Imports System.ComponentModel
Imports System.IO
Imports DevExpress.CrmDemo.Win.Helpers
Imports System.Collections

Namespace DevExpress.CrmDemo.Win.Data
	''' <summary>
	'''  This is all from here: http://www.devexpress.com/Support/Center/e/E750.aspx
	''' </summary>
	Public Class CustomAppointment
		Implements IEditableObject

		Private fStart As Date
		Private fEnd As Date
		Private fSubject As String
		Private fStatus As Integer
		Private fDescription As String
		Private fLabel As Long
		Private fLocation As String
		Private fAllday As Boolean
		Private fEventType As Integer
		Private fRecurrenceInfo As String
		Private fReminderInfo As String
		Private fOwnerId As Object

		Private events As CustomEventList
		Private committed As Boolean = False

		Public Sub New(ByVal events As CustomEventList)
			Me.events = events
		End Sub

		Private Sub OnListChanged()
			Dim index As Integer = events.IndexOf(Me)
			events.OnListChanged(New ListChangedEventArgs(ListChangedType.ItemChanged, index))
		End Sub

		Public Property StartTime() As Date
			Get
				Return fStart
			End Get
			Set(ByVal value As Date)
				fStart = value
			End Set
		End Property
		Public Property EndTime() As Date
			Get
				Return fEnd
			End Get
			Set(ByVal value As Date)
				fEnd = value
			End Set
		End Property
		Public Property Subject() As String
			Get
				Return fSubject
			End Get
			Set(ByVal value As String)
				fSubject = value
			End Set
		End Property
		Public Property Status() As Integer
			Get
				Return fStatus
			End Get
			Set(ByVal value As Integer)
				fStatus = value
			End Set
		End Property
		Public Property Description() As String
			Get
				Return fDescription
			End Get
			Set(ByVal value As String)
				fDescription = value
			End Set
		End Property
		Public Property Label() As Long
			Get
				Return fLabel
			End Get
			Set(ByVal value As Long)
				fLabel = value
			End Set
		End Property
		Public Property Location() As String
			Get
				Return fLocation
			End Get
			Set(ByVal value As String)
				fLocation = value
			End Set
		End Property
		Public Property AllDay() As Boolean
			Get
				Return fAllday
			End Get
			Set(ByVal value As Boolean)
				fAllday = value
			End Set
		End Property
		Public Property EventType() As Integer
			Get
				Return fEventType
			End Get
			Set(ByVal value As Integer)
				fEventType = value
			End Set
		End Property
		Public Property RecurrenceInfo() As String
			Get
				Return fRecurrenceInfo
			End Get
			Set(ByVal value As String)
				fRecurrenceInfo = value
			End Set
		End Property
		Public Property ReminderInfo() As String
			Get
				Return fReminderInfo
			End Get
			Set(ByVal value As String)
				fReminderInfo = value
			End Set
		End Property
		Public Property OwnerId() As Object
			Get
				Return fOwnerId
			End Get
			Set(ByVal value As Object)
				fOwnerId = value
			End Set
		End Property

		Public Sub BeginEdit() Implements IEditableObject.BeginEdit
		End Sub
		Public Sub CancelEdit() Implements IEditableObject.CancelEdit
			If Not committed Then
				CType(events, IList).Remove(Me)
			End If
		End Sub
		Public Sub EndEdit() Implements IEditableObject.EndEdit
			committed = True
			OnListChanged()
		End Sub
	End Class

	Public Class CustomEventList
		Inherits CollectionBase
		Implements IBindingList

		Default Public ReadOnly Property Item(ByVal idx As Integer) As CustomAppointment
			Get
				Return CType(MyBase.List(idx), CustomAppointment)
			End Get
		End Property

        Public Shadows Sub Clear()
            MyBase.Clear()
            OnListChanged(New ListChangedEventArgs(ListChangedType.Reset, -1))
        End Sub
        Public Sub Add(ByVal appointment As CustomAppointment)
            MyBase.List.Add(appointment)
        End Sub
        Public Function IndexOf(ByVal appointment As CustomAppointment) As Integer
            Return List.IndexOf(appointment)
        End Function
        Public Function AddNew() As Object Implements IBindingList.AddNew
            Dim app As New CustomAppointment(Me)
            List.Add(app)
            Return app
        End Function
        Public ReadOnly Property AllowEdit() As Boolean Implements IBindingList.AllowEdit
            Get
                Return True
            End Get
        End Property
        Public ReadOnly Property AllowNew() As Boolean Implements IBindingList.AllowNew
            Get
                Return True
            End Get
        End Property
        Public ReadOnly Property AllowRemove() As Boolean Implements IBindingList.AllowRemove
            Get
                Return True
            End Get
        End Property

        Private Event listChangedHandler As ListChangedEventHandler
        Public Custom Event ListChanged As ListChangedEventHandler Implements IBindingList.ListChanged
            AddHandler(ByVal value As ListChangedEventHandler)
                AddHandler listChangedHandler, value
            End AddHandler
            RemoveHandler(ByVal value As ListChangedEventHandler)
                RemoveHandler listChangedHandler, value
            End RemoveHandler
            RaiseEvent(ByVal sender As System.Object, ByVal e As System.ComponentModel.ListChangedEventArgs)
            End RaiseEvent
        End Event
        Friend Sub OnListChanged(ByVal args As ListChangedEventArgs)
            If Not listChangedHandlerEvent Is Nothing Then
                RaiseEvent listChangedHandler(Me, args)
            End If
        End Sub
        Protected Overrides Sub OnRemoveComplete(ByVal index As Integer, ByVal value As Object)
            OnListChanged(New ListChangedEventArgs(ListChangedType.ItemDeleted, index))
        End Sub
        Protected Overrides Sub OnInsertComplete(ByVal index As Integer, ByVal value As Object)
            OnListChanged(New ListChangedEventArgs(ListChangedType.ItemAdded, index))
        End Sub

        Public Sub AddIndex(ByVal pd As PropertyDescriptor) Implements IBindingList.AddIndex
            Throw New NotSupportedException()
        End Sub
        Public Sub ApplySort(ByVal pd As PropertyDescriptor, ByVal dir As ListSortDirection) Implements IBindingList.ApplySort
            Throw New NotSupportedException()
        End Sub
        Public Function Find(ByVal [property] As PropertyDescriptor, ByVal key As Object) As Integer Implements IBindingList.Find
            Throw New NotSupportedException()
        End Function
        Public ReadOnly Property IsSorted() As Boolean Implements IBindingList.IsSorted
            Get
                Return False
            End Get
        End Property
        Public Sub RemoveIndex(ByVal pd As PropertyDescriptor) Implements IBindingList.RemoveIndex
            Throw New NotSupportedException()
        End Sub
        Public Sub RemoveSort() Implements IBindingList.RemoveSort
            Throw New NotSupportedException()
        End Sub
        Public ReadOnly Property SortDirection() As ListSortDirection Implements IBindingList.SortDirection
            Get
                Throw New NotSupportedException()
            End Get
        End Property
        Public ReadOnly Property SortProperty() As PropertyDescriptor Implements IBindingList.SortProperty
            Get
                Throw New NotSupportedException()
            End Get
        End Property
        Public ReadOnly Property SupportsChangeNotification() As Boolean Implements IBindingList.SupportsChangeNotification
            Get
                Return True
            End Get
        End Property
        Public ReadOnly Property SupportsSearching() As Boolean Implements IBindingList.SupportsSearching
            Get
                Return False
            End Get
        End Property
        Public ReadOnly Property SupportsSorting() As Boolean Implements IBindingList.SupportsSorting
            Get
                Return False
            End Get
        End Property
    End Class

	#Region "#customresource"
	Public Class CustomResource
		Private name_Renamed As String
		Private res_id As Integer
		Private res_color As Color

		Public Property Name() As String
			Get
				Return name_Renamed
			End Get
			Set(ByVal value As String)
				name_Renamed = value
			End Set
		End Property
		Public Property ResID() As Integer
			Get
				Return res_id
			End Get
			Set(ByVal value As Integer)
				res_id = value
			End Set
		End Property
		Public Property ResColor() As Color
			Get
				Return res_color
			End Get
			Set(ByVal value As Color)
				res_color = value
			End Set
		End Property

		Public Sub New()
		End Sub
	End Class
	#End Region ' #customresource

	#Region "#customresourcecollection"
	Public Class CustomResourceCollection
		Inherits CollectionBase
		Implements IBindingList

		Public Sub New()
		End Sub
		Default Public ReadOnly Property Item(ByVal idx As Integer) As CustomResource
			Get
				Return CType(MyBase.List(idx), CustomResource)
			End Get
		End Property

		Public Sub Add(ByVal res As CustomResource)
			List.Add(res)
		End Sub
        Public Shadows Sub Clear()
            MyBase.Clear()
            OnListChanged(New ListChangedEventArgs(ListChangedType.Reset, -1))
        End Sub
		Protected Overrides Sub OnRemoveComplete(ByVal index As Integer, ByVal value As Object)
			OnListChanged(New ListChangedEventArgs(ListChangedType.ItemDeleted, index))
		End Sub
		Protected Overrides Sub OnInsertComplete(ByVal index As Integer, ByVal value As Object)
			OnListChanged(New ListChangedEventArgs(ListChangedType.ItemAdded, index))
		End Sub
		#Region "IBindingList implementation"
        Private Event listChangedHandler As ListChangedEventHandler
        Public Custom Event ListChanged As ListChangedEventHandler Implements IBindingList.ListChanged
            AddHandler(ByVal value As ListChangedEventHandler)
                AddHandler listChangedHandler, value
            End AddHandler
            RemoveHandler(ByVal value As ListChangedEventHandler)
                RemoveHandler listChangedHandler, value
            End RemoveHandler
            RaiseEvent(ByVal sender As System.Object, ByVal e As System.ComponentModel.ListChangedEventArgs)
            End RaiseEvent
        End Event
        Friend Sub OnListChanged(ByVal args As ListChangedEventArgs)
            If Not listChangedHandlerEvent Is Nothing Then
                RaiseEvent listChangedHandler(Me, args)
            End If
        End Sub
		Public ReadOnly Property AllowEdit() As Boolean Implements IBindingList.AllowEdit
			Get
				Return True
			End Get
		End Property
		Public ReadOnly Property AllowNew() As Boolean Implements IBindingList.AllowNew
			Get
				Return True
			End Get
		End Property
		Public ReadOnly Property AllowRemove() As Boolean Implements IBindingList.AllowRemove
			Get
				Return True
			End Get
		End Property

		Public ReadOnly Property IsSorted() As Boolean Implements IBindingList.IsSorted
			Get
				Return False
			End Get
		End Property
		Public ReadOnly Property SortDirection() As ListSortDirection Implements IBindingList.SortDirection
			Get
				Throw New NotSupportedException()
			End Get
		End Property
		Public ReadOnly Property SortProperty() As PropertyDescriptor Implements IBindingList.SortProperty
			Get
				Throw New NotSupportedException()
			End Get
		End Property

		Public ReadOnly Property SupportsChangeNotification() As Boolean Implements IBindingList.SupportsChangeNotification
			Get
				Return True
			End Get
		End Property
		Public ReadOnly Property SupportsSearching() As Boolean Implements IBindingList.SupportsSearching
			Get
				Return False
			End Get
		End Property
		Public ReadOnly Property SupportsSorting() As Boolean Implements IBindingList.SupportsSorting
			Get
				Return False
			End Get
		End Property

		Public Function AddNew() As Object Implements IBindingList.AddNew
			Dim res As New CustomResource()
			Add(res)
			Return res
		End Function
		Public Sub AddIndex(ByVal pd As PropertyDescriptor) Implements IBindingList.AddIndex
			Throw New NotSupportedException()
		End Sub
		Public Sub ApplySort(ByVal pd As PropertyDescriptor, ByVal dir As ListSortDirection) Implements IBindingList.ApplySort
			Throw New NotSupportedException()
		End Sub
		Public Function Find(ByVal [property] As PropertyDescriptor, ByVal key As Object) As Integer Implements IBindingList.Find
			Throw New NotSupportedException()
		End Function
		Public Sub RemoveIndex(ByVal pd As PropertyDescriptor) Implements IBindingList.RemoveIndex
			Throw New NotSupportedException()
		End Sub
		Public Sub RemoveSort() Implements IBindingList.RemoveSort
			Throw New NotSupportedException()
		End Sub
		#End Region
	End Class
	#End Region ' #customresourcecollection
End Namespace
