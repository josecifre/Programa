Imports Microsoft.VisualBasic
Imports System

Partial Public Class ucTextosEnvios


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
        Me.dgvx = New MyGridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.HoldfToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Gv = New MyGridView()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.ToolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
        Me.PanelCajas = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.chkIncluirAvisoLegal = New uc_tb_CheckBoxRojoNegro()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbDocumento = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.txtAsunto = New DevExpress.XtraEditors.TextEdit()
        Me.txtTexto = New DevExpress.XtraEditors.MemoEdit()
        Me.txtCodigoEmpresa = New DevExpress.XtraEditors.TextEdit()
        Me.txtTituloInforme = New DevExpress.XtraEditors.MemoEdit()
        Me.chkIncluirFichaInmueble = New uc_tb_CheckBoxRojoNegro()
        Me.chkIncluirDatosEmpresa = New uc_tb_CheckBoxRojoNegro()
        Me.chkLlevaTitulo = New uc_tb_CheckBoxRojoNegro()
        Me.PanelBotones = New DevExpress.XtraEditors.PanelControl()
        Me.btnSalir = New uc_tb_SimpleButton()
        Me.btnCancelar = New uc_tb_SimpleButton()
        Me.btnAceptar = New uc_tb_SimpleButton()
        Me.btnModificar = New uc_tb_SimpleButton()
        Me.btnEliminar = New uc_tb_SimpleButton()
        Me.btnAnadir = New uc_tb_SimpleButton()
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        CType(Me.dgvx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.Gv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelCajas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelCajas.SuspendLayout()
        CType(Me.chkIncluirAvisoLegal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbDocumento.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAsunto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTexto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigoEmpresa.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTituloInforme.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkIncluirFichaInmueble.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkIncluirDatosEmpresa.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkLlevaTitulo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBotones.SuspendLayout()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvx
        '
        Me.dgvx.ColumnaCheck = Nothing
        Me.dgvx.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgvx.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvx.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvx.Location = New System.Drawing.Point(0, 0)
        Me.dgvx.MainView = Me.Gv
        Me.dgvx.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvx.Name = "dgvx"
        Me.dgvx.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1})
        Me.dgvx.Size = New System.Drawing.Size(839, 83)
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
        Me.PanelCajas.Controls.Add(Me.LabelControl1)
        Me.PanelCajas.Controls.Add(Me.LabelControl4)
        Me.PanelCajas.Controls.Add(Me.LabelControl15)
        Me.PanelCajas.Controls.Add(Me.LabelControl12)
        Me.PanelCajas.Controls.Add(Me.cmbDocumento)
        Me.PanelCajas.Controls.Add(Me.txtAsunto)
        Me.PanelCajas.Controls.Add(Me.txtTexto)
        Me.PanelCajas.Controls.Add(Me.txtCodigoEmpresa)
        Me.PanelCajas.Controls.Add(Me.txtTituloInforme)
        Me.PanelCajas.Controls.Add(Me.chkIncluirFichaInmueble)
        Me.PanelCajas.Controls.Add(Me.chkIncluirDatosEmpresa)
        Me.PanelCajas.Controls.Add(Me.chkLlevaTitulo)
        Me.PanelCajas.Controls.Add(Me.chkIncluirAvisoLegal)
        Me.PanelCajas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelCajas.Location = New System.Drawing.Point(0, 83)
        Me.PanelCajas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PanelCajas.Name = "PanelCajas"
        Me.PanelCajas.Size = New System.Drawing.Size(839, 265)
        Me.PanelCajas.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.AllowHtmlString = True
        Me.LabelControl1.Location = New System.Drawing.Point(5, 178)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(67, 13)
        Me.LabelControl1.TabIndex = 200
        Me.LabelControl1.Text = "Título Informe"
        '
        'chkIncluirAvisoLegal
        '
        Me.chkIncluirAvisoLegal.Location = New System.Drawing.Point(219, 111)
        Me.chkIncluirAvisoLegal.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkIncluirAvisoLegal.Name = "chkIncluirAvisoLegal"
        Me.chkIncluirAvisoLegal.Properties.Caption = "Incluir Aviso Legal"
        Me.chkIncluirAvisoLegal.Properties.ReadOnly = True
        Me.chkIncluirAvisoLegal.Size = New System.Drawing.Size(170, 19)
        Me.chkIncluirAvisoLegal.TabIndex = 4
        Me.chkIncluirAvisoLegal.TabStop = False
        Me.chkIncluirAvisoLegal.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkIncluirAvisoLegal.tbColorSi = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.chkIncluirAvisoLegal.ToolTip = "Indique si quiere incluir el texto LOPD"
        '
        'LabelControl4
        '
        Me.LabelControl4.AllowHtmlString = True
        Me.LabelControl4.Location = New System.Drawing.Point(5, 6)
        Me.LabelControl4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(54, 13)
        Me.LabelControl4.TabIndex = 196
        Me.LabelControl4.Text = "Documento"
        '
        'LabelControl15
        '
        Me.LabelControl15.AllowHtmlString = True
        Me.LabelControl15.Location = New System.Drawing.Point(5, 67)
        Me.LabelControl15.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(55, 13)
        Me.LabelControl15.TabIndex = 181
        Me.LabelControl15.Text = "Texto Email"
        '
        'LabelControl12
        '
        Me.LabelControl12.AllowHtmlString = True
        Me.LabelControl12.Location = New System.Drawing.Point(221, 6)
        Me.LabelControl12.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl12.TabIndex = 178
        Me.LabelControl12.Text = "Asunto"
        '
        'cmbDocumento
        '
        Me.cmbDocumento.EnterMoveNextControl = True
        Me.cmbDocumento.Location = New System.Drawing.Point(5, 26)
        Me.cmbDocumento.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbDocumento.Name = "cmbDocumento"
        Me.cmbDocumento.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmbDocumento.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.cmbDocumento.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cmbDocumento.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbDocumento.Properties.View = Me.GridView3
        Me.cmbDocumento.Size = New System.Drawing.Size(199, 20)
        Me.cmbDocumento.TabIndex = 1
        '
        'GridView3
        '
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'txtAsunto
        '
        Me.txtAsunto.EnterMoveNextControl = True
        Me.txtAsunto.Location = New System.Drawing.Point(221, 26)
        Me.txtAsunto.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAsunto.Name = "txtAsunto"
        Me.txtAsunto.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtAsunto.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtAsunto.Size = New System.Drawing.Size(613, 20)
        Me.txtAsunto.TabIndex = 2
        '
        'txtTexto
        '
        Me.txtTexto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTexto.Location = New System.Drawing.Point(5, 93)
        Me.txtTexto.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTexto.Name = "txtTexto"
        Me.txtTexto.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTexto.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtTexto.Size = New System.Drawing.Size(829, 76)
        Me.txtTexto.TabIndex = 6
        '
        'txtCodigoEmpresa
        '
        Me.txtCodigoEmpresa.EnterMoveNextControl = True
        Me.txtCodigoEmpresa.Location = New System.Drawing.Point(210, 96)
        Me.txtCodigoEmpresa.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCodigoEmpresa.Name = "txtCodigoEmpresa"
        Me.txtCodigoEmpresa.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 6.0!)
        Me.txtCodigoEmpresa.Properties.Appearance.Options.UseFont = True
        Me.txtCodigoEmpresa.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCodigoEmpresa.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtCodigoEmpresa.Size = New System.Drawing.Size(10, 16)
        Me.txtCodigoEmpresa.TabIndex = 0
        '
        'txtTituloInforme
        '
        Me.txtTituloInforme.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTituloInforme.Location = New System.Drawing.Point(5, 200)
        Me.txtTituloInforme.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTituloInforme.Name = "txtTituloInforme"
        Me.txtTituloInforme.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTituloInforme.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtTituloInforme.Size = New System.Drawing.Size(829, 56)
        Me.txtTituloInforme.TabIndex = 7
        '
        'chkIncluirFichaInmueble
        '
        Me.chkIncluirFichaInmueble.Location = New System.Drawing.Point(569, 111)
        Me.chkIncluirFichaInmueble.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkIncluirFichaInmueble.Name = "chkIncluirFichaInmueble"
        Me.chkIncluirFichaInmueble.Properties.Caption = "Incluir Ficha Inmueble"
        Me.chkIncluirFichaInmueble.Properties.ReadOnly = True
        Me.chkIncluirFichaInmueble.Size = New System.Drawing.Size(191, 19)
        Me.chkIncluirFichaInmueble.TabIndex = 5
        Me.chkIncluirFichaInmueble.TabStop = False
        Me.chkIncluirFichaInmueble.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkIncluirFichaInmueble.tbColorSi = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.chkIncluirFichaInmueble.ToolTip = "Indique si quiere incluir la Ficha del inmueble"
        '
        'chkIncluirDatosEmpresa
        '
        Me.chkIncluirDatosEmpresa.Location = New System.Drawing.Point(371, 111)
        Me.chkIncluirDatosEmpresa.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkIncluirDatosEmpresa.Name = "chkIncluirDatosEmpresa"
        Me.chkIncluirDatosEmpresa.Properties.Caption = "IncluirDatosEmpresa"
        Me.chkIncluirDatosEmpresa.Properties.ReadOnly = True
        Me.chkIncluirDatosEmpresa.Size = New System.Drawing.Size(167, 19)
        Me.chkIncluirDatosEmpresa.TabIndex = 3
        Me.chkIncluirDatosEmpresa.TabStop = False
        Me.chkIncluirDatosEmpresa.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkIncluirDatosEmpresa.tbColorSi = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.chkIncluirDatosEmpresa.ToolTip = "Indique si quiere incluir los datos de la empresa en el texto"
        '
        'chkLlevaTitulo
        '
        Me.chkLlevaTitulo.Location = New System.Drawing.Point(208, 199)
        Me.chkLlevaTitulo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkLlevaTitulo.Name = "chkLlevaTitulo"
        Me.chkLlevaTitulo.Properties.Caption = "Lleva titulo"
        Me.chkLlevaTitulo.Properties.ReadOnly = True
        Me.chkLlevaTitulo.Size = New System.Drawing.Size(123, 19)
        Me.chkLlevaTitulo.TabIndex = 201
        Me.chkLlevaTitulo.TabStop = False
        Me.chkLlevaTitulo.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkLlevaTitulo.tbColorSi = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.chkLlevaTitulo.ToolTip = "Indique si quiere incluir el texto LOPD"
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
        Me.PanelBotones.Location = New System.Drawing.Point(0, 348)
        Me.PanelBotones.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PanelBotones.Name = "PanelBotones"
        Me.PanelBotones.Size = New System.Drawing.Size(839, 64)
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
        Me.btnSalir.Location = New System.Drawing.Point(766, 5)
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
        Me.btnCancelar.Location = New System.Drawing.Point(692, 5)
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
        Me.btnAceptar.Location = New System.Drawing.Point(618, 5)
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
        Me.btnModificar.Location = New System.Drawing.Point(544, 5)
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
        Me.btnEliminar.Location = New System.Drawing.Point(470, 5)
        Me.btnEliminar.LookAndFeel.SkinName = "Metropolis"
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(68, 55)
        Me.btnEliminar.TabIndex = 1
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.Visible = False
        '
        'btnAnadir
        '
        Me.btnAnadir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAnadir.Appearance.Options.UseBackColor = True
        Me.btnAnadir.Appearance.Options.UseTextOptions = True
        Me.btnAnadir.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnAnadir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnAnadir.Image = Global.My.Resources.Resources.Add_New
        Me.btnAnadir.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnAnadir.Location = New System.Drawing.Point(396, 5)
        Me.btnAnadir.LookAndFeel.SkinName = "Metropolis"
        Me.btnAnadir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAnadir.Name = "btnAnadir"
        Me.btnAnadir.Size = New System.Drawing.Size(68, 55)
        Me.btnAnadir.TabIndex = 0
        Me.btnAnadir.Text = "Añadir"
        Me.btnAnadir.ToolTip = "Pulse F1 para añadir"
        Me.btnAnadir.Visible = False
        '
        'DockManager1
        '
        Me.DockManager1.Form = Me
        Me.DockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.StatusBar", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl"})
        '
        'ucTextosEnvios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.dgvx)
        Me.Controls.Add(Me.PanelCajas)
        Me.Controls.Add(Me.PanelBotones)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "ucTextosEnvios"
        Me.Size = New System.Drawing.Size(839, 412)
        CType(Me.dgvx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.Gv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelCajas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelCajas.ResumeLayout(False)
        Me.PanelCajas.PerformLayout()
        CType(Me.chkIncluirAvisoLegal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbDocumento.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAsunto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTexto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodigoEmpresa.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTituloInforme.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkIncluirFichaInmueble.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkIncluirDatosEmpresa.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkLlevaTitulo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBotones.ResumeLayout(False)
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvx As MyGridControl
    Friend WithEvents Gv As MyGridView
    Friend WithEvents PanelBotones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnAceptar As uc_tb_SimpleButton
    Friend WithEvents btnModificar As uc_tb_SimpleButton
    Friend WithEvents btnEliminar As uc_tb_SimpleButton
    Friend WithEvents btnAnadir As uc_tb_SimpleButton

    Friend WithEvents PanelCajas As DevExpress.XtraEditors.PanelControl

    Friend WithEvents txtAsunto As DevExpress.XtraEditors.TextEdit
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents btnCancelar As uc_tb_SimpleButton

    Friend WithEvents txtTexto As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents TabPageContactosComerciales As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TabPageDocumentos As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents ToolTipController1 As DevExpress.Utils.ToolTipController
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents HoldfToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents btnSalir As uc_tb_SimpleButton
    Friend WithEvents cmbDocumento As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents txtCodigoEmpresa As DevExpress.XtraEditors.TextEdit
    Friend WithEvents chkIncluirAvisoLegal As uc_tb_CheckBoxRojoNegro
    Friend WithEvents chkIncluirDatosEmpresa As uc_tb_CheckBoxRojoNegro
    Friend WithEvents chkLlevaTitulo As uc_tb_CheckBoxRojoNegro
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtTituloInforme As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents chkIncluirFichaInmueble As uc_tb_CheckBoxRojoNegro

End Class
