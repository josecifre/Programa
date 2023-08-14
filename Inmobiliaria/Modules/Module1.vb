
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Columns
Imports System.Data
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports System.ComponentModel


Public Class CheckedLookUpEdit
    Inherits PopupContainerEdit
    '  Implements ISupportInitialize
    Protected Overrides Sub CreateRepositoryItem()
        fProperties = New RepositoryItemCheckedLookUpEdit(Me)
    End Sub
    <Description("Specifies settings specific to the current editor."), Category("Properties"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public Shadows ReadOnly Property Properties() As RepositoryItemCheckedLookUpEdit
        Get
            Return TryCast(MyBase.Properties, RepositoryItemCheckedLookUpEdit)
        End Get
    End Property
#Region "ISupportInitialize Members"

    Public Sub BeginInit()
        Properties.BeginInit()
    End Sub

    Public Sub EndInit()
        Properties.EndInit()
    End Sub

#End Region

    Private firstShow As Boolean = True
    Protected Overrides Function CalcPopupFormSize() As System.Drawing.Size
        If firstShow Then
            firstShow = False
            Return New System.Drawing.Size(Me.Width, 250)
        End If
        Return MyBase.CalcPopupFormSize()
    End Function
End Class
<UserRepositoryItem("Register")> _
Public Class RepositoryItemCheckedLookUpEdit
    Inherits RepositoryItemPopupContainerEdit
    Implements System.ComponentModel.ISupportInitialize
    Private m_dataSource As Object
    Friend Const EditorName As String = "CheckedLookUpEdit"

    Shared Sub New()
        Register()
    End Sub

    Public Shared Sub Register()
        EditorRegistrationInfo.[Default].Editors.Add(New DevExpress.XtraEditors.Registrator.EditorClassInfo(EditorName, GetType(CheckedLookUpEdit), GetType(RepositoryItemCheckedLookUpEdit), GetType(DevExpress.XtraEditors.ViewInfo.LookUpEditViewInfo), New DevExpress.XtraEditors.Drawing.ButtonEditPainter(), True))
    End Sub

    <Category("Data")> _
    Public Property SeparatorChar() As Char
        Get
            Return m_SeparatorChar
        End Get
        Set(value As Char)
            m_SeparatorChar = value
        End Set
    End Property
    Private m_SeparatorChar As Char
    <Category("Data")> _
    Public Property DisplaySeparatorChar() As Char
        Get
            Return m_DisplaySeparatorChar
        End Get
        Set(value As Char)
            m_DisplaySeparatorChar = value
        End Set
    End Property
    Private m_DisplaySeparatorChar As Char
    <Category("Data")> _
    <AttributeProvider(GetType(IListSource))> _
    <Description("Gets or sets the source of data displayed in the dropdown window.")> _
    <DefaultValue("")> _
    Public Property DataSource() As Object
        Get
            Return m_dataSource
        End Get
        Set(value As Object)
            m_dataSource = value
            If View IsNot Nothing AndAlso View.GridControl IsNot Nothing Then
                View.GridControl.DataSource = value
                If View.Columns.Count < 2 Then
                    View.PopulateColumns()
                    If PopupControl IsNot Nothing Then
                        TryCast(PopupControl, CheckedLookUpEditPopUpControl).PrepareView()
                    End If
                End If
            End If
        End Set
    End Property
    <Category("Data")> _
    Public Property ValueMember() As String
        Get
            Return m_ValueMember
        End Get
        Set(value As String)
            m_ValueMember = value
        End Set
    End Property
    Private m_ValueMember As String
    <Category("Data")> _
    Public Property DisplayMember() As String
        Get
            Return m_DisplayMember
        End Get
        Set(value As String)
            m_DisplayMember = value
        End Set
    End Property
    Private m_DisplayMember As String
    <Category("Data")> _
    Public ReadOnly Property View() As GridView
        Get
            Return TryCast(PopupControl, CheckedLookUpEditPopUpControl).View
        End Get
    End Property
    Private Sub Initialize()
        '  Me.QueryPopUp += New CancelEventHandler(RepositoryItemCheckedLookUpEdit_QueryPopUp)

        AddHandler Me.QueryPopUp, AddressOf RepositoryItemCheckedLookUpEdit_QueryPopUp
        Me.PopupControl = New CheckedLookUpEditPopUpControl()
        SeparatorChar = "|"c
        DisplaySeparatorChar = ","c
        TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
    End Sub

    Private Sub RepositoryItemCheckedLookUpEdit_QueryPopUp(sender As Object, e As CancelEventArgs)
        '(PopupControl as CheckedLookUpEditPopUpControl).EditValue = (sender as BaseEdit).EditValue;
        TryCast(PopupControl, CheckedLookUpEditPopUpControl).PrepareView()
    End Sub
    Protected Overrides Sub RaiseParseEditValue(e As DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs)
        TryCast(PopupControl, CheckedLookUpEditPopUpControl).EditValue = e.Value
        MyBase.RaiseParseEditValue(e)
    End Sub

    Public Overrides Function GetDisplayText(editValue As Object) As String
        Return TryCast(Me.PopupControl, CheckedLookUpEditPopUpControl).GetDisplayText(editValue)
    End Function

    Protected Overrides Sub RaiseQueryDisplayText(e As DevExpress.XtraEditors.Controls.QueryDisplayTextEventArgs)
        e.DisplayText = TryCast(Me.PopupControl, CheckedLookUpEditPopUpControl).GetDisplayText(e.EditValue)
    End Sub

    Protected Overrides Sub RaiseQueryResultValue(e As DevExpress.XtraEditors.Controls.QueryResultValueEventArgs)
        e.Value = TryCast(Me.PopupControl, CheckedLookUpEditPopUpControl).EditValue
        MyBase.RaiseQueryResultValue(e)
    End Sub
    Protected Overrides Sub RaiseQueryPopUp(e As CancelEventArgs)
        MyBase.RaiseQueryPopUp(e)

        TryCast(Me.PopupControl, CheckedLookUpEditPopUpControl).EditValue = ConvertArgs.Value
    End Sub

    Public Sub New()
        MyBase.New()
        Initialize()
    End Sub
    Public Sub New(edit As CheckedLookUpEdit)
        Initialize()
        SetOwnerEdit(edit)
    End Sub

    Public Overrides Function CreateEditor() As BaseEdit
        Return New CheckedLookUpEdit()
    End Function
    Public Overrides ReadOnly Property EditorTypeName() As String
        Get
            Return EditorName
        End Get
    End Property
    <Browsable(False)> _
    Public Overrides Property TextEditStyle() As DevExpress.XtraEditors.Controls.TextEditStyles
        Get
            Return DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        End Get
        Set(value As DevExpress.XtraEditors.Controls.TextEditStyles)
            MyBase.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        End Set
    End Property
    Public Overrides Sub Assign(item As RepositoryItem)
        MyBase.Assign(item)
        Dim rep As RepositoryItemCheckedLookUpEdit = TryCast(item, RepositoryItemCheckedLookUpEdit)
        Me.ValueMember = rep.ValueMember
        Me.DisplayMember = rep.DisplayMember
        Me.DataSource = rep.DataSource
        Me.SeparatorChar = rep.SeparatorChar
        Me.DisplaySeparatorChar = rep.DisplaySeparatorChar

    End Sub
End Class


