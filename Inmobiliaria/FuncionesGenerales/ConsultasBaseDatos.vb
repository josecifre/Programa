
Imports System.Data.SqlClient
Imports System.Data
Imports System

Public Class ConsultasBaseDatos
    'Public Shared Function MarcaDeTiempoHaCambiado(ByVal Tabla As String, ByVal MarcaDeTiempo As String, Optional ByVal NumeroCadena As Integer = 0) As Boolean


    '    Try


    '        Dim Sel As String

    '        Dim sMarcaTiempo As String
    '        sMarcaTiempo = "0x"
    '        For i = 0 To MarcaDeTiempo.Length - 1
    '            sMarcaTiempo = sMarcaTiempo + Right("00" & Hex(MarcaDeTiempo(i)), 2)
    '        Next i
    '        Sel = "SELECT COUNT(*) FROM " & Tabla & " WHERE MarcaDeTiempo = " & sMarcaTiempo
    '        Dim aff As Object
    '        aff = BD_CERO.Execute(Sel, False)
    '        If aff Is DBNull.Value Or aff Is Nothing Then
    '            Return True
    '        Else
    '            If aff = 0 Then
    '                Return True
    '            Else
    '                Return False
    '            End If
    '        End If

    '    Catch ex As Exception
    '        Return False
    '    End Try

    'End Function
    Public Shared Sub InsertarEmailConfiguracion(ByVal EMail As String, ByVal Usuario As String, ByVal NombreMostrar As String, ByVal Contrasena As String, ByVal SMTP As String, ByVal POP3Host As String, ByVal PuertoSMPT As Integer, ByVal PuertoPOP3 As Integer, ByVal Asunto As String, ByVal Url As String, ByVal Mensaje As String, ByVal html As Boolean, ByVal SSL As Boolean, Optional ByVal NumeroCadena As Integer = 0) 'As Integer

        'Dim Sel As String
        FuncionesBD.sp_InsertarEmailConfiguracion(DatosEmpresa.Codigo, EMail, Usuario, NombreMostrar, Contrasena, SMTP, POP3Host, PuertoSMPT, PuertoPOP3, FuncionesGenerales.Funciones.pf_ReplaceComillas(Asunto), FuncionesGenerales.Funciones.pf_ReplaceComillas(Url), FuncionesGenerales.Funciones.pf_ReplaceComillas(Mensaje), FuncionesGenerales.Funciones.pf_ReplaceTrueFalse(html), FuncionesGenerales.Funciones.pf_ReplaceTrueFalse(SSL))
 

    End Sub

        Public Shared Function ObtenerInmueblesParaConcertarCitas(CodigoEmpresa As Integer, Delegacion As Integer, Optional ByVal NumeroCadena As Integer = 0) As DataTable

        Dim Sel As String

        Sel = "SELECT Contador, Referencia, Poblacion, " & Funciones.SQL_CASE({"Via <> ''", "Via = ''"}, {"Via " & GL_SQL_SUMA & "' '" & GL_SQL_SUMA & " Direccion", "Direccion"}) & " AS Direccion FROM Inmuebles WHERE CodigoEmpresa = " & CodigoEmpresa & " AND Delegacion = " & Delegacion & " ORDER BY Referencia"

        Dim bd As New BaseDatos(NumeroCadena)
        bd.LlenarDataSet(Sel, "Inmuebles")
        Return bd.ds.Tables("Inmuebles")

    End Function



    Public Shared Function ObtenerDescripcionInmueble2(ByVal ContadorInmueble As Integer, Optional ByVal FormatoHTML As Integer = 1, Optional ByVal SacarReferencia As Boolean = True, Optional ByVal DevolverPrecio As Boolean = True) As String

        Dim TablaInmuebles As String = "Inmuebles"



        Dim Sel As String = "SELECT * FROM " & TablaInmuebles & " WHERE Contador = " & ContadorInmueble

        Dim Texto As String = ""

        Dim dtr As Object
        Dim bdob As New BaseDatos
        dtr = bdob.ExecuteReader(Sel)

        If Not dtr.hasrows Then
            dtr.close()

            Return Texto
        End If

        dtr.read()

        Dim TipoVivienda As String
        If dtr("Tipo") = "CASA" Then
            TipoVivienda = "CASA INDEPENDIENTE"
        Else
            TipoVivienda = dtr("Tipo")
        End If


        If SacarReferencia Then

            If FormatoHTML = 1 Then
                Texto = Texto & "<font color=""blue""><u> "
            End If

            Texto = "Ref " & " - "
        Else
            Texto = ""
        End If
         

        If SacarReferencia Then
            Texto = Texto & dtr("Referencia")
        End If


        If FormatoHTML = 1 Then
            Texto = Texto & "</u></font>"
        End If

        If FormatoHTML = 1 Then
            Texto = Texto & "<br> "
        Else
            Texto = Texto & vbCrLf
        End If

        '  Texto = Texto & " - " & TipoVivienda
        Texto = Texto & TipoVivienda

        If Not IsDBNull(dtr("Estado")) Then
            Texto = Texto & " " & dtr("Estado")
        End If

        Texto = Texto & " EN " & dtr("TipoVenta")

        Texto = Texto & " EN " & dtr("Poblacion")

        If dtr("Metros") > 0 Then
            Texto = Texto & ", DE " & dtr("Metros").ToString & " m²"
        End If

        If dtr("Altura") = -1 Then
            Texto = Texto & ", EN ENTRESUELO"
        End If

        If dtr("Altura") = -2 Then
            Texto = Texto & ", EN PLANTA BAJA"
        End If

        If dtr("Altura") > 0 Then
            Texto = Texto & ", EN " & dtr("Altura").ToString & "ª PLANTA"
        End If

        If Not IsDBNull(dtr("Ascensor")) AndAlso dtr("Ascensor") Then
            Texto = Texto & ", CON ASCENSOR"
        Else
            If Not IsDBNull(dtr("Altura")) AndAlso dtr("Altura") > 0 Then
                Texto = Texto & ", SIN ASCENSOR"
            End If
        End If

        If Not IsDBNull(dtr("Habitaciones")) AndAlso dtr("Habitaciones") = 1 Then
            Texto = Texto & ", 1 HABITACION"
        Else
            If Not IsDBNull(dtr("Habitaciones")) AndAlso dtr("Habitaciones") > 1 Then
                Texto = Texto & ", " & dtr("Habitaciones") & " HABITACIONES"
            End If
        End If

        If Not IsDBNull(dtr("Banos")) AndAlso dtr("Banos") = 1 Then
            Texto = Texto & ", 1 BAÑO"
        Else
            If Not IsDBNull(dtr("Banos")) AndAlso dtr("Banos") > 1 Then
                Texto = Texto & ", " & dtr("Banos") & " BAÑOS"
            End If
        End If

        If Not IsDBNull(dtr("Piscina")) AndAlso dtr("Piscina") Then
            Texto = Texto & ", PISCINA"
        End If

        If Not IsDBNull(dtr("CocinaOffice")) AndAlso dtr("CocinaOffice") Then
            Texto = Texto & ", COCINA OFFICE"
        End If

        If Not IsDBNull(dtr("Galeria")) AndAlso dtr("Galeria") Then
            Texto = Texto & ", GALERIA"
        End If

        If Not IsDBNull(dtr("Amueblado")) AndAlso dtr("Amueblado") Then
            Texto = Texto & ", AMUEBLADO"
        End If

        If dtr("Terraza") Then
            If dtr("MTerraza") > 0 Then
                If dtr("MTerraza2") > 0 Then
                    Texto = Texto & ", 2 TERRAZAS DE " & dtr("MTerraza").ToString & " y " & dtr("MTerraza2").ToString & "  m²"
                Else
                    Texto = Texto & ", TERRAZA DE " & dtr("MTerraza").ToString & "  m²"
                End If
            Else
                Texto = Texto & ", TERRAZA"
            End If
        End If

        If dtr("Balcon") Then
            If dtr("MBalcon") > 0 Then
                If dtr("MBalcon2") > 0 Then
                    Texto = Texto & ", 2 BALCONES DE " & dtr("MBalcon").ToString & " y " & dtr("MBalcon2").ToString & "  m²"
                Else
                    Texto = Texto & ", BALCÓN DE " & dtr("MBalcon").ToString & "  m²"
                End If
            Else
                Texto = Texto & ", BALCÓN"
            End If
        End If

        If dtr("Patio") Then
            If dtr("MPatio") > 0 Then
                If dtr("MPatio2") > 0 Then
                    Texto = Texto & ", 2 PATIOS DE " & dtr("MPatio").ToString & " y " & dtr("MPatio2").ToString & "  m²"
                Else
                    Texto = Texto & ", PATIO DE " & dtr("MPatio").ToString & "  m²"
                End If
            Else
                Texto = Texto & ", PATIO"
            End If
        End If



        Dim TextoJardin As String = ""

        If dtr("Jardin") Then
            If InStr(dtr("Jardin"), "CHALET", CompareMethod.Text) > 0 OrElse InStr(dtr("Jardin"), "TERRENO", CompareMethod.Text) > 0 Then
                TextoJardin = ", PARCELA"
            Else
                TextoJardin = ", JARDÍN"
            End If
            If dtr("MJardin") > 0 Then
                TextoJardin = TextoJardin & ", DE " & dtr("MJardin").ToString & "  m²"
            End If

        End If

        If TextoJardin <> "" Then
            Texto = Texto & TextoJardin
        End If

        If Not IsDBNull(dtr("VistasAlMar")) AndAlso dtr("VistasAlMar") Then
            Texto = Texto & ", VISTAS AL MAR"
        End If

        If dtr("Duplex") Then
            Texto = Texto & ", PISO DÚPLEX"
        End If

        If dtr("Orientacion").ToString <> "" Then
            Texto = Texto & ", ORIENTACION " & dtr("Orientacion").ToString
        End If

        If dtr("Zona").ToString <> "" Then
            Texto = Texto & ", ZONA " & dtr("Zona").ToString
        End If

        If Not IsDBNull(dtr("ZonaComercial")) AndAlso dtr("ZonaComercial") Then
            Texto = Texto & ", ZONA COMERCIAL"
        End If

        If dtr("Extras").ToString <> "" Then
            Texto = Texto & ", " & dtr("Extras").ToString.Trim
        End If



        Dim sMTrastero As String = ""
        If dtr("MTrastero") > 0 Then
            sMTrastero = " DE " & dtr("MTrastero").ToString & " m²"
        End If


        Dim sMGaraje As String = ""
        If dtr("MGaraje") > 0 Then
            sMGaraje = " DE " & dtr("MGaraje").ToString & " m²"
        End If

        Dim GarajeCerr As String = ""
        If dtr("GarajeCerrado") Then
            GarajeCerr = " CERRADO"
        End If




        Dim TextoIncluido As String = ""
        Dim FaltaPunto As Boolean = False
        Dim TextoTrasteroVenta As String = ""
        Dim TextoOpcional As String = ""

        If IsDBNull(dtr("Trastero")) OrElse dtr("Trastero") Then
            FaltaPunto = True
            TextoTrasteroVenta = " TRASTERO"
            If IsDBNull(dtr("Trastero")) Then
                TextoOpcional = " OPCIONAL"
                TextoTrasteroVenta = TextoTrasteroVenta
            Else
                If IsDBNull(dtr("Garaje")) OrElse Not dtr("Garaje") Then
                    TextoIncluido = " INCLUIDO"
                End If
            End If
            TextoTrasteroVenta = TextoTrasteroVenta & sMTrastero & TextoIncluido & TextoOpcional
        End If


        TextoOpcional = ""
        Dim TextoGarajeVenta As String = ""
        If IsDBNull(dtr("Garaje")) OrElse dtr("Garaje") Then
            FaltaPunto = True
            If TextoTrasteroVenta <> "" Then
                TextoGarajeVenta = " Y GARAJE"
            Else
                TextoGarajeVenta = " GARAJE"
            End If

            If IsDBNull(dtr("Garaje")) Then
                TextoGarajeVenta = TextoGarajeVenta
                TextoIncluido = ""
                TextoOpcional = " OPCIONAL"
            Else
                'TextoGarajeVenta = " INCLUIDO"

                If Not IsDBNull(dtr("Trastero")) AndAlso dtr("Trastero") Then
                    TextoIncluido = " INCLUIDOS"
                Else
                    TextoIncluido = " INCLUIDO"
                End If

                'If TextoIncluido = " INCLUIDO" Then
                '    TextoIncluido = " INCLUIDOS"
                'Else
                '    TextoIncluido = " INCLUIDO"
                'End If

            End If

            TextoGarajeVenta = TextoGarajeVenta & GarajeCerr & sMGaraje & TextoOpcional

            Dim TextoTrasteroGarajeVenta As String
            TextoTrasteroGarajeVenta = TextoTrasteroVenta & TextoGarajeVenta & TextoIncluido

            If TextoTrasteroGarajeVenta <> "" Then
                TextoTrasteroGarajeVenta = "," & TextoTrasteroGarajeVenta
            End If

            Texto = Texto + TextoTrasteroGarajeVenta

        End If


        If FaltaPunto Then
            Texto = Texto + "."
        End If


        'If dtr("MPlaya") <> 5000 Then
        '    '     Texto = Texto + "DISTANCIA A LA PLAYA " & dtr("MPlaya").ToString & " m"
        '    Texto = Texto + " A " & dtr("MPlaya").ToString & " m DE LA PLAYA"
        'End If

       
        'PrimeraLineaPlaya

        If dtr("PrimeraLineaPlaya") = GL_SQL_VALOR_1 And dtr("MPlaya") >= 0 Then
            Texto = Texto + ", EN PRIMERA LINEA, A " & dtr("MPlaya").ToString & " m DE LA PLAYA"
        Else
            If dtr("PrimeraLineaPlaya") = GL_SQL_VALOR_1 And Not dtr("MPlaya") >= 0 Then
                Texto = Texto + ", EN PRIMERA LINEA DE PLAYA"
            Else
                If Not dtr("PrimeraLineaPlaya") = GL_SQL_VALOR_1 And dtr("MPlaya") >= 0 Then
                    Texto = Texto + ", A " & dtr("MPlaya").ToString & " m DE LA PLAYA"
                Else

                End If
            End If
        End If
        'If dtr("MPlaya") >= 0 Then
        '    '     Texto = Texto + "DISTANCIA A LA PLAYA " & dtr("MPlaya").ToString & " m"
        '    Texto = Texto + ", A " & dtr("MPlaya").ToString & " m DE LA PLAYA"
        'End If

        If dtr("Tipo") = "GARAJE" OrElse dtr("Tipo") = "SOLAR" OrElse dtr("Tipo") = "TERRENO" OrElse dtr("Tipo") = "TERRENO CON CASA" Then
        Else
            If IsDBNull(dtr("CalificacionEnergetica")) OrElse dtr("CalificacionEnergetica") = "" Then
                Texto = Texto + ". CALIFICACIÓN ENERGÉTICA: En proceso"
            Else
                Texto = Texto + ". CALIFICACIÓN ENERGÉTICA: " & dtr("CalificacionEnergetica").ToString
            End If
        End If

        Texto = Texto + "."

        'añadir No animales prop
        Sel = "SELECT NOAnimales FROM Propietarios WHERE Contador = (SELECT ContadorPropietario FROM Inmuebles WHERE Contador = " & ContadorInmueble & ")"
        Dim NoAnimales As Boolean = BD_CERO.Execute(Sel, False)

        If NoAnimales Then
            Texto = Texto + " <br>" + "No se aceptan determinados animales. Consultar en la oficina."
        End If

        Dim TextoTrastero As String = ""
        Dim TextoGaraje As String = ""


        If DevolverPrecio Then
            If FormatoHTML Then
                Texto = Texto + " <br>"
            Else
                Texto = Texto + " "
                '   Texto = Texto + vbCrLf
            End If

            Texto = Texto + "PRECIO: " & FormatNumber(dtr("Precio"), 0) + " €"
            If dtr("TipoVenta").ToString.Length > Len(GL_Palabra_Alquiler) - 1 AndAlso Microsoft.VisualBasic.Left(dtr("TipoVenta").ToString, Len(GL_Palabra_Alquiler)) = GL_Palabra_Alquiler Then
                Texto = Texto & "/mes"
            End If

            If Not IsDBNull(dtr("ComunidadIncluida")) AndAlso dtr("ComunidadIncluida") AndAlso
                dtr("TipoVenta").ToString.Length > Len(GL_Palabra_Alquiler) - 1 AndAlso Microsoft.VisualBasic.Left(dtr("TipoVenta").ToString, Len(GL_Palabra_Alquiler)) = GL_Palabra_Alquiler Then 'ROBERTO 26/05/2017
                Texto &= " Comunidad Incluida"
            End If
            ' Funciones.SQL_CASE({"FianzaAlquiler < 1", "FianzaAlquiler > 0"}, {"'<b><font color=""red""> '" & GL_SQL_SUMA & Funciones.SQL_CONVERT("VARCHAR", "FianzaAlquiler") & GL_SQL_SUMA & "' Mes/es de Fianza</font></color></b>'", "''"}) & GL_SQL_SUMA & _

            If Not IsDBNull(dtr("FianzaAlquiler")) AndAlso dtr("FianzaAlquiler") > 0 Then
                Dim fianza As Integer = dtr("FianzaAlquiler")
                Texto &= ", " & fianza & " Mes" & IIf(fianza > 1, "es", "") & " de Fianza"
            End If

            If IsDBNull(dtr("Trastero")) Then
                If (Not IsDBNull(dtr("PrecioTrastero")) AndAlso dtr("PrecioTrastero") > 0) AndAlso IsDBNull(dtr("Trastero")) Then
                    TextoTrastero = TextoTrastero & " TRASTERO " & Microsoft.VisualBasic.FormatNumber(dtr("PrecioTrastero"), 0) & " €"
                    If dtr("TipoVenta").ToString.Length > Len(GL_Palabra_Alquiler) - 1 AndAlso Microsoft.VisualBasic.Left(dtr("TipoVenta").ToString, Len(GL_Palabra_Alquiler)) = GL_Palabra_Alquiler Then
                        TextoTrastero = TextoTrastero & "/mes"
                    End If
                End If
            End If

            If IsDBNull(dtr("Garaje")) Then
                If (Not IsDBNull(dtr("PrecioGaraje")) AndAlso dtr("PrecioGaraje") > 0) AndAlso IsDBNull(dtr("Garaje")) Then
                    TextoGaraje = TextoGaraje & " Garaje " & Microsoft.VisualBasic.FormatNumber(dtr("PrecioGaraje"), 0) & " €"
                    If dtr("TipoVenta").ToString.Length > Len(GL_Palabra_Alquiler) - 1 AndAlso Microsoft.VisualBasic.Left(dtr("TipoVenta").ToString, Len(GL_Palabra_Alquiler)) = GL_Palabra_Alquiler Then
                        TextoTrastero = TextoTrastero & "/mes"
                    End If
                End If
            End If
        End If




        Texto = Texto & TextoTrastero & TextoGaraje







        If dtr("Oportunidad") And FormatoHTML Then
            Texto = "<b>" & Texto & " </b>"
        End If
        If FormatoHTML Then
            Texto = "<font size=3> " & Texto & " </font>"
        End If

        dtr.Close()







        Return Texto





    End Function


    Public Shared Function ObtenerNombreCliente(ByVal ContadorCliente As Integer, Optional ByVal NumeroCadena As Integer = 0) As String

        Dim Sel As String
        Sel = "select Nombre FROM Clientes WHERE Contador = " & ContadorCliente
        Dim bd As New BaseDatos(NumeroCadena)
        Return bd.Execute(Sel, False)

    End Function



    Public Shared Function ObtenerNombrePropietario(ByVal ContadorPropietario As Integer, Optional ByVal NumeroCadena As Integer = 0) As String

        Dim Sel As String
        Sel = "select Nombre FROM Propietarios WHERE Contador = " & ContadorPropietario
        'Dim bd As New BaseDatos(NumeroCadena)
        Return BD_CERO.Execute(Sel, False)

    End Function

    Public Shared Function InsertarVisita(ByVal Tab As Tablas.clVisitas) As Integer


        'Dim Sel As String = "INSERT INTO [Visitas] ([CodigoEmpresa], [Delegacion], [ContadorInmueble], [ContadorCliente], [Fecha], [Hora], [Observaciones], [ContadorEmpleado], [Impreso])" & _
        '                " VALUES ( " & Tab.CodigoEmpresa & ", " & Tab.Delegacion & ", " & Tab.ContadorInmueble & ", " & Tab.ContadorCliente & ", (SELECT C ONVERT(VARCHAR(50), " & gl_sql_getdate & ",112)), '19000101 '" & GL_SQL_SUMA & " (SELECT C ONVERT(VARCHAR(50), " & gl_sql_getdate & ",108)), '" & Funciones.pf_ReplaceComillas(Tab.Observaciones) & "'," & Tab.ContadorEmpleado & ", " & Funciones.pf_ReplaceTrueFalse(Tab.Impreso) & ")"


        Dim Sel As String = "INSERT INTO [Visitas] ([CodigoEmpresa], [Delegacion], [ContadorInmueble], [ContadorCliente], [Fecha], [Hora], [Observaciones], [ContadorEmpleado], [Impreso])" & _
                    " VALUES ( " & Tab.CodigoEmpresa & ", " & Tab.Delegacion & ", " & Tab.ContadorInmueble & ", " & Tab.ContadorCliente & "," & Funciones.pf_ReplaceFecha(CDate(Tab.Fecha)) & ", " & Funciones.pf_ReplaceHora(CDate(Tab.Hora)) & ", '" & Funciones.pf_ReplaceComillas(Tab.Observaciones) & "'," & Tab.ContadorEmpleado & ", " & Funciones.pf_ReplaceTrueFalse(Tab.Impreso) & ")"


        Dim bd As New BaseDatos
        bd.Execute(Sel)


    End Function

    Public Shared Function ObtenerObservaciones(ByVal ContadorClientePropietarioInmueble As Integer, ByVal Tabla As String) As DataTable

        Try


            Dim CampoContadorTipo As String = ""

            Select Case Tabla

                Case GL_TablaClientes
                    CampoContadorTipo = "ContadorCliente"

                Case GL_TablaInmuebles
                    CampoContadorTipo = "ContadorInmueble"


                Case GL_TablaPropietarios
                    CampoContadorTipo = "ContadorPropietario"

                    'Case "Reservas"
                    '    CampoContadorTipo = "ContadorInmueble"

            End Select

            Dim Sel As String = ""
            'If Tabla = "Reservas" Then
            '    Sel = "SELECT " & FuncionesBD.fnFormatDate("Fecha", "DD/MM/YY") & " AS Fecha, Observaciones AS Observacion FROM " & Tabla & " WHERE " & CampoContadorTipo & " = " & ContadorClientePropietarioInmueble & " ORDER BY Fecha DESC"
            'Else
            Tabla = Tabla & "Observaciones"
            '            Sel = "SELECT " & FuncionesBD.fnFormatDate("Fecha", "DD/MM/YY") & " AS Fecha, Observaciones AS Observacion, " & Funciones.SQL_CASE({"ContadorLlamada = 0", "ContadorLlamada <> 0"}, {"''", "'LL'"}) & " AS Llamada FROM " & Tabla & " WHERE " & CampoContadorTipo & " = " & ContadorClientePropietarioInmueble & " ORDER BY " & Tabla & ".Fecha DESC"

            Sel = "SELECT  Fecha, Observaciones AS Observacion, '' as Llamada FROM " & Tabla & " WHERE " & CampoContadorTipo & " = " & ContadorClientePropietarioInmueble & " ORDER BY " & Tabla & ".Fecha DESC"

            'End If


            Dim bd As New BaseDatos
            bd.LlenarDataSet(Sel, "Observaciones")

            Return bd.ds.Tables("Observaciones")


        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Public Shared Function ObtenerPreciosInmueble(ByVal ContadorInmueble As Integer, Optional ByVal NumeroCadena As Integer = 0) As Tablas.clPreciosInmueble

        Dim PreciosInmueble As New Tablas.clPreciosInmueble

        Try

            Dim dtr As Object
            Dim Sel As String
            Dim bdobt As New BaseDatos

            Sel = "SELECT Precio  FROM Inmuebles WHERE Contador = " & ContadorInmueble
            dtr = bdobt.ExecuteReader(Sel)
            If dtr.HasRows Then
                While dtr.Read()
                    PreciosInmueble.Precio = dtr("Precio ")

                End While
            End If
            dtr.Close()
            bdobt.CerrarBD()
        Catch ex As Exception
            PreciosInmueble.Precio = 0

        End Try

        Return PreciosInmueble
    End Function


    Public Shared Function InsertarComunicacionesObservaciones(ByVal Tab As Tablas.clComunicaciones) As Integer

        Try


            Dim TablaAUtilizar As String = ""
            Dim CampoContador As String = ""

            Select Case Tab.Tabla

                Case GL_TablaClientes
                    CampoContador = "ContadorCliente"

                    If Tab.Tipo = GL_OBSERVACIONES_MANUAL Then
                        'TablaAUtilizar = "ClientesObservaciones"
                    Else
                        TablaAUtilizar = "ClientesComunicaciones"
                    End If


                Case GL_TablaPropietarios
                    CampoContador = "ContadorPropietario"
                    'If Tab.Tipo = GL_OBSERVACIONES_MANUAL Then
                    '    TablaAUtilizar = "PropietariosObservaciones"

                    'Else
                    '    TablaAUtilizar = "PropietariosComunicaciones"
                    'End If

                    TablaAUtilizar = "PropietariosComunicaciones"
                Case GL_TablaInmuebles
                    CampoContador = "ContadorInmueble"
                    TablaAUtilizar = "InmueblesObservaciones"


            End Select

            Dim Sel As String = ""

            If Tab.Tipo = GL_LLAMADA And Not Tab.LlamadaContestada Then
                Tab.Tipo = GL_LLAMADA_NO_CONTESTA
            End If

            If Tab.Tipo = GL_OBSERVACIONES_MANUAL Then


            
                Sel = "INSERT INTO " & TablaAUtilizar & " (CodigoEmpresa ,Delegacion, " & CampoContador & ",Fecha,ContadorEmpleado,Observaciones) VALUES (" & _
                        Tab.CodigoEmpresa & "," & Gl_Delegacion & "," & Tab.ContadorClientePropietarioInmueble & "," & GL_SQL_GETDATE & "," & GL_CodigoUsuario & ",'" & Funciones.pf_ReplaceComillas(Tab.Observaciones) & "'" & _
                        ")"
                BD_CERO.Execute(Sel)

            Else

                Sel = "INSERT INTO " & TablaAUtilizar & " (CodigoEmpresa ,Delegacion, ContadorInmueble, " & CampoContador & ",Fecha,ContadorEmpleado,LlamadaContestada,Observaciones,Tipo) VALUES (" & _
                                   Tab.CodigoEmpresa & "," & Gl_Delegacion & "," & Tab.ContadorInmueble & "," & Tab.ContadorClientePropietarioInmueble & "," & GL_SQL_GETDATE & "," & GL_CodigoUsuario & "," & Funciones.pf_ReplaceTrueFalse(Tab.LlamadaContestada) & ",'" & Funciones.pf_ReplaceComillas(Tab.Observaciones) & "','" & Funciones.pf_ReplaceComillas(Tab.Tipo) & "'" & _
                                   ")"
                BD_CERO.Execute(Sel)


                If TablaAUtilizar = "PropietariosComunicaciones" Then
                    If Tab.Tipo <> GL_LLAMADA_NO_CONTESTA Then
                        Sel = "UPDATE Inmuebles set FechaUltimaLlamadaPropietario = " & GL_SQL_GETDATE & " WHERE Contador = " & Tab.ContadorInmueble
                        BD_CERO.Execute(Sel)
                    End If

                End If
                Dim TextoFechaPuestoAlDia As String = ""

                If Tab.Tipo = GL_EMAIL_LISTADO_CLIENTES Or Tab.Tipo = GL_EMAIL_LISTADO_NOVEDADES Then
                    TextoFechaPuestoAlDia = ",  FechaPuestoAlDia= " & GL_SQL_GETDATE & ""
                End If

                Dim CampoFechaActuliazar As String = ObtenerCampoFechaAACtualizar(Tab.Tipo)

                If CampoFechaActuliazar <> "" Then
                    Sel = "UPDATE Clientes SET " & CampoFechaActuliazar & "= " & GL_SQL_GETDATE & ", FechaUltimaComunicacion = " & GL_SQL_GETDATE & " " & TextoFechaPuestoAlDia & " WHERE Contador=" & Tab.ContadorClientePropietarioInmueble
                    BD_CERO.Execute(Sel)
                End If


                If Tab.Tipo = GL_EMAIL_LISTADO_CLIENTES Or Tab.Tipo = GL_EMAIL_LISTADO_NOVEDADES Then
                    Sel = "INSERT INTO HistoricoClientesComunicaciones SELECT * FROM ClientesComunicaciones WHERE ContadorCliente =" & Tab.ContadorClientePropietarioInmueble & " AND ContadorInmueble <> 0"
                    BD_CERO.Execute(Sel)
                End If


            End If





            Return 0
        Catch ex As Exception
            MensajeError(ex.Message)
            Return 1
        End Try
    End Function


    Public Shared Function ObtenerVisitas(CodigoEmpresa As Integer, Delegacion As Integer, ContadorCliente As Integer, ContadorInmueble As Integer, ByRef bd As BaseDatos) As BaseDatos

        Dim Sel As String
        Dim WhereAAplicar As String = ""

        If ContadorCliente <> 0 Then
            WhereAAplicar = " AND ContadorCliente = " & ContadorCliente
        End If

        If ContadorInmueble <> 0 Then
            WhereAAplicar = " AND ContadorInmueble = " & ContadorInmueble
        End If

        Sel = VistaTodasLasVisitas() & " WHERE CodigoEmpresa = " & CodigoEmpresa & " AND Delegacion = " & Delegacion & WhereAAplicar & " ORDER BY Fecha, Hora"

        bd = New BaseDatos
        bd.LlenarDataSet(Sel, "Inmuebles")
        Return bd

    End Function


    Public Shared Function ObtenerVisitasPendientes(ByVal ContadorCliente As Integer, Optional ByVal NumeroCadena As Integer = 0) As DataTable

        Dim Sel As String
        Sel = " SELECT Contador, Fecha, Hora, Referencia, Direccion, ContadorInmueble FROM (" & VistaTodasLasVisitas() & ") q WHERE  ContadorCliente = " & ContadorCliente & " AND Impreso = 0 ORDER BY Fecha, Hora"

        Dim bd As New BaseDatos(NumeroCadena)
        bd.LlenarDataSet(Sel, "Inmuebles")
        Return bd.ds.Tables("Inmuebles")

    End Function
    Public Shared Function VistaTodasLasVisitas() As String
        Dim Sel As String = ""

 
        Sel = "SELECT V.Contador, V.CodigoEmpresa, V.Delegacion, V.Impreso,V.ContadorInmueble as ContadorInmueble " & _
      " ,(SELECT Referencia FROM Inmuebles  WHERE Contador = V.ContadorInmueble  )    AS  Referencia " & _
      " ,(SELECT Baja FROM Inmuebles  WHERE Contador = V.ContadorInmueble  )    AS  BajaInmueble " & _
      " ,(SELECT Direccion FROM Inmuebles  WHERE Contador = V.ContadorInmueble  )    AS  Direccion " & _
      " ,ContadorCliente " & _
      " ,(SELECT Nombre FROM Clientes  WHERE Contador = V.ContadorCliente  )    AS  Cliente" & _
      " ,(SELECT Baja FROM Clientes  WHERE Contador = V.ContadorCliente  )    AS  BajaCliente " & _
      " ,Fecha, Hora, " & Funciones.SQL_CASE_ISNULL("(SELECT Nombre FROM Empleados E WHERE E.Contador = V.ContadorEmpleado ),''") & " AS Visitador, Observaciones" & _
      " FROM Visitas V"

        Return Sel
    End Function
    Public Shared Function VisitasImpresas(ByVal ContadorCliente As Integer, Optional ByVal NumeroCadena As Integer = 0) As Integer

        Dim Sel As String
        Sel = "UPDATE visitas SET Impreso=" & GL_SQL_VALOR_1 & " WHERE ContadorCliente = " & ContadorCliente & " AND Impreso = 0 "

        Dim aff As Object
        aff = BD_CERO.Execute(Sel, False)
        If aff Is DBNull.Value Or aff Is Nothing Then
            Return 0
        Else
            Return aff
        End If

    End Function


  
        Public Shared Function ObtenerComerciales(CodigoEmpresa As Integer, Delegacion As Integer, Optional ByVal NumeroCadena As Integer = 0) As DataTable

            Dim Sel As String
        Sel = "SELECT Nombre, Contador FROM Empleados WHERE CodigoEmpresa = " & CodigoEmpresa & " ORDER BY Nombre"

            Dim bd As New BaseDatos(NumeroCadena)
            bd.LlenarDataSet(Sel, "Inmuebles")
            Return bd.ds.Tables("Inmuebles")

        End Function

         

    Public Shared Function EliminarVisita(Contador As Integer, Optional ByVal NumeroCadena As Integer = 0) As Integer

        Dim Sel As String
        Sel = "" & GL_SQL_DELETE & "FROM Visitas WHERE Contador = " & Contador

     
        Dim aff As Object
        aff = BD_CERO.Execute(Sel, False)

        If aff Is DBNull.Value Or aff Is Nothing Then
            Return 0
        Else
            Return aff
        End If

    End Function
         

    Public Shared Function ObtenerContadorClienteEnAlta(Nombre As String, NIF As String, Telefono1 As String, ContadorMinimo As Integer, ContadorEmpleado As Integer) As Integer
        Dim Sel As String
        Sel = "SELECT Contador FROM Clientes WHERE Contador > " & ContadorMinimo & " AND Nombre = '" & FuncionesGenerales.Funciones.pf_ReplaceComillas(Nombre) & "' AND NIF = '" & FuncionesGenerales.Funciones.pf_ReplaceComillas(NIF) & "' AND ContadorEmpleado = " & ContadorEmpleado


         Dim aff As Object
        aff = BD_CERO.Execute(Sel, False)
        If aff Is DBNull.Value Or aff Is Nothing Then
            Return 0
        Else
            Return aff
        End If
    End Function
    Public Shared Function ObtenerContadorInmuebleEnAlta(Referencia As String, ContadorMinimo As Integer, ContadorEmpleado As Integer) As Integer
        Dim Sel As String
        Sel = "SELECT Contador FROM Inmuebles WHERE Contador >" & ContadorMinimo & " AND Referencia = '" & FuncionesGenerales.Funciones.pf_ReplaceComillas(Referencia) & "'  AND ContadorEmpleado =" & ContadorEmpleado
        Dim aff As Object
        aff = BD_CERO.Execute(Sel, False)
        If aff Is DBNull.Value Or aff Is Nothing Then
            Return 0
        Else
            Return aff
        End If
    End Function

    Public Shared Function ObtenerNombreEmpleadoDesdeCodigo(CodigoUsu As Integer) As String
        Dim Sel As String
        Sel = "SELECT Nombre FROM Empleados WHERE Contador = " & CodigoUsu

        Dim aff As Object
        aff = BD_CERO.Execute(Sel, False)
        If aff Is DBNull.Value Or aff Is Nothing Then
            Return 0
        Else
            Return aff
        End If
    End Function

      
     
    Public Shared Function ObtenerMensajePropietario(CodigoEmpresa As Integer, ContadorInmueble As Integer, Referencia As String, Optional IncluirDatosEmpresa As Boolean = False, Optional IncluirAvisoLegal As Boolean = True, Optional IncluirFaltanFotos As Boolean = False, Optional IncluirTextoDireccion As Boolean = False, Optional IncluirDatosInmuebles As Boolean = False) As String

        Dim Mensa As String = ""

        If Referencia <> "" Then
            Mensa = Mensa & vbCrLf & "Referencia del inmueble: " & Referencia
        End If



        If IncluirTextoDireccion AndAlso Not IsNothing(ContadorInmueble) AndAlso ContadorInmueble <> 0 Then
            Dim direc As String = ""
            Dim Sel As String
            Sel = "SELECT Direccion " & GL_SQL_SUMA & _
            Funciones.SQL_CASE({"Numero <> ''", "Numero = ''"}, {"' Num '" & GL_SQL_SUMA & "Numero", "''"}) & GL_SQL_SUMA & _
            Funciones.SQL_CASE({"Puerta <> ''", "Puerta = ''"}, {"' Pta. '" & GL_SQL_SUMA & "Puerta", "''"}) & " as DireccionCompleta FROM Inmuebles WHERE Contador = " & ContadorInmueble
            direc = "Dirección del inmueble: " & BD_CERO.Execute(Sel, False, "")
            Mensa = Mensa & vbCrLf & direc
        End If

        If IncluirFaltanFotos Then
            Mensa = Mensa & vbCrLf & "Recuerde enviar las fotos del inmueble."
        End If

        If IncluirDatosInmuebles Then
            Dim DatosInmueble As String
            DatosInmueble = ConsultasBaseDatos.ObtenerDescripcionInmueble2(ContadorInmueble) & " <br><br>" & Funciones.EnlaceWeb(BD_CERO.Execute("SELECT Tipo FROM Inmuebles WHERE Contador=" & ContadorInmueble, False), BD_CERO.Execute("SELECT TipoVenta FROM Inmuebles WHERE Contador=" & ContadorInmueble, False), BD_CERO.Execute("SELECT Poblacion FROM Inmuebles WHERE Contador=" & ContadorInmueble, False), Referencia, True)
            Mensa = Mensa & vbCrLf & DatosInmueble
        End If

        If IncluirDatosEmpresa Then
            Mensa = Mensa & vbCrLf & vbCrLf & pf_ObtenerDireccionEmpresa(CodigoEmpresa, False, False, 0)
        End If

        If IncluirAvisoLegal Then
            Mensa = Mensa & vbCrLf & vbCrLf & pf_ObtenerAvisoLegal(CodigoEmpresa)
        End If

        Return Mensa

        'JCB 23/06/2014 
        'CAMBIO PQ ME DIJO QUE NO QUIERE QUE EL PROPIETARIO VEA LA DESCRIPCIÓN DEL INMUEBLE
        Return ConsultasBaseDatos.ObtenerDescripcionInmueble2(ContadorInmueble) & " <br><br>" & Funciones.EnlaceWeb(BD_CERO.Execute("SELECT Tipo FROM Inmuebles WHERE Contador=" & ContadorInmueble, False), BD_CERO.Execute("SELECT TipoVenta FROM Inmuebles WHERE Contador=" & ContadorInmueble, False), BD_CERO.Execute("SELECT Poblacion FROM Inmuebles WHERE Contador=" & ContadorInmueble, False), Referencia, True)
    End Function

    Public Shared Function ObtenerAsuntoYCuerpoEmail(Documento As String, CodigoEmpresa As Integer, Optional ContadorInmueble As Integer = 0, Optional Referencia As String = "", Optional ContadorCliente As Integer = 0) As Tablas.cl_AsuntoYMensaje

        Try
            Dim dtr As Object
            Dim Sel As String
            Dim bdas As New BaseDatos
            Dim AsuntoYMensaje As New Tablas.cl_AsuntoYMensaje
            Dim DireccionEmpresa As String = ""

            AsuntoYMensaje.Asunto = ""
            AsuntoYMensaje.Mensaje = ""
            AsuntoYMensaje.Titulo = ""

            Sel = "SELECT * FROM TextosEnvios WHERE Documento = '" & Documento & "' AND CodigoEmpresa = " & CodigoEmpresa
            dtr = bdas.ExecuteReader(Sel)
            If dtr.HasRows Then
                While dtr.Read()
                    AsuntoYMensaje.Asunto = dtr("Asunto")
                    AsuntoYMensaje.Mensaje = dtr("Texto")
                    AsuntoYMensaje.Titulo = dtr("TituloInforme")
                    If dtr("IncluirDatosEmpresa") AndAlso Documento <> "EMAIL FIJO" Then
                        If ContadorCliente <> 0 Then
                            DireccionEmpresa = pf_ObtenerDireccionEmpresa(CodigoEmpresa, dtr("IncluirAvisoLegal"), True, ContadorCliente)
                        Else
                            DireccionEmpresa = pf_ObtenerDireccionEmpresa(CodigoEmpresa, dtr("IncluirAvisoLegal"), False, ContadorCliente)
                        End If

                    End If
                End While
            End If
            dtr.Close()
            bdas.CerrarBD()

            If Documento = GL_EMAIL_DETALLE Then
                If AsuntoYMensaje.Mensaje = "" Then
                    AsuntoYMensaje.Mensaje = ConsultasBaseDatos.ObtenerDescripcionInmueble2(ContadorInmueble)
                Else
                    AsuntoYMensaje.Mensaje = AsuntoYMensaje.Mensaje & vbCrLf & vbCrLf & ConsultasBaseDatos.ObtenerDescripcionInmueble2(ContadorInmueble)
                End If

                If DatosEmpresa.WordPress Then
                    'AsuntoYMensaje.Mensaje = AsuntoYMensaje.Mensaje & vbCrLf & vbCrLf & "Visite el inmueble en " & GL_ConfiguracionWeb.WebConHHTP & "/property-search/?property-id=" & Referencia
                    AsuntoYMensaje.Mensaje = AsuntoYMensaje.Mensaje & vbCrLf & vbCrLf & "Visite el inmueble en " & BD_CERO.Execute("SELECT link_WP FROM Inmuebles WHERE Contador=" & ContadorInmueble, False)
                Else
                    AsuntoYMensaje.Mensaje = AsuntoYMensaje.Mensaje & vbCrLf & vbCrLf & "Visite el inmueble en " & Funciones.EnlaceWeb(BD_CERO.Execute("SELECT Tipo FROM Inmuebles WHERE Contador=" & ContadorInmueble, False), BD_CERO.Execute("SELECT TipoVenta FROM Inmuebles WHERE Contador=" & ContadorInmueble, False), BD_CERO.Execute("SELECT Poblacion FROM Inmuebles WHERE Contador=" & ContadorInmueble, False), Referencia, True)

                End If

            End If

            If DireccionEmpresa <> "" Then
                AsuntoYMensaje.Mensaje = AsuntoYMensaje.Mensaje & vbCrLf & vbCrLf & DireccionEmpresa
            End If

            Return AsuntoYMensaje
        Catch ex As Exception
            MensajeError(ex.Message)
            Return Nothing
        End Try


    End Function

  
    Public Shared Function ObtenerContadorTablasAuxEnAlta(Tabla As String, ClavePrincipal As String) As Integer
        Dim Sel As String
        Sel = "SELECT MAX(" & ClavePrincipal & ") FROM " & Tabla

        Dim aff As Object
        aff = BD_CERO.Execute(Sel, False)
        If aff Is DBNull.Value Or aff Is Nothing Then
            Return 0
        Else
            Return aff
        End If
    End Function
End Class
 

