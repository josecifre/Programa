Imports System.Drawing.Imaging
Imports System.IO

Module MarcaAgua

    Public Class clConfiguracionMarcaAgua

        Public MostrarTexto As Boolean
        Public MostrarImagen As Boolean
        Public RutaImagen As String
        Public TextoAMostrar As String = ""
        Public Posicion As String
        Public RelacionAncho As Double
        Public RelacionAlto As Double
        Public Transparencia As Double

    End Class

    Public Sub AnadirMarcaAguaJPG(Origen As String, Destino As String, ConfiguracionMarcaAgua As clConfiguracionMarcaAgua)


        Dim fi As FileInfo = My.Computer.FileSystem.GetFileInfo(Destino)

        Dim Extension As String = fi.Extension
        Dim NombreFicheroDestino As String = fi.Name

        Dim NombreFicheroDestinoSinGuiones As String = Microsoft.VisualBasic.Left(NombreFicheroDestino, Len(NombreFicheroDestino) - Len(Extension))

        NombreFicheroDestinoSinGuiones = Replace(NombreFicheroDestinoSinGuiones, "-", "")
        NombreFicheroDestinoSinGuiones = Replace(NombreFicheroDestinoSinGuiones, "'", "")
        NombreFicheroDestinoSinGuiones = Replace(NombreFicheroDestinoSinGuiones, ".", "")
        NombreFicheroDestinoSinGuiones = Replace(NombreFicheroDestinoSinGuiones, " ", "")
        NombreFicheroDestinoSinGuiones = NombreFicheroDestinoSinGuiones & Extension

        Destino = Replace(Destino, NombreFicheroDestino, NombreFicheroDestinoSinGuiones)

        'set a working directory

        '  Dim WorkingDirectory As String = My.Computer.FileSystem.GetParentPath(Imagen)


        'define a string of text to use as the Copyright message
        If Not ConfiguracionMarcaAgua.MostrarTexto Then
            ConfiguracionMarcaAgua.TextoAMostrar = ""
        End If

        Dim Copyright As String = ConfiguracionMarcaAgua.TextoAMostrar
        '     Copyright = ""
        'create a image object containing the photograph to watermark
        Dim imgPhoto As Image = Image.FromFile(Origen)

        ''Try
        ''    ' imgPhoto.Save(Destino, ImageFormat.Jpeg)


        ''    Dim ms As New MemoryStream()
        ''    imgPhoto.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
        ''    ms.Seek(0, SeekOrigin.Begin) 
        ''    Dim file As New FileStream(Destino, FileMode.Create, FileAccess.Write)
        ''    ms.WriteTo(file)
        ''    file.Close()
        ''    ms.Close()
        ''    imgPhoto.Dispose()


        ''Catch ex2 As BadImageFormatException
        ''    MsgBox(ex2.Message)
        ''Catch ex3 As EndOfStreamException

        ''    MsgBox(ex3.Message)
        ''Catch ex As Exception
        ''    MsgBox(ex.Message)
        ''End Try

        ''MsgBox("2")
        ' ''  imgPhoto.Dispose()

        ''Return


       
        Dim phWidth As Integer = imgPhoto.Width
        Dim phHeight As Integer = imgPhoto.Height

        'create a Bitmap the Size of the original photograph
        Dim bmPhoto As New Bitmap(phWidth, phHeight, PixelFormat.Format24bppRgb)

        bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution)


        'load the Bitmap into a Graphics object 
        Dim grPhoto As Graphics = Graphics.FromImage(bmPhoto)


        ' JCB COMENTO ESTO PQ NO QUIERO AÑADIR IMAGEN
        'create a image object containing the watermark
        ' Dim imgWatermark As Image = New Bitmap(WorkingDirectory & Convert.ToString("\watermark.bmp"))
        'Dim imgWatermark As Image = New Bitmap(My.Application.Info.DirectoryPath & Convert.ToString("\watermark.png"))
        'Dim imgWatermark As Image = New Bitmap(My.Application.Info.DirectoryPath & Convert.ToString("\logo.png"))

        Dim imgWatermark As Image
        Dim wmWidth As Integer
        Dim wmHeight As Integer

        If ConfiguracionMarcaAgua.MostrarImagen Then
            imgWatermark = New Bitmap(ConfiguracionMarcaAgua.RutaImagen)
            wmWidth = imgWatermark.Width
            wmHeight = imgWatermark.Height
        End If


        'FIN JCB COMENTO ESTO PQ NO QUIERO AÑADIR IMAGEN 

        '------------------------------------------------------------
        'Step #1 - Insert Copyright message
        '------------------------------------------------------------

        'Set the rendering quality for this Graphics object
        grPhoto.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        'Draws the photo Image object at original size to the graphics object.
        ' Photo Image object
        ' Rectangle structure
        ' x-coordinate of the portion of the source image to draw. 
        ' y-coordinate of the portion of the source image to draw. 
        ' Width of the portion of the source image to draw. 
        ' Height of the portion of the source image to draw. 
        grPhoto.DrawImage(imgPhoto, New Rectangle(0, 0, phWidth, phHeight), 0, 0, phWidth, phHeight, _
         GraphicsUnit.Pixel)
        ' Units of measure 
        '-------------------------------------------------------
        'to maximize the size of the Copyright message we will 
        'test multiple Font sizes to determine the largest posible 
        'font we can use for the width of the Photograph
        'define an array of point sizes you would like to consider as possiblities
        '-------------------------------------------------------
        Dim sizes As Integer() = New Integer() {16, 14, 12, 10, 8, 6, _
         4}

        Dim crFont As Font = Nothing
        Dim crSize As New SizeF()

        'Loop through the defined sizes checking the length of the Copyright string
        'If its length in pixles is less then the image width choose this Font size.
        For i As Integer = 0 To 6
            'set a Font object to Arial (i)pt, Bold
            crFont = New Font("arial", sizes(i), FontStyle.Bold)
            'Measure the Copyright string in this Font
            crSize = grPhoto.MeasureString(Copyright, crFont)

            If CUShort(crSize.Width) < CUShort(phWidth) Then
                Exit For
            End If
        Next

        'Since all photographs will have varying heights, determine a 
        'position 5% from the bottom of the image
        Dim yPixlesFromBottom As Integer = CInt(phHeight * 0.05)

        'Now that we have a point size use the Copyrights string height 
        'to determine a y-coordinate to draw the string of the photograph

        'JCB TEXTO BAJO
        'Dim yPosFromBottom As Single = ((phHeight - yPixlesFromBottom) - (crSize.Height / 2))

        'JCB TEXTO CENTRADO
        'Dim yPosFromBottom As Single = ((phHeight - yPixlesFromBottom) - (crSize.Height / 2))


        Dim yPosFromBottom As Single
        Dim xCenterOfImg As Single

        Dim AnchoLogo As Integer '= phWidth / 3
        Dim AltoLogo As Integer ' = phHeight / 6
        Dim multi As Double
        If phWidth <= phHeight Then 'DEFINIR TAMAÑO DEL LOGO XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            multi = phWidth / 1920
        Else
            multi = phHeight / 1080
        End If
      
        If ConfiguracionMarcaAgua.RelacionAlto > 0 AndAlso ConfiguracionMarcaAgua.RelacionAncho > 0 Then
            AnchoLogo = (1920 * ConfiguracionMarcaAgua.RelacionAncho) * multi
            AltoLogo = (1080 * ConfiguracionMarcaAgua.RelacionAlto) * multi
        Else
            AnchoLogo = 640 * multi
            AltoLogo = 360 * multi
        End If

        Select Case ConfiguracionMarcaAgua.Posicion
            Case "CENTRADOIZQUIERDA", "CENTRADO", "CENTRADODERECHA"
                yPosFromBottom = (phHeight / 2) - (AltoLogo / 2) '((phHeight / 2 - yPixlesFromBottom) - (crSize.Height / 2))
            Case "ABAJOIZQUIERDA", "ABAJO", "ABAJODERECHA"
                yPosFromBottom = phHeight - (AltoLogo + 10) '((phHeight - yPixlesFromBottom) - crSize.Height)
            Case "ARRIBAIZQUIERDA", "ARRIBA", "ARRIBADERECHA"
                yPosFromBottom = 0 + 10 ' wmHeight
        End Select
       
        If ConfiguracionMarcaAgua.Posicion.Contains("IZQUIERDA") Then
            xCenterOfImg = 0 + 10
        ElseIf ConfiguracionMarcaAgua.Posicion.Contains("DERECHA") Then
            xCenterOfImg = phWidth - (AnchoLogo + 10)
        Else
            xCenterOfImg = (phWidth / 2) - (AnchoLogo / 2)
        End If
       
        'Determine its x-coordinate by calculating the center of the width of the image


        'Define the text layout by setting the text alignment to centered
        Dim StrFormat As New StringFormat()
        StrFormat.Alignment = StringAlignment.Center

        'define a Brush which is semi trasparent black (Alpha set to 153)
        Dim semiTransBrush2 As New SolidBrush(Color.FromArgb(153, 0, 0, 0))

        'Draw the Copyright string
        'string of text
        'font
        'Brush
        'Position
        grPhoto.DrawString(Copyright, crFont, semiTransBrush2, New PointF(xCenterOfImg + 1, yPosFromBottom + 101), StrFormat)

        'define a Brush which is semi trasparent white (Alpha set to 153)
        Dim semiTransBrush As New SolidBrush(Color.FromArgb(153, 255, 255, 255))

        'Draw the Copyright string a second time to create a shadow effect
        'Make sure to move this text 1 pixel to the right and down 1 pixel
        'string of text
        'font
        'Brush
        'Position
        grPhoto.DrawString(Copyright, crFont, semiTransBrush, New PointF(xCenterOfImg, yPosFromBottom + 100), StrFormat)
        'Text alignment


        '------------------------------------------------------------
        'Step #2 - Insert Watermark image
        '------------------------------------------------------------

        'Create a Bitmap based on the previously modified photograph Bitmap
        Dim bmWatermark As New Bitmap(bmPhoto)
        bmWatermark.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution)
        ' bmWatermark.MakeTransparent(Color.White)
        'Load this Bitmap into a new Graphic Object
        Dim grWatermark As Graphics = Graphics.FromImage(bmWatermark)
        'To achieve a transulcent watermark we will apply (2) color 
        'manipulations by defineing a ImageAttributes object and 
        'seting (2) of its properties.
        Dim imageAttributes As New ImageAttributes()

        'The first step in manipulating the watermark image is to replace 
        'the background color with one that is trasparent (Alpha=0, R=0, G=0, B=0)
        'to do this we will use a Colormap and use this to define a RemapTable
        Dim colorMap As New ColorMap()

        'My watermark was defined with a background of 100% Green this will
        'be the color we search for and replace with transparency
        ''JCB Comento esto pq el fondo es transparente
        'colorMap.OldColor = Color.FromArgb(255, 0, 255, 0)
        'colorMap.NewColor = Color.FromArgb(0, 0, 0, 0)

        'Dim remapTable As ColorMap() = {colorMap}

        'imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap)
        'JCB Comento esto pq el fondo es transparente

        'The second color manipulation is used to change the opacity of the 
        'watermark.  This is done by applying a 5x5 matrix that contains the 
        'coordinates for the RGBA space.  By setting the 3rd row and 3rd column 
        'to 0.3f we achive a level of opacity'DEFINIMOS LA TRANSPARENCIA DEL LOGO 0.7F SE VE BASTANTE XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXxx
        Dim transparencia As Double = 0.7

        If ConfiguracionMarcaAgua.Transparencia > 0 Then
            transparencia = ConfiguracionMarcaAgua.Transparencia
        End If
        Dim colorMatrixElements As Single()() = {New Single() {1.0F, 0.0F, 0.0F, 0.0F, 0.0F}, New Single() {0.0F, 1.0F, 0.0F, 0.0F, 0.0F}, New Single() {0.0F, 0.0F, 1.0F, 0.0F, 0.0F}, New Single() {0.0F, 0.0F, 0.0F, transparencia, 0.0F}, New Single() {0.0F, 0.0F, 0.0F, 0.0F, 1.0F}}
        Dim wmColorMatrix As New ColorMatrix(colorMatrixElements)

        imageAttributes.SetColorMatrix(wmColorMatrix, ColorMatrixFlag.[Default], ColorAdjustType.Bitmap)

        'For this example we will place the watermark in the upper right
        'hand corner of the photograph. offset down 10 pixels and to the 
        'left 10 pixles





        'JCB COMENTO ESTO PQ NO QUIERO AÑADIR IMAGEN
        Dim xPosOfWm As Integer = ((phWidth - wmWidth) - 10)
        Dim yPosOfWm As Integer = 10


        'Set the detination Position
        ' x-coordinate of the portion of the source image to draw. 
        ' y-coordinate of the portion of the source image to draw. 
        ' Watermark Width
        ' Watermark Height
        ' Unit of measurment
        'grWatermark.DrawImage(imgWatermark, New Rectangle(xPosOfWm, yPosOfWm, wmWidth, wmHeight), 0, 0, wmWidth, wmHeight, _
        ' GraphicsUnit.Pixel, imageAttributes)

        'Dim ValoresBuenosAncho As Integer = 640
        'Dim ValoresBuenosAlto As Integer = 480

        'Dim MultiplicadorAncho As Double
        'Dim MultiplicadorAlto As Double

        'MultiplicadorAncho = ValoresBuenosAncho / phWidth
        'MultiplicadorAlto = ValoresBuenosAlto / phHeight


       


        'grWatermark.DrawImage(imgWatermark, New Rectangle(xCenterOfImg - (wmWidth * MultiplicadorAncho) / 2, yPosFromBottom - (wmHeight * MultiplicadorAlto) / 2, (wmWidth * MultiplicadorAncho), (wmHeight * MultiplicadorAlto)), 0, 0, wmWidth, wmHeight, _
        'GraphicsUnit.Pixel, imageAttributes)

        If ConfiguracionMarcaAgua.MostrarImagen Then
            grWatermark.DrawImage(imgWatermark, New Rectangle(xCenterOfImg, yPosFromBottom, (AnchoLogo), (AltoLogo)), 0, 0, wmWidth, wmHeight, _
      GraphicsUnit.Pixel, imageAttributes)
            '     grWatermark.DrawImage(imgWatermark, New Rectangle(xCenterOfImg - (AnchoLogo) / 2, yPosFromBottom - (AltoLogo) / 2, (AnchoLogo), (AltoLogo)), 0, 0, wmWidth, wmHeight, _
            'GraphicsUnit.Pixel, imageAttributes)
        End If

        'FIN JCB COMENTO ESTO PQ NO QUIERO AÑADIR IMAGEN


        'ImageAttributes Object
        'Replace the original photgraphs bitmap with the new Bitmap

        'prueba jcb
        imgPhoto = bmWatermark
        grPhoto.Dispose()
        grWatermark.Dispose()

        'save new image to file system.
        'imgPhoto.Save(WorkingDirectory & Convert.ToString("\watermark_final.jpg"), ImageFormat.Jpeg)

        'Try
        '    System.IO.File.Delete(Replace(Origen, "SinMarcaAgua", ""))
        'Catch ex As Exception


        'End Try



        '     MsgBox("Voy a save " & (Replace(Imagen, "SinMarcaAgua", "")))
        Destino = Replace(Destino, "\", "/")
        Destino = Replace(Destino, ".JPG", ".jpg")

        Try
            'comento esto pq da error GDI+
            'imgPhoto.Save(Destino, ImageFormat.Jpeg)
            'imgPhoto.Dispose()

            'y añado esto.
            Dim ms As New MemoryStream()
            imgPhoto.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            ms.Seek(0, SeekOrigin.Begin)
            Dim file As New FileStream(Destino, FileMode.Create, FileAccess.Write)
            ms.WriteTo(file)
            file.Close()
            ms.Close()
            imgPhoto.Dispose()




        Catch ex2 As BadImageFormatException
            MsgBox(ex2.Message)
        Catch ex3 As EndOfStreamException

            MsgBox(ex3.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

       

        'Dim safeImage As New Bitmap(imgPhoto)
        'MsgBox("1")
        'imgPhoto.Dispose()
        'MsgBox("2")

        'safeImage.Save(Destino, ImageFormat.Jpeg)

        'MsgBox("3")
        ''JCB COMENTO ESTO PQ NO QUIERO AÑADIR IMAGEN
        'imgWatermark.Dispose()
        ''FIN JCB COMENTO ESTO PQ NO QUIERO AÑADIR IMAGEN


    End Sub

    'Public Function DirectoryCopy(ByVal DirOrigen As String, ByVal DirDestino As String, ByVal CopiarSubdir As Boolean) As Boolean

    '    ' Cogemos las carpetas en el origen. 
    '    Dim dir As DirectoryInfo = New DirectoryInfo(DirOrigen)
    '    Dim dirs As DirectoryInfo() = dir.GetDirectories()
    '    Dim RutaLogo2 As String = My.Application.Info.DirectoryPath & "/Logo.png"

    '    If Not dir.Exists Then
    '        MsgBox("No se ha encontrado el directorio origen: " + DirOrigen)
    '        Return False
    '    End If

    '    Try
    '        ' Si no existe la carpeta destino la creamos. 
    '        If Not Directory.Exists(DirDestino) Then
    '            Directory.CreateDirectory(DirDestino)
    '        End If
    '        '  Cogemos los archivos origen y los copiamos en destino. 
    '        Dim files As FileInfo() = dir.GetFiles()
    '        For Each file In files
    '            Dim temppath As String = Path.Combine(DirDestino, file.Name)
    '            ' file.CopyTo(temppath, False)
    '            AnadirMarcaAguaJPG(file.FullName, temppath, RutaLogo2)
    '        Next file
    '        ' Si tenemos q copiar subdirectorios...repetimos proceso para cada uno de ellos
    '        If CopiarSubdir Then
    '            For Each subdir In dirs
    '                Dim temppath As String = Path.Combine(DirDestino, subdir.Name)
    '                DirectoryCopy(subdir.FullName, temppath, CopiarSubdir)
    '            Next subdir
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Error: " + ex.Message)
    '        Return False
    '    End Try
    '    Return True
    'End Function
End Module
