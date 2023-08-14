

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

Public Class ucinmuebles2

    Inherits DevExpress.XtraEditors.XtraUserControl

    Dim GridPrincipal As GridView


    Dim FiltroAntesBusquedaPropietario As String = ""
    Dim PosicionAntesBusquedaPropietario As Integer = 0

    Dim AP As ActualizaPerfil

    Dim Eliminando As Boolean = False
    Dim menu As DXPopupMenu
    Public PopupMenu As DXPopupMenu
    Dim EstoyEnAlta As Boolean

    Dim bd As BaseDatos
    Private WithEvents BinSrc As BindingSource
    Dim TablaMantenimiento As String = "Inmuebles"
    Dim CargandoInmuebles As Boolean = True
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


    Private Sub ucInmuebles_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load


        AparienciaGeneral()

        btnPropietarios.Text = "Datos" & vbCrLf & "Propietarios"


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

        'Bindings
        txtReferencia.DataBindings.Add(New Binding("EditValue", BinSrc, "Referencia", True))
       

        txtExtras.DataBindings.Add(New Binding("EditValue", BinSrc, "Extras", True))



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



    

        ucBalcon.chk.DataBindings.Add(New Binding("CheckState", BinSrc, "Balcon", True))
        ucBalcon.spnValorCajaTexto1.DataBindings.Add(New Binding("EditValue", BinSrc, "MBalcon", True))
        ucBalcon.spnValorCajaTexto2.DataBindings.Add(New Binding("EditValue", BinSrc, "MBalcon2", True))

        ucPatio.chk.DataBindings.Add(New Binding("CheckState", BinSrc, "Patio", True))
        ucPatio.spnValorCajaTexto1.DataBindings.Add(New Binding("EditValue", BinSrc, "MPatio", True))
        ucPatio.spnValorCajaTexto2.DataBindings.Add(New Binding("EditValue", BinSrc, "MPatio2", True))

        ucTerraza.chk.DataBindings.Add(New Binding("CheckState", BinSrc, "Terraza", True))
        ucTerraza.spnValorCajaTexto1.DataBindings.Add(New Binding("EditValue", BinSrc, "MTerraza", True))
        ucTerraza.spnValorCajaTexto2.DataBindings.Add(New Binding("EditValue", BinSrc, "MTerraza2", True))

        ucJardin.chk.DataBindings.Add(New Binding("CheckState", BinSrc, "Jardin", True))
        ucJardin.spnValorCajaTexto1.DataBindings.Add(New Binding("EditValue", BinSrc, "MJardin", True))


        ucTrasteroVenta.RGruop.DataBindings.Add("SelectedIndex", BinSrc, "TrasteroVenta", True)
        ucTrasteroVenta.spnValorCajaTexto1.DataBindings.Add(New Binding("EditValue", BinSrc, "PrecioTrasteroVenta", True))
        ucTrasteroVenta.spnValorCajaTexto2.DataBindings.Add(New Binding("EditValue", BinSrc, "MTrastero", True))

        ucGarajeVenta.RGruop.DataBindings.Add("SelectedIndex", BinSrc, "GarajeVenta", True)
        ucGarajeVenta.spnValorCajaTexto1.DataBindings.Add(New Binding("EditValue", BinSrc, "PrecioGarajeVenta", True))
        ucGarajeVenta.spnValorCajaTexto2.DataBindings.Add(New Binding("EditValue", BinSrc, "MGaraje", True))
        ucGarajeVenta.chkValorCheck.DataBindings.Add(New Binding("CheckState", BinSrc, "GarajeCerrado", True))

        ucTrasteroAlquiler.RGruop.DataBindings.Add("SelectedIndex", BinSrc, "TrasteroAlquiler", True)
        ucTrasteroAlquiler.spnValorCajaTexto1.DataBindings.Add(New Binding("EditValue", BinSrc, "PrecioTrasteroAlquiler", True))
        ucTrasteroAlquiler.spnValorCajaTexto2.DataBindings.Add(New Binding("EditValue", BinSrc, "MTrastero", True))

        ucGarajeAlquiler.RGruop.DataBindings.Add("SelectedIndex", BinSrc, "GarajeAlquiler", True)
        ucGarajeAlquiler.spnValorCajaTexto1.DataBindings.Add(New Binding("EditValue", BinSrc, "PrecioGarajeAlquiler", True))
        ucGarajeAlquiler.spnValorCajaTexto2.DataBindings.Add(New Binding("EditValue", BinSrc, "MGaraje", True))
        ucGarajeAlquiler.chkValorCheck.DataBindings.Add(New Binding("CheckState", BinSrc, "GarajeCerrado", True))


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
        FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbPoblacion, "Poblacion", "Poblacion", "Poblacion", , , , "SELECT Poblacion FROM Poblacion")
        FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbZona, "Zona", "Zona", "Zona", , , , "SELECT Zona FROM Zona")
        FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbOrientacion, "Orientacion", "Orientacion", "Orientacion", , , , "SELECT Orientacion FROM Orientacion")
        FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbEstado, "Estado", "Estado", "Estado", , , , "SELECT Estado FROM Estado")
        FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbTipo, "Tipo", "Tipo", "Tipo", , , , "SELECT Tipo FROM Tipo")
        '  FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbPropietarios, "Propietarios", "ContadorPropietario", "Nombre", "Contador")

        ParametrizarGrid(Gv, False)

        dgvx.tbCarpetaPerfiles = GL_CARPETA_PERFILES & "\" & Me.Name & "\" & dgvx.Name
        MenuGrid = New tbContextMenuStripComponent(dgvx.tbCarpetaPerfiles, cmbPerfiles2)
        dgvx.ContextMenuStrip = MenuGrid
        'dgvx.ContextMenuStrip = New tbContextMenuStripComponent(dgvx.tbCarpetaPerfiles)
        '  dgvx.ContextMenuStrip.Items.Add("Copiar Perfiles", Nothing, AddressOf CopiarPerfilesDgvX)
        dgvx.ContextMenuStrip.Items.Add("Gestión Documental", Nothing, AddressOf dgvxGestDoc)

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

        If AnadirCheckColunm Then
            Try
                dgvx.tb_AnadirColumnaCheck = True
                '    ColumnaCheck.View = Nothing


            Catch ex As Exception

            End Try

            '   ColumnaCheck = New GridCheckMarksSelection(Gv)


        End If

        'uInmueblesPropietario = New ucInmueblesPropietario
        'CrearPanelFlotanteNueva(DockManager1, PanelArticulosVendidos, uInmueblesPropietario, 800, 300)

        CargandoInmuebles = False
        ' HabilitarBotones()

        HabilitarDesHabilitarBotones(True)
        'HabilitarDeshabilitarBotones(True) 'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        HabilitarDesHabilitarCajas(False) 'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

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

        CargandoInmuebles = True

        Dim FiltroSelect As String

        If FiltroBusqueda = "" Then
            FiltroSelect = ""
        Else
            FiltroSelect = " WHERE (Telefono1propietario LIKE '%" & FiltroBusqueda & "' OR  Telefono2propietario LIKE '%" & FiltroBusqueda & "' OR  TelefonoMovilpropietario LIKE '%" & FiltroBusqueda & "' OR  Emailpropietario LIKE '%" & FiltroBusqueda & "%')"

        End If
        Dim TextoBaja As String = ""

        If GL_TablaInmuebles = GL_TablaInmueblesBaja Then
            TextoBaja = "Baja"
        End If

        Dim FiltroTotal As String = ""
        Dim FiltroCliente As String = ""

        If DeDondeVengo = GL_VENGO_DE_CLIENTES Then
            FiltroCliente = "  Contador IN (SELECT Contador FROM [dbo].[ObtenerReferenciasQueCuadran] (" & ContadorClienteDeDondeVengo & "))"
        End If
        If DeDondeVengo = "Alarmas" Then
            FiltroCliente = "  Contador = " & ContadorClienteDeDondeVengo
        End If

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


        If FiltroBusqueda = "" Then
            SentenciaSQL = "SELECT *,(SELECT Nombre FROM Propietarios P WHERE Contador = I.ContadorPropietario) AS Propietario," & _
                          "(SELECT Telefono1 FROM Propietarios P WHERE Contador = I.ContadorPropietario) AS Telefono1Propietario," & _
                          "(SELECT Telefono2 FROM Propietarios P WHERE Contador = I.ContadorPropietario) AS Telefono2Propietario," & _
                          "(SELECT TelefonoMovil FROM Propietarios P WHERE Contador = I.ContadorPropietario) AS TelefonoMovilPropietario," & _
                          "(SELECT Email FROM Propietarios P WHERE Contador = I.ContadorPropietario) AS EmailPropietario," & _
                          "(SELECT Observaciones FROM Propietarios P WHERE Contador = I.ContadorPropietario) AS ObservacionesPropietario," & _
                          "(SELECT COUNT(*) FROM Inmuebles I2 WHERE I2.ContadorPropietario = I.ContadorPropietario) AS Inmuebles" & _
                        " FROM " & TablaInmuebles & " I WHERE CodigoEmpresa = " & DatosEmpresa.Codigo & FiltroTotal & " ORDER BY Referencia DESC"
        Else
            SentenciaSQL = "SELECT * FROM v_TodosLosInmuebles " & FiltroTotal & " ORDER BY Referencia DESC"

        End If

        'Dim Tab As New Tablas.clTablaGeneral(TablaMantenimiento, , SentenciaSQL)
        'bd = New BaseDatos
        'Tab.Datos(bd, Tab.ConsultaAEjecutar, , , , , True)

        bd = New BaseDatos
        bd.LlenarDataSet(SentenciaSQL, TablaMantenimiento, , False, True)



        If PrimeraVez Then
            BinSrc = New BindingSource
        End If

        BinSrc.DataSource = bd.ds
        BinSrc.DataMember = TablaMantenimiento


        dgvx.BindingContext = New BindingContext()

        dgvx.DataSource = Nothing
        dgvx.DataSource = BinSrc
        'dgvx.ForceInitialize()



        'dgvx.BeginUpdate()
        'dgvx.DataSource = BinSrc
        'dgvx.RefreshDataSource()



        ''if (view != null)
        ''{
        ''    view.FocusedRowHandle = index;
        ''    view.TopRowIndex = topVisibleIndex;
        ''}

        'dgvx.EndUpdate()
        'dgvx.ForceInitialize()
        'Gv = New MyGridView
        'Gv.GridControl = dgvx

        'dgvx.Views(0).BeginUpdate()
        'dgvx.DataSource = BinSrc
        'dgvx.Views(0).EndUpdate()

        '    Gv = New MyGridView
        Gv = Nothing
        'Gv = dgvx.MainView

        Gv = dgvx.MainView

        'Gv.PopulateColumns(bd.ds.Tables(0))
        ''MyGridControl1.DataSource = BinSrc
        ''MyGridView1 = MyGridControl1.MainView

        'dgvx.ForceInitialize()

        If PrimeraVez Then
            AP = New ActualizaPerfil(Gv)
        End If

        CargandoInmuebles = False

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



        Dim condition1 As StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        condition1.Appearance.BackColor = Color.FromArgb(255, 205, 178, 131)
        condition1.Appearance.Options.UseBackColor = True
        condition1.Condition = FormatConditionEnum.Expression
        condition1.Expression = "[Reservado] = 1"
        Gv.FormatConditions.Add(condition1)

        condition1 = New DevExpress.XtraGrid.StyleFormatCondition()
        condition1.Appearance.BackColor = Color.Red
        condition1.Appearance.Options.UseBackColor = True
        condition1.Condition = FormatConditionEnum.Expression
        condition1.Expression = "[Baja] = true"
        Gv.FormatConditions.Add(condition1)

        condition1 = New DevExpress.XtraGrid.StyleFormatCondition()
        condition1.Appearance.BackColor = Color.FromArgb(255, 205, 138, 81)
        condition1.Appearance.Options.UseBackColor = True
        condition1.Condition = FormatConditionEnum.Expression
        condition1.Expression = "[Baja] = true and [Reservado] = 1"
        Gv.FormatConditions.Add(condition1)

        PrimeraVez = False
        If dgvx.tbEstablecerPerfilPredeterminado() Then
            cmbPerfiles2.EditValue = dgvx.tbPerfilPredeterminado
            cmbPerfiles2.Text = dgvx.tbPerfilPredeterminado & "(Predeterminado)"
            Exit Sub
        End If


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

        '  Gv.Columns("Contador").Visible = False
        '  Gv.Columns("Contador").OptionsColumn.AllowShowHide = False
        Gv.Columns("CodigoEmpresa").Visible = False
        Gv.Columns("Delegacion").Visible = False
        Gv.Columns("ContadorPropietario").Visible = False
        'XXXXGv.Columns("Baja").Visible = False
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
        ItemArticulo.FieldName = "Contador"
        ItemArticulo.DisplayFormat = "{0:n0}"
        ItemArticulo.SummaryType = DevExpress.Data.SummaryItemType.Count
        Gv.Columns("Referencia").SummaryItem.DisplayFormat = "Inmuebles: {0:n0}"
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

        'If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
        '    Return
        'End If

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



        HabilitarDesHabilitarBotones(False)
        HabilitarDesHabilitarCajas(False)


        If FilaSeleccionada > 1 Then
            Gv.FocusedRowHandle = FilaSeleccionada - 1

        Else
            Try
                Gv.FocusedRowHandle = FilaSeleccionada + 1
            Catch ex As Exception
                HabilitarDesHabilitarBotones(False)
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
        HabilitarDesHabilitarBotones(True)
        HabilitarDesHabilitarCajas(False)

    End Sub
    Private Sub PrepararModificacion()

        HabilitarDesHabilitarCajas(True)

        HabilitarDesHabilitarBotones(False)
        txtReferencia.Enabled = False
        

    End Sub

    Private Sub PrepararAlta()

        HabilitarDesHabilitarBotones(False)
        HabilitarDesHabilitarCajas(True)

        '   FechaAltaDateEdit.EditValue = Microsoft.VisualBasic.Today 'Microsoft.VisualBasic.Format(Microsoft.VisualBasic.Today, "dd/MM/yyyy")
        'chkBaja.EditValue = False

        txtReferencia.Text = ""
        txtReferencia.Enabled = False
        '     chkBaja.Enabled = False


        PonerChecksEnIndeterminado()


    End Sub

    Private Sub PonerChecksEnIndeterminado()

        mskFechaAlta.EditValue = ""
        mskUltimaVisita.EditValue = ""

        'combos?

        txtObservaciones.Text = ""
        txtExtras.Text = ""

        SliderPequeno.Images.Clear()
        SliderGrande.Images.Clear()

        ucBalcon.chk.Checked = CheckState.Unchecked
        ucPatio.chk.Checked = CheckState.Unchecked
        ucTerraza.chk.Checked = CheckState.Unchecked
        ucJardin.chk.Checked = CheckState.Unchecked
        ucBalcon.spnValorCajaTexto1.EditValue = 0
        ucPatio.spnValorCajaTexto1.EditValue = 0
        ucTerraza.spnValorCajaTexto1.EditValue = 0
        ucJardin.spnValorCajaTexto1.EditValue = 0
        ucBalcon.spnValorCajaTexto2.EditValue = 0
        ucPatio.spnValorCajaTexto2.EditValue = 0
        ucTerraza.spnValorCajaTexto2.EditValue = 0
        ucCocina.Valor = vbNull
        ucCalentador.Valor = vbNull

        chkCocinaOffice.CheckState = CheckState.Unchecked
        chkDuplex.CheckState = CheckState.Unchecked
        chkPiscina.CheckState = CheckState.Unchecked
        chkAscensor.CheckState = CheckState.Unchecked
        chkElectrodomesticos.CheckState = CheckState.Unchecked
        chkGaleria.CheckState = CheckState.Unchecked

        chkVenta.CheckState = CheckState.Unchecked
        chkAlquiler.CheckState = CheckState.Unchecked
        chkOpcionCompra.CheckState = CheckState.Unchecked
        chkVerano.CheckState = CheckState.Unchecked
        chkTraspaso.CheckState = CheckState.Unchecked
        chkLlaves.CheckState = CheckState.Unchecked
        chkOportunidad.CheckState = CheckState.Unchecked
        chkCartel.CheckState = CheckState.Unchecked
        chkEscaparate.CheckState = CheckState.Unchecked
        chkNoAlquiler.CheckState = CheckState.Unchecked
        chkOcultar.CheckState = CheckState.Unchecked

        'spnPrecioTraspaso.EditValue = 0
        'spnPrecioVerano.EditValue = 0

        spnAltura.EditValue = 0
        spnMetros.EditValue = 0
        spnHabitaciones.EditValue = 0
        spnBanos.EditValue = 0
        spnBaneras.EditValue = 0
        spnAnoConstruccion.EditValue = 0
        spnDuchas.EditValue = 0
        spnMetrosPlaya.EditValue = 0

        spnPrecioAlquiler.EditValue = 0
        ucTrasteroAlquiler.spnValorCajaTexto1.EditValue = 0
        ucTrasteroAlquiler.spnValorCajaTexto2.EditValue = 0
        ucTrasteroAlquiler.RGruop.EditValue = vbNull
        ucGarajeAlquiler.spnValorCajaTexto1.EditValue = 0
        ucGarajeAlquiler.spnValorCajaTexto2.EditValue = 0
        ucGarajeAlquiler.RGruop.EditValue = vbNull
        ucGarajeAlquiler.chkValorCheck.CheckState = CheckState.Unchecked
        spnFianza.EditValue = 0
        spnPrecioComunidad.EditValue = 0
        chkComunidadIncluida.CheckState = CheckState.Unchecked

        spnPrecioVenta.EditValue = 0
        ucTrasteroVenta.spnValorCajaTexto1.EditValue = 0
        ucTrasteroVenta.spnValorCajaTexto2.EditValue = 0
        ucTrasteroVenta.RGruop.EditValue = vbNull
        ucGarajeVenta.spnValorCajaTexto1.EditValue = 0
        ucGarajeVenta.spnValorCajaTexto2.EditValue = 0
        ucGarajeVenta.RGruop.EditValue = vbNull
        ucGarajeVenta.chkValorCheck.CheckState = CheckState.Unchecked

    End Sub

    Private Sub HabilitarDesHabilitarAlquilerVenta(Si As Boolean, Optional Cual As String = "TODOS")
        If Cual = "TODOS" Or Cual = "ALQUILER" Then
            For Each c As Control In pnlAlquiler.Controls
                If Si Then
                    c.Enabled = chkAlquiler.Checked
                Else
                    c.Enabled = False
                End If
            Next
        End If
        If Cual = "TODOS" Or Cual = "VENTA" Then
            For Each c As Control In pnlVenta.Controls
                If Si Then
                    c.Enabled = chkVenta.Checked
                Else
                    c.Enabled = False
                End If
            Next
        End If
    End Sub



    Private Sub HabilitarDesHabilitarCajas(Habilitar As Boolean)

        For Each c As Control In pnlDatosGenerales.Controls
            If c.Name <> "Extras1" And c.Name <> "pnlAlquiler" And c.Name <> "pnlVenta" Then
                c.Enabled = Habilitar
            End If
        Next

        HabilitarDesHabilitarAlquilerVenta(Habilitar)

        HabilitarDeshabilitarExtras1(Habilitar)

        HabilitarDesHabilitarBotonesEspecialesCuandoVengoDeClientes(Not Habilitar)

        SliderPequeno.Enabled = True
        SliderGrande.Enabled = True



    End Sub
    Private Sub HabilitarDeshabilitarExtras1(Si As Boolean)
        For Each c As Control In Extras1.Controls
            c.Enabled = Si
        Next
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
                txtReferencia.EditValue = clGenerales.SiguienteRegistro("CONVERT(INT,Referencia) ", "Inmuebles", " WHERE Delegacion = 1")
                BinSrc.Current("Delegacion") = 1
                BinSrc.Current("CodigoEmpresa") = DatosEmpresa.Codigo
                BinSrc.Current("ContadorEmpleado") = GL_CodigoUsuario

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
            HabilitarDesHabilitarBotones(True)
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
    Private Function ActualizarBaseDatos(Optional RefrescarDatos As Boolean = False) As Boolean

        Try

            Dim ContadorMinimo As Integer = 0

            If EstoyEnAlta Then
                ContadorMinimo = clGenerales.Maximo("Contador", TablaMantenimiento)
            End If


            bd.ActualizarCambios(TablaMantenimiento, bd.ds, RefrescarDatos)

            If EstoyEnAlta Then

                CargandoInmuebles = True


                'Se supone que el cliente ya está dado de alta en la bd.
                'Como el contador es autonumérico, no lo tenemos en el dataset.
                'Con lo siguiente, vamos a acutaliazar el dataset con el contador que le han asignado al cliente
                Dim NuevoContador As Integer

                NuevoContador = ConsultasBaseDatos.ObtenerContadorInmuebleEnAlta(BinSrc.Current("Referencia"), ContadorMinimo, GL_CodigoUsuario)

                Dim dt As DataTable
                Dim dr As DataRow
                dt = bd.ds.Tables(TablaMantenimiento)
                dr = dt.Rows(bd.ds.Tables(TablaMantenimiento).Rows.Count - 1)

                If BinSrc.Current("Referencia") = dr("Referencia") And dr("Contador") Is DBNull.Value Then
                    dr.BeginEdit()
                    dr("Contador") = NuevoContador
                    dr.EndEdit()
                    bd.ds.AcceptChanges()
                End If



                CargandoInmuebles = False
            End If



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
        If txtReferencia.Text.ToString.Trim = "" And Not EstoyEnAlta Then
            MensajeError("El campo código no puede estar vacío")

            txtReferencia.Focus()
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

    Private Sub HabilitarDesHabilitarAnadirModificarBorrar(Habilitar)
        btnAnadir.Enabled = Habilitar
        btnModificar.Enabled = Not Habilitar
        btnEliminar.Enabled = Not Habilitar
        If bd.ds.Tables(TablaMantenimiento).Rows.Count > 0 Then
            btnModificar.Enabled = Habilitar
            btnEliminar.Enabled = Habilitar
        End If
    End Sub

    Private Sub HabilitarDesHabilitarBotones(Habilitar As Boolean)


        HabilitarDesHabilitarAnadirModificarBorrar(Habilitar)

        btnAceptar.Enabled = Not Habilitar
        btnCancelar.Enabled = Not Habilitar
        btnSalir.Enabled = Habilitar

        btnVerBajas.Enabled = Habilitar
        btnDarDeBaja.Enabled = Habilitar
        '   btnVisitas.Enabled = Habilitar
        btnClientes.Enabled = Habilitar
        btnEmails.Enabled = Habilitar
        btnAnadirObservaciones.Enabled = Habilitar
        btnReservar.Enabled = Habilitar
        btnFotos.Enabled = Habilitar
        btnImprimir.Enabled = Habilitar

        dgvx.Enabled = Habilitar

        'For Each Page As DevExpress.XtraTab.XtraTabPage In XtraTabControl1.TabPages
        '    Page.PageEnabled = True
        'Next

        HabilitarDesHabilitarBotonesEspecialesCuandoVengoDeClientes(Habilitar)

        'If TablaClientes = GL_TablaClientesBaja Then
        '    btnVisitas.Enabled = False
        'End If

    End Sub
    Private Sub HabilitarDesHabilitarBotonesEspecialesCuandoVengoDeClientes(Habilitar As Boolean)
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
            Try
                If a.Item("Reservado") = True Then
                    b = Color.FromArgb(255, 205, 178, 131)
                    .BackColor = Color.Moccasin
                    Try
                        If a.Item("Baja") = True Then
                            .BackColor = Color.FromArgb(255, 255, 178, 131)
                        End If
                    Catch
                    End Try
                    Exit Sub
                End If
            Catch
            End Try
            Try
                If a.Item("Baja") = True Then
                    .BackColor = Color.FromArgb(255, 255, 100, 100)
                    Exit Sub
                End If
            Catch
            End Try
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

        'If slid.Name = SliderPequeno.Name Then
        '    Carpeta = Carpeta & "\actualizaweb"
        'End If

        If Not System.IO.Directory.Exists(Carpeta) Then Exit Sub

        Dim Fotos() As String = System.IO.Directory.GetFiles(Carpeta)

        For i = 0 To Fotos.Count - 1
            Dim fs As System.IO.FileStream = New System.IO.FileStream(Fotos(i), System.IO.FileMode.Open)
            slid.Images.Add(Image.FromStream(fs))
            fs.Close()
            'slid.Images.Add(Image.FromFile(Fotos(i)))
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
        slid.LayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.ZoomInside
    End Sub

    Private Sub HacerCambioFila()

        If CargandoInmuebles Then
            Exit Sub
        End If
        'habilitabotones(False)
        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Exit Sub
        End If
        '   habilitabotones(True)
        LlenarObservaciones()

        'If BinSrc.Current("ElectroDomesticosAlquiler") Is DBNull.Value Then
        '    chkElectrodomesticos.ForeColor = Color.Blue
        'End If

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
        'Nextf

        'Dim uClientesContactos As New Venalia.ucMantenimientos(GL_ClientesContactos, Gv.GetFocusedRowCellValue("Referencia").ToString, False, False)
        ''pnlContactos.Controls.Add(u)

        'uClientesContactos.Dock = DockStyle.Fill
        'pnlContactos.Controls.Add(uClientesContactos)


        'For i = 0 To plnDireccionesEnvio.Controls.Count - 1
        '    plnDireccionesEnvio.Controls.Remove(plnDireccionesEnvio.Controls(0))
        'Next

        'Dim uDireccionesEnvio As New Venalia.ucMantenimientos(GL_DireccionesEnvio, Gv.GetFocusedRowCellValue("Referencia").ToString, False, False)
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

        Dim condition1 As StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        condition1.Appearance.BackColor = Color.FromArgb(255, 205, 178, 131)
        condition1.Appearance.Options.UseBackColor = True
        condition1.Condition = FormatConditionEnum.Expression
        condition1.Expression = "[Reservado] = 1"
        Gv.FormatConditions.Add(condition1)

        condition1 = New DevExpress.XtraGrid.StyleFormatCondition()
        condition1.Appearance.BackColor = Color.Red
        condition1.Appearance.Options.UseBackColor = True
        condition1.Condition = FormatConditionEnum.Expression
        condition1.Expression = "[Baja] = true"
        Gv.FormatConditions.Add(condition1)

        condition1 = New DevExpress.XtraGrid.StyleFormatCondition()
        condition1.Appearance.BackColor = Color.FromArgb(255, 205, 138, 81)
        condition1.Appearance.Options.UseBackColor = True
        condition1.Condition = FormatConditionEnum.Expression
        condition1.Expression = "[Baja] = true and [Reservado] = 1"
        Gv.FormatConditions.Add(condition1)

        ''If Gv.Columns("baja") IsNot Nothing Then
        ''    Gv.Columns("baja").Visible = False
        ''    Gv.Columns("baja").OptionsColumn.AllowShowHide = False
        ''End If

    End Sub
    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs)
        If FiltroBusqueda <> "" Then
            Gl_ResultadoBusqueda = ""
            FiltroBusqueda = ""
            LlenarGrid()
            btnReservar.Text = TextoInicialBotonBuscar
            btnReservar.ForeColor = ColorInicialBotonBuscar
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
            btnReservar.Text = "FILTRADO"
            btnReservar.ForeColor = Color.Red
        Else
            Gl_ResultadoBusqueda = ""
            FiltroBusqueda = ""
            LlenarGrid()
            btnReservar.Text = TextoInicialBotonBuscar
            btnReservar.ForeColor = ColorInicialBotonBuscar
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
        CargandoInmuebles = True

        Gv.ActiveFilterString = ""
        CargandoInmuebles = False

        TabInmuebles.SelectedTabPageIndex = 0
        BinSrc.Filter = "Referencia = " & UcInmueblesPropietario1.Gv.GetFocusedRowCellValue("Referencia")
        'txtCodigo.EditValue = UcInmueblesPropietario1.Gv.GetFocusedRowCellValue("Referencia")


    End Sub

    Private Sub TabInmuebles_SelectedPageChanged(sender As System.Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles TabInmuebles.SelectedPageChanged
        If TabInmuebles.SelectedTabPageIndex = 1 And BinSrc.Filter <> "" Then
            BinSrc.Filter = ""
            CargandoInmuebles = True
            Gv.ActiveFilterString = FiltroAntesBusquedaPropietario
            CargandoInmuebles = False
            FiltroAntesBusquedaPropietario = ""
            BinSrc.Position = PosicionAntesBusquedaPropietario
            Gv.Focus()

        End If

    End Sub

    Private Sub SliderPequeno_DoubleClick(sender As Object, e As System.EventArgs) Handles SliderPequeno.DoubleClick
        If BinSrc.Current("Inmuebles") IsNot DBNull.Value And BinSrc.Current("Inmuebles") IsNot DBNull.Value Then
            SliderGrande.Images.Clear()
            '  pnlDatosGenerales.Visible = False
            'SliderGrande.Height = pnlDatosGenerales.Height
            'SliderGrande.Width = pnlDatosGenerales.Height
            'SliderGrande.Top = pnlDatosGenerales.Top
            'SliderGrande.Left = ((pnlDatosGenerales.Left + pnlDatosGenerales.Right) / 2) - (SliderGrande.Width / 2)
            SliderGrande.Height = Me.Height
            SliderGrande.Width = Me.Height
            SliderGrande.Top = Me.Top
            SliderGrande.Left = ((Me.Left + Me.Right) / 2) - (SliderGrande.Width / 2)

            CargarSlider(SliderGrande, BinSrc.Current("ContadorPropietario"), BinSrc.Current("Referencia"))

            If SliderGrande.Images.Count < 1 Then Exit Sub

            SliderGrande.Visible = True
            SliderGrande.BringToFront()
        End If
    End Sub

    Private Sub SliderGrande_DoubleClick(sender As Object, e As System.EventArgs) Handles SliderGrande.DoubleClick
        SliderGrande.Visible = False
    End Sub

    Private Sub chks_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkVenta.CheckedChanged, chkAlquiler.CheckedChanged
        If chkVenta.Enabled Then
            HabilitarDesHabilitarAlquilerVenta(chkVenta.Checked, "VENTA")
        End If
        If chkAlquiler.Enabled Then
            HabilitarDesHabilitarAlquilerVenta(chkAlquiler.Checked, "ALQUILER")
        End If
        'PARA NUEVOS CONTROLES AÑADIR AQUI Y EN EL HANDLES
    End Sub



    Private Sub btnClientes_Click(sender As System.Object, e As System.EventArgs) Handles btnClientes.Click
        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Return
        End If

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        CargarFormulario("Clientes", True, GL_VENGO_DE_INMUEBLES, BinSrc.Current("Contador").ToString & "|" & BinSrc.Current("Referencia").ToString)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow

        Exit Sub
        '  For Each frm As DevExpress.XtraEditors.XtraForm In Me.MdiChildren



        'Try
        '    Application.OpenForms.Item("Clientes").Dispose()

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

    Private Sub btnVerBajas_Click(sender As System.Object, e As System.EventArgs) Handles btnVerBajas.Click

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor


        If TablaInmuebles = GL_TablaInmuebles Then
            TablaInmuebles = GL_TablaInmueblesBaja
            btnDarDeBaja.ForeColor = Color.Red
            btnDarDeBaja.Text = "Dar de Alta"
            btnVerBajas.ForeColor = Color.Red
            btnVerBajas.Text = "Ver Altas"
            btnVerBajas.Image = My.Resources.InmueblesAlta
            btnDarDeBaja.Image = My.Resources.DarDeAlta
            HabilitarDesHabilitarAnadirModificarBorrar(False)
        Else
            TablaInmuebles = GL_TablaInmuebles
            btnDarDeBaja.ForeColor = ColorInicialBotonBajas
            btnDarDeBaja.Text = "Dar de Baja"
            btnVerBajas.ForeColor = ColorInicialBotonBajas
            btnVerBajas.Text = "Ver Bajas"
            btnVerBajas.Image = My.Resources.InmueblesBaja
            btnDarDeBaja.Image = My.Resources.DarDeBaja
            HabilitarDesHabilitarAnadirModificarBorrar(True)
        End If



        LlenarGrid()


        Me.Cursor = System.Windows.Forms.Cursors.Arrow

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
            If TablaInmuebles = GL_TablaInmuebles Then
                Texto = "¿Confirma que quiere dar de baja el registro seleccionado?"
            Else
                Texto = "¿Confirma que quiere dar de alta el registro seleccionado?"
            End If

            If XtraMessageBox.Show(Texto, "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
                Return False
            End If

            If TablaInmuebles = GL_TablaInmuebles Then
                bd.Execute("sp_PasarInmuebleABaja " & BinSrc.Current("Contador"))
            Else
                bd.Execute("sp_PasarInmuebleAAlta " & BinSrc.Current("Contador"))
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
    Private Sub cmbPerfiles2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbPerfiles2.SelectedIndexChanged
        Dim selectedIndex As Integer = cmbPerfiles2.SelectedIndex
        If selectedIndex <> -1 Then
            MenuGrid.AplicarPerfil(cmbPerfiles2.EditValue, dgvx)
        End If
        AP.ActualizaPerfil(Gv, MenuGrid.mnuPerfilActual.Text.Substring(15))
        If AnadirCheckColunm Then 'añadimos le checkcolumn tras actualizar el perfil
            Try
                dgvx.tb_AnadirColumnaCheck = True
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub btnAnadirObservaciones_Click(sender As System.Object, e As System.EventArgs) Handles btnAnadirObservaciones.Click

        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Return
        End If

        ProcesoAnadirObservaciones(False, TablaInmuebles, BinSrc.Current("Contador"))

        LlenarObservaciones()

    End Sub
    Public Function ProcesoAnadirObservaciones(LLamada As Boolean, Tabla As String, ContadorInmueble As Integer) As Integer

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
            Observaciones.ContadorClientePropietarioInmueble = ContadorInmueble
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

    Private Sub LlenarObservaciones()
        txtObservaciones.Text = ""
        Dim dt As DataTable
        dt = ConsultasBaseDatos.ObtenerObservaciones(BinSrc.Current("Contador"), TablaInmuebles)

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

    Private Sub btnFotos_Click(sender As System.Object, e As System.EventArgs) Handles btnFotos.Click
        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Return
        End If
        'Dim f As New ucImagenes(BinSrc.Current("ContadorPropietario"), BinSrc.Current("Referencia"))
        'f.Show()
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        CargarFormulario("Imagenes", Otros:=BinSrc.Current("ContadorPropietario") & "|" & BinSrc.Current("Referencia"))
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click

        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Return
        End If
        Dim listaInmuebles As String = ""
        Dim row As DataRowView
        For I = 0 To dgvx.ColumnaCheck.SelectedCount - 1
            If dgvx.ColumnaCheck.SelectedCount >= 1 Then
                row = dgvx.ColumnaCheck.GetSelectedRow(I)
                If I = 0 Then
                    listaInmuebles = " where Referencia=" & row.Item("Referencia")
                Else
                    listaInmuebles &= " or Referencia=" & row.Item("Referencia")
                End If

            End If
        Next

        Dim DT As New DataTable

        Dim Sel As String = "SELECT I.Referencia, [dbo].[ObtenerTextoInforme] (Contador) as Texto, I.Poblacion, I.Chollo FROM Inmuebles I" & listaInmuebles & _
                            " ORDER BY Poblacion, PrecioVenta, PrecioAlquiler"
        Dim bd As New BaseDatos
        bd.LlenarDataSet(Sel, "Datos")
        DT = bd.ds.Tables("Datos")
        'System.IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\Listados\Esquemas\")
        '   DT.WriteXmlSchema(My.Application.Info.DirectoryPath & "\Listados\Esquemas\Datos.xsd")
        ' DT.WriteXml(My.Application.Info.DirectoryPath & "\Listados\Esquemas\Datos.xml", XmlWriteMode.WriteSchema)
        Dim r As New rptListadoInmuebles
        r.lblTitulo.Text = ConsultasBaseDatos.ObtenerAsuntoYCuerpoEmail(GL_EMAIL_LISTADO_CLIENTES, DatosEmpresa.Codigo).Titulo
        r.DataSource = DT
        r.DataMember = "Datos"
        r.ShowPreview()


        'Dim inicio As DateTime = DateTime.Now

        'report.ExportToPdf(NombreFichero)

        'Dim fin As DateTime = DateTime.Now

        'Dim totalMin As String
        'Dim total As TimeSpan = New TimeSpan(fin.Ticks - inicio.Ticks)
        'totalMin = total.Hours.ToString("00") & ":" & total.Minutes.ToString("00") & ":" & total.Seconds.ToString("00")


    End Sub

    Private Sub btnEmails_Click(sender As System.Object, e As System.EventArgs) Handles btnEmails.Click
        EnviosDeEmailMasivo()
    End Sub
    Private Sub EnviosDeEmailMasivo()

        If dgvx.ColumnaCheck.SelectedCount = 0 And (Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle) Then
            MensajeError("No ha seleccionado ningún inmueble al que enviar email")
            Exit Sub
        End If

        Dim SeleccionManual As Boolean = False

        If dgvx.ColumnaCheck.SelectedCount = 0 Then
            dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, True)
            SeleccionManual = True
        End If

        'Aqui mostramos un form en el q definimos el mensaje,titulo y asunto, elegimos el predeterminado o guardamos alguno nuevo o cargamos
        'asi como si se incluyen los datos de empresa los de los inmuebles o incluso si se agrega algun documento adjunto

        frmMensajeEmail.ShowDialog()
        Dim a() As String = Split(GL_DatosMensajePersonalizado, "|")
        If a(7) = True Then Return
        Dim AnadirAvisoLegal As Boolean = a(6)
        Dim AnadirDatosEmpresa As Boolean = a(5)
        Dim AnadirDatosInmueble As Boolean = a(4)
        Dim FicheroAdjunto As String = a(3)
        Dim AsuntoMensaje As String = a(1)
        Dim TituloMensaje As String = a(0)
        Dim MensajeMensaje As String = a(2)

        Try 'situamos cartel de envio
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            pnlEnviado.Left = (pnlDatosGenerales.Width - pnlEnviado.Width) / 2
            pnlEnviado.Top = (pnlDatosGenerales.Height - pnlEnviado.Height) / 2
            pnlEnviado.Visible = True
            pnlEnviado.Enabled = True
            PanelBotones.Enabled = False
            lblxdey.Text = "1 de " & dgvx.ColumnaCheck.SelectedCount
            '   Application.DoEvents()
        Catch ex As Exception
        End Try

        Dim ContadorInmuebleIncial As Integer = 0
        Dim ContadorInmueble As Integer
        Dim Nombre As String = ""
        Dim Email As String = ""
        Dim Cadena As String = ""
        Dim CuantosConMail As Integer = 0
        Dim CuantosSinMail As Integer = 0
        Dim PropietariosSinMail As New Generic.List(Of String)
        Dim LlamadaContestada As Integer = 0


        'recorremos todos los inmuebles sobre los que enviaremos email a los propietarios y los introducimos dentro de una tabla con los datos de sus propietarios

        Dim inmuebles As String = ""
        For i As Integer = 0 To dgvx.ColumnaCheck.SelectedCount - 1
            If i = 0 Then
                ContadorInmuebleIncial = (TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("Contador")
            End If
            inmuebles &= Str((TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("Contador")) & ","
        Next
        inmuebles = inmuebles.Substring(0, inmuebles.Count - 1)

        SentenciaSQL = "SELECT i.Contador,i.Referencia,p.Nombre,p.Email FROM Inmuebles i INNER JOIN Propietarios p ON i.ContadorPropietario = p.Contador WHERE i.Contador IN(" & inmuebles & ")"
        Dim bdemail As New BaseDatos
        bdemail.LlenarDataSet(SentenciaSQL, "Email")

        Dim DTEmail As New DataTable
        DTEmail = bdemail.ds.Tables("Email")
        'recorremos la tabla propietario a propietario y enviamos los email correspondientes borrando lo que vamos mandando(no repetir propietario)

        For i As Integer = 0 To DTEmail.Rows.Count - 1
            With DTEmail.Rows(i)
                lblxdey.Text = (CuantosConMail + CuantosSinMail + 1) & " de " & DTEmail.Rows.Count
                Application.DoEvents() '???

                Email = .Item("Email")
                Nombre = .Item("Nombre")
                ContadorInmueble = .Item("Contador")

                If (Email = "" Or Not FuncionesGenerales.Funciones.validar_Mail(Email)) Then
                    CuantosSinMail += 1
                    PropietariosSinMail.Add(Nombre)
                Else
                    If .Item("Nombre") <> "" Then
                        Try
                            Dim ResultadoEnvio As String = ""
                            'obtenemos la informacion a enviar
                            Dim AsuntoYMensaje As New Tablas.cl_AsuntoYMensaje
                            AsuntoYMensaje.Asunto = AsuntoMensaje
                            AsuntoYMensaje.Titulo = TituloMensaje
                            AsuntoYMensaje.Mensaje = MensajeMensaje & vbCrLf & vbCrLf
                            For ii As Integer = i To DTEmail.Rows.Count - 1
                                If DTEmail.Rows(ii).Item("Nombre") = Nombre Then
                                    CuantosConMail += 1 'cada propietario duplicado se cuenta como un nuevo mail enviado
                                    If AnadirDatosInmueble Then
                                        AsuntoYMensaje.Mensaje &= ConsultasBaseDatos.ObtenerMensajePropietario(DatosEmpresa.Codigo, .Item("Contador"), .Item("Referencia")) & vbCrLf & vbCrLf
                                    End If
                                    DTEmail.Rows(ii).Item("Nombre") = ""
                                End If
                            Next
                            If AsuntoYMensaje Is Nothing Then
                                MensajeInformacion("No se encontró información de asunto y mensaje para el envío de emails")
                                Exit Sub
                            End If
                            If AnadirDatosEmpresa Then
                                AsuntoYMensaje.Mensaje &= ConsultasBaseDatos.ObtenerMensajePropietario(2, 0, "", AnadirDatosEmpresa, AnadirAvisoLegal)
                            End If
                            'enviamos el email al propietario
                            ResultadoEnvio = EnviosEmailIndividual(Email, Nombre, AsuntoYMensaje, FicheroAdjunto)


                            'Se llena la tabla con los datos dle envio a los propietarios correspondientes
                            If ResultadoEnvio = "" Then

                                'Dim Tab As New Tablas.clComunicaciones
                                'Tab.CodigoEmpresa = DatosEmpresa.Codigo
                                'Tab.Delegacion = Gl_Delegacion
                                'Tab.ContadorCliente = ContadorCliente
                                'Tab.ContadorInmueble = ContadorInmueble
                                'Tab.ContadorEmpleado = GL_CodigoUsuario
                                'Tab.Fecha = mskFecha.EditValue
                                'Tab.PrecioEnvioVenta = 0
                                'Tab.PrecioEnvioAlquiler = 0
                                'Tab.PrecioEnvioVerano = 0
                                'Tab.PrecioEnvioTraspaso = 0
                                'Tab.CambioDePrecio = False
                                'Tab.LlamadaContestada = LlamadaContestada

                                'Dim QueBuscaCliente As New Tablas.clTipoVentaCliente
                                'QueBuscaCliente.Venta = (TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("Venta")
                                'QueBuscaCliente.Alquiler = (TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("Alquiler")
                                'QueBuscaCliente.Verano = (TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("Verano")
                                'QueBuscaCliente.Traspaso = (TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("Traspaso")
                                'ConsultasBaseDatos.InsertarComunicaciones(Tab, QueBuscaCliente, GL_EMAIL_DETALLE)

                            End If

                        Catch ex As Exception
                            MensajeError(ex.Message)
                        End Try
                    End If
                End If
                .Item("Nombre") = ""
            End With
        Next

        If SeleccionManual Then
            dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, False)
            SeleccionManual = False
        Else
            dgvx.ColumnaCheck.ClearSelection()
        End If


        HacerCambioFila() '???


        '************Esto para refrescar datos va ok. lo comento pq ahora lo que necesito es forzar cambio de fila'?????
        Try
            dgvx.ColumnaCheck.View = Nothing
        Catch ex As Exception

        End Try

        Dim TopIndexAntes As Integer
        TopIndexAntes = Gv.TopRowIndex
        bd.RefrescarDatos(TablaMantenimiento, bd.ds)
        Gv.TopRowIndex = TopIndexAntes
        SituarseEnGrid(Gv, ContadorInmuebleIncial, "Contador")

        Try
            If dgvx.tb_AnadirColumnaCheck Then
                dgvx.AnadirColumnaCheck()
            End If

        Catch ex As Exception

        End Try
        '************Esto para refrescar datos va ok

        Try 'Escondemos panel envio

            pnlEnviado.Visible = False
            PanelBotones.Enabled = True
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Catch ex As Exception

        End Try

        If CuantosSinMail > 0 Then 'Mostramos mensaje ocn los errores
            Dim CadenaMensaje As String = ""

            CadenaMensaje = "Hay " & CuantosSinMail & " propietarios de los inmuebles seleccionados que no se ha podido enviar el email porque no tiene dirección de email o el email no es correcto."

            For Each s In PropietariosSinMail
                CadenaMensaje = CadenaMensaje & vbCrLf & s.ToString
            Next
            MensajeError(CadenaMensaje)
        End If



    End Sub
    Private Function EnviosEmailIndividual(Email As String, Nombre As String, AsuntoYMensaje As Tablas.cl_AsuntoYMensaje, Optional NombreFichero As String = "") As String

        Dim MailAdressesDestino As New System.Net.Mail.MailAddressCollection
        MailAdressesDestino.Add(New System.Net.Mail.MailAddress(Email, Nombre))
        Dim ResultadoEnvio As String = Funciones.EnviarCorreo(Email, AsuntoYMensaje.Asunto, AsuntoYMensaje.Mensaje, False, NombreFichero, , , , MailAdressesDestino)

        Return ResultadoEnvio
    End Function


    Private Sub btnReservar_Click(sender As System.Object, e As System.EventArgs) Handles btnReservar.Click
        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle OrElse Gv.RowCount > 1 Then
            Return
        End If
        Dim a As DataRow = dgvx.ColumnaCheck.GetSelectedRow(0)
        frmFichaReserva.ContadorCliente = a.Item("Contador")
        frmFichaReserva.ShowDialog()
    End Sub

     


    Private Sub btnBuscarPropietarios_Click(sender As System.Object, e As System.EventArgs)

    End Sub
End Class





