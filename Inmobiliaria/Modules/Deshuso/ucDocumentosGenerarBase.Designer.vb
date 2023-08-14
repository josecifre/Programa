Imports Microsoft.VisualBasic
Imports System

Partial Public Class ucDocumentosGenerarBase

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
        Dim Label1 As System.Windows.Forms.Label
        Dim FormaPagoLabel As System.Windows.Forms.Label
        Dim lblNumero As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label9 As System.Windows.Forms.Label
        Dim Label10 As System.Windows.Forms.Label
        Dim Label11 As System.Windows.Forms.Label
        Dim Label12 As System.Windows.Forms.Label
        Dim Label13 As System.Windows.Forms.Label
        Dim Label14 As System.Windows.Forms.Label
        Dim Label15 As System.Windows.Forms.Label
        Dim Label16 As System.Windows.Forms.Label
        Dim Label17 As System.Windows.Forms.Label
        Dim Label18 As System.Windows.Forms.Label
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SuperToolTip3 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem3 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SuperToolTip4 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem4 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SerializableAppearanceObject5 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SuperToolTip5 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem5 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SerializableAppearanceObject6 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SuperToolTip6 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem6 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Me.PanelBotones = New DevExpress.XtraEditors.PanelControl()
        Me.btnArticulosVendidos = New DevExpress.XtraEditors.SimpleButton()
        Me.btnRiesgo = New DevExpress.XtraEditors.SimpleButton()
        Me.btnEliminarDocumento = New DevExpress.XtraEditors.SimpleButton()
        Me.btnImprimir = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSalir = New DevExpress.XtraEditors.SimpleButton()
        Me.btnEnviar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnModificar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnEliminar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAnadir = New DevExpress.XtraEditors.SimpleButton()
        Me.dgvx = New MyGridControl()
        Me.Gv = New MyGridView()
        Me.PanelDatosGenerales = New DevExpress.XtraEditors.PanelControl()
        Me.mskFechaEntrega = New DevExpress.XtraEditors.DateEdit()
        Me.cmbSeriesFacturacion = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.mskFecha = New DevExpress.XtraEditors.DateEdit()
        Me.cmbEmpleados = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.txtNumero = New DevExpress.XtraEditors.TextEdit()
        Me.cmbAlmacenes = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cmbFormasPago = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelDatosCliente = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl28 = New DevExpress.XtraEditors.LabelControl()
        Me.spnDescuentoPP = New DevExpress.XtraEditors.SpinEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.spnDescuentoEsp = New DevExpress.XtraEditors.SpinEdit()
        Me.cmbDireccionesEnvio = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.txtEmail = New DevExpress.XtraEditors.TextEdit()
        Me.txtFax = New DevExpress.XtraEditors.TextEdit()
        Me.txtTelefono2 = New DevExpress.XtraEditors.TextEdit()
        Me.txtTelefono1 = New DevExpress.XtraEditors.TextEdit()
        Me.txtNombreComercial = New DevExpress.XtraEditors.TextEdit()
        Me.txtProvincia = New DevExpress.XtraEditors.TextEdit()
        Me.txtPoblacion = New DevExpress.XtraEditors.TextEdit()
        Me.txtCodPostal = New DevExpress.XtraEditors.TextEdit()
        Me.txtDireccion = New DevExpress.XtraEditors.TextEdit()
        Me.cmbClientes = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.txtNIF = New DevExpress.XtraEditors.TextEdit()
        Me.txtTotal = New DevExpress.XtraEditors.TextEdit()
        Me.txtIVA = New DevExpress.XtraEditors.TextEdit()
        Me.txtBI = New DevExpress.XtraEditors.TextEdit()
        Me.pnlDetalle = New DevExpress.XtraEditors.PanelControl()
        Me.PanelDatosObservaciones = New DevExpress.XtraEditors.PanelControl()
        Me.txtObservaciones = New DevExpress.XtraEditors.MemoEdit()
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.txtImporte = New DevExpress.XtraEditors.TextEdit()
        Me.txtDtoPPImporte = New DevExpress.XtraEditors.TextEdit()
        Label1 = New System.Windows.Forms.Label()
        FormaPagoLabel = New System.Windows.Forms.Label()
        lblNumero = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Label4 = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        Label7 = New System.Windows.Forms.Label()
        Label8 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        Label5 = New System.Windows.Forms.Label()
        Label9 = New System.Windows.Forms.Label()
        Label10 = New System.Windows.Forms.Label()
        Label11 = New System.Windows.Forms.Label()
        Label12 = New System.Windows.Forms.Label()
        Label13 = New System.Windows.Forms.Label()
        Label14 = New System.Windows.Forms.Label()
        Label15 = New System.Windows.Forms.Label()
        Label16 = New System.Windows.Forms.Label()
        Label17 = New System.Windows.Forms.Label()
        Label18 = New System.Windows.Forms.Label()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBotones.SuspendLayout()
        CType(Me.dgvx, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelDatosGenerales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDatosGenerales.SuspendLayout()
        CType(Me.mskFechaEntrega.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mskFechaEntrega.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbSeriesFacturacion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mskFecha.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mskFecha.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbEmpleados.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumero.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbAlmacenes.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbFormasPago.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelDatosCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDatosCliente.SuspendLayout()
        CType(Me.spnDescuentoPP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spnDescuentoEsp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbDireccionesEnvio.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTelefono2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTelefono1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombreComercial.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProvincia.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPoblacion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodPostal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDireccion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbClientes.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNIF.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIVA.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBI.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDetalle.SuspendLayout()
        CType(Me.PanelDatosObservaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDatosObservaciones.SuspendLayout()
        CType(Me.txtObservaciones.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImporte.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDtoPPImporte.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(1, 89)
        Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(53, 13)
        Label1.TabIndex = 104
        Label1.Text = "Vendedor"
        '
        'FormaPagoLabel
        '
        FormaPagoLabel.AutoSize = True
        FormaPagoLabel.Location = New System.Drawing.Point(5, 43)
        FormaPagoLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        FormaPagoLabel.Name = "FormaPagoLabel"
        FormaPagoLabel.Size = New System.Drawing.Size(64, 13)
        FormaPagoLabel.TabIndex = 102
        FormaPagoLabel.Text = "Forma Pago"
        '
        'lblNumero
        '
        lblNumero.AutoSize = True
        lblNumero.Location = New System.Drawing.Point(175, 3)
        lblNumero.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        lblNumero.Name = "lblNumero"
        lblNumero.Size = New System.Drawing.Size(44, 13)
        lblNumero.TabIndex = 100
        lblNumero.Text = "Número"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(5, 4)
        Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(47, 13)
        Label2.TabIndex = 106
        Label2.Text = "Almacén"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(2, 5)
        Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(40, 13)
        Label4.TabIndex = 104
        Label4.Text = "Cliente"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Location = New System.Drawing.Point(229, 5)
        Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(45, 13)
        Label6.TabIndex = 100
        Label6.Text = "NIF/CIF"
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.Location = New System.Drawing.Point(68, 43)
        Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(50, 13)
        Label7.TabIndex = 108
        Label7.Text = "Dirección"
        Label7.Visible = False
        AddHandler Label7.Click, AddressOf Me.Label7_Click
        '
        'Label8
        '
        Label8.AutoSize = True
        Label8.Location = New System.Drawing.Point(2, 43)
        Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(50, 13)
        Label8.TabIndex = 110
        Label8.Text = "C. Postal"
        Label8.Visible = False
        AddHandler Label8.Click, AddressOf Me.Label8_Click
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(24, 42)
        Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(52, 13)
        Label3.TabIndex = 112
        Label3.Text = "Población"
        Label3.Visible = False
        AddHandler Label3.Click, AddressOf Me.Label3_Click
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(21, 44)
        Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(50, 13)
        Label5.TabIndex = 114
        Label5.Text = "Provincia"
        Label5.Visible = False
        '
        'Label9
        '
        Label9.AutoSize = True
        Label9.Location = New System.Drawing.Point(2, 43)
        Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label9.Name = "Label9"
        Label9.Size = New System.Drawing.Size(36, 13)
        Label9.TabIndex = 109
        Label9.Text = "Fecha"
        '
        'Label10
        '
        Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label10.AutoSize = True
        Label10.Location = New System.Drawing.Point(487, 313)
        Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label10.Name = "Label10"
        Label10.Size = New System.Drawing.Size(55, 13)
        Label10.TabIndex = 122
        Label10.Text = "Base Imp."
        '
        'Label11
        '
        Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label11.AutoSize = True
        Label11.Location = New System.Drawing.Point(641, 313)
        Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label11.Name = "Label11"
        Label11.Size = New System.Drawing.Size(24, 13)
        Label11.TabIndex = 123
        Label11.Text = "IVA"
        '
        'Label12
        '
        Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label12.AutoSize = True
        Label12.Location = New System.Drawing.Point(749, 313)
        Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label12.Name = "Label12"
        Label12.Size = New System.Drawing.Size(31, 13)
        Label12.TabIndex = 124
        Label12.Text = "Total"
        '
        'Label13
        '
        Label13.AutoSize = True
        Label13.Location = New System.Drawing.Point(2, 3)
        Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label13.Name = "Label13"
        Label13.Size = New System.Drawing.Size(31, 13)
        Label13.TabIndex = 111
        Label13.Text = "Serie"
        '
        'Label14
        '
        Label14.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label14.AutoSize = True
        Label14.Location = New System.Drawing.Point(5, 44)
        Label14.Name = "Label14"
        Label14.Size = New System.Drawing.Size(78, 13)
        Label14.TabIndex = 92
        Label14.Text = "Observaciones"
        '
        'Label15
        '
        Label15.AutoSize = True
        Label15.Location = New System.Drawing.Point(131, 43)
        Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label15.Name = "Label15"
        Label15.Size = New System.Drawing.Size(77, 13)
        Label15.TabIndex = 113
        Label15.Text = "Fecha Entrega"
        '
        'Label16
        '
        Label16.AutoSize = True
        Label16.Location = New System.Drawing.Point(2, 89)
        Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label16.Name = "Label16"
        Label16.Size = New System.Drawing.Size(94, 13)
        Label16.TabIndex = 122
        Label16.Text = "Dirección de Envio"
        '
        'Label17
        '
        Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label17.AutoSize = True
        Label17.Location = New System.Drawing.Point(240, 313)
        Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label17.Name = "Label17"
        Label17.Size = New System.Drawing.Size(45, 13)
        Label17.TabIndex = 126
        Label17.Text = "Importe"
        '
        'Label18
        '
        Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label18.AutoSize = True
        Label18.Location = New System.Drawing.Point(357, 313)
        Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label18.Name = "Label18"
        Label18.Size = New System.Drawing.Size(43, 13)
        Label18.TabIndex = 128
        Label18.Text = "Dto. PP"
        '
        'PanelBotones
        '
        Me.PanelBotones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelBotones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelBotones.Controls.Add(Me.btnArticulosVendidos)
        Me.PanelBotones.Controls.Add(Me.btnRiesgo)
        Me.PanelBotones.Controls.Add(Me.btnEliminarDocumento)
        Me.PanelBotones.Controls.Add(Me.btnImprimir)
        Me.PanelBotones.Controls.Add(Me.btnSalir)
        Me.PanelBotones.Controls.Add(Me.btnEnviar)
        Me.PanelBotones.Controls.Add(Me.btnAceptar)
        Me.PanelBotones.Controls.Add(Me.btnModificar)
        Me.PanelBotones.Controls.Add(Me.btnEliminar)
        Me.PanelBotones.Controls.Add(Me.btnAnadir)
        Me.PanelBotones.Location = New System.Drawing.Point(3, 357)
        Me.PanelBotones.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PanelBotones.Name = "PanelBotones"
        Me.PanelBotones.Size = New System.Drawing.Size(834, 46)
        Me.PanelBotones.TabIndex = 3
        '
        'btnArticulosVendidos
        '
        Me.btnArticulosVendidos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnArticulosVendidos.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnArticulosVendidos.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnArticulosVendidos.Appearance.Options.UseBackColor = True
        Me.btnArticulosVendidos.Appearance.Options.UseForeColor = True
        Me.btnArticulosVendidos.Appearance.Options.UseTextOptions = True
        Me.btnArticulosVendidos.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.btnArticulosVendidos.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnArticulosVendidos.Location = New System.Drawing.Point(317, 5)
        Me.btnArticulosVendidos.LookAndFeel.SkinName = "Metropolis"
        Me.btnArticulosVendidos.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnArticulosVendidos.Name = "btnArticulosVendidos"
        Me.btnArticulosVendidos.Size = New System.Drawing.Size(84, 42)
        Me.btnArticulosVendidos.TabIndex = 123
        Me.btnArticulosVendidos.Text = "Gestión Documental"
        '
        'btnRiesgo
        '
        Me.btnRiesgo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRiesgo.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnRiesgo.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnRiesgo.Appearance.Options.UseBackColor = True
        Me.btnRiesgo.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnRiesgo.Image = Global.My.Resources.Resources.Riesgo
        Me.btnRiesgo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnRiesgo.Location = New System.Drawing.Point(255, 5)
        Me.btnRiesgo.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnRiesgo.Name = "btnRiesgo"
        Me.btnRiesgo.Size = New System.Drawing.Size(52, 42)
        Me.btnRiesgo.TabIndex = 16
        Me.btnRiesgo.Text = "Riesgo"
        Me.btnRiesgo.ToolTip = "Ver Riesgo"
        '
        'btnEliminarDocumento
        '
        Me.btnEliminarDocumento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEliminarDocumento.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnEliminarDocumento.Appearance.Options.UseBackColor = True
        Me.btnEliminarDocumento.Appearance.Options.UseTextOptions = True
        Me.btnEliminarDocumento.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnEliminarDocumento.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnEliminarDocumento.Image = Global.My.Resources.Resources.EliminarDocumento
        Me.btnEliminarDocumento.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnEliminarDocumento.Location = New System.Drawing.Point(3, 4)
        Me.btnEliminarDocumento.LookAndFeel.SkinName = "Metropolis"
        Me.btnEliminarDocumento.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnEliminarDocumento.Name = "btnEliminarDocumento"
        Me.btnEliminarDocumento.Size = New System.Drawing.Size(52, 42)
        Me.btnEliminarDocumento.TabIndex = 14
        Me.btnEliminarDocumento.Text = "Imprimir"
        Me.btnEliminarDocumento.ToolTip = "Eliminar Documento"
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImprimir.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnImprimir.Appearance.Options.UseBackColor = True
        Me.btnImprimir.Appearance.Options.UseTextOptions = True
        Me.btnImprimir.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnImprimir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnImprimir.Image = Global.My.Resources.Resources.ImprimirBoton
        Me.btnImprimir.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnImprimir.Location = New System.Drawing.Point(129, 4)
        Me.btnImprimir.LookAndFeel.SkinName = "Metropolis"
        Me.btnImprimir.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(52, 42)
        Me.btnImprimir.TabIndex = 12
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.ToolTip = "Imprimir Documento"
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnSalir.Appearance.Options.UseBackColor = True
        Me.btnSalir.Appearance.Options.UseTextOptions = True
        Me.btnSalir.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnSalir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnSalir.Image = Global.My.Resources.Resources.Salir
        Me.btnSalir.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnSalir.Location = New System.Drawing.Point(777, 4)
        Me.btnSalir.LookAndFeel.SkinName = "Metropolis"
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(52, 42)
        Me.btnSalir.TabIndex = 11
        Me.btnSalir.Text = "Salir"
        '
        'btnEnviar
        '
        Me.btnEnviar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEnviar.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnEnviar.Appearance.Options.UseBackColor = True
        Me.btnEnviar.Appearance.Options.UseTextOptions = True
        Me.btnEnviar.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnEnviar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnEnviar.Image = Global.My.Resources.Resources.EmailBoton
        Me.btnEnviar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnEnviar.Location = New System.Drawing.Point(193, 4)
        Me.btnEnviar.LookAndFeel.SkinName = "Metropolis"
        Me.btnEnviar.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(52, 42)
        Me.btnEnviar.TabIndex = 10
        Me.btnEnviar.Text = "Añadir"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnAceptar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnAceptar.Appearance.Options.UseBackColor = True
        Me.btnAceptar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnAceptar.Enabled = False
        Me.btnAceptar.Image = Global.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnAceptar.Location = New System.Drawing.Point(651, 4)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(52, 42)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.Visible = False
        '
        'btnModificar
        '
        Me.btnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnModificar.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnModificar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnModificar.Appearance.Options.UseBackColor = True
        Me.btnModificar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnModificar.Enabled = False
        Me.btnModificar.Image = Global.My.Resources.Resources.Modificar
        Me.btnModificar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnModificar.Location = New System.Drawing.Point(520, 5)
        Me.btnModificar.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(52, 42)
        Me.btnModificar.TabIndex = 2
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.ToolTip = "Modificar Linea"
        Me.btnModificar.Visible = False
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnEliminar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnEliminar.Appearance.Options.UseBackColor = True
        Me.btnEliminar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnEliminar.Image = Global.My.Resources.Resources.Eliminar
        Me.btnEliminar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnEliminar.Location = New System.Drawing.Point(67, 4)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(52, 42)
        Me.btnEliminar.TabIndex = 1
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.ToolTip = "Borrar Linea"
        '
        'btnAnadir
        '
        Me.btnAnadir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAnadir.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnAnadir.Appearance.Options.UseBackColor = True
        Me.btnAnadir.Appearance.Options.UseTextOptions = True
        Me.btnAnadir.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnAnadir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnAnadir.Image = Global.My.Resources.Resources.Anadir
        Me.btnAnadir.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnAnadir.Location = New System.Drawing.Point(576, 4)
        Me.btnAnadir.LookAndFeel.SkinName = "Metropolis"
        Me.btnAnadir.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnAnadir.Name = "btnAnadir"
        Me.btnAnadir.Size = New System.Drawing.Size(52, 42)
        Me.btnAnadir.TabIndex = 0
        Me.btnAnadir.Text = "Añadir"
        Me.btnAnadir.Visible = False
        '
        'dgvx
        '
        Me.dgvx.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvx.ColumnaCheck = Nothing
        Me.dgvx.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dgvx.Location = New System.Drawing.Point(5, 6)
        Me.dgvx.MainView = Me.Gv
        Me.dgvx.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dgvx.Name = "dgvx"
        Me.dgvx.Size = New System.Drawing.Size(821, 143)
        Me.dgvx.TabIndex = 0
        Me.dgvx.tb_AnadirColumnaCheck = False
        Me.dgvx.tbPerfilPredeterminado = ""
        Me.dgvx.UseDisabledStatePainter = False
        Me.dgvx.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Gv})
        '
        'Gv
        '
        Me.Gv.GridControl = Me.dgvx
        Me.Gv.Name = "Gv"
        Me.Gv.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        '
        'PanelDatosGenerales
        '
        Me.PanelDatosGenerales.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelDatosGenerales.Controls.Add(Label15)
        Me.PanelDatosGenerales.Controls.Add(Me.mskFechaEntrega)
        Me.PanelDatosGenerales.Controls.Add(Me.cmbSeriesFacturacion)
        Me.PanelDatosGenerales.Controls.Add(Label13)
        Me.PanelDatosGenerales.Controls.Add(Label9)
        Me.PanelDatosGenerales.Controls.Add(Me.mskFecha)
        Me.PanelDatosGenerales.Controls.Add(Me.cmbEmpleados)
        Me.PanelDatosGenerales.Controls.Add(Label1)
        Me.PanelDatosGenerales.Controls.Add(Me.txtNumero)
        Me.PanelDatosGenerales.Controls.Add(lblNumero)
        Me.PanelDatosGenerales.Location = New System.Drawing.Point(2, 3)
        Me.PanelDatosGenerales.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PanelDatosGenerales.Name = "PanelDatosGenerales"
        Me.PanelDatosGenerales.Size = New System.Drawing.Size(269, 134)
        Me.PanelDatosGenerales.TabIndex = 0
        Me.PanelDatosGenerales.UseDisabledStatePainter = False
        '
        'mskFechaEntrega
        '
        Me.mskFechaEntrega.EditValue = Nothing
        Me.mskFechaEntrega.EnterMoveNextControl = True
        Me.mskFechaEntrega.Location = New System.Drawing.Point(134, 60)
        Me.mskFechaEntrega.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.mskFechaEntrega.Name = "mskFechaEntrega"
        Me.mskFechaEntrega.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.mskFechaEntrega.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Strong
        Me.mskFechaEntrega.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.mskFechaEntrega.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.mskFechaEntrega.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.mskFechaEntrega.Size = New System.Drawing.Size(125, 20)
        Me.mskFechaEntrega.TabIndex = 112
        '
        'cmbSeriesFacturacion
        '
        Me.cmbSeriesFacturacion.EnterMoveNextControl = True
        Me.cmbSeriesFacturacion.Location = New System.Drawing.Point(3, 20)
        Me.cmbSeriesFacturacion.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cmbSeriesFacturacion.Name = "cmbSeriesFacturacion"
        Me.cmbSeriesFacturacion.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cmbSeriesFacturacion.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.cmbSeriesFacturacion.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        SerializableAppearanceObject1.Font = New System.Drawing.Font("Tahoma", 8.75!, System.Drawing.FontStyle.Bold)
        SerializableAppearanceObject1.Options.UseFont = True
        ToolTipItem1.Text = "Añadir forma de pago"
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.cmbSeriesFacturacion.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", 30, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "Nuevo", Nothing, SuperToolTip1, True)})
        Me.cmbSeriesFacturacion.Properties.View = Me.GridView3
        Me.cmbSeriesFacturacion.Size = New System.Drawing.Size(168, 20)
        Me.cmbSeriesFacturacion.TabIndex = 0
        '
        'GridView3
        '
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'mskFecha
        '
        Me.mskFecha.EditValue = Nothing
        Me.mskFecha.EnterMoveNextControl = True
        Me.mskFecha.Location = New System.Drawing.Point(5, 60)
        Me.mskFecha.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.mskFecha.Name = "mskFecha"
        Me.mskFecha.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.mskFecha.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Strong
        Me.mskFecha.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.mskFecha.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.mskFecha.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.mskFecha.Size = New System.Drawing.Size(125, 20)
        Me.mskFecha.TabIndex = 2
        '
        'cmbEmpleados
        '
        Me.cmbEmpleados.EnterMoveNextControl = True
        Me.cmbEmpleados.Location = New System.Drawing.Point(4, 106)
        Me.cmbEmpleados.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cmbEmpleados.Name = "cmbEmpleados"
        Me.cmbEmpleados.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cmbEmpleados.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.cmbEmpleados.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        SerializableAppearanceObject2.Font = New System.Drawing.Font("Tahoma", 8.75!, System.Drawing.FontStyle.Bold)
        SerializableAppearanceObject2.Options.UseFont = True
        ToolTipItem2.Text = "Añadir forma de pago"
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.cmbEmpleados.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", 30, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "Nuevo", Nothing, SuperToolTip2, True)})
        Me.cmbEmpleados.Properties.View = Me.GridView2
        Me.cmbEmpleados.Size = New System.Drawing.Size(254, 20)
        Me.cmbEmpleados.TabIndex = 3
        '
        'GridView2
        '
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'txtNumero
        '
        Me.txtNumero.EnterMoveNextControl = True
        Me.txtNumero.Location = New System.Drawing.Point(175, 20)
        Me.txtNumero.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNumero.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtNumero.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtNumero.Size = New System.Drawing.Size(84, 20)
        Me.txtNumero.TabIndex = 1
        '
        'cmbAlmacenes
        '
        Me.cmbAlmacenes.EnterMoveNextControl = True
        Me.cmbAlmacenes.Location = New System.Drawing.Point(8, 20)
        Me.cmbAlmacenes.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cmbAlmacenes.Name = "cmbAlmacenes"
        Me.cmbAlmacenes.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmbAlmacenes.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cmbAlmacenes.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.cmbAlmacenes.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        SerializableAppearanceObject3.Font = New System.Drawing.Font("Tahoma", 8.75!, System.Drawing.FontStyle.Bold)
        SerializableAppearanceObject3.Options.UseFont = True
        ToolTipItem3.Text = "Añadir forma de pago"
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.cmbAlmacenes.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", 30, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject3, "Nuevo", Nothing, SuperToolTip3, True)})
        Me.cmbAlmacenes.Properties.View = Me.GridView1
        Me.cmbAlmacenes.Size = New System.Drawing.Size(218, 20)
        Me.cmbAlmacenes.TabIndex = 5
        '
        'GridView1
        '
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'cmbFormasPago
        '
        Me.cmbFormasPago.EnterMoveNextControl = True
        Me.cmbFormasPago.Location = New System.Drawing.Point(5, 59)
        Me.cmbFormasPago.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cmbFormasPago.Name = "cmbFormasPago"
        Me.cmbFormasPago.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cmbFormasPago.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.cmbFormasPago.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        SerializableAppearanceObject4.Font = New System.Drawing.Font("Tahoma", 8.75!, System.Drawing.FontStyle.Bold)
        SerializableAppearanceObject4.Options.UseFont = True
        ToolTipItem4.Text = "Añadir forma de pago"
        SuperToolTip4.Items.Add(ToolTipItem4)
        Me.cmbFormasPago.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", 30, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject4, "Nuevo", Nothing, SuperToolTip4, True)})
        Me.cmbFormasPago.Properties.View = Me.GridLookUpEdit1View
        Me.cmbFormasPago.Size = New System.Drawing.Size(311, 20)
        Me.cmbFormasPago.TabIndex = 4
        '
        'GridLookUpEdit1View
        '
        Me.GridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridLookUpEdit1View.Name = "GridLookUpEdit1View"
        Me.GridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'PanelDatosCliente
        '
        Me.PanelDatosCliente.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelDatosCliente.Controls.Add(Me.LabelControl28)
        Me.PanelDatosCliente.Controls.Add(Me.spnDescuentoPP)
        Me.PanelDatosCliente.Controls.Add(Me.LabelControl1)
        Me.PanelDatosCliente.Controls.Add(Me.spnDescuentoEsp)
        Me.PanelDatosCliente.Controls.Add(Me.cmbDireccionesEnvio)
        Me.PanelDatosCliente.Controls.Add(Label16)
        Me.PanelDatosCliente.Controls.Add(Me.txtEmail)
        Me.PanelDatosCliente.Controls.Add(Me.txtFax)
        Me.PanelDatosCliente.Controls.Add(Me.txtTelefono2)
        Me.PanelDatosCliente.Controls.Add(Me.txtTelefono1)
        Me.PanelDatosCliente.Controls.Add(Me.cmbFormasPago)
        Me.PanelDatosCliente.Controls.Add(FormaPagoLabel)
        Me.PanelDatosCliente.Controls.Add(Me.txtNombreComercial)
        Me.PanelDatosCliente.Controls.Add(Me.txtProvincia)
        Me.PanelDatosCliente.Controls.Add(Label5)
        Me.PanelDatosCliente.Controls.Add(Me.txtPoblacion)
        Me.PanelDatosCliente.Controls.Add(Label3)
        Me.PanelDatosCliente.Controls.Add(Me.txtCodPostal)
        Me.PanelDatosCliente.Controls.Add(Label8)
        Me.PanelDatosCliente.Controls.Add(Me.txtDireccion)
        Me.PanelDatosCliente.Controls.Add(Label7)
        Me.PanelDatosCliente.Controls.Add(Me.cmbClientes)
        Me.PanelDatosCliente.Controls.Add(Label4)
        Me.PanelDatosCliente.Controls.Add(Me.txtNIF)
        Me.PanelDatosCliente.Controls.Add(Label6)
        Me.PanelDatosCliente.Location = New System.Drawing.Point(275, 3)
        Me.PanelDatosCliente.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PanelDatosCliente.Name = "PanelDatosCliente"
        Me.PanelDatosCliente.Size = New System.Drawing.Size(321, 134)
        Me.PanelDatosCliente.TabIndex = 1
        Me.PanelDatosCliente.UseDisabledStatePainter = False
        '
        'LabelControl28
        '
        Me.LabelControl28.Location = New System.Drawing.Point(255, 87)
        Me.LabelControl28.Name = "LabelControl28"
        Me.LabelControl28.Size = New System.Drawing.Size(40, 13)
        Me.LabelControl28.TabIndex = 207
        Me.LabelControl28.Text = "Dto. PP:"
        '
        'spnDescuentoPP
        '
        Me.spnDescuentoPP.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.spnDescuentoPP.Location = New System.Drawing.Point(255, 106)
        Me.spnDescuentoPP.Name = "spnDescuentoPP"
        Me.spnDescuentoPP.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.spnDescuentoPP.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.spnDescuentoPP.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.spnDescuentoPP.Properties.NullText = "0"
        Me.spnDescuentoPP.Size = New System.Drawing.Size(61, 20)
        Me.spnDescuentoPP.TabIndex = 206
        Me.spnDescuentoPP.ToolTip = "Porcentaje de descuento sobre base imponible"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(183, 87)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(66, 13)
        Me.LabelControl1.TabIndex = 205
        Me.LabelControl1.Text = "Dto. Especial:"
        '
        'spnDescuentoEsp
        '
        Me.spnDescuentoEsp.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.spnDescuentoEsp.Location = New System.Drawing.Point(183, 107)
        Me.spnDescuentoEsp.Name = "spnDescuentoEsp"
        Me.spnDescuentoEsp.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.spnDescuentoEsp.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.spnDescuentoEsp.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.spnDescuentoEsp.Properties.NullText = "0"
        Me.spnDescuentoEsp.Size = New System.Drawing.Size(66, 20)
        Me.spnDescuentoEsp.TabIndex = 204
        Me.spnDescuentoEsp.ToolTip = "Porcentaje de descuento a nivel de linea"
        '
        'cmbDireccionesEnvio
        '
        Me.cmbDireccionesEnvio.EnterMoveNextControl = True
        Me.cmbDireccionesEnvio.Location = New System.Drawing.Point(5, 106)
        Me.cmbDireccionesEnvio.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cmbDireccionesEnvio.Name = "cmbDireccionesEnvio"
        Me.cmbDireccionesEnvio.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cmbDireccionesEnvio.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.cmbDireccionesEnvio.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        SerializableAppearanceObject5.Font = New System.Drawing.Font("Tahoma", 8.75!, System.Drawing.FontStyle.Bold)
        SerializableAppearanceObject5.Options.UseFont = True
        ToolTipItem5.Text = "Añadir forma de pago"
        SuperToolTip5.Items.Add(ToolTipItem5)
        Me.cmbDireccionesEnvio.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", 30, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject5, "Nuevo", Nothing, SuperToolTip5, True)})
        Me.cmbDireccionesEnvio.Properties.View = Me.GridView5
        Me.cmbDireccionesEnvio.Size = New System.Drawing.Size(174, 20)
        Me.cmbDireccionesEnvio.TabIndex = 121
        '
        'GridView5
        '
        Me.GridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView5.Name = "GridView5"
        Me.GridView5.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView5.OptionsView.ShowGroupPanel = False
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(25, 170)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtEmail.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtEmail.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtEmail.Size = New System.Drawing.Size(39, 20)
        Me.txtEmail.TabIndex = 120
        Me.txtEmail.Visible = False
        '
        'txtFax
        '
        Me.txtFax.Location = New System.Drawing.Point(50, 170)
        Me.txtFax.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtFax.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtFax.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtFax.Size = New System.Drawing.Size(39, 20)
        Me.txtFax.TabIndex = 119
        Me.txtFax.Visible = False
        '
        'txtTelefono2
        '
        Me.txtTelefono2.Location = New System.Drawing.Point(50, 170)
        Me.txtTelefono2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtTelefono2.Name = "txtTelefono2"
        Me.txtTelefono2.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtTelefono2.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtTelefono2.Size = New System.Drawing.Size(39, 20)
        Me.txtTelefono2.TabIndex = 118
        Me.txtTelefono2.Visible = False
        '
        'txtTelefono1
        '
        Me.txtTelefono1.Location = New System.Drawing.Point(60, 170)
        Me.txtTelefono1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtTelefono1.Name = "txtTelefono1"
        Me.txtTelefono1.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTelefono1.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtTelefono1.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtTelefono1.Size = New System.Drawing.Size(39, 20)
        Me.txtTelefono1.TabIndex = 117
        Me.txtTelefono1.Visible = False
        '
        'txtNombreComercial
        '
        Me.txtNombreComercial.Location = New System.Drawing.Point(5, 170)
        Me.txtNombreComercial.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtNombreComercial.Name = "txtNombreComercial"
        Me.txtNombreComercial.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtNombreComercial.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtNombreComercial.Size = New System.Drawing.Size(39, 20)
        Me.txtNombreComercial.TabIndex = 116
        Me.txtNombreComercial.Visible = False
        '
        'txtProvincia
        '
        Me.txtProvincia.EnterMoveNextControl = True
        Me.txtProvincia.Location = New System.Drawing.Point(22, 60)
        Me.txtProvincia.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtProvincia.Name = "txtProvincia"
        Me.txtProvincia.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtProvincia.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtProvincia.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtProvincia.Size = New System.Drawing.Size(131, 20)
        Me.txtProvincia.TabIndex = 3
        Me.txtProvincia.Visible = False
        '
        'txtPoblacion
        '
        Me.txtPoblacion.EnterMoveNextControl = True
        Me.txtPoblacion.Location = New System.Drawing.Point(25, 59)
        Me.txtPoblacion.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtPoblacion.Name = "txtPoblacion"
        Me.txtPoblacion.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtPoblacion.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtPoblacion.Size = New System.Drawing.Size(189, 20)
        Me.txtPoblacion.TabIndex = 6
        Me.txtPoblacion.Visible = False
        '
        'txtCodPostal
        '
        Me.txtCodPostal.EnterMoveNextControl = True
        Me.txtCodPostal.Location = New System.Drawing.Point(5, 60)
        Me.txtCodPostal.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtCodPostal.Name = "txtCodPostal"
        Me.txtCodPostal.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCodPostal.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtCodPostal.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtCodPostal.Size = New System.Drawing.Size(59, 20)
        Me.txtCodPostal.TabIndex = 4
        Me.txtCodPostal.Visible = False
        '
        'txtDireccion
        '
        Me.txtDireccion.EnterMoveNextControl = True
        Me.txtDireccion.Location = New System.Drawing.Point(68, 59)
        Me.txtDireccion.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtDireccion.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtDireccion.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtDireccion.Size = New System.Drawing.Size(190, 20)
        Me.txtDireccion.TabIndex = 5
        Me.txtDireccion.Visible = False
        '
        'cmbClientes
        '
        Me.cmbClientes.EnterMoveNextControl = True
        Me.cmbClientes.Location = New System.Drawing.Point(5, 22)
        Me.cmbClientes.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cmbClientes.Name = "cmbClientes"
        Me.cmbClientes.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cmbClientes.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.cmbClientes.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        SerializableAppearanceObject6.Font = New System.Drawing.Font("Tahoma", 8.75!, System.Drawing.FontStyle.Bold)
        SerializableAppearanceObject6.Options.UseFont = True
        ToolTipItem6.Text = "Añadir forma de pago"
        SuperToolTip6.Items.Add(ToolTipItem6)
        Me.cmbClientes.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", 30, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject6, "Nuevo", Nothing, SuperToolTip6, True)})
        Me.cmbClientes.Properties.View = Me.GridView4
        Me.cmbClientes.Size = New System.Drawing.Size(223, 20)
        Me.cmbClientes.TabIndex = 1
        '
        'GridView4
        '
        Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView4.OptionsView.ShowGroupPanel = False
        '
        'txtNIF
        '
        Me.txtNIF.EnterMoveNextControl = True
        Me.txtNIF.Location = New System.Drawing.Point(232, 22)
        Me.txtNIF.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtNIF.Name = "txtNIF"
        Me.txtNIF.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNIF.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtNIF.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtNIF.Size = New System.Drawing.Size(84, 20)
        Me.txtNIF.TabIndex = 2
        '
        'txtTotal
        '
        Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotal.Enabled = False
        Me.txtTotal.EnterMoveNextControl = True
        Me.txtTotal.Location = New System.Drawing.Point(718, 331)
        Me.txtTotal.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Properties.Appearance.Options.UseTextOptions = True
        Me.txtTotal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtTotal.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTotal.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtTotal.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtTotal.Size = New System.Drawing.Size(114, 20)
        Me.txtTotal.TabIndex = 121
        '
        'txtIVA
        '
        Me.txtIVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIVA.Enabled = False
        Me.txtIVA.EnterMoveNextControl = True
        Me.txtIVA.Location = New System.Drawing.Point(593, 331)
        Me.txtIVA.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtIVA.Name = "txtIVA"
        Me.txtIVA.Properties.Appearance.Options.UseTextOptions = True
        Me.txtIVA.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtIVA.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtIVA.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtIVA.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtIVA.Size = New System.Drawing.Size(114, 20)
        Me.txtIVA.TabIndex = 120
        '
        'txtBI
        '
        Me.txtBI.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBI.Enabled = False
        Me.txtBI.EnterMoveNextControl = True
        Me.txtBI.Location = New System.Drawing.Point(469, 332)
        Me.txtBI.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtBI.Name = "txtBI"
        Me.txtBI.Properties.Appearance.Options.UseTextOptions = True
        Me.txtBI.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtBI.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtBI.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtBI.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtBI.Size = New System.Drawing.Size(114, 20)
        Me.txtBI.TabIndex = 119
        '
        'pnlDetalle
        '
        Me.pnlDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDetalle.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.pnlDetalle.Controls.Add(Me.dgvx)
        Me.pnlDetalle.Location = New System.Drawing.Point(2, 143)
        Me.pnlDetalle.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.pnlDetalle.Name = "pnlDetalle"
        Me.pnlDetalle.Size = New System.Drawing.Size(830, 155)
        Me.pnlDetalle.TabIndex = 6
        Me.pnlDetalle.UseDisabledStatePainter = False
        '
        'PanelDatosObservaciones
        '
        Me.PanelDatosObservaciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelDatosObservaciones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelDatosObservaciones.Controls.Add(Me.txtObservaciones)
        Me.PanelDatosObservaciones.Controls.Add(Label14)
        Me.PanelDatosObservaciones.Controls.Add(Me.cmbAlmacenes)
        Me.PanelDatosObservaciones.Controls.Add(Label2)
        Me.PanelDatosObservaciones.Location = New System.Drawing.Point(601, 3)
        Me.PanelDatosObservaciones.Name = "PanelDatosObservaciones"
        Me.PanelDatosObservaciones.Size = New System.Drawing.Size(231, 134)
        Me.PanelDatosObservaciones.TabIndex = 2
        Me.PanelDatosObservaciones.UseDisabledStatePainter = False
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObservaciones.Location = New System.Drawing.Point(5, 60)
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(220, 68)
        Me.txtObservaciones.TabIndex = 91
        Me.txtObservaciones.TabStop = False
        '
        'DockManager1
        '
        Me.DockManager1.Form = Me
        Me.DockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.StatusBar", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl"})
        '
        'txtImporte
        '
        Me.txtImporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtImporte.Enabled = False
        Me.txtImporte.EnterMoveNextControl = True
        Me.txtImporte.Location = New System.Drawing.Point(206, 332)
        Me.txtImporte.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Properties.Appearance.Options.UseTextOptions = True
        Me.txtImporte.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtImporte.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtImporte.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtImporte.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtImporte.Size = New System.Drawing.Size(114, 20)
        Me.txtImporte.TabIndex = 125
        '
        'txtDtoPPImporte
        '
        Me.txtDtoPPImporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDtoPPImporte.Enabled = False
        Me.txtDtoPPImporte.EnterMoveNextControl = True
        Me.txtDtoPPImporte.Location = New System.Drawing.Point(339, 332)
        Me.txtDtoPPImporte.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtDtoPPImporte.Name = "txtDtoPPImporte"
        Me.txtDtoPPImporte.Properties.Appearance.Options.UseTextOptions = True
        Me.txtDtoPPImporte.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtDtoPPImporte.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtDtoPPImporte.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtDtoPPImporte.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtDtoPPImporte.Size = New System.Drawing.Size(114, 20)
        Me.txtDtoPPImporte.TabIndex = 127
        '
        'ucDocumentosGenerarBase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Label18)
        Me.Controls.Add(Me.txtDtoPPImporte)
        Me.Controls.Add(Label17)
        Me.Controls.Add(Me.txtImporte)
        Me.Controls.Add(Me.PanelDatosObservaciones)
        Me.Controls.Add(Label12)
        Me.Controls.Add(Me.pnlDetalle)
        Me.Controls.Add(Me.PanelDatosCliente)
        Me.Controls.Add(Label11)
        Me.Controls.Add(Me.PanelDatosGenerales)
        Me.Controls.Add(Me.PanelBotones)
        Me.Controls.Add(Label10)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.txtBI)
        Me.Controls.Add(Me.txtIVA)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "ucDocumentosGenerarBase"
        Me.Size = New System.Drawing.Size(839, 406)
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBotones.ResumeLayout(False)
        CType(Me.dgvx, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelDatosGenerales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDatosGenerales.ResumeLayout(False)
        Me.PanelDatosGenerales.PerformLayout()
        CType(Me.mskFechaEntrega.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mskFechaEntrega.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbSeriesFacturacion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mskFecha.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mskFecha.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbEmpleados.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumero.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbAlmacenes.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbFormasPago.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelDatosCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDatosCliente.ResumeLayout(False)
        Me.PanelDatosCliente.PerformLayout()
        CType(Me.spnDescuentoPP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spnDescuentoEsp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbDireccionesEnvio.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTelefono2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTelefono1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombreComercial.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProvincia.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPoblacion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodPostal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDireccion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbClientes.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNIF.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIVA.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBI.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDetalle.ResumeLayout(False)
        CType(Me.PanelDatosObservaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDatosObservaciones.ResumeLayout(False)
        Me.PanelDatosObservaciones.PerformLayout()
        CType(Me.txtObservaciones.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImporte.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDtoPPImporte.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelBotones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnModificar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnEliminar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAnadir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents dgvx As MyGridControl
    Friend WithEvents Gv As MyGridView
    Friend WithEvents PanelDatosGenerales As DevExpress.XtraEditors.PanelControl
    Friend WithEvents cmbAlmacenes As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cmbEmpleados As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cmbFormasPago As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txtNumero As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PanelDatosCliente As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtDireccion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmbClientes As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txtNIF As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtProvincia As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPoblacion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCodPostal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents pnlDetalle As DevExpress.XtraEditors.PanelControl
    Friend WithEvents mskFecha As DevExpress.XtraEditors.DateEdit

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents txtEmail As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtFax As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTelefono2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTelefono1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtNombreComercial As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTotal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtIVA As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtBI As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmbSeriesFacturacion As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelDatosObservaciones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtObservaciones As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents btnEnviar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSalir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnImprimir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnEliminarDocumento As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnRiesgo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents mskFechaEntrega As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents btnArticulosVendidos As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmbDireccionesEnvio As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl28 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents spnDescuentoPP As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents spnDescuentoEsp As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtDtoPPImporte As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtImporte As DevExpress.XtraEditors.TextEdit
End Class

