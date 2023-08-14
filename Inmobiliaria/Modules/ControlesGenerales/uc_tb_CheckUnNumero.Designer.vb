<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uc_tb_CheckUnNumero
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.chk = New uc_tb_CheckBoxRojoNegro()
        Me.spnValorCajaTexto1 = New DevExpress.XtraEditors.ButtonEdit()
        CType(Me.chk.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spnValorCajaTexto1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chk
        '
        Me.chk.Location = New System.Drawing.Point(0, 0)
        Me.chk.Name = "chk"
        Me.chk.Properties.AllowGrayed = True
        Me.chk.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chk.Properties.Appearance.Options.UseForeColor = True
        Me.chk.Properties.Caption = "Uc_tb_CheckBoxColor1"
        Me.chk.Size = New System.Drawing.Size(75, 19)
        Me.chk.TabIndex = 270
        '
        'spnValorCajaTexto1
        '
        Me.spnValorCajaTexto1.EnterMoveNextControl = True
        Me.spnValorCajaTexto1.Location = New System.Drawing.Point(87, 0)
        Me.spnValorCajaTexto1.Name = "spnValorCajaTexto1"
        Me.spnValorCajaTexto1.Properties.AllowMouseWheel = False
        Me.spnValorCajaTexto1.Properties.Appearance.Options.UseTextOptions = True
        Me.spnValorCajaTexto1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.spnValorCajaTexto1.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.spnValorCajaTexto1.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.spnValorCajaTexto1.Properties.DisplayFormat.FormatString = "n0"
        Me.spnValorCajaTexto1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.spnValorCajaTexto1.Properties.Mask.EditMask = "n0"
        Me.spnValorCajaTexto1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.spnValorCajaTexto1.Size = New System.Drawing.Size(45, 20)
        Me.spnValorCajaTexto1.TabIndex = 268
        '
        'uc_tb_CheckUnNumero
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.chk)
        Me.Controls.Add(Me.spnValorCajaTexto1)
        Me.Name = "uc_tb_CheckUnNumero"
        Me.Size = New System.Drawing.Size(132, 20)
        CType(Me.chk.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spnValorCajaTexto1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chk As uc_tb_CheckBoxRojoNegro
    Friend WithEvents spnValorCajaTexto1 As DevExpress.XtraEditors.ButtonEdit

End Class
