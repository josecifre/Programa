Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors

Namespace PhotoViewer
	Partial Public Class AlbumPropertiesForm
		Inherits XtraForm
		Public Sub New()
			InitializeComponent()
		End Sub
		Public Sub New(ByVal viewData As PhotoViewerData)
			Me.New()
			Me.viewData_Renamed = viewData
		End Sub

		Private viewData_Renamed As PhotoViewerData
		Public Property ViewData() As PhotoViewerData
			Get
				Return viewData_Renamed
			End Get
			Set(ByVal value As PhotoViewerData)
				viewData_Renamed = value
			End Set
		End Property

		Private isEditExistingAlbumMode_Renamed As Boolean
		Public Property IsEditExistingAlbumMode() As Boolean
			Get
				Return isEditExistingAlbumMode_Renamed
			End Get
			Set(ByVal value As Boolean)
				isEditExistingAlbumMode_Renamed = value
			End Set
		End Property

		Private Sub simpleButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton2.Click
			If CheckAlbumProperties() Then
				DialogResult = System.Windows.Forms.DialogResult.OK
				Close()
			End If
		End Sub

		Protected Overridable Function CheckAlbumProperties() As Boolean
			Dim albumName As String = albumNameEdit.Text.Trim()
			Dim messageCaption As String
			If IsEditExistingAlbumMode Then
				messageCaption = "Edit Album"
			Else
				messageCaption = "New Album"
			End If
			If String.IsNullOrEmpty(albumName) Then
				XtraMessageBox.Show(Me, "Error: please type album name.", messageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error)
				Return False
			End If
			For Each album As AlbumData In ViewData.Albums
				If album.Name = albumName AndAlso (Not IsEditExistingAlbumMode) Then
					XtraMessageBox.Show(Me, "Error: album with the name '" & albumNameEdit.Text & "' already exists in albums collection. Please type another name.", messageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error)
					Return False
				End If
			Next album
			Return True
		End Function

		Private Sub NewAlbumForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			albumDate_Renamed.DateTime = DateTime.Now
		End Sub

		Public Property AlbumName() As String
			Get
				Return albumNameEdit.Text
			End Get
			Set(ByVal value As String)
				albumNameEdit.Text = value
			End Set
		End Property
		Public Property AlbumDate() As DateTime
			Get
				Return albumDate_Renamed.DateTime
			End Get
			Set(ByVal value As DateTime)
				albumDate_Renamed.DateTime = value
			End Set
		End Property
		Public Property AlbumDescription() As String
			Get
				Return albumDescription_Renamed.Text
			End Get
			Set(ByVal value As String)
				albumDescription_Renamed.Text = value
			End Set
		End Property
	End Class
End Namespace
