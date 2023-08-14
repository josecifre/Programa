Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors
Imports System
Imports System.Windows.Forms
Imports System.Data
Imports Microsoft.VisualBasic
Imports DevExpress.XtraGrid
Imports DevExpress.Skins
Imports System.Drawing
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Docking
Imports DevExpress.XtraReports.UI



Partial Public Class ucDocumentosListadoBase

    Inherits DevExpress.XtraEditors.XtraUserControl

    Dim bd As BaseDatos
    Dim TabDocumentos As Tablas.clTablaGeneral
    Dim TabDocumentosDetalle As Tablas.clTablaGeneral
    Public TablaDocumento As String
    Public TablaDocumentoDetalle As String

    Dim TrabajarConAgrupaciones As Boolean
    Dim CampoBusquedas As String
    Dim AnadiendoOModificando As Boolean = False
    Dim Eliminando As Boolean = False
    '    Dim ContadorDocumento As Integer
    Private WithEvents BinSrc As BindingSource


    Dim PanelGestionDocumental As DockPanel
    Dim uGestionDocumental As ucGestionDocumental
    Dim TablaGestionDocumental As String
    Dim CampoGestionDocumental As String


    Dim uArticulosVendidos As ucInmueblesPropietario
    Dim Cargando As Boolean
    ' Dim BarManager1 As New DevExpress.XtraBars.BarManager

    Dim PrimeraVez As Boolean

    Dim NombreDocumentoAMostrar As String

    Public Sub New(NombreTabla As String, CodigoEmpresa As Integer)

        InitializeComponent()
        PrimeraVez = True

        Cargando = True
        AparienciaGeneral()

        btnAceptarDocumento.Text = "Aceptar" & vbCrLf & "Rechazar"
        '   btnGestionDocumental.Text = "Gestión" & vbCrLf & "Documental"

        Me.Dock = DockStyle.Fill
        TablaDocumento = NombreTabla
        Me.Tag = TablaDocumento
        '    ContadorDocumento = Contador

        Select Case TablaDocumento.ToString.ToUpper


            Case GL_DocumentoPresupuesto
                TablaDocumentoDetalle = GL_DocumentoPresupuestoDetalle
                NombreDocumentoAMostrar = "Prespuestos"
            Case GL_DocumentoPedido
                TablaDocumentoDetalle = GL_DocumentoPedidoDetalle
                NombreDocumentoAMostrar = "Pedidos"
            Case GL_DocumentoAlbaran
                TablaDocumentoDetalle = GL_DocumentoAlbaranDetalle
                NombreDocumentoAMostrar = "Albaranes"
            Case GL_DocumentoFactura
                TablaDocumentoDetalle = GL_DocumentoFacturaDetalle
                NombreDocumentoAMostrar = "Facturas"

        End Select


        Dim Primer As Date
        Dim Ultimo As Date

        Primer = DateSerial(Year(Today), Month(Today), 1)
        Ultimo = DateSerial(Year(Today), Month(Today) + 1, 0)

        mskFechaDesde.DateTime = Primer
        mskFechaHasta.DateTime = Ultimo

        LlenarDataGrid()
        'Dim MiMenu As MiMenuRadial = New MiMenuRadial(dgvx)


        ParametrizarGrid(Gv, , TablaDocumento)

        dgvx.tbCarpetaPerfiles = GL_CARPETA_PERFILES & "\" & Me.Name & "\" & TablaDocumento.ToString.ToUpper & "\" & dgvx.Name
        dgvx.ContextMenuStrip = New tbContextMenuStripComponent(dgvx.tbCarpetaPerfiles)
        dgvx.ContextMenuStrip.Items.Add("Gestión Documental", Nothing, AddressOf dgvxGestDoc)


        TablaGestionDocumental = TablaDocumento
        CampoGestionDocumental = "Contador"
        uGestionDocumental = New ucGestionDocumental(NombreDocumentoAMostrar)
        CrearPanelFlotanteNueva(DockManager1, PanelGestionDocumental, uGestionDocumental, 360, 130)

        ConfigurarGrid()


        'CrearPanelFlotante()
        Cargando = False

    End Sub

    Private Sub ConfigurarGrid()


        'If PrimeraVez Then
        '    PrimeraVez = False

        If Not PrimeraVez Then
            Exit Sub
        End If

        PrimeraVez = False
        If dgvx.tbEstablecerPerfilPredeterminado() Then
            Exit Sub
        End If


        Gv.BestFitColumns()
        Gv.OptionsView.ShowAutoFilterRow = False

        Gv.Columns("Empleado").Caption = "Vendedor"
        Gv.Columns("Contador").Visible = False
        Gv.Columns("CodigoEmpresa").Visible = False
        Gv.Columns("Serie").Visible = False
        Gv.Columns("Cobrada").Visible = False
        Gv.Columns("CodEmpleado").Visible = False

        Gv.Columns("Fecha").Width = 50
        Gv.Columns("Fecha").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Gv.Columns("Fecha").DisplayFormat.FormatString = "dd/MM/yy"
        Gv.Columns("Fecha").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

        Gv.Columns("BI").Width = 75
        Gv.Columns("BI").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Gv.Columns("BI").DisplayFormat.FormatString = "{0:n2}"

        Gv.Columns("IVA").Width = 75
        Gv.Columns("IVA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Gv.Columns("IVA").DisplayFormat.FormatString = "{0:n2}"

        Gv.Columns("Total").Width = 75
        Gv.Columns("Total").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Gv.Columns("Total").DisplayFormat.FormatString = "{0:n2}"

        Gv.Columns("Numero").Width = 75
        '    Gv.Columns("Cliente").Width = 75


        'Gv.Columns("Revisadas").Caption = "Cantidad"


        '  Gv.Columns("Numero").Width = 100


        'Sumatorios en agrupaciones
        Gv.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways
        Gv.OptionsView.ShowGroupPanel = False

        Gv.OptionsView.ShowAutoFilterRow = True

        Dim ItemArticulo As GridGroupSummaryItem = New GridGroupSummaryItem()
        ItemArticulo.FieldName = "Contador"
        ItemArticulo.DisplayFormat = "Documentos: {0}"
        ItemArticulo.SummaryType = DevExpress.Data.SummaryItemType.Count
        Gv.GroupSummary.Add(ItemArticulo)

        ItemArticulo = New GridGroupSummaryItem()

        ItemArticulo.FieldName = "BI"
        ItemArticulo.DisplayFormat = "BI: {0:n2}"
        ItemArticulo.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Gv.GroupSummary.Add(ItemArticulo)

        ItemArticulo = New GridGroupSummaryItem()

        ItemArticulo.FieldName = "IVA"
        ItemArticulo.DisplayFormat = "IVA: {0:n2}"
        ItemArticulo.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Gv.GroupSummary.Add(ItemArticulo)

        ItemArticulo = New GridGroupSummaryItem()

        ItemArticulo.FieldName = "Total"
        ItemArticulo.DisplayFormat = "Total: {0:n2}"
        ItemArticulo.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Gv.GroupSummary.Add(ItemArticulo)


        'Sumatorio en el pie del grid
        Gv.OptionsView.ShowFooter = True


        Gv.Columns("Contador").SummaryItem.FieldName = "Orden"
        Gv.Columns("Numero").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        Gv.Columns("Numero").SummaryItem.DisplayFormat = "{0} Documentos"

        Gv.Columns("BI").SummaryItem.FieldName = "BI"
        Gv.Columns("BI").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Gv.Columns("BI").SummaryItem.DisplayFormat = "{0:n2}"

        Gv.Columns("IVA").SummaryItem.FieldName = "IVA"
        Gv.Columns("IVA").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Gv.Columns("IVA").SummaryItem.DisplayFormat = "{0:n2}"

        Gv.Columns("Total").SummaryItem.FieldName = "Total"
        Gv.Columns("Total").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Gv.Columns("Total").SummaryItem.DisplayFormat = "{0:n2}"


    End Sub

    Public Sub LlenarDataGrid(Optional Situarse As Boolean = False)

        Cargando = True
        Dim ContadorAnterior As Integer = -1
        If Situarse Then
            Try
                ContadorAnterior = CInt(Gv.GetFocusedRowCellValue("Contador"))
            Catch ex As Exception

            End Try

        End If

        dgvx.DataSource = Nothing

        TabDocumentos = New Tablas.clTablaGeneral(TablaDocumento, "", "EXEC sp_ListadoDocumentos '" & TablaDocumento & "' ," & DatosEmpresa.Codigo & ", '" & Format(CDate(mskFechaDesde.EditValue), "yyyyMMdd") & "', '" & Format(CDate(mskFechaHasta.EditValue), "yyyyMMdd") & "', " & GL_CodigoUsuario & ", '" & GL_TipoUsuario & "'")
        bd = New BaseDatos
        TabDocumentos.Datos(bd, TabDocumentos.ConsultaAEjecutar, , , False)
        dgvx.DataSource = bd.ds.Tables(TabDocumentos.Tabla)

        If Situarse AndAlso ContadorAnterior > 0 Then
            SituarseEnGrid(Gv, CStr(ContadorAnterior), "Contador")
        End If
        Cargando = False
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        LlenarDataGrid()
    End Sub

    Public Sub PanelesVisibleModoListado()
        pnlListado.Visible = True
        PanelBotones.Visible = True
        pnlDetallesEnListadosBase.Visible = False
    End Sub

    Private Sub PanelesVisibleModoDetalle()
        pnlListado.Visible = False
        PanelBotones.Visible = False
        pnlDetallesEnListadosBase.Visible = True
    End Sub

    Private Sub dgvx_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvx.DoubleClick

        Dim Contador As Integer = 0
        Dim Estado As String = ""

        Try
            Contador = CInt(Gv.GetFocusedRowCellValue("Contador"))
            Estado = Gv.GetFocusedRowCellValue("Estado")
        Catch ex As Exception

        End Try

        If Contador <= 0 Then
            Exit Sub
        End If


        PanelesVisibleModoDetalle()


        Dim DocumentosDetalle As ucDocumentosGenerarBase
        DocumentosDetalle = New ucDocumentosGenerarBase(TablaDocumento, Contador, Estado)
        pnlDetallesEnListadosBase.Controls.Add(DocumentosDetalle)
    End Sub

    Private Sub btnNuevoDocumento_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevoDocumento.Click
        PanelesVisibleModoDetalle()

        Dim DocumentosDetalle As ucDocumentosGenerarBase

        DocumentosDetalle = New ucDocumentosGenerarBase(TablaDocumento, 0, "")
        pnlDetallesEnListadosBase.Controls.Add(DocumentosDetalle)
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

        If PanelGestionDocumental.Visibility = DockVisibility.Visible Then
            uGestionDocumental.RefrescarBotones(Gv.GetFocusedRowCellValue(CampoGestionDocumental).ToString, TablaGestionDocumental)
        End If

        'Dim Contador As Integer = 0

        'Try
        '    Contador = CInt(Gv.GetFocusedRowCellValue("Contador"))

        'Catch ex As Exception
        '    '        Exit Sub
        'End Try

        'uGestionDoc.RefrescarBotones(CStr(Contador), TablaDocumento)
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.ParentForm.Dispose()
    End Sub

    Private Sub btnMesSiguiente_Click(sender As System.Object, e As System.EventArgs) Handles btnMesSiguiente.Click
        Dim Primer As Date
        Dim Ultimo As Date
        Primer = DateSerial(Year(mskFechaDesde.Text), Month(mskFechaDesde.Text) + 1, 1)
        Ultimo = DateSerial(Year(mskFechaDesde.Text), Month(mskFechaDesde.Text) + 2, 0)
        mskFechaDesde.DateTime = Primer
        mskFechaHasta.DateTime = Ultimo
        LlenarDataGrid()

    End Sub
    Private Sub btnMesAnterior_Click(sender As System.Object, e As System.EventArgs) Handles btnMesAnterior.Click

        Dim Primer As Date
        Dim Ultimo As Date
        Primer = DateSerial(Year(mskFechaDesde.Text), Month(mskFechaDesde.Text) - 1, 1)
        Ultimo = DateSerial(Year(mskFechaDesde.Text), Month(mskFechaDesde.Text) + 0, 0)

        mskFechaDesde.DateTime = Primer
        mskFechaHasta.DateTime = Ultimo

        LlenarDataGrid()

    End Sub

    Private Sub btnDuplicarDocumento_Click(sender As System.Object, e As System.EventArgs) Handles btnDuplicarDocumento.Click

        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Exit Sub
        End If
        If DevExpress.XtraEditors.XtraMessageBox.Show("Confirma que quiere duplicar el documento seleccionado?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Dim Contador As Integer = 0

        Try
            Contador = CInt(Gv.GetFocusedRowCellValue("Contador"))
            ConsultasBaseDatos.DuplicarDocumento(Contador, TablaDocumento, TablaDocumento)
            LlenarDataGrid(True)
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

            uGestionDocumental.RefrescarBotones(Gv.GetFocusedRowCellValue(CampoGestionDocumental).ToString, TablaGestionDocumental)
        End If
    End Sub
    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click

        '    Dim DT As DataTable
        'Dim NombreReport As String = "rptNOK.rpt"

        'Dim dwListado As New DataView
        'dwListado = Gv.DataSource

        'Dim FiltroInicial As String = dwListado.RowFilter
        'Dim OrdenInicial As String = dwListado.Sort

        'Dim op As DevExpress.Data.Filtering.CriteriaOperator = Gv.ActiveFilterCriteria 'filterControl1.FilterCriteria
        'Dim filterString As String = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op)
        'dwListado.RowFilter = filterString

        'Dim so As DevExpress.XtraGrid.Columns.GridColumnSortInfoCollection
        'so = Gv.SortInfo
        'Try
        '    dwListado.Sort = so.Item(0).Column.FieldName
        'Catch ex As Exception

        'End Try

        'DT = dwListado.ToTable


        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Exit Sub
        End If

        ''PARA CREAR ESQUEMAS. NO TOCAR
        Dim bdReport As New BaseDatos
        bdReport.LlenarDataSet("SELECT * FROM rptPresupuesto WHERE Contador = " & Gv.GetFocusedRowCellValue("Contador"), "DocumentoCabecera")
        bdReport.LlenarDataSet("SELECT * FROM DocumentoPresupuestoDetalle WHERE ContadorDocumento = " & Gv.GetFocusedRowCellValue("Contador"), "DocumentoDetalle")

        Dim NombreRelacion As String = "Relacion"
        Dim TablaPrincipal As String = "DocumentoCabecera"
        Dim TablaSecundaria As String = "DocumentoDetalle"
        Dim CampoPrincipal As String = "Contador"
        Dim CampoPrincipalSecundario As String = "ContadorDocumento"
        bdReport.ds.Relations.Add(NombreRelacion, bdReport.ds.Tables(TablaPrincipal).Columns(CampoPrincipal), bdReport.ds.Tables(TablaSecundaria).Columns(CampoPrincipalSecundario))



        'bdReport.ds.WriteXmlSchema(My.Application.Info.DirectoryPath & "\EsquemasXML\rptDocumentoCabecera.xsd")
        'bdReport.ds.WriteXml(My.Application.Info.DirectoryPath & "\EsquemasXML\rptDocumentoCabecera.xml")
        ' ''FIN PARA CREAR ESQUEMAS. NO TOCAR


        Dim report As New rtpDocumentoPrespuesto
        report.DataSource = bdReport.ds
        report.ShowPreviewDialog()

        ''   pr_InformeCrystal2008(clVariables.RutaServidor & "\Listados\" & NombreReport, DT)
        'Dim printTool As New ReportPrintTool(New rptPresupuesto())

        'printTool.Report.CreateDocument(False)

        'AddHandler printTool.PreviewForm.Load, AddressOf PreviewForm_Load
        'printTool.ShowPreviewDialog()


    End Sub

   
End Class
