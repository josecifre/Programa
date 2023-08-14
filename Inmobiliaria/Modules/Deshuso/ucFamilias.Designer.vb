Imports Microsoft.VisualBasic
Imports System

Partial Public Class ucFamilias
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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.btnAceptarFamilias = New DevExpress.XtraEditors.SimpleButton()
        Me.btnModificarFamilias = New DevExpress.XtraEditors.SimpleButton()
        Me.btnEliminarFamilias = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAnadirFamilias = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.btnAceptarSubFamilias = New DevExpress.XtraEditors.SimpleButton()
        Me.btnModificarSubFamilias = New DevExpress.XtraEditors.SimpleButton()
        Me.btnEliminarSubFamilias = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAnadirSubFamilias = New DevExpress.XtraEditors.SimpleButton()
        Me.dgvxFamilias = New lpGridControlDevExpress.MyGridControl()
        Me.FamiliasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsSubFamilias = New dsSubFamilias()
        Me.GvFamilias = New lpGridControlDevExpress.MyGridView()
        Me.colFamilia = New lpGridControlDevExpress.MyGridColumn()
        Me.colAgrupacion = New lpGridControlDevExpress.MyGridColumn()
        Me.RepositoryItemLookUpEdit7 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.AgrupacionesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RepositoryItemLookUpEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.RepositoryItemLookUpEdit5 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.RepositoryItemLookUpEdit6 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.RepositoryItemLookUpEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.dgvxSubFamilias = New lpGridControlDevExpress.MyGridControl()
        Me.FKSubFamiliasFamiliasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GvSubFamilias = New lpGridControlDevExpress.MyGridView()
        Me.colFamilia1 = New lpGridControlDevExpress.MyGridColumn()
        Me.colSubFamilia = New lpGridControlDevExpress.MyGridColumn()
        Me.colAgrupacion1 = New lpGridControlDevExpress.MyGridColumn()
        Me.RepositoryItemLookUpEdit8 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.AgrupacionesBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.MyRepositoryLookupEdit1 = New lpGridControlDevExpress.MyRepositoryLookupEdit()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.RepositoryItemLookUpEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        Me.TableAdapterManager = New dsTipoIVATableAdapters.TableAdapterManager()
        Me.colNombre = New lpGridControlDevExpress.MyGridColumn()
        Me.colNumeroVencimientos = New lpGridControlDevExpress.MyGridColumn()
        Me.colDiasPrimerVencimiento = New lpGridControlDevExpress.MyGridColumn()
        Me.colDiasEntreVencimiento = New lpGridControlDevExpress.MyGridColumn()
        Me.colPredeterminado = New lpGridControlDevExpress.MyGridColumn()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.FamiliasTableAdapter = New dsSubFamiliasTableAdapters.FamiliasTableAdapter()
        Me.AgrupacionesTableAdapter = New dsSubFamiliasTableAdapters.AgrupacionesTableAdapter()
        Me.SubFamiliasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SubFamiliasTableAdapter = New dsSubFamiliasTableAdapters.SubFamiliasTableAdapter()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.dgvxFamilias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FamiliasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSubFamilias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GvFamilias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AgrupacionesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvxSubFamilias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FKSubFamiliasFamiliasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GvSubFamilias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AgrupacionesBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyRepositoryLookupEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SubFamiliasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.PanelControl2)
        Me.LayoutControl1.Controls.Add(Me.PanelControl3)
        Me.LayoutControl1.Controls.Add(Me.dgvxFamilias)
        Me.LayoutControl1.Controls.Add(Me.dgvxSubFamilias)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup3})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(302, 521, 415, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1175, 597)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelControl2.Controls.Add(Me.btnAceptarFamilias)
        Me.PanelControl2.Controls.Add(Me.btnModificarFamilias)
        Me.PanelControl2.Controls.Add(Me.btnEliminarFamilias)
        Me.PanelControl2.Controls.Add(Me.btnAnadirFamilias)
        Me.PanelControl2.Location = New System.Drawing.Point(24, 515)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(575, 58)
        Me.PanelControl2.TabIndex = 24
        '
        'btnAceptarFamilias
        '
        Me.btnAceptarFamilias.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptarFamilias.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnAceptarFamilias.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnAceptarFamilias.Appearance.Options.UseBackColor = True
        Me.btnAceptarFamilias.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnAceptarFamilias.Enabled = False
        Me.btnAceptarFamilias.Image = My.Resources.Aceptar
        Me.btnAceptarFamilias.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnAceptarFamilias.Location = New System.Drawing.Point(480, 1)
        Me.btnAceptarFamilias.Name = "btnAceptarFamilias"
        Me.btnAceptarFamilias.Size = New System.Drawing.Size(90, 59)
        Me.btnAceptarFamilias.TabIndex = 3
        Me.btnAceptarFamilias.Text = "Aceptar"
        '
        'btnModificarFamilias
        '
        Me.btnModificarFamilias.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnModificarFamilias.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnModificarFamilias.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnModificarFamilias.Appearance.Options.UseBackColor = True
        Me.btnModificarFamilias.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnModificarFamilias.Enabled = False
        Me.btnModificarFamilias.Image = My.Resources.Modificar
        Me.btnModificarFamilias.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnModificarFamilias.Location = New System.Drawing.Point(384, -1)
        Me.btnModificarFamilias.Name = "btnModificarFamilias"
        Me.btnModificarFamilias.Size = New System.Drawing.Size(90, 59)
        Me.btnModificarFamilias.TabIndex = 2
        Me.btnModificarFamilias.Text = "Modificar"
        '
        'btnEliminarFamilias
        '
        Me.btnEliminarFamilias.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminarFamilias.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnEliminarFamilias.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnEliminarFamilias.Appearance.Options.UseBackColor = True
        Me.btnEliminarFamilias.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnEliminarFamilias.Enabled = False
        Me.btnEliminarFamilias.Image = My.Resources.Eliminar
        Me.btnEliminarFamilias.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnEliminarFamilias.Location = New System.Drawing.Point(288, -1)
        Me.btnEliminarFamilias.Name = "btnEliminarFamilias"
        Me.btnEliminarFamilias.Size = New System.Drawing.Size(90, 59)
        Me.btnEliminarFamilias.TabIndex = 1
        Me.btnEliminarFamilias.Text = "Eliminar"
        Me.ToolTip1.SetToolTip(Me.btnEliminarFamilias, "F2 Eliminar")
        '
        'btnAnadirFamilias
        '
        Me.btnAnadirFamilias.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAnadirFamilias.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnAnadirFamilias.Appearance.Options.UseBackColor = True
        Me.btnAnadirFamilias.Appearance.Options.UseTextOptions = True
        Me.btnAnadirFamilias.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnAnadirFamilias.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnAnadirFamilias.Image = My.Resources.Anadir
        Me.btnAnadirFamilias.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnAnadirFamilias.Location = New System.Drawing.Point(192, 1)
        Me.btnAnadirFamilias.LookAndFeel.SkinName = "Metropolis"
        Me.btnAnadirFamilias.Name = "btnAnadirFamilias"
        Me.btnAnadirFamilias.Size = New System.Drawing.Size(90, 57)
        Me.btnAnadirFamilias.TabIndex = 0
        Me.btnAnadirFamilias.Text = "Añadir"
        Me.ToolTip1.SetToolTip(Me.btnAnadirFamilias, "F1 Añadir")
        '
        'PanelControl3
        '
        Me.PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelControl3.Controls.Add(Me.btnAceptarSubFamilias)
        Me.PanelControl3.Controls.Add(Me.btnModificarSubFamilias)
        Me.PanelControl3.Controls.Add(Me.btnEliminarSubFamilias)
        Me.PanelControl3.Controls.Add(Me.btnAnadirSubFamilias)
        Me.PanelControl3.Location = New System.Drawing.Point(632, 516)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(519, 57)
        Me.PanelControl3.TabIndex = 23
        '
        'btnAceptarSubFamilias
        '
        Me.btnAceptarSubFamilias.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptarSubFamilias.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnAceptarSubFamilias.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnAceptarSubFamilias.Appearance.Options.UseBackColor = True
        Me.btnAceptarSubFamilias.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnAceptarSubFamilias.Enabled = False
        Me.btnAceptarSubFamilias.Image = My.Resources.Aceptar
        Me.btnAceptarSubFamilias.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnAceptarSubFamilias.Location = New System.Drawing.Point(424, 0)
        Me.btnAceptarSubFamilias.Name = "btnAceptarSubFamilias"
        Me.btnAceptarSubFamilias.Size = New System.Drawing.Size(90, 59)
        Me.btnAceptarSubFamilias.TabIndex = 3
        Me.btnAceptarSubFamilias.Text = "Aceptar"
        '
        'btnModificarSubFamilias
        '
        Me.btnModificarSubFamilias.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnModificarSubFamilias.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnModificarSubFamilias.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnModificarSubFamilias.Appearance.Options.UseBackColor = True
        Me.btnModificarSubFamilias.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnModificarSubFamilias.Enabled = False
        Me.btnModificarSubFamilias.Image = My.Resources.Modificar
        Me.btnModificarSubFamilias.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnModificarSubFamilias.Location = New System.Drawing.Point(328, -2)
        Me.btnModificarSubFamilias.Name = "btnModificarSubFamilias"
        Me.btnModificarSubFamilias.Size = New System.Drawing.Size(90, 59)
        Me.btnModificarSubFamilias.TabIndex = 2
        Me.btnModificarSubFamilias.Text = "Modificar"
        '
        'btnEliminarSubFamilias
        '
        Me.btnEliminarSubFamilias.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminarSubFamilias.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnEliminarSubFamilias.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnEliminarSubFamilias.Appearance.Options.UseBackColor = True
        Me.btnEliminarSubFamilias.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnEliminarSubFamilias.Enabled = False
        Me.btnEliminarSubFamilias.Image = My.Resources.Eliminar
        Me.btnEliminarSubFamilias.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnEliminarSubFamilias.Location = New System.Drawing.Point(232, -2)
        Me.btnEliminarSubFamilias.Name = "btnEliminarSubFamilias"
        Me.btnEliminarSubFamilias.Size = New System.Drawing.Size(90, 59)
        Me.btnEliminarSubFamilias.TabIndex = 1
        Me.btnEliminarSubFamilias.Text = "Eliminar"
        Me.ToolTip1.SetToolTip(Me.btnEliminarSubFamilias, "F2 Eliminar")
        '
        'btnAnadirSubFamilias
        '
        Me.btnAnadirSubFamilias.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAnadirSubFamilias.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnAnadirSubFamilias.Appearance.Options.UseBackColor = True
        Me.btnAnadirSubFamilias.Appearance.Options.UseTextOptions = True
        Me.btnAnadirSubFamilias.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnAnadirSubFamilias.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnAnadirSubFamilias.Image = My.Resources.Anadir
        Me.btnAnadirSubFamilias.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnAnadirSubFamilias.Location = New System.Drawing.Point(136, 0)
        Me.btnAnadirSubFamilias.LookAndFeel.SkinName = "Metropolis"
        Me.btnAnadirSubFamilias.Name = "btnAnadirSubFamilias"
        Me.btnAnadirSubFamilias.Size = New System.Drawing.Size(90, 57)
        Me.btnAnadirSubFamilias.TabIndex = 0
        Me.btnAnadirSubFamilias.Text = "Añadir"
        Me.ToolTip1.SetToolTip(Me.btnAnadirSubFamilias, "F1 Añadir")
        '
        'dgvxFamilias
        '
        Me.dgvxFamilias.DataSource = Me.FamiliasBindingSource
        Me.dgvxFamilias.Location = New System.Drawing.Point(24, 43)
        Me.dgvxFamilias.MainView = Me.GvFamilias
        Me.dgvxFamilias.Name = "dgvxFamilias"
        Me.dgvxFamilias.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLookUpEdit4, Me.RepositoryItemLookUpEdit5, Me.RepositoryItemLookUpEdit6, Me.RepositoryItemLookUpEdit3, Me.RepositoryItemLookUpEdit7})
        Me.dgvxFamilias.Size = New System.Drawing.Size(575, 468)
        Me.dgvxFamilias.TabIndex = 19
        Me.dgvxFamilias.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GvFamilias})
        '
        'FamiliasBindingSource
        '
        Me.FamiliasBindingSource.DataMember = "Familias"
        Me.FamiliasBindingSource.DataSource = Me.DsSubFamilias
        '
        'DsSubFamilias
        '
        Me.DsSubFamilias.DataSetName = "dsSubFamilias"
        Me.DsSubFamilias.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GvFamilias
        '
        Me.GvFamilias.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colFamilia, Me.colAgrupacion})
        Me.GvFamilias.GridControl = Me.dgvxFamilias
        Me.GvFamilias.Name = "GvFamilias"
        Me.GvFamilias.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        '
        'colFamilia
        '
        Me.colFamilia.FieldName = "Familia"
        Me.colFamilia.Name = "colFamilia"
        Me.colFamilia.UseAdvancedFiltering = True
        Me.colFamilia.Visible = True
        Me.colFamilia.VisibleIndex = 0
        '
        'colAgrupacion
        '
        Me.colAgrupacion.ColumnEdit = Me.RepositoryItemLookUpEdit7
        Me.colAgrupacion.FieldName = "Agrupacion"
        Me.colAgrupacion.Name = "colAgrupacion"
        Me.colAgrupacion.UseAdvancedFiltering = True
        Me.colAgrupacion.Visible = True
        Me.colAgrupacion.VisibleIndex = 1
        '
        'RepositoryItemLookUpEdit7
        '
        Me.RepositoryItemLookUpEdit7.AutoHeight = False
        Me.RepositoryItemLookUpEdit7.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit7.DataSource = Me.AgrupacionesBindingSource
        Me.RepositoryItemLookUpEdit7.DisplayMember = "Agrupacion"
        Me.RepositoryItemLookUpEdit7.Name = "RepositoryItemLookUpEdit7"
        Me.RepositoryItemLookUpEdit7.ValueMember = "Agrupacion"
        '
        'AgrupacionesBindingSource
        '
        Me.AgrupacionesBindingSource.DataMember = "Agrupaciones"
        Me.AgrupacionesBindingSource.DataSource = Me.DsSubFamilias
        '
        'RepositoryItemLookUpEdit4
        '
        Me.RepositoryItemLookUpEdit4.AutoHeight = False
        Me.RepositoryItemLookUpEdit4.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit4.DisplayMember = "Gama"
        Me.RepositoryItemLookUpEdit4.Name = "RepositoryItemLookUpEdit4"
        Me.RepositoryItemLookUpEdit4.ValueMember = "Gama"
        '
        'RepositoryItemLookUpEdit5
        '
        Me.RepositoryItemLookUpEdit5.AutoHeight = False
        Me.RepositoryItemLookUpEdit5.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit5.DisplayMember = "Fabricante"
        Me.RepositoryItemLookUpEdit5.Name = "RepositoryItemLookUpEdit5"
        Me.RepositoryItemLookUpEdit5.ValueMember = "Fabricante"
        '
        'RepositoryItemLookUpEdit6
        '
        Me.RepositoryItemLookUpEdit6.AutoHeight = False
        Me.RepositoryItemLookUpEdit6.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit6.DisplayMember = "Agrupacion"
        Me.RepositoryItemLookUpEdit6.Name = "RepositoryItemLookUpEdit6"
        Me.RepositoryItemLookUpEdit6.ValueMember = "Agrupacion"
        '
        'RepositoryItemLookUpEdit3
        '
        Me.RepositoryItemLookUpEdit3.AutoHeight = False
        Me.RepositoryItemLookUpEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit3.DisplayMember = "Agrupacion"
        Me.RepositoryItemLookUpEdit3.Name = "RepositoryItemLookUpEdit3"
        Me.RepositoryItemLookUpEdit3.ValueMember = "Agrupacion"
        '
        'dgvxSubFamilias
        '
        Me.dgvxSubFamilias.DataSource = Me.FKSubFamiliasFamiliasBindingSource
        Me.dgvxSubFamilias.Location = New System.Drawing.Point(632, 43)
        Me.dgvxSubFamilias.MainView = Me.GvSubFamilias
        Me.dgvxSubFamilias.Name = "dgvxSubFamilias"
        Me.dgvxSubFamilias.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.MyRepositoryLookupEdit1, Me.RepositoryItemComboBox1, Me.RepositoryItemLookUpEdit1, Me.RepositoryItemLookUpEdit2, Me.RepositoryItemLookUpEdit8})
        Me.dgvxSubFamilias.Size = New System.Drawing.Size(519, 469)
        Me.dgvxSubFamilias.TabIndex = 15
        Me.dgvxSubFamilias.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GvSubFamilias})
        '
        'FKSubFamiliasFamiliasBindingSource
        '
        Me.FKSubFamiliasFamiliasBindingSource.DataMember = "FK_SubFamilias_Familias"
        Me.FKSubFamiliasFamiliasBindingSource.DataSource = Me.FamiliasBindingSource
        '
        'GvSubFamilias
        '
        Me.GvSubFamilias.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colFamilia1, Me.colSubFamilia, Me.colAgrupacion1})
        Me.GvSubFamilias.GridControl = Me.dgvxSubFamilias
        Me.GvSubFamilias.Name = "GvSubFamilias"
        '
        'colFamilia1
        '
        Me.colFamilia1.FieldName = "Familia"
        Me.colFamilia1.Name = "colFamilia1"
        Me.colFamilia1.UseAdvancedFiltering = True
        Me.colFamilia1.Visible = True
        Me.colFamilia1.VisibleIndex = 0
        '
        'colSubFamilia
        '
        Me.colSubFamilia.FieldName = "SubFamilia"
        Me.colSubFamilia.Name = "colSubFamilia"
        Me.colSubFamilia.UseAdvancedFiltering = True
        Me.colSubFamilia.Visible = True
        Me.colSubFamilia.VisibleIndex = 1
        '
        'colAgrupacion1
        '
        Me.colAgrupacion1.ColumnEdit = Me.RepositoryItemLookUpEdit8
        Me.colAgrupacion1.FieldName = "Agrupacion"
        Me.colAgrupacion1.Name = "colAgrupacion1"
        Me.colAgrupacion1.UseAdvancedFiltering = True
        Me.colAgrupacion1.Visible = True
        Me.colAgrupacion1.VisibleIndex = 2
        '
        'RepositoryItemLookUpEdit8
        '
        Me.RepositoryItemLookUpEdit8.AutoHeight = False
        Me.RepositoryItemLookUpEdit8.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit8.DataSource = Me.AgrupacionesBindingSource1
        Me.RepositoryItemLookUpEdit8.DisplayMember = "Agrupacion"
        Me.RepositoryItemLookUpEdit8.Name = "RepositoryItemLookUpEdit8"
        Me.RepositoryItemLookUpEdit8.ValueMember = "Agrupacion"
        '
        'AgrupacionesBindingSource1
        '
        Me.AgrupacionesBindingSource1.DataMember = "Agrupaciones"
        Me.AgrupacionesBindingSource1.DataSource = Me.DsSubFamilias
        '
        'MyRepositoryLookupEdit1
        '
        Me.MyRepositoryLookupEdit1.AutoHeight = False
        Me.MyRepositoryLookupEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.MyRepositoryLookupEdit1.Name = "MyRepositoryLookupEdit1"
        Me.MyRepositoryLookupEdit1.UseAdvancedFiltering = True
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'RepositoryItemLookUpEdit1
        '
        Me.RepositoryItemLookUpEdit1.AutoHeight = False
        Me.RepositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit1.DisplayMember = "Agrupaciones.Agrupacion"
        Me.RepositoryItemLookUpEdit1.Name = "RepositoryItemLookUpEdit1"
        Me.RepositoryItemLookUpEdit1.ValueMember = "Agrupaciones.Agrupacion"
        '
        'RepositoryItemLookUpEdit2
        '
        Me.RepositoryItemLookUpEdit2.AutoHeight = False
        Me.RepositoryItemLookUpEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit2.DisplayMember = "Agrupacion"
        Me.RepositoryItemLookUpEdit2.Name = "RepositoryItemLookUpEdit2"
        Me.RepositoryItemLookUpEdit2.ValueMember = "Agrupacion"
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.CustomizationFormText = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(608, 383)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(547, 194)
        Me.LayoutControlGroup3.Text = "Gamas"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Root"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2, Me.LayoutControlGroup4, Me.SplitterItem1})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1175, 597)
        Me.LayoutControlGroup1.Text = "Root"
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CustomizationFormText = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem5})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(608, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(547, 577)
        Me.LayoutControlGroup2.Text = "SubFamilias"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.dgvxSubFamilias
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(523, 473)
        Me.LayoutControlItem1.Text = "LayoutControlItem1"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextToControlDistance = 0
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.PanelControl3
        Me.LayoutControlItem5.CustomizationFormText = "LayoutControlItem5"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 473)
        Me.LayoutControlItem5.MaxSize = New System.Drawing.Size(0, 61)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(104, 61)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(523, 61)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.Text = "LayoutControlItem5"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextToControlDistance = 0
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.CustomizationFormText = "LayoutControlGroup4"
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3, Me.LayoutControlItem4})
        Me.LayoutControlGroup4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup4.Name = "LayoutControlGroup4"
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(603, 577)
        Me.LayoutControlGroup4.Text = "Familias"
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.dgvxFamilias
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(104, 24)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(579, 472)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.Text = "LayoutControlItem3"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextToControlDistance = 0
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.PanelControl2
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 472)
        Me.LayoutControlItem4.MaxSize = New System.Drawing.Size(0, 62)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(204, 62)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(579, 62)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.Text = "LayoutControlItem4"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextToControlDistance = 0
        Me.LayoutControlItem4.TextVisible = False
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.CustomizationFormText = "SplitterItem1"
        Me.SplitterItem1.Location = New System.Drawing.Point(603, 0)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(5, 577)
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.AgrupacionesTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.TipoIVATableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = dsTipoIVATableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'colNombre
        '
        Me.colNombre.FieldName = "Nombre"
        Me.colNombre.Name = "colNombre"
        Me.colNombre.UseAdvancedFiltering = True
        Me.colNombre.Visible = True
        Me.colNombre.VisibleIndex = 0
        '
        'colNumeroVencimientos
        '
        Me.colNumeroVencimientos.FieldName = "NumeroVencimientos"
        Me.colNumeroVencimientos.Name = "colNumeroVencimientos"
        Me.colNumeroVencimientos.UseAdvancedFiltering = True
        Me.colNumeroVencimientos.Visible = True
        Me.colNumeroVencimientos.VisibleIndex = 1
        '
        'colDiasPrimerVencimiento
        '
        Me.colDiasPrimerVencimiento.FieldName = "DiasPrimerVencimiento"
        Me.colDiasPrimerVencimiento.Name = "colDiasPrimerVencimiento"
        Me.colDiasPrimerVencimiento.UseAdvancedFiltering = True
        Me.colDiasPrimerVencimiento.Visible = True
        Me.colDiasPrimerVencimiento.VisibleIndex = 2
        '
        'colDiasEntreVencimiento
        '
        Me.colDiasEntreVencimiento.FieldName = "DiasEntreVencimiento"
        Me.colDiasEntreVencimiento.Name = "colDiasEntreVencimiento"
        Me.colDiasEntreVencimiento.UseAdvancedFiltering = True
        Me.colDiasEntreVencimiento.Visible = True
        Me.colDiasEntreVencimiento.VisibleIndex = 3
        '
        'colPredeterminado
        '
        Me.colPredeterminado.FieldName = "Predeterminado"
        Me.colPredeterminado.Name = "colPredeterminado"
        Me.colPredeterminado.UseAdvancedFiltering = True
        Me.colPredeterminado.Visible = True
        Me.colPredeterminado.VisibleIndex = 4
        '
        'FamiliasTableAdapter
        '
        Me.FamiliasTableAdapter.ClearBeforeFill = True
        '
        'AgrupacionesTableAdapter
        '
        Me.AgrupacionesTableAdapter.ClearBeforeFill = True
        '
        'SubFamiliasBindingSource
        '
        Me.SubFamiliasBindingSource.DataMember = "SubFamilias"
        Me.SubFamiliasBindingSource.DataSource = Me.DsSubFamilias
        '
        'SubFamiliasTableAdapter
        '
        Me.SubFamiliasTableAdapter.ClearBeforeFill = True
        '
        'ucFamilias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "ucFamilias"
        Me.Size = New System.Drawing.Size(1175, 597)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.dgvxFamilias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FamiliasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSubFamilias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GvFamilias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AgrupacionesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvxSubFamilias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FKSubFamiliasFamiliasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GvSubFamilias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AgrupacionesBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyRepositoryLookupEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SubFamiliasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents dgvxSubFamilias As lpGridControlDevExpress.MyGridControl
    Friend WithEvents GvSubFamilias As lpGridControlDevExpress.MyGridView
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents dgvxFamilias As lpGridControlDevExpress.MyGridControl
    Friend WithEvents GvFamilias As lpGridControlDevExpress.MyGridView
    Friend WithEvents TableAdapterManager As dsTipoIVATableAdapters.TableAdapterManager
    Friend WithEvents colNombre As lpGridControlDevExpress.MyGridColumn
    Friend WithEvents colNumeroVencimientos As lpGridControlDevExpress.MyGridColumn
    Friend WithEvents colDiasPrimerVencimiento As lpGridControlDevExpress.MyGridColumn
    Friend WithEvents colDiasEntreVencimiento As lpGridControlDevExpress.MyGridColumn
    Friend WithEvents colPredeterminado As lpGridControlDevExpress.MyGridColumn
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnAceptarFamilias As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnModificarFamilias As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnEliminarFamilias As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAnadirFamilias As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnAceptarSubFamilias As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnModificarSubFamilias As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnEliminarSubFamilias As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAnadirSubFamilias As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents MyRepositoryLookupEdit1 As lpGridControlDevExpress.MyRepositoryLookupEdit
    Friend WithEvents RepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit

    Friend WithEvents RepositoryItemLookUpEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepositoryItemLookUpEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepositoryItemLookUpEdit5 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepositoryItemLookUpEdit6 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepositoryItemLookUpEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents FamiliasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsSubFamilias As dsSubFamilias
    Friend WithEvents colFamilia As lpGridControlDevExpress.MyGridColumn
    Friend WithEvents colAgrupacion As lpGridControlDevExpress.MyGridColumn
    Friend WithEvents FamiliasTableAdapter As dsSubFamiliasTableAdapters.FamiliasTableAdapter
    Friend WithEvents RepositoryItemLookUpEdit7 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents AgrupacionesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AgrupacionesTableAdapter As dsSubFamiliasTableAdapters.AgrupacionesTableAdapter
    Friend WithEvents FKSubFamiliasFamiliasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents colFamilia1 As lpGridControlDevExpress.MyGridColumn
    Friend WithEvents colSubFamilia As lpGridControlDevExpress.MyGridColumn
    Friend WithEvents colAgrupacion1 As lpGridControlDevExpress.MyGridColumn
    Friend WithEvents SubFamiliasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SubFamiliasTableAdapter As dsSubFamiliasTableAdapters.SubFamiliasTableAdapter
    Friend WithEvents RepositoryItemLookUpEdit8 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents AgrupacionesBindingSource1 As System.Windows.Forms.BindingSource

End Class
