Public Class frmConfiguracionEmpresa 

    

    Dim Eliminando As Boolean = False
 
    Dim EstoyEnAlta As Boolean

    Dim bd As BaseDatos
    Private WithEvents BinSrc As BindingSource
    Dim TablaMantenimiento As String = "Empresas"
    Dim Cargando As Boolean = True
    Dim PrimeraVez As Boolean
    Dim fotoactiva As Boolean
    Dim ruta As String = clVariables.RutaServidor & "\Logos\Logo\" & DatosEmpresa.Codigo
    Dim rutatmp As String = clVariables.RutaServidor & "\Logos\Logo\tmp\" & DatosEmpresa.Codigo

 
     
    Private Sub ucConfiguracionEmpresas_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        FuncionesGenerales.Funciones.ComprobarYCrearCarpetas(ruta)

        AparienciaGeneral()
        MostrarImagenDeFondo()

        If DatosEmpresa.Codigo = 2 Then
            btnEnviarEmailTrasteros.Visible = True
        End If

        Dim Tab As New Tablas.clTablaGeneral(TablaMantenimiento, " WHERE Codigo = " & DatosEmpresa.Codigo)
        bd = New BaseDatos
        Tab.Datos(bd, Tab.ConsultaAEjecutar, , , , , True)


        BinSrc = New BindingSource

        '   
        BinSrc.DataSource = bd.ds
        BinSrc.DataMember = TablaMantenimiento

        'Bindings


        txtCodigo.DataBindings.Add(New Binding("EditValue", BinSrc, "Codigo", True))
        txtCodPostal.DataBindings.Add(New Binding("EditValue", BinSrc, "CodPostal", True))
        txtDireccion.DataBindings.Add(New Binding("EditValue", BinSrc, "Direccion", True))
        txtEmail.DataBindings.Add(New Binding("EditValue", BinSrc, "Email", True))

        txtFax.DataBindings.Add(New Binding("EditValue", BinSrc, "Fax", True))
        txtNIF.DataBindings.Add(New Binding("EditValue", BinSrc, "NIF", True))
        txtNombre.DataBindings.Add(New Binding("EditValue", BinSrc, "Nombre", True))
        txtNombreComercial.DataBindings.Add(New Binding("EditValue", BinSrc, "NombreComercial", True))
        txtObservaciones.DataBindings.Add(New Binding("EditValue", BinSrc, "Observaciones", True))
        txtPais.DataBindings.Add(New Binding("EditValue", BinSrc, "Pais", True))
        txtPoblacion.DataBindings.Add(New Binding("EditValue", BinSrc, "Poblacion", True))
        txtProvincia.DataBindings.Add(New Binding("EditValue", BinSrc, "Provincia", True))
        txtTelefono1.DataBindings.Add(New Binding("EditValue", BinSrc, "Telefono1", True))
        txtTelefono2.DataBindings.Add(New Binding("EditValue", BinSrc, "Telefono2", True))
        txtTelefonoMovil.DataBindings.Add(New Binding("EditValue", BinSrc, "TelefonoMovil", True))
        txtWeb.DataBindings.Add(New Binding("EditValue", BinSrc, "Web", True))

        txtAvisoLegal.DataBindings.Add(New Binding("EditValue", BinSrc, "AvisoLegal", True))

        Try
            Dim ExtensionLogo As String = ObtenerExtensionLogo()
            cargaLogo(ruta, ExtensionLogo)
        Catch
        End Try

        Cargando = False

        HabilitarBotones()
        HabilitarDesHabilitarCajas(False)

        fotoactiva = False
        imgLogo.Enabled = True




    End Sub

     


