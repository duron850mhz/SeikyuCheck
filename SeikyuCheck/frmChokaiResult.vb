Imports System.IO
Imports System.Text
Imports ExcelDataReader

Public Class frmChokaiResult
    Dim LG_bSetbyProg As Boolean = False

    ''' <summary>
    ''' 初期化
    ''' </summary>
    Private Sub I_Init()
        LG_bSetbyProg = True

        ' 全データチェック
        chkAllData.Checked = C_ReadIni(KEY_Chokai, SET_ChokaiResultAllData)

        ' 月数コンボ設定
        Dim dt As New DataTable
        dt.Columns.Add("Value")
        dt.Columns.Add("Text")
        For i As Integer = 1 To 12
            Dim dr As DataRow = dt.NewRow
            dr("Value") = i
            dr("Text") = i & "ヶ月分"
            dt.Rows.Add(dr)
        Next
        cmbMonth.DataSource = dt
        cmbMonth.ValueMember = "Value"
        cmbMonth.DisplayMember = "Text"
        cmbMonth.SelectedValue = C_ReadIni(KEY_Chokai, SET_ChokaiResultMonth)

        ' 色塗り
        For i As Integer = 3 To 5
            dgv.Columns(i).DefaultCellStyle.BackColor = Color.LightCyan
        Next

        ' Dummy data
        For r As Integer = 1 To 40
            dgv.Rows.Add("101", "山田太郎", "10,000", "101", "山田太郎", "備考")
        Next

        LG_bSetbyProg = False
    End Sub

    ''' <summary>
    ''' 照合
    ''' </summary>
    Private Sub I_DataSet()
        ' Excelファイルパス
        Dim ExcelHonsya As String = C_ReadIni(KEY_Chokai, SET_ChokaiHonsyaExcel)
        Dim ExcelMeibo As String = C_ReadIni(KEY_Chokai, SET_ChokaiMeiboExcel)

        ' 存在チェック
        If File.Exists(ExcelHonsya) = False Then
            MessageBox.Show("本社データのExcelファイルが存在しません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        ElseIf File.Exists(ExcelMeibo) = False Then
            MessageBox.Show("名簿データのExcelファイルが存在しません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            ' ExcelDataReaderの文字化け対策（必須）
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance)


        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Excelの指定列をHashSetで読み込み（重複排除）
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <param name="colIndex"></param>
    ''' <param name="dataStartRow"></param>
    ''' <returns></returns>
    Function I_ReadColumn(filePath As String, colIndex As Integer, dataStartRow As Integer) As HashSet(Of String)
        Dim result As New HashSet(Of String)
        Using stream = File.Open(filePath, FileMode.Open, FileAccess.Read)
            Using reader = ExcelReaderFactory.CreateReader(stream)
                Dim ds = reader.AsDataSet(New ExcelDataSetConfiguration() With {
                .ConfigureDataTable = Function(tableReader) New ExcelDataTableConfiguration() With {
                    .UseHeaderRow = False   ' ヘッダー扱いしない
                }
            })
                Dim table = ds.Tables(0)
                ' dataStartRow は1始まり（1=1行目からデータ）
                For rowIdx = dataStartRow - 1 To table.Rows.Count - 1
                    Dim val = table.Rows(rowIdx)(colIndex)?.ToString().Trim()
                    If Not String.IsNullOrEmpty(val) Then
                        result.Add(val)
                    End If
                Next
            End Using
        End Using
        Return result
    End Function

    ''' <summary>
    ''' Excelの指定列をDictionaryで読み込み（部屋番号→請求額、重複部屋番号は請求額合算）
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <param name="roomColIndex"></param>
    ''' <param name="amountColIndex"></param>
    ''' <param name="dataStartRow"></param>
    ''' <returns></returns>
    Function ReadBillingData(filePath As String, roomColIndex As Integer, amountColIndex As Integer, dataStartRow As Integer) As Dictionary(Of String, Decimal)
        Dim result As New Dictionary(Of String, Decimal)
        Using stream = File.Open(filePath, FileMode.Open, FileAccess.Read)
            Using reader = ExcelReaderFactory.CreateReader(stream)
                Dim ds = reader.AsDataSet(New ExcelDataSetConfiguration() With {
                    .ConfigureDataTable = Function(tableReader) New ExcelDataTableConfiguration() With {
                        .UseHeaderRow = False
                    }
                })
                Dim table = ds.Tables(0)
                For rowIdx = dataStartRow - 1 To table.Rows.Count - 1
                    Dim room = table.Rows(rowIdx)(roomColIndex)?.ToString().Trim()
                    Dim amountStr = table.Rows(rowIdx)(amountColIndex)?.ToString().Trim()
                    If String.IsNullOrEmpty(room) Then Continue For

                    Dim amount As Decimal = 0
                    Decimal.TryParse(amountStr, amount)

                    If result.ContainsKey(room) Then
                        result(room) += amount   ' 重複部屋番号は合算
                    Else
                        result.Add(room, amount)
                    End If
                Next
            End Using
        End Using
        Return result
    End Function

    ''' <summary>
    ''' CSV出力
    ''' </summary>
    ''' <param name="filePath"></param>
    Private Sub I_OutputCSV(ByVal filePath As String)
        Try
            ' UTF-8 (BOM付き) で保存（Excelで開いた時の文字化け防止）
            Using sw As New StreamWriter(filePath, False, Encoding.GetEncoding("UTF-8"))

                ' 1. ヘッダー行の書き出し
                Dim columnCount As Integer = dgv.Columns.Count
                Dim columnNames As New List(Of String)
                For i As Integer = 0 To columnCount - 1
                    ' 非表示列を除外したい場合は If dgv.Columns(i).Visible Then を追加
                    columnNames.Add(dgv.Columns(i).HeaderText)
                Next
                sw.WriteLine(String.Join(",", columnNames))

                ' 2. データ行の書き出し
                For Each row As DataGridViewRow In dgv.Rows
                    ' 新規入力用の空行（AllowUserToAddRows = True の場合）をスキップ
                    If Not row.IsNewRow Then
                        Dim cells As New List(Of String)
                        For j As Integer = 0 To columnCount - 1
                            ' セルの値を取得し、カンマや改行が含まれる場合は引用符で囲む
                            Dim cellValue As String = If(row.Cells(j).Value?.ToString(), "")

                            ' CSV特有の特殊文字対応 (カンマやダブルクォーテーション)
                            If cellValue.Contains(",") OrElse cellValue.Contains("""") OrElse cellValue.Contains(vbCrLf) Then
                                cellValue = """" & cellValue.Replace("""", """""") & """"
                            End If

                            cells.Add(cellValue)
                        Next
                        sw.WriteLine(String.Join(",", cells))
                    End If
                Next
            End Using

            MessageBox.Show("CSV出力が完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("エラーが発生しました: " & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' FormLoad
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmChokaiResult_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call I_Init()
        Call I_DataSet()
    End Sub

    ''' <summary>
    ''' FormClosing
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmChokaiResult_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        C_WriteIni(KEY_Chokai, SET_ChokaiResultAllData, chkAllData.Checked)
        C_WriteIni(KEY_Chokai, SET_ChokaiResultMonth, cmbMonth.SelectedValue)
    End Sub

    ''' <summary>
    ''' CSV出力
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>    
    Private Sub btnCSV_Click(sender As Object, e As EventArgs) Handles btnCSV.Click
        Using sfd As New SaveFileDialog
            sfd.FileName = Path.GetFileName(C_ReadIni(KEY_Chokai, SET_ChokaiResultCSVOutput))
            sfd.InitialDirectory = Path.GetDirectoryName(C_ReadIni(KEY_Chokai, SET_ChokaiResultCSVOutput))
            sfd.Title = "保存先を選択してください"
            sfd.RestoreDirectory = True
            sfd.Filter = "CSVファイル|*.csv"
            If sfd.ShowDialog(Me) = DialogResult.OK Then
                Dim strFilePath As String = sfd.FileName
                C_WriteIni(KEY_Chokai, SET_ChokaiResultCSVOutput, strFilePath)
                Call I_OutputCSV(strFilePath)
            End If
        End Using
    End Sub

    ''' <summary>
    ''' チェケラ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub chkAllData_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllData.CheckedChanged
        If LG_bSetbyProg = False Then
            Call I_DataSet()
        End If
    End Sub

    ''' <summary>
    ''' 月数変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmbMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMonth.SelectedIndexChanged
        If LG_bSetbyProg = False Then
            Call I_DataSet()
        End If
    End Sub
End Class