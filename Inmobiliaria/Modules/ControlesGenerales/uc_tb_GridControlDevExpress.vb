Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Registrator
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Registrator
Imports System.ComponentModel

Public Class MyGridControl
    Inherits GridControl

    Private p_CarpetaPerfiles As String = ""
    Private p_tbPerfilPredeterminado As String = ""
    Private FicheroInformacionPerfiles As String = ""
    Private p_ColumnaCheck As GridCheckMarksSelection
    Private p_tb_AnadirColumnaCheck As Boolean

   

    Property ColumnaCheck() As GridCheckMarksSelection
        Get
            Return p_ColumnaCheck
        End Get
        Set(ByVal value As GridCheckMarksSelection)
            p_ColumnaCheck = value
           


        End Set
    End Property

    Property tb_AnadirColumnaCheck() As Boolean
        Get
            Return p_tb_AnadirColumnaCheck
        End Get
        Set(ByVal value As Boolean)
            p_tb_AnadirColumnaCheck = value
            Try
                If p_tb_AnadirColumnaCheck Then
                    AnadirColumnaCheck()

                Else
                    If Not IsNothing(p_ColumnaCheck) Then
                        If Not IsNothing(p_ColumnaCheck.View) Then
                            p_ColumnaCheck.View = Nothing
                        End If
                    End If

                End If
            Catch ex As Exception

            End Try



        End Set
    End Property


    <Category("Comportamiento"), Description("Establece la carpeta donde se encuentran los perfiles para este grid y este usuario"), _
DefaultValue("")> _
    Property tbCarpetaPerfiles() As String
        Get
            tbCarpetaPerfiles = p_CarpetaPerfiles
        End Get
        Set(ByVal value As String)
            p_CarpetaPerfiles = value
            FicheroInformacionPerfiles = p_CarpetaPerfiles & "/InformacionPerfiles.xml"
        End Set
    End Property

    Property tbPerfilPredeterminado() As String
        Get
            Return p_tbPerfilPredeterminado
        End Get
        Set(ByVal value As String)
            p_tbPerfilPredeterminado = value

        End Set
    End Property
    Protected Overrides Function CreateDefaultView() As BaseView
        Return CreateView("MyGridView")
    End Function
    Protected Overrides Sub RegisterAvailableViewsCore(ByVal collection As InfoCollection)
        MyBase.RegisterAvailableViewsCore(collection)
        collection.Add(New MyGridViewInfoRegistrator)
    End Sub

    Public Sub AnadirColumnaCheck()
        p_ColumnaCheck = New GridCheckMarksSelection(Me.MainView)
    End Sub

