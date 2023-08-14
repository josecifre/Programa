
Imports Microsoft.VisualBasic
Imports System

Partial Public Class ucPoblacion

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
        Me.ToolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
        Me.PanelBotones = New DevExpress.XtraEditors.PanelControl()
        Me.btnSalir = New uc_tb_SimpleButton()
        Me.btnCancelar = New uc_tb_SimpleButton()
        Me.btnAceptar = New uc_tb_SimpleButton()
        Me.btnModificar = New uc_tb_SimpleButton()
        Me.btnPredeterminar = New uc_tb_SimpleButton()
        Me.btnAnadir = New uc_tb_SimpleButton()
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.txtPoblacion = New DevExpress.XtraEditors.TextEdit()
        Me.lblPoblacion = New DevExpress.XtraEditors.LabelControl()
        Me.PanelCajas = New DevExpress.XtraEditors.PanelControl()
        Me.cmbPoblacion = New uc_tb_CombosCheck()
        Me.lblPoblacion1 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbProvincia = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.lblProvincia = New DevExpress.XtraEditors.LabelControl()
        CType(Me.dgvx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.Gv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBotones.SuspendLayout()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPoblacion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelCajas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelCajas.SuspendLayout()
        CType(Me.cmbPoblacion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbProvincia.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.PanelBotones.Controls.Add(Me.btnPredeterminar)
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
        'btnPredeterminar
        '
        Me.btnPredeterminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPredeterminar.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnPredeterminar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnPredeterminar.Appearance.Options.UseBackColor = True
        Me.btnPredeterminar.Appearance.Options.UseTextOptions = True
        Me.btnPredeterminar.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnPredeterminar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnPredeterminar.Enabled = False
        Me.btnPredeterminar.Image = Global.My.Resources.Resources.First
        Me.btnPredeterminar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnPredeterminar.Location = New System.Drawing.Point(184, 5)
        Me.btnPredeterminar.LookAndFeel.SkinName = "Metropolis"
        Me.btnPredeterminar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPredeterminar.Name = "btnPredeterminar"
        Me.btnPredeterminar.Size = New System.Drawing.Size(65, 57)
        Me.btnPredeterminar.TabIndex = 1
        Me.btnPredeterminar.Text = "Predeterminar"
        Me.btnPredeterminar.ToolTip = "Pulse F2 para Predeterminar"
        '
        'btnAnadir
        '
        Me.btnAnadir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAnadir.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnAnadir.Appearance.Options.UseBackColor = True
        Me.btnAnadir.Appearance.Options.UseForeColor = True
        Me.btnAnadir.Appearance.Options.UseTextOptions = True
        Me.btnAnadir.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnAnadir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnAnadir.Image = Global.My.Resources.Resources.Multiple
        Me.btnAnadir.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnAnadir.Location = New System.Drawing.Point(5, 5)
        Me.btnAnadir.LookAndFeel.SkinName = "Metropolis"
        Me.btnAnadir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAnadir.Name = "btnAnadir"
        Me.btnAnadir.Size = New System.Drawing.Size(173, 57)
        Me.btnAnadir.TabIndex = 0
        Me.btnAnadir.Text = "Seleccionar Poblaciones"
        Me.btnAnadir.ToolTip = "Pulse F1 para Seleccionar Poblaciones"
        '
        'DockManager1
        '
        Me.DockManager1.Form = Me
        Me.DockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.StatusBar", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl"})
        '
        'txtPoblacion
        '
        Me.txtPoblacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPoblacion.EnterMoveNextControl = True
        Me.txtPoblacion.Location = New System.Drawing.Point(5, 28)
        Me.txtPoblacion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPoblacion.Name = "txtPoblacion"
        Me.txtPoblacion.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtPoblacion.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtPoblacion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPoblacion.Size = New System.Drawing.Size(1235, 20)
        Me.txtPoblacion.TabIndex = 3
        '
        'lblPoblacion
        '
        Me.lblPoblacion.Location = New System.Drawing.Point(358, 9)
        Me.lblPoblacion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lblPoblacion.Name = "lblPoblacion"
        Me.lblPoblacion.Size = New System.Drawing.Size(45, 13)
        Me.lblPoblacion.TabIndex = 178
        Me.lblPoblacion.Text = "Población"
        Me.lblPoblacion.Visible = False
        '
        'PanelCajas
        '
        Me.PanelCajas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelCajas.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelCajas.Controls.Add(Me.cmbPoblacion)
        Me.PanelCajas.Controls.Add(Me.lblPoblacion1)
        Me.PanelCajas.Controls.Add(Me.cmbProvincia)
        Me.PanelCajas.Controls.Add(Me.lblProvincia)
        Me.PanelCajas.Controls.Add(Me.lblPoblacion)
        Me.PanelCajas.Controls.Add(Me.txtPoblacion)
        Me.PanelCajas.Location = New System.Drawing.Point(0, 678)
        Me.PanelCajas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PanelCajas.Name = "PanelCajas"
        Me.PanelCajas.Size = New System.Drawing.Size(1245, 58)
        Me.PanelCajas.TabIndex = 0
        '
        'cmbPoblacion
        '
        Me.cmbPoblacion.CadenaConLosValores = Nothing
        Me.cmbPoblacion.EditValue = ""
        Me.cmbPoblacion.EstoyEnAlta = False
        Me.cmbPoblacion.Location = New System.Drawing.Point(358, 28)
        Me.cmbPoblacion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbPoblacion.Name = "cmbPoblacion"
        Me.cmbPoblacion.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbPoblacion.Size = New System.Drawing.Size(325, 20)
        Me.cmbPoblacion.TabIndex = 2
        Me.cmbPoblacion.tb_Campo = Nothing
        Me.cmbPoblacion.tb_CampoFiltro = Nothing
        Me.cmbPoblacion.tb_TablaCompleta = Nothing
        Me.cmbPoblacion.tb_TablaEnlazada = Nothing
        Me.cmbPoblacion.tb_ValorBusqueda = 0
        '
        'lblPoblacion1
        '
        Me.lblPoblacion1.Location = New System.Drawing.Point(8, 9)
        Me.lblPoblacion1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lblPoblacion1.Name = "lblPoblacion1"
        Me.lblPoblacion1.Size = New System.Drawing.Size(45, 13)
        Me.lblPoblacion1.TabIndex = 186
        Me.lblPoblacion1.Text = "Población"
        '
        'cmbProvincia
        '
        Me.cmbProvincia.EnterMoveNextControl = True
        Me.cmbProvincia.Location = New System.Drawing.Point(5, 28)
        Me.cmbProvincia.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.cmbProvincia.Name = "cmbProvincia"
        Me.cmbProvincia.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White
        Me.cmbProvincia.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.cmbProvincia.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cmbProvincia.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.cmbProvincia.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cmbProvincia.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbProvincia.Properties.View = Me.GridView1
        Me.cmbProvincia.Size = New System.Drawing.Size(325, 20)
        Me.cmbProvincia.TabIndex = 1
        Me.cmbProvincia.Visible = False
        '
        'GridView1
        '
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'lblProvincia
        '
        Me.lblProvincia.Location = New System.Drawing.Point(8, 10)
        Me.lblProvincia.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lblProvincia.Name = "lblProvincia"
        Me.lblProvincia.Size = New System.Drawing.Size(43, 13)
        Me.lblProvincia.TabIndex = 184
        Me.lblProvincia.Text = "Provincia"
        Me.lblProvincia.Visible = False
        '
        'ucPoblacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.dgvx)
        Me.Controls.Add(Me.PanelCajas)
        Me.Controls.Add(Me.PanelBotones)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "ucPoblacion"
        Me.Size = New System.Drawing.Size(1245, 800)
        CType(Me.dgvx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.Gv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBotones.ResumeLayout(False)
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPoblacion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelCajas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelCajas.ResumeLayout(False)
        Me.PanelCajas.PerformLayout()
        CType(Me.cmbPoblacion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbProvincia.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvx As MyGridControl
    Friend WithEvents Gv As MyGridView
    Friend WithEvents PanelBotones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnAceptar As uc_tb_SimpleButton
    Friend WithEvents btnModificar As uc_tb_SimpleButton
    Friend WithEvents btnPredeterminar As uc_tb_SimpleButton
    Friend WithEvents btnAnadir As uc_tb_SimpleButton


    Friend WithEvents btnCancelar As uc_tb_SimpleButton

    Friend WithEvents ToolTipController1 As DevExpress.Utils.ToolTipController
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents HoldfToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

    Friend WithEvents btnSalir As uc_tb_SimpleButton
    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents PanelCajas As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblPoblacion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPoblacion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmbProvincia As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblProvincia As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPoblacion1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbPoblacion As uc_tb_CombosCheck

End Class