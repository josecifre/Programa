Module VariablesGlobales

    Public GL_TokenWP As String
    Public GL_Palabra_Alquiler As String
    Public GL_Palabra_Venta As String

    Public Const GL_wsRutaWs As String = "https://api.inmofactory.com/api/"
    Public Const GL_CodigoErrorWebService As Integer = -9999

    Public GL_Portales As New List(Of String)
    Public GL_PortalesCreados As New List(Of String)

    Public GL_VentaAlquiler As String

    Public GL_PANTALLA_QUE_LANZA_LLAMADA As String
    Public GL_DESCARGA_POR_FTP As Boolean
    Public GL_BD_VENALIA As String

    Public GL_ICONOSI As String = "√" '"☑" '
    Public GL_ICONONO As String = "☐" '"X" '
    Public GL_ICONOOTRO As String = "�" '"⊡" '"?" '"▣" '"⌻" '

    'SQL
    Public GL_SQL_DELETE As String '*
    Public GL_SQL_SUMA As String '" & GL_SQL_SUMA & " || 
    Public GL_SQL_UPPER As String
    Public GL_SQL_GETDATE As String
    Public GL_SQL_POR As String '* %
    Public GL_SQL_DBO As String '.DBO
    Public GL_SQL_CHAR As String 'CHAR CHR
    Public GL_SQL_FROMDUAL As String ' FROM DUAL
    Public GL_SQL_LEN As String
    Public GL_SQL_DIS As String 'DISTINTO != <>
    Public GL_SQL_YEAR As String 'EL AÑO EXTRACT (YEAR YEAR
    Public GL_SQL_MONTH As String 'EL MES EXTRACT (MONTH MONTH
    Public GL_SQL_DAY As String 'EL DIA EXTRACT (DAY DAY
    Public GL_SQL_VALOR_1 As String 'EN SQL SERVER, 1 EN ACCESS -1
    Public GL_SQL_D As String 'PARA DATEDIFF EN SQL dd EN ACCESS 'd'
    Public GL_SQL_SUBSTRING As String 'substring substr mid
    Public GL_SQL_TOP1_FRONT As String 'SELECT TOP 1,SELECT TOP 1,'SELECT * FROM (SELECT '
    Public GL_SQL_TOP1_BACK As String ' '','', ) WHERE ROWNUM=1

    Public Const TIPOACCESS As String = "MDB" '"ACCDB"
    Public Const GL_NombreBaseDatosLevantamientoVacia As String = "LEVANTAMIENTO_VACIA." & TIPOACCESS
    Public Const PassAccessLevantamiento As String = "TresBits368"
    ''Para Mapas
    Public time As New ArrayList()
    Public autor As New ArrayList()
    Public URLautor As New ArrayList()
    Public textoReview As New ArrayList()

    Public GL_TextoSMS As String
    Public Const GL_VACIO As String = ""
    Public Const GL_ESPACIO As String = " "
    Public Const GL_ESPACIOSQL As String = "' '"
    Public GL_TipoBD As Integer

    'Rutas
    Public copyRuta As New ArrayList()
    Public ordenRuta As New ArrayList()
    Public rutaID As New ArrayList()
    Public DuraciTotal As New ArrayList()
    Public DistanciaTotal As New ArrayList()
    Public TiempoSegundos As New ArrayList()
    Public Polilineas As New ArrayList()
    '-------
    Public statusRuta As String
    '--------
    'Elevación
    Public resolucion As New ArrayList()

    'Seguimiento de solicitudes HTTP
    Public URLseguimiento As New ArrayList
    Public numeroInstancia As Long

    'Hilo
    Public hiloImagenes As Threading.Thread
    Public hiloMapas As Threading.Thread

    'Mapas completos (importar xml)
    Public rutaArchivoimportar As String

    'Autocompletar
    Public listaAutocompletar As New ArrayList 'La lista con los datos
    Public MySource As New AutoCompleteStringCollection()

    'FIN para mapas
    ' Public cnOracleUnicaTramex As Oracle.DataAccess.Client.OracleConnection
    Public cnSQLServerUnicaTramex As SqlClient.SqlConnection
    Public cnAccessUnica As OleDb.OleDbConnection
    Public cmdAccessUnica As OleDb.OleDbCommand
    Public cnAccessUnicaDTR As OleDb.OleDbConnection
    Public cmdAccessUnicaDTR As OleDb.OleDbCommand

    Public ESLEVANTAMIENTO As Boolean
    Public BD_CERO As BaseDatos

    Public cnSQLServerUnica As SqlClient.SqlConnection
    Public cmdSQLServerUnica As SqlClient.SqlCommand


    Public cnSQLServerUnicaDTR As SqlClient.SqlConnection
    Public cmdSQLServerUnicaDTR As SqlClient.SqlCommand


    Public GL_ADMINISTRADOR As String = "ADMINISTRADOR"
    Public Const PerfilSituacionActual As String = "PERFIL_SIT_ACTU"

    Public GL_Aleatorio_Menus As String ''
    Public GL_GruposVisibles As String 'XXXXXXXXXXXXXXXXXXXX para quitar los q no lo sean

    Public Enum EnumTipoBD As Integer

        SQL_SERVER = 1
        ORACLE = 2
        ACCESS = 3

    End Enum

    Public GL_Busqueda As String

    Public GL_PropietariosPendienteActualizacion As Boolean
    Public GL_ClientesPendienteActualizacion As Boolean
    Public GL_InmueblesPendienteActualizacion As Boolean
    Public GL_AlarmasPendienteActualizacion As Boolean

    Public GL_TieneAnimales As Boolean
    Public GL_ObservacionesCambioPrecio As String

    Public PropietariosEstaActivo As Boolean
    'Public InmueblesEstaActivo As Boolean
    'Public ClientesEstaActivo As Boolean
    'Public AlarmasEstaActivo As Boolean
    Public GL_AlarmasActivo As Boolean
    Public GL_CambiosPrecios As Tablas.clCambiosPrecios

    Public GL_FichaAlquiler As Integer

    Public Const GL_VENGO_DE_PRINCIPAL As String = "PRINCIPAL"
    Public Const GL_VENGO_DE_CLIENTES As String = "CLIENTES"
    Public Const GL_VENGO_DE_INMUEBLES As String = "INMUEBLES"
    Public Const GL_VENGO_DE_PROPIETARIOS As String = "PROPIETARIOS"
    Public Const GL_VENGO_DE_VISITAS As String = "VISITAS"

    Public UClienteActivo As Venalia.ucClientes
    Public uEmpleadosActivo As ucEmpleados
    Public uPropietariosActivo As ucPropietarios
    Public uTextosEnviosActivo As ucTextosEnvios
    Public uAlarmasActivo As ucAlarmas
    Public uImagenesActivo As ucImagenes
    ' Public uClientesWebActivo As ucClientesWeb

    Public uInmueblesActivo As ucInmuebles


    Public uConfiguracionActivo As ucConfiguracion

    '   Public uInmueblesActivo2 As ucInmuebles2
    Public GL_Observaciones As String
    Public GL_RespondioALaLlamada As Boolean


    Public GL_FicheroINI As String
    Public GL_FicheroINI_RED As String
    Public GL_TipoUsuario As String
    Public GL_Usuario As String
    Public GL_Usuario_NombreEmpleado As String
    Public GL_CodigoUsuario As Integer

    'Public GL_RutaDisenoUsuario As String
    Public GL_DisenoPerfil As String

    Public GL_FechaInicio As String
    Public GL_FechaFin As String

    Public GL_TamanoLetra As Integer = 10
    Public GL_AltoFila As Integer = 22
    Public GL_LetraTitulares As String = ""
    Public GL_ContadorTitular As Integer = 0
    Public GL_FaseSeleccionada As String = ""
    Public GL_MunicipioSeleccionado As String = ""

    Public Const ADMINISTRADOR = "ADMINISTRADOR"
    Public Const GL_CARPETA_DISENOS = "Disenos"
    Public GL_TablaMantenimientos As String
    Public GL_TextoMantenimientos As String

    Public GL_Descargas As String
    Public GL_ActualizacionesAutomaticas As String
    Public GL_QuienSoy As String



    Public GL_CARPETA_PERFILES As String = ""
    Public Const GL_ValorDuplicado As String = "Registro Duplicado"

    Public GL_Divisa_EW As String
    Public GL_Empresa_EW As String
    Public GL_BD_EW As String
    Public GL_MostarNotePad As String

    Public DatosEmpresa As clDatosEmpresa

    Public GL_ResultadoBusqueda_CANCELAR As String = "-888888888"
    Public Const Gl_ResultadoBusqueda_SALIR As String = "-999999999"
    Public Gl_ResultadoBusqueda As String

    Public Enum EnumResultadoBusqueda As Integer
        CLIENTE = 99999
        TECNICO
        AUXILIAR
        FAMILIA
        MARCA
        ARTICULO
        VENDEDOR
        ALMACEN
        CATEGORIA_OTROS
        CONDUCTOR
        CONDUCTOR_VEHICULO
        PROPIETARIO
    End Enum

    Public Enum EnumFiltro As Integer
        TODOS = 0
        WORD = 1
        EXCEL = 2
        PDF = 3
        JPG = 4
        IMAGENES = 5
    End Enum

    Public Class clDatosEmpresa

        Public Codigo As Integer
        Public Nombre As String
        Public NombreComercial As String

        Public BaseDatos As String

        Public WordPress As Boolean
    End Class

    Public Gl_Delegacion As Integer

    'NOMBRES DE TABLAS

    Public GL_Agrupaciones As String = "AGRUPACIONES"

    Public GL_EmpleadosSeleccionados As String
    Public GL_ComoConociste As String

    Public GL_Clientes As String = "CLIENTES"
    Public GL_Empleados As String = "EMPLEADOS"
    Public GL_Propietarios As String = "PROPIETARIOS"

    Public GL_TextoHttpdocs As String

    Public Const GL_LLAMADA = "LLAMADA"
    Public Const GL_LLAMADA_NO_CONTESTA = "NO CONTESTA"
    Public Const GL_VISITA_OFICINA = "VISITA OFICINA"
    'Public Const GL_LLAMADA_CLIENTE = "LLAMADA CLIENTE"
    Public Const GL_LLAMADA_PROPIETARIO = "LLAMADA PROPIETARIO"
    Public Const GL_EMAIL_FIJO = "EMAIL FIJO"
    Public Const GL_EMAIL_DETALLE = "EMAIL DETALLE"
    Public Const GL_LLAMADA_DETALLE = "LLAMADA DETALLE"
    Public Const GL_COMUNICADO_DETALLE = "COMUNICADO DETALLE"
    Public Const GL_EMAIL_LISTADO_CLIENTES = "LISTADO COMPLETO"
    Public Const GL_EMAIL_LISTADO_NOVEDADES = "LISTADO NOVEDADES"
    Public Const GL_EMAIL_PROPIETARIOS As String = "EMAIL PROPIETARIOS"
    Public Const GL_SMS = "SMS"

    Public GL_TablaClientes As String = "Clientes"


    Public GL_TablaInmuebles As String = "Inmuebles"



    Public GL_TablaPropietarios As String = "Propietarios"

    Public GL_ColorTextoBotones As System.Drawing.Color


    Public Const GL_OBSERVACIONES_LLAMADA As String = "LLAMADA"
    Public Const GL_OBSERVACIONES_INFORMADO As String = "INFORMADO"
    Public Const GL_OBSERVACIONES_MANUAL As String = "MANUAL"

    Public Const GL_MODIFICAR_OBSERVACIONES_LLAMADA As String = "MODIFICAR_OBSERVACIONES_LLAMADA"



    Public GL_DatosMensajePersonalizado As String = ""

    'COLORES DE LAS LINEAS

    Public GL_ColorHide As System.Drawing.Color = Color.LightBlue
    Public GL_ColorTextoHide As System.Drawing.Color = Color.Black
    Public GL_ColorFondoImpar As Color = Color.AliceBlue

    Public GL_ColorSeleccionado As System.Drawing.Color = Color.FromArgb(255, 80, 160, 240)
    Public GL_ColorTextoSeleccionado As System.Drawing.Color = Color.White

    Public GL_ColorVisitado As System.Drawing.Color = Color.FromArgb(80, 191, 234, 64)
    Public GL_ColorVisitadoSeleccionado As System.Drawing.Color = Color.FromArgb(255, 191, 234, 64)
    'Public GL_ColorVisitado As System.Drawing.Color = Color.FromArgb(80, 255, 170, 85)
    'Public GL_ColorVisitadoSeleccionado As System.Drawing.Color = Color.FromArgb(255, 255, 170, 85)

    Public GL_ColorPendienteWeb As System.Drawing.Color = Color.PaleTurquoise
    Public GL_ColorPendienteWebSeleccionado As System.Drawing.Color = Color.Turquoise

    Public GL_ColorMostrarPPrincipalWeb As System.Drawing.Color = Color.Plum
    Public GL_ColorMostrarPPrincipalWebSeleccionado As System.Drawing.Color = Color.Violet

    Public GL_ColorOcultar As System.Drawing.Color = Color.FromArgb(255, 90, 90, 90)
    Public GL_ColorOcultarSeleccionado As System.Drawing.Color = Color.FromArgb(255, 170, 170, 170)

    'Public GL_ColorReservado1 As System.Drawing.Color = Color.FromArgb(80, 255, 158, 62)
    ' Public GL_ColorReservado1 As System.Drawing.Color = Color.FromArgb(80, 255, 155, 106)
    '  Public GL_ColorReservado1Seleccionado As System.Drawing.Color = Color.FromArgb(80, 255, 155, 106)
    'Public GL_ColorReservado1Seleccionado As System.Drawing.Color = Color.FromArgb(255, 255, 158, 62)

    Public GL_ColorEmail As System.Drawing.Color = Color.FromArgb(80, 168, 255, 255)
    Public GL_ColorEmailSeleccionado As System.Drawing.Color = Color.FromArgb(255, 168, 255, 255)



    Public GL_ColorNovedad As System.Drawing.Color = Color.Salmon ' Color.FromArgb(255, 250, 128, 114)
    Public GL_ColorNovedadSeleccionado As System.Drawing.Color = Color.FromArgb(255, 250 - 20, 128 - 20, 114 - 20)


    Public GL_ColorLlamada As System.Drawing.Color = Color.FromArgb(80, 255, 119, 255)
    Public GL_ColorLlamadaSeleccionado As System.Drawing.Color = Color.FromArgb(255, 255, 119, 255)

    Public GL_ColorLlamada_EMail As System.Drawing.Color = Color.FromArgb(80, 176, 98, 255)
    Public GL_ColorLlamada_EMailSeleccionado As System.Drawing.Color = Color.FromArgb(255, 176, 98, 255)

    Public GL_ColorReservado As System.Drawing.Color = Color.FromArgb(160, Color.Yellow)
    Public GL_ColorReservadoSeleccionado As System.Drawing.Color = Color.FromArgb(255, Color.Yellow)

    Public GL_ColorAruraRosaBaja As System.Drawing.Color = Color.FromArgb(255, Color.Pink)
    Public GL_ColorBaja As System.Drawing.Color = Color.FromArgb(255, Color.Red)
    Public GL_ColorBajaSeleccionado As System.Drawing.Color = Color.FromArgb(255, 205, 0, 0)
    Public GL_ColorBajaReservado As System.Drawing.Color = Color.FromArgb(80, Color.Red)
    Public GL_ColorBajaReservadoSeleccionado As System.Drawing.Color = Color.FromArgb(150, 205, 0, 0)
    Public GL_ColorOriginal As System.Drawing.Color

    Public GL_FotosPc As Integer
    Public GL_FotosWeb As Integer
    Public GL_FotoPrincipal As String
    Public GL_InmuebleReservado As String

    Public GL_Listado As String
    Public GL_Word As Boolean

    Public hilo1 As Threading.Thread
    Public hilo2 As Threading.Thread


    Public GL_CarpetaFotos As String
    Public GL_CarpetaFotosBaja As String
    Public GL_CarpetaFotosEliminadas As String
    Public GL_ConfiguracionWeb As Tablas.clConfiguracionWeb
    Public GL_PoblacionPrederminada As String

    Public GL_ServidorFTP As String

    Public GL_Error As String

    Public GL_PortalesDesactualizados As Boolean

End Module
