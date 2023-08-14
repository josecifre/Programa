Imports System.Data.SqlClient

Public Class ucEmailConfiguracion

    Private Sub ucEmailConfiguracion_Load(sender As Object, e As System.EventArgs) Handles Me.Load


        MostrarImagenDeFondo()

        Dim Sel As String
        Dim bdBuscar As New BaseDatos
        Dim dtr As Object

        Sel = "SELECT * FROM EmailConfiguracion"
        dtr = bdBuscar.ExecuteReader(Sel)

        If dtr.HasRows Then
            While dtr.Read

                txtEmail.Text = dtr("Email")
                txtNombreAMostrar.Text = dtr("NombreMostrar")
                txtUsuario.Text = dtr("Usuario")
                txtPass.Text = Encriptacion.DesEncriptar(dtr("Contrasena"), "LAMBDAPI")
                txtSMTP.Text = dtr("SMTP")
                txtPOP3.Text = dtr("POP3Host")
                spnPuertoSMTP.Text = dtr("PuertoSMTP")
                spnPuertoPOP3.Text = dtr("PuertoPOP3")
                chkSSL.Checked = dtr("SSL")



            End While
        Else

        End If
        dtr.Close()
        bdBuscar.CerrarBD()

    End Sub



    Private Function ValidarDatos() As Boolean


        If txtEmail.Text.Trim = "" Then
            MensajeError("Debe indicar un email")
            txtEmail.Focus()
            Return False
        End If


        If Not FuncionesGenerales.Funciones.validar_Mail(txtEmail.Text) Then
            MensajeError("El email no es válido")
            txtEmail.Focus()
            Return False
        End If


        If txtUsuario.Text.Trim = "" Then
            MensajeError("Debe indicar el usuario")
            txtUsuario.Focus()
            Return False
        End If

        If txtPass.Text.Trim = "" Then
            MensajeError("Debe indicar la contraseña")
            txtPass.Focus()
            Return False
        End If


        If spnPuertoSMTP.Text.Trim = "" Or spnPuertoSMTP.Text = "0" Then
            MensajeError("Debe indicar el puerto saliente (25, 587, ...)")
            spnPuertoSMTP.Focus()
            Return False
        End If


        If spnPuertoPOP3.Text = "" Then
            spnPuertoPOP3.Text = "0"
        End If

        If txtSMTP.Text.Trim = "" Then
            MensajeError("Debe indicar el servidor saliente")
            txtSMTP.Focus()
            Return False
        End If
         
       
        

        Return True
    End Function


    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click

        If Not ValidarDatos() Then
            Exit Sub
        End If


        ConsultasBaseDatos.InsertarEmailConfiguracion(txtEmail.Text, txtUsuario.Text, txtNombreAMostrar.Text, Encriptacion.Encriptar(txtPass.Text, "LAMBDAPI"), txtSMTP.Text, txtPOP3.Text, spnPuertoSMTP.Text, spnPuertoPOP3.Text, "", "", "", False, chkSSL.Checked)

        MensajeInformacion("Cambios guardados correctamente")
        Salir()


    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Salir()
    End Sub
    Private Sub Salir()
        Me.ParentForm.Dispose()
        MostrarImagenDeFondo()
    End Sub



End Class
