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


Namespace Igis



    Partial Public Class ucClientes

        Inherits DevExpress.XtraEditors.XtraUserControl

        '  Dim AnadiendoOModificando As Boolean = False

        '   Dim DocumentosDetalle As ucDocumentosGenerarBase

        Dim Eliminando As Boolean = False
        Dim menu As DXPopupMenu
        Public PopupMenu As DXPopupMenu
        Dim EstoyEnAlta As Boolean

        Dim bd As BaseDatos
        Private WithEvents BinSrc As BindingSource
        Dim TablaMantenimiento As String = "Clientes"
        Dim CargandoClientes As Boolean = True
        Dim PrimeraVez As Boolean

        Dim AP As ActualizaPerfil

        Dim SentenciaSQL As String
        Dim FiltroBusqueda As String = ""
        Dim TablaClientes As String
        Dim TextoInicialBotonBuscar As String = ""
        Dim ColorInicialBotonBuscar As System.Drawing.Color
        Dim CampoInicialBusqueda As String = "Nombre"


        Dim PanelComunicacionesDetalle As DockPanel
        Dim uComunicacionesDetalle As ucComunicacionesDetalle

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

        Private Sub ucClientes_Load(sender As Object, e As System.EventArgs) Handles Me.Load


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
            btnEmailFijo.ForeColor = GL_ColorTextoBotones
            btnEmailDetalle.ForeColor = GL_ColorTextoBotones
            btnEmailListado.ForeColor = GL_ColorTextoBotones
            btnSMS.ForeColor = GL_ColorTextoBotones
            btnLlamadas.ForeColor = GL_ColorTextoBotones
            btnVisitasOficina.ForeColor = GL_ColorTextoBotones
            btnComunicacionesDetalle.ForeColor = GL_ColorTextoBotones

            TablaClientes = GL_TablaClientes
            ' Me.ContadorInmuebleDeDondeVengo = 9 'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX OJO

            'Me.ContadorInmuebleDeDondeVengo = 0
            If ContadorInmuebleDeDondeVengo <> 0 Then
                '        dgvx.Height = dgvx.Height - txtDescripcionInmueble.Height - 100
                txtDescripcionInmueble.Visible = True
                txtDescripcionInmueble.Text = ConsultasBaseDatos.ObtenerDescripcionInmuebleConReferencia(ContadorInmuebleDeDondeVengo)
            Else
                txtDescripcionInmueble.Visible = False
            End If

            ColorInicialTextos = LabelControl1.ForeColor
            ColorInicialBotonBajas = btnVerBajas.ForeColor
            btnComunicacionesDetalle.Text = "Ver" & vbCrLf & "Detalle"


            'chkVenta.Properties.AllowGrayed = False
            'chkAlquiler.Properties.AllowGrayed = False
            'chkTraspaso.Properties.AllowGrayed = False
            'chkVerano.Properties.AllowGrayed = False

            CargandoClientes = True
            PrimeraVez = True

            ColorInicialBotonBuscar = txtBusquedaEmailTelefono.ForeColor

            TablaGestionDocumental = "Clientes"
            CampoGestionDocumental = "Contador"

            LlenarGrid()

            CargandoClientes = True
            AddHandler BinSrc.CurrentItemChanged, AddressOf HacerCambioFilaBinding

            'Bindings


            'txtCodigo.DataBindings.Add(New Binding("EditValue", BinSrc, "Codigo", True))
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

            spnPrecioVentaD.DataBindings.Add(New Binding("EditValue", BinSrc, "PrecioVentaD", True))
            spnPrecioVentaH.DataBindings.Add(New Binding("EditValue", BinSrc, "PrecioVentaH", True))

            spnPrecioAlquilerD.DataBindings.Add(New Binding("EditValue", BinSrc, "PrecioAlquilerD", True))
            spnPrecioAlquilerH.DataBindings.Add(New Binding("EditValue", BinSrc, "PrecioAlquilerH", True))

            spnPrecioVeranoD.DataBindings.Add(New Binding("EditValue", BinSrc, "PrecioVeranoD", True))
            spnPrecioVeranoH.DataBindings.Add(New Binding("EditValue", BinSrc, "PrecioVeranoH", True))

            spnPrecioTraspasoD.DataBindings.Add(New Binding("EditValue", BinSrc, "PrecioTraspasoD", True))
            spnPrecioTraspasoH.DataBindings.Add(New Binding("EditValue", BinSrc, "PrecioTraspasoH", True))

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

            chkVenta.DataBindings.Add(New Binding("CheckState", BinSrc, "Venta", True))
            chkVerano.DataBindings.Add(New Binding("CheckState", BinSrc, "Verano", True))
            chkAlquiler.DataBindings.Add(New Binding("CheckState", BinSrc, "Alquiler", True))
            chkTraspaso.DataBindings.Add(New Binding("CheckState", BinSrc, "Traspaso", True))

            chkNoQuiereRecibirEmails.DataBindings.Add(New Binding("CheckState", BinSrc, "NoQuiereRecibirEmails", True))
            chkNoQuiereRecibirSMSs.DataBindings.Add(New Binding("CheckState", BinSrc, "NoQuiereRecibirSMSs", True))

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

            chkPrimeraLineaPlaya.DataBindings.Add(New Binding("CheckState", BinSrc, "PrimeraLineaPlaya", True))
            chkZonaComercial.DataBindings.Add(New Binding("CheckState", BinSrc, "ZonaComercial", True))

            ucCocina.DataBindings.Add(New Binding("Valor", BinSrc, "Cocina", True))
            ucCalentador.DataBindings.Add(New Binding("Valor", BinSrc, "Calentador", True))

            mskSMS.DataBindings.Add(New Binding("EditValue", BinSrc, "FechaSMS", True))
            mskEmailListado.DataBindings.Add(New Binding("EditValue", BinSrc, "FechaEmailListado", True))
            mskLlamada.DataBindings.Add(New Binding("EditValue", BinSrc, "FechaLlamada", True))
            mskEmailFijo.DataBindings.Add(New Binding("EditValue", BinSrc, "FechaEmailFijo", True))
            mskVisitaOficina.DataBindings.Add(New Binding("EditValue", BinSrc, "FechaVisitaOficina", True))
            mskEmailDetalle.DataBindings.Add(New Binding("EditValue", BinSrc, "FechaEmailDetalle", True))
            txtReferenciaEmailDetalle.DataBindings.Add(New Binding("EditValue", BinSrc, "ReferenciaEmailDetalle", True))
            txtReferenciaLlamada.DataBindings.Add(New Binding("EditValue", BinSrc, "ReferenciaLlamada", True))
            txtReferenciaOficina.DataBindings.Add(New Binding("EditValue", BinSrc, "ReferenciaVisitaOficina", True))
            txtReferenciaSMS.DataBindings.Add(New Binding("EditValue", BinSrc, "ReferenciaSMS", True))


            PrepararLlenarCheckCombosClientes(cmbPoblacion, "Poblacion")
            PrepararLlenarCheckCombosClientes(cmbZona, "Zona")
            PrepararLlenarCheckCombosClientes(cmbTipo, "Tipo")
            PrepararLlenarCheckCombosClientes(cmbOrientacion, "Orientacion")
            PrepararLlenarCheckCombosClientes(cmbEstado, "Estado")

            ' LlenarLst(lstEmails, "ComunicacionesEmailDetalle")

            '' LayoutControl1.Items(0).Visibility = False


            ''Combos
            FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbAgrupaciones, "Agrupaciones", "Agrupacion", "Agrupacion", , , " WHERE CodigoEmpresa = " & DatosEmpresa.Codigo, , , , , False)
            FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbComoConociste, "ComoConociste", "ComoConociste", "ComoConociste", , , " WHERE CodigoEmpresa = " & DatosEmpresa.Codigo, , , , , False)
            FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbEmpleados, "Empleados", "ContadorEmpleado", "Nombre", "Contador", , , "SELECT Contador, Nombre, NIF,Alias,Baja FROM Empleados WHERE CodigoEmpresa = " & DatosEmpresa.Codigo & " ORDER BY Nombre", , , , False)

            ParametrizarGrid(Gv, False)

            dgvx.tbCarpetaPerfiles = GL_CARPETA_PERFILES & "\" & Me.Name & "\" & dgvx.Name
            MenuGrid = New tbContextMenuStripComponent(dgvx.tbCarpetaPerfiles, cmbPerfiles2)
            dgvx.ContextMenuStrip = MenuGrid
            '  dgvx.ContextMenuStrip.Items.Add("Copiar Perfiles", Nothing, AddressOf CopiarPerfilesDgvX)
            dgvx.ContextMenuStrip.Items.Add("Gestión Documental", Nothing, AddressOf dgvxGestDoc)

            ConfigurarGrid()

            uComunicacionesDetalle = New ucComunicacionesDetalle(DatosEmpresa.Codigo)
            CrearPanelFlotanteNueva(DockManager1, PanelComunicacionesDetalle, uComunicacionesDetalle, 600, 300)

            If AnadirCheckColunm Then
                Try
                    dgvx.tb_AnadirColumnaCheck = True
                    '    ColumnaCheck.View = Nothing


                Catch ex As Exception

                End Try

                '   ColumnaCheck = New GridCheckMarksSelection(Gv)


            End If

            uGestionDocumental = New ucGestionDocumental
            CrearPanelFlotanteNueva(DockManager1, PanelGestionDocumental, uGestionDocumental, 600, 300)


            CargandoClientes = False

            HabilitarBotones()
            HabilitarDesHabilitarCajas(False)

            PonerFocoRowFilterEnGridView(Gv, CampoInicialBusqueda)
            Try
                Gv.Focus()
            Catch ex As Exception

            End Try

            'Dim dataSource As DataView = CreateTable(3).DefaultView
            'MyGridLookupDataSourceHelper.SetupGridLookUpEdit(cmbPerfiles, dataSource, "Name", "ID")

            'Dim MenuGrid As New tbContextMenuStripComponent(dgvx.tbCarpetaPerfiles)
            'MenuGrid.CargarPerfilesEnComboExterior(cmbPerfiles)


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

        Private Sub HacerCambioFilaBinding(sender As Object, e As System.EventArgs)


            'txtReferenciaEmailDetalle.EditValue = ""
            'mskEmailDetalle.EditValue = ""
            'mskEmailFijo.EditValue = ""
            'mskLlamada.EditValue = ""
            'mskVisitaOficina.EditValue = ""
            'mskSMS.EditValue = ""

            If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
                Return
            End If

            LlenarObservaciones()





            'Dim dtr As SqlClient.SqlDataReader
            'Dim bdPobs As New BaseDatos()
            'Dim Sel As String = "EXEC sp_ObtenerUltimasComunicaciones  " & BinSrc.Current("Contador")
            'dtr = bdPobs.ExecuteReader(Sel)
            'If dtr.HasRows Then
            '    While dtr.Read

            '        Select Case UCase(dtr("Tipo"))
            '            Case GL_EMAIL_DETALLE
            '                mskEmailDetalle.EditValue = dtr("Fecha")
            '                txtReferencia.EditValue = dtr("Referencia")
            '            Case GL_EMAIL_FIJO
            '                mskEmailFijo.EditValue = dtr("Fecha")
            '            Case GL_EMAIL_LISTADO_CLIENTES
            '                mskEmailListado.EditValue = dtr("Fecha")
            '            Case GL_LLAMADA_CLIENTE
            '                mskLlamada.EditValue = dtr("Fecha")
            '            Case GL_VISITA_OFICINA
            '                mskVisitaOficina.EditValue = dtr("Fecha")
            '            Case GL_SMS
            '                mskSMS.EditValue = dtr("Fecha")

            '        End Select

            '    End While
            'End If
            'bdPobs.CerrarBD()

            If PanelComunicacionesDetalle.Visibility = DockVisibility.Visible Then
                uComunicacionesDetalle.LlenarGrid(BinSrc.Current("Contador"))
            End If

        End Sub

        Private Sub LlenarObservaciones()
            txtObservaciones.Text = ""
            Dim dt As DataTable
            dt = ConsultasBaseDatos.ObtenerObservaciones(BinSrc.Current("Contador"), TablaClientes)

            If dt IsNot Nothing Then
                Dim Observaciones As String = ""
                For Each dr In dt.Rows
                    If Observaciones = "" Then
                        Observaciones = dr("Observacion")
                    Else
                        Observaciones = Observaciones & vbCrLf & dr("Observacion")
                    End If
                Next
                txtObservaciones.Text = Observaciones
            End If
        End Sub
        Private Sub PrepararLlenarCheckCombosClientes(cmb As uc_tb_CombosCheck, Tabla As String)

            cmb.tb_TablaCompleta = Tabla
            cmb.tb_TablaEnlazada = "Clientes" & Tabla
            cmb.tb_Campo = Tabla
            cmb.tb_CampoFiltro = "ContadorCliente"
            cmb.tb_LlenarCompleta()
            cmb.DataBindings.Add(New Binding("tb_ValorBusqueda", BinSrc, "Contador", True, DataSourceUpdateMode.Never))
            '    cmb.DataBindings.Add(New Binding("tb_ValorBusqueda", BinSrc, "Codigo", True))
        End Sub

        Private Sub LlenarLst(lst As uc_tb_lst, Tabla As String)


            lst.tb_Orden = " Fecha DESC"
            lst.tb_TablaEnlazada = Tabla
            lst.tb_Campo = "dbo.fnFormatDate (Fecha, 'DD/MM/YY')   + ' Ref: ' +  Referencia AS Fecha"

            lst.tb_CampoFiltro = "Contador"
            lst.DataBindings.Add(New Binding("tb_ValorBusqueda", BinSrc, "Contador", True, DataSourceUpdateMode.Never))


        End Sub

        Public Sub LlenarGrid()

            CargandoClientes = True

            Dim FiltroSelect As String

            If FiltroBusqueda = "" Then
                FiltroSelect = ""
            Else
                FiltroSelect = " AND (Telefono1 LIKE '%" & FiltroBusqueda & "' OR  Telefono2 LIKE '%" & FiltroBusqueda & "' OR  TelefonoMovil LIKE '%" & FiltroBusqueda & "' OR  Email LIKE '%" & FiltroBusqueda & "%')"

            End If
            Dim TextoBaja As String = ""

            If TablaClientes = GL_TablaClientesBaja Then
                TextoBaja = "Baja"
            End If

            Dim FiltroTotal As String = ""
            Dim FiltroInmueble As String = ""

            If DeDondeVengo = GL_VENGO_DE_INMUEBLES Then
                FiltroInmueble = " Contador IN (SELECT Contador FROM [dbo].[ObtenerClientesQueCuadran] (" & ContadorInmuebleDeDondeVengo & "))"
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

            Dim SubConsultaFechaEmail = "(SELECT TOP 1 Fecha FROM ClientesComunicacionesEmailDetalle" & TextoBaja & " WHERE ContadorInmueble = " & ContadorInmuebleDeDondeVengo & " AND ContadorCliente = T.Contador ORDER BY Fecha DESC) AS FEmail, "
            Dim SubConsultaFechaLlamada = "(SELECT TOP 1 Fecha FROM ClientesComunicacionesLlamada" & TextoBaja & " WHERE ContadorInmueble = " & ContadorInmuebleDeDondeVengo & " AND ContadorCliente = T.Contador ORDER BY Fecha DESC) AS FLlamada, "
            Dim SubConsultaFechaSMS = "(SELECT TOP 1 Fecha FROM ClientesComunicacionesSMS" & TextoBaja & " WHERE ContadorInmueble = " & ContadorInmuebleDeDondeVengo & " AND ContadorCliente = T.Contador ORDER BY Fecha DESC) AS FSMS, "

            Dim SubConsultaComunicaciones As String = ""
            If ContadorInmuebleDeDondeVengo <> 0 Then
                SubConsultaComunicaciones = SubConsultaFechaEmail & SubConsultaFechaLlamada & SubConsultaFechaSMS
            End If

            'SentenciaSQL = "SELECT " & SubConsultaComunicaciones & " * FROM " & TablaClientes & " T WHERE CodigoEmpresa = " & DatosEmpresa.Codigo & FiltroSelect & _
            '" ORDER BY Nombre"

            If FiltroBusqueda = "" Then
                SentenciaSQL = "SELECT " & SubConsultaComunicaciones & " * FROM " & TablaClientes & " T WHERE CodigoEmpresa = " & DatosEmpresa.Codigo & FiltroTotal & _
                               " ORDER BY Nombre"
            Else
                SentenciaSQL = "SELECT *, convert(bit,0) as Baja FROM " & GL_TablaClientes & " T WHERE CodigoEmpresa = " & DatosEmpresa.Codigo & FiltroTotal & _
                             " UNION ALL SELECT *, convert(bit,1) as Baja FROM " & GL_TablaClientesBaja & " T WHERE CodigoEmpresa = " & DatosEmpresa.Codigo & FiltroTotal & _
                             " ORDER BY Nombre"
            End If


            'Dim Tab As New Tablas.clTablaGeneral(TablaMantenimiento, , SentenciaSQL)
            'bd = New BaseDatos
            'Tab.Datos(bd, Tab.ConsultaAEjecutar, , , , , True, False)


            bd = New BaseDatos
            bd.LlenarDataSet(SentenciaSQL, TablaMantenimiento)

            If PrimeraVez Then
                BinSrc = New BindingSource
            End If
            '   
            BinSrc.DataSource = bd.ds
            BinSrc.DataMember = TablaMantenimiento

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

        End Sub

        Private Sub AnadirONoLasColumnasDeFecha()

            Try

                If ContadorInmuebleDeDondeVengo = 0 Then
                    Gv.Columns("FLlamada").OptionsColumn.AllowShowHide = False
                    Gv.Columns("FLlamada").Visible = False

                    Gv.Columns("FSMS").OptionsColumn.AllowShowHide = False
                    Gv.Columns("FSMS").Visible = False

                    Gv.Columns("FEmail").OptionsColumn.AllowShowHide = False
                    Gv.Columns("FEmail").Visible = False
                Else
                    Gv.Columns("FLlamada").OptionsColumn.AllowShowHide = True
                    Gv.Columns("FLlamada").Visible = True

                    Gv.Columns("FSMS").OptionsColumn.AllowShowHide = True
                    Gv.Columns("FSMS").Visible = True

                    Gv.Columns("FEmail").OptionsColumn.AllowShowHide = True
                    Gv.Columns("FEmail").Visible = True


                End If

                Dim condition1 As StyleFormatCondition

                condition1 = New DevExpress.XtraGrid.StyleFormatCondition()
                condition1.Tag = "1"
                condition1.Appearance.BackColor = Color.IndianRed
                condition1.Appearance.Options.UseBackColor = True
                condition1.Condition = FormatConditionEnum.Expression
                condition1.Expression = "[FLlamada] <> NULL"
                Gv.FormatConditions.Add(condition1)

                condition1 = New DevExpress.XtraGrid.StyleFormatCondition()
                condition1.Appearance.BackColor = Color.Plum
                condition1.Appearance.Options.UseBackColor = True
                condition1.Condition = FormatConditionEnum.Expression
                condition1.Expression = "[FSMS] <> NULL"
                Gv.FormatConditions.Add(condition1)

                condition1 = New DevExpress.XtraGrid.StyleFormatCondition()
                condition1.Appearance.BackColor = Color.Salmon
                condition1.Appearance.Options.UseBackColor = True
                condition1.Condition = FormatConditionEnum.Expression
                condition1.Expression = "[FEmail] <> NULL AND [FLlamada] <> NULL"
                Gv.FormatConditions.Add(condition1)

                condition1 = New DevExpress.XtraGrid.StyleFormatCondition()
                condition1.Appearance.BackColor = Color.PaleTurquoise
                condition1.Appearance.Options.UseBackColor = True
                condition1.Condition = FormatConditionEnum.Expression
                condition1.Expression = "[FEmail] <> NULL AND [FLlamada] is NULL"
                Gv.FormatConditions.Add(condition1)

                condition1 = New DevExpress.XtraGrid.StyleFormatCondition()
                condition1.Appearance.BackColor = Color.Red
                condition1.Appearance.Options.UseBackColor = True
                condition1.Condition = FormatConditionEnum.Expression
                condition1.Expression = "[Baja] = true"
                Gv.FormatConditions.Add(condition1)

                If Gv.Columns("Baja") IsNot Nothing Then
                    Gv.Columns("Baja").Visible = False
                    Gv.Columns("Baja").OptionsColumn.AllowShowHide = False
                End If

            Catch ex As Exception

            End Try
        End Sub

        Private Sub ConfigurarGrid()

            If Not PrimeraVez Then
                Exit Sub
            End If

            PrimeraVez = False
            If dgvx.tbEstablecerPerfilPredeterminado() Then
                cmbPerfiles2.EditValue = dgvx.tbPerfilPredeterminado
                cmbPerfiles2.Text = dgvx.tbPerfilPredeterminado & "(Predeterminado)"

                AnadirONoLasColumnasDeFecha()
                Exit Sub
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



            Gv.Columns("CodigoEmpresa").OptionsColumn.AllowShowHide = False
            Gv.Columns("CodigoEmpresa").Visible = False

            Gv.Columns("Contador").OptionsColumn.AllowShowHide = False
            Gv.Columns("Contador").Visible = False

            Gv.Columns("Delegacion").OptionsColumn.AllowShowHide = False
            Gv.Columns("Delegacion").Visible = False

            Gv.Columns("ContadorEmpleado").Visible = False

            Gv.Columns("Venta").Visible = False
            Gv.Columns("Alquiler").Visible = False
            Gv.Columns("AlquilerOpcionCompra").Visible = False
            Gv.Columns("Traspaso").Visible = False
            Gv.Columns("NIF").Visible = False
            Gv.Columns("Direccion").Visible = False
            Gv.Columns("Poblacion").Visible = False
            Gv.Columns("CodPostal").Visible = False
            Gv.Columns("Provincia").Visible = False
            Gv.Columns("Pais").Visible = False

            Gv.Columns("Fax").Visible = False
            Gv.Columns("Email").Visible = False
            Gv.Columns("Web").Visible = False
            Gv.Columns("Banos").Visible = False
            Gv.Columns("MetrosD").Visible = False
            Gv.Columns("MetrosH").Visible = False

            Gv.Columns("PrecioVentaD").Visible = False
            Gv.Columns("PrecioVentaH").Visible = False
            Gv.Columns("PrecioAlquilerD").Visible = False

            Gv.Columns("PrecioAlquilerH").Visible = False
            Gv.Columns("PrecioTraspasoD").Visible = False
            Gv.Columns("PrecioTraspasoH").Visible = False
            Gv.Columns("PrecioVeranoD").Visible = False
            Gv.Columns("PrecioVeranoH").Visible = False
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
            Gv.Columns("FechaEmailListado").Visible = False
            Gv.Columns("FechaVisitaOficina").Visible = False
            Gv.Columns("FechaEmailDetalle").Visible = False
            Gv.Columns("ReferenciaEmailDetalle").Visible = False
            Gv.Columns("ReferenciaLlamada").Visible = False
            Gv.Columns("ReferenciaSMS").Visible = False
            Gv.Columns("ReferenciaVisitaOficina").Visible = False

            Try


                Gv.Columns("FEmail").Caption = "F. Email"
                Gv.Columns("FLlamada").Caption = "F. Llamada"
                Gv.Columns("FSMS").Caption = "F. SMS"

            Catch ex As Exception

            End Try

            Gv.Columns("Verano").Visible = False
            Gv.Columns("FechaAlta").Visible = False
            Gv.Columns("ComoConociste").Visible = False

            Gv.Columns("TelefonoMovil").Caption = "Móvil"
            Gv.Columns("FechaLlamada").Caption = "Llamada"

            Gv.Columns("FechaEmailFijo").Caption = "EMail Fijo"
            Gv.Columns("FechaSMS").Caption = "SMS"
            Gv.Columns("FechaEmailListado").Caption = "Email Listado"
            Gv.Columns("FechaVisitaOficina").Caption = "V. Oficina"
            Gv.Columns("FechaEmailDetalle").Caption = "Email Detalle"
            Gv.Columns("ReferenciaEmailDetalle").Caption = "Ref. Email Listado"

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
            Gv.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways

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

        Private Sub MyGridView1_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)

            Try


                Dim View As GridView = sender

                If e.Column.FieldName = "Disponible" Then
                    If e.CellValue < 0 Then
                        e.Appearance.BackColor = Color.Salmon
                        e.Appearance.BackColor2 = Color.SeaShell
                        e.Appearance.GradientMode = Drawing2D.LinearGradientMode.BackwardDiagonal
                        'Else
                        '    e.Appearance.BackColor = Color.LightGreen
                        '    e.Appearance.BackColor2 = Color.GreenYellow
                        '    'e.Appearance.BackColor = Color.DeepSkyBlue
                        '    'e.Appearance.BackColor2 = Color.LightCyan

                    End If
                End If

            Catch ex As Exception

            End Try


            'If e.Column.FieldName = "BloqueoTemporal" Then
            '    If e.CellValue = True Then
            '        e.Appearance.BackColor = Color.PapayaWhip
            '        e.Appearance.BackColor2 = Color.Orange
            '        e.Appearance.GradientMode = Drawing2D.LinearGradientMode.BackwardDiagonal
            '        'Else
            '        '    e.Appearance.BackColor = Color.LightGreen
            '        '    e.Appearance.BackColor2 = Color.GreenYellow
            '        '    'e.Appearance.BackColor = Color.DeepSkyBlue
            '        '    'e.Appearance.BackColor2 = Color.LightCyan

            '    End If
            'End If

        End Sub

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
            '   txtCodigo.Enabled = False
            txtNombre.Focus()

        End Sub

        Private Sub PrepararAlta()

            HabilitarDesHabilitarCajas(True)

            '   FechaAltaDateEdit.EditValue = Microsoft.VisualBasic.Today 'Microsoft.VisualBasic.Format(Microsoft.VisualBasic.Today, "dd/MM/yyyy")
            chkNoQuiereRecibirEmails.EditValue = False
            chkNoQuiereRecibirSMSs.EditValue = False
            ' cmbEmpleados.EditValue = cmbEmpleados.Properties.GetDisplayTextByKeyValue(GL_CodigoUsuario).ToString
            cmbEmpleados.EditValue = GL_CodigoUsuario



            '   txtCodigo.Text = ""



            PonerChecksEnIndeterminado()
            '    txtCodigo.Enabled = False


            txtNombre.Focus()

            DesHabilitarBotones()

        End Sub

        Private Sub PonerChecksEnIndeterminado()


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

            chkElectrodomesticos.CheckState = CheckState.Indeterminate
            chkGaleria.CheckState = CheckState.Indeterminate
            chkAireAcondicionado.CheckState = CheckState.Indeterminate
            chkCalefaccion.CheckState = CheckState.Indeterminate
            ucCocina.Valor = vbNull
            ucCalentador.Valor = vbNull
            chkPrimeraLineaPlaya.CheckState = CheckState.Indeterminate





            spnPrecioVentaD.EditValue = 0
            spnPrecioVentaH.EditValue = 999999

            spnPrecioAlquilerD.EditValue = 0
            spnPrecioAlquilerH.EditValue = 999999

            spnPrecioTraspasoD.EditValue = 0
            spnPrecioTraspasoH.EditValue = 999999

            spnPrecioVeranoD.EditValue = 0
            spnPrecioVeranoH.EditValue = 999999

            spnAlturaD.EditValue = 0
            spnAlturaH.EditValue = 99

            spnMetrosD.EditValue = 0
            spnMetrosH.EditValue = 99999

            spnHabitacionesD.EditValue = 0
            spnHabitacionesH.EditValue = 99

            ucCocina.Valor = Nothing
            ucCalentador.Valor = Nothing




        End Sub
        Private Sub HabilitarDesHabilitarCajas(Habilitar As Boolean)


            For Each c As Control In PanelCajas.Controls
                c.Enabled = Habilitar
            Next

            For Each c As Control In PanelCajas2.Controls
                If c.Name <> "GroupControl1" And c.Name <> "lblPersonas" And c.Name <> "lblMPlaya" Then
                    'If c.Name <> "lblPersonas" And c.Name <> "lblMPlaya" And c.Name <> "ucCocina" And c.Name <> "ucCalentador" Then
                    c.Enabled = Habilitar
                End If
            Next

            For Each c As Control In GroupControl1.Controls
                c.Enabled = Habilitar
            Next



            'cmbPoblacion.Enabled = True
            'cmbZona.Enabled = True
            'cmbOrientacion.Enabled = True
            'cmbTipo.Enabled = True
            'cmbEstado.Enabled = True

            cmbPoblacion.tb_HabilitarDesHabilitarItems(Habilitar)
            cmbZona.tb_HabilitarDesHabilitarItems(Habilitar)
            cmbTipo.tb_HabilitarDesHabilitarItems(Habilitar)
            cmbOrientacion.tb_HabilitarDesHabilitarItems(Habilitar)
            cmbEstado.tb_HabilitarDesHabilitarItems(Habilitar)


            '     cmbEmpleados.Enabled = False
            mskFecha.Enabled = False

            If Habilitar Then

                ucCocina.tb_ReadOnly = Not Habilitar
                ucCalentador.tb_ReadOnly = Not Habilitar

                '    HabilitarDesHabilitarVenta(chkVenta.Checked)
                '    HabilitarDesHabilitarAlquiler(chkAlquiler.Checked)
                '    HabilitarDesHabilitarTraspaso(chkTraspaso.Checked)
                '    HabilitarDesHabilitarVerano(chkVerano.Checked)
                'Else
                '    HabilitarDesHabilitarVenta(Habilitar)
                '    HabilitarDesHabilitarAlquiler(Habilitar)
                '    HabilitarDesHabilitarTraspaso(Habilitar)
                '    HabilitarDesHabilitarVerano(Habilitar)
            End If

            HabilitarDesHabilitarVenta(chkVenta.Checked)
            HabilitarDesHabilitarAlquiler(chkAlquiler.Checked)
            HabilitarDesHabilitarTraspaso(chkTraspaso.Checked)
            HabilitarDesHabilitarVerano(chkVerano.Checked)

            gControlComunicaciones.Enabled = Not Habilitar
            btnEmailFijo.Enabled = Not Habilitar
            btnEmailDetalle.Enabled = Not Habilitar
            btnEmailListado.Enabled = Not Habilitar
            btnSMS.Enabled = Not Habilitar
            btnVisitasOficina.Enabled = Not Habilitar
            btnLlamadas.Enabled = Not Habilitar



            mskEmailListado.Enabled = False

            HabilitarDesHabilitarBotonesEspecialesCuandoVengoDeInmuebles(Not Habilitar)

            RCPrecioCompra.Enabled = True
            RCPrecioAlquiler.Enabled = True
            RCPrecioTraspaso.Enabled = True
            RCPrecioVerano.Enabled = True
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





        End Sub

        Private Function Actualizar() As Boolean
            Try

                Me.Validate()

                If Not ComprobarDatos() Then
                    Return False
                End If

                If EstoyEnAlta Then
                    BinSrc.Current("FechaAlta") = Microsoft.VisualBasic.Today
                    BinSrc.Current("CodigoEmpresa") = DatosEmpresa.Codigo


                    ''XXXXXXXXXXXXXX?????añado estas lineas ya que da error al crear y no estas estos datos
                    BinSrc.Current("Delegacion") = Gl_Delegacion
                    If BinSrc.Current("Alquiler").ToString = "" Then BinSrc.Current("Alquiler") = 0
                    If BinSrc.Current("Venta").ToString = "" Then BinSrc.Current("Venta") = 0
                    If BinSrc.Current("Verano").ToString = "" Then BinSrc.Current("Verano") = 0
                    If BinSrc.Current("Traspaso").ToString = "" Then BinSrc.Current("Traspaso") = 0
                    If BinSrc.Current("AlquilerOpcionCompra").ToString = "" Then BinSrc.Current("AlquilerOpcionCompra") = 0
                    If BinSrc.Current("Pais").ToString = "" Then BinSrc.Current("Pais") = ""
                    If BinSrc.Current("Telefono1").ToString = "" Then BinSrc.Current("Telefono1") = ""
                    If BinSrc.Current("Telefono2").ToString = "" Then BinSrc.Current("Telefono2") = ""
                    If BinSrc.Current("TelefonoMovil").ToString = "" Then BinSrc.Current("TelefonoMovil") = ""
                    If BinSrc.Current("Fax").ToString = "" Then BinSrc.Current("Fax") = ""
                    If BinSrc.Current("Email").ToString = "" Then BinSrc.Current("Email") = ""
                    If BinSrc.Current("Web").ToString = "" Then BinSrc.Current("Web") = ""
                    If BinSrc.Current("NoQuiereRecibirEmails").ToString = "" Then BinSrc.Current("NoQuiereRecibirEmails") = 0
                    If BinSrc.Current("NoQuiereRecibirSMSs").ToString = "" Then BinSrc.Current("NoQuiereRecibirSMSs") = 0
                    If BinSrc.Current("Banos").ToString = "" Then BinSrc.Current("Banos") = 0
                    If BinSrc.Current("ComoConociste").ToString = "" Then BinSrc.Current("ComoConociste") = ""
                    If BinSrc.Current("Agrupacion").ToString = "" Then BinSrc.Current("Agrupacion") = ""
                    If BinSrc.Current("Personas").ToString = "" Then BinSrc.Current("Personas") = 0
                    If BinSrc.Current("MPlaya").ToString = "" Then BinSrc.Current("MPlaya") = 0
                    If BinSrc.Current("MTerraza").ToString = "" Then BinSrc.Current("MTerraza") = 0
                    If BinSrc.Current("MJardin").ToString = "" Then BinSrc.Current("MJardin") = 0
                    If BinSrc.Current("PisoAscensor").ToString = "" Then BinSrc.Current("PisoAscensor") = 0

                    '    txtCodigo.EditValue = CStr(clGenerales.SiguienteRegistro("CONVERT(INT,Codigo) ", "Clientes", " WHERE CodigoEmpresa = " & DatosEmpresa.Codigo))


                    cmbPoblacion.EstoyEnAlta = True
                    cmbZona.EstoyEnAlta = True
                    cmbTipo.EstoyEnAlta = True
                    cmbEstado.EstoyEnAlta = True
                    cmbOrientacion.EstoyEnAlta = True

                End If

                BinSrc.EndEdit()

                Dim ValorClaveAntes As Object = BinSrc.Current("Contador")

                If Not ActualizarBaseDatos() Then


                    cmbPoblacion.CadenaConLosValores = ""
                    cmbZona.CadenaConLosValores = ""
                    cmbTipo.CadenaConLosValores = ""
                    cmbEstado.CadenaConLosValores = ""
                    cmbOrientacion.CadenaConLosValores = ""

                    Return False
                End If

                ActualizaDatosTodosCombosAuxiliares()

                'Me.ClientesTableAdapter.Update(DsClientes.Clientes)
                'DsClientes.AcceptChanges()
                'Me.ClientesTableAdapter.Fill(Me.DsClientes.Clientes)
                If Not Eliminando AndAlso ValorClaveAntes IsNot Nothing Then
                    SituarseEnGrid(Gv, ValorClaveAntes.ToString, "Contador")
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

        Private Sub ActualizaDatosTodosCombosAuxiliares()

            cmbPoblacion.tb_ActualizaDatosCombos()
            cmbTipo.tb_ActualizaDatosCombos()
            cmbZona.tb_ActualizaDatosCombos()
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
        '        Sel = "DELETE FROM " & Tabla & " WHERE CodigoCliente = '" & txtCodigo.EditValue & "'"
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
        Private Function ActualizarBaseDatos(Optional RefrescarDatos As Boolean = False) As Boolean

            Try
                bd.ActualizarCambios(TablaMantenimiento, bd.ds, RefrescarDatos)
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

            Return True

        End Function

        Private Sub dgvx_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvx.KeyDown

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

            btnVerBajas.Enabled = True
            btnDarDeBaja.Enabled = True
            btnVisitas.Enabled = True
            btnInmuebles.Enabled = True
            btnEmails.Enabled = True
            btnAnadirObservaciones.Enabled = True
            btnFichaAlquiler.Enabled = True
            dgvx.Enabled = True

            'For Each Page As DevExpress.XtraTab.XtraTabPage In XtraTabControl1.TabPages
            '    Page.PageEnabled = True
            'Next

            HabilitarDesHabilitarBotonesEspecialesCuandoVengoDeInmuebles(True)

            If TablaClientes = GL_TablaClientesBaja Then
                btnVisitas.Enabled = False
            End If

        End Sub
        Private Sub HabilitarDesHabilitarBotonesEspecialesCuandoVengoDeInmuebles(Habilitar As Boolean)
            If Me.ContadorInmuebleDeDondeVengo <> 0 Then
                btnEmailDetalle.Enabled = Habilitar
            Else
                btnEmailDetalle.Enabled = False
            End If
        End Sub

        Private Sub DesHabilitarBotones()

            btnAnadir.Enabled = False
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
            btnSalir.Enabled = False
            btnAceptar.Enabled = True
            btnCancelar.Enabled = True

            btnVerBajas.Enabled = False
            btnDarDeBaja.Enabled = False
            btnVisitas.Enabled = False
            btnInmuebles.Enabled = False
            btnEmails.Enabled = False
            btnAnadirObservaciones.Enabled = False
            btnFichaAlquiler.Enabled = False

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

        Private Sub habilitabotones(si As Boolean)

            btnModificar.Enabled = si
            btnEliminar.Enabled = si

            If Not si Then
                btnAceptar.Enabled = si
                btnCancelar.Enabled = si
            End If

            btnDarDeBaja.Enabled = si
            btnInmuebles.Enabled = si
            btnAnadirObservaciones.Enabled = si

        End Sub
        Public Sub FocusedColor()
            Dim b As Color
            Dim a As DataRowView = Gv.GetFocusedRow
            With Gv.Appearance.FocusedRow
                .ForeColor = Color.Black
                Try


                    If Not IsDBNull(a.Item("FEmail")) And IsDBNull(a.Item("FLlamada")) Then
                        b = Color.PaleTurquoise
                        .BackColor = Color.FromArgb(255, b.R + 50, b.G + 15, b.B + 15)
                        Exit Sub
                    End If
                    If Not IsDBNull(a.Item("FEmail")) And Not IsDBNull(a.Item("FLlamada")) Then
                        b = Color.Salmon
                        .BackColor = Color.FromArgb(255, b.R + 5, b.G + 50, b.B + 50)
                        Exit Sub
                    End If
                    If Not IsDBNull(a.Item("FSMS")) Then
                        b = Color.Plum
                        .BackColor = Color.FromArgb(255, b.R + 30, b.G + 50, b.B + 30)
                        Exit Sub
                    End If
                    If Not IsDBNull(a.Item("FLlamada")) Then
                        b = Color.IndianRed
                        .BackColor = Color.FromArgb(255, b.R + 50, b.G + 50, b.B + 50)
                        Exit Sub
                    End If
                Catch ex As Exception

                End Try
                'If Gv.Columns("Mark") IsNot Nothing Then
                Try
                    If a.Item("Baja") = True Then
                        b = Color.Red
                        .BackColor = Color.FromArgb(255, b.R, b.G + 100, b.B + 100)
                        Exit Sub
                    End If
                    'End If
                Catch
                End Try
                .BackColor = Color.FromArgb(255, 80, 160, 240)
                .ForeColor = Color.White

            End With

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

        Private Sub HacerCambioFila()

            If CargandoClientes Then
                Exit Sub
            End If
            habilitabotones(False)
            If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
                Exit Sub
            End If
            habilitabotones(True)

            If PanelGestionDocumental.Visibility = DockVisibility.Visible Then
                uGestionDocumental.RefrescarBotones(BinSrc.Current(CampoGestionDocumental), TablaGestionDocumental)
            End If

            'cmbPoblacion.tb_ValorBusqueda = txtCodigo.EditValue
            'cmbZona.tb_ValorBusqueda = txtCodigo.EditValue
            'cmbTipo.tb_ValorBusqueda = txtCodigo.EditValue
            'cmbOrientacion.tb_ValorBusqueda = txtCodigo.EditValue
            'cmbEstado.tb_ValorBusqueda = txtCodigo.EditValue






            'XtraTabControl1.TabPages(0).Text = "Cliente " & BinSrc.Current("Nombre")



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




            'If PanelComunicaciones.Visibility = DockVisibility.Visible Then
            '    uComunicaciones.LlenarGrid(BinSrc.Current("Contador"), 0, 0)
            'End If

        End Sub
        Private Sub LlenarCombosAuxiliaresSoloConSusDatos(cmb As CheckedComboBoxEdit, Tabla As String, Campo As String, Optional Filtro As String = "")

            Dim bdPobs As New BaseDatos()
            Dim Tab As New Tablas.clTablaGeneral(Tabla, , "SELECT " & Campo & " FROM " & Tabla & " WHERE ContadorCliente = '" & BinSrc.Current("Contador") & "'", )
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
            'Sel = "SELECT " & Campo & " FROM " & Tabla & " WHERE CodigoCliente = '" & BinSrc.Current("Contador") & "'"
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

        Private Sub BusquedaPorTelefonoEmail()

            If FiltroBusqueda <> "" Then
                FiltroBusqueda = ""
                LlenarGrid()
                txtBusquedaEmailTelefono.Text = ""
                txtBusquedaEmailTelefono.ForeColor = ColorInicialBotonBuscar
                Return
            End If

            If FiltroBusqueda = txtBusquedaEmailTelefono.Text Then
                Return
            End If

            If txtBusquedaEmailTelefono.Text <> "" Then
                FiltroBusqueda = txtBusquedaEmailTelefono.Text
                LlenarGrid()
                txtBusquedaEmailTelefono.ForeColor = Color.Red
            Else

                FiltroBusqueda = ""
                LlenarGrid()
                txtBusquedaEmailTelefono.Text = ""
                txtBusquedaEmailTelefono.ForeColor = ColorInicialBotonBuscar
                '      View.EditingValue = Gl_ResultadoBusqueda
            End If

            Dim condition1 As StyleFormatCondition
            condition1 = New DevExpress.XtraGrid.StyleFormatCondition()
            condition1.Appearance.BackColor = Color.Red
            condition1.Appearance.Options.UseBackColor = True
            condition1.Condition = FormatConditionEnum.Expression
            condition1.Expression = "[Baja] = true"
            Gv.FormatConditions.Add(condition1)

            ''If Gv.Columns("baja") IsNot Nothing Then
            ''    Gv.Columns("baja").Visible = False
            ''    Gv.Columns("baja").OptionsColumn.AllowShowHide = False
            ''End If


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

                uGestionDocumental.RefrescarBotones(BinSrc.Current(CampoGestionDocumental).ToString, TablaGestionDocumental)
            End If
        End Sub

        'Private Sub PreparaDatosComboCheck(cmb As CheckedComboBoxEdit, Tabla As String, Campo As String)
        '    Dim bdPobs As New BaseDatos()

        '    Dim Sel As String
        '    Dim dtr As SqlDataReader

        '    Sel = "SELECT " & Campo & " FROM " & Tabla & " WHERE CodigoCliente = '" & BinSrc.Current("Contador") & "'"
        '    Dim Elementos As String = ""
        '    dtr = bdPobs.ExecuteReader(Sel)
        '    If dtr.HasRows Then
        '        While dtr.Read
        '            If Elementos = "" Then
        '                Elementos = dtr(Campo)
        '            Else
        '                Elementos = Elementos & ";" & dtr(Campo)
        '            End If

        '        End While
        '    End If
        '    bdPobs.CerrarBD()

        '    cmb.SetEditValue(Elementos)

        '    If Not btnAceptar.Enabled Then
        '        For Each c As CheckedListBoxItem In cmb.Properties.Items
        '            c.Enabled = False
        '        Next
        '    End If


        'End Sub

        Private Sub mnuMostrarOcultarDatosGenerales_Click(sender As System.Object, e As System.EventArgs) Handles mnuMostrarOcultarDatosGenerales.Click
            If LayoutDatosBusqueda.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never Then
                LayoutDatosBusqueda.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            Else
                LayoutDatosBusqueda.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            End If
        End Sub

        Private Sub mnuMostrarOcultarDatosBusqueda_Click(sender As System.Object, e As System.EventArgs) Handles mnuMostrarOcultarDatosBusqueda.Click
            If LayoutDatosBusqueda.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never Then
                LayoutDatosBusqueda.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            Else
                LayoutDatosBusqueda.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            End If
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
        Private Sub chkTraspaso_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkTraspaso.CheckedChanged
            If chkTraspaso.Enabled Then
                HabilitarDesHabilitarTraspaso(chkTraspaso.Checked)
            End If

        End Sub
        Private Sub chkVerano_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkVerano.CheckedChanged
            If chkVerano.Enabled Then
                HabilitarDesHabilitarVerano(chkVerano.Checked)
            End If

        End Sub


        Private Sub HabilitarDesHabilitarVenta(Habilitar As Boolean)

            spnPrecioVentaD.Enabled = chkVenta.Checked
            spnPrecioVentaD.Properties.ReadOnly = Not chkVenta.Enabled

            spnPrecioVentaH.Enabled = chkVenta.Checked
            spnPrecioVentaH.Properties.ReadOnly = Not chkVenta.Enabled

            PintarRCPrecioCompra()


        End Sub

        Private Sub PintarRCPrecioCompra()
            If chkVenta.Checked Then
                RCPrecioCompra.AppearanceCaption.ForeColor = Color.Red
            Else
                RCPrecioCompra.AppearanceCaption.ForeColor = ColorInicialTextos
            End If
        End Sub

        Private Sub HabilitarDesHabilitarAlquiler(Habilitar As Boolean)
            spnPrecioAlquilerD.Enabled = chkAlquiler.Checked
            spnPrecioAlquilerD.Properties.ReadOnly = Not chkAlquiler.Enabled

            spnPrecioAlquilerH.Enabled = chkVenta.Checked
            spnPrecioAlquilerH.Properties.ReadOnly = Not chkAlquiler.Enabled
            PintarRCPrecioAlquiler()
        End Sub
        Private Sub PintarRCPrecioAlquiler()
            If chkAlquiler.Checked Then
                RCPrecioAlquiler.AppearanceCaption.ForeColor = Color.Red
            Else
                RCPrecioAlquiler.AppearanceCaption.ForeColor = ColorInicialTextos
            End If
        End Sub
        Private Sub HabilitarDesHabilitarTraspaso(Habilitar As Boolean)
            spnPrecioTraspasoD.Enabled = chkTraspaso.Checked
            spnPrecioTraspasoD.Properties.ReadOnly = Not chkTraspaso.Enabled

            spnPrecioTraspasoH.Enabled = chkTraspaso.Checked
            spnPrecioTraspasoH.Properties.ReadOnly = Not chkTraspaso.Enabled
            PintarRCPrecioTraspaso()
        End Sub
        Private Sub PintarRCPrecioTraspaso()
            If chkTraspaso.Checked Then
                RCPrecioTraspaso.AppearanceCaption.ForeColor = Color.Red
            Else
                RCPrecioTraspaso.AppearanceCaption.ForeColor = ColorInicialTextos
            End If
        End Sub
        Private Sub HabilitarDesHabilitarVerano(Habilitar As Boolean)
            spnPrecioVeranoD.Enabled = chkVerano.Checked
            spnPrecioVeranoD.Properties.ReadOnly = Not chkVerano.Enabled

            spnPrecioVeranoH.Enabled = chkVerano.Checked
            spnPrecioVeranoH.Properties.ReadOnly = Not chkVerano.Enabled
            spnPersonas.Enabled = Habilitar
            PintarRCPrecioVerano()
        End Sub
        Private Sub PintarRCPrecioVerano()
            If chkVerano.Checked Then
                RCPrecioVerano.AppearanceCaption.ForeColor = Color.Red
            Else
                RCPrecioVerano.AppearanceCaption.ForeColor = ColorInicialTextos
            End If
        End Sub
        Private Sub btnInmuebles_Click(sender As System.Object, e As System.EventArgs) Handles btnInmuebles.Click

            'If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            '    Return
            'End If

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            CargarFormulario("Inmuebles", True, GL_VENGO_DE_CLIENTES, BinSrc.Current("Contador").ToString)
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

        Private Sub btnDarDeBaja_Click(sender As System.Object, e As System.EventArgs) Handles btnDarDeBaja.Click

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ActualizarBajaAlta()
            Me.Cursor = System.Windows.Forms.Cursors.Arrow

        End Sub

        Private Function ActualizarBajaAlta() As Boolean

            Try

                If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
                    Return False
                End If

                Dim Texto As String
                If TablaClientes = GL_TablaClientes Then
                    Texto = "¿Confirma que quiere dar de baja el registro seleccionado?"
                Else
                    Texto = "¿Confirma que quiere dar de alta el registro seleccionado?"
                End If

                If XtraMessageBox.Show(Texto, "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
                    Return False
                End If

                If TablaClientes = GL_TablaClientes Then
                    bd.Execute("sp_PasarClienteABaja " & BinSrc.Current("Contador"))
                Else
                    bd.Execute("sp_PasarClienteAAlta " & BinSrc.Current("Contador"))
                End If
                'BinSrc.Current("Baja") = Not BinSrc.Current("Baja")
                'BinSrc.EndEdit()


                'Dim ValorClaveAntes As Object = BinSrc.Current("Contador")

                If Not ActualizarBaseDatos(True) Then
                    Return False
                End If

                'ActualizaDatosTodosCombosAuxiliares()

                ''Me.ClientesTableAdapter.Update(DsClientes.Clientes)
                ''DsClientes.AcceptChanges()
                '' Me.ClientesTableAdapter.Fill(Me.DsClientes.Clientes)
                'If Not Eliminando AndAlso ValorClaveAntes IsNot Nothing Then
                '    SituarseEnGrid(Gv, ValorClaveAntes.ToString, "Contador")
                'End If
                'HabilitarBotones()
                'HabilitarDesHabilitarCajas(False)
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

        Private Sub btnVerBajas_Click(sender As System.Object, e As System.EventArgs) Handles btnVerBajas.Click

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor


            If TablaClientes = GL_TablaClientes Then
                TablaClientes = GL_TablaClientesBaja
                btnDarDeBaja.ForeColor = Color.Red
                btnDarDeBaja.Text = "Dar de Alta"
                btnVerBajas.ForeColor = Color.Red
                btnVerBajas.Text = "Ver Altas"
                btnVerBajas.Image = My.Resources.ClientesAlta
                btnDarDeBaja.Image = My.Resources.DarDeAlta
            Else
                TablaClientes = GL_TablaClientes
                btnDarDeBaja.ForeColor = ColorInicialBotonBajas
                btnDarDeBaja.Text = "Dar de Baja"
                btnVerBajas.ForeColor = ColorInicialBotonBajas
                btnVerBajas.Text = "Ver Bajas"
                btnVerBajas.Image = My.Resources.ClientesBaja
                btnDarDeBaja.Image = My.Resources.DarDeBaja
            End If



            LlenarGrid()


            Me.Cursor = System.Windows.Forms.Cursors.Arrow

        End Sub

        Private Sub cmbPerfiles2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbPerfiles2.SelectedIndexChanged
            Dim selectedIndex As Integer = cmbPerfiles2.SelectedIndex
            If selectedIndex <> -1 Then
                MenuGrid.AplicarPerfil(cmbPerfiles2.EditValue, dgvx)
                AP.ActualizaPerfil(Gv, MenuGrid.mnuPerfilActual.Text.Substring(15))
                If AnadirCheckColunm Then 'añadimos le checkcolumn tras actualizar el perfil
                    Try
                        dgvx.tb_AnadirColumnaCheck = True
                    Catch ex As Exception
                    End Try
                End If
            End If
        End Sub

        Private Sub txtBusquedaEmailTelefono_Properties_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtBusquedaEmailTelefono.Properties.ButtonClick
            If e.Button.Index = 0 Then
                BusquedaPorTelefonoEmail()
            End If

        End Sub

        Private Sub txtBusquedaEmailTelefono_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtBusquedaEmailTelefono.KeyDown
            If e.KeyCode = Keys.Enter Then
                BusquedaPorTelefonoEmail()
            End If
        End Sub

        Private Sub btnVisitas_Click(sender As System.Object, e As System.EventArgs) Handles btnVisitas.Click

            Dim Contador As Integer = 0
            Dim Nombre As String = ""

            If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then

            Else
                Contador = BinSrc.Current("Contador")
                Nombre = txtNombre.EditValue
            End If

            Dim f As New frmVisitas(Contador, Nombre, 0, "")
            f.ShowDialog()
        End Sub

        Private Sub btnEmailListado_Click(sender As System.Object, e As System.EventArgs) Handles btnEmailListado.Click


            EnviosDeEmailMasivo(GL_EMAIL_LISTADO_CLIENTES)

        End Sub

        Private Sub EnviosDeEmailMasivo(Tipo)



            If dgvx.ColumnaCheck.SelectedCount = 0 And (Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle) Then

                Select Case Tipo
                    Case GL_LLAMADA_CLIENTE
                        MensajeError("No ha seleccionado ningún cliente para llamar")
                    Case GL_SMS
                        MensajeError("No ha seleccionado ningún cliente para enviar SMS")
                    Case GL_VISITA_OFICINA
                        MensajeError("No ha seleccionado ningún cliente para marcar como visita")
                    Case Else
                        MensajeError("No ha seleccionado ningún cliente al que enviar email")
                End Select
                Exit Sub
            End If

            If dgvx.ColumnaCheck.SelectedCount > 1 AndAlso Tipo = GL_LLAMADA_CLIENTE Then
                MensajeError("En la opción llamada solo puede seleccionar un cliente")
                Exit Sub
            End If

            If dgvx.ColumnaCheck.SelectedCount > 10 AndAlso Tipo = GL_EMAIL_LISTADO_CLIENTES Then
                MensajeError("En la opción Listado Email solo puede seleccionar como máximo bloques de 10 clientes")
                Exit Sub
            End If




            '   Dim MensajeAEnviar As String = ""


            'If Tipo = GL_EMAIL_LISTADO_CLIENTES Then


            '    Dim f As New tbImputBox("Indique el mensaje del email")
            '    f.txtResultado.Text = "Listado de inmuebles que se ajustan a sus necesidades"
            '    f.ShowDialog()
            '    MensajeAEnviar = Gl_ResultadoBusqueda

            '    If MensajeAEnviar = "" Or MensajeAEnviar = Gl_ResultadoBusqueda_SALIR Then
            '        MensajeInformacion("Email no enviado")
            '        Exit Sub
            '    End If

            '    MensajeAEnviar = MensajeAEnviar & vbCrLf & vbCrLf & "Para ver fotos, pinche en la referencia"
            'End If 

            Dim SeleccionManual As Boolean = False

            If dgvx.ColumnaCheck.SelectedCount = 0 Then
                dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, True)
                SeleccionManual = True
            End If


            Try

                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                pnlEnviado.Left = (PanelCajas2.Width - pnlEnviado.Width) / 2
                pnlEnviado.Top = (PanelCajas2.Height - pnlEnviado.Height) / 2
                pnlEnviado.Visible = True
                pnlEnviado.Enabled = True
                PanelBotones.Enabled = False
                lblxdey.Text = "1 de " & dgvx.ColumnaCheck.SelectedCount
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
            Dim LlamadaContestada As Integer = 0

            If Tipo = GL_EMAIL_DETALLE Or Tipo = GL_EMAIL_FIJO Or Tipo = GL_EMAIL_LISTADO_CLIENTES Then
                ParaEnvioEmail = True
            End If

            If Tipo = GL_SMS Then
                ParaEnvioSMS = True
            End If

            If Tipo = GL_LLAMADA_CLIENTE Then
                ParaLlamar = True
            End If

            For i As Integer = 0 To dgvx.ColumnaCheck.SelectedCount - 1

                lblxdey.Text = i + 1 & " de " & dgvx.ColumnaCheck.SelectedCount
                Application.DoEvents()
                If i = 0 Then
                    ContadorClienteIncial = (TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("Contador")
                End If

                Email = (TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("Email")
                Nombre = (TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("Nombre")
                NoQuiereRecibirEmails = (TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("NoQuiereRecibirEmails")
                NoQuiereRecibirSMSs = (TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("NoQuiereRecibirSMSs")

                If (ParaEnvioEmail And (Email = "" Or NoQuiereRecibirEmails Or Not FuncionesGenerales.Funciones.validar_Mail(Email))) Or (ParaEnvioSMS And NoQuiereRecibirSMSs) Then
                    CuantosSinMail = CuantosSinMail + 1
                    ConsumidoresSinMail.Add((TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("Nombre"))
                Else
                    CuantosConMail = CuantosConMail + 1

                    ContadorCliente = (TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("Contador")
                    Try

                        Dim ResultadoEnvio As String = ""

                        If ParaEnvioEmail Then
                            Dim AsuntoYMensaje As Tablas.cl_AsuntoYMensaje = ConsultasBaseDatos.ObtenerAsuntoYCuerpoEmail(Tipo, DatosEmpresa.Codigo, Me.ContadorInmuebleDeDondeVengo, Me.ReferenciaInmuebleDeDondeVengo)
                            If AsuntoYMensaje Is Nothing Then
                                MensajeInformacion("No se encontró información de asunto y mensaje para el envío de emails del tipo seleccionado")
                                Exit Sub
                            End If
                            ResultadoEnvio = EnviosEmailIndividual(Tipo, ContadorCliente, DatosEmpresa.Codigo, Email, Nombre, AsuntoYMensaje)
                        End If


                        If ParaLlamar Then
                            LlamadaContestada = ProcesoAnadirObservaciones(True, TablaClientes, ContadorCliente)
                        End If

                        If ResultadoEnvio = "" Then

                            Dim Tab As New Tablas.clComunicaciones

                            Tab.CodigoEmpresa = DatosEmpresa.Codigo
                            Tab.Delegacion = Gl_Delegacion
                            Tab.ContadorCliente = ContadorCliente
                            Tab.ContadorInmueble = Me.ContadorInmuebleDeDondeVengo
                            Tab.ContadorEmpleado = GL_CodigoUsuario
                            Tab.Fecha = mskFecha.EditValue
                            Tab.PrecioEnvioVenta = 0
                            Tab.PrecioEnvioAlquiler = 0
                            Tab.PrecioEnvioVerano = 0
                            Tab.PrecioEnvioTraspaso = 0

                            Tab.CambioDePrecio = False
                            Tab.LlamadaContestada = LlamadaContestada

                            Dim QueBuscaCliente As New Tablas.clTipoVentaCliente
                            QueBuscaCliente.Venta = (TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("Venta")
                            QueBuscaCliente.Alquiler = (TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("Alquiler")
                            QueBuscaCliente.Verano = (TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("Verano")
                            QueBuscaCliente.Traspaso = (TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("Traspaso")


                            ConsultasBaseDatos.InsertarComunicaciones(Tab, QueBuscaCliente, Tipo)

                            'Select Case Tipo

                            '    Case GL_EMAIL_LISTADO_CLIENTES, GL_EMAIL_FIJO, GL_LLAMADA_CLIENTE, GL_SMS, GL_VISITA_OFICINA

                            '        Dim Tab As New Tablas.clEmailsEnviados

                            '        Tab.CodigoEmpresa = DatosEmpresa.Codigo
                            '        Tab.Delegacion = Gl_Delegacion
                            '        Tab.ContadorCliente = ContadorCliente
                            '        Tab.ContadorInmueble = 0
                            '        Tab.ContadorEmpleado = GL_CodigoUsuario

                            '        ConsultasBaseDatos.InsertarComunicacionesVarios(Tab, Tipo)


                            '    Case GL_EMAIL_DETALLE

                            '        Dim Tab As New Tablas.clEmailsEnviados

                            '        Tab.CodigoEmpresa = DatosEmpresa.Codigo
                            '        Tab.Delegacion = Gl_Delegacion
                            '        Tab.ContadorCliente = ContadorCliente
                            '        Tab.ContadorInmueble = Me.ContadorInmuebleDeDondeVengo
                            '        Tab.ContadorEmpleado = GL_CodigoUsuario
                            '        Tab.Fecha = mskFecha.EditValue
                            '        Tab.PrecioEnvioVenta = 0
                            '        Tab.PrecioEnvioAlquiler = 0
                            '        Tab.PrecioEnvioVerano = 0
                            '        Tab.PrecioEnvioTraspaso = 0

                            '        Tab.CambioDePrecio = False

                            '        Dim QueBuscaCliente As New Tablas.clTipoVentaCliente
                            '        QueBuscaCliente.Venta = (TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("Venta")
                            '        QueBuscaCliente.Alquiler = (TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("Alquiler")
                            '        QueBuscaCliente.Verano = (TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("Verano")
                            '        QueBuscaCliente.Traspaso = (TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("Traspaso")



                            '        ConsultasBaseDatos.InsertarComunicacionesEmailDetalle(Tab, QueBuscaCliente)

                            'End Select
                        End If



                    Catch ex As Exception
                        MensajeError(ex.Message)
                    End Try

                End If
            Next i

            If SeleccionManual Then
                dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, False)
                SeleccionManual = False
            Else
                dgvx.ColumnaCheck.ClearSelection()
            End If



            Dim s As Object
            Dim e As System.EventArgs
            HacerCambioFilaBinding(s, e)


            '************Esto para refrescar datos va ok. lo comento pq ahora lo que necesito es forzar cambio de fila
            Try
                dgvx.ColumnaCheck.View = Nothing
            Catch ex As Exception

            End Try

            Dim TopIndexAntes As Integer
            TopIndexAntes = Gv.TopRowIndex
            bd.RefrescarDatos(TablaMantenimiento, bd.ds)
            Gv.TopRowIndex = TopIndexAntes
            SituarseEnGrid(Gv, ContadorClienteIncial, "Contador")

            Try
                If dgvx.tb_AnadirColumnaCheck Then
                    dgvx.AnadirColumnaCheck()
                End If

            Catch ex As Exception

            End Try
            '************Esto para refrescar datos va ok

            Try

                pnlEnviado.Visible = False
                PanelBotones.Enabled = True
                Me.Cursor = System.Windows.Forms.Cursors.Arrow
            Catch ex As Exception

            End Try

            If CuantosSinMail > 0 Then
                Dim CadenaMensaje As String = ""

                If Tipo = GL_EMAIL_DETALLE Or Tipo = GL_EMAIL_FIJO Or Tipo = GL_EMAIL_LISTADO_CLIENTES Then
                    CadenaMensaje = "Hay " & CuantosSinMail & " clientes de los seleccionados que no se ha podido enviar el email porque no tiene dirección de email o no quieren recibir email o el email no es correcto."
                End If

                If Tipo = GL_SMS Then
                    CadenaMensaje = "Hay " & CuantosSinMail & " clientes de los seleccionados que no se ha podido enviar el SMS porque no quieren recibir SMS's."
                End If

                For Each s In ConsumidoresSinMail
                    CadenaMensaje = CadenaMensaje & vbCrLf & s.ToString
                Next
                MensajeError(CadenaMensaje)
            End If



        End Sub

        Private Sub btnEmailDetalle_Click(sender As System.Object, e As System.EventArgs) Handles btnEmailDetalle.Click
            EnviosDeEmailMasivo(GL_EMAIL_DETALLE)
        End Sub
        Private Sub btnEmailFijo_Click(sender As System.Object, e As System.EventArgs) Handles btnEmailFijo.Click
            EnviosDeEmailMasivo(GL_EMAIL_FIJO)
        End Sub
        Private Sub btnSMS_Click(sender As System.Object, e As System.EventArgs) Handles btnSMS.Click
            EnviosDeEmailMasivo(GL_SMS)
        End Sub
        Private Sub btnLlamadas_Click(sender As System.Object, e As System.EventArgs) Handles btnLlamadas.Click
            EnviosDeEmailMasivo(GL_LLAMADA_CLIENTE)
        End Sub
        Private Sub btnVisitasOficina_Click(sender As System.Object, e As System.EventArgs) Handles btnVisitasOficina.Click
            EnviosDeEmailMasivo(GL_VISITA_OFICINA)
        End Sub

        Private Function EnviosEmailIndividual(Tipo As String, ContadorCliente As Integer, CodigoEmpresa As Integer, Email As String, Nombre As String, AsuntoYMensaje As Tablas.cl_AsuntoYMensaje) As String


            Dim Sel As String = ""


            'Si no pasamos el email, es pq no lo tenemos, hay que buscarlo y validarlo
            If Email = "" Then

                Dim NoQuiereRecibirEmails As Boolean

                Dim dtr As SqlDataReader
                Dim bdPobs As New BaseDatos()
                Sel = "SELECT Nombre, Email,NoQuiereRecibirEmails FROM Clientes WHERE Contador = " & ContadorCliente
                Dim Elementos As String = ""
                dtr = bdPobs.ExecuteReader(Sel)
                If dtr.HasRows Then
                    While dtr.Read
                        Nombre = dtr("Nombre")
                        Email = dtr("Email")
                        NoQuiereRecibirEmails = dtr("NoQuiereRecibirEmails")
                    End While
                End If
                bdPobs.CerrarBD()

                If Trim(Email) = "" Then
                    Return ("El cliente seleccionado no tiene direccion de e-mail")

                End If

                If NoQuiereRecibirEmails Then
                    Return ("El cliente seleccionado NO quiere recibir Emails")

                End If

                If Not FuncionesGenerales.Funciones.validar_Mail(Email) Then
                    Return ("La dirección de e-mail no es correcta")

                End If
            End If



            'If MensajeAEnviar = "" Then
            '    Dim f As New tbImputBox("Indique el mensaje del email")
            '    f.txtResultado.Text = "Listado de inmuebles que se ajustan a sus necesidades"
            '    f.ShowDialog()
            '    MensajeAEnviar = Gl_ResultadoBusqueda

            '    If MensajeAEnviar = "" Or MensajeAEnviar = Gl_ResultadoBusqueda_SALIR Then
            '        Return ("Email no enviado")

            '    End If
            'End If


            If AsuntoYMensaje Is Nothing Then
                AsuntoYMensaje = ConsultasBaseDatos.ObtenerAsuntoYCuerpoEmail(Tipo, CodigoEmpresa)
                If AsuntoYMensaje Is Nothing Then
                    Return ("No se encontró información de asunto y mensaje para el envío de emails listado")

                End If
            End If

            Dim NombreFichero As String = ""

            Select Case Tipo
                Case GL_EMAIL_LISTADO_CLIENTES
                    NombreFichero = PrepararFicheroListado(ContadorCliente, AsuntoYMensaje.Titulo)
            End Select

            Dim MailAdressesDestino As New System.Net.Mail.MailAddressCollection
            MailAdressesDestino.Add(New System.Net.Mail.MailAddress(Email, Nombre))
            Dim ResultadoEnvio As String = Funciones.EnviarCorreo(Email, AsuntoYMensaje.Asunto, AsuntoYMensaje.Mensaje, False, NombreFichero, , , , MailAdressesDestino)



            Return ResultadoEnvio



        End Function
        Private Function PrepararFicheroListado(ContadorCliente As Integer, Titulo As String) As String

            Dim NombreFichero As String = ""

            Dim Directorio As String = My.Application.Info.DirectoryPath & "\EnvioListados\" & DatosEmpresa.Codigo.ToString & "\" & ContadorCliente.ToString
            NombreFichero = Directorio & "\Inmuebles.pdf"
            FuncionesGenerales.Funciones.ComprobarYCrearCarpetas(Directorio)

            Try
                System.IO.File.Delete(NombreFichero)
            Catch ex As Exception

            End Try

            Dim DT As New DataTable

            Dim Sel As String = "EXEC sp_ObtenerTextoDeReferenciasQueCuadran  " & ContadorCliente
            Dim bd As New BaseDatos
            bd.LlenarDataSet(Sel, "Datos")
            DT = bd.ds.Tables("Datos")
            'System.IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\Listados\Esquemas\")
            '   DT.WriteXmlSchema(My.Application.Info.DirectoryPath & "\Listados\Esquemas\Datos.xsd")
            ' DT.WriteXml(My.Application.Info.DirectoryPath & "\Listados\Esquemas\Datos.xml", XmlWriteMode.WriteSchema)
            Dim report As New rptListadoCliente
            report.lblTitulo.Text = Titulo
            report.DataSource = DT
            report.DataMember = "Datos"

            'report.ShowPreviewDialog()
            'Exit Sub

            Dim inicio As DateTime = DateTime.Now

            report.ExportToPdf(NombreFichero)

            Dim fin As DateTime = DateTime.Now

            Dim totalMin As String
            Dim total As TimeSpan = New TimeSpan(fin.Ticks - inicio.Ticks)
            totalMin = total.Hours.ToString("00") & ":" & total.Minutes.ToString("00") & ":" & total.Seconds.ToString("00")

            '2931 inmuebles
            '2 seg sin fotos y sin links
            '3 seg sin fotos y con links
            '2:15 min con fotos y con links
            '3 seg min con fotos y con links con la foto en local

            Return NombreFichero
        End Function

        Private Sub cmbEmpleados_QueryPopUp(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles cmbEmpleados.QueryPopUp
            cmbEmpleados.Properties.View.Columns("Contador").Visible = False
        End Sub

        Private Sub btnComunicacionesDetalle_Click(sender As System.Object, e As System.EventArgs) Handles btnComunicacionesDetalle.Click

            If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
                Return
            End If


            If PanelComunicacionesDetalle IsNot Nothing AndAlso PanelComunicacionesDetalle.Visibility = DockVisibility.Visible Then
                PanelComunicacionesDetalle.Visibility = DockVisibility.Hidden
            Else
                Dim s As New Size
                s = PanelComunicacionesDetalle.Size

                PanelComunicacionesDetalle.Visibility = DockVisibility.Visible
                PanelComunicacionesDetalle.FloatSize = s
                uComunicacionesDetalle.LlenarGrid(BinSrc.Current("Contador"))
            End If
        End Sub

        Private Sub btnAnadirObservaciones_Click(sender As System.Object, e As System.EventArgs) Handles btnAnadirObservaciones.Click

            If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
                Return
            End If

            ProcesoAnadirObservaciones(False, TablaClientes, BinSrc.Current("Contador"))

            LlenarObservaciones()

        End Sub

        Public Function ProcesoAnadirObservaciones(LLamada As Boolean, Tabla As String, ContadorClientePropietarioInmueble As Integer) As Integer

            Dim TipoDeObservacion As String
            GL_Observaciones = ""
            GL_RespondioALaLlamada = True


            If LLamada Then
                frmObservacionesLlamada.ShowDialog()
                TipoDeObservacion = GL_OBSERVACIONES_LLAMADA
            Else
                frmObservaciones.ShowDialog()
                TipoDeObservacion = GL_OBSERVACIONES_MANUAL
            End If


            If GL_Observaciones <> Gl_ResultadoBusqueda_SALIR Then

                Dim Observaciones As New Tablas.clObservaciones

                Observaciones.CodigoEmpresa = DatosEmpresa.Codigo
                Observaciones.ContadorClientePropietarioInmueble = ContadorClientePropietarioInmueble
                Observaciones.ContadorEmpleado = GL_CodigoUsuario
                Observaciones.Delegacion = Gl_Delegacion
                Observaciones.Observaciones = GL_Observaciones
                Observaciones.Tipo = TipoDeObservacion

                ConsultasBaseDatos.InsertarObservaciones(Observaciones, Tabla)

            End If

            'Esta función devuelve un número que indica, que en caso de que sea observaciones por llamada, si contesta o no
            'Este valor solo lo utilizaré fuera si he llamado a esta función por que quiero añadir una observación de llamada.

            If LLamada Then
                If GL_RespondioALaLlamada Then
                    Return 1
                Else
                    Return 0
                End If
            Else
                Return -1
            End If

        End Function

        Private Sub txtBusquedaEmailTelefono_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtBusquedaEmailTelefono.EditValueChanged

        End Sub

        Private Sub btnFichaAlquiler_Click(sender As System.Object, e As System.EventArgs) Handles btnFichaAlquiler.Click
            If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle OrElse Gv.RowCount > 1 Then
                Return
            End If
            Dim a As DataRow = dgvx.ColumnaCheck.GetSelectedRow(0)
            frmFichaAlquiler.ContadorCliente = a.Item("Contador")
            frmFichaAlquiler.ShowDialog()
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