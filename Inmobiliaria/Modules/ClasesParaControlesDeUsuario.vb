Namespace Venalia.ControlesTB


    Public Class SiNoUnNumero

        Private p_Valor As String
        Private p_CajaTexto1 As Integer

        Public Property Valor() As String
            Get
                Return p_Valor
            End Get

            Set(value As String)
                p_Valor = value
            End Set

        End Property

        Public Property ValorCajaTexto1() As Integer
            Get
                Return p_CajaTexto1
            End Get

            Set(value As Integer)
                p_CajaTexto1 = value
            End Set

        End Property

    End Class

    Public Class cl_Propietarios

        Private p_ContadorPropietario As Integer
        Private p_Nombre As String
        Private p_Nif As String
        Private p_Alias As String
        Private p_Via As String
        Private p_Domicilio As String
        Private p_Poblacion As String
        Private p_CodPostal As String
        Private p_Provincia As String
        Private p_PaisCliente As String
        Private p_Telefono1 As String
        Private p_Telefono2 As String
        Private p_TelefonoMovil As String
        Private p_FaxCliente As String
        Private p_EmailCliente As String
        Private p_OtrasObservaciones As String
        Private p_AplicarIVANulo As String
        Private p_AplicarRE As String
        Private p_Web As String
        Private p_Fecha As String
        Private p_NoInmobiliaria As String
        Private p_Delegacion As String
        Private p_FechaEnVenta As String
        Private p_AvisadoTresPorCien As String
        Private p_AvisadoMensualidad As String

        Public Property ContadorPropietario() As Integer
            Get
                Return p_ContadorPropietario
            End Get

            Set(value As Integer)
                p_ContadorPropietario = value
            End Set

        End Property

        Public Property Nombre() As String
            Get
                Return p_Nombre
            End Get

            Set(value As String)
                p_Nombre = value
            End Set

        End Property

        Public Property Telefono1() As String
            Get
                Return p_Telefono1
            End Get

            Set(value As String)
                p_Telefono1 = value
            End Set

        End Property

        Public Property Telefono2() As String
            Get
                Return p_Telefono2
            End Get

            Set(value As String)
                p_Telefono2 = value
            End Set

        End Property

        Public Property TelefonoMovil() As String
            Get
                Return p_TelefonoMovil
            End Get

            Set(value As String)
                p_TelefonoMovil = value
            End Set

        End Property

        Public Property OtrasObservaciones() As String
            Get
                Return p_OtrasObservaciones
            End Get

            Set(value As String)
                p_OtrasObservaciones = value
            End Set

        End Property






    End Class

End Namespace

