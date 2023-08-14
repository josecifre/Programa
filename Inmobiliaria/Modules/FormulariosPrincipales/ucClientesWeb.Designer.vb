<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucClientesWeb
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.dgvx = New MyGridControl()
        Me.Gv = New MyGridView()
        Me.RepositoryItemComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.PanelBotones = New DevExpress.XtraEditors.PanelControl()
        Me.btnDarDeBaja = New uc_tb_SimpleButton()
        Me.btnVerMensajes = New uc_tb_SimpleButton()
        Me.btnEnviarMensajes = New uc_tb_SimpleButton()
        Me.btnSalir = New uc_tb_SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        CType(Me.dgvx, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBotones.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvx
        '
        Me.dgvx.ColumnaCheck = Nothing
        Me.dgvx.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvx.Location = New System.Drawing.Point(2, 2)
        Me.dgvx.MainView = Me.Gv
        Me.dgvx.Name = "dgvx"
        Me.dgvx.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox2})
        Me.dgvx.Size = New System.Drawing.Size(1218, 540)
        Me.dgvx.TabIndex = 0
        Me.dgvx.tb_AnadirColumnaCheck = False
        Me.dgvx.tbPerfilPredeterminado = ""
        Me.dgvx.UseDisabledStatePainter = False
        Me.dgvx.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Gv})
        '
        'Gv
        '
        Me.Gv.GridControl = Me.dgvx
        Me.Gv.Name = "Gv"
        '
        'RepositoryItemComboBox2
        '
        Me.RepositoryItemComboBox2.AutoHeight = False
        Me.RepositoryItemComboBox2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox2.Name = "RepositoryItemComboBox2"
        '
        'PanelBotones
        '
        Me.PanelBotones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelBotones.Controls.Add(Me.btnDarDeBaja)
        Me.PanelBotones.Controls.Add(Me.btnVerMensajes)
        Me.PanelBotones.Controls.Add(Me.btnEnviarMensajes)
        Me.PanelBotones.Controls.Add(Me.btnSalir)
        Me.PanelBotones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBotones.Location = New System.Drawing.Point(0, 544)
        Me.PanelBotones.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PanelBotones.Name = "PanelBotones"
        Me.PanelBotones.Size = New System.Drawing.Size(1222, 64)
        Me.PanelBotones.TabIndex = 126
        '
        'btnDarDeBaja
        '
        Me.btnDarDeBaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDarDeBaja.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnDarDeBaja.Appearance.BorderColor = System.Drawing.Color.White
        Me.btnDarDeBaja.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDarDeBaja.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnDarDeBaja.Appearance.Options.UseBackColor = True
        Me.btnDarDeBaja.Appearance.Options.UseBorderColor = True
        Me.btnDarDeBaja.Appearance.Options.UseFont = True
        Me.btnDarDeBaja.Appearance.Options.UseForeColor = True
        Me.btnDarDeBaja.Appearance.Options.UseTextOptions = True
        Me.btnDarDeBaja.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnDarDeBaja.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnDarDeBaja.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnDarDeBaja.Image = Global.My.Resources.Resources.DarDeBaja
        Me.btnDarDeBaja.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnDarDeBaja.Location = New System.Drawing.Point(207, 5)
        Me.btnDarDeBaja.LookAndFeel.SkinName = "Metropolis"
        Me.btnDarDeBaja.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnDarDeBaja.Name = "btnDarDeBaja"
        Me.btnDarDeBaja.Size = New System.Drawing.Size(85, 55)
        Me.btnDarDeBaja.TabIndex = 3
        Me.btnDarDeBaja.Text = "Dar de baja"
        '
        'btnVerMensajes
        '
        Me.btnVerMensajes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnVerMensajes.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnVerMensajes.Appearance.BorderColor = System.Drawing.Color.White
        Me.btnVerMensajes.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerMensajes.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnVerMensajes.Appearance.Options.UseBackColor = True
        Me.btnVerMensajes.Appearance.Options.UseBorderColor = True
        Me.btnVerMensajes.Appearance.Options.UseFont = True
        Me.btnVerMensajes.Appearance.Options.UseForeColor = True
        Me.btnVerMensajes.Appearance.Options.UseTextOptions = True
        Me.btnVerMensajes.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnVerMensajes.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnVerMensajes.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnVerMensajes.Image = Global.My.Resources.Resources.Observaciones
        Me.btnVerMensajes.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnVerMensajes.Location = New System.Drawing.Point(5, 5)
        Me.btnVerMensajes.LookAndFeel.SkinName = "Metropolis"
        Me.btnVerMensajes.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnVerMensajes.Name = "btnVerMensajes"
        Me.btnVerMensajes.Size = New System.Drawing.Size(97, 55)
        Me.btnVerMensajes.TabIndex = 1
        Me.btnVerMensajes.Text = "Mensajes"
        Me.btnVerMensajes.ToolTip = "Ver mensajes"
        '
        'btnEnviarMensajes
        '
        Me.btnEnviarMensajes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEnviarMensajes.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnEnviarMensajes.Appearance.BorderColor = System.Drawing.Color.White
        Me.btnEnviarMensajes.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnviarMensajes.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnEnviarMensajes.Appearance.Options.UseBackColor = True
        Me.btnEnviarMensajes.Appearance.Options.UseBorderColor = True
        Me.btnEnviarMensajes.Appearance.Options.UseFont = True
        Me.btnEnviarMensajes.Appearance.Options.UseForeColor = True
        Me.btnEnviarMensajes.Appearance.Options.UseTextOptions = True
        Me.btnEnviarMensajes.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnEnviarMensajes.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnEnviarMensajes.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnEnviarMensajes.Image = Global.My.Resources.Resources.Forward_32x32
        Me.btnEnviarMensajes.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnEnviarMensajes.Location = New System.Drawing.Point(108, 5)
        Me.btnEnviarMensajes.LookAndFeel.SkinName = "Metropolis"
        Me.btnEnviarMensajes.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEnviarMensajes.Name = "btnEnviarMensajes"
        Me.btnEnviarMensajes.Size = New System.Drawing.Size(93, 55)
        Me.btnEnviarMensajes.TabIndex = 2
        Me.btnEnviarMensajes.Text = "Enviar"
        Me.btnEnviarMensajes.ToolTip = "Enviar Mensajes"
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
        Me.btnSalir.Location = New System.Drawing.Point(1149, 5)
        Me.btnSalir.LookAndFeel.SkinName = "Metropolis"
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(68, 55)
        Me.btnSalir.TabIndex = 4
        Me.btnSalir.Text = "Salir"
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelControl1.Controls.Add(Me.dgvx)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1222, 544)
        Me.PanelControl1.TabIndex = 127
        '
        'ucClientesWeb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1222, 608)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PanelBotones)
        Me.Name = "ucClientesWeb"
        Me.Text = "ucClientesWeb"
        CType(Me.dgvx, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBotones.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvx As MyGridControl
    Friend WithEvents Gv As MyGridView
    Friend WithEvents RepositoryItemComboBox2 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents PanelBotones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnVerMensajes As uc_tb_SimpleButton
    Friend WithEvents btnEnviarMensajes As uc_tb_SimpleButton
    Friend WithEvents btnSalir As uc_tb_SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnDarDeBaja As uc_tb_SimpleButton
End Class
