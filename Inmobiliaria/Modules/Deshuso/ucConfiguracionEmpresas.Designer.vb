Imports Microsoft.VisualBasic
Imports System

Partial Public Class ucConfiguracionEmpresas
    ''' <summary> 
    ''' Required designer variable.
    ''' </summary>
    '''   Inherits DevExpress.XtraEditors.XtraUserControl
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary> 
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.PanelCajas = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl26 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl25 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl24 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl23 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl22 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl20 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl19 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl17 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl16 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.txtWeb = New DevExpress.XtraEditors.TextEdit()
        Me.txtCodigo = New DevExpress.XtraEditors.TextEdit()
        Me.txtNombre = New DevExpress.XtraEditors.TextEdit()
        Me.txtNombreComercial = New DevExpress.XtraEditors.TextEdit()
        Me.txtDireccion = New DevExpress.XtraEditors.TextEdit()
        Me.txtPoblacion = New DevExpress.XtraEditors.TextEdit()
        Me.txtCodPostal = New DevExpress.XtraEditors.TextEdit()
        Me.txtProvincia = New DevExpress.XtraEditors.TextEdit()
        Me.txtPais = New DevExpress.XtraEditors.TextEdit()
        Me.txtTelefono1 = New DevExpress.XtraEditors.TextEdit()
        Me.txtTelefono2 = New DevExpress.XtraEditors.TextEdit()
        Me.txtTelefonoMovil = New DevExpress.XtraEditors.TextEdit()
        Me.txtFax = New DevExpress.XtraEditors.TextEdit()
        Me.txtEmail = New DevExpress.XtraEditors.TextEdit()
        Me.txtObservaciones = New DevExpress.XtraEditors.MemoEdit()
        Me.txtNIF = New DevExpress.XtraEditors.TextEdit()
        Me.PanelBotones = New DevExpress.XtraEditors.PanelControl()
        Me.btnSalir = New DevExpress.XtraEditors.SimpleButton()
        Me.ToolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnModificar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnEliminar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAnadir = New DevExpress.XtraEditors.SimpleButton()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.HoldfToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.PanelCajas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelCajas.SuspendLayout()
        CType(Me.txtWeb.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombre.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombreComercial.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDireccion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPoblacion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodPostal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProvincia.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPais.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTelefono1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTelefono2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTelefonoMovil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtObservaciones.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNIF.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBotones.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelCajas
        '
        Me.PanelCajas.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelCajas.Controls.Add(Me.LabelControl26)
        Me.PanelCajas.Controls.Add(Me.LabelControl25)
        Me.PanelCajas.Controls.Add(Me.LabelControl24)
        Me.PanelCajas.Controls.Add(Me.LabelControl23)
        Me.PanelCajas.Controls.Add(Me.LabelControl22)
        Me.PanelCajas.Controls.Add(Me.LabelControl21)
        Me.PanelCajas.Controls.Add(Me.LabelControl20)
        Me.PanelCajas.Controls.Add(Me.LabelControl19)
        Me.PanelCajas.Controls.Add(Me.LabelControl18)
        Me.PanelCajas.Controls.Add(Me.LabelControl17)
        Me.PanelCajas.Controls.Add(Me.LabelControl16)
        Me.PanelCajas.Controls.Add(Me.LabelControl15)
        Me.PanelCajas.Controls.Add(Me.LabelControl14)
        Me.PanelCajas.Controls.Add(Me.LabelControl13)
        Me.PanelCajas.Controls.Add(Me.LabelControl12)
        Me.PanelCajas.Controls.Add(Me.LabelControl11)
        Me.PanelCajas.Controls.Add(Me.txtWeb)
        Me.PanelCajas.Controls.Add(Me.txtCodigo)
        Me.PanelCajas.Controls.Add(Me.txtNombre)
        Me.PanelCajas.Controls.Add(Me.txtNombreComercial)
        Me.PanelCajas.Controls.Add(Me.txtDireccion)
        Me.PanelCajas.Controls.Add(Me.txtPoblacion)
        Me.PanelCajas.Controls.Add(Me.txtCodPostal)
        Me.PanelCajas.Controls.Add(Me.txtProvincia)
        Me.PanelCajas.Controls.Add(Me.txtPais)
        Me.PanelCajas.Controls.Add(Me.txtTelefono1)
        Me.PanelCajas.Controls.Add(Me.txtTelefono2)
        Me.PanelCajas.Controls.Add(Me.txtTelefonoMovil)
        Me.PanelCajas.Controls.Add(Me.txtFax)
        Me.PanelCajas.Controls.Add(Me.txtEmail)
        Me.PanelCajas.Controls.Add(Me.txtObservaciones)
        Me.PanelCajas.Controls.Add(Me.txtNIF)
        Me.PanelCajas.Location = New System.Drawing.Point(3, 2)
        Me.PanelCajas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PanelCajas.Name = "PanelCajas"
        Me.PanelCajas.Size = New System.Drawing.Size(777, 207)
        Me.PanelCajas.TabIndex = 0
        '
        'LabelControl26
        '
        Me.LabelControl26.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl26.Location = New System.Drawing.Point(593, 89)
        Me.LabelControl26.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl26.Name = "LabelControl26"
        Me.LabelControl26.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl26.TabIndex = 176
        Me.LabelControl26.Text = "Web"
        '
        'LabelControl25
        '
        Me.LabelControl25.Location = New System.Drawing.Point(426, 89)
        Me.LabelControl25.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl25.Name = "LabelControl25"
        Me.LabelControl25.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl25.TabIndex = 175
        Me.LabelControl25.Text = "Email"
        '
        'LabelControl24
        '
        Me.LabelControl24.Location = New System.Drawing.Point(318, 89)
        Me.LabelControl24.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl24.Name = "LabelControl24"
        Me.LabelControl24.Size = New System.Drawing.Size(18, 13)
        Me.LabelControl24.TabIndex = 174
        Me.LabelControl24.Text = "Fax"
        '
        'LabelControl23
        '
        Me.LabelControl23.Location = New System.Drawing.Point(214, 89)
        Me.LabelControl23.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl23.Name = "LabelControl23"
        Me.LabelControl23.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl23.TabIndex = 173
        Me.LabelControl23.Text = "Teléfono Movil"
        '
        'LabelControl22
        '
        Me.LabelControl22.Location = New System.Drawing.Point(516, 49)
        Me.LabelControl22.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl22.Name = "LabelControl22"
        Me.LabelControl22.Size = New System.Drawing.Size(43, 13)
        Me.LabelControl22.TabIndex = 172
        Me.LabelControl22.Text = "Provincia"
        '
        'LabelControl21
        '
        Me.LabelControl21.Location = New System.Drawing.Point(442, 49)
        Me.LabelControl21.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(51, 13)
        Me.LabelControl21.TabIndex = 171
        Me.LabelControl21.Text = "Cod Postal"
        '
        'LabelControl20
        '
        Me.LabelControl20.Location = New System.Drawing.Point(270, 49)
        Me.LabelControl20.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl20.Name = "LabelControl20"
        Me.LabelControl20.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl20.TabIndex = 170
        Me.LabelControl20.Text = "Poblacion"
        '
        'LabelControl19
        '
        Me.LabelControl19.Location = New System.Drawing.Point(4, 49)
        Me.LabelControl19.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl19.Name = "LabelControl19"
        Me.LabelControl19.Size = New System.Drawing.Size(43, 13)
        Me.LabelControl19.TabIndex = 169
        Me.LabelControl19.Text = "Direccion"
        '
        'LabelControl18
        '
        Me.LabelControl18.Location = New System.Drawing.Point(109, 89)
        Me.LabelControl18.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(51, 13)
        Me.LabelControl18.TabIndex = 168
        Me.LabelControl18.Text = "Teléfono 2"
        '
        'LabelControl17
        '
        Me.LabelControl17.Location = New System.Drawing.Point(4, 89)
        Me.LabelControl17.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl17.Name = "LabelControl17"
        Me.LabelControl17.Size = New System.Drawing.Size(51, 13)
        Me.LabelControl17.TabIndex = 167
        Me.LabelControl17.Text = "Teléfono 1"
        '
        'LabelControl16
        '
        Me.LabelControl16.Location = New System.Drawing.Point(675, 49)
        Me.LabelControl16.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl16.Name = "LabelControl16"
        Me.LabelControl16.Size = New System.Drawing.Size(19, 13)
        Me.LabelControl16.TabIndex = 166
        Me.LabelControl16.Text = "Pais"
        '
        'LabelControl15
        '
        Me.LabelControl15.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl15.Location = New System.Drawing.Point(5, 134)
        Me.LabelControl15.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(71, 13)
        Me.LabelControl15.TabIndex = 165
        Me.LabelControl15.Text = "Observaciones"
        '
        'LabelControl14
        '
        Me.LabelControl14.Location = New System.Drawing.Point(445, 7)
        Me.LabelControl14.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(86, 13)
        Me.LabelControl14.TabIndex = 164
        Me.LabelControl14.Text = "Nombre Comercial"
        '
        'LabelControl13
        '
        Me.LabelControl13.Location = New System.Drawing.Point(357, 7)
        Me.LabelControl13.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(17, 13)
        Me.LabelControl13.TabIndex = 163
        Me.LabelControl13.Text = "NIF"
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(89, 8)
        Me.LabelControl12.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl12.TabIndex = 162
        Me.LabelControl12.Text = "Nombre"
        '
        'LabelControl11
        '
        Me.LabelControl11.Location = New System.Drawing.Point(4, 8)
        Me.LabelControl11.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl11.TabIndex = 161
        Me.LabelControl11.Text = "Codigo"
        '
        'txtWeb
        '
        Me.txtWeb.EnterMoveNextControl = True
        Me.txtWeb.Location = New System.Drawing.Point(593, 105)
        Me.txtWeb.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtWeb.Name = "txtWeb"
        Me.txtWeb.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtWeb.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtWeb.Size = New System.Drawing.Size(179, 20)
        Me.txtWeb.TabIndex = 14
        '
        'txtCodigo
        '
        Me.txtCodigo.EnterMoveNextControl = True
        Me.txtCodigo.Location = New System.Drawing.Point(4, 24)
        Me.txtCodigo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCodigo.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtCodigo.Size = New System.Drawing.Size(80, 20)
        Me.txtCodigo.TabIndex = 0
        '
        'txtNombre
        '
        Me.txtNombre.EnterMoveNextControl = True
        Me.txtNombre.Location = New System.Drawing.Point(89, 24)
        Me.txtNombre.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNombre.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtNombre.Size = New System.Drawing.Size(263, 20)
        Me.txtNombre.TabIndex = 1
        '
        'txtNombreComercial
        '
        Me.txtNombreComercial.EnterMoveNextControl = True
        Me.txtNombreComercial.Location = New System.Drawing.Point(442, 23)
        Me.txtNombreComercial.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNombreComercial.Name = "txtNombreComercial"
        Me.txtNombreComercial.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNombreComercial.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtNombreComercial.Size = New System.Drawing.Size(330, 20)
        Me.txtNombreComercial.TabIndex = 3
        '
        'txtDireccion
        '
        Me.txtDireccion.EnterMoveNextControl = True
        Me.txtDireccion.Location = New System.Drawing.Point(4, 64)
        Me.txtDireccion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtDireccion.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtDireccion.Size = New System.Drawing.Size(261, 20)
        Me.txtDireccion.TabIndex = 4
        '
        'txtPoblacion
        '
        Me.txtPoblacion.EnterMoveNextControl = True
        Me.txtPoblacion.Location = New System.Drawing.Point(270, 64)
        Me.txtPoblacion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPoblacion.Name = "txtPoblacion"
        Me.txtPoblacion.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtPoblacion.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtPoblacion.Size = New System.Drawing.Size(167, 20)
        Me.txtPoblacion.TabIndex = 5
        '
        'txtCodPostal
        '
        Me.txtCodPostal.EnterMoveNextControl = True
        Me.txtCodPostal.Location = New System.Drawing.Point(443, 64)
        Me.txtCodPostal.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCodPostal.Name = "txtCodPostal"
        Me.txtCodPostal.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCodPostal.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtCodPostal.Size = New System.Drawing.Size(67, 20)
        Me.txtCodPostal.TabIndex = 6
        '
        'txtProvincia
        '
        Me.txtProvincia.EnterMoveNextControl = True
        Me.txtProvincia.Location = New System.Drawing.Point(515, 64)
        Me.txtProvincia.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtProvincia.Name = "txtProvincia"
        Me.txtProvincia.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtProvincia.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtProvincia.Size = New System.Drawing.Size(154, 20)
        Me.txtProvincia.TabIndex = 7
        '
        'txtPais
        '
        Me.txtPais.EnterMoveNextControl = True
        Me.txtPais.Location = New System.Drawing.Point(675, 64)
        Me.txtPais.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPais.Name = "txtPais"
        Me.txtPais.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtPais.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtPais.Size = New System.Drawing.Size(97, 20)
        Me.txtPais.TabIndex = 8
        '
        'txtTelefono1
        '
        Me.txtTelefono1.EnterMoveNextControl = True
        Me.txtTelefono1.Location = New System.Drawing.Point(4, 105)
        Me.txtTelefono1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTelefono1.Name = "txtTelefono1"
        Me.txtTelefono1.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTelefono1.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtTelefono1.Size = New System.Drawing.Size(99, 20)
        Me.txtTelefono1.TabIndex = 12
        '
        'txtTelefono2
        '
        Me.txtTelefono2.EnterMoveNextControl = True
        Me.txtTelefono2.Location = New System.Drawing.Point(213, 105)
        Me.txtTelefono2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTelefono2.Name = "txtTelefono2"
        Me.txtTelefono2.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTelefono2.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtTelefono2.Size = New System.Drawing.Size(99, 20)
        Me.txtTelefono2.TabIndex = 9
        '
        'txtTelefonoMovil
        '
        Me.txtTelefonoMovil.EnterMoveNextControl = True
        Me.txtTelefonoMovil.Location = New System.Drawing.Point(109, 105)
        Me.txtTelefonoMovil.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTelefonoMovil.Name = "txtTelefonoMovil"
        Me.txtTelefonoMovil.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTelefonoMovil.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtTelefonoMovil.Size = New System.Drawing.Size(99, 20)
        Me.txtTelefonoMovil.TabIndex = 10
        '
        'txtFax
        '
        Me.txtFax.EnterMoveNextControl = True
        Me.txtFax.Location = New System.Drawing.Point(318, 105)
        Me.txtFax.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtFax.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtFax.Size = New System.Drawing.Size(99, 20)
        Me.txtFax.TabIndex = 11
        '
        'txtEmail
        '
        Me.txtEmail.EnterMoveNextControl = True
        Me.txtEmail.Location = New System.Drawing.Point(423, 105)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtEmail.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtEmail.Size = New System.Drawing.Size(164, 20)
        Me.txtEmail.TabIndex = 13
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(4, 151)
        Me.txtObservaciones.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(768, 47)
        Me.txtObservaciones.TabIndex = 15
        '
        'txtNIF
        '
        Me.txtNIF.EnterMoveNextControl = True
        Me.txtNIF.Location = New System.Drawing.Point(357, 23)
        Me.txtNIF.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNIF.Name = "txtNIF"
        Me.txtNIF.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNIF.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtNIF.Size = New System.Drawing.Size(80, 20)
        Me.txtNIF.TabIndex = 2
        '
        'PanelBotones
        '
        Me.PanelBotones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelBotones.Controls.Add(Me.btnSalir)
        Me.PanelBotones.Controls.Add(Me.btnCancelar)
        Me.PanelBotones.Controls.Add(Me.btnAceptar)
        Me.PanelBotones.Controls.Add(Me.btnModificar)
        Me.PanelBotones.Controls.Add(Me.btnEliminar)
        Me.PanelBotones.Controls.Add(Me.btnAnadir)
        Me.PanelBotones.Location = New System.Drawing.Point(3, 213)
        Me.PanelBotones.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PanelBotones.Name = "PanelBotones"
        Me.PanelBotones.Size = New System.Drawing.Size(777, 46)
        Me.PanelBotones.TabIndex = 17
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
        Me.btnSalir.Location = New System.Drawing.Point(722, 2)
        Me.btnSalir.LookAndFeel.SkinName = "Metropolis"
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(52, 42)
        Me.btnSalir.TabIndex = 6
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.ToolTipController = Me.ToolTipController1
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnCancelar.Appearance.Options.UseBackColor = True
        Me.btnCancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnCancelar.Enabled = False
        Me.btnCancelar.Image = Global.My.Resources.Resources.Cancelar
        Me.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnCancelar.Location = New System.Drawing.Point(668, 2)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(52, 42)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "Cancelar"
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
        Me.btnAceptar.Location = New System.Drawing.Point(614, 2)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(52, 42)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "Aceptar"
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
        Me.btnModificar.Location = New System.Drawing.Point(560, 2)
        Me.btnModificar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(52, 42)
        Me.btnModificar.TabIndex = 2
        Me.btnModificar.Text = "Modificar"
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnEliminar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnEliminar.Appearance.Options.UseBackColor = True
        Me.btnEliminar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Image = Global.My.Resources.Resources.Eliminar
        Me.btnEliminar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnEliminar.Location = New System.Drawing.Point(506, 2)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(52, 42)
        Me.btnEliminar.TabIndex = 1
        Me.btnEliminar.Text = "Eliminar"
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
        Me.btnAnadir.Location = New System.Drawing.Point(452, 2)
        Me.btnAnadir.LookAndFeel.SkinName = "Metropolis"
        Me.btnAnadir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAnadir.Name = "btnAnadir"
        Me.btnAnadir.Size = New System.Drawing.Size(52, 42)
        Me.btnAnadir.TabIndex = 0
        Me.btnAnadir.Text = "Añadir"
        Me.btnAnadir.ToolTip = "Pulse F1 para añadir"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HoldfToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(103, 26)
        '
        'HoldfToolStripMenuItem
        '
        Me.HoldfToolStripMenuItem.Name = "HoldfToolStripMenuItem"
        Me.HoldfToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
        Me.HoldfToolStripMenuItem.Text = "holdf"
        '
        'ucConfiguracionEmpresas
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.PanelCajas)
        Me.Controls.Add(Me.PanelBotones)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "ucConfiguracionEmpresas"
        Me.Size = New System.Drawing.Size(791, 265)
        CType(Me.PanelCajas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelCajas.ResumeLayout(False)
        Me.PanelCajas.PerformLayout()
        CType(Me.txtWeb.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodigo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombre.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombreComercial.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDireccion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPoblacion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodPostal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProvincia.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPais.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTelefono1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTelefono2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTelefonoMovil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtObservaciones.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNIF.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBotones.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabPageInformacionComplementaria As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelBotones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnModificar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnEliminar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAnadir As DevExpress.XtraEditors.SimpleButton

    Friend WithEvents PanelCajas As DevExpress.XtraEditors.PanelControl
   
    Friend WithEvents txtCodigo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtNombre As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtNombreComercial As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtDireccion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPoblacion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCodPostal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtProvincia As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPais As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTelefono1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTelefono2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTelefonoMovil As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtFax As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtEmail As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtWeb As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton

    Friend WithEvents txtObservaciones As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents txtNIF As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TabPageContactosComerciales As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TabPageDocumentos As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents ToolTipController1 As DevExpress.Utils.ToolTipController
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents HoldfToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents btnSalir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl26 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl25 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl24 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl23 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl22 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl20 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl19 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl17 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl16 As DevExpress.XtraEditors.LabelControl

End Class
 