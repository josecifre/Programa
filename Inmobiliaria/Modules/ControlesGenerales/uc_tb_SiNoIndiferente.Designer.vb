<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uc_tb_SiNoIndiferente


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
        CType(Me.RGruop.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RGruop
        '
        Me.RGruop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RGruop.Location = New System.Drawing.Point(0, 0)
        Me.RGruop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RGruop.Name = "RGruop"
        Me.RGruop.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.RGruop.Properties.Appearance.Options.UseBackColor = True
        Me.RGruop.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.RGruop.Properties.Columns = 3
        Me.RGruop.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Sí"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "No"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Opc")})
        Me.RGruop.Size = New System.Drawing.Size(153, 21)
        Me.RGruop.TabIndex = 213
        '
        'uc_tb_SiNoIndiferente
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.RGruop)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "uc_tb_SiNoIndiferente"
        Me.Size = New System.Drawing.Size(153, 21)
        CType(Me.RGruop.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RGruop As DevExpress.XtraEditors.RadioGroup


End Class

