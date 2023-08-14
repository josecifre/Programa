Imports System.Data.SqlClient
Imports System.Data.OleDb
'Imports System.Data.OracleClient
Imports System.Data
Imports System
Imports Oracle.DataAccess.Client

'Clase para manejar las Bases de Datos
Public Class BaseDatos

    Public ds As New DataSet
    Public dt As New DataTable

    Public cnSQLServer As New SqlConnection
    Public cmdSQLServer As New SqlCommand
    Public daaSQLServer() As SqlDataAdapter
    Public cbbSQLServer() As SqlCommandBuilder

    Public cnAccess As New OleDbConnection
    Public cmdAccess As New OleDbCommand
    Public daaAccess() As OleDbDataAdapter
    Public cbbAccess() As OleDbCommandBuilder
 
    Private CadConexion As String

    Private NumCadenaAUtilizar As Integer

    Private TipoBD As Integer

    Sub New(Optional ByVal NumeroCadena As Integer = 0)


        NumCadenaAUtilizar = NumeroCadena

        Select Case NumeroCadena
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

    Public Sub GenerarCadenaConexion()
        'Dim GL_Servidor As String = System.Net.Dns.GetHostEntry("LOCALHOST").HostName & "\SQLEXPRESS"
        'Dim GL_BaseDatos As String
        'cnSQLServer.ConnectionString = "Data Source=" & GL_Servidor & ";Initial Catalog=" & GL_BaseDatos & ";Integrated Security=True"
        Select Case GL_TipoBD
            Case EnumTipoBD.SQL_SERVER


                '    CerrarBD()
                If cnSQLServer.ConnectionString = "" OrElse cnSQLServer.State = ConnectionState.Closed Then
                    If cnSQLServer.State <> ConnectionState.Closed Then
                        CerrarBD()
                    End If
                    cnSQLServer.ConnectionString = CadConexion
                    cnSQLServer.Open()
                End If



            Case EnumTipoBD.ACCESS

                If cnAccess.ConnectionString = "" OrElse cnAccess.State = ConnectionState.Closed Then
                    If cnAccess.State <> ConnectionState.Closed Then
                        CerrarBD()
                    End If
                    cnAccess.ConnectionString = CadConexion
                    cnAccess.Open()
                End If


            

        End Select



    End Sub

    Public Sub CerrarBD()
        Select Case GL_TipoBD
            Case EnumTipoBD.SQL_SERVER
                If cnSQLServer.State <> ConnectionState.Closed Then
                    cnSQLServer.Close()
                End If
                Try
                    SqlConnection.ClearPool(cnSQLServer)
                Catch ex As Exception



                End Try
            Case EnumTipoBD.ACCESS
                If cnAccess.State <> ConnectionState.Closed Then
                    cnAccess.Close()
                End If
                Try
                    'OleDbConnection.ClearPool(cnAccess)
                Catch ex As Exception


                End Try
          
                
        End Select


    End Sub

    Public Sub LlenarAdapter(ByVal Sel As String, ByVal Indice As Integer, Optional ByVal GenerarCommandsDinamicos As Boolean = False)
        Select Case GL_TipoBD
            Case EnumTipoBD.SQL_SERVER
                ReDim Preserve daaSQLServer(Indice)
                daaSQLServer(Indice) = New SqlDataAdapter(Sel, cnSQLServer)
            Case EnumTipoBD.ACCESS
                ReDim Preserve daaAccess(Indice)
                daaAccess(Indice) = New OleDbDataAdapter(Sel, cnAccess)
          

        End Select


        '    ReDim Preserve cbbSQLServer(Indice)





        'cbbSQLServer(Indice) = New SqlCommandBuilder(daaSQLServer(Indice))
        'Try
        '    '    If GenerarCommandsDinamicos Then
        '    daaSQLServer(Indice).DeleteCommand = cbbSQLServer(Indice).GetDeleteCommand.Clone
        '    daaSQLServer(Indice).InsertCommand = cbbSQLServer(Indice).GetInsertCommand.Clone
        '    daaSQLServer(Indice).UpdateCommand = cbbSQLServer(Indice).GetUpdateCommand.Clone
        '    '    End If
        'Catch ex As Exception

        'End Try


    End Sub

    Public Sub CrearCommandBuilder(ByVal Indice As Integer, Optional ByVal GenerarCommandsDinamicos As Boolean = False)
        Select Case GL_TipoBD
            Case EnumTipoBD.SQL_SERVER
                ReDim Preserve cbbSQLServer(Indice)
                cbbSQLServer(Indice) = New SqlCommandBuilder(daaSQLServer(Indice))
                Try
                    If GenerarCommandsDinamicos Then
                        daaSQLServer(Indice).DeleteCommand = cbbSQLServer(Indice).GetDeleteCommand.Clone
                        daaSQLServer(Indice).InsertCommand = cbbSQLServer(Indice).GetInsertCommand.Clone
                        daaSQLServer(Indice).UpdateCommand = cbbSQLServer(Indice).GetUpdateCommand.Clone
                    End If
                Catch ex As Exception

                End Try
            Case EnumTipoBD.ACCESS
                ReDim Preserve cbbAccess(Indice)
                cbbAccess(Indice) = New OleDbCommandBuilder(daaAccess(Indice))
                Try
                    If GenerarCommandsDinamicos Then
                        daaAccess(Indice).DeleteCommand = cbbAccess(Indice).GetDeleteCommand.Clone
                        daaAccess(Indice).InsertCommand = cbbAccess(Indice).GetInsertCommand.Clone
                        daaAccess(Indice).UpdateCommand = cbbAccess(Indice).GetUpdateCommand.Clone
                    End If
                Catch ex As Exception

                End Try
            
        End Select

        '  cbbSQLServer(Indice).ConflictOption = ConflictOption.OverwriteChanges




    End Sub

    'Funcion SobreCargada Para utilizar un DataSet de fuera o el de la clase
    Public Sub LlenarDataSet(ByVal Sel As String, ByVal Tabla As String, Optional ByVal GenerarCommandsDinamicos As Boolean = False, Optional LlenarEsquema As Boolean = True, Optional ValoresPorDefecto As Boolean = False, Optional AbrirYCerrarBD As Boolean = True)

        For i = 0 To ds.Tables.Count - 1
            If ds.Tables(i).TableName.ToUpper = Tabla.ToUpper Then
                ds.Tables(i).Clear()
                Exit For
            End If
        Next

        Dim Indice As Integer
        '      ds.Clear()
        ' ds.Relations.Clear()
        GenerarCadenaConexion()
        Indice = ds.Tables.Count
        LlenarAdapter(Sel, Indice, GenerarCommandsDinamicos)
        'If AbrirYCerrarBD Then
        '    AbrirBD()
        'End If

        ds.EnforceConstraints = True
        ds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema


        If LlenarEsquema Then
            Select Case GL_TipoBD
                Case EnumTipoBD.SQL_SERVER

                    daaSQLServer(Indice).FillSchema(ds, SchemaType.Source, Tabla)
                Case EnumTipoBD.ACCESS
                    daaAccess(Indice).FillSchema(ds, SchemaType.Source, Tabla)
              

            End Select
        End If


        Select Case GL_TipoBD

            Case EnumTipoBD.SQL_SERVER
                daaSQLServer(Indice).Fill(ds, Tabla)
            Case EnumTipoBD.ACCESS
                daaAccess(Indice).Fill(ds, Tabla)
          



        End Select



        ' ds.Tables(Tabla).Constraints.Add("pk_sid", ds.Tables(Tabla).Columns("CONTADOR"), True)

        CrearCommandBuilder(Indice, GenerarCommandsDinamicos)

        Select Case GL_TipoBD

            Case EnumTipoBD.SQL_SERVER
                If Me.cnSQLServer.State <> ConnectionState.Closed Then
                    Me.cnSQLServer.Close()
                End If
            Case EnumTipoBD.ACCESS
                If Me.cnAccess.State <> ConnectionState.Closed Then
                    Me.cnAccess.Close()
                End If

            
        End Select



        '  OracleConnection.ClearPool(Me.cnOracle)

        'If AbrirYCerrarBD Then
        '    CerrarBD()
        'End If

        If ValoresPorDefecto Then
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
        '  Dim bdCol As New BaseDatos(NumCadenaAUtilizar)
        Dim Sel As String = GL_VACIO

        If GL_TipoBD = EnumTipoBD.SQL_SERVER Then
            Sel = "SELECT C.NAME AS COLUMNA, A.NAME AS TIPO FROM SYS.TABLES T INNER JOIN SYS.COLUMNS C ON T.OBJECT_ID = C.OBJECT_ID" & _
                   " INNER JOIN SYS.TYPES A ON C.SYSTEM_TYPE_ID = A.SYSTEM_TYPE_ID AND C.USER_TYPE_ID=A.USER_TYPE_ID" & _
                   " WHERE T.NAME = '" & Tabla & "'"
        ElseIf GL_TipoBD = EnumTipoBD.ORACLE Then
            Sel = "SELECT COLUMN_NAME AS COLUMNA,DATA_TYPE AS TIPO,DATA_PRECISION AS D FROM ALL_TAB_COLUMNS WHERE TABLE_NAME ='" & Tabla & "'"
        End If
        dtr = Me.ExecuteReader(Sel)

        If dtr.HasRows Then
            While dtr.Read
                For Each col As DataColumn In ds.Tables(Tabla).Columns
                    If col.ColumnName.ToUpper = dtr("Columna").ToString.ToUpper And col.ColumnName.ToUpper <> "CODIGO" Then
                        If Not col.AutoIncrement Then
                            Try


                                Select Case dtr("TIPO").ToString.ToUpper

                                    Case "VARCHAR", "VARCHAR2"
                                        col.DefaultValue = GL_VACIO
                                    Case "BIT"
                                        col.DefaultValue = False
                                    Case "INT"
                                        col.DefaultValue = 0
                                    Case "FLOAT", "DOUBLE"
                                        col.DefaultValue = 0
                                    Case "DATETIME", "DATE"
                                        col.DefaultValue = DBNull.Value
                                    Case "NUMBER"
                                        If dtr("D") = 1 Then
                                            col.DefaultValue = False
                                        ElseIf dtr("D") = 10 Then
                                            col.DefaultValue = 0
                                        End If
                                    Case Else

                                        Try
                                            col.DefaultValue = GL_VACIO
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
        Me.CerrarBD()

    End Sub
    'Public Sub LlenarDataSet(ByVal Sel As String, ByVal Tabla As String, ByRef dsPasado As DataSet)

    '    Dim Indice As Integer
    '    '**************debe clear??????????????????
    '    'dsPasado.Clear()
    '    'dsPasado.Relations.Clear()
    '    GenerarCadenaConexion()
    '    Indice = dsPasado.Tables.Count
    '    LlenarAdapter(Sel, Indice)
    '    AbrirBD()
    '    dsPasado.EnforceConstraints = False
    '    daaSQLServer(Indice).FillSchema(dsPasado, SchemaType.Source, Tabla)
    '    daaSQLServer(Indice).Fill(dsPasado, Tabla)
    '    CerrarBD()

    'End Sub

    Public Sub RefrescarDatos(Optional PosicionParaActualizarSoloFilaSeleccionada As Integer = -1, Optional NombreTabla As String = GL_VACIO, Optional GvAActualizar As MyGridView = Nothing, Optional Bind As BindingSource = Nothing)

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
            LlenarDsEnRefrescarDatos(NombreTabla, ds, PosicionParaActualizarSoloFilaSeleccionada)
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


            LlenarDsEnRefrescarDatos(NombreTabla, ds)


            If IndiceAnterior >= 0 Then
                If Not IsNothing(Bind) Then 'Esto es pq me quiero situar
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


    Public Sub LlenarDsEnRefrescarDatos(ByVal Tabla As String, ByRef dsPasado As DataSet, Optional PosicionParaActualizarSoloFilaSeleccionada As Integer = -1)


        Dim Indice As Integer

        For i = 0 To dsPasado.Tables.Count - 1
            If dsPasado.Tables(i).TableName.ToUpper = Tabla.ToUpper Then
                Indice = i
                Exit For
            End If
        Next

        If PosicionParaActualizarSoloFilaSeleccionada >= 0 Then
            Select Case GL_TipoBD
                Case EnumTipoBD.SQL_SERVER
                    daaSQLServer(Indice).Fill(ds, PosicionParaActualizarSoloFilaSeleccionada, 1, Tabla)
                Case EnumTipoBD.ACCESS
                    daaAccess(Indice).Fill(ds, PosicionParaActualizarSoloFilaSeleccionada, 1, Tabla)
               

            End Select
        Else
            ds.Tables(Indice).Clear()
            Select Case GL_TipoBD
                Case EnumTipoBD.SQL_SERVER
                    daaSQLServer(Indice).Fill(ds, Tabla)
                Case EnumTipoBD.ACCESS
                    daaAccess(Indice).Fill(ds, Tabla)
              

            End Select
        End If



    End Sub


    Public Sub ActualizarCambios(ByVal Tabla As String, ByRef dsPasado As DataSet, Optional RefrescarDatos As Boolean = False)

        'Utilizando el DataSet Externo
        Dim Indice As Integer

        For i = 0 To dsPasado.Tables.Count - 1
            If dsPasado.Tables(i).TableName.ToUpper = Tabla.ToUpper Then
                Indice = i
                Exit For
            End If
        Next
        Select Case GL_TipoBD
            Case EnumTipoBD.SQL_SERVER
                daaSQLServer(Indice).Update(dsPasado.Tables(Tabla))
            Case EnumTipoBD.ACCESS
                daaAccess(Indice).Update(dsPasado.Tables(Tabla))
           
        End Select

        If RefrescarDatos Then
            dsPasado.Tables(Indice).Clear()
            Select Case GL_TipoBD
                Case EnumTipoBD.SQL_SERVER
                    daaSQLServer(Indice).Fill(dsPasado, Tabla)
                Case EnumTipoBD.ACCESS
                    daaAccess(Indice).Fill(dsPasado, Tabla)
                

            End Select
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
        Select Case GL_TipoBD
            Case EnumTipoBD.SQL_SERVER
                daaSQLServer(Indice).Update(ds.Tables(Tabla))
            Case EnumTipoBD.ACCESS
                daaAccess(Indice).Update(ds.Tables(Tabla))
           

        End Select

    End Sub
    'Public Sub ActualizarCambios()
    '    'Sin DataSet, utilizando DataTable
    '    da.Update(dt)
    'End Sub

    Public Function ExecuteReader(ByVal Sel As String) As Object


        Dim objReader As Object = Nothing


        GenerarCadenaConexion()

        Select Case GL_TipoBD
            Case EnumTipoBD.SQL_SERVER
                ' Sel = Replace(Sel, "''", GL_ESPACIOSQL) 'PARA MANTENER LO MISMO QUE EN ORACLE

                'Sel = Replace(Sel, "''", GL_ESPACIOSQL)
                'Sel = Replace(Sel, "/////", "''")

                If cnSQLServer.State <> ConnectionState.Open Then
                    cnSQLServer.Open()
                End If

                cmdSQLServer = New SqlCommand(Sel, cnSQLServer)
                objReader = cmdSQLServer.ExecuteReader(CommandBehavior.CloseConnection)

            Case EnumTipoBD.ACCESS

                'Sel = Replace(Sel, "''", GL_ESPACIOSQL)
                'Sel = Replace(Sel, "/////", "''")


                If cnAccess.State <> ConnectionState.Open Then
                    cnAccess.Open()
                End If


                cmdAccess = New OleDbCommand(Sel, cnAccess)
                objReader = cmdAccess.ExecuteReader(CommandBehavior.CloseConnection)





            

        End Select
        Try
            'dtr = TryCast(obj, Object)
        Catch ex As Exception
            MensajeError(ex.Message)
        End Try


        Return objReader

    End Function

    Public Function Execute(ByVal Sel As String, Optional ByVal NonQuery As Boolean = True) As Object

        Dim aff As Object = Nothing

        Select Case NumCadenaAUtilizar
            Case 0
                AbrirCadenaConexionUnica(NumCadenaAUtilizar)

            Case Else
                GenerarCadenaConexion()
        End Select

        Select Case GL_TipoBD
            Case EnumTipoBD.SQL_SERVER

                'Sel = Replace(Sel, "''", GL_ESPACIOSQL) 'PARA MANTENER LO MISMO QUE EN ORACLE
                'Sel = Replace(Sel, "/////", "''")

                Select Case NumCadenaAUtilizar
                    Case 0
                        cmdSQLServer = New SqlCommand(Sel, cnSQLServerUnicaTramex)

                    Case Else
                        cmdSQLServer = New SqlCommand(Sel, cnSQLServer)
                End Select

                If NonQuery Then
                    aff = cmdSQLServer.ExecuteNonQuery
                Else
                    aff = cmdSQLServer.ExecuteScalar
                End If


            Case EnumTipoBD.ACCESS

                'Sel = Replace(Sel, "''", GL_ESPACIOSQL) 'PARA MANTENER LO MISMO QUE EN ORACLE
                'Sel = Replace(Sel, "/////", "''")

                Select Case NumCadenaAUtilizar
                    Case 0
                        cmdAccess = New OleDbCommand(Sel, cnAccessUnicaTramex)

                    Case Else
                        cmdAccess = New OleDbCommand(Sel, cnAccess)
                End Select



                If NonQuery Then
                    aff = cmdAccess.ExecuteNonQuery
                Else
                    aff = cmdAccess.ExecuteScalar
                End If


           
        End Select

        If NumCadenaAUtilizar <> 0 Then
            CerrarBD()
        End If

        Return aff
        'If aff Is DBNull.Value Or aff Is Nothing Then
        '    If SiNuloNothingDevolverNOTHING Then
        '        Return Nothing
        '    End If
        '    If SiNuloNothingDevolver = "NULO" Then
        '        Return aff
        '    Else
        '        Return SiNuloNothingDevolver
        '    End If
        'Else
        '    Return aff
        'End If

    End Function

    Private Sub AbrirCadenaConexionUnica(Optional ByVal NumeroCadena As Integer = 0)


        Select Case GL_TipoBD
            Case EnumTipoBD.SQL_SERVER

                Select Case NumeroCadena
                    Case 0

                        If IsNothing(cnSQLServerUnicaTramex) Then
                            cnSQLServerUnicaTramex = New SqlConnection
                        End If

                        If cnSQLServerUnicaTramex.State = ConnectionState.Closed Then
                            cnSQLServerUnicaTramex.ConnectionString = CadConexion
                            cnSQLServerUnicaTramex.Open()
                        End If


                End Select


            Case EnumTipoBD.ACCESS

                Select Case NumeroCadena
                    Case 0

                        If IsNothing(cnAccessUnicaTramex) Then
                            cnAccessUnicaTramex = New OleDbConnection
                        End If

                        If cnAccessUnicaTramex.State = ConnectionState.Closed Then
                            cnAccessUnicaTramex.ConnectionString = CadConexion
                            cnAccessUnicaTramex.Open()
                        End If


                End Select

          
        End Select





    End Sub

