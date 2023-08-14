Imports DevExpress.XtraGrid.Views.Grid
Imports System.Drawing
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports DevExpress.Skins


Imports Microsoft.VisualBasic
Imports System

Imports System.ComponentModel
Imports System.Data

Imports System.Text

Imports DevExpress.XtraEditors

Imports System.Collections
Imports DevExpress.XtraEditors.Repository



Module FuncionesGeneralesD
    Public Enum Accion As Integer
        Ocular = 1
        Congelar
    End Enum
    Public Sub MensajeError(ByVal texto As String)

        MessageBox.Show(texto, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

    End Sub


    Public Sub MensajeInformacion(ByVal texto As String)

        MessageBox.Show(texto, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
    Public Sub CrearImageListBotones(ByRef CtrlNav As DevExpress.XtraEditors.ControlNavigator)

        CtrlNav.Buttons.ImageList = CargarImagenes()
        CtrlNav.Buttons.EndEdit.ImageIndex = 0
        CtrlNav.Buttons.Append.ImageIndex = 1
        CtrlNav.Buttons.CancelEdit.ImageIndex = 2
        CtrlNav.Buttons.Remove.ImageIndex = 3
        CtrlNav.Buttons.Edit.ImageIndex = 4


        CtrlNav.Buttons.First.Visible = False
        CtrlNav.Buttons.Next.Visible = False
        CtrlNav.Buttons.NextPage.Visible = False
        CtrlNav.Buttons.Last.Visible = False
        CtrlNav.Buttons.Prev.Visible = False
        CtrlNav.Buttons.PrevPage.Visible = False

    End Sub


    Public Function CargarImagenes() As System.Windows.Forms.ImageList

        Dim img As New System.Windows.Forms.ImageList

        Dim Tamano As System.Drawing.Size
        Tamano.Height = 32
        Tamano.Width = 32

        img.ImageSize = Tamano

        img.TransparentColor = System.Drawing.Color.Transparent
        img.Images.Add(My.Resources.Aceptar)
        img.Images.Add(My.Resources.Anadir)
        img.Images.Add(My.Resources.Cancelar)
        img.Images.Add(My.Resources.Eliminar)
        img.Images.Add(My.Resources.Modificar)



        'Me.ImageList3.ImageStream = CType(Resources.GetObject("ImageList3.ImageStream"), System.Windows.Forms.ImageListStreamer)
        'Me.pictureEdit1.EditValue = Resources.Under_Construction
        img.Images.SetKeyName(0, "Aceptar.png")
        img.Images.SetKeyName(1, "Anadir.png")
        img.Images.SetKeyName(2, "Cancelar.png")
        img.Images.SetKeyName(3, "Eliminar.png")
        img.Images.SetKeyName(4, "Modificar.png")

        Return img
    End Function
    Public Sub FormatearGrids(ByVal Gv As GridView, ByVal Tamano As Integer, ByVal AltoFila As Integer)

        '  Dim FuenteGrid As New System.Drawing.Font("Tahoma", Tamano, System.Drawing.FontStyle.Bold)

        '    Dim FuenteGrid As New System.Drawing.Font("Tahoma", Tamano, System.Drawing.FontStyle.Bold)
        Dim FuenteGrid As New System.Drawing.Font("Tahoma", Tamano, FontStyle.Regular)

        'Gv.Appearance.HideSelectionRow.BackColor = GL_ColorHide 'Color.LightBlue
        'Gv.Appearance.HideSelectionRow.ForeColor = GL_ColorTextoHide 'Color.Black
        'Gv.Appearance.HideSelectionRow.Font = New Font(FuenteGrid.FontFamily, FuenteGrid.Size, FontStyle.Bold)

        Gv.Appearance.FocusedRow.BackColor = GL_ColorSeleccionado 'Color.SteelBlue
        Gv.Appearance.FocusedRow.ForeColor = GL_ColorTextoSeleccionado 'Color.White
        Gv.Appearance.SelectedRow.Font = FuenteGrid
        '  Gv.Appearance.FocusedRow.Font = New Font(FuenteGrid.FontFamily, FuenteGrid.Size, FontStyle.Bold)


        Gv.Appearance.FocusedCell.BackColor = GL_ColorSeleccionado ' Color.SteelBlue
        Gv.Appearance.FocusedCell.ForeColor = GL_ColorTextoSeleccionado 'Color.White
        Gv.Appearance.SelectedRow.Font = FuenteGrid
        '   Gv.Appearance.FocusedCell.Font = New Font(FuenteGrid.FontFamily, FuenteGrid.Size, FontStyle.Bold)



        Gv.Appearance.Row.Font = FuenteGrid
        Gv.Appearance.HeaderPanel.Font = FuenteGrid
        Gv.Appearance.GroupPanel.Font = FuenteGrid
        Gv.Appearance.FooterPanel.Font = FuenteGrid



        Gv.Appearance.SelectedRow.BackColor = GL_ColorSeleccionado ' Color.SteelBlue
        Gv.Appearance.SelectedRow.ForeColor = GL_ColorTextoSeleccionado 'Color.White
        Gv.Appearance.SelectedRow.Font = FuenteGrid




        '   Gv.Appearance.SelectedRow.BackColor = 'Color.Silver
        Gv.Appearance.FilterPanel.Font = FuenteGrid
        '   Gv.Appearance.EvenRow.ForeColor = 'Color.Black
        Gv.RowHeight = AltoFila
        Gv.Appearance.EvenRow.Font = FuenteGrid
        Gv.Appearance.EvenRow.BackColor = GL_ColorFondoImpar
        Gv.OptionsView.EnableAppearanceEvenRow = False
        Gv.Appearance.FilterPanel.Font = FuenteGrid

        Gv.Appearance.FilterPanel.Options.UseFont = True

        Gv.Appearance.FocusedCell.Font = FuenteGrid
        Gv.Appearance.FocusedCell.BackColor = GL_ColorSeleccionado ' Color.SteelBlue
        Gv.Appearance.FocusedCell.ForeColor = GL_ColorTextoSeleccionado 'Color.White

        Gv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center


        Gv.OptionsNavigation.EnterMoveNextColumn = True
        Gv.OptionsNavigation.UseTabKey = True
        Gv.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        Gv.OptionsView.ShowGroupPanel = False
        Gv.OptionsBehavior.Editable = False
        Gv.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        Gv.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
        Gv.OptionsView.ColumnAutoWidth = True
        Gv.OptionsView.ShowAutoFilterRow = False


        Gv.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True

        'Dim gcontrol As MyGridControl = TryCast(Gv.GridControl, MyGridControl)
        'gcontrol.tbCarpetaPerfiles = GL_CARPETA_PERFILES & "\" & gcontrol.Parent.Name & "\" & gcontrol.Name
        'If TextoExtraCarpetaPerfiles <> "" Then
        '    gcontrol.tbCarpetaPerfiles = gcontrol.tbCarpetaPerfiles & "\" & TextoExtraCarpetaPerfiles
        'End If

        'If AnadirMenuRadial Then
        '    Dim MiMenu As MiMenuRadial = New MiMenuRadial(gcontrol, TextoExtraCarpetaPerfiles)
        'End If


        'Dim tb_Check As New RepositoryItemCheckEdit()
        'tb_Check = dgvx.RepositoryItems("tbRichk")
        'Gv.Columns("A_MA").ColumnEdit = tb_Check


        Dim riMyCheckEdit = New RepositoryItemCheckEdit
        riMyCheckEdit.Name = "tbRichk"
        riMyCheckEdit.Caption = "Markcheck"
        'riChk.Appearance.BackColor = 'Color.Red
        'riChk.Appearance.Options.UseBackColor = True
        'riChk.AppearanceDisabled.BackColor = 'Color.Red
        ' Me.riMyCheckEdit.AutoHeight = False
        riMyCheckEdit.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
        riMyCheckEdit.PictureChecked = My.Resources.sel
        riMyCheckEdit.PictureUnchecked = My.Resources.nosel
        riMyCheckEdit.PictureGrayed = My.Resources.nisinino
        '  Me.RepositoryItems.AddRange(New RepositoryItemMyCheckEdit() {Me.riMyCheckEdit})
        Dim gcontrol As MyGridControl = TryCast(Gv.GridControl, MyGridControl)
        gcontrol.RepositoryItems.Add(riMyCheckEdit)

        Dim riMyCheckEdit2 = New RepositoryItemCheckEdit
        riMyCheckEdit2.Name = "tbRichk2"
        riMyCheckEdit2.Caption = "Markcheck2"

        riMyCheckEdit2.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined

        riMyCheckEdit2.ValueChecked = Convert.ToByte(1)
        riMyCheckEdit2.ValueUnchecked = Convert.ToByte(0)
        'riMyCheckEdit2.ValueGrayed = Convert.ToByte(vbNull)


        riMyCheckEdit2.PictureChecked = My.Resources.sel
        riMyCheckEdit2.PictureUnchecked = My.Resources.nosel
        riMyCheckEdit2.PictureGrayed = My.Resources.nisinino

        gcontrol.RepositoryItems.Add(riMyCheckEdit2)

        Dim riMyCheckEdit3 = New RepositoryItemCheckEdit
        riMyCheckEdit3.Name = "tbRichk3"
        riMyCheckEdit3.Caption = "Markcheck3"

        riMyCheckEdit3.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined

        riMyCheckEdit3.ValueChecked = Convert.ToInt16(-1)
        riMyCheckEdit3.ValueUnchecked = Convert.ToInt16(0)
        'riMyCheckEdit3.ValueGrayed = Convert.ToByte(vbNull)


        riMyCheckEdit3.PictureChecked = My.Resources.sel
        riMyCheckEdit3.PictureUnchecked = My.Resources.nosel
        riMyCheckEdit3.PictureGrayed = My.Resources.nisinino

        gcontrol.RepositoryItems.Add(riMyCheckEdit3)

        AsignarCheckEdit(Gv, riMyCheckEdit, riMyCheckEdit2, riMyCheckEdit3)

    End Sub
    'Public Sub FormatearGrids(ByVal Gv As GridView, Optional ByVal Tamano As Integer = 9, Optional ByVal AltoFila As Integer = 22)

    '    '  Dim FuenteGrid As New System.Drawing.Font("Tahoma", Tamano, System.Drawing.FontStyle.Bold)

    '    Dim FuenteGrid As New System.Drawing.Font("Tahoma", Tamano, System.Drawing.FontStyle.Bold)

    '    Gv.Appearance.HideSelectionRow.BackColor = GL_ColorHide 'Color.LightBlue
    '    Gv.Appearance.HideSelectionRow.ForeColor = GL_ColorTextoHide 'Color.Black
    '    Gv.Appearance.HideSelectionRow.Font = New Font(FuenteGrid.FontFamily, FuenteGrid.Size, FontStyle.Bold)

    '    Gv.Appearance.FocusedRow.BackColor = GL_ColorSeleccionado 'Color.SteelBlue
    '    Gv.Appearance.FocusedRow.ForeColor = GL_ColorTextoSeleccionado 'Color.White
    '    Gv.Appearance.FocusedRow.Font = New Font(FuenteGrid.FontFamily, FuenteGrid.Size, FontStyle.Bold)


    '    Gv.Appearance.FocusedCell.BackColor = GL_ColorSeleccionado ' Color.SteelBlue
    '    Gv.Appearance.FocusedCell.ForeColor = GL_ColorTextoSeleccionado 'Color.White
    '    Gv.Appearance.FocusedCell.Font = New Font(FuenteGrid.FontFamily, FuenteGrid.Size, FontStyle.Bold)

    '    Gv.Appearance.Row.Font = FuenteGrid
    '    Gv.Appearance.HeaderPanel.Font = FuenteGrid
    '    Gv.Appearance.GroupPanel.Font = FuenteGrid
    '    Gv.Appearance.FooterPanel.Font = FuenteGrid


    '    '  Gv.Appearance.FocusedRow.BackColor = 'Color.Silver
    '    Gv.Appearance.SelectedRow.BackColor = GL_ColorSeleccionado ' Color.SteelBlue
    '    Gv.Appearance.SelectedRow.ForeColor = GL_ColorTextoSeleccionado 'Color.White
    '    Gv.Appearance.SelectedRow.Font = FuenteGrid




    '    '   Gv.Appearance.SelectedRow.BackColor = 'Color.Silver
    '    Gv.Appearance.FilterPanel.Font = FuenteGrid
    '    '   Gv.Appearance.EvenRow.ForeColor = 'Color.Black
    '    Gv.RowHeight = AltoFila
    '    Gv.Appearance.EvenRow.Font = FuenteGrid
    '    Gv.Appearance.EvenRow.BackColor = GL_ColorFondoImpar
    '    Gv.OptionsView.EnableAppearanceEvenRow = False
    '    Gv.Appearance.FilterPanel.Font = FuenteGrid

    '    Gv.Appearance.FilterPanel.Options.UseFont = True

    '    Gv.Appearance.FocusedCell.Font = FuenteGrid
    '    Gv.Appearance.FocusedCell.BackColor = GL_ColorSeleccionado ' Color.SteelBlue
    '    Gv.Appearance.FocusedCell.ForeColor = GL_ColorTextoSeleccionado 'Color.White

    '    Gv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center


    '    Gv.OptionsNavigation.EnterMoveNextColumn = True
    '    Gv.OptionsNavigation.UseTabKey = True
    '    Gv.OptionsView.NewItemRowPosition = NewItemRowPosition.None
    '    Gv.OptionsView.ShowGroupPanel = False
    '    Gv.OptionsBehavior.Editable = False
    '    Gv.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
    '    Gv.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
    '    Gv.OptionsView.ColumnAutoWidth = True
    '    Gv.OptionsView.ShowAutoFilterRow = False

    '    'Dim gcontrol As MyGridControl = TryCast(Gv.GridControl, MyGridControl)
    '    'gcontrol.tbCarpetaPerfiles = GL_CARPETA_PERFILES & "\" & gcontrol.Parent.Name & "\" & gcontrol.Name
    '    'If TextoExtraCarpetaPerfiles <> "" Then
    '    '    gcontrol.tbCarpetaPerfiles = gcontrol.tbCarpetaPerfiles & "\" & TextoExtraCarpetaPerfiles
    '    'End If

    '    'If AnadirMenuRadial Then
    '    '    Dim MiMenu As MiMenuRadial = New MiMenuRadial(gcontrol, TextoExtraCarpetaPerfiles)
    '    'End If


    '    'Dim tb_Check As New RepositoryItemCheckEdit()
    '    'tb_Check = dgvx.RepositoryItems("tbRichk")
    '    'Gv.Columns("A_MA").ColumnEdit = tb_Check


    '    Dim riMyCheckEdit = New RepositoryItemCheckEdit
    '    riMyCheckEdit.Name = "tbRichk"

    '    riMyCheckEdit.Caption = "Markcheck"
    '    'riChk.Appearance.BackColor = 'Color.Red
    '    'riChk.Appearance.Options.UseBackColor = True
    '    'riChk.AppearanceDisabled.BackColor = 'Color.Red
    '    ' Me.riMyCheckEdit.AutoHeight = False
    '    riMyCheckEdit.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
    '    riMyCheckEdit.PictureChecked = My.Resources.sel
    '    riMyCheckEdit.PictureUnchecked = My.Resources.nosel
    '    riMyCheckEdit.PictureGrayed = My.Resources.nisinino
    '    '  Me.RepositoryItems.AddRange(New RepositoryItemMyCheckEdit() {Me.riMyCheckEdit})
    '    Dim gcontrol As MyGridControl = TryCast(Gv.GridControl, MyGridControl)
    '    gcontrol.RepositoryItems.Add(riMyCheckEdit)

    '    AsignarCheckEdit(Gv, riMyCheckEdit)
    'End Sub
    Public Sub AsignarCheckEdit(ByVal Gv As DevExpress.XtraGrid.Views.Grid.GridView, ByVal ri As RepositoryItemCheckEdit, ByVal ri2 As RepositoryItemCheckEdit, ByVal ri3 As RepositoryItemCheckEdit)

        Dim dc As New DevExpress.XtraGrid.Columns.GridColumn
        For Each dc In Gv.Columns
            Select Case dc.ColumnType.Name
                Case "Boolean"
                    dc.ColumnEdit = ri
                Case "Byte"
                    dc.ColumnEdit = ri2
                Case "Int16"
                    dc.ColumnEdit = ri3
                Case "Int32"
                Case "String"
                Case "DateTime"
                Case Else

            End Select

        Next

    End Sub
    'Public Sub FormatearGrids(ByVal gr As GridView, Optional ByVal Tamano As Integer = 8, Optional ByVal AltoFila As Integer = 22, Optional ByVal AnadirMenuRadial As Boolean = False, Optional ByVal TextoExtraCarpetaPerfiles As String = "")

    '    Dim FuenteGrid As New System.Drawing.Font("Tahoma", Tamano, System.Drawing.FontStyle.Bold)

    '    gr.Appearance.Row.Font = FuenteGrid
    '    gr.Appearance.HeaderPanel.Font = FuenteGrid
    '    gr.Appearance.GroupPanel.Font = FuenteGrid
    '    gr.Appearance.FooterPanel.Font = FuenteGrid
    '    gr.Appearance.FocusedRow.Font = FuenteGrid

    '    '  gr.Appearance.FocusedRow.BackColor = Color.Silver
    '    gr.Appearance.SelectedRow.Font = FuenteGrid

    '    '   gr.Appearance.SelectedRow.BackColor = Color.Silver
    '    gr.Appearance.FilterPanel.Font = FuenteGrid
    '    '   gr.Appearance.EvenRow.ForeColor = Color.Black
    '    gr.RowHeight = AltoFila
    '    gr.Appearance.EvenRow.Font = FuenteGrid
    '    '   gr.Appearance.EvenRow.BackColor = Color.AliceBlue
    '    ' gr.OptionsView.EnableAppearanceEvenRow = True
    '    gr.Appearance.FilterPanel.Font = FuenteGrid

    '    gr.Appearance.FilterPanel.Options.UseFont = True

    '    gr.Appearance.FocusedCell.Font = FuenteGrid

    '    gr.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center


    '    gr.OptionsNavigation.EnterMoveNextColumn = True
    '    gr.OptionsNavigation.UseTabKey = True
    '    gr.OptionsView.NewItemRowPosition = NewItemRowPosition.None
    '    gr.OptionsView.ShowGroupPanel = False
    '    gr.OptionsBehavior.Editable = False
    '    gr.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
    '    gr.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
    '    gr.OptionsView.ColumnAutoWidth = True
    '    gr.OptionsView.ShowAutoFilterRow = False

    '    'Dim gcontrol As MyGridControl = TryCast(gr.GridControl, MyGridControl)
    '    'gcontrol.tbCarpetaPerfiles = GL_CARPETA_PERFILES & "\" & gcontrol.Parent.Name & "\" & gcontrol.Name
    '    'If TextoExtraCarpetaPerfiles <> "" Then
    '    '    gcontrol.tbCarpetaPerfiles = gcontrol.tbCarpetaPerfiles & "\" & TextoExtraCarpetaPerfiles
    '    'End If

    '    'If AnadirMenuRadial Then
    '    '    Dim MiMenu As MiMenuRadial = New MiMenuRadial(gcontrol, TextoExtraCarpetaPerfiles)
    '    'End If

    'End Sub



    Public Sub SituarseEnGrid(ByVal gv As GridView, ByVal ValorBuscado As String, ByVal NombreDeCampoDondeBuscar As String, Optional ByVal InicioDeBusqueda As Integer = 1)
        Dim column As GridColumn = gv.Columns(NombreDeCampoDondeBuscar)
        If Not column Is Nothing Then
            ' locating the row 
            Dim rhFound As Integer = gv.LocateByDisplayText(InicioDeBusqueda, column, ValorBuscado)
            ' focusing the cell 
            If (rhFound <> GridControl.InvalidRowHandle) Then
                gv.FocusedRowHandle = rhFound
                '   gv.FocusedColumn = column
            End If
        End If
    End Sub

    Public Sub ParametrizarGrid(GridPasado As MyGridView, Optional ByVal Tamano As Integer = 10, Optional ByVal AltoFila As Integer = 20)

       
        FormatearGrids(GridPasado, Tamano, AltoFila)


        '  GridPasado.OptionsNavigation.EnterMoveNextColumn = True
        'GridPasado.OptionsNavigation.UseTabKey = True
        'GridPasado.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        'GridPasado.OptionsView.ShowGroupPanel = False
        'GridPasado.OptionsBehavior.Editable = False
        'GridPasado.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        'GridPasado.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
        'GridPasado.OptionsView.ColumnAutoWidth = True
        'GridPasado.OptionsView.ShowAutoFilterRow = False



        'GridPrincipal.Columns("ContadorPresupuesto").OptionsColumn.AllowEdit = False
        'GridPrincipal.Columns("Linea").OptionsColumn.AllowEdit = False
        'GridPrincipal.Columns("PorcentajeIVA").OptionsColumn.AllowEdit = False
        'GridPrincipal.Columns("Total").OptionsColumn.AllowEdit = False
        'GridPrincipal.Columns("Coeficiente").OptionsColumn.AllowEdit = False
        'GridPrincipal.Columns("DescuentoRecalculo").OptionsColumn.AllowEdit = False
        'GridPrincipal.Columns("TipoIVA").OptionsColumn.AllowEdit = False
        'GridPrincipal.Columns("Coeficiente").OptionsColumn.AllowEdit = False

        'GridPrincipal.Columns("Familia").OptionsColumn.AllowEdit = False
        'GridPrincipal.Columns("Familia").OptionsColumn.AllowFocus = False

        'GridPrincipal.Columns("CodigoFamilia").OptionsColumn.AllowEdit = False
        'GridPrincipal.Columns("CodigoFamilia").OptionsColumn.AllowFocus = False

        'GridPrincipal.Columns("ContadorPresupuesto").OptionsColumn.AllowFocus = False
        'GridPrincipal.Columns("Linea").OptionsColumn.AllowFocus = False
        'GridPrincipal.Columns("PorcentajeIVA").OptionsColumn.AllowFocus = False
        'GridPrincipal.Columns("Total").OptionsColumn.AllowFocus = False
        'GridPrincipal.Columns("Coeficiente").OptionsColumn.AllowFocus = False
        'GridPrincipal.Columns("DescuentoRecalculo").OptionsColumn.AllowFocus = False
        'GridPrincipal.Columns("DescuentoRecalculo").Visible = False
        'GridPrincipal.Columns("TipoIVA").OptionsColumn.AllowFocus = False



        'GridPrincipal.Columns("ContadorPresupuesto").Visible = False
        'GridPrincipal.Columns("CodigoFamilia").Visible = False
        'GridPrincipal.Columns("Linea").Visible = False
        'GridPrincipal.Columns("PorcentajeIVA").Visible = False
        'GridPrincipal.Columns("TipoIVA").Visible = False
        'GridPrincipal.Columns("Familia").Visible = False




        'GridPrincipal.Columns("Articulo").Width = 280
        'GridPrincipal.Columns("Codigo").Width = 100

        'GridPrincipal.Columns("Descuento").Caption = "% Desc."
        'GridPrincipal.Columns("DescuentoRecalculo").Caption = "% Recalc."

        'GridPrincipal.Columns("Precio").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric


        'GridPrincipal.BestFitMaxRowCount = 20
        'GridPrincipal.BestFitColumns()
        'GridPrincipal.OptionsView.ShowAutoFilterRow = False

        'If Estado = GL_ACEPTADO Then
        '    GridPrincipal.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        '    GridPrincipal.OptionsBehavior.Editable = False
        'End If


        'GridPrincipal.ShowButtonMode = Views.Base.ShowButtonModeEnum.ShowAlways
        '     GridPrincipal.ShowFindPanel()
        'Sumatorio en el pie del grid
        '   GridPrincipal.FooterPanelHeight = 20

        '    GridPrincipal.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always

        'Sumatorios en agrupaciones
        '  GridPrincipal.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways

        '    Dim ItemArticulo As GridGroupSummaryItem = New GridGroupSummaryItem()


        'Dim filterString As String = "Nombre LIKE '%a%'"
        'GridPrincipal.Columns("Nombre").FilterInfo = New Columns.ColumnFilterInfo(ColumnFilterType.Custom, Nothing, filterString)



        '   GridPrincipal.Columns("Nombre").FilterInfo.Type.Custom()



        'ItemArticulo.FieldName = "CodigoSIG"
        'ItemArticulo.DisplayFormat = " - Estudios: {0:n0}"
        'ItemArticulo.SummaryType = DevExpress.Data.SummaryItemType.Count
        'GridPrincipal.GroupSummary.Add(ItemArticulo)


        'GridPrincipal.OptionsView.ShowFooter = True
        'GridPrincipal.Columns("CodigoSIG").SummaryItem.FieldName = "CodigoSIG"
        'GridPrincipal.Columns("CodigoSIG").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        'GridPrincipal.Columns("CodigoSIG").SummaryItem.DisplayFormat = "Estudios: {0:n0}"


    End Sub

    Public Sub AparienciaGeneral()
        'DevExpress.Utils.AppearanceObject.DefaultFont = New System.Drawing.Font("Tahoma", 10, System.Drawing.FontStyle.Bold)
        '   DevExpress.Utils.AppearanceObject.DefaultFont = New System.Drawing.Font("Tahoma", 7)
        '    CommonSkins.GetSkin(LookAndFeel).Colors(CommonColors.DisabledControl) = Color.White

        DevExpress.Utils.AppearanceObject.DefaultFont = New System.Drawing.Font("Tahoma", 11)

        CommonSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default).Colors(CommonColors.DisabledControl) = Color.White
        'Color HotTrack
        'GL_ColorTextoBotones = System.Drawing.Color.FromArgb(255, 0, 102, 204)


        'GL_ColorTextoBotones.

        'If GridPrincipal.GetDataRow(GridPrincipal.FocusedRowHandle).Item("Color") <> 0 Then
        '    Dim col As New System.Drawing.Color
        '    col = System.Drawing.Color.FromArgb(GridPrincipal.GetDataRow(GridPrincipal.FocusedRowHandle).Item("Color"))
        '    btnColor.BackColor = Color.FromArgb(col.A, col.B, col.G, col.R)
        'End If


        ' Dim col As New System.Drawing.Color
        '   GL_ColorTextoBotones = System.Drawing.Color.FromArgb(255, 0, 102, 204)
        'Tab.Color = col.ToArgb



    End Sub
    Public Sub OcultarCongelarColumnasDevExpressGridLookUpEdit(ByVal Nombres() As String, ByVal cmb As DevExpress.XtraEditors.GridLookUpEdit, ByVal AccionAEjecutar As Integer)
        If Nombres IsNot Nothing Then
            Dim Columnas As New List(Of String)
            Columnas.AddRange(Nombres)

            For i = 0 To cmb.Properties.View.Columns.Count - 1
                For Each c As String In Columnas
                    If c.ToUpper = cmb.Properties.View.Columns(i).Name.ToUpper Then
                        cmb.Properties.View.Columns(i).Visible = False
                    End If
                Next
            Next

            '  Dim dc As New DevExpress.XtraGrid.Columns.GridColumnCollection
            'For Each dc In cmb.Properties.View.Columns
            '    For Each c As String In Columnas
            '        If c.ToUpper = dc..ToUpper Then
            '            Select Case AccionAEjecutar
            '                Case Accion.Ocular
            '                    cmb.Properties.View.Columns(dc.FieldName).Visible = False
            '                Case Accion.Congelar
            '                    cmb.Properties.View.Columns(dc.FieldName).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            '                    ' En congelar solo ponemos una columna
            '                    Exit Sub
            '            End Select
            '            Exit For
            '        End If
            '    Next
            'Next
        End If
    End Sub
    Public Sub OcultarCongelarColumnasDevExpress(ByVal Columnas As List(Of String), ByVal Nombres() As String, ByVal dgvx As DevExpress.XtraGrid.Views.Grid.GridView, ByVal AccionAEjecutar As Integer)
        If Nombres IsNot Nothing Then
            Columnas.AddRange(Nombres)
            Dim dc As New DevExpress.XtraGrid.Columns.GridColumn
            For Each dc In dgvx.Columns
                For Each c As String In Columnas
                    If c.ToUpper = dc.FieldName.ToUpper Then
                        Select Case AccionAEjecutar
                            Case Accion.Ocular
                                dgvx.Columns(dc.FieldName).Visible = False
                            Case Accion.Congelar
                                dgvx.Columns(dc.FieldName).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                                ' En congelar solo ponemos una columna
                                Exit Sub
                        End Select
                        Exit For
                    End If
                Next
            Next
        End If
    End Sub
    Public Sub PonerFocoRowFilterEnGridView(gr As MyGridView, Campo As String)

        Try
            gr.Focus()

            gr.FocusedRowHandle = GridControl.AutoFilterRowHandle
            gr.FocusedColumn = gr.Columns(Campo)


            gr.TopRowIndex = 0

        Catch ex As Exception

        End Try


    End Sub

    Public Class MyObject

        Public Sub New()

        End Sub

        Private _ID As Integer
        Public Property ID() As Integer
            Get
                Return _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property

        Private _DisplayText As Object
        Public Property DisplayText() As Object
            Get
                Return _DisplayText
            End Get
            Set(ByVal value As Object)
                _DisplayText = value
            End Set
        End Property
    End Class

    Friend Class MyDataSourceWrapper
        Implements ITypedList, IList
        Private ReadOnly _DisplayMember As String
        Public ReadOnly NestedList As IList
        Public ReadOnly Property NestedTypedList() As ITypedList
            Get
                Return CType(NestedList, ITypedList)
            End Get
        End Property
        Public Sub New(ByVal list As ITypedList, ByVal nullObject As MyObject, ByVal valueMember As String, ByVal displayMember As String)
            _ValueMember = valueMember
            _DisplayMember = displayMember
            _NullObject = nullObject
            Me.NestedList = CType(list, IList)
        End Sub

        Private _NullObject As MyObject
        Private ReadOnly _ValueMember As String
        Public Property NullObject() As MyObject
            Get
                Return _NullObject
            End Get
            Set(ByVal value As MyObject)
                _NullObject = value
            End Set
        End Property

        Private Class EmptyObjectPropertyDescriptor
            Inherits PropertyDescriptor
            Private ReadOnly _DisplayMember As String
            Public ReadOnly NestedDescriptor As PropertyDescriptor
            Public ReadOnly NullObject As MyObject
            Private ReadOnly _ValueMember As String
            Public Sub New(ByVal nestedDescriptor As PropertyDescriptor, ByVal nullObject As MyObject, ByVal valueMember As String, ByVal displayMember As String)
                MyBase.New(nestedDescriptor.Name, CType(New ArrayList(nestedDescriptor.Attributes).ToArray(GetType(Attribute)), Attribute()))
                _DisplayMember = displayMember
                _ValueMember = valueMember
                Me.NestedDescriptor = nestedDescriptor
                Me.NullObject = nullObject
            End Sub
            Public Overrides Function CanResetValue(ByVal component As Object) As Boolean
                Return False
            End Function
            Public Overrides ReadOnly Property ComponentType() As Type
                Get
                    Return GetType(Object)
                End Get
            End Property
            Public Overrides Function GetValue(ByVal component As Object) As Object
                If component Is NullObject Then
                    If NestedDescriptor.Name = _ValueMember Then
                        Return NullObject.ID
                    ElseIf NestedDescriptor.Name = _DisplayMember Then
                        Return NullObject.DisplayText
                    End If
                    Return Nothing

                Else
                    Return NestedDescriptor.GetValue(component)
                End If
            End Function
            Public Overrides ReadOnly Property IsReadOnly() As Boolean
                Get
                    Return True
                End Get
            End Property
            Public Overrides ReadOnly Property PropertyType() As Type
                Get
                    Return NestedDescriptor.PropertyType
                End Get
            End Property
            Public Overrides Sub ResetValue(ByVal component As Object)
                Throw New NotSupportedException("The method or operation is not implemented.")
            End Sub
            Public Overrides Sub SetValue(ByVal component As Object, ByVal value As Object)
                Throw New NotSupportedException("The method or operation is not implemented.")
            End Sub
            Public Overrides Function ShouldSerializeValue(ByVal component As Object) As Boolean
                Return True
            End Function
        End Class
        Public Function GetItemProperties(ByVal listAccessors() As PropertyDescriptor) As PropertyDescriptorCollection Implements ITypedList.GetItemProperties
            Dim result As New List(Of PropertyDescriptor)()
            For Each pd As PropertyDescriptor In NestedTypedList.GetItemProperties(ExtractOriginalDescriptors(listAccessors))
                Dim nullVal As Object = Nothing
                If pd.PropertyType Is GetType(String) Then
                    nullVal = "[empty]"
                End If
                result.Add(New EmptyObjectPropertyDescriptor(pd, NullObject, _ValueMember, _DisplayMember))
            Next pd
            Return New PropertyDescriptorCollection(result.ToArray())
        End Function
        Public Function GetListName(ByVal listAccessors() As PropertyDescriptor) As String Implements ITypedList.GetListName
            Return NestedTypedList.GetListName(ExtractOriginalDescriptors(listAccessors))
        End Function

        Protected Shared Function ExtractOriginalDescriptors(ByVal listAccessors() As PropertyDescriptor) As PropertyDescriptor()
            If listAccessors Is Nothing Then
                Return Nothing
            End If
            Dim convertedDescriptors(listAccessors.Length - 1) As PropertyDescriptor
            For i As Integer = 0 To convertedDescriptors.Length - 1
                Dim d As PropertyDescriptor = listAccessors(i)
                Dim c As EmptyObjectPropertyDescriptor = TryCast(d, EmptyObjectPropertyDescriptor)
                If c IsNot Nothing Then
                    convertedDescriptors(i) = c.NestedDescriptor
                Else
                    convertedDescriptors(i) = d
                End If
            Next i
            Return convertedDescriptors
        End Function
        Public Function Add(ByVal value As Object) As Integer Implements IList.Add
            Throw New NotSupportedException("The method or operation is not implemented.")
        End Function
        Public Sub Clear() Implements IList.Clear
            Throw New NotSupportedException("The method or operation is not implemented.")
        End Sub
        Public Function Contains(ByVal value As Object) As Boolean Implements IList.Contains
            If value Is NullObject Then
                Return True
            End If
            Return NestedList.Contains(value)
        End Function
        Public Function IndexOf(ByVal value As Object) As Integer Implements IList.IndexOf
            If value Is NullObject Then
                Return 0
            End If
            Dim nres As Integer = NestedList.IndexOf(value)
            If nres < 0 Then
                Return nres
            End If
            Return nres + 1
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As Object) Implements IList.Insert
            Throw New NotSupportedException("The method or operation is not implemented.")
        End Sub
        Public ReadOnly Property IsFixedSize() As Boolean Implements IList.IsFixedSize
            Get
                Return True
            End Get
        End Property
        Public ReadOnly Property IsReadOnly() As Boolean Implements IList.IsReadOnly
            Get
                Return True
            End Get
        End Property
        Public Sub Remove(ByVal value As Object) Implements IList.Remove
            Throw New NotSupportedException("The method or operation is not implemented.")
        End Sub
        Public Sub RemoveAt(ByVal index As Integer) Implements IList.RemoveAt
            Throw New NotSupportedException("The method or operation is not implemented.")
        End Sub
        Default Public Property Item(ByVal index As Integer) As Object Implements IList.Item

            Get
                Try
                    If index = 0 Then
                        Return NullObject
                    Else
                        Return NestedList(index - 1)
                    End If
                Catch ex As Exception
                    Return NullObject
                End Try

            End Get
            Set(ByVal value As Object)
                Throw New NotSupportedException("The method or operation is not implemented.")
            End Set
        End Property
        Public Sub CopyTo(ByVal array As Array, ByVal index As Integer) Implements System.Collections.ICollection.CopyTo
            Throw New NotSupportedException("The method or operation is not implemented.")
        End Sub
        Public ReadOnly Property Count() As Integer Implements System.Collections.ICollection.Count
            Get
                Return NestedList.Count + 1
            End Get
        End Property
        Public ReadOnly Property IsSynchronized() As Boolean Implements System.Collections.ICollection.IsSynchronized
            Get
                Return False
            End Get
        End Property
        Public ReadOnly Property SyncRoot() As Object Implements System.Collections.ICollection.SyncRoot
            Get
                Return NestedList.SyncRoot
            End Get
        End Property
        Public Function GetEnumerator() As IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Throw New NotSupportedException("The method or operation is not implemented.")
        End Function
    End Class

    Public Class MyGridLookupDataSourceHelper

        Private _MyObject As New MyObject()
        Private _DataSourceWrapper As MyDataSourceWrapper
        Private edit As GridLookUpEdit
        Private popupOpened As Boolean = False
        Public Sub New(ByVal edit As GridLookUpEdit, ByVal dataSource As ITypedList, ByVal displayMember As String, ByVal valueMember As String)
            Me.edit = edit
            _MyObject.ID = Int32.MinValue + 5
            _DataSourceWrapper = New MyDataSourceWrapper(dataSource, _MyObject, valueMember, displayMember)
            edit.Properties.DisplayMember = displayMember
            edit.Properties.ValueMember = valueMember
            edit.Properties.DataSource = _DataSourceWrapper
            AddHandler edit.Properties.View.CustomRowFilter, AddressOf View_CustomRowFilter
            AddHandler edit.ProcessNewValue, AddressOf edit_ProcessNewValue
            edit.Properties.View.RefreshData()
            AddHandler edit.Properties.QueryPopUp, AddressOf Properties_QueryPopUp
        End Sub

        Private Sub Properties_QueryPopUp(ByVal sender As Object, ByVal e As CancelEventArgs)
            Me.popupOpened = True
            edit.Properties.View.DataController.DoRefresh()
        End Sub

        Public Shared Sub SetupGridLookUpEdit(ByVal edit As GridLookUpEdit, ByVal dataSource As ITypedList, ByVal displayMember As String, ByVal valueMember As String)
            Dim TempMyGridLookupDataSourceHelper As MyGridLookupDataSourceHelper = New MyGridLookupDataSourceHelper(edit, dataSource, displayMember, valueMember)
        End Sub

        Private Sub View_CustomRowFilter(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowFilterEventArgs)
            If (Not popupOpened) Then
                Return
            End If
            If TypeOf _DataSourceWrapper(e.ListSourceRow) Is MyObject Then
                e.Visible = False
                e.Handled = True
            End If
        End Sub

        Private Sub edit_ProcessNewValue(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs)
            _MyObject.DisplayText = e.DisplayValue
            Me.popupOpened = False
            edit.Properties.View.DataController.DoRefresh()
            e.Handled = True
        End Sub
    End Class

End Module
