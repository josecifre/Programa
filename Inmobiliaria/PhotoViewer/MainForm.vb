Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraBars
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports System.IO
Imports DevExpress.XtraNavBar
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraBars.Ribbon.ViewInfo
Imports System.Drawing.Printing
Imports DevExpress.XtraTab
Imports DevExpress.Utils
Imports System.Collections
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.XtraSplashScreen

Namespace PhotoViewer
    Partial Public Class MainForm
        Inherits RibbonForm
        Public Shared HoverSkinImageSize As New Size(116, 86)
        Public Shared SkinImageSize As New Size(58, 43)

        Public Sub New()
            InitializeComponent()
            '  InitSkins()
            InitFilters()
            SelectDefaultPage()
            LoadData()
            UpdateItemsEnabledState()
            UpdateAddToLibraryItem(biAddFolder)
        End Sub
        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
            MyBase.OnLoad(e)
            SplashScreenManager.CloseForm()
        End Sub

        Private viewData_Renamed As PhotoViewerData
        Private rightClickItem_Renamed As GalleryItem
        Private lastSelectedGroup As NavBarGroup
        Private customizableLink_Renamed As NavBarItemLink
        Private markedItems_Renamed As List(Of GalleryItem)
        Private zoomControl_Renamed As ZoomTrackBarControl

        Private ReadOnly Property ZoomControl() As ZoomTrackBarControl
            Get
                Return zoomControl_Renamed
            End Get
        End Property
        Protected ReadOnly Property MarkedItems() As List(Of GalleryItem)
            Get
                If markedItems_Renamed Is Nothing Then
                    markedItems_Renamed = New List(Of GalleryItem)()
                End If
                Return markedItems_Renamed
            End Get
        End Property
        Protected ReadOnly Property ViewData() As PhotoViewerData
            Get
                If viewData_Renamed Is Nothing Then
                    viewData_Renamed = New PhotoViewerData()
                End If
                Return viewData_Renamed
            End Get
        End Property
        Protected Function GetDataDir() As String
            Dim path As String = AppDomain.CurrentDomain.BaseDirectory
            'For i As Integer = 0 To 9
            '    path &= "..\"
            '    If Directory.Exists(path & "Data") Then
            Return path & "Data"
            '    End If
            'Next i
            'Return String.Empty
        End Function
        Protected ReadOnly Property DataPath() As String
            Get
                Dim dataPathLocal As String = GetDataDir() & "\PhotoViewer"
                If Directory.Exists(dataPathLocal) Then
                    Return dataPathLocal
                End If
                Return String.Empty
            End Get
        End Property
        Protected ReadOnly Property ThumbPath() As String
            Get
                Return DataPath & "\Thumbs\"
            End Get
        End Property
        Protected ReadOnly Property ViewDataFile() As String
            Get
                Return DataPath & "\data.xml"
            End Get
        End Property
        Protected Property RightClickItem() As GalleryItem
            Get
                Return rightClickItem_Renamed
            End Get
            Set(ByVal value As GalleryItem)
                rightClickItem_Renamed = value
            End Set
        End Property
        Protected ReadOnly Property SelectedAlbum() As AlbumData
            Get
                Dim album As AlbumData
                If CustomizableLink Is Nothing Then
                    album = Nothing
                Else
                    album = TryCast(CustomizableLink.Item.Tag, AlbumData)
                End If
                If album Is Nothing Then
                    If albumGroup.SelectedLink Is Nothing Then
                        album = Nothing
                    Else
                        album = CType(albumGroup.SelectedLink.Item.Tag, AlbumData)
                    End If
                End If
                Return album
            End Get
        End Property
        Protected Property CustomizableLink() As NavBarItemLink
            Get
                Return customizableLink_Renamed
            End Get
            Set(ByVal value As NavBarItemLink)
                customizableLink_Renamed = value
            End Set
        End Property

        Private Sub SaveData()
            ViewData.FirstRun = False
            ViewData.SaveLayoutToXml(ViewDataFile)
        End Sub
        Private Sub LoadData()
            ViewData.Clear()
            Dim forceProcess As Boolean = False
            If File.Exists(ViewDataFile) Then
                ViewData.RestoreLayoutFromXml(ViewDataFile)
            End If
            If ViewData.FirstRun Then
                GenerateSampleData()
                forceProcess = True
            End If
            InitNavBar()
            UpdateMainGalleryContent(forceProcess)
        End Sub
        Protected Sub UpdateData()
            UpdateData(False)
        End Sub
        Protected Sub UpdateData(ByVal onlyAlbums As Boolean)
            SaveData()
            InitNavBar(onlyAlbums)
        End Sub

        Private Sub InitSkins()
            SkinHelper.InitSkinGallery(skinGalleryBarItem, True)
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style")
        End Sub
        Private Function GetSkinImage(ByVal userLF As UserLookAndFeel, ByVal sz As Size, ByVal indent As Integer) As Bitmap
            Dim image As New Bitmap(sz.Width, sz.Height)
            Using g As Graphics = Graphics.FromImage(image)
                Dim info As New StyleObjectInfoArgs(New GraphicsCache(g))
                info.Bounds = New Rectangle(Point.Empty, sz)
                userLF.Painter.Button.DrawObject(info)
                info.Bounds = New Rectangle(indent, indent, sz.Width - indent * 2, sz.Height - indent * 2)
            End Using
            Return image
        End Function
        Protected Overridable Sub InitFilters()
            Dim imageSize As Size = My.Resources.FilterSample.Size
            imageSize.Width = CInt(Fix(imageSize.Width * 0.5))
            imageSize.Height = CInt(Fix(imageSize.Height * 0.5))
            filtersGallery.Gallery.ImageSize = imageSize
            filtersGallery.Gallery.Images = FilterHelper.GetFiltersSamples(My.Resources.FilterSample)
            filtersGallery.Gallery.HoverImages = filtersGallery.Gallery.Images
            For Each fInfo As FilterInfo In FilterHelper.Filters
                filtersGallery.Gallery.Groups(0).Items.Add(CreateFilterGalleryItem(fInfo))
            Next fInfo
        End Sub
        Private Sub InitNavBar()
            InitNavBar(False)
        End Sub
        Private Sub InitNavBar(ByVal onlyAlbums As Boolean)
            navBarControl1.SelectedLink = Nothing
            For Each group As NavBarGroup In navBarControl1.Groups
                If onlyAlbums AndAlso group IsNot albumGroup Then
                    Continue For
                End If
                For i As Integer = group.ItemLinks.Count - 1 To 0 Step -1
                    navBarControl1.Items.Remove(group.ItemLinks(i).Item)
                Next i
            Next group
            navBarControl1.BeginUpdate()
            Try
                For Each album As AlbumData In ViewData.Albums
                    Dim item As NavBarItem = CreateAlbumItem(album)
                    navBarControl1.Items.Add(item)
                    albumGroup.ItemLinks.Add(item)
                Next album
                If onlyAlbums Then
                    Return
                End If
                For Each folder As PathData In ViewData.Folders
                    Dim item As NavBarItem = CreateFolderItem(folder)
                    If item IsNot Nothing Then
                        navBarControl1.Items.Add(item)
                        foldersGroup.ItemLinks.Add(item)
                    End If
                Next folder
                For Each file As PathData In ViewData.Others.Files
                    Dim item As NavBarItem = CreateFolderItem(file)
                    If item IsNot Nothing Then
                        navBarControl1.Items.Add(item)
                        othersGroup.ItemLinks.Add(item)
                    End If
                Next file
            Finally
                navBarControl1.EndUpdate()
            End Try
            If navBarControl1.Items.Count > 0 Then
                navBarControl1.SelectedLink = navBarControl1.Items(0).Links(0)
            End If
        End Sub
        Private Sub SelectDefaultPage()
            ribbonControl1.SelectedPage = imagePage
        End Sub

        Private Function CreateFilterGalleryItem(ByVal info As FilterInfo) As GalleryItem
            Dim item As New GalleryItem()
            item.ImageIndex = FilterHelper.Filters.IndexOf(info)
            item.HoverImageIndex = item.ImageIndex
            item.Caption = info.Name
            item.Tag = info
            item.Hint = info.Name
            Return item
        End Function
        Private Function CreateFolderItem(ByVal folder As PathData) As NavBarItem
            Dim item As New NavBarItem()
            item.Caption = folder.Name
            item.Hint = folder.Path
            item.Tag = folder
            AddHandler item.LinkClicked, AddressOf OnFolderLinkClicked
            Return item
        End Function
        Private Function CreateAlbumItem(ByVal album As AlbumData) As NavBarItem
            Dim item As New NavBarItem()
            item.Caption = album.Name
            item.Hint = album.Description
            item.Tag = album
            AddHandler item.LinkClicked, AddressOf OnAlbumLinkClicked
            Return item
        End Function
        Private Function CreatePhotoGalleryItem(ByVal fileName As String) As GalleryItem
            Dim item As New GalleryItem()
            item.Caption = Path.GetFileName(fileName)
            item.Hint = fileName
            item.Image = ThumbnailHelper.Default.GetThumbnail(fileName, 208, ThumbPath)
            item.Tag = fileName
            Return item
        End Function
        Private Function CreateFolderGroup(ByVal folder As PathData) As GalleryItemGroup
            Dim group As New GalleryItemGroup()
            group.Tag = folder
            group.Caption = folder.Name
            group.CaptionAlignment = GalleryItemGroupCaptionAlignment.Stretch
            group.CaptionControl = CreateFolderGroupCaptionControl(folder)
            Return group
        End Function
        Private Function CreateFolderGroupCaptionControl(ByVal folder As PathData) As Control
            Dim control As New FolderGroupCaptionControl()
            control.Folder = folder
            control.MainForm = Me
            Return control
        End Function
        Private Function CreateAlbumGroup(ByVal albumData As AlbumData) As GalleryItemGroup
            Dim group As New GalleryItemGroup()
            group.Tag = albumData
            group.Caption = albumData.Name
            group.CaptionAlignment = GalleryItemGroupCaptionAlignment.Stretch
            group.CaptionControl = CreateAlbumGroupCaptionControl(albumData)
            Return group
        End Function
        Private Function CreateAlbumGroupCaptionControl(ByVal albumData As AlbumData) As Control
            Dim control As New AlbumGroupCaptionControl()
            control.Album = albumData
            control.MainForm = Me
            Return control
        End Function
        Private Function CreateSelectionItem(ByVal galleryItem As GalleryItem) As GalleryItem
            Dim item As New GalleryItem()
            item.Image = galleryItem.Image
            item.Hint = galleryItem.Hint
            item.Tag = galleryItem
            Return item
        End Function
        Private Function CreateAddToAlbumItem(ByVal album As AlbumData) As BarItem
            Dim item As BarButtonItem
            If album IsNot Nothing Then
                item = New BarButtonItem(ribbonControl1.Manager, album.Name)
            Else
                item = New BarButtonItem(ribbonControl1.Manager, "New album...")
            End If
            AddHandler item.ItemClick, AddressOf OnAddToAlbumItemClick
            item.Tag = album
            Return item
        End Function
        Private Function CreateFilePathData(ByVal fileName As String) As PathData
            Dim pdata As New PathData()
            pdata.Path = fileName
            pdata.Name = Path.GetFileName(fileName)
            Return pdata
        End Function
        Protected Overridable Sub CreateThumbForFiles(ByVal files As List(Of String), ByVal progressText As String)
            Dim pf As New ProgressForm()
            pf.ProgressControl.Maximum = files.Count
            pf.ProgressControl.ProgressText = progressText
            pf.Show(Me)
            For Each fileName As String In files
                CreateThumbForFile(fileName)
                pf.ProgressControl.Value += 1
                Application.DoEvents()
            Next fileName
            pf.Close()
        End Sub
        Protected Overridable Sub CreateThumbForFile(ByVal fileName As String)
            Dim img As Image = ThumbnailHelper.Default.GetThumbnail(fileName, 208, ThumbPath)
            If img IsNot Nothing Then
                img.Dispose()
            End If
        End Sub
        Protected Overridable Sub CreateThumbsForFolder(ByVal folder As PathData)
            CreateThumbForFiles(GetImagesInFolder(folder), "Processing folder")
        End Sub
        Private Sub OnFolderLinkClicked(ByVal sender As Object, ByVal e As NavBarLinkEventArgs)
        End Sub
        Private Sub OnAlbumLinkClicked(ByVal sender As Object, ByVal e As NavBarLinkEventArgs)
        End Sub
        Private Overloads Sub OnFormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
            If File.Exists(ViewDataFile) Then
                ViewData.SaveLayoutToXml(ViewDataFile)
            End If
        End Sub
        Sub OnExit()
            If XtraMessageBox.Show(Me, "Exit Application?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                Close()
            End If
        End Sub
        Private Sub OnExitItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles biExit.ItemClick
            OnExit()
        End Sub
        Private Sub OnExitButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles exitButton.Click
            OnExit()
        End Sub
        Private Sub OnNewAlbumItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles biNewAlbum.ItemClick
            AddNewAlbum()
        End Sub
        Private Sub OnAddFolderItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles biAddFolder.ItemClick
            If folderBrowserDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                If (Not IsFolderAdded(folderBrowserDialog1.SelectedPath)) Then
                    Dim p As New PathData()
                    p.Name = Path.GetFileName(folderBrowserDialog1.SelectedPath)
                    p.Path = folderBrowserDialog1.SelectedPath
                    ViewData.Folders.Add(p)
                    CreateThumbsForFolder(p)
                    UpdateData()
                    navBarControl1.SelectedLink = GetLink(p)
                    UpdateMainGalleryContent(True)
                End If
                UpdateAddToLibraryItem(e.Item)
            End If
        End Sub
        Private Function GetLink(ByVal fileName As String) As NavBarItemLink
            For Each link As NavBarItemLink In othersGroup.ItemLinks
                If (CType(link.Item.Tag, PathData)).Path = fileName Then
                    Return link
                End If
            Next link
            Return Nothing
        End Function
        Private Function GetLinkByTag(ByVal group As NavBarGroup, ByVal tag As Object) As NavBarItemLink
            For Each link As NavBarItemLink In group.ItemLinks
                If link.Item.Tag Is tag Then
                    Return link
                End If
            Next link
            Return Nothing
        End Function
        Private Function GetLink(ByVal album As AlbumData) As NavBarItemLink
            Return GetLinkByTag(albumGroup, album)
        End Function
        Private Function GetLink(ByVal path As PathData) As NavBarItemLink
            Return GetLinkByTag(foldersGroup, path)
        End Function
        Private Sub OnAddFileClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles biAddFile.ItemClick
            If imageDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim lastFileName As String = String.Empty
                For Each fileName As String In imageDialog.FileNames
                    If (Not IsFileAdded(fileName)) Then
                        Dim p As New PathData()
                        p.Name = Path.GetFileName(fileName)
                        p.Path = fileName
                        ViewData.Others.Files.Add(p)
                    End If
                    lastFileName = fileName
                Next fileName
                CreateThumbForFiles(New List(Of String)(imageDialog.FileNames), "Processing files")
                UpdateData()
                navBarControl1.SelectedLink = GetLink(lastFileName)
                UpdateMainGalleryContent(True)
            End If
            UpdateAddToLibraryItem(e.Item)
        End Sub

        Private Sub OnNavBarControl1SelectedLinkChanged(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.ViewInfo.NavBarSelectedLinkChangedEventArgs) Handles navBarControl1.SelectedLinkChanged
            UpdateMainGalleryContent(False)
            lastSelectedGroup = e.Group
        End Sub
        Private Sub OnNavBarControl1MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles navBarControl1.MouseDown
            If e.Button <> MouseButtons.Right Then
                Return
            End If
            Dim hi As NavBarHitInfo = navBarControl1.GetViewInfo().CalcHitInfo(e.Location)
            If hi.Link Is Nothing Then
                Me.ribbonControl1.Manager.SetPopupContextMenu(Me.navBarControl1, Nothing)
                Return
            End If
            CustomizableLink = hi.Link
            If hi.Group Is albumGroup Then
                Me.ribbonControl1.Manager.SetPopupContextMenu(Me.navBarControl1, Me.albumPopupMenu)
            ElseIf hi.Group Is foldersGroup Then
                Me.ribbonControl1.Manager.SetPopupContextMenu(Me.navBarControl1, Me.folderPopupMenu)
            End If
        End Sub
        Private Sub OnRemoveAlbumItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles biRemoveAlbum.ItemClick
            If CustomizableLink Is Nothing Then
                Return
            End If
            Dim album As AlbumData = CType(customizableLink_Renamed.Item.Tag, AlbumData)
            RemoveAlbum(album)
        End Sub
        Private Sub OnRemoveFolderItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles biRemoveFolder.ItemClick
            If CustomizableLink Is Nothing Then
                Return
            End If
            Dim folder As PathData = CType(customizableLink_Renamed.Item.Tag, PathData)
            RemoveFolder(folder)
        End Sub
        Private Sub OnMainGalleryItemCheckedChanged(ByVal sender As Object, ByVal e As GalleryItemEventArgs) Handles mainGallery.Gallery.ItemCheckedChanged
            UpdateImageButtonsEnabledState()
            UpdateSelectedPictureEdit(e)
        End Sub
        Private Sub OnMainGalleryMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles mainGallery.MouseDown
            Dim hi As RibbonHitInfo = mainGallery.CalcHitInfo(e.Location)
            If (Not hi.InGalleryItem) Then
                ClearGalleryItemsCheckState(mainGallery)
            Else
                If e.Button = MouseButtons.Right Then
                    RightClickItem = hi.GalleryItem
                    ribbonControl1.Manager.SetPopupContextMenu(mainGallery, galleryItemMenu)
                    Return
                End If
            End If
        End Sub
        Private Sub OnMarkItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles biMark.ItemClick
            Dim items As List(Of GalleryItem) = mainGallery.Gallery.GetCheckedItems()
            MarkItems(items)
            mainGallery.Refresh()
        End Sub
        Private Sub OnSelectionGalleryCustomDrawItemImage(ByVal sender As Object, ByVal e As GalleryItemCustomDrawEventArgs)
            If (Not MarkedItems.Contains(e.Item)) Then
                Return
            End If
            e.Cache.Graphics.DrawImage(e.Item.Image, (CType(e.ItemInfo, GalleryItemViewInfo)).ImageContentBounds)
            DrawMarkedIconInSelection(e.Cache, (CType(e.ItemInfo, GalleryItemViewInfo)).ImageClientBounds)
            e.Handled = True
        End Sub
        Private Sub OnMainGalleryCustomDrawItemImage(ByVal sender As Object, ByVal e As GalleryItemCustomDrawEventArgs) Handles mainGallery.Gallery.CustomDrawItemImage
            If (Not MarkedItems.Contains(e.Item)) Then
                Return
            End If
            e.Cache.Graphics.DrawImage(e.Item.Image, (CType(e.ItemInfo, GalleryItemViewInfo)).ImageContentBounds)
            DrawMarkedIcon(e.Cache, (CType(e.ItemInfo, GalleryItemViewInfo)).ImageContentBounds)
            e.Handled = True
        End Sub
        Private Sub OnUnmarkAllItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles biUnmarkAll.ItemClick
            UnmarkItems()
            mainGallery.Refresh()
        End Sub
        Private Sub OnUnmarkItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles biUnmark.ItemClick
            Dim items As List(Of GalleryItem) = mainGallery.Gallery.GetCheckedItems()
            UnmarkItems(items)
            mainGallery.Refresh()
        End Sub
        Private Sub OnAddToAlbumButtonShowDropDownControl(ByVal sender As Object, ByVal e As ShowDropDownControlEventArgs)
            UpdateAlbumsMenu()
        End Sub
        Private Sub OnAddToAlbumItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs)
            Dim album As AlbumData = TryCast(e.Item.Tag, AlbumData)
            If album Is Nothing Then
                album = AddNewAlbum()
            End If
            If album Is Nothing Then
                Return
            End If
            Dim items As List(Of GalleryItem) = mainGallery.Gallery.GetCheckedItems()
            For Each item As GalleryItem In items
                If (Not album.Files.Contains(CStr(item.Tag))) Then
                    album.Files.Add(CreateFilePathData(CStr(item.Tag)))
                End If
            Next item
        End Sub
        Private Sub OnZoomTackValueChanged(ByVal sender As Object, ByVal e As EventArgs)
            mainGallery.Gallery.ImageSize = New Size(ZoomControl.Value, ZoomControl.Value)
        End Sub
        Private Sub OnViewImageItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs)
            Dim fileName As String = (CStr(RightClickItem.Tag))
            Dim files As List(Of String) = New List(Of String)(1)
            files.Add(fileName)
            ViewSelectedImages(Path.GetFileName(fileName), fileName, files)
        End Sub
        Private Sub OnTabControlCloseButtonClick(ByVal sender As Object, ByVal e As EventArgs)
            CloseSelectedTabPage()
        End Sub
        Private Sub OnEditAlbumItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles biEditAlbum.ItemClick
            EditAlbum()
        End Sub
        Private Sub OnAlbumPopupMenuCloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles albumPopupMenu.CloseUp
            CustomizableLink = Nothing
        End Sub
        Private Sub OnViewSelectedImagesItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles biView.ItemClick
            Dim files As List(Of String) = GetFilesInSelection()
            If files.Count = 0 Then
                XtraMessageBox.Show(Me, "None of images selected.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            Dim tabName As String
            If files.Count > 1 Then
                tabName = "Collection"
            Else
                tabName = Path.GetFileName(files(0))
            End If
            ViewSelectedImages(tabName, "", files)
        End Sub
        Private Sub OnAboutItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles biAbout.ItemClick
            DevExpress.Utils.About.AboutForm.Show(New DevExpress.Utils.About.ProductInfo(String.Empty, GetType(MainForm), DevExpress.Utils.About.ProductKind.XtraBars, DevExpress.Utils.About.ProductInfoStage.Registered))
        End Sub
        Private Function GetCheckedImages() As List(Of Image)
            Dim items As List(Of GalleryItem) = mainGallery.Gallery.GetCheckedItems()
            Dim images As List(Of Image) = New List(Of Image)(items.Count)
            For Each item As GalleryItem In items
                images.Add(Image.FromFile(CStr(item.Tag)))
            Next item
            Return images
        End Function
        Private Sub OnPrintItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles biPrint.ItemClick
            Dim images As List(Of Image) = GetCheckedImages()
            Dim ps As New PrintingSystem()

            ps.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A5
            ps.PageSettings.Landscape = True
            ps.PageSettings.LeftMargin = 0
            ps.PageSettings.RightMargin = 0
            ps.PageSettings.TopMargin = 0
            ps.PageSettings.BottomMargin = 0

            Dim gr As BrickGraphics = ps.Graph
            ps.Begin()


            Dim offsetY As Single = 0
            For Each image As Image In images
                Dim imageBrick As New ImageBrick()
                imageBrick.Image = image
                imageBrick.BorderWidth = 0
                imageBrick.BorderStyle = BrickBorderStyle.Inset
                imageBrick.Sides = BorderSide.All

                imageBrick.SizeMode = ImageSizeMode.Squeeze
                gr.DrawBrick(imageBrick, New RectangleF(New PointF(0, offsetY), ps.PageSettings.UsablePageSizeInPixels))
                offsetY += ps.PageSettings.UsablePageSizeInPixels.Height
            Next image
            ps.End()

            CType(New PrintTool(ps), PrintTool).ShowPreviewDialog()
        End Sub
        Private Sub OnExportItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles biExportFolder.ItemClick
            XtraMessageBox.Show(Me, "Here you can show your own export dialog.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub
        Private Sub OnEmailItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles biEmail.ItemClick
            XtraMessageBox.Show(Me, "Here you can make preparations for e-mail.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub
        Private Sub OnUploadItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles biUpload.ItemClick
            XtraMessageBox.Show(Me, "Here you can show your own upload settings dialog.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub
        Private Sub OnCollageItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles biCollage.ItemClick
            XtraMessageBox.Show(Me, "Here you can show your own collage settings dialog.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub
        Private Sub OnSlideShowItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles biSlideShow.ItemClick
            XtraMessageBox.Show(Me, "Here you can show your own slideshow settings dialog.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub
        Private Sub OnFilmItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles biFilm.ItemClick
            XtraMessageBox.Show(Me, "Here you can show your own film settings dialog.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub
        Private Sub OnMainTabSelectedPageChanged(ByVal sender As Object, ByVal e As EventArgs) Handles controlPresenter1.SelectedControlChanged
            If controlPresenter1.SelectedControl IsNot libraryPanel Then
                ShowViewCategory()
            Else
                HideViewCategory()
            End If
        End Sub
        Private Sub OnCloseImageItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles biClose.ItemClick
            CloseSelectedTabPage()
        End Sub
        Private Sub OnSaveImageItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles biSaveImage.ItemClick
            XtraMessageBox.Show(Me, "SaveImageItemClick", "PhotoViewer", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub
        Private Sub OnCancelFilterItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles biCancel.ItemClick
            Dim imageCollectionViewer As ImageCollectionViewer = TryCast(controlPresenter1.SelectedControl, ImageCollectionViewer)
            If imageCollectionViewer Is Nothing Then
                Return
            End If
            imageCollectionViewer.CancelFilters()
            UpdateCancelButtonEnabledState()
        End Sub
        Private Sub OnAddToAlbumItemPress(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles biAddToAlbum.ItemPress
            UpdateAlbumsMenu()
        End Sub
        Private Sub OnFiltersGalleryInitDropDown(ByVal sender As Object, ByVal e As InplaceGalleryEventArgs) Handles filtersGallery.Gallery.InitDropDownGallery
            e.PopupGallery.AllowHoverImages = False
            e.PopupGallery.ImageSize = My.Resources.FilterSample.Size
            e.PopupGallery.ShowItemText = True
            e.PopupGallery.ItemImageLocation = Locations.Top
            e.PopupGallery.SynchWithInRibbonGallery = True
        End Sub
        Private Sub OnFilterGalleryItemCheckedChanged(ByVal sender As Object, ByVal e As GalleryItemEventArgs) Handles filtersGallery.GalleryItemCheckedChanged
            Dim imageCollectionViewer As ImageCollectionViewer = TryCast(controlPresenter1.SelectedControl, ImageCollectionViewer)
            If imageCollectionViewer Is Nothing OrElse (Not e.Item.Checked) Then
                Return
            End If
            imageCollectionViewer.SetFilter(CType(e.Item.Tag, FilterInfo))
        End Sub
        Private Sub OnRibbonControlSelectedPageChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ribbonControl1.SelectedPageChanged
            Dim page As Control = TryCast(ribbonControl1.SelectedPage.Tag, Control)
            If page Is Nothing Then
                page = libraryPanel
            End If
            controlPresenter1.SelectedControl = page
            UpdateItemsEnabledState()
            If page Is libraryPanel Then
                beZoom.Visibility = BarItemVisibility.Always
            Else
                beZoom.Visibility = BarItemVisibility.Never
            End If
        End Sub
        Private Sub OnAddToLibraryItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles biAddToLibrary.ItemClick
            Dim item As BarItem = TryCast(biAddToLibrary.Tag, BarItem)
            If item IsNot Nothing Then
                item.PerformClick()
            End If
        End Sub
        Private Sub OnMainGalleryDoubleClick(ByVal sender As Object, ByVal e As GalleryItemClickEventArgs) Handles mainGallery.Gallery.ItemDoubleClick
            e.Item.Checked = True
            Dim fileName As String = (CStr(e.Item.Tag))
            Dim files As List(Of String) = New List(Of String)(1)
            files.Add(fileName)
            ViewSelectedImages(Path.GetFileName(fileName), fileName, files)
        End Sub
        Private Sub OnFilterByMarkedCheckedChanged(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles biFilterByMarked.CheckedChanged
            FilterByMarked(biFilterByMarked.Checked)
        End Sub
        Private Sub OnGenerateDataItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles biGenerateData.ItemClick
            If XtraMessageBox.Show(Me, "Are you sure you want generate data? Current data will be lost.", Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
                Return
            End If
            GenerateSampleData()
        End Sub
        Private Sub OnRemoveFromAlbumItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles biRemoveFromAlbum.ItemClick
            Dim items As List(Of GalleryItem) = mainGallery.Gallery.GetCheckedItems()
            If items.Count = 0 Then
                Return
            End If
            RemoveImagesFromAlbum(items)
        End Sub
        Private Sub ScrollToFolder(ByVal path As PathData, ByVal bAnimated As Boolean)
            mainGallery.Gallery.ScrollTo(GetGalleryGroupByTag(path), bAnimated)
        End Sub
        Private Sub ScrollToFile(ByVal fileName As String, ByVal bAnimated As Boolean)
            mainGallery.Gallery.ScrollTo(GetGalleryItemByTag(fileName), bAnimated)
        End Sub
        Private Sub ScrollToAlbum(ByVal album As AlbumData, ByVal bAnimated As Boolean)
            mainGallery.Gallery.ScrollTo(GetGalleryGroupByTag(album), bAnimated)
        End Sub

        Private Sub ProcessAlbums()
            mainGallery.Gallery.BeginUpdate()
            Try
                ClearGalleryAndImages()
                For Each album As AlbumData In ViewData.Albums
                    ProcessAlbum(album)
                Next album
            Finally
                mainGallery.Gallery.EndUpdate()
            End Try
        End Sub
        Private Sub ProcessAlbum(ByVal albumData As AlbumData, ByVal showEditButtons As Boolean)
            Dim group As GalleryItemGroup = CreateAlbumGroup(albumData)
            Dim control As AlbumGroupCaptionControl = CType(group.CaptionControl, AlbumGroupCaptionControl)
            If (Not showEditButtons) Then
                control.HideEditButtons()
            End If
            mainGallery.Gallery.Groups.Add(group)
            For Each pData As PathData In albumData.Files
                group.Items.Add(CreatePhotoGalleryItem(pData.Path))
            Next pData
        End Sub
        Private Sub ProcessAlbum(ByVal albumData As AlbumData)
            ProcessAlbum(albumData, True)
        End Sub
        Private Sub ProcessOthers()
            mainGallery.Gallery.BeginUpdate()
            Try
                ClearGalleryAndImages()
                ProcessAlbum(ViewData.Others, False)
            Finally
                mainGallery.Gallery.EndUpdate()
            End Try
        End Sub
        Private Sub ProcessFolder(ByVal folder As PathData)

            Dim group As GalleryItemGroup = CreateFolderGroup(folder)
            mainGallery.Gallery.Groups.Add(group)

            Dim files As List(Of String) = GetImagesInFolder(folder)
            For Each fileName As String In files
                group.Items.Add(CreatePhotoGalleryItem(fileName))
            Next fileName
        End Sub
        Private Sub ProcessFolders()
            mainGallery.Gallery.BeginUpdate()
            Try
                ClearGalleryAndImages()
                For Each pData As PathData In ViewData.Folders
                    ProcessFolder(pData)
                Next pData
            Finally
                mainGallery.Gallery.EndUpdate()
            End Try
        End Sub
        Private Function AddNewAlbum() As AlbumData
            Dim form As New AlbumPropertiesForm(ViewData)
            form.Text = "New album properties"
            form.Owner = Me
            If form.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim album As New AlbumData()
                album.Name = form.AlbumName
                album.Date = form.AlbumDate
                album.Description = form.AlbumDescription
                ViewData.Albums.Add(album)
                UpdateData(True)
                navBarControl1.SelectedLink = GetLink(album)
                UpdateMainGalleryContent(True)
                Return album
            End If
            Return Nothing
        End Function
        Friend Sub EditAlbum(ByVal album As AlbumData)
            If album Is Nothing Then
                Return
            End If
            Dim form As New AlbumPropertiesForm(ViewData)
            form.Text = "Edit album properties"
            form.Owner = Me
            form.AlbumName = album.Name
            form.AlbumDate = album.Date
            form.AlbumDescription = album.Description
            form.IsEditExistingAlbumMode = True
            If form.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                album.Name = form.AlbumName
                album.Date = form.AlbumDate
                album.Description = form.AlbumDescription
                UpdateData(True)
                For Each link As NavBarItemLink In navBarControl1.Groups(0).ItemLinks
                    If link.Item.Tag Is album Then
                        navBarControl1.Groups(0).SelectedLink = link
                        UpdateMainGalleryContent(True)
                        Exit For
                    End If
                Next link
            End If
        End Sub
        Friend Sub EditAlbum()
            EditAlbum(SelectedAlbum)
        End Sub
        Friend Sub RemoveAlbum(ByVal album As AlbumData)
            If XtraMessageBox.Show(Me, "Are you really want to remove album?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                ViewData.Albums.Remove(album)
                UpdateData()
                UpdateMainGalleryContent(True)
            End If
        End Sub
        Friend Sub RemoveFolder(ByVal folder As PathData)
            If XtraMessageBox.Show(Me, "Are you really want to remove folder?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                ViewData.Folders.Remove(folder)
                UpdateData()
                UpdateMainGalleryContent(True)
            End If
        End Sub
        Private Sub MarkItems(ByVal items As List(Of GalleryItem))
            For Each item As GalleryItem In items
                If (Not MarkedItems.Contains(item)) Then
                    MarkedItems.Add(item)
                End If
            Next item
        End Sub
        Private Sub UnmarkItems(ByVal items As List(Of GalleryItem))
            For Each item As GalleryItem In items
                MarkedItems.Remove(item)
            Next item
        End Sub
        Private Sub UnmarkItems()
            MarkedItems.Clear()
        End Sub
        Private Function IsPathAdded(ByVal path As String, ByVal coll As PathCollection) As Boolean
            For Each p As PathData In coll
                If p.Path = path Then
                    Return True
                End If
            Next p
            Return False
        End Function
        Private Function IsFolderAdded(ByVal folderPath As String) As Boolean
            Return IsPathAdded(folderPath, ViewData.Folders)
        End Function
        Private Function IsFileAdded(ByVal fileName As String) As Boolean
            Return IsPathAdded(fileName, ViewData.Others.Files)
        End Function
        Private Sub ClearGalleryAndImages()
            mainGallery.Gallery.Groups.Clear()
            For Each group As GalleryItemGroup In mainGallery.Gallery.Groups
                If group.CaptionControl IsNot Nothing Then
                    group.CaptionControl.Dispose()
                    group.CaptionControl = Nothing
                    For Each item As GalleryItem In group.Items
                        If item.Image IsNot Nothing Then
                            item.Image.Dispose()
                            item.Image = Nothing
                        End If
                        Dim pData As PathData = TryCast(item.Tag, PathData)
                        pData.Image = Nothing
                    Next item
                End If
            Next group
        End Sub
        Protected Function GetImagesInFolder(ByVal folder As PathData) As List(Of String)
            Dim strFilter As String = "*bmp;*tga;*.jpg;*.png;*.gif"
            Dim m_arExt() As String = strFilter.Split(";"c)
            Dim files As List(Of String) = New List(Of String)()
            For Each filter As String In m_arExt
                Dim str() As String = Directory.GetFiles(folder.Path, filter)
                files.AddRange(str)
            Next filter
            Return files
        End Function
        Private Function GetGalleryGroupByTag(ByVal tag As Object) As GalleryItemGroup
            For Each group As GalleryItemGroup In mainGallery.Gallery.Groups
                If group.Tag Is tag Then
                    Return group
                End If
            Next group
            Return Nothing
        End Function
        Private Function GetGalleryItemByTag(ByVal tag As Object) As GalleryItem
            For Each group As GalleryItemGroup In mainGallery.Gallery.Groups
                For Each item As GalleryItem In group.Items
                    If item.Tag Is tag Then
                        Return item
                    End If
                Next item
            Next group
            Return Nothing
        End Function
        Private Sub ClearGalleryItemsCheckState(ByVal gallery As GalleryControl)
            For Each group As GalleryItemGroup In gallery.Gallery.Groups
                For Each item As GalleryItem In group.Items
                    item.Checked = False
                Next item
            Next group
        End Sub
        Private Function InflateClip(ByVal cache As GraphicsCache) As RectangleF
            Dim clipBounds As RectangleF = cache.Graphics.ClipBounds
            Dim rect As RectangleF = cache.Graphics.ClipBounds
            rect.Inflate(50, 50)
            cache.Graphics.SetClip(rect)
            Return clipBounds
        End Function
        Private Sub DrawMarkedIcon(ByVal cache As GraphicsCache, ByVal bounds As Rectangle)
            Dim oldClipBounds As RectangleF = InflateClip(cache)
            cache.Graphics.DrawImage(My.Resources.ItemMarked_32x32, New Rectangle(bounds.Right - 26, bounds.Bottom - 26, 32, 32))
            cache.Graphics.SetClip(oldClipBounds)
        End Sub
        Private Sub DrawMarkedIconInSelection(ByVal cache As GraphicsCache, ByVal bounds As Rectangle)
            Dim oldClipBounds As RectangleF = InflateClip(cache)
            cache.Graphics.DrawImage(My.Resources.ItemMarked_16x16, New Rectangle(bounds.Right - 10, bounds.Bottom - 10, 16, 16))
            cache.Graphics.SetClip(oldClipBounds)
        End Sub
        Private Sub UpdateAlbumsMenu()
            For i As Integer = Me.albumsPopupMenu.ItemLinks.Count - 1 To 0 Step -1
                Dim link As BarItemLink = Me.albumsPopupMenu.ItemLinks(i)
                RemoveHandler link.Item.ItemClick, AddressOf OnAddToAlbumItemClick
                ribbonControl1.Manager.Items.Remove(link.Item)
            Next i
            albumsPopupMenu.ItemLinks.Clear()
            For Each album As AlbumData In ViewData.Albums
                albumsPopupMenu.ItemLinks.Add(CreateAddToAlbumItem(album))
            Next album
            Dim newAlbumLink As BarItemLink = albumsPopupMenu.ItemLinks.Add(CreateAddToAlbumItem(Nothing))
            newAlbumLink.BeginGroup = True
        End Sub
        Private Sub ShowViewCategory()
            If controlPresenter1.SelectedControl.Tag IsNot Nothing Then
                Return
            End If
            viewPageCategory.Visible = True
            collectionOriginalPage.Visible = False
            Dim ribbonPage As RibbonPage = CType((CType(collectionOriginalPage, ICloneable)).Clone(), RibbonPage)
            ribbonPage.Visible = True
            ribbonPage.Text = controlPresenter1.SelectedControl.Text
            viewPageCategory.Pages.Add(ribbonPage)
            ribbonPage.Tag = controlPresenter1.SelectedControl
            controlPresenter1.SelectedControl.Tag = ribbonPage
            ribbonControl1.SelectedPage = ribbonPage
        End Sub
        Private Sub HideViewCategory()
            If viewPageCategory.Pages.Count = 1 Then
                viewPageCategory.Visible = False
            End If
        End Sub
        Private Sub ViewSelectedImages(ByVal tabName As String, ByVal toolTip As String, ByVal files As List(Of String))
            Dim imageCollectionViewer As New ImageCollectionViewer(files, ThumbPath)
            imageCollectionViewer.SetMenuManager(ribbonControl1.Manager)
            imageCollectionViewer.Text = tabName
            imageCollectionViewer.Dock = DockStyle.Fill
            imageCollectionViewer.SetFilter(GetSelectedFilter())
            controlPresenter1.Controls.Add(imageCollectionViewer)
            controlPresenter1.SelectedControl = imageCollectionViewer
        End Sub
        Private Function GetSelectedFilter() As FilterInfo
            For Each group As GalleryItemGroup In filtersGallery.Gallery.Groups
                For Each item As GalleryItem In group.Items
                    If item.Checked Then
                        Return CType(item.Tag, FilterInfo)
                    End If
                Next item
            Next group
            Return Nothing
        End Function
        Private Function GetFilesInSelection() As List(Of String)
            Dim items As List(Of GalleryItem) = mainGallery.Gallery.GetCheckedItems()
            Dim res As List(Of String) = New List(Of String)(items.Count)
            For Each item As GalleryItem In items
                res.Add(CStr(item.Tag))
            Next item
            Return res
        End Function
        Private Sub UpdateAlbumButtonsEnabledState()
            biEditAlbum.Enabled = SelectedAlbum IsNot Nothing
            biRemoveAlbum.Enabled = SelectedAlbum IsNot Nothing
        End Sub
        Private Sub UpdateImageButtonsEnabledState()
            Dim hasFiles As Boolean = GetFilesInSelection().Count > 0
            biView.Enabled = hasFiles
            biRemoveFilesFromLibrary.Enabled = hasFiles
            biAddToAlbum.Enabled = hasFiles
            biMark.Enabled = hasFiles
            biCollage.Enabled = hasFiles
            biSlideShow.Enabled = hasFiles
            biFilm.Enabled = hasFiles
            biExportFolder.Enabled = hasFiles
            biEmail.Enabled = hasFiles
            biUpload.Enabled = hasFiles
            biPrint.Enabled = hasFiles
            biUnmark.Enabled = hasFiles
            biUnmarkAll.Enabled = hasFiles
            biRemoveFromAlbum.Enabled = hasFiles AndAlso navBarControl1.SelectedLink IsNot Nothing AndAlso (TypeOf navBarControl1.SelectedLink.Item.Tag Is AlbumData OrElse navBarControl1.SelectedLink.Group Is othersGroup)
        End Sub
        Private Sub UpdateSelectedPictureEdit(ByVal e As GalleryItemEventArgs)
            selectedPictureEdit.LoadAsync(CStr(e.Item.Tag))
        End Sub
        Private Sub UpdateItemsEnabledState()
            UpdateImageButtonsEnabledState()
            UpdateAlbumButtonsEnabledState()
            UpdateCancelButtonEnabledState()
        End Sub
        Private Sub CloseSelectedTabPage()
            Dim page As Control = controlPresenter1.SelectedControl
            If page Is libraryPanel Then
                page = controlPresenter1.Controls(controlPresenter1.Controls.Count - 1)
            End If
            If page Is libraryPanel Then
                Return
            End If
            controlPresenter1.Controls.Remove(page)
            Dim ribbonPage As RibbonPage = CType(page.Tag, RibbonPage)
            ribbonPage.Category.Pages.Remove(ribbonPage)
            ribbonPage.Dispose()
        End Sub
        Private Sub UpdateAddToLibraryItem(ByVal item As BarItem)
            biAddToLibrary.Glyph = item.Glyph
            biAddToLibrary.LargeGlyph = item.LargeGlyph
            biAddToLibrary.SuperTip = item.SuperTip
            biAddToLibrary.Hint = item.Hint
            biAddToLibrary.Tag = item
        End Sub
        Private Sub FilterByMarked(ByVal filterByMarked As Boolean)
            mainGallery.Gallery.BeginUpdate()
            Try
                For Each group As GalleryItemGroup In mainGallery.Gallery.Groups
                    For Each item As GalleryItem In group.Items
                        item.Visible = (Not filterByMarked) OrElse MarkedItems.Contains(item)
                    Next item
                Next group
            Finally
                mainGallery.Gallery.EndUpdate()
            End Try
        End Sub
        Private Sub GenerateSampleData()
            ViewData.Clear()

            AddFolder("\SamplePhotos\Photo1")
            AddFolder("\SamplePhotos\Photo2")
            AddFolder("\SamplePhotos\Photo3")
            AddFolder("\SamplePhotos\Photo4")

            If ViewData.Folders.Count > 1 Then
                Dim files As List(Of String) = GetImagesInFolder(ViewData.Folders(0))
                files.AddRange(GetImagesInFolder(ViewData.Folders(1)))

                AddAlbum("Sample Album 1", DateTime.Now, "This is a sample album 1", files)
            End If
            If ViewData.Folders.Count > 3 Then
                Dim files As List(Of String) = GetImagesInFolder(ViewData.Folders(2))
                files.AddRange(GetImagesInFolder(ViewData.Folders(3)))

                AddAlbum("Sample Album 2", DateTime.Now, "This is a sample album 2", files)
            End If

            ViewData.Others.Name = "Other"
            ViewData.Others.Date = DateTime.Now
            ViewData.Others.Description = "Other image files"

            UpdateData()
            UpdateMainGalleryContent(True)
        End Sub
        Private Sub AddFolder(ByVal relativePath As String)
            Dim pData As New PathData()
            pData.Path = DataPath & relativePath
            pData.Name = Path.GetFileName(pData.Path)
            If (Not Directory.Exists(pData.Path)) Then
                XtraMessageBox.Show(Me, "Error: no such path '" & pData.Path & "'. Maybe you removed this folder?", Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            ViewData.Folders.Add(pData)
        End Sub
        Private Sub AddAlbum(ByVal albumName As String, ByVal albumDate As DateTime, ByVal description As String, ByVal files As List(Of String))
            Dim aData As New AlbumData()
            aData.Name = albumName
            aData.Date = albumDate
            aData.Description = description
            For Each file As String In files
                Dim pData As New PathData()
                pData.Path = file
                aData.Files.Add(pData)
            Next file
            ViewData.Albums.Add(aData)

        End Sub
        Private Sub RemoveImagesFromAlbum(ByVal items As List(Of GalleryItem))
            Dim aData As AlbumData = TryCast(navBarControl1.SelectedLink.Item.Tag, AlbumData)
            Dim messageText As String = String.Empty
            If aData Is Nothing Then
                If navBarControl1.SelectedLink.Group Is othersGroup Then
                    aData = ViewData.Others
                    messageText = "Are you sure you want to remove checked items?"
                Else
                    Return
                End If
            Else
                messageText = "Are you sure you want to remove checked items from album '" & aData.Name & "'?"
            End If
            If XtraMessageBox.Show(Me, messageText, Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
                Return
            End If
            For Each item As GalleryItem In items
                aData.Files.Remove(CStr(item.Tag))
            Next item
            UpdateData()
            UpdateMainGalleryContent(True)
        End Sub
        Private Sub UpdateMainGalleryContent(ByVal forceProcess As Boolean)
            If navBarControl1.SelectedLink Is Nothing Then
                ClearGalleryAndImages()
                Return
            End If
            Dim album As AlbumData = TryCast(navBarControl1.SelectedLink.Item.Tag, AlbumData)
            Dim path As PathData = TryCast(navBarControl1.SelectedLink.Item.Tag, PathData)
            Dim shouldRecreateGallery As Boolean = lastSelectedGroup IsNot navBarControl1.SelectedLink.Group OrElse forceProcess
            Dim isOtherFiles As Boolean = navBarControl1.SelectedLink.Group Is othersGroup
            If album IsNot Nothing Then
                If shouldRecreateGallery Then
                    ProcessAlbums()
                End If
                ScrollToAlbum(album, (Not shouldRecreateGallery))
            ElseIf path IsNot Nothing Then
                If shouldRecreateGallery Then
                    If isOtherFiles Then
                        ProcessOthers()
                    Else
                        ProcessFolders()
                    End If
                End If
                If isOtherFiles Then
                    ScrollToFile(path.Path, (Not shouldRecreateGallery))
                Else
                    ScrollToFolder(path, (Not shouldRecreateGallery))
                End If
            End If
            UpdateItemsEnabledState()
        End Sub

        Friend Sub UpdateCancelButtonEnabledState()
            Dim viewer As ImageCollectionViewer = TryCast(controlPresenter1.SelectedControl, ImageCollectionViewer)
            biCancel.Enabled = viewer IsNot Nothing AndAlso viewer.IsImageFilterd()
        End Sub

        Private Sub OnSelectAllMarkedItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles biSelectAllMarked.ItemClick
            For Each item As GalleryItem In MarkedItems
                Dim unselectOtherItems As Boolean = MarkedItems.IndexOf(item) = 0
                mainGallery.Gallery.SetItemCheck(item, True, unselectOtherItems)
            Next item
        End Sub
        Private Sub OnZoomShownEditor(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles beZoom.ShownEditor
            Me.zoomControl_Renamed = TryCast(ribbonControl1.Manager.ActiveEditor, ZoomTrackBarControl)
            If ZoomControl IsNot Nothing Then
                AddHandler ZoomControl.ValueChanged, AddressOf OnZoomTackValueChanged
            End If
        End Sub

        Private Sub OnZoomHiddenEditor(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles beZoom.HiddenEditor
            RemoveHandler ZoomControl.ValueChanged, AddressOf OnZoomTackValueChanged
            Me.zoomControl_Renamed = Nothing
        End Sub

        Private Sub filtersGallery_Gallery_PopupClose(ByVal sender As Object, ByVal e As InplaceGalleryEventArgs) Handles filtersGallery.Gallery.PopupClose
            Dim items As List(Of GalleryItem) = e.Item.Gallery.GetCheckedItems()
            If items.Count > 0 Then
                e.Item.Gallery.MakeVisible(items(0))
            End If
        End Sub

        Private Sub OnDateFilterSelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dateFilter1.SelectionChanged
            mainGallery.Gallery.BeginUpdate()
            Try
                Dim items As List(Of GalleryItem) = mainGallery.Gallery.GetAllItems()
                For Each item As GalleryItem In items
                    Dim [date] As DateTime = File.GetCreationTime(CStr(item.Tag))
                    item.Visible = (Not dateFilter1.AllowFilter) OrElse ([date] >= dateFilter1.StartDate AndAlso [date] <= dateFilter1.EndDate)
                Next item
            Finally
                mainGallery.Gallery.EndUpdate()
            End Try
        End Sub
        Private Sub mainGallery_Gallery_MarqueeSelectionCompleted(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.Ribbon.GallerySelectionEventArgs) Handles mainGallery.Gallery.MarqueeSelectionCompleted
            Dim pt As Point = Control.MousePosition
            pt.Y -= 11
            Me.RibbonMiniToolbar1.Show(pt)
        End Sub
    End Class
End Namespace