#Region "Mantenimiento Clientes"

    Private Sub btnAnadir_Click(sender As System.Object, e As System.EventArgs) Handles btnAnadir.Click
        Anadir()
    End Sub


    Private Sub btnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        Modificar()
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
         
        Aceptar()
         
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub

    Private Sub Anadir()
        EstoyEnAlta = True
        BinSrc.AddNew()
        PrepararAlta()
    End Sub

    Private Sub Modificar(Optional PonermeEnLaPrimeraColumna As Boolean = True)


        EstoyEnAlta = False
        PrepararModificacion()
    End Sub

    Private Sub Aceptar()
        '  Dim FilaSeleccionada As Integer = GvClientes.FocusedRowHandle

        Actualizar()

        'If Not EstoyEnAlta AndAlso txtCodigo.EditValue = DatosEmpresa.Codigo Then
        '    DatosEmpresa.Nombre = txtNombre.EditValue
        'End If
        Try
            Dim ExtensionLogo As String = ObtenerExtensionLogo()
            borraLogo(ruta)
            copiaLogo(rutatmp, ruta, ExtensionLogo)
            cargaLogo(ruta, ExtensionLogo)
        Catch ex As Exception

        End Try
        'GvClientes.FocusedRowHandle = FilaSeleccionada
    End Sub
    Private Sub Cancelar()

        BinSrc.CancelEdit()
        HabilitarBotones()
        HabilitarDesHabilitarCajas(False)
        Try
            Dim ExtensionLogo As String = ObtenerExtensionLogo()
            cargaLogo(ruta, ExtensionLogo)
        Catch

        End Try

    End Sub
    Private Sub PrepararModificacion()

        HabilitarDesHabilitarCajas(True)


        DesHabilitarBotones()
        txtCodigo.Enabled = False

        txtNombre.Focus()
    End Sub

    Private Sub PrepararAlta()

        HabilitarDesHabilitarCajas(True)


        txtCodigo.Text = ""
        txtCodigo.Enabled = False
        '     chkBaja.Enabled = False

        txtNombreComercial.EditValue = ""




        txtNombre.Focus()



        'LookUpEditIVA.Properties.NullValuePrompt = LookUpEditIVA.Properties.GetDisplayValueByKeyValue(DatosEmpresa.IVAPrederminado).ToString


        DesHabilitarBotones()
        txtNombre.Focus()
    End Sub
    Private Sub HabilitarDesHabilitarCajas(ByVal Habilitar As Boolean)

        For Each c As Control In PanelCajas.Controls
            If Not TypeOf (c) Is DevExpress.XtraEditors.LabelControl AndAlso Not TypeOf (c) Is DevExpress.XtraEditors.PanelControl AndAlso Not TypeOf (c) Is DevExpress.XtraEditors.GroupControl Then
                c.Enabled = Habilitar
            End If
        Next
        imgLogo.Enabled = True
    End Sub

    Private Function Actualizar() As Boolean
        Try

            Me.Validate()

            If Not ComprobarDatos() Then
                Return False
            End If

            If EstoyEnAlta Then
                BinSrc.Current("FechaAlta") = Microsoft.VisualBasic.Today
                BinSrc.Current("Agrupacion") = ""
                txtCodigo.EditValue = clGenerales.SiguienteRegistro("Codigo", "Empresas")
            Else
                'If Not Eliminando Then
                '    If Gv.GetFocusedRowCellValue("FuturoCliente") = True And BinSrc.Current("FuturoCliente") = 0 Then
                '        MsgBox("")
                '    End If
                'End If

            End If


            'If BinSrc.Item(BinSrc.Count - 1)("Observaciones") Is DBNull.Value Then
            '    BinSrc.Item(BinSrc.Count - 1)("Observaciones") = ""
            'End If

            BinSrc.EndEdit()

            If Not EstoyEnAlta Then
                DatosEmpresa.Nombre = txtNombre.EditValue
            End If

            If Not ActualizarBaseDatos() Then
                Return False
            End If

            HabilitarBotones()
            HabilitarDesHabilitarCajas(False)
            Return True

        Catch ex As SqlClient.SqlException

            MensajeError(ex.Message)
            'DsClientes.RejectChanges()
            'DsClientes.AcceptChanges()

            Return False

        Catch ex2 As Exception

            MensajeError(ex2.Message)
            'DsClientes.RejectChanges()
            'DsClientes.AcceptChanges()
            Return False

        End Try


    End Function
    Private Function ActualizarBaseDatos() As Boolean

        Try
            bd.ActualizarCambios(TablaMantenimiento, bd.ds)
            'LlenarDataGrid()

            'Cargando = True
            'LlenarDataGrid()
            'Cargando = False

            Return True
        Catch ex As SqlClient.SqlException
            If ex.Number = 2627 Then
                MensajeError(GL_ValorDuplicado)
            Else
                MensajeError(ex.Message)
            End If

            '  bd.ds.RejectChanges()
            Return False
        End Try
    End Function

    Private Function ComprobarDatos() As Boolean
        If txtCodigo.Text.ToString.Trim = "" And Not EstoyEnAlta Then
            MensajeError("El campo código no puede estar vacío")

            txtCodigo.Focus()
            Return False
        End If

        If txtNombre.Text.ToString.Trim = "" Then
            MensajeError("El campo nombre no puede estar vacío")

            txtNombre.Focus()
            Return False
        End If



        Return True

    End Function

    Private Sub dgvxClientes_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)

        If e.KeyCode = Keys.Escape And btnAceptar.Enabled = True Then

            Try

                Cancelar()
            Catch ex As Exception

            End Try

 
        End If

        If e.KeyCode = Keys.F1 And btnAceptar.Enabled = False Then
            Anadir()
            Exit Sub
        End If

        If e.KeyCode = Keys.F3 And btnAceptar.Enabled = False Then
            Modificar()
            Exit Sub
        End If

        

        If e.KeyCode = Keys.F12 Then
            Aceptar()
            Exit Sub
        End If
    End Sub

    Private Sub HabilitarBotones()


        btnAnadir.Enabled = True
        btnModificar.Enabled = False

        If bd.ds.Tables(TablaMantenimiento).Rows.Count > 0 Then
            btnModificar.Enabled = True

            btnAnadir.Enabled = False
        End If

        btnAceptar.Enabled = False
        btnCancelar.Enabled = False
        btnSalir.Enabled = True
        btnLogo.Enabled = False
        fotoactiva = False

    End Sub

    Private Sub DesHabilitarBotones()

        btnAnadir.Enabled = False
        btnModificar.Enabled = False

        btnSalir.Enabled = False
        btnAceptar.Enabled = True
        btnCancelar.Enabled = True
        btnLogo.Enabled = True
        fotoactiva = True
    End Sub

