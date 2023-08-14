<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmColoresGrid
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
        Me.PanelBotones = New DevExpress.XtraEditors.PanelControl()
        Me.btnSalir = New uc_tb_SimpleButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvxClientes = New MyGridControl()
        Me.GvClientes = New MyGridView()
        Me.RepositoryItemComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvxInmuebles = New MyGridControl()
        Me.GvInmuebles = New MyGridView()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBotones.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvxClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GvClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvxInmuebles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GvInmuebles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelBotones
        '
        Me.PanelBotones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelBotones.Controls.Add(Me.btnSalir)
        Me.PanelBotones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBotones.Location = New System.Drawing.Point(0, 438)
        Me.PanelBotones.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PanelBotones.Name = "PanelBotones"
        Me.PanelBotones.Size = New System.Drawing.Size(994, 59)
        Me.PanelBotones.TabIndex = 127
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
        Me.btnSalir.Location = New System.Drawing.Point(924, 2)
        Me.btnSalir.LookAndFeel.SkinName = "Metropolis"
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(68, 55)
        Me.btnSalir.TabIndex = 0
        Me.btnSalir.Text = "Salir"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvxClientes)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(492, 436)
        Me.GroupBox1.TabIndex = 128
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Clientes"
        '
        'dgvxClientes
        '
        Me.dgvxClientes.ColumnaCheck = Nothing
        Me.dgvxClientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvxClientes.Location = New System.Drawing.Point(3, 20)
        Me.dgvxClientes.MainView = Me.GvClientes
        Me.dgvxClientes.Name = "dgvxClientes"
        Me.dgvxClientes.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox2})
        Me.dgvxClientes.Size = New System.Drawing.Size(486, 413)
        Me.dgvxClientes.TabIndex = 1
        Me.dgvxClientes.tb_AnadirColumnaCheck = False
        Me.dgvxClientes.tbPerfilPredeterminado = ""
        Me.dgvxClientes.UseDisabledStatePainter = False
        Me.dgvxClientes.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GvClientes})
        '
        'GvClientes
        '
        Me.GvClientes.GridControl = Me.dgvxClientes
        Me.GvClientes.Name = "GvClientes"
        '
        'RepositoryItemComboBox2
        '
        Me.RepositoryItemComboBox2.AutoHeight = False
        Me.RepositoryItemComboBox2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox2.Name = "RepositoryItemComboBox2"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvxInmuebles)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(498, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(492, 436)
        Me.GroupBox2.TabIndex = 129
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Inmuebles"
        '
        'dgvxInmuebles
        '
        Me.dgvxInmuebles.ColumnaCheck = Nothing
        Me.dgvxInmuebles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvxInmuebles.Location = New System.Drawing.Point(3, 20)
        Me.dgvxInmuebles.MainView = Me.GvInmuebles
        Me.dgvxInmuebles.Name = "dgvxInmuebles"
        Me.dgvxInmuebles.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1})
        Me.dgvxInmuebles.Size = New System.Drawing.Size(486, 413)
        Me.dgvxInmuebles.TabIndex = 2
        Me.dgvxInmuebles.tb_AnadirColumnaCheck = False
        Me.dgvxInmuebles.tbPerfilPredeterminado = ""
        Me.dgvxInmuebles.UseDisabledStatePainter = False
        Me.dgvxInmuebles.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GvInmuebles})
        '
        'GvInmuebles
        '
        Me.GvInmuebles.GridControl = Me.dgvxInmuebles
        Me.GvInmuebles.Name = "GvInmuebles"
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'frmColoresGrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(994, 497)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.PanelBotones)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmColoresGrid"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Significado de los Colores"
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBotones.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvxClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GvClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvxInmuebles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GvInmuebles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelBotones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnSalir As uc_tb_SimpleButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvxClientes As MyGridControl
    Friend WithEvents GvClientes As MyGridView
    Friend WithEvents RepositoryItemComboBox2 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvxInmuebles As MyGridControl
    Friend WithEvents GvInmuebles As MyGridView
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
End Class
