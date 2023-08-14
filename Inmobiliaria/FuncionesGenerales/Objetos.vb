Module Objetos

    Public Class clPortalesFotoCasa
        Public Property PublicationId As Integer
        Public Property Name As String
        Public Property TypeId As Integer
        Public Property Url As String
        Public Property MaxNumPublishedProperties As Integer
      
    End Class

    Public Class PropertyAddress
        Public Property ZipCode As String
        Public Property CountryId As Integer
        Public Property Zone As String
        Public Property StreetTypeId As Integer
        Public Property Street As String
        Public Property Number As String
        Public Property FloorId As Integer
        Public Property x As Double
        Public Property y As Double
        Public Property VisibilityModeId As Integer
    End Class

    Public Class PropertyDocument
        Public Property TypeId As Integer
        Public Property description As String
        Public Property Url As String
        Public Property RoomTypeId As Integer
        Public Property FileTypeId As Integer
        Public Property Visible As Boolean
        Public Property SortingId As Integer
    End Class

    Public Class PropertyFeature
        Public Property FeatureId As Integer
        Public Property LanguageId As Integer
        Public Property BoolValue As Boolean
        Public Property DecimalValue As Integer?
        Public Property TextValue As String

        Sub New()
            BoolValue = False
            DecimalValue = 0
            TextValue = ""
        End Sub


    End Class

    Public Class PropertyContactInfo
        Public Property TypeId As Integer
        Public Property Value As String
        Public Property ValueTypeId As Integer
    End Class

    Public Class PropertyFeatureGroupComment
        Public Property FeatureGroupId As Integer
        Public Property LanguageId As Integer
        Public Property Comments As String
    End Class

    Public Class PropertyCustomer
        Public Property CustomerId As Integer
        Public Property IsPrincipal As Boolean
    End Class

    Public Class PropertyPublication
        Public Property PublicationId As Integer
        Public Property PublicationTypeId As Integer
    End Class

    Public Class PropertyTransaction
        Public Property TransactionTypeId As Integer
        Public Property CustomerPrice As Integer
        Public Property Price As Integer
        Public Property PriceM2 As Integer
        Public Property CurrencyId As Integer
        Public Property PaymentPeriodicityId As Integer
        Public Property ShowPrice As Boolean
    End Class

    Public Class Inmuebles
        Public Property ExternalId As String
        Public Property AgencyReference As String
        Public Property TypeId As Integer
        Public Property SubtypeId As Integer
        Public Property IsNewConstruction As Boolean
        Public Property PropertyStatusId As Integer
        'Public Property ExpirationCauseId As Integer?
        Public Property ShowSurface As Boolean
        Public Property ContactTypeId As Integer
        Public Property IsPromotion As Boolean
        'Public Property BankAwardedId As Integer?
        Public Property ContactName As String
        Public Property PropertyAddress As List(Of PropertyAddress)
        Public Property PropertyDocument As List(Of PropertyDocument)
        Public Property PropertyFeature As List(Of PropertyFeature)
        Public Property PropertyContactInfo As List(Of PropertyContactInfo)
        'Public Property PropertyFeatureGroupComment As List(Of PropertyFeatureGroupComment)
        'Public Property PropertyCustomer As List(Of PropertyCustomer)
        Public Property PropertyPublications As List(Of PropertyPublication)
        Public Property PropertyTransaction As List(Of PropertyTransaction)
    End Class

#Region "Google"
    Public Class GoogleGeoCodeResponse

        Public Property status() As String
            Get
                Return m_status
            End Get
            Set(value As String)
                m_status = Value
            End Set
        End Property
        Private m_status As String
        Public Property results() As results()
            Get
                Return m_results
            End Get
            Set(value As results())
                m_results = Value
            End Set
        End Property
        Private m_results As results()

    End Class

    Public Class results
        Public Property formatted_address() As String
            Get
                Return m_formatted_address
            End Get
            Set(value As String)
                m_formatted_address = Value
            End Set
        End Property
        Private m_formatted_address As String
        Public Property geometry() As geometry
            Get
                Return m_geometry
            End Get
            Set(value As geometry)
                m_geometry = Value
            End Set
        End Property
        Private m_geometry As geometry
        Public Property types() As String()
            Get
                Return m_types
            End Get
            Set(value As String())
                m_types = Value
            End Set
        End Property
        Private m_types As String()
        Public Property address_components() As address_component()
            Get
                Return m_address_components
            End Get
            Set(value As address_component())
                m_address_components = Value
            End Set
        End Property
        Private m_address_components As address_component()
    End Class

    Public Class geometry
        Public Property location_type() As String
            Get
                Return m_location_type
            End Get
            Set(value As String)
                m_location_type = Value
            End Set
        End Property
        Private m_location_type As String
        Public Property location() As location
            Get
                Return m_location
            End Get
            Set(value As location)
                m_location = Value
            End Set
        End Property
        Private m_location As location
    End Class

    Public Class location
        Public Property lat() As String
            Get
                Return m_lat
            End Get
            Set(value As String)
                m_lat = Value
            End Set
        End Property
        Private m_lat As String
        Public Property lng() As String
            Get
                Return m_lng
            End Get
            Set(value As String)
                m_lng = Value
            End Set
        End Property
        Private m_lng As String
    End Class

    Public Class address_component
        Public Property long_name() As String
            Get
                Return m_long_name
            End Get
            Set(value As String)
                m_long_name = Value
            End Set
        End Property
        Private m_long_name As String
        Public Property short_name() As String
            Get
                Return m_short_name
            End Get
            Set(value As String)
                m_short_name = Value
            End Set
        End Property
        Private m_short_name As String
        Public Property types() As String()
            Get
                Return m_types
            End Get
            Set(value As String())
                m_types = Value
            End Set
        End Property
        Private m_types As String()
    End Class
#End Region

End Module
