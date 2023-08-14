Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraEditors

Public Class ucClientesWeb

    Dim Cargando As Boolean
    Dim PrimeraVez As Boolean
    Public WithEvents BinSrc As BindingSource
    Dim ColorInicialBotonBajas As System.Drawing.Color

    Private Sub frmClientesWeb_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        ColorInicialBotonBajas = btnDarDeBaja.ForeColor
        PrimeraVez = True

        AparienciaGeneral()


        ParametrizarGrid(Gv)


     
        'dgvx.ForceInitialize()

        'guardamos el perfil con todas las columnas de la bbdd para luego comparar con los perfiles si existe alguna columna nueva para añadir

        'If PrimeraVez Then
        '    AP = New ActualizaPerfil(Gv)
        'End If

        Cargando = False

        

        Me.Cursor = System.Windows.Forms.Cursors.Arrow

        LlenarGrid()

        ConfigurarGrid()



        'If AnadirCheckColunm Then
        Try
            dgvx.tb_AnadirColumnaCheck = True
            '    dgvx.ColumnaCheck.View = Nothing


        Catch ex As Exception

        End Try
 


        Cargando = False

        'HabilitarBotones()
        'HabilitarDesHabilitarCajas(False)

        'PonerFocoRowFilterEnGridView(Gv, CampoInicialBusqueda)

        Try
            Gv.Focus()
            Gv.FocusedRowHandle = 1
        Catch ex As Exception

        End Try




    End Sub
    Private Sub LlenarGrid()
        Dim Ser As New WebServiceVenalia.WebServiceVenaliaClient


        Dim Res As New List(Of WebServiceVenalia.clDatosDeUsuario)


        Try

            Res = Ser.ObtenerTodosLosUsuarios("TresBits", "EE358CB6BF1683287B21B102BBC848EB")


        Catch FaultEX As ServiceModel.FaultException(Of WebServiceVenalia.clResultado)

            MessageBox.Show(FaultEX.Message)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



        If PrimeraVez Then
            BinSrc = New BindingSource
        End If
        '   
        BinSrc.DataSource = Res
        '  BinSrc.DataMember = TablaMantenimiento

        dgvx.BindingContext = New BindingContext()
        dgvx.DataSource = Nothing
        dgvx.DataSource = BinSrc

        Gv = Nothing
        Gv = dgvx.MainView


        Try
            If Not PrimeraVez Then
                HacerCambioFila()
            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub ConfigurarGrid()

        If Not PrimeraVez Then
            Exit Sub
        End If

        PrimeraVez = False



        ' Gv.OptionsView.ColumnAutoWidth = False
        Gv.OptionsView.ShowGroupPanel = False
        Gv.OptionsView.ShowAutoFilterRow = True

        'GridPasado.OptionsNavigation.EnterMoveNextColumn = True
        'GridPasado.OptionsNavigation.UseTabKey = True
        'GridPasado.OptionsView.NewItemRowPosition = NewItemRowPosition.None

        'GridPasado.OptionsBehavior.Editable = False
        'GridPasado.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        'GridPasado.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
        'GridPasado.OptionsView.ColumnAutoWidth = True



        Gv.Columns("Id").Visible = False
        Gv.Columns("FechaAltaDispositivo").Visible = False
        Gv.Columns("Pass").Visible = False
        Gv.Columns("RegistrationID").Visible = False

        Gv.Columns("Nombre").VisibleIndex = 0
        Gv.Columns("Usuario").VisibleIndex = 2
        Gv.Columns("FechaAlta").VisibleIndex = 3
        Gv.Columns("TipoAlta").VisibleIndex = 4
        Gv.Columns("APPActiva").VisibleIndex = 5
        Gv.Columns("Baja").VisibleIndex = 6

        Gv.Columns("FechaAlta").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

        Gv.BestFitColumns()
        Gv.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        Dim ItemArticulo As GridGroupSummaryItem = New GridGroupSummaryItem()
        ItemArticulo.FieldName = "Id"
        ItemArticulo.DisplayFormat = "{0:n0}"
        ItemArticulo.SummaryType = DevExpress.Data.SummaryItemType.Count
        Gv.Columns("Usuario").SummaryItem.DisplayFormat = "Clientes: {0:n0}"
        Gv.GroupSummary.Add(ItemArticulo)

        'Dim filterString As String = "Nombre LIKE '%a%'"
        'gvClientes.Columns("Nombre").FilterInfo = New Columns.ColumnFilterInfo(ColumnFilterType.Custom, Nothing, filterString)

        'gvClientes.Columns("Nombre").FilterInfo.Type.Custom()

        Gv.OptionsView.ShowFooter = True
        Gv.Columns("Usuario").SummaryItem.FieldName = "Id"
        Gv.Columns("Usuario").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        Gv.Columns("Usuario").SummaryItem.DisplayFormat = "Total: {0:n0}"

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Salir()
    End Sub

    Private Sub Salir()
        Me.Dispose()
        MostrarImagenDeFondo()
    End Sub

    Private Sub btnEnviarMensajes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviarMensajes.Click



        Dim Nombre As String = ""


        Dim TextoAEnviar As String
        Dim TieneAPP As Boolean
        Dim EsBaja As Boolean

        Dim CuantosNotificaciones As Integer = 0

        If dgvx.ColumnaCheck.SelectedCount = 0 Then
            MsgBox("Debe seleccionar algún usuario.")
            Exit Sub
        End If

        GL_TextoSMS = ""

        frmTextoAEnviarSMS.ShowDialog()

        If GL_TextoSMS = "" Then
            Exit Sub
        End If

        TextoAEnviar = GL_TextoSMS

        Dim ErrorPublicacion As New List(Of String)


        'Dim pf As ProgressForm
        'pf = ProgressForm

        'pf.StartPosition = FormStartPosition.Manual

        'Dim P As Point
        'P.X = (Screen.PrimaryScreen.WorkingArea.Width - pf.Width) / 2
        'P.Y = (Screen.PrimaryScreen.WorkingArea.Height - pf.Height) / 2
        'pf.Location = P


        'pf.ProgressControl.Maximum = dgvx.ColumnaCheck.SelectedCount
        'pf.ProgressControl.ProgressText = "Espere unos instantes ..."



        'pf.BringToFront()
        'pf.Show()

        Dim pf As New ProgressForm(dgvx.ColumnaCheck.SelectedCount, "Espere unos instantes ...")


        'Antes de hacerlo, ver lo que va a hacer
        For i As Integer = 0 To dgvx.ColumnaCheck.SelectedCount - 1

            TieneAPP = False
            EsBaja = False

            TieneAPP = dgvx.ColumnaCheck.GetSelectedRow(i).APPActiva
            EsBaja = dgvx.ColumnaCheck.GetSelectedRow(i).Baja


            If Not TieneAPP OrElse EsBaja Then
                Nombre = dgvx.ColumnaCheck.GetSelectedRow(i).Nombre

                ErrorPublicacion.Add(Nombre)
            Else

                Dim ResulEnvio As Boolean = False

                Dim ContaConsu As Integer
                ContaConsu = dgvx.ColumnaCheck.GetSelectedRow(i).Id

                Dim TextoHTML As String = FuncionesGenerales.Funciones.ObtenerTextoConLink(TextoAEnviar)
                ResulEnvio = sw_EscribirMensajeParaAPP(0, ContaConsu, TextoHTML)
                Threading.Thread.Sleep(100)

                If ResulEnvio Then
                    ResulEnvio = sw_EnviarNotificaciones(ContaConsu, "Nuevo Mensaje", "Inmobiliaria UIM", "Mensajes")
                End If

                CuantosNotificaciones = CuantosNotificaciones + 1

            End If

            'pf.ProgressControl.Value += 1
            'Application.DoEvents()
            pf.nuevoPaso()

        Next i





        Try
            pf.Close()
        Catch ex As Exception

        End Try


        Dim TextoCuantosEnviados As String = CuantosNotificaciones & " Notificaciones"

        If ErrorPublicacion.Count > 0 Then

            MsgBox("El envio de notificaciones finalizó con " & ErrorPublicacion.Count & " ERRORES." & vbCrLf & "Envios Correctos: " & TextoCuantosEnviados)

            Dim ds As New DataSet
            Dim dt2 As New DataTable("Listado")
            ds.Tables.Add(dt2)
            Dim dc1 As New DataColumn("Texto")
            dt2.Columns.Add(dc1)

            For j As Integer = 0 To ErrorPublicacion.Count - 1
                Dim dr As DataRow = dt2.NewRow
                dr("Texto") = ErrorPublicacion(j)
                dt2.Rows.Add(dr)
            Next


            ' dt2.WriteXml(My.Application.Info.DirectoryPath & "\EsquemasXML\rptListado.xml")
            'pr_InformeCrystal2008(clVariables.RutaServidor & "\Listados\rptListado.rpt", dt2, , , , "NIF's que no se han podido publicar.")

            Dim r As New rptListado

            r.DataSource = dt2
            r.DataMember = "Listado"
            r.par_Titulo.Value = "Usuarios a los que no se les pudo enviar la notificación"
            r.par_Titulo.Visible = False
            r.ShowPreview()


        Else
            MsgBox("El envio finalizó correctamente con " & TextoCuantosEnviados)
        End If




    End Sub

    Private Sub btnVerMensajes_Click(sender As System.Object, e As System.EventArgs) Handles btnVerMensajes.Click


        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            MensajeError("Debe seleccionar un registro")
            Return
        End If



        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim UsuarioSeleccionada As WebServiceVenalia.clDatosDeUsuario = Gv.GetFocusedRow

        Dim Contador As Integer = UsuarioSeleccionada.Id
        Dim Nombre As String = UsuarioSeleccionada.Nombre
        Dim APPActiva As Boolean = UsuarioSeleccionada.APPActiva

        CargarConversaciones("ucConversaciones", Contador, Nombre, APPActiva)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub

    Private Sub btnDarDeBaja_Click(sender As System.Object, e As System.EventArgs) Handles btnDarDeBaja.Click
        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            MsgBox("Debe seleccionar un registro")
            Exit Sub
        End If


        Dim UsuarioSeleccionada As WebServiceVenalia.clDatosDeUsuario = Gv.GetFocusedRow

        Dim Texto As String
        '     Texto = "¿Confirma que quiere dar de baja el registro seleccionado?"
        If UsuarioSeleccionada.Baja Then
            Texto = "¿Confirma que quiere dar de baja el registro seleccionado?"
        Else
            Texto = "¿Confirma que quiere dar de alta el registro seleccionado?"
        End If
       

        If XtraMessageBox.Show(Texto, "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
            Exit Sub
        End If

        Dim Ser As New WebServiceVenalia.WebServiceVenaliaClient

        Dim Res As New WebServiceVenalia.clResultado


        Try


            Res = Ser.DarBajaUsuario("TresBits", "EE358CB6BF1683287B21B102BBC848EB", UsuarioSeleccionada.Id, Not UsuarioSeleccionada.Baja)

            LlenarGrid()

        Catch FaultEX As ServiceModel.FaultException(Of WebServiceVenalia.clResultado)

            MessageBox.Show(FaultEX.Message)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
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
            Dim UsuarioSeleccionada As WebServiceVenalia.clDatosDeUsuario = Gv.GetFocusedRow
            If UsuarioSeleccionada.Baja Then
                btnDarDeBaja.ForeColor = Color.Red
                btnDarDeBaja.Text = "Recuperar"
                btnDarDeBaja.Image = My.Resources.DarDeAlta

            Else
                btnDarDeBaja.ForeColor = ColorInicialBotonBajas
                btnDarDeBaja.Text = "Dar de Baja"
                btnDarDeBaja.Image = My.Resources.DarDeBaja

            End If
        Catch ex As Exception

        End Try
 
    End Sub

    Private Sub MyGridView1_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles Gv.FocusedRowChanged

        Try

             
            HacerCambioFila()

        Catch ex As Exception

        End Try

    End Sub


End Class