

'Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid
'Imports System
'Imports DevExpress.XtraEditors
'Imports System.Data
'Imports DevExpress.XtraEditors.Repository
'Imports DevExpress.Utils.Menu
'Imports DevExpress.XtraBars
'Imports DevExpress.LookAndFeel.Design
'Imports System.Drawing
'Imports DevExpress.Skins
Imports DevExpress.XtraGrid
Imports System.Data.SqlClient

'Imports System.Threading

'Imports DevExpress.XtraGrid.Columns
'Imports System.Data.SqlClient
'Imports DevExpress.XtraBars.Docking


Partial Public Class ucEmailMasivoClientes

    Inherits DevExpress.XtraEditors.XtraForm

    ' Dim AP As ActualizaPerfil
    Dim bd As BaseDatos
    Private WithEvents BinSrc As BindingSource
    Private PararBusqueda As Boolean
    'Private Contador As Integer = 0
    Private ContadorTotal As Integer = 1
    Public Tabla As String
    'Dim hilo1 As Thread
    'Dim hilo1 Dim Cargando As BooleanAs Thread
    Dim Cargando As Boolean

    Public Sub New()
        InitializeComponent()

    End Sub


    Private Sub ucEmailMasivoClientes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        AparienciaGeneral()

        'Dim SQL As String = "SELECT Count(*) FROM " & Tabla & " WHERE NoTieneEmail<>1 AND NoQuiereRecibirEmails<>1 AND CodigoEmpresa=" & DatosEmpresa.Codigo

        'bd = New BaseDatos
        'Try
        '    ContadorTotal = bd.Execute(SQL, False)
        'Catch
        '    ContadorTotal =1
        'End Try
        ' 'lblpercent.Text = Int((100 / ContadorTotal) * Contador) & " %"
        CargaClientes()
        ''ContadorTotal = 100 'PRUEBA
    End Sub
    Sub CargaClientes()
        'btnBuscar.Enabled = False
        'btnSalir.Enabled = False
        'btnParar.Enabled = True
        'btnBuscar.Refresh()
        'btnSalir.Refresh()
        'btnParar.Refresh()
        'pnlBuscando.Visible = True
        'PararBusqueda = False

        'Do Until PararBusqueda Or Contador > ContadorTotal
        Cargando = True
        dgvx.tb_AnadirColumnaCheck = False
        bd = New BaseDatos
        

        Dim SQL As String = "SELECT Contador,Nombre,Email,TipoVenta, NoQuiereRecibirEmails,NoQuiereRecibirSMSs" & _
                           ",(" & FuncionesBD.ObtenerReferenciasQueCuadranEnSelectCliente(, False, "Altas", "COUNT(*)") & ") AS Altas" & _
                            ",(" & FuncionesBD.ObtenerReferenciasQueCuadranEnSelectCliente(, False, "CambiosPrecios", "COUNT(*)") & ") AS CambiosPrecios" & _
                            ",(" & FuncionesBD.ObtenerReferenciasQueCuadranEnSelectCliente(, False, "ReservasQuitadas", "COUNT(*)") & ") AS ReservasQuitadas" & _
                           " FROM  " & Tabla & _
                           " C WHERE Baja = 0 AND Email <> '' AND NoTieneEmail<>1 AND NoQuiereRecibirEmails <>1 AND CodigoEmpresa=" & DatosEmpresa.Codigo & _
                           " AND (" & FuncionesBD.ObtenerReferenciasQueCuadranEnSelectCliente(, False, "Novedades", "COUNT(*)") & ") >0"
         
        bd.LlenarDataSet(SQL, Tabla, , False, True, True)
        Dim key(0) As DataColumn
        key(0) = bd.ds.Tables(Tabla).Columns("Contador")
        bd.ds.Tables(Tabla).PrimaryKey = key
        BinSrc = New BindingSource

        Dim WhereExtra As String = ""
      

        If bd.ds.Tables(Tabla).Rows.Count > 0 Then
 

            For I = bd.ds.Tables(Tabla).Rows.Count - 1 To 0 Step -1
                With bd.ds.Tables(Tabla).Rows(I)
                    If .Item("Altas") = 0 Then
                        BD_CERO.Execute("UPDATE " & Tabla & " SET FechaUltimaAlta=" & gl_sql_getdate & " WHERE Contador=" & .Item("Contador"))
                    End If
                    If .Item("CambiosPrecios") = 0 Then
                        BD_CERO.Execute("UPDATE " & Tabla & " SET FechaUltimoCambioPrecio=" & gl_sql_getdate & " WHERE Contador=" & .Item("Contador"))
                    End If
                    If .Item("ReservasQuitadas") = 0 Then
                        BD_CERO.Execute("UPDATE " & Tabla & " SET FechaUltimaReservaQuitada=" & gl_sql_getdate & " WHERE Contador=" & .Item("Contador"))
                    End If
                End With
            Next


        End If

        dgvx.BindingContext = New BindingContext()
        BinSrc.DataSource = bd.ds
        BinSrc.DataMember = Tabla
        'BinSrc.Filter = "[Altas]>0 OR [CambiosPrecios]>0 OR [ReservasQuitadas]>0"

        dgvx.DataSource = BinSrc
        ParametrizarGrid(Gv)

        ConfigurarGrid()
        dgvx.tb_AnadirColumnaCheck = True

        Cargando = False
        BinSrc.MoveFirst()

        'lblpercent.Text = Int((100 / ContadorTotal) * Contador) & " %"
        'Contador +=1
        'pnlBuscando.Refresh()
        'Try
        '    Gv.Focus()
        'Catch ex As Exception
        'End Try
        'Application.DoEvents()

        'Loop

        'btnSalir.Enabled = True
        'btnParar.Enabled = False
        'If PararBusqueda Then
        '    PararBusqueda = False
        '    btnBuscar.Enabled = True
        'Else
        '    pnlBuscando.Visible = False
        '    btnBuscar.Enabled = False
        'End If
        '  Me.ParentForm.Visible = True
    End Sub
     
    Private Sub ConfigurarGrid()

        'If Not PrimeraVez Then
        '    Exit Sub
        'End If

        'PrimeraVez = False

        Gv.Columns("Nombre").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

        If dgvx.tbEstablecerPerfilPredeterminado() Then
            Exit Sub
        End If


        Gv.OptionsView.ShowGroupPanel = False

        Gv.OptionsView.ShowAutoFilterRow = True

        Gv.Columns("Contador").OptionsColumn.AllowShowHide = False
        Gv.Columns("Contador").Visible = False
        Gv.Columns("Email").OptionsColumn.AllowShowHide = False
        Gv.Columns("Email").Visible = False
        Gv.Columns("NoQuiereRecibirEmails").OptionsColumn.AllowShowHide = False
        Gv.Columns("NoQuiereRecibirEmails").Visible = False
        Gv.Columns("NoQuiereRecibirSMSs").OptionsColumn.AllowShowHide = False
        Gv.Columns("NoQuiereRecibirSMSs").Visible = False


        Gv.BestFitColumns()

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

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Buscar()
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnParar.Click
        Parar()
    End Sub



    Private Sub Buscar()

        CargaClientes()
    End Sub
    Private Sub Parar()
        btnParar.Enabled = False
        PararBusqueda = True
    End Sub
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Salir()
    End Sub
    Private Sub Salir()
        Me.Dispose()
        'Me.ParentForm.Dispose()
    End Sub

    Private Sub GV_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles Gv.FocusedRowChanged
        Try
            HacerCambioFila()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub HacerCambioFila()
        btnEmails.Enabled = False
        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Exit Sub
        End If
        'If dgvx.ColumnaCheck.SelectedCount = 0 And Gv.SelectedRowsCount = 0 Then
        '    Exit Sub
        'End If
        btnEmails.Enabled = True


        If Cargando Then
            Exit Sub
        End If

        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Exit Sub
        End If



        Dim Sel As String
        Dim bdInmuebles As New BaseDatos


        Sel = FuncionesBD.ObtenerReferenciasQueCuadran(BinSrc.Current("Contador"), False, "Contador, Referencia, 'Alta' AS Tipo, '" & ConsultasBaseDatos.ObtenerDescripcionInmueble2(BinSrc.Current("Contador"), 0) & "' as Texto ") & _
                 " UNION ALL " & _
                 FuncionesBD.ObtenerReferenciasQueCuadran(BinSrc.Current("Contador"), False, "Contador, Referencia, 'BajaPrecio' AS Tipo, '" & ConsultasBaseDatos.ObtenerDescripcionInmueble2(BinSrc.Current("Contador"), 0) & "' as Texto ") & _
                 " UNION ALL " & _
                 FuncionesBD.ObtenerReferenciasQueCuadran(BinSrc.Current("Contador"), False, "Contador, Referencia, 'SinReserva' AS Tipo, '" & ConsultasBaseDatos.ObtenerDescripcionInmueble2(BinSrc.Current("Contador"), 0) & "' as Texto ")

        bdInmuebles.LlenarDataSet(Sel, "Inmuebles")
        dgvxInmuebles.DataSource = Nothing
        dgvxInmuebles.DataSource = bdInmuebles.ds.Tables("Inmuebles")
        GvInmuebles = New MyGridView
        GvInmuebles = dgvxInmuebles.MainView

        GvInmuebles.OptionsView.ShowGroupPanel = False
        GvInmuebles.OptionsView.ShowAutoFilterRow = False
        GvInmuebles.Columns("Contador").OptionsColumn.AllowShowHide = False
        GvInmuebles.Columns("Contador").Visible = False

        GvInmuebles.Columns("Referencia").Width = 80
        GvInmuebles.Columns("Tipo").Width = 100

    End Sub


    Private Sub HandleKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Escape Then
            btnParar.Enabled = False
            PararBusqueda = True
        End If

    End Sub

    Private Sub btnEmails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmails.Click
        EnviosDeEmailMasivo(GL_EMAIL_LISTADO_CLIENTES)
    End Sub

    Private Sub EnviosDeEmailMasivo(ByVal Tipo As String)

        If dgvx.ColumnaCheck.SelectedCount = 0 And (Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle) Then
            MensajeError("No ha seleccionado ningún cliente al que enviar email")
            Exit Sub
        End If

        If dgvx.ColumnaCheck.SelectedCount > 10 AndAlso Tipo = GL_EMAIL_LISTADO_CLIENTES Then
            If DevExpress.XtraEditors.XtraMessageBox.Show("Va en enviar " & dgvx.ColumnaCheck.SelectedCount & " emails." & vbCrLf & "Este proceso puede durar bastante tiempo" & vbCrLf & "¿Quiere continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
                Exit Sub
            End If
        End If
       

        Dim SeleccionManual As Boolean = False

        If dgvx.ColumnaCheck.SelectedCount = 0 Then
            dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, True)
            SeleccionManual = True
        End If


        Try

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            pnlBuscando.Left = (dgvx.Width - pnlBuscando.Width) / 2
            pnlBuscando.Top = (dgvx.Height - pnlBuscando.Height) / 2
            pnlBuscando.Visible = True
            pnlBuscando.Enabled = True
            PanelBotones.Enabled = False
            lblpercent.Text = "1 de " & dgvx.ColumnaCheck.SelectedCount
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
        Dim CuantosErrores As Integer = 0
        Dim ErrorEnvio As New Generic.List(Of String)

        ParaEnvioEmail = True

        Dim cont As Integer
        For i As Integer = 0 To dgvx.ColumnaCheck.SelectedCount - 1
            cont = dgvx.ColumnaCheck.GetSelectedRow(i)("Contador")
            lblpercent.Text = i + 1 & " de " & dgvx.ColumnaCheck.SelectedCount
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
                        Dim AsuntoYMensaje As Tablas.cl_AsuntoYMensaje = ConsultasBaseDatos.ObtenerAsuntoYCuerpoEmail(Tipo, DatosEmpresa.Codigo, , , ContadorCliente)
                        If AsuntoYMensaje Is Nothing Then
                            MensajeInformacion("No se encontró información de asunto y mensaje para el envío de emails del tipo seleccionado")
                            SeleccionManual = False
                            dgvx.ColumnaCheck.ClearSelection()
                            Exit Sub
                        End If
                        ResultadoEnvio = EnviosEmailIndividualClientes(Tipo, ContadorCliente, DatosEmpresa.Codigo, Email, Nombre, AsuntoYMensaje, Tabla, True)
                    End If


                    If ResultadoEnvio = "" Then
                    

                        dgvx.ColumnaCheck.GetSelectedRow(i)("Altas") = 0
                        dgvx.ColumnaCheck.GetSelectedRow(i)("CambiosPrecios") = 0
                        dgvx.ColumnaCheck.GetSelectedRow(i)("ReservasQuitadas") = 0




                        '  BinSrc.(dgvx.ColumnaCheck.GetSelectedRow(i)("Contador"))

                        Dim Tab As New Tablas.clComunicaciones

                        Tab.CodigoEmpresa = DatosEmpresa.Codigo
                        Tab.Delegacion = Gl_Delegacion
                        Tab.ContadorClientePropietarioInmueble = ContadorCliente
                        Tab.ContadorEmpleado = GL_CodigoUsuario
                        Tab.Fecha = Now
                        Tab.Contador = 0
                        Tab.ContadorInmueble = 0
                        Tab.ContadorLlamada = 0
                        Tab.Tabla = GL_TablaClientes
                        Tab.Tipo = Tipo
                        'Tab.Precio = 0

                        'Tab.CambioDePrecio = False
                        Tab.LlamadaContestada = LlamadaContestada

                        Dim TipoVenta As String = (TryCast(dgvx.ColumnaCheck.GetSelectedRow(i), DataRowView))("TipoVenta")
                        ConsultasBaseDatos.InsertarComunicacionesObservaciones(Tab)

                        bd.ds.Tables(0).Rows.Remove(bd.ds.Tables(0).Rows.Find(dgvx.ColumnaCheck.GetSelectedRow(i)("Contador")))

                    Else
                        CuantosErrores += 1
                        ErrorEnvio.Add(Nombre)
                    End If



                Catch ex As Exception
                    'MensajeError(ex.Message)
                    CuantosErrores += 1
                    ErrorEnvio.Add(Nombre)
                End Try

            End If
        Next i

        'If SeleccionManual Then
        '    dgvx.ColumnaCheck.SelectRow(Gv.FocusedRowHandle, False)
        '    SeleccionManual = False
        'Else
        '    dgvx.ColumnaCheck.ClearSelection()
        'End If

        dgvx.ColumnaCheck.ClearSelection()


        'Dim s As Object
        'Dim e As System.EventArgs
        'HacerCambioFilaBinding(s, e)

        HacerCambioFila()


        '************Esto para refrescar datos va ok. lo comento pq ahora lo que necesito es forzar cambio de fila
        'Try
        '    dgvx.ColumnaCheck.View = Nothing
        'Catch ex As Exception

        'End Try

        'Dim TopIndexAntes As Integer
        'TopIndexAntes = Gv.TopRowIndex
        ''bd.RefrescarDatos("Clientes", bd.ds)
        'Gv.TopRowIndex = TopIndexAntes
        'SituarseEnGrid(Gv, ContadorClienteIncial, "Contador")

        'Try
        '    If dgvx.tb_AnadirColumnaCheck Then
        '        dgvx.AnadirColumnaCheck()
        '    End If

        'Catch ex As Exception

        'End Try
        '************Esto para refrescar datos va ok

        Try

            pnlBuscando.Visible = False
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
        If CuantosErrores > 0 Then 'Mostramos mensaje con los errores de envio
            Dim CadenaMensaje As String = ""

            CadenaMensaje = "Hay " & CuantosErrores & " clientes de los seleccionados que ha fallado el envio."

            For Each s In ErrorEnvio
                CadenaMensaje = CadenaMensaje & vbCrLf & s.ToString
            Next
            MensajeError(CadenaMensaje)
        End If


    End Sub
    
    




End Class




