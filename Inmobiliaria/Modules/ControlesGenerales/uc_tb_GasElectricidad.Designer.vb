<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uc_tb_GasElectricidad

 
        Inherits DevExpress.XtraEditors.XtraUserControl

        'UserControl overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
        Me.RGruop = New DevExpress.XtraEditors.RadioGroup()
        Me.lblTitulo = New System.Windows.Forms.Label()
        CType(Me.RGruop.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RGruop
        '
        Me.RGruop.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RGruop.Location = New System.Drawing.Point(0, 0)
        Me.RGruop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RGruop.Name = "RGruop"
        Me.RGruop.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.RGruop.Properties.Columns = 3
        Me.RGruop.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Gas"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Elect."), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "NS")})
        Me.RGruop.Size = New System.Drawing.Size(152, 18)
        Me.RGruop.TabIndex = 213
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Location = New System.Drawing.Point(85, 6)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(38, 13)
        Me.lblTitulo.TabIndex = 214
        Me.lblTitulo.Text = "Label1"
        Me.lblTitulo.Visible = False
        '
        'uc_tb_GasElectricidad
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.RGruop)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "uc_tb_GasElectricidad"
        Me.Size = New System.Drawing.Size(154, 19)
        CType(Me.RGruop.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RGruop As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents lblTitulo As System.Windows.Forms.Label

    End Class

