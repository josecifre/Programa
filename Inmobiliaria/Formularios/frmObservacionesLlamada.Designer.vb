<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmObservacionesLlamada
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
        Me.PanelBotones = New DevExpress.XtraEditors.PanelControl()
        Me.txtTexto = New DevExpress.XtraEditors.MemoEdit()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.UcCambioPrecio1 = New ucCambioPrecio()
        Me.btnNoContesta = New uc_tb_SimpleButton()
        Me.btnAceptar = New uc_tb_SimpleButton()
        Me.btnSalir = New uc_tb_SimpleButton()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBotones.SuspendLayout()
        CType(Me.txtTexto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelBotones
        '
        Me.PanelBotones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelBotones.Controls.Add(Me.btnNoContesta)
        Me.PanelBotones.Controls.Add(Me.btnAceptar)
        Me.PanelBotones.Controls.Add(Me.btnSalir)
        Me.PanelBotones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBotones.Location = New System.Drawing.Point(0, 409)
        Me.PanelBotones.Name = "PanelBotones"
        Me.PanelBotones.Size = New System.Drawing.Size(649, 66)
        Me.PanelBotones.TabIndex = 126
        '
        'txtTexto
        '
        Me.txtTexto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTexto.Location = New System.Drawing.Point(2, 289)
        Me.txtTexto.Name = "txtTexto"
        Me.txtTexto.Size = New System.Drawing.Size(645, 108)
        Me.txtTexto.TabIndex = 0
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelControl1.Controls.Add(Me.UcCambioPrecio1)
        Me.PanelControl1.Controls.Add(Me.txtTexto)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(649, 409)
        Me.PanelControl1.TabIndex = 127
        '
        'UcCambioPrecio1
        '
        Me.UcCambioPrecio1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UcCambioPrecio1.ContaInmueble = -1
        Me.UcCambioPrecio1.Location = New System.Drawing.Point(2, 0)
        Me.UcCambioPrecio1.Name = "UcCambioPrecio1"
        Me.UcCambioPrecio1.Size = New System.Drawing.Size(645, 299)
        Me.UcCambioPrecio1.TabIndex = 1
        '
        'btnNoContesta
        '
        Me.btnNoContesta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNoContesta.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnNoContesta.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNoContesta.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnNoContesta.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnNoContesta.Appearance.Options.UseBackColor = True
        Me.btnNoContesta.Appearance.Options.UseFont = True
        Me.btnNoContesta.Appearance.Options.UseForeColor = True
        Me.btnNoContesta.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.btnNoContesta.Image = Global.My.Resources.Resources.NoContesta
        Me.btnNoContesta.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnNoContesta.Location = New System.Drawing.Point(408, 6)
        Me.btnNoContesta.Name = "btnNoContesta"
        Me.btnNoContesta.Size = New System.Drawing.Size(162, 55)
        Me.btnNoContesta.TabIndex = 1
        Me.btnNoContesta.Text = "No Contesta"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnAceptar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnAceptar.Appearance.Options.UseBackColor = True
        Me.btnAceptar.Appearance.Options.UseFont = True
        Me.btnAceptar.Appearance.Options.UseForeColor = True
        Me.btnAceptar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.btnAceptar.Image = Global.My.Resources.Resources.Llamadas
        Me.btnAceptar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(5, 6)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(162, 55)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "Contestó"
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Appearance.Options.UseBackColor = True
        Me.btnSalir.Appearance.Options.UseTextOptions = True
        Me.btnSalir.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnSalir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.btnSalir.Image = Global.My.Resources.Resources.desconexion_de_salida_icono_7025_641
        Me.btnSalir.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnSalir.Location = New System.Drawing.Point(576, 6)
        Me.btnSalir.LookAndFeel.SkinName = "Metropolis"
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(68, 55)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "Salir"
        '
        'frmObservacionesLlamada
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(649, 475)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PanelBotones)
        Me.Name = "frmObservacionesLlamada"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Observaciones"
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBotones.ResumeLayout(False)
        CType(Me.txtTexto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSalir As uc_tb_SimpleButton
    Friend WithEvents btnAceptar As uc_tb_SimpleButton
    Friend WithEvents PanelBotones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnNoContesta As uc_tb_SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    ' Friend WithEvents UcCambioPrecio1 As ucCambioPrecio
    Friend WithEvents txtTexto As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents UcCambioPrecio1 As ucCambioPrecio
End Class

