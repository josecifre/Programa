Imports Microsoft.VisualBasic
Imports System

Partial Public Class ucMantenimientos

    Inherits System.Windows.Forms.UserControl

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
        Me.dgvx = New MyGridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuAnadir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.Gv = New MyGridView()
        Me.RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.PanelBotones = New DevExpress.XtraEditors.PanelControl()
        Me.btnAceptar = New uc_tb_SimpleButton()
        Me.btnModificar = New uc_tb_SimpleButton()
        Me.btnEliminar = New uc_tb_SimpleButton()
        Me.btnAnadir = New uc_tb_SimpleButton()
        Me.pnlGrid = New DevExpress.XtraEditors.PanelControl()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.dgvx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.Gv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBotones.SuspendLayout()
        CType(Me.pnlGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGrid.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvx
        '
        Me.dgvx.ColumnaCheck = Nothing
        Me.dgvx.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgvx.Location = New System.Drawing.Point(2, 2)
        Me.dgvx.MainView = Me.Gv
        Me.dgvx.Name = "dgvx"
        Me.dgvx.Size = New System.Drawing.Size(394, 198)
        Me.dgvx.TabIndex = 0
        Me.dgvx.tb_AnadirColumnaCheck = False
        Me.dgvx.tbPerfilPredeterminado = ""
        Me.dgvx.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Gv})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAnadir, Me.mnuModificar, Me.mnuEliminar})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(126, 70)
        '
        'mnuAnadir
        '
        Me.mnuAnadir.Name = "mnuAnadir"
        Me.mnuAnadir.Size = New System.Drawing.Size(125, 22)
        Me.mnuAnadir.Text = "Añadir"
        '
        'mnuModificar
        '
        Me.mnuModificar.Name = "mnuModificar"
        Me.mnuModificar.Size = New System.Drawing.Size(125, 22)
        Me.mnuModificar.Text = "Modificar"
        '
        'mnuEliminar
        '
        Me.mnuEliminar.Name = "mnuEliminar"
        Me.mnuEliminar.Size = New System.Drawing.Size(125, 22)
        Me.mnuEliminar.Text = "Eliminar"
        '
        'Gv
        '
        Me.Gv.GridControl = Me.dgvx
        Me.Gv.Name = "Gv"
        Me.Gv.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        '
        'RepositoryItemLookUpEdit1
        '
        Me.RepositoryItemLookUpEdit1.Name = "RepositoryItemLookUpEdit1"
        '
        'PanelBotones
        '
        Me.PanelBotones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelBotones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelBotones.Controls.Add(Me.btnAceptar)
        Me.PanelBotones.Controls.Add(Me.btnModificar)
        Me.PanelBotones.Controls.Add(Me.btnEliminar)
        Me.PanelBotones.Controls.Add(Me.btnAnadir)
        Me.PanelBotones.Location = New System.Drawing.Point(3, 202)
        Me.PanelBotones.Name = "PanelBotones"
        Me.PanelBotones.Size = New System.Drawing.Size(398, 72)
        Me.PanelBotones.TabIndex = 1
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnAceptar.Appearance.Options.UseBackColor = True
        Me.btnAceptar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnAceptar.Enabled = False
        Me.btnAceptar.Image = Global.My.Resources.Resources.check1
        Me.btnAceptar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnAceptar.Location = New System.Drawing.Point(328, 5)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(65, 63)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.ToolTip = "F12 Aceptar"
        '
        'btnModificar
        '
        Me.btnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnModificar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnModificar.Appearance.Options.UseBackColor = True
        Me.btnModificar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnModificar.Enabled = False
        Me.btnModificar.Image = Global.My.Resources.Resources.Editar
        Me.btnModificar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnModificar.Location = New System.Drawing.Point(257, 5)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(65, 63)
        Me.btnModificar.TabIndex = 3
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.ToolTip = "F3 Modificar"
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnEliminar.Appearance.Options.UseBackColor = True
        Me.btnEliminar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Image = Global.My.Resources.Resources.Eliminar1
        Me.btnEliminar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnEliminar.Location = New System.Drawing.Point(186, 5)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(65, 63)
        Me.btnEliminar.TabIndex = 2
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.ToolTip = "F2 Borrar"
        '
        'btnAnadir
        '
        Me.btnAnadir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAnadir.Appearance.Options.UseBackColor = True
        Me.btnAnadir.Appearance.Options.UseTextOptions = True
        Me.btnAnadir.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnAnadir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnAnadir.Image = Global.My.Resources.Resources.Add_New
        Me.btnAnadir.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnAnadir.Location = New System.Drawing.Point(115, 5)
        Me.btnAnadir.LookAndFeel.SkinName = "Metropolis"
        Me.btnAnadir.Name = "btnAnadir"
        Me.btnAnadir.Size = New System.Drawing.Size(65, 63)
        Me.btnAnadir.TabIndex = 1
        Me.btnAnadir.Text = "Añadir"
        Me.ToolTip1.SetToolTip(Me.btnAnadir, "F1 Añadir")
        '
        'pnlGrid
        '
        Me.pnlGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlGrid.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.pnlGrid.Controls.Add(Me.dgvx)
        Me.pnlGrid.Location = New System.Drawing.Point(3, 0)
        Me.pnlGrid.Name = "pnlGrid"
        Me.pnlGrid.Size = New System.Drawing.Size(398, 202)
        Me.pnlGrid.TabIndex = 0
        '
        'ucMantenimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.pnlGrid)
        Me.Controls.Add(Me.PanelBotones)
        Me.Name = "ucMantenimientos"
        Me.Size = New System.Drawing.Size(401, 277)
        CType(Me.dgvx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.Gv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelBotones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBotones.ResumeLayout(False)
        CType(Me.pnlGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGrid.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvx As MyGridControl
    Friend WithEvents Gv As MyGridView
    Friend WithEvents RepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents PanelBotones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnAceptar As uc_tb_SimpleButton
    Friend WithEvents btnModificar As uc_tb_SimpleButton
    Friend WithEvents btnEliminar As uc_tb_SimpleButton
    Friend WithEvents btnAnadir As uc_tb_SimpleButton
    Friend WithEvents pnlGrid As DevExpress.XtraEditors.PanelControl
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuAnadir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuModificar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEliminar As System.Windows.Forms.ToolStripMenuItem

End Class
