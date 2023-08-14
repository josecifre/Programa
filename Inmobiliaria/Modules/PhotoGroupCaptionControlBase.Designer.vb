Imports Microsoft.VisualBasic
Imports System

Partial Public Class PhotoGroupCaptionControlBase
    ''' <summary> 
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary> 
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Component Designer generated code"

    ''' <summary> 
    ''' Required method for Designer support - do not modify 
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.nameLabel = New DevExpress.XtraEditors.LabelControl()
        Me.groupIcon = New DevExpress.XtraEditors.LabelControl()
        Me.dataLabel = New DevExpress.XtraEditors.LabelControl()
        Me.editLabel = New DevExpress.XtraEditors.LabelControl()
        Me.removeLabel = New DevExpress.XtraEditors.LabelControl()
        Me.collageLabel = New DevExpress.XtraEditors.LabelControl()
        Me.slideshowLabel = New DevExpress.XtraEditors.LabelControl()
        Me.filmLabel = New DevExpress.XtraEditors.LabelControl()
        Me.separatorLabel = New DevExpress.XtraEditors.LabelControl()
        Me.SuspendLayout()
        ' 
        ' nameLabel
        ' 
        Me.nameLabel.Appearance.Font = New System.Drawing.Font("Tahoma", 13.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(204)))
        Me.nameLabel.Location = New System.Drawing.Point(51, 9)
        Me.nameLabel.Name = "nameLabel"
        Me.nameLabel.Size = New System.Drawing.Size(90, 21)
        Me.nameLabel.TabIndex = 0
        Me.nameLabel.Text = "AlbumName"
        ' 
        ' groupIcon
        ' 
        Me.groupIcon.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(204)))
        Me.groupIcon.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.groupIcon.Location = New System.Drawing.Point(9, 11)
        Me.groupIcon.Name = "groupIcon"
        Me.groupIcon.Size = New System.Drawing.Size(32, 32)
        Me.groupIcon.TabIndex = 1
        ' 
        ' dataLabel
        ' 
        Me.dataLabel.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(204)))
        Me.dataLabel.Location = New System.Drawing.Point(51, 30)
        Me.dataLabel.Name = "dataLabel"
        Me.dataLabel.Size = New System.Drawing.Size(56, 13)
        Me.dataLabel.TabIndex = 2
        Me.dataLabel.Text = "22.06.2010"
        ' 
        ' editLabel
        ' 
        Me.editLabel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.editLabel.Appearance.Image = My.Resources.Edit_16x16
        Me.editLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.editLabel.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        Me.editLabel.Location = New System.Drawing.Point(159, 18)
        Me.editLabel.Name = "editLabel"
        Me.editLabel.Size = New System.Drawing.Size(21, 20)
        Me.editLabel.TabIndex = 9
        '			Me.editLabel.Click += New System.EventHandler(Me.OnEditButtonClick);
        ' 
        ' removeLabel
        ' 
        Me.removeLabel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.removeLabel.Appearance.Image = My.Resources.RemoveAlbum_16x16
        Me.removeLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.removeLabel.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        Me.removeLabel.Location = New System.Drawing.Point(186, 18)
        Me.removeLabel.Name = "removeLabel"
        Me.removeLabel.Size = New System.Drawing.Size(21, 20)
        Me.removeLabel.TabIndex = 10
        '			Me.removeLabel.Click += New System.EventHandler(Me.OnRemoveButtonClick);
        ' 
        ' collageLabel
        ' 
        Me.collageLabel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.collageLabel.Appearance.Image = My.Resources.Collage_16x16
        Me.collageLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.collageLabel.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        Me.collageLabel.Location = New System.Drawing.Point(223, 18)
        Me.collageLabel.Name = "collageLabel"
        Me.collageLabel.Size = New System.Drawing.Size(21, 20)
        Me.collageLabel.TabIndex = 11
        '			Me.collageLabel.Click += New System.EventHandler(Me.OnCollageButtonClick);
        ' 
        ' slideshowLabel
        ' 
        Me.slideshowLabel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.slideshowLabel.Appearance.Image = My.Resources.Slideshow_16x16
        Me.slideshowLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.slideshowLabel.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        Me.slideshowLabel.Location = New System.Drawing.Point(250, 18)
        Me.slideshowLabel.Name = "slideshowLabel"
        Me.slideshowLabel.Size = New System.Drawing.Size(21, 20)
        Me.slideshowLabel.TabIndex = 12
        '			Me.slideshowLabel.Click += New System.EventHandler(Me.OnSlideShowButtonClick);
        ' 
        ' filmLabel
        ' 
        Me.filmLabel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.filmLabel.Appearance.Image = My.Resources.Film_16x16
        Me.filmLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.filmLabel.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        Me.filmLabel.Location = New System.Drawing.Point(277, 18)
        Me.filmLabel.Name = "filmLabel"
        Me.filmLabel.Size = New System.Drawing.Size(21, 20)
        Me.filmLabel.TabIndex = 13
        '			Me.filmLabel.Click += New System.EventHandler(Me.OnFilmButtonClick);
        ' 
        ' separatorLabel
        ' 
        Me.separatorLabel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.separatorLabel.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        Me.separatorLabel.LineLocation = DevExpress.XtraEditors.LineLocation.Left
        Me.separatorLabel.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Vertical
        Me.separatorLabel.LineVisible = True
        Me.separatorLabel.Location = New System.Drawing.Point(213, 22)
        Me.separatorLabel.Name = "separatorLabel"
        Me.separatorLabel.Size = New System.Drawing.Size(4, 13)
        Me.separatorLabel.TabIndex = 14
        ' 
        ' PhotoGroupCaptionControlBase
        ' 
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.ForeColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.separatorLabel)
        Me.Controls.Add(Me.filmLabel)
        Me.Controls.Add(Me.slideshowLabel)
        Me.Controls.Add(Me.collageLabel)
        Me.Controls.Add(Me.removeLabel)
        Me.Controls.Add(Me.editLabel)
        Me.Controls.Add(Me.dataLabel)
        Me.Controls.Add(Me.groupIcon)
        Me.Controls.Add(Me.nameLabel)
        Me.Name = "PhotoGroupCaptionControlBase"
        Me.Size = New System.Drawing.Size(307, 56)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Protected nameLabel As DevExpress.XtraEditors.LabelControl
    Protected dataLabel As DevExpress.XtraEditors.LabelControl
    Protected WithEvents groupIcon As DevExpress.XtraEditors.LabelControl
    Protected WithEvents editLabel As DevExpress.XtraEditors.LabelControl
    Protected WithEvents removeLabel As DevExpress.XtraEditors.LabelControl
    Protected WithEvents collageLabel As DevExpress.XtraEditors.LabelControl
    Protected WithEvents slideshowLabel As DevExpress.XtraEditors.LabelControl
    Protected WithEvents filmLabel As DevExpress.XtraEditors.LabelControl
    Protected separatorLabel As DevExpress.XtraEditors.LabelControl
End Class