End Class
Public MustInherit Class clActualizaciones

    Public Property Tabla As String
    Public Property Filtro As String
    Public Property ORDEN As String
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

    Public Sub Datos(bd As BaseDatos, Optional Sel As String = GL_VACIO, Optional NombreTabla As String = GL_VACIO, Optional ByVal GenerarCommandsDinamicos As Boolean = False, Optional NumeroCadena As Integer = 0, Optional LlenarEsquema As Boolean = True, Optional ValoresPorDefecto As Boolean = False, Optional AbrirYCerrarBD As Boolean = True)

        If NombreTabla.Trim = GL_VACIO Then
            NombreTabla = Tabla
        End If
        LlenarDatos(bd, Sel, NombreTabla, GenerarCommandsDinamicos, NumeroCadena, LlenarEsquema, ValoresPorDefecto, AbrirYCerrarBD)

    End Sub
    Private Sub LlenarDatos(bd As BaseDatos, Optional Sel As String = GL_VACIO, Optional NombreTabla As String = GL_VACIO, Optional ByVal GenerarCommandsDinamicos As Boolean = False, Optional NumeroCadena As Integer = 0, Optional LlenarEsquema As Boolean = True, Optional ValoresPorDefecto As Boolean = False, Optional AbrirYCerrarBD As Boolean = True)

        If Sel.Trim = GL_VACIO Then
            Sel = "SELECT * FROM " & NombreTabla & Filtro & ORDEN
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
        Catch ex As SqlClient.SqlException
            Throw New Exception("Error al insertar.", ex)
            bd.ds.RejectChanges()
       
        Catch ex As OleDb.OleDbException

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
    Public Shared RutaServidorConBarraFinal As String
    Public Shared PassWordUsuarioSQL As String
    Public Shared SID_BD_Oracle As String
    Public Shared PuertoBaseDatos As String





    Public Shared CadenaConexion1 As String
    Public Shared BaseDatos1 As String
    Public Shared ServidorSQL1 As String
    Public Shared UsuarioSQL1 As String
    Public Shared PassWordUsuarioSQL1 As String
    Public Shared SID_BD_Oracle1 As String
    Public Shared PuertoBaseDatos1 As String

    Public Shared CadenaConexion2 As String
    Public Shared BaseDatos2 As String
    Public Shared ServidorSQL2 As String
    Public Shared UsuarioSQL2 As String
    Public Shared PassWordUsuarioSQL2 As String
    Public Shared SID_BD_Oracle2 As String
    Public Shared PuertoBaseDatos2 As String

    Public Shared CadenaConexion3 As String
    Public Shared BaseDatos3 As String
    Public Shared ServidorSQL3 As String
    Public Shared UsuarioSQL3 As String
    Public Shared PassWordUsuarioSQL3 As String
    Public Shared SID_BD_Oracle3 As String
    Public Shared PuertoBaseDatos3 As String

    Public Shared CadenaConexion4 As String
    Public Shared BaseDatos4 As String
    Public Shared ServidorSQL4 As String
    Public Shared UsuarioSQL4 As String
    Public Shared PassWordUsuarioSQL4 As String
    Public Shared SID_BD_Oracle4 As String
    Public Shared PuertoBaseDatos4 As String

    Public Shared CadenaConexion5 As String
    Public Shared BaseDatos5 As String
    Public Shared ServidorSQL5 As String
    Public Shared UsuarioSQL5 As String
    Public Shared PassWordUsuarioSQL5 As String
    Public Shared SID_BD_Oracle5 As String
    Public Shared PuertoBaseDatos5 As String

    Public Shared APPName As String

