'JCB 11/10/12
'CAMBIOS v. AÑADIDA LA FUNCION IMPORTAR EN LA CLASE CLACTUALIZCIONES
'De esta manera, desde la aplicación, rellenamos los tabs correspondiente y luego hacemos tab.insertar y listo.

Imports System.Data.SqlClient
Imports System.Data
Imports System


'Clase para manejar las Bases de Datos
Public Class BaseDatos
    Implements IDisposable

  
    Public ds As New DataSet
    Public dt As New DataTable

    Public cn As New SqlConnection
    Public cmd As New SqlCommand
    Public daa() As SqlDataAdapter
    Public cbb() As SqlCommandBuilder

    Public cnAccess As New OleDb.OleDbConnection
    Public cmdAccess As New OleDb.OleDbCommand
    Public daaAccess() As OleDb.OleDbDataAdapter
    Public cbbAccess() As OleDb.OleDbCommandBuilder

    Private CadConexion As String


    Private NumCadenaAUtilizar As Integer

    Sub New(Optional ByVal NumeroCadena As Integer = 0)

        NumCadenaAUtilizar = NumeroCadena

        ds = New DataSet
        'Select Case NumeroCadena
        '    Case 0
        '        CadConexion = clVariables.CadenaConexion
        '    Case 1
        '        CadConexion = clVariables.CadenaConexion1
        '    Case 2
        '        CadConexion = clVariables.CadenaConexion2
        '    Case 3
        '        CadConexion = clVariables.CadenaConexion3
        '    Case 4
        '        CadConexion = clVariables.CadenaConexion4
        '    Case 5
        '        CadConexion = clVariables.CadenaConexion5
        'End Select


    End Sub
    Private Sub ObtenerCadenaConexion()
        Select Case NumCadenaAUtilizar
            Case 0
                CadConexion = clVariables.CadenaConexion
            Case 1
                CadConexion = clVariables.CadenaConexion1
            Case 2
                CadConexion = clVariables.CadenaConexion2
            Case 3
                CadConexion = clVariables.CadenaConexion3
            Case 4
                CadConexion = clVariables.CadenaConexion4
            Case 5
                CadConexion = clVariables.CadenaConexion5
        End Select
    End Sub


    Private Sub PrepararObjetoBD()

        ObtenerCadenaConexion()

        If GL_TipoBD = EnumTipoBD.SQL_SERVER Then
            cn = New SqlConnection
            cn.ConnectionString = CadConexion
        ElseIf GL_TipoBD = EnumTipoBD.ACCESS Then
            cnAccess = New OleDb.OleDbConnection
            cnAccess.ConnectionString = CadConexion
        End If

    End Sub

    Public Sub GenerarCadenaConexion()

        'If cn.State <> ConnectionState.Closed Then
        '    CerrarBD()
        'End If
        'cn.ConnectionString = CadConexion

        Try
            If GL_TipoBD = EnumTipoBD.SQL_SERVER Then
                If IsNothing(cn) OrElse cn.ConnectionString = "" Then
                    PrepararObjetoBD()
                    cn.Open()
                Else
                    If cn.State <> ConnectionState.Open Then
                        cn.Open()
                    End If

                End If
            ElseIf GL_TipoBD = EnumTipoBD.ACCESS Then
                If IsNothing(cnAccess) OrElse cnAccess.ConnectionString = "" Then
                    PrepararObjetoBD()
                    cnAccess.Open()
                Else
                    If cnAccess.State <> ConnectionState.Open Then
                        cnAccess.Open()
                    End If

                End If
            End If
            
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub

    Public Sub AbrirBD()
        If GL_TipoBD = EnumTipoBD.SQL_SERVER Then
            If cn.State <> ConnectionState.Closed Then
                CerrarBD()
            End If
            cn.Open()
        ElseIf GL_TipoBD = EnumTipoBD.ACCESS Then
            If cnAccess.State <> ConnectionState.Closed Then
                CerrarBD()
            End If
            cnAccess.Open()
        End If
       
    End Sub

    Public Sub CerrarBD()
        If GL_TipoBD = EnumTipoBD.SQL_SERVER Then
            If Not IsNothing(cn) AndAlso cn.State <> ConnectionState.Closed Then
                cn.Close()
            End If
            'Try
            '    SqlConnection.ClearPool(cn)
            'Catch ex As Exception

            'End Try
        ElseIf GL_TipoBD = EnumTipoBD.ACCESS Then
            If Not IsNothing(cnAccess) AndAlso cnAccess.State <> ConnectionState.Closed Then
                cnAccess.Close()
            End If
            
        End If

       

    End Sub

    Public Sub LlenarAdapter(ByVal Sel As String, ByVal Indice As Integer, Optional ByVal GenerarCommandsDinamicos As Boolean = False)

        If GL_TipoBD = EnumTipoBD.SQL_SERVER Then
            If NumCadenaAUtilizar = 0 Then
                ReDim Preserve daa(Indice)
                daa(Indice) = New SqlDataAdapter(Sel, cnSQLServerUnica)
            Else

                PrepararObjetoBD()
                ReDim Preserve daa(Indice)
                daa(Indice) = New SqlDataAdapter(Sel, cn)
            End If
        ElseIf GL_TipoBD = EnumTipoBD.ACCESS Then
            If NumCadenaAUtilizar = 0 Then
                ReDim Preserve daaAccess(Indice)
                daaAccess(Indice) = New OleDb.OleDbDataAdapter(Sel, cnAccessUnica)
            Else

                PrepararObjetoBD()
                ReDim Preserve daaAccess(Indice)
                daaAccess(Indice) = New OleDb.OleDbDataAdapter(Sel, cnAccess)
            End If
        End If
       



        'ReDim Preserve daa(Indice)
        'ReDim Preserve cbb(Indice)

        'daa(Indice) = New SqlDataAdapter(Sel, cn)
        'cbb(Indice) = New SqlCommandBuilder(daa(Indice))
        'Try
        '    If GenerarCommandsDinamicos Then
        '        daa(Indice).DeleteCommand = cbb(Indice).GetDeleteCommand.Clone
        '        daa(Indice).InsertCommand = cbb(Indice).GetInsertCommand.Clone
        '        daa(Indice).UpdateCommand = cbb(Indice).GetUpdateCommand.Clone
        '    End If
        'Catch ex As Exception

        'End Try


    End Sub
    Private Sub AbrirCadenaConexionUnica(Optional ByVal NumeroCadena As Integer = 0)


        Select Case NumeroCadena

            Case 0
                If GL_TipoBD = EnumTipoBD.SQL_SERVER Then
                    If IsNothing(cnSQLServerUnica) Then
                        cnSQLServerUnica = New SqlConnection
                    End If

                    If cnSQLServerUnica.State = ConnectionState.Closed Then
                        ObtenerCadenaConexion()
                        CadConexion = Replace(CadConexion, "APP = Venalia", "APP = Venalia_Unica")
                        cnSQLServerUnica.ConnectionString = CadConexion
                        cnSQLServerUnica.Open()
                    End If
                ElseIf GL_TipoBD = EnumTipoBD.ACCESS Then
                    If IsNothing(cnAccessUnica) Then
                        cnAccessUnica = New OleDb.OleDbConnection
                    End If

                    If cnAccessUnica.State = ConnectionState.Closed Then
                        ObtenerCadenaConexion()
                        CadConexion = Replace(CadConexion, "APP = Venalia", "APP = Venalia_Unica")
                        cnAccessUnica.ConnectionString = CadConexion
                        cnAccessUnica.Open()
                    End If
                End If

               
        End Select


    End Sub
    'Funcion SobreCargada Para utilizar un DataSet de fuera o el de la clase
    Public Sub LlenarDataSet(ByVal Sel As String, ByVal Tabla As String, Optional ByVal GenerarCommandsDinamicos As Boolean = False, Optional LlenarEsquema As Boolean = True, Optional ValoresPorDefecto As Boolean = False, Optional AbrirYCerrarBD As Boolean = True, Optional b_CrearCommandBuilder As Boolean = True)

        If IsNothing(ds) Then
            ds = New DataSet
        End If

        For i = 0 To ds.Tables.Count - 1
            If ds.Tables(i).TableName.ToUpper = Tabla.ToUpper Then
                ds.Tables(i).Clear()
                Exit For
            End If
        Next

        Dim Indice As Integer


        'PARA PRUEBAS COMENTO ESTO
        'GenerarCadenaConexion()

        Indice = ds.Tables.Count
        LlenarAdapter(Sel, Indice, GenerarCommandsDinamicos)


        ds.EnforceConstraints = True
        ds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema

        If GL_TipoBD = EnumTipoBD.SQL_SERVER Then
            If LlenarEsquema Then
                daa(Indice).FillSchema(ds, SchemaType.Source, Tabla)
            End If
            daa(Indice).Fill(ds, Tabla)
        ElseIf GL_TipoBD = EnumTipoBD.ACCESS Then
            If LlenarEsquema Then
                daaAccess(Indice).FillSchema(ds, SchemaType.Source, Tabla)
            End If
            daaAccess(Indice).Fill(ds, Tabla)
        End If
       



        ' ds.Tables(Tabla).Constraints.Add("pk_sid", ds.Tables(Tabla).Columns("CONTADOR"), True)
        If b_CrearCommandBuilder Then
            CrearCommandBuilder(Indice, GenerarCommandsDinamicos)
        End If



        If ValoresPorDefecto Then
            '  Return
            PonerValoresPorDefecto(ds, Tabla)
        End If



    End Sub
    Private Sub PonerValoresPorDefecto(ByRef ds As DataSet, Tabla As String)
        If GL_TipoBD = EnumTipoBD.ACCESS Then
            For Each col As DataColumn In ds.Tables(Tabla).Columns
                If col.ColumnName.ToUpper <> "CONTADOR" Then
                    If Not col.AutoIncrement Then
                        Try


                            Select Case col.DataType.Name.ToUpper


                                Case "STRING"
                                    col.DefaultValue = GL_VACIO
                                Case "BIT", "BOOLEAN"
                                    col.DefaultValue = False
                                Case "INT32", "INT64", "INT16"
                                    col.DefaultValue = 0
                                Case "DECIMAL", "DOUBLE", "SINGLE"
                                    col.DefaultValue = 0
                                Case "DATE", "DATETIME"
                                    col.DefaultValue = DBNull.Value
                                    'Case "NUMBER"
                                    '    'If dtr("D") = 1 Then
                                    '    '    col.DefaultValue = False
                                    '    'ElseIf dtr("D") = 10 Then
                                    '    '    col.DefaultValue = 0
                                    '    'End If
                                Case Else

                                    Try
                                        col.DefaultValue = GL_VACIO
                                    Catch ex As Exception

                                    End Try
                            End Select
                        Catch ex As Exception

                        End Try
                    End If

                    '  Exit For
                End If
            Next
            Return
        End If

        Dim dtr As Object
        Dim bdCol As New BaseDatos
        Dim Sel As String

        Sel = " SELECT  C.name as Columna , A.Name as Tipo  FROM sys.TABLES T INNER JOIN sys.COLUMNS C ON T.OBJECT_ID = C.OBJECT_ID " & _
               " INNER JOIN sys.types A ON C.system_type_id = A.system_type_id AND C.user_type_id=A.user_type_id" & _
               " WHERE T.NAME = '" & Tabla & "'"
        dtr = bdCol.ExecuteReader(Sel)

        If dtr.HasRows Then
            While dtr.Read
                For Each col As DataColumn In ds.Tables(Tabla).Columns
                    If col.ColumnName.ToUpper = dtr("Columna").ToString.ToUpper Then
                        If Not col.AutoIncrement Then
                            Try


                                Select Case dtr("Tipo").ToString.ToUpper

                                    Case "VARCHAR"
                                        col.DefaultValue = ""
                                    Case "BIT"
                                        col.DefaultValue = False
                                    Case "INT"
                                        col.DefaultValue = 0
                                    Case "FLOAT"
                                        col.DefaultValue = 0
                                    Case "DATETIME"
                                        col.DefaultValue = DBNull.Value
                                    Case Else
                                        Try
                                            col.DefaultValue = ""
                                        Catch ex As Exception

                                        End Try
                                End Select
                            Catch ex As Exception

                            End Try
                        End If

                        Exit For
                    End If
                Next
            End While
        End If
        dtr.Close()
        bdCol.CerrarBD()
    End Sub

    Public Sub RefrescarDatos(Optional PosicionParaActualizarSoloFilaSeleccionada As Integer = -1, Optional NombreTabla As String = GL_VACIO, Optional GvAActualizar As MyGridView = Nothing, Optional Bind As BindingSource = Nothing, Optional VaciarAntes As Boolean = False)

        'Con este procedimiento, refrescamos el dataset desde la bd

        'Hay 2 modos de refrescar

        '1. Solo una fila.  En este caso pasaríamos el índice o la posicion de la fila a refrescar en el parámetro  PosicionParaActualizarSoloFilaSeleccionada
        '                   Si estamos con un binding, pasaríamos por ejemplo BinSrc.Position o uInmueblesActivo.BinSrc.Position

        '2. Actualizar el ds completo.En este caso NO pasamos valor al parámetro PosicionParaActualizarSoloFilaSeleccionada, lo dejamos con -1
        '   Si el ds está enlazado a un grid y queremos que al finalizar quede todo en la posición que estaba, debemos pasar
        '       - El objeto MyGridView donde situaremos la fila, por ejemplo Gv 
        '       - Si trabajamos con un binding, se lo pasamos para que coja la posición acutal, si no la cojerá del grid
        '       Si no pasamos grid ni binding, no se posicionará tras acabar



        FuncionesGenerales.Funciones.CerrarBDSiEsAccess()

        If NombreTabla.Trim = GL_VACIO Then
            NombreTabla = ds.Tables(0).TableName
        End If

        If PosicionParaActualizarSoloFilaSeleccionada >= 0 Then
            LlenarDsEnRefrescarDatos(NombreTabla, ds, PosicionParaActualizarSoloFilaSeleccionada, VaciarAntes)
        Else

            Dim IndiceAnterior As Integer = -1
            Dim TopIndexAntes As Integer = -1


            If Not IsNothing(Bind) Then 'Esto es pq me quiero situar
                IndiceAnterior = Bind.Position
            Else
                If Not IsNothing(GvAActualizar) Then 'Esto es pq me quiero situar
                    If IndiceAnterior = -1 Then
                        IndiceAnterior = GvAActualizar.FocusedRowHandle
                    End If
                End If
            End If

            If Not IsNothing(GvAActualizar) Then 'Esto es pq me quiero situar
                If TopIndexAntes = -1 Then
                    TopIndexAntes = GvAActualizar.TopRowIndex
                End If
            End If


            LlenarDsEnRefrescarDatos(NombreTabla, ds, , VaciarAntes)


            If IndiceAnterior >= 0 Then
                If Not IsNothing(Bind) Then 'Esto es pq me quiero situar
                    '     Bind.DataSource = Nothing
                    Bind.DataSource = ds

                    Bind.Position = IndiceAnterior
                Else
                    If Not IsNothing(GvAActualizar) Then 'Esto es pq me quiero situar
                        GvAActualizar.FocusedRowHandle = IndiceAnterior
                    End If
                End If

            End If

            If TopIndexAntes >= 0 Then
                GvAActualizar.TopRowIndex = TopIndexAntes
            End If
        End If

    End Sub


    Public Sub LlenarDsEnRefrescarDatos(ByVal Tabla As String, ByRef dsPasado As DataSet, Optional PosicionParaActualizarSoloFilaSeleccionada As Integer = -1, Optional VaciarAntes As Boolean = False)


        Dim Indice As Integer

        For i = 0 To dsPasado.Tables.Count - 1
            If dsPasado.Tables(i).TableName.ToUpper = Tabla.ToUpper Then
                Indice = i
                Exit For
            End If
        Next
        If GL_TipoBD = EnumTipoBD.SQL_SERVER Then
            If PosicionParaActualizarSoloFilaSeleccionada >= 0 Then
                daa(Indice).Fill(ds, PosicionParaActualizarSoloFilaSeleccionada, 1, Tabla)
            Else
                ds.Tables(Indice).Dispose()
                If VaciarAntes Then
                    ds.Tables(Indice).Clear()
                End If

                daa(Indice).Fill(ds, Tabla)
            End If
        ElseIf GL_TipoBD = EnumTipoBD.ACCESS Then
            If PosicionParaActualizarSoloFilaSeleccionada >= 0 Then
                daaAccess(Indice).Fill(ds, PosicionParaActualizarSoloFilaSeleccionada, 1, Tabla)
            Else
                ds.Tables(Indice).Clear()
                daaAccess(Indice).Fill(ds, Tabla)
            End If
        End If



    End Sub


    Public Sub ActualizarCambios(ByVal Tabla As String, ByRef dsPasado As DataSet, Optional RefrescarDatos As Boolean = False)

        'Utilizando el DataSet Externo
        Dim Indice As Integer

        If Tabla = "" Then
            Indice = 0
            Tabla = dsPasado.Tables(Indice).TableName
        Else
            For i = 0 To dsPasado.Tables.Count - 1
                If dsPasado.Tables(i).TableName.ToUpper = Tabla.ToUpper Then
                    Indice = i
                    Exit For
                End If
            Next
        End If

        If GL_TipoBD = EnumTipoBD.SQL_SERVER Then
            daa(Indice).Update(dsPasado.Tables(Tabla))

            If RefrescarDatos Then
                dsPasado.Tables(Indice).Clear()
                daa(Indice).Fill(dsPasado, Tabla)
            End If
        ElseIf GL_TipoBD = EnumTipoBD.ACCESS Then
            daaAccess(Indice).Update(dsPasado.Tables(Tabla))

            If RefrescarDatos Then
                dsPasado.Tables(Indice).Clear()
                daaAccess(Indice).Fill(dsPasado, Tabla)
            End If
        End If
        '   MsgBox(dsPasado.Tables(Indice).Columns("NOMBRE")(10573))

        '   dsPasado.Tables( Indice).Columns("CONTADOR")(dsPasado.Tables(Indice).Rows.Count - 1) = 9


        'dsPasado.AcceptChanges()
    End Sub
    Public Sub ActualizarCambios(ByVal Tabla As String)
        'Utilizando el DataSet de la clase (ds)
        Dim Indice As Integer

        For i = 0 To ds.Tables.Count - 1
            If ds.Tables(i).TableName.ToUpper = Tabla.ToUpper Then
                Indice = i
                Exit For
            End If
        Next
        If GL_TipoBD = EnumTipoBD.SQL_SERVER Then
            daa(Indice).Update(ds.Tables(Tabla))
        ElseIf GL_TipoBD = EnumTipoBD.ACCESS Then
            daaAccess(Indice).Update(ds.Tables(Tabla))
        End If

    End Sub

    Public Function ExecuteReader(ByVal Sel As String) As Object

        Select Case NumCadenaAUtilizar
            Case 0
                Select Case GL_TipoBD
                    Case EnumTipoBD.SQL_SERVER
                        If cnSQLServerUnicaDTR.State <> ConnectionState.Open Then
                            cnSQLServerUnicaDTR.Open()
                        End If

                    Case EnumTipoBD.ACCESS
                        If Not IsNothing(cnAccessUnicaDTR) AndAlso cnAccessUnicaDTR.State <> ConnectionState.Open Then
                            cnAccessUnicaDTR.Open()
                        End If

                        'Case EnumTipoBD.ORACLE

                End Select

            Case Else
                GenerarCadenaConexion()
        End Select

        'GenerarCadenaConexion()

        Select Case NumCadenaAUtilizar
            Case 0
                Select Case GL_TipoBD
                    Case EnumTipoBD.SQL_SERVER
                        ' cmdSQLServer = New SqlCommand(Sel, cnSQLServerUnica)
                        cmdSQLServerUnicaDTR.CommandText = Sel
                        'cmdSQLServerUnicaDTR.Connection.Close()
                        'cmdSQLServerUnicaDTR.Connection.Open()
                        cmdSQLServerUnicaDTR = New SqlCommand(Sel, cnSQLServerUnicaDTR)
                        ' Return cmdSQLServerUnicaDTR.ExecuteReader(CommandBehavior.CloseConnection)

                        Try
                            Return cmdSQLServerUnicaDTR.ExecuteReader()
                        Catch ex As Exception

                            If cn.ConnectionString = "" Then
                                GenerarCadenaConexion()
                            End If
                            If cn.State = ConnectionState.Closed Then
                                cn.Open()
                            End If
                            cmd = New SqlCommand(Sel, cn)
                            Return cmd.ExecuteReader()
                        End Try

                    Case EnumTipoBD.ACCESS
                        cmdAccessUnicaDTR.CommandText = Sel
                        cmdAccessUnicaDTR = New OleDb.OleDbCommand(Sel, cnAccessUnicaDTR)

                        Try
                            Return cmdAccessUnicaDTR.ExecuteReader()
                        Catch ex As Exception

                            If cnAccess.ConnectionString = "" Then
                                GenerarCadenaConexion()
                            End If
                            If cnAccess.State = ConnectionState.Closed Then
                                cnAccess.Open()
                            End If
                            cmdAccess = New OleDb.OleDbCommand(Sel, cnAccess)
                            Return cmdAccess.ExecuteReader()
                        End Try

                        'Case EnumTipoBD.ORACLE

                End Select




            Case Else
                Select Case GL_TipoBD
                    Case EnumTipoBD.SQL_SERVER
                        cmd = New SqlCommand(Sel, cn)
                        Return cmd.ExecuteReader()

                    Case EnumTipoBD.ACCESS
                        cmdAccess = New OleDb.OleDbCommand(Sel, cnAccess)
                        Return cmdAccess.ExecuteReader()

                        'Case EnumTipoBD.ORACLE

                End Select
               
        End Select




        'Return cmd.ExecuteReader(CommandBehavior.CloseConnection)
        ' cmd.Connection.Close()

    End Function
    Public Sub CerrarCommand()
        If GL_TipoBD = EnumTipoBD.SQL_SERVER Then
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        ElseIf GL_TipoBD = EnumTipoBD.ACCESS Then
            If cmdAccess.Connection.State = ConnectionState.Open Then
                cmdAccess.Connection.Close()
            End If
        End If
        
    End Sub

    Public Sub CrearCommandBuilder(ByVal Indice As Integer, Optional ByVal GenerarCommandsDinamicos As Boolean = False)
        If GL_TipoBD = EnumTipoBD.SQL_SERVER Then
            ReDim Preserve cbb(Indice)
            cbb(Indice) = New SqlCommandBuilder(daa(Indice))
            Try
                If GenerarCommandsDinamicos Then
                    daa(Indice).DeleteCommand = cbb(Indice).GetDeleteCommand.Clone
                    daa(Indice).InsertCommand = cbb(Indice).GetInsertCommand.Clone
                    daa(Indice).UpdateCommand = cbb(Indice).GetUpdateCommand.Clone
                End If
            Catch ex As Exception

            End Try
            '  cbbSQLServer(Indice).ConflictOption = ConflictOption.OverwriteChanges
        ElseIf GL_TipoBD = EnumTipoBD.ACCESS Then
            ReDim Preserve cbbAccess(Indice)
            cbbAccess(Indice) = New OleDb.OleDbCommandBuilder(daaAccess(Indice))
            Try
                If GenerarCommandsDinamicos Then
                    daaAccess(Indice).DeleteCommand = cbbAccess(Indice).GetDeleteCommand.Clone
                    daaAccess(Indice).InsertCommand = cbbAccess(Indice).GetInsertCommand.Clone
                    daaAccess(Indice).UpdateCommand = cbbAccess(Indice).GetUpdateCommand.Clone
                End If
            Catch ex As Exception

            End Try
            cbbAccess(Indice).ConflictOption = ConflictOption.OverwriteChanges
        End If





    End Sub
    Public Function Execute(ByVal Sel As String, Optional ByVal NonQuery As Boolean = True, Optional ByVal SiNuloNothingDevolver As String = "NULO", Optional Cerrar As Boolean = True) As Object



        Dim aff As Object = Nothing

        Select Case NumCadenaAUtilizar
            Case 0
                Select Case GL_TipoBD
                    Case EnumTipoBD.SQL_SERVER
                        If cnSQLServerUnica.State <> ConnectionState.Open Then
                            cnSQLServerUnica.Open()
                        End If

                    Case EnumTipoBD.ACCESS
                        If Not IsNothing(cnAccessUnica) AndAlso cnAccessUnica.State <> ConnectionState.Open Then
                            cnAccessUnica.Open()
                        End If

                        'Case EnumTipoBD.ORACLE
                        '    If cnOracleUnicaTramex.State <> ConnectionState.Open Then
                        '        cnOracleUnicaTramex.Open()
                        '    End If
                End Select

            Case Else
                GenerarCadenaConexion()
        End Select
        'Select Case NumCadenaAUtilizar
        '    Case 0
        '        If cnSQLServerUnica.State <> ConnectionState.Open Then
        '            cnSQLServerUnica.Open()
        '        End If
        '    Case Else
        '        GenerarCadenaConexion()
        'End Select


        'Select Case NumCadenaAUtilizar
        '    Case 0
        '        ' cmdSQLServer = New SqlCommand(Sel, cnSQLServerUnica)
        '        cmdSQLServerUnica.CommandText = Sel

        '        If NonQuery Then
        '            aff = cmdSQLServerUnica.ExecuteNonQuery
        '        Else
        '            aff = cmdSQLServerUnica.ExecuteScalar
        '        End If

        '        cmdSQLServerUnica.CommandText = ""

        '    Case Else
        '        cmd = New SqlCommand(Sel, cn)

        '        If NonQuery Then
        '            aff = cmd.ExecuteNonQuery
        '        Else
        '            aff = cmd.ExecuteScalar
        '        End If
        'End Select

        Select Case GL_TipoBD
            Case EnumTipoBD.SQL_SERVER

                Select Case NumCadenaAUtilizar
                    Case 0
                        cmdSQLServerUnica.CommandText = Sel

                        If NonQuery Then
                            aff = cmdSQLServerUnica.ExecuteNonQuery
                        Else
                            aff = cmdSQLServerUnica.ExecuteScalar
                        End If

                        cmdSQLServerUnica.CommandText = ""

                    Case Else
                        cmd = New SqlCommand(Sel, cn)

                        If NonQuery Then
                            aff = cmd.ExecuteNonQuery
                        Else
                            aff = cmd.ExecuteScalar
                        End If
                End Select

            Case EnumTipoBD.ACCESS

                Select Case NumCadenaAUtilizar
                    Case 0
                        cmdAccessUnica.CommandText = Sel

                        If NonQuery Then
                            aff = cmdAccessUnica.ExecuteNonQuery
                            'Esto es para que acabe de hacer la instrucción de arriba
                            cmdAccessUnica.CommandText = "UPDATE Empresas SET Codigo = Codigo"
                            cmdAccessUnica.ExecuteNonQuery()
                            'FIN Esto es para que acabe de hacer la instrucción de arriba

                        Else
                            aff = cmdAccessUnica.ExecuteScalar
                        End If

                        cmdAccessUnica.CommandText = ""

                    Case Else
                        cmdAccess = New OleDb.OleDbCommand(Sel, cnAccess)

                        If NonQuery Then
                            aff = cmdAccess.ExecuteNonQuery
                        Else
                            aff = cmdAccess.ExecuteScalar
                        End If
                End Select






                'Case EnumTipoBD.ORACLE



                '    Sel = Replace(Sel, "''", GL_ESPACIOSQL)
                '    Sel = Replace(Sel, "/////", "''")
                '    ''If Sel.Contains(";") Then 'XXXXXXXXXXXXX PARA SI PONEMOS DOS CONSULTAS JUNTAS SEPARADAS POR ;
                '    ''    Sel = "BEGIN " & Sel & "; " & "END;"
                '    ''End If

                '    Try

                '        Select Case NumCadenaAUtilizar
                '            Case 0
                '                ' cmdoracle = New SqlCommand(Sel, cnoracleUnicaTramex)
                '                cmdoracleUnica.CommandText = Sel

                '                If NonQuery Then
                '                    aff = cmdoracleUnica.ExecuteNonQuery
                '                Else
                '                    aff = cmdoracleUnica.ExecuteScalar
                '                End If

                '                cmdoracleUnica.CommandText = ""

                '            Case Else
                '                cmdOracle = New OracleCommand(Sel, cnOracle)
                '                If NonQuery Then
                '                    aff = cmdOracle.ExecuteNonQuery
                '                Else
                '                    aff = cmdOracle.ExecuteScalar
                '                End If
                '        End Select


                '    Catch exOra As OracleException
                '        If exOra.Number = 3114 Or exOra.Number = 3135 Then
                '            Try
                '                cmdOracle.Connection.Close()
                '                cmdOracle.Connection.Open()
                '            Catch ex As Exception

                '            End Try

                '            If NonQuery Then
                '                aff = cmdOracle.ExecuteNonQuery
                '            Else
                '                aff = cmdOracle.ExecuteScalar
                '            End If
                '        Else
                '            Throw (exOra)
                '        End If
                '    End Try


        End Select

       
        If NumCadenaAUtilizar <> 0 Then
            CerrarBD()
        End If

        If aff Is DBNull.Value Or aff Is Nothing Then
            If SiNuloNothingDevolver = "NULO" Then
                Return aff
            Else
                Return SiNuloNothingDevolver
            End If
        Else
            Return aff
        End If

    End Function

    Protected disposed As Boolean = False

    ' This method disposes the base object's resources.
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposed Then
            If disposing Then
                ds = Nothing
                If GL_TipoBD = EnumTipoBD.SQL_SERVER Then
                    cn.Dispose()
                    cmd.Dispose()
                ElseIf GL_TipoBD = EnumTipoBD.ACCESS Then
                    cnAccess.Dispose()
                    cmdAccess.Dispose()
                End If
                ' Insert code to free managed resources.
            End If
            ' Insert code to free unmanaged resources.
        End If
        Me.disposed = True
    End Sub

