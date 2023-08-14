Module FuncionesMantenimiento2
    'Public Enum Accion As Integer
    '    Ocular = 1
    '    Congelar
    'End Enum
    Public Enum OperadoresNumero As Integer
        Igual = 1
        Distinto_Que
        Mayor_Que
        Mayor_O_Igual_Que
        Menor_Que
        Menor_O_Igual_Que
    End Enum

    Public Enum OperadoresCadena As Integer
        Igual = 1
        Distinto_Que
        Comience_Por = 7
        Contenga
        Termine_Por
    End Enum

    Public Enum Filtrado As Integer
        Quitar_Filtro
        Igual
        Distinto_Que
        Mayor_Que
        Mayor_O_Igual_Que
        Menor_Que
        Menor_O_Igual_Que
        Comience_Por
        Contenga
        Termine_Por
    End Enum

    Public Class clFiltrando

        Private Filtro As String

        Public ReadOnly Property Filtrando() As Boolean
            Get
                If Filtro <> "" Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

        Public Function Buscar(ByVal TipoDeFiltro As Integer, ByVal Campo As String, ByVal Valor As String) As String

            If Valor = "" Then
                Return Filtro
            End If

            Dim Sel As String = ""

            Select Case TipoDeFiltro
                Case Filtrado.Igual
                    Sel = Campo & " = '" & Valor & "'"
                Case Filtrado.Distinto_Que
                    Sel = Campo & " <> '" & Valor & "'"
                Case Filtrado.Quitar_Filtro
                    Filtro = ""
                Case Filtrado.Contenga
                    Sel = Campo & " LIKE '%" & Valor & "%'"
                Case Filtrado.Comience_Por
                    Sel = Campo & " LIKE '" & Valor & "%'"
                Case Filtrado.Termine_Por
                    Sel = Campo & " LIKE '%" & Valor & "'"
                Case Filtrado.Mayor_O_Igual_Que
                    Sel = Campo & " >= '" & Valor & "'"
                Case Filtrado.Mayor_Que
                    Sel = Campo & " > '" & Valor & "'"
                Case Filtrado.Menor_O_Igual_Que
                    Sel = Campo & " <= '" & Valor & "'"
                Case Filtrado.Menor_Que
                    Sel = Campo & " < '" & Valor & "'"
            End Select

            If Filtro <> "" Then
                Return Filtro & " AND " & Sel
            Else
                Return Sel
            End If

        End Function

        Public Sub Filtrar(ByVal TipoDeFiltro As Integer, ByRef dgv As DataGridView, ByRef dw As DataView)

            Dim Numerico As Boolean = False

            Try
                Select Case dgv.Columns(dgv.CurrentCell.ColumnIndex).ValueType.Name
                    Case "String", "Date", "DateTime"
                        Numerico = False
                    Case Else
                        Numerico = True
                End Select
            Catch ex As Exception

            End Try


            Try
                If dgv.CurrentCell.Value Is DBNull.Value Then
                    MsgBox("No se puede aplicar el filtro.")
                    Exit Sub
                    Numerico = False
                End If
            Catch ex As Exception

            End Try

            Try

                Dim Sel As String = ""

                Select Case TipoDeFiltro
                    Case Filtrado.Igual
                        If Numerico Then
                            Sel = "[" & dgv.Columns(dgv.CurrentCell.ColumnIndex).Name & "]" & " = " & dgv.CurrentCell.Value
                        Else
                            Sel = "[" & dgv.Columns(dgv.CurrentCell.ColumnIndex).Name & "]" & " = '" & dgv.CurrentCell.Value & "'"
                        End If
                    Case Filtrado.Distinto_Que
                        If Numerico Then
                            Sel = "[" & dgv.Columns(dgv.CurrentCell.ColumnIndex).Name & "]" & " <> " & dgv.CurrentCell.Value
                        Else
                            Sel = "[" & dgv.Columns(dgv.CurrentCell.ColumnIndex).Name & "]" & " <> '" & dgv.CurrentCell.Value & "'"
                        End If
                    Case Filtrado.Quitar_Filtro
                        Filtro = ""
                    Case Filtrado.Contenga
                        If Numerico Then
                            Sel = "[" & dgv.Columns(dgv.CurrentCell.ColumnIndex).Name & "]" & " <> '%" & dgv.CurrentCell.Value & "%'"
                        Else
                            Sel = "[" & dgv.Columns(dgv.CurrentCell.ColumnIndex).Name & "]" & " <> '%" & dgv.CurrentCell.Value & "%'"
                        End If
                    Case Filtrado.Mayor_O_Igual_Que
                        If Numerico Then
                            Sel = "[" & dgv.Columns(dgv.CurrentCell.ColumnIndex).Name & "]" & " >= " & dgv.CurrentCell.Value
                        Else
                            Sel = "[" & dgv.Columns(dgv.CurrentCell.ColumnIndex).Name & "]" & " >= '" & dgv.CurrentCell.Value & "'"
                        End If
                    Case Filtrado.Mayor_Que
                        If Numerico Then
                            Sel = "[" & dgv.Columns(dgv.CurrentCell.ColumnIndex).Name & "]" & " > " & dgv.CurrentCell.Value
                        Else
                            Sel = "[" & dgv.Columns(dgv.CurrentCell.ColumnIndex).Name & "]" & " > '" & dgv.CurrentCell.Value & "'"
                        End If
                    Case Filtrado.Menor_O_Igual_Que
                        If Numerico Then
                            Sel = "[" & dgv.Columns(dgv.CurrentCell.ColumnIndex).Name & "]" & " <= " & dgv.CurrentCell.Value
                        Else
                            Sel = "[" & dgv.Columns(dgv.CurrentCell.ColumnIndex).Name & "]" & " <= '" & dgv.CurrentCell.Value & "'"
                        End If
                    Case Filtrado.Menor_Que
                        If Numerico Then
                            Sel = "[" & dgv.Columns(dgv.CurrentCell.ColumnIndex).Name & "]" & " < " & dgv.CurrentCell.Value
                        Else
                            Sel = "[" & dgv.Columns(dgv.CurrentCell.ColumnIndex).Name & "]" & " < '" & dgv.CurrentCell.Value & "'"
                        End If
                End Select

                If Filtro <> "" Then
                    Filtro = Filtro & " AND " & Sel
                Else
                    Filtro = Sel
                End If
                'dw.RowFilter = "IsDBNull ([1])"
                dw.RowFilter = Filtro

                '		dw.RowFilter = "1 = 40"
            Catch ex As Exception
                MsgBox("No se puede aplicar el filtro." & vbCrLf & ex.Message)

            End Try


        End Sub


    End Class

    Public Class CadenaCadena
        Private myDispMember As String
        Private myValMember As String
        Private myAdicional As String

        Public Sub New(ByVal strDispMember As String, ByVal strValMember As String, Optional ByVal strAdicional As String = "")
            myValMember = strValMember
            myDispMember = strDispMember
            myAdicional = strAdicional
        End Sub 'New

        Public ReadOnly Property ValMember() As String
            Get
                Return myValMember
            End Get
        End Property

        Public ReadOnly Property DispMember() As String
            Get
                Return myDispMember
            End Get
        End Property

        Public ReadOnly Property AdicionalMember() As String
            Get
                Return myAdicional
            End Get
        End Property

    End Class

    Public Class CadenaEntero
        Private myDispMember As String
        Private myValMember As Integer

        Public Sub New(ByVal strDispMember As String, ByVal strValMember As Integer)
            myValMember = strValMember
            myDispMember = strDispMember
        End Sub 'New

        Public ReadOnly Property ValMember() As Integer
            Get
                Return myValMember
            End Get
        End Property

        Public ReadOnly Property DispMember() As String
            Get
                Return myDispMember
            End Get
        End Property

    End Class
    Public Class EnteroEntero
        Private myDispMember As Integer
        Private myValMember As Integer

        Public Sub New(ByVal strDispMember As Integer, ByVal strValMember As Integer)
            myValMember = strValMember
            myDispMember = strDispMember
        End Sub 'New

        Public ReadOnly Property ValMember() As Integer
            Get
                Return myValMember
            End Get
        End Property

        Public ReadOnly Property DispMember() As Integer
            Get
                Return myDispMember
            End Get
        End Property

    End Class
    Public Class EnteroCadena
        Private myDispMember As Integer
        Private myValMember As String

        Public Sub New(ByVal strDispMember As Integer, ByVal strValMember As String)
            myValMember = strValMember
            myDispMember = strDispMember
        End Sub 'New

        Public ReadOnly Property ValMember() As String
            Get
                Return myValMember
            End Get
        End Property

        Public ReadOnly Property DispMember() As Integer
            Get
                Return myDispMember
            End Get
        End Property

    End Class

    Public Sub FormatearDataGrid(ByRef dgv As DataGridView)
        Dim dc As New DataGridViewColumn
        For Each dc In dgv.Columns

            With dc.DefaultCellStyle

                Select Case dc.ValueType.Name

                    Case "Int32", "Int64", "Int16"
                        .NullValue = "0"
                        .Alignment = DataGridViewContentAlignment.MiddleRight
                        .Format = "#,###,###,##0"

                    Case "Decimal", "Double", "Float"
                        .NullValue = "0"
                        .Alignment = DataGridViewContentAlignment.MiddleRight
                        .Format = "#,###,###,##0.#0"

                    Case "String"
                        .NullValue = ""
                        .Alignment = DataGridViewContentAlignment.MiddleLeft

                    Case "Date", "DateTime"
                        .NullValue = ""
                        .Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Format = "dd/MM/yy HH:mm:ss"

                End Select
            End With

            'dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells


        Next

        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
    End Sub
    Public Sub DesHabilitarColumnas(ByRef dgv As DataGridView)
        Dim dc As New DataGridViewColumn
        For Each dc In dgv.Columns
            dc.ReadOnly = True
        Next
    End Sub
    Public Function CargarComboCampos(ByVal TipoCampo As String, ByRef cmbOperador As ComboBox, ByRef txtBusqueda As Object) As Integer

        Dim Nombres() As String
        Dim Valores() As Integer
        Dim DatosOperadores As New List(Of CadenaEntero)
        Dim Indice As Integer


        cmbOperador.DataSource = Nothing

        Select Case TipoCampo

            Case "Int32", "Int64", "Int16", "Decimal", "Double", "Date", "DateTime", "Float"
                Dim OpNum As OperadoresNumero
                Nombres = [Enum].GetNames(OpNum.GetType)
                Valores = [Enum].GetValues(OpNum.GetType)
                txtBusqueda.RightToLeft = Windows.Forms.RightToLeft.Yes
                Indice = 0  'Igual

            Case "String"
                Dim OpNum As OperadoresCadena
                Nombres = [Enum].GetNames(OpNum.GetType)
                Valores = [Enum].GetValues(OpNum.GetType)
                txtBusqueda.RightToLeft = Windows.Forms.RightToLeft.No
                Indice = 3 'Contenga
            Case Else
                Nombres = {""}
                Valores = {""}
        End Select


        For i = 0 To Nombres.Length - 1
            DatosOperadores.Add(New CadenaEntero(Nombres(i), Valores(i)))
        Next

        cmbOperador.DataSource = DatosOperadores
        cmbOperador.DisplayMember = "DispMember"
        'cmbOperador.DisplayMember = "Nombre"
        cmbOperador.ValueMember = "ValMember"

        Return Indice

    End Function
    Public Sub LlenarComboDatosColumnasDevExpress(ByVal cmbCampos As ComboBox, ByVal dgvx As DevExpress.XtraGrid.Views.Grid.GridView)

        Dim DatosColumnas As New List(Of CadenaCadena)
        Dim dc As DevExpress.XtraGrid.Columns.GridColumn

        For Each dc In dgvx.Columns
            If dc.Visible Then
                Select Case dc.ColumnType.Name
                    Case "Int32", "Int64", "Int16", "Decimal", "Double", "Float", "String"
                        DatosColumnas.Add(New CadenaCadena(dc.FieldName, dc.ColumnType.Name))
                End Select
            End If
        Next
        cmbCampos.DataSource = DatosColumnas
        cmbCampos.DisplayMember = "DispMember"
        cmbCampos.ValueMember = "ValMember"
    End Sub

    'Public Sub OcultarCongelarColumnasDevExpress(ByVal Columnas As List(Of String), ByVal Nombres() As String, ByVal dgvx As DevExpress.XtraGrid.Views.Grid.GridView, ByVal AccionAEjecutar As Integer)
    '    If Nombres IsNot Nothing Then
    '        Columnas.AddRange(Nombres)
    '        Dim dc As New DevExpress.XtraGrid.Columns.GridColumn
    '        For Each dc In dgvx.Columns
    '            For Each c As String In Columnas
    '                If c.ToUpper = dc.FieldName.ToUpper Then
    '                    Select Case AccionAEjecutar
    '                        Case Accion.Ocular
    '                            dgvx.Columns(dc.FieldName).Visible = False
    '                        Case Accion.Congelar
    '                            dgvx.Columns(dc.FieldName).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
    '                            ' En congelar solo ponemos una columna
    '                            Exit Sub
    '                    End Select
    '                    Exit For
    '                End If
    '            Next
    '        Next
    '    End If
    'End Sub

    Public Sub LlenarComboDatosColumnas(ByVal cmbCampos As ComboBox, ByVal dgv As DataGridView)
        Dim DatosColumnas As New List(Of CadenaCadena)
        Dim dc As New DataGridViewColumn
        For Each dc In dgv.Columns
            If dc.Visible Then
                Select Case dc.ValueType.Name
                    Case "Int32", "Int64", "Int16", "Decimal", "Double", "Float", "String"
                        DatosColumnas.Add(New CadenaCadena(dc.Name, dc.ValueType.Name, dc.Name))
                End Select
            End If
        Next
        cmbCampos.DataSource = DatosColumnas
        cmbCampos.DisplayMember = "DispMember"
        cmbCampos.ValueMember = "ValMember"
    End Sub
    Public Sub SituarCampoInicialBusqueda(ByVal cmbCampos As ComboBox, ByVal cmbOperador As ComboBox, ByVal txtBusqueda As Object, ByVal CampoInicialBusqueda As String)
        Try
            cmbCampos.SelectedIndex = cmbCampos.FindStringExact(CampoInicialBusqueda)
            If cmbCampos.SelectedIndex > -1 Then
                cmbOperador.SelectedIndex = CargarComboCampos(cmbCampos.SelectedValue, cmbOperador, txtBusqueda)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub OcultarCongelarColumnas(ByVal Columnas As List(Of String), ByVal Nombres() As String, ByVal dgv As DataGridView, ByVal AccionAEjecutar As Integer)
        If Nombres IsNot Nothing Then
            Columnas.AddRange(Nombres)
            Dim dc As New DataGridViewColumn
            For Each dc In dgv.Columns
                For Each c As String In Columnas
                    If c.ToUpper = dc.Name.ToUpper Then
                        Select Case AccionAEjecutar
                            Case Accion.Ocular
                                dgv.Columns(dc.Name).Visible = False
                            Case Accion.Congelar
                                dgv.Columns(dc.Name).Frozen = True
                                ' En congelar solo ponemos una columna
                                Exit Sub
                        End Select
                        Exit For
                    End If
                Next
            Next
        End If
    End Sub

    Public Sub PintarIconos(ByVal Formu As Object)

        Dim ctl As Object

        Try

            For Each ctl In Formu.PanelBotones.controls
                If ctl.Name.ToString.ToUpper = "BTNAÑADIR" Then
                    ctl.ImageList = frmPrincipal.ImgGeneral
                    ctl.ImageKey = "añadir.png"
                End If
                If ctl.Name.ToString.ToUpper = "BTNMODIFICAR" Then
                    ctl.ImageList = frmPrincipal.ImgGeneral
                    ctl.ImageKey = "modificar.png"
                End If
                If ctl.Name.ToString.ToUpper = "BTNBORRAR" Then
                    ctl.ImageList = frmPrincipal.ImgGeneral
                    ctl.ImageKey = "borrar.png"
                End If
                If ctl.Name.ToString.ToUpper = "BTNACEPTAR" Then
                    ctl.ImageList = frmPrincipal.ImgGeneral
                    ctl.ImageKey = "aceptar.png"
                End If
                If ctl.Name.ToString.ToUpper = "BTNCANCELAR" Then
                    ctl.ImageList = frmPrincipal.ImgGeneral
                    ctl.ImageKey = "cancelar.png"
                End If
                If ctl.Name.ToString.ToUpper = "BTNSALIR" Then
                    ctl.ImageList = frmPrincipal.ImgGeneral
                    ctl.ImageKey = "salir.png"
                End If

                If ctl.Name.ToString.ToUpper = "BTNEMAIL" Then
                    ctl.ImageList = frmPrincipal.ImgGeneral
                    ctl.ImageKey = "email.png"
                End If

                If UCase(Left(ctl.Name, 11)) = "BTNIMPRIMIR" Then
                    ctl.ImageList = frmPrincipal.ImgGeneral
                    ctl.ImageKey = "imprimir.png"
                End If
            Next

        Catch ex As Exception

        End Try

        Formu.Icon = My.Resources.Icono
        '   Formu.BackColor = Color.GhostWhite


        '  Formu.Font = New Font(Formu.Font.FontFamily, 12)

        'Formu.btnAñadir.ImageList = frmPrincipal.ImgGeneral
        'Formu.btnAñadir.ImageKey = "añadir.png"
        'Formu.btnBorrar.ImageKey = "borrar.png"
        'Formu.btnBorrar.ImageList = frmPrincipal.ImgGeneral
        'Formu.btnModificar.ImageKey = "modificar.png"
        'Formu.btnModificar.ImageList = frmPrincipal.ImgGeneral
        'Formu.btnAceptar.ImageList = frmPrincipal.ImgGeneral
        'Formu.btnAceptar.ImageKey = "aceptar.png"
        'Formu.btnCancelar.ImageList = frmPrincipal.ImgGeneral
        'Formu.btnCancelar.ImageKey = "cancelar.png"
        'Formu.btnSalir.ImageList = frmPrincipal.ImgGeneral
        'Formu.btnSalir.ImageKey = "salir.png"
    End Sub

    Public Sub AnadirCheckBoxColumn(ByVal dgv As DataGridView)
        Dim column As New DataGridViewCheckBoxColumn()
        With column

            .HeaderText = "Selec."
            .Name = "Chec"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '.FlatStyle = FlatStyle.Flat
            .FlatStyle = FlatStyle.Standard

            '    .FlatStyle = FlatStyle.Standard
            '    .CellTemplate = New DataGridViewCheckBoxCell()
            '    .CellTemplate.Style.BackColor = Color.Beige
            '   .ReadOnly = False
        End With

        dgv.Columns.Insert(0, column)
    End Sub
    'Public Function LlenarComboDisenos(ByVal cmbDiseños As lpComboBox.LPControles.lpComboBox, ByVal CarpetaEspecial As String, Optional ByVal BuscarPredeterminado As Boolean = False, Optional ByVal TipoVista As String = "", Optional ByVal grid As DevExpress.XtraGrid.Views.Grid.GridView = Nothing) As Boolean

    '    Dim Carpeta As String = GL_RutaDisenoUsuario & "\" & CarpetaEspecial
    '    Dim Ficheros As String()

    '    cmbDiseños.Items.Clear()
    '    cmbDiseños.Items.Add("")

    '    FuncionesGenerales.Funciones.ComprobarYCrearCarpetas(Carpeta)
    '    Ficheros = System.IO.Directory.GetFiles(Carpeta, "*.xml")
    '    For Each Fich In Ficheros
    '        cmbDiseños.Items.Add(System.IO.Path.GetFileNameWithoutExtension(Fich))
    '    Next

    '    cmbDiseños.Text = ""

    '    If Ficheros.Length = 0 Then
    '        Return False
    '    End If

    '    If BuscarPredeterminado Then

    '        Dim sel As String = "SELECT Predeterminada FROM Vistas WHERE Usuario = '" & GL_Usuario & "' AND TipoVista = '" & TipoVista & "'"

    '        Dim Diseno As String
    '        Dim bdBusca As New BaseDatos
    '        Diseno = bdBusca.Execute(sel, False)
    '        If Diseno <> "" Then
    '            If cmbDiseños.FindStringExact(Diseno) >= 0 Then
    '                'cargar diseño
    '                cmbDiseños.Text = Diseno
    '                RecuperarDiseño(cmbDiseños, CarpetaEspecial, grid)
    '                Return True
    '            Else
    '                MsgBox("No se encuentra el diseño " & Diseno & " que fue asociado a este usuario.")
    '            End If
    '        End If

    '        Return False
    '    End If

    'End Function
    'Public Function RecuperarDiseño(ByVal cmbDiseños As lpComboBox.LPControles.lpComboBox, ByVal CarpetaEspecial As String, ByVal grid As DevExpress.XtraGrid.Views.Grid.GridView) As Boolean

    '    If cmbDiseños.Text = "" Then
    '        MsgBox("Debe seleccionar el Diseño a recuperar")
    '        Return False
    '    End If

    '    Dim RutaCompleta As String = GL_RutaDisenoUsuario & "\" & CarpetaEspecial & "\" & cmbDiseños.Text & ".xml"
    '    If Not System.IO.File.Exists(RutaCompleta) Then
    '        MsgBox("No existe el diseño seleccionado.")
    '        Return False
    '    End If

    '    Try
    '        grid.RestoreLayoutFromXml(GL_RutaDisenoUsuario & "\" & CarpetaEspecial & "\" & cmbDiseños.Text & ".xml", DevExpress.Utils.OptionsLayoutBase.FullLayout)
    '        Return True

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Return False
    '    End Try

    'End Function


End Module
