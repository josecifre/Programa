Imports Microsoft.VisualBasic
Imports System

Partial Public Class ucEmpleados


    Inherits DevExpress.XtraEditors.XtraUserControl
    ''' <summary> 
    ''' Required designer variable.
    ''' </summary>
    '''   Inherits DevExpress.XtraEditors.XtraUserControl
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary> 
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Me.dgvx = New MyGridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.HoldfToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Gv = New MyGridView()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.ToolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
        Me.PanelCajas = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl26 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl25 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl24 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl23 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl22 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl20 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl19 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl17 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl16 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.txtPassClara = New DevExpress.XtraEditors.TextEdit()
        Me.txtBancoCuenta = New DevExpress.XtraEditors.TextEdit()
        Me.cmbAgrupaciones = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView7 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.chkComercial = New DevExpress.XtraEditors.CheckEdit()
        Me.cmbTipo = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.txtUsuario = New DevExpress.XtraEditors.TextEdit()
        Me.chkBaja = New DevExpress.XtraEditors.CheckEdit()
        Me.txtNombre = New DevExpress.XtraEditors.TextEdit()
        Me.txtAlias = New DevExpress.XtraEditors.TextEdit()
        Me.txtDireccion = New DevExpress.XtraEditors.TextEdit()
        Me.txtPoblacion = New DevExpress.XtraEditors.TextEdit()
        Me.txtCodPostal = New DevExpress.XtraEditors.TextEdit()
        Me.txtProvincia = New DevExpress.XtraEditors.TextEdit()
        Me.txtPais = New DevExpress.XtraEditors.TextEdit()
        Me.txtTelefono1 = New DevExpress.XtraEditors.TextEdit()
        Me.txtTelefono2 = New DevExpress.XtraEditors.TextEdit()
        Me.txtTelefonoMovil = New DevExpress.XtraEditors.TextEdit()
        Me.txtFax = New DevExpress.XtraEditors.TextEdit()
        Me.txtEmail = New DevExpress.XtraEditors.TextEdit()
        Me.txtObservaciones = New DevExpress.XtraEditors.MemoEdit()
        Me.txtNIF = New DevExpress.XtraEditors.TextEdit()
        Me.txtPass = New DevExpress.XtraEditors.TextEdit()
        Me.PanelBotones = New DevExpress.XtraEditors.PanelControl()
        Me.btnSalir = New uc_tb_SimpleButton()
        Me.btnCancelar = New uc_tb_SimpleButton()
        Me.btnAceptar = New uc_tb_SimpleButton()
        Me.btnModificar = New uc_tb_SimpleButton()
        Me.btnEliminar = New uc_tb_SimpleButton()
        Me.btnAnadir = New uc_tb_SimpleButton()
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.dgvxPermisos = New MyGridControl()
        Me.GvPermisos = New MyGridView()
        Me.RepositoryItemComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.btnMarcarPagina = New DevExpress.XtraEditors.SimpleButton()
        Me.btnMarcarGrupo = New DevExpress.XtraEditors.SimpleButton()
        Me.btnMarcarTodo = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancelarPermisos = New uc_tb_SimpleButton()
        Me.btnAceptarPermisos = New uc_tb_SimpleButton()
        Me.btnModificarPermisos = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.dgvx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.Gv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelCajas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelCajas.SuspendLayout()
        CType(Me.txtPassClara.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBancoCuenta.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbAgrupaciones.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkComercial.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsuario.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkBaja.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombre.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAlias.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDireccion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPoblacion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodPostal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProvincia.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPais.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTelefono1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTelefono2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTelefonoMovil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtObservaciones.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNIF.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBotones.SuspendLayout()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvxPermisos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GvPermisos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvx
        '
        Me.dgvx.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvx.ColumnaCheck = Nothing
        Me.dgvx.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgvx.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvx.Location = New System.Drawing.Point(0, 0)
        Me.dgvx.MainView = Me.Gv
        Me.dgvx.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvx.Name = "dgvx"
        Me.dgvx.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1})
        Me.dgvx.Size = New System.Drawing.Size(812, 510)
        Me.dgvx.TabIndex = 0
        Me.dgvx.tb_AnadirColumnaCheck = False
        Me.dgvx.tbPerfilPredeterminado = ""
        Me.dgvx.ToolTipController = Me.ToolTipController1
        Me.dgvx.UseDisabledStatePainter = False
        Me.dgvx.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Gv})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HoldfToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(103, 26)
        '
        'HoldfToolStripMenuItem
        '
        Me.HoldfToolStripMenuItem.Name = "HoldfToolStripMenuItem"
        Me.HoldfToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
        Me.HoldfToolStripMenuItem.Text = "holdf"
        '
        'Gv
        '
        Me.Gv.GridControl = Me.dgvx
        Me.Gv.Name = "Gv"
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'PanelCajas
        '
        Me.PanelCajas.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelCajas.Controls.Add(Me.LabelControl4)
        Me.PanelCajas.Controls.Add(Me.LabelControl3)
        Me.PanelCajas.Controls.Add(Me.LabelControl1)
        Me.PanelCajas.Controls.Add(Me.LabelControl26)
        Me.PanelCajas.Controls.Add(Me.LabelControl25)
        Me.PanelCajas.Controls.Add(Me.LabelControl24)
        Me.PanelCajas.Controls.Add(Me.LabelControl23)
        Me.PanelCajas.Controls.Add(Me.LabelControl22)
        Me.PanelCajas.Controls.Add(Me.LabelControl21)
        Me.PanelCajas.Controls.Add(Me.LabelControl20)
        Me.PanelCajas.Controls.Add(Me.LabelControl19)
        Me.PanelCajas.Controls.Add(Me.LabelControl18)
        Me.PanelCajas.Controls.Add(Me.LabelControl17)
        Me.PanelCajas.Controls.Add(Me.LabelControl16)
        Me.PanelCajas.Controls.Add(Me.LabelControl15)
        Me.PanelCajas.Controls.Add(Me.LabelControl14)
        Me.PanelCajas.Controls.Add(Me.LabelControl13)
        Me.PanelCajas.Controls.Add(Me.LabelControl12)
        Me.PanelCajas.Controls.Add(Me.txtPassClara)
        Me.PanelCajas.Controls.Add(Me.txtBancoCuenta)
        Me.PanelCajas.Controls.Add(Me.cmbAgrupaciones)
        Me.PanelCajas.Controls.Add(Me.chkComercial)
        Me.PanelCajas.Controls.Add(Me.cmbTipo)
        Me.PanelCajas.Controls.Add(Me.txtUsuario)
        Me.PanelCajas.Controls.Add(Me.chkBaja)
        Me.PanelCajas.Controls.Add(Me.txtNombre)
        Me.PanelCajas.Controls.Add(Me.txtAlias)
        Me.PanelCajas.Controls.Add(Me.txtDireccion)
        Me.PanelCajas.Controls.Add(Me.txtPoblacion)
        Me.PanelCajas.Controls.Add(Me.txtCodPostal)
        Me.PanelCajas.Controls.Add(Me.txtProvincia)
        Me.PanelCajas.Controls.Add(Me.txtPais)
        Me.PanelCajas.Controls.Add(Me.txtTelefono1)
        Me.PanelCajas.Controls.Add(Me.txtTelefono2)
        Me.PanelCajas.Controls.Add(Me.txtTelefonoMovil)
        Me.PanelCajas.Controls.Add(Me.txtFax)
        Me.PanelCajas.Controls.Add(Me.txtEmail)
        Me.PanelCajas.Controls.Add(Me.txtObservaciones)
        Me.PanelCajas.Controls.Add(Me.txtNIF)
        Me.PanelCajas.Controls.Add(Me.txtPass)
        Me.PanelCajas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelCajas.Location = New System.Drawing.Point(0, 514)
        Me.PanelCajas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PanelCajas.Name = "PanelCajas"
        Me.PanelCajas.Size = New System.Drawing.Size(1245, 223)
        Me.PanelCajas.TabIndex = 0
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(437, 168)
        Me.LabelControl4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(20, 13)
        Me.LabelControl4.TabIndex = 196
        Me.LabelControl4.Text = "Tipo"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(7, 168)
        Me.LabelControl3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(79, 13)
        Me.LabelControl3.TabIndex = 195
        Me.LabelControl3.Text = "Cuenta Bancaria"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(332, 168)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(56, 13)
        Me.LabelControl1.TabIndex = 193
        Me.LabelControl1.Text = "Contraseña"
        '
        'LabelControl26
        '
        Me.LabelControl26.Location = New System.Drawing.Point(227, 168)
        Me.LabelControl26.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl26.Name = "LabelControl26"
        Me.LabelControl26.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl26.TabIndex = 192
        Me.LabelControl26.Text = "Usuario"
        '
        'LabelControl25
        '
        Me.LabelControl25.Location = New System.Drawing.Point(441, 118)
        Me.LabelControl25.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl25.Name = "LabelControl25"
        Me.LabelControl25.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl25.TabIndex = 191
        Me.LabelControl25.Text = "Email"
        '
        'LabelControl24
        '
        Me.LabelControl24.Location = New System.Drawing.Point(333, 118)
        Me.LabelControl24.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl24.Name = "LabelControl24"
        Me.LabelControl24.Size = New System.Drawing.Size(18, 13)
        Me.LabelControl24.TabIndex = 190
        Me.LabelControl24.Text = "Fax"
        '
        'LabelControl23
        '
        Me.LabelControl23.Location = New System.Drawing.Point(227, 118)
        Me.LabelControl23.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl23.Name = "LabelControl23"
        Me.LabelControl23.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl23.TabIndex = 189
        Me.LabelControl23.Text = "Teléfono Móvil"
        '
        'LabelControl22
        '
        Me.LabelControl22.Location = New System.Drawing.Point(519, 64)
        Me.LabelControl22.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl22.Name = "LabelControl22"
        Me.LabelControl22.Size = New System.Drawing.Size(43, 13)
        Me.LabelControl22.TabIndex = 188
        Me.LabelControl22.Text = "Provincia"
        '
        'LabelControl21
        '
        Me.LabelControl21.Location = New System.Drawing.Point(438, 64)
        Me.LabelControl21.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(51, 13)
        Me.LabelControl21.TabIndex = 187
        Me.LabelControl21.Text = "Cód Postal"
        '
        'LabelControl20
        '
        Me.LabelControl20.Location = New System.Drawing.Point(332, 64)
        Me.LabelControl20.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl20.Name = "LabelControl20"
        Me.LabelControl20.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl20.TabIndex = 186
        Me.LabelControl20.Text = "Población"
        '
        'LabelControl19
        '
        Me.LabelControl19.Location = New System.Drawing.Point(8, 64)
        Me.LabelControl19.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl19.Name = "LabelControl19"
        Me.LabelControl19.Size = New System.Drawing.Size(43, 13)
        Me.LabelControl19.TabIndex = 185
        Me.LabelControl19.Text = "Dirección"
        '
        'LabelControl18
        '
        Me.LabelControl18.Location = New System.Drawing.Point(122, 118)
        Me.LabelControl18.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl18.TabIndex = 184
        Me.LabelControl18.Text = "Teléfono2"
        '
        'LabelControl17
        '
        Me.LabelControl17.Location = New System.Drawing.Point(7, 118)
        Me.LabelControl17.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl17.Name = "LabelControl17"
        Me.LabelControl17.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl17.TabIndex = 183
        Me.LabelControl17.Text = "Teléfono1"
        '
        'LabelControl16
        '
        Me.LabelControl16.Location = New System.Drawing.Point(648, 64)
        Me.LabelControl16.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl16.Name = "LabelControl16"
        Me.LabelControl16.Size = New System.Drawing.Size(19, 13)
        Me.LabelControl16.TabIndex = 182
        Me.LabelControl16.Text = "País"
        '
        'LabelControl15
        '
        Me.LabelControl15.Location = New System.Drawing.Point(782, 12)
        Me.LabelControl15.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(71, 13)
        Me.LabelControl15.TabIndex = 181
        Me.LabelControl15.Text = "Observaciones"
        '
        'LabelControl14
        '
        Me.LabelControl14.Location = New System.Drawing.Point(446, 12)
        Me.LabelControl14.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(64, 13)
        Me.LabelControl14.TabIndex = 180
        Me.LabelControl14.Text = "Sobrenombre"
        '
        'LabelControl13
        '
        Me.LabelControl13.Location = New System.Drawing.Point(332, 12)
        Me.LabelControl13.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(17, 13)
        Me.LabelControl13.TabIndex = 179
        Me.LabelControl13.Text = "NIF"
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(7, 12)
        Me.LabelControl12.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl12.TabIndex = 178
        Me.LabelControl12.Text = "Nombre"
        '
        'txtPassClara
        '
        Me.txtPassClara.EnterMoveNextControl = True
        Me.txtPassClara.Location = New System.Drawing.Point(332, 189)
        Me.txtPassClara.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPassClara.Name = "txtPassClara"
        Me.txtPassClara.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtPassClara.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtPassClara.Size = New System.Drawing.Size(99, 20)
        Me.txtPassClara.TabIndex = 18
        '
        'txtBancoCuenta
        '
        Me.txtBancoCuenta.Location = New System.Drawing.Point(7, 189)
        Me.txtBancoCuenta.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtBancoCuenta.Name = "txtBancoCuenta"
        Me.txtBancoCuenta.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtBancoCuenta.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtBancoCuenta.Size = New System.Drawing.Size(214, 20)
        Me.txtBancoCuenta.TabIndex = 16
        '
        'cmbAgrupaciones
        '
        Me.cmbAgrupaciones.EnterMoveNextControl = True
        Me.cmbAgrupaciones.Location = New System.Drawing.Point(890, 52)
        Me.cmbAgrupaciones.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbAgrupaciones.Name = "cmbAgrupaciones"
        Me.cmbAgrupaciones.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmbAgrupaciones.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.cmbAgrupaciones.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        SerializableAppearanceObject1.Font = New System.Drawing.Font("Tahoma", 8.75!, System.Drawing.FontStyle.Bold)
        SerializableAppearanceObject1.Options.UseFont = True
        ToolTipItem1.Text = "Añadir forma de pago"
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.cmbAgrupaciones.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", 30, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "Nuevo", Nothing, SuperToolTip1, True)})
        Me.cmbAgrupaciones.Properties.View = Me.GridView7
        Me.cmbAgrupaciones.Size = New System.Drawing.Size(128, 20)
        Me.cmbAgrupaciones.TabIndex = 14
        Me.cmbAgrupaciones.Visible = False
        '
        'GridView7
        '
        Me.GridView7.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView7.Name = "GridView7"
        Me.GridView7.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView7.OptionsView.ShowGroupPanel = False
        '
        'chkComercial
        '
        Me.chkComercial.Location = New System.Drawing.Point(888, 84)
        Me.chkComercial.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkComercial.Name = "chkComercial"
        Me.chkComercial.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.chkComercial.Properties.Appearance.Options.UseFont = True
        Me.chkComercial.Properties.Caption = "Vendedor"
        Me.chkComercial.Size = New System.Drawing.Size(77, 19)
        Me.chkComercial.TabIndex = 20
        Me.chkComercial.TabStop = False
        Me.chkComercial.ToolTip = "Vendedor"
        Me.chkComercial.Visible = False
        '
        'cmbTipo
        '
        Me.cmbTipo.EnterMoveNextControl = True
        Me.cmbTipo.Location = New System.Drawing.Point(437, 189)
        Me.cmbTipo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmbTipo.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.cmbTipo.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cmbTipo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbTipo.Properties.View = Me.GridView3
        Me.cmbTipo.Size = New System.Drawing.Size(230, 20)
        Me.cmbTipo.TabIndex = 19
        '
        'GridView3
        '
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'txtUsuario
        '
        Me.txtUsuario.EnterMoveNextControl = True
        Me.txtUsuario.Location = New System.Drawing.Point(227, 189)
        Me.txtUsuario.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtUsuario.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtUsuario.Size = New System.Drawing.Size(99, 20)
        Me.txtUsuario.TabIndex = 17
        '
        'chkBaja
        '
        Me.chkBaja.Location = New System.Drawing.Point(701, 189)
        Me.chkBaja.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkBaja.Name = "chkBaja"
        Me.chkBaja.Properties.Caption = "Baja"
        Me.chkBaja.Size = New System.Drawing.Size(56, 19)
        Me.chkBaja.TabIndex = 21
        Me.chkBaja.TabStop = False
        '
        'txtNombre
        '
        Me.txtNombre.EnterMoveNextControl = True
        Me.txtNombre.Location = New System.Drawing.Point(7, 32)
        Me.txtNombre.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNombre.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtNombre.Size = New System.Drawing.Size(319, 20)
        Me.txtNombre.TabIndex = 1
        '
        'txtAlias
        '
        Me.txtAlias.EnterMoveNextControl = True
        Me.txtAlias.Location = New System.Drawing.Point(438, 32)
        Me.txtAlias.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAlias.Name = "txtAlias"
        Me.txtAlias.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtAlias.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtAlias.Size = New System.Drawing.Size(319, 20)
        Me.txtAlias.TabIndex = 3
        '
        'txtDireccion
        '
        Me.txtDireccion.EnterMoveNextControl = True
        Me.txtDireccion.Location = New System.Drawing.Point(7, 83)
        Me.txtDireccion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtDireccion.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtDireccion.Size = New System.Drawing.Size(319, 20)
        Me.txtDireccion.TabIndex = 4
        '
        'txtPoblacion
        '
        Me.txtPoblacion.EnterMoveNextControl = True
        Me.txtPoblacion.Location = New System.Drawing.Point(332, 83)
        Me.txtPoblacion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPoblacion.Name = "txtPoblacion"
        Me.txtPoblacion.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtPoblacion.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtPoblacion.Size = New System.Drawing.Size(100, 20)
        Me.txtPoblacion.TabIndex = 5
        '
        'txtCodPostal
        '
        Me.txtCodPostal.EnterMoveNextControl = True
        Me.txtCodPostal.Location = New System.Drawing.Point(438, 82)
        Me.txtCodPostal.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCodPostal.Name = "txtCodPostal"
        Me.txtCodPostal.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCodPostal.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtCodPostal.Size = New System.Drawing.Size(75, 20)
        Me.txtCodPostal.TabIndex = 6
        '
        'txtProvincia
        '
        Me.txtProvincia.EnterMoveNextControl = True
        Me.txtProvincia.Location = New System.Drawing.Point(519, 83)
        Me.txtProvincia.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtProvincia.Name = "txtProvincia"
        Me.txtProvincia.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtProvincia.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtProvincia.Size = New System.Drawing.Size(123, 20)
        Me.txtProvincia.TabIndex = 7
        '
        'txtPais
        '
        Me.txtPais.EnterMoveNextControl = True
        Me.txtPais.Location = New System.Drawing.Point(648, 83)
        Me.txtPais.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPais.Name = "txtPais"
        Me.txtPais.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtPais.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtPais.Size = New System.Drawing.Size(109, 20)
        Me.txtPais.TabIndex = 8
        '
        'txtTelefono1
        '
        Me.txtTelefono1.EnterMoveNextControl = True
        Me.txtTelefono1.Location = New System.Drawing.Point(7, 138)
        Me.txtTelefono1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTelefono1.Name = "txtTelefono1"
        Me.txtTelefono1.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTelefono1.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtTelefono1.Size = New System.Drawing.Size(109, 20)
        Me.txtTelefono1.TabIndex = 9
        '
        'txtTelefono2
        '
        Me.txtTelefono2.EnterMoveNextControl = True
        Me.txtTelefono2.Location = New System.Drawing.Point(122, 138)
        Me.txtTelefono2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTelefono2.Name = "txtTelefono2"
        Me.txtTelefono2.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTelefono2.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtTelefono2.Size = New System.Drawing.Size(99, 20)
        Me.txtTelefono2.TabIndex = 10
        '
        'txtTelefonoMovil
        '
        Me.txtTelefonoMovil.EnterMoveNextControl = True
        Me.txtTelefonoMovil.Location = New System.Drawing.Point(227, 138)
        Me.txtTelefonoMovil.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTelefonoMovil.Name = "txtTelefonoMovil"
        Me.txtTelefonoMovil.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTelefonoMovil.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtTelefonoMovil.Size = New System.Drawing.Size(99, 20)
        Me.txtTelefonoMovil.TabIndex = 11
        '
        'txtFax
        '
        Me.txtFax.EnterMoveNextControl = True
        Me.txtFax.Location = New System.Drawing.Point(333, 138)
        Me.txtFax.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtFax.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtFax.Size = New System.Drawing.Size(99, 20)
        Me.txtFax.TabIndex = 12
        '
        'txtEmail
        '
        Me.txtEmail.EnterMoveNextControl = True
        Me.txtEmail.Location = New System.Drawing.Point(438, 138)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtEmail.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtEmail.Size = New System.Drawing.Size(319, 20)
        Me.txtEmail.TabIndex = 13
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObservaciones.Location = New System.Drawing.Point(782, 32)
        Me.txtObservaciones.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(459, 178)
        Me.txtObservaciones.TabIndex = 22
        '
        'txtNIF
        '
        Me.txtNIF.EnterMoveNextControl = True
        Me.txtNIF.Location = New System.Drawing.Point(332, 32)
        Me.txtNIF.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNIF.Name = "txtNIF"
        Me.txtNIF.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNIF.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtNIF.Size = New System.Drawing.Size(100, 20)
        Me.txtNIF.TabIndex = 2
        '
        'txtPass
        '
        Me.txtPass.EnterMoveNextControl = True
        Me.txtPass.Location = New System.Drawing.Point(112, 83)
        Me.txtPass.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtPass.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtPass.Size = New System.Drawing.Size(85, 20)
        Me.txtPass.TabIndex = 198
        '
        'PanelBotones
        '
        Me.PanelBotones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelBotones.Controls.Add(Me.btnSalir)
        Me.PanelBotones.Controls.Add(Me.btnCancelar)
        Me.PanelBotones.Controls.Add(Me.btnAceptar)
        Me.PanelBotones.Controls.Add(Me.btnModificar)
        Me.PanelBotones.Controls.Add(Me.btnEliminar)
        Me.PanelBotones.Controls.Add(Me.btnAnadir)
        Me.PanelBotones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBotones.Location = New System.Drawing.Point(0, 737)
        Me.PanelBotones.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PanelBotones.Name = "PanelBotones"
        Me.PanelBotones.Size = New System.Drawing.Size(1245, 63)
        Me.PanelBotones.TabIndex = 17
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Appearance.Options.UseBackColor = True
        Me.btnSalir.Appearance.Options.UseTextOptions = True
        Me.btnSalir.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnSalir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnSalir.Image = Global.My.Resources.Resources.desconexion_de_salida_icono_7025_641
        Me.btnSalir.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnSalir.Location = New System.Drawing.Point(1172, 4)
        Me.btnSalir.LookAndFeel.SkinName = "Metropolis"
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(68, 55)
        Me.btnSalir.TabIndex = 6
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.ToolTipController = Me.ToolTipController1
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnCancelar.Appearance.Options.UseBackColor = True
        Me.btnCancelar.Appearance.Options.UseTextOptions = True
        Me.btnCancelar.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnCancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnCancelar.Enabled = False
        Me.btnCancelar.Image = Global.My.Resources.Resources.cancel1
        Me.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnCancelar.Location = New System.Drawing.Point(1098, 4)
        Me.btnCancelar.LookAndFeel.SkinName = "Metropolis"
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(68, 55)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnAceptar.Appearance.Options.UseBackColor = True
        Me.btnAceptar.Appearance.Options.UseTextOptions = True
        Me.btnAceptar.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnAceptar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnAceptar.Enabled = False
        Me.btnAceptar.Image = Global.My.Resources.Resources.check1
        Me.btnAceptar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnAceptar.Location = New System.Drawing.Point(1024, 4)
        Me.btnAceptar.LookAndFeel.SkinName = "Metropolis"
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(68, 55)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "Aceptar"
        '
        'btnModificar
        '
        Me.btnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnModificar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnModificar.Appearance.Options.UseBackColor = True
        Me.btnModificar.Appearance.Options.UseTextOptions = True
        Me.btnModificar.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnModificar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnModificar.Enabled = False
        Me.btnModificar.Image = Global.My.Resources.Resources.Editar
        Me.btnModificar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnModificar.Location = New System.Drawing.Point(950, 4)
        Me.btnModificar.LookAndFeel.SkinName = "Metropolis"
        Me.btnModificar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(68, 55)
        Me.btnModificar.TabIndex = 2
        Me.btnModificar.Text = "Modificar"
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnEliminar.Appearance.Options.UseBackColor = True
        Me.btnEliminar.Appearance.Options.UseTextOptions = True
        Me.btnEliminar.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnEliminar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Image = Global.My.Resources.Resources.Eliminar1
        Me.btnEliminar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnEliminar.Location = New System.Drawing.Point(876, 4)
        Me.btnEliminar.LookAndFeel.SkinName = "Metropolis"
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(68, 55)
        Me.btnEliminar.TabIndex = 1
        Me.btnEliminar.Text = "Eliminar"
        '
        'btnAnadir
        '
        Me.btnAnadir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAnadir.Appearance.Options.UseBackColor = True
        Me.btnAnadir.Appearance.Options.UseTextOptions = True
        Me.btnAnadir.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnAnadir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnAnadir.Image = Global.My.Resources.Resources.AnadirCliente48
        Me.btnAnadir.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnAnadir.Location = New System.Drawing.Point(802, 4)
        Me.btnAnadir.LookAndFeel.SkinName = "Metropolis"
        Me.btnAnadir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAnadir.Name = "btnAnadir"
        Me.btnAnadir.Size = New System.Drawing.Size(68, 55)
        Me.btnAnadir.TabIndex = 0
        Me.btnAnadir.Text = "Añadir"
        Me.btnAnadir.ToolTip = "Pulse F1 para añadir"
        '
        'DockManager1
        '
        Me.DockManager1.Form = Me
        Me.DockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.StatusBar", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl"})
        '
        'dgvxPermisos
        '
        Me.dgvxPermisos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvxPermisos.ColumnaCheck = Nothing
        Me.dgvxPermisos.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgvxPermisos.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvxPermisos.Location = New System.Drawing.Point(818, 0)
        Me.dgvxPermisos.MainView = Me.GvPermisos
        Me.dgvxPermisos.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvxPermisos.Name = "dgvxPermisos"
        Me.dgvxPermisos.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox2})
        Me.dgvxPermisos.Size = New System.Drawing.Size(422, 455)
        Me.dgvxPermisos.TabIndex = 18
        Me.dgvxPermisos.tb_AnadirColumnaCheck = False
        Me.dgvxPermisos.tbPerfilPredeterminado = ""
        Me.dgvxPermisos.ToolTipController = Me.ToolTipController1
        Me.dgvxPermisos.UseDisabledStatePainter = False
        Me.dgvxPermisos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GvPermisos})
        '
        'GvPermisos
        '
        Me.GvPermisos.GridControl = Me.dgvxPermisos
        Me.GvPermisos.Name = "GvPermisos"
        '
        'RepositoryItemComboBox2
        '
        Me.RepositoryItemComboBox2.AutoHeight = False
        Me.RepositoryItemComboBox2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox2.Name = "RepositoryItemComboBox2"
        '
        'btnMarcarPagina
        '
        Me.btnMarcarPagina.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMarcarPagina.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnMarcarPagina.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnMarcarPagina.Appearance.Options.UseBackColor = True
        Me.btnMarcarPagina.Appearance.Options.UseTextOptions = True
        Me.btnMarcarPagina.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.btnMarcarPagina.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.btnMarcarPagina.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnMarcarPagina.Enabled = False
        Me.btnMarcarPagina.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnMarcarPagina.Location = New System.Drawing.Point(900, 459)
        Me.btnMarcarPagina.LookAndFeel.SkinName = "Metropolis"
        Me.btnMarcarPagina.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnMarcarPagina.Name = "btnMarcarPagina"
        Me.btnMarcarPagina.Size = New System.Drawing.Size(76, 51)
        Me.btnMarcarPagina.TabIndex = 338
        Me.btnMarcarPagina.Text = "Marcar Desmarcar Página"
        Me.btnMarcarPagina.Visible = False
        '
        'btnMarcarGrupo
        '
        Me.btnMarcarGrupo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMarcarGrupo.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnMarcarGrupo.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnMarcarGrupo.Appearance.Options.UseBackColor = True
        Me.btnMarcarGrupo.Appearance.Options.UseTextOptions = True
        Me.btnMarcarGrupo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.btnMarcarGrupo.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.btnMarcarGrupo.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnMarcarGrupo.Enabled = False
        Me.btnMarcarGrupo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnMarcarGrupo.Location = New System.Drawing.Point(982, 459)
        Me.btnMarcarGrupo.LookAndFeel.SkinName = "Metropolis"
        Me.btnMarcarGrupo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnMarcarGrupo.Name = "btnMarcarGrupo"
        Me.btnMarcarGrupo.Size = New System.Drawing.Size(76, 51)
        Me.btnMarcarGrupo.TabIndex = 337
        Me.btnMarcarGrupo.Text = "Marcar Desmarcar Grupo"
        Me.btnMarcarGrupo.Visible = False
        '
        'btnMarcarTodo
        '
        Me.btnMarcarTodo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMarcarTodo.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnMarcarTodo.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnMarcarTodo.Appearance.Options.UseBackColor = True
        Me.btnMarcarTodo.Appearance.Options.UseTextOptions = True
        Me.btnMarcarTodo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.btnMarcarTodo.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.btnMarcarTodo.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnMarcarTodo.Enabled = False
        Me.btnMarcarTodo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnMarcarTodo.Location = New System.Drawing.Point(818, 459)
        Me.btnMarcarTodo.LookAndFeel.SkinName = "Metropolis"
        Me.btnMarcarTodo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnMarcarTodo.Name = "btnMarcarTodo"
        Me.btnMarcarTodo.Size = New System.Drawing.Size(76, 51)
        Me.btnMarcarTodo.TabIndex = 336
        Me.btnMarcarTodo.Text = "Marcar Desmarcar Todo"
        Me.btnMarcarTodo.Visible = False
        '
        'btnCancelarPermisos
        '
        Me.btnCancelarPermisos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelarPermisos.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnCancelarPermisos.Appearance.Options.UseBackColor = True
        Me.btnCancelarPermisos.Appearance.Options.UseTextOptions = True
        Me.btnCancelarPermisos.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnCancelarPermisos.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnCancelarPermisos.Enabled = False
        Me.btnCancelarPermisos.Image = Global.My.Resources.Resources.cancel1
        Me.btnCancelarPermisos.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnCancelarPermisos.Location = New System.Drawing.Point(1172, 455)
        Me.btnCancelarPermisos.LookAndFeel.SkinName = "Metropolis"
        Me.btnCancelarPermisos.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancelarPermisos.Name = "btnCancelarPermisos"
        Me.btnCancelarPermisos.Size = New System.Drawing.Size(68, 55)
        Me.btnCancelarPermisos.TabIndex = 340
        Me.btnCancelarPermisos.Text = "Cancelar"
        '
        'btnAceptarPermisos
        '
        Me.btnAceptarPermisos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptarPermisos.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnAceptarPermisos.Appearance.Options.UseBackColor = True
        Me.btnAceptarPermisos.Appearance.Options.UseTextOptions = True
        Me.btnAceptarPermisos.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnAceptarPermisos.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnAceptarPermisos.Enabled = False
        Me.btnAceptarPermisos.Image = Global.My.Resources.Resources.check1
        Me.btnAceptarPermisos.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnAceptarPermisos.Location = New System.Drawing.Point(1098, 455)
        Me.btnAceptarPermisos.LookAndFeel.SkinName = "Metropolis"
        Me.btnAceptarPermisos.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAceptarPermisos.Name = "btnAceptarPermisos"
        Me.btnAceptarPermisos.Size = New System.Drawing.Size(68, 55)
        Me.btnAceptarPermisos.TabIndex = 339
        Me.btnAceptarPermisos.Text = "Aceptar"
        '
        'btnModificarPermisos
        '
        Me.btnModificarPermisos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnModificarPermisos.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnModificarPermisos.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnModificarPermisos.Appearance.Options.UseBackColor = True
        Me.btnModificarPermisos.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnModificarPermisos.Image = Global.My.Resources.Resources.Editar
        Me.btnModificarPermisos.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnModificarPermisos.Location = New System.Drawing.Point(818, 459)
        Me.btnModificarPermisos.LookAndFeel.SkinName = "Metropolis"
        Me.btnModificarPermisos.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnModificarPermisos.Name = "btnModificarPermisos"
        Me.btnModificarPermisos.Size = New System.Drawing.Size(164, 51)
        Me.btnModificarPermisos.TabIndex = 341
        Me.btnModificarPermisos.Text = "Modificar Permisos"
        '
        'ucEmpleados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.btnCancelarPermisos)
        Me.Controls.Add(Me.btnAceptarPermisos)
        Me.Controls.Add(Me.btnMarcarPagina)
        Me.Controls.Add(Me.btnMarcarGrupo)
        Me.Controls.Add(Me.btnMarcarTodo)
        Me.Controls.Add(Me.dgvxPermisos)
        Me.Controls.Add(Me.PanelCajas)
        Me.Controls.Add(Me.PanelBotones)
        Me.Controls.Add(Me.dgvx)
        Me.Controls.Add(Me.btnModificarPermisos)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "ucEmpleados"
        Me.Size = New System.Drawing.Size(1245, 800)
        CType(Me.dgvx,System.ComponentModel.ISupportInitialize).EndInit
        Me.ContextMenuStrip1.ResumeLayout(false)
        CType(Me.Gv,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemComboBox1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PanelCajas,System.ComponentModel.ISupportInitialize).EndInit
        Me.PanelCajas.ResumeLayout(false)
        Me.PanelCajas.PerformLayout
        CType(Me.txtPassClara.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtBancoCuenta.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cmbAgrupaciones.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView7,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.chkComercial.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cmbTipo.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView3,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtUsuario.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.chkBaja.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtNombre.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtAlias.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtDireccion.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtPoblacion.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtCodPostal.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtProvincia.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtPais.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtTelefono1.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtTelefono2.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtTelefonoMovil.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtFax.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtEmail.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtObservaciones.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtNIF.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtPass.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PanelBotones,System.ComponentModel.ISupportInitialize).EndInit
        Me.PanelBotones.ResumeLayout(false)
        CType(Me.DockManager1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dgvxPermisos,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GvPermisos,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemComboBox2,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents dgvx As MyGridControl
    Friend WithEvents Gv As MyGridView
    Friend WithEvents PanelBotones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnAceptar As uc_tb_SimpleButton
    Friend WithEvents btnModificar As uc_tb_SimpleButton
    Friend WithEvents btnEliminar As uc_tb_SimpleButton
    Friend WithEvents btnAnadir As uc_tb_SimpleButton

    Friend WithEvents PanelCajas As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtNombre As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtAlias As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtDireccion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPoblacion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCodPostal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtProvincia As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPais As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTelefono1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTelefono2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTelefonoMovil As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtFax As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtEmail As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtUsuario As DevExpress.XtraEditors.TextEdit
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents btnCancelar As uc_tb_SimpleButton

    Friend WithEvents txtObservaciones As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents txtNIF As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ToolTipController1 As DevExpress.Utils.ToolTipController
    Friend WithEvents chkBaja As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents HoldfToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSalir As uc_tb_SimpleButton
    Friend WithEvents chkComercial As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cmbAgrupaciones As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView7 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cmbTipo As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txtBancoCuenta As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPassClara As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl26 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl25 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl24 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl23 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl22 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl20 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl19 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl17 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl16 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents txtPass As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnMarcarPagina As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnMarcarGrupo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnMarcarTodo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents dgvxPermisos As MyGridControl
    Friend WithEvents GvPermisos As MyGridView
    Friend WithEvents RepositoryItemComboBox2 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents btnCancelarPermisos As uc_tb_SimpleButton
    Friend WithEvents btnAceptarPermisos As uc_tb_SimpleButton
    Friend WithEvents btnModificarPermisos As DevExpress.XtraEditors.SimpleButton

End Class
