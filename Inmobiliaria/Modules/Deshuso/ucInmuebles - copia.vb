
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid
Imports System
Imports DevExpress.XtraEditors
Imports System.Data
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraBars
Imports DevExpress.LookAndFeel.Design
Imports System.Drawing
Imports DevExpress.Skins
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports System.Data.SqlClient
Imports DevExpress.XtraBars.Docking
Imports DevExpress.XtraEditors.Controls


Partial Public Class ucInmuebles

    Inherits DevExpress.XtraEditors.XtraUserControl

    Dim FiltroAntesBusquedaPropietario As String = ""
    Dim PosicionAntesBusquedaPropietario As Integer = 0
  

    Dim Eliminando As Boolean = False
    Dim menu As DXPopupMenu
    Public PopupMenu As DXPopupMenu
    Dim EstoyEnAlta As Boolean

    Dim bd As BaseDatos
    Private WithEvents BinSrc As BindingSource
    Dim TablaMantenimiento As String = "Inmuebles"
    Dim CargandoClientes As Boolean = True
    Dim PrimeraVez As Boolean

    Dim TablaInmuebles As String
    Dim SentenciaSQL As String
    Dim FiltroBusqueda As String = ""
    Dim TextoInicialBotonBuscar As String = ""
    Dim ColorInicialBotonBuscar As System.Drawing.Color
    Dim CampoInicialBusqueda As String = "Referencia"

  
    Dim PanelArticulosVendidos As DockPanel
    ' Dim uInmueblesPropietario As ucInmueblesPropietario

    Dim PanelGestionDocumental As DockPanel
    Dim uGestionDocumental As ucGestionDocumental
    Dim TablaGestionDocumental As String
    Dim CampoGestionDocumental As String

    Dim ColorInicialBotonBajas As System.Drawing.Color
   

    '*********COSAS A CAMBIAR EN NUEVOS MANTENIMIENTOS
    '*************************************************
    '1. TablaMantenimiento
    '2. EN NEW
    '   A. Bindings
    '   B. ConfigurarGrid
    '3. Private Sub PrepararAlta()
    '4. Private Function Actualizar() As Boolean
    '5. Private Function ComprobarDatos() As Boolean
    '****FIN*****COSAS A CAMBIAR EN NUEVOS MANTENIMIENTOS
    '****************************************************

    Public Sub New()
        InitializeComponent()
        ContadorClienteDeDondeVengo = 0
        DeDondeVengo = ""

    End Sub

    Private p_DeDondeVengo As String

    Public Property DeDondeVengo As String
        Get
            Return p_DeDondeVengo
        End Get
        Set(value As String)
            p_DeDondeVengo = value
        End Set
    End Property

    'Private p_Otros As String

    'Public Property Otros As String
    '    Get
    '        Return p_Otros
    '    End Get
    '    Set(value As String)
    '        p_Otros = value
    '    End Set
    'End Property

    Private p_ContadorClienteDeDondeVengo As Integer

    Public Property ContadorClienteDeDondeVengo As Integer
        Get
            Return p_ContadorClienteDeDondeVengo
        End Get
        Set(value As Integer)
            p_ContadorClienteDeDondeVengo = value
        End Set
    End Property
    Private Sub ucInmuebles_Load(sender As Object, e As System.EventArgs) Handles Me.Load


        AparienciaGeneral()


        btnDatosPropietarios.Text = "Datos" & vbCrLf & "Propietarios"


        CargandoClientes = True
        PrimeraVez = True
        TextoInicialBotonBuscar = btnBuscar.Text
        ColorInicialBotonBuscar = btnBuscar.ForeColor

        TablaGestionDocumental = "Inmuebles"
        CampoGestionDocumental = "Referencia"

        LlenarGrid()

        TablaInmuebles = GL_TablaInmuebles
        CargandoClientes = True

        ColorInicialBotonBajas = btnVerBajas.ForeColor

        'Bindings
        txtCodigo.DataBindings.Add(New Binding("EditValue", BinSrc, "Referencia", True))
        txtCodPostal.DataBindings.Add(New Binding("EditValue", BinSrc, "CodPostal", True))
        txtDireccion.DataBindings.Add(New Binding("EditValue", BinSrc, "Direccion", True))
        txtNumero.DataBindings.Add(New Binding("EditValue", BinSrc, "Numero", True))
        txtPuerta.DataBindings.Add(New Binding("EditValue", BinSrc, "Puerta", True))
        txtProvincia.DataBindings.Add(New Binding("EditValue", BinSrc, "Provincia", True))
        txtObservaciones.DataBindings.Add(New Binding("EditValue", BinSrc, "Observaciones", True))
        txtExtras.DataBindings.Add(New Binding("EditValue", BinSrc, "Extras", True))

        txtLlaves.DataBindings.Add(New Binding("EditValue", BinSrc, "TextoLlaves", True))

        mskFechaAlta.DataBindings.Add(New Binding("EditValue", BinSrc, "FechaAlta", True))

        spnMetros.DataBindings.Add(New Binding("EditValue", BinSrc, "Metros", True))
        spnMetrosPlaya.DataBindings.Add(New Binding("EditValue", BinSrc, "MPlaya", True))

        spnAltura.DataBindings.Add(New Binding("EditValue", BinSrc, "Altura", True))
        spnAnoConstruccion.DataBindings.Add(New Binding("EditValue", BinSrc, "AnoConstruccion", True))
        spnBanos.DataBindings.Add(New Binding("EditValue", BinSrc, "Banos", True))
        spnHabitaciones.DataBindings.Add(New Binding("EditValue", BinSrc, "Habitaciones", True))
        spnPrecioAlquiler.DataBindings.Add(New Binding("EditValue", BinSrc, "PrecioAlquiler", True))
        spnPrecioVenta.DataBindings.Add(New Binding("EditValue", BinSrc, "PrecioVenta", True))

        chkAlquiler.DataBindings.Add(New Binding("CheckState", BinSrc, "Alquiler", True))
        chkVenta.DataBindings.Add(New Binding("CheckState", BinSrc, "Venta", True))
        chkBaja.DataBindings.Add(New Binding("CheckState", BinSrc, "Baja", True))
        chkLlaves.DataBindings.Add(New Binding("CheckState", BinSrc, "Llaves", True))

        chkAscensor.DataBindings.Add(New Binding("CheckState", BinSrc, "Ascensor", True))
        chkCocinaOffice.DataBindings.Add(New Binding("CheckState", BinSrc, "CocinaOffice", True))
        chkDuplex.DataBindings.Add(New Binding("CheckState", BinSrc, "Duplex", True))
        chkGaleria.DataBindings.Add(New Binding("CheckState", BinSrc, "Galeria", True))
        chkPiscina.DataBindings.Add(New Binding("CheckState", BinSrc, "Piscina", True))

        chkElectrodomesticos.DataBindings.Add(New Binding("CheckState", BinSrc, "Electrodomesticos", True))

        chkOportunidad.DataBindings.Add(New Binding("CheckState", BinSrc, "Chollo", True))
        chkEscaparate.DataBindings.Add(New Binding("CheckState", BinSrc, "Escaparate", True))
        chkNoAlquiler.DataBindings.Add(New Binding("CheckState", BinSrc, "NoAlquiler", True))
        chkOcultar.DataBindings.Add(New Binding("CheckState", BinSrc, "Ocultar", True))
        chkCartel.DataBindings.Add(New Binding("CheckState", BinSrc, "Cartel", True))
        chkOpcionCompra.DataBindings.Add(New Binding("CheckState", BinSrc, "AlquilerOpcionCompra", True))

        ucCalentador.DataBindings.Add(New Binding("Valor", BinSrc, "Calentador", True))
        ucCocina.DataBindings.Add(New Binding("Valor", BinSrc, "Cocina", True))

        'chkCalentador.DataBindings.Add(New Binding("CheckState", BinSrc, "Calentador", True))
        'chkCocina.DataBindings.Add(New Binding("CheckState", BinSrc, "Cocina", True))
        '  ucOpcionCompra.DataBindings.Add(New Binding("Valor", BinSrc, "AlquilerOpcionCompra", False, DataSourceUpdateMode.OnPropertyChanged))



        txtGastosVenta.DataBindings.Add(New Binding("EditValue", BinSrc, "Gastos", True))
        spnPrecioPropietarioVenta.DataBindings.Add(New Binding("EditValue", BinSrc, "PrecioPropietarioVenta", True))


        spnPrecioPropietarioAlquiler.DataBindings.Add(New Binding("EditValue", BinSrc, "PrecioPropietarioAlquiler", True))

        ucBalcon.DataBindings.Add(New Binding("Valor", BinSrc, "Balcon", True))
        ucBalcon.DataBindings.Add(New Binding("ValorCajaTexto1", BinSrc, "MBalcon", True))
        ucBalcon.DataBindings.Add(New Binding("ValorCajaTexto2", BinSrc, "MBalcon2", True))

        ucPatio.DataBindings.Add(New Binding("Valor", BinSrc, "Patio", True))
        ucPatio.DataBindings.Add(New Binding("ValorCajaTexto1", BinSrc, "MPatio", True))
        ucPatio.DataBindings.Add(New Binding("ValorCajaTexto2", BinSrc, "MPatio2", True))

        ucTerraza.DataBindings.Add(New Binding("Valor", BinSrc, "Terraza", True))
        ucTerraza.DataBindings.Add(New Binding("ValorCajaTexto1", BinSrc, "MTerraza", True))
        ucTerraza.DataBindings.Add(New Binding("ValorCajaTexto2", BinSrc, "MTerraza2", True))


        ucTrasteroVenta.DataBindings.Add(New Binding("Valor", BinSrc, "TrasteroVenta", True))
        ucTrasteroVenta.RGruop.Properties.Items(2).Description = "Opc"
        ucTrasteroVenta.DataBindings.Add(New Binding("ValorCajaTexto1", BinSrc, "PrecioTrasteroVenta", True))
        ucTrasteroVenta.DataBindings.Add(New Binding("ValorCajaTexto2", BinSrc, "MTrastero", True))

        ucTrasteroAlquiler.DataBindings.Add(New Binding("Valor", BinSrc, "TrasteroAlquiler", True))
        ucTrasteroAlquiler.RGruop.Properties.Items(2).Description = "Opc"
        ucTrasteroAlquiler.DataBindings.Add(New Binding("ValorCajaTexto1", BinSrc, "PrecioTrasteroAlquiler", True))
        ucTrasteroAlquiler.DataBindings.Add(New Binding("ValorCajaTexto2", BinSrc, "MTrastero", True))

        ucGarajeVenta.DataBindings.Add(New Binding("Valor", BinSrc, "GarajeVenta", True))
        ucGarajeVenta.RGruop.Properties.Items(2).Description = "Opc"
        ucGarajeVenta.DataBindings.Add(New Binding("ValorCajaTexto1", BinSrc, "PrecioGarajeVenta", True))
        ucGarajeVenta.DataBindings.Add(New Binding("ValorCajaTexto2", BinSrc, "MGaraje", True))
        ucGarajeVenta.DataBindings.Add(New Binding("ValorCheck", BinSrc, "GarajeCerrado", True))

        ucGarajeAlquiler.DataBindings.Add(New Binding("Valor", BinSrc, "GarajeAlquiler", True))
        ucGarajeAlquiler.RGruop.Properties.Items(2).Description = "Opc"
        ucGarajeAlquiler.DataBindings.Add(New Binding("ValorCajaTexto1", BinSrc, "PrecioGarajeAlquiler", True))
        ucGarajeAlquiler.DataBindings.Add(New Binding("ValorCajaTexto2", BinSrc, "MGaraje", True))
        ucGarajeAlquiler.DataBindings.Add(New Binding("ValorCheck", BinSrc, "GarajeCerrado", True))



        ucJardin.DataBindings.Add(New Binding("Valor", BinSrc, "Jardin", True))
        ucJardin.DataBindings.Add(New Binding("ValorCajaTexto1", BinSrc, "MJardin", True))

        spnBaneras.DataBindings.Add(New Binding("EditValue", BinSrc, "Banera", True))
        spnPrecioComunidad.DataBindings.Add(New Binding("EditValue", BinSrc, "PrecioComunidad", True))

 

        UcInmueblesPropietario1.txtNombre.DataBindings.Add(New Binding("EditValue", BinSrc, "Propietario", True))
        UcInmueblesPropietario1.txtTelefono1.DataBindings.Add(New Binding("EditValue", BinSrc, "Telefono1Propietario", True))
        UcInmueblesPropietario1.txtTelefono2.DataBindings.Add(New Binding("EditValue", BinSrc, "Telefono2Propietario", True))
        UcInmueblesPropietario1.txtTelefonoMovil.DataBindings.Add(New Binding("EditValue", BinSrc, "TelefonoMovilPropietario", True))
        UcInmueblesPropietario1.txtEmail.DataBindings.Add(New Binding("EditValue", BinSrc, "EmailPropietario", True))
        UcInmueblesPropietario1.txtCodPropietario.DataBindings.Add(New Binding("EditValue", BinSrc, "ContadorPropietario", True))






        ' LayoutControl1.Items(0).Visibility = False


        ''Combos
        FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbAgrupaciones, "Agrupaciones", "Agrupacion", "Agrupacion")
        FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbPoblacion, "Poblacion", "Poblacion", "Poblacion")
        FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbZona, "Zona", "Zona", "Zona")
        FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbOrientacion, "Orientacion", "Orientacion", "Orientacion")
        FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbEstado, "Estado", "Estado", "Estado")
        FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbTipo, "Tipo", "Tipo", "Tipo")
        FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbPropietarios, "Propietarios", "ContadorPropietario", "Nombre", "Contador")
 


        ParametrizarGrid(Gv, False)

        dgvx.tbCarpetaPerfiles = GL_CARPETA_PERFILES & "\" & Me.Name & "\" & dgvx.Name
        dgvx.ContextMenuStrip = New tbContextMenuStripComponent(dgvx.tbCarpetaPerfiles)
        '  dgvx.ContextMenuStrip.Items.Add("Copiar Perfiles", Nothing, AddressOf CopiarPerfilesDgvX)
        dgvx.ContextMenuStrip.Items.Add("Gestión Documental", Nothing, AddressOf dgvxGestDoc)

        ConfigurarGrid()

        uGestionDocumental = New ucGestionDocumental
        CrearPanelFlotanteNueva(DockManager1, PanelGestionDocumental, uGestionDocumental, 600, 300)

        'uInmueblesPropietario = New ucInmueblesPropietario
        'CrearPanelFlotanteNueva(DockManager1, PanelArticulosVendidos, uInmueblesPropietario, 800, 300)

        CargandoClientes = False

        HabilitarBotones()
        HabilitarDesHabilitarCajas(False)

        PonerFocoRowFilterEnGridView(Gv, CampoInicialBusqueda)
        Try
            Gv.Focus()
        Catch ex As Exception

        End Try


    End Sub
    Private Sub PrepararLlenarCheckCombosClientes(cmb As uc_tb_CombosCheck, Tabla As String)

        cmb.tb_TablaCompleta = Tabla
        cmb.tb_TablaEnlazada = "Clientes" & Tabla
        cmb.tb_Campo = Tabla
        cmb.tb_CampoFiltro = "CodigoCliente"
        cmb.tb_LlenarCompleta()
        cmb.DataBindings.Add(New Binding("tb_ValorBusqueda", BinSrc, "Codigo", True))

    End Sub

    Public Sub LlenarGrid()

        CargandoClientes = True

        Dim FiltroSelect As String

        If FiltroBusqueda = "" Then
            FiltroSelect = " WHERE Baja = 0"
        Else
            FiltroSelect = " WHERE Baja = 0"
            '   FiltroSelect = " WHERE Codigo IN (SELECT DISTINCT CodigoCliente FROM ClientesComerciales WHERE CodigoEmpleado = " & CInt(FiltroBusqueda) & ")"

        End If
   


        Dim FiltroTotal As String = ""
        Dim FiltroCliente As String = ""

        If DeDondeVengo = GL_VENGO_DE_CLIENTES Then
            FiltroCliente = "  Contador IN (SELECT Contador FROM [dbo].[ObtenerReferenciasQueCuadran] (" & ContadorClienteDeDondeVengo & "))"
        End If

        If FiltroSelect = "" Then
            If FiltroCliente <> "" Then
                FiltroTotal = " WHERE " & FiltroCliente
            End If

        Else
            FiltroTotal = FiltroSelect
            If FiltroCliente <> "" Then
                FiltroTotal = FiltroTotal & " AND " & FiltroCliente
            End If

        End If

        SentenciaSQL = "SELECT * FROM v_TodosLosInmuebles " & FiltroTotal & _
                       " ORDER BY Referencia DESC"


        Dim Tab As New Tablas.clTablaGeneral(TablaMantenimiento, , SentenciaSQL)
        bd = New BaseDatos
        Tab.Datos(bd, Tab.ConsultaAEjecutar, , , , , True)

        If PrimeraVez Then
            BinSrc = New BindingSource
        End If
        '   
        BinSrc.DataSource = bd.ds
        BinSrc.DataMember = TablaMantenimiento


        dgvx.DataSource = BinSrc

        CargandoClientes = False

        Try
            If Not PrimeraVez Then
                HacerCambioFila()
            End If

        Catch ex As Exception

        End Try

    End Sub

    'Private Sub CopiarPerfilesDgvX(ByVal sender As Object, ByVal e As System.EventArgs)

    '    'Dim sen As New ToolStripMenuItem
    '    'sen = TryCast(sender, ToolStripMenuItem)


    '    Dim f As New frmCopiarPerfiles
    '    f.lbldgvxABuscar.Text = Me.Name & "/dgvx"
    '    f.ShowDialog()

    '    'frmCopiarPerfiles.lbldgvxABuscar.Text = Me.Name & "/dgvx"
    '    'frmCopiarPerfiles.ShowDialog()
    'End Sub
    Private Sub ConfigurarGrid()

        If Not PrimeraVez Then
            Exit Sub
        End If

        Gv.OptionsView.ColumnAutoWidth = False

        Dim condition1 As StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        condition1.Appearance.BackColor = Color.Moccasin
        condition1.Appearance.Options.UseBackColor = True
        condition1.Condition = FormatConditionEnum.Expression
        condition1.Expression = "[Reservado] = 1"
        Gv.FormatConditions.Add(condition1)


        PrimeraVez = False
        If dgvx.tbEstablecerPerfilPredeterminado() Then
            Exit Sub
        End If



        'GridPasado.OptionsNavigation.EnterMoveNextColumn = True
        'GridPasado.OptionsNavigation.UseTabKey = True
        'GridPasado.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        Gv.OptionsView.ShowGroupPanel = False
        'GridPasado.OptionsBehavior.Editable = False
        'GridPasado.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        'GridPasado.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
        'GridPasado.OptionsView.ColumnAutoWidth = True
        Gv.OptionsView.ShowAutoFilterRow = True

       
        Gv.Columns("CodigoEmpresa").Visible = False
        Gv.Columns("Delegacion").Visible = False
        Gv.Columns("ContadorPropietario").Visible = False
        Gv.Columns("Baja").Visible = False
        Gv.Columns("ContadorPropietario").OptionsColumn.AllowShowHide = False
        Gv.Columns("Reservado").Visible = False
        '  Gv.Columns("FechaAlta").Visible = False
        '    Gv.Columns("FechaUltimaLlamadaPropietario").Visible = False
        '   Gv.Columns("FechaVencimiento").Visible = False
        Gv.Columns("Venta").Visible = False
        Gv.Columns("Alquiler").Visible = False
        Gv.Columns("AlquilerOpcionCompra").Visible = False
        Gv.Columns("Verano").Visible = False
        Gv.Columns("Traspaso").Visible = False
        '   Gv.Columns("Baja").Visible = False
        Gv.Columns("Llaves").Visible = False
        '     Gv.Columns("PrecioVenta").Visible = False
        '    Gv.Columns("PrecioAlquiler").Visible = False
        Gv.Columns("PrecioVeranoJunio").Visible = False
        Gv.Columns("PrecioVeranoJulio").Visible = False
        Gv.Columns("PrecioVeranoAgosto").Visible = False
        Gv.Columns("PrecioTraspaso").Visible = False



        Gv.Columns("PrecioPropietarioVenta").Visible = False
        Gv.Columns("PrecioPropietarioAlquiler").Visible = False
        Gv.Columns("PrecioPropietarioVerano").Visible = False
        Gv.Columns("PrecioPropietarioTraspaso").Visible = False

        Gv.Columns("Gastos").Visible = False

        Gv.Columns("Direccion").Visible = False
        Gv.Columns("Numero").Visible = False
        Gv.Columns("Altura").Visible = False
        Gv.Columns("CodPostal").Visible = False
        ' Gv.Columns("Poblacion").Visible = False
        Gv.Columns("Provincia").Visible = False
        Gv.Columns("Puerta").Visible = False
        Gv.Columns("Metros").Visible = False
        Gv.Columns("Banos").Visible = False
        Gv.Columns("Habitaciones").Visible = False
        Gv.Columns("AnoConstruccion").Visible = False
        Gv.Columns("MPlaya").Visible = False
        Gv.Columns("Ascensor").Visible = False
        Gv.Columns("CocinaOffice").Visible = False
        Gv.Columns("Piscina").Visible = False
        Gv.Columns("Duplex").Visible = False
        Gv.Columns("Galeria").Visible = False
        Gv.Columns("AireAcondicionado").Visible = False
        Gv.Columns("Calefaccion").Visible = False
        '  Gv.Columns("Tipo").Visible = False
        Gv.Columns("Orientacion").Visible = False
        '   Gv.Columns("Zona").Visible = False
        '  Gv.Columns("Estado").Visible = False
        Gv.Columns("Extras").Visible = False
        Gv.Columns("Observaciones").Visible = False
        Gv.Columns("chollo").Visible = False
        Gv.Columns("Escaparate").Visible = False
        Gv.Columns("NOAlquiler").Visible = False
        Gv.Columns("Ocultar").Visible = False
        Gv.Columns("Cartel").Visible = False
        Gv.Columns("Balcon").Visible = False
        Gv.Columns("MBalcon").Visible = False
        Gv.Columns("MBalcon2").Visible = False
        Gv.Columns("Patio").Visible = False
        Gv.Columns("MPatio").Visible = False
        Gv.Columns("MPatio2").Visible = False
        Gv.Columns("Terraza").Visible = False
        Gv.Columns("MTerraza").Visible = False
        Gv.Columns("MTerraza2").Visible = False
        Gv.Columns("Jardin").Visible = False
        Gv.Columns("MJardin").Visible = False
        Gv.Columns("MTrastero").Visible = False
        Gv.Columns("TrasteroVenta").Visible = False
        Gv.Columns("TrasteroAlquiler").Visible = False
        Gv.Columns("PrecioTrasteroVenta").Visible = False
        Gv.Columns("PrecioTrasteroAlquiler").Visible = False
        Gv.Columns("MGaraje").Visible = False
        Gv.Columns("GarajeCerrado").Visible = False
        Gv.Columns("GarajeVenta").Visible = False
        Gv.Columns("GarajeAlquiler").Visible = False
        Gv.Columns("PrecioGarajeVenta").Visible = False
        Gv.Columns("PrecioGarajeAlquiler").Visible = False
        Gv.Columns("SemiAmueblado").Visible = False


        Gv.Columns("Amueblado").Visible = False

        Gv.Columns("Electrodomesticos").Visible = False
        Gv.Columns("Cocina").Visible = False
        Gv.Columns("Calentador").Visible = False
        Gv.Columns("PlatoDucha").Visible = False
        Gv.Columns("Banera").Visible = False
        Gv.Columns("FianzaAlquler").Visible = False
        Gv.Columns("ComunidadIncluida").Visible = False
        Gv.Columns("PrecioComunidad").Visible = False
        Gv.Columns("ZonaComercial").Visible = False

        Gv.Columns("ContadorEmpleado").Visible = False
        Gv.Columns("TextoEscaparate").Visible = False
        Gv.Columns("FotoEscaparate").Visible = False
        Gv.Columns("FotoEscaparate2").Visible = False
        Gv.Columns("Foto").Visible = False
        Gv.Columns("TextoLlaves").Visible = False

        Gv.Columns("Agrupacion").Visible = False
        Gv.Columns("Personas").Visible = False
        Gv.Columns("CamasDobles").Visible = False
        Gv.Columns("CamasIndividuales").Visible = False
        Gv.Columns("SofaCama").Visible = False
        Gv.Columns("PrimeraLineaPlaya").Visible = False
 



        'gvClientes.Columns("Articulo").Width = 280
        'gvClientes.Columns("Codigo").Width = 100

        'gvClientes.Columns("Descuento").Caption = "% Desc."
        'gvClientes.Columns("DescuentoRecalculo").Caption = "% Recalc."

        'gvClientes.Columns("Precio").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric


        'gvClientes.BestFitMaxRowCount = 20
        '  Gv.BestFitColumns()
        'gvClientes.OptionsView.ShowAutoFilterRow = False

        'If Estado = GL_ACEPTADO Then
        '    gvClientes.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        '    gvClientes.OptionsBehavior.Editable = False
        'End If


        'gvClientes.ShowButtonMode = Views.Base.ShowButtonModeEnum.ShowAlways
        '     gvClientes.ShowFindPanel()
        'Sumatorio en el pie del grid
        '   gvClientes.FooterPanelHeight = 20

        '    gvClientes.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always

        'Sumatorios en agrupaciones
        Gv.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways

        Dim ItemArticulo As GridGroupSummaryItem = New GridGroupSummaryItem()
        ItemArticulo.FieldName = "Codigo"
        ItemArticulo.DisplayFormat = "{0:n0}"
        ItemArticulo.SummaryType = DevExpress.Data.SummaryItemType.Count
        Gv.GroupSummary.Add(ItemArticulo)

        Gv.OptionsView.ShowFooter = True
        Gv.Columns("Referencia").SummaryItem.FieldName = "Contador"
        Gv.Columns("Referencia").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        Gv.Columns("Referencia").SummaryItem.DisplayFormat = "Total: {0:n0}"

        'Dim filterString As String = "Nombre LIKE '%a%'"
        'gvClientes.Columns("Nombre").FilterInfo = New Columns.ColumnFilterInfo(ColumnFilterType.Custom, Nothing, filterString)



        '   gvClientes.Columns("Nombre").FilterInfo.Type.Custom()






        'gvClientes.OptionsView.ShowFooter = True
        'gvClientes.Columns("CodigoSIG").SummaryItem.FieldName = "CodigoSIG"
        'gvClientes.Columns("CodigoSIG").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        'gvClientes.Columns("CodigoSIG").SummaryItem.DisplayFormat = "Estudios: {0:n0}"

    End Sub



    'Private Sub MyGridView1_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles Gv.RowCellStyle

    '    Try


    '        Dim View As GridView = sender

    '        If e.Column.FieldName = "Disponible" Then
    '            If e.CellValue < 0 Then
    '                e.Appearance.BackColor = Color.Salmon
    '                e.Appearance.BackColor2 = Color.SeaShell
    '                e.Appearance.GradientMode = Drawing2D.LinearGradientMode.BackwardDiagonal
    '                'Else
    '                '    e.Appearance.BackColor = Color.LightGreen
    '                '    e.Appearance.BackColor2 = Color.GreenYellow
    '                '    'e.Appearance.BackColor = Color.DeepSkyBlue
    '                '    'e.Appearance.BackColor2 = Color.LightCyan

    '            End If
    '        End If

    '    Catch ex As Exception

    '    End Try


    '    'If e.Column.FieldName = "BloqueoTemporal" Then
    '    '    If e.CellValue = True Then
    '    '        e.Appearance.BackColor = Color.PapayaWhip
    '    '        e.Appearance.BackColor2 = Color.Orange
    '    '        e.Appearance.GradientMode = Drawing2D.LinearGradientMode.BackwardDiagonal
    '    '        'Else
    '    '        '    e.Appearance.BackColor = Color.LightGreen
    '    '        '    e.Appearance.BackColor2 = Color.GreenYellow
    '    '        '    'e.Appearance.BackColor = Color.DeepSkyBlue
    '    '        '    'e.Appearance.BackColor2 = Color.LightCyan

    '    '    End If
    '    'End If

    'End Sub




