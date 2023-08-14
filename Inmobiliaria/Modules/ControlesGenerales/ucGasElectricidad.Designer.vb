

Namespace Venalia.ControlesTB

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ucGasElectricidad
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
            Me.lblTitulo = New DevExpress.XtraEditors.LabelControl()
            CType(Me.RGruop.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RGruop
            '
            Me.RGruop.Location = New System.Drawing.Point(0, -2)
            Me.RGruop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.RGruop.Name = "RGruop"
            Me.RGruop.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.RGruop.Properties.Appearance.Options.UseBackColor = True
            Me.RGruop.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.RGruop.Properties.Columns = 3
            Me.RGruop.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Gas"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Elect."), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "NS")})
            Me.RGruop.Size = New System.Drawing.Size(230, 20)
            Me.RGruop.TabIndex = 213
            '
            'lblTitulo
            '
            Me.lblTitulo.Location = New System.Drawing.Point(0, 2)
            Me.lblTitulo.Name = "lblTitulo"
            Me.lblTitulo.Size = New System.Drawing.Size(33, 13)
            Me.lblTitulo.TabIndex = 215
            Me.lblTitulo.Text = "Estado"
            Me.lblTitulo.Visible = False
            '
            'ucGasElectricidad
            '
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
            Me.Controls.Add(Me.lblTitulo)
            Me.Controls.Add(Me.RGruop)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.Name = "ucGasElectricidad"
            Me.Size = New System.Drawing.Size(230, 18)
            CType(Me.RGruop.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents RGruop As DevExpress.XtraEditors.RadioGroup
        Friend WithEvents lblTitulo As DevExpress.XtraEditors.LabelControl

    End Class
End Namespace

