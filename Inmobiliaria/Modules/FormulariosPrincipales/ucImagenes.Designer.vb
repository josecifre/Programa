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
        Dim GalleryItemGroup1 As DevExpress.XtraBars.Ribbon.GalleryItemGroup = New DevExpress.XtraBars.Ribbon.GalleryItemGroup()
        Dim GalleryItemGroup2 As DevExpress.XtraBars.Ribbon.GalleryItemGroup = New DevExpress.XtraBars.Ribbon.GalleryItemGroup()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.gcWeb = New DevExpress.XtraBars.Ribbon.GalleryControl()
        Me.GalleryControlClient3 = New DevExpress.XtraBars.Ribbon.GalleryControlClient()
        Me.PanelBotones = New DevExpress.XtraEditors.PanelControl()
        Me.btnRotarIzquierda = New uc_tb_SimpleButton()
        Me.btnRotarDerecha = New uc_tb_SimpleButton()
        Me.btnPrincipal = New uc_tb_SimpleButton()
        Me.btnEscaparate = New uc_tb_SimpleButton()
        Me.btnCancelar = New uc_tb_SimpleButton()
        Me.btnPublicar = New uc_tb_SimpleButton()
        Me.btnImprimir = New uc_tb_SimpleButton()
        Me.btnEliminar = New uc_tb_SimpleButton()
        Me.btnAnadir = New uc_tb_SimpleButton()
        Me.gc = New DevExpress.XtraBars.Ribbon.GalleryControl()
        Me.GalleryControlClient1 = New DevExpress.XtraBars.Ribbon.GalleryControlClient()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.gcWeb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gcWeb.SuspendLayout()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBotones.SuspendLayout()
        CType(Me.gc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gc.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.gcWeb)
        Me.LayoutControl1.Controls.Add(Me.PanelBotones)
        Me.LayoutControl1.Controls.Add(Me.gc)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(-1169, 209, 675, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(747, 427)
        Me.LayoutControl1.TabIndex = 1
        Me.LayoutControl1.Text = "LayoutControl1"
        Me.ToolTip1.SetToolTip(Me.LayoutControl1, "Ctrl o Shift para selecciones multiples," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Supr para borrar, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "DobleClick para amp" &
        "liar imagen")
        '
        'gcWeb
        '
        Me.gcWeb.Controls.Add(Me.GalleryControlClient3)
        Me.gcWeb.DesignGalleryGroupIndex = 0
        Me.gcWeb.DesignGalleryItemIndex = 0
        '
        'GalleryControlGallery1
        '
        GalleryItemGroup1.Caption = "Group1"
        Me.gcWeb.Gallery.Groups.AddRange(New DevExpress.XtraBars.Ribbon.GalleryItemGroup() {GalleryItemGroup1})
        Me.gcWeb.Location = New System.Drawing.Point(378, 12)
        Me.gcWeb.Name = "gcWeb"
        Me.gcWeb.Size = New System.Drawing.Size(357, 334)
        Me.gcWeb.StyleController = Me.LayoutControl1
        Me.gcWeb.TabIndex = 1
        Me.gcWeb.Text = "GalleryControl1"
        Me.gcWeb.ToolTip = "Ctrl o Shift para selecciones multiples," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Supr para borrar, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "DobleClick para amp" &
    "liar imagen"
        Me.ToolTip1.SetToolTip(Me.gcWeb, "Ctrl o Shift para selecciones multiples," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Supr para borrar, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "DobleClick para amp" &
        "liar imagen")
        Me.gcWeb.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        '
        'GalleryControlClient3
        '
        Me.GalleryControlClient3.GalleryControl = Me.gcWeb
        Me.GalleryControlClient3.Location = New System.Drawing.Point(2, 2)
        Me.GalleryControlClient3.Size = New System.Drawing.Size(336, 330)
        '
        'PanelBotones
        '
        Me.PanelBotones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelBotones.Controls.Add(Me.btnRotarIzquierda)
        Me.PanelBotones.Controls.Add(Me.btnRotarDerecha)
        Me.PanelBotones.Controls.Add(Me.btnPrincipal)
        Me.PanelBotones.Controls.Add(Me.btnEscaparate)
        Me.PanelBotones.Controls.Add(Me.btnCancelar)
        Me.PanelBotones.Controls.Add(Me.btnPublicar)
        Me.PanelBotones.Controls.Add(Me.btnImprimir)
        Me.PanelBotones.Controls.Add(Me.btnEliminar)
        Me.PanelBotones.Controls.Add(Me.btnAnadir)
        Me.PanelBotones.Location = New System.Drawing.Point(12, 350)
        Me.PanelBotones.Name = "PanelBotones"
        Me.PanelBotones.Size = New System.Drawing.Size(723, 65)
        Me.PanelBotones.TabIndex = 19
        Me.ToolTip1.SetToolTip(Me.PanelBotones, "Ctrl o Shift para selecciones multiples," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Supr para borrar, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "DobleClick para amp" &
        "liar imagen")
        '
        'btnRotarIzquierda
        '
        Me.btnRotarIzquierda.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRotarIzquierda.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnRotarIzquierda.Appearance.Options.UseBackColor = True
        Me.btnRotarIzquierda.Appearance.Options.UseTextOptions = True
        Me.btnRotarIzquierda.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnRotarIzquierda.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnRotarIzquierda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnRotarIzquierda.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnRotarIzquierda.Image = Global.My.Resources.Resources.rotarIzq
        Me.btnRotarIzquierda.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnRotarIzquierda.Location = New System.Drawing.Point(349, 5)
        Me.btnRotarIzquierda.LookAndFeel.SkinName = "Metropolis"
        Me.btnRotarIzquierda.Name = "btnRotarIzquierda"
        Me.btnRotarIzquierda.Size = New System.Drawing.Size(37, 55)
        Me.btnRotarIzquierda.TabIndex = 9
        Me.btnRotarIzquierda.Tag = ""
        Me.btnRotarIzquierda.Text = "Izq"
        Me.btnRotarIzquierda.ToolTip = "Rota la imagen a la izquierda"
        '
        'btnRotarDerecha
        '
        Me.btnRotarDerecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRotarDerecha.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnRotarDerecha.Appearance.Options.UseBackColor = True
        Me.btnRotarDerecha.Appearance.Options.UseTextOptions = True
        Me.btnRotarDerecha.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnRotarDerecha.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnRotarDerecha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnRotarDerecha.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnRotarDerecha.Image = Global.My.Resources.Resources.rotarDer
        Me.btnRotarDerecha.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnRotarDerecha.Location = New System.Drawing.Point(392, 5)
        Me.btnRotarDerecha.LookAndFeel.SkinName = "Metropolis"
        Me.btnRotarDerecha.Name = "btnRotarDerecha"
        Me.btnRotarDerecha.Size = New System.Drawing.Size(37, 55)
        Me.btnRotarDerecha.TabIndex = 8
        Me.btnRotarDerecha.Tag = ""
        Me.btnRotarDerecha.Text = "Der"
        Me.btnRotarDerecha.ToolTip = "Rota la imagen a la derecha"
        '
        'btnPrincipal
        '
        Me.btnPrincipal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrincipal.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnPrincipal.Appearance.Options.UseBackColor = True
        Me.btnPrincipal.Appearance.Options.UseTextOptions = True
        Me.btnPrincipal.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnPrincipal.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnPrincipal.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnPrincipal.Image = Global.My.Resources.Resources.First
        Me.btnPrincipal.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnPrincipal.Location = New System.Drawing.Point(177, 5)
        Me.btnPrincipal.LookAndFeel.SkinName = "Metropolis"
        Me.btnPrincipal.Name = "btnPrincipal"
        Me.btnPrincipal.Size = New System.Drawing.Size(80, 55)
        Me.btnPrincipal.TabIndex = 3
        Me.btnPrincipal.Text = "Principal"
        Me.btnPrincipal.ToolTip = "Establecer foto principal"
        '
        'btnEscaparate
        '
        Me.btnEscaparate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEscaparate.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnEscaparate.Appearance.Options.UseBackColor = True
        Me.btnEscaparate.Appearance.Options.UseTextOptions = True
        Me.btnEscaparate.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnEscaparate.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnEscaparate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnEscaparate.Image = Global.My.Resources.Resources.Escaparate
        Me.btnEscaparate.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnEscaparate.Location = New System.Drawing.Point(435, 5)
        Me.btnEscaparate.LookAndFeel.SkinName = "Metropolis"
        Me.btnEscaparate.Name = "btnEscaparate"
        Me.btnEscaparate.Size = New System.Drawing.Size(80, 55)
        Me.btnEscaparate.TabIndex = 5
        Me.btnEscaparate.Text = "Escaparate"
        Me.btnEscaparate.ToolTip = "Preparar e imprimir escaparate"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Appearance.Options.UseBackColor = True
        Me.btnCancelar.Appearance.Options.UseTextOptions = True
        Me.btnCancelar.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnCancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnCancelar.Image = Global.My.Resources.Resources.desconexion_de_salida_icono_7025_641
        Me.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnCancelar.Location = New System.Drawing.Point(638, 5)
        Me.btnCancelar.LookAndFeel.SkinName = "Metropolis"
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 55)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "Cancelar"
        '
        'btnPublicar
        '
        Me.btnPublicar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPublicar.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnPublicar.Appearance.Options.UseBackColor = True
        Me.btnPublicar.Appearance.Options.UseTextOptions = True
        Me.btnPublicar.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnPublicar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnPublicar.Image = Global.My.Resources.Resources.enviar
        Me.btnPublicar.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnPublicar.Location = New System.Drawing.Point(263, 5)
        Me.btnPublicar.LookAndFeel.SkinName = "Metropolis"
        Me.btnPublicar.Name = "btnPublicar"
        Me.btnPublicar.Size = New System.Drawing.Size(80, 55)
        Me.btnPublicar.TabIndex = 4
        Me.btnPublicar.Text = "Publicar"
        Me.btnPublicar.ToolTip = "Publicar las imágenes selccionadas"
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
        Me.btnImprimir.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnImprimir.Location = New System.Drawing.Point(521, 5)
        Me.btnImprimir.LookAndFeel.SkinName = "Metropolis"
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(80, 55)
        Me.btnImprimir.TabIndex = 6
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.ToolTip = "Imprimir selección"
        Me.btnImprimir.Visible = False
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnEliminar.Appearance.Options.UseBackColor = True
        Me.btnEliminar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnEliminar.Image = Global.My.Resources.Resources.Eliminar1
        Me.btnEliminar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnEliminar.Location = New System.Drawing.Point(91, 5)
        Me.btnEliminar.LookAndFeel.SkinName = "Metropolis"
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(80, 55)
        Me.btnEliminar.TabIndex = 2
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.ToolTip = "Eliminar  selección"
        '
        'btnAnadir
        '
        Me.btnAnadir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAnadir.Appearance.Options.UseBackColor = True
        Me.btnAnadir.Appearance.Options.UseTextOptions = True
        Me.btnAnadir.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnAnadir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnAnadir.Image = Global.My.Resources.Resources.Add_New
        Me.btnAnadir.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnAnadir.Location = New System.Drawing.Point(5, 5)
        Me.btnAnadir.LookAndFeel.SkinName = "Metropolis"
        Me.btnAnadir.Name = "btnAnadir"
        Me.btnAnadir.Size = New System.Drawing.Size(80, 55)
        Me.btnAnadir.TabIndex = 1
        Me.btnAnadir.Text = "Añadir"
        '
        'gc
        '
        Me.gc.Controls.Add(Me.GalleryControlClient1)
        Me.gc.DesignGalleryGroupIndex = 0
        Me.gc.DesignGalleryItemIndex = 0
        '
        'GalleryControlGallery2
        '
        GalleryItemGroup2.Caption = "Group1"
        Me.gc.Gallery.Groups.AddRange(New DevExpress.XtraBars.Ribbon.GalleryItemGroup() {GalleryItemGroup2})
        Me.gc.Location = New System.Drawing.Point(12, 12)
        Me.gc.Name = "gc"
        Me.gc.Size = New System.Drawing.Size(357, 334)
        Me.gc.StyleController = Me.LayoutControl1
        Me.gc.TabIndex = 0
        Me.gc.Text = "GalleryControl1"
        Me.gc.ToolTip = "Ctrl o Shift para selecciones multiples," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Supr para borrar, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "DobleClick para amp" &
    "liar imagen"
        Me.ToolTip1.SetToolTip(Me.gc, "Ctrl o Shift para selecciones multiples," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Supr para borrar, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "DobleClick para amp" &
        "liar imagen")
        Me.gc.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        '
        'GalleryControlClient1
        '
        Me.GalleryControlClient1.GalleryControl = Me.gc
        Me.GalleryControlClient1.Location = New System.Drawing.Point(2, 2)
        Me.GalleryControlClient1.Size = New System.Drawing.Size(336, 330)
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Root"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem3, Me.SplitterItem1, Me.LayoutControlItem2})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(747, 427)
        Me.LayoutControlGroup1.Text = "Ctrl o Shift para selecciones multiples"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.gc
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(54, 108)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(361, 338)
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
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(104, 24)
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
        Me.SplitterItem1.Location = New System.Drawing.Point(361, 0)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(5, 338)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.gcWeb
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(366, 0)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(54, 30)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(361, 338)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.Text = "LayoutControlItem2"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextToControlDistance = 0
        Me.LayoutControlItem2.TextVisible = False
        '
        'ucImagenes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "ucImagenes"
        Me.Size = New System.Drawing.Size(747, 427)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.gcWeb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gcWeb.ResumeLayout(False)
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBotones.ResumeLayout(False)
        CType(Me.gc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gc.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gc As DevExpress.XtraBars.Ribbon.GalleryControl
    Friend WithEvents GalleryControlClient1 As DevExpress.XtraBars.Ribbon.GalleryControlClient
    Friend WithEvents PanelBotones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnImprimir As uc_tb_SimpleButton
    Friend WithEvents btnEliminar As uc_tb_SimpleButton
    Friend WithEvents btnAnadir As uc_tb_SimpleButton
    Friend WithEvents btnPublicar As uc_tb_SimpleButton
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents btnCancelar As uc_tb_SimpleButton
    Friend WithEvents btnEscaparate As uc_tb_SimpleButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnPrincipal As uc_tb_SimpleButton
    Friend WithEvents gcWeb As DevExpress.XtraBars.Ribbon.GalleryControl
    Friend WithEvents GalleryControlClient3 As DevExpress.XtraBars.Ribbon.GalleryControlClient
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnRotarDerecha As uc_tb_SimpleButton
    Friend WithEvents btnRotarIzquierda As uc_tb_SimpleButton

End Class
