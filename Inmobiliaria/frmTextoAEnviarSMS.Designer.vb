<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTextoAEnviarSMS
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
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.TxtContadorConsumidores = New System.Windows.Forms.TextBox()
        Me.TxtContador = New System.Windows.Forms.TextBox()
        Me.lblDato = New System.Windows.Forms.Label()
        Me.lblCaracteres = New System.Windows.Forms.Label()
        Me.TxtDato = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSalir.Location = New System.Drawing.Point(232, 246)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(90, 57)
        Me.btnSalir.TabIndex = 5
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnAceptar.ImageKey = "(ninguno)"
        Me.btnAceptar.Location = New System.Drawing.Point(136, 246)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(90, 57)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'TxtContadorConsumidores
        '
        Me.TxtContadorConsumidores.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TxtContadorConsumidores.Location = New System.Drawing.Point(41, 94)
        Me.TxtContadorConsumidores.MaxLength = 0
        Me.TxtContadorConsumidores.Name = "TxtContadorConsumidores"
        Me.TxtContadorConsumidores.Size = New System.Drawing.Size(44, 26)
        Me.TxtContadorConsumidores.TabIndex = 10
        Me.TxtContadorConsumidores.Text = "0"
        Me.TxtContadorConsumidores.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtContadorConsumidores.Visible = False
        '
        'TxtContador
        '
        Me.TxtContador.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TxtContador.Location = New System.Drawing.Point(29, 103)
        Me.TxtContador.MaxLength = 0
        Me.TxtContador.Name = "TxtContador"
        Me.TxtContador.Size = New System.Drawing.Size(40, 26)
        Me.TxtContador.TabIndex = 12
        Me.TxtContador.Text = "0"
        Me.TxtContador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtContador.Visible = False
        '
        'lblDato
        '
        Me.lblDato.AutoSize = True
        Me.lblDato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDato.Location = New System.Drawing.Point(6, 19)
        Me.lblDato.Name = "lblDato"
        Me.lblDato.Size = New System.Drawing.Size(141, 16)
        Me.lblDato.TabIndex = 16
        Me.lblDato.Text = "Escriba el mensaje"
        '
        'lblCaracteres
        '
        Me.lblCaracteres.AutoSize = True
        Me.lblCaracteres.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaracteres.ForeColor = System.Drawing.Color.DarkRed
        Me.lblCaracteres.Location = New System.Drawing.Point(276, 19)
        Me.lblCaracteres.Name = "lblCaracteres"
        Me.lblCaracteres.Size = New System.Drawing.Size(96, 16)
        Me.lblCaracteres.TabIndex = 17
        Me.lblCaracteres.Text = "0 Caracteres"
        '
        'TxtDato
        '
        Me.TxtDato.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDato.Location = New System.Drawing.Point(9, 38)
        Me.TxtDato.MaxLength = 500
        Me.TxtDato.Multiline = True
        Me.TxtDato.Name = "TxtDato"
        Me.TxtDato.Size = New System.Drawing.Size(363, 169)
        Me.TxtDato.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(6, 210)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(351, 15)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Todos los enlaces deben empezar por http:// o https://"
        '
        'frmTextoAEnviarSMS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(375, 309)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtDato)
        Me.Controls.Add(Me.lblCaracteres)
        Me.Controls.Add(Me.lblDato)
        Me.Controls.Add(Me.TxtContador)
        Me.Controls.Add(Me.TxtContadorConsumidores)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnAceptar)
        Me.Name = "frmTextoAEnviarSMS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents TxtContadorConsumidores As TextBox
    Friend WithEvents TxtContador As TextBox
    Friend WithEvents lblDato As System.Windows.Forms.Label
    Friend WithEvents lblCaracteres As System.Windows.Forms.Label
    Friend WithEvents TxtDato As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
