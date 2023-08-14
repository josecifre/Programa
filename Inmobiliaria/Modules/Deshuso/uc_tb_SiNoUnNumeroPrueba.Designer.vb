
Namespace Igis.ControlesTB

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class uc_tb_SiNoUnNumeroPrueba
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
            Me.RC = New DevExpress.XtraEditors.GroupControl()
            Me.spnValorCajaTexto = New DevExpress.XtraEditors.SpinEdit()
            Me.RGruop = New DevExpress.XtraEditors.RadioGroup()
            CType(Me.RC, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.RC.SuspendLayout()
            CType(Me.spnValorCajaTexto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.RGruop.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RC
            '
            Me.RC.AppearanceCaption.Options.UseTextOptions = True
            Me.RC.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.RC.Controls.Add(Me.spnValorCajaTexto)
            Me.RC.Controls.Add(Me.RGruop)
            Me.RC.Dock = System.Windows.Forms.DockStyle.Fill
            Me.RC.Location = New System.Drawing.Point(0, 0)
            Me.RC.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.RC.Name = "RC"
            Me.RC.Size = New System.Drawing.Size(136, 49)
            Me.RC.TabIndex = 216
            Me.RC.Text = "Cocina Office"
            Me.RC.UseDisabledStatePainter = False
            '
            'spnValorCajaTexto
            '
            Me.spnValorCajaTexto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.spnValorCajaTexto.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.spnValorCajaTexto.EnterMoveNextControl = True
            Me.spnValorCajaTexto.Location = New System.Drawing.Point(80, 22)
            Me.spnValorCajaTexto.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.spnValorCajaTexto.Name = "spnValorCajaTexto"
            Me.spnValorCajaTexto.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.spnValorCajaTexto.Properties.AppearanceDisabled.Options.UseForeColor = True
            Me.spnValorCajaTexto.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.spnValorCajaTexto.Properties.NullText = "0"
            Me.spnValorCajaTexto.Size = New System.Drawing.Size(55, 20)
            Me.spnValorCajaTexto.TabIndex = 214
            '
            'RGruop
            '
            Me.RGruop.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RGruop.Location = New System.Drawing.Point(5, 23)
            Me.RGruop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.RGruop.Name = "RGruop"
            Me.RGruop.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.RGruop.Properties.Columns = 3
            Me.RGruop.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Sí"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "No")})
            Me.RGruop.Size = New System.Drawing.Size(71, 18)
            Me.RGruop.TabIndex = 213
            '
            'uc_tb_SiNoUnNumeroPrueba
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.RC)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.Name = "uc_tb_SiNoUnNumeroPrueba"
            Me.Size = New System.Drawing.Size(136, 49)
            CType(Me.RC, System.ComponentModel.ISupportInitialize).EndInit()
            Me.RC.ResumeLayout(False)
            CType(Me.spnValorCajaTexto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.RGruop.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RC As DevExpress.XtraEditors.GroupControl
        Friend WithEvents RGruop As DevExpress.XtraEditors.RadioGroup
        Friend WithEvents spnValorCajaTexto As DevExpress.XtraEditors.SpinEdit

    End Class
End Namespace