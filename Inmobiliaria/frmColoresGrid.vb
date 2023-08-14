Imports DevExpress.XtraGrid

Public Class frmColoresGrid
    Dim opciones As String = ""
    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Public Sub New(opc As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        opciones = opc
        GroupBox1.Visible = False
        GroupBox2.Location = GroupBox1.Location
        Me.Size = New Size(508, Me.Size.Height)
    End Sub


    Private Sub frmColoresGrid_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        CargarClientes()

        CargarInmuebles()

    End Sub
    Private Sub CargarClientes()
        Dim dt As New DataTable
        Dim dc As New DataColumn
        dc.ColumnName = "Significado"
        dt.Columns.Add(dc)

        Dim dr As DataRow

        dr = dt.NewRow
        dr("Significado") = ""
        dt.Rows.Add(dr)

        'dr = dt.NewRow
        'dr("Significado") = "LLAMADA"
        'dt.Rows.Add(dr)

        'dr = dt.NewRow
        'dr("Significado") = "SMS"
        'dt.Rows.Add(dr)

        'dr = dt.NewRow
        'dr("Significado") = "EMAIL + LLAMADA"
        'dt.Rows.Add(dr)

        'dr = dt.NewRow
        'dr("Significado") = "EMAIL"
        'dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Significado") = "INFORMADO"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Significado") = "BAJA"
        dt.Rows.Add(dr)

        dgvxClientes.DataSource = dt

        ColoresClientes()

        dgvxClientes.Enabled = False

        GvClientes.OptionsView.ShowGroupPanel = False
    End Sub

    Private Sub CargarInmuebles()
        Dim dt As New DataTable
        Dim dc As New DataColumn
        dc.ColumnName = "Significado"
        dt.Columns.Add(dc)

        Dim dr As DataRow

        dr = dt.NewRow
        dr("Significado") = ""
        dt.Rows.Add(dr)

        If opciones = "" OrElse opciones.Contains(".RESERVADO.") Then
            dr = dt.NewRow
            dr("Significado") = "RESERVADO"
            dt.Rows.Add(dr)
        End If
        If opciones = "" OrElse opciones.Contains(".OCULTO.") Then
            dr = dt.NewRow
            dr("Significado") = "OCULTO"
            dt.Rows.Add(dr)
        End If
        If opciones = "" OrElse opciones.Contains(".VISITA.") Then
            dr = dt.NewRow
            dr("Significado") = "VISITA"
            dt.Rows.Add(dr)
        End If
        If opciones = "" OrElse opciones.Contains(".BAJA.") Then
            dr = dt.NewRow
            dr("Significado") = "BAJA"
            dt.Rows.Add(dr)
        End If
        If opciones = "" OrElse opciones.Contains(".PENDIENTE ACTUALIZAR.") Then
            dr = dt.NewRow
            dr("Significado") = "PENDIENTE ACTUALIZAR EN LA WEB"
            dt.Rows.Add(dr)
        End If
        If opciones = "" OrElse opciones.Contains(".PANTALLA PRINCIPAL.") Then
            dr = dt.NewRow
            dr("Significado") = "SE MUESTRA EN LA PANTALLA PRINCIPAL DE LA WEB"
            dt.Rows.Add(dr)
        End If

        dgvxInmuebles.DataSource = dt

        ColoresInmuebles()

        dgvxInmuebles.Enabled = False

        GvInmuebles.OptionsView.ShowGroupPanel = False
    End Sub
    Private Sub ColoresClientes()

        Try



            Dim condition1 As StyleFormatCondition

            'condition1 = New DevExpress.XtraGrid.StyleFormatCondition()
            'condition1.Tag = "1"
            'condition1.Appearance.BackColor = GL_ColorLlamada
            'condition1.Appearance.Options.UseBackColor = True
            'condition1.Condition = FormatConditionEnum.Expression
            'condition1.Expression = "Significado = 'LLAMADA'"
            'GvClientes.FormatConditions.Add(condition1)

            ''condition1 = New DevExpress.XtraGrid.StyleFormatCondition()
            ''condition1.Appearance.BackColor = Color.Plum
            ''condition1.Appearance.Options.UseBackColor = True
            ''condition1.Condition = FormatConditionEnum.Expression
            ''condition1.Expression = "Significado = 'SMS'"
            ''GvClientes.FormatConditions.Add(condition1)

            'condition1 = New DevExpress.XtraGrid.StyleFormatCondition()
            'condition1.Appearance.BackColor = GL_ColorLlamada_EMail
            'condition1.Appearance.Options.UseBackColor = True
            'condition1.Condition = FormatConditionEnum.Expression
            'condition1.Expression = "Significado = 'EMAIL + LLAMADA'"
            'GvClientes.FormatConditions.Add(condition1)

            'condition1 = New DevExpress.XtraGrid.StyleFormatCondition()
            'condition1.Appearance.BackColor = GL_ColorEmail
            'condition1.Appearance.Options.UseBackColor = True
            'condition1.Condition = FormatConditionEnum.Expression
            'condition1.Expression = "Significado = 'EMAIL'"
            'GvClientes.FormatConditions.Add(condition1)

            condition1 = New DevExpress.XtraGrid.StyleFormatCondition()
            condition1.Appearance.BackColor = GL_ColorNovedad
            condition1.Appearance.Options.UseBackColor = True
            condition1.Condition = FormatConditionEnum.Expression
            condition1.Expression = "Significado = 'INFORMADO'"
            GvClientes.FormatConditions.Add(condition1)


            condition1 = New DevExpress.XtraGrid.StyleFormatCondition()
            condition1.Appearance.BackColor = Color.Red
            condition1.Appearance.Options.UseBackColor = True
            condition1.Condition = FormatConditionEnum.Expression
            condition1.Expression = "Significado = 'BAJA'"
            GvClientes.FormatConditions.Add(condition1)


        Catch ex As Exception

        End Try
    End Sub

    Private Sub ColoresInmuebles()

        Try


            Dim condition1 As StyleFormatCondition

            condition1 = New DevExpress.XtraGrid.StyleFormatCondition()
            condition1.Appearance.BackColor = GL_ColorReservado
            condition1.Appearance.Options.UseBackColor = True
            condition1.Condition = FormatConditionEnum.Expression
            condition1.Expression = "Significado = 'RESERVADO'"
            GvInmuebles.FormatConditions.Add(condition1)

            condition1 = New DevExpress.XtraGrid.StyleFormatCondition()
            condition1.Appearance.BackColor = GL_ColorOcultarSeleccionado
            condition1.Appearance.Options.UseBackColor = True
            condition1.Appearance.Options.UseForeColor = True
            condition1.Condition = FormatConditionEnum.Expression
            condition1.Expression = "Significado = 'OCULTO'"
            GvInmuebles.FormatConditions.Add(condition1)

            condition1 = New DevExpress.XtraGrid.StyleFormatCondition()
            condition1.Appearance.BackColor = GL_ColorBaja
            condition1.Appearance.Options.UseBackColor = True
            condition1.Condition = FormatConditionEnum.Expression
            condition1.Expression = "Significado = 'BAJA'"
            GvInmuebles.FormatConditions.Add(condition1)



            condition1 = New DevExpress.XtraGrid.StyleFormatCondition()
            condition1.Appearance.BackColor = GL_ColorVisitado
            condition1.Appearance.Options.UseBackColor = True
            condition1.Condition = FormatConditionEnum.Expression
            condition1.Expression = "Significado = 'VISITA'"
            GvInmuebles.FormatConditions.Add(condition1)

            condition1 = New DevExpress.XtraGrid.StyleFormatCondition()
            condition1.Appearance.BackColor = GL_ColorPendienteWeb
            condition1.Appearance.Options.UseBackColor = True
            condition1.Condition = FormatConditionEnum.Expression
            condition1.Expression = "Significado = 'PENDIENTE ACTUALIZAR EN LA WEB'"
            GvInmuebles.FormatConditions.Add(condition1)

            condition1 = New DevExpress.XtraGrid.StyleFormatCondition()
            condition1.Appearance.BackColor = GL_ColorMostrarPPrincipalWeb
            condition1.Appearance.Options.UseBackColor = True
            condition1.Condition = FormatConditionEnum.Expression
            condition1.Expression = "Significado = 'SE MUESTRA EN LA PANTALLA PRINCIPAL DE LA WEB'"
            GvInmuebles.FormatConditions.Add(condition1)


        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.Dispose()
    End Sub
End Class