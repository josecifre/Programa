Public Class frmWordReport

    Private Sub Salir()
        Me.Dispose()
    End Sub

    Private Sub btnWord_Click(sender As System.Object, e As System.EventArgs) Handles btnWord.Click
        GL_Word = True
        Salir()
    End Sub

    Private Sub btnPantalla_Click(sender As System.Object, e As System.EventArgs) Handles btnPantalla.Click
        GL_Word = False
        Salir()
    End Sub
End Class







