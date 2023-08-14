
Imports Microsoft.VisualBasic
Imports System

Partial Public Class ucEstado

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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.dgvx = New MyGridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.HoldfToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Gv = New MyGridView()
        Me.ToolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
        Me.PanelBotones = New DevExpress.XtraEditors.PanelControl()
        Me.btnSalir = New uc_tb_SimpleButton()
        Me.btnCancelar = New uc_tb_SimpleButton()
        Me.btnAceptar = New uc_tb_SimpleButton()
        Me.btnModificar = New uc_tb_SimpleButton()
        Me.btnEliminar = New uc_tb_SimpleButton()
        Me.btnAnadir = New uc_tb_SimpleButton()
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.txtEstado = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelCajas = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbClasificacionWeb = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtListadoRevista = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtListado = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtTipPrioridad = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtPrioridad = New DevExpress.XtraEditors.TextEdit()
        CType(Me.dgvx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.Gv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBotones.SuspendLayout()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEstado.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelCajas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelCajas.SuspendLayout()
        CType(Me.cmbClasificacionWeb.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtListadoRevista.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtListado.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTipPrioridad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPrioridad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.dgvx.Location = New System.Drawing.Point(0, 2)
        Me.dgvx.MainView = Me.Gv
        Me.dgvx.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvx.Name = "dgvx"
        Me.dgvx.Size = New System.Drawing.Size(1245, 676)
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
        Me.PanelBotones.Location = New System.Drawing.Point(0, 736)
        Me.PanelBotones.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PanelBotones.Name = "PanelBotones"
        Me.PanelBotones.Size = New System.Drawing.Size(1245, 64)
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
        Me.btnSalir.Location = New System.Drawing.Point(1172, 5)
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
        Me.btnCancelar.Location = New System.Drawing.Point(1098, 5)
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
        Me.btnAceptar.Location = New System.Drawing.Point(1024, 5)
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
        Me.btnModificar.Location = New System.Drawing.Point(950, 5)
        Me.btnModificar.LookAndFeel.SkinName = "Metropolis"
        Me.btnModificar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(68, 55)
        Me.btnModificar.TabIndex = 2
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.ToolTip = "Pulse F3 para modificar"
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
        Me.btnEliminar.Location = New System.Drawing.Point(876, 5)
        Me.btnEliminar.LookAndFeel.SkinName = "Metropolis"
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(68, 55)
        Me.btnEliminar.TabIndex = 1
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.ToolTip = "Pulse F2 para Eliminar"
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
        Me.btnAnadir.Location = New System.Drawing.Point(802, 5)
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
        'txtEstado
        '
        Me.txtEstado.EnterMoveNextControl = True
        Me.txtEstado.Location = New System.Drawing.Point(5, 29)
        Me.txtEstado.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtEstado.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtEstado.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEstado.Size = New System.Drawing.Size(195, 20)
        Me.txtEstado.TabIndex = 1
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(7, 10)
        Me.LabelControl12.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl12.TabIndex = 178
        Me.LabelControl12.Text = "Estado"
        '
        'PanelCajas
        '
        Me.PanelCajas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelCajas.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelCajas.Controls.Add(Me.LabelControl5)
        Me.PanelCajas.Controls.Add(Me.cmbClasificacionWeb)
        Me.PanelCajas.Controls.Add(Me.LabelControl4)
        Me.PanelCajas.Controls.Add(Me.TxtListadoRevista)
        Me.PanelCajas.Controls.Add(Me.LabelControl3)
        Me.PanelCajas.Controls.Add(Me.TxtListado)
        Me.PanelCajas.Controls.Add(Me.LabelControl2)
        Me.PanelCajas.Controls.Add(Me.TxtTipPrioridad)
        Me.PanelCajas.Controls.Add(Me.LabelControl1)
        Me.PanelCajas.Controls.Add(Me.TxtPrioridad)
        Me.PanelCajas.Controls.Add(Me.LabelControl12)
        Me.PanelCajas.Controls.Add(Me.txtEstado)
        Me.PanelCajas.Location = New System.Drawing.Point(0, 678)
        Me.PanelCajas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PanelCajas.Name = "PanelCajas"
        Me.PanelCajas.Size = New System.Drawing.Size(1245, 58)
        Me.PanelCajas.TabIndex = 0
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(381, 10)
        Me.LabelControl5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(83, 13)
        Me.LabelControl5.TabIndex = 198
        Me.LabelControl5.Text = "Clasificación Web"
        '
        'cmbClasificacionWeb
        '
        Me.cmbClasificacionWeb.EnterMoveNextControl = True
        Me.cmbClasificacionWeb.Location = New System.Drawing.Point(381, 27)
        Me.cmbClasificacionWeb.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbClasificacionWeb.Name = "cmbClasificacionWeb"
        Me.cmbClasificacionWeb.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmbClasificacionWeb.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.cmbClasificacionWeb.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cmbClasificacionWeb.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbClasificacionWeb.Properties.View = Me.GridView3
        Me.cmbClasificacionWeb.Size = New System.Drawing.Size(256, 20)
        Me.cmbClasificacionWeb.TabIndex = 197
        '
        'GridView3
        '
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(1098, 10)
        Me.LabelControl4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(73, 13)
        Me.LabelControl4.TabIndex = 186
        Me.LabelControl4.Text = "Listado Revista"
        Me.LabelControl4.Visible = False
        '
        'TxtListadoRevista
        '
        Me.TxtListadoRevista.EnterMoveNextControl = True
        Me.TxtListadoRevista.Location = New System.Drawing.Point(1098, 29)
        Me.TxtListadoRevista.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtListadoRevista.Name = "TxtListadoRevista"
        Me.TxtListadoRevista.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtListadoRevista.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.TxtListadoRevista.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtListadoRevista.Size = New System.Drawing.Size(141, 20)
        Me.TxtListadoRevista.TabIndex = 5
        Me.TxtListadoRevista.Visible = False
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(951, 10)
        Me.LabelControl3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl3.TabIndex = 184
        Me.LabelControl3.Text = "Listado"
        Me.LabelControl3.Visible = False
        '
        'TxtListado
        '
        Me.TxtListado.EnterMoveNextControl = True
        Me.TxtListado.Location = New System.Drawing.Point(951, 29)
        Me.TxtListado.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtListado.Name = "TxtListado"
        Me.TxtListado.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtListado.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.TxtListado.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtListado.Size = New System.Drawing.Size(141, 20)
        Me.TxtListado.TabIndex = 4
        Me.TxtListado.Visible = False
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(273, 10)
        Me.LabelControl2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl2.TabIndex = 182
        Me.LabelControl2.Text = "Tipo Prioridad"
        '
        'TxtTipPrioridad
        '
        Me.TxtTipPrioridad.EnterMoveNextControl = True
        Me.TxtTipPrioridad.Location = New System.Drawing.Point(273, 29)
        Me.TxtTipPrioridad.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtTipPrioridad.Name = "TxtTipPrioridad"
        Me.TxtTipPrioridad.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtTipPrioridad.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.TxtTipPrioridad.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTipPrioridad.Size = New System.Drawing.Size(102, 20)
        Me.TxtTipPrioridad.TabIndex = 3
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(209, 10)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(42, 13)
        Me.LabelControl1.TabIndex = 180
        Me.LabelControl1.Text = "Prioridad"
        '
        'TxtPrioridad
        '
        Me.TxtPrioridad.EnterMoveNextControl = True
        Me.TxtPrioridad.Location = New System.Drawing.Point(209, 29)
        Me.TxtPrioridad.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtPrioridad.Name = "TxtPrioridad"
        Me.TxtPrioridad.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtPrioridad.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.TxtPrioridad.Size = New System.Drawing.Size(56, 20)
        Me.TxtPrioridad.TabIndex = 2
        '
        'ucEstado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.dgvx)
        Me.Controls.Add(Me.PanelCajas)
        Me.Controls.Add(Me.PanelBotones)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "ucEstado"
        Me.Size = New System.Drawing.Size(1245, 800)
        CType(Me.dgvx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.Gv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBotones.ResumeLayout(False)
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEstado.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelCajas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelCajas.ResumeLayout(False)
        Me.PanelCajas.PerformLayout()
        CType(Me.cmbClasificacionWeb.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtListadoRevista.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtListado.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTipPrioridad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPrioridad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvx As MyGridControl
    Friend WithEvents Gv As MyGridView
    Friend WithEvents PanelBotones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnAceptar As uc_tb_SimpleButton
    Friend WithEvents btnModificar As uc_tb_SimpleButton
    Friend WithEvents btnEliminar As uc_tb_SimpleButton
    Friend WithEvents btnAnadir As uc_tb_SimpleButton


    Friend WithEvents btnCancelar As uc_tb_SimpleButton

    Friend WithEvents ToolTipController1 As DevExpress.Utils.ToolTipController
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents HoldfToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

    Friend WithEvents btnSalir As uc_tb_SimpleButton
    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents PanelCajas As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtEstado As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtPrioridad As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtTipPrioridad As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtListado As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtListadoRevista As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbClasificacionWeb As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
End Class