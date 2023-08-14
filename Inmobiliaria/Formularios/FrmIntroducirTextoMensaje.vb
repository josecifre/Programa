Public Class FrmIntroducirTextoMensaje


    

    Private Sub Mantenimiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        PintarIconos(Me)
        Me.Text = "Introduzca texto del mensaje"
        'Me.StartPosition = FormStartPosition.CenterScreen
        'Me.StartPosition = FormStartPosition.Manual
        Me.Top = 275
        Me.Left = 500

        btnAceptar.Enabled = True

    End Sub

    Private Sub pr_HabilitarAceptar()
        btnAceptar.Enabled = True
    End Sub
    Private Sub pr_DesHabilitarAceptar()
        btnAceptar.Enabled = False
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Cancelar()
    End Sub
    Private Sub Cancelar()
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Aceptar()
    End Sub
    Private Sub Aceptar()
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Close()
    End Sub
    

    

    

    

End Class
