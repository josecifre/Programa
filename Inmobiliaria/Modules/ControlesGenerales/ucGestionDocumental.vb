Imports System.IO

Public Class ucGestionDocumental

    Dim Contador As String
    Dim Documento As String = ""
    Dim CarpetaDocumento As String
    Dim TextoVerInicial As String
    Dim TextoAnadirInicial As String

    Sub New(Optional Texto As String = "")

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        TextoVerInicial = btnVerDocumento.Text
        TextoAnadirInicial = btnAnadirDocumento.Text
        If Texto = "" Then
            Texto = "Gestión Documental"
        Else
            Texto = "Gestión Documental " & Texto
        End If
        PanelGestionDocumental.Text = Texto
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    'Sub New(Contado As String, Document As String)

    '    ' Llamada necesaria para el diseñador.
    '    InitializeComponent()
    '    TextoVerInicial = btnVerDocumento.Text
    '    TextoAnadirInicial = btnAnadirDocumento.Text
    '    PanelGestionDocumental.Text = "Gestion Documental " & Documento
    '    RefrescarBotones(Contado, Document)

    'End Sub
    Private Sub PrepararCarpeta(Contado As String, Document As String)
        Contador = Contado
        Documento = Document
        CarpetaDocumento = clVariables.RutaServidor & "\Documentacion\" & Documento & "\" & Contador
        If Microsoft.VisualBasic.Right(clVariables.RutaServidor, 1) = "/" Or Microsoft.VisualBasic.Right(clVariables.RutaServidor, 1) = "\" Then
            CarpetaDocumento = clVariables.RutaServidor & "\Documentacion" & Documento & "\" & Contador
        Else
            CarpetaDocumento = clVariables.RutaServidor & "\Documentacion\" & Documento & "\" & Contador
        End If

    End Sub
    Public Sub Titulo(Descripcion As String)
        PanelGestionDocumental.Text = Descripcion
        PanelGestionDocumental.Refresh()
    End Sub

    Public Sub RefrescarBotones(Contado As String, Document As String)

        PrepararCarpeta(Contado, Document)
        PintarBotones()
    End Sub

    Private Sub btnAnadirDocumento_Click(sender As System.Object, e As System.EventArgs) Handles btnAnadirDocumento.Click
        InsertarDocumento(CarpetaDocumento)
        PintarBotones()
    End Sub

    Private Sub btnVerDocumento_Click(sender As System.Object, e As System.EventArgs) Handles btnVerDocumento.Click
        FuncionesGenerales.Funciones.VerDocumentos(CarpetaDocumento)

    End Sub

    Private Sub PintarBotones()

        btnVerDocumento.Text = TextoVerInicial
        btnVerDocumento.Enabled = False

        If Contador = "0" Then
            btnAnadirDocumento.Enabled = False
            Exit Sub
        End If

        btnAnadirDocumento.Enabled = True

        If Not System.IO.Directory.Exists(CarpetaDocumento) Then
            Exit Sub
        End If

        Dim Din As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(CarpetaDocumento)
        Dim cont As Integer = 0
        For Each file As System.IO.FileInfo In Din.GetFiles("*.*")
            If Not file.Attributes.ToString.Contains("Hidden") And Not file.Attributes.ToString.Contains("System") Then
                cont += 1
            End If
        Next
        btnVerDocumento.Text = TextoVerInicial & " (" & cont & ")"
        btnVerDocumento.Enabled = True
        'If DirFiles.Length > 0 Then
        '    btnConsultarInstruccionTecnica.ForeColor = ColorRojo
        'Else
        '    btnConsultarInstruccionTecnica.ForeColor = ColorOriginal
        'End If



    End Sub


End Class
