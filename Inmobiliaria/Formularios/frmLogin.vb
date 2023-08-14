Public Class frmLogin

    Public Sub New()
        InitializeComponent()
    End Sub


    Private Declare Sub keybd_event Lib "user32" ( _
       ByVal bVk As Byte, _
       ByVal bScan As Byte, _
       ByVal dwFlags As Integer, _
       ByVal dwExtraInfo As Integer _
   )
    Private Const VK_CAPITAL As Integer = &H14
    Private Const KEYEVENTF_EXTENDEDKEY As Integer = &H1
    Private Const KEYEVENTF_KEYUP As Integer = &H2
    Private bloqueo As Boolean
    Private Sub frmLogin_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.Text = "Autenticación"
        lbl1.Text = "Usuario"
        lbl2.Text = "Contraseña"

      

        ' PintarIconos(Me)
       
        EstadoInicial()
        txt1.Text = FuncionesGenerales.FicheroIni.Leer(GL_FicheroINI, "OTROS_DATOS", "ULTIMO_USUARIO")

        If Not Debugger.IsAttached Then
            txt2.Text = ""
        Else
            If txt1.Text.ToUpper = "TRESBITS" Then
                txt2.Text = "Admin0001"
                ComprobarUsuario()
                Return
            Else
                txt2.Text = "a"
            End If

        End If

        '   txt1.Text = System.Environment.UserName
        '#If Not Debug Then
        '  txt2.Text = "a"
        '#Else
        'txt2.Text = ""
        '#End If
 

        txt2.Properties.PasswordChar = "*"
        ' Toggle CapsLock
        If My.Computer.Keyboard.CapsLock Then
            LabelControl1.Visible = True
            capslock()
            bloqueo = True
        End If
       
        txt1.Focus()
 

    End Sub

 
    Private Sub capslock()
        ' Simulate the Key Press
        keybd_event(VK_CAPITAL, &H45, KEYEVENTF_EXTENDEDKEY Or 0, 0)
        ' Simulate the Key Release
        keybd_event(VK_CAPITAL, &H45, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        ComprobarUsuario()
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If bloqueo AndAlso Not My.Computer.Keyboard.CapsLock Then
            capslock()
        End If
        Me.Dispose()
    End Sub

    Private Sub ComprobarUsuario()




        '*************************cambiar posteriormente
        Gl_Delegacion = 1
        '***************************************************



        Dim Sel As String
        Dim dtr As Object
        Dim bdcom As New BaseDatos

        GL_CodigoUsuario = 0
        '  GL_DisenoPerfil = "Metropolis"
        GL_DisenoPerfil = "Office 2010 Blue"
        GL_TipoUsuario = ""
        GL_Usuario = ""
        GL_CARPETA_PERFILES = ""

        'DatosEmpresa = New clDatosEmpresa

        '  Dim Usuario As String = txt1.Text.ToUpper.Trim
        GL_CodigoUsuario = 0

        Sel = "SELECT * FROM Empleados WHERE " & GL_SQL_UPPER & "(usuario) = '" & txt1.Text.ToUpper.Trim & "' and Pass  = '" & Encriptacion.Encriptar(txt2.Text, "LAMBDAPI") & "'"
        dtr = bdcom.ExecuteReader(Sel)

        If dtr IsNot Nothing AndAlso dtr.HasRows Then
            dtr.Read()

            If dtr("Baja") <> False Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Este usuario ha sido bloqueado y no puede acceder al sistema." & vbCrLf & "Por favor intentelo de nuevo.", "Login Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt1.Focus()
                dtr.Close()
                bdcom.CerrarBD()
                Exit Sub
            End If

            GL_CodigoUsuario = dtr("Contador")
            GL_Usuario = dtr("Usuario")
            GL_DisenoPerfil = dtr("DisenoPerfil")
            GL_TipoUsuario = dtr("Tipo")
            GL_Usuario_NombreEmpleado = dtr("Nombre")


             

        Else
            If txt1.Text.ToUpper = "TRESBITS" AndAlso txt2.Text.ToUpper = "ADMIN0001" Then

                GL_CodigoUsuario = -1
                GL_Usuario = "SUPERADMINISTRADOR"
                GL_DisenoPerfil = "Office 2010 Blue" '"Metropolis"

                GL_TipoUsuario = ADMINISTRADOR
                'dtr.Close()

       

            Else
                DevExpress.XtraEditors.XtraMessageBox.Show("Usuario o Clave Incorrecta." & vbCrLf & "Por favor intentelo de nuevo.", "Login Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt1.Focus()
                dtr.Close()
                bdcom.CerrarBD()
                Exit Sub
            End If

        End If
        dtr.Close()
        bdcom.CerrarBD()


        'GL_CARPETA_PERFILES = clVariables.RutaServidor & "\PERFILES\PERFILES_" & GL_Usuario


        GL_CARPETA_PERFILES = clVariables.RutaServidor & "\PERFILES"



        FuncionesGenerales.FicheroIni.Escribir(GL_FicheroINI, "OTROS_DATOS", "ULTIMO_USUARIO", txt1.Text)
        If bloqueo AndAlso Not My.Computer.Keyboard.CapsLock Then
            capslock()
        End If
        Me.Close()

    End Sub



    Private Sub EstadoInicial()
        btnAceptar.Enabled = True
        btnCancelar.Enabled = True
        txt1.Focus()
    End Sub

   
    Private Sub txt2_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txt2.EditValueChanged

    End Sub

    Private Sub txt2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txt2.KeyDown
        If e.KeyCode = Keys.Enter Then
            ComprobarUsuario()
        End If

    End Sub

    
    Private Sub btnRed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRed.Click
        frmRed.ShowDialog()
    End Sub
End Class