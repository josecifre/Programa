<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmObtenerFotos
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
        Me.btnSalir = New uc_tb_SimpleButton()
        Me.btnCopiarFotos = New uc_tb_SimpleButton()
        Me.btnObtenerFotos = New uc_tb_SimpleButton()
        Me.btnActualizarBD = New uc_tb_SimpleButton()
        Me.btnCarpetaOrigen = New uc_tb_SimpleButton()
        Me.btnNum = New uc_tb_SimpleButton()
        Me.SuspendLayout()
        '
        'btnSalir
        '
        Me.btnSalir.Appearance.Options.UseBackColor = True
        Me.btnSalir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnSalir.Image = Global.My.Resources.Resources.desconexion_de_salida_icono_7025_641
        Me.btnSalir.Location = New System.Drawing.Point(11, 132)
        Me.btnSalir.LookAndFeel.SkinName = "Metropolis"
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(137, 61)
        Me.btnSalir.TabIndex = 6
        Me.btnSalir.Text = "Salir"
        '
        'btnCopiarFotos
        '
        Me.btnCopiarFotos.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnCopiarFotos.Appearance.Options.UseBackColor = True
        Me.btnCopiarFotos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCopiarFotos.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnCopiarFotos.Enabled = False
        Me.btnCopiarFotos.Location = New System.Drawing.Point(11, 42)
        Me.btnCopiarFotos.LookAndFeel.SkinName = "Metropolis"
        Me.btnCopiarFotos.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCopiarFotos.Name = "btnCopiarFotos"
        Me.btnCopiarFotos.Size = New System.Drawing.Size(137, 26)
        Me.btnCopiarFotos.TabIndex = 7
        Me.btnCopiarFotos.Text = "Copiar Fotos del Pc"
        Me.btnCopiarFotos.ToolTip = "Copia las carpetas y fotos de la carpeta origen a la del programa actual"
        '
        'btnObtenerFotos
        '
        Me.btnObtenerFotos.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnObtenerFotos.Appearance.Options.UseBackColor = True
        Me.btnObtenerFotos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnObtenerFotos.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnObtenerFotos.Location = New System.Drawing.Point(11, 72)
        Me.btnObtenerFotos.LookAndFeel.SkinName = "Metropolis"
        Me.btnObtenerFotos.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnObtenerFotos.Name = "btnObtenerFotos"
        Me.btnObtenerFotos.Size = New System.Drawing.Size(137, 26)
        Me.btnObtenerFotos.TabIndex = 8
        Me.btnObtenerFotos.Text = "Obtener Fotos de la Web"
        Me.btnObtenerFotos.ToolTip = "Descarga las fotos de la web a sus correspondientes carpetas web en el pc actuali" & _
            "zando asi el estado de estas"
        '
        'btnActualizarBD
        '
        Me.btnActualizarBD.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnActualizarBD.Appearance.Options.UseBackColor = True
        Me.btnActualizarBD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnActualizarBD.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnActualizarBD.Location = New System.Drawing.Point(11, 102)
        Me.btnActualizarBD.LookAndFeel.SkinName = "Metropolis"
        Me.btnActualizarBD.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnActualizarBD.Name = "btnActualizarBD"
        Me.btnActualizarBD.Size = New System.Drawing.Size(137, 26)
        Me.btnActualizarBD.TabIndex = 9
        Me.btnActualizarBD.Text = "Actualizar BD Inmuebles"
        Me.btnActualizarBD.ToolTip = "Actualiza los contadores de fotos de la base de datos con el numero de ficheros a" & _
            "ctuales"
        '
        'btnCarpetaOrigen
        '
        Me.btnCarpetaOrigen.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnCarpetaOrigen.Appearance.Options.UseBackColor = True
        Me.btnCarpetaOrigen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCarpetaOrigen.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnCarpetaOrigen.Location = New System.Drawing.Point(11, 12)
        Me.btnCarpetaOrigen.LookAndFeel.SkinName = "Metropolis"
        Me.btnCarpetaOrigen.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCarpetaOrigen.Name = "btnCarpetaOrigen"
        Me.btnCarpetaOrigen.Size = New System.Drawing.Size(137, 26)
        Me.btnCarpetaOrigen.TabIndex = 10
        Me.btnCarpetaOrigen.Text = "Elegir Carpeta Origen"
        Me.btnCarpetaOrigen.ToolTip = "Elegir la carpeta de donde se copiaran las fotos de los inmuebles"
        '
        'btnNum
        '
        Me.btnNum.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.btnNum.Appearance.Font = New System.Drawing.Font("Tahoma", 20.25!)
        Me.btnNum.Appearance.Options.UseBackColor = True
        Me.btnNum.Appearance.Options.UseFont = True
        Me.btnNum.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.btnNum.Location = New System.Drawing.Point(11, 72)
        Me.btnNum.LookAndFeel.SkinName = "Metropolis"
        Me.btnNum.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnNum.Name = "btnNum"
        Me.btnNum.Size = New System.Drawing.Size(137, 56)
        Me.btnNum.TabIndex = 11
        Me.btnNum.Text = "0 %"
        Me.btnNum.Visible = False
        '
        'frmObtenerFotos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(160, 201)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnNum)
        Me.Controls.Add(Me.btnCarpetaOrigen)
        Me.Controls.Add(Me.btnActualizarBD)
        Me.Controls.Add(Me.btnObtenerFotos)
        Me.Controls.Add(Me.btnCopiarFotos)
        Me.Controls.Add(Me.btnSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmObtenerFotos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento de fotos"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSalir As uc_tb_SimpleButton
    Friend WithEvents btnCopiarFotos As uc_tb_SimpleButton
    Friend WithEvents btnObtenerFotos As uc_tb_SimpleButton
    Friend WithEvents btnActualizarBD As uc_tb_SimpleButton
    Friend WithEvents btnCarpetaOrigen As uc_tb_SimpleButton
    Friend WithEvents btnNum As uc_tb_SimpleButton
End Class
