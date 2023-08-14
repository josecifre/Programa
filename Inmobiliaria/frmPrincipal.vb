Imports DevExpress.LookAndFeel
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.XtraBars
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraPrinting
Imports System.IO
Imports FuncionesGenerales.Funciones
Imports WordPressPCL
Imports WordPressPCL.Models
Imports System.Net.Http

Public Class frmPrincipal

    Dim PrimeraVez As Boolean

    Sub New()

        InitializeComponent()
        InitSkins()

        Me.InitSkinGallery()


    End Sub
    Sub InitSkins()
        DevExpress.Skins.SkinManager.EnableFormSkins()
        DevExpress.UserSkins.BonusSkins.Register()
        UserLookAndFeel.Default.SetSkinStyle("Metropolis")
        'UserLookAndFeel.Default.SetSkinStyle("Office 2010 Blue")

    End Sub
    Private Sub InitSkinGallery()
        SkinHelper.InitSkinGallery(rgbiSkins, True)
    End Sub


    Private Sub frmPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'If System.IO.File.Exists(My.Application.Info.DirectoryPath & "\Fondo.jpg") Then
        '    PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\Fondo.jpg")
        'End If

        'SplashScreen1.Show()

        'If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\fondo.jpg") Then
        '    Me.PictureBox1.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\fondo.jpg")
        'End If
        'If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\fondo.png") Then
        '    Me.PictureBox1.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\fondo.png")
        'End If
        Panellmagenes.Parent = PictureBox1

        InitSkins()
        'InitializeComponent()
        Me.InitSkinGallery()

        LlenarGallerySkins()

        GL_PropietariosPendienteActualizacion = False

        ribbonControl.Minimized = True


        Me.Top = 0

        ''#If DEBUG Then
        ''#Else

        If Not Debugger.IsAttached Then
            If FuncionesGenerales.LeerIni.ActualizacionesAutomaticas Then
                If My.Application.CommandLineArgs.Count = 0 Then
                    ActualizarSoftware()
                Else
                    Select Case My.Application.CommandLineArgs(0)

                        Case "-1"
                            MsgBox("ERROR AL DESCARGAR ALGÚN FICHERO DURANTE LA ACTUALIZACIÓN." & vbCrLf & "PÓNGASE EN CONTACTO CON SU PROVEEDOR")
                        Case "1"


                            Dim RutaOr As String
                            Dim RutaDes As String

                            RutaOr = My.Application.Info.DirectoryPath & "/EnviosVenalia.exe"
                            RutaDes = My.Application.Info.DirectoryPath & "/EnviosVenalia/EnviosVenalia.exe"

                            If System.IO.File.Exists(RutaOr) Then
                                Try
                                    IO.File.Delete(RutaDes)
                                    IO.File.Copy(RutaOr, RutaDes, True)
                                    IO.File.Delete(RutaOr)
                                Catch ex As Exception

                                End Try
                            End If

                            RutaOr = My.Application.Info.DirectoryPath & "/EnviosVenalia.exe.config"
                            RutaDes = My.Application.Info.DirectoryPath & "/EnviosVenalia/EnviosVenalia.exe.config"

                            If System.IO.File.Exists(RutaOr) Then
                                Try
                                    IO.File.Delete(RutaDes)
                                    IO.File.Copy(RutaOr, RutaDes, True)
                                    IO.File.Delete(RutaOr)
                                Catch ex As Exception

                                End Try
                            End If



                            RutaOr = My.Application.Info.DirectoryPath & "/BD_Vacia.db3"
                            RutaDes = My.Application.Info.DirectoryPath & "/Sincronizacion/BD_Vacia.db3"

                            If System.IO.File.Exists(RutaOr) Then
                                Try
                                    IO.File.Delete(RutaDes)
                                    IO.File.Copy(RutaOr, RutaDes, True)
                                    IO.File.Delete(RutaOr)
                                Catch ex As Exception

                                End Try
                            End If



                            MsgBox("La aplicación se actualizó correctamente a la versión " & ProductVersion)

                    End Select
                End If
            End If
        End If

        ''#End If

        'SplashScreen1.Close()

        FuncionesGenerales.LeerIni.LeerFicheroInicializacion()

        'If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\fondo.jpg") Then
        '    Me.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\fondo.jpg")
        'End If

        'Me.Icon = My.Resources.Icono

        '  Me.Text = ProductName & " - Versión: " & ProductVersion & " - by TresBits"


        'Antes de entrar, miramos VenaliaEmpresas, la cadena de conexión 1.
        'Puede pasar lo siguiente:

        '1. No existe VenaliaEmpresas. Esto será lo mas normal
        '   El nombre de la base de datos será Venalia (De momento Venalia2)

        '2. Existe VenaliaEmpresas y la tabla de empresas tiene un registro. 
        '   Leemos el nombre de la base de datos de esa tabla

        '2. Existe VenaliaEmpresas y la tabla de empresas tiene mas un registro. 
        '   Sacamos una pantalla para que elija la empresa, y una vez elegida, actuamos como en el punto 2

        DatosEmpresa = New VariablesGlobales.clDatosEmpresa


        'If GL_TipoBD = EnumTipoBD.ACCESS Then
        '    'Comprobaremos con un file.exists si existe
        '    Dim bdBuscaEmpresa As New BaseDatos(1)
        '    bdBuscaEmpresa.cnAccess.ConnectionString = clVariables.CadenaConexion1
        '    Try
        '        bdBuscaEmpresa.AbrirBD()
        '        If bdBuscaEmpresa.Execute("SELECT COUNT(*) FROM Empresas", False) > 1 Then
        '            'Mostar pantalla
        '            MsgBox("Falta pantalla")
        '        Else
        '            DatosEmpresa.BaseDatos = bdBuscaEmpresa.Execute("SELECT BaseDatos FROM Empresas", False)
        '        End If
        '        bdBuscaEmpresa.CerrarBD()
        '    Catch exs As SqlException

        '        If exs.Number = 4060 Then  'No se puede abrir
        '            DatosEmpresa.BaseDatos = "Venalia2"
        '        Else

        '        End If

        '    Catch ex As Exception

        '    End Try
        'End If

        'If GL_TipoBD = EnumTipoBD.SQL_SERVER Then
        '    Dim bdBuscaEmpresa As New BaseDatos(1)
        '    bdBuscaEmpresa.cn.ConnectionString = clVariables.CadenaConexion1
        '    Try
        '        bdBuscaEmpresa.AbrirBD()
        '        If bdBuscaEmpresa.Execute("SELECT COUNT(*) FROM Empresas", False) > 1 Then
        '            'Mostar pantalla
        '            MsgBox("Falta pantalla")
        '        Else
        '            DatosEmpresa.BaseDatos = bdBuscaEmpresa.Execute("SELECT BaseDatos FROM Empresas", False)
        '        End If
        '        bdBuscaEmpresa.CerrarBD()
        '    Catch exs As SqlException

        '        If exs.Number = 4060 Then  'No se puede abrir
        '            DatosEmpresa.BaseDatos = "Venalia2"
        '        Else

        '        End If

        '    Catch ex As Exception

        '    End Try

        'End If

        'clVariables.BaseDatos = DatosEmpresa.BaseDatos
        ''  clVariables.BaseDatos = "PLB"

        If GL_BD_VENALIA <> "" Then
            DatosEmpresa.BaseDatos = GL_BD_VENALIA
        Else
            DatosEmpresa.BaseDatos = "Venalia2"
        End If

        clVariables.BaseDatos = DatosEmpresa.BaseDatos


        If GL_TipoBD = EnumTipoBD.ACCESS Then
            'Comprobaremos con un file.exists si existe
            If Not Funciones.PrepararCadenaDeConexionAccess(clVariables.RutaServidor & "\" & DatosEmpresa.BaseDatos & "." & TIPOACCESS) Then
                End
            End If

            cnAccessUnica = New OleDb.OleDbConnection
            Dim CadenaConexionUnicaAccess As String = Replace(clVariables.CadenaConexion, "APP=Venalia", "APP=Venalia_Unica")
            cnAccessUnica.ConnectionString = CadenaConexionUnicaAccess
            cmdAccessUnica = New OleDb.OleDbCommand
            cmdAccessUnica.Connection = cnAccessUnica

            cnAccessUnicaDTR = New OleDb.OleDbConnection
            Dim CadenaConexionUnicaAccessDTR As String = Replace(clVariables.CadenaConexion, "APP=Venalia", "APP=Venalia_Unica_DTR")
            cnAccessUnicaDTR.ConnectionString = CadenaConexionUnicaAccessDTR
            cmdAccessUnicaDTR = New OleDb.OleDbCommand
            cmdAccessUnicaDTR.Connection = cnAccessUnicaDTR
        End If

        If GL_TipoBD = EnumTipoBD.SQL_SERVER Then
            If Not FuncionesGenerales.Funciones.PrepararCadenaDeConexion(IIf(clVariables.PassWordUsuarioSQL = "", True, False)) Then
                End
            End If

            cnSQLServerUnica = New SqlClient.SqlConnection
            Dim CadenaConexionUnicaSQLServer As String = Replace(clVariables.CadenaConexion, "APP=Venalia", "APP=Venalia_Unica")
            cnSQLServerUnica.ConnectionString = CadenaConexionUnicaSQLServer
            cmdSQLServerUnica = New SqlClient.SqlCommand
            cmdSQLServerUnica.Connection = cnSQLServerUnica

            cnSQLServerUnicaDTR = New SqlClient.SqlConnection
            Dim CadenaConexionUnicaSQLServerDTR As String = Replace(clVariables.CadenaConexion, "APP=Venalia", "APP=Venalia_Unica_DTR")
            cnSQLServerUnicaDTR.ConnectionString = CadenaConexionUnicaSQLServerDTR
            cmdSQLServerUnicaDTR = New SqlClient.SqlCommand
            cmdSQLServerUnicaDTR.Connection = cnSQLServerUnicaDTR
        End If

        BD_CERO = New BaseDatos






        DatosEmpresa.Codigo = BD_CERO.Execute("SELECT Codigo FROM Empresas", False)
        DatosEmpresa.Nombre = BD_CERO.Execute("SELECT Nombre FROM Empresas", False)
        DatosEmpresa.NombreComercial = BD_CERO.Execute("SELECT NombreComercial FROM Empresas", False)
        DatosEmpresa.WordPress = BD_CERO.Execute("SELECT WordPress FROM Empresas", False)

        If DatosEmpresa.NombreComercial.Trim = "" Then
            DatosEmpresa.NombreComercial = DatosEmpresa.Nombre
        End If
        GL_CarpetaFotos = clVariables.RutaServidor & "/Fotos/" & DatosEmpresa.Codigo
        GL_CarpetaFotosBaja = clVariables.RutaServidor & "/FotosBaja/" & DatosEmpresa.Codigo
        GL_CarpetaFotosEliminadas = clVariables.RutaServidor & "/FotosEliminadas/" & DatosEmpresa.Codigo

        Try
            Dim SelCrear As String
            SelCrear = "ALTER TABLE ConfiguracionWeb ADD ftpClienteDireccion varchar(50)"
            BD_CERO.Execute(SelCrear)
            SelCrear = "ALTER TABLE ConfiguracionWeb ADD ftpClienteUsuario varchar(50)"
            BD_CERO.Execute(SelCrear)
            SelCrear = "ALTER TABLE ConfiguracionWeb ADD ftpClientePass varchar(50)"
            BD_CERO.Execute(SelCrear)


            Select Case DatosEmpresa.Codigo
                Case 3
                    SelCrear = "UPDATE ConfiguracionWeb SET ftpClienteDireccion = '396DAC60BAA617F04DDBC7C1B15679118B11D5C233FCDD88'"
                    BD_CERO.Execute(SelCrear)

                    '                SelCrear = "UPDATE ConfiguracionWeb SET ftpClienteUsuario = 'casano'"
                    SelCrear = "UPDATE ConfiguracionWeb SET ftpClienteUsuario = '433D818BAE779292'"
                    BD_CERO.Execute(SelCrear)

                    '                SelCrear = "UPDATE ConfiguracionWeb SET ftpClientePass = 'in1234#TB'"
                    SelCrear = "UPDATE ConfiguracionWeb SET ftpClientePass = 'F0D26A107CECEE412D92BF0958C71B8E'"
                    BD_CERO.Execute(SelCrear)
                Case 2
                    SelCrear = "UPDATE ConfiguracionWeb SET ftpClienteDireccion = ''"
                    BD_CERO.Execute(SelCrear)

                    '                SelCrear = "UPDATE ConfiguracionWeb SET ftpClienteUsuario = 'casano'"
                    SelCrear = "UPDATE ConfiguracionWeb SET ftpClienteUsuario = ''"
                    BD_CERO.Execute(SelCrear)

                    '                SelCrear = "UPDATE ConfiguracionWeb SET ftpClientePass = 'in1234#TB'"
                    SelCrear = "UPDATE ConfiguracionWeb SET ftpClientePass = ''"
                    BD_CERO.Execute(SelCrear)

            End Select





        Catch ex As Exception

        End Try

        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Metropolis")
        Dim CurrentSkin As DevExpress.Skins.Skin
        CurrentSkin = DevExpress.Skins.CommonSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default)
        CurrentSkin.Colors("Control") = Color.GhostWhite
        ' CurrentSkin.Colors("ControlText") = Color.DodgerBlue
        CurrentSkin.Colors("ControlText") = System.Drawing.ColorTranslator.FromHtml("#488fd6")
        'CurrentSkin.Colors("ControlText") = Color.DeepSkyBlue
        Dim mensaje As String = FuncionesMantenimiento.ActualizarBD()
        If mensaje <> "" AndAlso mensaje <> "ok" Then
            'MensajeError("No se ha podido actualizar la BD, contacte con el administrador del Software")
            Funciones.EnviarCorreoConCuentaConfigurada("josecifre@tresbits.es", "Venalia error Actualizacion BD", mensaje)
        Else
            If mensaje = "ok" Then Funciones.EnviarCorreoConCuentaConfigurada("josecifre@tresbits.es", "Venalia Actualizacion BD Correcta", mensaje)
        End If

        frmLogin.ShowDialog()
        '   UserLookAndFeel.Default.SetSkinStyle(GL_DisenoPerfil)
        'Dim PassEncriptada As String
        'PassEncriptada = Encriptacion.Encriptar("", "LAMBDAPI")

        If GL_TipoUsuario Is Nothing OrElse GL_TipoUsuario = "" Then
            Me.Close()
            Exit Sub
        End If


        GL_ConfiguracionWeb = New Tablas.clConfiguracionWeb


        Dim Sel As String

        Sel = "SELECT TipoVenta FROM TipoVenta WHERE TipoVenta = 'ALQUILER' OR TipoVenta = 'EN ALQUILER'"
        GL_Palabra_Alquiler = BD_CERO.Execute(Sel, False, "")
        If GL_Palabra_Alquiler = "" Then
            MensajeError("No se encuentra un valor para ALQUILER en TipoVenta")
            End
        End If

        Sel = "SELECT * FROM TipoVenta WHERE TipoVenta = 'VENTA' OR TipoVenta = 'EN VENTA'"
        GL_Palabra_Venta = BD_CERO.Execute(Sel, False, "")
        If GL_Palabra_Venta = "" Then
            MensajeError("No se encuentra un valor para VENTA en TipoVenta")
            End
        End If


        Sel = "SELECT * FROM ConfiguracionWeb WHERE CodigoEmpresa = " & DatosEmpresa.Codigo


        Dim dtr As Object
        ' dtr = TryCast(dtr, SqlClient.SqlDataReader)
        'Dim dtr As SqlClient.SqlDataReader
        Dim bdlo As New BaseDatos
        dtr = bdlo.ExecuteReader(Sel)




        If dtr.hasrows Then
            dtr.Read

            'While dtr.Read
            GL_ConfiguracionWeb.API_WP = IIf(IsDBNull(dtr("API_WP")), "", Encriptacion.DesEncriptar(dtr("API_WP"), "LAMBDAPI"))
            Try
                GL_ConfiguracionWeb.API_WP_ESPANOL = dtr("API_WP_ESPANOL")

                If GL_ConfiguracionWeb.API_WP_ESPANOL Then
                    GL_ConfiguracionWeb.API_WP_Funcion_TipoVentas = "estatus-propiedad"
                    GL_ConfiguracionWeb.API_WP_Funcion_Poblacion = "ciudades-propiedad"
                    GL_ConfiguracionWeb.API_WP_Funcion_Propiedades = "properties"
                    GL_ConfiguracionWeb.API_WP_Funcion_Tipos = "tipos-propiedad"
                Else
                    GL_ConfiguracionWeb.API_WP_Funcion_TipoVentas = "property-statuses"
                    GL_ConfiguracionWeb.API_WP_Funcion_Poblacion = "property-cities"
                    GL_ConfiguracionWeb.API_WP_Funcion_Propiedades = "properties"
                    GL_ConfiguracionWeb.API_WP_Funcion_Tipos = "property-types"
                End If



            Catch ex As Exception
                GL_ConfiguracionWeb.API_WP_ESPANOL = False
            End Try

            GL_ConfiguracionWeb.APP3B = IIf(Encriptacion.DesEncriptar(dtr("APP3B"), "LAMBDAPI") = "SIAPP", True, False)
            GL_ConfiguracionWeb.web3B = IIf(Encriptacion.DesEncriptar(dtr("web3B"), "LAMBDAPI") = "SIWEB", True, False)
            GL_ConfiguracionWeb.DirectorioFotos = Encriptacion.DesEncriptar(dtr("DirectorioFotos"), "LAMBDAPI")
            If DatosEmpresa.Codigo = 2 Then
                GL_ConfiguracionWeb.DirectorioFotos = GL_ConfiguracionWeb.DirectorioFotos & "/1"
            Else
                GL_ConfiguracionWeb.DirectorioFotos = GL_ConfiguracionWeb.DirectorioFotos & "/" & DatosEmpresa.Codigo
            End If

            GL_ConfiguracionWeb.PaginaDetalle = Encriptacion.DesEncriptar(dtr("PaginaDetalle"), "LAMBDAPI")
            'GL_ConfiguracionWeb.PaginaDetalle = GL_ConfiguracionWeb.PaginaDetalle & "?e=" & DatosEmpresa.Codigo & "&r="
            If DatosEmpresa.Codigo <> 2 Then
                GL_ConfiguracionWeb.PaginaDetalle = GL_ConfiguracionWeb.PaginaDetalle.Replace(".aspx", "/")
            End If

            GL_ConfiguracionWeb.PaginaBusqueda = Encriptacion.DesEncriptar(dtr("PaginaBusqueda"), "LAMBDAPI")

            GL_ConfiguracionWeb.Pass = Encriptacion.DesEncriptar(dtr("Pass"), "LAMBDAPI")
            GL_ConfiguracionWeb.Servidor = Encriptacion.DesEncriptar(dtr("Servidor"), "LAMBDAPI")
            GL_ConfiguracionWeb.Usuario = Encriptacion.DesEncriptar(dtr("Usuario"), "LAMBDAPI")
            GL_ConfiguracionWeb.Web = Encriptacion.DesEncriptar(dtr("Web"), "LAMBDAPI")

            GL_ConfiguracionWeb.WebConHHTP = ObtenerWebEmpresa()

            If dtr("url_baja") <> "" Then
                GL_ConfiguracionWeb.url_baja = GL_ConfiguracionWeb.WebConHHTP & "/" & dtr("url_baja")
            End If

            GL_ConfiguracionWeb.WP_Id_Agente = dtr("WP_Id_Agente")
            GL_ConfiguracionWeb.WP_Id_Oportunidad = dtr("WP_Id_Oportunidad")
            GL_ConfiguracionWeb.WP_ColorOportunidad = dtr("WP_ColorOportunidad")




            GL_ConfiguracionWeb.FTPClienteDireccion = Encriptacion.DesEncriptar(dtr("ftpClienteDireccion"), "LAMBDAPI")
            GL_ConfiguracionWeb.FTPClienteUsuario = Encriptacion.DesEncriptar(dtr("ftpClienteUsuario"), "LAMBDAPI")
            GL_ConfiguracionWeb.FTPClientePass = Encriptacion.DesEncriptar(dtr("ftpClientePass"), "LAMBDAPI")
            'End While


        Else
            GL_ConfiguracionWeb.APP3B = False
            GL_ConfiguracionWeb.web3B = False
            GL_ConfiguracionWeb.DirectorioFotos = ""
            GL_ConfiguracionWeb.PaginaDetalle = ""
            GL_ConfiguracionWeb.PaginaBusqueda = ""
            GL_ConfiguracionWeb.Pass = ""
            GL_ConfiguracionWeb.Servidor = ""
            GL_ConfiguracionWeb.Usuario = ""
            GL_ConfiguracionWeb.Web = ""
            GL_ConfiguracionWeb.WebConHHTP = ""
            GL_ConfiguracionWeb.FTPClienteDireccion = ""
            GL_ConfiguracionWeb.FTPClienteUsuario = ""
            GL_ConfiguracionWeb.FTPClientePass = ""
        End If
        dtr.close()
        'bdlo.CerrarBD()
        GL_PoblacionPrederminada = BD_CERO.Execute("SELECT Poblacion FROM Poblacion WHERE Predeterminada = " & GL_SQL_VALOR_1, False, "")

        'CamiarCodigoEmpresa(6)
        Me.Text = ProductName & " - Versión: " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.MajorRevision & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.MinorRevision

        XtraTabbedMdiManager1.MdiParent = Me

        '     CrearGalleryOrganismos()

        ribbonControl.SelectedPage = ribbonControl.Pages.Item("Ventas")

        If GL_Usuario = "SUPERADMINISTRADOR" Then
            ribbonControl.Pages("TresBits").Visible = True
        End If
        If GL_Usuario = "SUPERADMINISTRADOR" OrElse GL_TipoUsuario = "ADMINISTRADOR" Then
            pgMantenimientos.Visible = True
            pgListados.Visible = True
        End If



        'Sel = "" & GL_SQL_DELETE & "FROM NuevasAltas WHERE DATEDIFF (" & GL_SQL_D & ",Fecha," & gl_sql_getdate & ") > 30"
        'BD_CERO.Execute(Sel)

        'Sel = "" & GL_SQL_DELETE & "FROM NuevasReservasQuitadas WHERE DATEDIFF (" & GL_SQL_D & ",Fecha," & gl_sql_getdate & ") > 30"
        'BD_CERO.Execute(Sel)

        'Sel = "" & GL_SQL_DELETE & "FROM NuevosCambiosPrecios WHERE DATEDIFF (" & GL_SQL_D & ",Fecha," & gl_sql_getdate & ") > 30"
        'BD_CERO.Execute(Sel)




        AparienciaGeneral()


        'Me.Height = Screen.PrimaryScreen.WorkingArea.Height
        'Me.Width = Screen.PrimaryScreen.WorkingArea.Width
        'Me.Left = 0
        'Me.Top = 0


        'lblUsuario.Top = ribbonControl.Top + ribbonControl.Height + 10
        'lblUsuario.Left = Screen.PrimaryScreen.WorkingArea.Width - (50 + lblUsuario.Width)
        'lblUsuario.Text = "Usuario: <b><color=SteelBlue>" & GL_Usuario & "</b></color>"
        'lblUsuario.BackColor = Color.Transparent
        '   ListadoRevista()
        txtUsuario.Caption = "Usuario: <b><color=SteelBlue>" & GL_Usuario & "     </b></color>"
        'Panellmagenes.Left = (Me.Width / 2) - (Panellmagenes.Width) / 2
        'Panellmagenes.Top = (Me.Height / 2) - (Panellmagenes.Height) / 2

        'Sel = "DELETE FROM ClientesComunicaciones WHERE Tipo <> 'LLAMADA' AND Tipo <> 'VISITA OFICINA' "
        'BD_CERO.Execute(Sel)

        dtr = bdlo.ExecuteReader("SELECT Portal, 'C' as Tipo FROM PortalesCreados Union All SELECT Portal, 'T' as Tipo FROM Portales ") '
        'dtr = bdlo.ExecuteReader("SELECT * FROM ClientePortales WHERE Activo = 1")

        If dtr.hasrows Then
            While dtr.read
                If dtr("Tipo") = "T" Then
                    GL_Portales.Add(dtr("Portal")) 'los q existes
                Else
                    GL_PortalesCreados.Add(dtr("Portal")) 'los permitidos para el ciente
                    Dim p As BarButtonItem = ribbonControl.Items.CreateButton(dtr("Portal"))
                    p.LargeGlyph = My.Resources.ResourceManager.GetObject(dtr("Portal"))
                    p.Name = "I" & dtr("Portal")
                    p.Tag = dtr("Portal")
                    p.Id = ribbonControl.Manager.GetNewItemId() 'Ensures correct runtime layout (de)serialization.
                    AddHandler p.ItemClick, AddressOf IBotones_ItemClick
                    grPortales.ItemLinks.Add(p, True)
                End If


            End While
        End If

        dtr.close()
        bdlo.CerrarBD()

        comprobarPortales()


        If DatosEmpresa.Codigo = 2 Then
            IActualizarWeb.Visibility = BarItemVisibility.Always
        End If



    End Sub


    Private Sub ShowListado(ByVal r As XtraReport, ByVal GL_Word As Boolean, ByVal DT As DataTable)
        r.DataSource = DT
        r.DataMember = "Datos"
        FuncionesGenerales.Funciones.ComprobarYCrearCarpetas("TMP", True)
        Dim Fichero As String = My.Application.Info.DirectoryPath & "/TMP/Word" & Format(Now, "ddmmyyyyhhmmss")
        Try
            File.Delete(Fichero & ".doc")
        Catch ex As Exception
        End Try
        Try
            File.Delete(Fichero & ".html")
        Catch ex As Exception
        End Try



        If GL_Word Then
            Using docServer As New RichEditDocumentServer()
                r.ExportToHtml(Fichero & ".html", New HtmlExportOptions() With {.ExportMode = HtmlExportMode.SingleFile, .EmbedImagesInHTML = True})
                docServer.LoadDocument(Fichero & ".html", DocumentFormat.Html)
                docServer.SaveDocument(Fichero & ".doc", DocumentFormat.Doc)
            End Using
            'Try
            '    File.Delete(Fichero & ".html")
            'Catch ex As Exception
            'End Try

            'r.ExportToRtf(Fichero & ".doc")
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            Process.Start(Fichero & ".doc")
        Else
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            r.ShowPreview()
        End If
    End Sub

    Private Sub iExit_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles iExit.ItemClick
        iSalir()


    End Sub
    Private Sub iSalir()
        Try
            'hilo2.Abort()
            'hilo1.Abort()


            hilo2 = Nothing
            hilo1 = Nothing

            ucEmailMasivoClientes.Dispose()
        Catch ex As Exception

        End Try

        For Each frm In Me.MdiChildren
            frm.Dispose()
        Next



        Try
            Application.Exit()
        Catch ex As Exception

        End Try
    End Sub




    Private Sub rgbiSkins_GalleryItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs) Handles rgbiSkins.GalleryItemClick

        If e.Item.Caption = "MetroBlack" Then
            MensajeInformacion("Skin no soportado")
        End If

        Dim bdItem As New BaseDatos(1)
        bdItem.Execute("UPDATE Usuarios SET DisenoPerfil = '" & e.Item.Caption & "'")
    End Sub
    'Private Sub rgbiOrganismos_GalleryItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs) Handles rgbOrganismos.GalleryItemClick
    '    AbrirProyectos(e.Item.Caption)
    'End Sub

    'Private Sub AbrirProyectos(ByVal OrganismoSelecccionado)
    '    Dim bdOrganismo As New BaseDatos
    '    If GL_CONSULTORA_u_ORGANISMO = GL_TIPO_CONSULTORA Then
    '        GL_ORGANISMO = OrganismoSelecccionado
    '        GL_CODIGO_TRAMITADOR = bdOrganismo.Execute("SELECT CodigoConsultora FROM OrganismosConsultoras WHERE AbreviaturaOrganismo = '" & GL_ORGANISMO & "'", False)
    '        GL_NOMBRE_ORGANISMO = bdOrganismo.Execute("SELECT NombreOrganismo FROM Organismos  WHERE AbreviaturaOrganismo = '" & GL_ORGANISMO & "'", False)
    '    End If

    '    If frmProyectosListado.IsHandleCreated Then
    '        frmProyectosListado.Dispose()
    '    End If

    '    frmProyectosListado.MdiParent = Me
    '    siStatus.Caption = "Proyectos"
    '    frmProyectosListado.Show()
    'End Sub

    Private ReadOnly Property ActiveMDIForm() As Form
        Get
            Return Me.ActiveMdiChild
        End Get
    End Property

    Private Sub siInfo_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles siInfo.ItemClick
        Process.Start("http://www.tresbits.es")
    End Sub


    Private Sub IMantenimientos_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles IFormasPago.ItemClick, IAgrupaciones.ItemClick, IAlmacenes.ItemClick, IFabricantes.ItemClick, IFamilias.ItemClick, IFormasPago.ItemClick, IGamas.ItemClick, IMarcas.ItemClick, ISeriesFacturacion.ItemClick, ISubFamilias.ItemClick, ITarifas.ItemClick, ITipoIVA.ItemClick, INacionalidades.ItemClick, IColores.ItemClick

        '  For Each frm As DevExpress.XtraEditors.XtraForm In Me.MdiChildren

        For Each frm In Me.MdiChildren

            If frm.Name = e.Item.Tag Then
                frm.Activate()
                Exit Sub
            End If
        Next

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor



        Dim p As New XtraForm1(e.Item.Tag)
        p.Name = e.Item.Tag
        p.ControlBox = False

        Dim u As New ucMantenimientos(e.Item.Tag)
        u.Dock = DockStyle.Fill
        p.Controls.Add(u)
        p.MdiParent = Me
        p.Show()


        Me.Cursor = System.Windows.Forms.Cursors.Arrow


    End Sub

    Public Sub CrearInmuebles()
        Try
            Application.OpenForms.Item("Inmuebles").Dispose()

        Catch ex As Exception

        End Try

        'If uInmueblesActivo IsNot Nothing Then
        '    uInmueblesActivo = Nothing
        '    '   uInmueblesActivo.Dispose()
        'End If

        'For Each frm In frmPrincipal.MdiChildren

        '    If frm.Name = "Inmuebles" Then
        '        frm.Dispose()
        '        Exit Sub
        '    End If
        'Next

        'Me.Cursor = System.Windows.Forms.Cursors.WaitCursor


        Dim p As New XtraForm1("Inmuebles")
        p.Name = "Inmuebles"
        p.ControlBox = False

        '  Dim u As Object


        uInmueblesActivo = New ucInmuebles
        uInmueblesActivo.Dock = DockStyle.Fill
        p.Controls.Add(uInmueblesActivo)






        'u.Dock = DockStyle.Fill
        'p.Controls.Add(u)




        p.MdiParent = Me
        p.Show()


        Me.Cursor = System.Windows.Forms.Cursors.Arrow

    End Sub


    Private Sub IEstilos_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles IEstilos.ItemClick
        PopupControlContainer3.Width = 700
        PopupControlContainer3.Height = 370



        'Me.Width = Screen.PrimaryScreen.WorkingArea.Width -  155
        'Me.Height = Screen.PrimaryScreen.WorkingArea.Height - 30

        Dim pt As Point

        'pt.X = (Me.Width - popupControlContainer3.Width) / 2
        'pt.Y = (Me.Height - popupControlContainer3.Height) / 2

        pt.X = (Screen.PrimaryScreen.WorkingArea.Width - PopupControlContainer3.Width) / 2
        pt.Y = (Screen.PrimaryScreen.WorkingArea.Height - PopupControlContainer3.Height) / 2
        '        pt = Cursor.Position
        PopupControlContainer3.ShowPopup(BarManager1, pt)
    End Sub

    Private Sub LlenarGallerySkins()

        DevExpress.Skins.SkinCollectionHelper.SkinIconsSmall.Images.Clear()
        DevExpress.Skins.SkinCollectionHelper.SkinIconsLarge.ImageSize = New Size(64, 64)
        DevExpress.Skins.SkinCollectionHelper.SkinIconsSmall.ImageSize = New Size(128, 128)
        DevExpress.Skins.SkinCollectionHelper.SkinIconsSmall.Images.AddRange(DevExpress.Skins.SkinCollectionHelper.SkinIconsLarge.Images)

        DevExpress.Skins.SkinCollectionHelper.SkinIconsLarge.Images.Clear()
        DevExpress.Skins.SkinCollectionHelper.SkinIconsLarge.Images.AddRange(DevExpress.Skins.SkinCollectionHelper.SkinIconsSmall.Images)

        'Me.GalleryControl1.Gallery.ImageSize = New Size(64, 64)

        SkinHelper.InitSkinGallery(GalleryControl1, True, True, True)

        Me.PopupControlContainer3.Controls.Add(Me.GalleryControl1)

    End Sub

    Private Sub GalleryControl1_Gallery_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs) Handles GalleryControl1.CausesValidationChanged

        PopupControlContainer3.HidePopup()
    End Sub



    Private Sub GalleryControlGallery1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs) Handles GalleryControl1.Gallery.ItemClick

        'If e.Item.Caption = "MetroBlack" Then
        '    MensajeInformacion("Skin no soportado")
        'End If

        Dim bdItem As New BaseDatos(1)
        bdItem.Execute("UPDATE Usuarios SET DisenoPerfil = '" & e.Item.Caption & "' WHERE Usuario = '" & GL_Usuario & "'")
    End Sub

    'Private Sub ribbonControl_ApplicationButtonClick(sender As System.Object, e As System.EventArgs) Handles ribbonControl.ApplicationButtonClick
    '    Dim proceso As New System.Diagnostics.Process
    '    With proceso
    '        .StartInfo.FileName = "http://www.tresbits.es"
    '        .Start()
    '    End With
    'End Sub


    Private Sub IEstadisticas_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles IEstadisticas.ItemClick
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim p As New frmFechas
        p.ShowDialog()
        If GL_FechaInicio = "" OrElse GL_FechaFin = "" Then
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            Exit Sub
        End If

        GL_FechaFin = CDate(GL_FechaFin).AddDays(1).ToString("dd/MM/yyyy")

        Dim WhereEmp As String = ""

        If GL_EmpleadosSeleccionados <> "" Then
            WhereEmp = " WHERE Contador IN " & GL_EmpleadosSeleccionados
        End If

        Dim Sel As String = "select E.nombre" &
                   ",(select count(*) from (select distinct ContadorCliente,ContadorEmpleado from Visitas where Fecha >= " & Funciones.pf_ReplaceFecha(CDate(GL_FechaInicio)) & " AND Fecha < " & Funciones.pf_ReplaceFecha(CDate(GL_FechaFin)) & ") a WHERE a.ContadorEmpleado=e.contador) as Clientes" &
                   ",(select count(*) from (select distinct ContadorInmueble,ContadorEmpleado from Visitas where Fecha >= " & Funciones.pf_ReplaceFecha(CDate(GL_FechaInicio)) & " AND Fecha < " & Funciones.pf_ReplaceFecha(CDate(GL_FechaFin)) & ") a WHERE a.ContadorEmpleado=e.contador) as Inmuebles" &
                   ",(select count(*) from ClientesComunicaciones where ContadorEmpleado=e.contador AND Tipo = '" & GL_LLAMADA & "'  AND Fecha >= " & Funciones.pf_ReplaceFecha(CDate(GL_FechaInicio)) & " AND Fecha < " & Funciones.pf_ReplaceFecha(CDate(GL_FechaFin)) & ") as llamadasclientes" &
                   ",(select count(*) from ClientesComunicaciones where ContadorEmpleado=e.contador  AND Tipo = '" & GL_LLAMADA_NO_CONTESTA & "' and LlamadaContestada =0 AND Fecha >= " & Funciones.pf_ReplaceFecha(CDate(GL_FechaInicio)) & " AND Fecha < " & Funciones.pf_ReplaceFecha(CDate(GL_FechaFin)) & ") as llamadasclientesNoContesta" &
                   ",(select count(*) from PropietariosComunicaciones where ContadorEmpleado=e.contador  AND Tipo = '" & GL_LLAMADA & "'  AND Fecha >= " & Funciones.pf_ReplaceFecha(CDate(GL_FechaInicio)) & " AND Fecha < " & Funciones.pf_ReplaceFecha(CDate(GL_FechaFin)) & ") as llamadaspropietarios" &
                   ",(select count(*) from PropietariosComunicaciones where ContadorEmpleado=e.contador  AND Tipo = '" & GL_LLAMADA_NO_CONTESTA & "'  AND LlamadaContestada =0 AND Fecha >= " & Funciones.pf_ReplaceFecha(CDate(GL_FechaInicio)) & " AND Fecha < " & Funciones.pf_ReplaceFecha(CDate(GL_FechaFin)) & ") as llamadaspropietariosNoContesta" &
                   ",(select count(*) from Clientes where ContadorEmpleado=e.contador  AND FechaAlta >= " & Funciones.pf_ReplaceFecha(CDate(GL_FechaInicio)) & " AND FechaAlta < " & Funciones.pf_ReplaceFecha(CDate(GL_FechaFin)) & ")as clientesaltas" &
                  ",(select count(*) from Impresiones where Documento='FICHA INMUEBLE' AND ContadorEmpleado=e.contador  AND Fecha >= " & Funciones.pf_ReplaceFecha(CDate(GL_FechaInicio)) & " AND Fecha < " & Funciones.pf_ReplaceFecha(CDate(GL_FechaFin)) & ")as ImpresionesFichaInmueble" &
                   " from empleados E " & WhereEmp & " ORDER BY Nombre"

        Dim bdstats As New BaseDatos
        bdstats.LlenarDataSet(Sel, "Datos")
        Dim DT As DataTable = bdstats.ds.Tables("Datos")
        'System.IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\Listados\Esquemas\")
        'DT.WriteXmlSchema(My.Application.Info.DirectoryPath & "\Listados\Esquemas\Datos.xsd")
        'DT.WriteXml(My.Application.Info.DirectoryPath & "\Listados\Esquemas\Datos.xml", XmlWriteMode.WriteSchema)
        Dim r As New rptEstadisticasEmpleados
        r.DataSource = DT
        r.DataMember = "Datos"
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        r.ShowPreview()
    End Sub
    Private Sub IEstadisticasGlobales_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles IEstadisticasGlobales.ItemClick
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim p As New frmFechas
        p.dgvx.Visible = False
        p.ShowDialog()
        If GL_FechaInicio = "" OrElse GL_FechaFin = "" Then
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            Exit Sub
        End If

        GL_FechaFin = CDate(GL_FechaFin).AddDays(1).ToString("dd/MM/yyyy")

        Dim WhereEmp As String = ""

        If GL_EmpleadosSeleccionados <> "" Then
            WhereEmp = " WHERE Contador IN " & GL_EmpleadosSeleccionados
        End If


        Dim Sel As String = "select E.nombre" &
                         ",(select count(*) from (select distinct ContadorCliente from Visitas where Fecha >= " & pf_ReplaceFecha(CDate(GL_FechaInicio)) & " AND Fecha < " & pf_ReplaceFecha(CDate(GL_FechaFin)) & ") q1) as Clientes" &
                         ",(select count(*) from (select distinct ContadorInmueble from Visitas where Fecha >= " & pf_ReplaceFecha(CDate(GL_FechaInicio)) & " AND Fecha < " & pf_ReplaceFecha(CDate(GL_FechaFin)) & ")q) as Inmuebles" &
                         ",(select count(*) from ClientesComunicaciones where Fecha >= " & pf_ReplaceFecha(CDate(GL_FechaInicio)) & "  AND Tipo = '" & GL_LLAMADA & "' AND Fecha < " & pf_ReplaceFecha(CDate(GL_FechaFin)) & ") as llamadasclientes" &
                         ",(select count(*) from ClientesComunicaciones where LlamadaContestada =0  AND Tipo = '" & GL_LLAMADA_NO_CONTESTA & "' AND Fecha >= " & pf_ReplaceFecha(CDate(GL_FechaInicio)) & " AND Fecha < " & pf_ReplaceFecha(CDate(GL_FechaFin)) & ") as llamadasclientesNoContesta" &
                         ",(select count(*) from PropietariosComunicaciones where  Tipo = '" & GL_LLAMADA & "' AND Fecha >= " & pf_ReplaceFecha(CDate(GL_FechaInicio)) & " AND Fecha < " & pf_ReplaceFecha(CDate(GL_FechaFin)) & ") as llamadaspropietarios" &
                         ",(select count(*) from PropietariosComunicaciones where LlamadaContestada =0  AND Tipo = '" & GL_LLAMADA_NO_CONTESTA & "' AND Fecha >= " & pf_ReplaceFecha(CDate(GL_FechaInicio)) & " AND Fecha < " & pf_ReplaceFecha(CDate(GL_FechaFin)) & ") as llamadaspropietariosNoContesta" &
                         ",(select count(*) from Clientes where FechaAlta >= " & pf_ReplaceFecha(CDate(GL_FechaInicio)) & " AND FechaAlta < " & pf_ReplaceFecha(CDate(GL_FechaFin)) & ")as clientesaltas" &
                        ",(select count(*) from Impresiones where Documento='FICHA INMUEBLE' AND Fecha >= " & pf_ReplaceFecha(CDate(GL_FechaInicio)) & " AND Fecha < " & pf_ReplaceFecha(CDate(GL_FechaFin)) & ")as ImpresionesFichaInmueble" &
                         " from empleados E " & WhereEmp

        Dim bdstats As New BaseDatos
        bdstats.LlenarDataSet(Sel, "Datos")
        Dim DT As DataTable = bdstats.ds.Tables("Datos")
        'System.IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\Listados\Esquemas\")
        'DT.WriteXmlSchema(My.Application.Info.DirectoryPath & "\Listados\Esquemas\Datos.xsd")
        'DT.WriteXml(My.Application.Info.DirectoryPath & "\Listados\Esquemas\Datos.xml", XmlWriteMode.WriteSchema)
        Dim r As New rptEstadisticasEmpleadosGlobal
        r.DataSource = DT
        r.DataMember = "Datos"
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        r.ShowPreview()
    End Sub
    Private Sub IListadoLlamadas_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles IListadoLlamadas.ItemClick
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim p As New frmFechas
        p.ShowDialog()
        If GL_FechaInicio = "" OrElse GL_FechaFin = "" Then
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            Exit Sub
        End If

        GL_FechaFin = CDate(GL_FechaFin).AddDays(1).ToString("dd/MM/yyyy")

        Dim WhereEmp As String = ""

        If GL_EmpleadosSeleccionados <> "" Then
            WhereEmp = " AND ContadorEmpleado IN " & GL_EmpleadosSeleccionados
        End If

        Dim Sel As String = "select Fecha,(Select Nombre From Clientes c Where c.Contador=cc.ContadorCliente)as Cliente,(Select Baja From Clientes c Where c.Contador=cc.ContadorCliente) as   Baja," &
        "(Select Referencia From Inmuebles i Where i.Contador=cc.ContadorInmueble )as Referencia," &
         "(Select Direccion" & GL_SQL_SUMA & "' '" & GL_SQL_SUMA & "Numero" & GL_SQL_SUMA & "', Alt. '" & GL_SQL_SUMA & SQL_CONVERT("varchar(10)", "Altura") & " From Inmuebles i Where i.Contador=cc.ContadorInmueble  )as Direccion," &
         "(Select Nombre From Empleados e Where e.Contador=cc.ContadorEmpleado)as Comercial," &
        " LlamadaContestada " &
         "  from ClientesComunicaciones cc Where CodigoEmpresa=" & DatosEmpresa.Codigo & " and (Tipo = '" & GL_LLAMADA & "' OR Tipo = '" & GL_LLAMADA_DETALLE & "') and Delegacion=" & Gl_Delegacion & " and Fecha >= " & pf_ReplaceFecha(CDate(GL_FechaInicio)) & " AND Fecha < " & pf_ReplaceFecha(CDate(GL_FechaFin)) & WhereEmp &
        "order by Fecha"
        Dim bdstats As New BaseDatos
        bdstats.LlenarDataSet(Sel, "Datos")
        Dim DT As DataTable = bdstats.ds.Tables("Datos")
        'System.IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\Listados\Esquemas\")
        'DT.WriteXmlSchema(My.Application.Info.DirectoryPath & "\Listados\Esquemas\Datos.xsd")
        'DT.WriteXml(My.Application.Info.DirectoryPath & "\Listados\Esquemas\Datos.xml", XmlWriteMode.WriteSchema)
        Dim r As New rptListadoLlamadas
        r.DataSource = DT
        r.DataMember = "Datos"
        r.Titulo.Text = "Llamadas realizadas desde " & GL_FechaInicio & " hasta " & GL_FechaFin
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        r.ShowPreview()
    End Sub
    Private Sub IBotones_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles IAlarmas.ItemClick, IClientes.ItemClick, IEmpleados.ItemClick, IConfiguracionEmpresas.ItemClick, ITextosEnvios.ItemClick, IPropietarios.ItemClick, IAgrupacion.ItemClick, IComoConociste.ItemClick, IOrientacion.ItemClick, IPoblacion.ItemClick, IProvincias.ItemClick, Itipo.ItemClick, IZona.ItemClick, IEstado.ItemClick, IEmail.ItemClick, IMensajesAPP.ItemClick, IUsuariosAPP.ItemClick, IEnvioNovedades.ItemClick, IConfiguracion.ItemClick, IInmuebles.ItemClick, IElegirTipo.ItemClick, IElegirTipoVenta.ItemClick, IPrestamos.ItemClick, IClientesM.ItemClick, IInmueblesM.ItemClick, IPropietariosM.ItemClick, IAlarmasM.ItemClick

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        CargarFormulario(e.Item.Tag, Ribbon.SelectedPage.Name)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow

    End Sub
    Private Sub IPrestamosM_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles IPrestamosM.ItemClick

        Dim u As New frmPrestamos
        u.ShowDialog()



    End Sub

    Private Sub IConfiguracionPortales_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles IConfiguracionPortales.ItemClick

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        CargarFormulario(e.Item.Tag, Ribbon.SelectedPage.Name)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow

        comprobarPortales()

    End Sub
    Private Sub comprobarPortales()
        'verificar los portales activos
        Dim hayPortales As Boolean = False
        Dim dtr As Object
        Dim bdPortales As New BaseDatos
        dtr = bdPortales.ExecuteReader("SELECT * FROM ClientePortales WHERE Activo " & GL_SQL_DIS & " 0 AND CodigoEmpresa=" & DatosEmpresa.Codigo)
        For Each p In GL_PortalesCreados 'quitamos todos
            ribbonControl.Items("I" & p).Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Next
        'IYaEncontre.Visibility = BarItemVisibility.Never
        'IFotoCasa.Visibility = BarItemVisibility.Never
        'IIdealista.Visibility = BarItemVisibility.Never
        'IHogaria.Visibility = BarItemVisibility.Never
        If dtr.hasrows Then
            While dtr.read
                If GL_PortalesCreados.Contains(dtr("Portal")) Then 'añadimos de los disponibles para el cliente los que tiene creados
                    ribbonControl.Items("I" & dtr("Portal")).Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                    hayPortales = True
                End If
                'Select Case dtr("Portal")
                '    Case "YaEncontre"
                '        IYaEncontre.Visibility = BarItemVisibility.Always
                '        hayPortales = True
                '    Case "FotoCasa"
                '        IFotoCasa.Visibility = BarItemVisibility.Always
                '        hayPortales = True
                '    Case "Idealista"
                '        IIdealista.Visibility = BarItemVisibility.Always
                '        hayPortales = True
                '    Case "Hogaria"
                '        IHogaria.Visibility = BarItemVisibility.Always
                '        hayPortales = True
                'End Select
            End While
        End If
        bdPortales.CerrarBD()
        dtr.close()
        If hayPortales Then
            IElegirTipo.Visibility = BarItemVisibility.Always
            IElegirTipoVenta.Visibility = BarItemVisibility.Always
            picPortales.Enabled = True
            picPortales.Image = My.Resources._04
        Else
            IElegirTipo.Visibility = BarItemVisibility.Never
            IElegirTipoVenta.Visibility = BarItemVisibility.Never
            picPortales.Enabled = False
            picPortales.Image = My.Resources.i04
        End If


    End Sub

    Private Sub ribbonControl_SelectedPageChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ribbonControl.SelectedPageChanged

        If PrimeraVez Then
            PrimeraVez = False
            Exit Sub
        End If

        Try
            Dim f As New Font(Me.ribbonControl.SelectedPage.Appearance.Font.FontFamily, 9)

            For i = 0 To Me.ribbonControl.Pages.Count - 1
                If Me.ribbonControl.Pages(i).Appearance.Font.Size <> f.Size Then
                    Me.ribbonControl.Pages(i).Appearance.Font = f
                End If
            Next

            f = New Font(Me.ribbonControl.SelectedPage.Appearance.Font.FontFamily, 16)

            Me.ribbonControl.SelectedPage.Appearance.Font = f
        Catch ex As Exception

        End Try



    End Sub


    Private Sub BarButtonItem12_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnJuntarInmuebles.ItemClick

        Dim Sel As String = ""
        Dim Tabla As String

        'Dim TablaBaja As String = ""

        For i = 0 To 1

            'If i =1 THEN
            '    TablaBaja = "Baja"
            'End If

            Tabla = "Inmuebles" '& TablaBaja


            Sel = "select  count(*),ContadorPropietario, Tipo, Via, Direccion, Altura, CodPostal, Poblacion, Provincia, Numero, Puerta FROM " & Tabla &
               " where Baja = " & i & " AND direccion <> '' and numero <> '' and puerta <> '' " &
               " group by ContadorPropietario,Tipo, Via, Direccion, Altura, CodPostal, Poblacion, Provincia,Numero, Puerta" &
               " having count(*) = 2  order by count(*) desc "

            Dim dtr1 As Object
            Dim bd1 As New BaseDatos

            dtr1 = bd1.ExecuteReader(Sel)
            If dtr1.HasRows Then
                While dtr1.Read
                    Dim dtr2 As Object
                    Dim bd2 As New BaseDatos

                    Sel = "SELECT *  FROM " & Tabla &
                        " WHERE Baja = " & i & " AND ContadorPropietario = " & dtr1("ContadorPropietario") &
                        " AND Tipo = '" & FuncionesGenerales.Funciones.pf_ReplaceComillas(dtr1("Tipo")) & "'" &
                        " AND Via = '" & FuncionesGenerales.Funciones.pf_ReplaceComillas(dtr1("Via")) & "'" &
                        " AND Direccion = '" & FuncionesGenerales.Funciones.pf_ReplaceComillas(dtr1("Direccion")) & "'" &
                        " AND Altura = '" & FuncionesGenerales.Funciones.pf_ReplaceComillas(dtr1("Altura")) & "'" &
                        " AND CodPostal = '" & FuncionesGenerales.Funciones.pf_ReplaceComillas(dtr1("CodPostal")) & "'" &
                        " AND Poblacion = '" & FuncionesGenerales.Funciones.pf_ReplaceComillas(dtr1("Poblacion")) & "'" &
                        " AND Provincia = '" & FuncionesGenerales.Funciones.pf_ReplaceComillas(dtr1("Provincia")) & "'" &
                        " AND Numero = '" & FuncionesGenerales.Funciones.pf_ReplaceComillas(dtr1("Numero")) & "'" &
                        " AND Puerta = '" & FuncionesGenerales.Funciones.pf_ReplaceComillas(dtr1("Puerta")) & "' ORDER BY Contador"
                    dtr2 = bd2.ExecuteReader(Sel)

                    If dtr2.HasRows Then
                        Dim SoyPrimero As Boolean = True
                        Dim ContadorBueno As Integer = 0
                        Dim ReferenciaBueno As String = ""

                        Dim ContadorSegundo As Integer = 0
                        Dim ReferenciaSegundo As String = ""

                        While dtr2.Read

                            If SoyPrimero Then
                                SoyPrimero = False
                                ContadorBueno = dtr2("Contador")
                                ReferenciaBueno = dtr2("Referencia")
                            Else
                                ContadorSegundo = dtr2("Contador")
                                ReferenciaSegundo = dtr2("Referencia")

                                Dim TextoAmueblado As String = ""

                                'If Tipo = "Verano" Then
                                '    TextoAmueblado = ""
                                'Else
                                TextoAmueblado = " , SemiAmueblado = " & FuncionesGenerales.Funciones.pf_ReplaceTrueFalse(dtr2("SemiAmueblado")) &
                                  " , Amueblado = " & FuncionesGenerales.Funciones.pf_ReplaceTrueFalse(dtr2("Amueblado"))
                                'End If


                                Dim TextoFecha As String = ""

                                If IsDBNull(dtr2("FechaReservado")) Then
                                    TextoFecha = " NULL "
                                Else
                                    TextoFecha = " '" & Format(dtr2("FechaReservado"), "yyyyMMdd") & "' "
                                End If


                                Sel = "UPDATE " & Tabla & " SET " &
                                      "  Precio = " & FuncionesGenerales.Funciones.ReplacePuntos(dtr2("Precio")) &
                                      " , PrecioPropietario = " & FuncionesGenerales.Funciones.ReplacePuntos(dtr2("PrecioPropietario")) &
                                      " , Gastos = " & FuncionesGenerales.Funciones.ReplacePuntos(dtr2("PrecioPropietario")) &
                                      " , Trastero = " & FuncionesGenerales.Funciones.pf_ReplaceTrueFalse(dtr2("Trastero")) &
                                      " , PrecioTrastero = " & FuncionesGenerales.Funciones.ReplacePuntos(dtr2("PrecioTrastero")) &
                                      " , Garaje = " & FuncionesGenerales.Funciones.pf_ReplaceTrueFalse(dtr2("Garaje")) &
                                      " , PrecioGaraje = " & FuncionesGenerales.Funciones.ReplacePuntos(dtr2("PrecioGaraje")) &
                                      TextoAmueblado &
                                      " , Reservado = " & FuncionesGenerales.Funciones.pf_ReplaceTrueFalse(dtr2("Reservado")) &
                                      " , FechaReservado = " & TextoFecha &
                                      ", ReferenciasUnidas = '" & ReferenciaBueno & "'" & GL_SQL_SUMA & " '-'" & GL_SQL_SUMA & " '" & ReferenciaSegundo & "'" &
                                      " , Cartel = " & IIf(dtr2("Cartel"), GL_SQL_VALOR_1, " Cartel") &
                                      " , FechaCambioPrecio = " & GL_SQL_GETDATE & " " &
                                      " WHERE Contador = " & ContadorBueno



                                BD_CERO.Execute(Sel)



                                Dim Tabla2 As String



                                'Tabla2 = "cambiosprecio"
                                'Sel = "UPDATE " & Tabla2 & " SET precio" & Tipo & " = " & dtr2("precio" & Tipo) & " WHERE ContadorInmueble = " & ContadorBueno
                                'BD_CERO.Execute(Sel)


                                'Tabla2 = "cambiosprecio"
                                'Sel = "" & GL_SQL_DELETE & "FROM " & Tabla2 & " WHERE ContadorInmueble = " & ContadorSegundo
                                'BD_CERO.Execute(Sel)

                                Sel = "UPDATE ClientesComunicacionesEmailDetalle SET ContadorInmueble = " & ContadorBueno & " WHERE ContadorInmueble = " & ContadorSegundo
                                BD_CERO.Execute("UPDATE Clientes SET FechaEmailDetalle =  I.Fecha, ReferenciaEmailDetalle = " & Funciones.SQL_CASE_ISNULL("(SELECT Referencia FROM Inmuebles INMM WHERE INMM.Contador = I.ContadorInmueble),''") & "" &
                                               " FROM Clientes InM inner join ClientesComunicacionesEmailDetalle I on InM.Contador  = i.ContadorCliente WHERE I.ContadorInmueble=" & ContadorBueno)
                                BD_CERO.Execute(Sel)



                                Sel = "UPDATE ClientesComunicacionesEmailFijo SET ContadorInmueble = " & ContadorBueno & " WHERE ContadorInmueble = " & ContadorSegundo
                                BD_CERO.Execute("UPDATE Clientes SET FechaEmailDetalle =  I.Fecha" &
                                              " FROM Clientes InM inner join ClientesComunicacionesEmailDetalle I on InM.Contador  = i.ContadorCliente WHERE I.ContadorInmueble=" & ContadorBueno)
                                BD_CERO.Execute(Sel)

                                Sel = "UPDATE ClientesComunicacionesEmailListadoClientes SET ContadorInmueble = " & ContadorBueno & " WHERE ContadorInmueble = " & ContadorSegundo
                                BD_CERO.Execute("UPDATE Clientes SET FechaEmailListado =  I.Fecha" &
                                              " FROM Clientes InM inner join ClientesComunicacionesEmailListadoClientes I on InM.Contador  = i.ContadorCliente WHERE I.ContadorInmueble=" & ContadorBueno)
                                BD_CERO.Execute(Sel)


                                Tabla2 = "ClientesComunicacionesLLamada"
                                Sel = "UPDATE " & Tabla2 & " SET ContadorInmueble = " & ContadorBueno & " WHERE ContadorInmueble = " & ContadorSegundo
                                BD_CERO.Execute(Sel)



                                Sel = "UPDATE ClientesComunicacionesSMS SET ContadorInmueble = " & ContadorBueno & " WHERE ContadorInmueble = " & ContadorSegundo
                                BD_CERO.Execute("UPDATE Clientes SET FechaSMS =  I.Fecha, ReferenciaSMS = " & Funciones.SQL_CASE_ISNULL("(SELECT Referencia FROM Inmuebles INMM WHERE INMM.Contador = I.ContadorInmueble),''") & "" &
                                              " FROM Clientes InM inner join ClientesComunicacionesSMS I on InM.Contador  = i.ContadorCliente WHERE I.ContadorInmueble=" & ContadorBueno)
                                BD_CERO.Execute(Sel)



                                Sel = "UPDATE ClientesComunicacionesVisitaOficina SET ContadorInmueble = " & ContadorBueno & " WHERE ContadorInmueble = " & ContadorSegundo
                                BD_CERO.Execute("UPDATE Clientes SET FechaVisitaOficina =  I.Fecha, ReferenciaVisitaOficina = " & Funciones.SQL_CASE_ISNULL("(SELECT Referencia FROM Inmuebles INMM WHERE INMM.Contador = I.ContadorInmueble),''") & "" &
                                             " FROM Clientes InM inner join ClientesComunicacionesVisitaOficina I on InM.Contador  = i.ContadorCliente WHERE I.ContadorInmueble=" & ContadorBueno)
                                BD_CERO.Execute(Sel)



                                'Tabla2 = "Reservas"
                                'Sel = "UPDATE " & Tabla2 & " SET ContadorInmueble = " & ContadorBueno & " WHERE ContadorInmueble = " & ContadorSegundo
                                'BD_CERO.Execute(Sel)


                                'Sel = "" & GL_SQL_DELETE & "FROM " & Tabla & " WHERE Contador = " & ContadorSegundo
                                'BD_CERO.Execute(Sel)



                                If ContadorSegundo = 0 Then
                                    ContadorSegundo = ContadorBueno
                                End If

                                If ReferenciaSegundo = "" Then
                                    ReferenciaSegundo = ReferenciaBueno
                                End If

                                Sel = "INSERT INTO z_Uniones VALUES ('" & Tabla & "'," & ContadorSegundo & ", " & ContadorBueno & ", '" & ReferenciaSegundo & "', '" & ReferenciaBueno & "', '" & dtr1("ContadorPropietario") & "-" & ContadorBueno & "',''," & dtr1("ContadorPropietario") & ")"
                                BD_CERO.Execute(Sel)



                                'End If


                            End If




                        End While

                    End If
                    dtr2.Close()
                    bd2.CerrarBD()
                End While

            End If
            dtr1.Close()
            bd1.CerrarBD()
        Next

        'Sel = ""& GL_SQL_DELETE &"from InmueblesCarteles "
        'BD_CERO.Execute(Sel)

        'Sel = "INSERT INTO InmueblesCarteles (ContadorInmueble,ContadorEmpleado,Fecha,CartelPuesto) SELECT Contador,1," & gl_sql_getdate & ",1 FROM inmuebles WHERE Cartel =" & GL_SQL_VALOR_1 & "  "
        'BD_CERO.Execute(Sel)

        MsgBox("Fin")

    End Sub

    Private Sub btnFotosPC_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnFotosPC.ItemClick
        ArreglarFotosPC(False)

    End Sub
    Private Sub btnFotosPCBaja_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnFotosPCBaja.ItemClick
        ArreglarFotosPC(True)
    End Sub

    'Private Sub ArreglarFotosPC(ByVal Baja As Boolean)
    '    Dim CarpetaDocumento As String
    '    If Baja Then
    '        CarpetaDocumento = GL_CarpetaFotosBaja
    '    Else
    '        CarpetaDocumento = GL_CarpetaFotos
    '    End If


    '    Dim Sel As String
    '    If Baja Then
    '        Sel = "UPDATE Inmuebles SET FotosPC = 0, FotosWeb = 0, fotoprincipal = '' WHERE Baja <> 0"
    '    Else
    '        Sel = "UPDATE Inmuebles SET FotosPC = 0, FotosWeb = 0, fotoprincipal = '' WHERE Baja = 0 "
    '    End If

    '    'If Baja Then
    '    '    Sel = "UPDATE Inmuebles SET FotosPC = 0, FotosWeb = 0  WHERE Baja = 1"
    '    'Else
    '    '    Sel = "UPDATE Inmuebles SET FotosPC = 0, FotosWeb = 0  WHERE Baja = 0"
    '    'End If

    '    BD_CERO.Execute(Sel)

    '    Dim CarpetasABorrar As New List(Of String)

    '    Dim direc() As String
    '    Try
    '        direc = System.IO.Directory.GetDirectories(CarpetaDocumento)
    '    Catch ex As Exception
    '        MensajeError("No existe la carpeta.")
    '        Exit Sub
    '    End Try
    '    Dim aff As Integer

    '    For i = 0 To direc.Count - 1
    '        Dim Ref As String
    '        Dim PosGuion As Integer
    '        PosGuion = InStrRev(direc(i), "\")
    '        Ref = Microsoft.VisualBasic.Right(direc(i), Len(direc(i)) - PosGuion)



    '        Dim DirFiles() As String = System.IO.Directory.GetFiles(direc(i), "*.jpg")

    '        Dim CuantasSubidas As Integer = 0
    '        If System.IO.Directory.Exists(direc(i) & "\actualizaweb") Then
    '            CuantasSubidas = System.IO.Directory.GetFiles(direc(i) & "\actualizaweb", "*.jpg").Length
    '        End If

    '        Dim FotoPrincipal As String = ""

    '        If DirFiles.Count > 0 Then
    '            FotoPrincipal = DirFiles(0)
    '            FotoPrincipal = My.Computer.FileSystem.GetName(FotoPrincipal)
    '            FotoPrincipal = Replace(FotoPrincipal, "'", "")
    '            Try
    '                Sel = "UPDATE Inmuebles SET FotosWeb = " & CuantasSubidas & ", FotosPC = " & DirFiles.Count & ", fotoprincipal='" & FotoPrincipal & "' WHERE Referencia = '" & Ref & "'"
    '                aff = BD_CERO.Execute(Sel)
    '            Catch ex As Exception
    '                Sel = "UPDATE Inmuebles SET FotosWeb = " & CuantasSubidas & ", FotosPC = " & DirFiles.Count & " WHERE Referencia = '" & Ref & "'"
    '                aff = BD_CERO.Execute(Sel)
    '            End Try
    '            '  


    '            'If aff < 1 Then
    '            '    CarpetasABorrar.Add(direc(i))
    '            'End If

    '        End If



    '    Next

    '    'For i = 0 To CarpetasABorrar.Count - 1
    '    '    System.IO.Directory.Delete(CarpetasABorrar(i), True)
    '    'Next

    '    MsgBox("Fin")
    'End Sub
    Private Sub ArreglarFotosPC(ByVal Baja As Boolean)
        Dim CarpetaDocumento As String
        If Baja Then
            CarpetaDocumento = GL_CarpetaFotosBaja
        Else
            CarpetaDocumento = GL_CarpetaFotos & "\FotosPerdidas"
        End If


        Dim Sel As String
        If Baja Then
            Sel = "UPDATE Inmuebles SET FotosPC = 0, FotosWeb = 0, fotoprincipal = '' WHERE Baja <> 0"
        Else
            Sel = "UPDATE Inmuebles SET FotosPC = 0, FotosWeb = 0, fotoprincipal = '' WHERE Baja = 0 AND Referencia > '25355'"
        End If

        'If Baja Then
        '    Sel = "UPDATE Inmuebles SET FotosPC = 0, FotosWeb = 0  WHERE Baja = 1"
        'Else
        '    Sel = "UPDATE Inmuebles SET FotosPC = 0, FotosWeb = 0  WHERE Baja = 0"
        'End If

        BD_CERO.Execute(Sel)

        Dim CarpetasABorrar As New List(Of String)

        Dim direc() As String
        Try
            direc = System.IO.Directory.GetDirectories(CarpetaDocumento)
        Catch ex As Exception
            MensajeError("No existe la carpeta.")
            Exit Sub
        End Try
        Dim aff As Integer

        For i = 0 To direc.Count - 1
            Dim Ref As String
            Dim PosGuion As Integer
            PosGuion = InStrRev(direc(i), "\")
            Ref = Microsoft.VisualBasic.Right(direc(i), Len(direc(i)) - PosGuion)



            Dim DirFiles() As String = System.IO.Directory.GetFiles(direc(i), "*.jpg")

            Dim CuantasSubidas As Integer = 0
            If System.IO.Directory.Exists(direc(i) & "\actualizarweb") Then
                CuantasSubidas = System.IO.Directory.GetFiles(direc(i) & "\actualizarweb", "*.jpg").Length
            End If

            Dim FotoPrincipal As String = ""

            If DirFiles.Count > 0 Then
                FotoPrincipal = DirFiles(0)
                FotoPrincipal = My.Computer.FileSystem.GetName(FotoPrincipal)
                FotoPrincipal = Replace(FotoPrincipal, "'", "")
                Try
                    Sel = "UPDATE Inmuebles SET FotosWeb = " & CuantasSubidas & ", FotosPC = " & DirFiles.Count & ", fotoprincipal='" & FotoPrincipal & "' WHERE Referencia = '" & Ref & "'"
                    aff = BD_CERO.Execute(Sel)
                Catch ex As Exception
                    Sel = "UPDATE Inmuebles SET FotosWeb = " & CuantasSubidas & ", FotosPC = " & DirFiles.Count & " WHERE Referencia = '" & Ref & "'"
                    aff = BD_CERO.Execute(Sel)
                End Try
                '  


                'If aff < 1 Then
                '    CarpetasABorrar.Add(direc(i))
                'End If

            End If



        Next

        'For i = 0 To CarpetasABorrar.Count - 1
        '    System.IO.Directory.Delete(CarpetasABorrar(i), True)
        'Next

        MsgBox("Fin")
    End Sub
    'Private Sub ArreglarFotosPC(ByVal Baja As Boolean)
    '    Dim CarpetaDocumento As String
    '    If Baja Then
    '        CarpetaDocumento = GL_CarpetaFotosBaja
    '    Else
    '        CarpetaDocumento = GL_CarpetaFotos
    '    End If


    '    Dim Sel As String
    '    Sel = "UPDATE Inmuebles SET FotosPC = 0 WHERE Baja=" & IIf(Baja, GL_SQL_VALOR_1, 0)
    '    BD_CERO.Execute(Sel)

    '    Dim CarpetasABorrar As New List(Of String)

    '    Dim direc() As String
    '    Try
    '        direc = System.IO.Directory.GetDirectories(CarpetaDocumento)
    '    Catch ex As Exception
    '        MensajeError("No existe la carpeta.")
    '        Exit Sub
    '    End Try


    '    For i = 0 To direc.Count - 1
    '        Dim Ref As String
    '        Dim PosGuion As Integer
    '        PosGuion = InStr(direc(i), "-")
    '        Ref = Microsoft.VisualBasic.Right(direc(i), Len(direc(i)) - PosGuion)
    '        Dim DirFiles() As String = System.IO.Directory.GetFiles(direc(i), "*.*")

    '        Sel = "UPDATE Inmuebles SET FotosPC = " & DirFiles.Count & " fotoprincipal='" & DirFiles(0) & "' WHERE Referencia = '" & Ref & "' AND Baja=" & IIf(Baja, GL_SQL_VALOR_1, 0)
    '        Dim aff As Integer = BD_CERO.Execute(Sel)
    '        If aff < 1 Then
    '            CarpetasABorrar.Add(direc(i))
    '        End If

    '    Next

    '    'For i = 0 To CarpetasABorrar.Count - 1
    '    '    System.IO.Directory.Delete(CarpetasABorrar(i), True)
    '    'Next

    '    MsgBox("Fin")
    'End Sub


    Private Sub IGenerarBDAccess_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles IGenerarBDAccess.ItemClick
        GenerarBaseAccess()

    End Sub
    Private Function GenerarBaseAccess() As Integer 'ByVal CONTADORPROYECTO As Integer, ByVal ParaLevantamiento As Boolean, Optional ByVal PrepararDemo As Boolean = False) As Integer


        '1. Comprobar si existe la carpeta levantamiento
        '2. Borrar su contenido
        '3. Copiar ini, exe, listados
        '4. Crear la bd dentro de la carpeta levantamiento y dentro de bases de datos
        '5. Crear tablas Llenar la bd con datos de ese PROYECTO
        '6. Crear relaciones en la bd


        '   Dim ParaLevantamiento As Boolean

        'If GL_Levantamiento Then
        '    MensajeError("Función no disponible en levantamiento")
        '    Return -99
        'End If

        If GL_TipoBD = EnumTipoBD.ACCESS Then
            MensajeError("Función no disponible en para base de datos access")
            Return -99
        End If

        'If CONTADORPROYECTO <> 0 Then
        '    ParaLevantamiento = True
        'Else
        '    ParaLevantamiento = False
        'End If
        'Dim CopiarFicheros As Boolean = True
        Dim DescargarFotos As Boolean = True

        'If ParaLevantamiento Then
        '    If XtraMessageBox.Show("¿Confirma que quiere generar los ficheros de levantamiento del PROYECTO seleccionado?" & vbCrLf & "Recuerde que este PROYECTO estará bloqueado en la central durante el tiempo del levantamiento.", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
        '        Return -99
        '    End If
        '    If XtraMessageBox.Show("¿Quiere descargar también las fotos?" & vbCrLf & "Si durante el levantamiento NO va a utilizar las fotos desde la aplicación, elija NO para que la descarga sea más rápida y eficaz", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
        '        DescargarFotos = True
        '    Else
        '        DescargarFotos = False
        '    End If
        'Else

        'If CONTADORPROYECTO <> 0 Then
        '    Dim SiNoCan As System.Windows.Forms.DialogResult
        '    SiNoCan = XtraMessageBox.Show("¿Quiere generar base de datos access SOLO con el proyecto seleccionado (Si) o por el contrario con todos los proyectos (No) ?", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)
        '    If SiNoCan = Windows.Forms.DialogResult.Cancel Then
        '        Return False
        '    End If
        '    If SiNoCan = Windows.Forms.DialogResult.No Then
        '        CONTADORPROYECTO = 0
        '    End If
        'End If

        'If XtraMessageBox.Show("¿Copiar solo la base de datos (Sí) o copiar Base de datos + ficheros (fotos, planos, etc)  (No) ?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
        'CopiarFicheros = False
        'Else
        'CopiarFicheros = True
        'End If
        'End If

        Dim CARPETA_DESTINO_FINAL As String = ""

        Dim ofd As New FolderBrowserDialog
        Dim errores As New Collections.ArrayList
        Try
            ofd.Description = "Seleccione la carpeta de destino"

            If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
                CARPETA_DESTINO_FINAL = ofd.SelectedPath
            Else
                Return -99
            End If
        Catch ex As Exception
            MensajeError(ex.Message)
            Return -99
        End Try

        Try
            Funciones.ComprobarYCrearCarpetas(CARPETA_DESTINO_FINAL)
        Catch ex As Exception

        End Try


        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor


        'Try
        '    Funciones.ComprobarYCrearCarpetas(CARPETA_DESTINO_FINAL)
        'Catch ex As Exception

        'End Try

        Dim ClaveProyecto As String
        Dim ClaveProyectoSinGuiones As String


        'If CONTADORPROYECTO <> 0 Then
        '    ClaveProyecto = BD_CERO.Execute("SELECT CLAVE FROM PROYECTOS WHERE CONTADOR = " & CONTADORPROYECTO, False)
        'Else
        ClaveProyecto = "Completo"
        'End If

        'ClaveProyectoSinGuiones = ReplaceNIFCIFClientes(ClaveProyecto)
        ClaveProyectoSinGuiones = ClaveProyecto 'Quitar_Acentos(ClaveProyectoSinGuiones)


        '  Dim CARPETA_DESTINO_FINAL As String = ""
        'Dim CARPETA_GENERAL_LEVANTAMIENTO As String = My.Application.Info.DirectoryPath & "\LevantamientoSalida"
        Dim CARPETA_GENERAL_LEVANTAMIENTO As String = clVariables.RutaServidor & "\LevantamientoSalida"
        Dim CARPETA_LEVANTAMIENTO_TEMPORAL As String = CARPETA_GENERAL_LEVANTAMIENTO & "\LEV_" & Format(Now, "ddMMyyyyHHmmsstt") & "_" & ClaveProyectoSinGuiones.ToString

        Funciones.ComprobarYCrearCarpetas(CARPETA_LEVANTAMIENTO_TEMPORAL)

        Dim BdAccessSinCompactar As String
        BdAccessSinCompactar = CARPETA_LEVANTAMIENTO_TEMPORAL & "\VENALIA." & TIPOACCESS

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        frRealizandoCopia.Visible = True
        frRealizandoCopia.Location = New Point(Me.ClientSize.Width / 2 - frRealizandoCopia.Width / 2, Me.ClientSize.Height / 2 - frRealizandoCopia.Height / 2)
        frRealizandoCopia.BringToFront()

        Dim PasosTotales As String

        PasosTotales = "3"


        '**************AQUÍ SE HACE LO IMPORTANTE  *************+

        '1. COPIAR FICHEROS
        '2. CREAR LA BASE DE DATOS
        '3. COMPRIMIR Y CREAR INSTALADOR

        label17.Text = "Realizando paso 1 de " & PasosTotales
        Label18.Text = "Creando Carpetas y copiando ficheros"
        Application.DoEvents()

        FileCopy(clVariables.RutaServidor & "\" & GL_NombreBaseDatosLevantamientoVacia, BdAccessSinCompactar)

        'If CopiarFicheros Then
        '    If Not CopiarFicherosLevantamiento(CONTADORPROYECTO, BdAccessSinCompactar, CARPETA_LEVANTAMIENTO_TEMPORAL, ParaLevantamiento, DescargarFotos) Then
        '        Return -1
        '    End If
        'End If


        label17.Text = "Realizando paso 2 de " & PasosTotales

        If Not CrearBaseDatosLevantamiento(BdAccessSinCompactar, CARPETA_LEVANTAMIENTO_TEMPORAL) Then
            Return -1
        End If


        label17.Text = "Realizando paso 3 de " & PasosTotales
        Label18.Text = "Comprimiendo ficheros"
        Application.DoEvents()


        Dim NombreFicheroDestino As String = "Instalacion Venalia Levantamiento_" & ClaveProyectoSinGuiones & ".exe"

        'If CopiarFicheros Then
        '    If Not GenerarInstaladorLevantamiento(NombreFicheroDestino, CARPETA_LEVANTAMIENTO_TEMPORAL, CARPETA_DESTINO_FINAL, CARPETA_GENERAL_LEVANTAMIENTO) Then
        '        Return -1
        '    End If


        'Else
        ' System.IO.File.Copy(BdAccessSinCompactar, CARPETA_DESTINO_FINAL & "\" & "TRAMEX." & TIPOACCESS, True)
        CopiaArchivoConProgreso(BdAccessSinCompactar, CARPETA_DESTINO_FINAL & "\" & "VENALIA." & TIPOACCESS, True)
        Try
            System.IO.File.Delete(BdAccessSinCompactar)
        Catch ex As Exception

        End Try
        'End If


        Try
            System.IO.Directory.Delete(CARPETA_LEVANTAMIENTO_TEMPORAL, True)
        Catch ex As Exception

        End Try

        'Dim myProcess As New Process()
        'myProcess.Start("Notepad.exe")
        'myProcess.WaitForInputIdle()





        'If ParaLevantamiento Then


        '    Dim Sel As String = ""
        '    Sel = "UPDATE PROYECTOS SET BLOQUEADO=1 WHERE CONTADOR=" & CONTADORPROYECTO
        '    BD_CERO.Execute(Sel)


        'Else
        'If clGenerales.Cuenta("PROYECTOS", " WHERE BLOQUEADO = 1 AND CONTADOR=" & CONTADORPROYECTO) = 0 Then
        '    BD_CERO.Execute(GL_SQL_DELETE & " FROM DATOSLEVANTAMIENTOCABECERA WHERE CONTADORPROYECTO = " & CONTADORPROYECTO & " AND FECHAVUELTA IS NULL")
        'End If


        '
        '  Sel = GL_SQL_DELETE & " FROM DATOSLEVANTAMIENTOCABECERA WHERE CONTADORPROYECTO = " & CONTADORPROYECTO & " AND FECHAVUELTA IS NULL"
        'BD_CERO.Execute(Sel)

        'Sel = "INSERT INTO DATOSLEVANTAMIENTOCABECERA (CONTADORPROYECTO, FECHASALIDA) VALUES (" & CONTADORPROYECTO & ", " & FuncionesGenerales.Funciones.pf_ReplaceFecha(Today) & ")"
        'BD_CERO.Execute(Sel)




        'sw.WriteLine(Sel)

        'sw.WriteLine(Sel)
        'sw.Close()

        'TablaABuscar = "REPRESENTANTESTITULARES"
        'Condicion = " WHERE CONTADORPROYECTO = " & CONTADORPROYECTO
        'ContaABuscar = clGenerales.Maximo("CONTADOR", TablaABuscar, Condicion)
        'Sel = "INSERT INTO DATOSLEVANTAMIENTOCONTADORES (CONTADORLEVANTAMIENTO, TABLA, ULTIMOCONTADOR) VALUES (" & ContaLevantamiento & ", '" & TablaABuscar & "', " & ContaABuscar & ")"
        'BD_CERO.Execute(Sel)



        'End If

        'uProyectosActivo.RefrescarGrid()
        frRealizandoCopia.Visible = False
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        MensajeInformacion("Proceso Finalizado Correctamente en la carpeta " & CARPETA_DESTINO_FINAL)

        Return 0

        'If Not ParaLevantamiento Then 'comentado para poder crear con un usuario no superadministrador 
        '    If XtraMessageBox.Show("¿Desea actualizar el ini para arrancar con ACCESS (NO LEVANTAMIENTO)?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then

        '        If XtraMessageBox.Show("¿Confirma que desea actualizar el ini para arrancar con ACCESS (NO LEVANTAMIENTO)?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
        '            Try
        '                'modificar el ini para ejecutar ocn oracle
        '                FuncionesGenerales.FicheroIni.Escribir(My.Application.Info.DirectoryPath & "\" & My.Application.Info.AssemblyName & ".ini", "OTROS_DATOS", "TIPO_BD", "ACC")
        '                FuncionesGenerales.FicheroIni.Escribir(My.Application.Info.DirectoryPath & "\" & My.Application.Info.AssemblyName & ".ini", "OTROS_DATOS", "ULTIMO_USUARIO", "")

        '                If FuncionesGenerales.FicheroIni.Leer(GL_FicheroINI, "RED", "RED") = "" Then
        '                    Try
        '                        File.Delete(My.Application.Info.DirectoryPath & "\TRAMEX." & TIPOACCESS)
        '                        'File.Delete(My.Application.Info.DirectoryPath & "\USUARIOS." & TIPOACCESS)
        '                    Catch ex As Exception
        '                        MensajeError(ex.Message)
        '                    End Try
        '                    Try
        '                        File.Copy(CARPETA_LEVANTAMIENTO_TEMPORAL & "\TRAMEX." & TIPOACCESS, My.Application.Info.DirectoryPath & "\TRAMEX." & TIPOACCESS, True)
        '                        'File.Copy(CARPETA_LEVANTAMIENTO_TEMPORAL & "\USUARIOS." & TIPOACCESS, My.Application.Info.DirectoryPath & "\USUARIOS." & TIPOACCESS, True)
        '                    Catch ex As Exception
        '                        MensajeError(ex.Message)
        '                    End Try
        '                End If



        '            Catch ex As Exception
        '                MensajeError("Error al cambiar acceso ini a ACCESS" & vbCrLf & ex.Message)
        '                Return False
        '            End Try
        '        End If
        '    End If
        'End If




        ' Process.Start("IExplore.exe", CARPETA_DESTINO_FINAL)





    End Function
    Private Function CrearBaseDatosLevantamiento(ByVal BdAccessSinCompactar As String, ByVal CARPETA_LEVANTAMIENTO_TEMPORAL As String) As Boolean

        Try

            Dim Sel As String = ""

            Dim arTables() As String

            Dim iCount As Long
            Dim sqlMdb As String
            Dim TableName As String
            Dim TableCreate As String

            Dim WhereTieneContadorProyecto As String
            Dim cnBDLevantamientoCreando As OleDb.OleDbConnection
            Dim cmdAccessLevantamiento As OleDb.OleDbCommand

            'Estas son para cuando volvemos del levantamiento
            Dim cnBDAccessOrigen As OleDb.OleDbConnection
            'Dim cmdAccessOrigen As OleDb.OleDbCommand
            'Estas son para cuando volvemos del levantamiento

            Dim dtr As Object


            'For NumeroBD = 0 To 1
            Dim NUMEROBD As Byte = 0
            'If NumeroBD = 0 Then 

            cnBDLevantamientoCreando = GenerarCadenaConexionAccessLevantamiento(BdAccessSinCompactar)

            'If BDAccessOrigen <> "" Then
            '    cnBDAccessOrigen = GenerarCadenaConexionAccessLevantamiento(BDAccessOrigen)
            'End If

            'If ParaLevantamiento Then
            '    PrepararTalblasDatosLevantamientos(CONTADORPROYECTO)
            'End If

            'If BDAccessOrigen = "" Then
            'PrepararTablasDatosLevantamientos(False)
            'End If

            'GETTING THE NAME OF ALL USERTABLES FROM SQL SERVER

            Dim TablasNoDeLevantamiento As String = ""

            Dim OtrasTablas As String = ""

            'If CrearProyectoNuevo Then
            '    OtrasTablas = ",'DOCUMENTOCONTESTACIONESALEGACI','ANUNCIOS', 'ANUNCIOSPOBLACIONES', 'DECRETOINICIALDEFINITIVO', 'DECRETOS', 'DECRETOSHILOS','EXPEDIENTES','EXPEDIENTESHILOS','CITACIONESTITULARES'"
            'End If

            'If BDAccessOrigen <> "" Then
            '    ' TablasNoDeLevantamiento = "IN ('TRAMITESFINCA', 'PROYECTOS', 'MUNICIPIOS', 'ACREDITADO' ,'COMOREPRESENTA' ,'TIPOCARGAS' ,'TIPOPARCELA' ,'CALIFICACIONES' ,'CLASIFICACIONES' ,'DERECHOS' ,'TIPODOCUMENTOTITULO' ,'TIPOSUBFINCAS' ,'UNIDADESMEDIDA' ,'POBLACIONES' ,'AFECCIONES' ,'CULTIVOS' ,'TITULARES' ,'FINCAS' ,'HILOS' ,'DOCUMENTOSFINCA' ,'DOCUMENTOALEGACIONES' ,'DOCUMENTOCATASTROS' ,'DOCUMENTOCONCEPTOSINDEMNIZABLE' ,'DOCUMENTODILIGENCIAS' ,'DOCUMENTOTITULARES' ,'DOCUMENTOTITULOSPROPIEDAD' ,'DATOSREGISTRALESTITULOS' ,'CARGASTITULO','DATOSLEVANTAMIENTOCABECERA','DATOSLEVANTAMIENTOCONTADORES','REPRESENTANTESTITULARES'" & OtrasTablas & ") "
            '    TablasNoDeLevantamiento = "IN ('TRAMITESFINCA', 'PROYECTOS', 'MUNICIPIOS', 'ACREDITADO' ,'COMOREPRESENTA' ,'TIPOCARGAS' ,'TIPOPARCELA' ,'CALIFICACIONES' ,'CLASIFICACIONES' ,'DERECHOS' ,'TIPODOCUMENTOTITULO' ,'TIPOSUBFINCAS' ,'UNIDADESMEDIDA' ,'POBLACIONES' ,'AFECCIONES' ,'CULTIVOS' ,'TITULARES' ,'FINCAS' ,'HILOS' ,'DOCUMENTOSFINCA' ,'DOCUMENTOALEGACIONES' ,'DOCUMENTOCATASTROS' ,'DOCUMENTOCONCEPTOSINDEMNIZABLE' ,'DOCUMENTODILIGENCIAS' ,'DOCUMENTOTITULARES' ,'DOCUMENTOTITULOSPROPIEDAD' ,'DATOSREGISTRALESTITULOS' ,'CARGASTITULO','REPRESENTANTESTITULARES'" & OtrasTablas & ") "

            '    Select Case GL_TipoBD
            '        Case EnumTipoBD.SQL_SERVER
            '            TablasNoDeLevantamiento = " AND NAME " & TablasNoDeLevantamiento
            '        Case EnumTipoBD.ORACLE
            '            TablasNoDeLevantamiento = " AND TABLE_NAME " & TablasNoDeLevantamiento
            '    End Select
            'End If

            Dim PAISES As String = ""
            Select Case GL_TipoBD
                Case EnumTipoBD.SQL_SERVER
                    'If Not DatosUsuario.Nombre = "SUPERADMINISTRADOR" Then PAISES = " AND  " & GL_SQL_UPPER & "(NAME) NOT LIKE 'PAISES' "
                    Sel = "SELECT NAME FROM SYSOBJECTS WHERE XTYPE='U' AND  " & GL_SQL_UPPER & "(LEFT(NAME,3)) " & GL_SQL_DIS & " 'SYS' " & PAISES & TablasNoDeLevantamiento & " ORDER BY NAME"
                Case EnumTipoBD.ORACLE
                    'If Not DatosUsuario.NOMBRE = "SUPERADMINISTRADOR" Then PAISES = " AND TABLE_NAME NOT LIKE 'PAISES' "
                    Sel = "SELECT TABLE_NAME AS NAME FROM ALL_TABLES WHERE (TABLESPACE_NAME='USERS' OR TABLESPACE_NAME='CAR_EXP_OWN') AND TABLE_NAME NOT LIKE 'APEX$%'  AND TABLE_NAME NOT LIKE 'DMRS%' " & PAISES & TablasNoDeLevantamiento & " ORDER BY TABLE_NAME"
            End Select


            Dim BDSQL As New BaseDatos(NUMEROBD)
            dtr = BDSQL.ExecuteReader(Sel)
            If dtr.HASROWS Then
                ReDim arTables(0)
                While dtr.Read
                    arTables(UBound(arTables)) = dtr("NAME")
                    ReDim Preserve arTables(UBound(arTables) + 1)
                End While
            End If
            dtr.Close()
            BDSQL.CerrarBD()

            ReDim Preserve arTables(UBound(arTables) - 1)



            Dim TablaOriginal As String = GL_VACIO

            Dim BdColumnas As New BaseDatos(NUMEROBD)

            For iCount = 0 To UBound(arTables) 'Creation of table in mdb file starts here

                Label18.Text = "Creando tablas e insertando datos" & vbCrLf & "Tabla " & arTables(iCount) & vbCrLf & iCount + 1 & " de " & UBound(arTables)
                Application.DoEvents()

                'If arTables(iCount).ToUpper <> "VISITAS" Then
                '    Continue For
                'End If
                '   Continue For
                Select Case GL_TipoBD
                    Case EnumTipoBD.SQL_SERVER
                        ' Sel = "SELECT SYSCOLUMNS.NAME AS NOMBRE, SYSCOLUMNS.XUSERTYPE AS TIPO, SYSCOLUMNS.PREC AS TAMANO" & _
                        '" FROM SYSOBJECTS INNER JOIN SYSCOLUMNS ON SYSOBJECTS.ID=SYSCOLUMNS.ID" & _
                        '" WHERE SYSOBJECTS.XTYPE='U' AND SYSOBJECTS.NAME = '" & arTables(iCount) & "'"


                        'Sel = "SELECT CAMPO AS NOMBRE, TIPO, TAMANOPRECISIONESCALA, PERMITENULOS, VALORPORDEFECTO,ISIDENTITY, ISCOMPUTED, FORMULA FROM V_TODASLASCOLUMNAS WHERE TABLA = '" & _
                        '     arTables(iCount) & "'"
                        Sel = "SELECT     INFORMATION_SCHEMA.COLUMNS.TABLE_NAME AS TABLA, INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME AS NOMBRE, " &
                    " UPPER(INFORMATION_SCHEMA.COLUMNS.DATA_TYPE) AS TIPO, " &
                    " CASE DATA_TYPE WHEN 'CHAR' THEN CASE CHARACTER_MAXIMUM_LENGTH WHEN - 1 THEN 'MAX' ELSE CONVERT(VARCHAR(1000), " &
                    " CHARACTER_MAXIMUM_LENGTH) END WHEN 'NCHAR' THEN CASE CHARACTER_MAXIMUM_LENGTH WHEN - 1 THEN 'MAX' ELSE CONVERT(VARCHAR(1000), " &
                    " CHARACTER_MAXIMUM_LENGTH) END WHEN 'VARCHAR' THEN CASE CHARACTER_MAXIMUM_LENGTH WHEN - 1 THEN 'MAX' ELSE CONVERT(VARCHAR(1000), " &
                    " CHARACTER_MAXIMUM_LENGTH) END WHEN 'NVARCHAR' THEN CASE CHARACTER_MAXIMUM_LENGTH WHEN - 1 THEN 'MAX' ELSE CONVERT(VARCHAR(1000), " &
                    " CHARACTER_MAXIMUM_LENGTH) END WHEN 'DECIMAL' THEN '(' + CONVERT(VARCHAR(10), NUMERIC_PRECISION) + ',' + CONVERT(VARCHAR(10), " &
                    " NUMERIC_SCALE) + ')' WHEN 'FLOAT' THEN '(' + CONVERT(VARCHAR(10), NUMERIC_PRECISION) + ',' + CONVERT(VARCHAR(10), NUMERIC_SCALE) " &
                    " + ')' END AS TAMANOPRECISIONESCALA, CASE INFORMATION_SCHEMA.COLUMNS.IS_NULLABLE WHEN 'YES' THEN 1 ELSE 0 END AS PERMITENULOS, " &
                    " COLUMNPROPERTY(OBJECT_ID(INFORMATION_SCHEMA.COLUMNS.TABLE_NAME), INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME, 'ISIDENTITY') " &
                    " AS ISIDENTITY, INFORMATION_SCHEMA.COLUMNS.COLUMN_DEFAULT AS VALORPORDEFECTO, " &
                    " COLUMNPROPERTY(OBJECT_ID(INFORMATION_SCHEMA.COLUMNS.TABLE_NAME), INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME, 'ISCOMPUTED') " &
                    " AS ISCOMPUTED, INFORMATION_SCHEMA.COLUMNS.ORDINAL_POSITION AS POSICIONENTABLA, ISNULL(CC.definition, N'') AS FORMULA " &
                    " FROM       INFORMATION_SCHEMA.COLUMNS LEFT OUTER JOIN " &
                    " sys.computed_columns AS CC ON INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME = CC.name WHERE INFORMATION_SCHEMA.COLUMNS.TABLE_NAME = '" & arTables(iCount) & "'"

                    Case EnumTipoBD.ORACLE
                        '   Sel = "SELECT COLUMN_NAME AS NOMBRE,DATA_TYPE AS TIPO, NVL(DATA_PRECISION,DATA_LENGTH)AS TAMANO FROM ALL_TAB_COLUMNS WHERE TABLE_NAME='" & arTables(iCount) & "' ORDER BY COLUMN_ID"
                        Sel = "SELECT COLUMN_NAME AS NOMBRE, DATA_TYPE AS TIPO, NVL(DATA_PRECISION,DATA_LENGTH)AS TAMANOPRECISIONESCALA,CASE WHEN NULLABLE='Y' THEN 1 ELSE 0 END AS PERMITENULOS," &
                                "DATA_DEFAULT AS VALORPORDEFECTO,(SELECT COUNT(*) FROM ALL_TRIGGERS WHERE TABLE_NAME='" & arTables(iCount) & "' AND  " & GL_SQL_UPPER & "(WHEN_CLAUSE) LIKE '%NEW.' || A.COLUMN_NAME || ' %' ) AS ISIDENTITY," &
                                "0 AS ISCOMPUTED,'' AS FORMULA, (select get_data_default(USER, '" & arTables(iCount) & "', COLUMN_NAME ) from dual) AS VALORPORDEFECTO2 FROM ALL_TAB_COLUMNS A WHERE TABLE_NAME='" &
                                arTables(iCount) & "' ORDER BY COLUMN_ID"

                End Select

                Dim NombreCampoAutonumerico As String = ""


                BdColumnas.LlenarDataSet(Sel, "Columnas")

                If BdColumnas.ds.Tables("Columnas").Rows.Count > 0 Then

                    TableName = arTables(iCount)
                    TableCreate = "CREATE TABLE " & TableName & TablaOriginal & " ("
                    NombreCampoAutonumerico = ""


                    'Dim SenteciaAlter As String
                    Dim SoyPrimerCampo As Boolean = True
                    Dim ValoresPorDefecto As New List(Of String)

                    '    Dim New_BDATRIBUTOS As New BaseDatos(NUMEROBD)

                    For Each drColumnas As DataRow In BdColumnas.ds.Tables("Columnas").Rows

                        'Dim SelAtributos As String = ""
                        'Select Case GL_TipoBD
                        '    Case EnumTipoBD.SQL_SERVER
                        '        SelAtributos = "SELECT TIPO, TAMANOPRECISIONESCALA, PERMITENULOS, VALORPORDEFECTO,ISIDENTITY, ISCOMPUTED, FORMULA FROM V_TODASLASCOLUMNAS WHERE TABLA = '" & _
                        '            TableName & "' AND CAMPO = '" & drColumnas("NOMBRE") & "'"
                        '    Case EnumTipoBD.ORACLE
                        '        SelAtributos = "SELECT DATA_TYPE AS TIPO, NVL(DATA_PRECISION,DATA_LENGTH)AS TAMANOPRECISIONESCALA,C ASE WHEN NULLABLE='Y' THEN 1 ELSE 0 END AS PERMITENULOS," & _
                        '            "DATA_DEFAULT AS VALORPORDEFECTO,(SELECT COUNT(*) FROM ALL_TRIGGERS WHERE TABLE_NAME='" & arTables(iCount) & "' AND  " & GL_SQL_UPPER & "(WHEN_CLAUSE)LIKE '%NEW." & drColumnas("NOMBRE") & " %')AS ISIDENTITY," & _
                        '            "0 AS ISCOMPUTED,'' AS FORMULA, (select get_data_default(USER, '" & TableName & "', '" & drColumnas("NOMBRE") & "' ) from dual) AS VALORPORDEFECTO2 FROM ALL_TAB_COLUMNS WHERE TABLE_NAME='" & _
                        '            arTables(iCount) & "' AND COLUMN_NAME ='" & drColumnas("NOMBRE") & "'"
                        'End Select

                        Dim TIPO As String
                        Dim TamanoPrecisionEscala As String
                        Dim PermiteNulos As Integer
                        '  Dim ValorPorDefecto As String
                        Dim IsIdentity As Integer
                        Dim IsComputed As Integer
                        Dim Formula As String

                        ' Dim TextoTamano As String
                        'Dim TextoValorDefecto As String

                        'Dim dtAtributos As New DataTable

                        'New_BDATRIBUTOS.LlenarDataSet(SelAtributos, "Atributos")
                        'dtAtributos = New_BDATRIBUTOS.ds.Tables("Atributos")

                        '    Dim dr As DataRow




                        TIPO = drColumnas("TIPO")
                        If IsDBNull(drColumnas("TAMANOPRECISIONESCALA")) Then
                            TamanoPrecisionEscala = 0
                        Else
                            TamanoPrecisionEscala = drColumnas("TAMANOPRECISIONESCALA")
                            If TamanoPrecisionEscala = GL_VACIO Then
                                TamanoPrecisionEscala = 0
                            End If
                        End If



                        PermiteNulos = drColumnas("PERMITENULOS")
                        'If TablaOriginal = "ORIGINAL" Then
                        IsIdentity = drColumnas("ISIDENTITY")
                        'Else
                        '    IsIdentity = 0
                        'End If

                        IsComputed = drColumnas("ISCOMPUTED")
                        If IsDBNull(drColumnas("FORMULA")) Then
                            Formula = ""
                        Else
                            Formula = drColumnas("FORMULA")
                        End If


                        If Formula.Trim <> GL_VACIO Then
                            Formula = Formula
                        End If


                        If SoyPrimerCampo Then
                            SoyPrimerCampo = False
                        Else
                            TableCreate = TableCreate & ", "
                        End If

                        Dim NuevoCampo As String
                        NuevoCampo = drColumnas("NOMBRE") & " "
                        'NuevoCampo &= IIf(IsIdentity = 1, " AUTOINCREMENT ", GetDataTypeEnum(drColumnas("TIPO"), TamanoPrecisionEscala))
                        If IsIdentity = 1 Then 'BDAccessOrigen = "" AndAlso
                            Dim BDMAX As New BaseDatos(NUMEROBD)
                            Dim MAXCONTADOR As Integer = BDMAX.Execute("SELECT " & Funciones.SQL_CASE_ISNULL("MAX(" & drColumnas("NOMBRE") & "),1") & " FROM " & TableName, False) + 1
                            NombreCampoAutonumerico = NuevoCampo
                            NuevoCampo &= " AUTOINCREMENT (" & MAXCONTADOR & ",1)"
                            BDMAX.CerrarBD()
                            ' NuevoCampo &= GetDataTypeEnum(drColumnas("TIPO"), TamanoPrecisionEscala)
                        Else
                            NuevoCampo &= GetDataTypeEnum(drColumnas("TIPO"), TamanoPrecisionEscala)
                        End If

                        'NuevoCampo &= IIf(PermiteNulos = 1, "", " NOT NULL ")

                        TableCreate = TableCreate & NuevoCampo

                        'IIf(IsDBNull(drColumnas("ValorPorDefecto")), "", " DEFAULT " & drColumnas("ValorPorDefecto"))
                        'TableCreate = TableCreate & NuevoCampo


                        Dim TieneValoresPorDefecto As Boolean = False

                        ' ''If Not IsDBNull(drColumnas("VALORPORDEFECTO2")) Then


                        ' ''    ''Si estoy en Oracle, hay que hacer una movida para sacar el valor por defecto
                        ' ''    'Dim VPD As String = ""
                        ' ''    'VPD = drColumnas("VALORPORDEFECTO2")
                        ' ''    ''Select Case GL_TipoBD
                        ' ''    ''    Case EnumTipoBD.SQL_SERVER
                        ' ''    ''        VPD = drColumnas("VALORPORDEFECTO")
                        ' ''    ''    Case EnumTipoBD.ORACLE
                        ' ''    ''        Dim BDVPD As New BaseDatos
                        ' ''    ''        VPD = BDVPD.Execute("select get_data_default(USER, '" & TableName & "', '" & drColumnas("NOMBRE") & "' ) from dual", False)
                        ' ''    ''End Select

                        ' ''    'VPD.Trim()

                        ' ''    TieneValoresPorDefecto = True
                        ' ''    Dim VALORDEF As String = GL_VACIO
                        ' ''    VALORDEF = drColumnas("VALORPORDEFECTO2")
                        ' ''    If VALORDEF Is Nothing Then
                        ' ''        VALORDEF = GL_ESPACIOSQL
                        ' ''    End If
                        ' ''    VALORDEF.Trim()
                        ' ''    If GetDataTypeEnum(drColumnas("TIPO"), TamanoPrecisionEscala) = "BIT" Then


                        ' ''        If VALORDEF.Contains("0") Then
                        ' ''            VALORDEF = "FALSE"
                        ' ''        End If
                        ' ''        If VALORDEF.Contains("1") Then
                        ' ''            VALORDEF = "TRUE"
                        ' ''        End If
                        ' ''    End If

                        ' ''    VALORDEF = Replace(VALORDEF, "(", "")
                        ' ''    VALORDEF = Replace(VALORDEF, ")", "")
                        ' ''    If VALORDEF = GL_VACIO Then
                        ' ''        VALORDEF = GL_ESPACIO
                        ' ''    End If




                        ' ''    Select Case GL_TipoBD
                        ' ''        Case EnumTipoBD.SQL_SERVER
                        ' ''            If InStr(VALORDEF.ToUpper, "GETDATE[]") > 0 Then
                        ' ''                VALORDEF = Replace(VALORDEF, "Getdate[]", "Date()", , , CompareMethod.Text)
                        ' ''            End If
                        ' ''        Case EnumTipoBD.ORACLE
                        ' ''            If VALORDEF.ToUpper.Contains("SYSDATE") Then
                        ' ''                VALORDEF = Replace(VALORDEF, "SYSDATE", "Date()", , , CompareMethod.Text)
                        ' ''            End If
                        ' ''    End Select





                        ' ''    SenteciaAlter = "ALTER TABLE " & TableName & TablaOriginal & " ALTER COLUMN " & drColumnas("NOMBRE") & " "
                        ' ''    'SenteciaAlter &= IIf(IsIdentity = 1, " AUTOINCREMENT ", GetDataTypeEnum(drColumnas("TIPO"), TamanoPrecisionEscala))
                        ' ''    'If IsIdentity = 1 Then
                        ' ''    '    Dim BDMAX As New BaseDatos(NUMEROBD)
                        ' ''    '    Dim MAXCONTADOR As Integer = BDMAX.Execute("SELECT " & Funciones.SQL_CASE_ISNULL("MAX(" & drColumnas("NOMBRE") & "),1") & " FROM " & TableName, False) + 1
                        ' ''    '    SenteciaAlter &= " AUTOINCREMENT (" & MAXCONTADOR & ",1)"
                        ' ''    '    'SenteciaAlter &= GetDataTypeEnum(drColumnas("TIPO"), TamanoPrecisionEscala)
                        ' ''    'Else
                        ' ''    SenteciaAlter &= GetDataTypeEnum(drColumnas("TIPO"), TamanoPrecisionEscala)
                        ' ''    ' End If
                        ' ''    SenteciaAlter &= IIf(PermiteNulos = 1, "", " NOT NULL ")

                        ' ''    If TieneValoresPorDefecto Then
                        ' ''        If VALORDEF = GL_ESPACIO OrElse VALORDEF = "' '" & vbLf & "   " OrElse VALORDEF = "' '" Then
                        ' ''            SenteciaAlter &= " DEFAULT "" """

                        ' ''        Else
                        ' ''            SenteciaAlter &= " DEFAULT " & VALORDEF
                        ' ''        End If

                        ' ''    End If


                        ' ''    ValoresPorDefecto.Add(SenteciaAlter)
                        ' ''End If


                        'If CampoIdentity <> "" AndAlso drColumnas("NOMBRE").ToString.ToUpper = CampoIdentity.ToUpper Then
                        '    If Microsoft.VisualBasic.Right(TableCreate, 14) = "LONG DEFAULT 0" Then
                        '        TableCreate = Microsoft.VisualBasic.Left(TableCreate, Len(TableCreate) - 14)
                        '    End If
                        '    TableCreate = TableCreate & " AUTOINCREMENT "
                        'End If
                        ' BDATRIBUTOS.CerrarBD()

                    Next



                    TableCreate = TableCreate & ")"

                    Dim SentenciaAEjecutar As String = TableCreate

                    cnBDLevantamientoCreando.Open()

                    cmdAccessLevantamiento = New OleDb.OleDbCommand(SentenciaAEjecutar, cnBDLevantamientoCreando)
                    ' cmdAccessLevantamiento.Connection.Open()
                    cmdAccessLevantamiento.ExecuteNonQuery()
                    '   cmdAccessLevantamiento.Connection.Close()

                    For Each s As String In ValoresPorDefecto
                        SentenciaAEjecutar = s
                        cmdAccessLevantamiento = New OleDb.OleDbCommand(SentenciaAEjecutar, cnBDLevantamientoCreando)
                        '   cmdAccessLevantamiento.Connection.Open()
                        cmdAccessLevantamiento.ExecuteNonQuery()
                        '   cmdAccessLevantamiento.Connection.Close()
                    Next

                    If cnBDLevantamientoCreando.State = ConnectionState.Open Then
                        cnBDLevantamientoCreando.Close()
                    End If

                    '  cnBDLevantamientoCreando.Execute(TableCreate, , 129) 'Table Creation in Mdb

                    '*********************************Ahora Toca los datos***************************

                    'If TablaOriginal = "ORIGINAL" Then



                    WhereTieneContadorProyecto = GL_VACIO

                    'If arTables(iCount).ToString.ToUpper <> "VISITAS" Then
                    Dim OrderBy As String = ""
                    If NombreCampoAutonumerico <> "" Then
                        OrderBy = " ORDER BY " & NombreCampoAutonumerico
                    End If

                    'If arTables(iCount).ToUpper = "POBLACIONES" Then
                    '    Sel = "SELECT * FROM " & arTables(iCount) & IIf(WhereTieneContadorProyecto = GL_VACIO, " WHERE PROVINCIA='VALENCIA' OR PROVINCIA='ALICANTE'", WhereTieneContadorProyecto & " AND PROVINCIA='VALENCIA' OR PROVINCIA='ALICANTE'") & OrderBy
                    'Else
                    Sel = "SELECT * FROM " & arTables(iCount) & WhereTieneContadorProyecto & OrderBy
                    'End If
                    dtr = New Object
                    'If BDAccessOrigen = "" Then
                    BDSQL = New BaseDatos(NUMEROBD)
                    dtr = BDSQL.ExecuteReader(Sel)
                    'Else
                    '    cmdAccessOrigen = New OleDb.OleDbCommand(Sel, cnBDAccessOrigen)
                    '    If cnBDAccessOrigen.State <> ConnectionState.Open Then
                    '        cnBDAccessOrigen.Open()
                    '        '    cnBDAccessOrigen.Close()
                    '    End If
                    '    dtr = cmdAccessOrigen.ExecuteReader()
                    'End If

                    If dtr.HasRows Then

                        sqlMdb = "SELECT * FROM " & arTables(iCount) & TablaOriginal & OrderBy


                        Dim dt As DataTable
                        Dim dr As DataRow
                        Dim ds As New DataSet
                        Dim da As New OleDb.OleDbDataAdapter(sqlMdb, cnBDLevantamientoCreando)
                        Dim cb As New OleDb.OleDbCommandBuilder(da)
                        da.Fill(ds, arTables(iCount))
                        dt = ds.Tables(arTables(iCount))
                        Dim numRows As Integer = BD_CERO.Execute("SELECT COUNT(*) FROM " & arTables(iCount) & WhereTieneContadorProyecto, False)
                        Dim numPercent = If(numRows > 0, 100 / numRows, 0)
                        Dim cont As Integer = -1

                        While dtr.Read
                            cont += 1
                            lblPercent.Text = "Creando " & CInt(numPercent * cont) & " %" : Application.DoEvents()

                            dr = dt.NewRow

                            'Dim RestarNumero As Integer = 0
                            'If CampoIdentity <> "" Then
                            '    RestarNumero = 1
                            'End If

                            For i = 0 To dt.Columns.Count - 1 ' - RestarNumero
                                Try
                                    If TypeOf dtr(i) Is TimeSpan Then
                                        dr(i) = "01/01/1900 " & dtr(i).ToString
                                    Else
                                        dr(i) = dtr(i)
                                    End If
                                Catch ex As Exception
                                    dr(i) = dtr(i)
                                End Try
                            Next

                            'If CampoIdentity <> "" Then
                            '    dr("AutoNum") = dtr(CampoIdentity)
                            'End If


                            dt.Rows.Add(dr)


                        End While

                        Dim ColeccionCampos As String
                        Dim ColeccionValores As String


                        'Sql = "UPDATE " & BaseDatos & ".dbo" & Tabla & " SET  DOCUMENTO = '" & DOCUMENTO & "' WHERE CONTADORDOCUMENTO = " & ContadorDocumentoDestino
                        'bd0.Execute(Sql)

                        ColeccionCampos = Funciones.F_OBTENERCOLECCIONDECAMPOS(arTables(iCount), GL_VACIO, NUMEROBD)

                        lblPercent.Text = "Creando Fin" : Application.DoEvents()

                        Dim FECHA As String

                        For I = 0 To dt.Rows.Count - 1

                            lblPercent.Text = "Insertando " & CInt(numPercent * I) & " %"
                            Application.DoEvents()

                            ColeccionValores = GL_VACIO

                            For II = 0 To dt.Columns.Count - 1

                                Dim O As Object = dt.Columns(II).DataType
                                Select Case O.NAME.ToString.ToUpper
                                    Case "BOOLEAN", "BYTE"
                                        Try
                                            ColeccionValores &= "," & If(IsDBNull(dt.Rows(I)(II)), "0", Funciones.pf_ReplaceTrueFalse(dt.Rows(I)(II)))
                                        Catch ex As Exception
                                            ColeccionValores &= ",0"
                                        End Try

                                    Case "INT32", "DOUBLE", "INT64"
                                        Try
                                            ColeccionValores &= "," & If(IsDBNull(dt.Rows(I)(II)), "0", Funciones.ReplacePuntos(dt.Rows(I)(II)))
                                        Catch ex As Exception
                                            ColeccionValores &= ",0"
                                        End Try
                                    Case "STRING"
                                        If dt.Rows(I)(II).ToString.Contains("'") Then
                                            If dt.Rows(I)(II).ToString.Contains("SELECT") AndAlso dt.Rows(I)(II).ToString.Contains("FROM") Then
                                                dt.Rows(I)(II) = GL_VACIO
                                            Else
                                                dt.Rows(I)(II) = Replace(dt.Rows(I)(II).ToString, "'", "''")
                                            End If
                                        End If
                                        ColeccionValores &= ",'" & dt.Rows(I)(II) & "'"
                                    Case "DATETIME"
                                        FECHA = "'" & dt.Rows(I)(II) & "'"
                                        If FECHA = "''" Then
                                            FECHA = "NULL"
                                        End If
                                        ColeccionValores &= "," & FECHA
                                    Case "TIMESPAN", "DATE", "TIME"
                                        ColeccionValores &= GL_VACIO
                                    Case Else
                                        ColeccionValores &= GL_VACIO
                                End Select

                            Next

                            ColeccionValores = ColeccionValores.Substring(1)
                            SentenciaAEjecutar = " INSERT INTO " & arTables(iCount) & TablaOriginal & " (" & ColeccionCampos & ") VALUES (" & ColeccionValores & ")"

                            If cnBDLevantamientoCreando.State = ConnectionState.Closed Then
                                cnBDLevantamientoCreando.Open()
                            End If

                            cmdAccessLevantamiento = New OleDb.OleDbCommand(SentenciaAEjecutar, cnBDLevantamientoCreando)
                            '  cmdAccessLevantamiento.Connection.Open()
                            cmdAccessLevantamiento.ExecuteNonQuery()
                            '  cmdAccessLevantamiento.Connection.Close()
                        Next

                        lblPercent.Text = ""
                        Application.DoEvents()

                        'End If


                        If cnBDLevantamientoCreando.State = ConnectionState.Open Then
                            cnBDLevantamientoCreando.Close()
                        End If

                        'If BDAccessOrigen = "" Then
                        If Not IsNothing(cnBDAccessOrigen) AndAlso cnBDAccessOrigen.State = ConnectionState.Open Then
                            cnBDAccessOrigen.Close()
                        End If

                        'End If

                    End If
                    dtr.CLOSE()
                    BDSQL.CerrarBD()
                    dtr = Nothing


                End If

            Next



            ' label17.Text = "Realizando paso 3"
            Label18.Text = "Creando Claves Principales, relaciones e índices"
            Application.DoEvents()

            'Ahora vamos a poner las claves principales

            Dim TablaAnterior As String
            Dim Campos As String

            Select Case GL_TipoBD
                Case EnumTipoBD.SQL_SERVER
                    Sel = "SELECT I1.TABLE_NAME AS TABLA, I2.COLUMN_NAME AS CAMPO FROM " &
                  " INFORMATION_SCHEMA.TABLE_CONSTRAINTS I1" &
                  " INNER JOIN" &
                  " INFORMATION_SCHEMA.KEY_COLUMN_USAGE I2" &
                  " ON I1.CONSTRAINT_NAME = I2.CONSTRAINT_NAME" &
                  " WHERE I1.CONSTRAINT_TYPE = 'PRIMARY KEY' AND  " & GL_SQL_UPPER & "(LEFT(I1.TABLE_NAME,3)) <> 'SYS' " &
                  "  AND I1.TABLE_NAME <> 'PAISES' " & TablasNoDeLevantamiento &
                  " ORDER BY  I1.TABLE_NAME"
                Case EnumTipoBD.ORACLE
                    Sel = "SELECT TABLE_NAME AS TABLA, COLUMN_NAME AS CAMPO FROM USER_CONS_COLUMNS WHERE (CONSTRAINT_NAME LIKE 'PK%' OR CONSTRAINT_NAME LIKE '%_PK')" &
                         " AND TABLE_NAME <> 'PAISES' AND TABLE_NAME NOT LIKE 'APEX%'" & TablasNoDeLevantamiento
            End Select



            dtr = BDSQL.ExecuteReader(Sel)

            If dtr.HASROWS Then
                TablaAnterior = GL_VACIO
                Campos = GL_VACIO

                While dtr.READ
                    If TablaAnterior <> dtr("TABLA") Then
                        If Campos.Trim <> GL_VACIO Then

                            Try

                                Sel = "ALTER TABLE " & TablaAnterior & " ADD CONSTRAINT 'PK_" & TablaAnterior & "' PRIMARY KEY (" & Campos & ")"
                                cmdAccessLevantamiento = New OleDb.OleDbCommand(Sel, cnBDLevantamientoCreando)
                                If cnBDLevantamientoCreando.State = ConnectionState.Closed Then
                                    cmdAccessLevantamiento.Connection.Open()
                                End If
                                cmdAccessLevantamiento.ExecuteNonQuery()
                            Catch ex As Exception

                            End Try
                            '   cmdAccessLevantamiento.Connection.Close()


                            '  CNBDLEVANTAMIENTOCREANDO.EXECUTE(SEL)
                        End If
                        TablaAnterior = dtr("TABLA")
                        Campos = dtr("CAMPO")
                    Else
                        Campos = Campos & ", " & dtr("CAMPO")
                    End If

                End While


                Sel = "ALTER TABLE " & TablaAnterior & " ADD CONSTRAINT 'CLAVEPRIN' PRIMARY KEY (" & Campos & ")"

                cmdAccessLevantamiento = New OleDb.OleDbCommand(Sel, cnBDLevantamientoCreando)
                If cnBDLevantamientoCreando.State = ConnectionState.Closed Then
                    cmdAccessLevantamiento.Connection.Open()
                End If
                cmdAccessLevantamiento.ExecuteNonQuery()
                ' cmdAccessLevantamiento.Connection.Close()

            End If
            dtr.CLOSE()

            ''VALORES UNIQUE

            TablaAnterior = GL_VACIO
            Campos = GL_VACIO

            Select Case GL_TipoBD
                Case EnumTipoBD.SQL_SERVER
                    Sel = "SELECT I1.TABLE_NAME AS TABLA, I2.COLUMN_NAME AS CAMPO FROM " &
                  " INFORMATION_SCHEMA.TABLE_CONSTRAINTS I1" &
                  " INNER JOIN" &
                  " INFORMATION_SCHEMA.KEY_COLUMN_USAGE I2" &
                  " ON I1.CONSTRAINT_NAME = I2.CONSTRAINT_NAME" &
                  " WHERE I1.CONSTRAINT_TYPE = 'UNIQUE' AND  " & GL_SQL_UPPER & "(LEFT(I1.TABLE_NAME,3)) <> 'SYS'" & TablasNoDeLevantamiento & " ORDER BY  I1.TABLE_NAME"
                Case EnumTipoBD.ORACLE
                    Sel = "SELECT TABLE_NAME AS TABLA, COLUMN_NAME AS CAMPO FROM USER_CONS_COLUMNS WHERE CONSTRAINT_NAME LIKE 'UQ%'" & TablasNoDeLevantamiento
            End Select


            dtr = BDSQL.ExecuteReader(Sel)

            If dtr.HasRows Then
                TablaAnterior = GL_VACIO
                Campos = GL_VACIO

                While dtr.Read




                    Sel = "CREATE UNIQUE INDEX " & dtr("CAMPO") & " ON " & dtr("TABLA") & "(" & dtr("CAMPO") & ")"
                    cmdAccessLevantamiento = New OleDb.OleDbCommand(Sel, cnBDLevantamientoCreando)
                    If cnBDLevantamientoCreando.State = ConnectionState.Closed Then
                        cmdAccessLevantamiento.Connection.Open()
                    End If
                    cmdAccessLevantamiento.ExecuteNonQuery()
                    'cmdAccessLevantamiento.Connection.Close()

                End While


            End If
            dtr.CLOSE()
            ''        Sel = "CREATE UNIQUE INDEX CONTADOR ON FINCAS (CONTADOR)"
            ''        cnBDLevantamientoCreando.Execute(Sel)

            ''        'Ahora vamos a poner las relaciones

            Dim TablaFKAnterior As String
            Dim TablaPrincipalAnterior As String
            Dim CamposFK As String
            Dim CamposPrincipal As String
            Dim NombreFKAnterior As String

            Select Case GL_TipoBD
                Case EnumTipoBD.SQL_SERVER
                    Sel = "SELECT O1.NAME NOMBREFK, O2.NAME TABLAFK, C1.NAME CAMPOFK, O3.NAME TABLAPRINCIPAL, C2.NAME CAMPOPRINCIPAL" &
                   " FROM SYSFOREIGNKEYS FK" &
                   " JOIN SYSOBJECTS O1 ON FK.CONSTID = O1.ID" &
                   " JOIN SYSOBJECTS O2 ON FK.FKEYID = O2.ID" &
                   " JOIN SYSOBJECTS O3 ON FK.RKEYID = O3.ID" &
                   " JOIN SYSCOLUMNS C1 ON FK.FKEY = C1.COLID AND FK.FKEYID = C1.ID" &
                   " JOIN SYSCOLUMNS C2 ON FK.RKEY = C2.COLID AND FK.RKEYID = C2.ID" &
                   Replace(TablasNoDeLevantamiento, " AND NAME IN", " AND O1.NAME IN") &
                   " ORDER BY TABLAFK,TABLAPRINCIPAL"
                Case EnumTipoBD.ORACLE
                    Sel = "SELECT A.CONSTRAINT_NAME AS NOMBREFK, A.TABLE_NAME AS TABLAFK, A.COLUMN_NAME AS CAMPOFK, C_PK.TABLE_NAME AS TABLAPRINCIPAL,  B.COLUMN_NAME AS CAMPOPRINCIPAL " &
                "FROM USER_CONS_COLUMNS A " &
                "JOIN USER_CONSTRAINTS C ON A.OWNER = C.OWNER AND A.CONSTRAINT_NAME = C.CONSTRAINT_NAME " &
                "JOIN USER_CONSTRAINTS C_PK ON C.R_OWNER = C_PK.OWNER AND C.R_CONSTRAINT_NAME = C_PK.CONSTRAINT_NAME " &
                "JOIN USER_CONS_COLUMNS B ON C_PK.OWNER = B.OWNER AND  C_PK.CONSTRAINT_NAME = B.CONSTRAINT_NAME AND B.POSITION = A.POSITION " &
                "WHERE C.CONSTRAINT_TYPE = 'R' AND A.CONSTRAINT_NAME LIKE 'FK%' " & Replace(TablasNoDeLevantamiento, " AND TABLE_NAME IN", " AND A.TABLE_NAME IN") & " ORDER BY TABLAFK,TABLAPRINCIPAL"
            End Select

            dtr = BDSQL.ExecuteReader(Sel)

            If dtr.HasRows Then
                TablaFKAnterior = GL_VACIO
                TablaPrincipalAnterior = GL_VACIO
                CamposFK = GL_VACIO
                CamposPrincipal = GL_VACIO
                NombreFKAnterior = GL_VACIO

                While dtr.Read
                    If NombreFKAnterior <> dtr("NOMBREFK") Then
                        If CamposFK.Trim <> GL_VACIO Then

                            'If UCase(TablaFKAnterior) = "POBLACIONES" And UCase(TablaPrincipalAnterior) = "PROVINCIAS" Then
                            '    Sel = "ALTER TABLE POBLACIONES  ADD CONSTRAINT 'FK_Poblaciones_Provincias' FOREIGN  KEY (CodigoPoblacionesProvincias, CodigoPoblacionesPais) REFERENCES PROVINCIAS( CodigoProvincias,CodigoProvinciasPais) ON UPDATE CASCADE ON DELETE CASCADE"
                            'Else

                            If Len(NombreFKAnterior) > 50 Then
                                NombreFKAnterior = Microsoft.VisualBasic.Left(NombreFKAnterior, 50)
                            End If
                            Sel = "ALTER TABLE " & TablaFKAnterior & "  ADD CONSTRAINT '" & NombreFKAnterior & "' FOREIGN  KEY (" & CamposFK & ") REFERENCES " & TablaPrincipalAnterior & "(" & CamposPrincipal & ") ON UPDATE CASCADE ON DELETE CASCADE"
                            'End If

                            'NombreFKAnterior = Microsoft.VisualBasic.Left("FK_ClientesComunicacionesVisitaOficina_ClientesComunicacionesVisitaOficina", 50)
                            'Sel = "ALTER TABLE ClientesComunicacionesEmailListadoClientes  ADD CONSTRAINT '" & NombreFKAnterior & "' FOREIGN  KEY (ContadorCliente) REFERENCES Clientes(Contador) ON UPDATE CASCADE ON DELETE CASCADE"
                            'Sel = "ALTER TABLE ClientesComunicacionesVisitaOficina  ADD CONSTRAINT 'FK_ClientesComunicacionesVisitaOficina_ClientesComunicacionesVisitaOficina' FOREIGN  KEY (ContadorCliente) REFERENCES Clientes(Contador) ON UPDATE CASCADE ON DELETE CASCADE"


                            cmdAccessLevantamiento = New OleDb.OleDbCommand(Sel, cnBDLevantamientoCreando)
                            If cnBDLevantamientoCreando.State = ConnectionState.Closed Then
                                cmdAccessLevantamiento.Connection.Open()
                            End If

                            cmdAccessLevantamiento.ExecuteNonQuery()

                        End If
                        TablaFKAnterior = dtr("TABLAFK")
                        CamposFK = dtr("CAMPOFK")
                        TablaPrincipalAnterior = dtr("TABLAPRINCIPAL")
                        CamposPrincipal = dtr("CAMPOPRINCIPAL")
                        NombreFKAnterior = dtr("NOMBREFK")
                    Else
                        If TablaPrincipalAnterior <> dtr("TABLAPRINCIPAL") Then
                            If CamposFK.Trim <> GL_VACIO Then

                                Sel = "ALTER TABLE " & TablaFKAnterior & "  ADD CONSTRAINT '" & NombreFKAnterior & "' FOREIGN  KEY (" & CamposFK & ") REFERENCES " & TablaPrincipalAnterior & "(" & CamposPrincipal & ") ON UPDATE CASCADE ON DELETE CASCADE"
                                cmdAccessLevantamiento = New OleDb.OleDbCommand(Sel, cnBDLevantamientoCreando)
                                If cnBDLevantamientoCreando.State = ConnectionState.Closed Then
                                    cmdAccessLevantamiento.Connection.Open()
                                End If
                                cmdAccessLevantamiento.ExecuteNonQuery()
                                '        cmdAccessLevantamiento.Connection.Close()

                            End If
                            TablaFKAnterior = dtr("TABLAFK")
                            CamposFK = dtr("CAMPOFK")
                            TablaPrincipalAnterior = dtr("TABLAPRINCIPAL")
                            CamposPrincipal = dtr("CAMPOPRINCIPAL")
                            NombreFKAnterior = dtr("NOMBREFK")
                        Else
                            CamposFK = CamposFK & ", " & dtr("CAMPOFK")
                            CamposPrincipal = CamposPrincipal & ", " & dtr("CAMPOPRINCIPAL")
                        End If
                    End If

                End While



                Sel = "ALTER TABLE " & TablaFKAnterior & "  ADD CONSTRAINT '" & NombreFKAnterior & "' FOREIGN  KEY (" & CamposFK & ") REFERENCES " & TablaPrincipalAnterior & "(" & CamposPrincipal & ") ON UPDATE CASCADE ON DELETE CASCADE"
                cmdAccessLevantamiento = New OleDb.OleDbCommand(Sel, cnBDLevantamientoCreando)
                If cnBDLevantamientoCreando.State = ConnectionState.Closed Then
                    cmdAccessLevantamiento.Connection.Open()
                End If
                cmdAccessLevantamiento.ExecuteNonQuery()
                ' cmdAccessLevantamiento.Connection.Close()


            End If
            dtr.CLOSE()
            'If BDAccessOrigen = "" Then
            'Dim BDUsuarios As New BaseDatos(1)
            'If Not DatosUsuario.NOMBRE = "SUPERADMINISTRADOR" Then

            '    '  Dim Consultora As String = BDUsuarios.Execute ("SELECT Contador FROM CONSULTORAS 
            '    Sel = "DELETE FROM USUARIOS WHERE CONTADORCONSULTORA <> " & DatosUsuario.CONTADORCONSULTORA
            '    cmdAccessLevantamiento = New OleDb.OleDbCommand(Sel, cnBDLevantamientoCreando)
            '    If cnBDLevantamientoCreando.State = ConnectionState.Closed Then
            '        cmdAccessLevantamiento.Connection.Open()
            '    End If
            '    cmdAccessLevantamiento.ExecuteNonQuery()
            '    ' cmdAccessLevantamiento.Connection.Close()

            '    Sel = "DELETE FROM CONSULTORAS WHERE CONTADOR  <> " & DatosUsuario.CONTADORCONSULTORA
            '    cmdAccessLevantamiento = New OleDb.OleDbCommand(Sel, cnBDLevantamientoCreando)
            '    If cnBDLevantamientoCreando.State = ConnectionState.Closed Then
            '        cmdAccessLevantamiento.Connection.Open()
            '    End If
            '    cmdAccessLevantamiento.ExecuteNonQuery()
            '    '  cmdAccessLevantamiento.Connection.Close()

            '    Sel = "INSERT INTO USUARIOS (CONTADORCONSULTORA, NOMBRE, USUARIO, PASS, TIPO, EMAIL, DISENOPERFIL, BAJA, ORGANISMOPREDETERMINADO) VALUES (" & DatosUsuario.CONTADORCONSULTORA & ",'LEVANTAMIENTO','LEVANTAMIENTO','" & Encriptacion.Encriptar("1234", "LAMBDAPI") & "','ADMINISTRADOR',' ','The Asphalt World',0,1)"
            '    cmdAccessLevantamiento = New OleDb.OleDbCommand(Sel, cnBDLevantamientoCreando)
            '    If cnBDLevantamientoCreando.State = ConnectionState.Closed Then
            '        cmdAccessLevantamiento.Connection.Open()
            '    End If
            '    cmdAccessLevantamiento.ExecuteNonQuery()
            '    'cmdAccessLevantamiento.Connection.Close()

            'End If


            'If CopiarFicheros Then
            '    Sel = "SELECT Usuario FROM USUARIOS"


            '    Dim dss As New DataSet
            '    Dim daa As New OleDb.OleDbDataAdapter(Sel, cnBDLevantamientoCreando)
            '    daa.Fill(dss, "USUARIOS")


            '    For i = 0 To dss.Tables("USUARIOS").Rows.Count - 1

            '        If System.IO.Directory.Exists(clVariables.RutaServidor & "\PERFILES\BASE_DE_PERFILES") Then
            '            Funciones.ComprobarYCrearCarpetas(clVariables.RutaServidor & "\PERFILES")

            '            If Directory.Exists(CARPETA_LEVANTAMIENTO_TEMPORAL & "\PERFILES\PERFILES_" & dss.Tables("USUARIOS").Rows(i)("Usuario")) Then
            '                Directory.Delete(CARPETA_LEVANTAMIENTO_TEMPORAL & "\PERFILES\PERFILES_" & dss.Tables("USUARIOS").Rows(i)("Usuario"), True)
            '            End If

            '            FuncionesGenerales.Funciones.DirectoryCopy(clVariables.RutaServidor & "\PERFILES\BASE_DE_PERFILES", CARPETA_LEVANTAMIENTO_TEMPORAL & "\PERFILES\PERFILES_" & dss.Tables("USUARIOS").Rows(i)("Usuario"), True)
            '        End If

            '    Next
            'End If
            'End If


            cnBDLevantamientoCreando.Close()
            BDSQL.CerrarBD()


        Catch ex As Exception
            MensajeError(ex.Message)
            'If BDAccessOrigen <> "" Then
            '    Funciones.EscribeLogTexto(GL_FicheroLogImportarLevantamiento, "Error creando base sin autonumérico" & vbCrLf & ex.Message)
            'End If

            Return False
        End Try

        Return True

    End Function
    Public Function GetDataTypeEnum(ByVal val, ByVal siz) As String
        Select Case GL_TipoBD
            Case EnumTipoBD.SQL_SERVER
                Select Case val

                    Case "56", "127", "52", "INT", "BIGINT"
                        GetDataTypeEnum = "LONG" '"adInteger"
                    Case "7", "58", "40", "DATETIME", "DATE", "TIME"
                        GetDataTypeEnum = "DATE" '"adDate"
                    Case "104", "173", "165", "BIT"
                        GetDataTypeEnum = "BIT" '"adBoolean"
                        'GetDataTypeEnum = "BYTE" '"adBoolean"
                    Case "61"
                        GetDataTypeEnum = "DATE" '"adDBDate"
                    Case "99", "VARCHAR"
                        If siz < 255 Then GetDataTypeEnum = "TEXT(" & siz & ")" Else GetDataTypeEnum = "MEMO"
                    Case "175", "239", "231", "35", "167"
                        If siz < 255 Then GetDataTypeEnum = "TEXT(" & siz & ")" Else GetDataTypeEnum = "MEMO"
                    Case "106", "62", "60", "59", "122", "FLOAT"
                        GetDataTypeEnum = "DOUBLE"
                    Case Else


                End Select
            Case EnumTipoBD.ORACLE
                Select Case val
                    Case "NUMBER"
                        If siz = 10 Then
                            GetDataTypeEnum = "LONG" '(10)"adInteger"
                        Else
                            GetDataTypeEnum = "BIT" '(1)"adBoolean"
                        End If
                    Case "DATE" '"adDate"
                        GetDataTypeEnum = "DATE" '"adDate"
                    Case "CLOB" '"adLongVarChar"
                        GetDataTypeEnum = "MEMO" '"adLongVarChar"
                    Case "VARCHAR2"
                        If siz < 255 Then GetDataTypeEnum = "TEXT(" & siz & ")" Else GetDataTypeEnum = "MEMO"
                    Case "FLOAT"
                        GetDataTypeEnum = "DOUBLE"
                        'Case 56, 127, 52
                        '    GetDataTypeEnum = "NUMBER(10)" '"adInteger"
                        'Case 7, 58, 40
                        '    GetDataTypeEnum = "DATE" '"adDate"
                        'Case 104, 173, 165
                        '    GetDataTypeEnum = "NUMBER(1)" '"adBoolean"
                        'Case 61
                        '    GetDataTypeEnum = "DATE" '"adDBDate"
                        'Case 99, 35
                        '    GetDataTypeEnum = "CLOB" '"adLongVarChar"
                        'Case 175, 239, 231, 167
                        '    If siz <= 4000 AndAlso siz > 0 Then GetDataTypeEnum = "VARCHAR2(" & siz & ")" Else GetDataTypeEnum = "CLOB"
                        'Case 106, 62, 60, 59, 122
                        '    GetDataTypeEnum = "FLOAT(12)"

                End Select
        End Select


        'SELECT Case val

        '    Case 56, 127, 52
        '        GetDataTypeEnum = "LONG DEFAULT 0" '"adInteger"
        '    Case 7, 58, 40
        '        GetDataTypeEnum = "DATE" '"adDate"
        '    Case 104, 173, 165
        '        GetDataTypeEnum = "BIT" '"adBoolean"
        '    Case 61
        '        GetDataTypeEnum = "DATE" '"adDBDate"
        '    Case 99
        '        GetDataTypeEnum = "MEMO" '"adLongVarChar"
        '    Case 175, 239, 231, 35, 167
        '        If siz < 255 Then GetDataTypeEnum = "TEXT(" & siz & ")" Else GetDataTypeEnum = "MEMO"
        '    Case 106, 62, 60, 59, 122
        '        GetDataTypeEnum = "DOUBLE DEFAULT 0"

        'End Select


    End Function
    Sub CopiaArchivoConProgreso(ByVal Origen As String, ByVal Destino As String, ByVal Reemplazar As Boolean)
        'path = ruta del lugar de origen, en donde se encuentra el archivo
        'path2 = ruta del lugar de destino, a donde se copiará el archivo
        'file = nombre del archivo a copiar
        If Reemplazar Then
            If File.Exists(Destino) Then
                Try
                    File.Delete(Destino)
                Catch ex As Exception

                End Try
            End If
        End If
        'Dim pf As ProgressForm

        Dim fi As New IO.FileInfo(Origen)
        Dim sr As New IO.FileStream(Origen, IO.FileMode.Open) 'lugar de origen
        Dim sw As New IO.FileStream(Destino, IO.FileMode.Create) 'lugar de destino

        Dim len As Long = sr.Length - 1

        Dim pf As New ProgressForm(len, "Copiando fichero ...")

        'pf = ProgressForm
        'pf.ProgressControl.Maximum = 100

        'pf.ProgressControl.ProgressText = "Copiando fichero ..."

        'pf.StartPosition = FormStartPosition.Manual

        'Dim P As Point
        'P.X = (Screen.PrimaryScreen.WorkingArea.Width - pf.Width) / 2
        'P.Y = (Screen.PrimaryScreen.WorkingArea.Height - pf.Height) / 2
        'pf.Location = P

        'pf.BringToFront()
        'pf.Show()


        For i As Long = 0 To len
            sw.WriteByte(sr.ReadByte)
            If i Mod 1000 = 0 Then 'Actualiza con cada 1 kb copiado
                ' pf.ProgressControl.Value += 1
                pf.nuevoPaso()
                'pf.ProgressControl.Value = i * 100 / len
                'ProgressBar1.Value = i * 100 / len
                'Application.DoEvents()
            End If
        Next
        Try
            pf.Close()
        Catch ex As Exception

        End Try
        sr.Close()
        sw.Close()
    End Sub
    Private Function GenerarCadenaConexionAccessLevantamiento(ByVal BaseDatos As String) As OleDb.OleDbConnection

        Dim oConexion As New OleDb.OleDbConnection

        Try

            '  oConexion.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & BaseDatos

            ' oConexion.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & BaseDatos & ";Jet OLEDB:Database Password=" & clVariables.PassWordUsuarioSQL & ";"

            oConexion.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & BaseDatos & ";Jet OLEDB:Database Password=" & PassAccessLevantamiento


            '   oConexion.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & BaseDatos & "; ExtendedAnsiSQL=1"

            'oConexion.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & BaseDatos & "; ExtendedAnsiSQL=1"

            ' oConexion.ConnectionString = "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=D:\Nueva carpeta (6)\Tramex." & TIPOACCESS & ";Uid=Admin;Pwd=;ExtendedAnsiSQL=1;"



            'oConexion.Open()
            'oConexion.Close()

        Catch Ex As OleDb.OleDbException
            MensajeError("Error al conectar con datos" & ControlChars.CrLf & Ex.Message)
            Return Nothing
        End Try
        Return oConexion

    End Function





    Private Sub IBBDD_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles IBBDD.ItemClick
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim fbd As New FolderBrowserDialog
        fbd.Description = "Indique la carpeta donde se realizará la copia"
        If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                If GL_TipoBD = EnumTipoBD.SQL_SERVER Then
                    Dim err As String = Funciones.HacerCopiaSeguridadCompleta(fbd.SelectedPath)
                    If err <> "" Then
                        MensajeError("Error al realizar la copia de la BBDD. " & err)
                        Me.Cursor = System.Windows.Forms.Cursors.Arrow
                        Exit Sub
                    End If
                ElseIf GL_TipoBD = EnumTipoBD.ACCESS Then
                    IO.File.Copy(My.Application.Info.DirectoryPath & "\VENALIA2.MDB", fbd.SelectedPath & "\VENALIA2.MDB")
                End If
            Catch ex As Exception
                MensajeError("Error al realizar la copia de la BBDD. " & ex.Message)
                Me.Cursor = System.Windows.Forms.Cursors.Arrow
                Exit Sub
            End Try
            MensajeInformacion("Copia realizada correctamente.")
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub

    Private Sub IEnviarDatos_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles IEnviarDatos.ItemClick

        Publicar()
    End Sub
    Private Sub IImagenes_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles IImagenes.ItemClick
        Shell("explorer.exe root = " & My.Application.Info.DirectoryPath & "\fotos\" & DatosEmpresa.Codigo, vbNormalFocus)
    End Sub


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


    Private Sub IPublicarTodosLosInmuebles_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles IPublicarTodosLosInmuebles.ItemClick

        If MsgBox("¿Confirma que quiere actualizar todos los inmuebles?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Return
        End If


        Dim Sel As String = "SELECT Referencia FROM Inmuebles WHERE CodigoEmpresa = " & DatosEmpresa.Codigo & " AND Baja = 0  AND Reservado = 0 AND ID_WP = 0   "
        '" And referencia = '10001876' "
        'If DatosEmpresa.WordPress Then
        '    Sel = Sel & " AND id_wp = 0 "
        'End If

        Sel = Sel & " ORDER BY Referencia DESC"


        Dim bdin As New BaseDatos
        bdin.LlenarDataSet(Sel, "T")

        For i = 0 To bdin.ds.Tables("T").Rows.Count - 1
            FuncionesGenerales.FuncionesBD.SincronizarReferencia("INSERT", bdin.ds.Tables("T").Rows(i)("Referencia"), "")
        Next



        'Sel = "SELECT Id_WP FROM Inmuebles WHERE Id_WP <> 0"
        'bdin = New BaseDatos
        'bdin.LlenarDataSet(Sel, "T")

        'For i = 0 To bdin.ds.Tables("T").Rows.Count - 1
        '    WP_Eliminar_General("Inmuebles", bdin.ds.Tables("T").Rows(i)("Id_WP"), True)
        'Next


        MensajeInformacion("Fin")


        'Sel = "INSERT INTO AccionesPendientes (Accion,Tabla,Referencia,CodigoEmpresa,Codigo,Fecha, Pendiente, Aleatorio) " &
        '                " SELECT 'INSERT','INMUEBLES',Referencia," & DatosEmpresa.Codigo & ",'', " & GL_SQL_GETDATE & "," & GL_SQL_VALOR_1 & ",'' FROM Inmuebles"

        'BD_CERO.Execute(Sel)





        'Publicar()
    End Sub

    Private Sub Publicar()
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        pnlEnviado.Visible = True

        Dim p As New Point

        p.Y = Me.Height / 2 - pnlEnviado.Height / 2
        p.X = Me.Width / 2 - pnlEnviado.Width / 2

        pnlEnviado.Location = p


        Dim CodigoSalida As Integer
        Dim ProcessProperties As New ProcessStartInfo
        ProcessProperties.FileName = My.Application.Info.DirectoryPath & "\EnviosVenalia\" & "EnviosVenalia.exe"
        ProcessProperties.Arguments = "E|S"
        ProcessProperties.WindowStyle = ProcessWindowStyle.Hidden
        Try
            Dim myProcess As Process = Process.Start(ProcessProperties)
            myProcess.WaitForExit()
            CodigoSalida = myProcess.ExitCode ' --> En esta línea es en la que capturo el código que meha 
        Catch ex As Exception

        End Try



        Me.Cursor = System.Windows.Forms.Cursors.Arrow

        'Dim startInfo As New ProcessStartInfo(My.Application.Info.DirectoryPath & "\EnviosVenalia\" & "EnviosVenalia.exe")
        'Dim cmdLine As String
        'cmdLine = "E|S"
        'startInfo.Arguments = cmdLine

        ''    startInfo.CreateNoWindow = True

        ''Deseamos manipular la salida del proceso, para ello debemos establecer que se redirija la salida
        ''  startInfo.RedirectStandardOutput = True

        ''  Process.Start(startInfo)

        'Dim procID As Integer
        'Dim newProc As Diagnostics.Process

        'Dim procEC As Integer = -1

        'newProc = Diagnostics.Process.Start(startInfo)
        'procID = newProc.Id
        'newProc.WaitForExit()


        'If newProc.HasExited Then
        '    procEC = newProc.ExitCode
        'End If
        ''MsgBox("El proceso con ID " & CStr(procID) & _
        ''    " ha terminado con el código de salida: " & CStr(procEC))


        pnlEnviado.Visible = False
    End Sub

    Private Sub frmPrincipal_Resize(sender As System.Object, e As System.EventArgs) Handles MyBase.Resize
        cambiaTamaño()
    End Sub
    Private Sub frmPrincipal_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

        Me.Height = Screen.PrimaryScreen.WorkingArea.Height
        Me.Width = Screen.PrimaryScreen.WorkingArea.Width
        Me.Left = 0
        Me.Top = 0

        cambiaTamaño()
        Panellmagenes.Visible = True
    End Sub
    Private Sub cambiaTamaño()
        Panellmagenes.Left = (Me.Width / 2) - (Panellmagenes.Width) / 2
        Panellmagenes.Top = (Me.Height / 2) - (Panellmagenes.Height) / 2 '- 100
    End Sub
    Private Sub picAlarmas_Click(sender As System.Object, e As System.EventArgs) Handles picAlarmas.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        CargarFormulario("Alarmas", Ribbon.SelectedPage.Name)
        'Panellmagenes.Visible = False
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub
    Private Sub picClientes_Click(sender As System.Object, e As System.EventArgs) Handles picClientes.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        CargarFormulario("Clientes", Ribbon.SelectedPage.Name)
        'Panellmagenes.Visible = False
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub

    Private Sub picPropietarios_Click(sender As System.Object, e As System.EventArgs) Handles picPropietarios.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        CargarFormulario("Propietarios", Ribbon.SelectedPage.Name)
        'Panellmagenes.Visible = False
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub

    Private Sub picInmuebles_Click(sender As System.Object, e As System.EventArgs) Handles picInmuebles.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        CargarFormulario("Inmuebles", Ribbon.SelectedPage.Name)
        'Panellmagenes.Visible = False
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub

    Private Sub picPortales_Click(sender As System.Object, e As System.EventArgs) Handles picPortales.Click
        ribbonControl.SelectedPage = pgPortales
        ribbonControl.Minimized = False
    End Sub

    Private Sub picVenaliaApp_Click(sender As System.Object, e As System.EventArgs) Handles picVenaliaApp.Click

    End Sub

    Private Sub picExit_Click(sender As System.Object, e As System.EventArgs) Handles picExit.Click
        iSalir()
    End Sub

    'Private Sub PintarPaginas()

    '    Try

    '        GL_GruposVisibles = ""
    '        Dim todoslosgruposinvisibles As Boolean
    '        Dim Adquirido As Boolean = False
    '        Dim Permiso As Boolean = False



    '        Select Case GL_TIPO_EMPRESA
    '            Case "ELECTRO"
    '                ITablaDinamicaFacturas.Visibility = BarItemVisibility.Never
    '                ITablaDinamicaPedidos.Visibility = BarItemVisibility.Never
    '                ITablaDinamicaPendiente.Visibility = BarItemVisibility.Never
    '                IResumenAnual.Visibility = BarItemVisibility.Never
    '                grCMVentas.Visible = False
    '                IInforme1.Visibility = BarItemVisibility.Always
    '            Case Else

    '                ITablaDinamicaFacturas.Visibility = BarItemVisibility.Always
    '                ITablaDinamicaPedidos.Visibility = BarItemVisibility.Always
    '                ITablaDinamicaPendiente.Visibility = BarItemVisibility.Always

    '                If GL_Nombre_Empresa_EW.ToUpper = "ASTRO" AndAlso Microsoft.VisualBasic.InStr(GL_BD_EW.ToUpper, "WX") > 0 Then
    '                    IResumenAnual.Visibility = BarItemVisibility.Always
    '                    grDireccion.Visible = True
    '                Else
    '                    IResumenAnual.Visibility = BarItemVisibility.Never
    '                    grDireccion.Visible = False
    '                End If

    '                IInforme1.Visibility = BarItemVisibility.Never


    '                'If GL_Nombre_Empresa_EW.ToUpper = "ASTRO" AndAlso Microsoft.VisualBasic.InStr(GL_BD_EW.ToUpper, "WX") > 0 Then

    '                '    IInforme1.Visibility = BarItemVisibility.Never
    '                '    ITablaDinamicaFacturas.Visibility = BarItemVisibility.Always
    '                '    ITablaDinamicaPedidos.Visibility = BarItemVisibility.Always
    '                '    ITablaDinamicaPendiente.Visibility = BarItemVisibility.Always


    '                '    ' If DatosUsuario.USUARIO = "a" Then
    '                '    IResumenAnual.Visibility = BarItemVisibility.Always
    '                '    'End If
    '                'Else
    '                '    IResumenAnual.Visibility = BarItemVisibility.Never
    '                '    IInforme1.Visibility = BarItemVisibility.Never
    '                'End If

    '        End Select

    '        Dim sCodigoEmpresa As String = 0

    '        Try
    '            sCodigoEmpresa = Encriptacion.DesEncriptar(FuncionesGenerales.FicheroIni.Leer(GL_FicheroINI, "CONFIG", Encriptacion.Encriptar("CODIGOEMPRESA", "LAMBDAPI")), "LAMBDAPI")

    '        Catch ex As Exception
    '            MensajeError("Error de código. La aplicación finalizará")
    '            End
    '        End Try
    '        If Not IsNumeric(sCodigoEmpresa) Then
    '            MensajeError("Error de código 2. La aplicación finalizará")
    '            End
    '        End If
    '        Try

    '            Dim ServicioWeb As New wsGestionaControl.WebServiceGestionaControlClient
    '            Dim Res2 As wsGestionaControl.clPermisosGestiona
    '            Res2 = ServicioWeb.ObtenerPermisosGestiona("TresBits", "EE358CB6BF1683287B21B102BBC848EB", CInt(sCodigoEmpresa), "GESTIONA")
    '            FuncionesGenerales.FicheroIni.Escribir(GL_FicheroINI_RED, "CONFIG", Encriptacion.Encriptar("Páginas", "LAMBDAPI"), Encriptacion.Encriptar(Res2.sPermisos, "LAMBDAPI"))

    '        Catch ex As Exception
    '            MensajeError("Error de código. La aplicación finalizará")
    '            End
    '        End Try


    '        Dim items As String '= Encriptacion.Encriptar(",Albaranes,Comisiones,Control,", "LAMBDAPI")
    '        Dim ModulosAdquiridos As String = Encriptacion.DesEncriptar(FuncionesGenerales.FicheroIni.Leer(GL_FicheroINI_RED, "CONFIG", Encriptacion.Encriptar("Páginas", "LAMBDAPI")), "LAMBDAPI")
    '        For Each pagina As DevExpress.XtraBars.Ribbon.RibbonPage In ribbonControl.Pages


    '            If ModulosAdquiridos.Contains("," & pagina.Name) OrElse pagina.Name.ToUpper = "PGCONTROL" Then
    '                pagina.Visible = True
    '                Adquirido = True
    '                Permiso = True
    '            Else
    '                pagina.Visible = False
    '                Adquirido = False
    '                Permiso = False
    '            End If



    '            If Adquirido AndAlso (DatosUsuario.TIPO <> "ADMINISTRADOR") Then ' Or TienenPermiso = "TODOS" Then
    '                todoslosgruposinvisibles = True
    '                Permiso = True
    '                For Each grupo As Ribbon.RibbonPageGroup In pagina.Groups
    '                    grupo.Visible = False
    '                    items = ""
    '                    For Each PermisoUsuario As String In DatosUsuario.Permisos

    '                        If grupo.Name = PermisoUsuario.Split("|")(0) Then
    '                            For Each item As DevExpress.XtraBars.BarItemLink In pagina.Groups(PermisoUsuario.Split("|")(0)).ItemLinks
    '                                If item.Item.Name = PermisoUsuario.Split("|")(1) Then
    '                                    grupo.Visible = True
    '                                    todoslosgruposinvisibles = False
    '                                    item.Item.Visibility = BarItemVisibility.Always
    '                                Else
    '                                    If Not items.Contains(item.Item.Name & "|") Then
    '                                        item.Item.Visibility = BarItemVisibility.Never
    '                                    End If
    '                                End If
    '                                If Not items.Contains(item.Item.Name & "|") Then
    '                                    items &= item.Item.Name & "|"
    '                                End If
    '                            Next
    '                        End If
    '                    Next
    '                    If pagina.Visible AndAlso grupo.Visible Then
    '                        GL_GruposVisibles &= grupo.Name & grupo.Text & "|"
    '                    End If
    '                Next

    '                If todoslosgruposinvisibles Then
    '                    pagina.Visible = False
    '                    Permiso = False
    '                End If

    '            Else
    '                If DatosUsuario.TIPO = "ADMINISTRADOR" Then ' Or TienenPermiso = "TODOS" Then
    '                    '   Adquirido = True
    '                    Permiso = True
    '                End If


    '            End If

    '            PintarPics(pagina.Name, Adquirido, Permiso)






    '        Next

    '        Select Case GL_TIPO_EMPRESA
    '            Case "ELECTRO"
    '                ITablaDinamicaFacturas.Visibility = BarItemVisibility.Never
    '                ITablaDinamicaPedidos.Visibility = BarItemVisibility.Never
    '                ITablaDinamicaPendiente.Visibility = BarItemVisibility.Never
    '                IResumenAnual.Visibility = BarItemVisibility.Never
    '                grCMVentas.Visible = False
    '                IInforme1.Visibility = BarItemVisibility.Always
    '        End Select




    '    Catch ex As Exception

    '    End Try

    'End Sub
    'Private Sub PintarPics(NombrePagina As String, Adquirido As Boolean, Permiso As Boolean)


    '    Select Case NombrePagina
    '        Case "pgAlbaranes"

    '            If Not Adquirido Then  'Amarill
    '                picAlbaranes.Image = Gestiona.My.Resources.Resources._01G
    '                '  picAlbaranes.Enabled = False
    '                picAlbaranes.Tag = GL_NO_ADQUIRIDO
    '                Dim myToolTipText = "SOLICITE INFORMACIÓN SOBRE ESTE PRODUCTO"
    '                ToolTip1.SetToolTip(Me.picAlbaranes, myToolTipText)
    '            Else
    '                If Permiso Then  'Naranja
    '                    picAlbaranes.Image = Gestiona.My.Resources.Resources._01
    '                    picAlbaranes.Tag = GL_ADQUIRIDO_Y_PERMISO
    '                Else  'Gris
    '                    picAlbaranes.Image = Gestiona.My.Resources.Resources._01A
    '                    '     picAlbaranes.Enabled = False
    '                    picAlbaranes.Tag = GL_ADQUIRIDO_Y_NO_PERMISO
    '                    Dim myToolTipText = "CONSULTE AL ADMINISTRADOR DE SU SISTEMA"
    '                    ToolTip1.SetToolTip(Me.picAlbaranes, myToolTipText)
    '                End If
    '            End If



    '        Case "pgComisiones"

    '            If Not Adquirido Then  'Amarill
    '                picComisiones.Image = Gestiona.My.Resources.Resources._02G
    '                '     picComisiones.Enabled = False
    '                picComisiones.Tag = GL_NO_ADQUIRIDO
    '                Dim myToolTipText = "SOLICITE INFORMACIÓN SOBRE ESTE PRODUCTO"
    '                ToolTip1.SetToolTip(Me.picComisiones, myToolTipText)
    '            Else
    '                If Permiso Then  'Naranja
    '                    picComisiones.Image = Gestiona.My.Resources.Resources._02
    '                    picComisiones.Tag = GL_ADQUIRIDO_Y_PERMISO
    '                Else  'Gris
    '                    picComisiones.Image = Gestiona.My.Resources.Resources._02A
    '                    '   picComisiones.Enabled = False
    '                    picComisiones.Tag = GL_ADQUIRIDO_Y_NO_PERMISO
    '                    Dim myToolTipText = "CONSULTE AL ADMINISTRADOR DE SU SISTEMA"
    '                    ToolTip1.SetToolTip(Me.picComisiones, myToolTipText)
    '                End If
    '            End If

    '        Case "pgMineria"
    '            If Not Adquirido Then  'Amarill
    '                picMineria.Image = Gestiona.My.Resources.Resources._03G
    '                picMineria.Tag = GL_NO_ADQUIRIDO
    '                Dim myToolTipText = "SOLICITE INFORMACIÓN SOBRE ESTE PRODUCTO"
    '                ToolTip1.SetToolTip(Me.picMineria, myToolTipText)
    '            Else
    '                If Permiso Then  'Naranja
    '                    picMineria.Image = Gestiona.My.Resources.Resources._03
    '                    picMineria.Tag = GL_ADQUIRIDO_Y_PERMISO
    '                Else  'Gris
    '                    picMineria.Image = Gestiona.My.Resources.Resources._03A
    '                    ' picMineria.Enabled = False
    '                    picMineria.Tag = GL_ADQUIRIDO_Y_NO_PERMISO
    '                    Dim myToolTipText = "CONSULTE AL ADMINISTRADOR DE SU SISTEMA"
    '                    ToolTip1.SetToolTip(Me.picMineria, myToolTipText)
    '                End If
    '            End If

    '        Case "pgInventario"
    '            If Not Adquirido Then  'Amarill
    '                picInventario.Image = Gestiona.My.Resources.Resources._09G
    '                picInventario.Tag = GL_NO_ADQUIRIDO
    '                Dim myToolTipText = "SOLICITE INFORMACIÓN SOBRE ESTE PRODUCTO"
    '                ToolTip1.SetToolTip(Me.picInventario, myToolTipText)
    '            Else
    '                If Permiso Then  'Naranja
    '                    picInventario.Image = Gestiona.My.Resources.Resources._09
    '                    picInventario.Tag = GL_ADQUIRIDO_Y_PERMISO
    '                Else  'Gris
    '                    picInventario.Image = Gestiona.My.Resources.Resources._09A
    '                    '    picInventario.Enabled = False
    '                    picInventario.Tag = GL_ADQUIRIDO_Y_NO_PERMISO
    '                    Dim myToolTipText = "CONSULTE AL ADMINISTRADOR DE SU SISTEMA"
    '                    ToolTip1.SetToolTip(Me.picInventario, myToolTipText)
    '                End If
    '            End If

    '        Case "pgLogistica"
    '            If Not Adquirido Then  'Amarill
    '                picLogistica.Image = Gestiona.My.Resources.Resources._07G
    '                picLogistica.Tag = GL_NO_ADQUIRIDO
    '                Dim myToolTipText = "SOLICITE INFORMACIÓN SOBRE ESTE PRODUCTO"
    '                ToolTip1.SetToolTip(Me.picLogistica, myToolTipText)
    '            Else
    '                If Permiso Then  'Naranja
    '                    picLogistica.Image = Gestiona.My.Resources.Resources._07
    '                    picLogistica.Tag = GL_ADQUIRIDO_Y_PERMISO
    '                Else  'Gris
    '                    picLogistica.Image = Gestiona.My.Resources.Resources._07A
    '                    '     picLogistica.Enabled = False
    '                    picLogistica.Tag = GL_ADQUIRIDO_Y_NO_PERMISO
    '                    Dim myToolTipText = "CONSULTE AL ADMINISTRADOR DE SU SISTEMA"
    '                    ToolTip1.SetToolTip(Me.picLogistica, myToolTipText)
    '                End If
    '            End If

    '        Case "pgCuadroMandos"
    '            If Not Adquirido Then  'Amarill
    '                picCuadroMandos.Image = Gestiona.My.Resources.Resources._05G
    '                picCuadroMandos.Tag = GL_NO_ADQUIRIDO
    '                Dim myToolTipText = "SOLICITE INFORMACIÓN SOBRE ESTE PRODUCTO"
    '                ToolTip1.SetToolTip(Me.picCuadroMandos, myToolTipText)
    '            Else
    '                If Permiso Then  'Naranja
    '                    picCuadroMandos.Image = Gestiona.My.Resources.Resources._05
    '                    picCuadroMandos.Tag = GL_ADQUIRIDO_Y_PERMISO
    '                Else  'Gris
    '                    picCuadroMandos.Image = Gestiona.My.Resources.Resources._05A
    '                    '     picCuadroMandos.Enabled = False
    '                    picCuadroMandos.Tag = GL_ADQUIRIDO_Y_NO_PERMISO
    '                    Dim myToolTipText = "CONSULTE AL ADMINISTRADOR DE SU SISTEMA"
    '                    ToolTip1.SetToolTip(Me.picCuadroMandos, myToolTipText)
    '                End If
    '            End If
    '        Case "pgInformes"
    '            If Not Adquirido Then  'Amarill
    '                picInformes.Image = Gestiona.My.Resources.Resources._06G
    '                picInformes.Tag = GL_NO_ADQUIRIDO
    '                Dim myToolTipText = "SOLICITE INFORMACIÓN SOBRE ESTE PRODUCTO"
    '                ToolTip1.SetToolTip(Me.picInformes, myToolTipText)
    '            Else
    '                If Permiso Then  'Naranja
    '                    picInformes.Image = Gestiona.My.Resources.Resources._06
    '                    picInformes.Tag = GL_ADQUIRIDO_Y_PERMISO
    '                Else  'Gris
    '                    picInformes.Image = Gestiona.My.Resources.Resources._06A
    '                    '      picInformes.Enabled = False
    '                    picInformes.Tag = GL_ADQUIRIDO_Y_NO_PERMISO
    '                    Dim myToolTipText = "CONSULTE AL ADMINISTRADOR DE SU SISTEMA"
    '                    ToolTip1.SetToolTip(Me.picInformes, myToolTipText)
    '                End If
    '            End If


    '    End Select


    'End Sub




    Private Sub IListadoCartel_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles IListadoCartel.ItemClick
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim p As New frmFechas
        p.dgvx.Visible = False
        p.ShowDialog()
        If GL_FechaInicio = "" OrElse GL_FechaFin = "" Then
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            Exit Sub
        End If

        GL_FechaFin = CDate(GL_FechaFin).AddDays(1).ToString("dd/MM/yyyy")

        Dim Sel As String = "select FechaCartel, Referencia" &
         ", Direccion" & GL_SQL_SUMA & "' '" & GL_SQL_SUMA & "Numero" & GL_SQL_SUMA & "', Alt. '" & GL_SQL_SUMA & SQL_CONVERT("varchar(10)", "Altura") & " as Direccion" &
         ",(Select Nombre From Empleados e Where e.Contador=cc.ContadorEmpleado)as Comercial" &
         " from Inmuebles cc Where CodigoEmpresa=" & DatosEmpresa.Codigo & " and QuienCartel <> 0  and Delegacion=" & Gl_Delegacion & " and FechaCartel >= " & pf_ReplaceFecha(CDate(GL_FechaInicio)) & " AND FechaCartel < " & pf_ReplaceFecha(CDate(GL_FechaFin)) &
        "order by FechaCartel"
        Dim bdstats As New BaseDatos
        bdstats.LlenarDataSet(Sel, "Datos")
        Dim DT As DataTable = bdstats.ds.Tables("Datos")
        'System.IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\Listados\Esquemas\")
        '  DT.WriteXmlSchema(My.Application.Info.DirectoryPath & "\Listados\Esquemas\Datos.xsd")
        'DT.WriteXml(My.Application.Info.DirectoryPath & "\Listados\Esquemas\Datos.xml", XmlWriteMode.WriteSchema)
        Dim r As New rptListadoCartel
        r.DataSource = DT
        r.DataMember = "Datos"
        r.Titulo.Text = "Carteles puestos desde " & GL_FechaInicio & " hasta " & GL_FechaFin
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        r.ShowPreview()
    End Sub

    Private Sub IListadoComoConocio_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles IListadoComoConocio.ItemClick
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim p As New frmFechas
        p.dgvx.Visible = False
        p.panelComoConociste.Visible = True
        p.ShowDialog()
        If GL_FechaInicio = "" OrElse GL_FechaFin = "" Then
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            Exit Sub
        End If

        GL_FechaFin = CDate(GL_FechaFin).AddDays(1).ToString("dd/MM/yyyy")

        Dim Sel, where As String
        where = " WHERE CodigoEmpresa=" & DatosEmpresa.Codigo & " AND Delegacion=" & Gl_Delegacion &
            " AND FechaAlta >= " & pf_ReplaceFecha(CDate(GL_FechaInicio)) & " AND FechaAlta < " & pf_ReplaceFecha(CDate(GL_FechaFin))
        If GL_ComoConociste.Split("|")(1) <> "" Then where &= " AND ComoConociste = '" & GL_ComoConociste.Split("|")(1) & "' "
        If GL_ComoConociste.Split("|")(0) = 0 Then
            'sin agrupar
            Sel = "SELECT Nombre,ComoConociste,Telefono1,Telefono2,TelefonoMovil FROM Clientes " & where
        Else
            'agrupando
            Sel = "SELECT ComoConociste,COUNT(*) as Total FROM Clientes " & where & " Group by ComoConociste"
        End If

        Dim bdstats As New BaseDatos
        bdstats.LlenarDataSet(Sel, "Datos")
        Dim DT As DataTable = bdstats.ds.Tables("Datos")
        'DT.WriteXmlSchema(My.Application.Info.DirectoryPath & "\Listados\Esquemas\Datos.xsd")
        If GL_ComoConociste.Split("|")(0) = 0 Then
            Dim r As New rptListadoComoConocio
            r.DataSource = DT
            r.DataMember = "Datos"
            r.Titulo.Text = "Listado de como nos conocieron " & GL_ComoConociste.Split("|")(1)
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            r.ShowPreview()
        Else
            Dim r As New rptListadoComoConocioAgrupado
            r.DataSource = DT
            r.DataMember = "Datos"
            r.Titulo.Text = "Listado de como nos conocieron "
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            r.ShowPreview()
        End If
    End Sub


    Private Sub btnContadorOrigen_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnContadorOrigen.ItemClick

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Dim Sel As String = ""
        Dim Tabla As String = "Inmuebles"

        Sel = "select  count(*)as c,ContadorPropietario, Tipo, Via, Direccion, Altura, CodPostal, Poblacion, Provincia, Numero, Puerta FROM " & Tabla &
          " where  direccion <> '' and numero <> '' and puerta <> '' " &
          " group by ContadorPropietario,Tipo, Via, Direccion, Altura, CodPostal, Poblacion, Provincia,Numero, Puerta" &
          " having count(*) > 1  order by count(*) desc "

        Dim pf As New ProgressForm(BD_CERO.Execute("select count(*) from (" & Sel.Replace(" order by count(*) desc ", "") & ") a", False) + 1, "Generando columna ContadorOrigen ...")

        Try
            BD_CERO.Execute("ALTER TABLE Inmuebles ADD ContadorOrigen INT NOT NULL default 0")
        Catch ex As Exception

        End Try
        pf.nuevoPaso()

        'BD_CERO.Execute("UPDATE Inmuebles SET ContadorOrigen = Contador ")
        'pf.nuevoPaso()

        Dim dtr1 As Object
        Dim bd1 As New BaseDatos

        dtr1 = bd1.ExecuteReader(Sel)
        If dtr1.HasRows Then
            While dtr1.Read
                Dim dtr2 As Object
                Dim bd2 As New BaseDatos

                Sel = "SELECT *  FROM " & Tabla &
                    " WHERE ContadorPropietario = " & dtr1("ContadorPropietario") &
                    " AND Tipo = '" & FuncionesGenerales.Funciones.pf_ReplaceComillas(dtr1("Tipo")) & "'" &
                    " AND Via = '" & FuncionesGenerales.Funciones.pf_ReplaceComillas(dtr1("Via")) & "'" &
                    " AND Direccion = '" & FuncionesGenerales.Funciones.pf_ReplaceComillas(dtr1("Direccion")) & "'" &
                    " AND Altura = '" & FuncionesGenerales.Funciones.pf_ReplaceComillas(dtr1("Altura")) & "'" &
                    " AND CodPostal = '" & FuncionesGenerales.Funciones.pf_ReplaceComillas(dtr1("CodPostal")) & "'" &
                    " AND Poblacion = '" & FuncionesGenerales.Funciones.pf_ReplaceComillas(dtr1("Poblacion")) & "'" &
                    " AND Provincia = '" & FuncionesGenerales.Funciones.pf_ReplaceComillas(dtr1("Provincia")) & "'" &
                    " AND Numero = '" & FuncionesGenerales.Funciones.pf_ReplaceComillas(dtr1("Numero")) & "'" &
                    " AND Puerta = '" & FuncionesGenerales.Funciones.pf_ReplaceComillas(dtr1("Puerta")) & "' ORDER BY Contador"
                dtr2 = bd2.ExecuteReader(Sel)

                Dim SoyPrimero As Boolean = True
                Dim ContadorOrigen As Integer = 0

                If dtr2.HasRows Then

                    Dim ContadorActual As Integer = 0

                    While dtr2.Read

                        If SoyPrimero Then
                            SoyPrimero = False
                            ContadorOrigen = dtr2("Contador")
                        End If
                        Sel = "UPDATE " & Tabla & " SET ContadorOrigen = " & ContadorOrigen & " WHERE Contador = " & dtr2("Contador")
                        BD_CERO.Execute(Sel)

                    End While

                End If
                dtr2.Close()
                bd2.CerrarBD()
                pf.nuevoPaso()
            End While

        End If
        dtr1.Close()
        bd1.CerrarBD()

        pf.Close()

        Me.Cursor = System.Windows.Forms.Cursors.Arrow

        MsgBox("Fin")
    End Sub


    Private Sub IActualizarWeb_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles IActualizarWeb.ItemClick
        Process.Start(clVariables.RutaServidor & "\SincronizarWeb.bat")
        MensajeInformacion(clVariables.RutaServidor & "\SincronizarWeb.bat")
        MensajeInformacion("El proceso para actualizar la web se ha iniciado correctamente")

    End Sub
    Private Sub CamiarCodigoEmpresa(NuevoCodigo As Integer)

        'El primero es el válido.

        Dim bdTablasConIdDemeter As New BaseDatos
        Dim dtTablasConIdDemeter As DataTable



        Dim Sel As String

        Sel = "SELECT SO.NAME as Tabla, SC.NAME as Columna, SC.max_length  as Tamano FROM sys.objects SO INNER JOIN sys.columns SC ON SO.OBJECT_ID = SC.OBJECT_ID WHERE SO.TYPE = 'U' and SC.name = 'CodigoEmpresa' ORDER BY SO.NAME, SC.NAME "
        bdTablasConIdDemeter.LlenarDataSet(Sel, "T")
        dtTablasConIdDemeter = bdTablasConIdDemeter.ds.Tables(0)

        For k = 0 To dtTablasConIdDemeter.Rows.Count - 1
            Sel = "UPDATE " & dtTablasConIdDemeter.Rows(k)("Tabla") & " SET CodigoEmpresa = " & NuevoCodigo
            BD_CERO.Execute(Sel)
        Next


    End Sub
#Region "WordPress"



    Private Sub btnTipoPrincipalWeb_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnTipoPrincipalWeb.ItemClick

        'Dim Sel As String

        'Sel = "insert into TipoPrincipalWeb values ('SIN CLASIFICAR', 0)"
        'BD_CERO.Execute(Sel)

        'TipoPrincipalWeb("VIVIENDAS")
        'TipoPrincipalWeb("LOCALES")
        'TipoPrincipalWeb("GARAJES")
        'TipoPrincipalWeb("TERRENOS RÚSTICOS")
        'TipoPrincipalWeb("SOLARES URBANOS")
        'TipoPrincipalWeb("NAVE INDUSTRIAL")
        'TipoPrincipalWeb("SUELO INDUSTRIAL")
        'TipoPrincipalWeb("TRASTEROS")

        ''FuncionesGenerales.FuncionesBD.SincronizarTodoLoPendienteConLaWeb()



        Dim Sel As String

        Sel = "SELECT * FROM TipoPrincipalWeb WHERE Id_WP = 0"
        Dim bdT As New BaseDatos
        bdT.LlenarDataSet(Sel, "T")

        For i = 0 To bdT.ds.Tables("T").Rows.Count - 1
            TipoPrincipalWeb(bdT.ds.Tables("T").Rows(i)("TipoPrincipal"))
        Next

        MensajeInformacion("FIN")


    End Sub
    Private Sub TipoPrincipalWeb(Valor As String)


        Dim Sel As String




        Dim Res2 As New Tablas.clWPCreado
        Dim Res As Tablas.clResultado

        GL_TokenWP = ObtenerTokenWP()


        Dim dato As Tablas.clNombre
        Dim postData As String = ""

        dato = New Tablas.clNombre(StrConv(Valor, VbStrConv.ProperCase))
        postData = SerializarPost(dato)

        Dim Funcion As String = ""
        Funcion = GL_ConfiguracionWeb.API_WP_Funcion_Tipos


        Res = WordPressPost(Funcion, postData)

        Dim Id_WP As Integer

        Res2 = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Tablas.clWPCreado)(Res.Mensaje)
        Id_WP = Res2.id


        Sel = "UPDATE TipoPrincipalWeb SET Id_WP = " & Id_WP & " WHERE TipoPrincipal = '" & Funciones.pf_ReplaceComillas(Valor) & "'"
        BD_CERO.Execute(Sel)

        'Sel = "insert into TipoPrincipalWeb values ('" & Funciones.pf_ReplaceComillas(Valor) & "', " & Id_WP & ")"
        'BD_CERO.Execute(Sel)



    End Sub


    Private Sub TipoSecundarioWeb(Valor As String, TipoPrincipal As String)


        Dim Sel As String




        Dim Res2 As Tablas.clWPCreado
        Dim Res As Tablas.clResultado

        GL_TokenWP = ObtenerTokenWP()

        Sel = "SELECT Id_WP FROM TipoPrincipalWeb WHERE TipoPrincipal = '" & pf_ReplaceComillas(TipoPrincipal) & "'"
        Dim IdParent As Integer = BD_CERO.Execute(Sel, False, 0)

        If IdParent <> 0 Then



            Dim dato As Tablas.clNombre
            Dim postData As String

            dato = New Tablas.clNombre(StrConv(Valor, VbStrConv.ProperCase), IdParent)
            postData = SerializarPost(dato)

            'dato = New Tablas.clNombre(StrConv(Valor, VbStrConv.ProperCase))
            'postData = SerializarPost(dato)

            Dim Funcion As String = ""
            Funcion = GL_ConfiguracionWeb.API_WP_Funcion_Tipos


            Res = WordPressPost(Funcion, postData)

            Dim Id_WP As Integer

            Res2 = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Tablas.clWPCreado)(Res.Mensaje)
            Id_WP = Res2.id

            Sel = "UPDATE TipoSecundarioWeb SET Id_WP = " & Id_WP & " WHERE TipoPrincipal = '" & Funciones.pf_ReplaceComillas(TipoPrincipal) & "' AND TipoSecundario = '" & Funciones.pf_ReplaceComillas(Valor) & "'"
            BD_CERO.Execute(Sel)

            'Sel = "insert into TipoSecundarioWeb values ('" & Funciones.pf_ReplaceComillas(TipoPrincipal) & "', '" & Funciones.pf_ReplaceComillas(Valor) & "', " & Id_WP & ")"
            'BD_CERO.Execute(Sel)

        End If



    End Sub
    Private Function TipoTerciarioWeb(Valor As String, IdParent As Integer) As Integer


        Dim Sel As String




        Dim Res2 As Tablas.clWPCreado
        Dim Res As Tablas.clResultado

        GL_TokenWP = ObtenerTokenWP()


        Dim dato As Tablas.clNombre
        Dim postData As String

        dato = New Tablas.clNombre(StrConv(Valor, VbStrConv.ProperCase), IdParent)
        postData = SerializarPost(dato)

        'dato = New Tablas.clNombre(StrConv(Valor, VbStrConv.ProperCase))
        'postData = SerializarPost(dato)

        Dim Funcion As String = ""
        Funcion = GL_ConfiguracionWeb.API_WP_Funcion_Tipos


        Res = WordPressPost(Funcion, postData)

        Dim Id_WP As Integer

        Res2 = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Tablas.clWPCreado)(Res.Mensaje)
        Id_WP = Res2.id

        Return Id_WP
        'Sel = "UPDATE TipoSecundarioWeb SET Id_WP = " & Id_WP & " WHERE TipoPrincipal = '" & Funciones.pf_ReplaceComillas(TipoPrincipal) & "' AND TipoSecundario = '" & Funciones.pf_ReplaceComillas(Valor) & "'"
        'BD_CERO.Execute(Sel)

        'Sel = "insert into TipoSecundarioWeb values ('" & Funciones.pf_ReplaceComillas(TipoPrincipal) & "', '" & Funciones.pf_ReplaceComillas(Valor) & "', " & Id_WP & ")"
        'BD_CERO.Execute(Sel)




    End Function
    Private Sub Poblaciones(Valor As String)


        Dim IdParent As Integer = 0
        Dim Sel As String

        Dim Res2 As Tablas.clWPCreado
        Dim Res As Tablas.clResultado

        GL_TokenWP = ObtenerTokenWP()


        Dim dato As Tablas.clNombre
        Dim postData As String

        dato = New Tablas.clNombre(StrConv(Valor, VbStrConv.ProperCase), IdParent)
        postData = SerializarPost(dato)

        'dato = New Tablas.clNombre(StrConv(Valor, VbStrConv.ProperCase))
        'postData = SerializarPost(dato)

        Dim Funcion As String = ""
        Funcion = GL_ConfiguracionWeb.API_WP_Funcion_Poblacion


        Res = WordPressPost(Funcion, postData)

        Dim Id_WP As Integer

        Res2 = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Tablas.clWPCreado)(Res.Mensaje)
        Id_WP = Res2.id

        Sel = "UPDATE Poblacion SET Id_WP = " & Id_WP & " WHERE Poblacion = '" & Funciones.pf_ReplaceComillas(Valor) & "'"
        BD_CERO.Execute(Sel)




    End Sub

    Private Sub btnWPSubirTodasLasFOTOS_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnWPSubirTodasLasFOTOS.ItemClick

        If MsgBox("¿Confirma que quiere subir todas las fotos a WP?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Return
        End If


        'AsignarPrincipal()

        ArreglarFotos2()


        'MsgBox("Fin")
    End Sub
    'Private Sub Empre()
    '    Dim ApiCredentials As New Tablas.ApiCredentials
    '    Dim client = New WordPressClient(ApiCredentials.WordPressUri)
    '    client.AuthMethod = AuthMethod.JWT
    '    client.RequestJWToken(ApiCredentials.Username, ApiCredentials.Password)
    '    Dim isValidToken = client.IsValidJWToken()
    '    Dim Post = client.Posts.GetAll()
    'End Sub
    Private Async Sub ArreglarFotos2()

        Dim Sel As String


        Dim CarpetaDocumento As String

        CarpetaDocumento = "C:\Compartida\Venalia2\Fotos\" & DatosEmpresa.Codigo


        'Dim by As Byte() = IO.File.ReadAllBytes("C:\Compartida\Jose\admin.png")

        'Dim strBy As String

        'For i = 0 To by.Count - 1
        '    strBy = strBy & "," & by(i)
        'Next
        'strBy = strBy.Substring(1)

        'Dim Fichero As String = "C:\Compartida\Venalia2\Fotos\2\27189\1.jpg"
        'Dim postData As String
        ''postData = SerializarPost("file:///C:/Compartida/Venalia2/Fotos/2/27189/1.jpg", "source_url")
        ''WordPressPost("media", postData, False)


        'Dim dato As Tablas.clNuevaImagen
        'dato = New Tablas.clNuevaImagen
        'dato.data = strBy
        'dato.source_url = "file:///C:/Compartida/Venalia2/Fotos/2/27189/1.jpg"
        'postData = SerializarPost(dato)
        'WordPressPost("media", postData, False)




        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 Or System.Net.SecurityProtocolType.Tls11 Or System.Net.SecurityProtocolType.Tls
        Dim ApiCredentials As New Tablas.ApiCredentials
        Dim client = New WordPressClient(ApiCredentials.WordPressUri)
        client.AuthMethod = AuthMethod.JWT
        Await client.RequestJWToken(ApiCredentials.Username, ApiCredentials.Password)
        Dim isValidToken = Await client.IsValidJWToken()





        Sel = "SELECT Contador, Referencia, Id_WP,FotoPrincipal FROM Inmuebles WHERE Id_WP <> 0 AND Baja = 0 and fotosweb > 0 and FotoPrincipal <> '' and Contador not in (  Select DISTINCT ContadorInmueble  from WP_FOTOS   WHERE AsignadoAWeb = 1) " &
            " and contador = 11737  ORDER BY Referencia DESC"

        Dim bdFotos As New BaseDatos
        Dim dtFotos As DataTable
        Dim aff As Integer
        bdFotos.LlenarDataSet(Sel, "T")
        dtFotos = bdFotos.ds.Tables("T")


        For i = 0 To dtFotos.Rows.Count - 1

            Try



                Dim CarpetaFotos As String

                Dim Id_WP As String = dtFotos(i)("Id_WP")
                Dim ContadorInmueble As String = dtFotos(i)("Contador")
                Dim Referencia As String = dtFotos(i)("Referencia")
                Dim FotoPrincipal As String = dtFotos(i)("FotoPrincipal")
                Dim CuantasSubidas As Integer = 0
                'FotoPrincipal = "C:\Compartida\Venalia2\Fotos\2/27141/ActualizarWeb\febc390f4e8943eba2f52aebd26189ff.jpg"

                CarpetaFotos = CarpetaDocumento & "/" & dtFotos(i)("Referencia") & "/ActualizarWeb"
                If Not System.IO.Directory.Exists(CarpetaFotos) Then
                    FotoPrincipal = ""
                    Sel = "UPDATE Inmuebles SET FotosWeb = " & CuantasSubidas & " WHERE Contador = " & ContadorInmueble
                    aff = BD_CERO.Execute(Sel)
                    Continue For
                End If


                Dim ListaFotos As String() = System.IO.Directory.GetFiles(CarpetaFotos, "*.jpg")
                If ListaFotos.Count = 0 Then
                    FotoPrincipal = ""
                    Sel = "UPDATE Inmuebles SET FotosWeb = " & CuantasSubidas & " WHERE Contador = " & ContadorInmueble
                    aff = BD_CERO.Execute(Sel)
                    Continue For
                End If



                CuantasSubidas = ListaFotos.Count

                'FotoPrincipal = "C:\Compartida\Venalia2\Fotos\2/26920/ActualizarWeb\1.jpg"
                Sel = "UPDATE Inmuebles SET FotosWeb = " & CuantasSubidas & " , fotoprincipal='" & FotoPrincipal & "' WHERE Contador = " & ContadorInmueble
                aff = BD_CERO.Execute(Sel)

                Dim TengoPrincipal As Boolean = False

                For k = 0 To ListaFotos.Count - 1
                    Dim RutaImagen As String
                    RutaImagen = ListaFotos(k)

                    Try
                        If My.Computer.FileSystem.GetName(RutaImagen) <> FotoPrincipal Then
                            Continue For
                        End If

                        TengoPrincipal = True

                        Dim s As Stream = File.OpenRead(RutaImagen)
                        Dim createdMedia = Await client.Media.Create(s, "media.jpg")

                        Dim IdWPFotoPrincipal As Integer = 0
                        IdWPFotoPrincipal = createdMedia.Id
                        AsignarMediaAInmueble(Id_WP, createdMedia.Id, Referencia, ContadorInmueble, RutaImagen, IIf(My.Computer.FileSystem.GetName(RutaImagen) = FotoPrincipal, True, False), IdWPFotoPrincipal)
                    Catch ex As Exception
                        EscribeLog("Error fotos. Contado: " & dtFotos(i)("Contador") & "-" & ex.Message)
                    End Try


                Next

                If TengoPrincipal Then
                    Dim LisaImas As New List(Of Integer)
                    Sel = "SELECT * FROM WP_FOTOS WHERE ContadorInmueble = " & ContadorInmueble
                    Dim bdConta As New BaseDatos
                    bdConta.LlenarDataSet(Sel, "T")
                    For k = 0 To bdConta.ds.Tables("T").Rows.Count - 1
                        LisaImas.Add(bdConta.ds.Tables("T").Rows(k)("IdFoto"))
                    Next

                    Dim postData As String

                    postData = SerializarPost(LisaImas, "REAL_HOMES_property_images")
                    WordPressPost(GL_ConfiguracionWeb.API_WP_Funcion_Propiedades & "/" & Id_WP, postData, False,, False)
                End If



            Catch ex As Exception
                EscribeLog("Error fotos. Contado: " & dtFotos(i)("Contador") & "-" & ex.Message)
            End Try
        Next




        'Dim Id_WP_Id__Foto As Integer
        'Sel = "SELECT IdFoto FROM WP_FOTOS WHERE IdProperty = " & Id_WP & " And Fichero = '" & Funciones.pf_ReplaceComillas(FotoPrincipal) & " '"
        'Id_WP_Id__Foto = BD_CERO.Execute(Sel, False)

        'If Id_WP_Id__Foto <> 0 Then

        '    Dim postData As String
        '    postData = SerializarPost(Id_WP_Id__Foto, "featured_media")
        '    WordPressPost(GL_ConfiguracionWeb.API_WP_Funcion_Propiedades & "/" & Id_WP, postData)

        '    Sel = "UPDATE WP_FOTOS SET Principal = 0 WHERE IdProperty = " & Id_WP & " AND IdFoto <> " & Id_WP_Id__Foto
        '    BD_CERO.Execute(Sel)

        '    Sel = "UPDATE WP_FOTOS SET Principal = 1 WHERE IdProperty = " & Id_WP & " AND IdFoto = " & Id_WP_Id__Foto
        '    BD_CERO.Execute(Sel)

        'End If


        'WPActualizarREAL_HOMES_property_images(Id_WP)






        MsgBox("Fin")


        Return
        'Dim client = New WordPressClient(GL_ConfiguracionWeb.API_WP.Replace("wp/v2/", ""))
        'Dim posts = Await client.Posts.GetAll()
        'Dim postbyid = Await client.Posts.GetByID(id)
        'Dim comments = Await client.Comments.GetAll()
        'Dim commentbyid = Await client.Comments.GetByID(id)
        'Dim commentsbypost = Await client.Comments.GetCommentsForPost(postid, True, False)
        '    Dim ApiCredentials As New Tablas.ApiCredentials
        '    Dim client = New WordPressClient(ApiCredentials.WordPressUri)
        '    client.AuthMethod = AuthMethod.JWT
        '    Await client.RequestJWToken(ApiCredentials.Username, ApiCredentials.Password)
        '    Dim isValidToken = Await client.IsValidJWToken()

        '    Dim s As Stream = File.OpenRead("D:\EnDesarrolloEntregados\Venalia\Programa\Inmobiliaria\bin\Debug\Fotos\4\16600330\11100734_1.jpg")

        '    Dim createdMedia = Await client.Media.Create(s, "media.jpg")

        '    Dim p As New WordPressPCL.Models.Page
        '    p.Parent = 3908

        '    Dim posts = Await client.Posts.GetAll()
        '    'Dim response = client.Posts.Delete(postid)
        '    Dim postbyid = Await client.Posts.GetByID(3908)
    End Sub
    Private Async Sub SubirFotos2()

        Dim Sel As String


        Dim CarpetaDocumento As String

        CarpetaDocumento = "C:\Compartida\Venalia2\Fotos\" & DatosEmpresa.Codigo


        'Dim by As Byte() = IO.File.ReadAllBytes("C:\Compartida\Jose\admin.png")

        'Dim strBy As String

        'For i = 0 To by.Count - 1
        '    strBy = strBy & "," & by(i)
        'Next
        'strBy = strBy.Substring(1)

        'Dim Fichero As String = "C:\Compartida\Venalia2\Fotos\2\27189\1.jpg"
        'Dim postData As String
        ''postData = SerializarPost("file:///C:/Compartida/Venalia2/Fotos/2/27189/1.jpg", "source_url")
        ''WordPressPost("media", postData, False)


        'Dim dato As Tablas.clNuevaImagen
        'dato = New Tablas.clNuevaImagen
        'dato.data = strBy
        'dato.source_url = "file:///C:/Compartida/Venalia2/Fotos/2/27189/1.jpg"
        'postData = SerializarPost(dato)
        'WordPressPost("media", postData, False)




        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 Or System.Net.SecurityProtocolType.Tls11 Or System.Net.SecurityProtocolType.Tls
        Dim ApiCredentials As New Tablas.ApiCredentials
        Dim client = New WordPressClient(ApiCredentials.WordPressUri)
        client.AuthMethod = AuthMethod.JWT
        Await client.RequestJWToken(ApiCredentials.Username, ApiCredentials.Password)
        Dim isValidToken = Await client.IsValidJWToken()





        Sel = "SELECT Contador, Referencia, Id_WP,FotoPrincipal FROM Inmuebles WHERE Id_WP <> 0 AND Baja = 0 and fotosweb > 0 and Contador not in (Select contadorinmueble from WP_FOTOS ) and reservado = 0 ORDER BY Referencia DESC"

        'Sel = "SELECT Contador, Referencia, Id_WP,FotoPrincipal FROM Inmuebles WHERE Id_WP <> 0 AND Baja = 0 and FotoPrincipal = '' ORDER BY Referencia DESC"

        'Sel = "SELECT * FROM WP_FOTOS m where Principal = 1"

        Dim bdFotos As New BaseDatos
        Dim dtFotos As DataTable
        Dim aff As Integer
        bdFotos.LlenarDataSet(Sel, "T")
        dtFotos = bdFotos.ds.Tables("T")


        For i = 0 To dtFotos.Rows.Count - 1

            Try



                Dim CarpetaFotos As String

                Dim Id_WP As String = dtFotos(i)("Id_WP")
                Dim ContadorInmueble As String = dtFotos(i)("Contador")
                Dim Referencia As String = dtFotos(i)("Referencia")
                Dim FotoPrincipal As String = dtFotos(i)("FotoPrincipal")
                Dim CuantasSubidas As Integer = 0
                'FotoPrincipal = "C:\Compartida\Venalia2\Fotos\2/27141/ActualizarWeb\febc390f4e8943eba2f52aebd26189ff.jpg"

                CarpetaFotos = CarpetaDocumento & "/" & dtFotos(i)("Referencia") & "/ActualizarWeb"
                If Not System.IO.Directory.Exists(CarpetaFotos) Then
                    FotoPrincipal = ""
                    Sel = "UPDATE Inmuebles SET FotosWeb = " & CuantasSubidas & " WHERE Contador = " & ContadorInmueble
                    aff = BD_CERO.Execute(Sel)
                    Continue For
                End If


                Dim ListaFotos As String() = System.IO.Directory.GetFiles(CarpetaFotos, "*.jpg")
                If ListaFotos.Count = 0 Then
                    FotoPrincipal = ""
                    Sel = "UPDATE Inmuebles SET FotosWeb = " & CuantasSubidas & " WHERE Contador = " & ContadorInmueble
                    aff = BD_CERO.Execute(Sel)
                    Continue For
                End If


                If FotoPrincipal = "" Then
                    FotoPrincipal = ListaFotos(0)
                    FotoPrincipal = My.Computer.FileSystem.GetName(FotoPrincipal)
                    FotoPrincipal = Replace(FotoPrincipal, "'", "")
                End If

                CuantasSubidas = ListaFotos.Count

                'FotoPrincipal = "C:\Compartida\Venalia2\Fotos\2/26920/ActualizarWeb\1.jpg"
                Sel = "UPDATE Inmuebles SET FotosWeb = " & CuantasSubidas & " , fotoprincipal='" & FotoPrincipal & "' WHERE Contador = " & ContadorInmueble
                aff = BD_CERO.Execute(Sel)


                For k = 0 To ListaFotos.Count - 1
                    Dim RutaImagen As String
                    RutaImagen = ListaFotos(k)

                    Try
                        Dim s As Stream = File.OpenRead(RutaImagen)
                        Dim createdMedia = Await client.Media.Create(s, "media.jpg")

                        Dim IdWPFotoPrincipal As Integer = 0
                        If My.Computer.FileSystem.GetName(RutaImagen) = FotoPrincipal Then
                            IdWPFotoPrincipal = createdMedia.Id
                        End If
                        AsignarMediaAInmueble(Id_WP, createdMedia.Id, Referencia, ContadorInmueble, RutaImagen, IIf(My.Computer.FileSystem.GetName(RutaImagen) = FotoPrincipal, True, False), IdWPFotoPrincipal)
                    Catch ex As Exception
                        EscribeLog("Error fotos. Contado: " & dtFotos(i)("Contador") & "-" & ex.Message)
                    End Try


                Next

                Dim LisaImas As New List(Of Integer)
                Sel = "SELECT * FROM WP_FOTOS WHERE ContadorInmueble = " & ContadorInmueble
                Dim bdConta As New BaseDatos
                bdConta.LlenarDataSet(Sel, "T")
                For k = 0 To bdConta.ds.Tables("T").Rows.Count - 1
                    LisaImas.Add(bdConta.ds.Tables("T").Rows(k)("IdFoto"))
                Next

                Dim postData As String

                postData = SerializarPost(LisaImas, "REAL_HOMES_property_images")
                WordPressPost(GL_ConfiguracionWeb.API_WP_Funcion_Propiedades & "/" & Id_WP, postData, False,, False)


            Catch ex As Exception
                EscribeLog("Error fotos. Contado: " & dtFotos(i)("Contador") & "-" & ex.Message)
            End Try
        Next




        'Dim Id_WP_Id__Foto As Integer
        'Sel = "SELECT IdFoto FROM WP_FOTOS WHERE IdProperty = " & Id_WP & " And Fichero = '" & Funciones.pf_ReplaceComillas(FotoPrincipal) & " '"
        'Id_WP_Id__Foto = BD_CERO.Execute(Sel, False)

        'If Id_WP_Id__Foto <> 0 Then

        '    Dim postData As String
        '    postData = SerializarPost(Id_WP_Id__Foto, "featured_media")
        '    WordPressPost(GL_ConfiguracionWeb.API_WP_Funcion_Propiedades & "/" & Id_WP, postData)

        '    Sel = "UPDATE WP_FOTOS SET Principal = 0 WHERE IdProperty = " & Id_WP & " AND IdFoto <> " & Id_WP_Id__Foto
        '    BD_CERO.Execute(Sel)

        '    Sel = "UPDATE WP_FOTOS SET Principal = 1 WHERE IdProperty = " & Id_WP & " AND IdFoto = " & Id_WP_Id__Foto
        '    BD_CERO.Execute(Sel)

        'End If


        'WPActualizarREAL_HOMES_property_images(Id_WP)






        MsgBox("Fin")


        Return
        'Dim client = New WordPressClient(GL_ConfiguracionWeb.API_WP.Replace("wp/v2/", ""))
        'Dim posts = Await client.Posts.GetAll()
        'Dim postbyid = Await client.Posts.GetByID(id)
        'Dim comments = Await client.Comments.GetAll()
        'Dim commentbyid = Await client.Comments.GetByID(id)
        'Dim commentsbypost = Await client.Comments.GetCommentsForPost(postid, True, False)
        '    Dim ApiCredentials As New Tablas.ApiCredentials
        '    Dim client = New WordPressClient(ApiCredentials.WordPressUri)
        '    client.AuthMethod = AuthMethod.JWT
        '    Await client.RequestJWToken(ApiCredentials.Username, ApiCredentials.Password)
        '    Dim isValidToken = Await client.IsValidJWToken()

        '    Dim s As Stream = File.OpenRead("D:\EnDesarrolloEntregados\Venalia\Programa\Inmobiliaria\bin\Debug\Fotos\4\16600330\11100734_1.jpg")

        '    Dim createdMedia = Await client.Media.Create(s, "media.jpg")

        '    Dim p As New WordPressPCL.Models.Page
        '    p.Parent = 3908

        '    Dim posts = Await client.Posts.GetAll()
        '    'Dim response = client.Posts.Delete(postid)
        '    Dim postbyid = Await client.Posts.GetByID(3908)
    End Sub

    Private Sub AsignarPrincipal()

        Dim Sel As String


        GL_TokenWP = ObtenerTokenWP()

        Sel = "SELECT * FROM WP_FOTOS m where Principal = 1 AND AsignadoAWeb = 0"

        Dim bdFotos As New BaseDatos
        Dim dtFotos As DataTable
        bdFotos.LlenarDataSet(Sel, "T")
        dtFotos = bdFotos.ds.Tables("T")


        For i = 0 To dtFotos.Rows.Count - 1

            Dim postData As String
            postData = SerializarPost(dtFotos(i)("IdFoto"), "featured_media")
            WordPressPost(GL_ConfiguracionWeb.API_WP_Funcion_Propiedades & "/" & dtFotos(i)("IdProperty"), postData,,, False)

            Sel = "UPDATE WP_FOTOS SET AsignadoAWeb = 1 WHERE IdFoto = " & dtFotos(i)("IdFoto")
            BD_CERO.Execute(Sel)

        Next



    End Sub
    Public Sub AsignarMediaAInmueble(Id_WP_Inmueble As Integer, Id_WP_Foto As Integer, Referencia As String, ContadorInmueble As Integer, RutaImagen As String, SoyFotoPrincipal As Boolean, Id_WP_FotoPrincipal As Integer)

        Dim Sel As String
        ''Dim client = New WordPressClient(GL_ConfiguracionWeb.API_WP.Replace("wp/v2/", ""))
        ''Dim posts = Await client.Posts.GetAll()
        ''Dim postbyid = Await client.Posts.GetByID(id)
        ''Dim comments = Await client.Comments.GetAll()
        ''Dim commentbyid = Await client.Comments.GetByID(id)
        ''Dim commentsbypost = Await client.Comments.GetCommentsForPost(postid, True, False)
        'System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 Or System.Net.SecurityProtocolType.Tls11 Or System.Net.SecurityProtocolType.Tls
        'Dim Sel As String
        'Sel = "SELECT Referencia FROM Inmuebles WHERE Contador = " & ContadorInmueble
        'Dim Referencia As String = BD_CERO.Execute(Sel, False, "")

        'Dim ApiCredentials As New Tablas.ApiCredentials
        'Dim client = New WordPressClient(ApiCredentials.WordPressUri)
        'client.AuthMethod = AuthMethod.JWT
        'Await client.RequestJWToken(ApiCredentials.Username, ApiCredentials.Password)
        'Dim isValidToken = Await client.IsValidJWToken()

        ''RutaImagen = "D:\EnDesarrolloEntregados\Venalia\Programa\Inmobiliaria\bin\Debug\Fotos\4\16600330\11100734_1.jpg"
        'Dim s As Stream = File.OpenRead(RutaImagen)

        'Dim createdMedia = Await client.Media.Create(s, "media.jpg")

        If IsNothing(GL_TokenWP) OrElse GL_TokenWP = "" Then
            GL_TokenWP = ObtenerTokenWP()
        End If


        Dim postData As String


        Dim Res As Tablas.clResultado
        Dim ResImagen As Tablas.cl_WP_Media
        Dim SourceURL As String = ""

        postData = SerializarPost(Id_WP_Inmueble, "post")
        Res = WordPressPost("media/" & Id_WP_Foto, postData, ,, False)

        If Res.Codigo = 0 Then
            ResImagen = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Tablas.cl_WP_Media)(Res.Mensaje)
            SourceURL = ResImagen.source_url

        Else


            InsertarMovimientosWP(Referencia, "INSERTAR FOTO", Res.Codigo, "ERROR", Res.Mensaje)
        End If


        postData = SerializarPost(Id_WP_Foto, "REAL_HOMES_property_images")
        WordPressPost(GL_ConfiguracionWeb.API_WP_Funcion_Propiedades & "/" & Id_WP_Inmueble, postData, False,, False)
        'Id_WP_FotoPrincipal = 11230
        'If Id_WP_FotoPrincipal <> 0 Then
        '    postData = SerializarPost(Id_WP_FotoPrincipal, "featured_media")
        '    WordPressPost(GL_ConfiguracionWeb.API_WP_Funcion_Propiedades & "/" & Id_WP_Inmueble, postData, False,, False)
        'End If




        Sel = "INSERT INTO WP_FOTOS (IdFoto, IdProperty, ContadorInmueble,Fichero,Principal,SourceURL,AsignadoAWeb) VALUES ( " &
              Id_WP_Foto &
              ", " & Id_WP_Inmueble &
              ", " & ContadorInmueble &
              ", '" & My.Computer.FileSystem.GetName(RutaImagen) & "'" &
              ",0 " &
              ", '" & SourceURL & "'" &
              ",0" &
              ")"

        BD_CERO.Execute(Sel)


        InsertarMovimientosWP(Referencia, "INSERTAR FOTO", Res.Codigo, "", "Id Foto: " & Id_WP_Foto)


        If SoyFotoPrincipal Then
            postData = SerializarPost(Id_WP_Foto, "featured_media")
            WordPressPost(GL_ConfiguracionWeb.API_WP_Funcion_Propiedades & "/" & Id_WP_Inmueble, postData)

            Sel = "UPDATE WP_FOTOS SET Principal = 1,AsignadoAWeb = 1 WHERE IdProperty = " & Id_WP_Inmueble & " AND IdFoto = " & Id_WP_Foto
            BD_CERO.Execute(Sel)
        End If



    End Sub




    Private Sub btnTipoSecundarioWeb_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnTipoSecundarioWeb.ItemClick

        Dim Sel As String

        Sel = "SELECT * FROM TipoSecundarioWeb WHERE Id_WP = 0"
        Dim bdT As New BaseDatos
        bdT.LlenarDataSet(Sel, "T")

        For i = 0 To bdT.ds.Tables("T").Rows.Count - 1
            TipoSecundarioWeb(bdT.ds.Tables("T").Rows(i)("TipoSecundario"), bdT.ds.Tables("T").Rows(i)("TipoPrincipal"))
        Next

        MensajeInformacion("FIN")

        'TipoSecundarioWeb("Pisos/Áticos", "VIVIENDAS")
        'TipoSecundarioWeb("Casas", "VIVIENDAS")
        'TipoSecundarioWeb("Despachos", "LOCALES")
        'TipoSecundarioWeb("Locales", "LOCALES")



    End Sub

    Private Sub btnTipos_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnTipos.ItemClick
        ActualizarTipos()
    End Sub
    Private Sub ActualizarTipos()

        Dim Sel As String

        Sel = "SELECT * FROM Tipo WHERE ID_WP = 0"
        Dim bdT As New BaseDatos
        bdT.LlenarDataSet(Sel, "T")

        'Dim IdTipo As Integer

        For i = 0 To bdT.ds.Tables("T").Rows.Count - 1



            Dim Tipo As String = bdT.ds.Tables("T").Rows(i)("Tipo")
            Dim TipoPrimario As String = DevolverTipoPrincipal(Tipo)
            Dim TipoSecundario As String = DevolverTipoSecundario(Tipo)
            Dim TipoTerciario As String = DevolverTipoTerciario(Tipo)
            Dim ID_WP As Integer

            ID_WP = DevolverID_WP_TipoNuevo(TipoTerciario)

            If ID_WP = 0 Then
                If IsNothing(TipoPrimario) Then
                    Continue For
                End If
                If TipoPrimario.ToUpper.Trim() = TipoTerciario.ToUpper.Trim() Then
                    Sel = "SELECT ID_WP FROM TipoPrincipalWeb WHERE TipoPrincipal ='" & pf_ReplaceComillas(TipoPrimario) & "'"
                    ID_WP = BD_CERO.Execute(Sel, False)
                Else
                    If TipoSecundario.ToUpper.Trim() = TipoTerciario.ToUpper.Trim() Then
                        Sel = "SELECT ID_WP FROM TipoSecundarioWeb WHERE TipoPrincipal ='" & pf_ReplaceComillas(TipoSecundario) & "'"
                        ID_WP = BD_CERO.Execute(Sel, False)
                    End If
                End If
                If ID_WP = 0 Then
                    Dim Id_WP_Parent As Integer
                    Sel = "SELECT ID_WP FROM TipoSecundarioWeb WHERE TipoSecundario ='" & pf_ReplaceComillas(TipoSecundario) & "'"
                    Id_WP_Parent = BD_CERO.Execute(Sel, False)
                    ID_WP = TipoTerciarioWeb(TipoTerciario, Id_WP_Parent)
                End If

                Sel = "UPDATE correspondenciatipos SET Id_WP = " & ID_WP & " WHERE TipoOriginal = '" & pf_ReplaceComillas(Tipo) & "'"
                BD_CERO.Execute(Sel)
            End If



            Sel = "UPDATE Tipo SET Id_WP = " & ID_WP & " WHERE Tipo = '" & pf_ReplaceComillas(Tipo) & "'"
            BD_CERO.Execute(Sel)

        Next

        MensajeInformacion("FIN")



    End Sub
    Private Function DevolverTipoPrincipal(ByVal TipoOriginal As String) As String

        Dim bd As New BaseDatos()
        Return bd.Execute("SELECT TipoPrincipal FROM correspondenciatipos WHERE TipoOriginal = '" & pf_ReplaceComillas(TipoOriginal) & "'", False)

    End Function
    Private Function DevolverTipoSecundario(ByVal TipoOriginal As String) As String

        Dim bd As New BaseDatos()
        Return bd.Execute("SELECT TipoSecundario FROM correspondenciatipos WHERE TipoOriginal = '" & pf_ReplaceComillas(TipoOriginal) & "'", False)

    End Function
    Private Function DevolverID_WP_TipoNuevo(ByVal TipoNuevo As String) As Integer

        Dim bd As New BaseDatos()
        Return bd.Execute("SELECT ID_WP FROM correspondenciatipos WHERE TipoNuevo = '" & pf_ReplaceComillas(TipoNuevo) & "'", False)

    End Function
    Private Function DevolverID_WP_TipoTerciario(ByVal TipoOriginal As String) As Integer

        Dim bd As New BaseDatos()
        Return bd.Execute("SELECT ID_WP FROM correspondenciatipos WHERE TipoOriginal = '" & pf_ReplaceComillas(TipoOriginal) & "'", False)

    End Function
    Private Function DevolverTipoTerciario(ByVal TipoOriginal As String) As String

        Dim bd As New BaseDatos()
        Return bd.Execute("SELECT TipoNuevo FROM correspondenciatipos WHERE TipoOriginal = '" & pf_ReplaceComillas(TipoOriginal) & "'", False)

    End Function


    Private Sub btnTipoVenta_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnTipoVenta.ItemClick
        Dim Sel As String

        Sel = "SELECT * FROM TipoVenta WHERE Id_WP = 0"
        Dim bdT As New BaseDatos
        bdT.LlenarDataSet(Sel, "T")

        For i = 0 To bdT.ds.Tables("T").Rows.Count - 1
            WP_TipoVenta(bdT.ds.Tables("T").Rows(i)("TipoVenta"))
        Next

        MensajeInformacion("FIN")
    End Sub

    Private Sub WP_TipoVenta(Valor As String)


        Dim Sel As String




        Dim Res2 As Tablas.clWPCreado
        Dim Res As Tablas.clResultado

        GL_TokenWP = ObtenerTokenWP()




        Dim dato As Tablas.clNombre
        Dim postData As String



        dato = New Tablas.clNombre(StrConv(Valor, VbStrConv.ProperCase))
        postData = SerializarPost(dato)

        Dim Funcion As String = ""
        Funcion = GL_ConfiguracionWeb.API_WP_Funcion_TipoVentas


        Res = WordPressPost(Funcion, postData)

        Dim Id_WP As Integer

        Res2 = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Tablas.clWPCreado)(Res.Mensaje)
        Id_WP = Res2.id

        Sel = "UPDATE TipoVenta SET Id_WP = " & Id_WP & " WHERE  TipoVenta = '" & Funciones.pf_ReplaceComillas(Valor) & "'"
        BD_CERO.Execute(Sel)

        'Sel = "insert into TipoSecundarioWeb values ('" & Funciones.pf_ReplaceComillas(TipoPrincipal) & "', '" & Funciones.pf_ReplaceComillas(Valor) & "', " & Id_WP & ")"
        'BD_CERO.Execute(Sel)





    End Sub

    Private Sub btnWP_Otros_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnWP_Otros.ItemClick
        Dim Sel As String

        Sel = "SELECT * FROM WP_OtrosCampos WHERE Id_WP = 0"
        Dim bdT As New BaseDatos
        bdT.LlenarDataSet(Sel, "T")

        For i = 0 To bdT.ds.Tables("T").Rows.Count - 1
            WP_Otros(bdT.ds.Tables("T").Rows(i)("Campo"))
        Next

        MensajeInformacion("FIN")
    End Sub

    Private Sub WP_Otros(Valor As String)


        Dim Sel As String




        Dim Res2 As Tablas.clWPCreado
        Dim Res As Tablas.clResultado

        GL_TokenWP = ObtenerTokenWP()

        Dim IdParent As Integer

        Select Case Valor
            Case "ALQUILER OPCIÓN COMPRA"
                Sel = "SELECT Id_WP FROM TipoVenta WHERE TipoVenta = 'ALQUILER'"
                IdParent = BD_CERO.Execute(Sel, False, 0)
        End Select



        If IdParent <> 0 Then



            Dim dato As Tablas.clNombre
            Dim postData As String

            dato = New Tablas.clNombre(StrConv(Valor, VbStrConv.ProperCase), IdParent)
            postData = SerializarPost(dato)

            'dato = New Tablas.clNombre(StrConv(Valor, VbStrConv.ProperCase))
            'postData = SerializarPost(dato)

            Dim Funcion As String = ""
            Funcion = GL_ConfiguracionWeb.API_WP_Funcion_TipoVentas


            Res = WordPressPost(Funcion, postData)

            Dim Id_WP As Integer

            Res2 = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Tablas.clWPCreado)(Res.Mensaje)
            Id_WP = Res2.id

            Sel = "UPDATE WP_OtrosCampos SET Id_WP = " & Id_WP & " WHERE Campo = '" & Funciones.pf_ReplaceComillas(Valor) & "'"
            BD_CERO.Execute(Sel)

            'Sel = "insert into TipoSecundarioWeb values ('" & Funciones.pf_ReplaceComillas(TipoPrincipal) & "', '" & Funciones.pf_ReplaceComillas(Valor) & "', " & Id_WP & ")"
            'BD_CERO.Execute(Sel)

        End If



    End Sub

    Private Sub btnWP_Poblaciones_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnWP_Poblaciones.ItemClick
        Dim Sel As String

        Sel = "  SELECT DISTINCT (I.Poblacion) AS Pob FROM Inmuebles I INNER JOIN Poblacion P ON P.Poblacion = I.Poblacion  WHERE I.CodigoEmpresa  = " & DatosEmpresa.Codigo & " AND I.Baja = 0 AND I.Reservado = 0 AND P.Id_WP = 0 AND I.Id_WP = 0 "
        Dim bdT As New BaseDatos
        bdT.LlenarDataSet(Sel, "T")

        For i = 0 To bdT.ds.Tables("T").Rows.Count - 1
            Poblaciones(bdT.ds.Tables("T").Rows(i)("Pob"))
        Next

        MensajeInformacion("FIN")
    End Sub




#End Region
End Class
