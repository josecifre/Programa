Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms

Namespace PhotoViewer
	Partial Public Class AlbumGroupCaptionControl
		Inherits PhotoGroupCaptionControlBase
		Public Sub New()
			InitializeComponent()
		End Sub

		Private albumData As AlbumData
		Public Property Album() As AlbumData
			Get
				Return albumData
			End Get
			Set(ByVal value As AlbumData)
				If Album Is value Then
					Return
				End If
				albumData = value
				OnAlbumChanged()
			End Set
		End Property

		Protected Overridable Sub OnAlbumChanged()
			nameLabel.Text = Album.Name
			dataLabel.Text = Album.Date.ToLongDateString()
		End Sub
		Protected Overrides Sub OnRemoveButtonClick(ByVal sender As Object, ByVal e As EventArgs)
			If MainForm IsNot Nothing Then
				MainForm.RemoveAlbum(Album)
			End If
		End Sub
		Protected Overrides Sub OnEditButtonClick(ByVal sender As Object, ByVal e As EventArgs)
			If MainForm IsNot Nothing Then
				MainForm.EditAlbum(Album)
			End If
		End Sub
		Public Sub HideEditButtons()
			removeLabel.Visible = False
			editLabel.Visible = False
			separatorLabel.Visible = False
		End Sub
	End Class
End Namespace
