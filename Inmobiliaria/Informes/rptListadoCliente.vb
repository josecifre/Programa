Public Class rptListadoCliente

    Private Sub lblReferencia_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles lblReferencia.BeforePrint
        CType(sender, DevExpress.XtraReports.UI.XRLabel).NavigateUrl = [String].Format("http://inmobiliariauim.com/inmuebles.aspx?Referencia={0}", GetCurrentColumnValue("Referencia"))

    End Sub

    Private Sub xrRichText2_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrRichText2.BeforePrint
        If GetCurrentColumnValue("Chollo") = True Then
            DirectCast(sender, DevExpress.XtraReports.UI.XRRichText).Font = New Font("Times New Roman", 9, FontStyle.Bold)
        Else
            DirectCast(sender, DevExpress.XtraReports.UI.XRRichText).Font = New Font("Times New Roman", 9)
        End If

    End Sub

    ''Private Sub lblReferencia_EvaluateBinding(sender As System.Object, e As DevExpress.XtraReports.UI.BindingEventArgs) Handles lblReferencia.EvaluateBinding
    ''    'e.Value = String.Format("http://inmobiliariauim.com/Page.aspx?V1={0}&V2={1}", GetCurrentColumnValue("V1"), GetCurrentColumnValue("V2"))
    ''    '  e.Value = String.Format("http://inmobiliariauim.com/inmuebles.aspx?Referencia={0}", GetCurrentColumnValue("Referencia"))
    ''    e.Value = String.Format("Ref. " & FormatNumber(GetCurrentColumnValue("Referencia"), 0))
    ''End Sub

    ''Private Sub lblReferencia_HtmlItemCreated(sender As Object, e As DevExpress.XtraReports.UI.HtmlEventArgs) Handles lblReferencia.HtmlItemCreated
    ''    e.ContentCell.Controls.Clear()

    ''    Dim hyperLink As New System.Web.UI.WebControls.HyperLink()

    ''    '  hyperLink.Text = "http://inmobiliariauim.com/inmuebles.aspx?Referencia=" & e.Brick.Value.ToString()

    ''    hyperLink.NavigateUrl = "http://inmobiliariauim.com/inmuebles.aspx?Referencia=" & e.Brick.Value.ToString()
    ''    ' type your url here

    ''    e.ContentCell.Controls.Add(hyperLink)
    ''End Sub
    Private Sub Foto1_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles Foto1.BeforePrint


        '       Foto1.ImageUrl = "http://inmobiliariauim.com/fotos/1/" & GetCurrentColumnValue("Referencia") & "/mini/" & GetCurrentColumnValue("Referencia") & "_1.jpg"
        Foto1.ImageUrl = "d:\10321_1.jpg"
        Foto1.NavigateUrl = "http://inmobiliariauim.com/inmuebles.aspx?Referencia=" & GetCurrentColumnValue("Referencia")
        If Foto1.Image Is Nothing Then
            Foto1.ImageUrl = "http://inmobiliariauim.com/fotos/1/NoDisponibleGrande.jpg"
            Foto1.NavigateUrl = ""
        End If



    End Sub
    

End Class