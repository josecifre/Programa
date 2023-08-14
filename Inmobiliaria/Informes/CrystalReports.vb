
'COMO USAR ESTA FUNCIÓN
'Hay 2 formas de conexión, con un DataSet o conexión directa a la bd

'Para trabajar con DataSet o DataTable, primero hay que hacer un Esquema XML

'Dim DT As DataTable
'DT.WriteXmlSchema(RutaFichero & ".xml")

'y crear el report con este esquema.
'Luego el esquema se puede eliminar

'Para Filtrar
'rpt.RecordSelectionFormula = "{clientes.ciudad} = 'Madrid'"
'rpt.RecordSelectionFormula = "{Pedidos.NumPedido} = 10451"
'rpt.RecordSelectionFormula = "{Pedidos.FechaPedido} = #08/07/97#"


'****PASO DE PARAMETROS********

'Dim Par As New List(Of CrystalParametros)

'Par.Add(New CrystalParametros("Param1", "Valor1"))
'Par.Add(New CrystalParametros("Param2", 2))
'Par.Add(New CrystalParametros("Param3", #2/3/2009#))
'****FIN***PASO DE PARAMETROS********

'****PARA ORDENAR********
'Dim Orden As New List(Of CrystalOrden)
'Orden.Add(New CrystalOrden("Clientes", "Nombre"))
'****FIN***PASO DE PARAMETROS********

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Module CrystalReports

    Public Enum EnumDestino As Integer
        Pantalla
        Impresora
        Fichero
    End Enum

    Public Sub pr_InformeCrystal(ByVal rpt As ReportDocument, Optional ByRef dt As System.Data.DataTable = Nothing, Optional ByRef ds As System.Data.DataSet = Nothing, Optional ByVal Destino As EnumDestino = EnumDestino.Pantalla, Optional ByVal Copias As Integer = 1, Optional ByVal Titulo As String = "", Optional ByVal Par As List(Of CrystalParametros) = Nothing, Optional ByVal RecordSelectionFormula As String = "", Optional ByVal Orden As List(Of CrystalOrden) = Nothing, Optional ByVal Impresora As String = "", Optional ByVal RutaFichero As String = "", Optional ByVal TipoDocumento As ExportFormatType = ExportFormatType.PortableDocFormat, Optional ByVal LoMuestroModal As Boolean = False)

        'Dim rpt As New ReportDocument

        ''Comprobamos si existe el report
        'If IO.File.Exists(NombreReport) = False Then
        '    MessageBox.Show("Reporte ya no existe o fue movido de ubicacion.", "Error buscando reporte.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        '    Exit Sub
        'End If

        ''Cargamos el ReportDocument
        'rpt.Load(NombreReport)


        ' Dim rpt As New rptRendimientoTrabajosConDetalle

        If dt IsNot Nothing Then
            rpt.SetDataSource(dt)
        Else
            If ds IsNot Nothing Then

                rpt.SetDataSource(ds)

            Else

                'Establecemos la conexión con la base de datos
                Dim rptConnectionInfo As New ConnectionInfo
                Dim rptTableLogOnInfo As TableLogOnInfo
                Dim rptListTables As Tables
                Dim rptTable As Table
                Dim rptReady As Boolean

                rptConnectionInfo.ServerName = clVariables.ServidorSQL
                rptConnectionInfo.DatabaseName = clVariables.BaseDatos
                rptConnectionInfo.UserID = clVariables.UsuarioSQL
                rptConnectionInfo.Password = clVariables.PassWordUsuarioSQL
                rptConnectionInfo.IntegratedSecurity = False

                rptListTables = rpt.Database.Tables
                For Each rptTable In rptListTables
                    rptTableLogOnInfo = rptTable.LogOnInfo
                    rptTableLogOnInfo.ConnectionInfo = rptConnectionInfo
                    rptTable.ApplyLogOnInfo(rptTableLogOnInfo)
                    rptReady = rptTable.TestConnectivity()

                    If rptReady = False Then
                        MessageBox.Show("Usuario y Contraseña invalidos, Error al establecer conexion con el servidor.", "Error en conexion.")
                        frmReport.crw.ReportSource = Nothing
                        Exit Sub
                    End If
                Next


                Dim subrpt As ReportDocument

                For Each subrpt In rpt.Subreports

                    rptListTables = subrpt.Database.Tables
                    For Each rptTable In rptListTables
                        rptTableLogOnInfo = rptTable.LogOnInfo
                        rptTableLogOnInfo.ConnectionInfo = rptConnectionInfo
                        rptTable.ApplyLogOnInfo(rptTableLogOnInfo)
                        rptReady = rptTable.TestConnectivity()

                        If rptReady = False Then
                            MessageBox.Show("Usuario y Contraseña invalidos, Error al establecer conexion con el servidor.", "Error en conexion.")
                            frmReport.crw.ReportSource = Nothing
                            Exit Sub
                        End If
                    Next

                Next
            End If
        End If


        'Cargamos las distintas opciones
        rpt.SummaryInfo.ReportTitle = Titulo

        'Insertando parámetros
        If Par IsNot Nothing Then

            For i = 0 To Par.Count - 1
                If Par(i).SubReport <> "" Then


                    Dim NombreSubreport As String = Par(i).SubReport
                    Dim NombreParametroSubReport As String = Par(i).Nombre

                    Dim myParameterFieldDefinitions As ParameterFieldDefinitions = rpt.DataDefinition.ParameterFields
                    Dim myParameterFieldDefinition As ParameterFieldDefinition = myParameterFieldDefinitions(NombreParametroSubReport, NombreSubreport)

                    myParameterFieldDefinition.CurrentValues.Clear()

                    Dim myParameterRangeValue As ParameterDiscreteValue = New ParameterDiscreteValue()
                    myParameterRangeValue.Value = Par(i).Valor

                    myParameterFieldDefinition.CurrentValues.Add(myParameterRangeValue)
                    myParameterFieldDefinition.ApplyCurrentValues(myParameterFieldDefinition.CurrentValues)

                Else
                    rpt.SetParameterValue(Par(i).Nombre, Par(i).Valor)
                End If

            Next
        End If

        If RecordSelectionFormula <> "" Then
            rpt.RecordSelectionFormula = RecordSelectionFormula
        End If

        'Ordenando listados
        If Orden IsNot Nothing Then
            For i = 0 To Orden.Count - 1
                rpt.DataDefinition.SortFields.Item(i).Field = rpt.Database.Tables(Orden(i).Tabla).Fields(Orden(i).Campo)
            Next
        End If

        'Try

        '    Dim GraficoExcel As CrystalDecisions.CrystalReports.Engine.ReportObject
        '    GraficoExcel = rpt.ReportDefinition.ReportObjects("Picture11")

        'Catch ex As Exception

        '   End Try

        Select Case Destino
            Case EnumDestino.Pantalla
                frmReport.crw.ReportSource = rpt
                If LoMuestroModal Then
                    frmReport.ShowDialog()
                Else
                    frmReport.Show()
                End If

            Case EnumDestino.Impresora
                If Impresora <> "" Then
                    rpt.PrintOptions.PrinterName = Impresora
                End If

                Try
                    rpt.PrintToPrinter(Copias, False, 0, 0)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            Case EnumDestino.Fichero
                If RutaFichero <> "" Then
                    rpt.ExportToDisk(TipoDocumento, RutaFichero)
                    '     rpt.Export()
                Else
                    MsgBox("No se ha indicado la ruta de destino")
                End If

        End Select

    End Sub
    Public Class CrystalParametros

        Public ReadOnly Nombre As String
        Public ReadOnly Valor As Object
        Public ReadOnly SubReport As String

        Public Sub New(ByVal Nom As String, ByVal Val As Object, Optional ByVal SubRpt As String = Nothing)

            Nombre = Nom
            Valor = Val
            SubReport = SubRpt

        End Sub

    End Class

    Public Class CrystalOrden

        Public ReadOnly Tabla As String
        Public ReadOnly Campo As Object

        Public Sub New(ByVal Tabl As String, ByVal Camp As String)

            Tabla = Tabl
            Campo = Camp

        End Sub

    End Class

End Module
