Imports System.Net
Imports System.IO
Imports FuncionesGenerales.Funciones

Public Class tb_FTP

    Public UsuarioFTP As String
    Public PassWordFTP As String
    Public RutaInicialFTP As String
    '    Sub New(Optional ByVal BuscarDatosFTPEnBaseDeDatos As Boolean = False, Optional ByVal Usuario As String = "tresbits", Optional ByVal Contrasena As String = "43D214B34643B13132BC2A02C0BE1F4A", Optional ByVal ContasenaEncriptada As Boolean = True, Optional ByVal RutaFTP As String = "ftp://ftp.tresbits.es/")
    Sub New(Optional ByVal BuscarDatosFTPEnBaseDeDatos As Boolean = False, Optional ByVal Usuario As String = "venalia", Optional ByVal Contrasena As String = "Ftp1234#TB", Optional ByVal ContasenaEncriptada As Boolean = False, Optional ByVal RutaFTP As String = "ftp://ftp.venalia.net")

        If Not IsNothing(GL_ConfiguracionWeb) Then
            RutaFTP = GL_ConfiguracionWeb.Servidor
            Contrasena = GL_ConfiguracionWeb.Pass
            Usuario = GL_ConfiguracionWeb.Usuario
        Else
            RutaInicialFTP = RutaFTP
            PassWordFTP = Contrasena
            UsuarioFTP = Usuario
        End If

        

        If BuscarDatosFTPEnBaseDeDatos Then
            RellenarUsuarioYPassDeBaseDeDatos()
        Else
            UsuarioFTP = Usuario
            PassWordFTP = Contrasena
            RutaInicialFTP = RutaFTP
        End If
        If ContasenaEncriptada Then
            PassWordFTP = Encriptacion.DesEncriptar(PassWordFTP, "LAMBDAPI")
        End If



    End Sub

    Public Sub RellenarUsuarioYPassDeBaseDeDatos()

        Dim bd As New BaseDatos
        UsuarioFTP = bd.Execute("SELECT Usuario FROM ConfiguracionWeb", False)
        PassWordFTP = bd.Execute("SELECT Pass FROM ConfiguracionWeb", False)
        RutaInicialFTP = bd.Execute("SELECT Servidor FROM ConfiguracionWeb", False)

        UsuarioFTP = Encriptacion.DesEncriptar(UsuarioFTP, "LAMBDAPI")
        PassWordFTP = Encriptacion.DesEncriptar(PassWordFTP, "LAMBDAPI")
        RutaInicialFTP = Encriptacion.DesEncriptar(RutaInicialFTP, "LAMBDAPI")


    End Sub
    Public Function FTPCuantos(ByVal CarpetaFTP As String, Optional ByVal Extension As String = "") As Integer

        Dim Servidor As String = RutaInicialFTP & CarpetaFTP

        Dim dirFtp As FtpWebRequest = CType(FtpWebRequest.Create(Servidor), FtpWebRequest)

        ' Los datos del usuario (credenciales)
        Dim cr As New NetworkCredential(UsuarioFTP, PassWordFTP)
        dirFtp.Credentials = cr

        ' El comando a ejecutar
        ' dirFtp.Method = "LIST"

        ' También usando la enumeración de WebRequestMethods.Ftp
        dirFtp.Method = WebRequestMethods.Ftp.ListDirectory


        Dim sr As New StreamReader(dirFtp.GetResponse().GetResponseStream())
        Dim Linea As String
        Dim ContadorLin As Integer = 0
        Linea = sr.ReadLine()
        If Linea <> "." And Linea <> ".." Then
            If Extension <> "" Then
                If Right(Linea, Len(Extension)).ToUpper = Extension.ToUpper Then
                    ContadorLin += 1
                End If
            Else
                ContadorLin += 1
            End If
        End If

        While Not Linea Is Nothing
            Linea = sr.ReadLine()

            If Linea <> "." And Linea <> ".." Then
                If Extension <> "" Then
                    If Right(Linea, Len(Extension)).ToUpper = Extension.ToUpper Then
                        ContadorLin += 1
                    End If
                Else
                    ContadorLin += 1
                End If
            End If

        End While
        sr.Close()
        dirFtp = Nothing
        Return ContadorLin

    End Function
    Public Function FTPCarpetasEn(ByVal CarpetaFTP As String, Optional ByVal Extension As String = "") As String
        Dim carpetas As String = ""
        Dim Servidor As String = RutaInicialFTP & CarpetaFTP

        Dim dirFtp As FtpWebRequest = CType(FtpWebRequest.Create(Servidor), FtpWebRequest)

        ' Los datos del usuario (credenciales)
        Dim cr As New NetworkCredential(UsuarioFTP, PassWordFTP)
        dirFtp.Credentials = cr

        ' El comando a ejecutar
        ' dirFtp.Method = "LIST"

        ' También usando la enumeración de WebRequestMethods.Ftp
        dirFtp.Method = WebRequestMethods.Ftp.ListDirectory


        Dim sr As New StreamReader(dirFtp.GetResponse().GetResponseStream())
        Dim Linea As String

        Linea = sr.ReadLine()
        If Linea <> "." And Linea <> ".." Then
            If Extension <> "" Then
                If Right(Linea, Len(Extension)).ToUpper = Extension.ToUpper Then
                    carpetas = Linea
                End If
            Else
                carpetas = Linea
            End If
        End If

        While Not Linea Is Nothing
            Linea = sr.ReadLine()

            If Linea <> "." And Linea <> ".." Then
                If Extension <> "" Then
                    If Right(Linea, Len(Extension)).ToUpper = Extension.ToUpper Then
                        carpetas &= "|" & Linea
                    End If
                Else
                    carpetas &= "|" & Linea
                End If
            End If

        End While
        sr.Close()
        dirFtp = Nothing
        Return carpetas

    End Function
    Public Function FTPDescargarCarpeta(ByVal CarpetaFTP As String, ByVal CarpetaDestino As String, Optional ByVal Extension As String = "") As Integer

        Dim ErrorAlBajarAlgunFichero As Boolean = False
        Dim ContadorLin As Integer = 0

        Dim Servidor As String = CarpetaFTP & "/"


        Try
            Dim dirFtp As FtpWebRequest = CType(FtpWebRequest.Create(RutaInicialFTP & CarpetaFTP & "/"), FtpWebRequest)

            ' Los datos del usuario (credenciales)
            Dim cr As New NetworkCredential(UsuarioFTP, PassWordFTP)
            dirFtp.Credentials = cr

            ' El comando a ejecutar
            ' dirFtp.Method = "LIST"

            ' También usando la enumeración de WebRequestMethods.Ftp
            dirFtp.Method = WebRequestMethods.Ftp.ListDirectory


            Dim sr As New StreamReader(dirFtp.GetResponse().GetResponseStream())

            Dim Linea As String
            Dim FicheroValido As Boolean = False

            Linea = sr.ReadLine()

            If Linea <> "." And Linea <> ".." Then
                If Extension <> "" Then
                    If Right(Linea, Len(Extension)).ToUpper = Extension.ToUpper Then
                        FicheroValido = True
                    End If
                Else
                    FicheroValido = True
                End If
            End If

            If FicheroValido Then
                ContadorLin += 1
                If Not FTPDescargarFichero(Servidor & Linea, CarpetaDestino & "\" & Linea) Then
                    ErrorAlBajarAlgunFichero = True
                    EscribeLog("Error al descargar el fichero " & Linea)
                End If
            End If


            While Not Linea Is Nothing
                FicheroValido = False
                Linea = sr.ReadLine()

                If Linea <> "." And Linea <> ".." Then
                    If Extension <> "" Then
                        If Right(Linea, Len(Extension)).ToUpper = Extension.ToUpper Then
                            FicheroValido = True
                        End If
                    Else
                        FicheroValido = True
                    End If
                End If

                If FicheroValido Then
                    ContadorLin += 1
                    If Not FTPDescargarFichero(Servidor & Linea, CarpetaDestino & "\" & Linea) Then
                        ErrorAlBajarAlgunFichero = True
                        EscribeLog("Error al descargar el fichero " & Linea)
                    End If
                End If

            End While
            sr.Close()
            dirFtp = Nothing

        Catch ex As Exception

            EscribeLog("Error al hacer el LIST en el FTP. ", ex.Message)
            Return -1

        End Try

        If ErrorAlBajarAlgunFichero Then
            Return -2
        Else
            Return ContadorLin
        End If


    End Function

    Public Function FTPArchivosCarpeta(CarpetaFTP As String) As List(Of String)
        Try


            Dim archivos As New List(Of String)
            Dim Servidor As String = RutaInicialFTP & CarpetaFTP

            Dim dirFtp As FtpWebRequest = CType(FtpWebRequest.Create(Servidor), FtpWebRequest)

            ' Los datos del usuario (credenciales)
            Dim cr As New NetworkCredential(UsuarioFTP, PassWordFTP)
            dirFtp.Credentials = cr

            ' El comando a ejecutar
            ' dirFtp.Method = "LIST"

            ' También usando la enumeración de WebRequestMethods.Ftp
            dirFtp.Method = WebRequestMethods.Ftp.ListDirectory


            Dim sr As New StreamReader(dirFtp.GetResponse().GetResponseStream())
            Dim Linea As String

            Linea = sr.ReadLine()
            If Linea <> "." AndAlso Linea <> ".." AndAlso Not IsNothing(Linea) Then
                archivos.Add(Linea)
            End If

            While Not Linea Is Nothing
                Linea = sr.ReadLine()
                If Linea <> "." AndAlso Linea <> ".." AndAlso Not IsNothing(Linea) Then
                    archivos.Add(Linea)
                End If
            End While

            sr.Close()
            dirFtp = Nothing
            Return archivos
        Catch ex As Exception
            Return Nothing
        End Try

    End Function


    Public Function FTPDescargarFichero(ByVal Origen As String, ByVal Destino As String) As Boolean

        Try
            My.Computer.Network.DownloadFile(RutaInicialFTP & "/" & Origen, Destino, UsuarioFTP, PassWordFTP)

        Catch ex As Exception
            Return False
        End Try
        Return True

    End Function


    Public Function FTPComprobaryCrearDirectorio(ByVal CarpetaFTP As String) As String

        Dim Servidor As String = RutaInicialFTP & CarpetaFTP

        Dim dirFtp As FtpWebRequest = CType(FtpWebRequest.Create(Servidor), FtpWebRequest)


        Try


            Dim cr As New NetworkCredential(UsuarioFTP, PassWordFTP)
            dirFtp.Credentials = cr

            ' El comando a ejecutar
            ' dirFtp.Method = "LIST"

            ' También usando la enumeración de WebRequestMethods.Ftp
            dirFtp.Method = WebRequestMethods.Ftp.ListDirectory


            dirFtp = FtpWebRequest.Create(Servidor)



            Using response As FtpWebResponse = _
          DirectCast(dirFtp.GetResponse(), FtpWebResponse)
                ' Folder exists here
                '  MsgBox("exists!")
            End Using

        Catch ex2 As WebException
            Dim response As FtpWebResponse = _
               DirectCast(ex2.Response, FtpWebResponse)
            'Does not exist
            If response.StatusCode = _
            FtpStatusCode.ActionNotTakenFileUnavailable Then
                dirFtp = FtpWebRequest.Create(Servidor)
                dirFtp.Method = WebRequestMethods.Ftp.MakeDirectory

                Dim respuestaFTP As FtpWebResponse
                respuestaFTP = CType(dirFtp.GetResponse(), FtpWebResponse)
                respuestaFTP.Close()
            End If




        Catch ex As Exception

            Return ex.Message

        End Try
        Return ""

    End Function
    Public Function FTPSubirCarpeta(ByVal CarpetaFTP As String, ByVal CarpetaOrigen As String, Optional ByVal Extension As String = "") As String




        Dim Servidor As String = RutaInicialFTP & CarpetaFTP & "/"

        Dim pf As New ProgressForm
        Try

            'FTPComprobaryCrearDirectorio(CarpetaFTP)



            Dim Archivos() As String
            Dim Archivo As String
            Dim Total As Integer

            Archivos = System.IO.Directory.GetFiles(CarpetaOrigen, IIf(Extension <> "", "*." & Extension, ""))
            Total = Archivos.Length


            pf.ProgressControl.Maximum = Archivos.Count
            pf.ProgressControl.ProgressText = "Espere unos instantes ..."
            pf.StartPosition = FormStartPosition.Manual
            Dim P As Point
            P.X = (Screen.PrimaryScreen.WorkingArea.Width - pf.Width) / 2
            P.Y = (Screen.PrimaryScreen.WorkingArea.Height - pf.Height) / 2
            pf.Location = P
            pf.Visible = True
            pf.BringToFront()
            pf.Show()
            pf.BringToFront()
            pf.Refresh()
            For Each Archivo In Archivos
                pf.ProgressControl.Value += 1
                pf.Refresh()

                'clVariables.RutaCompletaFTP = clVariables.RutaInicialFTP & System.IO.Path.GetFileName(Archivo)
                clVariables.RutaCompletaFTP = Servidor & System.IO.Path.GetFileName(Archivo)
                Dim Res As String
                Res = SubirArchivoAlServidor(Archivo, clVariables.RutaCompletaFTP, Servidor)
                If Res <> "" Then
                    '  MsgBox("Error subiendo las imagénes. " & vbCrLf & Res)
                    Return "Error 2 subiendo las imagénes. " & vbCrLf & Res
                End If
            Next
            pf.Close()
        Catch ex As Exception
            pf.Close()


            Return "Error 3 subiendo las imagénes. " & vbCrLf & ex.Message

        End Try

        Return ""

    End Function

    Public Function SubirArchivoAlServidor(ByVal ArchivoOrigen As String, ByVal ServidorDestino As String, CarpetaDestino As String, Optional usuario As String = "", Optional pass As String = "") As String
        If usuario = "" Then
            usuario = UsuarioFTP
        End If
        If pass = "" Then
            pass = PassWordFTP
        End If
        Try
            If Not ServidorDestino.Contains("ftp://") Then
                ServidorDestino = "ftp://" & ServidorDestino
            End If

            FuncionesGenerales.Funciones.TextoANotePad(ServidorDestino & vbCrLf & usuario & vbCrLf & pass & vbCrLf & ArchivoOrigen)
            My.Computer.Network.UploadFile(ArchivoOrigen, ServidorDestino, usuario, pass)

        Catch ex2 As WebException
            Dim response As FtpWebResponse = _
               DirectCast(ex2.Response, FtpWebResponse)
            'Does not exist
            If response.StatusCode = _
            FtpStatusCode.ActionNotTakenFileUnavailable Then

                Try


                    Dim dirFtp As FtpWebRequest = CType(FtpWebRequest.Create(CarpetaDestino), FtpWebRequest)

                    ' Los datos del usuario (credenciales)
                    Dim cr As New NetworkCredential(UsuarioFTP, PassWordFTP)
                    dirFtp.Credentials = cr


                    dirFtp.Method = WebRequestMethods.Ftp.MakeDirectory

                    Using respuestaFTP As FtpWebResponse = _
                 DirectCast(dirFtp.GetResponse(), FtpWebResponse)
                        ' Folder exists here
                        '  MsgBox("exists!")
                    End Using

                    My.Computer.Network.UploadFile(ArchivoOrigen, ServidorDestino, UsuarioFTP, PassWordFTP)

                Catch ex As Exception
                    Return ex.Message
                End Try
            End If

        Catch ex As Exception
            Return ex.Message
        End Try
        Return ""
    End Function

    Public Function FTPBorrarFicherosCarpeta(ByVal CarpetaFTP As String, Optional ByVal Extension As String = "") As Integer

        Dim ErrorAlBorrarAlgunFichero As Boolean = False
        Dim ContadorLin As Integer = 0

        Dim Servidor As String = CarpetaFTP & "/"


        Try
            Dim dirFtp As FtpWebRequest = CType(FtpWebRequest.Create(RutaInicialFTP & CarpetaFTP & "/"), FtpWebRequest)

            ' Los datos del usuario (credenciales)
            Dim cr As New NetworkCredential(UsuarioFTP, PassWordFTP)
            dirFtp.Credentials = cr

            ' El comando a ejecutar
            ' dirFtp.Method = "LIST"

            ' También usando la enumeración de WebRequestMethods.Ftp
            dirFtp.Method = WebRequestMethods.Ftp.ListDirectory


            Dim sr As New StreamReader(dirFtp.GetResponse().GetResponseStream())

            Dim Linea As String
            Dim FicheroValido As Boolean = False

            Linea = sr.ReadLine()

            If Linea <> "." And Linea <> ".." Then
                If Extension <> "" Then
                    If Right(Linea, Len(Extension)).ToUpper = Extension.ToUpper Then
                        FicheroValido = True
                    End If
                Else
                    FicheroValido = False
                End If
            End If
            If FicheroValido Then
                If Not FTPBorrarFichero(Servidor & Linea) Then
                    ErrorAlBorrarAlgunFichero = True
                    EscribeLog("Error al borrar el fichero " & Linea)
                End If
            Else
                ContadorLin += 1
            End If


            While Not Linea Is Nothing
                FicheroValido = False
                Linea = sr.ReadLine()

                If Linea <> "." And Linea <> ".." Then

                    


                    If Extension <> "" Then
                        If Right(Linea, Len(Extension)).ToUpper = Extension.ToUpper Then
                            FicheroValido = True
                        End If
                    Else
                        FicheroValido = False
                    End If
                 

                End If
                If FicheroValido Then
                    If Not FTPBorrarFichero(Servidor & Linea) Then
                        ErrorAlBorrarAlgunFichero = True
                        EscribeLog("Error al borrar el fichero " & Linea)
                    End If
                Else
                    ContadorLin += 1
                End If

            End While
            sr.Close()
            dirFtp = Nothing

        Catch ex As Exception

            EscribeLog("Error al hacer el LIST en el FTP. ", ex.Message)
            Return -1

        End Try

        If ErrorAlBorrarAlgunFichero Then
            Return -2
        Else
            Return ContadorLin
        End If
    End Function
    Public Function FTPBorrarFichero(ByVal Origen As String, Optional usuario As String = "", Optional pass As String = "", Optional ruta As String = "") As Boolean
        If usuario = "" Then
            usuario = UsuarioFTP
        End If
        If pass = "" Then
            pass = PassWordFTP
        End If
        Dim peticionFTP As FtpWebRequest
        If ruta = "" Then
            If Not Origen.Contains(RutaInicialFTP) Then Origen = RutaInicialFTP & Origen
        Else
            Origen = "ftp://" & ruta
        End If

        Try
            peticionFTP = CType(WebRequest.Create(New Uri(Origen)), FtpWebRequest)

            ' Fijamos el usuario y la contraseña de la petición
            peticionFTP.Credentials = New NetworkCredential(usuario, pass)

            ' Seleccionamos el comando que vamos a utilizar: Eliminar un fichero
            peticionFTP.Method = WebRequestMethods.Ftp.DeleteFile
            peticionFTP.UsePassive = False

            Dim respuestaFTP As FtpWebResponse
            respuestaFTP = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuestaFTP.Close()
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function
End Class
