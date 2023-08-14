Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraEditors

Public Class frmEscaparate


    Public ContadorInmueble As Integer
    Public ContadorPropietario As Integer
    Public ReferenciaInmueble As String
    Dim CarpetaImagenes As String

    Dim ds As DataSet
    Dim bd As BaseDatos
    Dim dt As DataTable
    Dim Fotos() As String
    Private Sub frmEscaparate_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        AparienciaGeneral()

        If Not GL_ConfiguracionWeb.PaginaDetalle = "" Then
            chkMostrarQR.Enabled = True
        Else
            chkMostrarQR.Enabled = False
        End If

        Me.Text = "Escaparate de: " & ReferenciaInmueble
        imgSecundaria.Parent = imgPrincipal
        imgPrincipal.Properties.ReadOnly = True
        imgSecundaria.Properties.ReadOnly = True
        With gc.Gallery
            .ItemImageLayout = ImageLayoutMode.ZoomInside
            .ImageSize = New Size(120, 90)
            .ItemCheckMode = Gallery.ItemCheckMode.SingleCheck
            .AllowHoverImages = False
            .ShowItemText = True
        End With

        'JCB CARPETA FOTOS
        CarpetaImagenes = GL_CarpetaFotos & "\" & ReferenciaInmueble
        CargaGalleria()
        CargarInformes()
        CargarFotos(getInforme)

         

    End Sub
    Private Sub CargarInformes()
        Dim Sel As String = "SELECT * FROM InmueblesInformes WHERE ContadorInmueble =" & ContadorInmueble
        bd = New BaseDatos
        bd.LlenarDataSet(Sel, "Informes")
        dt = bd.ds.Tables("Informes")
        'si tenemos una tabla con los tipos de informes, aqui cargariamos una tabla con ellos y el informe segun las pautas, de momento se cargan los dos informes basicos
        lbcInformes.Items.Clear()
        For Each row As DataRow In dt.Rows
            lbcInformes.Items.Add(row.Item("Informe"))
        Next
        Dim ok1 As Boolean = False
        Dim ok2 As Boolean = False
        For Each item As String In lbcInformes.Items
            If item.Contains("1") Then
                ok1 = True
            End If
            If item.Contains("2") Then
                ok2 = True
            End If
        Next
        If Not ok1 Then lbcInformes.Items.Add("Escaparate 1 foto(Vacio)")
        If Not ok2 Then lbcInformes.Items.Add("Escaparate 2 fotos(Vacio)")
        lbcInformes.SortOrder = SortOrder.Ascending
        lbcInformes.SelectedIndex = 0
    End Sub
    Private Sub CargaGalleria()
        With gc.Gallery.Groups
            .Item(0).Caption = "Imágenes del inmueble"
            .Item(0).Items.Clear()
            If Not System.IO.Directory.Exists(CarpetaImagenes) Then
                Exit Sub
            End If
            Dim DirFiles() As String = System.IO.Directory.GetFiles(CarpetaImagenes, "*.*")
            If DirFiles.Length > 0 Then
                For i = 0 To DirFiles.Length - 1
                    Try
                        Dim img As Image = Funciones.redimensionaimagen(Image.FromStream(New IO.MemoryStream(IO.File.ReadAllBytes(DirFiles(i)))), 120, 90, False)
                        .Item(0).Items.Add(New GalleryItem(img, Nothing, My.Computer.FileSystem.GetName(DirFiles(i)), "", i, i, DirFiles(i), ""))

                    Catch
                    End Try
                Next
                .Item(0).Caption = "Imágenes del inmueble (" & DirFiles.Length & ")"
            End If
        End With
    End Sub
    Private Sub CargarFotos(info As String)
        'carga de fotos
        For Each row As DataRow In dt.Rows
            If row.Item("Informe") = lbcInformes.SelectedItem Then
                Fotos = Split(row.Item("Fotos"), "|")
                Exit For
            End If
        Next
        'esto ira en funcion de los tipos de informe
        'activacion de los controles q correspondan
        Select Case info
            Case "Escaparate 1 foto(Vacio)", "Escaparate 1 foto"
                imgSecundaria.Visible = False
                btnSecundaria.Visible = False
            Case "Escaparate 2 fotos(Vacio)", "Escaparate 2 fotos"
                imgSecundaria.Visible = True
                btnSecundaria.Visible = True
        End Select
        'rellenado de los controles
        Limpiar(False)
        If Not info.Contains("Vacio") Then
            'Dim items As List(Of GalleryItem) = gc.Gallery.GetAllItems
            'For Each item As GalleryItem In items
            Dim DirFiles() As String = System.IO.Directory.GetFiles(CarpetaImagenes, "*.*")
            If DirFiles.Length > 0 Then
                For i = 0 To DirFiles.Length - 1
                    If imgPrincipal.Visible Then
                        'If My.Computer.FileSystem.GetName(Fotos(0)) = item.Caption Then
                        If My.Computer.FileSystem.GetName(Fotos(0)) = My.Computer.FileSystem.GetName(DirFiles(i)) Then
                            Try
                                imgPrincipal.Image = Image.FromStream(New IO.MemoryStream(IO.File.ReadAllBytes(DirFiles(i))))
                            Catch
                            End Try
                            '.Item(0).Caption = "Imágenes del inmueble (" & DirFiles.Length & ")"
                            'imgPrincipal.Image = item.Image
                            imgPrincipal.Image.Tag = My.Computer.FileSystem.GetName(DirFiles(i)) 'item.Caption
                        End If
                    End If
                    If imgSecundaria.Visible Then
                        'If My.Computer.FileSystem.GetName(Fotos(1)) = item.Caption Then
                        If My.Computer.FileSystem.GetName(Fotos(1)) = My.Computer.FileSystem.GetName(DirFiles(i)) Then
                            Try
                                imgSecundaria.Image = Image.FromStream(New IO.MemoryStream(IO.File.ReadAllBytes(DirFiles(i))))
                            Catch
                            End Try
                            'imgSecundaria.Image = item.Image
                            imgSecundaria.Image.Tag = My.Computer.FileSystem.GetName(DirFiles(i)) 'item.Caption
                        End If
                    End If
                Next
            End If
        End If
    End Sub
    Private Function getInforme() As String
        Return lbcInformes.SelectedItem
    End Function
   Private Sub lbcInformes_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lbcInformes.SelectedIndexChanged
        If lbcInformes.SelectedIndex >= 0 Then
            CargarFotos(getInforme)
        End If
    End Sub
    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Salir()
    End Sub
    Private Sub Salir()
 
        Me.Dispose()
        LiberarMemoria()
    End Sub
    Private Sub btnPrincipal_Click(sender As System.Object, e As System.EventArgs) Handles btnPrincipal.Click
        Mostrar(True)
    End Sub
    Private Sub btnSecundaria_Click(sender As System.Object, e As System.EventArgs) Handles btnSecundaria.Click
        Mostrar()
    End Sub
    Sub Mostrar(Optional Principal As Boolean = False)
        If Principal Then
            imgPrincipal.Image = Nothing
        Else
            imgSecundaria.Image = Nothing
        End If
        Dim items As List(Of GalleryItem)
        items = gc.Gallery.GetCheckedItems()
        For Each item As GalleryItem In items
            Dim img As Image = Image.FromStream(New IO.MemoryStream(IO.File.ReadAllBytes(CStr(item.Tag))))

            If Principal Then
                imgPrincipal.Image = img
                imgPrincipal.Image.Tag = My.Computer.FileSystem.GetName(item.Tag)
                Exit For
            Else
                imgSecundaria.Image = img
                imgSecundaria.Image.Tag = My.Computer.FileSystem.GetName(item.Tag)
                Exit For
            End If
        Next

        imgPrincipal.Refresh()
        imgSecundaria.Refresh()
    End Sub

    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click
        Limpiar()
    End Sub
    Private Sub Limpiar(Optional Pregunta As Boolean = True)
        If Pregunta Then
            If XtraMessageBox.Show("¿Confirma que quiere quitar las fotos actuales?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
                Exit Sub
            End If
        End If
        imgPrincipal.Image = Nothing
        imgSecundaria.Image = Nothing
        imgPrincipal.Refresh()
        imgSecundaria.Refresh()
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        If imgPrincipal.Image Is Nothing Then
            XtraMessageBox.Show("No hay foto principal", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If getInforme.Contains("2") Then
            If imgSecundaria.Image Is Nothing Then
                XtraMessageBox.Show("No hay foto secundaria", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        Dim bd As New BaseDatos
        Dim Sel As String
        Dim CodigoEmpresa As Integer = DatosEmpresa.Codigo

        Dim TextoBarraMes As String = ""
        Dim TipoVenta As String = BD_CERO.Execute("SELECT TipoVenta FROM Inmuebles WHERE Contador = " & ContadorInmueble, False)
        If TipoVenta.ToString.Length > Len(GL_Palabra_Alquiler) - 1 AndAlso Microsoft.VisualBasic.Left(TipoVenta.ToString, Len(GL_Palabra_Alquiler)) = GL_Palabra_Alquiler Then
            TextoBarraMes = "'/mes'"
        Else
            TextoBarraMes = "''"
        End If
        'If GL_TipoBD = EnumTipoBD.SQL_SERVER Then
        '    Sel = "SELECT  '" & ConsultasBaseDatos.ObtenerDescripcionInmueble2(ContadorInmueble, 0, False, False) & "' as Texto, " & _
        '        "(" & Funciones.SQL_CASE({"Precio > 0", "Precio <= 0"}, {"" & _
        '        "' PRECIO '" & GL_SQL_SUMA & " TipoVenta " & GL_SQL_SUMA & "': '" & GL_SQL_SUMA & " REPLACE(CONVERT(VARCHAR(20), C AST(Precio AS MONEY), 1), '.00', '') " & GL_SQL_SUMA & "' €'" & GL_SQL_SUMA & TextoBarraMes & GL_SQL_SUMA & " " & _
        '        Funciones.SQL_CASE({"Trastero IS NULL AND PrecioTrastero>0", "Trastero IS NOT NULL OR PrecioTrastero<=0"}, {"' TRASTERO: '" & GL_SQL_SUMA & " REPLACE(CONVERT(VARCHAR(20), C AST(PrecioTrastero AS MONEY), 1), '.00', '')   " & GL_SQL_SUMA & "' € '", "''"}) & GL_SQL_SUMA & TextoBarraMes & GL_SQL_SUMA & _
        '        Funciones.SQL_CASE({"Garaje IS NULL AND PrecioGaraje>0", "Garaje IS NOT NULL OR PrecioGaraje<=0"}, {"' GARAJE: '" & GL_SQL_SUMA & " REPLACE(CONVERT(VARCHAR(20), C AST(PrecioGaraje AS MONEY), 1), '.00', '')   " & GL_SQL_SUMA & "' € '", "''"}) & GL_SQL_SUMA & TextoBarraMes & _
        '        "", "''"}) & ") AS Precio " & _
        '        " FROM Inmuebles WHERE Contador=" & ContadorInmueble
        'ElseIf GL_TipoBD = EnumTipoBD.ACCESS Then
        '    Sel = "SELECT  '" & ConsultasBaseDatos.ObtenerDescripcionInmueble2(ContadorInmueble, 0, False, False) & "' as Texto, " & _
        '        "(" & Funciones.SQL_CASE({"Precio > 0", "Precio <= 0"}, {"" & _
        '        "' PRECIO '" & GL_SQL_SUMA & " TipoVenta " & GL_SQL_SUMA & "': '" & GL_SQL_SUMA & " FORMAT(precio,'##,##0') " & GL_SQL_SUMA & "' €'" & GL_SQL_SUMA & TextoBarraMes & GL_SQL_SUMA & " " & _
        '        Funciones.SQL_CASE({"Trastero IS NULL AND PrecioTrastero>0", "Trastero IS NOT NULL OR PrecioTrastero<=0"}, {"' TRASTERO: '" & GL_SQL_SUMA & " FORMAT(PrecioTrastero,'##,##0')   " & GL_SQL_SUMA & "' € '", "''"}) & GL_SQL_SUMA & TextoBarraMes & GL_SQL_SUMA & _
        '        Funciones.SQL_CASE({"Garaje IS NULL AND PrecioGaraje>0", "Garaje IS NOT NULL OR PrecioGaraje<=0"}, {"' GARAJE: '" & GL_SQL_SUMA & " FORMAT(PrecioGaraje,'##,##0')   " & GL_SQL_SUMA & "' € '", "''"}) & GL_SQL_SUMA & TextoBarraMes & _
        '        "", "''"}) & ") AS Precio " & _
        '        " FROM Inmuebles WHERE Contador=" & ContadorInmueble
        'End If

        Sel = ""

        If GL_TipoBD = EnumTipoBD.SQL_SERVER Then
            Sel = "SELECT  '" & ConsultasBaseDatos.ObtenerDescripcionInmueble2(ContadorInmueble, 0, False, False) & "' as Texto, " & _
                "(" & Funciones.SQL_CASE({"Precio > 0", "Precio <= 0"}, {"" & _
                "' PRECIO '" & GL_SQL_SUMA & " TipoVenta " & GL_SQL_SUMA & "': '" & GL_SQL_SUMA & " REPLACE(CONVERT(VARCHAR(20), CAST(Precio AS MONEY), 1), '.00', '') " & GL_SQL_SUMA & "' €'" & GL_SQL_SUMA & TextoBarraMes & GL_SQL_SUMA & " " & _
                Funciones.SQL_CASE({"Trastero IS NULL AND PrecioTrastero>0", "Trastero IS NOT NULL OR PrecioTrastero<=0"}, {"' TRASTERO: '" & GL_SQL_SUMA & " REPLACE(CONVERT(VARCHAR(20), CAST(PrecioTrastero AS MONEY), 1), '.00', '')   " & GL_SQL_SUMA & "' €'" & GL_SQL_SUMA & TextoBarraMes, "''"}) & GL_SQL_SUMA & _
                Funciones.SQL_CASE({"Garaje IS NULL AND PrecioGaraje>0", "Garaje IS NOT NULL OR PrecioGaraje<=0"}, {"' GARAJE: '" & GL_SQL_SUMA & " REPLACE(CONVERT(VARCHAR(20), CAST(PrecioGaraje AS MONEY), 1), '.00', '')   " & GL_SQL_SUMA & "' €'" & GL_SQL_SUMA & TextoBarraMes, "''"}) & _
                "", "''"}) & ") AS Precio " & _
                " FROM Inmuebles WHERE Contador=" & ContadorInmueble
        ElseIf GL_TipoBD = EnumTipoBD.ACCESS Then
            Sel = "SELECT  '" & ConsultasBaseDatos.ObtenerDescripcionInmueble2(ContadorInmueble, 0, False, False) & "' as Texto, " & _
                "(" & Funciones.SQL_CASE({"Precio > 0", "Precio <= 0"}, {"" & _
                "' PRECIO '" & GL_SQL_SUMA & " TipoVenta " & GL_SQL_SUMA & "': '" & GL_SQL_SUMA & " FORMAT(precio,'##,##0') " & GL_SQL_SUMA & "' €'" & GL_SQL_SUMA & TextoBarraMes & GL_SQL_SUMA & " " & _
                Funciones.SQL_CASE({"Trastero IS NULL AND PrecioTrastero>0", "Trastero IS NOT NULL OR PrecioTrastero<=0"}, {"' TRASTERO: '" & GL_SQL_SUMA & " FORMAT(PrecioTrastero,'##,##0')   " & GL_SQL_SUMA & "' €'" & GL_SQL_SUMA & TextoBarraMes, "''"}) & GL_SQL_SUMA & _
                Funciones.SQL_CASE({"Garaje IS NULL AND PrecioGaraje>0", "Garaje IS NOT NULL OR PrecioGaraje<=0"}, {"' GARAJE: '" & GL_SQL_SUMA & " FORMAT(PrecioGaraje,'##,##0')   " & GL_SQL_SUMA & "' €'" & GL_SQL_SUMA & TextoBarraMes, "''"}) & _
                "", "''"}) & ") AS Precio " & _
                " FROM Inmuebles WHERE Contador=" & ContadorInmueble
        End If
        bd.LlenarDataSet(Sel, "Escaparate")

        'bd.ds.WriteXmlSchema(My.Application.Info.DirectoryPath & "\EsquemasXML\rptEscaparate.xsd")

        Dim r As New rptEscaparate
        r.DataSource = bd.ds
        r.DataMember = "Escaparate"

        Sel = "SELECT ImprimirCabecera FROM ConfiguracionEscaparate"
        Dim PonerCabecera As Boolean = BD_CERO.Execute(Sel, False)

        If PonerCabecera Then
            Dim ruta As String = clVariables.RutaServidor & "\Logos\Logo\" & DatosEmpresa.Codigo
            ruta &= "." & BD_CERO.Execute("SELECT ExtensionLogo FROM Empresas WHERE Codigo = " & DatosEmpresa.Codigo, False)
            If System.IO.File.Exists(ruta) Then
                Dim img As Image = Image.FromStream(New IO.MemoryStream(IO.File.ReadAllBytes(ruta)))
                r.imgTitulo.Image = img
            Else
                r.imgTitulo.Visible = False
                r.txtTituloEmail.LocationF = New PointF(r.imgTitulo.LocationF.X, r.txtTituloEmail.LocationF.Y)
                r.txtTituloNombre.LocationF = New PointF(r.imgTitulo.LocationF.X, r.txtTituloNombre.LocationF.Y)
                r.txtTituloTel.LocationF = New PointF(r.imgTitulo.LocationF.X, r.txtTituloTel.LocationF.Y)
                r.txtTituloWeb.LocationF = New PointF(r.imgTitulo.LocationF.X, r.txtTituloWeb.LocationF.Y)
            End If

            r.txtTituloNombre.Text = DatosEmpresa.NombreComercial
            r.txtTituloTel.Text = BD_CERO.Execute("SELECT Telefono1 " & GL_SQL_SUMA & "' / '" & GL_SQL_SUMA & " TelefonoMovil FROM Empresas WHERE Codigo = " & DatosEmpresa.Codigo, False)
            r.txtTituloEmail.Text = BD_CERO.Execute("SELECT Email FROM Empresas WHERE Codigo = " & DatosEmpresa.Codigo, False)
            r.txtTituloWeb.Text = BD_CERO.Execute("SELECT Web FROM Empresas WHERE Codigo = " & DatosEmpresa.Codigo, False)

        End If

        r.imgPrincipal.Image = imgPrincipal.Image

        If getInforme.Contains("1") Then r.imgSecundaria.Visible = False

        Dim CajasColocadas As Integer = 0
        Dim Precio As String = bd.ds.Tables(0).Rows(0)("Precio")


        Dim PosicionSiguienteCaja As Point
        Dim DistanciaEntreCajas As Integer = 10

        PosicionSiguienteCaja.X = r.txtPrecio.LeftF
        PosicionSiguienteCaja.Y = r.txtPrecio.TopF

        If chkMostrarPrecios.Checked Then
            r.txtPrecio.Visible = True
            r.txtPrecio.LocationF = PosicionSiguienteCaja
            PosicionSiguienteCaja.X = r.txtPrecio.LeftF
            PosicionSiguienteCaja.Y = PosicionSiguienteCaja.Y + r.txtPrecio.HeightF + DistanciaEntreCajas
        End If

        r.imgSecundaria.Image = imgSecundaria.Image
        r.Referencia.Text += CStr(ReferenciaInmueble)


        If chkMostrarQR.Checked Then
            'Dim web As String = ObtenerWebEmpresa()
            r.imgQR.Image = FuncionesEspecificas.GenerarQR(Funciones.EnlaceWeb(BD_CERO.Execute("SELECT Tipo FROM Inmuebles WHERE Contador=" & ContadorInmueble, False), TipoVenta, BD_CERO.Execute("SELECT Poblacion FROM Inmuebles WHERE Contador=" & ContadorInmueble, False), CStr(ReferenciaInmueble), False))
            'r.imgQR.Image = FuncionesEspecificas.GenerarQR(web & "/Inmuebles.aspx?Referencia=" & CStr(ReferenciaInmueble))
        Else
            r.imgQR.Image = Nothing
        End If



        Dim CajasTextoColocadas As Integer = 0



        r.ShowPreviewDialog()
        Guardar(getInforme)
        Salir()

    End Sub

    Private Sub HandleKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Delete Then
            Limpiar()
        End If
        If e.KeyCode = Keys.Escape Then
            Salir()
        End If

    End Sub


    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Guardar(getInforme)
    End Sub
    Private Sub Guardar(info As String)
        If imgPrincipal.Image Is Nothing Then
            XtraMessageBox.Show("No hay foto principal", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If getInforme.Contains("2") Then
            If imgSecundaria.Image Is Nothing Then
                XtraMessageBox.Show("No hay foto secundaria", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        Dim imagen As String
        imagen = imgPrincipal.Image.Tag & "|"
        Try
            imagen &= imgSecundaria.Image.Tag
        Catch
        End Try

        Dim Sel As String = ""
        Sel = GL_SQL_DELETE & " FROM InmueblesInformes WHERE ContadorInmueble = " & ContadorInmueble & " AND Informe = '" & info & "'"
        BD_CERO.Execute(Sel)

        Sel = "INSERT INTO InmueblesInformes VALUES (" & ContadorInmueble & ",'" & Replace(info, "(Vacio)", "") & "','" & Funciones.pf_ReplaceComillas(imagen) & "')"
        BD_CERO.Execute(Sel)

        'If info.Contains("Vacio") Then
        '    'insertamos
        '    bd.Execute("INSERT INTO InmueblesInformes VALUES (" & ContadorInmueble & ",'" & info.Substring(0, info.Length - 7) & "','" & Funciones.pf_ReplaceComillas(imagen) & "')")
        'Else
        '    'actualizamos
        '    'If lbcInformes.SelectedItem.Contains("2") Then
        '    bd.Execute("UPDATE InmueblesInformes SET Fotos='" & Funciones.pf_ReplaceComillas(imagen) & "' WHERE ContadorInmueble=" & ContadorInmueble & " AND Informe='" & info & "'")
        '    'End If
        'End If
        CargarInformes()
    End Sub

End Class







