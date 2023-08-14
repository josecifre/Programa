<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFiltroDuplicados
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
        Dim lblNumero As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelBotones = New DevExpress.XtraEditors.PanelControl()
        Me.rOpcionACompra = New System.Windows.Forms.RadioButton()
        Me.rTraspaso = New System.Windows.Forms.RadioButton()
        Me.rVacacional = New System.Windows.Forms.RadioButton()
        Me.rAlquiler = New System.Windows.Forms.RadioButton()
        Me.rVenta = New System.Windows.Forms.RadioButton()
        Me.btnSalir = New uc_tb_SimpleButton()
        Me.btnBuscar = New uc_tb_SimpleButton()
        Me.chkOpcionACompra = New uc_tb_CheckBoxRojoNegro()
        Me.chkTraspaso = New uc_tb_CheckBoxRojoNegro()
        Me.chkVacacional = New uc_tb_CheckBoxRojoNegro()
        Me.chkAlquiler = New uc_tb_CheckBoxRojoNegro()
        Me.chkVenta = New uc_tb_CheckBoxRojoNegro()
        lblNumero = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBotones.SuspendLayout()
        CType(Me.chkOpcionACompra.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkTraspaso.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkVacacional.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAlquiler.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkVenta.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblNumero
        '
        lblNumero.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        lblNumero.AutoSize = True
        lblNumero.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblNumero.Location = New System.Drawing.Point(206, 13)
        lblNumero.Name = "lblNumero"
        lblNumero.Size = New System.Drawing.Size(43, 16)
        lblNumero.TabIndex = 115
        lblNumero.Text = "No es"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label1.Location = New System.Drawing.Point(9, 13)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(26, 16)
        Label1.TabIndex = 116
        Label1.Text = "Es "
        '
        'PanelControl1
        '
        Me.PanelControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelControl1.Controls.Add(Me.btnSalir)
        Me.PanelControl1.Controls.Add(Me.btnBuscar)
        Me.PanelControl1.Location = New System.Drawing.Point(0, 175)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(360, 64)
        Me.PanelControl1.TabIndex = 118
        '
        'PanelBotones
        '
        Me.PanelBotones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelBotones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelBotones.Controls.Add(Me.rOpcionACompra)
        Me.PanelBotones.Controls.Add(Me.rTraspaso)
        Me.PanelBotones.Controls.Add(Me.rVacacional)
        Me.PanelBotones.Controls.Add(Me.rAlquiler)
        Me.PanelBotones.Controls.Add(Me.rVenta)
        Me.PanelBotones.Controls.Add(Me.chkOpcionACompra)
        Me.PanelBotones.Controls.Add(Me.chkTraspaso)
        Me.PanelBotones.Controls.Add(Me.chkVacacional)
        Me.PanelBotones.Controls.Add(Me.chkAlquiler)
        Me.PanelBotones.Controls.Add(Me.chkVenta)
        Me.PanelBotones.Controls.Add(Label1)
        Me.PanelBotones.Controls.Add(lblNumero)
        Me.PanelBotones.Location = New System.Drawing.Point(1, 3)
        Me.PanelBotones.Name = "PanelBotones"
        Me.PanelBotones.Size = New System.Drawing.Size(359, 172)
        Me.PanelBotones.TabIndex = 117
        '
        'rOpcionACompra
        '
        Me.rOpcionACompra.AutoSize = True
        Me.rOpcionACompra.Location = New System.Drawing.Point(11, 139)
        Me.rOpcionACompra.Name = "rOpcionACompra"
        Me.rOpcionACompra.Size = New System.Drawing.Size(121, 17)
        Me.rOpcionACompra.TabIndex = 118
        Me.rOpcionACompra.Text = "OPCIÓN A COMPRA"
        Me.rOpcionACompra.UseVisualStyleBackColor = True
        '
        'rTraspaso
        '
        Me.rTraspaso.AutoSize = True
        Me.rTraspaso.Location = New System.Drawing.Point(11, 114)
        Me.rTraspaso.Name = "rTraspaso"
        Me.rTraspaso.Size = New System.Drawing.Size(78, 17)
        Me.rTraspaso.TabIndex = 118
        Me.rTraspaso.Text = "TRASPASO"
        Me.rTraspaso.UseVisualStyleBackColor = True
        '
        'rVacacional
        '
        Me.rVacacional.AutoSize = True
        Me.rVacacional.Location = New System.Drawing.Point(11, 89)
        Me.rVacacional.Name = "rVacacional"
        Me.rVacacional.Size = New System.Drawing.Size(90, 17)
        Me.rVacacional.TabIndex = 118
        Me.rVacacional.Text = "VACACIONAL"
        Me.rVacacional.UseVisualStyleBackColor = True
        '
        'rAlquiler
        '
        Me.rAlquiler.AutoSize = True
        Me.rAlquiler.Location = New System.Drawing.Point(11, 64)
        Me.rAlquiler.Name = "rAlquiler"
        Me.rAlquiler.Size = New System.Drawing.Size(74, 17)
        Me.rAlquiler.TabIndex = 118
        Me.rAlquiler.Text = "ALQUILER"
        Me.rAlquiler.UseVisualStyleBackColor = True
        '
        'rVenta
        '
        Me.rVenta.AutoSize = True
        Me.rVenta.Location = New System.Drawing.Point(11, 39)
        Me.rVenta.Name = "rVenta"
        Me.rVenta.Size = New System.Drawing.Size(57, 17)
        Me.rVenta.TabIndex = 118
        Me.rVenta.Text = "VENTA"
        Me.rVenta.UseVisualStyleBackColor = True
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
        Me.btnSalir.Location = New System.Drawing.Point(278, 5)
        Me.btnSalir.LookAndFeel.SkinName = "Metropolis"
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(77, 55)
        Me.btnSalir.TabIndex = 6
        Me.btnSalir.Text = "Salir"
        '
        'btnBuscar
        '
        Me.btnBuscar.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnBuscar.Appearance.BorderColor = System.Drawing.Color.White
        Me.btnBuscar.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnBuscar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnBuscar.Appearance.Options.UseBackColor = True
        Me.btnBuscar.Appearance.Options.UseBorderColor = True
        Me.btnBuscar.Appearance.Options.UseFont = True
        Me.btnBuscar.Appearance.Options.UseForeColor = True
        Me.btnBuscar.Appearance.Options.UseTextOptions = True
        Me.btnBuscar.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnBuscar.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.btnBuscar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnBuscar.Image = Global.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(5, 5)
        Me.btnBuscar.LookAndFeel.SkinName = "Metropolis"
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(133, 55)
        Me.btnBuscar.TabIndex = 5
        Me.btnBuscar.Text = "Buscar"
        '
        'chkOpcionACompra
        '
        Me.chkOpcionACompra.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkOpcionACompra.Location = New System.Drawing.Point(205, 138)
        Me.chkOpcionACompra.Name = "chkOpcionACompra"
        Me.chkOpcionACompra.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkOpcionACompra.Properties.Appearance.Options.UseForeColor = True
        Me.chkOpcionACompra.Properties.Caption = "OPCIÓN A COMPRA"
        Me.chkOpcionACompra.Properties.ReadOnly = True
        Me.chkOpcionACompra.Size = New System.Drawing.Size(141, 19)
        Me.chkOpcionACompra.TabIndex = 117
        Me.chkOpcionACompra.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkOpcionACompra.tbColorSi = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        '
        'chkTraspaso
        '
        Me.chkTraspaso.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkTraspaso.Location = New System.Drawing.Point(205, 113)
        Me.chkTraspaso.Name = "chkTraspaso"
        Me.chkTraspaso.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkTraspaso.Properties.Appearance.Options.UseForeColor = True
        Me.chkTraspaso.Properties.Caption = "TRASPASO"
        Me.chkTraspaso.Properties.ReadOnly = True
        Me.chkTraspaso.Size = New System.Drawing.Size(92, 19)
        Me.chkTraspaso.TabIndex = 117
        Me.chkTraspaso.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkTraspaso.tbColorSi = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        '
        'chkVacacional
        '
        Me.chkVacacional.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkVacacional.Location = New System.Drawing.Point(205, 88)
        Me.chkVacacional.Name = "chkVacacional"
        Me.chkVacacional.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkVacacional.Properties.Appearance.Options.UseForeColor = True
        Me.chkVacacional.Properties.Caption = "VACACIONAL"
        Me.chkVacacional.Properties.ReadOnly = True
        Me.chkVacacional.Size = New System.Drawing.Size(92, 19)
        Me.chkVacacional.TabIndex = 117
        Me.chkVacacional.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkVacacional.tbColorSi = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        '
        'chkAlquiler
        '
        Me.chkAlquiler.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkAlquiler.Location = New System.Drawing.Point(205, 63)
        Me.chkAlquiler.Name = "chkAlquiler"
        Me.chkAlquiler.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkAlquiler.Properties.Appearance.Options.UseForeColor = True
        Me.chkAlquiler.Properties.Caption = "ALQUILER"
        Me.chkAlquiler.Properties.ReadOnly = True
        Me.chkAlquiler.Size = New System.Drawing.Size(92, 19)
        Me.chkAlquiler.TabIndex = 117
        Me.chkAlquiler.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkAlquiler.tbColorSi = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        '
        'chkVenta
        '
        Me.chkVenta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkVenta.Location = New System.Drawing.Point(205, 38)
        Me.chkVenta.Name = "chkVenta"
        Me.chkVenta.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkVenta.Properties.Appearance.Options.UseForeColor = True
        Me.chkVenta.Properties.Caption = "VENTA"
        Me.chkVenta.Properties.ReadOnly = True
        Me.chkVenta.Size = New System.Drawing.Size(92, 19)
        Me.chkVenta.TabIndex = 117
        Me.chkVenta.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkVenta.tbColorSi = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        '
        'frmFiltroDuplicados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(360, 240)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PanelBotones)
        Me.Name = "frmFiltroDuplicados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Quitar Duplicados"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBotones.ResumeLayout(False)
        Me.PanelBotones.PerformLayout()
        CType(Me.chkOpcionACompra.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkTraspaso.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkVacacional.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAlquiler.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkVenta.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnSalir As uc_tb_SimpleButton
    Friend WithEvents btnBuscar As uc_tb_SimpleButton
    Friend WithEvents PanelBotones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents rOpcionACompra As System.Windows.Forms.RadioButton
    Friend WithEvents rTraspaso As System.Windows.Forms.RadioButton
    Friend WithEvents rVacacional As System.Windows.Forms.RadioButton
    Friend WithEvents rAlquiler As System.Windows.Forms.RadioButton
    Friend WithEvents rVenta As System.Windows.Forms.RadioButton
    Friend WithEvents chkOpcionACompra As uc_tb_CheckBoxRojoNegro
    Friend WithEvents chkTraspaso As uc_tb_CheckBoxRojoNegro
    Friend WithEvents chkVacacional As uc_tb_CheckBoxRojoNegro
    Friend WithEvents chkAlquiler As uc_tb_CheckBoxRojoNegro
    Friend WithEvents chkVenta As uc_tb_CheckBoxRojoNegro
End Class
