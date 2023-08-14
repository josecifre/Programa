

Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid
Imports System
Imports DevExpress.XtraEditors
Imports System.Data
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraBars
Imports DevExpress.LookAndFeel.Design
Imports System.Drawing
Imports DevExpress.Skins
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports System.Data.SqlClient
Imports DevExpress.XtraBars.Docking


Partial Public Class ucTipo

    Inherits DevExpress.XtraEditors.XtraUserControl


    Dim Eliminando As Boolean = False
    Dim menu As DXPopupMenu
    Public PopupMenu As DXPopupMenu
    Dim EstoyEnAlta As Boolean

    Dim bd As BaseDatos
    Private WithEvents BinSrc As BindingSource

    Dim Cargando As Boolean
    Dim PrimeraVez As Boolean
    Dim SentenciaSQL As String

    Dim ValorComercialAntes As Boolean
    Dim UsuarioAntes As String
    Dim PassAntes As String
    Dim TipoAntes As String
    Dim BajaAntes As String


    Dim PanelComercialesClientes As DockPanel
    Dim AP As ActualizaPerfil

    Dim AnadirCheckColunm As Boolean = False



    Dim CampoInicialBusqueda As String = "Tipo"
    Dim TablaMantenimiento As String = "Tipo"
    Dim ClavePrincipal As String = "Contador"
    Dim ClavePrincipalEsIdentity As Boolean = True
    Dim ValorAntesModificar As String
    Public Sub New()
        InitializeComponent()

    End Sub


    Private Sub ucASunto_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        AparienciaGeneral()
        MostrarImagenDeFondo()
        Cargando = True
        PrimeraVez = True

        'SentenciaSQL = "SELECT * FROM " & TablaMantenimiento   ' & " WHERE ContadorOrganismo =1"

        SentenciaSQL = "SELECT * FROM " & TablaMantenimiento & " WHERE CodigoEmpresa = " & DatosEmpresa.Codigo & " ORDER BY Tipo"

        bd = New BaseDatos
        bd.LlenarDataSet(SentenciaSQL, TablaMantenimiento, , False, True)


        If PrimeraVez Then
            BinSrc = New BindingSource
        End If

        dgvx.BindingContext = New BindingContext()
        BinSrc.DataSource = bd.ds
        BinSrc.DataMember = TablaMantenimiento

        If PrimeraVez Then
            AP = New ActualizaPerfil(Gv)
        End If

        'Bindings


        txtTipo.DataBindings.Add(New Binding("EditValue", BinSrc, "Tipo", True))
        TxtPrioridad.DataBindings.Add(New Binding("EditValue", BinSrc, "Prioridad", True))
        TxtTipoPrioridad.DataBindings.Add(New Binding("EditValue", BinSrc, "TipoPrioridad", True))
        txtTipoEnDescripcion.DataBindings.Add(New Binding("EditValue", BinSrc, "TipoEnDescripcion", True))
        FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbTipoPrincipal, "TipoPrincipalWeb", "TipoPrincipal", "TipoPrincipal", , , , "SELECT DISTINCT TipoPrincipal FROM TipoPrincipalWeb ORDER by TipoPrincipal")
        CargarComboTipoSecundario()


        dgvx.DataSource = BinSrc

        ParametrizarGrid(Gv)
        'Esto es para cambiar el color roweven particular para este grid
        '  Gv.Appearance.EvenRow.BackColor = Color.Yellow

        dgvx.tbCarpetaPerfiles = GL_CARPETA_PERFILES & "\" & Me.Name & "\" & dgvx.Name
        dgvx.ContextMenuStrip = New tbContextMenuStripComponent(dgvx.tbCarpetaPerfiles)
        'dgvx.ContextMenuStrip.Items.Add("Copiar Perfiles", Nothing, AddressOf CopiarPerfilesDgvX)

        ConfigurarGrid()

        Cargando = False

        'Try
        '    If Not PrimeraVez Then
        '        HacerCambioFila()
        '    End If

        'Catch ex As Exception

        'End Try

        If AnadirCheckColunm Then
            Try
                dgvx.tb_AnadirColumnaCheck = True

            Catch ex As Exception
            End Try
        End If

        HabilitarBotones()
        HabilitarDesHabilitarCajas(False)

        PonerFocoRowFilterEnGridView(Gv, CampoInicialBusqueda)
        Try
            Gv.Focus()
            Gv.FocusedRowHandle = 0
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ConfigurarGrid()

        If Not PrimeraVez Then
            Exit Sub
        End If

        PrimeraVez = False



        If dgvx.tbEstablecerPerfilPredeterminado() Then
            Exit Sub
        End If


        Gv.ClearSorting()
        Gv.BeginDataUpdate()
        Try
            Gv.ClearSorting()
            Gv.Columns("TipoPrioridad").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            Gv.Columns("Prioridad").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
        Finally
            Gv.EndDataUpdate()
        End Try



        Gv.OptionsView.ShowGroupPanel = False

        Gv.OptionsView.ShowAutoFilterRow = True

        Gv.Columns("Contador").OptionsColumn.AllowShowHide = False
        Gv.Columns("Contador").Visible = False

        '    Gv.Columns("Contador").OptionsColumn.AllowShowHide = False
        Gv.Columns("Id_WP").Visible = False

        For Each p In GL_Portales
            Gv.Columns("Contador" & p).OptionsColumn.AllowShowHide = False
            Gv.Columns("Contador" & p).Visible = False
        Next
        'Gv.Columns("ContadorHogaria").OptionsColumn.AllowShowHide = False
        'Gv.Columns("ContadorHogaria").Visible = False

        'Gv.Columns("ContadorIdealista").OptionsColumn.AllowShowHide = False
        'Gv.Columns("ContadorIdealista").Visible = False

        'Gv.Columns("ContadorYaEncontre").OptionsColumn.AllowShowHide = False
        'Gv.Columns("ContadorYaEncontre").Visible = False

        'Gv.Columns("ContadorFotoCasa").OptionsColumn.AllowShowHide = False
        'Gv.Columns("ContadorFotoCasa").Visible = False

        Gv.Columns("CodigoEmpresa").OptionsColumn.AllowShowHide = False
        Gv.Columns("CodigoEmpresa").Visible = False


        Gv.Columns("TipoPrioridad").Caption = "Tipo Prioridad"


        Gv.Columns("Prioridad").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

        Gv.Columns("TipoPrioridad").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

        Gv.BestFitColumns()

        Gv.Columns("TipoPrioridad").Width = 150


        'Sumatorios en agrupaciones
        Gv.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        Dim ItemArticulo As GridGroupSummaryItem = New GridGroupSummaryItem()
        ItemArticulo.FieldName = "Contador"
        ItemArticulo.DisplayFormat = "{0:n0}"
        ItemArticulo.SummaryType = DevExpress.Data.SummaryItemType.Count
        Gv.GroupSummary.Add(ItemArticulo)


        Gv.OptionsView.ShowFooter = True
        Gv.Columns("Tipo").SummaryItem.FieldName = "Contador"
        Gv.Columns("Tipo").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        Gv.Columns("Tipo").SummaryItem.DisplayFormat = "Total: {0:n0}"

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
        Aceptar()
    End Sub
    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub

    Private Sub Anadir()

        If Not Funciones.TienePermisosAME() Then
            Return
        End If

        EstoyEnAlta = True
        BinSrc.AddNew()
        PrepararAlta()

    End Sub

    Private Sub Modificar(Optional PonermeEnLaPrimeraColumna As Boolean = True)

        If Not Funciones.TienePermisosAME() Then
            Return
        End If


        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            MensajeError("Debe seleccionar un registro")
            Return
        End If

        If XtraMessageBox.Show("¿Confirma que quiere modificar el registro seleccionado?" & vbCrLf & "Este cambio afectará a todos los registros que estén utilizando este valor", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
            Exit Sub
        End If


        EstoyEnAlta = False
        ValorAntesModificar = txtTipo.EditValue
        PrepararModificacion()

    End Sub

    Private Sub Eliminar()

        If Not Funciones.TienePermisosAME() Then
            Return
        End If

        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            MensajeError("Debe seleccionar un registro")
            Return
        End If

        If Not PuedeEliminar("TIPO", txtTipo.EditValue) Then
            MensajeError("No puede eliminar este registro porque se está utilizando en otras tablas")
            Exit Sub
        End If

        If XtraMessageBox.Show("¿Confirma que quiere eliminar el registro seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
            Exit Sub
        End If

        Eliminando = True

        Try
            'ConsultasBaseDatos.EliminarUsuario(BinSrc.Current("Contador"), 1)
        Catch ex As Exception
            MensajeError(ex.Message)
            Return
        End Try

        Dim FilaSeleccionada As Integer = Gv.FocusedRowHandle
        'BinSrc.RemoveCurrent()

        'If DatosEmpresa.WordPress AndAlso BinSrc.Current("Id_WP") <> 0 Then

        '    Dim Res2 As New Tablas.clWPCreado
        '    Dim Res As Tablas.clResultado

        '    GL_TokenWP = FuncionesGenerales.FuncionesBD.ObtenerTokenWP()
        '    Res = WordPressPost("property-types/" & BinSrc.Current("Id_WP") & "?force=true", "", True)

        '    If Res.Codigo = 0 Then
        '        Res2 = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Tablas.clWPCreado)(Res.Mensaje)
        '    Else
        '        Dim Res3 As New Tablas.clErrorWP
        '        Res3 = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Tablas.clErrorWP)(Res.Mensaje)
        '        MensajeInformacion("Error al comunicar con la web. " & vbCrLf & "Inténtelo más tarde" & vbCrLf & Res3.message)
        '        Return
        '    End If

        'End If

        Gv.DeleteRow(Gv.FocusedRowHandle)

        BinSrc.EndEdit()

        If Not ActualizarBaseDatos() Then
            Return
        End If

        HabilitarBotones()
        HabilitarDesHabilitarCajas(False)

        If FilaSeleccionada > 1 Then
            Gv.FocusedRowHandle = FilaSeleccionada - 1
        Else
            Try
                Gv.FocusedRowHandle = FilaSeleccionada + 1
            Catch ex As Exception

            End Try
        End If

        FuncionesBD.Accion("REHACER", TablaMantenimiento)
        Eliminando = False
    End Sub
    Private Sub Aceptar()
        Actualizar()

    End Sub
    Private Sub Cancelar()
        BinSrc.CancelEdit()
        HabilitarBotones()
        HabilitarDesHabilitarCajas(False)
    End Sub
    Private Sub PrepararModificacion()

        For Each c As Control In PanelCajas.Controls
            c.Enabled = True
        Next

        'txtObservaciones.Enabled = True
        ' txtObservaciones.Properties.ReadOnly = True
        '  txtCodigo.Enabled = False
        DesHabilitarBotones()

        txtTipo.Focus()
    End Sub

    Private Sub PrepararAlta()

        HabilitarDesHabilitarCajas(True)


 

        DesHabilitarBotones()

        txtTipo.Focus()

    End Sub
    Private Sub HabilitarDesHabilitarCajas(ByVal Habilitar As Boolean)

        For Each c As Control In PanelCajas.Controls
            If Not TypeOf (c) Is DevExpress.XtraEditors.LabelControl AndAlso Not TypeOf (c) Is DevExpress.XtraEditors.PanelControl AndAlso Not TypeOf (c) Is DevExpress.XtraEditors.GroupControl Then
                c.Enabled = Habilitar
            End If
        Next
    End Sub

    Private Function Actualizar() As Boolean

        Try
            Dim Sel As String = ""

            Dim ValorDespuesDeModificar As String = ""
            Me.Validate()

            If Not Eliminando AndAlso Not ComprobarDatos() Then
                Return False
            End If

            'If DatosEmpresa.WordPress AndAlso Not EstoyEnAlta AndAlso Not IsDBNull(BinSrc.Current("Id_WP")) AndAlso BinSrc.Current("Id_WP") <> 0 Then
            '    If WP_Alta_Modificar_General("Tipo", BinSrc.Current("Tipo"), BinSrc.Current("Id_WP")) < 0 Then
            '        Return False
            '    End If
            'End If

            If EstoyEnAlta Then

                'BinSrc.Current("Id_WP") = 0
                BinSrc.Current("CodigoEmpresa") = DatosEmpresa.Codigo
            End If


            If BinSrc.Current("TipoSecundario") <> "" Then
                Sel = "SELECT Id_WP FROM TipoSecundarioWeb WHERE TipoSecundario ='" & Funciones.pf_ReplaceComillas(BinSrc.Current("TipoSecundario")) & "'"
                BinSrc.Current("Id_WP") = BD_CERO.Execute(Sel, False, 0)
            Else
                Sel = "SELECT Id_WP FROM TipoPrincipalWeb WHERE TipoPrincipal ='" & Funciones.pf_ReplaceComillas(BinSrc.Current("TipoPrincipal")) & "'"
                BinSrc.Current("Id_WP") = BD_CERO.Execute(Sel, False, 0)
            End If

            If BinSrc.Current("TipoEnDescripcion").ToString.Trim = "" Then
                BinSrc.Current("TipoEnDescripcion") = BinSrc.Current("Tipo")
            End If

            Cargando = True
            BinSrc.EndEdit()
            ValorDespuesDeModificar = txtTipo.EditValue
            Cargando = False

            Dim ValorClaveAntes As Object = BinSrc.Current(ClavePrincipal)

            If Not ActualizarBaseDatos() Then
                Return False
            End If

            If Not Eliminando AndAlso ValorClaveAntes IsNot Nothing Then
                SituarseEnGrid(Gv, ValorClaveAntes.ToString, ClavePrincipal)
            End If

            If Not EstoyEnAlta AndAlso (ValorDespuesDeModificar <> ValorAntesModificar) Then

                Sel = "UPDATE ClientesTipo SET Tipo = '" & Funciones.pf_ReplaceComillas(ValorDespuesDeModificar) & "' WHERE Tipo = '" & Funciones.pf_ReplaceComillas(ValorAntesModificar) & "'"
                If DatosEmpresa.WordPress Then
                Else
                    FuncionesBD.Accion("INSTRUCCION", TablaMantenimiento, Funciones.pf_ReplaceComillas(ValorAntesModificar) & "|" & Funciones.pf_ReplaceComillas(ValorDespuesDeModificar))
                End If

                BD_CERO.Execute(Sel)
                Sel = "UPDATE Inmuebles SET Tipo = '" & Funciones.pf_ReplaceComillas(ValorDespuesDeModificar) & "' WHERE Tipo = '" & Funciones.pf_ReplaceComillas(ValorAntesModificar) & "'"
                BD_CERO.Execute(Sel)

            End If
            FuncionesBD.Accion("REHACER", TablaMantenimiento)
            HabilitarBotones()
            HabilitarDesHabilitarCajas(False)
            Return True

        Catch ex As SqlClient.SqlException

            XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)


            Return False

        Catch ex2 As Exception

            XtraMessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False

        End Try


    End Function
    Private Function ActualizarBaseDatos(Optional RefrescarDatos As Boolean = False) As Boolean

        Try


            'Dim ContadorMinimo As Integer = 0

            'If EstoyEnAlta Then
            '    ContadorMinimo = clGenerales.Maximo(ClavePrincipal, TablaMantenimiento)
            'End If

            bd.ActualizarCambios(TablaMantenimiento, bd.ds, RefrescarDatos)

            If EstoyEnAlta And Not Eliminando Then

                Cargando = True


                'Se supone que el cliente ya está dado de alta en la bd.
                'Como el contador es autonumérico, no lo tenemos en el dataset.
                'Con lo siguiente, vamos a acutaliazar el dataset con el contador que le han asignado al cliente
                If ClavePrincipalEsIdentity Then
                    Dim NuevoContador As Integer
                    NuevoContador = ConsultasBaseDatos.ObtenerContadorTablasAuxEnAlta(TablaMantenimiento, ClavePrincipal)

                    Dim dt As DataTable
                    Dim dr As DataRow
                    dt = bd.ds.Tables(TablaMantenimiento)
                    dr = dt.Rows(bd.ds.Tables(TablaMantenimiento).Rows.Count - 1)

                    ' If BinSrc.Current("Nombre") = dr("Nombre") And dr("Contador") Is DBNull.Value Then
                    If dr(ClavePrincipal) Is DBNull.Value OrElse dr(ClavePrincipal) = 0 Then
                        dr.BeginEdit()
                        dr(ClavePrincipal) = NuevoContador
                        dr.EndEdit()
                        bd.ds.AcceptChanges()
                    End If
                End If




                Cargando = False
            End If

            Return True
        Catch ex As SqlClient.SqlException
            If ex.Number = 2627 Then
                MensajeError(GL_ValorDuplicado)
            Else
                MensajeError(ex.Message)
            End If

            '  bd.ds.RejectChanges()
            Return False
        End Try
    End Function


    Private Function ComprobarDatos() As Boolean

        If txtTipo.Text.ToString.Trim = "" Then
            MensajeError("El campo tipo no puede estar vacío")
            txtTipo.Focus()
            Return False
        End If


        If TxtPrioridad.Text.ToString.Trim = "" Then
            MensajeError("El campo prioridad no puede estar vacío")
            TxtPrioridad.Focus()
            Return False
        End If

        If DatosEmpresa.WordPress Then
            If cmbTipoPrincipal.EditValue = "" Then
                MensajeInformacion("Debe indicar el campo Tipo Principal")
                Return False
            End If
        End If

        'If TxtTipoPrioridad.Text.ToString.Trim = "" Then
        '    MensajeError("El campo tipo prioridad no puede estar vacío")
        '    TxtTipoPrioridad.Focus()
        '    Return False
        'End If


        Return True

    End Function





    Private Sub HabilitarBotones()


        btnAnadir.Enabled = True
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        If bd.ds.Tables(TablaMantenimiento).Rows.Count > 0 Then
            btnModificar.Enabled = True
            btnEliminar.Enabled = True

        End If

        btnAceptar.Enabled = False
        btnCancelar.Enabled = False
        btnSalir.Enabled = True


        dgvx.Enabled = True





    End Sub

    Private Sub DesHabilitarBotones()

        btnAnadir.Enabled = False
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        btnSalir.Enabled = False
        btnAceptar.Enabled = True
        btnCancelar.Enabled = True

        dgvx.Enabled = False



        Dim PaginaSeleccionadaAntes As Integer
        If EstoyEnAlta Then
            PaginaSeleccionadaAntes = 0
        End If

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
    Private Sub cmbTipoPrincipal_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cmbTipoPrincipal.EditValueChanged
        If Cargando Then
            Exit Sub
        End If

        CargarComboTipoSecundario()

    End Sub
    Private Sub CargarComboTipoSecundario()
        FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbTipoSecundario, "TipoSecundarioWeb", "TipoSecundario", "TipoSecundario", , , , "SELECT DISTINCT TipoSecundario FROM TipoSecundarioWeb WHERE TipoPrincipal  = '" & Funciones.pf_ReplaceComillas(cmbTipoPrincipal.EditValue) & "' ORDER by TipoSecundario")
    End Sub
    'Private Sub MyGridView1_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles Gv.FocusedRowChanged

    '    Try
    '        HacerCambioFila()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub HacerCambioFila()
    '    If Cargando Then
    '        Exit Sub
    '    End If
    '    If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
    '        Exit Sub
    '    End If


    'End Sub

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

        If e.KeyCode = Keys.Escape And btnAceptar.Enabled = True Then

            Try
                Cancelar()
                e.Handled = True
                e.SuppressKeyPress = True
            Catch ex As Exception

            End Try

        End If

        If e.KeyCode = Keys.F1 And btnAceptar.Enabled = False Then
            Anadir()
            e.Handled = True
            e.SuppressKeyPress = True
            Exit Sub
        End If

        If e.KeyCode = Keys.F2 And btnAceptar.Enabled = False Then
            Eliminar()
            e.Handled = True
            e.SuppressKeyPress = True
            Exit Sub
        End If

        If e.KeyCode = Keys.F3 And btnAceptar.Enabled = False Then
            Modificar(False)
            e.Handled = True
            e.SuppressKeyPress = True
            Exit Sub
        End If

        If e.KeyCode = Keys.F12 Then
            Aceptar()
            e.Handled = True
            e.SuppressKeyPress = True
            Exit Sub
        End If


    End Sub

#End Region

End Class




