



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
 
Partial Public Class ucAlarmas

    Inherits DevExpress.XtraEditors.XtraForm



    Dim Eliminando As Boolean = False
    'Dim menu As DXPopupMenu
    Public PopupMenu As DXPopupMenu
    Dim EstoyEnAlta As Boolean

    Public bd As BaseDatos
    Public WithEvents BinSrc As BindingSource
    Dim TablaMantenimiento As String = "Alarmas"
    Public Cargando As Boolean
    Dim PrimeraVez As Boolean
    Dim SentenciaSQL As String

    Dim AnadirCheckColunm As Boolean = True
    Dim CampoInicialBusqueda As String = "Referencia"

    Public Sub New()
        InitializeComponent()

    End Sub

    Private Sub ucAlarmas_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        AparienciaGeneral()
        GL_AlarmasActivo = True
        Carga()
    End Sub
    Private Sub ucAlarmas_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        If GL_AlarmasPendienteActualizacion Then
            RefrescarDatosDesdeBdAlarmas(False, True)
            GL_AlarmasPendienteActualizacion = False
        End If
    End Sub
    Private Sub Carga()
        Dim FilaSeleccionada As Integer = Gv.FocusedRowHandle
        Cargando = True
        PrimeraVez = True
        btnInmuebles.Enabled = False

        LlenarGrid2()
        'Bindings

        txtObservaciones.DataBindings.Add(New Binding("EditValue", BinSrc, "Observaciones", True))

        ParametrizarGrid(Gv)

        dgvx.tbCarpetaPerfiles = GL_CARPETA_PERFILES & "\" & Me.Name & "\" & dgvx.Name
        dgvx.ContextMenuStrip = New tbContextMenuStripComponent(dgvx.tbCarpetaPerfiles)

        ConfigurarGrid()

        If AnadirCheckColunm Then
            Try
                dgvx.tb_AnadirColumnaCheck = True


            Catch ex As Exception
            End Try
            'ColumnaCheck = New GridCheckMarksSelection(Gv)
        End If



        Cargando = False
        Try
            Gv.Focus()
            Gv.FocusedColumn = Gv.Columns(CampoInicialBusqueda)
            Gv.TopRowIndex = 0
            Gv.FocusedRowHandle = 0
        Catch
        End Try
        If FilaSeleccionada > 1 Then
            Gv.FocusedRowHandle = FilaSeleccionada - 1
        Else
            Try
                Gv.FocusedRowHandle = FilaSeleccionada + 1
            Catch ex As Exception

            End Try
        End If

    End Sub
    Public Sub LlenarGrid2()
        'Dim propietario As String = ",(SELECT Nombre FROM Propietarios P WHERE P.Contador=I.ContadorPropietario)as Propietario " & _
        '    ",(SELECT Domicilio " & GL_SQL_SUMA & "' '" & GL_SQL_SUMA & " Poblacion FROM Propietarios P WHERE P.Contador=I.ContadorPropietario)as Direccion " & _
        '    ",(SELECT Telefono1 " & GL_SQL_SUMA & "' '" & GL_SQL_SUMA & " Telefono2 " & GL_SQL_SUMA & "' '" & GL_SQL_SUMA & " Telefono3 " & GL_SQL_SUMA & "' '" & GL_SQL_SUMA & " Telefono4 " & GL_SQL_SUMA & "' '" & GL_SQL_SUMA & " TelefonoMovil FROM Propietarios P WHERE P.Contador=I.ContadorPropietario)as Telefonos " & _
        '    ",(SELECT FechaLlamada FROM Propietarios P WHERE P.Contador=I.ContadorPropietario)as FechaLlamada " & _
        '    ",(SELECT FechaNoContesta FROM Propietarios P WHERE P.Contador=I.ContadorPropietario)as FechaNoContesta "

        Dim FechaNull As String

        Select Case GL_TipoBD

            Case EnumTipoBD.SQL_SERVER

                FechaNull = "NULL"

            Case EnumTipoBD.ACCESS
                FechaNull = "''"

        End Select

        Dim SelDireccion As String = "  Direccion " & GL_SQL_SUMA & _
    Funciones.SQL_CASE({"Numero <> ''", "Numero = ''"}, {"' Num '" & GL_SQL_SUMA & "Numero", "''"}) & GL_SQL_SUMA & _
    Funciones.SQL_CASE({"Puerta <> ''", "Puerta = ''"}, {"' Pta. '" & GL_SQL_SUMA & "Puerta", "''"}) & " as Direccion"



        SentenciaSQL = "SELECT Contador,ContadorPropietario,Referencia,AlquiladoPorNosotros  ," & _
                        "(SELECT Nombre FROM Propietarios P WHERE P.Contador=I.ContadorPropietario)as Propietario ," & _
                        SelDireccion & ", " & _
                        "(SELECT Email FROM Propietarios P WHERE P.Contador=I.ContadorPropietario)as Email ," & _
                        "(SELECT Telefono1 " & GL_SQL_SUMA & "' '" & GL_SQL_SUMA & " Telefono2 " & GL_SQL_SUMA & "' '" & GL_SQL_SUMA & " Telefono3 " & GL_SQL_SUMA & "' '" & GL_SQL_SUMA & " Telefono4 " & GL_SQL_SUMA & "' '" & GL_SQL_SUMA & " TelefonoMovil FROM Propietarios P WHERE P.Contador=I.ContadorPropietario)as Telefonos ," & _
                        "(" & Funciones.SQL_CASE({"(DATEDIFF(" & GL_SQL_D & " ," & GL_SQL_GETDATE & ",FechaReservado) < 5 AND Reservado=" & GL_SQL_VALOR_1 & ")", "(DATEDIFF(" & GL_SQL_D & " ," & GL_SQL_GETDATE & ",FechaReservado) >= 0 OR Reservado=0)"}, {"'('" & GL_SQL_SUMA & " TipoVenta " & GL_SQL_SUMA & "')'", Funciones.SQL_CASE({"Reservado=" & GL_SQL_VALOR_1 & "", "Reservado=0"}, {"TipoVenta", "''"})}) & ") AS Para," & _
                        "(" & Funciones.SQL_CASE({"(DATEDIFF(" & GL_SQL_D & " ," & GL_SQL_GETDATE & ",FechaReservado) < 5 AND Reservado=" & GL_SQL_VALOR_1 & ")", "(DATEDIFF(" & GL_SQL_D & " ," & GL_SQL_GETDATE & ",FechaReservado) >= 0 OR Reservado=0)"}, {"FechaReservado", FechaNull}) & ") AS FechaVencimiento," & _
                        "(" & Funciones.SQL_CASE({"(DATEDIFF(" & GL_SQL_D & " ," & GL_SQL_GETDATE & ",FechaReservado) < 5 AND Reservado=" & GL_SQL_VALOR_1 & ")", "(DATEDIFF(" & GL_SQL_D & " ," & GL_SQL_GETDATE & ",FechaReservado) >= 0 OR Reservado=0)"}, {"1", "0"}) & ") AS Mostrar," & _
                        "(SELECT FechaLlamada FROM Propietarios P WHERE P.Contador=I.ContadorPropietario) as FechaLlamada ," & _
                        "(SELECT FechaNoContesta FROM Propietarios P WHERE P.Contador=I.ContadorPropietario) as FechaNoContesta, " & _
                        "(SELECT FechaEmail FROM Propietarios WHERE Contador =I.ContadorPropietario  ) as FechaEmail, " & _
                        "(SELECT TipoEmail FROM Propietarios WHERE Contador =I.ContadorPropietario  ) as TipoEmail, " & _
                        "(SELECT TOP 1 Observacion FROM ReservasRegistro WHERE ContadorInmueble=I.Contador ORDER BY Fecha DESC) as Observaciones " & _
                        " FROM Inmuebles I " & _
                        " where Baja = 0 AND Reservado=" & GL_SQL_VALOR_1 & " AND CodigoEmpresa=" & DatosEmpresa.Codigo '& _
        '" ORDER BY FechaVencimiento DESC "'ESTO NO FUNCIONA EN ACCESS, AÑADIDO EN CONFIGURAR GRID
        '",Observaciones " & _
        '"(SELECT TOP 1 Observaciones FROM PropietariosComunicaciones WHERE ContadorPropietario=I.ContadorPropietario AND Tipo ='EMAIL' ORDER BY Fecha DESC) as TipoEmail, " & _


        SentenciaSQL = "SELECT Contador,ContadorPropietario,Referencia,AlquiladoPorNosotros  ," &
                        "(SELECT Nombre FROM Propietarios P WHERE P.Contador=I.ContadorPropietario)as Propietario ," &
                        SelDireccion & ", " &
                        "(SELECT Email FROM Propietarios P WHERE P.Contador=I.ContadorPropietario)as Email ," &
                        "(SELECT LTRIM(rtrim(TelefonoMovil)) FROM Propietarios P WHERE P.Contador=I.ContadorPropietario) as Movil ," &
                        "(SELECT LTRIM(rtrim(Telefono1)) FROM Propietarios P WHERE P.Contador=I.ContadorPropietario) as Telefono1 ," &
                        "(SELECT LTRIM(rtrim(Telefono2)) FROM Propietarios P WHERE P.Contador=I.ContadorPropietario) as Telefono2 ," &
                        "(SELECT LTRIM(rtrim(Telefono3)) FROM Propietarios P WHERE P.Contador=I.ContadorPropietario) as Telefono3 ," &
                        "(SELECT LTRIM(rtrim(Telefono4)) FROM Propietarios P WHERE P.Contador=I.ContadorPropietario) as Telefono4 ," &
                        "(" & Funciones.SQL_CASE({"(DATEDIFF(" & GL_SQL_D & " ," & GL_SQL_GETDATE & ",FechaReservado) < 5 AND Reservado=" & GL_SQL_VALOR_1 & ")", "(DATEDIFF(" & GL_SQL_D & " ," & GL_SQL_GETDATE & ",FechaReservado) >= 0 OR Reservado=0)"}, {"'('" & GL_SQL_SUMA & " TipoVenta " & GL_SQL_SUMA & "')'", Funciones.SQL_CASE({"Reservado=" & GL_SQL_VALOR_1 & "", "Reservado=0"}, {"TipoVenta", "''"})}) & ") AS Para," &
                        "(" & Funciones.SQL_CASE({"(DATEDIFF(" & GL_SQL_D & " ," & GL_SQL_GETDATE & ",FechaReservado) < 5 AND Reservado=" & GL_SQL_VALOR_1 & ")", "(DATEDIFF(" & GL_SQL_D & " ," & GL_SQL_GETDATE & ",FechaReservado) >= 0 OR Reservado=0)"}, {"FechaReservado", FechaNull}) & ") AS FechaVencimiento," &
                        "(" & Funciones.SQL_CASE({"(DATEDIFF(" & GL_SQL_D & " ," & GL_SQL_GETDATE & ",FechaReservado) < 5 AND Reservado=" & GL_SQL_VALOR_1 & ")", "(DATEDIFF(" & GL_SQL_D & " ," & GL_SQL_GETDATE & ",FechaReservado) >= 0 OR Reservado=0)"}, {"1", "0"}) & ") AS Mostrar," &
                        "(SELECT FechaLlamada FROM Propietarios P WHERE P.Contador=I.ContadorPropietario) as FechaLlamada ," &
                        "(SELECT FechaNoContesta FROM Propietarios P WHERE P.Contador=I.ContadorPropietario) as FechaNoContesta, " &
                        "(SELECT FechaEmail FROM Propietarios WHERE Contador =I.ContadorPropietario  ) as FechaEmail, " &
                        "(SELECT TipoEmail FROM Propietarios WHERE Contador =I.ContadorPropietario  ) as TipoEmail, " &
                        "(SELECT TOP 1 Observacion FROM ReservasRegistro WHERE ContadorInmueble=I.Contador ORDER BY Fecha DESC) as Observaciones " &
                        " FROM Inmuebles I " &
                        " where Baja = 0 AND Reservado=" & GL_SQL_VALOR_1 & " AND CodigoEmpresa=" & DatosEmpresa.Codigo
        bd = New BaseDatos
        bd.LlenarDataSet(SentenciaSQL, TablaMantenimiento)


        'Dim col As New DataColumn
        'col = New DataColumn
        'With col
        '    .DataType = System.Type.GetType("System.DateTime")
        '    .ColumnName = "FechaLlamadaCopia"
        '    .Caption = "Fecha Llamada"
        'End With
        'bd.ds.Tables(TablaMantenimiento).Columns.Add(col)
        'col = New DataColumn
        'With col
        '    .DataType = System.Type.GetType("System.DateTime")
        '    .ColumnName = "FechaNoContestaCopia"
        '    .Caption = "Fecha No Contesta"
        'End With
        'bd.ds.Tables(TablaMantenimiento).Columns.Add(col)

        'For i = 0 To bd.ds.Tables(TablaMantenimiento).Rows.Count - 1
        '    bd.ds.Tables(TablaMantenimiento).Rows(i)("FechaLlamadaCopia") = bd.ds.Tables(TablaMantenimiento).Rows(i)("FechaLlamada")
        '    bd.ds.Tables(TablaMantenimiento).Rows(i)("FechaNoContestaCopia") = bd.ds.Tables(TablaMantenimiento).Rows(i)("FechaNoContesta")
        'Next


        If PrimeraVez Then
            BinSrc = New BindingSource
        End If

        BinSrc.DataSource = bd.ds
        BinSrc.DataMember = TablaMantenimiento
        BinSrc.Filter = "[Mostrar]<>0"

        'dgvx.DataSource = Nothing
        dgvx.DataSource = BinSrc

        'Gv = Nothing
        Gv = dgvx.MainView

        Try
            If Not PrimeraVez Then
                HacerCambioFila()
            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub MyGridView1_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles Gv.FocusedRowChanged

        Try

            'FocusedColor()

            HacerCambioFila()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub HacerCambioFila()
        btnInmuebles.Enabled = False
        btnLlamadasPropietarios.Enabled = False
        btnEmails.Enabled = False
        btnImprimir.Enabled = False
        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Exit Sub
        End If
        btnInmuebles.Enabled = True
        btnLlamadasPropietarios.Enabled = True
        btnEmails.Enabled = True
        btnImprimir.Enabled = True

        'LlenarObservaciones2()
    End Sub
    Private Sub ConfigurarGrid()

        If Not PrimeraVez Then
            Exit Sub
        End If

        PrimeraVez = False

        Try
            Gv.Columns("FechaVencimiento").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
        Catch ex As Exception

        End Try


        Dim condition1 As StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        condition1.Appearance.ForeColor = Color.FromArgb(70, 70, 70)
        condition1.Appearance.Options.UseForeColor = True
        condition1.Condition = FormatConditionEnum.Expression
        condition1.Expression = "[FechaVencimiento] < #" & Today.Year.ToString & "/" & Today.Month.ToString & "/" & Today.Day.ToString & "#"
        Gv.FormatConditions.Add(condition1)

        If dgvx.tbEstablecerPerfilPredeterminado() Then
            Exit Sub
        End If


        Gv.OptionsView.ShowGroupPanel = False

        Gv.OptionsView.ShowAutoFilterRow = True

        'For i = 0 To Gv.Columns.Count - 1
        '    Gv.Columns(i).Visible = False
        'Next
        Gv.Columns("Contador").OptionsColumn.AllowShowHide = False

        Gv.Columns("Contador").Visible = False
        Gv.Columns("ContadorPropietario").OptionsColumn.AllowShowHide = False

        Gv.Columns("ContadorPropietario").Visible = False
        '   Gv.Columns("FechaLlamada").Visible = False
        '   Gv.Columns("FechaNoContesta").Visible = False
        '  Gv.Columns("FechaLlamada").OptionsColumn.AllowShowHide = False
        ' Gv.Columns("FechaNoContesta").OptionsColumn.AllowShowHide = False
        Gv.Columns("Mostrar").Visible = False
        Gv.Columns("Mostrar").OptionsColumn.AllowShowHide = False

        Gv.Columns("FechaLlamada").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Gv.Columns("FechaLlamada").DisplayFormat.FormatString = "dd/MM/yy HH:mm"

        Gv.Columns("FechaNoContesta").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Gv.Columns("FechaNoContesta").DisplayFormat.FormatString = "dd/MM/yy HH:mm"

        Gv.Columns("AlquiladoPorNosotros").Caption = "Por Nosotros"


        Gv.Columns("Movil").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Gv.Columns("Telefono1").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Gv.Columns("Telefono2").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Gv.Columns("Telefono3").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Gv.Columns("Telefono4").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center


        'Gv.Columns("Referencia").Visible = True
        'Gv.Columns("FechaVencimiento").Visible = True
        'Gv.Columns("Para").Visible = True
        'Gv.Columns("Referencia").VisibleIndex = 0
        'Gv.Columns("FechaVencimiento").VisibleIndex =1
        'Gv.Columns("Para").VisibleIndex = 2

        'Gv.Columns("Propietario").Visible = True
        'Gv.Columns("Direccion").Visible = True
        'Gv.Columns("Telefonos").Visible = True
        'Gv.Columns("Propietario").VisibleIndex = 3
        'Gv.Columns("Direccion").VisibleIndex = 4
        'Gv.Columns("Telefonos").VisibleIndex = 5

        Gv.OptionsView.ShowFooter = True

        Dim ItemArticulo As GridGroupSummaryItem = New GridGroupSummaryItem()
        ItemArticulo.FieldName = "Referencia"
        ItemArticulo.DisplayFormat = "{0:n0}"
        ItemArticulo.SummaryType = DevExpress.Data.SummaryItemType.Count
        Gv.GroupSummary.Add(ItemArticulo)
        Gv.Columns("Referencia").SummaryItem.FieldName = "Contador"
        Gv.Columns("Referencia").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        Gv.Columns("Referencia").SummaryItem.DisplayFormat = "Total: {0:n0}"




    End Sub




