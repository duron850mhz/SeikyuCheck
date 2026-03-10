Imports System.ComponentModel

Public Class frmOption
    ''' <summary>
    ''' 初期化
    ''' </summary>
    Private Sub I_Init()
        Call I_SetRowCombo(cmbHonsyaNo)
        Call I_SetRowCombo(cmbHonsyaName)
        Call I_SetRowCombo(cmbHonsyaMoney)
        Call I_SetRowCombo(cmbMeiboNo)
        Call I_SetRowCombo(cmbMeiboName)
        Call I_SetRowCombo(cmbMeiboMemo)

        cmbHonsyaNo.SelectedValue = C_ReadIni(KEY_Chokai, SET_ChokaiOptionHonsyaNo)
        cmbHonsyaName.SelectedValue = C_ReadIni(KEY_Chokai, SET_ChokaiOptionHonsyaName)
        cmbHonsyaMoney.SelectedValue = C_ReadIni(KEY_Chokai, SET_ChokaiOptionHonsyaMoney)
        txtHonsyaStartRow.Text = C_ReadIni(KEY_Chokai, SET_ChokaiOptionHonsyaStartRow)
        cmbMeiboNo.SelectedValue = C_ReadIni(KEY_Chokai, SET_ChokaiOptionMeiboNo)
        cmbMeiboName.SelectedValue = C_ReadIni(KEY_Chokai, SET_ChokaiOptionMeiboName)
        cmbMeiboMemo.SelectedValue = C_ReadIni(KEY_Chokai, SET_ChokaiOptionMeiboMemo)
        txtMeiboStartRow.Text = C_ReadIni(KEY_Chokai, SET_ChokaiOptionMeiboStartRow)
        txtMeiboMaxRow.Text = C_ReadIni(KEY_Chokai, SET_ChokaiOptionMeiboMaxRow)
        txtMeiboMaxCol.Text = C_ReadIni(KEY_Chokai, SET_ChokaiOptionMeiboMaxCol)
        txtMeiboMoney.Text = C_ReadIni(KEY_Chokai, SET_ChokaiOptionMeiboMoney)
    End Sub

    ''' <summary>
    ''' 行コンボ設定
    ''' </summary>
    ''' <param      
    ''' </summary>
    ''' <param name="cmb"></param>
    Private Sub I_SetRowCombo(cmb As ComboBox)
        Dim dt As New DataTable
        dt.Columns.Add("Value")
        dt.Columns.Add("Text")
        For i As Integer = 1 To 52
            Dim dr As DataRow = dt.NewRow
            dr("Value") = i
            dr("Text") = I_GetExcelColName(i) & "列"
            dt.Rows.Add(dr)
        Next
        cmb.DataSource = dt
        cmb.ValueMember = "Value"
        cmb.DisplayMember = "Text"
    End Sub

    ''' <summary>
    ''' Excelの列名を取得
    ''' </summary>
    ''' <param name="iCol"></param>
    ''' <returns></returns>
    Private Function I_GetExcelColName(ByVal iCol As Integer) As String
        Dim iAlpha As Integer = (iCol - 1) \ 26
        Dim iBeta As Integer = (iCol - 1) Mod 26
        Dim strAlpha As String = If(iAlpha > 0, Chr(64 + iAlpha), "")
        Dim strBeta As String = Chr(65 + iBeta)
        Return strAlpha & strBeta
    End Function

    ''' <summary>
    ''' FormLoad
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmOption_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call I_Init()
    End Sub

    ''' <summary>
    ''' FormClosing
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmOption_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        C_WriteIni(KEY_Chokai, SET_ChokaiOptionHonsyaNo, cmbHonsyaNo.SelectedValue)
        C_WriteIni(KEY_Chokai, SET_ChokaiOptionHonsyaName, cmbHonsyaName.SelectedValue)
        C_WriteIni(KEY_Chokai, SET_ChokaiOptionHonsyaMoney, cmbHonsyaMoney.SelectedValue)
        C_WriteIni(KEY_Chokai, SET_ChokaiOptionHonsyaStartRow, txtHonsyaStartRow.Text)
        C_WriteIni(KEY_Chokai, SET_ChokaiOptionMeiboNo, cmbMeiboNo.SelectedValue)
        C_WriteIni(KEY_Chokai, SET_ChokaiOptionMeiboName, cmbMeiboName.SelectedValue)
        C_WriteIni(KEY_Chokai, SET_ChokaiOptionMeiboMemo, cmbMeiboMemo.SelectedValue)
        C_WriteIni(KEY_Chokai, SET_ChokaiOptionMeiboStartRow, txtMeiboStartRow.Text)
        C_WriteIni(KEY_Chokai, SET_ChokaiOptionMeiboMaxRow, txtMeiboMaxRow.Text)
        C_WriteIni(KEY_Chokai, SET_ChokaiOptionMeiboMaxCol, txtMeiboMaxCol.Text)
        C_WriteIni(KEY_Chokai, SET_ChokaiOptionMeiboMoney, txtMeiboMoney.Text)
    End Sub
End Class