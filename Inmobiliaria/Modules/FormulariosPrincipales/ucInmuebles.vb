
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraGrid
Imports DevExpress.XtraBars.Docking
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraPrinting
Imports System.IO
Imports DevExpress.Utils
Imports System.Xml
Imports RestSharp
Imports System.ServiceModel
Imports System.Net
Imports Ionic.Zip
Imports DevExpress.Internal

Partial Public Class ucInmuebles

    Inherits DevExpress.XtraEditors.XtraUserControl

#Region "Variables"

    Dim GridPrincipal As GridView

    Public NuevoInmueble As Boolean

    Dim FiltroAntesBusquedaPropietario As String = ""
    Dim BinsrcAntesBusquedaPropietario As String = ""
    Dim EstoyEnDobleClickDeInmueblesPropietario As Boolean

    Dim PosicionAntesBusquedaPropietario As Integer = 0

    Dim AP As ActualizaPerfil

    Dim Eliminando As Boolean = False
    Dim menu As DXPopupMenu
    Public PopupMenu As DXPopupMenu
    Dim EstoyEnAlta As Boolean

    Public bd As BaseDatos
    Public WithEvents BinSrc As BindingSource
    Dim TablaMantenimiento As String = "Inmuebles"
    Dim CargandoInmuebles As Boolean = True
    Dim PrimeraVez As Boolean

    Public TablaInmuebles As String
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
    Dim MenuGrid As tbContextMenuStripComponent

    Dim AnadirCheckColunm As Boolean = True
    Dim BuscandoPorTelefonoEmail As Boolean = False
    Dim ValorCartelAntes As Boolean

    Dim PrecioAntes As Integer = 0


    Dim AltoVentana As Integer = 0
    Dim PulsadoVerBajas As Boolean = False

    Dim Portal As String

    Dim changing As Boolean = False

    Private mostrarFocus As Boolean = True

    Dim VerReservasPC As Boolean
    Dim VerBajasPC As Boolean

#End Region

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

    Private p_ContadorPropietarioDeDondeVengo As Integer

    Public Property ContadorPropietarioDeDondeVengo As Integer
        Get
            Return p_ContadorPropietarioDeDondeVengo
        End Get
        Set(value As Integer)
            p_ContadorPropietarioDeDondeVengo = value
        End Set
    End Property

    Private p_ContadorInmuebleAlQueVoy As Integer

    Public Property ContadorInmuebleAlQueVoy As Integer
        Get
            Return p_ContadorInmuebleAlQueVoy
        End Get
        Set(value As Integer)
            p_ContadorInmuebleAlQueVoy = value
        End Set
    End Property


    Private Function ObtenerEscalador() As SizeF

        'Dim   AnchoInicial As Integer = 1280
        'Dim   AltoInicial As Integer = 1024

        Dim AnchoInicial As Integer = 1920
        Dim AltoInicial As Integer = 1080


        'Dim AnchoInicial As Integer = 1024
        'Dim AltoInicial As Integer = 768

        Dim ancho As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim alto As Integer = Screen.PrimaryScreen.Bounds.Height

        Dim aux As Integer = 1
        'indica como es la pantalla de despliegue respecto a la de programación. 
        If ancho > AnchoInicial Then
            If alto > AltoInicial Then
                aux = 1 'ancho mayor, alto mayor 
            Else
                aux = 2 'ancho mayor, alto menor o igual 
            End If
        Else
            If alto > AltoInicial Then
                aux = 3 'ancho menor o igual, alto mayor 
            Else
                aux = 4 'ancho menor o igual, alto menor o igual 
            End If
        End If

        Dim escalador As SizeF

        Select Case aux
            Case 1 'ancho mayor, alto mayor 
                escalador = New SizeF(ancho / AnchoInicial, alto / AltoInicial)
                Exit Select

            Case 2 'ancho mayor, alto menor o igual 
                escalador = New SizeF(ancho / AnchoInicial, alto / AltoInicial)
                Exit Select

            Case 3 'ancho menor o igual, alto mayor 
                escalador = New SizeF(ancho / AnchoInicial, alto / AltoInicial)
                Exit Select

            Case 4 'ancho menor o igual, alto menor o igual 
                escalador = New SizeF(ancho / AnchoInicial, alto / AltoInicial)
                Exit Select

            Case Else
                Exit Select
        End Select


        Return escalador

    End Function


    Private Sub ucInmuebles_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        VerReservasPC = False
        VerBajasPC = False

        If DeDondeVengo.Contains("Portal") Then
            If DeDondeVengo.ToUpper.Contains("FOTOCASA") Then
                btnDespublicar.Visible = True
                btnCreaJsonFotocasa.Visible = True
            Else
                btnDespublicar.Visible = False
                btnCreaJsonFotocasa.Visible = False
            End If
            Portal = DeDondeVengo.Split("|")(1)
            pnlPortales.Visible = True
            pnlPortales.BringToFront()
        End If

        GL_ColorOriginal = PanelControl3.BackColor
        EstoyEnDobleClickDeInmueblesPropietario = False
        AparienciaGeneral()

        '  Dim Escalador As SizeF = ObtenerEscalador()


        Dim ancho As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim alto As Integer = Screen.PrimaryScreen.Bounds.Height

        Dim X_Inicial As Integer = 250
        Dim Y_Inicial As Integer = 95

        If ancho = 1280 And alto = 1024 Then
            X_Inicial = 550
            Y_Inicial = 108
        End If

        If ancho = 1920 And alto = 1080 Then
            X_Inicial = 240
            Y_Inicial = 130
        End If



        'Dim p As New Point

        'Dim x, y As Integer
        'x = X_Inicial
        'y = Y_Inicial
        ''  y = Me.Height - TabInmuebles.Height - Y_Inicial


        'p.X = x
        'p.Y = y
        'btnReservar.Location = p


        'x = p.X + btnReservar.Width + 5

        'p.X = x
        'btnVisitas.Location = p

        'x = p.X + btnVisitas.Width + 5

        'p.X = x
        'btnDirecciones.Location = p

        CargandoInmuebles = True
        PrimeraVez = True
        TextoInicialBotonBuscar = btnReservar.Text
        ColorInicialBotonBuscar = btnReservar.ForeColor

        TablaGestionDocumental = "Inmuebles"
        CampoGestionDocumental = "Contador"

        TablaInmuebles = GL_TablaInmuebles
        'GL_VENGO_DE_CLIENTES


        LlenarGrid()
        CargandoInmuebles = True

        ColorInicialBotonBajas = btnVerBajas.ForeColor

        ' ''Bindings

        '    btnReservar.DataBindings.Add(New Binding("Tag", BinSrc, "Reservado", True))
        txtObservaciones.DataBindings.Add(New Binding("EditValue", BinSrc, "Observaciones", True))

        txtDireccionMapa.DataBindings.Add(New Binding("EditValue", BinSrc, "DireccionMapa", True))


        txtReferencia.DataBindings.Add(New Binding("EditValue", BinSrc, "Referencia", True))
        txtCodPostal.DataBindings.Add(New Binding("EditValue", BinSrc, "CodPostal", True))
        txtDireccion.DataBindings.Add(New Binding("EditValue", BinSrc, "Direccion", True))
        txtNumero.DataBindings.Add(New Binding("EditValue", BinSrc, "Numero", True))
        txtPuerta.DataBindings.Add(New Binding("EditValue", BinSrc, "Puerta", True))
        txtProvincia.DataBindings.Add(New Binding("EditValue", BinSrc, "Provincia", True))
        txtContadorPropietario.DataBindings.Add(New Binding("EditValue", BinSrc, "ContadorPropietario", True))
        txtPropietario.DataBindings.Add(New Binding("EditValue", BinSrc, "Propietario", True))

        txtExtras.DataBindings.Add(New Binding("EditValue", BinSrc, "Extras", True))

        mskFechaAlta.DataBindings.Add(New Binding("EditValue", BinSrc, "FechaAlta", True))
        mskUltimaVisita.DataBindings.Add(New Binding("EditValue", BinSrc, "UltimaVisita", True))

        spnMetros.DataBindings.Add(New Binding("EditValue", BinSrc, "Metros", True))
        txtMPlaya.DataBindings.Add(New Binding("EditValue", BinSrc, "MPlaya", True))

        txtDireccion2.DataBindings.Add(New Binding("EditValue", BinSrc, "Direccion2", True))
        spnAltura2.DataBindings.Add(New Binding("Tag", BinSrc, "Altura", True))


        spnAltura.DataBindings.Add(New Binding("Tag", BinSrc, "Altura", True))
        spnAnoConstruccion.DataBindings.Add(New Binding("EditValue", BinSrc, "AnoConstruccion", True))
        spnBanos.DataBindings.Add(New Binding("EditValue", BinSrc, "Banos", True))
        spnHabitaciones.DataBindings.Add(New Binding("EditValue", BinSrc, "Habitaciones", True))


        chkEnviadaFicha.DataBindings.Add(New Binding("CheckState", BinSrc, "EnviadaFicha", True))

        chkVivenEnEl.DataBindings.Add(New Binding("CheckState", BinSrc, "VivenEnEl", True))
        chkLlaves.DataBindings.Add(New Binding("CheckState", BinSrc, "Llaves", True))
        chkLlavesCanet.DataBindings.Add(New Binding("CheckState", BinSrc, "LlavesCanet", True))
        chkFotosRevisar.DataBindings.Add(New Binding("CheckState", BinSrc, "FotosRevisar", True))

        chkAscensor.DataBindings.Add(New Binding("CheckState", BinSrc, "Ascensor", True))
        chkDuplex.DataBindings.Add(New Binding("CheckState", BinSrc, "Duplex", True))
        chkGaleria.DataBindings.Add(New Binding("CheckState", BinSrc, "Galeria", True))
        chkPiscina.DataBindings.Add(New Binding("CheckState", BinSrc, "Piscina", True))

        chkCocinaOffice.DataBindings.Add(New Binding("CheckState", BinSrc, "CocinaOffice", True))
        chkUrbanizacion.DataBindings.Add(New Binding("CheckState", BinSrc, "Urbanizacion", True))
        chkZonaComercial.DataBindings.Add(New Binding("CheckState", BinSrc, "ZonaComercial", True))
        chkVistasAlMar.DataBindings.Add(New Binding("CheckState", BinSrc, "VistasAlMar", True))
        chkPlayaDerecha.DataBindings.Add(New Binding("CheckState", BinSrc, "PlayaDerecha", True))
        chkAccesoMinusvalidos.DataBindings.Add(New Binding("CheckState", BinSrc, "AccesoMinusvalidos", True))

        chkMostrarPPrincipalWeb.DataBindings.Add(New Binding("CheckState", BinSrc, "MostrarPPrincipalWeb", True))


        chkElectrodomesticos.DataBindings.Add(New Binding("CheckState", BinSrc, "Electrodomesticos", True))
        chkOportunidad.DataBindings.Add(New Binding("CheckState", BinSrc, "Oportunidad", True))
        chkExclusiva.DataBindings.Add(New Binding("CheckState", BinSrc, "Exclusiva", True))
        chkEscaparate.DataBindings.Add(New Binding("CheckState", BinSrc, "Escaparate", True))

        chkCartel.DataBindings.Add(New Binding("CheckState", BinSrc, "Cartel", True))
        '    spnOpcionCompra.DataBindings.Add(New Binding("EditValue", BinSrc, "AlquilerOpcionCompra", True))
        chkOpcionCompra.DataBindings.Add(New Binding("CheckState", BinSrc, "AlquilerOpcionCompra", True))
        chkAlquilerVacacional.DataBindings.Add(New Binding("CheckState", BinSrc, "AlquilerVacacional", True))

        chkAmuebladoVenta.DataBindings.Add(New Binding("CheckState", BinSrc, "Amueblado", True))
        chkSemiAmuebladoVenta.DataBindings.Add(New Binding("CheckState", BinSrc, "SemiAmueblado", True))
        chkPrimeraLineaPlaya.DataBindings.Add(New Binding("CheckState", BinSrc, "PrimeraLineaPlaya", True))
        chkCalefaccion.DataBindings.Add(New Binding("CheckState", BinSrc, "Calefaccion", True))
        chkAireAcondicionado.DataBindings.Add(New Binding("CheckState", BinSrc, "AireAcondicionado", True))
        chkBanco.DataBindings.Add(New Binding("CheckState", BinSrc, "Banco", True))

        'ucCalentador.DataBindings.Add(New Binding("Valor", BinSrc, "Calentador", True))
        'ucCocina.DataBindings.Add(New Binding("Valor", BinSrc, "Cocina", True))


        spnPrecioPropietarioVenta.DataBindings.Add(New Binding("EditValue", BinSrc, "PrecioPropietario", True))
        txtImporteHipoteca.DataBindings.Add(New Binding("EditValue", BinSrc, "Gastos", True))

        chkMontana.DataBindings.Add(New Binding("CheckState", BinSrc, "Montana", True))


        chkBalcon.DataBindings.Add(New Binding("CheckState", BinSrc, "Balcon", True))
        spnBalconM1.DataBindings.Add(New Binding("EditValue", BinSrc, "MBalcon", True))
        spnBalconM2.DataBindings.Add(New Binding("EditValue", BinSrc, "MBalcon2", True))

        chkPatio.DataBindings.Add(New Binding("CheckState", BinSrc, "Patio", True))
        spnPatioM1.DataBindings.Add(New Binding("EditValue", BinSrc, "MPatio", True))
        spnPatioM2.DataBindings.Add(New Binding("EditValue", BinSrc, "MPatio2", True))

        chkTerraza.DataBindings.Add(New Binding("CheckState", BinSrc, "Terraza", True))
        spnTerrazaM1.DataBindings.Add(New Binding("EditValue", BinSrc, "MTerraza", True))
        spnTerrazaM2.DataBindings.Add(New Binding("EditValue", BinSrc, "MTerraza2", True))

        chkJardin.DataBindings.Add(New Binding("CheckState", BinSrc, "Jardin", True))
        spnJardinM1.DataBindings.Add(New Binding("EditValue", BinSrc, "MJardin", True))

        chkOcultar.DataBindings.Add(New Binding("CheckState", BinSrc, "Ocultar", True))
        chkAlquiladoNosotros.DataBindings.Add(New Binding("CheckState", BinSrc, "AlquiladoPorNosotros", True))

        spnMetrosTrastero.DataBindings.Add(New Binding("EditValue", BinSrc, "MTrastero", True))
        spnMetrosGaraje.DataBindings.Add(New Binding("EditValue", BinSrc, "MGaraje", True))
        chkGarajeCerrado.DataBindings.Add(New Binding("CheckState", BinSrc, "GarajeCerrado", True))

        spnTrasteroNumero.DataBindings.Add(New Binding("EditValue", BinSrc, "TrasteroNumero", True))
        spnGarajeNumero.DataBindings.Add(New Binding("EditValue", BinSrc, "GarajeNumero", True))


        spnPrecio.DataBindings.Add(New Binding("EditValue", BinSrc, "Precio", True))
        spnPrecioGaraje.DataBindings.Add(New Binding("EditValue", BinSrc, "PrecioGaraje", True))
        spnPrecioTrastero.DataBindings.Add(New Binding("EditValue", BinSrc, "PrecioTrastero", True))
        ucTrasteroVenta.DataBindings.Add(New Binding("Valor", BinSrc, "Trastero", True))
        ucGarajeVenta.DataBindings.Add(New Binding("Valor", BinSrc, "Garaje", True))

        spnPersonas.DataBindings.Add(New Binding("EditValue", BinSrc, "Personas", True))

        ucTipoCalentador.DataBindings.Add(New Binding("Valor", BinSrc, "TipoCalentador", True))
        ucTipoCocina.DataBindings.Add(New Binding("Valor", BinSrc, "TipoCocina", True))
        spnPrecioJunio.DataBindings.Add(New Binding("EditValue", BinSrc, "PrecioJunio", True))
        spnPrecioJulio.DataBindings.Add(New Binding("EditValue", BinSrc, "PrecioJulio", True))
        spnPrecioAgosto.DataBindings.Add(New Binding("EditValue", BinSrc, "PrecioAgosto", True))
        spnAlturaFinca.DataBindings.Add(New Binding("EditValue", BinSrc, "AlturaFinca", True))

        spnPrecioComunidad.DataBindings.Add(New Binding("EditValue", BinSrc, "PrecioComunidad", True))
        spnFianzaAlquiler.DataBindings.Add(New Binding("EditValue", BinSrc, "FianzaAlquiler", True))
        chkComunidadIncluida.DataBindings.Add(New Binding("CheckState", BinSrc, "ComunidadIncluida", True))

        UcInmueblesPropietario1.txtNombre.DataBindings.Add(New Binding("EditValue", BinSrc, "Propietario", True))
        UcInmueblesPropietario1.txtTelefono1.DataBindings.Add(New Binding("EditValue", BinSrc, "Telefono1Propietario", True))
        UcInmueblesPropietario1.txtTelefono2.DataBindings.Add(New Binding("EditValue", BinSrc, "Telefono2Propietario", True))
        UcInmueblesPropietario1.txtTelefono3.DataBindings.Add(New Binding("EditValue", BinSrc, "Telefono3Propietario", True))
        UcInmueblesPropietario1.txtTelefono4.DataBindings.Add(New Binding("EditValue", BinSrc, "Telefono4Propietario", True))
        UcInmueblesPropietario1.txtTelefonoMovil.DataBindings.Add(New Binding("EditValue", BinSrc, "TelefonoMovilPropietario", True))
        UcInmueblesPropietario1.txtEmail.DataBindings.Add(New Binding("EditValue", BinSrc, "EmailPropietario", True))
        UcInmueblesPropietario1.txtCodPropietario.DataBindings.Add(New Binding("EditValue", BinSrc, "ContadorPropietario", True))
        UcInmueblesPropietario1.chkAviso3.DataBindings.Add(New Binding("CheckState", BinSrc, "AvisadoTresPorCien", True))
        UcInmueblesPropietario1.chkMensual.DataBindings.Add(New Binding("CheckState", BinSrc, "AvisadoMensualidad", True))
        UcInmueblesPropietario1.chkNoInmo.DataBindings.Add(New Binding("CheckState", BinSrc, "NoInmobiliaria", True))
        UcInmueblesPropietario1.chkNoExtranjeros.DataBindings.Add(New Binding("CheckState", BinSrc, "NoExtranjeros", True))
        UcInmueblesPropietario1.chkSeguroVivienda.DataBindings.Add(New Binding("CheckState", BinSrc, "SeguroVivienda", True))

        UcInmueblesPropietario1.chkNoAnimales.DataBindings.Add(New Binding("CheckState", BinSrc, "NoAnimales", True))
        UcInmueblesPropietario1.chkNoQuiereRecibirEmails.DataBindings.Add(New Binding("CheckState", BinSrc, "NoQuiereRecibirEmails", True))

        ' LayoutControl1.Items(0).Visibility = False


        '  FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbPropietarios, "Propietarios", "ContadorPropietario", "Nombre", "Contador")
        Select Case GL_TipoBD
            Case EnumTipoBD.SQL_SERVER
                FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbEstado, "Estado", "Estado", "Estado", , , , "SELECT TOP 1 '' AS Estado, '' as TipoPrioridad, 9999 AS Prioridad FROM Estado UNION ALL SELECT Estado,TipoPrioridad,Prioridad FROM Estado ORDER BY Prioridad DESC")
                'FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbTipo, "Tipo", "Tipo", "Tipo", , , , "SELECT TOP 1 '' AS Tipo, '' as TipoPrioridad, 9999 AS Prioridad FROM Tipo UNION ALL SELECT Tipo,TipoPrioridad,Prioridad FROM Tipo WHERE Prioridad>0 ORDER BY TipoPrioridad, Prioridad ")
                FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbTipo, "Tipo", "Tipo", "Tipo", , , , "SELECT TOP 1 '' AS Tipo, '' as TipoPrioridad, 9999 AS Prioridad FROM Tipo UNION ALL SELECT Tipo,TipoPrioridad,Prioridad FROM Tipo  ORDER BY TipoPrioridad, Prioridad ")
                FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbTipoVenta, "TipoVenta", "TipoVenta", "TipoVenta", , , , "SELECT TipoVenta FROM TipoVenta ORDER by Orden")
                FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbEmpleados, "Empleados", "ContadorEmpleado", "Nombre", "Contador", , , "SELECT Contador, Nombre, Baja   FROM Empleados E  ORDER BY Nombre", , , , False)
                FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbAgrupaciones, "Agrupaciones", "Agrupacion", "Agrupacion", , , , "SELECT TOP 1 '' AS Agrupacion FROM Agrupaciones UNION ALL SELECT Agrupacion FROM Agrupaciones")
                FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbPoblacion, "Poblacion", "Poblacion", "Poblacion", , , , "SELECT Poblacion, Provincia FROM Poblacion WHERE Visible = " & GL_SQL_VALOR_1 & " AND Provincia IN (SELECT Provincia FROM Provincias WHERE Visible = " & GL_SQL_VALOR_1 & ") ORDER BY Poblacion, Provincia ")
                FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbZona, "Zona", "Zona", "Zona", , , , "SELECT  TOP 1 '' AS Zona FROM Zona UNION ALL SELECT DISTINCT Zona FROM Zona WHERE Poblacion   = '" & Funciones.pf_ReplaceComillas(cmbPoblacion.EditValue) & "'  UNION ALL SELECT Zona FROM ZonasComunes ORDER by Zona")
                FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbOrientacion, "Orientacion", "Orientacion", "Orientacion", , , , "SELECT TOP 1 '' AS Orientacion FROM Orientacion UNION ALL SELECT Orientacion FROM Orientacion")
                FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbClasificacion, "Clasificacion", "Clasificacion", "Clasificacion", "Clasificacion", , , "SELECT Clasificacion FROM Clasificacion E  ORDER BY Clasificacion", , , , False)

            Case EnumTipoBD.ACCESS
                FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbEstado, "Estado", "Estado", "Estado", , , , "SELECT Estado,TipoPrioridad,Prioridad FROM Estado ORDER BY Prioridad DESC")
                FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbTipo, "Tipo", "Tipo", "Tipo", , , , " SELECT Tipo,TipoPrioridad,Prioridad FROM Tipo ORDER BY TipoPrioridad, Prioridad")
                FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbTipoVenta, "TipoVenta", "TipoVenta", "TipoVenta", , , , "SELECT TipoVenta FROM TipoVenta ORDER by Orden")
                FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbEmpleados, "Empleados", "ContadorEmpleado", "Nombre", "Contador", , , "SELECT Contador, Nombre, Baja   FROM Empleados E  ORDER BY Nombre", , , , False)
                FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbAgrupaciones, "Agrupaciones", "Agrupacion", "Agrupacion", , , , " SELECT Agrupacion FROM Agrupaciones")
                FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbPoblacion, "Poblacion", "Poblacion", "Poblacion", , , , "SELECT Poblacion, Provincia FROM Poblacion WHERE Visible = " & GL_SQL_VALOR_1 & " AND Provincia IN (SELECT Provincia FROM Provincias WHERE Visible = " & GL_SQL_VALOR_1 & ") ORDER BY Poblacion, Provincia ")
                FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbZona, "Zona", "Zona", "Zona", , , , " SELECT DISTINCT Zona FROM Zona WHERE Poblacion   = '" & Funciones.pf_ReplaceComillas(cmbPoblacion.EditValue) & "'  UNION ALL SELECT Zona FROM ZonasComunes ORDER by Zona")
                FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbOrientacion, "Orientacion", "Orientacion", "Orientacion", , , , " SELECT Orientacion FROM Orientacion")
                FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbClasificacion, "Clasificacion", "Clasificacion", "Clasificacion", "Clasificacion", , , "SELECT Clasificacion FROM Clasificacion E  ORDER BY Clasificacion", , , , False)

        End Select

        FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbVia, "Vias", "Via", "Abreviatura", "Via", , , "SELECT Via, Abreviatura FROM Vias ORDER BY Abreviatura")

        cmbCalificacionEnergetica.DataBindings.Add(New Binding("EditValue", BinSrc, "CalificacionEnergetica", True))

        ParametrizarGrid(Gv)

        dgvx.tbCarpetaPerfiles = GL_CARPETA_PERFILES & "\" & Me.Name & "\" & dgvx.Name
        MenuGrid = New tbContextMenuStripComponent(dgvx.tbCarpetaPerfiles, cmbPerfiles, cmbFiltros)
        dgvx.ContextMenuStrip = MenuGrid
        'dgvx.ContextMenuStrip = New tbContextMenuStripComponent(dgvx.tbCarpetaPerfiles)
        '  dgvx.ContextMenuStrip.Items.Add("Copiar Perfiles", Nothing, AddressOf CopiarPerfilesDgvX)


        MenuGrid.Items.Add("Gestión Documental", Nothing, AddressOf dgvxGestDoc)
        MenuGrid.Items.Add("Lectura de Colores", Nothing, AddressOf dgvxColores)
        MenuGrid.PopMenuEscaparate.Visible = True
        MenuGrid.PopMenuMostrar.Visible = True
        MenuGrid.PopMenuOcultarTodo.Visible = True
        MenuGrid.PopMenuMapa.Visible = True
        MenuGrid.PopMenuReserva.Visible = True
        MenuGrid.PopMenuDarDeBajaInmueble.Visible = True
        MenuGrid.PopMenuDuplicarInmueble.Visible = True
        MenuGrid.PopMenuMostrarColoresInmueble.Visible = True
        MenuGrid.PopMenuMostrarPPrincipalWeb.Visible = True
        MenuGrid.AbrirCarpetaFotos.Visible = True
        MenuGrid.PopMenuPublicarFacebook.Visible = True
        MenuGrid.Parentt = "Inmuebles"

        MenuGrid.Items.Insert(0, MenuGrid.PopMenuMapa)
        MenuGrid.Items.Insert(1, MenuGrid.PopMenuReserva)
        MenuGrid.Items.Insert(2, MenuGrid.PopMenuOcultarReservados)
        MenuGrid.Items.Insert(3, MenuGrid.PopMenuDarDeBajaInmueble)
        MenuGrid.Items.Insert(4, MenuGrid.PopMenuDuplicarInmueble)
        MenuGrid.Items.Insert(5, MenuGrid.PopMenuMostrarColoresInmueble)
        MenuGrid.Items.Insert(6, MenuGrid.PopMenuMostrarPPrincipalWeb)
        MenuGrid.Items.Insert(7, MenuGrid.PopMenuGuardarSituacionActual)
        MenuGrid.Items.Insert(8, MenuGrid.PopMenuRecuperarSituacionGuardada)
        MenuGrid.Items.Insert(9, MenuGrid.Items(29))
        MenuGrid.Items.Insert(10, MenuGrid.Items(30))
        MenuGrid.Items.Insert(11, MenuGrid.PopMenuExportar)
        MenuGrid.Items.Insert(12, MenuGrid.PopMenuPerfiles)
        MenuGrid.Items.Insert(13, MenuGrid.PopMenuFiltros)
        MenuGrid.Items.Insert(14, MenuGrid.PopMenuCopiarCelda)
        MenuGrid.Items.Insert(15, MenuGrid.PopMenuCopiarFila)
        MenuGrid.Items.Insert(16, MenuGrid.PopMenuEscaparate)
        MenuGrid.Items.Insert(17, MenuGrid.PopMenuMostrar)
        MenuGrid.Items.Insert(18, MenuGrid.PopMenuOcultarTodo)
        MenuGrid.Items.Insert(19, MenuGrid.AbrirCarpetaFotos)
        MenuGrid.Items.Insert(20, MenuGrid.PopMenuPublicarFacebook)






        'If DeDondeVengo = "CLIENTES" Then
        MenuGrid.PopMenuOcultarReservados.Visible = True
        'End If

        If DeDondeVengo.Contains("Portal") Then
            dgvx.ContextMenuStrip = Nothing
        End If

        ConfigurarGrid()

        uGestionDocumental = New ucGestionDocumental
        CrearPanelFlotanteNueva(DockManager1, PanelGestionDocumental, uGestionDocumental, 600, 300)

        If ContadorClienteDeDondeVengo <> 0 Then
            '        dgvx.Height = dgvx.Height - txtDescripcionInmueble.Height - 100
            PanelDescripcionCliente.Visible = True
            txtDescripcionCliente.Text = "Inmuebles que se ajustan a " & ConsultasBaseDatos.ObtenerNombreCliente(ContadorClienteDeDondeVengo)
        Else
            PanelDescripcionCliente.Visible = False
        End If





        ' HabilitarBotones()

        HabilitarDesHabilitarBotones(True)
        'HabilitarDeshabilitarBotones(True) '-----------------------------------------------------------
        HabilitarDesHabilitarCajas(False) '---------------------------------------------------------------
        MostrarOcultarDatosPropietarios(False)
        'PonerFocoRowFilterEnGridView(Gv, CampoInicialBusqueda)


        Try
            Gv.Focus()
            Gv.FocusedRowHandle = 0
        Catch ex As Exception

        End Try

        BinSrc.MoveFirst()

        If DeDondeVengo = "Alarmas" Then
            SituarseEnGrid(Gv, ContadorClienteDeDondeVengo, "Contador", 0)
            TabInmuebles.SelectedTabPage = TabPropietarios
        End If


        'Dim column As GridColumn = Gv.Columns("timestamp")
        'Gv.FocusedColumn = column

        'RemoveHandler Gv.CustomColumnDisplayText, AddressOf gv_CustomColumnDisplayText
        'If DeDondeVengo = GL_VENGO_DE_CLIENTES Then LlenarVisitados()

        If DeDondeVengo.Contains("Portal") Then
            TabInmuebles.Visible = Not TabInmuebles.Visible
            If DeDondeVengo.ToUpper.Contains("FOTOCASA") Then
                Gv.Columns("PortalFotoCasa").Visible = True
                Gv.Columns("PortalFotoCasa").VisibleIndex = 1
                Gv.Columns("PortalFotoCasa").Caption = "FC"
                Gv.Columns("Baja").Visible = True
                Gv.Columns("Reservado").Visible = True
                Gv.Columns("Publicacion").Visible = True
                Gv.Columns("DesPublicacion").Visible = True

                'For i = 0 To Gv.RowCount - 1
                '    If Gv.GetDataRow(i)(DeDondeVengo.Replace("|", "")) Then dgvx.ColumnaCheck.SelectRow(i, True)
                'Next
            Else
                For i = 0 To Gv.RowCount - 1
                    If Gv.GetDataRow(i)(DeDondeVengo.Replace("|", "")) Then dgvx.ColumnaCheck.SelectRow(i, True)
                Next
            End If

        End If

        CargandoInmuebles = False
        Me.Cursor = System.Windows.Forms.Cursors.Arrow



        If DeDondeVengo <> GL_VENGO_DE_CLIENTES Then
            If DeDondeVengo = GL_VENGO_DE_PROPIETARIOS And NuevoInmueble Then
            Else
                HacerCambioFila()
            End If

        End If
        If DeDondeVengo = "" Then
            TabInmuebles.Visible = True
        End If
        '     FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbZona, "Zona", "Zona", "Zona", , , , "SELECT Zona FROM Zona WHERE Poblacion   = '" & cmbPoblacion.EditValue & "'  ORDER by Zona")

        VerificarPortalesActualizados()
        '    dgvx.ForceInitialize()
        'Gv.PopulateColumns()
        '   PonerFocoRowFilterEnGridView(Gv, CampoInicialBusqueda)
        '  PonerFocoRowFilterEnGridView(Gv, "Ref")


        'If DeDondeVengo = GL_VENGO_DE_PROPIETARIOS Then

        '    If NuevoInmueble Then
        '        Anadir()
        '        btnModificar.Enabled = False
        '        btnEliminar.Enabled = False


        '        BinSrc.Current("Referencia") = txtReferencia.EditValue
        '        BinSrc.Current("ContadorPropietario") = uPropietariosActivo.BinSrc.Current("Contador")

        '        txtPropietario.EditValue = uPropietariosActivo.BinSrc.Current("Nombre")
        '        txtContadorPropietario.EditValue = uPropietariosActivo.BinSrc.Current("Contador")

        '    Else
        '        TabInmuebles.SelectedTabPage = TabPropietarios
        '    End If
        'End If

        If DeDondeVengo = GL_VENGO_DE_PROPIETARIOS And NuevoInmueble Then
            Anadir()
            btnModificar.Enabled = False
            btnEliminar.Enabled = False


            BinSrc.Current("Referencia") = txtReferencia.EditValue
            BinSrc.Current("ContadorPropietario") = uPropietariosActivo.BinSrc.Current("Contador")

            txtPropietario.EditValue = uPropietariosActivo.BinSrc.Current("Nombre")
            txtContadorPropietario.EditValue = uPropietariosActivo.BinSrc.Current("Contador")
        End If


        If DeDondeVengo.Contains("Portal") Then
            Gv.TopRowIndex = 0
        End If

        ' NuevoInmuebleDesdeProp()
        'If NuevoInmueble Then
        '    Anadir()
        '    btnModificar.Enabled = False
        '    btnEliminar.Enabled = False


        '    BinSrc.Current("Referencia") = txtReferencia.EditValue
        '    BinSrc.Current("ContadorPropietario") = uPropietariosActivo.BinSrc.Current("Contador")

        '    txtPropietario.EditValue = uPropietariosActivo.BinSrc.Current("Nombre")
        '    txtContadorPropietario.EditValue = uPropietariosActivo.BinSrc.Current("Contador")
        'End If



    End Sub
    Public Sub NuevoInmuebleDesdeProp()

        If DeDondeVengo = GL_VENGO_DE_PROPIETARIOS Then

            If NuevoInmueble Then
                'Anadir()
                'btnModificar.Enabled = False
                'btnEliminar.Enabled = False


                'BinSrc.Current("Referencia") = txtReferencia.EditValue
                'BinSrc.Current("ContadorPropietario") = uPropietariosActivo.BinSrc.Current("Contador")

                txtPropietario.EditValue = uPropietariosActivo.BinSrc.Current("Nombre")
                txtContadorPropietario.EditValue = uPropietariosActivo.BinSrc.Current("Contador")
                chkBanco.EditValue = uPropietariosActivo.BinSrc.Current("Banco")

            Else
                TabInmuebles.SelectedTabPage = TabPropietarios
            End If
        End If
    End Sub

    Public Sub AbrirCarpetaFotos()
        Dim carpeta As String = Path.GetFullPath(GL_CarpetaFotos & "/" & BinSrc.Current("Referencia"))
        If Not Directory.Exists(carpeta) Then
            carpeta = Path.GetFullPath(GL_CarpetaFotos)
        End If
        Process.Start("explorer.exe", carpeta)
    End Sub

    Private Sub cmbPoblacion_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cmbPoblacion.EditValueChanged
        If CargandoInmuebles Then
            Exit Sub
        End If

        FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbZona, "Zona", "Zona", "Zona", , , , GL_SQL_TOP1_FRONT & " '' AS Zona FROM Zona " & GL_SQL_TOP1_BACK & " UNION ALL SELECT DISTINCT Zona FROM Zona WHERE Poblacion   = '" & Funciones.pf_ReplaceComillas(If(IsDBNull(cmbPoblacion.EditValue), "", cmbPoblacion.EditValue)) & "' UNION ALL SELECT Zona FROM ZonasComunes ORDER by Zona")
        If txtCodPostal.EditValue = "" Then

            Dim CodPostal As String
            Dim Sel As String
            Sel = "SELECT CodigoPostal FROM Poblacion WHERE Poblacion = '" & Funciones.pf_ReplaceComillas(cmbPoblacion.EditValue) & "'"
            CodPostal = BD_CERO.Execute(Sel, False)

            txtCodPostal.EditValue = CodPostal
        End If


        '   FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbZona, "Zona", "Zona", "Zona", , , , "SELECT Zona FROM Zona WHERE Poblacion   = '" & cmbPoblacion.EditValue & "'  ORDER by Zona")
    End Sub


    Private Sub PrepararLlenarCheckCombosClientes(ByVal cmb As uc_tb_CombosCheck, ByVal Tabla As String)

        cmb.tb_TablaCompleta = Tabla
        cmb.tb_TablaEnlazada = "Clientes" & Tabla
        cmb.tb_Campo = Tabla
        cmb.tb_CampoFiltro = "CodigoCliente"
        cmb.tb_LlenarCompleta()
        cmb.DataBindings.Add(New Binding("tb_ValorBusqueda", BinSrc, "Codigo", True))

    End Sub

    Public Sub LlenarGrid(Optional ByVal Filtro As String = "", Optional Situarse As Boolean = False, Optional whereAdicional As String = "")

        Dim ContadorAnterior As Integer = -1
        If Situarse Then
            Try
                ContadorAnterior = CInt(Gv.GetFocusedRowCellValue("Contador"))
            Catch ex As Exception

            End Try

        End If

        CargandoInmuebles = True

        Dim FiltroSelect As String

        If FiltroBusqueda = "" Then
            FiltroSelect = ""
        Else
            'FiltroSelect = " WHERE (Telefono1propietario LIKE '%" & FiltroBusqueda & "%' OR  Telefono2propietario LIKE '%" & FiltroBusqueda & "%' OR  Telefono3propietario LIKE '%" & FiltroBusqueda & "%' OR  Telefono4propietario LIKE '%" & FiltroBusqueda & "%' OR  TelefonoMovilpropietario LIKE '%" & FiltroBusqueda & "%' OR  Emailpropietario LIKE '%" & FiltroBusqueda & "%' OR  Email2propietario LIKE '%" & FiltroBusqueda & "%'  OR  ContadorPropietario IN (SELECT Contador FROM Propietarios WHERE Nombre LIKE '%" & FiltroBusqueda & "%'))"
            FiltroSelect = " AND ((SELECT Telefono1 FROM Propietarios P WHERE Contador = I.ContadorPropietario) LIKE '%" & FiltroBusqueda & "%' OR  (SELECT Telefono2 FROM Propietarios P WHERE Contador = I.ContadorPropietario) LIKE '%" & FiltroBusqueda & "%' OR  (SELECT Telefono3 FROM Propietarios P WHERE Contador = I.ContadorPropietario) LIKE '%" & FiltroBusqueda & "%' OR  (SELECT Telefono4 FROM Propietarios P WHERE Contador = I.ContadorPropietario) LIKE '%" & FiltroBusqueda & "%' OR  (SELECT TelefonoMovil FROM Propietarios P WHERE Contador = I.ContadorPropietario) LIKE '%" & FiltroBusqueda & "%' OR  (SELECT Email FROM Propietarios P WHERE Contador = I.ContadorPropietario) LIKE '%" & FiltroBusqueda & "%' OR  (SELECT Email2 FROM Propietarios P WHERE Contador = I.ContadorPropietario) LIKE '%" & FiltroBusqueda & "%'  OR  ContadorPropietario IN (SELECT Contador FROM Propietarios WHERE Nombre LIKE '%" & FiltroBusqueda & "%'))"
        End If


        Dim TextoBaja As String = ""

        If PulsadoVerBajas Then
            TextoBaja = " AND Baja =" & GL_SQL_VALOR_1 & " "
        Else
            TextoBaja = " AND Baja = 0 "
        End If

        If DeDondeVengo = GL_VENGO_DE_VISITAS Then
            TextoBaja = ""
        End If

        Dim FiltroTotal As String = ""
        Dim FiltroCliente As String = ""
        Dim Visitado As String = " ,(" & Funciones.SQL_CASE({"(SELECT COUNT(*) FROM Visitas WHERE ContadorInmueble = I.Contador) > 0", "(SELECT COUNT(*) FROM Visitas WHERE ContadorInmueble = I.Contador) <= 0"}, {Funciones.SQL_CONVERT("BIT", "1"), Funciones.SQL_CONVERT("BIT", "0")}) & ") as Visitado"

        Select Case DeDondeVengo.ToUpper
            Case GL_VENGO_DE_CLIENTES

                Visitado = " ,(" & Funciones.SQL_CASE({"(SELECT COUNT(*) FROM Visitas WHERE ContadorInmueble = I.Contador AND ContadorCliente = " & ContadorClienteDeDondeVengo & ") > 0", "(SELECT COUNT(*) FROM Visitas WHERE ContadorInmueble = I.Contador AND ContadorCliente = " & ContadorClienteDeDondeVengo & ") <= 0"}, {Funciones.SQL_CONVERT("BIT", "1"), Funciones.SQL_CONVERT("BIT", "0")}) & ") as Visitado"
            Case GL_VENGO_DE_PROPIETARIOS, "ALARMAS"
                FiltroCliente = "  ContadorPropietario=" & ContadorPropietarioDeDondeVengo
        End Select

        If FiltroSelect = "" Then
            If FiltroCliente <> "" Then
                FiltroTotal = " AND " & FiltroCliente
            End If

        Else
            FiltroTotal = FiltroSelect
            If FiltroCliente <> "" Then
                FiltroTotal = FiltroTotal & " AND " & FiltroCliente
            End If

        End If
        FiltroTotal &= Filtro
        '"(SELECT TOP 1 " & Funciones.SQL_CASE({"Cambio LIKE '%BAJA%'", "Cambio  LIKE '%SUBE%'", "Cambio NOT LIKE '%BAJA%' AND Cambio NOT LIKE '%SUBE%'"}, {"'BAJA'", "'SUBE'", "''"}) & _
        '                " FROM CambiosPrecio I2 WHERE I2.ContadorInmueble = I.Contador ORDER BY I2.Contador DESC) AS CambioPrecio," & _

        Dim SentetenciaSelect As String



        SentetenciaSelect = "SELECT *, Direccion " & GL_SQL_SUMA &
         Funciones.SQL_CASE({"Numero <> ''", "Numero = ''"}, {"' Num '" & GL_SQL_SUMA & "Numero", "''"}) & GL_SQL_SUMA &
         Funciones.SQL_CASE({"Puerta <> ''", "Puerta = ''"}, {"' Pta. '" & GL_SQL_SUMA & "Puerta", "''"}) & " as DireccionCompleta " &
            ",(SELECT FechaEmail FROM Propietarios P WHERE Contador = I.ContadorPropietario) AS FechaEmail" &
            ",(SELECT Nombre FROM Propietarios P WHERE Contador = I.ContadorPropietario) AS Propietario," &
            "(SELECT Telefono1 FROM Propietarios P WHERE Contador = I.ContadorPropietario) AS Telefono1Propietario," &
            "(SELECT Telefono2 FROM Propietarios P WHERE Contador = I.ContadorPropietario) AS Telefono2Propietario," &
            "(SELECT Telefono3 FROM Propietarios P WHERE Contador = I.ContadorPropietario) AS Telefono3Propietario," &
            "(SELECT Telefono4 FROM Propietarios P WHERE Contador = I.ContadorPropietario) AS Telefono4Propietario," &
            "(SELECT TelefonoMovil FROM Propietarios P WHERE Contador = I.ContadorPropietario) AS TelefonoMovilPropietario," &
            "(SELECT Email FROM Propietarios P WHERE Contador = I.ContadorPropietario) AS EmailPropietario," &
            "(SELECT COUNT(*) FROM Inmuebles I2 WHERE I2.ContadorPropietario = I.ContadorPropietario) AS Inmuebles," &
            "(SELECT AvisadoTresPorCien FROM Propietarios P WHERE Contador = I.ContadorPropietario) AS AvisadoTresPorCien," &
            "(SELECT AvisadoMensualidad FROM Propietarios P WHERE Contador = I.ContadorPropietario) AS AvisadoMensualidad," &
            "(SELECT NoInmobiliaria FROM Propietarios P WHERE Contador = I.ContadorPropietario) AS NoInmobiliaria, " &
            "(SELECT NoAnimales FROM Propietarios P WHERE Contador = I.ContadorPropietario) AS NoAnimales, " &
            "(SELECT SeguroVivienda FROM Propietarios P WHERE Contador = I.ContadorPropietario) AS SeguroVivienda," &
            "(SELECT NoExtranjeros FROM Propietarios P WHERE Contador = I.ContadorPropietario) AS NoExtranjeros, " &
            "(SELECT NoQuiereRecibirEmails FROM Propietarios P WHERE Contador = I.ContadorPropietario) AS NoQuiereRecibirEmails, " &
            "(SELECT MAX(Fecha) FROM Visitas V WHERE V.ContadorInmueble = I.Contador) AS UltimaVisita, " &
            "(SELECT COUNT(*) FROM AccionesPendientes WHERE Referencia = I.Referencia) as PendienteWeb, " &
            "(SELECT Referencia FROM Inmuebles WHERE Contador = I.ContadorOrigen) as RefOrigen " &
            Visitado

        If FiltroBusqueda <> "" Or DeDondeVengo.ToUpper = GL_Propietarios Then
            TextoBaja = ""
        End If

        If whereAdicional <> "" Then
            whereAdicional = " AND TipoVenta = " & whereAdicional.Split("|")(0) & " AND ContadorOrigen NOT IN (SELECT ContadorOrigen FROM Inmuebles WHERE TipoVenta in (" & whereAdicional.Split("|")(1) & ") and ContadorOrigen <>0)"
        End If


        'If DeDondeVengo.ToUpper = GL_Clientes Then
        '    SentenciaSQL = FuncionesBD.ObtenerReferenciasQueCuadran(ContadorClienteDeDondeVengo, False, Microsoft.VisualBasic.Right(SentetenciaSelect, Len(SentetenciaSelect) - Len("SELECT ")), , True) & " ORDER BY Referencia DESC" ' FiltroTotal & TextoBaja
        'ElseIf DeDondeVengo.Contains("Portal") Then
        '    SentenciaSQL = SentetenciaSelect & " FROM Inmuebles I WHERE CodigoEmpresa = " & DatosEmpresa.Codigo & "AND Baja=0 AND Reservado=0  ORDER BY " & DeDondeVengo.Replace("|", "") & " DESC, Referencia DESC"
        'Else
        '    SentenciaSQL = SentetenciaSelect & " FROM Inmuebles I WHERE CodigoEmpresa = " & DatosEmpresa.Codigo & FiltroTotal & TextoBaja & "  ORDER BY Referencia DESC"
        'End If
        If DeDondeVengo = GL_VENGO_DE_VISITAS Then
            FiltroTotal &= " AND Contador=" & ContadorInmuebleAlQueVoy
        End If

        If DeDondeVengo.ToUpper = GL_Clientes Then
            SentenciaSQL = FuncionesBD.ObtenerReferenciasQueCuadran(ContadorClienteDeDondeVengo, True, Microsoft.VisualBasic.Right(SentetenciaSelect, Len(SentetenciaSelect) - Len("SELECT ")), , True)   ' FiltroTotal & TextoBaja
        ElseIf DeDondeVengo.Contains("Portal") Then
            SentenciaSQL = SentetenciaSelect & " FROM Inmuebles I WHERE CodigoEmpresa = " & DatosEmpresa.Codigo & "AND Baja=0 AND Reservado=0 ORDER BY " & DeDondeVengo.Replace("|", "") & " DESC, Referencia DESC"
        Else
            SentenciaSQL = SentetenciaSelect & " FROM Inmuebles I WHERE CodigoEmpresa = " & DatosEmpresa.Codigo & FiltroTotal & TextoBaja & whereAdicional & "  ORDER BY Referencia DESC"
        End If



        If DeDondeVengo.ToUpper = GL_Clientes Then
            SentenciaSQL = FuncionesBD.ObtenerReferenciasQueCuadran(ContadorClienteDeDondeVengo, True, Microsoft.VisualBasic.Right(SentetenciaSelect, Len(SentetenciaSelect) - Len("SELECT ")), , True)   ' FiltroTotal & TextoBaja
        Else
            If DeDondeVengo.Contains("Portal") Then
                If DeDondeVengo.Replace("|", "").ToString.ToUpper = "PORTALFOTOCASA" Then
                    SentetenciaSelect = SentetenciaSelect & " , (SELECT MAX(Fecha) FROM MovimientosFotocasa WHERE Referencia = I.Referencia AND Publicar = 1) as Publicacion, (SELECT MAX(Fecha) FROM MovimientosFotocasa WHERE Referencia = I.Referencia AND Publicar = 0) as DesPublicacion, Baja, Reservado "
                    SentenciaSQL = SentetenciaSelect & " FROM Inmuebles I WHERE CodigoEmpresa = " & DatosEmpresa.Codigo & IIf(VerBajasPC, "", " AND Baja=0 ") & IIf(VerReservasPC, "", " AND Reservado=0") & " ORDER BY " & DeDondeVengo.Replace("|", "") & " DESC, Referencia DESC"
                Else
                    SentenciaSQL = SentetenciaSelect & " FROM Inmuebles I WHERE CodigoEmpresa = " & DatosEmpresa.Codigo & " AND Baja=0 AND Reservado=0 ORDER BY " & DeDondeVengo.Replace("|", "") & " DESC, Referencia DESC"
                End If

            Else
                SentenciaSQL = SentetenciaSelect & " FROM Inmuebles I WHERE CodigoEmpresa = " & DatosEmpresa.Codigo & FiltroTotal & TextoBaja & whereAdicional & "  ORDER BY Referencia DESC"
            End If
        End If



        '   SentetenciaSelect = "SELECT Contador, Direccion FROM Inmuebles"
        bd = New BaseDatos
        bd.LlenarDataSet(SentenciaSQL, TablaMantenimiento, , False, True)


        Dim col As New DataColumn
        col = New DataColumn
        With col
            .DataType = System.Type.GetType("System.Int32")
            .ColumnName = "Años"
            .Caption = "Años"
            .Expression = Year(Today) & " - AnoConstruccion"
        End With
        bd.ds.Tables(TablaMantenimiento).Columns.Add(col)




        'With bd.ds.Tables(TablaMantenimiento).Columns("Contador")
        '    .AutoIncrement = True
        '    '    .AutoIncrementSeed =1
        '    .AutoIncrementStep = 1
        'End With

        Dim key(0) As DataColumn
        key(0) = bd.ds.Tables(TablaMantenimiento).Columns("Contador")
        bd.ds.Tables(TablaMantenimiento).PrimaryKey = key



        If PrimeraVez Then
            BinSrc = New BindingSource
        End If

        BinSrc.DataSource = bd.ds
        BinSrc.DataMember = TablaMantenimiento

        'La puta línea que faltaba
        dgvx.BindingContext = New BindingContext()
        dgvx.DataSource = Nothing
        dgvx.DataSource = BinSrc

        '    Gv = New MyGridView
        Gv = Nothing
        Gv = dgvx.MainView

        'MyGridControl1.DataSource = BinSrc
        'MyGridView1 = MyGridControl1.MainView

        dgvx.ForceInitialize()

        If PrimeraVez Then
            AP = New ActualizaPerfil(Gv)
        End If

        If Gv.RowCount = 0 Then
            TabInmuebles.Enabled = False
        Else
            TabInmuebles.Enabled = True
        End If

        CargandoInmuebles = False



        If Situarse AndAlso ContadorAnterior > 0 Then
            SituarseEnGrid(Gv, CStr(ContadorAnterior), "Contador")
        Else
            Try
                If Not PrimeraVez Then
                    HacerCambioFila()
                End If

            Catch ex As Exception

            End Try
        End If

    End Sub


    Private Sub ConfigurarGrid()


        If DatosEmpresa.Codigo = 2 Then
            chkExclusiva.Visible = False
            chkLlavesCanet.Visible = True
            If Not IsNothing(Gv.Columns("Exclusiva")) Then
                Gv.Columns("Exclusiva").OptionsColumn.AllowShowHide = False
            End If

        Else
            chkExclusiva.Visible = True
            chkLlavesCanet.Visible = False
            Gv.Columns("LlavesCanet").OptionsColumn.AllowShowHide = False
        End If





        If Not PrimeraVez Then

            Exit Sub
        End If

        PrimeraVez = False
        If dgvx.tbEstablecerPerfilPredeterminado() Then
            cmbPerfiles.EditValue = dgvx.tbPerfilPredeterminado
            cmbPerfiles.Text = dgvx.tbPerfilPredeterminado & "(Predeterminado)"

            If DeDondeVengo.ToUpper = GL_VENGO_DE_CLIENTES Then
                Gv.ClearSorting()
                Gv.Columns("Precio").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            End If

            PonerColoresInmuebles(Gv)

            AddHandler Gv.RowCellStyle, AddressOf gv_RowCellStyle
            AddHandler Gv.RowStyle, AddressOf Gv_RowStyle

            Exit Sub
        End If
        '        MsgBox("No Tengo perfiles")

        Try
            RemoveHandler Gv.RowCellStyle, AddressOf gv_RowCellStyle
            RemoveHandler Gv.RowStyle, AddressOf Gv_RowStyle
        Catch ex As Exception

        End Try


        PonerColoresInmuebles(Gv)

        Dim pos As Integer = 0
        pos = pos + 1
        Gv.Columns("Tipo").VisibleIndex = pos
        pos = pos + 1
        Gv.Columns("TipoVenta").VisibleIndex = pos
        pos = pos + 1
        Gv.Columns("Poblacion").VisibleIndex = pos
        pos = pos + 1
        Gv.Columns("Zona").VisibleIndex = pos
        pos = pos + 1
        Gv.Columns("Estado").VisibleIndex = pos
        pos = pos + 1
        Gv.Columns("Metros").VisibleIndex = pos
        pos = pos + 1
        Gv.Columns("Precio").VisibleIndex = pos
        pos = pos + 1
        Gv.Columns("Años").VisibleIndex = pos
        pos = pos + 1
        Gv.Columns("FechaAlta").VisibleIndex = pos
        pos = pos + 1
        Gv.Columns("FechaUltimaLlamadaPropietario").VisibleIndex = pos
        pos = pos + 1
        Gv.Columns("FechaReservado").VisibleIndex = pos
        pos = pos + 1
        Gv.Columns("Ocultar").VisibleIndex = pos
        pos = pos + 1
        Gv.Columns("Cartel").VisibleIndex = pos
        pos = pos + 1
        Gv.Columns("Llaves").VisibleIndex = pos
        pos = pos + 1
        Gv.Columns("AlquiladoPorNosotros").VisibleIndex = pos
        pos = pos + 1
        Gv.Columns("DireccionCompleta").VisibleIndex = pos
        pos = pos + 1
        Gv.Columns("Propietario").VisibleIndex = pos
        pos = pos + 1
        Gv.Columns("Telefono1Propietario").VisibleIndex = pos
        pos = pos + 1
        Gv.Columns("Telefono2Propietario").VisibleIndex = pos
        pos = pos + 1
        Gv.Columns("Telefono3Propietario").VisibleIndex = pos
        pos = pos + 1
        Gv.Columns("Telefono4Propietario").VisibleIndex = pos
        pos = pos + 1
        Gv.Columns("TelefonoMovilPropietario").VisibleIndex = pos
        pos = pos + 1
        Gv.Columns("Orientacion").VisibleIndex = pos

        If DeDondeVengo.ToUpper = GL_VENGO_DE_CLIENTES Then

            Gv.ClearSorting()
            '   Gv.Columns("Referencia").SortOrder = DevExpress.Data.ColumnSortOrder.None

            'If UClienteActivo.BinSrc.Current(TipoVenta") = True Then
            Gv.Columns("Precio").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            'Else
            '    If UClienteActivo.BinSrc.Current("Alquiler") = True Then
            '        Gv.Columns("PrecioAlquiler").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            '    Else
            '        If UClienteActivo.BinSrc.Current("Verano") = True Then
            '            Gv.Columns("PrecioVerano").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            '        Else
            '            Gv.Columns("Referencia").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
            '        End If
            '    End If
            'End If


            'Gv.TopRowIndex = 0
            'Gv.FocusedRowHandle = 0
            'Gv.TopRowIndex = 0

        End If


        Gv.Columns("MostrarPPrincipalWeb").Visible = False
        Gv.Columns("LlavesCanet").Visible = False




        Gv.Columns("FechaEmail").Caption = "F Email"
        Gv.Columns("FechaEmail").Visible = False
        Gv.Columns("ContadorOrigen").Visible = False
        Gv.Columns("RefOrigen").Visible = False

        Gv.Columns("Clasificacion").Visible = False

        Gv.Columns("PrecioJunio").Visible = False
        Gv.Columns("PrecioJulio").Visible = False
        Gv.Columns("PrecioAgosto").Visible = False
        Gv.Columns("AlturaFinca").Visible = False
        Gv.Columns("TipoCalentador").Visible = False
        Gv.Columns("TipoCocina").Visible = False

        Gv.Columns("TrasteroNumero").Visible = False
        Gv.Columns("QuienCartel").Visible = False
        Gv.Columns("FechaCartel").Visible = False

        Gv.Columns("FechaCambioPrecio").Visible = False
        Gv.Columns("FechaQuitaReservado").Visible = False
        Gv.Columns("FechaUltimoCambio").Visible = False
        Gv.Columns("AlquilerVacacional").Visible = False
        Gv.Columns("Oportunidad").Visible = False
        Gv.Columns("NOAlquiler").Visible = False
        ' Gv.Columns("Ocultar").Visible = False
        Gv.Columns("FotosWeb").Visible = False
        'Gv.Columns("FotosPc").Visible = False
        Gv.Columns("CambioPrecio").Visible = True
        Gv.Columns("Observaciones").Visible = False
        Gv.Columns("CalificacionEnergetica").Visible = False
        Gv.Columns("PlayaDerecha").Visible = False
        Gv.Columns("Montana").Visible = False
        Gv.Columns("EmailPropietario").Visible = False
        Gv.Columns("Inmuebles").Visible = False
        Gv.Columns("SeguroVivienda").Visible = False
        Gv.Columns("NoExtranjeros").Visible = False
        Gv.Columns("NoQuiereRecibirEmails").Visible = False
        Gv.Columns("UltimaVisita").Visible = False
        Gv.Columns("Visitado").Visible = False
        'Gv.Columns("DireccionCompleta").Visible = False
        'Gv.Columns("Propietario").Visible = False
        Gv.Columns("Telefono1Propietario").Visible = False
        Gv.Columns("Telefono2Propietario").Visible = False
        Gv.Columns("Telefono3Propietario").Visible = False
        Gv.Columns("Telefono4Propietario").Visible = False
        Gv.Columns("TelefonoMovilPropietario").Visible = False
        Gv.Columns("Orientacion").Visible = False


        Gv.Columns("Telefono1Propietario").Caption = "Teléfono1"
        Gv.Columns("Telefono2Propietario").Caption = "Teléfono2"
        Gv.Columns("Telefono3Propietario").Caption = "Teléfono3"
        Gv.Columns("Telefono4Propietario").Caption = "Teléfono4"
        Gv.Columns("TelefonoMovilPropietario").Caption = "Móvil"
        'If AnadirCheckColunm AndAlso Not dgvx.tb_AnadirColumnaCheck Then
        '    Try
        '        dgvx.tb_AnadirColumnaCheck = True
        '        
        '    Catch ex As Exception
        '    End Try
        '    '   ColumnaCheck = New GridCheckMarksSelection(Gv)
        'End If

        Gv.OptionsView.ColumnAutoWidth = False
        'GridPasado.OptionsNavigation.EnterMoveNextColumn = True
        'GridPasado.OptionsNavigation.UseTabKey = True
        'GridPasado.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        Gv.OptionsView.ShowGroupPanel = False
        'GridPasado.OptionsBehavior.Editable = False
        'GridPasado.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        'GridPasado.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
        'GridPasado.OptionsView.ColumnAutoWidth = True
        Gv.OptionsView.ShowAutoFilterRow = True

        Gv.Columns("TipoVenta").Caption = "Oferta"

        With Gv.Columns("FechaAlta")
            .Caption = "F Alta"
            .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            .DisplayFormat.FormatString = "dd/MM/yy"
            .AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            .Width = 80
        End With

        With Gv.Columns("FechaUltimaLlamadaPropietario")
            .Caption = "F Llamada"
            .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            .DisplayFormat.FormatString = "dd/MM/yy"
            .AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            .Width = 80
        End With

        With Gv.Columns("FechaReservado")
            .Caption = "F Reserva"
            .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            .DisplayFormat.FormatString = "dd/MM/yy"
            .AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            .Width = 80
        End With

        With Gv.Columns("FechaCambioPrecio")
            .Caption = "F Precio"
            .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            .DisplayFormat.FormatString = "dd/MM/yy"
            .AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            .Width = 80
        End With

        With Gv.Columns("FechaQuitaReservado")
            .Caption = "F Quita Reserva"
            .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            .DisplayFormat.FormatString = "dd/MM/yy"
            .AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            .Width = 80
        End With

        With Gv.Columns("FechaUltimoCambio")
            .Caption = "F Ult. Cambio"
            .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            .DisplayFormat.FormatString = "dd/MM/yy"
            .AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            .Width = 80
        End With

        For Each p In GL_Portales
            Gv.Columns("Portal" & p).Visible = False
        Next

        If DeDondeVengo.Contains("Portal") Then
            Gv.Columns(DeDondeVengo.Replace("|", "")).SortOrder = DevExpress.Data.ColumnSortOrder.Descending


        End If
        For Each p In GL_PortalesCreados
            If frmPrincipal.ribbonControl.Items("I" & p).Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
                pos = pos + 1
                Gv.Columns("Portal" & p).VisibleIndex = pos

                Gv.Columns("Portal" & p).Visible = True
                Gv.Columns("Portal" & p).Caption = p
            End If
        Next


        Gv.Columns("Referencia").SortOrder = DevExpress.Data.ColumnSortOrder.Descending



        Gv.Columns("RefOrigen").Caption = "Ref.Original"

        Gv.Columns("NoAnimales").Caption = "NO Anim"
        Gv.Columns("NoAnimales").Visible = False

        Gv.Columns("Referencia").VisibleIndex = 0

        Gv.Columns("Garaje").Caption = "Garaje"
        Gv.Columns("Trastero").Caption = "Trastero"

        Gv.Columns("MostrarPPrincipalWeb").Caption = "Principal en Web"
        Gv.Columns("MostrarPPrincipalWeb").Visible = False

        If DeDondeVengo.Contains("Portal") Then
            For Each p In GL_PortalesCreados
                If frmPrincipal.ribbonControl.Items("I" & p).Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
                    Gv.Columns("Portal" & p).VisibleIndex = 1
                End If
            Next

            Gv.Columns(DeDondeVengo.Replace("|", "")).VisibleIndex = 1
        End If


        'Gv.Columns("Contador").Visible = False
        'Gv.Columns("Contador").OptionsColumn.AllowShowHide = False

        Gv.Columns("CodigoEmpresa").OptionsColumn.AllowShowHide = False
        Gv.Columns("Delegacion").OptionsColumn.AllowShowHide = False



        Gv.Columns("Zona").OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
        Gv.Columns("Estado").OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
        Gv.Columns("Tipo").OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
        Gv.Columns("Orientacion").OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
        Gv.Columns("Poblacion").OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
        Gv.Columns("TipoVenta").OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList

        'TipoVenta

        'Gv.Columns("MarcaDeTiempo").OptionsColumn.AllowShowHide = False
        'Gv.Columns("MarcaDeTiempo").Visible = False

        Gv.Columns("Contador").Visible = False
        Gv.Columns("AvisadoMensualidad").Visible = False
        Gv.Columns("NoInmobiliaria").Visible = False
        Gv.Columns("AvisadoTresPorCien").Visible = False
        Gv.Columns("AvisadoTresPorCien").Caption = "3 %"




        Gv.Columns("Reservado").Visible = False
        Gv.Columns("FechaReservado").Visible = True

        Gv.Columns("FechaReservado").Width = 80

        Gv.Columns("FotosPc").Width = 40
        Gv.Columns("FotosWeb").Width = 40
        Gv.Columns("Metros").Width = 40
        Gv.Columns("Referencia").Width = 50
        Gv.Columns("Precio").Width = 60
        Gv.Columns("Tipo").Width = 65
        Gv.Columns("TipoVenta").Width = 65
        Gv.Columns("DireccionCompleta").Width = 200
        Gv.Columns("Propietario").Width = 200
        Gv.Columns("Orientacion").Width = 150
        Gv.Columns("Metros").Width = 65
        Gv.Columns("Altura").Width = 40
        Gv.Columns("Zona").Width = 160
        Gv.Columns("Poblacion").Width = 160

        Gv.Columns("CalificacionEnergetica").Caption = "CEE"



        Gv.Columns("AlquiladoPorNosotros").Caption = "Por Nosotros"
        Gv.Columns("AlquilerVacacional").Caption = "Vacacional"
        Gv.Columns("FotosPc").Caption = "F. PC"
        Gv.Columns("FotosWeb").Caption = "F.Web"
        Gv.Columns("Referencia").Caption = "Ref."

        Gv.Columns("PrecioPropietario").Visible = False


        Gv.Columns("CodigoEmpresa").Visible = False
        Gv.Columns("CodigoEmpresa").Visible = False
        Gv.Columns("Delegacion").Visible = False
        Gv.Columns("ContadorPropietario").Visible = False
        'XXXXGv.Columns("Baja").Visible = False
        Gv.Columns("ContadorPropietario").OptionsColumn.AllowShowHide = False

        Gv.Columns("Precio").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Gv.Columns("Precio").DisplayFormat.FormatString = "{0:n0}"



        'Gv.Columns("FechaAlta").Visible = False
        'Gv.Columns("FechaUltimaLlamadaPropietario").Visible = False


        Gv.Columns("AlquilerOpcionCompra").Visible = False

        Gv.Columns("Baja").Visible = False
        'Gv.Columns("Llaves").Visible = False


        Gv.Columns("ImporteHipoteca").Visible = False

        Gv.Columns("FotoPrincipal").Visible = False

        Gv.Columns("PrecioPropietario").Visible = False

        Gv.Columns("Gastos").Visible = False

        Gv.Columns("Via").Visible = False
        Gv.Columns("Direccion").Visible = False
        Gv.Columns("Numero").Visible = False
        Gv.Columns("Altura").Visible = False
        Gv.Columns("CodPostal").Visible = False
        Gv.Columns("Provincia").Visible = False
        Gv.Columns("Puerta").Visible = False

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
        '  Gv.Columns("Orientacion").Visible = False
        '   Gv.Columns("Zona").Visible = False
        '  Gv.Columns("Estado").Visible = False
        Gv.Columns("Extras").Visible = False

        '   Gv.Columns("Oportunidad").Visible = False
        Gv.Columns("Escaparate").Visible = False
        ' Gv.Columns("Ocultar").Visible = False
        '   Gv.Columns("Cartel").Visible = False
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
        Gv.Columns("Trastero").Visible = False
        Gv.Columns("PrecioTrastero").Visible = False
        Gv.Columns("MGaraje").Visible = False
        Gv.Columns("GarajeCerrado").Visible = False
        Gv.Columns("GarajeNumero").Visible = False
        Gv.Columns("Garaje").Visible = False
        Gv.Columns("PrecioGaraje").Visible = False
        Gv.Columns("SemiAmueblado").Visible = False


        Gv.Columns("Amueblado").Visible = False

        Gv.Columns("Electrodomesticos").Visible = False


        Gv.Columns("FianzaAlquiler").Visible = False
        Gv.Columns("ComunidadIncluida").Visible = False
        Gv.Columns("PrecioComunidad").Visible = False
        Gv.Columns("ZonaComercial").Visible = False

        Gv.Columns("ContadorEmpleado").Visible = False

        Gv.Columns("FotoEscaparate").Visible = False
        Gv.Columns("FotoEscaparate2").Visible = False


        Gv.Columns("Agrupacion").Visible = False
        Gv.Columns("Personas").Visible = False
        Gv.Columns("PrimeraLineaPlaya").Visible = False
        Gv.Columns("VivenEnEl").Visible = False
        Gv.Columns("VistasAlMar").Visible = False


        Gv.Columns("AccesoMinusvalidos").Visible = False
        Gv.Columns("Urbanizacion").Visible = False


        Gv.Columns("Direccion2").Visible = False
        Gv.Columns("EnviadaFicha").Visible = False


        Gv.Columns("DireccionMapa").Visible = False
        Gv.Columns("PendienteWeb").Visible = False



        Gv.Columns("CambioPrecio").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Gv.Columns("CalificacionEnergetica").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Gv.Columns("Clasificacion").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
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
        Gv.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        Dim ItemArticulo As GridGroupSummaryItem = New GridGroupSummaryItem()
        ItemArticulo.FieldName = "Contador"
        ItemArticulo.DisplayFormat = "{0:n0}"
        ItemArticulo.SummaryType = DevExpress.Data.SummaryItemType.Count
        Gv.Columns("Referencia").SummaryItem.DisplayFormat = "Inmuebles: {0:n0}"
        Gv.GroupSummary.Add(ItemArticulo)

        Gv.OptionsView.ShowFooter = True
        Gv.Columns("Referencia").SummaryItem.FieldName = "Contador"
        Gv.Columns("Referencia").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        Gv.Columns("Referencia").SummaryItem.DisplayFormat = "{0:n0}"


        '  Gv.OptionsView.ColumnAutoWidth = True

        If AnadirCheckColunm AndAlso Not dgvx.tb_AnadirColumnaCheck Then
            Try
                dgvx.tb_AnadirColumnaCheck = True

            Catch ex As Exception
            End Try
            '   ColumnaCheck = New GridCheckMarksSelection(Gv)
        End If

        AddHandler Gv.RowCellStyle, AddressOf gv_RowCellStyle
        AddHandler Gv.RowStyle, AddressOf Gv_RowStyle

        'Dim filterString As String = "Nombre LIKE '%a%'"
        'gvClientes.Columns("Nombre").FilterInfo = New Columns.ColumnFilterInfo(ColumnFilterType.Custom, Nothing, filterString)



        '   gvClientes.Columns("Nombre").FilterInfo.Type.Custom()






        'gvClientes.OptionsView.ShowFooter = True
        'gvClientes.Columns("CodigoSIG").SummaryItem.FieldName = "CodigoSIG"
        'gvClientes.Columns("CodigoSIG").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        'gvClientes.Columns("CodigoSIG").SummaryItem.DisplayFormat = "Estudios: {0:n0}"

    End Sub



#Region "Mantenimiento Clientes"

    Private Sub btnAnadir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnadir.Click
        TabInmuebles.Visible = True
        Anadir()
    End Sub
    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Eliminar()
    End Sub
    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        TabInmuebles.Visible = True
        Modificar()
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Aceptar() Then
            NuevoInmueble = False
            ActivaUcs()
            PintarPaneles()
            TabPropietarios.PageEnabled = True
        End If
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Cancelar()
        NuevoInmueble = False
        ActivaUcs()
        TabPropietarios.PageEnabled = True
    End Sub
    Private Sub ActivaUcs()
        ucTrasteroVenta.Enabled = True
        ucGarajeVenta.Enabled = True
        ucTrasteroVenta.tb_ReadOnly = True
        ucGarajeVenta.tb_ReadOnly = True

        ucTipoCalentador.Enabled = True
        ucTipoCocina.Enabled = True
        ucTipoCalentador.tb_ReadOnly = True
        ucTipoCocina.tb_ReadOnly = True

    End Sub
    Private Sub Anadir()
        EstoyEnAlta = True
        BinSrc.AddNew()
        PrepararAlta()
    End Sub

    Private Sub Modificar(Optional ByVal PonermeEnLaPrimeraColumna As Boolean = True)

        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Return
        End If

        'If ConsultasBaseDatos.MarcaDeTiempoHaCambiado(TablaMantenimiento, BinSrc.Current("MarcaDeTiempo")) Then
        bd.RefrescarDatos(BinSrc.Position)
        ' End If

        EstoyEnAlta = False
        PrepararModificacion()
        ValorCartelAntes = chkCartel.CheckState

        PrecioAntes = spnPrecio.EditValue


    End Sub

    Private Sub MostrarOcultarDatosPropietarios(ByVal Mostrar As Boolean)
        'If TabInmuebles.Visible Then
        '    If Mostrar AndAlso Not PanelDatosOcultos.Visible Then
        '        TabInmuebles.Top -= (PanelDatosOcultos.Height + 10)
        '    ElseIf Not Mostrar AndAlso PanelDatosOcultos.Visible Then
        '        TabInmuebles.Top += (PanelDatosOcultos.Height + 10)
        '    End If
        'End If
        PanelDatosOcultos.Visible = Mostrar
        If Mostrar AndAlso txtContadorPropietario.Text.Trim <> "" AndAlso txtContadorPropietario.Text.Trim <> "0" Then
            txtPropietario.Text = ConsultasBaseDatos.ObtenerNombrePropietario(CInt(txtContadorPropietario.Text))
        Else
            txtPropietario.Text = ""
        End If
        If TabInmuebles.Visible Then
            If Mostrar Then
                TabInmuebles.Height = 440
            Else
                TabInmuebles.Height = 345
            End If
        End If


    End Sub

    Private Sub Eliminar()



        If Not Funciones.TienePermisosAME() Then
            Return
        End If

        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            MensajeError("Debe seleccionar un registro")
            Return
        End If

        If XtraMessageBox.Show("¿Confirma que quiere eliminar el registro seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
            Exit Sub
        End If


        If XtraMessageBox.Show("Recuerde que también se eliminarán las fotos asociadas." & vbCrLf & "¿Confirma que quiere continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
            Exit Sub
        End If

        If BinSrc.Current("PortalFotoCasa") Then

            If XtraMessageBox.Show("El inmueble está dado de alta en FotoCasa. Si continúa se despublicará." & vbCrLf & "¿Confirma que quiere continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
                Exit Sub
            End If

            Dim CodigoAPI As String
            Dim Sel As String

            Sel = "SELECT Codigo FROM ClientePortales WHERE Portal = 'FotoCasa' and CodigoEmpresa = " & DatosEmpresa.Codigo
            CodigoAPI = BD_CERO.Execute(Sel, False, "")

            If CodigoAPI = "" Then
                MensajeError("No puede DesPublicar en FotoCasa porque no tiene código API de acceso")
            End If

            Gv.ClearColumnsFilter()


            dgvx.ColumnaCheck.ClearSelection()
            dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, True)
            Dim Res As clResultado = DespublicarFotocasa(dgvx.ColumnaCheck.GetSelectedRow(0)("Referencia"), CodigoAPI, "ELIMINAR")

            dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, False)
        End If


        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        EstoyEnAlta = False

        'If ConsultasBaseDatos.MarcaDeTiempoHaCambiado(TablaMantenimiento, BinSrc.Current("MarcaDeTiempo")) Then
        '    bd.RefrescarDatos(BinSrc.Position)
        'End If

        Eliminando = True



        PrevioEliminarInmueble(BinSrc.Current("Referencia"), BinSrc.Current("Baja"), BinSrc.Current("Contador"))

        ''JCB CARPETA FOTOS
        'Dim CarpetaDocumentoAlta As String = GL_CarpetaFotos & "\" & BinSrc.Current("Referencia")
        'Dim CarpetaDocumentoBaja As String = GL_CarpetaFotosBaja & "\" & BinSrc.Current("Referencia")
        'Dim CarpetaDocumentoEliminados As String = GL_CarpetaFotosEliminadas & "\" & BinSrc.Current("Referencia")

        'Dim CarpetaDocumentoOrigen As String
        'Dim CarpetaDocumentoDestino As String

        'If TablaInmuebles = GL_TablaInmuebles Then
        '    CarpetaDocumentoOrigen = CarpetaDocumentoAlta
        '    CarpetaDocumentoDestino = CarpetaDocumentoEliminados
        'Else
        '    CarpetaDocumentoOrigen = CarpetaDocumentoBaja
        '    CarpetaDocumentoDestino = CarpetaDocumentoEliminados
        'End If

        'Dim DirFiles() As String = Nothing

        'If System.IO.Directory.Exists(CarpetaDocumentoOrigen) Then
        '    DirFiles = System.IO.Directory.GetFiles(CarpetaDocumentoOrigen, "*.*")

        '    Try
        '        If DirFiles.Length > 0 Then
        '            If System.IO.Directory.Exists(CarpetaDocumentoDestino) Then
        '                Directory.Delete(CarpetaDocumentoDestino, True)
        '            End If
        '            FuncionesGenerales.Funciones.ComprobarYCrearCarpetas(CarpetaDocumentoDestino)
        '            For i = 0 To DirFiles.Length - 1
        '                Dim NombreFichero As String = My.Computer.FileSystem.GetName(DirFiles(i))
        '                Dim RutaFicheroDestino = CarpetaDocumentoDestino & "\" & NombreFichero
        '                System.IO.File.Copy(DirFiles(i), RutaFicheroDestino)
        '            Next

        '            Try
        '                For i = 0 To DirFiles.Length - 1
        '                    System.IO.File.Delete(DirFiles(i))
        '                Next

        '            Catch ex As Exception

        '            End Try

        '            If TablaInmuebles = GL_TablaInmuebles Then
        '                Dim CarpetaDocumentoPublicadas As String = CarpetaDocumentoOrigen & "\actualizarweb"

        '                'quitar imagenes de la web
        '                Dim ftp As New tb_FTP
        '                'Dim Http = "httpdocs/roberto" 'carpeta de la web
        '                Dim Http As String = GL_ConfiguracionWeb.DirectorioFotos
        '                ftp.FTPBorrarFicherosCarpeta(Http, "jpg")
        '                'quitar imagenes de la carpeta publicados
        '                Try
        '                    If System.IO.Directory.Exists(CarpetaDocumentoPublicadas) Then
        '                        System.IO.Directory.Delete(CarpetaDocumentoPublicadas, True)
        '                    End If
        '                Catch
        '                    MensajeError("Error al borrar fotos publicadas")
        '                End Try
        '            End If

        '            System.IO.Directory.Delete(CarpetaDocumentoOrigen, True)

        '        Else
        '            Exit Sub
        '        End If
        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '        Exit Sub
        '    End Try
        'End If

        '      Dim FilaSeleccionada As Integer = Gv.FocusedRowHandle
        'BinSrc.RemoveCurrent()
        FuncionesBD.Accion("DELETE", "Inmuebles", txtReferencia.EditValue)
        mostrarAlertaPortales()
        Gv.DeleteRow(Gv.FocusedRowHandle)

        BinSrc.EndEdit()

        'bd.RefrescarDatos(, , Gv, BinSrc)
        If Not ActualizarBaseDatos() Then
            Return
        End If
        GL_PropietariosPendienteActualizacion = True
        Me.Cursor = System.Windows.Forms.Cursors.Arrow

        'HabilitarDesHabilitarBotones(False)
        'HabilitarDesHabilitarCajas(False)
        'MostrarOcultarDatosPropietarios(False)

        'If FilaSeleccionada > 1 Then
        '    Gv.FocusedRowHandle = FilaSeleccionada - 1

        'Else
        '    Try
        '        Gv.FocusedRowHandle = FilaSeleccionada + 1
        '    Catch ex As Exception
        '        'HabilitarDesHabilitarBotones(False)
        '    End Try
        'End If


        Eliminando = False
    End Sub
    Private Function Aceptar() As Boolean
        '  Dim FilaSeleccionada As Integer = GvClientes.FocusedRowHandle

        Return Actualizar()

        'GvClientes.FocusedRowHandle = FilaSeleccionada
    End Function
    Private Sub Cancelar()

        BinSrc.CancelEdit()
        HabilitarDesHabilitarBotones(True)
        HabilitarDesHabilitarCajas(False)
        MostrarOcultarDatosPropietarios(False)
    End Sub
    Private Sub PrepararModificacion()

        HabilitarDesHabilitarCajas(True)

        HabilitarDesHabilitarBotones(False)
        txtReferencia.Enabled = False
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        MostrarOcultarDatosPropietarios(True)
        txtReferencia.Enabled = True
        txtReferencia.Focus()
        'cmbTipoVenta.Focus()

    End Sub

    Private Sub PrepararAlta()
        TabPropietarios.PageEnabled = False
        HabilitarDesHabilitarCajas(True)
        HabilitarDesHabilitarBotones(False)
        MostrarOcultarDatosPropietarios(True)


        txtReferencia.Text = ""
        txtReferencia.Enabled = False
        cmbEmpleados.EditValue = GL_CodigoUsuario
        '     chkBaja.Enabled = False
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        cmbClasificacion.EditValue = 0

        PonerChecksEnIndeterminado()

        cmbPoblacion.EditValue = GL_PoblacionPrederminada

        txtMPlaya.EditValue = -9999999
        spnMetrosPlaya.EditValue = 0
        chkMetrosPlaya.Checked = False
        txtReferencia.Enabled = True

        If DatosEmpresa.Codigo = 2 Then
            chkOcultar.Checked = True
        End If

        txtReferencia.EditValue = Funciones.SiguienteLetra(BD_CERO.Execute("SELECT MAX(Referencia) FROM Inmuebles", False))
        txtReferencia.Focus()
        'cmbTipoVenta.Focus()
    End Sub

    Public Sub PonerChecksEnIndeterminado()

        mskFechaAlta.EditValue = ""
        mskUltimaVisita.EditValue = DBNull.Value

        'combos?

        txtObservaciones.Text = ""
        txtExtras.Text = ""

        SliderPequeno.Images.Clear()
        SliderGrande.Images.Clear()


        'ucCocina.Valor = Nothing


        'ucCalentador.RGruop.SelectedIndex = 2

        chkBalcon.CheckState = CheckState.Unchecked
        spnBalconM1.EditValue = 0
        spnBalconM2.EditValue = 0

        chkPatio.CheckState = CheckState.Unchecked
        spnPatioM1.EditValue = 0
        spnPatioM2.EditValue = 0

        chkTerraza.CheckState = CheckState.Unchecked
        spnTerrazaM1.EditValue = 0
        spnTerrazaM2.EditValue = 0

        chkJardin.CheckState = CheckState.Unchecked
        spnJardinM1.EditValue = 0

        chkOcultar.CheckState = CheckState.Unchecked
        chkAlquiladoNosotros.CheckState = CheckState.Unchecked


        chkDuplex.CheckState = CheckState.Unchecked
        chkPiscina.CheckState = CheckState.Unchecked

        chkCocinaOffice.CheckState = CheckState.Unchecked
        chkUrbanizacion.CheckState = CheckState.Unchecked
        chkZonaComercial.CheckState = CheckState.Unchecked
        chkVistasAlMar.CheckState = CheckState.Unchecked
        chkPlayaDerecha.CheckState = CheckState.Unchecked
        chkMontana.CheckState = CheckState.Unchecked
        chkBanco.CheckState = CheckState.Unchecked
        chkAccesoMinusvalidos.CheckState = CheckState.Unchecked

        chkAscensor.CheckState = CheckState.Unchecked
        chkElectrodomesticos.CheckState = CheckState.Unchecked
        chkGaleria.CheckState = CheckState.Unchecked
        chkGarajeCerrado.CheckState = CheckState.Unchecked

        chkAlquilerVacacional.CheckState = CheckState.Unchecked
        chkOpcionCompra.CheckState = CheckState.Unchecked
        chkLlaves.CheckState = CheckState.Unchecked
        chkOportunidad.CheckState = CheckState.Unchecked
        chkExclusiva.CheckState = CheckState.Unchecked
        chkCartel.CheckState = CheckState.Unchecked
        chkEscaparate.CheckState = CheckState.Unchecked

        chkMostrarPPrincipalWeb.CheckState = CheckState.Unchecked
        chkLlavesCanet.CheckState = CheckState.Unchecked

        spnAltura.EditValue = 0
        spnAltura2.EditValue = 0
        spnMetros.EditValue = 0
        spnHabitaciones.EditValue = 0
        spnBanos.EditValue = 0
        '   spnBaneras.EditValue = 0
        spnAnoConstruccion.EditValue = 0
        '   spnDuchas.EditValue = 0
        txtMPlaya.EditValue = -9999999
        spnMetrosPlaya.EditValue = 0
        'chkMetrosPlaya.CheckState = CheckState.Unchecked

        spnMetrosTrastero.EditValue = 0
        spnMetrosGaraje.EditValue = 0

        spnGarajeNumero.EditValue = ""
        spnTrasteroNumero.EditValue = ""


        ucTrasteroVenta.Valor = 0
        ucGarajeVenta.Valor = 0

        spnPrecioTrastero.EditValue = 0

        spnPrecioGaraje.EditValue = 0

        ucTipoCalentador.Valor = Nothing
        ucTipoCocina.Valor = Nothing

        spnAlturaFinca.EditValue = 0
        spnPrecioAgosto.EditValue = 0
        spnPrecioJulio.EditValue = 0
        spnPrecioJunio.EditValue = 0

        spnPrecioComunidad.EditValue = 0
        spnFianzaAlquiler.EditValue = 0
        chkComunidadIncluida.CheckState = CheckState.Checked
    End Sub
    Private Sub PintarPaneles()

        lblGV.ForeColor = Color.Black
        lblTV.ForeColor = Color.Black

        If ucGarajeVenta.Valor Or ucGarajeVenta.Valor Is Nothing Then lblGV.ForeColor = System.Drawing.ColorTranslator.FromHtml("#1b812a")
        If ucTrasteroVenta.Valor Or ucTrasteroVenta.Valor Is Nothing Then lblTV.ForeColor = System.Drawing.ColorTranslator.FromHtml("#1b812a")

        lblCal.ForeColor = Color.Black
        lblCoc.ForeColor = Color.Black

    End Sub


    Private Sub HabilitarDesHabilitarCajas(ByVal Habilitar As Boolean)

        For Each c As Control In pnlDatosGenerales.Controls
            If Not TypeOf (c) Is DevExpress.XtraEditors.LabelControl AndAlso Not TypeOf (c) Is DevExpress.XtraEditors.PanelControl AndAlso Not TypeOf (c) Is DevExpress.XtraEditors.GroupControl Then
                If c.Name <> "Extras3" And c.Name <> "Extras1" And c.Name <> "pnlAlquiler" And c.Name <> "pnlVenta" And c.Name <> "pnlVerano" And c.Name <> "pnlTraspaso" Then
                    c.Enabled = Habilitar
                End If
            End If
        Next


        For Each c As Control In PanelDetalle2.Controls
            If Not TypeOf (c) Is DevExpress.XtraEditors.LabelControl AndAlso Not TypeOf (c) Is DevExpress.XtraEditors.PanelControl AndAlso Not TypeOf (c) Is DevExpress.XtraEditors.GroupControl Then
                c.Enabled = Habilitar
            End If
            'If c.Name <> "GroupControl1" And c.Name <> "lblPersonas" And c.Name <> "lblMPlaya" Then
            '    'If c.Name <> "lblPersonas" And c.Name <> "lblMPlaya" And c.Name <> "ucCocina" And c.Name <> "ucCalentador" Then
            '    c.Enabled = Habilitar
            'End If
        Next
        For Each c As Control In GroupControl1.Controls
            If Not TypeOf (c) Is DevExpress.XtraEditors.LabelControl AndAlso Not TypeOf (c) Is DevExpress.XtraEditors.PanelControl AndAlso Not TypeOf (c) Is DevExpress.XtraEditors.GroupControl Then
                c.Enabled = Habilitar
            End If
        Next
        For Each c As Control In GroupControl4.Controls
            If Not TypeOf (c) Is DevExpress.XtraEditors.LabelControl AndAlso Not TypeOf (c) Is DevExpress.XtraEditors.PanelControl AndAlso Not TypeOf (c) Is DevExpress.XtraEditors.GroupControl Then
                c.Enabled = Habilitar
            End If
        Next


        HabilitarDesHabilitarBotonesEspecialesCuandoVengoDeClientes(Not Habilitar)

        SliderPequeno.Enabled = True
        SliderGrande.Enabled = True

        txtObservaciones.Enabled = True
        txtObservaciones.Properties.ReadOnly = True
        txtExtras.Enabled = True
        txtExtras.Properties.ReadOnly = True
        MemoGrande.Enabled = True
        MemoGrande.Properties.ReadOnly = True

        txtAnosConstruccion.Visible = Not Habilitar
        If txtAnosConstruccion.Visible Then
            spnAnoConstruccion.Properties.Buttons(0).Caption = "Edad"
        Else
            spnAnoConstruccion.Properties.Buttons(0).Caption = "Año Const."
        End If

        If Habilitar Then

            ucTipoCocina.tb_ReadOnly = Not Habilitar
            ucTipoCalentador.tb_ReadOnly = Not Habilitar

            ucTrasteroVenta.tb_ReadOnly = Not Habilitar
            ucGarajeVenta.tb_ReadOnly = Not Habilitar

        End If


        spnAltura2.Enabled = Habilitar

        btnBuscarPropietarios.Enabled = Habilitar
        cmbVia.Enabled = Habilitar
        txtCodPostal.Enabled = Habilitar
        txtProvincia.Enabled = Habilitar

        txtDireccion.Enabled = Habilitar
        txtNumero.Enabled = Habilitar

        txtDireccionMapa.Enabled = Habilitar
        txtDireccion2.Enabled = Habilitar


        txtPuerta.Enabled = Habilitar


    End Sub
    Private Function Actualizar() As Boolean
        Try

            Me.Validate()

            If Not ComprobarDatos() Then
                Return False
            End If

            If chkBalcon.Checked = False AndAlso (spnBalconM1.EditValue > 0 OrElse spnBalconM2.EditValue > 0) Then
                chkBalcon.Checked = True
            End If
            If chkJardin.Checked = False AndAlso spnJardinM1.EditValue > 0 Then
                chkJardin.Checked = True
            End If
            If chkTerraza.Checked = False AndAlso (spnTerrazaM1.EditValue > 0 OrElse spnTerrazaM2.EditValue > 0) Then
                chkTerraza.Checked = True
            End If
            If chkPatio.Checked = False AndAlso (spnPatioM1.EditValue > 0 OrElse spnPatioM2.EditValue > 0) Then
                chkPatio.Checked = True
            End If
            If ucGarajeVenta.Valor = 0 AndAlso (spnMetrosGaraje.EditValue > 0 OrElse spnPrecioGaraje.EditValue > 0) Then
                If spnMetrosGaraje.EditValue > 0 OrElse spnPrecioGaraje.EditValue = 0 Then
                    ucGarajeVenta.Valor = 1
                Else
                    ucGarajeVenta.Valor = Nothing
                End If
            End If
            If ucTrasteroVenta.Valor = 0 AndAlso (spnMetrosTrastero.EditValue > 0 OrElse spnPrecioTrastero.EditValue > 0) Then
                If spnMetrosTrastero.EditValue > 0 OrElse spnPrecioTrastero.EditValue = 0 Then
                    ucTrasteroVenta.Valor = 1
                Else
                    ucTrasteroVenta.Valor = Nothing
                End If
            End If

            If spnMetrosPlaya.EditValue <= 0 Then
                '   BinSrc.Current("MPlaya") = -9999999
                txtMPlaya.EditValue = -9999999
                spnMetrosPlaya.EditValue = 0
            Else
                ' BinSrc.Current("MPlaya") = spnMetrosPlaya.EditValue
                txtMPlaya.EditValue = spnMetrosPlaya.EditValue
            End If


            'If chkMetrosPlaya.Checked Then
            '    txtMPlaya.EditValue = spnMetrosPlaya.EditValue
            'Else
            '    Select Case spnMetrosPlaya.EditValue
            '        Case 0 : txtMPlaya.EditValue = -9999999
            '        Case Is > 0 : txtMPlaya.EditValue = spnMetrosPlaya.EditValue * -1
            '    End Select
            'End If

            txtReferencia.EditValue = txtReferencia.EditValue.ToString.Trim

            If EstoyEnAlta Then
                If BD_CERO.Execute("SELECT COUNT(*) FROM Inmuebles WHERE Referencia='" & txtReferencia.EditValue & "'", False) > 0 Then
                    MensajeError("Ya existe esta referencia. Si no la encuentra en el listado es porque se encuentra en inmuebles de baja.")
                    Return False
                End If
                'BinSrc.Current("FechaAlta") = Microsoft.VisualBasic.Today
                mskFechaAlta.EditValue = Microsoft.VisualBasic.Today
                ' BinSrc.Current("Referencia") = clGenerales.SiguienteRegistro("CONVERT(INT,Referencia) ", "Inmuebles", " WHERE Delegacion =1")

                BinSrc.Current("Delegacion") = 1
                BinSrc.Current("CodigoEmpresa") = DatosEmpresa.Codigo
                BinSrc.Current("ContadorEmpleado") = GL_CodigoUsuario

                If BinSrc.Current("DireccionMapa") = "" Then
                    BinSrc.Current("DireccionMapa") = BinSrc.Current("Direccion")
                End If


                BinSrc.Current("CambioPrecio") = ""
                If spnAnoConstruccion.EditValue Is DBNull.Value Then
                    BinSrc.Current("Años") = 0
                Else
                    If spnAnoConstruccion.EditValue = 0 Then
                        BinSrc.Current("Años") = 0
                    Else
                        BinSrc.Current("Años") = Year(Today) - spnAnoConstruccion.EditValue
                    End If

                End If
                txtAnosConstruccion.Text = DateDiff(DateInterval.Year, "#1/1/" & spnAnoConstruccion.EditValue & "#", Today())
                Dim Fecha As Date = Now
                BinSrc.Current("FechaUltimoCambio") = Fecha
                BinSrc.Current("FechaAlta") = Fecha

                If chkCartel.CheckState = CheckState.Checked Then
                    BinSrc.Current("QuienCartel") = GL_CodigoUsuario
                    BinSrc.Current("FechaCartel") = Today
                Else
                    BinSrc.Current("QuienCartel") = 0
                End If

                'txtReferencia.EditValue = clGenerales.SiguienteRegistro(Funciones.SQL_CONVERT("INT", "Referencia"), "UltimaReferencia", " WHERE CodigoEmpresa =" & DatosEmpresa.Codigo)
                'Dim NuevoContador As Integer = clGenerales.SiguienteRegistro("Contador", "UltimaReferencia", " WHERE CodigoEmpresa =" & DatosEmpresa.Codigo)
                Dim NuevoContador2 As Integer = clGenerales.SiguienteRegistro("Contador", "Inmuebles")

                'If NuevoContador2 > NuevoContador Then
                '    NuevoContador = NuevoContador2
                'End If

                'BD_CERO.Execute(GL_SQL_DELETE & "FROM UltimaReferencia WHERE CodigoEmpresa=" & DatosEmpresa.Codigo)
                'BD_CERO.Execute("INSERT INTO UltimaReferencia (CodigoEmpresa, Referencia, Contador) VALUES(" & DatosEmpresa.Codigo & ",'" & txtReferencia.EditValue & "', " & NuevoContador2 & ")") 

                BinSrc.Current("Contador") = NuevoContador2 'NuevoContador

            Else
                If BD_CERO.Execute("SELECT COUNT(*) FROM Inmuebles WHERE Referencia='" & txtReferencia.EditValue & "' AND Contador <> " & BinSrc.Current("Contador"), False) > 0 Then
                    MensajeError("Ya existe esta referencia. Si no la encuentra en el listado es porque se encuentra en inmuebles de baja.")
                    Return False
                End If
                Dim ReferenciaVieja As String = BD_CERO.Execute("SELECT Referencia FROM Inmuebles WHERE Contador=" & BinSrc.Current("Contador"), False)
                If ReferenciaVieja <> BinSrc.Current("Referencia") Then

                    If Not DatosEmpresa.WordPress AndAlso GL_ConfiguracionWeb.web3B AndAlso Not Debugger.IsAttached Then

                        Try
                            Dim Ser As New WebServiceVenalia.WebServiceVenaliaClient

                            If Not Ser.CambiaReferencia("TresBits", "EE358CB6BF1683287B21B102BBC848EB", DatosEmpresa.Codigo, ReferenciaVieja, BinSrc.Current("Referencia")) Then
                                'MensajeError("Error al cambiar la Referencia en la WEB, compruebe la conexión.")
                                FuncionesBD.Accion("CAMBIOREFERENCIA", "Inmuebles", BinSrc.Current("Referencia"), Valor:=ReferenciaVieja, MensajeError:="Error")
                                'Return False
                            End If
                        Catch FaultEX As ServiceModel.FaultException(Of WebServiceVenalia.clResultado)
                            'MensajeError("Error al cambiar la Referencia en la WEB, compruebe la conexión.")
                            'MessageBox.Show(FaultEX.Message)
                            'txtReferencia.EditValue = ReferenciaVieja
                            'BinSrc.Current("Referencia") = ReferenciaVieja
                            FuncionesBD.Accion("CAMBIOREFERENCIA", "Inmuebles", BinSrc.Current("Referencia"), Valor:=ReferenciaVieja, MensajeError:=FaultEX.Message)
                            'Return False

                        Catch ex As Exception
                            'MensajeError("Error al cambiar la Referencia en la WEB, compruebe la conexión.")
                            'MessageBox.Show(ex.Message)
                            'txtReferencia.EditValue = ReferenciaVieja
                            'BinSrc.Current("Referencia") = ReferenciaVieja
                            FuncionesBD.Accion("CAMBIOREFERENCIA", "Inmuebles", BinSrc.Current("Referencia"), Valor:=ReferenciaVieja, MensajeError:=ex.Message)
                            'Return False

                        End Try

                    End If

                    If System.IO.Directory.Exists(GL_CarpetaFotos & "/" & ReferenciaVieja) Then
                        Try
                            Dim rutanueva As String = GL_CarpetaFotos & "/" & BinSrc.Current("Referencia")
                            If System.IO.Directory.Exists(rutanueva) Then
                                Funciones.BorrarContenidoCarpeta(rutanueva, True)
                            End If

                            My.Computer.FileSystem.RenameDirectory(GL_CarpetaFotos & "/" & ReferenciaVieja, BinSrc.Current("Referencia"))
                        Catch ex As Exception
                            ' MensajeError("Error al cambiar la carpeta de fotos del Inmueble, intente cambiarla a mano o no se verán las fotos." & vbCrLf & "(Ref. anterior: " & ReferenciaVieja & " - Ref. nueva: " & BinSrc.Current("Referencia") & ").")
                            '   Shell("explorer.exe root = " & GL_CarpetaFotos, vbNormalFocus)
                            'Return False
                        End Try
                    End If
                End If
                'If Not Eliminando Then
                '    If Gv.GetFocusedRowCellValue("FuturoCliente") = True And BinSrc.Current("FuturoCliente") = 0 Then
                '        MsgBox("")
                '    End If
                'End If
                txtAnosConstruccion.Text = DateDiff(DateInterval.Year, "#1/1/" & spnAnoConstruccion.EditValue & "#", Today())

                If PrecioAntes <> 0 AndAlso PrecioAntes <> spnPrecio.EditValue Then
                    Dim SubeBaja As String = ""
                    If PrecioAntes < spnPrecio.EditValue Then
                        SubeBaja = "SUBE"
                    Else
                        SubeBaja = "BAJA"
                    End If
                    BinSrc.Current("CambioPrecio") = SubeBaja

                    Dim Fecha As Date = Now
                    BinSrc.Current("FechaUltimoCambio") = Fecha
                    BinSrc.Current("FechaCambioPrecio") = Fecha

                    Dim Sel As String = "INSERT INTO CambiosPrecio (ContadorInmueble, ContadorEmpleado, Fecha, PrecioAntes, PrecioDespues) VALUES (" & BinSrc.Current("Contador") & ", " & GL_CodigoUsuario & ", " & GL_SQL_GETDATE & ", " & FuncionesGenerales.Funciones.ReplacePuntos(PrecioAntes) & ", " & FuncionesGenerales.Funciones.ReplacePuntos(spnPrecio.EditValue) & ")"
                    BD_CERO.Execute(Sel)
                End If



                PrecioAntes = spnPrecio.EditValue

                If Not ValorCartelAntes AndAlso chkCartel.CheckState = CheckState.Checked Then
                    BinSrc.Current("QuienCartel") = GL_CodigoUsuario
                    BinSrc.Current("FechaCartel") = Today
                End If

            End If

            'Dim v As DevExpress.XtraGrid.Views.Grid.GridView
            'v = cmbPoblacion.Properties.View
            Dim prov As String '= v.GetFocusedRowCellValue("Provincia")

            'If IsNothing(prov) Then
            prov = BD_CERO.Execute("SELECT Provincia FROM Poblacion WHERE Poblacion ='" & Funciones.pf_ReplaceComillas(cmbPoblacion.EditValue) & "'", False, "") 'Predeterminada = " & GL_SQL_VALOR_1, False, "")
            'End If
            BinSrc.Current("Provincia") = prov

            'If BinSrc.Item(BinSrc.Count - 1)("Observaciones") Is DBNull.Value Then
            '    BinSrc.Item(BinSrc.Count - 1)("Observaciones") = ""
            'End If
            'BinSrc.Current("UltimaVisita") = Today
            ''BinSrc.Current(23) = Today
            ''BinSrc.Current(24) = Today
            ''BinSrc.Current(25) = Today
            ''BinSrc.Current(26) = Today

            'mskUltimaVisita.EditValue = Today


            'Dim dr As DataRowView
            'dr = BinSrc.Current

            'For i = 0 To 108

            '    If IsDBNull(dr(i)) Then
            '        Dim a = ""
            '    End If

            'Next

            BinSrc.EndEdit()


            'dr = BinSrc.Current
            'For i = 0 To 108

            '    If IsDBNull(dr(i)) Then
            '        Dim a = ""
            '    End If

            'Next


            'For i = 0 To  

            '    If IsDBNull(dr(i)) Then
            '        Dim a = ""
            '    End If

            'Next


            Dim ValorClaveAntes As Object = Gv.GetFocusedRowCellValue("Referencia")

            If Not ActualizarBaseDatos() Then
                Return False
            End If

            If EstoyEnAlta Then

                'Dim SelConsulta As String

                'bd.Execute("UPDATE Inmuebles set PrecioVerano = PrecioJunio WHERE Contador = " & BinSrc.Current("Contador"))
                'bd.Execute("INSERT INTO NuevasAltas SELECT " & BinSrc.Current("Contador") & ", " & gl_sql_getdate & "")
                '   BD_CERO.Execute("UPDATE Inmuebles SET FechaAlta= " & gl_sql_getdate & ",FechaCambioPrecio=" & gl_sql_getdate & ",FechaUltimoCambio=" & gl_sql_getdate & " WHERE Contador=" & BinSrc.Current("Contador"))
                'SelConsulta = "INSERT INTO CambiosPrecio (ContadorInmueble, ContadorEmpleado, Fecha, Precio,Cambio)" & _
                '    " SELECT Contador, ContadorEmpleado, " & gl_sql_getdate & ", Precio, ''" & _
                '    " FROM   inmuebles WHERE Contador = " & BinSrc.Current("Contador")
                'bd.Execute(SelConsulta)
                'If BD_CERO.Execute("SELECT COUNT(*) FROM CambiosPrecio WHERE ContadorInmueble = " & BinSrc.Current("Contador")) > 1 Then
                '    BD_CERO.Execute("" & GL_SQL_DELETE & "FROM NuevosCambiosPrecios WHERE ContadorInmueble = " & BinSrc.Current("Contador"))
                'End If
                'BD_CERO.Execute("INSERT INTO NuevosCambiosPrecios VALUES (" & BinSrc.Current("Contador") & " , " & gl_sql_getdate & " )")


                'SelConsulta = "INSERT INTO InmueblesCarteles VALUES(" & BinSrc.Current("Contador") & "," & GL_CodigoUsuario & "," & gl_sql_getdate & "," & FuncionesGenerales.Funciones.pf_ReplaceTrueFalse(BinSrc.Current("Cartel")) & ")"
                'bd.Execute(SelConsulta)


                Dim Sel As String = "SELECT Nombre, Telefono1, Telefono2, Telefono3, Telefono4, TelefonoMovil, Email " &
                             " ,NoQuiereRecibirEmails, NoAnimales, AvisadoTresPorCien, AvisadoMensualidad, NoInmobiliaria " &
                             " FROM Propietarios WHERE Contador = " & txtContadorPropietario.EditValue

                Dim dtr As Object
                Dim bdPobs As New BaseDatos

                Dim Elementos As String = ""
                dtr = bdPobs.ExecuteReader(Sel)
                If dtr.HasRows Then
                    While dtr.Read
                        BinSrc.Current("Propietario") = dtr("Nombre")
                        BinSrc.Current("Telefono1Propietario") = dtr("Telefono1")
                        BinSrc.Current("Telefono2Propietario") = dtr("Telefono2")
                        BinSrc.Current("Telefono3Propietario") = dtr("Telefono3")
                        BinSrc.Current("Telefono4Propietario") = dtr("Telefono4")

                        BinSrc.Current("TelefonoMovilPropietario") = dtr("TelefonoMovil")
                        BinSrc.Current("EmailPropietario") = dtr("Email")

                        BinSrc.Current("AvisadoTresPorCien") = dtr("AvisadoTresPorCien")
                        BinSrc.Current("AvisadoMensualidad") = dtr("AvisadoMensualidad")
                        BinSrc.Current("NoInmobiliaria") = dtr("NoInmobiliaria")
                        BinSrc.Current("NoQuiereRecibirEmails") = dtr("NoQuiereRecibirEmails")
                        BinSrc.Current("NoAnimales") = dtr("NoAnimales")



                    End While
                End If
                dtr.Close()




                BinSrc.Current("Inmuebles") = clGenerales.Cuenta("Inmuebles", "ContadorPropietario = " & txtContadorPropietario.EditValue)
                'UcInmueblesPropietario1.LlenarGridInmuebles()
                HacerCambioFila()

                FuncionesBD.Accion("INSERT", "Inmuebles", txtReferencia.EditValue)

                '  LlenarGrid()

                Dim obs As New Tablas.clComunicaciones
                With obs
                    .Tipo = GL_OBSERVACIONES_LLAMADA
                    .Tabla = GL_TablaPropietarios
                    .ContadorClientePropietarioInmueble = txtContadorPropietario.EditValue
                    .CodigoEmpresa = DatosEmpresa.Codigo
                    .ContadorEmpleado = GL_CodigoUsuario
                    .Delegacion = Gl_Delegacion
                    .Observaciones = "Nuevo Inmueble Referencia: " & BinSrc.Current("Referencia")
                    .ContadorInmueble = BinSrc.Current("Contador")
                    .LlamadaContestada = True
                End With

                ConsultasBaseDatos.InsertarComunicacionesObservaciones(obs)

                If DeDondeVengo = GL_VENGO_DE_PROPIETARIOS Then
                    uPropietariosActivo.UcComunicacionesDetalle1.LlenarGrid(txtContadorPropietario.EditValue, GL_TablaPropietarios, BinSrc.Current("Contador"))
                End If
            Else

                'If ValorCartelAntes <> chkCartel.CheckState Then
                '    bd.Execute("INSERT INTO InmueblesCarteles VALUES(" & BinSrc.Current("Contador") & "," & GL_CodigoUsuario & "," & gl_sql_getdate & "," & FuncionesGenerales.Funciones.pf_ReplaceTrueFalse(BinSrc.Current("Cartel")) & ")")
                'End If
                FuncionesBD.Accion("UPDATE", "Inmuebles", txtReferencia.EditValue)
            End If
            'Me.ClientesTableAdapter.Update(DsClientes.Clientes)
            'DsClientes.AcceptChanges()
            'Me.ClientesTableAdapter.Fill(Me.DsClientes.Clientes)

            bd.RefrescarDatos()

            If Not EstoyEnAlta Then
                'If BinSrc.Current("PortalFotoCasa") Then
                If BD_CERO.Execute("SELECT PortalFotoCasa FROM Inmuebles WHERE Contador = " & BinSrc.Current("Contador"), False) Then
                    'Chequear esta fila
                    dgvx.ColumnaCheck.ClearSelection()
                    dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, True)
                    PublicarFotoCasa(False)
                    dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, False)

                End If

            End If

            If Not Eliminando AndAlso ValorClaveAntes IsNot Nothing Then
                SituarseEnGrid(Gv, ValorClaveAntes.ToString, "Referencia")
            End If
            HabilitarDesHabilitarBotones(True)
            HabilitarDesHabilitarCajas(False)
            MostrarOcultarDatosPropietarios(False)
            mostrarAlertaPortales()

            'If Not IsNothing(uPropietariosActivo) Then
            '    uPropietariosActivo.LlenarGridInmuebles()
            'End If

            GL_PropietariosPendienteActualizacion = True

            Return True

        Catch ex As SqlClient.SqlException

            XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'DsClientes.RejectChanges()
            'DsClientes.AcceptChanges()

            Return False

        Catch ex3 As OleDb.OleDbException

            XtraMessageBox.Show(ex3.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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




    Private Function ActualizarBaseDatos(Optional ByVal RefrescarDatos As Boolean = False) As Boolean

        Try

            Dim ContadorMinimo As Integer = 0

            If EstoyEnAlta Then
                ContadorMinimo = clGenerales.Maximo("Contador", TablaMantenimiento)
            End If


            bd.ActualizarCambios(TablaMantenimiento, bd.ds, RefrescarDatos)

            'If EstoyEnAlta Then

            '    CargandoInmuebles = True


            '    'Se supone que el cliente ya está dado de alta en la bd.
            '    'Como el contador es autonumérico, no lo tenemos en el dataset.
            '    'Con lo siguiente, vamos a acutaliazar el dataset con el contador que le han asignado al cliente
            '    Dim NuevoContador As Integer

            '    NuevoContador = ConsultasBaseDatos.ObtenerContadorInmuebleEnAlta(BinSrc.Current("Referencia"), ContadorMinimo, GL_CodigoUsuario)

            '    Dim dt As DataTable
            '    Dim dr As DataRow
            '    dt = bd.ds.Tables(TablaMantenimiento)
            '    dr = dt.Rows(bd.ds.Tables(TablaMantenimiento).Rows.Count - 1)

            '    If BinSrc.Current("Referencia") = dr("Referencia") And (dr("Contador") Is DBNull.Value OrElse dr("Contador") = 0) Then
            '        Dim bdMarcaTiempo As New BaseDatos
            '        'Dim MarcaDeTiempo As Byte() = bdMarcaTiempo.Execute("SELECT MarcaDeTiempo FROM " & TablaMantenimiento & " WHERE Contador = " & NuevoContador, False)

            '        dr.BeginEdit()
            '        dr("Contador") = NuevoContador
            '        'dr("MarcaDeTiempo") = MarcaDeTiempo
            '        dr.EndEdit()
            '        bd.ds.AcceptChanges()
            '    End If

            '    CargandoInmuebles = False


            'End If



            Return True

        Catch ex As SqlClient.SqlException
            If ex.Number = 2627 Then
                MensajeError(GL_ValorDuplicado)
            Else
                MensajeError(ex.Message)
            End If

            '  bd.ds.RejectChanges()
            Return False
        Catch ex2 As Exception
            MensajeError(ex2.Message)

            Return False
        End Try
    End Function

    Private Function ComprobarDatos() As Boolean

        If DeDondeVengo = GL_VENGO_DE_PROPIETARIOS And NuevoInmueble = True Then
            txtContadorPropietario.EditValue = ContadorPropietarioDeDondeVengo
        End If
        If IsDBNull(txtContadorPropietario.EditValue) OrElse txtContadorPropietario.EditValue Is Nothing OrElse txtContadorPropietario.EditValue = 0 OrElse txtContadorPropietario.Text = "" Then
            MensajeError("Debe seleccionar un Propietario")
            txtPropietario.Focus()
            Return False
        End If

        If txtReferencia.Text.ToString.Trim = "" And Not EstoyEnAlta Then
            MensajeError("El campo código no puede estar vacío")
            txtReferencia.Focus()
            Return False
        End If

        If cmbPoblacion.Text = "" OrElse cmbTipo.Text = "" OrElse cmbTipoVenta.Text = "" Then
            MensajeError("Los campos población, oferta y tipo deben rellenarse.")
            Return False
        End If

        If (Not ucTrasteroVenta.Valor Or ucTrasteroVenta.Valor) And spnPrecioTrastero.EditValue <> 0 Then
            MensajeError("Solamente se puede poner precio al trastero si está marcado como opcional")
            Return False
        End If
        If ucTrasteroVenta.Valor Is Nothing And spnPrecioTrastero.EditValue = 0 Then
            If XtraMessageBox.Show("Ha marcado el trastero como opcional y no le ha puesto precio" & vbCrLf & "¿Quiere continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
                Return False
            End If
        End If


        If (Not ucGarajeVenta.Valor Or ucGarajeVenta.Valor) And spnPrecioGaraje.EditValue <> 0 Then
            MensajeError("Solamente se puede poner precio al Garaje si está marcado como opcional")
            Return False
        End If

        If Not ucGarajeVenta.Valor AndAlso chkGarajeCerrado.Checked Then
            If XtraMessageBox.Show("Ha marcado que Garaje cerrado pero no hay Garaje" & vbCrLf & "¿Quiere continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
                Return False
            End If
            'chkGarajeCerrado.Checked = False
            '  Return False
        End If

        If ucGarajeVenta.Valor Is Nothing And spnPrecioGaraje.EditValue = 0 Then
            If XtraMessageBox.Show("Ha marcado el Garaje como opcional y no le ha puesto precio" & vbCrLf & "¿Quiere continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
                Return False
            End If
        End If
        If DatosEmpresa.Codigo <> 2 Then
            If chkMostrarPPrincipalWeb.Checked AndAlso BD_CERO.Execute("SELECT COUNT(*) FROM Inmuebles WHERE MostrarPPrincipalWeb <> 0", False) >= 12 Then
                XtraMessageBox.Show("No se pueden marcar más de 12 inmuebles para mostrar en la pantalla principal de la web", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
        End If

        If txtReferencia.EditValue.contains("/") OrElse txtReferencia.EditValue.contains("\") OrElse txtReferencia.EditValue.contains(".") OrElse txtReferencia.EditValue.contains("%") OrElse txtReferencia.EditValue.contains("=") OrElse txtReferencia.EditValue.contains("?") OrElse txtReferencia.EditValue.contains(",") Then
            XtraMessageBox.Show("Solo se permiten los caracteres especiales - y _ en la Referencia", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        'If ucGarajeVenta.chkValorCheck.Checked <> ucGarajeAlquiler.chkValorCheck.Checked Then
        '    If chkVenta.Checked And chkAlquiler.Checked Then
        '        MensajeError("Garaje cerrado no puede ser distinto en venta y en alquiler")
        '        Return False
        '    End If

        '    If chkVenta.Checked And Not chkAlquiler.Checked Then
        '        ucGarajeAlquiler.chkValorCheck.Checked = ucGarajeVenta.chkValorCheck.Checked
        '    End If
        '    If Not chkVenta.Checked And chkAlquiler.Checked Then
        '        ucGarajeVenta.chkValorCheck.Checked = ucGarajeAlquiler.chkValorCheck.Checked
        '    End If
        'End If

        'If ucGarajeVenta.spnValorCajaTexto2.EditValue <> ucGarajeAlquiler.spnValorCajaTexto2.EditValue Then
        '    If chkVenta.Checked And chkAlquiler.Checked Then
        '        MensajeError("Metros Garaje no puede ser distinto en venta y en alquiler")
        '        Return False
        '    End If

        '    If chkVenta.Checked And Not chkAlquiler.Checked Then
        '        ucGarajeAlquiler.spnValorCajaTexto2.EditValue = ucGarajeVenta.spnValorCajaTexto2.EditValue
        '    End If
        '    If Not chkVenta.Checked And chkAlquiler.Checked Then
        '        ucGarajeVenta.spnValorCajaTexto2.EditValue = ucGarajeAlquiler.spnValorCajaTexto2.EditValue
        '    End If
        'End If

        'If ucTrasteroVenta.spnValorCajaTexto2.EditValue <> ucTrasteroAlquiler.spnValorCajaTexto2.EditValue Then
        '    If chkVenta.Checked And chkAlquiler.Checked Then
        '        MensajeError("Metros Trastero no puede ser distinto en venta y en alquiler")
        '        Return False
        '    End If

        '    If chkVenta.Checked And Not chkAlquiler.Checked Then
        '        ucTrasteroAlquiler.spnValorCajaTexto2.EditValue = ucTrasteroVenta.spnValorCajaTexto2.EditValue

        '    End If
        '    If Not chkVenta.Checked And chkAlquiler.Checked Then
        '        ucTrasteroVenta.spnValorCajaTexto2.EditValue = ucTrasteroAlquiler.spnValorCajaTexto2.EditValue
        '    End If
        'End If


        Return True

    End Function


    Private Sub dgvxClientes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvx.KeyDown

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

        'If e.KeyCode = Keys.F1 And btnAceptar.Enabled = False Then
        '    Anadir()
        '    Exit Sub
        'End If

        'If e.KeyCode = Keys.F2 And btnAceptar.Enabled = False Then
        '    Eliminar()
        '    Exit Sub
        'End If

        'If e.KeyCode = Keys.F3 And btnAceptar.Enabled = False Then
        '    Modificar(False)
        '    Exit Sub
        'End If

        'If e.KeyCode = Keys.F12 Then
        '    Aceptar()
        '    Exit Sub
        'End If

    End Sub
#Region "ParaKeyPreview"

    Private Structure MSG
        Public hwnd As IntPtr
        Public message As Integer
        Public wParam As IntPtr
        Public lParam As IntPtr
        Public time As Integer
        Public pt_x As Integer
        Public pt_y As Integer
    End Structure

    <Runtime.InteropServices.DllImport("user32.dll", CharSet:=Runtime.InteropServices.CharSet.Auto)>
    Private Shared Function PeekMessage(<Runtime.InteropServices.In(), Runtime.InteropServices.Out()> ByRef msg As MSG, hwnd As Runtime.InteropServices.HandleRef, msgMin As Integer, msgMax As Integer, remove As Integer) As Boolean
    End Function
    ''' <span class="code-SummaryComment"><summary> </span>
    ''' Trap any keypress before child controls get hold of them
    ''' <span class="code-SummaryComment"></summary></span>
    ''' <span class="code-SummaryComment"><param name="m">Windows message</param></span>
    ''' <span class="code-SummaryComment"><returns>True if the keypress is handled</returns></span>
    Protected Overrides Function ProcessKeyPreview(ByRef m As Message) As Boolean
        Const WM_KEYDOWN As Integer = &H100
        Const WM_KEYUP As Integer = &H101
        Const WM_CHAR As Integer = &H102
        Const WM_SYSCHAR As Integer = &H106
        Const WM_SYSKEYDOWN As Integer = &H104
        Const WM_SYSKEYUP As Integer = &H105
        Const WM_IME_CHAR As Integer = &H286

        Dim e As KeyEventArgs = Nothing

        If (m.Msg <> WM_CHAR) AndAlso (m.Msg <> WM_SYSCHAR) AndAlso (m.Msg <> WM_IME_CHAR) Then
            e = New KeyEventArgs(DirectCast(CInt(CLng(m.WParam)), Keys) Or ModifierKeys)
            If (m.Msg = WM_KEYDOWN) OrElse (m.Msg = WM_SYSKEYDOWN) Then
                TrappedKeyDown(e)
            End If
            'else
            '{
            '    TrappedKeyUp(e);
            '}

            ' Remove any WM_CHAR type messages if supresskeypress is true.
            If e.SuppressKeyPress Then
                Me.RemovePendingMessages(WM_CHAR, WM_CHAR)
                Me.RemovePendingMessages(WM_SYSCHAR, WM_SYSCHAR)
                Me.RemovePendingMessages(WM_IME_CHAR, WM_IME_CHAR)
            End If

            If e.Handled Then
                Return e.Handled
            End If
        End If
        Return MyBase.ProcessKeyPreview(m)
    End Function

    Private Sub RemovePendingMessages(msgMin As Integer, msgMax As Integer)
        If Not Me.IsDisposed Then
            Dim msg As New MSG()
            Dim handle As IntPtr = Me.Handle
            While PeekMessage(msg, New Runtime.InteropServices.HandleRef(Me, handle), msgMin, msgMax, 1)
            End While
        End If
    End Sub

    ''' <span class="code-SummaryComment"><summary></span>
    ''' This routine gets called if a keydown has been trapped 
    ''' before a child control can get it.
    ''' <span class="code-SummaryComment"></summary></span>
    ''' <span class="code-SummaryComment"><param name="e"></param></span>
    Private Sub TrappedKeyDown(e As KeyEventArgs)

        If e.KeyCode = Keys.Escape And btnAceptar.Visible = True Then

            Try
                Cancelar()
                e.Handled = True
                e.SuppressKeyPress = True
            Catch ex As Exception

            End Try

        End If

        If e.KeyCode = Keys.F1 And btnAceptar.Visible = False Then
            Anadir()
            e.Handled = True
            e.SuppressKeyPress = True
            Exit Sub
        End If

        If e.KeyCode = Keys.F2 And btnAceptar.Visible = False Then
            Eliminar()
            e.Handled = True
            e.SuppressKeyPress = True
            Exit Sub
        End If

        If e.KeyCode = Keys.F3 And btnAceptar.Visible = False Then
            Modificar(False)
            e.Handled = True
            e.SuppressKeyPress = True
            Exit Sub
        End If

        If e.KeyCode = Keys.F12 Then
            Aceptar()
            e.Handled = True
            e.SuppressKeyPress = True
            Exit Sub
        End If

        If (e.KeyCode = Keys.Up Or e.KeyCode = Keys.Right) And SliderGrande.Visible Then
            SliderGrande.SlideNext()
            e.Handled = True
            e.SuppressKeyPress = True
            Exit Sub
        End If

        If (e.KeyCode = Keys.Down Or e.KeyCode = Keys.Left) And SliderGrande.Visible Then
            SliderGrande.SlidePrev()
            e.Handled = True
            e.SuppressKeyPress = True
            Exit Sub
        End If


        If (e.KeyCode = Keys.Enter) And SliderGrande.Visible Then
            SliderGrande.Visible = False
            e.Handled = True
            e.SuppressKeyPress = True
            Exit Sub
        End If



    End Sub

#End Region
    'Private Sub habilitabotones(si As Boolean)

    '    btnModificar.Enabled = si
    '    btnEliminar.Enabled = si

    '    If Not si Then
    '        btnAceptar.Enabled = si
    '        btnCancelar.Enabled = si
    '    End If

    '    btnDarDeBaja.Enabled = si
    '    btnClientes.Enabled = si
    '    btnFotos.Enabled = si
    '    btnImprimir.Enabled = si
    '    btnAnadirObservaciones.Enabled = si
    '    btnReservar.Enabled = si
    'End Sub

    Private Sub HabilitarDesHabilitarAnadirModificarBorrar(ByVal Habilitar)
        btnAnadir.Enabled = Habilitar
        btnModificar.Enabled = Not Habilitar
        btnEliminar.Enabled = Not Habilitar
        If bd.ds.Tables(TablaMantenimiento).Rows.Count > 0 Then
            btnModificar.Enabled = Habilitar
            btnEliminar.Enabled = Habilitar
        End If
        'btnDuplicar.Enabled = Habilitar
        MenuGrid.PopMenuDuplicarInmueble.Visible = Habilitar
        btnClientes.Enabled = Habilitar
        btnAnadirObservaciones.Enabled = Habilitar
        btnEmails.Enabled = Habilitar
        btnImprimir.Enabled = Habilitar
        btnReservar.Enabled = Habilitar
        btnVisitas.Enabled = Habilitar
        btnBuscar.Enabled = Habilitar
        btnVerEnWeb.Enabled = Habilitar
        btnFotos.Enabled = Habilitar

        '       btnFotos.Enabled = Habilitar
    End Sub

    Private Sub HabilitarDesHabilitarBotones(ByVal Habilitar As Boolean)


        HabilitarDesHabilitarAnadirModificarBorrar(Habilitar)

        btnAceptar.Enabled = Not Habilitar
        btnCancelar.Enabled = Not Habilitar
        btnSalir.Enabled = Habilitar

        btnVerBajas.Enabled = Habilitar
        'btnDarDeBaja.Enabled = Habilitar
        MenuGrid.PopMenuDarDeBajaInmueble.Visible = Habilitar
        '   btnVisitas.Enabled = Habilitar
        btnClientes.Enabled = Habilitar
        btnEmails.Enabled = Habilitar
        btnAnadirObservaciones.Enabled = Habilitar

        btnFotos.Enabled = Habilitar
        btnVerEnWeb.Enabled = Habilitar
        btnLlamar.Enabled = Habilitar

        UcInmueblesPropietario1.Enabled = Habilitar

        dgvx.Enabled = Habilitar

        'For Each Page As DevExpress.XtraTab.XtraTabPage In XtraTabControl1.TabPages
        '    Page.PageEnabled = True
        'Next

        HabilitarDesHabilitarBotonesEspecialesCuandoVengoDeClientes(Habilitar)

        btnMostrarListado.Enabled = Habilitar
        btnVerTodos.Enabled = Habilitar
        btnDirecciones.Enabled = Habilitar
        txtBusquedaEmailTelefono.Enabled = Habilitar
        cmbPerfiles.Enabled = Habilitar
        cmbFiltros.Enabled = Habilitar
        'txtObservaciones.Enabled = Habilitar
        txtObservaciones.Properties.ReadOnly = Habilitar
        txtExtras.Properties.ReadOnly = Habilitar
        MemoGrande.Properties.ReadOnly = Habilitar
        SliderPequeno.Enabled = Habilitar
        SliderGrande.Enabled = Habilitar

    End Sub
    Private Sub HabilitarDesHabilitarBotonesEspecialesCuandoVengoDeClientes(ByVal Habilitar As Boolean)
        If Me.ContadorClienteDeDondeVengo <> 0 Then
            '  btnEmailDetalle.Enabled = Habilitar
        Else
            '  btnEmailDetalle.Enabled = False
        End If
    End Sub
    'Private Sub ModificarCambiaBotones()
    '    btnsModificar(Not btnModificar.Enabled)
    'End Sub
    'Private Sub btnsModificar(si As Boolean)

    '    btnAnadir.Enabled = si
    '    btnModificar.Enabled = si
    '    btnAceptar.Enabled = Not si
    '    btnCancelar.Enabled = Not si
    '    btnEliminar.Enabled = si
    '    btnSalir.Enabled = si

    '    btnDarDeBaja.Enabled = si
    '    btnVerBajas.Enabled = si
    '    btnFotos.Enabled = si
    '    btnClientes.Enabled = si
    '    btnImprimir.Enabled = si
    '    btnEmails.Enabled = si
    '    btnAnadirObservaciones.Enabled = si

    '    dgvx.Enabled = si

    '    'For Each Page As DevExpress.XtraTab.XtraTabPage In XtraTabControl1.TabPages
    '    '    Page.PageEnabled = True
    '    'Next



    'End Sub

    'Private Sub DesHabilitarBotones()

    '    btnAnadir.Enabled = False
    '    btnModificar.Enabled = False
    '    btnEliminar.Enabled = False
    '    btnSalir.Enabled = False
    '    btnAceptar.Enabled = True
    '    btnCancelar.Enabled = True

    '    dgvx.Enabled = False

    '    'Dim PaginaSeleccionadaAntes As Integer
    '    'PaginaSeleccionadaAntes = XtraTabControl1.SelectedTabPageIndex
    '    'If EstoyEnAlta Then
    '    '    PaginaSeleccionadaAntes = 0
    '    'End If

    '    'For Each Page As DevExpress.XtraTab.XtraTabPage In XtraTabControl1.TabPages
    '    '    Page.PageEnabled = False
    '    'Next

    '    'XtraTabControl1.TabPages(0).PageEnabled = True
    '    'If EstoyEnAlta = False Then
    '    '    XtraTabControl1.TabPages(1).PageEnabled = True
    '    'End If

    '    'XtraTabControl1.SelectedTabPageIndex = PaginaSeleccionadaAntes
    'End Sub

#End Region


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click, btnSalir2.Click
        Salir()
    End Sub
    Private Sub Salir()

        Me.ParentForm.Dispose()
        MostrarImagenDeFondo()
        LiberarMemoria()


    End Sub

    Private Sub Gv_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles Gv.FocusedRowChanged

        Try

            HacerCambioFila()
            'If TabInmuebles.SelectedTabPage Is TabPropietarios Then UcInmueblesPropietario1.CambioPropietario()
        Catch ex As Exception

        End Try

    End Sub
    'Private Sub Gv_RowLoaded(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowEventArgs) Handles Gv.RowLoaded
    '    Try

    '        HacerCambioFila()
    '        'If TabInmuebles.SelectedTabPage Is TabPropietarios Then UcInmueblesPropietario1.CambioPropietario()
    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Private Sub Gv_FocusedRowLoaded(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowEventArgs) Handles Gv.FocusedRowLoaded
    '    Try

    '        HacerCambioFila()
    '        'If TabInmuebles.SelectedTabPage Is TabPropietarios Then UcInmueblesPropietario1.CambioPropietario()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub Gv_TopRowChanged(sender As Object, e As System.EventArgs) Handles Gv.TopRowChanged
    '    Try

    '        HacerCambioFila()
    '        'If TabInmuebles.SelectedTabPage Is TabPropietarios Then UcInmueblesPropietario1.CambioPropietario()
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Private Sub CargarSlider(ByVal slid As ImageSlider, ByVal ContadorPropietario As Integer, ByVal Referencia As String, Optional ByVal Pequenas As Boolean = True, Optional ByVal una As Boolean = True)

        '  Dim mySlider As ImageSlider = New ImageSlider()
        'mySlider.Parent = Me
        'mySlider.Size = New Size(240, 200)
        'Populate ImageSlider with images


        'JCB CARPETA FOTOS
        Dim Carpeta As String

        Carpeta = GL_CarpetaFotos & "\" & Referencia

        'If slid.Name = SliderPequeno.Name Then
        '    Carpeta = Carpeta & "\actualizaweb"
        'End If

        If Not System.IO.Directory.Exists(Carpeta) Then Exit Sub

        Dim Fotos() As String = System.IO.Directory.GetFiles(Carpeta)
        Dim cuenta As Integer = Fotos.Count - 1
        Try

            If BinSrc.Current("FotoPrincipal") <> "" Then
                For i = 0 To cuenta

                    If My.Computer.FileSystem.GetName(Fotos(i)) = BinSrc.Current("FotoPrincipal") Then
                        slid.Images.Add(Funciones.redimensionaimagen(Image.FromStream(New IO.MemoryStream(IO.File.ReadAllBytes(Fotos(i)))), slid.Width, slid.Height, False))
                        Exit For
                    End If

                Next
            Else

                Dim FotoDirectorioWeb As String = Carpeta & "\actualizaweb" & "\" & Referencia & "_1.jpg"
                If System.IO.File.Exists(FotoDirectorioWeb) Then

                    slid.Images.Add(Image.FromStream(New IO.MemoryStream(IO.File.ReadAllBytes(FotoDirectorioWeb))))


                End If


            End If

            If Not una Then
                For i = 0 To cuenta
                    If Not My.Computer.FileSystem.GetName(Fotos(i)) = BinSrc.Current("FotoPrincipal") Then 'AndAlso Not una Then
                        slid.Images.Add(Funciones.redimensionaimagen(Image.FromStream(New IO.MemoryStream(IO.File.ReadAllBytes(Fotos(i)))), slid.Width, slid.Height, False))
                    End If
                Next
            End If

        Catch ex As Exception


        End Try

        'slid.Images.Add(Image.FromFile("c:\Images\im1.jpg"))
        'slid.Images.Add(Image.FromFile("c:\Images\im2.jpg"))
        'slid.Images.Add(Image.FromFile("c:\Images\im3.jpg"))
        'slid.Images.Add(Image.FromFile("c:\Images\im4.jpg"))
        'Increase image sliding animation duration (default is 700 ms)
        slid.AnimationTime = 1200
        slid.AllowLooping = True
        slid.Refresh()
        'Display images at the center of ImageSlider in their original size
        slid.LayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.ZoomInside
    End Sub

    Private Sub HacerCambioFila()

        If CargandoInmuebles Then
            Exit Sub
        End If
        'habilitabotones(False)
        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            TabInmuebles.Enabled = False
            '    Exit Sub
        Else
            TabInmuebles.Enabled = True
        End If

        FocusedColorInmuebles(Gv)
        PintarPaneles()
        '   habilitabotones(True)
        'txtObservaciones.Text = BD_CERO.Execute("SELECT Observaciones FROM Inmuebles WHERE Contador= " & BinSrc.Current("Contador"))
        'LlenarObservaciones(txtObservaciones, BinSrc.Current("Contador"), TablaInmuebles)  'Fijarse

        'If BinSrc.Current("ElectroDomesticosAlquiler") Is DBNull.Value Then
        '    chkElectrodomesticos.ForeColor = Color.Blue
        'End If

        If BinSrc.Current("Inmuebles") Is DBNull.Value Then
            TabInmuebles.TabPages(1).Text = "Propietario"
        Else
            TabInmuebles.TabPages(1).Text = "Propietario - " & BinSrc.Current("Inmuebles") & " Inmuebles"
        End If

        'For i = 0 To ImageSlider1.Images.Count - 1
        '    ImageSlider1.Images.RemoveAt(0)
        'Next

        SliderPequeno.Images.Clear()

        If BinSrc.Current("Inmuebles") IsNot DBNull.Value And BinSrc.Current("Inmuebles") IsNot DBNull.Value Then
            CargarSlider(SliderPequeno, BinSrc.Current("ContadorPropietario"), BinSrc.Current("Referencia"))
        End If

        txtAnosConstruccion.Text = DateDiff(DateInterval.Year, "#1/1/" & BinSrc.Current("AnoConstruccion") & "#", Today())

        Select Case spnAltura.Tag
            Case "-2"
                spnAltura.EditValue = "PB"

            Case "-1"
                spnAltura.EditValue = "ENT"

            Case Else
                spnAltura.EditValue = spnAltura.Tag
        End Select

        Select Case spnAltura2.Tag
            Case "-2"
                spnAltura2.EditValue = "PB"

            Case "-1"
                spnAltura2.EditValue = "ENT"

            Case Else
                spnAltura2.EditValue = spnAltura2.Tag
        End Select

        'Select Case txtMPlaya.EditValue
        '    Case -9999999
        '        spnMetrosPlaya.EditValue = 0
        '        chkMetrosPlaya.CheckState = CheckState.Unchecked
        '    Case Is < 0
        '        spnMetrosPlaya.EditValue = txtMPlaya.EditValue * -1
        '        chkMetrosPlaya.CheckState = CheckState.Unchecked
        '    Case Else
        '        spnMetrosPlaya.EditValue = txtMPlaya.EditValue
        '        chkMetrosPlaya.CheckState = CheckState.Checked
        'End Select


        Select Case txtMPlaya.EditValue
            '  Case -9999999
            '  spnMetrosPlaya.EditValue = 0
            '  chkMetrosPlaya.CheckState = CheckState.Unchecked
            Case Is < 0
                spnMetrosPlaya.EditValue = 0
                '  chkMetrosPlaya.CheckState = CheckState.Unchecked
            Case Else
                spnMetrosPlaya.EditValue = txtMPlaya.EditValue
                ' chkMetrosPlaya.CheckState = CheckState.Checked
        End Select


        'spnAltura2.EditValue = spnAltura.EditValue

        If BinSrc.Current("FotosWeb") > 0 Then
            btnFotos.Text = "Fot. " & BinSrc.Current("FotosPc") & "/" & BinSrc.Current("FotosWeb")
            btnFotos.ForeColor = Color.Red
        Else
            btnFotos.ForeColor = SystemColors.HotTrack
            btnFotos.Text = "Fotos: " & BinSrc.Current("FotosPc")
        End If



        ActivaUcs()

        If TabInmuebles.SelectedTabPage Is TabPropietarios Then
            'UcInmueblesPropietario1.LlenarGridInmuebles()
            UcInmueblesPropietario1.CambioPropietario()
        End If



        If PanelGestionDocumental.Visibility = DockVisibility.Visible Then
            uGestionDocumental.Titulo("Gestión documental del inmueble " & BinSrc.Current("Referencia"))
            uGestionDocumental.RefrescarBotones(Gv.GetFocusedRowCellValue(CampoGestionDocumental), TablaGestionDocumental)
        End If

        Try
            If Not IsNothing(BinSrc.Current("Baja")) Then
                CambiarBtnDarDeBaja(BinSrc.Current("Baja"))
            End If
        Catch ex As Exception

        End Try

        If BinSrc.Current("MostrarPPrincipalWeb") Then
            MenuGrid.PopMenuMostrarPPrincipalWeb.Text = "Quitar de la Pantalla Principal de la Web"
        Else
            MenuGrid.PopMenuMostrarPPrincipalWeb.Text = "Mostrar en la Pantalla Principal de la Web"
        End If

        If BinSrc.Current("Reservado") Then
            txtExtras.Width = txtObservaciones.Width - txtObservacionesReserva.Width - 10
            txtObservacionesReserva.Visible = True
            Dim Sel As String
            Sel = "SELECT Observacion FROM ReservasRegistro WHERE ContadorInmueble = " & BinSrc.Current("Contador")
            txtObservacionesReserva.Text = BD_CERO.Execute(Sel, False, "")
            lblReservas.Visible = True
            lblExtras.Text = "Extras"
        Else
            txtExtras.Width = txtObservaciones.Width
            txtObservacionesReserva.Visible = False
            txtObservacionesReserva.Text = ""
            lblReservas.Visible = False
            lblExtras.Text = "Extras (Visible en la descripción del inmueble)"
        End If

        lblDocs.Visible = False
        'pintar lo que sea
        If System.IO.Directory.Exists(clVariables.RutaServidor & "\Documentacion\Inmuebles\" & BinSrc.Current("Contador")) Then
            Dim Fichs As String() = System.IO.Directory.GetFiles(clVariables.RutaServidor & "\Documentacion\Inmuebles\" & BinSrc.Current("Contador"))
            If Fichs.Length > 0 Then
                lblDocs.Text = Fichs.Length & " Docs"
                lblDocs.Visible = True
            End If
        End If

    End Sub
    Private Sub LlenarCombosAuxiliaresSoloConSusDatos(ByVal cmb As CheckedComboBoxEdit, ByVal Tabla As String, ByVal Campo As String, Optional ByVal Filtro As String = "")

        Dim bdPobs As New BaseDatos()
        Dim Tab As New Tablas.clTablaGeneral(Tabla, , "SELECT " & Campo & " FROM " & Tabla & " WHERE CodigoCliente = '" & Gv.GetFocusedRowCellValue("Codigo") & "'", )
        bdPobs = New BaseDatos
        Tab.Datos(bdPobs, Tab.ConsultaAEjecutar, , , , , True)

        cmb.Properties.DataSource = Nothing
        cmb.Properties.DataSource = bdPobs.ds.Tables(Tab.Tabla)

        cmb.Properties.DisplayMember = Campo


        For Each c As CheckedListBoxItem In cmb.Properties.Items
            c.Enabled = False
            c.Value = True
        Next

    End Sub
    Private Sub LlenarCombosAuxiliaresCompletos(ByVal cmb As CheckedComboBoxEdit, ByVal Tabla As String, ByVal Campo As String, Optional ByVal Filtro As String = "")

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


    Private Sub txtBusquedaEmailTelefono_Properties_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtBusquedaEmailTelefono.ButtonClick
        If e.Button.Index = 0 Then
            BusquedaPorTelefonoEmail()
        End If

    End Sub
    Private Sub txtBusquedaEmailTelefono_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBusquedaEmailTelefono.KeyDown
        If e.KeyCode = Keys.Enter Then
            BusquedaPorTelefonoEmail()
        End If
    End Sub
    Private Sub BusquedaPorTelefonoEmail()

        If FiltroBusqueda <> "" Then

            BuscandoPorTelefonoEmail = False
            FiltroBusqueda = ""

            LlenarGrid()
            txtBusquedaEmailTelefono.Text = ""
            txtBusquedaEmailTelefono.ForeColor = ColorInicialBotonBuscar
            BuscandoPorTelefonoEmail = False

            PulsadoVerBajas = True
            VerBajas()

            HabilitarDesHabilitarAnadirModificarBorrar(True)
            'btnDarDeBaja.Enabled = True
            MenuGrid.PopMenuDarDeBajaInmueble.Visible = True

            Return
        End If

        If FiltroBusqueda = txtBusquedaEmailTelefono.Text Then
            Return
        End If

        If txtBusquedaEmailTelefono.Text <> "" Then
            FiltroBusqueda = txtBusquedaEmailTelefono.Text
            LlenarGrid()
            txtBusquedaEmailTelefono.ForeColor = Color.Red
            BuscandoPorTelefonoEmail = True

            HabilitarDesHabilitarAnadirModificarBorrar(False)
            'btnDarDeBaja.Enabled = True
            MenuGrid.PopMenuDarDeBajaInmueble.Visible = True
        Else

            BuscandoPorTelefonoEmail = False
            FiltroBusqueda = ""

            LlenarGrid()
            txtBusquedaEmailTelefono.Text = ""
            txtBusquedaEmailTelefono.ForeColor = ColorInicialBotonBuscar
            BuscandoPorTelefonoEmail = False

            BuscandoPorTelefonoEmail = False
            VerBajas()

            HabilitarDesHabilitarAnadirModificarBorrar(True)
            'btnDarDeBaja.Enabled = True
            MenuGrid.PopMenuDarDeBajaInmueble.Visible = True


            '      View.EditingValue = Gl_ResultadoBusqueda
        End If



        'If FiltroBusqueda <> "" Then
        '    FiltroBusqueda = ""
        '    LlenarGrid()
        '    txtBusquedaEmailTelefono.Text = ""
        '    txtBusquedaEmailTelefono.ForeColor = ColorInicialBotonBuscar
        '    Return
        'End If

        'If FiltroBusqueda = txtBusquedaEmailTelefono.Text Then
        '    Return
        'End If

        'If txtBusquedaEmailTelefono.Text <> "" Then
        '    FiltroBusqueda = txtBusquedaEmailTelefono.Text
        '    LlenarGrid()
        '    txtBusquedaEmailTelefono.ForeColor = Color.Red
        'Else

        '    FiltroBusqueda = ""
        '    LlenarGrid()
        '    txtBusquedaEmailTelefono.Text = ""
        '    txtBusquedaEmailTelefono.ForeColor = ColorInicialBotonBuscar
        '    '      View.EditingValue = Gl_ResultadoBusqueda
        'End If



        'PonerColoresInmuebles(Gv)

        HacerCambioFila()


    End Sub

    'Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If FiltroBusqueda <> "" Then
    '        Gl_ResultadoBusqueda = ""
    '        FiltroBusqueda = ""
    '        LlenarGrid()
    '        btnReservar.Text = TextoInicialBotonBuscar
    '        btnReservar.ForeColor = ColorInicialBotonBuscar
    '        Return
    '    End If



    '    Gl_ResultadoBusqueda = ""

    '    Try
    '        Dim f As New frmBuscar(EnumResultadoBusqueda.VENDEDOR)
    '        f.ShowDialog()
    '    Catch ex As Exception

    '    End Try

    '    If FiltroBusqueda = Gl_ResultadoBusqueda Then
    '        Return
    '    End If

    '    If Gl_ResultadoBusqueda <> "" Then
    '        FiltroBusqueda = Gl_ResultadoBusqueda
    '        LlenarGrid()
    '        btnReservar.Text = "FILTRADO"
    '        btnReservar.ForeColor = Color.Red
    '    Else
    '        Gl_ResultadoBusqueda = ""
    '        FiltroBusqueda = ""
    '        LlenarGrid()
    '        btnReservar.Text = TextoInicialBotonBuscar
    '        btnReservar.ForeColor = ColorInicialBotonBuscar
    '        '      View.EditingValue = Gl_ResultadoBusqueda
    '    End If




    'End Sub

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

            uGestionDocumental.Titulo("Gestión documental del inmueble " & BinSrc.Current("Referencia"))
            uGestionDocumental.RefrescarBotones(Gv.GetFocusedRowCellValue(CampoGestionDocumental).ToString, TablaGestionDocumental)
        End If
    End Sub
    Private Sub UcInmueblesPropietario1_dgvxDatosPropietariosDoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcInmueblesPropietario1.dgvxDatosPropietariosDoubleClick

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

        If UcInmueblesPropietario1.Gv.FocusedRowHandle < 0 Then
            Return
        End If

        EstoyEnDobleClickDeInmueblesPropietario = True

        Dim op As DevExpress.Data.Filtering.CriteriaOperator = Gv.ActiveFilterCriteria 'filterControl1.FilterCriteria
        FiltroAntesBusquedaPropietario = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op)
        PosicionAntesBusquedaPropietario = BinSrc.Position
        FiltroAntesBusquedaPropietario = Gv.ActiveFilterString

        If IsNothing(BinSrc.Filter) OrElse BinSrc.Filter = "" Then
            BinsrcAntesBusquedaPropietario = ""
        Else
            BinsrcAntesBusquedaPropietario = BinSrc.Filter
        End If



        CargandoInmuebles = True

        Gv.ActiveFilterString = ""

        CargandoInmuebles = False

        Dim Filtro As String = "Referencia = '" & UcInmueblesPropietario1.Gv.GetFocusedRowCellValue("Referencia").ToString & "'"
        BinSrc.Filter = Filtro

        TabInmuebles.SelectedTabPageIndex = 0

        'If IsNothing(BinSrc.Filter) OrElse BinSrc.Filter = "" Then
        '    BinSrc.Filter = "Referencia = " & UcInmueblesPropietario1.Gv.GetFocusedRowCellValue("Referencia")
        'Else
        '    BinSrc.Filter = "Referencia = " & UcInmueblesPropietario1.Gv.GetFocusedRowCellValue("Referencia") & " AND " & BinSrc.Filter
        'End If

        'txtCodigo.EditValue = UcInmueblesPropietario1.Gv.GetFocusedRowCellValue("Referencia")


    End Sub



    Private Sub TabInmuebles_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles TabInmuebles.SelectedPageChanged

        'If TabInmuebles.SelectedTabPageIndex =1 THEN
        '    UcInmueblesPropietario1.CambioPropietario()
        'End If


        If TabInmuebles.SelectedTabPageIndex = 1 Then
            If Not IsNothing(BinSrc.Filter) AndAlso Microsoft.VisualBasic.Left(BinSrc.Filter.ToString, 12) = "Referencia =" And EstoyEnDobleClickDeInmueblesPropietario Then

                EstoyEnDobleClickDeInmueblesPropietario = False

                '  UcInmueblesPropietario1.CambioPropietario()
                Dim ContadorActual As Integer = 0
                Try
                    ContadorActual = uInmueblesActivo.BinSrc.Current("Contador")
                Catch ex As Exception

                End Try

                'Dim PosicionAND As Integer = InStr(BinSrc.Filter.ToString, " AND ")
                'If PosicionAND > 0 Then
                '    Dim PosicionFinal = PosicionAND + 4
                '    BinSrc.Filter = Microsoft.VisualBasic.Right(BinSrc.Filter.ToString, Len(BinSrc.Filter.ToString) - PosicionFinal)
                'Else
                '    BinSrc.Filter = Nothing
                'End If


                CargandoInmuebles = True
                Gv.ActiveFilterString = FiltroAntesBusquedaPropietario
                CargandoInmuebles = False
                FiltroAntesBusquedaPropietario = ""

                If BinsrcAntesBusquedaPropietario = "" Then
                    BinSrc.Filter = Nothing
                Else
                    BinSrc.Filter = BinsrcAntesBusquedaPropietario
                End If

                BinSrc.Position = PosicionAntesBusquedaPropietario
                UcInmueblesPropietario1.CambioPropietario()
                If ContadorActual <> 0 Then
                    SituarseEnGrid(UcInmueblesPropietario1.Gv, ContadorActual, "Contador")
                End If

                Gv.Focus()
            Else
                UcInmueblesPropietario1.CambioPropietario()
            End If

        End If

        'If TabInmuebles.SelectedTabPageIndex = 1 Then
        '    btnVisitas.Visible = False
        '    btnDirecciones.Visible = False
        '    btnReservar.Visible = False
        'Else
        '    btnVisitas.Visible = True
        '    btnDirecciones.Visible = True
        '    btnReservar.Visible = True
        'End If


    End Sub

    Private Sub SliderPequeno_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles SliderPequeno.DoubleClick
        If BinSrc.Current("Inmuebles") IsNot DBNull.Value And BinSrc.Current("Inmuebles") IsNot DBNull.Value Then
            SliderGrande.Images.Clear()
            '  pnlDatosGenerales.Visible = False
            SliderGrande.Parent = uInmueblesActivo
            SliderGrande.Height = uInmueblesActivo.Height
            SliderGrande.Width = uInmueblesActivo.Height
            SliderGrande.Top = uInmueblesActivo.Top
            SliderGrande.Left = ((uInmueblesActivo.Left + uInmueblesActivo.Right) / 2) - (SliderGrande.Width / 2)

            CargarSlider(SliderGrande, BinSrc.Current("ContadorPropietario"), BinSrc.Current("Referencia"), , False)

            If SliderGrande.Images.Count < 1 Then Exit Sub

            SliderGrande.Visible = True
            SliderGrande.BringToFront()
            'SliderGrande.Focus()
        End If
    End Sub

    Private Sub SliderGrande_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles SliderGrande.DoubleClick
        SliderGrande.Visible = False
    End Sub


    Private Sub btnClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClientes.Click
        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Return
        End If

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        CargarFormulario("Clientes", "", True, GL_VENGO_DE_INMUEBLES, BinSrc.Current("Contador").ToString & "|" & BinSrc.Current("Referencia").ToString)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow

        Exit Sub


    End Sub
    Private Sub VerBajas()
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor



        If Not BinSrc.Current("Baja") Then

            PanelControl3.BackColor = GL_ColorAruraRosaBaja
            PanelBotones.BackColor = GL_ColorAruraRosaBaja
            PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            PanelBotones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder

            PulsadoVerBajas = True
            CambiarBtnDarDeBaja(True)

            'btnDarDeBaja.ForeColor = Color.Red
            'btnDarDeBaja.Text = "Recuperar"
            'btnDarDeBaja.Image = My.Resources.DarDeAlta


            btnVerBajas.ForeColor = Color.Red
            btnVerBajas.Text = "Ver Altas"
            btnVerBajas.Image = My.Resources.InmueblesAlta

            HabilitarDesHabilitarAnadirModificarBorrar(False)
        Else

            PanelControl3.BackColor = GL_ColorOriginal
            PanelBotones.BackColor = GL_ColorOriginal
            PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
            PanelBotones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat




            PulsadoVerBajas = False
            CambiarBtnDarDeBaja(False)

            'btnDarDeBaja.ForeColor = ColorInicialBotonBajas
            'btnDarDeBaja.Text = "Dar de Baja"
            'btnDarDeBaja.Image = My.Resources.DarDeBaja

            btnVerBajas.ForeColor = ColorInicialBotonBajas
            btnVerBajas.Text = "Ver Bajas"
            btnVerBajas.Image = My.Resources.InmueblesBaja

            HabilitarDesHabilitarAnadirModificarBorrar(True)
        End If

        LlenarGrid()


        If Not PulsadoVerBajas Then HabilitarDesHabilitarAnadirModificarBorrar(True)

        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub

    Private Sub CambiarBtnDarDeBaja(ByVal SoyBaja As Boolean)


        If SoyBaja Then
            'btnDarDeBaja.ForeColor = Color.Red
            'btnDarDeBaja.Text = "Recuperar"
            'btnDarDeBaja.Image = My.Resources.DarDeAlta
            MenuGrid.PopMenuDarDeBajaInmueble.Text = "Recuperar Inmueble"
            HabilitarDesHabilitarAnadirModificarBorrar(False)
        Else
            'btnDarDeBaja.ForeColor = ColorInicialBotonBajas
            'btnDarDeBaja.Text = "Dar de Baja"
            'btnDarDeBaja.Image = My.Resources.DarDeBaja
            If Not NuevoInmueble Then
                MenuGrid.PopMenuDarDeBajaInmueble.Text = "Dar de Baja Inmueble"
                HabilitarDesHabilitarAnadirModificarBorrar(True)
            End If
        End If


    End Sub

    Private Sub btnVerBajas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerBajas.Click

        VerBajas()

    End Sub

    Private Sub btnDarDeBaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        ActualizarBajaAlta()
        Me.Cursor = System.Windows.Forms.Cursors.Arrow

    End Sub

    Function ActualizarBajaAlta() As Boolean

        Try

            If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
                Return False
            End If

            Dim Texto As String


            If Not BinSrc.Current("Baja") Then
                Texto = "¿Confirma que quiere dar de baja el registro seleccionado?"
            Else
                Texto = "¿Confirma que quiere recuperar el registro seleccionado?"
            End If

            If XtraMessageBox.Show(Texto, "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
                Return False
            End If

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            Dim FilaSeleccionada As Integer = Gv.FocusedRowHandle


            '     CarpetaDocumentoPublicadas = CarpetaDocumento & "\actualizarweb"

            Dim MensajeAdicional As String = ""

            Dim Referencia As String = BinSrc.Current("Referencia")

            If Not BinSrc.Current("Baja") Then


                'If BinSrc.Current("PortalFotoCasa") Then

                'End If
                If BD_CERO.Execute("SELECT PortalFotoCasa FROM Inmuebles WHERE Contador = " & BinSrc.Current("Contador"), False) Then

                    If XtraMessageBox.Show("El inmueble está dado de alta en FotoCasa. Si continúa se despublicará." & vbCrLf & "¿Confirma que quiere continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
                        Exit Function
                    End If

                    Dim CodigoAPI As String
                    Dim Sel As String

                    Sel = "SELECT Codigo FROM ClientePortales WHERE Portal = 'FotoCasa' and CodigoEmpresa = " & DatosEmpresa.Codigo
                    CodigoAPI = BD_CERO.Execute(Sel, False, "")

                    If CodigoAPI = "" Then
                        MensajeError("No puede DesPublicar en FotoCasa porque no tiene código API de acceso")
                    End If

                    Gv.ClearColumnsFilter()


                    dgvx.ColumnaCheck.ClearSelection()
                    dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, True)
                    Dim Res As clResultado = DespublicarFotocasa(dgvx.ColumnaCheck.GetSelectedRow(0)("Referencia"), CodigoAPI, "BAJA")

                    If Res.Code = "" Then
                        MensajeAdicional = "Estaba en FC. Despublicación OK"
                    Else
                        MensajeAdicional = "Estaba en FC. Despublicación KO"
                    End If

                End If


                InsertaEnTramites(Referencia, "BAJA INMUEBLE", MensajeAdicional)

                BD_CERO.Execute("UPDATE Inmuebles SET Baja = " & GL_SQL_VALOR_1 & ",FechaReservado = NULL, Reservado = 0, FotosWeb = 0 WHERE Contador=" & BinSrc.Current("Contador"))
                BD_CERO.Execute("DELETE FROM ReservasRegistro WHERE ContadorInmueble=" & BinSrc.Current("Contador"))


                FuncionesBD.Accion("DELETE", "Inmuebles", txtReferencia.EditValue)



                'FuncionesBD.sp_PasarInmuebleA(True, BinSrc.Current("Contador"))
                '    FuncionesGenerales.Funciones.CambiaValorCampoRowActual(bd.ds, TablaMantenimiento, "Baja", 1, , BinSrc.Current("Contador"))

                Dim cartel As String = ""
                If BinSrc.Current("Cartel") Then cartel = "Hay cartel."
                Dim llaves As String = ""
                If BinSrc.Current("Llaves") Then llaves = "Tenemos llaves."
                If cartel <> "" Or llaves <> "" Then XtraMessageBox.Show(llaves & vbCrLf & cartel, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

                PonerPendienteRefrescarPropietarios()
                PonerPendienteRefrescarAlarmas()

            Else
                BD_CERO.Execute("UPDATE Inmuebles SET Baja=0 WHERE Contador=" & BinSrc.Current("Contador"))
                FuncionesBD.Accion("UPDATE", "Inmuebles", txtReferencia.EditValue)

                InsertaEnTramites(Referencia, "ALTA INMUEBLE", MensajeAdicional)


                'FuncionesBD.sp_PasarInmuebleA(False, BinSrc.Current("Contador"))
                '   FuncionesGenerales.Funciones.CambiaValorCampoRowActual(bd.ds, TablaMantenimiento, "Baja", 0, , BinSrc.Current("Contador"))

            End If

            'JCB CARPETA FOTOS
            Dim CarpetaDocumentoAlta As String = GL_CarpetaFotos & "\" & BinSrc.Current("Referencia")
            Dim CarpetaDocumentoBaja As String = GL_CarpetaFotosBaja & "\" & BinSrc.Current("Referencia")

            Dim CarpetaDocumentoOrigen As String
            Dim CarpetaDocumentoDestino As String

            If Not BinSrc.Current("Baja") Then
                CarpetaDocumentoOrigen = CarpetaDocumentoAlta
                CarpetaDocumentoDestino = CarpetaDocumentoBaja
            Else
                CarpetaDocumentoOrigen = CarpetaDocumentoBaja
                CarpetaDocumentoDestino = CarpetaDocumentoAlta
            End If

            Dim DirFiles() As String = Nothing

            If System.IO.Directory.Exists(CarpetaDocumentoOrigen) Then
                DirFiles = System.IO.Directory.GetFiles(CarpetaDocumentoOrigen, "*.*")

                Try
                    If DirFiles.Length > 0 Then
                        If System.IO.Directory.Exists(CarpetaDocumentoDestino) Then
                            Directory.Delete(CarpetaDocumentoDestino, True)
                        End If
                        FuncionesGenerales.Funciones.ComprobarYCrearCarpetas(CarpetaDocumentoDestino)
                        For i = 0 To DirFiles.Length - 1
                            Dim NombreFichero As String = My.Computer.FileSystem.GetName(DirFiles(i))
                            Dim RutaFicheroDestino = CarpetaDocumentoDestino & "\" & NombreFichero
                            System.IO.File.Copy(DirFiles(i), RutaFicheroDestino)
                        Next

                        Try
                            For i = 0 To DirFiles.Length - 1
                                System.IO.File.Delete(DirFiles(i))
                            Next

                        Catch ex As Exception

                        End Try

                        If Not BinSrc.Current("Baja") Then
                            Dim CarpetaDocumentoPublicadas As String = CarpetaDocumentoOrigen & "\actualizarweb"
                            'quitar imagenes de la web
                            If DatosEmpresa.WordPress Then
                                'WPEliminarFotosInmueble(BinSrc.Current("Contador"))
                            Else

                                Dim ftp As New tb_FTP
                                'Dim Http = "httpdocs/roberto" 'carpeta de la web
                                Dim Http As String = GL_ConfiguracionWeb.DirectorioFotos & "\" & BinSrc.Current("Referencia")
                                ftp.FTPBorrarFicherosCarpeta(Http, "jpg")
                                'quitar imagenes de la carpeta publicados
                            End If

                            Try
                                If System.IO.Directory.Exists(CarpetaDocumentoPublicadas) Then
                                    System.IO.Directory.Delete(CarpetaDocumentoPublicadas, True)
                                End If
                            Catch
                                MensajeError("Error al borrar fotos publicadas")
                            End Try
                        End If

                        System.IO.Directory.Delete(CarpetaDocumentoOrigen, True)

                    Else
                        Exit Function
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Exit Function
                End Try
            End If
            FiltroBusqueda = ""
            txtBusquedaEmailTelefono.Text = ""
            '
            '  bd.RefrescarDatos(, , Gv, BinSrc)

            Try
                If Gv.FocusedRowHandle > 1 Then
                    Gv.FocusedRowHandle = Gv.FocusedRowHandle - 1
                Else
                    Gv.FocusedRowHandle = Gv.FocusedRowHandle + 1
                End If
            Catch ex As Exception

            End Try



            LlenarGrid(, True)
            Me.Cursor = System.Windows.Forms.Cursors.Arrow


            mostrarAlertaPortales()
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
    Private Sub cmbPerfiles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPerfiles.SelectedIndexChanged




        Dim selectedIndex As Integer = cmbPerfiles.SelectedIndex
        If selectedIndex <> -1 Then
            MenuGrid.AplicarPerfil(cmbPerfiles.EditValue, dgvx)
        End If
        AP.ActualizaPerfil(Gv, MenuGrid.mnuPerfilActual.Text.Substring(15)) 'se coge a partir del 15 pq los primeros son "Perfil Actual:"
        If AnadirCheckColunm Then 'añadimos le checkcolumn tras actualizar el perfil
            Try
                dgvx.tb_AnadirColumnaCheck = True
            Catch ex As Exception
            End Try
        End If





    End Sub
    Private Sub cmbFiltros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFiltros.SelectedIndexChanged

        'Static Vuelta As Integer

        'If IsNothing(Vuelta) OrElse Vuelta = 0 Then
        '    Vuelta =1
        Dim selectedIndex As Integer = cmbFiltros.SelectedIndex
        If selectedIndex <> -1 Then
            MenuGrid.AplicarFiltro(cmbFiltros.EditValue, dgvx)
            'If selectedIndex = 0 Then
            '    Gv.ActiveFilterCriteria = Nothing
            'Else
            '    MenuGrid.AplicarFiltro(cmbFiltros.EditValue, dgvx)
            'End If
        End If
        'Else
        'Vuelta = 0
        'End If

        'cmbFiltros.Text = ""
    End Sub

    Private Sub btnAnadirObservaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnadirObservaciones.Click



        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Return
        End If



        Dim Observaciones As New Tablas.clComunicaciones

        Observaciones.Tipo = GL_OBSERVACIONES_MANUAL
        Observaciones.Tabla = TablaInmuebles  'Fijarse
        Observaciones.ContadorClientePropietarioInmueble = BinSrc.Current("Contador")
        Observaciones.CodigoEmpresa = DatosEmpresa.Codigo
        Observaciones.ContadorEmpleado = GL_CodigoUsuario
        Observaciones.Delegacion = Gl_Delegacion
        Observaciones.Observaciones = GL_Observaciones
        Observaciones.ContadorInmueble = BinSrc.Current("Contador")

        If ProcesoAnadirObservaciones2(Observaciones) = -1 Then Return
        txtObservaciones.Text = Now & " " & GL_Observaciones & vbCrLf & txtObservaciones.Text
        If txtObservaciones.Text.Length > 5000 Then
            txtObservaciones.Text = txtObservaciones.Text.Substring(0, 5000)
        End If
        BD_CERO.Execute("UPDATE Inmuebles SET Observaciones= '" & Funciones.pf_ReplaceComillas(txtObservaciones.Text) & "' WHERE Contador= " & BinSrc.Current("Contador"))
        'LlenarObservaciones(txtObservaciones, BinSrc.Current("Contador"), TablaInmuebles)  'Fijarse
        bd.RefrescarDatos()
    End Sub



    Private Sub btnFotos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFotos.Click
        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Return
        End If
        'Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        'CargarFormulario("Imagenes", Otros:=BinSrc.Current("ContadorPropietario") & "|" & BinSrc.Current("Referencia") & "|" & BinSrc.Current("Contador"))
        'Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Dim p As New XtraForm1("Imagenes de: " & BinSrc.Current("Referencia"))
        p.Name = "Imagenes"
        p.ControlBox = False
        Dim Baja As Boolean
        If Not PulsadoVerBajas Then
            Baja = False
        Else
            Baja = True
        End If

        Dim ID_WP_Pasado As Integer = 0
        If DatosEmpresa.WordPress Then

            If BinSrc.Current("Id_WP") <> 0 Then
                ID_WP_Pasado = BinSrc.Current("Id_WP")
            Else
                Dim Sel As String
                Sel = "SELECT Id_WP FROM Inmuebles WHERE Contador = " & BinSrc.Current("Contador")
                ID_WP_Pasado = BD_CERO.Execute(Sel, False, 0)
            End If

            'If ID_WP_Pasado = 0 Then
            '    MensajeInformacion("No puede asociar imágenes porque el inmueble todavía no se ha dado de alta")
            '    Return
            'End If

        End If



        Dim u As New ucImagenes(BinSrc.Current("ContadorPropietario"), BinSrc.Current("Referencia"), BinSrc.Current("Contador"), Baja, ID_WP_Pasado)
        u.Dock = DockStyle.Fill
        p.Controls.Add(u)
        p.Size = Me.Size
        p.StartPosition = FormStartPosition.CenterScreen
        p.ShowDialog()

        RefrescarDatosDesdeBdInmuebles(True)
        'CambiaValorCampoRowActual("FotosPc", GL_FotosPc)
        'CambiaValorCampoRowActual("FotosWeb", GL_FotosWeb)
        'CambiaValorCampoRowActual("FotoPrincipal", GL_FotoPrincipal)
        'recargar inmueblespropietarios
        HacerCambioFila()

    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click



        If dgvx.ColumnaCheck.SelectedCount = 0 And (Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle) Then
            MensajeError("No ha seleccionado ningún inmueble")
            Exit Sub
        End If

        Dim SeleccionManual As Boolean = False





        frmListados.Location = New Point(MousePosition.X - 40, MousePosition.Y - 340)
        frmListados.ShowDialog()
        If GL_Listado = "SALIR" Then Return



        frmWordReport.Location = New Point(MousePosition.X - 45, MousePosition.Y - 75)
        frmWordReport.ShowDialog()

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Select Case GL_Listado
            Case "CLIENTES"
                'ListadoClientes()
                ListadoRevista(False, Me.ContadorClienteDeDondeVengo)
            Case "REVISTA"
                ListadoRevista(True)
            Case "DIRECCIONES"
                ListadoDirecciones()
            Case "FICHA"
                If dgvx.ColumnaCheck.SelectedCount = 0 Then
                    dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, True)
                    SeleccionManual = True
                End If
                ListadoFicha()
        End Select

        If SeleccionManual Then
            dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, False)
            SeleccionManual = False
        Else
            dgvx.ColumnaCheck.ClearSelection()
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Arrow


    End Sub
    Private Sub ListadoRevista(Optional ByVal ocultar As Boolean = False, Optional ByVal ContadorCliente As Integer = 0)
        Dim listaInmuebles As String = ""
        Dim row As DataRowView
        Dim HaSeleccionado As Boolean = False



        If dgvx.ColumnaCheck.SelectedCount = 0 Then
            For i = 0 To Gv.RowCount - 1
                If i = 0 Then
                    listaInmuebles = Gv.GetDataRow(i)("Contador").ToString()
                Else
                    listaInmuebles &= ", " & Gv.GetDataRow(i)("Contador").ToString()
                End If
            Next
        Else
            For I = 0 To dgvx.ColumnaCheck.SelectedCount - 1
                If dgvx.ColumnaCheck.SelectedCount >= 1 Then
                    HaSeleccionado = True
                    row = dgvx.ColumnaCheck.GetSelectedRow(I)
                    If I = 0 Then
                        listaInmuebles = row.Item("Contador")
                    Else
                        listaInmuebles &= ", " & row.Item("Contador")
                    End If
                End If
            Next
        End If

        If listaInmuebles <> "" Then
            listaInmuebles = "  WHERE Contador IN (" & listaInmuebles & ")"
        End If

        If ocultar Then
            If listaInmuebles = "" Then
                listaInmuebles = " WHERE ocultar=0"
            Else
                listaInmuebles &= " AND ocultar=0"
            End If
        End If


        If Not HaSeleccionado Then

            Dim TextoReserva As String
            TextoReserva = " Reservado =0"

            If listaInmuebles = "" Then
                listaInmuebles = " WHERE "
            Else
                listaInmuebles = listaInmuebles & " AND "
            End If
            listaInmuebles = listaInmuebles & TextoReserva
        End If


        Dim DT As DataTable

        Dim Sel As String = "SELECT Referencia,Poblacion, Oportunidad,ContadorPropietario, FotoPrincipal, Contador  FROM Inmuebles " & listaInmuebles & " ORDER BY Poblacion, Precio "
        DT = ObtenerDTListadoInmuebles(Sel)


        Dim bdRevista As New BaseDatos
        bdRevista.LlenarDataSet(Sel, "Datos")


        If DT.Rows.Count = 0 Then
            MensajeInformacion("Los inmuebles seleccionados están ocultos" & vbCrLf & "Seleccione otros inmuebles para el listado revista")
            Exit Sub
        End If
        'System.IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\Listados\Esquemas\")
        ' DT.WriteXmlSchema(My.Application.Info.DirectoryPath & "\Listados\Esquemas\Datos.xsd")
        ' DT.WriteXml(My.Application.Info.DirectoryPath & "\Listados\Esquemas\Datos.xml", XmlWriteMode.WriteSchema)

        '   Dim Oferta As String = BD_CERO.Execute("SELECT TipoVenta FROM Clientes WHERE Contador = " & ContadorCliente, False)

        Dim r As New rptListadoInmuebles
        r.lblTitulo.Text = ConsultasBaseDatos.ObtenerAsuntoYCuerpoEmail(GL_EMAIL_LISTADO_CLIENTES, DatosEmpresa.Codigo).Titulo
        '   r.Oferta = Oferta
        Funciones.ShowListado(r, GL_Word, DT)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow


        If dgvx.ColumnaCheck.SelectedCount <> 0 Then
            dgvx.ColumnaCheck.ClearSelection()
        End If

        'Dim inicio As DateTime = DateTime.Now

        'report.ExportToPdf(NombreFichero)

        'Dim fin As DateTime = DateTime.Now

        'Dim totalMin As String
        'Dim total As TimeSpan = New TimeSpan(fin.Ticks - inicio.Ticks)
        'totalMin = total.Hours.ToString("00") & ":" & total.Minutes.ToString("00") & ":" & total.Seconds.ToString("00")


    End Sub

    Private Sub ListadoDirecciones(Optional ByVal ocultar As Boolean = False)
        Dim listaInmuebles As String = ""
        Dim row As DataRowView
        For I = 0 To dgvx.ColumnaCheck.SelectedCount - 1
            If dgvx.ColumnaCheck.SelectedCount >= 1 Then
                row = dgvx.ColumnaCheck.GetSelectedRow(I)
                If I = 0 Then
                    listaInmuebles = " where Referencia in ('" & row.Item("Referencia") & "'" '(Referencia='" & row.Item("Referencia") & "'"
                Else
                    listaInmuebles &= ",'" & row.Item("Referencia") & "'" '" or Referencia='" & row.Item("Referencia") & "'"
                End If
            End If
        Next
        If dgvx.ColumnaCheck.SelectedCount = 0 Then
            For i = 0 To Gv.RowCount - 1
                If i = 0 Then
                    listaInmuebles = " where Referencia in ('" & Gv.GetDataRow(i)("Referencia").ToString() & "'" ' (Referencia='" & Gv.GetDataRow(i)("Referencia").ToString() & "'"
                Else
                    listaInmuebles &= ",'" & Gv.GetDataRow(i)("Referencia").ToString() & "'" '" or Referencia='" & Gv.GetDataRow(i)("Referencia").ToString() & "'"
                End If
            Next
        End If
        If Not listaInmuebles = "" Then listaInmuebles &= ")"

        If ocultar Then
            If listaInmuebles = "" Then
                listaInmuebles = " WHERE ocultar=0"
            Else
                listaInmuebles &= " AND ocultar=0"
            End If
        End If

        Dim DT As New DataTable

        'Dim Sel As String = "SELECT I.* FROM Inmuebles I" & listaInmuebles & " ORDER BY I.Poblacion, I.PrecioVenta, I.PrecioAlquiler"
        Dim Sel As String = "SELECT " & Funciones.SQL_CASE({"Via <> ''", "Via = ''"}, {"Via " & GL_SQL_SUMA & "' '" & GL_SQL_SUMA & " Direccion", "Direccion"}) & " AS Direccion,Numero,Altura,Puerta,Poblacion,Referencia,Oportunidad FROM " & TablaInmuebles & " I" & listaInmuebles & " ORDER BY I.Poblacion, I.Precio "
        Dim bdRevista As New BaseDatos
        bdRevista.LlenarDataSet(Sel, "Datos")
        DT = bdRevista.ds.Tables("Datos")
        'System.IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\Listados\Esquemas\")
        'DT.WriteXmlSchema(My.Application.Info.DirectoryPath & "\Listados\Esquemas\Datos.xsd")
        'DT.WriteXml(My.Application.Info.DirectoryPath & "\Listados\Esquemas\Datos.xml", XmlWriteMode.WriteSchema)
        Dim r As New rptListadoDireccionesInmuebles
        'r.lblTitulo.Text = ConsultasBaseDatos.ObtenerAsuntoYCuerpoEmail(GL_EMAIL_LISTADO_CLIENTES, DatosEmpresa.Codigo).Titulo
        r.lblTitulo.Text = "Listado de Direcciones"
        Funciones.ShowListado(r, GL_Word, DT)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub
    Private Sub ListadoFicha()

        Dim listaInmuebles As String = ""
        Dim row As DataRowView
        For I = 0 To dgvx.ColumnaCheck.SelectedCount - 1
            If dgvx.ColumnaCheck.SelectedCount >= 1 Then
                row = dgvx.ColumnaCheck.GetSelectedRow(I)
                If I = 0 Then
                    listaInmuebles = " where I.Contador in(" & row.Item("Contador") '(I.Contador=" & row.Item("Contador")
                Else
                    listaInmuebles &= "," & row.Item("Contador") '" or I.Contador=" & row.Item("Contador")
                End If
            End If
        Next
        If dgvx.ColumnaCheck.SelectedCount = 0 Then
            For i = 0 To Gv.RowCount - 1
                If i = 0 Then
                    listaInmuebles = " where I.Contador in (" & Gv.GetDataRow(i)("Contador").ToString() '(I.Contador=" & Gv.GetDataRow(i)("Contador").ToString()
                Else
                    listaInmuebles &= "," & Gv.GetDataRow(i)("Contador").ToString() '" or I.Contador=" & Gv.GetDataRow(i)("Contador").ToString()
                End If
            Next
        End If
        If Not listaInmuebles = "" Then listaInmuebles &= ")"

        Dim DT As DataTable = ObtenerDT_ParaReportFichaPropietario(TablaInmuebles, listaInmuebles)

        For Each dr As DataRow In DT.Rows
            '            BD_CERO.Execute("INSERT INTO Impresiones (ContadorEmpleado, Documento, ContadorInmueble) VALUES (" & GL_CodigoUsuario & ", 'FICHA INMUEBLE'," & dr("I.Contador") & ")")
            BD_CERO.Execute("INSERT INTO Impresiones (ContadorEmpleado, Documento, ContadorInmueble) VALUES (" & GL_CodigoUsuario & ", 'FICHA INMUEBLE'," & dr("Contador") & ")")
            'BD_CERO.Execute("UPDATE " & TablaInmuebles & " SET EnviadaFicha =" & GL_SQL_VALOR_1 & " WHERE Contador = " & dr("Contador"))
        Next

        'Dim Sel As String = "SELECT I.*,P.* FROM " & TablaInmuebles & " I INNER JOIN Propietarios P ON P.Contador=I.ContadorPropietario" & listaInmuebles & _
        '                    " ORDER BY I.Referencia DESC"

        'Dim bd As New BaseDatos

        'bd.LlenarDataSet(Sel, "Datos")
        'DT = bd.ds.Tables("Datos")

        'System.IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\Listados\Esquemas\")
        'DT.WriteXmlSchema(My.Application.Info.DirectoryPath & "\Listados\Esquemas\Ficha.xsd")

        'Dim r As New rptListadoFichaInmueble
        Dim r As New rptFichaPropietario
        Funciones.ShowListado(r, GL_Word, DT)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub





    Private Sub btnEmails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmails.Click
        EnviosDeEmailMasivo()
    End Sub
    Private Sub EnviosDeEmailMasivo()

        If dgvx.ColumnaCheck.SelectedCount = 0 AndAlso (Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle) Then
            MensajeError("No ha seleccionado ningún inmueble al que enviar email")
            Exit Sub
        End If

        If dgvx.ColumnaCheck.SelectedCount > 0 AndAlso Not IsNothing(UcInmueblesPropietario1.dgvxDatosPropietarios.ColumnaCheck) AndAlso UcInmueblesPropietario1.dgvxDatosPropietarios.ColumnaCheck.SelectedCount > 0 Then
            If XtraMessageBox.Show("Ha marcado para enviar inmuebles principales y al mismo tiempo inmuebles de un determinado propietario." & vbCrLf & "Si continua, se enviarán los princpales" & vbCrLf & "¿Quiere continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
                Return
            End If
        End If


        Dim dgvxSeleccionado As MyGridControl
        Dim GvSeleccionado As MyGridView

        ' Dim TrabajoConLosInmueblesDelUcPropietarios As Boolean

        If TabInmuebles.SelectedTabPage Is TabPropietarios And dgvx.ColumnaCheck.SelectedCount = 0 Then
            dgvxSeleccionado = UcInmueblesPropietario1.dgvxDatosPropietarios
            GvSeleccionado = UcInmueblesPropietario1.Gv
            '  TrabajoConLosInmueblesDelUcPropietarios = True
        Else
            dgvxSeleccionado = dgvx
            GvSeleccionado = Gv
            '  TrabajoConLosInmueblesDelUcPropietarios = False
            If Not IsNothing(UcInmueblesPropietario1.dgvxDatosPropietarios.ColumnaCheck) Then
                UcInmueblesPropietario1.dgvxDatosPropietarios.ColumnaCheck.ClearSelection()
            End If

        End If



        If dgvxSeleccionado.ColumnaCheck.SelectedCount = 0 And (GvSeleccionado.RowCount = 0 OrElse GvSeleccionado.FocusedRowHandle = GridControl.AutoFilterRowHandle) Then
            MensajeError("No ha seleccionado ningún inmueble al que enviar email")
            Exit Sub
        End If

        Dim SeleccionManual As Boolean = False

        If dgvxSeleccionado.ColumnaCheck.SelectedCount = 0 Then
            dgvxSeleccionado.ColumnaCheck.SelectRow(GvSeleccionado.FocusedRowHandle, True)
            SeleccionManual = True
        End If

        'Aqui mostramos un form en el q definimos el mensaje,titulo y asunto, elegimos el predeterminado o guardamos alguno nuevo o cargamos
        'asi como si se incluyen los datos de empresa los de los inmuebles o incluso si se agrega algun documento adjunto
        CargarFormulario("MensajeEmail")
        '  frmMensajeEmail.ShowDialog()
        Dim a() As String = Split(GL_DatosMensajePersonalizado, "|")
        If a(8) = True Then
            If SeleccionManual Then
                dgvxSeleccionado.ColumnaCheck.SelectRow(GvSeleccionado.FocusedRowHandle, False)
                SeleccionManual = False
            Else
                dgvxSeleccionado.ColumnaCheck.ClearSelection()
            End If
            Return
        End If
        Dim IncluirFichaInmueble As Boolean = a(7)
        Dim AnadirAvisoLegal As Boolean = a(6)
        Dim AnadirDatosEmpresa As Boolean = a(5)
        Dim AnadirDatosInmueble As Boolean = a(4)
        Dim FicheroAdjunto As String = a(3)
        Dim AsuntoMensaje As String = a(1)
        Dim TituloMensaje As String = a(0)
        Dim MensajeMensaje As String = a(2)
        Dim IncluirTextoFaltanFotos As String = a(9)
        Dim IncluirTextoDireccionInmueble As String = a(10)
        Dim TipoEmail As String = a(11)

        Try 'situamos cartel de envio
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            pnlEnviado.Left = (pnlDatosGenerales.Width - pnlEnviado.Width) / 2
            pnlEnviado.Top = (pnlDatosGenerales.Height - pnlEnviado.Height) / 2
            pnlEnviado.Visible = True
            pnlEnviado.Enabled = True
            PanelBotones.Enabled = False
            lblxdey.Text = "1 de " & dgvxSeleccionado.ColumnaCheck.SelectedCount
            '   Application.DoEvents()
        Catch ex As Exception
        End Try

        Dim ContadorInmuebleIncial As Integer = 0

        Dim ContadorPropietario As Integer
        Dim Nombre As String = ""
        Dim Email As String = ""
        Dim Cadena As String = ""
        Dim CuantosConMail As Integer = 0
        Dim CuantosSinMail As Integer = 0
        Dim CuantosNoQuieren As Integer = 0
        Dim PropietariosSinMail As New Generic.List(Of String)
        Dim PropietariosNoQuierenEmails As New Generic.List(Of String)
        Dim LlamadaContestada As Integer = 0
        Dim CuantosErrores As Integer = 0
        Dim ErrorEnvio As New Generic.List(Of String)


        Dim AdjuntosAEviar As String = FicheroAdjunto

        'recorremos todos los inmuebles sobre los que enviaremos email a los propietarios y los introducimos dentro de una tabla con los datos de sus propietarios

        Dim inmuebles As String = ""
        For i As Integer = 0 To dgvxSeleccionado.ColumnaCheck.SelectedCount - 1
            If i = 0 Then
                ContadorInmuebleIncial = (TryCast(dgvxSeleccionado.ColumnaCheck.GetSelectedRow(i), DataRowView))("Contador")
            End If
            inmuebles &= Str((TryCast(dgvxSeleccionado.ColumnaCheck.GetSelectedRow(i), DataRowView))("Contador")) & ","
        Next
        inmuebles = inmuebles.Substring(0, inmuebles.Count - 1)

        Dim CampoContador As String
        'If dgvxSeleccionado Is dgvx Then
        CampoContador = "i.Contador"
        'Else
        '    CampoContador = "p.Contador"
        'End If

        'SentenciaSQL = "SELECT i.Contador as ContadorInmueble,i.Referencia,p.Nombre,p.Email,p.NoQuiereRecibirEmails, p.Contador as ContadorPropietario FROM Inmuebles i INNER JOIN Propietarios p ON i.ContadorPropietario = p.Contador WHERE i.Contador IN(" & inmuebles & ") ORDER  BY P.Contador"
        SentenciaSQL = "SELECT i.Contador as ContadorInmueble,i.Referencia,p.Nombre,p.Email " & GL_SQL_SUMA & " " &
            Funciones.SQL_CASE({"p.Email2 = ''", "p.Email2 " & GL_SQL_DIS & " ''"}, {"''", "';'" & GL_SQL_SUMA & " P.Email2"}) & " AS Email,p.NoQuiereRecibirEmails, p.Contador as ContadorPropietario " &
            " FROM Inmuebles i INNER JOIN Propietarios p ON i.ContadorPropietario = p.Contador WHERE " & CampoContador & " IN(" & inmuebles & ") ORDER  BY P.Contador"



        Dim bdemail As New BaseDatos
        bdemail.LlenarDataSet(SentenciaSQL, "Email")

        Dim DTEmail As New DataTable
        DTEmail = bdemail.ds.Tables("Email")
        'recorremos la tabla propietario a propietario y enviamos los email correspondientes borrando lo que vamos mandando(no repetir propietario)

        ContadorPropietario = 0
        For i As Integer = 0 To DTEmail.Rows.Count - 1
            With DTEmail.Rows(i)
                lblxdey.Text = (CuantosConMail + CuantosSinMail + CuantosNoQuieren + 1) & " de " & DTEmail.Rows.Count
                Application.DoEvents() '???

                Email = .Item("Email")
                Nombre = .Item("Nombre")



                If .Item("NoQuiereRecibirEmails") Then
                    CuantosNoQuieren += 1
                    PropietariosNoQuierenEmails.Add(Nombre)
                Else
                    If (Email = "" Or Not FuncionesGenerales.Funciones.validar_Mail(Email)) Then
                        CuantosSinMail += 1
                        PropietariosSinMail.Add(Nombre)
                    Else

                        ' If ContadorPropietario <> .Item("ContadorPropietario") Then
                        Try
                            ContadorPropietario = .Item("ContadorPropietario")
                            AdjuntosAEviar = ""
                            Dim ResultadoEnvio As String = ""
                            'obtenemos la informacion a enviar
                            Dim AsuntoYMensaje As New Tablas.cl_AsuntoYMensaje
                            AsuntoYMensaje.Asunto = AsuntoMensaje
                            AsuntoYMensaje.Titulo = TituloMensaje
                            AsuntoYMensaje.Mensaje = MensajeMensaje & " <br><br>"
                            '      Dim ListaContadores As New List(Of Integer)

                            '    For ii As Integer = i To DTEmail.Rows.Count - 1
                            '   If DTEmail.Rows(ii).Item("ContadorPropietario") = ContadorPropietario Then
                            CuantosConMail += 1 'cada propietario duplicado se cuenta como un nuevo mail enviado

                            Dim ContaInmu As Integer
                            'If Not TrabajoConLosInmueblesDelUcPropietarios Then
                            '    ContaInmu = .Item("ContadorInmueble")
                            '    AsuntoYMensaje.Mensaje &= ConsultasBaseDatos.ObtenerMensajePropietario(DatosEmpresa.Codigo, ContaInmu, .Item("Referencia")) & vbCrLf & vbCrLf
                            'Else
                            ContaInmu = DTEmail.Rows(i).Item("ContadorInmueble")
                            '    ListaContadores.Add(ContaInmu)

                            '    If AnadirDatosInmueble Then
                            AsuntoYMensaje.Mensaje &= ConsultasBaseDatos.ObtenerMensajePropietario(DatosEmpresa.Codigo, ContaInmu, DTEmail.Rows(i).Item("Referencia"), AnadirDatosEmpresa, AnadirAvisoLegal, IncluirTextoFaltanFotos, IncluirTextoDireccionInmueble, AnadirDatosInmueble) & vbCrLf & vbCrLf
                            ' End If
                            If IncluirFichaInmueble Then
                                Dim listaInmuebles As String = " where (I.Contador=" & ContaInmu & ")"
                                If AdjuntosAEviar = "" Then
                                    AdjuntosAEviar = PrepararFicheroFichaInmueble(ContaInmu, TablaInmuebles, listaInmuebles)
                                Else
                                    AdjuntosAEviar = AdjuntosAEviar & ";" & PrepararFicheroFichaInmueble(ContaInmu, TablaInmuebles, listaInmuebles)
                                End If
                            End If
                            ' End If
                            ' Next
                            If AsuntoYMensaje Is Nothing Then
                                MensajeInformacion("No se encontró información de asunto y mensaje para el envío de emails")
                                Exit Sub
                            End If
                            'If AnadirDatosEmpresa Then
                            '    AsuntoYMensaje.Mensaje &= ConsultasBaseDatos.ObtenerMensajePropietario(DatosEmpresa.Codigo, 0, "", AnadirDatosEmpresa, AnadirAvisoLegal)
                            'End If
                            'enviamos el email al propietario


                            ResultadoEnvio = EnviosEmailIndividual(Email, Nombre, AsuntoYMensaje, AdjuntosAEviar, True)


                            'Se llena la tabla con los datos dle envio a los propietarios correspondientes
                            If ResultadoEnvio = "" Then
                                BD_CERO.Execute("UPDATE Propietarios SET FechaEmail= " & GL_SQL_GETDATE & ", TipoEmail = '" & Funciones.pf_ReplaceComillas(TipoEmail) & "' WHERE Contador=" & ContadorPropietario)
                                '   For k = 0 To ListaContadores.Count - 1
                                '    Dim ContaInmu As Integer
                                '    ContaInmu = ListaContadores(k)

                                Dim Sel As String
                                Sel = "INSERT INTO PropietariosComunicaciones (CodigoEmpresa ,Delegacion, ContadorInmueble, ContadorPropietario,Fecha,ContadorEmpleado,LlamadaContestada,Observaciones,Tipo) VALUES (" &
                                DatosEmpresa.Codigo & "," & Gl_Delegacion & ",0," & ContadorPropietario & "," & GL_SQL_GETDATE & "," & GL_CodigoUsuario & "," & ContaInmu & ", '" & Funciones.pf_ReplaceComillas(TipoEmail) & "', 'EMAIL'" &
                                ")"
                                BD_CERO.Execute(Sel)

                                If IncluirFichaInmueble Then
                                    BD_CERO.Execute("UPDATE " & TablaInmuebles & " SET EnviadaFicha =" & GL_SQL_VALOR_1 & " WHERE Contador = " & ContaInmu)
                                End If

                                '  Next


                            Else
                                CuantosErrores += 1
                                ErrorEnvio.Add(Nombre)
                            End If

                        Catch ex As Exception
                            'MensajeError(ex.Message)
                            CuantosErrores += 1
                            ErrorEnvio.Add(Nombre)
                        End Try
                        '  End If
                    End If
                    'If Not TrabajoConLosInmueblesDelUcPropietarios Then
                    '    '   .Item("Nombre") = ""
                    'Else
                    '    Exit For
                    'End If

                End If
            End With
        Next





        ' HacerCambioFila() '???


        '************Esto para refrescar datos va ok. lo comento pq ahora lo que necesito es forzar cambio de fila'?????
        'Try
        '    dgvx.ColumnaCheck.View = Nothing
        'Catch ex As Exception

        'End Try

        'Dim TopIndexAntes As Integer
        'TopIndexAntes = Gv.TopRowIndex
        'bd.RefrescarDatos(TablaMantenimiento, bd.ds)
        'Gv.TopRowIndex = TopIndexAntes
        'SituarseEnGrid(Gv, ContadorInmuebleIncial, "Contador")

        'Try
        '    If dgvx.tb_AnadirColumnaCheck Then
        '        dgvx.AnadirColumnaCheck()
        '    End If

        'Catch ex As Exception

        'End Try
        '************Esto para refrescar datos va ok

        Try 'Escondemos panel envio

            pnlEnviado.Visible = False
            PanelBotones.Enabled = True
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Catch ex As Exception

        End Try

        If CuantosSinMail > 0 Then 'Mostramos mensaje con los errores
            Dim CadenaMensaje As String = ""

            CadenaMensaje = "Hay " & CuantosSinMail & " propietarios de los inmuebles seleccionados que no se ha podido enviar el email porque no tiene dirección de email o el email no es correcto."
            If XtraMessageBox.Show(CadenaMensaje & vbCrLf & "¿Desea verlos?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then 'ROBERTO 26/05/2017
                For Each s In PropietariosSinMail
                    CadenaMensaje = CadenaMensaje & vbCrLf & s.ToString
                Next
                FuncionesGenerales.Funciones.TextoANotePad(CadenaMensaje) 'ROBERTO 26/05/2017
            End If
            'MensajeError(CadenaMensaje)
        End If
        If CuantosNoQuieren > 0 Then 'Mostramos mensaje con los que no quieren
            Dim CadenaMensaje As String = ""

            CadenaMensaje = "Hay " & CuantosNoQuieren & " propietarios de los inmuebles seleccionados que no recibirán emails porque no quieren."

            For Each s In PropietariosNoQuierenEmails
                CadenaMensaje = CadenaMensaje & vbCrLf & s.ToString
            Next
            MensajeError(CadenaMensaje)
        End If
        If CuantosErrores > 0 Then 'Mostramos mensaje con los errores de envio
            Dim CadenaMensaje As String = ""

            CadenaMensaje = "Hay " & CuantosErrores & " propietarios de los inmuebles seleccionados que ha fallado el envio."

            For Each s In ErrorEnvio
                CadenaMensaje = CadenaMensaje & vbCrLf & s.ToString
            Next
            MensajeError(CadenaMensaje)
        End If
        bd.RefrescarDatos()
        PonerPendienteRefrescarPropietarios()
        PonerPendienteRefrescarAlarmas()
        HacerCambioFila()
        MensajeInformacion("El envío de emails finalizó correctamente.")

    End Sub
    'Private Sub EnviosDeEmailMasivo()

    '    If dgvx.ColumnaCheck.SelectedCount = 0 AndAlso (Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle) Then
    '        MensajeError("No ha seleccionado ningún inmueble al que enviar email")
    '        Exit Sub
    '    End If

    '    If dgvx.ColumnaCheck.SelectedCount > 0 AndAlso Not IsNothing(UcInmueblesPropietario1.dgvxDatosPropietarios.ColumnaCheck) AndAlso UcInmueblesPropietario1.dgvxDatosPropietarios.ColumnaCheck.SelectedCount > 0 Then
    '        If XtraMessageBox.Show("Ha marcado para enviar inmuebles principales y al mismo tiempo inmuebles de un determinado propietario." & vbCrLf & "Si continua, se enviarán los princpales" & vbCrLf & "¿Quiere continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
    '            Return
    '        End If
    '    End If


    '    Dim dgvxSeleccionado As MyGridControl
    '    Dim GvSeleccionado As MyGridView

    '    ' Dim TrabajoConLosInmueblesDelUcPropietarios As Boolean

    '    If TabInmuebles.SelectedTabPage Is TabPropietarios And dgvx.ColumnaCheck.SelectedCount = 0 Then
    '        dgvxSeleccionado = UcInmueblesPropietario1.dgvxDatosPropietarios
    '        GvSeleccionado = UcInmueblesPropietario1.Gv
    '        '  TrabajoConLosInmueblesDelUcPropietarios = True
    '    Else
    '        dgvxSeleccionado = dgvx
    '        GvSeleccionado = Gv
    '        '  TrabajoConLosInmueblesDelUcPropietarios = False
    '        If Not IsNothing(UcInmueblesPropietario1.dgvxDatosPropietarios.ColumnaCheck) Then
    '            UcInmueblesPropietario1.dgvxDatosPropietarios.ColumnaCheck.ClearSelection()
    '        End If

    '    End If



    '    If dgvxSeleccionado.ColumnaCheck.SelectedCount = 0 And (GvSeleccionado.RowCount = 0 OrElse GvSeleccionado.FocusedRowHandle = GridControl.AutoFilterRowHandle) Then
    '        MensajeError("No ha seleccionado ningún inmueble al que enviar email")
    '        Exit Sub
    '    End If

    '    Dim SeleccionManual As Boolean = False

    '    If dgvxSeleccionado.ColumnaCheck.SelectedCount = 0 Then
    '        dgvxSeleccionado.ColumnaCheck.SelectRow(GvSeleccionado.FocusedRowHandle, True)
    '        SeleccionManual = True
    '    End If

    '    'Aqui mostramos un form en el q definimos el mensaje,titulo y asunto, elegimos el predeterminado o guardamos alguno nuevo o cargamos
    '    'asi como si se incluyen los datos de empresa los de los inmuebles o incluso si se agrega algun documento adjunto
    '    CargarFormulario("MensajeEmail")
    '    '  frmMensajeEmail.ShowDialog()
    '    Dim a() As String = Split(GL_DatosMensajePersonalizado, "|")
    '    If a(8) = True Then
    '        If SeleccionManual Then
    '            dgvxSeleccionado.ColumnaCheck.SelectRow(GvSeleccionado.FocusedRowHandle, False)
    '            SeleccionManual = False
    '        Else
    '            dgvxSeleccionado.ColumnaCheck.ClearSelection()
    '        End If
    '        Return
    '    End If
    '    Dim IncluirFichaInmueble As Boolean = a(7)
    '    Dim AnadirAvisoLegal As Boolean = a(6)
    '    Dim AnadirDatosEmpresa As Boolean = a(5)
    '    Dim AnadirDatosInmueble As Boolean = a(4)
    '    Dim FicheroAdjunto As String = a(3)
    '    Dim AsuntoMensaje As String = a(1)
    '    Dim TituloMensaje As String = a(0)
    '    Dim MensajeMensaje As String = a(2)
    '    Dim IncluirTextoFaltanFotos As String = a(9)
    '    Dim IncluirTextoDireccionInmueble As String = a(10)

    '    Try 'situamos cartel de envio
    '        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
    '        pnlEnviado.Left = (pnlDatosGenerales.Width - pnlEnviado.Width) / 2
    '        pnlEnviado.Top = (pnlDatosGenerales.Height - pnlEnviado.Height) / 2
    '        pnlEnviado.Visible = True
    '        pnlEnviado.Enabled = True
    '        PanelBotones.Enabled = False
    '        lblxdey.Text = "1 de " & dgvxSeleccionado.ColumnaCheck.SelectedCount
    '        '   Application.DoEvents()
    '    Catch ex As Exception
    '    End Try

    '    Dim ContadorInmuebleIncial As Integer = 0

    '    Dim ContadorPropietario As Integer
    '    Dim Nombre As String = ""
    '    Dim Email As String = ""
    '    Dim Cadena As String = ""
    '    Dim CuantosConMail As Integer = 0
    '    Dim CuantosSinMail As Integer = 0
    '    Dim CuantosNoQuieren As Integer = 0
    '    Dim PropietariosSinMail As New Generic.List(Of String)
    '    Dim PropietariosNoQuierenEmails As New Generic.List(Of String)
    '    Dim LlamadaContestada As Integer = 0
    '    Dim CuantosErrores As Integer = 0
    '    Dim ErrorEnvio As New Generic.List(Of String)


    '    Dim AdjuntosAEviar As String = FicheroAdjunto

    '    'recorremos todos los inmuebles sobre los que enviaremos email a los propietarios y los introducimos dentro de una tabla con los datos de sus propietarios

    '    Dim inmuebles As String = ""
    '    For i As Integer = 0 To dgvxSeleccionado.ColumnaCheck.SelectedCount - 1
    '        If i = 0 Then
    '            ContadorInmuebleIncial = (TryCast(dgvxSeleccionado.ColumnaCheck.GetSelectedRow(i), DataRowView))("Contador")
    '        End If
    '        inmuebles &= Str((TryCast(dgvxSeleccionado.ColumnaCheck.GetSelectedRow(i), DataRowView))("Contador")) & ","
    '    Next
    '    inmuebles = inmuebles.Substring(0, inmuebles.Count - 1)

    '    'SentenciaSQL = "SELECT i.Contador as ContadorInmueble,i.Referencia,p.Nombre,p.Email,p.NoQuiereRecibirEmails, p.Contador as ContadorPropietario FROM Inmuebles i INNER JOIN Propietarios p ON i.ContadorPropietario = p.Contador WHERE i.Contador IN(" & inmuebles & ") ORDER  BY P.Contador"
    '    SentenciaSQL = "SELECT i.Contador as ContadorInmueble,i.Referencia,p.Nombre,p.Email + CASE WHEN p.Email2 = '' THEN '' ELSE ';' + P.Email2 END AS Email,p.NoQuiereRecibirEmails, p.Contador as ContadorPropietario FROM Inmuebles i INNER JOIN Propietarios p ON i.ContadorPropietario = p.Contador WHERE i.Contador IN(" & inmuebles & ") ORDER  BY P.Contador"



    '    Dim bdemail As New BaseDatos
    '    bdemail.LlenarDataSet(SentenciaSQL, "Email")

    '    Dim DTEmail As New DataTable
    '    DTEmail = bdemail.ds.Tables("Email")
    '    'recorremos la tabla propietario a propietario y enviamos los email correspondientes borrando lo que vamos mandando(no repetir propietario)

    '    ContadorPropietario = 0
    '    For i As Integer = 0 To DTEmail.Rows.Count - 1
    '        With DTEmail.Rows(i)
    '            lblxdey.Text = (CuantosConMail + CuantosSinMail + CuantosNoQuieren + 1) & " de " & DTEmail.Rows.Count
    '            Application.DoEvents() '???

    '            Email = .Item("Email")
    '            Nombre = .Item("Nombre")



    '            If .Item("NoQuiereRecibirEmails") Then
    '                CuantosNoQuieren += 1
    '                PropietariosNoQuierenEmails.Add(Nombre)
    '            Else
    '                If (Email = "" Or Not FuncionesGenerales.Funciones.validar_Mail(Email)) Then
    '                    CuantosSinMail += 1
    '                    PropietariosSinMail.Add(Nombre)
    '                Else

    '                    If ContadorPropietario <> .Item("ContadorPropietario") Then
    '                        Try
    '                            ContadorPropietario = .Item("ContadorPropietario")
    '                            AdjuntosAEviar = ""
    '                            Dim ResultadoEnvio As String = ""
    '                            'obtenemos la informacion a enviar
    '                            Dim AsuntoYMensaje As New Tablas.cl_AsuntoYMensaje
    '                            AsuntoYMensaje.Asunto = AsuntoMensaje
    '                            AsuntoYMensaje.Titulo = TituloMensaje
    '                            AsuntoYMensaje.Mensaje = MensajeMensaje & " <br><br>"
    '                            Dim ListaContadores As New List(Of Integer)

    '                            For ii As Integer = i To DTEmail.Rows.Count - 1
    '                                If DTEmail.Rows(ii).Item("ContadorPropietario") = ContadorPropietario Then
    '                                    CuantosConMail += 1 'cada propietario duplicado se cuenta como un nuevo mail enviado

    '                                    Dim ContaInmu As Integer
    '                                    'If Not TrabajoConLosInmueblesDelUcPropietarios Then
    '                                    '    ContaInmu = .Item("ContadorInmueble")
    '                                    '    AsuntoYMensaje.Mensaje &= ConsultasBaseDatos.ObtenerMensajePropietario(DatosEmpresa.Codigo, ContaInmu, .Item("Referencia")) & vbCrLf & vbCrLf
    '                                    'Else
    '                                    ContaInmu = DTEmail.Rows(ii).Item("ContadorInmueble")
    '                                    ListaContadores.Add(ContaInmu)

    '                                    If AnadirDatosInmueble Then
    '                                        AsuntoYMensaje.Mensaje &= ConsultasBaseDatos.ObtenerMensajePropietario(DatosEmpresa.Codigo, ContaInmu, DTEmail.Rows(ii).Item("Referencia"), AnadirDatosEmpresa, AnadirAvisoLegal, IncluirTextoFaltanFotos, IncluirTextoDireccionInmueble, AnadirDatosInmueble) & vbCrLf & vbCrLf
    '                                    End If
    '                                    If IncluirFichaInmueble Then
    '                                        Dim listaInmuebles As String = " where (I.Contador=" & ContaInmu & ")"
    '                                        If AdjuntosAEviar = "" Then
    '                                            AdjuntosAEviar = PrepararFicheroFichaInmueble(ContaInmu, TablaInmuebles, listaInmuebles)
    '                                        Else
    '                                            AdjuntosAEviar = AdjuntosAEviar & ";" & PrepararFicheroFichaInmueble(ContaInmu, TablaInmuebles, listaInmuebles)
    '                                        End If
    '                                    End If
    '                                End If
    '                            Next
    '                            If AsuntoYMensaje Is Nothing Then
    '                                MensajeInformacion("No se encontró información de asunto y mensaje para el envío de emails")
    '                                Exit Sub
    '                            End If
    '                            'If AnadirDatosEmpresa Then
    '                            '    AsuntoYMensaje.Mensaje &= ConsultasBaseDatos.ObtenerMensajePropietario(DatosEmpresa.Codigo, 0, "", AnadirDatosEmpresa, AnadirAvisoLegal)
    '                            'End If
    '                            'enviamos el email al propietario


    '                            ResultadoEnvio = EnviosEmailIndividual(Email, Nombre, AsuntoYMensaje, AdjuntosAEviar, True)


    '                            'Se llena la tabla con los datos dle envio a los propietarios correspondientes
    '                            If ResultadoEnvio = "" Then
    '                                BD_CERO.Execute("UPDATE Propietarios SET FechaEmail= " & GL_SQL_GETDATE & " WHERE Contador=" & ContadorPropietario)
    '                                For k = 0 To ListaContadores.Count - 1
    '                                    Dim ContaInmu As Integer
    '                                    ContaInmu = ListaContadores(k)
    '                                    BD_CERO.Execute("UPDATE " & TablaInmuebles & " SET EnviadaFicha =" & GL_SQL_VALOR_1 & " WHERE Contador = " & ContaInmu)
    '                                Next


    '                            Else
    '                                CuantosErrores += 1
    '                                ErrorEnvio.Add(Nombre)
    '                            End If

    '                        Catch ex As Exception
    '                            'MensajeError(ex.Message)
    '                            CuantosErrores += 1
    '                            ErrorEnvio.Add(Nombre)
    '                        End Try
    '                    End If
    '                End If
    '                'If Not TrabajoConLosInmueblesDelUcPropietarios Then
    '                '    '   .Item("Nombre") = ""
    '                'Else
    '                '    Exit For
    '                'End If

    '            End If
    '        End With
    '    Next





    '    ' HacerCambioFila() '???


    '    '************Esto para refrescar datos va ok. lo comento pq ahora lo que necesito es forzar cambio de fila'?????
    '    'Try
    '    '    dgvx.ColumnaCheck.View = Nothing
    '    'Catch ex As Exception

    '    'End Try

    '    'Dim TopIndexAntes As Integer
    '    'TopIndexAntes = Gv.TopRowIndex
    '    'bd.RefrescarDatos(TablaMantenimiento, bd.ds)
    '    'Gv.TopRowIndex = TopIndexAntes
    '    'SituarseEnGrid(Gv, ContadorInmuebleIncial, "Contador")

    '    'Try
    '    '    If dgvx.tb_AnadirColumnaCheck Then
    '    '        dgvx.AnadirColumnaCheck()
    '    '    End If

    '    'Catch ex As Exception

    '    'End Try
    '    '************Esto para refrescar datos va ok

    '    Try 'Escondemos panel envio

    '        pnlEnviado.Visible = False
    '        PanelBotones.Enabled = True
    '        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    '    Catch ex As Exception

    '    End Try

    '    If CuantosSinMail > 0 Then 'Mostramos mensaje con los errores
    '        Dim CadenaMensaje As String = ""

    '        CadenaMensaje = "Hay " & CuantosSinMail & " propietarios de los inmuebles seleccionados que no se ha podido enviar el email porque no tiene dirección de email o el email no es correcto."

    '        For Each s In PropietariosSinMail
    '            CadenaMensaje = CadenaMensaje & vbCrLf & s.ToString
    '        Next
    '        MensajeError(CadenaMensaje)
    '    End If
    '    If CuantosNoQuieren > 0 Then 'Mostramos mensaje con los que no quieren
    '        Dim CadenaMensaje As String = ""

    '        CadenaMensaje = "Hay " & CuantosNoQuieren & " propietarios de los inmuebles seleccionados que no recibirán emails porque no quieren."

    '        For Each s In PropietariosNoQuierenEmails
    '            CadenaMensaje = CadenaMensaje & vbCrLf & s.ToString
    '        Next
    '        MensajeError(CadenaMensaje)
    '    End If
    '    If CuantosErrores > 0 Then 'Mostramos mensaje con los errores de envio
    '        Dim CadenaMensaje As String = ""

    '        CadenaMensaje = "Hay " & CuantosErrores & " propietarios de los inmuebles seleccionados que ha fallado el envio."

    '        For Each s In ErrorEnvio
    '            CadenaMensaje = CadenaMensaje & vbCrLf & s.ToString
    '        Next
    '        MensajeError(CadenaMensaje)
    '    End If
    '    bd.RefrescarDatos()
    '    PonerPendienteRefrescarPropietarios()
    '    PonerPendienteRefrescarAlarmas()

    '    MensajeInformacion("El envío de emails finalizó correctamente.")

    'End Sub



    Private Sub btnReservar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReservar.Click
        Reserva()
    End Sub
    Public Sub Reserva(Optional ByVal Contador As Integer = 0)
        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then Return
        If dgvx.ColumnaCheck.SelectedCount > 1 Then Return
        Dim a As DataRowView = Gv.GetFocusedRow
        Dim VengoDeInmueblesPropietarios As Boolean = False
        If Contador = 0 Then
            Contador = a.Item("Contador")
        Else
            VengoDeInmueblesPropietarios = True
        End If

        If Not a.Item("Reservado") Then
            frmFichaReserva.chkReservado.Checked = True
        End If

        frmFichaReserva.ContadorInmueble = Contador
        frmFichaReserva.ShowDialog()

        'If VengoDeInmueblesPropietarios Then
        '    SituarseEnGrid(Gv, Contador, "Contador")
        'Else
        '    SituarseEnGrid(UcInmueblesPropietario1.Gv, Contador, "Contador", 0)
        'End If

        Dim Referencia As String

        Dim reservas() As String = Split(GL_InmuebleReservado, "|")
        If Not GL_InmuebleReservado = "NO" Then
            Dim cartel As String = ""
            If BinSrc.Current("Cartel") Then cartel = "Hay cartel."
            Dim llaves As String = ""
            If BinSrc.Current("Llaves") Then llaves = "Tenemos llaves."
            If cartel <> "" Or llaves <> "" Then XtraMessageBox.Show(llaves & vbCrLf & cartel, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Referencia = BinSrc.Current("Referencia")
            If BD_CERO.Execute("SELECT PortalFotoCasa FROM Inmuebles WHERE Contador = " & BinSrc.Current("Contador"), False) Then

                'If XtraMessageBox.Show("El inmueble está dado de alta en FotoCasa. Si continúa se despublicará." & vbCrLf & "¿Confirma que quiere continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
                '    Exit Sub
                'End If
                Dim CodigoAPI As String
                Dim Sel As String

                Sel = "SELECT Codigo FROM ClientePortales WHERE Portal = 'FotoCasa' and CodigoEmpresa = " & DatosEmpresa.Codigo
                CodigoAPI = BD_CERO.Execute(Sel, False, "")

                If CodigoAPI = "" Then
                    MensajeError("No puede DesPublicar en FotoCasa porque no tiene código API de acceso")
                End If

                Gv.ClearColumnsFilter()


                dgvx.ColumnaCheck.ClearSelection()
                dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, True)
                Dim Res As clResultado = DespublicarFotocasa(Referencia, CodigoAPI, "RESERVA")
                dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, False)



                MensajeInformacion("El inmueble se despublicó de Fotocasa")

                Dim MensajeAdicional As String
                If Res.Code = "" Then
                    MensajeAdicional = "Estaba en FC. Despublicación OK"
                Else
                    MensajeAdicional = "Estaba en FC. Despublicación KO"
                End If



                InsertaEnTramites(Referencia, "RESERVA INMUEBLE", MensajeAdicional)
            End If



            'End If
        End If



    End Sub

    Private Sub btnBuscarPropietarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPropietarios.Click

        Gl_ResultadoBusqueda = ""

        Try
            Dim f As New frmBuscar(EnumResultadoBusqueda.PROPIETARIO)
            f.ShowDialog()
        Catch ex As Exception

        End Try

        If Gl_ResultadoBusqueda <> "" Then
            txtContadorPropietario.EditValue = Gl_ResultadoBusqueda
            txtPropietario.Text = ConsultasBaseDatos.ObtenerNombrePropietario(CInt(txtContadorPropietario.Text))
        End If
    End Sub



    Private Sub gv_RowCellStyle(ByVal sender As Object, ByVal e As RowCellStyleEventArgs)
        Dim View As GridView = sender
        Select Case e.Column.FieldName
            Case "CambioPrecio"
                Select Case View.GetRowCellDisplayText(e.RowHandle, View.Columns("CambioPrecio"))
                    Case "▼"
                        e.Appearance.BackColor = Color.LightGreen
                        e.Appearance.BackColor2 = Color.GreenYellow
                        e.Appearance.GradientMode = Drawing2D.LinearGradientMode.BackwardDiagonal
                    Case "▲"
                        e.Appearance.BackColor = Color.Salmon
                        e.Appearance.BackColor2 = Color.SeaShell
                        e.Appearance.GradientMode = Drawing2D.LinearGradientMode.BackwardDiagonal
                End Select
                e.Appearance.GradientMode = Drawing2D.LinearGradientMode.BackwardDiagonal
            Case "CalificacionEnergetica"
                Select Case View.GetRowCellDisplayText(e.RowHandle, View.Columns("CalificacionEnergetica"))
                    Case "A" : e.Appearance.BackColor = Color.DarkGreen : e.Appearance.ForeColor = Color.White : e.Appearance.BackColor2 = Color.White : e.Appearance.GradientMode = Drawing2D.LinearGradientMode.BackwardDiagonal
                    Case "B" : e.Appearance.BackColor = Color.Green : e.Appearance.ForeColor = Color.White : e.Appearance.BackColor2 = Color.White : e.Appearance.GradientMode = Drawing2D.LinearGradientMode.BackwardDiagonal
                    Case "C" : e.Appearance.BackColor = Color.GreenYellow : e.Appearance.ForeColor = Color.Gray : e.Appearance.BackColor2 = Color.White : e.Appearance.GradientMode = Drawing2D.LinearGradientMode.BackwardDiagonal
                    Case "D" : e.Appearance.BackColor = Color.Yellow : e.Appearance.ForeColor = Color.LightGray : e.Appearance.BackColor2 = Color.White : e.Appearance.GradientMode = Drawing2D.LinearGradientMode.BackwardDiagonal
                    Case "E" : e.Appearance.BackColor = Color.Orange : e.Appearance.ForeColor = Color.White : e.Appearance.BackColor2 = Color.White : e.Appearance.GradientMode = Drawing2D.LinearGradientMode.BackwardDiagonal
                    Case "F" : e.Appearance.BackColor = Color.Red : e.Appearance.ForeColor = Color.White : e.Appearance.BackColor2 = Color.White : e.Appearance.GradientMode = Drawing2D.LinearGradientMode.BackwardDiagonal
                    Case "G" : e.Appearance.BackColor = Color.DarkRed : e.Appearance.ForeColor = Color.White : e.Appearance.BackColor2 = Color.White : e.Appearance.GradientMode = Drawing2D.LinearGradientMode.BackwardDiagonal
                        'Case Else : e.Appearance.BackColor = Color.White : e.Appearance.ForeColor = Color.Black
                End Select

            Case "Clasificacion"
                Select Case View.GetRowCellDisplayText(e.RowHandle, View.Columns("Clasificacion"))
                    '   Case 0 : e.Appearance.BackColor = Color.DarkGreen : e.Appearance.ForeColor = Color.White : e.Appearance.BackColor2 = Color.White : e.Appearance.GradientMode = Drawing2D.LinearGradientMode.BackwardDiagonal
                    Case 5 : e.Appearance.BackColor = Color.Green : e.Appearance.ForeColor = Color.White : e.Appearance.BackColor2 = Color.White : e.Appearance.GradientMode = Drawing2D.LinearGradientMode.BackwardDiagonal
                    Case 4 : e.Appearance.BackColor = Color.GreenYellow : e.Appearance.ForeColor = Color.Gray : e.Appearance.BackColor2 = Color.White : e.Appearance.GradientMode = Drawing2D.LinearGradientMode.BackwardDiagonal
                    Case 3 : e.Appearance.BackColor = Color.Yellow : e.Appearance.ForeColor = Color.LightGray : e.Appearance.BackColor2 = Color.White : e.Appearance.GradientMode = Drawing2D.LinearGradientMode.BackwardDiagonal
                    Case 2 : e.Appearance.BackColor = Color.Orange : e.Appearance.ForeColor = Color.White : e.Appearance.BackColor2 = Color.White : e.Appearance.GradientMode = Drawing2D.LinearGradientMode.BackwardDiagonal
                    Case 1 : e.Appearance.BackColor = Color.Red : e.Appearance.ForeColor = Color.White : e.Appearance.BackColor2 = Color.White : e.Appearance.GradientMode = Drawing2D.LinearGradientMode.BackwardDiagonal
                        '    Case "G" : e.Appearance.BackColor = Color.DarkRed : e.Appearance.ForeColor = Color.White : e.Appearance.BackColor2 = Color.White : e.Appearance.GradientMode = Drawing2D.LinearGradientMode.BackwardDiagonal
                        'Case Else : e.Appearance.BackColor = Color.White : e.Appearance.ForeColor = Color.Black
                End Select

            Case "Referencia"
                If Me.ContadorClienteDeDondeVengo <> 0 And GL_TieneAnimales Then
                    If View.GetRowCellDisplayText(e.RowHandle, View.Columns("NoAnimales")) = "Seleccionado" Then
                        e.Appearance.BackColor = Color.Red : e.Appearance.ForeColor = Color.White
                    Else

                    End If
                End If
                'Case "Garaje", "Trastero"
                '    Funciones.CHECKSCOLOR(sender, e) ', "'GARAJE','TRASTERO'")
            Case "MPlaya"
                If View.GetRowCellValue(e.RowHandle, View.Columns("MPlaya")) < 0 Then e.Appearance.ForeColor = Color.Red

            Case "DireccionCompleta" 'ROBERTO 26/05/2017
                If e.RowHandle > -1 AndAlso View.GetRowCellDisplayText(e.RowHandle, View.Columns("Direccion")) = View.GetRowCellDisplayText(e.RowHandle, View.Columns("DireccionMapa")) Then
                    e.Appearance.BackColor = Color.Red : e.Appearance.ForeColor = Color.White : e.Appearance.BackColor2 = Color.White : e.Appearance.GradientMode = Drawing2D.LinearGradientMode.BackwardDiagonal
                End If


        End Select

    End Sub

    Private Sub gv_CustomColumnDisplayText(ByVal sender As Object, ByVal e As CustomColumnDisplayTextEventArgs) Handles Gv.CustomColumnDisplayText
        Dim View As ColumnView = sender
        Select Case e.Column.FieldName
            Case "CambioPrecio"
                Dim Cambio As String = ""
                If Not IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("CambioPrecio"))) Then
                    Cambio = View.GetRowCellValue(e.RowHandle, View.Columns("CambioPrecio"))
                End If

                Select Case Cambio
                    Case "BAJA" : e.DisplayText = "▼"
                    Case "SUBE" : e.DisplayText = "▲"
                End Select
            Case "Precio"
                Dim Cambio As String = View.GetRowCellValue(e.RowHandle, View.Columns(e.Column.FieldName))
                If Cambio = "0" Then e.DisplayText = ""
            Case "Altura"
                Dim Cambio As String = View.GetRowCellValue(e.RowHandle, View.Columns("Altura"))
                Select Case Cambio
                    Case "-2" : e.DisplayText = "Planta Baja"
                    Case "-1" : e.DisplayText = "Entresuelo"
                End Select
                'Case "Garaje", "Trastero"
                '    Funciones.CHECKS(sender, e) ', "'GARAJE','TRASTERO'")
            Case "MPlaya"
                Dim Valor As Integer = View.GetRowCellValue(e.RowHandle, View.Columns("MPlaya"))
                Select Case Valor
                    Case -9999999
                        e.DisplayText = 0
                    Case Is < 0
                        e.DisplayText = Valor * -1
                End Select
        End Select

    End Sub

    Private Sub spnAltura_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles spnAltura.EditValueChanged
        If Not changing Then
            Dim b = TryCast(sender, tb_ButtonEdit)
            changing = True
            Select Case StrConv(b.EditValue, VbStrConv.Uppercase)
                Case "PB"
                    b.Tag = "-2"
                Case "ENT"
                    b.Tag = "-1"
                Case Else
                    If IsNumeric(b.EditValue) Then
                        b.Tag = b.EditValue
                    Else
                        b.Tag = 0
                        b.EditValue = 0
                    End If
            End Select
            spnAltura2.EditValue = b.EditValue
            spnAltura2.Tag = b.Tag
            changing = False
        End If
    End Sub
    Private Sub spnAltura2_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles spnAltura2.EditValueChanged
        If Not changing Then
            Dim b = TryCast(sender, TextEdit)
            changing = True
            Select Case StrConv(b.EditValue, VbStrConv.Uppercase)
                Case "PB"
                    b.Tag = "-2"
                Case "ENT"
                    b.Tag = "-1"
                Case Else
                    If IsNumeric(b.EditValue) Then
                        b.Tag = b.EditValue
                    Else
                        b.Tag = 0
                        b.EditValue = 0
                    End If
            End Select
            spnAltura.EditValue = b.EditValue
            spnAltura.Tag = b.Tag
            changing = False
        End If
    End Sub

    'Private Sub txtMPlaya_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMPlaya.EditValueChanged
    '    Select Case txtMPlaya.EditValue
    '        Case -9999999
    '            spnMetrosPlaya.EditValue = 0
    '            chkMetrosPlaya.CheckState = CheckState.Unchecked
    '        Case Is < 0
    '            spnMetrosPlaya.EditValue = txtMPlaya.EditValue * -1
    '            chkMetrosPlaya.CheckState = CheckState.Unchecked
    '        Case Else
    '            spnMetrosPlaya.EditValue = txtMPlaya.EditValue
    '            chkMetrosPlaya.CheckState = CheckState.Checked

    '    End Select
    'End Sub

    'Private Sub btnObtenerFotos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObtenerFotos.Click
    '    frmObtenerFotos.ShowDialog()
    '    Salir()
    'End Sub


    Private Sub cmbCalificacionEnergetica_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCalificacionEnergetica.SelectedIndexChanged
        Select Case cmbCalificacionEnergetica.SelectedItem.ToString
            Case "A" : cmbCalificacionEnergetica.BackColor = Color.DarkGreen : cmbCalificacionEnergetica.ForeColor = Color.White
            Case "B" : cmbCalificacionEnergetica.BackColor = Color.Green : cmbCalificacionEnergetica.ForeColor = Color.White
            Case "C" : cmbCalificacionEnergetica.BackColor = Color.GreenYellow : cmbCalificacionEnergetica.ForeColor = Color.Gray
            Case "D" : cmbCalificacionEnergetica.BackColor = Color.Yellow : cmbCalificacionEnergetica.ForeColor = Color.LightGray
            Case "E" : cmbCalificacionEnergetica.BackColor = Color.Orange : cmbCalificacionEnergetica.ForeColor = Color.White
            Case "F" : cmbCalificacionEnergetica.BackColor = Color.Red : cmbCalificacionEnergetica.ForeColor = Color.White
            Case "G" : cmbCalificacionEnergetica.BackColor = Color.DarkRed : cmbCalificacionEnergetica.ForeColor = Color.White
            Case Else : cmbCalificacionEnergetica.BackColor = Color.White : cmbCalificacionEnergetica.ForeColor = Color.Black
        End Select

    End Sub


    Private Sub cmbEmpleados_QueryPopUp(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbEmpleados.QueryPopUp
        cmbEmpleados.Properties.View.Columns("Contador").Visible = False

        cmbEmpleados.Properties.View.Columns("Baja").Visible = False
    End Sub

    Private Sub btnDuplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DuplicarInmueble()
    End Sub
    Sub DuplicarInmueble()
        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Return
        End If
        'If XtraMessageBox.Show("¿Confirma que quiere duplicar el inmueble seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
        '    Exit Sub
        'End If

        Dim dupli As New ucDuplicarInmueble(BinSrc.Current("Precio"), BinSrc.Current("PrecioPropietario"))
        dupli.ShowDialog()

        If dupli.pvp = -1 Then Exit Sub

        Dim NuevaReferencia As String = FuncionesBD.sp_DuplicarDocumento(BinSrc.Current("Contador"), TablaMantenimiento, TablaMantenimiento, GL_CodigoUsuario)
        '    Dim NuevaReferencia As String = bd.Execute("SELECT MAX(CONVERT(BIGINT,Referencia)) FROM Inmuebles WHERE CodigoEmpresa=" & DatosEmpresa.Codigo, False)

        Dim tipoVenta As String = BinSrc.Current("TipoVenta")
        Dim sqltipo As String = ""
        If tipoVenta = GL_Palabra_Venta Then
            sqltipo = " ,TipoVenta='" & GL_Palabra_Alquiler & "'"
            tipoVenta = GL_Palabra_Alquiler
        ElseIf tipoVenta = GL_Palabra_Alquiler Then
            sqltipo = " ,TipoVenta='" & GL_Palabra_Venta & "'"
            tipoVenta = GL_Palabra_Venta
        End If

        BD_CERO.Execute("UPDATE " & TablaInmuebles & " SET Precio=" & Funciones.ReplacePuntos(dupli.pvp) & ",PrecioPropietario=" & Funciones.ReplacePuntos(dupli.pp) & sqltipo & " WHERE Referencia='" & NuevaReferencia & "'")

        Dim obs As New Tablas.clComunicaciones
        With obs
            .Tipo = GL_OBSERVACIONES_LLAMADA
            .Tabla = GL_TablaPropietarios
            .ContadorClientePropietarioInmueble = BinSrc.Current("ContadorPropietario")
            .CodigoEmpresa = DatosEmpresa.Codigo
            .ContadorEmpleado = GL_CodigoUsuario
            .Delegacion = Gl_Delegacion
            .Observaciones = "Inmueble duplicado Referencia: " & NuevaReferencia & " dado de alta como " & tipoVenta & " por: PVP: " & dupli.pvp & " €, Propietario: " & dupli.pp & " €"
            .ContadorInmueble = BD_CERO.Execute("SELECT Contador FROM Inmuebles WHERE Referencia='" & NuevaReferencia & "' ", False)
            .LlamadaContestada = True
        End With

        ConsultasBaseDatos.InsertarComunicacionesObservaciones(obs)
        'JCB CARPETA FOTOS
        Dim CarpetaDocumentoOrigen As String = GL_CarpetaFotos & "\" & BinSrc.Current("Referencia")
        Dim CarpetaDocumentoDestino As String = GL_CarpetaFotos & "\" & NuevaReferencia


        Dim DirFiles() As String = Nothing

        If System.IO.Directory.Exists(CarpetaDocumentoOrigen) Then
            DirFiles = System.IO.Directory.GetFiles(CarpetaDocumentoOrigen, "*.*")

            Try
                If DirFiles.Length > 0 Then
                    If System.IO.Directory.Exists(CarpetaDocumentoDestino) Then
                        Directory.Delete(CarpetaDocumentoDestino, True)
                    End If
                    FuncionesGenerales.Funciones.ComprobarYCrearCarpetas(CarpetaDocumentoDestino)
                    For i = 0 To DirFiles.Length - 1
                        Dim NombreFichero As String = My.Computer.FileSystem.GetName(DirFiles(i))
                        Dim RutaFicheroDestino = CarpetaDocumentoDestino & "\" & NombreFichero
                        System.IO.File.Copy(DirFiles(i), RutaFicheroDestino)
                    Next

                    'Try
                    '    For i = 0 To DirFiles.Length - 1
                    '        System.IO.File.Delete(DirFiles(i))
                    '    Next

                    'Catch ex As Exception

                    'End Try




                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try
        End If
        XtraMessageBox.Show("La Referencia del nuevo inmueble es: " & vbCrLf & NuevaReferencia)
        'aqui sacariamos una pantalla para modificar los datos del nuevo inmueble
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        LlenarGrid()
        SituarseEnGrid(Gv, NuevaReferencia, "Referencia")
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub
    'Public Sub Mapa(Optional ByVal Contador As Integer = 0)

    '    ' Dim objetoMaps As New MapsNet

    '    'Dim direccionString = objetoMaps.ObtenerURLdesdeDireccion(txtDireccion.Text) 'String con la direccion
    '    '   Dim direccion As New Uri(direccionString) 'Pasamos el string a URI


    '    If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
    '        MensajeInformacion("Debe seleccionar un registro")
    '        Return
    '    End If

    '    If dgvx.ColumnaCheck.SelectedCount > 1 Then Return
    '    Dim a As DataRowView = Gv.GetFocusedRow
    '    If Contador = 0 Then Contador = a.Item("Contador")
    '    Dim bdmap As New BaseDatos
    '    Dim dr As Object
    '    dr = bdmap.ExecuteReader("SELECT  " & Funciones.SQL_CASE({"Via <> ''", "Via=''"}, {Funciones.SQL_CASE_ISNULL("(SELECT Abreviatura FROM Vias WHERE Via = I.Via),''") & "   " & GL_SQL_SUMA & "' '" & GL_SQL_SUMA & " Direccion " & GL_SQL_SUMA & "' '" & GL_SQL_SUMA & " Numero", "Direccion " & GL_SQL_SUMA & "' '" & GL_SQL_SUMA & " Numero"}) & " as Direccion,CodPostal,Poblacion,Provincia FROM Inmuebles I WHERE Contador = " & Contador)
    '    dr.Read()
    '    Dim Direccion As String = dr("Direccion")
    '    Dim CodPostal As String = dr("CodPostal")
    '    Dim Poblacion As String = dr("Poblacion")
    '    Dim Provincia As String = dr("Provincia")
    '    dr.Close()
    '    bdmap.CerrarBD()
    '    Dim mp As New MapaGoogle(Direccion, CodPostal, Poblacion, Provincia)

    '    Dim p As New XtraForm1("Mapa")
    '    p.Name = "Mapa"

    '    Dim u As New WebBrowser
    '    u.Dock = DockStyle.Fill

    '    p.Controls.Add(u)
    '    p.Size = New Size(New Point(700, 550))
    '    p.Show()

    '    u.ScriptErrorsSuppressed = True
    '    u.Navigate(mp.ObtenerFichero)


    'End Sub


    Private Sub txtDireccion_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDireccion.Leave, txtNumero.Leave, txtPuerta.Leave, cmbPoblacion.Leave

        If Not EstoyEnAlta Then Return

        If txtDireccion.Text.Trim = "" OrElse txtNumero.Text.Trim = "" OrElse txtPuerta.Text.Trim = "" OrElse cmbPoblacion.Text.Trim = "" Then
            Return
        End If


        Dim Sel As String
        Dim bdBusca As New BaseDatos

        Sel = GL_SQL_TOP1_FRONT & " Referencia,Baja,Contador FROM Inmuebles WHERE Via = '" & cmbVia.EditValue & "' AND Direccion = '" & FuncionesGenerales.Funciones.pf_ReplaceComillas(txtDireccion.Text.Trim) & "' AND Numero = '" & FuncionesGenerales.Funciones.pf_ReplaceComillas(txtNumero.Text.Trim) & "' AND Puerta = '" & FuncionesGenerales.Funciones.pf_ReplaceComillas(txtPuerta.Text.Trim) & "' AND Poblacion = '" & FuncionesGenerales.Funciones.pf_ReplaceComillas(cmbPoblacion.Text.Trim) & "'" & GL_SQL_TOP1_BACK
        Dim dtr As Object
        dtr = bdBusca.ExecuteReader(Sel)
        If dtr.hasrows Then
            dtr.read()
            Dim Referencia As String = dtr("Referencia")
            If XtraMessageBox.Show("Ya existe un inmueble (" & Referencia & ") con esa dirección" & vbCrLf & "¿Desea verlo?", "Duplicado", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                If (Not dtr("Baja") And Not PulsadoVerBajas) Or (dtr("Baja") And PulsadoVerBajas) Then
                    dtr.close()
                    EstoyEnAlta = False
                    Cancelar()
                    BinSrc.Filter = "Referencia = " & Referencia
                    BinSrc.MoveFirst()
                Else
                    dtr.close()
                    EstoyEnAlta = False
                    Cancelar()
                    VerBajas()
                    BinSrc.Filter = "Referencia = " & Referencia
                    BinSrc.MoveFirst()
                End If
            End If
        End If
        dtr.close()
        bdBusca.CerrarBD()
    End Sub


    Private Sub btnMostrarListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrarListado.Click
        TabInmuebles.Visible = Not TabInmuebles.Visible



        If TabInmuebles.Visible AndAlso Me.Height < 800 Then
            Gv.OptionsView.ShowFooter = False
            Gv.OptionsView.ShowAutoFilterRow = False
        Else
            Gv.OptionsView.ShowFooter = True
            Gv.OptionsView.ShowAutoFilterRow = True
        End If

        'If LayoutDatosBusqueda.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never Then
        '    LayoutDatosBusqueda.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        '    If TabInmuebles.SelectedTabPageIndex = 1 Then
        '        btnVisitas.Visible = False
        '        btnDirecciones.Visible = False
        '        btnReservar.Visible = False
        '    Else
        '        btnVisitas.Visible = True
        '        btnDirecciones.Visible = True
        '        btnReservar.Visible = True
        '    End If
        'Else
        '    LayoutDatosBusqueda.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '    btnReservar.Visible = False
        '    btnVisitas.Visible = False
        '    btnDirecciones.Visible = False
        'End If

        'Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height - (frmPrincipal.ribbonControl.Height + 5)
        'If AltoVentana = 0 Then
        '    AltoVentana = LayoutControlItem2.Height
        '    LayoutControlItem2.Height = a
        '    Exit Sub
        'End If
        'If LayoutControlItem2.Height > AltoVentana Then
        '    LayoutControlItem2.Height = AltoVentana
        'Else
        '    LayoutControlItem2.Height = a
        'End If
    End Sub

    Private Sub btnVisitas_Click(sender As System.Object, e As System.EventArgs) Handles btnVisitas.Click

        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            MensajeInformacion("Debe seleccionar un registro")
            Return
        End If

        Dim Contador As Integer = 0
        Dim Nombre As String = ""

        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then

        Else
            Contador = BinSrc.Current("Contador")
            Nombre = txtReferencia.EditValue
        End If

        Dim f As New frmVisitas(0, "", Contador, Nombre, GL_VENGO_DE_INMUEBLES)
        If Not PulsadoVerBajas Then f.EsBajas = True
        f.ShowDialog()

    End Sub

    Private Sub btnDirecciones_Click(sender As System.Object, e As System.EventArgs) Handles btnDirecciones.Click
        MostrarOcultarDatosPropietarios(Not PanelDatosOcultos.Visible)

    End Sub

    Private Sub btnVerTodos_Click(sender As System.Object, e As System.EventArgs) Handles btnVerTodos.Click
        VerTodos()
    End Sub
    Private Sub VerTodos()
        FiltroBusqueda = ""
        txtBusquedaEmailTelefono.Text = ""
        DeDondeVengo = ""
        Gv.ActiveFilterCriteria = Nothing
        Try
            BinSrc.Filter = Nothing
        Catch ex As Exception

        End Try
        LlenarGrid()
    End Sub
    Private Sub btnVentaAlquiler_Click(sender As System.Object, e As System.EventArgs) Handles btnVentaAlquiler.Click
        Dim f As New frmFiltroDuplicados
        f.ShowDialog()
        LlenarGrid(whereAdicional:=GL_VentaAlquiler)
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If btnBuscar.Text = "Buscar" Then
            frmBuscador.EsInmuebles = True
            frmBuscador.ShowDialog()
            If GL_Busqueda <> "" Then
                LlenarGrid(GL_Busqueda)
                btnBuscar.Text = "Quitar Bús."
                btnBuscar.Image = My.Resources.QuitarBusqueda
                btnBuscar.Tag = "Quitar Búsqueda"
            End If
        Else
            LlenarGrid()
            btnBuscar.Text = "Buscar"
            btnBuscar.Tag = "Buscar Inmuebles"
            btnBuscar.Image = My.Resources.Buscar
        End If
    End Sub


    Private Sub cmbTipoVenta_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoVenta.EditValueChanged

        If cmbTipoVenta.Enabled Then
            If cmbTipoVenta.EditValue = GL_Palabra_Venta OrElse cmbTipoVenta.EditValue = GL_Palabra_Alquiler Then
                chkOpcionCompra.Enabled = True
                chkAlquilerVacacional.Enabled = True
            Else
                chkOpcionCompra.Enabled = False
                chkAlquilerVacacional.Enabled = False
            End If
        End If
    End Sub

    Private Sub chkBalcon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBalcon.CheckedChanged
        If chkBalcon.Checked = False Then
            spnBalconM1.EditValue = 0
            spnBalconM2.EditValue = 0
        End If
    End Sub
    Private Sub chkPatio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPatio.CheckedChanged
        If chkPatio.Checked = False Then
            spnPatioM1.EditValue = 0
            spnPatioM2.EditValue = 0
        End If
    End Sub
    Private Sub chkTerraza_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTerraza.CheckedChanged
        If chkTerraza.Checked = False Then
            spnTerrazaM1.EditValue = 0
            spnTerrazaM2.EditValue = 0
        End If
    End Sub
    Private Sub chkJardin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkJardin.CheckedChanged
        If chkJardin.Checked = False Then
            spnJardinM1.EditValue = 0
        End If
    End Sub
    'Private Sub ucGarajeVenta_Load() Handles ucGarajeVenta.
    '    If ucGarajeVenta.Valor = 0 Then
    '    spnMetrosGaraje.EditValue = 0
    '    spnPrecioGaraje.EditValue = 0
    '    End If
    'End Sub
    'Private Sub ucTrasteroVenta_Load() Handles ucTrasteroVenta.
    '    If ucTrasteroVenta.Valor = 0 Then
    '    spnMetrosTrastero.EditValue = 0
    '    spnPrecioTrastero.EditValue = 0
    '    End If
    'End Sub

    Private Sub Gv_DragObjectDrop(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.DragObjectDropEventArgs) Handles Gv.DragObjectDrop
        Select Case e.DragObject.ColumnType.Name
            Case "Boolean"
                e.DragObject.ColumnEdit = Gv.GridControl.RepositoryItems("tbRichk")
            Case "Byte"
                e.DragObject.ColumnEdit = Gv.GridControl.RepositoryItems("tbRichk2")
        End Select
    End Sub

    Private Sub btnVerEnWeb_Click(sender As System.Object, e As System.EventArgs) Handles btnVerEnWeb.Click

        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            MensajeInformacion("Debe seleccionar un registro")
            Return
        End If


        Dim proceso As New System.Diagnostics.Process
        With proceso
            .StartInfo.FileName = Funciones.EnlaceWeb(BinSrc.Current("Tipo").ToString, BinSrc.Current("TipoVenta").ToString, BinSrc.Current("Poblacion").ToString, BinSrc.Current("Referencia").ToString, False)
            .Start()
        End With
    End Sub

    Private Sub txtObservaciones_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtObservaciones.DoubleClick, txtExtras.DoubleClick, MemoGrande.DoubleClick
        Dim CONTROL As MemoEdit = TryCast(sender, MemoEdit)
        If CONTROL.Properties.ReadOnly Then
            If CONTROL.Name.ToUpper = "MEMOGRANDE" Then
                MemoGrande.Visible = False
            Else
                If CONTROL.Name = txtObservaciones.Name Then
                    MemoGrande.Tag = "Observaciones"
                Else
                    MemoGrande.Tag = "Extras"
                End If
                MemoGrande.Size = pnlDatosGenerales.Size
                MemoGrande.Text = CONTROL.Text
                MemoGrande.Visible = True
            End If
        Else
            If CONTROL.Name.ToUpper = "MEMOGRANDE" Then
                If CONTROL.Tag = "Observaciones" Then
                    txtObservaciones.Text = CONTROL.Text
                Else
                    txtExtras.Text = CONTROL.Text
                End If
                MemoGrande.Visible = False
            Else
                If CONTROL.Name = txtObservaciones.Name Then
                    MemoGrande.Tag = "Observaciones"
                Else
                    MemoGrande.Tag = "Extras"
                End If
                MemoGrande.Size = pnlDatosGenerales.Size
                MemoGrande.Text = CONTROL.Text
                MemoGrande.Visible = True
            End If
        End If


    End Sub

    Private Sub btnPublicar_Click(sender As System.Object, e As System.EventArgs) Handles btnPublicar.Click
        If Gv.RowCount = 0 OrElse (Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle And dgvx.ColumnaCheck.SelectedCount = 0) Then Return
        If dgvx.ColumnaCheck.SelectedCount = 0 Then
            dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, True)
        End If


        If Portal.ToUpper <> "FOTOCASA" Then
            GuardarSeleccion()

        End If


        ActualizarPortales(Portal) '.ToUpper
    End Sub
    Public Sub PublicarFotoCasa(Optional Preguntar As Boolean = True)

        If Gv.RowCount = 0 OrElse (Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle And dgvx.ColumnaCheck.SelectedCount = 0) Then Return
        If dgvx.ColumnaCheck.SelectedCount = 0 Then
            dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, True)
        End If


        Dim ListaErrores As New List(Of String)

        If Preguntar Then
            If MsgBox("¿Estas seguro de querer publicar en " & "FotoCasa" & IIf(dgvx.ColumnaCheck.SelectedCount = 1, " el ", " los " & dgvx.ColumnaCheck.SelectedCount) & IIf(dgvx.ColumnaCheck.SelectedCount = 1, " inmueble seleccionado", " inmuebles seleccionados") & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Return
        End If



        Dim CodigoAPI As String
        Dim Sel As String = ""

        Sel = "SELECT Codigo FROM ClientePortales WHERE Portal = 'FotoCasa' and CodigoEmpresa = " & DatosEmpresa.Codigo
        CodigoAPI = BD_CERO.Execute(Sel, False, "")

        If CodigoAPI = "" Then
            MensajeError("No puede publicar en FotoCasa porque no tiene código API de acceso")
            Return
        End If

        Gv.ClearColumnsFilter()



        Dim pf As New ProgressForm(dgvx.ColumnaCheck.SelectedCount, "Publicando Inmuebles en FotoCasa ...")
        Application.DoEvents()


        For i As Integer = 0 To dgvx.ColumnaCheck.SelectedCount - 1

            'Primero despublicamos(por si ya estuviera arriba) y luego publicamos
            Dim Res As clResultado
            'res= DespublicarFotocasa(dgvx.ColumnaCheck.GetSelectedRow(i)("Referencia"), CodigoAPI)


            Res = PublicarFotoCasaRest(i, CodigoAPI)

            If Res.StatusCode = 0 Then

            Else
                ListaErrores.Add("Referencia: " & dgvx.ColumnaCheck.GetSelectedRow(i)("Referencia") & ". " & Res.Message)
            End If



            pf.nuevoPaso()
            Application.DoEvents()

        Next
        dgvx.ColumnaCheck.ClearSelection()

        LlenarGrid()

        pf.Close()

        If ListaErrores.Count > 0 Then
            Dim ds As New DataSet
            Dim dt2 As New DataTable("Listado")
            ds.Tables.Add(dt2)
            Dim dc1 As New DataColumn("Texto")
            dt2.Columns.Add(dc1)

            For Each EanNoVal As String In ListaErrores
                Dim dr As DataRow = dt2.NewRow
                dr("Texto") = EanNoVal.Trim
                dt2.Rows.Add(dr)
            Next


            ' dt2.WriteXml(My.Application.Info.DirectoryPath & "\EsquemasXML\rptListado.xml")
            'pr_InformeCrystal2008(clVariables.RutaServidor & "\Listados\rptListado.rpt", dt2, , , , "NIF's que no se han podido publicar.")

            Dim r As New rptListado

            r.DataSource = dt2
            r.DataMember = "Listado"
            r.par_Titulo.Value = "Listado de referencias que no se han podido publicar. Fecha: " & Microsoft.VisualBasic.Format(Now, "dd/MM/yyyy HH:mm:ss")
            r.PageHeader.Visible = False
            r.par_Titulo.Visible = False
            r.ShowPreview()

        Else
            If dgvx.ColumnaCheck.SelectedCount = 1 Then
                If Preguntar Then
                    MensajeInformacion("El inmuebles se publicó en Fotocasa correctamente")
                Else
                    MensajeInformacion("El inmueble se actualizó en Fotocasa correctamente")
                End If

            Else
                If Preguntar Then
                    MensajeInformacion("El inmuebles se publicaron en Fotocasa correctamente")
                Else
                    MensajeInformacion("El inmueble se actualizó en Fotocasa correctamente")
                End If
            End If

        End If



    End Sub

    Private Function ValidarPublicacion(CodigoAPI As String) As clResultado

        Dim Res As New clResultado

        Try

            Dim client = New RestClient(GL_wsRutaWs & "/publication/property")
            Dim request = New RestRequest(Method.GET)

            request.AddHeader("Inmofactory-Api-Key", CodigoAPI)
            request.AddHeader("Cache-Control", "no-cache")
            request.AddHeader("content-type", "application/json")

            'Dim postData As String = SerializarPost(Inmueble)

            'request.AddParameter("application/json", postData, ParameterType.RequestBody)

            Dim response As IRestResponse = client.Execute(request)

            If response.StatusCode = 200 Then

                Dim ListaEnFotocasa As New List(Of String)

                Dim ListaTodos As New List(Of String)

                response.Content = Replace(response.Content, "\", "")
                response.Content = Replace(response.Content, """", "")

                Dim Inmus As List(Of clAgencyExternal)
                Inmus = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of clAgencyExternal))(response.Content)

                Dim Sel As String
                Dim Cuantos As Integer

                For i = 0 To Inmus.Count - 1
                    Sel = "SELECT COUNT(*) FROM Inmuebles WHERE Referencia = '" & Inmus(i).AgencyReference & "' AND  PortalFotocasa = 1"
                    Cuantos = BD_CERO.Execute(Sel, False, 0)
                    If Cuantos = 0 Then
                        ListaEnFotocasa.Add(Inmus(i).AgencyReference)
                    End If
                    ListaTodos.Add(Inmus(i).AgencyReference)
                Next
                ListaTodos.Sort()
                ListaEnFotocasa.Sort()

                Dim ListaEnPrograma As New List(Of String)
                Sel = "SELECT Referencia FROM Inmuebles WHERE PortalFotocasa = 1 ORDER BY Referencia"
                Dim bdF As New BaseDatos
                bdF.LlenarDataSet(Sel, "T")

                For i = 0 To bdF.ds.Tables(0).Rows.Count - 1
                    If Not ListaTodos.Contains(bdF.ds.Tables(0).Rows(i)("Referencia")) Then
                        ListaEnPrograma.Add(bdF.ds.Tables(0).Rows(i)("Referencia"))
                    End If
                Next

                ListaEnPrograma.Sort()

                Dim TodoOK As Boolean = True

                If ListaEnFotocasa.Count > 0 Then
                    Dim ds As New DataSet
                    Dim dt2 As New DataTable("Listado")
                    ds.Tables.Add(dt2)
                    Dim dc1 As New DataColumn("Texto")
                    dt2.Columns.Add(dc1)

                    For Each EanNoVal As String In ListaEnFotocasa
                        Dim dr As DataRow = dt2.NewRow
                        dr("Texto") = EanNoVal.Trim
                        dt2.Rows.Add(dr)
                        TodoOK = False
                    Next

                    If TodoOK = False Then
                        Dim r As New rptListado

                        r.DataSource = dt2
                        r.DataMember = "Listado"
                        r.par_Titulo.Value = "Listado de referencias en Fotocasa y no en el programa. Fecha: " & Microsoft.VisualBasic.Format(Now, "dd/MM/yyyy HH:mm:ss")
                        r.PageHeader.Visible = False
                        r.par_Titulo.Visible = False
                        r.ShowPreview()
                    End If

                End If



                If ListaEnPrograma.Count > 0 Then
                    Dim ds As New DataSet
                    Dim dt2 As New DataTable("Listado")
                    ds.Tables.Add(dt2)
                    Dim dc1 As New DataColumn("Texto")
                    dt2.Columns.Add(dc1)

                    For Each EanNoVal As String In ListaEnPrograma
                        Dim dr As DataRow = dt2.NewRow
                        dr("Texto") = EanNoVal.Trim
                        dt2.Rows.Add(dr)
                        TodoOK = False
                    Next

                    If TodoOK = False Then
                        Dim r As New rptListado
                        r.DataSource = dt2
                        r.DataMember = "Listado"
                        r.par_Titulo.Value = "Listado de referencias en Programa y no en Fotocasa. Fecha: " & Microsoft.VisualBasic.Format(Now, "dd/MM/yyyy HH:mm:ss")
                        r.PageHeader.Visible = False
                        r.par_Titulo.Visible = False
                        r.ShowPreview()
                    End If



                End If

                If TodoOK Then
                    MensajeInformacion("Sincronización con Fotocasa OK")
                End If
            Else
                Res.StatusCode = -1
                Res = Newtonsoft.Json.JsonConvert.DeserializeObject(Of clResultado)(response.Content)
                Res.Code = response.StatusDescription
            End If




        Catch ex4 As FaultException(Of clResultado)
            Res.StatusCode = ex4.Code.ToString
            Res.Message = ex4.Reason.ToString

        Catch ex5 As Net.WebException
            Res.StatusCode = GL_CodigoErrorWebService
            Res.Message = ex5.Message

        Catch ex As Exception
            Res.StatusCode = GL_CodigoErrorWebService
            Res.Message = ex.Message
        End Try

        Return Res


    End Function
    Private Function PublicarFotoCasaRest(i As Integer, CodigoAPI As String) As clResultado

        Dim Res As New clResultado
        Dim Locati As location
        Dim Referencia As Integer = dgvx.ColumnaCheck.GetSelectedRow(i)("Referencia")


        If Debugger.IsAttached Then
            Return Res
        End If


        If dgvx.ColumnaCheck.GetSelectedRow(i)("Metros") = 0 Then
            Res.StatusCode = -1
            Res.Message = "No se puede publicar el inmueble en Fotocasa porque no tiene metros"
            Return Res
        End If

        If dgvx.ColumnaCheck.GetSelectedRow(i)("Precio") = 0 Then
            Res.StatusCode = -1
            Res.Message = "No se puede publicar el inmueble en Fotocasa porque no tiene Precio"
            Return Res
        End If

        If dgvx.ColumnaCheck.GetSelectedRow(i)("CodPostal").ToString.Trim = "" Then
            Res.StatusCode = -1
            Res.Message = "No se puede publicar el inmueble en Fotocasa porque no tiene Código Postal"
            Return Res
        End If

        Try

            Dim Direccion As String = ""
            Direccion = dgvx.ColumnaCheck.GetSelectedRow(i)("Provincia") & "+" & dgvx.ColumnaCheck.GetSelectedRow(i)("Poblacion") & "+" & dgvx.ColumnaCheck.GetSelectedRow(i)("CodPostal") & "+" & dgvx.ColumnaCheck.GetSelectedRow(i)("DireccionMapa") ' & "+" & dgvx.ColumnaCheck.GetSelectedRow(i)("Numero")

            Locati = ObtenerLocation(Direccion)



        Catch ex As Exception


            Res.StatusCode = -1
            Res.Message = "Error al obtener la latitud y la longitud " & ex.Message
            Return Res
        End Try

        If Locati.lat = 0 AndAlso Locati.lng = 0 Then
            Res.StatusCode = -1
            Res.Message = "Error al obtener la latitud y la longitud. No se pudo obtener localizar el inmueble con la dirección actual"
            Return Res
        End If


        Dim Inmueble As Objetos.Inmuebles = PrepararJsonInmueble(i, Locati)

        If IsNothing(Inmueble) Then
            Res.StatusCode = -1
            Res.Message = "Error al construir el objeto"
            Return Res
        End If

        Try

            ''Para superseguridad. SOLO con Framework 4.5
            ''System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls


            Dim client = New RestClient(GL_wsRutaWs & "property")
            Dim request = New RestRequest(Method.[POST])

            request.AddHeader("Inmofactory-Api-Key", CodigoAPI)
            request.AddHeader("Cache-Control", "no-cache")
            request.AddHeader("content-type", "application/json")

            Dim postData As String = SerializarPost(Inmueble)

            request.AddParameter("application/json", postData, ParameterType.RequestBody)

            Dim response As IRestResponse = client.Execute(request)

            Dim MensajeAdicional As String = response.Content
            Dim Sel As String

            If response.StatusCode = 201 Then
                Res.Message = response.Content
                Res.StatusCode = 0
                Res.Code = ""

                Sel = "UPDATE Inmuebles SET Portal" & "FotoCasa" & " = " & GL_SQL_VALOR_1 & " WHERE Referencia = '" & Funciones.pf_ReplaceComillas(Referencia) & "' AND CodigoEmpresa=" & DatosEmpresa.Codigo
                BD_CERO.Execute(Sel)

                InsertaEnTramites(Referencia, "ALTA FOTOCASA", MensajeAdicional)
            Else
                Res = Newtonsoft.Json.JsonConvert.DeserializeObject(Of clResultado)(response.Content)


                If Res.StatusCode = 400 AndAlso Res.Code = "Error_110" Then  'El inmueble ya existe, hacemos un put
                    request.Method = Method.PUT
                    response = client.Execute(request)
                    MensajeAdicional = response.Content
                    If response.StatusCode = 200 Then
                        Res.Message = response.Content
                        Res.StatusCode = 0
                        Res.Code = ""


                        Sel = "UPDATE Inmuebles SET Portal" & "FotoCasa" & " = " & GL_SQL_VALOR_1 & " WHERE Referencia = '" & Funciones.pf_ReplaceComillas(Referencia) & "' AND CodigoEmpresa=" & DatosEmpresa.Codigo
                        BD_CERO.Execute(Sel)

                        InsertaEnTramites(Referencia, "ALTA FOTOCASA", MensajeAdicional)

                    Else
                        Res.StatusCode = -1
                        Res = Newtonsoft.Json.JsonConvert.DeserializeObject(Of clResultado)(response.Content)
                        Res.Code = response.StatusDescription
                        InsertaEnTramites(Referencia, "INTENTO ALTA FOTOCASA", MensajeAdicional)
                    End If



                Else
                    Res.StatusCode = -2
                    Res = Newtonsoft.Json.JsonConvert.DeserializeObject(Of clResultado)(response.Content)
                    Res.Code = response.StatusDescription
                    InsertaEnTramites(Referencia, "INTENTO ALTA FOTOCASA", MensajeAdicional)

                End If

            End If

            InsertarMovimientosFotocasa(Referencia, 1, Res.StatusCode, "ALTA", MensajeAdicional)



        Catch ex4 As FaultException(Of clResultado)
            Res.StatusCode = ex4.Code.ToString
            Res.Message = ex4.Reason.ToString

        Catch ex5 As Net.WebException
            Res.StatusCode = GL_CodigoErrorWebService
            Res.Message = ex5.Message

        Catch ex As Exception
            Res.StatusCode = GL_CodigoErrorWebService
            Res.Message = ex.Message
        End Try

        Return Res


    End Function

    Private Function PrepararJsonInmueble(i As Integer, Locati As location) As Objetos.Inmuebles

        Dim Referencia As String = dgvx.ColumnaCheck.GetSelectedRow(i)("Referencia")
        Dim Sel As String
        Sel = "SELECT Tipo FROM TipoPortales WHERE Contador=(SELECT Contador" & "FotoCasa" & " FROM Tipo WHERE CodigoEmpresa=" & DatosEmpresa.Codigo & " AND Tipo='" & dgvx.ColumnaCheck.GetSelectedRow(i)("Tipo") & "')"
        Dim Tipo As String
        Tipo = BD_CERO.Execute(Sel, False, "")

        If Tipo = "" Then
            MensajeError("No se puede continuar con la publicación porque la referencia " & Referencia & " no tiene tipo asignado")
            Return Nothing
        End If


        Dim IdTipoVenta As Integer = 0
        Sel = "SELECT TipoVenta FROM TipoVentaPortales WHERE Contador=(SELECT Contador" & "FotoCasa" & " FROM TipoVenta WHERE CodigoEmpresa=" & DatosEmpresa.Codigo & " AND TipoVenta='" & dgvx.ColumnaCheck.GetSelectedRow(i)("TipoVenta") & "')"
        Dim tipoventa As String = BD_CERO.Execute(Sel, False)
        If IsNothing(tipoventa) OrElse Not tipoventa.Contains("|") Then
            MensajeError("No se puede continuar con la publicación porque la referencia " & Referencia & " no tiene tipo asignado")
            Return Nothing
        End If
        IdTipoVenta = tipoventa.Split("|")(0)
        'Dim tipo As String = BD_CERO.Execute(Sel, False)
        'If IsNothing(tipo) OrElse Not tipo.Contains("|") Then
        '    XtraMessageBox.Show("Error al publicar el inmueble " & dtr("Referencia") & ", el tipo " & dtr("Tipo") & " NO esta asignado" & vbCrLf & "Se cancela la publicación completa de " & "FotoCasa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    .Flush()
        '    .Close()
        '    bdPublicar.CerrarBD()
        '    dtr.close()
        '    pf.Close()
        '    Return Inmueble
        'End If
        '.WriteAttributeString("id", tipo.Split("|")(0))
        '.WriteString(tipo.Split("|")(1))


        Dim Inmueble As New Objetos.Inmuebles

        Inmueble.ExternalId = Referencia
        Inmueble.AgencyReference = Referencia
        Inmueble.TypeId = Tipo.Split("|")(0)
        Try
            Inmueble.SubtypeId = Tipo.Split("|")(2)
        Catch ex As Exception

        End Try

        If dgvx.ColumnaCheck.GetSelectedRow(i)("Duplex") Then
            Inmueble.SubtypeId = 3
        End If

        Inmueble.IsNewConstruction = False

        Inmueble.PropertyStatusId = 1 'Disponbile DIC_PropertyStatus


        '  Inmueble.ExpirationCauseId = null
        Inmueble.ShowSurface = True
        Inmueble.ContactTypeId = 1 'Agencia DIC_PropertyContactType
        Inmueble.IsPromotion = False
        '  Inmueble.BankAwardedId = 0
        Inmueble.ContactName = "" 'Si queremos poner el nombre del contacto de la inmobiliaria


        '******* PropertyAddress
        Inmueble.PropertyAddress = New List(Of PropertyAddress)

        Dim MiPropertyAddress = New PropertyAddress

        Dim StreetTypeId As Integer = 0
        Sel = "SELECT Id FROM ViasFotocasa WHERE AComparar LIKE '%" & dgvx.ColumnaCheck.GetSelectedRow(i)("Via") & "%'"
        StreetTypeId = BD_CERO.Execute(Sel, False, 0)

        Dim FloorId As Integer = 0
        If dgvx.ColumnaCheck.GetSelectedRow(i)("Altura") = -2 Then
            FloorId = 5
        Else
            If dgvx.ColumnaCheck.GetSelectedRow(i)("Altura") = -1 Then
                FloorId = 4
            Else
                If dgvx.ColumnaCheck.GetSelectedRow(i)("Altura") = 0 Then
                    FloorId = 3
                Else

                    FloorId = dgvx.ColumnaCheck.GetSelectedRow(i)("Altura") + 5
                End If
            End If
        End If


        MiPropertyAddress.ZipCode = dgvx.ColumnaCheck.GetSelectedRow(i)("CodPostal")
        MiPropertyAddress.CountryId = 724
        MiPropertyAddress.Zone = ""
        MiPropertyAddress.StreetTypeId = StreetTypeId
        'MiPropertyAddress.Street = dgvx.ColumnaCheck.GetSelectedRow(i)("Direccion")
        'MiPropertyAddress.Number = dgvx.ColumnaCheck.GetSelectedRow(i)("Numero")

        MiPropertyAddress.Street = dgvx.ColumnaCheck.GetSelectedRow(i)("DireccionMapa")
        MiPropertyAddress.Number = 1


        MiPropertyAddress.FloorId = FloorId



        MiPropertyAddress.x = CDbl(Replace(Locati.lng, ".", ","))
        MiPropertyAddress.y = CDbl(Replace(Locati.lat, ".", ","))
        MiPropertyAddress.VisibilityModeId = 2

        Inmueble.PropertyAddress.Add(MiPropertyAddress)





        '******* PropertyFeature
        Inmueble.PropertyFeature = New List(Of PropertyFeature)

        Dim MiPropertyFeature As PropertyFeature

        MiPropertyFeature = New PropertyFeature
        MiPropertyFeature.FeatureId = 1
        MiPropertyFeature.LanguageId = 4
        MiPropertyFeature.DecimalValue = dgvx.ColumnaCheck.GetSelectedRow(i)("Metros")
        Inmueble.PropertyFeature.Add(MiPropertyFeature)

        Dim Descripcion As String = ConsultasBaseDatos.ObtenerDescripcionInmueble2(dgvx.ColumnaCheck.GetSelectedRow(i)("Contador"), 0)
        MiPropertyFeature = New PropertyFeature  'Descripcion Abreviada
        MiPropertyFeature.FeatureId = 2
        MiPropertyFeature.LanguageId = 4
        MiPropertyFeature.TextValue = Descripcion
        Inmueble.PropertyFeature.Add(MiPropertyFeature)

        MiPropertyFeature = New PropertyFeature  'Descripcion Extendida
        MiPropertyFeature.FeatureId = 3
        MiPropertyFeature.LanguageId = 4
        MiPropertyFeature.TextValue = Descripcion
        Inmueble.PropertyFeature.Add(MiPropertyFeature)


        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 10 Then
            MiPropertyFeature = New PropertyFeature  'Descripcion Extendida
            MiPropertyFeature.FeatureId = 11
            MiPropertyFeature.LanguageId = 4
            MiPropertyFeature.DecimalValue = dgvx.ColumnaCheck.GetSelectedRow(i)("Habitaciones")
            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If


        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Then
            MiPropertyFeature = New PropertyFeature  'Descripcion Extendida
            MiPropertyFeature.FeatureId = 12
            MiPropertyFeature.LanguageId = 4
            MiPropertyFeature.DecimalValue = dgvx.ColumnaCheck.GetSelectedRow(i)("Banos")
            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 3 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 5 Or Inmueble.TypeId = 10 Then
            MiPropertyFeature = New PropertyFeature  'Descripcion Extendida
            MiPropertyFeature.FeatureId = 22
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(dgvx.ColumnaCheck.GetSelectedRow(i)("Ascensor")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = dgvx.ColumnaCheck.GetSelectedRow(i)("Ascensor")
            End If
            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 5 Or Inmueble.TypeId = 10 Then
            MiPropertyFeature = New PropertyFeature  'Descripcion Extendida
            MiPropertyFeature.FeatureId = 23
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(dgvx.ColumnaCheck.GetSelectedRow(i)("Garaje")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = dgvx.ColumnaCheck.GetSelectedRow(i)("Garaje")
            End If
            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 3 Or Inmueble.TypeId = 4 Then
            MiPropertyFeature = New PropertyFeature  'Descripcion Extendida
            MiPropertyFeature.FeatureId = 24
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(dgvx.ColumnaCheck.GetSelectedRow(i)("Trastero")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = dgvx.ColumnaCheck.GetSelectedRow(i)("Trastero")
            End If
            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 5 Or Inmueble.TypeId = 10 Then
            MiPropertyFeature = New PropertyFeature  'Descripcion Extendida
            MiPropertyFeature.FeatureId = 25
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(dgvx.ColumnaCheck.GetSelectedRow(i)("Piscina")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = dgvx.ColumnaCheck.GetSelectedRow(i)("Piscina")
            End If
            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 10 Then
            MiPropertyFeature = New PropertyFeature  'Descripcion Extendida
            MiPropertyFeature.FeatureId = 26
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(dgvx.ColumnaCheck.GetSelectedRow(i)("Jardin")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = dgvx.ColumnaCheck.GetSelectedRow(i)("Jardin")
            End If
            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 4 Then
            MiPropertyFeature = New PropertyFeature  'Descripcion Extendida
            MiPropertyFeature.FeatureId = 27
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(dgvx.ColumnaCheck.GetSelectedRow(i)("Terraza")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = dgvx.ColumnaCheck.GetSelectedRow(i)("Terraza")
            End If
            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 3 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 5 Or Inmueble.TypeId = 6 Or Inmueble.TypeId = 7 Or Inmueble.TypeId = 10 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 28
            MiPropertyFeature.LanguageId = 4
            Select Case dgvx.ColumnaCheck.GetSelectedRow(i)("Orientacion")
                Case "NORTE"
                    MiPropertyFeature.DecimalValue = 3
                Case "ESTE-NORTE"
                    MiPropertyFeature.DecimalValue = 1
                Case "ESTE"
                    MiPropertyFeature.DecimalValue = 5
                Case "ESTE-SUR"
                    MiPropertyFeature.DecimalValue = 6
                Case "SUR"
                    MiPropertyFeature.DecimalValue = 8
                Case "SUR-OESTE"
                    MiPropertyFeature.DecimalValue = 4
                Case "OESTE"
                    MiPropertyFeature.DecimalValue = 2
                Case "NORTE-OESTE"
                    MiPropertyFeature.DecimalValue = 7
                Case Else
                    MiPropertyFeature.DecimalValue = 3
            End Select

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If


        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 10 Then
            MiPropertyFeature = New PropertyFeature  'Descripcion Extendida
            MiPropertyFeature.FeatureId = 29
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(dgvx.ColumnaCheck.GetSelectedRow(i)("Calefaccion")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = dgvx.ColumnaCheck.GetSelectedRow(i)("Calefaccion")
            End If
            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 3 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 10 Then

            Dim Amueblado As Boolean = False
            Dim SemiAmueblado As Boolean = False

            If IsDBNull(dgvx.ColumnaCheck.GetSelectedRow(i)("Amueblado")) Then
                Amueblado = False
            Else
                Amueblado = dgvx.ColumnaCheck.GetSelectedRow(i)("Amueblado")
            End If

            If IsDBNull(dgvx.ColumnaCheck.GetSelectedRow(i)("SemiAmueblado")) Then
                SemiAmueblado = False
            Else
                SemiAmueblado = dgvx.ColumnaCheck.GetSelectedRow(i)("SemiAmueblado")
            End If

            If Amueblado OrElse SemiAmueblado Then
                Amueblado = True
            End If

            MiPropertyFeature = New PropertyFeature  'Descripcion Extendida
            MiPropertyFeature.FeatureId = 30
            MiPropertyFeature.LanguageId = 4
            MiPropertyFeature.BoolValue = Amueblado
            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 3 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 5 Or Inmueble.TypeId = 6 Or Inmueble.TypeId = 7 Or Inmueble.TypeId = 8 Or Inmueble.TypeId = 10 Or Inmueble.TypeId = 12 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 57
            MiPropertyFeature.LanguageId = 4
            MiPropertyFeature.DecimalValue = dgvx.ColumnaCheck.GetSelectedRow(i)("Metros")

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If


        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 3 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 5 Or Inmueble.TypeId = 10 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 62
            MiPropertyFeature.LanguageId = 4
            MiPropertyFeature.DecimalValue = dgvx.ColumnaCheck.GetSelectedRow(i)("MTerraza") + dgvx.ColumnaCheck.GetSelectedRow(i)("MTerraza2")

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 2 Or Inmueble.TypeId = 10 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 72
            MiPropertyFeature.LanguageId = 4
            MiPropertyFeature.DecimalValue = dgvx.ColumnaCheck.GetSelectedRow(i)("MJardin")

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If


        If Inmueble.TypeId = 2 Or Inmueble.TypeId = 10 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 83
            MiPropertyFeature.LanguageId = 4
            MiPropertyFeature.DecimalValue = dgvx.ColumnaCheck.GetSelectedRow(i)("MGaraje")

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If


        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 3 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 5 Or Inmueble.TypeId = 7 Or Inmueble.TypeId = 10 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 132
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(dgvx.ColumnaCheck.GetSelectedRow(i)("Electrodomesticos")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = dgvx.ColumnaCheck.GetSelectedRow(i)("Electrodomesticos")
            End If

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 3 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 5 Or Inmueble.TypeId = 7 Or Inmueble.TypeId = 12 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 155
            MiPropertyFeature.LanguageId = 4
            MiPropertyFeature.DecimalValue = dgvx.ColumnaCheck.GetSelectedRow(i)("PrecioComunidad")

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If


        If IdTipoVenta = 3 Or IdTipoVenta = 8 Then
            If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 3 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 8 Or Inmueble.TypeId = 12 Then
                MiPropertyFeature = New PropertyFeature
                MiPropertyFeature.FeatureId = 156
                MiPropertyFeature.LanguageId = 4

                If IsDBNull(dgvx.ColumnaCheck.GetSelectedRow(i)("ComunidadIncluida")) Then
                    MiPropertyFeature.BoolValue = False
                Else
                    MiPropertyFeature.BoolValue = dgvx.ColumnaCheck.GetSelectedRow(i)("ComunidadIncluida")
                End If

                Inmueble.PropertyFeature.Add(MiPropertyFeature)
            End If
        End If




        If Not IsDBNull(dgvx.ColumnaCheck.GetSelectedRow(i)("ZonaComercial")) AndAlso dgvx.ColumnaCheck.GetSelectedRow(i)("ZonaComercial") Then
            If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 3 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 5 Or Inmueble.TypeId = 6 Or Inmueble.TypeId = 7 Or Inmueble.TypeId = 10 Then
                MiPropertyFeature = New PropertyFeature
                MiPropertyFeature.FeatureId = 174
                MiPropertyFeature.LanguageId = 4
                MiPropertyFeature.DecimalValue = 1
                Inmueble.PropertyFeature.Add(MiPropertyFeature)
            End If
        End If

        If Not IsDBNull(dgvx.ColumnaCheck.GetSelectedRow(i)("ZonaComercial")) AndAlso dgvx.ColumnaCheck.GetSelectedRow(i)("ZonaComercial") Then
            If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 3 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 5 Or Inmueble.TypeId = 6 Or Inmueble.TypeId = 7 Or Inmueble.TypeId = 8 Or Inmueble.TypeId = 10 Then
                MiPropertyFeature = New PropertyFeature
                MiPropertyFeature.FeatureId = 175
                MiPropertyFeature.LanguageId = 4
                MiPropertyFeature.DecimalValue = 9
                Inmueble.PropertyFeature.Add(MiPropertyFeature)
            End If
        End If

        If Not IsDBNull(dgvx.ColumnaCheck.GetSelectedRow(i)("ZonaComercial")) AndAlso dgvx.ColumnaCheck.GetSelectedRow(i)("ZonaComercial") Then
            If Inmueble.TypeId = 10 Then
                MiPropertyFeature = New PropertyFeature
                MiPropertyFeature.FeatureId = 180
                MiPropertyFeature.LanguageId = 4
                MiPropertyFeature.DecimalValue = 15
                Inmueble.PropertyFeature.Add(MiPropertyFeature)
            End If
        End If

        If Not IsDBNull(dgvx.ColumnaCheck.GetSelectedRow(i)("Urbanizacion")) AndAlso dgvx.ColumnaCheck.GetSelectedRow(i)("Urbanizacion") Then
            If Inmueble.TypeId = 6 Then
                MiPropertyFeature = New PropertyFeature
                MiPropertyFeature.FeatureId = 183
                MiPropertyFeature.LanguageId = 4
                MiPropertyFeature.DecimalValue = 7
                Inmueble.PropertyFeature.Add(MiPropertyFeature)
            End If
        End If

        If Not IsDBNull(dgvx.ColumnaCheck.GetSelectedRow(i)("Urbanizacion")) AndAlso dgvx.ColumnaCheck.GetSelectedRow(i)("Urbanizacion") Then
            If Inmueble.TypeId = 10 Then
                MiPropertyFeature = New PropertyFeature
                MiPropertyFeature.FeatureId = 187
                MiPropertyFeature.LanguageId = 4
                MiPropertyFeature.DecimalValue = 7
                Inmueble.PropertyFeature.Add(MiPropertyFeature)
            End If
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 3 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 5 Or Inmueble.TypeId = 7 Or Inmueble.TypeId = 8 Or Inmueble.TypeId = 10 Or Inmueble.TypeId = 12 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 231
            MiPropertyFeature.LanguageId = 4
            MiPropertyFeature.DecimalValue = dgvx.ColumnaCheck.GetSelectedRow(i)("AnoConstruccion")

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 3 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 5 Or Inmueble.TypeId = 7 Or Inmueble.TypeId = 10 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 249
            MiPropertyFeature.LanguageId = 4
            Select Case dgvx.ColumnaCheck.GetSelectedRow(i)("Estado")
                Case "NUEVO"
                    MiPropertyFeature.DecimalValue = 3
                Case "SEMINUEVO"
                    MiPropertyFeature.DecimalValue = 2
                Case "REFORMADO"
                    MiPropertyFeature.DecimalValue = 1
                Case "SEMIREFORMADO"
                    MiPropertyFeature.DecimalValue = 4
                Case "ORIGEN", "PARA REFORMAR", "PARA DERRIVAR", "PARA DERRIBAR", "DIAFANO"
                    MiPropertyFeature.DecimalValue = 5

                Case Else
                    MiPropertyFeature.DecimalValue = 1
            End Select

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 3 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 5 Or Inmueble.TypeId = 7 Or Inmueble.TypeId = 8 Or Inmueble.TypeId = 10 Or Inmueble.TypeId = 12 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 254
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(dgvx.ColumnaCheck.GetSelectedRow(i)("AireAcondicionado")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = dgvx.ColumnaCheck.GetSelectedRow(i)("AireAcondicionado")
            End If

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If


        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 259
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(dgvx.ColumnaCheck.GetSelectedRow(i)("Electrodomesticos")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = dgvx.ColumnaCheck.GetSelectedRow(i)("Electrodomesticos")
            End If

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 263
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(dgvx.ColumnaCheck.GetSelectedRow(i)("Patio")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = dgvx.ColumnaCheck.GetSelectedRow(i)("Patio")
            End If

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 3 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 263
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(dgvx.ColumnaCheck.GetSelectedRow(i)("Calefaccion")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = dgvx.ColumnaCheck.GetSelectedRow(i)("Calefaccion")
            End If

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 284
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(dgvx.ColumnaCheck.GetSelectedRow(i)("PrimeraLineaPlaya")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = dgvx.ColumnaCheck.GetSelectedRow(i)("PrimeraLineaPlaya")
            End If

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 285
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(dgvx.ColumnaCheck.GetSelectedRow(i)("Montana")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = dgvx.ColumnaCheck.GetSelectedRow(i)("Montana")
            End If

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 289
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(dgvx.ColumnaCheck.GetSelectedRow(i)("CocinaOffice")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = dgvx.ColumnaCheck.GetSelectedRow(i)("CocinaOffice")
            End If

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 10 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 296
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(dgvx.ColumnaCheck.GetSelectedRow(i)("Calefaccion")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = dgvx.ColumnaCheck.GetSelectedRow(i)("Calefaccion")
            End If

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 297
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(dgvx.ColumnaCheck.GetSelectedRow(i)("Balcon")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = dgvx.ColumnaCheck.GetSelectedRow(i)("Balcon")
            End If

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 315
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(dgvx.ColumnaCheck.GetSelectedRow(i)("VistasAlMar")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = dgvx.ColumnaCheck.GetSelectedRow(i)("VistasAlMar")
            End If

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 3 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 5 Or Inmueble.TypeId = 7 Or Inmueble.TypeId = 10 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 317
            MiPropertyFeature.LanguageId = 4

            Select Case dgvx.ColumnaCheck.GetSelectedRow(i)("CalificacionEnergetica")
                Case "A"
                    MiPropertyFeature.DecimalValue = 1
                Case "B"
                    MiPropertyFeature.DecimalValue = 2
                Case "C"
                    MiPropertyFeature.DecimalValue = 3
                Case "D"
                    MiPropertyFeature.DecimalValue = 4
                Case "E"
                    MiPropertyFeature.DecimalValue = 5
                Case "F"
                    MiPropertyFeature.DecimalValue = 6
                Case "G"
                    MiPropertyFeature.DecimalValue = 7

                Case Else
                    MiPropertyFeature.DecimalValue = 8
            End Select

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If


        '******* PropertyContactInfo
        Sel = "SELECT Email FROM Empresas WHERE Codigo = " & DatosEmpresa.Codigo
        Dim Email As String = BD_CERO.Execute(Sel, False, "")

        If Email <> "" AndAlso IsNothing(Inmueble.PropertyContactInfo) Then
            Inmueble.PropertyContactInfo = New List(Of PropertyContactInfo)
        End If

        If Email <> "" Then
            Dim MiPropertyContactInfo = New PropertyContactInfo

            MiPropertyContactInfo.TypeId = 1 'Email
            MiPropertyContactInfo.Value = Email
            MiPropertyContactInfo.ValueTypeId = 1

            Inmueble.PropertyContactInfo.Add(MiPropertyContactInfo)
        End If


        Sel = "SELECT Telefono1 FROM Empresas WHERE Codigo = " & DatosEmpresa.Codigo
        Dim Telefono As String = BD_CERO.Execute(Sel, False, "")

        If Telefono <> "" AndAlso IsNothing(Inmueble.PropertyContactInfo) Then
            Inmueble.PropertyContactInfo = New List(Of PropertyContactInfo)
        End If

        If Telefono <> "" Then
            Dim MiPropertyContactInfo = New PropertyContactInfo

            MiPropertyContactInfo.TypeId = 2 'Telefono
            MiPropertyContactInfo.Value = Telefono
            MiPropertyContactInfo.ValueTypeId = 1

            Inmueble.PropertyContactInfo.Add(MiPropertyContactInfo)
        End If


        '******* PropertyContactInfo
        Inmueble.PropertyPublications = New List(Of PropertyPublication)

        Dim MiPropertyPublications = New PropertyPublication

        MiPropertyPublications.PublicationId = 1 'FotoCasa
        MiPropertyPublications.PublicationTypeId = 1 'Web Propia

        Inmueble.PropertyPublications.Add(MiPropertyPublications)


        '******* PropertyContactInfo
        Inmueble.PropertyTransaction = New List(Of PropertyTransaction)

        Dim MiPropertyTransaction = New PropertyTransaction

        MiPropertyTransaction.TransactionTypeId = IdTipoVenta

        Select Case MiPropertyTransaction.TransactionTypeId
            Case 3
                MiPropertyTransaction.PaymentPeriodicityId = 3

            Case 8
                MiPropertyTransaction.PaymentPeriodicityId = 4

        End Select



        MiPropertyTransaction.Price = dgvx.ColumnaCheck.GetSelectedRow(i)("Precio")
        If dgvx.ColumnaCheck.GetSelectedRow(i)("Metros") <> 0 Then
            MiPropertyTransaction.PriceM2 = dgvx.ColumnaCheck.GetSelectedRow(i)("Precio") / dgvx.ColumnaCheck.GetSelectedRow(i)("Metros")
        Else
            MiPropertyTransaction.PriceM2 = dgvx.ColumnaCheck.GetSelectedRow(i)("Precio")
        End If

        MiPropertyTransaction.CurrencyId = 1

        MiPropertyTransaction.ShowPrice = True



        Inmueble.PropertyTransaction.Add(MiPropertyTransaction)



        '******* PropertyDocument
        Inmueble.PropertyDocument = New List(Of PropertyDocument)


        If DatosEmpresa.WordPress Then

            Sel = "SELECT SourceUrl FROM WP_FOTOS WHERE ContadorInmueble = " & dgvx.ColumnaCheck.GetSelectedRow(i)("Contador")
            Dim bdFotos As New BaseDatos
            bdFotos.LlenarDataSet(Sel, "T")

            For i = 0 To bdFotos.ds.Tables("T").Rows.Count - 1

                Dim PropertyDocument = New PropertyDocument
                PropertyDocument.TypeId = 1
                PropertyDocument.description = ""

                PropertyDocument.Url = bdFotos.ds.Tables("T").Rows(i)("SourceUrl")

                PropertyDocument.RoomTypeId = 0
                PropertyDocument.FileTypeId = 2
                PropertyDocument.Visible = True
                PropertyDocument.SortingId = i

                Inmueble.PropertyDocument.Add(PropertyDocument)




            Next


        Else
            Dim ftp As New tb_FTP
            Dim DirFiles As List(Of String) = ftp.FTPArchivosCarpeta(GL_ConfiguracionWeb.DirectorioFotos & "/" & Referencia)
            If Not IsNothing(DirFiles) AndAlso DirFiles.Count > 0 Then
                For i = 0 To DirFiles.Count - 1
                    Try
                        Dim PropertyDocument = New PropertyDocument
                        PropertyDocument.TypeId = 1
                        PropertyDocument.description = ""
                        If GL_ConfiguracionWeb.web3B Then
                            PropertyDocument.Url = "http://venalia.net" & GL_ConfiguracionWeb.DirectorioFotos & "/" & Referencia & "/" & DirFiles(i)
                        Else
                            PropertyDocument.Url = GL_ConfiguracionWeb.WebConHHTP & Replace(GL_ConfiguracionWeb.DirectorioFotos, "/httpdocs", "") & "/" & Referencia & "/" & DirFiles(i)
                        End If

                        PropertyDocument.RoomTypeId = 0
                        PropertyDocument.FileTypeId = 2
                        PropertyDocument.Visible = True
                        PropertyDocument.SortingId = i

                        Inmueble.PropertyDocument.Add(PropertyDocument)
                    Catch
                    End Try
                Next
            End If
        End If



        Return Inmueble
    End Function
    Private Sub btnDespublicar_Click(sender As System.Object, e As System.EventArgs) Handles btnDespublicar.Click
        If Gv.RowCount = 0 OrElse (Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle And dgvx.ColumnaCheck.SelectedCount = 0) Then Return
        If dgvx.ColumnaCheck.SelectedCount = 0 Then
            dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, True)
        End If


        Dim ListaErrores As New List(Of String)

        If MsgBox("¿Estas seguro de querer despublicar de " & Portal & IIf(dgvx.ColumnaCheck.SelectedCount = 1, " el ", " los " & dgvx.ColumnaCheck.SelectedCount) & IIf(dgvx.ColumnaCheck.SelectedCount = 1, " inmueble seleccionado", " inmuebles seleccionados") & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Return


        Dim CodigoAPI As String
        Dim Sel As String = ""

        Sel = "SELECT Codigo FROM ClientePortales WHERE Portal = 'FotoCasa' and CodigoEmpresa = " & DatosEmpresa.Codigo
        CodigoAPI = BD_CERO.Execute(Sel, False, "")

        If CodigoAPI = "" Then
            MensajeError("No puede publicar en FotoCasa porque no tiene código API de acceso")
            Return
        End If

        Gv.ClearColumnsFilter()



        Dim pf As New ProgressForm(dgvx.ColumnaCheck.SelectedCount, "Despublicando Inmuebles en " & Portal & "...")
        Application.DoEvents()

        For i As Integer = 0 To dgvx.ColumnaCheck.SelectedCount - 1

            Select Case Portal.ToUpper
                Case "FOTOCASA"

                    'Sel = "UPDATE Inmuebles SET PortalFotoCasa = 0 WHERE Referencia = '" & Funciones.pf_ReplaceComillas(dgvx.ColumnaCheck.GetSelectedRow(i)("Referencia")) & "'  and CodigoEmpresa = " & DatosEmpresa.Codigo
                    'BD_CERO.Execute(Sel)


                    Dim Res As clResultado = DespublicarFotocasa(dgvx.ColumnaCheck.GetSelectedRow(i)("Referencia"), CodigoAPI, "DESPUBLICAR")
                    If Res.StatusCode <> 0 Then
                        ListaErrores.Add("Referencia: " & dgvx.ColumnaCheck.GetSelectedRow(i)("Referencia") & ". " & Res.Message)
                    End If

                Case Else
                    Sel = "UPDATE Inmuebles SET Portal" & Portal & " = 0 WHERE Contador = " & dgvx.ColumnaCheck.GetSelectedRow(i)("Contador") & " AND CodigoEmpresa=" & DatosEmpresa.Codigo
                    BD_CERO.Execute(Sel)
            End Select

            pf.nuevoPaso()
            Application.DoEvents()

        Next
        dgvx.ColumnaCheck.ClearSelection()


        pf.Close()

        LlenarGrid()

        'For i = 0 To Gv.RowCount - 1
        '    If Gv.GetDataRow(i)(DeDondeVengo.Replace("|", "")) Then dgvx.ColumnaCheck.SelectRow(i, True)
        'Next


        'GuardarSeleccion()

        ' ActualizarPortales(Portal) '.ToUpper

        If ListaErrores.Count > 0 Then
            Dim ds As New DataSet
            Dim dt2 As New DataTable("Listado")
            ds.Tables.Add(dt2)
            Dim dc1 As New DataColumn("Texto")
            dt2.Columns.Add(dc1)

            For Each EanNoVal As String In ListaErrores
                Dim dr As DataRow = dt2.NewRow
                dr("Texto") = EanNoVal.Trim
                dt2.Rows.Add(dr)
            Next


            ' dt2.WriteXml(My.Application.Info.DirectoryPath & "\EsquemasXML\rptListado.xml")
            'pr_InformeCrystal2008(clVariables.RutaServidor & "\Listados\rptListado.rpt", dt2, , , , "NIF's que no se han podido publicar.")

            Dim r As New rptListado

            r.DataSource = dt2
            r.DataMember = "Listado"
            r.par_Titulo.Value = "Listado de referencias que no se han podido despublicar. Fecha: " & Microsoft.VisualBasic.Format(Now, "dd/MM/yyyy HH:mm:ss")
            r.PageHeader.Visible = False
            r.par_Titulo.Visible = False
            r.ShowPreview()
        End If



    End Sub

    Private Function FotocasaObtenerPortalesAsociados(CodigoAPI As String) As List(Of clPortalesFotoCasa)

        Dim Res As New clResultado
        Dim Portales As New List(Of clPortalesFotoCasa)

        Try

            ''Para superseguridad. SOLO con Framework 4.5
            ''System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls

            'Dim client = New RestClient(GL_wsRutaWs & "property/" & Referencia & "/publication/1")
            Dim client = New RestClient(GL_wsRutaWs & "publication")
            Dim request = New RestRequest(Method.GET)

            request.AddHeader("Inmofactory-Api-Key", CodigoAPI)
            request.AddHeader("Cache-Control", "no-cache")
            request.AddHeader("content-type", "application/json")

            Dim response As IRestResponse = client.Execute(request)

            If response.StatusDescription = "OK" Then
                Portales = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of clPortalesFotoCasa))(response.Content)
                Res.StatusCode = 0
                Res.Code = ""


            Else
                Res = Newtonsoft.Json.JsonConvert.DeserializeObject(Of clResultado)(response.Content)
                Res.Code = response.StatusDescription
            End If



        Catch ex4 As FaultException(Of clResultado)
            Res.StatusCode = ex4.Code.ToString
            Res.Message = ex4.Reason.ToString

        Catch ex5 As Net.WebException
            Res.StatusCode = GL_CodigoErrorWebService
            Res.Message = ex5.Message

        Catch ex As Exception
            Res.StatusCode = GL_CodigoErrorWebService
            Res.Message = ex.Message
        End Try

        Return Portales


    End Function
    'Private Function DespublicarFotocasa(Referencia As String, CodigoAPI As String) As clResultado

    '    Dim Res As New clResultado



    '    Try
    '        Dim Portales As List(Of clPortalesFotoCasa)
    '        Portales = FotocasaObtenerPortalesAsociados(CodigoAPI)
    '        ''Para superseguridad. SOLO con Framework 4.5
    '        ''System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls

    '        'Dim client = New RestClient(GL_wsRutaWs & "property/" & Referencia & "/publication/1")

    '        For i = 0 To Portales.Count - 1
    '            Dim client = New RestClient(GL_wsRutaWs & "property/" & Referencia & "/publication/" & Portales(i).PublicationId)
    '            Dim request = New RestRequest(Method.[DELETE])

    '            request.AddHeader("Inmofactory-Api-Key", CodigoAPI)
    '            request.AddHeader("Cache-Control", "no-cache")
    '            request.AddHeader("content-type", "application/json")

    '            Dim response As IRestResponse = client.Execute(request)

    '            If response.StatusDescription = "OK" Then
    '                Res.Message = response.Content
    '                Res.StatusCode = 0
    '                Res.Code = ""
    '            Else
    '                Res = Newtonsoft.Json.JsonConvert.DeserializeObject(Of clResultado)(response.Content)
    '                Res.Code = response.StatusDescription
    '            End If
    '        Next




    '    Catch ex4 As FaultException(Of clResultado)
    '        Res.StatusCode = ex4.Code.ToString
    '        Res.Message = ex4.Reason.ToString

    '    Catch ex5 As Net.WebException
    '        Res.StatusCode = GL_CodigoErrorWebService
    '        Res.Message = ex5.Message

    '    Catch ex As Exception
    '        Res.StatusCode = GL_CodigoErrorWebService
    '        Res.Message = ex.Message
    '    End Try

    '    Return Res


    'End Function


    Private Sub btnCreaJsonFotocasa_Click(sender As System.Object, e As System.EventArgs) Handles btnCreaJsonFotocasa.Click

        If Portal.ToUpper <> "FOTOCASA" Then
            MensajeInformacion("Solo válido para FotoCasa")
            Return
        End If



        If Gv.RowCount = 0 OrElse (Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle And dgvx.ColumnaCheck.SelectedCount = 0) Then Return
        If dgvx.ColumnaCheck.SelectedCount = 0 Then
            dgvx.ColumnaCheck.ClearSelection()
            dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, True)
        End If

        For i As Integer = 0 To dgvx.ColumnaCheck.SelectedCount - 1
            Dim Locati As location


            If dgvx.ColumnaCheck.GetSelectedRow(i)("Metros") = 0 Then
                MensajeInformacion("No se puede generar el json porque no tiene metros")
                dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, False)
                Return
            End If

            If dgvx.ColumnaCheck.GetSelectedRow(i)("Precio") = 0 Then
                MensajeInformacion("No se puede generar el json porque no tiene Precio")
                dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, False)
                Return
            End If

            If dgvx.ColumnaCheck.GetSelectedRow(i)("CodPostal").ToString.Trim = "" Then
                MensajeInformacion("No se puede generar el json porque no tiene Código Postal")
                dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, False)
                Return
            End If

            Try

                Dim Direccion As String = ""
                Direccion = dgvx.ColumnaCheck.GetSelectedRow(i)("Provincia") & "+" & dgvx.ColumnaCheck.GetSelectedRow(i)("Poblacion") & "+" & dgvx.ColumnaCheck.GetSelectedRow(i)("CodPostal") & "+" & dgvx.ColumnaCheck.GetSelectedRow(i)("DireccionMapa") ' & "+" & dgvx.ColumnaCheck.GetSelectedRow(i)("Numero")

                Locati = ObtenerLocation(Direccion)



            Catch ex As Exception
                MensajeInformacion("Error al obtener la latitud y la longitud " & ex.Message)
                Return
            End Try

            If Locati.lat = 0 AndAlso Locati.lng = 0 Then

                MensajeInformacion("Error al obtener la latitud y la longitud. No se pudo obtener localizar el inmueble con la dirección actual")
                Return
            End If


            Dim Inmueble As Objetos.Inmuebles = PrepararJsonInmueble(i, Locati)
            Dim postData As String = SerializarPost(Inmueble)


            Dim Ruta As String
            Dim Aleatorio As String = Microsoft.VisualBasic.Format(Now, "yyyyMMddHHmmssfff")

            Ruta = clVariables.RutaServidor & "\Notepad"
            FuncionesGenerales.Funciones.ComprobarYCrearCarpetas(Ruta)

            Ruta = Ruta & "\" & Aleatorio & ".txt"
            Dim sw As New System.IO.StreamWriter(Ruta, True)
            sw.WriteLine(postData)
            sw.Close()

            Dim p As New Process
            p.Start(Ruta)


        Next


        dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, False)


    End Sub
    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click

        If Portal.ToUpper <> "FOTOCASA" Then
            GuardarSeleccion()
        End If

    End Sub
    Private Sub btnExportarExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportarExcel.Click
        Try

            Dim f As New tbImputBox("Introduzca la contraseña para exportar datos")
            f.ShowDialog()
            Dim Pass As String
            Pass = Gl_ResultadoBusqueda

            If Pass <> "LMML77" Then
                MensajeInformacion("La contraseña no es correcta")
                Exit Sub
            End If

            Dim Ruta As String = ""
            Dim FBD As New FolderBrowserDialog

            Dim ofd As New SaveFileDialog
            Dim Fichero As String

            'ofd.Filter = "Archivos de Word(*.doc;*.docx)|*.doc;*.docx"

            'ofd.Filter = "Archivos doc |*.doc|docx|*.docx"

            'ofd.Filter = "Archivos |*.xlsx|Todos|*.*"
            ofd.Filter = "Archivos |*.xls|Todos|*.*" 'SI LO QUIERE EN .XLS
            ofd.Title = "Seleccione un fichero"

            If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then

                Dim g As New GridView
                g = dgvx.MainView

                Fichero = ofd.FileName

                'g.ExportToXlsx(Fichero)
                g.ExportToXls(Fichero) 'SI LO QUIERE EN .XLS

                Dim p As New Process
                p.Start(Fichero)
            Else
                MessageBox.Show("No se guardó el documento", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Private Sub GuardarSeleccion()
        Gv.ClearColumnsFilter()

        'actualizar los inmuebles pendientes de publicar del portal actual en la BD

        BD_CERO.Execute("UPDATE Inmuebles SET Portal" & Portal & " = 0 WHERE CodigoEmpresa =" & DatosEmpresa.Codigo)
        For i As Integer = 0 To dgvx.ColumnaCheck.SelectedCount - 1
            BD_CERO.Execute("UPDATE Inmuebles SET Portal" & Portal & " = " & GL_SQL_VALOR_1 & " WHERE Contador = " & dgvx.ColumnaCheck.GetSelectedRow(i)("Contador") & " AND CodigoEmpresa=" & DatosEmpresa.Codigo)
        Next
        dgvx.ColumnaCheck.ClearSelection()

        LlenarGrid()

        For i = 0 To Gv.RowCount - 1
            If Gv.GetDataRow(i)(DeDondeVengo.Replace("|", "")) Then dgvx.ColumnaCheck.SelectRow(i, True)
        Next
    End Sub

    Public Sub MostrarColoresInmueble()

        Dim texto As String = "."

        Dim a As DataRowView = Gv.GetFocusedRow
        With Gv.Appearance.FocusedRow
            Try
                If a.Item("Reservado") Then
                    texto &= "." & "RESERVADO"
                End If
                If a.Item("Baja") Then
                    texto &= "." & "BAJA"
                End If
                If a.Item("Ocultar") Then
                    texto &= "." & "OCULTO"
                End If
                If a.Item("Visitado") Then
                    texto &= "." & "VISITA"
                End If
                If a.Item("PendienteWeb") Then
                    texto &= "." & "PENDIENTE ACTUALIZAR"
                End If
                If a.Item("MostrarPPrincipalWeb") Then
                    texto &= "." & "PANTALLA PRINCIPAL"
                End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End With

        texto &= "."

        Dim col As New frmColoresGrid(texto)
        col.ShowDialog()

    End Sub
    Public Sub MostrarPPrincipalWeb()
        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Return
        End If
        chkMostrarPPrincipalWeb.Checked = Not chkMostrarPPrincipalWeb.Checked
        Me.Validate()
        If Not DatosEmpresa.WordPress AndAlso (chkMostrarPPrincipalWeb.Checked AndAlso BD_CERO.Execute("SELECT COUNT(*) FROM Inmuebles WHERE MostrarPPrincipalWeb <> 0", False) >= 12) Then
            XtraMessageBox.Show("No se pueden marcar más de 12 inmuebles para mostrar en la pantalla principal de la web", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            chkMostrarPPrincipalWeb.Checked = Not chkMostrarPPrincipalWeb.Checked
            bd.RefrescarDatos(BinSrc.Position)
            Me.Validate()
            Exit Sub
        Else
            If DatosEmpresa.WordPress AndAlso chkMostrarPPrincipalWeb.Checked AndAlso BinSrc.Current("ID_WP") = 0 Then
                XtraMessageBox.Show("Este inmueble no se encuentra en la web", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                chkMostrarPPrincipalWeb.Checked = Not chkMostrarPPrincipalWeb.Checked
                bd.RefrescarDatos(BinSrc.Position)
                Me.Validate()
                Exit Sub
            End If

            If chkMostrarPPrincipalWeb.Checked AndAlso (BinSrc.Current("Reservado") = True OrElse BinSrc.Current("Baja") = True) Then
                XtraMessageBox.Show("No se pueden mostrar inmuebles dados de baja o reservados", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                chkMostrarPPrincipalWeb.Checked = Not chkMostrarPPrincipalWeb.Checked
                bd.RefrescarDatos(BinSrc.Position)
                Me.Validate()
                Exit Sub
            End If
            BinSrc.EndEdit()
            If Not ActualizarBaseDatos() Then
                chkMostrarPPrincipalWeb.Checked = Not chkMostrarPPrincipalWeb.Checked
                bd.RefrescarDatos(BinSrc.Position)
                Me.Validate()
                BinSrc.EndEdit()
                Exit Sub
            End If
            'WP_CambiarMostrarPantallaPrincipal
            If DatosEmpresa.WordPress Then
                WP_CambiarMostrarPantallaPrincipal(BinSrc.Current("Referencia"), chkMostrarPPrincipalWeb.Checked, BinSrc.Current("ID_WP"))
            Else
                FuncionesBD.Accion("UPDATE", "Inmuebles", txtReferencia.EditValue)
            End If

            bd.RefrescarDatos()
            'mostrarAlertaPortales()
            HacerCambioFila()
        End If
    End Sub

    Private Sub ucInmuebles_Enter(sender As System.Object, e As System.EventArgs) Handles MyBase.Enter
        mostrarAlertaPortales()
    End Sub
    Private Sub mostrarAlertaPortales()
        If GL_PortalesDesactualizados Then
            DefaultToolTipController1.SetToolTip(PanelControl3, "Portales pendientes de actualizar")
            btnActualizarPortales.Visible = True
        Else
            DefaultToolTipController1.SetToolTip(PanelControl3, "")
            btnActualizarPortales.Visible = False
        End If
    End Sub

    Private Sub btnActualizarPortales_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizarPortales.Click
        ActualizarPortales()
    End Sub

    Private Sub btnFocus_Click(sender As System.Object, e As System.EventArgs) Handles btnFocus.Click
        If btnFocus.Appearance.BackColor <> Color.Red Then
            btnFocus.Appearance.BackColor = Color.Red
            mostrarFocus = False
        Else
            btnFocus.Appearance.BackColor = btnDirecciones.Appearance.BackColor
            mostrarFocus = True
        End If
    End Sub

    Private Sub ActualizarPortales(Optional Portalpasado As String = "")
        For Each p In GL_PortalesCreados
            If (Portalpasado = "" OrElse Portalpasado = p) AndAlso
                 frmPrincipal.ribbonControl.Items("I" & p).Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
                Portal = p
                CallByName(Me, "Publicar" & p, CallType.Method)
            End If
        Next
        'If (Portalpasado = "" OrElse Portalpasado = "YAENCONTRE") AndAlso frmPrincipal.IYaEncontre.Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
        '    Portal = "YaEncontre"
        '    PublicarYaEncontre()
        'End If
        'If (Portalpasado = "" OrElse Portalpasado = "FOTOCASA") AndAlso frmPrincipal.IFotoCasa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
        '    Portal = "FotoCasa"
        '    PublicarFotoCasa()
        'End If
        'If (Portalpasado = "" OrElse Portalpasado = "IDEALISTA") AndAlso frmPrincipal.IIdealista.Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
        '    Portal = "Idealista"
        '    PublicarIdealista()
        'End If
        'If (Portalpasado = "" OrElse Portalpasado = "HOGARIA") AndAlso frmPrincipal.IHogaria.Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
        '    Portal = "Hogaria"
        '    PublicarHogaria()
        'End If
        'If (Portalpasado = "" OrElse Portalpasado = "TUCASA") AndAlso frmPrincipal.ITuCasa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
        '    Portal = "TuCasa"
        '    PublicarTuCasa()
        'End If

        VerificarPortalesActualizados()
    End Sub
    Private Sub VerificarPortalesActualizados()
        If BD_CERO.Execute("SELECT COUNT(PendientePublicar) FROM ClientePortales WHERE PendientePublicar" & GL_SQL_DIS & "0 AND Activo" & GL_SQL_DIS & "0 AND CodigoEmpresa=" & DatosEmpresa.Codigo, False) > 0 Then
            GL_PortalesDesactualizados = True
            'mostrarAlertaPortales()
        Else
            GL_PortalesDesactualizados = False
        End If
        mostrarAlertaPortales()
    End Sub
    Public Sub PublicarHogaria()
        PublicarYaEncontre() ' de momento utiliza el generador de YaEncontre asi como sus poblaciones, se tendria que crear una tabla poblacionesHogaria asi como un campo contadorHogaria en Poblacion
    End Sub
    Public Sub PublicarTuCasa()
        PublicarIdealista() ' de momento utiliza el generador de Idealista asi como sus poblaciones, se tendria que crear una tabla poblacionesHogaria asi como un campo contadorHogaria en Poblacion
    End Sub
    Public Sub PublicarYaEncontre()
        Dim pf As New ProgressForm(BD_CERO.Execute("SELECT count(*) FROM Inmuebles WHERE Portal" & Portal & " " & GL_SQL_DIS & "0 AND CodigoEmpresa =" & DatosEmpresa.Codigo, False) + 3, "Cargando publicación ...")
        Application.DoEvents()
        Dim codigo As String = BD_CERO.Execute("SELECT Codigo FROM ClientePortales WHERE Portal='" & Portal & "' AND CodigoEmpresa=" & DatosEmpresa.Codigo, False)
        Dim ficheroDestinoXml As String = clVariables.RutaServidor & "\" & codigo & ".xml"

        If File.Exists(ficheroDestinoXml) Then
            Try
                File.Delete(ficheroDestinoXml)
            Catch ex As Exception
            End Try
        End If
        Dim myXml As XmlTextWriter = New XmlTextWriter(ficheroDestinoXml, System.Text.Encoding.UTF8)
        With myXml


            .Formatting = System.Xml.Formatting.Indented
            .WriteStartDocument()
            '.WriteComment("Esto es un comentario")'añadir comentarios

            .WriteStartElement("publicacion") 'crear elemento
            .WriteAttributeString("oficina", codigo) 'añadir atributos a un elemento

            .WriteStartElement("referencias")

            Dim dtr As Object
            Dim bdPublicar As New BaseDatos

            dtr = bdPublicar.ExecuteReader("SELECT * FROM Inmuebles WHERE Portal" & Portal & " " & GL_SQL_DIS & "0 AND CodigoEmpresa =" & DatosEmpresa.Codigo)

            pf.nuevoPaso("Generando publicación ...")
            Application.DoEvents()
            Try

                If dtr.hasrows Then
                    While dtr.read

                        'If dtr("Referencia") = "950" Then
                        '    XtraMessageBox.Show("Ojo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        'End If
                        .WriteStartElement("referencia") 'inicio de referencia
                        .WriteAttributeString("id", dtr("Referencia"))
                        .WriteAttributeString("timestamp", Funciones.ReplacePuntos((DateTime.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds)) 'UNIX timestamp

                        .WriteStartElement("operacion")
                        Dim tipoventa As String = BD_CERO.Execute("SELECT TipoVenta FROM TipoVentaPortales WHERE Contador=(SELECT Contador" & Portal & " FROM TipoVenta WHERE CodigoEmpresa=" & DatosEmpresa.Codigo & " AND TipoVenta='" & dtr("TipoVenta") & "')", False)
                        If IsNothing(tipoventa) OrElse Not tipoventa.Contains("|") Then
                            XtraMessageBox.Show("Error al publicar el inmueble " & dtr("Referencia") & ", la oferta " & dtr("TipoVenta") & " NO esta asignada" & vbCrLf & "Se cancela la publicación completa de " & Portal, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            .Flush()
                            .Close()
                            bdPublicar.CerrarBD()
                            dtr.close()
                            pf.Close()
                            Return
                        End If

                        .WriteAttributeString("id", tipoventa.Split("|")(0))
                        .WriteString(tipoventa.Split("|")(1))

                        .WriteEndElement()

                        .WriteStartElement("tipo")
                        Dim tipo As String = BD_CERO.Execute("SELECT Tipo FROM TipoPortales WHERE Contador=(SELECT Contador" & Portal & " FROM Tipo WHERE CodigoEmpresa=" & DatosEmpresa.Codigo & " AND Tipo='" & dtr("Tipo") & "')", False)
                        If IsNothing(tipo) OrElse Not tipo.Contains("|") Then
                            XtraMessageBox.Show("Error al publicar el inmueble " & dtr("Referencia") & ", el tipo " & dtr("Tipo") & " NO esta asignado" & vbCrLf & "Se cancela la publicación completa de " & Portal, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            .Flush()
                            .Close()
                            bdPublicar.CerrarBD()
                            dtr.close()
                            pf.Close()
                            Return
                        End If
                        .WriteAttributeString("id", tipo.Split("|")(0))
                        .WriteString(tipo.Split("|")(1))

                        .WriteEndElement()

                        .WriteStartElement("ubicacion") 'inicio de ubicacion

                        .WriteElementString("pais", "ES")

                        .WriteStartElement("provincia") '<provincia id="08"><![CDATA[Barcelona]]></provincia>
                        Dim provincia As String = BD_CERO.Execute("SELECT provincia " & GL_SQL_SUMA & " '|' " & GL_SQL_SUMA & " " & Funciones.SQL_CONVERT("VARCHAR", "contador") & " FROM provincias WHERE provincia=(SELECT distinct provincia from poblacion WHERE poblacion='" & Funciones.pf_ReplaceComillas(dtr("Poblacion")) & "' AND CodigoEmpresa =" & DatosEmpresa.Codigo & ")", False)
                        .WriteAttributeString("id", provincia.Split("|")(1).PadLeft(2, "0"))
                        .WriteCData(provincia.Split("|")(0))

                        .WriteEndElement()
                        Dim poblacion As String = BD_CERO.Execute("SELECT poblacion " & GL_SQL_SUMA & " '|' " & GL_SQL_SUMA & " " &
                                    Funciones.SQL_CASE_ISNULL(Funciones.SQL_CONVERT("VARCHAR", "contadorYaEncontre") & ",'0'") &
                                    " FROM poblacion WHERE poblacion='" & Funciones.pf_ReplaceComillas(dtr("Poblacion")) & "' AND CodigoEmpresa =" & DatosEmpresa.Codigo, False) 'Ojo en hogaria tambien usamos de momento las tablas de YaEncontre
                        .WriteStartElement("poblacion") '<poblacion id="374"><![CDATA[L'Hospitalet del Llobregat]]></poblacion>
                        If poblacion.Split("|")(1) > 0 Then
                            .WriteAttributeString("id", poblacion.Split("|")(1))
                        Else
                            CargarFormulario("ElegirPoblacionPortal", , , , Portal & "|" & poblacion)
                            Try
                                Dim contadorPoblacion As Integer = BD_CERO.Execute("SELECT contadorYaEncontre FROM poblacion WHERE poblacion='" & Funciones.pf_ReplaceComillas(dtr("Poblacion")) & "' AND CodigoEmpresa =" & DatosEmpresa.Codigo, False)
                                .WriteAttributeString("id", contadorPoblacion)
                            Catch ex As Exception
                                XtraMessageBox.Show("Se ha cancelado la publicación de " & Portal & " por:" & vbCrLf & ex.Message, "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                .Flush()
                                .Close()
                                bdPublicar.CerrarBD()
                                dtr.close()
                                pf.Close()
                                Return
                            End Try

                        End If

                        .WriteCData(poblacion.Split("|")(0))
                        .WriteEndElement()

                        '<zona id="252"><![CDATA[La Florida]]></zona>'NO OBLIGATORIO
                        '<zona_libre><![CDATA[Junto mercado]]></zona_libre>'NO OBLIGATORIO
                        .WriteElementString("cod_postal", dtr("CodPostal")) '<cod_postal>08904</cod_postal>'NO OBLIGATORIO
                        '<tipo_via id="2"><![CDATA[calle]]></tipo_via>'NO OBLIGATORIO
                        '<direccion><![CDATA[Teide]]></direccion>'NO OBLIGATORIO
                        '<direccion_num><![CDATA[12]]></direccion_num>'NO OBLIGATORIO
                        '<!-- Escalera, Bloque, Puerta, Piso.... -->
                        '<direccion_otra_info><![CDATA[1º2º Escalera A]]></direccion_otra_info>'NO OBLIGATORIO
                        '<!-- Indica privacidad del número de la direccion-->
                        '<direccion_privada>1</direccion_privada>'NO OBLIGATORIO
                        '<!-- Si la referencia esta geolocalizada indicar sus coordenadas geográficas expresadas en grados decimales -->
                        '<latitud>41.365826</latitud>'NO OBLIGATORIO
                        '<longitud>2.110491</longitud>'NO OBLIGATORIO

                        .WriteEndElement() ' fin de ubicacion

                        .WriteStartElement("precio") '<precio periodicidad="mensual">650.00</precio>'la periodicidad no obligatorio
                        '.WriteAttributeString("periodicidad", "mensual")
                        .WriteString(Funciones.ReplacePuntos(dtr("Precio")))
                        .WriteEndElement()
                        '<disponibilidad><![CDATA[a partir de mayo]]></disponibilidad>'NO OBLIGATORIO
                        '<num_reg_alquiler_turistico><![CDATA[HUTB-3255]]></num_reg_alquiler_turistico>'NO OBLIGATORIO
                        .WriteElementString("m2_construidos", Funciones.ReplacePuntos(dtr("Metros"))) '<m2_construidos>78.45</m2_construidos>'******* OJO SOLO TENEMOS UNOS METROS
                        .WriteElementString("m2_utiles", Funciones.ReplacePuntos(dtr("Metros"))) '<m2_utiles>65.00</m2_utiles>
                        .WriteElementString("habitaciones", Funciones.ReplacePuntos(dtr("Habitaciones"))) '<habitaciones dobles="1" sencillas="2">3</habitaciones>'NO OBLIGATORIO
                        .WriteElementString("banyos", Funciones.ReplacePuntos(dtr("Banos"))) '<banyos>1</banyos>'NO OBLIGATORIO
                        '<nuevo>1</nuevo><!-- Indica si el inmueble es nuevo a estrenar o obranueva -->'NO OBLIGATORIO
                        If dtr("CalificacionEnergetica") <> "" Then
                            .WriteElementString("certificacion_energetica", dtr("CalificacionEnergetica")) '<certificacion_energetica><![CDATA[b]]></certificacion_energetica>'NO OBLIGATORIO
                        End If
                        '<certificacion_energetica_etiqueta>'NO OBLIGATORIO
                        '<![CDATA[http://www.webdelcliente.com/etiquetas/PISO-399380-B.jpeg]]>
                        '</certificacion_energetica_etiqueta>
                        '<titulos>'NO OBLIGATORIO
                        '<titulo idioma="es"><![CDATA[Apartamento con cocina americana]]></titulo>'NO OBLIGATORIO
                        '</titulos>
                        .WriteStartElement("descripciones") 'inicio <descripciones>
                        .WriteStartElement("descripcion") '<descripcion idioma="es">
                        .WriteAttributeString("idioma", "es")
                        '****** VER QUE SE PONE
                        .WriteCData(ConsultasBaseDatos.ObtenerDescripcionInmueble2(dtr("Contador"), 0, False, False)) '.WriteCData(dtr("Extras"))'.WriteCData(dtr("Observaciones"))'****** VER QUE SE PONE
                        .WriteEndElement() '</descripcion>
                        .WriteEndElement() 'fin </descripciones>

                        '<!-- Lista de caracteristicas del inmueble, ver la documentación para más detalles -->
                        .WriteStartElement("caracteristicas") '<caracteristicas>'NO OBLIGATORIO
                        Dim Extras As String = ""

                        '        id	opcion	tipo	opciones combo	opcion Venalia	tipo venalia	opciones textcombo	que hacer
                        If Not IsDBNull(dtr("AccesoMinusvalidos")) AndAlso dtr("AccesoMinusvalidos") Then
                            myXml = extra(myXml, "acceso_discapacitados", Funciones.pf_ReplaceTrueFalse(dtr("AccesoMinusvalidos"))) '1	acceso_discapacitados	boolean		accesominusvalidos	boolean		ok
                        End If
                        If Not IsDBNull(dtr("AireAcondicionado")) AndAlso dtr("AireAcondicionado") Then
                            myXml = extra(myXml, "Aire_acondicionado", 2) '5 aire_acondicionado	combo	0 = splits,1 = bomba de calor,2 = otros,3 = preinstalación,4= instalación completa,5 = sistema de Air Zona)	aireacondicionado	boolean		poner 2=otros o añadir a otros_txt
                        End If
                        If Not IsDBNull(dtr("Amueblado")) AndAlso dtr("Amueblado") Then
                            myXml = extra(myXml, "amueblado", Funciones.pf_ReplaceTrueFalse(dtr("Amueblado"))) '11	amueblado	boolean		amueblado	boolean		ok
                        End If
                        If Not IsDBNull(dtr("Ascensor")) AndAlso dtr("Ascensor") Then
                            myXml = extra(myXml, "ascensor", Funciones.pf_ReplaceTrueFalse(dtr("Ascensor"))) '15	ascensor	boolean		ascensor	boolean		ok
                        End If
                        If Not IsDBNull(dtr("Balcon")) AndAlso dtr("Balcon") Then
                            myXml = extra(myXml, "balcon", Funciones.pf_ReplaceTrueFalse(dtr("Balcon"))) '19	balcon	boolean		balcon	boolean		ok
                        End If
                        If Not IsDBNull(dtr("Calefaccion")) AndAlso dtr("Calefaccion") Then
                            myXml = extra(myXml, "calefaccion", Funciones.pf_ReplaceTrueFalse(dtr("Calefaccion"))) '23	calefaccion	boolean		calefaccion	boolean		ok
                        End If
                        If Not IsDBNull(dtr("Jardin")) AndAlso dtr("Jardin") Then
                            myXml = extra(myXml, "jardin", Funciones.pf_ReplaceTrueFalse(dtr("Jardin"))) '57	jardin	boolean		jardin	boolean		ok
                        End If
                        If Not IsDBNull(dtr("Terraza")) AndAlso dtr("Terraza") Then
                            myXml = extra(myXml, "terraza", Funciones.pf_ReplaceTrueFalse(dtr("Terraza"))) '111	terraza	boolean		terraza	boolean		ok
                            If dtr("MTerraza") Then
                                myXml = extra(myXml, "m2_terraza_principal", Funciones.ReplacePuntos(dtr("MTerraza"))) '65	m2_terraza_principal	decimal		mterraza	int		ok
                            End If
                        End If

                        If dtr("Estado") <> "" Then
                            '43	estado	combo	(0  =  nuevo,  1  = buen   estado,  2  =  por reformar)	estado	textcombo	editables	si coincide ok sino añadir a otros_txt
                            Select Case dtr("Estado").ToString.ToUpper
                                Case "NUEVO"
                                    myXml = extra(myXml, "estado", 0)
                                Case "SEMINUEVO"
                                    myXml = extra(myXml, "estado", 1)
                                Case "PARA REFORMAR"
                                    myXml = extra(myXml, "estado", 2)
                                Case Else
                                    If Extras <> "" Then Extras &= ", "
                                    Extras &= "Estado: " & dtr("Estado").ToString.ToUpper
                            End Select
                        End If
                        If dtr("Orientacion") <> "" Then
                            '74	orientacion_txt	combo	(0 = Norte, 1 = NorEste,   2    =    Este,     3    = SurEste,  4  =  Sur,  5  = SurOeste, 6 = Oeste, 7 = NorOeste, 8 = mar,  9 = Montaña)	orientacion	textcombo	16 orientaciones	combinar las 16 con las 8
                            Select Case dtr("Orientacion").ToString.ToUpper
                                Case "NORTE"
                                    myXml = extra(myXml, "orientacion_txt", 0)
                                Case "ESTE-NORTE"
                                    myXml = extra(myXml, "orientacion_txt", 1)
                                Case "ESTE"
                                    myXml = extra(myXml, "orientacion_txt", 2)
                                Case "ESTE-SUR"
                                    myXml = extra(myXml, "orientacion_txt", 3)
                                Case "SUR"
                                    myXml = extra(myXml, "orientacion_txt", 4)
                                Case "SUR-OESTE"
                                    myXml = extra(myXml, "orientacion_txt", 5)
                                Case "OESTE"
                                    myXml = extra(myXml, "orientacion_txt", 6)
                                Case "NORTE-OESTE"
                                    myXml = extra(myXml, "orientacion_txt", 7)
                                Case Else
                                    If Extras <> "" Then Extras &= ", "
                                    Extras &= "Orientación: " & dtr("Orientacion").ToString.ToUpper
                            End Select
                        End If
                        If dtr("Zona") <> "" Then '				zona	textcombo		añadir a otros_txt                        
                            If Extras <> "" Then Extras &= ", "
                            Extras &= "Zona: " & dtr("Zona").ToString.ToUpper
                        End If
                        If dtr("Extras") <> "" Then
                            If Extras <> "" Then Extras &= ", "
                            Extras &= dtr("Extras") '75	otros_txt	textarea		extras	text		ok
                        End If
                        If Not IsDBNull(dtr("Piscina")) AndAlso dtr("Piscina") Then
                            myXml = extra(myXml, "piscina", Funciones.pf_ReplaceTrueFalse(dtr("Piscina"))) '80	piscina	boolean		piscina	boolean		ok
                        End If
                        If IsDBNull(dtr("Garaje")) Then
                            If Extras <> "" Then Extras &= ", "
                            Extras &= "garaje opcional"
                        ElseIf dtr("Garaje") Then
                            myXml = extra(myXml, "garaje", Funciones.pf_ReplaceTrueFalse(dtr("Garaje"))) '46	garaje	boolean		garaje	boolean		ok
                        End If
                        If IsDBNull(dtr("Trastero")) Then
                            If Extras <> "" Then Extras &= ", "
                            Extras &= "trastero opcional"
                        ElseIf Not IsDBNull(dtr("Trastero")) AndAlso dtr("Trastero") Then
                            myXml = extra(myXml, "trastero", Funciones.pf_ReplaceTrueFalse(dtr("Trastero"))) '117	trastero	boolean		trastero	boolean		ok
                            If dtr("MTrastero") > 0 Then
                                myXml = extra(myXml, "trastero_m2", Funciones.ReplacePuntos(dtr("MTrastero"))) '118	trastero_m2	decimal		mtrastero	int		ok
                            End If
                        End If
                        If Not IsDBNull(dtr("PrimeraLineaPlaya")) AndAlso dtr("PrimeraLineaPlaya") Then
                            myXml = extra(myXml, "zona_linea_mar", Funciones.pf_ReplaceTrueFalse(dtr("PrimeraLineaPlaya"))) '126	zona_linea_mar	boolean		primeralineaplaya	boolean		ok
                        End If
                        If Not IsDBNull(dtr("Urbanizacion")) AndAlso dtr("Urbanizacion") Then
                            myXml = extra(myXml, "zona_urbanizaciones", Funciones.pf_ReplaceTrueFalse(dtr("Urbanizacion"))) '129	zona_urbanizaciones	boolean		urbanizacion	boolean		ok
                        End If

                        '				altura	int		añadir a otros_txt
                        If Not IsDBNull(dtr("Patio")) AndAlso dtr("Patio") Then '				patio	boolean		añadir a otros_txt
                            If Extras <> "" Then Extras &= ", "
                            Extras &= "patio"
                        End If
                        If Not IsDBNull(dtr("duplex")) AndAlso dtr("duplex") Then '				duplex	boolean		añadir a otros_txt
                            If Extras <> "" Then Extras &= ", "
                            Extras &= "duplex"
                        End If
                        If Not IsDBNull(dtr("SemiAmueblado")) AndAlso dtr("SemiAmueblado") Then '				semiamueblado	boolean		añadir a otros_txt
                            If Extras <> "" Then Extras &= ", "
                            Extras &= "semi-amueblado"
                        End If
                        If Not IsDBNull(dtr("Galeria")) AndAlso dtr("Galeria") Then '				galeria	boolean		añadir a otros_txt
                            If Extras <> "" Then Extras &= ", "
                            Extras &= "galeria"
                        End If
                        If Not IsDBNull(dtr("CocinaOffice")) AndAlso dtr("CocinaOffice") Then '				cocinaoffice	boolean		añadir a otros_txt
                            If Extras <> "" Then Extras &= ", "
                            Extras &= "cocina-office"
                        End If
                        If Not IsDBNull(dtr("Electrodomesticos")) AndAlso dtr("Electrodomesticos") Then '				electrodomesticos	boolean		añadir a otros_txt
                            If Extras <> "" Then Extras &= ", "
                            Extras &= "electrodomesticos"
                        End If
                        If Not IsDBNull(dtr("VistasAlMar")) AndAlso dtr("VistasAlMar") Then '				vistasalmar	boolean		añadir a otros_txt
                            If Extras <> "" Then Extras &= ", "
                            Extras &= "vistas al mar"
                        End If
                        'If dtr("Oportunidad") Then '				oportunidad	boolean		añadir a otros_txt
                        '    If Extras <> "" Then Extras &= ", "
                        '    Extras &= "oportunidad"
                        'End If
                        'If dtr("AlquilerVacacional") Then '				alquilervacacional	boolean		añadir a otros_txt
                        '    If Extras <> "" Then Extras &= ", "
                        '    Extras &= "alquiler vacacional"
                        'End If
                        If Not IsDBNull(dtr("ZonaComercial")) AndAlso dtr("ZonaComercial") Then 'zonacomercial	boolean	añadir a otros_txt	
                            If Extras <> "" Then Extras &= ", "
                            Extras &= "zona comercial"
                        End If
                        If dtr("MPlaya") >= 0 Then '				mplaya	int		añadir a otros_txt
                            If Extras <> "" Then Extras &= ", "
                            Extras &= "a " & dtr("MPlaya") & " metros de la playa"
                        End If

                        '				capacidad	int		añadir a otros_txt

                        .WriteStartElement("extra")
                        .WriteAttributeString("id", "otros_txt")
                        .WriteCData(Extras)
                        .WriteEndElement()

                        '<extra id="terraza">1</extra> <!--tipo booleano -->
                        '<extra id="terraza_m2">36.90</extra><!--tipo decimal -->
                        '<extra id="parking_plazas">0</extra><!--tipo combo: 0 (1) -->
                        '<extra id="prox_metro_txt"><![CDATA[Metro L9]]></extra><!--tipo string -->
                        '<extra id="estado">0</extra> <!--tipo selector: 0 (nuevo) -->


                        .WriteEndElement() '</caracteristicas>


                        Dim ftp As New tb_FTP
                        Dim DirFiles As List(Of String) = ftp.FTPArchivosCarpeta(GL_ConfiguracionWeb.DirectorioFotos & "/" & dtr("Referencia"))
                        If Not IsNothing(DirFiles) AndAlso DirFiles.Count > 0 Then
                            .WriteStartElement("adjuntos") 'inicio <adjuntos>'NO OBLIGATORIO
                            For i = 0 To DirFiles.Count - 1
                                Try
                                    .WriteStartElement("adjunto") '<adjunto tipo="foto" url="http://www.webdelcliente.com/images/foto1.jpeg"><![CDATA[Cocina]]></adjunto>
                                    .WriteAttributeString("tipo", "foto")
                                    ' .WriteAttributeString("url", "http://venalia.net" & GL_ConfiguracionWeb.DirectorioFotos & "/" & dtr("Referencia") & "/" & DirFiles(i))
                                    If GL_ConfiguracionWeb.web3B Then
                                        .WriteAttributeString("url", "http://venalia.net" & GL_ConfiguracionWeb.DirectorioFotos & "/" & dtr("Referencia") & "/" & DirFiles(i)) 'url de la imagen
                                    Else
                                        .WriteAttributeString("url", GL_ConfiguracionWeb.WebConHHTP & Replace(GL_ConfiguracionWeb.DirectorioFotos, "/httpdocs", "") & "/" & dtr("Referencia") & "/" & DirFiles(i)) 'url de la imagen
                                    End If
                                    '.WriteCData(System.IO.Path.GetFileName(DirFiles(i)))
                                    .WriteCData(i + 1)
                                    .WriteEndElement() '</adjunto>
                                Catch
                                End Try
                            Next
                            .WriteEndElement() 'fin </adjuntos>
                        Else
                            .WriteStartElement("adjuntos")
                            Try
                                .WriteStartElement("adjunto")
                                .WriteAttributeString("tipo", "foto")
                                .WriteAttributeString("url", "http://venalia.net" & GL_ConfiguracionWeb.DirectorioFotos & "/SinImagen.jpg")

                                'If GL_ConfiguracionWeb.web3B Then
                                '    .WriteAttributeString("url", "http://venalia.net" & GL_ConfiguracionWeb.DirectorioFotos & "/SinImagen.jpg")
                                'Else
                                '    .WriteAttributeString("url", GL_ConfiguracionWeb.WebConHHTP & Replace(GL_ConfiguracionWeb.DirectorioFotos, "/httpdocs", "") & "/" & dtr("Referencia") & "/" & DirFiles(i)) 'url de la imagen
                                'End If

                                .WriteCData("Sin imagenes")
                                .WriteEndElement() '</adjunto>
                            Catch
                            End Try
                            .WriteEndElement() 'fin </adjuntos>
                        End If
                        .WriteEndElement() 'fin de referencia
                        pf.BringToFront()
                        pf.nuevoPaso()
                        Application.DoEvents()
                    End While
                Else
                    .Flush()
                    .Close()
                    bdPublicar.CerrarBD()
                    dtr.close()
                    pf.Close()
                    Return
                End If

            Catch ex As Exception
                XtraMessageBox.Show("Error en el inmueble " & dtr("Referencia") & vbCrLf & ex.Message & vbCrLf & "Se cancela la publicación de " & Portal, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                .Close()
                bdPublicar.CerrarBD()
                dtr.close()
                pf.Close()
                Return
            End Try

            bdPublicar.CerrarBD()
            dtr.close()

            .WriteEndElement() 'fin de referencias

            'inicio y fin de promociones

            .WriteEndElement() 'fin de publicacion

            .Flush()
            .Close()

        End With

        'si queremos zipear

        ''borrar ficheros anteriores
        'If File.Exists(ficheroDestinoXml & ".gz") Then
        '    Try
        '        File.Delete(ficheroDestinoXml & ".gz")
        '    Catch ex As Exception
        '    End Try
        'End If

        'pf.nuevoTexto("Compactando ...")

        ''Comprimir en formato gzip
        'Dim p As New ProcessStartInfo
        'p.FileName = clVariables.RutaServidor & "\gzip.exe"
        'p.Arguments = ficheroDestinoXml
        'p.WindowStyle = ProcessWindowStyle.Hidden
        'Process.Start(p)

        'pf.nuevoPaso("Publicando ...")

        ''subir al ftp

        'If Not SubirAlFtp(ficheroDestinoXml & ".gz", GL_ConfiguracionWeb.FTPClienteUsuario, GL_ConfiguracionWeb.FTPClientePass, GL_ConfiguracionWeb.FTPClienteDireccion & "/httpdocs/hogaria/" & Path.GetFileName(ficheroDestinoXml & ".gz")) Then
        '    pf.Close()
        '    Return
        'End If

        pf.nuevoPaso("Publicando ...")

        If DatosEmpresa.Codigo = 2 Then


            Try
                System.IO.File.Delete(Replace(ficheroDestinoXml, ".xml", ".zip"))
            Catch ex As Exception

            End Try

            Try
                Using zip As ZipFile = New ZipFile
                    zip.AddFile(ficheroDestinoXml, "")
                    zip.Save(Replace(ficheroDestinoXml, ".xml", ".zip"))
                End Using
            Catch ex1 As Exception
                Console.Error.WriteLine("exception: {0}", ex1.ToString)
            End Try

            Try
                System.IO.File.Delete(ficheroDestinoXml)
            Catch ex As Exception

            End Try
            ficheroDestinoXml = Replace(ficheroDestinoXml, ".xml", ".zip")

            If Not SubirAlFtp(ficheroDestinoXml, GL_ConfiguracionWeb.FTPClienteUsuario, GL_ConfiguracionWeb.FTPClientePass, "ftp://inmobiliariauim.com/httpdocs/yaencontre/" & Path.GetFileName(ficheroDestinoXml)) Then
                pf.Close()
                Return
            End If
        Else
            If Not SubirAlFtp(ficheroDestinoXml, GL_ConfiguracionWeb.FTPClienteUsuario, GL_ConfiguracionWeb.FTPClientePass, GL_ConfiguracionWeb.FTPClienteDireccion & "/httpdocs/yaencontre/" & Path.GetFileName(ficheroDestinoXml)) Then
                pf.Close()
                Return
            End If
        End If


        copiarAHistorico(ficheroDestinoXml, Portal)

        pf.nuevoPaso()
        pf.Close()

        'actualizamos el portal
        BD_CERO.Execute("UPDATE ClientePortales SET PendientePublicar = 0 WHERE Portal='" & Portal & "' AND CodigoEmpresa=" & DatosEmpresa.Codigo)

    End Sub

    Private Function extra(xmlw As XmlTextWriter, atributo As String, valor As String) As XmlTextWriter
        With xmlw
            .WriteStartElement("extra")
            .WriteAttributeString("id", atributo)
            .WriteString(valor) '1	acceso_discapacitados	boolean		accesominusvalidos	boolean		ok
            .WriteEndElement()
        End With
        Return xmlw
    End Function
    Public Sub PublicarIdealista() 'falta añadir campos extra,verificar errores posibles
        Dim sinDireccion As String = ""
        Dim pf As New ProgressForm(BD_CERO.Execute("SELECT count(*) FROM Inmuebles WHERE Portal" & Portal & " " & GL_SQL_DIS & "0 AND CodigoEmpresa =" & DatosEmpresa.Codigo, False) + 3, "Cargando publicación ...")

        Dim codigo As String = BD_CERO.Execute("SELECT Codigo FROM ClientePortales WHERE Portal='" & Portal & "' AND CodigoEmpresa=" & DatosEmpresa.Codigo, False)
        Dim ficheroDestinoXml As String
        If Portal = "Idealista" Then
            ficheroDestinoXml = clVariables.RutaServidor & "\" & codigo & ".xml"
        ElseIf Portal = "TuCasa" Then
            ficheroDestinoXml = clVariables.RutaServidor & "\tucasa.xml"
        End If

        If File.Exists(ficheroDestinoXml) Then
            Try
                File.Delete(ficheroDestinoXml)
            Catch ex As Exception
            End Try
        End If
        Dim myXmlTextWriter As XmlTextWriter = New XmlTextWriter(ficheroDestinoXml, System.Text.Encoding.UTF8)
        With myXmlTextWriter

            .Formatting = System.Xml.Formatting.Indented
            '.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8'")
            .WriteStartDocument()

            .WriteStartElement("clients") 'inicio clients
            .WriteStartElement("client") 'inicio client 
            If Portal = "Idealista" Then .WriteElementString("aggregator", "bfe5ab140d5e33c42cdc7595d827a67ed2de51b3") 'txt50 'OBLIGATORIO 'propietario del fichero 
            .WriteElementString("code", codigo) 'txt43 'OBLIGATORIO 'codigovolcadocliente
            .WriteStartElement("secondhandListing") 'inicio secondhandListing 'OBLIGATORIO
            'para cada finca
            Dim dtr As Object
            Dim bdPublicar As New BaseDatos

            dtr = bdPublicar.ExecuteReader("SELECT * FROM Inmuebles WHERE Portal" & Portal & " " & GL_SQL_DIS & "0 AND CodigoEmpresa =" & DatosEmpresa.Codigo)

            pf.nuevoPaso("Generando publicación ...")

            If dtr.hasrows Then
                While dtr.read
                    If dtr("DireccionMapa") = "" Then
                        sinDireccion &= dtr("Referencia") & vbCrLf
                        pf.nuevoPaso()
                    Else

                        .WriteStartElement("Property") 'inicio Property 'OBLIGATORIO
                        .WriteStartElement("address") 'inicio address 'OBLIGATORIO
                        .WriteElementString("cityName", dtr("Poblacion")) 'txt75 nombremunicipio
                        '.WriteStartElement("coordinates") 'inicio coordinates
                        '.WriteElementString("latitude", "41.5130246465") 'dec20 xx.xxxx
                        '.WriteElementString("longitude", "-4.5130246465") 'dec20 yy.yyyy
                        '.WriteEndElement() 'fin de coordinates
                        .WriteElementString("country", "ES") 'txt2 códigoISO31661 alpha2depaís
                        '.WriteElementString("floor", "") 'st sotano,ss subsuelo,en entreplanta,bj bajo,numero-> numero de planta

                        If dtr("CodPostal") = "" Then 'txt5 'OBLIGATORIO codigopostal
                            'ojo no puede estar sin este campo
                            Dim pobla As String = BD_CERO.Execute("SELECT CodigoPostal FROM Poblacion WHERE Poblacion='" & dtr("Poblacion") & "' AND CodigoEmpresa =" & DatosEmpresa.Codigo, False)
                        Else
                            .WriteElementString("postalcode", dtr("CodPostal"))
                        End If

                        '.WriteElementString("stair", "") 'text10 escalera

                        If dtr("Direccion") = "" Then 'txt200 'OBLIGATORIO calle
                            'ojo no puede estar sin este campo
                            .WriteElementString("streetName", "Centro")
                        Else
                            .WriteElementString("streetName", dtr("DireccionMapa"))
                        End If
                        'If dtr("Numero") = "" Then 'txt10 'OBLIGATORIO numero
                        'ojo no puede estar sin este campo
                        .WriteElementString("streetNumber", "S/N")
                        '    Else
                        '    .WriteElementString("streetNumber", dtr("Numero"))
                        'End If

                        .WriteElementString("visibility", "3") '1 direccioncompleta, 2 solocalle, 3 ocultardirección
                        .WriteEndElement() 'fin de address
                        .WriteElementString("code", dtr("Contador")) 'txt50'OBLIGATORIO 'contador del inmueble
                        .WriteElementString("reference", dtr("Referencia")) 'txt50'referencia del inmueble
                        .WriteElementString("scope", "1") '1idealistoymicrosite, 2micrositesolo
                        .WriteStartElement("operation") 'inicio operation

                        Dim tipoventa As String = BD_CERO.Execute("SELECT TipoVenta FROM TipoVentaPortales WHERE Contador=(SELECT Contador" & Portal & " FROM TipoVenta WHERE CodigoEmpresa=" & DatosEmpresa.Codigo & " AND TipoVenta='" & dtr("TipoVenta") & "')", False)
                        If IsNothing(tipoventa) OrElse Not tipoventa.Contains("|") Then
                            XtraMessageBox.Show("Error al publicar el inmueble " & dtr("Referencia") & ", la oferta " & dtr("TipoVenta") & " NO esta asignada" & vbCrLf & "Se cancela la publicación completa de " & Portal, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            .Flush()
                            .Close()
                            pf.Close()
                            Return
                        End If
                        .WriteAttributeString("type", tipoventa.Split("|")(0))

                        .WriteElementString("price", Funciones.ReplacePuntos(dtr("Precio"))) 'dec10.2 'OBLIGATORIO
                        If tipoventa = "renttoown" Then
                            .WriteElementString("salePrice", "") 'dec10.2 'OBLIGATORIO SI OPCION A COMPRA
                        End If
                        .WriteEndElement() 'fin de operation
                        .WriteStartElement("contact") 'inicio contact
                        .WriteElementString("email", BD_CERO.Execute("SELECT Email FROM EmailConfiguracion WHERE Empresa=" & DatosEmpresa.Codigo, False)) 'txt255 email
                        '.WriteElementString("name", "") 'txt255 nombre de contacto
                        '.WriteStartElement("phones") 'inicio phones
                        '.WriteStartElement("phone") 'inicio phone uno o varios
                        '.WriteElementString("number", "999999999") 'txt11 numero de telefono
                        '.WriteEndElement() 'fin de phone
                        '.WriteEndElement() 'fin de phones
                        .WriteEndElement() 'fin de contact
                        .WriteStartElement("descriptions") 'inicio descriptions
                        .WriteStartElement("description") 'inicio description
                        .WriteElementString("comment", ConsultasBaseDatos.ObtenerDescripcionInmueble2(dtr("Contador"), 0, False, False)) 'txt2500 descripcion del inmueble
                        '.WriteElementString("externalUrl", "")
                        .WriteElementString("language", "1") '1 español,2ingles,2frances,4aleman,...
                        '.WriteElementString("title", "ADOSADO ALDEAMAYOR") 'txt140 titulo
                        .WriteEndElement() 'fin de description
                        .WriteEndElement() 'fin de descriptions
                        .WriteStartElement("features") 'inicio features

                        Dim tipo As String = BD_CERO.Execute("SELECT Tipo FROM TipoPortales WHERE Contador=(SELECT Contador" & Portal & " FROM Tipo WHERE CodigoEmpresa=" & DatosEmpresa.Codigo & " AND Tipo='" & dtr("Tipo") & "')", False)
                        If IsNothing(tipo) OrElse Not tipo.Contains("|") Then
                            XtraMessageBox.Show("Error al publicar el inmueble " & dtr("Referencia") & ", el tipo " & dtr("Tipo") & " NO esta asignado" & vbCrLf & "Se cancela la publicación completa de " & Portal, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            .Flush()
                            .Close()
                            pf.Close()
                            Return
                        End If

                        .WriteAttributeString("type", tipo.Split("|")(0))

                        'casas rústicas (type: countryHouse) cr
                        'chalets (type: house) ch
                        'garajes (type: garage) ga
                        'locales o naves (type: premise) lo
                        'oficinas (type: office) of
                        'terrenos (type: land) te
                        'vivienda (type: flat) vi
                        If Funciones.ReplacePuntos(dtr("Metros")) < 1 Then 'OBLIGATORIO menos garajes, terrenos, promocion
                            'ojo si esta debe tener al menos 1
                            If "GARAGE,LAND,PROMO".Contains(tipo.ToUpper.Split("|")(0)) Then
                                'NO PONEMOS NADA
                            Else
                                .WriteElementString("constructedArea", 1)
                            End If
                        Else
                            .WriteElementString("constructedArea", Funciones.ReplacePuntos(dtr("Metros")))
                        End If

                        Select Case tipo.ToUpper.Split("|")(0)
                            Case "FLAT"
                                .WriteElementString("bathrooms", dtr("Banos")) 'Int baños'OBLIGATORIO countryHouse, flat, house
                                .WriteElementString("rooms", dtr("Habitaciones")) 'Int dormitorios 'OBLIGATORIO countryHouse, flat, house
                                If dtr("Terraza") OrElse dtr("Balcon") OrElse dtr("Patio") Then
                                    Dim terraza As Byte = 0
                                    Dim mterraza As Integer = 0
                                    If dtr("Terraza") Then
                                        terraza += 1
                                        mterraza += dtr("MTerraza") + dtr("MTerraza2")
                                        If dtr("MTerraza2") > 0 Then
                                            terraza += 1
                                        End If
                                    End If
                                    If dtr("Balcon") Then
                                        terraza += 1
                                        mterraza += dtr("MBalcon") + dtr("MBalcon2")
                                        If dtr("MBalcon2") > 0 Then
                                            terraza += 1
                                        End If
                                    End If
                                    If dtr("Patio") Then
                                        terraza += 1
                                        mterraza += dtr("MPatio") + dtr("MPatio2")
                                        If dtr("MPatio2") > 0 Then
                                            terraza += 1
                                        End If
                                    End If
                                    .WriteElementString("balconyNumber", terraza) 'flat,house,countryHouse  - no ob. - número de terrazas       - terraza/balcon/patio boolean
                                    .WriteElementString("terraceMeters", mterraza) 'flat,house,countryHouse - no ob. - metros cuadrados de la terraza     - mterraza int
                                End If
                                If Not IsDBNull(dtr("Piscina")) AndAlso dtr("Piscina") Then .WriteElementString("pool", dtr("Piscina")) 'flat,house,countryHouse - no ob. - tiene piscina        - piscina boolean
                                If Not IsDBNull(dtr("Trastero")) AndAlso dtr("Trastero") Then .WriteElementString("storageRoom", dtr("Trastero")) 'flat,house,countryHouse - no ob. - tiene trastero        - trastero boolean
                                If Not IsDBNull(dtr("Amueblado")) AndAlso dtr("Amueblado") Then .WriteElementString("furniture", 3) 'flat,house,countryHouse - no ob. - equipamiento del inmueble       - amueblado boolean 3=amueblado
                                If Not IsDBNull(dtr("Jardin")) AndAlso dtr("Jardin") Then .WriteElementString("garden", dtr("Jardin")) 'flat,house,countryHouse - no ob. - tiene jardin        - jardin boolean
                                If Not IsDBNull(dtr("AccesoMinusvalidos")) AndAlso dtr("AccesoMinusvalidos") Then .WriteElementString("handicappedAdapted", dtr("AccesoMinusvalidos")) 'flat,house,countryHouse - no ob. - edificio e inmueble adaptados a minusvalidos    - accesoMinusvalidos boolean

                                If dtr("Duplex") Then .WriteElementString("duplex", dtr("Duplex")) 'flat - no ob. - es un duplex       - duplex boolean
                                xmlFill("Estado", dtr, myXmlTextWriter)
                                If Not IsDBNull(dtr("Ascensor")) AndAlso dtr("Ascensor") Then .WriteElementString("elevator", dtr("Ascensor")) 'flat,garage - no ob. - tiene ascensor        - ascensor boolean
                                xmlFill("Orientacion", dtr, myXmlTextWriter)
                                If Not IsDBNull(dtr("Garaje")) AndAlso dtr("Garaje") Then .WriteElementString("parkingSpacesInPrice", 1) 'flat,house,countryHouse,office - no ob. - número de plazas de garaje incluidas en el precio - garaje boolean
                                xmlFill("CalificacionEnergetica", dtr, myXmlTextWriter)
                                If Not IsDBNull(dtr("Calefaccion")) AndAlso dtr("Calefaccion") Then .WriteElementString("heatingType", 2) 'flat,house,countryHouse,office,premise - no ob. - tipo de calefaccion       - calefaccion boolean
                                If Not IsDBNull(dtr("AireAcondicionado")) AndAlso dtr("AireAcondicionado") Then .WriteElementString("conditionedAir", 2) 'flat,house,countryHouse,office,premise - no ob. - tipo de aire acondicionado      - aireacondicionado boolean

                            Case "LAND"

                            Case "OFFICE"
                                If Not IsDBNull(dtr("AccesoMinusvalidos")) AndAlso dtr("AccesoMinusvalidos") Then .WriteElementString("handicappedBath", dtr("AccesoMinusvalidos")) 'office  - no ob. - baños por minusválidos       - accesoMinusvalidos boolean
                                If Not IsDBNull(dtr("Ascensor")) AndAlso dtr("Ascensor") Then .WriteElementString("elevatorNumber", dtr("Ascensor")) 'office  - no ob. - número de ascensores       - ascensor boolean
                                xmlFill("Estado", dtr, myXmlTextWriter)
                                If Not IsDBNull(dtr("Electrodomesticos")) AndAlso dtr("Electrodomesticos") Then .WriteElementString("kitchen", dtr("Electrodomesticos")) 'office,premise - no ob. - cocina equipada        - electrodomesticos boolean
                                xmlFill("Orientacion", dtr, myXmlTextWriter)
                                If Not IsDBNull(dtr("Garaje")) AndAlso dtr("Garaje") Then .WriteElementString("parkingSpacesInPrice", 1) 'flat,house,countryHouse,office - no ob. - número de plazas de garaje incluidas en el precio - garaje boolean
                                xmlFill("CalificacionEnergetica", dtr, myXmlTextWriter)
                                If Not IsDBNull(dtr("Calefaccion")) AndAlso dtr("Calefaccion") Then .WriteElementString("heatingType", 2) 'flat,house,countryHouse,office,premise - no ob. - tipo de calefaccion       - calefaccion boolean
                                If Not IsDBNull(dtr("AireAcondicionado")) AndAlso dtr("AireAcondicionado") Then .WriteElementString("conditionedAir", 2) 'flat,house,countryHouse,office,premise - no ob. - tipo de aire acondicionado      - aireacondicionado boolean

                            Case "PREMISE"
                                xmlFill("Estado", dtr, myXmlTextWriter)
                                If Not IsDBNull(dtr("AccesoMinusvalidos")) AndAlso dtr("AccesoMinusvalidos") Then .WriteElementString("handicappedBaths", dtr("AccesoMinusvalidos")) 'premise - no ob. - baños por minusvalidos       - accesoMinusvalidos boolean
                                If Not IsDBNull(dtr("Electrodomesticos")) AndAlso dtr("Electrodomesticos") Then .WriteElementString("kitchen", dtr("Electrodomesticos")) 'office,premise - no ob. - cocina equipada        - electrodomesticos boolean
                                xmlFill("CalificacionEnergetica", dtr, myXmlTextWriter)
                                If Not IsDBNull(dtr("Calefaccion")) AndAlso dtr("Calefaccion") Then .WriteElementString("heatingType", 2) 'flat,house,countryHouse,office,premise - no ob. - tipo de calefaccion       - calefaccion boolean
                                If Not IsDBNull(dtr("AireAcondicionado")) AndAlso dtr("AireAcondicionado") Then .WriteElementString("conditionedAir", 2) 'flat,house,countryHouse,office,premise - no ob. - tipo de aire acondicionado      - aireacondicionado boolean

                            Case "GARAGE"
                                If Not IsDBNull(dtr("Ascensor")) AndAlso dtr("Ascensor") Then .WriteElementString("elevator", dtr("Ascensor")) 'flat,garage - no ob. - tiene ascensor        - ascensor boolean

                            Case "HOUSE", "COUNTRYHOUSE"
                                .WriteElementString("bathrooms", dtr("Banos")) 'Int baños'OBLIGATORIO countryHouse, flat, house
                                .WriteElementString("rooms", dtr("Habitaciones")) 'Int dormitorios 'OBLIGATORIO countryHouse, flat, house
                                If dtr("Terraza") OrElse dtr("Balcon") OrElse dtr("Patio") Then
                                    Dim terraza As Byte = 0
                                    Dim mterraza As Integer = 0
                                    If dtr("Terraza") Then
                                        terraza += 1
                                        mterraza += dtr("MTerraza") + dtr("MTerraza2")
                                        If dtr("MTerraza2") > 0 Then
                                            terraza += 1
                                        End If
                                    End If
                                    If dtr("Balcon") Then
                                        terraza += 1
                                        mterraza += dtr("MBalcon") + dtr("MBalcon2")
                                        If dtr("MBalcon2") > 0 Then
                                            terraza += 1
                                        End If
                                    End If
                                    If dtr("Patio") Then
                                        terraza += 1
                                        mterraza += dtr("MPatio") + dtr("MPatio2")
                                        If dtr("MPatio2") > 0 Then
                                            terraza += 1
                                        End If
                                    End If
                                    .WriteElementString("balconyNumber", terraza) 'flat,house,countryHouse  - no ob. - número de terrazas       - terraza/balcon/patio boolean
                                    .WriteElementString("terraceMeters", mterraza) 'flat,house,countryHouse - no ob. - metros cuadrados de la terraza     - mterraza int
                                End If
                                If Not IsDBNull(dtr("Piscina")) AndAlso dtr("Piscina") Then .WriteElementString("pool", dtr("Piscina")) 'flat,house,countryHouse - no ob. - tiene piscina        - piscina boolean
                                If Not IsDBNull(dtr("Trastero")) AndAlso dtr("Trastero") Then .WriteElementString("storageRoom", dtr("Trastero")) 'flat,house,countryHouse - no ob. - tiene trastero        - trastero boolean
                                If Not IsDBNull(dtr("Amueblado")) AndAlso dtr("Amueblado") Then .WriteElementString("furniture", 3) 'flat,house,countryHouse - no ob. - equipamiento del inmueble       - amueblado boolean 3=amueblado
                                If Not IsDBNull(dtr("Jardin")) AndAlso dtr("Jardin") Then .WriteElementString("garden", dtr("Jardin")) 'flat,house,countryHouse - no ob. - tiene jardin        - jardin boolean
                                If Not IsDBNull(dtr("AccesoMinusvalidos")) AndAlso dtr("AccesoMinusvalidos") Then .WriteElementString("handicappedAdapted", dtr("AccesoMinusvalidos")) 'flat,house,countryHouse - no ob. - edificio e inmueble adaptados a minusvalidos    - accesoMinusvalidos boolean
                                xmlFill("Estado", dtr, myXmlTextWriter)
                                xmlFill("Orientacion", dtr, myXmlTextWriter)
                                If Not IsDBNull(dtr("Garaje")) AndAlso dtr("Garaje") Then .WriteElementString("parkingSpacesInPrice", 1) 'flat,house,countryHouse,office - no ob. - número de plazas de garaje incluidas en el precio - garaje boolean
                                xmlFill("CalificacionEnergetica", dtr, myXmlTextWriter)
                                If Not IsDBNull(dtr("Calefaccion")) AndAlso dtr("Calefaccion") Then .WriteElementString("heatingType", 2) 'flat,house,countryHouse,office,premise - no ob. - tipo de calefaccion       - calefaccion boolean
                                If Not IsDBNull(dtr("AireAcondicionado")) AndAlso dtr("AireAcondicionado") Then .WriteElementString("conditionedAir", 2) 'flat,house,countryHouse,office,premise - no ob. - tipo de aire acondicionado      - aireacondicionado boolean

                        End Select

                        .WriteEndElement() 'fin de features
                        Dim ftp As New tb_FTP
                        Dim DirFiles As List(Of String) = ftp.FTPArchivosCarpeta(GL_ConfiguracionWeb.DirectorioFotos & "/" & dtr("Referencia"))
                        If Not IsNothing(DirFiles) AndAlso DirFiles.Count > 0 Then
                            .WriteStartElement("images") 'inicio images
                            'para cada imagen
                            For i = 0 To DirFiles.Count - 1
                                Try

                                    .WriteStartElement("image") 'inicio image

                                    If DirFiles(i) = dtr("FotoPrincipal") Then
                                        .WriteElementString("code", "1")
                                    Else
                                        .WriteElementString("code", "0")
                                    End If


                                    '0 desconocido '1 baño '2 cocina '3 detalles '4 dormitorio '5 fachada '6 garaje '7 jardín '8 plano '9 salón '10 terraza '11 vistas '12 piscina '13 compañeros '14 pasillo '15 hall '16 sala de espera '17 zonas comunes '18 recepción '19 trastero '20 archivo '21 almacén '22 estancia '23 entrada/salida '24 terreno
                                    '.WriteElementString("url", "http://venalia.net" & GL_ConfiguracionWeb.DirectorioFotos & "/" & dtr("Referencia") & "/" & DirFiles(i)) 'url de la imagen

                                    If GL_ConfiguracionWeb.web3B Then
                                        .WriteElementString("url", "http://venalia.net" & GL_ConfiguracionWeb.DirectorioFotos & "/" & dtr("Referencia") & "/" & DirFiles(i)) 'url de la imagen
                                    Else
                                        .WriteElementString("url", GL_ConfiguracionWeb.WebConHHTP & Replace(GL_ConfiguracionWeb.DirectorioFotos, "/httpdocs", "") & "/" & dtr("Referencia") & "/" & DirFiles(i)) 'url de la imagen
                                    End If

                                    .WriteEndElement() 'fin de image
                                Catch
                                End Try
                            Next
                            .WriteEndElement() 'fin de images
                        Else
                        End If

                        .WriteEndElement() 'fin de Property
                        pf.nuevoPaso()
                    End If
                End While
            Else
                .Flush()
                .Close()
                pf.Close()
                Exit Sub
            End If
            bdPublicar.CerrarBD()
            dtr.close()
            'fin de las fincas
            .WriteEndElement() 'fin de secondhandListing
            .WriteEndElement() 'fin de client
            .WriteEndElement() 'fin de clients

            .Flush()
            .Close()
        End With

        pf.nuevoPaso("Publicando ...")

        'subir al ftp
        'Host: ftp1.idealista.com
        'Usuario: Venalia
        'Password: boakCikfie
        If Portal = "Idealista" Then
            If Not SubirAlFtp(ficheroDestinoXml, "Venalia", "boakCikfie", "ftp1.idealista.com" & "/" & Path.GetFileName(ficheroDestinoXml)) Then
                pf.Close()
                Return
            End If
        ElseIf Portal = "TuCasa" Then
            If Not SubirAlFtp(ficheroDestinoXml, GL_ConfiguracionWeb.FTPClienteUsuario, GL_ConfiguracionWeb.FTPClientePass, GL_ConfiguracionWeb.FTPClienteDireccion & "/httpdocs/tucasacom/" & Path.GetFileName(ficheroDestinoXml)) Then
                pf.Close()
                Return
            End If
        End If

        copiarAHistorico(ficheroDestinoXml, Portal)

        pf.nuevoPaso()
        pf.Close()

        'actualizamos el portal
        BD_CERO.Execute("UPDATE ClientePortales SET PendientePublicar = 0 WHERE Portal='" & Portal & "' AND CodigoEmpresa=" & DatosEmpresa.Codigo)

        If sinDireccion <> "" Then MensajeInformacion("Los siguientes inmuebles no tienen la dirección completa," & vbCrLf & "por lo que no se han publicado:" & vbCrLf & sinDireccion)
    End Sub

    Private Sub copiarAHistorico(fichero As String, portal As String)
        Try
            'copiar fichero al historico
            Dim rutaHistoricoPortales As String = "HistoricoPortales"
            Funciones.ComprobarYCrearCarpetas(rutaHistoricoPortales, True)
            File.Copy(fichero, rutaHistoricoPortales & "\" & portal & Now.ToString("yyyyMMddHHmmss") & "." & Path.GetExtension(fichero))
        Catch ex As Exception

        End Try
    End Sub



    Private Sub xmlFill(campo As String, dtr As Object, ByRef xml As XmlTextWriter)
        If dtr(campo) <> "" Then
            With xml
                Select Case campo
                    Case "Orientacion"
                        'flat,house,countryHouse,office - no ob. - orientación geográfica        - orientacion textcombo 
                        '1 norte,2 noreste,3 este,4 sureste,5 sur,6 suroeste,7 oeste,8 noroeste
                        Select Case dtr("Orientacion").ToString.ToUpper
                            Case "NORTE"
                                .WriteElementString("orientation", 1)
                            Case "ESTE-NORTE"
                                .WriteElementString("orientation", 2)
                            Case "ESTE"
                                .WriteElementString("orientation", 3)
                            Case "ESTE-SUR"
                                .WriteElementString("orientation", 4)
                            Case "SUR"
                                .WriteElementString("orientation", 5)
                            Case "SUR-OESTE"
                                .WriteElementString("orientation", 6)
                            Case "OESTE"
                                .WriteElementString("orientation", 7)
                            Case "NORTE-OESTE"
                                .WriteElementString("orientation", 8)
                        End Select

                    Case "Estado"
                        'flat,house,countryHouse,office,premise - no ob. - tipo y estado del inmueble     - estado textcombo 
                        '1 obra nueva, 2 a reformar, 3 buen estado
                        Select Case dtr("Estado").ToString.ToUpper
                            Case "NUEVO"
                                .WriteElementString("buildingType", 3)
                            Case "SEMINUEVO"
                                .WriteElementString("buildingType", 3)
                            Case "PARA REFORMAR"
                                .WriteElementString("buildingType", 2)
                        End Select

                    Case "CalificacionEnergetica"
                        .WriteStartElement("energyCertification") 'flat,house,countryHouse,office,premise - no ob. - nodo con los datos de la certificación energética  - CalificacionEnergetica textcombo
                        Select Case dtr("CalificacionEnergetica").ToString.ToUpper
                            Case "A"
                                .WriteElementString("rating", 2)
                            Case "B"
                                .WriteElementString("rating", 3)
                            Case "C"
                                .WriteElementString("rating", 4)
                            Case "D"
                                .WriteElementString("rating", 5)
                            Case "E"
                                .WriteElementString("rating", 6)
                            Case "F"
                                .WriteElementString("rating", 7)
                            Case "G"
                                .WriteElementString("rating", 8)
                        End Select
                        'rating no tEnergyRating 1 cualificación energética 2 A,3 B,4 C,5 D,6 E,7 F,8 G
                        'performance no number decimal 4.2 indice de prestacion energetica (ipe) en kwh/m² año
                        'type no tEnergyType 1 tipo de certificación energética
                        .WriteEndElement()



                End Select
            End With
        End If
    End Sub
    Private Function SubirAlFtp(Fichero As String, Optional usuario As String = "", Optional pass As String = "", Optional ruta As String = "") As Boolean
        Dim ftp As New tb_FTP
        Dim carpeta As String = GL_ConfiguracionWeb.DirectorioFotos
        If ruta = "" Then
            ruta = ftp.RutaInicialFTP & carpeta & "/" & Path.GetFileName(Fichero)
        End If
        Try
            ftp.FTPBorrarFichero(ruta, usuario, pass, ruta)
        Catch ex As Exception
        End Try
        Try
            Dim men As String = ftp.SubirArchivoAlServidor(Fichero, ruta, carpeta, usuario, pass)
            If men <> "" Then
                XtraMessageBox.Show("No se ha podido publicar en " & Portal & vbCrLf & men, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        Catch ex As Exception
            XtraMessageBox.Show("No se ha podido publicar en " & Portal & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        Return True
    End Function




    Private Sub btnLlamar_Click(sender As System.Object, e As System.EventArgs) Handles btnLlamar.Click
        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            MensajeInformacion("Debe seleccionar un registro")
            Return
        End If
        TabInmuebles.SelectedTabPageIndex = 1
        UcInmueblesPropietario1.UcComunicacionesDetalle1.llamada()
    End Sub

    Private Sub chkAmuebladoVenta_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAmuebladoVenta.CheckedChanged
        If chkAmuebladoVenta.Checked AndAlso chkSemiAmuebladoVenta.Checked Then
            chkAmuebladoVenta.Checked = False
        End If
    End Sub

    Private Sub chkSemiAmuebladoVenta_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSemiAmuebladoVenta.CheckedChanged
        If chkAmuebladoVenta.Checked AndAlso chkSemiAmuebladoVenta.Checked Then
            chkAmuebladoVenta.Checked = False
        End If
    End Sub

    Private Sub Gv_RowStyle(sender As System.Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs)


        If e.State = DevExpress.XtraGrid.Views.Base.GridRowCellState.Selected Then 'e.State <> 0
            e.HighPriority = True
            If mostrarFocus Then
                e.Appearance.BackColor = GL_ColorSeleccionado
                e.Appearance.ForeColor = GL_ColorTextoSeleccionado
            Else
                e.Appearance.BackColor = Color.White
                e.Appearance.ForeColor = Color.Black
            End If
        Else
            If Not mostrarFocus Then
                e.Appearance.BackColor = Color.White
                e.Appearance.ForeColor = Color.Black
            End If
        End If
    End Sub



    'Private Sub SliderGrande_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles SliderGrande.KeyDown
    '    If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Right Then
    '        SliderGrande.SlideNext()
    '    Else
    '        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Left Then
    '            SliderGrande.SlidePrev()
    '        End If
    '    End If
    'End Sub


    'Private Sub SliderGrande_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles SliderGrande.KeyPress
    '    If e.KeyChar = CChar(ChrW(Keys.Right)) Then
    '        SliderGrande.SlideNext()
    '    Else
    '        'If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Left Then
    '        '    SliderGrande.SlidePrev()
    '        'End If
    '    End If
    'End Sub

    Private Sub ucInmuebles_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        uInmueblesActivo = Nothing
    End Sub

    'Public Sub publicarFacebook()
    '    Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
    '    CargarFormulario("PublicarFacebook", , , , BinSrc.Current("FotoPrincipal") & "|" & BinSrc.Current("Referencia") & "|" & BinSrc.Current("Contador"))
    '    Me.Cursor = System.Windows.Forms.Cursors.Arrow

    'End Sub







    Private Sub txtReferencia_EditValueChanged(sender As Object, e As System.EventArgs) Handles txtReferencia.EditValueChanged
        If Not txtReferencia.Enabled Then
            HacerCambioFila()
        End If
    End Sub

    Private Sub btnValidarFotocasa_Click(sender As Object, e As EventArgs) Handles btnValidarFotocasa.Click

        Dim CodigoAPI As String
        Dim Sel As String

        Sel = "SELECT Codigo FROM ClientePortales WHERE Portal = 'FotoCasa' and CodigoEmpresa = " & DatosEmpresa.Codigo
        CodigoAPI = BD_CERO.Execute(Sel, False, "")

        If CodigoAPI = "" Then
            MensajeError("No puede DesPublicar en FotoCasa porque no tiene código API de acceso")
        End If

        ValidarPublicacion(CodigoAPI)
    End Sub

    Private Sub btnVerReservasPC_Click(sender As Object, e As EventArgs) Handles btnVerReservasPC.Click


        VerReservasPC = Not VerReservasPC
        LlenarGrid()
    End Sub

    Private Sub btnVerBajasPC_Click(sender As Object, e As EventArgs) Handles btnVerBajasPC.Click
        VerBajasPC = Not VerBajasPC
        LlenarGrid()
    End Sub
    'Private Sub txtReferencia_TextChanged(sender As Object, e As System.EventArgs) Handles txtReferencia.TextChanged
    '    If Not txtReferencia.Enabled Then
    '        HacerCambioFila()
    '    End If
    'End Sub
End Class






