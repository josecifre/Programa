

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


Partial Public Class ucPoblacion

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



    Dim CampoInicialBusqueda As String = "Poblacion"
    Dim TablaMantenimiento As String = "Poblacion"
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

        LlenarGrid()

        If PrimeraVez Then
            AP = New ActualizaPerfil(Gv)
        End If

        'Bindings

        txtPoblacion.DataBindings.Add(New Binding("EditValue", BinSrc, "Poblacion", True))
        FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbProvincia, "Provincias", "Provincia", "Provincia", , , , "SELECT Provincia FROM Provincias ORDER BY Provincia ")

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
        ALTA(False)
        HabilitarBotones()
        HabilitarDesHabilitarCajas(False)

        PonerFocoRowFilterEnGridView(Gv, CampoInicialBusqueda)
        Try
            Gv.Focus()
            Gv.FocusedRowHandle = 0
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LlenarGrid()
        SentenciaSQL = "SELECT * FROM " & TablaMantenimiento & " WHERE Visible = " & GL_SQL_VALOR_1 & " ORDER BY Poblacion"
        'Provincia IN (SELECT Provincia FROM Provincias WHERE Visible = " & GL_SQL_VALOR_1 & ")

        bd = New BaseDatos
        bd.LlenarDataSet(SentenciaSQL, TablaMantenimiento, , False, True)


        If PrimeraVez Then
            BinSrc = New BindingSource
        End If

        dgvx.BindingContext = New BindingContext()
        BinSrc.DataSource = bd.ds
        BinSrc.DataMember = TablaMantenimiento
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

        Gv.ClearSorting()
        Gv.BeginDataUpdate()
        Try
            Gv.ClearSorting()
            Gv.Columns("Provincia").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            Gv.Columns("Poblacion").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
        Finally
            Gv.EndDataUpdate()
        End Try

        Gv.OptionsView.ShowGroupPanel = False

        Gv.OptionsView.ShowAutoFilterRow = True

        Gv.Columns("Contador").OptionsColumn.AllowShowHide = False
        Gv.Columns("Contador").Visible = False


        Gv.Columns("CodigoEmpresa").OptionsColumn.AllowShowHide = False
        Gv.Columns("CodigoEmpresa").Visible = False


        Gv.Columns("Delegacion").OptionsColumn.AllowShowHide = False
        Gv.Columns("Delegacion").Visible = False

        Gv.Columns("CodigoPostal").OptionsColumn.AllowShowHide = False
        Gv.Columns("CodigoPostal").Visible = False

        Gv.Columns("Visible").OptionsColumn.AllowShowHide = False
        Gv.Columns("Visible").Visible = False

        For Each p In GL_Portales
            Try
                Gv.Columns("Contador" & p).OptionsColumn.AllowShowHide = False
                Gv.Columns("Contador" & p).Visible = False
            Catch ex As Exception

            End Try
        Next
        'Gv.Columns("ContadorYaEncontre").OptionsColumn.AllowShowHide = False
        'Gv.Columns("ContadorYaEncontre").Visible = False
        'Gv.Columns("ContadorIdealista").OptionsColumn.AllowShowHide = False
        'Gv.Columns("ContadorIdealista").Visible = False
        'Gv.Columns("ContadorFotoCasa").OptionsColumn.AllowShowHide = False
        'Gv.Columns("ContadorFotoCasa").Visible = False
        'Gv.Columns("ContadorHogaria").OptionsColumn.AllowShowHide = False 'por si hace falta en el futuro, de momento utiliza las mismas que YaEncontre
        'Gv.Columns("ContadorHogaria").Visible = False


        Gv.Columns("Poblacion").Caption = "Población"
       
      


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




