<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Base2CajasAceptarCancelar
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
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.grBotones = New DevExpress.XtraEditors.GroupControl()
        Me.btnAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.gr1 = New DevExpress.XtraEditors.GroupControl()
        Me.txt2 = New DevExpress.XtraEditors.TextEdit()
        Me.lbl2 = New tb_label()
        Me.txt1 = New DevExpress.XtraEditors.TextEdit()
        Me.lbl1 = New tb_label()
        CType(Me.grBotones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grBotones.SuspendLayout()
        CType(Me.gr1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gr1.SuspendLayout()
        CType(Me.txt2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancelar.Appearance.Options.UseFont = True
        Me.btnCancelar.Location = New System.Drawing.Point(137, 14)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(82, 64)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "Cancelar"
        '
        'grBotones
        '
        Me.grBotones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.grBotones.Controls.Add(Me.btnCancelar)
        Me.grBotones.Controls.Add(Me.btnAceptar)
        Me.grBotones.Location = New System.Drawing.Point(7, 134)
        Me.grBotones.Name = "grBotones"
        Me.grBotones.ShowCaption = False
        Me.grBotones.Size = New System.Drawing.Size(269, 94)
        Me.grBotones.TabIndex = 1
        '
        'btnAceptar
        '
        Me.btnAceptar.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnAceptar.Appearance.Options.UseFont = True
        Me.btnAceptar.Location = New System.Drawing.Point(49, 14)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(82, 64)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "Aceptar"
        '
        'gr1
        '
        Me.gr1.Appearance.BorderColor = System.Drawing.Color.Transparent
        Me.gr1.Appearance.Options.UseBorderColor = True
        Me.gr1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.gr1.Controls.Add(Me.txt2)
        Me.gr1.Controls.Add(Me.lbl2)
        Me.gr1.Controls.Add(Me.txt1)
        Me.gr1.Controls.Add(Me.lbl1)
        Me.gr1.Location = New System.Drawing.Point(7, 12)
        Me.gr1.Name = "gr1"
        Me.gr1.ShowCaption = False
        Me.gr1.Size = New System.Drawing.Size(269, 116)
        Me.gr1.TabIndex = 0
        '
        'txt2
        '
        Me.txt2.EnterMoveNextControl = True
        Me.txt2.Location = New System.Drawing.Point(17, 80)
        Me.txt2.Name = "txt2"
        Me.txt2.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txt2.Properties.Appearance.Options.UseFont = True
        Me.txt2.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txt2.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txt2.Size = New System.Drawing.Size(234, 26)
        Me.txt2.TabIndex = 180
        '
        'lbl2
        '
        Me.lbl2.Location = New System.Drawing.Point(17, 63)
        Me.lbl2.Name = "lbl2"
        Me.lbl2.Size = New System.Drawing.Size(34, 13)
        Me.lbl2.TabIndex = 181
        Me.lbl2.Text = "Texto2"
        '
        'txt1
        '
        Me.txt1.EnterMoveNextControl = True
        Me.txt1.Location = New System.Drawing.Point(17, 28)
        Me.txt1.Name = "txt1"
        Me.txt1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txt1.Properties.Appearance.Options.UseFont = True
        Me.txt1.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txt1.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txt1.Size = New System.Drawing.Size(234, 26)
        Me.txt1.TabIndex = 178
        '
        'lbl1
        '
        Me.lbl1.Location = New System.Drawing.Point(17, 11)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(34, 13)
        Me.lbl1.TabIndex = 179
        Me.lbl1.Text = "Texto1"
        '
        'Base2CajasAceptarCancelar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(288, 234)
        Me.ControlBox = False
        Me.Controls.Add(Me.grBotones)
        Me.Controls.Add(Me.gr1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Base2CajasAceptarCancelar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.grBotones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grBotones.ResumeLayout(False)
        CType(Me.gr1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gr1.ResumeLayout(False)
        Me.gr1.PerformLayout()
        CType(Me.txt2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grBotones As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gr1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents txt1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbl1 As tb_label
    Friend WithEvents txt2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbl2 As tb_label
End Class
