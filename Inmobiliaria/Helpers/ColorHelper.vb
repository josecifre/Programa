Imports System.Text
Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors

Namespace DevExpress.CrmDemo.Win.Helpers
	Public Class ColorHelper
		Public Shared MainForm As Form = Nothing
		Public Shared LabelColor As Color = Color.White
		Public Shared LabelColorLight As Color = Color.FromArgb(201, 201, 201)
		Public Shared LabelColorDark As Color = Color.FromArgb(179, 179, 179)
		Public Shared LabelColorDarkDark As Color = Color.FromArgb(139, 139, 139)
		Private Shared Sub SetMenuManager(ByVal controls As Control.ControlCollection, ByVal manager As BarManager)
			For Each ctrl As Control In controls
				Dim edit As BaseEdit = TryCast(ctrl, BaseEdit)
				If edit IsNot Nothing Then
					edit.MenuManager = manager
				End If
				If ctrl.Controls.Count > 0 Then
					SetMenuManager(ctrl.Controls, manager)
				End If
			Next ctrl
		End Sub
		Public Shared Sub SetMenuManager(ByVal controls As Control.ControlCollection, ByVal key As String, ByVal form As Form)
			Dim menuManager As New BarManager()
			menuManager.Form = form
			Dim controller As New BarAndDockingController()
			controller.LookAndFeel.UseDefaultLookAndFeel = False
			controller.LookAndFeel.SetSkinStyle(key)
			menuManager.Controller = controller
			SetMenuManager(controls, menuManager)
		End Sub
	End Class
End Namespace
