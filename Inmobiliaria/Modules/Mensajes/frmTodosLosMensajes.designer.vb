<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTodosLosMensajes
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.txtNombre = New DevExpress.XtraEditors.TextEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PanelBotones = New System.Windows.Forms.Panel()
        Me.btnConversacion = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.popMenuFiltrarPor = New System.Windows.Forms.ToolStripMenuItem()
        Me.PopMenuFiltrarExcluyendo = New System.Windows.Forms.ToolStripMenuItem()
        Me.popMenuFiltrarMayorQue = New System.Windows.Forms.ToolStripMenuItem()
        Me.popMenuFiltrarMayorOIgualQue = New System.Windows.Forms.ToolStripMenuItem()
        Me.popMenuFiltrarMenorQue = New System.Windows.Forms.ToolStripMenuItem()
        Me.popMenuFiltrarMenorOIgualQue = New System.Windows.Forms.ToolStripMenuItem()
        Me.PoPMenuFiltrarSinFiltro = New System.Windows.Forms.ToolStripMenuItem()
        Me.PoPMenuOcultarColumna = New System.Windows.Forms.ToolStripMenuItem()
        Me.PoPMenuCongelarColumna = New System.Windows.Forms.ToolStripMenuItem()
        Me.PopMenuExportarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvx = New MyGridControl()
        Me.MyGridView1 = New MyGridView()
        
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.PanelEdicion = New System.Windows.Forms.GroupBox()
        Me.PanelBotones.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvx, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEdicion.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtNombre
        '
        Me.txtNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(9, 34)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(1410, 98)
        Me.txtNombre.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Mensaje"
        '
        'PanelBotones
        '
        Me.PanelBotones.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelBotones.Controls.Add(Me.btnConversacion)
        Me.PanelBotones.Controls.Add(Me.btnSalir)
        Me.PanelBotones.Location = New System.Drawing.Point(8, 911)
        Me.PanelBotones.Name = "PanelBotones"
        Me.PanelBotones.Size = New System.Drawing.Size(1426, 65)
        Me.PanelBotones.TabIndex = 2
        '
        'btnConversacion
        '
        Me.btnConversacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnConversacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConversacion.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnConversacion.ImageKey = "(ninguno)"
        Me.btnConversacion.Location = New System.Drawing.Point(3, 3)
        Me.btnConversacion.Name = "btnConversacion"
        Me.btnConversacion.Size = New System.Drawing.Size(133, 57)
        Me.btnConversacion.TabIndex = 93
        Me.btnConversacion.Text = "Conversaciones"
        Me.btnConversacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnConversacion.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSalir.Location = New System.Drawing.Point(1336, 3)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(80, 57)
        Me.btnSalir.TabIndex = 5
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.popMenuFiltrarPor, Me.PopMenuFiltrarExcluyendo, Me.popMenuFiltrarMayorQue, Me.popMenuFiltrarMayorOIgualQue, Me.popMenuFiltrarMenorQue, Me.popMenuFiltrarMenorOIgualQue, Me.PoPMenuFiltrarSinFiltro, Me.PoPMenuOcultarColumna, Me.PoPMenuCongelarColumna, Me.PopMenuExportarExcel})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(196, 224)
        '
        'popMenuFiltrarPor
        '
        Me.popMenuFiltrarPor.Name = "popMenuFiltrarPor"
        Me.popMenuFiltrarPor.Size = New System.Drawing.Size(195, 22)
        Me.popMenuFiltrarPor.Text = "Filtrar Por"
        '
        'PopMenuFiltrarExcluyendo
        '
        Me.PopMenuFiltrarExcluyendo.Name = "PopMenuFiltrarExcluyendo"
        Me.PopMenuFiltrarExcluyendo.Size = New System.Drawing.Size(195, 22)
        Me.PopMenuFiltrarExcluyendo.Text = "Filtrar Excluyendo"
        '
        'popMenuFiltrarMayorQue
        '
        Me.popMenuFiltrarMayorQue.Name = "popMenuFiltrarMayorQue"
        Me.popMenuFiltrarMayorQue.Size = New System.Drawing.Size(195, 22)
        Me.popMenuFiltrarMayorQue.Text = "Mayor Que"
        '
        'popMenuFiltrarMayorOIgualQue
        '
        Me.popMenuFiltrarMayorOIgualQue.Name = "popMenuFiltrarMayorOIgualQue"
        Me.popMenuFiltrarMayorOIgualQue.Size = New System.Drawing.Size(195, 22)
        Me.popMenuFiltrarMayorOIgualQue.Text = "Mayor o Igual Que"
        '
        'popMenuFiltrarMenorQue
        '
        Me.popMenuFiltrarMenorQue.Name = "popMenuFiltrarMenorQue"
        Me.popMenuFiltrarMenorQue.Size = New System.Drawing.Size(195, 22)
        Me.popMenuFiltrarMenorQue.Text = "Menor Que"
        '
        'popMenuFiltrarMenorOIgualQue
        '
        Me.popMenuFiltrarMenorOIgualQue.Name = "popMenuFiltrarMenorOIgualQue"
        Me.popMenuFiltrarMenorOIgualQue.Size = New System.Drawing.Size(195, 22)
        Me.popMenuFiltrarMenorOIgualQue.Text = "Menor o Igual Que"
        '
        'PoPMenuFiltrarSinFiltro
        '
        Me.PoPMenuFiltrarSinFiltro.Name = "PoPMenuFiltrarSinFiltro"
        Me.PoPMenuFiltrarSinFiltro.Size = New System.Drawing.Size(195, 22)
        Me.PoPMenuFiltrarSinFiltro.Text = "Quitar Filtro"
        '
        'PoPMenuOcultarColumna
        '
        Me.PoPMenuOcultarColumna.Name = "PoPMenuOcultarColumna"
        Me.PoPMenuOcultarColumna.Size = New System.Drawing.Size(195, 22)
        Me.PoPMenuOcultarColumna.Text = "Ocultar Columna"
        '
        'PoPMenuCongelarColumna
        '
        Me.PoPMenuCongelarColumna.Name = "PoPMenuCongelarColumna"
        Me.PoPMenuCongelarColumna.Size = New System.Drawing.Size(195, 22)
        Me.PoPMenuCongelarColumna.Text = "Fijar / Liberar Columna"
        '
        'PopMenuExportarExcel
        '
        Me.PopMenuExportarExcel.Name = "PopMenuExportarExcel"
        Me.PopMenuExportarExcel.Size = New System.Drawing.Size(195, 22)
        Me.PopMenuExportarExcel.Text = "Exportar Excel"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.dgvx)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1429, 758)
        Me.GroupBox2.TabIndex = 28
        Me.GroupBox2.TabStop = False
        '
        'dgvx
        '
        Me.dgvx.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgvx.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvx.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvx.Location = New System.Drawing.Point(3, 16)
        Me.dgvx.LookAndFeel.SkinName = "Black"
        Me.dgvx.LookAndFeel.UseDefaultLookAndFeel = False
        Me.dgvx.MainView = Me.MyGridView1
        Me.dgvx.Name = "dgvx"
        Me.dgvx.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.dgvx.Size = New System.Drawing.Size(1423, 739)
        Me.dgvx.TabIndex = 1
        Me.dgvx.UseDisabledStatePainter = False
        Me.dgvx.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MyGridView1})
        '
        'MyGridView1
        '
        Me.MyGridView1.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Tahoma", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Strikeout), System.Drawing.FontStyle))
        Me.MyGridView1.Appearance.ColumnFilterButton.Options.UseFont = True
        Me.MyGridView1.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Tempus Sans ITC", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(1, Byte), True)
        Me.MyGridView1.Appearance.ColumnFilterButtonActive.Options.UseFont = True
        Me.MyGridView1.Appearance.DetailTip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline)
        Me.MyGridView1.Appearance.DetailTip.Options.UseFont = True
        Me.MyGridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.Honeydew
        Me.MyGridView1.Appearance.EvenRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyGridView1.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black
        Me.MyGridView1.Appearance.EvenRow.Options.UseBackColor = True
        Me.MyGridView1.Appearance.EvenRow.Options.UseFont = True
        Me.MyGridView1.Appearance.EvenRow.Options.UseForeColor = True
        Me.MyGridView1.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Strikeout)
        Me.MyGridView1.Appearance.FilterCloseButton.Options.UseFont = True
        Me.MyGridView1.Appearance.FilterPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyGridView1.Appearance.FilterPanel.Options.UseFont = True
        Me.MyGridView1.Appearance.FocusedCell.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyGridView1.Appearance.FocusedCell.Options.UseFont = True
        Me.MyGridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.Silver
        Me.MyGridView1.Appearance.FocusedRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyGridView1.Appearance.FocusedRow.Options.UseBackColor = True
        Me.MyGridView1.Appearance.FocusedRow.Options.UseFont = True
        Me.MyGridView1.Appearance.FooterPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte), True)
        Me.MyGridView1.Appearance.FooterPanel.Options.UseFont = True
        Me.MyGridView1.Appearance.FooterPanel.Options.UseTextOptions = True
        Me.MyGridView1.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.MyGridView1.Appearance.GroupFooter.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.MyGridView1.Appearance.GroupFooter.Options.UseFont = True
        Me.MyGridView1.Appearance.GroupPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyGridView1.Appearance.GroupPanel.Options.UseFont = True
        Me.MyGridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.MyGridView1.Appearance.HeaderPanel.Options.UseFont = True
        Me.MyGridView1.Appearance.Row.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyGridView1.Appearance.Row.Options.UseFont = True
        Me.MyGridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.White
        Me.MyGridView1.Appearance.SelectedRow.Options.UseBackColor = True
        Me.MyGridView1.GridControl = Me.dgvx
        Me.MyGridView1.GroupPanelText = "Arrastre la cabecera de la columna para agrupar por esa columna"
        Me.MyGridView1.Name = "MyGridView1"
        Me.MyGridView1.OptionsView.EnableAppearanceEvenRow = True
        Me.MyGridView1.OptionsView.ShowAutoFilterRow = True
        Me.MyGridView1.RowHeight = 30
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'PanelEdicion
        '
        Me.PanelEdicion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelEdicion.Controls.Add(Me.txtNombre)
        Me.PanelEdicion.Controls.Add(Me.Label2)
        Me.PanelEdicion.Location = New System.Drawing.Point(5, 767)
        Me.PanelEdicion.Name = "PanelEdicion"
        Me.PanelEdicion.Size = New System.Drawing.Size(1429, 138)
        Me.PanelEdicion.TabIndex = 29
        Me.PanelEdicion.TabStop = False
        '
        'frmTodosLosMensajes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(1440, 973)
        Me.Controls.Add(Me.PanelBotones)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.PanelEdicion)
        Me.KeyPreview = True
        Me.Name = "frmTodosLosMensajes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelBotones.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvx, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEdicion.ResumeLayout(False)
        Me.PanelEdicion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents popMenuFiltrarPor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PopMenuFiltrarExcluyendo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents popMenuFiltrarMayorQue As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents popMenuFiltrarMayorOIgualQue As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents popMenuFiltrarMenorQue As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents popMenuFiltrarMenorOIgualQue As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PoPMenuFiltrarSinFiltro As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PoPMenuOcultarColumna As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PoPMenuCongelarColumna As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Public WithEvents PanelBotones As System.Windows.Forms.Panel
    Friend WithEvents PopMenuExportarExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PanelEdicion As System.Windows.Forms.GroupBox
 
    Friend WithEvents dgvx As MyGridControl
    Friend WithEvents MyGridView1 As MyGridView
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents btnConversacion As System.Windows.Forms.Button

End Class
