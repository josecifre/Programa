Public Class frmFichaAlquiler

    Dim EstoyEnAlta As Boolean

    Dim bd As BaseDatos
    Private WithEvents BinSrc As BindingSource
    Dim TablaMantenimiento As String = "FichasAlquiler"
    Dim Cargando As Boolean = True

    Private p_ContadorCliente As String

    Public Property ContadorCliente As Integer
        Get
            Return p_ContadorCliente
        End Get
        Set(value As Integer)
            p_ContadorCliente = value
        End Set
    End Property

    Private Sub frmFichaAlquiler_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        GL_FichaAlquiler = -1
        AparienciaGeneral()

        Dim Tab As New Tablas.clTablaGeneral(TablaMantenimiento, , "SELECT * FROM " & TablaMantenimiento & " WHERE ContadorCliente = " & ContadorCliente, )
        bd = New BaseDatos
        Tab.Datos(bd, Tab.ConsultaAEjecutar, , , , , True)

        BinSrc = New BindingSource

        BinSrc.DataSource = bd.ds
        BinSrc.DataMember = TablaMantenimiento

        'Bindings
        txtCodigo.DataBindings.Add(New Binding("EditValue", BinSrc, "ContadorCliente", True))
        mskFechaInicioAlquiler.DataBindings.Add(New Binding("EditValue", BinSrc, "FechaInicioAlquiler", True))
        txtTiempoContrato.DataBindings.Add(New Binding("EditValue", BinSrc, "TiempoContrato", True))
        txtAdultos.DataBindings.Add(New Binding("EditValue", BinSrc, "Adultos", True))
        txtNinos.DataBindings.Add(New Binding("EditValue", BinSrc, "Niños", True))
        txtSueldoNomina.DataBindings.Add(New Binding("EditValue", BinSrc, "SueldoNomina", True))
        txtSueldoOtros.DataBindings.Add(New Binding("EditValue", BinSrc, "SueldoOtros", True))
        txtAnimales.DataBindings.Add(New Binding("EditValue", BinSrc, "Animales", True))
        txtProfesion.DataBindings.Add(New Binding("EditValue", BinSrc, "Profesion", True))
        txtContratoTrabajo.DataBindings.Add(New Binding("EditValue", BinSrc, "ContratoTrabajo", True))
        txtAntiguedad.DataBindings.Add(New Binding("EditValue", BinSrc, "AntiguedadEmpresa", True))
        txtNacionalidad.DataBindings.Add(New Binding("EditValue", BinSrc, "Nacionalidad", True))
        txtNotas.DataBindings.Add(New Binding("EditValue", BinSrc, "Notas", True))

        Cargando = False
        mskFechaInicioAlquiler.Focus()

        If txtCodigo.Text <> "" Then
            EstoyEnAlta = False
        Else
            EstoyEnAlta = True
            BinSrc.AddNew()
        End If
       
    End Sub

#Region "Mantenimiento Clientes"

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click

        If Actualizar() Then
            GL_FichaAlquiler = 1
            Salir()
        End If


    End Sub
    Private Function Actualizar() As Boolean

        If EstoyEnAlta Then
            txtCodigo.EditValue = ContadorCliente
        End If

        Try
            Me.Validate()
            If Not ComprobarDatos() Then
                Return False
            End If

            BinSrc.EndEdit()

            If Not ActualizarBaseDatos() Then
                Return False
            End If
            Return True
        Catch ex As SqlClient.SqlException
            MensajeError(ex.Message)
            Return False
        Catch ex2 As Exception
            MensajeError(ex2.Message)
            Return False
        End Try
    End Function
    Private Function ActualizarBaseDatos() As Boolean
        Try
            bd.ActualizarCambios(TablaMantenimiento, bd.ds)
            Return True
        Catch ex As SqlClient.SqlException
            If ex.Number = 2627 Then
                MensajeError(GL_ValorDuplicado)
            Else
                MensajeError(ex.Message)
            End If
            Return False
        End Try
    End Function
    Private Function ComprobarDatos() As Boolean
        'se revisara q esten todos los campos necesarios completados
        If GL_FichaAlquiler = 0 Then Return True 'si es baja
        If mskFechaInicioAlquiler.EditValue Is DBNull.Value Then
            MensajeError("Debe indicar la fecha de inicio del alquiler")
            mskFechaInicioAlquiler.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub btnBorrar_Click(sender As System.Object, e As System.EventArgs) Handles btnBorrar.Click
        If BinSrc Is Nothing Then Exit Sub
        If DevExpress.XtraEditors.XtraMessageBox.Show("¿Confirma que quiere eliminar esta ficha?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
            Exit Sub
        End If
        BinSrc.RemoveCurrent()
        GL_FichaAlquiler = 0
        Actualizar()
        Salir()
    End Sub

    Private Sub dgvxClientes_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Try
                Salir()
            Catch ex As Exception
            End Try
        End If
    End Sub

#End Region

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Salir()
    End Sub
    Private Sub Salir()
        Me.Dispose()
    End Sub

End Class







