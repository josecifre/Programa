<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucMensajeEmail
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PanelBotones = New DevExpress.XtraEditors.PanelControl()
        Me.cmbTextosEnvios = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.txtMensaje = New DevExpress.XtraEditors.MemoEdit()
        Me.lblTipo = New DevExpress.XtraEditors.LabelControl()
        Me.txtTitulo = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtAsunto = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtAdjunto = New DevExpress.XtraEditors.LabelControl()
        Me.cmbTipo = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.txtContador = New DevExpress.XtraEditors.TextEdit()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.txtTipoEmail = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.chkIncluirDireccion = New uc_tb_CheckBoxRojoNegro()
        Me.chkIncluirTextoFotos = New uc_tb_CheckBoxRojoNegro()
        Me.chkIncluirFichaInmueble = New uc_tb_CheckBoxRojoNegro()
        Me.chkAvisoLegal = New uc_tb_CheckBoxRojoNegro()
        Me.btnAdjuntar = New uc_tb_SimpleButton()
        Me.chkInfoEmpresa = New uc_tb_CheckBoxRojoNegro()
        Me.chkInfoInmueble = New uc_tb_CheckBoxRojoNegro()
        Me.btnEliminar = New uc_tb_SimpleButton()
        Me.btnPredeterminar = New uc_tb_SimpleButton()
        Me.btnGuardar = New uc_tb_SimpleButton()
        Me.btnAceptar = New uc_tb_SimpleButton()
        Me.btnSalir = New uc_tb_SimpleButton()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBotones.SuspendLayout()
        CType(Me.cmbTextosEnvios.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMensaje.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTitulo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAsunto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContador.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.txtTipoEmail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkIncluirDireccion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkIncluirTextoFotos.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkIncluirFichaInmueble.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAvisoLegal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkInfoEmpresa.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkInfoInmueble.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelBotones
        '
        Me.PanelBotones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelBotones.Controls.Add(Me.btnEliminar)
        Me.PanelBotones.Controls.Add(Me.cmbTextosEnvios)
        Me.PanelBotones.Controls.Add(Me.btnPredeterminar)
        Me.PanelBotones.Controls.Add(Me.LabelControl14)
        Me.PanelBotones.Controls.Add(Me.btnGuardar)
        Me.PanelBotones.Controls.Add(Me.btnAceptar)
        Me.PanelBotones.Controls.Add(Me.btnSalir)
        Me.PanelBotones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBotones.Location = New System.Drawing.Point(0, 339)
        Me.PanelBotones.Name = "PanelBotones"
        Me.PanelBotones.Size = New System.Drawing.Size(716, 65)
        Me.PanelBotones.TabIndex = 126
        '
        'cmbTextosEnvios
        '
        Me.cmbTextosEnvios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTextosEnvios.EnterMoveNextControl = True
        Me.cmbTextosEnvios.Location = New System.Drawing.Point(4, 32)
        Me.cmbTextosEnvios.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.cmbTextosEnvios.Name = "cmbTextosEnvios"
        Me.cmbTextosEnvios.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White
        Me.cmbTextosEnvios.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.cmbTextosEnvios.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cmbTextosEnvios.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.cmbTextosEnvios.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cmbTextosEnvios.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbTextosEnvios.Properties.View = Me.GridView1
        Me.cmbTextosEnvios.Size = New System.Drawing.Size(317, 20)
        Me.cmbTextosEnvios.TabIndex = 9
        '
        'GridView1
        '
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'LabelControl14
        '
        Me.LabelControl14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelControl14.Location = New System.Drawing.Point(12, 13)
        Me.LabelControl14.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(79, 13)
        Me.LabelControl14.TabIndex = 229
        Me.LabelControl14.Text = "Textos definidos"
        '
        'txtMensaje
        '
        Me.txtMensaje.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMensaje.Location = New System.Drawing.Point(5, 157)
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.Size = New System.Drawing.Size(701, 176)
        Me.txtMensaje.TabIndex = 2
        '
        'lblTipo
        '
        Me.lblTipo.Location = New System.Drawing.Point(7, 75)
        Me.lblTipo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(20, 13)
        Me.lblTipo.TabIndex = 180
        Me.lblTipo.Text = "Tipo"
        Me.lblTipo.Visible = False
        '
        'txtTitulo
        '
        Me.txtTitulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTitulo.EnterMoveNextControl = True
        Me.txtTitulo.Location = New System.Drawing.Point(436, 69)
        Me.txtTitulo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTitulo.Name = "txtTitulo"
        Me.txtTitulo.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTitulo.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtTitulo.Size = New System.Drawing.Size(12, 20)
        Me.txtTitulo.TabIndex = 179
        Me.txtTitulo.Visible = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(6, 80)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl1.TabIndex = 182
        Me.LabelControl1.Text = "Asunto"
        '
        'txtAsunto
        '
        Me.txtAsunto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAsunto.EnterMoveNextControl = True
        Me.txtAsunto.Location = New System.Drawing.Point(6, 98)
        Me.txtAsunto.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAsunto.Name = "txtAsunto"
        Me.txtAsunto.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtAsunto.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtAsunto.Size = New System.Drawing.Size(454, 20)
        Me.txtAsunto.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(5, 131)
        Me.LabelControl2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(40, 13)
        Me.LabelControl2.TabIndex = 183
        Me.LabelControl2.Text = "Mensaje"
        '
        'txtAdjunto
        '
        Me.txtAdjunto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAdjunto.Location = New System.Drawing.Point(353, 135)
        Me.txtAdjunto.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAdjunto.Name = "txtAdjunto"
        Me.txtAdjunto.Size = New System.Drawing.Size(54, 13)
        Me.txtAdjunto.TabIndex = 232
        Me.txtAdjunto.Text = "Adjuntar..."
        Me.txtAdjunto.Visible = False
        '
        'cmbTipo
        '
        Me.cmbTipo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTipo.EnterMoveNextControl = True
        Me.cmbTipo.Location = New System.Drawing.Point(6, 72)
        Me.cmbTipo.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White
        Me.cmbTipo.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.cmbTipo.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cmbTipo.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.cmbTipo.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cmbTipo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbTipo.Properties.View = Me.GridView2
        Me.cmbTipo.Size = New System.Drawing.Size(454, 20)
        Me.cmbTipo.TabIndex = 2
        Me.cmbTipo.Visible = False
        '
        'GridView2
        '
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'txtContador
        '
        Me.txtContador.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtContador.EnterMoveNextControl = True
        Me.txtContador.Location = New System.Drawing.Point(436, 68)
        Me.txtContador.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtContador.Name = "txtContador"
        Me.txtContador.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtContador.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtContador.Size = New System.Drawing.Size(12, 20)
        Me.txtContador.TabIndex = 235
        Me.txtContador.Visible = False
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelControl1.Controls.Add(Me.txtTipoEmail)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.chkIncluirDireccion)
        Me.PanelControl1.Controls.Add(Me.chkIncluirTextoFotos)
        Me.PanelControl1.Controls.Add(Me.txtMensaje)
        Me.PanelControl1.Controls.Add(Me.chkIncluirFichaInmueble)
        Me.PanelControl1.Controls.Add(Me.txtAsunto)
        Me.PanelControl1.Controls.Add(Me.cmbTipo)
        Me.PanelControl1.Controls.Add(Me.txtContador)
        Me.PanelControl1.Controls.Add(Me.chkAvisoLegal)
        Me.PanelControl1.Controls.Add(Me.txtTitulo)
        Me.PanelControl1.Controls.Add(Me.txtAdjunto)
        Me.PanelControl1.Controls.Add(Me.lblTipo)
        Me.PanelControl1.Controls.Add(Me.btnAdjuntar)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.chkInfoEmpresa)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.chkInfoInmueble)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(716, 339)
        Me.PanelControl1.TabIndex = 0
        '
        'txtTipoEmail
        '
        Me.txtTipoEmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTipoEmail.EnterMoveNextControl = True
        Me.txtTipoEmail.Location = New System.Drawing.Point(6, 44)
        Me.txtTipoEmail.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTipoEmail.Name = "txtTipoEmail"
        Me.txtTipoEmail.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTipoEmail.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtTipoEmail.Size = New System.Drawing.Size(454, 20)
        Me.txtTipoEmail.TabIndex = 0
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(6, 27)
        Me.LabelControl3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(346, 13)
        Me.LabelControl3.TabIndex = 239
        Me.LabelControl3.Text = "Tipo Email (Dato interno para clasificar los emails. Este dato no se envía)"
        '
        'chkIncluirDireccion
        '
        Me.chkIncluirDireccion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkIncluirDireccion.EditValue = True
        Me.chkIncluirDireccion.Location = New System.Drawing.Point(466, 132)
        Me.chkIncluirDireccion.Name = "chkIncluirDireccion"
        Me.chkIncluirDireccion.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.chkIncluirDireccion.Properties.Appearance.Options.UseForeColor = True
        Me.chkIncluirDireccion.Properties.Caption = "Incluir Dirección"
        Me.chkIncluirDireccion.Properties.ReadOnly = True
        Me.chkIncluirDireccion.Size = New System.Drawing.Size(240, 19)
        Me.chkIncluirDireccion.TabIndex = 237
        Me.chkIncluirDireccion.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkIncluirDireccion.tbColorSi = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        '
        'chkIncluirTextoFotos
        '
        Me.chkIncluirTextoFotos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkIncluirTextoFotos.Location = New System.Drawing.Point(466, 111)
        Me.chkIncluirTextoFotos.Name = "chkIncluirTextoFotos"
        Me.chkIncluirTextoFotos.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkIncluirTextoFotos.Properties.Appearance.Options.UseForeColor = True
        Me.chkIncluirTextoFotos.Properties.Caption = "Incluir Texto Faltan Fotos"
        Me.chkIncluirTextoFotos.Properties.ReadOnly = True
        Me.chkIncluirTextoFotos.Size = New System.Drawing.Size(240, 19)
        Me.chkIncluirTextoFotos.TabIndex = 236
        Me.chkIncluirTextoFotos.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkIncluirTextoFotos.tbColorSi = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        '
        'chkIncluirFichaInmueble
        '
        Me.chkIncluirFichaInmueble.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkIncluirFichaInmueble.EditValue = True
        Me.chkIncluirFichaInmueble.Location = New System.Drawing.Point(466, 90)
        Me.chkIncluirFichaInmueble.Name = "chkIncluirFichaInmueble"
        Me.chkIncluirFichaInmueble.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.chkIncluirFichaInmueble.Properties.Appearance.Options.UseForeColor = True
        Me.chkIncluirFichaInmueble.Properties.Caption = "Incluir Ficha Inmueble"
        Me.chkIncluirFichaInmueble.Properties.ReadOnly = True
        Me.chkIncluirFichaInmueble.Size = New System.Drawing.Size(240, 19)
        Me.chkIncluirFichaInmueble.TabIndex = 6
        Me.chkIncluirFichaInmueble.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkIncluirFichaInmueble.tbColorSi = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        '
        'chkAvisoLegal
        '
        Me.chkAvisoLegal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkAvisoLegal.EditValue = True
        Me.chkAvisoLegal.Location = New System.Drawing.Point(466, 69)
        Me.chkAvisoLegal.Name = "chkAvisoLegal"
        Me.chkAvisoLegal.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.chkAvisoLegal.Properties.Appearance.Options.UseForeColor = True
        Me.chkAvisoLegal.Properties.Caption = "Incluir aviso legal"
        Me.chkAvisoLegal.Properties.ReadOnly = True
        Me.chkAvisoLegal.Size = New System.Drawing.Size(240, 19)
        Me.chkAvisoLegal.TabIndex = 5
        Me.chkAvisoLegal.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkAvisoLegal.tbColorSi = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        '
        'btnAdjuntar
        '
        Me.btnAdjuntar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdjuntar.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnAdjuntar.Appearance.Options.UseBackColor = True
        Me.btnAdjuntar.Appearance.Options.UseTextOptions = True
        Me.btnAdjuntar.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnAdjuntar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.btnAdjuntar.Image = Global.My.Resources.Resources.Open_16x16
        Me.btnAdjuntar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnAdjuntar.Location = New System.Drawing.Point(322, 131)
        Me.btnAdjuntar.LookAndFeel.SkinName = "Metropolis"
        Me.btnAdjuntar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnAdjuntar.Name = "btnAdjuntar"
        Me.btnAdjuntar.Size = New System.Drawing.Size(19, 17)
        Me.btnAdjuntar.TabIndex = 7
        Me.btnAdjuntar.Text = "Añadir"
        Me.btnAdjuntar.ToolTip = "Pulse F1 para añadir"
        Me.btnAdjuntar.Visible = False
        '
        'chkInfoEmpresa
        '
        Me.chkInfoEmpresa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkInfoEmpresa.EditValue = True
        Me.chkInfoEmpresa.Location = New System.Drawing.Point(466, 48)
        Me.chkInfoEmpresa.Name = "chkInfoEmpresa"
        Me.chkInfoEmpresa.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.chkInfoEmpresa.Properties.Appearance.Options.UseForeColor = True
        Me.chkInfoEmpresa.Properties.Caption = "Incluir información de la empresa"
        Me.chkInfoEmpresa.Properties.ReadOnly = True
        Me.chkInfoEmpresa.Size = New System.Drawing.Size(240, 19)
        Me.chkInfoEmpresa.TabIndex = 4
        Me.chkInfoEmpresa.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkInfoEmpresa.tbColorSi = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        '
        'chkInfoInmueble
        '
        Me.chkInfoInmueble.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkInfoInmueble.EditValue = True
        Me.chkInfoInmueble.Location = New System.Drawing.Point(466, 28)
        Me.chkInfoInmueble.Name = "chkInfoInmueble"
        Me.chkInfoInmueble.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.chkInfoInmueble.Properties.Appearance.Options.UseForeColor = True
        Me.chkInfoInmueble.Properties.Caption = "Incluir información del inmueble"
        Me.chkInfoInmueble.Properties.ReadOnly = True
        Me.chkInfoInmueble.Size = New System.Drawing.Size(240, 19)
        Me.chkInfoInmueble.TabIndex = 3
        Me.chkInfoInmueble.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkInfoInmueble.tbColorSi = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.Appearance.Options.UseBackColor = True
        Me.btnEliminar.Appearance.Options.UseTextOptions = True
        Me.btnEliminar.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnEliminar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Image = Global.My.Resources.Resources.Eliminar1
        Me.btnEliminar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnEliminar.Location = New System.Drawing.Point(495, 5)
        Me.btnEliminar.LookAndFeel.SkinName = "Metropolis"
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(68, 55)
        Me.btnEliminar.TabIndex = 12
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.Visible = False
        '
        'btnPredeterminar
        '
        Me.btnPredeterminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPredeterminar.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnPredeterminar.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnPredeterminar.Appearance.Options.UseBackColor = True
        Me.btnPredeterminar.Appearance.Options.UseForeColor = True
        Me.btnPredeterminar.Appearance.Options.UseTextOptions = True
        Me.btnPredeterminar.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnPredeterminar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnPredeterminar.Image = Global.My.Resources.Resources.Predeterminar
        Me.btnPredeterminar.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnPredeterminar.Location = New System.Drawing.Point(353, 5)
        Me.btnPredeterminar.LookAndFeel.SkinName = "Metropolis"
        Me.btnPredeterminar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPredeterminar.Name = "btnPredeterminar"
        Me.btnPredeterminar.Size = New System.Drawing.Size(65, 55)
        Me.btnPredeterminar.TabIndex = 10
        Me.btnPredeterminar.Text = "Predet."
        Me.btnPredeterminar.ToolTip = "Establecer predeterminado"
        Me.btnPredeterminar.Visible = False
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnGuardar.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnGuardar.Appearance.Options.UseBackColor = True
        Me.btnGuardar.Appearance.Options.UseForeColor = True
        Me.btnGuardar.Appearance.Options.UseTextOptions = True
        Me.btnGuardar.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnGuardar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnGuardar.Image = Global.My.Resources.Resources.Save_32x32
        Me.btnGuardar.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(424, 5)
        Me.btnGuardar.LookAndFeel.SkinName = "Metropolis"
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(65, 55)
        Me.btnGuardar.TabIndex = 11
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.ToolTip = "Guardar Configuración"
        Me.btnGuardar.Visible = False
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnAceptar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnAceptar.Appearance.Options.UseBackColor = True
        Me.btnAceptar.Appearance.Options.UseForeColor = True
        Me.btnAceptar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnAceptar.Image = Global.My.Resources.Resources.EmailBoton
        Me.btnAceptar.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnAceptar.Location = New System.Drawing.Point(569, 5)
        Me.btnAceptar.LookAndFeel.SkinName = "Metropolis"
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(68, 55)
        Me.btnAceptar.TabIndex = 13
        Me.btnAceptar.Text = "Enviar"
        Me.btnAceptar.ToolTip = "Enviar"
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
        Me.btnSalir.Location = New System.Drawing.Point(643, 5)
        Me.btnSalir.LookAndFeel.SkinName = "Metropolis"
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(68, 55)
        Me.btnSalir.TabIndex = 14
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.ToolTip = "Cancelar"
        '
        'ucMensajeEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PanelBotones)
        Me.Name = "ucMensajeEmail"
        Me.Size = New System.Drawing.Size(716, 404)
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBotones.ResumeLayout(False)
        Me.PanelBotones.PerformLayout()
        CType(Me.cmbTextosEnvios.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMensaje.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTitulo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAsunto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContador.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.txtTipoEmail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkIncluirDireccion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkIncluirTextoFotos.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkIncluirFichaInmueble.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAvisoLegal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkInfoEmpresa.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkInfoInmueble.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSalir As uc_tb_SimpleButton
    Friend WithEvents btnAceptar As uc_tb_SimpleButton
    Friend WithEvents PanelBotones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtMensaje As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents lblTipo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtTitulo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtAsunto As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnGuardar As uc_tb_SimpleButton
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkInfoInmueble As uc_tb_CheckBoxRojoNegro
    Friend WithEvents chkInfoEmpresa As uc_tb_CheckBoxRojoNegro
    Friend WithEvents btnAdjuntar As uc_tb_SimpleButton
    Friend WithEvents txtAdjunto As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnPredeterminar As uc_tb_SimpleButton
    Friend WithEvents chkAvisoLegal As uc_tb_CheckBoxRojoNegro
    Friend WithEvents cmbTextosEnvios As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cmbTipo As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnEliminar As uc_tb_SimpleButton
    Friend WithEvents txtContador As DevExpress.XtraEditors.TextEdit
    Friend WithEvents chkIncluirFichaInmueble As uc_tb_CheckBoxRojoNegro
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents chkIncluirDireccion As uc_tb_CheckBoxRojoNegro
    Friend WithEvents chkIncluirTextoFotos As uc_tb_CheckBoxRojoNegro
    Friend WithEvents txtTipoEmail As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
End Class