End Class
Public Class clGenerales
    'Permite trabajar con consultas tanto de TIPO ExecuteNonquery como con ExecuteScalar

    'Public Shared Function Ejecutar(ByVal Sel As String, Optional ByVal NumeroCadena As Integer = 0) As Object
    '    Dim bd As New BaseDatos(NumeroCadena)

    '    Dim aff As Object
    '    aff = bd.Execute(Sel, False)
    '    bd.CerrarBD()
    '    If aff Is DBNull.Value Or aff Is Nothing Then
    '        Return 0
    '    Else
    '        Return aff
    '    End If

    'End Function

    Public Shared Function General(ByVal Campo As String, ByVal Tabla As String, ByVal Instruccion As String, Optional ByVal Condicion As String = GL_VACIO, Optional ByVal NumeroCadena As Integer = 0) As Object

        Dim bd As New BaseDatos(NumeroCadena)
        Dim Sel As String
        Dim aff As Object

        If Condicion.Trim <> GL_VACIO Then
            Condicion = Microsoft.VisualBasic.LTrim(Condicion)
            If Microsoft.VisualBasic.UCase(Microsoft.VisualBasic.Left(Condicion, 5)) <> "WHERE" Then
                Condicion = "WHERE " & Condicion
            End If
        End If

        Sel = "SELECT " & Instruccion & "(" & Campo & ") FROM " & Tabla & " " & Condicion
        aff = bd.Execute(Sel, False)

        ' bd.CerrarBD()

        If aff Is DBNull.Value Or aff Is Nothing Then
            Return 0
        Else
            Return aff
        End If



    End Function
    Public Shared Function Media(ByVal Campo As String, ByVal Tabla As String, Optional ByVal Condicion As String = GL_VACIO, Optional ByVal NumeroCadena As Integer = 0) As Double
        'Saca el valor máximo dado un campo y una tabla
        Return General(Campo, Tabla, "AVG", Condicion, NumeroCadena)
    End Function

    Public Shared Function Suma(ByVal Campo As String, ByVal Tabla As String, Optional ByVal Condicion As String = GL_VACIO, Optional ByVal NumeroCadena As Integer = 0) As Double
        'Saca el valor máximo dado un campo y una tabla
        Return General(Campo, Tabla, "SUM", Condicion, NumeroCadena)
    End Function
    Public Shared Function Maximo(ByVal Campo As String, ByVal Tabla As String, Optional ByVal Condicion As String = GL_VACIO, Optional ByVal NumeroCadena As Integer = 0) As Double
        'Saca el valor máximo dado un campo y una tabla
        Return General(Campo, Tabla, "MAX", Condicion, NumeroCadena)
    End Function

    Public Shared Function Minimo(ByVal Campo As String, ByVal Tabla As String, Optional ByVal Condicion As String = GL_VACIO, Optional ByVal NumeroCadena As Integer = 0) As Double
        'Saca el valor mínimo dado un campo y una tabla
        Return General(Campo, Tabla, "MIN", Condicion, NumeroCadena)
    End Function

    Public Shared Function Cuenta(ByVal Tabla As String, Optional ByVal Condicion As String = GL_VACIO, Optional ByVal NumeroCadena As Integer = 0) As Double
        'Cuenta el número de registros dada una tabla
        Return General("*", Tabla, "COUNT", Condicion, NumeroCadena)
    End Function

    Public Shared Function SiguienteRegistro(ByVal Campo As String, ByVal Tabla As String, Optional ByVal Condicion As String = GL_VACIO, Optional ByVal NumeroCadena As Integer = 0) As Double
        'Nos da el siguiente REGISTRO de una tabla, en el caso de que vayamos a dar de alta otro REGISTRO.
        'Trabaja con los campos que identifican los registros, deben ser númericos
        Return Maximo(Campo, Tabla, Condicion, NumeroCadena) + 1
    End Function
