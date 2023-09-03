Imports System
Imports System.Data


Public Class Tablas



#Region "WordPress"
    Public Class clInmuebleConId_WP
        Public Inmueble As Tablas.clInmueblesAlta
        Public ID_WP As Integer
        Public Id_WP_FotoPrincipal As Integer
    End Class
    Public Class StrStr
        Public Nombre As String
        Public Descripcion As String
    End Class

    Public Class ApiCredentials
        Public Property WordPressUri As String
        Public Property Username As String
        Public Property Password As String

        Sub New()
            WordPressUri = GL_ConfiguracionWeb.API_WP.Replace("wp/v2/", "")
            Username = GL_ConfiguracionWeb.Usuario
            Password = GL_ConfiguracionWeb.Pass
        End Sub
    End Class

    Public Class clNombre
        Public Property name As String
        Public Property slug As String

        Public Property parent As Integer

        Sub New(pnombre As String, Optional pparent As Integer = 0)
            name = pnombre
            slug = pnombre.ToLower.Replace(" ", "_")
            parent = pparent

        End Sub
    End Class
#Region "WP_media"


    Public Class clNuevaImagen
        Public Property data As String
        Public Property source_url As String
    End Class

    Public Class Guid
        Public Property rendered As String
    End Class

    Public Class Title
        Public Property rendered As String
    End Class

    Public Class Description
        Public Property rendered As String
    End Class

    Public Class Caption
        Public Property rendered As String
    End Class

    Public Class Medium
        Public Property file As String
        Public Property width As Integer
        Public Property height As Integer
        Public Property mime_type As String
        Public Property source_url As String
    End Class

    Public Class Thumbnail
        Public Property file As String
        Public Property width As Integer
        Public Property height As Integer
        Public Property mime_type As String
        Public Property source_url As String
    End Class

    Public Class MediumLarge
        Public Property file As String
        Public Property width As Integer
        Public Property height As Integer
        Public Property mime_type As String
        Public Property source_url As String
    End Class

    Public Class PostThumbnail
        Public Property file As String
        Public Property width As Integer
        Public Property height As Integer
        Public Property mime_type As String
        Public Property source_url As String
    End Class

    Public Class PropertyThumbImage
        Public Property file As String
        Public Property width As Integer
        Public Property height As Integer
        Public Property mime_type As String
        Public Property source_url As String
    End Class

    Public Class PropertyDetailVideoImage
        Public Property file As String
        Public Property width As Integer
        Public Property height As Integer
        Public Property mime_type As String
        Public Property source_url As String
    End Class

    Public Class AgentImage
        Public Property file As String
        Public Property width As Integer
        Public Property height As Integer
        Public Property mime_type As String
        Public Property source_url As String
    End Class

    Public Class PartnersLogo
        Public Property file As String
        Public Property width As Integer
        Public Property height As Integer
        Public Property mime_type As String
        Public Property source_url As String
    End Class

    Public Class GalleryTwoColumnImage
        Public Property file As String
        Public Property width As Integer
        Public Property height As Integer
        Public Property mime_type As String
        Public Property source_url As String
    End Class

    Public Class PropertyDetailSliderThumb
        Public Property file As String
        Public Property width As Integer
        Public Property height As Integer
        Public Property mime_type As String
        Public Property source_url As String
    End Class

    Public Class GridViewImage
        Public Property file As String
        Public Property width As Integer
        Public Property height As Integer
        Public Property mime_type As String
        Public Property source_url As String
    End Class

    Public Class Full
        Public Property file As String
        Public Property width As Integer
        Public Property height As Integer
        Public Property mime_type As String
        Public Property source_url As String
    End Class

    Public Class Sizes
        Public Property medium As Medium
        Public Property thumbnail As Thumbnail
        Public Property medium_large As MediumLarge
        Public Property post_thumbnail As PostThumbnail
        Public Property property_thumb_image As PropertyThumbImage
        Public Property property_detail_video_image As PropertyDetailVideoImage
        Public Property agent_image As AgentImage
        Public Property partners_logo As PartnersLogo
        Public Property gallery_two_column_image As GalleryTwoColumnImage
        Public Property property_detail_slider_thumb As PropertyDetailSliderThumb
        Public Property grid_view_image As GridViewImage
        Public Property full As Full
    End Class

    Public Class ImageMeta
        Public Property aperture As String
        Public Property credit As String
        Public Property camera As String
        Public Property caption As String
        Public Property created_timestamp As String
        Public Property copyright As String
        Public Property focal_length As String
        Public Property iso As String
        Public Property shutter_speed As String
        Public Property title As String
        Public Property orientation As String
        Public Property keywords As Object()
    End Class

    Public Class MediaDetails
        Public Property width As Integer
        Public Property height As Integer
        Public Property file As String
        Public Property sizes As Sizes
        Public Property image_meta As ImageMeta
    End Class

    Public Class Self
        Public Property href As String
    End Class

    Public Class Collection
        Public Property href As String
    End Class

    Public Class About
        Public Property href As String
    End Class

    Public Class Author
        Public Property embeddable As Boolean
        Public Property href As String
    End Class

    Public Class Reply
        Public Property embeddable As Boolean
        Public Property href As String
    End Class

    Public Class Links
        Public Property self As Self()
        Public Property collection As Collection()
        Public Property about As About()
        Public Property author As Author()
        Public Property replies As Reply()
    End Class

    Public Class cl_WP_Media
        Public Property id As Integer
        Public Property date_ As DateTime
        Public Property date_gmt As DateTime
        Public Property guid As Guid
        Public Property modified As DateTime
        Public Property modified_gmt As DateTime
        Public Property slug As String
        Public Property status As String
        Public Property type As String
        Public Property link As String
        Public Property title As Title
        Public Property author As Integer
        Public Property comment_status As String
        Public Property ping_status As String
        Public Property template As String
        Public Property meta As Object()
        Public Property description As Description
        Public Property caption As Caption
        Public Property alt_text As String
        Public Property media_type As String
        Public Property mime_type As String
        Public Property media_details As MediaDetails
        Public Property post As Integer
        Public Property source_url As String
        Public Property _links As Links
    End Class


