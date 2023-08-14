Imports System.IO
Imports DevExpress.Utils.Serializing
Imports DevExpress.XtraBars.ColorPick.Popup
Imports DevExpress.XtraBars.Ribbon.ViewInfo
Imports DevExpress.XtraEditors.ColorPick.Picker
Imports RestSharp
Imports WordPressPCL
Imports WordPressPCL.Models

Module WordPress
#Region "Generales"

    Public Function WP_Alta_Modificar_General(Tabla As String, Valor As String, Id_WP As Integer, Optional ObtenerToken As Boolean = True, Optional Eliminar As Boolean = False, Optional IdParent As Integer = 0) As Integer

        Dim Res2 As New Tablas.clWPCreado
        Dim Res As Tablas.clResultado

        If ObtenerToken Then
            GL_TokenWP = ObtenerTokenWP()
        End If


        Dim dato As Tablas.clNombre
        Dim postData As String = ""


        If Not Eliminar Then

            dato = New Tablas.clNombre(StrConv(Valor, VbStrConv.ProperCase), IdParent)
            postData = SerializarPost(dato)
        End If



        'If IdParent <> 0 Then
        '    dato = New Tablas.clNombre(StrConv(Valor, VbStrConv.ProperCase), IdParent)
        '    postData = SerializarPost(dato)
        'End If


        Dim Funcion As String = ""

        Select Case Tabla
            Case "Tipo"
                Funcion = GL_ConfiguracionWeb.API_WP_Funcion_Tipos


            Case "TipoVenta"
                Funcion = GL_ConfiguracionWeb.API_WP_Funcion_TipoVentas


            Case "Poblacion", "Zona"
                Funcion = GL_ConfiguracionWeb.API_WP_Funcion_Poblacion

        End Select

        If Id_WP = 0 Then
            Res = WordPressPost(Funcion, postData,,, False)
        Else
            Res = WordPressPost(Funcion & "/" & Id_WP, postData, Eliminar)
        End If


        If Res.Codigo = 0 Then
            Res2 = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Tablas.clWPCreado)(Res.Mensaje)
            Id_WP = Res2.id
        Else
            Dim Res3 As New Tablas.clErrorWP
            Res3 = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Tablas.clErrorWP)(Res.Mensaje)
            MensajeInformacion("Error al comunicar con la web. " & vbCrLf & "Inténtelo más tarde" & vbCrLf & Res3.message)
            Id_WP = -1
        End If

        Return Id_WP

    End Function

    Public Function WP_Eliminar_General(Tabla As String, Id_WP As Integer, Optional ObtenerToken As Boolean = True) As Boolean

        Dim Resultado As Boolean


        Try


            Dim Res As Tablas.clResultado

            If ObtenerToken Then
                GL_TokenWP = ObtenerTokenWP()
            End If


            Dim Funcion As String = ""

            Select Case Tabla

                Case "Inmuebles"
                    Funcion = GL_ConfiguracionWeb.API_WP_Funcion_Propiedades

                Case "Tipo"
                    Funcion = GL_ConfiguracionWeb.API_WP_Funcion_Tipos


                Case "TipoVenta"
                    Funcion = GL_ConfiguracionWeb.API_WP_Funcion_TipoVentas


                Case "Poblacion", "Zona"
                    Funcion = GL_ConfiguracionWeb.API_WP_Funcion_Poblacion

            End Select

            Funcion = Funcion & "/" & Id_WP
            Res = WordPressPost(Funcion, "", True,, False)


            If Res.Codigo = 0 Then
                Resultado = True
                'Res2 = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Tablas.clWPCreado)(Res.Mensaje)
                'Id_WP = Res2.id
            Else
                Resultado = False
                'Dim Res3 As New Tablas.clErrorWP
                'Res3 = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Tablas.clErrorWP)(Res.Mensaje)
                'MensajeInformacion("Error al comunicar con la web. " & vbCrLf & "Inténtelo más tarde" & vbCrLf & Res3.message)
                'Id_WP = -1
            End If
        Catch ex As Exception
            Resultado = False
        End Try

        Return Resultado

    End Function
#End Region
    Public Function WordPressPost(Funcion As String, PostData As String, Optional Delete As Boolean = False, Optional put As Boolean = False, Optional ObtenerToken As Boolean = True) As Tablas.clResultado

        Dim Res As New Tablas.clResultado

        Try

            If ObtenerToken Or IsNothing(GL_TokenWP) Then
                GL_TokenWP = ObtenerTokenWP()
            End If


            System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls12 Or Net.SecurityProtocolType.Tls11 Or Net.SecurityProtocolType.Tls


            Dim request As RestRequest

            If put Then
                request = New RestRequest(Method.[PUT])
            Else
                If Delete Then
                    request = New RestRequest(Method.[DELETE])
                    Funcion = Funcion & "?force=true"
                Else
                    request = New RestRequest(Method.[POST])
                End If

            End If

            'GL_ConfiguracionWeb.API_WP = "https://inmobiliariauim.com/wp-json/wp/v2/"

            Dim client = New RestClient(GL_ConfiguracionWeb.API_WP & Funcion)
            'GL_TokenWP = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwczpcL1wvcHJ1ZWJhc2lubW9iaWxpYXJpYXMudHJlc2JpdHMuZXMiLCJpYXQiOjE1OTUxNTU0MTEsIm5iZiI6MTU5NTE1NTQxMSwiZXhwIjoxNTk1NzYwMjExLCJkYXRhIjp7InVzZXIiOnsiaWQiOiIxIn19fQ.VYvvcryo_Jes6hRle_VviVoQV841VI0eBdilnYbeBb4"
            request.AddHeader("Authorization", "Bearer " + GL_TokenWP)
            'If Funcion.ToUpper = "MEDIA" Then
            '    request.AddHeader("Content-Type", "image/png")
            '    request.AddHeader("Content-Disposition", "attachment; filename=tmp")
            '    'request.AddHeader("Content-Disposition", "form-data; filename=C:\Compartida\Jose\admin.png")
            '    'request.AddFile("media", "C:\Compartida\Venalia2\Fotos\2\27189\1.jpg")

            '    'Dim s As Stream = File.OpenRead("C:\Compartida\Venalia2\Fotos\2\27189\1.jpg")
            '    'request.AddFileBytes("tmp", IO.File.ReadAllBytes("C:\Compartida\Venalia2\Fotos\2\27189\1.jpg"), "ll", "image/jpg")
            '    'request.AddFileBytes("tmp", IO.File.ReadAllBytes("C:\Compartida\Jose\admin.png"), "C:\Compartida\Jose\admin.png", "image/png")
            '    'request.AddFile("tmp", "C:\Compartida\Jose\admin.png")
            '    'admin.png
            '    'request.AddFile("tmp", IO.File.ReadAllBytes("C:\Compartida\Venalia2\Fotos\2\27189\2tt.jpg"), "ll", "image/jpg")
            '    'request.AddHeader("data", "C:\Compartida\Jose\admin.png")
            'Else

            'End If

            request.AddHeader("content-type", "application/json")

            If PostData <> "" Then
                request.AddParameter("application/json", PostData, ParameterType.RequestBody)
                'request.AddBody(PostData)
            End If
            '   request.AddParameter("application/json", "{""""Email"""":""""pruebas1@idoneapp.com""""}", ParameterType.RequestBody)
            Dim response As IRestResponse = client.Execute(request)


            If response.StatusCode = 200 Or response.StatusCode = 201 Then
                Res.Mensaje = response.Content
                Res.Codigo = 0
                Res.InformacionAdicional = ""
            Else
                Res.Mensaje = response.Content
                Res.Codigo = -1
                Res.InformacionAdicional = response.StatusDescription
            End If

        Catch ex4 As ServiceModel.FaultException(Of Tablas.clResultado)
            Res.Codigo = ex4.Code.ToString
            Res.Mensaje = ex4.Reason.ToString

        Catch ex5 As Net.WebException
            Res.Codigo = -1
            Res.Mensaje = ex5.Message

        Catch ex As Exception
            Res.Codigo = -2
            Res.Mensaje = ex.Message
        End Try

        Return Res




    End Function
    Private Function WordPressObtenerToken() As Tablas.clResultado

        Dim Res As New Tablas.clResultado

        Try
            'GL_ConfiguracionWeb.Web = "https://www.invinja.es"
            'GL_ConfiguracionWeb.Web = "https://inmobiliariauim.com"
            System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls12 Or Net.SecurityProtocolType.Tls11 Or Net.SecurityProtocolType.Tls
            Dim client = New RestClient(GL_ConfiguracionWeb.Web & "/wp-json/jwt-auth/v1/token?username=" & GL_ConfiguracionWeb.Usuario & "&password=" & GL_ConfiguracionWeb.Pass)
            Dim request As RestRequest
            request = New RestRequest(Method.[POST])

            'request.AddHeader("Authorization", "Token " + GL_TokenWP)
            request.AddHeader("content-type", "application/json")
            'If PostData <> "" Then
            '    request.AddParameter("application/json", PostData, ParameterType.RequestBody)
            'End If
            'request.AddParameter("application/json", "{""""username"""":""""admin""""}", ParameterType.HttpHeader)
            'request.AddParameter("application/json", "{""""password"""":""""8w4IlO7H9qpjTOBDEEi0""""}", ParameterType.RequestBody)
            'request.RequestFormat = DataFormat.Json
            Dim response As IRestResponse = client.Execute(request)


            If response.StatusDescription = "OK" Then
                Res.Mensaje = response.Content
                Res.Codigo = 0
                Res.InformacionAdicional = ""
            Else
                Res.Mensaje = response.Content
                Res.Codigo = -1
                Res.InformacionAdicional = response.StatusDescription
            End If

        Catch ex4 As ServiceModel.FaultException(Of Tablas.clResultado)
            Res.Codigo = ex4.Code.ToString
            Res.Mensaje = ex4.Reason.ToString

        Catch ex5 As Net.WebException
            Res.Codigo = -1
            Res.Mensaje = ex5.Message

        Catch ex As Exception
            Res.Codigo = -2
            Res.Mensaje = ex.Message
        End Try

        Return Res




    End Function
