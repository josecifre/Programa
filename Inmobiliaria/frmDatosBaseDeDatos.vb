Imports FuncionesGenerales.Funciones


Public Class frmDatosBaseDeDatos

    Private Sub frmDatosBaseDeDatos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        clVariables.ServidorSQL = ""
        clVariables.UsuarioSQL = ""
        clVariables.PassWordUsuarioSQL = ""
    End Sub


    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click



        clVariables.ServidorSQL = txtServidor.Text
        clVariables.UsuarioSQL = txtUsuario.Text
        clVariables.PassWordUsuarioSQL = txtPass.Text



        If Not Funciones.PrepararCadenaDeConexion(False) Then
            clVariables.ServidorSQL = ""
            clVariables.UsuarioSQL = ""
            clVariables.PassWordUsuarioSQL = ""
            MensajeError("Los datos introducidos no son correctos")
            Exit Sub
        End If

        clVariables.ServidorSQL = Encriptacion.Encriptar(clVariables.ServidorSQL, "LAMBDAPI")
        clVariables.UsuarioSQL = Encriptacion.Encriptar(clVariables.UsuarioSQL, "LAMBDAPI")
        clVariables.PassWordUsuarioSQL = Encriptacion.Encriptar(clVariables.PassWordUsuarioSQL, "LAMBDAPI")


        FicheroIni.Escribir(GL_FicheroINI_RED, "SERVIDORSQL", "SERVIDOR", clVariables.ServidorSQL)
        FicheroIni.Escribir(GL_FicheroINI_RED, "SERVIDORSQL", "USQLSERVER", clVariables.UsuarioSQL)
        FicheroIni.Escribir(GL_FicheroINI_RED, "SERVIDORSQL", "PSQLSERVER", clVariables.PassWordUsuarioSQL)

        Me.Dispose()

    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        clVariables.ServidorSQL = ""
        clVariables.UsuarioSQL = ""
        clVariables.PassWordUsuarioSQL = ""
        Me.Dispose()
    End Sub
End Class