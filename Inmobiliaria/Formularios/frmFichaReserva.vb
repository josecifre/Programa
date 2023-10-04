Public Class frmFichaReserva

    Dim bd As BaseDatos
    
    Dim Cargando As Boolean = True

    Private p_ContadorInmueble As String

    Public Property ContadorInmueble As Integer
        Get
            Return p_ContadorInmueble
        End Get
        Set(value As Integer)
            p_ContadorInmueble = value
        End Set
    End Property

    Dim ReservadoAlEntrar As Boolean

    Private Sub frmFichaReserva_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        AparienciaGeneral()
        bd = New BaseDatos
        Dim sel As String
        'sel = "SELECT * FROM Reservas WHERE ContadorInmueble=" & ContadorInmueble
        'bd.LlenarDataSet(sel, "Reservas")
        sel = "SELECT  Reservado,FechaReservado FROM Inmuebles WHERE Contador=" & ContadorInmueble
        bd.LlenarDataSet(sel, "Inmuebles")
        sel = "SELECT Contador,Nombre FROM Clientes WHERE CodigoEmpresa=" & DatosEmpresa.Codigo & " ORDER BY Nombre"
        bd.LlenarDataSet(sel, "Clientes")
        'If bd.ds.Tables("Reservas").Rows.Count > 0 Then
        '    With bd.ds.Tables("Reservas").Rows(0)
        '        txtCodigo.EditValue = .Item("ContadorCliente")
        '        txtObservaciones.EditValue = .Item("Observaciones")
        '    End With
        'End If
        With bd.ds.Tables("Inmuebles").Rows(0)
            
            ' chkReservado.Enabled = .Item("Venta")
            If .Item("Reservado") Then
                mskFechaVencimiento.EditValue = .Item("FechaReservado")
                chkReservado.Checked = .Item("Reservado")
                ReservadoAlEntrar = True
            Else
                ReservadoAlEntrar = False
            End If
        End With
        cmbClientes.Properties.DataSource = bd.ds.Tables("Clientes")
        cmbClientes.Properties.ValueMember = bd.ds.Tables("Clientes").Columns(0).ToString
        cmbClientes.Properties.DisplayMember = bd.ds.Tables("Clientes").Columns(1).ToString
        'If bd.ds.Tables("Reservas").Rows.Count > 0 Then
        '    cmbClientes.EditValue = bd.ds.Tables("Reservas").Rows(0).Item("ContadorCliente")
        'Else
        If chkReservado.Checked Then
            Try
                cmbClientes.EditValue = BD_CERO.Execute(GL_SQL_TOP1_FRONT & " ContadorCliente FROM ReservasRegistro WHERE ContadorInmueble=" & ContadorInmueble & " ORDER BY FECHA DESC " & GL_SQL_TOP1_BACK, False)
                txtObservaciones.EditValue = BD_CERO.Execute(GL_SQL_TOP1_FRONT & " Observacion FROM ReservasRegistro WHERE ContadorInmueble=" & ContadorInmueble & " ORDER BY FECHA DESC " & GL_SQL_TOP1_BACK, False)
            Catch ex As Exception
                cmbClientes.EditValue = 1
            End Try
        Else
            cmbClientes.EditValue = 1
        End If
       
       
        'End If
        Cargando = False
        cmbClientes.Focus()

        mskFechaVencimiento.Enabled = chkReservado.Checked

        GL_InmuebleReservado = ""
    End Sub

