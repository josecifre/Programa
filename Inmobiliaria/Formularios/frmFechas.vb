Public Class frmFechas 

    Private Sub frmFechas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        AparienciaGeneral()

        GL_EmpleadosSeleccionados = ""
        GL_FechaInicio = ""
        GL_FechaFin = ""
        Dim Primer As Date
        Dim Ultimo As Date

        Primer = DateSerial(Year(Today), Month(Today), 1)
        Ultimo = DateSerial(Year(Today), Month(Today) + 1, 0)

        mskFechaDesde.DateTime = Primer
        mskFechaHasta.DateTime = Ultimo

        Dim Sel As String
        Sel = "SELECT Nombre, Contador FROM Empleados ORDER BY Nombre"
        Dim bd As New BaseDatos
        bd.LlenarDataSet(Sel, "Emp")

        dgvx.DataSource = bd.ds
        dgvx.DataMember = "Emp"

        dgvx.tb_AnadirColumnaCheck = True

        ParametrizarGrid(Gv)

        Gv.Columns("Contador").Visible = False

        dgvx.ColumnaCheck.SelectAll()

        Funciones.LlenarCombo(cmbComoConociste, "ComoConociste", "ComoConociste", "ComoConociste", , , "SELECT ComoConociste FROM ComoConociste ORDER BY ComoConociste", , , , False)
    End Sub

    Private Sub btnMesAnterior_Click(sender As System.Object, e As System.EventArgs) Handles btnMesAnterior.Click
        Dim Primer As Date
        Dim Ultimo As Date
        Primer = DateSerial(Year(mskFechaDesde.Text), Month(mskFechaDesde.Text) - 1, 1)
        Ultimo = DateSerial(Year(mskFechaDesde.Text), Month(mskFechaDesde.Text) + 0, 0)

        mskFechaDesde.DateTime = Primer
        mskFechaHasta.DateTime = Ultimo
    End Sub

    Private Sub btnMesSiguiente_Click(sender As System.Object, e As System.EventArgs) Handles btnMesSiguiente.Click
        Dim Primer As Date
        Dim Ultimo As Date
        Primer = DateSerial(Year(mskFechaDesde.Text), Month(mskFechaDesde.Text) + 1, 1)
        Ultimo = DateSerial(Year(mskFechaDesde.Text), Month(mskFechaDesde.Text) + 2, 0)
        mskFechaDesde.DateTime = Primer
        mskFechaHasta.DateTime = Ultimo
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        GL_FechaFin = ""
        GL_FechaInicio = ""
        Me.Dispose()
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        GL_FechaFin = mskFechaHasta.EditValue
        GL_FechaInicio = mskFechaDesde.EditValue

        If dgvx.Visible Then
            Dim Cont As Integer
            For i As Integer = 0 To dgvx.ColumnaCheck.SelectedCount - 1
                Cont = dgvx.ColumnaCheck.GetSelectedRow(i)("Contador")
                If GL_EmpleadosSeleccionados = "" Then
                    GL_EmpleadosSeleccionados = Cont
                Else
                    GL_EmpleadosSeleccionados = GL_EmpleadosSeleccionados & ", " & Cont
                End If
            Next

            If GL_EmpleadosSeleccionados <> "" Then
                GL_EmpleadosSeleccionados = "(" & GL_EmpleadosSeleccionados & ")"
            End If
        End If
        If panelComoConociste.Visible Then
            GL_ComoConociste = IIf(chkAgrupar.Checked, "1", "0") & "|" & cmbComoConociste.EditValue
        End If
        Me.Dispose()
    End Sub
End Class