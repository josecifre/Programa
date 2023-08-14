Public Class frmFiltroDuplicados

    Private Sub frmFechas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AparienciaGeneral()
        rVenta.Checked = True
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        If rVenta.Checked Then GL_VentaAlquiler = "'" & rVenta.Text & "'"
        If rAlquiler.Checked Then GL_VentaAlquiler = "'" & rAlquiler.Text & "'"
        If rVacacional.Checked Then GL_VentaAlquiler = "'" & rVacacional.Text & "'"
        If rTraspaso.Checked Then GL_VentaAlquiler = "'" & rTraspaso.Text & "'"
        If rOpcionACompra.Checked Then GL_VentaAlquiler = "'" & rOpcionACompra.Text & "'"
        GL_VentaAlquiler &= "|"
        If chkVenta.Checked Then GL_VentaAlquiler &= "'" & chkVenta.Text & "'"
        If chkAlquiler.Checked Then GL_VentaAlquiler &= "'" & chkAlquiler.Text & "'"
        If chkVacacional.Checked Then GL_VentaAlquiler &= "'" & chkVacacional.Text & "'"
        If chkTraspaso.Checked Then GL_VentaAlquiler &= "'" & chkTraspaso.Text & "'"
        If chkOpcionACompra.Checked Then GL_VentaAlquiler &= "'" & chkOpcionACompra.Text & "'"
        GL_VentaAlquiler = GL_VentaAlquiler.Replace("''", "','")
        Me.Dispose()
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        GL_VentaAlquiler = ""
        Me.Dispose()
    End Sub

    Private Sub rVenta_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rVenta.CheckedChanged, rAlquiler.CheckedChanged, rVacacional.CheckedChanged, rTraspaso.CheckedChanged, rOpcionACompra.CheckedChanged

        chkVenta.Checked = True
        chkAlquiler.Checked = True
        chkVacacional.Checked = True
        chkTraspaso.Checked = True
        chkOpcionACompra.Checked = True

        Dim r As RadioButton = TryCast(sender, RadioButton)
        Select Case r.Text
            Case GL_Palabra_Venta
                chkVenta.Checked = False
            Case GL_Palabra_Alquiler
                chkAlquiler.Checked = False
            Case "VACACIONAL"
                chkVacacional.Checked = False
            Case "TRASPASO"
                chkTraspaso.Checked = False
            Case "OPCIÓN A COMPRA"
                chkOpcionACompra.Checked = False

        End Select
    End Sub
End Class