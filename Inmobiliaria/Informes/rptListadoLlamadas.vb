Public Class rptListadoLlamadas
    Private Sub lblNumero_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles lblNumero.BeforePrint
        lblNumero.Text = CInt(lblNumero.Text) + 1
    End Sub
End Class