End Class






''JCB 11/10/12
''CAMBIOS v. AÑADIDA LA FUNCION IMPORTAR EN LA CLASE CLACTUALIZCIONES
''De esta manera, desde la aplicación, rellenamos los tabs correspondiente y luego hacemos tab.insertar y listo.

'Imports System.Data.SqlClient
'Imports System.Data
'Imports System


''Clase para manejar las Bases de Datos
'Public Class BaseDatos

'    Public cn As New SqlConnection
'    Public ds As New DataSet
'    Public dt As New DataTable
'    Public cmd As New SqlCommand

'    Public daa() As SqlDataAdapter
'    Public cbb() As SqlCommandBuilder

'    Private CadConexion As String

'    Sub New(Optional ByVal NumeroCadena As Integer = 0)
'        Select Case NumeroCadena
'            Case 0
'                CadConexion = clVariables.CadenaConexion
'            Case 1
'                CadConexion = clVariables.CadenaConexion1
'            Case 2
'                CadConexion = clVariables.CadenaConexion2
'            Case 3
'                CadConexion = clVariables.CadenaConexion3
'            Case 4
'                CadConexion = clVariables.CadenaConexion4
'            Case 5
'                CadConexion = clVariables.CadenaConexion5
'        End Select


'    End Sub

'    Public Sub GenerarCadenaConexion()
'        'Dim GL_Servidor As String = System.Net.Dns.GetHostEntry("LOCALHOST").HostName & "\SQLEXPRESS"
'        'Dim GL_BaseDatos As String
'        'cn.ConnectionString = "Data Source=" & GL_Servidor & ";Initial Catalog=" & GL_BaseDatos & ";Integrated Security=True"
'        If cn.State <> ConnectionState.Closed Then
'            CerrarBD()
'        End If
'        cn.ConnectionString = CadConexion

