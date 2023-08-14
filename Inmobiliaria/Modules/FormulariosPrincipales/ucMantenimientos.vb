Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors
Imports System
Imports System.Windows.Forms
Imports System.Data
Imports DevExpress.XtraGrid

 

Partial Public Class ucMantenimientos

    Dim bd As BaseDatos
    Dim TabDatos As Tablas.clTablaGeneral
    Public Tabla As String

    Dim TrabajarConAgrupaciones As Boolean
    Dim CampoBusquedas As String
    Dim AnadiendoOModificando As Boolean = False
    Dim Eliminando As Boolean = False
    Dim MasInformacion As String = ""


    Public Sub New(p_NombreTabla As String, Optional p_MasInformacion As String = "", Optional p_AnadirSalir As Boolean = True, Optional p_OcultarBotones As Boolean = False)

        Tabla = p_NombreTabla
        MasInformacion = p_MasInformacion

        Dim FiltroConsulta As String = ""
        Dim ConsultaEnVezTabla As String = ""
        Dim OrdenPasado As String = ""
        Dim AnadirSalir As Boolean = p_AnadirSalir
        Dim OcultarBotones As Boolean = p_OcultarBotones

        Select Case Tabla.ToString.ToUpper

            
            Case GL_Agrupaciones
                CampoBusquedas = "Agrupacion"
             
          



        End Select

        InitializeComponent()
        AparienciaGeneral()

        If AnadirSalir Then
            AnadirBotonSalir()
        End If


        'Select Case Tabla.ToUpper
        '    Case GL_Agrupaciones, GL_Tarifas, GL_Nacionalidades, GL_Clientes, GL_Empleados, GL_Colores
        '        TrabajarConAgrupaciones = False

        '    Case Else
        '        TrabajarConAgrupaciones = True

        'End Select

        TrabajarConAgrupaciones = False


        TabDatos = New Tablas.clTablaGeneral(Tabla, FiltroConsulta, ConsultaEnVezTabla, OrdenPasado)
        bd = New BaseDatos
        TabDatos.Datos(bd, ConsultaEnVezTabla, , , , , True)


        Dim TabAgrupaciones As Tablas.clTablaGeneral = Nothing
        If TrabajarConAgrupaciones Then
            TabAgrupaciones = New Tablas.clTablaGeneral("Agrupaciones")
            TabAgrupaciones.Datos(bd)

            Dim NombreRelacion As String = "Relacion"
            Dim TablaPrincipal As String = TabAgrupaciones.Tabla
            Dim TablaSecundaria As String = TabDatos.Tabla
            Dim Campo As String = "Agrupacion"
            bd.ds.Relations.Add(NombreRelacion, bd.ds.Tables(TablaPrincipal).Columns(Campo), bd.ds.Tables(TablaSecundaria).Columns(Campo))
        End If



        dgvx.DataSource = bd.ds.Tables(TabDatos.Tabla)


        If TrabajarConAgrupaciones Then
            Dim RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
            RepositoryItemLookUpEdit1.AutoHeight = False
            RepositoryItemLookUpEdit1.DataSource = bd.ds.Tables(TabAgrupaciones.Tabla)
            RepositoryItemLookUpEdit1.DisplayMember = "Agrupacion"
            RepositoryItemLookUpEdit1.Name = "RepositoryItemLookUpEdit1"
            RepositoryItemLookUpEdit1.ValueMember = "Agrupacion"

            Gv.Columns("Agrupacion").ColumnEdit = RepositoryItemLookUpEdit1
        End If


        ParametrizarGrid(Gv)


        '    dgvx.RepositoryItems.Add((RepositoryItemLookUpEdit1))
        'Dim bindingSource1 As New System.Windows.Forms.BindingSource
        'bindingSource1.DataSource = bd.ds
        'bindingSource1.DataMember = TabAgrupaciones.Tabla

        '    Gv.Columns.Add(ColAgrupacionAPoner)


        HabilitarBotones()
        ConfigurarGrid()
        'InitPopupMenu()

        If OcultarBotones Then
            PanelBotones.Visible = False
            pnlGrid.Height = Me.Height - 5
        End If
        Try
            Gv.Focus()
            Gv.TopRowIndex = 0
            Gv.FocusedRowHandle = 0
        Catch
        End Try
    End Sub

