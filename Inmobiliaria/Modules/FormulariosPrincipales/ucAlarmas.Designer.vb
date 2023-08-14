Imports Microsoft.VisualBasic
Imports System

Partial Public Class ucAlarmas


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
        Dim GridCheckMarksSelection1 As GridCheckMarksSelection = New GridCheckMarksSelection()
        Me.Gv = New MyGridView()
        Me.dgvx = New MyGridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.HoldfToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemCheckEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemCheckEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemCheckEdit6 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.ToolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
        Me.PanelCajas = New DevExpress.XtraEditors.PanelControl()
        Me.pnlEnviado = New DevExpress.XtraEditors.PanelControl()
        Me.lblxdey = New DevExpress.XtraEditors.LabelControl()
        Me.lblEnviando = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.txtObservaciones = New DevExpress.XtraEditors.MemoEdit()
        Me.PanelBotones = New DevExpress.XtraEditors.PanelControl()
        Me.btnCambiarFecha = New uc_tb_SimpleButton()
        Me.btnImprimir = New uc_tb_SimpleButton()
        Me.LabelControl19 = New DevExpress.XtraEditors.LabelControl()
        Me.btnEmails = New uc_tb_SimpleButton()
        Me.btnLlamadasPropietarios = New uc_tb_SimpleButton()
        Me.btnInmuebles = New uc_tb_SimpleButton()
        Me.btnSalir = New uc_tb_SimpleButton()
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        CType(Me.Gv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelCajas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelCajas.SuspendLayout()
        CType(Me.pnlEnviado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEnviado.SuspendLayout()
        CType(Me.txtObservaciones.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBotones.SuspendLayout()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Gv
        '
        Me.Gv.GridControl = Me.dgvx
        Me.Gv.Name = "Gv"
        '
        'dgvx
        '
        Me.dgvx.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        GridCheckMarksSelection1.View = Nothing
        Me.dgvx.ColumnaCheck = GridCheckMarksSelection1
        Me.dgvx.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgvx.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvx.Location = New System.Drawing.Point(0, 0)
        Me.dgvx.MainView = Me.Gv
        Me.dgvx.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvx.Name = "dgvx"
        Me.dgvx.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1, Me.RepositoryItemCheckEdit1, Me.RepositoryItemCheckEdit3, Me.RepositoryItemCheckEdit2, Me.RepositoryItemCheckEdit4, Me.RepositoryItemCheckEdit6})
        Me.dgvx.Size = New System.Drawing.Size(823, 161)
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
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'RepositoryItemCheckEdit3
        '
        Me.RepositoryItemCheckEdit3.AutoHeight = False
        Me.RepositoryItemCheckEdit3.Name = "RepositoryItemCheckEdit3"
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        '
        'RepositoryItemCheckEdit4
        '
        Me.RepositoryItemCheckEdit4.AutoHeight = False
        Me.RepositoryItemCheckEdit4.Name = "RepositoryItemCheckEdit4"
        '
        'RepositoryItemCheckEdit6
        '
        Me.RepositoryItemCheckEdit6.AutoHeight = False
        Me.RepositoryItemCheckEdit6.Name = "RepositoryItemCheckEdit6"
        '
        'PanelCajas
        '
        Me.PanelCajas.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelCajas.Controls.Add(Me.pnlEnviado)
        Me.PanelCajas.Controls.Add(Me.LabelControl15)
        Me.PanelCajas.Controls.Add(Me.txtObservaciones)
        Me.PanelCajas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelCajas.Location = New System.Drawing.Point(0, 173)
        Me.PanelCajas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PanelCajas.Name = "PanelCajas"
        Me.PanelCajas.Size = New System.Drawing.Size(823, 146)
        Me.PanelCajas.TabIndex = 0
        '
        'pnlEnviado
        '
        Me.pnlEnviado.Controls.Add(Me.lblxdey)
        Me.pnlEnviado.Controls.Add(Me.lblEnviando)
        Me.pnlEnviado.Location = New System.Drawing.Point(298, 34)
        Me.pnlEnviado.Name = "pnlEnviado"
        Me.pnlEnviado.Size = New System.Drawing.Size(243, 78)
        Me.pnlEnviado.TabIndex = 293
        Me.pnlEnviado.Visible = False
        '
        'lblxdey
        '
        Me.lblxdey.Appearance.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblxdey.Appearance.ForeColor = System.Drawing.Color.Maroon
        Me.lblxdey.Location = New System.Drawing.Point(146, 27)
        Me.lblxdey.Name = "lblxdey"
        Me.lblxdey.Size = New System.Drawing.Size(63, 25)
        Me.lblxdey.TabIndex = 1
        Me.lblxdey.Text = "1 de 1"
        '
        'lblEnviando
        '
        Me.lblEnviando.Appearance.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblEnviando.Appearance.ForeColor = System.Drawing.Color.Maroon
        Me.lblEnviando.Location = New System.Drawing.Point(15, 27)
        Me.lblEnviando.Name = "lblEnviando"
        Me.lblEnviando.Size = New System.Drawing.Size(96, 25)
        Me.lblEnviando.TabIndex = 0
        Me.lblEnviando.Text = "Enviando"
        '
        'LabelControl15
        '
        Me.LabelControl15.Location = New System.Drawing.Point(5, 10)
        Me.LabelControl15.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(71, 13)
        Me.LabelControl15.TabIndex = 181
        Me.LabelControl15.Text = "Observaciones"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObservaciones.Enabled = False
        Me.txtObservaciones.Location = New System.Drawing.Point(5, 34)
        Me.txtObservaciones.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtObservaciones.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtObservaciones.Size = New System.Drawing.Size(813, 108)
        Me.txtObservaciones.TabIndex = 1
        '
        'PanelBotones
        '
        Me.PanelBotones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelBotones.Controls.Add(Me.btnCambiarFecha)
        Me.PanelBotones.Controls.Add(Me.btnImprimir)
        Me.PanelBotones.Controls.Add(Me.LabelControl19)
        Me.PanelBotones.Controls.Add(Me.btnEmails)
        Me.PanelBotones.Controls.Add(Me.btnLlamadasPropietarios)
        Me.PanelBotones.Controls.Add(Me.btnInmuebles)
        Me.PanelBotones.Controls.Add(Me.btnSalir)
        Me.PanelBotones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBotones.Location = New System.Drawing.Point(0, 319)
        Me.PanelBotones.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PanelBotones.Name = "PanelBotones"
        Me.PanelBotones.Size = New System.Drawing.Size(823, 64)
        Me.PanelBotones.TabIndex = 17
        '
        'btnCambiarFecha
        '
        Me.btnCambiarFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCambiarFecha.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnCambiarFecha.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnCambiarFecha.Appearance.Options.UseBackColor = True
        Me.btnCambiarFecha.Appearance.Options.UseForeColor = True
        Me.btnCambiarFecha.Appearance.Options.UseTextOptions = True
        Me.btnCambiarFecha.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnCambiarFecha.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.btnCambiarFecha.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.btnCambiarFecha.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnCambiarFecha.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnCambiarFecha.Location = New System.Drawing.Point(319, 5)
        Me.btnCambiarFecha.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCambiarFecha.Name = "btnCambiarFecha"
        Me.btnCambiarFecha.Size = New System.Drawing.Size(80, 55)
        Me.btnCambiarFecha.TabIndex = 188
        Me.btnCambiarFecha.Text = "Cambiar Fecha"
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImprimir.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnImprimir.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnImprimir.Appearance.Options.UseBackColor = True
        Me.btnImprimir.Appearance.Options.UseBorderColor = True
        Me.btnImprimir.Appearance.Options.UseFont = True
        Me.btnImprimir.Appearance.Options.UseForeColor = True
        Me.btnImprimir.Appearance.Options.UseTextOptions = True
        Me.btnImprimir.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnImprimir.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnImprimir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnImprimir.Image = Global.My.Resources.Resources.ImprimirBoton
        Me.btnImprimir.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnImprimir.Location = New System.Drawing.Point(248, 5)
        Me.btnImprimir.LookAndFeel.SkinName = "Metropolis"
        Me.btnImprimir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(65, 55)
        Me.btnImprimir.TabIndex = 187
        Me.btnImprimir.Text = "Ficha"
        Me.btnImprimir.ToolTip = "Ficha del inmueble"
        '
        'LabelControl19
        '
        Me.LabelControl19.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl19.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.LabelControl19.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.LabelControl19.Location = New System.Drawing.Point(422, 5)
        Me.LabelControl19.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl19.Name = "LabelControl19"
        Me.LabelControl19.Size = New System.Drawing.Size(322, 26)
        Me.LabelControl19.TabIndex = 186
        Me.LabelControl19.Text = "Esta pantalla muestra aquellos inmuebles que ha vencido la reserva o les queda me" & _
    "nos de 5 días para hacerlo"
        '
        'btnEmails
        '
        Me.btnEmails.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEmails.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnEmails.Appearance.BorderColor = System.Drawing.Color.White
        Me.btnEmails.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnEmails.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnEmails.Appearance.Options.UseBackColor = True
        Me.btnEmails.Appearance.Options.UseBorderColor = True
        Me.btnEmails.Appearance.Options.UseFont = True
        Me.btnEmails.Appearance.Options.UseForeColor = True
        Me.btnEmails.Appearance.Options.UseTextOptions = True
        Me.btnEmails.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnEmails.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.btnEmails.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnEmails.Image = Global.My.Resources.Resources.EmailBoton
        Me.btnEmails.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnEmails.Location = New System.Drawing.Point(86, 5)
        Me.btnEmails.LookAndFeel.SkinName = "Metropolis"
        Me.btnEmails.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEmails.Name = "btnEmails"
        Me.btnEmails.Size = New System.Drawing.Size(75, 55)
        Me.btnEmails.TabIndex = 3
        Me.btnEmails.Text = "Email"
        Me.btnEmails.ToolTip = "Enviar Email"
        '
        'btnLlamadasPropietarios
        '
        Me.btnLlamadasPropietarios.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnLlamadasPropietarios.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnLlamadasPropietarios.Appearance.BorderColor = System.Drawing.Color.White
        Me.btnLlamadasPropietarios.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLlamadasPropietarios.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnLlamadasPropietarios.Appearance.Options.UseBackColor = True
        Me.btnLlamadasPropietarios.Appearance.Options.UseBorderColor = True
        Me.btnLlamadasPropietarios.Appearance.Options.UseFont = True
        Me.btnLlamadasPropietarios.Appearance.Options.UseForeColor = True
        Me.btnLlamadasPropietarios.Appearance.Options.UseTextOptions = True
        Me.btnLlamadasPropietarios.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnLlamadasPropietarios.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.btnLlamadasPropietarios.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnLlamadasPropietarios.Image = Global.My.Resources.Resources.NoContesta
        Me.btnLlamadasPropietarios.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnLlamadasPropietarios.Location = New System.Drawing.Point(167, 5)
        Me.btnLlamadasPropietarios.LookAndFeel.SkinName = "Metropolis"
        Me.btnLlamadasPropietarios.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnLlamadasPropietarios.Name = "btnLlamadasPropietarios"
        Me.btnLlamadasPropietarios.Size = New System.Drawing.Size(75, 55)
        Me.btnLlamadasPropietarios.TabIndex = 4
        Me.btnLlamadasPropietarios.Text = "No Contesta"
        Me.btnLlamadasPropietarios.ToolTip = "Ver Inmuebles que coinciden con las características del cliente"
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
        Me.btnInmuebles.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.btnInmuebles.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnInmuebles.Image = Global.My.Resources.Resources.Inmuebles32x32
        Me.btnInmuebles.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnInmuebles.Location = New System.Drawing.Point(5, 5)
        Me.btnInmuebles.LookAndFeel.SkinName = "Metropolis"
        Me.btnInmuebles.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnInmuebles.Name = "btnInmuebles"
        Me.btnInmuebles.Size = New System.Drawing.Size(75, 55)
        Me.btnInmuebles.TabIndex = 2
        Me.btnInmuebles.Text = "Inmuebles"
        Me.btnInmuebles.ToolTip = "Ver Inmuebles que coinciden con las características del cliente"
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
        Me.btnSalir.Location = New System.Drawing.Point(750, 5)
        Me.btnSalir.LookAndFeel.SkinName = "Metropolis"
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(68, 55)
        Me.btnSalir.TabIndex = 5
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.ToolTipController = Me.ToolTipController1
        '
        'DockManager1
        '
        Me.DockManager1.Form = Me
        Me.DockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.StatusBar", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl"})
        '
        'ucAlarmas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(823, 383)
        Me.Controls.Add(Me.PanelCajas)
        Me.Controls.Add(Me.PanelBotones)
        Me.Controls.Add(Me.dgvx)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "ucAlarmas"
        CType(Me.Gv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelCajas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelCajas.ResumeLayout(False)
        Me.PanelCajas.PerformLayout()
        CType(Me.pnlEnviado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEnviado.ResumeLayout(False)
        Me.pnlEnviado.PerformLayout()
        CType(Me.txtObservaciones.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBotones.ResumeLayout(False)
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvx As MyGridControl
    Friend WithEvents Gv As MyGridView
    Friend WithEvents PanelBotones As DevExpress.XtraEditors.PanelControl

    Friend WithEvents PanelCajas As DevExpress.XtraEditors.PanelControl

    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox

    Friend WithEvents txtObservaciones As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents TabPageContactosComerciales As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TabPageDocumentos As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents ToolTipController1 As DevExpress.Utils.ToolTipController
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents HoldfToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents btnSalir As uc_tb_SimpleButton
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents btnInmuebles As uc_tb_SimpleButton
    Friend WithEvents btnLlamadasPropietarios As uc_tb_SimpleButton
    Friend WithEvents btnEmails As uc_tb_SimpleButton
    Friend WithEvents pnlEnviado As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblxdey As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblEnviando As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemCheckEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemCheckEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemCheckEdit6 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents LabelControl19 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnImprimir As uc_tb_SimpleButton
    Friend WithEvents btnCambiarFecha As uc_tb_SimpleButton

End Class
