Imports Microsoft.VisualBasic
Imports System

Partial Public Class ucPropietarios


    Inherits DevExpress.XtraEditors.XtraForm
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
        Me.dgvx = New MyGridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.HoldfToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Gv = New MyGridView()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.ToolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
        Me.PanelCajas = New DevExpress.XtraEditors.PanelControl()
        Me.chkNoExtranjeros = New uc_tb_CheckBoxRojoNegro()
        Me.chkNoQuiereRecibirEmails = New uc_tb_CheckBoxRojoNegro()
        Me.chkSeguroVivienda = New uc_tb_CheckBoxRojoNegro()
        Me.chkNoAnimales = New uc_tb_CheckBoxRojoNegro()
        Me.chkAvisadoTresPorCien = New uc_tb_CheckBoxRojoNegro()
        Me.chkNoInmobiliaria = New uc_tb_CheckBoxRojoNegro()
        Me.chkAvisadoMensualidad = New uc_tb_CheckBoxRojoNegro()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.txtCuenta = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.txtEmail2 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.txtTelefono3 = New DevExpress.XtraEditors.TextEdit()
        Me.txtTelefono4 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.mskFechaAlta = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtWeb = New DevExpress.XtraEditors.TextEdit()
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
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
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
        Me.txtNIF = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.txtObservaciones = New DevExpress.XtraEditors.MemoEdit()
        Me.PanelBotones = New DevExpress.XtraEditors.PanelControl()
        Me.btnEmailInformativo = New uc_tb_SimpleButton()
        Me.btnEmails = New uc_tb_SimpleButton()
        Me.btnNuevoInmueble = New uc_tb_SimpleButton()
        Me.btnInmuebles = New uc_tb_SimpleButton()
        Me.btnSalir = New uc_tb_SimpleButton()
        Me.btnCancelar = New uc_tb_SimpleButton()
        Me.btnAceptar = New uc_tb_SimpleButton()
        Me.btnModificar = New uc_tb_SimpleButton()
        Me.btnEliminar = New uc_tb_SimpleButton()
        Me.btnAnadir = New uc_tb_SimpleButton()
        Me.btnAnadirObservaciones = New uc_tb_SimpleButton()
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.btnSoloSinInmuebles = New uc_tb_SimpleButton()
        Me.btnNoReservados = New uc_tb_SimpleButton()
        Me.btnSoloConInmuebles = New uc_tb_SimpleButton()
        Me.btnVerTodos = New uc_tb_SimpleButton()
        Me.txtBusquedaEmailTelefono = New DevExpress.XtraEditors.ButtonEdit()
        Me.dgvxInmuebles = New MyGridControl()
        Me.GvInmuebles = New MyGridView()
        Me.RepositoryItemComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.UcComunicacionesDetalle1 = New Venalia.ucComunicacionesDetalle()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.pnlEnviado = New DevExpress.XtraEditors.PanelControl()
        Me.lblxdey = New DevExpress.XtraEditors.LabelControl()
        Me.lblEnviando = New DevExpress.XtraEditors.LabelControl()
        Me.chkBanco = New uc_tb_CheckBoxRojoNegro()
        CType(Me.dgvx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.Gv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelCajas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelCajas.SuspendLayout()
        CType(Me.chkNoExtranjeros.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkNoQuiereRecibirEmails.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSeguroVivienda.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkNoAnimales.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAvisadoTresPorCien.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkNoInmobiliaria.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAvisadoMensualidad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCuenta.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmail2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTelefono3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTelefono4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mskFechaAlta.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mskFechaAlta.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWeb.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.txtNIF.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtObservaciones.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBotones.SuspendLayout()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.txtBusquedaEmailTelefono.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvxInmuebles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GvInmuebles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlEnviado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEnviado.SuspendLayout()
        CType(Me.chkBanco.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.dgvx.Location = New System.Drawing.Point(5, 35)
        Me.dgvx.MainView = Me.Gv
        Me.dgvx.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvx.Name = "dgvx"
        Me.dgvx.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1})
        Me.dgvx.Size = New System.Drawing.Size(1216, 189)
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
        Me.PanelCajas.Controls.Add(Me.chkBanco)
        Me.PanelCajas.Controls.Add(Me.chkNoExtranjeros)
        Me.PanelCajas.Controls.Add(Me.chkNoQuiereRecibirEmails)
        Me.PanelCajas.Controls.Add(Me.chkSeguroVivienda)
        Me.PanelCajas.Controls.Add(Me.chkNoAnimales)
        Me.PanelCajas.Controls.Add(Me.chkAvisadoTresPorCien)
        Me.PanelCajas.Controls.Add(Me.chkNoInmobiliaria)
        Me.PanelCajas.Controls.Add(Me.chkAvisadoMensualidad)
        Me.PanelCajas.Controls.Add(Me.LabelControl6)
        Me.PanelCajas.Controls.Add(Me.txtCuenta)
        Me.PanelCajas.Controls.Add(Me.LabelControl5)
        Me.PanelCajas.Controls.Add(Me.txtEmail2)
        Me.PanelCajas.Controls.Add(Me.LabelControl3)
        Me.PanelCajas.Controls.Add(Me.LabelControl4)
        Me.PanelCajas.Controls.Add(Me.txtTelefono3)
        Me.PanelCajas.Controls.Add(Me.txtTelefono4)
        Me.PanelCajas.Controls.Add(Me.LabelControl2)
        Me.PanelCajas.Controls.Add(Me.mskFechaAlta)
        Me.PanelCajas.Controls.Add(Me.LabelControl1)
        Me.PanelCajas.Controls.Add(Me.txtWeb)
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
        Me.PanelCajas.Controls.Add(Me.LabelControl14)
        Me.PanelCajas.Controls.Add(Me.LabelControl13)
        Me.PanelCajas.Controls.Add(Me.LabelControl12)
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
        Me.PanelCajas.Controls.Add(Me.txtNIF)
        Me.PanelCajas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelCajas.Location = New System.Drawing.Point(0, 542)
        Me.PanelCajas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PanelCajas.Name = "PanelCajas"
        Me.PanelCajas.Size = New System.Drawing.Size(1229, 148)
        Me.PanelCajas.TabIndex = 0
        '
        'chkNoExtranjeros
        '
        Me.chkNoExtranjeros.Enabled = False
        Me.chkNoExtranjeros.Location = New System.Drawing.Point(1109, 71)
        Me.chkNoExtranjeros.Name = "chkNoExtranjeros"
        Me.chkNoExtranjeros.Properties.Caption = "No Extranjeros"
        Me.chkNoExtranjeros.Properties.ReadOnly = True
        Me.chkNoExtranjeros.Size = New System.Drawing.Size(102, 19)
        Me.chkNoExtranjeros.TabIndex = 22
        Me.chkNoExtranjeros.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkNoExtranjeros.tbColorSi = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        '
        'chkNoQuiereRecibirEmails
        '
        Me.chkNoQuiereRecibirEmails.Enabled = False
        Me.chkNoQuiereRecibirEmails.Location = New System.Drawing.Point(859, 91)
        Me.chkNoQuiereRecibirEmails.Name = "chkNoQuiereRecibirEmails"
        Me.chkNoQuiereRecibirEmails.Properties.Caption = "No Email"
        Me.chkNoQuiereRecibirEmails.Properties.ReadOnly = True
        Me.chkNoQuiereRecibirEmails.Size = New System.Drawing.Size(85, 19)
        Me.chkNoQuiereRecibirEmails.TabIndex = 23
        Me.chkNoQuiereRecibirEmails.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkNoQuiereRecibirEmails.tbColorSi = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.chkNoQuiereRecibirEmails.ToolTip = "Marcar si el cliente NO quiere recibir emails"
        '
        'chkSeguroVivienda
        '
        Me.chkSeguroVivienda.Enabled = False
        Me.chkSeguroVivienda.Location = New System.Drawing.Point(977, 71)
        Me.chkSeguroVivienda.Name = "chkSeguroVivienda"
        Me.chkSeguroVivienda.Properties.Caption = "Seguro Vivienda"
        Me.chkSeguroVivienda.Properties.ReadOnly = True
        Me.chkSeguroVivienda.Size = New System.Drawing.Size(102, 19)
        Me.chkSeguroVivienda.TabIndex = 21
        Me.chkSeguroVivienda.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkSeguroVivienda.tbColorSi = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        '
        'chkNoAnimales
        '
        Me.chkNoAnimales.Enabled = False
        Me.chkNoAnimales.Location = New System.Drawing.Point(859, 112)
        Me.chkNoAnimales.Name = "chkNoAnimales"
        Me.chkNoAnimales.Properties.Caption = "No Animales"
        Me.chkNoAnimales.Properties.ReadOnly = True
        Me.chkNoAnimales.Size = New System.Drawing.Size(102, 19)
        Me.chkNoAnimales.TabIndex = 25
        Me.chkNoAnimales.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkNoAnimales.tbColorSi = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.chkNoAnimales.ToolTip = "Marcar si el cliente NO quiere recibir emails"
        '
        'chkAvisadoTresPorCien
        '
        Me.chkAvisadoTresPorCien.Enabled = False
        Me.chkAvisadoTresPorCien.Location = New System.Drawing.Point(977, 91)
        Me.chkAvisadoTresPorCien.Name = "chkAvisadoTresPorCien"
        Me.chkAvisadoTresPorCien.Properties.Caption = "Avisado 3%"
        Me.chkAvisadoTresPorCien.Properties.ReadOnly = True
        Me.chkAvisadoTresPorCien.Size = New System.Drawing.Size(97, 19)
        Me.chkAvisadoTresPorCien.TabIndex = 26
        Me.chkAvisadoTresPorCien.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkAvisadoTresPorCien.tbColorSi = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        '
        'chkNoInmobiliaria
        '
        Me.chkNoInmobiliaria.Enabled = False
        Me.chkNoInmobiliaria.Location = New System.Drawing.Point(859, 71)
        Me.chkNoInmobiliaria.Name = "chkNoInmobiliaria"
        Me.chkNoInmobiliaria.Properties.Caption = "No Inmobiliaria"
        Me.chkNoInmobiliaria.Properties.ReadOnly = True
        Me.chkNoInmobiliaria.Size = New System.Drawing.Size(121, 19)
        Me.chkNoInmobiliaria.TabIndex = 20
        Me.chkNoInmobiliaria.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkNoInmobiliaria.tbColorSi = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        '
        'chkAvisadoMensualidad
        '
        Me.chkAvisadoMensualidad.Enabled = False
        Me.chkAvisadoMensualidad.Location = New System.Drawing.Point(977, 112)
        Me.chkAvisadoMensualidad.Name = "chkAvisadoMensualidad"
        Me.chkAvisadoMensualidad.Properties.Caption = "Avisado Mensualidad"
        Me.chkAvisadoMensualidad.Properties.ReadOnly = True
        Me.chkAvisadoMensualidad.Size = New System.Drawing.Size(141, 19)
        Me.chkAvisadoMensualidad.TabIndex = 24
        Me.chkAvisadoMensualidad.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkAvisadoMensualidad.tbColorSi = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(569, 104)
        Me.LabelControl6.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(94, 13)
        Me.LabelControl6.TabIndex = 310
        Me.LabelControl6.Text = "Nº Cuenta Bancaria"
        '
        'txtCuenta
        '
        Me.txtCuenta.EnterMoveNextControl = True
        Me.txtCuenta.Location = New System.Drawing.Point(566, 122)
        Me.txtCuenta.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCuenta.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtCuenta.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCuenta.Properties.Mask.EditMask = "\p{Lu}\p{Lu}\d\d-\d\d\d\d-\d\d\d\d-\d\d-\d\d\d\d\d\d\d\d\d\d"
        Me.txtCuenta.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.txtCuenta.Size = New System.Drawing.Size(172, 20)
        Me.txtCuenta.TabIndex = 17
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(345, 102)
        Me.LabelControl5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(30, 13)
        Me.LabelControl5.TabIndex = 308
        Me.LabelControl5.Text = "Email2"
        '
        'txtEmail2
        '
        Me.txtEmail2.EnterMoveNextControl = True
        Me.txtEmail2.Location = New System.Drawing.Point(345, 122)
        Me.txtEmail2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtEmail2.Name = "txtEmail2"
        Me.txtEmail2.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtEmail2.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtEmail2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmail2.Size = New System.Drawing.Size(214, 20)
        Me.txtEmail2.TabIndex = 16
        Me.txtEmail2.Tag = "Email2"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(744, 57)
        Me.LabelControl3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(51, 13)
        Me.LabelControl3.TabIndex = 306
        Me.LabelControl3.Text = "Telefono 4"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(639, 57)
        Me.LabelControl4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(51, 13)
        Me.LabelControl4.TabIndex = 305
        Me.LabelControl4.Text = "Telefono 3"
        '
        'txtTelefono3
        '
        Me.txtTelefono3.EnterMoveNextControl = True
        Me.txtTelefono3.Location = New System.Drawing.Point(639, 75)
        Me.txtTelefono3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTelefono3.Name = "txtTelefono3"
        Me.txtTelefono3.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTelefono3.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtTelefono3.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTelefono3.Size = New System.Drawing.Size(99, 20)
        Me.txtTelefono3.TabIndex = 12
        Me.txtTelefono3.Tag = "Telefono3"
        '
        'txtTelefono4
        '
        Me.txtTelefono4.EnterMoveNextControl = True
        Me.txtTelefono4.Location = New System.Drawing.Point(744, 75)
        Me.txtTelefono4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTelefono4.Name = "txtTelefono4"
        Me.txtTelefono4.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTelefono4.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtTelefono4.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTelefono4.Size = New System.Drawing.Size(99, 20)
        Me.txtTelefono4.TabIndex = 13
        Me.txtTelefono4.Tag = "Telefono4"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(743, 102)
        Me.LabelControl2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(51, 13)
        Me.LabelControl2.TabIndex = 202
        Me.LabelControl2.Text = "Fecha Alta"
        '
        'mskFechaAlta
        '
        Me.mskFechaAlta.EditValue = Nothing
        Me.mskFechaAlta.EnterMoveNextControl = True
        Me.mskFechaAlta.Location = New System.Drawing.Point(743, 122)
        Me.mskFechaAlta.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.mskFechaAlta.Name = "mskFechaAlta"
        Me.mskFechaAlta.Properties.Appearance.Options.UseTextOptions = True
        Me.mskFechaAlta.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.mskFechaAlta.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White
        Me.mskFechaAlta.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.mskFechaAlta.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.mskFechaAlta.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.mskFechaAlta.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.mskFechaAlta.Properties.EditFormat.FormatString = "dd/MM/yy"
        Me.mskFechaAlta.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.mskFechaAlta.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Strong
        Me.mskFechaAlta.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.mskFechaAlta.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.mskFechaAlta.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.mskFechaAlta.Size = New System.Drawing.Size(100, 20)
        Me.mskFechaAlta.TabIndex = 19
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(367, 125)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl1.TabIndex = 199
        Me.LabelControl1.Text = "Web"
        Me.LabelControl1.Visible = False
        '
        'txtWeb
        '
        Me.txtWeb.EnterMoveNextControl = True
        Me.txtWeb.Location = New System.Drawing.Point(423, 122)
        Me.txtWeb.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtWeb.Name = "txtWeb"
        Me.txtWeb.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtWeb.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtWeb.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWeb.Size = New System.Drawing.Size(210, 20)
        Me.txtWeb.TabIndex = 18
        Me.txtWeb.Visible = False
        '
        'LabelControl25
        '
        Me.LabelControl25.Location = New System.Drawing.Point(117, 101)
        Me.LabelControl25.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl25.Name = "LabelControl25"
        Me.LabelControl25.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl25.TabIndex = 191
        Me.LabelControl25.Text = "Email"
        '
        'LabelControl24
        '
        Me.LabelControl24.Location = New System.Drawing.Point(8, 104)
        Me.LabelControl24.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl24.Name = "LabelControl24"
        Me.LabelControl24.Size = New System.Drawing.Size(18, 13)
        Me.LabelControl24.TabIndex = 190
        Me.LabelControl24.Text = "Fax"
        '
        'LabelControl23
        '
        Me.LabelControl23.Location = New System.Drawing.Point(325, 57)
        Me.LabelControl23.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl23.Name = "LabelControl23"
        Me.LabelControl23.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl23.TabIndex = 189
        Me.LabelControl23.Text = "Telefono Movil"
        '
        'LabelControl22
        '
        Me.LabelControl22.Location = New System.Drawing.Point(79, 55)
        Me.LabelControl22.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl22.Name = "LabelControl22"
        Me.LabelControl22.Size = New System.Drawing.Size(43, 13)
        Me.LabelControl22.TabIndex = 188
        Me.LabelControl22.Text = "Provincia"
        '
        'LabelControl21
        '
        Me.LabelControl21.Location = New System.Drawing.Point(8, 55)
        Me.LabelControl21.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(43, 13)
        Me.LabelControl21.TabIndex = 187
        Me.LabelControl21.Text = "C. Postal"
        '
        'LabelControl20
        '
        Me.LabelControl20.Location = New System.Drawing.Point(974, 6)
        Me.LabelControl20.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl20.Name = "LabelControl20"
        Me.LabelControl20.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl20.TabIndex = 186
        Me.LabelControl20.Text = "Poblacion"
        '
        'LabelControl19
        '
        Me.LabelControl19.Location = New System.Drawing.Point(565, 7)
        Me.LabelControl19.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl19.Name = "LabelControl19"
        Me.LabelControl19.Size = New System.Drawing.Size(43, 13)
        Me.LabelControl19.TabIndex = 185
        Me.LabelControl19.Text = "Direccion"
        '
        'LabelControl18
        '
        Me.LabelControl18.Location = New System.Drawing.Point(534, 57)
        Me.LabelControl18.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(51, 13)
        Me.LabelControl18.TabIndex = 184
        Me.LabelControl18.Text = "Telefono 2"
        '
        'LabelControl17
        '
        Me.LabelControl17.Location = New System.Drawing.Point(429, 57)
        Me.LabelControl17.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl17.Name = "LabelControl17"
        Me.LabelControl17.Size = New System.Drawing.Size(51, 13)
        Me.LabelControl17.TabIndex = 183
        Me.LabelControl17.Text = "Telefono 1"
        '
        'LabelControl16
        '
        Me.LabelControl16.Location = New System.Drawing.Point(209, 55)
        Me.LabelControl16.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl16.Name = "LabelControl16"
        Me.LabelControl16.Size = New System.Drawing.Size(19, 13)
        Me.LabelControl16.TabIndex = 182
        Me.LabelControl16.Text = "Pais"
        '
        'LabelControl14
        '
        Me.LabelControl14.Location = New System.Drawing.Point(412, 7)
        Me.LabelControl14.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(64, 13)
        Me.LabelControl14.TabIndex = 180
        Me.LabelControl14.Text = "Sobrenombre"
        '
        'LabelControl13
        '
        Me.LabelControl13.Location = New System.Drawing.Point(325, 7)
        Me.LabelControl13.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(17, 13)
        Me.LabelControl13.TabIndex = 179
        Me.LabelControl13.Text = "NIF"
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(7, 6)
        Me.LabelControl12.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl12.TabIndex = 178
        Me.LabelControl12.Text = "Nombre"
        '
        'txtNombre
        '
        Me.txtNombre.EnterMoveNextControl = True
        Me.txtNombre.Location = New System.Drawing.Point(7, 26)
        Me.txtNombre.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNombre.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtNombre.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Size = New System.Drawing.Size(312, 20)
        Me.txtNombre.TabIndex = 1
        '
        'txtAlias
        '
        Me.txtAlias.EnterMoveNextControl = True
        Me.txtAlias.Location = New System.Drawing.Point(410, 27)
        Me.txtAlias.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAlias.Name = "txtAlias"
        Me.txtAlias.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtAlias.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtAlias.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAlias.Size = New System.Drawing.Size(149, 20)
        Me.txtAlias.TabIndex = 3
        '
        'txtDireccion
        '
        Me.txtDireccion.EnterMoveNextControl = True
        Me.txtDireccion.Location = New System.Drawing.Point(565, 26)
        Me.txtDireccion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtDireccion.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtDireccion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDireccion.Size = New System.Drawing.Size(403, 20)
        Me.txtDireccion.TabIndex = 4
        '
        'txtPoblacion
        '
        Me.txtPoblacion.EnterMoveNextControl = True
        Me.txtPoblacion.Location = New System.Drawing.Point(974, 26)
        Me.txtPoblacion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPoblacion.Name = "txtPoblacion"
        Me.txtPoblacion.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtPoblacion.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtPoblacion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPoblacion.Size = New System.Drawing.Size(245, 20)
        Me.txtPoblacion.TabIndex = 5
        '
        'txtCodPostal
        '
        Me.txtCodPostal.EnterMoveNextControl = True
        Me.txtCodPostal.Location = New System.Drawing.Point(8, 75)
        Me.txtCodPostal.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCodPostal.Name = "txtCodPostal"
        Me.txtCodPostal.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCodPostal.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtCodPostal.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodPostal.Size = New System.Drawing.Size(67, 20)
        Me.txtCodPostal.TabIndex = 6
        '
        'txtProvincia
        '
        Me.txtProvincia.EnterMoveNextControl = True
        Me.txtProvincia.Location = New System.Drawing.Point(81, 75)
        Me.txtProvincia.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtProvincia.Name = "txtProvincia"
        Me.txtProvincia.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtProvincia.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtProvincia.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProvincia.Size = New System.Drawing.Size(122, 20)
        Me.txtProvincia.TabIndex = 7
        '
        'txtPais
        '
        Me.txtPais.EnterMoveNextControl = True
        Me.txtPais.Location = New System.Drawing.Point(209, 75)
        Me.txtPais.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPais.Name = "txtPais"
        Me.txtPais.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtPais.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtPais.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPais.Size = New System.Drawing.Size(110, 20)
        Me.txtPais.TabIndex = 8
        '
        'txtTelefono1
        '
        Me.txtTelefono1.EnterMoveNextControl = True
        Me.txtTelefono1.Location = New System.Drawing.Point(429, 75)
        Me.txtTelefono1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTelefono1.Name = "txtTelefono1"
        Me.txtTelefono1.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTelefono1.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtTelefono1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTelefono1.Size = New System.Drawing.Size(99, 20)
        Me.txtTelefono1.TabIndex = 10
        Me.txtTelefono1.Tag = "Telefono1"
        '
        'txtTelefono2
        '
        Me.txtTelefono2.EnterMoveNextControl = True
        Me.txtTelefono2.Location = New System.Drawing.Point(534, 75)
        Me.txtTelefono2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTelefono2.Name = "txtTelefono2"
        Me.txtTelefono2.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTelefono2.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtTelefono2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTelefono2.Size = New System.Drawing.Size(99, 20)
        Me.txtTelefono2.TabIndex = 11
        Me.txtTelefono2.Tag = "Telefono2"
        '
        'txtTelefonoMovil
        '
        Me.txtTelefonoMovil.EnterMoveNextControl = True
        Me.txtTelefonoMovil.Location = New System.Drawing.Point(324, 75)
        Me.txtTelefonoMovil.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTelefonoMovil.Name = "txtTelefonoMovil"
        Me.txtTelefonoMovil.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTelefonoMovil.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtTelefonoMovil.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTelefonoMovil.Size = New System.Drawing.Size(99, 20)
        Me.txtTelefonoMovil.TabIndex = 9
        Me.txtTelefonoMovil.Tag = "TelefonoMovil"
        '
        'txtFax
        '
        Me.txtFax.EnterMoveNextControl = True
        Me.txtFax.Location = New System.Drawing.Point(8, 122)
        Me.txtFax.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtFax.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtFax.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFax.Size = New System.Drawing.Size(103, 20)
        Me.txtFax.TabIndex = 14
        Me.txtFax.Tag = "Fax"
        '
        'txtEmail
        '
        Me.txtEmail.EnterMoveNextControl = True
        Me.txtEmail.Location = New System.Drawing.Point(114, 122)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtEmail.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtEmail.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmail.Size = New System.Drawing.Size(225, 20)
        Me.txtEmail.TabIndex = 15
        Me.txtEmail.Tag = "Email"
        '
        'txtNIF
        '
        Me.txtNIF.EnterMoveNextControl = True
        Me.txtNIF.Location = New System.Drawing.Point(325, 27)
        Me.txtNIF.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNIF.Name = "txtNIF"
        Me.txtNIF.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNIF.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtNIF.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNIF.Size = New System.Drawing.Size(80, 20)
        Me.txtNIF.TabIndex = 2
        '
        'LabelControl15
        '
        Me.LabelControl15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelControl15.Location = New System.Drawing.Point(8, 373)
        Me.LabelControl15.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(71, 13)
        Me.LabelControl15.TabIndex = 181
        Me.LabelControl15.Text = "Observaciones"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtObservaciones.Location = New System.Drawing.Point(7, 390)
        Me.txtObservaciones.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(536, 147)
        Me.txtObservaciones.TabIndex = 16
        '
        'PanelBotones
        '
        Me.PanelBotones.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.PanelBotones.Appearance.Options.UseBackColor = True
        Me.PanelBotones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.PanelBotones.Controls.Add(Me.btnEmailInformativo)
        Me.PanelBotones.Controls.Add(Me.btnEmails)
        Me.PanelBotones.Controls.Add(Me.btnNuevoInmueble)
        Me.PanelBotones.Controls.Add(Me.btnInmuebles)
        Me.PanelBotones.Controls.Add(Me.btnSalir)
        Me.PanelBotones.Controls.Add(Me.btnCancelar)
        Me.PanelBotones.Controls.Add(Me.btnAceptar)
        Me.PanelBotones.Controls.Add(Me.btnModificar)
        Me.PanelBotones.Controls.Add(Me.btnEliminar)
        Me.PanelBotones.Controls.Add(Me.btnAnadir)
        Me.PanelBotones.Controls.Add(Me.btnAnadirObservaciones)
        Me.PanelBotones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBotones.Location = New System.Drawing.Point(0, 690)
        Me.PanelBotones.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PanelBotones.Name = "PanelBotones"
        Me.PanelBotones.Size = New System.Drawing.Size(1229, 63)
        Me.PanelBotones.TabIndex = 17
        '
        'btnEmailInformativo
        '
        Me.btnEmailInformativo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEmailInformativo.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnEmailInformativo.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnEmailInformativo.Appearance.Options.UseBackColor = True
        Me.btnEmailInformativo.Appearance.Options.UseBorderColor = True
        Me.btnEmailInformativo.Appearance.Options.UseFont = True
        Me.btnEmailInformativo.Appearance.Options.UseForeColor = True
        Me.btnEmailInformativo.Appearance.Options.UseTextOptions = True
        Me.btnEmailInformativo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnEmailInformativo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnEmailInformativo.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnEmailInformativo.Image = Global.My.Resources.Resources.EmailBoton
        Me.btnEmailInformativo.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnEmailInformativo.Location = New System.Drawing.Point(292, 4)
        Me.btnEmailInformativo.LookAndFeel.SkinName = "Metropolis"
        Me.btnEmailInformativo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEmailInformativo.Name = "btnEmailInformativo"
        Me.btnEmailInformativo.Size = New System.Drawing.Size(83, 55)
        Me.btnEmailInformativo.TabIndex = 38
        Me.btnEmailInformativo.Text = "Informativo"
        Me.btnEmailInformativo.ToolTip = "Enviar Email con texto informativo"
        '
        'btnEmails
        '
        Me.btnEmails.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEmails.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnEmails.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnEmails.Appearance.Options.UseBackColor = True
        Me.btnEmails.Appearance.Options.UseBorderColor = True
        Me.btnEmails.Appearance.Options.UseFont = True
        Me.btnEmails.Appearance.Options.UseForeColor = True
        Me.btnEmails.Appearance.Options.UseTextOptions = True
        Me.btnEmails.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnEmails.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnEmails.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnEmails.Image = Global.My.Resources.Resources.EmailBoton
        Me.btnEmails.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnEmails.Location = New System.Drawing.Point(203, 4)
        Me.btnEmails.LookAndFeel.SkinName = "Metropolis"
        Me.btnEmails.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEmails.Name = "btnEmails"
        Me.btnEmails.Size = New System.Drawing.Size(83, 55)
        Me.btnEmails.TabIndex = 37
        Me.btnEmails.Text = "Inmueble"
        Me.btnEmails.ToolTip = "Enviar Email con información del inmueble"
        '
        'btnNuevoInmueble
        '
        Me.btnNuevoInmueble.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNuevoInmueble.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnNuevoInmueble.Appearance.BorderColor = System.Drawing.Color.White
        Me.btnNuevoInmueble.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevoInmueble.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnNuevoInmueble.Appearance.Options.UseBackColor = True
        Me.btnNuevoInmueble.Appearance.Options.UseBorderColor = True
        Me.btnNuevoInmueble.Appearance.Options.UseFont = True
        Me.btnNuevoInmueble.Appearance.Options.UseForeColor = True
        Me.btnNuevoInmueble.Appearance.Options.UseTextOptions = True
        Me.btnNuevoInmueble.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnNuevoInmueble.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnNuevoInmueble.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnNuevoInmueble.Image = Global.My.Resources.Resources.NuevoInmueble
        Me.btnNuevoInmueble.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnNuevoInmueble.Location = New System.Drawing.Point(5, 4)
        Me.btnNuevoInmueble.LookAndFeel.SkinName = "Metropolis"
        Me.btnNuevoInmueble.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnNuevoInmueble.Name = "btnNuevoInmueble"
        Me.btnNuevoInmueble.Size = New System.Drawing.Size(105, 55)
        Me.btnNuevoInmueble.TabIndex = 27
        Me.btnNuevoInmueble.Text = "Nuevo Inmueble"
        Me.btnNuevoInmueble.ToolTip = "Añadir inmueble"
        '
        'btnInmuebles
        '
        Me.btnInmuebles.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnInmuebles.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnInmuebles.Appearance.BorderColor = System.Drawing.Color.White
        Me.btnInmuebles.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInmuebles.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnInmuebles.Appearance.Options.UseBackColor = True
        Me.btnInmuebles.Appearance.Options.UseBorderColor = True
        Me.btnInmuebles.Appearance.Options.UseFont = True
        Me.btnInmuebles.Appearance.Options.UseForeColor = True
        Me.btnInmuebles.Appearance.Options.UseTextOptions = True
        Me.btnInmuebles.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnInmuebles.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnInmuebles.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnInmuebles.Image = Global.My.Resources.Resources.Inmuebles32x32
        Me.btnInmuebles.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnInmuebles.Location = New System.Drawing.Point(116, 4)
        Me.btnInmuebles.LookAndFeel.SkinName = "Metropolis"
        Me.btnInmuebles.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnInmuebles.Name = "btnInmuebles"
        Me.btnInmuebles.Size = New System.Drawing.Size(81, 55)
        Me.btnInmuebles.TabIndex = 28
        Me.btnInmuebles.Text = "Inmuebles"
        Me.btnInmuebles.ToolTip = "Ver Inmuebles del propietario seleccionado"
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
        Me.btnSalir.Location = New System.Drawing.Point(1157, 4)
        Me.btnSalir.LookAndFeel.SkinName = "Metropolis"
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(68, 55)
        Me.btnSalir.TabIndex = 36
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
        Me.btnCancelar.Location = New System.Drawing.Point(1083, 4)
        Me.btnCancelar.LookAndFeel.SkinName = "Metropolis"
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(68, 55)
        Me.btnCancelar.TabIndex = 34
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
        Me.btnAceptar.Location = New System.Drawing.Point(1009, 4)
        Me.btnAceptar.LookAndFeel.SkinName = "Metropolis"
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(68, 55)
        Me.btnAceptar.TabIndex = 33
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
        Me.btnModificar.Location = New System.Drawing.Point(935, 4)
        Me.btnModificar.LookAndFeel.SkinName = "Metropolis"
        Me.btnModificar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(68, 55)
        Me.btnModificar.TabIndex = 32
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
        Me.btnEliminar.Location = New System.Drawing.Point(861, 4)
        Me.btnEliminar.LookAndFeel.SkinName = "Metropolis"
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(68, 55)
        Me.btnEliminar.TabIndex = 31
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
        Me.btnAnadir.Location = New System.Drawing.Point(787, 4)
        Me.btnAnadir.LookAndFeel.SkinName = "Metropolis"
        Me.btnAnadir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAnadir.Name = "btnAnadir"
        Me.btnAnadir.Size = New System.Drawing.Size(68, 55)
        Me.btnAnadir.TabIndex = 30
        Me.btnAnadir.Text = "Añadir"
        Me.btnAnadir.ToolTip = "Pulse F1 para añadir"
        '
        'btnAnadirObservaciones
        '
        Me.btnAnadirObservaciones.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAnadirObservaciones.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnAnadirObservaciones.Appearance.BorderColor = System.Drawing.Color.White
        Me.btnAnadirObservaciones.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnadirObservaciones.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnAnadirObservaciones.Appearance.Options.UseBackColor = True
        Me.btnAnadirObservaciones.Appearance.Options.UseBorderColor = True
        Me.btnAnadirObservaciones.Appearance.Options.UseFont = True
        Me.btnAnadirObservaciones.Appearance.Options.UseForeColor = True
        Me.btnAnadirObservaciones.Appearance.Options.UseTextOptions = True
        Me.btnAnadirObservaciones.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnAnadirObservaciones.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnAnadirObservaciones.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnAnadirObservaciones.Image = Global.My.Resources.Resources.Observaciones
        Me.btnAnadirObservaciones.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnAnadirObservaciones.Location = New System.Drawing.Point(152, 4)
        Me.btnAnadirObservaciones.LookAndFeel.SkinName = "Metropolis"
        Me.btnAnadirObservaciones.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAnadirObservaciones.Name = "btnAnadirObservaciones"
        Me.btnAnadirObservaciones.Size = New System.Drawing.Size(97, 55)
        Me.btnAnadirObservaciones.TabIndex = 29
        Me.btnAnadirObservaciones.Text = "Observaciones"
        Me.btnAnadirObservaciones.Visible = False
        '
        'DockManager1
        '
        Me.DockManager1.Form = Me
        Me.DockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.StatusBar", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl"})
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.btnSoloSinInmuebles)
        Me.PanelControl3.Controls.Add(Me.btnNoReservados)
        Me.PanelControl3.Controls.Add(Me.btnSoloConInmuebles)
        Me.PanelControl3.Controls.Add(Me.btnVerTodos)
        Me.PanelControl3.Controls.Add(Me.txtBusquedaEmailTelefono)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(1229, 35)
        Me.PanelControl3.TabIndex = 209
        '
        'btnSoloSinInmuebles
        '
        Me.btnSoloSinInmuebles.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnSoloSinInmuebles.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnSoloSinInmuebles.Appearance.Options.UseBackColor = True
        Me.btnSoloSinInmuebles.Appearance.Options.UseFont = True
        Me.btnSoloSinInmuebles.Appearance.Options.UseForeColor = True
        Me.btnSoloSinInmuebles.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnSoloSinInmuebles.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnSoloSinInmuebles.Location = New System.Drawing.Point(310, 6)
        Me.btnSoloSinInmuebles.LookAndFeel.SkinName = "Metropolis"
        Me.btnSoloSinInmuebles.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSoloSinInmuebles.Name = "btnSoloSinInmuebles"
        Me.btnSoloSinInmuebles.Size = New System.Drawing.Size(139, 23)
        Me.btnSoloSinInmuebles.TabIndex = 102
        Me.btnSoloSinInmuebles.Text = "Sin Inmuebles"
        Me.btnSoloSinInmuebles.ToolTip = "Mostrar solo los propietarios con inmuebles a la venta"
        '
        'btnNoReservados
        '
        Me.btnNoReservados.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnNoReservados.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnNoReservados.Appearance.Options.UseBackColor = True
        Me.btnNoReservados.Appearance.Options.UseFont = True
        Me.btnNoReservados.Appearance.Options.UseForeColor = True
        Me.btnNoReservados.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnNoReservados.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnNoReservados.Location = New System.Drawing.Point(455, 6)
        Me.btnNoReservados.LookAndFeel.SkinName = "Metropolis"
        Me.btnNoReservados.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnNoReservados.Name = "btnNoReservados"
        Me.btnNoReservados.Size = New System.Drawing.Size(153, 23)
        Me.btnNoReservados.TabIndex = 101
        Me.btnNoReservados.Text = "No reservados"
        Me.btnNoReservados.ToolTip = "Mostrar solo los propietarios con inmuebles no reservados"
        '
        'btnSoloConInmuebles
        '
        Me.btnSoloConInmuebles.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnSoloConInmuebles.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnSoloConInmuebles.Appearance.Options.UseBackColor = True
        Me.btnSoloConInmuebles.Appearance.Options.UseFont = True
        Me.btnSoloConInmuebles.Appearance.Options.UseForeColor = True
        Me.btnSoloConInmuebles.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnSoloConInmuebles.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnSoloConInmuebles.Location = New System.Drawing.Point(158, 6)
        Me.btnSoloConInmuebles.LookAndFeel.SkinName = "Metropolis"
        Me.btnSoloConInmuebles.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSoloConInmuebles.Name = "btnSoloConInmuebles"
        Me.btnSoloConInmuebles.Size = New System.Drawing.Size(146, 23)
        Me.btnSoloConInmuebles.TabIndex = 101
        Me.btnSoloConInmuebles.Text = "Solo con Inmuebles"
        Me.btnSoloConInmuebles.ToolTip = "Mostrar solo los propietarios con inmuebles a la venta"
        '
        'btnVerTodos
        '
        Me.btnVerTodos.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnVerTodos.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnVerTodos.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnVerTodos.Appearance.Options.UseBackColor = True
        Me.btnVerTodos.Appearance.Options.UseFont = True
        Me.btnVerTodos.Appearance.Options.UseForeColor = True
        Me.btnVerTodos.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnVerTodos.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnVerTodos.Location = New System.Drawing.Point(7, 6)
        Me.btnVerTodos.LookAndFeel.SkinName = "Metropolis"
        Me.btnVerTodos.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnVerTodos.Name = "btnVerTodos"
        Me.btnVerTodos.Size = New System.Drawing.Size(145, 23)
        Me.btnVerTodos.TabIndex = 37
        Me.btnVerTodos.Text = "Ver Todos"
        Me.btnVerTodos.ToolTip = "Ver Todos los inmuebles"
        '
        'txtBusquedaEmailTelefono
        '
        Me.txtBusquedaEmailTelefono.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBusquedaEmailTelefono.Location = New System.Drawing.Point(951, 6)
        Me.txtBusquedaEmailTelefono.Name = "txtBusquedaEmailTelefono"
        Me.txtBusquedaEmailTelefono.Properties.AllowMouseWheel = False
        Me.txtBusquedaEmailTelefono.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBusquedaEmailTelefono.Properties.Appearance.Options.UseFont = True
        Me.txtBusquedaEmailTelefono.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Tel/Email/Nombre", -1, True, True, True, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.txtBusquedaEmailTelefono.Size = New System.Drawing.Size(270, 22)
        Me.txtBusquedaEmailTelefono.TabIndex = 38
        '
        'dgvxInmuebles
        '
        Me.dgvxInmuebles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvxInmuebles.ColumnaCheck = Nothing
        Me.dgvxInmuebles.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgvxInmuebles.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvxInmuebles.Location = New System.Drawing.Point(5, 258)
        Me.dgvxInmuebles.MainView = Me.GvInmuebles
        Me.dgvxInmuebles.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvxInmuebles.Name = "dgvxInmuebles"
        Me.dgvxInmuebles.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox2})
        Me.dgvxInmuebles.Size = New System.Drawing.Size(1216, 102)
        Me.dgvxInmuebles.TabIndex = 210
        Me.dgvxInmuebles.tb_AnadirColumnaCheck = False
        Me.dgvxInmuebles.tbPerfilPredeterminado = ""
        Me.dgvxInmuebles.ToolTipController = Me.ToolTipController1
        Me.dgvxInmuebles.UseDisabledStatePainter = False
        Me.dgvxInmuebles.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GvInmuebles})
        '
        'GvInmuebles
        '
        Me.GvInmuebles.GridControl = Me.dgvxInmuebles
        Me.GvInmuebles.Name = "GvInmuebles"
        '
        'RepositoryItemComboBox2
        '
        Me.RepositoryItemComboBox2.AutoHeight = False
        Me.RepositoryItemComboBox2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox2.Name = "RepositoryItemComboBox2"
        '
        'UcComunicacionesDetalle1
        '
        Me.UcComunicacionesDetalle1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UcComunicacionesDetalle1.Location = New System.Drawing.Point(549, 392)
        Me.UcComunicacionesDetalle1.Name = "UcComunicacionesDetalle1"
        Me.UcComunicacionesDetalle1.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.UcComunicacionesDetalle1.Size = New System.Drawing.Size(676, 145)
        Me.UcComunicacionesDetalle1.TabIndex = 211
        '
        'LabelControl7
        '
        Me.LabelControl7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelControl7.Location = New System.Drawing.Point(549, 374)
        Me.LabelControl7.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(102, 13)
        Me.LabelControl7.TabIndex = 212
        Me.LabelControl7.Text = "Acciones Comerciales"
        '
        'LabelControl8
        '
        Me.LabelControl8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelControl8.Location = New System.Drawing.Point(5, 228)
        Me.LabelControl8.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(49, 13)
        Me.LabelControl8.TabIndex = 213
        Me.LabelControl8.Text = "Inmuebles"
        '
        'pnlEnviado
        '
        Me.pnlEnviado.Controls.Add(Me.lblxdey)
        Me.pnlEnviado.Controls.Add(Me.lblEnviando)
        Me.pnlEnviado.Location = New System.Drawing.Point(447, 466)
        Me.pnlEnviado.Name = "pnlEnviado"
        Me.pnlEnviado.Size = New System.Drawing.Size(243, 78)
        Me.pnlEnviado.TabIndex = 293
        Me.pnlEnviado.Visible = False
        '
        'lblxdey
        '
        Me.lblxdey.AllowHtmlString = True
        Me.lblxdey.Appearance.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblxdey.Appearance.ForeColor = System.Drawing.Color.Maroon
        Me.lblxdey.Location = New System.Drawing.Point(146, 27)
        Me.lblxdey.Name = "lblxdey"
        Me.lblxdey.Size = New System.Drawing.Size(97, 25)
        Me.lblxdey.TabIndex = 1
        Me.lblxdey.Text = "<b><color=Black><b><color=Black><b><color=Black><b><color=Black><b><color=Black>1" &
    " de 1 </b></color> </b></color> </b></color> </b></color> </b></color>"
        '
        'lblEnviando
        '
        Me.lblEnviando.AllowHtmlString = True
        Me.lblEnviando.Appearance.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblEnviando.Appearance.ForeColor = System.Drawing.Color.Maroon
        Me.lblEnviando.Location = New System.Drawing.Point(15, 27)
        Me.lblEnviando.Name = "lblEnviando"
        Me.lblEnviando.Size = New System.Drawing.Size(130, 25)
        Me.lblEnviando.TabIndex = 0
        Me.lblEnviando.Text = "<b><color=Black><b><color=Black><b><color=Black><b><color=Black><b><color=Black>E" &
    "nviando </b></color> </b></color> </b></color> </b></color> </b></color>"
        '
        'chkBanco
        '
        Me.chkBanco.Enabled = False
        Me.chkBanco.Location = New System.Drawing.Point(1109, 91)
        Me.chkBanco.Name = "chkBanco"
        Me.chkBanco.Properties.Caption = "Banco"
        Me.chkBanco.Properties.ReadOnly = True
        Me.chkBanco.Size = New System.Drawing.Size(102, 19)
        Me.chkBanco.TabIndex = 335
        Me.chkBanco.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkBanco.tbColorSi = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.chkBanco.ToolTip = "Gestiona Inmuebles de banco"
        '
        'ucPropietarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1229, 753)
        Me.Controls.Add(Me.pnlEnviado)
        Me.Controls.Add(Me.LabelControl8)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.UcComunicacionesDetalle1)
        Me.Controls.Add(Me.dgvxInmuebles)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.PanelCajas)
        Me.Controls.Add(Me.PanelBotones)
        Me.Controls.Add(Me.dgvx)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.LabelControl15)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "ucPropietarios"
        CType(Me.dgvx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.Gv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelCajas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelCajas.ResumeLayout(False)
        Me.PanelCajas.PerformLayout()
        CType(Me.chkNoExtranjeros.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkNoQuiereRecibirEmails.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSeguroVivienda.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkNoAnimales.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAvisadoTresPorCien.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkNoInmobiliaria.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAvisadoMensualidad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCuenta.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmail2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTelefono3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTelefono4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mskFechaAlta.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mskFechaAlta.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWeb.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombre.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAlias.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDireccion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPoblacion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodPostal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProvincia.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPais.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTelefono1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTelefono2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTelefonoMovil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNIF.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtObservaciones.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBotones.ResumeLayout(False)
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.txtBusquedaEmailTelefono.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvxInmuebles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GvInmuebles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlEnviado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEnviado.ResumeLayout(False)
        Me.pnlEnviado.PerformLayout()
        CType(Me.chkBanco.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents btnCancelar As uc_tb_SimpleButton

    Friend WithEvents txtObservaciones As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents txtNIF As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ToolTipController1 As DevExpress.Utils.ToolTipController
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents HoldfToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

    Friend WithEvents btnSalir As uc_tb_SimpleButton
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
    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtWeb As DevExpress.XtraEditors.TextEdit
    Friend WithEvents mskFechaAlta As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnInmuebles As uc_tb_SimpleButton
    Friend WithEvents chkNoQuiereRecibirEmails As uc_tb_CheckBoxRojoNegro
    Friend WithEvents btnAnadirObservaciones As uc_tb_SimpleButton
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtBusquedaEmailTelefono As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtCuenta As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtEmail2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtTelefono3 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTelefono4 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents chkAvisadoTresPorCien As uc_tb_CheckBoxRojoNegro
    Friend WithEvents chkNoInmobiliaria As uc_tb_CheckBoxRojoNegro
    Friend WithEvents chkAvisadoMensualidad As uc_tb_CheckBoxRojoNegro
    Friend WithEvents btnNuevoInmueble As uc_tb_SimpleButton
    Friend WithEvents btnVerTodos As uc_tb_SimpleButton
    Friend WithEvents chkNoAnimales As uc_tb_CheckBoxRojoNegro
    Friend WithEvents chkNoExtranjeros As uc_tb_CheckBoxRojoNegro
    Friend WithEvents chkSeguroVivienda As uc_tb_CheckBoxRojoNegro
    Friend WithEvents dgvxInmuebles As MyGridControl
    Friend WithEvents GvInmuebles As MyGridView
    Friend WithEvents RepositoryItemComboBox2 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents UcComunicacionesDetalle1 As Venalia.ucComunicacionesDetalle
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnEmails As uc_tb_SimpleButton
    Friend WithEvents pnlEnviado As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblxdey As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblEnviando As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnSoloConInmuebles As uc_tb_SimpleButton
    Friend WithEvents btnNoReservados As uc_tb_SimpleButton
    Friend WithEvents btnSoloSinInmuebles As uc_tb_SimpleButton
    Friend WithEvents btnEmailInformativo As uc_tb_SimpleButton
    Friend WithEvents chkBanco As uc_tb_CheckBoxRojoNegro
End Class
