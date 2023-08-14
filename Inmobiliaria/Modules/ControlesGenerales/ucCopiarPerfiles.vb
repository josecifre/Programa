Imports System.Data.SqlClient

Public Class ucCopiarPerfiles

    Dim RutaPerfiles As String
    Dim RutaFiltros
    Dim p_Tipo As String

    Sub New(p_RutaPerfiles As String, Tipo As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        p_Tipo = Tipo
        RutaPerfiles = p_RutaPerfiles
        RutaFiltros = RutaPerfiles ' & "\" & "Filtros"
        btnCopiar.Text = "Copiar" & vbCrLf & "Perfiles"



        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub ucCopiarPerfiles_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Select Case p_Tipo.ToUpper
            Case "PERFILES"
                LimpiarYCargarCLBsPerfiles()
                btnCopiar.Text = "Copiar" & vbCrLf & "Perfiles"
                LayoutControlItem1.CustomizationFormText = "Perfiles a copiar"
                GroupControl1.Text = "Copiar Perfiles"
                LayoutControlItem1.Text = "Copiar Perfiles"
                lblTexto.Text = "Seleccione los perfiles a copiar y los usuarios de destino y pulse en Copiar Perfiles"
            Case "FILTROS"
                LimpiarYCargarCLBsFiltros()
                btnCopiar.Text = "Copiar" & vbCrLf & "Filtros"
                LayoutControlItem1.CustomizationFormText = "Filtros a copiar"
                GroupControl1.Text = "Copiar Filtros"
                LayoutControlItem1.Text = "Copiar Filtros"
                lblTexto.Text = "Seleccione los filtros a copiar y los usuarios de destino y pulse en Copiar Filtros"
        End Select
    End Sub

    Private Sub LimpiarYCargarCLBsPerfiles()

        Dim bd1 As New BaseDatos(1)
        Dim dtr As Object
        Dim sql As String

        clbUsuarios.Items.Clear()
        sql = "SELECT ' TODOS' AS Usuario UNION ALL SELECT Usuario FROM Usuarios"
        dtr = bd1.ExecuteReader(sql)
        While dtr.Read
            clbUsuarios.Items.Add(dtr("Usuario"))
        End While
        dtr.Close()

        bd1.CerrarBD()
        Try
            clbPerfiles.Items.Clear()
            Dim Directorio As String = RutaPerfiles
            If System.IO.Directory.Exists(Directorio) Then
                'Filtramos el tipo de archivos que queremos añadir al combo
                clbPerfiles.Items.Add(" TODOS")
                Dim DirFiles() As String = IO.Directory.GetFiles(Directorio, "*.xml")
                'Borramos los ítems para no añadir repetidos al recargarlo

                For x As Integer = 0 To DirFiles.Length - 1
                    'Añadir al combo
                    If DirFiles(x).Substring(Directorio.Length + 1, DirFiles(x).Length - Directorio.Length - 5) <> "InformacionPerfiles" Then
                        clbPerfiles.Items.Add(DirFiles(x).Substring(Directorio.Length + 1, DirFiles(x).Length - Directorio.Length - 5))
                    End If

                Next
                '  clbusuarios.Sorted = True
            End If
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Private Sub LimpiarYCargarCLBsFiltros()

        Dim bd1 As New BaseDatos(1)
        Dim dtr As Object
        Dim sql As String

        clbUsuarios.Items.Clear()
        sql = "SELECT ' TODOS' AS Usuario UNION ALL SELECT Usuario FROM Usuarios"
        dtr = bd1.ExecuteReader(sql)
        While dtr.Read
            clbUsuarios.Items.Add(dtr("Usuario"))
        End While
        dtr.Close()
        bd1.CerrarBD()

        Try
            clbPerfiles.Items.Clear()
            Dim Fichero As String = RutaFiltros & "\InformacionFiltros.xml"
            If System.IO.File.Exists(Fichero) Then
                'Filtramos el tipo de archivos que queremos añadir al combo
                clbPerfiles.Items.Add(" TODOS")

                Dim ds As New DataSet
                Dim dt As New DataTable
                ds.ReadXmlSchema(Fichero)
                ds.ReadXml(Fichero)
                dt = ds.Tables("Info")
                For Each drr As DataRow In dt.Rows
                    clbPerfiles.Items.Add(drr("Nombre"))
                Next

                clbPerfiles.SortOrder = Windows.Forms.SortOrder.Ascending

               
            End If
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub


    Private Sub btnCopiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopiar.Click
        Select Case p_Tipo.ToUpper
            Case "PERFILES"
                CopiarPerfiles()
            Case "FILTROS"
                CopiarFiltros()

        End Select
    End Sub


    Private Sub CopiarPerfiles()

        If clbPerfiles.CheckedItems.Count = 0 Then
            MensajeError("No ha seleccionado ningún perfil para copiar.")
            Exit Sub
        End If
        If clbUsuarios.CheckedItems.Count = 0 Then
            MensajeError("No ha seleccionado ningún usuario de destino.")
            Exit Sub
        End If

        Dim CarpetaPerfilesOrigen As String = ""
        Dim CarpetaPerfilesDestino As String = ""
        Dim bdBuscaUsuario As New BaseDatos(1)

        CarpetaPerfilesOrigen = RutaPerfiles

        For i = 0 To clbUsuarios.CheckedItems.Count - 1

            If clbUsuarios.CheckedItems(i) <> " TODOS" Then
                Dim CodigoUsu As String = bdBuscaUsuario.Execute("SELECT Contador FROM Usuarios WHERE Usuario = '" & clbUsuarios.CheckedItems(i) & "'", False)
                ' CarpetaPerfilesDestino = clVariables.RutaServidor & "\PERFILES\PERFILES_" & CodigoUsu.ToString.PadLeft(5, "0") & "/" & lbldgvxABuscar.Text
                ' FuncionesGenerales.Funciones.ComprobarYCrearCarpetas(CarpetaPerfilesDestino)

                CarpetaPerfilesDestino = Replace(RutaPerfiles, "PERFILES_" & GL_Usuario, "PERFILES_" & clbUsuarios.CheckedItems(i))

                'Dim Directorio As String = GL_CARPETA_PERFILES & "/" & lbldgvxABuscar.Text
                'Dim Ficheros() = System.IO.Directory.GetFiles(Directorio)

                For j = 0 To clbPerfiles.CheckedItems.Count - 1

                    Try
                        Funciones.ComprobarYCrearCarpetas(CarpetaPerfilesDestino)
                        If clbPerfiles.CheckedItems(j) <> " TODOS" And CarpetaPerfilesOrigen & "\" & clbPerfiles.CheckedItems(j) & ".xml" <> CarpetaPerfilesDestino & "\" & clbPerfiles.CheckedItems(j) & ".xml" Then
                            System.IO.File.Copy(CarpetaPerfilesOrigen & "\" & clbPerfiles.CheckedItems(j) & ".xml", CarpetaPerfilesDestino & "\" & clbPerfiles.CheckedItems(j) & ".xml", True)
                        End If

                    Catch ex As Exception
                        MensajeError(ex.Message)
                    End Try
                Next
            End If




        Next
         
       
                MensajeInformacion("Perfiles copiados correctamente.")
          

        Salir()


    End Sub
    
    Private Sub CopiarFiltros()

        If clbPerfiles.CheckedItems.Count = 0 Then
            MensajeError("No ha seleccionado ningún filtro para copiar.")
            Exit Sub
        End If
        If clbUsuarios.CheckedItems.Count = 0 Then
            MensajeError("No ha seleccionado ningún usuario de destino.")
            Exit Sub
        End If

        Dim FicheroFiltrosOrigen As String = ""
        Dim FicheroFiltrosDestino As String = ""
        Dim bdBuscaUsuario As New BaseDatos(1)
        Dim CarpetaFiltroDestino As String = ""

        FicheroFiltrosOrigen = RutaFiltros & "\InformacionFiltros.xml"

        '      CarpetaPerfilesOrigen = RutaPerfiles


        For i = 0 To clbUsuarios.CheckedItems.Count - 1

            If clbUsuarios.CheckedItems(i) <> " TODOS" And GL_Usuario <> clbUsuarios.CheckedItems(i) Then
                Dim CodigoUsu As String = bdBuscaUsuario.Execute("SELECT Contador FROM Usuarios WHERE Usuario = '" & clbUsuarios.CheckedItems(i) & "'", False)
                ' CarpetaPerfilesDestino = clVariables.RutaServidor & "\PERFILES\PERFILES_" & CodigoUsu.ToString.PadLeft(5, "0") & "/" & lbldgvxABuscar.Text
                ' FuncionesGenerales.Funciones.ComprobarYCrearCarpetas(CarpetaPerfilesDestino)

                CarpetaFiltroDestino = Replace(RutaFiltros, "PERFILES_" & GL_Usuario, "PERFILES_" & clbUsuarios.CheckedItems(i))

                FicheroFiltrosDestino = CarpetaFiltroDestino & "\InformacionFiltros.xml"

                If Not System.IO.File.Exists(FicheroFiltrosDestino) Then
                    Funciones.ComprobarYCrearCarpetas(CarpetaFiltroDestino)
                    System.IO.File.Copy(clVariables.RutaServidor & "\InformacionFiltros.xml", FicheroFiltrosDestino)
                End If

                'Dim Directorio As String = GL_CARPETA_PERFILES & "/" & lbldgvxABuscar.Text
                'Dim Ficheros() = System.IO.Directory.GetFiles(Directorio)

                For j = 0 To clbPerfiles.CheckedItems.Count - 1
                    If clbPerfiles.CheckedItems(j) <> " TODOS" Then
                        Try
                            Dim NombreFiltro As String = clbPerfiles.CheckedItems(j)
                            Dim TipoFiltro As String = ""
                            Dim Filtro As String = ""

                            Dim dsOrigen As New DataSet
                            Dim dtOrigen As New DataTable
                            dsOrigen.ReadXmlSchema(FicheroFiltrosOrigen)
                            dsOrigen.ReadXml(FicheroFiltrosOrigen)
                            dtOrigen = dsOrigen.Tables("Info")
                            For Each drOrigen As DataRow In dtOrigen.Rows
                                If drOrigen("Nombre") = NombreFiltro Then
                                    TipoFiltro = drOrigen("Tipo")
                                    Filtro = drOrigen("Filtro")
                                    Exit For
                                End If
                            Next

                            If Filtro <> "" Then
                                Dim dtDestino As New DataTable
                                Dim dsDestino As New DataSet
                                Dim Actualizado As Boolean = False

                                dsDestino.ReadXmlSchema(FicheroFiltrosDestino)
                                dsDestino.ReadXml(FicheroFiltrosDestino)
                                dtDestino = dsDestino.Tables("Info")
                                For Each drDestino As DataRow In dtDestino.Rows
                                    If drDestino("Nombre") = NombreFiltro Then
                                        drDestino.BeginEdit()
                                        drDestino("Tipo") = TipoFiltro
                                        drDestino("Filtro") = Filtro
                                        drDestino.EndEdit()
                                        Actualizado = True
                                        dtDestino.AcceptChanges()
                                        dtDestino.WriteXml(FicheroFiltrosDestino, XmlWriteMode.WriteSchema)
                                        dtDestino = Nothing
                                    End If
                                Next

                                If Not Actualizado Then

                                    'Añadimos
                                    dsDestino = New DataSet
                                    dtDestino = New DataTable

                                    dsDestino.ReadXmlSchema(FicheroFiltrosDestino)
                                    dsDestino.ReadXml(FicheroFiltrosDestino)
                                    dtDestino = dsDestino.Tables("Info")
                                    Dim dr As DataRow
                                    dr = dtDestino.NewRow
                                    dr("Nombre") = NombreFiltro
                                    dr("Tipo") = TipoFiltro
                                    dr("Filtro") = Filtro
                                    dtDestino.Rows.Add(dr)
                                    dsDestino.AcceptChanges()
                                    dsDestino.WriteXml(FicheroFiltrosDestino, XmlWriteMode.WriteSchema)


                                End If




                            End If




                        Catch ex As Exception
                            MensajeError(ex.Message)
                        End Try
                    End If





                Next
            End If




        Next



        MensajeInformacion("Filtros copiados correctamente.")
        Salir()


    End Sub

    Private Sub clbUsuarios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clbUsuarios.SelectedIndexChanged
        If clbUsuarios.SelectedIndex = 0 Then
            FuncionesGenerales.Funciones.ChequearDeschequearClb(clbUsuarios, clbUsuarios.GetItemChecked(0))
        End If
    End Sub

    Private Sub clbPerfiles_ItemCheck(sender As Object, e As DevExpress.XtraEditors.Controls.ItemCheckEventArgs) Handles clbPerfiles.ItemCheck
        If clbPerfiles.SelectedIndex = 0 Then
            FuncionesGenerales.Funciones.ChequearDeschequearClb(clbPerfiles, clbPerfiles.GetItemChecked(0))
        End If
    End Sub

    Private Sub clbUsuarios_ItemCheck(sender As Object, e As DevExpress.XtraEditors.Controls.ItemCheckEventArgs) Handles clbUsuarios.ItemCheck
        If clbUsuarios.SelectedIndex = 0 Then
            FuncionesGenerales.Funciones.ChequearDeschequearClb(clbUsuarios, clbUsuarios.GetItemChecked(0))
        End If
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Salir()
    End Sub
    Private Sub Salir()
        Me.ParentForm.Dispose()
    End Sub

    Private Function Tipo() As Object
        Throw New NotImplementedException
    End Function

    
End Class