#Region "Boton Salir"

    Private Sub AnadirBotonSalir()


        Dim DistanciaEntreBotones As Integer

        DistanciaEntreBotones = btnEliminar.Location.X - btnAnadir.Location.X - btnEliminar.Size.Width

        For Each btn As SimpleButton In PanelBotones.Controls
            btn.Location = New System.Drawing.Point(btn.Location.X - btn.Size.Width - DistanciaEntreBotones, btn.Location.Y)
        Next


        Dim btnSalir As New uc_tb_SimpleButton()
        Me.PanelBotones.Controls.Add(btnSalir)

        btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        btnSalir.Appearance.BackColor = System.Drawing.Color.Transparent
        btnSalir.Appearance.Options.UseBackColor = True
        btnSalir.Appearance.Options.UseTextOptions = True
        btnSalir.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        btnSalir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        btnSalir.Image = My.Resources.Salir
        btnSalir.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter

        btnSalir.Name = "btnSalir"

        'btnSalir.Size = New System.Drawing.Size(90, 57)
        'btnSalir.TabIndex = 0
        btnSalir.Text = "Salir"
        Me.ToolTip1.SetToolTip(btnSalir, "Salir")
        btnSalir.Size = btnAceptar.Size
        btnSalir.Location = New System.Drawing.Point(btnAceptar.Location.X + btnAceptar.Size.Width, btnAceptar.Location.Y)

        Dim EspacioAMover As Integer = PanelBotones.Width - (btnSalir.Location.X + btnSalir.Width) - 2

        For Each btn As SimpleButton In PanelBotones.Controls
            btn.Location = New System.Drawing.Point(btn.Location.X + EspacioAMover, btn.Location.Y)
        Next

        AddHandler btnSalir.Click, AddressOf Salir


    End Sub
    Private Sub Salir(ByVal sender As Object, ByVal e As EventArgs)
        Me.ParentForm.Dispose()
    End Sub


#End Region




