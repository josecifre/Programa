'Imports DevExpress.XtraBars
'Imports System.Windows.Forms
'Imports System

'Module MenuRadial

'    Public Sub AsignarAGridRadialMenu(Grid As MyGridControl, BarMan As DevExpress.XtraBars.BarManager)

'        AddHandler BarMan.ItemClick, AddressOf RadialPopMenu_ItemClick

'        Dim ImageCollection1 As New DevExpress.Utils.ImageCollection

'        Dim ZA As System.Drawing.Size
'        ZA.Width = 32
'        ZA.Height = 32

'        ImageCollection1.ImageSize = ZA

'        BarMan.Form = Grid

'        ImageCollection1.AddImage(Resources.excel)
'        ImageCollection1.AddImage(Resources.PDF)
'        ImageCollection1.AddImage(Resources.Mail)



'        BarMan.Images = ImageCollection1


'        CreateBarItemsMenuExportar(BarMan)
'        '            menu.AddItems(CreateBarItemsMenuExportar(BarMan))

'        PrepararRadialMenu(Grid, BarMan)


'    End Sub

'    Public Sub RadialPopMenu_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs)

'        Try

'            If e.Item.Tag Is Nothing Then
'                Exit Sub
'            End If
'            '  menu.HidePopup()

'            '     AsignarAGridRadialMenu(dgvx)

'            Dim ParaExportar As Boolean = True
'            Dim ParaEmail As Boolean = False

'            Dim Extension As String = ""

'            Select Case e.Item.Tag.ToString
'                Case "EXCEL"
'                    Extension = "xlsx"
'                    ParaExportar = True
'                    ParaEmail = False

'                Case "PDF"
'                    Extension = "pdf"
'                    ParaExportar = True
'                    ParaEmail = False

'                Case "EMAILEXCEL"
'                    Extension = "xlsx"
'                    ParaExportar = False
'                    ParaEmail = True

'                Case "EMAILPDF"
'                    Extension = "pdf"
'                    ParaExportar = False
'                    ParaEmail = True

'                Case Else
'                    ParaExportar = False
'                    ParaEmail = False
'            End Select


'            If ParaExportar Then

'                Dim ofd As New SaveFileDialog
'                Dim Fichero As String

'                'ofd.Filter = "Archivos de Word(*.doc;*.docx)|*.doc;*.docx"

'                'ofd.Filter = "Archivos doc |*.doc|docx|*.docx"

'                ofd.Filter = "Archivos |*." & Extension & "|Todos|*.*"
'                ofd.Title = "Seleccione un fichero"

'                Menu.Dispose()

'                If ofd.ShowDialog = DialogResult.OK Then

'                    Dim barman As BarManager = TryCast(sender, BarManager)
'                    Dim gcontrol As MyGridControl = TryCast(barman.Form, MyGridControl)
'                    Dim gview As MyGridView = TryCast(gcontrol.MainView, MyGridView)

'                    Fichero = ofd.FileName

'                    Select Case e.Item.Tag.ToString
'                        Case "EXCEL"
'                            gview.ExportToXlsx(Fichero)

'                        Case "PDF"
'                            gview.ExportToPdf(Fichero)

'                    End Select
'                    System.Diagnostics.Process.Start(Fichero)

'                Else
'                    MensajeError("No se guardó el docuemnto")
'                End If

'                PrepararRadialMenu(dgvx, BarManager1)

'            End If

'            If ParaEmail Then

'                Dim Fichero As String

'                Fichero = My.Application.Info.DirectoryPath & "/Resumen." & Extension

'                Try
'                    System.IO.File.Delete(Fichero)
'                Catch ex As Exception

'                End Try

'                Dim barman As BarManager = TryCast(sender, BarManager)
'                Dim gcontrol As MyGridControl = TryCast(barman.Form, MyGridControl)
'                Dim gview As MyGridView = TryCast(gcontrol.MainView, MyGridView)

'                Select Case e.Item.Tag.ToString
'                    Case "EMAILEXCEL"
'                        gview.ExportToXlsx(Fichero)

'                    Case "EMAILPDF"
'                        gview.ExportToPdf(Fichero)

'                End Select

'                Menu.Dispose()

'                FuncionesGenerales.Funciones.EnviarCorreo("", Fichero)

'                PrepararRadialMenu(dgvx, BarManager1)


'            End If


'        Catch ex As Exception
'            MensajeError(ex.Message)
'        End Try


'    End Sub

'    Public Function PrepararRadialMenu(Grid As MyGridControl, BarMan As DevExpress.XtraBars.BarManager) As DevExpress.XtraBars.Ribbon.RadialMenu

'        Dim menu As New DevExpress.XtraBars.Ribbon.RadialMenu
'        menu = New DevExpress.XtraBars.Ribbon.RadialMenu
'        menu.Manager = BarMan
'        For Each it As DevExpress.XtraBars.BarItem In BarMan.Items
'            menu.AddItem(it)
'        Next
'        menu.Glyph = Resources.vert24
'        BarMan.SetPopupContextMenu(Grid, menu)

'        Return menu

'    End Function

'    Private Function CreateBarItemsMenuExportar(BarManager1 As BarManager) As BarItem()
'        ' Create bar items to display in Radial Menu
'        'Dim barButtonItemJose As BarItem

'        'barButtonItemJose = New BarButtonItem

'        'barButtonItemJose.Manager = BarManager1
'        'barButtonItemJose.LargeImageIndex = 0
'        'Return New BarItem() {barButtonItemJose}




'        Dim barButtonItem0 As BarItem = New BarButtonItem(BarManager1, "", 0)
'        Dim barButtonItem1 As BarItem = New BarButtonItem(BarManager1, "", 1)
'        barButtonItem0.Tag = "EXCEL"
'        barButtonItem1.Tag = "PDF"

'        Dim barButtonItem2 As BarItem = New BarButtonItem(BarManager1, "", 2)

'        'barButtonItem2.Appearance.GetImage()
'        'barButtonItem2.Appearance.BackColor = Color.AliceBlue
'        'barButtonItem2.LargeWidth = 80


'        '' Sub-menu with 3 check buttons


'        Dim subMenu As New BarSubItem(BarManager1, "Email", 2)
'        subMenu.Tag = "EMAIL"
'        '   Dim subMen2u As New BarSubItem(BarManager1, "Email", 2)

'        Dim barCheckItem4 As New BarCheckItem(BarManager1, False) With {.ImageIndex = 0, .Caption = ""}
'        Dim barCheckItem5 As New BarCheckItem(BarManager1, False) With {.ImageIndex =1, .Caption = ""}
'        Dim subMenuItems() As BarItem = {barCheckItem4, barCheckItem5}
'        barCheckItem4.Tag = "EMAILEXCEL"
'        barCheckItem5.Tag = "EMAILPDF"

'        subMenu.AddItems(subMenuItems)
'        '      subMen2u.AddItems(subMenuItems)


'        Dim barButtonItem7 As BarItem = New BarButtonItem(BarManager1, "Find", 1)
'        Dim barButtonItem8 As BarItem = New BarButtonItem(BarManager1, "Undo", 1)
'        Dim barButtonItem9 As BarItem = New BarButtonItem(BarManager1, "Redo", 2)


'        Return New BarItem() {barButtonItem0, barButtonItem1, subMenu, barButtonItem7, barButtonItem8, barButtonItem9}
'        '  Return New BarItem() {barButtonItem0, barButtonItem1, barButtonItem2}
'    End Function

'End Module
