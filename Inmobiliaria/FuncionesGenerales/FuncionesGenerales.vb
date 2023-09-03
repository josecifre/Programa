Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Windows.Forms
Imports System.IO
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraPrinting
Imports System.Net.Mail
Imports WordPressPCL

Namespace FuncionesGenerales




    Public Class LeerIni


        Public Shared Function ActualizacionesAutomaticas() As Boolean
            GL_FicheroINI = My.Application.Info.DirectoryPath & "\" & My.Application.Info.AssemblyName & ".ini"

            If Not System.IO.File.Exists(GL_FicheroINI) Then
                'Dim f As New System.IO.StreamWriter(GL_FicheroINI)
                'f.Dispose()
                MsgBox("No se encuentra el fichero de inicialización." & vbCrLf & "Póngase en contacto con su proveedor")
                End
            End If

            clVariables.RutaServidor = FicheroIni.Leer(GL_FicheroINI, "RED", "RED")
            If clVariables.RutaServidor = "" Then
                clVariables.RutaServidor = My.Application.Info.DirectoryPath
                GL_FicheroINI_RED = GL_FicheroINI
            Else
                GL_FicheroINI_RED = clVariables.RutaServidor & "\" & My.Application.Info.AssemblyName & ".ini"
            End If

            GL_Descargas = FicheroIni.Leer(GL_FicheroINI, "DESCARGAS", "DESCARGAS")
            GL_ActualizacionesAutomaticas = FicheroIni.Leer(GL_FicheroINI, "DESCARGAS", "ACTUALIZACIONESAUTOMATICAS")


            If FicheroIni.Leer(GL_FicheroINI, "DESCARGAS", "DESCARGA_POR_FTP") = "NO" Then
                GL_DESCARGA_POR_FTP = False
            Else
                GL_DESCARGA_POR_FTP = True
            End If

            If GL_ActualizacionesAutomaticas.ToUpper = "SI" Then
                Return True
            Else
                Return False
            End If




        End Function

        Public Shared Sub LeerFicheroInicializacion()

            Dim AutenticacionWindows As Boolean

            GL_FicheroINI = My.Application.Info.DirectoryPath & "\" & My.Application.Info.AssemblyName & ".ini"

            If Not System.IO.File.Exists(GL_FicheroINI) Then
                'Dim f As New System.IO.StreamWriter(GL_FicheroINI)
                'f.Dispose()
                MsgBox("No se encuentra el fichero de inicialización." & vbCrLf & "Póngase en contacto con su proveedor")
                End
            End If

            clVariables.RutaServidor = FicheroIni.Leer(GL_FicheroINI, "RED", "RED")
            If clVariables.RutaServidor = "" Then
                clVariables.RutaServidor = My.Application.Info.DirectoryPath
                GL_FicheroINI_RED = GL_FicheroINI
            Else
                GL_FicheroINI_RED = clVariables.RutaServidor & "\" & My.Application.Info.AssemblyName & ".ini"
            End If

            If Not System.IO.File.Exists(GL_FicheroINI_RED) Then
                'Dim f As New System.IO.StreamWriter(GL_FicheroINI)
                'f.Dispose()
                MsgBox("No se encuentra el fichero de inicialización en la ruta " & clVariables.RutaServidor & vbCrLf & "Póngase en contacto con su proveedor")
                End
            End If

            GL_Empresa_EW = FicheroIni.Leer(GL_FicheroINI_RED, "DATOS_EW", "EMPRESA_EW")
            GL_BD_EW = "[" & FicheroIni.Leer(GL_FicheroINI_RED, "DATOS_EW", "BASE_DATOS") & "]"


            GL_MostarNotePad = FicheroIni.Leer(GL_FicheroINI_RED, "OTROS_DATOS", "MOSTARNOTEPAD")


            clVariables.ServidorSQL = FicheroIni.Leer(GL_FicheroINI_RED, "SERVIDORSQL", "SERVIDOR")
            clVariables.BaseDatos = FicheroIni.Leer(GL_FicheroINI_RED, "SERVIDORSQL", "BASEDATOS")
            clVariables.UsuarioSQL = FicheroIni.Leer(GL_FicheroINI_RED, "SERVIDORSQL", "USQLSERVER")
            clVariables.PassWordUsuarioSQL = FicheroIni.Leer(GL_FicheroINI_RED, "SERVIDORSQL", "PSQLSERVER")

            If FicheroIni.Leer(GL_FicheroINI, "BASEDATOS", "AUTENTICACION_WINDOWS").ToUpper = "SI" Then
                AutenticacionWindows = True
            Else
                AutenticacionWindows = False
            End If

            Dim TipoBD As String = FicheroIni.Leer(GL_FicheroINI, "OTROS_DATOS", "TIPO_BD")

            Select Case TipoBD

                Case "SQL"
                    GL_TipoBD = EnumTipoBD.SQL_SERVER

                Case "ORA"
                    GL_TipoBD = EnumTipoBD.ORACLE

                Case "ACC"
                    GL_TipoBD = EnumTipoBD.ACCESS

                Case Else
                    GL_TipoBD = EnumTipoBD.SQL_SERVER
            End Select

            Select Case GL_TipoBD

                Case EnumTipoBD.SQL_SERVER
                    GL_SQL_DELETE = "DELETE "
                    GL_SQL_SUMA = "+"
                    GL_SQL_UPPER = "UPPER"
                    GL_SQL_POR = "%"
                    GL_SQL_DBO = "dbo."
                    GL_SQL_CHAR = "CHAR"
                    GL_SQL_FROMDUAL = GL_VACIO
                    GL_SQL_LEN = "LEN"
                    GL_SQL_DIS = "<>"
                    GL_SQL_YEAR = "YEAR( "
                    GL_SQL_VALOR_1 = "1"
                    GL_SQL_GETDATE = "GETDATE()"
                    GL_SQL_D = "d"
                    GL_SQL_SUBSTRING = "SUBSTRING"
                    GL_SQL_TOP1_FRONT = "SELECT TOP 1 "
                    GL_SQL_TOP1_BACK = ""

                Case EnumTipoBD.ORACLE
                    GL_SQL_DELETE = "DELETE "
                    GL_SQL_SUMA = "||"
                    GL_SQL_UPPER = "UPPER"
                    GL_SQL_POR = "%"
                    GL_SQL_DBO = GL_VACIO
                    GL_SQL_CHAR = "CHR"
                    GL_SQL_FROMDUAL = " FROM DUAL "
                    GL_SQL_LEN = "LENGTH"
                    GL_SQL_DIS = "!="
                    GL_SQL_YEAR = "EXTRACT(YEAR FROM "
                    GL_SQL_VALOR_1 = "1"
                    GL_SQL_GETDATE = "SYSDATE"
                    GL_SQL_D = "'DD'"
                    GL_SQL_SUBSTRING = "SUBSTR"
                    GL_SQL_TOP1_FRONT = "SELECT * FROM (SELECT "
                    GL_SQL_TOP1_BACK = ") WHERE ROWNUM=1"

                Case EnumTipoBD.ACCESS
                    GL_SQL_DELETE = "DELETE * "
                    GL_SQL_SUMA = "&"
                    GL_SQL_UPPER = "UCASE"
                    GL_SQL_POR = "%"
                    GL_SQL_DBO = GL_VACIO
                    GL_SQL_CHAR = "CHR"
                    GL_SQL_FROMDUAL = "FROM (SELECT TOP 1 * FROM Tipo)"
                    GL_SQL_LEN = "LEN"
                    GL_SQL_DIS = "<>"
                    GL_SQL_YEAR = "YEAR( "
                    GL_SQL_VALOR_1 = "-1"
                    GL_SQL_GETDATE = "NOW()"
                    GL_SQL_D = "'d'"
                    GL_SQL_SUBSTRING = "MID"
                    GL_SQL_TOP1_FRONT = "SELECT TOP 1 "
                    GL_SQL_TOP1_BACK = ""

                Case Else

            End Select

            clVariables.BaseDatos = Encriptacion.DesEncriptar(clVariables.BaseDatos, "LAMBDAPI")

            If clVariables.ServidorSQL = "" Or clVariables.UsuarioSQL = "" Or clVariables.PassWordUsuarioSQL = "" Then
                frmDatosBaseDeDatos.ShowDialog()
                If clVariables.ServidorSQL = "" Then
                    End
                End If
            End If

            clVariables.ServidorSQL = Encriptacion.DesEncriptar(clVariables.ServidorSQL, "LAMBDAPI")
            clVariables.UsuarioSQL = Encriptacion.DesEncriptar(clVariables.UsuarioSQL, "LAMBDAPI")
            clVariables.PassWordUsuarioSQL = Encriptacion.DesEncriptar(clVariables.PassWordUsuarioSQL, "LAMBDAPI")
            clVariables.ServidorSQL1 = clVariables.ServidorSQL
            clVariables.BaseDatos1 = clVariables.BaseDatos
            clVariables.UsuarioSQL1 = clVariables.UsuarioSQL
            clVariables.PassWordUsuarioSQL1 = clVariables.PassWordUsuarioSQL


            If GL_TipoBD = EnumTipoBD.ACCESS Then
                If Not Funciones.PrepararCadenaDeConexionAccess(clVariables.RutaServidor & "\VENALIA." & TIPOACCESS) Then
                    End
                End If

                Funciones.PrepararCadenaDeConexionAccess(clVariables.RutaServidor & "\VENALIA." & TIPOACCESS, 1, False)

            ElseIf GL_TipoBD = EnumTipoBD.SQL_SERVER Then
                If Not Funciones.PrepararCadenaDeConexion(AutenticacionWindows) Then
                    End
                End If

                Funciones.PrepararCadenaDeConexion(AutenticacionWindows, 1, False)
            End If

            GL_Descargas = FicheroIni.Leer(GL_FicheroINI, "DESCARGAS", "DESCARGAS")
            GL_ActualizacionesAutomaticas = FicheroIni.Leer(GL_FicheroINI, "DESCARGAS", "ACTUALIZACIONESAUTOMATICAS")
            GL_QuienSoy = FicheroIni.Leer(GL_FicheroINI, "DESCARGAS", "WHOIS")

            If FicheroIni.Leer(GL_FicheroINI, "DESCARGAS", "DESCARGA_POR_FTP") = "NO" Then
                GL_DESCARGA_POR_FTP = False
            Else
                GL_DESCARGA_POR_FTP = True
            End If

            GL_BD_VENALIA = ""
            GL_BD_VENALIA = FicheroIni.Leer(GL_FicheroINI, "SERVIDORSQL", "BDVENALIA")
            If GL_BD_VENALIA <> "" Then
                GL_BD_VENALIA = Encriptacion.DesEncriptar(GL_BD_VENALIA, "LAMBDAPI")
            End If


        End Sub

    End Class

    Public Class FicheroIni

        ' Leer una clave de un fichero INI
        Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
        ' Escribir una clave de un fichero INI (también para borrar claves y secciones)
        Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer

        Public Shared Function Leer(ByVal sFileName As String, ByVal sSection As String, ByVal sKeyName As String, Optional ByVal sDefault As String = "") As String
            '--------------------------------------------------------------------------
            ' Devuelve el valor de una clave de un fichero INI
            ' Los parámetros son:
            '   sFileName   El fichero INI
            '   sSection    La sección de la que se quiere leer
            '   sKeyName    Clave
            '   sDefault    Valor opcional que devolverá si no se encuentra la clave
            '--------------------------------------------------------------------------
            Dim ret As Integer
            Dim sRetVal As String
            '
            sRetVal = New String(Chr(0), 3000)
            '
            ret = GetPrivateProfileString(sSection, sKeyName, sDefault, sRetVal, Len(sRetVal), sFileName)
            If ret = 0 Then
                Return sDefault
            Else
                Return Left(sRetVal, ret)
            End If
        End Function

        Public Shared Sub Escribir(ByVal sFileName As String, ByVal sSection As String, ByVal sKeyName As String, ByVal sValue As String)
            '--------------------------------------------------------------------------
            ' Guarda los datos de configuración
            ' Los parámetros son los mismos que en LeerIni
            ' Siendo sValue el valor a guardar
            '
            Call WritePrivateProfileString(sSection, sKeyName, sValue, sFileName)
        End Sub

    End Class

    Public Class Funciones

        Public Shared Function TextoANotePad(Texto As String) As Boolean


            If GL_MostarNotePad <> "SI" Then
                Return False
            End If

            Dim Ruta As String
            Dim Aleatorio As String = Microsoft.VisualBasic.Format(Now, "yyyyMMddHHmmssfff")

            Ruta = clVariables.RutaServidor & "\Notepad"
            FuncionesGenerales.Funciones.ComprobarYCrearCarpetas(Ruta)

            Ruta = Ruta & "\" & Aleatorio & ".txt"
            Dim sw As New System.IO.StreamWriter(Ruta, True)
            sw.WriteLine(Texto)
            sw.Close()

            Dim p As New Process
            p.Start(Ruta)

            Return True
        End Function

        Public Shared Sub ShowListado(ByVal r As XtraReport, ByVal GL_Word As Boolean, ByVal DT As DataTable)
            r.DataSource = DT
            r.DataMember = "Datos"
            FuncionesGenerales.Funciones.ComprobarYCrearCarpetas(My.Application.Info.DirectoryPath & "\TMP")
            Dim Fichero As String = My.Application.Info.DirectoryPath & "\TMP\Word" & Format(Now, "ddmmyyyyhhmmss")
            Try
                File.Delete(Fichero & ".doc")
            Catch ex As Exception
            End Try
            Try
                File.Delete(Fichero & ".html")
            Catch ex As Exception
            End Try



            If GL_Word Then
                Try
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
                    'Me.Cursor = System.Windows.Forms.Cursors.Arrow
                    Process.Start(Fichero & ".doc")
                Catch ex As Exception
                    MensajeError(ex.Message)
                End Try

            Else
                'Me.Cursor = System.Windows.Forms.Cursors.Arrow
                r.ShowPreview()
            End If
        End Sub


        Public Shared Function EnlaceWeb(tipo As String, TipoVenta As String, poblacion As String, referencia As String, ParaEnvioEmail As Boolean) As String

            If DatosEmpresa.WordPress Then
                Dim link_WP As String = ""
                link_WP = BD_CERO.Execute("SELECT link_WP FROM Inmuebles WHERE Referencia='" & referencia & "'", False)
                Return link_WP
            Else

                If DatosEmpresa.Codigo = 2 Then

                    'If ParaEnvioEmail Then
                    '    Dim dir As String
                    '    Dir = "<a href=" & GL_ConfiguracionWeb.PaginaDetalle & "?Referencia=" & referencia & ">" & GL_ConfiguracionWeb.PaginaDetalle & "?Referencia=" & referencia & "</a>"
                    '    Return dir
                    'Else
                    '    Dim dir As String
                    '    dir = GL_ConfiguracionWeb.PaginaDetalle & "?Referencia=" & referencia
                    '    Return dir
                    'End If

                    Dim dir As String
                    dir = GL_ConfiguracionWeb.PaginaDetalle & "?Referencia=" & referencia
                    Return dir

                Else
                    Return GL_ConfiguracionWeb.PaginaDetalle & tipo.Replace("/", "-") & "/" & TipoVenta.Replace("/", "-") & "/" & poblacion.Replace("/", "-") & "/0/" & referencia.Replace("/", "-") & "/" & DatosEmpresa.Codigo
                End If
            End If



        End Function
        Public Shared Function SiguienteLetra(ByVal Codigo As String) As String
            If String.IsNullOrEmpty(Codigo) Then
                Return "0"
            End If
            Dim nuevoCodigo As String = ""
            For i = Codigo.Length - 1 To 0 Step -1
                nuevoCodigo = NextLetra(Codigo(i)) & nuevoCodigo
                If NextLetra(Codigo(i)) <> "0" AndAlso NextLetra(Codigo(i)) <> Codigo(i) Then
                    nuevoCodigo = Codigo.Substring(0, Codigo.Length - nuevoCodigo.Length) & nuevoCodigo
                    Exit For
                End If
            Next
            Return nuevoCodigo
        End Function
        Public Shared Function NextLetra(ByVal Letra As Char) As Char
            Dim codigo As Integer = Asc(Letra)
            Select Case codigo
                Case 48 To 56, 97 To 121, 65 To 89
                    codigo += 1
                Case 57
                    codigo = 48
                Case 122
                    codigo = 65
                Case 90
                    codigo = 48
            End Select
            Return Chr(codigo)
        End Function

        Public Shared Function HacerCopiaSeguridadCompleta(ByVal NombreBD As String) As String

            Dim pf As New ProgressForm(10, "Realizando copia de seguridad ...")

            Dim CarpetaResultado As String
            CarpetaResultado = clVariables.RutaServidor & "/Seguridad"
            Funciones.ComprobarYCrearCarpetas(CarpetaResultado)

            If Microsoft.VisualBasic.Right(CarpetaResultado, 1) <> "/" AndAlso Microsoft.VisualBasic.Right(CarpetaResultado, 1) <> "\" Then
                CarpetaResultado = CarpetaResultado & "/"
            End If
            CarpetaResultado = "\\SERVER\tramex/"
            Dim RutaCompleta As String = CarpetaResultado & "VENALIA2_COMPLETA.bak"
            Dim Sel As String

            Sel = "BACKUP DATABASE [" & clVariables.BaseDatos & "] TO  DISK = N'" & RutaCompleta & "'" &
                    " WITH  NOFORMAT, INIT, " &
                    " NAME = N'CopiaCompleta'" &
                    " ,SKIP, NOREWIND, NOUNLOAD, STATS = 10"

            pf.nuevoPaso()

            Try
                Dim cn As New SqlClient.SqlConnection
                cn.ConnectionString = clVariables.CadenaConexion
                Dim cmd As New SqlClient.SqlCommand(Sel, cn)
                cmd.CommandTimeout = 120
                pf.nuevoPaso()
                cmd.Connection.Open()
                pf.nuevoPaso()
                pf.nuevoPaso()
                cmd.ExecuteNonQuery()
                pf.nuevoPaso()
                pf.nuevoPaso()
                pf.nuevoPaso()
                pf.nuevoPaso()
                cmd.Connection.Close()
                pf.nuevoPaso()
            Catch ex As SqlClient.SqlException
                pf.Close()
                Return ex.Message
                End
            End Try


            Dim Ruta As String = NombreBD & "/VENALIA2_COMPLETA.bak"

            If System.IO.File.Exists(Ruta) Then
                System.IO.File.Delete(Ruta)
            End If
            IO.File.Copy(RutaCompleta, Ruta)

            pf.nuevoPaso()

            pf.Close()

            Return ""


        End Function

        Public Shared Sub CHECKS(ByVal View As ColumnView, ByVal e As CustomColumnDisplayTextEventArgs) ', ByVal Campos As String)
            If GL_TipoBD = EnumTipoBD.SQL_SERVER Then
                Return
            End If
            If e.Column.ColumnType.Name = "Byte" Then 'e.Column.ColumnType.Name = "Boolean" OrElse 
                'If Campos.Contains("'" & e.Column.FieldName.ToUpper & "'") Then
                Dim Cambio As String = ""
                If Not IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns(e.Column.FieldName))) Then
                    Cambio = View.GetRowCellValue(e.RowHandle, View.Columns(e.Column.FieldName))
                End If
                Select Case Cambio
                    Case "0"
                        e.DisplayText = GL_ICONONO
                    Case "1"
                        e.DisplayText = GL_ICONOSI
                    Case Else
                        e.DisplayText = GL_ICONOOTRO
                End Select

            End If
        End Sub
        Public Shared Sub CHECKSCOLOR(ByVal View As GridView, ByVal e As RowCellStyleEventArgs) ', ByVal Campos As String)
            If GL_TipoBD = EnumTipoBD.SQL_SERVER Then
                Return
            End If
            If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
                e.Appearance.ForeColor = Color.Transparent
                Return
            End If
            If e.Column.ColumnType.Name = "Byte" Then 'e.Column.ColumnType.Name = "Boolean" OrElse 
                'If Campos.Contains("'" & e.Column.FieldName.ToUpper & "'") Then
                Select Case View.GetRowCellDisplayText(e.RowHandle, View.Columns(e.Column.FieldName))
                    Case GL_ICONOSI
                        e.Appearance.ForeColor = Color.Green
                    Case GL_ICONONO
                        e.Appearance.ForeColor = Color.Red
                    Case GL_ICONOOTRO
                        e.Appearance.ForeColor = Color.Orange
                    Case Else

                End Select
            End If
        End Sub
        Public Shared Function F_OBTENERCOLECCIONDECAMPOS(ByVal Tabla As String, Optional ByVal CONTADOR As String = "CONTADOR", Optional ByVal BD As Integer = 0) As String

            Dim COLECCIONCAMPOS As String = GL_VACIO
            Dim CAMPO As String = GL_VACIO
            Dim bdOC As New BaseDatos(BD)

            Dim dtr As Object = Nothing
            Select Case GL_TipoBD
                Case EnumTipoBD.SQL_SERVER
                    dtr = bdOC.ExecuteReader("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" & Tabla.ToUpper & "'")
                Case EnumTipoBD.ORACLE
                    dtr = bdOC.ExecuteReader("SELECT COLUMN_NAME FROM ALL_TAB_COLUMNS WHERE TABLE_NAME ='" & Tabla.ToUpper & "' ORDER BY COLUMN_ID")

            End Select

            Select Case GL_TipoBD
                Case EnumTipoBD.SQL_SERVER, EnumTipoBD.ORACLE
                    If dtr.hasrows Then
                        While dtr.read
                            CAMPO = dtr("COLUMN_NAME")
                            If COLECCIONCAMPOS.Trim = GL_VACIO Then
                                If CAMPO.ToUpper <> CONTADOR Then
                                    COLECCIONCAMPOS = CAMPO
                                End If
                            Else
                                If CAMPO.ToUpper <> CONTADOR Then
                                    COLECCIONCAMPOS &= ", " & CAMPO
                                End If
                            End If

                        End While
                    End If
                Case EnumTipoBD.ACCESS
                    bdOC.LlenarDataSet("SELECT TOP 1 * FROM " & Tabla, "CAMPOS")
                    For i = 0 To bdOC.ds.Tables("CAMPOS").Columns.Count - 1
                        CAMPO = bdOC.ds.Tables("CAMPOS").Columns(i).ColumnName
                        If COLECCIONCAMPOS.Trim = GL_VACIO Then
                            If CAMPO.ToUpper <> CONTADOR Then
                                COLECCIONCAMPOS = CAMPO
                            End If
                        Else
                            If CAMPO.ToUpper <> CONTADOR Then
                                COLECCIONCAMPOS &= ", " & CAMPO
                            End If
                        End If
                    Next

            End Select
            dtr.Close()
            bdOC.CerrarBD()
            Return COLECCIONCAMPOS
        End Function

        Public Shared Function redimensionaimagen(ByVal img As System.Drawing.Image, ByVal ancho As Integer, ByVal alto As Integer, Optional ByVal FIJO As Boolean = True, Optional ByVal MantenerAncho As Boolean = False) As System.Drawing.Image
            Dim altoimg As Integer = img.Height
            Dim anchoimg As Integer = img.Width
            Dim altonuevo As Integer
            Dim anchonuevo As Integer

            If ancho > anchoimg Then
                'Dim Divisor As Double
                'Divisor = anchoimg / ancho
                'ancho = anchoimg
                'alto = alto * Divisor


                ancho = anchoimg
                alto = altoimg

            End If

            'If MantenerAncho Then
            '  altonuevo = altoimg / (anchoimg / ancho)
            '   anchonuevo = ancho
            'Else
            If (altoimg / alto) > (anchoimg / ancho) Then
                    altonuevo = alto
                    anchonuevo = anchoimg / (altoimg / alto)
                Else
                    altonuevo = altoimg / (anchoimg / ancho)
                    anchonuevo = ancho
                End If
                'End If


                Dim imgOrg As Bitmap = New Bitmap(img)
            Dim imgRdm As Bitmap = New Bitmap(ancho, alto)
            If Not FIJO Then
                imgRdm = New Bitmap(anchonuevo, altonuevo)
                'Else
                '    imgRdm = New Bitmap(ancho, alto)
            End If
            Using G As Graphics = Graphics.FromImage(imgRdm)
                G.Clear(Color.White)
                If FIJO Then
                    Dim a, b As Integer
                    a = (ancho - anchonuevo) / 2
                    b = (alto - altonuevo) / 2
                    'G.DrawImage(imgOrg, a, b, anchonuevo + a, altonuevo + b)
                    G.DrawImage(imgOrg, a, b, anchonuevo, altonuevo)
                    'G.DrawImage(imgOrg, 0, 0, anchonuevo, altonuevo)
                Else
                    G.DrawImage(imgOrg, 0, 0, anchonuevo, altonuevo)
                End If

            End Using
            Return imgRdm
        End Function
        Public Shared Function SQL_CONVERT(ByVal TIPO As String, ByVal Valor As String) As String
            Select Case GL_TipoBD
                Case EnumTipoBD.SQL_SERVER
                    Return " CAST(" & Valor & " AS " & TIPO & ") "
                Case EnumTipoBD.ORACLE
                    Select Case TIPO
                        Case "INT"
                            TIPO = "NUMBER(10)"
                            'Case "FLOAT"
                            '    TIPO = "NUMBER(10,2)"
                        Case "DATE"
                            TIPO = "DATE"
                        Case "BIT"
                            TIPO = "NUMBER(1)"
                        Case "DOUBLE", "FLOAT"
                            TIPO = "FLOAT(50)"
                        Case "MEMO"
                            TIPO = "CLOB"
                        Case Else
                            TIPO = Replace(TIPO, "VARCHAR", "VARCHAR2")
                    End Select

                    Return " CAST(" & Valor & " AS " & TIPO & ") "

                Case EnumTipoBD.ACCESS
                    Select Case TIPO
                        Case "INT"
                            Return " CINT(" & Valor & ") "
                        Case "BIT"
                            Return " CBOOL(" & Valor & ") "
                        Case "DATETIME"
                            Return " CDATE(" & Valor & ") "
                        Case "FLOAT"
                            Return " ROUND(" & Valor & ",2) "
                        Case Else 'varchar...
                            Return " CSTR(" & Valor & ") "
                    End Select

                Case Else
                    Return GL_VACIO
            End Select

        End Function
        Public Shared Function SQL_CASE(ByVal Condiciones() As String, ByVal Valor() As String) As String
            Dim cadena As String = GL_VACIO
            Select Case GL_TipoBD
                Case EnumTipoBD.SQL_SERVER, EnumTipoBD.ORACLE
                    cadena = " CASE"
                    For i = 0 To Condiciones.Length - 1
                        cadena &= " WHEN " & Condiciones(i) & " THEN " & Valor(i)
                    Next
                    cadena &= " END "
                Case EnumTipoBD.ACCESS
                    cadena = " SWITCH("
                    For i = 0 To Condiciones.Length - 1
                        If i > 0 Then
                            cadena &= " , "
                        End If
                        cadena &= Condiciones(i) & " , " & Valor(i)
                    Next
                    cadena &= ") "

            End Select
            Return cadena
        End Function
        Public Shared Function SQL_CHARINDEX(find As String, text As String) As String
            Dim cadena As String = GL_VACIO
            Select Case GL_TipoBD
                Case EnumTipoBD.ACCESS, EnumTipoBD.ORACLE
                    cadena = " INSTR(" & text & "," & find & ")"
                Case EnumTipoBD.SQL_SERVER
                    cadena = " CHARINDEX(" & find & "," & text & ")"
            End Select
            Return cadena
        End Function

        Public Shared Function SQL_CASE_ISNULL(ByVal VALORNULOYREEMPLAZO As String) As String
            Dim VALORNULO As String = Split(VALORNULOYREEMPLAZO, ",")(0)
            Dim REEMPLAZO As String = Split(VALORNULOYREEMPLAZO, ",")(1)
            If REEMPLAZO.Contains("TO_DATE") Then
                REEMPLAZO &= "," & Split(VALORNULOYREEMPLAZO, ",")(2)
            End If
            Dim cadena As String = GL_VACIO
            Select Case GL_TipoBD
                Case EnumTipoBD.SQL_SERVER
                    cadena = " ISNULL(" & VALORNULO & "," & REEMPLAZO & ")"
                Case EnumTipoBD.ORACLE
                    cadena = " NVL(" & VALORNULO & "," & REEMPLAZO & ")"
                Case EnumTipoBD.ACCESS
                    'cadena = " SWITCH(ISNULL(" & VALORNULO & ")," & REEMPLAZO & ","& Funciones.SQL_CASE_ISNULL("" & VALORNULO & ")=FALSE," & VALORNULO & ")"
                    cadena = " IIF(ISNULL(" & VALORNULO & ")," & REEMPLAZO & "," & VALORNULO & ")"
                    cadena = Replace(cadena, "//", ",")

            End Select
            Return cadena
        End Function

        Public Shared Sub CopiaSeguridad(ByVal CopiaTotal As Boolean)

            Dim CarpetaCopia As String

            Dim FolderBrowserDialogCopiaTotal As New FolderBrowserDialog

            CarpetaCopia = clVariables.RutaServidor & "\Copia"

            If CopiaTotal Then
                FolderBrowserDialogCopiaTotal.Description = "Copia de la Aplicación."
            Else
                FolderBrowserDialogCopiaTotal.Description = "Copia de la base de datos."
            End If
            FolderBrowserDialogCopiaTotal.SelectedPath = CarpetaCopia

            'Preparamos carpeta copia. Aquí haremos la copia de la bd, en ambos casos

            ComprobarYCrearCarpetas(CarpetaCopia)

            Try
                System.IO.File.Delete(CarpetaCopia & "\" & clVariables.BaseDatos & "AYER.BAK")
            Catch ex As Exception
            End Try
            Try
                System.IO.File.Copy(CarpetaCopia & "\" & clVariables.BaseDatos & ".BAK", CarpetaCopia & "\" & clVariables.BaseDatos & "AYER.BAK")
            Catch ex As Exception
            End Try
            Try
                System.IO.File.Delete(CarpetaCopia & "\" & clVariables.BaseDatos & ".BAK")
            Catch ex As Exception
            End Try
            'fin Preparamos carpeta copia

            'Seleccionamos el destino y hacemos la copia
            Dim Destino As String = ""

            If FolderBrowserDialogCopiaTotal.ShowDialog = Windows.Forms.DialogResult.OK Then
                Destino = FolderBrowserDialogCopiaTotal.SelectedPath
                If InStr(Destino, clVariables.RutaServidor, CompareMethod.Text) Then
                    MsgBox("La carpeta de destino no puede estar contenida el la carpeta a copiar")
                    Exit Sub
                End If
            End If

            If IO.Directory.Exists(Destino) Then
                Dim bd As New BaseDatos
                bd.Execute("BACKUP DATABASE " & clVariables.BaseDatos & " TO DISK = '" & CarpetaCopia & "\" & clVariables.BaseDatos & ".BAK'")
            Else
                MsgBox("No existe el directorio de destino")
                Exit Sub
            End If

            If CarpetaCopia.ToUpper <> Destino.ToUpper Then
                If CopiaTotal Then
                    My.Computer.FileSystem.CopyDirectory(clVariables.RutaServidor, Destino, True)
                Else
                    System.IO.File.Copy(CarpetaCopia & "\" & clVariables.BaseDatos & ".BAK", Destino & "\" & clVariables.BaseDatos & ".BAK", True)
                End If

            End If

            MsgBox("Copia Realizada Correctamente")

        End Sub

        Public Shared Sub BorrarContenidoCarpeta(ByVal Carpeta As String, Optional ByVal BorrarCarpetaTambien As Boolean = False)
            Dim Archivos() As String
            Dim Archivo As String

            Archivos = System.IO.Directory.GetFiles(Carpeta, "*.*")
            For Each Archivo In Archivos
                System.IO.File.Delete(Archivo)
            Next

            If BorrarCarpetaTambien Then
                System.IO.Directory.Delete(Carpeta, True)
            End If


        End Sub

        Public Shared Sub EscribeLog(ByVal Descripcion As String, Optional ByVal Resultado As String = "ERROR")


            Try
                Dim FicheroXML As String = My.Application.Info.DirectoryPath & "\FicheroLog.xml"


                Dim ds As New DataSet
                ds.ReadXml(FicheroXML)

                Dim dr As DataRow
                dr = ds.Tables("Tabla").NewRow()
                dr("fechahora") = Now
                dr("resultado") = Resultado
                dr("descripcion") = Descripcion


                ds.Tables("Tabla").Rows.Add(dr)

                ds.AcceptChanges()
                ds.WriteXml(FicheroXML, XmlWriteMode.WriteSchema)
            Catch ex As Exception


            End Try


        End Sub

        Public Shared Function PrepararCadenaDeConexionAccess(ByVal BaseDatos As String, Optional ByVal NumeroCadena As Integer = 0, Optional ByVal ProbarCadena As Boolean = True) As Boolean
            '  Dim CADENAACCESS As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & BaseDatos
            '  Dim CADENAACCESS As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & BaseDatos & ";Jet OLEDB:Database Password=" & clVariables.PassWordUsuarioSQL & ";"
            Dim CADENAACCESS As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & BaseDatos & ";Jet OLEDB:Database Password=" & clVariables.PassWordUsuarioSQL

            ' PARA ACCDB "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & BaseDatos
            Select Case NumeroCadena
                Case 0
                    clVariables.CadenaConexion = CADENAACCESS
                Case 1
                    clVariables.CadenaConexion1 = CADENAACCESS
                Case 2
                    clVariables.CadenaConexion2 = CADENAACCESS
                Case 3
                    clVariables.CadenaConexion3 = CADENAACCESS
                Case 4
                    clVariables.CadenaConexion4 = CADENAACCESS
                Case 5
                    clVariables.CadenaConexion5 = CADENAACCESS

            End Select

            Return True


        End Function

        Public Shared Function PrepararCadenaDeConexion(Optional ByVal AutenticacionWindows As Boolean = False, Optional ByVal NumeroCadena As Integer = 0, Optional ByVal ProbarCadena As Boolean = True) As Boolean

            Select Case NumeroCadena
                Case 0
                    If AutenticacionWindows Then
                        clVariables.UsuarioSQL = ""
                        clVariables.PassWordUsuarioSQL = ""
                        clVariables.CadenaConexion = "Data Source=" & clVariables.ServidorSQL & ";Initial Catalog=" & clVariables.BaseDatos & ";Integrated Security=True"
                    Else
                        clVariables.CadenaConexion = "Data Source=" & clVariables.ServidorSQL & ";Initial Catalog=" & clVariables.BaseDatos & ";User ID = " & clVariables.UsuarioSQL & "; Password = " & clVariables.PassWordUsuarioSQL & ";APP=Venalia"
                    End If
                Case 1
                    If AutenticacionWindows Then
                        clVariables.UsuarioSQL1 = ""
                        clVariables.PassWordUsuarioSQL1 = ""
                        clVariables.CadenaConexion1 = "Data Source=" & clVariables.ServidorSQL1 & ";Initial Catalog=" & clVariables.BaseDatos1 & ";Integrated Security=True"
                    Else
                        clVariables.CadenaConexion1 = "Data Source=" & clVariables.ServidorSQL1 & ";Initial Catalog=" & clVariables.BaseDatos1 & ";User ID = " & clVariables.UsuarioSQL1 & "; Password = " & clVariables.PassWordUsuarioSQL1 & ";APP=VenaliaEmpresas"
                    End If
                Case 2
                    If AutenticacionWindows Then
                        clVariables.UsuarioSQL2 = ""
                        clVariables.PassWordUsuarioSQL2 = ""
                        clVariables.CadenaConexion2 = "Data Source=" & clVariables.ServidorSQL2 & ";Initial Catalog=" & clVariables.BaseDatos2 & ";Integrated Security=True"
                    Else
                        clVariables.CadenaConexion2 = "Data Source=" & clVariables.ServidorSQL2 & ";Initial Catalog=" & clVariables.BaseDatos2 & ";User ID = " & clVariables.UsuarioSQL2 & "; Password = " & clVariables.PassWordUsuarioSQL2 & ";APP=Venalia"
                    End If
                Case 3
                    If AutenticacionWindows Then
                        clVariables.UsuarioSQL3 = ""
                        clVariables.PassWordUsuarioSQL3 = ""
                        clVariables.CadenaConexion3 = "Data Source=" & clVariables.ServidorSQL3 & ";Initial Catalog=" & clVariables.BaseDatos3 & ";Integrated Security=True"
                    Else
                        clVariables.CadenaConexion3 = "Data Source=" & clVariables.ServidorSQL3 & ";Initial Catalog=" & clVariables.BaseDatos3 & ";User ID = " & clVariables.UsuarioSQL3 & "; Password = " & clVariables.PassWordUsuarioSQL3 & ";APP=Venalia"
                    End If
                Case 4
                    If AutenticacionWindows Then
                        clVariables.UsuarioSQL4 = ""
                        clVariables.PassWordUsuarioSQL4 = ""
                        clVariables.CadenaConexion4 = "Data Source=" & clVariables.ServidorSQL4 & ";Initial Catalog=" & clVariables.BaseDatos4 & ";Integrated Security=True"
                    Else
                        clVariables.CadenaConexion4 = "Data Source=" & clVariables.ServidorSQL4 & ";Initial Catalog=" & clVariables.BaseDatos4 & ";User ID = " & clVariables.UsuarioSQL4 & "; Password = " & clVariables.PassWordUsuarioSQL4 & ";APP=Venalia"
                    End If
                Case 5
                    If AutenticacionWindows Then
                        clVariables.UsuarioSQL5 = ""
                        clVariables.PassWordUsuarioSQL5 = ""
                        clVariables.CadenaConexion5 = "Data Source=" & clVariables.ServidorSQL5 & ";Initial Catalog=" & clVariables.BaseDatos5 & ";Integrated Security=True"
                    Else
                        clVariables.CadenaConexion5 = "Data Source=" & clVariables.ServidorSQL5 & ";Initial Catalog=" & clVariables.BaseDatos5 & ";User ID = " & clVariables.UsuarioSQL5 & "; Password = " & clVariables.PassWordUsuarioSQL5 & ";APP=Venalia"
                    End If

            End Select


            'MsgBox(clVariables.CadenaConexion)
            'MsgBox(clVariables.CadenaConexion1)



            If ProbarCadena Then

                Dim Cadena As String = ""

                Select Case NumeroCadena
                    Case 0
                        Cadena = clVariables.CadenaConexion
                    Case 1
                        Cadena = clVariables.CadenaConexion1
                    Case 2
                        Cadena = clVariables.CadenaConexion2
                    Case 3
                        Cadena = clVariables.CadenaConexion3
                    Case 4
                        Cadena = clVariables.CadenaConexion4
                    Case 5
                        Cadena = clVariables.CadenaConexion5
                End Select

                Try

                    Return True
                Catch ex As Exception
                    Dim Texto As String = "No se puede iniciar la aplicación porque no se pudo establecer la conexión con la base de datos." & vbCrLf & "Asegúrese de que los datos proporcionados sean correctos y que la red funcione correctamente." ' & vbCrLf & ex.Message
                    MensajeError(Texto)
                    Return False

                End Try
            Else
                Return True

            End If





        End Function

        Public Shared Sub PrepararCombo(ByVal BinSrc As BindingSource, ByVal cmb As GridLookUpEdit, ByVal NombreTabla As String, ByVal CampoBinding As String, ByVal DispMember As String, Optional ByVal ValMember As String = "", Optional ByVal Tamano As Integer = 300, Optional ByVal FiltroPasado As String = "", Optional ByVal ConsultaEnVezDeTabla As String = "", Optional ByVal OrdenPasado As String = "", Optional ByVal GenerarCommandsDinamicos As Boolean = False, Optional ByVal ValoresPorDefecto As Boolean = False, Optional ByVal AbrirYCerrarBD As Boolean = True, Optional ByVal NumeroCadena As Integer = 0, Optional ByVal FiltroEnGridDesplegable As String = "", Optional ByVal NombresColumnasOcultas() As String = Nothing)

            For i = 0 To cmb.DataBindings.Count - 1
                cmb.DataBindings.Remove(cmb.DataBindings(0))
            Next

            cmb.DataBindings.Add(New Binding("EditValue", BinSrc, CampoBinding, True))

            If cmb.Properties.Buttons.VisibleCount > 1 Then



                Try
                    'Dim j = 0
                    'Do
                    RemoveHandler cmb.ButtonClick, AddressOf FuncionesGenerales.Funciones.AbrirMantenimientosCombos

                    '  Loop While j = 0
                Catch ex As Exception

                End Try

                AddHandler cmb.ButtonClick, AddressOf FuncionesGenerales.Funciones.AbrirMantenimientosCombos
            End If

            'If NombresColumnasOcultas IsNot Nothing Then
            '    Try
            '        RemoveHandler cmb.QueryPopUp, AddressOf FuncionesGenerales.Funciones.OcultarColumnasGridLookUpEdit
            '    Catch ex As Exception

            '    End Try

            'End If

            'AddHandler cmb.QueryPopUp, AddressOf FuncionesGenerales.Funciones.OcultarColumnasGridLookUpEdit



            LlenarCombo(cmb, NombreTabla, DispMember, ValMember, Tamano, FiltroPasado, ConsultaEnVezDeTabla, OrdenPasado, GenerarCommandsDinamicos, ValoresPorDefecto, AbrirYCerrarBD, NumeroCadena, FiltroEnGridDesplegable)

            '    OcultarCongelarColumnasDevExpressGridLookUpEdit(NombresColumnasOcultas, cmb, Accion.Ocular)

        End Sub
        Public Shared Sub OcultarColumnasGridLookUpEdit(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
            ' cmbEmpleados.Properties.View.Columns("Codigo").Visible = False
        End Sub
        Public Shared Sub LlenarCombo(ByVal cmb As GridLookUpEdit, ByVal NombreTabla As String, ByVal DispMember As String, Optional ByVal ValMember As String = "", Optional ByVal Tamano As Integer = 300, Optional ByVal FiltroPasado As String = "", Optional ByVal ConsultaEnVezDeTabla As String = "", Optional ByVal OrdenPasado As String = "", Optional ByVal GenerarCommandsDinamicos As Boolean = False, Optional ByVal ValoresPorDefecto As Boolean = False, Optional ByVal AbrirYCerrarBD As Boolean = True, Optional ByVal NumeroCadena As Integer = 0, Optional ByVal FiltroEnGridDesplegable As String = "")
            If ValMember = "" Then
                ValMember = DispMember
            End If

            Dim Tab As Tablas.clTablaGeneral
            Tab = New Tablas.clTablaGeneral(NombreTabla, FiltroPasado, ConsultaEnVezDeTabla, OrdenPasado)
            Dim bd As New BaseDatos(NumeroCadena)

            Tab.Datos(bd, ConsultaEnVezDeTabla, , GenerarCommandsDinamicos, NumeroCadena, False, ValoresPorDefecto, AbrirYCerrarBD)
            cmb.Properties.DataSource = Nothing
            cmb.Properties.DataSource = bd.ds.Tables(Tab.Tabla)
            'cmb.ForceInitialize()
            cmb.Properties.View.OptionsView.EnableAppearanceEvenRow = True
            cmb.Properties.View.OptionsView.ShowAutoFilterRow = True
            cmb.Properties.DisplayMember = DispMember
            cmb.Properties.ValueMember = ValMember


            cmb.Properties.View.BestFitColumns()
            ' Specify the total dropdown width.
            cmb.Properties.PopupFormWidth = Tamano

            cmb.Properties.View.ActiveFilterString = FiltroEnGridDesplegable

        End Sub


        Public Shared Sub AbrirMantenimientosCombos(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

            If e.Button.Index <> 1 Then
                Exit Sub
            End If

            Dim GLook As New GridLookUpEdit
            GLook = DirectCast(sender, GridLookUpEdit)

            'Dim TablaAPasar As String = DirectCast(sender, GridLookUpEdit).Name

            Dim TablaAPasar As String = GLook.Name
            TablaAPasar = Microsoft.VisualBasic.Right(TablaAPasar, TablaAPasar.Length - 3)

            Dim p_MasInformacion As String = ""
            Try
                Select Case TablaAPasar.ToUpper
                    'Case GL_DireccionesEnvio
                    '    p_MasInformacion = GLook.Properties.GetRowByKeyValue(GLook.EditValue)("CodigoCliente")
                End Select
            Catch ex As Exception

            End Try
            '         GLook.Properties.View.Columns("CodigoCliente").Visible = False

            Dim uc As New ucMantenimientos(TablaAPasar, p_MasInformacion)
            FuncionesGenerales.Funciones.AbrirMantenimiento(uc)


            'Cuando cierrann el mantenimiento, se recarga el combo

            Dim TextoAntes As Object = GLook.EditValue
            GLook.Properties.DataSource = Nothing
            LlenarCombo(GLook, TablaAPasar, GLook.Properties.DisplayMember, GLook.Properties.ValueMember)
            Try
                GLook.Properties.GetDisplayValueByKeyValue(TextoAntes).ToString()
            Catch ex As Exception
                Try
                    GLook.Properties.GetDisplayValueByKeyValue("").ToString()
                Catch ex2 As Exception

                End Try
            End Try


        End Sub

        Public Shared Sub AbrirMantenimiento(ByVal uc As Object)
            Dim f As New XtraForm

            f.SuspendLayout()
            '
            'form2
            '
            f.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            f.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            f.ClientSize = New System.Drawing.Size(658, 262)
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
            'f.Name = "form2"
            'f.Text = "form2"
            f.ResumeLayout(False)


            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
            uc.Dock = System.Windows.Forms.DockStyle.Fill
            f.Controls.Add(uc)
            f.StartPosition = FormStartPosition.CenterScreen
            f.ControlBox = False

            Dim Texto As String = ""
            Select Case uc.tabla.ToString.ToUpper



                Case GL_Agrupaciones
                    Texto = "Mantenimiento Agrupaciones"

            End Select




            f.Text = Texto

            f.ShowDialog()
            f.Dispose()
        End Sub

        Public Shared Function pf_ReplaceComillas(ByVal cadena As String) As String
            pf_ReplaceComillas = Replace(cadena, "'", "''")
        End Function
        Public Shared Function pf_ReplaceFecha(ByVal cadena As Object, Optional ByVal comillas As Boolean = True) As String
            Dim c As Char
            If GL_TipoBD = EnumTipoBD.ACCESS Then
                c = "#"
            Else
                c = "'"
            End If
            If Not comillas Then
                c = GL_VACIO
            End If
            If IsDBNull(cadena) OrElse IsNothing(cadena) Then
                Return "NULL"
            Else
                Select Case GL_TipoBD
                    Case EnumTipoBD.SQL_SERVER
                        Return c & Microsoft.VisualBasic.Format(cadena, "yyyyMMdd") & c
                    Case EnumTipoBD.ACCESS
                        Return c & Microsoft.VisualBasic.Format(cadena, "MM/dd/yyyy") & c
                    Case EnumTipoBD.ORACLE

                        ' Return c & "to_date(cadena, 'DD/MM/YYYY')" & c

                        Dim res As String
                        res = "TO_DATE('" & Microsoft.VisualBasic.Format(cadena, "dd/MM/yyyy") & "','DD/MM/YYYY')"

                        Return res


                        'Return c & Microsoft.VisualBasic.Format(cadena, "ddMMyyyy") & c
                    Case Else
                        Return GL_VACIO
                End Select

            End If
        End Function
        Public Shared Function pf_ReplaceHora(ByVal cadena As Object, Optional ByVal comillas As Boolean = True) As String
            Dim c As Char
            If GL_TipoBD = EnumTipoBD.ACCESS Then
                c = "#"
            Else
                c = "'"
            End If
            If Not comillas Then
                c = GL_VACIO
            End If
            If IsDBNull(cadena) OrElse IsNothing(cadena) Then
                Return "NULL"
            Else
                Select Case GL_TipoBD
                    Case EnumTipoBD.SQL_SERVER
                        Return c & Microsoft.VisualBasic.Format(cadena, "HH:mm") & c
                    Case EnumTipoBD.ACCESS
                        Return c & Microsoft.VisualBasic.Format(cadena, "HH:mm") & c
                    Case EnumTipoBD.ORACLE

                        ' Return c & "to_date(cadena, 'DD/MM/YYYY')" & c

                        Dim res As String
                        res = "TO_DATE('" & Microsoft.VisualBasic.Format(cadena, "HH:mm") & "','HH:MI')"

                        Return res


                        'Return c & Microsoft.VisualBasic.Format(cadena, "ddMMyyyy") & c
                    Case Else
                        Return GL_VACIO
                End Select

            End If
        End Function
        Public Shared Function DTR_es_True(ByVal cadena As Object) As Boolean
            If IsDBNull(cadena) Then
                Return False
            Else
                Return CBool(cadena)
            End If
        End Function
        Public Shared Function DTR_es_False(ByVal cadena As Object) As Boolean
            If IsDBNull(cadena) Then
                Return False
            Else
                Return CBool(cadena)
            End If
        End Function
        Public Shared Function pf_ReplaceTrueFalse(ByVal cadena As Boolean) As Byte
            If cadena Then
                Return 1
            Else
                Return 0
            End If
        End Function
        Public Shared Function pf_ReplaceTrueFalseNull(ByVal cadena As Object, Optional ByVal NULLVALUE As String = "NULL") As String
            If IsDBNull(cadena) Then
                Return NULLVALUE
            ElseIf cadena Then
                Return 1
            Else
                Return 0
            End If
        End Function
        Public Shared Function pf_ReplaceIntNull(ByVal cadena As Object, Optional ByVal NULLVALUE As String = "NULL") As String
            If IsDBNull(cadena) Then
                Return NULLVALUE
            Else
                Return cadena
            End If
        End Function

        Public Shared Function ComprobarYCrearCarpetas(ByVal Directorio As String, Optional ByVal AñadirDirectoryPath As Boolean = False) As String
            If AñadirDirectoryPath Then
                Directorio = clVariables.RutaServidor & "\" & Directorio
            End If
            If Not IO.Directory.Exists(Directorio) Then
                IO.Directory.CreateDirectory(Directorio)
            End If
            Return Directorio
        End Function

        Public Shared Function ReplacePuntos(ByVal Sentencia As String) As String
            Return Replace(Sentencia, ",", ".")
        End Function

        Public Shared Function Redondear(ByVal txt As String, Optional ByVal NumDecimales As Integer = 2)
            If Not IsNumeric(txt) Then
                Return 0
            End If
            Return Math.Round(CDbl(txt), NumDecimales)
        End Function
        Public Shared Sub ValidarNumeros(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal txt As TextBox, Optional ByVal Negativos As Boolean = True, Optional ByVal Decimales As Boolean = True)

            'Función que permite validar números.
            'Permite:
            '1. Números
            '2. Signo menos (opcional). Solo si es el primer caracter
            '3. Comas. (Opcional) Valida que solo pueda haber una, no sea el primer caracter ni el segundo en caso de que el primero sea un menos
            '4. Puntos. (Opcional) Lo cambia por una coma. Mismas validaciones que comas.
            '5. La tecla BackEspace (Keys.Back)
            '6. La tecla Enter (Keys.Return) que efectuará una tabulación

            If Char.IsNumber(e.KeyChar) Then
                Exit Sub
            End If

            If Negativos Then
                If e.KeyChar = "-" And txt.Text.Length = 0 Then
                    Exit Sub
                End If
            End If

            If Decimales Then
                If e.KeyChar = "," And InStr(txt.Text, ",") = 0 And txt.Text.Length > 0 And Not (txt.Text.Length = 1 And txt.Text = "-") Then
                    Exit Sub
                End If

                If e.KeyChar = "." And InStr(txt.Text, ",") = 0 And txt.Text.Length > 0 And Not (txt.Text.Length = 1 And txt.Text = "-") Then
                    SendKeys.Send(",")
                    e.Handled = True
                    Exit Sub
                End If
            End If

            'If e.KeyChar = "," Or e.KeyChar = "." Then
            '    If txtHoras.Text.Contains(",") Or txt.Text.Length = 0 Or (txt.Text.Length =1 And txt.Text = "-") Then
            '        e.Handled = True
            '    End If
            '    If e.KeyChar = "." Then
            '        SendKeys.Send(",")
            '        e.Handled = True
            '    End If
            '    Exit Sub
            'End If



            If e.KeyChar = Convert.ToChar(Keys.Back) Then
                Exit Sub
            End If

            e.Handled = True



        End Sub

        Public Shared Function ReplaceNIFCIFClientes(ByVal NIFCIF As String) As String
            NIFCIF = Replace(NIFCIF, ",", "")
            NIFCIF = Replace(NIFCIF, "-", "")
            NIFCIF = Replace(NIFCIF, ".", "")
            NIFCIF = Replace(NIFCIF, " ", "")
            If NIFCIF Is Nothing Then
                Return ""
            Else
                Return (NIFCIF)
            End If

        End Function

        Public Shared Sub ControlFormularios(ByVal sender As Object)
            'Procedimiento para saber cual es el formulario que acabamos de Abrir
            Dim FormularioActivo As String
            FormularioActivo = CType(sender, Form).Name
            'MsgBox("El formulario Activo es : " & FormularioActivo)
        End Sub



        Public Shared Function validar_Mail(ByVal sMail As String) As Boolean

            Dim Res As Boolean = False

            If sMail.Trim = "" Then
                Return True
            Else
                ' retorna true o false    

                Dim Emails As String() = Split(sMail, ";")

                For i = 0 To Emails.Length - 1
                    If Emails(i) <> "" Then
                        Res = System.Text.RegularExpressions.Regex.IsMatch(Emails(i),
                                               "^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$")


                    End If
                Next

                Return Res


            End If



        End Function
        Public Shared Function DevuelveTablaFiltrada(ByVal dt As DataTable, ByVal Filtro As String, Optional ByVal sort As String = "") As DataTable

            Dim rows As DataRow()
            Dim dtNew As DataTable

            ' Nos quedamos con las filas filtradas y ordenadas
            rows = dt.Select(Filtro, sort)

            'Vamos a meterlas en un nuevo dt
            ' Para ello, 1) Copiamos la estructura 2) Lo rellenamos con las filas
            dtNew = dt.Clone()
            For Each dr As DataRow In rows
                dtNew.ImportRow(dr)
            Next
            ' Devolvemos un dt con el filtro
            Return dtNew
        End Function
        Public Shared Function nombreColumna(ByVal numero As Integer) As String
            'Funcion que utiliza GenerarExcel para dar nombre a las celdas de la hoja que generamos
            Dim columna(256) As String

            columna(1) = "A"
            columna(2) = "B"
            columna(3) = "C"
            columna(4) = "D"
            columna(5) = "E"
            columna(6) = "F"
            columna(7) = "G"
            columna(8) = "H"
            columna(9) = "I"
            columna(10) = "J"
            columna(11) = "K"
            columna(12) = "L"
            columna(13) = "M"
            columna(14) = "N"
            columna(15) = "O"
            columna(16) = "P"
            columna(17) = "Q"
            columna(18) = "R"
            columna(19) = "S"
            columna(20) = "T"
            columna(21) = "U"
            columna(22) = "V"
            columna(23) = "W"
            columna(24) = "X"
            columna(25) = "Y"
            columna(26) = "Z"
            columna(27) = "AA"
            columna(28) = "AB"
            columna(29) = "AC"
            columna(30) = "AD"
            columna(31) = "AE"
            columna(32) = "AF"
            columna(33) = "AG"
            columna(34) = "AH"
            columna(35) = "AI"
            columna(36) = "AJ"
            columna(37) = "AK"
            columna(38) = "AL"
            columna(39) = "AM"
            columna(40) = "AN"
            columna(41) = "AO"
            columna(42) = "AP"
            columna(43) = "AQ"
            columna(44) = "AR"
            columna(45) = "AS"
            columna(46) = "AT"
            columna(47) = "AU"
            columna(48) = "AV"
            columna(49) = "AW"
            columna(50) = "AX"
            columna(51) = "AY"
            columna(52) = "AZ"
            columna(53) = "BA"
            columna(54) = "BB"
            columna(55) = "BC"
            columna(56) = "BD"
            columna(57) = "BE"
            columna(58) = "BF"
            columna(59) = "BG"
            columna(60) = "BH"
            columna(61) = "BI"
            columna(62) = "BJ"
            columna(63) = "BK"
            columna(64) = "BL"
            columna(65) = "BM"
            columna(66) = "BN"
            columna(67) = "BO"
            columna(68) = "BP"
            columna(69) = "BQ"
            columna(70) = "BR"
            columna(71) = "BS"
            columna(72) = "BT"
            columna(73) = "BU"
            columna(74) = "BV"
            columna(75) = "BW"
            columna(76) = "BX"
            columna(77) = "BY"
            columna(78) = "BZ"
            columna(79) = "CA"
            columna(80) = "CB"
            columna(81) = "CC"
            columna(82) = "CD"
            columna(83) = "CE"
            columna(84) = "CF"
            columna(85) = "CG"
            columna(86) = "CH"
            columna(87) = "CI"
            columna(88) = "CJ"
            columna(89) = "CK"
            columna(90) = "CL"
            columna(91) = "CM"
            columna(92) = "CN"
            columna(93) = "CO"
            columna(94) = "CP"
            columna(95) = "CQ"
            columna(96) = "CR"
            columna(97) = "CS"
            columna(98) = "CT"
            columna(99) = "CU"
            columna(100) = "CV"
            columna(101) = "CW"
            columna(102) = "CX"
            columna(103) = "CY"
            columna(104) = "CZ"
            columna(105) = "DA"
            columna(106) = "DB"
            columna(107) = "DC"
            columna(108) = "DD"
            columna(109) = "DE"
            columna(110) = "DF"
            columna(111) = "DG"
            columna(112) = "DH"
            columna(113) = "DI"
            columna(114) = "DJ"
            columna(115) = "DK"
            columna(116) = "DL"
            columna(117) = "DM"
            columna(118) = "DN"
            columna(119) = "DO"
            columna(120) = "DP"
            columna(121) = "DQ"
            columna(122) = "DR"
            columna(123) = "DS"
            columna(124) = "DT"
            columna(125) = "DU"
            columna(126) = "DV"
            columna(127) = "DW"
            columna(128) = "DX"
            columna(129) = "DY"
            columna(130) = "DZ"
            columna(131) = "EA"
            columna(132) = "EB"
            columna(133) = "EC"
            columna(134) = "ED"
            columna(135) = "EE"
            columna(136) = "EF"
            columna(137) = "EG"
            columna(138) = "EH"
            columna(139) = "EI"
            columna(140) = "EJ"
            columna(141) = "EK"
            columna(142) = "EL"
            columna(143) = "EM"
            columna(144) = "EN"
            columna(145) = "EO"
            columna(146) = "EP"
            columna(147) = "EQ"
            columna(148) = "ER"
            columna(149) = "ES"
            columna(150) = "ET"
            columna(151) = "EU"
            columna(152) = "EV"
            columna(153) = "EW"
            columna(154) = "EX"
            columna(155) = "EY"
            columna(156) = "EZ"
            columna(157) = "FA"
            columna(158) = "FB"
            columna(159) = "FC"
            columna(160) = "FD"
            columna(161) = "FE"
            columna(162) = "FF"
            columna(163) = "FG"
            columna(164) = "FH"
            columna(165) = "FI"
            columna(166) = "FJ"
            columna(167) = "FK"
            columna(168) = "FL"
            columna(169) = "FM"
            columna(170) = "FN"
            columna(171) = "FO"
            columna(172) = "FP"
            columna(173) = "FQ"
            columna(174) = "FR"
            columna(175) = "FS"
            columna(176) = "FT"
            columna(177) = "FU"
            columna(178) = "FV"
            columna(179) = "FW"
            columna(180) = "FX"
            columna(181) = "FY"
            columna(182) = "FZ"
            columna(183) = "GA"
            columna(184) = "GB"
            columna(185) = "GC"
            columna(186) = "GD"
            columna(187) = "GE"
            columna(188) = "GF"
            columna(189) = "GG"
            columna(190) = "GH"
            columna(191) = "GI"
            columna(192) = "GJ"
            columna(193) = "GK"
            columna(194) = "GL"
            columna(195) = "GM"
            columna(196) = "GN"
            columna(197) = "GO"
            columna(198) = "GP"
            columna(199) = "GQ"
            columna(200) = "GR"
            columna(201) = "GS"
            columna(202) = "GT"
            columna(203) = "GU"
            columna(204) = "GV"
            columna(205) = "GW"
            columna(206) = "GX"
            columna(207) = "GY"
            columna(208) = "GZ"
            columna(209) = "HA"
            columna(210) = "HB"
            columna(211) = "HC"
            columna(212) = "HD"
            columna(213) = "HE"
            columna(214) = "HF"
            columna(215) = "HG"
            columna(216) = "HH"
            columna(217) = "HI"
            columna(218) = "HJ"
            columna(219) = "HK"
            columna(220) = "HL"
            columna(221) = "HM"
            columna(222) = "HN"
            columna(223) = "HO"
            columna(224) = "HP"
            columna(225) = "HQ"
            columna(226) = "HR"
            columna(227) = "HS"
            columna(228) = "HT"
            columna(229) = "HU"
            columna(230) = "HV"
            columna(231) = "HW"
            columna(232) = "HX"
            columna(233) = "HY"
            columna(234) = "HZ"
            columna(235) = "IA"
            columna(236) = "IB"
            columna(237) = "IC"
            columna(238) = "ID"
            columna(239) = "IE"
            columna(240) = "IF"
            columna(241) = "IG"
            columna(242) = "IH"
            columna(243) = "II"
            columna(244) = "IJ"
            columna(245) = "IK"
            columna(246) = "IL"
            columna(247) = "IM"
            columna(248) = "IN"
            columna(249) = "IO"
            columna(250) = "IP"
            columna(251) = "IQ"
            columna(252) = "IR"
            columna(253) = "IS"
            columna(254) = "IT"
            columna(255) = "IU"
            columna(256) = "IV"

            Return (columna(numero))
        End Function



        Public Shared Function SubirArchivoAlServidor(ByVal ArchivoOrigen As String, ByVal ServidorDestino As String, ByVal UsuarioServidor As String, ByVal ClaveServidor As String) As Boolean
            Try
                My.Computer.Network.UploadFile(ArchivoOrigen, ServidorDestino, UsuarioServidor, ClaveServidor)
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function

        Public Shared Function ComprobarFechas(ByVal msk As MaskedTextBox, Optional ByVal Fecha As Boolean = True) As Boolean

            Dim Longitud As Integer

            If Fecha Then
                Longitud = 10
            Else
                Longitud = 5
            End If

            If Not IsDate(msk.Text) Or InStr(msk.Text, " ") > 0 Or InStr(msk.Text, "_") > 0 Or Len(msk.Text) < Longitud Then
                Return False
            Else
                Return True
            End If
        End Function



        Public Shared Sub VerDocumentos(ByVal Carpeta As String)
            If Not System.IO.Directory.Exists(Carpeta) Then
                MensajeError("No hay ningún fichero asociado")
                Exit Sub
            End If

            Shell("explorer.exe root = " & Carpeta, vbNormalFocus)
        End Sub

        Public Shared Sub ChequearDeschequearClb(ByVal clb As DevExpress.XtraEditors.CheckedListBoxControl, ByVal Chequear As Boolean)
            For i = 0 To clb.Items.Count - 1
                clb.SetItemChecked(i, Chequear)
            Next
        End Sub
        'Public Sub AbrirFincasEvento(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)

        '    AbrirFincas(e.Item.Caption)


        'End Sub

        'Public Sub AbrirFincas(ByVal Municipio As String)

        '    GL_MunicipioSeleccionado = Municipio

        '    If frmFincas.IsHandleCreated Then
        '        frmFincas.Dispose()
        '    End If

        '    frmFincas.MdiParent = frmPrincipal
        '    frmPrincipal.siStatus.Caption = "Fincas"
        '    frmFincas.Show()


        'End Sub

        '     Public Shared Function EnviarCorreo(ByVal EmailDestino As String, ByVal Asunto As String, ByVal Texto As String, Optional ByVal Adjuntos As String = "", Optional ByVal MostrarPantallaTexto As Boolean = False, Optional UtilizarElGestorDeCorreoDelUsuario As Boolean = False) As String
        Public Shared Function EnviarCorreo(ByVal EmailDestino As String, ByVal Asunto As String, ByVal Texto As String, Optional ByVal UtilizarElGestorDeCorreoDelUsuario As Boolean = False, Optional ByVal Adjuntos As String = "", Optional ByVal MostrarPantallaTexto As Boolean = False, Optional ByVal EnviarmeCopiaOculta As Boolean = False, Optional ByVal DatosEmail As Tablas.cl_DatosEmail = Nothing, Optional ByVal EmailDestinoConNombreDestinatario As System.Net.Mail.MailAddressCollection = Nothing, Optional ByVal Html As Boolean = False) As String

            'Dim bd As New BaseDatos
            'Dim Correo As String
            'Correo = bd.Execute("select Email from Usuarios where Usuario = '" & GL_Usuario & "'", False)

            If Trim(EmailDestino) = "" Then
                Return "El email del destinatario no puede estar vacio"
            End If

            If Not validar_Mail(EmailDestino) Then
                Return "El email " & EmailDestino & " no tiene un formato válido"
            End If

            If UtilizarElGestorDeCorreoDelUsuario Then
                'Envia correo con el gestor de correo predeterminado del ordenador si el usuario no tiene
                'cuenta de correo configurada en la aplicación

                '    'comprobamos si viene adjunto un archivo
                Try
                    If Adjuntos <> "" Then
                        Dim mapi As New SendFileTo.MAPI
                        'Metemos todos los adjuntos
                        Dim adjtos() As String
                        adjtos = Split(Adjuntos, ";")
                        For i = 0 To adjtos.Length - 1
                            mapi.AddAttachment(adjtos(i))
                        Next
                        'Metemos todas las direcciones de destino
                        Dim Reci() As String
                        Reci = Split(EmailDestino, ";")
                        For i = 0 To 0
                            If Trim(Reci(i)) <> "" Then
                                mapi.AddRecipientTo(Reci(i))
                            End If
                        Next

                        For i = 1 To Reci.Length - 1
                            If Trim(Reci(i)) <> "" Then
                                mapi.AddRecipientCC(Reci(i))
                            End If
                        Next


                        mapi.SendMailPopup(Asunto, Texto)
                    Else
                        Diagnostics.Process.Start("mailto:" & EmailDestino & "?subject=" & Asunto & ", " & Texto)
                    End If
                    Return ""
                Catch ex As Exception
                    MensajeError(ex.Message)
                    Return (ex.Message)
                End Try


            Else
                'envio con cuenta de correo configurada en la aplicación
                Return EnviarCorreoConCuentaConfigurada(EmailDestino, Asunto, Texto, Adjuntos, MostrarPantallaTexto, EnviarmeCopiaOculta, DatosEmail, EmailDestinoConNombreDestinatario, Html)
            End If

        End Function
        Public Shared Function EnviarCorreoConCuentaConfigurada(ByVal EmailDestino As String, ByVal Asunto As String, ByVal Texto As String, Optional ByVal Adjuntos As String = "", Optional ByVal MostrarPantallaTexto As Boolean = False, Optional ByVal EnviarmeCopiaOculta As Boolean = False, Optional ByVal DatosEmail As Tablas.cl_DatosEmail = Nothing, Optional ByVal EmailDestinoConNombreDestinatario As System.Net.Mail.MailAddressCollection = Nothing, Optional ByVal Html As Boolean = False) As String

            Dim Origen As String
            Dim PuertoSMTP As String
            Dim Contrasena As String
            Dim Usuario As String
            Dim smtpleido As String
            Dim SSL As Boolean
            Dim NombreMostrar As String

            Dim smtp As New Net.Mail.SmtpClient()
            Dim msg As New Net.Mail.MailMessage
            Dim exito As Boolean = True

            If DatosEmail Is Nothing Then
                DatosEmail = New Tablas.cl_DatosEmail(DatosEmpresa.Codigo)
            End If

            'If Debugger.IsAttached Then
            '    Origen = "roberto@tresbits.es"
            '    PuertoSMTP = 587
            '    Usuario = "roberto@tresbits.es"
            '    Contrasena = "sm#1234"
            '    smtpleido = "mail.tresbits.es"
            'Else
            Origen = DatosEmail.Email
            PuertoSMTP = DatosEmail.PuertoSMTP
            Contrasena = DatosEmail.Contrasena
            smtpleido = DatosEmail.SMTP
            Usuario = DatosEmail.Usuario
            SSL = DatosEmail.SSL
            '  End If

            NombreMostrar = DatosEmail.NombreMostrar

            If MostrarPantallaTexto Then
                FrmIntroducirTextoMensaje.txtTexto.Text = ""
                FrmIntroducirTextoMensaje.ShowDialog()
                Texto = FrmIntroducirTextoMensaje.txtTexto.Text
            End If

            msg.Subject = Asunto
            msg.Body = Texto

            If NombreMostrar = "" Then
                NombreMostrar = Origen
            End If
            msg.From = New Net.Mail.MailAddress(Origen, NombreMostrar)

            'Metemos todas las direcciones de destino

            If EmailDestinoConNombreDestinatario Is Nothing Then
                Dim Reci() As String
                Reci = Split(EmailDestino, ";")

                For i = 0 To 0
                    msg.To.Add(Reci(i))
                Next

                For i = 1 To Reci.Length - 1
                    msg.CC.Add(Reci(i))
                Next
            Else
                Dim i As Integer = 0
                For Each c As System.Net.Mail.MailAddress In EmailDestinoConNombreDestinatario
                    If i = 0 Then
                        msg.To.Add(c)
                        i = 1
                    Else
                        msg.CC.Add(c)
                    End If

                Next

            End If

            'msg.To.Add("nataliauim@hotmail.com")
            'msg.CC.Add("joseciFRE@TRESBITS.ES")


            If EnviarmeCopiaOculta Then
                msg.Bcc.Add(Origen)
            End If

            'Miramos si tiene algún fichero adjunto
            If Adjuntos <> "" Then
                'Metemos todos los adjuntos
                Dim adjtos() As String
                adjtos = Split(Adjuntos, ";")
                For i = 0 To adjtos.Length - 1
                    msg.Attachments.Add((New Net.Mail.Attachment(adjtos(i))))
                Next
            End If
            smtp.Host = smtpleido
            smtp.Port = PuertoSMTP
            smtp.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network

            smtp.UseDefaultCredentials = False
            smtp.Credentials = New System.Net.NetworkCredential(Usuario, Contrasena)
            smtp.EnableSsl = SSL
            msg.IsBodyHtml = Html


            If msg.IsBodyHtml Then
                msg.Body = New Text.RegularExpressions.Regex("\n\r").Replace(msg.Body, "<br />")
                msg.Body = New Text.RegularExpressions.Regex("\n").Replace(msg.Body, "<br />")
                msg.Body = New Text.RegularExpressions.Regex("\r").Replace(msg.Body, "<br />")

            End If


            ' msg.IsBodyHtml = False
            Try

                ''smtp.EnableSsl = True
                'Try
                '    Dim notifyOnFailureAndsuccess As Object = DeliveryNotificationOptions.OnFailure
                '    msg.DeliveryNotificationOptions = msg.DeliveryNotificationOptions Xor DeliveryNotificationOptions.None
                '    msg.Headers.Add("Disposition-Notification-To", "NATALIAUIM@hotmail.com")
                '    msg.Headers.Add("Return-Receipt-To", "NATALIAUIM@hotmail.com")

                'Catch ex As Exception

                'End Try

                smtp.Send(msg)
                Return ""

            Catch ex As SqlClient.SqlException
                MensajeError("Error 1 " & ex.Message)
                Return ("Error 1 " & ex.Message)
            Catch ex As System.Net.WebException
                MensajeError("Error 2 " & ex.Message)
                Return ("Error 2 " & ex.Message)
            Catch ex As Exception
                MensajeError("Error 3 " & ex.Message)
                Return ("Error 3 " & ex.Message)
                'Finally
                '    If exito Then
                '        MsgBox("Se envió el correo a " & EmailDestino & " con exito.")
                '    Else
                '        MsgBox("No se pudo enviar el correo a " & EmailDestino & ".")
                '    End If
            End Try


        End Function

        Public Shared Function EnviarCorreoConCuentaConfiguradaConImagen(ByVal EmailDestino As String, ByVal Asunto As String, ByVal Texto As String, Optional ByVal Adjuntos As String = "", Optional ByVal MostrarPantallaTexto As Boolean = False, Optional ByVal EnviarmeCopiaOculta As Boolean = False, Optional ByVal DatosEmail As Tablas.cl_DatosEmail = Nothing, Optional ByVal EmailDestinoConNombreDestinatario As System.Net.Mail.MailAddressCollection = Nothing, Optional ByVal Html As Boolean = False) As String

            Dim Origen As String
            Dim PuertoSMTP As String
            Dim Contrasena As String
            Dim Usuario As String
            Dim smtpleido As String
            Dim SSL As Boolean
            Dim NombreMostrar As String

            Dim smtp As New Net.Mail.SmtpClient()
            Dim msg As New Net.Mail.MailMessage
            Dim exito As Boolean = True

            If DatosEmail Is Nothing Then
                DatosEmail = New Tablas.cl_DatosEmail(DatosEmpresa.Codigo)
            End If

            If Debugger.IsAttached Then
                Origen = "info@tresbits.es"
                PuertoSMTP = 587
                Usuario = "info@tresbits.es"
                'Usuario = "roberto@tresbits.es"
                ' Contrasena = "sm#1234"
                Contrasena = "in1234#TB"
                smtpleido = "mail.tresbits.es"
            Else
                Origen = DatosEmail.Email
                PuertoSMTP = DatosEmail.PuertoSMTP
                Contrasena = DatosEmail.Contrasena
                smtpleido = DatosEmail.SMTP
                Usuario = DatosEmail.Usuario
                SSL = DatosEmail.SSL
            End If

            NombreMostrar = DatosEmail.NombreMostrar

            If MostrarPantallaTexto Then
                FrmIntroducirTextoMensaje.txtTexto.Text = ""
                FrmIntroducirTextoMensaje.ShowDialog()
                Texto = FrmIntroducirTextoMensaje.txtTexto.Text
            End If

            msg.Subject = Asunto
            msg.Body = Texto

            If NombreMostrar = "" Then
                NombreMostrar = Origen
            End If
            msg.From = New Net.Mail.MailAddress(Origen, NombreMostrar)

            'Metemos todas las direcciones de destino

            If EmailDestinoConNombreDestinatario Is Nothing Then
                Dim Reci() As String
                Reci = Split(EmailDestino, ";")

                For i = 0 To 0
                    msg.To.Add(Reci(i))
                Next

                For i = 1 To Reci.Length - 1
                    msg.CC.Add(Reci(i))
                Next
            Else
                Dim i As Integer = 0
                For Each c As System.Net.Mail.MailAddress In EmailDestinoConNombreDestinatario
                    If i = 0 Then
                        msg.To.Add(c)
                        i = 1
                    Else
                        msg.CC.Add(c)
                    End If

                Next

            End If



            If EnviarmeCopiaOculta Then
                msg.Bcc.Add(Origen)
            End If

            'Miramos si tiene algún fichero adjunto
            If Adjuntos <> "" Then
                'Metemos todos los adjuntos
                Dim adjtos() As String
                adjtos = Split(Adjuntos, ";")
                For i = 0 To adjtos.Length - 1
                    msg.Attachments.Add((New Net.Mail.Attachment(adjtos(i))))
                Next
            End If
            smtp.Host = smtpleido
            smtp.Port = PuertoSMTP
            smtp.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network

            smtp.UseDefaultCredentials = False
            smtp.Credentials = New System.Net.NetworkCredential(Usuario, Contrasena)
            smtp.EnableSsl = SSL
            msg.IsBodyHtml = Html


            '********************
            'Dim plainView As AlternateView = AlternateView.CreateAlternateViewFromString(Texto, System.Text.Encoding.UTF8, "text/plain")

            'Dim ImagenGoogle As String = "<div style=""background: url(http://www.megustaprobarcosas.com/web/imagenes/enlaceGooglePlayPeq.png); background-repeat:no-repeat; width:400px;height:100px; z-index:1;""><br><br>  <table><tr><td>&nbsp <a href=""http://www.megustaprobarcosas.com/blog/consumolab-mobile-tu-nueva-aplicacion-para-dispositivos-moviles/"" target=""_blank"">  <img src=""http://www.megustaprobarcosas.com/web/imagenes/enlaceBlog.png"" border=""0"" height=""50px"" /></a></td>  <td>  <a href=""https://play.google.com/store/apps/details?id=com.cdata.consumolab&hl=es"" target=""_blank""> <img src=""http://www.megustaprobarcosas.com/web/imagenes/enlaceGoogle.png"" border=""0""  height=""50px"" /></a>  </td></tr></table>    </div>"
            'Dim ImagenGoogle As String = "<div style=""background: url(http://www.megustaprobarcosas.com/web/imagenes/enlaceGooglePlayPeq.png); background-repeat:no-repeat; width:400px;height:100px; z-index:1;""><br><br>  <table><tr><td>&nbsp <a href=""http://www.megustaprobarcosas.com/blog/consumolab-mobile-tu-nueva-aplicacion-para-dispositivos-moviles/"" target=""_blank""> <img src=cid:enlaceBlog border=""0"" height=""50px"" /></a></td>  <td>  <a href=""https://play.google.com/store/apps/details?id=com.cdata.consumolab&hl=es"" target=""_blank""> <img src=cid:enlaceGoogle border=""0""  height=""50px"" /></a>  </td></tr></table>    </div>"
            '  Dim ImagenGoogle As String = "<div style=""background-image: img src=cid:enlaceGooglePlayPeq url(cid:enlaceGooglePlayPeq); background-repeat:no-repeat; width:400px;height:100px; z-index:1;""><br><br>  <table><tr><td>&nbsp <a href=""http://www.megustaprobarcosas.com/blog/consumolab-mobile-tu-nueva-aplicacion-para-dispositivos-moviles/"" target=""_blank""> <img src=cid:enlaceBlog border=""0"" height=""50px"" /></a></td>  <td>  <a href=""https://play.google.com/store/apps/details?id=com.cdata.consumolab&hl=es"" target=""_blank""> <img src=cid:enlaceGoogle border=""0""  height=""50px"" /></a>  </td></tr></table>    </div>"

            '     Dim ImagenGoogle As String = "<div style=""background-image: src=cid:enlaceGooglePlayPeq; background-repeat:no-repeat; width:400px; height:50px; z-index:1; />   <br><br>  <table><tr><td>&nbsp <a href=""http://www.megustaprobarcosas.com/blog/consumolab-mobile-tu-nueva-aplicacion-para-dispositivos-moviles/"" target=""_blank""> <img src=cid:enlaceBlog border=""0"" height=""50px"" /></a></td>  <td>  <a href=""https://play.google.com/store/apps/details?id=com.cdata.consumolab&hl=es"" target=""_blank""> <img src=cid:enlaceGoogle border=""0""  height=""50px"" /></a>  </td></tr></table>    </div>"

            'background-image:url(cid:BackgroundImage)


            'then we create the Html part
            'to embed images, we need to use the prefix 'cid' in the img src value
            'the cid value will map to the Content-Id of a Linked resource.
            'thus <img src='cid:companylogo'> will map to a LinkedResource with a ContentId of 'companylogo'
            '  Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString("Here is an embedded image.<img src=cid:companylogo>", Nothing, "text/html")


            Texto = New System.Text.RegularExpressions.Regex("\n\r").Replace(Texto, "<br />")
            Texto = New System.Text.RegularExpressions.Regex("\n").Replace(Texto, "<br />")
            'Texto = New System.Text.RegularExpressions.Regex("\r").Replace(Texto, "<br />")


            '    Texto = Replace(Texto, "<br /><br /><br /><br /><br /><br />", "<br /><br /><br /><br />")
            ''      Texto = Replace(Texto, "<br /><br />Muchas gracias", "<br />Muchas gracias")

            Texto = vbCrLf & vbCrLf & Texto

            Dim plainView As AlternateView = AlternateView.CreateAlternateViewFromString(Texto, System.Text.Encoding.UTF8, "text/plain")


            Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString("<img src=cid:enlaceBlog> <br /><br />" & Texto, System.Text.Encoding.UTF8, "text/html")
            ' Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString("<img src=cid:enlaceBlog> <br /><br />", System.Text.Encoding.UTF8, "text/html")

            'create the LinkedResource (embedded image)
            Dim logo As LinkedResource
            logo = New LinkedResource(clVariables.RutaServidor & "\ainia.png")
            logo.ContentId = "enlaceBlog"
            'add the LinkedResource to the appropriate view
            htmlView.LinkedResources.Add(logo)


            'add the views

            '  msg.AlternateViews.Add(plainView)
            msg.AlternateViews.Add(htmlView)
            msg.AlternateViews.Add(plainView)
            '*****************************************************'


            If msg.IsBodyHtml Then
                msg.Body = New Text.RegularExpressions.Regex("\n\r").Replace(msg.Body, "<br />")
                msg.Body = New Text.RegularExpressions.Regex("\n").Replace(msg.Body, "<br />")
                msg.Body = New Text.RegularExpressions.Regex("\r").Replace(msg.Body, "<br />")

            End If


            ' msg.IsBodyHtml = False
            Try

                'smtp.EnableSsl = True
                smtp.Send(msg)
                Return ""

            Catch ex As SqlClient.SqlException
                MensajeError(ex.Message)
                Return (ex.Message)
            Catch ex As System.Net.WebException
                MensajeError(ex.Message)
                Return (ex.Message)
            Catch ex As Exception
                MensajeError(ex.Message)
                Return (ex.Message)
                'Finally
                '    If exito Then
                '        MsgBox("Se envió el correo a " & EmailDestino & " con exito.")
                '    Else
                '        MsgBox("No se pudo enviar el correo a " & EmailDestino & ".")
                '    End If
            End Try


        End Function


        Public Shared Function EnviarCorreoTrasteroUIM(EmailDestino As String, ByVal Asunto As String, Optional ByVal Html As Boolean = False) As String

            Dim Origen As String
            Dim PuertoSMTP As String
            Dim Contrasena As String
            Dim Usuario As String
            Dim smtpleido As String
            Dim SSL As Boolean
            Dim NombreMostrar As String

            Dim smtp As New Net.Mail.SmtpClient()
            Dim msg As New Net.Mail.MailMessage
            Dim exito As Boolean = True


            Dim DatosEmail As Tablas.cl_DatosEmail
            If DatosEmail Is Nothing Then
                DatosEmail = New Tablas.cl_DatosEmail(DatosEmpresa.Codigo)
            End If

            If Debugger.IsAttached Then


                Origen = "info@tresbits.es"
                PuertoSMTP = 587
                Usuario = "info@tresbits.es"
                'Usuario = "roberto@tresbits.es"
                ' Contrasena = "sm#1234"
                Contrasena = "in1234#TB"
                smtpleido = "mail.tresbits.es"
            Else
                Origen = DatosEmail.Email
                PuertoSMTP = DatosEmail.PuertoSMTP
                Contrasena = DatosEmail.Contrasena
                smtpleido = DatosEmail.SMTP
                Usuario = DatosEmail.Usuario
                SSL = DatosEmail.SSL
            End If

            NombreMostrar = DatosEmail.NombreMostrar



            msg.Subject = Asunto
            '    msg.Body = Texto

            If NombreMostrar = "" Then
                NombreMostrar = Origen
            End If
            msg.From = New Net.Mail.MailAddress(Origen, NombreMostrar)

            'Metemos todas las direcciones de destino



            Dim Reci() As String
            Reci = Split(EmailDestino, ";")

            For i = 0 To 0
                msg.To.Add(Reci(i))
            Next

            For i = 1 To Reci.Length - 1
                msg.CC.Add(Reci(i))
            Next

            smtp.Host = smtpleido
            smtp.Port = PuertoSMTP
            smtp.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network

            smtp.UseDefaultCredentials = False
            smtp.Credentials = New System.Net.NetworkCredential(Usuario, Contrasena)
            smtp.EnableSsl = SSL
            msg.IsBodyHtml = Html


            '********************
            'Dim plainView As AlternateView = AlternateView.CreateAlternateViewFromString(Texto, System.Text.Encoding.UTF8, "text/plain")

            'Dim ImagenGoogle As String = "<div style=""background: url(http://www.megustaprobarcosas.com/web/imagenes/enlaceGooglePlayPeq.png); background-repeat:no-repeat; width:400px;height:100px; z-index:1;""><br><br>  <table><tr><td>&nbsp <a href=""http://www.megustaprobarcosas.com/blog/consumolab-mobile-tu-nueva-aplicacion-para-dispositivos-moviles/"" target=""_blank"">  <img src=""http://www.megustaprobarcosas.com/web/imagenes/enlaceImagen.png"" border=""0"" height=""50px"" /></a></td>  <td>  <a href=""https://play.google.com/store/apps/details?id=com.cdata.consumolab&hl=es"" target=""_blank""> <img src=""http://www.megustaprobarcosas.com/web/imagenes/enlaceGoogle.png"" border=""0""  height=""50px"" /></a>  </td></tr></table>    </div>"
            'Dim ImagenGoogle As String = "<div style=""background: url(http://www.megustaprobarcosas.com/web/imagenes/enlaceGooglePlayPeq.png); background-repeat:no-repeat; width:400px;height:100px; z-index:1;""><br><br>  <table><tr><td>&nbsp <a href=""http://www.megustaprobarcosas.com/blog/consumolab-mobile-tu-nueva-aplicacion-para-dispositivos-moviles/"" target=""_blank""> <img src=cid:enlaceImagen border=""0"" height=""50px"" /></a></td>  <td>  <a href=""https://play.google.com/store/apps/details?id=com.cdata.consumolab&hl=es"" target=""_blank""> <img src=cid:enlaceGoogle border=""0""  height=""50px"" /></a>  </td></tr></table>    </div>"
            '  Dim ImagenGoogle As String = "<div style=""background-image: img src=cid:enlaceGooglePlayPeq url(cid:enlaceGooglePlayPeq); background-repeat:no-repeat; width:400px;height:100px; z-index:1;""><br><br>  <table><tr><td>&nbsp <a href=""http://www.megustaprobarcosas.com/blog/consumolab-mobile-tu-nueva-aplicacion-para-dispositivos-moviles/"" target=""_blank""> <img src=cid:enlaceImagen border=""0"" height=""50px"" /></a></td>  <td>  <a href=""https://play.google.com/store/apps/details?id=com.cdata.consumolab&hl=es"" target=""_blank""> <img src=cid:enlaceGoogle border=""0""  height=""50px"" /></a>  </td></tr></table>    </div>"

            '     Dim ImagenGoogle As String = "<div style=""background-image: src=cid:enlaceGooglePlayPeq; background-repeat:no-repeat; width:400px; height:50px; z-index:1; />   <br><br>  <table><tr><td>&nbsp <a href=""http://www.megustaprobarcosas.com/blog/consumolab-mobile-tu-nueva-aplicacion-para-dispositivos-moviles/"" target=""_blank""> <img src=cid:enlaceImagen border=""0"" height=""50px"" /></a></td>  <td>  <a href=""https://play.google.com/store/apps/details?id=com.cdata.consumolab&hl=es"" target=""_blank""> <img src=cid:enlaceGoogle border=""0""  height=""50px"" /></a>  </td></tr></table>    </div>"

            'background-image:url(cid:BackgroundImage)


            'then we create the Html part
            'to embed images, we need to use the prefix 'cid' in the img src value
            'the cid value will map to the Content-Id of a Linked resource.
            'thus <img src='cid:companylogo'> will map to a LinkedResource with a ContentId of 'companylogo'
            '  Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString("Here is an embedded image.<img src=cid:companylogo>", Nothing, "text/html")

            Dim Texto1 As String
            Dim Texto2 As String

            Texto1 = "Invitación UIM" & vbCrLf & vbCrLf & "Te invitamos a la jornada de puertas abiertas que comienza esta semana  para visitar los nuevos trasteros en Sagunto y Puerto de Sagunto.  Precios exclusivos este mes. "

            Texto2 = "¿Te falta espacio en casa ? Pon orden en tu vida. Ya puedes alquilar tu trastero en Sagunto (zona Avda. Sants de la Pedra) y Puerto de Sagunto (zona Ayuntamiento). "

            'Texto2 = Texto2 & vbCrLf & "Desde 38 euros al mes. Disponemos de trasteros de diferentes medidas con 4 metros de altura.  Acceso 24 h al día / 365 días del año, seguros y muy cómodos. A pie de calle, sin tener que bajar a sótanos. "
            'Texto2 = Texto2 & vbCrLf & "Ideal para almacenar : material deportivo o de hobby, libros, ropa, muebles, juguetes , objetos de valor sentimental, herramientas, etc. "
            'Texto2 = Texto2 & vbCrLf & "Teléfono 655111650  Natalia"

            Dim Texto12 As String
            'Texto12 = "Si no ves la imagen, pincha aquí http://www.tresbits.es/Descargas/Trastero.jpg"

            Texto12 = "Si no ves la imagen, <a href=http://www.tresbits.es/Descargas/Trastero.jpg>pincha aquí</a>"
            Texto12 = "<br />" & Texto12 & "<br />" & "<br />"

            Texto2 = Texto2 & "<br />" & "<br />" & "Desde 38 euros al mes. Disponemos de trasteros de diferentes medidas con 4 metros de altura.  Acceso 24 h al día / 365 días del año, seguros y muy cómodos. A pie de calle, sin tener que bajar a sótanos. "
            Texto2 = Texto2 & "<br />" & "<br />" & "Ideal para almacenar : material deportivo o de hobby, libros, ropa, muebles, juguetes , objetos de valor sentimental, herramientas, etc. "
            Texto2 = Texto2 & "<br />" & "<br />" & "Teléfono 655111650  Natalia"


            Texto1 = New System.Text.RegularExpressions.Regex("\n\r").Replace(Texto1, "<br />")
            Texto1 = New System.Text.RegularExpressions.Regex("\n").Replace(Texto1, "<br />")



            Texto2 = New System.Text.RegularExpressions.Regex("\n\r").Replace(Texto2, "<br />")
            Texto2 = New System.Text.RegularExpressions.Regex("\n").Replace(Texto2, "<br />")


            'Texto = New System.Text.RegularExpressions.Regex("\r").Replace(Texto, "<br />")


            '    Texto = Replace(Texto, "<br /><br /><br /><br /><br /><br />", "<br /><br /><br /><br />")
            ''      Texto = Replace(Texto, "<br /><br />Muchas gracias", "<br />Muchas gracias")

            '  Texto = vbCrLf & vbCrLf & Texto

            '     Dim plainView1 As AlternateView = AlternateView.CreateAlternateViewFromString(Texto1 & Texto2, System.Text.Encoding.UTF8, "text/plain")
            '  Dim plainView2 As AlternateView = AlternateView.CreateAlternateViewFromString(Texto2, System.Text.Encoding.UTF8, "text/plain")


            Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(Texto1 & "<br /><br /><img src=cid:enlaceImagen> <br /><br />" & Texto12 & Texto2, System.Text.Encoding.UTF8, "text/html")
            'Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString("<br /><br /><img src=cid:enlaceImagen> <br /><br />" & Texto, System.Text.Encoding.UTF8, "text/html")
            ' Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString("<img src=cid:enlaceImagen> <br /><br />", System.Text.Encoding.UTF8, "text/html")

            'create the LinkedResource (embedded image)
            Dim logo As LinkedResource
            Dim RutaImagen As String
            ' RutaImagen = "http://www.tresbits.es/Descargas/Trastero.jpg"
            RutaImagen = clVariables.RutaServidor & "\Trastero.jpg"
            logo = New LinkedResource(RutaImagen)
            logo.ContentId = "enlaceImagen"
            'add the LinkedResource to the appropriate view
            htmlView.LinkedResources.Add(logo)


            'add the views

            '   msg.AlternateViews.Add(plainView1)
            msg.AlternateViews.Add(htmlView)
            '   msg.AlternateViews.Add(plainView2)
            '*****************************************************'

            'msg.Body = Texto1 & Texto2

            'If msg.IsBodyHtml Then
            '    msg.Body = New Text.RegularExpressions.Regex("\n\r").Replace(msg.Body, "<br />")
            '    msg.Body = New Text.RegularExpressions.Regex("\n").Replace(msg.Body, "<br />")
            '    msg.Body = New Text.RegularExpressions.Regex("\r").Replace(msg.Body, "<br />")

            'End If


            ' msg.IsBodyHtml = False
            Try

                'smtp.EnableSsl = True

                smtp.Send(msg)
                Return ""

            Catch ex As SqlClient.SqlException
                'MensajeError(ex.Message)
                Dim Sel As String
                Sel = "INSERT INTO TrasteroError VALUES ('" & Funciones.pf_ReplaceComillas(EmailDestino) & "')"
                BD_CERO.Execute(Sel)
                Return (ex.Message)
            Catch ex As System.Net.WebException
                Dim Sel As String
                Sel = "INSERT INTO TrasteroError VALUES ('" & Funciones.pf_ReplaceComillas(EmailDestino) & "')"
                BD_CERO.Execute(Sel)
                Return (ex.Message)
            Catch ex As Exception
                Dim Sel As String
                Sel = "INSERT INTO TrasteroError VALUES ('" & Funciones.pf_ReplaceComillas(EmailDestino) & "')"
                BD_CERO.Execute(Sel)
                Return (ex.Message)
                'Finally
                '    If exito Then
                '        MsgBox("Se envió el correo a " & EmailDestino & " con exito.")
                '    Else
                '        MsgBox("No se pudo enviar el correo a " & EmailDestino & ".")
                '    End If
            End Try


        End Function
        'Public Shared Sub CambiaValorCampoRowActual(ds As DataSet, Tabla As String, Campo As String, Valor As Object, Optional Gv As MyGridView = Nothing, Optional ValorBuscado As Object = Nothing)

        '    Dim dr As DataRow

        '    If ValorBuscado IsNot Nothing Then
        '        dr = ds.Tables(Tabla).Rows.Find(ValorBuscado)
        '    Else
        '        dr = ds.Tables(Tabla).Rows.Item(Gv.GetFocusedDataSourceRowIndex)
        '    End If


        '    dr.BeginEdit()
        '    dr(Campo) = Valor
        '    dr.EndEdit()
        '    ds.AcceptChanges()
        'End Sub

        Public Shared Sub SetSelectionAppearance(ByVal view As MyGridView, ByVal flag As Boolean)
            view.OptionsSelection.EnableAppearanceFocusedCell = flag

            view.OptionsSelection.EnableAppearanceFocusedRow = flag
            view.OptionsSelection.EnableAppearanceHideSelection = flag
        End Sub

        Public Shared Function DirectoryCopy(ByVal DirOrigen As String, ByVal DirDestino As String, ByVal CopiarSubdir As Boolean) As Boolean

            ' Cogemos las carpetas en el origen. 
            Dim dir As DirectoryInfo = New DirectoryInfo(DirOrigen)
            Dim dirs As DirectoryInfo() = dir.GetDirectories()

            If Not dir.Exists Then
                MsgBox("No se ha encontrado el directorio origen: " + DirOrigen)
                Return False
            End If

            Try
                ' Si no existe la carpeta destino la creamos. 
                If Not Directory.Exists(DirDestino) Then
                    Directory.CreateDirectory(DirDestino)
                End If
                ' Cogemos los archivos origen y los copiamos en destino. 
                Dim files As FileInfo() = dir.GetFiles()
                For Each file In files
                    Dim temppath As String = Path.Combine(DirDestino, file.Name)
                    file.CopyTo(temppath, False)
                Next file
                ' Si tenemos q copiar subdirectorios...repetimos proceso para cada uno de ellos
                If CopiarSubdir Then
                    For Each subdir In dirs
                        Dim temppath As String = Path.Combine(DirDestino, subdir.Name)
                        DirectoryCopy(subdir.FullName, temppath, CopiarSubdir)
                    Next subdir
                End If
            Catch ex As Exception
                MsgBox("Error: " + ex.Message)
                Return False
            End Try
            Return True
        End Function

        Public Shared Function TienePermisosAME() As Boolean
            If GL_TipoUsuario <> ADMINISTRADOR Then
                MensajeError("No tiene permisos para realizar esta acción")
                Return False
            Else
                Return True
            End If
        End Function



        Public Shared Sub CerrarBDSiEsAccess()
            If GL_TipoBD = EnumTipoBD.ACCESS Then
                Funciones.CerrarConexionUnica()
            End If
        End Sub

        Public Shared Sub CerrarConexionUnica()


            If Not IsNothing(cnSQLServerUnicaTramex) AndAlso cnSQLServerUnicaTramex.State <> ConnectionState.Closed Then
                cnSQLServerUnicaTramex.Close()
            End If



        End Sub



        Public Shared Function ObtenerTextoConLink(ByVal TextoHTML As String) As String

            TextoHTML = TextoHTML.Trim

            Dim PosicionInicial As Integer = 0
            Dim PosicionFinal As Integer = 0
            Dim LogitudLink As Integer

            Dim TextoOriginalLink As String = ""
            Dim TextoLinkConEtiquetas As String = ""

            PosicionInicial = InStr(TextoHTML, "http://", CompareMethod.Text)
            If PosicionInicial = 0 Then
                PosicionInicial = InStr(TextoHTML, "https://", CompareMethod.Text)
            End If


            If PosicionInicial > 0 Then

                Dim PosFinalEspacio As String = ""
                Dim PosFinalSalto As String = ""

                PosFinalEspacio = InStr(PosicionInicial, TextoHTML, " ", CompareMethod.Text)
                PosFinalSalto = InStr(PosicionInicial, TextoHTML, vbCrLf, CompareMethod.Binary)

                If PosFinalEspacio < PosFinalSalto Or PosFinalSalto = 0 Then
                    PosicionFinal = PosFinalEspacio
                Else
                    PosicionFinal = PosFinalSalto
                End If

                If PosicionFinal = 0 Then
                    PosicionFinal = Len(TextoHTML) + 1
                End If

                LogitudLink = PosicionFinal - PosicionInicial
                TextoOriginalLink = Mid(TextoHTML, PosicionInicial, LogitudLink)
                TextoHTML = Replace(TextoHTML, TextoOriginalLink, "<a href=" & TextoOriginalLink & ">" & TextoOriginalLink & "</a>")

            End If


            'TextoHTML = New Text.RegularExpressions.Regex("\n\r").Replace(TextoHTML, "<br>")
            TextoHTML = New System.Text.RegularExpressions.Regex("\n").Replace(TextoHTML, "<br>")
            ' TextoHTML = New Text.RegularExpressions.Regex("\r").Replace(TextoHTML, "<br>")

            Return TextoHTML

        End Function


    End Class

    Public Class FuncionesBD

        Public Shared Sub Accion(ByVal Accion As String, ByVal Tabla As String, Optional ByVal Referencia As String = "", Optional ByVal ReferenciaConComillas As Boolean = True, Optional ByVal Reserva As Boolean = False, Optional ByVal FotoPrincipal As Boolean = False, Optional ByVal Valor As String = "", Optional ByVal MensajeError As String = "")


            'COMENTADO DE MOMENTO. DESCOMENTAR
            If Debugger.IsAttached Then
                Exit Sub
            End If

            If Accion = "RESERVAR" Then
                Accion = "UPDATE"
                Valor = 1
                Reserva = True
            End If

            If Accion = "DESRESERVAR" Then
                Accion = "UPDATE"
                Valor = 0
                Reserva = True
            End If

            If Tabla.ToUpper <> "INMUEBLES" Then
                Exit Sub
            End If

            Try


                If Not Debugger.IsAttached AndAlso (Accion = "UPDATE" OrElse Accion = "DELETE") Then
                    Dim Portales As String
                    Portales = BD_CERO.Execute("SELECT " &
                                               Funciones.SQL_CASE({"PortalHogaria" & GL_SQL_DIS & "0", "PortalHogaria=0"}, {"'Hogaria'", "''"}) & GL_SQL_SUMA & " '|' " & GL_SQL_SUMA &
                                               Funciones.SQL_CASE({"PortalYaEncontre" & GL_SQL_DIS & "0", "PortalYaEncontre=0"}, {"'YaEncontre'", "''"}) & GL_SQL_SUMA & " '|' " & GL_SQL_SUMA &
                                               Funciones.SQL_CASE({"PortalFotoCasa" & GL_SQL_DIS & "0", "PortalFotoCasa=0"}, {"'FotoCasa'", "''"}) & GL_SQL_SUMA & " '|' " & GL_SQL_SUMA &
                                               Funciones.SQL_CASE({"PortalIdealista" & GL_SQL_DIS & "0", "PortalIdealista=0"}, {"'Idealista'", "''"}) &
                                               " FROM Inmuebles WHERE Referencia='" & Referencia & "' AND CodigoEmpresa = " & DatosEmpresa.Codigo, False)
                    If Portales <> "||" Then
                        For i = 0 To Portales.Split("|").Count - 1
                            If Portales.Split("|")(i) <> "" Then




                                If Portales.Split("|")(i).ToUpper = "FOTOCASA" Then
                                    'Dim CodigoAPI As String
                                    'Dim Sel As String

                                    'Sel = "SELECT Codigo FROM ClientePortales WHERE Portal = 'FotoCasa' and CodigoEmpresa = " & DatosEmpresa.Codigo
                                    'CodigoAPI = BD_CERO.Execute(Sel, False, "")

                                    'If CodigoAPI <> "" Then
                                    '    Dim Res As clResultado = DespublicarFotocasa(Referencia, CodigoAPI)
                                    'End If
                                Else
                                    BD_CERO.Execute("UPDATE ClientePortales SET PendientePublicar = " & GL_SQL_VALOR_1 & " WHERE Portal='" & Portales.Split("|")(i) & "' AND CodigoEmpresa=" & DatosEmpresa.Codigo)

                                End If

                            End If
                        Next
                        GL_PortalesDesactualizados = True
                    End If
                End If

                If Not GL_ConfiguracionWeb.web3B Then
                    Return
                End If


                If MensajeError <> "" Then
                    If MensajeError.Length > 200 Then
                        MensajeError = Valor & "|" & MensajeError.Substring(0, 200)
                    Else
                        MensajeError = Valor & "|" & MensajeError
                    End If
                End If
                If Referencia = "" Then
                    Referencia = "''"
                End If
                If Reserva Then
                    'ACTUALIZAR SOLO RESERVADO EN LA WEB

                    Try

                        If DatosEmpresa.WordPress Then
                            Dim ResultadoStatus As Boolean
                            ResultadoStatus = WP_CambiarStatus(Referencia, IIf(Valor = "1", "RESERVADO", "DESRESERVADO"), IIf(Valor = "1", "RESERVAR", "DESRESERVAR"))
                            If Not ResultadoStatus Then
                                BD_CERO.Execute("INSERT INTO AccionesPendientes (Accion,Tabla,Referencia,CodigoEmpresa,Codigo,Fecha, Pendiente, Aleatorio, MensajeError) VALUES ('" & IIf(Valor = "1", "RESERVAR", "DESRESERVAR") & "','" & Tabla.ToUpper & "','" & Funciones.pf_ReplaceComillas(Referencia) & "'," & DatosEmpresa.Codigo & ",'', " & GL_SQL_GETDATE & "," & GL_SQL_VALOR_1 & ",'','Error Reserva')")
                            End If
                        Else

                            'Dim Ser As New WebServiceVenalia.WebServiceVenaliaClient
                            'If Not Ser.ActualizaReservado("TresBits", "EE358CB6BF1683287B21B102BBC848EB", DatosEmpresa.Codigo, Referencia, Valor) Then
                            '    BD_CERO.Execute("INSERT INTO AccionesPendientes (Accion,Tabla,Referencia,CodigoEmpresa,Codigo,Fecha, Pendiente, Aleatorio, MensajeError) VALUES ('" & Accion & "','" & Tabla.ToUpper & "','" & Funciones.pf_ReplaceComillas(Referencia) & "'," & DatosEmpresa.Codigo & ",'', " & GL_SQL_GETDATE & "," & GL_SQL_VALOR_1 & ",'','Error Reserva')")
                            '    'MessageBox.Show("No se ha podido actualizar en la web, publique para ver los cambios o espere la actualización automática.")


                            'End If
                        End If

                        'Catch FaultEX As ServiceModel.FaultException(Of tabla.clResultado)
                        '    Dim MensaError As String = FaultEX.Message
                        '    If MensaError > 250 Then
                        '        MensaError = Microsoft.VisualBasic.Left(MensaError, 250)
                        '    End If

                        '    BD_CERO.Execute("INSERT INTO AccionesPendientes (Accion,Tabla,Referencia,CodigoEmpresa,Codigo,Fecha, Pendiente, Aleatorio, MensajeError) VALUES ('" & Accion & "','" & Tabla.ToUpper & "','" & Funciones.pf_ReplaceComillas(Referencia) & "'," & DatosEmpresa.Codigo & ",'', " & GL_SQL_GETDATE & "," & GL_SQL_VALOR_1 & ",'','" & MensaError & "')")
                        '    'MessageBox.Show("No se ha podido actualizar en la web, publique para ver los cambios o espere la actualización automática.")
                        '    'MessageBox.Show(FaultEX.Message)
                    Catch ex As Exception
                        Dim MensaError As String = ex.Message
                        If MensaError > 250 Then
                            MensaError = Microsoft.VisualBasic.Left(MensaError, 250)
                        End If
                        BD_CERO.Execute("INSERT INTO AccionesPendientes (Accion,Tabla,Referencia,CodigoEmpresa,Codigo,Fecha, Pendiente, Aleatorio, MensajeError) VALUES ('" & Accion & "','" & Tabla.ToUpper & "','" & Funciones.pf_ReplaceComillas(Referencia) & "'," & DatosEmpresa.Codigo & ",'', " & GL_SQL_GETDATE & "," & GL_SQL_VALOR_1 & ",'','" & MensaError & "')")
                        'MessageBox.Show("No se ha podido actualizar en la web, publique para ver los cambios o espere la actualización automática.")
                        'MessageBox.Show(ex.Message)
                    End Try
                ElseIf FotoPrincipal Then
                    ''ACTUALIZAR SOLO FOTOPRINCIPAL EN LA WEB
                    ''Dim Ser As New WebServiceVenalia.WebServiceVenaliaClient
                    'Try
                    '    'If DatosEmpresa.WordPress Then

                    '    'Else
                    '    '    If Not Ser.ActualizaFotoPrincipal("TresBits", "EE358CB6BF1683287B21B102BBC848EB", DatosEmpresa.Codigo, Referencia, Valor) Then
                    '    '        BD_CERO.Execute("INSERT INTO AccionesPendientes (Accion,Tabla,Referencia,CodigoEmpresa,Codigo,Fecha, Pendiente, Aleatorio, MensajeError) VALUES ('" & Accion & "','" & Tabla.ToUpper & "','" & Funciones.pf_ReplaceComillas(Referencia) & "'," & DatosEmpresa.Codigo & ",'', " & GL_SQL_GETDATE & "," & GL_SQL_VALOR_1 & ",'','Error FotoPrincipal')")
                    '    '        'MessageBox.Show("No se ha podido actualizar en la web, publique para ver los cambios o espere la actualización automática.")
                    '    '    End If
                    '    'End If

                    '    'Catch FaultEX As ServiceModel.FaultException(Of WebServiceVenalia.clResultado)
                    '    '    Dim MensaError As String = FaultEX.Message
                    '    '    If MensaError > 250 Then
                    '    '        MensaError = Microsoft.VisualBasic.Left(MensaError, 250)
                    '    '    End If
                    '    '    BD_CERO.Execute("INSERT INTO AccionesPendientes (Accion,Tabla,Referencia,CodigoEmpresa,Codigo,Fecha, Pendiente, Aleatorio, MensajeError) VALUES ('" & Accion & "','" & Tabla.ToUpper & "','" & Funciones.pf_ReplaceComillas(Referencia) & "'," & DatosEmpresa.Codigo & ",'', " & GL_SQL_GETDATE & "," & GL_SQL_VALOR_1 & ",'','" & MensaError & "')")
                    '    '    'MessageBox.Show("No se ha podido actualizar en la web, publique para ver los cambios o espere la actualización automática.")
                    '    '    'MessageBox.Show(FaultEX.Message)
                    'Catch ex As Exception
                    '    Dim MensaError As String = ex.Message
                    '    If MensaError > 250 Then
                    '        MensaError = Microsoft.VisualBasic.Left(MensaError, 250)
                    '    End If
                    '    BD_CERO.Execute("INSERT INTO AccionesPendientes (Accion,Tabla,Referencia,CodigoEmpresa,Codigo,Fecha, Pendiente, Aleatorio, MensajeError) VALUES ('" & Accion & "','" & Tabla.ToUpper & "','" & Funciones.pf_ReplaceComillas(Referencia) & "'," & DatosEmpresa.Codigo & ",'', " & GL_SQL_GETDATE & "," & GL_SQL_VALOR_1 & ",'','" & MensaError & "')")
                    '    'MessageBox.Show("No se ha podido actualizar en la web, publique para ver los cambios o espere la actualización automática.")
                    '    'MessageBox.Show(ex.Message)
                    'End Try
                Else
                    If Accion = "INSTRUCCION" Then
                        BD_CERO.Execute("INSERT INTO AccionesPendientes (Accion,Tabla,Referencia,CodigoEmpresa,Codigo,Fecha, Pendiente, Aleatorio) VALUES ('" & Accion & "','" & Tabla.ToUpper & "','" & Funciones.pf_ReplaceComillas(Referencia) & "'," & DatosEmpresa.Codigo & ",'', " & GL_SQL_GETDATE & "," & GL_SQL_VALOR_1 & ",'')")
                    Else
                        BD_CERO.Execute("INSERT INTO AccionesPendientes (Accion,Tabla,Referencia,CodigoEmpresa,Codigo,Fecha, Pendiente, Aleatorio, MensajeError) VALUES ('" & Accion & "','" & Tabla.ToUpper & "','" & Funciones.pf_ReplaceComillas(Referencia) & "'," & DatosEmpresa.Codigo & ",'', " & GL_SQL_GETDATE & "," & GL_SQL_VALOR_1 & ",'','" & MensajeError & "')")
                    End If
                    If Accion = "UPDATE" OrElse Accion = "INSERT" OrElse Accion = "DELETE" Then
                        'RECORRER LA LISTA DE ACCIONES DEL INMUEBLE Y REALIZARLAS
                        Try
                            If Not SincronizarTodoLoPendienteConLaWeb() Then
                                '    MessageBox.Show("No se ha podido actualizar en la web, publique para ver los cambios o espere la actualización automática.")

                                Dim ErrorAEscribir As String
                                If IsNothing(GL_Error) Then
                                    GL_Error = ""
                                End If
                                If GL_Error.Length > 250 Then
                                    ErrorAEscribir = GL_Error.Substring(0, 250)
                                Else
                                    ErrorAEscribir = GL_Error
                                End If

                                BD_CERO.Execute("UPDATE AccionesPendientes SET MensajeError ='" & ErrorAEscribir & "' WHERE Accion = '" & Accion & "' AND CodigoEmpresa = " & DatosEmpresa.Codigo & " AND Referencia = '" & Referencia & "'")
                            Else
                                BD_CERO.Execute(GL_SQL_DELETE & " FROM AccionesPendientes WHERE CodigoEmpresa = " & DatosEmpresa.Codigo & " AND Referencia = '" & Referencia & "'")
                            End If
                        Catch ex As Exception
                            Dim ErrorAEscribir As String
                            If ex.Message.Length > 250 Then
                                ErrorAEscribir = ex.Message.Substring(0, 250)
                            Else
                                ErrorAEscribir = ex.Message
                            End If
                            BD_CERO.Execute("UPDATE AccionesPendientes SET MensajeError ='" & ErrorAEscribir & "' WHERE Accion = '" & Accion & "' AND  CodigoEmpresa = " & DatosEmpresa.Codigo & " AND Referencia = '" & Referencia & "'")
                            ' MessageBox.Show("Hubo un error al sincronizar los datos con la web." & vbCrLf & "Inténtelo más tarde")
                        End Try
                    End If

                End If

            Catch ex As Exception

            End Try


        End Sub

        'Public Shared Function ActualizarInmueble(ByVal Referencia As String) As Boolean
        '    Dim Ser As New WebServiceVenalia.WebServiceVenaliaClient
        '    'recorrer todas las acciones
        '    Dim bdact, BDACT2 As New BaseDatos
        '    Dim dtr, DTR2 As Object
        '    dtr = bdact.ExecuteReader("SELECT TOP 1 * FROM AccionesPendientes WHERE CodigoEmpresa = " & DatosEmpresa.Codigo & " AND Referencia = '" & Referencia & "' ORDER BY CONTADOR DESC")
        '    If dtr.hasrows() Then
        '        While dtr.read()

        '            Try
        '                If Not Ser.BajaInmueble("TresBits", "EE358CB6BF1683287B21B102BBC848EB", DatosEmpresa.Codigo, Referencia) Then
        '                    Return False
        '                End If
        '            Catch FaultEX As ServiceModel.FaultException(Of WebServiceVenalia.clResultado)

        '                MessageBox.Show(FaultEX.Message)
        '                Return False
        '            Catch ex As Exception
        '                MessageBox.Show(ex.Message)
        '                Return False
        '            End Try



        '            If dtr("Accion") = "UPDATE" OrElse dtr("Accion") = "INSERT" Then
        '                Dim Inmueble As WebServiceVenalia.clInmueblesAlta
        '                Dim SEL As String = " Contador,Referencia,CodigoEmpresa,Delegacion,FechaAlta,TipoVenta,AlquilerOpcionCompra,AlquilerVacacional,Precio,Via,Direccion,Puerta,Numero" & _
        '                ",Altura,CodPostal,Poblacion,Provincia,Metros,Banos,Habitaciones,AnoConstruccion,Ascensor,CocinaOffice,Piscina,Duplex,Galeria,Tipo,Orientacion" & _
        '                ",Zona,Estado,Extras,Oportunidad,Amueblado,Balcon,MBalcon,MBalcon2,Patio,MPatio,MPatio2,Terraza,MTerraza,MTerraza2,Jardin,MJardin,Trastero,MTrastero" & _
        '                ",PrecioTrastero,Garaje,MGaraje,PrecioGaraje,CalificacionEnergetica,CambioPrecio,FechaCambioPrecio,FechaUltimoCambio,MPlaya ,  VistasAlMar, GarajeCerrado, ZonaComercial,Reservado,FotoPrincipal "
        '                SEL = " SELECT " & SEL & " FROM Inmuebles WHERE Referencia = '" & Referencia & "' AND CodigoEmpresa = " & DatosEmpresa.Codigo

        '                DTR2 = BDACT2.ExecuteReader(SEL)

        '                If DTR2.HasRows Then

        '                    DTR2.Read()

        '                    Inmueble = New WebServiceVenalia.clInmueblesAlta


        '                    Inmueble.Contador = DTR2("Contador")
        '                    Inmueble.Referencia = DTR2("Referencia")
        '                    Inmueble.CodigoEmpresa = DTR2("CodigoEmpresa")
        '                    Inmueble.Delegacion = DTR2("Delegacion")
        '                    Inmueble.FechaAlta = DTR2("FechaAlta")
        '                    Inmueble.TipoVenta = DTR2("TipoVenta")
        '                    Inmueble.AlquilerOpcionCompra = DTR2("AlquilerOpcionCompra")
        '                    Inmueble.AlquilerVacacional = DTR2("AlquilerVacacional")
        '                    Inmueble.Precio = DTR2("Precio")
        '                    Inmueble.Via = DTR2("Via")
        '                    Inmueble.Direccion = DTR2("Direccion")
        '                    Inmueble.Puerta = DTR2("Puerta")
        '                    Inmueble.Numero = DTR2("Numero")

        '                    Inmueble.Altura = DTR2("Altura")
        '                    Inmueble.CodPostal = DTR2("CodPostal")
        '                    Inmueble.Poblacion = DTR2("Poblacion")
        '                    Inmueble.Provincia = DTR2("Provincia")


        '                    Inmueble.Metros = DTR2("Metros")
        '                    Inmueble.Banos = DTR2("Banos")
        '                    Inmueble.Habitaciones = DTR2("Habitaciones")
        '                    Inmueble.AnoConstruccion = DTR2("AnoConstruccion")
        '                    Inmueble.Ascensor = DTR2("Ascensor")
        '                    Inmueble.CocinaOffice = DTR2("CocinaOffice")
        '                    Inmueble.Piscina = DTR2("Piscina")
        '                    Inmueble.Duplex = DTR2("Duplex")
        '                    Inmueble.Galeria = DTR2("Galeria")

        '                    Inmueble.Tipo = DTR2("Tipo")
        '                    Inmueble.Orientacion = DTR2("Orientacion")
        '                    Inmueble.Zona = DTR2("Zona")
        '                    Inmueble.Estado = DTR2("Estado")
        '                    Inmueble.Extras = DTR2("Extras")
        '                    Inmueble.Oportunidad = DTR2("Oportunidad")
        '                    Inmueble.Amueblado = DTR2("Amueblado")
        '                    Inmueble.Balcon = DTR2("Balcon")
        '                    Inmueble.MBalcon = DTR2("MBalcon")
        '                    Inmueble.MBalcon2 = DTR2("MBalcon2")
        '                    Inmueble.Patio = DTR2("Patio")

        '                    Inmueble.MPatio = DTR2("MPatio")
        '                    Inmueble.MPatio2 = DTR2("MPatio2")
        '                    Inmueble.Terraza = DTR2("Terraza")
        '                    Inmueble.MTerraza = DTR2("MTerraza")
        '                    Inmueble.MTerraza2 = DTR2("MTerraza2")
        '                    Inmueble.Jardin = DTR2("Jardin")
        '                    Inmueble.MJardin = DTR2("MJardin")
        '                    Try
        '                        If Not IsDBNull(DTR2("Trastero")) Then
        '                            Inmueble.Trastero = DTR2("Trastero")
        '                        End If
        '                    Catch ex As Exception

        '                    End Try


        '                    Inmueble.MTrastero = DTR2("MTrastero")
        '                    Inmueble.PrecioTrastero = DTR2("PrecioTrastero")
        '                    Try
        '                        If Not IsDBNull(DTR2("Garaje")) Then
        '                            Inmueble.Trastero = DTR2("Garaje")
        '                        End If
        '                    Catch ex As Exception

        '                    End Try


        '                    Inmueble.MPlaya = DTR2("MPlaya")

        '                    Inmueble.VistasAlMar = DTR2("VistasAlMar")
        '                    Inmueble.GarajeCerrado = DTR2("GarajeCerrado")
        '                    Inmueble.ZonaComercial = DTR2("ZonaComercial")
        '                    Inmueble.Reservado = DTR2("Reservado")
        '                    Inmueble.FotoPrincipal = DTR2("FotoPrincipal")

        '                    Inmueble.MGaraje = DTR2("MGaraje")
        '                    Inmueble.PrecioGaraje = DTR2("PrecioGaraje")
        '                    Inmueble.CalificacionEnergetica = DTR2("CalificacionEnergetica")
        '                    Inmueble.CambioPrecio = DTR2("CambioPrecio")
        '                    Try
        '                        If Not IsDBNull(DTR2("FechaCambioPrecio")) Then
        '                            Inmueble.FechaCambioPrecio = DTR2("FechaCambioPrecio")
        '                        End If
        '                    Catch ex As Exception

        '                    End Try
        '                    Try
        '                        If Not IsDBNull(DTR2("FechaUltimoCambio")) Then
        '                            Inmueble.FechaUltimoCambio = DTR2("FechaUltimoCambio")
        '                        End If
        '                    Catch ex As Exception

        '                    End Try


        '                Else
        '                    Return False
        '                End If
        '                Try
        '                    If Not Ser.AltaInmueble("TresBits", "EE358CB6BF1683287B21B102BBC848EB", Inmueble) Then
        '                        Return False
        '                    End If
        '                Catch FaultEX As ServiceModel.FaultException(Of WebServiceVenalia.clResultado)

        '                    MessageBox.Show(FaultEX.Message)
        '                    Return False
        '                Catch ex As Exception
        '                    MessageBox.Show(ex.Message)
        '                    Return False
        '                End Try

        '            End If

        '        End While
        '    Else
        '        Return False
        '    End If
        '    DTR2.CLOSE()
        '    BDACT2.CerrarBD()
        '    dtr.CLOSE()
        '    bdact.CerrarBD()
        '    Return True

        'End Function


        Public Shared Function PrepararObjetoInmuebleAlta(ByVal Referencia As String) As Tablas.clInmuebleConId_WP

            Dim InmuebleConId_WP As New Tablas.clInmuebleConId_WP

            Dim Sel As String
            Dim BDACT2 As New BaseDatos


            Dim DTR2 As Object
            Dim Inmueble As Tablas.clInmueblesAlta
            Dim Id_WP As Integer = 0
            Dim Id_WP_FotoPrincipal As Integer = 0

            Sel = " Contador,Referencia,CodigoEmpresa,Delegacion,FechaAlta,TipoVenta,AlquilerOpcionCompra,AlquilerVacacional,Precio,Via,Direccion,Puerta,DireccionMapa,Numero" &
            ",Altura,CodPostal,Poblacion,Provincia,Metros,Banos,Habitaciones,AnoConstruccion,Ascensor,CocinaOffice,Piscina,Duplex,Galeria,Tipo,Orientacion" &
            ",Zona,Estado,Extras,Oportunidad,Amueblado,Balcon,MBalcon,MBalcon2,Patio,MPatio,MPatio2,Terraza,MTerraza,MTerraza2,Jardin,MJardin,Trastero,MTrastero" &
            ",PrecioTrastero,Garaje,MGaraje,PrecioGaraje,CalificacionEnergetica,CambioPrecio,FechaCambioPrecio,FechaUltimoCambio,MPlaya ,  VistasAlMar, GarajeCerrado, ZonaComercial,Reservado,FotoPrincipal,MostrarPPrincipalWeb " &
            ", Id_WP,AireAcondicionado,ZonaComercial,AccesoMinusvalidos,Electrodomesticos, Urbanizacion,Calefaccion"
            Sel = " SELECT " & Sel & " FROM Inmuebles WHERE Referencia = '" & Referencia & "' AND CodigoEmpresa = " & DatosEmpresa.Codigo

            DTR2 = BDACT2.ExecuteReader(Sel)

            If DTR2.HasRows Then

                DTR2.Read()

                Inmueble = New Tablas.clInmueblesAlta


                Inmueble.Contador = DTR2("Contador")
                Inmueble.Referencia = DTR2("Referencia")
                Inmueble.CodigoEmpresa = DTR2("CodigoEmpresa")
                Inmueble.Delegacion = DTR2("Delegacion")
                Inmueble.FechaAlta = DTR2("FechaAlta")
                Inmueble.TipoVenta = DTR2("TipoVenta")
                Inmueble.AlquilerOpcionCompra = DTR2("AlquilerOpcionCompra")
                Inmueble.AlquilerVacacional = DTR2("AlquilerVacacional")
                Inmueble.Precio = DTR2("Precio")
                Inmueble.Via = "" 'DTR2("Via")
                Inmueble.Direccion = DTR2("DireccionMapa") 'DTR2("Direccion")
                Inmueble.Puerta = "" 'DTR2("Puerta")
                Inmueble.Numero = "" 'DTR2("Numero")

                Inmueble.Altura = DTR2("Altura")
                Inmueble.CodPostal = DTR2("CodPostal")
                Inmueble.Poblacion = DTR2("Poblacion")
                Inmueble.Provincia = DTR2("Provincia")


                Inmueble.Metros = DTR2("Metros")
                Inmueble.Banos = DTR2("Banos")
                Inmueble.Habitaciones = DTR2("Habitaciones")
                Inmueble.AnoConstruccion = DTR2("AnoConstruccion")
                Inmueble.Ascensor = DTR2("Ascensor")
                Inmueble.CocinaOffice = DTR2("CocinaOffice")
                Inmueble.Piscina = DTR2("Piscina")
                Inmueble.Duplex = DTR2("Duplex")
                Inmueble.Galeria = DTR2("Galeria")

                Inmueble.Tipo = DTR2("Tipo")
                Inmueble.Orientacion = DTR2("Orientacion")
                Inmueble.Zona = DTR2("Zona")
                Inmueble.Estado = DTR2("Estado")
                Inmueble.Extras = DTR2("Extras")
                Inmueble.Oportunidad = DTR2("Oportunidad")
                Inmueble.Amueblado = DTR2("Amueblado")
                Inmueble.Balcon = DTR2("Balcon")
                Inmueble.MBalcon = DTR2("MBalcon")
                Inmueble.MBalcon2 = DTR2("MBalcon2")
                Inmueble.Patio = DTR2("Patio")

                Inmueble.MPatio = DTR2("MPatio")
                Inmueble.MPatio2 = DTR2("MPatio2")
                Inmueble.Terraza = DTR2("Terraza")
                Inmueble.MTerraza = DTR2("MTerraza")
                Inmueble.MTerraza2 = DTR2("MTerraza2")
                Inmueble.Jardin = DTR2("Jardin")
                Inmueble.MJardin = DTR2("MJardin")

                Inmueble.MostrarPPrincipalWeb = DTR2("MostrarPPrincipalWeb")


                Try
                    If Not IsDBNull(DTR2("Trastero")) Then
                        Inmueble.Trastero = DTR2("Trastero")
                    End If
                Catch ex As Exception

                End Try


                Inmueble.MTrastero = DTR2("MTrastero")
                Inmueble.PrecioTrastero = DTR2("PrecioTrastero")
                Try
                    If Not IsDBNull(DTR2("Garaje")) Then
                        Inmueble.Garaje = DTR2("Garaje")
                    End If
                Catch ex As Exception

                End Try


                Inmueble.MPlaya = DTR2("MPlaya")

                Try
                    If Not IsDBNull(DTR2("VistasAlMar")) Then
                        Inmueble.VistasAlMar = DTR2("VistasAlMar")
                    End If
                Catch ex As Exception

                End Try

                Inmueble.GarajeCerrado = DTR2("GarajeCerrado")

                Try
                    If Not IsDBNull(DTR2("ZonaComercial")) Then
                        Inmueble.ZonaComercial = DTR2("ZonaComercial")
                    End If
                Catch ex As Exception

                End Try

                Inmueble.Reservado = DTR2("Reservado")
                Inmueble.FotoPrincipal = DTR2("FotoPrincipal")

                Inmueble.MGaraje = DTR2("MGaraje")
                Inmueble.PrecioGaraje = DTR2("PrecioGaraje")
                Inmueble.CalificacionEnergetica = DTR2("CalificacionEnergetica")
                Inmueble.CambioPrecio = DTR2("CambioPrecio")
                Try
                    If Not IsDBNull(DTR2("FechaCambioPrecio")) Then
                        Inmueble.FechaCambioPrecio = DTR2("FechaCambioPrecio")
                    End If
                Catch ex As Exception

                End Try
                Try
                    If Not IsDBNull(DTR2("FechaUltimoCambio")) Then
                        Inmueble.FechaUltimoCambio = DTR2("FechaUltimoCambio")
                    End If
                Catch ex As Exception
                    Inmueble = Nothing
                End Try
            Else
                Inmueble = Nothing
            End If

            InmuebleConId_WP.Inmueble = Inmueble
            InmuebleConId_WP.ID_WP = DTR2("ID_WP")

            DTR2.CLOSE()


            If InmuebleConId_WP.ID_WP <> 0 Then
                Sel = "SELECT IdFoto FROM WP_FOTOS WHERE IdProperty = " & InmuebleConId_WP.ID_WP & " AND Principal = 1"
                InmuebleConId_WP.Id_WP_FotoPrincipal = BD_CERO.Execute(Sel, False, 0)
            End If

            Return InmuebleConId_WP
        End Function
        Public Shared Function SincronizarReferencia(ByVal Accion As String, ByVal Referencia As String, ByVal ContadorAccionesPendientes As Integer, ByVal MensajeError As String, Optional ObtenerToken As Boolean = True) As Boolean

            'recorrer todas las acciones

            Dim Resultado As Boolean
            Dim InmuebleCompleto As New Tablas.clInmuebleConId_WP

            If Accion = "UPDATE" OrElse Accion = "INSERT" Then


                'si es wordpress, hacemos una cosa, si no, otra.

                If DatosEmpresa.WordPress Then


                    InmuebleCompleto = PrepararObjetoInmuebleAlta(Referencia)

                    If Not IsNothing(InmuebleCompleto.Inmueble) Then

                        Resultado = WP_Alta_Modificacion_Inmueble(InmuebleCompleto, Accion, ObtenerToken)
                    Else
                        Resultado = True
                    End If


                    'Else
                    '    Try

                    '        Dim Inmueble As WebServiceVenalia.clInmueblesAlta
                    '        InmuebleCompleto = PrepararObjetoInmuebleAlta(Referencia)
                    '        Inmueble = InmuebleCompleto.Inmueble

                    '        If Not IsNothing(Inmueble) Then
                    '            Dim Ser As New WebServiceVenalia.WebServiceVenaliaClient

                    '            If Not Ser.AltaInmueble("TresBits", "EE358CB6BF1683287B21B102BBC848EB", Inmueble) Then
                    '                'MsgBox("Error alta")
                    '                GL_Error = "Error"
                    '                Resultado = False
                    '            Else
                    '                Resultado = True
                    '            End If
                    '        Else
                    '            Resultado = True
                    '        End If

                    '    Catch FaultEX As ServiceModel.FaultException(Of WebServiceVenalia.clResultado)
                    '        GL_Error = FaultEX.Message
                    '        'MessageBox.Show(FaultEX.Message)
                    '        Resultado = False
                    '    Catch ex As Exception
                    '        GL_Error = ex.Message
                    '        'MessageBox.Show(ex.Message)
                    '        Resultado = False
                    '    End Try
                End If





            Else

                If Accion = "DELETE" Then
                    Try

                        If DatosEmpresa.WordPress Then
                            Resultado = WP_Eliminar_Inmueble(Referencia)

                        Else
                            'Dim Ser As New WebServiceVenalia.WebServiceVenaliaClient
                            'If Not Ser.BajaInmueble("TresBits", "EE358CB6BF1683287B21B102BBC848EB", DatosEmpresa.Codigo, Referencia) Then
                            '    GL_Error = "Error"
                            '    Resultado = False
                            'Else
                            '    Resultado = True
                            'End If
                        End If


                        'Catch FaultEX As ServiceModel.FaultException(Of WebServiceVenalia.clResultado)
                        '    GL_Error = FaultEX.Message
                        '    'MessageBox.Show(FaultEX.Message)
                        '    Resultado = False
                    Catch ex As Exception
                        GL_Error = ex.Message
                        'MessageBox.Show(ex.Message)
                        Resultado = False
                    End Try

                Else
                    If Accion = "RESERVAR" Or Accion = "DESRESERVAR" Then

                        Dim Valor As String
                        Dim Reserva As Boolean

                        If Accion = "RESERVAR" Then
                            Accion = "UPDATE"
                            Valor = 1
                            Reserva = True
                        Else
                            Accion = "UPDATE"
                            Valor = 0
                            Reserva = True

                        End If
                        If DatosEmpresa.WordPress Then
                            Dim ResultadoStatus As Boolean
                            Resultado = WP_CambiarStatus(Referencia, IIf(Valor = "1", "RESERVADO", "DESRESERVADO"), IIf(Valor = "1", "RESERVAR", "DESRESERVAR"))
                            If Not Resultado Then
                                BD_CERO.Execute("INSERT INTO AccionesPendientes (Accion,Tabla,Referencia,CodigoEmpresa,Codigo,Fecha, Pendiente, Aleatorio, MensajeError) VALUES ('" & IIf(Valor = "1", "RESERVAR", "DESRESERVAR") & "','INMUEBLES','" & Funciones.pf_ReplaceComillas(Referencia) & "'," & DatosEmpresa.Codigo & ",'', " & GL_SQL_GETDATE & "," & GL_SQL_VALOR_1 & ",'','Error Reserva')")
                            End If
                        Else

                            'Dim Ser As New WebServiceVenalia.WebServiceVenaliaClient
                            'If Not Ser.ActualizaReservado("TresBits", "EE358CB6BF1683287B21B102BBC848EB", DatosEmpresa.Codigo, Referencia, Valor) Then
                            '    BD_CERO.Execute("INSERT INTO AccionesPendientes (Accion,Tabla,Referencia,CodigoEmpresa,Codigo,Fecha, Pendiente, Aleatorio, MensajeError) VALUES ('" & Accion & "','" & Tabla.ToUpper & "','" & Funciones.pf_ReplaceComillas(Referencia) & "'," & DatosEmpresa.Codigo & ",'', " & GL_SQL_GETDATE & "," & GL_SQL_VALOR_1 & ",'','Error Reserva')")
                            '    'MessageBox.Show("No se ha podido actualizar en la web, publique para ver los cambios o espere la actualización automática.")


                            'End If
                        End If

                    End If
                    'Try
                    '    Dim Ser As New WebServiceVenalia.WebServiceVenaliaClient
                    '    If Not Ser.CambiaReferencia("TresBits", "EE358CB6BF1683287B21B102BBC848EB", DatosEmpresa.Codigo, MensajeError.Split("|")(0), Referencia) Then
                    '        GL_Error = "Error"
                    '        Return False
                    '        Resultado = False
                    '    Else
                    '        Resultado = True
                    '    End If
                    'Catch FaultEX As ServiceModel.FaultException(Of WebServiceVenalia.clResultado)
                    '    GL_Error = FaultEX.Message
                    '    'MessageBox.Show(FaultEX.Message)
                    '    Resultado = False
                    'Catch ex As Exception
                    '    GL_Error = ex.Message
                    '    'MessageBox.Show(ex.Message)
                    '    Resultado = False
                    'End Try

                End If



            End If

            If Resultado Then
                Dim Sel As String
                Sel = "DELETE FROM AccionesPendientes WHERE Contador = " & ContadorAccionesPendientes
                BD_CERO.Execute(Sel)
            End If

            Return Resultado

        End Function


        Public Shared Function SincronizarTodoLoPendienteConLaWeb() As Boolean

            'If DatosEmpresa.WordPress Then

            '    GL_TokenWP = ObtenerTokenWP()

            '    If GL_TokenWP = "" Then
            '        Return False
            '    End If

            'End If

            Dim Salir As Boolean = False
            ' Dim Ser As New WebServiceVenalia.WebServiceVenaliaClient
            'recorrer todas las acciones
            Dim Sel As String
            Sel = "SELECT COUNT(*) FROM AccionesPendientes WHERE Tabla = 'INMUEBLES' AND Accion = 'CAMBIOREFERENCIA' AND CodigoEmpresa = " & DatosEmpresa.Codigo
            'primero vemos las acciones de cambio de referncia
            If BD_CERO.Execute(Sel, False) > 0 Then

                Do 'Cambioreferencias

                    Dim ContadorAccion As String = ""
                    Dim Referencia As String = ""
                    Dim MensajeError As String = ""
                    Dim Accion As String = ""

                    Sel = GL_SQL_TOP1_FRONT & Funciones.SQL_CONVERT("VARCHAR", "Contador") & " " & GL_SQL_SUMA & " '|' " & GL_SQL_SUMA & " Referencia " & GL_SQL_SUMA & " '|' " & GL_SQL_SUMA & " MensajeError FROM AccionesPendientes WHERE Tabla = 'INMUEBLES' AND Accion = 'CAMBIOREFERENCIA' AND CodigoEmpresa = " & DatosEmpresa.Codigo & " ORDER BY CONTADOR" & GL_SQL_TOP1_BACK
                    Dim Res As String
                    Res = BD_CERO.Execute(Sel, False, "")
                    If Res = "" Then 'No hay acciones ptes
                        Salir = True
                        Continue Do
                    End If


                    Accion = "CAMBIOREFERENCIA"
                    ContadorAccion = Split(Res, "|")(0)
                    Referencia = Split(Res, "|")(1)
                    MensajeError = Split(Res, "|")(2)

                    If ContadorAccion = "" Then
                        ContadorAccion = 0
                    End If

                    If Not SincronizarReferencia(Accion, Referencia, CInt(ContadorAccion), MensajeError) Then
                        Return False
                    End If

                Loop While Not Salir
            End If
            Salir = False
            Do 'demas acciones

                Dim ContadorAccion As String = ""
                Dim Accion As String = ""
                Dim Referencia As String = ""

                'Sel = GL_SQL_TOP1_FRONT & Funciones.SQL_CONVERT("VARCHAR", "Contador") & " " & GL_SQL_SUMA & " '|' " & GL_SQL_SUMA & " Referencia " & GL_SQL_SUMA & " '|' " & GL_SQL_SUMA & " MensajeError FROM AccionesPendientes WHERE Tabla = 'INMUEBLES' AND Accion = 'CAMBIOREFERENCIA' AND CodigoEmpresa = " & DatosEmpresa.Codigo & " ORDER BY CONTADOR" & GL_SQL_TOP1_BACK
                Sel = GL_SQL_TOP1_FRONT & Funciones.SQL_CONVERT("VARCHAR", "Contador") & " " & GL_SQL_SUMA & " '|' " & GL_SQL_SUMA & " Accion " & GL_SQL_SUMA & " '|' " & GL_SQL_SUMA & " Referencia  FROM AccionesPendientes WHERE Tabla = 'INMUEBLES' AND CodigoEmpresa = " & DatosEmpresa.Codigo & " ORDER BY CONTADOR " & GL_SQL_TOP1_BACK
                Dim Res As String
                Res = BD_CERO.Execute(Sel, False, "")
                If Res = "" Then 'No hay acciones ptes
                    Salir = True
                    Continue Do
                End If

                ContadorAccion = Split(Res, "|")(0)
                Accion = Split(Res, "|")(1)
                Referencia = Split(Res, "|")(2)

                If ContadorAccion = "" Then
                    ContadorAccion = 0
                End If

                If Not SincronizarReferencia(Accion, Referencia, CInt(ContadorAccion), "") Then
                    'Comento esto para que continue y actualice el resto
                    'Return False
                End If

            Loop While Not Salir

            Return True

        End Function
        Public Shared Function sp_DuplicarDocumento(ByVal Contador As Integer, ByVal TablaNueva As String, ByVal TablaVieja As String, ByVal Empleado As Integer) As Object

            Dim Sql As String
            Dim ColeccionCampos As String = ""
            Dim CAMPO As String

            If TablaNueva.ToUpper = "INMUEBLES" AndAlso TablaNueva = TablaVieja Then BD_CERO.Execute("UPDATE Inmuebles SET ContadorOrigen=Contador WHERE Contador=" & Contador)

            Dim bdOC As New BaseDatos

            bdOC.LlenarDataSet(GL_SQL_TOP1_FRONT & " * FROM " & TablaVieja & GL_SQL_TOP1_BACK, "CAMPOS")
            For i = 0 To bdOC.ds.Tables("CAMPOS").Columns.Count - 1
                CAMPO = bdOC.ds.Tables("CAMPOS").Columns(i).ColumnName
                If ColeccionCampos.Trim = GL_VACIO Then

                    If CAMPO.ToUpper = "CONTADOR" Then
                        If TablaNueva.ToUpper = "INMUEBLES" Or TablaNueva.ToUpper = "CLIENTES" Then
                            ColeccionCampos = CAMPO
                        End If
                    Else
                        ColeccionCampos = CAMPO
                    End If

                Else
                    If CAMPO.ToUpper = "CONTADOR" Then
                        If TablaNueva.ToUpper = "INMUEBLES" Or TablaNueva.ToUpper = "CLIENTES" Then
                            ColeccionCampos &= ", " & CAMPO
                        End If
                    Else
                        ColeccionCampos &= ", " & CAMPO
                    End If

                End If
            Next

            'dtr = bdBD.ExecuteReader("SELECT  COL.name AS columna	FROM .syscolumns COL	JOIN sysobjects OBJ ON OBJ.id = COL.id	JOIN systypes TYP ON TYP.xusertype = COL.xtype" & _
            '                   " LEFT JOIN sysforeignkeys FK ON FK.fkey = COL.colid AND FK.fkeyid=OBJ.id LEFT JOIN sysobjects OBJ2 ON OBJ2.id = FK.rkeyid" & _
            '                   " LEFT JOIN syscolumns COL2 ON COL2.colid = FK.rkey AND COL2.id = OBJ2.id WHERE OBJ.name = '" & TablaNueva & "' AND (OBJ.xtype='U' OR OBJ.xtype='V')")

            'If dtr.hasrows Then
            '    While dtr.read

            '        If ColeccionCampos = "" Then
            '            If dtr("columna").ToString.ToUpper <> "CONTADOR" AndAlso dtr("columna").ToString.ToUpper <> "MARCADETIEMPO" Then
            '                ColeccionCampos = dtr("columna")
            '            End If
            '        Else
            '            If dtr("columna").ToString.ToUpper <> "CONTADOR" Then
            '                ColeccionCampos &= ", " & dtr("columna")
            '            End If
            '        End If

            '    End While
            'End If


            Dim NuevoContador As Integer = 0
            Dim NuevaReferencia As String = ""


            Dim ColeccionCamposValores As String = ColeccionCampos

            If TablaNueva.ToUpper = "INMUEBLES" Or TablaNueva.ToUpper = "CLIENTES" Then
                NuevoContador = clGenerales.SiguienteRegistro("Contador", "Inmuebles") ',  " WHERE CodigoEmpresa =" & DatosEmpresa.Codigo)

                ColeccionCamposValores = Replace(ColeccionCamposValores, "Contador, ", NuevoContador & ", ")

            End If

            If TablaNueva.ToUpper = "INMUEBLES" Then

                NuevaReferencia = Funciones.SiguienteLetra(BD_CERO.Execute("SELECT MAX(Referencia) FROM Inmuebles", False)) 'clGenerales.SiguienteRegistro(Funciones.SQL_CONVERT("INT", "Referencia"), "Inmuebles") ', " WHERE CodigoEmpresa =" & DatosEmpresa.Codigo)

                ColeccionCamposValores = Replace(ColeccionCamposValores, "Referencia, ", "'" & NuevaReferencia & "', ")
            End If


            BD_CERO.Execute("INSERT INTO " & TablaNueva & "(" & ColeccionCampos & ") SELECT " & ColeccionCamposValores & " FROM " & TablaVieja & " WHERE Contador =  " & Contador)


            If TablaNueva.ToUpper = "INMUEBLES" Then
                Sql = "UPDATE " & TablaNueva & " SET FechaAlta = " & GL_SQL_GETDATE & ", ContadorEmpleado=" & Empleado & ",Ocultar=0, FotosWeb = 0 WHERE Contador =  " & NuevoContador
                BD_CERO.Execute(Sql)
                'BD_CERO.Execute(GL_SQL_DELETE & "FROM UltimaReferencia WHERE CodigoEmpresa=" & DatosEmpresa.Codigo)
                'BD_CERO.Execute("INSERT INTO UltimaReferencia (CodigoEmpresa, Referencia, Contador) VALUES(" & DatosEmpresa.Codigo & ",'" & NuevaReferencia & "', " & NuevoContador & ")")

                FuncionesBD.Accion("INSERT", "Inmuebles", NuevaReferencia)

                Return NuevaReferencia
            End If


        End Function
        'Public Shared Sub sp_InsertarCambiosPrecio(ByVal ContadorInmueble As Integer, ByVal ContadorEmpleado As Integer, ByVal Precio As Integer, ByVal Cambio As String)

        '    BD_CERO.Execute("INSERT INTO CambiosPrecio (ContadorInmueble, ContadorEmpleado, Fecha, Precio, Cambio) VALUES(" & _
        '      ContadorInmueble & "," & ContadorEmpleado & "," & gl_sql_getdate & "," & Precio & ",'" & Cambio & "')")
        '    If BD_CERO.Execute("SELECT COUNT(*) FROM CambiosPrecio WHERE ContadorInmueble = " & ContadorInmueble) > 1 Then
        '        BD_CERO.Execute("" & GL_SQL_DELETE & "FROM NuevosCambiosPrecios WHERE ContadorInmueble = " & ContadorInmueble)
        '    End If
        '    BD_CERO.Execute("INSERT INTO NuevosCambiosPrecios VALUES (" & ContadorInmueble & " , " & gl_sql_getdate & " )")
        'End Sub


        Public Shared Sub sp_InsertarEmailConfiguracion(ByVal Empresa As Integer, ByVal EMail As String, ByVal Usuario As String, ByVal NombreMostrar As String, ByVal Contrasena As String, ByVal SMTP As String,
                                                        ByVal POP3Host As String, ByVal PuertoSMTP As Integer, ByVal PuertoPOP3 As Integer, ByVal Asunto As String, ByVal Url As String, ByVal Mensaje As String,
                                                        ByVal html As String, ByVal SSL As Boolean)
            BD_CERO.Execute("" & GL_SQL_DELETE & "FROM EmailConfiguracion WHERE   Empresa = " & Empresa)

            BD_CERO.Execute("INSERT INTO EmailConfiguracion (Empresa, EMail,Usuario ,NombreMostrar,Contrasena,SMTP,POP3Host,PuertoSMTP,PuertoPOP3,Asunto,Url,Mensaje,html,SSL)VALUES(" & _
                  Empresa & ",'" & EMail & "','" & Usuario & "','" & NombreMostrar & "','" & Contrasena & "','" & SMTP & "','" & POP3Host & "'," & _
                    PuertoSMTP & "," & PuertoPOP3 & ",'" & Asunto & "','" & Url & "','" & Mensaje & "','" & html & "'," & Funciones.pf_ReplaceTrueFalse(SSL) & ")")


        End Sub


        Public Shared Function ObtenerReferenciasQueCuadran(ByVal ContadorCliente As Integer, Optional ByVal Reservado As Boolean = False, Optional ByVal Campos As String = "Contador", Optional ByVal Tipo As String = "", Optional ByVal DevolverSelect As Boolean = False, Optional ByVal WhereExtra As String = "") As String

            Dim bdBD As New BaseDatos
            Dim sel As String = ""
            Dim dtr As Object
            dtr = bdBD.ExecuteReader("SELECT * FROM Clientes WHERE Contador =" & ContadorCliente)
            If dtr.hasrows Then
                dtr.read()
                If WhereExtra <> "" Then
                    If WhereExtra.Length > 4 AndAlso InStr(Microsoft.VisualBasic.Left(WhereExtra, 5), "AND ", CompareMethod.Text) > 0 Then
                    Else
                        WhereExtra = " AND " & WhereExtra
                    End If
                End If
                sel = "SELECT " & Campos & " FROM Inmuebles I WHERE CodigoEmpresa = " & dtr("CodigoEmpresa") & WhereExtra
                sel &= " AND Baja=0"
                Select Case Tipo
                    Case "Novedades"
                        If Not IsDBNull(dtr("FechaPuestoAlDia")) Then
                            sel &= " AND (FechaUltimoCambio >= '" & dtr("FechaPuestoAlDia") & "')"
                        End If

                    Case "Altas"
                        sel &= " AND FechaAlta >= '" & dtr("FechaEmailListado") & "'"
                    Case "CambiosPrecios"
                        sel &= " AND FechaCambioPrecio >= '" & dtr("FechaEmailListado") & "'"
                    Case "ReservasQuitadas"
                        sel &= " AND FechaQuitaReservado >= '" & dtr("FechaEmailListado") & "'"
                End Select

                If dtr("TipoVenta") = "OPCIÓN A COMPRA" Then
                    sel &= " AND ( (TipoVenta = '" & Funciones.pf_ReplaceComillas(dtr("TipoVenta")) & "') OR (TipoVenta = '" & GL_Palabra_Alquiler & "' AND AlquilerOpcionCompra = " & GL_SQL_VALOR_1 & "))" '= " & GL_SQL_VALOR_1 & "))"
                Else
                    If dtr("TipoVenta") = "VACACIONAL" Then
                        sel &= " AND ( (TipoVenta = '" & Funciones.pf_ReplaceComillas(dtr("TipoVenta")) & "') OR (TipoVenta = '" & GL_Palabra_Alquiler & "'  AND AlquilerVacacional = " & GL_SQL_VALOR_1 & "))"
                    Else
                        If dtr("TipoVenta") <> "" Then
                            sel &= " AND TipoVenta = '" & Funciones.pf_ReplaceComillas(dtr("TipoVenta")) & "'"
                        End If

                    End If
                End If

                If dtr("AlquilerOpcionCompra") = GL_SQL_VALOR_1 Then
                    sel &= " AND AlquilerOpcionCompra = " & Funciones.pf_ReplaceTrueFalseNull(dtr("AlquilerOpcionCompra"))

                End If

                If Not Reservado Then
                    sel &= " AND Reservado = " & Funciones.pf_ReplaceTrueFalseNull(Reservado)
                End If

                sel &= " AND Precio >=" & Funciones.pf_ReplaceIntNull(dtr("PrecioD")) & "  AND Precio <=" & Funciones.pf_ReplaceIntNull(dtr("PrecioH"))
                sel &= " AND Metros  >= " & dtr("MetrosD") & " AND Metros  <= " & dtr("MetrosH") & ""
                sel &= " AND Habitaciones  >= " & dtr("HabitacionesD") & "  AND Habitaciones <= " & dtr("HabitacionesH") & ""

                Dim AlturaDesde As Integer
                If dtr("AlturaD") = 0 Then
                    AlturaDesde = -2
                Else
                    AlturaDesde = dtr("AlturaD")
                End If

                Dim MPlaya As String
                If dtr("MPlaya") <> 0 Then
                    MPlaya = dtr("MPlaya") & " AND MPlaya * -1 <= " & dtr("MPlaya")
                Else
                    MPlaya = "MPlaya"
                End If

                sel &= " AND Altura >= " & AlturaDesde & " AND Altura <= " & dtr("AlturaH") & ""
                sel &= " AND MPlaya <= " & MPlaya
                sel &= " AND Banos >= " & Funciones.pf_ReplaceIntNull(dtr("Banos")) & " "
                sel &= " AND (MTerraza >= " & dtr("MTerraza") & " OR MTerraza2 >= " & dtr("MTerraza") & ")"
                sel &= " AND (MJardin >= " & dtr("MJardin") & "  )"
                sel &= " AND (Personas >=  " & Funciones.pf_ReplaceIntNull(dtr("Personas")) & " OR Personas IS NULL)  "


                If Not IsDBNull(dtr("Balcon")) Then
                    If dtr("Balcon") Then
                        sel &= " AND (Balcon =" & GL_SQL_VALOR_1 & " OR Patio =" & GL_SQL_VALOR_1 & " OR Terraza =" & GL_SQL_VALOR_1 & ")"
                    Else
                        sel &= " AND (Balcon =0)"
                    End If
                End If


                If Not IsDBNull(dtr("Patio")) Then
                    If Not IsDBNull(dtr("Balcon")) AndAlso dtr("Balcon") Then
                    Else
                        If dtr("Patio") Then
                            sel &= " AND (Patio =" & GL_SQL_VALOR_1 & " OR Terraza =" & GL_SQL_VALOR_1 & ")"
                        Else
                            sel &= " AND (Patio =0)"
                        End If
                    End If
                End If

                If Not IsDBNull(dtr("Terraza")) Then
                    If (Not IsDBNull(dtr("Balcon")) AndAlso dtr("Balcon")) Or (Not IsDBNull(dtr("Patio")) AndAlso dtr("Patio")) Then
                    Else
                        If dtr("Terraza") Then
                            sel &= " AND (Terraza =" & GL_SQL_VALOR_1 & ")"
                        Else
                            sel &= " AND (Terraza =0)"
                        End If
                    End If
                End If




                If Not IsDBNull(dtr("Galeria")) Then
                    sel &= " AND (Galeria = " & Funciones.pf_ReplaceTrueFalseNull(dtr("Galeria")) & ")"
                End If

                If Not IsDBNull(dtr("Ascensor")) Then
                    If Not dtr("Ascensor") Then
                        sel &= " AND (Ascensor = " & Funciones.pf_ReplaceTrueFalseNull(dtr("Ascensor")) & ")"
                    Else
                        sel &= " AND ( (Altura <= 0) OR (Ascensor = " & Funciones.pf_ReplaceTrueFalseNull(dtr("Ascensor")) & " AND Altura > 0))"
                    End If
                Else
                    If dtr("PisoAscensor") > 0 Then
                        sel &= " AND ( (Altura <= " & dtr("PisoAscensor") & _
                        ") OR (Ascensor = " & GL_SQL_VALOR_1 & "  AND Altura > " & dtr("PisoAscensor") & ") )"
                    End If
                End If

                '        sel &= " AND ((" & Funciones.pf_ReplaceTrueFalseNull(dtr("Ascensor")) & " IS NULL AND (Ascensor IS NULL OR (Ascensor = 0 AND Altura<=" & IIf(dtr("PisoAscensor") = 0, 5000, dtr("PisoAscensor")) & ") OR Ascensor =" & GL_SQL_VALOR_1 & ")) OR (Ascensor = " & Funciones.pf_ReplaceTrueFalseNull(dtr("Ascensor")) & " OR (" & Funciones.pf_ReplaceTrueFalseNull(dtr("Ascensor")) & " =" & GL_SQL_VALOR_1 & " AND Altura<=0))) "
                'sel &= " AND ((" & Funciones.pf_ReplaceTrueFalseNull(dtr("Ascensor")) & " IS NULL AND (Ascensor IS NULL OR (Ascensor = 0 AND Altura<=" & IIf(dtr("PisoAscensor") = 0, 5000, dtr("PisoAscensor")) & ") OR Ascensor =" & GL_SQL_VALOR_1 & ")) OR (Ascensor = " & Funciones.pf_ReplaceTrueFalseNull(dtr("Ascensor")) & " OR (" & Funciones.pf_ReplaceTrueFalseNull(dtr("Ascensor")) & " =" & GL_SQL_VALOR_1 & " AND Altura<=0))) "

                If Not IsDBNull(dtr("SemiAmueblado")) Then sel &= " AND (SemiAmueblado = " & Funciones.pf_ReplaceTrueFalseNull(dtr("SemiAmueblado")) & " OR (SemiAmueblado =" & GL_SQL_VALOR_1 & " AND Amueblado =" & GL_SQL_VALOR_1 & "))"
                'Else
                If Not IsDBNull(dtr("Amueblado")) Then sel &= " AND (Amueblado = " & Funciones.pf_ReplaceTrueFalseNull(dtr("Amueblado")) & ")"
                'End If



                If Not IsDBNull(dtr("AccesoMinusvalidos")) Then sel &= " AND (AccesoMinusvalidos = " & Funciones.pf_ReplaceTrueFalseNull(dtr("AccesoMinusvalidos")) & ")"
                If Not IsDBNull(dtr("Urbanizacion")) Then sel &= " AND (Urbanizacion = " & Funciones.pf_ReplaceTrueFalseNull(dtr("Urbanizacion")) & ")"

                If Not IsDBNull(dtr("Piscina")) Then sel &= " AND (Piscina = " & Funciones.pf_ReplaceTrueFalseNull(dtr("Piscina")) & ")"
                If Not IsDBNull(dtr("Duplex")) Then sel &= " AND (Duplex = " & Funciones.pf_ReplaceTrueFalseNull(dtr("Duplex")) & ")"
                If Not IsDBNull(dtr("GarajeCerrado")) Then sel &= " AND (GarajeCerrado = " & Funciones.pf_ReplaceTrueFalseNull(dtr("GarajeCerrado")) & ")"
                If Not IsDBNull(dtr("Jardin")) Then sel &= " AND (Jardin = " & Funciones.pf_ReplaceTrueFalseNull(dtr("Jardin")) & ")"
                If Not IsDBNull(dtr("CocinaOffice")) Then sel &= " AND (CocinaOffice = " & Funciones.pf_ReplaceTrueFalseNull(dtr("CocinaOffice")) & ")"



                If Not IsDBNull(dtr("Banco")) Then sel &= " AND (Banco = " & Funciones.pf_ReplaceTrueFalseNull(dtr("Banco")) & ")"
                If Not IsDBNull(dtr("AireAcondicionado")) Then sel &= " AND (AireAcondicionado = " & Funciones.pf_ReplaceTrueFalseNull(dtr("AireAcondicionado")) & ")"
                If Not IsDBNull(dtr("Calefaccion")) Then sel &= " AND (Calefaccion = " & Funciones.pf_ReplaceTrueFalseNull(dtr("Calefaccion")) & ")"
                If Not IsDBNull(dtr("Electrodomesticos")) Then sel &= " AND (Electrodomesticos = " & Funciones.pf_ReplaceTrueFalseNull(dtr("Electrodomesticos")) & ")"
                If Not IsDBNull(dtr("ZonaComercial")) Then sel &= " AND (ZonaComercial = " & Funciones.pf_ReplaceTrueFalseNull(dtr("ZonaComercial")) & ")"
                If Not IsDBNull(dtr("PrimeraLineaPlaya")) Then sel &= " AND (PrimeraLineaPlaya = " & Funciones.pf_ReplaceTrueFalseNull(dtr("PrimeraLineaPlaya")) & ")"
                If Not IsDBNull(dtr("VistasAlMar")) Then sel &= " AND (VistasAlMar = " & Funciones.pf_ReplaceTrueFalseNull(dtr("VistasAlMar")) & ")"
                If Not IsDBNull(dtr("Trastero")) Then sel &= " AND (Trastero = " & Funciones.pf_ReplaceTrueFalseNull(dtr("Trastero")) & ")"
                If Not IsDBNull(dtr("Garaje")) Then sel &= " AND (Garaje = " & Funciones.pf_ReplaceTrueFalseNull(dtr("Garaje")) & ")"

                If Not IsDBNull(dtr("TipoCalentador")) Then sel &= " AND (TipoCalentador = " & Funciones.pf_ReplaceTrueFalseNull(dtr("TipoCalentador")) & " OR TipoCalentador IS NULL )"
                If Not IsDBNull(dtr("TipoCocina")) Then sel &= " AND (TipoCocina = " & Funciones.pf_ReplaceTrueFalseNull(dtr("TipoCocina")) & " OR TipoCocina IS NULL )"

                If Not IsDBNull(dtr("Montana")) Then sel &= " AND (Montana = " & Funciones.pf_ReplaceTrueFalseNull(dtr("Montana")) & ")"
                If Not IsDBNull(dtr("PlayaDerecha")) Then sel &= " AND (PlayaDerecha = " & Funciones.pf_ReplaceTrueFalseNull(dtr("PlayaDerecha")) & ")"

                Dim SelPoblacion As String = ""
                If BD_CERO.Execute("SELECT COUNT(*) FROM ClientesPoblacion WHERE ContadorCliente  = " & ContadorCliente, False) > 0 Then
                    SelPoblacion = " AND Poblacion IN (SELECT c.Poblacion from ClientesPoblacion c WHERE ContadorCliente  = " & ContadorCliente & ")"
                End If

                Dim SelOrientacion As String = ""
                If BD_CERO.Execute("SELECT COUNT(*) FROM ClientesOrientacion WHERE ContadorCliente  = " & ContadorCliente, False) > 0 Then
                    SelOrientacion = " AND (Orientacion IN (SELECT c.Orientacion from ClientesOrientacion c WHERE ContadorCliente  = " & ContadorCliente & ") OR Orientacion = '' )"
                End If

                Dim SelZona As String = ""
                If BD_CERO.Execute("SELECT COUNT(*) FROM ClientesZona WHERE ContadorCliente  = " & ContadorCliente, False) > 0 Then
                    SelZona = " AND (Zona IN (SELECT c.Zona from ClientesZona c WHERE ContadorCliente  = " & ContadorCliente & ") OR Zona = '' )"
                End If

                Dim SelEstado As String = ""
                If BD_CERO.Execute("SELECT COUNT(*) FROM ClientesEstado WHERE ContadorCliente  = " & ContadorCliente, False) > 0 Then
                    SelEstado = " AND (Estado in (SELECT T.Estado FROM Estado T INNER JOIN ClientesEstado C ON T.Prioridad <= (SELECT Prioridad FROM Estado WHERE Estado = C.Estado) AND T.TipoPrioridad = (SELECT TipoPrioridad FROM Estado WHERE Estado = C.Estado) WHERE ContadorCliente  = " & ContadorCliente & ") OR Estado = '' )"
                End If

                Dim SelTipo As String = ""
                If BD_CERO.Execute("SELECT COUNT(*) FROM ClientesTipo WHERE ContadorCliente  = " & ContadorCliente, False) > 0 Then
                    SelTipo = " AND (Tipo in (SELECT T.Tipo FROM Tipo T INNER JOIN ClientesTipo C ON T.Prioridad <= (SELECT Prioridad FROM Tipo WHERE Tipo = C.Tipo) AND T.TipoPrioridad = (SELECT TipoPrioridad FROM Tipo WHERE Tipo = C.Tipo) WHERE ContadorCliente  = " & ContadorCliente & ") OR Tipo = '' )"
                End If

                sel &= SelPoblacion & SelZona & SelOrientacion & SelTipo & SelEstado

            End If
            dtr.close()

            If DevolverSelect Then
                Return sel
            Else
                If Campos = "Contador" Then
                    dtr = bdBD.ExecuteReader(sel)
                    If dtr.hasrows Then
                        sel = ""
                        While dtr.read
                            sel &= dtr("Contador") & ","
                        End While
                        sel = sel.Substring(0, sel.Length - 1)
                    End If
                    dtr.close()
                ElseIf Campos = "COUNT(Contador)" Then
                    sel = BD_CERO.Execute(sel, False)
                End If
                bdBD.CerrarBD()
                Return sel

            End If


        End Function

        Public Shared Function ObtenerReferenciasQueCuadranEnSelectCliente(Optional ByVal ContadorInmueble As Integer = 0, Optional ByVal Reservado As Boolean = False, Optional ByVal TipoBusqueda As String = "", Optional ByVal Campos As String = "Contador", Optional ByVal WhereExtra As String = "") As String
            Dim sel As String = ""

            ' AND Reservado = 0 
            Dim TipoVenta As String = ""

            Dim Tipo_TipoPrioriodad As String = ""
            Dim Tipo_Prioriodad As Integer = 0

            Dim Estado_TipoPrioriodad As String = ""
            Dim Estado_Prioriodad As Integer = 0

            Estado_TipoPrioriodad = BD_CERO.Execute("SELECT TipoPrioridad FROM Estado WHERE Estado = (SELECT Estado FROM Inmuebles WHERE Contador = " & ContadorInmueble & ")", False, "")
            Estado_Prioriodad = BD_CERO.Execute("SELECT Prioridad FROM Estado WHERE Estado = (SELECT Estado FROM Inmuebles WHERE Contador = " & ContadorInmueble & ")", False, 9999)

            Tipo_TipoPrioriodad = BD_CERO.Execute("SELECT TipoPrioridad FROM Tipo WHERE Tipo = (SELECT Tipo FROM Inmuebles WHERE Contador = " & ContadorInmueble & ")", False, "")
            Tipo_Prioriodad = BD_CERO.Execute("SELECT Prioridad FROM Tipo WHERE Tipo = (SELECT Tipo FROM Inmuebles WHERE Contador = " & ContadorInmueble & ")", False, 9999)

            TipoVenta = BD_CERO.Execute("SELECT TipoVenta FROM Inmuebles WHERE Contador = " & ContadorInmueble, False, "")

            Dim TVENTA As String = " ('" & TipoVenta & "' = C.TipoVenta OR '' = C.TipoVenta)"


            Dim WhereTotal As String = ""

            Dim WhereContadorInmueble As String = ""
            If ContadorInmueble <> 0 Then
                WhereContadorInmueble = " I.Contador = " & ContadorInmueble
                If WhereTotal = "" Then
                    WhereTotal = " WHERE " & WhereContadorInmueble
                Else
                    WhereTotal = WhereTotal & " AND " & WhereContadorInmueble
                End If
            End If

            Dim WhereTipoBusqueda As String = ""
            Select Case TipoBusqueda
                'Case "Altas"
                '    WhereTipoBusqueda = " (" & Funciones.SQL_CASE_ISNULL("FechaAlta,'01/01/1900'") & " > " & Funciones.SQL_CASE_ISNULL("C.FechaEmailListado,'01/01/1900'") & " )"
                'Case "CambiosPrecios"
                '    WhereTipoBusqueda = " (" & Funciones.SQL_CASE_ISNULL("FechaCambioPrecio,'01/01/1900'") & " > " & Funciones.SQL_CASE_ISNULL("C.FechaEmailListado,'01/01/1900'") & " )"
                'Case "ReservasQuitadas"
                '    WhereTipoBusqueda = " (" & Funciones.SQL_CASE_ISNULL("FechaQuitaReservado,'01/01/1900'") & " > " & Funciones.SQL_CASE_ISNULL("C.FechaEmailListado,'01/01/1900'") & " )"
                Case "Novedades"
                    WhereTipoBusqueda = " (" & Funciones.SQL_CASE_ISNULL("FechaUltimoCambio," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & " > " & Funciones.SQL_CASE_ISNULL("C.FechaPuestoAlDia," & Funciones.pf_ReplaceFecha(CDate("01/01/1900"))) & _
                        " AND (SELECT COUNT(*) FROM ClientesComunicaciones WHERE ContadorCliente = C.Contador AND ContadorInmueble = I.Contador)= 0  )"

            End Select
            If TipoBusqueda <> "" Then

                If WhereTotal = "" Then
                    WhereTotal = " WHERE " & WhereTipoBusqueda
                Else
                    WhereTotal = WhereTotal & " AND " & WhereTipoBusqueda
                End If
            End If

            Dim WhereReservado As String = ""
            If Not Reservado Then
                WhereReservado = " Reservado = 0 "
                If WhereTotal = "" Then
                    WhereTotal = " WHERE " & WhereReservado
                Else
                    WhereTotal = WhereTotal & " AND " & WhereReservado
                End If
            End If


            If WhereTotal = "" Then
                WhereTotal = " WHERE Baja = 0 AND I.CodigoEmpresa = C.CodigoEmpresa "
            Else
                WhereTotal = WhereTotal & " AND Baja = 0 AND I.CodigoEmpresa = C.CodigoEmpresa "
            End If


            If WhereExtra <> "" Then
                If WhereTotal = "" Then
                    WhereTotal = " WHERE " & WhereExtra
                Else
                    WhereTotal = WhereTotal & " AND " & WhereExtra
                End If
            End If



            sel = " SELECT " & Campos & " FROM Inmuebles I " & WhereTotal & _
                    " AND " & TVENTA & " AND Precio >= C.PrecioD  AND Precio  <= C.PrecioH " & _
                    " AND Metros >= C.MetrosD  AND Metros <= C.MetrosH " & _
                    " AND Habitaciones >= C.HabitacionesD  AND Habitaciones  <= C.HabitacionesH " & _
                    " AND Banos >= C.Banos  AND (MTerraza  >= C.MTerraza OR MTerraza2  >= C.MTerraza) AND (MJardin  >= C.MJardin)" & _
                    " AND (Personas >= C.Personas  OR Personas IS NULL)"

            sel &= " AND Altura <= C.AlturaH AND ((C.AlturaD<>0 AND Altura >= C.AlturaD) OR (C.AlturaD=0 AND Altura >= -2))"
            'sel &= " AND ((C.MPlaya <> 0 AND MPlaya <= C.MPlaya) OR  C.MPlaya=0)"
            sel &= " AND ((C.MPlaya <> 0 AND MPlaya <= C.MPlaya AND MPlaya * -1 <= C.MPlaya) OR  C.MPlaya=0)"

            sel &= " AND (C.Balcon IS NULL OR Balcon = C.Balcon  OR (C.Balcon = " & GL_SQL_VALOR_1 & " AND Patio = " & GL_SQL_VALOR_1 & "  )  OR (C.Balcon = " & GL_SQL_VALOR_1 & " AND Terraza = " & GL_SQL_VALOR_1 & "  ))"
            sel &= " AND (C.Patio IS NULL  OR Patio = C.Patio OR (C.Patio = " & GL_SQL_VALOR_1 & " AND Terraza = " & GL_SQL_VALOR_1 & "  ))"

            'sel &= " AND ((C.Ascensor IS NULL AND " & _
            '   "(Ascensor IS NULL OR " & _
            '   "(Ascensor = 0 AND ((C.PisoAscensor=0 AND Altura <=5000) OR (C.PisoAscensor<>0 AND Altura <=C.PisoAscensor))) OR " & _
            '   " C.Ascensor IS NULL ))" & _
            '   " OR (Ascensor = C.Ascensor OR (C.Ascensor =" & GL_SQL_VALOR_1 & " AND Altura <=C.PisoAscensor))) "


            'Case "SI"

            Dim Ascensor As Boolean = BD_CERO.Execute("SELECT Ascensor FROM Inmuebles WHERE Contador = " & ContadorInmueble, False, "")

            If Ascensor Then
                sel &= " AND (C.Ascensor = " & GL_SQL_VALOR_1 & " OR C.Ascensor IS NULL OR (C.Ascensor <> " & GL_SQL_VALOR_1 & " AND C.PisoAscensor>0 AND Altura  >= PisoAscensor) ) "
            Else
                sel &= " AND ( (C.Ascensor <> " & GL_SQL_VALOR_1 & ")   OR " & _
                    " (C.Ascensor IS NULL  AND (PisoAscensor= 0 OR PisoAscensor>= Altura or Altura <=0 )) OR " & _
                    " (C.Ascensor = " & GL_SQL_VALOR_1 & " AND (Altura <=0)))"
            End If


            'Case "NO"





            '    sel &= " AND (C.AlquilerOpcionCompra IS NULL OR AlquilerOpcionCompra = C.AlquilerOpcionCompra)"
            sel &= " AND (C.Terraza IS NULL OR Terraza = C.Terraza)"
            sel &= " AND (C.Galeria IS NULL OR Galeria = C.Galeria)"

            sel &= " AND (C.SemiAmueblado IS NULL OR C.SemiAmueblado =SemiAmueblado OR (C.SemiAmueblado=" & GL_SQL_VALOR_1 & " AND Amueblado=" & GL_SQL_VALOR_1 & "))"
            sel &= " AND (C.Amueblado IS NULL OR C.Amueblado = Amueblado)"


            sel &= " AND (C.Banco IS NULL  OR Banco = C.Banco)"
            sel &= " AND (C.AccesoMinusvalidos IS NULL  OR AccesoMinusvalidos = C.AccesoMinusvalidos)"
            sel &= " AND (C.Urbanizacion IS NULL  OR Urbanizacion = C.Urbanizacion)"
            sel &= " AND (C.Piscina IS NULL  OR Piscina = C.Piscina)"
            sel &= " AND (C.Duplex IS NULL  OR Duplex = C.Duplex)"
            sel &= " AND (C.GarajeCerrado IS NULL OR GarajeCerrado = C.GarajeCerrado)"
            sel &= " AND (C.Jardin IS NULL OR Jardin = C.Jardin)"
            sel &= " AND (C.CocinaOffice IS NULL OR CocinaOffice = C.CocinaOffice)"

            sel &= " AND (C.AireAcondicionado IS NULL OR AireAcondicionado = C.AireAcondicionado)"
            sel &= " AND (C.Calefaccion IS NULL OR Calefaccion = C.Calefaccion)"
            sel &= " AND (C.Electrodomesticos IS NULL  OR Electrodomesticos = C.Electrodomesticos)"
            sel &= " AND (C.ZonaComercial IS NULL OR ZonaComercial = C.ZonaComercial)"
            sel &= " AND (C.PrimeraLineaPlaya IS NULL OR PrimeraLineaPlaya = C.PrimeraLineaPlaya)"
            sel &= " AND (C.VistasAlMar IS NULL OR VistasAlMar = C.VistasAlMar)"
            sel &= " AND (C.Trastero IS NULL OR Trastero = C.Trastero)"
            sel &= " AND (C.Garaje IS NULL OR Garaje = C.Garaje)"

            sel &= " AND (C.TipoCalentador IS NULL OR TipoCalentador = C.TipoCalentador)"
            sel &= " AND (C.TipoCocina IS NULL OR TipoCocina = C.TipoCocina)"

            sel &= " AND (C.Montana IS NULL OR Montana = C.Montana)"
            sel &= " AND (C.PlayaDerecha IS NULL OR PlayaDerecha = C.PlayaDerecha)"

            'Dim aa As String = " AND ((Poblacion in (SELECT CC.Poblacion from ClientesPoblacion CC WHERE ContadorCliente  = C.Contador UNION ALL SELECT " & Funciones.SQL_CASE({"(SELECT COUNT(*) FROM ClientesPoblacion WHERE ContadorCliente = C.Contador ) > 0 ", "(SELECT COUNT(*) FROM ClientesPoblacion WHERE ContadorCliente = C.Contador ) <= 0"}, {" NULL ", " Poblacion "}) & ")) OR Poblacion='')"

            sel &= " AND (I.Poblacion = '' OR ( (SELECT COUNT(*)  FROM ClientesPoblacion CC WHERE ContadorCliente = C.Contador AND CC.Poblacion = I.Poblacion) > 0 OR (SELECT COUNT(*)  FROM ClientesPoblacion WHERE ContadorCliente = C.Contador ) = 0))"
            sel &= " AND (I.Zona = '' OR ( (SELECT COUNT(*)  FROM ClientesZona CC WHERE ContadorCliente = C.Contador AND CC.Zona = I.Zona) > 0 OR (SELECT COUNT(*)  FROM ClientesZona WHERE ContadorCliente = C.Contador ) = 0))"
            sel &= " AND (I.Orientacion = '' OR ( (SELECT COUNT(*)  FROM ClientesOrientacion CC WHERE ContadorCliente = C.Contador AND CC.Orientacion = I.Orientacion) > 0 OR (SELECT COUNT(*)  FROM ClientesOrientacion WHERE ContadorCliente = C.Contador ) = 0))"

            sel &= " AND (I.Tipo = '' OR (  (SELECT COUNT(*)  FROM ClientesTipo CC  WHERE  ContadorCliente = C.Contador AND CC.Tipo IN ( SELECT TIPO FROM TIPO WHERE PRIORIDAD >= " & Tipo_Prioriodad & " AND TipoPrioridad = '" & Tipo_TipoPrioriodad & "'  )) > 0 OR (SELECT COUNT(*)  FROM ClientesTipo WHERE ContadorCliente = C.Contador ) = 0) )"
            sel &= " AND (I.Estado = '' OR (  (SELECT COUNT(*)  FROM ClientesEstado CC  WHERE  ContadorCliente = C.Contador AND CC.Estado IN ( SELECT Estado FROM Estado WHERE PRIORIDAD >= " & Estado_Prioriodad & " AND TipoPrioridad = '" & Estado_TipoPrioriodad & "'  )) > 0 OR (SELECT COUNT(*)  FROM ClientesEstado WHERE ContadorCliente = C.Contador ) = 0) )"


            '   sel &= " AND C.Nombre = 'PRUEBAS 1'"

            ' sel &= " AND ((Poblacion in (SELECT CC.Poblacion from ClientesPoblacion CC WHERE ContadorCliente  = C.Contador UNION ALL SELECT " & Funciones.SQL_CASE({"(SELECT COUNT(*) FROM ClientesPoblacion WHERE ContadorCliente = C.Contador ) > 0 ", "(SELECT COUNT(*) FROM ClientesPoblacion WHERE ContadorCliente = C.Contador ) <= 0"}, {" NULL ", " Poblacion "}) & ")) OR Poblacion='')"
            'sel &= " AND ((Zona in (SELECT CC.Zona from ClientesZona CC WHERE ContadorCliente  = C.Contador UNION ALL SELECT " & Funciones.SQL_CASE({"(SELECT COUNT(*) FROM ClientesZona WHERE ContadorCliente = C.Contador ) > 0 ", "(SELECT COUNT(*) FROM ClientesZona WHERE ContadorCliente = C.Contador ) <= 0"}, {" NULL ", " Zona "}) & ")) OR Zona='')"
            '   sel &= " AND ((Orientacion in (SELECT CC.Orientacion from ClientesOrientacion CC WHERE ContadorCliente  = C.Contador UNION ALL SELECT " & Funciones.SQL_CASE({"(SELECT COUNT(*) FROM ClientesOrientacion WHERE ContadorCliente = C.Contador ) > 0 ", "(SELECT COUNT(*) FROM ClientesOrientacion WHERE ContadorCliente = C.Contador ) <= 0"}, {" NULL ", " Orientacion "}) & ")) OR Orientacion='')"
            'sel &= " AND ((Tipo in (SELECT T.Tipo FROM Tipo T INNER JOIN ClientesTipo CC ON T.Prioridad <= (SELECT Prioridad FROM Tipo WHERE Tipo = CC.TIPO) "
            'sel &= " AND T.TipoPrioridad = (SELECT TOP 1 TipoPrioridad FROM Tipo WHERE Tipo = CC.TIPO ) WHERE(ContadorCliente = C.Contador)"
            'sel &= " UNION ALL SELECT " & Funciones.SQL_CASE({"(SELECT COUNT(*) FROM ClientesTipo WHERE ContadorCliente = C.Contador ) > 0", "(SELECT COUNT(*) FROM ClientesTipo WHERE ContadorCliente = C.Contador ) <= 0"}, {"NULL", "Tipo"}) & ")) OR Tipo='')"

            'sel &= " AND ((Estado in (SELECT T.Estado FROM Estado T INNER JOIN ClientesEstado CC ON T.Prioridad <= (SELECT Prioridad FROM Estado WHERE Estado = CC.Estado) "
            'sel &= " AND T.TipoPrioridad = (SELECT TipoPrioridad FROM Estado WHERE Estado = CC.Estado) WHERE ContadorCliente  = C.Contador UNION ALL SELECT " & Funciones.SQL_CASE({"(SELECT COUNT(*) FROM ClientesEstado WHERE ContadorCliente = C.Contador ) > 0", "(SELECT COUNT(*) FROM ClientesEstado WHERE ContadorCliente = C.Contador ) <= 0"}, {"NULL ", " Estado "}) & ")) OR Estado='')"


            Return sel



        End Function





        Public Shared Function fnFormatDate(ByVal Datetime As String, ByVal StringDate As String) As String
            StringDate = StringDate.Replace("/", " + %/% + ")

            If StringDate.Contains("YYYY") Then StringDate = StringDate.Replace("YYYY", "'$ATENA*E(Y'Y, @)'")
            If StringDate.Contains("YY") Then StringDate = StringDate.Replace("YY", "'RIGHT($ATENA*E(Y'Y, @),2)'")
            If StringDate.Contains("Month") Then StringDate = StringDate.Replace("Month", "'$ATENA*E(**, @)'")
            If StringDate.Contains("MON") Then StringDate = StringDate.Replace("MON", "'LEFT(" & GL_SQL_UPPER & "($ATENA*E(**, @)),3)'")
            If StringDate.Contains("Mon") Then StringDate = StringDate.Replace("Mon", "'LEFT($ATENA*E(**, @),3)'")
            If StringDate.Contains("MM") Then StringDate = StringDate.Replace("MM", "'RIGHT(%0%+CONVERT(VARCHAR,$ATEPART(**, @)),2)'")
            If StringDate.Contains("M") Then StringDate = StringDate.Replace("M", "'CONVERT(VARCHAR,$ATEPART(**, @))'")
            If StringDate.Contains("DD") Then StringDate = StringDate.Replace("DD", "'RIGHT(%0%+$ATENA*E($$, @),2)'")
            If StringDate.Contains("D") Then StringDate = StringDate.Replace("D", "'$ATENA*E($$, @)'")

            StringDate = StringDate.Replace("''", " + ")
            StringDate = StringDate.Replace("'", "")
            StringDate = StringDate.Replace("*", "M")
            StringDate = StringDate.Replace("$", "D")
            StringDate = StringDate.Replace("%", "'")
            StringDate = StringDate.Replace("@", Datetime)

            Return StringDate
        End Function


    End Class

    Public Class clInmueblesAlta

        Public Property Contador() As Int64
            Get
                Return m_Contador
            End Get
            Set(ByVal value As Int64)
                m_Contador = value
            End Set
        End Property
        Private m_Contador As Int64



        Public Property Referencia() As [String]
            Get
                Return m_Referencia
            End Get
            Set(ByVal value As [String])
                m_Referencia = value
            End Set
        End Property
        Private m_Referencia As [String]


        Public Property CodigoEmpresa() As Int32
            Get
                Return m_CodigoEmpresa
            End Get
            Set(ByVal value As Int32)
                m_CodigoEmpresa = value
            End Set
        End Property
        Private m_CodigoEmpresa As Int32


        Public Property Delegacion() As Int32
            Get
                Return m_Delegacion
            End Get
            Set(ByVal value As Int32)
                m_Delegacion = value
            End Set
        End Property
        Private m_Delegacion As Int32


        Public Property FechaAlta() As DateTime
            Get
                Return m_FechaAlta
            End Get
            Set(ByVal value As DateTime)
                m_FechaAlta = value
            End Set
        End Property
        Private m_FechaAlta As DateTime



        Public Property TipoVenta() As [String]
            Get
                Return m_TipoVenta
            End Get
            Set(ByVal value As [String])
                m_TipoVenta = value
            End Set
        End Property
        Private m_TipoVenta As [String]


        Public Property AlquilerOpcionCompra() As Integer
            Get
                Return m_AlquilerOpcionCompra
            End Get
            Set(ByVal value As Integer)
                m_AlquilerOpcionCompra = value
            End Set
        End Property
        Private m_AlquilerOpcionCompra As Integer

        Public Property AlquilerVacacional() As [Boolean]
            Get
                Return m_AlquilerVacacional
            End Get
            Set(ByVal value As [Boolean])
                m_AlquilerVacacional = value
            End Set
        End Property
        Private m_AlquilerVacacional As [Boolean]


        Public Property Precio() As Int32
            Get
                Return m_Precio
            End Get
            Set(ByVal value As Int32)
                m_Precio = value
            End Set
        End Property
        Private m_Precio As Int32



        Public Property Via() As [String]
            Get
                Return m_Via
            End Get
            Set(ByVal value As [String])
                m_Via = value
            End Set
        End Property
        Private m_Via As [String]



        Public Property Direccion() As [String]
            Get
                Return m_Direccion
            End Get
            Set(ByVal value As [String])
                m_Direccion = value
            End Set
        End Property
        Private m_Direccion As [String]



        Public Property Puerta() As [String]
            Get
                Return m_Puerta
            End Get
            Set(ByVal value As [String])
                m_Puerta = value
            End Set
        End Property
        Private m_Puerta As [String]



        Public Property Numero() As [String]
            Get
                Return m_Numero
            End Get
            Set(ByVal value As [String])
                m_Numero = value
            End Set
        End Property
        Private m_Numero As [String]


        Public Property Altura() As Int32
            Get
                Return m_Altura
            End Get
            Set(ByVal value As Int32)
                m_Altura = value
            End Set
        End Property
        Private m_Altura As Int32



        Public Property CodPostal() As [String]
            Get
                Return m_CodPostal
            End Get
            Set(ByVal value As [String])
                m_CodPostal = value
            End Set
        End Property
        Private m_CodPostal As [String]



        Public Property Poblacion() As [String]
            Get
                Return m_Poblacion
            End Get
            Set(ByVal value As [String])
                m_Poblacion = value
            End Set
        End Property
        Private m_Poblacion As [String]



        Public Property Provincia() As [String]
            Get
                Return m_Provincia
            End Get
            Set(ByVal value As [String])
                m_Provincia = value
            End Set
        End Property
        Private m_Provincia As [String]


        Public Property Metros() As Int32
            Get
                Return m_Metros
            End Get
            Set(ByVal value As Int32)
                m_Metros = value
            End Set
        End Property
        Private m_Metros As Int32


        Public Property Banos() As Int32
            Get
                Return m_Banos
            End Get
            Set(ByVal value As Int32)
                m_Banos = value
            End Set
        End Property
        Private m_Banos As Int32


        Public Property Habitaciones() As Int32
            Get
                Return m_Habitaciones
            End Get
            Set(ByVal value As Int32)
                m_Habitaciones = value
            End Set
        End Property
        Private m_Habitaciones As Int32


        Public Property AnoConstruccion() As Int32
            Get
                Return m_AnoConstruccion
            End Get
            Set(ByVal value As Int32)
                m_AnoConstruccion = value
            End Set
        End Property
        Private m_AnoConstruccion As Int32




        Public Property Ascensor() As [Boolean]
            Get
                Return m_Ascensor
            End Get
            Set(ByVal value As [Boolean])
                m_Ascensor = value
            End Set
        End Property
        Private m_Ascensor As [Boolean]


        Public Property CocinaOffice() As [Boolean]
            Get
                Return m_CocinaOffice
            End Get
            Set(ByVal value As [Boolean])
                m_CocinaOffice = value
            End Set
        End Property
        Private m_CocinaOffice As [Boolean]


        Public Property Piscina() As [Boolean]
            Get
                Return m_Piscina
            End Get
            Set(ByVal value As [Boolean])
                m_Piscina = value
            End Set
        End Property
        Private m_Piscina As [Boolean]


        Public Property Duplex() As [Boolean]
            Get
                Return m_Duplex
            End Get
            Set(ByVal value As [Boolean])
                m_Duplex = value
            End Set
        End Property
        Private m_Duplex As [Boolean]


        Public Property Galeria() As [Boolean]
            Get
                Return m_Galeria
            End Get
            Set(ByVal value As [Boolean])
                m_Galeria = value
            End Set
        End Property
        Private m_Galeria As [Boolean]



        Public Property Tipo() As [String]
            Get
                Return m_Tipo
            End Get
            Set(ByVal value As [String])
                m_Tipo = value
            End Set
        End Property
        Private m_Tipo As [String]



        Public Property Orientacion() As [String]
            Get
                Return m_Orientacion
            End Get
            Set(ByVal value As [String])
                m_Orientacion = value
            End Set
        End Property
        Private m_Orientacion As [String]



        Public Property Zona() As [String]
            Get
                Return m_Zona
            End Get
            Set(ByVal value As [String])
                m_Zona = value
            End Set
        End Property
        Private m_Zona As [String]



        Public Property Estado() As [String]
            Get
                Return m_Estado
            End Get
            Set(ByVal value As [String])
                m_Estado = value
            End Set
        End Property
        Private m_Estado As [String]


        Public Property Extras() As [String]
            Get
                Return m_Extras
            End Get
            Set(ByVal value As [String])
                m_Extras = value
            End Set
        End Property
        Private m_Extras As [String]


        Public Property Oportunidad() As [Boolean]
            Get
                Return m_Oportunidad
            End Get
            Set(ByVal value As [Boolean])
                m_Oportunidad = value
            End Set
        End Property
        Private m_Oportunidad As [Boolean]


        Public Property Amueblado() As [Boolean]
            Get
                Return m_Amueblado
            End Get
            Set(ByVal value As [Boolean])
                m_Amueblado = value
            End Set
        End Property
        Private m_Amueblado As [Boolean]


        Public Property Balcon() As [Boolean]
            Get
                Return m_Balcon
            End Get
            Set(ByVal value As [Boolean])
                m_Balcon = value
            End Set
        End Property
        Private m_Balcon As [Boolean]


        Public Property MBalcon() As Int32
            Get
                Return m_MBalcon
            End Get
            Set(ByVal value As Int32)
                m_MBalcon = value
            End Set
        End Property
        Private m_MBalcon As Int32


        Public Property MBalcon2() As Int32
            Get
                Return m_MBalcon2
            End Get
            Set(ByVal value As Int32)
                m_MBalcon2 = value
            End Set
        End Property
        Private m_MBalcon2 As Int32


        Public Property Patio() As [Boolean]
            Get
                Return m_Patio
            End Get
            Set(ByVal value As [Boolean])
                m_Patio = value
            End Set
        End Property
        Private m_Patio As [Boolean]


        Public Property MPatio() As Int32
            Get
                Return m_MPatio
            End Get
            Set(ByVal value As Int32)
                m_MPatio = value
            End Set
        End Property
        Private m_MPatio As Int32


        Public Property MPatio2() As Int32
            Get
                Return m_MPatio2
            End Get
            Set(ByVal value As Int32)
                m_MPatio2 = value
            End Set
        End Property
        Private m_MPatio2 As Int32


        Public Property Terraza() As [Boolean]
            Get
                Return m_Terraza
            End Get
            Set(ByVal value As [Boolean])
                m_Terraza = value
            End Set
        End Property
        Private m_Terraza As [Boolean]


        Public Property MTerraza() As Int32
            Get
                Return m_MTerraza
            End Get
            Set(ByVal value As Int32)
                m_MTerraza = value
            End Set
        End Property
        Private m_MTerraza As Int32


        Public Property MTerraza2() As Int32
            Get
                Return m_MTerraza2
            End Get
            Set(ByVal value As Int32)
                m_MTerraza2 = value
            End Set
        End Property
        Private m_MTerraza2 As Int32


        Public Property Jardin() As [Boolean]
            Get
                Return m_Jardin
            End Get
            Set(ByVal value As [Boolean])
                m_Jardin = value
            End Set
        End Property
        Private m_Jardin As [Boolean]


        Public Property MJardin() As Int32
            Get
                Return m_MJardin
            End Get
            Set(ByVal value As Int32)
                m_MJardin = value
            End Set
        End Property
        Private m_MJardin As Int32


        Public Property Trastero() As Boolean?
            Get
                Return m_Trastero
            End Get
            Set(ByVal value As Boolean?)
                m_Trastero = value
            End Set
        End Property
        Private m_Trastero As Boolean?


        Public Property MTrastero() As Int32
            Get
                Return m_MTrastero
            End Get
            Set(ByVal value As Int32)
                m_MTrastero = value
            End Set
        End Property
        Private m_MTrastero As Int32


        Public Property PrecioTrastero() As Int32
            Get
                Return m_PrecioTrastero
            End Get
            Set(ByVal value As Int32)
                m_PrecioTrastero = value
            End Set
        End Property
        Private m_PrecioTrastero As Int32


        Public Property Garaje() As [Boolean]
            Get
                Return m_Garaje
            End Get
            Set(ByVal value As [Boolean])
                m_Garaje = value
            End Set
        End Property
        Private m_Garaje As [Boolean]

        Public Property MPlaya() As Int32
            Get
                Return m_MPlaya
            End Get
            Set(ByVal value As Int32)
                m_MPlaya = value
            End Set
        End Property
        Private m_MPlaya As Int32

        Public Property MGaraje() As Int32
            Get
                Return m_MGaraje
            End Get
            Set(ByVal value As Int32)
                m_MGaraje = value
            End Set
        End Property
        Private m_MGaraje As Int32


        Public Property PrecioGaraje() As Int32
            Get
                Return m_PrecioGaraje
            End Get
            Set(ByVal value As Int32)
                m_PrecioGaraje = value
            End Set
        End Property
        Private m_PrecioGaraje As Int32



        Public Property CalificacionEnergetica() As [String]
            Get
                Return m_CalificacionEnergetica
            End Get
            Set(ByVal value As [String])
                m_CalificacionEnergetica = value
            End Set
        End Property
        Private m_CalificacionEnergetica As [String]



        Public Property CambioPrecio() As [String]
            Get
                Return m_CambioPrecio
            End Get
            Set(ByVal value As [String])
                m_CambioPrecio = value
            End Set
        End Property
        Private m_CambioPrecio As [String]

        Public Property FechaCambioPrecio() As System.Nullable(Of DateTime)
            Get
                Return m_FechaCambioPrecio
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                m_FechaCambioPrecio = value
            End Set
        End Property
        Private m_FechaCambioPrecio As System.Nullable(Of DateTime)

        Public Property FechaUltimoCambio() As System.Nullable(Of DateTime)
            Get
                Return m_FechaUltimoCambio
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                m_FechaUltimoCambio = value
            End Set
        End Property
        Private m_FechaUltimoCambio As System.Nullable(Of DateTime)



        Public Property VistasAlMar() As [Boolean]
            Get
                Return m_VistasAlMar
            End Get
            Set(ByVal value As [Boolean])
                m_VistasAlMar = value
            End Set
        End Property
        Private m_VistasAlMar As [Boolean]

        Public Property GarajeCerrado() As [Boolean]
            Get
                Return m_GarajeCerrado
            End Get
            Set(ByVal value As [Boolean])
                m_GarajeCerrado = value
            End Set
        End Property
        Private m_GarajeCerrado As [Boolean]



        Public Property ZonaComercial() As [Boolean]
            Get
                Return m_ZonaComercial
            End Get
            Set(ByVal value As [Boolean])
                m_ZonaComercial = value
            End Set
        End Property
        Private m_ZonaComercial As [Boolean]

        Public Property Reservado() As [Boolean]
            Get
                Return m_Reservado
            End Get
            Set(ByVal value As [Boolean])
                m_Reservado = value
            End Set
        End Property
        Private m_Reservado As [Boolean]

        Public Property FotoPrincipal() As [String]
            Get
                Return m_FotoPrincipal
            End Get
            Set(ByVal value As [String])
                m_FotoPrincipal = value
            End Set
        End Property
        Private m_FotoPrincipal As [String]

    End Class


End Namespace