#Region "Mantenimiento"

    Private Sub ConfigurarGrid()

        Try
            Gv.Columns("CodigoEmpresa").OptionsColumn.AllowShowHide = False
            Gv.Columns("CodigoEmpresa").Visible = False
        Catch ex As Exception

        End Try

        Select Case Tabla.ToUpper

            'Case GL_FormasPago
            '    Gv.Columns("Nombre").Width = 150
            '    Gv.Columns("NumeroVencimientos").Width = 60
            '    Gv.Columns("DiasPrimerVencimiento").Width = 60
            '    Gv.Columns("DiasEntreVencimiento").Width = 60
            '    Gv.Columns("Agrupacion").Width = 60

            'Case GL_ClientesContactos
            '    Gv.Columns("Codigo").Visible = False
            '    Gv.Columns("CodigoCliente").Visible = False
            '    Gv.Columns("Direccion").Visible = False
            '    Gv.Columns("Poblacion").Visible = False
            '    Gv.Columns("CodPostal").Visible = False
            '    Gv.Columns("Provincia").Visible = False
            '    Gv.Columns("Pais").Visible = False
            '    Gv.Columns("Telefono2").Visible = False
            '    Gv.Columns("Fax").Visible = False
            '    Gv.Columns("Comercial").Visible = False
            '    Gv.Columns("Agrupacion").Visible = False

            'Case GL_DireccionesEnvio
            '    Gv.Columns("Codigo").Visible = False
            '    Gv.Columns("CodigoCliente").Visible = False
            '    Gv.Columns("Agrupacion").Visible = False

        End Select
    End Sub

    Private Sub Gv_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles Gv.InitNewRow

        Dim view As GridView = CType(sender, GridView)

        Try
            view.SetRowCellValue(e.RowHandle, view.Columns("CodigoEmpresa"), DatosEmpresa.Codigo)
        Catch ex As Exception

        End Try

        Select Case Tabla.ToUpper
            'Case GL_FormasPago
            '    view.SetRowCellValue(e.RowHandle, view.Columns("NumeroVencimientos"), 1)
            '    view.SetRowCellValue(e.RowHandle, view.Columns("DiasPrimerVencimiento"), 0)
            '    view.SetRowCellValue(e.RowHandle, view.Columns("DiasEntreVencimiento"), 0)

            'Case GL_ClientesContactos
            '    view.SetRowCellValue(e.RowHandle, view.Columns("CodigoCliente"), MasInformacion)

           

        End Select

        If TrabajarConAgrupaciones Then
            view.SetRowCellValue(e.RowHandle, view.Columns("Agrupacion"), "")
        End If





    End Sub
    Private Sub dgvx_EditorKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvx.EditorKeyDown

        Select Case Tabla.ToUpper
            'Case GL_FormasPago
            '    If (e.KeyCode = Keys.Decimal Or e.KeyCode = Keys.OemPeriod) AndAlso (Gv.FocusedColumn.FieldName = "NumeroVencimientos" Or Gv.FocusedColumn.FieldName = "DiasPrimerVencimiento" Or Gv.FocusedColumn.FieldName = "DiasEntreVencimiento") Then
            '        e.SuppressKeyPress = True
            '        '   SendKeys.Send(",")
            '    End If
        End Select


        If e.KeyCode = Keys.Escape Then
            Gv.CancelUpdateCurrentRow()
            HabilitarBotones()
        End If
    End Sub

    Private Sub btnAnadir_Click(sender As System.Object, e As System.EventArgs) Handles btnAnadir.Click
        Anadir()
    End Sub
    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        Eliminar()
    End Sub

    Private Sub btnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        Modificar()
    End Sub
    Private Sub Anadir()

        Gv.AddNewRow()

        Gv.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
        Gv.OptionsBehavior.Editable = True
        Gv.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom

        DesHabilitarBotones()
        Gv.FocusedColumn = Gv.Columns(CampoBusquedas)
        Gv.ShowEditor()
        AnadiendoOModificando = True

    End Sub
    Private Sub Modificar(Optional PonermeEnLaPrimeraColumna As Boolean = True)
        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Return
        End If

        If Not ComprobarDatos() Then
            Return
        End If

        Gv.OptionsBehavior.Editable = True
        DesHabilitarBotones()
        If PonermeEnLaPrimeraColumna Then
            Gv.FocusedColumn = Gv.Columns(CampoBusquedas)
            'Else
            '    Gv.FocusedColumn = Gv.Columns(Gv.FocusedColumn.FieldName)
        End If
        Gv.ShowEditor()
        '    dgvx.Focus()
        AnadiendoOModificando = True

    End Sub


    Private Function ComprobarDatos() As Boolean

        Select Case Tabla.ToUpper

            'Case GL_DireccionesEnvio
            '    If Gv.GetFocusedRowCellValue("Nombre") = GL_RAZON_SOCIAL Then
            '        MensajeError("No puede ni modificar ni eliminar esta fila")
            '        Return False
            '    End If

        End Select


        Return True
    End Function
    Private Sub Eliminar()


        If Not ComprobarDatos() Then
            Return
        End If

        If XtraMessageBox.Show("¿Confirma que quiere eliminar el registro seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
            Exit Sub
        End If
        Eliminando = True
        Dim FilaSeleccionada As Integer = Gv.FocusedRowHandle
        Gv.DeleteRow(Gv.FocusedRowHandle)
        If ActualizarDatos() Then
            If FilaSeleccionada > 1 Then
                Gv.FocusedRowHandle = FilaSeleccionada - 1
            Else
                Try
                    Gv.FocusedRowHandle = FilaSeleccionada + 1
                Catch ex As Exception

                End Try
            End If
        End If

        Eliminando = False
    End Sub
    Private Sub Aceptar()
        '  Dim FilaSeleccionada As Integer = Gv.FocusedRowHandle
        ActualizarDatos()
        '   Gv.FocusedRowHandle = FilaSeleccionada
    End Sub
    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        'Aceptar()
        HabilitarBotones()
    End Sub

    Private Sub Gv_RowUpdated(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles Gv.RowUpdated
        AnadiendoOModificando = True
        ActualizarDatos()

    End Sub




    Private Function ActualizarDatos() As Boolean

        Try
            Dim ValorClaveAntes As Object = Gv.GetFocusedRowCellValue(CampoBusquedas)
            Actualizar()
 


            If Not Eliminando AndAlso ValorClaveAntes IsNot Nothing Then
                SituarseEnGrid(Gv, ValorClaveAntes.ToString, CampoBusquedas)
            End If
            HabilitarBotones()
            Return True

        Catch ex As SqlClient.SqlException

            XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            bd.ds.Tables(TabDatos.Tabla).RejectChanges()
            bd.ds.Tables(TabDatos.Tabla).AcceptChanges()
            Return False

        End Try


    End Function

    Private Function Actualizar() As Boolean

        Try
            bd.ActualizarCambios(TabDatos.Tabla, bd.ds)
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

            bd.ds.RejectChanges()
            Return False
        End Try
    End Function

    Private Sub dgvx_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvx.DoubleClick
        Modificar(False)
    End Sub



    Private Sub dgvx_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvx.KeyDown
        If e.KeyCode = Keys.Escape Then
            Try
                Gv.CancelUpdateCurrentRow()
            Catch ex As Exception
            End Try

            HabilitarBotones()
        End If

        If e.KeyCode = Keys.F1 Then
            Anadir()
            Exit Sub
        End If

        If e.KeyCode = Keys.F2 Then
            Eliminar()
            Exit Sub
        End If

        If e.KeyCode = Keys.F3 Then
            Modificar(False)
            Exit Sub
        End If

        If e.KeyCode = Keys.F12 Then
            Aceptar()
            Exit Sub
        End If
    End Sub
    Private Sub Gv_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles Gv.FocusedRowChanged

        If AnadiendoOModificando Then
            HabilitarBotones()
        End If



    End Sub




    Private Sub HabilitarBotones()

        Gv.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        Gv.OptionsBehavior.Editable = False

        btnAnadir.Enabled = True
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        If bd.ds.Tables(TabDatos.Tabla).Rows.Count > 0 Then
            btnModificar.Enabled = True
            btnEliminar.Enabled = True
        End If

        Try
            PanelBotones.Controls("btnSalir").Enabled = True
        Catch ex As Exception

        End Try

        btnAceptar.Enabled = False
        Gv.OptionsView.NewItemRowPosition = NewItemRowPosition.None

        Select Case Tabla.ToUpper
            Case GL_Clientes, GL_Empleados
                btnAnadir.Enabled = False
                btnEliminar.Enabled = False
        End Select

        AnadiendoOModificando = False

    End Sub

    Private Sub DesHabilitarBotones()
        btnAnadir.Enabled = False
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        btnAceptar.Enabled = True
        Try
            PanelBotones.Controls("btnSalir").Enabled = False
        Catch ex As Exception

        End Try
    End Sub

#End Region

    Private Sub mnuAnadir_Click(sender As System.Object, e As System.EventArgs) Handles mnuAnadir.Click
        Anadir()
    End Sub
    Private Sub mnuModificar_Click(sender As System.Object, e As System.EventArgs) Handles mnuModificar.Click
        Modificar()
    End Sub

    Private Sub mnuEliminar_Click(sender As System.Object, e As System.EventArgs) Handles mnuEliminar.Click
        Eliminar()
    End Sub

    Private Sub ContextMenuStrip1_Opened(sender As Object, e As System.EventArgs) Handles ContextMenuStrip1.Opened
        mnuAnadir.Enabled = btnAnadir.Enabled
        mnuEliminar.Enabled = btnEliminar.Enabled
        mnuModificar.Enabled = btnModificar.Enabled
    End Sub

   
End Class

