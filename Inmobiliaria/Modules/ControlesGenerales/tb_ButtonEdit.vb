Imports DevExpress.XtraEditors

Public Class tb_ButtonEdit

    ' TODO: *** Comprobar si es Inherits o Implements ***
    Inherits ButtonEdit


    Public Sub New()
        InitializeComponent()

    End Sub

    Private _NeedSelectAll As Boolean
    Public Property NeedSelectAll() As Boolean
        Get
            Return _NeedSelectAll
        End Get
        Set(value As Boolean)
            _NeedSelectAll = value
        End Set

    End Property

    Protected Sub R2(sender As Object, e As System.EventArgs) Handles Me.Enter
        MyBase.OnEnter(e)
        NeedSelectAll = True

    End Sub

    Private Sub R1() Handles Me.MouseUp

        If NeedSelectAll Then
            Me.Select(0, Me.Text.Length)
        End If
        NeedSelectAll = False

    End Sub



End Class
