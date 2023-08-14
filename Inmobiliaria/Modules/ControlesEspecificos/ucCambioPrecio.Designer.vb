<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucCambioPrecio
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
        Me.pnlPreciosPublico = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.spnPrecioVenta = New DevExpress.XtraEditors.SpinEdit()
        Me.pnlPreciosPropietarios = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.spnPrecioVentaProp = New DevExpress.XtraEditors.SpinEdit()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.btnAceptar = New uc_tb_SimpleButton()
        Me.btnSalir = New uc_tb_SimpleButton()
        Me.dgvx = New MyGridControl()
        Me.Gv = New MyGridView()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        CType(Me.pnlPreciosPublico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPreciosPublico.SuspendLayout()
        CType(Me.spnPrecioVenta.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlPreciosPropietarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPreciosPropietarios.SuspendLayout()
        CType(Me.spnPrecioVentaProp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.dgvx, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlPreciosPublico
        '
        Me.pnlPreciosPublico.Controls.Add(Me.LabelControl3)
        Me.pnlPreciosPublico.Controls.Add(Me.LabelControl4)
        Me.pnlPreciosPublico.Controls.Add(Me.spnPrecioVenta)
        Me.pnlPreciosPublico.Location = New System.Drawing.Point(325, 3)
        Me.pnlPreciosPublico.Name = "pnlPreciosPublico"
        Me.pnlPreciosPublico.Size = New System.Drawing.Size(317, 46)
        Me.pnlPreciosPublico.TabIndex = 206
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.LabelControl3.Location = New System.Drawing.Point(247, 17)
        Me.LabelControl3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl3.TabIndex = 250
        Me.LabelControl3.Text = "Público"
        Me.LabelControl3.Visible = False
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.LabelControl4.Location = New System.Drawing.Point(8, 17)
        Me.LabelControl4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl4.TabIndex = 244
        Me.LabelControl4.Text = "Precio Público"
        '
        'spnPrecioVenta
        '
        Me.spnPrecioVenta.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.spnPrecioVenta.EnterMoveNextControl = True
        Me.spnPrecioVenta.Location = New System.Drawing.Point(119, 14)
        Me.spnPrecioVenta.Name = "spnPrecioVenta"
        Me.spnPrecioVenta.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.spnPrecioVenta.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.spnPrecioVenta.Properties.DisplayFormat.FormatString = "n0"
        Me.spnPrecioVenta.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.spnPrecioVenta.Properties.EditFormat.FormatString = "n0"
        Me.spnPrecioVenta.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.spnPrecioVenta.Properties.Mask.EditMask = "n0"
        Me.spnPrecioVenta.Properties.NullText = "0"
        Me.spnPrecioVenta.Size = New System.Drawing.Size(104, 20)
        Me.spnPrecioVenta.TabIndex = 1
        '
        'pnlPreciosPropietarios
        '
        Me.pnlPreciosPropietarios.Controls.Add(Me.LabelControl13)
        Me.pnlPreciosPropietarios.Controls.Add(Me.LabelControl9)
        Me.pnlPreciosPropietarios.Controls.Add(Me.spnPrecioVentaProp)
        Me.pnlPreciosPropietarios.Location = New System.Drawing.Point(3, 3)
        Me.pnlPreciosPropietarios.Name = "pnlPreciosPropietarios"
        Me.pnlPreciosPropietarios.Size = New System.Drawing.Size(319, 46)
        Me.pnlPreciosPropietarios.TabIndex = 245
        '
        'LabelControl13
        '
        Me.LabelControl13.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.LabelControl13.Location = New System.Drawing.Point(9, 17)
        Me.LabelControl13.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(84, 13)
        Me.LabelControl13.TabIndex = 248
        Me.LabelControl13.Text = "Precio Propietario"
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.LabelControl9.Location = New System.Drawing.Point(256, 17)
        Me.LabelControl9.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(52, 13)
        Me.LabelControl9.TabIndex = 247
        Me.LabelControl9.Text = "Propietario"
        Me.LabelControl9.Visible = False
        '
        'spnPrecioVentaProp
        '
        Me.spnPrecioVentaProp.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.spnPrecioVentaProp.EnterMoveNextControl = True
        Me.spnPrecioVentaProp.Location = New System.Drawing.Point(146, 14)
        Me.spnPrecioVentaProp.Name = "spnPrecioVentaProp"
        Me.spnPrecioVentaProp.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.spnPrecioVentaProp.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.spnPrecioVentaProp.Properties.DisplayFormat.FormatString = "n0"
        Me.spnPrecioVentaProp.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.spnPrecioVentaProp.Properties.EditFormat.FormatString = "n0"
        Me.spnPrecioVentaProp.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.spnPrecioVentaProp.Properties.Mask.EditMask = "n0"
        Me.spnPrecioVentaProp.Properties.NullText = "0"
        Me.spnPrecioVentaProp.Size = New System.Drawing.Size(104, 20)
        Me.spnPrecioVentaProp.TabIndex = 0
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.btnAceptar)
        Me.PanelControl2.Controls.Add(Me.btnSalir)
        Me.PanelControl2.Location = New System.Drawing.Point(0, 236)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(645, 63)
        Me.PanelControl2.TabIndex = 247
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnAceptar.Appearance.Options.UseBackColor = True
        Me.btnAceptar.Appearance.Options.UseForeColor = True
        Me.btnAceptar.Appearance.Options.UseTextOptions = True
        Me.btnAceptar.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.btnAceptar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnAceptar.Image = Global.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(432, 4)
        Me.btnAceptar.LookAndFeel.SkinName = "Metropolis"
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(134, 55)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "Cambiar Precios"
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
        Me.btnSalir.Location = New System.Drawing.Point(572, 4)
        Me.btnSalir.LookAndFeel.SkinName = "Metropolis"
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(68, 55)
        Me.btnSalir.TabIndex = 5
        Me.btnSalir.Text = "Salir"
        '
        'dgvx
        '
        Me.dgvx.ColumnaCheck = Nothing
        Me.dgvx.Location = New System.Drawing.Point(3, 55)
        Me.dgvx.MainView = Me.Gv
        Me.dgvx.Name = "dgvx"
        Me.dgvx.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1})
        Me.dgvx.Size = New System.Drawing.Size(642, 181)
        Me.dgvx.TabIndex = 2
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
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'ucCambioPrecio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.dgvx)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.pnlPreciosPropietarios)
        Me.Controls.Add(Me.pnlPreciosPublico)
        Me.Name = "ucCambioPrecio"
        Me.Size = New System.Drawing.Size(645, 299)
        CType(Me.pnlPreciosPublico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPreciosPublico.ResumeLayout(False)
        Me.pnlPreciosPublico.PerformLayout()
        CType(Me.spnPrecioVenta.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlPreciosPropietarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPreciosPropietarios.ResumeLayout(False)
        Me.pnlPreciosPropietarios.PerformLayout()
        CType(Me.spnPrecioVentaProp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.dgvx, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlPreciosPublico As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents pnlPreciosPropietarios As DevExpress.XtraEditors.PanelControl
    Friend WithEvents spnPrecioVenta As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents spnPrecioVentaProp As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnAceptar As uc_tb_SimpleButton
    Friend WithEvents btnSalir As uc_tb_SimpleButton
    Friend WithEvents dgvx As MyGridControl
    Friend WithEvents Gv As MyGridView
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl

End Class
