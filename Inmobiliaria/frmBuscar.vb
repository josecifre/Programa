Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid

Public Class frmBuscar


    '*******Cosas a Modificar***************
    Dim SentenciaSQL As String ' = "SELECT DISTINCT ClienteCodigo, ClienteNombre FROM LPControl"
    Dim Tabla As String = "LPControl"
    Dim ClavePrincipal As String = "Codigo"
    Dim CampoInicialBusqueda As String = "Nombre"
    Dim OrdenInicial As String = "Nombre"  'Ejemplo "Nombre DESC"
    Dim FiltroInicial As String = ""  'Ejemplo "Nombre LIKE 'A%'"  o "CodCategoria = '2'"
    Dim TextoErrorDuplicado As String = "Trabajador ya existe" 'Error de duplicado"
    Dim CampoParaMaximo As String = "Contador"
    Dim ColumnasOcultas As New List(Of String)
    Dim NombresColumnasOcultas() As String '= {"CodCategoria", "Nombre"}
    Dim ColumnasCongeladas As New List(Of String)
    'Columnas congeladas solo se puede poner una. Ponemos Array para seguir la misma estructura
    Dim NombresColumnasCongeladas() As String '= {"Nombre"}
    Dim AnadirCheckColunm As Boolean = False 'True

    'Crear la clase correspondiente en la clase tablas
    'Modificar la funcion MostrarDatos
    'Modificar la funcion pr_AltaModificacion con los datos que corresponda
    'pf_ComprobarDatos
    'Cambiar txtNombre.Focus() por el campo donde pongamos el foco para modificar

    '    FALTA
    'Iconos en load

    '*******Cosas a Modificar***************


    Dim OrdenActual As String
    Dim FiltroActual As String
    Dim OperadorInicialTexto As String = OperadoresCadena.Comience_Por
    Dim OperadorInicialNumero As String = OperadoresNumero.Igual

    Dim bd As New BaseDatos
    Dim dw As New DataView
    Dim Filt As New clFiltrando
    Dim Alta As Boolean
    Dim Cargando As Boolean
    Dim RegistrosIniciales As Integer
    Dim NombreActual As String


    Dim BuscandoPor As Integer

    Sub New(BuscarPor As Integer)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        BuscandoPor = BuscarPor

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub frmBuscar_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        AparienciaGeneral()
        Cargando = True
        Gl_ResultadoBusqueda = ""

        Select Case BuscandoPor

            Case EnumResultadoBusqueda.TECNICO, EnumResultadoBusqueda.AUXILIAR, EnumResultadoBusqueda.CATEGORIA_OTROS
                CampoInicialBusqueda = "Nombre"
                OrdenInicial = "Nombre"
                Tabla = "Empleados"

            Case EnumResultadoBusqueda.ALMACEN
                CampoInicialBusqueda = "AlmacenNombre"
                OrdenInicial = "AlmacenNombre"
                Tabla = "LPControl"
            Case EnumResultadoBusqueda.CLIENTE
                CampoInicialBusqueda = "Nombre"
                OrdenInicial = "Nombre"
                Tabla = "Clientes"
            Case EnumResultadoBusqueda.VENDEDOR
                CampoInicialBusqueda = "Nombre"
                OrdenInicial = "Codigo"
                Tabla = "Empleados"
            Case EnumResultadoBusqueda.MARCA
                CampoInicialBusqueda = "Nombre"
                OrdenInicial = "Nombre"
                Tabla = "MARCAS"
            Case EnumResultadoBusqueda.FAMILIA
                CampoInicialBusqueda = "Nombre"
                OrdenInicial = "Nombre"
                Tabla = "FAMILIAS"
            Case EnumResultadoBusqueda.PROPIETARIO
                CampoInicialBusqueda = "Nombre"
                OrdenInicial = "Nombre"
                Tabla = "PROPIETARIOS"



        End Select
        Me.Text = Tabla

        LlenarDataGrid()
        ParametrizarGrid(Gv)
        ConfigurarGrid()
        'FormatearDataGrid(dgv)

        Cargando = False
        PonerFocoRowFilterEnGridView(Gv, CampoInicialBusqueda)


    End Sub
    
     
    Private Sub LlenarDataGrid()
        'Esto hay que quitarlos********************************
        '      clVariables.CadenaConexion = "Data Source=Portatillp\sqlexpress;Initial Catalog=Ejemplo;Integrated Security=True"
        'Esto hay que quitarlos********************************
        pf_BuscarBasesDeDatos()
        bd.LlenarDataSet(SentenciaSQL, Tabla)
        dgvx.DataSource = bd.ds.Tables(Tabla)
 
    End Sub
    Public Function pf_BuscarBasesDeDatos() As Boolean

        On Error GoTo ErrorDatos

        Dim sel As String
        Dim NombreBD As String
        Dim SelAnterior As String
        Dim Campos As String

        Select Case BuscandoPor

            Case EnumResultadoBusqueda.PROPIETARIO
                Campos = "Contador as Codigo, Nombre "
                SentenciaSQL = "SELECT DISTINCT " & Campos & " FROM Propietarios T  ORDER BY Nombre"

            Case EnumResultadoBusqueda.CLIENTE
                Campos = " Codigo, Nombre "
                SentenciaSQL = "SELECT DISTINCT " & Campos & " FROM Clientes T "

            Case EnumResultadoBusqueda.VENDEDOR
                Campos = " Codigo, Nombre "
                SentenciaSQL = "SELECT DISTINCT " & Campos & " FROM Empleados T "

            Case EnumResultadoBusqueda.ARTICULO
                Campos = " Codigo, Nombre, Familia "
                SentenciaSQL = "SELECT DISTINCT " & Campos & " FROM Articulos T "


        End Select


        Return True

