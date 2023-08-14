Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraGrid
Imports DevExpress.XtraBars.Docking

Partial Public Class ucPublicacion

    Inherits DevExpress.XtraEditors.XtraUserControl

    Dim Eliminando As Boolean = False

    Dim bd As BaseDatos
    Private WithEvents BinSrc As BindingSource

    Dim Cargando As Boolean
    Dim PrimeraVez As Boolean
    Dim SentenciaSQL As String

    Dim CampoInicialBusqueda As String = "Portal"
    Dim TablaMantenimiento As String = "ClientePortales"
    Dim ClavePrincipal As String = "Contador"

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub ucASunto_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Me.ParentForm.Text = "Mantenimiento de portales"

        AparienciaGeneral()
        MostrarImagenDeFondo()
        Cargando = True
        PrimeraVez = True

        SentenciaSQL = "SELECT * FROM " & TablaMantenimiento & " WHERE CodigoEmpresa=" & DatosEmpresa.Codigo & " ORDER BY Activo,Portal"

        bd = New BaseDatos
        bd.LlenarDataSet(SentenciaSQL, TablaMantenimiento, , False, True)


        If PrimeraVez Then
            BinSrc = New BindingSource
        End If

        dgvx.BindingContext = New BindingContext()
        BinSrc.DataSource = bd.ds
        BinSrc.DataMember = TablaMantenimiento

        dgvx.DataSource = BinSrc

        ParametrizarGrid(Gv)

        ConfigurarGrid()

        Cargando = False

        PonerFocoRowFilterEnGridView(Gv, CampoInicialBusqueda)
        Try
            Gv.Focus()
            Gv.FocusedRowHandle = 0
        Catch ex As Exception
        End Try

        txtCodigo.DataBindings.Add(New Binding("EditValue", BinSrc, "Codigo", True))
        chkActivo.DataBindings.Add(New Binding("CheckState", BinSrc, "Activo", True))
        FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbPortal, "Portales", "Portal", "Portal", , , , "SELECT Portal FROM PortalesCreados ORDER BY Portal")

        HacerCambioFila()

    End Sub

    Private Sub ConfigurarGrid()

        If Not PrimeraVez Then
            Exit Sub
        End If

        PrimeraVez = False

        Gv.Columns(CampoInicialBusqueda).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

        If dgvx.tbEstablecerPerfilPredeterminado() Then
            Exit Sub
        End If

        Gv.OptionsView.ShowGroupPanel = False

        Gv.OptionsView.ShowAutoFilterRow = True

        Gv.Columns("Contador").OptionsColumn.AllowShowHide = False
        Gv.Columns("Contador").Visible = False
        Gv.Columns("CodigoEmpresa").OptionsColumn.AllowShowHide = False
        Gv.Columns("CodigoEmpresa").Visible = False
        Gv.Columns("PendientePublicar").OptionsColumn.AllowShowHide = False
        Gv.Columns("PendientePublicar").Visible = False

        Gv.Columns("Codigo").Caption = "Código"

        Gv.BestFitColumns()

        'Sumatorios en agrupaciones
        Gv.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        Dim ItemArticulo As GridGroupSummaryItem = New GridGroupSummaryItem()
        ItemArticulo.FieldName = "Contador"
        ItemArticulo.DisplayFormat = "{0:n0}"
        ItemArticulo.SummaryType = DevExpress.Data.SummaryItemType.Count
        Gv.GroupSummary.Add(ItemArticulo)

        Gv.OptionsView.ShowFooter = True
        Gv.Columns("Portal").SummaryItem.FieldName = "Contador"
        Gv.Columns("Portal").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        Gv.Columns("Portal").SummaryItem.DisplayFormat = "Total: {0:n0}"

    End Sub

