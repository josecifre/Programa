Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

 
Public Class uc_tb_CombosCheck
    Inherits CheckedComboBoxEdit

    'Public Sub New()
    '    InitializeComponent()
    '    MyBase.New()
    'End Sub

    Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        p_EstoyEnAlta = False
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public p_ValorBusqueda As Integer
    Private p_EstoyEnAlta As Boolean
    Private p_CadenaConLosValores As String

    Public Property CadenaConLosValores As String
        Get
            Return p_CadenaConLosValores
        End Get
        Set(value As String)
            p_CadenaConLosValores = value
            Me.SetEditValue(value)
        End Set
    End Property

    Public Property EstoyEnAlta As Boolean
        Get
            Return p_EstoyEnAlta
        End Get
        Set(value As Boolean)
            p_EstoyEnAlta = value
        End Set
    End Property


    Public Property tb_ValorBusqueda() As Integer
        Get
            Return p_ValorBusqueda
        End Get

        Set(value As Integer)

            If p_EstoyEnAlta Then
                p_EstoyEnAlta = False
                p_CadenaConLosValores = Me.Properties.GetCheckedItems
            Else
                If p_ValorBusqueda <> value Then
                    p_ValorBusqueda = value
                    tb_PreparaDatosComboCheck()
                End If
            End If


        End Set
    End Property

    Private p_TablaCompleta As String

    Public Property tb_TablaCompleta() As String
        Get
            Return p_TablaCompleta
        End Get

        Set(value As String)
            p_TablaCompleta = value
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

    Private p_Campo As String

    Public Property tb_Campo() As String
        Get
            Return p_Campo
        End Get

        Set(value As String)
            p_Campo = value
        End Set
    End Property


    Public Sub tb_LlenarCompleta(Optional ByVal Orden As String = "", Optional ByVal ConsultaCompleta As String = "", Optional HacerClear As Boolean = True)
        Dim bdPobs As New BaseDatos()
        If Orden = "" Then
            Orden = tb_Campo
        End If
        Dim Tab As New Tablas.clTablaGeneral(tb_TablaCompleta, , IIf(ConsultaCompleta = "", "SELECT " & tb_Campo & " FROM  " & tb_TablaCompleta & " ORDER BY " & Orden, ConsultaCompleta))
        bdPobs = New BaseDatos
        Tab.Datos(bdPobs, Tab.ConsultaAEjecutar, , , , , True)

        Me.Properties.DataSource = Nothing
        If HacerClear Then
            Me.Properties.Items.Clear()
        End If

        Me.Properties.DataSource = bdPobs.ds.Tables(Tab.Tabla)

        Me.Properties.DisplayMember = tb_Campo
        Me.Properties.ValueMember = tb_Campo
        Me.Properties.SeparatorChar = ";"
    End Sub

    Public Sub tb_PreparaDatosComboCheck()

        'If tb_ValorBusqueda Is Nothing Then
        '    Me.SetEditValue(Nothing)
        '    Exit Sub
        'End If

        If tb_ValorBusqueda = Nothing Then
            Me.SetEditValue(Nothing)
            Exit Sub
        End If

        Dim bdPobs As New BaseDatos()

        Dim Sel As String
        Dim dtr As Object

        Sel = "SELECT " & tb_Campo & " FROM " & tb_TablaEnlazada & " WHERE  " & tb_CampoFiltro & " = " & tb_ValorBusqueda
        Dim Elementos As String = ""
        dtr = bdPobs.ExecuteReader(Sel)
        If dtr.HasRows Then
            While dtr.Read
                If Elementos = "" Then
                    Elementos = dtr(tb_Campo)
                Else
                    Elementos = Elementos & ";" & dtr(tb_Campo)
                End If

            End While
        End If
        dtr.Close()
        bdPobs.CerrarBD()
        Me.SetEditValue(Elementos)

        'tb_HabilitarDesHabilitarItems(False)
        '    tb_HabilitarDesHabilitarItems(True)
    End Sub

    Public Sub tb_HabilitarDesHabilitarItems(Habilitar As Boolean)
        For Each c As CheckedListBoxItem In Me.Properties.Items
            c.Enabled = Habilitar
        Next
    End Sub



    Public Sub tb_ActualizaDatosCombos()

        Try
            Dim Sel As String
            Dim BdBorra As New BaseDatos
            Sel = "" & GL_SQL_DELETE & "FROM " & tb_TablaEnlazada & " WHERE " & tb_CampoFiltro & " =  " & tb_ValorBusqueda
            BdBorra.Execute(Sel)

            Dim Campos() As String
            If p_CadenaConLosValores <> "" Then
                Campos = Split(p_CadenaConLosValores, ";")
                p_CadenaConLosValores = ""
            Else
                Campos = Split(Me.Properties.GetCheckedItems, ";")
            End If
            'If Campos.Length = Me.Properties.Items.Count Then
            '    Me.SetEditValue("")
            '    Exit Sub
            'End If
            ''JCB Nuevo para quitar los blancos
            'If Campos.Length > 1 OrElse (Campos.Length = 1 AndAlso Campos(0).ToString <> "") Then
            '    For i = 0 To Campos.Count - 1
            '        If Campos(i).Trim <> "" Then
            '            Sel = "INSERT INTO " & tb_TablaEnlazada & " VALUES ( " & tb_ValorBusqueda & " , '" & FuncionesGenerales.Funciones.pf_ReplaceComillas(Campos(i).Trim()) & "' )"
            '            BdBorra.Execute(Sel)
            '        End If

            '    Next

            '    tb_PreparaDatosComboCheck()
            'Else
            '    Me.SetEditValue("")

            'End If

          Me.SetEditValue("")
            'JCB Nuevo para quitar los blancos
            If Campos.Length > 1 OrElse (Campos.Length = 1 AndAlso Campos(0).ToString <> "") Then
                For i = 0 To Campos.Count - 1
                    If Campos(i).Trim <> "" Then
                        Sel = "INSERT INTO " & tb_TablaEnlazada & " VALUES ( " & tb_ValorBusqueda & " , '" & FuncionesGenerales.Funciones.pf_ReplaceComillas(Campos(i).Trim()) & "' )"
                        BdBorra.Execute(Sel)
                    End If

                Next

                tb_PreparaDatosComboCheck()
            Else


            End If






        Catch ex As Exception
            MensajeError(ex.Message)
        End Try
    End Sub


End Class

