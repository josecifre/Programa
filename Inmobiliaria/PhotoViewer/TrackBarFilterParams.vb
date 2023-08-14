Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraLayout

Namespace PhotoViewer
	Partial Public Class TrackBarFilterParams
		Inherits SimpleFilterParams
		Public Sub New()
			InitializeComponent()
			Dim trackBarItem As New LayoutControlItem(Me.SimpleFilterParamsConvertedLayout, Me.trackBarControl1)
			trackBarItem.Text = FilterText
			trackBarItem.SizeConstraintsType = SizeConstraintsType.Custom
			trackBarItem.MinSize = New Size(25, 50)
			trackBarItem.MaxSize = New Size(0, 50)
			trackBarItem.Move(Me.applyButtonItem, DevExpress.XtraLayout.Utils.InsertType.Top)
		End Sub
		Public Overrides Function GetParams() As Object()
			Return New Object() { GetValue() }
		End Function

		Protected Overridable Sub OnBeforeShowTrackBarValueToolTip(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.TrackBarValueToolTipEventArgs) Handles trackBarControl1.Properties.BeforeShowValueToolTip
			e.ShowArgs.ToolTip = GetValue().ToString()
		End Sub

		Protected Overridable Function GetValue() As Single
			Return trackBarControl1.Value * 0.001f
		End Function

		Private Sub trackBarControl1_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles trackBarControl1.EditValueChanged
			UpdatePreview()
		End Sub
		Protected Overridable ReadOnly Property FilterText() As String
			Get
				Return ""
			End Get
		End Property
	End Class

	Partial Public Class BrightnessFilterParams
		Inherits TrackBarFilterParams
		Protected Overrides ReadOnly Property FilterText() As String
			Get
				Return "Brightness"
			End Get
		End Property
		Protected Overrides Function GetValue() As Single
			Return trackBarControl1.Value * 0.002f - 1.0f
		End Function
	End Class

	Partial Public Class ContrastFilterParams
		Inherits TrackBarFilterParams
		Protected Overrides ReadOnly Property FilterText() As String
			Get
				Return "Contrast"
			End Get
		End Property
		Protected Overrides Function GetValue() As Single
			Return trackBarControl1.Value * 0.002f
		End Function
	End Class

	Partial Public Class SaturationFilterParams
		Inherits TrackBarFilterParams
		Protected Overrides ReadOnly Property FilterText() As String
			Get
				Return "Saturation"
			End Get
		End Property
		Protected Overrides Function GetValue() As Single
			Return trackBarControl1.Value * 0.001f
		End Function
	End Class
End Namespace
