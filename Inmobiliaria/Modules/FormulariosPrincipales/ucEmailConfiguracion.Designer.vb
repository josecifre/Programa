<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucEmailConfiguracion
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
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl26 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl25 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.txtPass = New DevExpress.XtraEditors.TextEdit()
        Me.txtPOP3 = New DevExpress.XtraEditors.TextEdit()
        Me.txtSMTP = New DevExpress.XtraEditors.TextEdit()
        Me.txtUsuario = New DevExpress.XtraEditors.TextEdit()
        Me.txtNombreAMostrar = New DevExpress.XtraEditors.TextEdit()
        Me.txtEmail = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.spnPuertoPOP3 = New DevExpress.XtraEditors.SpinEdit()
        Me.spnPuertoSMTP = New DevExpress.XtraEditors.SpinEdit()
        Me.chkSSL = New DevExpress.XtraEditors.CheckEdit()
        Me.grEmailDocumentos = New DevExpress.XtraEditors.GroupControl()
        Me.PanelBotones = New DevExpress.XtraEditors.PanelControl()
        Me.btnSalir = New uc_tb_SimpleButton()
        Me.btnAceptar = New uc_tb_SimpleButton()
        CType(Me.txtPass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPOP3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSMTP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsuario.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombreAMostrar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spnPuertoPOP3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spnPuertoSMTP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSSL.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grEmailDocumentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grEmailDocumentos.SuspendLayout()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(269, 168)
        Me.LabelControl3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(114, 13)
        Me.LabelControl3.TabIndex = 195
        Me.LabelControl3.Text = "Servidor Entrante POP3"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(15, 168)
        Me.LabelControl2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(109, 13)
        Me.LabelControl2.TabIndex = 194
        Me.LabelControl2.Text = "Servidor saliente SMTP"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(269, 99)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(56, 13)
        Me.LabelControl1.TabIndex = 193
        Me.LabelControl1.Text = "Contraseña"
        '
        'LabelControl26
        '
        Me.LabelControl26.Location = New System.Drawing.Point(15, 99)
        Me.LabelControl26.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl26.Name = "LabelControl26"
        Me.LabelControl26.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl26.TabIndex = 192
        Me.LabelControl26.Text = "Usuario"
        '
        'LabelControl25
        '
        Me.LabelControl25.Location = New System.Drawing.Point(18, 38)
        Me.LabelControl25.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl25.Name = "LabelControl25"
        Me.LabelControl25.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl25.TabIndex = 191
        Me.LabelControl25.Text = "Email"
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(269, 38)
        Me.LabelControl12.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(86, 13)
        Me.LabelControl12.TabIndex = 178
        Me.LabelControl12.Text = "Nombre a Mostrar"
        '
        'txtPass
        '
        Me.txtPass.EnterMoveNextControl = True
        Me.txtPass.Location = New System.Drawing.Point(269, 123)
        Me.txtPass.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtPass.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtPass.Size = New System.Drawing.Size(92, 20)
        Me.txtPass.TabIndex = 4
        '
        'txtPOP3
        '
        Me.txtPOP3.EditValue = ""
        Me.txtPOP3.Location = New System.Drawing.Point(269, 191)
        Me.txtPOP3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPOP3.Name = "txtPOP3"
        Me.txtPOP3.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtPOP3.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtPOP3.Size = New System.Drawing.Size(323, 20)
        Me.txtPOP3.TabIndex = 9
        '
        'txtSMTP
        '
        Me.txtSMTP.Location = New System.Drawing.Point(15, 191)
        Me.txtSMTP.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtSMTP.Name = "txtSMTP"
        Me.txtSMTP.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtSMTP.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtSMTP.Size = New System.Drawing.Size(238, 20)
        Me.txtSMTP.TabIndex = 8
        '
        'txtUsuario
        '
        Me.txtUsuario.EnterMoveNextControl = True
        Me.txtUsuario.Location = New System.Drawing.Point(15, 123)
        Me.txtUsuario.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtUsuario.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtUsuario.Size = New System.Drawing.Size(238, 20)
        Me.txtUsuario.TabIndex = 3
        '
        'txtNombreAMostrar
        '
        Me.txtNombreAMostrar.EnterMoveNextControl = True
        Me.txtNombreAMostrar.Location = New System.Drawing.Point(269, 60)
        Me.txtNombreAMostrar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNombreAMostrar.Name = "txtNombreAMostrar"
        Me.txtNombreAMostrar.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNombreAMostrar.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtNombreAMostrar.Size = New System.Drawing.Size(323, 20)
        Me.txtNombreAMostrar.TabIndex = 2
        '
        'txtEmail
        '
        Me.txtEmail.EnterMoveNextControl = True
        Me.txtEmail.Location = New System.Drawing.Point(15, 60)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtEmail.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtEmail.Size = New System.Drawing.Size(238, 20)
        Me.txtEmail.TabIndex = 1
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(468, 99)
        Me.LabelControl6.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl6.TabIndex = 202
        Me.LabelControl6.Text = "Puerto POP3"
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(373, 99)
        Me.LabelControl7.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl7.TabIndex = 201
        Me.LabelControl7.Text = "Puerto SMTP"
        '
        'spnPuertoPOP3
        '
        Me.spnPuertoPOP3.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.spnPuertoPOP3.EnterMoveNextControl = True
        Me.spnPuertoPOP3.Location = New System.Drawing.Point(468, 123)
        Me.spnPuertoPOP3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.spnPuertoPOP3.Name = "spnPuertoPOP3"
        Me.spnPuertoPOP3.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.spnPuertoPOP3.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.spnPuertoPOP3.Properties.NullText = "0"
        Me.spnPuertoPOP3.Size = New System.Drawing.Size(87, 20)
        Me.spnPuertoPOP3.TabIndex = 6
        '
        'spnPuertoSMTP
        '
        Me.spnPuertoSMTP.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.spnPuertoSMTP.EnterMoveNextControl = True
        Me.spnPuertoSMTP.Location = New System.Drawing.Point(372, 123)
        Me.spnPuertoSMTP.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.spnPuertoSMTP.Name = "spnPuertoSMTP"
        Me.spnPuertoSMTP.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.spnPuertoSMTP.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.spnPuertoSMTP.Properties.NullText = "0"
        Me.spnPuertoSMTP.Size = New System.Drawing.Size(87, 20)
        Me.spnPuertoSMTP.TabIndex = 5
        '
        'chkSSL
        '
        Me.chkSSL.Location = New System.Drawing.Point(561, 124)
        Me.chkSSL.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkSSL.Name = "chkSSL"
        Me.chkSSL.Properties.Caption = "SSL"
        Me.chkSSL.Size = New System.Drawing.Size(52, 19)
        ToolTipItem1.Text = "Aplicar Recargo de Equivalencia"
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.chkSSL.SuperTip = SuperToolTip1
        Me.chkSSL.TabIndex = 7
        '
        'grEmailDocumentos
        '
        Me.grEmailDocumentos.Controls.Add(Me.LabelControl6)
        Me.grEmailDocumentos.Controls.Add(Me.txtEmail)
        Me.grEmailDocumentos.Controls.Add(Me.LabelControl7)
        Me.grEmailDocumentos.Controls.Add(Me.txtNombreAMostrar)
        Me.grEmailDocumentos.Controls.Add(Me.spnPuertoPOP3)
        Me.grEmailDocumentos.Controls.Add(Me.txtUsuario)
        Me.grEmailDocumentos.Controls.Add(Me.spnPuertoSMTP)
        Me.grEmailDocumentos.Controls.Add(Me.txtSMTP)
        Me.grEmailDocumentos.Controls.Add(Me.chkSSL)
        Me.grEmailDocumentos.Controls.Add(Me.txtPOP3)
        Me.grEmailDocumentos.Controls.Add(Me.LabelControl3)
        Me.grEmailDocumentos.Controls.Add(Me.txtPass)
        Me.grEmailDocumentos.Controls.Add(Me.LabelControl2)
        Me.grEmailDocumentos.Controls.Add(Me.LabelControl12)
        Me.grEmailDocumentos.Controls.Add(Me.LabelControl1)
        Me.grEmailDocumentos.Controls.Add(Me.LabelControl25)
        Me.grEmailDocumentos.Controls.Add(Me.LabelControl26)
        Me.grEmailDocumentos.Dock = System.Windows.Forms.DockStyle.Top
        Me.grEmailDocumentos.Location = New System.Drawing.Point(0, 0)
        Me.grEmailDocumentos.Name = "grEmailDocumentos"
        Me.grEmailDocumentos.Size = New System.Drawing.Size(610, 250)
        Me.grEmailDocumentos.TabIndex = 2
        Me.grEmailDocumentos.Text = "Configuración Correo Envío Documentos"
        '
        'PanelBotones
        '
        Me.PanelBotones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelBotones.Controls.Add(Me.btnSalir)
        Me.PanelBotones.Controls.Add(Me.btnAceptar)
        Me.PanelBotones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBotones.Location = New System.Drawing.Point(0, 239)
        Me.PanelBotones.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PanelBotones.Name = "PanelBotones"
        Me.PanelBotones.Size = New System.Drawing.Size(610, 82)
        Me.PanelBotones.TabIndex = 18
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Appearance.Options.UseBackColor = True
        Me.btnSalir.Appearance.Options.UseTextOptions = True
        Me.btnSalir.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnSalir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnSalir.Image = Global.My.Resources.Resources.desconexion_de_salida_icono_7025_641
        Me.btnSalir.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnSalir.Location = New System.Drawing.Point(531, 10)
        Me.btnSalir.LookAndFeel.SkinName = "Metropolis"
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(68, 61)
        Me.btnSalir.TabIndex = 11
        Me.btnSalir.Text = "Salir"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnAceptar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnAceptar.Appearance.Options.UseBackColor = True
        Me.btnAceptar.Appearance.Options.UseForeColor = True
        Me.btnAceptar.Appearance.Options.UseTextOptions = True
        Me.btnAceptar.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnAceptar.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.btnAceptar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnAceptar.Image = Global.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(361, 10)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(164, 61)
        Me.btnAceptar.TabIndex = 10
        Me.btnAceptar.Text = "Guardar Cambios"
        '
        'ucEmailConfiguracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.PanelBotones)
        Me.Controls.Add(Me.grEmailDocumentos)
        Me.Name = "ucEmailConfiguracion"
        Me.Size = New System.Drawing.Size(610, 321)
        CType(Me.txtPass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPOP3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSMTP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsuario.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombreAMostrar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spnPuertoPOP3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spnPuertoSMTP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSSL.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grEmailDocumentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grEmailDocumentos.ResumeLayout(False)
        Me.grEmailDocumentos.PerformLayout()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBotones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl26 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl25 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPass As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPOP3 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSMTP As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtUsuario As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtNombreAMostrar As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtEmail As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents spnPuertoPOP3 As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents spnPuertoSMTP As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents chkSSL As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents grEmailDocumentos As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PanelBotones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnSalir As uc_tb_SimpleButton
    Friend WithEvents btnAceptar As uc_tb_SimpleButton

End Class
