Imports System.IO

Namespace DevExpress.CrmDemo.Win.Helpers
	Public NotInheritable Class DataBindingHelpers

		Private Sub New()
		End Sub

		Public Shared Sub SuspendTwoWayBinding(ByVal bindingManager As BindingManagerBase)
			If bindingManager Is Nothing Then
				Throw New ArgumentNullException("bindingManager")
			End If

			For Each b As Binding In bindingManager.Bindings
				b.DataSourceUpdateMode = DataSourceUpdateMode.Never
			Next b
		End Sub

		Public Shared Sub UpdateDataBoundObject(ByVal bindingManager As BindingManagerBase, ByVal bindingSource As BindingSource)
			If bindingManager Is Nothing Then
				Throw New ArgumentNullException("bindingManager")
			End If

			bindingSource.RaiseListChangedEvents = False

			For Each b As Binding In bindingManager.Bindings
				b.WriteValue()
			Next b

			bindingSource.RaiseListChangedEvents = True
		End Sub
	End Class
End Namespace
