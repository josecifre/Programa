<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDuplicarInmueble
    Inherits DevExpress.XtraEditors.XtraForm

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
        Me.PanelBotones = New DevExpress.XtraEditors.PanelControl()
        Me.btnAceptar = New uc_tb_SimpleButton()
        Me.btnCancelar = New uc_tb_SimpleButton()
        Me.pnlPreciosPropietarios = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.spnPP = New DevExpress.XtraEditors.SpinEdit()
        Me.pnlPreciosPublico = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.spnPVP = New DevExpress.XtraEditors.SpinEdit()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBotones.SuspendLayout()
        CType(Me.pnlPreciosPropietarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPreciosPropietarios.SuspendLayout()
        CType(Me.spnPP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlPreciosPublico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPreciosPublico.SuspendLayout()
        CType(Me.spnPVP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelBotones
        '
        Me.PanelBotones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelBotones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelBotones.Controls.Add(Me.btnAceptar)
        Me.PanelBotones.Controls.Add(Me.btnCancelar)
        Me.PanelBotones.Location = New System.Drawing.Point(0, 102)
        Me.PanelBotones.Name = "PanelBotones"
        Me.PanelBotones.Size = New System.Drawing.Size(240, 65)
        Me.PanelBotones.TabIndex = 126
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Appearance.Options.UseBackColor = True
        Me.btnAceptar.Appearance.Options.UseTextOptions = True
        Me.btnAceptar.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnAceptar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnAceptar.Image = Global.My.Resources.Resources.check1
        Me.btnAceptar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnAceptar.Location = New System.Drawing.Point(101, 5)
        Me.btnAceptar.LookAndFeel.SkinName = "Metropolis"
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(63, 55)
        Me.btnAceptar.TabIndex = 14
        Me.btnAceptar.Text = "Aceptar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Appearance.Options.UseBackColor = True
        Me.btnCancelar.Appearance.Options.UseTextOptions = True
        Me.btnCancelar.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnCancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnCancelar.Image = Global.My.Resources.Resources.cancel1
        Me.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnCancelar.Location = New System.Drawing.Point(167, 5)
        Me.btnCancelar.LookAndFeel.SkinName = "Metropolis"
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(68, 55)
        Me.btnCancelar.TabIndex = 15
        Me.btnCancelar.Text = "Cancelar"
        '
        'pnlPreciosPropietarios
        '
        Me.pnlPreciosPropietarios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPreciosPropietarios.Controls.Add(Me.LabelControl13)
        Me.pnlPreciosPropietarios.Controls.Add(Me.spnPP)
        Me.pnlPreciosPropietarios.Location = New System.Drawing.Point(4, 52)
        Me.pnlPreciosPropietarios.Name = "pnlPreciosPropietarios"
        Me.pnlPreciosPropietarios.Size = New System.Drawing.Size(232, 46)
        Me.pnlPreciosPropietarios.TabIndex = 247
        '
        'LabelControl13
        '
        Me.LabelControl13.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.LabelControl13.Location = New System.Drawing.Point(9, 17)
        Me.LabelControl13.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(84, 13)
        Me.LabelControl13.TabIndex = 248
        Me.LabelControl13.Text = "Precio Propietario"
        '
        'spnPP
        '
        Me.spnPP.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.spnPP.EnterMoveNextControl = True
        Me.spnPP.Location = New System.Drawing.Point(119, 14)
        Me.spnPP.Name = "spnPP"
        Me.spnPP.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.spnPP.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.spnPP.Properties.DisplayFormat.FormatString = "n0"
        Me.spnPP.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.spnPP.Properties.EditFormat.FormatString = "n0"
        Me.spnPP.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.spnPP.Properties.Mask.EditMask = "n0"
        Me.spnPP.Properties.NullText = "0"
        Me.spnPP.Size = New System.Drawing.Size(104, 20)
        Me.spnPP.TabIndex = 0
        '
        'pnlPreciosPublico
        '
        Me.pnlPreciosPublico.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPreciosPublico.Controls.Add(Me.LabelControl4)
        Me.pnlPreciosPublico.Controls.Add(Me.spnPVP)
        Me.pnlPreciosPublico.Location = New System.Drawing.Point(4, 3)
        Me.pnlPreciosPublico.Name = "pnlPreciosPublico"
        Me.pnlPreciosPublico.Size = New System.Drawing.Size(232, 46)
        Me.pnlPreciosPublico.TabIndex = 246
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.LabelControl4.Location = New System.Drawing.Point(8, 17)
        Me.LabelControl4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl4.TabIndex = 244
        Me.LabelControl4.Text = "Precio Público"
        '
        'spnPVP
        '
        Me.spnPVP.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.spnPVP.EnterMoveNextControl = True
        Me.spnPVP.Location = New System.Drawing.Point(119, 14)
        Me.spnPVP.Name = "spnPVP"
        Me.spnPVP.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.spnPVP.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.spnPVP.Properties.DisplayFormat.FormatString = "n0"
        Me.spnPVP.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.spnPVP.Properties.EditFormat.FormatString = "n0"
        Me.spnPVP.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.spnPVP.Properties.Mask.EditMask = "n0"
        Me.spnPVP.Properties.NullText = "0"
        Me.spnPVP.Size = New System.Drawing.Size(104, 20)
        Me.spnPVP.TabIndex = 1
        '
        'ucDuplicarInmueble
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(240, 167)
        Me.Controls.Add(Me.pnlPreciosPropietarios)
        Me.Controls.Add(Me.pnlPreciosPublico)
        Me.Controls.Add(Me.PanelBotones)
        Me.Name = "ucDuplicarInmueble"
        Me.Text = "Duplicar inmueble"
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBotones.ResumeLayout(False)
        CType(Me.pnlPreciosPropietarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPreciosPropietarios.ResumeLayout(False)
        Me.pnlPreciosPropietarios.PerformLayout()
        CType(Me.spnPP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlPreciosPublico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPreciosPublico.ResumeLayout(False)
        Me.pnlPreciosPublico.PerformLayout()
        CType(Me.spnPVP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelBotones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnAceptar As uc_tb_SimpleButton
    Friend WithEvents btnCancelar As uc_tb_SimpleButton
    Friend WithEvents pnlPreciosPropietarios As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents spnPP As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents pnlPreciosPublico As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents spnPVP As DevExpress.XtraEditors.SpinEdit
End Class