#Region "Mantenimiento Asunto"

    Private Sub btnAnadir_Click(sender As System.Object, e As System.EventArgs) Handles btnAnadir.Click
        Anadir()
    End Sub
    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        Eliminar()
    End Sub
    Private Sub btnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        Modificar()
    End Sub
    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        actualizar()
        Dim pregunta As Boolean = Not cmbPortal.Properties.ReadOnly
        botones(True)
        If pregunta AndAlso XtraMessageBox.Show("Los tipos y ofertas para este portal pueden estar sin asignar" & vbCrLf & "¿Desea abrir las pantallas de asignación?", "Asignación de tipos y ofertas", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            CargarFormulario("Asignar Tipos", , , , BinSrc.Current("Portal"))
            CargarFormulario("Asignar Ofertas", , , , BinSrc.Current("Portal"))
        End If
    End Sub
    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        botones(True)
        BinSrc.CancelEdit()
    End Sub

    Private Sub Anadir()

        If Not Funciones.TienePermisosAME() Then
            Return
        End If

        botones()

        BinSrc.AddNew()

        cmbPortal.EditValue = ""
        txtCodigo.EditValue = ""
        chkActivo.Checked = False
        BinSrc.Current("CodigoEmpresa") = DatosEmpresa.Codigo
        BinSrc.Current("PendientePublicar") = 0

        cmbPortal.Focus()

    End Sub

    Private Sub Modificar()
        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then Return
        If Not Funciones.TienePermisosAME() Then
            Return
        End If

        botones()

        cmbPortal.Properties.ReadOnly = True

        txtCodigo.Focus()

    End Sub

    Private Sub Eliminar()

        If Not Funciones.TienePermisosAME() Then
            Return
        End If

        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            MensajeError("Debe seleccionar un registro")
            Return
        End If

     
        If XtraMessageBox.Show("¿Confirma que quiere eliminar el registro seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
            Exit Sub
        End If

        Eliminando = True

        Dim FilaSeleccionada As Integer = Gv.FocusedRowHandle

        Gv.DeleteRow(Gv.FocusedRowHandle)

        BinSrc.EndEdit()

        bd.ActualizarCambios(TablaMantenimiento, bd.ds, False)

        If FilaSeleccionada > 1 Then
            Gv.FocusedRowHandle = FilaSeleccionada - 1
        Else
            Try
                Gv.FocusedRowHandle = FilaSeleccionada + 1
            Catch ex As Exception

            End Try
        End If

        Eliminando = False
    End Sub

    Private Sub botones(Optional activa As Boolean = False)
        btnAnadir.Enabled = activa
        btnEliminar.Enabled = activa
        btnModificar.Enabled = activa
        btnAceptar.Enabled = Not activa
        btnCancelar.Enabled = Not activa

        dgvx.Enabled = activa

        cmbPortal.Properties.ReadOnly = activa
        txtCodigo.Properties.ReadOnly = activa
        chkActivo.Enabled = Not activa
    End Sub

    Private Sub actualizar()
        Try
            Me.Validate()

            'If chkActivo.Checked = False Then
            '    BinSrc.Current("PendientePublicar") = 0
            'End If
            Cargando = True
            BinSrc.EndEdit()
            Cargando = False

            bd.ActualizarCambios(TablaMantenimiento, bd.ds, True)

        Catch ex As SqlClient.SqlException
            XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex2 As Exception
            XtraMessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

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


        If e.KeyCode = Keys.F1 Then
            Anadir()
            e.Handled = True
            e.SuppressKeyPress = True
            Exit Sub
        End If

        If e.KeyCode = Keys.F2 Then
            Eliminar()
            e.Handled = True
            e.SuppressKeyPress = True
            Exit Sub
        End If

        If e.KeyCode = Keys.F3 Then
            Modificar()
            e.Handled = True
            e.SuppressKeyPress = True
            Exit Sub
        End If

    End Sub

#End Region

    Private Sub Gv_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles Gv.FocusedRowChanged
        Try
            HacerCambioFila()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub HacerCambioFila()

        If Cargando Then
            Exit Sub
        End If
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Exit Sub
        End If
        btnModificar.Enabled = dgvx.Enabled
        btnEliminar.Enabled = dgvx.Enabled

    End Sub

End Class




