Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports System.IO

Namespace PhotoViewer
	Partial Public Class FolderGroupCaptionControl
		Inherits PhotoGroupCaptionControlBase
		Public Sub New()
			InitializeComponent()
		End Sub
		Private folderData As PathData
		Public Property Folder() As PathData
			Get
				Return folderData
			End Get
			Set(ByVal value As PathData)
				If Folder Is value Then
					Return
				End If
				folderData = value
				OnFolderChanged()
			End Set
		End Property

		Protected Overridable Sub OnFolderChanged()
			nameLabel.Text = Folder.Name
			dataLabel.Text = Directory.GetCreationTime(Folder.Path).ToShortDateString()
		End Sub

		Private Sub OnFolderIconClick(ByVal sender As Object, ByVal e As EventArgs) Handles groupIcon.Click
			System.Diagnostics.Process.Start(Folder.Path, "")
		End Sub
		Protected Overrides Sub OnRemoveButtonClick(ByVal sender As Object, ByVal e As EventArgs)
			If MainForm IsNot Nothing Then
				MainForm.RemoveFolder(Folder)
			End If
		End Sub
	End Class
End Namespace
