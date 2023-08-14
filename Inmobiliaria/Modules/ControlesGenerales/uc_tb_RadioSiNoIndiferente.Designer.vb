 
Namespace Venalia.ControlesTB

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class uc_tb_RadioSiNoIndiferente
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
            Me.RC = New DevExpress.XtraEditors.GroupControl()
            Me.RGruop = New DevExpress.XtraEditors.RadioGroup()
            CType(Me.RC, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.RC.SuspendLayout()
            CType(Me.RGruop.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RC
            '
            Me.RC.AppearanceCaption.Options.UseTextOptions = True
            Me.RC.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.RC.Controls.Add(Me.RGruop)
            Me.RC.Dock = System.Windows.Forms.DockStyle.Fill
            Me.RC.Location = New System.Drawing.Point(0, 0)
            Me.RC.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.RC.Name = "RC"
            Me.RC.Size = New System.Drawing.Size(122, 43)
            Me.RC.TabIndex = 216
            Me.RC.Text = "Cocina Office"
            Me.RC.UseDisabledStatePainter = False
            '
            'RGruop
            '
            Me.RGruop.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RGruop.Location = New System.Drawing.Point(4, 21)
            Me.RGruop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.RGruop.Name = "RGruop"
            Me.RGruop.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.RGruop.Properties.Columns = 3
            Me.RGruop.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Sí"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "No"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Ind")})
            Me.RGruop.Size = New System.Drawing.Size(114, 18)
            Me.RGruop.TabIndex = 213
            '
            'uc_tb_RadioSiNoIndiferente
            '
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
            Me.Controls.Add(Me.RC)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.Name = "uc_tb_RadioSiNoIndiferente"
            Me.Size = New System.Drawing.Size(122, 43)
            CType(Me.RC, System.ComponentModel.ISupportInitialize).EndInit()
            Me.RC.ResumeLayout(False)
            CType(Me.RGruop.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RC As DevExpress.XtraEditors.GroupControl
        Friend WithEvents RGruop As DevExpress.XtraEditors.RadioGroup

    End Class
End Namespace