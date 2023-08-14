Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid

Partial Public Class UcAsignacionTipoPortales

    Inherits DevExpress.XtraEditors.XtraUserControl

    Dim bd As BaseDatos
    Private WithEvents BinSrc As BindingSource

    Dim bdPortales As BaseDatos
    Private WithEvents BinSrcPortales As BindingSource

    Dim Cargando As Boolean
    Dim SentenciaSQL As String

    Dim CampoYTablaBase As String = "Tipo"
    Dim TablaPortal As String = "Portales"
    Public Portal As String = ""

    Public Sub New(Venta As Boolean)
        InitializeComponent()
        If Venta Then
            CampoYTablaBase &= "Venta"
        End If
        TablaPortal = CampoYTablaBase & TablaPortal
    End Sub
    'Private Sub showButton(ByRef bt As uc_tb_SimpleButton, ByRef position As Integer)
    '    bt.Visible = True
    '    bt.Location = New Point(5 + ((position * bt.Width) + (6 * position)), bt.Location.Y)
    '    position += 1
    'End Sub
    Private Sub ucASunto_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim portals As String = ""
        Dim numBotones As Integer = 0

        Dim dtr As Object
        bd = New BaseDatos
        dtr = bd.ExecuteReader("SELECT DISTINCT(Portal) FROM ClientePortales WHERE CodigoEmpresa=" & DatosEmpresa.Codigo)
        If dtr.hasrows Then
            While dtr.read
                If GL_PortalesCreados.Contains(dtr("Portal")) Then
                    Dim bt As New uc_tb_SimpleButton
                    bt.Name = "btn" & dtr("Portal")
                    bt.Text = dtr("Portal")
                    bt.Visible = True
                    bt.Parent = PanelBotones
                    bt.Location = New Point(5 + ((numBotones * bt.Width) + (6 * numBotones)), btnSalir.Location.Y)
                    bt.TabIndex = numBotones + 2
                    bt.ToolTip = "Pulse F" & (numBotones + 1)
                    bt.Image = My.Resources.ResourceManager.GetObject(dtr("Portal"))
                    bt.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
                    bt.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
                    bt.Appearance.Options.UseTextOptions = True
                    bt.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
                    bt.Size = btnSalir.Size
                    AddHandler bt.Click, AddressOf btnPortal_Click
                    numBotones += 1
                    portals = dtr("Portal")
                End If

                'Select Case dtr("Portal")
                '    Case "YaEncontre"
                '        showButton(btnYaEncontre, numBotones)
                '    Case "FotoCasa"
                '        showButton(btnFotoCasa, numBotones)
                '    Case "Idealista"
                '        showButton(btnIdealista, numBotones)
                '    Case "Hogaria"
                '        showButton(btnHogaria, numBotones)
                '    Case "TuCasa"
                '        showButton(btnTuCasa, numBotones)
                'End Select
            End While
        End If
        dtr.close()

        'If btnHogaria.Visible Then
        '    portals = btnHogaria.Text
        'End If
        'If btnIdealista.Visible Then
        '    portals = btnIdealista.Text
        'End If
        'If btnFotoCasa.Visible Then
        '    portals = btnFotoCasa.Text
        'End If
        'If btnYaEncontre.Visible Then
        '    portals = btnYaEncontre.Text
        'End If

        If Portal = "" Then
            Portal = portals
        End If

        If Portal = "" Then
            Salir()
        End If

        AparienciaGeneral()
        MostrarImagenDeFondo()
        Cargando = True

        BinSrc = New BindingSource
        BinSrcPortales = New BindingSource

        CargarGrid()
        CargarGridPortal()

        ConfigurarGrid()
        ConfigurarGridPortal()

        PonerFocoRowFilterEnGridView(GvPortal, TablaPortal)
        PonerFocoRowFilterEnGridView(Gv, CampoYTablaBase)
        Try
            Gv.Focus()
            Gv.FocusedRowHandle = 0
        Catch ex As Exception
        End Try

        Cargando = False

    End Sub

    Private Sub CargarGridPortal()
        SentenciaSQL = "SELECT Contador,Portal," & _
            GL_SQL_SUBSTRING & "(" & CampoYTablaBase & ", " & _
            Funciones.SQL_CHARINDEX("'|'", CampoYTablaBase) & " + 1, " & GL_SQL_LEN & "(" & CampoYTablaBase & ")-" & _
            Funciones.SQL_CHARINDEX("'|'", CampoYTablaBase) & " + 1) AS " & CampoYTablaBase & " FROM " & TablaPortal & " WHERE Portal = '" & Portal & "'"

        bdPortales = New BaseDatos
        bdPortales.LlenarDataSet(SentenciaSQL, TablaPortal, , False, True)

        dgvxPortal.BindingContext = New BindingContext()
        BinSrcPortales.DataSource = bdPortales.ds
        BinSrcPortales.DataMember = TablaPortal
        dgvxPortal.DataSource = BinSrcPortales

        ParametrizarGrid(GvPortal)
    End Sub
    Private Sub CargarGrid()
        If CampoYTablaBase.Contains("Venta") Then
            Me.ParentForm.Text = "Asignar Ofertas con " & Portal
        Else
            Me.ParentForm.Text = "Asignar Tipos con " & Portal
        End If

        SentenciaSQL = "SELECT *," & Funciones.SQL_CASE_ISNULL(Replace("(SELECT " & _
            GL_SQL_SUBSTRING & "(" & CampoYTablaBase & ", " & _
            Funciones.SQL_CHARINDEX("'|'", CampoYTablaBase) & " + 1, " & GL_SQL_LEN & "(" & CampoYTablaBase & ")-" & _
            Funciones.SQL_CHARINDEX("'|'", CampoYTablaBase) & " + 1) AS " & CampoYTablaBase & _
            " FROM " & TablaPortal & " WHERE Contador=T.Contador" & Portal & ")", ",", "#") & ",'Sin asignar'") & " AS Asignacion FROM " & CampoYTablaBase & " T WHERE CodigoEmpresa = " & DatosEmpresa.Codigo
        SentenciaSQL = Replace(SentenciaSQL, "#", ",")
        bd = New BaseDatos
        bd.LlenarDataSet(SentenciaSQL, CampoYTablaBase, , False, True)

        dgvx.BindingContext = New BindingContext()
        BinSrc.DataSource = bd.ds
        BinSrc.DataMember = CampoYTablaBase
        dgvx.DataSource = BinSrc

        ParametrizarGrid(Gv)
    End Sub

    Private Sub ConfigurarGridPortal()
        With GvPortal


            .Columns(CampoYTablaBase).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

            If dgvx.tbEstablecerPerfilPredeterminado() Then
                Exit Sub
            End If

            .OptionsView.ShowGroupPanel = False
            .OptionsView.ShowAutoFilterRow = False

            .Columns("Contador").OptionsColumn.AllowShowHide = False
            .Columns("Contador").Visible = False
            .Columns("Portal").OptionsColumn.AllowShowHide = False
            .Columns("Portal").Visible = False

            If CampoYTablaBase.Contains("Venta") Then
                .Columns(CampoYTablaBase).Caption = "Oferta Portal"
            Else
                .Columns(CampoYTablaBase).Caption = "Tipo Portal"
            End If

            .BestFitColumns()

            'Sumatorios en agrupaciones
            .OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

            Dim ItemArticulo As GridGroupSummaryItem = New GridGroupSummaryItem()
            ItemArticulo.FieldName = "Contador"
            ItemArticulo.DisplayFormat = "{0:n0}"
            ItemArticulo.SummaryType = DevExpress.Data.SummaryItemType.Count
            .GroupSummary.Add(ItemArticulo)

            .OptionsView.ShowFooter = True
            .Columns(CampoYTablaBase).SummaryItem.FieldName = "Contador"
            .Columns(CampoYTablaBase).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            .Columns(CampoYTablaBase).SummaryItem.DisplayFormat = "Total Portal: {0:n0}"
        End With
    End Sub
    Private Sub ConfigurarGrid()

        Gv.Columns(CampoYTablaBase).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

        If dgvx.tbEstablecerPerfilPredeterminado() Then
            Exit Sub
        End If

        Gv.OptionsView.ShowGroupPanel = False
        Gv.OptionsView.ShowAutoFilterRow = False

        Gv.Columns("Contador").OptionsColumn.AllowShowHide = False
        Gv.Columns("Contador").Visible = False
        Gv.Columns("CodigoEmpresa").OptionsColumn.AllowShowHide = False
        Gv.Columns("CodigoEmpresa").Visible = False

        If CampoYTablaBase.Contains("Venta") Then
            Gv.Columns("Orden").OptionsColumn.AllowShowHide = False
            Gv.Columns("Orden").Visible = False
        Else
            Gv.Columns("TipoPrioridad").OptionsColumn.AllowShowHide = False
            Gv.Columns("TipoPrioridad").Visible = False
            Gv.Columns("Prioridad").OptionsColumn.AllowShowHide = False
            Gv.Columns("Prioridad").Visible = False
        End If

        For Each p In GL_Portales
            Gv.Columns("Contador" & p).OptionsColumn.AllowShowHide = False
            Gv.Columns("Contador" & p).Visible = False
        Next
        'Gv.Columns("ContadorYaEncontre").OptionsColumn.AllowShowHide = False
        'Gv.Columns("ContadorYaEncontre").Visible = False
        'Gv.Columns("ContadorIdealista").OptionsColumn.AllowShowHide = False
        'Gv.Columns("ContadorIdealista").Visible = False
        'Gv.Columns("ContadorFotoCasa").OptionsColumn.AllowShowHide = False
        'Gv.Columns("ContadorFotoCasa").Visible = False
        'Gv.Columns("ContadorHogaria").OptionsColumn.AllowShowHide = False
        'Gv.Columns("ContadorHogaria").Visible = False
        'Gv.Columns("ContadorTuCasa").OptionsColumn.AllowShowHide = False
        'Gv.Columns("ContadorTuCasa").Visible = False

        Gv.Columns("Asignacion").Caption = "Asignación"
        If CampoYTablaBase.Contains("Venta") Then
            Gv.Columns(CampoYTablaBase).Caption = "Oferta"
        Else
            Gv.Columns(CampoYTablaBase).Caption = "Tipo"
        End If

        Gv.BestFitColumns()

        'Sumatorios en agrupaciones
        Gv.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        Dim ItemArticulo As GridGroupSummaryItem = New GridGroupSummaryItem()
        ItemArticulo.FieldName = "Contador"
        ItemArticulo.DisplayFormat = "{0:n0}"
        ItemArticulo.SummaryType = DevExpress.Data.SummaryItemType.Count
        Gv.GroupSummary.Add(ItemArticulo)

        Gv.OptionsView.ShowFooter = True
        Gv.Columns(CampoYTablaBase).SummaryItem.FieldName = "Contador"
        Gv.Columns(CampoYTablaBase).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        Gv.Columns(CampoYTablaBase).SummaryItem.DisplayFormat = "Total: {0:n0}"

    End Sub

    Private Sub btnPortal_Click(sender As System.Object, e As System.EventArgs)
        Portal = TryCast(sender, uc_tb_SimpleButton).Text
        carga()
    End Sub
    Private Sub carga(Optional row As Integer = 0)
        Cargando = True
        CargarGrid()
        CargarGridPortal()
        PonerFocoRowFilterEnGridView(GvPortal, TablaPortal)
        PonerFocoRowFilterEnGridView(Gv, CampoYTablaBase)
        Try
            Gv.Focus()
            Gv.FocusedRowHandle = row
        Catch ex As Exception
        End Try
        Cargando = False
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Salir()
    End Sub
    Private Sub Salir()
        Me.ParentForm.Dispose()
        MostrarImagenDeFondo()
        LiberarMemoria()
    End Sub

