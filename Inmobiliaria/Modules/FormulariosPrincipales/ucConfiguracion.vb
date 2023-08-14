




Partial Public Class ucConfiguracion

    Inherits DevExpress.XtraEditors.XtraForm

    Public Sub New()
        InitializeComponent()

    End Sub

    Private Sub ucAlarmas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AparienciaGeneral()
       
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Salir()
    End Sub
    Private Sub Salir()

        Me.Dispose()

    End Sub

 

End Class





