Imports DevExpress.XtraEditors

Public Class ucComercialesClientes


    Dim CodigoCliente As String
    Dim CodigoEmpleado As Integer

    Public Sub New()
        InitializeComponent()

    End Sub


    Public Sub LlenarGrid(p_CodigoCliente As String, p_CodigoEmpleado As Integer, Todos As Integer)

        CodigoCliente = p_CodigoCliente
        CodigoEmpleado = p_CodigoEmpleado

        Dim Tabla As String = "ComercialesAsociados2"
        Dim Sel As String

        Sel = "EXEC sp_ComercialesAsociados '" & CodigoCliente & "', " & CodigoEmpleado & ", " & Todos
        Dim bd As New BaseDatos
        bd.LlenarDataSet(Sel, Tabla, , False)

        Dim col As New DataColumn
        col = New DataColumn
        With col
            .DataType = System.Type.GetType("System.Boolean")
            .ColumnName = "Marca"
            .Caption = "Marcar"

        End With

        bd.ds.Tables(Tabla).Columns.Add(col)

        For i = 0 To bd.ds.Tables(Tabla).Rows.Count - 1
            bd.ds.Tables(Tabla).Rows(i)("Marca") = bd.ds.Tables(Tabla).Rows(i)("Marcar")
        Next


        col = New DataColumn
        With col
            .DataType = System.Type.GetType("System.Boolean")
            .ColumnName = "Principa"
            .Caption = "Principal"
        End With
        bd.ds.Tables(Tabla).Columns.Add(col)
        For i = 0 To bd.ds.Tables(Tabla).Rows.Count - 1
            bd.ds.Tables(Tabla).Rows(i)("Principa") = bd.ds.Tables(Tabla).Rows(i)("Principal")
        Next

        dgvx.DataSource = bd.ds.Tables(Tabla)

        ParametrizarGrid(Gv, False)

        Gv.Columns("Marcar").Visible = False
        Gv.Columns("Codigo").Visible = False
        Gv.Columns("Principal").Visible = False
        Gv.Columns("Principa").Visible = True

        Gv.Columns("Nombre").OptionsColumn.AllowEdit = False
        Gv.Columns("Principal").OptionsColumn.AllowEdit = False
        Gv.Columns("Codigo").OptionsColumn.AllowEdit = False
        Gv.Columns("Marcar").OptionsColumn.AllowEdit = False

        If Todos = 1 Then
            Gv.Columns("Marca").Visible = True
            Gv.OptionsBehavior.Editable = True
            Gv.Columns("Principa").OptionsColumn.AllowEdit = True
            Gv.Columns("Marca").OptionsColumn.AllowEdit = True


        Else
            Gv.Columns("Marca").Visible = False
            Gv.OptionsBehavior.Editable = False
            Gv.Columns("Principa").OptionsColumn.AllowEdit = False
            Gv.Columns("Marca").OptionsColumn.AllowEdit = False
        End If

         

        Gv.BestFitColumns()
        Gv.OptionsView.ShowGroupPanel = False
        Gv.OptionsView.ShowAutoFilterRow = False
        Gv.OptionsView.ColumnAutoWidth = True

        'Gv.Columns("Nombre").Width = dgvx.Width
        'Gv.Columns("Principal").Width = 60
        'Gv.Columns("Codigo").Width = 60
        'Gv.Columns("Marcar").Width = 60

        dgvx.Width = Me.Width

        dgvx.Height = Me.Height - PanelBotones.Height - PanelControl2.Height
        PanelBotones.Width = Me.Width

        ' Gv.OptionsView.ColumnAutoWidth = True
    End Sub


    Private Sub btnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        LlenarGrid(CodigoCliente, CodigoEmpleado, 1)
        HabilitarDesHabilitarBotonesAceptar(True)
    End Sub


    Private Sub HabilitarDesHabilitarBotonesAceptar(Habilitar As Boolean)
        btnAceptar.Enabled = Habilitar
        btnCancelar.Enabled = Habilitar
        btnModificar.Enabled = Not Habilitar
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click

        Dim Principal As Boolean

        Dim CuentaPrincipales As Integer = 0
        Dim CuentaMarcados As Integer = 0
        Dim BuscoPorCliente As Boolean

        If CodigoCliente <> "" Then
            BuscoPorCliente = True
        Else
            BuscoPorCliente = False
        End If

        If BuscoPorCliente Then
            For i = 0 To Gv.RowCount - 1
                If Gv.GetRowCellValue(i, "Marca") = True And Gv.GetRowCellValue(i, "Principa") = True Then
                    CuentaPrincipales = CuentaPrincipales + 1
                    If CuentaPrincipales > 1 Then
                        MensajeError("Un cliente no puede tener 2 empleados marcado como principales")
                        Return
                    End If
                End If
            Next

            If CuentaPrincipales = 0 Then
                For i = 0 To Gv.RowCount - 1
                    If Gv.GetRowCellValue(i, "Marca") = True Then
                        CuentaMarcados = CuentaMarcados + 1
                    End If
                Next
                If CuentaMarcados > 1 Then
                    If XtraMessageBox.Show("¿Confirma que quiere dejar el cliente sin Comercial principal?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
                        Exit Sub
                    End If

                End If
            End If


        End If





        'Borrar todo

        ConsultasBaseDatos.EliminarTodosLosComercialesCliente(CodigoCliente, CodigoEmpleado)

        For i = 0 To Gv.RowCount - 1

            If BuscoPorCliente Then

                If Gv.GetRowCellValue(i, "Marca") = True Then
                    Principal = Gv.GetRowCellValue(i, "Principa")
                    CodigoEmpleado = Gv.GetRowCellValue(i, "Codigo")
                    ConsultasBaseDatos.InsertarComercialesCliente(CodigoCliente, CodigoEmpleado, Principal)
                    'inserter
                End If
            Else

                If Gv.GetRowCellValue(i, "Marca") = True Then
                    Principal = Gv.GetRowCellValue(i, "Principa")
                    CodigoCliente = Gv.GetRowCellValue(i, "Codigo")
                    ConsultasBaseDatos.InsertarComercialesCliente(CodigoCliente, CodigoEmpleado, Principal)
                    'inserter
                End If

            End If




        Next
        If BuscoPorCliente Then
            CodigoEmpleado = 0
        Else
            CodigoCliente = ""
        End If
        LlenarGrid(CodigoCliente, CodigoEmpleado, 0)
        HabilitarDesHabilitarBotonesAceptar(False)

        If CodigoCliente <> "" Then
            Try
                UClienteActivo.LlenarGrid()
            Catch ex As Exception

            End Try
        End If



    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click

        LlenarGrid(CodigoCliente, CodigoEmpleado, 0)
        HabilitarDesHabilitarBotonesAceptar(False)
    End Sub


    'Private Sub MyGridView1_RowUpdated(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles Gv.RowUpdated

    '    If Gv.RowCount = 1 Then
    '        If e.Row("Principa") = False Then
    '            e.Row("Principa") = True
    '        End If
    '    End If



    'End Sub
End Class
