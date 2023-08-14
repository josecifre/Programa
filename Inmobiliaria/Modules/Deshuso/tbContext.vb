Imports DevExpress.Utils.Menu

Public Class tbContext
    Inherits DXPopupMenu

    Sub New()


        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.Items.Add(New DXMenuItem("Prueba1"))


    End Sub
    
End Class
