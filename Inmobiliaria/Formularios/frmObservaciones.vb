Public Class frmObservaciones 

    Public Tipo As String = ""
     
    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click


        If txtTexto.Text.Trim = "" Then
            If Tipo = "COMUNICADO" Then
                GL_Observaciones = ""
            Else
                GL_Observaciones = Gl_ResultadoBusqueda_SALIR
            End If

        Else
            GL_Observaciones = txtTexto.Text.Trim
        End If

        Me.Dispose()
    End Sub
    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        GL_Observaciones = Gl_ResultadoBusqueda_SALIR
        Me.Dispose()

    End Sub

    
   
End Class