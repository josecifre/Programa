Imports System.ComponentModel

Namespace DevExpress.CrmDemo.Win.Data
	Public Class TeamMember
		Implements INotifyPropertyChanged

		#Region "Public members"

		Public Property Id() As Integer
			Get
				Return _id
			End Get
			Set(ByVal value As Integer)
				_id = value
				InvokePropertyChanged("Id")
			End Set
		End Property

		Public Property FullName() As String
			Get
				Return _fullName
			End Get
			Set(ByVal value As String)
				_fullName = value
				InvokePropertyChanged("FullName")
			End Set
		End Property

		Public Property Photo() As Bitmap
			Get
				Return _photo
			End Get
			Set(ByVal value As Bitmap)
				_photo = value
				InvokePropertyChanged("Photo")
			End Set
		End Property

		Public Property PhotoSmall() As Bitmap
			Get
				Return _photoSmall
			End Get
			Set(ByVal value As Bitmap)
				_photoSmall = value
				InvokePropertyChanged("PhotoSmall")
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

		Private _id As Integer
		Private _fullName As String
		Private _photo As Bitmap
		Private _photoSmall As Bitmap

		#End Region

	End Class
End Namespace