#Region "Mantenimiento Empleados"



    Private Sub dgvxEmpleados_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvx.KeyDown

        If e.KeyCode = Keys.Escape Then

            Try


            Catch ex As Exception

            End Try

        End If
    End Sub


#End Region

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Salir()
    End Sub
    Private Sub Salir()
        GL_AlarmasActivo = False
        Me.Dispose()
        MostrarImagenDeFondo()
    End Sub

    Private Sub dgvx_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvx.DoubleClick
        LlamarInmuebles()
    End Sub

    Private Sub btnInmuebles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInmuebles.Click
        LlamarInmuebles()
    End Sub
    Private Sub LlamarInmuebles()
        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Return
        End If
        GL_AlarmasPendienteActualizacion = True
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        CargarFormulario("Inmuebles", "", True, "Alarmas", BinSrc.Current("Contador").ToString & "|" & BinSrc.Current("ContadorPropietario").ToString)
        'CargarFormulario("Inmuebles","", True, "Alarmas", 1)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub



    'Private Sub LlenarObservaciones2()
    '    txtObservaciones.Text = ""
    '    'Dim dt As DataTable
    '    'dt = ConsultasBaseDatos.ObtenerObservaciones(BinSrc.Current("Contador"), "Reservas")

    '    'If dt IsNot Nothing Then
    '    '    Dim Observaciones As String = ""
    '    '    For Each dr In dt.Rows
    '    '        If Observaciones = "" Then
    '    '            Observaciones = dr("Observacion")
    '    '        Else
    '    '            Observaciones = Observaciones & vbCrLf & dr("Observacion")
    '    '        End If
    '    '    Next
    '    '    txtObservaciones.Text = Observaciones
    '    'End If
    'End Sub

    Private Sub btnLlamadasPropietarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLlamadasPropietarios.Click

        If dgvx.ColumnaCheck.SelectedCount = 0 And (Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle) Then
            MensajeError("No ha seleccionado ningún inmueble al que llamar")
            Exit Sub
        End If

        'If ClientesEstaActivo Then
        '    If UClienteActivo.Gv.RowCount = 0 OrElse UClienteActivo.Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
        '        Return
        '    End If
        'End If
        'AlarmasEstaActivo = True
        Dim QuienMeLLama As String = Me.ParentForm.Text
        LlamadaObservacionesAlarmas(GL_OBSERVACIONES_LLAMADA)
        ''LlenarGrid(BinSrc.Current("ContadorPropietario"), "Propietarios")
        'If InmueblesEstaActivo Then
        '    uInmueblesActivo.UcInmueblesPropietario1.ActualizaCambiosPrecio()
        '    With GL_CambiosPrecios
        '        If .CambioAlquiler = "SUBE" Or .CambioVerano = "SUBE" Or .CambioVenta = "SUBE" Or .CambioTraspaso = "SUBE" Then
        '            uInmueblesActivo.CambiaValorCampoRowActual("CambioPrecio", "SUBE")
        '        ElseIf .CambioAlquiler = "BAJA" Or .CambioVerano = "BAJA" Or .CambioVenta = "BAJA" Or .CambioTraspaso = "BAJA" Then
        '            uInmueblesActivo.CambiaValorCampoRowActual("CambioPrecio", "BAJA")
        '        End If
        '    End With
        'End If
        'AlarmasEstaActivo = False
        'If Not GL_Observaciones = Gl_ResultadoBusqueda_SALIR Then
        '    If GL_RespondioALaLlamada Then
        '        CambiaValorCampoRowActual("FechaLlamadaCopia", Today)
        '    Else
        'NUEVO
        bd.Execute("UPDATE Propietarios SET FechaNoContesta= " & GL_SQL_GETDATE & " WHERE Contador=" & BinSrc.Current("ContadorPropietario"))
        bd.RefrescarDatos(, , Gv, BinSrc)
        '  bd.RefrescarDatos(BinSrc.Position)

        PonerPendienteRefrescarPropietarios()
        '    End If
        'End If
    End Sub

    Private Sub LlamadaObservacionesAlarmas(ByVal Tipo As String)

        'If Not GL_ObservacionesCambioPrecio = "" Then
        '    GL_Observaciones &= GL_ObservacionesCambioPrecio
        '    GL_ObservacionesCambioPrecio = ""
        'End If 

        Dim Observaciones As New Tablas.clComunicaciones

        Observaciones.Tipo = Tipo
        Observaciones.Tabla = GL_TablaPropietarios
        Observaciones.ContadorClientePropietarioInmueble = BinSrc.Current("ContadorPropietario")
        Observaciones.CodigoEmpresa = DatosEmpresa.Codigo
        Observaciones.ContadorEmpleado = GL_CodigoUsuario
        Observaciones.Delegacion = Gl_Delegacion
        Observaciones.Observaciones = ""
        Observaciones.ContadorInmueble = BinSrc.Current("Contador")
        Observaciones.LlamadaContestada = False
        'NUEVO
        ConsultasBaseDatos.InsertarComunicacionesObservaciones(Observaciones)
        'ProcesoAnadirObservaciones2(Observaciones)

        'ProcesoAnadirObservaciones(False, TablaClientes, BinSrc.Current("Contador"))

        'If "Propietarios" = GL_TablaPropietarios Then
        '    LlenarObservaciones(uInmueblesActivo.UcInmueblesPropietario1.txtObservaciones, BinSrc.Current("ContadorPropietario"), "Propietarios")
        'Else
        '    LlenarObservaciones(UClienteActivo.txtObservaciones, BinSrc.Current("ContadorPropietario"), "Propietarios")
        'End If
    End Sub
    Private Sub gv_RowCellStyle(ByVal sender As Object, ByVal e As RowCellStyleEventArgs) Handles Gv.RowCellStyle
        Dim View As GridView = sender
        Select Case e.Column.FieldName
            Case "FechaNoContesta"
                e.Appearance.ForeColor = Color.Red
        End Select
    End Sub

    Private Sub btnEmails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmails.Click
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
        CargarFormulario("MensajeEmail")

        Dim a() As String = Split(GL_DatosMensajePersonalizado, "|")
        If a(8) = True Then
            If SeleccionManual Then
                dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, False)
                SeleccionManual = False
            Else
                dgvx.ColumnaCheck.ClearSelection()
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
        Dim TipoEmail As String = a(11)

        Try 'situamos cartel de envio
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            pnlEnviado.Left = (PanelCajas.Width - pnlEnviado.Width) / 2
            pnlEnviado.Top = (PanelCajas.Height - pnlEnviado.Height) / 2
            pnlEnviado.Visible = True
            pnlEnviado.Enabled = True
            PanelBotones.Enabled = False
            lblxdey.Text = "1 de " & dgvx.ColumnaCheck.SelectedCount
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

        Dim AdjuntosAEviar As String = FicheroAdjunto


        'recorremos todos los inmuebles sobre los que enviaremos email a los propietarios y los introducimos dentro de una tabla con los datos de sus propietarios

        Dim inmuebles As String = ""
        For i As Integer = 0 To dgvx.ColumnaCheck.SelectedCount - 1
            If i = 0 Then
                ContadorInmuebleIncial = (TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("Contador")
            End If
            inmuebles &= Str((TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("Contador")) & ","
        Next
        inmuebles = inmuebles.Substring(0, inmuebles.Count - 1)

        SentenciaSQL = "SELECT i.Contador as ContadorInmueble,i.Referencia,p.Contador as ContadorPropietario, p.Nombre,p.Email,p.NoQuiereRecibirEmails FROM Inmuebles i INNER JOIN Propietarios p ON i.ContadorPropietario = p.Contador WHERE i.Contador IN (" & inmuebles & ")  ORDER  BY ContadorPropietario"
        Dim bdemail As New BaseDatos
        bdemail.LlenarDataSet(SentenciaSQL, "Email")

        Dim DTEmail As New DataTable
        DTEmail = bdemail.ds.Tables("Email")
        'recorremos la tabla propietario a propietario y enviamos los email correspondientes borrando lo que vamos mandando(no repetir propietario)

        ContadorPropietario = 0
        'Dim PropietariosEnviados As New List(Of Integer)
        For i As Integer = 0 To DTEmail.Rows.Count - 1
            With DTEmail.Rows(i)
                lblxdey.Text = (CuantosConMail + CuantosSinMail + CuantosNoQuieren + 1) & " de " & DTEmail.Rows.Count
                Application.DoEvents() '???

                Email = .Item("Email")
                If Debugger.IsAttached Then
                    Email = "josecifre@tresbits.es"
                End If
                Nombre = .Item("Nombre")

                If .Item("NoQuiereRecibirEmails") Then
                    CuantosNoQuieren += 1
                    PropietariosNoQuierenEmails.Add(Nombre)
                Else
                    If (Email = "" Or Not FuncionesGenerales.Funciones.validar_Mail(Email)) Then
                        CuantosSinMail += 1
                        PropietariosSinMail.Add(Nombre)
                    Else

                        If ContadorPropietario <> .Item("ContadorPropietario") Then

                            Try
                                ContadorPropietario = .Item("ContadorPropietario")
                                AdjuntosAEviar = ""
                                '    If Not PropietariosEnviados.Contains(ContadorPropietario) Then
                                'PropietariosEnviados.Add(ContadorPropietario)

                               

                               


                                Dim ResultadoEnvio As String = ""
                                'obtenemos la informacion a enviar
                                Dim AsuntoYMensaje As New Tablas.cl_AsuntoYMensaje
                                AsuntoYMensaje.Asunto = AsuntoMensaje
                                AsuntoYMensaje.Titulo = TituloMensaje
                                AsuntoYMensaje.Mensaje = MensajeMensaje & " <br><br>"



                                For ii As Integer = i To DTEmail.Rows.Count - 1
                                    If DTEmail.Rows(ii).Item("ContadorPropietario") = ContadorPropietario Then
                                        CuantosConMail += 1 'cada propietario duplicado se cuenta como un nuevo mail enviado

                                        Dim ContaInmu As Integer
                                        ContaInmu = DTEmail.Rows(ii).Item("ContadorInmueble")

                                        If AnadirDatosInmueble Then
                                            AsuntoYMensaje.Mensaje &= ConsultasBaseDatos.ObtenerMensajePropietario(DatosEmpresa.Codigo, ContaInmu, DTEmail.Rows(ii).Item("Referencia")) & vbCrLf & vbCrLf
                                        End If

                                        If IncluirFichaInmueble Then
                                            Dim listaInmuebles As String = " where (I.Contador=" & ContaInmu & ")"
                                            If AdjuntosAEviar = "" Then
                                                AdjuntosAEviar = PrepararFicheroFichaInmueble(ContaInmu, "Inmuebles", listaInmuebles)
                                            Else
                                                AdjuntosAEviar = AdjuntosAEviar & ";" & PrepararFicheroFichaInmueble(ContaInmu, "Inmuebles", listaInmuebles)
                                            End If

                                        End If
                                        'If Not TrabajoConLosInmueblesDelUcPropietarios Then
                                        '    DTEmail.Rows(ii).Item("Nombre") = ""
                                        'End If

                                    End If
                                Next




                                If AsuntoYMensaje Is Nothing Then
                                    MensajeInformacion("No se encontró información de asunto y mensaje para el envío de emails")
                                    Exit Sub
                                End If
                                If AnadirDatosEmpresa Then
                                    AsuntoYMensaje.Mensaje &= ConsultasBaseDatos.ObtenerMensajePropietario(DatosEmpresa.Codigo, 0, "", AnadirDatosEmpresa, AnadirAvisoLegal)
                                End If
                                'enviamos el email al propietario
                                ResultadoEnvio = EnviosEmailIndividual(Email, Nombre, AsuntoYMensaje, AdjuntosAEviar, True)


                                'Se llena la tabla con los datos dle envio a los propietarios correspondientes
                                If ResultadoEnvio = "" Then

                                    Dim ContaInmu As Integer

                                    '     ContaInmu = DTEmail.Rows(ii).Item("ContadorInmueble")
                                    ContaInmu = DTEmail.Rows(i).Item("ContadorInmueble")

                                    BD_CERO.Execute("UPDATE Propietarios SET FechaEmail= " & GL_SQL_GETDATE & ", TipoEmail = '" & Funciones.pf_ReplaceComillas(TipoEmail) & "' WHERE Contador=" & ContadorPropietario)

                                    Dim Sel As String
                                    Sel = "INSERT INTO PropietariosComunicaciones (CodigoEmpresa ,Delegacion, ContadorInmueble, ContadorPropietario,Fecha,ContadorEmpleado,LlamadaContestada,Observaciones,Tipo) VALUES (" & _
                                    DatosEmpresa.Codigo & "," & Gl_Delegacion & ",0," & ContadorPropietario & "," & GL_SQL_GETDATE & "," & GL_CodigoUsuario & "," & ContaInmu & " ,'" & Funciones.pf_ReplaceComillas(TipoEmail) & "', 'EMAIL'" & _
                                    ")"
                                    BD_CERO.Execute(Sel)

                                    If IncluirFichaInmueble Then
                                        BD_CERO.Execute("UPDATE Inmuebles SET EnviadaFicha =" & GL_SQL_VALOR_1 & " WHERE Contador = " & ContaInmu)
                                    End If


                                End If

                            Catch ex As Exception
                                MensajeError(ex.Message)
                            End Try
                        End If
                    End If

                End If
            End With
        Next



        PonerPendienteRefrescarPropietarios()

        Try

            If Not IsNothing(dgvx.ColumnaCheck) Then
                If Not IsNothing(dgvx.ColumnaCheck.View) Then
                    dgvx.ColumnaCheck.View = Nothing
                End If
            End If
        Catch ex As Exception

        End Try
        RefrescarDatosDesdeBdAlarmas(False)
        Try
            If dgvx.tb_AnadirColumnaCheck Then
                dgvx.AnadirColumnaCheck()
            End If

        Catch ex As Exception

        End Try

        HacerCambioFila() '???

        If SeleccionManual Then
            dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, False)
            SeleccionManual = False
        Else
            dgvx.ColumnaCheck.ClearSelection()
        End If

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
        'If dgvx.tb_AnadirColumnaCheck Then
        'dgvx.AnadirColumnaCheck()
        'End If

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


    End Sub
   

    Public Sub ActualizarGrid()
        'eliminar columna check
        dgvx.tb_AnadirColumnaCheck = False
        'copiar posicion actual

        Carga()
    End Sub
    
    Private Sub PanelBotones_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelBotones.Resize
        'MessageBox.Show("TAMAÑO: ANCHO-> " & PanelBotones.Width & " ALTO-> " & PanelBotones.Height)'NO SE PORQUE PASA PERO EL TAMAÑO TANTO DE LA BARRA COMO DE LOS BOTONES SE HACE MAS GRANDE EN INICIALICECOMPONENT()
        If PanelBotones.Height > 72 Then PanelBotones.Height = 72
    End Sub
    Private Sub btnInmuebles_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInmuebles.SizeChanged
        If btnInmuebles.Height > 63 Then btnInmuebles.Height = 63
    End Sub
    Private Sub btnEmails_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmails.SizeChanged
        If btnEmails.Height > 63 Then btnEmails.Height = 63
    End Sub
    Private Sub btnLlamadasPropietarios_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLlamadasPropietarios.SizeChanged
        If btnLlamadasPropietarios.Height > 63 Then btnLlamadasPropietarios.Height = 63
    End Sub
    Private Sub btnSalir_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.SizeChanged
        If btnSalir.Height > 63 Then btnSalir.Height = 63
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        If dgvx.ColumnaCheck.SelectedCount = 0 And (Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle) Then
            MensajeError("No ha seleccionado ningún inmueble")
            Exit Sub
        End If

        Dim SeleccionManual As Boolean = False

        frmWordReport.Location = New Point(MousePosition.X - 45, MousePosition.Y - 75)
        frmWordReport.ShowDialog()

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
       
        If dgvx.ColumnaCheck.SelectedCount = 0 Then
            dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, True)
            SeleccionManual = True
        End If
        ListadoFicha()

        If SeleccionManual Then
            dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, False)
            SeleccionManual = False
        Else
            dgvx.ColumnaCheck.ClearSelection()
        End If

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

        Dim DT As DataTable = ObtenerDT_ParaReportFichaPropietario("Inmuebles", listaInmuebles)

        For Each dr As DataRow In DT.Rows
            BD_CERO.Execute("INSERT INTO Impresiones (ContadorEmpleado, Documento, ContadorInmueble) VALUES (" & GL_CodigoUsuario & ", 'FICHA INMUEBLE'," & dr("Contador") & ")")
        Next

        Dim r As New rptFichaPropietario
        Funciones.ShowListado(r, GL_Word, DT)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow

    End Sub

    Private Sub ucAlarmas_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        uAlarmasActivo = Nothing
    End Sub

    Private Sub btnCambiarFecha_Click(sender As System.Object, e As System.EventArgs) Handles btnCambiarFecha.Click
        If dgvx.ColumnaCheck.SelectedCount = 0 And (Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle) Then
            MensajeError("No ha seleccionado ningún inmueble")
            Exit Sub
        End If

        Dim SeleccionManual As Boolean = False


        Dim stNuevaFecha As String

        stNuevaFecha = InputBox("Introduzca la nueva fecha (dd/mm/yyyy)")

        If Not IsDate(stNuevaFecha) Then
            MensajeError("El valor introducido (" & stNuevaFecha & " no es una fecha válida")
            Return
        End If

        Dim NuevaFecha As Date = CDate(stNuevaFecha)

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        If dgvx.ColumnaCheck.SelectedCount = 0 Then
            dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, True)
            SeleccionManual = True
        End If

        bd.ds.Tables(0).Columns("FechaVencimiento").ReadOnly = False

        Dim listaInmuebles As String = ""
        Dim row As DataRowView
        For I = 0 To dgvx.ColumnaCheck.SelectedCount - 1
            If dgvx.ColumnaCheck.SelectedCount >= 1 Then
                row = dgvx.ColumnaCheck.GetSelectedRow(I)
                Dim Sel As String
                Sel = "UPDATE Inmuebles SET FechaReservado = '" & Microsoft.VisualBasic.Format(NuevaFecha, "yyyyMMdd") & "' WHERE Contador = " & row.Item("Contador")
                BD_CERO.Execute(Sel)

                'Dim rows() As DataRow
                'rows = bd.ds.Tables(0).Select(" Contador = " & row.Item("Contador"))
                'rows(0).BeginEdit()
                'rows(0)("FechaReservado") = NuevaFecha
                'rows(0).EndEdit()

                bd.ds.Tables(0).Select(" Contador = " & row.Item("Contador"))(0).BeginEdit()
                bd.ds.Tables(0).Select(" Contador = " & row.Item("Contador"))(0)("FechaVencimiento") = NuevaFecha
                bd.ds.Tables(0).Select(" Contador = " & row.Item("Contador"))(0).EndEdit()
                '                bd.RefrescarDatos(BinSrc.Position)
                'Me.Validate()
            End If
        Next

        If SeleccionManual Then
            dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, False)
            SeleccionManual = False
        Else
            dgvx.ColumnaCheck.ClearSelection()
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub
End Class





