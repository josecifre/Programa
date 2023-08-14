Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.Skins
Imports DevExpress.Utils.Drawing


Partial Public Class PhotoGroupCaptionControlBase
    Inherits UserControl
    Public Sub New()
        SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint, True)
        InitializeComponent()
    End Sub

 

    Protected Overridable Sub OnEditButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles editLabel.Click
    End Sub
    Protected Overridable Sub OnRemoveButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles removeLabel.Click
    End Sub
    Protected Overridable Sub OnCollageButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles collageLabel.Click
        XtraMessageBox.Show(Me, "Here you can show your own collage settings dialog.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Protected Overridable Sub OnSlideShowButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles slideshowLabel.Click
        XtraMessageBox.Show(Me, "Here you can show your own slideshow settings dialog.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Protected Overridable Sub OnFilmButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles filmLabel.Click
        XtraMessageBox.Show(Me, "Here you can show your own film settings dialog.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private oldParent As GalleryControlClient = Nothing
    Protected Overrides Sub OnParentChanged(ByVal e As EventArgs)
        MyBase.OnParentChanged(e)
        If oldParent IsNot Nothing Then
            RemoveHandler oldParent.GalleryControl.LookAndFeel.StyleChanged, AddressOf LookAndFeel_StyleChanged
        End If
        oldParent = Nothing
        Dim cl As GalleryControlClient = TryCast(Parent, GalleryControlClient)
        If cl Is Nothing Then
            Return
        End If
        oldParent = cl
        AddHandler cl.GalleryControl.LookAndFeel.StyleChanged, AddressOf LookAndFeel_StyleChanged
    End Sub

    Private Sub LookAndFeel_StyleChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim cl As GalleryControlClient = TryCast(Parent, GalleryControlClient)
        If cl Is Nothing Then
            Return
        End If
        Me.nameLabel.Appearance.ForeColor = RibbonSkins.GetSkin(cl.GalleryControl.LookAndFeel.ActiveLookAndFeel)(RibbonSkins.SkinPopupGalleryGroupCaption).Color.ForeColor
        Me.dataLabel.Appearance.ForeColor = Me.nameLabel.Appearance.ForeColor
    End Sub
End Class

