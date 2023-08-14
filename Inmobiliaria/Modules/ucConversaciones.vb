Imports System
Imports System.Data.SqlClient

Public Class ucConversaciones

    Dim ContadorConsumidor As Integer
    Dim NombreConsumidor As String

    Public APPActiva As Boolean

    Private Sub ucConversaciones_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        'Dim bdAPPActiva As New BaseDatos
        'Dim Sel As String

        'Sel = "SELECT APPActiva FROM Consumidores C WHERE Contador = " & ContadorConsumidor
        'APPActiva = bdAPPActiva.Execute(Sel, False)

        If Not APPActiva Then
            lblNombre.Text = lblNombre.Text & "<color=255, 0, 0>   app inactiva</color>"
            txtMensaje.Enabled = False
        Else
            lblNombre.Text = lblNombre.Text & "<color=0, 0, 0>   app activa</color>"
        End If

        XtraScrollableControl1.VerticalScroll.Value = XtraScrollableControl1.VerticalScroll.Maximum
        txtMensaje.Focus()
    End Sub

    Public Sub LlenarMensajes(ContaConsumidor As Integer, NomConsumidor As String, APPActiva As Boolean)

        ContadorConsumidor = ContaConsumidor
        NombreConsumidor = NomConsumidor
        APPActiva = APPActiva
        lblNombre.Text = "Conversación con  <color=0,120, 255>" & NombreConsumidor & "</color>"


        For i = 0 To Me.XtraScrollableControl1.Controls.Count - 1
            Me.XtraScrollableControl1.Controls.RemoveAt(0)
        Next

        Dim Mensajes As List(Of WebServiceVenalia.clMensajes) = sw_ObtenerMensajes(ContaConsumidor)

        Dim AlturaAnterior As Integer = 0
        Dim DistanciaEntreMensajes As Integer = 20
        Dim DistanciaLateral As String = 25

        For Each Mensaje As WebServiceVenalia.clMensajes In Mensajes

            Dim Boca As New ucBocadillo3(Mensaje.Mensaje, "GRANDE", Mensaje.ContadorEmisor)
            Dim Boca2 As New ucBocadillo3(Mensaje.FechaCadena & " " & Mensaje.HoraCadena, "PEQUEÑO", Mensaje.ContadorEmisor)

            Dim Pos As New Point
            '   Dim Boca As New DevExpress.XtraEditors.LabelControl
            Dim ColorFondo As New System.Drawing.Color

            If Mensaje.ContadorEmisor <> 0 Then
                ColorFondo = Color.LightCyan

                Pos.X = 0 + DistanciaLateral
            Else
                ColorFondo = Color.Honeydew
                Pos.X = Me.XtraScrollableControl1.Width - Boca.Ancho - DistanciaLateral
            End If

            Pos.Y = AlturaAnterior + DistanciaEntreMensajes

            '  Boca.BackColor = ColorFondo
            Boca.lblTexto.BackColor = ColorFondo
            Boca.Panel1.BackColor = ColorFondo
            Boca.Panel1.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
            'Boca.Height = Boca.Alto
            Boca.Location = Pos

            Boca.lblTexto.AllowHtmlString = True


            Me.XtraScrollableControl1.Controls.Add(Boca)
            AlturaAnterior = Pos.Y + Boca.Height


            If Mensaje.ContadorEmisor <> 0 Then
                Pos.X = 0 + DistanciaLateral
            Else
                Pos.X = Me.XtraScrollableControl1.Width - Boca2.Ancho - DistanciaLateral
            End If

            Pos.Y = AlturaAnterior + 3
            '  Boca2.BackColor = ColorFondo

            Boca2.lblTexto.BackColor = Color.Transparent
            Boca2.Panel1.BackColor = Color.Transparent

            If Mensaje.ContadorEmisor <> 0 Then
                Boca2.lblTexto.ForeColor = Color.ForestGreen
            Else
                Boca2.lblTexto.ForeColor = Color.SteelBlue
            End If






            Boca2.Location = Pos
            Me.XtraScrollableControl1.Controls.Add(Boca2)
            AlturaAnterior = Pos.Y + Boca2.Height



        Next

        '  scrl.ClientSize.Height - padding.Top - padding.Bottom)
        ' XtraScrollableControl1.AutoScrollPosition = New Point(0, 0)
        XtraScrollableControl1.VerticalScroll.Value = XtraScrollableControl1.VerticalScroll.Maximum
        txtMensaje.Text = ""
        txtMensaje.Focus()

        'Dim p As New Point
        'p.X = 0
        'p.Y = XtraScrollableControl1.Height * -1
        'p.Y = p.Y * 2
        'XtraScrollableControl1.AutoScrollPosition = p


    End Sub


    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.Parent.Dispose()
    End Sub

    Private Sub btnEnviar_Click(sender As System.Object, e As System.EventArgs) Handles btnEnviar.Click

        Enviar()


    End Sub
    

    Private Sub Enviar()

      

        If Not APPActiva Then
            MsgBox("El consumidor no tiene la app activa, cerró sesión o se desinstaló la app")
            Exit Sub
        End If

        If txtMensaje.Text.Trim = "" Then
            MsgBox("No hay mensaje que enviar")
            Exit Sub
        End If

        If txtMensaje.Text.Length > 500 Then
            MsgBox("El mensaje no puede superar los 500 caracteres")
            Exit Sub
        End If

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Dim TextoHTML As String
        TextoHTML = FuncionesGenerales.Funciones.ObtenerTextoConLink(txtMensaje.Text.Trim)
         


        Dim ResulEnvio As Boolean = sw_EscribirMensajeParaAPP(0, ContadorConsumidor, TextoHTML)


        'For i =1 To 3000
        '    sw_EscribirMensajeParaAPP(0, ContadorConsumidor, i.ToString & " " & TextoHTML)
        'Next



        If ResulEnvio Then
            ResulEnvio = sw_EnviarNotificaciones(ContadorConsumidor, "Nuevo mensaje", "Inmobiliaria UIM", "Mensajes")
        End If


        'Dim bd As New BaseDatos
        'Dim Sel As String

        'Sel = "  UPDATE T1 " & _
        '    " SET T1.UsuarioContesta = '" & GL_Usuario & "', T1.FechaContestacion = " & gl_sql_getdate & "" & _
        '    " FROM MensajesAPP T1 INNER JOIN MensajesAPPPendientes T2 " & _
        '    " ON T1.Contador = T2.ContadorEnMensajes AND T1.ContadorEmisor = T2.ContadorEmisor " & _
        '    " AND T1.ContadorEmisor = " & ContadorConsumidor
        'bd.Execute(Sel)

        'Sel = "UPDATE MensajesAPPPendientes SET LeidoAinia =1 WHERE ContadorEmisor = " & ContadorConsumidor
        'bd.Execute(Sel)

        'Sel = ""& GL_SQL_DELETE &"FROM MensajesAPPPendientes WHERE ContadorEmisor = " & ContadorConsumidor & " AND LeidoAinia =1 AND LeidoMovil =1"
        'bd.Execute(Sel)


        LlenarMensajes(ContadorConsumidor, NombreConsumidor, APPActiva)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub

    

      
    'Private Sub XtraScrollableControl1_MouseEnter(sender As Object, e As System.EventArgs) Handles XtraScrollableControl1.MouseEnter
    '    ActiveControl = XtraScrollableControl1
    'End Sub

    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        Actualizar()
    End Sub

    Private Sub Actualizar()
        LlenarMensajes(ContadorConsumidor, NombreConsumidor, APPActiva)
    End Sub

    Private Sub txtMensaje_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtMensaje.KeyDown
        If e.KeyCode = Keys.F9 Then
            Enviar()
        End If
        If e.KeyCode = Keys.F5 Then
            Actualizar()
        End If
    End Sub

    'Private Sub txtMensaje_MouseEnter(sender As Object, e As System.EventArgs) Handles txtMensaje.MouseEnter
    '    ActiveControl = txtMensaje
    'End Sub

    'Private Sub txtMensaje_MouseLeave(sender As Object, e As System.EventArgs) Handles txtMensaje.MouseLeave
    '    ActiveControl = XtraScrollableControl1
    'End Sub

   
End Class
