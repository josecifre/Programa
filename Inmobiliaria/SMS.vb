Imports DevExpress.XtraReports.UI

Public Class CL_SMS
    Dim dtsms As DataTable

    Sub CreaDTSMS()
        dtsms = New DataTable("Listado")
        dtsms.Columns.Add("Nombre")
        dtsms.Columns.Add("TelefonoMovil")
        dtsms.Columns.Add("TextoError")
        dtsms.Columns.Add("CodigoError")

    End Sub
    Sub CargaErrorSMS(ByVal Nombre As String, ByVal TelefonoMovil As String, ByVal TextoError As String, ByVal CodigoError As String)
        Dim dr As DataRow = dtsms.NewRow
        dr("Nombre") = Nombre
        dr("TelefonoMovil") = TelefonoMovil
        dr("TextoError") = TextoError
        dr("CodigoError") = CodigoError
        dtsms.Rows.Add(dr)
    End Sub

    Sub MuestraErrorSMS(ByVal Titulo As String)
        Dim r As New rptErrorEnvioSMS

        r.DataSource = dtsms
        r.DataMember = "Listado"
        r.XrLabel1.Text = Titulo
        r.ShowPreview()

    End Sub
End Class