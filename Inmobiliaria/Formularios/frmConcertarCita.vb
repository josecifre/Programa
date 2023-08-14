Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors
Imports DevExpress.XtraReports.UI
Imports System.Drawing.Text


Public Class frmConcertarCita
    Dim CitasImpresas As Boolean
    Dim p_ContadorCliente As Integer
    Dim p_NombreCliente As String
    Dim vengoDe As String


    Public Property ContadorCliente As Integer
        Get
            Return p_ContadorCliente
        End Get
        Set(value As Integer)
            p_ContadorCliente = value
        End Set
    End Property

    Public Property NombreCliente As String
        Get
            Return p_NombreCliente
        End Get
        Set(value As String)
            p_NombreCliente = value
        End Set
    End Property

    Sub New(ContadorClientePasado As Integer, NombreClientePasado As String, vengoDe As String)

        '  Llamada necesaria para el diseñador.
        InitializeComponent()

        ContadorCliente = ContadorClientePasado
        NombreCliente = NombreClientePasado
        Me.vengoDe = vengoDe
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub frmConcertarCita_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CitasImpresas = False
        AparienciaGeneral()

        lblCliente.Text = "Cliente: " & NombreCliente
        mskFecha.EditValue = Today
        mskHora.EditValue = CDate("00:00")


        Dim dt As New DataTable
        dt = ConsultasBaseDatos.ObtenerComerciales(DatosEmpresa.Codigo, Gl_Delegacion)


        cmbEmpleados.Properties.DataSource = dt
        cmbEmpleados.Properties.ValueMember = "Contador"
        cmbEmpleados.Properties.DisplayMember = "Nombre"

        ParametrizarGrid(Gv)
        ParametrizarGrid(GvCitas)

        LlenarGridInmuebles()
        LlenarGridVisitas()
        ConfigurarGrid()


        cmbEmpleados.EditValue = GL_CodigoUsuario


    End Sub

    Private Sub cmbEmpleados_QueryPopUp(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles cmbEmpleados.QueryPopUp
        cmbEmpleados.Properties.View.Columns("Contador").Visible = False
    End Sub


    Private Sub ConfigurarGrid()

        Gv.OptionsView.ShowGroupPanel = False
        Gv.OptionsView.ShowAutoFilterRow = True
        Gv.Columns("Contador").Visible = False
        Gv.Columns("Contador").OptionsColumn.AllowShowHide = False

        Gv.Columns("Referencia").Width = 60
        Gv.Columns("Referencia").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
        '  Gv.BestFitColumns()

        GvCitas.OptionsView.ShowGroupPanel = False
        GvCitas.OptionsView.ShowAutoFilterRow = True
        GvCitas.BestFitColumns()

        GvCitas.Columns("Fecha").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        GvCitas.Columns("Fecha").DisplayFormat.FormatString = "dd/MM/yy"
        GvCitas.Columns("Fecha").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

        GvCitas.Columns("Hora").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        GvCitas.Columns("Hora").DisplayFormat.FormatString = "HH:mm"
        GvCitas.Columns("Hora").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

        GvCitas.Columns("Contador").Visible = False
        GvCitas.Columns("Contador").OptionsColumn.AllowShowHide = False

        GvCitas.Columns("ContadorInmueble").Visible = False
        GvCitas.Columns("ContadorInmueble").OptionsColumn.AllowShowHide = False

        If Not IsDBNull(Gv.Columns("Direccion")) Then Gv.Columns("Direccion").Caption = "Dirección"
        If Not IsDBNull(Gv.Columns("Poblacion")) Then Gv.Columns("Poblacion").Caption = "Población"

        GvCitas.OptionsView.ShowAutoFilterRow = False

    End Sub
    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.Dispose()
    End Sub


    Public Sub LlenarGridInmuebles()


        Dim dt As New DataTable
        dt = ConsultasBaseDatos.ObtenerInmueblesParaConcertarCitas(DatosEmpresa.Codigo, Gl_Delegacion)
        dgvx.DataSource = Nothing
        dgvx.DataSource = dt


    End Sub

    Public Sub LlenarGridVisitas()


        Dim dt As New DataTable
        dt = ConsultasBaseDatos.ObtenerVisitasPendientes(ContadorCliente)
        dgvxCitas.DataSource = Nothing
        dgvxCitas.DataSource = dt


    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        ConcertarCita()
    End Sub
    Private Sub ConcertarCita()


        If cmbEmpleados.EditValue = Nothing Then
            MensajeError("Debe elegir un visitador")
            Return
        End If

        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            MensajeError("Debe elegir un inmueble")
            Return
        End If

        Dim Tab As New Tablas.clVisitas

        Tab.ContadorCliente = ContadorCliente
        Tab.ContadorEmpleado = cmbEmpleados.EditValue
        Tab.ContadorInmueble = Gv.GetFocusedRowCellValue("Contador")
        Tab.Delegacion = Gl_Delegacion
        Tab.CodigoEmpresa = DatosEmpresa.Codigo
        Tab.Fecha = mskFecha.EditValue
        Tab.Hora = mskHora.EditValue

        Tab.Impreso = False
        Tab.Observaciones = txtObservaciones.Text

        ConsultasBaseDatos.InsertarVisita(Tab)
        LlenarGridVisitas()

    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If GvCitas.RowCount = 0 OrElse GvCitas.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Return
        End If

        If XtraMessageBox.Show("¿Confirma que quiere eliminar el registro seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
            Exit Sub
        End If

        ConsultasBaseDatos.EliminarVisita(GvCitas.GetFocusedRowCellValue("Contador"))
        LlenarGridVisitas()

    End Sub

    Private Sub dgvx_Click(sender As System.Object, e As System.EventArgs) Handles dgvx.DoubleClick
        ConcertarCita()
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        If GvCitas.RowCount = 0 OrElse GvCitas.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Return
        End If

        Dim Venta As Boolean

        If XtraMessageBox.Show("¿Desea imprimir el documento de venta?", "Gestión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            Venta = True
        Else
            Venta = False
        End If



        Dim CodigoEmpresa As Integer = DatosEmpresa.Codigo

        Dim bd As New BaseDatos
        Dim bd1 As New BaseDatos
        Dim bd2 As New BaseDatos
        Dim Sel As String


        'selects para introducir informacion en el ds
        Sel = "select nombre, direccion,telefono1,telefono2,telefonomovil,codpostal,email,web,poblacion,NIF,avisolegal from empresas where codigo=" & DatosEmpresa.Codigo
        bd.LlenarDataSet(Sel, "Empresa")
        Sel = "SELECT (SELECT " & _
            Funciones.SQL_CASE({"Via <> '' and  Direccion <> ''", "Via = ''"}, {"Via " & GL_SQL_SUMA & "' '" & GL_SQL_SUMA & " Direccion", "Direccion"}) & GL_SQL_SUMA & _
            Funciones.SQL_CASE({"Direccion2 <> ''", "Direccion2 = ''"}, {"' '" & GL_SQL_SUMA & " Direccion2", "''"}) & GL_SQL_SUMA & _
            Funciones.SQL_CASE({"Numero <> ''", "Numero = ''"}, {"' Num: '" & GL_SQL_SUMA & " Numero", "''"}) & GL_SQL_SUMA
        
        If GL_TipoBD = EnumTipoBD.SQL_SERVER Then
            Sel &= Funciones.SQL_CASE({"Altura > 0", "Altura <=0"}, {"' Piso: '" & GL_SQL_SUMA & " replace(convert(varchar,Altura),',00','')", "''"}) & GL_SQL_SUMA & _
            Funciones.SQL_CASE({"Puerta <> ''", "Puerta = ''"}, {"' Pta: '" & GL_SQL_SUMA & " replace(convert(varchar,Puerta),',00','')", "''"}) & GL_SQL_SUMA
            If Venta Then
                Sel &= "' - '" & GL_SQL_SUMA & " i.Poblacion " & _
                    GL_SQL_SUMA & Funciones.SQL_CASE({"GarajeNumero <> ''", "GarajeNumero = ''"}, {"' Garaje: '" & GL_SQL_SUMA & " GarajeNumero", "''"}) & _
                    GL_SQL_SUMA & Funciones.SQL_CASE({"TrasteroNumero <> ''", "TrasteroNumero = ''"}, {"' Trastero: '" & GL_SQL_SUMA & " TrasteroNumero", "''"}) & _
                    GL_SQL_SUMA & "' Precio Venta: '" & GL_SQL_SUMA & "  REPLACE(CONVERT(VARCHAR(20), CAST(Precio AS MONEY), 1), '.00', '') " & GL_SQL_SUMA & "' €'"
            Else
                Sel &= "' - '" & GL_SQL_SUMA & " i.Poblacion " & _
                    GL_SQL_SUMA & Funciones.SQL_CASE({"GarajeNumero <> ''", "GarajeNumero = ''"}, {"' Garaje: '" & GL_SQL_SUMA & " GarajeNumero", "''"}) & _
                    GL_SQL_SUMA & Funciones.SQL_CASE({"TrasteroNumero <> ''", "TrasteroNumero = ''"}, {"' Trastero: '" & GL_SQL_SUMA & " TrasteroNumero", "''"}) & _
                    GL_SQL_SUMA & "' Precio Alquiler: '" & GL_SQL_SUMA & "  REPLACE(CONVERT(VARCHAR(20), CAST(Precio AS MONEY), 1), '.00', '') " & GL_SQL_SUMA & "' €/mes'"
            End If
            Sel &= GL_SQL_SUMA & "'<br/>REFERENCIA DEL INMUEBLE '" & GL_SQL_SUMA & " Referencia " & GL_SQL_SUMA & "' -- VISITA '" & GL_SQL_SUMA & " convert(varchar(10),v.fecha,103) " & GL_SQL_SUMA & "' a las '" & GL_SQL_SUMA & " left(v.hora,5) " & GL_SQL_SUMA & "' horas.' FROM Inmuebles i WHERE i.Contador  = v.ContadorInmueble ) as inmueble " & _
           " FROM visitas v WHERE Impreso = 0 AND ContadorCliente = " & ContadorCliente
        ElseIf GL_TipoBD = EnumTipoBD.ACCESS Then
            Sel &= Funciones.SQL_CASE({"Altura > 0", "Altura <=0"}, {"' Piso: '" & GL_SQL_SUMA & " FORMAT(Altura,'##0')", "''"}) & GL_SQL_SUMA & _
            Funciones.SQL_CASE({"Puerta <> ''", "Puerta = ''"}, {"' Pta: '" & GL_SQL_SUMA & " FORMAT(Puerta,'##0')", "''"}) & GL_SQL_SUMA
            If Venta Then
                Sel &= "' - '" & GL_SQL_SUMA & " i.Poblacion " & _
                    GL_SQL_SUMA & Funciones.SQL_CASE({"GarajeNumero <> ''", "GarajeNumero = ''"}, {"' Garaje: '" & GL_SQL_SUMA & " GarajeNumero", "''"}) & _
                    GL_SQL_SUMA & Funciones.SQL_CASE({"TrasteroNumero <> ''", "TrasteroNumero = ''"}, {"' Trastero: '" & GL_SQL_SUMA & " TrasteroNumero", "''"}) & _
                    GL_SQL_SUMA & "' Precio Venta: '" & GL_SQL_SUMA & "  FORMAT(precio,'##,##0') " & GL_SQL_SUMA & "' €'"
            Else
                Sel &= "' - '" & GL_SQL_SUMA & " i.Poblacion " & _
                    GL_SQL_SUMA & Funciones.SQL_CASE({"GarajeNumero <> ''", "GarajeNumero = ''"}, {"' Garaje: '" & GL_SQL_SUMA & " GarajeNumero", "''"}) & _
                    GL_SQL_SUMA & Funciones.SQL_CASE({"TrasteroNumero <> ''", "TrasteroNumero = ''"}, {"' Trastero: '" & GL_SQL_SUMA & " TrasteroNumero", "''"}) & _
                    GL_SQL_SUMA & "' Precio Alquiler: '" & GL_SQL_SUMA & "  FORMAT(precio,'##,##0') " & GL_SQL_SUMA & "' €/mes'"
            End If
            Sel &= GL_SQL_SUMA & "'<br/>REFERENCIA DEL INMUEBLE '" & GL_SQL_SUMA & " Referencia " & GL_SQL_SUMA & "' -- VISITA '" & GL_SQL_SUMA & " FORMAT(v.fecha,'dd/mm/yyyy') " & GL_SQL_SUMA & "' a las '" & GL_SQL_SUMA & " left(v.hora,5) " & GL_SQL_SUMA & "' horas.' FROM Inmuebles i WHERE i.Contador  = v.ContadorInmueble ) as inmueble " & _
           " FROM visitas v WHERE Impreso = 0 AND ContadorCliente = " & ContadorCliente
        End If
       
        bd1.LlenarDataSet(Sel, "Visitas")
        Sel = "select contador,nombre,nif,direccion,poblacion,telefono1,telefono2,TelefonoMovil,email,web from clientes where contador=" & ContadorCliente
        bd2.LlenarDataSet(Sel, "Cliente")

 

        'Sel = "UPDATE Inmuebles SET UltimaVisita = " & gl_sql_getdate & " WHERE Contador IN (SELECT ContadorInmueble FROM visitas v WHERE Impreso = 0 AND ContadorCliente = " & ContadorCliente & ")"
        'bd2.Execute(Sel)

        'creamos esquema
        '  bd1.ds.Tables("Visitas").WriteXmlSchema(My.Application.Info.DirectoryPath & "\EsquemasXML\rptAlquilerYVentaInmueble.xsd")
        Dim ExtensionLogo As String = ObtenerExtensionLogo()
        If Venta Then
            Dim r As New rptCompraInmueble
            r.DataSource = bd1.ds.Tables("Visitas")
            r.DataMember = "Visitas"
            r.Logo.ImageUrl = clVariables.RutaServidor & "\Logos\Logo\" & CodigoEmpresa & "." & ExtensionLogo

            Dim Cli As DataRow
            Cli = bd2.ds.Tables("Cliente").Rows(0)
            r.parNombreCliente.Value = Cli("Nombre")
            r.NifCliente.Text = Cli("nif")
            r.DomicilioCliente.Text = Cli("direccion")
            Dim tel As String = ""
            If Cli("telefonomovil") <> "" Then
                tel &= Cli("telefonomovil")
                If Cli("telefono1") <> "" Then tel &= " / "
            End If
            If Cli("telefono1") <> "" Then tel &= Cli("telefono1")
            If Cli("telefono2") <> "" Then tel &= " / " & Cli("telefono2")
            r.TelefonosCliente.Text = tel

            Dim Emp As DataRow
            Emp = bd.ds.Tables("Empresa").Rows(0)
            r.parEmpresa.Value = Emp("nombre") & "<b><font size=-1><br/>" & Emp("direccion") & " - " & Emp("telefono1") & "<br/>" & Emp("poblacion")
            r.EmpresaCif.Text = "CIF " & Emp("NIF")
            r.lblAvisoLegal.Text = Emp("AvisoLegal")
            r.ParNombreEmpresa.Value = Emp("nombre")
            r.parNombreCliente.Visible = False
            r.parEmpresa.Visible = False
            r.ParNombreEmpresa.Visible = False

            r.ShowPreview()
            CitasImpresas = True
        Else

            If DatosEmpresa.Codigo = 2 Then
                Dim r As New rptAlquilerInmuebleUIM



                r.DataSource = bd1.ds.Tables("Visitas")
                r.DataMember = "Visitas"
                r.Logo.ImageUrl = clVariables.RutaServidor & "\Logos\Logo\" & CodigoEmpresa & "." & ExtensionLogo

                Dim Cli As DataRow
                Cli = bd2.ds.Tables("Cliente").Rows(0)
                r.parNombreCliente.Value = Cli("Nombre")
                r.NifCliente.Text = Cli("nif")
                r.DomicilioCliente.Text = Cli("direccion")
                Dim tel As String = ""
                If Cli("telefonomovil") <> "" Then
                    tel &= Cli("telefonomovil")
                    If Cli("telefono1") <> "" Then tel &= " / "
                End If
                If Cli("telefono1") <> "" Then tel &= Cli("telefono1")
                If Cli("telefono2") <> "" Then tel &= " / " & Cli("telefono2")
                r.TelefonosCliente.Text = tel

                'Dim TextoComisionAlquiler As String

                'If DatosEmpresa.Codigo <> 2 Then
                '    TextoComisionAlquiler = "media mensualidad más el IVA correspondiente en caso de vivienda y de una mensualidad mas el IVA correspondiente en caso de local comercial, del precio total del alquiler, con un importe mínimo de 150 €"

                'Else
                '    TextoComisionAlquiler = "una mensualidad más el IVA correspondiente en caso de vivienda y de una mensualidad mas el IVA correspondiente en caso de local comercial, del precio total del alquiler, con un importe mínimo de 150 €"

                'End If


                Dim Emp As DataRow
                Emp = bd.ds.Tables("Empresa").Rows(0)
                r.parEmpresa.Value = Emp("nombre") & "<b><font size=-1><br/>" & Emp("direccion") & " - " & Emp("telefono1") & " - " & Emp("poblacion")
                r.EmpresaCif.Text = "CIF " & Emp("NIF")
                r.lblAvisoLegal.Text = Emp("AvisoLegal")

                r.parNombreCliente.Visible = False
                r.parEmpresa.Visible = False

                r.ShowPreview()
                CitasImpresas = True
            Else
                Dim r As New rptAlquilerInmueble



                r.DataSource = bd1.ds.Tables("Visitas")
                r.DataMember = "Visitas"
                r.Logo.ImageUrl = clVariables.RutaServidor & "\Logos\Logo\" & CodigoEmpresa & "." & ExtensionLogo

                Dim Cli As DataRow
                Cli = bd2.ds.Tables("Cliente").Rows(0)
                r.parNombreCliente.Value = Cli("Nombre")
                r.NifCliente.Text = Cli("nif")
                r.DomicilioCliente.Text = Cli("direccion")
                Dim tel As String = ""
                If Cli("telefonomovil") <> "" Then
                    tel &= Cli("telefonomovil")
                    If Cli("telefono1") <> "" Then tel &= " / "
                End If
                If Cli("telefono1") <> "" Then tel &= Cli("telefono1")
                If Cli("telefono2") <> "" Then tel &= " / " & Cli("telefono2")
                r.TelefonosCliente.Text = tel

                'Dim TextoComisionAlquiler As String

                'If DatosEmpresa.Codigo <> 2 Then
                '    TextoComisionAlquiler = "media mensualidad más el IVA correspondiente en caso de vivienda y de una mensualidad mas el IVA correspondiente en caso de local comercial, del precio total del alquiler, con un importe mínimo de 150 €"

                'Else
                '    TextoComisionAlquiler = "una mensualidad más el IVA correspondiente en caso de vivienda y de una mensualidad mas el IVA correspondiente en caso de local comercial, del precio total del alquiler, con un importe mínimo de 150 €"

                'End If


                Dim Emp As DataRow
                Emp = bd.ds.Tables("Empresa").Rows(0)
                r.parEmpresa.Value = Emp("nombre") & "<b><font size=-1><br/>" & Emp("direccion") & " - " & Emp("telefono1") & " - " & Emp("poblacion")
                r.EmpresaCif.Text = "CIF " & Emp("NIF")
                r.lblAvisoLegal.Text = Emp("AvisoLegal")

                r.parNombreCliente.Visible = False
                r.parEmpresa.Visible = False

                r.ShowPreview()
                CitasImpresas = True
            End If

          
        End If


    End Sub

    Private Sub btnImprimirListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirListado.Click

        If GvCitas.RowCount = 0 OrElse GvCitas.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            Return
        End If

        Dim bd As New BaseDatos
        Dim Sel As String
        Dim CodigoEmpresa As Integer = DatosEmpresa.Codigo
        Dim tb As Tablas.cl_AsuntoYMensaje = ConsultasBaseDatos.ObtenerAsuntoYCuerpoEmail(GL_EMAIL_LISTADO_CLIENTES, DatosEmpresa.Codigo, 0, "", ContadorCliente)
        Dim texto1 As String = tb.Titulo


        '        Sel = "SELECT 'EJEMPLAR PARA '" & GL_SQL_SUMA & " (SELECT NombreComercial from Empresas where codigo=" & CodigoEmpresa & ") as titulo,'" & texto1 & "' as texto1," & _
        '    "REPLACE(REPLACE((SELECT Direccion " & GL_SQL_SUMA & _
        '    Funciones.SQL_CASE({"Numero <> ''", "Numero = ''"}, {"' Num: '" & GL_SQL_SUMA & " Numero", "''"}) & GL_SQL_SUMA & _
        ' Funciones.SQL_CASE({"Altura > 0", "Altura <= 0"}, {"' Piso: '" & GL_SQL_SUMA & " replace(convert(varchar,Altura),',00','') ", " '' "}) & GL_SQL_SUMA & _
        ' Funciones.SQL_CASE({"Puerta <> ''", "Puerta = ''"}, {"' Pta: '" & GL_SQL_SUMA & " replace(convert(varchar,Puerta),',00','') ", " '' "}) & GL_SQL_SUMA & _
        '"' - '" & GL_SQL_SUMA & " i.Poblacion " & GL_SQL_SUMA & "' HORA: <b>'" & GL_SQL_SUMA & " left(v.hora,5) " & GL_SQL_SUMA & "'</b> LLAVES: '" & GL_SQL_SUMA & _
        '    Funciones.SQL_CASE({"Llaves = 0", "Llaves <> 0"}, {"'NO' ", " '<b><font color=""red"">SI</font></color></b>' "}) & GL_SQL_SUMA & "' FOTOS: '" & GL_SQL_SUMA & _
        '    Funciones.SQL_CASE({"(FotosPc" & GL_SQL_SUMA & "FotosWeb) = 0", "(FotosPc" & GL_SQL_SUMA & "FotosWeb) <> 0"}, {"'<b><font color=""blue"">NO</font></color></b>' ", " 'SI' "}) & GL_SQL_SUMA & _
        '    Funciones.SQL_CASE({"FotosRevisar > 0", "FotosRevisar <= 0"}, {"'<b><font color=""red""> Revisar Fotos</font></color></b>' ", " '' "}) & GL_SQL_SUMA & _
        '"'<br>'" & GL_SQL_SUMA & " ' PROPIETARIO: <b>'" & GL_SQL_SUMA & " p.Nombre " & GL_SQL_SUMA & "'</b> TELÉFONOS: <b>'" & GL_SQL_SUMA & _
        '    Funciones.SQL_CASE({"telefonoMovil<>''", "telefonoMovil=''"}, {"telefonoMovil " & GL_SQL_SUMA & "'/' ", " '' "}) & GL_SQL_SUMA & _
        '    Funciones.SQL_CASE({"Telefono1<>''", "telefono1=''"}, {"Telefono1 " & GL_SQL_SUMA & "'/' ", " '' "}) & GL_SQL_SUMA & _
        ' Funciones.SQL_CASE({"Telefono2<>''", "telefono2=''"}, {"Telefono2 " & GL_SQL_SUMA & "'/' ", " '' "}) & GL_SQL_SUMA & _
        ' Funciones.SQL_CASE({"Telefono3<>''", "telefono3=''"}, {"Telefono3 " & GL_SQL_SUMA & "'/' ", " '' "}) & GL_SQL_SUMA & _
        ' Funciones.SQL_CASE({"Telefono4<>''", "telefono4=''"}, {"Telefono4 ", " '*' "}) & GL_SQL_SUMA & "'</b><br>EMAILS: <b>'" & GL_SQL_SUMA & _
        'Funciones.SQL_CASE({"p.email<>''", "p.email=''"}, {"p.email " & GL_SQL_SUMA & "'/' ", " '' "}) & GL_SQL_SUMA & _
        '    Funciones.SQL_CASE({"p.email2<>''", "p.email2=''"}, {"p.email2 ", " '*' "}) & GL_SQL_SUMA & "'</b>' FROM propietarios p inner join Inmuebles i on p.contador=i.contadorpropietario WHERE i.Contador  = v.Contadorinmueble),'/*',''),'*','') AS texto2" & _
        '    ", contadorinmueble,(select Referencia from inmuebles where contador=v.contadorinmueble) as Referencia " & _
        '    "FROM visitas v WHERE Impreso = 0 AND ContadorCliente = " & ContadorCliente

        If GL_TipoBD = EnumTipoBD.SQL_SERVER Then
            Sel = "SELECT 'EJEMPLAR PARA '" & GL_SQL_SUMA & " (SELECT NombreComercial from Empresas where codigo=" & CodigoEmpresa & ") as titulo,'" & texto1 & "' as texto1," & _
        "REPLACE(REPLACE((SELECT Direccion " & GL_SQL_SUMA & _
        Funciones.SQL_CASE({"Numero <> ''", "Numero = ''"}, {"' Num: '" & GL_SQL_SUMA & " Numero", "''"}) & GL_SQL_SUMA & _
     Funciones.SQL_CASE({"Altura > 0", "Altura <= 0"}, {"' Piso: '" & GL_SQL_SUMA & " replace(convert(varchar,Altura),',00','') ", " '' "}) & GL_SQL_SUMA & _
     Funciones.SQL_CASE({"Puerta <> ''", "Puerta = ''"}, {"' Pta: '" & GL_SQL_SUMA & " replace(convert(varchar,Puerta),',00','') ", " '' "}) & GL_SQL_SUMA & _
    "' - '" & GL_SQL_SUMA & " i.Poblacion " & GL_SQL_SUMA & "' HORA: <b>'" & GL_SQL_SUMA & " left(v.hora,5) " & GL_SQL_SUMA & "'</b> LLAVES: '" & GL_SQL_SUMA & _
        Funciones.SQL_CASE({"Llaves = 0", "Llaves <> 0"}, {"'NO' ", " '<b><font color=""red"">SI</font></color></b>' "}) & GL_SQL_SUMA & "' FOTOS: '" & GL_SQL_SUMA & _
        Funciones.SQL_CASE({"(FotosPc" & GL_SQL_SUMA & "FotosWeb) = 0", "(FotosPc" & GL_SQL_SUMA & "FotosWeb) <> 0"}, {"'<b><font color=""blue"">NO</font></color></b>' ", " 'SI' "}) & GL_SQL_SUMA & _
        Funciones.SQL_CASE({"FotosRevisar " & GL_SQL_DIS & " 0", "FotosRevisar = 0"}, {"'<b><font color=""red""> Revisar Fotos</font></color></b>'", "''"}) & GL_SQL_SUMA & _
    "'<br>'" & GL_SQL_SUMA & " ' PROPIETARIO: <b>'" & GL_SQL_SUMA & " p.Nombre " & GL_SQL_SUMA & "'</b> TELÉFONOS: <b>'" & GL_SQL_SUMA & _
        Funciones.SQL_CASE({"telefonoMovil<>''", "telefonoMovil=''"}, {"telefonoMovil " & GL_SQL_SUMA & "'/' ", " '' "}) & GL_SQL_SUMA & _
        Funciones.SQL_CASE({"Telefono1<>''", "telefono1=''"}, {"Telefono1 " & GL_SQL_SUMA & "'/' ", " '' "}) & GL_SQL_SUMA & _
     Funciones.SQL_CASE({"Telefono2<>''", "telefono2=''"}, {"Telefono2 " & GL_SQL_SUMA & "'/' ", " '' "}) & GL_SQL_SUMA & _
     Funciones.SQL_CASE({"Telefono3<>''", "telefono3=''"}, {"Telefono3 " & GL_SQL_SUMA & "'/' ", " '' "}) & GL_SQL_SUMA & _
     Funciones.SQL_CASE({"Telefono4<>''", "telefono4=''"}, {"Telefono4 ", " '*' "}) & GL_SQL_SUMA & "'</b><br>EMAILS: <b>'" & GL_SQL_SUMA & _
    Funciones.SQL_CASE({"p.email<>''", "p.email=''"}, {"p.email " & GL_SQL_SUMA & "'/' ", " '' "}) & GL_SQL_SUMA & _
        Funciones.SQL_CASE({"p.email2<>''", "p.email2=''"}, {"p.email2 ", " '*' "}) & GL_SQL_SUMA & "'</b>' FROM propietarios p inner join Inmuebles i on p.contador=i.contadorpropietario WHERE i.Contador  = v.Contadorinmueble),'/*',''),'*','') AS texto2" & _
        ", contadorinmueble,(select Referencia from inmuebles where contador=v.contadorinmueble) as Referencia " & _
        "FROM visitas v WHERE Impreso = 0 AND ContadorCliente = " & ContadorCliente
        ElseIf GL_TipoBD = EnumTipoBD.ACCESS Then
            Sel = "SELECT 'EJEMPLAR PARA '" & GL_SQL_SUMA & " (SELECT NombreComercial from Empresas where codigo=" & CodigoEmpresa & ") as titulo,'" & texto1 & "' as texto1," & _
       "(SELECT Direccion " & GL_SQL_SUMA & _
       Funciones.SQL_CASE({"Numero <> ''", "Numero = ''"}, {"' Num: '" & GL_SQL_SUMA & " Numero", "''"}) & GL_SQL_SUMA & _
    Funciones.SQL_CASE({"Altura > 0", "Altura <= 0"}, {"' Piso: '" & GL_SQL_SUMA & " FORMAT(Altura,'##0') ", " '' "}) & GL_SQL_SUMA & _
    Funciones.SQL_CASE({"Puerta <> ''", "Puerta = ''"}, {"' Pta: '" & GL_SQL_SUMA & " FORMAT(Puerta,'##0') ", " '' "}) & GL_SQL_SUMA & _
   "' - '" & GL_SQL_SUMA & " i.Poblacion " & GL_SQL_SUMA & "' HORA: <b>'" & GL_SQL_SUMA & " left(v.hora,5) " & GL_SQL_SUMA & "'</b> LLAVES: '" & GL_SQL_SUMA & _
       Funciones.SQL_CASE({"Llaves = 0", "Llaves <> 0"}, {"'NO' ", " '<b><font color=""red"">SI</font></color></b>' "}) & GL_SQL_SUMA & "' FOTOS: '" & GL_SQL_SUMA & _
       Funciones.SQL_CASE({"(FotosPc" & GL_SQL_SUMA & "FotosWeb) = 0", "(FotosPc" & GL_SQL_SUMA & "FotosWeb) <> 0"}, {"'<b><font color=""blue"">NO</font></color></b>' ", " 'SI' "}) & GL_SQL_SUMA & _
     Funciones.SQL_CASE({"FotosRevisar " & GL_SQL_DIS & " 0", "FotosRevisar = 0"}, {"'<b><font color=""red""> Revisar Fotos</font></color></b>'", "''"}) & GL_SQL_SUMA & _
   "'<br>'" & GL_SQL_SUMA & " ' PROPIETARIO: <b>'" & GL_SQL_SUMA & " p.Nombre " & GL_SQL_SUMA & "'</b> TELÉFONOS: <b>'" & GL_SQL_SUMA & _
       Funciones.SQL_CASE({"telefonoMovil<>''", "telefonoMovil=''"}, {"telefonoMovil " & GL_SQL_SUMA & "'/' ", " '' "}) & GL_SQL_SUMA & _
       Funciones.SQL_CASE({"Telefono1<>''", "telefono1=''"}, {"Telefono1 " & GL_SQL_SUMA & "'/' ", " '' "}) & GL_SQL_SUMA & _
    Funciones.SQL_CASE({"Telefono2<>''", "telefono2=''"}, {"Telefono2 " & GL_SQL_SUMA & "'/' ", " '' "}) & GL_SQL_SUMA & _
    Funciones.SQL_CASE({"Telefono3<>''", "telefono3=''"}, {"Telefono3 " & GL_SQL_SUMA & "'/' ", " '' "}) & GL_SQL_SUMA & _
    Funciones.SQL_CASE({"Telefono4<>''", "telefono4=''"}, {"Telefono4 ", " '*' "}) & GL_SQL_SUMA & "'</b><br>EMAILS: <b>'" & GL_SQL_SUMA & _
   Funciones.SQL_CASE({"p.email<>''", "p.email=''"}, {"p.email " & GL_SQL_SUMA & "'/' ", " '' "}) & GL_SQL_SUMA & _
       Funciones.SQL_CASE({"p.email2<>''", "p.email2=''"}, {"p.email2 ", " '*' "}) & GL_SQL_SUMA & "'</b>' FROM propietarios p inner join Inmuebles i on p.contador=i.contadorpropietario WHERE i.Contador  = v.Contadorinmueble) AS texto2" & _
       ", contadorinmueble,(select Referencia from inmuebles where contador=v.contadorinmueble) as Referencia " & _
       "FROM visitas v WHERE Impreso = 0 AND ContadorCliente = " & ContadorCliente
        End If
        bd.LlenarDataSet(Sel, "Visitas")
        If GL_TipoBD = EnumTipoBD.ACCESS Then
            For Each RO As DataRow In bd.ds.Tables("Visitas").Rows
                RO("Texto2") = Replace(Replace(RO("Texto2"), "/*", ""), "*", "")
            Next
        End If

        Dim col As New DataColumn
        col = New DataColumn
        With col
            .DataType = System.Type.GetType("System.String")
            .ColumnName = "texto3"
            .Caption = "texto3"
        End With
        bd.ds.Tables("Visitas").Columns.Add(col)

        For i = 0 To bd.ds.Tables("Visitas").Rows.Count - 1

            '   bd.ds.Tables("Visitas").Rows(i)("texto3") = "Ref. " & bd.ds.Tables("Visitas").Rows(i)("Referencia") & " - " & ConsultasBaseDatos.ObtenerDescripcionInmueble2(bd.ds.Tables("Visitas").Rows(i)("contadorinmueble"))
            bd.ds.Tables("Visitas").Rows(i)("texto3") = ConsultasBaseDatos.ObtenerDescripcionInmueble2(bd.ds.Tables("Visitas").Rows(i)("contadorinmueble"))

        Next
        'bd.ds.WriteXmlSchema(My.Application.Info.DirectoryPath & "\EsquemasXML\rptListadoVisitas.xsd")

        Dim pfc As New PrivateFontCollection
        pfc.AddFontFile(My.Application.Info.DirectoryPath & "\Fuentes\Mouser Outline.ttf")
        Dim familia As FontFamily = pfc.Families(0)
        Dim fuente = New Font(familia, 30)

        Dim r As New rptListadoVisitas
        r.DataSource = bd.ds
        r.DataMember = "Visitas"
        r.ReportHeader.Visible = False
        r.Titulo1.Visible = False
        r.Texto2.Visible = False
        r.Detail.HeightF = 60
        Dim p As Point
        'p.X = 0
        'p.Y = 0
        'r.Texto3.LocationF = p
        p.Y = 31
        r.XrLine1.LocationF = p
        r.ShowPreviewDialog() 'Muestra la hoja base


        LiberarMemoria()

        r = New rptListadoVisitas
        r.DataSource = bd.ds
        r.DataMember = "Visitas"
        r.Titulo1.Font = fuente
        r.ReportHeader.Visible = True
        r.Titulo1.Visible = True
        r.Texto2.Visible = True
        r.Texto2.Html = True
        r.ShowPreview() 'Muestra el ejemplar para la empresa

        LiberarMemoria()

    End Sub

    Private Sub frmConcertarCita_FormClosed(sender As System.Object, e As System.EventArgs) Handles MyBase.FormClosed
        If CitasImpresas Then
            Dim Sel As String
            Sel = "INSERT INTO ClientesComunicaciones (CodigoEmpresa,Delegacion,ContadorInmueble , ContadorCliente ,Fecha ,ContadorEmpleado ,LlamadaContestada ,Observaciones ,Tipo ) " & _
                  " SELECT CodigoEmpresa,Delegacion,ContadorInmueble , ContadorCliente, CONVERT (DATETIME, Fecha)  + CONVERT (DATETIME,Hora)   AS Fecha2  ,ContadorEmpleado,convert (bit,0) as LlamadaContestada,'' as observaciones,'VISITA' as Tipo from Visitas " & _
                  " WHERE Impreso = 0 AND ContadorCliente = " & ContadorCliente
            BD_CERO.Execute(Sel)
            ConsultasBaseDatos.VisitasImpresas(ContadorCliente)
        End If
    End Sub

End Class