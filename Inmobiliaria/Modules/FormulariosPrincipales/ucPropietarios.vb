

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





Partial Public Class ucPropietarios

    Inherits DevExpress.XtraEditors.XtraForm


    Dim Eliminando As Boolean = False
    Public PopupMenu As DXPopupMenu
    Dim EstoyEnAlta As Boolean

    Public bd As BaseDatos
    Public bdInm As New BaseDatos
    Public WithEvents BinSrc As BindingSource
    Dim TablaMantenimiento As String = "Propietarios"
    Dim Cargando As Boolean
    Dim PrimeraVez As Boolean
    Dim SentenciaSQL As String

    Dim ValorComercialAntes As Boolean
    Dim UsuarioAntes As String
    Dim PassAntes As String
    Dim TipoAntes As String
    Dim BajaAntes As String

    Dim uGestionDocumental As ucGestionDocumental
    Dim PanelGestionDocumental As DockPanel
    Dim TablaGestionDocumental As String
    Dim CampoGestionDocumental As String

    Dim CampoInicialBusqueda As String = "Nombre"


    Dim PanelComercialesClientes As DockPanel

    Dim FiltroBusqueda As String = ""
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
    Dim PrimeraVezInmuebles As Boolean

    Dim soloConInmuebles As Boolean
    Dim SinInmuebles As Boolean
    Dim noReservados As Boolean

    Dim BuscandoPorTelefonoEmail2 As Boolean = False
    Dim ColorInicialBotonBuscar As System.Drawing.Color

    Public Sub New()
        InitializeComponent()
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

    Private p_ContadorPropietarioDeDondeVengo As Integer

    Public Property ContadorPropietarioDeDondeVengo As Integer
        Get
            Return p_ContadorPropietarioDeDondeVengo
        End Get
        Set(value As Integer)
            p_ContadorPropietarioDeDondeVengo = value
        End Set
    End Property

    Private Sub ucPropietarios_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        If GL_PropietariosPendienteActualizacion Then
            RefrescarDatosDesdeBdPropietarios(False)
            GL_PropietariosPendienteActualizacion = False
            LlenarGridInmuebles()
            LlenarGridLlamadas()
        End If
    End Sub

    Private Sub ucPropietarios_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        uPropietariosActivo = Nothing
    End Sub

    Private Sub ucPropietarios_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        GL_PropietariosPendienteActualizacion = False
        AparienciaGeneral()
        PrimeraVezInmuebles = True
        Cargando = True
        PrimeraVez = True

        TablaGestionDocumental = "Propietarios"
        CampoGestionDocumental = "Contador"
        ColorInicialBotonBuscar = txtBusquedaEmailTelefono.ForeColor

        GL_ColorOriginal = PanelControl3.BackColor


        '   SentenciaSQL = "SELECT CodigoEmpresa, Contador, 	FechaAlta,	  	Nombre,	NIF ,	Alias ,	Direccion,	Poblacion,	CodPostal ,	Provincia ,	Pais ,	Telefono1 , " & _
        '        " Telefono2 ,	TelefonoMovil ,	Fax ,	Email ,	Observaciones, " & _
        '        " BancoNombre ,	BancoCuenta ,	Agrupacion,	Comercial " & _
        '" , (SELECT Usuario FROM " & clVariables.BaseDatos1 & ".dbo.Usuarios U WHERE U.Contador = E.Contador) as Usuario  " & _
        '" , (SELECT C ONVERT(VARCHAR(300),DECRYPTBYPASSPHRASE ('TRESBITS',Pass )) as Pass FROM " & clVariables.BaseDatos1 & ".dbo.Usuarios U WHERE U.Contador = E.Contador) as Pass  " & _
        '" , (SELECT Tipo FROM " & clVariables.BaseDatos1 & ".dbo.Usuarios U WHERE U.Contador = E.Contador) as Tipo  " & _
        '" , (SELECT Baja FROM " & clVariables.BaseDatos1 & ".dbo.Usuarios U WHERE U.Contador = E.Contador) as Baja  " & _
        '" FROM Empleados E"

        LlenarGrid()


        'Bindings
        txtObservaciones.DataBindings.Add(New Binding("EditValue", BinSrc, "Observaciones", True))

        txtNIF.DataBindings.Add(New Binding("EditValue", BinSrc, "NIF", True))
        txtNombre.DataBindings.Add(New Binding("EditValue", BinSrc, "Nombre", True))
        txtAlias.DataBindings.Add(New Binding("EditValue", BinSrc, "Alias", True))

        txtCodPostal.DataBindings.Add(New Binding("EditValue", BinSrc, "CodPostal", True))
        txtDireccion.DataBindings.Add(New Binding("EditValue", BinSrc, "Domicilio", True))
        txtPais.DataBindings.Add(New Binding("EditValue", BinSrc, "Pais", True))
        txtPoblacion.DataBindings.Add(New Binding("EditValue", BinSrc, "Poblacion", True))
        txtProvincia.DataBindings.Add(New Binding("EditValue", BinSrc, "Provincia", True))


        txtTelefono1.DataBindings.Add(New Binding("EditValue", BinSrc, "Telefono1", True))
        txtTelefono2.DataBindings.Add(New Binding("EditValue", BinSrc, "Telefono2", True))
        txtTelefono3.DataBindings.Add(New Binding("EditValue", BinSrc, "Telefono3", True))
        txtTelefono4.DataBindings.Add(New Binding("EditValue", BinSrc, "Telefono4", True))
        txtTelefonoMovil.DataBindings.Add(New Binding("EditValue", BinSrc, "TelefonoMovil", True))
        txtEmail.DataBindings.Add(New Binding("EditValue", BinSrc, "Email", True))
        txtEmail2.DataBindings.Add(New Binding("EditValue", BinSrc, "Email2", True))
        txtCuenta.DataBindings.Add(New Binding("EditValue", BinSrc, "Cuenta", True))
        txtFax.DataBindings.Add(New Binding("EditValue", BinSrc, "Fax", True))
        txtWeb.DataBindings.Add(New Binding("EditValue", BinSrc, "Web", True))

        chkBanco.DataBindings.Add(New Binding("CheckState", BinSrc, "Banco", True))
        chkNoInmobiliaria.DataBindings.Add(New Binding("CheckState", BinSrc, "NoInmobiliaria", True))
        chkAvisadoTresPorCien.DataBindings.Add(New Binding("CheckState", BinSrc, "AvisadoTresPorCien", True))
        chkAvisadoMensualidad.DataBindings.Add(New Binding("CheckState", BinSrc, "AvisadoMensualidad", True))
        chkNoAnimales.DataBindings.Add(New Binding("CheckState", BinSrc, "NoAnimales", True))
        chkNoExtranjeros.DataBindings.Add(New Binding("CheckState", BinSrc, "NoExtranjeros", True))
        chkSeguroVivienda.DataBindings.Add(New Binding("CheckState", BinSrc, "SeguroVivienda", True))

        chkNoQuiereRecibirEmails.DataBindings.Add(New Binding("CheckState", BinSrc, "NoQuiereRecibirEmails", True))

        mskFechaAlta.DataBindings.Add(New Binding("EditValue", BinSrc, "FechaAlta", True))

        'Datos de la tabla sin binding todavia a falta de saber el tratamiento
        'Contador
        'CodigoEmpresa
        'Delegacion
        'ContadorEmpleado
        'FechaEmail
        'FechaLlamada

        'txtCodigo.DataBindings.Add(New Binding("EditValue", BinSrc, "Codigo", True))

        dgvx.DataSource = BinSrc

        ParametrizarGrid(Gv)

        dgvx.tbCarpetaPerfiles = GL_CARPETA_PERFILES & "\" & Me.Name & "\" & dgvx.Name
        dgvx.ContextMenuStrip = New tbContextMenuStripComponent(dgvx.tbCarpetaPerfiles)
        'dgvx.ContextMenuStrip.Items.Add("Copiar Perfiles", Nothing, AddressOf CopiarPerfilesDgvX)
        dgvx.ContextMenuStrip.Items.Add("Gestión Documental", Nothing, AddressOf dgvxGestDoc)
        ConfigurarGrid()

        uGestionDocumental = New ucGestionDocumental
        CrearPanelFlotanteNueva(DockManager1, PanelGestionDocumental, uGestionDocumental, 600, 300)

        Cargando = False

        Try
            If Not PrimeraVez Then
                HacerCambioFila()
            End If

        Catch ex As Exception

        End Try

        HabilitarBotones()
        HabilitarDesHabilitarCajas(False)

        PonerFocoRowFilterEnGridView(Gv, CampoInicialBusqueda)
        Try
            Gv.Focus()
            Gv.FocusedRowHandle = 0
        Catch ex As Exception

        End Try

        If AnadirCheckColunm AndAlso Not dgvx.tb_AnadirColumnaCheck Then
            Try
                dgvx.tb_AnadirColumnaCheck = True

            Catch ex As Exception
            End Try
            '   ColumnaCheck = New GridCheckMarksSelection(Gv)
        End If

    End Sub

    Private Sub LlenarGrid(Optional situarse As Boolean = False)

        Dim ContadorAnterior As Integer = -1
        If situarse Then
            Try
                ContadorAnterior = CInt(Gv.GetFocusedRowCellValue("Contador"))
            Catch ex As Exception

            End Try

        End If


  

        Dim PropietarioInmueble As String = ""

        If DeDondeVengo = GL_VENGO_DE_INMUEBLES Then
            PropietarioInmueble = " AND Contador=" & ContadorPropietarioDeDondeVengo
        End If

        Dim FiltroSelect As String

        'If FiltroBusqueda = "" Then
        '    FiltroSelect = ""
        'Else
        '    FiltroSelect = " AND (Telefono1 LIKE '%" & FiltroBusqueda & "%' OR  Telefono2 LIKE '%" & FiltroBusqueda & "%' OR Telefono3 LIKE '%" & FiltroBusqueda & "%' OR  Telefono4 LIKE '%" & FiltroBusqueda & "%' OR  TelefonoMovil LIKE '%" & FiltroBusqueda & "%' OR  Email LIKE '%" & FiltroBusqueda & "%' OR  Email2 LIKE '%" & FiltroBusqueda & "%'  OR Nombre LIKE '%" & FiltroBusqueda & "%'  OR Fax LIKE '%" & FiltroBusqueda & "%')"

        'End If

        If BuscandoPorTelefonoEmail2 AndAlso txtBusquedaEmailTelefono.Text.Trim <> "" Then
            FiltroSelect = " AND (Telefono1 LIKE '%" & txtBusquedaEmailTelefono.Text.Trim & "%' OR  Telefono2 LIKE '%" & txtBusquedaEmailTelefono.Text.Trim & "%' OR Telefono3 LIKE '%" & txtBusquedaEmailTelefono.Text.Trim & "%' OR  Telefono4 LIKE '%" & txtBusquedaEmailTelefono.Text.Trim & "%' OR  TelefonoMovil LIKE '%" & txtBusquedaEmailTelefono.Text.Trim & "%' OR  Email LIKE '%" & txtBusquedaEmailTelefono.Text.Trim & "%' OR  Email2 LIKE '%" & txtBusquedaEmailTelefono.Text.Trim & "%'  OR Nombre LIKE '%" & txtBusquedaEmailTelefono.Text.Trim & "%'  OR Fax LIKE '%" & txtBusquedaEmailTelefono.Text.Trim & "%')"
        End If

        Dim soloInmo As String = ""

        If soloConInmuebles Then
            soloInmo = " AND (SELECT COUNT(*) FROM Inmuebles WHERE ContadorPropietario=P.contador AND Baja=0)>0 "
        End If

        If SinInmuebles Then
            soloInmo = " AND (SELECT COUNT(*) FROM Inmuebles WHERE ContadorPropietario=P.contador AND Baja=0)=0 "
        End If


        If noReservados Then
            soloInmo &= " AND (SELECT COUNT(*) FROM Inmuebles WHERE ContadorPropietario=P.contador AND Reservado=0 AND Baja=0)>0 "
        End If

        SentenciaSQL = "SELECT * FROM Propietarios P WHERE CodigoEmpresa=" & DatosEmpresa.Codigo & PropietarioInmueble & FiltroSelect & soloInmo & " ORDER BY Nombre"

        bd = New BaseDatos
        bd.LlenarDataSet(SentenciaSQL, TablaMantenimiento, , False, True)

        With bd.ds.Tables(TablaMantenimiento).Columns("Contador")
            .AutoIncrement = True
            '    .AutoIncrementSeed =1
            .AutoIncrementStep = 1
        End With

        Dim key(0) As DataColumn
        key(0) = bd.ds.Tables(TablaMantenimiento).Columns("Contador")
        bd.ds.Tables(TablaMantenimiento).PrimaryKey = key

        If PrimeraVez Then
            BinSrc = New BindingSource
        End If

        dgvx.BindingContext = New BindingContext()
        BinSrc.DataSource = bd.ds
        BinSrc.DataMember = TablaMantenimiento

        If Gv.RowCount > 0 AndAlso BinSrc.Current("NoInmobiliaria") Then
            PanelControl3.BackColor = GL_ColorAruraRosaBaja
            PanelBotones.BackColor = GL_ColorAruraRosaBaja
            PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            PanelBotones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Else
            PanelControl3.BackColor = GL_ColorOriginal
            PanelBotones.BackColor = GL_ColorOriginal
            PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
            PanelBotones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        End If

        If situarse AndAlso ContadorAnterior > 0 Then
            SituarseEnGrid(Gv, CStr(ContadorAnterior), "Contador")
            'Else
            '    Try
            '        If Not PrimeraVez Then
            '            HacerCambioFila()
            '        End If

            '    Catch ex As Exception

            '    End Try
        End If

    End Sub


    Private Sub ConfigurarGrid()

        If Not PrimeraVez Then
            Exit Sub
        End If

        PrimeraVez = False
        If dgvx.tbEstablecerPerfilPredeterminado() Then
            Exit Sub
        End If


        Gv.OptionsView.ShowGroupPanel = False

        Gv.OptionsView.ShowAutoFilterRow = True
        Gv.OptionsView.ColumnAutoWidth = False

        'Gv.BestFitColumns()


        '     Gv.Columns("Contador").OptionsColumn.AllowShowHide = False
        Gv.Columns("Contador").Visible = False
        Gv.Columns("Nombre").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

        Gv.Columns("ContadorEmpleado").OptionsColumn.AllowShowHide = False
        Gv.Columns("ContadorEmpleado").Visible = False

        'Gv.Columns("MarcaDeTiempo").OptionsColumn.AllowShowHide = False
        'Gv.Columns("MarcaDeTiempo").Visible = False

        Gv.Columns("Delegacion").OptionsColumn.AllowShowHide = False
        Gv.Columns("Delegacion").Visible = False

        Gv.Columns("FechaAlta").Visible = False
        Gv.Columns("Provincia").Visible = False
        Gv.Columns("Poblacion").Visible = False
        Gv.Columns("Web").Visible = False
        Gv.Columns("Domicilio").Visible = False
        Gv.Columns("Pais").Visible = False
        Gv.Columns("CodPostal").Visible = False


        Gv.Columns("NIF").Visible = False
        Gv.Columns("NoInmobiliaria").Visible = False
        Gv.Columns("AvisadoMensualidad").Visible = False
        Gv.Columns("NoQuiereRecibirEmails").Visible = False
        '   Gv.Columns("FechaNoContesta").Visible = False
        Gv.Columns("Cuenta").Visible = False
        Gv.Columns("Alias").Visible = False
        Gv.Columns("Fax").Visible = False

        'Gv.Columns("FechaEmail").Visible = False
        Gv.Columns("FechaNoContesta").Visible = False
        Gv.Columns("NOAnimales").Visible = False
        Gv.Columns("NoExtranjeros").Visible = False

        Gv.Columns("Observaciones").Visible = False

        Gv.Columns("AvisadoTresPorCien").Visible = False
        Gv.Columns("SeguroVivienda").Visible = False
        Gv.Columns("Email2").Visible = False

        Gv.Columns("CodigoEmpresa").OptionsColumn.AllowShowHide = False
        Gv.Columns("CodigoEmpresa").Visible = False

        Gv.Columns("TelefonoMovil").Caption = "Móvil"
        Gv.Columns("AvisadoTresPorCien").Caption = "3 %"
        Gv.Columns("FechaLlamada").Caption = "Llamada"
        Gv.Columns("FechaNoContesta").Caption = "No contesta"

        Gv.Columns("FechaLlamada").Width = 100
        Gv.Columns("FechaLlamada").Caption = "F Llamada"
        Gv.Columns("FechaNoContesta").Width = 100
        Gv.Columns("FechaNoContesta").Caption = "F No Contesta"
        Gv.Columns("FechaEmail").Width = 100
        Gv.Columns("FechaEmail").Caption = "F Email"

        Gv.Columns("Telefono1").Width = 80
        Gv.Columns("Telefono2").Width = 80
        Gv.Columns("Telefono3").Width = 80
        Gv.Columns("Telefono4").Width = 80
        Gv.Columns("TelefonoMovil").Width = 80
        Gv.Columns("AvisadoTresPorCien").Width = 50
        Gv.Columns("Email").Width = 150

        Gv.Columns("Nombre").Width = 200
        Gv.OptionsView.ColumnAutoWidth = True
        '   Gv.BestFitColumns()
        'Sumatorios en agrupaciones
        Gv.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        Dim ItemArticulo As GridGroupSummaryItem = New GridGroupSummaryItem()
        ItemArticulo.FieldName = "Contador"
        ItemArticulo.DisplayFormat = "{0:n0}"
        ItemArticulo.SummaryType = DevExpress.Data.SummaryItemType.Count
        Gv.GroupSummary.Add(ItemArticulo)


        Gv.OptionsView.ShowFooter = True
        Gv.Columns("Nombre").SummaryItem.FieldName = "Contador"
        Gv.Columns("Nombre").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        Gv.Columns("Nombre").SummaryItem.DisplayFormat = "Total: {0:n0}"
    End Sub