#End Region

    Public Class clTokenWP

        Public Property token As String
        Public Property user_email As String
        Public Property user_nicename As String
        Public Property user_display_name As String

    End Class

    Public Class clErrorWP
        '{"code":"jwt_auth_bad_auth_header","message":"Authorization header malformed.","data":{"status":403}}
        Public Property code As String
        Public Property message As String
        '  Public Property data As String


    End Class

    Public Class clResultado

        Public Property Codigo As Integer
        Public Property Mensaje As String
        Public Property InformacionAdicional As String
        Public Property InformacionAdicional2 As String
        Public Property InformacionAdicional3 As String
        Public Property InformacionAdicional4 As String

    End Class

    Public Class cl_wp_InspiryFloorPlan
        Public Property inspiry_floor_plan_name As String
        Public Property inspiry_floor_plan_price As String
        Public Property inspiry_floor_plan_size As String
        Public Property inspiry_floor_plan_bedrooms As String
        Public Property inspiry_floor_plan_bathrooms As String
        Public Property inspiry_floor_plan_descr As String
        Public Property inspiry_floor_plan_image As String
    End Class

    'Public Class cl_wp_REALHOMESAdditionalDetails
    '    Public Property Construido___en As String
    '    Public Property Frente___al___mar As String
    '    Public Property Suelo As String
    '    Public Property Mascotas As String
    '    Public Property Garaje As String
    '    Public Property Estado As String
    'End Class

    Public Class cl_wp_REALHOMESAdditionalDetails
        Public Property Detalles As String
    End Class

    Public Class cl_wp_Immueble

        Public Property status As String
        Public Property type As String
        Public Property title As String
        Public Property content As String
        Public Property author As Integer
        Public Property featured_media As Integer
        Public Property comment_status As String
        Public Property ping_status As String
        'Public Property property____types As List(Of Integer) 'Cambiado por tipos____propiedad
        'Public Property property____statuses As List(Of Integer) 'Cambiado por estatus____propiedad
        'Public Property property____cities As List(Of Integer) 'Cambiado por ciudades____propiedad
        'Public Property property____features As List(Of Integer)  'Cambiado por características____propiedad
        Public Property características____propiedad As List(Of Integer)
        Public Property tipos____propiedad As List(Of Integer)
        Public Property estatus____propiedad As List(Of Integer)
        Public Property ciudades____propiedad As List(Of Integer)



        'Inmueble_wp.REAL_HOMES_property_map = 0 '?????
        'Inmueble_wp.REAL_HOMES_gallery_slider_type = "thumb-on-right" '?????
        'Inmueble_wp.inspiry_property_label_color = "#dd3333"  '(Es color de la etiqueta para oportunidades)


        'Public Property _thumbnail_id As List(Of String)
        Public Property REAL_HOMES_property_price As String
        Public Property REAL_HOMES_property_size As String
        Public Property REAL_HOMES_property_location As String

        Public Property REAL_HOMES_property_map As String
        Public Property REAL_HOMES_gallery_slider_type As String
        Public Property inspiry_property_label_color As String
        Public Property REAL_HOMES_property_size_postfix As String

        Public Property REAL_HOMES_agents As String


        Public Property REAL_HOMES_property_address As String
        Public Property REAL_HOMES_property_garage As String
        Public Property REAL_HOMES_property_bedrooms As String
        Public Property REAL_HOMES_property_bathrooms As String

        Public Property inspiry_property_label As String

        Public Property REAL_HOMES_energy_class As String

        Public Property inspiry_estado As String


        Public Property REAL_HOMES_featured As Integer
        'Public Property REAL_HOMES_add_in_slider As List(Of String)
        Public Property REAL_HOMES_property_id As String
        '  Public Property inspiry_floor_plans As cl_wp_InspiryFloorPlan()

        'Public Property REAL_HOMES_additional_details As List(Of StrStr)
        Public Property REAL_HOMES_additional_details As cl_wp_REALHOMESAdditionalDetails


        Sub New()
            'REAL_HOMES_featured = New List(Of String)
            'REAL_HOMES_add_in_slider = New List(Of String)
            '    property____types = New List(Of Integer)
            '    property____statuses = New List(Of Integer)
            '    property____cities = New List(Of Integer)
            'property____features = New List(Of Integer)
            'características____propiedad = New List(Of Integer)

            tipos____propiedad = New List(Of Integer)
            estatus____propiedad = New List(Of Integer)
            ciudades____propiedad = New List(Of Integer)
            características____propiedad = New List(Of Integer)


            '_thumbnail_id = New List(Of String)
        End Sub

    End Class


    Public Class clWPCreado
        Public Property id As Integer
        Public Property link As String
    End Class


