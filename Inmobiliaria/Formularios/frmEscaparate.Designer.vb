<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEscaparate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEscaparate))
        Dim GalleryItemGroup1 As DevExpress.XtraBars.Ribbon.GalleryItemGroup = New DevExpress.XtraBars.Ribbon.GalleryItemGroup()
        Me.imgPrincipal = New DevExpress.XtraEditors.PictureEdit()
        Me.PanelBotones = New DevExpress.XtraEditors.PanelControl()
        Me.chkMostrarQR = New uc_tb_CheckBoxRojoNegro()
        Me.chkMostrarPrecios = New uc_tb_CheckBoxRojoNegro()
        Me.btnGuardar = New uc_tb_SimpleButton()
        Me.btnLimpiar = New uc_tb_SimpleButton()
        Me.btnSecundaria = New uc_tb_SimpleButton()
        Me.btnPrincipal = New uc_tb_SimpleButton()
        Me.btnImprimir = New uc_tb_SimpleButton()
        Me.btnSalir = New uc_tb_SimpleButton()
        Me.imgSecundaria = New DevExpress.XtraEditors.PictureEdit()
        Me.gc = New DevExpress.XtraBars.Ribbon.GalleryControl()
        Me.GalleryControlClient1 = New DevExpress.XtraBars.Ribbon.GalleryControlClient()
        Me.lbcInformes = New DevExpress.XtraEditors.ListBoxControl()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.imgPrincipal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBotones.SuspendLayout()
        CType(Me.chkMostrarQR.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkMostrarPrecios.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgSecundaria.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gc.SuspendLayout()
        CType(Me.lbcInformes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imgPrincipal
        '
        Me.imgPrincipal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgPrincipal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.imgPrincipal.Location = New System.Drawing.Point(281, 17)
        Me.imgPrincipal.Name = "imgPrincipal"
        Me.imgPrincipal.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.imgPrincipal.Properties.Appearance.Options.UseFont = True
        Me.imgPrincipal.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.imgPrincipal.Size = New System.Drawing.Size(640, 480)
        Me.imgPrincipal.TabIndex = 184
        '
        'PanelBotones
        '
        Me.PanelBotones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelBotones.Controls.Add(Me.chkMostrarQR)
        Me.PanelBotones.Controls.Add(Me.chkMostrarPrecios)
        Me.PanelBotones.Controls.Add(Me.btnGuardar)
        Me.PanelBotones.Controls.Add(Me.btnLimpiar)
        Me.PanelBotones.Controls.Add(Me.btnSecundaria)
        Me.PanelBotones.Controls.Add(Me.btnPrincipal)
        Me.PanelBotones.Controls.Add(Me.btnImprimir)
        Me.PanelBotones.Controls.Add(Me.btnSalir)
        Me.PanelBotones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBotones.Location = New System.Drawing.Point(0, 503)
        Me.PanelBotones.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PanelBotones.Name = "PanelBotones"
        Me.PanelBotones.Size = New System.Drawing.Size(926, 64)
        Me.PanelBotones.TabIndex = 19
        '
        'chkMostrarQR
        '
        Me.chkMostrarQR.Location = New System.Drawing.Point(253, 36)
        Me.chkMostrarQR.Name = "chkMostrarQR"
        Me.chkMostrarQR.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkMostrarQR.Properties.Appearance.Options.UseForeColor = True
        Me.chkMostrarQR.Properties.Caption = "Mostrar QR"
        Me.chkMostrarQR.Properties.ReadOnly = True
        Me.chkMostrarQR.Size = New System.Drawing.Size(164, 19)
        Me.chkMostrarQR.TabIndex = 12
        Me.chkMostrarQR.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkMostrarQR.tbColorSi = System.Drawing.ColorTranslator.FromHtml("#14b12b")
        '
        'chkMostrarPrecios
        '
        Me.chkMostrarPrecios.Location = New System.Drawing.Point(253, 11)
        Me.chkMostrarPrecios.Name = "chkMostrarPrecios"
        Me.chkMostrarPrecios.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkMostrarPrecios.Properties.Appearance.Options.UseForeColor = True
        Me.chkMostrarPrecios.Properties.Caption = "Mostrar Precios"
        Me.chkMostrarPrecios.Properties.ReadOnly = True
        Me.chkMostrarPrecios.Size = New System.Drawing.Size(164, 19)
        Me.chkMostrarPrecios.TabIndex = 11
        Me.chkMostrarPrecios.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkMostrarPrecios.tbColorSi = System.Drawing.ColorTranslator.FromHtml("#14b12b")
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnGuardar.Appearance.Options.UseBackColor = True
        Me.btnGuardar.Appearance.Options.UseTextOptions = True
        Me.btnGuardar.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnGuardar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnGuardar.Image = Global.My.Resources.Resources.Save_32x32
        Me.btnGuardar.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(691, 5)
        Me.btnGuardar.LookAndFeel.SkinName = "Metropolis"
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 55)
        Me.btnGuardar.TabIndex = 13
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.ToolTip = "Guaradar configuración actual"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnLimpiar.Appearance.Options.UseBackColor = True
        Me.btnLimpiar.Appearance.Options.UseTextOptions = True
        Me.btnLimpiar.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnLimpiar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnLimpiar.Image = Global.My.Resources.Resources.RemoveFromAlbum_32x32
        Me.btnLimpiar.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnLimpiar.Location = New System.Drawing.Point(167, 5)
        Me.btnLimpiar.LookAndFeel.SkinName = "Metropolis"
        Me.btnLimpiar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(75, 55)
        Me.btnLimpiar.TabIndex = 10
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.ToolTip = "Quitar las imagenes actuales"
        '
        'btnSecundaria
        '
        Me.btnSecundaria.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSecundaria.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnSecundaria.Appearance.Options.UseBackColor = True
        Me.btnSecundaria.Appearance.Options.UseTextOptions = True
        Me.btnSecundaria.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnSecundaria.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnSecundaria.Image = CType(resources.GetObject("btnSecundaria.Image"), System.Drawing.Image)
        Me.btnSecundaria.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnSecundaria.Location = New System.Drawing.Point(86, 5)
        Me.btnSecundaria.LookAndFeel.SkinName = "Metropolis"
        Me.btnSecundaria.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSecundaria.Name = "btnSecundaria"
        Me.btnSecundaria.Size = New System.Drawing.Size(75, 55)
        Me.btnSecundaria.TabIndex = 9
        Me.btnSecundaria.Text = "Secundaria"
        Me.btnSecundaria.ToolTip = "Establecer imagen secundaria (Opcional)"
        '
        'btnPrincipal
        '
        Me.btnPrincipal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrincipal.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnPrincipal.Appearance.Options.UseBackColor = True
        Me.btnPrincipal.Appearance.Options.UseTextOptions = True
        Me.btnPrincipal.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnPrincipal.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnPrincipal.Image = CType(resources.GetObject("btnPrincipal.Image"), System.Drawing.Image)
        Me.btnPrincipal.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnPrincipal.Location = New System.Drawing.Point(5, 5)
        Me.btnPrincipal.LookAndFeel.SkinName = "Metropolis"
        Me.btnPrincipal.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPrincipal.Name = "btnPrincipal"
        Me.btnPrincipal.Size = New System.Drawing.Size(75, 55)
        Me.btnPrincipal.TabIndex = 8
        Me.btnPrincipal.Text = "Principal"
        Me.btnPrincipal.ToolTip = "Establecer imagen principal"
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImprimir.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnImprimir.Appearance.Options.UseBackColor = True
        Me.btnImprimir.Appearance.Options.UseTextOptions = True
        Me.btnImprimir.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnImprimir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnImprimir.Image = Global.My.Resources.Resources.ImprimirBoton
        Me.btnImprimir.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnImprimir.Location = New System.Drawing.Point(772, 5)
        Me.btnImprimir.LookAndFeel.SkinName = "Metropolis"
        Me.btnImprimir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(75, 55)
        Me.btnImprimir.TabIndex = 14
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.ToolTip = "Imprimir, guardar y salir"
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
        Me.btnSalir.Location = New System.Drawing.Point(853, 5)
        Me.btnSalir.LookAndFeel.SkinName = "Metropolis"
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(68, 55)
        Me.btnSalir.TabIndex = 15
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.ToolTip = "Cerrar sin guardar"
        '
        'imgSecundaria
        '
        Me.imgSecundaria.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgSecundaria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.imgSecundaria.Location = New System.Drawing.Point(304, 245)
        Me.imgSecundaria.Name = "imgSecundaria"
        Me.imgSecundaria.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.imgSecundaria.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.imgSecundaria.Properties.Appearance.Options.UseBackColor = True
        Me.imgSecundaria.Properties.Appearance.Options.UseFont = True
        Me.imgSecundaria.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.imgSecundaria.Size = New System.Drawing.Size(320, 240)
        Me.imgSecundaria.TabIndex = 185
        '
        'gc
        '
        Me.gc.Controls.Add(Me.GalleryControlClient1)
        Me.gc.DesignGalleryGroupIndex = 0
        Me.gc.DesignGalleryItemIndex = 0
        '
        'GalleryControlGallery1
        '
        GalleryItemGroup1.Caption = "Imagenes del inmueble"
        Me.gc.Gallery.Groups.AddRange(New DevExpress.XtraBars.Ribbon.GalleryItemGroup() {GalleryItemGroup1})
        Me.gc.Location = New System.Drawing.Point(5, 160)
        Me.gc.Name = "gc"
        Me.gc.Size = New System.Drawing.Size(267, 337)
        Me.gc.TabIndex = 186
        Me.gc.Text = "GalleryControl1"
        '
        'GalleryControlClient1
        '
        Me.GalleryControlClient1.GalleryControl = Me.gc
        Me.GalleryControlClient1.Location = New System.Drawing.Point(2, 2)
        Me.GalleryControlClient1.Size = New System.Drawing.Size(246, 333)
        '
        'lbcInformes
        '
        Me.lbcInformes.Location = New System.Drawing.Point(7, 31)
        Me.lbcInformes.Name = "lbcInformes"
        Me.lbcInformes.Size = New System.Drawing.Size(265, 123)
        Me.lbcInformes.TabIndex = 187
        '
        'LabelControl14
        '
        Me.LabelControl14.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(43, 13)
        Me.LabelControl14.TabIndex = 205
        Me.LabelControl14.Text = "Informes"
        '
        'frmEscaparate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(926, 567)
        Me.ControlBox = False
        Me.Controls.Add(Me.LabelControl14)
        Me.Controls.Add(Me.lbcInformes)
        Me.Controls.Add(Me.gc)
        Me.Controls.Add(Me.imgSecundaria)
        Me.Controls.Add(Me.imgPrincipal)
        Me.Controls.Add(Me.PanelBotones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmEscaparate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Escaparate"
        CType(Me.imgPrincipal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBotones.ResumeLayout(False)
        CType(Me.chkMostrarQR.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkMostrarPrecios.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgSecundaria.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gc.ResumeLayout(False)
        CType(Me.lbcInformes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelBotones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnSalir As uc_tb_SimpleButton
    Friend WithEvents imgPrincipal As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents imgSecundaria As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents btnSecundaria As uc_tb_SimpleButton
    Friend WithEvents btnPrincipal As uc_tb_SimpleButton
    Friend WithEvents btnImprimir As uc_tb_SimpleButton
    Friend WithEvents gc As DevExpress.XtraBars.Ribbon.GalleryControl
    Friend WithEvents GalleryControlClient1 As DevExpress.XtraBars.Ribbon.GalleryControlClient
    Friend WithEvents btnLimpiar As uc_tb_SimpleButton
    Friend WithEvents lbcInformes As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnGuardar As uc_tb_SimpleButton
    Friend WithEvents chkMostrarPrecios As uc_tb_CheckBoxRojoNegro
    Friend WithEvents chkMostrarQR As uc_tb_CheckBoxRojoNegro
End Class
