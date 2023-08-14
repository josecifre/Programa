Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.Skins

Namespace PhotoViewer
	Partial Public Class DateFilter
		Inherits XtraUserControl
        Private Shared ReadOnly _selectionChanged As Object = New Object()
        Public Sub New()
            InitializeComponent()
        End Sub
        Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
            MyBase.OnSizeChanged(e)

            _startDate.Location = New Point(DisplayRectangle.X + (DisplayRectangle.Width - _startDate.Width) \ 2, DisplayRectangle.Y + (panel1.Top - DisplayRectangle.Y - _startDate.Height) \ 2)
        End Sub

        Public ReadOnly Property StartDate() As DateTime
            Get
                If allowFilterCheck.Checked Then
                    Return _startDate.SelectionStart
                Else
                    Return DateTime.MinValue
                End If
            End Get
        End Property
        Public ReadOnly Property EndDate() As DateTime
            Get
                If allowFilterCheck.Checked Then
                    Return _startDate.SelectionEnd
                Else
                    Return DateTime.MinValue
                End If
            End Get
        End Property
        Public ReadOnly Property AllowFilter() As Boolean
            Get
                Return allowFilterCheck.Checked
            End Get
        End Property

        Protected Sub RaiseSelectionChanged()
            Dim handler As EventHandler = TryCast(Events(_selectionChanged), EventHandler)
            If handler IsNot Nothing Then
                handler(Me, EventArgs.Empty)
            End If
        End Sub
        Public Custom Event SelectionChanged As EventHandler
            AddHandler(ByVal value As EventHandler)
                Events.AddHandler(_selectionChanged, value)
            End AddHandler
            RemoveHandler(ByVal value As EventHandler)
                Events.RemoveHandler(_selectionChanged, value)
            End RemoveHandler
            RaiseEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
            End RaiseEvent
        End Event

		Private Sub allowFilterCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles allowFilterCheck.CheckedChanged
			RaiseSelectionChanged()
		End Sub

        Private Sub startDate_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _startDate.SelectionChanged
            RaiseSelectionChanged()
        End Sub

		Private Sub endDate_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
			RaiseSelectionChanged()
		End Sub
	End Class
End Namespace
