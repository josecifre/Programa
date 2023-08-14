Public Class frmPublicarFacebook
    Public datos As String
    Private Sub frm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        AparienciaGeneral()
        texto.Text = ConsultasBaseDatos.ObtenerDescripcionInmueble2(datos.Split("|")(2), 0)

        cargarFotoInicial(datos.Split("|")(0), datos.Split("|")(1))
    End Sub
    Private Sub cargarFotoInicial(FotoPrincipal As String, Referencia As String)
        Dim Carpeta As String = GL_CarpetaFotos & "\" & Referencia

        If Not System.IO.Directory.Exists(Carpeta) Then Exit Sub

        Dim Fotos() As String = System.IO.Directory.GetFiles(Carpeta)
        Dim cuenta As Integer = Fotos.Count - 1
        Try

            If FotoPrincipal <> "" Then
                For i = 0 To cuenta
                    If My.Computer.FileSystem.GetName(Fotos(i)) = FotoPrincipal Then
                        imagen.BackgroundImage = Funciones.redimensionaimagen(Image.FromStream(New IO.MemoryStream(IO.File.ReadAllBytes(Fotos(i)))), imagen.Width, imagen.Height, False)
                        imagen.BackgroundImageLayout = ImageLayout.Zoom
                        imagen.Tag = Fotos(i)
                        Exit For
                    End If
                Next
            Else
                Dim FotoDirectorioWeb As String = Carpeta & "\actualizaweb" & "\" & Referencia & "_1.jpg"
                If System.IO.File.Exists(FotoDirectorioWeb) Then
                    imagen.BackgroundImage = Image.FromStream(New IO.MemoryStream(IO.File.ReadAllBytes(FotoDirectorioWeb)))
                    imagen.BackgroundImageLayout = ImageLayout.Zoom
                    imagen.Tag = FotoDirectorioWeb
                End If
            End If

            'If Not una Then
            '    For i = 0 To cuenta
            '        If Not My.Computer.FileSystem.GetName(Fotos(i)) = FotoPrincipal Then
            '            slid.Images.Add(Funciones.redimensionaimagen(Image.FromStream(New IO.MemoryStream(IO.File.ReadAllBytes(Fotos(i)))), slid.Width, slid.Height, False))
            '        End If
            '    Next
            'End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.Dispose()
    End Sub

    Private Sub imagen_Click(sender As System.Object, e As System.EventArgs) Handles imagen.Click
        Dim Carpeta As String = GL_CarpetaFotos & "\" & datos.Split("|")(1)

        Dim ConfiguracionMarcaAgua As MarcaAgua.clConfiguracionMarcaAgua

        Dim dtr As Object
        Dim bdim As New BaseDatos
        Dim Sel As String = "SELECT * FROM ConfiguracionMarcaAgua"
        dtr = bdim.ExecuteReader(Sel)
        If dtr.hasrows Then
            ConfiguracionMarcaAgua = New MarcaAgua.clConfiguracionMarcaAgua
            dtr.read()


            ConfiguracionMarcaAgua.Posicion = dtr("Posicion")
            ConfiguracionMarcaAgua.TextoAMostrar = dtr("TextoAMostrar")
            ConfiguracionMarcaAgua.RutaImagen = clVariables.RutaServidor & "\Logos\MarcaAgua\" & DatosEmpresa.Codigo & "." & dtr("ExtensionLogo")


            If ConfiguracionMarcaAgua.TextoAMostrar.Trim = "" Then
                ConfiguracionMarcaAgua.MostrarTexto = False
            Else
                ConfiguracionMarcaAgua.MostrarTexto = dtr("MostrarTexto")
            End If



            If Not System.IO.File.Exists(ConfiguracionMarcaAgua.RutaImagen) Then
                ConfiguracionMarcaAgua.MostrarImagen = False
            Else
                ConfiguracionMarcaAgua.MostrarImagen = dtr("MostrarImagen")
            End If

            Try
                ConfiguracionMarcaAgua.Transparencia = dtr("Transparencia")
            Catch ex As Exception
                ConfiguracionMarcaAgua.Transparencia = 0
            End Try

            Try
                ConfiguracionMarcaAgua.RelacionAncho = dtr("RelacionAncho")
            Catch ex As Exception
                ConfiguracionMarcaAgua.RelacionAncho = 0
            End Try
            Try
                ConfiguracionMarcaAgua.RelacionAlto = dtr("RelacionAlto")
            Catch ex As Exception
                ConfiguracionMarcaAgua.RelacionAlto = 0
            End Try

        Else
            ConfiguracionMarcaAgua = Nothing
        End If
        dtr.close()
        bdim.CerrarBD()
        imagen.Tag = InsertarDocumento(Carpeta, EnumFiltro.JPG, True, , , ConfiguracionMarcaAgua, True)
        If imagen.Tag.trim <> "" Then
            imagen.BackgroundImage = Funciones.redimensionaimagen(Image.FromStream(New IO.MemoryStream(IO.File.ReadAllBytes(imagen.Tag))), imagen.Width, imagen.Height, False)
            imagen.BackgroundImageLayout = ImageLayout.Zoom
        End If
        
    End Sub


    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Return
        'id de la aplicacion 133268093907553
        'clave de la aplicacion f4566cba9e560f7664b84d8f715fa7ec
        'id de acceso cliente 7cc285df366c460244dbf8a88bf27a02
        'mayte@tresbits.es TresBits368

        'Dim fb As New Facebook.FacebookClient("133268093907553|f4566cba9e560f7664b84d8f715fa7ec")
        Dim fb As New Facebook.FacebookClient
        Dim parameters As Object
        Dim result As Object

        With fb

            'DATOS DE LA APP
            .AppId = "133268093907553"
            .AppSecret = "f4566cba9e560f7664b84d8f715fa7ec"
            .UseFacebookBeta = True
            .Version = "v2.9"

            '1-OBTENER ACCESS_TOKEN 2 HORAS BASICO
            'parameters = New System.Dynamic.ExpandoObject()
            'parameters.client_id = .AppId
            'parameters.client_secret = .AppSecret
            'parameters.grant_type = "client_credentials"
            'result = .Get("oauth/access_token", parameters) 'devuelve al access token bien
            '.AccessToken = result.access_token 'obtiene este codigo que sirve para datos basicos 133268093907553|GHSf_tok42vAP4Fwa_6OOoxs95w
            '.AccessToken = "133268093907553|GHSf_tok42vAP4Fwa_6OOoxs95w"

            'XXX 2-OBTENER ACCESS_TOKEN CON PERMISOS ESPECIALES POR EL EXPLORER API GRAPH(NO CONSEGUIDO, FALTA REDIRECT_URI??)
            ''https://developers.facebook.com/tools/explorer/133268093907553?method=GET&path=me%3Ffields%3Did%2Cname&version=v2.9
            ''get access with permisions
            ''https://www.facebook.com/dialog/oauth?client_id=YOUR_APP_ID&redirect_uri=YOUR_URL&scope=offline_access,email,read_stream
            ''https://www.facebook.com/dialog/oauth?client_id=133268093907553&redirect_uri=YOUR_URL&scope=publish_actions,manage_pages,publish_pages,pages_show_list
            'parameters = New System.Dynamic.ExpandoObject()
            'parameters.client_id = .AppId
            'parameters.redirect_uri = ""
            'parameters.scope = "publish_actions,manage_pages,publish_pages,pages_show_list"
            'result = .Get("https://www.facebook.com/dialog/oauth", parameters)

            '3-OBTENER ACCESS_TOKEN DE LARGA DURACION 60 DIAS EXTENDIDO CON LOS PERMISOS REQUERIDOS 'long_lived_access_token
            ''https://graph.facebook.com/oauth/access_token?grant_type=fb_exchange_token&client_id=[app-id]&client_secret=[app-secret]&fb_exchange_token=[short-lived-token]
            ''https://graph.facebook.com/oauth/access_token?grant_type=fb_exchange_token&client_id=133268093907553&client_secret=f4566cba9e560f7664b84d8f715fa7ec&fb_exchange_token= 'codigo que nos de el api graph explorer
            ''aplicacion TresBits Version 2.9 el actual, obtener identificador, elegir los permisos que se quieren manage_pages,publish... CADUCA el codigo que da
            'parameters = New System.Dynamic.ExpandoObject()
            'parameters.grant_type = "fb_exchange_token"
            'parameters.client_id = .AppId
            'parameters.client_secret = .AppSecret
            ''obtener toquen dinamicamente(↓ este exchange toquen lo obtendriamos en el paso anterior, pero como no lo conseguimos se obtiene de la api graph manualmente)
            'parameters.fb_exchange_token = "EAAB5NOVlsmEBANs6ssZCTr7E1MFvVt43qzNHoASHBKagazJ2QyZAHVQDzdJHxgfCFmceWsU0kBUWUpRhnkZBt7McwTbQ6fsXZAtN1kFW6mR2RPChVmgNR33Qjw1ZAqIRGxieGXpm0bxnfdGgJeBSrSg1ZAqSwCyEqmNHE1RaVHZC2trtkatZBsZB2l1aBk72d7PYZD" 'token obtenido por el explorer API GRAPH
            'result = .Get("oauth/access_token", parameters)
            '.AccessToken = result.access_token '"EAAB5NOVlsmEBACAenhEk8kUSMICIwi5LJl5Srvf6yKFJKLyYxINO7DZCj3C596H5Ixmur3bAlXNRaNQRN4HC0vxlh2T3nAkRirNYZA6nuFR3ELPlNpiyZBeujzZCIfAnOaHMZA0HBVq9yeciajSt6QTLXQfetjLEkRSZALwWXHNgZDZD" valido hasta inicio de octubre(creado 3/8/17) 60 dias'EAAB5NOVlsmEBAH2L9Jhsz9yJCxoyMwvMMBMRDieGQVAp8ZCRhqtnIQVKofbc4lEPYe0NkM8afBQ0ipiJsD8lk3SRJFcSNPuR6ZBAZBFBH017lZBtP5NWFzsSPL7ZBSTaZAPZA2zh7omGebwZBaUQEevgfS2Pct2kRGsZD
            .AccessToken = "EAAB5NOVlsmEBACAenhEk8kUSMICIwi5LJl5Srvf6yKFJKLyYxINO7DZCj3C596H5Ixmur3bAlXNRaNQRN4HC0vxlh2T3nAkRirNYZA6nuFR3ELPlNpiyZBeujzZCIfAnOaHMZA0HBVq9yeciajSt6QTLXQfetjLEkRSZALwWXHNgZDZD"

            'OPCIONAL-OBTENER ID DEL USUARIO(ACOUNT_ID)
            'https://graph.facebook.com/v2.9/me?access_token={long_lived_access_token}
            'parameters = New System.Dynamic.ExpandoObject()
            'parameters.access_token = .AccessToken
            'result = .Get("v2.9/me", parameters) 'result.id = codigo de usuario(acount_id) 272641683141775

            'XXX 4-OBTENER ACCESS_TOKEN PERMANENTE (aparentemente esta opcion ya no esta disponible) devuelve los datos vacios
            'https://graph.facebook.com/v2.9/{account_id}/accounts?access_token={long_lived_access_token}
            'https://graph.facebook.com/v2.9/272641683141775/accounts?access_token=EAAB5NOVlsmEBACAenhEk8kUSMICIwi5LJl5Srvf6yKFJKLyYxINO7DZCj3C596H5Ixmur3bAlXNRaNQRN4HC0vxlh2T3nAkRirNYZA6nuFR3ELPlNpiyZBeujzZCIfAnOaHMZA0HBVq9yeciajSt6QTLXQfetjLEkRSZALwWXHNgZDZD
            'result = .Get("me/accounts", parameters) 'tambien se puede especificar v2.9/" & result.id & " el acount_id

            'OPCIONAL-PRUEBA DE CONEXION ok
            'https://www.facebook.com/dialog/oauth?client_id=$X&scope=manage_pages,publish_stream&response_type=token&redirect_uri=https://www.facebook.com/connect/login_success.html"
            'Dim mee As Facebook.JsonObject = fb.Get("133268093907553") 
            'Dim nombre As String = mee("name") 'TresBits es el nombre de la app
            'mee = fb.Get("133268093907553/permissions") 'saber que permisos tiene

            '5-CREACION DE UNA PUBLICACION
            parameters = New System.Dynamic.ExpandoObject() 'dynamic Facebook.JsonObject = New Facebook.JsonObject
            parameters.message = texto.Text.Replace("<br>", vbCrLf) 'texto arriba de la foto
            parameters.subject = datos.Split("|")(1) 'referencia
            Dim fm As New Facebook.FacebookMediaObject 'añadir foto
            fm.ContentType = "image/" & IO.Path.GetExtension(imagen.Tag).Replace(".", "") 'gif
            fm.FileName = IO.Path.GetFileName(imagen.Tag)
            fm.SetValue(IO.File.ReadAllBytes(imagen.Tag))
            parameters.source = fm

            Try
                'PUBLICAR COMO FOTOS
                'Roberto Id 1091747868(no permitido publicar en otros usuarios desde 06/02/2013)
                'Mayte Tb 100011878363875
                result = .Post("me/photos", parameters) 'dynamic ' me/photos(Identificador del usuario/carpeta en la que publica
                MensajeInformacion("Publicado correctamente")

            Catch ex As Facebook.FacebookOAuthException 'oauth exception occurred
                MensajeError(ex.Message)
            Catch ex As Facebook.FacebookApiLimitException 'api limit exception occurred.
                MensajeError(ex.Message)
            Catch ex As Facebook.FacebookApiException 'other general facebook api exception
                MensajeError(ex.Message)
            Catch ex As Exception
                MensajeError(ex.Message)
            End Try

            Try
                '.Delete(result.id)
            Catch ex As Exception
                MensajeError(ex.Message)
            End Try

            'XXX PRUEBA FEED EN VEZ DE PUBLICAR FOTO (NO OPERATIVO)
            'parameters = New Dynamic.ExpandoObject()
            'parameters.message = "Test Message"
            'parameters.subject = "test 123"
            'parameters.link = "https://youtu.be/dQw4w9WgXcQ"
            'parameters.picture = "http://b.vimeocdn.com/ps/588/58832_300.jpg"
            'parameters.name = "Article Title"
            'parameters.caption = "Caption for the link"
            'parameters.description = "Longer description of the link"
            'parameters.privacy = New 
            '    {
            '        value = "SELF"
            '    }
            Try
                'result = .Post("me/feed", parameters)
            Catch ex As Exception
                MensajeError(ex.Message)
            End Try

            'BORRAR PUBLICACIONES POR ID
            '.Delete(result.id)'se deberia guardar este id para poder borrar en el futuro las publicaciones viejas y/o repetidas

        End With

    End Sub

End Class