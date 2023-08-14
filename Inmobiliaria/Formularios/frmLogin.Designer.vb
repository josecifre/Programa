<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Me.btnRed = New uc_tb_SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txt2 = New DevExpress.XtraEditors.TextEdit()
        Me.lbl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txt1 = New DevExpress.XtraEditors.TextEdit()
        Me.lbl1 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.grBotones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grBotones.SuspendLayout()
        CType(Me.gr1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gr1.SuspendLayout()
        CType(Me.txt2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grBotones
        '
        Me.grBotones.Appearance.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.grBotones.Appearance.Options.UseBackColor = True
        Me.grBotones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.grBotones.Controls.Add(Me.btnCancelar)
        Me.grBotones.Controls.Add(Me.btnAceptar)
        Me.grBotones.Location = New System.Drawing.Point(3, 304)
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
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.Image = Global.My.Resources.Resources.cancel
        Me.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnCancelar.Location = New System.Drawing.Point(160, 12)
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
        Me.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAceptar.Image = Global.My.Resources.Resources.check
        Me.btnAceptar.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnAceptar.Location = New System.Drawing.Point(22, 12)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(115, 82)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "ACEPTAR"
        '
        'gr1
        '
        Me.gr1.Appearance.BackColor = System.Drawing.Color.LightBlue
        Me.gr1.Appearance.BackColor2 = System.Drawing.SystemColors.ActiveCaption
        Me.gr1.Appearance.BorderColor = System.Drawing.Color.Transparent
        Me.gr1.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.gr1.Appearance.Options.UseBackColor = True
        Me.gr1.Appearance.Options.UseBorderColor = True
        Me.gr1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.gr1.Controls.Add(Me.btnRed)
        Me.gr1.Controls.Add(Me.LabelControl2)
        Me.gr1.Controls.Add(Me.LabelControl1)
        Me.gr1.Controls.Add(Me.txt2)
        Me.gr1.Controls.Add(Me.lbl2)
        Me.gr1.Controls.Add(Me.txt1)
        Me.gr1.Controls.Add(Me.lbl1)
        Me.gr1.Location = New System.Drawing.Point(3, 2)
        Me.gr1.Name = "gr1"
        Me.gr1.ShowCaption = False
        Me.gr1.Size = New System.Drawing.Size(296, 312)
        Me.gr1.TabIndex = 0
        '
        'btnRed
        '
        Me.btnRed.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRed.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnRed.Appearance.Options.UseFont = True
        Me.btnRed.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnRed.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRed.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnRed.Location = New System.Drawing.Point(169, 52)
        Me.btnRed.Name = "btnRed"
        Me.btnRed.Size = New System.Drawing.Size(109, 27)
        Me.btnRed.TabIndex = 184
        Me.btnRed.Text = "Configurar Red"
        '
        'LabelControl2
        '
        Me.LabelControl2.AllowHtmlString = True
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.LabelControl2.Location = New System.Drawing.Point(77, 12)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(144, 25)
        Me.LabelControl2.TabIndex = 183
        Me.LabelControl2.Text = "Identificación"
        '
        'LabelControl1
        '
        Me.LabelControl1.AllowHtmlString = True
        Me.LabelControl1.Location = New System.Drawing.Point(146, 252)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(132, 13)
        Me.LabelControl1.TabIndex = 182
        Me.LabelControl1.Text = "<color=Red><b>* Mayúsculas Activada </b></Color>"
        Me.LabelControl1.ToolTip = "Se ha desactivado el bloqueo de  mayúsculas, se activará al salir de esta pantall" & _
    "a."
        Me.LabelControl1.Visible = False
        '
        'txt2
        '
        Me.txt2.EditValue = "a"
        Me.txt2.EnterMoveNextControl = True
        Me.txt2.Location = New System.Drawing.Point(25, 204)
        Me.txt2.Name = "txt2"
        Me.txt2.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!)
        Me.txt2.Properties.Appearance.Options.UseFont = True
        Me.txt2.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txt2.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txt2.Size = New System.Drawing.Size(253, 36)
        Me.txt2.TabIndex = 180
        '
        'lbl2
        '
        Me.lbl2.AllowHtmlString = True
        Me.lbl2.Appearance.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.lbl2.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.lbl2.Location = New System.Drawing.Point(24, 170)
        Me.lbl2.Name = "lbl2"
        Me.lbl2.Size = New System.Drawing.Size(62, 25)
        Me.lbl2.TabIndex = 181
        Me.lbl2.Text = "Texto2"
        '
        'txt1
        '
        Me.txt1.EnterMoveNextControl = True
        Me.txt1.Location = New System.Drawing.Point(25, 122)
        Me.txt1.Name = "txt1"
        Me.txt1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!)
        Me.txt1.Properties.Appearance.Options.UseFont = True
        Me.txt1.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txt1.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txt1.Size = New System.Drawing.Size(253, 36)
        Me.txt1.TabIndex = 178
        '
        'lbl1
        '
        Me.lbl1.AllowHtmlString = True
        Me.lbl1.Appearance.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.lbl1.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.lbl1.Location = New System.Drawing.Point(24, 88)
        Me.lbl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(62, 25)
        Me.lbl1.TabIndex = 179
        Me.lbl1.Text = "Texto1"
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(302, 426)
        Me.Controls.Add(Me.grBotones)
        Me.Controls.Add(Me.gr1)
        Me.Name = "frmLogin"
        Me.ShowInTaskbar = True
        CType(Me.grBotones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grBotones.ResumeLayout(False)
        CType(Me.gr1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gr1.ResumeLayout(False)
        Me.gr1.PerformLayout()
        CType(Me.txt2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grBotones As DevExpress.XtraEditors.GroupControl
    Friend WithEvents gr1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents txt1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnCancelar As uc_tb_SimpleButton
    Friend WithEvents btnAceptar As uc_tb_SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnRed As uc_tb_SimpleButton
End Class