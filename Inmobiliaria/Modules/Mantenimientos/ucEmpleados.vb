

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





Partial Public Class ucEmpleados

    Inherits DevExpress.XtraEditors.XtraUserControl
 

    Dim Eliminando As Boolean = False
    Dim menu As DXPopupMenu
    Public PopupMenu As DXPopupMenu
    Dim EstoyEnAlta As Boolean

    Dim bd As BaseDatos
    Private WithEvents BinSrc As BindingSource
    Dim TablaMantenimiento As String = "Empleados"
    Dim Cargando As Boolean
    Dim PrimeraVez As Boolean
    Dim SentenciaSQL As String

    Dim ValorComercialAntes As Boolean
    Dim UsuarioAntes As String
    Dim PassAntes As String
    Dim TipoAntes As String
    Dim BajaAntes As String

    Dim CampoInicialBusqueda As String = "Nombre"


    Dim PanelComercialesClientes As DockPanel

    Dim Marcar As Boolean = False

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

     

    Private Sub ucEmpleados_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        AparienciaGeneral()
        MostrarImagenDeFondo()
        Cargando = True
        PrimeraVez = True


        If GL_TipoUsuario <> GL_ADMINISTRADOR Then
            txtPassClara.Properties.PasswordChar = "*"
        End If


        SentenciaSQL = "SELECT CodigoEmpresa, Contador, 	FechaAlta,	  	Nombre,	NIF ,	Alias ,	Direccion,	Poblacion,	CodPostal ,	Provincia ,	Pais ,	Telefono1 , " & _
             " Telefono2 ,	TelefonoMovil ,	Fax ,	Email ,	Observaciones, " & _
             " BancoCuenta ,	Agrupacion,	Comercial,Usuario,Tipo,Baja,DisenoPerfil " & _
             " ,Pass ,BancoNombre " & _
     " FROM Empleados E"



        bd = New BaseDatos
        bd.LlenarDataSet(SentenciaSQL, TablaMantenimiento, , False, True)
        bd.ds.Tables(TablaMantenimiento).Columns.Add(New DataColumn("PASSCLARA", System.Type.GetType("System.String")))

        ActualizarColumnasPassClara()


        If PrimeraVez Then
            BinSrc = New BindingSource
        End If

        dgvx.BindingContext = New BindingContext()
        BinSrc.DataSource = bd.ds
        BinSrc.DataMember = TablaMantenimiento



        'Bindings

        txtBancoCuenta.DataBindings.Add(New Binding("EditValue", BinSrc, "BancoCuenta", True))

        '      txtCodigo.DataBindings.Add(New Binding("EditValue", BinSrc, "Codigo", True))
        txtCodPostal.DataBindings.Add(New Binding("EditValue", BinSrc, "CodPostal", True))
        txtDireccion.DataBindings.Add(New Binding("EditValue", BinSrc, "Direccion", True))
        txtEmail.DataBindings.Add(New Binding("EditValue", BinSrc, "Email", True))

        txtFax.DataBindings.Add(New Binding("EditValue", BinSrc, "Fax", True))
        txtNIF.DataBindings.Add(New Binding("EditValue", BinSrc, "NIF", True))
        txtNombre.DataBindings.Add(New Binding("EditValue", BinSrc, "Nombre", True))
        txtAlias.DataBindings.Add(New Binding("EditValue", BinSrc, "Alias", True))
        txtObservaciones.DataBindings.Add(New Binding("EditValue", BinSrc, "Observaciones", True))
        txtPais.DataBindings.Add(New Binding("EditValue", BinSrc, "Pais", True))
        txtPoblacion.DataBindings.Add(New Binding("EditValue", BinSrc, "Poblacion", True))
        txtProvincia.DataBindings.Add(New Binding("EditValue", BinSrc, "Provincia", True))
        txtTelefono1.DataBindings.Add(New Binding("EditValue", BinSrc, "Telefono1", True))
        txtTelefono2.DataBindings.Add(New Binding("EditValue", BinSrc, "Telefono2", True))
        txtTelefonoMovil.DataBindings.Add(New Binding("EditValue", BinSrc, "TelefonoMovil", True))
        txtUsuario.DataBindings.Add(New Binding("EditValue", BinSrc, "Usuario", True))
        txtPassClara.DataBindings.Add(New Binding("EditValue", BinSrc, "PASSCLARA", True))
        txtPass.DataBindings.Add(New Binding("EditValue", BinSrc, "Pass", True))


        'spnDescuentoEsp.DataBindings.Add(New Binding("EditValue", BinSrc, "DescuentoEsp", True))
        'spnDiaPagoDos.DataBindings.Add(New Binding("EditValue", BinSrc, "DiaPagoDos", True))
        'spnDiaPagoUno.DataBindings.Add(New Binding("EditValue", BinSrc, "DiaPagoUno", True))
        'spnRetencion.DataBindings.Add(New Binding("EditValue", BinSrc, "Retencion", True))

        'chkAplicarIVANulo.DataBindings.Add(New Binding("EditValue", BinSrc, "AplicarIVANulo", True))
        'chkAplicarRE.DataBindings.Add(New Binding("EditValue", BinSrc, "AplicarRE", True))
        chkBaja.DataBindings.Add(New Binding("EditValue", BinSrc, "Baja", True))
        chkComercial.DataBindings.Add(New Binding("EditValue", BinSrc, "Comercial", True))



        'Combos
        FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbAgrupaciones, "Agrupaciones", "Agrupacion", "Agrupacion")
        FuncionesGenerales.Funciones.PrepararCombo(BinSrc, cmbTipo, "UsuarioTipos", "Tipo", "Tipo")


        dgvx.DataSource = BinSrc

        ParametrizarGrid(Gv)




        dgvx.tbCarpetaPerfiles = GL_CARPETA_PERFILES & "\" & Me.Name & "\" & dgvx.Name
        dgvx.ContextMenuStrip = New tbContextMenuStripComponent(dgvx.tbCarpetaPerfiles)
        'dgvx.ContextMenuStrip.Items.Add("Copiar Perfiles", Nothing, AddressOf CopiarPerfilesDgvX)

        ConfigurarGrid()


        Cargando = False

        Try
            If Not PrimeraVez Then
                HacerCambioFila()
            End If

        Catch ex As Exception

        End Try

        HabilitarBotones()
        HabilitarDesHabilitarCajas(False)

        Try
            Gv.Focus()
            Gv.FocusedColumn = Gv.Columns(CampoInicialBusqueda)
            Gv.TopRowIndex = 0
            Gv.FocusedRowHandle = 0
        Catch
        End Try
    End Sub
    Private Sub ActualizarColumnasPassClara()
        For i = 0 To bd.ds.Tables(TablaMantenimiento).Rows.Count - 1
            bd.ds.Tables(TablaMantenimiento).Rows(i).Item("PASSCLARA") = Encriptacion.DesEncriptar(bd.ds.Tables(TablaMantenimiento).Rows(i).Item("Pass"), "LAMBDAPI")
        Next
    End Sub
    Private Sub ConfigurarGrid()

        If Not PrimeraVez Then
            Exit Sub
        End If

        PrimeraVez = False
        If dgvx.tbEstablecerPerfilPredeterminado() Then
            Exit Sub
        End If



        'GridPasado.OptionsNavigation.EnterMoveNextColumn = True
        'GridPasado.OptionsNavigation.UseTabKey = True
        'GridPasado.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        Gv.OptionsView.ShowGroupPanel = False
        'GridPasado.OptionsBehavior.Editable = False
        'GridPasado.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        'GridPasado.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
        'GridPasado.OptionsView.ColumnAutoWidth = True
        Gv.OptionsView.ShowAutoFilterRow = True


        Gv.Columns("Baja").Visible = False

        Gv.Columns("FechaAlta").Visible = False
        Gv.Columns("Direccion").Visible = False
        Gv.Columns("Pais").Visible = False
        Gv.Columns("CodPostal").Visible = False
        Gv.Columns("Telefono2").Visible = False
        Gv.Columns("Fax").Visible = False

        Gv.Columns("Email").Visible = False
        Gv.Columns("Comercial").Visible = False
        Gv.Columns("Observaciones").Visible = False


        Gv.Columns("Usuario").Visible = False
        Gv.Columns("Pass").Visible = False
        Gv.Columns("Tipo").Visible = False

        Gv.Columns("Agrupacion").Visible = False

        Gv.Columns("Contador").Visible = False
        Gv.Columns("Contador").OptionsColumn.AllowShowHide = False

        Gv.Columns("CodigoEmpresa").OptionsColumn.AllowShowHide = False
        Gv.Columns("CodigoEmpresa").Visible = False

        Gv.Columns("PASSCLARA").OptionsColumn.AllowShowHide = False
        Gv.Columns("PASSCLARA").Visible = False

        Gv.Columns("DisenoPerfil").OptionsColumn.AllowShowHide = False
        Gv.Columns("DisenoPerfil").Visible = False

        Gv.Columns("BancoNombre").OptionsColumn.AllowShowHide = False
        Gv.Columns("BancoNombre").Visible = False



        Gv.BestFitColumns()


        'Sumatorios en agrupaciones
        Gv.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        Dim ItemArticulo As GridGroupSummaryItem = New GridGroupSummaryItem()
        ItemArticulo.FieldName = "Contador"
        ItemArticulo.DisplayFormat = "{0:n0}"
        ItemArticulo.SummaryType = DevExpress.Data.SummaryItemType.Count
        Gv.GroupSummary.Add(ItemArticulo)


        Gv.OptionsView.ShowFooter = True
        Gv.Columns("Nombre").SummaryItem.FieldName = "Contador"
        Gv.Columns("Nombre").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        Gv.Columns("Nombre").SummaryItem.DisplayFormat = "Total: {0:n0}"
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

        If GL_Usuario = txtUsuario.Text Then
            MensajeError("No puede eliminarse a si mismo")
            Exit Sub
        End If

        If Not PuedeEliminar("EMPLEADOS", BinSrc.Current("Contador")) Then
            MensajeError("No puede eliminar este registro porque se está utilizando en otras tablas")
            Exit Sub
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


        ValorComercialAntes = Gv.GetFocusedRowCellValue("Comercial")
        UsuarioAntes = Gv.GetFocusedRowCellValue("Usuario")
        TipoAntes = Gv.GetFocusedRowCellValue("Tipo")
        PassAntes = Gv.GetFocusedRowCellValue("Pass")
        BajaAntes = Gv.GetFocusedRowCellValue("Baja")

        For Each c As Control In PanelCajas.Controls
            c.Enabled = True
        Next



        '  txtCodigo.Enabled = False
        DesHabilitarBotones()
    End Sub

    Private Sub PrepararAlta()

        HabilitarDesHabilitarCajas(True)

        chkBaja.EditValue = False
        chkComercial.EditValue = True

        '   txtCodigo.Enabled = False
        '     chkBaja.Enabled = False

        chkComercial.EditValue = False
        txtAlias.EditValue = ""
        '      txtCodigo.Text = ""
        cmbTipo.EditValue = cmbTipo.Properties.GetDisplayTextByKeyValue("ADMINISTRADOR").ToString
        'LookUpEditIVA.Properties.NullValuePrompt = LookUpEditIVA.Properties.GetDisplayValueByKeyValue(DatosEmpresa.IVAPrederminado).ToString
        txtPassClara.EditValue = ""
        txtNombre.Focus()

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


            txtPass.EditValue = Encriptacion.Encriptar(txtPassClara.Text, "LAMBDAPI")

            BinSrc.Current("Pass") = txtPass.EditValue

            If Not EstoyEnAlta Then

                If BajaAntes <> chkBaja.EditValue AndAlso txtUsuario.EditValue = GL_Usuario Then
                    MensajeError("No se puede cambiar el estado de baja a si mismo")
                    Exit Function
                End If

            End If


            If EstoyEnAlta Then
                '   BinSrc.Current("Codigo") = 9
                '   txtCodigo.EditValue = clGenerales.SiguienteRegistro("Codigo", "Empleados")
                BinSrc.Current("FechaAlta") = Microsoft.VisualBasic.Today
                BinSrc.Current("CodigoEmpresa") = DatosEmpresa.Codigo
                BinSrc.Current("DisenoPerfil") = "Office 2010 Blue"
                BinSrc.Current("BancoNombre") = ""
                'Else
                '    If UsuarioAntes <> txtUsuario.EditValue Or PassAntes <> txtPassClara.EditValue Or TipoAntes <> cmbTipo.EditValue Or BajaAntes <> chkBaja.EditValue Then
                '        ConsultasBaseDatos.ModificarUsuario(BinSrc.Current("Contador"), txtUsuario.EditValue, txtPassClara.EditValue, cmbTipo.EditValue, chkBaja.EditValue)
                '    End If

            End If


            'If BinSrc.Item(BinSrc.Count - 1)("Observaciones") Is DBNull.Value Then
            Cargando = True
            BinSrc.EndEdit()
            Cargando = False



            '    BinSrc.Item(BinSrc.Count - 1)("Observaciones") = ""
            'End If




            Dim ValorClaveAntes As Object = BinSrc.Current("Contador")

            If Not ActualizarBaseDatos() Then
                Return False
            End If






            'Lo eliminiamos como comercial
            'If Not EstoyEnAlta Then
            '    If (chkBaja.EditValue = True AndAlso ValorBajaAntes <> chkBaja.EditValue) Or (chkComercial.EditValue = False AndAlso ValorComercialAntes <> chkComercial.EditValue) Then
            '        ConsultasBaseDatos.EliminarComercialDeComercialesCliente(CInt(txtCodigo.EditValue))
            '    End If
            'End If

            'Eliminamos acceso al programa
            'If Not EstoyEnAlta AndAlso BajaAntes <> chkBaja.EditValue Then
            '    If chkBaja.EditValue = True Then
            '        Dim BajaAPasar As Integer
            '        If chkBaja.Checked Then
            '            BajaAPasar =1
            '        Else
            '            BajaAPasar = 0
            '        End If
            '        ConsultasBaseDatos.CambiarBajaUsuario(BinSrc.Current("Contador"), DatosEmpresa.Codigo, BajaAPasar)
            '    End If
            'End If


            If ValorClaveAntes IsNot Nothing Then
                bd.LlenarDataSet(SentenciaSQL, TablaMantenimiento)
                SituarseEnGrid(Gv, ValorClaveAntes.ToString, "Contador")
            End If
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
        'If txtCodigo.Text = "" And Not EstoyEnAlta Then
        '    MensajeError("El campo código no puede estar vacío")
        '    XtraTabControl1.SelectedTabPageIndex = 0
        '    txtCodigo.Focus()
        '    Return False
        'End If

        If txtNombre.Text.ToString.Trim = "" Then
            MensajeError("El campo nombre no puede estar vacío")
            txtNombre.Focus()
            Return False
        End If


        If txtUsuario.Text.ToString.Trim = "" Then
            MensajeError("El campo usuario no puede estar vacío")
            txtUsuario.Focus()
            Return False
        End If

        If txtPassClara.Text.ToString.Trim = "" Then
            MensajeError("El campo contraseña no puede estar vacío")
            txtPassClara.Focus()
            Return False
        End If

        Dim CondicionCodigo As String = ""

        If Not Eliminando Then
            If Not EstoyEnAlta Then
                CondicionCodigo = " AND Contador <> " & BinSrc.Current("Contador")
            End If


            If clGenerales.Cuenta("Empleados", " WHERE Usuario = '" & FuncionesGenerales.Funciones.pf_ReplaceComillas(txtUsuario.EditValue) & "'" & CondicionCodigo) > 0 Then
                MensajeError("Ya existe un empleado con el usuario " & txtUsuario.EditValue)
                txtUsuario.Focus()
                Return False
            End If
        End If





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



        Dim PaginaSeleccionadaAntes As Integer

        If EstoyEnAlta Then
            PaginaSeleccionadaAntes = 0
        End If


    End Sub

