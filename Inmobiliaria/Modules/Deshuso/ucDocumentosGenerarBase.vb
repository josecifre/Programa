Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors
Imports System
Imports System.Windows.Forms
Imports System.Data
Imports DevExpress.XtraGrid
Imports DevExpress.XtraBars.Docking


Partial Public Class ucDocumentosGenerarBase

    Dim bd As BaseDatos
    Dim TabDocumentos As Tablas.clTablaGeneral
    Dim TabDocumentosDetalle As Tablas.clTablaGeneral
    Public TablaDocumento As String

    Public TablaDocumentoDetalle As String
    Public TablaTotales As String = "TablaTotales"

    Dim TrabajarConAgrupaciones As Boolean
    Dim CampoBusquedas As String
    Dim AnadiendoOModificando As Boolean = False
    Dim Eliminando As Boolean = False
    Dim ContadorDocumento As Integer

    Dim PanelRiesgo As DockPanel
    Dim PanelArticulosVendidos As DockPanel

    Dim uArticulosVendidos As ucInmueblesPropietario
    Dim PrimeraVez As Boolean
    Dim Cargando As Boolean
    Dim EstadoOriginal As String

    Private WithEvents BinSrc As BindingSource

    Public Sub New(NombreTabla As String, Contador As Integer, Estad As String)

        InitializeComponent()

        TablaDocumento = NombreTabla
        ContadorDocumento = Contador
        EstadoOriginal = Estad


        Me.Dock = DockStyle.Fill


        'PrimeraVez = True
        ''  Cargando = True
        'If ContadorDocumento = 0 Then
        '    ContadorDocumento = ConsultasBaseDatos.CrearDocumento(TablaDocumento)
        'End If


        'AparienciaGeneral()

        'Dim TextoDoc As String = ""

        'Select Case TablaDocumento.ToString.ToUpper


        '    Case GL_DocumentoPreventa
        '        TablaDocumentoDetalle = GL_DocumentoPreventaDetalle
        '        TextoDoc = "Preventa"


        '    Case GL_DocumentoPresupuesto
        '        TablaDocumentoDetalle = GL_DocumentoPresupuestoDetalle
        '        TextoDoc = "Presupuesto"
        '        btnEnviar.ToolTip = "Enviar" & vbCrLf & "Presupuesto"

        '    Case GL_DocumentoPedido
        '        TablaDocumentoDetalle = GL_DocumentoPedidoDetalle
        '        TextoDoc = "Pedido"


        '    Case GL_DocumentoAlbaran
        '        TablaDocumentoDetalle = GL_DocumentoAlbaranDetalle
        '        TextoDoc = "Albaran"


        '    Case GL_DocumentoFactura
        '        TablaDocumentoDetalle = GL_DocumentoFacturaDetalle
        '        TextoDoc = "Factura"

        'End Select

        'btnEliminarDocumento.ToolTip = "Eliminar" & vbCrLf & TextoDoc
        ''btnNuevoDocumento.ToolTip = "Nuevo" & vbCrLf & TextoDoc
        ''btnDuplicarDocumento.ToolTip = "Duplicar" & vbCrLf & TextoDoc
        'btnArticulosVendidos.Text = "Artículos" & vbCrLf & "Vendidos"
        'btnArticulosVendidos.ToolTip = "Ver Artículos Vendidos"
        'btnImprimir.ToolTip = "Imprimir" & vbCrLf & TextoDoc
        'btnEnviar.ToolTip = "Enviar" & vbCrLf & TextoDoc

        ''    AnadirBotonSalir() 

        ''Select Case TablaDocumento.ToUpper
        ''    Case GL_Agrupaciones, GL_Tarifas
        ''        TrabajarConAgrupaciones = False

        ''    Case Else
        ''        TrabajarConAgrupaciones = True

        ''End Select

        'TabDocumentos = New Tablas.clTablaGeneral(TablaDocumento, " WHERE Contador = " & ContadorDocumento)
        'bd = New BaseDatos
        'TabDocumentos.Datos(bd)

        'TabDocumentosDetalle = New Tablas.clTablaGeneral(TablaDocumentoDetalle, " WHERE ContadorDocumento = " & ContadorDocumento)
        'TabDocumentosDetalle.Datos(bd)

        'bd.LlenarDataSet("EXEC sp_TotalesDocumento '" & TablaDocumento & "' , " & ContadorDocumento, "TablaTotales")


        ''Dim TabAgrupaciones As Tablas.clTablaGeneral
        ''If TrabajarConAgrupaciones Then
        ''    TabAgrupaciones = New Tablas.clTablaGeneral("Agrupaciones")
        ''    TabAgrupaciones.Datos(bd)

        ''    Dim NombreRelacion As String = "Relacion"
        ''    Dim TablaPrincipal As String = TabAgrupaciones.TablaDocumento
        ''    Dim TablaSecundaria As String = TabDatos.TablaDocumento
        ''    Dim Campo As String = "Agrupacion"
        ''    bd.ds.Relations.Add(NombreRelacion, bd.ds.Tables(TablaPrincipal).Columns(Campo), bd.ds.Tables(TablaSecundaria).Columns(Campo))
        ''End If



        'BinSrc = New BindingSource
        'BinSrc.DataSource = bd.ds
        'BinSrc.DataMember = TablaDocumento


        ''Bindings

        'txtCodPostal.DataBindings.Add(New Binding("EditValue", BinSrc, "CodPostal", True))
        'txtDireccion.DataBindings.Add(New Binding("EditValue", BinSrc, "Direccion", True))
        'txtNIF.DataBindings.Add(New Binding("EditValue", BinSrc, "NIF", True))
        'txtPoblacion.DataBindings.Add(New Binding("EditValue", BinSrc, "Poblacion", True))
        'txtProvincia.DataBindings.Add(New Binding("EditValue", BinSrc, "Provincia", True))
        'txtNumero.DataBindings.Add(New Binding("EditValue", BinSrc, "Numero", True))

        'txtEmail.DataBindings.Add(New Binding("EditValue", BinSrc, "Email", True))
        'txtNombreComercial.DataBindings.Add(New Binding("EditValue", BinSrc, "NombreComercial", True))
        'txtTelefono1.DataBindings.Add(New Binding("EditValue", BinSrc, "Telefono1", True))
        'txtTelefono2.DataBindings.Add(New Binding("EditValue", BinSrc, "Telefono2", True))
        'txtFax.DataBindings.Add(New Binding("EditValue", BinSrc, "Fax", True))
        'txtObservaciones.DataBindings.Add(New Binding("EditValue", BinSrc, "Observaciones", True))



        'mskFecha.DataBindings.Add(New Binding("EditValue", BinSrc, "Fecha", True))
        'mskFechaEntrega.DataBindings.Add(New Binding("EditValue", BinSrc, "FechaEntrega", True))


        ''spnRetencion.DataBindings.Add(New Binding("EditValue", BinSrc, "Retencion", True))
        ''chkAplicarIVANulo.DataBindings.Add(New Binding("EditValue", BinSrc, "AplicarIVANulo", True))

        ''Combos
        'FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbAlmacenes, "Almacenes", "Almacen", "Almacen", , , , , , , , False)
        'FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbFormasPago, "FormasPago", "FormaPago", "Nombre", , , , , , , , False)
        'FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbEmpleados, "Empleados", "CodEmpleado", "Nombre", "Codigo", , , "SELECT Codigo, Nombre, NIF,Alias,Baja FROM Empleados WHERE Baja = 0 UNION SELECT Codigo, Nombre, E.NIF,Alias,Baja FROM Empleados E INNER JOIN " & TablaDocumento & " D ON E.Codigo = D.CodEmpleado WHERE D.Contador = " & ContadorDocumento & " ORDER BY Nombre", , , , False)
        'FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbClientes, "Clientes", "CodCliente", "Nombre", "Codigo", , , "SELECT Codigo, Nombre, NIF,NombreComercial,Baja,VentasBloqueadas FROM Clientes  WHERE Baja = 0 AND VentasBloqueadas = 0 UNION SELECT Codigo, Nombre, C.NIF,C.NombreComercial,Baja,VentasBloqueadas FROM Clientes C INNER JOIN " & TablaDocumento & " D ON C.Codigo = D.CodCliente WHERE D.Contador = " & ContadorDocumento & " ORDER BY Nombre", "Nombre", , , False)
        'FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbSeriesFacturacion, "SeriesFacturacion", "Serie", "Nombre", , , , , , , , False)

        'FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbDireccionesEnvio, "DireccionesEnvio", "DireccionEnvio", "Nombre", , , , , , , , False)

        'Dim col As DataColumn
        'Dim dtTotal As New DataTable

        'col = New DataColumn
        'With col
        '    .DataType = System.Type.GetType("System.Decimal")
        '    .ColumnName = "Total"
        '    .Caption = "Total"
        '    '.Expression = "Unidades * (1- (INV * " & CDbl(txtPorcentajeUnidades.Text) & "/100))"
        '    'If DatosEmpresa.IVAIncluido Then
        '    .Expression = "Cantidad * Precio * (1-(DtoPor/100))"
        '    'Else
        '    '    .Expression = "PV * (100 + IVAPor) / 100"
        '    'End If
        'End With
        'bd.ds.Tables(TabDocumentosDetalle.Tabla).Columns.Add(col)


        'dgvx.DataSource = bd.ds.Tables(TabDocumentosDetalle.Tabla)

        'PonerTotales()

        ''If TrabajarConAgrupaciones Then
        ''    Dim RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        ''    RepositoryItemLookUpEdit1.AutoHeight = False
        ''    RepositoryItemLookUpEdit1.DataSource = bd.ds.Tables(TabAgrupaciones.TablaDocumento)
        ''    RepositoryItemLookUpEdit1.DisplayMember = "Agrupacion"
        ''    RepositoryItemLookUpEdit1.Name = "RepositoryItemLookUpEdit1"
        ''    RepositoryItemLookUpEdit1.ValueMember = "Agrupacion"

        ''    Gv.Columns("Agrupacion").ColumnEdit = RepositoryItemLookUpEdit1
        ''End If


        'ParametrizarGrid(Gv)

        'dgvx.tbCarpetaPerfiles = GL_CARPETA_PERFILES & "\" & Me.Name & "\" & TablaDocumento.ToString.ToUpper & "\" & dgvx.Name
        'dgvx.ContextMenuStrip = New tbContextMenuStripComponent(dgvx.tbCarpetaPerfiles)
        'dgvx.ContextMenuStrip.Items.Add("Copiar Perfiles", Nothing, AddressOf CopiarPerfilesDgvX)

        'ConfigurarGrid()

        'If Estad <> GL_PENDIENTE And Estad <> "" Then
        '    pnlDetalle.Enabled = False
        '    PanelDatosGenerales.Enabled = False
        '    PanelDatosCliente.Enabled = False
        '    PanelDatosObservaciones.Enabled = False
        '    For Each c As SimpleButton In PanelBotones.Controls
        '        c.Enabled = False
        '    Next

        '    'btnNuevoDocumento.Enabled = True
        '    'btnDuplicarDocumento.Enabled = True
        '    btnEnviar.Enabled = True
        '    btnImprimir.Enabled = True
        '    btnSalir.Enabled = True
        '    btnRiesgo.Enabled = True
        '    btnArticulosVendidos.Enabled = True
        'End If




        ''    dgvx.RepositoryItems.Add((RepositoryItemLookUpEdit1))
        ''Dim bindingSource1 As New System.Windows.Forms.BindingSource
        ''bindingSource1.DataSource = bd.ds
        ''bindingSource1.DataMember = TabAgrupaciones.TablaDocumento

        ''    Gv.Columns.Add(ColAgrupacionAPoner)


        ''HabilitarBotones()
        ''      AjustarGrid()
        ''InitPopupMenu()



    End Sub



    Private Function ActualizarTabla(Tabla As String) As Boolean

        Try

            bd.ActualizarCambios(Tabla, bd.ds)
            bd.LlenarDataSet("EXEC sp_TotalesDocumento '" & TablaDocumento & "' , " & ContadorDocumento, "TablaTotales")
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
    Private Sub cmbCliente_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cmbClientes.EditValueChanged

        '    txtDireccion.EditValue = cmbClientes.Properties.GetRowByKeyValue(cmbClientes.EditValue)("Direccion")
        '    txtNIF.EditValue = cmbClientes.Properties.GetRowByKeyValue(cmbClientes.EditValue)("NIF")
        '    txtCodPostal.EditValue = cmbClientes.Properties.GetRowByKeyValue(cmbClientes.EditValue)("CodPostal")
        '    txtPoblacion.EditValue = cmbClientes.Properties.GetRowByKeyValue(cmbClientes.EditValue)("Poblacion")
        '    txtProvincia.EditValue = cmbClientes.Properties.GetRowByKeyValue(cmbClientes.EditValue)("Provincia")

        '    txtEmail.EditValue = cmbClientes.Properties.GetRowByKeyValue(cmbClientes.EditValue)("Email")
        '    txtNombreComercial.EditValue = cmbClientes.Properties.GetRowByKeyValue(cmbClientes.EditValue)("NombreComercial")
        '    txtTelefono1.EditValue = cmbClientes.Properties.GetRowByKeyValue(cmbClientes.EditValue)("Telefono1")
        '    txtTelefono2.EditValue = cmbClientes.Properties.GetRowByKeyValue(cmbClientes.EditValue)("Telefono2")
        'txtFax.EditValue = cmbClientes.Properties.GetRowByKeyValue(cmbClientes.EditValue)("Fax")

        If Cargando Then
            '   Cargando = False
            Exit Sub
        End If
        ' Dim TabCli As New Tablas.clTablaGeneral("Clientes", " WHERE Codigo = '" & cmbClientes.Properties.GetRowByKeyValue(cmbClientes.EditValue)("Codigo") & "'")
        Dim TabCli As New Tablas.clTablaGeneral("Clientes", " WHERE Codigo = '" & cmbClientes.EditValue & "'")
        Dim bdEmpresas As New BaseDatos
        TabCli.Datos(bdEmpresas)

        BinSrc.Current("CodCliente") = cmbClientes.EditValue
        txtDireccion.EditValue = bdEmpresas.ds.Tables(TabCli.Tabla).Rows(0)("Direccion").ToString
        txtNIF.EditValue = bdEmpresas.ds.Tables(TabCli.Tabla).Rows(0)("NIF").ToString
        txtCodPostal.EditValue = bdEmpresas.ds.Tables(TabCli.Tabla).Rows(0)("CodPostal").ToString

        txtPoblacion.EditValue = bdEmpresas.ds.Tables(TabCli.Tabla).Rows(0)("Poblacion").ToString
        txtProvincia.EditValue = bdEmpresas.ds.Tables(TabCli.Tabla).Rows(0)("Provincia").ToString

        txtEmail.EditValue = bdEmpresas.ds.Tables(TabCli.Tabla).Rows(0)("Email").ToString
        txtNombreComercial.EditValue = bdEmpresas.ds.Tables(TabCli.Tabla).Rows(0)("NombreComercial").ToString
        txtTelefono1.EditValue = bdEmpresas.ds.Tables(TabCli.Tabla).Rows(0)("Telefono1").ToString
        txtTelefono2.EditValue = bdEmpresas.ds.Tables(TabCli.Tabla).Rows(0)("Telefono2").ToString
        txtFax.EditValue = bdEmpresas.ds.Tables(TabCli.Tabla).Rows(0)("Fax").ToString
        '  FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbDireccionesEnvio, "DireccionesEnvio", "DireccionEnvio", "Nombre", "Codigo", , , , , , , False)
        FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbDireccionesEnvio, "DireccionesEnvio", "DireccionEnvio", "Nombre", , , , "SELECT CodigoCliente, Nombre, Direccion, Poblacion, Provincia FROM DireccionesEnvio  WHERE CodigoCliente = '" & cmbClientes.Properties.GetRowByKeyValue(cmbClientes.EditValue)("Codigo") & "'", , , , False, , , {"Codigo", "CodigoCliente"})
        cmbDireccionesEnvio.EditValue = ConsultasBaseDatos.ObtenerDireccionEnvioPrincipalCliente(cmbClientes.Properties.GetRowByKeyValue(cmbClientes.EditValue)("Codigo"))

        If Gv.RowCount <> 0 Then
            If XtraMessageBox.Show("¿Quiere aplicar los descuentos y formas de pago de este cliente?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                spnDescuentoEsp.EditValue = bdEmpresas.ds.Tables(TabCli.Tabla).Rows(0)("DescuentoEsp").ToString
                spnDescuentoPP.EditValue = bdEmpresas.ds.Tables(TabCli.Tabla).Rows(0)("DescuentoPP").ToString
                cmbFormasPago.EditValue = bdEmpresas.ds.Tables(TabCli.Tabla).Rows(0)("FormaPago").ToString
            End If
        End If



        'If BinSrc.Current("Cliente") <> cmbClientes.Text Then
        '    BinSrc.Current("Cliente") = cmbClientes.Text
        'End If

        'If BinSrc.Current("Empleado") <> cmbEmpleados.Text Then
        '    BinSrc.Current("Empleado") = cmbEmpleados.Text
        'End If
        BinSrc.EndEdit()
        ActualizarTabla(TablaDocumento)
        PonerTotales()

    End Sub



#Region "MantenimientoGrid"

    Private Sub ConfigurarGrid()

        If Not PrimeraVez Then
            Exit Sub
        End If

        PrimeraVez = False
        If dgvx.tbEstablecerPerfilPredeterminado() Then
            Exit Sub
        End If

        '**Opciones Generales del Grid
        Gv.OptionsNavigation.EnterMoveNextColumn = True
        Gv.OptionsNavigation.UseTabKey = True
        Gv.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom
        Gv.OptionsView.ShowGroupPanel = False
        Gv.OptionsBehavior.Editable = True
        Gv.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
        Gv.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True
        Gv.OptionsView.ColumnAutoWidth = True
        Gv.OptionsView.ShowAutoFilterRow = False


        '**Columnas Visibles

        Gv.Columns("ContadorDocumento").Visible = False
        Gv.Columns("Linea").Visible = False


        Gv.Columns("CodigoArticulo").Visible = True
        Gv.Columns("Articulo").Visible = True
        Gv.Columns("Cantidad").Visible = True
        Gv.Columns("Precio").Visible = True
        Gv.Columns("DtoPor").Visible = True

        Gv.Columns("IVAPor").Visible = False
        Gv.Columns("REPor").Visible = False
        Gv.Columns("Familia").Visible = False
        Gv.Columns("SubFamilia").Visible = False
        Gv.Columns("RetencionPor").Visible = False
        Gv.Columns("Almacen").Visible = False
        '    Gv.Columns("CodigoPropuesto").Visible = False

        '**Columnas Editables

        Gv.Columns("ContadorDocumento").OptionsColumn.AllowEdit = False
        Gv.Columns("Linea").OptionsColumn.AllowEdit = False


        Gv.Columns("CodigoArticulo").OptionsColumn.AllowEdit = True
        Gv.Columns("Articulo").OptionsColumn.AllowEdit = True
        Gv.Columns("Cantidad").OptionsColumn.AllowEdit = True
        Gv.Columns("Precio").OptionsColumn.AllowEdit = True
        Gv.Columns("DtoPor").OptionsColumn.AllowEdit = True

        Gv.Columns("IVAPor").OptionsColumn.AllowEdit = False
        Gv.Columns("REPor").OptionsColumn.AllowEdit = False
        Gv.Columns("Familia").OptionsColumn.AllowEdit = False
        Gv.Columns("SubFamilia").OptionsColumn.AllowEdit = False
        Gv.Columns("RetencionPor").OptionsColumn.AllowEdit = False
        Gv.Columns("Almacen").OptionsColumn.AllowEdit = False
        Gv.Columns("Total").OptionsColumn.AllowEdit = False
        Gv.Columns("CodigoPropuesto").OptionsColumn.AllowEdit = False
        '**Columnas Permite Foco

        Gv.Columns("ContadorDocumento").OptionsColumn.AllowFocus = False
        Gv.Columns("Linea").OptionsColumn.AllowFocus = False


        Gv.Columns("CodigoArticulo").OptionsColumn.AllowFocus = True
        Gv.Columns("Articulo").OptionsColumn.AllowFocus = True
        Gv.Columns("Cantidad").OptionsColumn.AllowFocus = True
        Gv.Columns("Precio").OptionsColumn.AllowFocus = True
        Gv.Columns("DtoPor").OptionsColumn.AllowFocus = True

        Gv.Columns("IVAPor").OptionsColumn.AllowFocus = False
        Gv.Columns("REPor").OptionsColumn.AllowFocus = False
        Gv.Columns("Familia").OptionsColumn.AllowFocus = False
        Gv.Columns("SubFamilia").OptionsColumn.AllowFocus = False
        Gv.Columns("RetencionPor").OptionsColumn.AllowFocus = False
        Gv.Columns("Almacen").OptionsColumn.AllowFocus = False
        Gv.Columns("Total").OptionsColumn.AllowFocus = False
        Gv.Columns("CodigoPropuesto").OptionsColumn.AllowFocus = False

        '**Anchos de columna

        'Gv.Columns("Nombre").Width = 150
        'Gv.Columns("NumeroVencimientos").Width = 60
        'Gv.Columns("DiasPrimerVencimiento").Width = 60
        'Gv.Columns("DiasEntreVencimiento").Width = 60
        'Gv.Columns("Agrupacion").Width = 60


        '**Formatos de Columna
        Gv.Columns("DtoPor").Caption = "% Desc."
        'Gv.Columns("IVAPor").Caption = "% IVA"
        'Gv.Columns("REPor").Caption = "% R.Eq."

        'Gv.Columns("Precio").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric


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
            Exit Sub
        End If

        Try
            DatosPersonalizacion(Gv.GetFocusedRowCellValue("Personalizado"))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Gv_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles Gv.CellValueChanged
        If e.Column.FieldName = "Personalizado" Then
            DatosPersonalizacion(e.Value)
        End If
        If e.Column.FieldName = "Grabado" Then
            DatosGrabado(e.Value)
        End If
    End Sub

    Private Sub Gv_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles Gv.InitNewRow


        Dim view As GridView = CType(sender, GridView)

        view.SetRowCellValue(e.RowHandle, view.Columns("ContadorDocumento"), ContadorDocumento)
        view.SetRowCellValue(e.RowHandle, view.Columns("Linea"), ConsultasBaseDatos.SiquienteLinea(TablaDocumentoDetalle, ContadorDocumento))
        '  view.SetRowCellValue(e.RowHandle, view.Columns("CodigoArticulo"), "")
        view.SetRowCellValue(e.RowHandle, view.Columns("Articulo"), "")
        view.SetRowCellValue(e.RowHandle, view.Columns("Cantidad"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("Precio"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("DtoPor"), spnDescuentoEsp.EditValue)
        view.SetRowCellValue(e.RowHandle, view.Columns("IVAPor"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("REPor"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("Familia"), "")
        view.SetRowCellValue(e.RowHandle, view.Columns("SubFamilia"), "")
        view.SetRowCellValue(e.RowHandle, view.Columns("RetencionPor"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("Almacen"), cmbAlmacenes.EditValue)
        view.SetRowCellValue(e.RowHandle, view.Columns("Personalizacion"), False)
        view.SetRowCellValue(e.RowHandle, view.Columns("Personalizado"), False)
        view.SetRowCellValue(e.RowHandle, view.Columns("Color"), "")
        view.SetRowCellValue(e.RowHandle, view.Columns("Relieve"), False)
        view.SetRowCellValue(e.RowHandle, view.Columns("Grabado"), False)
        view.SetRowCellValue(e.RowHandle, view.Columns("TextoGrabado"), "")
        view.SetRowCellValue(e.RowHandle, view.Columns("ColorMarca"), "")
        view.SetRowCellValue(e.RowHandle, view.Columns("CodigoPropuesto"), "")


        DatosPersonalizacion(False)
        '   view.SetRowCellValue(e.RowHandle, view.Columns("Predeterminado"), False)

    End Sub
    Private Sub DatosGrabado(Habilitado As Boolean)


        Gv.Columns("TextoGrabado").OptionsColumn.AllowEdit = Habilitado
        Gv.Columns("TextoGrabado").OptionsColumn.AllowFocus = Habilitado


        If Not Habilitado Then
            Gv.SetRowCellValue(Gv.FocusedRowHandle, Gv.Columns("TextoGrabado"), "")
        End If



    End Sub
    Private Sub DatosPersonalizacion(Habilitado As Boolean)

        Gv.Columns("Color").OptionsColumn.AllowEdit = Habilitado
        Gv.Columns("Color").OptionsColumn.AllowFocus = Habilitado

        Gv.Columns("Relieve").OptionsColumn.AllowEdit = Habilitado
        Gv.Columns("Relieve").OptionsColumn.AllowFocus = Habilitado

        Gv.Columns("Grabado").OptionsColumn.AllowEdit = Habilitado
        Gv.Columns("Grabado").OptionsColumn.AllowFocus = Habilitado

        Gv.Columns("TextoGrabado").OptionsColumn.AllowEdit = Habilitado
        Gv.Columns("TextoGrabado").OptionsColumn.AllowFocus = Habilitado

        Gv.Columns("ColorMarca").OptionsColumn.AllowEdit = Habilitado
        Gv.Columns("ColorMarca").OptionsColumn.AllowFocus = Habilitado

        If Not Habilitado Then
            Gv.SetRowCellValue(Gv.FocusedRowHandle, Gv.Columns("Color"), "")
            Gv.SetRowCellValue(Gv.FocusedRowHandle, Gv.Columns("Relieve"), False)
            Gv.SetRowCellValue(Gv.FocusedRowHandle, Gv.Columns("Grabado"), False)
            Gv.SetRowCellValue(Gv.FocusedRowHandle, Gv.Columns("TextoGrabado"), "")
            Gv.SetRowCellValue(Gv.FocusedRowHandle, Gv.Columns("ColorMarca"), "")

        End If



    End Sub
    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If Gv.FocusedRowHandle > 0 Then
            If (MessageBox.Show("¿Confirma que quiere eliminar la fila seleccionada?", "Confirmation", _
             MessageBoxButtons.YesNo) <> DialogResult.Yes) Then Return
            Gv.DeleteRow(Gv.FocusedRowHandle)
            ActualizarDatos()
        End If

    End Sub

    Private Sub dgvx_EditorKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvx.EditorKeyDown

        If (e.KeyCode = Keys.Decimal Or e.KeyCode = Keys.OemPeriod) AndAlso (Gv.FocusedColumn.FieldName = "Cantidad" Or Gv.FocusedColumn.FieldName = "Precio" Or Gv.FocusedColumn.FieldName = "DtoPor" Or Gv.FocusedColumn.FieldName = "IVAPor" Or Gv.FocusedColumn.FieldName = "REPor" Or Gv.FocusedColumn.FieldName = "RetencionPor") Then
            e.SuppressKeyPress = True
            SendKeys.Send(",")
        End If

        If e.KeyCode = Keys.Escape Then
            Gv.CancelUpdateCurrentRow()
            '      HabilitarBotonesGamas()
        End If


        If e.KeyCode = Keys.F4 AndAlso Gv.FocusedColumn.FieldName = "CodigoArticulo" Then
            Dim grid As GridControl = CType(sender, GridControl)
            Gv_KeyDown(grid.FocusedView, e)
        End If



    End Sub

    Private Sub Gv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Gv.KeyDown

        Dim view As GridView = CType(sender, GridView)

        If (e.KeyCode = Keys.Delete And e.Modifiers = Keys.Control) Then
            If (MessageBox.Show("¿Confirma que quiere eliminar la fila seleccionada?", "Confirmation", _
              MessageBoxButtons.YesNo) <> DialogResult.Yes) Then Return
            view.DeleteRow(view.FocusedRowHandle)
            ActualizarDatos()
        End If

        If e.KeyCode = Keys.F4 AndAlso view.FocusedColumn.FieldName = "CodigoArticulo" AndAlso view.IsEditing Then

            Gl_ResultadoBusqueda = ""

            Try
                Dim f As New frmBuscar(EnumResultadoBusqueda.ARTICULO)
                f.ShowDialog()
            Catch ex As Exception

            End Try


            If Gl_ResultadoBusqueda <> "" Then
                view.EditingValue = Gl_ResultadoBusqueda
                'view.SetRowCellValue(view.EditingValue, view.Columns("Codigo"), Gl_ResultadoBusqueda)
            End If
        End If
    End Sub

    Private Sub Gv_ValidatingEditor(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles Gv.ValidatingEditor

        Try

            'If Gv.FocusedColumn.FieldName = "Articulo" Then
            '    If e.Value.ToString.Length > 105 Then
            '        MensajeInformacion("La longitud del artículo no puede superar los 105 caracteres.")
            '        e.Valid = False
            '    End If
            'End If
            If Gv.FocusedColumn.FieldName = "Personalizado" Then
                If Gv.FocusedValue And Not e.Value And (Gv.GetFocusedRowCellValue("Grabado") Or Gv.GetFocusedRowCellValue("Relieve") Or Gv.GetFocusedRowCellValue("TextoGrabado") <> "" Or Gv.GetFocusedRowCellValue("Color") <> "" Or Gv.GetFocusedRowCellValue("ColorMarca") <> "") Then
                    If (MessageBox.Show("¿Confirma que quiere quitar la marca de personalizado?", "Confirmation", _
          MessageBoxButtons.YesNo) <> DialogResult.Yes) Then
                        ' e.Valid = False
                        e.Value = True
                        Gv.SetFocusedRowCellValue("Personalizado", True)
                        'e.Valid = True
                        Return
                    End If

                End If

            End If

            If Gv.FocusedColumn.FieldName = "CodigoArticulo" Then

                'Dim bd1 As New BaseDatos(1)
                'Dim dtr As SqlClient.SqlDataReader
                'Dim Sel As String = ""
                'Dim Precio As Double = 0
                'Dim PorcentajeIVA As Double = 0
                'Dim Tipo_IVA As String = ""
                'Dim Articulo As String = ""
                'Dim Familia As String = ""
                'Dim CodigoFamilia As String = ""

                'Sel = "SELECT Familia AS CodigoFamilia, Nombre,  Tipo_IVA, (SELECT Nombre FROM " & clVariables.BaseDatos1 & "Familias I WHERE  I.Codigo = A.Familia) AS Familia , (SELECT IVA FROM " & clVariables.BaseDatos1 & "Tipo_IVA I WHERE  I.Codigo = A.Tipo_IVA) AS PorcentajeIVA FROM " & clVariables.BaseDatos1 & "Articulo A WHERE UPPER(Codigo) = '" & pf_ReplaceComillas(e.Value.ToString.ToUpper) & "'"
                'dtr = bd1.ExecuteReader(Sel)

                'If dtr.HasRows Then
                '    While dtr.Read
                '        Articulo = Trim(dtr("Nombre"))

                '        '     Precio = Math.Round(dtr("Cost_Ult1"), 2)
                '        PorcentajeIVA = dtr("PorcentajeIVA")
                '        Tipo_IVA = dtr("Tipo_IVA")
                '        Familia = dtr("Familia")
                '        CodigoFamilia = dtr("CodigoFamilia")

                '    End While
                'Else
                '    MsgBox("El codigo introducido no existe")
                '    e.Valid = False
                'End If
                'dtr = Nothing

                'Dim bd_BuscaPrecio As New BaseDatos
                'Try
                '    Precio = bd_BuscaPrecio.Execute("SELECT pvp FROM  " & clVariables.BaseDatos1 & "pvp WHERE RTRIM(UPPER(Articulo)) = '" & pf_ReplaceComillas(e.Value.ToString.ToUpper) & "' AND TARIFA = '" & GL_TARIFA & "'", False)
                'Catch ex As Exception
                '    Precio = 0
                'End Try
                'Precio = Math.Round(Precio, 2)

                Dim CodigoArticuloAPasar As String = e.Value.ToString
                Dim AC As New ArticulosCampos
                AC = ConsultasBaseDatos.ObtenerDatosArticulo(CodigoArticuloAPasar)

                If AC.Articulo IsNot Nothing Then
                    Gv.SetFocusedRowCellValue("Articulo", AC.Articulo)
                    Gv.SetFocusedRowCellValue("Precio", AC.Precio)
                    Gv.SetFocusedRowCellValue("IVAPor", AC.IVAPor)
                    Gv.SetFocusedRowCellValue("Familia", AC.Familia)
                    Gv.SetFocusedRowCellValue("SubFamilia", AC.SubFamilia)
                End If




            End If






        Catch ex As Exception

        End Try




        'If (Convert.ToInt32(e.Value) < 0) Or (Convert.ToInt32(e.Value) > 1000000) Then
        '    e.Valid = False
        'End If
    End Sub
    Private Sub PonerTotales()

        txtImporte.Text = Microsoft.VisualBasic.Format(bd.ds.Tables(TablaTotales).Rows(0)("IMPORTE"), "Currency")
        txtDtoPPImporte.Text = Microsoft.VisualBasic.Format(bd.ds.Tables(TablaTotales).Rows(0)("DTOPP"), "Currency")

        txtBI.Text = Microsoft.VisualBasic.Format(bd.ds.Tables(TablaTotales).Rows(0)("BI"), "Currency")
        txtIVA.Text = Microsoft.VisualBasic.Format(bd.ds.Tables(TablaTotales).Rows(0)("IVA"), "Currency")
        txtTotal.Text = Microsoft.VisualBasic.Format(bd.ds.Tables(TablaTotales).Rows(0)("Total"), "Currency")

    End Sub
    Private Function ActualizarDatos() As Boolean

        Try
            ' Dim ValorClaveAntes As Object = Gv.GetFocusedRowCellValue(CampoBusquedas)
            ActualizarTabla(TablaDocumentoDetalle)

            TabDocumentosDetalle = New Tablas.clTablaGeneral(TablaDocumentoDetalle, " WHERE ContadorDocumento = " & ContadorDocumento)
            TabDocumentosDetalle.Datos(bd)
            dgvx.RefreshDataSource()
            '        dgvx.DataSource = bd.ds.Tables(TabDocumentosDetalle.Tabla)


            'If Not Eliminando AndAlso ValorClaveAntes IsNot Nothing Then
            '    SituarseEnGrid(Gv, ValorClaveAntes.ToString, CampoBusquedas)
            'End If
            '     HabilitarBotones()
            PonerTotales()

            Return True

        Catch ex As SqlClient.SqlException

            XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            bd.ds.Tables(TablaDocumentoDetalle).RejectChanges()
            bd.ds.Tables(TablaDocumentoDetalle).AcceptChanges()
            Return False

        End Try


    End Function
    Private Sub Gv_RowUpdated(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles Gv.RowUpdated
        '       AnadiendoOModificando = True


        'If Gv.GetFocusedRowCellValue("Personalizado") Then

        '    Gv.SetFocusedRowCellValue("CodigoPropuesto", "E")

        'End If

        ActualizarDatos()

    End Sub



#End Region



    Private Sub ucDocumentosGenerarBase_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Cargando = True
        Try
            PrimeraVez = True
            '  Cargando = True
            If ContadorDocumento = 0 Then
                ContadorDocumento = ConsultasBaseDatos.CrearDocumento(TablaDocumento)
            End If


            AparienciaGeneral()

            Dim TextoDoc As String = ""

            Select Case TablaDocumento.ToString.ToUpper


                Case GL_DocumentoPreventa
                    TablaDocumentoDetalle = GL_DocumentoPreventaDetalle
                    TextoDoc = "Preventa"


                Case GL_DocumentoPresupuesto
                    TablaDocumentoDetalle = GL_DocumentoPresupuestoDetalle
                    TextoDoc = "Presupuesto"
                    btnEnviar.ToolTip = "Enviar" & vbCrLf & "Presupuesto"

                Case GL_DocumentoPedido
                    TablaDocumentoDetalle = GL_DocumentoPedidoDetalle
                    TextoDoc = "Pedido"


                Case GL_DocumentoAlbaran
                    TablaDocumentoDetalle = GL_DocumentoAlbaranDetalle
                    TextoDoc = "Albaran"


                Case GL_DocumentoFactura
                    TablaDocumentoDetalle = GL_DocumentoFacturaDetalle
                    TextoDoc = "Factura"

            End Select

            btnEliminarDocumento.ToolTip = "Eliminar" & vbCrLf & TextoDoc
            'btnNuevoDocumento.ToolTip = "Nuevo" & vbCrLf & TextoDoc
            'btnDuplicarDocumento.ToolTip = "Duplicar" & vbCrLf & TextoDoc
            btnArticulosVendidos.Text = "Artículos" & vbCrLf & "Vendidos"
            btnArticulosVendidos.ToolTip = "Ver Artículos Vendidos"
            btnImprimir.ToolTip = "Imprimir" & vbCrLf & TextoDoc
            btnEnviar.ToolTip = "Enviar" & vbCrLf & TextoDoc

            '    AnadirBotonSalir() 

            'Select Case TablaDocumento.ToUpper
            '    Case GL_Agrupaciones, GL_Tarifas
            '        TrabajarConAgrupaciones = False

            '    Case Else
            '        TrabajarConAgrupaciones = True

            'End Select

            TabDocumentos = New Tablas.clTablaGeneral(TablaDocumento, " WHERE Contador = " & ContadorDocumento)
            bd = New BaseDatos
            TabDocumentos.Datos(bd)

            TabDocumentosDetalle = New Tablas.clTablaGeneral(TablaDocumentoDetalle, " WHERE ContadorDocumento = " & ContadorDocumento)
            TabDocumentosDetalle.Datos(bd)

            bd.LlenarDataSet("EXEC sp_TotalesDocumento '" & TablaDocumento & "' , " & ContadorDocumento, "TablaTotales")



            Dim TabColores As Tablas.clTablaGeneral
            TabColores = New Tablas.clTablaGeneral("Colores")
            TabColores.Datos(bd)

            'Dim NombreRelacion As String = "Relacion"
            'Dim TablaPrincipal As String = TabColores.Tabla
            'Dim TablaSecundaria As String = TablaDocumentoDetalle
            'Dim Campo As String = "Color"
            'bd.ds.Relations.Add(NombreRelacion, bd.ds.Tables(TablaPrincipal).Columns(Campo), bd.ds.Tables(TablaSecundaria).Columns(Campo))







            BinSrc = New BindingSource
            BinSrc.DataSource = bd.ds
            BinSrc.DataMember = TablaDocumento


            'Bindings

            'txtCodPostal.DataBindings.Add(New Binding("EditValue", BinSrc, "CodPostal", True))
            'txtDireccion.DataBindings.Add(New Binding("EditValue", BinSrc, "Direccion", True))
            'txtNIF.DataBindings.Add(New Binding("EditValue", BinSrc, "NIF", True))
            'txtPoblacion.DataBindings.Add(New Binding("EditValue", BinSrc, "Poblacion", True))
            'txtProvincia.DataBindings.Add(New Binding("EditValue", BinSrc, "Provincia", True))
            txtNumero.DataBindings.Add(New Binding("EditValue", BinSrc, "Numero", True))

            'txtEmail.DataBindings.Add(New Binding("EditValue", BinSrc, "Email", True))
            'txtNombreComercial.DataBindings.Add(New Binding("EditValue", BinSrc, "NombreComercial", True))
            'txtTelefono1.DataBindings.Add(New Binding("EditValue", BinSrc, "Telefono1", True))
            'txtTelefono2.DataBindings.Add(New Binding("EditValue", BinSrc, "Telefono2", True))
            'txtFax.DataBindings.Add(New Binding("EditValue", BinSrc, "Fax", True))
            txtObservaciones.DataBindings.Add(New Binding("EditValue", BinSrc, "Observaciones", True))

            spnDescuentoPP.DataBindings.Add(New Binding("EditValue", BinSrc, "DescuentoPP", True))
            spnDescuentoEsp.DataBindings.Add(New Binding("EditValue", BinSrc, "DescuentoEsp", True))


            mskFecha.DataBindings.Add(New Binding("EditValue", BinSrc, "Fecha", True))
            mskFechaEntrega.DataBindings.Add(New Binding("EditValue", BinSrc, "FechaEntrega", True))


            'spnRetencion.DataBindings.Add(New Binding("EditValue", BinSrc, "Retencion", True))
            'chkAplicarIVANulo.DataBindings.Add(New Binding("EditValue", BinSrc, "AplicarIVANulo", True))

            'Combos
            FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbAlmacenes, "Almacenes", "Almacen", "Almacen", , , , , , , , False)
            FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbFormasPago, "FormasPago", "FormaPago", "Nombre", , , , , , , , False)
            FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbEmpleados, "Empleados", "CodEmpleado", "Nombre", "Codigo", , , "SELECT Codigo, Nombre, NIF,Alias,Baja FROM Empleados WHERE Baja = 0 UNION SELECT Codigo, Nombre, E.NIF,Alias,Baja FROM Empleados E INNER JOIN " & TablaDocumento & " D ON E.Codigo = D.CodEmpleado WHERE D.Contador = " & ContadorDocumento & " ORDER BY Nombre", , , , False)
            FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbClientes, "Clientes", "CodCliente", "Nombre", "Codigo", , , "SELECT Codigo, Nombre, NIF,NombreComercial,Baja,VentasBloqueadas FROM Clientes  WHERE Baja = 0 AND VentasBloqueadas = 0 UNION SELECT Codigo, Nombre, C.NIF,C.NombreComercial,Baja,VentasBloqueadas FROM Clientes C INNER JOIN " & TablaDocumento & " D ON C.Codigo = D.CodCliente WHERE D.Contador = " & ContadorDocumento & " ORDER BY Nombre", "Nombre", , , False)
            FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbSeriesFacturacion, "SeriesFacturacion", "Serie", "Nombre", , , , , , , , False)

            Try
                FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbDireccionesEnvio, "DireccionesEnvio", "DireccionEnvio", "Nombre", , , , "SELECT CodigoCliente, Nombre, Direccion, Poblacion, Provincia FROM DireccionesEnvio  WHERE CodigoCliente = '" & cmbClientes.Properties.GetRowByKeyValue(cmbClientes.EditValue)("Codigo") & "'", , , , False, , , {"Codigo", "CodigoCliente"})
            Catch ex As Exception

            End Try

            '     FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbDireccionesEnvio, "DireccionesEnvio", "DireccionEnvio", "Nombre", , , , , , , , False)

            Dim col As DataColumn
            Dim dtTotal As New DataTable

            col = New DataColumn
            With col
                .DataType = System.Type.GetType("System.Decimal")
                .ColumnName = "Total"
                .Caption = "Total"
                '.Expression = "Unidades * (1- (INV * " & CDbl(txtPorcentajeUnidades.Text) & "/100))"
                'If DatosEmpresa.IVAIncluido Then
                .Expression = "Cantidad * Precio * (1-(DtoPor/100))"
                'Else
                '    .Expression = "PV * (100 + IVAPor) / 100"
                'End If
            End With
            bd.ds.Tables(TabDocumentosDetalle.Tabla).Columns.Add(col)


            dgvx.DataSource = bd.ds.Tables(TabDocumentosDetalle.Tabla)


            Dim RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
            RepositoryItemLookUpEdit1.AutoHeight = False
            RepositoryItemLookUpEdit1.DataSource = bd.ds.Tables(TabColores.Tabla)
            RepositoryItemLookUpEdit1.DisplayMember = "Color"
            RepositoryItemLookUpEdit1.Name = "RepositoryItemLookUpEdit1"
            RepositoryItemLookUpEdit1.ValueMember = "Color"

            Gv.Columns("Color").ColumnEdit = RepositoryItemLookUpEdit1
            Gv.Columns("ColorMarca").ColumnEdit = RepositoryItemLookUpEdit1
            RepositoryItemLookUpEdit1.PopulateColumns()
            RepositoryItemLookUpEdit1.Columns("Codigo").Visible = False

            PonerTotales()


            ParametrizarGrid(Gv)

            dgvx.tbCarpetaPerfiles = GL_CARPETA_PERFILES & "\" & Me.Name & "\" & TablaDocumento.ToString.ToUpper & "\" & dgvx.Name
            dgvx.ContextMenuStrip = New tbContextMenuStripComponent(dgvx.tbCarpetaPerfiles)
            '   dgvx.ContextMenuStrip.Items.Add("Copiar Perfiles", Nothing, AddressOf CopiarPerfilesDgvX)

            ConfigurarGrid()

            If EstadoOriginal <> GL_PENDIENTE And EstadoOriginal <> "" Then
                pnlDetalle.Enabled = False
                PanelDatosGenerales.Enabled = False
                PanelDatosCliente.Enabled = False
                PanelDatosObservaciones.Enabled = False
                For Each c As SimpleButton In PanelBotones.Controls
                    c.Enabled = False
                Next

                'btnNuevoDocumento.Enabled = True
                'btnDuplicarDocumento.Enabled = True
                btnEnviar.Enabled = True
                btnImprimir.Enabled = True
                btnSalir.Enabled = True
                btnRiesgo.Enabled = True
                btnArticulosVendidos.Enabled = True
            End If




            '    dgvx.RepositoryItems.Add((RepositoryItemLookUpEdit1))
            'Dim bindingSource1 As New System.Windows.Forms.BindingSource
            'bindingSource1.DataSource = bd.ds
            'bindingSource1.DataMember = TabAgrupaciones.TablaDocumento

            '    Gv.Columns.Add(ColAgrupacionAPoner)


            'HabilitarBotones()
            '      AjustarGrid()
            'InitPopupMenu()
            txtNumero.Focus()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try

        Cargando = False
    End Sub


    'Private Sub ucDocumentosGenerarBase_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.Validating

    '    e.Cancel = Not PuedoSalir()



    'End Sub


    Private Function PuedoSalir() As Boolean

        PuedoSalir = False

        Dim DocumentoBorrado As Boolean = False

        If clGenerales.Cuenta(TablaDocumentoDetalle, " WHERE ContadorDocumento = " & ContadorDocumento) = 0 Then
            ConsultasBaseDatos.ElimnarDocumento(TablaDocumento, ContadorDocumento)
            DocumentoBorrado = True
        End If

        If Not DocumentoBorrado Then

            If Microsoft.VisualBasic.Trim(txtNumero.Text) = "" Then
                MensajeError("El Número no puede estar vacío")
                Return False
            End If

            If Microsoft.VisualBasic.Trim(cmbClientes.Text) = "" Then
                MensajeError("El cliente no puede estar vacío")
                Return False
            End If


            'If BinSrc.Current("Cliente") <> cmbClientes.Text Then
            '    BinSrc.Current("Cliente") = cmbClientes.Text
            'End If

            'If BinSrc.Current("Empleado") <> cmbEmpleados.Text Then
            '    BinSrc.Current("Empleado") = cmbEmpleados.Text
            'End If


            BinSrc.EndEdit()

            If Not ActualizarTabla(TablaDocumento) Then
                Return False
            End If
        End If



        Select Case TablaDocumento.ToString.ToUpper


            Case GL_DocumentoPresupuesto
                Try
                    uListadoPresupuestos.LlenarDataGrid(True)
                Catch ex As Exception

                End Try

                uListadoPresupuestos.PanelesVisibleModoListado()

            Case GL_DocumentoPedido
                Try
                    uListadoPedidos.LlenarDataGrid(True)
                Catch ex As Exception

                End Try

                uListadoPedidos.PanelesVisibleModoListado()


            Case GL_DocumentoAlbaran
                Try
                    uListadoAlbaranes.LlenarDataGrid(True)
                Catch ex As Exception

                End Try

                uListadoAlbaranes.PanelesVisibleModoListado()


            Case GL_DocumentoFactura
                Try
                    uListadoFacturas.LlenarDataGrid(True)
                Catch ex As Exception

                End Try

                uListadoFacturas.PanelesVisibleModoListado()

        End Select





        Return True

    End Function

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Salir()
    End Sub


    Private Sub Salir()

        If Not PuedoSalir() Then
            Exit Sub
        End If

        Me.Dispose()
        'Me.ParentForm.Dispose()
    End Sub

 




    Private Sub btnArticulosVendidos_Click(sender As System.Object, e As System.EventArgs) Handles btnArticulosVendidos.Click
        If PanelArticulosVendidos IsNot Nothing AndAlso PanelArticulosVendidos.Visibility = DockVisibility.Visible Then
            PanelArticulosVendidos.Visibility = DockVisibility.Hidden
        Else
            '   PrepararPanelRiesgo()
            '  CrearPanelFlotante()
            Try
                uArticulosVendidos = New ucInmueblesPropietario
                '   uArticulosVendidos.LlenarGrid(cmbClientes.Properties.GetRowByKeyValue(cmbClientes.EditValue)("Codigo"))
                CrearPanelFlotanteNueva(DockManager1, PanelArticulosVendidos, uArticulosVendidos, 849, 350)
                PanelArticulosVendidos.Visibility = DockVisibility.Visible
                uArticulosVendidos.dgvxDatosPropietarios.Size = New Size(PanelArticulosVendidos.Width - 20, PanelArticulosVendidos.Height - 30)
            Catch ex As Exception

            End Try

        End If
    End Sub


    Private Sub Label8_Click(sender As System.Object, e As System.EventArgs)

    End Sub
    Private Sub txtCodPostal_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtCodPostal.EditValueChanged

    End Sub
    Private Sub Label7_Click(sender As System.Object, e As System.EventArgs)

    End Sub
    Private Sub txtDireccion_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtDireccion.EditValueChanged

    End Sub
    Private Sub txtPoblacion_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtPoblacion.EditValueChanged

    End Sub
    Private Sub Label3_Click(sender As System.Object, e As System.EventArgs)

    End Sub
    Private Sub txtProvincia_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtProvincia.EditValueChanged

    End Sub

    Private Sub btnRiesgo_Click(sender As System.Object, e As System.EventArgs) Handles btnRiesgo.Click

    End Sub
End Class