'    End Sub

'    Public Sub AbrirBD()
'        If cn.State <> ConnectionState.Closed Then
'            CerrarBD()
'        End If
'        cn.Open()
'    End Sub

'    Public Sub CerrarBD()
'        If cn.State <> ConnectionState.Closed Then
'            cn.Close()
'        End If
'        Try
'            SqlConnection.ClearPool(cn)
'        Catch ex As Exception

'        End Try
'    End Sub

'    Public Sub LlenarAdapter(ByVal Sel As String, ByVal Indice As Integer, Optional ByVal GenerarCommandsDinamicos As Boolean = False)
'        ReDim Preserve daa(Indice)
'        '    ReDim Preserve cbb(Indice)



'        daa(Indice) = New SqlDataAdapter(Sel, cn)

'        'cbb(Indice) = New SqlCommandBuilder(daa(Indice))
'        'Try
'        '    '    If GenerarCommandsDinamicos Then
'        '    daa(Indice).DeleteCommand = cbb(Indice).GetDeleteCommand.Clone
'        '    daa(Indice).InsertCommand = cbb(Indice).GetInsertCommand.Clone
'        '    daa(Indice).UpdateCommand = cbb(Indice).GetUpdateCommand.Clone
'        '    '    End If
'        'Catch ex As Exception

'        'End Try


'    End Sub

'    Public Sub CrearCommandBuilder(ByVal Indice As Integer, Optional ByVal GenerarCommandsDinamicos As Boolean = False)

'        ReDim Preserve cbb(Indice)

'        cbb(Indice) = New SqlCommandBuilder(daa(Indice))

'        '  cbb(Indice).ConflictOption = ConflictOption.OverwriteChanges
'        Try
'            If GenerarCommandsDinamicos Then
'                daa(Indice).DeleteCommand = cbb(Indice).GetDeleteCommand.Clone
'                daa(Indice).InsertCommand = cbb(Indice).GetInsertCommand.Clone
'                daa(Indice).UpdateCommand = cbb(Indice).GetUpdateCommand.Clone
'            End If
'        Catch ex As Exception

'        End Try


'    End Sub

'    'Funcion SobreCargada Para utilizar un DataSet de fuera o el de la clase
'    Public Sub LlenarDataSet(ByVal Sel As String, ByVal Tabla As String, Optional ByVal GenerarCommandsDinamicos As Boolean = False, Optional LlenarEsquema As Boolean = True, Optional ValoresPorDefecto As Boolean = False, Optional AbrirYCerrarBD As Boolean = True, Optional Rellenar As Boolean = False)
'        Dim Indice As Integer
'        If Rellenar Then
'            For i = 0 To ds.Tables.Count - 1
'                If ds.Tables(i).TableName.ToUpper = Tabla.ToUpper Then
'                    Indice = i + 1
'                    Exit For
'                End If
'            Next
'        Else
'            For i = 0 To ds.Tables.Count - 1
'                If ds.Tables(i).TableName.ToUpper = Tabla.ToUpper Then
'                    ds.Tables(i).Clear()
'                    Exit For
'                End If
'            Next
'        End If

'        '      ds.Clear()
'        ' ds.Relations.Clear()
'        GenerarCadenaConexion()
'        If Not Rellenar Then Indice = ds.Tables.Count
'        LlenarAdapter(Sel, Indice, GenerarCommandsDinamicos)
'        If AbrirYCerrarBD Then
'            AbrirBD()
'        End If

'        ds.EnforceConstraints = True
'        ds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema


'        If LlenarEsquema Then
'            daa(Indice).FillSchema(ds, SchemaType.Source, Tabla)
'        End If



'        daa(Indice).Fill(ds, Tabla)


'        ' ds.Tables(Tabla).Constraints.Add("pk_sid", ds.Tables(Tabla).Columns("Contador"), True)

'        CrearCommandBuilder(Indice, GenerarCommandsDinamicos)

'        If AbrirYCerrarBD Then
'            CerrarBD()
'        End If

