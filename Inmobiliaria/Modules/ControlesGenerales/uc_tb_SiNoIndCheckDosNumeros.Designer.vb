 
Namespace Venalia.ControlesTB

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class uc_tb_SiNoIndCheckDosNumeros
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
            Me.spnValorCajaTexto2 = New DevExpress.XtraEditors.ButtonEdit()
            Me.spnValorCajaTexto1 = New DevExpress.XtraEditors.ButtonEdit()
            Me.chkValorCheck = New uc_tb_CheckBoxRojoNegro()
            Me.RGruop = New DevExpress.XtraEditors.RadioGroup()
            CType(Me.RC, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.RC.SuspendLayout()
            CType(Me.spnValorCajaTexto2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.spnValorCajaTexto1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.chkValorCheck.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.RGruop.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RC
            '
            Me.RC.AppearanceCaption.Options.UseTextOptions = True
            Me.RC.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.RC.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
            Me.RC.Controls.Add(Me.spnValorCajaTexto2)
            Me.RC.Controls.Add(Me.spnValorCajaTexto1)
            Me.RC.Controls.Add(Me.chkValorCheck)
            Me.RC.Controls.Add(Me.RGruop)
            Me.RC.Dock = System.Windows.Forms.DockStyle.Fill
            Me.RC.Location = New System.Drawing.Point(0, 0)
            Me.RC.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.RC.Name = "RC"
            Me.RC.Size = New System.Drawing.Size(316, 47)
            Me.RC.TabIndex = 216
            Me.RC.Text = "Cocina Office"
            Me.RC.UseDisabledStatePainter = False
            '
            'spnValorCajaTexto2
            '
            Me.spnValorCajaTexto2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.spnValorCajaTexto2.EnterMoveNextControl = True
            Me.spnValorCajaTexto2.Location = New System.Drawing.Point(270, 23)
            Me.spnValorCajaTexto2.Name = "spnValorCajaTexto2"
            Me.spnValorCajaTexto2.Properties.AllowMouseWheel = False
            Me.spnValorCajaTexto2.Properties.Appearance.Options.UseTextOptions = True
            Me.spnValorCajaTexto2.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            Me.spnValorCajaTexto2.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.spnValorCajaTexto2.Properties.AppearanceDisabled.Options.UseForeColor = True
            Me.spnValorCajaTexto2.Properties.DisplayFormat.FormatString = "n0"
            Me.spnValorCajaTexto2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.spnValorCajaTexto2.Properties.Mask.EditMask = "n0"
            Me.spnValorCajaTexto2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
            Me.spnValorCajaTexto2.Size = New System.Drawing.Size(41, 20)
            Me.spnValorCajaTexto2.TabIndex = 268
            '
            'spnValorCajaTexto1
            '
            Me.spnValorCajaTexto1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.spnValorCajaTexto1.EnterMoveNextControl = True
            Me.spnValorCajaTexto1.Location = New System.Drawing.Point(205, 23)
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
            Me.spnValorCajaTexto1.Size = New System.Drawing.Size(64, 20)
            Me.spnValorCajaTexto1.TabIndex = 267
            '
            'chkValorCheck
            '
            Me.chkValorCheck.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.chkValorCheck.Location = New System.Drawing.Point(146, 24)
            Me.chkValorCheck.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.chkValorCheck.Name = "chkValorCheck"
            Me.chkValorCheck.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.chkValorCheck.Properties.Appearance.Options.UseForeColor = True
            Me.chkValorCheck.Properties.Caption = "Cerr."
            Me.chkValorCheck.Properties.ReadOnly = True
            Me.chkValorCheck.Size = New System.Drawing.Size(64, 19)
            Me.chkValorCheck.TabIndex = 216
            Me.chkValorCheck.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.chkValorCheck.tbColorSi = System.Drawing.ColorTranslator.FromHtml("#14b12b")
            '
            'RGruop
            '
            Me.RGruop.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RGruop.Location = New System.Drawing.Point(3, 23)
            Me.RGruop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.RGruop.Name = "RGruop"
            Me.RGruop.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.RGruop.Properties.Columns = 3
            Me.RGruop.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Sí"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "No"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Opc")})
            Me.RGruop.Size = New System.Drawing.Size(137, 20)
            Me.RGruop.TabIndex = 213
            '
            'uc_tb_SiNoIndCheckDosNumeros
            '
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
            Me.Controls.Add(Me.RC)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.Name = "uc_tb_SiNoIndCheckDosNumeros"
            Me.Size = New System.Drawing.Size(316, 47)
            CType(Me.RC, System.ComponentModel.ISupportInitialize).EndInit()
            Me.RC.ResumeLayout(False)
            CType(Me.spnValorCajaTexto2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.spnValorCajaTexto1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.chkValorCheck.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.RGruop.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RC As DevExpress.XtraEditors.GroupControl
        Friend WithEvents RGruop As DevExpress.XtraEditors.RadioGroup
        Friend WithEvents chkValorCheck As uc_tb_CheckBoxRojoNegro
        Friend WithEvents spnValorCajaTexto2 As DevExpress.XtraEditors.ButtonEdit
        Friend WithEvents spnValorCajaTexto1 As DevExpress.XtraEditors.ButtonEdit

    End Class
End Namespace
