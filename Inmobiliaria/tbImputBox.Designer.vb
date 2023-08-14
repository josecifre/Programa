<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class tbImputBox
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
        Me.btnSalir = New uc_tb_SimpleButton()
        Me.btnAceptar = New uc_tb_SimpleButton()
        Me.lblTitulo = New DevExpress.XtraEditors.LabelControl()
        Me.txtResultado = New DevExpress.XtraEditors.MemoEdit()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBotones.SuspendLayout()
        CType(Me.txtResultado.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelBotones
        '
        Me.PanelBotones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelBotones.Controls.Add(Me.btnSalir)
        Me.PanelBotones.Controls.Add(Me.btnAceptar)
        Me.PanelBotones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBotones.Location = New System.Drawing.Point(0, 135)
        Me.PanelBotones.Name = "PanelBotones"
        Me.PanelBotones.Size = New System.Drawing.Size(356, 81)
        Me.PanelBotones.TabIndex = 1
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Appearance.Options.UseBackColor = True
        Me.btnSalir.Appearance.Options.UseTextOptions = True
        Me.btnSalir.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnSalir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Image = Global.My.Resources.Resources.cancel1
        Me.btnSalir.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnSalir.Location = New System.Drawing.Point(179, 5)
        Me.btnSalir.LookAndFeel.SkinName = "Metropolis"
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(82, 64)
        Me.btnSalir.TabIndex = 1
        Me.btnSalir.Text = "Salir"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnAceptar.Appearance.Options.UseBackColor = True
        Me.btnAceptar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnAceptar.Image = Global.My.Resources.Resources.check
        Me.btnAceptar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnAceptar.Location = New System.Drawing.Point(83, 5)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(82, 64)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "Aceptar"
        '
        'lblTitulo
        '
        Me.lblTitulo.AllowHtmlString = True
        Me.lblTitulo.Location = New System.Drawing.Point(12, 12)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(84, 13)
        Me.lblTitulo.TabIndex = 19
        Me.lblTitulo.Text = "<b><color=Black><b><color=Black>LabelControl1 </b></color> </b></color>"
        '
        'txtResultado
        '
        Me.txtResultado.Location = New System.Drawing.Point(12, 31)
        Me.txtResultado.Name = "txtResultado"
        Me.txtResultado.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtResultado.Properties.Appearance.Options.UseFont = True
        Me.txtResultado.Size = New System.Drawing.Size(332, 98)
        Me.txtResultado.TabIndex = 0
        '
        'tbImputBox
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(356, 216)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtResultado)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.PanelBotones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.LookAndFeel.SkinName = "Metropolis"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "tbImputBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBotones.ResumeLayout(False)
        CType(Me.txtResultado.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelBotones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnSalir As uc_tb_SimpleButton
    Friend WithEvents btnAceptar As uc_tb_SimpleButton
    Friend WithEvents lblTitulo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtResultado As DevExpress.XtraEditors.MemoEdit
End Class
