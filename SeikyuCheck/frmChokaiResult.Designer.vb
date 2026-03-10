<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChokaiResult
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChokaiResult))
        dgv = New DataGridView()
        col_本社部屋番号 = New DataGridViewTextBoxColumn()
        col_本社氏名 = New DataGridViewTextBoxColumn()
        col_本社請求額 = New DataGridViewTextBoxColumn()
        col_名簿部屋番号 = New DataGridViewTextBoxColumn()
        col_名簿氏名 = New DataGridViewTextBoxColumn()
        col_名簿備考 = New DataGridViewTextBoxColumn()
        chkAllData = New CheckBox()
        cmbMonth = New ComboBox()
        btnQuit = New Button()
        btnCSV = New Button()
        CType(dgv, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dgv
        ' 
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False
        dgv.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgv.Columns.AddRange(New DataGridViewColumn() {col_本社部屋番号, col_本社氏名, col_本社請求額, col_名簿部屋番号, col_名簿氏名, col_名簿備考})
        dgv.Location = New Point(12, 12)
        dgv.Name = "dgv"
        dgv.Size = New Size(1005, 553)
        dgv.TabIndex = 0
        ' 
        ' col_本社部屋番号
        ' 
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight
        col_本社部屋番号.DefaultCellStyle = DataGridViewCellStyle1
        col_本社部屋番号.HeaderText = "部屋番号"
        col_本社部屋番号.Name = "col_本社部屋番号"
        col_本社部屋番号.ReadOnly = True
        ' 
        ' col_本社氏名
        ' 
        col_本社氏名.HeaderText = "氏名"
        col_本社氏名.Name = "col_本社氏名"
        col_本社氏名.ReadOnly = True
        col_本社氏名.Width = 200
        ' 
        ' col_本社請求額
        ' 
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight
        col_本社請求額.DefaultCellStyle = DataGridViewCellStyle2
        col_本社請求額.HeaderText = "請求額"
        col_本社請求額.Name = "col_本社請求額"
        col_本社請求額.ReadOnly = True
        ' 
        ' col_名簿部屋番号
        ' 
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight
        col_名簿部屋番号.DefaultCellStyle = DataGridViewCellStyle3
        col_名簿部屋番号.HeaderText = "部屋番号"
        col_名簿部屋番号.Name = "col_名簿部屋番号"
        col_名簿部屋番号.ReadOnly = True
        ' 
        ' col_名簿氏名
        ' 
        col_名簿氏名.HeaderText = "氏名"
        col_名簿氏名.Name = "col_名簿氏名"
        col_名簿氏名.ReadOnly = True
        col_名簿氏名.Width = 200
        ' 
        ' col_名簿備考
        ' 
        col_名簿備考.HeaderText = "備考"
        col_名簿備考.Name = "col_名簿備考"
        col_名簿備考.ReadOnly = True
        col_名簿備考.Width = 150
        ' 
        ' chkAllData
        ' 
        chkAllData.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        chkAllData.AutoSize = True
        chkAllData.Location = New Point(12, 593)
        chkAllData.Name = "chkAllData"
        chkAllData.Size = New Size(184, 25)
        chkAllData.TabIndex = 1
        chkAllData.Text = "すべてのデータを表示する"
        chkAllData.UseVisualStyleBackColor = True
        ' 
        ' cmbMonth
        ' 
        cmbMonth.DropDownStyle = ComboBoxStyle.DropDownList
        cmbMonth.FormattingEnabled = True
        cmbMonth.Location = New Point(234, 589)
        cmbMonth.Name = "cmbMonth"
        cmbMonth.Size = New Size(121, 29)
        cmbMonth.TabIndex = 2
        ' 
        ' btnQuit
        ' 
        btnQuit.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnQuit.Location = New Point(914, 571)
        btnQuit.Name = "btnQuit"
        btnQuit.Size = New Size(103, 47)
        btnQuit.TabIndex = 4
        btnQuit.Text = "終 了"
        btnQuit.UseVisualStyleBackColor = True
        ' 
        ' btnCSV
        ' 
        btnCSV.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnCSV.Location = New Point(805, 571)
        btnCSV.Name = "btnCSV"
        btnCSV.Size = New Size(103, 47)
        btnCSV.TabIndex = 3
        btnCSV.Text = "CSV出力"
        btnCSV.UseVisualStyleBackColor = True
        ' 
        ' frmChokaiResult
        ' 
        AutoScaleDimensions = New SizeF(9F, 21F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = btnQuit
        ClientSize = New Size(1029, 630)
        Controls.Add(btnCSV)
        Controls.Add(btnQuit)
        Controls.Add(cmbMonth)
        Controls.Add(chkAllData)
        Controls.Add(dgv)
        Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(4)
        Name = "frmChokaiResult"
        Text = "比較結果"
        CType(dgv, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dgv As DataGridView
    Friend WithEvents chkAllData As CheckBox
    Friend WithEvents cmbMonth As ComboBox
    Friend WithEvents btnQuit As Button
    Friend WithEvents btnCSV As Button
    Friend WithEvents col_本社部屋番号 As DataGridViewTextBoxColumn
    Friend WithEvents col_本社氏名 As DataGridViewTextBoxColumn
    Friend WithEvents col_本社請求額 As DataGridViewTextBoxColumn
    Friend WithEvents col_名簿部屋番号 As DataGridViewTextBoxColumn
    Friend WithEvents col_名簿氏名 As DataGridViewTextBoxColumn
    Friend WithEvents col_名簿備考 As DataGridViewTextBoxColumn
End Class
