



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
 
Partial Public Class ucTextosEnvios

    Inherits DevExpress.XtraEditors.XtraUserControl

   

    Dim Eliminando As Boolean = False
    Dim menu As DXPopupMenu
    Public PopupMenu As DXPopupMenu
    Dim EstoyEnAlta As Boolean

    Dim bd As BaseDatos
    Private WithEvents BinSrc As BindingSource
    Dim TablaMantenimiento As String = "TextosEnvios"
    Dim Cargando As Boolean
    Dim PrimeraVez As Boolean
    Dim SentenciaSQL As String
 
    Dim CampoInicialBusqueda As String = "Documento"




    '*********COSAS A CAMBIAR EN NUEVOS MANTENIMIENTOS
    '*************************************************
    '1. TablaMantenimiento
    '2. EN NEW
    '   A. Bindings
    '   B. ConfigurarGrid
    '3. Private Sub PrepararAlta()
    '4. Private Function Actualizar() As Boolean
    '5. Private Function ComprobarDatos() As Boolean
    '****FIN*****COSAS A CAMBIAR EN NUEVOS MANTENIMIENTOS
    '****************************************************

    Public Sub New()
        InitializeComponent()

    End Sub

    Private Sub ucEmpleados_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        AparienciaGeneral()
        MostrarImagenDeFondo()
        Cargando = True
        PrimeraVez = True


        Dim Tab As New Tablas.clTablaGeneral(TablaMantenimiento, , , "Documento")
        bd = New BaseDatos
        Tab.Datos(bd, Tab.ConsultaAEjecutar, , True, , True, True)

        BinSrc = New BindingSource
        BinSrc.DataSource = bd.ds
        BinSrc.DataMember = TablaMantenimiento



        'Bindings
 
        txtAsunto.DataBindings.Add(New Binding("EditValue", BinSrc, "Asunto", True))
        txtTexto.DataBindings.Add(New Binding("EditValue", BinSrc, "Texto", True))
        txtCodigoEmpresa.DataBindings.Add(New Binding("EditValue", BinSrc, "CodigoEmpresa", True))
        chkIncluirAvisoLegal.DataBindings.Add(New Binding("Checked", BinSrc, "IncluirAvisoLegal", True))
        chkIncluirDatosEmpresa.DataBindings.Add(New Binding("Checked", BinSrc, "IncluirDatosEmpresa", True))
        txtTituloInforme.DataBindings.Add(New Binding("EditValue", BinSrc, "TituloInforme", True))
        chkLlevaTitulo.DataBindings.Add(New Binding("Checked", BinSrc, "LlevaTitulo", True))
        chkIncluirFichaInmueble.DataBindings.Add(New Binding("Checked", BinSrc, "IncluirFichaInmueble", True))

        'Combos
        FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbDocumento, "InternaDocumentos", "Documento", "Documento")


        dgvx.DataSource = BinSrc

        ParametrizarGrid(Gv)




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

        HabilitarBotones()
        HabilitarDesHabilitarCajas(False)

        PonerFocoRowFilterEnGridView(Gv, CampoInicialBusqueda)
        Try
            Gv.Focus()
            Gv.FocusedRowHandle = 0
        Catch ex As Exception

        End Try

    End Sub
    'Private Sub OnCalcRowHeight(sender As Object, e As RowHeightEventArgs) Handles Gv.CalcRowHeight
    '    Dim view As Views.Base.ColumnView = DirectC ast(sender, Views.Base.ColumnView)
    '    For Each col As GridColumn In view.VisibleColumns
    '        e.RowHeight = Math.Max(DevExpress.Utils.Text.TextUtils.GetStringHeight(view.GetViewInfo().GInfo.Graphics, view.GetRowCellDisplayText(e.RowHandle, col), col.AppearanceCell.Font, Integer.MaxValue), e.RowHeight)
    '    Next
    'End Sub
    Private Sub ConfigurarGrid()

        If Not PrimeraVez Then
            Exit Sub
        End If

        PrimeraVez = False
        If dgvx.tbEstablecerPerfilPredeterminado() Then
            Exit Sub
        End If

        'Dim repoMemo As New RepositoryItemMemoEdit()

        'dgvx.RepositoryItems.Add(repoMemo)

        'For Each column As GridColumn In Gv.Columns
        '    column.ColumnEdit = repoMemo
        'Next
        '       Gv.OptionsView.RowAutoHeight = True



        'GridPasado.OptionsNavigation.EnterMoveNextColumn = True
        'GridPasado.OptionsNavigation.UseTabKey = True
        'GridPasado.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        Gv.OptionsView.ShowGroupPanel = False
        'GridPasado.OptionsBehavior.Editable = False
        'GridPasado.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        'GridPasado.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
        'GridPasado.OptionsView.ColumnAutoWidth = True
        Gv.OptionsView.ShowAutoFilterRow = True

        Gv.Columns("Contador").OptionsColumn.AllowShowHide = False
        Gv.Columns("Contador").Visible = False

        Gv.Columns("CodigoEmpresa").OptionsColumn.AllowShowHide = False
        Gv.Columns("CodigoEmpresa").Visible = False

        Gv.Columns("LlevaTitulo").OptionsColumn.AllowShowHide = False
        Gv.Columns("LlevaTitulo").Visible = False

        Gv.Columns("IncluirOtros").OptionsColumn.AllowShowHide = False
        Gv.Columns("IncluirOtros").Visible = False

        Gv.Columns("Predeterminado").OptionsColumn.AllowShowHide = False
        Gv.Columns("Predeterminado").Visible = False

        Gv.Columns("IncluirDatosEmpresa").OptionsColumn.AllowShowHide = False
        Gv.Columns("IncluirDatosEmpresa").Visible = False

        Gv.Columns("TituloInforme").OptionsColumn.AllowShowHide = False
        Gv.Columns("TituloInforme").Visible = False

        Gv.Columns("LlevaTitulo").OptionsColumn.AllowShowHide = False
        Gv.Columns("LlevaTitulo").Visible = False

        Gv.Columns("IncluirFichaInmueble").OptionsColumn.AllowShowHide = False
        Gv.Columns("IncluirFichaInmueble").Visible = False

        Gv.Columns("IncluirAvisoLegal").OptionsColumn.AllowShowHide = False
        Gv.Columns("IncluirAvisoLegal").Visible = False



        'txtAsunto.DataBindings.Add(New Binding("EditValue", BinSrc, "Asunto", True))
        'txtTexto.DataBindings.Add(New Binding("EditValue", BinSrc, "Texto", True))
        'txtCodigoEmpresa.DataBindings.Add(New Binding("EditValue", BinSrc, "CodigoEmpresa", True))
        'chkIncluirAvisoLegal.DataBindings.Add(New Binding("Checked", BinSrc, "IncluirAvisoLegal", True))
        'chkIncluirDatosEmpresa.DataBindings.Add(New Binding("Checked", BinSrc, "IncluirDatosEmpresa", True))
        'txtTituloInforme.DataBindings.Add(New Binding("EditValue", BinSrc, "TituloInforme", True))
        'chkLlevaTitulo.DataBindings.Add(New Binding("Checked", BinSrc, "LlevaTitulo", True))
        'chkIncluirFichaInmueble.DataBindings.Add(New Binding("Checked", BinSrc, "IncluirFichaInmueble", True))



        Gv.OptionsView.ShowFooter = True

        Dim ItemArticulo As GridGroupSummaryItem = New GridGroupSummaryItem()
        ItemArticulo.FieldName = "Documento"
        ItemArticulo.DisplayFormat = "{0:n0}"
        ItemArticulo.SummaryType = DevExpress.Data.SummaryItemType.Count
        Gv.GroupSummary.Add(ItemArticulo)



    End Sub




