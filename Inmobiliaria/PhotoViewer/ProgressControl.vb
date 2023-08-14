Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors

Namespace PhotoViewer
	Partial Public Class ProgressControl
		Inherits XtraUserControl
		Public Sub New()
			InitializeComponent()
		End Sub

		Public Property Maximum() As Integer
			Get
				Return progressBarControl1.Properties.Maximum
			End Get
			Set(ByVal value As Integer)
				progressBarControl1.Properties.Maximum = value
			End Set
		End Property
		Public Property Value() As Integer
			Get
				Return CInt(Fix(progressBarControl1.EditValue))
			End Get
			Set(ByVal value As Integer)
				progressBarControl1.EditValue = value
			End Set
		End Property
		Public Property ProgressText() As String
			Get
				Return labelControl1.Text
			End Get
			Set(ByVal value As String)
				labelControl1.Text = value
			End Set
		End Property
	End Class
End Namespace
