Imports System.IO


Public Class frmObtenerFotos

    Dim bd As BaseDatos
    Dim CarpetaOrigen As String = ""

    'JCB CARPETA FOTOS
    Dim CarpetaDestino As String = GL_CarpetaFotos & "\"

    Private Sub frmFichaReserva_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        AparienciaGeneral()

    End Sub



    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Salir()
    End Sub
    Private Sub Salir()
        Me.Dispose()
    End Sub

    Private Sub btnCarpetaOrigen_Click(sender As System.Object, e As System.EventArgs) Handles btnCarpetaOrigen.Click
        btnCarpetaOrigen.ForeColor = Color.Red
        Dim fbd As New FolderBrowserDialog
        Try
            fbd.Description = "Seleccione la carpeta de 'Fotos' origen"
            If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
                CarpetaOrigen = fbd.SelectedPath
                btnCarpetaOrigen.Text = System.IO.Path.GetFileName(CarpetaOrigen)
                btnCarpetaOrigen.ToolTip = System.IO.Path.GetFileName(CarpetaOrigen)
                btnCopiarFotos.Enabled = True
                btnCarpetaOrigen.ForeColor = Color.Green
            Else
                MsgBox("No seleccionó ningúna carpeta.")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

    End Sub

    Private Sub btnCopiarFotos_Click(sender As System.Object, e As System.EventArgs) Handles btnCopiarFotos.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        If Not FuncionesGenerales.Funciones.DirectoryCopy(CarpetaOrigen, CarpetaDestino, True) Then
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            MsgBox("No se ha podido completar la operacion")
            btnCopiarFotos.ForeColor = Color.Red
        Else
            btnCopiarFotos.ForeColor = Color.Green
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub

    Private Sub btnObtenerFotos_Click(sender As System.Object, e As System.EventArgs) Handles btnObtenerFotos.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        If Not DescargaWeb() Then
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            MsgBox("No se ha podido completar la operacion")
            btnObtenerFotos.ForeColor = Color.Red
        Else
            btnObtenerFotos.ForeColor = Color.Green
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub
    Private Function DescargaWeb() As Boolean
        Dim ftp As New tb_FTP
        'Dim Http = "httpdocs/roberto" 'carpeta de la web
        Dim Http As String = GL_ConfiguracionWeb.DirectorioFotos
        Try
            Dim a() As String = Split(ftp.FTPCarpetasEn(Http), "|")
            Dim numdir As Integer = 0
            btnNum.Text = CStr(numdir) & " %"
            btnNum.Visible = True
            For i = 0 To a.Count - 1
                numdir += 1
                btnNum.Text = CStr(CInt(100 / a.Count) * numdir) & " %"
                btnNum.Refresh()
                If Not a(i) = "" Then
                    Try
                        System.IO.Directory.Delete(CarpetaDestino & "\" & a(i) & "\actualizarweb", True)
                    Catch
                    End Try
                    ftp.FTPDescargarCarpeta(Http & "\" & a(i), CarpetaDestino & "\" & a(i) & "\actualizarweb")
                End If
            Next
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
            btnNum.Visible = False
            Return False
        End Try
        btnNum.Visible = False
        Return True
    End Function

    Private Sub btnActualizarBD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarBD.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        If Not ActualizarBD() Then
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            MsgBox("No se ha podido completar la operacion")
            btnActualizarBD.ForeColor = Color.Red
        Else
            btnActualizarBD.ForeColor = Color.Green
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub
    Private Function ActualizarBD() As Boolean
        Dim FotosPc As Integer = 0
        Dim FotosWeb As Integer = 0
        Dim RefInmueble As Integer = -1
        Dim Sel As String = ""
        Dim bd As New BaseDatos

        Dim dir As DirectoryInfo = New DirectoryInfo(CarpetaDestino)
        Dim dirs As DirectoryInfo() = dir.GetDirectories()

        If Not dir.Exists Then
            MsgBox("No se ha encontrado el directorio : " & CarpetaDestino)
            Return False
        End If
        Try
            Sel = "UPDATE Inmuebles SET FotosPc=0,FotosWeb=0 WHERE CodigoEmpresa=" & DatosEmpresa.Codigo
            bd.Execute(Sel)
            Dim numdir As Integer = 0
            btnNum.Text = CStr(numdir) & " %"
            btnNum.Visible = True
            For Each subdir In dirs
                numdir += 1
                btnNum.Text = CStr(CInt(100 / dirs.Count) * numdir) & " %"
                btnNum.Refresh()
                Dim files As FileInfo() = subdir.GetFiles("*.jpg")
                FotosPc = files.Count

                Dim a() As String = Split(subdir.ToString, "-")
                RefInmueble = CInt(a(1))

                Dim dirweb As DirectoryInfo = New DirectoryInfo(CarpetaDestino & subdir.ToString & "\actualizarweb")
                If dirweb.Exists Then
                    Dim filesweb As FileInfo() = dirweb.GetFiles("*.jpg")
                    FotosWeb = filesweb.Count
                Else
                    FotosWeb = 0
                End If

                Sel = "UPDATE Inmuebles SET FotosPc=" & FotosPc & ",FotosWeb=" & FotosWeb & " WHERE Referencia =" & RefInmueble & " AND CodigoEmpresa=" & DatosEmpresa.Codigo
                bd.Execute(Sel)

            Next subdir
        Catch ex As Exception
            MsgBox("Error: " + ex.Message)
            btnNum.Visible = False
            Return False
        End Try
        btnNum.Visible = False
        Return True
    End Function
End Class







