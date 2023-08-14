<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVisitasConcertadas
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
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
        Dim Label2 As System.Windows.Forms.Label
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.btnEliminar = New uc_tb_SimpleButton()
        Me.btnCrearVisita = New uc_tb_SimpleButton()
        Me.txtObservaciones = New DevExpress.XtraEditors.MemoEdit()
        Me.btnSalir = New uc_tb_SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.dgvxCitas = New MyGridControl()
        Me.Gv = New MyGridView()
        Me.lblCliente = New DevExpress.XtraEditors.LabelControl()
        Label2 = New System.Windows.Forms.Label()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.txtObservaciones.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.dgvxCitas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(10, 5)
        Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(78, 13)
        Label2.TabIndex = 223
        Label2.Text = "Observaciones"
        '
        'PanelControl3
        '
        Me.PanelControl3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelControl3.Controls.Add(Me.btnEliminar)
        Me.PanelControl3.Controls.Add(Me.btnCrearVisita)
        Me.PanelControl3.Controls.Add(Me.txtObservaciones)
        Me.PanelControl3.Controls.Add(Label2)
        Me.PanelControl3.Controls.Add(Me.btnSalir)
        Me.PanelControl3.Location = New System.Drawing.Point(6, 283)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(827, 97)
        Me.PanelControl3.TabIndex = 232
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnEliminar.Appearance.Options.UseBackColor = True
        Me.btnEliminar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Image = Global.My.Resources.Resources.Eliminar1
        Me.btnEliminar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnEliminar.Location = New System.Drawing.Point(644, 22)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(89, 65)
        Me.btnEliminar.TabIndex = 224
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.ToolTip = "Pulse F2 para eliminar"
        '
        'btnCrearVisita
        '
        Me.btnCrearVisita.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCrearVisita.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnCrearVisita.Appearance.BorderColor = System.Drawing.Color.White
        Me.btnCrearVisita.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCrearVisita.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnCrearVisita.Appearance.Options.UseBackColor = True
        Me.btnCrearVisita.Appearance.Options.UseBorderColor = True
        Me.btnCrearVisita.Appearance.Options.UseFont = True
        Me.btnCrearVisita.Appearance.Options.UseForeColor = True
        Me.btnCrearVisita.Appearance.Options.UseTextOptions = True
        Me.btnCrearVisita.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnCrearVisita.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.btnCrearVisita.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnCrearVisita.Image = Global.My.Resources.Resources.visitas
        Me.btnCrearVisita.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnCrearVisita.Location = New System.Drawing.Point(542, 22)
        Me.btnCrearVisita.LookAndFeel.SkinName = "Metropolis"
        Me.btnCrearVisita.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCrearVisita.Name = "btnCrearVisita"
        Me.btnCrearVisita.Size = New System.Drawing.Size(95, 65)
        Me.btnCrearVisita.TabIndex = 3
        Me.btnCrearVisita.Text = "Crear Visita"
        Me.btnCrearVisita.ToolTip = "Visitas"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObservaciones.Location = New System.Drawing.Point(5, 22)
        Me.txtObservaciones.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(531, 65)
        Me.txtObservaciones.TabIndex = 2
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
        Me.btnSalir.Location = New System.Drawing.Point(738, 22)
        Me.btnSalir.LookAndFeel.SkinName = "Metropolis"
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(83, 65)
        Me.btnSalir.TabIndex = 4
        Me.btnSalir.Text = "Salir"
        '
        'PanelControl2
        '
        Me.PanelControl2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelControl2.Controls.Add(Me.dgvxCitas)
        Me.PanelControl2.Location = New System.Drawing.Point(6, 32)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(827, 245)
        Me.PanelControl2.TabIndex = 231
        '
        'dgvxCitas
        '
        Me.dgvxCitas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvxCitas.ColumnaCheck = Nothing
        Me.dgvxCitas.Location = New System.Drawing.Point(5, 5)
        Me.dgvxCitas.MainView = Me.Gv
        Me.dgvxCitas.Name = "dgvxCitas"
        Me.dgvxCitas.Size = New System.Drawing.Size(817, 235)
        Me.dgvxCitas.TabIndex = 1
        Me.dgvxCitas.tb_AnadirColumnaCheck = False
        Me.dgvxCitas.tbPerfilPredeterminado = ""
        Me.dgvxCitas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Gv})
        '
        'Gv
        '
        Me.Gv.GridControl = Me.dgvxCitas
        Me.Gv.Name = "Gv"
        '
        'lblCliente
        '
        Me.lblCliente.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.lblCliente.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblCliente.Location = New System.Drawing.Point(6, 8)
        Me.lblCliente.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(65, 19)
        Me.lblCliente.TabIndex = 229
        Me.lblCliente.Text = "Dirección"
        '
        'frmVisitasConcertadas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(837, 385)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.lblCliente)
        Me.Name = "frmVisitasConcertadas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Visitas Concertadas"
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.txtObservaciones.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.dgvxCitas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtObservaciones As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents dgvxCitas As MyGridControl
    Friend WithEvents Gv As MyGridView
    Friend WithEvents btnSalir As uc_tb_SimpleButton
    Friend WithEvents lblCliente As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnCrearVisita As uc_tb_SimpleButton
    Friend WithEvents btnEliminar As uc_tb_SimpleButton
End Class
