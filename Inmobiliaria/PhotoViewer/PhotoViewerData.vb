Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.Utils.Serializing
Imports System.Collections.Specialized
Imports System.Collections
Imports System.Drawing
Imports System.IO

Namespace PhotoViewer
	Public Class PhotoViewerData
		Implements IXtraSerializable
		Private folders_Renamed As PathCollection
		Private albums_Renamed As AlbumCollection
		Private others_Renamed As AlbumData

		Private firstRun_Renamed As Boolean

		<XtraSerializableProperty(XtraSerializationVisibility.Collection, True, False, True, 1, XtraSerializationFlags.DeserializeCollectionItemBeforeCallSetIndex)> _
		Public ReadOnly Property Albums() As AlbumCollection
			Get
				If albums_Renamed Is Nothing Then
					albums_Renamed = New AlbumCollection()
				End If
				Return albums_Renamed
			End Get
		End Property
		<XtraSerializableProperty(XtraSerializationVisibility.Collection, True, False, True, 2, XtraSerializationFlags.DeserializeCollectionItemBeforeCallSetIndex)> _
		Public ReadOnly Property Folders() As PathCollection
			Get
				If folders_Renamed Is Nothing Then
					folders_Renamed = New PathCollection()
				End If
				Return folders_Renamed
			End Get
		End Property
		<XtraSerializableProperty(XtraSerializationVisibility.Content)> _
		Public ReadOnly Property Others() As AlbumData
			Get
				If others_Renamed Is Nothing Then
					others_Renamed = New AlbumData()
				End If
				Return others_Renamed
			End Get
		End Property
		<XtraSerializableProperty> _
		Public Property FirstRun() As Boolean
			Get
				Return firstRun_Renamed
			End Get
			Set(ByVal value As Boolean)
				firstRun_Renamed = value
			End Set
		End Property

		#Region "IXtraSerializable Members"

		Private Sub OnEndDeserializing(ByVal restoredVersion As String) Implements IXtraSerializable.OnEndDeserializing
		End Sub
		Private Sub OnEndSerializing() Implements IXtraSerializable.OnEndSerializing
		End Sub
		Private Sub OnStartDeserializing(ByVal e As DevExpress.Utils.LayoutAllowEventArgs) Implements IXtraSerializable.OnStartDeserializing
		End Sub
		Private Sub OnStartSerializing() Implements IXtraSerializable.OnStartSerializing
		End Sub

		#End Region

		Public Sub SaveLayoutToXml(ByVal fileName As String)
			If File.Exists(fileName) Then
				File.SetAttributes(fileName, FileAttributes.Normal)
			End If
			SaveLayoutCore(New XmlXtraSerializer(), fileName)
		End Sub
		Public Sub RestoreLayoutFromXml(ByVal fileName As String)
			File.SetAttributes(fileName, FileAttributes.Normal)
			RestoreLayoutCore(New XmlXtraSerializer(), fileName)
		End Sub
		Protected Overridable Function SaveLayoutCore(ByVal serializer As XtraSerializer, ByVal path As Object) As Boolean
			Dim stream As System.IO.Stream = TryCast(path, System.IO.Stream)
			If stream IsNot Nothing Then
				Return serializer.SerializeObjects(New XtraObjectInfo() { New XtraObjectInfo("PhotoViewerData", Me) }, stream, Me.GetType().Name)
			Else
				Return serializer.SerializeObjects(New XtraObjectInfo() { New XtraObjectInfo("PhotoViewerData", Me) }, path.ToString(), Me.GetType().Name)
			End If
		End Function
		Protected Overridable Sub RestoreLayoutCore(ByVal serializer As XtraSerializer, ByVal path As Object)
			Dim stream As System.IO.Stream = TryCast(path, System.IO.Stream)
				If stream IsNot Nothing Then
					serializer.DeserializeObjects(New XtraObjectInfo() { New XtraObjectInfo("PhotoViewerData", Me) }, stream, Me.GetType().Name)
				Else
					serializer.DeserializeObjects(New XtraObjectInfo() { New XtraObjectInfo("PhotoViewerData", Me) }, path.ToString(), Me.GetType().Name)
				End If
		End Sub
		Private Function XtraCreateAlbumsItem(ByVal e As XtraItemEventArgs) As Object
			Return New AlbumData()
		End Function
		Private Sub XtraSetIndexAlbumsItem(ByVal e As XtraSetItemIndexEventArgs)
			Albums.Insert(e.NewIndex, CType(e.Item.Value, AlbumData))
		End Sub
		Private Function XtraCreateFoldersItem(ByVal e As XtraItemEventArgs) As Object
			Return New PathData()
		End Function
		Private Sub XtraSetIndexFoldersItem(ByVal e As XtraSetItemIndexEventArgs)
			Folders.Insert(e.NewIndex, CType(e.Item.Value, PathData))
		End Sub

		Public Sub Clear()
			Albums.Clear()
			Folders.Clear()
		End Sub
	End Class

	Public Class AlbumCollection
		Inherits CollectionBase
		Public Function Add(ByVal album As AlbumData) As Integer
			Return List.Add(album)
		End Function
		Public Sub Insert(ByVal index As Integer, ByVal album As AlbumData)
			List.Insert(index, album)
		End Sub
		Public Sub Remove(ByVal album As AlbumData)
			List.Remove(album)
		End Sub
		Default Public Property Item(ByVal index As Integer) As AlbumData
			Get
				Return TryCast(List(index), AlbumData)
			End Get
			Set(ByVal value As AlbumData)
				List(index) = value
			End Set
		End Property
	End Class

	Public Class PathCollection
		Inherits CollectionBase
		Public Function Add(ByVal path As PathData) As Integer
			Return List.Add(path)
		End Function
		Public Sub Insert(ByVal index As Integer, ByVal path As PathData)
			List.Insert(index, path)
		End Sub
		Public Sub Remove(ByVal path As PathData)
			List.Remove(path)
		End Sub
		Public Sub Remove(ByVal path As String)
			For Each pData As PathData In Me
				If pData.Path = path Then
					Remove(pData)
					Return
				End If
			Next pData
		End Sub
		Default Public Property Item(ByVal index As Integer) As PathData
			Get
				Return TryCast(List(index), PathData)
			End Get
			Set(ByVal value As PathData)
				List(index) = value
			End Set
		End Property
		Public Function Contains(ByVal file As String) As Boolean
			For Each pData As PathData In Me
				If pData.Path = file Then
					Return True
				End If
			Next pData
			Return False
		End Function
	End Class

	Public Class AlbumData
		Implements IXtraSerializable
		Private files_Renamed As PathCollection
		Private date_Renamed As DateTime
		Private name_Renamed As String
		Private description_Renamed As String

		<XtraSerializableProperty(XtraSerializationVisibility.Collection, True, False, True, 1, XtraSerializationFlags.DeserializeCollectionItemBeforeCallSetIndex)> _
		Public ReadOnly Property Files() As PathCollection
			Get
				If files_Renamed Is Nothing Then
					files_Renamed = New PathCollection()
				End If
				Return files_Renamed
			End Get
		End Property

		<XtraSerializableProperty> _
		Public Property Name() As String
			Get
				Return name_Renamed
			End Get
			Set(ByVal value As String)
				name_Renamed = value
			End Set
		End Property
		<XtraSerializableProperty> _
		Public Property [Date]() As DateTime
			Get
				Return date_Renamed
			End Get
			Set(ByVal value As DateTime)
				date_Renamed = value
			End Set
		End Property
		<XtraSerializableProperty> _
		Public Property Description() As String
			Get
				Return description_Renamed
			End Get
			Set(ByVal value As String)
				description_Renamed = value
			End Set
		End Property

		#Region "IXtraSerializable Members"

		Private Sub OnEndDeserializing(ByVal restoredVersion As String) Implements IXtraSerializable.OnEndDeserializing
		End Sub
		Private Sub OnEndSerializing() Implements IXtraSerializable.OnEndSerializing
		End Sub
		Private Sub OnStartDeserializing(ByVal e As DevExpress.Utils.LayoutAllowEventArgs) Implements IXtraSerializable.OnStartDeserializing
		End Sub
		Private Sub OnStartSerializing() Implements IXtraSerializable.OnStartSerializing
		End Sub

		#End Region

		Private Function XtraCreateFilesItem(ByVal e As XtraItemEventArgs) As Object
			Return New PathData()
		End Function
		Private Sub XtraSetIndexFilesItem(ByVal e As XtraSetItemIndexEventArgs)
			Files.Insert(e.NewIndex, CType(e.Item.Value, PathData))
		End Sub
	End Class

	Public Class PathData
		Implements IXtraSerializable
		Private name_Renamed As String
		Private path_Renamed As String
		Private image_Renamed As Image

		<XtraSerializableProperty> _
		Public Property Name() As String
			Get
				Return name_Renamed
			End Get
			Set(ByVal value As String)
				name_Renamed = value
			End Set
		End Property
		<XtraSerializableProperty> _
		Public Property Path() As String
			Get
				Return path_Renamed
			End Get
			Set(ByVal value As String)
				path_Renamed = value
			End Set
		End Property
		Public Property Image() As Image
			Get
				Return image_Renamed
			End Get
			Set(ByVal value As Image)
				image_Renamed = value
			End Set
		End Property

		#Region "IXtraSerializable Members"

		Private Sub OnEndDeserializing(ByVal restoredVersion As String) Implements IXtraSerializable.OnEndDeserializing
		End Sub
		Private Sub OnEndSerializing() Implements IXtraSerializable.OnEndSerializing
		End Sub
		Private Sub OnStartDeserializing(ByVal e As DevExpress.Utils.LayoutAllowEventArgs) Implements IXtraSerializable.OnStartDeserializing
		End Sub
		Private Sub OnStartSerializing() Implements IXtraSerializable.OnStartSerializing
		End Sub

		#End Region
	End Class
End Namespace
