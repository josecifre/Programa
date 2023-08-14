
Namespace Venalia

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ucComunicacionesDetalle
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
            Me.Gv = New MyGridView()
            Me.RepositoryItemComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
            Me.LabelControl20 = New DevExpress.XtraEditors.LabelControl()
            Me.PanelTitulo = New DevExpress.XtraEditors.PanelControl()
            Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
            Me.btnRef = New uc_tb_SimpleButton()
            Me.btnModificarObservacionesLlamada = New uc_tb_SimpleButton()
            Me.btnLlamadas = New uc_tb_SimpleButton()
            Me.btnSoloLlamadas = New uc_tb_SimpleButton()
            Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            CType(Me.dgvx, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.Gv, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelTitulo.SuspendLayout()
            CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl3.SuspendLayout()
            CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl2.SuspendLayout()
            Me.SuspendLayout()
            '
            'dgvx
            '
            Me.dgvx.ColumnaCheck = Nothing
            Me.dgvx.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvx.Location = New System.Drawing.Point(2, 2)
            Me.dgvx.MainView = Me.Gv
            Me.dgvx.Name = "dgvx"
            Me.dgvx.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox2})
            Me.dgvx.Size = New System.Drawing.Size(478, 175)
            Me.dgvx.TabIndex = 1
            Me.dgvx.tb_AnadirColumnaCheck = False
            Me.dgvx.tbPerfilPredeterminado = ""
            Me.ToolTip1.SetToolTip(Me.dgvx, "Haga doble click para modificar las observaciones de las llamadas")
            Me.dgvx.UseDisabledStatePainter = False
            Me.dgvx.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Gv})
            '
            'Gv
            '
            Me.Gv.GridControl = Me.dgvx
            Me.Gv.Name = "Gv"
            '
            'RepositoryItemComboBox2
            '
            Me.RepositoryItemComboBox2.AutoHeight = False
            Me.RepositoryItemComboBox2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.RepositoryItemComboBox2.Name = "RepositoryItemComboBox2"
            '
            'LabelControl20
            '
            Me.LabelControl20.Location = New System.Drawing.Point(5, 5)
            Me.LabelControl20.Name = "LabelControl20"
            Me.LabelControl20.Size = New System.Drawing.Size(102, 13)
            Me.LabelControl20.TabIndex = 187
            Me.LabelControl20.Text = "Acciones Comerciales"
            '
            'PanelTitulo
            '
            Me.PanelTitulo.Controls.Add(Me.LabelControl20)
            Me.PanelTitulo.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelTitulo.Location = New System.Drawing.Point(3, 0)
            Me.PanelTitulo.Name = "PanelTitulo"
            Me.PanelTitulo.Size = New System.Drawing.Size(482, 26)
            Me.PanelTitulo.TabIndex = 188
            '
            'PanelControl3
            '
            Me.PanelControl3.Controls.Add(Me.btnRef)
            Me.PanelControl3.Controls.Add(Me.btnModificarObservacionesLlamada)
            Me.PanelControl3.Controls.Add(Me.btnLlamadas)
            Me.PanelControl3.Controls.Add(Me.btnSoloLlamadas)
            Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.PanelControl3.Location = New System.Drawing.Point(2, 177)
            Me.PanelControl3.Name = "PanelControl3"
            Me.PanelControl3.Size = New System.Drawing.Size(478, 33)
            Me.PanelControl3.TabIndex = 121
            '
            'btnRef
            '
            Me.btnRef.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.btnRef.Appearance.BorderColor = System.Drawing.Color.White
            Me.btnRef.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.btnRef.Appearance.Options.UseBackColor = True
            Me.btnRef.Appearance.Options.UseBorderColor = True
            Me.btnRef.Appearance.Options.UseForeColor = True
            Me.btnRef.Appearance.Options.UseTextOptions = True
            Me.btnRef.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.btnRef.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.btnRef.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
            Me.btnRef.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
            Me.btnRef.Location = New System.Drawing.Point(355, 4)
            Me.btnRef.LookAndFeel.SkinName = "Metropolis"
            Me.btnRef.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.btnRef.Name = "btnRef"
            Me.btnRef.Size = New System.Drawing.Size(110, 26)
            Me.btnRef.TabIndex = 5
            Me.btnRef.Text = "Ref. "
            Me.btnRef.Visible = False
            '
            'btnModificarObservacionesLlamada
            '
            Me.btnModificarObservacionesLlamada.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.btnModificarObservacionesLlamada.Appearance.BorderColor = System.Drawing.Color.White
            Me.btnModificarObservacionesLlamada.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.btnModificarObservacionesLlamada.Appearance.Options.UseBackColor = True
            Me.btnModificarObservacionesLlamada.Appearance.Options.UseBorderColor = True
            Me.btnModificarObservacionesLlamada.Appearance.Options.UseForeColor = True
            Me.btnModificarObservacionesLlamada.Appearance.Options.UseTextOptions = True
            Me.btnModificarObservacionesLlamada.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.btnModificarObservacionesLlamada.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.btnModificarObservacionesLlamada.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
            Me.btnModificarObservacionesLlamada.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
            Me.btnModificarObservacionesLlamada.Location = New System.Drawing.Point(94, 4)
            Me.btnModificarObservacionesLlamada.LookAndFeel.SkinName = "Metropolis"
            Me.btnModificarObservacionesLlamada.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.btnModificarObservacionesLlamada.Name = "btnModificarObservacionesLlamada"
            Me.btnModificarObservacionesLlamada.Size = New System.Drawing.Size(139, 26)
            Me.btnModificarObservacionesLlamada.TabIndex = 4
            Me.btnModificarObservacionesLlamada.Text = "Mod. Observaciones"
            '
            'btnLlamadas
            '
            Me.btnLlamadas.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.btnLlamadas.Appearance.BorderColor = System.Drawing.Color.White
            Me.btnLlamadas.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.btnLlamadas.Appearance.Options.UseBackColor = True
            Me.btnLlamadas.Appearance.Options.UseBorderColor = True
            Me.btnLlamadas.Appearance.Options.UseForeColor = True
            Me.btnLlamadas.Appearance.Options.UseTextOptions = True
            Me.btnLlamadas.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.btnLlamadas.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.btnLlamadas.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
            Me.btnLlamadas.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
            Me.btnLlamadas.Location = New System.Drawing.Point(2, 4)
            Me.btnLlamadas.LookAndFeel.SkinName = "Metropolis"
            Me.btnLlamadas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.btnLlamadas.Name = "btnLlamadas"
            Me.btnLlamadas.Size = New System.Drawing.Size(86, 26)
            Me.btnLlamadas.TabIndex = 2
            Me.btnLlamadas.Text = "Llamar"
            '
            'btnSoloLlamadas
            '
            Me.btnSoloLlamadas.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.btnSoloLlamadas.Appearance.BorderColor = System.Drawing.Color.White
            Me.btnSoloLlamadas.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.btnSoloLlamadas.Appearance.Options.UseBackColor = True
            Me.btnSoloLlamadas.Appearance.Options.UseBorderColor = True
            Me.btnSoloLlamadas.Appearance.Options.UseForeColor = True
            Me.btnSoloLlamadas.Appearance.Options.UseTextOptions = True
            Me.btnSoloLlamadas.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.btnSoloLlamadas.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.btnSoloLlamadas.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
            Me.btnSoloLlamadas.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
            Me.btnSoloLlamadas.Location = New System.Drawing.Point(239, 4)
            Me.btnSoloLlamadas.LookAndFeel.SkinName = "Metropolis"
            Me.btnSoloLlamadas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.btnSoloLlamadas.Name = "btnSoloLlamadas"
            Me.btnSoloLlamadas.Size = New System.Drawing.Size(110, 26)
            Me.btnSoloLlamadas.TabIndex = 3
            Me.btnSoloLlamadas.Text = "Ver Todo"
            '
            'PanelControl2
            '
            Me.PanelControl2.Controls.Add(Me.dgvx)
            Me.PanelControl2.Controls.Add(Me.PanelControl3)
            Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelControl2.Location = New System.Drawing.Point(3, 26)
            Me.PanelControl2.Name = "PanelControl2"
            Me.PanelControl2.Size = New System.Drawing.Size(482, 212)
            Me.PanelControl2.TabIndex = 189
            '
            'ucComunicacionesDetalle
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.Controls.Add(Me.PanelControl2)
            Me.Controls.Add(Me.PanelTitulo)
            Me.Name = "ucComunicacionesDetalle"
            Me.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
            Me.Size = New System.Drawing.Size(488, 238)
            CType(Me.dgvx, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.Gv, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelTitulo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelTitulo.ResumeLayout(False)
            Me.PanelTitulo.PerformLayout()
            CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl3.ResumeLayout(False)
            CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents dgvx As MyGridControl
        Friend WithEvents Gv As MyGridView
        Friend WithEvents RepositoryItemComboBox2 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Friend WithEvents LabelControl20 As DevExpress.XtraEditors.LabelControl
        Friend WithEvents PanelTitulo As DevExpress.XtraEditors.PanelControl
        Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
        Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
        Friend WithEvents btnSoloLlamadas As uc_tb_SimpleButton
        Friend WithEvents btnLlamadas As uc_tb_SimpleButton
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        Friend WithEvents btnModificarObservacionesLlamada As uc_tb_SimpleButton
        Friend WithEvents btnRef As uc_tb_SimpleButton

    End Class
End Namespace