#Region "Mantenimiento Asunto"

    Private Sub btnAnadir_Click(sender As System.Object, e As System.EventArgs) Handles btnAnadir.Click
        Anadir()
    End Sub
    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPredeterminar.Click
        Predeterminar()
    End Sub
    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Modificar()
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Aceptar()
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub

    Private Sub Anadir()

        If Not Funciones.TienePermisosAME() Then
            Return
        End If

        EstoyEnAlta = True
        PrepararAlta()

    End Sub

    Private Sub Modificar(Optional ByVal PonermeEnLaPrimeraColumna As Boolean = True)

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
        ValorAntesModificar = txtPoblacion.EditValue
        PrepararModificacion()

    End Sub

    Private Sub Predeterminar()

        If Not Funciones.TienePermisosAME() Then
            Return
        End If

        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            MensajeError("Debe seleccionar un registro")
            Return
        End If

        If BD_CERO.Execute("SELECT " & Funciones.SQL_CASE_ISNULL("Predeterminada,0") & " FROM Poblacion WHERE Poblacion='" & Funciones.pf_ReplaceComillas(txtPoblacion.Text) & "'", False) = 0 Then
            If XtraMessageBox.Show("¿Confirma que quiere marcar como predeterminado el registro seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
                Exit Sub
            End If
            BD_CERO.Execute("UPDATE Poblacion SET Predeterminada=0")
            BD_CERO.Execute("UPDATE Poblacion SET Predeterminada=" & GL_SQL_VALOR_1 & " WHERE Poblacion ='" & Funciones.pf_ReplaceComillas(txtPoblacion.EditValue) & "'")
            GL_PoblacionPrederminada = txtPoblacion.EditValue
        Else
            MensajeError("Para quitar el Predeterminado Predetermine otro registro")
            Return
        End If

        Dim ValorClaveAntes As Integer = BinSrc.Current("Contador")

      
        LlenarGrid()

        SituarseEnGrid(Gv, ValorClaveAntes.ToString, "Contador")
        FuncionesBD.Accion("REHACER", TablaMantenimiento)

    End Sub
    Private Sub Aceptar()
        Actualizar()

    End Sub
    Private Sub Cancelar()
        If EstoyEnAlta Then
            ALTA(False)
        End If
        HabilitarBotones()
        HabilitarDesHabilitarCajas(False)
    End Sub
    Private Sub PrepararModificacion()

        For Each c As Control In PanelCajas.Controls
            c.Enabled = True
        Next

        DesHabilitarBotones()

        txtPoblacion.Focus()




    End Sub

    Private Sub PrepararAlta()

        HabilitarDesHabilitarCajas(True)

        ALTA(True)
       
        DesHabilitarBotones()

        PrepararLlenarCheckCombosClientes()
        cmbProvincia.Focus()
    End Sub
    Private Sub PrepararLlenarCheckCombosClientes()

        cmbPoblacion.tb_TablaCompleta = TablaMantenimiento
        cmbPoblacion.tb_TablaEnlazada = TablaMantenimiento
        cmbPoblacion.tb_Campo = TablaMantenimiento
        cmbPoblacion.tb_CampoFiltro = "Contador"
        cmbPoblacion.tb_LlenarCompleta("", "SELECT Poblacion FROM Poblacion WHERE Provincia ='" & cmbProvincia.EditValue & "'")
        cmbPoblacion.tb_ValorBusqueda = 0
        Dim CADENA As String = ""
        Dim PROVINCIA As String = ""
        If IsDBNull(cmbProvincia.EditValue) OrElse cmbProvincia.EditValue.ToString.Trim = "" Then
            PROVINCIA = ""
        Else
            PROVINCIA = cmbProvincia.EditValue
        End If

        For Each ITEM As DataRow In bd.ds.Tables(TablaMantenimiento).Rows
            If ITEM("Provincia") = PROVINCIA Then
                If CADENA = "" Then
                    CADENA = ITEM("Poblacion")
                Else
                    CADENA &= "; " & ITEM("Poblacion")
                End If

            End If
        Next
        cmbPoblacion.EditValue = CADENA



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

            If Not ComprobarDatos() Then
                Return False
            End If

            Dim ValorDespuesDeModificar As String = Funciones.pf_ReplaceComillas(txtPoblacion.EditValue)




            If EstoyEnAlta Then
                For Each ITEM As DataRow In bd.ds.Tables(TablaMantenimiento).Rows
                    If ITEM("Predeterminada") Then
                        If ITEM("Provincia") = cmbProvincia.EditValue AndAlso Not cmbPoblacion.EditValue.ToString.Contains(ITEM("Poblacion")) Then
                            cmbPoblacion.EditValue &= "; " & ITEM("Poblacion")
                            MensajeError("No se ha quitado la población " & ITEM("Poblacion") & " ya que es la predeterminada, cambie esto antes de quitarla.")
                        End If
                        Exit For
                    End If
                Next
                BD_CERO.Execute("UPDATE Poblacion SET Visible=" & GL_SQL_VALOR_1 & " WHERE Poblacion IN ('" & Replace(Funciones.pf_ReplaceComillas(cmbPoblacion.EditValue), "; ", "','") & "')")
                BD_CERO.Execute("UPDATE Poblacion SET Visible=0 WHERE Poblacion NOT IN ('" & Replace(Funciones.pf_ReplaceComillas(cmbPoblacion.EditValue), "; ", "','") & "') AND Provincia='" & cmbProvincia.EditValue & "'")
                BD_CERO.Execute("UPDATE Provincias SET Visible=" & GL_SQL_VALOR_1 & " WHERE Provincia ='" & cmbProvincia.EditValue & "'")
                BD_CERO.Execute("UPDATE Provincias SET Visible=0 WHERE Provincia NOT IN (SELECT DISTINCT Provincia FROM Poblacion WHERE Visible=" & GL_SQL_VALOR_1 & ")")
            Else
                If Not EstoyEnAlta AndAlso (ValorDespuesDeModificar <> ValorAntesModificar) Then

                    If DatosEmpresa.WordPress AndAlso Not EstoyEnAlta AndAlso Not IsDBNull(BinSrc.Current("Id_WP")) AndAlso BinSrc.Current("Id_WP") <> 0 Then
                        If WP_Alta_Modificar_General("Poblacion", BinSrc.Current("Poblacion").ToString, BinSrc.Current("Id_WP")) < 0 Then
                            Return False
                        End If
                    End If



                    BD_CERO.Execute("UPDATE Poblacion SET Poblacion ='" & ValorDespuesDeModificar & "' WHERE Contador =" & BinSrc.Current("Contador"))
                    Dim Sel As String
                    Sel = "UPDATE Inmuebles SET Poblacion = '" & Funciones.pf_ReplaceComillas(ValorDespuesDeModificar) & "' WHERE Poblacion = '" & Funciones.pf_ReplaceComillas(ValorAntesModificar) & "'"
                    BD_CERO.Execute(Sel)
                    Sel = "UPDATE ClientesPoblacion SET Poblacion = '" & Funciones.pf_ReplaceComillas(ValorDespuesDeModificar) & "' WHERE Poblacion = '" & Funciones.pf_ReplaceComillas(ValorAntesModificar) & "'"
                    BD_CERO.Execute(Sel)
                    Sel = "UPDATE Zona SET Poblacion = '" & Funciones.pf_ReplaceComillas(ValorDespuesDeModificar) & "' WHERE Poblacion = '" & Funciones.pf_ReplaceComillas(ValorAntesModificar) & "'"
                    BD_CERO.Execute(Sel)
                End If

            End If
            Cargando = True

            '    Dim ValorClaveAntes As Integer = BinSrc.Current("Contador")
            bd.RefrescarDatos()
            Cargando = False

            '       SituarseEnGrid(Gv, ValorClaveAntes.ToString, ClavePrincipal)
           

            FuncionesBD.Accion("REHACER", TablaMantenimiento)
            If EstoyEnAlta Then
                ALTA(False)
            End If
            HabilitarBotones()
            HabilitarDesHabilitarCajas(False)
            LlenarGrid()
            Return True

        Catch ex As SqlClient.SqlException

            XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)


            Return False

        Catch ex2 As Exception

            XtraMessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False

        End Try


    End Function
   
    Private Function ComprobarDatos() As Boolean
        If EstoyEnAlta Then
            If cmbProvincia.EditValue.ToString.Trim = "" Then
                MensajeError("El campo Provincia no puede estar vacío")
                cmbProvincia.Focus()
                Return False
            End If
            'If cmbPoblacion.EditValue.ToString.Trim = "" Then
            '    MensajeError("El campo población no puede estar vacío")
            '    cmbProvincia.Focus()
            '    Return False
            'End If
        Else
            If txtPoblacion.Text.ToString.Trim = "" Then
                MensajeError("El campo población no puede estar vacío")
                txtPoblacion.Focus()
                Return False
            End If
        End If
       
        Return True

    End Function





    Private Sub HabilitarBotones()


        btnAnadir.Enabled = True
        btnModificar.Enabled = False
        btnPredeterminar.Enabled = False
        If bd.ds.Tables(TablaMantenimiento).Rows.Count > 0 Then
            btnModificar.Enabled = True
            btnPredeterminar.Enabled = True

        End If

        btnAceptar.Enabled = False
        btnCancelar.Enabled = False
        btnSalir.Enabled = True


        dgvx.Enabled = True





    End Sub
    Private Sub ALTA(ByVal SI As Boolean)
        lblPoblacion.Visible = SI
        lblProvincia.Visible = SI
        lblPoblacion1.Visible = Not SI
        cmbPoblacion.Visible = SI
        cmbProvincia.Visible = SI
        txtPoblacion.Visible = Not SI
    End Sub
    Private Sub DesHabilitarBotones()

        btnAnadir.Enabled = False
        btnModificar.Enabled = False
        btnPredeterminar.Enabled = False
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



    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
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
    Private Shared Function PeekMessage(<Runtime.InteropServices.In(), Runtime.InteropServices.Out()> ByRef msg As MSG, ByVal hwnd As Runtime.InteropServices.HandleRef, ByVal msgMin As Integer, ByVal msgMax As Integer, ByVal remove As Integer) As Boolean
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

    Private Sub RemovePendingMessages(ByVal msgMin As Integer, ByVal msgMax As Integer)
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
    Private Sub TrappedKeyDown(ByVal e As KeyEventArgs)

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
            Predeterminar()
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

    Private Sub cmbProvincia_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProvincia.EditValueChanged
        If Cargando Then
            Exit Sub
        End If
        PrepararLlenarCheckCombosClientes()
    End Sub
End Class