#End Region

    'Private Sub FormaDePagoLookUpEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cmbFormaPago.ButtonClick


    '    If e.Button.Index <> 1 Then
    '        Exit Sub
    '    End If

    '    '   Dim f As New XtraForm
    '    Dim uc As New ucMantenimientos

    '    AbrirMantenimiento(uc, "Formas de Pago")

    '    'f.SuspendLayout()
    '    ''

    '    ''
    '    'f.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    '    'f.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    '    'f.ClientSize = New System.Drawing.Size(658, 262)
    '    'f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
    '    'f.Name = "form2"
    '    'f.Text = "form2"
    '    'f.ResumeLayout(False)


    '    'f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
    '    'uc.Dock = System.Windows.Forms.DockStyle.Fill
    '    'f.Controls.Add(uc)
    '    'f.StartPosition = FormStartPosition.CenterScreen
    '    'f.ControlBox = False
    '    'f.Text = "Formas de Pago"

    '    'f.ShowDialog()

    '    ''f.Size = New System.Drawing.Size(674, 300)
    '    ''uc.Size = New System.Drawing.Size(674, 300)
    'End Sub

    'Public Sub AbrirMantenimiento(uc As Object, Texto As String)
    '    Dim f As New XtraForm
    '    '     Dim uc As New ucMantenimientos



    '    f.SuspendLayout()
    '    '
    '    'form2
    '    '
    '    f.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    '    f.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    '    f.ClientSize = New System.Drawing.Size(658, 262)
    '    f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
    '    'f.Name = "form2"
    '    'f.Text = "form2"
    '    f.ResumeLayout(False)


    '    f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
    '    uc.Dock = System.Windows.Forms.DockStyle.Fill
    '    f.Controls.Add(uc)
    '    f.StartPosition = FormStartPosition.CenterScreen
    '    f.ControlBox = False
    '    f.Text = Texto

    '    f.ShowDialog()
    'End Sub


    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Salir()
    End Sub
    Private Sub Salir()
        Me.ParentForm.Dispose()
        MostrarImagenDeFondo()
        LiberarMemoria()
    End Sub

    Private Sub MyGridView1_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles Gv.FocusedRowChanged

        Try
            HacerCambioFila()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub HacerCambioFila()
        If Cargando Then
            Exit Sub
        End If
        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Exit Sub
        End If

        LlenarGridPermisos(False)
        HabilitarDesHabilitarBotonesPermisos(False)

        'Dim Contador As Integer = 0

        'Try
        '    Contador = CInt(Gv.GetFocusedRowCellValue("Contador"))

        'Catch ex As Exception
        '    '        Exit Sub
        'End Try

        'uGestionDoc.RefrescarBotones(CStr(Contador), TablaDocumento)


    End Sub

