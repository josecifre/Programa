Imports DevExpress.XtraGrid

Public Class frmVisitasConcertadas
    Dim p_ContadorCliente As String
    Dim p_ContadorInmueble As String
    Dim p_NombreCliente As String
    Dim p_Referencia As String
    Dim vengoDe As String

    Dim bd As BaseDatos

    Public EsBajas As Boolean = False

    Private WithEvents BinSrc As BindingSource

    Public Property ContadorCliente As Integer
        Get
            Return p_ContadorCliente
        End Get
        Set(value As Integer)
            p_ContadorCliente = value
        End Set
    End Property

    Public Property ContadorInmueble As Integer
        Get
            Return p_ContadorInmueble
        End Get
        Set(value As Integer)
            p_ContadorInmueble = value
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

    Public Property Referencia As String
        Get
            Return p_Referencia
        End Get
        Set(value As String)
            p_Referencia = value
        End Set
    End Property

    Sub New(ContadorClientePasado As Integer, NombreClientePasado As String, ContadorInmueblePasado As Integer, ReferenciaPasada As String, vengoDe As String)

        '  Llamada necesaria para el diseñador.
        InitializeComponent()

        ContadorCliente = ContadorClientePasado
        NombreCliente = NombreClientePasado
        ContadorInmueble = ContadorInmueblePasado
        Referencia = ReferenciaPasada
        btnEliminar.Enabled = True
        Me.vengoDe = vengoDe
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Private Sub frmVisitas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If EsBajas Then btnCrearVisita.Visible = False
        txtObservaciones.Properties.ReadOnly = True

        If ContadorCliente <> 0 Then
            lblCliente.Text = "Listado de visitas del Cliente: " & NombreCliente
        Else
            btnCrearVisita.Visible = False
        End If

        If ContadorInmueble <> 0 Then
            lblCliente.Text = "Listado de visitas del Inmueble: " & Referencia
        End If

        If ContadorCliente = 0 And ContadorInmueble = 0 Then
            lblCliente.Text = "Listado de visitas"
        End If


        LlenarGridVisitas()
        ParametrizarGrid(Gv)
        ConfigurarGrid()
    End Sub
    Private Sub ConfigurarGrid()



        Gv.OptionsView.ShowGroupPanel = False
        Gv.OptionsView.ShowAutoFilterRow = True
        Gv.BestFitColumns()

        Gv.Columns("Fecha").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Gv.Columns("Fecha").DisplayFormat.FormatString = "dd/MM/yy"
        Gv.Columns("Fecha").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

        Gv.Columns("Hora").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Gv.Columns("Hora").DisplayFormat.FormatString = "HH:mm"
        Gv.Columns("Hora").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

        Gv.Columns("Contador").Visible = False
        Gv.Columns("Contador").OptionsColumn.AllowShowHide = False

        Gv.Columns("CodigoEmpresa").Visible = False
        Gv.Columns("CodigoEmpresa").OptionsColumn.AllowShowHide = False

        Gv.Columns("Delegacion").Visible = False
        Gv.Columns("Delegacion").OptionsColumn.AllowShowHide = False

        Gv.Columns("ContadorCliente").Visible = False
        Gv.Columns("ContadorCliente").OptionsColumn.AllowShowHide = False

        Gv.Columns("ContadorInmueble").Visible = False
        Gv.Columns("ContadorInmueble").OptionsColumn.AllowShowHide = False

        Gv.Columns("Observaciones").Visible = False
        Gv.Columns("Observaciones").OptionsColumn.AllowShowHide = False

        Gv.Columns("Impreso").Visible = False

        Gv.Columns("BajaCliente").Caption = "Baja"
        Gv.Columns("BajaInmueble").Caption = "Baja"

        Gv.Columns("BajaCliente").Width = 50
        Gv.Columns("BajaInmueble").Width = 50

        If Not IsDBNull(Gv.Columns("Direccion")) Then Gv.Columns("Direccion").Caption = "Dirección"



    End Sub


    Public Sub LlenarGridVisitas()


        Dim dt As New DataTable
        bd = ConsultasBaseDatos.ObtenerVisitas(DatosEmpresa.Codigo, Gl_Delegacion, ContadorCliente, ContadorInmueble, bd)
 

        BinSrc = New BindingSource
        BinSrc.DataSource = bd.ds.Tables(0)
        dgvxCitas.DataSource = BinSrc


        Try
            txtObservaciones.DataBindings.RemoveAt(0)

        Catch ex As Exception

        End Try


        Try
            txtObservaciones.DataBindings.Add(New Binding("EditValue", BinSrc, "Observaciones", True))
        Catch ex As Exception

        End Try


    End Sub
    Private Sub Salir()
        Me.Dispose()
    End Sub
    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Salir()
    End Sub

    Private Sub btnCrearVisita_Click(sender As System.Object, e As System.EventArgs) Handles btnCrearVisita.Click
        Dim f As New frmConcertarCita(ContadorCliente, NombreCliente, vengode)
        'Salir()
        f.ShowDialog()

        LlenarGridVisitas()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Eliminar()
    End Sub

    Private Sub Eliminar()



        If Not Funciones.TienePermisosAME() Then
            Return
        End If

        If Gv.RowCount = 0 OrElse Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then
            MensajeError("Debe seleccionar un registro")
            Return
        End If


        If DevExpress.XtraEditors.XtraMessageBox.Show("¿Confirma que quiere eliminar el registro seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
            Exit Sub
        End If


        'Dim ContadorCliente As String = BinSrc.Current("Contador")
        'Dim Sel As String

        'Sel = GL_SQL_DELETE & "  FROM ClientesObservaciones  WHERE ContadorCliente = " & ContadorCliente
        'BD_CERO.Execute(Sel)



        'Sel = GL_SQL_DELETE & "  FROM ClientesComunicaciones  WHERE ContadorCliente = " & ContadorCliente
        'BD_CERO.Execute(Sel)



        'Sel = GL_SQL_DELETE & "  FROM Visitas  WHERE ContadorCliente = " & ContadorCliente
        'BD_CERO.Execute(Sel)

        'Sel = GL_SQL_DELETE & "  FROM FichasAlquiler  WHERE ContadorCliente = " & ContadorCliente
        'BD_CERO.Execute(Sel)








        'If ConsultasBaseDatos.MarcaDeTiempoHaCambiado(TablaMantenimiento, BinSrc.Current("MarcaDeTiempo")) Then
        '    bd.RefrescarDatos(BinSrc.Position)
        'End If


        Dim FilaSeleccionada As Integer = Gv.FocusedRowHandle
        'BinSrc.RemoveCurrent()
        Gv.DeleteRow(Gv.FocusedRowHandle)

        BinSrc.EndEdit()

        If Not ActualizarBaseDatos() Then
            Return
        End If


         

        If FilaSeleccionada > 1 Then
            Gv.FocusedRowHandle = FilaSeleccionada - 1
        Else
            Try
                Gv.FocusedRowHandle = FilaSeleccionada + 1
            Catch ex As Exception

            End Try
        End If

         
    End Sub
    Private Function ActualizarBaseDatos(Optional ByVal RefrescarDatos As Boolean = False) As Boolean

        Try

            Dim ContadorMinimo As Integer = 0

              

            bd.ActualizarCambios("", bd.ds, RefrescarDatos)

            'If EstoyEnAlta Then

            '    CargandoClientes = True


            '    'Se supone que el cliente ya está dado de alta en la bd.
            '    'Como el contador es autonumérico, no lo tenemos en el dataset.
            '    'Con lo siguiente, vamos a acutaliazar el dataset con el contador que le han asignado al cliente
            '    Dim NuevoContador As Integer

            '    NuevoContador = ConsultasBaseDatos.ObtenerContadorClienteEnAlta(BinSrc.Current("Nombre"), BinSrc.Current("NIF"), BinSrc.Current("Telefono1"), ContadorMinimo, GL_CodigoUsuario)

            '    Dim dt As DataTable
            '    Dim dr As DataRow
            '    dt = bd.ds.Tables(TablaMantenimiento)
            '    dr = dt.Rows(bd.ds.Tables(TablaMantenimiento).Rows.Count - 1)

            '    If BinSrc.Current("Nombre") = dr("Nombre") And (dr("Contador") Is DBNull.Value OrElse dr("Contador") = 0) Then
            '        Dim bdMarcaTiempo As New BaseDatos
            '        'Dim MarcaDeTiempo As Byte() = bdMarcaTiempo.Execute("SELECT MarcaDeTiempo FROM " & TablaMantenimiento & " WHERE Contador = " & NuevoContador, False)

            '        dr.BeginEdit()
            '        dr("Contador") = NuevoContador
            '        'dr("MarcaDeTiempo") = MarcaDeTiempo
            '        dr.EndEdit()
            '        bd.ds.AcceptChanges()
            '    End If



            '    CargandoClientes = False
            'End If



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

    Private Sub Gv_DoubleClick(sender As System.Object, e As EventArgs) Handles Gv.DoubleClick
        Dim pt As Point = dgvxCitas.PointToClient(Control.MousePosition)
        Dim info As Views.Grid.ViewInfo.GridHitInfo = Gv.CalcHitInfo(pt)
        If info.InRow OrElse info.InRowCell Then
            'info.RowHandle
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            If vengoDe = GL_VENGO_DE_INMUEBLES Then
                CargarFormulario("Clientes", "", True, GL_VENGO_DE_VISITAS, BinSrc.Current("ContadorCliente").ToString)
            Else
                CargarFormulario("Inmuebles", "", True, GL_VENGO_DE_VISITAS, BinSrc.Current("ContadorInmueble").ToString)
            End If
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
        End If
    End Sub
   
End Class