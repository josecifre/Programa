
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls


Public Class uc_tb_lst
    Inherits DevExpress.XtraEditors.ListBoxControl

    'Public Sub New()
    '    InitializeComponent()
    '    MyBase.New()
    'End Sub

    Private p_ValorBusqueda As Integer

    Public Property tb_ValorBusqueda() As Integer
        Get
            Return p_ValorBusqueda
        End Get

        Set(value As Integer)

            If p_ValorBusqueda <> value Then
                p_ValorBusqueda = value
                tb_LlenarLista()
            End If

        End Set
    End Property

   

    Private p_TablaEnlazada As String

    Public Property tb_TablaEnlazada() As String
        Get
            Return p_TablaEnlazada
        End Get

        Set(value As String)
            p_TablaEnlazada = value
        End Set
    End Property

    Private p_CampoFiltro As String

    Public Property tb_CampoFiltro() As String
        Get
            Return p_CampoFiltro
        End Get

        Set(value As String)
            p_CampoFiltro = value
        End Set
    End Property

    Private p_Orden As String

    Public Property tb_Orden() As String
        Get
            Return p_Orden
        End Get

        Set(value As String)
            p_Orden = value
        End Set
    End Property

    Private p_Campo As String

    Public Property tb_Campo() As String
        Get
            Return p_Campo
        End Get

        Set(value As String)
            p_Campo = value
        End Set
    End Property


    Private Sub tb_LlenarLista()


        Dim bdPobs As New BaseDatos()
        Dim Sel As String

        Me.DataSource = Nothing
        Sel = "SELECT " & tb_Campo & " FROM " & tb_TablaEnlazada & " WHERE  " & tb_CampoFiltro & " =  " & tb_ValorBusqueda

        If tb_Orden <> "" Then
            Sel = Sel & " ORDER BY " & tb_Orden
        End If
        bdPobs.LlenarDataSet(Sel, tb_TablaEnlazada)

        Me.DataSource = bdPobs.ds.Tables(tb_TablaEnlazada)

        'Me.DisplayMember = tb_Campo
        Me.DisplayMember = "Fecha"
        Me.ValueMember = "Fecha"
    End Sub

    

End Class


