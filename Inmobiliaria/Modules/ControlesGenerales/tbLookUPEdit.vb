 
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports System.Data
Imports DevExpress.XtraGrid.Views.Grid
Imports System.ComponentModel





Friend Class CheckedLookUpEditPopUpControlBase
    Inherits XtraUserControl
    Private gcMain As DevExpress.XtraGrid.GridControl
    Private btnOk As SimpleButton
    Private btnCancel As SimpleButton
    Private checkColumn As DevExpress.XtraGrid.Columns.GridColumn
    Private repositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend gvMain As DevExpress.XtraGrid.Views.Grid.GridView


    Friend Property EditValue() As Object
        Get
            Return GetEditValue()
        End Get
        Set(value As Object)
            RefreshSelectedItems(value)
        End Set
    End Property

    Private ReadOnly Property SeparatorChar() As String
        Get
            If popupControl IsNot Nothing AndAlso popupControl.PopupContainerProperties IsNot Nothing Then
                Return "" & TryCast(popupControl.PopupContainerProperties, RepositoryItemCheckedLookUpEdit).SeparatorChar
            End If
            Return ""
        End Get
    End Property
    Private ReadOnly Property DisplaySeparatorChar() As String
        Get
            If popupControl IsNot Nothing AndAlso popupControl.PopupContainerProperties IsNot Nothing Then
                Return "" + TryCast(popupControl.PopupContainerProperties, RepositoryItemCheckedLookUpEdit).DisplaySeparatorChar
            End If
            Return ""
        End Get
    End Property
    Private ReadOnly Property ValueMember() As String
        Get
            If popupControl IsNot Nothing AndAlso popupControl.PopupContainerProperties IsNot Nothing Then
                Return TryCast(popupControl.PopupContainerProperties, RepositoryItemCheckedLookUpEdit).ValueMember
            End If
            Return ""
        End Get
    End Property
    Private ReadOnly Property DisplayMember() As String
        Get
            If popupControl IsNot Nothing AndAlso popupControl.PopupContainerProperties IsNot Nothing Then
                Return TryCast(popupControl.PopupContainerProperties, RepositoryItemCheckedLookUpEdit).DisplayMember
            End If

            Return ""
        End Get
    End Property

    Private selectedItems As New List(Of String)()
    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub InitializeComponent()
        Me.gcMain = New DevExpress.XtraGrid.GridControl()
        Me.gvMain = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.checkColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.btnOk = New uc_tb_SimpleButton()
        Me.btnCancel = New uc_tb_SimpleButton()
        DirectCast(Me.gcMain, System.ComponentModel.ISupportInitialize).BeginInit()
        DirectCast(Me.gvMain, System.ComponentModel.ISupportInitialize).BeginInit()
        DirectCast(Me.repositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        ' 
        ' gcMain
        ' 
        Me.gcMain.Anchor = DirectCast((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gcMain.Location = New System.Drawing.Point(0, 0)
        Me.gcMain.MainView = Me.gvMain
        Me.gcMain.Name = "gcMain"
        Me.gcMain.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repositoryItemCheckEdit1})
        Me.gcMain.Size = New System.Drawing.Size(471, 173)
        Me.gcMain.TabIndex = 0
        Me.gcMain.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvMain})
        ' 
        ' gvMain
        ' 
        Me.gvMain.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.checkColumn})
        Me.gvMain.GridControl = Me.gcMain
        Me.gvMain.Name = "gvMain"
        Me.gvMain.OptionsCustomization.AllowColumnMoving = False
        Me.gvMain.OptionsCustomization.AllowFilter = False
        Me.gvMain.OptionsCustomization.AllowGroup = False
        Me.gvMain.OptionsCustomization.AllowQuickHideColumns = False
        Me.gvMain.OptionsDetail.ShowDetailTabs = False
        Me.gvMain.OptionsView.ShowDetailButtons = False
        Me.gvMain.OptionsView.ShowGroupPanel = False
        '     Me.gvMain.CustomUnboundColumnData += New DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(Me.gvMain_CustomUnboundColumnData)
        '      Me.gvMain.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.gvMain_KeyDown)
        ' 
        ' checkColumn
        ' 
        Me.checkColumn.ColumnEdit = Me.repositoryItemCheckEdit1
        Me.checkColumn.FieldName = "SELECTED"
        Me.checkColumn.MaxWidth = 20
        Me.checkColumn.Name = "checkColumn"
        Me.checkColumn.OptionsColumn.ShowCaption = False
        Me.checkColumn.UnboundType = DevExpress.Data.UnboundColumnType.[Boolean]
        Me.checkColumn.Visible = True
        Me.checkColumn.VisibleIndex = 0
        Me.checkColumn.Width = 20
        ' 
        ' repositoryItemCheckEdit1
        ' 
        Me.repositoryItemCheckEdit1.AutoHeight = False
        Me.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1"
        ' 
        ' btnOk
        ' 
        Me.btnOk.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.Location = New System.Drawing.Point(291, 179)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 1
        Me.btnOk.Text = "OK"
        '   Me.btnOk.Click += New System.EventHandler(Me.btnOk_Click)
        ' 
        ' btnCancel
        ' 
        Me.btnCancel.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(385, 179)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        '    Me.btnCancel.Click += New System.EventHandler(Me.btnCancel_Click)
        ' 
        ' CheckedLookUpEditPopUpControlBase
        ' 
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.gcMain)
        Me.Name = "CheckedLookUpEditPopUpControlBase"
        Me.Size = New System.Drawing.Size(471, 206)
        DirectCast(Me.gcMain, System.ComponentModel.ISupportInitialize).EndInit()
        DirectCast(Me.gvMain, System.ComponentModel.ISupportInitialize).EndInit()
        DirectCast(Me.repositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private Sub RefreshSelectedItems(ByVal editValue As Object)
        selectedItems.Clear()
        Dim str As String() = editValue.AsString().Split(New String() {SeparatorChar}, StringSplitOptions.RemoveEmptyEntries)
        For Each s As String In str
            If s IsNot Nothing AndAlso s <> "" Then
                If Not selectedItems.Contains(s.Trim()) Then
                    selectedItems.Add(s.Trim())
                End If
            End If
        Next
        gcMain.RefreshDataSource()
    End Sub

    Friend popupControl As CheckedLookUpEditPopUpControl
    Friend Function GetDisplayText(ByVal editValue As Object) As String
        Dim result As String = ""
        If gvMain IsNot Nothing Then
            Dim list As New List(Of String)()

            Dim str As String() = editValue.AsString().Split(New String() {SeparatorChar}, StringSplitOptions.RemoveEmptyEntries)
            For Each s As String In str
                If s IsNot Nothing AndAlso s <> "" Then
                    If Not list.Contains(s.Trim()) Then
                        list.Add(s.Trim())
                    End If
                End If
            Next

            For i As Integer = 0 To gvMain.RowCount - 1
                Dim r As DataRow = gvMain.GetDataRow(i)
                If r IsNot Nothing Then
                    If Not r.Table.Columns.Contains(ValueMember) OrElse Not r.Table.Columns.Contains(DisplayMember) Then
                        Exit For
                    End If
                    If list.Contains(r(ValueMember).AsString()) Then
                        result = result & DisplaySeparatorChar
                        result += r(DisplayMember).AsString()
                    End If
                End If
            Next
        End If
        Return result
    End Function
    Friend Sub PrepareView()
        If Not gvMain.Columns.Contains(checkColumn) Then
            gvMain.Columns.Add(checkColumn)
        End If
        checkColumn.ColumnEdit = repositoryItemCheckEdit1
        checkColumn.Visible = True
        checkColumn.VisibleIndex = 0
        For Each col As GridColumn In gvMain.Columns
            If col IsNot checkColumn Then
                If col.VisibleIndex = 0 Then
                    col.VisibleIndex += 1
                End If
                col.OptionsColumn.AllowEdit = False
                col.OptionsColumn.[ReadOnly] = True
            Else
                col.OptionsColumn.AllowEdit = True
                col.OptionsColumn.[ReadOnly] = False
            End If
        Next
        gvMain.Invalidate()
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs)
        popupControl.OwnerEdit.ClosePopup()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        popupControl.OwnerEdit.CancelPopup()
    End Sub

    Private Sub gvMain_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.Column Is checkColumn Then
            Dim row As DataRow = gvMain.GetDataRow(e.RowHandle)
            If row IsNot Nothing AndAlso row.Table.Columns.Contains(ValueMember.ToString()) Then
                Dim str As String = row(ValueMember).AsString()

                If e.IsGetData Then
                    e.Value = selectedItems.Contains(str)
                End If
                If e.IsSetData Then

                    If e.Value.AsBool() Then
                        If Not selectedItems.Contains(str) Then
                            selectedItems.Add(str)
                        End If
                    Else
                        If selectedItems.Contains(str) Then
                            selectedItems.Remove(str)
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Friend Function GetEditValue() As String
        Return selectedItems.ToString(SeparatorChar)
    End Function

    Private Sub gvMain_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = System.Windows.Forms.Keys.Space Then
            Try
                Dim selected As Boolean = gvMain.GetRowCellValue(gvMain.FocusedRowHandle, checkColumn).AsBool()
                Dim row As DataRow = gvMain.GetFocusedDataRow()
                If row IsNot Nothing AndAlso row.Table.Columns.Contains(ValueMember.ToString()) Then
                    Dim str As String = row(ValueMember).AsString()
                    If Not selected Then
                        If Not selectedItems.Contains(str) Then
                            selectedItems.Add(str)
                        End If
                    Else
                        If selectedItems.Contains(str) Then
                            selectedItems.Remove(str)
                        End If
                    End If

                    gvMain.SetRowCellValue(gvMain.FocusedRowHandle, checkColumn, Not selected)
                End If
            Catch
            End Try
        End If
        If e.KeyCode = System.Windows.Forms.Keys.Enter Then
            btnOk.PerformClick()
        End If
        If e.KeyCode = System.Windows.Forms.Keys.Escape Then
            btnCancel.PerformClick()
        End If
    End Sub
End Class

<ToolboxItem(False)> _
Public Class CheckedLookUpEditPopUpControl
    Inherits PopupContainerControl
    Private baseControl As CheckedLookUpEditPopUpControlBase

    Public Sub New()
        MyBase.New()
        baseControl = New CheckedLookUpEditPopUpControlBase()
        baseControl.Dock = System.Windows.Forms.DockStyle.Fill
        baseControl.popupControl = Me
        Me.Controls.Add(baseControl)
    End Sub

    Friend Function GetDisplayText(editValue As Object) As String
        Return baseControl.GetDisplayText(editValue)
    End Function
    Friend Property EditValue() As Object
        Get
            Return baseControl.EditValue
        End Get
        Set(value As Object)
            baseControl.EditValue = value
        End Set
    End Property
    Public ReadOnly Property View() As GridView
        Get
            Return baseControl.gvMain
        End Get
    End Property
    Friend Sub PrepareView()
        baseControl.PrepareView()
    End Sub
End Class


