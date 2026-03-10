Imports System.IO
Imports System.Text
Imports ExcelDataReader

Public Class frmChokaiResult
    Dim LG_bSetbyProg As Boolean = False

    Private Class clsHonsyaData
        Public Property Room As String
        Public Property Name As String
        Public Property Amount As Decimal
    End Class
    Private Class clsMeiboData
        Public Property Room As String
        Public Property Name As String
        Public Property Memo As String
    End Class

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
        ' clear
        dgv.Rows.Clear()

        ' Excelファイルパス
        Dim ExcelHonsya As String = C_ReadIni(KEY_Chokai, SET_ChokaiHonsyaExcel)
        Dim ExcelMeibo As String = C_ReadIni(KEY_Chokai, SET_ChokaiMeiboExcel)

        ' Iniからパラメータ取得  
        Dim iHonsyaNo As Integer = CInt(C_ReadIni(KEY_Chokai, SET_ChokaiOptionHonsyaNo))
        Dim iHonsyaName As Integer = CInt(C_ReadIni(KEY_Chokai, SET_ChokaiOptionHonsyaName))
        Dim iHonsyaMoney As Integer = CInt(C_ReadIni(KEY_Chokai, SET_ChokaiOptionHonsyaMoney))
        Dim iHonsyaStartRow As Integer = CInt(C_ReadIni(KEY_Chokai, SET_ChokaiOptionHonsyaStartRow))
        Dim iMeiboNo As Integer = CInt(C_ReadIni(KEY_Chokai, SET_ChokaiOptionMeiboNo))
        Dim iMeiboName As Integer = CInt(C_ReadIni(KEY_Chokai, SET_ChokaiOptionMeiboName))
        Dim iMeiboMemo As Integer = CInt(C_ReadIni(KEY_Chokai, SET_ChokaiOptionMeiboMemo))
        Dim iMeiboStartRow As Integer = CInt(C_ReadIni(KEY_Chokai, SET_ChokaiOptionMeiboStartRow))
        Dim iMeiboMaxRow As Integer = CInt(C_ReadIni(KEY_Chokai, SET_ChokaiOptionMeiboMaxRow))
        Dim iMeiboMaxCol As Integer = CInt(C_ReadIni(KEY_Chokai, SET_ChokaiOptionMeiboMaxCol))
        Dim dMeiboMoney As Decimal = CDec(C_ReadIni(KEY_Chokai, SET_ChokaiOptionMeiboMoney))

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

            ' Excelからデータ取得
            Dim listHonsya As List(Of clsHonsyaData) = I_ReadHonsyaData(ExcelHonsya, iHonsyaNo, iHonsyaName, iHonsyaMoney, iHonsyaStartRow)
            Dim listMeibo As List(Of clsMeiboData) = I_ReadMeiboData(ExcelMeibo, iMeiboNo, iMeiboName, iMeiboMemo, iMeiboStartRow, iMeiboMaxRow, iMeiboMaxCol)

            ' 想定額
            Dim expectedAmount As Decimal = dMeiboMoney * cmbMonth.SelectedValue

            ' 1. Room をキーにして両方のリストを結合（Full Outer Join的なアプローチ）
            ' 全てのRoom（部屋番号）のユニークリストを作成
            Dim allRooms = listHonsya.Select(Function(h) h.Room).
                   Union(listMeibo.Select(Function(m) m.Room)).Distinct()

            For Each roomNo In allRooms
                ' 各リストから該当するRoomのデータを取得（無い場合はNothing）
                Dim honsya = listHonsya.FirstOrDefault(Function(h) h.Room = roomNo)
                Dim meibo = listMeibo.FirstOrDefault(Function(m) m.Room = roomNo)

                Dim hAmount As Decimal = If(honsya IsNot Nothing, honsya.Amount, 0)
                Dim name As String = If(meibo IsNot Nothing, meibo.Name, If(honsya IsNot Nothing, honsya.Name, "不明"))

                ' --- 判定ロジック ---

                ' ① 名簿に無いのに金額が0ではない
                If meibo Is Nothing AndAlso hAmount <> 0 Then
                    Call I_AddRow(honsya, meibo) ' データ追加
                    Continue For
                End If

                ' ② 名簿にあるのに金額が0
                If meibo IsNot Nothing AndAlso hAmount = 0 Then
                    Call I_AddRow(honsya, meibo) ' データ追加
                    Continue For
                End If

                ' ③ 金額が想定額と一致しない (両方にデータがある場合)
                If meibo IsNot Nothing AndAlso honsya IsNot Nothing AndAlso hAmount <> expectedAmount Then
                    Call I_AddRow(honsya, meibo) ' データ追加
                    Continue For
                End If

                ' 正常
                If chkAllData.Checked Then
                    Call I_AddRow(honsya, meibo, False) ' データ追加
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("エラーが発生しました: " & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub I_AddRow(ByVal honsya As clsHonsyaData, ByVal meibo As clsMeiboData, Optional ByVal bColor As Boolean = True)
        dgv.Rows.Add()
        Dim iRow As Integer = dgv.Rows.Count - 1
        dgv.Rows(iRow).Cells(col_本社部屋番号.Index).Value = honsya?.Room
        dgv.Rows(iRow).Cells(col_本社氏名.Index).Value = honsya?.Name
        dgv.Rows(iRow).Cells(col_本社請求額.Index).Value = If(honsya IsNot Nothing, honsya.Amount.ToString("N0"), "")
        dgv.Rows(iRow).Cells(col_名簿部屋番号.Index).Value = meibo?.Room
        dgv.Rows(iRow).Cells(col_名簿氏名.Index).Value = meibo?.Name
        dgv.Rows(iRow).Cells(col_名簿備考.Index).Value = meibo?.Memo

        If bColor = True And chkAllData.Checked = True Then
            ' 照合エラー行は赤で表示
            dgv.Rows(iRow).Cells(col_本社部屋番号.Index).Style.BackColor = Color.Red
        End If
    End Sub

    ''' <summary>
    ''' Excelから名簿データ取得
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <param name="roomIndex"></param>
    ''' <param name="nameIndex"></param>
    ''' <param name="memoIndex"></param>
    ''' <param name="dataStartRow"></param>
    ''' <param name="maxRow"></param>
    ''' <param name="maxCol"></param>
    ''' <returns></returns>
    Private Function I_ReadMeiboData(filePath As String, roomIndex As Integer, nameIndex As Integer, memoIndex As Integer, dataStartRow As Integer, maxRow As Integer, maxCol As Integer) As List(Of clsMeiboData)
        Dim result As New List(Of clsMeiboData)
        Using stream = File.Open(filePath, FileMode.Open, FileAccess.Read)
            Using reader = ExcelReaderFactory.CreateReader(stream)
                Dim ds = reader.AsDataSet(New ExcelDataSetConfiguration() With {
                .ConfigureDataTable = Function(tableReader) New ExcelDataTableConfiguration() With {
                    .UseHeaderRow = False   ' ヘッダー扱いしない
                }
            })
                Dim table = ds.Tables(0)
                Dim iColCount As Integer = 0
                Do
                    ' dataStartRow は1始まり（1=1行目からデータ）
                    For rowIdx = dataStartRow - 1 To maxRow - 1
                        ' 指定行数ループ
                        Dim valRoom = table.Rows(rowIdx + iColCount)(roomIndex - 1)?.ToString().Trim()
                        Dim valName = table.Rows(rowIdx)(nameIndex - 1)?.ToString().Trim()
                        Dim valMemo = table.Rows(rowIdx)(memoIndex - 1)?.ToString().Trim()
                        If Not String.IsNullOrEmpty(valRoom) Then
                            Dim clsVal As New clsMeiboData With {
                            .Room = valRoom,
                            .Name = valName,
                            .Memo = valMemo
                        }
                            result.Add(clsVal)
                        Else
                            '部屋番号空白はデータ終端とみなす
                            Exit Do
                        End If
                    Next

                    '次のブロックへ
                    iColCount += maxCol
                Loop
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
    Private Function I_ReadHonsyaData(filePath As String, roomColIndex As Integer, nameIndex As Integer, amountColIndex As Integer, dataStartRow As Integer) As List(Of clsHonsyaData)
        Dim result As New List(Of clsHonsyaData)
        Using stream = File.Open(filePath, FileMode.Open, FileAccess.Read)
            Using reader = ExcelReaderFactory.CreateReader(stream)
                Dim ds = reader.AsDataSet(New ExcelDataSetConfiguration() With {
                    .ConfigureDataTable = Function(tableReader) New ExcelDataTableConfiguration() With {
                        .UseHeaderRow = False
                    }
                })
                Dim table = ds.Tables(0)
                ' 終端までループ
                For rowIdx = dataStartRow - 1 To table.Rows.Count - 1
                    Dim valRoom = table.Rows(rowIdx)(roomColIndex - 1)?.ToString().Trim()
                    Dim valName = table.Rows(rowIdx)(nameIndex - 1)?.ToString().Trim()
                    Dim valAmountStr = table.Rows(rowIdx)(amountColIndex - 1)?.ToString().Trim()
                    ' 部屋番号が空白または数値でない場合はスキップ（空白は終端、数値以外は誤データとみなす）
                    If (String.IsNullOrEmpty(valRoom) Or IsNumeric(valRoom) = False) Then Continue For

                    ' 請求額は数値以外は0扱い
                    Dim amount As Decimal = 0
                    Decimal.TryParse(valAmountStr, amount)

                    ' データ追加
                    Dim clsVal As New clsHonsyaData With {
                            .Room = valRoom,
                            .Name = valName,
                            .Amount = amount
                        }
                    result.Add(clsVal)
                Next

                ' 部屋番号重複は請求額合算
                result = result.GroupBy(Function(x) x.Room).Select(Function(g) New clsHonsyaData With {
                    .Room = g.Key,
                    .Name = g.First().Name, ' 同一部屋番号の名前は同一とみなす（異なる場合は最初の行の名前を採用）
                    .Amount = g.Sum(Function(x) x.Amount)
                }).ToList()
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