#Region "Perfiles"

    Public Function tbEstablecerPerfilPredeterminado() As Boolean

        Dim NombrePefilPredeterminado As String
        Dim FicheroInformacionPerfiles As String
        FicheroInformacionPerfiles = p_CarpetaPerfiles & "/InformacionPerfiles.xml"
        If Not System.IO.File.Exists(FicheroInformacionPerfiles) Then
            Return False
        End If

        Dim FicheroPerfilPredeterminado As String = RecuperarPredeterminadoOActual("PREDETERMINADO", p_CarpetaPerfiles, True)

        If FicheroPerfilPredeterminado = "" Then
            Return False
        End If
        NombrePefilPredeterminado = FicheroPerfilPredeterminado
        FicheroPerfilPredeterminado = p_CarpetaPerfiles & "\" & NombrePefilPredeterminado & ".xml"

        If Not System.IO.File.Exists(FicheroPerfilPredeterminado) Then
            Return False
        End If

        EscribirPredeterminadoOActual(NombrePefilPredeterminado, "ACTUAL")
        tbPerfilPredeterminado = NombrePefilPredeterminado
        Try
            Me.MainView.RestoreLayoutFromXml(FicheroPerfilPredeterminado, DevExpress.Utils.OptionsLayoutBase.FullLayout)

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Sub tbRecuperarPerfil(ByVal NombrePerfil)
        Try
            Dim g As MyGridView
            g = Me.MainView
            g.RestoreLayoutFromXml(p_CarpetaPerfiles & "\" & NombrePerfil & ".xml", DevExpress.Utils.OptionsLayoutBase.FullLayout)
            EscribirPredeterminadoOActual(NombrePerfil, "ACTUAL")
        Catch ex As Exception

        End Try
    End Sub

   

    Private Sub EscribirPredeterminadoOActual(ByVal NombrePerfil As String, ByVal Tipo As String, Optional ByVal ValoresPorDefecto As Boolean = False)

        If Tipo = "PREDETERMINADO" AndAlso NombrePerfil = "" AndAlso Not ValoresPorDefecto Then
            MessageBox.Show("Debe guardar el perfil con un nombre para establecerlo como predeterminado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If Not ValoresPorDefecto Then
            If Not System.IO.File.Exists(FicheroInformacionPerfiles) Then
                If Tipo = "PREDETERMINADO" Then
                    ComprobarYCrearCarpetas(p_CarpetaPerfiles)
                    System.IO.File.Copy(My.Application.Info.DirectoryPath & "/InformacionPerfiles.xml", FicheroInformacionPerfiles)
                Else
                    Exit Sub
                End If

            End If
        End If

        Dim dt As DataTable
        '  Dim dr As DataRow

        Dim ds As New DataSet
        ds.ReadXmlSchema(FicheroInformacionPerfiles)
        ds.ReadXml(FicheroInformacionPerfiles)
        dt = ds.Tables("Info")
        For Each drr As DataRow In dt.Rows
            If drr("Tipo") = Tipo Then
                drr("Nombre") = NombrePerfil
                ds.AcceptChanges()
                ds.WriteXml(FicheroInformacionPerfiles, XmlWriteMode.WriteSchema)

            End If
        Next

        If Tipo = "PREDETERMINADO" Then
            If ValoresPorDefecto Then
                MessageBox.Show("Debe salir y volver a entrar en la pantalla para completar los cambios.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Diseño establecido como predeterminado correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        End If

        'REVISAR
        'If Tipo = "ACTUAL" Then
        '    Try
        '        mnuPerfilActual.Text = "Perfil Actual: " & NombrePerfil

        '    Catch ex As Exception

        '    End Try
        'End If


    End Sub

    Private Function ComprobarYCrearCarpetas(ByVal Directorio As String) As String

        If Not IO.Directory.Exists(Directorio) Then
            IO.Directory.CreateDirectory(Directorio)
        End If
        Return Directorio
    End Function
    'Private Function RecuperarPredeterminadoOActual(ByVal Tipo As String, Fichero As String) As String


    '    If Not System.IO.File.Exists(Fichero) Then
    '        Return ""
    '    End If

    '    Dim Predeterminado As String = ""
    '    Dim dt As DataTable
    '    Dim ds As New DataSet
    '    ds.ReadXmlSchema(Fichero)
    '    ds.ReadXml(Fichero)
    '    dt = ds.Tables("Info")
    '    For Each drr As DataRow In dt.Rows
    '        If drr("Tipo") = Tipo Then
    '            Predeterminado = drr("Nombre")
    '        End If
    '    Next

    '    Return Predeterminado

    'End Function
    Private Function RecuperarPredeterminadoOActual(ByVal Tipo As String, ByVal CarpetaPerfiles As String, Perfil As Boolean) As String

        Dim FicheroInformacion As String = ""

        If Perfil Then
            FicheroInformacionPerfiles = CarpetaPerfiles & "/InformacionPerfiles.xml"
        Else
            FicheroInformacionPerfiles = CarpetaPerfiles & "/InformacionFiltros.xml"
        End If

        If Not System.IO.File.Exists(FicheroInformacionPerfiles) Then
            Return ""
        End If

        Dim Predeterminado As String = ""
        Dim dt As DataTable
        Dim ds As New DataSet
        ds.ReadXmlSchema(FicheroInformacionPerfiles)
        ds.ReadXml(FicheroInformacionPerfiles)
        dt = ds.Tables("Info")
        For Each drr As DataRow In dt.Rows
            If drr("Tipo") = Tipo Then
                Predeterminado = drr("Nombre")
            End If
        Next

        Return Predeterminado

    End Function



#End Region
End Class
Public Class MyGridView
    Inherits GridView

    Public Sub New()
        Me.New(Nothing)
    End Sub
    Public Sub New(ByVal grid As GridControl)
        MyBase.New(grid)
        ' put your initialization code here

    End Sub
    Protected Overrides ReadOnly Property ViewName() As String
        Get
            Return "MyGridView"
        End Get
    End Property
    Protected Overrides Function CreateColumnCollection() As Global.DevExpress.XtraGrid.Columns.GridColumnCollection
        Return New MyGridColumnCollection(Me)
    End Function
    Protected Overrides Function CreateFilterRowInfo(ByVal column As DevExpress.XtraGrid.Columns.GridColumn, ByVal _value As Object) As DevExpress.XtraGrid.Columns.ColumnFilterInfo
        Try
            If TypeOf (column) Is MyGridColumn AndAlso CType(column, MyGridColumn).UseAdvancedFiltering = True AndAlso CStr(_value) <> "" Then
                Dim FilterText As String = _value
                If FilterText.Contains("%") = False AndAlso FilterText.Contains("_") = False Then
                    FilterText = "%" & _value & "%"
                End If
                Return New DevExpress.XtraGrid.Columns.ColumnFilterInfo(DevExpress.XtraGrid.Columns.ColumnFilterType.AutoFilter, _value, New DevExpress.Data.Filtering.BinaryOperator(column.FieldName, FilterText, DevExpress.Data.Filtering.BinaryOperatorType.Like), Nothing)
            Else
                Return MyBase.CreateFilterRowInfo(column, _value)
            End If
        Catch ex As Exception
            Return MyBase.CreateFilterRowInfo(column, _value)
        End Try
    End Function


End Class
Public Class MyGridViewInfoRegistrator
    Inherits GridInfoRegistrator
    Public Overrides ReadOnly Property ViewName() As String
        Get
            Return "MyGridView"
        End Get
    End Property
    Public Overrides Function CreateView(ByVal grid As GridControl) As BaseView
        Return New MyGridView(grid)
    End Function
End Class
Public Class MyGridColumn
    Inherits Global.DevExpress.XtraGrid.Columns.GridColumn
    Public Sub New()
        MyBase.New()
    End Sub
    Private mUseAdvancedFiltering As Boolean = True
    Public Property UseAdvancedFiltering() As Boolean
        Get
            Return Me.mUseAdvancedFiltering
        End Get
        Set(ByVal value As Boolean)
            Me.mUseAdvancedFiltering = value
        End Set
    End Property
End Class
Public Class MyGridColumnCollection
    Inherits GridColumnCollection
    Public Sub New(ByVal View As Global.DevExpress.XtraGrid.Views.Base.ColumnView)
        MyBase.New(View)
    End Sub
    Protected Overrides Function CreateColumn() As Global.DevExpress.XtraGrid.Columns.GridColumn
        Return New MyGridColumn()
    End Function
End Class


<UserRepositoryItem("Register")> _
Public Class MyRepositoryLookupEdit
    Inherits DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend Const MyRepositoryLookupEditName As String = "MyLookupEdit"
    Shared Sub New()
        MyRepositoryLookupEdit.Register()
    End Sub
    Sub New()
        MyBase.new()
    End Sub
    Shared Sub Register()
        EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(MyRepositoryLookupEditName, GetType(MyLookupEdit), GetType(MyRepositoryLookupEdit), GetType(DevExpress.XtraEditors.ViewInfo.LookUpEditViewInfo), New DevExpress.XtraEditors.Drawing.ButtonEditPainter, True, EditImageIndexes.LookUpEdit))
    End Sub
    Public Overrides ReadOnly Property EditorTypeName() As String
        Get
            Return MyRepositoryLookupEdit.MyRepositoryLookupEditName
        End Get
    End Property
    Protected Overrides Function CreateDataAdapter() As DevExpress.XtraEditors.ListControls.LookUpListDataAdapter
        Return New MyLookUpListDataAdapter(Me)
    End Function
    Private mUseAdvancedFiltering As Boolean = True
    Public Property UseAdvancedFiltering() As Boolean
        Get
            Return Me.mUseAdvancedFiltering
        End Get
        Set(ByVal value As Boolean)
            Me.mUseAdvancedFiltering = value
        End Set
    End Property
End Class
Public Class MyLookupEdit
    Inherits DevExpress.XtraEditors.LookUpEdit
    Shared Sub New()
        MyRepositoryLookupEdit.Register()
    End Sub
    Sub New()
        MyBase.New()
    End Sub
    Public Overrides ReadOnly Property EditorTypeName() As String
        Get
            Return MyRepositoryLookupEdit.MyRepositoryLookupEditName
        End Get
    End Property
    Public Overloads ReadOnly Property Properties() As MyRepositoryLookupEdit
        Get
            Return MyBase.Properties
        End Get
    End Property
End Class
Public Class MyLookUpListDataAdapter
    Inherits DevExpress.XtraEditors.ListControls.LookUpListDataAdapter
    Public Sub New(ByVal item As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)
        MyBase.New(item)
    End Sub
    Protected Overrides Function CreateFilterExpression() As String
        Try
            If CType(Me.Item, MyRepositoryLookupEdit).UseAdvancedFiltering = True Then
                Dim FilterText As String = Me.FilterPrefix
                If FilterText.Contains("%") = False Then
                    FilterText = "%" & FilterText & "%"
                End If
                Return New DevExpress.Data.Filtering.BinaryOperator(Me.FilterField, FilterText, DevExpress.Data.Filtering.BinaryOperatorType.Like).ToString()
            Else
                Return MyBase.CreateFilterExpression()
            End If
        Catch ex As Exception
            Return MyBase.CreateFilterExpression()
        End Try
    End Function
End Class

