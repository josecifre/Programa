<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWordReport
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
        Me.btnPantalla = New uc_tb_SimpleButton()
        Me.btnWord = New uc_tb_SimpleButton()
        Me.SuspendLayout()
        '
        'btnPantalla
        '
        Me.btnPantalla.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnPantalla.Appearance.BorderColor = System.Drawing.Color.White
        Me.btnPantalla.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnPantalla.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnPantalla.Appearance.Options.UseBackColor = True
        Me.btnPantalla.Appearance.Options.UseBorderColor = True
        Me.btnPantalla.Appearance.Options.UseFont = True
        Me.btnPantalla.Appearance.Options.UseForeColor = True
        Me.btnPantalla.Appearance.Options.UseTextOptions = True
        Me.btnPantalla.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnPantalla.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnPantalla.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnPantalla.Image = Global.My.Resources.Resources.PC
        Me.btnPantalla.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnPantalla.Location = New System.Drawing.Point(12, 11)
        Me.btnPantalla.LookAndFeel.SkinName = "Metropolis"
        Me.btnPantalla.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPantalla.Name = "btnPantalla"
        Me.btnPantalla.Size = New System.Drawing.Size(73, 53)
        Me.btnPantalla.TabIndex = 1
        Me.btnPantalla.Text = "Pantalla"
        Me.btnPantalla.ToolTip = "Mostrar en Pantalla / Imprimir"
        '
        'btnWord
        '
        Me.btnWord.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnWord.Appearance.BorderColor = System.Drawing.Color.White
        Me.btnWord.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnWord.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnWord.Appearance.Options.UseBackColor = True
        Me.btnWord.Appearance.Options.UseBorderColor = True
        Me.btnWord.Appearance.Options.UseFont = True
        Me.btnWord.Appearance.Options.UseForeColor = True
        Me.btnWord.Appearance.Options.UseTextOptions = True
        Me.btnWord.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnWord.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnWord.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnWord.Image = Global.My.Resources.Resources.Word32
        Me.btnWord.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnWord.Location = New System.Drawing.Point(91, 11)
        Me.btnWord.LookAndFeel.SkinName = "Metropolis"
        Me.btnWord.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnWord.Name = "btnWord"
        Me.btnWord.Size = New System.Drawing.Size(73, 53)
        Me.btnWord.TabIndex = 2
        Me.btnWord.Text = "Word"
        Me.btnWord.ToolTip = "Mostrar en Word"
        '
        'frmWordReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(176, 74)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnWord)
        Me.Controls.Add(Me.btnPantalla)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmWordReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Mostrar en:"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnPantalla As uc_tb_SimpleButton
    Friend WithEvents btnWord As uc_tb_SimpleButton
End Class