#Region "Mantenimiento Empleados"

    Private Sub btnAnadir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnadir.Click
        Anadir()
    End Sub
    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Eliminar()
    End Sub
    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Modificar()
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Aceptar()
        HacerCambioFila()
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub

    Private Sub Anadir()
        EstoyEnAlta = True
        BinSrc.AddNew()
        PrepararAlta()
        'CargaDatosPropietario()
    End Sub

    Private Sub Modificar(Optional ByVal PonermeEnLaPrimeraColumna As Boolean = True)

        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            MensajeError("Debe seleccionar un registro")
            Return
        End If

        ' If ConsultasBaseDatos.MarcaDeTiempoHaCambiado(TablaMantenimiento, BinSrc.Current("MarcaDeTiempo")) Then
        bd.RefrescarDatos(BinSrc.Position)
        ' End If

        EstoyEnAlta = False
        PrepararModificacion()

    End Sub
    Private Sub CargaDatosPropietario() 'Actualiza los datos de inmueblespropietarios
        If uInmueblesActivo IsNot Nothing Then
            If uInmueblesActivo.UcInmueblesPropietario1.txtCodPropietario.Text = CStr(BinSrc.Current("Contador")) Then
                uInmueblesActivo.UcInmueblesPropietario1.txtNombre.Text = BinSrc.Current("Nombre")
                uInmueblesActivo.UcInmueblesPropietario1.txtTelefono1.Text = BinSrc.Current("Telefono1")
                uInmueblesActivo.UcInmueblesPropietario1.txtTelefono2.Text = BinSrc.Current("Telefono2")
                uInmueblesActivo.UcInmueblesPropietario1.txtTelefono3.Text = BinSrc.Current("Telefono3")
                uInmueblesActivo.UcInmueblesPropietario1.txtTelefono4.Text = BinSrc.Current("Telefono4")
                uInmueblesActivo.UcInmueblesPropietario1.txtTelefonoMovil.Text = BinSrc.Current("TelefonoMovil")
                uInmueblesActivo.UcInmueblesPropietario1.txtEmail.Text = BinSrc.Current("Email")
                uInmueblesActivo.UcInmueblesPropietario1.chkAviso3.Checked = BinSrc.Current("AvisadoTresPorCien")
                uInmueblesActivo.UcInmueblesPropietario1.chkMensual.Checked = BinSrc.Current("AvisadoMensualidad")
                uInmueblesActivo.UcInmueblesPropietario1.chkNoInmo.Checked = BinSrc.Current("NoInmobiliaria")
                uInmueblesActivo.UcInmueblesPropietario1.chkNoQuiereRecibirEmails.Checked = BinSrc.Current("NoQuiereRecibirEmails")
                uInmueblesActivo.UcInmueblesPropietario1.chkNoAnimales.Checked = BinSrc.Current("NoAnimales")

                uInmueblesActivo.UcInmueblesPropietario1.chkNoExtranjeros.Checked = BinSrc.Current("NoExtranjeros")
                uInmueblesActivo.UcInmueblesPropietario1.chkSeguroVivienda.Checked = BinSrc.Current("SeguroVivienda")

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

        If XtraMessageBox.Show("¿Confirma que quiere eliminar el registro seleccionado?" & vbCrLf & "Recuerde que al eliminar un propietario también eliminará todos los inmuebles asociados a él", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
            Exit Sub
        End If

        Dim ContadorPropietario As String = BinSrc.Current("Contador")
        Dim Sel As String

        

        Sel = GL_SQL_DELETE & "  FROM PropietariosComunicaciones  WHERE ContadorPropietario = " & ContadorPropietario
        BD_CERO.Execute(Sel)

        Sel = "SELECT Contador, Baja , Referencia FROM Inmuebles WHERE ContadorPropietario = " & ContadorPropietario
        Dim dtr As Object
        Dim bdEli As New BaseDatos

        dtr = bdEli.ExecuteReader(Sel)
        If dtr.hasrows Then
            While dtr.read
                PrevioEliminarInmueble(dtr("Referencia"), dtr("Baja"), dtr("Contador"))
                FuncionesBD.Accion("DELETE", "Inmuebles", dtr("Referencia"))
            End While
        End If
        dtr.Close()
        bdEli.CerrarBD()
        Sel = GL_SQL_DELETE & "  FROM Inmuebles WHERE ContadorPropietario = " & ContadorPropietario
        BD_CERO.Execute(Sel)

        'If ConsultasBaseDatos.MarcaDeTiempoHaCambiado(TablaMantenimiento, BinSrc.Current("MarcaDeTiempo")) Then
        '    bd.RefrescarDatos(BinSrc.Position)
        'End If

        Eliminando = True

        Try
            'ConsultasBaseDatos.EliminarUsuario(BinSrc.Current("Contador"), DatosEmpresa.Codigo)
        Catch ex As Exception
            MensajeError(ex.Message)
            Return
        End Try

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
        Actualizar()
        CargaDatosPropietario()
    End Sub
    Private Sub Cancelar()
        BinSrc.CancelEdit()
        HabilitarBotones()
        HabilitarDesHabilitarCajas(False)
    End Sub
    Private Sub PrepararModificacion()
        'ValorComercialAntes = Gv.GetFocusedRowCellValue("Comercial")
        'UsuarioAntes = Gv.GetFocusedRowCellValue("Usuario")
        'TipoAntes = Gv.GetFocusedRowCellValue("Tipo")
        'PassAntes = Gv.GetFocusedRowCellValue("Pass")
        'BajaAntes = Gv.GetFocusedRowCellValue("Baja")

        For Each c As Control In PanelCajas.Controls
            If Not TypeOf (c) Is DevExpress.XtraEditors.LabelControl AndAlso Not TypeOf (c) Is DevExpress.XtraEditors.PanelControl AndAlso Not TypeOf (c) Is DevExpress.XtraEditors.GroupControl Then
                c.Enabled = True
            End If
            'If c.Name <> "GroupControl1" And c.Name <> "lblPersonas" And c.Name <> "lblMPlaya" Then
            '    'If c.Name <> "lblPersonas" And c.Name <> "lblMPlaya" And c.Name <> "ucCocina" And c.Name <> "ucCalentador" Then
            '    c.Enabled = Habilitar
            'End If
        Next

        'For Each c As Control In PanelCajas.Controls
        '    c.Enabled = True
        'Next

        txtObservaciones.Enabled = True
        txtObservaciones.Properties.ReadOnly = True
        '  txtCodigo.Enabled = False
        DesHabilitarBotones()
    End Sub

    Private Sub PrepararAlta()

        HabilitarDesHabilitarCajas(True)

        chkAvisadoTresPorCien.EditValue = False
        chkNoInmobiliaria.EditValue = False
        chkBanco.EditValue = False
        chkNoQuiereRecibirEmails.EditValue = False
        '   txtCodigo.Enabled = False
        '     chkBaja.Enabled = False

        txtAlias.EditValue = ""
        '      txtCodigo.Text = ""

        txtNombre.Focus()

        DesHabilitarBotones()

    End Sub
    Private Sub HabilitarDesHabilitarCajas(ByVal Habilitar As Boolean)
        For Each c As Control In PanelCajas.Controls
            If Not TypeOf (c) Is DevExpress.XtraEditors.LabelControl AndAlso Not TypeOf (c) Is DevExpress.XtraEditors.PanelControl AndAlso Not TypeOf (c) Is DevExpress.XtraEditors.GroupControl Then
                c.Enabled = Habilitar
            End If
            
        Next
        txtBusquedaEmailTelefono.Enabled = True

        btnNuevoInmueble.Enabled = Not Habilitar
        btnInmuebles.Enabled = Not Habilitar
        btnEmails.Enabled = Not Habilitar
    End Sub

    Private Function Actualizar() As Boolean
        Try

            Me.Validate()

            If Not Eliminando AndAlso Not ComprobarDatos() Then
                Return False
            End If

            'If Not EstoyEnAlta Then

            '    If BajaAntes <> chkBaja.EditValue AndAlso txtUsuario.EditValue = GL_Usuario Then
            '        MensajeError("No se puede cambiar el estado de baja a si mismo")
            '        Exit Function
            '    End If

            'End If

            If EstoyEnAlta Then
                '   txtCodigo.EditValue = clGenerales.SiguienteRegistro("Codigo", "Empleados")

                If IsDBNull(BinSrc.Current("FechaAlta")) Then
                    BinSrc.Current("FechaAlta") = Microsoft.VisualBasic.Today
                End If
                BinSrc.Current("CodigoEmpresa") = DatosEmpresa.Codigo
                BinSrc.Current("ContadorEmpleado") = GL_CodigoUsuario
                BinSrc.Current("Delegacion") = Gl_Delegacion
                BinSrc.Current("TipoEmail") = ""

                ''Contador
                'FechaEmail
                'FechaLlamada

                'BinSrc.Current("Contador") = ConsultasBaseDatos.InsertarUsuario(txtUsuario.EditValue, txtPassAbierta.EditValue, cmbTipo.EditValue, DatosEmpresa.Codigo)
                'ConsultasBaseDatos.InsertarUsuarioEmpresa(txtUsuario.EditValue, BinSrc.Current("Contador"), DatosEmpresa.Codigo)
            Else
                'If UsuarioAntes <> txtUsuario.EditValue Or PassAntes <> txtPassAbierta.EditValue Or TipoAntes <> cmbTipo.EditValue Or BajaAntes <> chkBaja.EditValue Then
                '    ConsultasBaseDatos.ModificarUsuario(BinSrc.Current("Contador"), txtUsuario.EditValue, txtPassAbierta.EditValue, cmbTipo.EditValue, chkBaja.EditValue)
                'End If

            End If


            'If BinSrc.Item(BinSrc.Count - 1)("Observaciones") Is DBNull.Value Then

            'If BinSrc.Item(BinSrc.Count - 1)("Banco") Is DBNull.Value Then
            '    BinSrc.Item(BinSrc.Count - 1)("Banco") = False
            'End If
            Cargando = True
            BinSrc.EndEdit()
            Cargando = False



            '    BinSrc.Item(BinSrc.Count - 1)("Observaciones") = ""
            'End If




            '  Dim ValorClaveAntes As Object = BinSrc.Current("Contador")

            If Not ActualizarBaseDatos() Then
                Return False
            End If

            If EstoyEnAlta Then
                Dim tab As New Tablas.clComunicaciones

                tab.CodigoEmpresa = DatosEmpresa.Codigo
                tab.Delegacion = Gl_Delegacion
                tab.ContadorInmueble = 0
                tab.ContadorClientePropietarioInmueble = BinSrc.Current("Contador")
                tab.ContadorEmpleado = GL_CodigoUsuario
                tab.LlamadaContestada = 1
                tab.Observaciones = ""
                tab.Tipo = GL_OBSERVACIONES_LLAMADA
                tab.Tabla = GL_TablaPropietarios

                ConsultasBaseDatos.InsertarComunicacionesObservaciones(tab)



                BinSrc.Current("FechaLlamada") = Now
                BinSrc.EndEdit()
                EstoyEnAlta = False
                ActualizarBaseDatos()
                bd.ds.AcceptChanges()

                'If Not ActualizarBaseDatos() Then
                '    Return False
                'End If


                '    UcComunicacionesDetalle1.LlenarGrid(tab.ContadorClientePropietarioInmueble, tab.Tabla)
            End If

            'If ValorClaveAntes IsNot Nothing Then
            '    bd.LlenarDataSet(SentenciaSQL, TablaMantenimiento)
            '    SituarseEnGrid(Gv, ValorClaveAntes.ToString, "Contador")
            'End If


            HabilitarBotones()
            HabilitarDesHabilitarCajas(False)
            Return True

        Catch ex As SqlClient.SqlException

            XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)


            Return False

        Catch ex2 As Exception

            XtraMessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False

        End Try


    End Function
    Private Function ActualizarBaseDatos() As Boolean



        Try

            bd.ActualizarCambios(TablaMantenimiento, bd.ds)

            If EstoyEnAlta Then

                Cargando = True


                'Se supone que el cliente ya está dado de alta en la bd.
                'Como el contador es autonumérico, no lo tenemos en el dataset.
                'Con lo siguiente, vamos a acutaliazar el dataset con el contador que le han asignado al cliente
                Dim NuevoContador As Integer

                NuevoContador = clGenerales.Maximo("Contador", TablaMantenimiento)

                Dim dt As DataTable
                Dim dr As DataRow
                dt = bd.ds.Tables(TablaMantenimiento)
                dr = dt.Rows(bd.ds.Tables(TablaMantenimiento).Rows.Count - 1)

                If BinSrc.Current("Nombre") = dr("Nombre") And dr("Contador") Is DBNull.Value OrElse dr("Contador") = 0 Then
                    Dim bdMarcaTiempo As New BaseDatos
                    'Dim MarcaDeTiempo As Byte() = bdMarcaTiempo.Execute("SELECT MarcaDeTiempo FROM " & TablaMantenimiento & " WHERE Contador = " & NuevoContador, False)



                    dr.BeginEdit()
                    dr("Contador") = NuevoContador
                    'dr("MarcaDeTiempo") = MarcaDeTiempo
                    dr.EndEdit()
                    bd.ds.AcceptChanges()
                End If

                '    bd.RefrescarDatos(True)


                Cargando = False
            End If



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
        'If txtCodigo.Text = "" And Not EstoyEnAlta Then
        '    MensajeError("El campo código no puede estar vacío")
        '    XtraTabControl1.SelectedTabPageIndex = 0
        '    txtCodigo.Focus()
        '    Return False
        'End If

        If txtNombre.Text.ToString.Trim = "" Then
            MensajeError("El campo nombre no puede estar vacío")
            txtNombre.Focus()
            Return False
        End If


        If Not Funciones.validar_Mail(txtEmail.Text) Then
            MensajeError("El campo email no es correcto")
            txtEmail.Focus()
            Return False
        End If


        If Not Funciones.validar_Mail(txtEmail2.Text) Then
            MensajeError("El campo email no es correcto")
            txtEmail2.Focus()
            Return False
        End If

        If txtEmail2.Text.Trim <> "" AndAlso txtEmail.Text.Trim = "" Then
            MensajeError("No puede rellenar Email2 sin haber rellenado Email ")
            txtEmail2.Focus()
            Return False
        End If

        Dim CondicionCodigo As String = ""

        If Not Eliminando Then
            If Not EstoyEnAlta Then
                CondicionCodigo = " AND CodigoEmpleado <> " & BinSrc.Current("Contador")
            End If


            'If clGenerales.Cuenta("UsuarioEmpresas", " WHERE Usuario = '" & FuncionesGenerales.Funciones.pf_ReplaceComillas(txtUsuario.EditValue) & "'" & CondicionCodigo, 1) > 0 Then
            '    MensajeError("Ya existe un empleado con el usuario " & txtUsuario.EditValue)
            '    txtUsuario.Focus()
            '    Return False
            'End If
        End If





        Return True

    End Function

    Private Sub dgvx_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvx.DoubleClick
        CargarInmuebles()
    End Sub


    Private Sub dgvxEmpleados_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvx.KeyDown

        If e.KeyCode = Keys.Escape And btnAceptar.Enabled = True Then

            Try

                Cancelar()
            Catch ex As Exception

            End Try


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





    End Sub

    Private Sub DesHabilitarBotones()

        btnAnadir.Enabled = False
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        btnSalir.Enabled = False
        btnAceptar.Enabled = True
        btnCancelar.Enabled = True

        dgvx.Enabled = False

        txtObservaciones.Properties.ReadOnly = False

        Dim PaginaSeleccionadaAntes As Integer
        If EstoyEnAlta Then
            PaginaSeleccionadaAntes = 0
        End If
        txtBusquedaEmailTelefono.Enabled = False
    End Sub