#Region "Mantenimiento Clientes"

    Private Sub btnAnadir_Click(sender As System.Object, e As System.EventArgs) Handles btnAnadir.Click
        Anadir()
    End Sub
    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        Eliminar()
    End Sub

    Private Sub btnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        Modificar()
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Aceptar()

    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub

    Private Sub Anadir()
        EstoyEnAlta = True
        BinSrc.AddNew()
        PrepararAlta()
    End Sub

    Private Sub Modificar(Optional PonermeEnLaPrimeraColumna As Boolean = True)

        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Return
        End If

        EstoyEnAlta = False
        PrepararModificacion()
    End Sub
    Private Sub Eliminar()

        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Return
        End If

        If XtraMessageBox.Show("¿Confirma que quiere eliminar el registro seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
            Exit Sub
        End If

        Eliminando = True
        Dim FilaSeleccionada As Integer = Gv.FocusedRowHandle
        'BinSrc.RemoveCurrent()
        Gv.DeleteRow(Gv.FocusedRowHandle)

        BinSrc.EndEdit()

        If Not ActualizarBaseDatos() Then
            Return
        End If



        HabilitarBotones()
        HabilitarDesHabilitarCajas(False)



        If FilaSeleccionada > 1 Then
            Gv.FocusedRowHandle = FilaSeleccionada - 1
        Else
            Try
                Gv.FocusedRowHandle = FilaSeleccionada + 1
            Catch ex As Exception

            End Try
        End If


        Eliminando = False
    End Sub
    Private Sub Aceptar()
        '  Dim FilaSeleccionada As Integer = GvClientes.FocusedRowHandle

        Actualizar()

        'GvClientes.FocusedRowHandle = FilaSeleccionada
    End Sub
    Private Sub Cancelar()

        BinSrc.CancelEdit()
        HabilitarBotones()
        HabilitarDesHabilitarCajas(False)
    End Sub
    Private Sub PrepararModificacion()

        HabilitarDesHabilitarCajas(True)

        DesHabilitarBotones()
        txtCodigo.Enabled = False
        txtNumero.Focus()

    End Sub

    Private Sub PrepararAlta()

        HabilitarDesHabilitarCajas(True)

        '   FechaAltaDateEdit.EditValue = Microsoft.VisualBasic.Today 'Microsoft.VisualBasic.Format(Microsoft.VisualBasic.Today, "dd/MM/yyyy")
        chkBaja.EditValue = False

        txtCodigo.Text = ""
        txtCodigo.Enabled = False
        '     chkBaja.Enabled = False


        DesHabilitarBotones()

    End Sub

    Private Sub HabilitarDesHabilitarAlquiler(Habilitar As Boolean)
        For Each c As Control In pnlAlquiler.Controls
            c.Enabled = Habilitar
        Next
        If Habilitar Then
            ucGarajeAlquiler.tb_ReadOnly = Not Habilitar
            ucTrasteroAlquiler.tb_ReadOnly = Not Habilitar
        End If


    End Sub

    Private Sub HabilitarDesHabilitarVenta(Habilitar As Boolean)
        For Each c As Control In pnlVenta.Controls
            c.Enabled = Habilitar
        Next
        If Habilitar Then
            ucGarajeVenta.tb_ReadOnly = Not Habilitar
            ucTrasteroVenta.tb_ReadOnly = Not Habilitar
        End If


    End Sub

    Private Sub HabilitarDesHabilitarCajas(Habilitar As Boolean)

        For Each c As Control In pnlDatosGenerales.Controls
            c.Enabled = Habilitar
        Next



        'For Each c As Control In pnlAlquiler.Controls
        '    c.Enabled = Habilitar
        'Next

        'For Each c As Control In pnlVenta.Controls
        '    c.Enabled = Habilitar
        'Next



        If Habilitar Then
            ucBalcon.tb_ReadOnly = Not Habilitar
            ucPatio.tb_ReadOnly = Not Habilitar
            ucTerraza.tb_ReadOnly = Not Habilitar
            ucJardin.tb_ReadOnly = Not Habilitar

            'ucOpcionCompra.tb_ReadOnly = Not Habilitar


            'ucCocina.tb_ReadOnly = Not Habilitar
            'ucCalentador.tb_ReadOnly = Not Habilitar
            ''ucGarajeAlquiler.tb_ReadOnly = Not Habilitar
            ''ucGarajeVenta.tb_ReadOnly = Not Habilitar
            ''ucTrasteroAlquiler.tb_ReadOnly = Not Habilitar
            ''ucTrasteroVenta.tb_ReadOnly = Not Habilitar

            HabilitarDesHabilitarAlquiler(chkAlquiler.Checked)
            HabilitarDesHabilitarVenta(chkVenta.Checked)
        Else

            HabilitarDesHabilitarAlquiler(Habilitar)
            HabilitarDesHabilitarVenta(Habilitar)

        End If


        SliderPequeno.Enabled = True
        SliderGrande.Enabled = True



    End Sub

    Private Function Actualizar() As Boolean
        Try

            Me.Validate()

            If Not ComprobarDatos() Then
                Return False
            End If

            If EstoyEnAlta Then
                BinSrc.Current("FechaAlta") = Microsoft.VisualBasic.Today
                ' BinSrc.Current("Referencia") = clGenerales.SiguienteRegistro("CONVERT(INT,Referencia) ", "Inmuebles", " WHERE Delegacion = 1")
                txtCodigo.EditValue = clGenerales.SiguienteRegistro("CONVERT(INT,Referencia) ", "Inmuebles", " WHERE Delegacion = 1")
                BinSrc.Current("Delegacion") = 1
            Else
                'If Not Eliminando Then
                '    If Gv.GetFocusedRowCellValue("FuturoCliente") = True And BinSrc.Current("FuturoCliente") = 0 Then
                '        MsgBox("")
                '    End If
                'End If

            End If


            'If BinSrc.Item(BinSrc.Count - 1)("Observaciones") Is DBNull.Value Then
            '    BinSrc.Item(BinSrc.Count - 1)("Observaciones") = ""
            'End If

            ActualizaAscensorYGaraje()

            BinSrc.EndEdit()






            Dim ValorClaveAntes As Object = Gv.GetFocusedRowCellValue("Referencia")

            If Not ActualizarBaseDatos() Then
                Return False
            End If



            'Me.ClientesTableAdapter.Update(DsClientes.Clientes)
            'DsClientes.AcceptChanges()
            'Me.ClientesTableAdapter.Fill(Me.DsClientes.Clientes)
            If Not Eliminando AndAlso ValorClaveAntes IsNot Nothing Then
                SituarseEnGrid(Gv, ValorClaveAntes.ToString, "Referencia")
            End If
            HabilitarBotones()
            HabilitarDesHabilitarCajas(False)
            Return True

        Catch ex As SqlClient.SqlException

            XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'DsClientes.RejectChanges()
            'DsClientes.AcceptChanges()

            Return False

        Catch ex2 As Exception

            XtraMessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'DsClientes.RejectChanges()
            'DsClientes.AcceptChanges()
            Return False

        End Try


    End Function



    Private Sub ActualizaAscensorYGaraje()

        'Dim ValorAscensor As String = ""

        'Select Case RadioAscensor.SelectedIndex
        '    Case 0
        '        ValorAscensor = "SI"
        '    Case 1
        '        ValorAscensor = "NO"
        '    Case 2
        '        ValorAscensor = ""

        'End Select

        'BinSrc.Current("Ascensor") = ValorAscensor



    End Sub

    'Private Sub ActualizaDatosCombos(cmb As CheckedComboBoxEdit, Tabla As String, Campo As String)

    '    Try
    '        Dim Sel As String
    '        Dim BdBorra As New BaseDatos
    '        Sel = "DELETE FROM " & Tabla & " WHERE CodigoCliente = '" & txtCodigo.EditValue & "'"
    '        BdBorra.Execute(Sel)

    '        Dim Campos() As String
    '        Campos = Split(cmb.Properties.GetCheckedItems, ";")
    '        For i = 0 To Campos.Count - 1
    '            Sel = "INSERT INTO " & Tabla & " VALUES ('" & txtCodigo.EditValue & "', '" & FuncionesGenerales.Funciones.pf_ReplaceComillas(Campos(i).Trim()) & "' )"
    '            BdBorra.Execute(Sel)
    '        Next

    '        PreparaDatosComboCheck(cmb, Tabla, Campo)

    '    Catch ex As Exception
    '        MensajeError(ex.Message)
    '    End Try
    'End Sub
    Private Function ActualizarBaseDatos() As Boolean

        Try
            bd.ActualizarCambios(TablaMantenimiento, bd.ds)
            'LlenarDataGrid()

            'Cargando = True
            'LlenarDataGrid()
            'Cargando = False

            Return True
        Catch ex As SqlClient.SqlException
            If ex.Number = 2627 Then
                MensajeError(GL_ValorDuplicado)
            Else
                MensajeError(ex.Message)
            End If

            '  bd.ds.RejectChanges()
            Return False
        End Try
    End Function

    Private Function ComprobarDatos() As Boolean
        If txtCodigo.Text.ToString.Trim = "" And Not EstoyEnAlta Then
            MensajeError("El campo código no puede estar vacío")

            txtCodigo.Focus()
            Return False
        End If

        If ucGarajeVenta.chkValorCheck.Checked <> ucGarajeAlquiler.chkValorCheck.Checked Then
            If chkVenta.Checked And chkAlquiler.Checked Then
                MensajeError("Garaje cerrado no puede ser distinto en venta y en alquiler")
                Return False
            End If

            If chkVenta.Checked And Not chkAlquiler.Checked Then
                ucGarajeAlquiler.chkValorCheck.Checked = ucGarajeVenta.chkValorCheck.Checked
            End If
            If Not chkVenta.Checked And chkAlquiler.Checked Then
                ucGarajeVenta.chkValorCheck.Checked = ucGarajeAlquiler.chkValorCheck.Checked
            End If
        End If

        If ucGarajeVenta.spnValorCajaTexto2.EditValue <> ucGarajeAlquiler.spnValorCajaTexto2.EditValue Then
            If chkVenta.Checked And chkAlquiler.Checked Then
                MensajeError("Metros Garaje no puede ser distinto en venta y en alquiler")
                Return False
            End If

            If chkVenta.Checked And Not chkAlquiler.Checked Then
                ucGarajeAlquiler.spnValorCajaTexto2.EditValue = ucGarajeVenta.spnValorCajaTexto2.EditValue
            End If
            If Not chkVenta.Checked And chkAlquiler.Checked Then
                ucGarajeVenta.spnValorCajaTexto2.EditValue = ucGarajeAlquiler.spnValorCajaTexto2.EditValue
            End If
        End If

        If ucTrasteroVenta.spnValorCajaTexto2.EditValue <> ucTrasteroAlquiler.spnValorCajaTexto2.EditValue Then
            If chkVenta.Checked And chkAlquiler.Checked Then
                MensajeError("Metros Trastero no puede ser distinto en venta y en alquiler")
                Return False
            End If

            If chkVenta.Checked And Not chkAlquiler.Checked Then
                ucTrasteroAlquiler.spnValorCajaTexto2.EditValue = ucTrasteroVenta.spnValorCajaTexto2.EditValue

            End If
            If Not chkVenta.Checked And chkAlquiler.Checked Then
                ucTrasteroVenta.spnValorCajaTexto2.EditValue = ucTrasteroAlquiler.spnValorCajaTexto2.EditValue
            End If
        End If


        Return True

    End Function


    Private Sub dgvxClientes_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)

        If e.KeyCode = Keys.Escape And btnAceptar.Enabled = True Then

            Try

                Cancelar()
            Catch ex As Exception

            End Try


            'Try
            '    gvClientes.CancelUpdateCurrentRow()
            '    HabilitarBotones()
            'Catch ex As Exception
            'End Try

            'HabilitarBotones()
        End If

        If e.KeyCode = Keys.F1 And btnAceptar.Enabled = False Then
            Anadir()
            Exit Sub
        End If

        If e.KeyCode = Keys.F2 And btnAceptar.Enabled = False Then
            Eliminar()
            Exit Sub
        End If

        If e.KeyCode = Keys.F3 And btnAceptar.Enabled = False Then
            Modificar(False)
            Exit Sub
        End If

        If e.KeyCode = Keys.F12 Then
            Aceptar()
            Exit Sub
        End If
    End Sub


    Private Sub HabilitarBotones()


        btnAnadir.Enabled = True
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        If bd.ds.Tables(TablaMantenimiento).Rows.Count > 0 Then
            btnModificar.Enabled = True
            btnEliminar.Enabled = True

        End If

        btnAceptar.Enabled = False
        btnCancelar.Enabled = False
        btnSalir.Enabled = True

        dgvx.Enabled = True

        'For Each Page As DevExpress.XtraTab.XtraTabPage In XtraTabControl1.TabPages
        '    Page.PageEnabled = True
        'Next



    End Sub

    Private Sub DesHabilitarBotones()

        btnAnadir.Enabled = False
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        btnSalir.Enabled = False
        btnAceptar.Enabled = True
        btnCancelar.Enabled = True

        dgvx.Enabled = False

        'Dim PaginaSeleccionadaAntes As Integer
        'PaginaSeleccionadaAntes = XtraTabControl1.SelectedTabPageIndex
        'If EstoyEnAlta Then
        '    PaginaSeleccionadaAntes = 0
        'End If

        'For Each Page As DevExpress.XtraTab.XtraTabPage In XtraTabControl1.TabPages
        '    Page.PageEnabled = False
        'Next

        'XtraTabControl1.TabPages(0).PageEnabled = True
        'If EstoyEnAlta = False Then
        '    XtraTabControl1.TabPages(1).PageEnabled = True
        'End If

        'XtraTabControl1.SelectedTabPageIndex = PaginaSeleccionadaAntes
    End Sub

