<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucInmueblesPropietario
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.dgvxDatosPropietarios = New MyGridControl()
        Me.Gv = New MyGridView()
        Me.RepositoryItemComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.ToolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelObservaciones = New DevExpress.XtraEditors.PanelControl()
        Me.UcComunicacionesDetalle1 = New Venalia.ucComunicacionesDetalle()
        Me.txtObservaciones = New DevExpress.XtraEditors.MemoEdit()
        Me.dgvxLlamadas = New MyGridControl()
        Me.GvLlamadas = New MyGridView()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.PanelChecks = New DevExpress.XtraEditors.PanelControl()
        Me.GroupControl7 = New DevExpress.XtraEditors.GroupControl()
        Me.PanelDatos = New DevExpress.XtraEditors.PanelControl()
        Me.lblTelefono4 = New DevExpress.XtraEditors.LabelControl()
        Me.lblTelefono3 = New DevExpress.XtraEditors.LabelControl()
        Me.lblTelefono2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtTelefono4 = New DevExpress.XtraEditors.TextEdit()
        Me.txtTelefono3 = New DevExpress.XtraEditors.TextEdit()
        Me.txtTelefono2 = New DevExpress.XtraEditors.TextEdit()
        Me.btnCambiarPrecio = New uc_tb_SimpleButton()
        Me.btnPropietario = New uc_tb_SimpleButton()
        Me.btnTelefonoEmail = New uc_tb_SimpleButton()
        Me.btnAnadirObservaciones = New uc_tb_SimpleButton()
        Me.chkNoQuiereRecibirEmails = New uc_tb_CheckBoxRojoNegro()
        Me.chkNoAnimales = New uc_tb_CheckBoxRojoNegro()
        Me.chkSeguroVivienda = New uc_tb_CheckBoxRojoNegro()
        Me.chkNoExtranjeros = New uc_tb_CheckBoxRojoNegro()
        Me.chkMensual = New uc_tb_CheckBoxRojoNegro()
        Me.chkAviso3 = New uc_tb_CheckBoxRojoNegro()
        Me.chkNoInmo = New uc_tb_CheckBoxRojoNegro()
        Me.txtEmail = New DevExpress.XtraEditors.TextEdit()
        Me.lblEmail = New DevExpress.XtraEditors.LabelControl()
        Me.txtTelefonoMovil = New DevExpress.XtraEditors.TextEdit()
        Me.txtNombre = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl23 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl17 = New DevExpress.XtraEditors.LabelControl()
        Me.txtTelefono1 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.txtCodPropietario = New DevExpress.XtraEditors.TextEdit()
        Me.PanelGrid = New DevExpress.XtraEditors.PanelControl()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.dgvxDatosPropietarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelObservaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelObservaciones.SuspendLayout()
        CType(Me.txtObservaciones.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvxLlamadas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GvLlamadas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelChecks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDatos.SuspendLayout()
        CType(Me.txtTelefono4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTelefono3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTelefono2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkNoQuiereRecibirEmails.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkNoAnimales.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSeguroVivienda.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkNoExtranjeros.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkMensual.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAviso3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkNoInmo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTelefonoMovil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombre.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTelefono1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodPropietario.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelGrid.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvxDatosPropietarios
        '
        Me.dgvxDatosPropietarios.ColumnaCheck = Nothing
        Me.dgvxDatosPropietarios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvxDatosPropietarios.Location = New System.Drawing.Point(2, 2)
        Me.dgvxDatosPropietarios.MainView = Me.Gv
        Me.dgvxDatosPropietarios.Name = "dgvxDatosPropietarios"
        Me.dgvxDatosPropietarios.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox2})
        Me.dgvxDatosPropietarios.Size = New System.Drawing.Size(1182, 78)
        Me.dgvxDatosPropietarios.TabIndex = 120
        Me.dgvxDatosPropietarios.tb_AnadirColumnaCheck = False
        Me.dgvxDatosPropietarios.tbPerfilPredeterminado = ""
        Me.ToolTip1.SetToolTip(Me.dgvxDatosPropietarios, "Doble click para ir al inmueble")
        Me.dgvxDatosPropietarios.UseDisabledStatePainter = False
        Me.dgvxDatosPropietarios.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Gv})
        '
        'Gv
        '
        Me.Gv.GridControl = Me.dgvxDatosPropietarios
        Me.Gv.Name = "Gv"
        '
        'RepositoryItemComboBox2
        '
        Me.RepositoryItemComboBox2.AutoHeight = False
        Me.RepositoryItemComboBox2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox2.Name = "RepositoryItemComboBox2"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.PanelControl1)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl2.Location = New System.Drawing.Point(3, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1194, 276)
        Me.PanelControl2.TabIndex = 0
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.PanelObservaciones)
        Me.PanelControl1.Controls.Add(Me.PanelDatos)
        Me.PanelControl1.Controls.Add(Me.PanelGrid)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl1.Location = New System.Drawing.Point(2, 2)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1190, 272)
        Me.PanelControl1.TabIndex = 210
        '
        'PanelObservaciones
        '
        Me.PanelObservaciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelObservaciones.Controls.Add(Me.UcComunicacionesDetalle1)
        Me.PanelObservaciones.Controls.Add(Me.txtObservaciones)
        Me.PanelObservaciones.Controls.Add(Me.dgvxLlamadas)
        Me.PanelObservaciones.Controls.Add(Me.PanelChecks)
        Me.PanelObservaciones.Controls.Add(Me.GroupControl7)
        Me.PanelObservaciones.Location = New System.Drawing.Point(406, 86)
        Me.PanelObservaciones.Name = "PanelObservaciones"
        Me.PanelObservaciones.Size = New System.Drawing.Size(781, 183)
        Me.PanelObservaciones.TabIndex = 204
        '
        'UcComunicacionesDetalle1
        '
        Me.UcComunicacionesDetalle1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UcComunicacionesDetalle1.Location = New System.Drawing.Point(228, 6)
        Me.UcComunicacionesDetalle1.Name = "UcComunicacionesDetalle1"
        Me.UcComunicacionesDetalle1.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.UcComunicacionesDetalle1.Size = New System.Drawing.Size(548, 173)
        Me.UcComunicacionesDetalle1.TabIndex = 17
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtObservaciones.Enabled = False
        Me.txtObservaciones.Location = New System.Drawing.Point(5, 5)
        Me.txtObservaciones.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White
        Me.txtObservaciones.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.txtObservaciones.Properties.ReadOnly = True
        Me.txtObservaciones.Size = New System.Drawing.Size(221, 174)
        Me.txtObservaciones.TabIndex = 16
        '
        'dgvxLlamadas
        '
        Me.dgvxLlamadas.ColumnaCheck = Nothing
        Me.dgvxLlamadas.Location = New System.Drawing.Point(132, 78)
        Me.dgvxLlamadas.MainView = Me.GvLlamadas
        Me.dgvxLlamadas.Name = "dgvxLlamadas"
        Me.dgvxLlamadas.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1})
        Me.dgvxLlamadas.Size = New System.Drawing.Size(59, 53)
        Me.dgvxLlamadas.TabIndex = 188
        Me.dgvxLlamadas.tb_AnadirColumnaCheck = False
        Me.dgvxLlamadas.tbPerfilPredeterminado = ""
        Me.dgvxLlamadas.UseDisabledStatePainter = False
        Me.dgvxLlamadas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GvLlamadas})
        Me.dgvxLlamadas.Visible = False
        '
        'GvLlamadas
        '
        Me.GvLlamadas.GridControl = Me.dgvxLlamadas
        Me.GvLlamadas.Name = "GvLlamadas"
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'PanelChecks
        '
        Me.PanelChecks.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PanelChecks.Location = New System.Drawing.Point(5, -16)
        Me.PanelChecks.Name = "PanelChecks"
        Me.PanelChecks.Size = New System.Drawing.Size(109, 12)
        Me.PanelChecks.TabIndex = 209
        Me.PanelChecks.Visible = False
        '
        'GroupControl7
        '
        Me.GroupControl7.AppearanceCaption.Options.UseTextOptions = True
        Me.GroupControl7.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GroupControl7.Location = New System.Drawing.Point(53, 24)
        Me.GroupControl7.Name = "GroupControl7"
        Me.GroupControl7.ShowCaption = False
        Me.GroupControl7.Size = New System.Drawing.Size(107, 10)
        Me.GroupControl7.TabIndex = 239
        Me.GroupControl7.Text = "Venta / Alquiler"
        Me.GroupControl7.UseDisabledStatePainter = False
        '
        'PanelDatos
        '
        Me.PanelDatos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PanelDatos.Controls.Add(Me.lblTelefono4)
        Me.PanelDatos.Controls.Add(Me.lblTelefono3)
        Me.PanelDatos.Controls.Add(Me.lblTelefono2)
        Me.PanelDatos.Controls.Add(Me.txtTelefono4)
        Me.PanelDatos.Controls.Add(Me.txtTelefono3)
        Me.PanelDatos.Controls.Add(Me.txtTelefono2)
        Me.PanelDatos.Controls.Add(Me.btnCambiarPrecio)
        Me.PanelDatos.Controls.Add(Me.btnPropietario)
        Me.PanelDatos.Controls.Add(Me.btnTelefonoEmail)
        Me.PanelDatos.Controls.Add(Me.btnAnadirObservaciones)
        Me.PanelDatos.Controls.Add(Me.chkNoQuiereRecibirEmails)
        Me.PanelDatos.Controls.Add(Me.chkNoAnimales)
        Me.PanelDatos.Controls.Add(Me.chkSeguroVivienda)
        Me.PanelDatos.Controls.Add(Me.chkNoExtranjeros)
        Me.PanelDatos.Controls.Add(Me.chkMensual)
        Me.PanelDatos.Controls.Add(Me.chkAviso3)
        Me.PanelDatos.Controls.Add(Me.chkNoInmo)
        Me.PanelDatos.Controls.Add(Me.txtEmail)
        Me.PanelDatos.Controls.Add(Me.lblEmail)
        Me.PanelDatos.Controls.Add(Me.txtTelefonoMovil)
        Me.PanelDatos.Controls.Add(Me.txtNombre)
        Me.PanelDatos.Controls.Add(Me.LabelControl23)
        Me.PanelDatos.Controls.Add(Me.LabelControl17)
        Me.PanelDatos.Controls.Add(Me.txtTelefono1)
        Me.PanelDatos.Controls.Add(Me.LabelControl12)
        Me.PanelDatos.Controls.Add(Me.txtCodPropietario)
        Me.PanelDatos.Location = New System.Drawing.Point(0, 86)
        Me.PanelDatos.Name = "PanelDatos"
        Me.PanelDatos.Size = New System.Drawing.Size(400, 183)
        Me.PanelDatos.TabIndex = 0
        '
        'lblTelefono4
        '
        Me.lblTelefono4.Location = New System.Drawing.Point(193, 46)
        Me.lblTelefono4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lblTelefono4.Name = "lblTelefono4"
        Me.lblTelefono4.Size = New System.Drawing.Size(51, 13)
        Me.lblTelefono4.TabIndex = 205
        Me.lblTelefono4.Text = "Teléfono 4"
        Me.lblTelefono4.Visible = False
        '
        'lblTelefono3
        '
        Me.lblTelefono3.Location = New System.Drawing.Point(98, 46)
        Me.lblTelefono3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lblTelefono3.Name = "lblTelefono3"
        Me.lblTelefono3.Size = New System.Drawing.Size(51, 13)
        Me.lblTelefono3.TabIndex = 204
        Me.lblTelefono3.Text = "Teléfono 3"
        Me.lblTelefono3.Visible = False
        '
        'lblTelefono2
        '
        Me.lblTelefono2.Location = New System.Drawing.Point(8, 46)
        Me.lblTelefono2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lblTelefono2.Name = "lblTelefono2"
        Me.lblTelefono2.Size = New System.Drawing.Size(51, 13)
        Me.lblTelefono2.TabIndex = 203
        Me.lblTelefono2.Text = "Teléfono 2"
        Me.lblTelefono2.Visible = False
        '
        'txtTelefono4
        '
        Me.txtTelefono4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTelefono4.Enabled = False
        Me.txtTelefono4.EnterMoveNextControl = True
        Me.txtTelefono4.Location = New System.Drawing.Point(190, 63)
        Me.txtTelefono4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTelefono4.Name = "txtTelefono4"
        Me.txtTelefono4.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtTelefono4.Properties.Appearance.Options.UseFont = True
        Me.txtTelefono4.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTelefono4.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtTelefono4.Size = New System.Drawing.Size(84, 20)
        Me.txtTelefono4.TabIndex = 202
        Me.txtTelefono4.Visible = False
        '
        'txtTelefono3
        '
        Me.txtTelefono3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTelefono3.Enabled = False
        Me.txtTelefono3.EnterMoveNextControl = True
        Me.txtTelefono3.Location = New System.Drawing.Point(98, 63)
        Me.txtTelefono3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTelefono3.Name = "txtTelefono3"
        Me.txtTelefono3.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtTelefono3.Properties.Appearance.Options.UseFont = True
        Me.txtTelefono3.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTelefono3.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtTelefono3.Size = New System.Drawing.Size(84, 20)
        Me.txtTelefono3.TabIndex = 201
        Me.txtTelefono3.Visible = False
        '
        'txtTelefono2
        '
        Me.txtTelefono2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTelefono2.EditValue = ""
        Me.txtTelefono2.Enabled = False
        Me.txtTelefono2.EnterMoveNextControl = True
        Me.txtTelefono2.Location = New System.Drawing.Point(8, 63)
        Me.txtTelefono2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTelefono2.Name = "txtTelefono2"
        Me.txtTelefono2.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtTelefono2.Properties.Appearance.Options.UseFont = True
        Me.txtTelefono2.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTelefono2.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtTelefono2.Size = New System.Drawing.Size(84, 20)
        Me.txtTelefono2.TabIndex = 200
        Me.txtTelefono2.Visible = False
        '
        'btnCambiarPrecio
        '
        Me.btnCambiarPrecio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCambiarPrecio.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnCambiarPrecio.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnCambiarPrecio.Appearance.Options.UseFont = True
        Me.btnCambiarPrecio.Appearance.Options.UseForeColor = True
        Me.btnCambiarPrecio.Appearance.Options.UseTextOptions = True
        Me.btnCambiarPrecio.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnCambiarPrecio.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnCambiarPrecio.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnCambiarPrecio.Image = Global.My.Resources.Resources.Modificar
        Me.btnCambiarPrecio.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnCambiarPrecio.Location = New System.Drawing.Point(213, 125)
        Me.btnCambiarPrecio.LookAndFeel.SkinName = "Metropolis"
        Me.btnCambiarPrecio.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCambiarPrecio.Name = "btnCambiarPrecio"
        Me.btnCambiarPrecio.Size = New System.Drawing.Size(84, 54)
        Me.btnCambiarPrecio.TabIndex = 14
        Me.btnCambiarPrecio.Text = "Modificar"
        Me.btnCambiarPrecio.ToolTip = "Modificar Propietario"
        '
        'btnPropietario
        '
        Me.btnPropietario.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPropietario.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnPropietario.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnPropietario.Appearance.Options.UseFont = True
        Me.btnPropietario.Appearance.Options.UseForeColor = True
        Me.btnPropietario.Appearance.Options.UseTextOptions = True
        Me.btnPropietario.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnPropietario.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnPropietario.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnPropietario.Image = Global.My.Resources.Resources.DatosPropietarios
        Me.btnPropietario.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnPropietario.Location = New System.Drawing.Point(302, 125)
        Me.btnPropietario.LookAndFeel.SkinName = "Metropolis"
        Me.btnPropietario.Margin = New System.Windows.Forms.Padding(2)
        Me.btnPropietario.Name = "btnPropietario"
        Me.btnPropietario.Size = New System.Drawing.Size(89, 54)
        Me.btnPropietario.TabIndex = 15
        Me.btnPropietario.Text = "Propietario"
        '
        'btnTelefonoEmail
        '
        Me.btnTelefonoEmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnTelefonoEmail.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnTelefonoEmail.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnTelefonoEmail.Appearance.Options.UseBackColor = True
        Me.btnTelefonoEmail.Appearance.Options.UseBorderColor = True
        Me.btnTelefonoEmail.Appearance.Options.UseFont = True
        Me.btnTelefonoEmail.Appearance.Options.UseForeColor = True
        Me.btnTelefonoEmail.Appearance.Options.UseTextOptions = True
        Me.btnTelefonoEmail.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnTelefonoEmail.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.btnTelefonoEmail.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.btnTelefonoEmail.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnTelefonoEmail.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnTelefonoEmail.Location = New System.Drawing.Point(122, 125)
        Me.btnTelefonoEmail.LookAndFeel.SkinName = "Metropolis"
        Me.btnTelefonoEmail.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnTelefonoEmail.Name = "btnTelefonoEmail"
        Me.btnTelefonoEmail.Size = New System.Drawing.Size(85, 54)
        Me.btnTelefonoEmail.TabIndex = 13
        Me.btnTelefonoEmail.Text = "Mostrar Teléfonos Email"
        Me.btnTelefonoEmail.ToolTip = "Mostrar Teléfonos o Email"
        '
        'btnAnadirObservaciones
        '
        Me.btnAnadirObservaciones.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAnadirObservaciones.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnadirObservaciones.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnAnadirObservaciones.Appearance.Options.UseFont = True
        Me.btnAnadirObservaciones.Appearance.Options.UseForeColor = True
        Me.btnAnadirObservaciones.Appearance.Options.UseTextOptions = True
        Me.btnAnadirObservaciones.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnAnadirObservaciones.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnAnadirObservaciones.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnAnadirObservaciones.Image = Global.My.Resources.Resources.Observaciones
        Me.btnAnadirObservaciones.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnAnadirObservaciones.Location = New System.Drawing.Point(8, 125)
        Me.btnAnadirObservaciones.LookAndFeel.SkinName = "Metropolis"
        Me.btnAnadirObservaciones.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAnadirObservaciones.Name = "btnAnadirObservaciones"
        Me.btnAnadirObservaciones.Size = New System.Drawing.Size(97, 54)
        Me.btnAnadirObservaciones.TabIndex = 12
        Me.btnAnadirObservaciones.Text = "Observaciones"
        '
        'chkNoQuiereRecibirEmails
        '
        Me.chkNoQuiereRecibirEmails.Enabled = False
        Me.chkNoQuiereRecibirEmails.Location = New System.Drawing.Point(6, 104)
        Me.chkNoQuiereRecibirEmails.Name = "chkNoQuiereRecibirEmails"
        Me.chkNoQuiereRecibirEmails.Properties.Caption = "No Email"
        Me.chkNoQuiereRecibirEmails.Properties.ReadOnly = True
        Me.chkNoQuiereRecibirEmails.Size = New System.Drawing.Size(85, 19)
        Me.chkNoQuiereRecibirEmails.TabIndex = 8
        Me.chkNoQuiereRecibirEmails.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkNoQuiereRecibirEmails.tbColorSi = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.chkNoQuiereRecibirEmails.ToolTip = "Marcar si el cliente NO quiere recibir emails"
        '
        'chkNoAnimales
        '
        Me.chkNoAnimales.Enabled = False
        Me.chkNoAnimales.Location = New System.Drawing.Point(272, 104)
        Me.chkNoAnimales.Name = "chkNoAnimales"
        Me.chkNoAnimales.Properties.Caption = "No Animales"
        Me.chkNoAnimales.Properties.ReadOnly = True
        Me.chkNoAnimales.Size = New System.Drawing.Size(102, 19)
        Me.chkNoAnimales.TabIndex = 10
        Me.chkNoAnimales.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkNoAnimales.tbColorSi = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.chkNoAnimales.ToolTip = "Marcar si el cliente NO quiere recibir emails"
        '
        'chkSeguroVivienda
        '
        Me.chkSeguroVivienda.Enabled = False
        Me.chkSeguroVivienda.Location = New System.Drawing.Point(125, 87)
        Me.chkSeguroVivienda.Name = "chkSeguroVivienda"
        Me.chkSeguroVivienda.Properties.AutoWidth = True
        Me.chkSeguroVivienda.Properties.Caption = "Seguro Impago"
        Me.chkSeguroVivienda.Properties.ReadOnly = True
        Me.chkSeguroVivienda.Size = New System.Drawing.Size(95, 19)
        Me.chkSeguroVivienda.TabIndex = 6
        Me.chkSeguroVivienda.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkSeguroVivienda.tbColorSi = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        '
        'chkNoExtranjeros
        '
        Me.chkNoExtranjeros.Enabled = False
        Me.chkNoExtranjeros.Location = New System.Drawing.Point(272, 87)
        Me.chkNoExtranjeros.Name = "chkNoExtranjeros"
        Me.chkNoExtranjeros.Properties.Caption = "No Extranjeros"
        Me.chkNoExtranjeros.Properties.ReadOnly = True
        Me.chkNoExtranjeros.Size = New System.Drawing.Size(119, 19)
        Me.chkNoExtranjeros.TabIndex = 7
        Me.chkNoExtranjeros.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkNoExtranjeros.tbColorSi = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        '
        'chkMensual
        '
        Me.chkMensual.Enabled = False
        Me.chkMensual.Location = New System.Drawing.Point(125, 104)
        Me.chkMensual.Name = "chkMensual"
        Me.chkMensual.Properties.Caption = "Mensualidad"
        Me.chkMensual.Properties.ReadOnly = True
        Me.chkMensual.Size = New System.Drawing.Size(119, 19)
        Me.chkMensual.TabIndex = 9
        Me.chkMensual.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkMensual.tbColorSi = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        '
        'chkAviso3
        '
        Me.chkAviso3.Enabled = False
        Me.chkAviso3.Location = New System.Drawing.Point(149, 89)
        Me.chkAviso3.Name = "chkAviso3"
        Me.chkAviso3.Properties.Caption = "Aviso 3 %"
        Me.chkAviso3.Properties.ReadOnly = True
        Me.chkAviso3.Size = New System.Drawing.Size(100, 19)
        Me.chkAviso3.TabIndex = 11
        Me.chkAviso3.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkAviso3.tbColorSi = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.chkAviso3.Visible = False
        '
        'chkNoInmo
        '
        Me.chkNoInmo.Enabled = False
        Me.chkNoInmo.Location = New System.Drawing.Point(6, 87)
        Me.chkNoInmo.Name = "chkNoInmo"
        Me.chkNoInmo.Properties.Caption = "No Inmo"
        Me.chkNoInmo.Properties.ReadOnly = True
        Me.chkNoInmo.Size = New System.Drawing.Size(102, 19)
        Me.chkNoInmo.TabIndex = 5
        Me.chkNoInmo.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkNoInmo.tbColorSi = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        '
        'txtEmail
        '
        Me.txtEmail.Enabled = False
        Me.txtEmail.EnterMoveNextControl = True
        Me.txtEmail.Location = New System.Drawing.Point(8, 63)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtEmail.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtEmail.Size = New System.Drawing.Size(266, 20)
        Me.txtEmail.TabIndex = 3
        '
        'lblEmail
        '
        Me.lblEmail.Location = New System.Drawing.Point(8, 45)
        Me.lblEmail.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(24, 13)
        Me.lblEmail.TabIndex = 199
        Me.lblEmail.Text = "Email"
        '
        'txtTelefonoMovil
        '
        Me.txtTelefonoMovil.Enabled = False
        Me.txtTelefonoMovil.EnterMoveNextControl = True
        Me.txtTelefonoMovil.Location = New System.Drawing.Point(280, 20)
        Me.txtTelefonoMovil.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTelefonoMovil.Name = "txtTelefonoMovil"
        Me.txtTelefonoMovil.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTelefonoMovil.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtTelefonoMovil.Size = New System.Drawing.Size(114, 20)
        Me.txtTelefonoMovil.TabIndex = 2
        '
        'txtNombre
        '
        Me.txtNombre.Enabled = False
        Me.txtNombre.EnterMoveNextControl = True
        Me.txtNombre.Location = New System.Drawing.Point(5, 20)
        Me.txtNombre.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNombre.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtNombre.Size = New System.Drawing.Size(269, 20)
        Me.txtNombre.TabIndex = 1
        '
        'LabelControl23
        '
        Me.LabelControl23.Location = New System.Drawing.Point(280, 2)
        Me.LabelControl23.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl23.Name = "LabelControl23"
        Me.LabelControl23.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl23.TabIndex = 196
        Me.LabelControl23.Text = "Teléfono Movil"
        '
        'LabelControl17
        '
        Me.LabelControl17.Location = New System.Drawing.Point(280, 45)
        Me.LabelControl17.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl17.Name = "LabelControl17"
        Me.LabelControl17.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl17.TabIndex = 187
        Me.LabelControl17.Text = "Teléfono1"
        '
        'txtTelefono1
        '
        Me.txtTelefono1.Enabled = False
        Me.txtTelefono1.EnterMoveNextControl = True
        Me.txtTelefono1.Location = New System.Drawing.Point(280, 63)
        Me.txtTelefono1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTelefono1.Name = "txtTelefono1"
        Me.txtTelefono1.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTelefono1.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtTelefono1.Size = New System.Drawing.Size(114, 20)
        Me.txtTelefono1.TabIndex = 4
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(6, 2)
        Me.LabelControl12.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl12.TabIndex = 9
        Me.LabelControl12.Text = "Nombre"
        '
        'txtCodPropietario
        '
        Me.txtCodPropietario.Enabled = False
        Me.txtCodPropietario.EnterMoveNextControl = True
        Me.txtCodPropietario.Location = New System.Drawing.Point(326, 142)
        Me.txtCodPropietario.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCodPropietario.Name = "txtCodPropietario"
        Me.txtCodPropietario.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCodPropietario.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtCodPropietario.Size = New System.Drawing.Size(48, 20)
        Me.txtCodPropietario.TabIndex = 13
        '
        'PanelGrid
        '
        Me.PanelGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelGrid.Controls.Add(Me.dgvxDatosPropietarios)
        Me.PanelGrid.Location = New System.Drawing.Point(2, 2)
        Me.PanelGrid.Name = "PanelGrid"
        Me.PanelGrid.Size = New System.Drawing.Size(1186, 82)
        Me.PanelGrid.TabIndex = 200
        '
        'ucInmueblesPropietario
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.PanelControl2)
        Me.Name = "ucInmueblesPropietario"
        Me.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.Size = New System.Drawing.Size(1200, 276)
        CType(Me.dgvxDatosPropietarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelObservaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelObservaciones.ResumeLayout(False)
        CType(Me.txtObservaciones.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvxLlamadas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GvLlamadas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelChecks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDatos.ResumeLayout(False)
        Me.PanelDatos.PerformLayout()
        CType(Me.txtTelefono4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTelefono3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTelefono2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkNoQuiereRecibirEmails.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkNoAnimales.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSeguroVivienda.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkNoExtranjeros.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkMensual.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAviso3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkNoInmo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTelefonoMovil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombre.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTelefono1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodPropietario.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelGrid.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvxDatosPropietarios As MyGridControl
    Friend WithEvents Gv As MyGridView
    Friend WithEvents RepositoryItemComboBox2 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtNombre As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl17 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtTelefono1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl23 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtTelefonoMovil As DevExpress.XtraEditors.TextEdit
    Friend WithEvents dgvxLlamadas As MyGridControl
    Friend WithEvents GvLlamadas As MyGridView
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents PanelGrid As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelDatos As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelObservaciones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelChecks As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnPropietario As uc_tb_SimpleButton
    Friend WithEvents txtEmail As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblEmail As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl7 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtCodPropietario As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtObservaciones As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents UcComunicacionesDetalle1 As Venalia.ucComunicacionesDetalle
    Friend WithEvents btnCambiarPrecio As uc_tb_SimpleButton
    Friend WithEvents chkMensual As uc_tb_CheckBoxRojoNegro
    Friend WithEvents chkAviso3 As uc_tb_CheckBoxRojoNegro
    Friend WithEvents chkNoInmo As uc_tb_CheckBoxRojoNegro
    Friend WithEvents ToolTipController1 As DevExpress.Utils.ToolTipController
    Friend WithEvents chkNoExtranjeros As uc_tb_CheckBoxRojoNegro
    Friend WithEvents chkSeguroVivienda As uc_tb_CheckBoxRojoNegro
    Friend WithEvents chkNoAnimales As uc_tb_CheckBoxRojoNegro
    Friend WithEvents chkNoQuiereRecibirEmails As uc_tb_CheckBoxRojoNegro
    Friend WithEvents btnAnadirObservaciones As uc_tb_SimpleButton
    Friend WithEvents btnTelefonoEmail As uc_tb_SimpleButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtTelefono4 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTelefono3 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTelefono2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblTelefono4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblTelefono3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblTelefono2 As DevExpress.XtraEditors.LabelControl

End Class