#End Region

    

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Salir()
    End Sub
    Private Sub Salir()

        Me.Dispose()
        MostrarImagenDeFondo()
    End Sub

    Private Sub MyGridView1_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles Gv.FocusedRowChanged

        Try
            HacerCambioFila()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub HacerCambioFila()
        If Cargando Then
            Exit Sub
        End If
        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            PanelCajas.Enabled = False
            UcComunicacionesDetalle1.Enabled = False
            txtObservaciones.Enabled = False
            dgvxInmuebles.Enabled = False
            Exit Sub
        Else
            PanelCajas.Enabled = True
            UcComunicacionesDetalle1.Enabled = True
            txtObservaciones.Enabled = True
            dgvxInmuebles.Enabled = True
        End If

        'XtraTabControl1.TabPages(0).Text = "Empleado: " & Gv.GetFocusedRowCellValue("Nombre")
        If PanelGestionDocumental.Visibility = DockVisibility.Visible Then
            uGestionDocumental.Titulo("Gestión documental del propietario " & BinSrc.Current("Nombre"))
            uGestionDocumental.RefrescarBotones(Gv.GetFocusedRowCellValue(CampoGestionDocumental), TablaGestionDocumental)
        End If

        'BD_CERO.Execute("UPDATE Propietarios SET Observaciones= '" & Funciones.txtObservaciones.Text & "' WHERE Contador= " & BinSrc.Current("Contador"))
        'LlenarObservaciones(txtObservaciones, BinSrc.Current("Contador"), GL_TablaPropietarios)

        If BinSrc.Current("NoInmobiliaria") Then
            PanelControl3.BackColor = GL_ColorAruraRosaBaja
            PanelBotones.BackColor = GL_ColorAruraRosaBaja
            PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            PanelBotones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Else
            PanelControl3.BackColor = GL_ColorOriginal
            PanelBotones.BackColor = GL_ColorOriginal
            PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
            PanelBotones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        End If
        
        CambiosInmueblesyLlamadas()


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

            uGestionDocumental.Titulo("Gestión documental del propietario " & BinSrc.Current("Nombre"))
            uGestionDocumental.RefrescarBotones(Gv.GetFocusedRowCellValue(CampoGestionDocumental).ToString, TablaGestionDocumental)
        End If
    End Sub

    Private Sub btnInmuebles_Click(sender As System.Object, e As System.EventArgs) Handles btnInmuebles.Click
        CargarInmuebles()
    End Sub

  
    Private Sub CargarInmuebles()
        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            MensajeError("Debe seleccionar un registro")
            Return
        End If
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        CargarFormulario("Inmuebles", "", True, GL_VENGO_DE_PROPIETARIOS, BinSrc.Current("Contador").ToString & "|FALSE")
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub
    Private Sub btnAnadirObservaciones_Click(sender As System.Object, e As System.EventArgs) Handles btnAnadirObservaciones.Click

        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            MensajeError("Debe seleccionar un registro")
            Return
        End If

        Dim Observaciones As New Tablas.clComunicaciones

        Observaciones.Tipo = GL_OBSERVACIONES_MANUAL
        Observaciones.Tabla = TablaMantenimiento
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
        BD_CERO.Execute("UPDATE Propietarios SET Observaciones= '" & Funciones.pf_ReplaceComillas(txtObservaciones.Text) & "' WHERE Contador= " & BinSrc.Current("Contador"))
        'LlenarObservaciones(txtObservaciones, BinSrc.Current("Contador"), TablaMantenimiento)
    End Sub
    Private Sub txtBusquedaEmailTelefono_Properties_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtBusquedaEmailTelefono.Properties.ButtonClick
        If e.Button.Index = 0 Then
            txtBusquedaEmailTelefono.Text = ""
            'BuscandoPorTelefonoEmail2 = False
            BusquedaPorTelefonoEmail()
        End If

    End Sub
    Private Sub txtBusquedaEmailTelefono_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtBusquedaEmailTelefono.KeyDown
        If e.KeyCode = Keys.Enter Then
            BusquedaPorTelefonoEmail()
        End If
    End Sub

    Private Sub BusquedaPorTelefonoEmail()

        If txtBusquedaEmailTelefono.Text.Trim = "" Then
            BuscandoPorTelefonoEmail2 = False
        Else
            BuscandoPorTelefonoEmail2 = True
        End If

        If Not BuscandoPorTelefonoEmail2 Then


            ' PulsadoVerBajas = False
            LlenarGrid()
            txtBusquedaEmailTelefono.Text = ""
            txtBusquedaEmailTelefono.ForeColor = ColorInicialBotonBuscar
            '     VerBajas()
            HabilitarBotones()
            'btnDarDeBaja.Enabled = True
            '  MenuGrid.PopMenuDarDeBajaCliente.Visible = True

        Else

            'PulsadoVerBajas = False
            LlenarGrid()
            '  txtBusquedaEmailTelefono.Text = ""
            txtBusquedaEmailTelefono.ForeColor = Color.Red
            'VerBajas()
            HabilitarBotones()
            'btnDarDeBaja.Enabled = True
            ' MenuGrid.PopMenuDarDeBajaCliente.Visible = True
        End If

      



        Try
            HacerCambioFila()
            'Gv.Focus()

            'Gv.FocusedRowHandle = 0
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub BusquedaPorTelefonoEmail()

    '    If FiltroBusqueda <> "" Then
    '        FiltroBusqueda = ""
    '        LlenarGrid()
    '        txtBusquedaEmailTelefono.Text = ""
    '        txtBusquedaEmailTelefono.ForeColor = Color.Black
    '        HacerCambioFila()
    '        Return
    '    End If

    '    If FiltroBusqueda = txtBusquedaEmailTelefono.Text Then
    '        Return
    '    End If

    '    If txtBusquedaEmailTelefono.Text <> "" Then
    '        FiltroBusqueda = txtBusquedaEmailTelefono.Text
    '        LlenarGrid()
    '        txtBusquedaEmailTelefono.ForeColor = Color.Red
    '        HacerCambioFila()
    '    Else

    '        FiltroBusqueda = ""
    '        LlenarGrid()
    '        txtBusquedaEmailTelefono.Text = ""
    '        txtBusquedaEmailTelefono.ForeColor = Color.Black
    '        HacerCambioFila()
    '        '      View.EditingValue = Gl_ResultadoBusqueda
    '    End If

    'End Sub
   
        
    Private Sub btnNuevoInmueble_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevoInmueble.Click

        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            MensajeError("Debe seleccionar un registro")
            Return
        End If


        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        CargarFormulario("Inmuebles", "", True, GL_VENGO_DE_PROPIETARIOS, BinSrc.Current("Contador").ToString & "|TRUE")
        uInmueblesActivo.NuevoInmuebleDesdeProp()
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub

    Private Sub txt_LostFocus(sender As System.Object, e As System.EventArgs) Handles txtTelefono1.Leave, txtTelefono2.Leave, txtTelefono3.Leave, txtTelefono4.Leave, txtTelefonoMovil.Leave, txtFax.Leave, txtEmail.Leave, txtEmail2.Leave
        If Not EstoyEnAlta Then Return
        Dim txt As TextEdit = TryCast(sender, TextEdit)
        Dim campos As String = ""
        If txt.EditValue = "" Then Return

        Dim YaEncontrado As Boolean = False

        Select Case txt.Tag
            Case "Email", "Email2"
                campos = "WHERE Email= '" & txt.EditValue & "' OR Email2= '" & txt.EditValue & "'"
            Case Else
                campos = "WHERE Telefono1 = '" & txt.EditValue & "' OR Telefono2 = '" & txt.EditValue & "' OR Telefono3 = '" & txt.EditValue & "' OR Telefono4 = '" & txt.EditValue & "' OR TelefonoMovil = '" & txt.EditValue & "' OR Fax = '" & txt.EditValue & "'"
        End Select
        Dim sel As String = GL_SQL_TOP1_FRONT & " Nombre " & GL_SQL_SUMA & "'|'" & GL_SQL_SUMA & " " & Funciones.SQL_CONVERT("VARCHAR", "Contador") & GL_SQL_SUMA & "'|'" & GL_SQL_SUMA & " '" & txt.Tag & "' FROM Propietarios " & campos & GL_SQL_TOP1_BACK
        Dim Resultado() As String = Nothing
        Resultado = Split(bd.Execute(sel, False), "|")
        If Not Resultado Is Nothing AndAlso Resultado.Length > 2 Then
            If XtraMessageBox.Show("Ya existe un propietario (" & Resultado(0) & ") con ese " & Resultado(2) & vbCrLf & "¿Desea verlo?", "Duplicado", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                EstoyEnAlta = False
                Cancelar()
                BinSrc.Filter = campos.Substring(6)
                BinSrc.MoveFirst()
                YaEncontrado = True
            End If
        End If

        If Not YaEncontrado Then
            Select Case txt.Tag 'Buscamos en propietarios
                Case "Email", "Email2"
                    campos = "WHERE Email = '" & txt.EditValue & "'"
                Case Else
                    campos = "WHERE Telefono1 = '" & Funciones.pf_ReplaceComillas(txt.EditValue) & "' OR Telefono2 = '" & Funciones.pf_ReplaceComillas(txt.EditValue) & "' OR TelefonoMovil = '" & Funciones.pf_ReplaceComillas(txt.EditValue) & "' OR Fax = '" & Funciones.pf_ReplaceComillas(txt.EditValue) & "'"
            End Select
            Dim SelPrpi As String
            Dim Propietario As String
            Dim bEsBaja As Boolean
            Dim strEsBaja As String
            SelPrpi = GL_SQL_TOP1_FRONT & "  Nombre FROM Clientes " & campos & GL_SQL_TOP1_BACK
            Propietario = BD_CERO.Execute(SelPrpi, False)
            SelPrpi = GL_SQL_TOP1_FRONT & " Baja   FROM Clientes " & campos & GL_SQL_TOP1_BACK
            bEsBaja = BD_CERO.Execute(SelPrpi, False)
            If bEsBaja Then
                strEsBaja = "BAJA"
            Else
                strEsBaja = "ALTA"
            End If
            If Not Propietario Is Nothing And Not String.IsNullOrEmpty(Propietario) Then
                MensajeInformacion("Existe un cliente de " & strEsBaja & " con este " & txt.Tag & "." & vbCrLf & "El cliente es " & Propietario)
            End If
        End If

    End Sub
     
    Private Sub btnVerTodos_Click(sender As System.Object, e As System.EventArgs) Handles btnVerTodos.Click
        FiltroBusqueda = ""
        txtBusquedaEmailTelefono.Text = ""
        DeDondeVengo = ""
        Gv.ActiveFilterCriteria = Nothing
        soloConInmuebles = False
        noReservados = False
        Try
            BinSrc.Filter = Nothing
        Catch ex As Exception

        End Try
        LlenarGrid()
    End Sub

#Region "Inmuebles"
    Private Sub CambiosInmueblesyLlamadas()
        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Return
        End If

        LlenarGridInmuebles()
        LlenarGridLlamadas()
    End Sub

    Public Sub LlenarGridLlamadas()

        Dim Tabla As String = "Propietarios"
        Dim Sel As String = "SELECT Fecha,(SELECT Nombre FROM Empleados WHERE Contador = ContadorEmpleado ) as Comercial from PropietariosComunicaciones  WHERE ContadorPropietario  = " & BinSrc.Current("Contador") & " ORDER BY Fecha DESC, Contador DESC"
        Dim bd As New BaseDatos
        bd.LlenarDataSet(Sel, Tabla)

        'dgvxLlamadas.DataSource = bd.ds.Tables(Tabla)
        'dgvxLlamadas.ForceInitialize()
        'ParametrizarGrid(GvLlamadas)

        'dgvxLlamadas.tbCarpetaPerfiles = GL_CARPETA_PERFILES & "\" & Me.Name & "\" & dgvxLlamadas.Name
        'dgvxLlamadas.ContextMenuStrip = New tbContextMenuStripComponent(dgvxLlamadas.tbCarpetaPerfiles)

        'ConfigurarGridLlamadas()
        UcComunicacionesDetalle1.LlenarGrid(BinSrc.Current("Contador"), GL_TablaPropietarios, 0)

        Try
            If Not dgvxInmuebles.tb_AnadirColumnaCheck Then
                dgvxInmuebles.tb_AnadirColumnaCheck = True
            End If


        Catch ex As Exception
        End Try
        'txtObservaciones.Text = BD_CERO.Execute("SELECT Observaciones FROM Propietarios WHERE Contador= " & txtCodPropietario.EditValue)
        'LlenarObservaciones(txtObservaciones, txtCodPropietario.EditValue, TablaMantenimiento)

    End Sub


    Public Sub LlenarGridInmuebles()

        bdInm = New BaseDatos

        If IsNothing(BinSrc.Current("Contador")) Then
            Return
        End If
        ',(SELECT TOP 1 r.Observaciones FROM Reservas r WHERE r.ContadorInmueble=I.Contador ORDER BY Fecha DESC) as ObservacionesReservas



        Dim SentenciaSQL As String = "SELECT Direccion " & GL_SQL_SUMA & _
            Funciones.SQL_CASE({"Numero <> ''", "Numero = ''"}, {"' Num '" & GL_SQL_SUMA & "Numero", "''"}) & GL_SQL_SUMA & _
            Funciones.SQL_CASE({"Puerta <> ''", "Puerta = ''"}, {"' Pta. '" & GL_SQL_SUMA & "Puerta", "''"}) & " as DireccionCompleta ,ContadorPropietario, Reservado , Contador, Referencia, FechaAlta, FotosPc, FotosWeb, Direccion, Poblacion, Metros, TipoVenta,PrecioPropietario  AS Precio  , FechaReservado , Tipo, Altura, Zona,   Baja" & _
                           " FROM Inmuebles I" & _
        " WHERE ContadorPropietario =" & BinSrc.Current("Contador") & " ORDER BY Baja, Reservado, Referencia DESC"




        '**********
        bdInm = New BaseDatos
        bdInm.LlenarDataSet(SentenciaSQL, TablaMantenimiento, , False, True)
 
 
        dgvxInmuebles.DataSource = bdInm.ds
        dgvxInmuebles.DataMember = TablaMantenimiento

        '    GvInmuebles = New MyGridView
        GvInmuebles = Nothing
        GvInmuebles = dgvxInmuebles.MainView

        'MyGridControl1.DataSource = BinSrc
        'MyGridView1 = MyGridControl1.MainView

        dgvxInmuebles.ForceInitialize()

        'Dim AP As ActualizaPerfil
        'If PrimeraVezInmuebles Then
        '    AP = New ActualizaPerfil(GvInmuebles)
        'End If
        ''***************

        ParametrizarGrid(GvInmuebles)

        dgvxInmuebles.tbCarpetaPerfiles = GL_CARPETA_PERFILES & "\" & Me.Name & "\" & dgvxInmuebles.Name

        MenuGrid = New tbContextMenuStripComponent(dgvxInmuebles.tbCarpetaPerfiles)
        dgvxInmuebles.ContextMenuStrip = MenuGrid

        MenuGrid.PopMenuEscaparate.Visible = False
        MenuGrid.PopMenuMapa.Visible = True
        MenuGrid.PopMenuReserva.Visible = True
        MenuGrid.PopMenuExportar.Visible = False
        MenuGrid.PopMenuPerfiles.Visible = False
        MenuGrid.PopMenuFiltros.Visible = False
        MenuGrid.PopMenuCopiarCelda.Visible = False
        MenuGrid.PopMenuCopiarFila.Visible = False
        MenuGrid.Parentt = "Propiet"
        ConfigurarGridInmuebles()

       

         
        FocusedColorInmuebles(GvInmuebles)
    End Sub


    Private Sub ConfigurarGridInmuebles()

        If Not PrimeraVezInmuebles Then
            Exit Sub
        End If

        PrimeraVezInmuebles = False
        If dgvxInmuebles.tbEstablecerPerfilPredeterminado() Then
            Exit Sub
        End If

        GvInmuebles.OptionsView.ShowAutoFilterRow = False

        GvInmuebles.BeginDataUpdate()
        Try
            GvInmuebles.ClearSorting()
            GvInmuebles.Columns("Baja").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            GvInmuebles.Columns("Reservado").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            GvInmuebles.Columns("Referencia").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
        Finally
            GvInmuebles.EndDataUpdate()
        End Try


        PonerColoresInmuebles(GvInmuebles)

        For i = 0 To GvInmuebles.Columns.Count - 1
            GvInmuebles.Columns(i).Visible = False
        Next

        Dim pos As Integer = 0

        pos = pos + 1
        GvInmuebles.Columns("Referencia").VisibleIndex = pos
        pos = pos + 1
        GvInmuebles.Columns("FotosPc").VisibleIndex = pos
        pos = pos + 1
        GvInmuebles.Columns("FotosWeb").VisibleIndex = pos
        pos = pos + 1
        GvInmuebles.Columns("DireccionCompleta").VisibleIndex = pos
        pos = pos + 1
        GvInmuebles.Columns("Poblacion").VisibleIndex = pos
        pos = pos + 1
        GvInmuebles.Columns("Metros").VisibleIndex = pos
        pos = pos + 1
        GvInmuebles.Columns("Precio").VisibleIndex = pos
        pos = pos + 1
        GvInmuebles.Columns("Tipo").VisibleIndex = pos
        pos = pos + 1
        GvInmuebles.Columns("Altura").VisibleIndex = pos
        pos = pos + 1
        GvInmuebles.Columns("FechaReservado").VisibleIndex = pos
        pos = pos + 1
        GvInmuebles.Columns("Zona").VisibleIndex = pos
        pos = pos + 1
        GvInmuebles.Columns("TipoVenta").VisibleIndex = pos
        'GvInmuebles.Columns("ObservacionesReservas").VisibleIndex = 13

        'GvInmuebles.BestFitColumns()

        'GvInmuebles.OptionsView.ColumnAutoWidth = False
        GvInmuebles.OptionsView.ShowGroupPanel = False
        GvInmuebles.OptionsView.ShowAutoFilterRow = True



        GvInmuebles.Columns("TipoVenta").Caption = "Oferta"

        GvInmuebles.Columns("Reservado").Visible = False

        GvInmuebles.Columns("Referencia").Visible = True
        GvInmuebles.Columns("FechaAlta").Visible = True
        GvInmuebles.Columns("FotosPc").Visible = True
        GvInmuebles.Columns("FotosWeb").Visible = True

        GvInmuebles.Columns("DireccionCompleta").Visible = True
        GvInmuebles.Columns("Poblacion").Visible = True
        GvInmuebles.Columns("Metros").Visible = True

        GvInmuebles.Columns("Precio").Visible = True
        GvInmuebles.Columns("Tipo").Visible = True
        GvInmuebles.Columns("Altura").Visible = True
        'GvInmuebles.Columns("Zona").Visible = True
        'GvInmuebles.Columns("ObservacionesReservas").Visible = True
        GvInmuebles.Columns("FechaReservado").Visible = True

        GvInmuebles.Columns("FechaAlta").Visible = False

        GvInmuebles.BestFitColumns()
        GvInmuebles.Columns("FechaReservado").Width = 80

        GvInmuebles.Columns("FechaAlta").Width = 80
        GvInmuebles.Columns("FotosPc").Width = 50
        GvInmuebles.Columns("FotosWeb").Width = 50
        GvInmuebles.Columns("Metros").Width = 65
        GvInmuebles.Columns("Referencia").Width = 65
        GvInmuebles.Columns("Precio").Width = 70
        GvInmuebles.Columns("DireccionCompleta").Width = 200

        GvInmuebles.Columns("Tipo").Width = 60
        GvInmuebles.Columns("Altura").Width = 50
        GvInmuebles.Columns("Zona").Width = 200


        GvInmuebles.Columns("FechaReservado").Caption = "F. Reserva"




        GvInmuebles.Columns("FotosPc").Caption = "F. PC"
        GvInmuebles.Columns("FotosWeb").Caption = "F.Web"
        GvInmuebles.Columns("Referencia").Caption = "Ref."



        GvInmuebles.OptionsView.ShowFooter = False
        GvInmuebles.OptionsView.ShowAutoFilterRow = False

        'Dim ItemArticulo As GridGroupSummaryItem = New GridGroupSummaryItem()
        'ItemArticulo.FieldName = "Contador"
        'ItemArticulo.DisplayFormat = "{0:n0}"
        'ItemArticulo.SummaryType = DevExpress.Data.SummaryItemType.Count
        'GvInmuebles.GroupSummary.Add(ItemArticulo)

    End Sub

    Private Sub gv_CustomColumnDisplayText(ByVal sender As Object, ByVal e As Views.Base.CustomColumnDisplayTextEventArgs) Handles GvInmuebles.CustomColumnDisplayText
        Dim View As Views.Base.ColumnView = sender
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

    Private Sub Gv_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GvInmuebles.FocusedRowChanged

        Try
            FocusedColorInmuebles(GvInmuebles)
        Catch ex As Exception

        End Try

    End Sub

#End Region



    Private Sub btnEmails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmails.Click
        EnviosDeEmailMasivo()
    End Sub

    Private Sub EnviosDeEmailMasivo()

        If dgvx.ColumnaCheck.SelectedCount = 0 AndAlso (Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle) Then
            MensajeError("No ha seleccionado ningún inmueble al que enviar email")
            Exit Sub
        End If

        If dgvx.ColumnaCheck.SelectedCount > 1 AndAlso Not IsNothing(dgvxInmuebles.ColumnaCheck) AndAlso dgvxInmuebles.ColumnaCheck.SelectedCount > 0 Then
            If XtraMessageBox.Show("Ha marcado para enviar varios propietarios y al mismo tiempo inmuebles." & vbCrLf & "Si continua, se enviarán emails a todos los propietarios y todos los inmuebles." & vbCrLf & "¿Quiere continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
                Return
            End If
        End If

        Dim TablaInmuebles As String = GL_TablaInmuebles
        Dim dgvxSeleccionado As MyGridControl
        Dim GvSeleccionado As MyGridView

        ' Dim TrabajoConLosInmueblesDelUcPropietarios As Boolean

        If dgvx.ColumnaCheck.SelectedCount = 0 Or dgvx.ColumnaCheck.SelectedCount = 1 Then
            dgvxSeleccionado = dgvxInmuebles
            GvSeleccionado = GvInmuebles
            '  TrabajoConLosInmueblesDelUcPropietarios = True
        Else
            dgvxSeleccionado = dgvx
            GvSeleccionado = Gv
            '  TrabajoConLosInmueblesDelUcPropietarios = False
            If Not IsNothing(dgvxInmuebles.ColumnaCheck) Then
                dgvxInmuebles.ColumnaCheck.ClearSelection()
            End If

        End If



        If dgvxSeleccionado.ColumnaCheck.SelectedCount = 0 And (GvSeleccionado.RowCount = 0 OrElse GvSeleccionado.FocusedRowHandle = GridControl.AutoFilterRowHandle) Then
            MensajeError("No ha seleccionado ningún inmueble al que enviar email")
            Exit Sub
        End If

        Dim SeleccionManual As Boolean = False

        If dgvxSeleccionado.ColumnaCheck.SelectedCount = 0 Then
            If dgvxSeleccionado Is dgvxInmuebles Then
                dgvxSeleccionado.ColumnaCheck.SelectAll()
            Else
                dgvxSeleccionado.ColumnaCheck.SelectRow(GvSeleccionado.FocusedRowHandle, True)
            End If

            SeleccionManual = True
        End If

        'Aqui mostramos un form en el q definimos el mensaje,titulo y asunto, elegimos el predeterminado o guardamos alguno nuevo o cargamos
        'asi como si se incluyen los datos de empresa los de los inmuebles o incluso si se agrega algun documento adjunto
        CargarFormulario("MensajeEmail")
        '  frmMensajeEmail.ShowDialog()
        Dim a() As String = Split(GL_DatosMensajePersonalizado, "|")
        If a(8) = True Then
            If SeleccionManual Then
                'dgvxSeleccionado.ColumnaCheck.SelectRow(GvSeleccionado.FocusedRowHandle, False)
                dgvxSeleccionado.ColumnaCheck.ClearSelection()
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
            pnlEnviado.Left = (Me.Width - pnlEnviado.Width) / 2
            pnlEnviado.Top = (Me.Height - pnlEnviado.Height) / 2
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
        If dgvxSeleccionado Is dgvxInmuebles Then
            CampoContador = "i.Contador"
        Else
            CampoContador = "p.Contador"
        End If


        SentenciaSQL = "SELECT i.Contador as ContadorInmueble,i.Referencia,p.Nombre,p.Email " & GL_SQL_SUMA & " " & _
            Funciones.SQL_CASE({"p.Email2 = ''", "p.Email2 " & GL_SQL_DIS & " ''"}, {"''", "';'" & GL_SQL_SUMA & " P.Email2"}) & " AS Email,p.NoQuiereRecibirEmails, p.Contador as ContadorPropietario " & _
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

                        '  If ContadorPropietario <> .Item("ContadorPropietario") Then
                        Try
                            ContadorPropietario = .Item("ContadorPropietario")
                            AdjuntosAEviar = ""
                            Dim ResultadoEnvio As String = ""
                            'obtenemos la informacion a enviar
                            Dim AsuntoYMensaje As New Tablas.cl_AsuntoYMensaje
                            AsuntoYMensaje.Asunto = AsuntoMensaje
                            AsuntoYMensaje.Titulo = TituloMensaje
                            AsuntoYMensaje.Mensaje = MensajeMensaje & " <br><br>"
                            ' ListaContadores As New List(Of Integer)

                            '  For ii As Integer = i To DTEmail.Rows.Count - 1
                            '    If DTEmail.Rows(ii).Item("ContadorPropietario") = ContadorPropietario Then
                            CuantosConMail += 1 'cada propietario duplicado se cuenta como un nuevo mail enviado

                            Dim ContaInmu As Integer

                            '     ContaInmu = DTEmail.Rows(ii).Item("ContadorInmueble")
                            ContaInmu = DTEmail.Rows(i).Item("ContadorInmueble")
                            '  ListaContadores.Add(ContaInmu)

                            '   If AnadirDatosInmueble Then
                            AsuntoYMensaje.Mensaje &= ConsultasBaseDatos.ObtenerMensajePropietario(DatosEmpresa.Codigo, ContaInmu, DTEmail.Rows(i).Item("Referencia"), AnadirDatosEmpresa, AnadirAvisoLegal, IncluirTextoFaltanFotos, IncluirTextoDireccionInmueble, AnadirDatosInmueble) & vbCrLf & vbCrLf
                            '   End If
                            If IncluirFichaInmueble Then
                                Dim listaInmuebles As String = " where (I.Contador=" & ContaInmu & ")"
                                If AdjuntosAEviar = "" Then
                                    AdjuntosAEviar = PrepararFicheroFichaInmueble(ContaInmu, TablaInmuebles, listaInmuebles)
                                Else
                                    AdjuntosAEviar = AdjuntosAEviar & ";" & PrepararFicheroFichaInmueble(ContaInmu, TablaInmuebles, listaInmuebles)
                                End If
                            End If
                            '   End If
                            '  Next
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

                                Dim Sel As String
                                Sel = "INSERT INTO PropietariosComunicaciones (CodigoEmpresa ,Delegacion, ContadorInmueble, ContadorPropietario,Fecha,ContadorEmpleado,LlamadaContestada,Observaciones,Tipo) VALUES (" & _
                                DatosEmpresa.Codigo & "," & Gl_Delegacion & ",0," & ContadorPropietario & "," & GL_SQL_GETDATE & "," & GL_CodigoUsuario & "," & ContaInmu & ", '" & Funciones.pf_ReplaceComillas(TipoEmail) & "', 'EMAIL'" & _
                                ")"
                                BD_CERO.Execute(Sel)

                                'For k = 0 To ListaContadores.Count - 1
                                '    Dim ContaInmu As Integer
                                '    ContaInmu = ListaContadores(k)
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



        Try 'Escondemos panel envio

            pnlEnviado.Visible = False
            PanelBotones.Enabled = True
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Catch ex As Exception

        End Try

        If CuantosSinMail > 0 Then 'Mostramos mensaje con los errores
            Dim CadenaMensaje As String = ""

            CadenaMensaje = "Hay " & CuantosSinMail & " propietarios de los inmuebles seleccionados que no se ha podido enviar el email porque no tiene dirección de email o el email no es correcto."

            For Each s In PropietariosSinMail
                CadenaMensaje = CadenaMensaje & vbCrLf & s.ToString
            Next
            MensajeError(CadenaMensaje)
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

        LlenarGrid(True)

        dgvx.ColumnaCheck.ClearSelection()
        dgvxInmuebles.ColumnaCheck.ClearSelection()

        'bd.RefrescarDatos()
        '  PonerPendienteRefrescarPropietarios()
        PonerPendienteRefrescarAlarmas()

        MensajeInformacion("El envío de emails finalizó correctamente.")

    End Sub
    Private Sub btnEmailInformativo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmailInformativo.Click
        EnviosDeEmailInformativo()
    End Sub


    Private Sub EnviosDeEmailInformativo()

        If dgvx.ColumnaCheck.SelectedCount = 0 AndAlso (Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle) Then
            MensajeError("No ha seleccionado ningún propietario al que enviar email")
            Exit Sub
        End If

        

        Dim TablaInmuebles As String = GL_TablaInmuebles
        Dim dgvxSeleccionado As MyGridControl
        Dim GvSeleccionado As MyGridView

        dgvxSeleccionado = dgvx
        GvSeleccionado = Gv
        dgvxInmuebles.ColumnaCheck.ClearSelection()
 
        Dim SeleccionManual As Boolean = False

        If dgvxSeleccionado.ColumnaCheck.SelectedCount = 0 Then
            dgvxSeleccionado.ColumnaCheck.SelectRow(GvSeleccionado.FocusedRowHandle, True)

            SeleccionManual = True
        End If

        'Aqui mostramos un form en el q definimos el mensaje,titulo y asunto, elegimos el predeterminado o guardamos alguno nuevo o cargamos
        'asi como si se incluyen los datos de empresa los de los inmuebles o incluso si se agrega algun documento adjunto
        ' CargarFormulario("MensajeEmail")
        frmMensajeEmail.ShowDialog()
        Dim a() As String = Split(GL_DatosMensajePersonalizado, "|")
        If a(8) = True Then
            If SeleccionManual Then
                'dgvxSeleccionado.ColumnaCheck.SelectRow(GvSeleccionado.FocusedRowHandle, False)
                dgvxSeleccionado.ColumnaCheck.ClearSelection()
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
            pnlEnviado.Left = (Me.Width - pnlEnviado.Width) / 2
            pnlEnviado.Top = (Me.Height - pnlEnviado.Height) / 2
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
        If dgvxSeleccionado Is dgvxInmuebles Then
            CampoContador = "i.Contador"
        Else
            CampoContador = "p.Contador"
        End If


        'SentenciaSQL = "SELECT i.Contador as ContadorInmueble,i.Referencia,p.Nombre,p.Email " & GL_SQL_SUMA & " " & _
        '    Funciones.SQL_CASE({"p.Email2 = ''", "p.Email2 " & GL_SQL_DIS & " ''"}, {"''", "';'" & GL_SQL_SUMA & " P.Email2"}) & " AS Email,p.NoQuiereRecibirEmails, p.Contador as ContadorPropietario " & _
        '    " FROM Inmuebles i INNER JOIN Propietarios p ON i.ContadorPropietario = p.Contador WHERE " & CampoContador & " IN(" & inmuebles & ") ORDER  BY P.Contador"

        SentenciaSQL = "SELECT p.Nombre,p.Email " & GL_SQL_SUMA & " " & _
      Funciones.SQL_CASE({"p.Email2 = ''", "p.Email2 " & GL_SQL_DIS & " ''"}, {"''", "';'" & GL_SQL_SUMA & " P.Email2"}) & " AS Email,p.NoQuiereRecibirEmails, p.Contador as ContadorPropietario " & _
      " FROM Propietarios p  WHERE " & CampoContador & " IN(" & inmuebles & ") ORDER  BY P.Contador"


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

                        '  If ContadorPropietario <> .Item("ContadorPropietario") Then
                        Try
                            ContadorPropietario = .Item("ContadorPropietario")
                            AdjuntosAEviar = ""
                            Dim ResultadoEnvio As String = ""
                            'obtenemos la informacion a enviar
                            Dim AsuntoYMensaje As New Tablas.cl_AsuntoYMensaje
                            AsuntoYMensaje.Asunto = AsuntoMensaje
                            AsuntoYMensaje.Titulo = TituloMensaje
                            AsuntoYMensaje.Mensaje = MensajeMensaje & " <br><br>"
                            ' ListaContadores As New List(Of Integer)

                            '  For ii As Integer = i To DTEmail.Rows.Count - 1
                            '    If DTEmail.Rows(ii).Item("ContadorPropietario") = ContadorPropietario Then
                            CuantosConMail += 1 'cada propietario duplicado se cuenta como un nuevo mail enviado

                            Dim ContaInmu As Integer

                            '     ContaInmu = DTEmail.Rows(ii).Item("ContadorInmueble")
                            ContaInmu = 0
                            '  ListaContadores.Add(ContaInmu)

                            '   If AnadirDatosInmueble Then
                            AsuntoYMensaje.Mensaje &= ConsultasBaseDatos.ObtenerMensajePropietario(DatosEmpresa.Codigo, ContaInmu, "", AnadirDatosEmpresa, AnadirAvisoLegal, IncluirTextoFaltanFotos, IncluirTextoDireccionInmueble, AnadirDatosInmueble) & vbCrLf & vbCrLf
                            
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

                                Dim Sel As String
                                Sel = "INSERT INTO PropietariosComunicaciones (CodigoEmpresa ,Delegacion, ContadorInmueble, ContadorPropietario,Fecha,ContadorEmpleado,LlamadaContestada,Observaciones,Tipo) VALUES (" & _
                                DatosEmpresa.Codigo & "," & Gl_Delegacion & ",0," & ContadorPropietario & "," & GL_SQL_GETDATE & "," & GL_CodigoUsuario & "," & ContaInmu & ", '" & Funciones.pf_ReplaceComillas(TipoEmail) & "', 'EMAIL'" & _
                                ")"
                                BD_CERO.Execute(Sel)

                                'For k = 0 To ListaContadores.Count - 1
                                '    Dim ContaInmu As Integer
                                '    ContaInmu = ListaContadores(k)
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



        Try 'Escondemos panel envio

            pnlEnviado.Visible = False
            PanelBotones.Enabled = True
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Catch ex As Exception

        End Try

        If CuantosSinMail > 0 Then 'Mostramos mensaje con los errores
            Dim CadenaMensaje As String = ""

            CadenaMensaje = "Hay " & CuantosSinMail & " propietarios de los seleccionados que no se ha podido enviar el email porque no tiene dirección de email o el email no es correcto."

            For Each s In PropietariosSinMail
                CadenaMensaje = CadenaMensaje & vbCrLf & s.ToString
            Next
            MensajeError(CadenaMensaje)
        End If
        If CuantosNoQuieren > 0 Then 'Mostramos mensaje con los que no quieren
            Dim CadenaMensaje As String = ""

            CadenaMensaje = "Hay " & CuantosNoQuieren & " propietarios de los seleccionados que no recibirán emails porque no quieren."

            For Each s In PropietariosNoQuierenEmails
                CadenaMensaje = CadenaMensaje & vbCrLf & s.ToString
            Next
            MensajeError(CadenaMensaje)
        End If
        If CuantosErrores > 0 Then 'Mostramos mensaje con los errores de envio
            Dim CadenaMensaje As String = ""

            CadenaMensaje = "Hay " & CuantosErrores & " propietarios de los seleccionados que ha fallado el envio."

            For Each s In ErrorEnvio
                CadenaMensaje = CadenaMensaje & vbCrLf & s.ToString
            Next
            MensajeError(CadenaMensaje)
        End If

        LlenarGrid(True)

        dgvx.ColumnaCheck.ClearSelection()
        dgvxInmuebles.ColumnaCheck.ClearSelection()

        'bd.RefrescarDatos()
        '  PonerPendienteRefrescarPropietarios()
        PonerPendienteRefrescarAlarmas()

        MensajeInformacion("El envío de emails finalizó correctamente.")

    End Sub



    Private Sub btnSoloConInmuebles_Click(sender As System.Object, e As System.EventArgs) Handles btnSoloConInmuebles.Click
        soloConInmuebles = True
        SinInmuebles = False
        LlenarGrid()
    End Sub

    Private Sub btnSoloSinInmuebles_Click(sender As System.Object, e As System.EventArgs) Handles btnSoloSinInmuebles.Click
        soloConInmuebles = False
        SinInmuebles = True
        LlenarGrid()
    End Sub
    Private Sub btnNoReservados_Click(sender As System.Object, e As System.EventArgs) Handles btnNoReservados.Click
        noReservados = True
        LlenarGrid()
    End Sub

    Private Sub GvInmuebles_RowCellStyle(sender As System.Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GvInmuebles.RowCellStyle

    End Sub
End Class




