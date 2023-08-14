Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors

Namespace PhotoViewer
	Partial Public Class SimpleFilterParams
		Inherits XtraUserControl
		Private filterInfo As FilterInfo

		Public Sub New()
			InitializeComponent()
		End Sub

		Public Overridable Function GetParams() As Object()
			Return New Object() { }
		End Function
		Public Property Filter() As FilterInfo
			Get
				Return filterInfo
			End Get
			Set(ByVal value As FilterInfo)
				filterInfo = value
			End Set
		End Property
		Private imageToFilter_Renamed As Image
		Public Property ImageToFilter() As Image
			Get
				Return imageToFilter_Renamed
			End Get
			Set(ByVal value As Image)
				If ImageToFilter Is value Then
					Return
				End If
				imageToFilter_Renamed = value
				OnImageToFilterChanged()
			End Set
		End Property
		Private Sub OnImageToFilterChanged()
			Dim img As Image = TryCast(pictureEdit1.Tag, Image)
			If img IsNot Nothing Then
				img.Dispose()
			End If
			pictureEdit1.Tag = Nothing
			img = pictureEdit1.Image
			pictureEdit1.Image = Nothing
			If img IsNot Nothing Then
				img.Dispose()
			End If
			If ImageToFilter IsNot Nothing Then
				pictureEdit1.Image = ThumbnailHelper.Default.CreateThumbnail(ImageToFilter, 128)
				UpdatePreview()
			End If
		End Sub
		Public Custom Event ApplyFilter As EventHandler
			AddHandler(ByVal value As EventHandler)
				AddHandler applyFilterButton.Click, value
			End AddHandler
			RemoveHandler(ByVal value As EventHandler)
				RemoveHandler applyFilterButton.Click, value
			End RemoveHandler
			RaiseEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
			End RaiseEvent
		End Event
		Public Overridable Sub UpdatePreview()
			Dim oldImage As Image
			If pictureEdit1.Tag Is Nothing Then
				oldImage = Nothing
			Else
				oldImage = pictureEdit1.Image
			End If
			If pictureEdit1.Tag Is Nothing Then
				pictureEdit1.Tag = pictureEdit1.Image
			End If
			If pictureEdit1.Tag Is Nothing Then
				Return
			End If
			pictureEdit1.Image = FilterHelper.ApplyFilter(Filter.Name, CType(pictureEdit1.Tag, Image), GetParams())
			If oldImage IsNot Nothing Then
				oldImage.Dispose()
			End If
		End Sub
		Protected Overrides Sub OnParentChanged(ByVal e As EventArgs)
			MyBase.OnParentChanged(e)
			If Parent IsNot Nothing AndAlso Filter IsNot Nothing Then
				UpdatePreview()
			ElseIf Parent Is Nothing Then
				ImageToFilter = Nothing
			End If
		End Sub
	End Class
End Namespace
