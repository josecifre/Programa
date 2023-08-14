<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRed
    ' Inherits DevExpress.XtraEditors.XtraForm
    Inherits DevExpress.XtraWaitForm.WaitForm

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
        Me.grBotones = New DevExpress.XtraEditors.GroupControl()
        Me.btnCancelar = New uc_tb_SimpleButton()
        Me.btnAceptar = New uc_tb_SimpleButton()
        Me.gr1 = New DevExpress.XtraEditors.GroupControl()
        Me.btnRuta = New uc_tb_SimpleButton()
        Me.rbCliente = New System.Windows.Forms.RadioButton()
        Me.rbServidor = New System.Windows.Forms.RadioButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtRuta = New DevExpress.XtraEditors.TextEdit()
        Me.lbl2 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.grBotones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grBotones.SuspendLayout()
        CType(Me.gr1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gr1.SuspendLayout()
        CType(Me.txtRuta.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grBotones
        '
        Me.grBotones.Appearance.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.grBotones.Appearance.Options.UseBackColor = True
        Me.grBotones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.grBotones.Controls.Add(Me.btnCancelar)
        Me.grBotones.Controls.Add(Me.btnAceptar)
        Me.grBotones.Location = New System.Drawing.Point(3, 303)
        Me.grBotones.Name = "grBotones"
        Me.grBotones.ShowCaption = False
        Me.grBotones.Size = New System.Drawing.Size(296, 120)
        Me.grBotones.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancelar.Appearance.Options.UseFont = True
        Me.btnCancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnCancelar.Image = Global.My.Resources.Resources.cancel
        Me.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnCancelar.Location = New System.Drawing.Point(154, 17)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(115, 82)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "CANCELAR"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnAceptar.Appearance.Options.UseFont = True
        Me.btnAceptar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnAceptar.Image = Global.My.Resources.Resources.check
        Me.btnAceptar.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnAceptar.Location = New System.Drawing.Point(33, 17)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(115, 82)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "ACEPTAR"
        '
        'gr1
        '
        Me.gr1.Appearance.BorderColor = System.Drawing.Color.Transparent
        Me.gr1.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.gr1.Appearance.Options.UseBorderColor = True
        Me.gr1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.gr1.Controls.Add(Me.btnRuta)
        Me.gr1.Controls.Add(Me.rbCliente)
        Me.gr1.Controls.Add(Me.rbServidor)
        Me.gr1.Controls.Add(Me.LabelControl2)
        Me.gr1.Controls.Add(Me.txtRuta)
        Me.gr1.Controls.Add(Me.lbl2)
        Me.gr1.Location = New System.Drawing.Point(3, 2)
        Me.gr1.Name = "gr1"
        Me.gr1.ShowCaption = False
        Me.gr1.Size = New System.Drawing.Size(296, 312)
        Me.gr1.TabIndex = 0
        '
        'btnRuta
        '
        Me.btnRuta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRuta.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnRuta.Appearance.Options.UseFont = True
        Me.btnRuta.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnRuta.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnRuta.Location = New System.Drawing.Point(173, 213)
        Me.btnRuta.Name = "btnRuta"
        Me.btnRuta.Size = New System.Drawing.Size(105, 22)
        Me.btnRuta.TabIndex = 185
        Me.btnRuta.Text = "Ruta ..."
        '
        'rbCliente
        '
        Me.rbCliente.AutoSize = True
        Me.rbCliente.Font = New System.Drawing.Font("Tahoma", 13.0!)
        Me.rbCliente.ForeColor = System.Drawing.Color.SteelBlue
        Me.rbCliente.Location = New System.Drawing.Point(18, 116)
        Me.rbCliente.Name = "rbCliente"
        Me.rbCliente.Size = New System.Drawing.Size(81, 26)
        Me.rbCliente.TabIndex = 2
        Me.rbCliente.TabStop = True
        Me.rbCliente.Text = "Cliente"
        Me.rbCliente.UseVisualStyleBackColor = True
        '
        'rbServidor
        '
        Me.rbServidor.AutoSize = True
        Me.rbServidor.BackColor = System.Drawing.Color.White
        Me.rbServidor.Font = New System.Drawing.Font("Tahoma", 13.0!)
        Me.rbServidor.ForeColor = System.Drawing.Color.SteelBlue
        Me.rbServidor.Location = New System.Drawing.Point(18, 73)
        Me.rbServidor.Name = "rbServidor"
        Me.rbServidor.Size = New System.Drawing.Size(92, 26)
        Me.rbServidor.TabIndex = 1
        Me.rbServidor.TabStop = True
        Me.rbServidor.Text = "Servidor"
        Me.rbServidor.UseVisualStyleBackColor = False
        '
        'LabelControl2
        '
        Me.LabelControl2.AllowHtmlString = True
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.LabelControl2.Location = New System.Drawing.Point(60, 20)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(174, 19)
        Me.LabelControl2.TabIndex = 183
        Me.LabelControl2.Text = "Configuración de Red"
        '
        'txtRuta
        '
        Me.txtRuta.EditValue = ""
        Me.txtRuta.EnterMoveNextControl = True
        Me.txtRuta.Location = New System.Drawing.Point(15, 213)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.txtRuta.Properties.Appearance.Options.UseFont = True
        Me.txtRuta.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtRuta.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtRuta.Size = New System.Drawing.Size(152, 22)
        Me.txtRuta.TabIndex = 3
        '
        'lbl2
        '
        Me.lbl2.AllowHtmlString = True
        Me.lbl2.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.lbl2.Location = New System.Drawing.Point(15, 177)
        Me.lbl2.Name = "lbl2"
        Me.lbl2.Size = New System.Drawing.Size(39, 19)
        Me.lbl2.TabIndex = 181
        Me.lbl2.Text = "Ruta"
        '
        'frmRed
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(302, 426)
        Me.Controls.Add(Me.grBotones)
        Me.Controls.Add(Me.gr1)
        Me.Name = "frmRed"
        Me.ShowInTaskbar = True
        CType(Me.grBotones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grBotones.ResumeLayout(False)
        CType(Me.gr1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gr1.ResumeLayout(False)
        Me.gr1.PerformLayout()
        CType(Me.txtRuta.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grBotones As DevExpress.XtraEditors.GroupControl
    Friend WithEvents gr1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents txtRuta As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnCancelar As uc_tb_SimpleButton
    Friend WithEvents btnAceptar As uc_tb_SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents rbCliente As System.Windows.Forms.RadioButton
    Friend WithEvents rbServidor As System.Windows.Forms.RadioButton
    Friend WithEvents btnRuta As uc_tb_SimpleButton
End Class