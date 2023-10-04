
Imports ThoughtWorks.QRCode
Imports ThoughtWorks.QRCode.Codec
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraGrid
Imports System.Net
Imports System.Text
Imports RestSharp
Imports Microsoft.VisualBasic
Imports System.Web
Imports System.IO

Module FuncionesEspecificas



    Public Class clsMemory

        <Runtime.InteropServices.DllImport("KERNEL32.DLL", EntryPoint:="SetProcessWorkingSetSize", SetLastError:=True, CallingConvention:=Runtime.InteropServices.CallingConvention.StdCall)>
        Friend Shared Function SetProcessWorkingSetSize(ByVal pProcess As IntPtr, ByVal dwMinimumWorkingSetSize As Integer, ByVal dwMaximumWorkingSetSize As Integer) As Boolean

        End Function



        <Runtime.InteropServices.DllImport("KERNEL32.DLL", EntryPoint:="GetCurrentProcess", SetLastError:=True, CallingConvention:=Runtime.InteropServices.CallingConvention.StdCall)>
        Friend Shared Function GetCurrentProcess() As IntPtr

        End Function



        Public Sub New()

            Dim pHandle As IntPtr = GetCurrentProcess()

            SetProcessWorkingSetSize(pHandle, -1, -1)

        End Sub

    End Class

    Public Sub LiberarMemoria()

        Dim MemClass As New clsMemory()
        MemClass = Nothing

    End Sub

    Public Function GenerarQR(Texto As String) As Image
        Dim generarCodigoQR As QRCodeEncoder = New QRCodeEncoder
        generarCodigoQR.QRCodeEncodeMode = Codec.QRCodeEncoder.ENCODE_MODE.BYTE
        generarCodigoQR.QRCodeScale = Int32.Parse(4)
        generarCodigoQR.QRCodeErrorCorrect = Codec.QRCodeEncoder.ERROR_CORRECTION.M
        generarCodigoQR.QRCodeVersion = 0
        generarCodigoQR.QRCodeBackgroundColor = Color.White
        generarCodigoQR.QRCodeForegroundColor = Color.Black
        Try
            Return generarCodigoQR.Encode(Texto, System.Text.Encoding.UTF8)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
        Return Nothing
    End Function
    Public Sub CrearPanelFlotanteNueva(ByRef DockManager1 As DevExpress.XtraBars.Docking.DockManager, ByRef PanelObservaciones As DevExpress.XtraBars.Docking.DockPanel, ByRef uc As Object, Ancho As Integer, Alto As Integer, Optional Texto As String = "")

        If Not IsNothing(PanelObservaciones) Then
            Try
                For i = 0 To PanelObservaciones.Controls.Count - 1
                    PanelObservaciones.Controls.Remove(PanelObservaciones.Controls(0))
                Next
            Catch ex As Exception

            End Try
        End If


        'uc = New ucComercialesClientes

        PanelObservaciones = DockManager1.AddPanel(DevExpress.XtraBars.Docking.DockingStyle.Float)

        With uc
            .Parent = PanelObservaciones
            '.Location = New Point(5, 10)

            '   .Size = New Point(PanelObservaciones.Width - 10, PanelObservaciones.Height - 14)
            .Dock = DockStyle.Fill
            '.LookAndFeel.SkinName = "Black"
            '.LookAndFeel.UseDefaultLookAndFeel = False
            '.Font = New Font(dgvxPanel.Font.FontFamily, 12)
            '.Font = New System.Drawing.Font(dgvxPanel.Font.FontFamily, dgvxPanel.Font.Size, dgvxPanel.Font.Style)

        End With


        'PanelObservaciones.Width = 2000

        PanelObservaciones.Text = Texto
        PanelObservaciones.FloatSize = New Size(Ancho, Alto)

        Dim pt As Point = New Point(Screen.PrimaryScreen.WorkingArea.Width - 45 - PanelObservaciones.Width, Screen.PrimaryScreen.WorkingArea.Height / 2)
        ' ''   Dim pt As Point = New Point(dgvx.Location.X + 25, dgvx.Height - 25 - PanelObservaciones.Height)
        PanelObservaciones.MakeFloat(pt)



        '   PanelObservaciones.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible
        ' PanelObservaciones.Visibility = DockVisibility.Hidden
        DockManager1.ActivePanel = PanelObservaciones
        PanelObservaciones = DockManager1.ActivePanel
        PanelObservaciones.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden

    End Sub

    Public Sub CargarFormulario(NombreFormulario As String, Optional RibbonPageNombre As String = "", Optional CerrarFormularioActual As Boolean = False, Optional DeDondeVengo As String = "", Optional Otros As String = "")

        frmPrincipal.PictureBox1.Visible = False

        Try
            If CerrarFormularioActual Then
                Application.OpenForms.Item(NombreFormulario).Dispose()
            Else
                If Not IsNothing(Application.OpenForms.Item(NombreFormulario)) Then
                    Application.OpenForms.Item(NombreFormulario).Activate()
                    Return
                End If

            End If
        Catch ex As Exception

        End Try

        If NombreFormulario = "Alarmas" Then
            Try
                Application.OpenForms.Item("ucAlarmas").Activate()
                Return
            Catch ex As Exception

            End Try
        End If

        If NombreFormulario = "Propietarios" Then
            Try
                Application.OpenForms.Item("ucPropietarios").Activate()
                Return
            Catch ex As Exception

            End Try
        End If



        'For Each frm In frmPrincipal.MdiChildren
        '    If frm.Name = NombreFormulario Then

        '        frm.Activate()
        '        Exit Sub
        '    End If
        'Next

        'Me.Cursor = System.Windows.Forms.Cursors.WaitCursor


        Dim p As New XtraForm1(NombreFormulario, RibbonPageNombre)
        p.Name = NombreFormulario
        p.ControlBox = False

        '  Dim u As Object

        Select Case If(GL_PortalesCreados.Contains(NombreFormulario), "Portales", NombreFormulario)
            'Case "PublicarFacebook"
            '    Dim u As New frmPublicarFacebook
            '    u.datos = Otros
            '    u.ShowDialog()

            Case "Prestamos"

                Dim u As New frmPrestamos
                u.ShowDialog()

                'Case "Inmuebles2"
                '    uInmueblesActivo2 = New ucInmuebles2
                '    uInmueblesActivo2.Dock = DockStyle.Fill
                '    uInmueblesActivo2.DeDondeVengo = DeDondeVengo
                '    If DeDondeVengo = GL_VENGO_DE_CLIENTES Or DeDondeVengo = "Alarmas" Then
                '        uInmueblesActivo2.ContadorClienteDeDondeVengo = CInt(Otros)
                '    End If

                '    p.Controls.Add(uInmueblesActivo2)
                '    p.MdiParent = frmPrincipal
                '    p.Show()



            Case "Agrupaciones"

                Dim u As New ucAgrupaciones
                u.Dock = DockStyle.Fill
                p.Controls.Add(u)
                Dim tamano As New System.Drawing.Size
                tamano.Height = 600
                tamano.Width = 770
                p.Size = tamano
                p.StartPosition = FormStartPosition.CenterScreen
                p.ShowDialog()



            Case "ComoConociste"

                Dim u As New ucComoConociste
                u.Dock = DockStyle.Fill
                p.Controls.Add(u)
                Dim tamano As New System.Drawing.Size
                tamano.Height = 600
                tamano.Width = 770
                p.Size = tamano
                p.StartPosition = FormStartPosition.CenterScreen
                p.ShowDialog()


            Case "Email"

                Dim u As New ucEmailConfiguracion
                u.Dock = DockStyle.Fill
                p.Controls.Add(u)
                Dim tamano As New System.Drawing.Size
                tamano.Height = 400
                tamano.Width = 650
                p.Size = tamano
                p.StartPosition = FormStartPosition.CenterScreen
                p.ShowDialog()


            Case "Orientación"

                Dim u As New ucOrientacion
                u.Dock = DockStyle.Fill
                p.Controls.Add(u)
                Dim tamano As New System.Drawing.Size
                tamano.Height = 600
                tamano.Width = 770
                p.Size = tamano
                p.StartPosition = FormStartPosition.CenterScreen
                p.ShowDialog()



            Case "Población"

                Dim u As New ucPoblacion
                u.Dock = DockStyle.Fill
                p.Controls.Add(u)
                Dim tamano As New System.Drawing.Size
                tamano.Height = 600
                tamano.Width = 770
                p.Size = tamano
                p.StartPosition = FormStartPosition.CenterScreen
                p.ShowDialog()


            Case "Provincias"

                Dim u As New ucProvincias
                u.Dock = DockStyle.Fill
                p.Controls.Add(u)
                Dim tamano As New System.Drawing.Size
                tamano.Height = 600
                tamano.Width = 770
                p.Size = tamano
                p.StartPosition = FormStartPosition.CenterScreen
                p.ShowDialog()


            Case "Tipo"

                Dim u As New ucTipo
                u.Dock = DockStyle.Fill
                p.Controls.Add(u)
                Dim tamano As New System.Drawing.Size
                tamano.Height = 600
                tamano.Width = 920
                p.Size = tamano
                p.StartPosition = FormStartPosition.CenterScreen
                p.ShowDialog()


            Case "Zona"

                Dim u As New ucZona
                u.Dock = DockStyle.Fill
                p.Controls.Add(u)
                Dim tamano As New System.Drawing.Size
                tamano.Height = 600
                tamano.Width = 770
                p.Size = tamano
                p.StartPosition = FormStartPosition.CenterScreen
                p.ShowDialog()



            Case "Estado"

                Dim u As New ucEstado
                u.Dock = DockStyle.Fill
                p.Controls.Add(u)
                Dim tamano As New System.Drawing.Size
                tamano.Height = 600
                tamano.Width = 770
                p.Size = tamano
                p.StartPosition = FormStartPosition.CenterScreen
                p.ShowDialog()

                'Case "MensajesAPP"

                '    frmTodosLosMensajes.MdiParent = frmPrincipal
                '    frmTodosLosMensajes.Show()

            Case "Inmuebles"
                For Each portal In GL_PortalesCreados
                    Try
                        If Not IsNothing(Application.OpenForms.Item(portal)) Then
                            Application.OpenForms.Item(portal).Dispose()
                        End If

                    Catch ex As Exception
                    End Try
                Next
                'Try
                '    Application.OpenForms.Item("YaEncontre").Dispose()
                'Catch ex As Exception
                'End Try
                'Try
                '    Application.OpenForms.Item("FotoCasa").Dispose()
                'Catch ex As Exception
                'End Try
                'Try
                '    Application.OpenForms.Item("Idealista").Dispose()
                'Catch ex As Exception
                'End Try
                'Try
                '    Application.OpenForms.Item("Hogaria").Dispose()
                'Catch ex As Exception
                'End Try
                'Try
                '    Application.OpenForms.Item("TuCasa").Dispose()
                'Catch ex As Exception
                'End Try

                uInmueblesActivo = New ucInmuebles
                uInmueblesActivo.Dock = DockStyle.Fill
                uInmueblesActivo.DeDondeVengo = DeDondeVengo
                If DeDondeVengo = GL_VENGO_DE_CLIENTES Then
                    uInmueblesActivo.ContadorClienteDeDondeVengo = CInt(Otros)
                End If
                If DeDondeVengo = GL_VENGO_DE_PROPIETARIOS Then
                    Dim a() As String = Split(Otros, "|")
                    uInmueblesActivo.ContadorPropietarioDeDondeVengo = CInt(a(0))
                    uInmueblesActivo.NuevoInmueble = CBool(a(1))
                End If
                If DeDondeVengo = "Alarmas" Then
                    Dim a() As String = Split(Otros, "|")
                    uInmueblesActivo.ContadorClienteDeDondeVengo = CInt(a(0))
                    uInmueblesActivo.ContadorPropietarioDeDondeVengo = CInt(a(1))
                End If
                If DeDondeVengo = GL_VENGO_DE_VISITAS Then
                    uInmueblesActivo.ContadorInmuebleAlQueVoy = Otros
                End If
                p.Controls.Add(uInmueblesActivo)
                p.MdiParent = frmPrincipal
                p.Show()

                If DeDondeVengo = GL_VENGO_DE_PROPIETARIOS Then
                    Dim a() As String = Split(Otros, "|")
                    uInmueblesActivo.ContadorPropietarioDeDondeVengo = CInt(a(0))
                    uInmueblesActivo.NuevoInmueble = CBool(a(1))
                    If uInmueblesActivo.NuevoInmueble Then
                        uInmueblesActivo.PonerChecksEnIndeterminado()
                    End If

                End If




            Case "Clientes"
                UClienteActivo = New Venalia.ucClientes
                UClienteActivo.Dock = DockStyle.Fill
                UClienteActivo.DeDondeVengo = DeDondeVengo
                If DeDondeVengo = GL_VENGO_DE_INMUEBLES Then
                    Dim a() As String = Split(Otros, "|")
                    UClienteActivo.ContadorInmuebleDeDondeVengo = CInt(a(0))
                    UClienteActivo.ReferenciaInmuebleDeDondeVengo = a(1)
                ElseIf DeDondeVengo = GL_VENGO_DE_VISITAS Then
                    UClienteActivo.ContadorClienteAlQueVoy = Otros
                End If
                p.Controls.Add(UClienteActivo)
                p.MdiParent = frmPrincipal

                p.Show()

            Case "Empleados"
                If Not Debugger.IsAttached Then
                    If DatosEmpresa.Codigo = 2 AndAlso (GL_CodigoUsuario <> 1 AndAlso GL_Usuario <> "SUPERADMINISTRADOR") Then
                        frmPrincipal.PictureBox1.Visible = True
                        Return
                    End If
                End If


                uEmpleadosActivo = New ucEmpleados
                uEmpleadosActivo.Dock = DockStyle.Fill
                p.Controls.Add(uEmpleadosActivo)
                p.MdiParent = frmPrincipal
                p.Show()

            Case "Propietarios"
                uPropietariosActivo = New ucPropietarios
                '   uPropietariosActivo.Dock = DockStyle.Fill
                uPropietariosActivo.DeDondeVengo = DeDondeVengo
                If DeDondeVengo = GL_VENGO_DE_INMUEBLES Then
                    uPropietariosActivo.ContadorPropietarioDeDondeVengo = CInt(Otros)
                End If
                uPropietariosActivo.Text = "Propietarios"
                uPropietariosActivo.ControlBox = False
                uPropietariosActivo.MdiParent = frmPrincipal
                uPropietariosActivo.Show()

                'p.Controls.Add(uPropietariosActivo)
                'p.MdiParent = frmPrincipal
                'p.Show()

            Case "TextosEnvios"
                uTextosEnviosActivo = New ucTextosEnvios
                uTextosEnviosActivo.Dock = DockStyle.Fill
                p.Controls.Add(uTextosEnviosActivo)
                p.MdiParent = frmPrincipal
                p.Show()

            Case "Alarmas"
                uAlarmasActivo = New ucAlarmas
                uAlarmasActivo.Dock = DockStyle.Fill
                uAlarmasActivo.Text = "Alarmas"
                'p.Controls.Add(uAlarmasActivo)
                'p.MdiParent = frmPrincipal

                'p.Show()


                uAlarmasActivo.ControlBox = False
                uAlarmasActivo.MdiParent = frmPrincipal
                uAlarmasActivo.Show()




                'uAlarmasActivo.Dock = DockStyle.Fill
                'p.Controls.Add(uAlarmasActivo)
                'p.MdiParent = frmPrincipal
                'p.Show()

            Case "Imagenes"
                Dim a() As String = Split(Otros, "|")
                '    uImagenesActivo = New ucImagenes(CInt(a(0)), CInt(a(1)), CInt(a(2)))
                uImagenesActivo.Dock = DockStyle.Fill
                p.Controls.Add(uImagenesActivo)
                p.MdiParent = frmPrincipal
                p.Show()


            Case "Configuracion Empresas"

                frmConfiguracionEmpresa.ShowDialog()


            Case "MensajeEmail"

                Dim u As New ucMensajeEmail()
                u.Dock = DockStyle.Fill
                p.Controls.Add(u)
                u.ClientesPropietarios = GL_Propietarios
                u.CargarDatos()
                Dim tamano As New System.Drawing.Size
                tamano.Height = 355
                tamano.Width = 770
                p.Size = tamano
                p.StartPosition = FormStartPosition.CenterScreen
                p.ShowDialog()



                'Case "UsuariosAPP"

                '    uClientesWebActivo = New ucClientesWeb
                '    uClientesWebActivo.Text = "Clientes APP/Web"
                '    uClientesWebActivo.ControlBox = False
                '    uClientesWebActivo.MdiParent = frmPrincipal
                '    uClientesWebActivo.Show()



            Case "EnvioNovedades"

                p = New XtraForm1("Clientes con novedades")
                p.Name = "EmailMasivoClientes"
                p.ControlBox = False
                ucEmailMasivoClientes.Tabla = "Clientes"
                ucEmailMasivoClientes.ShowDialog()



                'Dim u As New ucEmailMasivoClientes
                'u.Dock = DockStyle.Fill
                'p.Controls.Add(u)
                'Dim tamano As New System.Drawing.Size
                'tamano.Height = 600
                'tamano.Width = 770
                'p.Size = tamano
                'p.StartPosition = FormStartPosition.CenterScreen
                'p.ShowDialog()

            Case "Configuracion"
                uConfiguracionActivo = New ucConfiguracion
                uConfiguracionActivo.Text = "Configuración"
                uConfiguracionActivo.ControlBox = False
                uConfiguracionActivo.MdiParent = frmPrincipal
                uConfiguracionActivo.Show()

            Case "Mantenimientodeportales"
                Dim u As New ucPublicacion
                u.Dock = DockStyle.Fill
                p.Controls.Add(u)
                Dim tamano As New System.Drawing.Size
                tamano.Height = 600
                tamano.Width = 770
                p.Size = tamano
                p.StartPosition = FormStartPosition.CenterScreen
                p.ShowDialog()

            Case "Portales" '"YaEncontre", "FotoCasa", "Idealista", "Hogaria", "TuCasa"
                Try
                    'If Not IsNothing(Application.OpenForms.Item("Inmuebles")) Then
                    '    If DevExpress.XtraEditors.XtraMessageBox.Show("Al abrir este portal se cerrara la ventana de Inmuebles" & vbCrLf & "¿Desea continuar?", "Inmuebles", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Application.OpenForms.Item("Inmuebles").Dispose()
                    '    Else
                    '        Exit Sub
                    '    End If
                    'End If
                Catch ex As Exception
                End Try
                For Each portal In GL_PortalesCreados
                    Try
                        Application.OpenForms.Item(portal).Dispose()
                    Catch ex As Exception
                    End Try
                Next
                'Try
                '    Application.OpenForms.Item("YaEncontre").Dispose()
                'Catch ex As Exception
                'End Try
                'Try
                '    Application.OpenForms.Item("FotoCasa").Dispose()
                'Catch ex As Exception
                'End Try
                'Try
                '    Application.OpenForms.Item("Idealista").Dispose()
                'Catch ex As Exception
                'End Try
                'Try
                '    Application.OpenForms.Item("Hogaria").Dispose()
                'Catch ex As Exception
                'End Try
                'Try
                '    Application.OpenForms.Item("TuCasa").Dispose()
                'Catch ex As Exception
                'End Try
                uInmueblesActivo = New ucInmuebles
                uInmueblesActivo.Dock = DockStyle.Fill
                uInmueblesActivo.DeDondeVengo = "Portal|" & p.Name
                p.Controls.Add(uInmueblesActivo)
                p.MdiParent = frmPrincipal
                p.Show()

            Case "Asignar Tipos", "Asignar Ofertas"
                Dim u As New UcAsignacionTipoPortales(NombreFormulario.Contains("Oferta"))
                u.Dock = DockStyle.Fill
                u.Portal = Otros
                p.Controls.Add(u)
                Dim tamano As New System.Drawing.Size
                tamano.Height = 700
                tamano.Width = 800
                p.Size = tamano
                p.StartPosition = FormStartPosition.CenterScreen
                p.ShowDialog()

            Case "ElegirPoblacionPortal"
                Dim u As New UcElegirPoblacionPortal(Otros.Split("|")(0), Otros.Split("|")(1))
                u.Dock = DockStyle.Fill
                p.Controls.Add(u)
                Dim tamano As New System.Drawing.Size
                tamano.Height = 700
                tamano.Width = 500
                p.Size = tamano
                p.StartPosition = FormStartPosition.CenterScreen
                p.ShowDialog()

        End Select

        'u.Dock = DockStyle.Fill
        'p.Controls.Add(u)



        ' Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub



    Public Function pf_ObtenerDireccionEmpresa(CodigoEmpresa As Integer, IncluirAvisoLegal As Boolean, SoyDeClliente As Boolean, ContadorCliente As Integer) As String

        Dim TextoDatosEmpresa As String = ""
        Dim Sel As String

        Dim dtr As Object
        Dim bdActualizar As New BaseDatos
        Sel = "SELECT * FROM Empresas WHERE Codigo = " & CodigoEmpresa
        dtr = bdActualizar.ExecuteReader(Sel)

        If dtr.HasRows Then
            dtr.Read()


            TextoDatosEmpresa = dtr("Nombre") & vbCrLf & dtr("Direccion") & vbCrLf & dtr("Poblacion") & " - " & dtr("Provincia")


            If dtr("Telefono1") <> "" Then
                TextoDatosEmpresa = TextoDatosEmpresa & vbCrLf & "Teléfono " & dtr("Telefono1")
            End If

            If dtr("Telefono2") <> "" Then
                TextoDatosEmpresa = TextoDatosEmpresa & " - " & dtr("Telefono2") & " (Ventas)"
            End If

            If dtr("TelefonoMovil") <> "" Then
                TextoDatosEmpresa = TextoDatosEmpresa & " - " & dtr("TelefonoMovil") & " (Alquiler)"
            End If

            If dtr("Fax") <> "" Then
                TextoDatosEmpresa = TextoDatosEmpresa & vbCrLf & "Fax " & dtr("Fax")
            End If


            If SoyDeClliente AndAlso DatosEmpresa.WordPress Then
                If GL_ConfiguracionWeb.url_baja <> "" Then
                    Dim EnlaceBaja As String
                    EnlaceBaja = "< a href=""" & GL_ConfiguracionWeb.url_baja & "/?" & ContadorCliente & """>" & "Baja" & "</a>"
                    TextoDatosEmpresa = TextoDatosEmpresa & vbCrLf & vbCrLf & "Has recibido este email porque estás inscrito en nuestra base de datos. Este mensaje se envía con la finalidad de ofrecerte información que consideramos de tu interés. No obstante, si quieres que dejemos de enviarte comunicaciones, solo debes pinchar en el siguiente enlace " & EnlaceBaja & ". Se te abrirá una página de confirmación de baja y dejarás de recibir información."
                End If
            End If


            If IncluirAvisoLegal Then
                If dtr("AvisoLegal") <> "" Then
                    TextoDatosEmpresa = TextoDatosEmpresa & vbCrLf & vbCrLf & vbCrLf & dtr("AvisoLegal")
                End If
            End If



            '  If Not ISNULL("dtr("Fax")) Then
            '    TextoDatosEmpresa = TextoDatosEmpresa & vbCrLf & "Fax " & dtr("Fax")
            '  End If

            '  If TextoDatosEmpresa <> "" Then
            '    TextoDatosEmpresa = vbCrLf & vbCrLf & "Póngase en contacto con nosotros en el " & TextoDatosEmpresa
            '  End If



        End If

        dtr.Close()

        Return TextoDatosEmpresa



    End Function

    Public Function pf_ObtenerAvisoLegal(CodigoEmpresa As Integer) As String

        Dim TextoDatosEmpresa As String = ""
        Dim Sel As String
        Sel = "SELECT AvisoLegal FROM Empresas WHERE Codigo = " & CodigoEmpresa
        TextoDatosEmpresa = vbCrLf & vbCrLf & vbCrLf & BD_CERO.Execute(Sel, False, "")

        Return TextoDatosEmpresa



    End Function
    Public Function ProcesoAnadirObservaciones2(Observaciones As Tablas.clComunicaciones) As Integer


        GL_Observaciones = ""
        GL_RespondioALaLlamada = True

        GL_PANTALLA_QUE_LANZA_LLAMADA = Observaciones.QuienMeLlama
        Select Case Observaciones.Tipo
            Case GL_OBSERVACIONES_LLAMADA
                frmObservacionesLlamada.ShowDialog()
                If GL_Observaciones = GL_ResultadoBusqueda_CANCELAR Then Return -1
                Observaciones.LlamadaContestada = GL_RespondioALaLlamada
            Case GL_OBSERVACIONES_MANUAL, GL_OBSERVACIONES_INFORMADO
                Dim f As New frmObservaciones
                f.Tipo = Observaciones.Tipo
                If Observaciones.Tabla = GL_TablaPropietarios Then
                    Dim Sel As String
                    Sel = "SELECT Observaciones FROM Propietarios WHERE Contador = " & Observaciones.ContadorClientePropietarioInmueble

                    f.txtTexto.Text = BD_CERO.Execute(Sel, False, "")


                End If
                f.ShowDialog()
                Observaciones.LlamadaContestada = False
            Case GL_MODIFICAR_OBSERVACIONES_LLAMADA

                Dim Obser As String = ""
                Try

                    Dim Vista As String

                    If Observaciones.Tabla = GL_TablaPropietarios Then
                        Vista = "PropietariosComunicaciones"
                    Else
                        Vista = "ClientesComunicaciones"
                    End If

                    Obser = BD_CERO.Execute("SELECT Observaciones  FROM  " & Vista & " WHERE Contador = " & Observaciones.ContadorLlamada, False)
                Catch ex As Exception

                End Try
                frmObservaciones.txtTexto.Text = Obser
                frmObservaciones.ShowDialog()
                Observaciones.LlamadaContestada = False



        End Select

        If Not GL_ObservacionesCambioPrecio = "" Then
            If GL_Observaciones = Gl_ResultadoBusqueda_SALIR Then
                GL_Observaciones = ""
            End If
            GL_Observaciones &= " " & GL_ObservacionesCambioPrecio
            GL_ObservacionesCambioPrecio = ""
        End If

        If (Observaciones.Tipo = GL_MODIFICAR_OBSERVACIONES_LLAMADA And (GL_Observaciones <> Gl_ResultadoBusqueda_SALIR)) Or (Observaciones.Tipo = GL_OBSERVACIONES_MANUAL And (GL_Observaciones <> Gl_ResultadoBusqueda_SALIR)) Or (Observaciones.Tipo = GL_OBSERVACIONES_INFORMADO And (GL_Observaciones <> Gl_ResultadoBusqueda_SALIR)) Or (Observaciones.Tipo = GL_OBSERVACIONES_LLAMADA And (GL_Observaciones <> Gl_ResultadoBusqueda_SALIR Or Not GL_RespondioALaLlamada)) Or (Observaciones.Tipo = GL_OBSERVACIONES_LLAMADA And GL_Observaciones = Gl_ResultadoBusqueda_SALIR And GL_RespondioALaLlamada) Then

            If GL_Observaciones = Gl_ResultadoBusqueda_SALIR Then
                GL_Observaciones = ""
            End If

            Observaciones.Observaciones = GL_Observaciones

            If Observaciones.Tipo = GL_MODIFICAR_OBSERVACIONES_LLAMADA AndAlso Observaciones.Observaciones <> "" Then

                Dim Vista As String

                If Observaciones.Tabla = GL_TablaPropietarios Then
                    Vista = "PropietariosComunicaciones"
                Else
                    Vista = "ClientesComunicaciones"
                End If
                BD_CERO.Execute("UPDATE " & Vista & " SET  Observaciones = '" & Funciones.pf_ReplaceComillas(Observaciones.Observaciones) & "' WHERE Contador = " & Observaciones.ContadorLlamada, False)



            Else
                '    ConsultasBaseDatos.InsertarComunicaciones(
                ConsultasBaseDatos.InsertarComunicacionesObservaciones(Observaciones)
            End If

        End If


    End Function
    'Public Function ProcesoAnadirObservaciones(LLamada As Boolean, Tabla As String, ContadorClientePropietarioInmueble As Integer) As Integer

    '    Dim TipoDeObservacion As String
    '    GL_Observaciones = ""
    '    GL_RespondioALaLlamada = True
    '    Dim ContadorLlamada As Integer = 0


    '    If LLamada Then
    '        frmObservacionesLlamada.ShowDialog()
    '        TipoDeObservacion = GL_OBSERVACIONES_LLAMADA
    '    Else
    '        frmObservaciones.ShowDialog()
    '        TipoDeObservacion = GL_OBSERVACIONES_MANUAL
    '    End If

    '    If Not GL_ObservacionesCambioPrecio = "" Then
    '        If GL_Observaciones = Gl_ResultadoBusqueda_SALIR Then
    '            GL_Observaciones = ""
    '        End If
    '        GL_Observaciones &= " " & GL_ObservacionesCambioPrecio
    '        GL_ObservacionesCambioPrecio = ""
    '    End If

    '    If GL_Observaciones <> Gl_ResultadoBusqueda_SALIR Then

    '        Dim Observaciones As New Tablas.clComunicaciones

    '        Observaciones.CodigoEmpresa = DatosEmpresa.Codigo
    '        Observaciones.ContadorClientePropietarioInmueble = ContadorClientePropietarioInmueble
    '        Observaciones.ContadorEmpleado = GL_CodigoUsuario
    '        Observaciones.Delegacion = Gl_Delegacion
    '        Observaciones.Observaciones = GL_Observaciones
    '        Observaciones.Tipo = TipoDeObservacion
    '        Observaciones.ContadorLlamada = ContadorLlamada

    '        ConsultasBaseDatos.InsertarComunicacionesObservaciones(Observaciones)

    '    End If

    '    'Esta función devuelve un número que indica, que en caso de que sea observaciones por llamada, si contesta o no
    '    'Este valor solo lo utilizaré fuera si he llamado a esta función por que quiero añadir una observación de llamada.

    '    If LLamada Then
    '        If GL_RespondioALaLlamada Then
    '            Return 1
    '        Else
    '            Return 0
    '        End If
    '    Else
    '        Return -1
    '    End If

    'End Function

    'Public Sub LlenarObservaciones(txtObservaciones As DevExpress.XtraEditors.MemoEdit, Contador As Integer, Tabla As String, Optional Filtro As String = "")
    '    txtObservaciones.Text = ""
    '    Dim dt As DataTable
    '    dt = ConsultasBaseDatos.ObtenerObservaciones(Contador, Tabla)

    '    If dt IsNot Nothing Then
    '        Dim Observaciones As String = ""
    '        Dim TextoObservacion As String
    '        For Each dr In dt.Rows
    '            If dr("Llamada") = Filtro Then 'Si no es una observacion de llamada
    '                TextoObservacion = dr("Fecha") & IIf(dr("Llamada") <> "", "-LL", "") & "-" & dr("Observacion")
    '                If Observaciones = "" Then
    '                    Observaciones = TextoObservacion
    '                Else
    '                    Observaciones = Observaciones & vbCrLf & TextoObservacion
    '                End If
    '            End If
    '        Next
    '        txtObservaciones.Text = Observaciones
    '    End If
    'End Sub
    Public Function EnviosEmailIndividual(Email As String, Nombre As String, AsuntoYMensaje As Tablas.cl_AsuntoYMensaje, Optional NombreFichero As String = "", Optional Html As Boolean = False) As String

        Dim MailAdressesDestino As New System.Net.Mail.MailAddressCollection

        Dim Emails As String() = Split(Email, ";")

        For i = 0 To Emails.Length - 1
            If Emails(i) <> "" Then
                MailAdressesDestino.Add(New System.Net.Mail.MailAddress(Emails(i), Nombre))
            End If
        Next




        Dim ResultadoEnvio As String = Funciones.EnviarCorreo(Email, AsuntoYMensaje.Asunto, AsuntoYMensaje.Mensaje, False, NombreFichero, , , , MailAdressesDestino, Html)

        Return ResultadoEnvio
    End Function
    Public Function EnviosEmailIndividualClientes(Tipo As String, ContadorCliente As Integer, CodigoEmpresa As Integer, Email As String, Nombre As String, AsuntoYMensaje As Tablas.cl_AsuntoYMensaje, Tabla As String, SoloNovedades As Boolean, Optional VerTambienReservados As Boolean = False) As String


        Dim Sel As String = ""


        'Si no pasamos el email, es pq no lo tenemos, hay que buscarlo y validarlo
        If Email = "" Then

            Dim NoQuiereRecibirEmails As Boolean

            Dim dtr As Object
            Dim bdPobs As New BaseDatos()
            Sel = "SELECT Nombre, Email,NoQuiereRecibirEmails FROM " & Tabla & " WHERE Contador = " & ContadorCliente
            Dim Elementos As String = ""
            dtr = bdPobs.ExecuteReader(Sel)
            If dtr.HasRows Then
                While dtr.Read
                    Nombre = dtr("Nombre")
                    Email = dtr("Email")
                    NoQuiereRecibirEmails = dtr("NoQuiereRecibirEmails")
                End While
            End If
            dtr.Close()

            If Trim(Email) = "" Then
                Return ("El cliente seleccionado no tiene direccion de e-mail")

            End If

            If NoQuiereRecibirEmails Then
                Return ("El cliente seleccionado NO quiere recibir Emails")

            End If

            If Not FuncionesGenerales.Funciones.validar_Mail(Email) Then
                Return ("La dirección de e-mail no es correcta")

            End If
        End If



        If AsuntoYMensaje Is Nothing Then
            AsuntoYMensaje = ConsultasBaseDatos.ObtenerAsuntoYCuerpoEmail(Tipo, CodigoEmpresa, , , ContadorCliente)
            If AsuntoYMensaje Is Nothing Then
                Return ("No se encontró información de asunto y mensaje para el envío de emails listado")

            End If
        End If

        Dim NombreFichero As String = ""

        Dim TextoFinal As String = ""

        Select Case Tipo
            Case GL_EMAIL_LISTADO_CLIENTES, GL_EMAIL_LISTADO_NOVEDADES
                If DatosEmpresa.WordPress Then
                    TextoFinal = PrepararListadoCuerpoEmail(ContadorCliente, SoloNovedades, VerTambienReservados)
                Else
                    If GL_ConfiguracionWeb.web3B OrElse DatosEmpresa.WordPress Then
                        TextoFinal = PrepararEmailListadoWeb(ContadorCliente, AsuntoYMensaje.Titulo, SoloNovedades)
                    Else
                        TextoFinal = PrepararListadoCuerpoEmail(ContadorCliente, SoloNovedades, VerTambienReservados)
                    End If

                End If

                ' NombreFichero = PrepararFicheroListado(ContadorCliente, AsuntoYMensaje.Titulo, ParaAltasCambiosPreciosReservasQuitadas)
        End Select

        Select Case Tipo
            Case GL_EMAIL_LISTADO_CLIENTES, GL_EMAIL_LISTADO_NOVEDADES
                If TextoFinal = "" Then 'No tiene emails, así que no envíe nada
                    Return "No se envió email porque no hay inmnuebles que enviar"
                End If
        End Select



        Dim MailAdressesDestino As New System.Net.Mail.MailAddressCollection
        MailAdressesDestino.Add(New System.Net.Mail.MailAddress(Email, Nombre))
        Dim ResultadoEnvio As String = Funciones.EnviarCorreo(Email, AsuntoYMensaje.Asunto, AsuntoYMensaje.Mensaje & vbCrLf & TextoFinal & vbCrLf & pf_ObtenerDireccionEmpresa(CodigoEmpresa, True, True, ContadorCliente), False, NombreFichero, , , , MailAdressesDestino, True)
        ' Dim ResultadoEnvio As String = Funciones.EnviarCorreo(Email, AsuntoYMensaje.Asunto, AsuntoYMensaje.Mensaje & vbCrLf & TextoFinal, False, NombreFichero, , , , MailAdressesDestino, True)



        Return ResultadoEnvio



    End Function

    Public Function PrepararEmailListadoWeb(ContadorCliente As Integer, Titulo As String, SoloNovedades As Boolean) As String


        Dim bdBD As New BaseDatos
        Dim Resultado As String = ""
        Dim sel As String = ""

        Dim dtr As Object
        dtr = bdBD.ExecuteReader("SELECT * FROM Clientes WHERE Contador =" & ContadorCliente)
        If dtr.hasrows Then
            dtr.read()

            Resultado &= "TIPOVENTA|" & dtr("TipoVenta")



            Dim SelCaracteristicas As String = ""

            If Funciones.DTR_es_True(dtr("Piscina")) Then
                SelCaracteristicas &= "|PISCINA"
            End If

            If Funciones.DTR_es_True(dtr("Ascensor")) Then
                SelCaracteristicas &= "|ASCENSOR"
            End If

            If Funciones.DTR_es_True(dtr("Terraza")) Then
                SelCaracteristicas &= "|TERRAZA"
            End If

            If Funciones.DTR_es_True(dtr("Garaje")) Then
                SelCaracteristicas &= "|GARAJE"
            End If

            If Funciones.DTR_es_False(dtr("CocinaOffice")) Then
                SelCaracteristicas &= "|COCINA INDEPENDIENTE"
            End If

            If Funciones.DTR_es_True(dtr("Balcon")) Or Funciones.DTR_es_True(dtr("Patio")) Then
                SelCaracteristicas &= "|BALCÓN/PATIO"
            End If

            If SelCaracteristicas <> "" Then
                SelCaracteristicas = "*CARACTERISTICAS" & SelCaracteristicas
            End If

            Resultado &= SelCaracteristicas


            Dim SelPrecio As String = ""

            Dim P1 As Integer
            Dim P2 As Integer
            Dim P3 As Integer
            Dim P4 As Integer
            Dim P5 As Integer
            Dim P6 As Integer
            Dim P7 As Integer
            Dim P8 As Integer
            Dim P9 As Integer
            Dim Precio As Integer = 0

            Select Case dtr("TipoVenta").ToString.ToUpper

                Case GL_Palabra_Alquiler

                    P1 = 150
                    P2 = 300
                    P3 = 450
                    P4 = 600
                    P5 = 750
                    P6 = 900
                    P7 = 1050
                    P8 = 1200
                    P9 = 99999999

                Case Else

                    P1 = 100000
                    P2 = 200000
                    P3 = 300000
                    P4 = 400000
                    P5 = 500000
                    P6 = 600000
                    P7 = 700000
                    P8 = 99999999
                    P9 = 99999999


            End Select

            Select Case dtr("PrecioH")

                Case Is <= P1
                    Precio = P1

                Case Is <= P2
                    Precio = P2

                Case Is <= P3
                    Precio = P3

                Case Is <= P4
                    Precio = P4

                Case Is <= P5
                    Precio = P5

                Case Is <= P6
                    Precio = P6

                Case Is <= P7
                    Precio = P7

                Case Is <= P8
                    Precio = P8

                Case Else
                    Precio = P9



            End Select


            If Precio <> 0 Then
                SelPrecio = "*PRECIO|" & Precio.ToString
                Resultado &= SelPrecio
            End If



            P1 = 1
            P2 = 2
            P3 = 3
            P4 = 4
            P5 = 5
            P6 = 0


            Select Case dtr("HabitacionesD")

                Case Is >= P5
                    Precio = P5

                Case Is >= P4
                    Precio = P4

                Case Is >= P3
                    Precio = P3

                Case Is >= P2
                    Precio = P2

                Case Is >= P1
                    Precio = P1

                Case Else
                    Precio = P6


            End Select


            If Precio <> 0 Then
                SelPrecio = "*HABITACIONES|" & Precio.ToString
                Resultado &= SelPrecio
            End If


            P1 = 0
            P2 = 60
            P3 = 80
            P4 = 100
            P5 = 150
            'P5 = 500
            'P6 = 1000
            'P7 = 1500
            'P8 = 2000

            Select Case dtr("MetrosD")



                Case Is >= P5
                    Precio = P5

                Case Is >= P4
                    Precio = P4

                Case Is >= P3
                    Precio = P3

                Case Is >= P2
                    Precio = P2


                Case Else
                    Precio = P1


            End Select

            If Precio <> 0 Then
                SelPrecio = "*SUPERFICIE|" & Precio.ToString
                Resultado &= SelPrecio
            End If




            P1 = 1
            P2 = 2
            P3 = 3
            P4 = 4
            P5 = 5
            P6 = 0



            Select Case dtr("Banos")



                Case Is >= P5
                    Precio = P5

                Case Is >= P4
                    Precio = P4

                Case Is >= P3
                    Precio = P3

                Case Is >= P2
                    Precio = P2

                Case Is >= P1
                    Precio = P1

                Case Else
                    Precio = P6


            End Select

            If Precio <> 0 Then
                SelPrecio = "*BANOS|" & Precio.ToString
                Resultado &= SelPrecio
            End If


        End If
        dtr.close()


        Dim SelPoblacion As String = ""

        sel = "SELECT Poblacion FROM ClientesPoblacion WHERE ContadorCliente  = " & ContadorCliente
        dtr = bdBD.ExecuteReader(sel)
        If dtr.hasrows Then
            While dtr.read
                SelPoblacion = SelPoblacion & "|" & dtr("Poblacion")
            End While
            SelPoblacion = "*POBLACION" & SelPoblacion
            Resultado &= SelPoblacion
        End If
        dtr.CLOSE()


        Dim SelEstado As String = ""

        sel = "SELECT Estado FROM ClientesEstado WHERE ContadorCliente  = " & ContadorCliente
        dtr = bdBD.ExecuteReader(sel)
        If dtr.hasrows Then
            While dtr.read
                SelEstado = SelEstado & "|" & dtr("Estado")
            End While
            SelEstado = "*ESTADO" & SelEstado
            Resultado &= SelEstado
        End If
        dtr.CLOSE()

        Dim SelZona As String = ""
        sel = "SELECT Zona FROM ClientesZona WHERE ContadorCliente  = " & ContadorCliente
        dtr = bdBD.ExecuteReader(sel)
        If dtr.hasrows Then
            While dtr.read
                SelZona = SelZona & "|" & dtr("Zona")
            End While
            SelZona = "*ZONA" & SelZona
            Resultado &= SelZona
        End If
        dtr.CLOSE()

        Dim SelTipo As String = ""

        sel = "SELECT Tipo FROM ClientesTipo WHERE ContadorCliente  = " & ContadorCliente
        dtr = bdBD.ExecuteReader(sel)
        If dtr.hasrows Then
            While dtr.read
                SelTipo = SelTipo & "|" & dtr("Tipo")
            End While
            SelTipo = "*TIPO" & SelTipo
            Resultado &= SelTipo
        End If
        dtr.CLOSE()


        If SoloNovedades Then
            Dim strFechaUltimoEnvio As String = BD_CERO.Execute("SELECT FechaEmailListado FROM Clientes WHERE Contador = " & ContadorCliente, False, "", False)
            If strFechaUltimoEnvio <> "" Then
                Dim SelPrecio As String = "*FECHAULTIMOENVIO|" & Microsoft.VisualBasic.Format(CDate(strFechaUltimoEnvio), "dd/MM/yyyy HH:mm:ss")
                Resultado &= SelPrecio
            End If

        End If



        Resultado = Replace(Resultado, " ", "+")


        If DatosEmpresa.WordPress Then
            Resultado = Replace(Resultado, "TIPOVENTA|", "&status=",,, CompareMethod.Text)
            Resultado = Replace(Resultado, "*PRECIO|", "&max-price=",,, CompareMethod.Text)
            Resultado = Replace(Resultado, "*HABITACIONES|", "&bedrooms=",,, CompareMethod.Text)
            Resultado = Replace(Resultado, "*SUPERFICIE|", "&min-area=",,, CompareMethod.Text)
            Resultado = Replace(Resultado, "*BANOS|", "&bathrooms=",,, CompareMethod.Text)
            Resultado = Replace(Resultado, "*POBLACION|", "&location=",,, CompareMethod.Text)
            Resultado = Replace(Resultado, "*ESTADO|", "&inspiry_estado=",,, CompareMethod.Text)
            Resultado = Replace(Resultado, "*TIPO|", "&type=",,, CompareMethod.Text)
            Resultado = Replace(Resultado, "*ZONA|", "&location=",,, CompareMethod.Text)

            Dim Palabra As String

            Palabra = "ascensor"
            Resultado = Replace(Resultado, Palabra.ToUpper & "|", "&features%5B%5D=" & Palabra.ToLower,,, CompareMethod.Text)

            Palabra = "Piscina"
            Resultado = Replace(Resultado, Palabra.ToUpper & "|", "&features%5B%5D=" & Palabra.ToLower,,, CompareMethod.Text)

            Palabra = "Terraza"
            Resultado = Replace(Resultado, Palabra.ToUpper & "|", "&features%5B%5D=" & Palabra.ToLower,,, CompareMethod.Text)

            Palabra = "Garaje"
            Resultado = Replace(Resultado, Palabra.ToUpper & "|", "&features%5B%5D=" & Palabra.ToLower,,, CompareMethod.Text)

            Resultado = Replace(Resultado, "COCINA INDEPENDIENTE|", "&features%5B%5D=COCINA-INDEPENDIENTE",,, CompareMethod.Text)

            Resultado = Replace(Resultado, "BALCÓN/PATIO|", "&features%5B%5D=BALCON-PATIO",,, CompareMethod.Text)


            'Resultado = Replace(Resultado, "?&", "&",,, CompareMethod.Text)
            Resultado = Resultado.Substring(1)


            Resultado = Replace(Resultado, "+", "_")
            Resultado = Replace(Resultado, "/", "%2F")

            Resultado = Resultado.ToLower
        End If

        Dim UrlRecortada As String

        If DatosEmpresa.WordPress Then
            Resultado = GL_ConfiguracionWeb.WebConHHTP & "/property-search/?" & Resultado
            Resultado = Replace(Resultado, "HTTP://HTTPS://", "HTTPS://",,, CompareMethod.Text)
            UrlRecortada = Resultado
        Else
            Resultado = GL_ConfiguracionWeb.PaginaBusqueda & "?CON=" & Resultado


            Resultado = Resultado.ToUpper

            'Resultado = Replace(Resultado, "Á", "AAA")
            'Resultado = Replace(Resultado, "É", "EEE")
            'Resultado = Replace(Resultado, "Í", "III")
            'Resultado = Replace(Resultado, "Ó", "OOO")
            'Resultado = Replace(Resultado, "Ú", "UUU")


            Resultado = System.Web.HttpUtility.HtmlEncode(Resultado)

            Resultado = Replace(Resultado, "&", "***")
            Resultado = Replace(Resultado, "#", "---")


            '   Resultado = System.Web.HttpUtility.HtmlDecode(Resultado)




            Try
                UrlRecortada = GoogleUrlShortnerApi.Shorten(Resultado)
            Catch ex As Exception
                UrlRecortada = Resultado
            End Try

        End If




        If SoloNovedades Then
            UrlRecortada = "<a href=""" & UrlRecortada & """>" & "Lista de novedades" & "</a>"
        Else
            UrlRecortada = "<a href=""" & UrlRecortada & """>" & "Lista de inmuebles" & "</a>"
        End If


        bdBD.CerrarBD()
        Return UrlRecortada



    End Function
    'Public Function PrepararEmailListadoWeb(ContadorCliente As Integer, Titulo As String, SoloNovedades As Boolean) As String


    '    Dim bdBD As New BaseDatos
    '    Dim Resultado As String = ""
    '    Dim sel As String = ""

    '    Dim dtr As Object
    '    dtr = bdBD.ExecuteReader("SELECT * FROM Clientes WHERE Contador =" & ContadorCliente)
    '    If dtr.hasrows Then
    '        dtr.read()

    '        Resultado &= "TIPOVENTA|" & dtr("TipoVenta")



    '        Dim SelCaracteristicas As String = ""

    '        If Funciones.DTR_es_True(dtr("Piscina")) Then
    '            SelCaracteristicas &= "|PISCINA"
    '        End If

    '        If Funciones.DTR_es_True(dtr("Ascensor")) Then
    '            SelCaracteristicas &= "|ASCENSOR"
    '        End If

    '        If Funciones.DTR_es_True(dtr("Terraza")) Then
    '            SelCaracteristicas &= "|TERRAZA"
    '        End If

    '        If Funciones.DTR_es_True(dtr("Garaje")) Then
    '            SelCaracteristicas &= "|GARAJE"
    '        End If

    '        If Funciones.DTR_es_False(dtr("CocinaOffice")) Then
    '            SelCaracteristicas &= "|COCINA INDEPENDIENTE"
    '        End If

    '        If Funciones.DTR_es_True(dtr("Balcon")) Or Funciones.DTR_es_True(dtr("Patio")) Then
    '            SelCaracteristicas &= "|BALCÓN/PATIO"
    '        End If

    '        If SelCaracteristicas <> "" Then
    '            SelCaracteristicas = "*CARACTERISTICAS" & SelCaracteristicas
    '        End If

    '        Resultado &= SelCaracteristicas


    '        Dim SelPrecio As String = ""

    '        Dim P1 As Integer
    '        Dim P2 As Integer
    '        Dim P3 As Integer
    '        Dim P4 As Integer
    '        Dim P5 As Integer
    '        Dim P6 As Integer
    '        Dim P7 As Integer
    '        Dim P8 As Integer
    '        Dim P9 As Integer
    '        Dim Precio As Integer = 0

    '        Select Case dtr("TipoVenta").ToString.ToUpper

    '            Case GL_Palabra_Alquiler

    '                P1 = 150
    '                P2 = 300
    '                P3 = 450
    '                P4 = 600
    '                P5 = 750
    '                P6 = 900
    '                P7 = 1050
    '                P8 = 1200
    '                P9 = 99999999

    '            Case Else

    '                P1 = 100000
    '                P2 = 200000
    '                P3 = 300000
    '                P4 = 400000
    '                P5 = 500000
    '                P6 = 600000
    '                P7 = 700000
    '                P8 = 99999999
    '                P9 = 99999999


    '        End Select

    '        Select Case dtr("PrecioH")

    '            Case Is <= P1
    '                Precio = P1

    '            Case Is <= P2
    '                Precio = P2

    '            Case Is <= P3
    '                Precio = P3

    '            Case Is <= P4
    '                Precio = P4

    '            Case Is <= P5
    '                Precio = P5

    '            Case Is <= P6
    '                Precio = P6

    '            Case Is <= P7
    '                Precio = P7

    '            Case Is <= P8
    '                Precio = P8

    '            Case Else
    '                Precio = P9



    '        End Select


    '        If Precio <> 0 Then
    '            SelPrecio = "*PRECIO|" & Precio.ToString
    '            Resultado &= SelPrecio
    '        End If



    '        P1 = 1
    '        P2 = 2
    '        P3 = 3
    '        P4 = 4
    '        P5 = 5
    '        P6 = 0


    '        Select Case dtr("HabitacionesD")

    '            Case Is >= P5
    '                Precio = P5

    '            Case Is >= P4
    '                Precio = P4

    '            Case Is >= P3
    '                Precio = P3

    '            Case Is >= P2
    '                Precio = P2

    '            Case Is >= P1
    '                Precio = P1

    '            Case Else
    '                Precio = P6


    '        End Select


    '        If Precio <> 0 Then
    '            SelPrecio = "*HABITACIONES|" & Precio.ToString
    '            Resultado &= SelPrecio
    '        End If


    '        P1 = 0
    '        P2 = 60
    '        P3 = 80
    '        P4 = 100
    '        P5 = 150
    '        'P5 = 500
    '        'P6 = 1000
    '        'P7 = 1500
    '        'P8 = 2000

    '        Select Case dtr("MetrosD")



    '            Case Is >= P5
    '                Precio = P5

    '            Case Is >= P4
    '                Precio = P4

    '            Case Is >= P3
    '                Precio = P3

    '            Case Is >= P2
    '                Precio = P2


    '            Case Else
    '                Precio = P1


    '        End Select

    '        If Precio <> 0 Then
    '            SelPrecio = "*SUPERFICIE|" & Precio.ToString
    '            Resultado &= SelPrecio
    '        End If




    '        P1 = 1
    '        P2 = 2
    '        P3 = 3
    '        P4 = 4
    '        P5 = 5
    '        P6 = 0



    '        Select Case dtr("Banos")



    '            Case Is >= P5
    '                Precio = P5

    '            Case Is >= P4
    '                Precio = P4

    '            Case Is >= P3
    '                Precio = P3

    '            Case Is >= P2
    '                Precio = P2

    '            Case Is >= P1
    '                Precio = P1

    '            Case Else
    '                Precio = P6


    '        End Select

    '        If Precio <> 0 Then
    '            SelPrecio = "*BANOS|" & Precio.ToString
    '            Resultado &= SelPrecio
    '        End If


    '    End If
    '    dtr.close()


    '    Dim SelPoblacion As String = ""

    '    sel = "SELECT Poblacion FROM ClientesPoblacion WHERE ContadorCliente  = " & ContadorCliente
    '    dtr = bdBD.ExecuteReader(sel)
    '    If dtr.hasrows Then
    '        While dtr.read
    '            SelPoblacion = SelPoblacion & "|" & dtr("Poblacion")
    '            Exit While
    '        End While
    '        SelPoblacion = "*POBLACION" & SelPoblacion
    '        Resultado &= SelPoblacion

    '    End If
    '    dtr.CLOSE()


    '    Dim SelEstado As String = ""

    '    sel = "SELECT Estado FROM ClientesEstado WHERE ContadorCliente  = " & ContadorCliente
    '    dtr = bdBD.ExecuteReader(sel)
    '    If dtr.hasrows Then
    '        While dtr.read

    '            Dim ClasificacionWeb As String = ""

    '            sel = "SELECT ClasificacionWeb FROM Estado WHERE Estado = '" & Funciones.pf_ReplaceComillas(dtr("Estado")) & "'"
    '            ClasificacionWeb = BD_CERO.Execute(sel, False, "")


    '            SelEstado = SelEstado & "|" & ClasificacionWeb
    '            Exit While
    '        End While
    '        SelEstado = "*ESTADO" & SelEstado
    '        Resultado &= SelEstado
    '    End If
    '    dtr.CLOSE()

    '    Dim SelZona As String = ""
    '    'sel = "SELECT Zona FROM ClientesZona WHERE ContadorCliente  = " & ContadorCliente
    '    'dtr = bdBD.ExecuteReader(sel)
    '    'If dtr.hasrows Then
    '    '    While dtr.read
    '    '        SelZona = SelZona & "|" & dtr("Zona")
    '    '    End While
    '    '    SelZona = "*ZONA" & SelZona
    '    '    Resultado &= SelZona
    '    'End If
    '    'dtr.CLOSE()

    '    Dim SelTipo As String = ""
    '    Dim ListaTipos As New List(Of String)
    '    sel = "SELECT Tipo FROM ClientesTipo WHERE ContadorCliente  = " & ContadorCliente
    '    dtr = bdBD.ExecuteReader(sel)
    '    If dtr.hasrows Then
    '        While dtr.read

    '            Dim TipoSecundario As String = ""
    '            Dim TipoFinal As String = ""

    '            sel = "SELECT TipoSecundario FROM Tipo WHERE Tipo = '" & Funciones.pf_ReplaceComillas(dtr("Tipo")) & "'"
    '            TipoSecundario = BD_CERO.Execute(sel, False, "")
    '            If TipoSecundario = "" Then
    '                sel = "SELECT TipoPrincipal FROM Tipos WHERE Tipo = '" & Funciones.pf_ReplaceComillas(dtr("Tipo")) & "'"
    '                TipoFinal = BD_CERO.Execute(sel, False, "")
    '            Else
    '                TipoFinal = TipoSecundario
    '            End If

    '            If Not ListaTipos.Contains(TipoFinal) Then

    '                ListaTipos.Add(TipoFinal)
    '                SelTipo = SelTipo & "|" & TipoFinal

    '            End If


    '            Exit While
    '        End While
    '        SelTipo = "*TIPO" & SelTipo
    '        Resultado &= SelTipo
    '    End If
    '    dtr.CLOSE()


    '    If SoloNovedades Then
    '        Dim strFechaUltimoEnvio As String = BD_CERO.Execute("SELECT FechaEmailListado FROM Clientes WHERE Contador = " & ContadorCliente, False, "", False)
    '        If strFechaUltimoEnvio <> "" Then
    '            Dim SelPrecio As String = "*FECHAULTIMOENVIO|" & Microsoft.VisualBasic.Format(CDate(strFechaUltimoEnvio), "dd/MM/yyyy HH:mm:ss")
    '            Resultado &= SelPrecio
    '        End If

    '    End If



    '    Resultado = Replace(Resultado, " ", "+")


    '    If DatosEmpresa.WordPress Then
    '        Resultado = Replace(Resultado, "TIPOVENTA|", "&status=",,, CompareMethod.Text)
    '        Resultado = Replace(Resultado, "*PRECIO|", "&max-price=",,, CompareMethod.Text)
    '        Resultado = Replace(Resultado, "*HABITACIONES|", "&bedrooms=",,, CompareMethod.Text)
    '        Resultado = Replace(Resultado, "*SUPERFICIE|", "&min-area=",,, CompareMethod.Text)
    '        Resultado = Replace(Resultado, "*BANOS|", "&bathrooms=",,, CompareMethod.Text)
    '        Resultado = Replace(Resultado, "*POBLACION|", "&location=",,, CompareMethod.Text)
    '        Resultado = Replace(Resultado, "*ESTADO|", "&inspiry_estado=",,, CompareMethod.Text)
    '        Resultado = Replace(Resultado, "*TIPO|", "&type=",,, CompareMethod.Text)
    '        Resultado = Replace(Resultado, "*ZONA|", "&location=",,, CompareMethod.Text)

    '        Dim Palabra As String

    '        Palabra = "ascensor"
    '        Resultado = Replace(Resultado, "|" & Palabra.ToUpper, "&features%5B%5D=" & Palabra.ToLower,,, CompareMethod.Text)

    '        Palabra = "Piscina"
    '        Resultado = Replace(Resultado, "|" & Palabra.ToUpper, "&features%5B%5D=" & Palabra.ToLower,,, CompareMethod.Text)

    '        Palabra = "Terraza"
    '        Resultado = Replace(Resultado, "|" & Palabra.ToUpper, "&features%5B%5D=" & Palabra.ToLower,,, CompareMethod.Text)

    '        Palabra = "Garaje"
    '        Resultado = Replace(Resultado, "|" & Palabra.ToUpper, "&features%5B%5D=" & Palabra.ToLower,,, CompareMethod.Text)

    '        Resultado = Replace(Resultado, "|COCINA INDEPENDIENTE", "&features%5B%5D=COCINA-INDEPENDIENTE",,, CompareMethod.Text)

    '        Resultado = Replace(Resultado, "|BALCÓN/PATIO", "&features%5B%5D=BALCON-PATIO",,, CompareMethod.Text)

    '        Resultado = Replace(Resultado, "*CARACTERISTICAS", "",,, CompareMethod.Text)


    '        'Resultado = Replace(Resultado, "?&", "&",,, CompareMethod.Text)
    '        Resultado = Resultado.Substring(1)




    '        Resultado = Resultado.ToLower


    '        Resultado = Replace(Resultado, "SemiReformado/Origen", "SemiReformado/Origen",,, CompareMethod.Text)
    '        Resultado = Replace(Resultado, "Nuevo/Seminuevo", "Nuevo/Seminuevo",,, CompareMethod.Text)
    '        Resultado = Replace(Resultado, "Reformado", "Reformado",,, CompareMethod.Text)

    '        Resultado = Replace(Resultado, "+", "_")
    '        Resultado = Replace(Resultado, "/", "%2F")

    '    End If

    '    Dim UrlRecortada As String

    '    If DatosEmpresa.WordPress Then
    '        Resultado = GL_ConfiguracionWeb.WebConHHTP & "/property-search/?" & Resultado
    '        Resultado = Replace(Resultado, "HTTP://HTTPS://", "HTTPS://",,, CompareMethod.Text)
    '        UrlRecortada = Resultado
    '    Else
    '        Resultado = GL_ConfiguracionWeb.PaginaBusqueda & "?CON=" & Resultado


    '        Resultado = Resultado.ToUpper

    '        'Resultado = Replace(Resultado, "Á", "AAA")
    '        'Resultado = Replace(Resultado, "É", "EEE")
    '        'Resultado = Replace(Resultado, "Í", "III")
    '        'Resultado = Replace(Resultado, "Ó", "OOO")
    '        'Resultado = Replace(Resultado, "Ú", "UUU")


    '        Resultado = System.Web.HttpUtility.HtmlEncode(Resultado)

    '        Resultado = Replace(Resultado, "&", "***")
    '        Resultado = Replace(Resultado, "#", "---")


    '        '   Resultado = System.Web.HttpUtility.HtmlDecode(Resultado)




    '        Try
    '            UrlRecortada = GoogleUrlShortnerApi.Shorten(Resultado)
    '        Catch ex As Exception
    '            UrlRecortada = Resultado
    '        End Try

    '    End If




    '    If SoloNovedades Then
    '        UrlRecortada = "<a href=""" & UrlRecortada & """>" & "Lista de novedades" & "</a>"
    '    Else
    '        UrlRecortada = "<a href=""" & UrlRecortada & """>" & "Lista de inmuebles" & "</a>"
    '    End If


    '    bdBD.CerrarBD()
    '    Return UrlRecortada



    'End Function


    Public Function ObtenerDTListadoInmuebles(Sel As String) As DataTable

        Dim DT As DataTable

        Dim bdPrepararFicheroListado As New BaseDatos
        bdPrepararFicheroListado.LlenarDataSet(Sel, "Datos")

        DT = bdPrepararFicheroListado.ds.Tables("Datos")

        Dim col As New DataColumn
        col = New DataColumn
        With col
            .DataType = System.Type.GetType("System.String")
            .ColumnName = "Texto"
            .Caption = "Texto"
        End With
        DT.Columns.Add(col)

        For i = 0 To DT.Rows.Count - 1
            DT.Rows(i)("Texto") = ConsultasBaseDatos.ObtenerDescripcionInmueble2(DT.Rows(i)("Contador"))
        Next

        Return DT

        'System.IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\Listados\Esquemas\")
        ' DT.WriteXmlSchema(My.Application.Info.DirectoryPath & "\Listados\Esquemas\Datos.xsd")
        ' DT.WriteXml(My.Application.Info.DirectoryPath & "\Listados\Esquemas\Datos.xml", XmlWriteMode.WriteSchema)

        '   Dim Oferta As String = BD_CERO.Execute("SELECT TipoVenta FROM Clientes WHERE Contador = " & ContadorCliente, False)

        'Dim r As New rptListadoInmuebles
        'r.lblTitulo.Text = ConsultasBaseDatos.ObtenerAsuntoYCuerpoEmail(GL_EMAIL_LISTADO_CLIENTES, DatosEmpresa.Codigo).Titulo
        ''   r.Oferta = Oferta

        'If PDF Then

        'Else
        '    ShowListado(r, GL_Word, DT)

        'End If


    End Function

    Public Function PrepararListadoCuerpoEmail(ContadorCliente As Integer, SoloNovedades As Boolean, Optional VerTambienReservados As Boolean = False) As String

        Dim DT As DataTable
        Dim Sel As String

        Dim bdPrepararFicheroListado As New BaseDatos

        'Sel = FuncionesBD.ObtenerReferenciasQueCuadran(ContadorCliente, VerTambienReservados, "Referencia,Contador, Poblacion, Oportunidad, ContadorPropietario, FotoPrincipal ,Precio", IIf(SoloNovedades, "Novedades", ""), True) & _
        '     " ORDER BY Poblacion, Precio "

        'cambio jcb 2/8/17  quieren ordenado por precio y poblacion
        Sel = FuncionesBD.ObtenerReferenciasQueCuadran(ContadorCliente, VerTambienReservados, "Referencia,Contador, Poblacion, Oportunidad, ContadorPropietario, FotoPrincipal ,Precio", IIf(SoloNovedades, "Novedades", ""), True) &
             " ORDER BY Precio,Poblacion  "

        'If Funciones.TextoANotePad(Sel) Then
        '    Return ""
        'End If


        DT = ObtenerDTListadoInmuebles(Sel)


        Dim TextoFinal As New System.Text.StringBuilder

        Dim pf As New ProgressForm(DT.Rows.Count, "Preparando Fichero ...")


        For Each dr As DataRow In DT.Rows
            If TextoFinal.ToString = "" Then
                TextoFinal.Append("<table width=""100%""   cellpadding=""20"">")
            End If

            TextoFinal.Append("<tr > <td >    " & dr("Texto").ToString & vbCrLf & "<a href=" & Funciones.EnlaceWeb("", "", dr("Poblacion"), dr("Referencia"), True) & ">Pinche aquí para ver fotos</a></td> </tr>")


            ' TextoFinal.Append("<tr ><td  width=""10%""></td><td ></br> <font face=""Arial Narrow"" size=""6"">  " & dr("Texto").ToString & "</font></td><td  width=""10%""></td></tr>")

            pf.nuevoPaso()
        Next

        pf.Close()
        If TextoFinal.ToString <> "" Then
            TextoFinal.Append("</table>")
        End If

        Return TextoFinal.ToString


    End Function

    Public Function PrepararFicheroListado(ContadorCliente As Integer, SoloNovedades As Boolean, Optional PDF As Boolean = False) As String

        Dim DT As DataTable
        Dim Sel As String

        Dim bdPrepararFicheroListado As New BaseDatos

        'antes en el parametro reservado ponía esto:    IIf(SoloNovedades, False, True)

        Sel = FuncionesBD.ObtenerReferenciasQueCuadran(ContadorCliente, False, "Referencia,Contador, Poblacion, Oportunidad, ContadorPropietario, FotoPrincipal ,Precio", IIf(SoloNovedades, "Novedades", ""), True) &
              " ORDER BY Poblacion, Precio "

        DT = ObtenerDTListadoInmuebles(Sel)


        Dim Report As New rptListadoInmuebles
        Report.lblTitulo.Text = ConsultasBaseDatos.ObtenerAsuntoYCuerpoEmail(IIf(SoloNovedades, GL_EMAIL_LISTADO_NOVEDADES, GL_EMAIL_LISTADO_CLIENTES), DatosEmpresa.Codigo).Titulo



        Report.DataSource = DT
        Report.DataMember = "Datos"


        Dim NombreFichero As String = ""

        If PDF Then
            Dim Directorio As String = My.Application.Info.DirectoryPath & "\EnvioListados\" & DatosEmpresa.Codigo.ToString & "\" & ContadorCliente.ToString
            NombreFichero = Directorio & "\Inmuebles.pdf"
            FuncionesGenerales.Funciones.ComprobarYCrearCarpetas(Directorio)
        Else
            If DT.Rows.Count < 1 Then
                MensajeInformacion("No hay registros.")
            Else
                Report.ShowPreview()
            End If

        End If

        Return NombreFichero

    End Function
    'Public Function PrepararFicheroListado(ContadorCliente As Integer, Titulo As String, ParaAltasCambiosPreciosReservasQuitadas As Boolean, Optional TipoOferta As String = "") As String

    '    Dim NombreFichero As String = ""

    '    Dim Directorio As String = My.Application.Info.DirectoryPath & "\EnvioListados\" & DatosEmpresa.Codigo.ToString & "\" & ContadorCliente.ToString
    '    NombreFichero = Directorio & "\Inmuebles.pdf"
    '    FuncionesGenerales.Funciones.ComprobarYCrearCarpetas(Directorio)

    '    Try
    '        System.IO.File.Delete(NombreFichero)
    '    Catch ex As Exception

    '    End Try

    '    Dim DT As New DataTable

    '    Dim Sel As String

    '    Dim bdPrepararFicheroListado As New BaseDatos



    '    Dim Oferta As String = BD_CERO.Execute("SELECT TipoVenta FROM Clientes WHERE Contador = " & ContadorCliente, False)

    '    If ParaAltasCambiosPreciosReservasQuitadas Then
    '        Sel = "SELECT Contador, I.Referencia,  I.Poblacion, I.Oportunidad, " & _
    '            " I.ContadorPropietario, I.FotoPrincipal,PrecioPropietario  ,Precio FROM Inmuebles I " & _
    '            " WHERE  I.Contador IN (" & FuncionesBD.ObtenerReferenciasQueCuadran(ContadorCliente, , "ReservaCambioAlta") & ") " & _
    '            " ORDER BY Poblacion, Precio "
    '    Else

    '        Sel = "SELECT Contador, I.Referencia,  , I.Poblacion, I.Oportunidad, I.ContadorPropietario, I.FotoPrincipal" & _
    '            " ,PrecioPropietario ,Precio FROM Inmuebles I WHERE  I.Contador IN (" & FuncionesBD.ObtenerReferenciasQueCuadran(ContadorCliente, True) & ")" & _
    '            " ORDER BY Poblacion, Precio"
    '    End If
    '    bdPrepararFicheroListado.LlenarDataSet(Sel, "Datos")


    '    Dim col As New DataColumn
    '    col = New DataColumn
    '    With col
    '        .DataType = System.Type.GetType("System.String")
    '        .ColumnName = "Texto"
    '        .Caption = "Texto"
    '    End With
    '    bdPrepararFicheroListado.ds.Tables("Datos").Columns.Add(col)

    '    For i = 0 To bdPrepararFicheroListado.ds.Tables("Datos").Rows.Count - 1

    '        bdPrepararFicheroListado.ds.Tables("Datos").Rows(i)("Texto") = ConsultasBaseDatos.ObtenerDescripcionInmueble2(bdPrepararFicheroListado.ds.Tables("Datos").Rows(i)("Contador"))

    '    Next


    '    DT = bdPrepararFicheroListado.ds.Tables("Datos")
    '    'System.IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\Listados\Esquemas\")
    '    '   DT.WriteXmlSchema(My.Application.Info.DirectoryPath & "\Listados\Esquemas\Datos.xsd")
    '    ' DT.WriteXml(My.Application.Info.DirectoryPath & "\Listados\Esquemas\Datos.xml", XmlWriteMode.WriteSchema)
    '    Dim Report As New rptListadoInmuebles
    '    Report.lblTitulo.Text = Titulo


    '    Report.Oferta = Oferta
    '    Report.DataSource = DT
    '    Report.DataMember = "Datos"

    '    '  Report.ShowPreview()
    '    'Exit Sub

    '    'Dim inicio As DateTime = DateTime.Now

    '    Try

    '        Report.ExportToPdf(NombreFichero)

    '    Catch ex As Exception
    '        MensajeError(ex.Message & " Fichero: " & NombreFichero)
    '        Return False

    '    End Try



    '    'Dim fin As DateTime = DateTime.Now

    '    'Dim totalMin As String
    '    'Dim total As TimeSpan = New TimeSpan(fin.Ticks - inicio.Ticks)
    '    'totalMin = total.Hours.ToString("00") & ":" & total.Minutes.ToString("00") & ":" & total.Seconds.ToString("00")

    '    '2931 inmuebles
    '    '2 seg sin fotos y sin links
    '    '3 seg sin fotos y con links
    '    '2:15 min con fotos y con links
    '    '3 seg min con fotos y con links con la foto en local

    '    Return NombreFichero
    'End Function
    Public Sub RefrescarDatosDesdeBdInmuebles(SoloFilaSeleccionada As Boolean)


        If Not IsNothing(uInmueblesActivo) Then
            If SoloFilaSeleccionada Then
                uInmueblesActivo.bd.RefrescarDatos() 'uInmueblesActivo.BinSrc.Position)
                Try
                    uInmueblesActivo.UcInmueblesPropietario1.bd.RefrescarDatos(, , uInmueblesActivo.UcInmueblesPropietario1.Gv, uInmueblesActivo.UcInmueblesPropietario1.BinSrc, True)
                Catch ex As Exception

                End Try

            Else
                uInmueblesActivo.bd.RefrescarDatos(, , uInmueblesActivo.Gv, uInmueblesActivo.BinSrc)
                Try
                    uInmueblesActivo.UcInmueblesPropietario1.bd.RefrescarDatos(, , uInmueblesActivo.UcInmueblesPropietario1.Gv, uInmueblesActivo.UcInmueblesPropietario1.BinSrc)
                Catch ex As Exception

                End Try
            End If
        End If

        If Not IsNothing(uPropietariosActivo) Then
            Try
                uPropietariosActivo.bdInm.RefrescarDatos(, , uPropietariosActivo.GvInmuebles, , True)
            Catch ex As Exception

            End Try
        End If


    End Sub

    Public Sub RefrescarDatosDesdeBdPropietarios(SoloFilaSeleccionada As Boolean)

        If Not IsNothing(uPropietariosActivo) Then
            If SoloFilaSeleccionada Then
                uPropietariosActivo.bd.RefrescarDatos(uPropietariosActivo.BinSrc.Position)
            Else
                uPropietariosActivo.bd.RefrescarDatos(, , uPropietariosActivo.Gv, uPropietariosActivo.BinSrc)
            End If
        End If
    End Sub

    Public Sub RefrescarDatosDesdeBdClientes(SoloFilaSeleccionada As Boolean)

        If Not IsNothing(UClienteActivo) Then
            If SoloFilaSeleccionada Then
                UClienteActivo.bd.RefrescarDatos(UClienteActivo.BinSrc.Position)
            Else
                UClienteActivo.bd.RefrescarDatos(, , UClienteActivo.Gv, UClienteActivo.BinSrc)
            End If
        End If
    End Sub

    Public Sub RefrescarDatosDesdeBdAlarmas(SoloFilaSeleccionada As Boolean, Optional VaciarAntes As Boolean = False)

        If Not IsNothing(uAlarmasActivo) Then
            Dim CargandoAntes As Boolean
            CargandoAntes = uAlarmasActivo.Cargando

            uAlarmasActivo.Cargando = True
            If SoloFilaSeleccionada Then
                uAlarmasActivo.bd.RefrescarDatos(uAlarmasActivo.BinSrc.Position)
            Else
                uAlarmasActivo.bd.RefrescarDatos(, , uAlarmasActivo.Gv, uAlarmasActivo.BinSrc, VaciarAntes)
            End If
            uAlarmasActivo.Cargando = CargandoAntes
        End If
    End Sub

    Public Sub PonerPendienteRefrescarPropietarios()
        If Not IsNothing(uPropietariosActivo) Then
            GL_PropietariosPendienteActualizacion = True
        End If
    End Sub

    Public Sub PonerPendienteRefrescarAlarmas()
        If Not IsNothing(uAlarmasActivo) Then
            GL_AlarmasPendienteActualizacion = True
        End If
    End Sub
    Public Function PrepararFicheroFichaInmueble(ContadoInmueble As Integer, TablaInmuebles As String, listaInmuebles As String) As String

        Dim NombreFichero As String = ""

        Dim Directorio As String = My.Application.Info.DirectoryPath & "\EnvioFichaInmueble\" & DatosEmpresa.Codigo.ToString & "\" & ContadoInmueble.ToString
        NombreFichero = Directorio & "\FichaInmueble.pdf"
        FuncionesGenerales.Funciones.ComprobarYCrearCarpetas(Directorio)



        Dim DT As DataTable = ObtenerDT_ParaReportFichaPropietario(TablaInmuebles, listaInmuebles)


        Dim r As New rptFichaPropietario
        r.DataSource = DT
        r.DataMember = "Datos"
        r.ExportToPdf(NombreFichero)




        Return NombreFichero
    End Function
    Public Function ObtenerDT_ParaReportFichaPropietario(TablaAUtilizar As String, listaInmuebles As String) As DataTable

        Dim DT As New DataTable

        Dim Sel As String = "SELECT I.*,P.*, " &
            Funciones.SQL_CASE({"FechaReservado IS NOT NULL AND FechaReservado >= " & Funciones.pf_ReplaceFecha(Today),
                                "FechaReservado IS NULL OR FechaReservado < " & Funciones.pf_ReplaceFecha(Today)},
                               {"'RESERVADO HASTA ' " & GL_SQL_SUMA & " FORMAT(FechaReservado,'dd/MM/yy')", "''"}) & " AS TextoReservado " &
            " FROM " & TablaAUtilizar & " I INNER JOIN Propietarios P ON P.Contador=I.ContadorPropietario" & listaInmuebles &
            " ORDER BY I.Referencia DESC"

        Dim bd As New BaseDatos

        bd.LlenarDataSet(Sel, "Datos")
        DT = bd.ds.Tables("Datos")

        '   DT.WriteXmlSchema(My.Application.Info.DirectoryPath & "\Listados\Esquemas\Ficha.xsd")

        Return DT
    End Function

    'Public Sub CargarConversaciones(NombreFormulario As String, ContadorConsumidor As Integer, NombreConsumidor As String, APPActiva As Boolean, Optional CerrarFormularioActual As Boolean = False)


    '    Try
    '        If CerrarFormularioActual Then
    '            Application.OpenForms.Item(NombreFormulario).Dispose()
    '        Else
    '            Application.OpenForms.Item(NombreFormulario).Activate()
    '            Return
    '        End If
    '    Catch ex As Exception

    '    End Try

    '    'For Each frm In frmPrincipal.MdiChildren
    '    '    If frm.Name = NombreFormulario Then

    '    '        frm.Activate()
    '    '        Exit Sub
    '    '    End If
    '    'Next

    '    'Me.Cursor = System.Windows.Forms.Cursors.WaitCursor


    '    Dim p As New XtraForm1(NombreFormulario)
    '    p.Name = NombreFormulario
    '    p.ControlBox = False

    '    Dim u As New ucConversaciones
    '    u.Dock = DockStyle.Fill
    '    p.Controls.Add(u)
    '    Dim tamano As New System.Drawing.Size
    '    tamano.Height = 600
    '    tamano.Width = 800
    '    p.Size = tamano
    '    p.StartPosition = FormStartPosition.CenterScreen

    '    u.LlenarMensajes(ContadorConsumidor, NombreConsumidor, APPActiva)
    '    u.APPActiva = APPActiva
    '    p.ShowDialog()



    'End Sub

    Public Sub dgvxColores(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim col As New frmColoresGrid
        col.ShowDialog()


    End Sub

    Public Sub MostrarImagenDeFondo()
        If frmPrincipal.MdiChildren.Count = 0 Then
            frmPrincipal.PictureBox1.Visible = True
        End If
    End Sub

    Public Sub PonerColoresInmuebles(ByRef Gv As MyGridView)

        'For i = 0 To Gv.FormatConditions.Count - 1
        '    Gv.FormatConditions.RemoveAt(0)
        'Next

        Gv.FormatConditions.Clear()

        Dim ca(5) As StyleFormatCondition
        'Dim condition1 As StyleFormatCondition

        ca(5) = New DevExpress.XtraGrid.StyleFormatCondition
        ca(5).Appearance.BackColor = GL_ColorBaja
        ca(5).Appearance.Options.UseBackColor = True
        ca(5).Condition = FormatConditionEnum.Expression
        ca(5).Expression = "[Baja] <> 0" '=" & GL_SQL_VALOR_1
        'Gv.FormatConditions.Add(condition1)

        ca(4) = New DevExpress.XtraGrid.StyleFormatCondition
        ca(4).Appearance.BackColor = GL_ColorReservado
        ca(4).Appearance.Options.UseBackColor = True
        ca(4).Condition = FormatConditionEnum.Expression
        ca(4).Expression = "[Reservado] <> 0" ' =" & GL_SQL_VALOR_1
        'Gv.FormatConditions.Add(condition1)

        ca(3) = New DevExpress.XtraGrid.StyleFormatCondition
        ca(3).Appearance.BackColor = GL_ColorMostrarPPrincipalWeb
        ca(3).Appearance.Options.UseBackColor = True
        ca(3).Condition = FormatConditionEnum.Expression
        ca(3).Expression = "[MostrarPPrincipalWeb] <> 0"
        'Gv.FormatConditions.Add(condition1)

        ca(2) = New DevExpress.XtraGrid.StyleFormatCondition
        ca(2).Appearance.BackColor = GL_ColorPendienteWeb
        ca(2).Appearance.Options.UseBackColor = True
        ca(2).Condition = FormatConditionEnum.Expression
        ca(2).Expression = "[PendienteWeb] <> 0"
        'Gv.FormatConditions.Add(condition1)

        ca(1) = New DevExpress.XtraGrid.StyleFormatCondition
        ca(1).Appearance.BackColor = GL_ColorVisitado
        ca(1).Appearance.Options.UseBackColor = True
        ca(1).Condition = FormatConditionEnum.Expression
        ca(1).Expression = "[Visitado] <> 0" '=" & GL_SQL_VALOR_1
        'Gv.FormatConditions.Add(condition1)

        ca(0) = New DevExpress.XtraGrid.StyleFormatCondition
        ca(0).Appearance.ForeColor = GL_ColorOcultar
        ca(0).Appearance.Options.UseForeColor = True
        ca(0).Condition = FormatConditionEnum.Expression
        ca(0).Expression = "[Ocultar] <> 0" '=" & GL_SQL_VALOR_1


        'Gv.FormatConditions.Add(condition1)

        'Array.Reverse(ca)

        Gv.FormatConditions.AddRange(ca)

        'condition1 = New DevExpress.XtraGrid.StyleFormatCondition()
        'condition1.Appearance.BackColor = GL_ColorBajaReservado
        'condition1.Appearance.Options.UseBackColor = True
        'condition1.Condition = FormatConditionEnum.Expression
        'condition1.Expression = "[Baja] = true and [Reservado] <>0 "
        'Gv.FormatConditions.Add(condition1)

        'condition1 = New DevExpress.XtraGrid.StyleFormatCondition()
        'condition1.Appearance.ForeColor = Color.SteelBlue
        'condition1.Appearance.Options.UseForeColor = True
        'condition1.Condition = FormatConditionEnum.Expression
        'condition1.Expression = "[AlquiladaPorNosotros] =" & GL_SQL_VALOR_1
        'Gv.FormatConditions.Add(condition1)


    End Sub

    Public Sub FocusedColorInmuebles(ByRef Gv As MyGridView)

        Dim a As DataRowView = Gv.GetFocusedRow
        With Gv.Appearance.FocusedRow
            .ForeColor = Color.Black
            'Try
            '    If a.Item("Visitado") Then
            '        .BackColor = GL_ColorVisitadoSeleccionado
            '        Gv.Appearance.HideSelectionRow.BackColor = Gv.Appearance.FocusedRow.BackColor
            '        Gv.Appearance.HideSelectionRow.ForeColor = Gv.Appearance.FocusedRow.ForeColor
            '        Exit Sub
            '    End If
            'Catch
            'End Try
            Try
                If a.Item("Baja") Then
                    .BackColor = GL_ColorBajaSeleccionado
                    Gv.Appearance.HideSelectionRow.BackColor = Gv.Appearance.FocusedRow.BackColor
                    Gv.Appearance.HideSelectionRow.ForeColor = Gv.Appearance.FocusedRow.ForeColor
                    Gv.Appearance.FocusedCell.BackColor = Gv.Appearance.FocusedRow.BackColor
                    Exit Sub
                End If
            Catch
            End Try
            Try
                If a.Item("Reservado") Then
                    .BackColor = GL_ColorReservadoSeleccionado

                    Gv.Appearance.HideSelectionRow.BackColor = Gv.Appearance.FocusedRow.BackColor
                    Gv.Appearance.HideSelectionRow.ForeColor = Gv.Appearance.FocusedRow.ForeColor
                    Gv.Appearance.FocusedCell.BackColor = Gv.Appearance.FocusedRow.BackColor
                    Gv.Appearance.FocusedCell.ForeColor = Gv.Appearance.FocusedRow.ForeColor
                    Exit Sub
                End If
            Catch
            End Try
            Try
                If a.Item("MostrarPPrincipalWeb") Then
                    .BackColor = GL_ColorMostrarPPrincipalWebSeleccionado
                    Gv.Appearance.HideSelectionRow.BackColor = Gv.Appearance.FocusedRow.BackColor
                    Gv.Appearance.HideSelectionRow.ForeColor = Gv.Appearance.FocusedRow.ForeColor
                    Gv.Appearance.FocusedCell.BackColor = Gv.Appearance.FocusedRow.BackColor
                    Exit Sub
                End If
            Catch
            End Try
            Try
                If a.Item("PendienteWeb") Then
                    .BackColor = GL_ColorPendienteWebSeleccionado
                    Gv.Appearance.HideSelectionRow.BackColor = Gv.Appearance.FocusedRow.BackColor
                    Gv.Appearance.HideSelectionRow.ForeColor = Gv.Appearance.FocusedRow.ForeColor
                    Gv.Appearance.FocusedCell.BackColor = Gv.Appearance.FocusedRow.BackColor
                    Exit Sub
                End If
            Catch
            End Try
            Try
                If a.Item("Visitado") Then
                    .BackColor = GL_ColorVisitadoSeleccionado
                    Gv.Appearance.HideSelectionRow.BackColor = Gv.Appearance.FocusedRow.BackColor
                    Gv.Appearance.HideSelectionRow.ForeColor = Gv.Appearance.FocusedRow.ForeColor
                    Gv.Appearance.FocusedCell.BackColor = Gv.Appearance.FocusedRow.BackColor
                    Exit Sub
                End If
            Catch
            End Try

            Try
                If a.Item("Ocultar") Then
                    .BackColor = GL_ColorOcultarSeleccionado
                    Gv.Appearance.HideSelectionRow.BackColor = Gv.Appearance.FocusedRow.BackColor
                    Gv.Appearance.HideSelectionRow.ForeColor = Gv.Appearance.FocusedRow.ForeColor
                    Gv.Appearance.FocusedCell.BackColor = Gv.Appearance.FocusedRow.BackColor
                    Exit Sub
                End If
            Catch
            End Try







            'Try
            '    If a.Item("AlquiladaPorNosotros") = 1 Then
            '        .BackColor = Color.White
            '        .ForeColor = Color.SteelBlue
            '        Gv.Appearance.HideSelectionRow.BackColor = Color.White
            '        Gv.Appearance.HideSelectionRow.ForeColor = Color.SteelBlue
            '        Exit Sub
            '    End If
            'Catch
            'End Try


            .BackColor = GL_ColorSeleccionado
            .ForeColor = GL_ColorTextoSeleccionado

        End With

        Gv.Appearance.FocusedCell.BackColor = Gv.Appearance.FocusedRow.BackColor
        Gv.Appearance.HideSelectionRow.BackColor = Gv.Appearance.FocusedRow.BackColor
        Gv.Appearance.HideSelectionRow.ForeColor = Gv.Appearance.FocusedRow.ForeColor


    End Sub

    Public Function InsertarDocumento(ByVal Carpeta As String, Optional ByVal Filtro As Integer = 0, Optional ByVal SeleccionMultiple As Boolean = False, Optional ByVal titulo As String = "Seleccione un fichero", Optional ByVal FicheroDestino As String = "", Optional ByVal ConfiguracionMarcaAgua As MarcaAgua.clConfiguracionMarcaAgua = Nothing, Optional carpetaEsDondeBusca As Boolean = False) As String

        Dim ofd As New OpenFileDialog
        Dim FicheroADevolver As String = ""
        ' Dim Ruta As String

        Dim FiltroFinal As String = "Todos (*.*, *.*)|*.*;*.*"

        Select Case Filtro
            Case EnumFiltro.EXCEL
                FiltroFinal = "Archivos Excel |*.xls|xlsx|*.xlsx"
            Case EnumFiltro.WORD
                FiltroFinal = "Archivos de Word(*.doc;*.docx)|*.doc;*.docx"
            Case EnumFiltro.PDF
                FiltroFinal = "Archivos PDF |*.pdf"
            Case EnumFiltro.JPG
                FiltroFinal = "Archivos JPG |*.jpg"
            Case EnumFiltro.TODOS
                FiltroFinal = "Todos (*.*, *.*)|*.*;*.*"
            Case EnumFiltro.IMAGENES
                FiltroFinal = "Archivos JPG, PNG, BMP |*.jpg;*.png;*.bmp"

        End Select



        Try
            ofd.Title = titulo
            ofd.Filter = FiltroFinal
            ofd.Multiselect = SeleccionMultiple
            If carpetaEsDondeBusca Then
                ofd.InitialDirectory = Carpeta.Replace("/", "\") & "\"
            End If
            If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then

                FuncionesGenerales.Funciones.ComprobarYCrearCarpetas(Carpeta)

                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                Dim primero As Boolean = True
                For Each Ruta As String In ofd.FileNames
                    If primero Then
                        primero = False
                        If FicheroDestino = "" Then
                            FicheroDestino = System.IO.Path.GetFileName(Ruta)
                        Else
                            FicheroDestino &= System.IO.Path.GetExtension(Ruta)
                        End If
                    Else
                        FicheroDestino = System.IO.Path.GetFileName(Ruta)
                    End If
                    If Not IsNothing(ConfiguracionMarcaAgua) Then

                        AnadirMarcaAguaJPG(Ruta, Carpeta & "\" & FicheroDestino, ConfiguracionMarcaAgua)

                        LiberarMemoria()
                        FicheroADevolver = Carpeta & "\" & FicheroDestino
                    Else

                        System.IO.File.Copy(Ruta, Carpeta & "\" & FicheroDestino)
                        FicheroADevolver = Ruta
                    End If


                Next
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Arrow
                '   Ruta = ofd.FileName
            Else
                MsgBox("No seleccionó ningún fichero.")

                Return ""
            End If
        Catch ex As Exception

            MsgBox(ex.Message)
            Return ""
        End Try

        Return FicheroADevolver



        '   Dim DirFiles() As String = System.IO.Directory.GetFiles(CarpetaDocumento, "*.*")


    End Function

    Public Function ObtenerExtensionLogo() As String
        Return BD_CERO.Execute("SELECT ExtensionLogo FROM Empresas WHERE Codigo = " & DatosEmpresa.Codigo, False, "")
    End Function


    Public Function ObtenerWebEmpresa(Optional ConHTTP As Boolean = True, Optional QuitarWWW As Boolean = True) As String

        Dim web As String = GL_ConfiguracionWeb.Web

        If QuitarWWW Then
            web = Replace(web, "www.", "", , , CompareMethod.Text)
        End If

        If ConHTTP Then
            If web.Length > 7 AndAlso Microsoft.VisualBasic.Left(web, 7).ToUpper <> "HTTP://" Then
                web = "http://" & web
            End If

            web = Replace(web, "http://https://", "https://")

        End If


        Return web
    End Function


    Public Function PuedeEliminar(Tabla As String, Valor As String) As Boolean

        Dim Puede As Boolean = True
        Dim Sel As String = ""

        Select Case Tabla.ToUpper

            Case "AGRUPACION"
                Sel = "SELECT COUNT(*) FROM Clientes  WHERE " & Tabla & " = '" & Valor & "'"
                If BD_CERO.Execute(Sel, False) > 0 Then
                    Return False
                End If

                Sel = "SELECT COUNT(*) FROM Inmuebles  WHERE " & Tabla & " = '" & Valor & "'"
                If BD_CERO.Execute(Sel, False) > 0 Then
                    Return False
                End If

            Case "COMOCONOCISTE"
                Sel = "SELECT COUNT(*) FROM Clientes  WHERE " & Tabla & " = '" & Valor & "'"
                If BD_CERO.Execute(Sel, False) > 0 Then
                    Return False
                End If

            Case "EMPLEADOS"

                Sel = "SELECT COUNT(*) FROM Inmuebles  WHERE ContadorEmpleado = " & CInt(Valor)
                If BD_CERO.Execute(Sel, False) > 0 Then
                    Return False
                End If


                Sel = "SELECT COUNT(*) FROM ClientesComunicaciones  WHERE ContadorEmpleado = " & CInt(Valor)
                If BD_CERO.Execute(Sel, False) > 0 Then
                    Return False
                End If


                Sel = "SELECT COUNT(*) FROM Visitas  WHERE ContadorEmpleado = " & CInt(Valor)
                If BD_CERO.Execute(Sel, False) > 0 Then
                    Return False
                End If



                Sel = "SELECT COUNT(*) FROM PropietariosComunicaciones  WHERE ContadorEmpleado = " & CInt(Valor)
                If BD_CERO.Execute(Sel, False) > 0 Then
                    Return False
                End If

                'Sel = "SELECT COUNT(*) FROM CambiosPrecio  WHERE ContadorEmpleado = " & CInt(Valor)
                'If BD_CERO.Execute(Sel, False) > 0 Then
                '    Return False
                'End If

                Sel = "SELECT COUNT(*) FROM Impresiones  WHERE ContadorEmpleado = " & CInt(Valor)
                If BD_CERO.Execute(Sel, False) > 0 Then
                    Return False
                End If

                'Sel = "SELECT COUNT(*) FROM ClientesObservaciones  WHERE ContadorEmpleado = " & CInt(Valor)
                'If BD_CERO.Execute(Sel, False) > 0 Then
                '    Return False
                'End If

                'Sel = "SELECT COUNT(*) FROM InmueblesObservaciones  WHERE ContadorEmpleado = " & CInt(Valor)
                'If BD_CERO.Execute(Sel, False) > 0 Then
                '    Return False
                'End If



                'Sel = "SELECT COUNT(*) FROM PropietariosComunicaciones  WHERE ContadorEmpleado = " & CInt(Valor)
                'If BD_CERO.Execute(Sel, False) > 0 Then
                '    Return False
                'End If











            Case Else

                Sel = "SELECT COUNT(*) FROM Clientes" & Tabla & " WHERE " & Tabla & " = '" & Valor & "'"
                If BD_CERO.Execute(Sel, False) > 0 Then
                    Return False
                End If

                Sel = "SELECT COUNT(*) FROM Inmuebles WHERE " & Tabla & " = '" & Valor & "'"
                If BD_CERO.Execute(Sel, False) > 0 Then
                    Return False
                End If

        End Select

        Return Puede

    End Function


    Public Function ObtenerCampoFechaAACtualizar(Tipo As String) As String

        ' Dim CampoFecha As String = "      "
        Dim CampoFecha As String = ""
        Select Case Tipo
            Case GL_LLAMADA_DETALLE
                CampoFecha = "AvisadoInmueble"
            Case GL_EMAIL_DETALLE
                ' CampoFecha = "AvisoInmueble" '"Email Detalle"******************* YA NO ESTA
            Case GL_SMS
                CampoFecha = "SMS"
            Case GL_VISITA_OFICINA
                CampoFecha = "VisitaOficina"
            Case GL_EMAIL_FIJO
                CampoFecha = "EmailFijo"
            Case GL_EMAIL_LISTADO_CLIENTES
                CampoFecha = "EmailListado"
            Case GL_EMAIL_LISTADO_NOVEDADES
                CampoFecha = "Novedades" '"EmailNovedades"******************* YA NO ESTA
            Case GL_LLAMADA
                CampoFecha = "Llamada" '*****************************Fecha YA NO ESTA
            Case Else

        End Select

        If CampoFecha = "" Then
            Return ""
        Else
            Return "Fecha" & CampoFecha
        End If



    End Function
    Public Function ListaZonas(Poblaciones As List(Of String), ContadorEmpresa As Integer) As List(Of Tablas.clZonas)

        Dim Zonas As New List(Of Tablas.clZonas)

        Dim bdlist As BaseDatos

        Try


            bdlist = New BaseDatos

            Dim dtr As Object
            Dim sel As String = String.Empty

            Dim ListaPoblaciones As String = ""

            For i = 0 To Poblaciones.Count - 1
                If ListaPoblaciones = "" Then
                    ListaPoblaciones = "'" & Funciones.pf_ReplaceComillas(Poblaciones(i).ToUpper.Trim) & "'"
                Else
                    ListaPoblaciones = ListaPoblaciones & ", '" & Funciones.pf_ReplaceComillas(Poblaciones(i).ToUpper.Trim) & "'"
                End If
            Next

            If ListaPoblaciones <> "" Then
                ListaPoblaciones = " WHERE " & GL_SQL_UPPER & "(Poblacion) IN ( " & ListaPoblaciones & ")"
            End If

            'sel = "SELECT 'TODOS' AS Zona, 0 AS ORDEN UNION ALL SELECT DISTINCT Zona, 1 AS ORDEN FROM Zona " & ListaPoblaciones & " ORDER BY ORDEN, Zona "
            sel = "SELECT DISTINCT Zona FROM Zona " & ListaPoblaciones & " UNION ALL SELECT Zona FROM ZonasComunes ORDER BY  Zona "
            'If Poblaciones.Count <= 1 Then
            'sel = "SELECT DISTINCT Zona FROM Zona " & ListaPoblaciones & " UNION ALL SELECT Zona FROM ZonasComunes ORDER BY  Zona "
            'Else
            '    sel = "SELECT Zona FROM ZonasComunes ORDER BY  Zona "
            'End If


            dtr = bdlist.ExecuteReader(sel)



            If dtr.HasRows Then
                While dtr.Read

                    Dim Zona As New Tablas.clZonas
                    Zona.Zona = dtr("Zona")
                    Zonas.Add(Zona)

                End While
            End If

            dtr.Close()
            bdlist.CerrarBD()





        Catch ex As Exception

            MensajeError(ex.Message)

        End Try

        Return Zonas

    End Function
    Public Function PrevioEliminarInmueble(Referencia As String, Baja As Boolean, ContadorInmueble As Integer) As Boolean



        Dim Sel As String

        'Sel = GL_SQL_DELETE & "  FROM Reservas WHERE ContadorInmueble = " & ContadorInmueble
        'BD_CERO.Execute(Sel)

        'Sel = GL_SQL_DELETE & "  FROM ReservasRegistro WHERE ContadorInmueble = " & ContadorInmueble
        'BD_CERO.Execute(Sel)

        'Sel = GL_SQL_DELETE & "  FROM NuevasAltas WHERE ContadorInmueble = " & ContadorInmueble
        'BD_CERO.Execute(Sel)

        'Sel = GL_SQL_DELETE & "  FROM NuevasReservasQuitadas  WHERE ContadorInmueble = " & ContadorInmueble
        'BD_CERO.Execute(Sel)

        'Sel = GL_SQL_DELETE & "  FROM NuevosCambiosPrecios  WHERE ContadorInmueble = " & ContadorInmueble
        'BD_CERO.Execute(Sel)

        'Sel = GL_SQL_DELETE & "  FROM InmueblesReservasQuitadas  WHERE ContadorInmueble = " & ContadorInmueble
        'BD_CERO.Execute(Sel)

        Sel = GL_SQL_DELETE & "  FROM InmueblesInformes  WHERE ContadorInmueble = " & ContadorInmueble
        BD_CERO.Execute(Sel)

        Sel = GL_SQL_DELETE & "  FROM Impresiones  WHERE ContadorInmueble = " & ContadorInmueble
        BD_CERO.Execute(Sel)

        'Sel = GL_SQL_DELETE & "  FROM CambiosPrecio  WHERE ContadorInmueble = " & ContadorInmueble
        'BD_CERO.Execute(Sel)

        Sel = GL_SQL_DELETE & "  FROM ClientesComunicaciones  WHERE ContadorInmueble = " & ContadorInmueble
        BD_CERO.Execute(Sel)


        Sel = GL_SQL_DELETE & "  FROM Visitas  WHERE ContadorInmueble = " & ContadorInmueble
        BD_CERO.Execute(Sel)

        'JCB CARPETA FOTOS
        Dim CarpetaDocumentoAlta As String = GL_CarpetaFotos & "\" & Referencia
        Dim CarpetaDocumentoBaja As String = GL_CarpetaFotosBaja & "\" & Referencia
        Dim CarpetaDocumentoEliminados As String = GL_CarpetaFotosEliminadas & "\" & Referencia

        Dim CarpetaDocumentoOrigen As String
        Dim CarpetaDocumentoDestino As String

        If Not Baja Then
            CarpetaDocumentoOrigen = CarpetaDocumentoAlta
            CarpetaDocumentoDestino = CarpetaDocumentoEliminados
        Else
            CarpetaDocumentoOrigen = CarpetaDocumentoBaja
            CarpetaDocumentoDestino = CarpetaDocumentoEliminados
        End If

        Dim DirFiles() As String = Nothing

        If System.IO.Directory.Exists(CarpetaDocumentoOrigen) Then
            DirFiles = System.IO.Directory.GetFiles(CarpetaDocumentoOrigen, "*.*")

            Try
                If DirFiles.Length > 0 Then
                    If System.IO.Directory.Exists(CarpetaDocumentoDestino) Then
                        IO.Directory.Delete(CarpetaDocumentoDestino, True)
                    End If
                    FuncionesGenerales.Funciones.ComprobarYCrearCarpetas(CarpetaDocumentoDestino)
                    For i = 0 To DirFiles.Length - 1
                        Dim NombreFichero As String = My.Computer.FileSystem.GetName(DirFiles(i))
                        Dim RutaFicheroDestino = CarpetaDocumentoDestino & "\" & NombreFichero
                        System.IO.File.Copy(DirFiles(i), RutaFicheroDestino)
                    Next

                    Try
                        For i = 0 To DirFiles.Length - 1
                            System.IO.File.Delete(DirFiles(i))
                        Next

                    Catch ex As Exception

                    End Try

                    If Not Baja Then
                        Dim CarpetaDocumentoPublicadas As String = CarpetaDocumentoOrigen & "\actualizarweb"

                        'quitar imagenes de la web
                        Dim ftp As New tb_FTP
                        'Dim Http = "httpdocs/roberto" 'carpeta de la web
                        Dim Http As String = GL_ConfiguracionWeb.DirectorioFotos
                        ftp.FTPBorrarFicherosCarpeta(Http, "jpg")
                        'quitar imagenes de la carpeta publicados
                        Try
                            If System.IO.Directory.Exists(CarpetaDocumentoPublicadas) Then
                                System.IO.Directory.Delete(CarpetaDocumentoPublicadas, True)
                            End If
                        Catch
                            MensajeError("Error al borrar fotos publicadas")
                        End Try
                    End If

                    System.IO.Directory.Delete(CarpetaDocumentoOrigen, True)

                Else
                    Exit Function
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Function
            End Try
        End If


    End Function
    Public Class GoogleUrlShortnerApi
        Private Const key As String = "AIzaSyCSlGDRyifpvk9Abc3AOpg6OpW91NowoUY"

        Public Shared Function Shorten(url As String) As String
            Dim post As String = (Convert.ToString("{""longUrl"": """) & url) + """}"
            Dim shortUrl As String = url
            Dim request As HttpWebRequest = DirectCast(WebRequest.Create(Convert.ToString("https://www.googleapis.com/urlshortener/v1/url?key=") & key), HttpWebRequest)

            Try
                request.ServicePoint.Expect100Continue = False
                request.Method = "POST"
                request.ContentLength = post.Length
                request.ContentType = "application/json"
                request.Headers.Add("Cache-Control", "no-cache")

                Using requestStream As IO.Stream = request.GetRequestStream()
                    Dim postBuffer As Byte() = Encoding.ASCII.GetBytes(post)
                    requestStream.Write(postBuffer, 0, postBuffer.Length)
                End Using

                Using response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
                    Using responseStream As IO.Stream = response.GetResponseStream()
                        Using responseReader As New IO.StreamReader(responseStream)
                            Dim json As String = responseReader.ReadToEnd()
                            shortUrl = RegularExpressions.Regex.Match(json, """id"": ?""(?<id>.+)""").Groups("id").Value
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                ' if Google's URL Shortner is down...
                System.Diagnostics.Debug.WriteLine(ex.Message)
                System.Diagnostics.Debug.WriteLine(ex.StackTrace)
            End Try
            Return shortUrl
        End Function
    End Class



    'Public Class GoogleUrlShortner
    '    Public Shared Function Shorten(longUrl As String) As GoogleUrlReply
    '        Dim data As String = (Convert.ToString("{""longUrl"":""") & longUrl) + """}"
    '        Dim gUrl As String = "https://www.googleapis.com/urlshortener/v1/url"

    '        Dim response As String = Post(gUrl, data)
    '        Return FromJSON(Of GoogleUrlReply)(response)
    '    End Function

    '    Private Shared Function Post(url As String, data As String) As String
    '        Dim request As WebRequest = WebRequest.Create(url)
    '        request.Method = "POST"
    '        request.ContentType = "application/json"

    '        Dim byteData As Byte() = Encoding.UTF8.GetBytes(data)

    '        request.ContentLength = byteData.Length

    '        Using s As IO.Stream = request.GetRequestStream()
    '            s.Write(byteData, 0, byteData.Length)
    '            s.Close()
    '        End Using

    '        Dim replyData As String

    '        Using response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
    '            Using dataStream As IO.Stream = response.GetResponseStream()
    '                Using reader As New IO.StreamReader(dataStream)
    '                    replyData = reader.ReadToEnd()
    '                End Using
    '            End Using
    '        End Using

    '        Return replyData
    '    End Function

    '    Private Shared Function FromJSON(Of T)(input As String) As T
    '        Dim stream As New IO.MemoryStream()

    '        Try
    '            Dim jsSerializer As New DataContractJsonSerializer(GetType(T))
    '            stream = New IO.MemoryStream(Encoding.UTF8.GetBytes(input))
    '            Dim obj As T = DirectCast(jsSerializer.ReadObject(stream), T)

    '            Return obj
    '        Finally
    '            stream.Close()
    '            stream.Dispose()
    '        End Try
    '    End Function
    'End Class
    Public Sub MostrarMapa(Contador As Integer)

        ' Dim objetoMaps As New MapsNet

        'Dim direccionString = objetoMaps.ObtenerURLdesdeDireccion(txtDireccion.Text) 'String con la direccion
        '   Dim direccion As New Uri(direccionString) 'Pasamos el string a URI



        Dim bdmap As New BaseDatos
        Dim dr As Object
        dr = bdmap.ExecuteReader("SELECT  " & Funciones.SQL_CASE({"Via <> ''", "Via=''"}, {Funciones.SQL_CASE_ISNULL("(SELECT Abreviatura FROM Vias WHERE Via = I.Via),''") & "   " & GL_SQL_SUMA & "' '" & GL_SQL_SUMA & " Direccion " & GL_SQL_SUMA & "' '" & GL_SQL_SUMA & " Numero", "Direccion " & GL_SQL_SUMA & "' '" & GL_SQL_SUMA & " Numero"}) & " as Direccion,CodPostal,Poblacion,Provincia FROM Inmuebles I WHERE Contador = " & Contador)
        dr.Read()
        Dim Direccion As String = dr("Direccion")
        Dim CodPostal As String = dr("CodPostal")
        Dim Poblacion As String = dr("Poblacion")
        Dim Provincia As String = dr("Provincia")
        dr.Close()
        bdmap.CerrarBD()
        Dim mp As New MapaGoogle(Direccion, CodPostal, Poblacion, Provincia)

        VerificaNavegador()

        Dim p As New XtraForm1("Mapa")
        p.Name = "Mapa"

        Dim u As New WebBrowser
        u.Dock = DockStyle.Fill

        p.Controls.Add(u)
        p.Size = New Size(New Point(700, 550))
        p.Show()

        u.ScriptErrorsSuppressed = True
        u.Navigate(mp.ObtenerFichero)


    End Sub

    Private Function VerificaNavegador() As Boolean
        Dim versaoNavegador As Integer, RegVal As Integer
        Try
            ' obtem a versão instalada do IE
            Using Wb As New WebBrowser()
                versaoNavegador = Wb.Version.Major
            End Using
            ' define a versão do IE
            If versaoNavegador >= 11 Then
                RegVal = 11001
            ElseIf versaoNavegador = 10 Then
                RegVal = 10001
            ElseIf versaoNavegador = 9 Then
                RegVal = 9999
            ElseIf versaoNavegador = 8 Then
                RegVal = 8888
            Else
                RegVal = 7000
            End If

            ' define a chave atual
            Dim Key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", True)
            Key.SetValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe", RegVal, Microsoft.Win32.RegistryValueKind.DWord)
            Key.Close()
            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub InsertarMovimientosFotocasa(Referencia As String, Publicar As Integer, Resultado As Integer, Motivo As String, MensajeAdicional As String)
        Dim Sel As String
        Sel = "INSERT INTO MovimientosFotocasa (Fecha, Referencia, Publicar, Resultado, Motivo,MensajeAdicional) VALUES (GETDATE(), '" & Funciones.pf_ReplaceComillas(Referencia) & "', " & Publicar & ", " & Resultado & ", '" & Funciones.pf_ReplaceComillas(Motivo) & "', '" & Funciones.pf_ReplaceComillas(MensajeAdicional) & "')"
        BD_CERO.Execute(Sel)
    End Sub

    Public Sub InsertarMovimientosWP(Referencia As String, Accion As String, Resultado As Integer, Motivo As String, MensajeAdicional As String)
        Dim Sel As String
        Sel = "INSERT INTO WP_Movimientos (Fecha, Referencia, Accion, Resultado, Motivo,MensajeAdicional) VALUES (GETDATE(), '" & Funciones.pf_ReplaceComillas(Referencia) & "', '" & Accion & "', " & Resultado & ", '" & Funciones.pf_ReplaceComillas(Motivo) & "', '" & Funciones.pf_ReplaceComillas(MensajeAdicional) & "')"
        BD_CERO.Execute(Sel)
    End Sub

    Public Sub InsertaEnTramites(Referencia As String, Accion As String, Mensaje As String)
        Dim Sel As String
        Sel = "INSERT INTO Tramites (Fecha, Referencia, Accion ,MensajeAdicional) VALUES (GETDATE(), '" & Funciones.pf_ReplaceComillas(Referencia) & "', '" & Funciones.pf_ReplaceComillas(Accion) & "', '" & Funciones.pf_ReplaceComillas(Mensaje) & "')"
        BD_CERO.Execute(Sel)
    End Sub


End Module
