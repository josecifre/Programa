<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMensajeEmail
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
        Me.btnSalir = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelBotones = New DevExpress.XtraEditors.PanelControl()
        Me.txtMensaje = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtAsunto = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.btnAdjuntar = New DevExpress.XtraEditors.SimpleButton()
        Me.txtAdjunto = New DevExpress.XtraEditors.LabelControl()
        Me.chkAvisoLegal = New uc_tb_CheckBoxRojoNegro()
        Me.chkInfoEmpresa = New uc_tb_CheckBoxRojoNegro()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBotones.SuspendLayout()
        CType(Me.txtMensaje.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAsunto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAvisoLegal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkInfoEmpresa.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnSalir.Appearance.Options.UseBackColor = True
        Me.btnSalir.Appearance.Options.UseTextOptions = True
        Me.btnSalir.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnSalir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnSalir.Image = Global.My.Resources.Resources.desconexion_de_salida_icono_7025_641
        Me.btnSalir.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnSalir.Location = New System.Drawing.Point(639, 5)
        Me.btnSalir.LookAndFeel.SkinName = "Metropolis"
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(65, 51)
        Me.btnSalir.TabIndex = 1
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.ToolTip = "Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnAceptar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnAceptar.Appearance.Options.UseBackColor = True
        Me.btnAceptar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnAceptar.Image = Global.My.Resources.Resources.EmailBoton
        Me.btnAceptar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnAceptar.Location = New System.Drawing.Point(568, 5)
        Me.btnAceptar.LookAndFeel.SkinName = "Metropolis"
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(65, 51)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.ToolTip = "Aceptar"
        '
        'PanelBotones
        '
        Me.PanelBotones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelBotones.Controls.Add(Me.btnAceptar)
        Me.PanelBotones.Controls.Add(Me.btnSalir)
        Me.PanelBotones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBotones.Location = New System.Drawing.Point(0, 344)
        Me.PanelBotones.Name = "PanelBotones"
        Me.PanelBotones.Size = New System.Drawing.Size(716, 61)
        Me.PanelBotones.TabIndex = 126
        '
        'txtMensaje
        '
        Me.txtMensaje.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMensaje.Location = New System.Drawing.Point(10, 92)
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.Size = New System.Drawing.Size(694, 246)
        Me.txtMensaje.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 18)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl1.TabIndex = 182
        Me.LabelControl1.Text = "Asunto"
        '
        'txtAsunto
        '
        Me.txtAsunto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAsunto.EnterMoveNextControl = True
        Me.txtAsunto.Location = New System.Drawing.Point(10, 37)
        Me.txtAsunto.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAsunto.Name = "txtAsunto"
        Me.txtAsunto.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtAsunto.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtAsunto.Size = New System.Drawing.Size(491, 20)
        Me.txtAsunto.TabIndex = 181
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(10, 74)
        Me.LabelControl2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(40, 13)
        Me.LabelControl2.TabIndex = 183
        Me.LabelControl2.Text = "Mensaje"
        '
        'btnAdjuntar
        '
        Me.btnAdjuntar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdjuntar.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnAdjuntar.Appearance.Options.UseBackColor = True
        Me.btnAdjuntar.Appearance.Options.UseTextOptions = True
        Me.btnAdjuntar.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnAdjuntar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.btnAdjuntar.Image = Global.My.Resources.Resources.Open_16x16
        Me.btnAdjuntar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnAdjuntar.Location = New System.Drawing.Point(511, 57)
        Me.btnAdjuntar.LookAndFeel.SkinName = "Metropolis"
        Me.btnAdjuntar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnAdjuntar.Name = "btnAdjuntar"
        Me.btnAdjuntar.Size = New System.Drawing.Size(19, 17)
        Me.btnAdjuntar.TabIndex = 231
        Me.btnAdjuntar.Text = "Añadir"
        Me.btnAdjuntar.ToolTip = "Pulse F1 para añadir"
        '
        'txtAdjunto
        '
        Me.txtAdjunto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAdjunto.Location = New System.Drawing.Point(533, 61)
        Me.txtAdjunto.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAdjunto.Name = "txtAdjunto"
        Me.txtAdjunto.Size = New System.Drawing.Size(54, 13)
        Me.txtAdjunto.TabIndex = 232
        Me.txtAdjunto.Text = "Adjuntar..."
        '
        'chkAvisoLegal
        '
        Me.chkAvisoLegal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkAvisoLegal.EditValue = True
        Me.chkAvisoLegal.Location = New System.Drawing.Point(509, 33)
        Me.chkAvisoLegal.Name = "chkAvisoLegal"
        Me.chkAvisoLegal.Properties.Appearance.ForeColor = System.Drawing.Color.Red
        Me.chkAvisoLegal.Properties.Appearance.Options.UseForeColor = True
        Me.chkAvisoLegal.Properties.Caption = "Incluir aviso legal"
        Me.chkAvisoLegal.Properties.ReadOnly = True
        Me.chkAvisoLegal.Size = New System.Drawing.Size(195, 19)
        Me.chkAvisoLegal.TabIndex = 233
        Me.chkAvisoLegal.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkAvisoLegal.tbColorSi = System.Drawing.Color.Red
        '
        'chkInfoEmpresa
        '
        Me.chkInfoEmpresa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkInfoEmpresa.EditValue = True
        Me.chkInfoEmpresa.Location = New System.Drawing.Point(509, 12)
        Me.chkInfoEmpresa.Name = "chkInfoEmpresa"
        Me.chkInfoEmpresa.Properties.Appearance.ForeColor = System.Drawing.Color.Red
        Me.chkInfoEmpresa.Properties.Appearance.Options.UseForeColor = True
        Me.chkInfoEmpresa.Properties.Caption = "Incluir información de la empresa"
        Me.chkInfoEmpresa.Properties.ReadOnly = True
        Me.chkInfoEmpresa.Size = New System.Drawing.Size(195, 19)
        Me.chkInfoEmpresa.TabIndex = 185
        Me.chkInfoEmpresa.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkInfoEmpresa.tbColorSi = System.Drawing.Color.Red
        '
        'frmMensajeEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(716, 405)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkAvisoLegal)
        Me.Controls.Add(Me.txtAdjunto)
        Me.Controls.Add(Me.btnAdjuntar)
        Me.Controls.Add(Me.chkInfoEmpresa)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.txtAsunto)
        Me.Controls.Add(Me.txtMensaje)
        Me.Controls.Add(Me.PanelBotones)
        Me.Name = "frmMensajeEmail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Datos de Envio"
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBotones.ResumeLayout(False)
        CType(Me.txtMensaje.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAsunto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAvisoLegal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkInfoEmpresa.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSalir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelBotones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtMensaje As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtAsunto As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkInfoEmpresa As uc_tb_CheckBoxRojoNegro
    Friend WithEvents btnAdjuntar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtAdjunto As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkAvisoLegal As uc_tb_CheckBoxRojoNegro
End Class
