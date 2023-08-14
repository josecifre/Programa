Imports System
Imports System.Drawing
Imports DevExpress.XtraReports.UI
Imports System.Drawing.Printing

 

Public Class rptListadoInmuebles

    

    Private Sub XtraReport1_BeforePrint(ByVal sender As Object, ByVal e As PrintEventArgs) Handles MyBase.BeforePrint

        Detail.SortFields.Add(New GroupField("Precio", XRColumnSortOrder.Ascending))

 
    End Sub
    
    Private Sub xrRichText2_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrRichText2.BeforePrint
        ' CType(sender, DevExpress.XtraReports.UI.XRRichText).NavigateUrl = [String].Format(GL_ConfiguracionWeb.PaginaDetalle & "{0}", GetCurrentColumnValue("Referencia"))

        CType(sender, DevExpress.XtraReports.UI.XRRichText).NavigateUrl = [String].Format(Funciones.EnlaceWeb(BD_CERO.Execute("SELECT Tipo FROM Inmuebles WHERE Contador=" & GetCurrentColumnValue("Contador"), False), BD_CERO.Execute("SELECT TipoVenta FROM Inmuebles WHERE Contador=" & GetCurrentColumnValue("Contador"), False), BD_CERO.Execute("SELECT Poblacion FROM Inmuebles WHERE Contador=" & GetCurrentColumnValue("Contador"), False), GetCurrentColumnValue("Referencia"), False))

        'Dim content As String = GetCurrentColumnValue("Texto")
        'Using ms As New IO.MemoryStream(System.Text.Encoding.GetEncoding("utf-8").GetBytes(content))
        '    XrRichText2.LoadFile(ms, DevExpress.XtraReports.UI.XRRichTextStreamType.HtmlText)
        'End Using

        'If GetCurrentColumnValue("Oportunidad") = True Then

        '    Dim Rich As DevExpress.XtraReports.UI.XRRichText
        '    Rich = DirectCast(sender, DevExpress.XtraReports.UI.XRRichText)
        '    Rich.Font = New Font("Times New Roman", Rich.Font.Size, FontStyle.Bold)
        'Else

        '    Dim Rich As DevExpress.XtraReports.UI.XRRichText
        '    Rich = DirectCast(sender, DevExpress.XtraReports.UI.XRRichText)
        '    Rich.Font = New Font("Times New Roman", Rich.Font.Size, FontStyle.Regular)

        'End If




    End Sub

    ''Private Sub lblReferencia_EvaluateBinding(sender As System.Object, e As DevExpress.XtraReports.UI.BindingEventArgs) Handles lblReferencia.EvaluateBinding
    ''    'e.Value = String.Format("http://inmobiliariauim.com/Page.aspx?V1={0}&V2={1}", GetCurrentColumnValue("V1"), GetCurrentColumnValue("V2"))
    ''    '  e.Value = String.Format("http://inmobiliariauim.com/inmuebles.aspx?Referencia={0}", GetCurrentColumnValue("Referencia"))
    ''    e.Value = String.Format("Ref. " & FormatNumber(GetCurrentColumnValue("Referencia"), 0))
    ''End Sub

    'Private Sub lblReferencia_HtmlItemCreated(sender As Object, e As DevExpress.XtraReports.UI.HtmlEventArgs) Handles lblReferencia.HtmlItemCreated
    '    e.ContentCell.Controls.Clear()

    '    Dim hyperLink As New System.Web.UI.WebControls.HyperLink()

    '    '  hyperLink.Text = "http://inmobiliariauim.com/inmuebles.aspx?Referencia=" & e.Brick.Value.ToString()

    '    hyperLink.NavigateUrl = "http://inmobiliariauim.com/inmuebles.aspx?Referencia=" & e.Brick.Value.ToString()
    '    ' type your url here

    '    e.ContentCell.Controls.Add(hyperLink)
    'End Sub
    Private Sub Foto1_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles Foto1.BeforePrint


        'Foto1.ImageUrl = "http://inmobiliariauim.com/fotos/1/" & GetCurrentColumnValue("Referencia") & "/mini/" & GetCurrentColumnValue("Referencia") & "_1.jpg"
        ' Foto1.ImageUrl = "d:\10321_1.jpg"

        'ESTO ES PARA COGER LAS FOTOS DEL SERVIDOR EN VEZ DE DE LA WEB.
        'LO COMENTO MOMENTANEAMENTE POR QUE GENERA UNOS FICHERO MUY GRANDES
        'Dim Carpeta As String
        'Carpeta = GL_CarpetaFotos & "\" & GetCurrentColumnValue("ContadorPropietario").ToString & "-" & GetCurrentColumnValue("Referencia")

        'Dim TodoOK As Boolean = False
        'If System.IO.Directory.Exists(Carpeta) Then
        '    If GetCurrentColumnValue("FotoPrincipal").ToString <> "" Then
        '        If System.IO.File.Exists(Carpeta & "\" & GetCurrentColumnValue("FotoPrincipal").ToString) Then
        '            Foto1.ImageUrl = Carpeta & "\" & GetCurrentColumnValue("FotoPrincipal").ToString
        '            TodoOK = True
        '        Else
        '            Dim Fotos() As String = System.IO.Directory.GetFiles(Carpeta)
        '            If Fotos.Count > 0 Then
        '                Foto1.ImageUrl = Fotos(0)
        '                TodoOK = True
        '            End If
        '        End If
        '    Else
        '        Dim Fotos() As String = System.IO.Directory.GetFiles(Carpeta)
        '        If Fotos.Count > 0 Then
        '            Foto1.ImageUrl = Fotos(0)
        '            TodoOK = True
        '        End If
        '    End If
        'End If

        'If Not TodoOK Then
        '    Foto1.ImageUrl = "http://inmobiliariauim.com/fotos/1/NoDisponibleGrande.jpg"
        'End If
        'FIN ESTO ES PARA COGER LAS FOTOS DEL SERVIDOR EN VEZ DE DE LA WEB.
        'LO COMENTO MOMENTANEAMENTE POR QUE GENERA UNOS FICHERO MUY GRANDES

        Foto1.Image = Nothing
        If System.IO.File.Exists(GL_CarpetaFotos & "/" & GetCurrentColumnValue("Referencia") & "/" & GetCurrentColumnValue("FotoPrincipal")) Then
            Foto1.Image = Funciones.redimensionaimagen(Image.FromStream(New IO.MemoryStream(IO.File.ReadAllBytes(GL_CarpetaFotos & "/" & GetCurrentColumnValue("Referencia") & "/" & GetCurrentColumnValue("FotoPrincipal")))), 130, 100, False)
        End If
        If Foto1.Image Is Nothing Then
            If System.IO.File.Exists(clVariables.RutaServidor & "\NoDisponiblePequena.jpg") Then
                Foto1.Image = Funciones.redimensionaimagen(Image.FromStream(New IO.MemoryStream(IO.File.ReadAllBytes(clVariables.RutaServidor & "\NoDisponiblePequena.jpg"))), 130, 100, False)
            End If
            
        End If


        '    Foto1.ImageUrl = "http://" & GL_ConfiguracionWeb.DirectorioFotos & "/fotos/1/" & GetCurrentColumnValue("Referencia") & "/mini/" & GetCurrentColumnValue("FotoPrincipal") & "_1.jpg"
        '    Foto1.NavigateUrl = GL_ConfiguracionWeb.PaginaDetalle & GetCurrentColumnValue("Referencia")
        'If Foto1.Image Is Nothing Then
        '    Foto1.ImageUrl = "http://" & GL_ConfiguracionWeb.DirectorioFotos & "fotos/1/NoDisponibleGrande.jpg"
        '    Foto1.NavigateUrl = ""
        'End If



    End Sub


End Class