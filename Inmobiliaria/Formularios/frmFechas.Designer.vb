<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFechas
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
        Dim Label1 As System.Windows.Forms.Label
        Dim lblNumero As System.Windows.Forms.Label
        Me.mskFechaHasta = New DevExpress.XtraEditors.DateEdit()
        Me.mskFechaDesde = New DevExpress.XtraEditors.DateEdit()
        Me.PanelBotones = New DevExpress.XtraEditors.PanelControl()
        Me.btnMesAnterior = New uc_tb_SimpleButton()
        Me.btnMesSiguiente = New uc_tb_SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.btnSalir = New uc_tb_SimpleButton()
        Me.btnBuscar = New uc_tb_SimpleButton()
        Me.dgvx = New MyGridControl()
        Me.Gv = New MyGridView()
        Me.panelComoConociste = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl16 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbComoConociste = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.chkAgrupar = New uc_tb_CheckBoxRojoNegro()
        Label1 = New System.Windows.Forms.Label()
        lblNumero = New System.Windows.Forms.Label()
        CType(Me.mskFechaHasta.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mskFechaHasta.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mskFechaDesde.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mskFechaDesde.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBotones.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.dgvx, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.panelComoConociste, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelComoConociste.SuspendLayout()
        CType(Me.cmbComoConociste.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAgrupar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(8, 6)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(37, 13)
        Label1.TabIndex = 116
        Label1.Text = "Desde"
        '
        'lblNumero
        '
        lblNumero.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        lblNumero.AutoSize = True
        lblNumero.Location = New System.Drawing.Point(114, 6)
        lblNumero.Name = "lblNumero"
        lblNumero.Size = New System.Drawing.Size(35, 13)
        lblNumero.TabIndex = 115
        lblNumero.Text = "Hasta"
        '
        'mskFechaHasta
        '
        Me.mskFechaHasta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mskFechaHasta.EditValue = Nothing
        Me.mskFechaHasta.EnterMoveNextControl = True
        Me.mskFechaHasta.Location = New System.Drawing.Point(115, 25)
        Me.mskFechaHasta.Name = "mskFechaHasta"
        Me.mskFechaHasta.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.75!, System.Drawing.FontStyle.Bold)
        Me.mskFechaHasta.Properties.AppearanceDisabled.Options.UseFont = True
        Me.mskFechaHasta.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.mskFechaHasta.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Strong
        Me.mskFechaHasta.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.mskFechaHasta.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.mskFechaHasta.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.mskFechaHasta.Size = New System.Drawing.Size(104, 20)
        Me.mskFechaHasta.TabIndex = 2
        '
        'mskFechaDesde
        '
        Me.mskFechaDesde.EditValue = Nothing
        Me.mskFechaDesde.EnterMoveNextControl = True
        Me.mskFechaDesde.Location = New System.Drawing.Point(5, 25)
        Me.mskFechaDesde.Name = "mskFechaDesde"
        Me.mskFechaDesde.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.75!, System.Drawing.FontStyle.Bold)
        Me.mskFechaDesde.Properties.AppearanceDisabled.Options.UseFont = True
        Me.mskFechaDesde.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.mskFechaDesde.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Strong
        Me.mskFechaDesde.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.mskFechaDesde.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.mskFechaDesde.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.mskFechaDesde.Size = New System.Drawing.Size(104, 20)
        Me.mskFechaDesde.TabIndex = 1
        '
        'PanelBotones
        '
        Me.PanelBotones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelBotones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelBotones.Controls.Add(Me.btnMesAnterior)
        Me.PanelBotones.Controls.Add(Label1)
        Me.PanelBotones.Controls.Add(Me.btnMesSiguiente)
        Me.PanelBotones.Controls.Add(lblNumero)
        Me.PanelBotones.Controls.Add(Me.mskFechaHasta)
        Me.PanelBotones.Controls.Add(Me.mskFechaDesde)
        Me.PanelBotones.Location = New System.Drawing.Point(1, 3)
        Me.PanelBotones.Name = "PanelBotones"
        Me.PanelBotones.Size = New System.Drawing.Size(222, 126)
        Me.PanelBotones.TabIndex = 117
        '
        'btnMesAnterior
        '
        Me.btnMesAnterior.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnMesAnterior.Appearance.Options.UseBackColor = True
        Me.btnMesAnterior.Appearance.Options.UseTextOptions = True
        Me.btnMesAnterior.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnMesAnterior.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnMesAnterior.Image = Global.My.Resources.Resources.Back_32x32
        Me.btnMesAnterior.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnMesAnterior.Location = New System.Drawing.Point(5, 61)
        Me.btnMesAnterior.LookAndFeel.SkinName = "Metropolis"
        Me.btnMesAnterior.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnMesAnterior.Name = "btnMesAnterior"
        Me.btnMesAnterior.Size = New System.Drawing.Size(104, 61)
        Me.btnMesAnterior.TabIndex = 3
        Me.btnMesAnterior.Text = "Mes Anterior"
        '
        'btnMesSiguiente
        '
        Me.btnMesSiguiente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMesSiguiente.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnMesSiguiente.Appearance.Options.UseBackColor = True
        Me.btnMesSiguiente.Appearance.Options.UseTextOptions = True
        Me.btnMesSiguiente.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnMesSiguiente.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnMesSiguiente.Image = Global.My.Resources.Resources.Forward_32x32
        Me.btnMesSiguiente.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnMesSiguiente.Location = New System.Drawing.Point(115, 61)
        Me.btnMesSiguiente.LookAndFeel.SkinName = "Metropolis"
        Me.btnMesSiguiente.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnMesSiguiente.Name = "btnMesSiguiente"
        Me.btnMesSiguiente.Size = New System.Drawing.Size(104, 61)
        Me.btnMesSiguiente.TabIndex = 4
        Me.btnMesSiguiente.Text = "Mes Siguiente"
        '
        'PanelControl1
        '
        Me.PanelControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelControl1.Controls.Add(Me.btnSalir)
        Me.PanelControl1.Controls.Add(Me.btnBuscar)
        Me.PanelControl1.Location = New System.Drawing.Point(0, 335)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(225, 64)
        Me.PanelControl1.TabIndex = 118
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
        Me.btnSalir.Location = New System.Drawing.Point(143, 5)
        Me.btnSalir.LookAndFeel.SkinName = "Metropolis"
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(77, 55)
        Me.btnSalir.TabIndex = 6
        Me.btnSalir.Text = "Salir"
        '
        'btnBuscar
        '
        Me.btnBuscar.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnBuscar.Appearance.BorderColor = System.Drawing.Color.White
        Me.btnBuscar.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnBuscar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnBuscar.Appearance.Options.UseBackColor = True
        Me.btnBuscar.Appearance.Options.UseBorderColor = True
        Me.btnBuscar.Appearance.Options.UseFont = True
        Me.btnBuscar.Appearance.Options.UseForeColor = True
        Me.btnBuscar.Appearance.Options.UseTextOptions = True
        Me.btnBuscar.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnBuscar.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.btnBuscar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnBuscar.Image = Global.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(5, 5)
        Me.btnBuscar.LookAndFeel.SkinName = "Metropolis"
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(133, 55)
        Me.btnBuscar.TabIndex = 5
        Me.btnBuscar.Text = "Buscar"
        '
        'dgvx
        '
        Me.dgvx.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvx.ColumnaCheck = Nothing
        Me.dgvx.Location = New System.Drawing.Point(1, 131)
        Me.dgvx.MainView = Me.Gv
        Me.dgvx.Name = "dgvx"
        Me.dgvx.Size = New System.Drawing.Size(219, 198)
        Me.dgvx.TabIndex = 119
        Me.dgvx.tb_AnadirColumnaCheck = False
        Me.dgvx.tbPerfilPredeterminado = ""
        Me.dgvx.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Gv})
        '
        'Gv
        '
        Me.Gv.GridControl = Me.dgvx
        Me.Gv.Name = "Gv"
        '
        'panelComoConociste
        '
        Me.panelComoConociste.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelComoConociste.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.panelComoConociste.Controls.Add(Me.chkAgrupar)
        Me.panelComoConociste.Controls.Add(Me.LabelControl16)
        Me.panelComoConociste.Controls.Add(Me.cmbComoConociste)
        Me.panelComoConociste.Location = New System.Drawing.Point(1, 131)
        Me.panelComoConociste.Name = "panelComoConociste"
        Me.panelComoConociste.Size = New System.Drawing.Size(222, 127)
        Me.panelComoConociste.TabIndex = 118
        Me.panelComoConociste.Visible = False
        '
        'LabelControl16
        '
        Me.LabelControl16.Location = New System.Drawing.Point(11, 59)
        Me.LabelControl16.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl16.Name = "LabelControl16"
        Me.LabelControl16.Size = New System.Drawing.Size(95, 13)
        Me.LabelControl16.TabIndex = 207
        Me.LabelControl16.Text = "Cómo nos conociste"
        '
        'cmbComoConociste
        '
        Me.cmbComoConociste.EnterMoveNextControl = True
        Me.cmbComoConociste.Location = New System.Drawing.Point(11, 77)
        Me.cmbComoConociste.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cmbComoConociste.Name = "cmbComoConociste"
        Me.cmbComoConociste.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cmbComoConociste.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.cmbComoConociste.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cmbComoConociste.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbComoConociste.Properties.View = Me.GridView5
        Me.cmbComoConociste.Size = New System.Drawing.Size(174, 20)
        Me.cmbComoConociste.TabIndex = 206
        '
        'GridView5
        '
        Me.GridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView5.Name = "GridView5"
        Me.GridView5.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView5.OptionsView.ShowGroupPanel = False
        '
        'chkAgrupar
        '
        Me.chkAgrupar.Location = New System.Drawing.Point(11, 21)
        Me.chkAgrupar.Name = "chkAgrupar"
        Me.chkAgrupar.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkAgrupar.Properties.Appearance.Options.UseForeColor = True
        Me.chkAgrupar.Properties.AutoWidth = True
        Me.chkAgrupar.Properties.Caption = "Agrupar"
        Me.chkAgrupar.Properties.ReadOnly = True
        Me.chkAgrupar.Size = New System.Drawing.Size(61, 19)
        Me.chkAgrupar.TabIndex = 208
        Me.chkAgrupar.tbColorNo = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkAgrupar.tbColorSi = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(43, Byte), Integer))
        '
        'frmFechas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(225, 400)
        Me.ControlBox = False
        Me.Controls.Add(Me.panelComoConociste)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PanelBotones)
        Me.Controls.Add(Me.dgvx)
        Me.Name = "frmFechas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Filtro Fechas"
        CType(Me.mskFechaHasta.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mskFechaHasta.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mskFechaDesde.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mskFechaDesde.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBotones.ResumeLayout(False)
        Me.PanelBotones.PerformLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.dgvx, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.panelComoConociste, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelComoConociste.ResumeLayout(False)
        Me.panelComoConociste.PerformLayout()
        CType(Me.cmbComoConociste.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAgrupar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents mskFechaHasta As DevExpress.XtraEditors.DateEdit
    Friend WithEvents mskFechaDesde As DevExpress.XtraEditors.DateEdit
    Friend WithEvents PanelBotones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnMesAnterior As uc_tb_SimpleButton
    Friend WithEvents btnMesSiguiente As uc_tb_SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnSalir As uc_tb_SimpleButton
    Friend WithEvents btnBuscar As uc_tb_SimpleButton
    Friend WithEvents dgvx As MyGridControl
    Friend WithEvents Gv As MyGridView
    Friend WithEvents panelComoConociste As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl16 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbComoConociste As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents chkAgrupar As uc_tb_CheckBoxRojoNegro
End Class