ErrorDatos:
        MsgBox(Err.Description)
        pf_BuscarBasesDeDatos = False

    End Function
    Private Sub ConfigurarGrid()
        'GridPasado.OptionsNavigation.EnterMoveNextColumn = True
        'GridPasado.OptionsNavigation.UseTabKey = True
        'GridPasado.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        Gv.OptionsView.ShowGroupPanel = False
        'GridPasado.OptionsBehavior.Editable = False
        'GridPasado.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        'GridPasado.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
        'GridPasado.OptionsView.ColumnAutoWidth = True
        Gv.OptionsView.ShowAutoFilterRow = True

        With Gv
            .Columns(0).Width = 150
            .Columns(1).Width = dgvx.Width - 250
            .Columns(0).Caption = "Código"
            .Columns(1).Caption = "Nombre"

            If BuscandoPor = EnumResultadoBusqueda.ARTICULO Then
                .Columns(1).Width = .Columns(1).Width - 100
                .Columns(2).Width = 100
            End If

        End With

        If BuscandoPor = EnumResultadoBusqueda.PROPIETARIO Then
            Gv.Columns("Codigo").Visible = False
        End If


        'Gv.Columns("Baja").Visible = False
        'Gv.Columns("FuturoCliente").Visible = True
        'Gv.Columns("FechaAlta").Visible = False
        'Gv.Columns("Direccion").Visible = False
        'Gv.Columns("Pais").Visible = False
        'Gv.Columns("CodPostal").Visible = False
        'Gv.Columns("Telefono2").Visible = False
        'Gv.Columns("Fax").Visible = False

        'Gv.Columns("Email").Visible = False
        'Gv.Columns("Web").Visible = False
        'Gv.Columns("Observaciones").Visible = False
        'Gv.Columns("DescuentoCom").Visible = False
        'Gv.Columns("DescuentoEsp").Visible = False
        'Gv.Columns("DescuentoPP").Visible = False

        'Gv.Columns("AplicarIVANulo").Visible = False
        'Gv.Columns("AplicarRE").Visible = False
        'Gv.Columns("Retencion").Visible = False
        'Gv.Columns("FormaPago").Visible = False
        'Gv.Columns("DiaPagoUno").Visible = False
        'Gv.Columns("DiaPagoDos").Visible = False
        'Gv.Columns("BancoNombre").Visible = False
        'Gv.Columns("BancoCuenta").Visible = False
        'Gv.Columns("Agrupacion").Visible = False
        'Gv.Columns("Nacionalidad").Visible = False
        'Gv.Columns("Tarifa").Visible = False

        'Gv.Columns("Disponible").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        'Gv.Columns("Disponible").DisplayFormat.FormatString = "{0:n2}"


        '  Gv.Columns("FuturoCliente").Caption = "Fut."
        'gvClientes.Columns("Articulo").Width = 280
        'gvClientes.Columns("Codigo").Width = 100

        'gvClientes.Columns("Descuento").Caption = "% Desc."
        'gvClientes.Columns("DescuentoRecalculo").Caption = "% Recalc."

        'gvClientes.Columns("Precio").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric


        'gvClientes.BestFitMaxRowCount = 20
        Gv.BestFitColumns()
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
        ItemArticulo.FieldName = "Codigo"
        ItemArticulo.DisplayFormat = "{0:n0}"
        ItemArticulo.SummaryType = DevExpress.Data.SummaryItemType.Count
        Gv.GroupSummary.Add(ItemArticulo)

        'Dim filterString As String = "Nombre LIKE '%a%'"
        'gvClientes.Columns("Nombre").FilterInfo = New Columns.ColumnFilterInfo(ColumnFilterType.Custom, Nothing, filterString)



        '   gvClientes.Columns("Nombre").FilterInfo.Type.Custom()






        'gvClientes.OptionsView.ShowFooter = True
        'gvClientes.Columns("CodigoSIG").SummaryItem.FieldName = "CodigoSIG"
        'gvClientes.Columns("CodigoSIG").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        'gvClientes.Columns("CodigoSIG").SummaryItem.DisplayFormat = "Estudios: {0:n0}"

    End Sub


    Private Sub Gv_DoubleClick(sender As Object, e As System.EventArgs) Handles Gv.DoubleClick
        CargarValor()
    End Sub

    Private Sub CargarValor()
        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Exit Sub
        End If
        If Not IsDBNull(Gv.FocusedValue) Then
            Gl_ResultadoBusqueda = Gv.GetFocusedRowCellValue("Codigo")
            Salir()
        End If
    End Sub



    Private Sub dgv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Gv.KeyDown
        If e.KeyCode = Keys.Enter Then
            CargarValor()
        End If
    End Sub


    'Private Sub txtBusqueda_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBusqueda.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        CargarValor()
    '    End If

    '    'If e.KeyCode = Keys.Down Then
    '    '    dgv.Focus()
    '    'End If
    'End Sub




    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Salir()
    End Sub

    Private Sub Salir()
        Me.Dispose()
    End Sub
End Class