#Region "Mantenimiento Empleados"

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
        EstoyEnAlta = True
        BinSrc.AddNew()
        PrepararAlta()
    End Sub

    Private Sub Modificar(Optional PonermeEnLaPrimeraColumna As Boolean = True)

        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Return
        End If
        EstoyEnAlta = False
        PrepararModificacion()
    End Sub
    Private Sub Eliminar()

        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Return
        End If

        

        If XtraMessageBox.Show("¿Confirma que quiere eliminar el registro seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
            Exit Sub
        End If

        Eliminando = True

      
        Dim FilaSeleccionada As Integer = Gv.FocusedRowHandle
        'BinSrc.RemoveCurrent()
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

        cmbDocumento.Enabled = False
        If Not chkLlevaTitulo.EditValue Then
            txtTituloInforme.Enabled = False
        End If
        DesHabilitarBotones()
    End Sub

    Private Sub PrepararAlta()

        HabilitarDesHabilitarCajas(True)

 
        cmbDocumento.EditValue = cmbDocumento.Properties.GetDisplayTextByKeyValue("EMAIL DETALLE").ToString
        'LookUpEditIVA.Properties.NullValuePrompt = LookUpEditIVA.Properties.GetDisplayValueByKeyValue(DatosEmpresa.IVAPrederminado).ToString

        txtAsunto.Focus()

        DesHabilitarBotones()

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

            Me.Validate()

            If Not Eliminando AndAlso Not ComprobarDatos() Then
                Return False
            End If
 


            If EstoyEnAlta Then
                '   BinSrc.Current("Codigo") = 9
                txtCodigoEmpresa.EditValue = DatosEmpresa.Codigo

 
            End If


            'If BinSrc.Item(BinSrc.Count - 1)("Observaciones") Is DBNull.Value Then
            BinSrc.EndEdit()



            '    BinSrc.Item(BinSrc.Count - 1)("Observaciones") = ""
            'End If




            Dim ValorClaveAntes As Object = Gv.GetFocusedRowCellValue("Documento")

            If Not ActualizarBaseDatos() Then
                Return False
            End If





            'Lo eliminiamos como comercial
            'If Not EstoyEnAlta Then
            '    If (chkBaja.EditValue = True AndAlso ValorBajaAntes <> chkBaja.EditValue) Or (chkComercial.EditValue = False AndAlso ValorComercialAntes <> chkComercial.EditValue) Then
            '        ConsultasBaseDatos.EliminarComercialDeComercialesCliente(CInt(txtCodigo.EditValue))
            '    End If
            'End If

            


            'If ValorClaveAntes IsNot Nothing Then
            '    bd.LlenarDataSet(SentenciaSQL, TablaMantenimiento)
            '    SituarseEnGrid(Gv, ValorClaveAntes.ToString, "Documento")
           
            'End If
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
    Private Function ActualizarBaseDatos() As Boolean

        Try
            bd.ActualizarCambios(TablaMantenimiento, bd.ds)
            'LlenarDataGrid()

            'Cargando = True
            'LlenarDataGrid()
            'Cargando = False

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
      
         
        Return True

    End Function


    Private Sub dgvxEmpleados_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvx.KeyDown

        If e.KeyCode = Keys.Escape And btnAceptar.Enabled = True Then

            Try

                Cancelar()
            Catch ex As Exception

            End Try


        End If

        If e.KeyCode = Keys.F1 And btnAceptar.Enabled = False Then
            Anadir()
            Exit Sub
        End If

        If e.KeyCode = Keys.F2 And btnAceptar.Enabled = False Then
            Eliminar()
            Exit Sub
        End If

        If e.KeyCode = Keys.F3 And btnAceptar.Enabled = False Then
            Modificar(False)
            Exit Sub
        End If

        If e.KeyCode = Keys.F12 Then
            Aceptar()
            Exit Sub
        End If
    End Sub


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
    
 
End Class