#Region "Fotos"


    Public Async Sub WPEnviarFoto(RutaImagen As String, WP_IdProperty As Integer, ContadorInmueble As Integer)
        'Dim client = New WordPressClient(GL_ConfiguracionWeb.API_WP.Replace("wp/v2/", ""))
        'Dim posts = Await client.Posts.GetAll()
        'Dim postbyid = Await client.Posts.GetByID(id)
        'Dim comments = Await client.Comments.GetAll()
        'Dim commentbyid = Await client.Comments.GetByID(id)
        'Dim commentsbypost = Await client.Comments.GetCommentsForPost(postid, True, False)
        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 Or System.Net.SecurityProtocolType.Tls11 Or System.Net.SecurityProtocolType.Tls
        Dim Sel As String
        Sel = "SELECT Referencia FROM Inmuebles WHERE Contador = " & ContadorInmueble
        Dim Referencia As String = BD_CERO.Execute(Sel, False, "")

        Dim ApiCredentials As New Tablas.ApiCredentials
        Dim client = New WordPressClient(ApiCredentials.WordPressUri)
        client.AuthMethod = AuthMethod.JWT
        Await client.RequestJWToken(ApiCredentials.Username, ApiCredentials.Password)
        Dim isValidToken = Await client.IsValidJWToken()

        'RutaImagen = "D:\EnDesarrolloEntregados\Venalia\Programa\Inmobiliaria\bin\Debug\Fotos\4\16600330\11100734_1.jpg"
        Dim s As Stream = File.OpenRead(RutaImagen)

        Dim createdMedia = Await client.Media.Create(s, "media.jpg")
        GL_TokenWP = ObtenerTokenWP()



        Dim postData As String


        Dim Res As Tablas.clResultado
        Dim ResImagen As Tablas.cl_WP_Media
        Dim SourceURL As String = ""

        postData = SerializarPost(WP_IdProperty, "post")
        Res = WordPressPost("media/" & createdMedia.Id, postData, ,, False)

        If Res.Codigo = 0 Then
            ResImagen = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Tablas.cl_WP_Media)(Res.Mensaje)
            SourceURL = ResImagen.source_url

        Else


            InsertarMovimientosWP(Referencia, "INSERTAR FOTO", Res.Codigo, "ERROR", Res.Mensaje)
        End If


        postData = SerializarPost(createdMedia.Id, "REAL_HOMES_property_images")
        WordPressPost(GL_ConfiguracionWeb.API_WP_Funcion_Propiedades & "/" & WP_IdProperty, postData, False)



        'dato = "{""REAL_HOMES_property_images"":""" & "" & createdMedia.Id & """}"
        'postData = SerializarPost(dato)
        'WordPressPost("GL_ConfiguracionWeb.API_WP_Funcion_Propiedades & "/" & WP_IdProperty, postData)



        ''WordPressPost(GL_ConfiguracionWeb.API_WP_Funcion_Propiedades & "/" & WP_IdProperty, "{""REAL_HOMES_property_images"":""" & createdMedia.Id & "}")


        'dato = "{""post"":""" & WP_IdProperty & "}"
        'postData = SerializarPost(dato)
        'WordPressPost("media/" & createdMedia.Id, postData)


        Sel = "INSERT INTO WP_FOTOS (IdFoto, IdProperty, ContadorInmueble,Fichero,Principal,SourceURL,AsignadoAWeb) VALUES ( " &
              createdMedia.Id &
              ", " & WP_IdProperty &
              ", " & ContadorInmueble &
              ", '" & My.Computer.FileSystem.GetName(RutaImagen) & "'" &
              ",0 " &
              ", '" & SourceURL & "'" &
              ",0" &
              ")"

        BD_CERO.Execute(Sel)


        InsertarMovimientosWP(Referencia, "INSERTAR FOTO", Res.Codigo, "", "Id Foto: " & createdMedia.Id)

    End Sub

    'Public Sub WPEnviarFoto2(RutaImagen As String, WP_IdProperty As Integer, ContadorInmueble As Integer)
    '    'Dim client = New WordPressClient(GL_ConfiguracionWeb.API_WP.Replace("wp/v2/", ""))
    '    'Dim posts = Await client.Posts.GetAll()
    '    'Dim postbyid = Await client.Posts.GetByID(id)
    '    'Dim comments = Await client.Comments.GetAll()
    '    'Dim commentbyid = Await client.Comments.GetByID(id)
    '    'Dim commentsbypost = Await client.Comments.GetCommentsForPost(postid, True, False)




    '    Dim ApiCredentials As New Tablas.ApiCredentials
    '    Dim client = New WordPressClient(ApiCredentials.WordPressUri)
    '    client.AuthMethod = AuthMethod.JWT
    '    client.RequestJWToken(ApiCredentials.Username, ApiCredentials.Password)


    '    'Dim isValidToken = Await client.IsValidJWToken()

    '    'RutaImagen = "D:\EnDesarrolloEntregados\Venalia\Programa\Inmobiliaria\bin\Debug\Fotos\4\16600330\11100734_1.jpg"
    '    Dim s As Stream = File.OpenRead(RutaImagen)

    '    Dim createdMedia = client.Media.Create(s, "media.jpg")
    '    GL_TokenWP = ObtenerTokenWP()

    '    Dim postData As String
    '    postData = SerializarPost(WP_IdProperty, "post")
    '    WordPressPost("media/" & createdMedia.Id, postData, ,, False)



    '    Dim Sel As String
    '    Sel = "INSERT INTO WP_FOTOS (IdFoto, IdProperty, ContadorInmueble,Fichero,Principal) VALUES ( " &
    '          createdMedia.Id &
    '          ", " & WP_IdProperty &
    '          ", " & ContadorInmueble &
    '          ", '" & My.Computer.FileSystem.GetName(RutaImagen) & "'" &
    '          ",0 " &
    '          ")"

    '    BD_CERO.Execute(Sel)




    '    'Dim p As New WordPressPCL.Models.Page
    '    'p.Parent = 3908

    '    'Dim posts = Await client.Posts.GetAll()
    '    ''Dim response = client.Posts.Delete(postid)
    '    'Dim postbyid = Await client.Posts.GetByID(3908)
    'End Sub


    'Public Async Sub WPEliminarFoto_Async(WP_IdFotos As Integer)

    '    Dim ApiCredentials As New Tablas.ApiCredentials
    '    Dim client = New WordPressClient(ApiCredentials.WordPressUri)
    '    client.AuthMethod = AuthMethod.JWT
    '    Await client.RequestJWToken(ApiCredentials.Username, ApiCredentials.Password)
    '    Dim isValidToken = Await client.IsValidJWToken()

    '    Dim createdMedia = Await client.Media.Delete(WP_IdFotos)

    '    If createdMedia Then
    '        Dim Sel As String
    '        Sel = "DELETE FROM WP_FOTOS WHERE IdFoto = " & WP_IdFotos
    '        BD_CERO.Execute(Sel)
    '    End If



    'End Sub

    Public Sub WPEliminarFotosInmueble(ContadorInmueble As Integer)

        Dim Sel As String
        Dim bdFotos As New BaseDatos

        Sel = "SELECT IdFoto FROM WP_FOTOS WP_F WHERE WP_F.ContadorInmueble = " & ContadorInmueble
        bdFotos.LlenarDataSet(Sel, "T")

        For i = 0 To bdFotos.ds.Tables("T").Rows.Count - 1
            WPEliminarFoto(bdFotos.ds.Tables("T").Rows(i)("IdFoto"))
        Next



    End Sub

    Public Sub WPEliminarFoto(WP_IdFotos As Integer)

        Dim Res As Tablas.clResultado
        Res = WordPressPost("media/" & WP_IdFotos, "", True)

        Dim Referencia As String = ObtenerReferenciaDesdeIdFoto(WP_IdFotos)

        InsertarMovimientosWP(Referencia, "ELIMINAR FOTO", Res.Codigo, "", "")

        If Res.Codigo = 0 Then
            Dim Sel As String
            Sel = "DELETE FROM WP_FOTOS WHERE IdFoto = " & WP_IdFotos
            BD_CERO.Execute(Sel)
        End If


    End Sub

    Public Function ObtenerReferenciaDesdeIdFoto(IdFoto As Integer) As String

        Dim Sel As String
        Dim Referencia As String

        Sel = "SELECT Referencia FROM Inmuebles I INNER JOIN WP_FOTOS WP_F ON I.Contador = WP_F.ContadorInmueble WHERE IdFoto = " & IdFoto
        Referencia = BD_CERO.Execute(Sel, False, "")

        Return Referencia



    End Function

    Public Function ObtenerIdFoto_Desde_IdPropertyYFichero(IdProperty As Integer, Fichero As String) As Integer

        Dim Id_WP_Foto As Integer
        Dim Sel As String
        Sel = "SELECT IdFoto FROM WP_FOTOS WHERE IdProperty = " & IdProperty & " AND Fichero = '" & Funciones.pf_ReplaceComillas(Fichero) & "'"
        Id_WP_Foto = BD_CERO.Execute(Sel, False, 0)


        Return Id_WP_Foto



    End Function


    Public Sub WPActualizarREAL_HOMES_property_images(WP_IdProperty As Integer)

        Dim postData As String

        postData = SerializarPost("", "REAL_HOMES_property_images")
        WordPressPost(GL_ConfiguracionWeb.API_WP_Funcion_Propiedades & "/" & WP_IdProperty, postData)

        Dim Sel As String
        Sel = "SELECT IdFoto FROM WP_FOTOS WHERE IdProperty = " & WP_IdProperty
        Dim bdFotos As New BaseDatos
        bdFotos.LlenarDataSet(Sel, "T")

        For i = 0 To bdFotos.ds.Tables("T").Rows.Count - 1
            postData = SerializarPost(bdFotos.ds.Tables("T").Rows(i)("IdFoto").ToString, "REAL_HOMES_property_images")
            WordPressPost(GL_ConfiguracionWeb.API_WP_Funcion_Propiedades & "/" & WP_IdProperty, postData, ,, False)
        Next

    End Sub

