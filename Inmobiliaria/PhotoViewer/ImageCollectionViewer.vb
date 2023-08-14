Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraBars.Ribbon
Imports System.IO
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors.Repository

Namespace PhotoViewer
	Partial Public Class ImageCollectionViewer
		Inherits XtraUserControl
		Private files_Renamed As List(Of String)
		Private thumbPath_Renamed As String
		Public Sub New(ByVal files As List(Of String), ByVal thumbPath As String)
			Me.files_Renamed = files
			Me.thumbPath_Renamed = thumbPath
			InitializeComponent()
			InitializeGallery()
		End Sub

		Public ReadOnly Property Files() As List(Of String)
			Get
				Return files_Renamed
			End Get
		End Property
		Public ReadOnly Property ThumbPath() As String
			Get
				Return thumbPath_Renamed
			End Get
		End Property

		Protected Sub InitializeGallery()
			For Each file As String In Files
				galleryControl1.Gallery.Groups(0).Items.Add(CreateGalleryItem(file))
			Next file
			galleryControl1.Gallery.Groups(0).Items(0).Checked = True
			If Files.Count = 1 Then
				dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float
				dockManager1.RemovePanel(dockPanel1)
			End If
		End Sub

		Protected Overridable Function CreateGalleryItem(ByVal file As String) As GalleryItem
			Dim item As New GalleryItem()
			item.Tag = file
			item.Image = ThumbnailHelper.Default.GetThumbnail(file, 208, ThumbPath)
			Return item
		End Function

		Private Sub galleryControl1_Gallery_ItemCheckedChanged(ByVal sender As Object, ByVal e As GalleryItemEventArgs) Handles galleryControl1.Gallery.ItemCheckedChanged
			If e.Item.Checked Then
				If Parent Is Nothing Then
					UpdateImage()
				Else
					galleryControl1.Gallery.ScrollTo(e.Item, True, DevExpress.Utils.VertAlignment.Center)
				End If
			End If
		End Sub

		Private Sub leftLabel_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim item As GalleryItem = GetCheckedItem()
			Dim itemIndex As Integer = item.GalleryGroup.Items.IndexOf(item)
			itemIndex = Math.Max(0, itemIndex - 1)
			item.GalleryGroup.Items(itemIndex).Checked = True
		End Sub

		Private Sub rightLabel_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim item As GalleryItem = GetCheckedItem()
			Dim itemIndex As Integer = item.GalleryGroup.Items.IndexOf(item)
			itemIndex = Math.Min(item.GalleryGroup.Items.Count - 1, itemIndex + 1)
			item.GalleryGroup.Items(itemIndex).Checked = True
		End Sub

		Protected Overridable Function GetCheckedItem() As GalleryItem
			For Each item As GalleryItem In galleryControl1.Gallery.Groups(0).Items
				If item.Checked Then
					Return item
				End If
			Next item
			Return Nothing
		End Function

		Private Sub galleryControl1_Gallery_EndScroll(ByVal sender As Object, ByVal e As EventArgs) Handles galleryControl1.Gallery.EndScroll
			BeginInvoke(New MethodInvoker(AddressOf UpdateImage))
		End Sub
		Public Sub UpdateImage()
			pictureEdit1.LoadAsync(CStr(GetCheckedItem().Tag))
		End Sub
		Private Sub UpdatePreviewImage()
			If dockPanel2_Container.Controls.Count > 0 Then
				Dim fp As SimpleFilterParams = CType(dockPanel2_Container.Controls(0), SimpleFilterParams)
				fp.ImageToFilter = pictureEdit1.Image
			End If
		End Sub
		Public Sub SetFilter(ByVal info As FilterInfo)
            If dockPanel2_Container.Controls.Count > 0 Then
                Dim paramsControl As SimpleFilterParams = TryCast(dockPanel2_Container.Controls(0), SimpleFilterParams)
                If Not IsNothing(paramsControl) Then
                    RemoveHandler paramsControl.ApplyFilter, AddressOf OnApplyFilter
                    dockPanel2_Container.Controls.Remove(paramsControl)
                    paramsControl.Dispose()
                End If
                dockPanel2_Container.Controls.Clear()
            End If
            dockPanel2_Container.Controls.Clear()
            If info IsNot Nothing Then
                Dim pc As SimpleFilterParams = info.CreateParamsControl()
                pc.Dock = DockStyle.Fill
                AddHandler pc.ApplyFilter, AddressOf OnApplyFilter
                dockPanel2.Text = info.Name
                dockPanel2_Container.Controls.Add(pc)
                UpdatePreviewImage()
            End If
		End Sub
		Protected Overrides Sub OnParentChanged(ByVal e As EventArgs)
			MyBase.OnParentChanged(e)
			If Parent Is Nothing AndAlso dockPanel2_Container.Controls.Count > 0 Then
				RemoveHandler (CType(dockPanel2_Container.Controls(0), SimpleFilterParams)).ApplyFilter, AddressOf OnApplyFilter
			End If
		End Sub
		Private Sub OnApplyFilter(ByVal sender As Object, ByVal e As EventArgs)
			Dim paramsControl As SimpleFilterParams = TryCast(dockPanel2_Container.Controls(0), SimpleFilterParams)
			If paramsControl Is Nothing Then
				Return
			End If
			Dim oldImage As Image
			If pictureEdit1.Tag Is Nothing Then
				oldImage = Nothing
			Else
				oldImage = pictureEdit1.Image
			End If
			If pictureEdit1.Tag Is Nothing Then
				pictureEdit1.Tag = pictureEdit1.Image
			End If
			pictureEdit1.Image = FilterHelper.ApplyFilter(paramsControl.Filter.Name, pictureEdit1.Image, paramsControl.GetParams())
			If oldImage IsNot Nothing Then
				oldImage.Dispose()
			End If
			Dim form As MainForm = CType(FindForm(), MainForm)
			form.UpdateCancelButtonEnabledState()
		End Sub

		Public Sub CancelFilters()
			Dim oldImage As Image = pictureEdit1.Image
			If pictureEdit1.Tag IsNot Nothing Then
				pictureEdit1.Image = CType(pictureEdit1.Tag, Image)
				pictureEdit1.Tag = Nothing
			End If
		End Sub
		Friend Function IsImageFilterd() As Boolean
			Return pictureEdit1.Tag IsNot Nothing
		End Function

		Private Sub pictureEdit1_LoadCompleted(ByVal sender As Object, ByVal e As EventArgs) Handles pictureEdit1.LoadCompleted
			UpdatePreviewImage()
        End Sub
        Friend Sub SetMenuManager(ByVal ribbonBarManager As RibbonBarManager)
            pictureEdit1.MenuManager = ribbonBarManager
        End Sub
    End Class
End Namespace
