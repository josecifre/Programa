Imports System.Xml
Imports FuncionesGenerales.Funciones
Imports System.IO

Module ActualizacionSoftware
    '    Public Sub ActualizarSoftware()

    '        If GL_ContadorEquipo = 0 Then
    '            Exit Sub
    '        End If


    '        If GL_EstoyEnPruebas Then
    '            GL_Descargas = "Demos/Electro/StocksServicio"
    '        Else
    '            GL_Descargas = "Medired/StocksServicio"
    '        End If


    '        Dim ManifestFile As String = "Manifiesto" & My.Application.Info.AssemblyName & ".xml"


    '        Dim CarpetaVersionesAnteriores As String
    '        Dim CarpetaTemporal As String

    '        CarpetaTemporal = ComprobarYCrearCarpetas(My.Application.Info.DirectoryPath & "\Temporal\Ejecutable")
    '        BorrarContenidoCarpeta(CarpetaTemporal)
    '        CarpetaVersionesAnteriores = ComprobarYCrearCarpetas(My.Application.Info.DirectoryPath & "\VersionesAnteriores\Ejecutable")

    '        Dim FTP As New tb_FTP()

    '        If Not FTP.FTPDescargarFichero("clientes/" & GL_Descargas & "/Ejecutable/" & ManifestFile, CarpetaTemporal & "/" & ManifestFile) Then
    '            Exit Sub
    '        End If

    '        Try
    '            Dim m_xmld As XmlDocument
    '            Dim m_nodelist As XmlNodeList
    '            Dim m_node As XmlNode
    '            'Create the XML Document

    '            m_xmld = New XmlDocument
    '            'Load the Xml file

    '            m_xmld.Load(CarpetaTemporal & "\" & ManifestFile)
    '            'Get the list of name nodes 
    '            m_nodelist = m_xmld.SelectNodes("/update/name")

    '            m_node = m_nodelist(0)
    '            'Get the file Attribute Value
    '            Dim fileAttribute = m_node.Attributes.GetNamedItem("file").Value
    '            'Get the fileName Element Value
    '            Dim fileNameValue = m_node.ChildNodes.Item(0).InnerText
    '            'Get the fileVersion Element Value
    '            Dim fileVersionValue = m_node.ChildNodes.Item(1).InnerText
    '            'Get the fileLastModified Value
    '            Dim fileLastModiValue = m_node.ChildNodes.Item(2).InnerText

    '            'Temp file name
    '            Dim TempFileName As String = CarpetaTemporal & "/" & fileNameValue
    '            Dim isToUpgrade As Boolean = False
    '            Dim RealFileName As String = My.Application.Info.DirectoryPath & "\" & fileNameValue
    '            Dim LastModified As Date = CDate(fileLastModiValue)

    '            If fileAttribute = ManifestFile Then

    '                Dim FileExists As Boolean = File.Exists(RealFileName)
    '                'If file not exist then download file
    '                If Not FileExists Then
    '                    isToUpgrade = True
    '                Else
    '                    'check last modified file
    '                    isToUpgrade = (LastModified > File.GetLastWriteTimeUtc(RealFileName))
    '                End If

    '                If isToUpgrade Then

    '                    ''JCB Si nos vamos a actulizar, también actualizaremos el fichero de configuracion AgenteR3B10.exe.Config
    '                    '' En ese fichero se guardan datos de configuración y lo mas importante, donde está el servicio Web
    '                    ' EscribirEnLogsEquiposTrazas(2, "voy a descagar el config", "")
    '                    Dim FicheroConfig As String = My.Application.Info.AssemblyName & ".exe.config"
    '                    If File.Exists(CarpetaTemporal & "\" & FicheroConfig) Then
    '                        File.Delete(CarpetaTemporal & "\" & FicheroConfig)
    '                    End If
    '                    If FTP.FTPDescargarFichero("clientes/" & GL_Descargas & "/Ejecutable/" & FicheroConfig, CarpetaTemporal & "/" & FicheroConfig) Then
    '                        If File.Exists(My.Application.Info.DirectoryPath & "\" & FicheroConfig) Then
    '                            File.Delete(My.Application.Info.DirectoryPath & "\" & FicheroConfig)
    '                        End If
    '                        File.Copy(CarpetaTemporal & "/" & FicheroConfig, My.Application.Info.DirectoryPath & "\" & FicheroConfig)
    '                    End If

    '                    ''JCB

    '                    'En este punto, nos hemos descargado el manifiesto y el programa debe actualizarse, bien porque el manifiesto no es el mismo
    '                    ' o porque directamente no tenía manifiesto.
    '                    'Ahora, lo que haremos será copiar el manifiesto descargado a la carpeta del programaa
    '                    Try
    '                        System.IO.File.Delete(RealFileName)
    '                    Catch ex As Exception
    '                    End Try
    '                    System.IO.File.Copy(CarpetaTemporal & "\" & fileNameValue, RealFileName, True)
    '                    '  EscribirEnLogsEquiposTrazas(2, "Estoy en ActualizarSoftware.", "Fecha Antes: " & File.GetLastWriteTimeUtc(RealFileName))
    '                    File.SetLastWriteTimeUtc(RealFileName, LastModified)
    '                    '  EscribirEnLogsEquiposTrazas(2, "Estoy en ActualizarSoftware.", "Fecha Despues: " & File.GetLastWriteTimeUtc(RealFileName))

    '                    If Not File.Exists(My.Application.Info.DirectoryPath & "/AutoUpdate.exe") Then
    '                        If Not FTP.FTPDescargarFichero("httpdocs/descargas/AutoUpdate.exe", My.Application.Info.DirectoryPath & "/AutoUpdate.exe") Then
    '                            'MsgBox("No se encuentra el programa de actualización. Póngase en contacto con su proveedor")
    '                            Exit Sub
    '                        End If
    '                    End If


    '                    Dim Origen As String
    '                    Dim Destino As String
    '                    Dim Usuario As String
    '                    Dim PassW As String
    '                    Dim ExeFile As String
    '                    Dim CommandLine As String
    '                    Dim ContadorEquipo As String = String.Empty

    '                    'Dim param() As String = Split(Microsoft.VisualBasic.Command(), "|")
    '                    'Origen = param(0)
    '                    'Destino = param(1)
    '                    'Usuario = param(2)
    '                    'PassW = param(3)
    '                    'ExeFile = param(4)
    '                    'ManifestFile = param(5)
    '                    CommandLine = Microsoft.VisualBasic.Command()

    '                    'Origen = "ftp://ftp.tresbits.es/httpdocs/clientes/Ainia/ConsumoData/Ejecutable"
    '                    'Destino = My.Application.Info.DirectoryPath
    '                    'Usuario = "tresbits"
    '                    'PassW = "tb1234"
    '                    'ExeFile = My.Application.Info.DirectoryPath & "/" & My.Application.Info.AssemblyName & ".exe"
    '                    'ManifestFile = "Manifiesto.xml"

    '                    Origen = FTP.RutaInicialFTP & "clientes/" & GL_Descargas & "/Ejecutable"
    '                    Destino = My.Application.Info.DirectoryPath
    '                    Usuario = FTP.UsuarioFTP
    '                    PassW = FTP.PassWordFTP
    '                    ExeFile = My.Application.Info.AssemblyName
    '                    ManifestFile = ManifestFile
    '                    ContadorEquipo = GL_ContadorEquipo.ToString
    '                    'Origen = "ftp://ftp.tresbits.es/httpdocs/clientes/SistemasWeb/Ejecutable"
    '                    'Destino = My.Application.Info.DirectoryPath
    '                    'Usuario = "tresbits"
    '                    'PassW = "tb1234"
    '                    'ExeFile = My.Application.Info.AssemblyName
    '                    'ManifestFile = "Manifiesto.xml"

    '                    Dim startInfo As New ProcessStartInfo(My.Application.Info.DirectoryPath & "\" & "AutoUpdate.exe")
    '                    Dim cmdLine As String
    '                    cmdLine = Origen & "|" & Destino & "|" & Usuario & "|" & PassW & "|" & ExeFile & "|" & ManifestFile & "|SERVICE|" & ContadorEquipo
    '                    startInfo.Arguments = cmdLine
    '                    Process.Start(startInfo)
    '                    End
    '                    'Environment.Exit(0)
    '                End If
    '            End If

    '        Catch ex As Exception
    '            'MsgBox("Error en la actualización de software. " & ex.Message)
    '            EscribirEnLogsEquiposTrazas(2, "Estoy en ActualizarSoftware.", "Error en la actualización de software. " & ex.Message)
    '        End Try

    '    End Sub
    Public Sub ActualizarSoftware()


        'If GL_ContadorEquipo = 0 Then
        '    Exit Sub
        'End If

        Dim TipoDeAplicacion As String = "EXE"  ' o SERVICE

        'If GL_EstoyEnPruebas Then
        '    GL_Descargas = "Demos/Electro/StocksExe"
        'Else
        '    GL_Descargas = "Medired/StocksExe"
        'End If

        'Si trabajo con 3bits, debo ponerlo
        ' GL_TextoHttpdocs = "httpdocs/"
        GL_TextoHttpdocs = ""
        GL_Descargas = ""


        Dim ManifestFile As String = "Manifiesto" & My.Application.Info.AssemblyName & ".xml"

        Dim NombreConRutaFicheroAplicacion As String = My.Application.Info.DirectoryPath & "/" & My.Application.Info.AssemblyName & ".exe"

        Dim CarpetaVersionesAnteriores As String
        Dim CarpetaTemporal As String
        Dim CarpetaActualizaciones As String


        CarpetaTemporal = ComprobarYCrearCarpetas(My.Application.Info.DirectoryPath & "\Temporal\Ejecutable")
        BorrarContenidoCarpeta(CarpetaTemporal)
        CarpetaVersionesAnteriores = FuncionesGenerales.Funciones.ComprobarYCrearCarpetas(My.Application.Info.DirectoryPath & "\VersionesAnteriores\Ejecutable")

        If Right(clVariables.RutaServidor, 1) = "\" Or Right(clVariables.RutaServidor, 1) = "/" Then
            CarpetaActualizaciones = clVariables.RutaServidor & "Actualizaciones"
        Else
            CarpetaActualizaciones = clVariables.RutaServidor & "\Actualizaciones"
        End If

        Dim FTP As New tb_FTP()

        If GL_DESCARGA_POR_FTP Then
            If Not FTP.FTPDescargarFichero(GL_TextoHttpdocs & "clientes/" & GL_Descargas & "/Ejecutable/" & ManifestFile, CarpetaTemporal & "/" & ManifestFile) Then
                Exit Sub
            End If


        Else

            Try
                System.IO.File.Copy(CarpetaActualizaciones & "\" & ManifestFile, CarpetaTemporal & "\" & ManifestFile)
            Catch ex As Exception
                MsgBox("No se pudo comprobar si existen actualizaciones pendientes." & vbCrLf & ex.Message)
                Exit Sub
            End Try
        End If


        Try
            Dim m_xmld As XmlDocument
            Dim m_nodelist As XmlNodeList
            Dim m_node As XmlNode
            'Create the XML Document

            m_xmld = New XmlDocument
            'Load the Xml file

            m_xmld.Load(CarpetaTemporal & "\" & ManifestFile)
            'Get the list of name nodes 
            m_nodelist = m_xmld.SelectNodes("/update/name")

            m_node = m_nodelist(0)
            'Get the file Attribute Value
            Dim fileAttribute = m_node.Attributes.GetNamedItem("file").Value
            'Get the fileName Element Value
            Dim fileNameValue = m_node.ChildNodes.Item(0).InnerText
            'Get the fileVersion Element Value
            Dim fileVersionValue = m_node.ChildNodes.Item(1).InnerText
            'Get the fileLastModified Value
            Dim fileLastModiValue = m_node.ChildNodes.Item(2).InnerText

            'Temp file nam
            Dim TempFileName As String = CarpetaTemporal & "/" & fileNameValue
            Dim isToUpgrade As Boolean = False
            Dim RealFileName As String = My.Application.Info.DirectoryPath & "\" & fileNameValue
            Dim LastModified As Date = CDate(fileLastModiValue)



            If fileAttribute = ManifestFile Then

                Dim FileExists As Boolean = File.Exists(RealFileName)
                'If file not exist then download file
                If Not FileExists Then
                    isToUpgrade = True
                Else
                    'check last modified file
                    isToUpgrade = (LastModified > File.GetLastWriteTimeUtc(RealFileName))
                   
                    'NUEVO JCB 18/02/12  PARA QUE MIRE SI LA VERSION DEL EXE nueva es > vieja. Entonces, se lo baja si o si
                    If Not isToUpgrade Then

                        If File.Exists(NombreConRutaFicheroAplicacion) Then

                            m_xmld = New XmlDocument
                            'Load the Xml file

                            m_xmld.Load(CarpetaTemporal & "\" & ManifestFile)
                            'Get the list of name nodes 
                            m_nodelist = m_xmld.SelectNodes("/update/name")

                            '   Dim fv As FileVersionInfo
                            For Each m_node In m_nodelist
                                If m_node.Attributes.GetNamedItem("file").Value = My.Application.Info.AssemblyName & ".exe" Then
                                    ' fv = FileVersionInfo.GetVersionInfo(NombreConRutaFicheroAplicacion)
                                    fileVersionValue = m_node.ChildNodes.Item(1).InnerText
                                    isToUpgrade = EsParaActualizar(NombreConRutaFicheroAplicacion, fileVersionValue)

                                    'isToUpgrade = fileVersionValue <> fv.FileMajorPart & "." & fv.FileMinorPart & "." & fv.FileBuildPart & "." & fv.FilePrivatePart
                                    If Not isToUpgrade Then

                                        isToUpgrade = (m_node.ChildNodes.Item(2).InnerText > File.GetLastWriteTimeUtc(NombreConRutaFicheroAplicacion))
                                        Exit For
                                    End If
                                End If
                            Next
                        End If
                    End If
                    'NUEVO JCB 18/02/12  PARA QUE MIRE SI LA VERSION DEL EXE ES <>. Entonces, se lo baja si o si

                End If

                If isToUpgrade Then



                    ''JCB Si nos vamos a actulizar, también actualizaremos el fichero de configuracion AgenteR3B10.exe.Config
                    '' En ese fichero se guardan datos de configuración y lo mas importante, donde está el servicio Web
                    Dim FicheroConfig As String = My.Application.Info.AssemblyName & ".exe.config"
                    If File.Exists(CarpetaTemporal & "\" & FicheroConfig) Then
                        File.Delete(CarpetaTemporal & "\" & FicheroConfig)
                    End If

                    If GL_DESCARGA_POR_FTP Then
                        If FTP.FTPDescargarFichero(GL_TextoHttpdocs & "clientes/" & GL_Descargas & "/Ejecutable/" & FicheroConfig, CarpetaTemporal & "/" & FicheroConfig) Then
                            If File.Exists(My.Application.Info.DirectoryPath & "\" & FicheroConfig) Then
                                File.Delete(My.Application.Info.DirectoryPath & "\" & FicheroConfig)
                            End If
                            File.Copy(CarpetaTemporal & "/" & FicheroConfig, My.Application.Info.DirectoryPath & "\" & FicheroConfig)
                        End If
                    Else

                        If System.IO.File.Exists(CarpetaActualizaciones & "\" & FicheroConfig) Then
                            If File.Exists(My.Application.Info.DirectoryPath & "\" & FicheroConfig) Then
                                File.Delete(My.Application.Info.DirectoryPath & "\" & FicheroConfig)
                            End If
                            System.IO.File.Copy(CarpetaActualizaciones & "\" & FicheroConfig, My.Application.Info.DirectoryPath & "\" & FicheroConfig)
                        End If

                    End If


                    ''JCB

                    'En este punto, nos hemos descargado el manifiesto y el programa debe actualizarse, bien porque el manifiesto no es el mismo
                    ' o porque directamente no tenía manifiesto.
                    'Ahora, lo que haremos será copiar el manifiesto descargado a la carpeta del programaa
                    Try
                        System.IO.File.Delete(RealFileName)
                    Catch ex As Exception
                    End Try
                    System.IO.File.Copy(CarpetaTemporal & "\" & fileNameValue, RealFileName, True)
                    File.SetLastWriteTimeUtc(RealFileName, LastModified)

                    If Not File.Exists(My.Application.Info.DirectoryPath & "/AutoUpdate.exe") Then

                        If GL_DESCARGA_POR_FTP Then
                            If Not FTP.FTPDescargarFichero("clientes/AutoUpdate.exe", My.Application.Info.DirectoryPath & "/AutoUpdate.exe") Then
                                'MsgBox("No se encuentra el programa de actualización. Póngase en contacto con su proveedor")
                                Exit Sub
                            End If
                        Else
                            Try
                                System.IO.File.Copy(clVariables.RutaServidor & "\AutoUpdate.exe", My.Application.Info.DirectoryPath & "\AutoUpdate.exe")

                            Catch ex As Exception
                                MsgBox("No se encuentra el programa de actualización. Póngase en contacto con su proveedor")
                                Exit Sub
                            End Try
                        End If

                    End If


                    'NUEVO JCB 18/02/12  PARA QUE actualice AutoUpdate


                    m_xmld = New XmlDocument
                    'Load the Xml file

                    m_xmld.Load(CarpetaTemporal & "\" & ManifestFile)
                    'Get the list of name nodes 
                    m_nodelist = m_xmld.SelectNodes("/update/name")
                    For Each m_node In m_nodelist
                        If m_node.Attributes.GetNamedItem("file").Value = "AutoUpdate.exe" Then
                            fileVersionValue = m_node.ChildNodes.Item(1).InnerText

                            If EsParaActualizar(My.Application.Info.DirectoryPath & "/AutoUpdate.exe", fileVersionValue) Then
                                ActualizarAutoUpdate()
                            Else
                                If m_node.ChildNodes.Item(2).InnerText > File.GetLastWriteTimeUtc(My.Application.Info.DirectoryPath & "/AutoUpdate.exe") Then
                                    ActualizarAutoUpdate()
                                End If

                            End If
                            Exit For
                        End If
                    Next
                    'NUEVO JCB 18/02/12  PARA QUE actualice AutoUpdate


                    Dim Origen As String
                    Dim Destino As String
                    Dim Usuario As String
                    Dim PassW As String
                    Dim ExeFile As String
                    Dim CommandLine As String
                    Dim ContadorEquipo As String = String.Empty

                    'Dim param() As String = Split(Microsoft.VisualBasic.Command(), "|")
                    'Origen = param(0)
                    'Destino = param(1)
                    'Usuario = param(2)
                    'PassW = param(3)
                    'ExeFile = param(4)
                    'ManifestFile = param(5)
                    CommandLine = Microsoft.VisualBasic.Command()




                    If GL_DESCARGA_POR_FTP Then
                        Origen = FTP.RutaInicialFTP & GL_TextoHttpdocs & IIf(Microsoft.VisualBasic.Right(FTP.RutaInicialFTP, 1) = "/", "", "/") & "clientes/" & GL_Descargas & "/Ejecutable"

                        Destino = My.Application.Info.DirectoryPath
                        Usuario = FTP.UsuarioFTP
                        PassW = FTP.PassWordFTP
                        ExeFile = My.Application.Info.AssemblyName
                        ManifestFile = ManifestFile
                        ContadorEquipo = 0


                        Dim startInfo As New ProcessStartInfo(My.Application.Info.DirectoryPath & "\" & "AutoUpdate.exe")
                        Dim cmdLine As String
                        cmdLine = Origen & "|" & Destino & "|" & Usuario & "|" & PassW & "|" & ExeFile & "|" & ManifestFile & "|" & TipoDeAplicacion & "|" & ContadorEquipo
                        startInfo.Arguments = cmdLine
                        Process.Start(startInfo)
                    Else

                        Origen = clVariables.RutaServidor & "\Actualizaciones"
                        Destino = My.Application.Info.DirectoryPath
                        'Usuario = FTP.UsuarioFTP
                        Usuario = ""
                        'PassW = FTP.PassWordFTP
                        PassW = ""
                        ExeFile = My.Application.Info.DirectoryPath & "\" & My.Application.Info.AssemblyName & ".exe"
                        ManifestFile = ManifestFile
                        ' Dim startInfo As New ProcessStartInfo(clVariables.RutaServidor & "\AutoUpdate.exe")
                        Dim startInfo As New ProcessStartInfo(My.Application.Info.DirectoryPath & "\AutoUpdate.exe")
                        Dim cmdLine As String
                        cmdLine = Origen & "|""" & Destino & """|""" & Usuario & """|""" & PassW & """|""" & ExeFile & """|" & ManifestFile & "|EXE|""" & My.Application.Info.AssemblyName & """"
                        startInfo.Arguments = cmdLine





                        Process.Start(startInfo)
                    End If



                    End
                    'Environment.Exit(0)
                End If
            End If

        Catch ex As Exception
            'MsgBox("Error en la actualización de software. " & ex.Message)
        End Try

    End Sub
    Private Sub ActualizarAutoUpdate()
        Try
            Dim FTP As New tb_FTP()

            System.IO.File.Delete(My.Application.Info.DirectoryPath & "/AutoUpdate.exe")
            FTP.FTPDescargarFichero(GL_TextoHttpdocs & "clientes/" & GL_Descargas & "/Ejecutable/AutoUpdate.exe", My.Application.Info.DirectoryPath & "/AutoUpdate.exe")
            Dim stopwatch As Stopwatch = stopwatch.StartNew
            Threading.Thread.Sleep(5000)
            stopwatch.Stop()
        Catch ex As Exception

        End Try
    End Sub

    Private Function EsParaActualizar(ByVal FicheroAComparar As String, ByVal VersionDelManifiesto As String) As Boolean

        Dim isToUpgrade As Boolean = False

        Dim fv As FileVersionInfo
        fv = FileVersionInfo.GetVersionInfo(FicheroAComparar)


        Dim FileMajorP As Integer = 0
        Dim FileMinorP As Integer = 0
        Dim FileBuildP As Integer = 0
        Dim FilePrivateP As Integer = 0
        Dim LeoTodasLasPartes As Boolean = False

        Dim PosicionPunto As Integer = 0
        Dim PosicionPuntoAnterior As Integer = 0

        If VersionDelManifiesto.Length > 1 Then

            PosicionPunto = InStr(VersionDelManifiesto, ".", CompareMethod.Text)
            If PosicionPunto > 1 Then
                FileMajorP = Left(VersionDelManifiesto, PosicionPunto - 1)
            End If
        End If

        PosicionPuntoAnterior = PosicionPunto + 1
        If VersionDelManifiesto.Length > PosicionPuntoAnterior Then

            PosicionPunto = InStr(PosicionPuntoAnterior, VersionDelManifiesto, ".", CompareMethod.Text)
            If PosicionPunto > 1 Then
                FileMinorP = Mid(VersionDelManifiesto, PosicionPuntoAnterior, PosicionPunto - PosicionPuntoAnterior)
            End If

        End If

        PosicionPuntoAnterior = PosicionPunto + 1
        If VersionDelManifiesto.Length > PosicionPuntoAnterior Then

            PosicionPunto = InStr(PosicionPuntoAnterior, VersionDelManifiesto, ".", CompareMethod.Text)
            If PosicionPunto > 1 Then
                FileBuildP = Mid(VersionDelManifiesto, PosicionPuntoAnterior, PosicionPunto - PosicionPuntoAnterior)

            End If

        End If

        PosicionPuntoAnterior = PosicionPunto + 1
        If VersionDelManifiesto.Length > PosicionPuntoAnterior Then
            FilePrivateP = Right(VersionDelManifiesto, VersionDelManifiesto.Length - PosicionPuntoAnterior + 1)
            LeoTodasLasPartes = True
        End If

        If LeoTodasLasPartes Then
            If FileMajorP > fv.FileMajorPart Then
                isToUpgrade = True
                Return True
            Else
                If FileMinorP > fv.FileMinorPart Then
                    isToUpgrade = True
                    Return True
                Else
                    If FileBuildP > fv.FileBuildPart Then
                        isToUpgrade = True
                        Return True
                    Else
                        If FilePrivateP > fv.FilePrivatePart Then
                            isToUpgrade = True
                            Return True
                        End If

                    End If
                End If
            End If
        End If



        Return False


    End Function
End Module
