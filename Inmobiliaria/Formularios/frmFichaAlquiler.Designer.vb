<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFichaAlquiler
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
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.PanelCajas = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtSueldoOtros = New DevExpress.XtraEditors.TextEdit()
        Me.txtNinos = New DevExpress.XtraEditors.TextEdit()
        Me.mskFechaInicioAlquiler = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl23 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl22 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl20 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl19 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl17 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.txtTiempoContrato = New DevExpress.XtraEditors.TextEdit()
        Me.txtAnimales = New DevExpress.XtraEditors.TextEdit()
        Me.txtProfesion = New DevExpress.XtraEditors.TextEdit()
        Me.txtSueldoNomina = New DevExpress.XtraEditors.TextEdit()
        Me.txtContratoTrabajo = New DevExpress.XtraEditors.TextEdit()
        Me.txtAntiguedad = New DevExpress.XtraEditors.TextEdit()
        Me.txtNacionalidad = New DevExpress.XtraEditors.TextEdit()
        Me.txtNotas = New DevExpress.XtraEditors.MemoEdit()
        Me.txtAdultos = New DevExpress.XtraEditors.TextEdit()
        Me.txtCodigo = New DevExpress.XtraEditors.TextEdit()
        Me.PanelBotones = New DevExpress.XtraEditors.PanelControl()
        Me.btnSalir = New uc_tb_SimpleButton()
        Me.btnBorrar = New uc_tb_SimpleButton()
        Me.btnAceptar = New uc_tb_SimpleButton()
        CType(Me.PanelCajas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelCajas.SuspendLayout()
        CType(Me.txtSueldoOtros.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNinos.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mskFechaInicioAlquiler.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mskFechaInicioAlquiler.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTiempoContrato.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAnimales.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProfesion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSueldoNomina.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContratoTrabajo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAntiguedad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNacionalidad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNotas.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAdultos.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelCajas
        '
        Me.PanelCajas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelCajas.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelCajas.Controls.Add(Me.LabelControl1)
        Me.PanelCajas.Controls.Add(Me.txtSueldoOtros)
        Me.PanelCajas.Controls.Add(Me.txtNinos)
        Me.PanelCajas.Controls.Add(Me.mskFechaInicioAlquiler)
        Me.PanelCajas.Controls.Add(Me.LabelControl23)
        Me.PanelCajas.Controls.Add(Me.LabelControl22)
        Me.PanelCajas.Controls.Add(Me.LabelControl21)
        Me.PanelCajas.Controls.Add(Me.LabelControl20)
        Me.PanelCajas.Controls.Add(Me.LabelControl19)
        Me.PanelCajas.Controls.Add(Me.LabelControl18)
        Me.PanelCajas.Controls.Add(Me.LabelControl17)
        Me.PanelCajas.Controls.Add(Me.LabelControl15)
        Me.PanelCajas.Controls.Add(Me.LabelControl14)
        Me.PanelCajas.Controls.Add(Me.LabelControl13)
        Me.PanelCajas.Controls.Add(Me.LabelControl12)
        Me.PanelCajas.Controls.Add(Me.txtTiempoContrato)
        Me.PanelCajas.Controls.Add(Me.txtAnimales)
        Me.PanelCajas.Controls.Add(Me.txtProfesion)
        Me.PanelCajas.Controls.Add(Me.txtSueldoNomina)
        Me.PanelCajas.Controls.Add(Me.txtContratoTrabajo)
        Me.PanelCajas.Controls.Add(Me.txtAntiguedad)
        Me.PanelCajas.Controls.Add(Me.txtNacionalidad)
        Me.PanelCajas.Controls.Add(Me.txtNotas)
        Me.PanelCajas.Controls.Add(Me.txtAdultos)
        Me.PanelCajas.Controls.Add(Me.txtCodigo)
        Me.PanelCajas.Location = New System.Drawing.Point(0, 0)
        Me.PanelCajas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PanelCajas.Name = "PanelCajas"
        Me.PanelCajas.Size = New System.Drawing.Size(666, 325)
        Me.PanelCajas.TabIndex = 18
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(357, 89)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(70, 13)
        Me.LabelControl1.TabIndex = 196
        Me.LabelControl1.Text = "Sueldo (Otros)"
        '
        'txtSueldoOtros
        '
        Me.txtSueldoOtros.EnterMoveNextControl = True
        Me.txtSueldoOtros.Location = New System.Drawing.Point(357, 107)
        Me.txtSueldoOtros.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtSueldoOtros.Name = "txtSueldoOtros"
        Me.txtSueldoOtros.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtSueldoOtros.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtSueldoOtros.Size = New System.Drawing.Size(170, 20)
        Me.txtSueldoOtros.TabIndex = 6
        '
        'txtNinos
        '
        Me.txtNinos.EnterMoveNextControl = True
        Me.txtNinos.Location = New System.Drawing.Point(445, 21)
        Me.txtNinos.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNinos.Name = "txtNinos"
        Me.txtNinos.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNinos.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtNinos.Size = New System.Drawing.Size(82, 20)
        Me.txtNinos.TabIndex = 4
        '
        'mskFechaInicioAlquiler
        '
        Me.mskFechaInicioAlquiler.EditValue = Nothing
        Me.mskFechaInicioAlquiler.EnterMoveNextControl = True
        Me.mskFechaInicioAlquiler.Location = New System.Drawing.Point(5, 21)
        Me.mskFechaInicioAlquiler.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.mskFechaInicioAlquiler.Name = "mskFechaInicioAlquiler"
        Me.mskFechaInicioAlquiler.Properties.Appearance.Options.UseTextOptions = True
        Me.mskFechaInicioAlquiler.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.mskFechaInicioAlquiler.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White
        Me.mskFechaInicioAlquiler.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.mskFechaInicioAlquiler.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.mskFechaInicioAlquiler.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.mskFechaInicioAlquiler.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, True, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.mskFechaInicioAlquiler.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.mskFechaInicioAlquiler.Properties.EditFormat.FormatString = "dd/MM/yy"
        Me.mskFechaInicioAlquiler.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.mskFechaInicioAlquiler.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Strong
        Me.mskFechaInicioAlquiler.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.mskFechaInicioAlquiler.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.mskFechaInicioAlquiler.Size = New System.Drawing.Size(170, 20)
        Me.mskFechaInicioAlquiler.TabIndex = 1
        '
        'LabelControl23
        '
        Me.LabelControl23.Location = New System.Drawing.Point(5, 131)
        Me.LabelControl23.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl23.Name = "LabelControl23"
        Me.LabelControl23.Size = New System.Drawing.Size(60, 13)
        Me.LabelControl23.TabIndex = 173
        Me.LabelControl23.Text = "Nacionalidad"
        '
        'LabelControl22
        '
        Me.LabelControl22.Location = New System.Drawing.Point(181, 89)
        Me.LabelControl22.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl22.Name = "LabelControl22"
        Me.LabelControl22.Size = New System.Drawing.Size(78, 13)
        Me.LabelControl22.TabIndex = 172
        Me.LabelControl22.Text = "Sueldo (Nómina)"
        '
        'LabelControl21
        '
        Me.LabelControl21.Location = New System.Drawing.Point(445, 3)
        Me.LabelControl21.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl21.TabIndex = 171
        Me.LabelControl21.Text = "Niños"
        '
        'LabelControl20
        '
        Me.LabelControl20.Location = New System.Drawing.Point(5, 47)
        Me.LabelControl20.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl20.Name = "LabelControl20"
        Me.LabelControl20.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl20.TabIndex = 170
        Me.LabelControl20.Text = "Profesión"
        '
        'LabelControl19
        '
        Me.LabelControl19.Location = New System.Drawing.Point(5, 174)
        Me.LabelControl19.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl19.Name = "LabelControl19"
        Me.LabelControl19.Size = New System.Drawing.Size(42, 13)
        Me.LabelControl19.TabIndex = 169
        Me.LabelControl19.Text = "Animales"
        '
        'LabelControl18
        '
        Me.LabelControl18.Location = New System.Drawing.Point(5, 89)
        Me.LabelControl18.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(122, 13)
        Me.LabelControl18.TabIndex = 168
        Me.LabelControl18.Text = "Antigüedad (en Empresa)"
        '
        'LabelControl17
        '
        Me.LabelControl17.Location = New System.Drawing.Point(357, 47)
        Me.LabelControl17.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl17.Name = "LabelControl17"
        Me.LabelControl17.Size = New System.Drawing.Size(96, 13)
        Me.LabelControl17.TabIndex = 167
        Me.LabelControl17.Text = "Contrato de trabajo"
        '
        'LabelControl15
        '
        Me.LabelControl15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelControl15.Location = New System.Drawing.Point(5, 219)
        Me.LabelControl15.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(28, 13)
        Me.LabelControl15.TabIndex = 165
        Me.LabelControl15.Text = "Notas"
        '
        'LabelControl14
        '
        Me.LabelControl14.Location = New System.Drawing.Point(181, 3)
        Me.LabelControl14.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(93, 13)
        Me.LabelControl14.TabIndex = 164
        Me.LabelControl14.Text = "Tiempo de contrato"
        '
        'LabelControl13
        '
        Me.LabelControl13.Location = New System.Drawing.Point(357, 3)
        Me.LabelControl13.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl13.TabIndex = 163
        Me.LabelControl13.Text = "Adultos"
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(5, 3)
        Me.LabelControl12.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(107, 13)
        Me.LabelControl12.TabIndex = 162
        Me.LabelControl12.Text = "Fecha de inicio alquiler"
        '
        'txtTiempoContrato
        '
        Me.txtTiempoContrato.EnterMoveNextControl = True
        Me.txtTiempoContrato.Location = New System.Drawing.Point(181, 21)
        Me.txtTiempoContrato.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTiempoContrato.Name = "txtTiempoContrato"
        Me.txtTiempoContrato.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTiempoContrato.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtTiempoContrato.Size = New System.Drawing.Size(170, 20)
        Me.txtTiempoContrato.TabIndex = 2
        '
        'txtAnimales
        '
        Me.txtAnimales.EnterMoveNextControl = True
        Me.txtAnimales.Location = New System.Drawing.Point(5, 192)
        Me.txtAnimales.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAnimales.Name = "txtAnimales"
        Me.txtAnimales.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtAnimales.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtAnimales.Size = New System.Drawing.Size(656, 20)
        Me.txtAnimales.TabIndex = 7
        '
        'txtProfesion
        '
        Me.txtProfesion.EnterMoveNextControl = True
        Me.txtProfesion.Location = New System.Drawing.Point(5, 65)
        Me.txtProfesion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtProfesion.Name = "txtProfesion"
        Me.txtProfesion.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtProfesion.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtProfesion.Size = New System.Drawing.Size(346, 20)
        Me.txtProfesion.TabIndex = 8
        '
        'txtSueldoNomina
        '
        Me.txtSueldoNomina.EnterMoveNextControl = True
        Me.txtSueldoNomina.Location = New System.Drawing.Point(181, 107)
        Me.txtSueldoNomina.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtSueldoNomina.Name = "txtSueldoNomina"
        Me.txtSueldoNomina.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtSueldoNomina.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtSueldoNomina.Size = New System.Drawing.Size(170, 20)
        Me.txtSueldoNomina.TabIndex = 5
        '
        'txtContratoTrabajo
        '
        Me.txtContratoTrabajo.EnterMoveNextControl = True
        Me.txtContratoTrabajo.Location = New System.Drawing.Point(357, 65)
        Me.txtContratoTrabajo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtContratoTrabajo.Name = "txtContratoTrabajo"
        Me.txtContratoTrabajo.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtContratoTrabajo.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtContratoTrabajo.Size = New System.Drawing.Size(304, 20)
        Me.txtContratoTrabajo.TabIndex = 9
        '
        'txtAntiguedad
        '
        Me.txtAntiguedad.EnterMoveNextControl = True
        Me.txtAntiguedad.Location = New System.Drawing.Point(5, 107)
        Me.txtAntiguedad.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAntiguedad.Name = "txtAntiguedad"
        Me.txtAntiguedad.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtAntiguedad.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtAntiguedad.Size = New System.Drawing.Size(170, 20)
        Me.txtAntiguedad.TabIndex = 10
        '
        'txtNacionalidad
        '
        Me.txtNacionalidad.EnterMoveNextControl = True
        Me.txtNacionalidad.Location = New System.Drawing.Point(5, 149)
        Me.txtNacionalidad.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNacionalidad.Name = "txtNacionalidad"
        Me.txtNacionalidad.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNacionalidad.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtNacionalidad.Size = New System.Drawing.Size(346, 20)
        Me.txtNacionalidad.TabIndex = 11
        '
        'txtNotas
        '
        Me.txtNotas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtNotas.Location = New System.Drawing.Point(5, 237)
        Me.txtNotas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNotas.Name = "txtNotas"
        Me.txtNotas.Size = New System.Drawing.Size(656, 82)
        Me.txtNotas.TabIndex = 12
        '     Me.txtNotas.UseOptimizedRendering = True
        '
        'txtAdultos
        '
        Me.txtAdultos.EnterMoveNextControl = True
        Me.txtAdultos.Location = New System.Drawing.Point(357, 21)
        Me.txtAdultos.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAdultos.Name = "txtAdultos"
        Me.txtAdultos.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtAdultos.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtAdultos.Size = New System.Drawing.Size(82, 20)
        Me.txtAdultos.TabIndex = 3
        '
        'txtCodigo
        '
        Me.txtCodigo.EnterMoveNextControl = True
        Me.txtCodigo.Location = New System.Drawing.Point(5, 21)
        Me.txtCodigo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCodigo.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txtCodigo.Size = New System.Drawing.Size(21, 20)
        Me.txtCodigo.TabIndex = 0
        '
        'PanelBotones
        '
        Me.PanelBotones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelBotones.Controls.Add(Me.btnSalir)
        Me.PanelBotones.Controls.Add(Me.btnBorrar)
        Me.PanelBotones.Controls.Add(Me.btnAceptar)
        Me.PanelBotones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBotones.Location = New System.Drawing.Point(0, 325)
        Me.PanelBotones.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PanelBotones.Name = "PanelBotones"
        Me.PanelBotones.Size = New System.Drawing.Size(666, 63)
        Me.PanelBotones.TabIndex = 19
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
        Me.btnSalir.Location = New System.Drawing.Point(593, 4)
        Me.btnSalir.LookAndFeel.SkinName = "Metropolis"
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(68, 55)
        Me.btnSalir.TabIndex = 15
        Me.btnSalir.Text = "Salir"
        '
        'btnBorrar
        '
        Me.btnBorrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBorrar.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnBorrar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnBorrar.Appearance.Options.UseBackColor = True
        Me.btnBorrar.Appearance.Options.UseTextOptions = True
        Me.btnBorrar.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnBorrar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnBorrar.Image = Global.My.Resources.Resources.cancel1
        Me.btnBorrar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnBorrar.Location = New System.Drawing.Point(519, 4)
        Me.btnBorrar.LookAndFeel.SkinName = "Metropolis"
        Me.btnBorrar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(68, 55)
        Me.btnBorrar.TabIndex = 14
        Me.btnBorrar.Text = "Borrar"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnAceptar.Appearance.Options.UseBackColor = True
        Me.btnAceptar.Appearance.Options.UseTextOptions = True
        Me.btnAceptar.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnAceptar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnAceptar.Image = Global.My.Resources.Resources.check1
        Me.btnAceptar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnAceptar.Location = New System.Drawing.Point(445, 4)
        Me.btnAceptar.LookAndFeel.SkinName = "Metropolis"
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(68, 55)
        Me.btnAceptar.TabIndex = 13
        Me.btnAceptar.Text = "Aceptar"
        '
        'frmFichaAlquiler
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(666, 388)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelCajas)
        Me.Controls.Add(Me.PanelBotones)
        Me.Name = "frmFichaAlquiler"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ficha de Alquiler"
        CType(Me.PanelCajas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelCajas.ResumeLayout(False)
        Me.PanelCajas.PerformLayout()
        CType(Me.txtSueldoOtros.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNinos.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mskFechaInicioAlquiler.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mskFechaInicioAlquiler.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTiempoContrato.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAnimales.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProfesion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSueldoNomina.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContratoTrabajo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAntiguedad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNacionalidad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNotas.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAdultos.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodigo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBotones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelCajas As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl23 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl22 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl20 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl19 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl17 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtCodigo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTiempoContrato As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtAnimales As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtProfesion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSueldoNomina As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtNotas As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents txtAdultos As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PanelBotones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnSalir As uc_tb_SimpleButton
    Friend WithEvents btnBorrar As uc_tb_SimpleButton
    Friend WithEvents btnAceptar As uc_tb_SimpleButton
    Friend WithEvents txtContratoTrabajo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtAntiguedad As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtNacionalidad As DevExpress.XtraEditors.TextEdit
    Friend WithEvents mskFechaInicioAlquiler As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtNinos As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtSueldoOtros As DevExpress.XtraEditors.TextEdit
End Class
