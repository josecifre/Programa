Imports System.Data.SqlClient
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class ucCambioPrecio

    Dim bd As New BaseDatos
    Dim PrecioAntes As Integer
    Dim PrecioAntesProp As Integer

    Public ContadorInmueble As Integer = -1

    Public Property ContaInmueble As Integer
        Get
            Return ContadorInmueble
        End Get
        Set(value As Integer)
            ContadorInmueble = value
        End Set
    End Property

    Sub New(ContaInmueble As Integer)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        ContadorInmueble = ContaInmueble
        CargarValores()


    End Sub
    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Public Sub CargarValores()

        AparienciaGeneral()

        Dim Sel As String = "SELECT *, (SELECT Nombre FROM Empleados E WHERE E.Contador = CP.ContadorEmpleado) AS Empleado  FROM CambiosPrecio CP WHERE ContadorInmueble = " & ContadorInmueble & " ORDER BY Contador DESC"
        bd = New BaseDatos
        bd.LlenarDataSet(Sel, "CambiosPrecio", , False)
        dgvx.DataSource = bd.ds
        dgvx.DataMember = "CambiosPrecio"

        'bd.ds.Tables("CambiosPrecio").Columns.Add("Cambio", GetType(String))


        'Dim UltimaFila As Integer
        'UltimaFila = bd.ds.Tables("CambiosPrecio").Rows.Count - 1

        ''UltimaFila = 0
        'If UltimaFila > 0 Then
        '    PrecioAntes = bd.ds.Tables("CambiosPrecio").Rows(0)("PrecioDespues").ToString
        'Else
        PrecioAntes = BD_CERO.Execute("SELECT Precio FROM Inmuebles WHERE Contador=" & ContadorInmueble, False)
        'End If

        PrecioAntesProp = BD_CERO.Execute("SELECT PrecioPropietario FROM Inmuebles WHERE Contador=" & ContadorInmueble, False)

        'Dim dtr As Object
        'Dim bdPobs As New BaseDatos()

        'Dim SelAlta As String = "SELECT  PrecioPropietario FROM Inmuebles WHERE Contador = " & ContadorInmueble


        'dtr = bdPobs.ExecuteReader(SelAlta)
        'If dtr.HasRows Then
        '    While dtr.Read
        '        spnPrecioVentaProp.Text = dtr("PrecioPropietario").ToString
        '    End While
        'End If
        'dtr.Close()
        'bdPobs.CerrarBD()
        'PrecioAntesProp = spnPrecioVentaProp.Text


        spnPrecioVenta.Text = PrecioAntes
        spnPrecioVentaProp.Text = PrecioAntesProp

        ConfigurarGrid()

    End Sub

    Private Sub ConfigurarGrid()


        ParametrizarGrid(Gv)
        '        Gv.BestFitColumns()
        Gv.OptionsView.ColumnAutoWidth = True
        Gv.OptionsView.ShowGroupPanel = False
        Gv.OptionsView.ShowAutoFilterRow = False

        'Gv.Columns("CambioPrecio").Visible = True

        Gv.Columns("Contador").Visible = False
        Gv.Columns("Contador").OptionsColumn.AllowShowHide = False

        Gv.Columns("ContadorInmueble").Visible = False
        Gv.Columns("ContadorInmueble").OptionsColumn.AllowShowHide = False

        Gv.Columns("ContadorEmpleado").Visible = False
        Gv.Columns("ContadorEmpleado").OptionsColumn.AllowShowHide = False

        'Gv.Columns("PrecioAntes").Visible = False
        'Gv.Columns("PrecioAntes").OptionsColumn.AllowShowHide = False
        'Gv.Columns("PrecioDespues").Visible = False
        'Gv.Columns("PrecioDespues").OptionsColumn.AllowShowHide = False

        Gv.Columns("Fecha").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Gv.Columns("Fecha").DisplayFormat.FormatString = "dd/MM/yy"
        Gv.Columns("Fecha").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

        ' Gv.Columns("Precio").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        'Gv.Columns("Precio").DisplayFormat.FormatString = "{0:n0}"


    End Sub
    Private Sub gv_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles Gv.RowCellStyle

        If e.Column.FieldName = "Precio" Then
            Dim View As GridView = sender
            Dim Cambio As String = ""

            Cambio = View.GetDataRow(e.RowHandle).Item("Cambio")


            Select Case Cambio
                Case "SUBE"
                    e.Appearance.BackColor = Color.Salmon
                    e.Appearance.BackColor2 = Color.SeaShell
                    e.Appearance.GradientMode = Drawing2D.LinearGradientMode.BackwardDiagonal
                Case "BAJA"
                    e.Appearance.BackColor = Color.LightGreen
                    e.Appearance.BackColor2 = Color.GreenYellow
                    e.Appearance.GradientMode = Drawing2D.LinearGradientMode.BackwardDiagonal
            End Select
        End If

    End Sub



    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        ConfirmarPrecios()
        Salir()
    End Sub
    Public Sub ConfirmarPrecios()
        'Si hay cambios insertar

        'Dim CambioVenta As Boolean = False

        Dim CambioVentaStr As String = Nothing
        Dim CambioVentaPropStr As String = Nothing

        If spnPrecioVentaProp.Text > PrecioAntesProp Then
            CambioVentaPropStr = "SUBE"
        End If

        If spnPrecioVentaProp.Text < PrecioAntesProp Then
            CambioVentaPropStr = "BAJA"
        End If

        If spnPrecioVenta.Text > PrecioAntes Then
            CambioVentaStr = "SUBE"
        End If

        If spnPrecioVenta.Text < PrecioAntes Then
            CambioVentaStr = "BAJA"
        End If


        If (CambioVentaPropStr = "" And spnPrecioVentaProp.Text = PrecioAntesProp) AndAlso (CambioVentaStr = "" And spnPrecioVenta.Text = PrecioAntes) Then
            'If ContadorInmueble > -1 Then MensajeError("No hay cambios que guardar")
            Exit Sub
        End If

        GL_ObservacionesCambioPrecio = IIf(Not CambioVentaStr = "", CambioVentaStr & " precio venta de " & CStr(Format(PrecioAntes, "N0")) & " a " & CStr(spnPrecioVenta.Text) & ". ", "")
        GL_ObservacionesCambioPrecio &= IIf(Not CambioVentaPropStr = "", CambioVentaPropStr & " precio propietario de " & CStr(Format(PrecioAntesProp, "N0")) & " a " & CStr(spnPrecioVentaProp.Text) & ".", "")

        'Dim GL_CambiosPrecios As New Tablas.clGL_CambiosPrecioscios

        GL_CambiosPrecios.HayCambios = True
        GL_CambiosPrecios.ContadorInmueble = ContadorInmueble
        GL_CambiosPrecios.ContadorEmpleado = GL_CodigoUsuario
        GL_CambiosPrecios.Precio = spnPrecioVenta.Text

        GL_CambiosPrecios.CambioPropietario = CambioVentaPropStr
        GL_CambiosPrecios.Cambio = CambioVentaStr

        GL_CambiosPrecios.PrecioPropietario = spnPrecioVentaProp.Text

        If Not (CambioVentaPropStr = "" And spnPrecioVentaProp.Text = PrecioAntesProp) Then
            InsertarCambiosPrecios(GL_CambiosPrecios)
        End If
        ActualizarPreciosPropietario(GL_CambiosPrecios)


        'If DatosEmpresa.WordPress Then
        '    Dim Sel As String
        '    Dim ID_WP_Pasado As Integer = 0
        '    Sel = "SELECT Id_WP FROM Inmuebles WHERE Contador = " & GL_CambiosPrecios.ContadorInmueble
        '    ID_WP_Pasado = BD_CERO.Execute(Sel, False, 0)

        '    If ID_WP_Pasado <> 0 Then
        '        Dim Referencia As String
        '        Sel = "SELECT Referencia FROM Inmuebles WHERE Contador = " & GL_CambiosPrecios.ContadorInmueble
        '        Referencia = BD_CERO.Execute(Sel, False, "")

        '        If Referencia <> "" Then
        '            FuncionesBD.Accion("UPDATE", "Inmuebles", Referencia)
        '        End If
        '        'Publicar piso antes de entrar en inmuebles


        '    End If

        'End If



        RefrescarDatosDesdeBdInmuebles(True)
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Salir()
    End Sub
    Private Sub Salir()
        Me.ParentForm.Dispose()
    End Sub

    Public Function ActualizarPreciosPropietario(CambiosPre As Tablas.clCambiosPrecios) As Integer


        Try
            Dim Sel As String = "UPDATE Inmuebles SET " & _
                                " Precio = " & CambiosPre.Precio & _
                                ", PrecioPropietario = " & CambiosPre.PrecioPropietario
            If Not String.IsNullOrEmpty(CambiosPre.Cambio) Then
                Sel &= ", FechaCambioPrecio = " & GL_SQL_GETDATE
                Sel &= ", FechaUltimoCambio = " & GL_SQL_GETDATE
                If DatosEmpresa.Codigo <> 2 Then
                    Sel &= ", CambioPrecio = '" & CambiosPre.Cambio & "'"
                End If
            End If
            If Not String.IsNullOrEmpty(CambiosPre.CambioPropietario) AndAlso DatosEmpresa.Codigo = 2 Then
                Sel &= ", CambioPrecio = '" & CambiosPre.CambioPropietario & "'"
            End If
            Sel &= ", FechaUltimaLlamadaPropietario = " & GL_SQL_GETDATE
            Sel &= " WHERE Contador = " & CambiosPre.ContadorInmueble
            BD_CERO.Execute(Sel)


            FuncionesBD.Accion("UPDATE", "Inmuebles", BD_CERO.Execute("SELECT Referencia FROM Inmuebles WHERE CONTADOR=" & CambiosPre.ContadorInmueble, False), False)

            Return 0
        Catch ex As Exception
            Return -1
        End Try
    End Function

    Public Function InsertarCambiosPrecios(CambiosPre As Tablas.clCambiosPrecios) As Integer

        Try
            Dim Sel As String = "INSERT INTO CambiosPrecio (ContadorInmueble, ContadorEmpleado, Fecha, PrecioAntes ,PrecioDespues) VALUES " & _
                                      "(" & CambiosPre.ContadorInmueble & ", " & CambiosPre.ContadorEmpleado & ", " & GL_SQL_GETDATE & " " & _
                                      ", " & PrecioAntesProp & ", " & FuncionesGenerales.Funciones.ReplacePuntos(CambiosPre.PrecioPropietario) & ")"
            PrecioAntesProp = CambiosPre.PrecioPropietario
            'If BD_CERO.Execute("SELECT COUNT(*) FROM CambiosPrecio WHERE ContadorInmueble = " & CambiosPre.ContadorInmueble) > 1 Then
            '    BD_CERO.Execute("" & GL_SQL_DELETE & "FROM NuevosCambiosPrecios WHERE ContadorInmueble = " & CambiosPre.ContadorInmueble)
            'End If
            'BD_CERO.Execute("INSERT INTO NuevosCambiosPrecios VALUES (" & CambiosPre.ContadorInmueble & " , " & gl_sql_getdate & " )")

            Return BD_CERO.Execute(Sel)

        Catch ex As Exception
            Return -1
        End Try


    End Function

   



End Class
