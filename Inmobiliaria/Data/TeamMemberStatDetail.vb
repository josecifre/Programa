Imports System.ComponentModel

Namespace DevExpress.CrmDemo.Win.Data
	Public Class TeamMemberStatDetail
		Implements INotifyPropertyChanged

		#Region "Public members"

		Public Property TeamMemberId() As Integer
			Get
				Return _teamMemberId
			End Get
			Set(ByVal value As Integer)
				_teamMemberId = value
				InvokePropertyChanged("TeamMemberId")
			End Set
		End Property

		Public Property [Date]() As Date
			Get
				Return _date
			End Get
			Set(ByVal value As Date)
				_date = value
				InvokePropertyChanged("Date")
			End Set
		End Property

		Public Property DateString() As String
			Get
				Return _dateString
			End Get
			Set(ByVal value As String)
				_dateString = value
				InvokePropertyChanged("DateString")
			End Set
		End Property

		Public Property Amount() As Long
			Get
				Return _amount
			End Get
			Set(ByVal value As Long)
				_amount = value
				InvokePropertyChanged("Amount")
			End Set
		End Property

		#End Region

		#Region "INotifyPropertyChanged implementation"
		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

		Private Sub InvokePropertyChanged(ByVal name As String)
			Dim handler As PropertyChangedEventHandler = PropertyChangedEvent
			If handler IsNot Nothing Then
				handler(Me, New PropertyChangedEventArgs(name))
			End If
		End Sub
		#End Region

		#Region "Private data"

		Private _teamMemberId As Integer
		Private _amount As Long
		Private _dateString As String
		Private _date As Date

		#End Region

	End Class

	Public Class TeamMemberStatDetailList
		Inherits BindingList(Of TeamMemberStatDetail)

	End Class
End Namespace
