Imports FuncionesGenerales.Funciones

Public Class ucMensajeEmail
    Dim adjuntos As String = ""
    'Dim bd As BaseDatos
    'Dim BinSrc As BindingSource
    Dim BinSrc2 As BindingSource
    Dim SentenciaSQL As String
    Dim row As DataRowView

    Public p_ClientesPropietarios As String
    Dim Documento As String

    Public Property ClientesPropietarios As String
        Get
            Return p_ClientesPropietarios
        End Get
        Set(value As String)
            p_ClientesPropietarios = value
            Select Case p_ClientesPropietarios
                Case GL_Clientes
                    Documento = GL_EMAIL_DETALLE
                Case GL_Propietarios
                    Documento = GL_EMAIL_PROPIETARIOS
            End Select
            '    CargarDatos()
        End Set
    End Property
    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Function LlenarComboAsunto() As Boolean

        Try
            SentenciaSQL = "SELECT * FROM TextosEnvios WHERE CodigoEmpresa=" & DatosEmpresa.Codigo & " AND Documento = '" & pf_ReplaceComillas(Documento) & "' ORDER BY Predeterminado DESC, Asunto"
            cmbTextosEnvios.EditValue = Nothing
            FuncionesGenerales.Funciones.LlenarCombo(cmbTextosEnvios, "TextosEnvios", "Asunto", "Contador", ConsultaEnVezDeTabla:=SentenciaSQL)
            cmbTextosEnvios.ForceInitialize()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try


    End Function

    Public Sub CargarDatos()

        'bd = New BaseDatos
        'BinSrc = New BindingSource
        BinSrc2 = New BindingSource

        If Not LlenarComboAsunto() Then
            Exit Sub
        End If

        Dim AsuntoPredeterminado As String = ""

        Dim dt As DataTable = cmbTextosEnvios.Properties.DataSource
        Dim ContadorPredeterminado As Integer = 0


        For Each d As DataRow In dt.Rows
            If d("Predeterminado") Then
                AsuntoPredeterminado = d("Asunto")
                ContadorPredeterminado = d("Contador")
                Exit For
            End If
        Next

        If AsuntoPredeterminado = "" Then
            If dt.Rows.Count > 0 Then
                AsuntoPredeterminado = dt.Rows(0)("Asunto").
                ContadorPredeterminado = dt.Rows(0)("Contador")
            End If
        End If

        If AsuntoPredeterminado = "" Then
            Exit Sub
        End If

        cmbTextosEnvios.EditValue = ContadorPredeterminado
        BinSrc2.DataSource = cmbTextosEnvios.GetSelectedDataRow

        '   BinSrc2.DataSource = cmbTextosEnvios.Properties.DataSource
        'BinSrc2.ResetBindings(True)

        Try
            txtContador.DataBindings.Add(New Binding("EditValue", BinSrc2, "Contador", True))
            txtTitulo.DataBindings.Add(New Binding("EditValue", BinSrc2, "TituloInforme", True))
            txtAsunto.DataBindings.Add(New Binding("Text", BinSrc2, "Asunto", True))
            txtMensaje.DataBindings.Add(New Binding("EditValue", BinSrc2, "Texto", True))
            chkInfoEmpresa.DataBindings.Add(New Binding("Checked", BinSrc2, "IncluirDatosEmpresa", True))
            chkInfoInmueble.DataBindings.Add(New Binding("Checked", BinSrc2, "IncluirOtros", True))
            chkAvisoLegal.DataBindings.Add(New Binding("Checked", BinSrc2, "IncluirAvisoLegal", True))
            chkIncluirFichaInmueble.DataBindings.Add(New Binding("Checked", BinSrc2, "IncluirFichaInmueble", True))

        Catch ex As Exception

        End Try

        ColorPredeterminado()

        If chkInfoEmpresa.Checked Then
            chkAvisoLegal.Enabled = True
        Else
            chkAvisoLegal.Enabled = False
        End If

        'For Each d As DataRow In bd.ds.Tables("TextosEnvios").Rows
        '    If d("Predeterminado") Then
        '        AsuntoPredeterminado = d("Asunto")
        '        Exit For
        '    End If
        'Next

        'If AsuntoPredeterminado = "" Then
        '    If bd.ds.Tables("TextosEnvios").Rows.Count > 0 Then
        '        AsuntoPredeterminado = bd.ds.Tables("TextosEnvios").Rows(0)("Asunto").ToString
        '    End If
        'End If

        'cmbTextosEnvios.Properties.GetRowByKeyValue(GLook.EditValue)("CodigoCliente")
        'cmbTextosEnvios.Properties.GetRowByKeyValue()

        'BinSrc2.DataSource = cmbTextosEnvios.GetSelectedDataRow

        'txtTitulo.DataBindings.Add(New Binding("Text", BinSrc2, "TituloInforme", True))
        'txtAsunto.DataBindings.Add(New Binding("Text", BinSrc2, "Asunto", True))
        'txtMensaje.DataBindings.Add(New Binding("Text", BinSrc2, "Texto", True))
        'chkInfoEmpresa.DataBindings.Add(New Binding("Checked", BinSrc2, "IncluirDatosEmpresa", True))
        'chkInfoInmueble.DataBindings.Add(New Binding("Checked", BinSrc2, "IncluirOtros", True))
        'chkAvisoLegal.DataBindings.Add(New Binding("Checked", BinSrc2, "IncluirAvisoLegal", True))

    End Sub

    Private Sub cmbTextosEnvios_Closed(sender As Object, e As DevExpress.XtraEditors.Controls.ClosedEventArgs) Handles cmbTextosEnvios.Closed
        CambioDeTexto()
    End Sub
    Private Sub cmbTextosEnvios_QueryPopUp(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles cmbTextosEnvios.QueryPopUp
        For i = 0 To cmbTextosEnvios.Properties.View.Columns().Count - 1
            cmbTextosEnvios.Properties.View.Columns(i).Visible = False
        Next
        cmbTextosEnvios.Properties.View.Columns("Asunto").Visible = True
        cmbTextosEnvios.Properties.View.Columns("Texto").Visible = True
        cmbTextosEnvios.Properties.View.Columns("Predeterminado").Visible = True
        'For i = 0 To cmbTextosEnvios.Properties.View.RowCount - 1
        '    row = cmbTextosEnvios.Properties.View.GetRow(i)
        '    If row.Item("Documento").ToString.Contains("(Predeterminado)") Then
        '        If Not row.Item("Asunto").ToString.Contains("(Predeterminado)") Then row.Item("Asunto") &= "(Predeterminado)"
        '    End If
        'Next
    End Sub

    Private Sub ColorPredeterminado()

        If IsNothing(BinSrc2.Current) Then
            Return
        End If

        Try
            If BinSrc2.Current("Predeterminado") Then
                cmbTextosEnvios.ForeColor = Color.Red
            Else
                cmbTextosEnvios.ForeColor = Color.Black
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub CambioDeTexto()

        BinSrc2.DataSource = cmbTextosEnvios.GetSelectedDataRow
        ColorPredeterminado()

    End Sub
    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        If VerificarDatos() Then
            MontarRespuesta(False)
            Salir()
        Else
            MsgBox("Los campos titulo, asunto y mensaje son obligatorios.")
        End If
    End Sub
    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
         MontarRespuesta(True)
        Salir()
    End Sub
    Private Sub MontarRespuesta(Salir As Boolean)

        Dim Res As String
        If Salir Then
            Res = "True"
        Else

            Res = "False"
        End If


        GL_DatosMensajePersonalizado = txtTitulo.Text & "|" & txtAsunto.Text & "|" & txtMensaje.Text & "|" & adjuntos & "|" & _
  chkInfoInmueble.Checked & "|" & chkInfoEmpresa.Checked & "|" & chkAvisoLegal.Checked & "|" & chkIncluirFichaInmueble.Checked & "|" & Res & "|" & chkIncluirTextoFotos.Checked & "|" & chkIncluirDireccion.Checked & "|" & txtTipoEmail.Text.Trim

    End Sub
    Private Sub Salir()
        Me.ParentForm.Dispose()
    End Sub
    Private Function VerificarDatos() As Boolean
        Return Not ((txtAsunto.Text = "") + (txtMensaje.Text = ""))
    End Function
    Private Sub btnAdjuntar_Click(sender As System.Object, e As System.EventArgs) Handles btnAdjuntar.Click
        InsertarDocumento()
    End Sub
    Private Sub InsertarDocumento(Optional FicheroDestino As String = "")
        Dim ofd As New OpenFileDialog
        Try
            ofd.Title = "Seleccione un fichero"
            ofd.Filter = "Todos (*.*, *.*)|*.*;*.*"
            ofd.Multiselect = True
            txtAdjunto.Text = ""
            adjuntos = ""
            If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
                For Each Ruta As String In ofd.FileNames
                    txtAdjunto.Text &= System.IO.Path.GetFileName(Ruta) & ","
                    adjuntos &= Ruta & ";"
                Next
                txtAdjunto.Text = txtAdjunto.Text.Substring(0, txtAdjunto.Text.Count - 1)
                adjuntos = adjuntos.Substring(0, adjuntos.Count - 1)
            Else
                MsgBox("No seleccionó ningún fichero.")
                Return
            End If
        Catch ex As Exception

            MsgBox(ex.Message)
            Return
        End Try
    End Sub
    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If Not VerificarDatos() Then
            MsgBox("Los campos titulo, asunto y mensaje son obligatorios.")
            Return
        End If
        'añadimos a textosenvios

        Dim AsuntoAnterior As String = txtAsunto.Text

        If cmbTextosEnvios.Text = txtAsunto.Text Then
            If MsgBox("¿Confirma que quiere modificar la configuración actual?" & vbCrLf & "Si quiere una nueva configuración, cambie el asunto", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Return
            Modificar(AsuntoAnterior)
            Exit Sub
        End If




        If MsgBox("¿Quiere crear un nuevo mensaje con este asunto?" & vbCrLf & "Si elige NO, modificará el mensaje actual con el nuevo asunto", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Anadir(AsuntoAnterior)
        Else
            Modificar(AsuntoAnterior)
        End If


    End Sub

    Private Sub Anadir(AsuntoAnterior As String)

        Dim Sel As String = "INSERT INTO TextosEnvios VALUES(" & DatosEmpresa.Codigo & ",'" & pf_ReplaceComillas(Documento) & "','" & pf_ReplaceComillas(txtAsunto.Text) & "','" & pf_ReplaceComillas(txtMensaje.Text) & _
            "','" & pf_ReplaceTrueFalse(chkAvisoLegal.Checked) & "','" & pf_ReplaceTrueFalse(chkInfoEmpresa.Checked) & "','" & pf_ReplaceTrueFalse(txtTitulo.Text) & "',1,'" & pf_ReplaceTrueFalse(chkInfoInmueble.Checked) & "','" & pf_ReplaceTrueFalse(chkIncluirFichaInmueble.Checked) & "',0)"

        ConsultaSQL(Sel, AsuntoAnterior)

        'row = cmbTextosEnvios.GetSelectedDataRow

        ' cmbTextosEnvios.EditValue = AsuntoAnterior

    End Sub
    Private Sub Modificar(AsuntoAnterior As String)

        Dim Sel As String
        Dim Contador As Integer
        Contador = BinSrc2.Current("Contador")
        Sel = "UPDATE TextosEnvios Set Asunto = '" & Funciones.pf_ReplaceComillas(txtAsunto.Text) & "', Texto = '" & Funciones.pf_ReplaceComillas(txtMensaje.Text) & "', TituloInforme = '" & Funciones.pf_ReplaceComillas(txtTitulo.Text) & "', IncluirAvisoLegal = " & Funciones.pf_ReplaceTrueFalse(chkAvisoLegal.Checked) & ", IncluirFichaInmueble = " & Funciones.pf_ReplaceTrueFalse(chkIncluirFichaInmueble.Checked) & ", IncluirDatosEmpresa = " & Funciones.pf_ReplaceTrueFalse(chkInfoEmpresa.Checked) & ", IncluirOtros = " & Funciones.pf_ReplaceTrueFalse(chkInfoInmueble.Checked) & " WHERE Contador = " & Contador
        ConsultaSQL(Sel, AsuntoAnterior)


    End Sub
    'Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
    '    If MsgBox("¿Estas seguro de borrar " & cmbTextosEnvios.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Return
    '    'borramos el actual de textosenvios
    '    row = cmbTextosEnvios.GetSelectedDataRow
    '    '   ConsultaSQL(""& GL_SQL_DELETE &"FROM TextosEnvios WHERE Documento ='" & row.Item("Documento") & "' AND Asunto='" & row.Item("Asunto") & "' AND Texto='" & row.Item("Texto") & "'")
    '    ConsultaSQL(""& GL_SQL_DELETE &"FROM TextosEnvios WHERE Contador = " & row.Item("Contador"))
    'End Sub
    Private Sub btnPredeterminar_Click(sender As System.Object, e As System.EventArgs) Handles btnPredeterminar.Click
        'recorremos los campos borramos el (Predeterminado) y se lo añadimos al actual
        ' row = cmbTextosEnvios.GetSelectedDataRow
        'ConsultaSQL("UPDATE TextosEnvios Set Documento='EMAIL PROPIETARIOS' where Documento LIKE 'EMAIL PROPIETARIOS%' " & _
        '   "UPDATE TextosEnvios Set Documento=Documento" & GL_SQL_SUMA & "' (Predeterminado)' where Documento='EMAIL PROPIETARIOS' AND Asunto='" & _
        '   row.Item("Asunto") & "' AND Texto='" & row.Item("Texto") & "'")

        If IsNothing(BinSrc2.Current) Then
            Return
        End If

        Dim Contador As Integer
        Contador = BinSrc2.Current("Contador")
        ConsultaSQL("UPDATE TextosEnvios SET Predeterminado = 0 WHERE Documento='" & pf_ReplaceComillas(Documento) & "' " & _
                    "UPDATE TextosEnvios SET Predeterminado =" & GL_SQL_VALOR_1 & " WHERE Contador = " & Contador, "")

        'FALTA BORRAR LOS PONER A FALSE EL RESTO

        CargarDatos()

        'BinSrc2.Current("Predeterminado") = True
        'ColorPredeterminado()
    End Sub
    Private Function ConsultaSQL(sel As String, ValorAnterior As String) As Boolean

        Try

            Dim bd As New BaseDatos
            bd.Execute(sel)

            'Prueba...TT
            ' If Not LlenarComboAsunto() Then
            '     Exit Function
            ' End If

            ' Dim dt As DataTable = cmbTextosEnvios.Properties.DataSource
            ' Dim ContadorAnterior As Integer = 0

            ' For Each d As DataRow In dt.Rows
            '  If d("Asunto") = ValorAnterior Then
            '    ContadorAnterior = d("Contador")
            ''BinSrc2.DataSource = d
            '    Exit For
            ' End If
            'Next

            'cmbTextosEnvios.EditValue = ContadorAnterior
            'BinSrc2.DataSource = cmbTextosEnvios.GetSelectedDataRow
            'BinSrc2.ResetBindings(True)

            'ColorPredeterminado()

        Catch ex As SqlClient.SqlException
            If ex.Number = 2601 Then
                MsgBox("Ya existe un mensaje con ese asunto")
            Else
                MsgBox(ex.Message)
            End If

            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

        Return True
    End Function



    Private Sub chkInfoEmpresa_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkInfoEmpresa.CheckedChanged
        If chkInfoEmpresa.Checked Then
            chkAvisoLegal.Enabled = True
        Else
            chkAvisoLegal.Enabled = False
        End If
    End Sub


End Class