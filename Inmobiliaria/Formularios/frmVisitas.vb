Public Class frmVisitas 

    Dim p_ContadorCliente As String
    Dim p_ContadorInmueble As String
    Dim p_NombreCliente As String
    Dim p_Referencia As String
    Dim vengoDe As String

    Public EsBajas As Boolean = False

    Private WithEvents BinSrc As BindingSource

    Public Property ContadorCliente As Integer
        Get
            Return p_ContadorCliente
        End Get
        Set(value As Integer)
            p_ContadorCliente = value
        End Set
    End Property

    Public Property ContadorInmueble As Integer
        Get
            Return p_ContadorInmueble
        End Get
        Set(value As Integer)
            p_ContadorInmueble = value
        End Set
    End Property

    Public Property NombreCliente As String
        Get
            Return p_NombreCliente
        End Get
        Set(value As String)
            p_NombreCliente = value
        End Set
    End Property

    Public Property Referencia As String
        Get
            Return p_Referencia
        End Get
        Set(value As String)
            p_Referencia = value
        End Set
    End Property

    Sub New(ContadorClientePasado As Integer, NombreClientePasado As String, ContadorInmueblePasado As Integer, ReferenciaPasada As String, vengoDe As String)

        '  Llamada necesaria para el diseñador.
        InitializeComponent()

        ContadorCliente = ContadorClientePasado
        NombreCliente = NombreClientePasado
        ContadorInmueble = ContadorInmueblePasado
        Referencia = ReferenciaPasada
        Me.vengoDe = vengoDe
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Private Sub frmVisitas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If ContadorCliente = 0 Then
            btnConcertarVisita.Visible = False
            btnVisitasCliente.Visible = False
        End If
        If EsBajas Then btnConcertarVisita.Visible = False
        If ContadorInmueble = 0 Then
            btnVisitasInmueble.Visible = False
        End If
    End Sub
     
    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Salir()
    End Sub

    Private Sub Salir()
        Me.Dispose()
    End Sub

    Private Sub btnConcertarVisita_Click(sender As System.Object, e As System.EventArgs) Handles btnConcertarVisita.Click
        Dim f As New frmConcertarCita(ContadorCliente, NombreCliente, vengoDe)
        f.ShowDialog()
        Salir()
    End Sub

    Private Sub btnVisitasCliente_Click(sender As System.Object, e As System.EventArgs) Handles btnVisitasCliente.Click
        VisitasInmuebleCliente(False)

    End Sub
    Private Sub btnVisitasInmueble_Click(sender As System.Object, e As System.EventArgs) Handles btnVisitasInmueble.Click
        VisitasInmuebleCliente(False)
    End Sub

    Private Sub btnTodasLasVisitas_Click(sender As System.Object, e As System.EventArgs) Handles btnTodasLasVisitas.Click
        VisitasInmuebleCliente(True)
    End Sub

    Private Sub VisitasInmuebleCliente(Todas As Boolean)

        Dim ccli, cinm As String
        Dim Ref, ncli As String

        If Todas Then
            ccli = 0
            ncli = ""
            cinm = 0
            Ref = ""
        Else
            ccli = ContadorCliente
            ncli = NombreCliente
            cinm = ContadorInmueble
            Ref = Referencia
        End If

        Dim f As New frmVisitasConcertadas(ccli, ncli, cinm, Ref, vengoDe)
        If EsBajas Then f.EsBajas = True
        f.ShowDialog()
        Salir()
    End Sub

    
End Class