#End Region


    Public Class clInmueblesAlta

        Public AlquilerOpcionCompra As Boolean


            Public AlquilerVacacional As Boolean


            Public Altura As Integer


            Public Amueblado As Boolean


            Public AnoConstruccion As Integer


            Public Ascensor As Boolean


            Public Balcon As Boolean


            Public Banos As Integer


            Public CalificacionEnergetica As String


            Public CambioPrecio As String


            Public CocinaOffice As Boolean


            Public CodPostal As String


            Public CodigoEmpresa As Integer


            Public Contador As Long


            Public Delegacion As Integer


            Public Direccion As String


            Public Duplex As Boolean


            Public Estado As String


            Public Extras As String


            Public FechaAlta As Date


            Public FechaCambioPrecio As System.Nullable(Of Date)


            Public FechaUltimoCambio As System.Nullable(Of Date)


            Public FotoPrincipal As String


            Public Galeria As Boolean


            Public Garaje As Boolean


            Public GarajeCerrado As Boolean


            Public Habitaciones As Integer


            Public Jardin As Boolean


            Public MBalcon As Integer


            Public MBalcon2 As Integer


            Public MGaraje As Integer


            Public MJardin As Integer


            Public MPatio As Integer


            Public MPatio2 As Integer


            Public MPlaya As Integer


            Public MTerraza As Integer


            Public MTerraza2 As Integer


            Public MTrastero As Integer


            Public Metros As Integer


            Public MostrarPPrincipalWeb As Boolean


            Public Numero As String


            Public Oportunidad As Boolean


            Public Orientacion As String


            Public Patio As Boolean


            Public Piscina As Boolean


            Public Poblacion As String


            Public Precio As Integer


            Public PrecioGaraje As Integer


            Public PrecioTrastero As Integer


            Public Provincia As String


            Public Puerta As String


            Public Referencia As String


            Public Reservado As Boolean


            Public Terraza As Boolean


            Public Tipo As String


            Public TipoVenta As String


            Public Trastero As System.Nullable(Of Boolean)


            Public Via As String


            Public VistasAlMar As Boolean


            Public Zona As String


            Public ZonaComercial As Boolean
        End Class

    Public Class clZonas


        Public Property Zona As String

    End Class

    Public Class clInmueblesPropietario

        Public Contador As Integer
        Public CodigoEmpresa As Integer
        Public Delegacion As Integer
        Public Nombre As String
        Public TelefonoMovil As String
        Public Telefono1 As String
        Public Telefono2 As String
        Public Telefono3 As String
        Public Telefono4 As String

        Public Email As String

        Public NoInmo As Boolean
        Public Mensual As Boolean
        Public Aviso3 As Boolean
        Public NoExtranjeros As Boolean
        Public SeguroVivienda As Boolean
        Public NoEmail As Boolean
        Public NoAnimales As Boolean


    End Class

    Public Class clCambiosPrecios
        Public ContadorInmueble As Integer
        Public ContadorEmpleado As Integer
        Public Fecha As DateTime
        Public Precio As Integer
        Public Cambio As String
        Public CambioPropietario As String
        Public PrecioPropietario As Integer

        Public TipoVenta As String
        Public OpcionCompra As Boolean

        Public HayCambios As Boolean

    End Class
    Public Class clComunicaciones

        Public Contador As Integer
        Public CodigoEmpresa As Integer
        Public Delegacion As Integer
        Public ContadorClientePropietarioInmueble As Integer
        Public Fecha As Date
        Public ContadorEmpleado As Integer
        Public Observaciones As String
        Public Tipo As String
        Public ContadorLlamada As Integer
        Public ContadorInmueble As Integer
        Public LlamadaContestada As Boolean
        Public Tabla As String
        Public QuienMeLlama As String

    End Class


    Public Class clVisitas

        Public Contador As Integer
        Public CodigoEmpresa As Integer
        Public Delegacion As Integer
        Public ContadorCliente As Integer
        Public ContadorInmueble As Integer
        Public Fecha As String
        Public Hora As String
        Public Observaciones As String
        Public Impreso As Boolean
        Public ContadorEmpleado As Integer

    End Class

    'Public Class clComunicaciones


    '    Public CodigoEmpresa As Integer
    '    Public Delegacion As Integer
    '    Public ContadorCliente As Integer
    '    Public ContadorInmueble As Integer
    '    Public Fecha As String
    '    Public ContadorEmpleado As Integer
    '    Public Precio As Double

    '    Public CambioDePrecio As Boolean
    '    Public LlamadaContestada As Integer


    'End Class




    Public Class clPreciosInmueble

        Public CodigoEmpresa As Integer
        Public ContadorInmueble As Integer
        Public Precio As Double



    End Class

    Public Class cl_AsuntoYMensaje
        Public Asunto As String
        Public Mensaje As String
        Public Titulo As String
    End Class

    Public Class cl_DatosEmail

        Private p_Email As String
        Private p_Usuario As String
        Private p_Contrasena As String
        Private p_NombreMostrar As String
        Private p_SMTP As String
        Private p_POP3 As String

        Private p_PuertoSMTP As Integer
        Private p_PuertoPOP3 As Integer

        Private p_SSL As Boolean
        Private p_HTML As Boolean

        Private p_CodigoEmpresa As Integer

        Sub New(CodEmpresa As Integer)
            p_CodigoEmpresa = CodEmpresa
            CargarDatosEmailDeBD()
        End Sub



        Public Property Email As String
            Get
                Email = p_Email
            End Get
            Set(value As String)
                p_Email = value
            End Set
        End Property

        Public Property Usuario As String
            Get
                Usuario = p_Usuario
            End Get
            Set(value As String)
                p_Usuario = value
            End Set
        End Property

        Public Property Contrasena As String
            Get
                Contrasena = p_Contrasena
            End Get
            Set(value As String)
                p_Contrasena = value
            End Set
        End Property

        Public Property NombreMostrar As String
            Get
                NombreMostrar = p_NombreMostrar
            End Get
            Set(value As String)
                p_NombreMostrar = value
            End Set
        End Property

        Public Property SMTP As String
            Get
                SMTP = p_SMTP
            End Get
            Set(value As String)
                p_SMTP = value
            End Set
        End Property

        Public Property POP3 As String
            Get
                POP3 = p_POP3
            End Get
            Set(value As String)
                p_POP3 = value
            End Set
        End Property

        Public Property PuertoSMTP As Integer
            Get
                PuertoSMTP = p_PuertoSMTP
            End Get
            Set(value As Integer)
                p_PuertoSMTP = value
            End Set
        End Property

        Public Property PuertoPOP3 As Integer
            Get
                PuertoPOP3 = p_PuertoPOP3
            End Get
            Set(value As Integer)
                p_PuertoPOP3 = value
            End Set
        End Property

        Public Property SSL As Boolean
            Get
                SSL = p_SSL
            End Get
            Set(value As Boolean)
                p_SSL = value
            End Set
        End Property


        Public Property HTML As Boolean
            Get
                HTML = p_HTML
            End Get
            Set(value As Boolean)
                p_HTML = value
            End Set
        End Property

        Private Sub CargarDatosEmailDeBD()

            Dim dtr As Object
            Dim bdPobs As New BaseDatos()
            Dim Sel As String = GL_SQL_TOP1_FRONT & " EMail, Usuario, Contrasena, NombreMostrar, SMTP, POP3Host, PuertoSMTP, PuertoPOP3, SSL, html FROM EmailConfiguracion WHERE Empresa = " & p_CodigoEmpresa & GL_SQL_TOP1_BACK

            dtr = bdPobs.ExecuteReader(Sel)
            If dtr.HasRows Then
                dtr.Read()

                Email = dtr("EMail")
                Usuario = dtr("Usuario")
                Contrasena = Encriptacion.DesEncriptar(dtr("Contrasena"), "LAMBDAPI")
                NombreMostrar = dtr("NombreMostrar")
                SMTP = dtr("SMTP")
                POP3 = dtr("POP3Host")
                PuertoSMTP = dtr("PuertoSMTP")
                PuertoPOP3 = dtr("PuertoPOP3")
                SSL = dtr("SSL")
                HTML = dtr("html")
            End If

            dtr.Close()
            bdPobs.CerrarBD()
        End Sub

    End Class



    Public Class clAgrupaciones

        Inherits clActualizaciones

        Public Agrupacion As String


        Sub New()
            Tabla = "Agrupaciones"
        End Sub



        Protected Overrides Sub CargarDatos(ByRef dr As System.Data.DataRow)

            dr("Agrupacion") = Agrupacion

        End Sub

    End Class



    Public Class clTablaGeneral
        Inherits clActualizaciones

        Sub New(NombreTabla As String, Optional FiltroPasado As String = "", Optional ConsultaEnVezDeTabla As String = "", Optional OrdenPasado As String = "")
            Tabla = NombreTabla
            ConsultaAEjecutar = ConsultaEnVezDeTabla
            If FiltroPasado = "" Then
                Filtro = ""
            Else
                If FiltroPasado.Length > 5 Then
                    If Microsoft.VisualBasic.InStr(Microsoft.VisualBasic.Left(FiltroPasado, 7), "WHERE", Microsoft.VisualBasic.CompareMethod.Text) = 0 Then
                        Filtro = " WHERE " & FiltroPasado
                    Else
                        Filtro = " " & FiltroPasado
                    End If
                End If
            End If

            Orden = ""
            If OrdenPasado = "" Then
                Orden = ""
            Else
                If OrdenPasado.Length > 5 AndAlso ConsultaEnVezDeTabla = "" Then
                    If Microsoft.VisualBasic.InStr(Microsoft.VisualBasic.Left(OrdenPasado, 8), "ORDER BY", Microsoft.VisualBasic.CompareMethod.Text) = 0 Then
                        Orden = " ORDER BY " & OrdenPasado
                    Else
                        Orden = " " & OrdenPasado
                    End If
                End If
            End If

        End Sub

        Protected Overrides Sub CargarDatos(ByRef dr As System.Data.DataRow)

        End Sub
    End Class

    Public Class clConfiguracionWeb

        Public Usuario As String
        Public Pass As String
        Public DirectorioFotos As String
        Public Servidor As String
        Public Web As String
        Public PaginaDetalle As String
        Public PaginaBusqueda As String
        Public web3B As Boolean
        Public APP3B As Boolean
        Public WebConHHTP As String

        Public FTPClienteUsuario As String
        Public FTPClientePass As String
        Public FTPClienteDireccion As String

        Public API_WP As String
        Public API_WP_ESPANOL As Boolean

        Public API_WP_Funcion_Propiedades As String
        Public API_WP_Funcion_Tipos As String
        Public API_WP_Funcion_TipoVentas As String
        Public API_WP_Funcion_Poblacion As String

        Public url_baja As String

        Public WP_Id_Agente As Integer
        Public WP_Id_Oportunidad As Integer
        Public WP_ColorOportunidad As String




    End Class







End Class
