Imports System.IO

Namespace DevExpress.CrmDemo.Win.Helpers
	Public NotInheritable Class FileHelpers

		Private Sub New()
		End Sub

		Public Shared Function GetFileIcon(ByVal filepath As String) As Bitmap
			If String.IsNullOrEmpty(filepath) OrElse (Not File.Exists(filepath)) Then
				Return Nothing
			End If

			Dim foundIcon As Icon = Nothing

			Try
				foundIcon = Icon.ExtractAssociatedIcon(filepath)
			Catch
			End Try

			If foundIcon IsNot Nothing Then
				Return foundIcon.ToBitmap()
			Else
				Return Nothing
			End If
		End Function
	End Class
End Namespace
