<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucImagenes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucImagenes))
        Dim GalleryItemGroup1 As DevExpress.XtraBars.Ribbon.GalleryItemGroup = New DevExpress.XtraBars.Ribbon.GalleryItemGroup()
        Dim GalleryItemGroup2 As DevExpress.XtraBars.Ribbon.GalleryItemGroup = New DevExpress.XtraBars.Ribbon.GalleryItemGroup()
        Me.imageSlider = New DevExpress.XtraEditors.Controls.ImageSlider()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.PanelBotones = New DevExpress.XtraEditors.PanelControl()
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnPublicar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnImprimir = New DevExpress.XtraEditors.SimpleButton()
        Me.btnEliminar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAnadir = New DevExpress.XtraEditors.SimpleButton()
        Me.gc = New DevExpress.XtraBars.Ribbon.GalleryControl()
        Me.GalleryControlClient1 = New DevExpress.XtraBars.Ribbon.GalleryControlClient()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        CType(Me.imageSlider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBotones.SuspendLayout()
        CType(Me.gc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gc.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imageSlider
        '
        Me.imageSlider.LayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.ZoomInside
        Me.imageSlider.Location = New System.Drawing.Point(207, 12)
        Me.imageSlider.Name = "imageSlider"
        Me.imageSlider.Size = New System.Drawing.Size(528, 334)
        Me.imageSlider.StyleController = Me.LayoutControl1
        Me.imageSlider.TabIndex = 17
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.PanelBotones)
        Me.LayoutControl1.Controls.Add(Me.imageSlider)
        Me.LayoutControl1.Controls.Add(Me.gc)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(539, 217, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(747, 427)
        Me.LayoutControl1.TabIndex = 1
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'PanelBotones
        '
        Me.PanelBotones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelBotones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelBotones.Controls.Add(Me.btnCancelar)
        Me.PanelBotones.Controls.Add(Me.btnAceptar)
        Me.PanelBotones.Controls.Add(Me.btnPublicar)
        Me.PanelBotones.Controls.Add(Me.btnImprimir)
        Me.PanelBotones.Controls.Add(Me.btnEliminar)
        Me.PanelBotones.Controls.Add(Me.btnAnadir)
        Me.PanelBotones.Location = New System.Drawing.Point(12, 350)
        Me.PanelBotones.Name = "PanelBotones"
        Me.PanelBotones.Size = New System.Drawing.Size(723, 65)
        Me.PanelBotones.TabIndex = 19
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelar.Appearance.Options.UseBackColor = True
        Me.btnCancelar.Appearance.Options.UseTextOptions = True
        Me.btnCancelar.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnCancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnCancelar.Image = Global.My.Resources.Resources.Cancelar
        Me.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnCancelar.Location = New System.Drawing.Point(653, 7)
        Me.btnCancelar.LookAndFeel.SkinName = "Metropolis"
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(65, 51)
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.Text = "Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnAceptar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Appearance.Options.UseBackColor = True
        Me.btnAceptar.Appearance.Options.UseFont = True
        Me.btnAceptar.Appearance.Options.UseForeColor = True
        Me.btnAceptar.Appearance.Options.UseTextOptions = True
        Me.btnAceptar.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.btnAceptar.BackgroundImage = CType(resources.GetObject("btnAceptar.BackgroundImage"), System.Drawing.Image)
        Me.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAceptar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnAceptar.Image = Global.My.Resources.Resources.empty
        Me.btnAceptar.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnAceptar.Location = New System.Drawing.Point(561, 7)
        Me.btnAceptar.LookAndFeel.SkinName = "Metropolis"
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(86, 51)
        Me.btnAceptar.TabIndex = 9
        Me.btnAceptar.Text = "Publicar"
        Me.btnAceptar.ToolTip = "Subir a la web"
        '
        'btnPublicar
        '
        Me.btnPublicar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPublicar.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnPublicar.Appearance.Options.UseBackColor = True
        Me.btnPublicar.Appearance.Options.UseTextOptions = True
        Me.btnPublicar.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnPublicar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnPublicar.Image = CType(resources.GetObject("btnPublicar.Image"), System.Drawing.Image)
        Me.btnPublicar.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnPublicar.Location = New System.Drawing.Point(147, 7)
        Me.btnPublicar.LookAndFeel.SkinName = "Metropolis"
        Me.btnPublicar.Name = "btnPublicar"
        Me.btnPublicar.Size = New System.Drawing.Size(65, 51)
        Me.btnPublicar.TabIndex = 7
        Me.btnPublicar.Text = "A publicar"
        Me.btnPublicar.ToolTip = "Mover a publicar  selección"
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImprimir.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnImprimir.Appearance.Options.UseBackColor = True
        Me.btnImprimir.Appearance.Options.UseTextOptions = True
        Me.btnImprimir.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnImprimir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnImprimir.Image = Global.My.Resources.Resources.ImprimirBoton
        Me.btnImprimir.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnImprimir.Location = New System.Drawing.Point(218, 7)
        Me.btnImprimir.LookAndFeel.SkinName = "Metropolis"
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(65, 51)
        Me.btnImprimir.TabIndex = 6
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.ToolTip = "Imprimir selección"
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnEliminar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnEliminar.Appearance.Options.UseBackColor = True
        Me.btnEliminar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnEliminar.Image = Global.My.Resources.Resources.Eliminar
        Me.btnEliminar.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnEliminar.Location = New System.Drawing.Point(76, 7)
        Me.btnEliminar.LookAndFeel.SkinName = "Metropolis"
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(65, 51)
        Me.btnEliminar.TabIndex = 1
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.ToolTip = "Eliminar  selección"
        '
        'btnAnadir
        '
        Me.btnAnadir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAnadir.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnAnadir.Appearance.Options.UseBackColor = True
        Me.btnAnadir.Appearance.Options.UseTextOptions = True
        Me.btnAnadir.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnAnadir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnAnadir.Image = Global.My.Resources.Resources.Anadir
        Me.btnAnadir.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnAnadir.Location = New System.Drawing.Point(5, 7)
        Me.btnAnadir.LookAndFeel.SkinName = "Metropolis"
        Me.btnAnadir.Name = "btnAnadir"
        Me.btnAnadir.Size = New System.Drawing.Size(65, 51)
        Me.btnAnadir.TabIndex = 0
        Me.btnAnadir.Text = "Añadir"
        '
        'gc
        '
        Me.gc.Controls.Add(Me.GalleryControlClient1)
        Me.gc.DesignGalleryGroupIndex = 0
        Me.gc.DesignGalleryItemIndex = 0
        '
        'GalleryControlGallery1
        '
        Me.gc.Gallery.AllowHoverImages = True
        Me.gc.Gallery.AllowMarqueeSelection = True
        GalleryItemGroup1.Caption = "Group1"
        GalleryItemGroup2.Caption = "Group2"
        Me.gc.Gallery.Groups.AddRange(New DevExpress.XtraBars.Ribbon.GalleryItemGroup() {GalleryItemGroup1, GalleryItemGroup2})
        Me.gc.Location = New System.Drawing.Point(12, 12)
        Me.gc.Name = "gc"
        Me.gc.Size = New System.Drawing.Size(186, 334)
        Me.gc.StyleController = Me.LayoutControl1
        Me.gc.TabIndex = 0
        Me.gc.Text = "GalleryControl1"
        '
        'GalleryControlClient1
        '
        Me.GalleryControlClient1.GalleryControl = Me.gc
        Me.GalleryControlClient1.Location = New System.Drawing.Point(2, 23)
        Me.GalleryControlClient1.Size = New System.Drawing.Size(165, 309)
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Root"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem1, Me.LayoutControlItem3, Me.SplitterItem1})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(747, 427)
        Me.LayoutControlGroup1.Text = "Root"
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.imageSlider
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(195, 0)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(54, 20)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(532, 338)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.Text = "LayoutControlItem2"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextToControlDistance = 0
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.gc
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(54, 108)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(190, 338)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.Text = "LayoutControlItem1"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextToControlDistance = 0
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.PanelBotones
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 338)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(0, 69)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(104, 69)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(727, 69)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.Text = "LayoutControlItem3"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextToControlDistance = 0
        Me.LayoutControlItem3.TextVisible = False
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.CustomizationFormText = "SplitterItem1"
        Me.SplitterItem1.Location = New System.Drawing.Point(190, 0)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(5, 338)
        '
        'ucImagenes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "ucImagenes"
        Me.Size = New System.Drawing.Size(747, 427)
        CType(Me.imageSlider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBotones.ResumeLayout(False)
        CType(Me.gc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gc.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents imageSlider As DevExpress.XtraEditors.Controls.ImageSlider
    Friend WithEvents gc As DevExpress.XtraBars.Ribbon.GalleryControl
    Friend WithEvents GalleryControlClient1 As DevExpress.XtraBars.Ribbon.GalleryControlClient
    Friend WithEvents PanelBotones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnImprimir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnEliminar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAnadir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnPublicar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents btnAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton

End Class
