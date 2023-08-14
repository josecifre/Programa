<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVisitas
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.btnVisitasInmueble = New uc_tb_SimpleButton()
        Me.btnVisitasCliente = New uc_tb_SimpleButton()
        Me.btnConcertarVisita = New uc_tb_SimpleButton()
        Me.btnSalir = New uc_tb_SimpleButton()
        Me.btnTodasLasVisitas = New uc_tb_SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelControl1.Controls.Add(Me.btnVisitasInmueble)
        Me.PanelControl1.Controls.Add(Me.btnVisitasCliente)
        Me.PanelControl1.Controls.Add(Me.btnConcertarVisita)
        Me.PanelControl1.Controls.Add(Me.btnSalir)
        Me.PanelControl1.Controls.Add(Me.btnTodasLasVisitas)
        Me.PanelControl1.Location = New System.Drawing.Point(12, 12)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(142, 306)
        Me.PanelControl1.TabIndex = 223
        '
        'btnVisitasInmueble
        '
        Me.btnVisitasInmueble.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnVisitasInmueble.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnVisitasInmueble.Appearance.Options.UseBackColor = True
        Me.btnVisitasInmueble.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.btnVisitasInmueble.Image = Global.My.Resources.Resources.Clientes
        Me.btnVisitasInmueble.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnVisitasInmueble.Location = New System.Drawing.Point(8, 83)
        Me.btnVisitasInmueble.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnVisitasInmueble.Name = "btnVisitasInmueble"
        Me.btnVisitasInmueble.Size = New System.Drawing.Size(128, 75)
        Me.btnVisitasInmueble.TabIndex = 2
        Me.btnVisitasInmueble.Text = "Visitas Inmueble"
        Me.btnVisitasInmueble.ToolTip = "Visitas Inmueble"
        '
        'btnVisitasCliente
        '
        Me.btnVisitasCliente.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnVisitasCliente.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnVisitasCliente.Appearance.Options.UseBackColor = True
        Me.btnVisitasCliente.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.btnVisitasCliente.Image = Global.My.Resources.Resources.Clientes
        Me.btnVisitasCliente.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnVisitasCliente.Location = New System.Drawing.Point(8, 83)
        Me.btnVisitasCliente.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnVisitasCliente.Name = "btnVisitasCliente"
        Me.btnVisitasCliente.Size = New System.Drawing.Size(128, 75)
        Me.btnVisitasCliente.TabIndex = 123
        Me.btnVisitasCliente.Text = "Visitas Cliente"
        Me.btnVisitasCliente.ToolTip = "Visitas Cliente"
        '
        'btnConcertarVisita
        '
        Me.btnConcertarVisita.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnConcertarVisita.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnConcertarVisita.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnConcertarVisita.Appearance.Options.UseBackColor = True
        Me.btnConcertarVisita.Appearance.Options.UseForeColor = True
        Me.btnConcertarVisita.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.btnConcertarVisita.Image = Global.My.Resources.Resources.Anadir
        Me.btnConcertarVisita.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnConcertarVisita.Location = New System.Drawing.Point(8, 4)
        Me.btnConcertarVisita.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnConcertarVisita.Name = "btnConcertarVisita"
        Me.btnConcertarVisita.Size = New System.Drawing.Size(128, 75)
        Me.btnConcertarVisita.TabIndex = 1
        Me.btnConcertarVisita.Text = "Concertar Visita"
        Me.btnConcertarVisita.ToolTip = "Concertar Cita"
        '
        'btnSalir
        '
        Me.btnSalir.Appearance.Options.UseBackColor = True
        Me.btnSalir.Appearance.Options.UseTextOptions = True
        Me.btnSalir.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnSalir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.btnSalir.Image = Global.My.Resources.Resources.desconexion_de_salida_icono_7025_641
        Me.btnSalir.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnSalir.Location = New System.Drawing.Point(8, 244)
        Me.btnSalir.LookAndFeel.SkinName = "Metropolis"
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(128, 59)
        Me.btnSalir.TabIndex = 4
        Me.btnSalir.Text = "Salir"
        '
        'btnTodasLasVisitas
        '
        Me.btnTodasLasVisitas.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnTodasLasVisitas.Appearance.Options.UseBackColor = True
        Me.btnTodasLasVisitas.Appearance.Options.UseTextOptions = True
        Me.btnTodasLasVisitas.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnTodasLasVisitas.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.btnTodasLasVisitas.Image = Global.My.Resources.Resources.caja
        Me.btnTodasLasVisitas.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnTodasLasVisitas.Location = New System.Drawing.Point(8, 163)
        Me.btnTodasLasVisitas.LookAndFeel.SkinName = "Metropolis"
        Me.btnTodasLasVisitas.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnTodasLasVisitas.Name = "btnTodasLasVisitas"
        Me.btnTodasLasVisitas.Size = New System.Drawing.Size(128, 75)
        Me.btnTodasLasVisitas.TabIndex = 3
        Me.btnTodasLasVisitas.Text = "Todas las Visitas"
        Me.btnTodasLasVisitas.ToolTip = "Todas las Visitas"
        '
        'frmVisitas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(159, 323)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "frmVisitas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Visitas"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnVisitasCliente As uc_tb_SimpleButton
    Friend WithEvents btnConcertarVisita As uc_tb_SimpleButton
    Friend WithEvents btnSalir As uc_tb_SimpleButton
    Friend WithEvents btnTodasLasVisitas As uc_tb_SimpleButton
    Friend WithEvents btnVisitasInmueble As uc_tb_SimpleButton
End Class
