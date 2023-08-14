Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.XtraBars.Ribbon


<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrincipal
    Inherits RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrincipal))
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Me.ribbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.appMenu = New DevExpress.XtraBars.Ribbon.ApplicationMenu(Me.components)
        Me.popupControlContainer2 = New DevExpress.XtraBars.PopupControlContainer(Me.components)
        Me.buttonEdit = New DevExpress.XtraEditors.ButtonEdit()
        Me.BarButtonItem11 = New DevExpress.XtraBars.BarButtonItem()
        Me.iExit = New DevExpress.XtraBars.BarButtonItem()
        Me.popupControlContainer1 = New DevExpress.XtraBars.PopupControlContainer(Me.components)
        Me.someLabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.someLabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.ribbonImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.iNew = New DevExpress.XtraBars.BarButtonItem()
        Me.iOpen = New DevExpress.XtraBars.BarButtonItem()
        Me.iClose = New DevExpress.XtraBars.BarButtonItem()
        Me.iFind = New DevExpress.XtraBars.BarButtonItem()
        Me.iSave = New DevExpress.XtraBars.BarButtonItem()
        Me.iSaveAs = New DevExpress.XtraBars.BarButtonItem()
        Me.iCalificacion = New DevExpress.XtraBars.BarButtonItem()
        Me.iClasificacion = New DevExpress.XtraBars.BarButtonItem()
        Me.siStatus = New DevExpress.XtraBars.BarStaticItem()
        Me.siInfo = New DevExpress.XtraBars.BarStaticItem()
        Me.alignButtonGroup = New DevExpress.XtraBars.BarButtonGroup()
        Me.iBoldFontStyle = New DevExpress.XtraBars.BarButtonItem()
        Me.iItalicFontStyle = New DevExpress.XtraBars.BarButtonItem()
        Me.iUnderlinedFontStyle = New DevExpress.XtraBars.BarButtonItem()
        Me.fontStyleButtonGroup = New DevExpress.XtraBars.BarButtonGroup()
        Me.iLeftTextAlign = New DevExpress.XtraBars.BarButtonItem()
        Me.iCenterTextAlign = New DevExpress.XtraBars.BarButtonItem()
        Me.iRightTextAlign = New DevExpress.XtraBars.BarButtonItem()
        Me.rgbiSkins = New DevExpress.XtraBars.RibbonGalleryBarItem()
        Me.Iderechos = New DevExpress.XtraBars.BarButtonItem()
        Me.IDelegaciones = New DevExpress.XtraBars.BarButtonItem()
        Me.IDiarios = New DevExpress.XtraBars.BarButtonItem()
        Me.IIntereses = New DevExpress.XtraBars.BarButtonItem()
        Me.ITipoExpediente = New DevExpress.XtraBars.BarButtonItem()
        Me.IInteresesOpcionesCalculo = New DevExpress.XtraBars.BarButtonItem()
        Me.IPaisesProvinciasPoblaciones = New DevExpress.XtraBars.BarButtonItem()
        Me.ILeyes = New DevExpress.XtraBars.BarButtonItem()
        Me.IUsuarios = New DevExpress.XtraBars.BarButtonItem()
        Me.IRepresentacion = New DevExpress.XtraBars.BarButtonItem()
        Me.IAfecciones = New DevExpress.XtraBars.BarButtonItem()
        Me.ICultivos = New DevExpress.XtraBars.BarButtonItem()
        Me.rgbOrganismos = New DevExpress.XtraBars.RibbonGalleryBarItem()
        Me.ImageCollection2 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.iFincas = New DevExpress.XtraBars.BarButtonItem()
        Me.iTitulares = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem4 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem5 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem6 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.MunicipiosButtonGroup = New DevExpress.XtraBars.BarButtonGroup()
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem7 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem8 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem9 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem10 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonGroup1 = New DevExpress.XtraBars.BarButtonGroup()
        Me.BarButtonGroup2 = New DevExpress.XtraBars.BarButtonGroup()
        Me.BarButtonGroup3 = New DevExpress.XtraBars.BarButtonGroup()
        Me.BarButtonGroup4 = New DevExpress.XtraBars.BarButtonGroup()
        Me.BarButtonGroup5 = New DevExpress.XtraBars.BarButtonGroup()
        Me.IClientes = New DevExpress.XtraBars.BarButtonItem()
        Me.IInmuebles = New DevExpress.XtraBars.BarButtonItem()
        Me.IAlarmas = New DevExpress.XtraBars.BarButtonItem()
        Me.BarCheckItem1 = New DevExpress.XtraBars.BarCheckItem()
        Me.BarCheckItem2 = New DevExpress.XtraBars.BarCheckItem()
        Me.BarButtonItem14 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem15 = New DevExpress.XtraBars.BarButtonItem()
        Me.ITextosEnvios = New DevExpress.XtraBars.BarButtonItem()
        Me.IEmpleados = New DevExpress.XtraBars.BarButtonItem()
        Me.IConfiguracionEmpresas = New DevExpress.XtraBars.BarButtonItem()
        Me.IFormasPago = New DevExpress.XtraBars.BarButtonItem()
        Me.IAgrupaciones = New DevExpress.XtraBars.BarButtonItem()
        Me.IAlmacenes = New DevExpress.XtraBars.BarButtonItem()
        Me.IFabricantes = New DevExpress.XtraBars.BarButtonItem()
        Me.IFamilias = New DevExpress.XtraBars.BarButtonItem()
        Me.ISubFamilias = New DevExpress.XtraBars.BarButtonItem()
        Me.IGamas = New DevExpress.XtraBars.BarButtonItem()
        Me.IMarcas = New DevExpress.XtraBars.BarButtonItem()
        Me.INacionalidades = New DevExpress.XtraBars.BarButtonItem()
        Me.ISeriesFacturacion = New DevExpress.XtraBars.BarButtonItem()
        Me.ITarifas = New DevExpress.XtraBars.BarButtonItem()
        Me.ITipoIVA = New DevExpress.XtraBars.BarButtonItem()
        Me.IColores = New DevExpress.XtraBars.BarButtonItem()
        Me.IEstilos = New DevExpress.XtraBars.BarButtonItem()
        Me.IPropietarios = New DevExpress.XtraBars.BarButtonItem()
        Me.IEstadisticas = New DevExpress.XtraBars.BarButtonItem()
        Me.IAgrupacion = New DevExpress.XtraBars.BarButtonItem()
        Me.IComoConociste = New DevExpress.XtraBars.BarButtonItem()
        Me.IEstado = New DevExpress.XtraBars.BarButtonItem()
        Me.IOrientacion = New DevExpress.XtraBars.BarButtonItem()
        Me.IPoblacion = New DevExpress.XtraBars.BarButtonItem()
        Me.IProvincias = New DevExpress.XtraBars.BarButtonItem()
        Me.Itipo = New DevExpress.XtraBars.BarButtonItem()
        Me.IZona = New DevExpress.XtraBars.BarButtonItem()
        Me.IEmail = New DevExpress.XtraBars.BarButtonItem()
        Me.IEstadisticasGlobales = New DevExpress.XtraBars.BarButtonItem()
        Me.IListadoLlamadas = New DevExpress.XtraBars.BarButtonItem()
        Me.btnJuntarInmuebles = New DevExpress.XtraBars.BarButtonItem()
        Me.btnFotosPC = New DevExpress.XtraBars.BarButtonItem()
        Me.btnFotosPCBaja = New DevExpress.XtraBars.BarButtonItem()
        Me.IMensajesAPP = New DevExpress.XtraBars.BarButtonItem()
        Me.IUsuariosAPP = New DevExpress.XtraBars.BarButtonItem()
        Me.IEnvioNovedades = New DevExpress.XtraBars.BarButtonItem()
        Me.txtUsuario = New DevExpress.XtraBars.BarStaticItem()
        Me.IConfiguracion = New DevExpress.XtraBars.BarButtonItem()
        Me.IGenerarBDAccess = New DevExpress.XtraBars.BarButtonItem()
        Me.IEnviarDatos = New DevExpress.XtraBars.BarButtonItem()
        Me.IVerEnvios = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem12 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem13 = New DevExpress.XtraBars.BarButtonItem()
        Me.IBBDD = New DevExpress.XtraBars.BarButtonItem()
        Me.IImagenes = New DevExpress.XtraBars.BarButtonItem()
        Me.IPublicarTodosLosInmuebles = New DevExpress.XtraBars.BarButtonItem()
        Me.IConfiguracionPortales = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem16 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem17 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem18 = New DevExpress.XtraBars.BarButtonItem()
        Me.IElegirTipo = New DevExpress.XtraBars.BarButtonItem()
        Me.IElegirTipoVenta = New DevExpress.XtraBars.BarButtonItem()
        Me.IListadoCartel = New DevExpress.XtraBars.BarButtonItem()
        Me.IPrestamos = New DevExpress.XtraBars.BarButtonItem()
        Me.IClientesM = New DevExpress.XtraBars.BarButtonItem()
        Me.IInmueblesM = New DevExpress.XtraBars.BarButtonItem()
        Me.IPropietariosM = New DevExpress.XtraBars.BarButtonItem()
        Me.IPrestamosM = New DevExpress.XtraBars.BarButtonItem()
        Me.IAlarmasM = New DevExpress.XtraBars.BarButtonItem()
        Me.btnContadorOrigen = New DevExpress.XtraBars.BarButtonItem()
        Me.IListadoComoConocio = New DevExpress.XtraBars.BarButtonItem()
        Me.IActualizarWeb = New DevExpress.XtraBars.BarButtonItem()
        Me.btnTipoPrincipalWeb = New DevExpress.XtraBars.BarButtonItem()
        Me.btnWPSubirTodasLasFOTOS = New DevExpress.XtraBars.BarButtonItem()
        Me.btnTipoSecundarioWeb = New DevExpress.XtraBars.BarButtonItem()
        Me.btnTipoVenta = New DevExpress.XtraBars.BarButtonItem()
        Me.btnWP_Otros = New DevExpress.XtraBars.BarButtonItem()
        Me.btnTipos = New DevExpress.XtraBars.BarButtonItem()
        Me.btnWP_Poblaciones = New DevExpress.XtraBars.BarButtonItem()
        Me.ribbonImageCollectionLarge = New DevExpress.Utils.ImageCollection(Me.components)
        Me.pgInicio = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.Salir = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.grVentas = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.pgListados = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.grListados = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.pgPortales = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.grPortales = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.pgMantenimientos = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.grMantenimientos = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.pgControl = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.grControl = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.pgCopiaSeguridad = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rgSincronizacion = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rgCopiaSeguridad = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.TresBits = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RepositoryItemHyperLinkEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.RepositoryItemHyperLinkEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.RepositoryItemPictureEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.RepositoryItemImageEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageEdit()
        Me.ribbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.GalleryControl1 = New DevExpress.XtraBars.Ribbon.GalleryControl()
        Me.GalleryControlClient1 = New DevExpress.XtraBars.Ribbon.GalleryControlClient()
        Me.ImgGeneral = New System.Windows.Forms.ImageList(Me.components)
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.XtraTabbedMdiManager1 = New DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(Me.components)
        Me.PopupControlContainer3 = New DevExpress.XtraBars.PopupControlContainer(Me.components)
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.frRealizandoCopia = New DevExpress.XtraEditors.PanelControl()
        Me.lblPercent = New DevExpress.XtraEditors.LabelControl()
        Me.label17 = New DevExpress.XtraEditors.LabelControl()
        Me.Label18 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.pnlEnviado = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.Panellmagenes = New System.Windows.Forms.Panel()
        Me.picAlarmas = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.picExit = New System.Windows.Forms.PictureBox()
        Me.picPropietarios = New System.Windows.Forms.PictureBox()
        Me.picInmuebles = New System.Windows.Forms.PictureBox()
        Me.picPortales = New System.Windows.Forms.PictureBox()
        Me.picVenaliaApp = New System.Windows.Forms.PictureBox()
        Me.picClientes = New System.Windows.Forms.PictureBox()
        Me.BarButtonItem19 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem20 = New DevExpress.XtraBars.BarButtonItem()
        CType(Me.ribbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.appMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.popupControlContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.popupControlContainer2.SuspendLayout()
        CType(Me.buttonEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.popupControlContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.popupControlContainer1.SuspendLayout()
        CType(Me.ribbonImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ribbonImageCollectionLarge, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemHyperLinkEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemHyperLinkEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemPictureEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GalleryControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GalleryControl1.SuspendLayout()
        CType(Me.XtraTabbedMdiManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupControlContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PopupControlContainer3.SuspendLayout()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.frRealizandoCopia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frRealizandoCopia.SuspendLayout()
        CType(Me.pnlEnviado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEnviado.SuspendLayout()
        Me.Panellmagenes.SuspendLayout()
        CType(Me.picAlarmas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPropietarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picInmuebles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPortales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picVenaliaApp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ribbonControl
        '
        Me.ribbonControl.ApplicationButtonDropDownControl = Me.appMenu
        Me.ribbonControl.ApplicationIcon = CType(resources.GetObject("ribbonControl.ApplicationIcon"), System.Drawing.Bitmap)
        Me.ribbonControl.ExpandCollapseItem.Id = 0
        Me.ribbonControl.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.ribbonControl.Images = Me.ribbonImageCollection
        Me.ribbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.ribbonControl.ExpandCollapseItem, Me.iNew, Me.iOpen, Me.iClose, Me.iFind, Me.iSave, Me.iSaveAs, Me.iExit, Me.iCalificacion, Me.iClasificacion, Me.siStatus, Me.siInfo, Me.alignButtonGroup, Me.iBoldFontStyle, Me.iItalicFontStyle, Me.iUnderlinedFontStyle, Me.fontStyleButtonGroup, Me.iLeftTextAlign, Me.iCenterTextAlign, Me.iRightTextAlign, Me.rgbiSkins, Me.Iderechos, Me.IDelegaciones, Me.IDiarios, Me.IIntereses, Me.ITipoExpediente, Me.IInteresesOpcionesCalculo, Me.IPaisesProvinciasPoblaciones, Me.ILeyes, Me.IUsuarios, Me.IRepresentacion, Me.IAfecciones, Me.ICultivos, Me.rgbOrganismos, Me.iFincas, Me.iTitulares, Me.BarButtonItem4, Me.BarButtonItem5, Me.BarButtonItem6, Me.BarButtonItem2, Me.MunicipiosButtonGroup, Me.BarButtonItem3, Me.BarButtonItem7, Me.BarButtonItem8, Me.BarButtonItem9, Me.BarButtonItem10, Me.BarButtonGroup1, Me.BarButtonGroup2, Me.BarButtonGroup3, Me.BarButtonGroup4, Me.BarButtonGroup5, Me.IClientes, Me.IInmuebles, Me.IAlarmas, Me.BarCheckItem1, Me.BarCheckItem2, Me.BarButtonItem14, Me.BarButtonItem15, Me.ITextosEnvios, Me.IEmpleados, Me.IConfiguracionEmpresas, Me.IFormasPago, Me.IAgrupaciones, Me.IAlmacenes, Me.IFabricantes, Me.IFamilias, Me.ISubFamilias, Me.IGamas, Me.IMarcas, Me.INacionalidades, Me.ISeriesFacturacion, Me.ITarifas, Me.ITipoIVA, Me.IColores, Me.IEstilos, Me.IPropietarios, Me.IEstadisticas, Me.IAgrupacion, Me.IComoConociste, Me.IEstado, Me.IOrientacion, Me.IPoblacion, Me.IProvincias, Me.Itipo, Me.IZona, Me.IEmail, Me.IEstadisticasGlobales, Me.IListadoLlamadas, Me.btnJuntarInmuebles, Me.btnFotosPC, Me.btnFotosPCBaja, Me.IMensajesAPP, Me.IUsuariosAPP, Me.IEnvioNovedades, Me.txtUsuario, Me.IConfiguracion, Me.IGenerarBDAccess, Me.IEnviarDatos, Me.IVerEnvios, Me.BarButtonItem12, Me.BarButtonItem13, Me.IBBDD, Me.IImagenes, Me.IPublicarTodosLosInmuebles, Me.IConfiguracionPortales, Me.BarButtonItem16, Me.BarButtonItem17, Me.BarButtonItem18, Me.IElegirTipo, Me.IElegirTipoVenta, Me.IListadoCartel, Me.IPrestamos, Me.IClientesM, Me.IInmueblesM, Me.IPropietariosM, Me.IPrestamosM, Me.IAlarmasM, Me.btnContadorOrigen, Me.IListadoComoConocio, Me.IActualizarWeb, Me.btnTipoPrincipalWeb, Me.btnWPSubirTodasLasFOTOS, Me.btnTipoSecundarioWeb, Me.btnTipoVenta, Me.btnWP_Otros, Me.btnTipos, Me.btnWP_Poblaciones})
        Me.ribbonControl.LargeImages = Me.ribbonImageCollectionLarge
        Me.ribbonControl.Location = New System.Drawing.Point(0, 0)
        Me.ribbonControl.MaxItemId = 204
        Me.ribbonControl.Name = "ribbonControl"
        Me.ribbonControl.PageHeaderItemLinks.Add(Me.txtUsuario)
        Me.ribbonControl.PageHeaderItemLinks.Add(Me.ribbonControl.ExpandCollapseItem)
        Me.ribbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.pgInicio, Me.pgListados, Me.pgPortales, Me.pgMantenimientos, Me.pgControl, Me.pgCopiaSeguridad, Me.TresBits})
        Me.ribbonControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemHyperLinkEdit1, Me.RepositoryItemHyperLinkEdit2, Me.RepositoryItemPictureEdit1, Me.RepositoryItemImageEdit1})
        Me.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.MacOffice
        Me.ribbonControl.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.[True]
        Me.ribbonControl.ShowToolbarCustomizeItem = False
        Me.ribbonControl.Size = New System.Drawing.Size(1262, 143)
        Me.ribbonControl.StatusBar = Me.ribbonStatusBar
        Me.ribbonControl.Toolbar.ItemLinks.Add(Me.iSave)
        Me.ribbonControl.Toolbar.ItemLinks.Add(Me.iSaveAs)
        Me.ribbonControl.Toolbar.ItemLinks.Add(Me.iCalificacion)
        Me.ribbonControl.Toolbar.ItemLinks.Add(Me.IClientesM)
        Me.ribbonControl.Toolbar.ItemLinks.Add(Me.IInmueblesM)
        Me.ribbonControl.Toolbar.ItemLinks.Add(Me.IPropietariosM)
        Me.ribbonControl.Toolbar.ItemLinks.Add(Me.IAlarmasM)
        Me.ribbonControl.Toolbar.ItemLinks.Add(Me.IPrestamosM)
        Me.ribbonControl.Toolbar.ShowCustomizeItem = False
        '
        'appMenu
        '
        Me.appMenu.BottomPaneControlContainer = Me.popupControlContainer2
        Me.appMenu.ItemLinks.Add(Me.BarButtonItem11)
        Me.appMenu.ItemLinks.Add(Me.iExit)
        Me.appMenu.MenuAppearance.AppearanceMenu.Normal.Options.UseTextOptions = True
        Me.appMenu.MenuAppearance.AppearanceMenu.Normal.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.appMenu.MenuAppearance.MenuBar.Options.UseTextOptions = True
        Me.appMenu.MenuAppearance.MenuBar.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.appMenu.Name = "appMenu"
        Me.appMenu.Ribbon = Me.ribbonControl
        Me.appMenu.RightPaneControlContainer = Me.popupControlContainer1
        '
        'popupControlContainer2
        '
        Me.popupControlContainer2.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.popupControlContainer2.Appearance.Options.UseBackColor = True
        Me.popupControlContainer2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.popupControlContainer2.Controls.Add(Me.buttonEdit)
        Me.popupControlContainer2.Location = New System.Drawing.Point(238, 289)
        Me.popupControlContainer2.Name = "popupControlContainer2"
        Me.popupControlContainer2.Ribbon = Me.ribbonControl
        Me.popupControlContainer2.Size = New System.Drawing.Size(118, 28)
        Me.popupControlContainer2.TabIndex = 7
        Me.popupControlContainer2.Visible = False
        '
        'buttonEdit
        '
        Me.buttonEdit.EditValue = "Some Text"
        Me.buttonEdit.Location = New System.Drawing.Point(3, 5)
        Me.buttonEdit.MenuManager = Me.ribbonControl
        Me.buttonEdit.Name = "buttonEdit"
        Me.buttonEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.buttonEdit.Size = New System.Drawing.Size(100, 20)
        Me.buttonEdit.TabIndex = 0
        Me.buttonEdit.Visible = False
        '
        'BarButtonItem11
        '
        Me.BarButtonItem11.Caption = "Estadisticas"
        Me.BarButtonItem11.Id = 145
        Me.BarButtonItem11.ImageIndex = 20
        Me.BarButtonItem11.LargeImageIndex = 29
        Me.BarButtonItem11.Name = "BarButtonItem11"
        '
        'iExit
        '
        Me.iExit.Caption = "Salir"
        Me.iExit.Description = "Finaliza la aplicación"
        Me.iExit.Id = 20
        Me.iExit.LargeGlyph = Global.My.Resources.Resources.desconexion_de_salida_icono_7025_641
        Me.iExit.Name = "iExit"
        '
        'popupControlContainer1
        '
        Me.popupControlContainer1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.popupControlContainer1.Appearance.Options.UseBackColor = True
        Me.popupControlContainer1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.popupControlContainer1.Controls.Add(Me.someLabelControl2)
        Me.popupControlContainer1.Controls.Add(Me.someLabelControl1)
        Me.popupControlContainer1.Location = New System.Drawing.Point(111, 197)
        Me.popupControlContainer1.Name = "popupControlContainer1"
        Me.popupControlContainer1.Ribbon = Me.ribbonControl
        Me.popupControlContainer1.Size = New System.Drawing.Size(76, 70)
        Me.popupControlContainer1.TabIndex = 6
        Me.popupControlContainer1.Visible = False
        '
        'someLabelControl2
        '
        Me.someLabelControl2.AllowHtmlString = True
        Me.someLabelControl2.Location = New System.Drawing.Point(3, 57)
        Me.someLabelControl2.Name = "someLabelControl2"
        Me.someLabelControl2.Size = New System.Drawing.Size(64, 13)
        Me.someLabelControl2.TabIndex = 0
        Me.someLabelControl2.Text = "<b><color=Black><b><color=Black>Some Info </b></color> </b></color>"
        '
        'someLabelControl1
        '
        Me.someLabelControl1.AllowHtmlString = True
        Me.someLabelControl1.Location = New System.Drawing.Point(3, 3)
        Me.someLabelControl1.Name = "someLabelControl1"
        Me.someLabelControl1.Size = New System.Drawing.Size(64, 13)
        Me.someLabelControl1.TabIndex = 0
        Me.someLabelControl1.Text = "<b><color=Black><b><color=Black>Some Info </b></color> </b></color>"
        '
        'ribbonImageCollection
        '
        Me.ribbonImageCollection.ImageStream = CType(resources.GetObject("ribbonImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ribbonImageCollection.Images.SetKeyName(0, "Ribbon_New_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(1, "Ribbon_Open_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(2, "Ribbon_Close_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(3, "Ribbon_Find_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(4, "Ribbon_Save_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(5, "Ribbon_SaveAs_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(6, "Ribbon_Exit_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(7, "Ribbon_Content_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(8, "Ribbon_Info_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(9, "Ribbon_Bold_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(10, "Ribbon_Italic_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(11, "Ribbon_Underline_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(12, "Ribbon_AlignLeft_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(13, "Ribbon_AlignCenter_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(14, "Ribbon_AlignRight_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(15, "Ribbon_Card4_16x16.png")
        Me.ribbonImageCollection.Images.SetKeyName(16, "DiputacionValencia.jpg")
        Me.ribbonImageCollection.Images.SetKeyName(17, "dipu2.png")
        Me.ribbonImageCollection.Images.SetKeyName(18, "Barcode.png")
        Me.ribbonImageCollection.Images.SetKeyName(19, "Barcode.jpeg")
        Me.ribbonImageCollection.Images.SetKeyName(20, "Estadisticas.png")
        Me.ribbonImageCollection.Images.SetKeyName(21, "Agrupar.png")
        Me.ribbonImageCollection.Images.SetKeyName(22, "Buscar.png")
        Me.ribbonImageCollection.Images.SetKeyName(23, "Estado.png")
        Me.ribbonImageCollection.Images.SetKeyName(24, "orientacion.png")
        Me.ribbonImageCollection.Images.SetKeyName(25, "poblacion.png")
        Me.ribbonImageCollection.Images.SetKeyName(26, "provincia.png")
        Me.ribbonImageCollection.Images.SetKeyName(27, "TipoCasa.png")
        Me.ribbonImageCollection.Images.SetKeyName(28, "zona.png")
        Me.ribbonImageCollection.Images.SetKeyName(29, "ListadoLlamadas.png")
        Me.ribbonImageCollection.Images.SetKeyName(30, "Clientes32x32.png")
        Me.ribbonImageCollection.Images.SetKeyName(31, "prestamos.png")
        Me.ribbonImageCollection.Images.SetKeyName(32, "Inmuebles32x32.png")
        Me.ribbonImageCollection.Images.SetKeyName(33, "DatosPropietarios.png")
        Me.ribbonImageCollection.Images.SetKeyName(34, "Alarm-Clock.png")
        Me.ribbonImageCollection.Images.SetKeyName(35, "Clientes.png")
        '
        'iNew
        '
        Me.iNew.Caption = "New"
        Me.iNew.Description = "Creates a new, blank file."
        Me.iNew.Hint = "Creates a new, blank file"
        Me.iNew.Id = 1
        Me.iNew.ImageIndex = 0
        Me.iNew.LargeImageIndex = 0
        Me.iNew.Name = "iNew"
        Me.iNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'iOpen
        '
        Me.iOpen.Caption = "&Open"
        Me.iOpen.Description = "Opens a file."
        Me.iOpen.Hint = "Opens a file"
        Me.iOpen.Id = 2
        Me.iOpen.ImageIndex = 1
        Me.iOpen.LargeImageIndex = 1
        Me.iOpen.Name = "iOpen"
        Me.iOpen.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        Me.iOpen.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'iClose
        '
        Me.iClose.Caption = "&Close"
        Me.iClose.Description = "Closes the active document."
        Me.iClose.Hint = "Closes the active document"
        Me.iClose.Id = 3
        Me.iClose.ImageIndex = 2
        Me.iClose.LargeImageIndex = 2
        Me.iClose.Name = "iClose"
        Me.iClose.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'iFind
        '
        Me.iFind.Caption = "Find"
        Me.iFind.Description = "Searches for the specified info."
        Me.iFind.Hint = "Searches for the specified info"
        Me.iFind.Id = 15
        Me.iFind.ImageIndex = 3
        Me.iFind.LargeImageIndex = 3
        Me.iFind.Name = "iFind"
        Me.iFind.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'iSave
        '
        Me.iSave.Caption = "&Save"
        Me.iSave.Description = "Saves the active document."
        Me.iSave.Hint = "Saves the active document"
        Me.iSave.Id = 16
        Me.iSave.ImageIndex = 4
        Me.iSave.LargeImageIndex = 4
        Me.iSave.Name = "iSave"
        Me.iSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'iSaveAs
        '
        Me.iSaveAs.Caption = "Save As"
        Me.iSaveAs.Description = "Saves the active document in a different location."
        Me.iSaveAs.Hint = "Saves the active document in a different location"
        Me.iSaveAs.Id = 17
        Me.iSaveAs.ImageIndex = 5
        Me.iSaveAs.LargeImageIndex = 5
        Me.iSaveAs.Name = "iSaveAs"
        Me.iSaveAs.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'iCalificacion
        '
        Me.iCalificacion.Caption = "Calificación"
        Me.iCalificacion.Description = "Start the program help system."
        Me.iCalificacion.Hint = "Start the program help system"
        Me.iCalificacion.Id = 22
        Me.iCalificacion.ImageIndex = 7
        Me.iCalificacion.LargeImageIndex = 7
        Me.iCalificacion.Name = "iCalificacion"
        Me.iCalificacion.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'iClasificacion
        '
        Me.iClasificacion.Caption = "Clasificación"
        Me.iClasificacion.Description = "Displays general program information."
        Me.iClasificacion.Hint = "Displays general program information"
        Me.iClasificacion.Id = 24
        Me.iClasificacion.ImageIndex = 7
        Me.iClasificacion.LargeImageIndex = 7
        Me.iClasificacion.Name = "iClasificacion"
        Me.iClasificacion.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'siStatus
        '
        Me.siStatus.Id = 31
        Me.siStatus.Name = "siStatus"
        Me.siStatus.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'siInfo
        '
        Me.siInfo.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.siInfo.Id = 32
        Me.siInfo.ItemAppearance.Normal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.siInfo.ItemAppearance.Normal.ForeColor = System.Drawing.Color.DarkRed
        Me.siInfo.ItemAppearance.Normal.Options.UseFont = True
        Me.siInfo.ItemAppearance.Normal.Options.UseForeColor = True
        Me.siInfo.Name = "siInfo"
        Me.siInfo.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'alignButtonGroup
        '
        Me.alignButtonGroup.Caption = "Align Commands"
        Me.alignButtonGroup.Id = 52
        Me.alignButtonGroup.ItemLinks.Add(Me.iBoldFontStyle)
        Me.alignButtonGroup.ItemLinks.Add(Me.iItalicFontStyle)
        Me.alignButtonGroup.ItemLinks.Add(Me.iUnderlinedFontStyle)
        Me.alignButtonGroup.Name = "alignButtonGroup"
        '
        'iBoldFontStyle
        '
        Me.iBoldFontStyle.Caption = "Bold"
        Me.iBoldFontStyle.Id = 53
        Me.iBoldFontStyle.ImageIndex = 9
        Me.iBoldFontStyle.Name = "iBoldFontStyle"
        '
        'iItalicFontStyle
        '
        Me.iItalicFontStyle.Caption = "Italic"
        Me.iItalicFontStyle.Id = 54
        Me.iItalicFontStyle.ImageIndex = 10
        Me.iItalicFontStyle.Name = "iItalicFontStyle"
        '
        'iUnderlinedFontStyle
        '
        Me.iUnderlinedFontStyle.Caption = "Underlined"
        Me.iUnderlinedFontStyle.Id = 55
        Me.iUnderlinedFontStyle.ImageIndex = 11
        Me.iUnderlinedFontStyle.Name = "iUnderlinedFontStyle"
        '
        'fontStyleButtonGroup
        '
        Me.fontStyleButtonGroup.Caption = "Font Style"
        Me.fontStyleButtonGroup.Id = 56
        Me.fontStyleButtonGroup.ItemLinks.Add(Me.iLeftTextAlign)
        Me.fontStyleButtonGroup.ItemLinks.Add(Me.iCenterTextAlign)
        Me.fontStyleButtonGroup.ItemLinks.Add(Me.iRightTextAlign)
        Me.fontStyleButtonGroup.Name = "fontStyleButtonGroup"
        '
        'iLeftTextAlign
        '
        Me.iLeftTextAlign.Caption = "Left"
        Me.iLeftTextAlign.Id = 57
        Me.iLeftTextAlign.ImageIndex = 12
        Me.iLeftTextAlign.Name = "iLeftTextAlign"
        '
        'iCenterTextAlign
        '
        Me.iCenterTextAlign.Caption = "Center"
        Me.iCenterTextAlign.Id = 58
        Me.iCenterTextAlign.ImageIndex = 13
        Me.iCenterTextAlign.Name = "iCenterTextAlign"
        '
        'iRightTextAlign
        '
        Me.iRightTextAlign.Caption = "Right"
        Me.iRightTextAlign.Id = 59
        Me.iRightTextAlign.ImageIndex = 14
        Me.iRightTextAlign.Name = "iRightTextAlign"
        '
        'rgbiSkins
        '
        Me.rgbiSkins.Caption = "Skins"
        '
        '
        '
        Me.rgbiSkins.Gallery.AllowHoverImages = True
        Me.rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseFont = True
        Me.rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseTextOptions = True
        Me.rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Normal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.rgbiSkins.Gallery.ColumnCount = 4
        Me.rgbiSkins.Gallery.FixedHoverImageSize = False
        Me.rgbiSkins.Gallery.ImageSize = New System.Drawing.Size(32, 17)
        Me.rgbiSkins.Gallery.ItemImageLocation = DevExpress.Utils.Locations.Top
        Me.rgbiSkins.Gallery.RowCount = 4
        Me.rgbiSkins.Id = 60
        Me.rgbiSkins.Name = "rgbiSkins"
        '
        'Iderechos
        '
        Me.Iderechos.Caption = "Derechos"
        Me.Iderechos.Id = 62
        Me.Iderechos.ImageIndex = 7
        Me.Iderechos.LargeImageIndex = 7
        Me.Iderechos.Name = "Iderechos"
        '
        'IDelegaciones
        '
        Me.IDelegaciones.Caption = "Delegaciones"
        Me.IDelegaciones.Id = 64
        Me.IDelegaciones.ImageIndex = 7
        Me.IDelegaciones.LargeImageIndex = 7
        Me.IDelegaciones.Name = "IDelegaciones"
        '
        'IDiarios
        '
        Me.IDiarios.Caption = "Diarios"
        Me.IDiarios.Id = 65
        Me.IDiarios.ImageIndex = 7
        Me.IDiarios.LargeImageIndex = 7
        Me.IDiarios.Name = "IDiarios"
        '
        'IIntereses
        '
        Me.IIntereses.Caption = "Intereses"
        Me.IIntereses.Id = 66
        Me.IIntereses.ImageIndex = 7
        Me.IIntereses.LargeImageIndex = 7
        Me.IIntereses.Name = "IIntereses"
        '
        'ITipoExpediente
        '
        Me.ITipoExpediente.Caption = "Tipo Expediente"
        Me.ITipoExpediente.Id = 67
        Me.ITipoExpediente.ImageIndex = 7
        Me.ITipoExpediente.LargeImageIndex = 7
        Me.ITipoExpediente.Name = "ITipoExpediente"
        '
        'IInteresesOpcionesCalculo
        '
        Me.IInteresesOpcionesCalculo.Caption = "Opciones Cálculo Intereses"
        Me.IInteresesOpcionesCalculo.Id = 68
        Me.IInteresesOpcionesCalculo.ImageIndex = 7
        Me.IInteresesOpcionesCalculo.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A))
        Me.IInteresesOpcionesCalculo.LargeImageIndex = 7
        Me.IInteresesOpcionesCalculo.Name = "IInteresesOpcionesCalculo"
        '
        'IPaisesProvinciasPoblaciones
        '
        Me.IPaisesProvinciasPoblaciones.Caption = "Paises" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Provincias" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "-Poblaciones"
        Me.IPaisesProvinciasPoblaciones.Id = 69
        Me.IPaisesProvinciasPoblaciones.ImageIndex = 7
        Me.IPaisesProvinciasPoblaciones.LargeImageIndex = 7
        Me.IPaisesProvinciasPoblaciones.Name = "IPaisesProvinciasPoblaciones"
        '
        'ILeyes
        '
        Me.ILeyes.Caption = "Leyes"
        Me.ILeyes.Id = 70
        Me.ILeyes.ImageIndex = 7
        Me.ILeyes.LargeImageIndex = 7
        Me.ILeyes.Name = "ILeyes"
        '
        'IUsuarios
        '
        Me.IUsuarios.Caption = "Usuarios"
        Me.IUsuarios.Id = 71
        Me.IUsuarios.ImageIndex = 7
        Me.IUsuarios.LargeImageIndex = 7
        Me.IUsuarios.Name = "IUsuarios"
        '
        'IRepresentacion
        '
        Me.IRepresentacion.Caption = "Representacion"
        Me.IRepresentacion.Id = 72
        Me.IRepresentacion.Name = "IRepresentacion"
        '
        'IAfecciones
        '
        Me.IAfecciones.Caption = "Afecciones"
        Me.IAfecciones.Id = 73
        Me.IAfecciones.ImageIndex = 15
        Me.IAfecciones.LargeImageIndex = 9
        Me.IAfecciones.Name = "IAfecciones"
        '
        'ICultivos
        '
        Me.ICultivos.Caption = "Cultivos"
        Me.ICultivos.Id = 74
        Me.ICultivos.ImageIndex = 15
        Me.ICultivos.LargeImageIndex = 9
        Me.ICultivos.Name = "ICultivos"
        '
        'rgbOrganismos
        '
        Me.rgbOrganismos.Caption = "Organismos"
        Me.rgbOrganismos.Description = "Seleccione un organismo"
        '
        '
        '
        Me.rgbOrganismos.Gallery.AllowHoverImages = True
        Me.rgbOrganismos.Gallery.HoverImages = Me.ImageCollection2
        Me.rgbOrganismos.Gallery.Images = Me.ImageCollection1
        Me.rgbOrganismos.Id = 91
        Me.rgbOrganismos.Name = "rgbOrganismos"
        '
        'ImageCollection2
        '
        Me.ImageCollection2.ImageSize = New System.Drawing.Size(180, 65)
        Me.ImageCollection2.ImageStream = CType(resources.GetObject("ImageCollection2.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection2.Images.SetKeyName(0, "MinisterioFomento.png")
        Me.ImageCollection2.Images.SetKeyName(1, "DiputacionValencia.png")
        Me.ImageCollection2.Images.SetKeyName(2, "prestamos.png")
        '
        'ImageCollection1
        '
        Me.ImageCollection1.ImageSize = New System.Drawing.Size(128, 56)
        Me.ImageCollection1.ImageStream = CType(resources.GetObject("ImageCollection1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection1.Images.SetKeyName(0, "MinisterioFomento.png")
        Me.ImageCollection1.Images.SetKeyName(1, "DiputacionValencia.png")
        '
        'iFincas
        '
        Me.iFincas.Caption = "Fincas"
        Me.iFincas.Id = 96
        Me.iFincas.Name = "iFincas"
        '
        'iTitulares
        '
        Me.iTitulares.Caption = "Titulares"
        Me.iTitulares.Id = 97
        Me.iTitulares.Name = "iTitulares"
        '
        'BarButtonItem4
        '
        Me.BarButtonItem4.Caption = "BarButtonItem4"
        Me.BarButtonItem4.Id = 98
        Me.BarButtonItem4.Name = "BarButtonItem4"
        '
        'BarButtonItem5
        '
        Me.BarButtonItem5.Caption = "BarButtonItem5"
        Me.BarButtonItem5.Id = 99
        Me.BarButtonItem5.Name = "BarButtonItem5"
        '
        'BarButtonItem6
        '
        Me.BarButtonItem6.Caption = "BarButtonItem6"
        Me.BarButtonItem6.Id = 100
        Me.BarButtonItem6.Name = "BarButtonItem6"
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "BarButtonItem2"
        Me.BarButtonItem2.Id = 104
        Me.BarButtonItem2.Name = "BarButtonItem2"
        '
        'MunicipiosButtonGroup
        '
        Me.MunicipiosButtonGroup.Caption = "MunicipiosButtonGroup"
        Me.MunicipiosButtonGroup.Id = 107
        Me.MunicipiosButtonGroup.LargeImageIndex = 7
        Me.MunicipiosButtonGroup.LargeImageIndexDisabled = 7
        Me.MunicipiosButtonGroup.Name = "MunicipiosButtonGroup"
        '
        'BarButtonItem3
        '
        Me.BarButtonItem3.Caption = "BarButtonItem3"
        Me.BarButtonItem3.Id = 108
        Me.BarButtonItem3.Name = "BarButtonItem3"
        '
        'BarButtonItem7
        '
        Me.BarButtonItem7.Caption = "BarButtonItem7"
        Me.BarButtonItem7.Id = 109
        Me.BarButtonItem7.Name = "BarButtonItem7"
        '
        'BarButtonItem8
        '
        Me.BarButtonItem8.Caption = "BarButtonItem8"
        Me.BarButtonItem8.Id = 110
        Me.BarButtonItem8.Name = "BarButtonItem8"
        '
        'BarButtonItem9
        '
        Me.BarButtonItem9.Caption = "BarButtonItem9"
        Me.BarButtonItem9.Id = 111
        Me.BarButtonItem9.Name = "BarButtonItem9"
        '
        'BarButtonItem10
        '
        Me.BarButtonItem10.Caption = "BarButtonItem10"
        Me.BarButtonItem10.Id = 112
        Me.BarButtonItem10.Name = "BarButtonItem10"
        '
        'BarButtonGroup1
        '
        Me.BarButtonGroup1.Caption = "BarButtonGroup1"
        Me.BarButtonGroup1.Id = 113
        Me.BarButtonGroup1.Name = "BarButtonGroup1"
        '
        'BarButtonGroup2
        '
        Me.BarButtonGroup2.Caption = "BarButtonGroup2"
        Me.BarButtonGroup2.Id = 114
        Me.BarButtonGroup2.Name = "BarButtonGroup2"
        '
        'BarButtonGroup3
        '
        Me.BarButtonGroup3.Caption = "BarButtonGroup3"
        Me.BarButtonGroup3.Id = 115
        Me.BarButtonGroup3.Name = "BarButtonGroup3"
        '
        'BarButtonGroup4
        '
        Me.BarButtonGroup4.Caption = "BarButtonGroup4"
        Me.BarButtonGroup4.Id = 116
        Me.BarButtonGroup4.Name = "BarButtonGroup4"
        '
        'BarButtonGroup5
        '
        Me.BarButtonGroup5.Caption = "BarButtonGroup5"
        Me.BarButtonGroup5.Id = 117
        Me.BarButtonGroup5.Name = "BarButtonGroup5"
        '
        'IClientes
        '
        Me.IClientes.Caption = "Clientes"
        Me.IClientes.Id = 118
        Me.IClientes.ImageIndex = 12
        Me.IClientes.LargeImageIndex = 12
        Me.IClientes.Name = "IClientes"
        Me.IClientes.Tag = "Clientes"
        '
        'IInmuebles
        '
        Me.IInmuebles.Caption = "Inmuebles"
        Me.IInmuebles.Id = 119
        Me.IInmuebles.ImageIndex = 18
        Me.IInmuebles.LargeGlyph = Global.My.Resources.Resources.Inmuebles32x32
        Me.IInmuebles.Name = "IInmuebles"
        Me.IInmuebles.Tag = "Inmuebles"
        '
        'IAlarmas
        '
        Me.IAlarmas.Caption = "Alarmas"
        Me.IAlarmas.Id = 120
        Me.IAlarmas.LargeImageIndex = 17
        Me.IAlarmas.Name = "IAlarmas"
        Me.IAlarmas.Tag = "Alarmas"
        '
        'BarCheckItem1
        '
        Me.BarCheckItem1.Caption = "BarCheckItem1"
        Me.BarCheckItem1.Id = 121
        Me.BarCheckItem1.Name = "BarCheckItem1"
        '
        'BarCheckItem2
        '
        Me.BarCheckItem2.Caption = "BarCheckItem2"
        Me.BarCheckItem2.Id = 122
        Me.BarCheckItem2.Name = "BarCheckItem2"
        '
        'BarButtonItem14
        '
        Me.BarButtonItem14.Caption = "BarButtonItem14"
        Me.BarButtonItem14.Id = 123
        Me.BarButtonItem14.Name = "BarButtonItem14"
        '
        'BarButtonItem15
        '
        Me.BarButtonItem15.Caption = "BarButtonItem15"
        Me.BarButtonItem15.Id = 124
        Me.BarButtonItem15.Name = "BarButtonItem15"
        '
        'ITextosEnvios
        '
        Me.ITextosEnvios.Caption = "Texto Envios"
        Me.ITextosEnvios.Id = 125
        Me.ITextosEnvios.LargeGlyph = CType(resources.GetObject("ITextosEnvios.LargeGlyph"), System.Drawing.Image)
        Me.ITextosEnvios.LargeImageIndex = 27
        Me.ITextosEnvios.Name = "ITextosEnvios"
        Me.ITextosEnvios.Tag = "TextosEnvios"
        '
        'IEmpleados
        '
        Me.IEmpleados.Caption = "Empleados"
        Me.IEmpleados.Id = 127
        Me.IEmpleados.LargeImageIndex = 16
        Me.IEmpleados.Name = "IEmpleados"
        Me.IEmpleados.Tag = "Empleados"
        '
        'IConfiguracionEmpresas
        '
        Me.IConfiguracionEmpresas.Caption = "Empresa"
        Me.IConfiguracionEmpresas.Id = 128
        Me.IConfiguracionEmpresas.LargeImageIndex = 25
        Me.IConfiguracionEmpresas.Name = "IConfiguracionEmpresas"
        Me.IConfiguracionEmpresas.Tag = "Configuracion Empresas"
        '
        'IFormasPago
        '
        Me.IFormasPago.Caption = "Formas Pago"
        Me.IFormasPago.Id = 129
        Me.IFormasPago.Name = "IFormasPago"
        Me.IFormasPago.Tag = "FormasPago"
        '
        'IAgrupaciones
        '
        Me.IAgrupaciones.Caption = "Agrupaciones"
        Me.IAgrupaciones.Id = 130
        Me.IAgrupaciones.Name = "IAgrupaciones"
        Me.IAgrupaciones.Tag = "Agrupaciones"
        '
        'IAlmacenes
        '
        Me.IAlmacenes.Caption = "Almacenes"
        Me.IAlmacenes.Id = 131
        Me.IAlmacenes.Name = "IAlmacenes"
        Me.IAlmacenes.Tag = "Almacenes"
        '
        'IFabricantes
        '
        Me.IFabricantes.Caption = "Fabricantes"
        Me.IFabricantes.Id = 132
        Me.IFabricantes.Name = "IFabricantes"
        Me.IFabricantes.Tag = "Fabricantes"
        '
        'IFamilias
        '
        Me.IFamilias.Caption = "Familias"
        Me.IFamilias.Id = 133
        Me.IFamilias.Name = "IFamilias"
        Me.IFamilias.Tag = "Familias"
        '
        'ISubFamilias
        '
        Me.ISubFamilias.Caption = "SubFamilias"
        Me.ISubFamilias.Id = 134
        Me.ISubFamilias.Name = "ISubFamilias"
        Me.ISubFamilias.Tag = "SubFamilias"
        '
        'IGamas
        '
        Me.IGamas.Caption = "Gamas"
        Me.IGamas.Id = 135
        Me.IGamas.Name = "IGamas"
        Me.IGamas.Tag = "Gamas"
        '
        'IMarcas
        '
        Me.IMarcas.Caption = "Marcas"
        Me.IMarcas.Id = 136
        Me.IMarcas.Name = "IMarcas"
        Me.IMarcas.Tag = "Marcas"
        '
        'INacionalidades
        '
        Me.INacionalidades.Caption = "Nacionalidades"
        Me.INacionalidades.Id = 137
        Me.INacionalidades.Name = "INacionalidades"
        Me.INacionalidades.Tag = "Nacionalidades"
        '
        'ISeriesFacturacion
        '
        Me.ISeriesFacturacion.Caption = "Series Facturacion"
        Me.ISeriesFacturacion.Id = 138
        Me.ISeriesFacturacion.Name = "ISeriesFacturacion"
        Me.ISeriesFacturacion.Tag = "SeriesFacturacion"
        '
        'ITarifas
        '
        Me.ITarifas.Caption = "Tarifas"
        Me.ITarifas.Id = 139
        Me.ITarifas.Name = "ITarifas"
        Me.ITarifas.Tag = "Tarifas"
        '
        'ITipoIVA
        '
        Me.ITipoIVA.Caption = "Tipos de IVA"
        Me.ITipoIVA.Id = 140
        Me.ITipoIVA.Name = "ITipoIVA"
        Me.ITipoIVA.Tag = "TipoIVA"
        '
        'IColores
        '
        Me.IColores.Caption = "Colores"
        Me.IColores.Id = 142
        Me.IColores.Name = "IColores"
        Me.IColores.Tag = "Colores"
        '
        'IEstilos
        '
        Me.IEstilos.Caption = "Estilos"
        Me.IEstilos.Id = 143
        Me.IEstilos.LargeImageIndex = 26
        Me.IEstilos.Name = "IEstilos"
        '
        'IPropietarios
        '
        Me.IPropietarios.Caption = "Propietarios"
        Me.IPropietarios.Id = 144
        Me.IPropietarios.LargeImageIndex = 23
        Me.IPropietarios.Name = "IPropietarios"
        Me.IPropietarios.Tag = "Propietarios"
        '
        'IEstadisticas
        '
        Me.IEstadisticas.Caption = "Empleado"
        Me.IEstadisticas.Id = 145
        Me.IEstadisticas.ImageIndex = 20
        Me.IEstadisticas.LargeImageIndex = 29
        Me.IEstadisticas.Name = "IEstadisticas"
        '
        'IAgrupacion
        '
        Me.IAgrupacion.Caption = "Agrupaciones"
        Me.IAgrupacion.Id = 146
        Me.IAgrupacion.LargeImageIndex = 30
        Me.IAgrupacion.Name = "IAgrupacion"
        Me.IAgrupacion.Tag = "Agrupaciones"
        '
        'IComoConociste
        '
        Me.IComoConociste.Caption = "Conociste"
        Me.IComoConociste.Id = 147
        Me.IComoConociste.LargeImageIndex = 31
        Me.IComoConociste.Name = "IComoConociste"
        Me.IComoConociste.Tag = "ComoConociste"
        '
        'IEstado
        '
        Me.IEstado.Caption = "Estado"
        Me.IEstado.Id = 148
        Me.IEstado.LargeImageIndex = 32
        Me.IEstado.Name = "IEstado"
        Me.IEstado.Tag = "Estado"
        '
        'IOrientacion
        '
        Me.IOrientacion.Caption = "Orientación"
        Me.IOrientacion.Id = 149
        Me.IOrientacion.LargeImageIndex = 33
        Me.IOrientacion.Name = "IOrientacion"
        Me.IOrientacion.Tag = "Orientación"
        '
        'IPoblacion
        '
        Me.IPoblacion.Caption = "Población"
        Me.IPoblacion.Id = 150
        Me.IPoblacion.LargeImageIndex = 34
        Me.IPoblacion.Name = "IPoblacion"
        Me.IPoblacion.Tag = "Población"
        '
        'IProvincias
        '
        Me.IProvincias.Caption = "Provincias"
        Me.IProvincias.Id = 151
        Me.IProvincias.LargeImageIndex = 35
        Me.IProvincias.Name = "IProvincias"
        Me.IProvincias.Tag = "Provincias"
        Me.IProvincias.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'Itipo
        '
        Me.Itipo.Caption = "Tipo"
        Me.Itipo.Id = 152
        Me.Itipo.LargeImageIndex = 36
        Me.Itipo.Name = "Itipo"
        Me.Itipo.Tag = "Tipo"
        '
        'IZona
        '
        Me.IZona.Caption = "Zona"
        Me.IZona.Id = 153
        Me.IZona.LargeImageIndex = 37
        Me.IZona.Name = "IZona"
        Me.IZona.Tag = "Zona"
        '
        'IEmail
        '
        Me.IEmail.Caption = "Email"
        Me.IEmail.Id = 155
        Me.IEmail.LargeGlyph = Global.My.Resources.Resources.EmailBoton
        Me.IEmail.LargeImageIndex = 38
        Me.IEmail.Name = "IEmail"
        Me.IEmail.Tag = "Email"
        '
        'IEstadisticasGlobales
        '
        Me.IEstadisticasGlobales.Caption = "Global"
        Me.IEstadisticasGlobales.Id = 156
        Me.IEstadisticasGlobales.ImageIndex = 20
        Me.IEstadisticasGlobales.LargeImageIndex = 29
        Me.IEstadisticasGlobales.Name = "IEstadisticasGlobales"
        '
        'IListadoLlamadas
        '
        Me.IListadoLlamadas.Caption = "Llamadas"
        Me.IListadoLlamadas.Id = 157
        Me.IListadoLlamadas.LargeGlyph = Global.My.Resources.Resources.ListadoLlamadas
        Me.IListadoLlamadas.LargeImageIndex = 39
        Me.IListadoLlamadas.Name = "IListadoLlamadas"
        '
        'btnJuntarInmuebles
        '
        Me.btnJuntarInmuebles.Caption = "Juntar Inmuebles"
        Me.btnJuntarInmuebles.Id = 158
        Me.btnJuntarInmuebles.Name = "btnJuntarInmuebles"
        '
        'btnFotosPC
        '
        Me.btnFotosPC.Caption = "Fotos PC"
        Me.btnFotosPC.Id = 159
        Me.btnFotosPC.Name = "btnFotosPC"
        '
        'btnFotosPCBaja
        '
        Me.btnFotosPCBaja.Caption = "Fotos PC Baja"
        Me.btnFotosPCBaja.Id = 160
        Me.btnFotosPCBaja.Name = "btnFotosPCBaja"
        '
        'IMensajesAPP
        '
        Me.IMensajesAPP.Caption = "Mensajes APP"
        Me.IMensajesAPP.Id = 161
        Me.IMensajesAPP.Name = "IMensajesAPP"
        Me.IMensajesAPP.Tag = "MensajesAPP"
        Me.IMensajesAPP.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'IUsuariosAPP
        '
        Me.IUsuariosAPP.Caption = "Usuarios APP/WEB"
        Me.IUsuariosAPP.Id = 162
        Me.IUsuariosAPP.LargeImageIndex = 24
        Me.IUsuariosAPP.Name = "IUsuariosAPP"
        ToolTipTitleItem1.Text = "Envío de novedades por email"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Inmuebles nuevos, bajados de precio o que se les ha quitado la reserva"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.IUsuariosAPP.SuperTip = SuperToolTip1
        Me.IUsuariosAPP.Tag = "UsuariosAPP"
        Me.IUsuariosAPP.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'IEnvioNovedades
        '
        Me.IEnvioNovedades.Caption = "Envio Novedades"
        Me.IEnvioNovedades.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.IEnvioNovedades.Id = 163
        Me.IEnvioNovedades.LargeImageIndex = 38
        Me.IEnvioNovedades.Name = "IEnvioNovedades"
        Me.IEnvioNovedades.Tag = "EnvioNovedades"
        Me.IEnvioNovedades.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'txtUsuario
        '
        Me.txtUsuario.AllowHtmlText = DevExpress.Utils.DefaultBoolean.[True]
        Me.txtUsuario.Caption = "Usuario: "
        Me.txtUsuario.Id = 165
        Me.txtUsuario.ImageIndex = 30
        Me.txtUsuario.ItemAppearance.Normal.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtUsuario.ItemAppearance.Normal.Options.UseFont = True
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'IConfiguracion
        '
        Me.IConfiguracion.Caption = "Configuración"
        Me.IConfiguracion.Id = 166
        Me.IConfiguracion.LargeImageIndex = 25
        Me.IConfiguracion.Name = "IConfiguracion"
        Me.IConfiguracion.Tag = "Configuracion"
        Me.IConfiguracion.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'IGenerarBDAccess
        '
        Me.IGenerarBDAccess.Caption = "Generar BD Access"
        Me.IGenerarBDAccess.Id = 167
        Me.IGenerarBDAccess.Name = "IGenerarBDAccess"
        '
        'IEnviarDatos
        '
        Me.IEnviarDatos.Caption = "Publicar"
        Me.IEnviarDatos.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.IEnviarDatos.Id = 168
        Me.IEnviarDatos.LargeGlyph = Global.My.Resources.Resources.enviar
        Me.IEnviarDatos.Name = "IEnviarDatos"
        Me.IEnviarDatos.Tag = "EnviarDatos"
        '
        'IVerEnvios
        '
        Me.IVerEnvios.Caption = "VerEnvios"
        Me.IVerEnvios.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.IVerEnvios.Id = 169
        Me.IVerEnvios.LargeGlyph = Global.My.Resources.Resources.verenvios
        Me.IVerEnvios.Name = "IVerEnvios"
        Me.IVerEnvios.Tag = "VerEnvios"
        '
        'BarButtonItem12
        '
        Me.BarButtonItem12.Caption = "BarButtonItem12"
        Me.BarButtonItem12.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BarButtonItem12.Id = 170
        Me.BarButtonItem12.Name = "BarButtonItem12"
        '
        'BarButtonItem13
        '
        Me.BarButtonItem13.Caption = "BarButtonItem13"
        Me.BarButtonItem13.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BarButtonItem13.Id = 171
        Me.BarButtonItem13.Name = "BarButtonItem13"
        '
        'IBBDD
        '
        Me.IBBDD.Caption = "Base de Datos"
        Me.IBBDD.Id = 172
        Me.IBBDD.LargeGlyph = Global.My.Resources.Resources.copiaseguridad
        Me.IBBDD.Name = "IBBDD"
        '
        'IImagenes
        '
        Me.IImagenes.Caption = "Imagenes"
        Me.IImagenes.Id = 173
        Me.IImagenes.LargeGlyph = Global.My.Resources.Resources.imagenes
        Me.IImagenes.Name = "IImagenes"
        '
        'IPublicarTodosLosInmuebles
        '
        Me.IPublicarTodosLosInmuebles.Caption = "Todos Inmuebles"
        Me.IPublicarTodosLosInmuebles.Id = 174
        Me.IPublicarTodosLosInmuebles.LargeGlyph = Global.My.Resources.Resources.enviar
        Me.IPublicarTodosLosInmuebles.Name = "IPublicarTodosLosInmuebles"
        Me.IPublicarTodosLosInmuebles.Tag = "PublicarTodosLosInmuebles"
        '
        'IConfiguracionPortales
        '
        Me.IConfiguracionPortales.Caption = "Configuración"
        Me.IConfiguracionPortales.Id = 175
        Me.IConfiguracionPortales.LargeImageIndex = 25
        Me.IConfiguracionPortales.Name = "IConfiguracionPortales"
        Me.IConfiguracionPortales.Tag = "Mantenimientodeportales"
        '
        'BarButtonItem16
        '
        Me.BarButtonItem16.Caption = "BarButtonItem16"
        Me.BarButtonItem16.Id = 176
        Me.BarButtonItem16.Name = "BarButtonItem16"
        '
        'BarButtonItem17
        '
        Me.BarButtonItem17.Caption = "BarButtonItem17"
        Me.BarButtonItem17.Id = 177
        Me.BarButtonItem17.Name = "BarButtonItem17"
        '
        'BarButtonItem18
        '
        Me.BarButtonItem18.Caption = "BarButtonItem18"
        Me.BarButtonItem18.Id = 178
        Me.BarButtonItem18.Name = "BarButtonItem18"
        '
        'IElegirTipo
        '
        Me.IElegirTipo.Caption = "Asignar Tipos"
        Me.IElegirTipo.Id = 182
        Me.IElegirTipo.LargeImageIndex = 41
        Me.IElegirTipo.Name = "IElegirTipo"
        Me.IElegirTipo.Tag = "Asignar Tipos"
        '
        'IElegirTipoVenta
        '
        Me.IElegirTipoVenta.Caption = "Asignar Ofertas"
        Me.IElegirTipoVenta.Id = 183
        Me.IElegirTipoVenta.LargeImageIndex = 42
        Me.IElegirTipoVenta.Name = "IElegirTipoVenta"
        Me.IElegirTipoVenta.Tag = "Asignar Ofertas"
        '
        'IListadoCartel
        '
        Me.IListadoCartel.Caption = "Cartel"
        Me.IListadoCartel.Id = 185
        Me.IListadoCartel.ImageIndex = 20
        Me.IListadoCartel.LargeImageIndex = 29
        Me.IListadoCartel.Name = "IListadoCartel"
        '
        'IPrestamos
        '
        Me.IPrestamos.Caption = "Préstamos"
        Me.IPrestamos.Id = 186
        Me.IPrestamos.LargeImageIndex = 43
        Me.IPrestamos.Name = "IPrestamos"
        Me.IPrestamos.Tag = "Prestamos"
        '
        'IClientesM
        '
        Me.IClientesM.Caption = "Clientes"
        Me.IClientesM.Id = 187
        Me.IClientesM.ImageIndex = 35
        Me.IClientesM.Name = "IClientesM"
        Me.IClientesM.Tag = "Clientes"
        '
        'IInmueblesM
        '
        Me.IInmueblesM.Caption = "Inmuebles"
        Me.IInmueblesM.Id = 188
        Me.IInmueblesM.ImageIndex = 32
        Me.IInmueblesM.Name = "IInmueblesM"
        Me.IInmueblesM.Tag = "Inmuebles"
        '
        'IPropietariosM
        '
        Me.IPropietariosM.Caption = "Propietarios"
        Me.IPropietariosM.Id = 189
        Me.IPropietariosM.ImageIndex = 33
        Me.IPropietariosM.Name = "IPropietariosM"
        Me.IPropietariosM.Tag = "Propietarios"
        '
        'IPrestamosM
        '
        Me.IPrestamosM.Caption = "Préstamos"
        Me.IPrestamosM.Id = 190
        Me.IPrestamosM.ImageIndex = 31
        Me.IPrestamosM.Name = "IPrestamosM"
        Me.IPrestamosM.Tag = "Prestamos"
        '
        'IAlarmasM
        '
        Me.IAlarmasM.Caption = "Alarmas"
        Me.IAlarmasM.Id = 191
        Me.IAlarmasM.ImageIndex = 34
        Me.IAlarmasM.Name = "IAlarmasM"
        Me.IAlarmasM.Tag = "Alarmas"
        '
        'btnContadorOrigen
        '
        Me.btnContadorOrigen.Caption = "Añadir ContadorOrigen"
        Me.btnContadorOrigen.Id = 192
        Me.btnContadorOrigen.Name = "btnContadorOrigen"
        '
        'IListadoComoConocio
        '
        Me.IListadoComoConocio.Caption = "Como conoció"
        Me.IListadoComoConocio.Id = 193
        Me.IListadoComoConocio.ImageIndex = 20
        Me.IListadoComoConocio.LargeImageIndex = 29
        Me.IListadoComoConocio.Name = "IListadoComoConocio"
        '
        'IActualizarWeb
        '
        Me.IActualizarWeb.Caption = "Actualizar Web"
        Me.IActualizarWeb.Id = 195
        Me.IActualizarWeb.LargeGlyph = Global.My.Resources.Resources.GenerateData_32x32
        Me.IActualizarWeb.Name = "IActualizarWeb"
        Me.IActualizarWeb.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnTipoPrincipalWeb
        '
        Me.btnTipoPrincipalWeb.Caption = "WP Tipo Principal Web"
        Me.btnTipoPrincipalWeb.Id = 197
        Me.btnTipoPrincipalWeb.Name = "btnTipoPrincipalWeb"
        '
        'btnWPSubirTodasLasFOTOS
        '
        Me.btnWPSubirTodasLasFOTOS.Caption = "Subir Fotos WP"
        Me.btnWPSubirTodasLasFOTOS.Id = 198
        Me.btnWPSubirTodasLasFOTOS.Name = "btnWPSubirTodasLasFOTOS"
        '
        'btnTipoSecundarioWeb
        '
        Me.btnTipoSecundarioWeb.Caption = "WP Tipo Secundario Web"
        Me.btnTipoSecundarioWeb.Id = 199
        Me.btnTipoSecundarioWeb.Name = "btnTipoSecundarioWeb"
        '
        'btnTipoVenta
        '
        Me.btnTipoVenta.Caption = "WP Tipo Venta"
        Me.btnTipoVenta.Id = 200
        Me.btnTipoVenta.Name = "btnTipoVenta"
        '
        'btnWP_Otros
        '
        Me.btnWP_Otros.Caption = "WP Otros"
        Me.btnWP_Otros.Id = 201
        Me.btnWP_Otros.Name = "btnWP_Otros"
        '
        'btnTipos
        '
        Me.btnTipos.Caption = "WP Tipos"
        Me.btnTipos.Id = 202
        Me.btnTipos.Name = "btnTipos"
        '
        'btnWP_Poblaciones
        '
        Me.btnWP_Poblaciones.Caption = "Poblaciones"
        Me.btnWP_Poblaciones.Id = 203
        Me.btnWP_Poblaciones.Name = "btnWP_Poblaciones"
        '
        'ribbonImageCollectionLarge
        '
        Me.ribbonImageCollectionLarge.ImageSize = New System.Drawing.Size(32, 32)
        Me.ribbonImageCollectionLarge.ImageStream = CType(resources.GetObject("ribbonImageCollectionLarge.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ribbonImageCollectionLarge.Images.SetKeyName(0, "Ribbon_New_32x32.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(1, "Ribbon_Open_32x32.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(2, "Ribbon_Close_32x32.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(3, "Ribbon_Find_32x32.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(4, "Ribbon_Save_32x32.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(5, "Ribbon_SaveAs_32x32.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(6, "Ribbon_Exit_32x32.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(7, "Ribbon_Content_32x32.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(8, "Ribbon_Info_32x32.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(9, "Ribbon_Card4_32x32.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(10, "DiputacionValencia.jpg")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(11, "Articulos.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(12, "Clientes.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(13, "PresupuestosBoton.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(14, "Pedidos.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(15, "caja.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(16, "Vendedores.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(17, "alarma.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(18, "Calendar.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(19, "fotos.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(20, "inmuebles.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(21, "mantenimiento.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(22, "tipos.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(23, "vendedores.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(24, "zonas.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(25, "Configuracion.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(26, "Estilos.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(27, "textoenvio.png")
        Me.ribbonImageCollectionLarge.InsertImage(Global.My.Resources.Resources._Exit, "_Exit", GetType(Global.My.Resources.Resources), 28)
        Me.ribbonImageCollectionLarge.Images.SetKeyName(28, "_Exit")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(29, "Estadisticas.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(30, "Agrupar.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(31, "Buscar.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(32, "Estado.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(33, "orientacion.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(34, "poblacion.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(35, "provincia.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(36, "TipoCasa.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(37, "zona.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(38, "EmailRibbon.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(39, "ListadoLlamadas.png")
        Me.ribbonImageCollectionLarge.InsertImage(Global.My.Resources.Resources.WEB, "WEB", GetType(Global.My.Resources.Resources), 40)
        Me.ribbonImageCollectionLarge.Images.SetKeyName(40, "WEB")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(41, "ElegirTipo.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(42, "ElegirTipoVenta.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(43, "prestamos.png")
        Me.ribbonImageCollectionLarge.Images.SetKeyName(44, "Alarm-Clock.png")
        '
        'pgInicio
        '
        Me.pgInicio.Appearance.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.pgInicio.Appearance.Options.UseFont = True
        Me.pgInicio.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.Salir, Me.grVentas})
        Me.pgInicio.Name = "pgInicio"
        Me.pgInicio.Text = "Inicio"
        '
        'Salir
        '
        Me.Salir.ItemLinks.Add(Me.iExit)
        Me.Salir.Name = "Salir"
        Me.Salir.Text = "Salir"
        '
        'grVentas
        '
        Me.grVentas.ItemLinks.Add(Me.IClientes)
        Me.grVentas.ItemLinks.Add(Me.IInmuebles)
        Me.grVentas.ItemLinks.Add(Me.IPropietarios)
        Me.grVentas.ItemLinks.Add(Me.IAlarmas)
        Me.grVentas.ItemLinks.Add(Me.IEnvioNovedades)
        Me.grVentas.ItemLinks.Add(Me.IUsuariosAPP)
        Me.grVentas.ItemLinks.Add(Me.IMensajesAPP)
        Me.grVentas.ItemLinks.Add(Me.IPrestamos)
        Me.grVentas.Name = "grVentas"
        Me.grVentas.Text = "Inicio"
        '
        'pgListados
        '
        Me.pgListados.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.grListados})
        Me.pgListados.Name = "pgListados"
        Me.pgListados.Text = "Listados"
        Me.pgListados.Visible = False
        '
        'grListados
        '
        Me.grListados.ItemLinks.Add(Me.IEstadisticas)
        Me.grListados.ItemLinks.Add(Me.IEstadisticasGlobales)
        Me.grListados.ItemLinks.Add(Me.IListadoLlamadas)
        Me.grListados.ItemLinks.Add(Me.IListadoCartel)
        Me.grListados.ItemLinks.Add(Me.IListadoComoConocio)
        Me.grListados.Name = "grListados"
        Me.grListados.Text = "Estadísticas"
        '
        'pgPortales
        '
        Me.pgPortales.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.grPortales})
        Me.pgPortales.Name = "pgPortales"
        Me.pgPortales.Text = "Portales"
        '
        'grPortales
        '
        Me.grPortales.ItemLinks.Add(Me.IElegirTipo)
        Me.grPortales.ItemLinks.Add(Me.IElegirTipoVenta)
        Me.grPortales.ItemLinks.Add(Me.IConfiguracionPortales)
        Me.grPortales.Name = "grPortales"
        Me.grPortales.Tag = "Portales de publicación"
        Me.grPortales.Text = "Portales"
        '
        'pgMantenimientos
        '
        Me.pgMantenimientos.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.grMantenimientos})
        Me.pgMantenimientos.Name = "pgMantenimientos"
        Me.pgMantenimientos.Text = "Mantenimientos"
        Me.pgMantenimientos.Visible = False
        '
        'grMantenimientos
        '
        Me.grMantenimientos.ItemLinks.Add(Me.IEstado)
        Me.grMantenimientos.ItemLinks.Add(Me.Itipo)
        Me.grMantenimientos.ItemLinks.Add(Me.IZona)
        Me.grMantenimientos.ItemLinks.Add(Me.IOrientacion)
        Me.grMantenimientos.ItemLinks.Add(Me.IComoConociste)
        Me.grMantenimientos.ItemLinks.Add(Me.IPoblacion)
        Me.grMantenimientos.ItemLinks.Add(Me.IProvincias)
        Me.grMantenimientos.ItemLinks.Add(Me.IAgrupacion)
        Me.grMantenimientos.Name = "grMantenimientos"
        Me.grMantenimientos.Tag = "MantenimientoVenalia"
        Me.grMantenimientos.Text = "Mantenimientos"
        '
        'pgControl
        '
        Me.pgControl.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.grControl})
        Me.pgControl.Name = "pgControl"
        Me.pgControl.Tag = "Control"
        Me.pgControl.Text = "Control"
        '
        'grControl
        '
        Me.grControl.ItemLinks.Add(Me.IEmpleados)
        Me.grControl.ItemLinks.Add(Me.IEmail)
        Me.grControl.ItemLinks.Add(Me.ITextosEnvios)
        Me.grControl.ItemLinks.Add(Me.IConfiguracionEmpresas)
        Me.grControl.ItemLinks.Add(Me.IConfiguracion)
        Me.grControl.ItemLinks.Add(Me.IActualizarWeb)
        Me.grControl.Name = "grControl"
        Me.grControl.Tag = "Control"
        Me.grControl.Text = "Control"
        '
        'pgCopiaSeguridad
        '
        Me.pgCopiaSeguridad.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rgSincronizacion, Me.rgCopiaSeguridad})
        Me.pgCopiaSeguridad.Name = "pgCopiaSeguridad"
        Me.pgCopiaSeguridad.Tag = "CopiaSeguridad"
        Me.pgCopiaSeguridad.Text = "Copia Seguridad"
        '
        'rgSincronizacion
        '
        Me.rgSincronizacion.ItemLinks.Add(Me.IVerEnvios)
        Me.rgSincronizacion.Name = "rgSincronizacion"
        Me.rgSincronizacion.Text = "Sincronización"
        Me.rgSincronizacion.Visible = False
        '
        'rgCopiaSeguridad
        '
        Me.rgCopiaSeguridad.ItemLinks.Add(Me.IBBDD)
        Me.rgCopiaSeguridad.ItemLinks.Add(Me.IImagenes)
        Me.rgCopiaSeguridad.Name = "rgCopiaSeguridad"
        Me.rgCopiaSeguridad.Text = "Copia de Seguridad"
        '
        'TresBits
        '
        Me.TresBits.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1})
        Me.TresBits.Name = "TresBits"
        Me.TresBits.Text = "TresBits"
        Me.TresBits.Visible = False
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.IEstilos)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnJuntarInmuebles)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnFotosPC)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnFotosPCBaja)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.IGenerarBDAccess)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.IEnviarDatos)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.IPublicarTodosLosInmuebles)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnContadorOrigen, "AÑADIR CONTADORORIGEN Y RELLENARLO")
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnWPSubirTodasLasFOTOS)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnTipoPrincipalWeb)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnTipoSecundarioWeb)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnTipos)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnTipoVenta)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnWP_Otros)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnWP_Poblaciones)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "TresBits"
        '
        'RepositoryItemHyperLinkEdit1
        '
        Me.RepositoryItemHyperLinkEdit1.AutoHeight = False
        Me.RepositoryItemHyperLinkEdit1.Name = "RepositoryItemHyperLinkEdit1"
        '
        'RepositoryItemHyperLinkEdit2
        '
        Me.RepositoryItemHyperLinkEdit2.AutoHeight = False
        Me.RepositoryItemHyperLinkEdit2.Name = "RepositoryItemHyperLinkEdit2"
        '
        'RepositoryItemPictureEdit1
        '
        Me.RepositoryItemPictureEdit1.InitialImage = CType(resources.GetObject("RepositoryItemPictureEdit1.InitialImage"), System.Drawing.Image)
        Me.RepositoryItemPictureEdit1.Name = "RepositoryItemPictureEdit1"
        '
        'RepositoryItemImageEdit1
        '
        Me.RepositoryItemImageEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageEdit1.Name = "RepositoryItemImageEdit1"
        '
        'ribbonStatusBar
        '
        Me.ribbonStatusBar.ItemLinks.Add(Me.siStatus)
        Me.ribbonStatusBar.ItemLinks.Add(Me.siInfo)
        Me.ribbonStatusBar.Location = New System.Drawing.Point(0, 658)
        Me.ribbonStatusBar.Name = "ribbonStatusBar"
        Me.ribbonStatusBar.Ribbon = Me.ribbonControl
        Me.ribbonStatusBar.Size = New System.Drawing.Size(1262, 31)
        Me.ribbonStatusBar.Visible = False
        '
        'GalleryControl1
        '
        Me.GalleryControl1.Controls.Add(Me.GalleryControlClient1)
        Me.GalleryControl1.DesignGalleryGroupIndex = 0
        Me.GalleryControl1.DesignGalleryItemIndex = 0
        Me.GalleryControl1.Dock = System.Windows.Forms.DockStyle.Fill
        '
        'GalleryControlGallery1
        '
        Me.GalleryControl1.Gallery.FixedImageSize = False
        Me.GalleryControl1.Gallery.ImageSize = New System.Drawing.Size(64, 64)
        Me.GalleryControl1.Gallery.ItemImageLayout = DevExpress.Utils.Drawing.ImageLayoutMode.Stretch
        Me.GalleryControl1.Location = New System.Drawing.Point(0, 0)
        Me.GalleryControl1.Name = "GalleryControl1"
        Me.GalleryControl1.Size = New System.Drawing.Size(355, 171)
        Me.GalleryControl1.TabIndex = 0
        Me.GalleryControl1.Text = "GalleryControl1"
        '
        'GalleryControlClient1
        '
        Me.GalleryControlClient1.GalleryControl = Me.GalleryControl1
        Me.GalleryControlClient1.Location = New System.Drawing.Point(2, 2)
        Me.GalleryControlClient1.Size = New System.Drawing.Size(334, 167)
        '
        'ImgGeneral
        '
        Me.ImgGeneral.ImageStream = CType(resources.GetObject("ImgGeneral.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgGeneral.TransparentColor = System.Drawing.Color.Transparent
        Me.ImgGeneral.Images.SetKeyName(0, "aceptar.png")
        Me.ImgGeneral.Images.SetKeyName(1, "añadir.png")
        Me.ImgGeneral.Images.SetKeyName(2, "borrar.png")
        Me.ImgGeneral.Images.SetKeyName(3, "buscar.png")
        Me.ImgGeneral.Images.SetKeyName(4, "cancelar.png")
        Me.ImgGeneral.Images.SetKeyName(5, "comunic.png")
        Me.ImgGeneral.Images.SetKeyName(6, "config.png")
        Me.ImgGeneral.Images.SetKeyName(7, "consultas.png")
        Me.ImgGeneral.Images.SetKeyName(8, "cop_seg.png")
        Me.ImgGeneral.Images.SetKeyName(9, "email.png")
        Me.ImgGeneral.Images.SetKeyName(10, "imprimir.png")
        Me.ImgGeneral.Images.SetKeyName(11, "mantenim.png")
        Me.ImgGeneral.Images.SetKeyName(12, "modificar.png")
        Me.ImgGeneral.Images.SetKeyName(13, "procesos.png")
        Me.ImgGeneral.Images.SetKeyName(14, "salir.png")
        Me.ImgGeneral.Images.SetKeyName(15, "lp16.png")
        Me.ImgGeneral.Images.SetKeyName(16, "lp24.png")
        Me.ImgGeneral.Images.SetKeyName(17, "lp32.png")
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Derechos"
        Me.BarButtonItem1.Id = 62
        Me.BarButtonItem1.ImageIndex = 7
        Me.BarButtonItem1.LargeImageIndex = 7
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'XtraTabbedMdiManager1
        '
        Me.XtraTabbedMdiManager1.AppearancePage.HeaderActive.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.XtraTabbedMdiManager1.AppearancePage.HeaderActive.ForeColor = System.Drawing.Color.Red
        Me.XtraTabbedMdiManager1.AppearancePage.HeaderActive.Options.UseFont = True
        Me.XtraTabbedMdiManager1.AppearancePage.HeaderActive.Options.UseForeColor = True
        Me.XtraTabbedMdiManager1.MdiParent = Me
        '
        'PopupControlContainer3
        '
        Me.PopupControlContainer3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PopupControlContainer3.Controls.Add(Me.GalleryControl1)
        Me.PopupControlContainer3.Location = New System.Drawing.Point(454, 259)
        Me.PopupControlContainer3.Name = "PopupControlContainer3"
        Me.PopupControlContainer3.Size = New System.Drawing.Size(355, 171)
        Me.PopupControlContainer3.TabIndex = 10
        Me.PopupControlContainer3.Visible = False
        '
        'BarManager1
        '
        Me.BarManager1.AllowCustomization = False
        Me.BarManager1.AllowQuickCustomization = False
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.MaxItemId = 17
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1262, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 689)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1262, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 689)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1262, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 689)
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1262, 689)
        Me.PictureBox1.TabIndex = 308
        Me.PictureBox1.TabStop = False
        '
        'frRealizandoCopia
        '
        Me.frRealizandoCopia.Controls.Add(Me.lblPercent)
        Me.frRealizandoCopia.Controls.Add(Me.label17)
        Me.frRealizandoCopia.Controls.Add(Me.Label18)
        Me.frRealizandoCopia.Controls.Add(Me.LabelControl1)
        Me.frRealizandoCopia.Location = New System.Drawing.Point(287, 267)
        Me.frRealizandoCopia.Name = "frRealizandoCopia"
        Me.frRealizandoCopia.Size = New System.Drawing.Size(688, 188)
        Me.frRealizandoCopia.TabIndex = 314
        Me.frRealizandoCopia.Visible = False
        '
        'lblPercent
        '
        Me.lblPercent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPercent.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPercent.Appearance.ForeColor = System.Drawing.Color.Maroon
        Me.lblPercent.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblPercent.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblPercent.Location = New System.Drawing.Point(5, 155)
        Me.lblPercent.Name = "lblPercent"
        Me.lblPercent.Size = New System.Drawing.Size(678, 28)
        Me.lblPercent.TabIndex = 5
        '
        'label17
        '
        Me.label17.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label17.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label17.Appearance.ForeColor = System.Drawing.Color.Maroon
        Me.label17.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.label17.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.label17.Location = New System.Drawing.Point(5, 52)
        Me.label17.Name = "label17"
        Me.label17.Size = New System.Drawing.Size(678, 28)
        Me.label17.TabIndex = 4
        Me.label17.Text = "Enviando" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label18
        '
        Me.Label18.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Appearance.ForeColor = System.Drawing.Color.Maroon
        Me.Label18.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Label18.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.Label18.Location = New System.Drawing.Point(5, 93)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(678, 57)
        Me.Label18.TabIndex = 3
        Me.Label18.Text = "Enviando"
        '
        'LabelControl1
        '
        Me.LabelControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.Maroon
        Me.LabelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl1.Location = New System.Drawing.Point(5, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(678, 23)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Generación de Ficheros Iniciado"
        '
        'pnlEnviado
        '
        Me.pnlEnviado.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.pnlEnviado.Controls.Add(Me.LabelControl4)
        Me.pnlEnviado.Controls.Add(Me.LabelControl3)
        Me.pnlEnviado.Location = New System.Drawing.Point(316, 253)
        Me.pnlEnviado.Name = "pnlEnviado"
        Me.pnlEnviado.Size = New System.Drawing.Size(631, 182)
        Me.pnlEnviado.TabIndex = 321
        Me.pnlEnviado.Visible = False
        '
        'LabelControl4
        '
        Me.LabelControl4.AllowHtmlString = True
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Italic)
        Me.LabelControl4.Location = New System.Drawing.Point(254, 91)
        Me.LabelControl4.LookAndFeel.UseDefaultLookAndFeel = False
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(291, 33)
        Me.LabelControl4.TabIndex = 259
        Me.LabelControl4.Text = "Espere unos instantes ..."
        '
        'LabelControl3
        '
        Me.LabelControl3.AllowHtmlString = True
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Italic)
        Me.LabelControl3.Location = New System.Drawing.Point(79, 30)
        Me.LabelControl3.LookAndFeel.UseDefaultLookAndFeel = False
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(185, 33)
        Me.LabelControl3.TabIndex = 258
        Me.LabelControl3.Text = "Enviando datos"
        '
        'Panellmagenes
        '
        Me.Panellmagenes.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Panellmagenes.BackColor = System.Drawing.Color.White
        Me.Panellmagenes.Controls.Add(Me.picAlarmas)
        Me.Panellmagenes.Controls.Add(Me.PictureBox2)
        Me.Panellmagenes.Controls.Add(Me.picExit)
        Me.Panellmagenes.Controls.Add(Me.picPropietarios)
        Me.Panellmagenes.Controls.Add(Me.picInmuebles)
        Me.Panellmagenes.Controls.Add(Me.picPortales)
        Me.Panellmagenes.Controls.Add(Me.picVenaliaApp)
        Me.Panellmagenes.Controls.Add(Me.picClientes)
        Me.Panellmagenes.Location = New System.Drawing.Point(1, 143)
        Me.Panellmagenes.MaximumSize = New System.Drawing.Size(1262, 644)
        Me.Panellmagenes.Name = "Panellmagenes"
        Me.Panellmagenes.Size = New System.Drawing.Size(1262, 644)
        Me.Panellmagenes.TabIndex = 339
        '
        'picAlarmas
        '
        Me.picAlarmas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picAlarmas.Image = Global.My.Resources.Resources.alarmas
        Me.picAlarmas.InitialImage = Nothing
        Me.picAlarmas.Location = New System.Drawing.Point(232, 355)
        Me.picAlarmas.Name = "picAlarmas"
        Me.picAlarmas.Size = New System.Drawing.Size(193, 179)
        Me.picAlarmas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picAlarmas.TabIndex = 331
        Me.picAlarmas.TabStop = False
        Me.picAlarmas.Tag = "Alarmas"
        '
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictureBox2.Image = Global.My.Resources.Resources._09
        Me.PictureBox2.InitialImage = Nothing
        Me.PictureBox2.Location = New System.Drawing.Point(85, 47)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(340, 77)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 330
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Tag = "Proyectos"
        '
        'picExit
        '
        Me.picExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picExit.Image = Global.My.Resources.Resources._10
        Me.picExit.InitialImage = Nothing
        Me.picExit.Location = New System.Drawing.Point(931, 47)
        Me.picExit.Name = "picExit"
        Me.picExit.Size = New System.Drawing.Size(104, 77)
        Me.picExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picExit.TabIndex = 329
        Me.picExit.TabStop = False
        Me.picExit.Tag = "Proyectos"
        '
        'picPropietarios
        '
        Me.picPropietarios.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picPropietarios.Image = Global.My.Resources.Resources._02
        Me.picPropietarios.InitialImage = Nothing
        Me.picPropietarios.Location = New System.Drawing.Point(842, 154)
        Me.picPropietarios.Name = "picPropietarios"
        Me.picPropietarios.Size = New System.Drawing.Size(193, 179)
        Me.picPropietarios.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picPropietarios.TabIndex = 327
        Me.picPropietarios.TabStop = False
        Me.picPropietarios.Tag = "Propietarios"
        '
        'picInmuebles
        '
        Me.picInmuebles.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picInmuebles.Image = Global.My.Resources.Resources._03
        Me.picInmuebles.InitialImage = Nothing
        Me.picInmuebles.Location = New System.Drawing.Point(537, 154)
        Me.picInmuebles.Name = "picInmuebles"
        Me.picInmuebles.Size = New System.Drawing.Size(193, 179)
        Me.picInmuebles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picInmuebles.TabIndex = 325
        Me.picInmuebles.TabStop = False
        Me.picInmuebles.Tag = "Minería de datos"
        '
        'picPortales
        '
        Me.picPortales.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picPortales.Image = Global.My.Resources.Resources._04
        Me.picPortales.InitialImage = Nothing
        Me.picPortales.Location = New System.Drawing.Point(537, 355)
        Me.picPortales.Name = "picPortales"
        Me.picPortales.Size = New System.Drawing.Size(193, 179)
        Me.picPortales.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picPortales.TabIndex = 323
        Me.picPortales.TabStop = False
        Me.picPortales.Tag = "Portales"
        '
        'picVenaliaApp
        '
        Me.picVenaliaApp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picVenaliaApp.Enabled = False
        Me.picVenaliaApp.Image = Global.My.Resources.Resources.i05
        Me.picVenaliaApp.InitialImage = Nothing
        Me.picVenaliaApp.Location = New System.Drawing.Point(842, 355)
        Me.picVenaliaApp.Name = "picVenaliaApp"
        Me.picVenaliaApp.Size = New System.Drawing.Size(193, 179)
        Me.picVenaliaApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picVenaliaApp.TabIndex = 322
        Me.picVenaliaApp.TabStop = False
        Me.picVenaliaApp.Tag = "Informes"
        '
        'picClientes
        '
        Me.picClientes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picClientes.Image = Global.My.Resources.Resources._01
        Me.picClientes.InitialImage = Nothing
        Me.picClientes.Location = New System.Drawing.Point(232, 155)
        Me.picClientes.Name = "picClientes"
        Me.picClientes.Size = New System.Drawing.Size(193, 179)
        Me.picClientes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picClientes.TabIndex = 321
        Me.picClientes.TabStop = False
        Me.picClientes.Tag = "Albaranes"
        '
        'BarButtonItem19
        '
        Me.BarButtonItem19.Caption = "Cartel"
        Me.BarButtonItem19.Id = 185
        Me.BarButtonItem19.ImageIndex = 20
        Me.BarButtonItem19.LargeImageIndex = 29
        Me.BarButtonItem19.Name = "BarButtonItem19"
        '
        'BarButtonItem20
        '
        Me.BarButtonItem20.Caption = "Tipo Principal Web"
        Me.BarButtonItem20.Id = 197
        Me.BarButtonItem20.Name = "BarButtonItem20"
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1262, 689)
        Me.Controls.Add(Me.Panellmagenes)
        Me.Controls.Add(Me.frRealizandoCopia)
        Me.Controls.Add(Me.pnlEnviado)
        Me.Controls.Add(Me.PopupControlContainer3)
        Me.Controls.Add(Me.popupControlContainer1)
        Me.Controls.Add(Me.popupControlContainer2)
        Me.Controls.Add(Me.ribbonStatusBar)
        Me.Controls.Add(Me.ribbonControl)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.Name = "frmPrincipal"
        Me.Ribbon = Me.ribbonControl
        Me.StatusBar = Me.ribbonStatusBar
        CType(Me.ribbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.appMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.popupControlContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.popupControlContainer2.ResumeLayout(False)
        CType(Me.buttonEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.popupControlContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.popupControlContainer1.ResumeLayout(False)
        Me.popupControlContainer1.PerformLayout()
        CType(Me.ribbonImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ribbonImageCollectionLarge, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemHyperLinkEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemHyperLinkEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemPictureEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GalleryControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GalleryControl1.ResumeLayout(False)
        CType(Me.XtraTabbedMdiManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupControlContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PopupControlContainer3.ResumeLayout(False)
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.frRealizandoCopia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frRealizandoCopia.ResumeLayout(False)
        CType(Me.pnlEnviado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEnviado.ResumeLayout(False)
        Me.pnlEnviado.PerformLayout()
        Me.Panellmagenes.ResumeLayout(False)
        CType(Me.picAlarmas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPropietarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picInmuebles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPortales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picVenaliaApp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents siInfo As DevExpress.XtraBars.BarStaticItem
    Private WithEvents iNew As DevExpress.XtraBars.BarButtonItem
    Private WithEvents iOpen As DevExpress.XtraBars.BarButtonItem
    Private WithEvents iClose As DevExpress.XtraBars.BarButtonItem
    Private WithEvents iFind As DevExpress.XtraBars.BarButtonItem
    Private WithEvents iSave As DevExpress.XtraBars.BarButtonItem
    Private WithEvents iSaveAs As DevExpress.XtraBars.BarButtonItem
    Private WithEvents alignButtonGroup As DevExpress.XtraBars.BarButtonGroup
    Private WithEvents iBoldFontStyle As DevExpress.XtraBars.BarButtonItem
    Private WithEvents iItalicFontStyle As DevExpress.XtraBars.BarButtonItem
    Private WithEvents iUnderlinedFontStyle As DevExpress.XtraBars.BarButtonItem
    Private WithEvents fontStyleButtonGroup As DevExpress.XtraBars.BarButtonGroup
    Private WithEvents iLeftTextAlign As DevExpress.XtraBars.BarButtonItem
    Private WithEvents iCenterTextAlign As DevExpress.XtraBars.BarButtonItem
    Private WithEvents iRightTextAlign As DevExpress.XtraBars.BarButtonItem
    Private WithEvents rgbiSkins As DevExpress.XtraBars.RibbonGalleryBarItem
    Private WithEvents iExit As DevExpress.XtraBars.BarButtonItem
    Private WithEvents iCalificacion As DevExpress.XtraBars.BarButtonItem
    Private WithEvents iClasificacion As DevExpress.XtraBars.BarButtonItem
    Private WithEvents popupControlContainer1 As DevExpress.XtraBars.PopupControlContainer
    Private WithEvents someLabelControl2 As DevExpress.XtraEditors.LabelControl
    Private WithEvents someLabelControl1 As DevExpress.XtraEditors.LabelControl
    Private WithEvents popupControlContainer2 As DevExpress.XtraBars.PopupControlContainer
    Private WithEvents buttonEdit As DevExpress.XtraEditors.ButtonEdit
    Private WithEvents ribbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Private WithEvents ribbonImageCollection As DevExpress.Utils.ImageCollection
    Private WithEvents ribbonImageCollectionLarge As DevExpress.Utils.ImageCollection
    Friend WithEvents ImgGeneral As System.Windows.Forms.ImageList
    Friend WithEvents Iderechos As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IDelegaciones As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IDiarios As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IIntereses As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ITipoExpediente As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IInteresesOpcionesCalculo As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IPaisesProvinciasPoblaciones As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ILeyes As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IUsuarios As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IRepresentacion As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IAfecciones As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ICultivos As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents XtraTabbedMdiManager1 As DevExpress.XtraTabbedMdi.XtraTabbedMdiManager
    Friend WithEvents RepositoryItemHyperLinkEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents RepositoryItemHyperLinkEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Public WithEvents siStatus As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents RepositoryItemPictureEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents RepositoryItemImageEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemImageEdit
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents ImageCollection2 As DevExpress.Utils.ImageCollection
    Friend WithEvents rgbOrganismos As DevExpress.XtraBars.RibbonGalleryBarItem
    Public WithEvents ribbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents iFincas As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents iTitulares As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem4 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem5 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem6 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents MunicipiosButtonGroup As DevExpress.XtraBars.BarButtonGroup
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem7 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem8 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem9 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem10 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonGroup1 As DevExpress.XtraBars.BarButtonGroup
    Friend WithEvents BarButtonGroup2 As DevExpress.XtraBars.BarButtonGroup
    Friend WithEvents BarButtonGroup3 As DevExpress.XtraBars.BarButtonGroup
    Friend WithEvents BarButtonGroup4 As DevExpress.XtraBars.BarButtonGroup
    Friend WithEvents BarButtonGroup5 As DevExpress.XtraBars.BarButtonGroup
    Friend WithEvents IClientes As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IInmuebles As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IAlarmas As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarCheckItem1 As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents BarCheckItem2 As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents BarButtonItem14 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem15 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents pgInicio As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents grVentas As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents pgListados As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents grListados As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents ITextosEnvios As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IEmpleados As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IConfiguracionEmpresas As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IFormasPago As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IAgrupaciones As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IAlmacenes As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IFabricantes As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IFamilias As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ISubFamilias As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IGamas As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IMarcas As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents INacionalidades As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ISeriesFacturacion As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ITarifas As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ITipoIVA As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IColores As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IEstilos As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PopupControlContainer3 As DevExpress.XtraBars.PopupControlContainer
    Friend WithEvents GalleryControl1 As DevExpress.XtraBars.Ribbon.GalleryControl
    Friend WithEvents GalleryControlClient1 As DevExpress.XtraBars.Ribbon.GalleryControlClient
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents IPropietarios As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IEstadisticas As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IAgrupacion As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IComoConociste As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IEstado As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IOrientacion As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IPoblacion As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IProvincias As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Itipo As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IZona As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents pgMantenimientos As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents grMantenimientos As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents IEmail As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IEstadisticasGlobales As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IListadoLlamadas As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem11 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Salir As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btnJuntarInmuebles As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnFotosPC As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnFotosPCBaja As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents TresBits As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents IMensajesAPP As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IUsuariosAPP As DevExpress.XtraBars.BarButtonItem
    Private WithEvents appMenu As DevExpress.XtraBars.Ribbon.ApplicationMenu
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents IEnvioNovedades As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents txtUsuario As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents IConfiguracion As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IGenerarBDAccess As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents frRealizandoCopia As DevExpress.XtraEditors.PanelControl
    Friend WithEvents label17 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents IEnviarDatos As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IVerEnvios As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents pgCopiaSeguridad As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rgSincronizacion As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarButtonItem12 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem13 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IBBDD As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IImagenes As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rgCopiaSeguridad As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents pnlEnviado As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents IPublicarTodosLosInmuebles As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IConfiguracionPortales As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents pgPortales As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents grPortales As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarButtonItem16 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem17 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem18 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Panellmagenes As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents picExit As System.Windows.Forms.PictureBox
    Friend WithEvents picPropietarios As System.Windows.Forms.PictureBox
    Friend WithEvents picInmuebles As System.Windows.Forms.PictureBox
    Friend WithEvents picPortales As System.Windows.Forms.PictureBox
    Friend WithEvents picVenaliaApp As System.Windows.Forms.PictureBox
    Friend WithEvents picClientes As System.Windows.Forms.PictureBox
    Friend WithEvents pgControl As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents grControl As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents IElegirTipo As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IElegirTipoVenta As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents picAlarmas As System.Windows.Forms.PictureBox
    Friend WithEvents IListadoCartel As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IPrestamos As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IClientesM As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IInmueblesM As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IPropietariosM As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IPrestamosM As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IAlarmasM As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnContadorOrigen As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IListadoComoConocio As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem19 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IActualizarWeb As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents lblPercent As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnTipoPrincipalWeb As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnWPSubirTodasLasFOTOS As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnTipoSecundarioWeb As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnTipoVenta As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem20 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnWP_Otros As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnTipos As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnWP_Poblaciones As DevExpress.XtraBars.BarButtonItem
End Class
