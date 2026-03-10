Imports System.IO

Public Class frmChokai
    ''' <summary>
    ''' 初期化
    ''' </summary>
    Private Sub I_Init()
        If C_ExistsIni() = False Then
            C_CreateIni()
        Else
            txtHonsya.Text = C_ReadIni(KEY_Chokai, SET_ChokaiHonsyaExcel)
            txtMeibo.Text = C_ReadIni(KEY_Chokai, SET_ChokaiMeiboExcel)
        End If
    End Sub

    ''' <summary>
    ''' 設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnOption_Click(sender As Object, e As EventArgs) Handles btnOption.Click
        Using _frm As New frmOption
            _frm.ShowDialog(Me)
        End Using
    End Sub

    ''' <summary>
    ''' 実行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Using _frm As New frmChokaiResult
            _frm.ShowDialog(Me)
        End Using
    End Sub

    ''' <summary>
    ''' Excelファイル参照
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnHonsyaRef_Click(sender As Object, e As EventArgs) Handles btnHonsyaRef.Click, btnMeiboRef.Click
        Using ofd As New OpenFileDialog
            Dim txtTarget As TextBox = Nothing
            Select Case True
                Case sender Is btnHonsyaRef
                    txtTarget = txtHonsya
                Case sender Is btnMeiboRef
                    txtTarget = txtMeibo
            End Select

            ofd.FileName = Path.GetFileName(txtTarget.Text)
            ofd.InitialDirectory = Path.GetDirectoryName(txtTarget.Text)
            ofd.Title = "開くファイルを選択してください"
            ofd.RestoreDirectory = True

            ofd.Filter = "Excelファイル|*.xlsx;*.xls"
            If ofd.ShowDialog(Me) = DialogResult.OK Then
                txtTarget.Text = ofd.FileName
            End If
        End Using
    End Sub

    ''' <summary>
    ''' FormLoad
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmChokai_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call I_Init()
    End Sub

    ''' <summary>
    ''' FormClosing
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmChokai_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        C_WriteIni(KEY_Chokai, SET_ChokaiHonsyaExcel, txtHonsya.Text)
        C_WriteIni(KEY_Chokai, SET_ChokaiMeiboExcel, txtMeibo.Text)
    End Sub
End Class