#Region "ParaKeyPreview"

    Private Structure MSG
        Public hwnd As IntPtr
        Public message As Integer
        Public wParam As IntPtr
        Public lParam As IntPtr
        Public time As Integer
        Public pt_x As Integer
        Public pt_y As Integer
    End Structure

    <Runtime.InteropServices.DllImport("user32.dll", CharSet:=Runtime.InteropServices.CharSet.Auto)> _
    Private Shared Function PeekMessage(<Runtime.InteropServices.In(), Runtime.InteropServices.Out()> ByRef msg As MSG, hwnd As Runtime.InteropServices.HandleRef, msgMin As Integer, msgMax As Integer, remove As Integer) As Boolean
    End Function
    ''' <span class="code-SummaryComment"><summary> </span>
    ''' Trap any keypress before child controls get hold of them
    ''' <span class="code-SummaryComment"></summary></span>
    ''' <span class="code-SummaryComment"><param name="m">Windows message</param></span>
    ''' <span class="code-SummaryComment"><returns>True if the keypress is handled</returns></span>
    Protected Overrides Function ProcessKeyPreview(ByRef m As Message) As Boolean
        Const WM_KEYDOWN As Integer = &H100
        Const WM_KEYUP As Integer = &H101
        Const WM_CHAR As Integer = &H102
        Const WM_SYSCHAR As Integer = &H106
        Const WM_SYSKEYDOWN As Integer = &H104
        Const WM_SYSKEYUP As Integer = &H105
        Const WM_IME_CHAR As Integer = &H286

        Dim e As KeyEventArgs = Nothing

        If (m.Msg <> WM_CHAR) AndAlso (m.Msg <> WM_SYSCHAR) AndAlso (m.Msg <> WM_IME_CHAR) Then
            e = New KeyEventArgs(DirectCast(CInt(CLng(m.WParam)), Keys) Or ModifierKeys)
            If (m.Msg = WM_KEYDOWN) OrElse (m.Msg = WM_SYSKEYDOWN) Then
                TrappedKeyDown(e)
            End If
            'else
            '{
            '    TrappedKeyUp(e);
            '}

            ' Remove any WM_CHAR type messages if supresskeypress is true.
            If e.SuppressKeyPress Then
                Me.RemovePendingMessages(WM_CHAR, WM_CHAR)
                Me.RemovePendingMessages(WM_SYSCHAR, WM_SYSCHAR)
                Me.RemovePendingMessages(WM_IME_CHAR, WM_IME_CHAR)
            End If

            If e.Handled Then
                Return e.Handled
            End If
        End If
        Return MyBase.ProcessKeyPreview(m)
    End Function

    Private Sub RemovePendingMessages(msgMin As Integer, msgMax As Integer)
        If Not Me.IsDisposed Then
            Dim msg As New MSG()
            Dim handle As IntPtr = Me.Handle
            While PeekMessage(msg, New Runtime.InteropServices.HandleRef(Me, handle), msgMin, msgMax, 1)
            End While
        End If
    End Sub

    ''' <span class="code-SummaryComment"><summary></span>
    ''' This routine gets called if a keydown has been trapped 
    ''' before a child control can get it.
    ''' <span class="code-SummaryComment"></summary></span>
    ''' <span class="code-SummaryComment"><param name="e"></param></span>
    Private Sub TrappedKeyDown(e As KeyEventArgs)
        For i = 1 To PanelBotones.Controls.Count - 1
            If e.KeyCode = (111 + i) AndAlso PanelBotones.Controls(i).Visible Then
                Portal = PanelBotones.Controls(i).Text
                carga()
                e.Handled = True
                e.SuppressKeyPress = True
                Exit Sub
            End If
        Next
        'If e.KeyCode = 112 AndAlso btnYaEncontre.Visible Then 'Keys.F1 = 112
        '    Portal = "YaEncontre"
        '    carga()
        '    e.Handled = True
        '    e.SuppressKeyPress = True
        '    Exit Sub
        'End If

        'If e.KeyCode = 113 AndAlso btnFotoCasa.Visible Then
        '    Portal = "FotoCasa"
        '    carga()
        '    e.Handled = True
        '    e.SuppressKeyPress = True
        '    Exit Sub
        'End If

        'If e.KeyCode = 114 AndAlso btnIdealista.Visible Then
        '    Portal = "Idealista"
        '    carga()
        '    e.Handled = True
        '    e.SuppressKeyPress = True
        '    Exit Sub
        'End If

        'If e.KeyCode = 115 AndAlso btnHogaria.Visible Then
        '    Portal = "Hogaria"
        '    carga()
        '    e.Handled = True
        '    e.SuppressKeyPress = True
        '    Exit Sub
        'End If

        'If e.KeyCode = 116 AndAlso btnHogaria.Visible Then
        '    Portal = "TuCasa"
        '    carga()
        '    e.Handled = True
        '    e.SuppressKeyPress = True
        '    Exit Sub
        'End If
        

        If e.KeyCode = Keys.Escape Then
            Salir()
            e.Handled = True
            e.SuppressKeyPress = True
            Exit Sub
        End If

    End Sub

#End Region

    Private Sub GvPortal_FocusedRowChanged(sender As System.Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GvPortal.RowClick
        If Cargando OrElse Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle OrElse GvPortal.RowCount = 0 OrElse e.RowHandle = GridControl.AutoFilterRowHandle Then
            Return
        End If
        BD_CERO.Execute("UPDATE " & CampoYTablaBase & " SET Contador" & Portal & " = " & BinSrcPortales.Current("Contador") & " WHERE Contador =" & BinSrc.Current("Contador"), False)
        carga(Gv.FocusedRowHandle)
    End Sub

    Private Sub gv_RowCellStyle(ByVal sender As Object, ByVal e As RowCellStyleEventArgs) Handles Gv.RowCellStyle
        Dim View As GridView = sender
        If e.Column.FieldName = "Asignacion" AndAlso View.GetRowCellDisplayText(e.RowHandle, View.Columns("Asignacion")) = "Sin asignar" Then
            e.Appearance.ForeColor = Color.Red
        End If
    End Sub

End Class




