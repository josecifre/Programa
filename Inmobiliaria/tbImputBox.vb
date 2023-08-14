Public Class tbImputBox


    Sub New(Titulo As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        lblTitulo.Text = Titulo
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Aceptar()
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Gl_ResultadoBusqueda = Gl_ResultadoBusqueda_SALIR
        Me.Dispose()
    End Sub

  
    Private Sub txtResultado_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(Keys.Enter) Then
            Aceptar()
        End If
    End Sub

    Private Sub Aceptar()

        Gl_ResultadoBusqueda = txtResultado.Text
        Me.Dispose()
    End Sub
End Class