#Region "Permisos"



    Private Sub btnModificarPermisos_Click(sender As System.Object, e As System.EventArgs) Handles btnModificarPermisos.Click

    End Sub

    Private Sub btnCancelarPermisos_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelarPermisos.Click
        LlenarGridPermisos(False)
        HabilitarDesHabilitarBotonesPermisos(False)
    End Sub

    Private Sub btnAceptarPermisos_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptarPermisos.Click

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        EliminarTodosLosUsuariosMenus(Gv.GetFocusedRowCellValue("CONTADOR"))

        For i = 0 To GvPermisos.RowCount - 1
            If GvPermisos.GetRowCellValue(i, "Marca") = True Then
                InsertarTodosLosUsuariosMenus(Gv.GetFocusedRowCellValue("CONTADOR"), GvPermisos.GetRowCellValue(i, "Menu"), GvPermisos.GetRowCellValue(i, "Grupo"))
            End If
        Next

        LlenarGridPermisos(False)
        HabilitarDesHabilitarBotonesPermisos(False)

        Me.Cursor = System.Windows.Forms.Cursors.Arrow

    End Sub

    Private Sub HabilitarDesHabilitarBotonesPermisos(Habilitar As Boolean)

        btnAceptarPermisos.Enabled = Habilitar
        btnCancelarPermisos.Enabled = Habilitar
        btnModificarPermisos.Enabled = Not Habilitar
        PanelBotones.Enabled = Not Habilitar
        dgvx.Enabled = Not Habilitar

        btnModificarPermisos.Visible = Not Habilitar
        btnMarcarTodo.Visible = Habilitar
        btnMarcarGrupo.Visible = Habilitar
        btnMarcarPagina.Visible = Habilitar

        btnMarcarTodo.Enabled = Habilitar
        btnMarcarGrupo.Enabled = Habilitar
        btnMarcarPagina.Enabled = Habilitar

    End Sub

    Private Function EliminarTodosLosUsuariosMenus(ContadorUsuario As String) As Integer

        Dim Sel As String

        Sel = "DELETE FROM Permisos WHERE ContadorUsuario =  " & ContadorUsuario
        Return BD_CERO.Execute(Sel)

    End Function

    Public Shared Function InsertarTodosLosUsuariosMenus(ContadorUsuario As Integer, Menu As String, Grupo As String) As Integer


        Dim Sel As String
        Dim bd As New BaseDatos


        Sel = "INSERT INTO Permisos (ContadorUsuario, Menu,Grupo) VALUES ( " & ContadorUsuario & " , '" & Menu & "', '" & Grupo & "')"
        Return BD_CERO.Execute(Sel)


    End Function

    Private Sub LlenarMenus()


        Dim Sel As String = ""
        GL_Aleatorio_Menus = Microsoft.VisualBasic.Format(Now, "ddMMyyyyHHmmssfff")



        Try
            GL_GruposVisibles = ""

            Dim TienenPermiso As String = Encriptacion.DesEncriptar(FuncionesGenerales.FicheroIni.Leer(GL_FicheroINI, "CONFIG", Encriptacion.Encriptar("Páginas", "LAMBDAPI")), "LAMBDAPI")

            Dim Orden As Integer = 0
            Dim OrdenPagina As Integer
            For Each pagina As DevExpress.XtraBars.Ribbon.RibbonPage In frmPrincipal.ribbonControl.Pages

                OrdenPagina = OrdenPagina + 1

                'DIF CON PPAL
                If TienenPermiso.Contains("," & pagina.Name) AndAlso pagina.Visible Then
                    Dim OrdenGrupo As Integer = 0
                    For Each grupo As Ribbon.RibbonPageGroup In pagina.Groups

                        OrdenGrupo = OrdenGrupo + 1
                        'If frmPrincipal.ribbonControl.Pages(2).Groups(0).ItemLinks(1).Visible Then

                        'End If
                        Dim i As Integer = 0
                        '   For Each rpg As Ribbon.RibbonPageGroup In pagina.Groups   ''.ribbonControl.Pages(GL_RibbonPagePreventa).Groups
                        For j = 0 To grupo.ItemLinks.Count - 1
                            Try
                                If grupo.ItemLinks(j).Item.Visibility = BarItemVisibility.Always Then
                                    If clGenerales.Cuenta("Menus", " WHERE Menu = '" & grupo.ItemLinks(j).Item.Name & "'") = 0 Then
                                        i = i + 1
                                        Sel = "INSERT INTO Menus (Menu,TextoMenu, Grupo, TextoGrupo, Aleatorio,Orden, Pagina, OrdenGrupo,OrdenPagina) VALUES ('" & grupo.ItemLinks(j).Item.Name & "','" & grupo.ItemLinks(j).Item.Caption & "', '" & grupo.Name & "' , '" & grupo.Text & "'  , '" & GL_Aleatorio_Menus & "', " & i & ", '" & pagina.Text & "', " & OrdenGrupo & ", " & OrdenPagina & ")"
                                        BD_CERO.Execute(Sel)
                                    End If

                                End If

                            Catch ex As Exception

                            End Try

                        Next


                        
                    Next
                End If


            Next

        Catch ex As Exception

        End Try


 
    End Sub
    Private Sub LlenarGridPermisos(Todos As Boolean)

        Dim TablaPermisos As String = "Permisos"
        Dim Sel As String

        If Todos Then
            Sel = "SELECT " & Funciones.SQL_CASE({"(SELECT COUNT(*) FROM Permisos WHERE Menu = E.Menu AND Grupo= E.Grupo AND ContadorUsuario = " & Gv.GetFocusedRowCellValue("Contador") & ") > 0", "(SELECT COUNT(*) FROM Permisos WHERE Menu = E.Menu AND Grupo= E.Grupo AND ContadorUsuario = " & Gv.GetFocusedRowCellValue("Contador") & ") < 1"}, {Funciones.SQL_CONVERT("BIT", "1"), Funciones.SQL_CONVERT("BIT", "0")}) & "  AS Marcar, E.Pagina,  E.Grupo,  E.Menu , E.TextoGrupo,  E.TextoMenu FROM Menus E  ORDER BY  E.OrdenPagina,E.OrdenGrupo, E.Orden"
        Else
            Sel = "SELECT " & Funciones.SQL_CONVERT("BIT", "1") & " AS Marcar, E.Pagina , E.Grupo,   E.Menu, E.TextoGrupo,  E.TextoMenu FROM Permisos CC   INNER JOIN Menus E ON E.Menu = CC.Menu WHERE  CC.ContadorUsuario =  " & Gv.GetFocusedRowCellValue("Contador") & " AND E.Grupo= CC.Grupo AND E.Aleatorio = '" & GL_Aleatorio_Menus & "' ORDER BY  E.OrdenPagina,E.OrdenGrupo, E.Orden"
        End If

        '        Sel = "EXEC sp_UsuariosMenus  " & Gv.GetFocusedRowCellValue("CONTADOR") & " , " & FuncionesGenerales.Funciones.pf_ReplaceTrueFalse(Todos) & ",'" & GL_Aleatorio_Menus & "'"

        Dim bdPermisos As BaseDatos
        bdPermisos = New BaseDatos()
        bdPermisos.LlenarDataSet(Sel, TablaPermisos)

        Dim col As New DataColumn
        col = New DataColumn
        With col
            .DataType = System.Type.GetType("System.Boolean")
            .ColumnName = "Marca"
            .Caption = "Marcar"
        End With
        bdPermisos.ds.Tables(TablaPermisos).Columns.Add(col)
        'col = New DataColumn
        'With col
        '    .DataType = System.Type.GetType("System.String")
        '    .ColumnName = "Pagina"
        '    .Caption = "Página"
        'End With
        'bdPermisos.ds.Tables(TablaPermisos).Columns.Add(col)

        Dim borrar As New List(Of Integer)
        For i = 0 To bdPermisos.ds.Tables(TablaPermisos).Rows.Count - 1
            'If Not GL_GruposVisibles.Contains(bdPermisos.ds.Tables(TablaPermisos).Rows(i)("Grupo") & bdPermisos.ds.Tables(TablaPermisos).Rows(i)("TextoGrupo") & "|") Then 'XXXXXXXXXXXXXXXXXXXXXXXXXXX Se quitaran los no visibles(es decir los no permitidos)
            '    borrar.Add(i)
            'Else
            '  bdPermisos.ds.Tables(TablaPermisos).Rows(i)("Pagina") = GL_GrupoPagina(bdPermisos.ds.Tables(TablaPermisos).Rows(i)("Grupo"))
            bdPermisos.ds.Tables(TablaPermisos).Rows(i)("Marca") = bdPermisos.ds.Tables(TablaPermisos).Rows(i)("Marcar")
            ' End If
        Next
        'If borrar.Count > 0 Then 'XXXX para quitar las no visibles
        '    For i = borrar.Count - 1 To 0 Step -1
        '        bdPermisos.ds.Tables(TablaPermisos).Rows.RemoveAt(borrar(i))
        '    Next
        'End If

        dgvxPermisos.DataSource = bdPermisos.ds.Tables(TablaPermisos)

        ParametrizarGrid(GvPermisos)

        GvPermisos.Columns("TextoMenu").OptionsColumn.AllowEdit = False
        GvPermisos.Columns("TextoGrupo").OptionsColumn.AllowEdit = False

        GvPermisos.Columns("TextoMenu").Caption = "Menu"
        GvPermisos.Columns("TextoGrupo").Caption = "Grupo"

        GvPermisos.Columns("Pagina").VisibleIndex = 0

        GvPermisos.Columns("Menu").Visible = False
        GvPermisos.Columns("Grupo").Visible = False
        GvPermisos.Columns("Marcar").Visible = False
        '    GvPermisos.Columns("ContadorUsuario").Visible = False

        ' GvPermisos.Columns("ContadorUsuario").OptionsColumn.AllowEdit = False
        GvPermisos.Columns("Pagina").OptionsColumn.AllowEdit = False
        GvPermisos.Columns("Menu").OptionsColumn.AllowEdit = False
        GvPermisos.Columns("Marcar").OptionsColumn.AllowEdit = False

        If Todos Then
            GvPermisos.Columns("Marca").Visible = True
            GvPermisos.OptionsBehavior.Editable = True
            GvPermisos.Columns("Marca").OptionsColumn.AllowEdit = True
        Else
            GvPermisos.Columns("Marca").Visible = False
            GvPermisos.OptionsBehavior.Editable = False
            GvPermisos.Columns("Marca").OptionsColumn.AllowEdit = False
        End If



        GvPermisos.BestFitColumns()
        GvPermisos.OptionsView.ShowGroupPanel = False
        GvPermisos.OptionsView.ShowAutoFilterRow = True
        GvPermisos.OptionsView.ColumnAutoWidth = True
        GvPermisos.OptionsCustomization.AllowFilter = False
        GvPermisos.OptionsCustomization.AllowQuickHideColumns = False

    End Sub

    Private Sub btnMarcarTodo_Click(sender As System.Object, e As System.EventArgs) Handles btnMarcarTodo.Click
        Marcar = Not Marcar
        For i = 0 To GvPermisos.RowCount - 1
            GvPermisos.SetRowCellValue(i, "Marca", Marcar)
        Next
    End Sub


    Private Sub btnMarcarGrupo_Click(sender As System.Object, e As System.EventArgs) Handles btnMarcarGrupo.Click

        Dim Grupo As String = GvPermisos.GetFocusedRowCellValue("Grupo")

        Marcar = Not Marcar
        For i = 0 To GvPermisos.RowCount - 1
            If GvPermisos.GetRowCellValue(i, "Grupo") = Grupo Then
                GvPermisos.SetRowCellValue(i, "Marca", Marcar)
            End If

        Next
    End Sub

    Private Sub btnMarcarPagina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMarcarPagina.Click  'XXXXXXXXXXXX para toda la pagina

        Dim Pagina As String = GvPermisos.GetFocusedRowCellValue("Pagina")

        Marcar = Not Marcar
        For i = 0 To GvPermisos.RowCount - 1
            If GvPermisos.GetRowCellValue(i, "Pagina") = Pagina Then
                GvPermisos.SetRowCellValue(i, "Marca", Marcar)
            End If

        Next
    End Sub

#End Region
End Class




