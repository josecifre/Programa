
Imports Microsoft.VisualBasic
Imports System

Partial Public Class ucEmailMasivoClientes

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
        Me.dgvx = New MyGridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.HoldfToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Gv = New MyGridView()
        Me.ToolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
        Me.PanelBotones = New DevExpress.XtraEditors.PanelControl()
        Me.pnlBuscando = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.lblBuscando = New DevExpress.XtraEditors.LabelControl()
        Me.lblpercent = New DevExpress.XtraEditors.LabelControl()
        Me.btnEmails = New uc_tb_SimpleButton()
        Me.btnSalir = New uc_tb_SimpleButton()
        Me.btnParar = New uc_tb_SimpleButton()
        Me.btnBuscar = New uc_tb_SimpleButton()
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.pnlEnviando = New DevExpress.XtraEditors.PanelControl()
        Me.lblxdey = New DevExpress.XtraEditors.LabelControl()
        Me.lblEnviando = New DevExpress.XtraEditors.LabelControl()
        Me.dgvxInmuebles = New MyGridControl()
        Me.GvInmuebles = New MyGridView()
        CType(Me.dgvx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.Gv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBotones.SuspendLayout()
        CType(Me.pnlBuscando, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBuscando.SuspendLayout()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlEnviando, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEnviando.SuspendLayout()
        CType(Me.dgvxInmuebles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GvInmuebles, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.dgvx.Size = New System.Drawing.Size(784, 314)
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
        Me.PanelBotones.Controls.Add(Me.pnlBuscando)
        Me.PanelBotones.Controls.Add(Me.btnEmails)
        Me.PanelBotones.Controls.Add(Me.btnSalir)
        Me.PanelBotones.Controls.Add(Me.btnParar)
        Me.PanelBotones.Controls.Add(Me.btnBuscar)
        Me.PanelBotones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBotones.Location = New System.Drawing.Point(0, 469)
        Me.PanelBotones.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PanelBotones.Name = "PanelBotones"
        Me.PanelBotones.Size = New System.Drawing.Size(784, 64)
        Me.PanelBotones.TabIndex = 17
        '
        'pnlBuscando
        '
        Me.pnlBuscando.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBuscando.Controls.Add(Me.LabelControl1)
        Me.pnlBuscando.Controls.Add(Me.lblBuscando)
        Me.pnlBuscando.Controls.Add(Me.lblpercent)
        Me.pnlBuscando.Location = New System.Drawing.Point(313, 5)
        Me.pnlBuscando.Name = "pnlBuscando"
        Me.pnlBuscando.Size = New System.Drawing.Size(243, 55)
        Me.pnlBuscando.TabIndex = 294
        Me.pnlBuscando.Visible = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LabelControl1.Location = New System.Drawing.Point(69, 33)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(95, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Esc para detener"
        '
        'lblBuscando
        '
        Me.lblBuscando.Appearance.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblBuscando.Appearance.ForeColor = System.Drawing.Color.Maroon
        Me.lblBuscando.Location = New System.Drawing.Point(5, 9)
        Me.lblBuscando.Name = "lblBuscando"
        Me.lblBuscando.Size = New System.Drawing.Size(101, 25)
        Me.lblBuscando.TabIndex = 0
        Me.lblBuscando.Text = "Buscando"
        '
        'lblpercent
        '
        Me.lblpercent.Appearance.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblpercent.Appearance.ForeColor = System.Drawing.Color.Maroon
        Me.lblpercent.Location = New System.Drawing.Point(147, 9)
        Me.lblpercent.Name = "lblpercent"
        Me.lblpercent.Size = New System.Drawing.Size(44, 25)
        Me.lblpercent.TabIndex = 1
        Me.lblpercent.Text = "0 %"
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
        Me.btnEmails.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnEmails.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnEmails.Enabled = False
        Me.btnEmails.Image = Global.My.Resources.Resources.EmailBoton
        Me.btnEmails.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnEmails.Location = New System.Drawing.Point(6, 4)
        Me.btnEmails.LookAndFeel.SkinName = "Metropolis"
        Me.btnEmails.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEmails.Name = "btnEmails"
        Me.btnEmails.Size = New System.Drawing.Size(65, 55)
        Me.btnEmails.TabIndex = 2
        Me.btnEmails.Text = "Email"
        Me.btnEmails.ToolTip = "Enviar Email"
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
        Me.btnSalir.Location = New System.Drawing.Point(711, 5)
        Me.btnSalir.LookAndFeel.SkinName = "Metropolis"
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(68, 55)
        Me.btnSalir.TabIndex = 6
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.ToolTipController = Me.ToolTipController1
        '
        'btnParar
        '
        Me.btnParar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnParar.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnParar.Appearance.BorderColor = System.Drawing.Color.White
        Me.btnParar.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnParar.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnParar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnParar.Appearance.Options.UseBackColor = True
        Me.btnParar.Appearance.Options.UseBorderColor = True
        Me.btnParar.Appearance.Options.UseFont = True
        Me.btnParar.Appearance.Options.UseForeColor = True
        Me.btnParar.Appearance.Options.UseTextOptions = True
        Me.btnParar.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnParar.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnParar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnParar.Enabled = False
        Me.btnParar.Image = Global.My.Resources.Resources.Cancelar
        Me.btnParar.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnParar.Location = New System.Drawing.Point(633, 5)
        Me.btnParar.LookAndFeel.SkinName = "Metropolis"
        Me.btnParar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnParar.Name = "btnParar"
        Me.btnParar.Size = New System.Drawing.Size(65, 55)
        Me.btnParar.TabIndex = 4
        Me.btnParar.Text = "Parar"
        Me.btnParar.ToolTip = "ESC para detener la busqueda"
        Me.btnParar.Visible = False
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnBuscar.Appearance.BorderColor = System.Drawing.Color.White
        Me.btnBuscar.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnBuscar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnBuscar.Appearance.Options.UseBackColor = True
        Me.btnBuscar.Appearance.Options.UseBorderColor = True
        Me.btnBuscar.Appearance.Options.UseFont = True
        Me.btnBuscar.Appearance.Options.UseForeColor = True
        Me.btnBuscar.Appearance.Options.UseTextOptions = True
        Me.btnBuscar.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnBuscar.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnBuscar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnBuscar.Image = Global.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnBuscar.Location = New System.Drawing.Point(562, 5)
        Me.btnBuscar.LookAndFeel.SkinName = "Metropolis"
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(65, 55)
        Me.btnBuscar.TabIndex = 3
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.Visible = False
        '
        'DockManager1
        '
        Me.DockManager1.Form = Me
        Me.DockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.StatusBar", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl"})
        '
        'pnlEnviando
        '
        Me.pnlEnviando.Controls.Add(Me.lblxdey)
        Me.pnlEnviando.Controls.Add(Me.lblEnviando)
        Me.pnlEnviando.Location = New System.Drawing.Point(267, 161)
        Me.pnlEnviando.Name = "pnlEnviando"
        Me.pnlEnviando.Size = New System.Drawing.Size(266, 78)
        Me.pnlEnviando.TabIndex = 292
        Me.pnlEnviando.Visible = False
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
        'dgvxInmuebles
        '
        Me.dgvxInmuebles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvxInmuebles.ColumnaCheck = Nothing
        Me.dgvxInmuebles.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgvxInmuebles.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvxInmuebles.Location = New System.Drawing.Point(0, 320)
        Me.dgvxInmuebles.MainView = Me.GvInmuebles
        Me.dgvxInmuebles.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvxInmuebles.Name = "dgvxInmuebles"
        Me.dgvxInmuebles.Size = New System.Drawing.Size(784, 148)
        Me.dgvxInmuebles.TabIndex = 1
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
        'ucEmailMasivoClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(784, 533)
        Me.Controls.Add(Me.dgvxInmuebles)
        Me.Controls.Add(Me.pnlEnviando)
        Me.Controls.Add(Me.dgvx)
        Me.Controls.Add(Me.PanelBotones)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "ucEmailMasivoClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Envío de emails por Alta, Cambio Precio o Fin Reservas"
        CType(Me.dgvx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.Gv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBotones.ResumeLayout(False)
        CType(Me.pnlBuscando, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBuscando.ResumeLayout(False)
        Me.pnlBuscando.PerformLayout()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlEnviando, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEnviando.ResumeLayout(False)
        Me.pnlEnviando.PerformLayout()
        CType(Me.dgvxInmuebles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GvInmuebles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvx As MyGridControl
    Friend WithEvents Gv As MyGridView
    Friend WithEvents PanelBotones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnBuscar As uc_tb_SimpleButton


    Friend WithEvents btnParar As uc_tb_SimpleButton

    Friend WithEvents ToolTipController1 As DevExpress.Utils.ToolTipController
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents HoldfToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

    Friend WithEvents btnSalir As uc_tb_SimpleButton
    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents btnEmails As uc_tb_SimpleButton
    Friend WithEvents pnlBuscando As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblpercent As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblBuscando As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents pnlEnviando As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblxdey As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblEnviando As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dgvxInmuebles As MyGridControl
    Friend WithEvents GvInmuebles As MyGridView

End Class