Namespace DevExpress.CrmDemo.Win.Helpers
	Public Module FormsExtensions
		<System.Runtime.CompilerServices.Extension> _
		Public Function CropBitmap(ByVal bitmap As Bitmap, ByVal rectangle As Rectangle) As Bitmap
			Dim croppedBitmap = New Bitmap(rectangle.Width, rectangle.Height)
			Dim graphics = System.Drawing.Graphics.FromImage(croppedBitmap)
			graphics.DrawImage(bitmap, 0, 0, rectangle, GraphicsUnit.Pixel)
			Return croppedBitmap
		End Function

		<System.Runtime.CompilerServices.Extension> _
		Public Function Add(ByVal point1 As Point, ByVal point2 As Point) As Point
			Return Point.Add(point1, New Size(point2))
		End Function
	End Module
End Namespace
