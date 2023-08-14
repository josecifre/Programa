Public Class rptFichaPropietario

    Private Sub txtWeb_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles txtWeb.BeforePrint
        'CType(sender, DevExpress.XtraReports.UI.XRRichText).NavigateUrl = [String].Format(GL_ConfiguracionWeb.PaginaDetalle & "{0}", GetCurrentColumnValue("Referencia"))

        'CType(sender, DevExpress.XtraReports.UI.XRRichText).NavigateUrl = [String].Format(Funciones.EnlaceWeb(BD_CERO.Execute("SELECT Tipo FROM Inmuebles WHERE Contador=" & GetCurrentColumnValue("I.Contador"), False), BD_CERO.Execute("SELECT TipoVenta FROM Inmuebles WHERE Contador=" & GetCurrentColumnValue("I.Contador"), False), BD_CERO.Execute("SELECT Poblacion FROM Inmuebles WHERE Contador=" & GetCurrentColumnValue("I.Contador"), False), GetCurrentColumnValue("Referencia")))

        CType(sender, DevExpress.XtraReports.UI.XRRichText).NavigateUrl = [String].Format(Funciones.EnlaceWeb(GetCurrentColumnValue("Tipo"), GetCurrentColumnValue("TipoVenta"), GetCurrentColumnValue("I.Poblacion"), GetCurrentColumnValue("Referencia"), False))

    End Sub

   
    Private Sub chkAlquilerVacacional_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles chkZComercial.BeforePrint, chkVistasAlMar.BeforePrint, chkUrbanizacion.BeforePrint, chkTerraza.BeforePrint, chkSemiAmueblado.BeforePrint, chkPLineaPlaya.BeforePrint, chkPiscina.BeforePrint, chkPatio.BeforePrint, chkOportunidad.BeforePrint, chkJardin.BeforePrint, chkGaleria.BeforePrint, chkElectrodomesticos.BeforePrint, chkDuplex.BeforePrint, chkCocinaOffice.BeforePrint, chkCalefaccion.BeforePrint, chkBalcon.BeforePrint, chkAscensor.BeforePrint, chkAmueblado.BeforePrint, chkAlquilerVacacional.BeforePrint, chkAireAcondicionado.BeforePrint, chkAccMinusvalidos.BeforePrint, chkPlayaDerecha.BeforePrint, chkMontana.BeforePrint, chkExclusiva.BeforePrint
        Dim a As DevExpress.XtraReports.UI.XRCheckBox = TryCast(sender, DevExpress.XtraReports.UI.XRCheckBox)
        If a.CheckState = CheckState.Indeterminate Then a.CheckState = CheckState.Unchecked
    End Sub

    Private Sub XrLabel25_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrLabel25.BeforePrint
        Dim a As DevExpress.XtraReports.UI.XRLabel = TryCast(sender, DevExpress.XtraReports.UI.XRLabel)
        If a.Text = "-9999999" Then a.Text = 0
    End Sub
End Class