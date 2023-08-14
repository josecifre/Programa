Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid
Imports System
Imports DevExpress.XtraEditors
Imports System.Data
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraBars
Imports DevExpress.LookAndFeel.Design


Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text

    Partial Public Class ucFamilias

    Inherits DevExpress.XtraEditors.XtraUserControl

        Dim AnadiendoOModificando As Boolean = False
        Dim Eliminando As Boolean = False
        Dim menu As DXPopupMenu
        Public PopupMenu As DXPopupMenu

        Public Sub New()
            InitializeComponent()
            DevExpress.Utils.AppearanceObject.DefaultFont = New System.Drawing.Font("Tahoma", 10, System.Drawing.FontStyle.Bold)



            'Me.FabricantesTableAdapter.Fill(Me.DsFabricantes.Fabricantes)
            'Me.AgrupacionesTableAdapter1.Fill(Me.DsFabricantes.Agrupaciones)
            Me.FamiliasTableAdapter.Fill(Me.DsSubFamilias.Familias)
            '  Me.FamiliasTableAdapter.Fill(Me.DsSubFamilias.Familias)

            Me.SubFamiliasTableAdapter.Fill(Me.DsSubFamilias.SubFamilias)
            Me.AgrupacionesTableAdapter.Fill(Me.DsSubFamilias.Agrupaciones)


            'Me.AgrupacionesTableAdapter2.Fill(Me.dsSubFamilias.Agrupaciones)
            'Me.FabricantesTableAdapter1.Fill(dsSubFamilias.Fabricantes)
            'Me.GamasTableAdapter1.Fill(Me.dsSubFamilias.Gamas)
            ''      Me.AgrupacionesTableAdapter.Fill(Me.DsAgrupacionesGamas.Agrupaciones)


            ParametrizarGrid(GvSubFamilias)
            ParametrizarGrid(GvFamilias)


            HabilitarBotonesSubFamilias()
            HabilitarBotonesFamilias()

            

        End Sub


 


