Public Class frmRed

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        txtRuta.Text = FuncionesGenerales.FicheroIni.Leer(GL_FicheroINI, "RED", "RED")
        If String.IsNullOrEmpty(txtRuta.Text) Then
            rbServidor.Checked = True
        Else
            rbCliente.Checked = True
        End If

        rbServidor.Focus()


    End Sub


    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If rbServidor.Checked Then
            FuncionesGenerales.FicheroIni.Escribir(GL_FicheroINI, "RED", "RED", "")
        Else
            If IO.Directory.Exists(txtRuta.Text) Then
                If IO.File.Exists(txtRuta.Text & "\VENALIA2.mdb") Then
                    FuncionesGenerales.FicheroIni.Escribir(GL_FicheroINI, "RED", "RED", txtRuta.Text)
                Else
                    MensajeError("No existe la BBDD VENALIA2 en esta ruta.")
                    Exit Sub
                End If
            Else
                MensajeError("No existe la ruta indicada.")
                Exit Sub
            End If
        End If
        Me.Dispose()
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
      
        Me.Dispose()
    End Sub

    Private Sub btnRuta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRuta.Click
        Dim ofd As New OpenFileDialog

        ofd.Title = "Seleccione la BBDD VENALIA2"
        ofd.Filter = "BBDD VENALIA2|VENALIA2.mdb"
        ofd.Multiselect = False

        If String.IsNullOrEmpty(txtRuta.Text) Then
            ofd.InitialDirectory = "C:\"
        Else
            ofd.InitialDirectory = txtRuta.Text
        End If

        If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtRuta.Text = IO.Path.GetDirectoryName(ofd.FileName)
            rbCliente.Checked = True
        End If
    End Sub
End Class