Imports System.ComponentModel

Namespace DevExpress.CrmDemo.Win.Data
	Public Class TeamMemberStat
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

		Public Property Percent() As Integer
			Get
				Return _percent
			End Get
			Set(ByVal value As Integer)
				_percent = value
				InvokePropertyChanged("Percent")
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
		Private _percent As Integer

		#End Region

	End Class

	Public Class TeamMemberStatList
		Inherits BindingList(Of TeamMemberStat)

	End Class
End Namespace
