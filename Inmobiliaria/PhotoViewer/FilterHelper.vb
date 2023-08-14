Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports DevExpress.Utils

Namespace PhotoViewer
	Public NotInheritable Class FilterHelper
        Public Delegate Function ApplyFilterDelegate(ByVal img As Image, ByVal filterParams() As Object) As Image

		Private Sub New()
		End Sub
		Private Shared Function FilterImage(ByVal source As Image, ByVal filterMatrix As ColorMatrix) As Image
			Dim res As Image = New Bitmap(source.Width, source.Height)
			Using g As Graphics = Graphics.FromImage(res)
				Dim attrib As New ImageAttributes()
				attrib.SetColorMatrix(filterMatrix)
				g.Clear(Color.Transparent)
				g.DrawImage(source, New Rectangle(Point.Empty, res.Size), 0, 0, source.Width, source.Height, GraphicsUnit.Pixel, attrib)
			End Using
			Return res
		End Function
		Private Shared Function GetRedChannelColorMatrix() As ColorMatrix
			Dim m As New ColorMatrix(New Single()() { New Single() { 1.0f, 0.0f, 0.0f, 0.0f, 0.0f }, New Single() { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f }, New Single() { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f }, New Single() { 0.0f, 0.0f, 0.0f, 1.0f, 0.0f }, New Single() { 0.0f, 0.0f, 0.0f, 0.0f, 1.0f } })
			Return m
		End Function
		Private Shared Function GetGreenChannelColorMatrix() As ColorMatrix
			Dim m As New ColorMatrix(New Single()() { New Single() { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f }, New Single() { 0.0f, 1.0f, 0.0f, 0.0f, 0.0f }, New Single() { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f }, New Single() { 0.0f, 0.0f, 0.0f, 1.0f, 0.0f }, New Single() { 0.0f, 0.0f, 0.0f, 0.0f, 1.0f } })
			Return m
		End Function
		Private Shared Function GetBlueChannelColorMatrix() As ColorMatrix
			Dim m As New ColorMatrix(New Single()() { New Single() { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f }, New Single() { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f }, New Single() { 0.0f, 0.0f, 1.0f, 0.0f, 0.0f }, New Single() { 0.0f, 0.0f, 0.0f, 1.0f, 0.0f }, New Single() { 0.0f, 0.0f, 0.0f, 0.0f, 1.0f } })
			Return m
		End Function
		Private Shared Function GetRGB2BGRColorMatrix() As ColorMatrix
			Dim m As New ColorMatrix(New Single()() { New Single() { 0.0f, 0.0f, 1.0f, 0.0f, 0.0f }, New Single() { 0.0f, 1.0f, 0.0f, 0.0f, 0.0f }, New Single() { 1.0f, 0.0f, 0.0f, 0.0f, 0.0f }, New Single() { 0.0f, 0.0f, 0.0f, 1.0f, 0.0f }, New Single() { 0.0f, 0.0f, 0.0f, 0.0f, 1.0f } })
			Return m
		End Function
		Private Shared Function GetInvertColorMatrix() As ColorMatrix
			Dim m As New ColorMatrix(New Single()() { New Single() { -1.0f, 0.0f, 0.0f, 0.0f, 0.0f }, New Single() { 0.0f, -1.0f, 0.0f, 0.0f, 0.0f }, New Single() { 0.0f, 0.0f, -1.0f, 0.0f, 0.0f }, New Single() { 0.0f, 0.0f, 0.0f, 1.0f, 0.0f }, New Single() { 1.0f, 1.0f, 1.0f, 0.0f, 1.0f } })
			Return m
		End Function
		Private Shared Function GetSepiaColorMatrix() As ColorMatrix
			Dim m As New ColorMatrix(New Single()() { New Single() { 0.393f, 0.349f, 0.272f, 0.0f, 0.0f }, New Single() { 0.769f, 0.686f, 0.534f, 0.0f, 0.0f }, New Single() { 0.189f, 0.168f, 0.131f, 0.0f, 0.0f }, New Single() { 0.0f, 0.0f, 0.0f, 1.0f, 0.0f }, New Single() { 0.0f, 0.0f, 0.0f, 0.0f, 1.0f } })
			Return m
		End Function
		Private Shared Function GetBWColorMatrix() As ColorMatrix
			Dim m As New ColorMatrix(New Single()() { New Single() { 1.5f, 1.5f, 1.5f, 0.0f, 0.0f }, New Single() { 1.5f, 1.5f, 1.5f, 0.0f, 0.0f }, New Single() { 1.5f, 1.5f, 1.5f, 0.0f, 0.0f }, New Single() { 0.0f, 0.0f, 0.0f, 1.0f, 0.0f }, New Single() { -1.0f, -1.0f, -1.0f, 0.0f, 1.0f } })
			Return m
		End Function
		Private Shared Function GetWhite2AlphaColorMatrix() As ColorMatrix
			Dim m As New ColorMatrix(New Single()() { New Single() { 1.0f, 0.0f, 0.0f, -1.0f, 0.0f }, New Single() { 0.0f, 1.0f, 0.0f, -1.0f, 0.0f }, New Single() { 0.0f, 0.0f, 1.0f, -1.0f, 0.0f }, New Single() { 0.0f, 0.0f, 0.0f, 1.0f, 0.0f }, New Single() { 0.0f, 0.0f, 0.0f, 0.0f, 1.0f } })
			Return m
		End Function
		Private Shared Function GetPolaroidColorMatrix() As ColorMatrix
			Dim m As New ColorMatrix(New Single()() { New Single() { 1.438f, -0.062f, -0.062f, 0.0f, 0.0f }, New Single() { -0.122f, 1.378f, -0.122f, 0.0f, 0.0f }, New Single() { -0.016f, -0.016f, 1.483f, 0.0f, 0.0f }, New Single() { 0.0f, 0.0f, 0.0f, 1.0f, 0.0f }, New Single() { -0.03f, 0.05f, -0.02f, 0.0f, 1.0f } })
			Return m
		End Function
		Private Shared Function GetGrayscaleColorMatrix() As ColorMatrix
			Dim m As New ColorMatrix(New Single()() { New Single() { 0.33f, 0.33f, 0.33f, 0.0f, 0.0f }, New Single() { 0.59f, 0.59f, 0.59f, 0.0f, 0.0f }, New Single() { 0.11f, 0.11f, 0.11f, 0.0f, 0.0f }, New Single() { 0.0f, 0.0f, 0.0f, 1.0f, 0.0f }, New Single() { 0.0f, 0.0f, 0.0f, 0.0f, 1.0f } })
			Return m
		End Function
		Private Shared Function GetContrastColorMatrix(ByVal c As Single) As ColorMatrix
			Dim t As Single = (1.0f - c) / 2.0f
			Dim m As New ColorMatrix(New Single()() { New Single() { c, 0.0f, 0.0f, 0.0f, 0.0f }, New Single() { 0.0f, c, 0.0f, 0.0f, 0.0f }, New Single() { 0.0f, 0.0f, c, 0.0f, 0.0f }, New Single() { 0.0f, 0.0f, 0.0f, 1.0f, 0.0f }, New Single() { t, t, t, 0.0f, 1.0f } })
			Return m
		End Function
		Private Shared Function GetBrightnessColorMatrix(ByVal b As Single) As ColorMatrix
			Dim m As New ColorMatrix(New Single()() { New Single() { 1.0f, 0.0f, 0.0f, 0.0f, 0.0f }, New Single() { 0.0f, 1.0f, 0.0f, 0.0f, 0.0f }, New Single() { 0.0f, 0.0f, 1.0f, 0.0f, 0.0f }, New Single() { 0.0f, 0.0f, 0.0f, 1.0f, 0.0f }, New Single() { b, b, b, 0.0f, 1.0f } })
			Return m
		End Function
		Private Shared Function GetSaturationColorMatrix(ByVal s As Single) As ColorMatrix
			Dim lumR As Single = 0.3086f
			Dim lumG As Single = 0.6094f
			Dim lumB As Single = 0.0820f

			Dim sr As Single = (1 - s) * lumR
			Dim sg As Single = (1 - s) * lumG
			Dim sb As Single = (1 - s) * lumB

			Dim m As New ColorMatrix(New Single()() { New Single() { s + sr, sr, sr, 0.0f, 0.0f }, New Single() { sg, s + sg, sg, 0.0f, 0.0f }, New Single() { sb, sb, s + sb, 0.0f, 0.0f }, New Single() { 0.0f, 0.0f, 0.0f, 1.0f, 0.0f }, New Single() { 0.0f, 0,0f, 0.0f, 0.0f, 1.0f } })
			Return m
		End Function
		Private Shared Function ApplyRedChannelFilter(ByVal img As Image, ParamArray ByVal filterParams() As Object) As Image
			Return FilterImage(img, GetRedChannelColorMatrix())
		End Function
		Private Shared Function ApplyGreenChannelFilter(ByVal img As Image, ParamArray ByVal filterParams() As Object) As Image
			Return FilterImage(img, GetGreenChannelColorMatrix())
		End Function
		Private Shared Function ApplyBlueChannelFilter(ByVal img As Image, ParamArray ByVal filterParams() As Object) As Image
			Return FilterImage(img, GetBlueChannelColorMatrix())
		End Function
		Private Shared Function ApplyInvertFilter(ByVal img As Image, ParamArray ByVal filterParams() As Object) As Image
			Return FilterImage(img, GetInvertColorMatrix())
		End Function
		Private Shared Function ApplyRGB2BGRFilter(ByVal img As Image, ParamArray ByVal filterParams() As Object) As Image
			Return FilterImage(img, GetRGB2BGRColorMatrix())
		End Function
		Private Shared Function ApplySepiaFilter(ByVal img As Image, ParamArray ByVal filterParams() As Object) As Image
			Return FilterImage(img, GetSepiaColorMatrix())
		End Function
		Private Shared Function ApplyBWFilter(ByVal img As Image, ParamArray ByVal filterParams() As Object) As Image
			Return FilterImage(img, GetBWColorMatrix())
		End Function
		Private Shared Function ApplyPolaroidFilter(ByVal img As Image, ParamArray ByVal filterParams() As Object) As Image
			Return FilterImage(img, GetPolaroidColorMatrix())
		End Function
		Private Shared Function ApplyGrayscaleFilter(ByVal img As Image, ParamArray ByVal filterParams() As Object) As Image
			Return FilterImage(img, GetGrayscaleColorMatrix())
		End Function
		Private Shared Function ApplyWhite2AlphaFilter(ByVal img As Image, ParamArray ByVal filterParams() As Object) As Image
			Return FilterImage(img, GetWhite2AlphaColorMatrix())
		End Function
		Private Shared Function ApplyContrastFilter(ByVal img As Image, ParamArray ByVal filterParams() As Object) As Image
			Dim param As Single
			If filterParams Is Nothing OrElse filterParams.Length = 0 Then
				param = 2.0f
			Else
				param = CSng(filterParams(0))
			End If
			Return FilterImage(img, GetContrastColorMatrix(param))
		End Function
		Private Shared Function ApplyBrightnessFilter(ByVal img As Image, ParamArray ByVal filterParams() As Object) As Image
			Dim param As Single
			If filterParams Is Nothing OrElse filterParams.Length = 0 Then
				param = 0.3f
			Else
				param = CSng(filterParams(0))
			End If
			Return FilterImage(img, GetBrightnessColorMatrix(param))
		End Function
		Private Shared Function ApplySaturationFilter(ByVal img As Image, ParamArray ByVal filterParams() As Object) As Image
			Dim param As Single
			If filterParams Is Nothing OrElse filterParams.Length = 0 Then
				param = 0.3f
			Else
				param = CSng(filterParams(0))
			End If
			Return FilterImage(img, GetSaturationColorMatrix(param))
		End Function
		Private Shared Function GetFilterByName(ByVal name As String) As FilterInfo
			For Each info As FilterInfo In Filters
				If info.Name = name Then
					Return info
				End If
			Next info
			Return Nothing
		End Function
		Public Shared Function ApplyFilter(ByVal name As String, ByVal img As Image, ParamArray ByVal filterParams() As Object) As Image
			Dim info As FilterInfo = GetFilterByName(name)
			If info IsNot Nothing Then
				Return CType(info.FilterMethod.DynamicInvoke(img, filterParams), Image)
			End If
			Return img
		End Function
		Private Shared filters_Renamed As List(Of FilterInfo)
		Public Shared ReadOnly Property Filters() As List(Of FilterInfo)
			Get
				If filters_Renamed Is Nothing Then
					filters_Renamed = New List(Of FilterInfo)()
					InitializeFilters(filters_Renamed)
				End If
				Return filters_Renamed
			End Get
		End Property
		Private Shared Sub InitializeFilters(ByVal filters As List(Of FilterInfo))
            filters.Add(New FilterInfo("Invert", New ApplyFilterDelegate(AddressOf ApplyInvertFilter), GetType(SimpleFilterParams)))
            filters.Add(New FilterInfo("RGB->BGR", New ApplyFilterDelegate(AddressOf ApplyRGB2BGRFilter), GetType(SimpleFilterParams)))
            filters.Add(New FilterInfo("Sepia", New ApplyFilterDelegate(AddressOf ApplySepiaFilter), GetType(SimpleFilterParams)))
            filters.Add(New FilterInfo("Contrast", New ApplyFilterDelegate(AddressOf ApplyContrastFilter), GetType(ContrastFilterParams)))
            filters.Add(New FilterInfo("Brightness", New ApplyFilterDelegate(AddressOf ApplyBrightnessFilter), GetType(BrightnessFilterParams)))
            filters.Add(New FilterInfo("Saturation", New ApplyFilterDelegate(AddressOf ApplySaturationFilter), GetType(SaturationFilterParams)))
            filters.Add(New FilterInfo("Black & White", New ApplyFilterDelegate(AddressOf ApplyBWFilter), GetType(SimpleFilterParams)))
            filters.Add(New FilterInfo("Polaroid", New ApplyFilterDelegate(AddressOf ApplyPolaroidFilter), GetType(SimpleFilterParams)))
            filters.Add(New FilterInfo("White -> Alpha", New ApplyFilterDelegate(AddressOf ApplyWhite2AlphaFilter), GetType(SimpleFilterParams)))
            filters.Add(New FilterInfo("Grayscale", New ApplyFilterDelegate(AddressOf ApplyGrayscaleFilter), GetType(SimpleFilterParams)))
            filters.Add(New FilterInfo("Red Channel", New ApplyFilterDelegate(AddressOf ApplyRedChannelFilter), GetType(SimpleFilterParams)))
            filters.Add(New FilterInfo("Green Channel", New ApplyFilterDelegate(AddressOf ApplyGreenChannelFilter), GetType(SimpleFilterParams)))
            filters.Add(New FilterInfo("Blue Channel", New ApplyFilterDelegate(AddressOf ApplyBlueChannelFilter), GetType(SimpleFilterParams)))
		End Sub
		Public Shared Function GetFiltersName() As String()
			Dim fname(Filters.Count - 1) As String
			Dim nameIndex As Integer = 0
			For Each info As FilterInfo In Filters
				fname(nameIndex) = info.Name
				nameIndex += 1
			Next info
			Return fname
		End Function
		Public Shared Function GetFiltersSamples(ByVal sampleImage As Image) As ImageCollection
			Dim coll As New ImageCollection()
			coll.ImageSize = sampleImage.Size
			For Each info As FilterInfo In Filters
				coll.Images.Add(CType(info.FilterMethod.DynamicInvoke(sampleImage, Nothing), Image))
			Next info
			Return coll
		End Function
	End Class

	Public Class FilterInfo
		Private name_Renamed As String
		Private filterMethod_Renamed As System.Delegate
        Private paramsControlType As Type

        Public Sub New(ByVal name As String, ByVal filterMethod As System.Delegate, ByVal paramsControlType As Type)
            Me.name_Renamed = name
            Me.filterMethod_Renamed = filterMethod
            Me.paramsControlType = paramsControlType
        End Sub

		Public ReadOnly Property Name() As String
			Get
				Return name_Renamed
			End Get
		End Property
		Public ReadOnly Property FilterMethod() As System.Delegate
			Get
				Return filterMethod_Renamed
			End Get
		End Property
        Public Function CreateParamsControl() As SimpleFilterParams
            Dim ci As Reflection.ConstructorInfo = paramsControlType.GetConstructor(New Type() {})
            Dim pc As SimpleFilterParams = CType(ci.Invoke(New Object() {}), SimpleFilterParams)
            pc.Filter = Me
            Return pc
        End Function
	End Class
End Namespace
