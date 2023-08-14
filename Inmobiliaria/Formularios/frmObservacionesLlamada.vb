Imports DevExpress.XtraGrid

Public Class frmObservacionesLlamada


    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click

        UcCambioPrecio1.ConfirmarPrecios()
        If txtTexto.Text.Trim = "" Then
            GL_Observaciones = Gl_ResultadoBusqueda_SALIR
        Else
            GL_Observaciones = txtTexto.Text.Trim
        End If

        GL_RespondioALaLlamada = True

        Try


            ActualizaCampos("FechaLlamada")


        Catch ex As Exception

        End Try
        Me.Dispose()
    End Sub
    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        GL_Observaciones = GL_ResultadoBusqueda_CANCELAR
        Me.Dispose()
    End Sub

    Private Sub ActualizaCampos(Campo As String)

        Dim Sel As String

        Select Case GL_PANTALLA_QUE_LANZA_LLAMADA.ToUpper

            Case GL_Clientes.ToUpper
                Try
                    If GL_Observaciones <> Gl_ResultadoBusqueda_SALIR Then
                        BD_CERO.Execute("UPDATE Clientes SET " & Campo & " = " & GL_SQL_GETDATE & " WHERE Contador=" & UClienteActivo.BinSrc.Current("Contador"))
                        RefrescarDatosDesdeBdClientes(True)
                    End If
                Catch ex As Exception

                End Try

            Case GL_TablaInmuebles.ToUpper
                Try
                    If GL_Observaciones <> Gl_ResultadoBusqueda_SALIR Then
                        Sel = "UPDATE Propietarios SET " & Campo & "= " & GL_SQL_GETDATE & " WHERE Contador=" & uInmueblesActivo.BinSrc.Current("ContadorPropietario")
                        BD_CERO.Execute(Sel)
                    End If

                    If GL_RespondioALaLlamada Then
                        BD_CERO.Execute("UPDATE Inmuebles SET FechaUltimaLlamadaPropietario = " & GL_SQL_GETDATE & " WHERE Contador=" & uInmueblesActivo.BinSrc.Current("Contador"))
                        RefrescarDatosDesdeBdInmuebles(True)
                    End If
                Catch ex As Exception

                End Try

                    PonerPendienteRefrescarPropietarios()

                PonerPendienteRefrescarAlarmas()

            Case "Alarmas".ToUpper

                Try
                    BD_CERO.Execute("UPDATE Propietarios SET " & Campo & "= " & GL_SQL_GETDATE & " WHERE Contador=" & uAlarmasActivo.BinSrc.Current("ContadorPropietario"))

                Catch ex As Exception

                End Try



            Case GL_TablaPropietarios.ToUpper
                Try
                    Sel = "UPDATE Propietarios SET " & Campo & "= " & GL_SQL_GETDATE & " WHERE Contador=" & uPropietariosActivo.BinSrc.Current("Contador")
                    BD_CERO.Execute(Sel)

                    PonerPendienteRefrescarAlarmas()

                Catch ex As Exception

                End Try



        End Select






        'If ClientesEstaActivo Then

        '    Try
        '        If GL_Observaciones <> Gl_ResultadoBusqueda_SALIR Then
        '            BD_CERO.Execute("UPDATE Clientes SET " & Campo & " = " & GL_SQL_GETDATE & " WHERE Contador=" & UClienteActivo.BinSrc.Current("Contador"))
        '            RefrescarDatosDesdeBdClientes(True)
        '        End If
        '    Catch ex As Exception

        '    End Try


        'End If

        'If InmueblesEstaActivo Then

        '    Try
        '        If GL_Observaciones <> Gl_ResultadoBusqueda_SALIR Then
        '            Sel = "UPDATE Propietarios SET " & Campo & "= " & GL_SQL_GETDATE & " WHERE Contador=" & uInmueblesActivo.BinSrc.Current("ContadorPropietario")
        '            BD_CERO.Execute(Sel)
        '        End If

        '        If GL_RespondioALaLlamada Then
        '            BD_CERO.Execute("UPDATE Inmuebles SET FechaUltimaLlamadaPropietario = " & GL_SQL_GETDATE & " WHERE Contador=" & uInmueblesActivo.BinSrc.Current("Contador"))
        '            RefrescarDatosDesdeBdInmuebles(True)
        '        End If
        '    Catch ex As Exception

        '    End Try



        'End If

        'If Not IsNothing(uPropietariosActivo) Then

        '    Try
        '        Sel = "UPDATE Propietarios SET " & Campo & "= " & GL_SQL_GETDATE & " WHERE Contador=" & uPropietariosActivo.BinSrc.Current("Contador")
        '        BD_CERO.Execute(Sel)
        '        PonerPendienteRefrescarPropietarios()
        '    Catch ex As Exception

        '    End Try

        'End If

        'If AlarmasEstaActivo Then

        '    Try
        '        BD_CERO.Execute("UPDATE Propietarios SET " & Campo & "= " & GL_SQL_GETDATE & " WHERE Contador=" & uAlarmasActivo.BinSrc.Current("ContadorPropietario"))
        '        PonerPendienteRefrescarAlarmas()
        '    Catch ex As Exception

        '    End Try

        'End If
    End Sub
    Private Sub frmObservacionesLlamada_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btnNoContesta.ForeColor = GL_ColorTextoBotones

        Dim SoyDeEstos As Boolean = False

        Select Case GL_PANTALLA_QUE_LANZA_LLAMADA.ToUpper

            Case GL_TablaInmuebles.ToUpper
                If Not IsNothing(uInmueblesActivo) Then
                    If uInmueblesActivo.UcInmueblesPropietario1.Gv.RowCount = 0 OrElse uInmueblesActivo.UcInmueblesPropietario1.Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then Return
                    UcCambioPrecio1.ContadorInmueble = uInmueblesActivo.UcInmueblesPropietario1.BinSrc.Current("Contador")
                    Me.Text = "Observaciones y precios de: " & uInmueblesActivo.UcInmueblesPropietario1.BinSrc.Current("Referencia")
                    SoyDeEstos = True
                End If

            Case "Alarmas".ToUpper

                If Not IsNothing(uAlarmasActivo) Then
                    If uAlarmasActivo.Gv.RowCount = 0 OrElse uAlarmasActivo.Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then Return
                    UcCambioPrecio1.ContadorInmueble = uAlarmasActivo.BinSrc.Current("Contador")
                    Me.Text = "Observaciones y precios de: " & uAlarmasActivo.BinSrc.Current("Referencia")
                    SoyDeEstos = True
                End If



            Case GL_TablaPropietarios.ToUpper
                If Not IsNothing(uPropietariosActivo) Then
                    If uPropietariosActivo.GvInmuebles.RowCount = 0 OrElse uPropietariosActivo.GvInmuebles.FocusedRowHandle = GridControl.AutoFilterRowHandle Then Return
                    UcCambioPrecio1.ContadorInmueble = uPropietariosActivo.GvInmuebles.GetFocusedDataRow("Contador")
                    Me.Text = "Observaciones y precios de: " & uPropietariosActivo.GvInmuebles.GetFocusedDataRow("Referencia")
                    SoyDeEstos = True
                End If



        End Select

        If SoyDeEstos Then
            UcCambioPrecio1.CargarValores()
            UcCambioPrecio1.Visible = True
            UcCambioPrecio1.btnAceptar.Visible = False
            UcCambioPrecio1.btnSalir.Visible = False
            txtTexto.Dock = DockStyle.Bottom

        Else
            UcCambioPrecio1.Visible = False
            txtTexto.Dock = DockStyle.Fill
        End If
       
        'If InmueblesEstaActivo Or AlarmasEstaActivo Or PropietariosEstaActivo Then
        '    If InmueblesEstaActivo Then
        '        UcCambioPrecio1.ContadorInmueble = uInmueblesActivo.UcInmueblesPropietario1.BinSrc.Current("Contador")
        '        Me.Text = "Observaciones y precios de: " & uInmueblesActivo.UcInmueblesPropietario1.BinSrc.Current("Referencia")
        '    Else
        '        If PropietariosEstaActivo Then
        '            UcCambioPrecio1.ContadorInmueble = uPropietariosActivo.GvInmuebles.GetFocusedDataRow("Contador")
        '            Me.Text = "Observaciones y precios de: " & uPropietariosActivo.GvInmuebles.GetFocusedDataRow("Referencia")
        '        Else
        '            UcCambioPrecio1.ContadorInmueble = uAlarmasActivo.BinSrc.Current("Contador")
        '            Me.Text = "Observaciones y precios de: " & uAlarmasActivo.BinSrc.Current("Referencia")
        '        End If

        '    End If

        '    UcCambioPrecio1.CargarValores()
        '    UcCambioPrecio1.Visible = True
        '    UcCambioPrecio1.btnAceptar.Visible = False
        '    UcCambioPrecio1.btnSalir.Visible = False
        '    txtTexto.Dock = DockStyle.Bottom

        'Else
        '    UcCambioPrecio1.Visible = False
        '    txtTexto.Dock = DockStyle.Fill
        'End If

        GL_CambiosPrecios = New Tablas.clCambiosPrecios

        GL_CambiosPrecios.HayCambios = False
    End Sub

    Private Sub btnNoContesta_Click(sender As System.Object, e As System.EventArgs) Handles btnNoContesta.Click
        Contesta()
    End Sub

    'Private Sub btnModificaUltimaLlamada_Click(sender As System.Object, e As System.EventArgs) Handles btnModificaUltimaLlamada.Click

    '    Contesta()
    'End Sub

    Private Sub Contesta()
        UcCambioPrecio1.ConfirmarPrecios()
        GL_RespondioALaLlamada = False
        If txtTexto.Text.Trim = "" Then
            GL_Observaciones = Gl_ResultadoBusqueda_SALIR
        Else
            GL_Observaciones = txtTexto.Text.Trim
        End If

        ActualizaCampos("FechaNoContesta")

        Me.Dispose()
    End Sub

    Private Sub frmObservacionesLlamada_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        txtTexto.Focus()
    End Sub
End Class