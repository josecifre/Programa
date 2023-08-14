<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucGestionDocumental
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
        Me.btnAnadirDocumento = New uc_tb_SimpleButton()
        Me.btnVerDocumento = New uc_tb_SimpleButton()
        Me.PanelGestionDocumental = New DevExpress.XtraEditors.GroupControl()
        CType(Me.PanelGestionDocumental, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelGestionDocumental.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAnadirDocumento
        '
        Me.btnAnadirDocumento.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnAnadirDocumento.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnAnadirDocumento.Appearance.Options.UseBackColor = True
        Me.btnAnadirDocumento.Appearance.Options.UseForeColor = True
        Me.btnAnadirDocumento.Appearance.Options.UseTextOptions = True
        Me.btnAnadirDocumento.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.btnAnadirDocumento.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.btnAnadirDocumento.Location = New System.Drawing.Point(5, 28)
        Me.btnAnadirDocumento.LookAndFeel.SkinName = "Metropolis"
        Me.btnAnadirDocumento.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.btnAnadirDocumento.Name = "btnAnadirDocumento"
        Me.btnAnadirDocumento.Size = New System.Drawing.Size(135, 44)
        Me.btnAnadirDocumento.TabIndex = 120
        Me.btnAnadirDocumento.Text = "Añadir Documento"
        '
        'btnVerDocumento
        '
        Me.btnVerDocumento.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnVerDocumento.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnVerDocumento.Appearance.Options.UseBackColor = True
        Me.btnVerDocumento.Appearance.Options.UseForeColor = True
        Me.btnVerDocumento.Appearance.Options.UseTextOptions = True
        Me.btnVerDocumento.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.btnVerDocumento.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.btnVerDocumento.Location = New System.Drawing.Point(144, 28)
        Me.btnVerDocumento.LookAndFeel.SkinName = "Metropolis"
        Me.btnVerDocumento.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.btnVerDocumento.Name = "btnVerDocumento"
        Me.btnVerDocumento.Size = New System.Drawing.Size(141, 44)
        Me.btnVerDocumento.TabIndex = 121
        Me.btnVerDocumento.Text = "Ver Documentos"
        '
        'PanelGestionDocumental
        '
        Me.PanelGestionDocumental.Controls.Add(Me.btnVerDocumento)
        Me.PanelGestionDocumental.Controls.Add(Me.btnAnadirDocumento)
        Me.PanelGestionDocumental.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelGestionDocumental.Location = New System.Drawing.Point(0, 0)
        Me.PanelGestionDocumental.Name = "PanelGestionDocumental"
        Me.PanelGestionDocumental.Size = New System.Drawing.Size(289, 86)
        Me.PanelGestionDocumental.TabIndex = 122
        Me.PanelGestionDocumental.Text = "GroupControl1"
        '
        'ucGestionDocumental
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelGestionDocumental)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "ucGestionDocumental"
        Me.Size = New System.Drawing.Size(289, 86)
        CType(Me.PanelGestionDocumental, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelGestionDocumental.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAnadirDocumento As uc_tb_SimpleButton
    Friend WithEvents btnVerDocumento As uc_tb_SimpleButton
    Friend WithEvents PanelGestionDocumental As DevExpress.XtraEditors.GroupControl

End Class
