<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDatosBaseDeDatos
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
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
        Me.PanelBotones = New DevExpress.XtraEditors.PanelControl()
        Me.btnSalir = New uc_tb_SimpleButton()
        Me.btnAceptar = New uc_tb_SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl25 = New DevExpress.XtraEditors.LabelControl()
        Me.txtServidor = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl22 = New DevExpress.XtraEditors.LabelControl()
        Me.txtPass = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl()
        Me.txtUsuario = New DevExpress.XtraEditors.TextEdit()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBotones.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.txtServidor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsuario.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelBotones
        '
        Me.PanelBotones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelBotones.Controls.Add(Me.btnSalir)
        Me.PanelBotones.Controls.Add(Me.btnAceptar)
        Me.PanelBotones.Location = New System.Drawing.Point(11, 185)
        Me.PanelBotones.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PanelBotones.Name = "PanelBotones"
        Me.PanelBotones.Size = New System.Drawing.Size(202, 61)
        Me.PanelBotones.TabIndex = 1
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Appearance.Options.UseBackColor = True
        Me.btnSalir.Appearance.Options.UseTextOptions = True
        Me.btnSalir.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnSalir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Image = Global.My.Resources.Resources.desconexion_de_salida_icono_7025_641
        Me.btnSalir.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnSalir.Location = New System.Drawing.Point(107, 3)
        Me.btnSalir.LookAndFeel.SkinName = "Metropolis"
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(90, 53)
        Me.btnSalir.TabIndex = 1
        Me.btnSalir.Text = "Salir"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnAceptar.Appearance.Options.UseBackColor = True
        Me.btnAceptar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAceptar.Image = Global.My.Resources.Resources.check1
        Me.btnAceptar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnAceptar.Location = New System.Drawing.Point(12, 4)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(90, 53)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "Aceptar"
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelControl1.Controls.Add(Me.LabelControl25)
        Me.PanelControl1.Controls.Add(Me.txtServidor)
        Me.PanelControl1.Controls.Add(Me.LabelControl22)
        Me.PanelControl1.Controls.Add(Me.txtPass)
        Me.PanelControl1.Controls.Add(Me.LabelControl21)
        Me.PanelControl1.Controls.Add(Me.txtUsuario)
        Me.PanelControl1.Location = New System.Drawing.Point(11, 12)
        Me.PanelControl1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(202, 167)
        Me.PanelControl1.TabIndex = 0
        '
        'LabelControl25
        '
        Me.LabelControl25.Location = New System.Drawing.Point(24, 111)
        Me.LabelControl25.Name = "LabelControl25"
        Me.LabelControl25.Size = New System.Drawing.Size(60, 13)
        Me.LabelControl25.TabIndex = 203
        Me.LabelControl25.Text = "Contraseña:"
        '
        'txtServidor
        '
        Me.txtServidor.EnterMoveNextControl = True
        Me.txtServidor.Location = New System.Drawing.Point(24, 24)
        Me.txtServidor.Name = "txtServidor"
        Me.txtServidor.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtServidor.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtServidor.Size = New System.Drawing.Size(160, 20)
        Me.txtServidor.TabIndex = 0
        '
        'LabelControl22
        '
        Me.LabelControl22.Location = New System.Drawing.Point(24, 55)
        Me.LabelControl22.Name = "LabelControl22"
        Me.LabelControl22.Size = New System.Drawing.Size(40, 13)
        Me.LabelControl22.TabIndex = 202
        Me.LabelControl22.Text = "Usuario:"
        '
        'txtPass
        '
        Me.txtPass.EnterMoveNextControl = True
        Me.txtPass.Location = New System.Drawing.Point(24, 131)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtPass.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtPass.Size = New System.Drawing.Size(160, 20)
        Me.txtPass.TabIndex = 2
        '
        'LabelControl21
        '
        Me.LabelControl21.Location = New System.Drawing.Point(24, 5)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(44, 13)
        Me.LabelControl21.TabIndex = 201
        Me.LabelControl21.Text = "Servidor:"
        '
        'txtUsuario
        '
        Me.txtUsuario.EnterMoveNextControl = True
        Me.txtUsuario.Location = New System.Drawing.Point(24, 75)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtUsuario.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtUsuario.Size = New System.Drawing.Size(160, 20)
        Me.txtUsuario.TabIndex = 1
        '
        'frmDatosBaseDeDatos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(223, 258)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PanelBotones)
        Me.Name = "frmDatosBaseDeDatos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Datos Base De Datos"
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBotones.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.txtServidor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsuario.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelBotones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnSalir As uc_tb_SimpleButton
    Friend WithEvents btnAceptar As uc_tb_SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl25 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtServidor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl22 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPass As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtUsuario As DevExpress.XtraEditors.TextEdit
End Class
