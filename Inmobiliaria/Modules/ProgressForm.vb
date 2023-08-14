'Imports Microsoft.VisualBasic
'Imports System
'Imports System.Collections.Generic
'Imports System.ComponentModel
'Imports System.Data
'Imports System.Drawing
'Imports System.Text
'Imports System.Windows.Forms


Partial Public Class ProgressForm
    Inherits Form
    Public Sub New()
        InitializeComponent()

    End Sub
    Public Sub New(max As Integer, texto As String, Optional paso As Integer = 1, Optional PosicionInicio As FormStartPosition = FormStartPosition.CenterScreen)
        InitializeComponent()
        progressControl1.progressBarControl1.Properties.Step = paso
        progressControl1.Maximum = max
        progressControl1.ProgressText = texto
        StartPosition = PosicionInicio
        BringToFront()
        Show()
        Application.DoEvents()
    End Sub

    Public ReadOnly Property ProgressControl() As ProgressControl
        Get
            Return progressControl1
        End Get
    End Property

    Protected Overrides Sub OnLoad(ByVal e As EventArgs)
        MyBase.OnLoad(e)
        'progressControl1.Width = Me.Width 
        progressControl1.progressBarControl1.Width = progressControl1.Width - 14
        progressControl1.labelControl1.Location = New Point(progressControl1.progressBarControl1.Location.X, progressControl1.labelControl1.Location.Y)
        progressControl1.labelControl1.Width = progressControl1.progressBarControl1.Width
        '   CenterToParent()
    End Sub

    Public Sub nuevoPaso(Optional texto As String = "")
        progressControl1.progressBarControl1.PerformStep()
        If texto <> "" Then
            progressControl1.ProgressText = texto
        End If
        Application.DoEvents()
    End Sub
    Public Sub nuevoTexto(texto As String)
        progressControl1.ProgressText = texto
        Application.DoEvents()
    End Sub

End Class

