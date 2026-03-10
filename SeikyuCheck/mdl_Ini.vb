Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text

Module mdl_Ini
    <DllImport("KERNEL32.DLL", CharSet:=CharSet.Auto)>
    Private Function GetPrivateProfileString(
                             ByVal lpAppName As String,
                             ByVal lpKeyName As String,
                             ByVal lpDefault As String,
                             ByVal lpReturnedString As StringBuilder,
                             ByVal nSize As Integer,
                             ByVal lpFileName As String) As Integer

    End Function

    <DllImport("KERNEL32.DLL", CharSet:=CharSet.Auto)>
    Private Function WritePrivateProfileString(
                              ByVal lpApplicationName As String,
                              ByVal lpKeyName As String,
                              ByVal lpString As String,
                              ByVal lpFileName As String) As Integer
    End Function

    ' KEY
    Public Const KEY_Chokai As String = "Chokai"

    ' SET
    Public Const SET_ChokaiHonsyaExcel As String = "ChokaiHonsyaExcel"
    Public Const SET_ChokaiMeiboExcel As String = "ChokaiMeiboExcel"
    Public Const SET_ChokaiOptionHonsyaNo As String = "ChokaiOptionHonsyaNo"
    Public Const SET_ChokaiOptionHonsyaName As String = "ChokaiOptionHonsyaName"
    Public Const SET_ChokaiOptionHonsyaMoney As String = "ChokaiOptionHonsyaMoney"
    Public Const SET_ChokaiOptionHonsyaStartRow As String = "ChokaiOptionHonsyaStartRow"
    Public Const SET_ChokaiOptionMeiboNo As String = "ChokaiOptionMeiboNo"
    Public Const SET_ChokaiOptionMeiboName As String = "ChokaiOptionMeiboName"
    Public Const SET_ChokaiOptionMeiboMemo As String = "ChokaiOptionMeiboMemo"
    Public Const SET_ChokaiOptionMeiboStartRow As String = "ChokaiOptionMeiboStartRow"
    Public Const SET_ChokaiOptionMeiboMaxRow As String = "ChokaiOptionMeiboMaxRow"
    Public Const SET_ChokaiOptionMeiboMaxCol As String = "ChokaiOptionMeiboMaxCol"
    Public Const SET_ChokaiOptionMeiboMoney As String = "ChokaiOptionMeiboMoney"
    Public Const SET_ChokaiResultAllData As String = "ChokaiResultAllData"
    Public Const SET_ChokaiResultMonth As String = "ChokaiResultMonth"
    Public Const SET_ChokaiResultCSVOutput As String = "ChokaiResultCSVOutput"

    ''' <summary>
    ''' ini読み込み
    ''' </summary>
    ''' <param name="strSection"></param>
    ''' <param name="strKeyName"></param>
    ''' <returns></returns>
    Public Function C_ReadIni(ByVal strSection As String,
                                     ByVal strKeyName As String) As String
        Try
            Dim strAppPath As String = System.Reflection.Assembly.GetExecutingAssembly().Location
            Dim strIniFileName As String = Path.ChangeExtension(strAppPath, "ini")

            Dim strWork As System.Text.StringBuilder = New System.Text.StringBuilder(1024)
            Dim intRet As Integer = GetPrivateProfileString(strSection, strKeyName, "", strWork, strWork.Capacity - 1, strIniFileName)
            If intRet > 0 Then
                Return strWork.ToString
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function


    ''' <summary>
    ''' ini書き込み
    ''' </summary>
    ''' <param name="strSection"></param>
    ''' <param name="strKeyName"></param>
    ''' <param name="strSet"></param>
    ''' <returns></returns>
    Public Function C_WriteIni(ByVal strSection As String,
                                       ByVal strKeyName As String,
                                       ByVal strSet As String) As Boolean
        Try
            Dim strAppPath As String = System.Reflection.Assembly.GetExecutingAssembly().Location
            Dim strIniFileName As String = Path.ChangeExtension(strAppPath, "ini")

            Dim intRet As Integer = WritePrivateProfileString(strSection, strKeyName, strSet, strIniFileName)
            If intRet > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Ini存在チェック
    ''' </summary>
    ''' <param name="strSection"></param>
    ''' <param name="strKeyName"></param>
    ''' <returns></returns>
    Public Function C_ExistsIni() As Boolean
        Return File.Exists(Path.ChangeExtension(System.Reflection.Assembly.GetExecutingAssembly().Location, "ini"))
    End Function

    ''' <summary>
    ''' Ini初期作成
    ''' </summary>
    Public Sub C_CreateIni()
        ' frmChokai
        C_WriteIni(KEY_Chokai, SET_ChokaiHonsyaExcel, "")
        C_WriteIni(KEY_Chokai, SET_ChokaiMeiboExcel, "")

        ' frmOption
        C_WriteIni(KEY_Chokai, SET_ChokaiOptionHonsyaNo, "2")
        C_WriteIni(KEY_Chokai, SET_ChokaiOptionHonsyaName, "3")
        C_WriteIni(KEY_Chokai, SET_ChokaiOptionHonsyaMoney, "10")
        C_WriteIni(KEY_Chokai, SET_ChokaiOptionHonsyaStartRow, "2")
        C_WriteIni(KEY_Chokai, SET_ChokaiOptionMeiboNo, "2")
        C_WriteIni(KEY_Chokai, SET_ChokaiOptionMeiboName, "3")
        C_WriteIni(KEY_Chokai, SET_ChokaiOptionMeiboMemo, "4")
        C_WriteIni(KEY_Chokai, SET_ChokaiOptionMeiboStartRow, "2")
        C_WriteIni(KEY_Chokai, SET_ChokaiOptionMeiboMaxRow, "40")
        C_WriteIni(KEY_Chokai, SET_ChokaiOptionMeiboMaxCol, "4")
        C_WriteIni(KEY_Chokai, SET_ChokaiOptionMeiboMoney, "200")

        ' frmChokaiResult
        C_WriteIni(KEY_Chokai, SET_ChokaiResultAllData, "False")
        C_WriteIni(KEY_Chokai, SET_ChokaiResultMonth, "2")
    End Sub
End Module
