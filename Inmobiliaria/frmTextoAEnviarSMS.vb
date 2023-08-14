Public Class frmTextoAEnviarSMS


    Private Sub frmHijos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        PintarIconos(Me)
        Me.StartPosition = FormStartPosition.CenterScreen


    End Sub



    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If pf_ComprobarDatos() = False Then
            Exit Sub
        End If

        GL_TextoSMS = TxtDato.Text

        Me.Dispose()

    End Sub

    Private Function pf_ComprobarDatos() As Boolean

        If TxtDato.Text = "" Then
            MsgBox("El texto no puede estar en blanco")
            TxtDato.Focus()
            Return False
        End If

        If TxtDato.Left > 160 Then
            MsgBox("No puede superar los 160 caracteres")
        End If

        Return True

    End Function


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        'GL_TextoAEnviar = ""
        Me.Dispose()
    End Sub

    

    Private Sub TxtDato_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDato.TextChanged
        lblCaracteres.Text = TxtDato.Text.Length.ToString & " Caracteres."
    End Sub
End Class