#Region "Mantenimiento Reservas"
    Private Sub cmbClientes_QueryPopUp(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles cmbClientes.QueryPopUp
        cmbClientes.Properties.View.Columns("Contador").Visible = False
    End Sub
    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        If Aceptar() Then
            Me.Cursor = System.Windows.Forms.Cursors.Arrow

            If Not chkReservado.Checked AndAlso ReservadoAlEntrar Then
                bd.Execute("UPDATE Inmuebles SET FechaQuitaReservado = " & gl_sql_getdate & ", FechaUltimoCambio =" & gl_sql_getdate & " WHERE Contador = " & ContadorInmueble)
            End If

            RefrescarDatosDesdeBdInmuebles(True)
            PonerPendienteRefrescarAlarmas()
            Salir()
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub
    Private Function Aceptar() As Boolean
        If Not ComprobarDatos() Then
            Return False
        End If
        Try
            Me.Validate() '????
            If Not ActualizarBaseDatos() Then
                Return False
            End If
            Return True
        Catch ex As SqlClient.SqlException
            MensajeError(ex.Message)
            Return False
        Catch ex2 As Exception
            MensajeError(ex2.Message)
            Return False
        End Try
    End Function
    Private Function ActualizarBaseDatos() As Boolean
        Try


            Dim Sel As String
            Sel = "DELETE FROM ReservasRegistro WHERE ContadorInmueble=" & ContadorInmueble
            BD_CERO.Execute(Sel)

            If chkReservado.Checked Then
                'If txtCodigo.EditValue Is Nothing Then
                '    bd.Execute("INSERT INTO Reservas VALUES (" & ContadorInmueble & "," & cmbClientes.EditValue & ",'" & txtObservaciones.EditValue & _
                '               "','" & Today & "'," & GL_CodigoUsuario & ")")
                bd.Execute("INSERT INTO ReservasRegistro (TIPO,FECHA,CONTADORINMUEBLE,CONTADOREMPLEADO,ContadorCliente,Observacion) VALUES ('NUEVO'," & GL_SQL_GETDATE & "," & ContadorInmueble & "," & GL_CodigoUsuario & "," & cmbClientes.EditValue & ",'" & txtObservaciones.EditValue & "')")
                'Else
                '    bd.Execute("UPDATE Reservas SET ContadorCliente=" & cmbClientes.EditValue & ",Observaciones='" & txtObservaciones.EditValue & _
                '               "',Fecha='" & Today & "',ContadorEmpleado=" & GL_CodigoUsuario & " WHERE ContadorInmueble=" & ContadorInmueble)
                '    bd.Execute("INSERT INTO ReservasRegistro VALUES ('MODIFICADO','" & Today & "'," & ContadorInmueble & "," & GL_CodigoUsuario & ")")
                'End If

                Dim FVen As String
                If mskFechaVencimiento.EditValue Is Nothing Then
                    FVen = "NULL"
                Else
                    FVen = "'" & Microsoft.VisualBasic.Format(mskFechaVencimiento.EditValue, "yyyyMMdd") & "'"
                End If

                'Dim BorrarFotosTodoOK As Boolean = True

                'JCB CARPETA FOTOS
                ' Dim a As String = bd.Execute("SELECT c onvert(varchar,ContadorPropietario) " & GL_SQL_SUMA & "'-'" & GL_SQL_SUMA & " c onvert(varchar,Referencia) FROM Inmuebles WHERE Contador=" & ContadorInmueble, False)
                'Dim CarpetaDocumentoPublicadas As String = GL_CarpetaFotos & "\" & a & "\actualizarweb"

                'quitar imagenes de la web
                'Dim ftp As New tb_FTP
                'Dim Http = "httpdocs/roberto" 'carpeta de la web
                'ftp.FTPBorrarFicherosCarpeta(Http, "jpg")
                'quitar imagenes de la carpeta publicados
                'Try
                '    If System.IO.Directory.Exists(CarpetaDocumentoPublicadas) Then
                '        System.IO.Directory.Delete(CarpetaDocumentoPublicadas, True)
                '    End If
                'Catch
                '    BorrarFotosTodoOK = False
                '    MensajeError("Error al borrar fotos publicadas")

                'End Try

                '       IIf(BorrarFotosTodoOK, " FotosWeb = 0", "") & _
                bd.Execute("UPDATE Inmuebles SET Reservado =" & FuncionesGenerales.Funciones.pf_ReplaceTrueFalse(chkReservado.Checked) & "," & _
                       "FechaReservado=" & FVen & _
                       " WHERE Contador=" & ContadorInmueble)
                GL_InmuebleReservado = "SI"
                FuncionesBD.Accion("UPDATE", "Inmuebles", BD_CERO.Execute("SELECT Referencia FROM Inmuebles WHERE CONTADOR=" & ContadorInmueble, False), False, Reserva:=True, Valor:=1)


            Else
                'BD_CERO.Execute("INSERT INTO InmueblesReservasQuitadas (ContadorInmueble,Fecha,ContadorEmpleado) SELECT ContadorInmueble," & gl_sql_getdate & ",ContadorEmpleado FROM Reservas WHERE ContadorInmueble=" & ContadorInmueble)
                'bd.Execute("" & GL_SQL_DELETE & "FROM Reservas WHERE ContadorInmueble =" & ContadorInmueble)
                bd.Execute("UPDATE Inmuebles SET Reservado =0 ,FechaReservado =NULL WHERE Contador=" & ContadorInmueble)
                FuncionesBD.Accion("UPDATE", "Inmuebles", BD_CERO.Execute("SELECT Referencia FROM Inmuebles WHERE CONTADOR=" & ContadorInmueble, False), False, Reserva:=True, Valor:=0)

                GL_InmuebleReservado = "NO"
                'BD_CERO.Execute("" & GL_SQL_DELETE & "FROM NuevasReservasQuitadas WHERE ContadorInmueble = " & ContadorInmueble)
                'BD_CERO.Execute("INSERT INTO NuevasReservasQuitadas VALUES ( " & ContadorInmueble & " , " & gl_sql_getdate & ")")
                'bd.Execute("INSERT INTO ReservasRegistro VALUES ('BORRADO','" & Today & "'," & ContadorInmueble & "," & GL_CodigoUsuario & ")")
            End If

            '   RefrescarDatosDesdeBdInmuebles(True)
            'PonerPendienteRefrescarAlarmas()


            Return True
        Catch ex As SqlClient.SqlException
            If ex.Number = 2627 Then
                MensajeError(GL_ValorDuplicado)
            Else
                MensajeError(ex.Message)
            End If
            Return False
        End Try
    End Function


    Private Function ComprobarDatos() As Boolean

        If chkReservado.Checked Then
            If IsNothing(mskFechaVencimiento.EditValue) OrElse IsDBNull(mskFechaVencimiento.EditValue) Then
                MensajeInformacion("El campo fecha es obligatorio")
                Return False
            End If

            If IsNothing(cmbClientes.EditValue) OrElse IsDBNull(cmbClientes.EditValue) Then
                MensajeInformacion("El campo cliente es obligatorio")
                Return False
            End If

        End If

        If Not chkReservado.Checked Then mskFechaVencimiento.EditValue = Nothing
        Return True
    End Function

    Private Sub dgvxClientes_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Try
                Salir()
            Catch ex As Exception
            End Try
        End If
    End Sub

#End Region

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        GL_InmuebleReservado = ""
        Salir()
    End Sub
    Private Sub Salir()
        Me.Dispose()
    End Sub


    Private Sub chkReservado_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkReservado.CheckedChanged
        mskFechaVencimiento.Enabled = chkReservado.Checked
        If mskFechaVencimiento.Enabled = False Then mskFechaVencimiento.Text = ""
    End Sub

   
End Class