#Region " IDisposable Support "
    ' Do not change or add Overridable to these methods.
    ' Put cleanup code in Dispose(ByVal disposing As Boolean).
    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
    Protected Overrides Sub Finalize()
        Dispose(False)
        MyBase.Finalize()
    End Sub
#End Region
End Class
Public MustInherit Class clActualizaciones

    Public Property Tabla As String
    Public Property Filtro As String
    Public Property Orden As String
    Public Property ConsultaAEjecutar As String


    Protected MustOverride Sub CargarDatos(ByRef dr As DataRow)


    'Public Sub Modificar(ByRef dsPasado As DataSet, ByVal Fila As Integer)

    '    AltaModificar(False, dsPasado, Fila)

    'End Sub




    Public Sub Modificar(ByRef dsPasado As DataSet, ByVal dr As DataRow)

        AltaModificar(False, dsPasado, dr)

    End Sub
    Public Sub Alta(ByRef dsPasado As DataSet)

        AltaModificar(True, dsPasado)

    End Sub
    Private Sub AltaModificar(ByVal Alta As Boolean, ByRef dsPasado As DataSet, Optional ByVal dr As DataRow = Nothing)

        Dim dt As New DataTable
        dt = dsPasado.Tables(Tabla)

        If Alta Then
            dr = dt.NewRow
        Else
            '     dr = dt.Rows(Fila)
            dr.BeginEdit()
        End If

        CargarDatos(dr)

        If Alta Then
            dt.Rows.Add(dr)
        Else
            dr.EndEdit()
        End If
    End Sub

    Public Sub Datos(bd As BaseDatos, Optional Sel As String = "", Optional NombreTabla As String = "", Optional ByVal GenerarCommandsDinamicos As Boolean = False, Optional NumeroCadena As Integer = 0, Optional LlenarEsquema As Boolean = True, Optional ValoresPorDefecto As Boolean = False, Optional AbrirYCerrarBD As Boolean = True)

        If NombreTabla = "" Then
            NombreTabla = Tabla
        End If
        LlenarDatos(bd, Sel, NombreTabla, GenerarCommandsDinamicos, NumeroCadena, LlenarEsquema, ValoresPorDefecto, AbrirYCerrarBD)

    End Sub
    Private Sub LlenarDatos(bd As BaseDatos, Optional Sel As String = "", Optional NombreTabla As String = "", Optional ByVal GenerarCommandsDinamicos As Boolean = False, Optional NumeroCadena As Integer = 0, Optional LlenarEsquema As Boolean = True, Optional ValoresPorDefecto As Boolean = False, Optional AbrirYCerrarBD As Boolean = True)

        If Sel = "" Then
            Sel = "SELECT * FROM " & NombreTabla & Filtro & Orden
        End If
        bd.LlenarDataSet(Sel, NombreTabla, GenerarCommandsDinamicos, LlenarEsquema, ValoresPorDefecto, AbrirYCerrarBD)

    End Sub


    Public Function Insertar(Optional NumeroCadena As Integer = 0) As Boolean

        Dim bd As New BaseDatos(NumeroCadena)
        Dim Sel As String = "SELECT TOP 0 * FROM " & Tabla
        bd.LlenarDataSet(Sel, Tabla)
        AltaModificar(True, bd.ds)


        Try
            bd.ActualizarCambios(Tabla, bd.ds)
            Return True
        Catch ex As Exception 'SqlClient.SqlException


            Throw New Exception("Error al insertar.", ex)

            'If ex.Number = 2627 Then

            '    MsgBox(GL_ValorDuplicado)
            'Else
            '    MsgBox(ex.Message)
            'End If

            bd.ds.RejectChanges()
            Return False
        End Try


    End Function




    'Private Sub AltaModificar(ByVal Alta As Boolean, ByRef dsPasado As DataSet, Optional ByVal Fila As Integer = 0)

    '    Dim dt As DataTable
    '    Dim dr As DataRow
    '    dt = dsPasado.Tables(Tabla)

    '    If Alta Then
    '        dr = dt.NewRow
    '    Else
    '        dr = dt.Rows(Fila)
    '        dr.BeginEdit()
    '    End If

    '    CargarDatos(dr)

    '    If Alta Then
    '        dt.Rows.Add(dr)
    '    Else
    '        dr.EndEdit()
    '    End If
    'End Sub

    'Public Sub Borrar(ByRef dsPasado As DataSet, ByVal Fila As Integer)

    '    Dim dt As DataTable
    '    Dim dr As DataRow
    '    dt = dsPasado.Tables(Tabla)
    '    dr = dt.Rows(Fila)
    '    dr.Delete()

    'End Sub


    Public Sub Borrar(ByVal dr As DataRow)

        dr.Delete()

    End Sub



