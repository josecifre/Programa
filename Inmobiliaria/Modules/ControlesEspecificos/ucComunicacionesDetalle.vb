Imports DevExpress.XtraGrid

Namespace Venalia


    Public Class ucComunicacionesDetalle

        Dim EstoyViendoTodo As Boolean
        Dim ContaClientePropietario As Integer
        Dim BackColorInicialGrid As System.Drawing.Color
        Dim ForeColorInicialGrid As System.Drawing.Color
        Dim TablaFinal As String
        Dim TablaInicial As String
        Dim ContadorInmueble As Integer

        Dim PubContadorClientePropietario As Integer
        Dim PubTabla As String
        Dim PubContaInmueble As Integer
        Dim SoloRef As Boolean = False

        Public Sub New()
            InitializeComponent()
            PrimeraVez = True
            btnSoloLlamadas.ForeColor = GL_ColorTextoBotones
            btnSoloLlamadas.Text = "Ver Todo"
            EstoyViendoTodo = False
            Gv.OptionsView.ShowGroupPanel = False
            Gv.OptionsView.ShowAutoFilterRow = False

            PanelTitulo.Visible = False
           

        End Sub

        Private PrimeraVez As Boolean


        Public Sub LlenarGrid(ContadorClientePropietario As Integer, Tabla As String, ContaInmueble As Integer)


            PubContadorClientePropietario = ContadorClientePropietario
            PubTabla = Tabla
            PubContaInmueble = ContaInmueble
          

            Dim Sel As String = ""

            TablaInicial = Tabla

            ContadorInmueble = ContaInmueble

            If ContaInmueble <> 0 Then
                Dim Ref As String
                Sel = "SELECT Referencia FROM Inmuebles WHERE Contador = " & ContadorInmueble
                Ref = BD_CERO.Execute(Sel, False, "")
                btnRef.Text = "Ref. " & Ref
                btnRef.Visible = True
            Else
                '  btnRef.Visible = False
                btnRef.Text = "Generales"

            End If

            BackColorInicialGrid = Gv.Appearance.SelectedRow.BackColor
            ForeColorInicialGrid = Gv.Appearance.SelectedRow.ForeColor


            ContaClientePropietario = ContadorClientePropietario
            TablaFinal = "Comunicaciones" & Tabla


            Dim WhereTipo As String = ""
            Dim TablaDondeBuscar As String = Tabla & "Comunicaciones"
            Dim ContadorTablaDondeBuscar As String = ""

            'If ContadorInmueble = 0 Then
            '    If Not EstoyViendoTodo And Tabla <> GL_TablaPropietarios Then
            '        WhereTipo = " AND ContadorInmueble = " & ContadorInmueble
            '    End If
            'Else
            '    WhereTipo = " AND ContadorInmueble = " & ContadorInmueble
            'End If

            If SoloRef Then
                WhereTipo = " AND ContadorInmueble = " & ContadorInmueble
            End If


            If Tabla = GL_TablaPropietarios Then
                btnSoloLlamadas.Visible = False
            End If

            Select Case Tabla
                Case GL_TablaClientes
                    ContadorTablaDondeBuscar = "ContadorCliente"
                Case GL_TablaPropietarios
                    ContadorTablaDondeBuscar = "ContadorPropietario"
            End Select


            Sel = "SELECT Tipo, Fecha, ContadorInmueble," & _
                    Funciones.SQL_CASE_ISNULL("(SELECT     Referencia  FROM Inmuebles  WHERE Contador = C.ContadorInmueble), ''") & " AS Referencia, ContadorEmpleado, " & ContadorTablaDondeBuscar & " AS ContadorClientePropietarioInmueble, " & _
                    "Contador ,(SELECT     Nombre   FROM         Empleados AS E  WHERE      Contador = C.ContadorEmpleado) AS Comercial, LlamadaContestada," & _
                    "  Observaciones " & _
                    " FROM " & TablaDondeBuscar & " C WHERE " & ContadorTablaDondeBuscar & " = " & ContadorClientePropietario & WhereTipo & " ORDER BY Fecha DESC "





            Dim bd As New BaseDatos
            bd.LlenarDataSet(Sel, Tabla)


            dgvx.DataSource = bd.ds.Tables(Tabla)

            '  ParametrizarGrid(Gv)

            If Not IsNothing(Gv.Columns("ContadorLlamada")) Then
                Gv.Columns("ContadorLlamada").Visible = False
                Gv.Columns("ContadorLlamada").OptionsColumn.AllowShowHide = False
            End If

            If Not IsNothing(Gv.Columns("ContadorClientePropietarioInmueble")) Then
                Gv.Columns("ContadorClientePropietarioInmueble").Visible = False
                Gv.Columns("ContadorClientePropietarioInmueble").OptionsColumn.AllowShowHide = False
            End If

            If PrimeraVez Then



                ParametrizarGrid(Gv)

                'Gv.OptionsView.ShowGroupPanel = False
                'Gv.OptionsView.ShowAutoFilterRow = False

                Gv.BestFitColumns()
                Gv.OptionsView.ColumnAutoWidth = False

                Gv.Columns("Fecha").Width = 100

                'Gv.OptionsView.ShowGroupPanel = True
                'Gv.OptionsView.ShowAutoFilterRow = True


                Gv.Columns("Contador").Visible = False
                Gv.Columns("Contador").OptionsColumn.AllowShowHide = False

                Gv.Columns("ContadorEmpleado").Visible = False
                Gv.Columns("ContadorEmpleado").OptionsColumn.AllowShowHide = False

                Gv.Columns("ContadorInmueble").Visible = False
                Gv.Columns("ContadorInmueble").OptionsColumn.AllowShowHide = False

                Gv.Columns("LlamadaContestada").Visible = False
                Gv.Columns("LlamadaContestada").OptionsColumn.AllowShowHide = False

                Gv.Columns("Fecha").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                Gv.Columns("Fecha").DisplayFormat.FormatString = "dd/MM/yy HH:mm"

                Dim condition1 As StyleFormatCondition

                condition1 = New DevExpress.XtraGrid.StyleFormatCondition()
                condition1.Appearance.ForeColor = GL_ColorLlamada
                condition1.Appearance.Options.UseForeColor = True

                condition1.Condition = FormatConditionEnum.Expression
                condition1.Expression = "Tipo = 'Llamada'  AND LlamadaContestada = 0"
                Gv.FormatConditions.Add(condition1)

                'Falta totales
                Dim ItemArticulo As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                ItemArticulo.FieldName = "Contador"
                ItemArticulo.DisplayFormat = "Total: {0:n0}"
                ItemArticulo.SummaryType = DevExpress.Data.SummaryItemType.Count
                Gv.GroupSummary.Add(ItemArticulo)
                '  If dgvx.Width > Me.Width Then
                dgvx.Width = Me.Width
                '  End If
            End If

            Gv.BestFitColumns()

            FocusedColor()


            If PrimeraVez Then
                PrimeraVez = False
            End If


            Funciones.SetSelectionAppearance(Gv, False)
        End Sub


        Private Sub btnSoloLlamadas_Click(sender As System.Object, e As System.EventArgs) Handles btnSoloLlamadas.Click

            If ContaClientePropietario = 0 Then
                MensajeInformacion("Debe seleccionar un registro")
                Exit Sub
            End If

            If EstoyViendoTodo Then
                btnSoloLlamadas.Text = "Ver Todo"
            Else
                btnSoloLlamadas.Text = "Ver Solo Principales"
            End If
            EstoyViendoTodo = Not EstoyViendoTodo
            LlenarGrid(ContaClientePropietario, TablaInicial, ContadorInmueble)
        End Sub
        Private Sub Gv_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles Gv.FocusedRowChanged

            Try
                FocusedColor()
            Catch ex As Exception

            End Try

        End Sub
        Private Sub FocusedColor()
            Dim a As DataRowView = Gv.GetFocusedRow
            With Gv.Appearance.FocusedRow

                Try
                    If a.Item("LlamadaContestada") = False And a.Item("Tipo") = "Llamada" Then
                        .BackColor = GL_ColorLlamada
                        .ForeColor = Color.White
                      
                    Else
                        .BackColor = BackColorInicialGrid
                        .ForeColor = ForeColorInicialGrid
                    End If



                Catch
                End Try
                Gv.Appearance.HideSelectionRow.BackColor = Gv.Appearance.FocusedRow.BackColor
                Gv.Appearance.HideSelectionRow.ForeColor = Gv.Appearance.FocusedRow.ForeColor

                'Try
                '    With Gv.Appearance.HideSelectionRow
                '        .BackColor = Color.White
                '        ' .ForeColor = Color.White
                '    End With
                'Catch ex As Exception

                'End Try
                
                
            End With
 
          

            'Try
            '    If a.Item("LlamadaContestada") = False And a.Item("Tipo") = "Llamada" Then
            '        .BackColor = GL_ColorLlamada
            '        .ForeColor = Color.White
            '    Else
            '        .BackColor = BackColorInicialGrid
            '        .ForeColor = ForeColorInicialGrid
            '    End If

            '    Exit Sub

            'Catch
            'End Try


            'End With

        End Sub
        Private Sub ModificarOBservacionesLlamada()
 

            Dim a As DataRowView = Gv.GetFocusedRow

            If IsNothing(a) Then
                Exit Sub
            End If

            'If a.Item("Tipo").ToString.ToUpper <> "LLAMADA" Then
            '    MensajeInformacion("Solo se puede modificar las observaciones de las llamadas.")
            '    Exit Sub
            'End If

            'If a.Item("Fecha") < #4/1/2014# Then
            '    MensajeInformacion("No se puede modificar las observaciones de llamadas antiguas")
            '    Exit Sub
            'End If

            'If a.Item("LlamadaContestada") = 0 Then
            '    MensajeInformacion("No hay observaciones para llamadas no contestadas")
            '    Exit Sub
            'End If
            Dim QuienMeLLama As String = Me.ParentForm.Text
            LlamadaObservaciones("MODIFICAR_OBSERVACIONES_LLAMADA", QuienMeLLama, a.Item("Contador"))

            LlenarGrid(ContaClientePropietario, TablaInicial, ContadorInmueble)
        End Sub
        Private Sub dgvx_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvx.DoubleClick

            ModificarOBservacionesLlamada()

        End Sub

        Private Sub dgvx_Enter(sender As System.Object, e As System.EventArgs) Handles dgvx.Enter
            Funciones.SetSelectionAppearance(Gv, True)
        End Sub
        Private Sub dgvx_Leave(sender As System.Object, e As System.EventArgs) Handles dgvx.Leave
            Funciones.SetSelectionAppearance(Gv, True)
        End Sub

        'Private Sub dgvx_GotFocus(sender As Object, e As System.EventArgs) Handles dgvx.GotFocus
        '    Funciones.SetSelectionAppearance(Gv, True)
        'End Sub

     

        'Private Sub dgvx_LostFocus(sender As Object, e As System.EventArgs) Handles dgvx.LostFocus
        '    Funciones.SetSelectionAppearance(Gv, False)
        'End Sub

       
        'Private Sub Gv_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles Gv.RowStyle

        '    Dim view As MyGridView = TryCast(sender, MyGridView)
        '    If (view.IsRowSelected(e.RowHandle)) Then

        '        Dim Tipo As String
        '        Dim LlamadaContestada As Boolean

        '        Tipo = view.GetDataRow(e.RowHandle).Item("Tipo")
        '        LlamadaContestada = view.GetDataRow(e.RowHandle).Item("LlamadaContestada")

        '        If Tipo = "Llamada" And LlamadaContestada Then

        '            e.Appearance.ForeColor = Color.White
        '            e.Appearance.BackColor = GL_ColorLlamada
        '        Else
        '            e.Appearance.ForeColor = ForeColorInicialGrid
        '            e.Appearance.BackColor = BackColorInicialGrid


        '        End If

        '        '   e.Appearance.Assign(view.PaintAppearance.SelectedRow)

        '        e.HighPriority = True
        '    End If





        'End Sub

    
        Private Sub LlamadaObservaciones(Tipo As String, QuienMeLLama As String, Optional ContadorLLamada As Integer = 0)
            If ContaClientePropietario = 0 Then
                Exit Sub
            End If

            Dim Observaciones As New Tablas.clComunicaciones

            Observaciones.Tipo = Tipo
            Observaciones.Tabla = TablaInicial
            Observaciones.ContadorClientePropietarioInmueble = ContaClientePropietario
            Observaciones.CodigoEmpresa = DatosEmpresa.Codigo
            Observaciones.ContadorEmpleado = GL_CodigoUsuario
            Observaciones.Delegacion = Gl_Delegacion
            Observaciones.Observaciones = GL_Observaciones
            Observaciones.ContadorInmueble = 0

            '    If InmueblesEstaActivo Or AlarmasEstaActivo Or PropietariosEstaActivo Then

            Select Case QuienMeLLama
                Case "Inmuebles"
                    Observaciones.ContadorInmueble = uInmueblesActivo.UcInmueblesPropietario1.BinSrc.Current("Contador")
                    Me.Text = "Observaciones y precios de: " & uInmueblesActivo.UcInmueblesPropietario1.BinSrc.Current("Referencia")
                Case "Alarmas"
                    Observaciones.ContadorInmueble = uAlarmasActivo.BinSrc.Current("Contador")
                Case "Propietarios"
                    Observaciones.ContadorInmueble = uPropietariosActivo.GvInmuebles.GetFocusedDataRow("Contador")
                Case Else
                    QuienMeLLama = ""
            End Select

            Observaciones.QuienMeLlama = QuienMeLLama

            'If InmueblesEstaActivo Then
            '    Observaciones.ContadorInmueble = uInmueblesActivo.UcInmueblesPropietario1.BinSrc.Current("Contador")
            '    Me.Text = "Observaciones y precios de: " & uInmueblesActivo.UcInmueblesPropietario1.BinSrc.Current("Referencia")
            'Else
            '    Observaciones.ContadorInmueble = uAlarmasActivo.BinSrc.Current("Contador")
            'End If
            '   End If


            If ContadorLLamada <> 0 Then
                Observaciones.ContadorLlamada = ContadorLLamada
            End If

            If TablaInicial = GL_TablaClientes Then
                Observaciones.ContadorInmueble = UClienteActivo.ContadorInmuebleDeDondeVengo
            End If

            If ProcesoAnadirObservaciones2(Observaciones) = -1 Then Return

            'ProcesoAnadirObservaciones(False, TablaClientes, BinSrc.Current("Contador"))
            If TablaInicial = GL_TablaPropietarios Then

                If GL_Observaciones <> "" AndAlso GL_Observaciones <> Gl_ResultadoBusqueda_SALIR Then


                    If QuienMeLLama = "Propietarios" Then
                        ''uPropietariosActivo.txtObservaciones.Text = Now & " " & GL_Observaciones & vbCrLf & uPropietariosActivo.txtObservaciones.Text
                        ''If uPropietariosActivo.txtObservaciones.Text.Length > 5000 Then
                        ''    uPropietariosActivo.txtObservaciones.Text = uPropietariosActivo.txtObservaciones.Text.Substring(0, 5000)
                        ''End If
                        ''BD_CERO.Execute("UPDATE Propietarios SET Observaciones= '" & Funciones.pf_ReplaceComillas(uPropietariosActivo.txtObservaciones.Text) & "' WHERE Contador= " & ContaClientePropietario)

                        ''Try
                        ''    If Not IsNothing(uInmueblesActivo) Then
                        ''        If uInmueblesActivo.BinSrc("ContadorPropietario") = ContaClientePropietario Then
                        ''            If uInmueblesActivo.UcInmueblesPropietario1.txtObservaciones.Text.Length > 5000 Then
                        ''                uInmueblesActivo.UcInmueblesPropietario1.txtObservaciones.Text = uInmueblesActivo.UcInmueblesPropietario1.txtObservaciones.Text.Substring(0, 5000)
                        ''            End If
                        ''        End If
                        ''    End If
                        ''Catch ex As Exception

                        ''End Try


                    Else
                        If Not IsNothing(uInmueblesActivo) Then
                            uInmueblesActivo.UcInmueblesPropietario1.txtObservaciones.Text = Now & " " & GL_Observaciones & vbCrLf & uInmueblesActivo.UcInmueblesPropietario1.txtObservaciones.Text
                            If uInmueblesActivo.UcInmueblesPropietario1.txtObservaciones.Text.Length > 5000 Then
                                uInmueblesActivo.UcInmueblesPropietario1.txtObservaciones.Text = uInmueblesActivo.UcInmueblesPropietario1.txtObservaciones.Text.Substring(0, 5000)
                            End If
                            BD_CERO.Execute("UPDATE Propietarios SET Observaciones= '" & Funciones.pf_ReplaceComillas(uInmueblesActivo.UcInmueblesPropietario1.txtObservaciones.Text) & "' WHERE Contador= " & ContaClientePropietario)

                        End If

                    End If

                End If
            Else

                If Not IsNothing(UClienteActivo) Then
                    If GL_Observaciones <> "" AndAlso GL_Observaciones <> Gl_ResultadoBusqueda_SALIR Then
                        UClienteActivo.txtObservaciones.Text = Now & " " & GL_Observaciones & vbCrLf & UClienteActivo.txtObservaciones.Text
                        If UClienteActivo.txtObservaciones.Text.Length > 5000 Then
                            UClienteActivo.txtObservaciones.Text = UClienteActivo.txtObservaciones.Text.Substring(0, 5000)
                        End If
                        BD_CERO.Execute("UPDATE Clientes SET Observaciones= '" & Funciones.pf_ReplaceComillas(UClienteActivo.txtObservaciones.Text) & "' WHERE Contador= " & ContaClientePropietario)
                        'LlenarObservaciones(UClienteActivo.txtObservaciones, ContaClientePropietario, TablaInicial)
                    End If

                    UClienteActivo.RefrescarDatosClientes(Observaciones.ContadorClientePropietarioInmueble)
                End If

            End If
        End Sub
       
      

        Private Sub btnLlamadas_Click(sender As System.Object, e As System.EventArgs) Handles btnLlamadas.Click
            llamada()
        End Sub
        Public Sub llamada()
            If ContaClientePropietario = 0 Then
                MensajeInformacion("Debe seleccionar un registro")
                Exit Sub
            End If

            Dim QuienMeLLama As String = Me.ParentForm.Text

            Select Case QuienMeLLama
                Case GL_TablaInmuebles
                    If uInmueblesActivo.UcInmueblesPropietario1.Gv.RowCount = 0 OrElse uInmueblesActivo.UcInmueblesPropietario1.Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then Return
                Case GL_TablaClientes
                    If UClienteActivo.Gv.RowCount = 0 OrElse UClienteActivo.Gv.FocusedRowHandle = GridControl.AutoFilterRowHandle Then Return
                Case GL_TablaPropietarios
                    If uPropietariosActivo.GvInmuebles.RowCount = 0 OrElse uPropietariosActivo.GvInmuebles.FocusedRowHandle = GridControl.AutoFilterRowHandle Then Return
            End Select

            'If uInmueblesActivo IsNot Nothing Then If uInmueblesActivo.Name.Contains(Me.ParentForm.Name) Then InmueblesEstaActivo = True
            'If UClienteActivo IsNot Nothing Then If UClienteActivo.Name.Contains(Me.ParentForm.Name) Then ClientesEstaActivo = True
            'If uPropietariosActivo IsNot Nothing Then If uPropietariosActivo.Name.Contains(Me.ParentForm.Name) Then PropietariosEstaActivo = True

            LlamadaObservaciones(GL_OBSERVACIONES_LLAMADA, QuienMeLLama)
            LlenarGrid(ContaClientePropietario, TablaInicial, ContadorInmueble)
            If uInmueblesActivo IsNot Nothing Then
                uInmueblesActivo.UcInmueblesPropietario1.ActualizaCambiosPrecio()
                With GL_CambiosPrecios
                    If .Cambio = "SUBE" Then
                        RefrescarDatosDesdeBdInmuebles(True)
                    ElseIf .Cambio = "BAJA" Then
                        RefrescarDatosDesdeBdInmuebles(True)
                    End If
                End With
            End If

            If QuienMeLLama = GL_TablaInmuebles AndAlso uInmueblesActivo IsNot Nothing Then
                uInmueblesActivo.UcInmueblesPropietario1.LlenarGridInmuebles()
            End If

            'If uInmueblesActivo IsNot Nothing Then If uInmueblesActivo.Name.Contains(Me.ParentForm.Name) Then InmueblesEstaActivo = False
            'If UClienteActivo IsNot Nothing Then If UClienteActivo.Name.Contains(Me.ParentForm.Name) Then ClientesEstaActivo = False
        End Sub
 

        Private Sub btnModificarObservacionesLlamada_Click(sender As System.Object, e As System.EventArgs) Handles btnModificarObservacionesLlamada.Click

            If ContaClientePropietario = 0 Then
                MensajeInformacion("Debe seleccionar un registro")
                Exit Sub
            End If


            ModificarOBservacionesLlamada()
        End Sub

     
        Private Sub btnRef_Click(sender As System.Object, e As System.EventArgs) Handles btnRef.Click
            SoloRef = Not SoloRef
            LlenarGrid(PubContadorClientePropietario, PubTabla, PubContaInmueble)
        End Sub
    End Class
End Namespace