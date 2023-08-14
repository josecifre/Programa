Public Class frmPrestamos

    Private Sub frmFechas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        AparienciaGeneral()

        importe.Focus()

    End Sub

   
    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.Dispose()
    End Sub

   
    Private Sub importe_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles plazos.EditValueChanged, interes.EditValueChanged, importe.EditValueChanged, impMes.EditValueChanged, anos.EditValueChanged
        recalcular()
    End Sub

    Private Sub recalcular()

        If anos.EditValue = 0 Or interes.EditValue = 0 Or importe.EditValue = 0 Then
            Return
        End If
        'plazos.EditValue = importe.EditValue / ((1 - Math.Pow((1 + (interes.EditValue / 100)), -anos.EditValue)) / (interes.EditValue / 100))
        'impMes.EditValue = plazos.EditValue - (importe.EditValue / anos.EditValue)

        impMes.EditValue = Format(Math.Abs(CLng(PPmt(CDbl(interes.EditValue) / 100 / 12, 1, CDbl(anos.EditValue) * 12, CDbl(importe.EditValue)))) + Math.Abs(CLng(IPmt(CDbl(interes.EditValue) / 100 / 12, 1, CDbl(anos.EditValue) * 12, CDbl(importe.EditValue)))), "Standard")
        plazos.EditValue = anos.EditValue * 12
        '        impMes.EditValue = plazos.EditValue - (importe.EditValue / anos.EditValue)

    End Sub
End Class