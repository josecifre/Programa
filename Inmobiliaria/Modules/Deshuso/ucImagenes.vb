Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraBars.Ribbon.ViewInfo
Imports System.Drawing.Imaging
Public Class ucImagenes

    Dim Referencia As String
    Dim CarpetaDocumento As String
    Dim CarpetaDocumentoPublicadas As String
    Dim ImagenesDe As String
    Private markedItems_Renamed As List(Of GalleryItem)
    Private p_ContadorPropietario As String
    Private p_ReferenciaInmueble As String
    Dim fs As System.IO.FileStream
    Dim Fichero As String
    Dim FicheroDestino As String
    Dim items As List(Of GalleryItem)
    Dim EnDisco As Boolean = True

    Private WithEvents BinSrc As BindingSource

    Public Property ContadorPropietario As Integer
        Get
            Return p_ContadorPropietario
        End Get
        Set(value As Integer)
            p_ContadorPropietario = value
        End Set
    End Property
    Public Property ReferenciaInmueble As Integer
        Get
            Return p_ReferenciaInmueble
        End Get
        Set(value As Integer)
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

    Sub New(contadorPropietarioPasado As Integer, referenciaInmueblePasado As Integer)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        ReferenciaInmueble = referenciaInmueblePasado
        ContadorPropietario = contadorPropietarioPasado

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub ucImagenes_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        AparienciaGeneral()

        AddHandler Me.KeyDown, AddressOf HandleKeyPress
        AddHandler gc.KeyDown, AddressOf HandleKeyPress
        AddHandler imageSlider.KeyDown, AddressOf HandleKeyPress

        gc.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside
        gc.Gallery.ImageSize = New Size(120, 90)
        gc.Gallery.HoverImageSize = New Size(130, 100)
        gc.Gallery.ItemCheckMode = Gallery.ItemCheckMode.Multiple

        gc.Gallery.AllowHoverImages = False

        gc.Gallery.ShowItemText = True
        imageSlider.AllowLooping = True

        Referencia = ReferenciaInmueble
        ImagenesDe = ContadorPropietario
        CarpetaDocumento = clVariables.RutaServidor & "\Fotos\" & ImagenesDe & "-" & Referencia
        CarpetaDocumentoPublicadas = CarpetaDocumento & "\actualizarweb"

        CargarFotos()
    End Sub

    Private Sub HandleKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyCode = Keys.Right Then
            Try
                imageSlider.SlideNext()
            Catch ex As Exception

            End Try
        End If

        If e.KeyCode = Keys.Left Then
            Try
                imageSlider.SlidePrev()
            Catch ex As Exception

            End Try
        End If

    End Sub

    Public Sub CargarFotos()
       
        imageSlider.Images.Clear()
        With gc.Gallery.Groups
            .Item(0).Caption = "Imágenes en disco (0)"
            .Item(1).Caption = "Imágenes a publicar (0)"
            .Item(0).Items.Clear()
            .Item(1).Items.Clear()
            If Not System.IO.Directory.Exists(CarpetaDocumento) Then
                Exit Sub
            End If
            Dim DirFiles() As String = System.IO.Directory.GetFiles(CarpetaDocumento, "*.*")
            If DirFiles.Length > 0 Then
                For i = 0 To DirFiles.Length - 1
                    Try
                        fs = New System.IO.FileStream(DirFiles(i), System.IO.FileMode.Open)
                        Fichero = My.Computer.FileSystem.GetName(fs.Name)
                        .Item(0).Items.Add(New GalleryItem(Image.FromStream(fs), Image.FromStream(fs), Fichero, "", i, i, fs.Name, ""))
                        If EnDisco Then
                            imageSlider.Images.Add(Image.FromStream(fs))
                        End If
                        fs.Close()
                    Catch
                    End Try
                Next
                .Item(0).Caption = "Imágenes en disco (" & DirFiles.Length & ")"
            End If
            If Not System.IO.Directory.Exists(CarpetaDocumentoPublicadas) Then
                Exit Sub
            End If
            Dim DirFilesPublicadas() As String = System.IO.Directory.GetFiles(CarpetaDocumentoPublicadas, "*.*")
            If DirFilesPublicadas.Length > 0 Then
                For i = 0 To DirFilesPublicadas.Length - 1
                    Try
                        fs = New System.IO.FileStream(DirFilesPublicadas(i), System.IO.FileMode.Open)
                        Fichero = My.Computer.FileSystem.GetName(fs.Name)
                        .Item(1).Items.Add(New GalleryItem(Image.FromStream(fs), Image.FromStream(fs), Fichero, "", i, i, fs.Name, ""))
                        If Not EnDisco Then
                            imageSlider.Images.Add(Image.FromStream(fs))
                        End If
                        fs.Close()
                    Catch
                    End Try
                Next
                .Item(1).Caption = "Imágenes a publicar (" & DirFilesPublicadas.Length & ")"
            End If
        End With
        imageSlider.Refresh() 'TODO
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

    Private Sub btnAnadir_Click(sender As System.Object, e As System.EventArgs) Handles btnAnadir.Click
        FuncionesGenerales.Funciones.InsertarDocumento(CarpetaDocumento, EnumFiltro.JPG, True)
        CargarFotos()
    End Sub

    Private Sub GalleryControlGallery1_ItemDoubleClick(sender As System.Object, e As DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs) Handles gc.Gallery.ItemDoubleClick
        Diagnostics.Process.Start(e.Item.Tag)
    End Sub
    Private Function GetCheckedImages() As List(Of Image)
        items = gc.Gallery.GetCheckedItems()
        Dim images As List(Of Image) = New List(Of Image)(items.Count)
        For Each item As GalleryItem In items
            images.Add(Image.FromFile(CStr(item.Tag)))
        Next item
        Return images
    End Function
    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click

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

    Private Sub GalleryControlGallery1_ItemClick(sender As System.Object, e As DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs) Handles gc.Gallery.ItemClick
        Dim item As GalleryItem = sender
        If item.GalleryGroup.Caption.Contains("disco") Then
            If Not EnDisco Then
                EnDisco = True
                CargarFotos()
            End If
        Else
            If EnDisco Then
                EnDisco = False
                CargarFotos()
            End If
        End If
        Dim items As List(Of GalleryItem) = gc.Gallery.GetCheckedItems()
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
    Private Sub DrawMarkedIconInSelection(ByVal cache As GraphicsCache, ByVal bounds As Rectangle)
        Dim oldClipBounds As RectangleF = InflateClip(cache)
        cache.Graphics.DrawImage(My.Resources.ItemMarked_16x16, New Rectangle(bounds.Right - 10, bounds.Bottom - 10, 16, 16))
        cache.Graphics.SetClip(oldClipBounds)
    End Sub
    Private Sub OnMainGalleryCustomDrawItemImage(ByVal sender As Object, ByVal e As GalleryItemCustomDrawEventArgs) Handles gc.Gallery.CustomDrawItemImage
        If (Not MarkedItems.Contains(e.Item)) Then
            Return
        End If
        e.Cache.Graphics.DrawImage(e.Item.Image, (CType(e.ItemInfo, GalleryItemViewInfo)).ImageContentBounds)
        DrawMarkedIcon(e.Cache, (CType(e.ItemInfo, GalleryItemViewInfo)).ImageContentBounds)
        e.Handled = True
    End Sub
    Private Sub FilterByMarked(ByVal filterByMarked As Boolean)
        gc.Gallery.BeginUpdate()
        Try
            For Each group As GalleryItemGroup In gc.Gallery.Groups
                For Each item As GalleryItem In group.Items
                    item.Visible = (Not filterByMarked) OrElse MarkedItems.Contains(item)
                Next item
            Next group
        Finally
            gc.Gallery.EndUpdate()
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Salir()
    End Sub
    Private Sub Salir()
        Me.ParentForm.Dispose()
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        BorrarFotos()
    End Sub
    Public Sub BorrarFotos()
        Dim carpeta As String
        For Each item As GalleryItem In MarkedItems
            If item.GalleryGroup.Caption.Contains("disco") Then
                carpeta = CarpetaDocumento
            Else
                carpeta = CarpetaDocumentoPublicadas
            End If
            If System.IO.File.Exists(carpeta & "\" & item.Caption) Then
                Try
                    System.IO.File.Delete(carpeta & "\" & item.Caption)
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Exit Sub
                End Try
            End If
        Next
        CargarFotos()
    End Sub

    Private Sub btnPublicar_Click(sender As System.Object, e As System.EventArgs) Handles btnPublicar.Click
        Publicar()
    End Sub
    Private Sub publicar()
        Dim DirFiles() As String = System.IO.Directory.GetFiles(CarpetaDocumento, "*.*")
        Try
            If DirFiles.Length > 0 Then
                For Each item As GalleryItem In MarkedItems
                    If item.GalleryGroup.Caption.Contains("disco") Then
                        For i = 0 To DirFiles.Length - 1
                            If DirFiles(i).Contains(item.Caption) Then
                                fs = New System.IO.FileStream(DirFiles(i), System.IO.FileMode.Open)
                                Exit For
                            End If
                        Next
                        Fichero = My.Computer.FileSystem.GetName(fs.Name)
                        FicheroDestino = CarpetaDocumentoPublicadas & "\" & Fichero
                        If item.Caption = Fichero Then
                            FuncionesGenerales.Funciones.ComprobarYCrearCarpetas(CarpetaDocumentoPublicadas)
                            'System.IO.File.Copy(fs.Name, FicheroDestino & ".tmp")
                            Dim img As Image = item.Image
                            SaveJPGWithCompressionSetting(redimensionaimagen(img, 640, 480), FicheroDestino, 70)
                        End If
                        fs.Close()
                    End If
                Next

            Else
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
        CargarFotos()
    End Sub
    Public Shared Function redimensionaimagen(img As Image, ancho As Integer, alto As Integer) As Image
        Dim altoimg As Integer = img.Height
        Dim anchoimg As Integer = img.Width
        Dim altonuevo As Integer
        Dim anchonuevo As Integer

        If (altoimg / alto) > (anchoimg / ancho) Then
            altonuevo = alto
            anchonuevo = anchoimg / (altoimg / alto)
        Else
            altonuevo = altoimg / (anchoimg / ancho)
            anchonuevo = ancho
        End If

        Dim imgOrg As Bitmap = New Bitmap(img)
        Dim imgRdm As Bitmap = New Bitmap(ancho, alto)
        Using gr As Graphics = Graphics.FromImage(imgRdm)
            'gr.DrawImage(imgOrg, 0, 0, imgRdm.Width, imgRdm.Height)
            gr.DrawImage(imgOrg, 0, 0, anchonuevo, altonuevo)
        End Using
        Return imgOrg
    End Function
    Public Shared Sub SaveJPGWithCompressionSetting(ByVal image As Image, ByVal szFileName As String, ByVal lCompression As Long)

        Dim eps As EncoderParameters = New EncoderParameters(1)
        eps.Param(0) = New EncoderParameter(Encoder.Quality, lCompression)

        Dim ici As ImageCodecInfo = GetEncoderInfo("image/jpeg")
        Try
            image.Save(szFileName, ici, eps)
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

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Dim ftp As New tb_FTP
        Dim Http = "httpdocs/roberto" 'carpeta de la web
        ftp.FTPBorrarFicherosCarpeta(Http, "jpg")
        ftp.FTPSubirCarpeta(Http, CarpetaDocumentoPublicadas, "jpg")
    End Sub
End Class