'        If ValoresPorDefecto Then
'            PonerValoresPorDefecto(ds, Tabla)
'        End If


'    End Sub
'    Private Sub PonerValoresPorDefecto(ByRef ds As DataSet, Tabla As String)


'        Dim dtr As SqlDataReader
'        Dim bdCol As New BaseDatos
'        Dim Sel As String

'        Sel = " SELECT  C.name as Columna , A.Name as Tipo  FROM sys.TABLES T INNER JOIN sys.COLUMNS C ON T.OBJECT_ID = C.OBJECT_ID " & _
'               " INNER JOIN sys.types A ON C.system_type_id = A.system_type_id AND C.user_type_id=A.user_type_id" & _
'               " WHERE T.NAME = '" & Tabla & "'"
'        dtr = bdCol.ExecuteReader(Sel)

'        If dtr.HasRows Then
'            While dtr.Read
'                For Each col As DataColumn In ds.Tables(Tabla).Columns
'                    If col.ColumnName.ToUpper = dtr("Columna").ToString.ToUpper And col.ColumnName.ToUpper <> "CODIGO" Then
'                        If Not col.AutoIncrement Then
'                            Try


'                                Select Case dtr("Tipo").ToString.ToUpper

'                                    Case "VARCHAR"
'                                        col.DefaultValue = ""
'                                    Case "BIT"
'                                        col.DefaultValue = False
'                                    Case "INT"
'                                        col.DefaultValue = 0
'                                    Case "FLOAT"
'                                        col.DefaultValue = 0
'                                    Case "DATETIME"
'                                        col.DefaultValue = DBNull.Value
'                                    Case Else
'                                        Try
'                                            col.DefaultValue = ""
'                                        Catch ex As Exception

'                                        End Try
'                                End Select
'                            Catch ex As Exception

'                            End Try
'                        End If

'                        Exit For
'                    End If
'                Next
'            End While
'        End If
'        bdCol.CerrarBD()

'    End Sub
'    'Public Sub LlenarDataSet(ByVal Sel As String, ByVal Tabla As String, ByRef dsPasado As DataSet)

'    '    Dim Indice As Integer
'    '    '**************debe clear??????????????????
'    '    'dsPasado.Clear()
'    '    'dsPasado.Relations.Clear()
'    '    GenerarCadenaConexion()
'    '    Indice = dsPasado.Tables.Count
'    '    LlenarAdapter(Sel, Indice)
'    '    AbrirBD()
'    '    dsPasado.EnforceConstraints = False
'    '    daa(Indice).FillSchema(dsPasado, SchemaType.Source, Tabla)
'    '    daa(Indice).Fill(dsPasado, Tabla)
'    '    CerrarBD()

'    'End Sub

'    Public Sub RefrescarDatos(Optional PosicionParaActualizarSoloFilaSeleccionada As Integer = -1, Optional NombreTabla As String = "", Optional GvAActualizar As MyGridView = Nothing, Optional Bind As BindingSource = Nothing)

'        'Con este procedimiento, refrescamos el dataset desde la bd

'        'Hay 2 modos de refrescar

'        '1. Solo una fila.  En este caso pasaríamos el índice o la posicion de la fila a refrescar en el parámetro  PosicionParaActualizarSoloFilaSeleccionada
'        '                   Si estamos con un binding, pasaríamos por ejemplo BinSrc.Position o uInmueblesActivo.BinSrc.Position

'        '2. Actualizar el ds completo.En este caso NO pasamos valor al parámetro PosicionParaActualizarSoloFilaSeleccionada, lo dejamos con -1
'        '   Si el ds está enlazado a un grid y queremos que al finalizar quede todo en la posición que estaba, debemos pasar
'        '       - El objeto MyGridView donde situaremos la fila, por ejemplo Gv 
'        '       - Si trabajamos con un binding, se lo pasamos para que coja la posición acutal, si no la cojerá del grid
'        '       Si no pasamos grid ni binding, no se posicionará tras acabar

'        If NombreTabla = "" Then
'            NombreTabla = ds.Tables(0).TableName
'        End If

'        If PosicionParaActualizarSoloFilaSeleccionada >= 0 Then
'            LlenarDsEnRefrescarDatos(NombreTabla, ds, PosicionParaActualizarSoloFilaSeleccionada)
'        Else

'            Dim IndiceAnterior As Integer = -1
'            Dim TopIndexAntes As Integer = -1


'            If Not IsNothing(Bind) Then 'Esto es pq me quiero situar
'                IndiceAnterior = Bind.Position
'            Else
'                If Not IsNothing(GvAActualizar) Then 'Esto es pq me quiero situar
'                    If IndiceAnterior = -1 Then
'                        IndiceAnterior = GvAActualizar.FocusedRowHandle
'                    End If
'                End If
'            End If

'            If Not IsNothing(GvAActualizar) Then 'Esto es pq me quiero situar
'                If TopIndexAntes = -1 Then
'                    TopIndexAntes = GvAActualizar.TopRowIndex
'                End If
'            End If


'            LlenarDsEnRefrescarDatos(NombreTabla, ds)


'            If IndiceAnterior >= 0 Then
'                If Not IsNothing(Bind) Then 'Esto es pq me quiero situar
'                    Bind.Position = IndiceAnterior
'                Else
'                    If Not IsNothing(GvAActualizar) Then 'Esto es pq me quiero situar
'                        GvAActualizar.FocusedRowHandle = IndiceAnterior
'                    End If
'                End If

'            End If

'            If TopIndexAntes >= 0 Then
'                GvAActualizar.TopRowIndex = TopIndexAntes
'            End If
'        End If

'    End Sub


'    Public Sub LlenarDsEnRefrescarDatos(ByVal Tabla As String, ByRef dsPasado As DataSet, Optional PosicionParaActualizarSoloFilaSeleccionada As Integer = -1)


'        Dim Indice As Integer

'        For i = 0 To dsPasado.Tables.Count - 1
'            If dsPasado.Tables(i).TableName.ToUpper = Tabla.ToUpper Then
'                Indice = i
'                Exit For
'            End If
'        Next

'        If PosicionParaActualizarSoloFilaSeleccionada >= 0 Then
'            daa(Indice).Fill(ds, PosicionParaActualizarSoloFilaSeleccionada, 1, Tabla)
'        Else
'            ds.Tables(Indice).Clear()
'            daa(Indice).Fill(ds, Tabla)
'        End If
'        dsPasado.AcceptChanges()
'        'daa(Indice).Update(dsPasado)

'    End Sub

