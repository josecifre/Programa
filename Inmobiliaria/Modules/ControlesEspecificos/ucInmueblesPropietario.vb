Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports Venalia.ControlesTB
Imports FuncionesGenerales.Funciones



Public Class ucInmueblesPropietario

    Public Event dgvxDatosPropietariosDoubleClick As EventHandler
    Public WithEvents BinSrc As BindingSource
    Public bd As BaseDatos

    ' Private p_ContadorPropietario As Integer
    Private p_Titulo As String
    Private p_Propietario As cl_Propietarios
    Private InmoProp As New Tablas.clInmueblesPropietario
    Private PrimeraVezInmuebles As Boolean
    Private PrimeraVezLlamadas As Boolean
    Dim MenuGrid As tbContextMenuStripComponent
    Dim TablaMantenimiento As String = "Propietarios"

    Public Sub New()
        InitializeComponent()

        PrimeraVezInmuebles = True
        PrimeraVezLlamadas = True

        UcComunicacionesDetalle1.Gv.OptionsView.ShowAutoFilterRow = False
        UcComunicacionesDetalle1.Gv.OptionsView.ShowGroupPanel = False
        'UcComunicacionesDetalle1.btnSoloLlamadas.Visible = False
        'UcComunicacionesDetalle1.dgvx.Dock = DockStyle.Fill

    End Sub


    Public Sub LlenarGridInmuebles()


        If txtCodPropietario.Text = "" Then
            dgvxDatosPropietarios.DataSource = Nothing
            Exit Sub
        End If

        ',(SELECT TOP 1 r.Observaciones FROM Reservas r WHERE r.ContadorInmueble=I.Contador ORDER BY Fecha DESC) as ObservacionesReservas
        Dim SentenciaSQL As String = "SELECT Direccion " & GL_SQL_SUMA & _
            Funciones.SQL_CASE({"Numero <> ''", "Numero = ''"}, {"' Num '" & GL_SQL_SUMA & "Numero", "''"}) & GL_SQL_SUMA & _
            Funciones.SQL_CASE({"Puerta <> ''", "Puerta = ''"}, {"' Pta. '" & GL_SQL_SUMA & "Puerta", "''"}) & " as DireccionCompleta ,ContadorPropietario, Reservado , Contador, Referencia, FechaAlta, FotosPc, FotosWeb, Direccion, Poblacion, Metros, TipoVenta,PrecioPropietario  AS Precio  , FechaReservado , Tipo, Altura, Zona,   Baja" & _
                           " FROM Inmuebles I" & _
        " WHERE ContadorPropietario =" & txtCodPropietario.Text & " ORDER BY Baja, Reservado, Referencia DESC"
        



        '**********
        bd = New BaseDatos
        bd.LlenarDataSet(SentenciaSQL, TablaMantenimiento, , False, True)



        If PrimeraVezInmuebles Then
            BinSrc = New BindingSource
        End If

        BinSrc.DataSource = bd.ds
        BinSrc.DataMember = TablaMantenimiento

        'BinSrc.DataSource = uInmueblesActivo.bd.ds.Tables("Inmuebles")
        'BinSrc.Filter() = "ContadorPropietario = " & txtCodPropietario.Text

        dgvxDatosPropietarios.BindingContext = New BindingContext()
        dgvxDatosPropietarios.DataSource = Nothing
        dgvxDatosPropietarios.DataSource = BinSrc

        '    Gv = New MyGridView
        Gv = Nothing
        Gv = dgvxDatosPropietarios.MainView

        'MyGridControl1.DataSource = BinSrc
        'MyGridView1 = MyGridControl1.MainView

        dgvxDatosPropietarios.ForceInitialize()

        Dim AP As ActualizaPerfil
        If PrimeraVezInmuebles Then
            AP = New ActualizaPerfil(Gv)
        End If
        '***************

        ParametrizarGrid(Gv)

        dgvxDatosPropietarios.tbCarpetaPerfiles = GL_CARPETA_PERFILES & "\" & Me.Name & "\" & dgvxDatosPropietarios.Name

        MenuGrid = New tbContextMenuStripComponent(dgvxDatosPropietarios.tbCarpetaPerfiles)
        dgvxDatosPropietarios.ContextMenuStrip = MenuGrid

        MenuGrid.PopMenuEscaparate.Visible = True
        MenuGrid.PopMenuMapa.Visible = True
        MenuGrid.PopMenuReserva.Visible = True
        MenuGrid.Parentt = "Propietarios"
        ConfigurarGridInmuebles()

        'Funciones.SetSelectionAppearance(Gv, False)










        'Dim bd As New BaseDatos
        'bd.LlenarDataSet(Sel, Tabla)

        'dgvxDatosPropietarios.DataSource = Nothing

        'dgvxDatosPropietarios.DataSource = bd.ds.Tables(Tabla)
        'dgvxDatosPropietarios.ForceInitialize()

        'ParametrizarGrid(Gv)

        'dgvxDatosPropietarios.tbCarpetaPerfiles = GL_CARPETA_PERFILES & "\" & Me.Name & "\" & dgvxDatosPropietarios.Name
        'dgvxDatosPropietarios.ContextMenuStrip = New tbContextMenuStripComponent(dgvxDatosPropietarios.tbCarpetaPerfiles)

        'ConfigurarGridInmuebles()
        FocusedColorInmuebles(Gv)
    End Sub
    Public Sub LlenarGridLlamadas()

        Dim Tabla As String = "Propietarios"
        Dim Sel As String = "SELECT Fecha,(SELECT Nombre FROM Empleados WHERE Contador = ContadorEmpleado ) as Comercial from PropietariosComunicaciones  WHERE ContadorPropietario  = " & txtCodPropietario.Text & " ORDER BY Fecha DESC, Contador DESC"
        Dim bd As New BaseDatos
        bd.LlenarDataSet(Sel, Tabla)

        dgvxLlamadas.DataSource = bd.ds.Tables(Tabla)
        dgvxLlamadas.ForceInitialize()
        ParametrizarGrid(GvLlamadas)

        dgvxLlamadas.tbCarpetaPerfiles = GL_CARPETA_PERFILES & "\" & Me.Name & "\" & dgvxLlamadas.Name
        dgvxLlamadas.ContextMenuStrip = New tbContextMenuStripComponent(dgvxLlamadas.tbCarpetaPerfiles)

        ConfigurarGridLlamadas()
        UcComunicacionesDetalle1.LlenarGrid(txtCodPropietario.Text, GL_TablaPropietarios, 0)

        'txtObservaciones.Text = BD_CERO.Execute("SELECT Observaciones FROM Propietarios WHERE Contador= " & txtCodPropietario.EditValue)
        'LlenarObservaciones(txtObservaciones, txtCodPropietario.EditValue, TablaMantenimiento)

    End Sub

    Private Sub ConfigurarGridInmuebles()

        If Not PrimeraVezInmuebles Then
            Exit Sub
        End If

        PrimeraVezInmuebles = False
        If dgvxDatosPropietarios.tbEstablecerPerfilPredeterminado() Then
            Exit Sub
        End If

        Gv.OptionsView.ShowAutoFilterRow = False

        Gv.BeginDataUpdate()
        Try
            Gv.ClearSorting()
            Gv.Columns("Baja").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            Gv.Columns("Reservado").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            Gv.Columns("Referencia").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
        Finally
            Gv.EndDataUpdate()
        End Try


        PonerColoresInmuebles(Gv)

        For i = 0 To Gv.Columns.Count - 1
            Gv.Columns(i).Visible = False
        Next

        Dim pos As Integer = 0

        pos = pos + 1
        Gv.Columns("Referencia").VisibleIndex = pos
        pos = pos + 1
        Gv.Columns("FotosPc").VisibleIndex = pos
        pos = pos + 1
        Gv.Columns("FotosWeb").VisibleIndex = pos
        pos = pos + 1
        Gv.Columns("DireccionCompleta").VisibleIndex = pos
        pos = pos + 1
        Gv.Columns("Poblacion").VisibleIndex = pos
        pos = pos + 1
        Gv.Columns("Metros").VisibleIndex = pos
        pos = pos + 1
        Gv.Columns("Precio").VisibleIndex = pos
        pos = pos + 1
        Gv.Columns("Tipo").VisibleIndex = pos
        pos = pos + 1
        Gv.Columns("Altura").VisibleIndex = pos
        pos = pos + 1
        Gv.Columns("FechaReservado").VisibleIndex = pos
        pos = pos + 1
        Gv.Columns("Zona").VisibleIndex = pos
        pos = pos + 1
        Gv.Columns("TipoVenta").VisibleIndex = pos
        'Gv.Columns("ObservacionesReservas").VisibleIndex = 13

        'Gv.BestFitColumns()

        'Gv.OptionsView.ColumnAutoWidth = False
        Gv.OptionsView.ShowGroupPanel = False
        Gv.OptionsView.ShowAutoFilterRow = True

    

        Gv.Columns("TipoVenta").Caption = "Oferta"

        Gv.Columns("Reservado").Visible = False
      
        Gv.Columns("Referencia").Visible = True
        Gv.Columns("FechaAlta").Visible = True
        Gv.Columns("FotosPc").Visible = True
        Gv.Columns("FotosWeb").Visible = True

        Gv.Columns("DireccionCompleta").Visible = True
        Gv.Columns("Poblacion").Visible = True
        Gv.Columns("Metros").Visible = True

        Gv.Columns("Precio").Visible = True
        Gv.Columns("Tipo").Visible = True
        Gv.Columns("Altura").Visible = True
        'Gv.Columns("Zona").Visible = True
        'Gv.Columns("ObservacionesReservas").Visible = True
        Gv.Columns("FechaReservado").Visible = True

        Gv.Columns("FechaAlta").Visible = False
        
        Gv.BestFitColumns()
        Gv.Columns("FechaReservado").Width = 80
       
        Gv.Columns("FechaAlta").Width = 80
        Gv.Columns("FotosPc").Width = 50
        Gv.Columns("FotosWeb").Width = 50
        Gv.Columns("Metros").Width = 65
        Gv.Columns("Referencia").Width = 65
        Gv.Columns("Precio").Width = 70
        Gv.Columns("DireccionCompleta").Width = 200

        Gv.Columns("Tipo").Width = 60
        Gv.Columns("Altura").Width = 50
        Gv.Columns("Zona").Width = 200


        Gv.Columns("FechaReservado").Caption = "F. Reserva"
        



        Gv.Columns("FotosPc").Caption = "F. PC"
        Gv.Columns("FotosWeb").Caption = "F.Web"
        Gv.Columns("Referencia").Caption = "Ref."

      

        Gv.OptionsView.ShowFooter = False
        Gv.OptionsView.ShowAutoFilterRow = False

        'Dim ItemArticulo As GridGroupSummaryItem = New GridGroupSummaryItem()
        'ItemArticulo.FieldName = "Contador"
        'ItemArticulo.DisplayFormat = "{0:n0}"
        'ItemArticulo.SummaryType = DevExpress.Data.SummaryItemType.Count
        'Gv.GroupSummary.Add(ItemArticulo)

    End Sub

    Private Sub gv_CustomColumnDisplayText(ByVal sender As Object, ByVal e As Views.Base.CustomColumnDisplayTextEventArgs) Handles Gv.CustomColumnDisplayText
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
    Private Sub ConfigurarGridLlamadas()

        If Not PrimeraVezLlamadas Then
            Exit Sub
        End If

        PrimeraVezLlamadas = False
        If dgvxLlamadas.tbEstablecerPerfilPredeterminado() Then
            Exit Sub
        End If

        GvLlamadas.OptionsView.ColumnAutoWidth = True
        GvLlamadas.OptionsView.ShowGroupPanel = False
        GvLlamadas.OptionsView.ShowAutoFilterRow = False

        GvLlamadas.Columns("Fecha").Width = 120

        GvLlamadas.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways

        Dim ItemArticulo As GridGroupSummaryItem = New GridGroupSummaryItem()
        ItemArticulo.FieldName = "Codigo"
        ItemArticulo.DisplayFormat = "{0:n0}"
        ItemArticulo.SummaryType = DevExpress.Data.SummaryItemType.Count
        GvLlamadas.GroupSummary.Add(ItemArticulo)

    End Sub
    Private Sub Gv_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles Gv.FocusedRowChanged

        Try
            FocusedColorInmuebles(Gv)
        Catch ex As Exception

        End Try

    End Sub

    'Private Sub txtCodPropietario_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtCodPropietario.EditValueChanged
    '    CambioPropietario()
    'End Sub
    Public Sub CambioPropietario()
        Try
            LlenarGridInmuebles()

            txtObservaciones.Text = BD_CERO.Execute("SELECT Observaciones FROM Propietarios WHERE Contador = " & txtCodPropietario.Text, False, "")

            Try

                If Not IsNothing(dgvxDatosPropietarios.ColumnaCheck) Then
                    If Not IsNothing(dgvxDatosPropietarios.ColumnaCheck.View) Then
                        dgvxDatosPropietarios.ColumnaCheck.View = Nothing
                    End If
                End If
            Catch ex As Exception

            End Try




            Try
                dgvxDatosPropietarios.tb_AnadirColumnaCheck = True

            Catch ex As Exception
            End Try
            SituarseEnGrid(Gv, uInmueblesActivo.BinSrc.Current("Contador"), "Contador")
            LlenarGridLlamadas()
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub

     
    
     
     
  
    Private Sub btnCambiarPrecio_Click(sender As System.Object, e As System.EventArgs) Handles btnCambiarPrecio.Click
        If btnCambiarPrecio.Text = "Modificar" Then
            ModificarPropietario()
        Else
            ConfirmarPropietario()
        End If
        'GL_CambiosPrecios = New Tablas.clCambiosPrecios
        'GL_CambiosPrecios.HayCambios = False
        'Dim p As New XtraForm1("Precios de: " & BinSrc.Current("Referencia"))
        'p.Name = "CambioDePrecios"
        'p.ControlBox = False
        'Dim u As New ucCambioPrecio(BinSrc.Current("Contador"))
        'u.Dock = DockStyle.Fill
        'p.Controls.Add(u)
        'Dim tamano As New System.Drawing.Size
        'tamano.Height = 400
        'tamano.Width = 800
        'p.Size = tamano
        'p.StartPosition = FormStartPosition.CenterScreen
        'p.ShowDialog()
        'If GL_CambiosPrecios.HayCambios Then
        '    Dim Observaciones As New Tablas.clObservaciones
        '    Observaciones.Tipo = "LLAMADA"
        '    Observaciones.Tabla = "Propietarios"
        '    Observaciones.ContadorClientePropietarioInmueble = BinSrc.Current("ContadorPropietario")
        '    Observaciones.CodigoEmpresa = DatosEmpresa.Codigo
        '    Observaciones.ContadorEmpleado = GL_CodigoUsuario
        '    Observaciones.Delegacion = Gl_Delegacion
        '    Observaciones.Observaciones = GL_ObservacionesCambioPrecio
        '    Observaciones.ContadorInmueble = BinSrc.Current("Contador")
        '    Observaciones.LlamadaContestada = True
        '    ConsultasBaseDatos.InsertarObservaciones(Observaciones)
        '    UcComunicacionesDetalle1.LlenarGrid(txtCodPropietario.Text, GL_TablaPropietarios)
        '    ActualizaCambiosPrecio()
        '    With GL_CambiosPrecios
        '        If .CambioAlquiler = "SUBE" Or .CambioJunio = "SUBE" Or .CambioJulio = "SUBE" Or .CambioAgosto = "SUBE" Or .CambioVenta = "SUBE" Or .CambioTraspaso = "SUBE" Then
        '            uInmueblesActivo.CambiaValorCampoRowActual("CambioPrecio", "SUBE")
        '        ElseIf .CambioAlquiler = "BAJA" Or .CambioJunio = "BAJA" Or .CambioJulio = "BAJA" Or .CambioAgosto = "BAJA" Or .CambioVenta = "BAJA" Or .CambioTraspaso = "BAJA" Then
        '            uInmueblesActivo.CambiaValorCampoRowActual("CambioPrecio", "BAJA")
        '        End If
        '    End With
        'End If
    End Sub

    Private Sub ModificarPropietario()

        btnAnadirObservaciones.Enabled = False
        btnTelefonoEmail.Enabled = False
        CopiarPropietario()
        PreparaPropietario()
    End Sub
    Private Sub CopiarPropietario()
        With InmoProp
            .Contador = txtCodPropietario.Text
            .CodigoEmpresa = DatosEmpresa.Codigo
            .Delegacion = Gl_Delegacion
            .Nombre = txtNombre.Text
            .TelefonoMovil = txtTelefonoMovil.Text
            .Telefono1 = txtTelefono1.Text
            .Telefono2 = txtTelefono2.Text
            .Telefono3 = txtTelefono3.Text
            .Telefono4 = txtTelefono4.Text

            .Email = txtEmail.Text

            .NoInmo = chkNoInmo.Checked
            .Mensual = chkMensual.Checked
            .Aviso3 = chkAviso3.Checked
            .NoExtranjeros = chkNoExtranjeros.Checked
            .SeguroVivienda = chkSeguroVivienda.Checked
            .NoEmail = chkNoQuiereRecibirEmails.Checked
            .NoAnimales = chkNoAnimales.Checked

        End With
    End Sub
    Private Function ConfirmarPropietario() As Boolean


        If Not Funciones.validar_Mail(txtEmail.Text) Then
            MensajeError("El campo email no es correcto")
            txtEmail.Focus()
            Return False
        End If


        PreparaPropietario()
        GuardarPropietario()

        btnAnadirObservaciones.Enabled = True
        btnTelefonoEmail.Enabled = True

        Return True

    End Function
    Private Sub GuardarPropietario()
        With InmoProp
            If CompruebaPropietario() Then
                BD_CERO.Execute("UPDATE Propietarios SET" & _
                " Nombre='" & txtNombre.Text & _
                "', TelefonoMovil='" & txtTelefonoMovil.Text & _
                "', Telefono1='" & txtTelefono1.Text & _
                "', Telefono2='" & txtTelefono2.Text & _
                "', Telefono3='" & txtTelefono3.Text & _
                "', Telefono4='" & txtTelefono4.Text & _
                "', Email='" & txtEmail.Text & _
                "', NoInmobiliaria=" & FuncionesGenerales.Funciones.pf_ReplaceTrueFalse(chkNoInmo.Checked) & _
                ", AvisadoMensualidad=" & FuncionesGenerales.Funciones.pf_ReplaceTrueFalse(chkMensual.Checked) & _
                ", AvisadoTresPorCien=" & FuncionesGenerales.Funciones.pf_ReplaceTrueFalse(chkAviso3.Checked) & _
                ", NoExtranjeros=" & FuncionesGenerales.Funciones.pf_ReplaceTrueFalse(chkNoExtranjeros.Checked) & _
                ", SeguroVivienda=" & FuncionesGenerales.Funciones.pf_ReplaceTrueFalse(chkSeguroVivienda.Checked) & _
                ", NoQuiereRecibirEmails=" & FuncionesGenerales.Funciones.pf_ReplaceTrueFalse(chkNoQuiereRecibirEmails.Checked) & _
                ", NoAnimales=" & FuncionesGenerales.Funciones.pf_ReplaceTrueFalse(chkNoAnimales.Checked) & _
                    " WHERE Contador=" & txtCodPropietario.Text & " AND CodigoEmpresa=" & DatosEmpresa.Codigo & " AND Delegacion=" & Gl_Delegacion)

                PonerPendienteRefrescarAlarmas()
                PonerPendienteRefrescarPropietarios()
                RefrescarDatosDesdeBdInmuebles(True)


            Else
                If txtNombre.Text.ToString.Trim = "" Then
                    MensajeError("El campo nombre no puede estar vacío")
                    PreparaPropietario()
                    txtNombre.Focus()
                End If
            End If
        End With
    End Sub
    Private Function CompruebaPropietario() As Boolean
        With InmoProp
            If (.Contador <> txtCodPropietario.Text Or
                .CodigoEmpresa <> DatosEmpresa.Codigo Or
                .Delegacion <> Gl_Delegacion Or
                .Nombre <> txtNombre.Text Or
                .TelefonoMovil <> txtTelefonoMovil.Text Or
                .Telefono1 <> txtTelefono1.Text Or
                 .Telefono2 <> txtTelefono2.Text Or
                  .Telefono3 <> txtTelefono3.Text Or
                   .Telefono4 <> txtTelefono4.Text Or
                .Email <> txtEmail.Text Or
                .NoInmo <> chkNoInmo.Checked Or
                .Mensual <> chkMensual.Checked Or
                .SeguroVivienda <> chkSeguroVivienda.Checked Or
                .NoExtranjeros <> chkNoExtranjeros.Checked Or
                .NoEmail <> chkNoExtranjeros.Checked Or
                .NoAnimales <> chkNoExtranjeros.Checked Or
                .Aviso3 <> chkAviso3.Checked) And
                 txtNombre.Text.ToString.Trim <> "" Then Return True
        End With
        Return False
    End Function
    Private Sub CancelarPropietario()

        btnAnadirObservaciones.Enabled = True
        btnTelefonoEmail.Enabled = True
        PreparaPropietario()
        ResetPropietario()
    End Sub
    Private Sub ResetPropietario()
        With InmoProp
            txtCodPropietario.Text = .Contador
            DatosEmpresa.Codigo = .CodigoEmpresa
            Gl_Delegacion = .Delegacion
            txtNombre.Text = .Nombre
            txtTelefonoMovil.Text = .TelefonoMovil
            txtTelefono1.Text = .Telefono1
            txtTelefono2.Text = .Telefono2
            txtTelefono3.Text = .Telefono3
            txtTelefono4.Text = .Telefono4
            txtEmail.Text = .Email
            chkNoInmo.Checked = .NoInmo
            chkMensual.Checked = .Mensual
            chkAviso3.Checked = .Aviso3
            chkSeguroVivienda.Checked = .SeguroVivienda
            chkNoExtranjeros.Checked = .NoExtranjeros
            chkNoAnimales.Checked = .NoAnimales
            chkNoQuiereRecibirEmails.Checked = .NoEmail
        End With
    End Sub
    Public Sub PreparaPropietario()
        If btnCambiarPrecio.Text = "Modificar" Then
            btnCambiarPrecio.Image = My.Resources.Aceptar
            btnPropietario.Image = My.Resources.Cancelar
            btnCambiarPrecio.Text = "Aceptar"
            btnPropietario.Text = "Cancelar"
            HabilitarPropietario(True)
        Else
            btnCambiarPrecio.Image = My.Resources.Modificar
            btnPropietario.Image = My.Resources.DatosPropietarios
            btnCambiarPrecio.Text = "Modificar"
            btnPropietario.Text = "Propietario"
            HabilitarPropietario(False)
        End If
    End Sub
    Private Sub HabilitarPropietario(si As Boolean)
        txtNombre.Properties.ReadOnly = Not si
        txtTelefonoMovil.Properties.ReadOnly = Not si
        txtTelefono1.Properties.ReadOnly = Not si
        txtTelefono2.Properties.ReadOnly = Not si
        txtTelefono3.Properties.ReadOnly = Not si
        txtTelefono4.Properties.ReadOnly = Not si

        txtEmail.Properties.ReadOnly = Not si

        'chkNoInmo.Properties.ReadOnly = Not si
        'chkMensual.Properties.ReadOnly = Not si
        'chkAviso3.Properties.ReadOnly = Not si

        txtNombre.Enabled = si
        txtTelefonoMovil.Enabled = si
        txtTelefono1.Enabled = si
        txtTelefono2.Enabled = si
        txtTelefono3.Enabled = si
        txtTelefono4.Enabled = si

        txtEmail.Enabled = si

        chkNoInmo.Enabled = si
        chkMensual.Enabled = si
        chkAviso3.Enabled = si
        chkSeguroVivienda.Enabled = si
        chkNoExtranjeros.Enabled = si

        chkNoAnimales.Enabled = si
        chkNoQuiereRecibirEmails.Enabled = si

        uInmueblesActivo.PanelBotones.Enabled = Not si
        uInmueblesActivo.dgvx.Enabled = Not si
        UcComunicacionesDetalle1.Enabled = Not si
        dgvxDatosPropietarios.Enabled = Not si
    End Sub
    Public Sub ActualizaCambiosPrecio()
        If GL_CambiosPrecios IsNot Nothing Then
            If GL_CambiosPrecios.HayCambios Then

                If Not IsNothing(bd) Then bd.RefrescarDatos(BinSrc.Position)


                'CambiaValorCampoRowActual(bd.ds, TablaMantenimiento, "PrecioVenta", GL_CambiosPrecios.PrecioVenta, Gv)
                'CambiaValorCampoRowActual(bd.ds, TablaMantenimiento, "PrecioAlquiler", GL_CambiosPrecios.PrecioAlquiler, Gv)
                'CambiaValorCampoRowActual(bd.ds, TablaMantenimiento, "Venta", GL_CambiosPrecios.Venta, Gv)
                'CambiaValorCampoRowActual(bd.ds, TablaMantenimiento, "Alquiler", GL_CambiosPrecios.Alquiler, Gv)
                'CambiaValorCampoRowActual(uInmueblesActivo.bd.ds, "Inmuebles", "PrecioVenta", GL_CambiosPrecios.PrecioVenta, , GL_CambiosPrecios.ContadorInmueble)
                'CambiaValorCampoRowActual(uInmueblesActivo.bd.ds, "Inmuebles", "PrecioAlquiler", GL_CambiosPrecios.PrecioAlquiler, , GL_CambiosPrecios.ContadorInmueble)
                'CambiaValorCampoRowActual(uInmueblesActivo.bd.ds, "Inmuebles", "Venta", GL_CambiosPrecios.Venta, , GL_CambiosPrecios.ContadorInmueble)
                'CambiaValorCampoRowActual(uInmueblesActivo.bd.ds, "Inmuebles", "Alquiler", GL_CambiosPrecios.Alquiler, , GL_CambiosPrecios.ContadorInmueble)

            End If
        End If


        'recargar inmueblespropietarios
    End Sub


    Private Sub btnPropietario_Click(sender As System.Object, e As System.EventArgs) Handles btnPropietario.Click
        If btnPropietario.Text = "Cancelar" Then
            CancelarPropietario()
        Else
            CargarFormulario("Propietarios", "", True, GL_VENGO_DE_INMUEBLES, BinSrc.Current("ContadorPropietario").ToString)
        End If
    End Sub

    'Private Sub dgvxDatosPropietarios_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvxDatosPropietarios.DoubleClick
    '    LlamarInmueble()
    'End Sub
    'Private Sub LlamarInmueble()
    '    SituarseEnGrid(uInmueblesActivo.Gv, BinSrc.Current("Contador"), "Contador", 0)
    '    uInmueblesActivo.TabInmuebles.SelectedTabPage = uInmueblesActivo.TabDatos
    'End Sub


    Private Sub dgvxDatosPropietarios_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvxDatosPropietarios.DoubleClick
        RaiseEvent dgvxDatosPropietariosDoubleClick(sender, e)
    End Sub



    Private Sub btnAnadirObservaciones_Click(sender As System.Object, e As System.EventArgs) Handles btnAnadirObservaciones.Click
        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Return
        End If

        Dim Observaciones As New Tablas.clComunicaciones

        Observaciones.Tipo = GL_OBSERVACIONES_MANUAL
        Observaciones.Tabla = GL_TablaPropietarios
        Observaciones.ContadorClientePropietarioInmueble = BinSrc.Current("ContadorPropietario")
        Observaciones.CodigoEmpresa = DatosEmpresa.Codigo
        Observaciones.ContadorEmpleado = GL_CodigoUsuario
        Observaciones.Delegacion = Gl_Delegacion
        Observaciones.Observaciones = GL_Observaciones
        Observaciones.ContadorInmueble = 0

        GL_Observaciones = ""
        GL_RespondioALaLlamada = True


        Dim f As New frmObservaciones
        f.Tipo = Observaciones.Tipo
        Dim Sel As String
        Sel = "SELECT Observaciones FROM Propietarios WHERE Contador = " & Observaciones.ContadorClientePropietarioInmueble
        f.txtTexto.Text = BD_CERO.Execute(Sel, False, "")
        f.ShowDialog()

        If GL_Observaciones <> Gl_ResultadoBusqueda_SALIR Then
            BD_CERO.Execute("UPDATE Propietarios SET Observaciones= '" & Funciones.pf_ReplaceComillas(GL_Observaciones) & "' WHERE Contador= " & BinSrc.Current("ContadorPropietario"))
            txtObservaciones.Text = GL_Observaciones
        End If

        PonerPendienteRefrescarPropietarios()

        '  If ProcesoAnadirObservaciones2(Observaciones) = -1 Then Return


        'txtObservaciones.Text = Now & " " & GL_Observaciones & vbCrLf & txtObservaciones.Text
        'If txtObservaciones.Text.Length > 5000 Then
        '    txtObservaciones.Text = txtObservaciones.Text.Substring(0, 5000)
        'End If
        'BD_CERO.Execute("UPDATE Propietarios SET Observaciones= '" & Funciones.pf_ReplaceComillas(txtObservaciones.Text) & "' WHERE Contador= " & BinSrc.Current("ContadorPropietario"))
        ''LlenarObservaciones(txtObservaciones, BinSrc.Current("ContadorPropietario"), TablaMantenimiento)
    End Sub

    Private Sub btnEmails_Click(sender As System.Object, e As System.EventArgs) Handles btnTelefonoEmail.Click
        If txtEmail.Visible = True Then
            txtTelefono2.Visible = True
            txtTelefono3.Visible = True
            txtTelefono4.Visible = True
            lblTelefono2.Visible = True
            lblTelefono3.Visible = True
            lblTelefono4.Visible = True

            lblEmail.Visible = False
            txtEmail.Visible = False

        Else

            txtTelefono2.Visible = False
            txtTelefono3.Visible = False
            txtTelefono4.Visible = False
            lblTelefono2.Visible = False
            lblTelefono3.Visible = False
            lblTelefono4.Visible = False

            lblEmail.Visible = True
            txtEmail.Visible = True

        End If
    End Sub
End Class