#End Region

    Public Function ObtenerTokenWP() As String

        Dim TokenWP As String = ""

        If DatosEmpresa.WordPress Then
            Dim Res2 As New Tablas.clTokenWP
            Dim Res As Tablas.clResultado = WordPressObtenerToken()

            If Res.Codigo = 0 Then
                Res2 = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Tablas.clTokenWP)(Res.Mensaje)
                TokenWP = Res2.token
            Else
                TokenWP = ""

            End If
        End If

        Return TokenWP

    End Function

    Private Function WP_ObtenerListaDetails(Inmueble As WebServiceVenalia.clInmueblesAlta) As Tablas.cl_wp_REALHOMESAdditionalDetails


        Dim wp_REALHOMESAdditionalDetails2 As New Tablas.cl_wp_REALHOMESAdditionalDetails
        wp_REALHOMESAdditionalDetails2.Detalles = ""

        Dim ListaPropos As New List(Of Integer)
        Dim ListaOTrosCampos As New List(Of String)
        Dim Sel As String

        Dim bdPrestaciones As BaseDatos
        Dim dtPrestaciones As DataTable

        Sel = "SELECT * FROM WP_DetallesAdicionales WHERE CodigoEmpresa = " & DatosEmpresa.Codigo
        bdPrestaciones = New BaseDatos
        bdPrestaciones.LlenarDataSet(Sel, "T")
        dtPrestaciones = bdPrestaciones.ds.Tables("T")

        Dim Select2 As String = ""

        For i = 0 To dtPrestaciones.Rows.Count - 1
            'If dtPrestaciones.Rows(i)("Campo").ToString.ToUpper = "AnoConstruccion" Then

            '    wp_Detail = New Tablas.StrStr
            '    wp_Detail.Nombre = "Construido en"
            '    wp_Detail.Descripcion = Inmueble.AnoConstruccion
            '    wp_REALHOMESAdditionalDetails2.Add(wp_Detail)
            'Else
            ListaOTrosCampos.Add(bdPrestaciones.ds.Tables(0).Rows(i)("Campo"))
            'End If
        Next

        If ListaOTrosCampos.Count > 0 Then
            For i = 0 To ListaOTrosCampos.Count - 1
                Select2 = Select2 & ", " & ListaOTrosCampos(i)
            Next

            Select2 = Select2.Substring(1)

            Sel = "SELECT " & Select2 & " FROM Inmuebles WHERE Contador = " & Inmueble.Contador
            Dim bdInmu As New BaseDatos
            bdInmu.LlenarDataSet(Sel, "T")
            Dim dtbdInmu As DataTable = bdInmu.ds.Tables("T")


            For i = 0 To ListaOTrosCampos.Count - 1
                If Not IsDBNull(dtbdInmu.Rows(0)(ListaOTrosCampos(i))) AndAlso dtbdInmu.Rows(0)(ListaOTrosCampos(i)) Then
                    Dim CampoDetalle As String = CambiarCamposDetalles(ListaOTrosCampos(i))
                    wp_REALHOMESAdditionalDetails2.Detalles = wp_REALHOMESAdditionalDetails2.Detalles & " - " & CampoDetalle
                End If
            Next
        End If

        If wp_REALHOMESAdditionalDetails2.Detalles.Length > 0 Then
            wp_REALHOMESAdditionalDetails2.Detalles = wp_REALHOMESAdditionalDetails2.Detalles.Substring(3)
        End If


        Return wp_REALHOMESAdditionalDetails2
    End Function

    Private Function WP_ObtenerListaPrestaciones(Inmueble As WebServiceVenalia.clInmueblesAlta) As List(Of Integer)


        Dim ListaPropos As New List(Of Integer)
        'Dim ListaOTrosCampos As New List(Of String)
        Dim Sel As String

        Dim bdPrestaciones As BaseDatos
        Dim dtPrestaciones As DataTable

        Dim IdBalcon As Integer = 0
        Sel = "SELECT * FROM WP_Prestaciones WHERE (Campo = 'Balcon' or Campo = 'Balcón') AND CodigoEmpresa = " & DatosEmpresa.Codigo
        IdBalcon = BD_CERO.Execute(Sel, False)

        Sel = "SELECT * FROM WP_Prestaciones WHERE CodigoEmpresa = " & DatosEmpresa.Codigo
        If DatosEmpresa.Codigo = 2 Then
            Sel = Sel & " UNION ALL SELECT 7,2,'Patio', " & IdBalcon
        End If
        bdPrestaciones = New BaseDatos
        bdPrestaciones.LlenarDataSet(Sel, "T")
        dtPrestaciones = bdPrestaciones.ds.Tables("T")

        Dim Select2 As String = ""

        For i = 0 To dtPrestaciones.Rows.Count - 1
            Select2 = Select2 & ", " & dtPrestaciones.Rows(i)("Campo")
        Next

        If Select2 <> "" Then
            Select2 = Select2.Substring(1)
            If DatosEmpresa.Codigo = 2 Then
                Select2 = Select2 & ",Patio"
            End If

            Sel = "SELECT " & Select2 & " FROM Inmuebles WHERE Contador = " & Inmueble.Contador
            Dim bdInmu As New BaseDatos
            bdInmu.LlenarDataSet(Sel, "T")
            Dim dtbdInmu As DataTable = bdInmu.ds.Tables("T")

            Dim IdCocinaIndependiente As Integer = 0
            Dim CocinaOffice As Boolean = False

            For i = 0 To dtPrestaciones.Rows.Count - 1
                If Not IsDBNull(dtbdInmu.Rows(0)(dtPrestaciones.Rows(i)("Campo"))) AndAlso dtbdInmu.Rows(0)(dtPrestaciones.Rows(i)("Campo")) Then
                    If dtPrestaciones.Rows(i)("Campo").ToString.ToUpper = "COCINAOFFICE" Then
                        CocinaOffice = True
                        Continue For
                    End If

                    If dtPrestaciones.Rows(i)("Id_WP") = IdBalcon Then
                        If Not ListaPropos.Contains(IdBalcon) Then
                            ListaPropos.Add(dtPrestaciones.Rows(i)("Id_WP"))
                        End If
                    Else
                        ListaPropos.Add(dtPrestaciones.Rows(i)("Id_WP"))

                    End If

                Else
                    'MsgBox("")
                End If
            Next
            If Not CocinaOffice Then
                'IdCocinaIndependiente = dtPrestaciones.Rows(i)("Id_WP")
                Dim rows() As DataRow
                rows = dtPrestaciones.Select("Campo = 'CocinaOffice'")
                If rows.Length > 0 Then
                    ListaPropos.Add(rows(0)("Id_WP"))
                End If

            End If
        End If


        Return ListaPropos
    End Function

    'Private Function WP_ObtenerListaPrestaciones(Inmueble As WebServiceVenalia.clInmueblesAlta) As List(Of Integer)

    '    Dim ListaPropos As New List(Of Integer)
    '    Dim ListaOTrosCampos As New List(Of String)
    '    Dim Sel As String

    '    Dim bdPrestaciones As BaseDatos
    '    Dim dtPrestaciones As DataTable

    '    Sel = "SELECT * FROM WP_Prestaciones WHERE CodigoEmpresa = " & DatosEmpresa.Codigo
    '    bdPrestaciones = New BaseDatos
    '    bdPrestaciones.LlenarDataSet(Sel, "T")
    '    dtPrestaciones = bdPrestaciones.ds.Tables("T")

    '    Dim Select2 As String = ""

    '    For i = 0 To dtPrestaciones.Rows.Count - 1
    '        'If dtPrestaciones.Rows(i)("Campo").ToString.ToUpper = "PATIO" Or dtPrestaciones.Rows(i)("Campo").ToString.ToUpper = "BALCON" Then
    '        '    If Inmueble.Balcon Or Inmueble.Patio Then
    '        '        ListaPropos.Add(bdPrestaciones.ds.Tables(0).Rows(i)("Id_WP"))
    '        '    End If
    '        'Else
    '        ListaOTrosCampos.Add(bdPrestaciones.ds.Tables(0).Rows(i)("Campo"))
    '        'If dtPrestaciones.Rows(i)("Campo").ToString.ToUpper = "COCINAOFFICE" Then
    '        '    If Not Inmueble.CocinaOffice Then
    '        '        ListaPropos.Add(bdPrestaciones.ds.Tables(0).Rows(i)("Id_WP"))
    '        '    End If
    '        'Else
    '        '    ListaOTrosCampos.Add(bdPrestaciones.ds.Tables(0).Rows(i)("Campo"))

    '        'End If

    '        'End If
    '    Next

    '    If ListaOTrosCampos.Count > 0 Then
    '        For i = 0 To ListaOTrosCampos.Count - 1
    '            Select2 = Select2 & ", " & ListaOTrosCampos(i)
    '        Next


    '        Select2 = Select2.Substring(1)

    '        Sel = "SELECT " & Select2 & " FROM Inmuebles WHERE Contador = " & Inmueble.Contador
    '        Dim bdInmu As New BaseDatos
    '        bdInmu.LlenarDataSet(Sel, "T")
    '        Dim dtbdInmu As DataTable = bdInmu.ds.Tables("T")

    '        Dim CocinaIndependiente As Boolean = True

    '        For i = 0 To ListaOTrosCampos.Count - 1
    '            If dtbdInmu.Rows(0)(ListaOTrosCampos(i)) Then
    '                If ListaOTrosCampos(i).ToString.ToUpper = "COCINAOFFICE" Then
    '                    CocinaIndependiente = False
    '                    Continue For
    '                End If
    '                'Dim CampoDetalle As String = CambiarCamposDetalles(bdPrestaciones.ds.Tables(0).Rows(i)("Id_WP"))
    '                'ListaPropos.Add(CampoDetalle)
    '                ListaPropos.Add(bdPrestaciones.ds.Tables(0).Rows(i)("Id_WP"))
    '            End If
    '        Next
    '        If CocinaIndependiente Then
    '            ListaPropos.Add("Cocina Independiente")
    '        End If
    '    End If



    '    Return ListaPropos
    'End Function
    Public Function WP_Eliminar_Inmueble(Referencia As String, Optional Motivo As String = "", Optional Id_WP As Integer = 0) As Boolean

        Dim Sel As String

        If Id_WP = 0 Then

            Sel = "SELECT Id_WP FROM Inmuebles WHERE Referencia = '" & Referencia & "'"
            Id_WP = BD_CERO.Execute(Sel, False, 0)
        End If

        Dim Resultado As Boolean
        Resultado = WP_Eliminar_General("Inmuebles", Id_WP, True)

        If Resultado Then
            Sel = "UPDATE Inmuebles Set Id_WP = 0,  FechaPublicado_WP = NULL WHERE Referencia = '" & Referencia & "'"
            BD_CERO.Execute(Sel)


            Sel = "SELECT Contador FROM Inmuebles WHERE Referencia = '" & Referencia & "'"
            Dim Contador As Integer = BD_CERO.Execute(Sel, False, 0)
            WPEliminarFotosInmueble(Contador)

            InsertarMovimientosWP(Referencia, "ELIMINAR INMUEBLE", IIf(Resultado, 0, -1), Motivo, "Id_WP: " & Id_WP)
        End If

        Return Resultado

    End Function

    Public Function WP_Alta_Modificacion_Inmueble(InmuebleCompleto As Tablas.clInmuebleConId_WP, Accion As String) As Boolean

        Dim Resultado As Boolean
        Try

            Dim Sel As String
            Dim Inmueble_wp As New Tablas.cl_wp_Immueble

            Inmueble_wp = PrepararObjetoInmuebleWP(InmuebleCompleto)

            If IsNothing(Inmueble_wp) Then
                Return False
            End If

            Dim postData As String = SerializarPost(Inmueble_wp)

            postData = postData.Replace("____", "-")
            postData = postData.Replace("___", " ")


            Dim Res2 As New Tablas.clWPCreado
            Dim Res As Tablas.clResultado


            Dim Funcion As String

            Funcion = GL_ConfiguracionWeb.API_WP_Funcion_Propiedades

            'Dim IdInmuebleWP As Integer
            'Sel = "SELECT Id_WP, FechaPublicado_WP FROM Inmuebles WHERE Referencia = '" & Inmueble.Referencia & "' AND CodigoEmpresa = " & DatosEmpresa.Codigo
            'Dim bdCosas As New BaseDatos
            'bdCosas.LlenarDataSet(Sel, "T")

            'If bdCosas.ds.Tables("T").Rows(0)("Id_WP") = 0 OrElse IsDBNull(bdCosas.ds.Tables("T").Rows(0)("Id_WP")) Then
            '    Accion = "INSERT"
            'End If
            'IdInmuebleWP = bdCosas.ds.Tables("T").Rows(0)("Id_WP")
            'InmuebleCompleto.ID_WP = 0
            If InmuebleCompleto.ID_WP = 0 Then
                Accion = "INSERT"
            End If

            Dim MotivoParaControl As String = ""
            If Accion = "INSERT" Then
                Res = WordPressPost(Funcion, postData)
                MotivoParaControl = "ALTA INMUEBLE"
            Else
                Res = WordPressPost(Funcion & "/" & InmuebleCompleto.ID_WP, postData)
                MotivoParaControl = "MODIFICACION INMUEBLE"
            End If

            Dim MensajeParaControl As String = ""

            If Res.Codigo = 0 Then
                Res2 = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Tablas.clWPCreado)(Res.Mensaje)
                Dim IdWpInmuebleCreado As Integer
                IdWpInmuebleCreado = Res2.id

                Dim urlPropiedad As String
                urlPropiedad = Res2.link

                If Accion = "INSERT" Then
                    Sel = "UPDATE Inmuebles Set Id_WP = " & IdWpInmuebleCreado & ", FechaPublicado_WP = GETDATE() WHERE Contador = " & InmuebleCompleto.Inmueble.Contador
                    BD_CERO.Execute(Sel)

                    If InmuebleCompleto.Inmueble.Reservado Then
                        postData = SerializarPost("private", "status")
                    Else
                        postData = SerializarPost("publish", "status")
                    End If

                    Res = WordPressPost(Funcion & "/" & IdWpInmuebleCreado, postData)


                End If

                Sel = "UPDATE Inmuebles Set link_WP = '" & urlPropiedad & "' WHERE Contador = " & InmuebleCompleto.Inmueble.Contador
                BD_CERO.Execute(Sel)

                MensajeParaControl = "ID_WP: " & IdWpInmuebleCreado

                Resultado = True
            Else

                Dim Res3 As New Tablas.clErrorWP
                Res3 = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Tablas.clErrorWP)(Res.Mensaje)
                MensajeParaControl = Res3.message
                Resultado = False
            End If

            InsertarMovimientosWP(InmuebleCompleto.Inmueble.Referencia, Accion, Res.Codigo, MotivoParaControl, MensajeParaControl)

        Catch ex As Exception
            Resultado = False
        End Try

        Return Resultado


    End Function
    Public Function WP_CambiarStatus(Referencia As String, Motivo As String, Accion As String, Optional Id_WP As Integer = 0, Optional VengoDeSincronizarPendientes As Boolean = False) As Boolean

        Dim Res As Tablas.clResultado

        If Id_WP = 0 Then
            Dim Sel As String
            Sel = "SELECT Id_WP FROM Inmuebles WHERE Referencia = '" & Referencia & "'"
            Id_WP = BD_CERO.Execute(Sel, False, 0)
        End If

        Dim postData As String
        Dim Funcion As String

        Funcion = GL_ConfiguracionWeb.API_WP_Funcion_Propiedades

        If Accion = "RESERVAR" Then
            postData = SerializarPost("draft", "status")
        Else
            postData = SerializarPost("publish", "status")
        End If
        Res = WordPressPost(Funcion & "/" & Id_WP, postData)

        'If Res.Codigo <> 0 Then
        '    Dim MensaError As String
        '    If Res.Mensaje.Length > 250 Then
        '        MensaError = Microsoft.VisualBasic.Left(Res.Mensaje, 250)
        '    End If

        '    BD_CERO.Execute("INSERT INTO AccionesPendientes (Accion,Tabla,Referencia,CodigoEmpresa,Codigo,Fecha, Pendiente, Aleatorio, MensajeError) VALUES ('" & Accion & "','INMUEBLES','" & Funciones.pf_ReplaceComillas(Referencia) & "'," & DatosEmpresa.Codigo & ",'', " & GL_SQL_GETDATE & "," & GL_SQL_VALOR_1 & ",'',MensaError)")
        'End If



        InsertarMovimientosWP(Referencia, "CAMBIO STATUS INMUEBLE", Res.Codigo, Motivo, "Acción: " & Accion)

        If Res.Codigo = 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function WP_CambiarMostrarPantallaPrincipal(Referencia As String, PonerEnPrincipal As Boolean, Optional Id_WP As Integer = 0) As Boolean

        Dim Res As Tablas.clResultado

        If Id_WP = 0 Then
            Dim Sel As String
            Sel = "SELECT Id_WP FROM Inmuebles WHERE Referencia = '" & Referencia & "'"
            Id_WP = BD_CERO.Execute(Sel, False, 0)
        End If

        Dim postData As String
        Dim Funcion As String

        Funcion = GL_ConfiguracionWeb.API_WP_Funcion_Propiedades

        If PonerEnPrincipal Then
            postData = SerializarPost(1, "REAL_HOMES_featured")
        Else
            postData = SerializarPost(0, "REAL_HOMES_featured")
        End If
        Res = WordPressPost(Funcion & "/" & Id_WP, postData)

        InsertarMovimientosWP(Referencia, IIf(PonerEnPrincipal, "AÑADIR", "QUITAR") & " PANTALLA PRINCIPAL", Res.Codigo, "MENU CONTEXTUAL", "")

        If Res.Codigo = 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Function CambiarCamposDetalles(Campo As String) As String
        Dim TextoAMostrar As String

        Select Case Campo.ToString.ToUpper

            Case "DUPLEX"
                TextoAMostrar = "Dúplex"

            Case "MONTANA"
                TextoAMostrar = "Montaña"

            Case "ACCESOMINUSVALIDOS"
                TextoAMostrar = "Acceso Minusválidos"

            Case "PRIMERALINEAPLAYA"
                TextoAMostrar = "Primera línea playa"

            Case "VISTASALMAR"
                TextoAMostrar = "Vistas al mar"

            Case "JARDIN"
                TextoAMostrar = "Jardín"

            Case "BALCON"
                TextoAMostrar = "Balcón"

            Case "ELECTRODOMESTICOS"
                TextoAMostrar = "Electrodomésticos"

            Case "CALEFACCION"
                TextoAMostrar = "Calefacción"

            Case " ZONACOMERCIAL"
                TextoAMostrar = "Zona Comercial"

            Case "AIREACONDICIONADO"
                TextoAMostrar = "Aire Acondicionado"

            Case "URBANIZACION"
                TextoAMostrar = "Urbanización"

            Case "CALEFACCION"
                TextoAMostrar = "Calefacción"


            Case Else
                TextoAMostrar = Campo
        End Select

        Return TextoAMostrar
    End Function
    Public Function PrepararObjetoInmuebleWP(InmuebleCompleto As Tablas.clInmuebleConId_WP) As Tablas.cl_wp_Immueble


        Dim Sel As String

        Dim Inmueble As WebServiceVenalia.clInmueblesAlta
        Inmueble = InmuebleCompleto.Inmueble

        Dim Inmueble_wp As New Tablas.cl_wp_Immueble

        Dim ListaPropos As List(Of Integer) = WP_ObtenerListaPrestaciones(Inmueble)
        Dim wp_REALHOMESAdditionalDetails2 As Tablas.cl_wp_REALHOMESAdditionalDetails = WP_ObtenerListaDetails(Inmueble)

        'Sel = "SELECT Id_WP FROM Tipo WHERE Tipo = '" & Funciones.pf_ReplaceComillas(Inmueble.Tipo) & "'"
        'Dim Id_Tipo As Integer = BD_CERO.Execute(Sel, False)
        'If Id_Tipo = 0 Then
        '    Id_Tipo = WP_Alta_Modificar_General("Tipo", Inmueble.Tipo, 0, False)
        '    If Id_Tipo <= 0 Then
        '        GL_Error = "Error"
        '        Return Nothing
        '    Else
        '        Sel = "UPDATE Tipo SET ID_WP = " & Id_Tipo & " WHERE Tipo = '" & Funciones.pf_ReplaceComillas(Inmueble.Tipo) & "'"
        '        BD_CERO.Execute(Sel)
        '    End If

        'End If

        Dim Id_Tipo As Integer
        Id_Tipo = Obtener_Id_WP_Tipo(Inmueble)

        Dim Id_TipoVenta As Integer
        Id_TipoVenta = Obtener_Id_WP_TipoVenta(Inmueble)


        'Sel = "SELECT Id_WP FROM TipoVenta WHERE TipoVenta = '" & Funciones.pf_ReplaceComillas(Inmueble.TipoVenta) & "'"
        'Dim Id_TipoVenta As Integer = BD_CERO.Execute(Sel, False)
        'If Id_TipoVenta = 0 Then
        '    Id_TipoVenta = WP_Alta_Modificar_General("TipoVenta", Inmueble.TipoVenta, 0, False)
        '    If Id_TipoVenta <= 0 Then
        '        GL_Error = "Error"
        '        Return Nothing
        '    Else
        '        Sel = "UPDATE TipoVenta SET ID_WP = " & Id_TipoVenta & " WHERE TipoVenta = '" & Funciones.pf_ReplaceComillas(Inmueble.TipoVenta) & "'"
        '        BD_CERO.Execute(Sel)
        '    End If
        'End If





        Sel = "SELECT Id_WP FROM Poblacion  WHERE Poblacion = '" & Funciones.pf_ReplaceComillas(Inmueble.Poblacion) & "'"
        Dim Id_Pob As Integer = BD_CERO.Execute(Sel, False)

        'If Inmueble.Poblacion.ToUpper = "TORRES TORRES" Then
        '    Id_Pob = 172
        'End If

        If Inmueble.Poblacion.ToUpper = "ALMARDA" Then
            Sel = "SELECT ID_WP FROM Poblacion WHERE Poblacion = 'SAGUNTO'"
            Id_Pob = BD_CERO.Execute(Sel, False)
        End If
        If Id_Pob = 0 Then
            Id_Pob = WP_Alta_Modificar_General("Poblacion", Inmueble.Poblacion, 0, False)
            If Id_Pob <= 0 Then
                GL_Error = "Error"
                Return Nothing
            Else
                Sel = "UPDATE Poblacion SET ID_WP = " & Id_Pob & " WHERE Poblacion = '" & Funciones.pf_ReplaceComillas(Inmueble.Poblacion) & "'"
                BD_CERO.Execute(Sel)
            End If
        End If


        ''05/12/2020 JCB Comento las Zonas para no tener problemas de momento
        'Dim Id_Zona As Integer = 0
        'If Inmueble.Zona <> "" Then
        '    Sel = "SELECT Id_WP FROM WP_Zona WHERE Poblacion = '" & Funciones.pf_ReplaceComillas(Inmueble.Poblacion) & "' AND  Zona = '" & Funciones.pf_ReplaceComillas(Inmueble.Zona) & "'"
        '    Id_Zona = BD_CERO.Execute(Sel, False)
        '    If Id_Zona = 0 Then
        '        Id_Zona = WP_Alta_Modificar_General("Zona", Inmueble.Zona, 0, False,, Id_Pob)
        '        If Id_Zona <= 0 Then
        '            GL_Error = "Error"
        '            Return Nothing
        '        Else
        '            'Sel = "UPDATE Zona SET ID_WP = " & Id_Zona & " WHERE Poblacion = '" & Funciones.pf_ReplaceComillas(Inmueble.Poblacion) & "' AND  Zona = '" & Funciones.pf_ReplaceComillas(Inmueble.Zona) & "'"
        '            Sel = "DELETE FROM WP_Zona WHERE Poblacion = '" & Funciones.pf_ReplaceComillas(Inmueble.Poblacion) & "' AND Zona = '" & Funciones.pf_ReplaceComillas(Inmueble.Zona) & "'"
        '            BD_CERO.Execute(Sel)
        '            Sel = "INSERT INTO WP_Zona (Poblacion, Zona, Id_WP) VALUES ('" & Funciones.pf_ReplaceComillas(Inmueble.Poblacion) & "','" & Funciones.pf_ReplaceComillas(Inmueble.Zona) & "', " & Id_Zona & ")"
        '            BD_CERO.Execute(Sel)
        '        End If
        '    End If
        'End If
        ''fin 05/12/2020 JCB Comento las Zonas para no tener problemas de momento

        Dim DescripcionInmuble As String = ObtenerDescripcionWeb(Inmueble.Referencia, Inmueble.CodigoEmpresa, 0, False, True)

        If Inmueble.Reservado Then
            'Inmueble_wp.status = "draft"
            Inmueble_wp.status = "private"
        Else
            Inmueble_wp.status = "publish"
        End If

        Inmueble_wp.type = "property"
        Inmueble_wp.author = "1"
        Inmueble_wp.comment_status = "closed"
        Inmueble_wp.ping_status = "closed"
        Inmueble_wp.REAL_HOMES_property_size_postfix = "m2"
        Inmueble_wp.REAL_HOMES_agents = GL_ConfiguracionWeb.WP_Id_Agente 'Esto es para que salga lo de contactar
        Inmueble_wp.REAL_HOMES_property_map = 0 '?????
        'Inmueble_wp.REAL_HOMES_gallery_slider_type = "thumb-on-right" '?????

        If Inmueble.Oportunidad Then
            Inmueble_wp.inspiry_property_label = "Oportunidad"  '(Es color de la etiqueta para oportunidades)
            Inmueble_wp.inspiry_property_label_color = GL_ConfiguracionWeb.WP_ColorOportunidad   '(Es color de la etiqueta para oportunidades)
        End If



        Inmueble_wp.REAL_HOMES_property_id = Inmueble.Referencia
        Inmueble_wp.title = StrConv(Inmueble.Tipo, VbStrConv.ProperCase) & " en " & StrConv(Inmueble.Poblacion, VbStrConv.ProperCase)
        Inmueble_wp.title = Replace(Inmueble_wp.title, "PUERTO DE SAGUNTO", "Puerto de Sagunto",,, CompareMethod.Text)
        Inmueble_wp.title = Replace(Inmueble_wp.title, " EN ", " en ",,, CompareMethod.Text)
        Inmueble_wp.content = DescripcionInmuble

        Inmueble_wp.REAL_HOMES_property_price = Inmueble.Precio
        'Inmueble_wp.REAL_HOMES_featured.Add("") '?????
        Inmueble_wp.REAL_HOMES_property_size = Inmueble.Metros

        Dim Loca As location
        Loca = ObtenerLocation(Inmueble.Provincia & "+" & Inmueble.Poblacion & "+" & Inmueble.CodPostal & "+" & Inmueble.Direccion) '  "25.8151252,-80.3716546,13" '?????
        Inmueble_wp.REAL_HOMES_property_location = Loca.lat.ToString & "," & Loca.lng.ToString
        Inmueble_wp.REAL_HOMES_property_address = Inmueble.Direccion
        Inmueble_wp.REAL_HOMES_property_size = Inmueble.Metros
        If Inmueble.Garaje Then
            Inmueble_wp.REAL_HOMES_property_garage = "1"
        Else
            Inmueble_wp.REAL_HOMES_property_garage = ""
        End If

        Inmueble_wp.REAL_HOMES_property_bathrooms = "" & Inmueble.Banos.ToString & ""
        Inmueble_wp.REAL_HOMES_property_bedrooms = "" & Inmueble.Habitaciones.ToString & ""


        Sel = "SELECT ClasificacionWeb FROM Estado WHERE Estado = '" & Funciones.pf_ReplaceComillas(Inmueble.Estado) & "'"
        Dim EstadoWeb As String = BD_CERO.Execute(Sel, False, "")

        Inmueble_wp.inspiry_estado = EstadoWeb

        Inmueble_wp.REAL_HOMES_energy_class = Inmueble.CalificacionEnergetica


        Inmueble_wp.tipos____propiedad.Add(Id_Tipo)
        Inmueble_wp.estatus____propiedad.Add(Id_TipoVenta)

        If Inmueble.Oportunidad Then
            Dim IdOportunidad As Integer
            IdOportunidad = GL_ConfiguracionWeb.WP_Id_Oportunidad
            Inmueble_wp.estatus____propiedad.Add(IdOportunidad)
        End If

        Inmueble_wp.ciudades____propiedad.Add(Id_Pob)
        ''05/12/2020 JCB Comento las Zonas para no tener problemas de momento
        'If Id_Zona <> 0 Then
        '    Inmueble_wp.ciudades____propiedad.Add(Id_Zona)
        'End If
        ''fin 05/12/2020 JCB Comento las Zonas para no tener problemas de momento



        Inmueble_wp.características____propiedad = ListaPropos '?????
        Inmueble_wp.REAL_HOMES_additional_details = wp_REALHOMESAdditionalDetails2

        If Inmueble.MostrarPPrincipalWeb Then
            Inmueble_wp.REAL_HOMES_featured = 1 'Si queremos que salga abajo, en el slider.
        Else
            Inmueble_wp.REAL_HOMES_featured = 0
        End If



        Inmueble_wp.featured_media = InmuebleCompleto.Id_WP_FotoPrincipal

        'Dim thumbnails As New List(Of String)

        'Inmueble_wp._thumbnail_id = thumbnails '?????





        'Dim featured As New List(Of String)
        ''featured.Add("80")
        'Inmueble_wp.REAL_HOMES_featured = featured




        'Dim add_in_slider As New List(Of String)
        'add_in_slider.Add("no")
        'Inmueble_wp.REAL_HOMES_add_in_slider = add_in_slider

        'Inmueble_wp.REAL_HOMES_add_in_slider.Add("no")





        Return Inmueble_wp
    End Function

    Public Function Obtener_Id_WP_Tipo(Inmueble As WebServiceVenalia.clInmueblesAlta) As Integer

        Dim Sel As String
        Sel = "SELECT Id_WP FROM Tipo WHERE Tipo = '" & Funciones.pf_ReplaceComillas(Inmueble.Tipo) & "'"
        Dim Id_WP As Integer = BD_CERO.Execute(Sel, False, 0)

        Return Id_WP

    End Function
    Public Function Obtener_Id_WP_TipoVenta(Inmueble As WebServiceVenalia.clInmueblesAlta) As Integer

        Dim Sel As String
        Dim Id_WP As Integer

        If Inmueble.AlquilerOpcionCompra Then
            Id_WP = Obtener_Id_WP_Otros(Inmueble, "ALQUILER OPCIÓN COMPRA")
        Else

            Sel = "SELECT Id_WP FROM TipoVenta WHERE TipoVenta = '" & Funciones.pf_ReplaceComillas(Inmueble.TipoVenta) & "'"
            Id_WP = BD_CERO.Execute(Sel, False, 0)
        End If






        Return Id_WP

    End Function
    Public Function Obtener_Id_WP_Otros(Inmueble As WebServiceVenalia.clInmueblesAlta, Campo As String) As Integer

        Dim Sel As String
        Sel = "SELECT Id_WP FROM WP_OtrosCampos WHERE Campo = '" & Funciones.pf_ReplaceComillas(Campo) & "'"
        Dim Id_WP As Integer = BD_CERO.Execute(Sel, False, 0)

        Return Id_WP

    End Function


    Private Function ObtenerDescripcionWeb(ByVal Referencia As String, CodigoEmpresa As Integer, Optional ByVal FormatoHTML As Integer = 1, Optional ByVal SacarReferencia As Boolean = True, Optional ByVal DevolverPrecio As Boolean = True) As String

        Dim TablaInmuebles As String = "Inmuebles"
        Dim bd As New BaseDatos

        Dim Texto As String = ""



        Dim Sel As String = "SELECT * FROM " & TablaInmuebles & " WHERE Referencia = '" & Referencia & "' AND CodigoEmpresa = " & CodigoEmpresa


        Try



            Dim dtr As Object

            dtr = bd.ExecuteReader(Sel)

            If Not dtr.hasrows Then
                dtr.close()

                Return Texto
            End If

            dtr.read()

            Dim TipoVivienda As String
            If dtr("Tipo") = "CASA" Then
                TipoVivienda = "CASA INDEPENDIENTE"
            Else
                TipoVivienda = dtr("Tipo")
            End If


            If SacarReferencia Then
                Texto = "Ref " & " - "
            Else
                Texto = ""
            End If


            If FormatoHTML = 1 Then
                Texto = Texto & "<font color=""blue""><u> "
            End If

            If SacarReferencia Then
                Texto = Texto & dtr("Referencia") & ". "
            End If


            If FormatoHTML = 1 Then
                Texto = Texto & "</u></font>"
            End If


            '  Texto = Texto & " - " & TipoVivienda
            Texto = Texto & TipoVivienda

            If Not IsDBNull(dtr("Estado")) Then
                Texto = Texto & " " & dtr("Estado")
            End If

            Texto = Texto & " EN " & dtr("TipoVenta")

            Texto = Texto & " EN " & dtr("Poblacion")

            If dtr("Metros") > 0 Then
                Texto = Texto & ", DE " & dtr("Metros").ToString & " m²"
            End If

            If dtr("Altura") = -1 Then
                Texto = Texto & ", EN ENTRESUELO"
            End If

            If dtr("Altura") = -2 Then
                Texto = Texto & ", EN PLANTA BAJA"
            End If

            If dtr("Altura") > 0 Then
                Texto = Texto & ", EN " & dtr("Altura").ToString & "ª PLANTA"
            End If

            If Not IsDBNull(dtr("Ascensor")) AndAlso dtr("Ascensor") Then
                Texto = Texto & ", CON ASCENSOR"
            Else
                If Not IsDBNull(dtr("Altura")) AndAlso dtr("Altura") > 0 Then
                    Texto = Texto & ", SIN ASCENSOR"
                End If
            End If

            If Not IsDBNull(dtr("Habitaciones")) AndAlso dtr("Habitaciones") = 1 Then
                Texto = Texto & ", 1 HABITACION"
            Else
                If Not IsDBNull(dtr("Habitaciones")) AndAlso dtr("Habitaciones") > 1 Then
                    Texto = Texto & ", " & dtr("Habitaciones") & " HABITACIONES"
                End If
            End If

            If Not IsDBNull(dtr("Banos")) AndAlso dtr("Banos") = 1 Then
                Texto = Texto & ", 1 BAÑO"
            Else
                If Not IsDBNull(dtr("Banos")) AndAlso dtr("Banos") > 1 Then
                    Texto = Texto & ", " & dtr("Banos") & " BAÑOS"
                End If
            End If

            If Not IsDBNull(dtr("Piscina")) AndAlso dtr("Piscina") Then
                Texto = Texto & ", PISCINA"
            End If

            If Not IsDBNull(dtr("CocinaOffice")) AndAlso dtr("CocinaOffice") Then
                Texto = Texto & ", COCINA OFFICE"
            End If

            If Not IsDBNull(dtr("Galeria")) AndAlso dtr("Galeria") Then
                Texto = Texto & ", GALERIA"
            End If

            If Not IsDBNull(dtr("Amueblado")) AndAlso dtr("Amueblado") Then
                Texto = Texto & ", AMUEBLADO"
            End If

            If dtr("Terraza") Then
                If dtr("MTerraza") > 0 Then
                    If dtr("MTerraza2") > 0 Then
                        Texto = Texto & ", 2 TERRAZAS DE " & dtr("MTerraza").ToString & " y " & dtr("MTerraza2").ToString & "  m²"
                    Else
                        Texto = Texto & ", TERRAZA DE " & dtr("MTerraza").ToString & "  m²"
                    End If
                Else
                    Texto = Texto & ", TERRAZA"
                End If
            End If

            If dtr("Balcon") Then
                If dtr("MBalcon") > 0 Then
                    If dtr("MBalcon2") > 0 Then
                        Texto = Texto & ", 2 BALCONES DE " & dtr("MBalcon").ToString & " y " & dtr("MBalcon2").ToString & "  m²"
                    Else
                        Texto = Texto & ", BALCÓN DE " & dtr("MBalcon").ToString & "  m²"
                    End If
                Else
                    Texto = Texto & ", BALCÓN"
                End If
            End If

            If dtr("Patio") Then
                If dtr("MPatio") > 0 Then
                    If dtr("MPatio2") > 0 Then
                        Texto = Texto & ", 2 PATIOS DE " & dtr("MPatio").ToString & " y " & dtr("MPatio2").ToString & "  m²"
                    Else
                        Texto = Texto & ", PATIO DE " & dtr("MPatio").ToString & "  m²"
                    End If
                Else
                    Texto = Texto & ", PATIO"
                End If
            End If



            Dim TextoJardin As String = ""

            If dtr("Jardin") Then
                If InStr(dtr("Jardin"), "CHALET", CompareMethod.Text) > 0 OrElse InStr(dtr("Jardin"), "TERRENO", CompareMethod.Text) > 0 Then
                    TextoJardin = ", PARCELA"
                Else
                    TextoJardin = ", JARDÍN"
                End If
                If dtr("MJardin") > 0 Then
                    TextoJardin = TextoJardin & ", DE " & dtr("MJardin").ToString & "  m²"
                End If

            End If

            If TextoJardin <> "" Then
                Texto = Texto & TextoJardin
            End If

            If Not IsDBNull(dtr("VistasAlMar")) AndAlso dtr("VistasAlMar") Then
                Texto = Texto & ", VISTAS AL MAR"
            End If


            If dtr("Duplex") Then
                Texto = Texto & ", PISO DÚPLEX"
            End If

            If dtr("Orientacion").ToString <> "" Then
                Texto = Texto & ", ORIENTACION " & dtr("Orientacion").ToString
            End If

            If dtr("Zona").ToString <> "" Then
                Texto = Texto & ", ZONA " & dtr("Zona").ToString
            End If

            If Not IsDBNull(dtr("ZonaComercial")) AndAlso dtr("ZonaComercial") Then
                Texto = Texto & ", ZONA COMERCIAL"
            End If

            If dtr("Extras").ToString <> "" Then
                Texto = Texto & ", " & dtr("Extras").ToString
            End If



            Dim sMTrastero As String = ""
            If dtr("MTrastero") > 0 Then
                sMTrastero = " DE " & dtr("MTrastero").ToString & " m²"
            End If


            Dim sMGaraje As String = ""
            If dtr("MGaraje") > 0 Then
                sMGaraje = " DE " & dtr("MGaraje").ToString & " m²"
            End If

            Dim GarajeCerr As String = ""
            If dtr("GarajeCerrado") Then
                GarajeCerr = " CERRADO"
            End If




            Dim TextoIncluido As String = ""
            Dim FaltaPunto As Boolean = False
            Dim TextoTrasteroVenta As String = ""
            Dim TextoOpcional As String = ""

            If IsDBNull(dtr("Trastero")) OrElse dtr("Trastero") Then
                FaltaPunto = True
                TextoTrasteroVenta = " TRASTERO"
                If IsDBNull(dtr("Trastero")) Then
                    TextoOpcional = " OPCIONAL"
                    TextoTrasteroVenta = TextoTrasteroVenta
                Else
                    If IsDBNull(dtr("Garaje")) OrElse Not dtr("Garaje") Then
                        TextoIncluido = " INCLUIDO"
                    End If
                End If
                TextoTrasteroVenta = TextoTrasteroVenta & sMTrastero & TextoIncluido & TextoOpcional
            End If


            TextoOpcional = ""
            Dim TextoGarajeVenta As String = ""
            If IsDBNull(dtr("Garaje")) OrElse dtr("Garaje") Then
                FaltaPunto = True
                If TextoTrasteroVenta <> "" Then
                    TextoGarajeVenta = " Y GARAJE"
                Else
                    TextoGarajeVenta = " GARAJE"
                End If

                If IsDBNull(dtr("Garaje")) Then
                    TextoGarajeVenta = TextoGarajeVenta
                    TextoIncluido = ""
                    TextoOpcional = " OPCIONAL"
                Else
                    'TextoGarajeVenta = " INCLUIDO"

                    If Not IsDBNull(dtr("Trastero")) AndAlso dtr("Trastero") Then
                        TextoIncluido = " INCLUIDOS"
                    Else
                        TextoIncluido = " INCLUIDO"
                    End If

                    'If TextoIncluido = " INCLUIDO" Then
                    '    TextoIncluido = " INCLUIDOS"
                    'Else
                    '    TextoIncluido = " INCLUIDO"
                    'End If

                End If

                TextoGarajeVenta = TextoGarajeVenta & GarajeCerr & sMGaraje & TextoOpcional

                Dim TextoTrasteroGarajeVenta As String
                TextoTrasteroGarajeVenta = TextoTrasteroVenta & TextoGarajeVenta & TextoIncluido

                If TextoTrasteroGarajeVenta <> "" Then
                    TextoTrasteroGarajeVenta = "," & TextoTrasteroGarajeVenta
                End If

                Texto = Texto & TextoTrasteroGarajeVenta


            End If

            If FaltaPunto Then
                Texto = Texto & "."
            End If



            'If dtr("MPlaya") <> 5000 Then
            '    Texto = Texto & " A " & dtr("MPlaya").ToString & " m DE LA PLAYA"
            'End If


            If dtr("MPlaya") >= 0 And dtr("MPlaya") <> 5000 Then
                Texto = Texto + ", A " & dtr("MPlaya").ToString & " m DE LA PLAYA"
            End If

            'If dtr("PrimeraLineaPlaya") = 1 And dtr("MPlaya") >= 0 And dtr("MPlaya") <> 5000 Then
            '    Texto = Texto + ", EN PRIMERA LINEA, A " & dtr("MPlaya").ToString & " m DE LA PLAYA"
            'Else
            '    If dtr("PrimeraLineaPlaya") = 1 And Not (dtr("MPlaya") >= 0 And dtr("MPlaya") <> 5000) Then
            '        Texto = Texto + ", EN PRIMERA LINEA DE PLAYA"
            '    Else
            '        If Not dtr("PrimeraLineaPlaya") = 1 And dtr("MPlaya") >= 0 And dtr("MPlaya") <> 5000 Then
            '            Texto = Texto + ", A " & dtr("MPlaya").ToString & " m DE LA PLAYA"
            '        Else

            '        End If
            '    End If
            'End If

            If dtr("Tipo") = "GARAJE" OrElse dtr("Tipo") = "SOLAR" OrElse dtr("Tipo") = "TERRENO" OrElse dtr("Tipo") = "TERRENO CON CASA" Then
            Else
                If IsDBNull(dtr("CalificacionEnergetica")) OrElse dtr("CalificacionEnergetica") = "" Then
                    Texto = Texto & " CALIFICACIÓN ENERGÉTICA: En proceso"
                Else
                    Texto = Texto & " CALIFICACIÓN ENERGÉTICA: " & dtr("CalificacionEnergetica").ToString
                End If
            End If

            Texto = Texto & "."




            Dim TextoTrastero As String = ""
            Dim TextoGaraje As String = ""


            If DevolverPrecio Then
                If FormatoHTML Then
                    Texto = Texto & " <br>"
                Else
                    Texto = Texto & " "
                    '   Texto = Texto & vbCrLf
                End If

                Texto = Texto & "PRECIO: " & Microsoft.VisualBasic.FormatNumber(dtr("Precio"), 0) & " €"
                If dtr("TipoVenta").ToString.Length > 7 AndAlso Microsoft.VisualBasic.Left(dtr("TipoVenta").ToString, 8) = "ALQUILER" Then
                    Texto = Texto & "/mes"
                End If

                If IsDBNull(dtr("Trastero")) Then
                    If (Not IsDBNull(dtr("PrecioTrastero")) AndAlso dtr("PrecioTrastero") > 0) AndAlso IsDBNull(dtr("Trastero")) Then
                        TextoTrastero = TextoTrastero & " TRASTERO " & Microsoft.VisualBasic.FormatNumber(dtr("PrecioTrastero"), 0) & " €"
                        If dtr("TipoVenta").ToString.Length > 7 AndAlso Microsoft.VisualBasic.Left(dtr("TipoVenta").ToString, 8) = "ALQUILER" Then
                            TextoTrastero = TextoTrastero & "/mes"
                        End If
                    End If
                End If

                If IsDBNull(dtr("Garaje")) Then
                    If (Not IsDBNull(dtr("PrecioGaraje")) AndAlso dtr("PrecioGaraje") > 0) AndAlso IsDBNull(dtr("Garaje")) Then
                        TextoGaraje = TextoGaraje & " Garaje " & Microsoft.VisualBasic.FormatNumber(dtr("PrecioGaraje"), 0) & " €"
                        If dtr("TipoVenta").ToString.Length > 7 AndAlso Microsoft.VisualBasic.Left(dtr("TipoVenta").ToString, 8) = "ALQUILER" Then
                            TextoTrastero = TextoTrastero & "/mes"
                        End If
                    End If
                End If
            End If




            Texto = Texto & TextoTrastero & TextoGaraje







            If dtr("Oportunidad") And FormatoHTML Then
                Texto = "<b>" & Texto & " </b>"
            End If
            If FormatoHTML Then
                Texto = "<font size=3> " & Texto & " </font>"
            End If

            dtr.Close()

            bd.CerrarBD()

        Catch ex As Exception

        End Try





        Return Texto





    End Function


    Public Function ObtenerLocation(Direccion As String) As location


        Dim Localizacion As New location
        Localizacion.lat = "0"
        Localizacion.lng = "0"

        Direccion = Direccion.Trim()

        Try


            'Limites
            'https://developers.google.com/maps/documentation/geocoding/usage-limits?hl=es

            Dim Direc As String
            Direc = "https://maps.googleapis.com/maps/api/geocode/json?address=" & Direccion & "&key=AIzaSyCT9gBaNguayE-kB8SAO230yTfGzph24aw"
            ' System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls

            Dim request As Net.WebRequest = Net.WebRequest.Create(Direc.Trim)
            request.Method = "GET"
            request.ContentType = "application/json"
            '      request.Headers.Add("authorization", "Bearer " & GL_TokenKyeroo)

            Dim response As Net.WebResponse = request.GetResponse()

            'Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)

            Dim dataStream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()

            Dim test As GoogleGeoCodeResponse
            test = Newtonsoft.Json.JsonConvert.DeserializeObject(Of GoogleGeoCodeResponse)(responseFromServer)
            ' Display the content.
            'Dim listaPedidos As New List(Of ObjOrders)
            'listaPedidos = JsonConvert.DeserializeObject(Of List(Of ObjOrders))(responseFromServer)


            ' Clean up the streams.
            reader.Close()
            dataStream.Close()
            response.Close()


            If test.results.Length <> 0 Then
                Localizacion.lat = test.results(0).geometry.location.lat
                Localizacion.lng = test.results(0).geometry.location.lng
            End If


        Catch ex As Exception

        End Try

        Return Localizacion



    End Function
End Module