#End Region

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Salir()
    End Sub
    Private Sub Salir()
        Try
            Dim ExtensionLogo As String = ObtenerExtensionLogo()
            borraLogo(rutatmp)
        Catch ex As Exception

        End Try

        Me.Dispose()
        MostrarImagenDeFondo()
        LiberarMemoria()

    End Sub

   

    Private Sub imgLogo_doubleclick(sender As System.Object, e As System.EventArgs) Handles imgLogo.DoubleClick
        If fotoactiva Then
            EligeLogo()
        End If
    End Sub

    Private Sub btnLogo_Click(sender As System.Object, e As System.EventArgs) Handles btnLogo.Click
        EligeLogo()
    End Sub
    Private Sub EligeLogo()
        Try
            Dim Fichero As String = ""
            Dim ExtensionLogo As String = ObtenerExtensionLogo()
            borraLogo(rutatmp)
            Fichero = InsertarDocumento(clVariables.RutaServidor & "\Logos\Logo\tmp", 5, FicheroDestino:=DatosEmpresa.Codigo)

            If Fichero <> "" Then
                ExtensionLogo = My.Computer.FileSystem.GetFileInfo(Fichero).Extension
                ExtensionLogo = Replace(ExtensionLogo, ".", "")
                Dim Sel As String = ""
                Sel = "UPDATE Empresas SET ExtensionLogo = '" & ExtensionLogo & "'"
                BD_CERO.Execute(Sel)

                cargaLogo(rutatmp, ExtensionLogo)
            End If

            '   Dim ExtensionLogo As String = BD_CERO.Execute("SELECT ExtensionLogo FROM Empresas WHERE Codigo = " & DatosEmpresa.Codigo, False)
        Catch
        End Try
    End Sub
    Private Sub cargaLogo(ruta As String, ExtensionLogo As String)
        If System.IO.File.Exists(ruta & "." & ExtensionLogo) Then

            Dim img As Image = Image.FromStream(New IO.MemoryStream(IO.File.ReadAllBytes(ruta & "." & ExtensionLogo)))
            imgLogo.Image = img
 
        End If
    
    End Sub
    Private Sub mueveLogo(de As String, a As String, ExtensionLogo As String)
        If System.IO.File.Exists(de & "." & ExtensionLogo) Then
            System.IO.File.Move(de & ExtensionLogo, a & ExtensionLogo)
        End If

    End Sub
    Private Sub borraLogo(ruta As String)

        Dim ExtensionLogo As String = ""

        ExtensionLogo = "jpg"
        If System.IO.File.Exists(ruta & "." & ExtensionLogo) Then
            System.IO.File.Delete(ruta & "." & ExtensionLogo)
        End If

        ExtensionLogo = "png"
        If System.IO.File.Exists(ruta & "." & ExtensionLogo) Then
            System.IO.File.Delete(ruta & "." & ExtensionLogo)
        End If


        ExtensionLogo = "bmp"
        If System.IO.File.Exists(ruta & "." & ExtensionLogo) Then
            System.IO.File.Delete(ruta & "." & ExtensionLogo)
        End If



    End Sub
    Private Sub copiaLogo(de As String, a As String, ExtensionLogo As String)
        If System.IO.File.Exists(de & "." & ExtensionLogo) Then
            System.IO.File.Copy(de & "." & ExtensionLogo, a & "." & ExtensionLogo)
        End If

    End Sub

    Private Sub btnEnviarEmailTrasteros_Click(sender As System.Object, e As System.EventArgs) Handles btnEnviarEmailTrasteros.Click

        'Esto hay que cambiarlo cada día. Empezamos por el 1
        'Clientes será 5 días (hay unos 9300)

        'Propietarios será 2 días (hay unos 9300)

        Dim Sel As String
        Sel = "SELECT UltimoDia FROM TrasteroEnvios"
        Dim UltimoDia As Integer = BD_CERO.Execute(Sel, False)

         
        Dim QueDiaEs As Integer = UltimoDia + 1


        If MsgBox("Vas a enviar los trasteros del día " & QueDiaEs & "¿Continuar?", vbYesNo) = MsgBoxResult.No Then
            Return
        End If


        Dim EmailDestino As String = ""
        Dim Cuenta As Integer = 0




        Dim ListaDestinos As New System.Net.Mail.MailAddressCollection

        '        Dim Email As New System.Net.Mail.MailAddress("josecifre73@gmail.com", "Jose Cifre")



        EmailDestino = "josecifre73@gmail.com"

        EmailDestino = "josecifre@tresbits.es"

        EmailDestino = "nataliauim@hotmail.com"

        '   EmailDestino = "jose.cifre@hotmail.com"


        Dim CuantosAlDia As Integer = 2000





        'Sel = "select Contador, Email from clientes where  NoQuiereRecibirEmails = 0 and Email <> '' and TipoVenta <> 'VACACIONAL'  ORDER BY Nombre offset  " & CuantosAlDia * (QueDiaEs - 1) & " ROWS fetch next " & CuantosAlDia & " rows only "

        Sel = "select Contador, Email from propietarios where  NoQuiereRecibirEmails = 0 and Email <> '' ORDER BY Nombre offset  " & CuantosAlDia * (QueDiaEs - 1) & " ROWS fetch next " & CuantosAlDia & " rows only "
        Dim bdEmails As New BaseDatos

        bdEmails.LlenarDataSet(Sel, "t")

        Dim pf As New ProgressForm(bdEmails.ds.Tables("t").Rows.Count, "Enviando Trasteros ...")

        For Cuenta = 0 To bdEmails.ds.Tables("t").Rows.Count - 1
            pf.nuevoPaso(Cuenta & " de " & bdEmails.ds.Tables("t").Rows.Count)
            EmailDestino = bdEmails.ds.Tables("t").Rows(Cuenta)("Email")
            'EmailDestino = "marquezlopez@hotmail.com"
            '    EmailDestino = "nataliauim@hotmail.com"
            'EmailDestino = "jose.cifre@hotmail.com"
            'EmailDestino = "josecifre@tresbits.es"
            Try
                If QueDiaEs = 1 And Cuenta < 270 Then
                    Funciones.EnviarCorreoTrasteroUIM(EmailDestino, "INAUGURACION !! TRASTEROS EN PUERTO DE SAGUNTO EN ALQUILER", True)
                Else

                End If

            Catch ex As Exception
                Dim Texto As String = "Error Contador " & bdEmails.ds.Tables("t").Rows(Cuenta)("Contador") & " Cuenta: " & Cuenta & " QueDiaEs: " & QueDiaEs

                Sel = "INSERT INTO TrasteroError VALUES ('" & Texto & "')"
                BD_CERO.Execute(Sel)
            End Try

            Sel = "INSERT INTO TrasteroEmailEnviado VALUES ('" & EmailDestino & "')"
            BD_CERO.Execute(Sel)
        Next

        pf.Close()

        'EmailDestino = "josecifre@tresbits.es"

        'EmailDestino = "jose.cifre@hotmail.com"
        '    Funciones.EnviarCorreoTrasteroUIM(EmailDestino, "INAUGURACION !! TRASTEROS EN PUERTO DE SAGUNTO EN ALQUILER", True)
        '    Sel = "INSERT INTO TrasteroEmailEnviado VALUES ('" & EmailDestino & "')"
        '    BD_CERO.Execute(Sel)


        Sel = "update TrasteroEnvios set UltimoDia = " & QueDiaEs
        BD_CERO.Execute(Sel)
       


    End Sub
End Class







