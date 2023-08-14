
Imports DevExpress.XtraBars
Imports System.Windows.Forms
Imports System
Imports System.Data

Public Class MiMenuRadial

    Dim GridMnuRadial As MyGridControl
    Dim BarManMnuRadial As New DevExpress.XtraBars.BarManager
    Dim Menu As DevExpress.XtraBars.Ribbon.RadialMenu
    'Dim CarpetaPerfiles As String
    'Dim PerfilActual As String
    'Dim FicheroInformacionPerfiles As String

    Sub New(GridPasado As MyGridControl, Optional TextoExtraCarpetaPerfiles As String = "")


        ' Este campo TextoExtraCarpetaPerfiles lo utilizo para grids que pueden representar varias opciones, por ejemplo el que saca presupuestos, facturas, etc.

        GridMnuRadial = GridPasado

        'Dim Predeterminado As String

        'CarpetaPerfiles = GL_CARPETA_PERFILES & "\" & GridMnuRadial.Parent.Name & "\" & GridMnuRadial.Name

        'If TextoExtraCarpetaPerfiles <> "" Then
        '    CarpetaPerfiles = CarpetaPerfiles & "\" & TextoExtraCarpetaPerfiles
        'End If

        'FicheroInformacionPerfiles = CarpetaPerfiles & "\InformacionPerfiles.xml"

        'Predeterminado = RecuperarPredeterminadoOActual("PREDETERMINADO")
        'EscribirPredeterminadoOActual(Predeterminado, "ACTUAL")


        AsignarAGridRadialMenu()
    End Sub

    Public Sub AsignarAGridRadialMenu()

        AddHandler BarManMnuRadial.ItemClick, AddressOf RadialPopMenu_ItemClick

        Dim ImageCollection1 As New DevExpress.Utils.ImageCollection

        Dim ZA As System.Drawing.Size
        ZA.Width = 32
        ZA.Height = 32

        ImageCollection1.ImageSize = ZA

        BarManMnuRadial.Form = GridMnuRadial

        ImageCollection1.AddImage(My.Resources.Excel)
        ImageCollection1.AddImage(My.Resources.PDF)
        ImageCollection1.AddImage(My.Resources.Mail)

        BarManMnuRadial.Images = ImageCollection1

        'Dim menu = New DevExpress.XtraBars.Ribbon.RadialMenu
        'menu.Manager = BarManMnuRadial
        'menu.AddItems(CreateBarItemsMenuExportar(BarManMnuRadial))
        'menu.Glyph = Resources.vert24
        'BarManMnuRadial.SetPopupContextMenu(GridMnuRadial, menu)


        'menu = New DevExpress.XtraBars.Ribbon.RadialMenu
        'menu.Manager = BarManager
        'For Each it As DevExpress.XtraBars.BarItem In BarMan.Items
        '    menu.AddItem(it)
        'Next
        'menu.Glyph = Resources.vert24
        'BarMan.SetPopupContextMenu(Grid, menu)




        'CreateBarItemsMenuExportar(BarManMnuRadial)

        PrepararRadialMenu()


    End Sub

    Public Sub RadialPopMenu_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs)

        Try

            If e.Item.Tag Is Nothing Then
                Exit Sub
            End If

            Dim gview As MyGridView = TryCast(GridMnuRadial.MainView, MyGridView)

            Dim ParaExportar As Boolean = True
            Dim ParaEmail As Boolean = False

            Dim Extension As String = ""

            Select Case e.Item.Tag.ToString
                Case "EXCEL"
                    Menu.Dispose()
                    PrepararRadialMenu()
                    Extension = "xlsx"
                    ExportarEnMenu(Extension, gview)


                Case "PDF"
                    Menu.Dispose()
                    PrepararRadialMenu()
                    Extension = "pdf"
                    ExportarEnMenu(Extension, gview)


                Case "EMAILEXCEL"
                    Extension = "xlsx"
                    Menu.Dispose()
                    PrepararRadialMenu()
                    EmailEnMenu(Extension, gview)


                Case "EMAILPDF"
                    Extension = "pdf"
                    Menu.Dispose()
                    PrepararRadialMenu()
                    EmailEnMenu(Extension, gview)

                Case "COPIARCELDA"

                    ParaExportar = False
                    ParaEmail = False
                    CopiarCeldaEnMnu(gview)

                    Menu.Dispose()
                    PrepararRadialMenu()
                    Exit Sub

                Case "COPIARFILA"

                    ParaExportar = False
                    ParaEmail = False
                    CopiarFilaEnMnu(gview)

                    Menu.Dispose()
                    PrepararRadialMenu()

                    Exit Sub

                Case "COPIARTODO"

                    ParaExportar = False
                    ParaEmail = False
                    CopiarTodoEnMnu(gview)

                    Menu.Dispose()
                    PrepararRadialMenu()
                    Exit Sub


                Case "PERFILACTUALCOMOPREDETERMINADO"




                    'barButtonItemPerfilActualComoPredeterminado.Tag = "PERFILACTUALCOMOPREDETERMINADO"
                    'barButtonItemPerfilGuardar.Tag = "PERFILGUARDAR"
                    'barButtonItemPerfilValoresPorDefecto.Tag = "PERFILVALORESPORDEFECTO"
                    'barButtonItemPerfilValoresPorDefecto.Tag = "PERFILSELECCIONAR"



                    'Case Else
                    '    ParaExportar = False
                    '    ParaEmail = False
            End Select


            'If ParaExportar Then

            '    Dim ofd As New SaveFileDialog
            '    Dim Fichero As String

            '    'ofd.Filter = "Archivos de Word(*.doc;*.docx)|*.doc;*.docx"

            '    'ofd.Filter = "Archivos doc |*.doc|docx|*.docx"

            '    ofd.Filter = "Archivos |*." & Extension & "|Todos|*.*"
            '    ofd.Title = "Seleccione un fichero"

            '    Menu.Dispose()

            '    If ofd.ShowDialog = DialogResult.OK Then


            '        Fichero = ofd.FileName

            '        Select Case e.Item.Tag.ToString
            '            Case "EXCEL"
            '                gview.ExportToXlsx(Fichero)

            '            Case "PDF"
            '                gview.ExportToPdf(Fichero)

            '        End Select
            '        System.Diagnostics.Process.Start(Fichero)

            '    Else
            '        MensajeError("No se guardó el docuemnto")
            '    End If

            '    PrepararRadialMenu()

            'End If

            ' If ParaEmail Then

            'Dim Fichero As String

            'Fichero = My.Application.Info.DirectoryPath & "/Resumen." & Extension

            'Try
            '    System.IO.File.Delete(Fichero)
            'Catch ex As Exception

            'End Try


            'Select Case e.Item.Tag.ToString
            '    Case "EMAILEXCEL"
            '        gview.ExportToXlsx(Fichero)

            '    Case "EMAILPDF"
            '        gview.ExportToPdf(Fichero)

            'End Select

            'Menu.Dispose()

            'FuncionesGenerales.Funciones.EnviarCorreo("", Fichero)

            'PrepararRadialMenu()


            '   End If


        Catch ex As Exception
            MensajeError(ex.Message)
        End Try


    End Sub
    Private Sub EmailEnMenu(Extension As String, gview As MyGridView)
        Dim Fichero As String

        Fichero = My.Application.Info.DirectoryPath & "\Resumen." & Extension

        Try
            System.IO.File.Delete(Fichero)
        Catch ex As Exception

        End Try


        Select Case Extension
            Case "xls", "xlsx"
                gview.ExportToXlsx(Fichero)

            Case "pdf"
                gview.ExportToPdf(Fichero)

        End Select

        FuncionesGenerales.Funciones.EnviarCorreo("", "", "", Fichero, False, True)

    End Sub
    Private Sub ExportarEnMenu(Extension As String, gview As MyGridView)

        Dim ofd As New SaveFileDialog
        Dim Fichero As String

        'ofd.Filter = "Archivos de Word(*.doc;*.docx)|*.doc;*.docx"

        'ofd.Filter = "Archivos doc |*.doc|docx|*.docx"

        ofd.Filter = "Archivos |*." & Extension & "|Todos|*.*"
        ofd.Title = "Seleccione un fichero"

        Menu.Dispose()

        If ofd.ShowDialog = DialogResult.OK Then


            Fichero = ofd.FileName

            Select Case Extension
                Case "xls", "xlsx"
                    gview.ExportToXlsx(Fichero)

                Case "pdf"
                    gview.ExportToPdf(Fichero)

            End Select
            System.Diagnostics.Process.Start(Fichero)

        Else
            MensajeError("No se guardó el docuemnto")
        End If


    End Sub


    Private Sub CopiarCeldaEnMnu(gview As MyGridView)
        If gview.RowCount = 0 Then
            MensajeError("Debe seleccionar una celda")
            Exit Sub
        End If

        If gview.FocusedRowHandle < 0 Then
            MensajeError("Debe seleccionar una celda")
            Exit Sub
        End If



        Dim TextoACopiar As String = TryCast(gview.GetRowCellValue(gview.FocusedRowHandle, gview.FocusedColumn), String)
        Clipboard.SetText(TextoACopiar)


    End Sub

    Private Sub CopiarFilaEnMnu(gview As MyGridView)
        If gview.RowCount = 0 Then
            MensajeError("Debe seleccionar una celda")
            Exit Sub
        End If

        If gview.FocusedRowHandle < 0 Then
            MensajeError("Debe seleccionar una celda")
            Exit Sub
        End If

        gview.CopyToClipboard()


    End Sub

    Private Sub CopiarTodoEnMnu(gview As MyGridView)

        If gview.RowCount = 0 Then
            MensajeError("Debe seleccionar una celda")
            Exit Sub
        End If

        If gview.FocusedRowHandle < 0 Then
            MensajeError("Debe seleccionar una celda")
            Exit Sub
        End If

        gview.OptionsSelection.MultiSelect = True

        gview.SelectAll()
        gview.CopyToClipboard()
        gview.OptionsSelection.MultiSelect = False


    End Sub



    Private Function CreateBarItemsMenuExportar() As BarItem()


        'EXCEL
        Dim barButtonItemExportarExcel As BarItem = New BarButtonItem(BarManMnuRadial, "", 0)
        barButtonItemExportarExcel.Tag = "EXCEL"

        'PDF
        Dim barButtonItemExportarPDF As BarItem = New BarButtonItem(BarManMnuRadial, "", 1)
        barButtonItemExportarPDF.Tag = "PDF"

        'EMAIL
        Dim barButtonItemEmailExcel As New BarCheckItem(BarManMnuRadial, False) With {.ImageIndex = 0, .Caption = "Excel"}
        Dim barButtonItemEmailPDF As New BarCheckItem(BarManMnuRadial, False) With {.ImageIndex = 1, .Caption = "PDF"}

        Dim subMenuItemsEmail() As BarItem = {barButtonItemEmailExcel, barButtonItemEmailPDF}
        barButtonItemEmailExcel.Tag = "EMAILEXCEL"
        barButtonItemEmailPDF.Tag = "EMAILPDF"
        Dim subMenuEmail As New BarSubItem(BarManMnuRadial, "Email", 2)
        subMenuEmail.Tag = "EMAIL"
        subMenuEmail.AddItems(subMenuItemsEmail)


        'COPIAR
        Dim barButtonItemCopiarCelda As New BarCheckItem(BarManMnuRadial, False) With {.ImageIndex = 0, .Caption = "Celda"}
        Dim barButtonItemCopiarFila As New BarCheckItem(BarManMnuRadial, False) With {.ImageIndex = 1, .Caption = "Fila"}
        Dim barButtonItemCopiarTodo As New BarCheckItem(BarManMnuRadial, False) With {.ImageIndex = 1, .Caption = "Todo"}

        Dim subMenuItemsCopiar() As BarItem = {barButtonItemCopiarCelda, barButtonItemCopiarFila, barButtonItemCopiarTodo}
        barButtonItemCopiarCelda.Tag = "COPIARCELDA"
        barButtonItemCopiarFila.Tag = "COPIARFILA"
        barButtonItemCopiarTodo.Tag = "COPIARTODO"
        Dim subMenuCopiar As New BarSubItem(BarManMnuRadial, "Copiar", 2)
        subMenuCopiar.Tag = "COPIAR"
        subMenuCopiar.AddItems(subMenuItemsCopiar)


        'PERFILES
        Dim barButtonItemPerfilActualComoPredeterminado As New BarCheckItem(BarManMnuRadial, False) With {.ImageIndex = 0, .Caption = "Celda"}
        Dim barButtonItemPerfilGuardar As New BarCheckItem(BarManMnuRadial, False) With {.ImageIndex = 1, .Caption = "Fila"}
        Dim barButtonItemPerfilValoresPorDefecto As New BarCheckItem(BarManMnuRadial, False) With {.ImageIndex = 1, .Caption = "Todo"}
        Dim barButtonItemPerfilSeleccionar As New BarCheckItem(BarManMnuRadial, False) With {.ImageIndex = 1, .Caption = "Todo"}

        Dim subMenuItemsPerfiles() As BarItem = {barButtonItemPerfilActualComoPredeterminado, barButtonItemPerfilGuardar, barButtonItemPerfilValoresPorDefecto, barButtonItemPerfilSeleccionar}
        barButtonItemPerfilActualComoPredeterminado.Tag = "PERFILACTUALCOMOPREDETERMINADO"
        barButtonItemPerfilGuardar.Tag = "PERFILGUARDAR"
        barButtonItemPerfilValoresPorDefecto.Tag = "PERFILVALORESPORDEFECTO"
        barButtonItemPerfilValoresPorDefecto.Tag = "PERFILSELECCIONAR"
        Dim subMenuPerfiles As New BarSubItem(BarManMnuRadial, "Perfiles", 2)
        subMenuPerfiles.Tag = "PERFILES"
        subMenuPerfiles.AddItems(subMenuItemsPerfiles)


        ''      subMen2u.AddItems(subMenuItems)

        'Dim barButtonItem2 As BarItem = New BarButtonItem(BarManMnuRadial, "", 2)
        'Dim barButtonItem7 As BarItem = New BarButtonItem(BarManMnuRadial, "Find", 1)
        'Dim barButtonItem8 As BarItem = New BarButtonItem(BarManMnuRadial, "Undo", 1)
        'Dim barButtonItem9 As BarItem = New BarButtonItem(BarManMnuRadial, "Redo", 2)

        Return New BarItem() {barButtonItemExportarExcel, barButtonItemExportarPDF, subMenuEmail, subMenuCopiar}

        'Return New BarItem() {barButtonItemExportarExcel, barButtonItemExportarPDF, subMenuEmail, barButtonItem7, barButtonItem8, barButtonItem9}
        '  Return New BarItem() {barButtonItemExportarExcel, barButtonItemExportarPDF, barButtonItem2}
    End Function

    Public Sub PrepararRadialMenu()

        '    Dim menu = New DevExpress.XtraBars.Ribbon.RadialMenu
        Menu = New DevExpress.XtraBars.Ribbon.RadialMenu
        Menu.Manager = BarManMnuRadial
        Menu.AddItems(CreateBarItemsMenuExportar())
        Menu.Glyph = My.Resources.vert24
        BarManMnuRadial.SetPopupContextMenu(GridMnuRadial, Menu)


        'Dim menu As New DevExpress.XtraBars.Ribbon.RadialMenu
        'menu = New DevExpress.XtraBars.Ribbon.RadialMenu
        'menu.Manager = BarMan
        'For Each it As DevExpress.XtraBars.BarItem In BarMan.Items
        '    menu.AddItem(it)
        'Next
        'menu.Glyph = Resources.vert24
        'BarMan.SetPopupContextMenu(Grid, menu)

        '   Return Menu

    End Sub

    'Private Function RecuperarPredeterminadoOActual(ByVal Tipo) As String

    '    If Not System.IO.File.Exists(FicheroInformacionPerfiles) Then
    '        Return ""
    '    End If

    '    Dim Predeterminado As String = ""
    '    Dim dt As DataTable
    '    Dim ds As New DataSet
    '    ds.ReadXmlSchema(FicheroInformacionPerfiles)
    '    ds.ReadXml(FicheroInformacionPerfiles)
    '    dt = ds.Tables("Info")
    '    For Each drr As DataRow In dt.Rows
    '        If drr("Tipo") = Tipo Then
    '            Predeterminado = drr("Nombre")
    '        End If
    '    Next

    '    Return Predeterminado

    'End Function

    'Private Sub EscribirPredeterminadoOActual(ByVal NombrePerfil As String, ByVal Tipo As String, Optional ByVal ValoresPorDefecto As Boolean = False)

    '    If Tipo = "PREDETERMINADO" AndAlso NombrePerfil = "" AndAlso Not ValoresPorDefecto Then
    '        MessageBox.Show("Debe guardar el perfil con un nombre para establecerlo como predeterminado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        Exit Sub
    '    End If

    '    If Not ValoresPorDefecto Then
    '        If Not System.IO.File.Exists(FicheroInformacionPerfiles) Then
    '            If Tipo = "PREDETERMINADO" Then
    '                ComprobarYCrearCarpetas(CarpetaPerfiles)
    '                System.IO.File.Copy(My.Application.Info.DirectoryPath & "/InformacionPerfiles.xml", FicheroInformacionPerfiles)
    '            Else
    '                Exit Sub
    '            End If

    '        End If
    '    End If

    '    Dim dt As DataTable
    '    '  Dim dr As DataRow

    '    Dim ds As New DataSet
    '    ds.ReadXmlSchema(FicheroInformacionPerfiles)
    '    ds.ReadXml(FicheroInformacionPerfiles)
    '    dt = ds.Tables("Info")
    '    For Each drr As DataRow In dt.Rows
    '        If drr("Tipo") = Tipo Then
    '            drr("Nombre") = NombrePerfil
    '            ds.AcceptChanges()
    '            ds.WriteXml(FicheroInformacionPerfiles, XmlWriteMode.WriteSchema)

    '        End If
    '    Next

    '    If Tipo = "PREDETERMINADO" Then
    '        If ValoresPorDefecto Then
    '            MessageBox.Show("Debe salir y volver a entrar en la pantalla para completar los cambios.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Else
    '            MessageBox.Show("Diseño establecido como predeterminado correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '        End If

    '    End If


    '    'If Tipo = "ACTUAL" Then
    '    '    Try
    '    '        mnuPerfilActual.Text = "Perfil Actual: " & NombrePerfil

    '    '    Catch ex As Exception

    '    '    End Try
    '    'End If


    'End Sub

    Private Function ComprobarYCrearCarpetas(ByVal Directorio As String) As String

        If Not IO.Directory.Exists(Directorio) Then
            IO.Directory.CreateDirectory(Directorio)
        End If
        Return Directorio
    End Function
End Class