#End Region

    'Private Sub FormaDePagoLookUpEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cmbFormaPago.ButtonClick


    '    If e.Button.Index <> 1 Then
    '        Exit Sub
    '    End If

    '    '   Dim f As New XtraForm
    '    Dim uc As New ucMantenimientos

    '    AbrirMantenimiento(uc, "Formas de Pago")

    '    'f.SuspendLayout()
    '    ''

    '    ''
    '    'f.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    '    'f.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    '    'f.ClientSize = New System.Drawing.Size(658, 262)
    '    'f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
    '    'f.Name = "form2"
    '    'f.Text = "form2"
    '    'f.ResumeLayout(False)


    '    'f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
    '    'uc.Dock = System.Windows.Forms.DockStyle.Fill
    '    'f.Controls.Add(uc)
    '    'f.StartPosition = FormStartPosition.CenterScreen
    '    'f.ControlBox = False
    '    'f.Text = "Formas de Pago"

    '    'f.ShowDialog()

    '    ''f.Size = New System.Drawing.Size(674, 300)
    '    ''uc.Size = New System.Drawing.Size(674, 300)
    'End Sub

    'Public Sub AbrirMantenimiento(uc As Object, Texto As String)
    '    Dim f As New XtraForm
    '    '     Dim uc As New ucMantenimientos



    '    f.SuspendLayout()
    '    '
    '    'form2
    '    '
    '    f.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    '    f.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    '    f.ClientSize = New System.Drawing.Size(658, 262)
    '    f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
    '    'f.Name = "form2"
    '    'f.Text = "form2"
    '    f.ResumeLayout(False)


    '    f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
    '    uc.Dock = System.Windows.Forms.DockStyle.Fill
    '    f.Controls.Add(uc)
    '    f.StartPosition = FormStartPosition.CenterScreen
    '    f.ControlBox = False
    '    f.Text = Texto

    '    f.ShowDialog()
    'End Sub


    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Salir()
    End Sub
    Private Sub Salir()
        Me.ParentForm.Dispose()
    End Sub

    Private Sub MyGridView1_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles Gv.FocusedRowChanged

        Try
            FocusedColor()
            HacerCambioFila()
        Catch ex As Exception

        End Try

    End Sub
    Public Sub FocusedColor()
        Dim b As Color
        Dim a As DataRowView = Gv.GetFocusedRow
        With Gv.Appearance.FocusedRow
            .ForeColor = Color.Black
            If a.Item("Reservado") = True Then
                b = Color.Moccasin
                .BackColor = Color.FromArgb(255, b.R, b.G + 15, b.B + 25)
                Exit Sub
            End If
            .BackColor = Color.FromArgb(255, 80, 160, 240)
            .ForeColor = Color.White
        End With

    End Sub
    Private Sub CargarSlider(slid As ImageSlider, ContadorPropietario As Integer, Referencia As String, Optional Pequenas As Boolean = True)
        '  Dim mySlider As ImageSlider = New ImageSlider()
        'mySlider.Parent = Me
        'mySlider.Size = New Size(240, 200)
        'Populate ImageSlider with images





        Dim Carpeta As String
        Carpeta = My.Application.Info.DirectoryPath & "\Fotos\" & ContadorPropietario.ToString & "-" & Referencia

        '   If Pequenas Then
        Carpeta = Carpeta & "\actualizaweb"
        ' End If

        Dim Fotos() As String = System.IO.Directory.GetFiles(Carpeta)

        For i = 0 To Fotos.Count - 1
            slid.Images.Add(Image.FromFile(Fotos(i)))
        Next

        'slid.Images.Add(Image.FromFile("c:\Images\im1.jpg"))
        'slid.Images.Add(Image.FromFile("c:\Images\im2.jpg"))
        'slid.Images.Add(Image.FromFile("c:\Images\im3.jpg"))
        'slid.Images.Add(Image.FromFile("c:\Images\im4.jpg"))
        'Increase image sliding animation duration (default is 700 ms)
        slid.AnimationTime = 1200
        slid.AllowLooping = True
        slid.Refresh()
        'Display images at the center of ImageSlider in their original size
        slid.LayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.Stretch
    End Sub
    Private Sub HacerCambioFila()

        If CargandoClientes Then
            Exit Sub
        End If

        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Exit Sub
        End If

        If BinSrc.Current("ElectroDomesticosAlquiler") Is DBNull.Value Then
            chkElectrodomesticos.ForeColor = Color.Blue
        End If

        If BinSrc.Current("Inmuebles") Is DBNull.Value Then
            TabInmuebles.TabPages(1).Text = "Propietarios"
        Else
            TabInmuebles.TabPages(1).Text = "Propietarios (" & BinSrc.Current("Inmuebles") & ")"
        End If

        'For i = 0 To ImageSlider1.Images.Count - 1
        '    ImageSlider1.Images.RemoveAt(0)
        'Next

        SliderPequeno.Images.Clear()

        If BinSrc.Current("Inmuebles") IsNot DBNull.Value And BinSrc.Current("Inmuebles") IsNot DBNull.Value Then
            CargarSlider(SliderPequeno, BinSrc.Current("ContadorPropietario"), BinSrc.Current("Referencia"))
        End If


        'Select Case BinSrc.Current("Ascensor").ToString.ToUpper
        '    Case "SI"
        '        RadioAscensor.SelectedIndex = 0
        '    Case "NO"
        '        RadioAscensor.SelectedIndex = 1
        '    Case Else
        '        RadioAscensor.SelectedIndex = 2
        'End Select

        'Select Case BinSrc.Current("Garaje").ToString.ToUpper
        '    Case "SI"
        '        RadioGaraje.SelectedIndex = 0
        '    Case "NO"
        '        RadioGaraje.SelectedIndex = 1
        '    Case Else
        '        RadioGaraje.SelectedIndex = 2
        'End Select





        'uRiesgo.LlenarGrid(Gv.GetFocusedRowCellValue("Referencia"))


        'For i = 0 To pnlContactos.Controls.Count - 1
        '    pnlContactos.Controls.Remove(pnlContactos.Controls(0))
        'Next

        'Dim uClientesContactos As New Igis.ucMantenimientos(GL_ClientesContactos, Gv.GetFocusedRowCellValue("Referencia").ToString, False, False)
        ''pnlContactos.Controls.Add(u)

        'uClientesContactos.Dock = DockStyle.Fill
        'pnlContactos.Controls.Add(uClientesContactos)


        'For i = 0 To plnDireccionesEnvio.Controls.Count - 1
        '    plnDireccionesEnvio.Controls.Remove(plnDireccionesEnvio.Controls(0))
        'Next

        'Dim uDireccionesEnvio As New Igis.ucMantenimientos(GL_DireccionesEnvio, Gv.GetFocusedRowCellValue("Referencia").ToString, False, False)
        ''pnlContactos.Controls.Add(u)

        'uDireccionesEnvio.Dock = DockStyle.Fill
        'plnDireccionesEnvio.Controls.Add(uDireccionesEnvio)

        'If PanelComercialesClientes.Visibility = DockVisibility.Visible Then
        '    uComercialesClientes.LlenarGrid(Gv.GetFocusedRowCellValue("Referencia"), 0, 0)
        'End If

         

        'If PanelGestionDocumental.Visibility = DockVisibility.Visible Then
        '    uGestionDocumental.RefrescarBotones(Gv.GetFocusedRowCellValue(CampoGestionDocumental), TablaGestionDocumental)
        'End If

    End Sub
    Private Sub LlenarCombosAuxiliaresSoloConSusDatos(cmb As CheckedComboBoxEdit, Tabla As String, Campo As String, Optional Filtro As String = "")

        Dim bdPobs As New BaseDatos()
        Dim Tab As New Tablas.clTablaGeneral(Tabla, , "SELECT " & Campo & " FROM " & Tabla & " WHERE CodigoCliente = '" & Gv.GetFocusedRowCellValue("Codigo") & "'", )
        bdPobs = New BaseDatos
        Tab.Datos(bdPobs, Tab.ConsultaAEjecutar, , , , , True)

        cmb.Properties.DataSource = Nothing
        cmb.Properties.DataSource = bdPobs.ds.Tables(Tab.Tabla)

        cmb.Properties.DisplayMember = Campo
        ' cmbpob.Properties.ValueMember = "Poblacion"

        'Dim dtr As SqlDataReader
        'Dim bdPobs As New BaseDatos()
        'Dim Sel As String
        'If Filtro <> "" Then

        'End If
        'Sel = "SELECT " & Campo & " FROM " & Tabla & " WHERE CodigoCliente = '" & Gv.GetFocusedRowCellValue("Codigo") & "'"
        'Dim Elementos As String = ""
        'dtr = bdPobs.ExecuteReader(Sel)
        'If dtr.HasRows Then
        '    While dtr.Read
        '        If Elementos = "" Then
        '            Elementos = dtr(Campo)
        '        Else
        '            Elementos = Elementos & ";" & dtr(Campo)
        '        End If

        '    End While
        'End If
        'bdPobs.CerrarBD()

        'cmb.Properties.DisplayMember = Campo
        'cmb.Properties.SeparatorChar = ";"
        'cmb.SetEditValue(Elementos)

        For Each c As CheckedListBoxItem In cmb.Properties.Items
            c.Enabled = False
            c.Value = True
        Next

    End Sub
    Private Sub LlenarCombosAuxiliaresCompletos(cmb As CheckedComboBoxEdit, Tabla As String, Campo As String, Optional Filtro As String = "")

        Dim bdPobs As New BaseDatos()
        Dim Tab As New Tablas.clTablaGeneral(Tabla, , "SELECT " & Campo & " FROM  " & Tabla & " ORDER BY " & Campo, )
        bdPobs = New BaseDatos
        Tab.Datos(bdPobs, Tab.ConsultaAEjecutar, , , , , True)

        cmb.Properties.DataSource = Nothing
        cmb.Properties.Items.Clear()
        cmb.Properties.DataSource = bdPobs.ds.Tables(Tab.Tabla)

        cmb.Properties.DisplayMember = Campo
        cmb.Properties.ValueMember = Campo
        cmb.Properties.SeparatorChar = ";"


    End Sub
    '' Disable the items that have the Discontinued field set to true
    'Private Sub CheckedListBoxControl1_GetItemEnabled(ByVal sender As System.Object, _
    '    ByVal e As GetItemEnabledEventArgs) _
    '    Handles cmbpob.GetItemEnabled
    '    'Dim control As CheckedListBoxControl = TryCast(sender, CheckedListBoxControl)
    '    'Dim isDiscontinued As Boolean = CBool((TryCast((TryCast(control.DataSource,  _
    '    '    BindingSource))(e.Index), DataRowView))("Discontinued"))
    '    'If isDiscontinued Then
    '    e.Enabled = False

    '    'End If
    'End Sub


     


    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs)

        If FiltroBusqueda <> "" Then
            Gl_ResultadoBusqueda = ""
            FiltroBusqueda = ""
            LlenarGrid()
            btnBuscar.Text = TextoInicialBotonBuscar
            btnBuscar.ForeColor = ColorInicialBotonBuscar
            Return
        End If



        Gl_ResultadoBusqueda = ""

        Try
            Dim f As New frmBuscar(EnumResultadoBusqueda.VENDEDOR)
            f.ShowDialog()
        Catch ex As Exception

        End Try

        If FiltroBusqueda = Gl_ResultadoBusqueda Then
            Return
        End If

        If Gl_ResultadoBusqueda <> "" Then
            FiltroBusqueda = Gl_ResultadoBusqueda
            LlenarGrid()
            btnBuscar.Text = "FILTRADO"
            btnBuscar.ForeColor = Color.Red
        Else
            Gl_ResultadoBusqueda = ""
            FiltroBusqueda = ""
            LlenarGrid()
            btnBuscar.Text = TextoInicialBotonBuscar
            btnBuscar.ForeColor = ColorInicialBotonBuscar
            '      View.EditingValue = Gl_ResultadoBusqueda
        End If




    End Sub






    Private Sub dgvxGestDoc(ByVal sender As Object, ByVal e As System.EventArgs)

        'Dim sen As New ToolStripMenuItem
        'sen = TryCast(sender, ToolStripMenuItem)


        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Exit Sub
        End If

        'Dim tbContextMenuStripComponentjose As New tbContextMenuStripComponent
        'tbContextMenuStripComponentjose = sen.GetCurrentParent


        If PanelGestionDocumental IsNot Nothing AndAlso PanelGestionDocumental.Visibility = DockVisibility.Visible Then
            PanelGestionDocumental.Visibility = DockVisibility.Hidden
        Else
            '   PrepararPanelRiesgo()
            ' CrearPanelFlotante()
            Dim s As New Size
            s = PanelGestionDocumental.Size

            PanelGestionDocumental.Visibility = DockVisibility.Visible
            PanelGestionDocumental.FloatSize = s

            uGestionDocumental.RefrescarBotones(Gv.GetFocusedRowCellValue(CampoGestionDocumental).ToString, TablaGestionDocumental)
        End If
    End Sub

    Private Sub UcInmueblesPropietario1_dgvxDatosPropietariosDoubleClick(sender As Object, e As System.EventArgs) Handles UcInmueblesPropietario1.dgvxDatosPropietariosDoubleClick
        'Dim PaginaSeleccionadaAntes As Integer
        'PaginaSeleccionadaAntes = XtraTabControl1.SelectedTabPageIndex
        'If EstoyEnAlta Then
        '    PaginaSeleccionadaAntes = 0
        'End If

        'For Each Page As DevExpress.XtraTab.XtraTabPage In XtraTabControl1.TabPages
        '    Page.PageEnabled = False
        'Next

        'XtraTabControl1.TabPages(0).PageEnabled = True
        'If EstoyEnAlta = False Then
        '    XtraTabControl1.TabPages(1).PageEnabled = True
        'End If

        Dim op As DevExpress.Data.Filtering.CriteriaOperator = Gv.ActiveFilterCriteria 'filterControl1.FilterCriteria
        FiltroAntesBusquedaPropietario = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op)
        PosicionAntesBusquedaPropietario = BinSrc.Position
        FiltroAntesBusquedaPropietario = Gv.ActiveFilterString
        CargandoClientes = True

        Gv.ActiveFilterString = ""
        CargandoClientes = False

        TabInmuebles.SelectedTabPageIndex = 0
        BinSrc.Filter = "Referencia = " & UcInmueblesPropietario1.Gv.GetFocusedRowCellValue("Referencia")
        '  txtCodigo.EditValue = UcInmueblesPropietario1.Gv.GetFocusedRowCellValue("Referencia")


    End Sub


 


    Private Sub TabInmuebles_SelectedPageChanged(sender As System.Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles TabInmuebles.SelectedPageChanged
        If TabInmuebles.SelectedTabPageIndex = 1 And BinSrc.Filter <> "" Then
            BinSrc.Filter = ""
            CargandoClientes = True
            Gv.ActiveFilterString = FiltroAntesBusquedaPropietario
            CargandoClientes = False
            FiltroAntesBusquedaPropietario = ""
            BinSrc.Position = PosicionAntesBusquedaPropietario
            Gv.Focus()

        End If

    End Sub



    Private Sub SliderPequeno_DoubleClick(sender As Object, e As System.EventArgs) Handles SliderPequeno.DoubleClick
        If BinSrc.Current("Inmuebles") IsNot DBNull.Value And BinSrc.Current("Inmuebles") IsNot DBNull.Value Then
            '  pnlDatosGenerales.Visible = False
            SliderGrande.Top = pnlDatosGenerales.Top
            SliderGrande.Left = pnlDatosGenerales.Left

            SliderGrande.Height = pnlDatosGenerales.Height
            SliderGrande.Width = pnlDatosGenerales.Height

            CargarSlider(SliderGrande, BinSrc.Current("ContadorPropietario"), BinSrc.Current("Referencia"))

            SliderGrande.Visible = True

        End If
    End Sub

    Private Sub SliderGrande_DoubleClick(sender As Object, e As System.EventArgs) Handles SliderGrande.DoubleClick
        SliderGrande.Visible = False
    End Sub

    Private Sub chkVenta_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkVenta.CheckedChanged
        If chkVenta.Enabled Then
            HabilitarDesHabilitarVenta(chkVenta.Checked)
        End If

    End Sub

    Private Sub chkAlquiler_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAlquiler.CheckedChanged
        If chkAlquiler.Enabled Then
            HabilitarDesHabilitarAlquiler(chkAlquiler.Checked)
        End If

    End Sub

    
    Private Sub btnDatosPropietarios_Click(sender As System.Object, e As System.EventArgs) Handles btnDatosPropietarios.Click

    End Sub

    Private Sub SimpleButton1_Click(sender As System.Object, e As System.EventArgs) Handles SimpleButton1.Click

    End Sub

    Private Sub btnFotos_Click(sender As System.Object, e As System.EventArgs) Handles btnFotos.Click

    End Sub

    Private Sub btnBuscar_Click_1(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click

    End Sub

    Private Sub SimpleButton3_Click(sender As System.Object, e As System.EventArgs) Handles SimpleButton3.Click

    End Sub

    Private Sub btnBaja_Click(sender As System.Object, e As System.EventArgs) Handles btnBaja.Click

    End Sub

    Private Sub btnClientes_Click(sender As System.Object, e As System.EventArgs) Handles btnClientes.Click
        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Return
        End If

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        CargarFormulario("Clientes", True, GL_VENGO_DE_INMUEBLES, BinSrc.Current("Contador").ToString)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow

        Exit Sub
        '  For Each frm As DevExpress.XtraEditors.XtraForm In Me.MdiChildren



        Try
            Application.OpenForms.Item("Inmuebles").Dispose()

        Catch ex As Exception

        End Try

        'If uInmueblesActivo IsNot Nothing Then
        '    uInmueblesActivo = Nothing
        '    '   uInmueblesActivo.Dispose()
        'End If

        'For Each frm In frmPrincipal.MdiChildren

        '    If frm.Name = "Inmuebles" Then
        '        frm.Dispose()
        '        Exit Sub
        '    End If
        'Next

        'Me.Cursor = System.Windows.Forms.Cursors.WaitCursor


        Dim p As New XtraForm1("Inmuebles")
        p.Name = "Inmuebles"
        p.ControlBox = False

        '  Dim u As Object


        uInmueblesActivo = New ucInmuebles
        uInmueblesActivo.Dock = DockStyle.Fill
        p.Controls.Add(uInmueblesActivo)






        'u.Dock = DockStyle.Fill
        'p.Controls.Add(u)




        p.MdiParent = frmPrincipal
        p.Show()


        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub

    Private Sub btnVerBajas_Click(sender As System.Object, e As System.EventArgs) Handles btnVerBajas.Click

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor


        If TablaInmuebles = GL_TablaClientes Then
            TablaInmuebles = GL_TablaClientesBaja
            btnBaja.ForeColor = Color.Red
            btnBaja.Text = "Dar de Alta"
            btnVerBajas.ForeColor = Color.Red
            btnVerBajas.Text = "Ver Altas"
            btnVerBajas.Image = My.Resources.VerAltas
            btnBaja.Image = My.Resources.DarDeAlta
        Else
            TablaInmuebles = GL_TablaClientes
            btnBaja.ForeColor = ColorInicialBotonBajas
            btnBaja.Text = "Dar de Baja"
            btnVerBajas.ForeColor = ColorInicialBotonBajas
            btnVerBajas.Text = "Ver Bajas"
            btnVerBajas.Image = My.Resources.VerBajas
            btnBaja.Image = My.Resources.DarDeBaja
        End If



        LlenarGrid()


        Me.Cursor = System.Windows.Forms.Cursors.Arrow

    End Sub


    Private Sub txtBusquedaEmailTelefono_Properties_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

    End Sub
End Class
 



