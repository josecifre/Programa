Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing
Imports DevExpress.Utils.Drawing
Imports System.IO
Imports DevExpress.XtraEditors
Imports System.Windows.Forms
Imports System.Security.Cryptography

Namespace PhotoViewer
	Public Class ThumbnailHelper
		Private Shared defaultHelper As ThumbnailHelper
		Public Shared ReadOnly Property [Default]() As ThumbnailHelper
			Get
				If defaultHelper Is Nothing Then
					defaultHelper = New ThumbnailHelper()
				End If
				Return defaultHelper
			End Get
		End Property

		Private thumbnails_Renamed As Dictionary(Of String, Image)
		Protected ReadOnly Property Thumbnails() As Dictionary(Of String, Image)
			Get
				If thumbnails_Renamed Is Nothing Then
					thumbnails_Renamed = New Dictionary(Of String, Image)()
				End If
				Return thumbnails_Renamed
			End Get
		End Property

		Public Function CreateThumbnail(ByVal image As Image, ByVal length As Integer) As Image
			Dim rect As Rectangle = ImageLayoutHelper.GetImageBounds(New Rectangle(0, 0, length, length), image.Size, ImageLayoutMode.ZoomInside)
			Dim bmp As New Bitmap(rect.Width, rect.Height)
			Using g As Graphics = Graphics.FromImage(bmp)
				rect.X = 0
				rect.Y = 0
				g.DrawImage(image, rect)
			End Using
			Return bmp
		End Function
		Public Function CreateThumbnail(ByVal image As Image, ByVal fileName As String, ByVal length As Integer, ByVal thumbPath As String) As Image
			Dim bmp As Image = CreateThumbnail(image, length)
			Dim thumbFileName As String = length.ToString() & "_" & fileName
			Dim md5hash As String = CalculateMD5Hash(thumbFileName)
			Try
				If (Not Directory.Exists(thumbPath)) Then
					Directory.CreateDirectory(thumbPath)
				End If
				Dim finalFileName As String = thumbPath & md5hash
			Catch e As Exception
				XtraMessageBox.Show("Error creating thumnail for image '" & fileName & "'. " & e.Message, "Thumbnail creator", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
			Return bmp
		End Function
		Public Function CalculateMD5Hash(ByVal input As String) As String
			Dim md5 As MD5 = System.Security.Cryptography.MD5.Create()
			Dim inputBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(input)
			Dim hash() As Byte = md5.ComputeHash(inputBytes)

			Dim sb As New StringBuilder()
			For i As Integer = 0 To hash.Length - 1
				sb.Append(hash(i).ToString("X2"))
			Next i
			Return sb.ToString()
		End Function
		Public Function GetThumbnail(ByVal fileName As String, ByVal length As Integer, ByVal thumbPath As String) As Image
			Dim thumbFileName As String = length.ToString() & "_" & fileName
			thumbFileName = CalculateMD5Hash(thumbFileName)
			thumbFileName = thumbPath & thumbFileName
			If Thumbnails.ContainsKey(thumbFileName) Then
				Return Thumbnails(thumbFileName)
			End If
			Try
				If File.Exists(thumbFileName) Then
					Return Image.FromFile(thumbFileName)
				End If
			Catch e As Exception
				XtraMessageBox.Show("Error creating thumnail for image '" & fileName & "'. " & e.Message, "Thumbnail creator", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
			Using img As Image = Image.FromFile(fileName)
				Return CreateThumbnail(img, fileName, length, thumbPath)
			End Using
		End Function
	End Class
End Namespace
