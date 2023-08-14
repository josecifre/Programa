Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns

Public Class ActualizaPerfil
    Dim gv2 As New GridView
    Dim cms As New tbContextMenuStripComponent
    Sub New(gv As GridView)
        For i = 0 To gv.Columns.Count - 1
            gv2.Columns.Add(gv.Columns(i))
        Next
    End Sub
    Public Sub ActualizaPerfil(gv As GridView, Perfil As String)
        Dim GuardarPerfil As Boolean = False
        If gv2 Is Nothing Then Exit Sub

        'revisamos todas las columnas de la vista de la bbdd
        For Each c As GridColumn In gv2.Columns
            'si algun campo de la bbdd no aparece en la vista cargada del perfil
            If gv.Columns.Item(c.FieldName) Is Nothing Then
                GuardarPerfil = True 'activamos el guardado del perfil con la nueva estructura
                Dim gc As GridColumn = New GridColumn()
                gc = gv2.Columns(c.FieldName)
                gc.Visible = False
                'añadimos las columnas q procedan
                gv.Columns.Add(gc)
            End If
        Next
        Dim gv3 As New GridView
        For Each c As GridColumn In gv.Columns
            'si algun campo de la  vista cargada del perfil no aparece en la bbdd
            If gv2.Columns.Item(c.FieldName) Is Nothing Then
                GuardarPerfil = True 'activamos el guardado del perfil con la nueva estructura
                'añadimos las columnas q posteriormente borraremos
                gv3.Columns.Add(c)
            End If
        Next
        For Each c As GridColumn In gv3.Columns
            'borramos las columnas q procedan
            gv.Columns.Remove(c)
        Next
        If GuardarPerfil Then 'guardamos le nuevo esquema de perfil
            cms.GuardarPerfilActual(gv, Perfil)
        End If

    End Sub

End Class