End Class
Public Class clVariables

    Public Shared UsuarioFTP As String
    Public Shared PassWordFTP As String
    Public Shared BaseDatosFTP As String
    Public Shared SoftwareFTP As String
    Public Shared RutaInicialFTP As String
    Public Shared RutaCompletaFTP As String

    Public Shared CadenaConexion As String
    Public Shared BaseDatos As String
    Public Shared ServidorSQL As String
    Public Shared UsuarioSQL As String
    Public Shared RutaServidor As String
    Public Shared PassWordUsuarioSQL As String

    Public Shared CadenaConexion1 As String
    Public Shared BaseDatos1 As String
    Public Shared ServidorSQL1 As String
    Public Shared UsuarioSQL1 As String
    Public Shared PassWordUsuarioSQL1 As String

    Public Shared CadenaConexion2 As String
    Public Shared BaseDatos2 As String
    Public Shared ServidorSQL2 As String
    Public Shared UsuarioSQL2 As String
    Public Shared PassWordUsuarioSQL2 As String

    Public Shared CadenaConexion3 As String
    Public Shared BaseDatos3 As String
    Public Shared ServidorSQL3 As String
    Public Shared UsuarioSQL3 As String
    Public Shared PassWordUsuarioSQL3 As String

    Public Shared CadenaConexion4 As String
    Public Shared BaseDatos4 As String
    Public Shared ServidorSQL4 As String
    Public Shared UsuarioSQL4 As String
    Public Shared PassWordUsuarioSQL4 As String

    Public Shared CadenaConexion5 As String
    Public Shared BaseDatos5 As String
    Public Shared ServidorSQL5 As String
    Public Shared UsuarioSQL5 As String
    Public Shared PassWordUsuarioSQL5 As String


