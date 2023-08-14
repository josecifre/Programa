Imports System.Net
Imports System.ServiceModel
Imports Newtonsoft.Json
Imports RestSharp



Module ConexionWS_Rest

    Public Class clAgencyExternal

        Public Property ExternalId As String
        Public Property AgencyReference As String

    End Class
    Public Class clResultado

        Public Property StatusCode As Integer
        Public Property Message As String
        Public Property Code As String

    End Class
    Public Function LlamarWebServicePOSTRestSharp(Funcion As String, PostData As String) As clResultado

        Dim Res As New clResultado

        Try
            
            Dim client = New RestClient(GL_wsRutaWs & Funcion)
            Dim request = New RestRequest(Method.[POST])
            Dim svcCredentials As String = ObtenerCredenciales(GL_CodigoUsuario)

            request.AddHeader("Authorization", "Basic " + svcCredentials)
            request.AddHeader("content-type", "application/json")
            If PostData <> "" Then
                request.AddParameter("application/json", PostData, ParameterType.RequestBody)
            End If
            '   request.AddParameter("application/json", "{""""Email"""":""""pruebas1@idoneapp.com""""}", ParameterType.RequestBody)
            Dim response As IRestResponse = client.Execute(request)

            If response.StatusDescription = "OK" Then
                Res.Message = response.Content
                Res.StatusCode = 0
                Res.Code = ""
            Else
                Res = Newtonsoft.Json.JsonConvert.DeserializeObject(Of clResultado)(response.Content)
                If IsNothing(Res) Then
                    Res = New clResultado
                    Res.StatusCode = -99
                    Res.Message = response.StatusDescription
                End If
                Res.Code = response.StatusDescription
            End If

        Catch ex4 As FaultException(Of clResultado)
            Res.StatusCode = ex4.Code.ToString
            Res.Message = ex4.Reason.ToString

        Catch ex5 As WebException
            Res.StatusCode = GL_CodigoErrorWebService
            Res.Message = ex5.Message

        Catch ex As Exception
            Res.StatusCode = GL_CodigoErrorWebService
            Res.Message = ex.Message
        End Try

        Return Res

    End Function

    Public Function SerializarPost(Dato As Object, Optional NombreDelObjeto As String = "") As String

        'Dim microsoftDateFormatSettings As JsonSerializerSettings = New JsonSerializerSettings
        'microsoftDateFormatSettings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat

        'Dim postData As String = JsonConvert.SerializeObject(Dato, microsoftDateFormatSettings)

        Dim postData As String = JsonConvert.SerializeObject(Dato)


        If NombreDelObjeto <> "" Then
            postData = "{""" & NombreDelObjeto & """:" & postData & "}" '
        End If


        Return postData

    End Function

    Public Function ObtenerCredenciales(Id As String)
        Dim Pass As String = "Med" & Id
        Pass = Encriptacion.Encriptar(Pass, "LAMBDAPI")
        Dim svcCredentials As String = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(Id + ":" + Pass))

        Return svcCredentials

    End Function
    'Public Function LlamarWebServiceGETRestSharp(Funcionyparametros As String) As clResultado

    '    Dim Res As New clResultado

    '    Try



    '        Dim client = New RestClient(GL_wsRutaWs & Funcionyparametros)
    '        Dim request = New RestRequest(Method.[GET])

    '        'Dim Pass As String = "Med" & GL_CodigoUsuario
    '        'Pass = Encriptacion.Encriptar(Pass, "LAMBDAPI")
    '        'Dim svcCredentials As String = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(GL_CodigoUsuario + ":" + Pass))

    '        Dim svcCredentials As String = ObtenerCredenciales(GL_CodigoUsuario)

    '        request.AddHeader("Authorization", "Basic " + svcCredentials)
    '        request.AddHeader("content-type", "application/json")
    '        '   request.AddParameter("application/json", "{""""Email"""":""""pruebas1@idoneapp.com""""}", ParameterType.RequestBody)
    '        Dim response As IRestResponse = client.Execute(request)

    '        If response.StatusDescription = "OK" Then
    '            Res.Mensaje = response.Content
    '            Res.Codigo = 0
    '            Res.InformacionAdicional = ""
    '        Else
    '            Res = Newtonsoft.Json.JsonConvert.DeserializeObject(Of clResultado)(response.Content)
    '            Res.InformacionAdicional = response.StatusDescription
    '        End If



    '    Catch ex4 As FaultException(Of clResultado)
    '        Res.Codigo = ex4.Code.ToString
    '        Res.Mensaje = ex4.Reason.ToString

    '    Catch ex5 As WebException
    '        Res.Codigo = GL_CodigoErrorWebService
    '        Res.Mensaje = ex5.Message

    '    Catch ex As Exception
    '        Res.Codigo = GL_CodigoErrorWebService
    '        Res.Mensaje = ex.Message
    '    End Try

    '    Return Res

    'End Function
End Module

