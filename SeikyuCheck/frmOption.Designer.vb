<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOption
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOption))
        GroupBox1 = New GroupBox()
        txtHonsyaStartRow = New TextBox()
        lblHonsyaStartRow = New Label()
        cmbHonsyaMoney = New ComboBox()
        lblHonsyaMoney = New Label()
        cmbHonsyaName = New ComboBox()
        lblHonsyaName = New Label()
        cmbHonsyaNo = New ComboBox()
        lblHonsyaNo = New Label()
        gbMeibo = New GroupBox()
        txtMeiboMoney = New TextBox()
        lblMeiboMoney = New Label()
        txtMeiboMaxCol = New TextBox()
        lblMeiboMaxCol = New Label()
        txtMeiboMaxRow = New TextBox()
        lblMeiboMaxRow = New Label()
        txtMeiboStartRow = New TextBox()
        lblMeiboStartRow = New Label()
        cmbMeiboMemo = New ComboBox()
        lblMeiboMemo = New Label()
        cmbMeiboName = New ComboBox()
        lblMeiboName = New Label()
        cmbMeiboNo = New ComboBox()
        lblMeiboNo = New Label()
        btnCancel = New Button()
        btnOK = New Button()
        GroupBox1.SuspendLayout()
        gbMeibo.SuspendLayout()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(txtHonsyaStartRow)
        GroupBox1.Controls.Add(lblHonsyaStartRow)
        GroupBox1.Controls.Add(cmbHonsyaMoney)
        GroupBox1.Controls.Add(lblHonsyaMoney)
        GroupBox1.Controls.Add(cmbHonsyaName)
        GroupBox1.Controls.Add(lblHonsyaName)
        GroupBox1.Controls.Add(cmbHonsyaNo)
        GroupBox1.Controls.Add(lblHonsyaNo)
        GroupBox1.Location = New Point(12, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(273, 185)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "本社請求データ"
        ' 
        ' txtHonsyaStartRow
        ' 
        txtHonsyaStartRow.Location = New Point(167, 133)
        txtHonsyaStartRow.Name = "txtHonsyaStartRow"
        txtHonsyaStartRow.Size = New Size(100, 29)
        txtHonsyaStartRow.TabIndex = 7
        txtHonsyaStartRow.TextAlign = HorizontalAlignment.Right
        ' 
        ' lblHonsyaStartRow
        ' 
        lblHonsyaStartRow.AutoSize = True
        lblHonsyaStartRow.Location = New Point(12, 136)
        lblHonsyaStartRow.Name = "lblHonsyaStartRow"
        lblHonsyaStartRow.Size = New Size(93, 21)
        lblHonsyaStartRow.TabIndex = 6
        lblHonsyaStartRow.Text = "データ開始行"
        ' 
        ' cmbHonsyaMoney
        ' 
        cmbHonsyaMoney.DropDownStyle = ComboBoxStyle.DropDownList
        cmbHonsyaMoney.FormattingEnabled = True
        cmbHonsyaMoney.Location = New Point(167, 98)
        cmbHonsyaMoney.Name = "cmbHonsyaMoney"
        cmbHonsyaMoney.Size = New Size(100, 29)
        cmbHonsyaMoney.TabIndex = 5
        ' 
        ' lblHonsyaMoney
        ' 
        lblHonsyaMoney.AutoSize = True
        lblHonsyaMoney.Location = New Point(12, 101)
        lblHonsyaMoney.Name = "lblHonsyaMoney"
        lblHonsyaMoney.Size = New Size(58, 21)
        lblHonsyaMoney.TabIndex = 4
        lblHonsyaMoney.Text = "請求額"
        ' 
        ' cmbHonsyaName
        ' 
        cmbHonsyaName.DropDownStyle = ComboBoxStyle.DropDownList
        cmbHonsyaName.FormattingEnabled = True
        cmbHonsyaName.Location = New Point(167, 63)
        cmbHonsyaName.Name = "cmbHonsyaName"
        cmbHonsyaName.Size = New Size(100, 29)
        cmbHonsyaName.TabIndex = 3
        ' 
        ' lblHonsyaName
        ' 
        lblHonsyaName.AutoSize = True
        lblHonsyaName.Location = New Point(12, 66)
        lblHonsyaName.Name = "lblHonsyaName"
        lblHonsyaName.Size = New Size(42, 21)
        lblHonsyaName.TabIndex = 2
        lblHonsyaName.Text = "氏名"
        ' 
        ' cmbHonsyaNo
        ' 
        cmbHonsyaNo.DropDownStyle = ComboBoxStyle.DropDownList
        cmbHonsyaNo.FormattingEnabled = True
        cmbHonsyaNo.Location = New Point(167, 28)
        cmbHonsyaNo.Name = "cmbHonsyaNo"
        cmbHonsyaNo.Size = New Size(100, 29)
        cmbHonsyaNo.TabIndex = 1
        ' 
        ' lblHonsyaNo
        ' 
        lblHonsyaNo.AutoSize = True
        lblHonsyaNo.Location = New Point(12, 31)
        lblHonsyaNo.Name = "lblHonsyaNo"
        lblHonsyaNo.Size = New Size(74, 21)
        lblHonsyaNo.TabIndex = 0
        lblHonsyaNo.Text = "部屋番号"
        ' 
        ' gbMeibo
        ' 
        gbMeibo.Controls.Add(txtMeiboMoney)
        gbMeibo.Controls.Add(lblMeiboMoney)
        gbMeibo.Controls.Add(txtMeiboMaxCol)
        gbMeibo.Controls.Add(lblMeiboMaxCol)
        gbMeibo.Controls.Add(txtMeiboMaxRow)
        gbMeibo.Controls.Add(lblMeiboMaxRow)
        gbMeibo.Controls.Add(txtMeiboStartRow)
        gbMeibo.Controls.Add(lblMeiboStartRow)
        gbMeibo.Controls.Add(cmbMeiboMemo)
        gbMeibo.Controls.Add(lblMeiboMemo)
        gbMeibo.Controls.Add(cmbMeiboName)
        gbMeibo.Controls.Add(lblMeiboName)
        gbMeibo.Controls.Add(cmbMeiboNo)
        gbMeibo.Controls.Add(lblMeiboNo)
        gbMeibo.Location = New Point(291, 12)
        gbMeibo.Name = "gbMeibo"
        gbMeibo.Size = New Size(273, 290)
        gbMeibo.TabIndex = 1
        gbMeibo.TabStop = False
        gbMeibo.Text = "町会会員名簿"
        ' 
        ' txtMeiboMoney
        ' 
        txtMeiboMoney.Location = New Point(167, 238)
        txtMeiboMoney.Name = "txtMeiboMoney"
        txtMeiboMoney.Size = New Size(100, 29)
        txtMeiboMoney.TabIndex = 13
        txtMeiboMoney.TextAlign = HorizontalAlignment.Right
        ' 
        ' lblMeiboMoney
        ' 
        lblMeiboMoney.AutoSize = True
        lblMeiboMoney.Location = New Point(12, 241)
        lblMeiboMoney.Name = "lblMeiboMoney"
        lblMeiboMoney.Size = New Size(58, 21)
        lblMeiboMoney.TabIndex = 12
        lblMeiboMoney.Text = "町会費"
        ' 
        ' txtMeiboMaxCol
        ' 
        txtMeiboMaxCol.Location = New Point(167, 203)
        txtMeiboMaxCol.Name = "txtMeiboMaxCol"
        txtMeiboMaxCol.Size = New Size(100, 29)
        txtMeiboMaxCol.TabIndex = 11
        txtMeiboMaxCol.TextAlign = HorizontalAlignment.Right
        ' 
        ' lblMeiboMaxCol
        ' 
        lblMeiboMaxCol.AutoSize = True
        lblMeiboMaxCol.Location = New Point(12, 206)
        lblMeiboMaxCol.Name = "lblMeiboMaxCol"
        lblMeiboMaxCol.Size = New Size(42, 21)
        lblMeiboMaxCol.TabIndex = 10
        lblMeiboMaxCol.Text = "列数"
        ' 
        ' txtMeiboMaxRow
        ' 
        txtMeiboMaxRow.Location = New Point(167, 168)
        txtMeiboMaxRow.Name = "txtMeiboMaxRow"
        txtMeiboMaxRow.Size = New Size(100, 29)
        txtMeiboMaxRow.TabIndex = 9
        txtMeiboMaxRow.TextAlign = HorizontalAlignment.Right
        ' 
        ' lblMeiboMaxRow
        ' 
        lblMeiboMaxRow.AutoSize = True
        lblMeiboMaxRow.Location = New Point(12, 171)
        lblMeiboMaxRow.Name = "lblMeiboMaxRow"
        lblMeiboMaxRow.Size = New Size(42, 21)
        lblMeiboMaxRow.TabIndex = 8
        lblMeiboMaxRow.Text = "行数"
        ' 
        ' txtMeiboStartRow
        ' 
        txtMeiboStartRow.Location = New Point(167, 133)
        txtMeiboStartRow.Name = "txtMeiboStartRow"
        txtMeiboStartRow.Size = New Size(100, 29)
        txtMeiboStartRow.TabIndex = 7
        txtMeiboStartRow.TextAlign = HorizontalAlignment.Right
        ' 
        ' lblMeiboStartRow
        ' 
        lblMeiboStartRow.AutoSize = True
        lblMeiboStartRow.Location = New Point(12, 136)
        lblMeiboStartRow.Name = "lblMeiboStartRow"
        lblMeiboStartRow.Size = New Size(93, 21)
        lblMeiboStartRow.TabIndex = 6
        lblMeiboStartRow.Text = "データ開始行"
        ' 
        ' cmbMeiboMemo
        ' 
        cmbMeiboMemo.DropDownStyle = ComboBoxStyle.DropDownList
        cmbMeiboMemo.FormattingEnabled = True
        cmbMeiboMemo.Location = New Point(167, 98)
        cmbMeiboMemo.Name = "cmbMeiboMemo"
        cmbMeiboMemo.Size = New Size(100, 29)
        cmbMeiboMemo.TabIndex = 5
        ' 
        ' lblMeiboMemo
        ' 
        lblMeiboMemo.AutoSize = True
        lblMeiboMemo.Location = New Point(12, 101)
        lblMeiboMemo.Name = "lblMeiboMemo"
        lblMeiboMemo.Size = New Size(42, 21)
        lblMeiboMemo.TabIndex = 4
        lblMeiboMemo.Text = "備考"
        ' 
        ' cmbMeiboName
        ' 
        cmbMeiboName.DropDownStyle = ComboBoxStyle.DropDownList
        cmbMeiboName.FormattingEnabled = True
        cmbMeiboName.Location = New Point(167, 63)
        cmbMeiboName.Name = "cmbMeiboName"
        cmbMeiboName.Size = New Size(100, 29)
        cmbMeiboName.TabIndex = 3
        ' 
        ' lblMeiboName
        ' 
        lblMeiboName.AutoSize = True
        lblMeiboName.Location = New Point(12, 66)
        lblMeiboName.Name = "lblMeiboName"
        lblMeiboName.Size = New Size(42, 21)
        lblMeiboName.TabIndex = 2
        lblMeiboName.Text = "氏名"
        ' 
        ' cmbMeiboNo
        ' 
        cmbMeiboNo.DropDownStyle = ComboBoxStyle.DropDownList
        cmbMeiboNo.FormattingEnabled = True
        cmbMeiboNo.Location = New Point(167, 28)
        cmbMeiboNo.Name = "cmbMeiboNo"
        cmbMeiboNo.Size = New Size(100, 29)
        cmbMeiboNo.TabIndex = 1
        ' 
        ' lblMeiboNo
        ' 
        lblMeiboNo.AutoSize = True
        lblMeiboNo.Location = New Point(12, 31)
        lblMeiboNo.Name = "lblMeiboNo"
        lblMeiboNo.Size = New Size(74, 21)
        lblMeiboNo.TabIndex = 0
        lblMeiboNo.Text = "部屋番号"
        ' 
        ' btnCancel
        ' 
        btnCancel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnCancel.Location = New Point(12, 328)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(103, 47)
        btnCancel.TabIndex = 3
        btnCancel.Text = "取 消"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' btnOK
        ' 
        btnOK.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnOK.DialogResult = DialogResult.OK
        btnOK.Location = New Point(463, 328)
        btnOK.Name = "btnOK"
        btnOK.Size = New Size(103, 47)
        btnOK.TabIndex = 2
        btnOK.Text = "登 録"
        btnOK.UseVisualStyleBackColor = True
        ' 
        ' frmOption
        ' 
        AutoScaleDimensions = New SizeF(9F, 21F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = btnCancel
        ClientSize = New Size(578, 387)
        Controls.Add(btnOK)
        Controls.Add(btnCancel)
        Controls.Add(gbMeibo)
        Controls.Add(GroupBox1)
        Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(4)
        Name = "frmOption"
        Text = "設定"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        gbMeibo.ResumeLayout(False)
        gbMeibo.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblHonsyaStartRow As Label
    Friend WithEvents cmbHonsyaMoney As ComboBox
    Friend WithEvents lblHonsyaMoney As Label
    Friend WithEvents cmbHonsyaName As ComboBox
    Friend WithEvents lblHonsyaName As Label
    Friend WithEvents cmbHonsyaNo As ComboBox
    Friend WithEvents lblHonsyaNo As Label
    Friend WithEvents txtHonsyaStartRow As TextBox
    Friend WithEvents gbMeibo As GroupBox
    Friend WithEvents txtMeiboStartRow As TextBox
    Friend WithEvents txtMeiboMaxRow As TextBox
    Friend WithEvents lblMeiboStartRow As Label
    Friend WithEvents cmbMeiboMemo As ComboBox
    Friend WithEvents lblMeiboMemo As Label
    Friend WithEvents cmbMeiboName As ComboBox
    Friend WithEvents lblMeiboName As Label
    Friend WithEvents cmbMeiboNo As ComboBox
    Friend WithEvents lblMeiboNo As Label
    Friend WithEvents txtMeiboMoney As TextBox
    Friend WithEvents lblMeiboMoney As Label
    Friend WithEvents txtMeiboMaxCol As TextBox
    Friend WithEvents lblMeiboMaxCol As Label
    Friend WithEvents lblMeiboMaxRow As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOK As Button
End Class