#Region "Mantenimiento SubFamilias"

        Private Sub GvSubFamilias_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GvSubFamilias.InitNewRow

            Dim view As GridView = CType(sender, GridView)

            view.SetRowCellValue(e.RowHandle, view.Columns("Agrupacion"), "")
            '   view.SetRowCellValue(e.RowHandle, view.Columns("Predeterminado"), False)

        End Sub
        Private Sub btnAnadirSubFamilias_Click(sender As System.Object, e As System.EventArgs) Handles btnAnadirSubFamilias.Click
            AnadirSubFamilias()
        End Sub
        Private Sub btnEliminarSubFamilias_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarSubFamilias.Click
            EliminarSubFamilias()
        End Sub

        Private Sub btnModificarSubFamilias_Click(sender As System.Object, e As System.EventArgs) Handles btnModificarSubFamilias.Click
            ModificarSubFamilias()
        End Sub
        Private Sub AnadirSubFamilias()

            GvSubFamilias.AddNewRow()

            GvSubFamilias.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
            GvSubFamilias.OptionsBehavior.Editable = True
            GvSubFamilias.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom

            DesHabilitarBotonesSubFamilias()
            GvSubFamilias.FocusedColumn = GvSubFamilias.Columns("SubFamilia")
            GvSubFamilias.ShowEditor()
            AnadiendoOModificando = True

        End Sub
        Private Sub ModificarSubFamilias(Optional PonermeEnLaPrimeraColumna As Boolean = True)
            GvSubFamilias.OptionsBehavior.Editable = True
            DesHabilitarBotonesSubFamilias()
            If PonermeEnLaPrimeraColumna Then
                GvSubFamilias.FocusedColumn = GvSubFamilias.Columns("SubFamilia")
                'Else
                '    GvSubFamilias.FocusedColumn = GvSubFamilias.Columns(GvSubFamilias.FocusedColumn.FieldName)
            End If
            GvSubFamilias.ShowEditor()
            '    dgvxSubFamilias.Focus()
            AnadiendoOModificando = True

        End Sub
        Private Sub EliminarSubFamilias()
            If XtraMessageBox.Show("¿Confirma que quiere eliminar el registro seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
                Exit Sub
            End If
            Eliminando = True
            Dim FilaSeleccionada As Integer = GvSubFamilias.FocusedRowHandle
            GvSubFamilias.DeleteRow(GvSubFamilias.FocusedRowHandle)
            If ActualizarSubFamilias() Then
                If FilaSeleccionada > 1 Then
                    GvSubFamilias.FocusedRowHandle = FilaSeleccionada - 1
                Else
                    Try
                        GvSubFamilias.FocusedRowHandle = FilaSeleccionada + 1
                    Catch ex As Exception

                    End Try
                End If
            End If

            Eliminando = False
        End Sub
        Private Sub AceptarSubFamilias()
            '  Dim FilaSeleccionada As Integer = GvSubFamilias.FocusedRowHandle
            ActualizarSubFamilias()
            '   GvSubFamilias.FocusedRowHandle = FilaSeleccionada
        End Sub
        Private Sub btnAceptarSubFamilias_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptarSubFamilias.Click
            'AceptarSubFamilias()
            HabilitarBotonesSubFamilias()
        End Sub

        Private Sub GvSubFamilias_RowUpdated(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles GvSubFamilias.RowUpdated
            AnadiendoOModificando = True
            ActualizarSubFamilias()

        End Sub




        Private Function ActualizarSubFamilias() As Boolean

            Try
                Dim ValorClaveAntes As Object = GvSubFamilias.GetFocusedRowCellValue("SubFamilia")
                Me.SubFamiliasTableAdapter.Update(DsSubFamilias)
                DsSubFamilias.AcceptChanges()
                Me.SubFamiliasTableAdapter.Fill(Me.DsSubFamilias.SubFamilias)
                If Not Eliminando AndAlso ValorClaveAntes IsNot Nothing Then
                    SituarseEnGrid(GvSubFamilias, ValorClaveAntes.ToString, "SubFamilia")
                End If
                HabilitarBotonesSubFamilias()
                Return True

            Catch ex As SqlClient.SqlException

                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                DsSubFamilias.RejectChanges()
                DsSubFamilias.AcceptChanges()
                Return False

            End Try


        End Function

        Private Sub dgvxSubFamilias_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvxSubFamilias.DoubleClick
            ModificarSubFamilias(False)
        End Sub

        Private Sub dgvxSubFamilias_EditorKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvxSubFamilias.EditorKeyDown

            'If (e.KeyCode = Keys.Decimal Or e.KeyCode = Keys.OemPeriod) AndAlso (GvSubFamilias.FocusedColumn.FieldName = "IVA" Or GvSubFamilias.FocusedColumn.FieldName = "RE") Then
            '    e.SuppressKeyPress = True
            '    SendKeys.Send(",")
            'End If

            If e.KeyCode = Keys.Escape Then
                GvSubFamilias.CancelUpdateCurrentRow()
                HabilitarBotonesSubFamilias()
            End If
        End Sub
        Private Sub dgvxSubFamilias_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvxSubFamilias.KeyDown
            If e.KeyCode = Keys.Escape Then
                Try
                    GvSubFamilias.CancelUpdateCurrentRow()
                Catch ex As Exception
                End Try

                HabilitarBotonesSubFamilias()
            End If

            If e.KeyCode = Keys.F1 Then
                AnadirSubFamilias()
                Exit Sub
            End If

            If e.KeyCode = Keys.F2 Then
                EliminarSubFamilias()
                Exit Sub
            End If

            If e.KeyCode = Keys.F3 Then
                ModificarSubFamilias(False)
                Exit Sub
            End If

            If e.KeyCode = Keys.F12 Then
                AceptarSubFamilias()
                Exit Sub
            End If
        End Sub
        Private Sub GvSubFamilias_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GvSubFamilias.FocusedRowChanged

            If AnadiendoOModificando Then
                HabilitarBotonesSubFamilias()
            End If



        End Sub



        Private Sub HabilitarBotonesSubFamilias()

            GvSubFamilias.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
            GvSubFamilias.OptionsBehavior.Editable = False

            btnAnadirSubFamilias.Enabled = True
            btnModificarSubFamilias.Enabled = False
            btnEliminarSubFamilias.Enabled = False
            If DsSubFamilias.SubFamilias.Rows.Count > 0 Then
                btnModificarSubFamilias.Enabled = True
                btnEliminarSubFamilias.Enabled = True
            End If

            btnAceptarSubFamilias.Enabled = False
            GvSubFamilias.OptionsView.NewItemRowPosition = NewItemRowPosition.None

            AnadiendoOModificando = False

        End Sub

        Private Sub DesHabilitarBotonesSubFamilias()
            btnAnadirSubFamilias.Enabled = False
            btnModificarSubFamilias.Enabled = False
            btnEliminarSubFamilias.Enabled = False
            btnAceptarSubFamilias.Enabled = True
        End Sub

#End Region

#Region "Mantenimiento Familias"



        Private Sub GvFamilias_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GvFamilias.InitNewRow

            Dim view As GridView = CType(sender, GridView)

 
            view.SetRowCellValue(e.RowHandle, view.Columns("Agrupacion"), "")
            '   view.SetRowCellValue(e.RowHandle, view.Columns("Predeterminado"), False)

        End Sub
        Private Sub btnAnadirFamilias_Click(sender As System.Object, e As System.EventArgs) Handles btnAnadirFamilias.Click
            AnadirFamilias()
        End Sub
        Private Sub btnEliminarFamilias_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarFamilias.Click
            EliminarFamilias()
        End Sub

        Private Sub btnModificarFamilias_Click(sender As System.Object, e As System.EventArgs) Handles btnModificarFamilias.Click
            ModificarFamilias()
        End Sub
        Private Sub AnadirFamilias()

            GvFamilias.AddNewRow()

            GvFamilias.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
            GvFamilias.OptionsBehavior.Editable = True
            GvFamilias.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom

            DesHabilitarBotonesFamilias()
            GvFamilias.FocusedColumn = GvFamilias.Columns("Familia")
            GvFamilias.ShowEditor()
            AnadiendoOModificando = True

        End Sub
        Private Sub ModificarFamilias(Optional PonermeEnLaPrimeraColumna As Boolean = True)
            GvFamilias.OptionsBehavior.Editable = True
            DesHabilitarBotonesFamilias()
            If PonermeEnLaPrimeraColumna Then
                GvFamilias.FocusedColumn = GvFamilias.Columns("Familia")
                'Else
                '    GvFamilias.FocusedColumn = GvFamilias.Columns(GvFamilias.FocusedColumn.FieldName)
            End If
            GvFamilias.ShowEditor()
            '    dgvxFamilias.Focus()
            AnadiendoOModificando = True

        End Sub
        Private Sub EliminarFamilias()
            If XtraMessageBox.Show("¿Confirma que quiere eliminar el registro seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
                Exit Sub
            End If
            Eliminando = True
            Dim FilaSeleccionada As Integer = GvFamilias.FocusedRowHandle
            GvFamilias.DeleteRow(GvFamilias.FocusedRowHandle)
            If ActualizarFamilias() Then
                If FilaSeleccionada > 1 Then
                    GvFamilias.FocusedRowHandle = FilaSeleccionada - 1
                Else
                    Try
                        GvFamilias.FocusedRowHandle = FilaSeleccionada + 1
                    Catch ex As Exception

                    End Try
                End If
            End If

            Eliminando = False
        End Sub
        Private Sub AceptarFamilias()
            '  Dim FilaSeleccionada As Integer = GvFamilias.FocusedRowHandle
            ActualizarFamilias()
            '   GvFamilias.FocusedRowHandle = FilaSeleccionada
        End Sub
        Private Sub btnAceptarFamilias_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptarFamilias.Click
            'AceptarFamilias()
            HabilitarBotonesFamilias()
        End Sub

        Private Sub GvFamilias_RowUpdated(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles GvFamilias.RowUpdated
            AnadiendoOModificando = True
            ActualizarFamilias()

        End Sub




        Private Function ActualizarFamilias() As Boolean

            Try
                Dim ValorClaveAntes As Object = GvFamilias.GetFocusedRowCellValue("Familia")
                Me.FamiliasTableAdapter.Update(dsSubFamilias)
                dsSubFamilias.AcceptChanges()
                Me.FamiliasTableAdapter.Fill(Me.dsSubFamilias.Familias)
                If Not Eliminando AndAlso ValorClaveAntes IsNot Nothing Then
                    SituarseEnGrid(GvFamilias, ValorClaveAntes.ToString, "Familia")
                End If
                HabilitarBotonesFamilias()
                Return True

            Catch ex As SqlClient.SqlException

                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dsSubFamilias.RejectChanges()
                dsSubFamilias.AcceptChanges()
                Return False

            End Try


        End Function

        Private Sub dgvxFamilias_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvxFamilias.DoubleClick
            ModificarFamilias(False)
        End Sub

        Private Sub dgvxFamilias_EditorKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvxFamilias.EditorKeyDown

            If (e.KeyCode = Keys.Decimal Or e.KeyCode = Keys.OemPeriod) AndAlso (GvFamilias.FocusedColumn.FieldName = "NumeroVencimientos" Or GvFamilias.FocusedColumn.FieldName = "DiasPrimerVencimiento" Or GvFamilias.FocusedColumn.FieldName = "DiasEntreVencimiento") Then
                e.SuppressKeyPress = True
                '   SendKeys.Send(",")
            End If

            If e.KeyCode = Keys.Escape Then
                GvFamilias.CancelUpdateCurrentRow()
                HabilitarBotonesFamilias()
            End If
        End Sub
        Private Sub dgvxFamilias_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvxFamilias.KeyDown
            If e.KeyCode = Keys.Escape Then
                Try
                    GvFamilias.CancelUpdateCurrentRow()
                Catch ex As Exception
                End Try

                HabilitarBotonesFamilias()
            End If

            If e.KeyCode = Keys.F1 Then
                AnadirFamilias()
                Exit Sub
            End If

            If e.KeyCode = Keys.F2 Then
                EliminarFamilias()
                Exit Sub
            End If

            If e.KeyCode = Keys.F3 Then
                ModificarFamilias(False)
                Exit Sub
            End If

            If e.KeyCode = Keys.F12 Then
                AceptarFamilias()
                Exit Sub
            End If
        End Sub
        Private Sub GvFamilias_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GvFamilias.FocusedRowChanged

            If AnadiendoOModificando Then
                HabilitarBotonesFamilias()
            End If



        End Sub




        Private Sub HabilitarBotonesFamilias()

            GvFamilias.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
            GvFamilias.OptionsBehavior.Editable = False

            btnAnadirFamilias.Enabled = True
            btnModificarFamilias.Enabled = False
            btnEliminarFamilias.Enabled = False
            If dsSubFamilias.Familias.Rows.Count > 0 Then
                btnModificarFamilias.Enabled = True
                btnEliminarFamilias.Enabled = True
            End If

            btnAceptarFamilias.Enabled = False
            GvFamilias.OptionsView.NewItemRowPosition = NewItemRowPosition.None

            AnadiendoOModificando = False

        End Sub

        Private Sub DesHabilitarBotonesFamilias()
            btnAnadirFamilias.Enabled = False
            btnModificarFamilias.Enabled = False
            btnEliminarFamilias.Enabled = False
            btnAceptarFamilias.Enabled = True
        End Sub

#End Region









    End Class
