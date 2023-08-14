Public Class XtraForm1 


    Dim ItemSelec As String
    Dim TextoFormu As String
    Dim RibbonPageNombre As String

    'Private Sub frmProyectosListado_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated


    '    If RibbonPageNombre <> "" Then
    '        frmPrincipal.ribbonControl.SelectedPage = frmPrincipal.ribbonControl.Pages.Item(RibbonPageNombre)
    '        frmPrincipal.siStatus.Caption = TextoFormu

    '    End If


    'End Sub

    Private Sub XtraForm2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Salir()
    End Sub
    Private Sub Salir()
        Me.Dispose()
    End Sub

    Public Sub New(ItemSeleccionado As String, Optional p_RibbonPageNombre As String = "", Optional TextoFormulario As String = "")
        InitializeComponent()

        ItemSelec = ItemSeleccionado
        RibbonPageNombre = p_RibbonPageNombre
        If TextoFormulario <> "" Then
            TextoFormu = TextoFormulario
        Else
            TextoFormu = ItemSeleccionado
        End If

        Me.Text = TextoFormu
    End Sub

    
End Class