'    Public Sub ActualizarCambios(ByVal Tabla As String, ByRef dsPasado As DataSet, Optional RefrescarDatos As Boolean = False)

'        'Utilizando el DataSet Externo
'        Dim Indice As Integer

'        For i = 0 To dsPasado.Tables.Count - 1
'            If dsPasado.Tables(i).TableName.ToUpper = Tabla.ToUpper Then
'                Indice = i
'                Exit For
'            End If
'        Next

'        daa(Indice).Update(dsPasado.Tables(Tabla))
'        If RefrescarDatos Then
'            dsPasado.Tables(Indice).Clear()
'            daa(Indice).Fill(dsPasado, Tabla)
'        End If

'        '   MsgBox(dsPasado.Tables(Indice).Columns("Nombre")(10573))

'        '   dsPasado.Tables( Indice).Columns("Contador")(dsPasado.Tables(Indice).Rows.Count - 1) = 9


'        dsPasado.AcceptChanges()
'    End Sub
'    Public Sub ActualizarCambios(ByVal Tabla As String)
'        'Utilizando el DataSet de la clase (ds)
'        Dim Indice As Integer

'        For i = 0 To ds.Tables.Count - 1
'            If ds.Tables(i).TableName.ToUpper = Tabla.ToUpper Then
'                Indice = i
'                Exit For
'            End If
'        Next
'        daa(Indice).Update(ds.Tables(Tabla))

'    End Sub
'    'Public Sub ActualizarCambios()
'    '    'Sin DataSet, utilizando DataTable
'    '    da.Update(dt)
'    'End Sub

'    Public Function ExecuteReader(ByVal Sel As String) As SqlDataReader

'        GenerarCadenaConexion()
'        cmd = New SqlCommand(Sel, cn)
'        cmd.Connection.Open()
'        Return cmd.ExecuteReader
'        CerrarBD()
'    End Function
'    Public Sub CerrarCommand()
'        If cmd.Connection.State = ConnectionState.Open Then
'            cmd.Connection.Close()
'        End If
'    End Sub
'    Public Function Execute(ByVal Sel As String, Optional ByVal NonQuery As Boolean = True, Optional ByVal SiNuloNothingDevolver As String = "NULO") As Object

'        Dim aff As Object

'        GenerarCadenaConexion()
'        cmd = New SqlCommand(Sel, cn)
'        cmd.Connection.Open()
'        If NonQuery Then
'            aff = cmd.ExecuteNonQuery
'        Else
'            aff = cmd.ExecuteScalar
'        End If

'        cmd.Connection.Close()
'        CerrarBD()

'        If aff Is DBNull.Value Or aff Is Nothing Then
'            If SiNuloNothingDevolver = "NULO" Then
'                Return aff
'            Else
'                Return SiNuloNothingDevolver
'            End If
'        Else
'            Return aff
'        End If

'    End Function

'End Class
'Public MustInherit Class clActualizaciones

'    Public Property Tabla As String
'    Public Property Filtro As String
'    Public Property Orden As String
'    Public Property ConsultaAEjecutar As String


'    Protected MustOverride Sub CargarDatos(ByRef dr As DataRow)


'    'Public Sub Modificar(ByRef dsPasado As DataSet, ByVal Fila As Integer)

'    '    AltaModificar(False, dsPasado, Fila)

'    'End Sub




'    Public Sub Modificar(ByRef dsPasado As DataSet, ByVal dr As DataRow)

'        AltaModificar(False, dsPasado, dr)

'    End Sub
'    Public Sub Alta(ByRef dsPasado As DataSet)

'        AltaModificar(True, dsPasado)

'    End Sub
'    Private Sub AltaModificar(ByVal Alta As Boolean, ByRef dsPasado As DataSet, Optional ByVal dr As DataRow = Nothing)

'        Dim dt As New DataTable
'        dt = dsPasado.Tables(Tabla)

'        If Alta Then
'            dr = dt.NewRow
'        Else
'            '     dr = dt.Rows(Fila)
'            dr.BeginEdit()
'        End If

'        CargarDatos(dr)

'        If Alta Then
'            dt.Rows.Add(dr)
'        Else
'            dr.EndEdit()
'        End If
'    End Sub

'    Public Sub Datos(bd As BaseDatos, Optional Sel As String = "", Optional NombreTabla As String = "", Optional ByVal GenerarCommandsDinamicos As Boolean = False, Optional NumeroCadena As Integer = 0, Optional LlenarEsquema As Boolean = True, Optional ValoresPorDefecto As Boolean = False, Optional AbrirYCerrarBD As Boolean = True)

'        If NombreTabla = "" Then
'            NombreTabla = Tabla
'        End If
'        LlenarDatos(bd, Sel, NombreTabla, GenerarCommandsDinamicos, NumeroCadena, LlenarEsquema, ValoresPorDefecto, AbrirYCerrarBD)

'    End Sub
'    Private Sub LlenarDatos(bd As BaseDatos, Optional Sel As String = "", Optional NombreTabla As String = "", Optional ByVal GenerarCommandsDinamicos As Boolean = False, Optional NumeroCadena As Integer = 0, Optional LlenarEsquema As Boolean = True, Optional ValoresPorDefecto As Boolean = False, Optional AbrirYCerrarBD As Boolean = True)

'        If Sel = "" Then
'            Sel = "SELECT * FROM " & NombreTabla & Filtro & Orden
'        End If
'        bd.LlenarDataSet(Sel, NombreTabla, GenerarCommandsDinamicos, LlenarEsquema, ValoresPorDefecto, AbrirYCerrarBD)

'    End Sub


'    Public Function Insertar(Optional NumeroCadena As Integer = 0) As Boolean

'        Dim bd As New BaseDatos(NumeroCadena)
'        Dim Sel As String = "SELECT TOP 0 * FROM " & Tabla
'        bd.LlenarDataSet(Sel, Tabla)
'        AltaModificar(True, bd.ds)


'        Try
'            bd.ActualizarCambios(Tabla, bd.ds)
'            Return True
'        Catch ex As SqlClient.SqlException


'            Throw New Exception("Error al insertar.", ex)

'            'If ex.Number = 2627 Then

'            '    MsgBox(GL_ValorDuplicado)
'            'Else
'            '    MsgBox(ex.Message)
'            'End If

'            bd.ds.RejectChanges()
'            Return False
'        End Try


'    End Function




'    'Private Sub AltaModificar(ByVal Alta As Boolean, ByRef dsPasado As DataSet, Optional ByVal Fila As Integer = 0)

