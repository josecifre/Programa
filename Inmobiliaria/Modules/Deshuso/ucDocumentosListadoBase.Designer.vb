
Imports Microsoft.VisualBasic
Imports System

Partial Public Class ucDocumentosListadoBase

    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub




    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim lblNumero As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Me.PanelBotones = New DevExpress.XtraEditors.PanelControl()
        Me.btnMesAnterior = New DevExpress.XtraEditors.SimpleButton()
        Me.btnMesSiguiente = New DevExpress.XtraEditors.SimpleButton()
        Me.mskFechaHasta = New DevExpress.XtraEditors.DateEdit()
        Me.mskFechaDesde = New DevExpress.XtraEditors.DateEdit()
        Me.btnBuscar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDuplicarDocumento = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAceptarDocumento = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNuevoDocumento = New DevExpress.XtraEditors.SimpleButton()
        Me.btnImprimir = New DevExpress.XtraEditors.SimpleButton()
        Me.btnEnviar = New DevExpress.XtraEditors.SimpleButton()
        Me.pnlDetallesEnListadosBase = New DevExpress.XtraEditors.PanelControl()
        Me.pnlListado = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.btnSalir = New DevExpress.XtraEditors.SimpleButton()
        Me.dgvx = New MyGridControl()
        Me.Gv = New MyGridView()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        lblNumero = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBotones.SuspendLayout()
        CType(Me.mskFechaHasta.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mskFechaHasta.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mskFechaDesde.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mskFechaDesde.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlDetallesEnListadosBase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlListado.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.dgvx, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblNumero
        '
        lblNumero.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        lblNumero.AutoSize = True
        lblNumero.Location = New System.Drawing.Point(122, 7)
        lblNumero.Name = "lblNumero"
        lblNumero.Size = New System.Drawing.Size(42, 17)
        lblNumero.TabIndex = 111
        lblNumero.Text = "Hasta"
        '
        'Label1
        '
        Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(5, 7)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(46, 17)
        Label1.TabIndex = 112
        Label1.Text = "Desde"
        '
        'PanelBotones
        '
        Me.PanelBotones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelBotones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelBotones.Controls.Add(Me.btnMesAnterior)
        Me.PanelBotones.Controls.Add(Me.btnMesSiguiente)
        Me.PanelBotones.Controls.Add(Label1)
        Me.PanelBotones.Controls.Add(lblNumero)
        Me.PanelBotones.Controls.Add(Me.mskFechaHasta)
        Me.PanelBotones.Controls.Add(Me.mskFechaDesde)
        Me.PanelBotones.Controls.Add(Me.btnBuscar)
        Me.PanelBotones.Location = New System.Drawing.Point(0, 0)
        Me.PanelBotones.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PanelBotones.Name = "PanelBotones"
        Me.PanelBotones.Size = New System.Drawing.Size(979, 64)
        Me.PanelBotones.TabIndex = 18
        '
        'btnMesAnterior
        '
        Me.btnMesAnterior.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnMesAnterior.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnMesAnterior.Appearance.Options.UseBackColor = True
        Me.btnMesAnterior.Appearance.Options.UseTextOptions = True
        Me.btnMesAnterior.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnMesAnterior.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnMesAnterior.Image = My.Resources.Resources.Izquierda
        Me.btnMesAnterior.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnMesAnterior.Location = New System.Drawing.Point(317, 6)
        Me.btnMesAnterior.LookAndFeel.SkinName = "Metropolis"
        Me.btnMesAnterior.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.btnMesAnterior.Name = "btnMesAnterior"
        Me.btnMesAnterior.Size = New System.Drawing.Size(114, 22)
        Me.btnMesAnterior.TabIndex = 115
        Me.btnMesAnterior.Text = "Mes Anterior"
        '
        'btnMesSiguiente
        '
        Me.btnMesSiguiente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnMesSiguiente.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnMesSiguiente.Appearance.Options.UseBackColor = True
        Me.btnMesSiguiente.Appearance.Options.UseTextOptions = True
        Me.btnMesSiguiente.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnMesSiguiente.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnMesSiguiente.Image = My.Resources.Resources.Derecha
        Me.btnMesSiguiente.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.btnMesSiguiente.Location = New System.Drawing.Point(317, 36)
        Me.btnMesSiguiente.LookAndFeel.SkinName = "Metropolis"
        Me.btnMesSiguiente.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.btnMesSiguiente.Name = "btnMesSiguiente"
        Me.btnMesSiguiente.Size = New System.Drawing.Size(127, 22)
        Me.btnMesSiguiente.TabIndex = 114
        Me.btnMesSiguiente.Text = "Mes Siguiente"
        '
        'mskFechaHasta
        '
        Me.mskFechaHasta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.mskFechaHasta.EditValue = Nothing
        Me.mskFechaHasta.EnterMoveNextControl = True
        Me.mskFechaHasta.Location = New System.Drawing.Point(126, 27)
        Me.mskFechaHasta.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.mskFechaHasta.Name = "mskFechaHasta"
        Me.mskFechaHasta.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.75!, System.Drawing.FontStyle.Bold)
        Me.mskFechaHasta.Properties.AppearanceDisabled.Options.UseFont = True
        Me.mskFechaHasta.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.mskFechaHasta.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Strong
        Me.mskFechaHasta.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.mskFechaHasta.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.mskFechaHasta.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.mskFechaHasta.Size = New System.Drawing.Size(114, 22)
        Me.mskFechaHasta.TabIndex = 110
        '
        'mskFechaDesde
        '
        Me.mskFechaDesde.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.mskFechaDesde.EditValue = Nothing
        Me.mskFechaDesde.EnterMoveNextControl = True
        Me.mskFechaDesde.Location = New System.Drawing.Point(5, 27)
        Me.mskFechaDesde.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.mskFechaDesde.Name = "mskFechaDesde"
        Me.mskFechaDesde.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 11.75!, System.Drawing.FontStyle.Bold)
        Me.mskFechaDesde.Properties.AppearanceDisabled.Options.UseFont = True
        Me.mskFechaDesde.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.mskFechaDesde.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Strong
        Me.mskFechaDesde.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.mskFechaDesde.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.mskFechaDesde.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.mskFechaDesde.Size = New System.Drawing.Size(114, 22)
        Me.mskFechaDesde.TabIndex = 109
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnBuscar.Appearance.BorderColor = System.Drawing.Color.White
        Me.btnBuscar.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnBuscar.Appearance.Options.UseBackColor = True
        Me.btnBuscar.Appearance.Options.UseBorderColor = True
        Me.btnBuscar.Appearance.Options.UseFont = True
        Me.btnBuscar.Appearance.Options.UseForeColor = True
        Me.btnBuscar.Appearance.Options.UseTextOptions = True
        Me.btnBuscar.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.btnBuscar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnBuscar.Image = My.Resources.Resources.BuscarDocumento
        Me.btnBuscar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnBuscar.Location = New System.Drawing.Point(252, 7)
        Me.btnBuscar.LookAndFeel.SkinName = "Metropolis"
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(61, 52)
        Me.btnBuscar.TabIndex = 0
        Me.btnBuscar.Text = "Buscar"
        '
        'btnDuplicarDocumento
        '
        Me.btnDuplicarDocumento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDuplicarDocumento.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnDuplicarDocumento.Appearance.Options.UseBackColor = True
        Me.btnDuplicarDocumento.Appearance.Options.UseTextOptions = True
        Me.btnDuplicarDocumento.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnDuplicarDocumento.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnDuplicarDocumento.Image = My.Resources.Resources.DuplicarDocumento
        Me.btnDuplicarDocumento.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnDuplicarDocumento.Location = New System.Drawing.Point(181, 3)
        Me.btnDuplicarDocumento.LookAndFeel.SkinName = "Metropolis"
        Me.btnDuplicarDocumento.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.btnDuplicarDocumento.Name = "btnDuplicarDocumento"
        Me.btnDuplicarDocumento.Size = New System.Drawing.Size(61, 52)
        Me.btnDuplicarDocumento.TabIndex = 120
        Me.btnDuplicarDocumento.Text = "Imprimir"
        Me.btnDuplicarDocumento.ToolTip = "Duplicar Documento"
        '
        'btnAceptarDocumento
        '
        Me.btnAceptarDocumento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAceptarDocumento.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnAceptarDocumento.Appearance.ForeColor = System.Drawing.Color.Red
        Me.btnAceptarDocumento.Appearance.Options.UseBackColor = True
        Me.btnAceptarDocumento.Appearance.Options.UseForeColor = True
        Me.btnAceptarDocumento.Appearance.Options.UseTextOptions = True
        Me.btnAceptarDocumento.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.btnAceptarDocumento.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnAceptarDocumento.Location = New System.Drawing.Point(74, 3)
        Me.btnAceptarDocumento.LookAndFeel.SkinName = "Metropolis"
        Me.btnAceptarDocumento.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.btnAceptarDocumento.Name = "btnAceptarDocumento"
        Me.btnAceptarDocumento.Size = New System.Drawing.Size(100, 52)
        Me.btnAceptarDocumento.TabIndex = 119
        Me.btnAceptarDocumento.Text = "Aprobar/Rechazar"
        Me.btnAceptarDocumento.ToolTip = "Aprobar o Rechazar Documento"
        '
        'btnNuevoDocumento
        '
        Me.btnNuevoDocumento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNuevoDocumento.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnNuevoDocumento.Appearance.Options.UseBackColor = True
        Me.btnNuevoDocumento.Appearance.Options.UseTextOptions = True
        Me.btnNuevoDocumento.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnNuevoDocumento.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnNuevoDocumento.Image = My.Resources.Resources.NuevoDocumento
        Me.btnNuevoDocumento.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnNuevoDocumento.Location = New System.Drawing.Point(2, 3)
        Me.btnNuevoDocumento.LookAndFeel.SkinName = "Metropolis"
        Me.btnNuevoDocumento.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.btnNuevoDocumento.Name = "btnNuevoDocumento"
        Me.btnNuevoDocumento.Size = New System.Drawing.Size(61, 52)
        Me.btnNuevoDocumento.TabIndex = 118
        Me.btnNuevoDocumento.Text = "Imprimir"
        Me.btnNuevoDocumento.ToolTip = "Nuevo Documento"
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImprimir.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnImprimir.Appearance.Options.UseBackColor = True
        Me.btnImprimir.Appearance.Options.UseTextOptions = True
        Me.btnImprimir.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnImprimir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnImprimir.Image = My.Resources.Resources.ImprimirBoton
        Me.btnImprimir.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnImprimir.Location = New System.Drawing.Point(254, 3)
        Me.btnImprimir.LookAndFeel.SkinName = "Metropolis"
        Me.btnImprimir.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(61, 52)
        Me.btnImprimir.TabIndex = 117
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.ToolTip = "Imprimir Documento"
        '
        'btnEnviar
        '
        Me.btnEnviar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEnviar.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnEnviar.Appearance.Options.UseBackColor = True
        Me.btnEnviar.Appearance.Options.UseTextOptions = True
        Me.btnEnviar.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnEnviar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnEnviar.Image = My.Resources.Resources.EmailBoton
        Me.btnEnviar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnEnviar.Location = New System.Drawing.Point(328, 3)
        Me.btnEnviar.LookAndFeel.SkinName = "Metropolis"
        Me.btnEnviar.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(61, 52)
        Me.btnEnviar.TabIndex = 116
        Me.btnEnviar.Text = "Añadir"
        '
        'pnlDetallesEnListadosBase
        '
        Me.pnlDetallesEnListadosBase.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDetallesEnListadosBase.Location = New System.Drawing.Point(0, 0)
        Me.pnlDetallesEnListadosBase.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlDetallesEnListadosBase.Name = "pnlDetallesEnListadosBase"
        Me.pnlDetallesEnListadosBase.Size = New System.Drawing.Size(979, 500)
        Me.pnlDetallesEnListadosBase.TabIndex = 113
        Me.pnlDetallesEnListadosBase.Visible = False
        '
        'pnlListado
        '
        Me.pnlListado.Controls.Add(Me.PanelBotones)
        Me.pnlListado.Controls.Add(Me.PanelControl1)
        Me.pnlListado.Controls.Add(Me.dgvx)
        Me.pnlListado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlListado.Location = New System.Drawing.Point(0, 0)
        Me.pnlListado.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlListado.Name = "pnlListado"
        Me.pnlListado.Size = New System.Drawing.Size(979, 500)
        Me.pnlListado.TabIndex = 19
        '
        'PanelControl1
        '
        Me.PanelControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelControl1.Controls.Add(Me.btnSalir)
        Me.PanelControl1.Controls.Add(Me.btnDuplicarDocumento)
        Me.PanelControl1.Controls.Add(Me.btnAceptarDocumento)
        Me.PanelControl1.Controls.Add(Me.btnNuevoDocumento)
        Me.PanelControl1.Controls.Add(Me.btnImprimir)
        Me.PanelControl1.Controls.Add(Me.btnEnviar)
        Me.PanelControl1.Location = New System.Drawing.Point(5, 439)
        Me.PanelControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(969, 57)
        Me.PanelControl1.TabIndex = 121
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnSalir.Appearance.Options.UseBackColor = True
        Me.btnSalir.Appearance.Options.UseTextOptions = True
        Me.btnSalir.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnSalir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnSalir.Image = My.Resources.Resources.Salir
        Me.btnSalir.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnSalir.Location = New System.Drawing.Point(905, 3)
        Me.btnSalir.LookAndFeel.SkinName = "Metropolis"
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(61, 52)
        Me.btnSalir.TabIndex = 121
        Me.btnSalir.Text = "Salir"
        '
        'dgvx
        '
        Me.dgvx.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvx.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvx.Location = New System.Drawing.Point(0, 65)
        Me.dgvx.MainView = Me.Gv
        Me.dgvx.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvx.Name = "dgvx"
        Me.dgvx.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1})
        Me.dgvx.Size = New System.Drawing.Size(979, 363)
        Me.dgvx.TabIndex = 1
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
        'DockManager1
        '
        Me.DockManager1.Form = Me
        Me.DockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.StatusBar", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl"})
        '
        'ucDocumentosListadoBase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlListado)
        Me.Controls.Add(Me.pnlDetallesEnListadosBase)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "ucDocumentosListadoBase"
        Me.Size = New System.Drawing.Size(979, 500)
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBotones.ResumeLayout(False)
        Me.PanelBotones.PerformLayout()
        CType(Me.mskFechaHasta.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mskFechaHasta.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mskFechaDesde.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mskFechaDesde.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlDetallesEnListadosBase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlListado.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.dgvx, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelBotones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnBuscar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pnlListado As DevExpress.XtraEditors.PanelControl
    Friend WithEvents dgvx As MyGridControl
    Friend WithEvents Gv As MyGridView
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents mskFechaDesde As DevExpress.XtraEditors.DateEdit
    Friend WithEvents mskFechaHasta As DevExpress.XtraEditors.DateEdit
    Friend WithEvents pnlDetallesEnListadosBase As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnMesAnterior As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnMesSiguiente As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnDuplicarDocumento As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAceptarDocumento As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnNuevoDocumento As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnImprimir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnEnviar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnSalir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager

End Class

