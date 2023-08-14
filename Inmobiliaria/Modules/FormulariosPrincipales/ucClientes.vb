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
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraSplashScreen
Imports System.IO.Ports
Imports DevExpress.Utils
Imports DevExpress.XtraPivotGrid
Imports System.Threading


Namespace Venalia



    Partial Public Class ucClientes

        Inherits DevExpress.XtraEditors.XtraUserControl

        '  Dim AnadiendoOModificando As Boolean = False

        '   Dim DocumentosDetalle As ucDocumentosGenerarBase

        Dim Eliminando As Boolean = False
        Dim menu As DXPopupMenu
        Public PopupMenu As DXPopupMenu
        Dim EstoyEnAlta As Boolean

        Public bd As BaseDatos
        Public WithEvents BinSrc As BindingSource
        Dim TablaMantenimiento As String = "Clientes"
        Dim CargandoClientes As Boolean = True
        Dim PrimeraVez As Boolean
        Dim PrimeraVezLlenarZona As Boolean

        Dim AP As ActualizaPerfil

        Dim SentenciaSQL As String
        'Dim FiltroBusqueda As String = ""

        Dim TextoInicialBotonBuscar As String = ""
        Dim ColorInicialBotonBuscar As System.Drawing.Color
        Dim CampoInicialBusqueda As String = "Nombre"


        'Dim PanelComunicacionesDetalle As DockPanel
        'Dim uComunicacionesDetalle As ucComunicacionesDetalle

        Dim PanelArticulosVendidos As DockPanel
        Dim uArticulosVendidos As ucInmueblesPropietario

        Dim PanelGestionDocumental As DockPanel
        Dim uGestionDocumental As ucGestionDocumental
        Dim TablaGestionDocumental As String
        Dim CampoGestionDocumental As String

        Dim ColorInicialTextos As System.Drawing.Color
        Dim ColorInicialBotonBajas As System.Drawing.Color
        Dim MenuGrid As tbContextMenuStripComponent

        Dim AnadirCheckColunm As Boolean = True

        'Dim BuscandoPorTelefonoEmail As Boolean = False
        Dim BuscandoPorTelefonoEmail2 As Boolean = False

        Dim AltoVentana As Integer = 0
        Dim EstoyDesHabilitando As Boolean = False
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
            WhereConsulta = ""
            DeDondeVengo = ""
            ContadorInmuebleDeDondeVengo = 0

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

        Private p_WhereConsulta As String

        Public Property WhereConsulta As String
            Get
                Return p_WhereConsulta
            End Get
            Set(value As String)
                p_WhereConsulta = value
            End Set
        End Property

        Private p_ContadorInmuebleDeDondeVengo As Integer

        Public Property ContadorInmuebleDeDondeVengo As Integer
            Get
                Return p_ContadorInmuebleDeDondeVengo
            End Get
            Set(value As Integer)
                p_ContadorInmuebleDeDondeVengo = value
            End Set
        End Property

        Private p_ReferenciaInmuebleDeDondeVengo As String

        Public Property ReferenciaInmuebleDeDondeVengo As String
            Get
                Return p_ReferenciaInmuebleDeDondeVengo
            End Get
            Set(value As String)
                p_ReferenciaInmuebleDeDondeVengo = value
            End Set
        End Property

        Private p_ContadorClienteAlQueVoy As Integer

        Public Property ContadorClienteAlQueVoy As Integer
            Get
                Return p_ContadorClienteAlQueVoy
            End Get
            Set(value As Integer)
                p_ContadorClienteAlQueVoy = value
            End Set
        End Property

        Dim PulsadoVerBajas As Boolean = False
        Dim PulsadoVerNovedades As Boolean = True
        Private Sub LlenarComboCmbTipoBuscar()

            Dim Sel As String
            Sel = "SELECT '' AS Tipo " & GL_SQL_FROMDUAL & " UNION ALL SELECT Tipo FROM Tipo"
            Dim bdTipo As New BaseDatos
            bdTipo.LlenarDataSet(Sel, "Tipo")
            For i = 0 To bdTipo.ds.Tables("Tipo").Rows.Count - 1
                cmbTipoBuscar.Properties.Items.Add(bdTipo.ds.Tables("Tipo").Rows(i)("Tipo"))
            Next
         


        End Sub
        Private Sub ucClientes_Load(sender As Object, e As System.EventArgs) Handles Me.Load


            BotonSoloNovedades()


            btnMostrarAccionesComerciales.Text = "Mostrar Acciones Comerciales"
            PrimeraVezLlenarZona = True
            'Dim FicheroXML As String = "c:\nif.xml"
            ''Pruebas xml 
            'Dim ds As New DataSet
            'Dim dt As DataTable

            'ds.ReadXmlSchema(FicheroXML)
            'ds.ReadXml(FicheroXML)
            'dt = ds.Tables("Info")
            'For Each drr As DataRow In dt.Rows
            '    If drr("Tipo") = Tipo Then
            '        drr("Nombre") = NombrePerfil
            '        ds.AcceptChanges()
            '        ds.WriteXml(FicheroInformacionPerfiles, XmlWriteMode.WriteSchema)

            '    End If
            'Next
            ''Pruebas xml 

            AparienciaGeneral()

            'btnEmailDetalle.ForeColor = GL_ColorTextoBotones
            'btnEmailListadoNovedades.ForeColor = GL_ColorTextoBotones
            'btnSMS.ForeColor = GL_ColorTextoBotones

            'btnVisitasOficina.ForeColor = GL_ColorTextoBotones


            ' Me.ContadorInmuebleDeDondeVengo = 9 '------------------------------------------------------------------------------- OJO

            'Me.ContadorInmuebleDeDondeVengo = 0
            If ContadorInmuebleDeDondeVengo <> 0 Then
                '        dgvx.Height = dgvx.Height - txtDescripcionInmueble.Height - 100
                txtDescripcionInmueble.Visible = True
                txtDescripcionInmueble.Text = ConsultasBaseDatos.ObtenerDescripcionInmueble2(ContadorInmuebleDeDondeVengo, 0) 'Revisado
                GCComunicacionesVengoDeInmuebles.Visible = True
                GCComunicacionesGenerales.Visible = False

                btnSoloNovedades.Visible = True
            Else
                txtDescripcionInmueble.Visible = False
                GCComunicacionesVengoDeInmuebles.Visible = False
                GCComunicacionesGenerales.Visible = True

                btnSoloNovedades.Visible = False
            End If

            ColorInicialTextos = LabelControl1.ForeColor
            ColorInicialBotonBajas = btnVerBajas.ForeColor

            ' Funciones.LlenarCombo(cmbTipoBuscar, "Tipo", "Tipo", "Tipo", , , "SELECT '' AS Tipo UNION ALL SELECT Tipo FROM Tipo")

            'chkVenta.Properties.AllowGrayed = False
            'chkAlquiler.Properties.AllowGrayed = False
            'chkTraspaso.Properties.AllowGrayed = False
            'chkVerano.Properties.AllowGrayed = False

            CargandoClientes = True
            PrimeraVez = True

            ColorInicialBotonBuscar = txtBusquedaEmailTelefono.ForeColor

            TablaGestionDocumental = "Clientes"
            CampoGestionDocumental = "Contador"
            LlenarComboCmbTipoBuscar()

            LlenarGrid()

            CargandoClientes = True
            'AddHandler BinSrc.CurrentItemChanged, AddressOf HacerCambioFilaBinding

            'Bindings

            txtObservaciones.DataBindings.Add(New Binding("EditValue", BinSrc, "Observaciones", True))

            'txtCodigo.DataBindings.Add(New Binding("EditValue", BinSrc, "Codigo", True))
            FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbTipoVenta, "TipoVenta", "TipoVenta", "TipoVenta", , , , "SELECT TipoVenta FROM TipoVenta ORDER by Orden")

            mskFechaAlta.DataBindings.Add(New Binding("EditValue", BinSrc, "FechaAlta", True))
            mskUltimaComunicacion.DataBindings.Add(New Binding("EditValue", BinSrc, "FechaUltimaComunicacion", True))
            'mskLlamada.DataBindings.Add(New Binding("EditValue", BinSrc, "FechaPuestoAlDia", True))
            'mskVisita.DataBindings.Add(New Binding("EditValue", BinSrc, "FechaNovedades", True))

            ucTipoCalentador.DataBindings.Add(New Binding("Valor", BinSrc, "TipoCalentador", True))
            ucTipoCocina.DataBindings.Add(New Binding("Valor", BinSrc, "TipoCocina", True))

            txtCodPostal.DataBindings.Add(New Binding("EditValue", BinSrc, "CodPostal", True))
            txtDireccion.DataBindings.Add(New Binding("EditValue", BinSrc, "Direccion", True))
            txtEmail.DataBindings.Add(New Binding("EditValue", BinSrc, "Email", True))

            txtFax.DataBindings.Add(New Binding("EditValue", BinSrc, "Fax", True))
            txtNIF.DataBindings.Add(New Binding("EditValue", BinSrc, "NIF", True))
            txtNombre.DataBindings.Add(New Binding("EditValue", BinSrc, "Nombre", True))
            txtPoblacion.DataBindings.Add(New Binding("EditValue", BinSrc, "Poblacion", True))
            txtProvincia.DataBindings.Add(New Binding("EditValue", BinSrc, "Provincia", True))
            txtTelefono1.DataBindings.Add(New Binding("EditValue", BinSrc, "Telefono1", True))
            txtTelefono2.DataBindings.Add(New Binding("EditValue", BinSrc, "Telefono2", True))
            txtTelefonoMovil.DataBindings.Add(New Binding("EditValue", BinSrc, "TelefonoMovil", True))

            spnPrecioVentaD.DataBindings.Add(New Binding("EditValue", BinSrc, "PrecioD", True))
            spnPrecioVentaH.DataBindings.Add(New Binding("EditValue", BinSrc, "PrecioH", True))



            spnHabitacionesD.DataBindings.Add(New Binding("EditValue", BinSrc, "HabitacionesD", True))
            spnHabitacionesH.DataBindings.Add(New Binding("EditValue", BinSrc, "HabitacionesH", True))
            spnMetrosD.DataBindings.Add(New Binding("EditValue", BinSrc, "MetrosD", True))
            spnMetrosH.DataBindings.Add(New Binding("EditValue", BinSrc, "MetrosH", True))
            spnAlturaD.DataBindings.Add(New Binding("EditValue", BinSrc, "AlturaD", True))
            spnAlturaH.DataBindings.Add(New Binding("EditValue", BinSrc, "AlturaH", True))
            spnBanos.DataBindings.Add(New Binding("EditValue", BinSrc, "Banos", True))

            spnPersonas.DataBindings.Add(New Binding("EditValue", BinSrc, "Personas", True))

            spnMTerraza.DataBindings.Add(New Binding("EditValue", BinSrc, "MTerraza", True))
            spnMJardin.DataBindings.Add(New Binding("EditValue", BinSrc, "MJardin", True))
            spnMPlaya.DataBindings.Add(New Binding("EditValue", BinSrc, "MPlaya", True))

            chkOpcionCompra.DataBindings.Add(New Binding("CheckState", BinSrc, "AlquilerOpcionCompra", True))
            chkNoQuiereRecibirEmails.DataBindings.Add(New Binding("CheckState", BinSrc, "NoQuiereRecibirEmails", True))
            chkNoQuiereRecibirSMSs.DataBindings.Add(New Binding("CheckState", BinSrc, "NoQuiereRecibirSMSs", True))
            chkNoTieneEmail.DataBindings.Add(New Binding("CheckState", BinSrc, "NoTieneEmail", True))


            chkUrbanizacion.DataBindings.Add(New Binding("CheckState", BinSrc, "Urbanizacion", True))
            chkAccesoMinusvalidos.DataBindings.Add(New Binding("CheckState", BinSrc, "AccesoMinusvalidos", True))
            chkAscensor.DataBindings.Add(New Binding("CheckState", BinSrc, "Ascensor", True))
            txtAlturaSinAscensor.DataBindings.Add(New Binding("EditValue", BinSrc, "PisoAscensor", True))
            chkGaleria.DataBindings.Add(New Binding("CheckState", BinSrc, "Galeria", True))
            chkBalcon.DataBindings.Add(New Binding("CheckState", BinSrc, "Balcon", True))
            chkPatio.DataBindings.Add(New Binding("CheckState", BinSrc, "Patio", True))
            chkTerraza.DataBindings.Add(New Binding("CheckState", BinSrc, "Terraza", True))
            chkPiscina.DataBindings.Add(New Binding("CheckState", BinSrc, "Piscina", True))
            chkJardin.DataBindings.Add(New Binding("CheckState", BinSrc, "Jardin", True))
            chkTrastero.DataBindings.Add(New Binding("CheckState", BinSrc, "Trastero", True))
            chkGaraje.DataBindings.Add(New Binding("CheckState", BinSrc, "Garaje", True))
            chkGarajeCerrado.DataBindings.Add(New Binding("CheckState", BinSrc, "GarajeCerrado", True))
            chkDuplex.DataBindings.Add(New Binding("CheckState", BinSrc, "Duplex", True))
            chkCocinaOffice.DataBindings.Add(New Binding("CheckState", BinSrc, "CocinaOffice", True))
            chkAmueblado.DataBindings.Add(New Binding("CheckState", BinSrc, "Amueblado", True))
            chkSemiamueblado.DataBindings.Add(New Binding("CheckState", BinSrc, "Semiamueblado", True))
            chkElectrodomesticos.DataBindings.Add(New Binding("CheckState", BinSrc, "Electrodomesticos", True))
            chkAireAcondicionado.DataBindings.Add(New Binding("CheckState", BinSrc, "AireAcondicionado", True))
            chkCalefaccion.DataBindings.Add(New Binding("CheckState", BinSrc, "Calefaccion", True))

            chkVistasAlMar.DataBindings.Add(New Binding("CheckState", BinSrc, "VistasAlMar", True))

            chkPrimeraLineaPlaya.DataBindings.Add(New Binding("CheckState", BinSrc, "PrimeraLineaPlaya", True))
            chkZonaComercial.DataBindings.Add(New Binding("CheckState", BinSrc, "ZonaComercial", True))

            chkPlayaDerecha.DataBindings.Add(New Binding("CheckState", BinSrc, "PlayaDerecha", True))
            chkMontana.DataBindings.Add(New Binding("CheckState", BinSrc, "Montana", True))
            chkBanco.DataBindings.Add(New Binding("CheckState", BinSrc, "Banco", True))


            LlenarTodosCombos()



            ParametrizarGrid(Gv)

            dgvx.tbCarpetaPerfiles = GL_CARPETA_PERFILES & "\" & Me.Name & "\" & dgvx.Name
            'dgvx.ContextMenuStrip = New tbContextMenuStripComponent(dgvx.tbCarpetaPerfiles, cmbPerfiles, cmbFiltros)

            MenuGrid = New tbContextMenuStripComponent(dgvx.tbCarpetaPerfiles, cmbPerfiles, cmbFiltros)
            dgvx.ContextMenuStrip = MenuGrid


            '  dgvx.ContextMenuStrip.Items.Add("Copiar Perfiles", Nothing, AddressOf CopiarPerfilesDgvX)
            MenuGrid.Items.Add("Gestión Documental", Nothing, AddressOf dgvxGestDoc)
            MenuGrid.Items.Add("Colores", Nothing, AddressOf dgvxColores)

            MenuGrid.Items.Insert(0, MenuGrid.PopMenuDarDeBajaCliente)
            MenuGrid.Items.Insert(1, MenuGrid.PopMenuGuardarSituacionActual)
            MenuGrid.Items.Insert(2, MenuGrid.PopMenuRecuperarSituacionGuardada)
            MenuGrid.Items.Insert(3, MenuGrid.Items(30))
            MenuGrid.Items.Insert(4, MenuGrid.PopMenuExportar)
            MenuGrid.Items.Insert(5, MenuGrid.PopMenuPerfiles)
            MenuGrid.Items.Insert(6, MenuGrid.PopMenuFiltros)
            MenuGrid.Items.Insert(7, MenuGrid.PopMenuCopiarCelda)
            MenuGrid.Items.Insert(8, MenuGrid.PopMenuCopiarFila)
            MenuGrid.Items.Insert(9, MenuGrid.Items(29))

            MenuGrid.PopMenuDarDeBajaCliente.Visible = True

            ConfigurarGrid()

            '     uComunicacionesDetalle = New ucComunicacionesDetalle()
            '    CrearPanelFlotanteNueva(DockManager1, PanelComunicacionesDetalle, uComunicacionesDetalle, 600, 300)



            uGestionDocumental = New ucGestionDocumental
            CrearPanelFlotanteNueva(DockManager1, PanelGestionDocumental, uGestionDocumental, 600, 300)


            CargandoClientes = False

            HabilitarBotones()
            HabilitarDesHabilitarCajas(False)

            PonerFocoRowFilterEnGridView(Gv, CampoInicialBusqueda)



            LlenarZona()

            BinSrc.MoveFirst()

            UcComunicacionesDetalle1.PanelTitulo.Visible = False

            'Dim dataSource As DataView = CreateTable(3).DefaultView
            'MyGridLookupDataSourceHelper.SetupGridLookUpEdit(cmbPerfiles, dataSource, "Name", "ID")

            'Dim MenuGrid As New tbContextMenuStripComponent(dgvx.tbCarpetaPerfiles)
            'MenuGrid.CargarPerfilesEnComboExterior(cmbPerfiles)

            If DeDondeVengo = "" Then
                PanelCajas2.Visible = False
                PanelComunicacion.Visible = False
            End If

            If ContadorInmuebleDeDondeVengo <> 0 Then
                PanelCajas2.Visible = False
                PanelComunicacion.Visible = True
            End If

            Try
                '    HacerCambioFila()
                Gv.Focus()

                Gv.FocusedRowHandle = 0
            Catch ex As Exception

            End Try
            PanelComunicacion.Visible = False
            mostrarAccionesComerciales()
            mostrarDetalle()

            If Not PanelComunicacion.Enabled AndAlso ContadorInmuebleDeDondeVengo <> 0 Then
                PanelComunicacion.Enabled = True
                GCComunicacionesVengoDeInmuebles.Enabled = True
                btnSoloNovedades.Enabled = True
                UcComunicacionesDetalle1.Enabled = False
                PanelControl1.Enabled = False
            End If



        End Sub
        'Private Shared Function CreateTable(ByVal RowCount As Integer) As DataTable
        '    Dim tbl As New DataTable()
        '    tbl.Columns.Add("Name", GetType(String))
        '    tbl.Columns.Add("ID", GetType(Integer))
        '    tbl.Columns.Add("Number", GetType(Integer))
        '    tbl.Columns.Add("Date", GetType(DateTime))
        '    For i As Integer = 0 To RowCount - 1
        '        tbl.Rows.Add(New Object() {String.Format("Name{0}", i), i, 3 - i, DateTime.Now.AddDays(i)})
        '    Next i
        '    Return tbl
        'End Function

        Private Sub HacerCambioFilaBinding(ByVal sender As Object, ByVal e As System.EventArgs)

            HacerCambioFila()

            'If CargandoClientes Then
            '    Exit Sub
            'End If

            'If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            '    Return
            'End If

            'Try
            '    LlenarObservaciones()

            '    If PanelComunicacionesDetalle.Visibility = DockVisibility.Visible Then
            '        uComunicacionesDetalle.LlenarGrid(BinSrc.Current("Contador"))
            '    End If
            'Catch ex As Exception

            'End Try






        End Sub


        Private Sub PrepararLlenarCheckCombosClientes(ByVal cmb As uc_tb_CombosCheck, ByVal Tabla As String, Optional ByVal ConBinding As Boolean = True, Optional ByVal Orden As String = "", Optional ByVal ConsultaCompleta As String = "", Optional Llenar As Boolean = True)

            Dim Baja As String = ""

            cmb.tb_TablaCompleta = Tabla
            cmb.tb_TablaEnlazada = "Clientes" & Tabla
            cmb.tb_Campo = Tabla
            cmb.tb_CampoFiltro = "ContadorCliente"
            If Llenar Then
                cmb.tb_LlenarCompleta(Orden, ConsultaCompleta)
                cmb.tb_ValorBusqueda = 0

                If PrimeraVez Then
                    cmb.DataBindings.Add(New Binding("tb_ValorBusqueda", BinSrc, "Contador", True, DataSourceUpdateMode.Never))
                End If
            End If




            'For i = 0 To cmb.DataBindings.Count - 1
            '    cmb.DataBindings.RemoveAt(0)
            'Next
            'If ConBinding Then




            '    '  cmb.DataBindings.Add(New Binding("tb_ValorBusqueda", BinSrc, "Codigo", True))
            'Else
            '    '    cmb.tb_PreparaDatosComboCheck()
            'End If


            'For Each c As CheckedListBoxItem In cmb.Properties.Items
            '    c.Enabled = True
            '    c.Value = False
            'Next
            'cmb.Text = ""

        End Sub

        'Private Sub LlenarLst(ByVal lst As uc_tb_lst, ByVal Tabla As String)


        '    lst.tb_Orden = " Fecha DESC"
        '    lst.tb_TablaEnlazada = Tabla
        '    lst.tb_Campo = FuncionesBD.fnFormatDate("Fecha", "DD/MM/YY") & "  " & GL_SQL_SUMA & "' Ref: '" & GL_SQL_SUMA & "  Referencia AS Fecha"

        '    lst.tb_CampoFiltro = "Contador"
        '    lst.DataBindings.Add(New Binding("tb_ValorBusqueda", BinSrc, "Contador", True, DataSourceUpdateMode.Never))


        'End Sub

        Public Sub LlenarGrid()

            CargandoClientes = True

            Dim FiltroSelect As String

            'If FiltroBusqueda = "" Then
            '    FiltroSelect = ""
            'Else
            '    FiltroSelect = " AND (Telefono1 LIKE '%" & FiltroBusqueda & "%' OR  Telefono2 LIKE '%" & FiltroBusqueda & "%' OR  TelefonoMovil LIKE '%" & FiltroBusqueda & "%' OR  Email LIKE '%" & FiltroBusqueda & "%' OR Nombre LIKE '%" & FiltroBusqueda & "%' OR Fax LIKE '%" & FiltroBusqueda & "%')"
            'End If

            If BuscandoPorTelefonoEmail2 AndAlso txtBusquedaEmailTelefono.Text.Trim <> "" Then
                FiltroSelect = " AND (Telefono1 LIKE '%" & txtBusquedaEmailTelefono.Text.Trim & "%' OR  Telefono2 LIKE '%" & txtBusquedaEmailTelefono.Text.Trim & "%' OR  TelefonoMovil LIKE '%" & txtBusquedaEmailTelefono.Text.Trim & "%' OR  Email LIKE '%" & txtBusquedaEmailTelefono.Text.Trim & "%' OR Nombre LIKE '%" & txtBusquedaEmailTelefono.Text.Trim & "%' OR Fax LIKE '%" & txtBusquedaEmailTelefono.Text.Trim & "%')"
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

            Dim FiltroTipo As String = ""
            If cmbTipoBuscar.EditValue <> "" Then
                FiltroTipo = " AND Contador IN (SELECT ContadorCliente FROM ClientesTipo WHERE Tipo = '" & Funciones.pf_ReplaceComillas(cmbTipoBuscar.EditValue) & "')"
            End If


            Dim FiltroTotal As String = ""
            Dim FiltroInmueble As String = ""
            Dim SubconsultaNovedad As String
            'Dim aaa As String = "SELECT " & _
            '                      Funciones.SQL_CASE({Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ,'01/01/1900'") & ">" & Funciones.SQL_CASE_ISNULL("FechaEmailListado,'01/01/1900'"), Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ,'01/01/1900'") & "<=" & Funciones.SQL_CASE_ISNULL("FechaEmailListado,'01/01/1900'")}, {1, 0}) & _
            '                       " FROM Clientes"


            If DeDondeVengo = GL_VENGO_DE_INMUEBLES Then
                ' FiltroInmueble = " Contador IN (" & FuncionesBD.ObtenerClientesQueCuadran(ContadorInmuebleDeDondeVengo) & ")"
                If PulsadoVerNovedades Then
                    FiltroInmueble = "(" & FuncionesBD.ObtenerReferenciasQueCuadranEnSelectCliente(ContadorInmuebleDeDondeVengo, True, "Novedades", "COUNT(*)") & ") > 0"
                Else
                    FiltroInmueble = "(" & FuncionesBD.ObtenerReferenciasQueCuadranEnSelectCliente(ContadorInmuebleDeDondeVengo, True, "", "COUNT(*)") & ") > 0"
                End If

                'SubconsultaNovedad = ", " & Funciones.SQL_CONVERT("BIT", " " & _
                '            Funciones.SQL_CASE({Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & ">" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))), Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & "<=" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900")))}, {1, 0}) & _
                '             "") & " AS Novedad "

                'SubconsultaNovedad = ", " & Funciones.SQL_CONVERT("BIT", " " & _
                '            Funciones.SQL_CASE({Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & ">" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & " AND C.Contador IN (SELECT DISTINCT ContadorCliente FROM ClientesComunicaciones WHERE ContadorInmueble = " & ContadorInmuebleDeDondeVengo & ") ", Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & "<=" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900")))}, {1, 0}) & _
                '             "") & " AS Novedad "

                'SubconsultaNovedad = ", " & Funciones.SQL_CONVERT("BIT", " " & _
                '          Funciones.SQL_CASE({Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & "<" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & " AND C.Contador IN (SELECT DISTINCT ContadorCliente FROM ClientesComunicaciones WHERE ContadorInmueble = " & ContadorInmuebleDeDondeVengo & ") ", Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & "<=" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900")))}, {1, 0}) & _
                '           "") & " AS Novedad "


                'SubconsultaNovedad = ", " & Funciones.SQL_CONVERT("BIT", " " & _
                '       Funciones.SQL_CASE({Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & "<" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & " AND (SELECT COUNT(*) FROM ClientesComunicaciones WHERE ContadorCliente = C.Contador AND ContadorInmueble = " & ContadorInmuebleDeDondeVengo & ") = 0 ", Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & ">=" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & " OR (SELECT COUNT(*) FROM ClientesComunicaciones WHERE ContadorCliente = C.Contador AND ContadorInmueble = " & ContadorInmuebleDeDondeVengo & ") = 0 "}, {1, 0}) & _
                '        "") & " AS Novedad "


                '         SubconsultaNovedad = ", " & Funciones.SQL_CONVERT("BIT", " " & _
                'Funciones.SQL_CASE({Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & "<" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & " OR (SELECT COUNT(*) FROM ClientesComunicaciones WHERE ContadorCliente = 24958 AND ContadorInmueble = " & ContadorInmuebleDeDondeVengo & ") > 0 ", Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & "<=" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900")))}, {1, 0}) & _
                ' "") & " AS Novedad "



                '         SubconsultaNovedad = ", " & Funciones.SQL_CONVERT("BIT", " " & _
                'Funciones.SQL_CASE({Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & "<" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & "  ", Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & "<=" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900")))}, {1, 0}) & _
                ' "") & " AS Novedad "

                '         SubconsultaNovedad = ", " & Funciones.SQL_CONVERT("BIT", "0") & " AS Novedad "
                '      WhereTipoBusqueda = " (" & Funciones.SQL_CASE_ISNULL("FechaUltimoCambio," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & " > " & Funciones.SQL_CASE_ISNULL("C.FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & _
                '" AND (SELECT COUNT(*) FROM ClientesComunicaciones WHERE ContadorCliente = C.Contador AND ContadorInmueble = I.Contador)= 0  )"


                '       SubconsultaNovedad = ", " & Funciones.SQL_CONVERT("BIT", "0") & " AS Novedad "
                ' SubconsultaNovedad = ", " & Funciones.SQL_CONVERT("BIT", " " & _
                'Funciones.SQL_CASE({Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & "<" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & " OR C.Contador IN (SELECT DISTINCT ContadorCliente FROM ClientesComunicaciones WHERE ContadorInmueble = " & ContadorInmuebleDeDondeVengo & "), ELSE"}, {1, 0}) & _
                ' "") & " AS Novedad "

                ' SubconsultaNovedad = Replace(SubconsultaNovedad, ", ELSE ", ",0, 'ELSE' ")





                '  SubconsultaNovedad = ", " & Funciones.SQL_CONVERT("BIT", "0") & " AS Novedad "
                '   SubconsultaNovedad = Replace(SubconsultaNovedad, ", ELSE THEN", "THEN 0 ELSE")





                'SubconsultaNovedad = ", " & Funciones.SQL_CONVERT("BIT", " " & _
                '   Funciones.SQL_CASE({Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & "<" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & " AND (SELECT COUNT(*) FROM ClientesComunicaciones WHERE ContadorCliente = C.Contador AND ContadorInmueble = " & ContadorInmuebleDeDondeVengo & ") = 0 ", Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & ">=" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & " OR (SELECT COUNT(*) FROM ClientesComunicaciones WHERE ContadorCliente = C.Contador AND ContadorInmueble = " & ContadorInmuebleDeDondeVengo & ") = 0 "}, {1, 0}) & _
                '    "") & " AS Novedad "

                SubconsultaNovedad = ", " & Funciones.SQL_CONVERT("BIT", " " & _
                   Funciones.SQL_CASE({Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & "<" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & " OR (SELECT COUNT(*) FROM ClientesComunicaciones WHERE ContadorCliente = C.Contador AND ContadorInmueble = " & ContadorInmuebleDeDondeVengo & ") > 0 ", Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & ">=" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900")))}, {0, 1}) & _
                    "") & " AS Novedad "


            Else

                SubconsultaNovedad = ", " & Funciones.SQL_CONVERT("BIT", "0") & " AS Novedad "
            End If

            If DeDondeVengo = "Alarmas" Then
                FiltroInmueble = "  Contador = " & ContadorInmuebleDeDondeVengo
            End If

            If FiltroSelect = "" Then
                If FiltroInmueble <> "" Then
                    FiltroTotal = " AND " & FiltroInmueble
                End If

            Else
                FiltroTotal = FiltroSelect
                If FiltroInmueble <> "" Then
                    FiltroTotal = FiltroTotal & " AND " & FiltroInmueble
                End If

            End If


            Dim SubConsultaComunicaciones As String = ""

            ''lo quito pq no quiren ver estas columnas
            'Dim SubConsultaFechaEmail = "(SELECT MAX(Fecha) FROM ClientesComunicaciones WHERE ContadorInmueble = " & ContadorInmuebleDeDondeVengo & " AND ContadorCliente = C.Contador AND Tipo = 'EMAILDETALLE') AS FEmail, "
            'Dim SubConsultaFechaLlamada = "(SELECT MAX(Fecha) FROM ClientesComunicaciones WHERE ContadorInmueble = " & ContadorInmuebleDeDondeVengo & " AND ContadorCliente = C.Contador AND Tipo = 'LLAMADA') AS FLlamada, "


            'If ContadorInmuebleDeDondeVengo <> 0 Then
            '    SubConsultaComunicaciones = SubConsultaFechaEmail & SubConsultaFechaLlamada ' & SubConsultaFechaSMS
            'End If

            ''lo quito pq no quiren ver estas columnas

            If BuscandoPorTelefonoEmail2 AndAlso txtBusquedaEmailTelefono.Text.Trim <> "" Then
                TextoBaja = ""
            End If

            Dim Campos As String = "*"

            'If FiltroBusqueda <> "" Then

            '    SentenciaSQL = "SELECT " & Campos & " ," & Funciones.SQL_CONVERT("BIT", "(SELECT COUNT(*) FROM FichasAlquiler WHERE ContadorCliente=Contador)") & " AS FichaAlquiler" & SubconsultaNovedad & " FROM " & GL_TablaClientes & " C WHERE CodigoEmpresa = " & DatosEmpresa.Codigo & FiltroTotal & TextoBaja & FiltroTipo

            'Else
            '    SentenciaSQL = "SELECT " & SubConsultaComunicaciones & " " & Campos & ", " & Funciones.SQL_CONVERT("BIT", "(SELECT COUNT(*) FROM FichasAlquiler WHERE ContadorCliente=Contador)") & " AS FichaAlquiler" & SubconsultaNovedad & " FROM " & GL_TablaClientes & " C WHERE CodigoEmpresa = " & DatosEmpresa.Codigo & FiltroTotal & TextoBaja & FiltroTipo & _
            '                                  " ORDER BY Nombre"
            'End If
            If DeDondeVengo = GL_VENGO_DE_VISITAS Then
                FiltroTotal &= " AND Contador=" & ContadorClienteAlQueVoy
            End If

            If BuscandoPorTelefonoEmail2 AndAlso txtBusquedaEmailTelefono.Text.Trim <> "" Then

                SentenciaSQL = "SELECT " & Campos & " ," & Funciones.SQL_CONVERT("BIT", "(SELECT COUNT(*) FROM FichasAlquiler WHERE ContadorCliente=Contador)") & " AS FichaAlquiler" & SubconsultaNovedad & " FROM " & GL_TablaClientes & " C WHERE CodigoEmpresa = " & DatosEmpresa.Codigo & FiltroTotal & TextoBaja & FiltroTipo

            Else
                SentenciaSQL = "SELECT " & SubConsultaComunicaciones & " " & Campos & ", " & Funciones.SQL_CONVERT("BIT", "(SELECT COUNT(*) FROM FichasAlquiler WHERE ContadorCliente=Contador)") & " AS FichaAlquiler" & SubconsultaNovedad & " FROM " & GL_TablaClientes & " C WHERE CodigoEmpresa = " & DatosEmpresa.Codigo & FiltroTotal & TextoBaja & FiltroTipo & _
                                              " ORDER BY Nombre"
            End If


            bd = New BaseDatos
            bd.LlenarDataSet(SentenciaSQL, TablaMantenimiento, , False, True)


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
            '   
            BinSrc.DataSource = bd.ds
            BinSrc.DataMember = TablaMantenimiento

            dgvx.BindingContext = New BindingContext()
            dgvx.DataSource = Nothing
            dgvx.DataSource = BinSrc

            Gv = Nothing
            Gv = dgvx.MainView
            'dgvx.ForceInitialize()

            'guardamos el perfil con todas las columnas de la bbdd para luego comparar con los perfiles si existe alguna columna nueva para añadir

            If PrimeraVez Then
                AP = New ActualizaPerfil(Gv)
            End If

            CargandoClientes = False

            Try
                If Not PrimeraVez Then
                    HacerCambioFila()
                End If

            Catch ex As Exception

            End Try

            BuscandoPorTelefonoEmail2 = False

        End Sub
        'Public Sub LlenarGrid()

        '    CargandoClientes = True

        '    Dim FiltroSelect As String

        '    If FiltroBusqueda = "" Then
        '        FiltroSelect = ""
        '    Else
        '        FiltroSelect = " AND (Telefono1 LIKE '%" & FiltroBusqueda & "%' OR  Telefono2 LIKE '%" & FiltroBusqueda & "%' OR  TelefonoMovil LIKE '%" & FiltroBusqueda & "%' OR  Email LIKE '%" & FiltroBusqueda & "%' OR Nombre LIKE '%" & FiltroBusqueda & "%' OR Fax LIKE '%" & FiltroBusqueda & "%')"

        '    End If
        '    Dim TextoBaja As String = ""

        '    If PulsadoVerBajas Then
        '        TextoBaja = " AND Baja =" & GL_SQL_VALOR_1 & " "
        '    Else
        '        TextoBaja = " AND Baja = 0 "
        '    End If

        '    Dim FiltroTipo As String = ""
        '    If cmbTipoBuscar.EditValue <> "" Then
        '        FiltroTipo = " AND Contador IN (SELECT ContadorCliente FROM ClientesTipo WHERE Tipo = '" & Funciones.pf_ReplaceComillas(cmbTipoBuscar.EditValue) & "')"
        '    End If


        '    Dim FiltroTotal As String = ""
        '    Dim FiltroInmueble As String = ""
        '    Dim SubconsultaNovedad As String
        '    'Dim aaa As String = "SELECT " & _
        '    '                      Funciones.SQL_CASE({Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ,'01/01/1900'") & ">" & Funciones.SQL_CASE_ISNULL("FechaEmailListado,'01/01/1900'"), Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ,'01/01/1900'") & "<=" & Funciones.SQL_CASE_ISNULL("FechaEmailListado,'01/01/1900'")}, {1, 0}) & _
        '    '                       " FROM Clientes"


        '    If DeDondeVengo = GL_VENGO_DE_INMUEBLES Then
        '        ' FiltroInmueble = " Contador IN (" & FuncionesBD.ObtenerClientesQueCuadran(ContadorInmuebleDeDondeVengo) & ")"
        '        If PulsadoVerNovedades Then
        '            FiltroInmueble = "(" & FuncionesBD.ObtenerReferenciasQueCuadranEnSelectCliente(ContadorInmuebleDeDondeVengo, True, "Novedades", "COUNT(*)") & ") > 0"
        '        Else
        '            FiltroInmueble = "(" & FuncionesBD.ObtenerReferenciasQueCuadranEnSelectCliente(ContadorInmuebleDeDondeVengo, True, "", "COUNT(*)") & ") > 0"
        '        End If

        '        'SubconsultaNovedad = ", " & Funciones.SQL_CONVERT("BIT", " " & _
        '        '            Funciones.SQL_CASE({Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & ">" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))), Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & "<=" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900")))}, {1, 0}) & _
        '        '             "") & " AS Novedad "

        '        'SubconsultaNovedad = ", " & Funciones.SQL_CONVERT("BIT", " " & _
        '        '            Funciones.SQL_CASE({Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & ">" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & " AND C.Contador IN (SELECT DISTINCT ContadorCliente FROM ClientesComunicaciones WHERE ContadorInmueble = " & ContadorInmuebleDeDondeVengo & ") ", Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & "<=" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900")))}, {1, 0}) & _
        '        '             "") & " AS Novedad "

        '        'SubconsultaNovedad = ", " & Funciones.SQL_CONVERT("BIT", " " & _
        '        '          Funciones.SQL_CASE({Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & "<" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & " AND C.Contador IN (SELECT DISTINCT ContadorCliente FROM ClientesComunicaciones WHERE ContadorInmueble = " & ContadorInmuebleDeDondeVengo & ") ", Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & "<=" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900")))}, {1, 0}) & _
        '        '           "") & " AS Novedad "


        '        'SubconsultaNovedad = ", " & Funciones.SQL_CONVERT("BIT", " " & _
        '        '       Funciones.SQL_CASE({Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & "<" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & " AND (SELECT COUNT(*) FROM ClientesComunicaciones WHERE ContadorCliente = C.Contador AND ContadorInmueble = " & ContadorInmuebleDeDondeVengo & ") = 0 ", Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & ">=" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & " OR (SELECT COUNT(*) FROM ClientesComunicaciones WHERE ContadorCliente = C.Contador AND ContadorInmueble = " & ContadorInmuebleDeDondeVengo & ") = 0 "}, {1, 0}) & _
        '        '        "") & " AS Novedad "


        '        '         SubconsultaNovedad = ", " & Funciones.SQL_CONVERT("BIT", " " & _
        '        'Funciones.SQL_CASE({Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & "<" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & " OR (SELECT COUNT(*) FROM ClientesComunicaciones WHERE ContadorCliente = 24958 AND ContadorInmueble = " & ContadorInmuebleDeDondeVengo & ") > 0 ", Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & "<=" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900")))}, {1, 0}) & _
        '        ' "") & " AS Novedad "



        '        '         SubconsultaNovedad = ", " & Funciones.SQL_CONVERT("BIT", " " & _
        '        'Funciones.SQL_CASE({Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & "<" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & "  ", Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & "<=" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900")))}, {1, 0}) & _
        '        ' "") & " AS Novedad "

        '        '         SubconsultaNovedad = ", " & Funciones.SQL_CONVERT("BIT", "0") & " AS Novedad "
        '        '      WhereTipoBusqueda = " (" & Funciones.SQL_CASE_ISNULL("FechaUltimoCambio," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & " > " & Funciones.SQL_CASE_ISNULL("C.FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & _
        '        '" AND (SELECT COUNT(*) FROM ClientesComunicaciones WHERE ContadorCliente = C.Contador AND ContadorInmueble = I.Contador)= 0  )"


        '        '       SubconsultaNovedad = ", " & Funciones.SQL_CONVERT("BIT", "0") & " AS Novedad "
        '        ' SubconsultaNovedad = ", " & Funciones.SQL_CONVERT("BIT", " " & _
        '        'Funciones.SQL_CASE({Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & "<" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & " OR C.Contador IN (SELECT DISTINCT ContadorCliente FROM ClientesComunicaciones WHERE ContadorInmueble = " & ContadorInmuebleDeDondeVengo & "), ELSE"}, {1, 0}) & _
        '        ' "") & " AS Novedad "

        '        ' SubconsultaNovedad = Replace(SubconsultaNovedad, ", ELSE ", ",0, 'ELSE' ")





        '        '  SubconsultaNovedad = ", " & Funciones.SQL_CONVERT("BIT", "0") & " AS Novedad "
        '        '   SubconsultaNovedad = Replace(SubconsultaNovedad, ", ELSE THEN", "THEN 0 ELSE")





        '        'SubconsultaNovedad = ", " & Funciones.SQL_CONVERT("BIT", " " & _
        '        '   Funciones.SQL_CASE({Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & "<" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & " AND (SELECT COUNT(*) FROM ClientesComunicaciones WHERE ContadorCliente = C.Contador AND ContadorInmueble = " & ContadorInmuebleDeDondeVengo & ") = 0 ", Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & ">=" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & " OR (SELECT COUNT(*) FROM ClientesComunicaciones WHERE ContadorCliente = C.Contador AND ContadorInmueble = " & ContadorInmuebleDeDondeVengo & ") = 0 "}, {1, 0}) & _
        '        '    "") & " AS Novedad "

        '        SubconsultaNovedad = ", " & Funciones.SQL_CONVERT("BIT", " " & _
        '           Funciones.SQL_CASE({Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & "<" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & " OR (SELECT COUNT(*) FROM ClientesComunicaciones WHERE ContadorCliente = C.Contador AND ContadorInmueble = " & ContadorInmuebleDeDondeVengo & ") > 0 ", Funciones.SQL_CASE_ISNULL("(SELECT FechaUltimoCambio FROM Inmuebles WHERE Contador = " & ContadorInmuebleDeDondeVengo & ") ," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & ">=" & Funciones.SQL_CASE_ISNULL("FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900")))}, {0, 1}) & _
        '            "") & " AS Novedad "


        '    Else

        '        SubconsultaNovedad = ", " & Funciones.SQL_CONVERT("BIT", "0") & " AS Novedad "
        '    End If

        '    If DeDondeVengo = "Alarmas" Then
        '        FiltroInmueble = "  Contador = " & ContadorInmuebleDeDondeVengo
        '    End If

        '    If FiltroSelect = "" Then
        '        If FiltroInmueble <> "" Then
        '            FiltroTotal = " AND " & FiltroInmueble
        '        End If

        '    Else
        '        FiltroTotal = FiltroSelect
        '        If FiltroInmueble <> "" Then
        '            FiltroTotal = FiltroTotal & " AND " & FiltroInmueble
        '        End If

        '    End If

        '    Dim SubConsultaFechaEmail = "(SELECT MAX(Fecha) FROM ClientesComunicaciones WHERE ContadorInmueble = " & ContadorInmuebleDeDondeVengo & " AND ContadorCliente = C.Contador AND Tipo = 'EMAILDETALLE') AS FEmail, "
        '    Dim SubConsultaFechaLlamada = "(SELECT MAX(Fecha) FROM ClientesComunicaciones WHERE ContadorInmueble = " & ContadorInmuebleDeDondeVengo & " AND ContadorCliente = C.Contador AND Tipo = 'LLAMADA') AS FLlamada, "


        '    'Dim SubConsultaFechaEmail = " FechaAlta  AS FEmail, "
        '    'Dim SubConsultaFechaLlamada = " FechaAlta  AS FLlamada, "


        '    '     Dim SubConsultaFechaSMS = "(SELECT TOP 1 Fecha FROM ClientesComunicacionesSMS WHERE ContadorInmueble = " & ContadorInmuebleDeDondeVengo & " AND ContadorCliente = C.Contador ORDER BY Fecha DESC) AS FSMS, "

        '    Dim SubConsultaComunicaciones As String = ""
        '    If ContadorInmuebleDeDondeVengo <> 0 Then
        '        SubConsultaComunicaciones = SubConsultaFechaEmail & SubConsultaFechaLlamada ' & SubConsultaFechaSMS
        '    End If


        '    If FiltroBusqueda <> "" Then
        '        TextoBaja = ""
        '    End If


        '    Dim Campos As String = "*"

        '    If FiltroBusqueda <> "" Then

        '        SentenciaSQL = "SELECT " & Campos & " ," & Funciones.SQL_CONVERT("BIT", "(SELECT COUNT(*) FROM FichasAlquiler WHERE ContadorCliente=Contador)") & " AS FichaAlquiler" & SubconsultaNovedad & " FROM " & GL_TablaClientes & " C WHERE CodigoEmpresa = " & DatosEmpresa.Codigo & FiltroTotal & TextoBaja & FiltroTipo

        '    Else
        '        SentenciaSQL = "SELECT " & SubConsultaComunicaciones & " " & Campos & ", " & Funciones.SQL_CONVERT("BIT", "(SELECT COUNT(*) FROM FichasAlquiler WHERE ContadorCliente=Contador)") & " AS FichaAlquiler" & SubconsultaNovedad & " FROM " & GL_TablaClientes & " C WHERE CodigoEmpresa = " & DatosEmpresa.Codigo & FiltroTotal & TextoBaja & FiltroTipo & _
        '                                      " ORDER BY Nombre"
        '    End If



        '    bd = New BaseDatos
        '    bd.LlenarDataSet(SentenciaSQL, TablaMantenimiento, , False, True)


        '    'With bd.ds.Tables(TablaMantenimiento).Columns("Contador")
        '    '    .AutoIncrement = True
        '    '    '    .AutoIncrementSeed =1
        '    '    .AutoIncrementStep = 1
        '    'End With

        '    Dim key(0) As DataColumn
        '    key(0) = bd.ds.Tables(TablaMantenimiento).Columns("Contador")
        '    bd.ds.Tables(TablaMantenimiento).PrimaryKey = key


        '    If PrimeraVez Then
        '        BinSrc = New BindingSource
        '    End If
        '    '   
        '    BinSrc.DataSource = bd.ds
        '    BinSrc.DataMember = TablaMantenimiento

        '    dgvx.BindingContext = New BindingContext()
        '    dgvx.DataSource = Nothing
        '    dgvx.DataSource = BinSrc

        '    Gv = Nothing
        '    Gv = dgvx.MainView
        '    'dgvx.ForceInitialize()

        '    'guardamos el perfil con todas las columnas de la bbdd para luego comparar con los perfiles si existe alguna columna nueva para añadir

        '    If PrimeraVez Then
        '        AP = New ActualizaPerfil(Gv)
        '    End If

        '    CargandoClientes = False

        '    Try
        '        If Not PrimeraVez Then
        '            HacerCambioFila()
        '        End If

        '    Catch ex As Exception

        '    End Try

        'End Sub
        Private Sub PonerColoresClientes()
            Dim condition1 As StyleFormatCondition

         
            'condition1 = New DevExpress.XtraGrid.StyleFormatCondition()
            'condition1.Appearance.BackColor = GL_ColorLlamada_EMail
            'condition1.Appearance.Options.UseBackColor = True
            'condition1.Condition = FormatConditionEnum.Expression
            'condition1.Expression = "[FEmail] <> NULL AND [FLlamada] <> NULL"
            'Gv.FormatConditions.Add(condition1)

            'condition1 = New DevExpress.XtraGrid.StyleFormatCondition()
            'condition1.Appearance.BackColor = GL_ColorEmail
            'condition1.Appearance.Options.UseBackColor = True
            'condition1.Condition = FormatConditionEnum.Expression
            'condition1.Expression = "[FEmail] <> NULL AND [FLlamada] is NULL"
            'Gv.FormatConditions.Add(condition1)

            'condition1 = New DevExpress.XtraGrid.StyleFormatCondition()
            'condition1.Appearance.BackColor = GL_ColorLlamada
            'condition1.Appearance.Options.UseBackColor = True
            'condition1.Condition = FormatConditionEnum.Expression
            'condition1.Expression = "[FLlamada] is NULL"
            'Gv.FormatConditions.Add(condition1)

            ''condition1 = New DevExpress.XtraGrid.StyleFormatCondition()
            ''condition1.Appearance.BackColor = Color.Plum
            ''condition1.Appearance.Options.UseBackColor = True
            ''condition1.Condition = FormatConditionEnum.Expression
            ''condition1.Expression = "[FSMS] <> NULL"
            ''Gv.FormatConditions.Add(condition1)

          

          

            condition1 = New DevExpress.XtraGrid.StyleFormatCondition()
            condition1.Appearance.BackColor = Color.Red
            condition1.Appearance.ForeColor = Color.White
            condition1.Appearance.Options.UseBackColor = True
            condition1.Condition = FormatConditionEnum.Expression
            condition1.Expression = "[Baja] =" & GL_SQL_VALOR_1
            Gv.FormatConditions.Add(condition1)

            If ContadorInmuebleDeDondeVengo <> 0 Then
                condition1 = New DevExpress.XtraGrid.StyleFormatCondition()
                condition1.Appearance.BackColor = GL_ColorNovedad
                condition1.Appearance.Options.UseBackColor = True
                condition1.Condition = FormatConditionEnum.Expression
                'condition1.Expression = "[Novedad] =" & GL_SQL_VALOR_1
                condition1.Expression = "[Novedad] =0"
                Gv.FormatConditions.Add(condition1)

            End If


            If Gv.Columns("Baja") IsNot Nothing Then
                Gv.Columns("Baja").Visible = False
                Gv.Columns("Baja").OptionsColumn.AllowShowHide = False
            End If

        End Sub
        Public Sub FocusedColor()
            Dim b As Color
            Dim a As DataRowView = Gv.GetFocusedRow
            With Gv.Appearance.FocusedRow
                .ForeColor = Color.Black
                Try

                    'If ContadorInmuebleDeDondeVengo <> 0 AndAlso Not IsDBNull(a.Item("Novedad")) And a.Item("Novedad") = 0 Then
                    '    .BackColor = GL_ColorNovedadSeleccionado
                    '    Gv.Appearance.FocusedCell.BackColor = Gv.Appearance.FocusedRow.BackColor
                    '    .ForeColor = Color.White
                    '    Exit Sub
                    'End If
                    'If Not IsDBNull(a.Item("FEmail")) And IsDBNull(a.Item("FLlamada")) Then
                    '    'b = GL_ColorEmail
                    '    '.BackColor = Color.FromArgb(255, b.R + 50, b.G + 15, b.B + 15)
                    '    .BackColor = GL_ColorLlamada_EMailSeleccionado
                    '    Gv.Appearance.FocusedCell.BackColor = Gv.Appearance.FocusedRow.BackColor
                    '    Exit Sub
                    'End If
                    'If Not IsDBNull(a.Item("FEmail")) And Not IsDBNull(a.Item("FLlamada")) Then
                    '    .BackColor = GL_ColorLlamada_EMailSeleccionado
                    '    Gv.Appearance.FocusedCell.BackColor = Gv.Appearance.FocusedRow.BackColor
                    '    Exit Sub
                    'End If


                    'If Not IsDBNull(a.Item("FSMS")) Then
                    '    b = Color.Plum

                    '    .BackColor = Color.FromArgb(255, b.R + 30, b.G + 50, b.B + 30)
                    '    Gv.Appearance.FocusedCell.BackColor = Gv.Appearance.FocusedRow.BackColor
                    '    Exit Sub
                    'End If


                    If Not IsDBNull(a.Item("FLlamada")) Then
                        .BackColor = GL_ColorLlamadaSeleccionado
                        Gv.Appearance.FocusedCell.BackColor = Gv.Appearance.FocusedRow.BackColor
                        Exit Sub
                    End If
                Catch ex As Exception

                End Try
                'If Gv.Columns("Mark") IsNot Nothing Then
                Try
                    If a.Item("Baja") = True Then
                        b = GL_ColorBajaSeleccionado
                        .BackColor = Color.FromArgb(255, b.R, b.G + 100, b.B + 100)
                        Gv.Appearance.FocusedCell.BackColor = Gv.Appearance.FocusedRow.BackColor
                        Exit Sub
                    End If
                    'End If
                Catch
                End Try
                .BackColor = Color.FromArgb(255, 80, 160, 240)
                .ForeColor = Color.White

            End With


            Gv.Appearance.FocusedCell.BackColor = Gv.Appearance.FocusedRow.BackColor
            Gv.Appearance.HideSelectionRow.BackColor = Gv.Appearance.FocusedRow.BackColor
            Gv.Appearance.HideSelectionRow.ForeColor = Gv.Appearance.FocusedRow.ForeColor

        End Sub
        Private Sub AnadirONoLasColumnasDeFecha()

            PonerColoresClientes()

            Try

                If ContadorInmuebleDeDondeVengo = 0 Then
                    'Gv.Columns("FechaAvisadoInmueble").OptionsColumn.AllowShowHide = False
                    'Gv.Columns("FechaAvisadoInmueble").Visible = False

                    Gv.Columns("Novedad").OptionsColumn.AllowShowHide = False
                    Gv.Columns("Novedad").Visible = False


                   
                Else
                    'Gv.Columns("FechaAvisadoInmueble").OptionsColumn.AllowShowHide = True
                    'Gv.Columns("FechaAvisadoInmueble").Visible = True

                    Gv.Columns("Novedad").OptionsColumn.AllowShowHide = True
                    Gv.Columns("Novedad").Visible = True


                End If

         
            Catch ex As Exception
                MensajeError(ex.Message)
            End Try
        End Sub

        Private Sub ConfigurarGrid()

            If Not PrimeraVez Then
                Exit Sub
            End If

            PrimeraVez = False
            If dgvx.tbEstablecerPerfilPredeterminado() Then
                cmbPerfiles.EditValue = dgvx.tbPerfilPredeterminado
                cmbPerfiles.Text = dgvx.tbPerfilPredeterminado & "(Predeterminado)"

                AnadirONoLasColumnasDeFecha()
                Exit Sub
            End If
            If AnadirCheckColunm Then
                Try
                    dgvx.tb_AnadirColumnaCheck = True



                Catch ex As Exception

                End Try

                '   ColumnaCheck = New GridCheckMarksSelection(Gv)


            End If

            AnadirONoLasColumnasDeFecha()

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

            Gv.Columns("Nombre").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending


            Gv.Columns("FechaAlta").Caption = "F Alta"
            Gv.Columns("FechaEmailListado").Caption = "F Listado"
            Gv.Columns("FechaLlamada").Caption = "F Llamada"
            Gv.Columns("FechaEmailFijo").Caption = "F Fijo"
            Gv.Columns("FechaVisitaOficina").Caption = "F Oficina"
            Gv.Columns("FechaNoContesta").Caption = "F No Cont."
            Gv.Columns("FechaUltimaComunicacion").Caption = "F Ult. Comunicación"
            Gv.Columns("FechaPuestoAlDia").Caption = "F Puesto Día"
            Gv.Columns("FechaNovedades").Caption = "F Novedades"
            Gv.Columns("TelefonoMovil").Caption = "Teléfono 3"
            Gv.Columns("TipoVenta").Caption = "Oferta"

            Gv.Columns("TipoVenta").Width = 100
            Gv.Columns("Telefono1").Width = 100
            Gv.Columns("Telefono2").Width = 100
            Gv.Columns("TelefonoMovil").Width = 100
            Gv.Columns("Poblacion").Width = 200
            Gv.Columns("Email").Width = 150
            
            With Gv.Columns("FechaAlta")
                .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .DisplayFormat.FormatString = "dd/MM/yy"
                .AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
                .Width = 80
            End With

            With Gv.Columns("FechaEmailListado")
                .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .DisplayFormat.FormatString = "dd/MM/yy"
                .AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
                .Width = 80
            End With

            With Gv.Columns("FechaLlamada")
                .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .DisplayFormat.FormatString = "dd/MM/yy"
                .AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
                .Width = 80
            End With

            With Gv.Columns("FechaEmailFijo")
                .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .DisplayFormat.FormatString = "dd/MM/yy"
                .AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
                .Width = 80
            End With

            With Gv.Columns("FechaNoContesta")
                .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .DisplayFormat.FormatString = "dd/MM/yy"
                .AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
                .Width = 80
            End With

            With Gv.Columns("FechaUltimaComunicacion")
                .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .DisplayFormat.FormatString = "dd/MM/yy"
                .AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
                .Width = 80
            End With

            With Gv.Columns("FechaPuestoAlDia")
                .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .DisplayFormat.FormatString = "dd/MM/yy"
                .AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
                .Width = 80
            End With

            With Gv.Columns("FechaUltimaComunicacion")
                .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .DisplayFormat.FormatString = "dd/MM/yy"
                .AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
                .Width = 80
            End With

            With Gv.Columns("FechaNovedades")
                .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .DisplayFormat.FormatString = "dd/MM/yy"
                .AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
                .Width = 80
            End With
 

  



            Gv.Columns("FechaAvisadoInmueble").OptionsColumn.AllowShowHide = False
            Gv.Columns("FechaAvisadoInmueble").Visible = False

            Gv.Columns("FechaSMS").OptionsColumn.AllowShowHide = False
            Gv.Columns("FechaSMS").Visible = False

            Gv.Columns("CodigoEmpresa").OptionsColumn.AllowShowHide = False
            Gv.Columns("CodigoEmpresa").Visible = False

            Gv.Columns("Contador").Visible = False

            Gv.Columns("Cocina").Visible = False
            Gv.Columns("Calefaccion").Visible = False

            'Gv.Columns("Contador").OptionsColumn.AllowShowHide = False
            'Gv.Columns("Contador").Visible = False

            Gv.Columns("Delegacion").OptionsColumn.AllowShowHide = False
            Gv.Columns("Delegacion").Visible = False

            'Gv.Columns("MarcaDeTiempo").OptionsColumn.AllowShowHide = False
            'Gv.Columns("MarcaDeTiempo").Visible = False

            Gv.Columns("PlayaDerecha").Visible = False
            Gv.Columns("Montana").Visible = False

            Gv.Columns("ContadorEmpleado").Visible = False
            Gv.Columns("NoQuiereRecibirEmails").Visible = False
            Gv.Columns("Observaciones").Visible = False
            Gv.Columns("FichaAlquiler").Visible = False
            Gv.Columns("NoTieneEmail").Visible = False

            Gv.Columns("ComoConociste").Visible = False
            Gv.Columns("FechaAlta").Visible = False
            Gv.Columns("FechaUltimaComunicacion").Visible = False
            Gv.Columns("FechaPuestoAlDia").Visible = False
            Gv.Columns("FechaNovedades").Visible = False


            Gv.Columns("NIF").Visible = False
            Gv.Columns("Direccion").Visible = False
            '   Gv.Columns("Poblacion").Visible = False
            Gv.Columns("CodPostal").Visible = False
            Gv.Columns("Provincia").Visible = False
            Gv.Columns("Pais").Visible = False

            Gv.Columns("Fax").Visible = False
            Gv.Columns("Email").Visible = True
            Gv.Columns("Web").Visible = False
            Gv.Columns("Banos").Visible = False
            Gv.Columns("MetrosD").Visible = False
            Gv.Columns("MetrosH").Visible = False

            Gv.Columns("PrecioD").Visible = False
            Gv.Columns("PrecioH").Visible = False


            Gv.Columns("HabitacionesD").Visible = False
            Gv.Columns("HabitacionesH").Visible = False
            Gv.Columns("AlturaD").Visible = False
            Gv.Columns("AlturaH").Visible = False
            Gv.Columns("Balcon").Visible = False

            Gv.Columns("Patio").Visible = False
            Gv.Columns("Ascensor").Visible = False
            Gv.Columns("Trastero").Visible = False
            Gv.Columns("Garaje").Visible = False
            Gv.Columns("Terraza").Visible = False
            Gv.Columns("Galeria").Visible = False
            Gv.Columns("Amueblado").Visible = False
            Gv.Columns("SemiAmueblado").Visible = False
            Gv.Columns("PisoAscensor").Visible = False

            Gv.Columns("Piscina").Visible = False
            Gv.Columns("Duplex").Visible = False
            Gv.Columns("GarajeCerrado").Visible = False
            Gv.Columns("Jardin").Visible = False
            Gv.Columns("CocinaOffice").Visible = False
            Gv.Columns("Calentador").Visible = False
            Gv.Columns("Cocina").Visible = False
            Gv.Columns("PrimeraLineaPlaya").Visible = False
            Gv.Columns("NoQuiereRecibirEmails").Visible = False
            Gv.Columns("NoQuiereRecibirSMSs").Visible = False

            Gv.Columns("Agrupacion").Visible = False
            Gv.Columns("Personas").Visible = False
            Gv.Columns("MTerraza").Visible = False

            Gv.Columns("MJardin").Visible = False
            Gv.Columns("MPlaya").Visible = False
            Gv.Columns("AireAcondicionado").Visible = False
            Gv.Columns("Calefaccion").Visible = False
            Gv.Columns("Electrodomesticos").Visible = False

            Gv.Columns("ZonaComercial").Visible = False
            '  Gv.Columns("FechaLlamada").Visible = False

            Gv.Columns("FechaEmailFijo").Visible = False
            Gv.Columns("FechaSMS").Visible = False
            Gv.Columns("FechaSMS").OptionsColumn.AllowShowHide = False
            Gv.Columns("FechaEmailListado").Visible = False
            Gv.Columns("FechaVisitaOficina").Visible = False
            'Gv.Columns("FechaAvisadoInmueble").Visible = False
            'Gv.Columns("FechaUltimaComunicacion").Visible = False
            'Gv.Columns("FechaPuestoAlDia").Visible = False
            'Gv.Columns("FechaLlamada").Visible = False
            Gv.Columns("FechaNoContesta").Visible = False
            'Gv.Columns("FechaNovedades").Visible = False

            Gv.Columns("VistasAlMar").Visible = False

            Gv.Columns("AccesoMinusvalidos").Visible = False
            Gv.Columns("Urbanizacion").Visible = False

            Gv.Columns("TipoCocina").Visible = False
            Gv.Columns("TipoCalentador").Visible = False

            '"'BALCON','PATIO','ASCENSOR','TRASTERO','GARAJE','TERRAZA','GALERIA','AMUEBLADO','SEMIAMUEBLADO','PISCINA','DUPLEX','GARAJECERRADO','JARDIN','COCINAOFFICE','COCINA','CALENTADOR','AIREACONDICIONADO','CALEFACCION','ELECTRODOMESTICOS','PRIMERALINEAPLAYA','VISTASALMAR','ACCESOMINUSVALIDOS','URBANIZACION','ZONACOMERCIAL'")
            Gv.Columns("Balcon").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            Gv.Columns("Patio").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            Gv.Columns("Ascensor").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            Gv.Columns("Trastero").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            Gv.Columns("Garaje").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            Gv.Columns("Terraza").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            Gv.Columns("Galeria").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            Gv.Columns("Amueblado").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            Gv.Columns("SemiAmueblado").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            Gv.Columns("Piscina").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            Gv.Columns("Duplex").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            Gv.Columns("GarajeCerrado").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            Gv.Columns("Jardin").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            Gv.Columns("CocinaOffice").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            Gv.Columns("Calentador").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            Gv.Columns("Cocina").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            Gv.Columns("PrimeraLineaPlaya").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            Gv.Columns("AireAcondicionado").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            Gv.Columns("Calefaccion").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            Gv.Columns("Electrodomesticos").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            Gv.Columns("ZonaComercial").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            Gv.Columns("VistasAlMar").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            Gv.Columns("AccesoMinusvalidos").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            Gv.Columns("Urbanizacion").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center










            Gv.Columns("Nombre").Width = 250

            'gvClientes.Columns("Descuento").Caption = "% Desc."
            'gvClientes.Columns("DescuentoRecalculo").Caption = "% Recalc."

            'gvClientes.Columns("Precio").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric


            'gvClientes.BestFitMaxRowCount = 20
            '    Gv.BestFitColumns()
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
            Gv.Columns("Nombre").SummaryItem.DisplayFormat = "Clientes: {0:n0}"
            Gv.GroupSummary.Add(ItemArticulo)

            'Dim filterString As String = "Nombre LIKE '%a%'"
            'gvClientes.Columns("Nombre").FilterInfo = New Columns.ColumnFilterInfo(ColumnFilterType.Custom, Nothing, filterString)

            'gvClientes.Columns("Nombre").FilterInfo.Type.Custom()

            Gv.OptionsView.ShowFooter = True
            Gv.Columns("Nombre").SummaryItem.FieldName = "Contador"
            Gv.Columns("Nombre").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            Gv.Columns("Nombre").SummaryItem.DisplayFormat = "Total: {0:n0}"

        End Sub
        Private Sub ActivaUcs()
            ucTipoCalentador.Enabled = True
            ucTipoCocina.Enabled = True
            ucTipoCalentador.tb_ReadOnly = True
            ucTipoCocina.tb_ReadOnly = True
        End Sub
        'Private Sub MyGridView1_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)

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

        Private Sub btnAnadir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnadir.Click
 

            PanelCajas2.Visible = True
            Anadir()
        End Sub
        Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
            Eliminar()
        End Sub
        Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
            PanelCajas2.Visible = True
            Modificar()
        End Sub
        Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

            Aceptar()

        End Sub
        Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
            Cancelar()
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
            'End If

            EstoyEnAlta = False
            PrepararModificacion()
        End Sub
        Private Sub Eliminar()



            If Not Funciones.TienePermisosAME() Then
                Return
            End If

            If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
                MensajeError("Debe seleccionar un registro")
                Return
            End If


            If XtraMessageBox.Show("¿Confirma que quiere eliminar el registro seleccionado?" & vbCrLf & "Recuerde que también se eliminarán todas las acciones comerciales realizadas con este cliente", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
                Exit Sub
            End If


            Dim ContadorCliente As String = BinSrc.Current("Contador")
            Dim Sel As String

            'Sel = GL_SQL_DELETE & "  FROM ClientesObservaciones  WHERE ContadorCliente = " & ContadorCliente
            'BD_CERO.Execute(Sel)

         

            Sel = GL_SQL_DELETE & "  FROM ClientesComunicaciones  WHERE ContadorCliente = " & ContadorCliente
            BD_CERO.Execute(Sel)

          

            Sel = GL_SQL_DELETE & "  FROM Visitas  WHERE ContadorCliente = " & ContadorCliente
            BD_CERO.Execute(Sel)

            Sel = GL_SQL_DELETE & "  FROM FichasAlquiler  WHERE ContadorCliente = " & ContadorCliente
            BD_CERO.Execute(Sel)








            'If ConsultasBaseDatos.MarcaDeTiempoHaCambiado(TablaMantenimiento, BinSrc.Current("MarcaDeTiempo")) Then
            '    bd.RefrescarDatos(BinSrc.Position)
            'End If

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
            ActivaUcs()
            Actualizar()
            'If Not EstoyEnAlta Then
            '    LlenarCombosCheckEnlazados()
            'End If
            'GvClientes.FocusedRowHandle = FilaSeleccionada
        End Sub
        Private Sub Cancelar()
            ActivaUcs()
            BinSrc.CancelEdit()
            HabilitarBotones()
            'If EstoyEnAlta Then
            '    LlenarCombosCheckEnlazados()
            'End If
            HabilitarDesHabilitarCajas(False)

        End Sub
        Private Sub PrepararModificacion()

            Dim ZonasAntes As String = cmbZona.EditValue

            HabilitarDesHabilitarCajas(True)
            DesHabilitarBotones()
            LlenarZona()
            LlenarZona()
            'LlenarCombosAlModificar()
            cmbZona.EditValue = ZonasAntes
            txtNombre.Focus()

        End Sub

        Private Sub PrepararAlta()



            HabilitarDesHabilitarCajas(True)

            chkNoQuiereRecibirEmails.EditValue = False
            chkNoQuiereRecibirSMSs.EditValue = False
            ' cmbEmpleados.EditValue = cmbEmpleados.Properties.GetDisplayTextByKeyValue(GL_CodigoUsuario).ToString
            cmbEmpleados.EditValue = GL_CodigoUsuario
            cmbTipoVenta.EditValue = ""


            PonerChecksEnIndeterminado()

            'CargandoClientes = True
            'PrepararLlenarCheckCombosClientes(cmbPoblacion, "Poblacion", False, , "SELECT Poblacion, Provincia FROM Poblacion WHERE Visible  = " & GL_SQL_VALOR_1 & " AND Provincia IN (SELECT Provincia FROM Provincias WHERE Visible = " & GL_SQL_VALOR_1 & ") ORDER BY Poblacion, Provincia ")
            'CargandoClientes = False

            CargandoClientes = True
            cmbPoblacion.EditValue = ""
            'cmbPoblacion.EditValue = GL_PoblacionPrederminada
            'cmbPoblacion.CadenaConLosValores = GL_PoblacionPrederminada
            CargandoClientes = False
            LlenarZona()
            '     LlenarZona()

            txtNombre.Focus()

            DesHabilitarBotones()

        End Sub
        Private Sub LlenarCombosCheckEnlazados(Optional ByVal ConBinding As Boolean = True)

            If Not PrimeraVez Then
                Exit Sub
            End If

            PrepararLlenarCheckCombosClientes(cmbPoblacion, "Poblacion", ConBinding, , "SELECT Poblacion, Provincia FROM Poblacion WHERE Visible  = " & GL_SQL_VALOR_1 & " AND Provincia IN (SELECT Provincia FROM Provincias WHERE Visible = " & GL_SQL_VALOR_1 & ") ORDER BY Poblacion, Provincia ")
            '       PrepararLlenarCheckCombosClientes(cmbZona, "Zona", ConBinding, , "SELECT Zona FROM Zona WHERE Poblacion IN (SELECT Poblacion FROM Poblacion WHERE Visible  = " & GL_SQL_VALOR_1 & " AND Provincia IN (SELECT Provincia FROM Provincias WHERE Visible = " & GL_SQL_VALOR_1 & ")) UNION ALL SELECT Zona FROM ZonasComunes ORDER BY Zona")
            'PrepararLlenarCheckCombosClientes(cmbZona, "Zona", ConBinding, , , False)
            PrepararLlenarCheckCombosClientes(cmbTipo, "Tipo", ConBinding)
            PrepararLlenarCheckCombosClientes(cmbOrientacion, "Orientacion", ConBinding)
            PrepararLlenarCheckCombosClientes(cmbEstado, "Estado", ConBinding, " TipoPrioridad, Prioridad DESC")

        End Sub

        Private Sub LlenarCombosAlModificar()

            '  cmbPoblacion.CheckAll()

            Dim Sel As String
            Dim dtr As Object

            Dim Tabla As String = "ClientesEstado"
            Dim Campo As String = "Estado"
            Dim bdPobs As New BaseDatos

            Sel = "SELECT " & Campo & " FROM " & Tabla & " WHERE ContadorCliente = '" & BinSrc.Current("Contador") & "'"
            Dim Elementos As String = ""
            dtr = bdPobs.ExecuteReader(Sel)
            If dtr.HasRows Then
                While dtr.Read
                    If Elementos = "" Then
                        Elementos = dtr(Campo)
                    Else
                        Elementos = Elementos & ";" & dtr(Campo)
                    End If

                End While
            End If
            dtr.Close()
            bdPobs.CerrarBD()
            cmbEstado.SetEditValue(Elementos)


        End Sub


        Private Sub PonerChecksEnIndeterminado()

            'LlenarCombosCheckEnlazados(False)
            'cmbPoblacion.SetEditValue("")
            'cmbZona.SetEditValue("")
            'cmbOrientacion.SetEditValue("")
            'cmbTipo.SetEditValue("")
            'cmbEstado.SetEditValue("")

            cmbPoblacion.CadenaConLosValores = ""
            cmbZona.CadenaConLosValores = ""
            cmbTipo.CadenaConLosValores = ""
            cmbEstado.CadenaConLosValores = ""
            cmbOrientacion.CadenaConLosValores = ""


            chkAscensor.CheckState = CheckState.Indeterminate
            chkBalcon.CheckState = CheckState.Indeterminate
            chkPatio.CheckState = CheckState.Indeterminate
            chkTerraza.CheckState = CheckState.Indeterminate
            chkJardin.CheckState = CheckState.Indeterminate
            chkGaraje.CheckState = CheckState.Indeterminate
            chkGarajeCerrado.CheckState = CheckState.Indeterminate
            chkTrastero.CheckState = CheckState.Indeterminate
            chkCocinaOffice.CheckState = CheckState.Indeterminate
            chkDuplex.CheckState = CheckState.Indeterminate
            chkPiscina.CheckState = CheckState.Indeterminate
            chkZonaComercial.CheckState = CheckState.Indeterminate
            chkAmueblado.CheckState = CheckState.Indeterminate
            chkSemiamueblado.CheckState = CheckState.Indeterminate

            chkPlayaDerecha.CheckState = CheckState.Indeterminate
            chkMontana.CheckState = CheckState.Indeterminate
            chkBanco.CheckState = CheckState.Indeterminate


            chkElectrodomesticos.CheckState = CheckState.Indeterminate
            chkGaleria.CheckState = CheckState.Indeterminate
            chkAireAcondicionado.CheckState = CheckState.Indeterminate
            chkCalefaccion.CheckState = CheckState.Indeterminate

            chkPrimeraLineaPlaya.CheckState = CheckState.Indeterminate
            chkVistasAlMar.CheckState = CheckState.Indeterminate


            chkAccesoMinusvalidos.CheckState = CheckState.Indeterminate

            chkUrbanizacion.CheckState = CheckState.Indeterminate

            chkOpcionCompra.CheckState = CheckState.Indeterminate


            spnPersonas.EditValue = 0
            spnMPlaya.EditValue = 0

            spnPrecioVentaD.EditValue = 0
            spnPrecioVentaH.EditValue = 9999999



            spnAlturaD.EditValue = 0
            spnAlturaH.EditValue = 99

            spnMetrosD.EditValue = 0
            spnMetrosH.EditValue = 99999

            spnHabitacionesD.EditValue = 0
            spnHabitacionesH.EditValue = 99

            ucTipoCalentador.Valor = Nothing
            ucTipoCocina.Valor = Nothing


        End Sub

        Private Sub HabilitarDesHabilitarCajas(ByVal Habilitar As Boolean)


            'For Each c As Control In PanelCajas.Controls
            '    c.Enabled = Habilitar
            'Next

            MostrarMultiples(False)

            EstoyDesHabilitando = True
            For Each c As Control In PanelCajas2.Controls
                If Not TypeOf (c) Is DevExpress.XtraEditors.LabelControl AndAlso Not TypeOf (c) Is DevExpress.XtraEditors.PanelControl AndAlso Not TypeOf (c) Is DevExpress.XtraEditors.GroupControl Then
                    c.Enabled = Habilitar
                End If
                'If c.Name <> "GroupControl1" And c.Name <> "lblPersonas" And c.Name <> "lblMPlaya" Then
                '    'If c.Name <> "lblPersonas" And c.Name <> "lblMPlaya" And c.Name <> "ucCocina" And c.Name <> "ucCalentador" Then
                '    c.Enabled = Habilitar
                'End If
            Next
            EstoyDesHabilitando = False
            For Each c As Control In GroupControl1.Controls
                If Not TypeOf (c) Is DevExpress.XtraEditors.LabelControl AndAlso Not TypeOf (c) Is DevExpress.XtraEditors.PanelControl AndAlso Not TypeOf (c) Is DevExpress.XtraEditors.GroupControl Then
                    c.Enabled = Habilitar
                End If
            Next

            UcComunicacionesDetalle1.Enabled = Not Habilitar


            'cmbPoblacion.tb_HabilitarDesHabilitarItems(Habilitar) xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            'cmbZona.tb_HabilitarDesHabilitarItems(Habilitar)
            'cmbTipo.tb_HabilitarDesHabilitarItems(Habilitar)
            'cmbOrientacion.tb_HabilitarDesHabilitarItems(Habilitar)
            'cmbEstado.tb_HabilitarDesHabilitarItems(Habilitar)



           

            'If Habilitar Then

            '    ucCocina.tb_ReadOnly = Not Habilitar
            '    ucCalentador.tb_ReadOnly = Not Habilitar

            '    '    HabilitarDesHabilitarVenta(chkVenta.Checked)
            '    '    HabilitarDesHabilitarAlquiler(chkAlquiler.Checked)
            '    '    HabilitarDesHabilitarTraspaso(chkTraspaso.Checked)
            '    '    HabilitarDesHabilitarVerano(chkVerano.Checked)
            '    'Else
            '    '    HabilitarDesHabilitarVenta(Habilitar)
            '    '    HabilitarDesHabilitarAlquiler(Habilitar)
            '    '    HabilitarDesHabilitarTraspaso(Habilitar)
            '    '    HabilitarDesHabilitarVerano(Habilitar)
            'End If



            GCComunicacionesGenerales.Enabled = Not Habilitar
            GCComunicacionesVengoDeInmuebles.Enabled = Not Habilitar

            'btnEmailDetalle.Enabled = Not Habilitar
            'btnEmailListadoNovedades.Enabled = Not Habilitar
            'btnSMS.Enabled = Not Habilitar
            'btnVisitasOficina.Enabled = Not Habilitar





            HabilitarDesHabilitarBotonesEspecialesCuandoVengoDeInmuebles(Not Habilitar)



            txtObservaciones.Enabled = True
            txtObservaciones.Properties.ReadOnly = True

         


            'RCCocinaOffice.Enabled = True
            'RCCocinaOffice.RGruop.Properties.ReadOnly = Not Habilitar

            'RCAmueblado.Enabled = True
            'RCAmueblado.RGruop.Properties.ReadOnly = Not Habilitar

            'RCSemiAmueblado.Enabled = True
            'RCSemiAmueblado.RGruop.Properties.ReadOnly = Not Habilitar

            'RCTrastero.Enabled = True
            'RCTrastero.RGruop.Properties.ReadOnly = Not Habilitar

            'RCDuplex.Enabled = True
            'RCDuplex.RGruop.Properties.ReadOnly = Not Habilitar

            'RCBalcon.Enabled = True
            'RCBalcon.RGruop.Properties.ReadOnly = Not Habilitar

            'RCPatio.Enabled = True
            'RCPatio.RGruop.Properties.ReadOnly = Not Habilitar

            'RCTerraza.Enabled = True
            'RCTerraza.RGruop.Properties.ReadOnly = Not Habilitar

            'RCGaleria.Enabled = True
            'RCGaleria.RGruop.Properties.ReadOnly = Not Habilitar

            'RCJardin.Enabled = True
            'RCJardin.RGruop.Properties.ReadOnly = Not Habilitar

            'RCPiscina.Enabled = True
            'RCPiscina.RGruop.Properties.ReadOnly = Not Habilitar

            'RCAscensor.Enabled = True
            'RadioAscensor.Properties.ReadOnly = Not Habilitar
            'spnAscensor.Properties.ReadOnly = Not Habilitar

            'RCGaraje.Enabled = True
            'RadioGaraje.Properties.ReadOnly = Not Habilitar
            'chkGarajeCerrado.Properties.ReadOnly = Not Habilitar

            If Habilitar Then

                ucTipoCocina.tb_ReadOnly = Not Habilitar
                ucTipoCalentador.tb_ReadOnly = Not Habilitar

            End If



        End Sub

        Private Function Actualizar() As Boolean
            Try

                Me.Validate()

                If Not ComprobarDatos() Then
                    Return False
                End If


                If chkTerraza.Checked = False AndAlso spnMTerraza.EditValue > 0 Then
                    chkTerraza.Checked = True
                End If
                If chkJardin.Checked = False AndAlso spnMJardin.EditValue > 0 Then
                    chkJardin.Checked = True
                End If
                'If chkAscensor.Checked = False AndAlso txtAlturaSinAscensor.EditValue > 0 Then
                '    chkAscensor.Checked = True
                'End If
                If chkGaraje.Checked = False AndAlso Not chkGarajeCerrado.Checked = False Then
                    chkGaraje.Checked = True
                End If

                If EstoyEnAlta Then
                    BinSrc.Current("FechaAlta") = Microsoft.VisualBasic.Now
                    'BinSrc.Current("FechaPuestoAlDia") = Microsoft.VisualBasic.Now
                    BinSrc.Current("FechaUltimaComunicacion") = Microsoft.VisualBasic.Now
                    BinSrc.Current("FechaLlamada") = Microsoft.VisualBasic.Now


                    BinSrc.Current("CodigoEmpresa") = DatosEmpresa.Codigo
                    BinSrc.Current("ContadorEmpleado") = GL_CodigoUsuario

                    ''---------------?????añado estas lineas ya que da error al crear y no estas estos datos
                    BinSrc.Current("Delegacion") = Gl_Delegacion



                    cmbPoblacion.EstoyEnAlta = True
                    cmbZona.EstoyEnAlta = True
                    cmbTipo.EstoyEnAlta = True
                    cmbEstado.EstoyEnAlta = True
                    cmbOrientacion.EstoyEnAlta = True

                    Dim NuevoContador As Integer = BD_CERO.Execute("SELECT MAX(Contador) + 1 FROM " & TablaMantenimiento, False, 1)
                    BinSrc.Current("Contador") = NuevoContador

                End If

                'For i = 0 To cmbZona.DataBindings.Count - 1
                '    cmbZona.DataBindings.RemoveAt(0)
                'Next
                'cmbZona.DataBindings.Add(New Binding("tb_ValorBusqueda", BinSrc, "Contador", True, DataSourceUpdateMode.Never))

                BinSrc.EndEdit()

                Dim ValorClaveAntes As Object = BinSrc.Current("Contador")


                Dim PoblacionesAntes As String = cmbPoblacion.EditValue
                Dim ZonasAntes As String = cmbZona.EditValue



                'Dim Poblaciones As New List(Of String)
                'Dim PoblacionesArray As String()
                'PoblacionesArray = Split(cmbPoblacion.EditValue, ";")

                If Not ActualizarBaseDatos() Then


                    cmbPoblacion.CadenaConLosValores = ""
                    cmbZona.CadenaConLosValores = ""
                    cmbTipo.CadenaConLosValores = ""
                    cmbEstado.CadenaConLosValores = ""
                    cmbOrientacion.CadenaConLosValores = ""

                    Return False
                Else
                    'Dim Sel As String

                    'Dim Zonas As New List(Of String)
                    'Dim ZonasArray As String()
                    'ZonasArray = Split(cmbZona.EditValue, ";")

                    'Sel = GL_SQL_DELETE & " FROM ClientesZona WHERE ContadorCliente = " & BinSrc.Current("Contador")
                    'BD_CERO.Execute(Sel)

                    'For i = 0 To ZonasArray.Length - 1
                    '    If ZonasArray(i).Trim <> "" Then
                    '        Sel = "INSERT INTO ClientesZona (ContadorCliente , Zona) VALUES (" & BinSrc.Current("Contador") & ", '" & Funciones.pf_ReplaceComillas(ZonasArray(i)) & "')"
                    '        BD_CERO.Execute(Sel)
                    '    End If
                    'Next

                    'If EstoyEnAlta Then
                    '    CargandoClientes = True



                    '    Sel = GL_SQL_DELETE & " FROM ClientesPoblacion WHERE ContadorCliente = " & BinSrc.Current("Contador")
                    '    BD_CERO.Execute(Sel)

                    '    For i = 0 To PoblacionesArray.Length - 1
                    '        If PoblacionesArray(i).Trim <> "" Then
                    '            Sel = "INSERT INTO ClientesPoblacion (ContadorCliente , Poblacion) VALUES (" & BinSrc.Current("Contador") & ", '" & Funciones.pf_ReplaceComillas(PoblacionesArray(i)) & "')"
                    '            BD_CERO.Execute(Sel)
                    '        End If
                    '    Next


                    '    CargandoClientes = False
                    'End If

                End If

                CargandoClientes = True
                cmbPoblacion.CadenaConLosValores = PoblacionesAntes
                'cmbPoblacion.EditValue = PoblacionesAntes
                CargandoClientes = False
                'cmbZona.EditValue = ZonasAntes
                cmbZona.CadenaConLosValores = ZonasAntes
                cmbZona.CadenaConLosValores = ZonasAntes
                cmbZona.tb_ValorBusqueda = CInt(ValorClaveAntes)
                cmbZona.tb_ValorBusqueda = CInt(ValorClaveAntes)
                ActualizaDatosTodosCombosAuxiliares(ZonasAntes)
                cmbZona.CadenaConLosValores = ZonasAntes
                cmbZona.EditValue = ZonasAntes

                If EstoyEnAlta Then
                    Dim tab As New Tablas.clComunicaciones

                    tab.CodigoEmpresa = DatosEmpresa.Codigo
                    tab.Delegacion = Gl_Delegacion
                    tab.ContadorInmueble = 0
                    tab.ContadorClientePropietarioInmueble = ValorClaveAntes
                    tab.ContadorClientePropietarioInmueble = ValorClaveAntes
                    tab.ContadorEmpleado = GL_CodigoUsuario
                    tab.LlamadaContestada = 1
                    tab.Observaciones = ""
                    'tab.Tipo = GL_OBSERVACIONES_LLAMADA
                    tab.Tipo = GL_VISITA_OFICINA
                    tab.Tabla = GL_TablaClientes

                    ConsultasBaseDatos.InsertarComunicacionesObservaciones(tab)

                    Dim ContAPasar As Integer
                    If DeDondeVengo = GL_VENGO_DE_INMUEBLES Then
                        ContAPasar = ContadorInmuebleDeDondeVengo
                    Else
                        ContAPasar = 0
                    End If
                    UcComunicacionesDetalle1.LlenarGrid(tab.ContadorClientePropietarioInmueble, tab.Tabla, ContAPasar)

                    bd.RefrescarDatos(BinSrc.Position)

                    'BinSrc.Current("FechaLlamada") = Now
                    'BinSrc.EndEdit()
                    'EstoyEnAlta = False
                    'ActualizarBaseDatos()
                    'bd.ds.AcceptChanges()

                    VerTodos()

                End If




                'Me.ClientesTableAdapter.Update(DsClientes.Clientes)
                'DsClientes.AcceptChanges()
                'Me.ClientesTableAdapter.Fill(Me.DsClientes.Clientes)
                If Not Eliminando AndAlso ValorClaveAntes IsNot Nothing Then
                    SituarseEnGrid(Gv, ValorClaveAntes.ToString, "Contador")
                End If
                HabilitarBotones()
                HabilitarDesHabilitarCajas(False)


                CargandoClientes = True
                cmbPoblacion.CadenaConLosValores = PoblacionesAntes
                'cmbPoblacion.EditValue = PoblacionesAntes
                CargandoClientes = False
                'cmbZona.EditValue = ZonasAntes
                cmbZona.CadenaConLosValores = ZonasAntes
                '    cmbZona.tb_ValorBusqueda = BinSrc.Current("Contador")
                '    ActualizaDatosTodosCombosAuxiliares()
                cmbZona.CadenaConLosValores = ZonasAntes
                cmbZona.EditValue = ZonasAntes
                LlenarZonaCliente()

                Return True

            Catch ex As DBConcurrencyException

                Dim customErrorMessage As String
                customErrorMessage = "Concurrency violation" & vbCrLf
                customErrorMessage += CType(ex.Row.Item(0), String)
                MessageBox.Show(customErrorMessage)

                ' Add business logic code to resolve the concurrency violation...
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

        Private Sub ActualizaDatosTodosCombosAuxiliares(Optional ZonasAntes As String = "")

            CargandoClientes = True
            cmbPoblacion.tb_ActualizaDatosCombos()
            CargandoClientes = False

            If ZonasAntes <> "" Then
                cmbZona.CadenaConLosValores = ZonasAntes
            End If

            cmbZona.tb_ActualizaDatosCombos()
            cmbTipo.tb_ActualizaDatosCombos()

            cmbOrientacion.tb_ActualizaDatosCombos()
            cmbEstado.tb_ActualizaDatosCombos()

        End Sub

        'Private Sub ActualizaAscensorYGaraje()

        '    Dim ValorAscensor As String = ""

        '    Select Case RadioAscensor.SelectedIndex
        '        Case 0
        '            ValorAscensor = "SI"
        '        Case 1
        '            ValorAscensor = "NO"
        '        Case 2
        '            ValorAscensor = ""

        '    End Select

        '    BinSrc.Current("Ascensor") = ValorAscensor


        '    Dim ValorGaraje As String = ""

        '    Select Case RadioGaraje.SelectedIndex
        '        Case 0
        '            ValorGaraje = "SI"
        '        Case 1
        '            ValorGaraje = "NO"
        '        Case 2
        '            ValorGaraje = ""

        '    End Select

        '    BinSrc.Current("Garaje") = ValorGaraje
        'End Sub

        'Private Sub ActualizaDatosCombos(cmb As CheckedComboBoxEdit, Tabla As String, Campo As String)

        '    Try
        '        Dim Sel As String
        '        Dim BdBorra As New BaseDatos
        '        Sel = ""& GL_SQL_DELETE &"FROM " & Tabla & " WHERE CodigoCliente = '" & txtCodigo.EditValue & "'"
        '        BdBorra.Execute(Sel)

        '        Dim Campos() As Stringfocu
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
        Private Function ActualizarBaseDatos(Optional ByVal RefrescarDatos As Boolean = False) As Boolean

            Try

                Dim ContadorMinimo As Integer = 0

                If EstoyEnAlta Then
                    ContadorMinimo = clGenerales.Maximo("Contador", TablaMantenimiento)
                End If


                bd.ActualizarCambios(GL_TablaClientes, bd.ds, RefrescarDatos)

                'If EstoyEnAlta Then

                '    CargandoClientes = True


                '    'Se supone que el cliente ya está dado de alta en la bd.
                '    'Como el contador es autonumérico, no lo tenemos en el dataset.
                '    'Con lo siguiente, vamos a acutaliazar el dataset con el contador que le han asignado al cliente
                '    Dim NuevoContador As Integer

                '    NuevoContador = ConsultasBaseDatos.ObtenerContadorClienteEnAlta(BinSrc.Current("Nombre"), BinSrc.Current("NIF"), BinSrc.Current("Telefono1"), ContadorMinimo, GL_CodigoUsuario)

                '    Dim dt As DataTable
                '    Dim dr As DataRow
                '    dt = bd.ds.Tables(TablaMantenimiento)
                '    dr = dt.Rows(bd.ds.Tables(TablaMantenimiento).Rows.Count - 1)

                '    If BinSrc.Current("Nombre") = dr("Nombre") And (dr("Contador") Is DBNull.Value OrElse dr("Contador") = 0) Then
                '        Dim bdMarcaTiempo As New BaseDatos
                '        'Dim MarcaDeTiempo As Byte() = bdMarcaTiempo.Execute("SELECT MarcaDeTiempo FROM " & TablaMantenimiento & " WHERE Contador = " & NuevoContador, False)

                '        dr.BeginEdit()
                '        dr("Contador") = NuevoContador
                '        'dr("MarcaDeTiempo") = MarcaDeTiempo
                '        dr.EndEdit()
                '        bd.ds.AcceptChanges()
                '    End If



                '    CargandoClientes = False
                'End If



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
            'If txtCodigo.Text.ToString.Trim = "" And Not EstoyEnAlta Then
            '    MensajeError("El campo código no puede estar vacío")

            '    txtCodigo.Focus()
            '    Return False
            'End If

            If txtNombre.Text.ToString.Trim = "" Then
                MensajeError("El campo nombre no puede estar vacío")

                txtNombre.Focus()
                Return False
            End If

            txtEmail.Text = Trim(txtEmail.Text)
            If Not Funciones.validar_Mail(txtEmail.Text) Then
                MensajeError("El campo email no es correcto")
                txtEmail.Focus()
                Return False
            End If

            If cmbTipoVenta.EditValue = "" Then
                MensajeError("Debe seleccionar venta, alquiler, verano o traspaso")
                Return False
            End If

            Return True

        End Function

        Private Sub dgvx_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvx.KeyDown

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

        Private Sub HabilitarDesHabilitarAnadirModificarBorrar(ByVal Habilitar)

            btnAnadir.Enabled = Habilitar
            btnModificar.Enabled = Not Habilitar
            btnEliminar.Enabled = Not Habilitar
            If bd.ds.Tables(TablaMantenimiento).Rows.Count > 0 Then
                btnModificar.Enabled = Habilitar
                btnEliminar.Enabled = Habilitar
            End If

            'btnDarDeBaja.Enabled = Habilitar
            btnVerBajas.Enabled = Habilitar
            'btnDarDeBaja.Enabled = Habilitar
            MenuGrid.PopMenuDarDeBajaCliente.Visible = True
            btnVisitas.Enabled = Habilitar
            btnInmuebles.Enabled = Habilitar
            btnMostrarAccionesComerciales.Enabled = Habilitar
            btnAnadirObservaciones.Enabled = Habilitar
            btnFichaAlquiler.Enabled = Habilitar




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

            btnVerBajas.Enabled = True
            'btnDarDeBaja.Enabled = True
            MenuGrid.PopMenuDarDeBajaCliente.Visible = True
            btnVisitas.Enabled = True
            btnInmuebles.Enabled = True
            btnMostrarAccionesComerciales.Enabled = True
            btnAnadirObservaciones.Enabled = True
            btnFichaAlquiler.Enabled = True
            dgvx.Enabled = True
            btnFichaAlquiler.Enabled = True
            'For Each Page As DevExpress.XtraTab.XtraTabPage In XtraTabControl1.TabPages
            '    Page.PageEnabled = True
            'Next

            HabilitarDesHabilitarBotonesEspecialesCuandoVengoDeInmuebles(True)

            If PulsadoVerBajas Then
                btnVisitas.Enabled = False
            End If

            btnVerTodos.Enabled = True
            btnMostrarListado.Enabled = True
            btnMostrarAccionesComerciales.Enabled = True
            txtBusquedaEmailTelefono.Enabled = True
            cmbPerfiles.Enabled = True
            cmbFiltros.Enabled = True
            txtObservaciones.Enabled = True
        End Sub
        Private Sub HabilitarDesHabilitarBotonesEspecialesCuandoVengoDeInmuebles(ByVal Habilitar As Boolean)
            'If Me.ContadorInmuebleDeDondeVengo <> 0 Then
            '    btnEmailDetalle.Enabled = Habilitar
            'Else
            '    btnEmailDetalle.Enabled = False
            'End If
        End Sub

        Private Sub DesHabilitarBotones()

            btnAnadir.Enabled = False
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
            btnSalir.Enabled = False
            btnAceptar.Enabled = True
            btnCancelar.Enabled = True

            btnVerBajas.Enabled = False
            'btnDarDeBaja.Enabled = False
            MenuGrid.PopMenuDarDeBajaCliente.Visible = False
            btnVisitas.Enabled = False
            btnInmuebles.Enabled = False
            btnMostrarAccionesComerciales.Enabled = False
            btnAnadirObservaciones.Enabled = False
            btnFichaAlquiler.Enabled = False
            btnSeleccionesMultiples.Enabled = False
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
            btnVerTodos.Enabled = False
            btnMostrarListado.Enabled = False
            btnMostrarAccionesComerciales.Enabled = False
            txtBusquedaEmailTelefono.Enabled = False
            cmbPerfiles.Enabled = False
            cmbFiltros.Enabled = False
            'txtObservaciones.Enabled = False
            txtObservaciones.Properties.ReadOnly = False
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

        Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
            Salir()
        End Sub

        Private Sub Salir()



            Me.ParentForm.Dispose()
            MostrarImagenDeFondo()
            LiberarMemoria()

        End Sub

        Private Sub MyGridView1_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles Gv.FocusedRowChanged

            Try



                HacerCambioFila()

            Catch ex As Exception

            End Try

        End Sub


        

        Private Sub CargarListBox(ByVal lb As ListBoxControl, ByVal tabla As String, ByVal cliente As String)
            Dim bajas As String = ""

            lb.Items.Clear()

            Dim dtr As Object
            Dim bdlist As New BaseDatos
            Dim SEL As String = " SELECT " & tabla & " as Dato FROM Clientes" & tabla & " WHERE ContadorCliente=" & cliente

            dtr = bdlist.ExecuteReader(SEL)

            If dtr.HasRows Then
                While dtr.Read
                    lb.Items.Add(dtr("Dato"))
                End While
            End If
            dtr.Close()
            bdlist.CerrarBD()

            lb.Enabled = False

            If lb.ItemCount < 2 Then
                lb.Height = cmbPoblacion.Height - 2
            ElseIf lb.ItemCount < 9 Then
                lb.Height = lb.ItemCount * (cmbPoblacion.Height - 4)
            Else
                lb.Height = (cmbPoblacion.Height - 4) * 8
                lb.Enabled = True
            End If

        End Sub

        'Private Sub gridView1_RowStyle(sender As Object, e As RowStyleEventArgs)
        '    If e.RowHandle = Gv.FocusedRowHandle Then
        '        MsgBox("hola")
        '        For Each style As StyleFormatCondition In Gv.FormatConditions
        '            If style.CheckValue(style.Column, Gv.GetRowCellValue(e.RowHandle, style.Column), Gv.GetRow(e.RowHandle)) Then
        '                e.Appearance.ForeColor = Color.Red
        '                e.HighPriority = True
        '            End If
        '        Next
        '    End If
        'End Sub

        Private Sub MostrarPanelComunicacionesEnCambioFila()
            If PanelComunicacion.Visible Then

                Dim ContAPasar As Integer
                If DeDondeVengo = GL_VENGO_DE_INMUEBLES Then
                    ContAPasar = ContadorInmuebleDeDondeVengo
                    '    ContAPasar = 0
                Else
                    ContAPasar = 0
                End If
                '         uComunicacionesDetalle = New ucComunicacionesDetalle()
                UcComunicacionesDetalle1.LlenarGrid(BinSrc.Current("Contador"), "Clientes", ContAPasar)

                Dim Sel As String
                Sel = "SELECT MAX(Fecha) FROM ClientesComunicaciones WHERE ContadorCliente = " & BinSrc.Current("Contador") & " AND Tipo = 'VISITA OFICINA'"
                mskVisita.EditValue = BD_CERO.Execute(Sel, False, "")

                Sel = "SELECT MAX(Fecha) FROM ClientesComunicaciones WHERE ContadorCliente = " & BinSrc.Current("Contador") & " AND Tipo = 'LLAMADA'"
                mskLlamada.EditValue = BD_CERO.Execute(Sel, False)

                chkFichaAlquiler.EditValue = BinSrc.Current("FichaAlquiler")

            End If
        End Sub

        Private Sub HacerCambioFila()

            If CargandoClientes Then
                Exit Sub
            End If

            If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
                PanelCajas2.Enabled = False
                PanelComunicacion.Enabled = False
                Exit Sub
            Else
                PanelCajas2.Enabled = True
                PanelComunicacion.Enabled = True
            End If

            FocusedColor()

            If PanelGestionDocumental.Visibility = DockVisibility.Visible Then
                uGestionDocumental.Titulo("Gestión documental del cliente " & BinSrc.Current("Nombre"))
                uGestionDocumental.RefrescarBotones(BinSrc.Current(CampoGestionDocumental), TablaGestionDocumental)
            End If

            Try
                'txtObservaciones.Text = BD_CERO.Execute("SELECT Observaciones FROM Clientes WHERE Contador= " & BinSrc.Current("Contador"))
                'LlenarObservaciones(txtObservaciones, BinSrc.Current("Contador"), "Clientes")

                ' UcComunicacionesDetalle1.LlenarGrid(BinSrc.Current("Contador"), "Clientes")
                MostrarPanelComunicacionesEnCambioFila

                If ContadorInmuebleDeDondeVengo = 0 Then
                    Dim SelNovedades As String = FuncionesBD.ObtenerReferenciasQueCuadran(BinSrc.Current("Contador"), False, "COUNT(*)", "Novedades")
                    Dim Cuant As Integer = BD_CERO.Execute(SelNovedades, False, 0)


                    If Cuant = 0 Then
                        btnEmailNovedades.Enabled = False
                        lblNovedades.Text = "0 novedades"
                        lblNovedades.ForeColor = System.Drawing.ColorTranslator.FromHtml("#7c2420")
                    Else
                        btnEmailNovedades.Enabled = True
                        lblNovedades.Text = Cuant.ToString & " novedades"

                        lblNovedades.ForeColor = System.Drawing.ColorTranslator.FromHtml("#1b812a")

                    End If
                End If



            Catch ex As Exception

            End Try

           CambiosAltaBaja

            CambiarColorFichaAlquiler()

            'LlenarCombosAlModificar()

            'cmbPoblacion.tb_ValorBusqueda = BinSrc.Current("Contador")
            'cmbEstado.tb_ValorBusqueda = BinSrc.Current("Contador")
            'cmbTipo.tb_ValorBusqueda = BinSrc.Current("Contador")
            'cmbOrientacion.tb_ValorBusqueda = BinSrc.Current("Contador")
            'cmbZona.tb_ValorBusqueda = BinSrc.Current("Contador")

            If lbPoblacion.Visible Then
                CargarListBox(lbPoblacion, "Poblacion", BinSrc.Current("Contador"))
                CargarListBox(lbZona, "Zona", BinSrc.Current("Contador"))
                CargarListBox(lbTipo, "Tipo", BinSrc.Current("Contador"))
                CargarListBox(lbOrientacion, "Orientacion", BinSrc.Current("Contador"))
                CargarListBox(lbEstado, "Estado", BinSrc.Current("Contador"))
            End If

            If BinSrc.Current("TipoVenta") = GL_Palabra_Alquiler Then
                btnFichaAlquiler.Enabled = True
            Else
                btnFichaAlquiler.Enabled = False
            End If

            If spnMPlaya.EditValue > 0 Then
                'spnMPlaya.BackColor = System.Drawing.ColorTranslator.FromHtml("#1b812a")
                '   spnMPlaya.Properties.AppearanceDisabled.ForeColor = System.Drawing.ColorTranslator.FromHtml("#1b812a")
                spnMPlaya.Properties.AppearanceDisabled.ForeColor = Color.Green
            Else
                spnMPlaya.Properties.AppearanceDisabled.ForeColor = Color.Black
                'spnMPlaya.BackColor = Color.White
            End If

            LlenarZona()
            LlenarZonaCliente()
            ActivaUcs()

        End Sub

        Private Sub CambiosAltaBaja()

            Try

                If BinSrc.Current("Baja") Then




                    PulsadoVerBajas = True
                    'btnDarDeBaja.ForeColor = Color.Red
                    'btnDarDeBaja.Text = "Recuperar"
                    btnVerBajas.ForeColor = Color.Red
                    btnVerBajas.Text = "Ver Altas"
                    btnVerBajas.Image = My.Resources.ClientesAlta
                    'btnDarDeBaja.Image = My.Resources.DarDeAlta
                    MenuGrid.PopMenuDarDeBajaCliente.Text = "Recuperar Cliente"
                    HabilitarDesHabilitarAnadirModificarBorrar(False)
                    btnInmuebles.Enabled = False

                Else



                    PulsadoVerBajas = False
                    'btnDarDeBaja.ForeColor = ColorInicialBotonBajas
                    'btnDarDeBaja.Text = "Dar de Baja"
                    btnVerBajas.ForeColor = ColorInicialBotonBajas
                    btnVerBajas.Text = "Ver Bajas"
                    btnVerBajas.Image = My.Resources.ClientesBaja
                    'btnDarDeBaja.Image = My.Resources.DarDeBaja
                    MenuGrid.PopMenuDarDeBajaCliente.Text = "Dar de Baja Cliente"
                    HabilitarDesHabilitarAnadirModificarBorrar(True)
                End If
            Catch ex As Exception

            End Try


            btnVerBajas.Enabled = True


            If bd.ds.Tables(TablaMantenimiento).Rows.Count > 0 Then
                btnModificar.Enabled = True
                btnEliminar.Enabled = True
                btnInmuebles.Enabled = True

            End If

        End Sub

        Private Sub LlenarZonaCliente()
            'sel = "SELECT 'TODOS' AS Zona, 0 AS ORDEN UNION ALL SELECT DISTINCT Zona, 1 AS ORDEN FROM Zona " & ListaPoblaciones & " ORDER BY ORDEN, Zona "


            Try


                Dim Sel As String
                Sel = "SELECT Zona FROM  ClientesZona  WHERE ContadorCliente = " & BinSrc.Current("Contador") & " ORDER BY  Zona "
                Dim dtr As SqlClient.SqlDataReader

                dtr = bd.ExecuteReader(Sel)

                Dim Zon As String = ""

                If dtr.HasRows Then
                    While dtr.Read

                        If Zon = "" Then
                            Zon = dtr("Zona")
                        Else
                            Zon = Zon & ";" & dtr("Zona")
                        End If


                    End While
                End If
                dtr.Close()

                cmbZona.CadenaConLosValores = Zon

            Catch ex As Exception
                cmbZona.CadenaConLosValores = ""

            End Try
        End Sub
        Private Sub LlenarZona()


            If CargandoClientes Then
                Exit Sub
            End If


            Dim Res As List(Of Tablas.clZonas)

            Try

                Dim Poblaciones As New List(Of String)
                Dim PoblacionesArray As String()
                PoblacionesArray = Split(cmbPoblacion.EditValue, ";")

                For i = 0 To PoblacionesArray.Length - 1
                    Poblaciones.Add(PoblacionesArray(i).Trim)
                Next

                Res = ListaZonas(Poblaciones, DatosEmpresa.Codigo)

                cmbZona.DeselectAll()
                cmbZona.Properties.Items.Clear()
                cmbZona.Properties.DataSource = Nothing


                cmbZona.Properties.DataSource = Res

                cmbZona.Properties.DisplayMember = "Zona"
                cmbZona.Properties.ValueMember = "Zona"
                cmbZona.Properties.SeparatorChar = ";"

                '   cmbZona.tb_ValorBusqueda = 0

                For i = 0 To cmbZona.DataBindings.Count - 1
                    cmbZona.DataBindings.RemoveAt(0)
                Next





                '   cmbZona.DataBindings.Add(New Binding("tb_ValorBusqueda", BinSrc, "Contador", True, DataSourceUpdateMode.Never))


                'cmbZona.tb_ValorBusqueda = 0

                'For i = 0 To cmbZona.DataBindings.Count - 1
                '    cmbZona.DataBindings.RemoveAt(0)
                'Next


                ''                If PrimeraVezLlenarZona Then
                ''PrimeraVezLlenarZona = False
                'If Not btnAceptar.Enabled Then
                '    cmbZona.DataBindings.Add(New Binding("tb_ValorBusqueda", BinSrc, "Contador", True, DataSourceUpdateMode.Never))
                'End If

            Catch ex As Exception

                MsgBox(ex.Message)

            End Try







        End Sub

        'Function ListaZonas(Poblaciones As List(Of String), ContadorEmpresa As Integer) As List(Of Tablas.clZonas)

        '    Dim Zonas As New List(Of Tablas.clZonas)

        '    Dim bd As BaseDatos

        '    Try


        '        bd = New BaseDatos

        '        Dim dtr As Object
        '        Dim sel As String = String.Empty

        '        Dim ListaPoblaciones As String = ""

        '        For i = 0 To Poblaciones.Count - 1
        '            If ListaPoblaciones = "" Then
        '                ListaPoblaciones = "'" & Funciones.pf_ReplaceComillas(Poblaciones(i).ToUpper.Trim) & "'"
        '            Else
        '                ListaPoblaciones = ListaPoblaciones & ", '" & Funciones.pf_ReplaceComillas(Poblaciones(i).ToUpper.Trim) & "'"
        '            End If
        '        Next

        '        If ListaPoblaciones <> "" Then
        '            ListaPoblaciones = " WHERE " & GL_SQL_UPPER & "(Poblacion) IN ( " & ListaPoblaciones & ")"
        '        End If

        '        'sel = "SELECT 'TODOS' AS Zona, 0 AS ORDEN UNION ALL SELECT DISTINCT Zona, 1 AS ORDEN FROM Zona " & ListaPoblaciones & " ORDER BY ORDEN, Zona "
        '        sel = "SELECT DISTINCT Zona FROM Zona " & ListaPoblaciones & " UNION ALL SELECT Zona FROM ZonasComunes ORDER BY  Zona "

        '        dtr = bd.ExecuteReader(sel)



        '        If dtr.HasRows Then
        '            While dtr.Read

        '                Dim Zona As New Tablas.clZonas
        '                Zona.Zona = dtr("Zona")
        '                Zonas.Add(Zona)

        '            End While
        '        End If

        '        dtr.Close()






        '    Catch ex As Exception

        '        MensajeError(ex.Message)

        '    End Try

        '    Return Zonas

        'End Function
        Private Sub CambiarColorFichaAlquiler()
            If BinSrc.Current("FichaAlquiler") > 0 Then
                btnFichaAlquiler.ForeColor = Color.Red
            Else
                btnFichaAlquiler.ForeColor = SystemColors.HotTrack
            End If
        End Sub
        Private Sub LlenarCombosAuxiliaresSoloConSusDatos(ByVal cmb As CheckedComboBoxEdit, ByVal Tabla As String, ByVal Campo As String, Optional ByVal Filtro As String = "")

            Dim bdPobs As New BaseDatos()
            Dim Tab As New Tablas.clTablaGeneral(Tabla, , "SELECT " & Campo & " FROM " & Tabla & " WHERE ContadorCliente = '" & BinSrc.Current("Contador") & "'", )
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
 
        'Private Sub BusquedaPorTelefonoEmail()

        '    If FiltroBusqueda <> "" Then

        '        BuscandoPorTelefonoEmail = False
        '        FiltroBusqueda = ""

        '        LlenarGrid()
        '        txtBusquedaEmailTelefono.Text = ""
        '        txtBusquedaEmailTelefono.ForeColor = ColorInicialBotonBuscar
        '        BuscandoPorTelefonoEmail = False

        '        PulsadoVerBajas = True
        '        VerBajas()

        '        HabilitarDesHabilitarAnadirModificarBorrar(True)
        '        'btnDarDeBaja.Enabled = True
        '        MenuGrid.PopMenuDarDeBajaCliente.Visible = True

        '        Return
        '    End If

        '    If FiltroBusqueda = txtBusquedaEmailTelefono.Text Then
        '        Return
        '    End If

        '    If txtBusquedaEmailTelefono.Text <> "" Then
        '        FiltroBusqueda = txtBusquedaEmailTelefono.Text
        '        LlenarGrid()
        '        txtBusquedaEmailTelefono.ForeColor = Color.Red
        '        BuscandoPorTelefonoEmail = True

        '        HabilitarDesHabilitarAnadirModificarBorrar(False)
        '        'btnDarDeBaja.Enabled = True
        '        MenuGrid.PopMenuDarDeBajaCliente.Visible = True

        '    Else

        '        BuscandoPorTelefonoEmail = False
        '        FiltroBusqueda = ""

        '        LlenarGrid()
        '        txtBusquedaEmailTelefono.Text = ""
        '        txtBusquedaEmailTelefono.ForeColor = ColorInicialBotonBuscar
        '        BuscandoPorTelefonoEmail = False

        '        PulsadoVerBajas = False
        '        VerBajas()

        '        HabilitarDesHabilitarAnadirModificarBorrar(True)
        '        'btnDarDeBaja.Enabled = True
        '        MenuGrid.PopMenuDarDeBajaCliente.Visible = True


        '        '      View.EditingValue = Gl_ResultadoBusqueda
        '    End If

        '    'Dim condition1 As StyleFormatCondition
        '    'condition1 = New DevExpress.XtraGrid.StyleFormatCondition()
        '    'condition1.Appearance.BackColor = Color.Red
        '    'condition1.Appearance.Options.UseBackColor = True
        '    'condition1.Condition = FormatConditionEnum.Expression
        '    'condition1.Expression = "[Baja] = true"
        '    'Gv.FormatConditions.Add(condition1)

        '    ''If Gv.Columns("baja") IsNot Nothing Then
        '    ''    Gv.Columns("baja").Visible = False
        '    ''    Gv.Columns("baja").OptionsColumn.AllowShowHide = False
        '    ''End If

        '    Try
        '        HacerCambioFila()
        '        'Gv.Focus()

        '        'Gv.FocusedRowHandle = 0
        '    Catch ex As Exception

        '    End Try
        'End Sub

        Private Sub BusquedaPorTelefonoEmail()

            If txtBusquedaEmailTelefono.Text.Trim = "" Then
                BuscandoPorTelefonoEmail2 = False
            Else
                BuscandoPorTelefonoEmail2 = True
            End If

            If Not BuscandoPorTelefonoEmail2 Then


                PulsadoVerBajas = False
                LlenarGrid()
                txtBusquedaEmailTelefono.Text = ""
                txtBusquedaEmailTelefono.ForeColor = ColorInicialBotonBuscar
                '     VerBajas()
                HabilitarDesHabilitarAnadirModificarBorrar(True)
                'btnDarDeBaja.Enabled = True
                MenuGrid.PopMenuDarDeBajaCliente.Visible = True

            Else

                'PulsadoVerBajas = False
                LlenarGrid()
                '  txtBusquedaEmailTelefono.Text = ""
                txtBusquedaEmailTelefono.ForeColor = Color.Red
                'VerBajas()
                HabilitarDesHabilitarAnadirModificarBorrar(True)
                'btnDarDeBaja.Enabled = True
                MenuGrid.PopMenuDarDeBajaCliente.Visible = True
            End If

            'If FiltroBusqueda = txtBusquedaEmailTelefono.Text Then
            '    Return
            'End If

            'If txtBusquedaEmailTelefono.Text <> "" Then
            '    FiltroBusqueda = txtBusquedaEmailTelefono.Text
            '    LlenarGrid()
            '    txtBusquedaEmailTelefono.ForeColor = Color.Red
            '    BuscandoPorTelefonoEmail = True

            '    HabilitarDesHabilitarAnadirModificarBorrar(False)
            '    'btnDarDeBaja.Enabled = True
            '    MenuGrid.PopMenuDarDeBajaCliente.Visible = True

            'Else

            '    BuscandoPorTelefonoEmail = False
            '    FiltroBusqueda = ""

            '    LlenarGrid()
            '    txtBusquedaEmailTelefono.Text = ""
            '    txtBusquedaEmailTelefono.ForeColor = ColorInicialBotonBuscar
            '    BuscandoPorTelefonoEmail = False

            '    PulsadoVerBajas = False
            '    VerBajas()

            '    HabilitarDesHabilitarAnadirModificarBorrar(True)
            '    'btnDarDeBaja.Enabled = True
            '    MenuGrid.PopMenuDarDeBajaCliente.Visible = True


            '    '      View.EditingValue = Gl_ResultadoBusqueda
            'End If



            Try
                HacerCambioFila()
                'Gv.Focus()

                'Gv.FocusedRowHandle = 0
            Catch ex As Exception

            End Try
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

                uGestionDocumental.Titulo("Gestión documental del cliente " & BinSrc.Current("Nombre"))
                uGestionDocumental.RefrescarBotones(BinSrc.Current(CampoGestionDocumental).ToString, TablaGestionDocumental)
            End If
        End Sub



        Private Sub btnInmuebles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInmuebles.Click

            If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
                Return
            End If

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            If BinSrc.Current("TipoVenta") = GL_Palabra_Alquiler Then
                Dim Sel As String = "SELECT COUNT(*) FROM FichasAlquiler WHERE ContadorCliente = " & BinSrc.Current("Contador") & " AND RTRIM(LTRIM(Animales)) <> ''"
                If BD_CERO.Execute(Sel, False) > 0 Then
                    GL_TieneAnimales = True
                Else
                    GL_TieneAnimales = False
                End If
            End If


            CargarFormulario("Inmuebles", "", True, GL_VENGO_DE_CLIENTES, BinSrc.Current("Contador").ToString)

            uInmueblesActivo.Gv.TopRowIndex = 0
            uInmueblesActivo.Gv.FocusedRowHandle = 0
            uInmueblesActivo.Gv.TopRowIndex = 0

            Me.Cursor = System.Windows.Forms.Cursors.Arrow

            Exit Sub
            '  For Each frm As DevExpress.XtraEditors.XtraForm In Me.MdiChildren



            'Try
            '    Application.OpenForms.Item("Inmuebles").Dispose()

            'Catch

            'End Try

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


            'Dim p As New XtraForm1("Inmuebles")
            'p.Name = "Inmuebles"
            'p.ControlBox = False

            ''  Dim u As Object


            'uInmueblesActivo = New ucInmuebles
            'uInmueblesActivo.Dock = DockStyle.Fill
            'p.Controls.Add(uInmueblesActivo)






            'u.Dock = DockStyle.Fill
            'p.Controls.Add(u)




            'p.MdiParent = frmPrincipal
            'p.Show()


            'Me.Cursor = System.Windows.Forms.Cursors.Arrow

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
                If Not BinSrc.Current("Baja") Then
                    BD_CERO.Execute("UPDATE Clientes SET Baja = " & GL_SQL_VALOR_1 & " WHERE Contador=" & BinSrc.Current("Contador"))
                    'FuncionesBD.sp_PasarClienteA(True, BinSrc.Current("Contador"))
                    '   FuncionesGenerales.Funciones.CambiaValorCampoRowActual(bd.ds, TablaMantenimiento, "Baja", 1, , BinSrc.Current("Contador"))
                Else
                    BD_CERO.Execute("UPDATE Clientes SET Baja=0 WHERE Contador=" & BinSrc.Current("Contador"))
                    'FuncionesBD.sp_PasarClienteA(False, BinSrc.Current("Contador"))
                    ' FuncionesGenerales.Funciones.CambiaValorCampoRowActual(bd.ds, TablaMantenimiento, "Baja", 0, , BinSrc.Current("Contador"))
                End If

                '   FiltroBusqueda = ""
                txtBusquedaEmailTelefono.Text = ""
                bd.RefrescarDatos(, , Gv, BinSrc)
                LlenarGrid()
                Me.Cursor = System.Windows.Forms.Cursors.Arrow

                If FilaSeleccionada > 1 Then
                    Gv.FocusedRowHandle = FilaSeleccionada - 1

                Else
                    Try
                        Gv.FocusedRowHandle = FilaSeleccionada + 1
                    Catch ex As Exception
                        'HabilitarDesHabilitarBotones(False)
                    End Try
                End If

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

        Private Sub btnVerBajas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerBajas.Click
            VerBajas()
        End Sub
        Private Sub VerBajas()
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            '   CambiosAltaBaja()
            If Not BinSrc.Current("Baja") Then

                PanelControl3.BackColor = GL_ColorAruraRosaBaja
                PanelBotones.BackColor = GL_ColorAruraRosaBaja
                PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
                PanelBotones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder



                PulsadoVerBajas = True
                'btnDarDeBaja.ForeColor = Color.Red
                'btnDarDeBaja.Text = "Recuperar"
                btnVerBajas.ForeColor = Color.Red
                btnVerBajas.Text = "Ver Altas"
                btnVerBajas.Image = My.Resources.ClientesAlta
                'btnDarDeBaja.Image = My.Resources.DarDeAlta
                MenuGrid.PopMenuDarDeBajaCliente.Text = "Recuperar Cliente"
                HabilitarDesHabilitarAnadirModificarBorrar(False)
            Else

                PanelControl3.BackColor = GL_ColorOriginal
                PanelBotones.BackColor = GL_ColorOriginal
                PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
                PanelBotones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat


                PulsadoVerBajas = False
                'btnDarDeBaja.ForeColor = ColorInicialBotonBajas
                'btnDarDeBaja.Text = "Dar de Baja"
                btnVerBajas.ForeColor = ColorInicialBotonBajas
                btnVerBajas.Text = "Ver Bajas"
                btnVerBajas.Image = My.Resources.ClientesBaja
                'btnDarDeBaja.Image = My.Resources.DarDeBaja
                MenuGrid.PopMenuDarDeBajaCliente.Text = "Dar de Baja Cliente"
                HabilitarDesHabilitarAnadirModificarBorrar(True)
            End If

            'btnDarDeBaja.Enabled = True
            btnVerBajas.Enabled = True
            If bd.ds.Tables(TablaMantenimiento).Rows.Count > 0 Then
                btnModificar.Enabled = True
                btnEliminar.Enabled = True
            End If
            MenuGrid.PopMenuDarDeBajaCliente.Visible = True

            LlenarGrid()

            LlenarTodosCombos()

            Me.Cursor = System.Windows.Forms.Cursors.Arrow



        End Sub

        Private Sub LlenarTodosCombos()

            LlenarCombosCheckEnlazados(True)


            cmbZona.tb_TablaEnlazada = "ClientesZona"
            cmbZona.tb_CampoFiltro = "ContadorCliente"
            cmbZona.tb_Campo = "Zona"

            FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbAgrupaciones, "Agrupaciones", "Agrupacion", "Agrupacion", , , , , , , , False)
            FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbComoConociste, "ComoConociste", "ComoConociste", "ComoConociste", , , , , , , , False)
            FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbEmpleados, "Empleados", "ContadorEmpleado", "Nombre", "Contador", , , "SELECT Contador, Nombre, Baja FROM Empleados E  ORDER BY Nombre", , , , False)

        End Sub

        Private Sub cmbTipoBuscar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoBuscar.SelectedIndexChanged
            If CargandoClientes Then
                Return
            End If
            LlenarGrid()
        End Sub

        Private Sub cmbPerfiles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPerfiles.SelectedIndexChanged
            Dim selectedIndex As Integer = cmbPerfiles.SelectedIndex
            If selectedIndex <> -1 Then
                MenuGrid.AplicarPerfil(cmbPerfiles.EditValue, dgvx)
                AP.ActualizaPerfil(Gv, MenuGrid.mnuPerfilActual.Text.Substring(15))
                If AnadirCheckColunm Then 'añadimos le checkcolumn tras actualizar el perfil
                    Try
                        dgvx.tb_AnadirColumnaCheck = True
                    Catch ex As Exception
                    End Try
                End If
            End If
        End Sub

        Private Sub cmbFiltros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFiltros.SelectedIndexChanged

            'Static Vuelta As Integer

            'If IsNothing(Vuelta) OrElse Vuelta = 0 Then
            '    Vuelta =1
            Dim selectedIndex As Integer = cmbFiltros.SelectedIndex
            If selectedIndex <> -1 Then
                If selectedIndex = 0 Then
                    Gv.ActiveFilterCriteria = Nothing
                Else
                    MenuGrid.AplicarFiltro(cmbFiltros.EditValue, dgvx)
                End If
            End If
            'Else
            'Vuelta = 0
            'End If



            'cmbFiltros.Text = ""
        End Sub


        Private Sub txtBusquedaEmailTelefono_Properties_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtBusquedaEmailTelefono.Properties.ButtonClick
            If e.Button.Index = 0 Then
                txtBusquedaEmailTelefono.Text = ""
                'BuscandoPorTelefonoEmail2 = False
                BusquedaPorTelefonoEmail()
            End If

        End Sub

        Private Sub txtBusquedaEmailTelefono_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBusquedaEmailTelefono.KeyDown
            If e.KeyCode = Keys.Enter Then
                BusquedaPorTelefonoEmail()
            End If
        End Sub

        Private Sub btnVisitas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisitas.Click

            Dim Contador As Integer = 0
            Dim Nombre As String = ""

            If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then

            Else
                Contador = BinSrc.Current("Contador")
                'If IsNothing(txtNombre.EditValue) Then
                '    HacerCambioFila()
                'End If
                Nombre = txtNombre.EditValue
            End If

            Dim f As New frmVisitas(Contador, Nombre, 0, "", GL_VENGO_DE_CLIENTES)
            If PulsadoVerBajas Then f.EsBajas = True
            f.ShowDialog()
            MostrarPanelComunicacionesEnCambioFila()
        End Sub


        Public Sub RefrescarDatosClientes(ByVal ContadorClienteIncial As Integer)

            '************Esto para refrescar datos va ok. lo comento pq ahora lo que necesito es forzar cambio de fila

            Try

                If Not IsNothing(dgvx.ColumnaCheck) Then
                    If Not IsNothing(dgvx.ColumnaCheck.View) Then
                        dgvx.ColumnaCheck.View = Nothing
                    End If
                End If
            Catch ex As Exception

            End Try



            'Dim TopIndexAntes As Integer
            'TopIndexAntes = Gv.TopRowIndex
            bd.RefrescarDatos(, , Gv, BinSrc)
            '      bd.RefrescarDatos(TablaMantenimiento, bd.ds)
            'Gv.TopRowIndex = TopIndexAntes

            If BinSrc.Current("Contador") <> ContadorClienteIncial Then
                SituarseEnGrid(Gv, ContadorClienteIncial, "Contador")
            End If


            Try
                If dgvx.tb_AnadirColumnaCheck Then
                    dgvx.AnadirColumnaCheck()
                End If

            Catch ex As Exception

            End Try
            '************Esto para refrescar datos va ok
        End Sub





        Private Sub cmbEmpleados_QueryPopUp(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbEmpleados.QueryPopUp
            cmbEmpleados.Properties.View.Columns("Contador").Visible = False
            cmbEmpleados.Properties.View.Columns("Baja").Visible = False
        End Sub

        Private Sub cmbAgrupaciones_QueryPopUp(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbAgrupaciones.QueryPopUp
            cmbAgrupaciones.Properties.View.Columns("CodigoEmpresa").Visible = False
            cmbAgrupaciones.Properties.View.Columns("Contador").Visible = False

        End Sub
        Private Sub cmbComoConociste_QueryPopUp(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbComoConociste.QueryPopUp
            cmbComoConociste.Properties.View.Columns("CodigoEmpresa").Visible = False
        End Sub




        Private Sub btnAnadirObservaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnadirObservaciones.Click

            If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
                Return
            End If

            Dim Observaciones As New Tablas.clComunicaciones

            Observaciones.Tipo = GL_OBSERVACIONES_MANUAL
            Observaciones.Tabla = GL_TablaClientes
            Observaciones.ContadorClientePropietarioInmueble = BinSrc.Current("Contador")
            Observaciones.CodigoEmpresa = DatosEmpresa.Codigo
            Observaciones.ContadorEmpleado = GL_CodigoUsuario
            Observaciones.Delegacion = Gl_Delegacion
            Observaciones.Observaciones = GL_Observaciones
            Observaciones.ContadorInmueble = 0

            If ProcesoAnadirObservaciones2(Observaciones) = -1 Then Return

            'ProcesoAnadirObservaciones(False, TablaClientes, BinSrc.Current("Contador"))
            txtObservaciones.Text = Now & " " & GL_Observaciones & vbCrLf & txtObservaciones.Text
            If txtObservaciones.Text.Length > 5000 Then
                txtObservaciones.Text = txtObservaciones.Text.Substring(0, 5000)
            End If
            BD_CERO.Execute("UPDATE Clientes SET Observaciones= '" & Funciones.pf_ReplaceComillas(txtObservaciones.Text) & "' WHERE Contador= " & BinSrc.Current("Contador"))
            bd.RefrescarDatos()
            'LlenarObservaciones(txtObservaciones, BinSrc.Current("Contador"), GL_TablaClientes)

        End Sub





        Private Sub btnFichaAlquiler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFichaAlquiler.Click
            If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then Return
            If dgvx.ColumnaCheck.SelectedCount > 1 Then Return
            Dim a As DataRowView = Gv.GetFocusedRow
            frmFichaAlquiler.ContadorCliente = a.Item("Contador")
            GL_FichaAlquiler = a.Item("FichaAlquiler")
            frmFichaAlquiler.ShowDialog()
            ' CambiaValorCampoRowActual("FichaAlquiler", GL_FichaAlquiler)
            '    FuncionesGenerales.Funciones.CambiaValorCampoRowActual(bd.ds, TablaMantenimiento, "FichaAlquiler", GL_FichaAlquiler)
            bd.RefrescarDatos(BinSrc.Position)
            CambiarColorFichaAlquiler()
        End Sub

        Private Sub btnSeleccionesMultiples_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccionesMultiples.Click

            Dim v As Boolean = Not lbPoblacion.Visible
            MostrarMultiples(v)

        End Sub
        Private Sub MostrarMultiples(v As Boolean)
            MostrarMultiples(lbPoblacion, v)
            '     cmbPoblacion.Visible = Not v
            MostrarMultiples(lbTipo, v)
            MostrarMultiples(lbZona, v)
            MostrarMultiples(lbOrientacion, v)
            MostrarMultiples(lbEstado, v)
        End Sub
        Private Sub MostrarMultiples(ByVal lb As ListBoxControl, ByVal v As Boolean)
            If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then Return
            lb.Visible = v
            If v Then CargarListBox(lb, lb.Tag, BinSrc.Current("Contador"))
        End Sub
        'Private Sub CambiaValorCampoRowActual(Campo As String, Valor As Object)
        '    Dim dr As DataRow = bd.ds.Tables(TablaMantenimiento).Rows.Item(Gv.GetFocusedDataSourceRowIndex)
        '    dr.BeginEdit()
        '    dr(Campo) = Valor
        '    dr.EndEdit()
        '    bd.ds.AcceptChanges()
        'End Sub
        'PRUEBA para filtrar en 3 columnas lo de una
        'Private Sub Gv_ColumnFilterChanged(sender As System.Object, e As System.EventArgs) Handles Gv.ColumnFilterChanged
        '    If (Gv.FilterPanelText.Contains("Telefono") Or Gv.FilterPanelText.Contains("Móvil")) And Not Gv.FilterPanelText.Contains("Y") And Not Gv.FilterPanelText.Contains("O") Then
        '        'MsgBox(Gv.ActiveFilterString.ToString())
        '        Dim buscar As String
        '        If Gv.FilterPanelText.Contains("Telefono1") Or Gv.FilterPanelText.Contains("Telefono2") Then
        '            buscar = Gv.ActiveFilterString.ToString().Substring(11)
        '        Else
        '            buscar = Gv.ActiveFilterString.ToString().Substring(15)
        '        End If
        '        Gv.ActiveFilterString = "[Telefono1] " & buscar & " or [Telefono2] " & buscar & " or [TelefonoMovil] " & buscar
        '    End If
        'End Sub


        'Dim hilo1 As Thread
        'Dim hilo2 As Thread

        Private Sub btnMostrarAccionesComerciales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrarAccionesComerciales.Click
            mostrarAccionesComerciales()

            'If btnMostrarAccionesComerciales.Text = "Mostrar Acciones Comerciales" Then
            '    SplitterItem1.Location = New Point(SplitterItem1.Location.X, 400)
            '    btnMostrarAccionesComerciales.Text = "Ocultar Acciones Comerciales"
            'Else
            '    SplitterItem1.Location = New Point(SplitterItem1.Location.X, 600)
            '    btnMostrarAccionesComerciales.Text = "Mostrar Acciones Comerciales"
            'End If




            'Exit Sub
            'hilo2 = New Thread(AddressOf Hilo2Proceso)
            'hilo2.Start()
            'hilo1 = New Thread(AddressOf Hilo1Proceso)
            'hilo1.Start()

        End Sub
        Private Sub mostrarAccionesComerciales()
            PanelComunicacion.Visible = Not PanelComunicacion.Visible

            If PanelComunicacion.Visible Then

                Dim ContAPasar As Integer
                If DeDondeVengo = GL_VENGO_DE_INMUEBLES Then
                    ContAPasar = ContadorInmuebleDeDondeVengo
                Else
                    ContAPasar = 0
                End If
                '         uComunicacionesDetalle = New ucComunicacionesDetalle()
                If Not IsNothing(BinSrc.Current) Then
                    UcComunicacionesDetalle1.LlenarGrid(BinSrc.Current("Contador"), "Clientes", ContAPasar)
                End If


            End If
        End Sub
        'Private Sub Hilo2Proceso()
        '    Dim p As New XtraForm1("Cargando Novedades")
        '    p.Name = "CargandoNovedades"
        '    p.ControlBox = True
        '    p.Width = 200
        '    p.Height = 20
        '    p.StartPosition = FormStartPosition.CenterScreen
        '    p.BackColor = Color.Red
        '    'p.Show()
        '    p.FormBorderStyle = FormBorderStyle.FixedSingle
        '    p.MinimizeBox = False
        '    p.MaximizeBox = False
        '    p.ShowDialog()
        '    Try
        '        Do While hilo1.IsAlive
        '        Loop
        '    Catch ex As Exception

        '    End Try

        '    p.Dispose()
        '    'hilo2.Abort()
        'End Sub
        'Private Sub Hilo1Proceso()
        '    Dim p As New XtraForm1("Clientes con novedades")
        '    p.Name = "EmailMasivoClientes"
        '    p.ControlBox = False
        '    ucEmailMasivoClientes.Tabla = GL_TablaClientes
        '    ucEmailMasivoClientes.ShowDialog()
        '    Try

        '        hilo2.Abort()
        '        hilo2 = Nothing
        '        hilo1 = Nothing

        '        ucEmailMasivoClientes.Dispose()
        '    Catch ex As Exception

        '    End Try
        '    'Dim u As New ucEmailMasivoClientes()
        '    'u.Dock = DockStyle.Fill
        '    'p.Controls.Add(u)
        '    'p.Width = 800
        '    'p.Height = 600
        '    'p.StartPosition = FormStartPosition.CenterScreen
        '    'p.Visible = False
        '    'p.ShowDialog()
        '    'p.Dispose()
        '    ''   'hilo1.Abort()
        'End Sub


        Private Sub txt_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTelefono1.Leave, txtTelefono2.Leave, txtTelefonoMovil.Leave, txtFax.Leave, txtEmail.Leave, txtNombre.Leave
            If Not EstoyEnAlta Then Return
            If EstoyDesHabilitando Then Return

            Dim txt As TextEdit = TryCast(sender, TextEdit)
            Dim campoWhere As String = ""
            If txt.EditValue = "" Then Return

            Dim YaEncontrado = False

            Select Case txt.Tag
                Case "Email", "Nombre"
                    campoWhere = "WHERE " & txt.Tag & " = '" & Funciones.pf_ReplaceComillas(txt.EditValue) & "'"
                Case Else
                    campoWhere = "WHERE Telefono1 = '" & Funciones.pf_ReplaceComillas(txt.EditValue) & "' OR Telefono2 = '" & Funciones.pf_ReplaceComillas(txt.EditValue) & "' OR TelefonoMovil = '" & Funciones.pf_ReplaceComillas(txt.EditValue) & "' OR Fax = '" & Funciones.pf_ReplaceComillas(txt.EditValue) & "'"
            End Select

            Dim sel As String = GL_SQL_TOP1_FRONT & " Nombre  ,Contador,Baja, " & txt.Tag & "  AS Campos FROM Clientes " & campoWhere & GL_SQL_TOP1_BACK
            Dim bdlost As New BaseDatos
            Dim dtr As Object
            dtr = bdlost.ExecuteReader(sel)

            If dtr.hasrows Then
                dtr.read()
                YaEncontrado = True
                Dim Propietario As String = BuscarPropietario(txt)
                Dim TextoPropietario As String = ""
                If Not Propietario Is Nothing And Not String.IsNullOrEmpty(Propietario) Then
                    TextoPropietario = "También existe un propietario con este " & txt.Tag & ". El propietario es " & Propietario
                    TextoPropietario = vbCrLf & TextoPropietario.ToUpper
                End If

                If XtraMessageBox.Show("Ya existe un cliente (" & dtr("Nombre") & ") con ese " & txt.Tag & " en " & IIf(dtr("Baja"), "bajas", "altas") & vbCrLf & "¿Desea verlo?" & TextoPropietario, "Duplicado", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                    If (Not dtr("Baja") And Not PulsadoVerBajas) Or (dtr("Baja") And PulsadoVerBajas) Then
                        dtr.close()
                        EstoyEnAlta = False
                        Cancelar()
                        BinSrc.Filter = campoWhere.Substring(6)
                        BinSrc.MoveFirst()
                    Else
                        dtr.close()
                        EstoyEnAlta = False
                        Cancelar()
                        VerBajas()
                        BinSrc.Filter = campoWhere.Substring(6)
                        BinSrc.MoveFirst()
                    End If

                End If
            End If
            dtr.close()
            bdlost.CerrarBD()


            If Not YaEncontrado Then

                Dim Propietario As String = BuscarPropietario(txt)


                If Not Propietario Is Nothing And Not String.IsNullOrEmpty(Propietario) Then
                    MensajeInformacion("Existe un propietario con este " & txt.Tag & "." & vbCrLf & "El propietario es " & Propietario)
                End If

            End If


        End Sub

        Private Function BuscarPropietario(ByVal txt As TextEdit) As String

            Dim campos As String = ""


            Select Case txt.Tag 'Buscamos en propietarios
                Case "Email"
                    campos = " WHERE Email = '" & Funciones.pf_ReplaceComillas(txt.EditValue) & "' OR Email2 = '" & Funciones.pf_ReplaceComillas(txt.EditValue) & "'"

                Case Else
                    campos = " WHERE Telefono1 = '" & Funciones.pf_ReplaceComillas(txt.EditValue) & "' OR Telefono2 = '" & Funciones.pf_ReplaceComillas(txt.EditValue) & "' OR Telefono3 = '" & Funciones.pf_ReplaceComillas(txt.EditValue) & "' OR TelefonoMovil = '" & Funciones.pf_ReplaceComillas(txt.EditValue) & "' OR Fax = '" & Funciones.pf_ReplaceComillas(txt.EditValue) & "'"

            End Select


            Dim SelPrpi As String
            Dim bdPropi As New BaseDatos
            Dim Propietario As String
            SelPrpi = GL_SQL_TOP1_FRONT & " Nombre FROM Propietarios " & campos & GL_SQL_TOP1_BACK
            Propietario = bdPropi.Execute(SelPrpi, False)


            Return Propietario

        End Function

        'Private Sub mnuMostrarOcultarDatosGenerales_Click(sender As System.Object, e As System.EventArgs)
        '    If LayoutDatosBusqueda.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never Then
        '        LayoutDatosBusqueda.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        '    Else
        '        LayoutDatosBusqueda.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '    End If
        'End Sub

        'Private Sub mnuMostrarOcultarDatosBusqueda_Click(sender As System.Object, e As System.EventArgs)
        '    If LayoutDatosBusqueda.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never Then
        '        LayoutDatosBusqueda.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        '    Else
        '        LayoutDatosBusqueda.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '    End If
        'End Sub

        Private Sub btnMostrarListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrarListado.Click
            mostrarDetalle()
           
            'If LayoutDatosBusqueda.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never Then
            '    LayoutDatosBusqueda.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            'Else
            '    LayoutDatosBusqueda.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
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
        Private Sub mostrarDetalle()
            PanelCajas2.Visible = Not PanelCajas2.Visible


            If PanelCajas2.Visible AndAlso Me.Height < 800 Then
                ' Gv.OptionsView.ShowFooter = False
                '     Gv.OptionsView.ShowAutoFilterRow = False
            Else
                Gv.OptionsView.ShowFooter = True
                Gv.OptionsView.ShowAutoFilterRow = True
            End If
        End Sub

        Private Sub btnVerTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerTodos.Click
            VerTodos()
        End Sub
        Private Sub VerTodos()
            '            FiltroBusqueda = ""
            txtBusquedaEmailTelefono.Text = ""
            BuscandoPorTelefonoEmail2 = False
            DeDondeVengo = ""
            Gv.ActiveFilterCriteria = Nothing
            Try
                BinSrc.Filter = Nothing
            Catch ex As Exception

            End Try

            LlenarGrid()
        End Sub

        Private Sub BotonSoloNovedades()
            If Not PulsadoVerNovedades Then
                btnSoloNovedades.Text = "Ver todos los clientes que cuadran"
                PulsadoVerNovedades = True
            Else
                btnSoloNovedades.Text = "Ver solo Novedades"
                PulsadoVerNovedades = False
            End If
        End Sub

        Private Sub btnSoloNovedades_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSoloNovedades.Click


            BotonSoloNovedades()


            LlenarGrid()
        End Sub

        Private Sub cmbPoblacion_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cmbPoblacion.EditValueChanged
            LlenarZona()
        End Sub

        Private Sub btnEnviarTextoFijo_Click(sender As System.Object, e As System.EventArgs) Handles btnEnviarTextoFijo.Click
            EnviosDeEmailMasivo(GL_EMAIL_FIJO)
        End Sub

        Private Sub btnEnviarInfo_Click(sender As System.Object, e As System.EventArgs) Handles btnEnviarInfo.Click
            EnviosDeEmailMasivo(GL_EMAIL_DETALLE, , , True)
        End Sub
    
        Private Sub btnOficina_Click(sender As System.Object, e As System.EventArgs) Handles btnOficina.Click
            EnviosDeEmailMasivo(GL_VISITA_OFICINA)
        End Sub
      
       
       
        Private Sub btnEmailNovedades_Click(sender As System.Object, e As System.EventArgs) Handles btnEmailNovedades.Click, btnEmailListadoCompleto.Click

           

            If TryCast(sender, uc_tb_SimpleButton).Name = "btnEmailNovedades" Then
                If lblNovedades.Text = "0 novedades" Then
                    MensajeInformacion("No hay novedades para enviar")
                    Exit Sub
                End If
            End If

            Dim TextoAdicional As String


            Dim f As New tbImputBox("Si quiere añadir un texto al email, escríbalo aquí")
            f.ShowDialog()
            TextoAdicional = Gl_ResultadoBusqueda

            If TextoAdicional = Gl_ResultadoBusqueda_SALIR Then
                MensajeInformacion("Envio cancelado por el usuario")
                Exit Sub
            End If

            If TryCast(sender, uc_tb_SimpleButton).Name = "btnEmailNovedades" Then
                EnviosDeEmailMasivo(GL_EMAIL_LISTADO_NOVEDADES, TextoAdicional, True)
            Else
                EnviosDeEmailMasivo(GL_EMAIL_LISTADO_CLIENTES, TextoAdicional, False, False) 'TT250716 para que no se vean los reservados en este listado pero si en el resto que hasta ahora se veian
            End If

            'lblxdey.Visible = False
            'lblEnviando.Visible = False

            pnlEnviando.Visible = False

        End Sub

         

        Private Sub EnviosDeEmailMasivo(ByVal Tipo As String, Optional ByVal TextoAdicionalAPpoDeEmail As String = "", Optional SoloNovedades As Boolean = False, Optional VerTambienReservados As Boolean = False)

            If dgvx.ColumnaCheck.SelectedCount = 0 And (Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle) Then

                Select Case Tipo

                    Case GL_SMS
                        MensajeError("No ha seleccionado ningún cliente para enviar SMS")
                    Case GL_VISITA_OFICINA
                        MensajeError("No ha seleccionado ningún cliente para marcar como visita")
                    Case Else
                        MensajeError("No ha seleccionado ningún cliente")

                End Select
                Exit Sub
            End If

            'If dgvx.ColumnaCheck.SelectedCount > 1 AndAlso Tipo = GL_LLAMADA_CLIENTE Then
            '    MensajeError("En la opción llamada solo puede seleccionar un cliente")
            '    Exit Sub
            'End If



            If dgvx.ColumnaCheck.SelectedCount > 10 AndAlso Tipo = GL_EMAIL_LISTADO_CLIENTES Then

                If XtraMessageBox.Show("Va en enviar " & dgvx.ColumnaCheck.SelectedCount & " emails." & vbCrLf & "Este proceso puede durar bastante tiempo" & vbCrLf & "¿Quiere continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
                    Exit Sub
                End If

                
            End If

            Dim SeleccionManual As Boolean = False


            Try
                If Tipo <> GL_VISITA_OFICINA Then


                    Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                    pnlEnviado.Left = (PanelCajas2.Width - pnlEnviado.Width) / 2
                    pnlEnviado.Top = (PanelCajas2.Height - pnlEnviado.Height) / 2
                    pnlEnviado.Visible = True
                    pnlEnviado.Enabled = True
                    PanelBotones.Enabled = False
                    lblxdey.Text = "1 de " & dgvx.ColumnaCheck.SelectedCount
                    If dgvx.ColumnaCheck.SelectedCount = 0 Then
                        lblxdey.Text = "1 de 1"
                    End If

                End If
                '   Application.DoEvents()
            Catch ex As Exception

            End Try


            Dim ContadorClienteIncial As Integer = 0
            Dim ContadorCliente As Integer
            Dim Nombre As String = ""
            Dim Email As String = ""
            Dim NoQuiereRecibirEmails As Boolean
            Dim NoQuiereRecibirSMSs As Boolean
            Dim Cadena As String = ""
            Dim CuantosConMail As Integer = 0
            Dim CuantosSinMail As Integer = 0
            Dim ConsumidoresSinMail As New Generic.List(Of String)
            Dim ParaEnvioEmail As Boolean = False
            Dim ParaEnvioSMS As Boolean = False
            Dim ParaLlamar As Boolean = False
            Dim LlamadaContestada As Boolean = False
            Dim CuantosErrores As Integer = 0
            Dim ErrorEnvio As New Generic.List(Of String)

            If Tipo = GL_EMAIL_DETALLE Or Tipo = GL_EMAIL_FIJO Or Tipo = GL_EMAIL_LISTADO_CLIENTES Or Tipo = GL_EMAIL_LISTADO_NOVEDADES Then
                ParaEnvioEmail = True
            End If

            If Tipo = GL_SMS Then
                ParaEnvioSMS = True
            End If

            If Tipo = GL_LLAMADA_DETALLE Or Tipo = GL_COMUNICADO_DETALLE Then
                ParaLlamar = True
            End If
            Dim cont As Integer

            If dgvx.ColumnaCheck.SelectedCount = 0 Then
                dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, True)
                SeleccionManual = True
            End If

            Dim AsuntoYMensaje As Tablas.cl_AsuntoYMensaje = ConsultasBaseDatos.ObtenerAsuntoYCuerpoEmail(Tipo, DatosEmpresa.Codigo, Me.ContadorInmuebleDeDondeVengo, Me.ReferenciaInmuebleDeDondeVengo)


            'lblxdey.Visible = True
            'lblEnviando.Visible = True
            pnlEnviando.Visible = True

            For i As Integer = 0 To dgvx.ColumnaCheck.SelectedCount - 1
                cont = dgvx.ColumnaCheck.GetSelectedRow(i)("Contador")
                lblxdey.Text = i + 1 & " de " & dgvx.ColumnaCheck.SelectedCount
                Application.DoEvents()
                If i = 0 Then
                    ContadorClienteIncial = (TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("Contador")
                End If

                Email = (TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("Email")
                Nombre = (TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("Nombre")
                NoQuiereRecibirEmails = (TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("NoQuiereRecibirEmails")
                NoQuiereRecibirSMSs = (TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("NoQuiereRecibirSMSs")

                If (ParaEnvioEmail AndAlso (Email = "" Or NoQuiereRecibirEmails Or Not FuncionesGenerales.Funciones.validar_Mail(Email))) Or (ParaEnvioSMS And NoQuiereRecibirSMSs) Then
                    CuantosSinMail = CuantosSinMail + 1
                    ConsumidoresSinMail.Add((TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("Nombre"))
                Else

                    CuantosConMail = CuantosConMail + 1

                    ContadorCliente = (TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("Contador")
                    Try

                        Dim ResultadoEnvio As String = ""

                        If ParaEnvioEmail Then
                            'Dim AsuntoYMensaje As Tablas.cl_AsuntoYMensaje = ConsultasBaseDatos.ObtenerAsuntoYCuerpoEmail(Tipo, DatosEmpresa.Codigo, Me.ContadorInmuebleDeDondeVengo, Me.ReferenciaInmuebleDeDondeVengo)
                            If AsuntoYMensaje Is Nothing Then
                                MensajeInformacion("No se encontró información de asunto y mensaje para el envío de emails del tipo seleccionado")
                                Exit Sub
                            End If
                            If TextoAdicionalAPpoDeEmail <> "" Then
                                AsuntoYMensaje.Mensaje = TextoAdicionalAPpoDeEmail & vbCrLf & vbCrLf & AsuntoYMensaje.Mensaje
                                TextoAdicionalAPpoDeEmail = ""
                            End If
                            ResultadoEnvio = EnviosEmailIndividualClientes(Tipo, ContadorCliente, DatosEmpresa.Codigo, Email, Nombre, AsuntoYMensaje, GL_TablaClientes, SoloNovedades, VerTambienReservados)
                        End If

                        If Tipo = GL_COMUNICADO_DETALLE AndAlso Not chkObservacionesAlInformar.Checked Then
                            ParaLlamar = False
                        End If

                        If ParaLlamar Then

                            Dim Observaciones As New Tablas.clComunicaciones

                            If Tipo = GL_COMUNICADO_DETALLE Then
                                Observaciones.Tipo = GL_OBSERVACIONES_INFORMADO
                            Else
                                Observaciones.Tipo = GL_OBSERVACIONES_LLAMADA
                            End If


                            Observaciones.Tabla = GL_TablaClientes
                            Observaciones.ContadorClientePropietarioInmueble = ContadorCliente
                            Observaciones.CodigoEmpresa = DatosEmpresa.Codigo
                            Observaciones.ContadorEmpleado = GL_CodigoUsuario
                            Observaciones.Delegacion = Gl_Delegacion
                            Observaciones.Observaciones = GL_Observaciones
                            Observaciones.ContadorInmueble = Me.ContadorInmuebleDeDondeVengo

                            LlamadaContestada = ProcesoAnadirObservaciones2(Observaciones) '...aqui hay algo q no me cuadra con la variable llamadacontestada


                        Else


                            If ResultadoEnvio = "" Or Tipo = GL_LLAMADA_DETALLE Then



                                Dim Tab As New Tablas.clComunicaciones

                                Tab.CodigoEmpresa = DatosEmpresa.Codigo
                                Tab.Delegacion = Gl_Delegacion
                                Tab.ContadorClientePropietarioInmueble = ContadorCliente
                                Tab.ContadorInmueble = Me.ContadorInmuebleDeDondeVengo
                                Tab.ContadorEmpleado = GL_CodigoUsuario
                                Tab.Fecha = mskFechaAlta.EditValue
                                'Tab.Precio = 0
                                Tab.Tabla = GL_TablaClientes
                                Tab.Tipo = Tipo

                                'Tab.CambioDePrecio = False
                                Tab.LlamadaContestada = LlamadaContestada

                                'Dim TipoVenta As String
                                'TipoVenta = (TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("TipoVenta")


                                ConsultasBaseDatos.InsertarComunicacionesObservaciones(Tab)

                            Else
                                CuantosErrores += 1
                                ErrorEnvio.Add(Nombre & " Motivo: " & ResultadoEnvio)
                            End If

                        End If



                    Catch ex As Exception
                        'MensajeError(ex.Message)
                        CuantosErrores += 1
                        ErrorEnvio.Add(Nombre)
                    End Try

                End If
            Next i

            If SeleccionManual Then
                dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, False)
                SeleccionManual = False
            Else
                dgvx.ColumnaCheck.ClearSelection()
            End If

            'lblxdey.Visible = False
            'lblEnviando.Visible = False

            pnlEnviando.Visible = False

            'Dim s As Object
            'Dim e As System.EventArgs
            'HacerCambioFilaBinding(s, e)



            '************Esto para refrescar datos va ok. lo comento pq ahora lo que necesito es forzar cambio de fila
            'Try
            '    dgvx.ColumnaCheck.View = Nothing
            'Catch ex As Exception

            'End Try

            'Dim TopIndexAntes As Integer
            'TopIndexAntes = Gv.TopRowIndex
            'bd.RefrescarDatos(TablaMantenimiento, bd.ds)
            'Gv.TopRowIndex = TopIndexAntes
            'SituarseEnGrid(Gv, ContadorClienteIncial, "Contador")

            'Try
            '    If dgvx.tb_AnadirColumnaCheck Then
            '        dgvx.AnadirColumnaCheck()
            '    End If

            'Catch ex As Exception

            'End Try
            CargandoClientes = True
            bd.RefrescarDatos(BinSrc.Position)
            'RefrescarDatosClientes(ContadorClienteIncial)
            CargandoClientes = False
            HacerCambioFila()

            '************Esto para refrescar datos va ok

            Try

                pnlEnviado.Visible = False
                PanelBotones.Enabled = True
                Me.Cursor = System.Windows.Forms.Cursors.Arrow
            Catch ex As Exception

            End Try

            If CuantosSinMail > 0 Then
                Dim CadenaMensaje As String = ""

                If Tipo = GL_EMAIL_DETALLE Or Tipo = GL_EMAIL_FIJO Or Tipo = GL_EMAIL_LISTADO_CLIENTES Or Tipo = GL_EMAIL_LISTADO_NOVEDADES Then
                    CadenaMensaje = "Hay " & CuantosSinMail & " clientes de los seleccionados que no se ha podido enviar el email porque no tiene dirección de email o no quieren recibir email o el email no es correcto."
                End If

                If Tipo = GL_SMS Then
                    CadenaMensaje = "Hay " & CuantosSinMail & " clientes de los seleccionados que no se ha podido enviar el SMS porque no quieren recibir SMS's."
                End If

                MensajeError(CadenaMensaje)

                Dim ds As New DataSet
                Dim dt2 As New DataTable("Listado")
                ds.Tables.Add(dt2)
                Dim dc1 As New DataColumn("Texto")
                dt2.Columns.Add(dc1)

                For Each EanNoVal As String In ConsumidoresSinMail
                    Dim dr As DataRow = dt2.NewRow
                    dr("Texto") = EanNoVal.Trim
                    dt2.Rows.Add(dr)
                Next


                ' dt2.WriteXml(My.Application.Info.DirectoryPath & "\EsquemasXML\rptListado.xml")
                'pr_InformeCrystal2008(clVariables.RutaServidor & "\Listados\rptListado.rpt", dt2, , , , "NIF's que no se han podido publicar.")

                Dim r As New rptListado

                r.DataSource = dt2
                r.DataMember = "Listado"
                r.par_Titulo.Value = "Listado de emails no enviados. Fecha: " & Microsoft.VisualBasic.Format(Now, "dd/MM/yyyy HH:mm:ss")
                r.PageHeader.Visible = False
                r.par_Titulo.Visible = False
                r.ShowPreview()

                'For Each s In ConsumidoresSinMail
                '    CadenaMensaje = CadenaMensaje & vbCrLf & s.ToString
                'Next

                'For Each s In ConsumidoresSinMail
                '    CadenaMensaje = CadenaMensaje & vbCrLf & s.ToString
                'Next

            End If
            If CuantosErrores > 0 Then 'Mostramos mensaje con los errores de envio
                Dim CadenaMensaje As String = ""

                CadenaMensaje = "Hay " & CuantosErrores & " clientes de los seleccionados que ha fallado el envio."
                MensajeError(CadenaMensaje)


                Dim ds As New DataSet
                Dim dt2 As New DataTable("Listado")
                ds.Tables.Add(dt2)
                Dim dc1 As New DataColumn("Texto")
                dt2.Columns.Add(dc1)

                For Each EanNoVal As String In ErrorEnvio
                    Dim dr As DataRow = dt2.NewRow
                    dr("Texto") = EanNoVal.Trim
                    dt2.Rows.Add(dr)
                Next


                ' dt2.WriteXml(My.Application.Info.DirectoryPath & "\EsquemasXML\rptListado.xml")
                'pr_InformeCrystal2008(clVariables.RutaServidor & "\Listados\rptListado.rpt", dt2, , , , "NIF's que no se han podido publicar.")

                Dim r As New rptListado

                r.DataSource = dt2
                r.DataMember = "Listado"
                r.par_Titulo.Value = "Listado de emails no enviados. Fecha: " & Microsoft.VisualBasic.Format(Now, "dd/MM/yyyy HH:mm:ss")
                r.PageHeader.Visible = False
                r.par_Titulo.Visible = False
                r.ShowPreview()

                'For Each s In ErrorEnvio
                '    CadenaMensaje = CadenaMensaje & vbCrLf & s.ToString
                'Next

            End If


        End Sub

        
        
        
        Private Sub btnImprimirListado_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimirListado.Click

            If dgvx.ColumnaCheck.SelectedCount > 1 Then
                MensajeError("Solo puede seleccionar un cliente")
                Exit Sub
            End If

            Dim SoloNovedades As Boolean
            If MsgBox("¿Mostrar solo novedades?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                SoloNovedades = True

            Else
                SoloNovedades = False

            End If

            Dim SeleccionManual As Boolean = False

            If dgvx.ColumnaCheck.SelectedCount = 0 Then
                dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, True)
                SeleccionManual = True
            End If


            For i As Integer = 0 To dgvx.ColumnaCheck.SelectedCount - 1
                PrepararFicheroListado((TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("Contador"), SoloNovedades)
            Next

             

            If SeleccionManual Then
                dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, False)
                SeleccionManual = False
            Else
                dgvx.ColumnaCheck.ClearSelection()
            End If

          
        End Sub
 
        Private Sub btnMarcarClienteAlDia_Click(sender As System.Object, e As System.EventArgs) Handles btnMarcarClienteAlDia.Click

            'If dgvx.ColumnaCheck.SelectedCount > 1 Then
            '    MensajeError("Solo puede seleccionar un cliente")
            '    Exit Sub
            'End If

            Dim ContadorClienteIncial As Integer = 0

            If MsgBox("¿Confirma que quiere marcar a los clientes seleccionados como que a fecha de hoy se encuentra informados de todas las novedades?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If

            Dim SeleccionManual As Boolean = False

            If dgvx.ColumnaCheck.SelectedCount = 0 Then
                dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, True)
                SeleccionManual = True
            End If

            Dim ContaCli As Integer

            For i As Integer = 0 To dgvx.ColumnaCheck.SelectedCount - 1
                If i = 0 Then
                    ContadorClienteIncial = (TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("Contador")
                End If

                ContaCli = (TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("Contador")
                BD_CERO.Execute("UPDATE Clientes SET FechaPuestoAlDia =" & gl_sql_getdate & " WHERE Contador = " & ContaCli)
                BD_CERO.Execute("INSERT INTO HistoricoClientesComunicaciones SELECT * FROM ClientesComunicaciones WHERE ContadorCliente =" & ContaCli & " AND ContadorInmueble <> 0")

            Next



            If SeleccionManual Then
                dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, False)
                SeleccionManual = False
            Else
                dgvx.ColumnaCheck.ClearSelection()
            End If

            RefrescarDatosClientes(ContadorClienteIncial)
            HacerCambioFila()


        End Sub
 
        Private Sub btnMarcarComunicado_Click(sender As System.Object, e As System.EventArgs) Handles btnMarcarComunicado.Click
            EnviosDeEmailMasivo(GL_COMUNICADO_DETALLE)
        End Sub
        'Private Sub gv_RowCellStyle(ByVal sender As Object, ByVal e As RowCellStyleEventArgs) Handles Gv.RowCellStyle
        '    Funciones.CHECKSCOLOR(sender, e) ', "'BALCON','PATIO','ASCENSOR','TRASTERO','GARAJE','TERRAZA','GALERIA','AMUEBLADO','SEMIAMUEBLADO','PISCINA','DUPLEX','GARAJECERRADO','JARDIN','COCINAOFFICE','COCINA','CALENTADOR','AIREACONDICIONADO','CALEFACCION','ELECTRODOMESTICOS','PRIMERALINEAPLAYA','VISTASALMAR','ACCESOMINUSVALIDOS','URBANIZACION','ZONACOMERCIAL'")
        'End Sub
        'Private Sub gv_CustomColumnDisplayText(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles Gv.CustomColumnDisplayText
        '    Funciones.CHECKS(sender, e) ', "'BALCON','PATIO','ASCENSOR','TRASTERO','GARAJE','TERRAZA','GALERIA','AMUEBLADO','SEMIAMUEBLADO','PISCINA','DUPLEX','GARAJECERRADO','JARDIN','COCINAOFFICE','COCINA','CALENTADOR','AIREACONDICIONADO','CALEFACCION','ELECTRODOMESTICOS','PRIMERALINEAPLAYA','VISTASALMAR','ACCESOMINUSVALIDOS','URBANIZACION','ZONACOMERCIAL'")
        'End Sub

        Private Sub chkTerraza_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTerraza.CheckedChanged
            If chkTerraza.Checked = False Then
                spnMTerraza.EditValue = 0
            End If
        End Sub

        Private Sub chkJardin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkJardin.CheckedChanged
            If chkJardin.Checked = False Then
                spnMJardin.EditValue = 0
            End If
        End Sub

        Private Sub chkGaraje_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGaraje.CheckedChanged
            If chkGaraje.Checked = False Then
                chkGarajeCerrado.Checked = False
            End If
        End Sub

        'Private Sub chkAscensor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAscensor.CheckedChanged
        '    If chkAscensor.Checked = False Or chkAscensor.Checked = True Then
        '        txtAlturaSinAscensor.EditValue = 0
        '        txtAlturaSinAscensor.Enabled = False
        '    Else
        '        txtAlturaSinAscensor.Enabled = True
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
 
       
        Private Sub chkAscensor_CheckStateChanged(sender As Object, e As System.EventArgs) Handles chkAscensor.CheckStateChanged
            If chkAscensor.CheckState = CheckState.Checked OrElse chkAscensor.CheckState = CheckState.Unchecked Then
                txtAlturaSinAscensor.EditValue = 0
                txtAlturaSinAscensor.Enabled = False
            Else
                txtAlturaSinAscensor.Enabled = True
            End If
        End Sub

        Private Sub chkSemiamueblado_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSemiamueblado.CheckStateChanged
            If chkSemiamueblado.CheckState = CheckState.Checked AndAlso chkAmueblado.CheckState = CheckState.Checked Then
                chkAmueblado.CheckState = CheckState.Indeterminate
            End If
        End Sub

        Private Sub chkAmueblado_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAmueblado.CheckStateChanged
            If chkSemiamueblado.CheckState = CheckState.Checked AndAlso chkAmueblado.CheckState = CheckState.Checked Then
                chkAmueblado.CheckState = CheckState.Indeterminate
            End If
        End Sub

        Private Sub ucClientes_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
            UClienteActivo = Nothing
        End Sub
    End Class
    '***********pruebas para sms's

    '    Dim SerialPort1 As New System.IO.Ports.SerialPort()


    '    SerialPort1.PortName = "COM3"
    '    SerialPort1.BaudRate = 9600
    '    SerialPort1.Parity = Parity.None
    '    SerialPort1.StopBits = StopBits.One
    '    SerialPort1.DataBits = 8
    '    SerialPort1.Handshake = Handshake.RequestToSend
    '    SerialPort1.DtrEnable = True
    '    SerialPort1.RtsEnable = True
    '    SerialPort1.NewLine = vbCrLf



    '    Dim message As String
    '    message = "hh"
    '    SerialPort1.Open()
    '    If SerialPort1.IsOpen() Then
    '        SerialPort1.Write("AT" & vbCrLf)
    '        SerialPort1.Write("AT+CMGF=1" & vbCrLf)
    '        SerialPort1.Write("AT+CMGS=" & Chr(34) & "659744470" & Chr(34) & vbCrLf)
    '        SerialPort1.Write(message & Chr(26))
    '        'MsgBox("Sent")
    '        SerialPort1.Close()
    '    Else
    '        MsgBox("Port not available")
    '    End If
    '
   

End Namespace