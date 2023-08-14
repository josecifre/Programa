Imports System.IO

Public Class MapaGoogle

    'Dim szNumero As String

    Private Direccion As String
    Private CodPostal As String
    Private Localidad As String
    Private Provincia As String
    Private Ancho As Integer
    Private Alto As Integer

    Sub New(Optional ByVal Dir As String = "", Optional ByVal CP As String = "", Optional ByVal Loc As String = "", Optional ByVal Prov As String = "", Optional ByVal AnchoDelControl As Integer = 640, Optional ByVal AltoDelControl As Integer = 480)

        Direccion = Dir
        CodPostal = CP
        Localidad = Loc
        Provincia = Prov
        Ancho = AnchoDelControl
        Alto = AltoDelControl

    End Sub

    Public Function ObtenerFichero() As String
        Dim Fichero As String
        Dim httpDireccion As String
        Dim szCadenaSalida As String


        Direccion = Replace(Direccion, ".", " ")
        Direccion = Replace(Direccion, "Nº", "")
        Direccion = Replace(Direccion, "º", "")
        Direccion = Replace(Direccion, " ", "+")

        
        'Dim objetoMaps As New MapsNet
        'httpDireccion = objetoMaps.ObtenerURLdesdeDireccion(Dire) 'String con la direccion


        httpDireccion = Direccion & ",+" & CodPostal & ",+" & Replace(Localidad, " ", "+") & ",+" & Provincia
        szCadenaSalida = "<iframe width='" & Ancho & "' height='" & Alto & "' frameborder='0' scrolling='no' marginheight='0' marginwidth='0'"
        'szCadenaSalida = szCadenaSalida & httpDireccion & "</iframe>"



        szCadenaSalida = szCadenaSalida & "src='http://maps.google.es/maps?f=q&amp;source=s_q&amp;hl=es&amp;geocode=&amp;q="
        szCadenaSalida = szCadenaSalida & httpDireccion
        szCadenaSalida = szCadenaSalida & "&amp;output=embed'></iframe>"

        FuncionesGenerales.Funciones.ComprobarYCrearCarpetas("TMP", True)
        Fichero = My.Application.Info.DirectoryPath & "\TMP\Google" & Format(Now, "ddmmyyyyhhmmss") & ".html"
        Dim sw As New StreamWriter(Fichero)
        sw.WriteLine(szCadenaSalida)
        sw.Close()

        ' Return szCadenaSalida
        Return Fichero




    End Function

End Class
