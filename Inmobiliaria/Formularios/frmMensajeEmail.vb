Public Class frmMensajeEmail
    Dim adjuntos As String = ""
    Dim bd As New BaseDatos
   
    Dim SentenciaSQL As String
    Dim row As DataRowView
    Private Sub frmMensajeEmail_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
       
    

    End Sub
 
    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        If VerificarDatos() Then
            'GL_DatosMensajePersonalizado = "|" & txtAsunto.Text & "|" & txtMensaje.Text & "|" & adjuntos & "|" & _
            '     "|" & chkInfoEmpresa.Checked & "|" & chkAvisoLegal.Checked & "|" & "False"


            GL_DatosMensajePersonalizado = "TITULO" & "|" & txtAsunto.Text & "|" & txtMensaje.Text & "|" & adjuntos & "|" & _
            "0" & "|" & chkInfoEmpresa.Checked & "|" & chkAvisoLegal.Checked & "|" & "0" & "|" & "False" & "|" & "0" & "|" & "0" & "|INFORMATIVO"



            Me.Dispose()
        Else
            MensajeInformacion("Los campos asunto y mensaje son obligatorios.")
        End If
    End Sub
    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        GL_DatosMensajePersonalizado = "TITULO" & "|" & txtAsunto.Text & "|" & txtMensaje.Text & "|" & adjuntos & "|" & _
          "0" & "|" & chkInfoEmpresa.Checked & "|" & chkAvisoLegal.Checked & "|" & "0" & "|" & "True" & "|" & "0" & "|" & "0" & "|INFORMATIVO"
        Me.Dispose()
    End Sub
    Private Function VerificarDatos() As Boolean
        Return Not ((txtAsunto.Text = "") + (txtMensaje.Text = ""))
    End Function
    Private Sub btnAdjuntar_Click(sender As System.Object, e As System.EventArgs) Handles btnAdjuntar.Click
        InsertarDocumento()
    End Sub
    Private Sub InsertarDocumento(Optional FicheroDestino As String = "")
        Dim ofd As New OpenFileDialog
        Try
            ofd.Title = "Seleccione un fichero"
            ofd.Filter = "Todos (*.*, *.*)|*.*;*.*"
            ofd.Multiselect = True
            txtAdjunto.Text = ""
            adjuntos = ""
            If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
                For Each Ruta As String In ofd.FileNames
                    txtAdjunto.Text &= System.IO.Path.GetFileName(Ruta) & ","
                    adjuntos &= Ruta & ";"
                Next
                txtAdjunto.Text = txtAdjunto.Text.Substring(0, txtAdjunto.Text.Count - 1)
                adjuntos = adjuntos.Substring(0, adjuntos.Count - 1)
            Else
                MsgBox("No seleccionó ningún fichero.")
                Return
            End If
        Catch ex As Exception

            MsgBox(ex.Message)
            Return
        End Try
    End Sub
     
End Class