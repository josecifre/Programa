Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraBars.Ribbon.ViewInfo
Imports System.Drawing.Imaging
Imports DevExpress.XtraEditors
Imports System.Runtime.InteropServices
Imports System.IO
Imports WordPressPCL
Imports WordPressPCL.Models

Public Class ucImagenes

    Dim Referencia As String
    Dim CarpetaDocumento As String
    Dim CarpetaDocumentoPublicadas As String
    Dim ImagenesDe As String
    Private markedItems_Renamed As List(Of GalleryItem)
    Private firstmarkedItems_Renamed As List(Of GalleryItem)
    Private p_ContadorPropietario As String
    Private p_ContadorInmueble As Integer
    Private p_ReferenciaInmueble As String
    Private p_Baja As Boolean
    Dim Fichero As String
    Dim FicheroDestino As String
    Dim items As List(Of GalleryItem)
    Dim EnDisco As Boolean = True
    Dim Principal As String = ""
    Dim WP_IdProperty As Integer


    Private WithEvents BinSrc As BindingSource

    Public Property ContadorInmueble As Integer
        Get
            Return p_ContadorInmueble
        End Get
        Set(value As Integer)
            p_ContadorInmueble = value
        End Set
    End Property
    Public Property Baja As Boolean
        Get
            Return p_Baja
        End Get
        Set(value As Boolean)
            p_Baja = value
        End Set
    End Property
    Public Property ContadorPropietario As Integer
        Get
            Return p_ContadorPropietario
        End Get
        Set(value As Integer)
            p_ContadorPropietario = value
        End Set
    End Property
    Public Property ReferenciaInmueble As String
        Get
            Return p_ReferenciaInmueble
        End Get
        Set(ByVal value As String)
            p_ReferenciaInmueble = value
        End Set
    End Property
    Protected ReadOnly Property MarkedItems() As List(Of GalleryItem)
        Get
            If markedItems_Renamed Is Nothing Then
                markedItems_Renamed = New List(Of GalleryItem)()
            End If
            Return markedItems_Renamed
        End Get
    End Property
    Protected ReadOnly Property firstMarkedItems() As List(Of GalleryItem)
        Get
            If firstmarkedItems_Renamed Is Nothing Then
                firstmarkedItems_Renamed = New List(Of GalleryItem)()
            End If
            Return firstmarkedItems_Renamed
        End Get
    End Property

    Sub New(ByVal contadorPropietarioPasado As Integer, ByVal referenciaInmueblePasado As String, ByVal contadorInmueblePasado As Integer, ByVal BajaPasado As Boolean, ByVal ID_WP_Pasado As Integer)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        ReferenciaInmueble = referenciaInmueblePasado
        ContadorPropietario = contadorPropietarioPasado
        ContadorInmueble = contadorInmueblePasado
        WP_IdProperty = ID_WP_Pasado
        Baja = BajaPasado

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub ucImagenes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        AparienciaGeneral()


        AddHandler Me.KeyDown, AddressOf HandleKeyPress
        AddHandler gc.KeyDown, AddressOf HandleKeyPress
        AddHandler gcWeb.KeyDown, AddressOf HandleKeyPress
        'AddHandler imageSlider.KeyDown, AddressOf HandleKeyPress

        gc.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside
        gc.Gallery.ImageSize = New Size(120, 90)
        gc.Gallery.HoverImageSize = New Size(130, 100)
        gc.Gallery.ItemCheckMode = Gallery.ItemCheckMode.Multiple
        gc.Gallery.AllowHoverImages = False
        gc.Gallery.ShowItemText = True
        gcWeb.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside
        gcWeb.Gallery.ImageSize = New Size(120, 90)
        gcWeb.Gallery.HoverImageSize = New Size(130, 100)
        gcWeb.Gallery.ItemCheckMode = Gallery.ItemCheckMode.Multiple
        gcWeb.Gallery.AllowHoverImages = False
        gcWeb.Gallery.ShowItemText = True
        'imageSlider.AllowLooping = True

        Referencia = ReferenciaInmueble
        ImagenesDe = ContadorPropietario
        btnPublicar.Enabled = True
        btnEscaparate.Enabled = True
        If Baja Then
            btnPublicar.Enabled = False
            btnEscaparate.Enabled = False
        End If

        'JCB CARPETA FOTOS
        CarpetaDocumento = GL_CarpetaFotos & "/" & Referencia
        CarpetaDocumentoPublicadas = CarpetaDocumento & "\actualizarweb"

        'If DatosEmpresa.WordPress Then
        '    Dim Sel As String
        '    Sel = "SELECT Id_WP FROM Inmuebles WHERE Contador = " & ContadorInmueble
        '    WP_IdProperty = BD_CERO.Execute(Sel, False, 0)
        'End If



        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        CargarFotos()
        CargarPrincipal()

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Arrow

    End Sub

    Private Sub HandleKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        'If e.KeyCode = Keys.Right Then
        '    Try
        '        imageSlider.SlideNext()
        '    Catch ex As Exception

        '    End Try
        'End If

        'If e.KeyCode = Keys.Left Then
        '    Try
        '        imageSlider.SlidePrev()
        '    Catch ex As Exception

        '    End Try
        'End If

        If e.KeyCode = Keys.Delete Then
            BorrarFotos()
        End If
        If e.KeyCode = Keys.Escape Then
            Salir()
        End If

    End Sub
    Private Sub CargarPrincipal()


        Dim Sel As String = "SELECT FotoPrincipal FROM Inmuebles WHERE Contador =" & ContadorInmueble
        Dim bd As New BaseDatos
        Principal = bd.Execute(Sel, False)
        If Principal = "" Then
            Try
                Principal = gc.Gallery.GetAllItems.Item(0).Caption
            Catch
            End Try
        End If
        MarcarPrincipal()
    End Sub
    Private Sub MarcarPrincipal()
        Dim items As List(Of GalleryItem) = gc.Gallery.GetAllItems
        If items.Count > 0 Then
            items.Clear()
            For Each item As GalleryItem In gc.Gallery.GetAllItems
                If item.Caption = Principal Then
                    items.Add(item)
                    firstMarkItems(items)
                    Return
                End If
            Next
        End If
        items = gcWeb.Gallery.GetAllItems
        If items.Count = 0 Then Return
        items.Clear()
        For Each item As GalleryItem In gcWeb.Gallery.GetAllItems
            If item.Caption = Principal Then
                items.Add(item)
                firstMarkItems(items)
                Return
            End If
        Next
        Principal = gc.Gallery.GetAllItems.Item(0).Caption
        MarcarPrincipal()
    End Sub

    Public Sub CargarFotos()

        'imageSlider.Images.Clear()
        'With gc.Gallery.Groups
        gc.Gallery.Groups.Item(0).Caption = "Imágenes en disco (0)"
        gcWeb.Gallery.Groups.Item(0).Caption = "Imágenes publicadas (0)"
        gc.Gallery.Groups.Item(0).Items.Clear()
        gcWeb.Gallery.Groups.Item(0).Items.Clear()
        If Not System.IO.Directory.Exists(CarpetaDocumento) Then
            Exit Sub
        End If
        Dim DirFiles() As String = System.IO.Directory.GetFiles(CarpetaDocumento, "*.*")
        If DirFiles.Length > 0 Then
            For i = 0 To DirFiles.Length - 1
                Try

                    Fichero = My.Computer.FileSystem.GetName(DirFiles(i))
                    Dim img As Image = Funciones.redimensionaimagen(Image.FromStream(New IO.MemoryStream(IO.File.ReadAllBytes(DirFiles(i)))), 1600, 1000, False)
                    Dim img2 As Image
                    If DatosEmpresa.WordPress Then
                        img2 = Funciones.redimensionaimagen(Image.FromStream(New IO.MemoryStream(IO.File.ReadAllBytes(DirFiles(i)))), 270, 150, False)
                    Else
                        img2 = Funciones.redimensionaimagen(Image.FromStream(New IO.MemoryStream(IO.File.ReadAllBytes(DirFiles(i)))), 130, 100, False)
                    End If
                    gc.Gallery.Groups.Item(0).Items.Add(New GalleryItem(img2, Nothing, Fichero, "", i, i, DirFiles(i), ""))
                    'If EnDisco Then
                    '    imageSlider.Images.Add(img)
                    'End If




                Catch ex As Exception
                    FuncionesGenerales.Funciones.EscribeLog("CargarFotos " & ex.Message)

                End Try
                ' If i Mod 5 = 0 Then
                ' LiberarMemoria()
                ' End If
            Next
            gc.Gallery.Groups.Item(0).Caption = "Imágenes en disco (" & DirFiles.Length & ")"
        End If
        If Not System.IO.Directory.Exists(CarpetaDocumentoPublicadas) Then
            Exit Sub
        End If
        Dim DirFilesPublicadas() As String = System.IO.Directory.GetFiles(CarpetaDocumentoPublicadas, "*.*")
        If DirFilesPublicadas.Length > 0 Then
            For i = 0 To DirFilesPublicadas.Length - 1
                Try

                    Fichero = My.Computer.FileSystem.GetName(DirFilesPublicadas(i))

                    Dim img2 As Image

                    If DatosEmpresa.WordPress Then
                        img2 = Funciones.redimensionaimagen(Image.FromStream(New IO.MemoryStream(IO.File.ReadAllBytes(DirFilesPublicadas(i)))), 270, 150, False)
                    Else
                        img2 = Funciones.redimensionaimagen(Image.FromStream(New IO.MemoryStream(IO.File.ReadAllBytes(DirFilesPublicadas(i)))), 130, 100, False)
                    End If
                    'Dim img As Image = Funciones.redimensionaimagen(Image.FromStream(New IO.MemoryStream(IO.File.ReadAllBytes(DirFilesPublicadas(i)))), 1600, 1000, False)

                    gcWeb.Gallery.Groups.Item(0).Items.Add(New GalleryItem(img2, Nothing, Fichero, "", i, i, DirFilesPublicadas(i), ""))
                    'If Not EnDisco Then
                    '    imageSlider.Images.Add(img)
                    'End If


                Catch ex As Exception
                    FuncionesGenerales.Funciones.EscribeLog("CargarFotosPublicadas " & ex.Message)
                End Try
            Next
            gcWeb.Gallery.Groups.Item(0).Caption = "Imágenes publicadas (" & DirFilesPublicadas.Length & ")"
        End If
        'End With
        'imageSlider.Refresh() 'TODO
        MarcarPrincipal()
        LiberarMemoria()

    End Sub

    Private Function CreateAlbumGroup() As GalleryItemGroup
        Dim group As New GalleryItemGroup()
        'group.Tag = albumData
        'group.Caption = albumData.Name
        group.CaptionAlignment = GalleryItemGroupCaptionAlignment.Stretch
        group.CaptionControl = CreateAlbumGroupCaptionControl()
        Return group
    End Function
    Private Function CreateAlbumGroupCaptionControl() As System.Windows.Forms.Control
        '    Private Function CreateAlbumGroupCaptionControl(ByVal albumData As AlbumData) As Control
        Dim control As New AlbumGroupCaptionControl()
        '  control.Album = albumData
        ' control.MainForm = Me
        Return control
    End Function

    Private Sub btnAnadir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnadir.Click

        Dim ConfiguracionMarcaAgua As MarcaAgua.clConfiguracionMarcaAgua

        Dim dtr As Object
        Dim bdim As New BaseDatos
        Dim Sel As String = "SELECT * FROM ConfiguracionMarcaAgua"
        dtr = bdim.ExecuteReader(Sel)
        If dtr.hasrows Then
            ConfiguracionMarcaAgua = New MarcaAgua.clConfiguracionMarcaAgua
            dtr.read()


            ConfiguracionMarcaAgua.Posicion = dtr("Posicion")
            ConfiguracionMarcaAgua.TextoAMostrar = dtr("TextoAMostrar")
            ConfiguracionMarcaAgua.RutaImagen = clVariables.RutaServidor & "\Logos\MarcaAgua\" & DatosEmpresa.Codigo & "." & dtr("ExtensionLogo")


            If ConfiguracionMarcaAgua.TextoAMostrar.Trim = "" Then
                ConfiguracionMarcaAgua.MostrarTexto = False
            Else
                ConfiguracionMarcaAgua.MostrarTexto = dtr("MostrarTexto")
            End If



            If Not System.IO.File.Exists(ConfiguracionMarcaAgua.RutaImagen) Then
                ConfiguracionMarcaAgua.MostrarImagen = False
            Else
                ConfiguracionMarcaAgua.MostrarImagen = dtr("MostrarImagen")
            End If

            Try
                ConfiguracionMarcaAgua.Transparencia = dtr("Transparencia")
            Catch ex As Exception
                ConfiguracionMarcaAgua.Transparencia = 0
            End Try

            Try
                ConfiguracionMarcaAgua.RelacionAncho = dtr("RelacionAncho")
            Catch ex As Exception
                ConfiguracionMarcaAgua.RelacionAncho = 0
            End Try
            Try
                ConfiguracionMarcaAgua.RelacionAlto = dtr("RelacionAlto")
            Catch ex As Exception
                ConfiguracionMarcaAgua.RelacionAlto = 0
            End Try

        Else
            ConfiguracionMarcaAgua = Nothing
        End If
        dtr.close()
        bdim.CerrarBD()
        InsertarDocumento(CarpetaDocumento, EnumFiltro.JPG, True, , , ConfiguracionMarcaAgua)
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        CargarFotos()

        MarcarPrincipal()
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub

    'Private Sub GalleryControlGallery1_ItemDoubleClick(sender As System.Object, e As DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs) Handles GC.Gallery.ItemDoubleClick
    '    Diagnostics.Process.Start(e.Item.Tag)
    'End Sub

    Private Sub GalleryControlGallery1_ItemDoubleClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs) Handles gc.Gallery.ItemDoubleClick, gcWeb.Gallery.ItemDoubleClick
        Try
            Diagnostics.Process.Start("rundll32.exe %SystemRoot%\system32\shimgvw.dll,ImageView_Fullscreen " & e.Item.Tag)
        Catch ex As Exception
            Diagnostics.Process.Start(e.Item.Tag)
        End Try

    End Sub

    Private Function GetCheckedImages() As List(Of Image)
        items = gc.Gallery.GetCheckedItems()
        items.AddRange(gcWeb.Gallery.GetCheckedItems())
        Dim images As List(Of Image) = New List(Of Image)(items.Count)
        For Each item As GalleryItem In items
            'images.Add(Image.FromFile(CStr(item.Tag)))
            Dim img As Image = Image.FromStream(New IO.MemoryStream(IO.File.ReadAllBytes(CStr(item.Tag))))
            images.Add(img)
        Next item
        Return images
    End Function
    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        If gc.Gallery.GetCheckedItems().Count + gcWeb.Gallery.GetCheckedItems().Count = 0 Then
            XtraMessageBox.Show("Elige alguna", "Atención", MessageBoxButtons.OK)
            Exit Sub
        End If
        Dim images As List(Of Image) = GetCheckedImages()
        Dim ps As New PrintingSystem()

        ps.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A5
        ps.PageSettings.Landscape = True
        ps.PageSettings.LeftMargin = 0
        ps.PageSettings.RightMargin = 0
        ps.PageSettings.TopMargin = 0
        ps.PageSettings.BottomMargin = 0

        Dim gr As BrickGraphics = ps.Graph
        ps.Begin()


        Dim offsetY As Single = 0
        For Each image As Image In images
            Dim imageBrick As New ImageBrick()
            imageBrick.Image = image
            imageBrick.BorderWidth = 0
            imageBrick.BorderStyle = BrickBorderStyle.Inset
            imageBrick.Sides = BorderSide.All

            imageBrick.SizeMode = ImageSizeMode.Squeeze
            gr.DrawBrick(imageBrick, New RectangleF(New PointF(0, offsetY), ps.PageSettings.UsablePageSizeInPixels))
            offsetY += ps.PageSettings.UsablePageSizeInPixels.Height
        Next image
        ps.End()

        CType(New PrintTool(ps), PrintTool).ShowPreviewDialog()
    End Sub

    Private Sub GalleryControlGallery1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs) Handles gc.Gallery.ItemClick, gcWeb.Gallery.ItemClick

        If e.Item.GalleryGroup.Caption.Contains("disco") Then
            If Not EnDisco Then
                EnDisco = True
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                CargarFotos()
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Arrow
            End If
        Else
            If EnDisco Then
                EnDisco = False
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                CargarFotos()
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Arrow
            End If
        End If
        Dim items As List(Of GalleryItem) = gc.Gallery.GetCheckedItems()
        items.AddRange(gcWeb.Gallery.GetCheckedItems())
        MarkItems(items)
        gc.Refresh()
    End Sub
    Private Sub MarkItems(ByVal items As List(Of GalleryItem))
        For Each item As GalleryItem In gc.Gallery.GetAllItems
            If items.Contains(item) And Not MarkedItems.Contains(item) Then
                MarkedItems.Add(item)
            End If
            If MarkedItems.Contains(item) And Not items.Contains(item) Then
                MarkedItems.Remove(item)
            End If
        Next
        For Each item As GalleryItem In gcWeb.Gallery.GetAllItems
            If items.Contains(item) And Not MarkedItems.Contains(item) Then
                MarkedItems.Add(item)
            End If
            If MarkedItems.Contains(item) And Not items.Contains(item) Then
                MarkedItems.Remove(item)
            End If
        Next
    End Sub
    Private Sub firstMarkItems(ByVal items As List(Of GalleryItem))
        If Not firstMarkedItems.Contains(items.Item(0)) Then
            firstMarkedItems.Clear()
            firstMarkedItems.Add(items.Item(0))
            Principal = items.Item(0).Caption
        End If
    End Sub

    Private Function InflateClip(ByVal cache As GraphicsCache) As RectangleF
        Dim clipBounds As RectangleF = cache.Graphics.ClipBounds
        Dim rect As RectangleF = cache.Graphics.ClipBounds
        rect.Inflate(50, 50)
        cache.Graphics.SetClip(rect)
        Return clipBounds
    End Function
    Private Sub DrawMarkedIcon(ByVal cache As GraphicsCache, ByVal bounds As Rectangle)
        Dim oldClipBounds As RectangleF = InflateClip(cache)
        cache.Graphics.DrawImage(My.Resources.ItemMarked_32x32, New Rectangle(bounds.Right - 26, bounds.Bottom - 26, 32, 32))
        cache.Graphics.SetClip(oldClipBounds)
    End Sub
    Private Sub firstDrawMarkedIcon(ByVal cache As GraphicsCache, ByVal bounds As Rectangle)
        Dim oldClipBounds As RectangleF = InflateClip(cache)
        cache.Graphics.DrawImage(My.Resources.First, New Rectangle(bounds.Left + 6, bounds.Bottom - 26, 32, 32))
        cache.Graphics.SetClip(oldClipBounds)
    End Sub
    Private Sub OnMainGalleryCustomDrawItemImage(ByVal sender As Object, ByVal e As GalleryItemCustomDrawEventArgs) Handles gc.Gallery.CustomDrawItemImage, gcWeb.Gallery.CustomDrawItemImage
        e.Cache.Graphics.DrawImage(e.Item.Image, (CType(e.ItemInfo, GalleryItemViewInfo)).ImageContentBounds)
        If (MarkedItems.Contains(e.Item)) Then
            DrawMarkedIcon(e.Cache, (CType(e.ItemInfo, GalleryItemViewInfo)).ImageContentBounds)
            e.Handled = True
        End If
        If (firstMarkedItems.Contains(e.Item)) Then
            firstDrawMarkedIcon(e.Cache, (CType(e.ItemInfo, GalleryItemViewInfo)).ImageContentBounds)
            e.Handled = True
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        GuardarFotos()
        Salir()
    End Sub
    Private Sub Salir()
        Me.ParentForm.Dispose()
        LiberarMemoria()
    End Sub
    Private Sub GuardarFotos()
        GL_FotosPc = 0
        If System.IO.Directory.Exists(CarpetaDocumento) Then
            Dim DirFiles0() As String = System.IO.Directory.GetFiles(CarpetaDocumento, "*.*")
            GL_FotosPc = DirFiles0.Length
        End If
        'JCB
        GL_FotosWeb = 0
        If System.IO.Directory.Exists(CarpetaDocumentoPublicadas) Then
            Dim DirFiles1() As String = System.IO.Directory.GetFiles(CarpetaDocumentoPublicadas, "*.*")
            GL_FotosWeb = DirFiles1.Length
        End If

        GL_FotoPrincipal = Principal
        Dim Sel As String = "UPDATE Inmuebles SET FotosPc=" & GL_FotosPc & ",FotosWeb=" & GL_FotosWeb & ",FotoPrincipal='" & GL_FotoPrincipal & "' WHERE Contador =" & ContadorInmueble
        Dim bd As New BaseDatos
        bd.Execute(Sel)




        If DatosEmpresa.WordPress Then

            Dim Id_WP_Id__Foto As Integer



            Sel = "SELECT IdFoto FROM WP_FOTOS WHERE IdProperty = " & WP_IdProperty & " And Fichero = '" & Funciones.pf_ReplaceComillas(GL_FotoPrincipal) & " '"
            Id_WP_Id__Foto = BD_CERO.Execute(Sel, False)

            If Id_WP_Id__Foto <> 0 Then

                Dim postData As String
                postData = SerializarPost(Id_WP_Id__Foto, "featured_media")
                WordPressPost(GL_ConfiguracionWeb.API_WP_Funcion_Propiedades & "/" & WP_IdProperty, postData)

                Sel = "UPDATE WP_FOTOS SET Principal = 0,AsignadoAWeb = 0 WHERE IdProperty = " & WP_IdProperty & " AND IdFoto <> " & Id_WP_Id__Foto
                BD_CERO.Execute(Sel)

                Sel = "UPDATE WP_FOTOS SET Principal = 1,AsignadoAWeb = 1 WHERE IdProperty = " & WP_IdProperty & " AND IdFoto = " & Id_WP_Id__Foto
                BD_CERO.Execute(Sel)

            End If


            WPActualizarREAL_HOMES_property_images(WP_IdProperty)





        Else
            FuncionesBD.Accion("UPDATE", "Inmuebles", uInmueblesActivo.BinSrc.Current("Referencia"), False, FotoPrincipal:=True, Valor:=GL_FotoPrincipal) '"(SELECT Referencia FROM Inmuebles WHERE CONTADOR=" & ContadorInmueble & ")", False)
        End If

    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        BorrarFotos()
        MarcarPrincipal()
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub
    Public Sub BorrarFotos()
        If gc.Gallery.GetCheckedItems().Count + gcWeb.Gallery.GetCheckedItems().Count = 0 Then
            XtraMessageBox.Show("Elige alguna", "Atención", MessageBoxButtons.OK)
            Exit Sub
        End If
        If XtraMessageBox.Show("¿Confirma que quiere eliminar las fotos seleccionadas?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
            Exit Sub
        End If
        Dim carpeta As String = ""

        Dim BorroPublicada As Boolean = False

        For Each item As GalleryItem In MarkedItems
            If item.GalleryGroup IsNot Nothing Then


                Dim FicheroAEliminar As String = item.Caption

                Dim EstaPublicada As Boolean = False
                If System.IO.File.Exists(CarpetaDocumentoPublicadas & "\" & FicheroAEliminar) Then
                    EstaPublicada = True
                    BorroPublicada = True
                End If

                If item.GalleryGroup.Caption.Contains("disco") Then
                    carpeta = CarpetaDocumento
                Else
                    carpeta = CarpetaDocumentoPublicadas
                End If
                If System.IO.File.Exists(carpeta & "\" & FicheroAEliminar) Then
                    Try
                        System.IO.File.Delete(carpeta & "\" & FicheroAEliminar)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                        Exit Sub
                    End Try
                End If
                If carpeta <> CarpetaDocumentoPublicadas Then
                    If System.IO.File.Exists(CarpetaDocumentoPublicadas & "\" & FicheroAEliminar) Then
                        Try
                            System.IO.File.Delete(CarpetaDocumentoPublicadas & "\" & FicheroAEliminar)
                        Catch ex As Exception
                            MsgBox(ex.Message)
                            Exit Sub
                        End Try
                    End If
                End If
                If EstaPublicada Then
                    If DatosEmpresa.WordPress Then
                        Dim Id_WP_Foto As Integer = ObtenerIdFoto_Desde_IdPropertyYFichero(WP_IdProperty, FicheroAEliminar)
                        If Id_WP_Foto <> 0 Then
                            WPEliminarFoto(Id_WP_Foto)
                        Else
                            Dim Sel As String
                            Sel = "DELETE FROM WP_Fotos WHERE ContadorInmueble = " & ContadorInmueble & " AND Fichero = '" & FicheroAEliminar & "' "
                            BD_CERO.Execute(Sel)
                        End If
                    Else

                    End If
                End If
            End If
        Next
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        CargarFotos()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Arrow

        If BorroPublicada AndAlso DatosEmpresa.WordPress Then
            'Actualiar realtimes propoerti
            WPActualizarREAL_HOMES_property_images(WP_IdProperty)
        End If

        If BorroPublicada AndAlso Not DatosEmpresa.WordPress Then
            upload()
        End If

    End Sub

    Private Sub btnPublicar_Click(sender As System.Object, e As System.EventArgs) Handles btnPublicar.Click

        If DatosEmpresa.WordPress AndAlso WP_IdProperty = 0 Then
            MensajeInformacion("No puede publicar fotos hasta que no publique el inmueble")
            Return
        End If

        If gc.Gallery.GetCheckedItems().Count = 0 Then
            XtraMessageBox.Show("Elija alguna foto", "Atención", MessageBoxButtons.OK)
            Exit Sub
        End If
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        If publicar() Then
            upload()
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub
    Private Function publicar() As Boolean
        Dim DirFiles() As String = Nothing
        If System.IO.Directory.Exists(CarpetaDocumento) Then
            DirFiles = System.IO.Directory.GetFiles(CarpetaDocumento, "*.*")
        End If
        Try
            If MarkedItems.Count = 0 Then
                MensajeInformacion("Marque las fotos que desee publicar.")
                Return False
            End If
            If DirFiles.Length > 0 Then
                For Each item As GalleryItem In MarkedItems
                    If item.GalleryGroup IsNot Nothing Then
                        If item.GalleryGroup.Caption.Contains("disco") Then
                            For i = 0 To DirFiles.Length - 1

                                If My.Computer.FileSystem.GetName(DirFiles(i)) = item.Caption Then
                                    Fichero = My.Computer.FileSystem.GetName(DirFiles(i))

                                    Exit For
                                End If


                                'If DirFiles(i).Contains(item.Caption) Then
                                '    Fichero = My.Computer.FileSystem.GetName(DirFiles(i))

                                '    Exit For
                                'End If
                            Next
                            'Fichero = My.Computer.FileSystem.GetName(DirFiles(i))
                            FicheroDestino = CarpetaDocumentoPublicadas & "\" & Fichero
                            If item.Caption = Fichero Then
                                FuncionesGenerales.Funciones.ComprobarYCrearCarpetas(CarpetaDocumentoPublicadas)

                                Dim img As Image = Image.FromStream(New IO.MemoryStream(IO.File.ReadAllBytes(CarpetaDocumento & "\" & Fichero))) 'item.Image
                                If DatosEmpresa.WordPress Then

                                    SaveJPGWithCompressionSetting(Funciones.redimensionaimagen(img, 850, 426, , False), FicheroDestino, 90)
                                Else
                                    SaveJPGWithCompressionSetting(Funciones.redimensionaimagen(img, 640, 480), FicheroDestino, 70)
                                End If


                            End If

                        End If
                    End If
                Next
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Arrow
        CargarFotos()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Return True
    End Function
    Public Shared Sub SaveJPGWithCompressionSetting(ByVal image As Image, ByVal szFileName As String, ByVal lCompression As Long)


        Dim eps As EncoderParameters = New EncoderParameters(1)
        eps.Param(0) = New EncoderParameter(Encoder.Quality, lCompression)

        Dim ici As ImageCodecInfo = GetEncoderInfo("image/jpeg")
        Try
            ''comento eso
            'MsgBox("redim 13")

            'image.Save(szFileName, ici, eps)
            'MsgBox("redim 14")



            'y añado esto.
            Dim ms As New MemoryStream()
            image.Save(ms, ici, eps)
            ms.Seek(0, SeekOrigin.Begin)
            Dim file As New FileStream(szFileName, FileMode.Create, FileAccess.Write)
            ms.WriteTo(file)
            file.Close()
            ms.Close()
            image.Dispose()




        Catch exc As Exception
            MessageBox.Show(exc, " Atención !", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Shared Function GetEncoderInfo(ByVal mimeType As String) As ImageCodecInfo
        Dim encoders As ImageCodecInfo() = ImageCodecInfo.GetImageEncoders()
        For i = 0 To encoders.Length
            If encoders(i).MimeType = mimeType Then
                Return encoders(i)
            End If
        Next
        Return Nothing
        'CodecName           FilenameExtension        FormatDescription MimeType 
        'Built-in BMP Codec  .BMP;*.DIB;*.RLE         BMP               image/bmp 
        'Built-in JPEG Codec .JPG;*.JPEG;*.JPE;*.JFIF JPEG              image/jpeg 
        'Built-in GIF Codec  *.GIF                    GIF               image/gif 
        'Built-in TIFF Codec *.TIF;*.TIFF             TIFF              image/tiff 
        'Built-in PNG Codec  *.PNG                    PNG               image/png 
    End Function

    Private Sub upload()

        If DatosEmpresa.WordPress Then
            WPSubirCarpeta(CarpetaDocumentoPublicadas, "jpg")
        Else
            Dim ftp As New tb_FTP
            'Dim Http = "httpdocs/roberto" 'carpeta de la web
            Dim Http As String = GL_ConfiguracionWeb.DirectorioFotos & "/" & ReferenciaInmueble
            ftp.FTPBorrarFicherosCarpeta(Http, "jpg")
            Dim Res As String = ftp.FTPSubirCarpeta(Http, CarpetaDocumentoPublicadas, "jpg")
            If Res <> "" Then
                MensajeError(Res)
            Else
                MensajeInformacion("Cambios publicados correctamente")
            End If
        End If




    End Sub
    Public Async Function WPSubirCarpeta(ByVal CarpetaOrigen As String, Optional ByVal Extension As String = "") As Threading.Tasks.Task(Of String)


        Dim pf As New ProgressForm
        Try

            'FTPComprobaryCrearDirectorio(CarpetaFTP)



            Dim Archivos() As String
            Dim Archivo As String
            Dim Total As Integer

            Archivos = System.IO.Directory.GetFiles(CarpetaOrigen, IIf(Extension <> "", "*." & Extension, ""))
            Total = Archivos.Length


            pf.ProgressControl.Maximum = Archivos.Count
            pf.ProgressControl.ProgressText = "Espere unos instantes ..."
            pf.StartPosition = FormStartPosition.Manual
            Dim P As Point
            P.X = (Screen.PrimaryScreen.WorkingArea.Width - pf.Width) / 2
            P.Y = (Screen.PrimaryScreen.WorkingArea.Height - pf.Height) / 2
            pf.Location = P
            pf.Visible = True
            pf.BringToFront()
            pf.Show()
            pf.BringToFront()
            pf.Refresh()



            Dim ListaArchivosEnBd As New List(Of String)
            Dim ListaArchivosEnCarpeta As New List(Of String)
            Dim ListaArchivosSubidos As New List(Of String)

            Dim ListaArchivosASubir As New List(Of String)
            Dim ListaArchivosABorrar As New List(Of String)




            Dim Sel As String
            Dim bdFotos As BaseDatos

            Sel = "SELECT Fichero FROM WP_Fotos WHERE ContadorInmueble = " & ContadorInmueble
            bdFotos = New BaseDatos
            bdFotos.LlenarDataSet(Sel, "T")

            For i = 0 To bdFotos.ds.Tables("T").Rows.Count - 1
                ListaArchivosEnBd.Add(bdFotos.ds.Tables("T").Rows(i)("Fichero"))
            Next



            For Each RutaCompleta In Archivos
                Dim Fichero As String
                Fichero = My.Computer.FileSystem.GetFileInfo(RutaCompleta).Name

                If ListaArchivosEnBd.Contains(Fichero) Then
                    ListaArchivosSubidos.Add(Fichero)
                Else
                    ListaArchivosASubir.Add(RutaCompleta)
                End If

                ListaArchivosEnCarpeta.Add(Fichero)
            Next


            For Each Fichero In ListaArchivosEnBd
                If Not ListaArchivosEnCarpeta.Contains(Fichero) Then
                    ListaArchivosABorrar.Add(CarpetaOrigen & "/" & Fichero)
                End If
            Next

            'Eliminamos la asociación de todas las imágenes con el inmueble
            'Dim postData As String
            'postData = SerializarPost("", "REAL_HOMES_property_images")
            'WordPressPost(GL_ConfiguracionWeb.API_WP_Funcion_Propiedades & "/" & WP_IdProperty, postData)

            For Each Archivo In ListaArchivosASubir
                pf.ProgressControl.Value += 1
                pf.Refresh()

                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 Or System.Net.SecurityProtocolType.Tls11 Or System.Net.SecurityProtocolType.Tls

                Dim ApiCredentials As New Tablas.ApiCredentials
                Dim client = New WordPressClient(ApiCredentials.WordPressUri)
                client.AuthMethod = AuthMethod.JWT
                Await client.RequestJWToken(ApiCredentials.Username, ApiCredentials.Password)
                Dim isValidToken = Await client.IsValidJWToken()


                Dim s As Stream = File.OpenRead(Archivo)
                Dim createdMedia = Await client.Media.Create(s, "media.jpg")


                GL_TokenWP = ObtenerTokenWP()




                Dim postData As String


                Dim Res As Tablas.clResultado
                Dim ResImagen As Tablas.cl_WP_Media
                Dim SourceURL As String = ""

                postData = SerializarPost(WP_IdProperty, "post")
                Res = WordPressPost("media/" & createdMedia.Id, postData, ,, False)

                If Res.Codigo = 0 Then
                    ResImagen = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Tablas.cl_WP_Media)(Res.Mensaje)
                    SourceURL = ResImagen.source_url

                Else


                    InsertarMovimientosWP(Referencia, "INSERTAR FOTO", Res.Codigo, "ERROR", Res.Mensaje)
                End If


                postData = SerializarPost(createdMedia.Id, "REAL_HOMES_property_images")
                WordPressPost(GL_ConfiguracionWeb.API_WP_Funcion_Propiedades & "/" & WP_IdProperty, postData, False)



                Sel = "INSERT INTO WP_FOTOS (IdFoto, IdProperty, ContadorInmueble,Fichero,Principal,SourceURL,AsignadoAWeb) VALUES ( " &
              createdMedia.Id &
              ", " & WP_IdProperty &
              ", " & ContadorInmueble &
              ", '" & My.Computer.FileSystem.GetName(Archivo) & "'" &
              ",0 " &
              ", '" & SourceURL & "'" &
              ",0" &
              ")"

                BD_CERO.Execute(Sel)


                InsertarMovimientosWP(Referencia, "INSERTAR FOTO", Res.Codigo, "", "Id Foto: " & createdMedia.Id)


                '   WPEnviarFoto(Archivo, WP_IdProperty, ContadorInmueble)


                'If Res <> "" Then
                '    '  MsgBox("Error subiendo las imagénes. " & vbCrLf & Res)
                '    Return "Error 2 subiendo las imagénes. " & vbCrLf & Res
                'End If
            Next


            For Each Archivo In ListaArchivosABorrar


                Dim ID_WP_Foto As Integer = ObtenerIdFoto_Desde_IdPropertyYFichero(WP_IdProperty, Archivo)
                WPEliminarFoto(ID_WP_Foto)


            Next

            'WPActualizarREAL_HOMES_property_images(WP_IdProperty)

            'Sel = "SELECT IdFoto FROM WP_Fotos WHERE ContadorInmueble = " & ContadorInmueble
            'bdFotos = New BaseDatos
            'bdFotos.LlenarDataSet(Sel, "T")

            'For i = 0 To bdFotos.ds.Tables("T").Rows.Count - 1
            '    postData = SerializarPost(bdFotos.ds.Tables("T").Rows(i)("IdFoto"), "REAL_HOMES_property_images")
            '    WordPressPost(GL_ConfiguracionWeb.API_WP_Funcion_Propiedades & "/" & WP_IdProperty, postData)


            'Next



            pf.Close()
        Catch ex As Exception
            pf.Close()


            Return "Error 3 subiendo las imagénes. " & vbCrLf & ex.Message

        End Try

        Return ""

    End Function


    Private Sub btnEscaparate_Click(sender As System.Object, e As System.EventArgs) Handles btnEscaparate.Click

        With frmEscaparate
            .ContadorInmueble = ContadorInmueble
            .ContadorPropietario = ContadorPropietario
            .ReferenciaInmueble = ReferenciaInmueble
            .ShowDialog()
            'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            'CargarFotos()
            'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Arrow
        End With
    End Sub

    Private Sub btnPrincipal_Click(sender As System.Object, e As System.EventArgs) Handles btnPrincipal.Click

        If gc.Gallery.GetCheckedItems().Count + gcWeb.Gallery.GetCheckedItems().Count = 1 Then
            Dim items As List(Of GalleryItem) = gc.Gallery.GetCheckedItems()
            items.AddRange(gcWeb.Gallery.GetCheckedItems())
            firstMarkItems(items)
        ElseIf gc.Gallery.GetCheckedItems().Count + gcWeb.Gallery.GetCheckedItems().Count > 1 Then
            XtraMessageBox.Show("Solo se puede elegir una", "Atención", MessageBoxButtons.OK)
        Else
            XtraMessageBox.Show("Elige una", "Atención", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub btnRotarDerecha_Click(sender As System.Object, e As System.EventArgs) Handles btnRotarDerecha.Click
        rotar(True)
    End Sub

    Private Sub btnRotarIzquierda_Click(sender As System.Object, e As System.EventArgs) Handles btnRotarIzquierda.Click
        rotar(False)
    End Sub

    Private Sub rotar(Derecha As Boolean)
        If gc.Gallery.GetCheckedItems().Count + gcWeb.Gallery.GetCheckedItems().Count = 0 Then
            XtraMessageBox.Show("Elige alguna", "Atención", MessageBoxButtons.OK)
            Exit Sub
        End If
        Dim carpeta As String = ""
        For Each item As GalleryItem In MarkedItems
            If item.GalleryGroup IsNot Nothing Then
                If item.GalleryGroup.Caption.Contains("disco") Then
                    carpeta = CarpetaDocumento
                Else
                    carpeta = CarpetaDocumentoPublicadas
                End If
                If System.IO.File.Exists(carpeta & "\" & item.Caption) Then
                    Dim img As Image = Image.FromStream(New IO.MemoryStream(IO.File.ReadAllBytes(carpeta & "\" & item.Caption)))
                    If Derecha Then
                        img.RotateFlip(RotateFlipType.Rotate270FlipXY)
                    Else
                        img.RotateFlip(RotateFlipType.Rotate90FlipXY)
                    End If
                    img.Save(carpeta & "\" & item.Caption)
                End If
                If DatosEmpresa.WordPress Then
                    Dim Id_WP_Foto As Integer = ObtenerIdFoto_Desde_IdPropertyYFichero(WP_IdProperty, item.Caption)
                    If Id_WP_Foto <> 0 Then
                        WPEliminarFoto(Id_WP_Foto)
                    End If
                Else

                End If
            End If
        Next
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        CargarFotos()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Arrow
        If carpeta = CarpetaDocumentoPublicadas Then
            upload()
        End If
    End Sub


End Class
