Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid

Partial Public Class UcElegirPoblacionPortal

    Inherits DevExpress.XtraEditors.XtraUserControl

    Dim bd As BaseDatos
    Private WithEvents BinSrc As BindingSource

    Dim Cargando As Boolean
    Dim SentenciaSQL As String

    Private Portal As String = ""
    Private poblacion As String = ""

    Public Sub New(nombrePortal As String, nombrePoblacion As String)
        InitializeComponent()
        Portal = nombrePortal
        poblacion = nombrePoblacion
    End Sub

    Private Sub ucASunto_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Portal = "" Then
            Salir()
        End If

        AparienciaGeneral()
        MostrarImagenDeFondo()
        Cargando = True

        BinSrc = New BindingSource

        CargarGrid()

        ConfigurarGrid()

        PonerFocoRowFilterEnGridView(Gv, "Poblacion")
        Try
            Gv.Focus()
            Gv.FocusedRowHandle = 0
        Catch ex As Exception
        End Try

        Cargando = False

    End Sub

   
    Private Sub CargarGrid()

        Me.ParentForm.Text = "Elige la población equivalente a " & poblacion & " en " & Portal

        If Portal = "Hogaria" Then Portal = "YaEncontre" 'de momento para que utilice los datos de YaEncontre
        SentenciaSQL = "SELECT Contador,Poblacion,Provincia,(SELECT Provincia FROM Provincias WHERE Contador=P.Provincia) AS Prov FROM Poblacion" & Portal & " P ORDER BY Poblacion"

        bd = New BaseDatos
        bd.LlenarDataSet(SentenciaSQL, "Poblacion", , False, True)

        dgvx.BindingContext = New BindingContext()
        BinSrc.DataSource = bd.ds
        BinSrc.DataMember = "Poblacion"
        dgvx.DataSource = BinSrc

        ParametrizarGrid(Gv)
    End Sub

    Private Sub ConfigurarGrid()

        Gv.Columns("Poblacion").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

        If dgvx.tbEstablecerPerfilPredeterminado() Then
            Exit Sub
        End If

        Gv.OptionsView.ShowGroupPanel = False
        Gv.OptionsView.ShowAutoFilterRow = True

        Gv.Columns("Contador").OptionsColumn.AllowShowHide = False
        Gv.Columns("Contador").Visible = False

        Gv.Columns("Provincia").OptionsColumn.AllowShowHide = False
        Gv.Columns("Provincia").Visible = False

        Gv.Columns("Poblacion").Caption = "Población"
        Gv.Columns("Prov").Caption = "Provincia"

        Gv.BestFitColumns()

        'Sumatorios en agrupaciones
        Gv.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        Dim ItemArticulo As GridGroupSummaryItem = New GridGroupSummaryItem()
        ItemArticulo.FieldName = "Contador"
        ItemArticulo.DisplayFormat = "{0:n0}"
        ItemArticulo.SummaryType = DevExpress.Data.SummaryItemType.Count
        Gv.GroupSummary.Add(ItemArticulo)

        Gv.OptionsView.ShowFooter = True
        Gv.Columns("Poblacion").SummaryItem.FieldName = "Contador"
        Gv.Columns("Poblacion").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        Gv.Columns("Poblacion").SummaryItem.DisplayFormat = "Total: {0:n0}"

    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
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

        If e.KeyCode = Keys.F1 Then
            Aceptar()
            e.Handled = True
            e.SuppressKeyPress = True
            Exit Sub
        End If

        If e.KeyCode = Keys.Escape Then
            Salir()
            e.Handled = True
            e.SuppressKeyPress = True
            Exit Sub
        End If

    End Sub

#End Region

    Private Sub aceptar()
        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Return
        End If
        BD_CERO.Execute("UPDATE Poblacion SET Contador" & Portal & " = " & BinSrc.Current("Contador") & " WHERE Poblacion ='" & Funciones.pf_ReplaceComillas(poblacion) & "'")
        Salir()
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        aceptar()
    End Sub
End Class




