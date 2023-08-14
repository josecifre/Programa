Public Class frmListados

    Private Sub frmFichaReserva_Load(sender As Object, e As System.EventArgs) Handles Me.Load



    End Sub

    Private Sub dgvxClientes_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Try
                Salir()
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        GL_Listado = "SALIR"
        Salir()
    End Sub
    Private Sub Salir()
        Me.Dispose()
    End Sub

    Private Sub btnClientes_Click(sender As System.Object, e As System.EventArgs) Handles btnClientes.Click
        GL_Listado = "CLIENTES"
        Salir()
    End Sub

    Private Sub btnRevista_Click(sender As System.Object, e As System.EventArgs) Handles btnRevista.Click
        GL_Listado = "REVISTA"
        Salir()
    End Sub

    Private Sub btnMesa_Click(sender As System.Object, e As System.EventArgs) Handles btnMesa.Click
        GL_Listado = "DIRECCIONES"
        Salir()
    End Sub

    Private Sub btnFicha_Click(sender As System.Object, e As System.EventArgs) Handles btnFicha.Click
        GL_Listado = "FICHA"
        Salir()
    End Sub
End Class







