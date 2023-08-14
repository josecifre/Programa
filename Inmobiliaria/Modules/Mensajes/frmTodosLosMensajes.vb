Imports DevExpress.XtraGrid.Views.Grid

Public Class frmTodosLosMensajes


    '*******Cosas a Modificar***************
    Dim SentenciaSQL As String = "SELECT Contador, Fecha,ContadorEmisor,ContadorReceptor" & _
                  " ,CASE ContadorEmisor WHEN 0 THEN 'consumolab' ELSE (SELECT Nombre FROM Consumidores C WHERE C.Contador = M.ContadorEmisor) END AS Emisor" & _
                  " ,CASE ContadorReceptor WHEN 0 THEN 'consumolab' ELSE (SELECT Nombre FROM Consumidores C WHERE C.Contador = M.ContadorReceptor) END AS Receptor" & _
                  " , convert (datetime ,FechaCadena " & GL_SQL_SUMA & "' '" & GL_SQL_SUMA & " HoraCadena)  as FechaEnvio, Mensaje" & _
                  " , CONVERT (BIT, " & Funciones.SQL_CASE({"FechaLectura IS NULL", "FechaLectura IS NOT NULL"}, {"0", "1"}) & ") AS Leido" & _
                  " , CONVERT (BIT, " & Funciones.SQL_CASE({"UsuarioContesta = ''", "UsuarioContesta <> ''"}, {"0", "1"}) & ") AS Respondido" & _
                  " ,UsuarioContesta as Usuario,FechaContestacion FROM MensajesAPP  M"

    Dim Tabla As String = "MensajesAPP"
    Dim ClavePrincipal As String = "Contador"
    Dim CampoInicialBusqueda As String = "Emisor"
    Dim OrdenInicial As String = "Fecha DESC"  'Ejemplo "Especialidad DESC"
    Dim FiltroInicial As String = ""  'Ejemplo "Especialidad LIKE 'A%'"  o "CodCategoria = '2'"
    Dim TextoErrorDuplicado As String = "Valor duplicado." 'Error de duplicado"
    Dim CampoParaMaximo As String '= "Contador"
    ' Dim Tab As New Tablas.clEspecialidad
    Dim ColumnasOcultas As New List(Of String)
    Dim NombresColumnasOcultas() As String '= {"CodCategoria", "Especialidad"}
    Dim ColumnasCongeladas As New List(Of String)
    'Columnas congeladas solo se puede poner una. Ponemos Array para seguir la misma estructura
    Dim NombresColumnasCongeladas() As String '= {"Especialidad"}
    Dim AnadirCheckColunm As Boolean = False
    Dim GridPrincipal As GridView
    Dim ColumnaCheck As GridCheckMarksSelection
    'Crear la clase correspondiente en la clase tablas
    'Modificar la funcion MostrarDatos
    'Modificar la funcion pr_AltaModificacion con los datos que corresponda
    'pf_ComprobarDatos
    'Cambiar txtNombre.Focus() por el campo donde pongamos el foco para modificar

    '    FALTA
    'Iconos en load

    '*******Cosas a Modificar***************
    Dim PrimeraVez As Boolean

    Dim OrdenActual As String
    Dim FiltroActual As String
    Dim OperadorInicialTexto As String = OperadoresCadena.Contenga
    Dim OperadorInicialNumero As String = OperadoresNumero.Igual

    Dim bd As New BaseDatos
    Dim dw As New DataView
    Dim Filt As New clFiltrando
    Dim Alta As Boolean
    Dim Cargando As Boolean
    Dim RegistrosIniciales As Integer
    Dim AP As ActualizaPerfil
    Private Sub pr_MostrarDatos()

        If Cargando Then
            Exit Sub
        End If

        If GridPrincipal.RowCount = 0 Then
            Exit Sub
        End If

        If GridPrincipal.FocusedRowHandle < 0 Then
            '   MsgBox("Debe seleccionar un registro")
            Exit Sub
        End If




        txtNombre.Text = GridPrincipal.GetDataRow(GridPrincipal.FocusedRowHandle).Item("Mensaje")
       
       

 

    End Sub
     
  
    Private Sub Mantenimiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DevExpress.Utils.AppearanceObject.DefaultFont = New Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold)



        PintarIconos(Me)
        Me.Text = Tabla

        Cargando = True

        PrimeraVez = True

        LlenarDataGrid()



        'Me.Width = 865
        'Me.Height = 705
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Top = 0
        Me.Left = 0
        Me.WindowState = FormWindowState.Normal
        ' dgv.lpSituarseEnlaFila()
        Cargando = False


        pr_MostrarDatos()

        PonerFocoRowFilterEnGridView(GridPrincipal, "Emisor")
    End Sub
  
    Private Sub LlenarDataGrid(Optional ByVal MostrarTodasLasColumnas As Boolean = False)

        Cargando = True 

        bd = New BaseDatos
        bd.LlenarDataSet(SentenciaSQL, Tabla)

        dw = New DataView

        dw.AllowDelete = False
        dw.AllowEdit = False
        dw.AllowNew = False
        'dgv.AllowUserToResizeColumns = True
        'dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        '   dgv.MultiSelect = False

        If Cargando Then
            OrdenActual = OrdenInicial
            FiltroActual = FiltroInicial
        Else
            OrdenActual = dw.Sort
            FiltroActual = dw.RowFilter
        End If

        dw.Table = bd.ds.Tables(Tabla)
        dw.RowFilter = FiltroActual
        dw.Sort = OrdenActual
        '    dgvx = New lpGridControlDevExpress.MyGridControl

        dgvx.DataSource = Nothing
        dgvx.MainView = Nothing
        dgvx.DataSource = dw



        'dgvx.ForceInitialize()


        GridPrincipal = Nothing
        GridPrincipal = New GridView
        GridPrincipal = dgvx.MainView
        '  GridPrincipal.OptionsBehavior.Editable = True
        GridPrincipal.OptionsView.ColumnAutoWidth = True
        'FormatearGrids(GridPrincipal, 10)
        'GridPrincipal.BestFitMaxRowCount = 20
        GridPrincipal.BestFitColumns()

        'guardamos el perfil con todas las columnas de la bbdd para luego comparar con los perfiles si existe alguna columna nueva para añadir
        If PrimeraVez Then
            AP = New ActualizaPerfil(GridPrincipal)
            PrimeraVez = False
        End If

     

            'GridPrincipal.ShowButtonMode = Views.Base.ShowButtonModeEnum.ShowAlways
            '     GridPrincipal.ShowFindPanel()
            'Sumatorio en el pie del grid
            GridPrincipal.FooterPanelHeight = 20

            GridPrincipal.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always

            'Sumatorios en agrupaciones
            '  GridPrincipal.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways

        '  Dim ItemArticulo As GridGroupSummaryItem = New GridGroupSummaryItem()


            

            GridPrincipal.OptionsView.ShowFooter = True
        GridPrincipal.Columns("Mensaje").SummaryItem.FieldName = "Contador"
        GridPrincipal.Columns("Mensaje").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridPrincipal.Columns("Mensaje").SummaryItem.DisplayFormat = "Mensajes: {0:n0}"

         

            AjustarGrid()

            OcultarCongelarColumnasDevExpress(ColumnasOcultas, NombresColumnasOcultas, GridPrincipal, Accion.Ocular)
            OcultarCongelarColumnasDevExpress(ColumnasCongeladas, NombresColumnasCongeladas, GridPrincipal, Accion.Congelar)

            'If AnadirCheckColunm Then

            '    ColumnaCheck.View = Nothing
            '    ColumnaCheck = New GridCheckMarksSelection(GridPrincipal)
            'End If



        If AnadirCheckColunm Then
            Try
                ColumnaCheck.View = Nothing
            Catch ex As Exception

            End Try

            ColumnaCheck = New GridCheckMarksSelection(GridPrincipal)


        End If


        Cargando = False
        'If AnadirCheckColunm Then
        ' ColumnaCheck.View = Nothing
        '    ColumnaCheck = New GridCheckMarksSelection()

        '    ColumnaCheck = New GridCheckMarksSelection(GridPrincipal)
        'End If

    End Sub
     
 
    Private Sub AjustarGrid()
        'ajustar los anchos de las columnas
        'GridPrincipal.Columns("Nombre").Width = 450
        'GridPrincipal.Columns("NIF").Width = 120
        'GridPrincipal.Columns("Sexo").Width = 100
        'GridPrincipal.Columns("FechaDeNacimiento").Width = 120
        'GridPrincipal.Columns("Poblacion").Width = 230
        'GridPrincipal.Columns("Hijos").Width = 50
        'GridPrincipal.Columns("BloqueoTemporal").Width = 150
        'GridPrincipal.Columns("Baja").Width = 60

        ''Nombre de las columas del grid
        'GridPrincipal.Columns("FechaDeNacimiento").Caption = "F. Nacimiento"
        'GridPrincipal.Columns("BloqueoTemporal").DisplayFormat.FormatString = "B. Temporal"


        GridPrincipal.Columns("ContadorEmisor").Visible = False
        GridPrincipal.Columns("ContadorReceptor").Visible = False
        GridPrincipal.Columns("Leido").Visible = False
        GridPrincipal.Columns("Contador").Visible = False
        GridPrincipal.Columns("Fecha").Visible = False
        GridPrincipal.Columns("Fecha").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        GridPrincipal.Columns("Fecha").DisplayFormat.FormatString = "dd/MM/yy HH:mm"

        ' GridPrincipal.Columns("FechaEnvio").Visible = False
        GridPrincipal.Columns("FechaEnvio").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        GridPrincipal.Columns("FechaEnvio").DisplayFormat.FormatString = "dd/MM/yy HH:mm"


    End Sub

     
    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If Filt.Filtrando Then
            PoPMenuFiltrarSinFiltro.Enabled = True
        Else
            PoPMenuFiltrarSinFiltro.Enabled = False
        End If
    End Sub
     
    Private Sub Salir()

        Me.Dispose()
    End Sub
   
 Private Sub MyGridView1_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles MyGridView1.FocusedRowChanged
        pr_MostrarDatos()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Salir()
    End Sub


    Private Sub btnConversacion_Click(sender As System.Object, e As System.EventArgs) Handles btnConversacion.Click

        If GridPrincipal.FocusedRowHandle < 0 Then
            MsgBox("No ha marcado ningún mensaje")
            Exit Sub
        End If


        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Dim Contador As Integer
        Dim Nombre As String


        If GridPrincipal.GetDataRow(GridPrincipal.FocusedRowHandle).Item("Receptor") = "consumolab" Then
            Contador = GridPrincipal.GetDataRow(GridPrincipal.FocusedRowHandle).Item("ContadorEmisor")
            Nombre = GridPrincipal.GetDataRow(GridPrincipal.FocusedRowHandle).Item("Emisor")
        Else
            Contador = GridPrincipal.GetDataRow(GridPrincipal.FocusedRowHandle).Item("ContadorReceptor")
            Nombre = GridPrincipal.GetDataRow(GridPrincipal.FocusedRowHandle).Item("Receptor")
        End If

      
        '  CargarConversaciones("ucConversaciones", Contador, Nombre)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub

End Class
