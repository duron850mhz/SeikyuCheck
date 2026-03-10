<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChokai
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChokai))
        lblHonsya = New Label()
        txtHonsya = New TextBox()
        btnHonsyaRef = New Button()
        lblMeibo = New Label()
        txtMeibo = New TextBox()
        btnMeiboRef = New Button()
        btnOption = New Button()
        btnOK = New Button()
        SuspendLayout()
        ' 
        ' lblHonsya
        ' 
        lblHonsya.AutoSize = True
        lblHonsya.Location = New Point(12, 9)
        lblHonsya.Name = "lblHonsya"
        lblHonsya.Size = New Size(109, 21)
        lblHonsya.TabIndex = 0
        lblHonsya.Text = "本社請求データ"
        ' 
        ' txtHonsya
        ' 
        txtHonsya.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtHonsya.Location = New Point(16, 33)
        txtHonsya.Name = "txtHonsya"
        txtHonsya.Size = New Size(649, 29)
        txtHonsya.TabIndex = 1
        ' 
        ' btnHonsyaRef
        ' 
        btnHonsyaRef.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnHonsyaRef.Location = New Point(671, 32)
        btnHonsyaRef.Name = "btnHonsyaRef"
        btnHonsyaRef.Size = New Size(75, 29)
        btnHonsyaRef.TabIndex = 2
        btnHonsyaRef.Text = "参照"
        btnHonsyaRef.UseVisualStyleBackColor = True
        ' 
        ' lblMeibo
        ' 
        lblMeibo.AutoSize = True
        lblMeibo.Location = New Point(16, 88)
        lblMeibo.Name = "lblMeibo"
        lblMeibo.Size = New Size(106, 21)
        lblMeibo.TabIndex = 3
        lblMeibo.Text = "町会会員名簿"
        ' 
        ' txtMeibo
        ' 
        txtMeibo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtMeibo.Location = New Point(16, 112)
        txtMeibo.Name = "txtMeibo"
        txtMeibo.Size = New Size(649, 29)
        txtMeibo.TabIndex = 4
        ' 
        ' btnMeiboRef
        ' 
        btnMeiboRef.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnMeiboRef.Location = New Point(671, 112)
        btnMeiboRef.Name = "btnMeiboRef"
        btnMeiboRef.Size = New Size(75, 29)
        btnMeiboRef.TabIndex = 5
        btnMeiboRef.Text = "参照"
        btnMeiboRef.UseVisualStyleBackColor = True
        ' 
        ' btnOption
        ' 
        btnOption.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnOption.Location = New Point(534, 200)
        btnOption.Name = "btnOption"
        btnOption.Size = New Size(103, 47)
        btnOption.TabIndex = 6
        btnOption.Text = "設 定"
        btnOption.UseVisualStyleBackColor = True
        ' 
        ' btnOK
        ' 
        btnOK.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnOK.Location = New Point(643, 200)
        btnOK.Name = "btnOK"
        btnOK.Size = New Size(103, 47)
        btnOK.TabIndex = 7
        btnOK.Text = "実 行"
        btnOK.UseVisualStyleBackColor = True
        ' 
        ' frmChokai
        ' 
        AutoScaleDimensions = New SizeF(9F, 21F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(758, 259)
        Controls.Add(btnOK)
        Controls.Add(btnOption)
        Controls.Add(btnMeiboRef)
        Controls.Add(txtMeibo)
        Controls.Add(lblMeibo)
        Controls.Add(btnHonsyaRef)
        Controls.Add(txtHonsya)
        Controls.Add(lblHonsya)
        Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(4)
        Name = "frmChokai"
        Text = "請求額チェック"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblHonsya As Label
    Friend WithEvents txtHonsya As TextBox
    Friend WithEvents btnHonsyaRef As Button
    Friend WithEvents lblMeibo As Label
    Friend WithEvents txtMeibo As TextBox
    Friend WithEvents btnMeiboRef As Button
    Friend WithEvents btnOption As Button
    Friend WithEvents btnOK As Button
End Class