'    '    Dim dt As DataTable
'    '    Dim dr As DataRow
'    '    dt = dsPasado.Tables(Tabla)

'    '    If Alta Then
'    '        dr = dt.NewRow
'    '    Else
'    '        dr = dt.Rows(Fila)
'    '        dr.BeginEdit()
'    '    End If

'    '    CargarDatos(dr)

'    '    If Alta Then
'    '        dt.Rows.Add(dr)
'    '    Else
'    '        dr.EndEdit()
'    '    End If
'    'End Sub

'    'Public Sub Borrar(ByRef dsPasado As DataSet, ByVal Fila As Integer)

'    '    Dim dt As DataTable
'    '    Dim dr As DataRow
'    '    dt = dsPasado.Tables(Tabla)
'    '    dr = dt.Rows(Fila)
'    '    dr.Delete()

'    'End Sub


'    Public Sub Borrar(ByVal dr As DataRow)

'        dr.Delete()

'    End Sub



'End Class
'Public Class clVariables

'    Public Shared UsuarioFTP As String
'    Public Shared PassWordFTP As String
'    Public Shared BaseDatosFTP As String
'    Public Shared SoftwareFTP As String
'    Public Shared RutaInicialFTP As String
'    Public Shared RutaCompletaFTP As String

'    Public Shared CadenaConexion As String
'    Public Shared BaseDatos As String
'    Public Shared ServidorSQL As String
'    Public Shared UsuarioSQL As String
'    Public Shared RutaServidor As String
'    Public Shared PassWordUsuarioSQL As String

'    Public Shared CadenaConexion1 As String
'    Public Shared BaseDatos1 As String
'    Public Shared ServidorSQL1 As String
'    Public Shared UsuarioSQL1 As String
'    Public Shared PassWordUsuarioSQL1 As String

'    Public Shared CadenaConexion2 As String
'    Public Shared BaseDatos2 As String
'    Public Shared ServidorSQL2 As String
'    Public Shared UsuarioSQL2 As String
'    Public Shared PassWordUsuarioSQL2 As String

'    Public Shared CadenaConexion3 As String
'    Public Shared BaseDatos3 As String
'    Public Shared ServidorSQL3 As String
'    Public Shared UsuarioSQL3 As String
'    Public Shared PassWordUsuarioSQL3 As String

'    Public Shared CadenaConexion4 As String
'    Public Shared BaseDatos4 As String
'    Public Shared ServidorSQL4 As String
'    Public Shared UsuarioSQL4 As String
'    Public Shared PassWordUsuarioSQL4 As String

'    Public Shared CadenaConexion5 As String
'    Public Shared BaseDatos5 As String
'    Public Shared ServidorSQL5 As String
'    Public Shared UsuarioSQL5 As String
'    Public Shared PassWordUsuarioSQL5 As String


'End Class
'Public Class clGenerales
'    'Permite trabajar con consultas tanto de tipo ExecuteNonquery como con ExecuteScalar

'    Public Shared Function Ejecutar(ByVal Sel As String, Optional ByVal NumeroCadena As Integer = 0) As Object
'        Dim bd As New BaseDatos(NumeroCadena)

'        Dim aff As Object
'        aff = bd.Execute(Sel, False)
'        bd.CerrarBD()
'        If aff Is DBNull.Value Or aff Is Nothing Then
'            Return 0
'        Else
'            Return aff
'        End If

'    End Function

'    Public Shared Function General(ByVal Campo As String, ByVal Tabla As String, ByVal Instruccion As String, Optional ByVal Condicion As String = "", Optional ByVal NumeroCadena As Integer = 0) As Object
'        Dim bd As New BaseDatos(NumeroCadena)
'        Dim Sel As String
'        Dim aff As Object

'        If Condicion <> "" Then
'            Condicion = Microsoft.VisualBasic.LTrim(Condicion)
'            If Microsoft.VisualBasic.UCase(Microsoft.VisualBasic.Left(Condicion, 5)) <> "WHERE" Then
'                Condicion = "WHERE " & Condicion
'            End If
'        End If

'        Sel = "SELECT " & Instruccion & "(" & Campo & ") FROM " & Tabla & " " & Condicion

'        aff = bd.Execute(Sel, False)

'        bd.CerrarBD()

'        If aff Is DBNull.Value Or aff Is Nothing Then
'            Return 0
'        Else
'            Return aff
'        End If



'    End Function
'    Public Shared Function Media(ByVal Campo As String, ByVal Tabla As String, Optional ByVal Condicion As String = "", Optional ByVal NumeroCadena As Integer = 0) As Double
'        'Saca el valor máximo dado un campo y una tabla
'        Return General(Campo, Tabla, "AVG", Condicion, NumeroCadena)
'    End Function

'    Public Shared Function Suma(ByVal Campo As String, ByVal Tabla As String, Optional ByVal Condicion As String = "", Optional ByVal NumeroCadena As Integer = 0) As Double
'        'Saca el valor máximo dado un campo y una tabla
'        Return General(Campo, Tabla, "SUM", Condicion, NumeroCadena)
'    End Function
'    Public Shared Function Maximo(ByVal Campo As String, ByVal Tabla As String, Optional ByVal Condicion As String = "", Optional ByVal NumeroCadena As Integer = 0) As Double
'        'Saca el valor máximo dado un campo y una tabla
'        Return General(Campo, Tabla, "MAX", Condicion, NumeroCadena)
'    End Function

'    Public Shared Function Minimo(ByVal Campo As String, ByVal Tabla As String, Optional ByVal Condicion As String = "", Optional ByVal NumeroCadena As Integer = 0) As Double
'        'Saca el valor mínimo dado un campo y una tabla
'        Return General(Campo, Tabla, "MIN", Condicion, NumeroCadena)
'    End Function

'    Public Shared Function Cuenta(ByVal Tabla As String, Optional ByVal Condicion As String = "", Optional ByVal NumeroCadena As Integer = 0) As Double
'        'Cuenta el número de registros dada una tabla
'        Return General("*", Tabla, "COUNT", Condicion, NumeroCadena)
'    End Function

'    Public Shared Function SiguienteRegistro(ByVal Campo As String, ByVal Tabla As String, Optional ByVal Condicion As String = "", Optional ByVal NumeroCadena As Integer = 0) As Double
'        'Nos da el siguiente registro de una tabla, en el caso de que vayamos a dar de alta otro registro.
'        'Trabaja con los campos que identifican los registros, deben ser númericos
'        Return Maximo(Campo, Tabla, Condicion, NumeroCadena) + 1
'    End Function
'End Class