End Class
Public Class clGenerales
    'Permite trabajar con consultas tanto de tipo ExecuteNonquery como con ExecuteScalar

    Public Shared Function Ejecutar(ByVal Sel As String, Optional ByVal NumeroCadena As Integer = 0) As Object
        Dim bd As New BaseDatos(NumeroCadena)

        Dim aff As Object
        aff = bd.Execute(Sel, False)
        bd.CerrarBD()
        If aff Is DBNull.Value Or aff Is Nothing Then
            Return 0
        Else
            Return aff
        End If

    End Function

    Public Shared Function General(ByVal Campo As String, ByVal Tabla As String, ByVal Instruccion As String, Optional ByVal Condicion As String = "", Optional ByVal NumeroCadena As Integer = 0) As Object
        Dim bd As New BaseDatos(NumeroCadena)
        Dim Sel As String
        Dim aff As Object

        If Condicion <> "" Then
            Condicion = Microsoft.VisualBasic.LTrim(Condicion)
            If Microsoft.VisualBasic.UCase(Microsoft.VisualBasic.Left(Condicion, 5)) <> "WHERE" Then
                Condicion = "WHERE " & Condicion
            End If
        End If

        Sel = "SELECT " & Instruccion & "(" & Campo & ") FROM " & Tabla & " " & Condicion

        aff = bd.Execute(Sel, False)

        bd.CerrarBD()

        If aff Is DBNull.Value Or aff Is Nothing Then
            Return 0
        Else
            Return aff
        End If



    End Function
    Public Shared Function Media(ByVal Campo As String, ByVal Tabla As String, Optional ByVal Condicion As String = "", Optional ByVal NumeroCadena As Integer = 0) As Double
        'Saca el valor máximo dado un campo y una tabla
        Return General(Campo, Tabla, "AVG", Condicion, NumeroCadena)
    End Function

    Public Shared Function Suma(ByVal Campo As String, ByVal Tabla As String, Optional ByVal Condicion As String = "", Optional ByVal NumeroCadena As Integer = 0) As Double
        'Saca el valor máximo dado un campo y una tabla
        Return General(Campo, Tabla, "SUM", Condicion, NumeroCadena)
    End Function
    Public Shared Function Maximo(ByVal Campo As String, ByVal Tabla As String, Optional ByVal Condicion As String = "", Optional ByVal NumeroCadena As Integer = 0) As Double
        'Saca el valor máximo dado un campo y una tabla
        Return General(Campo, Tabla, "MAX", Condicion, NumeroCadena)
    End Function

    Public Shared Function Minimo(ByVal Campo As String, ByVal Tabla As String, Optional ByVal Condicion As String = "", Optional ByVal NumeroCadena As Integer = 0) As Double
        'Saca el valor mínimo dado un campo y una tabla
        Return General(Campo, Tabla, "MIN", Condicion, NumeroCadena)
    End Function

    Public Shared Function Cuenta(ByVal Tabla As String, Optional ByVal Condicion As String = "", Optional ByVal NumeroCadena As Integer = 0) As Double
        'Cuenta el número de registros dada una tabla
        Return General("*", Tabla, "COUNT", Condicion, NumeroCadena)
    End Function

    Public Shared Function SiguienteRegistro(ByVal Campo As String, ByVal Tabla As String, Optional ByVal Condicion As String = "", Optional ByVal NumeroCadena As Integer = 0) As Double
        'Nos da el siguiente registro de una tabla, en el caso de que vayamos a dar de alta otro registro.
        'Trabaja con los campos que identifican los registros, deben ser númericos
        Return Maximo(Campo, Tabla, Condicion, NumeroCadena) + 1
    End Function
End Class




