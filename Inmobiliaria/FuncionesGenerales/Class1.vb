

Option Infer On

Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Threading.Tasks
Imports System.Web
Imports Microsoft.VisualBasic

<HttpGet>
Public Function FromImages() As HttpResponseMessage

    Dim imageStream = New ImageStream()
    Dim func As Func(Of Stream, HttpContext, TransportContext, Task) = AddressOf imageStream.WriteToStream
    Dim response = Request.CreateResponse()
    response.Content = New PushStreamContent(func)
    response.Content.Headers.Remove("Content-Type")
    response.Content.Headers.TryAddWithoutValidation("Content-Type", "multipart/x-mixed-replace;boundary=" & imageStream.Boundary)
    Return response

End Function

Friend Class ImageStream
    Private privateBoundary As Object = "HintDesk"
    Public Property Boundary() As Object
        Get
            Return privateBoundary
        End Get
        Private Set(ByVal value As Object)
            privateBoundary = value
        End Set
    End Property

    Public Async Function WriteToStream(ByVal outputStream As Stream, ByVal content As HttpContext, ByVal context As TransportContext) As Task
        Dim newLine() As Byte = Encoding.UTF8.GetBytes(ControlChars.CrLf)

        For Each file In Directory.GetFiles("TestData\Images", "*.jpg")
            Dim fileInfo = New FileInfo(file)
            Dim header = $"--{Boundary}" & ControlChars.CrLf & "Content-Type: image/jpeg" & ControlChars.CrLf & "Content-Length: {1}" & ControlChars.CrLf & ControlChars.CrLf
            Dim headerData = Encoding.UTF8.GetBytes(header)
            Await outputStream.WriteAsync(headerData, 0, headerData.Length)
            Await fileInfo.OpenRead().CopyToAsync(outputStream)
            Await outputStream.WriteAsync(newLine, 0, newLine.Length)
            Await Task.Delay(1000 \ 30)
        Next file
    End Function
End Class
