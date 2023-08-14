<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptListadoCliente
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptListadoCliente))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrLine3 = New DevExpress.XtraReports.UI.XRLine()
        Me.lblReferencia = New DevExpress.XtraReports.UI.XRLabel()
        Me.FormattingRule1 = New DevExpress.XtraReports.UI.FormattingRule()
        Me.Foto1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.lblTitulo = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine2 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.XrRichText2 = New DevExpress.XtraReports.UI.XRRichText()
        CType(Me.XrRichText2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrRichText2, Me.XrLine3, Me.lblReferencia, Me.Foto1})
        Me.Detail.HeightF = 82.29166!
        Me.Detail.KeepTogether = True
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLine3
        '
        Me.XrLine3.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash
        Me.XrLine3.LocationFloat = New DevExpress.Utils.PointFloat(1.041762!, 1.041667!)
        Me.XrLine3.Name = "XrLine3"
        Me.XrLine3.SizeF = New System.Drawing.SizeF(698.9583!, 10.41667!)
        Me.XrLine3.StylePriority.UseBorderDashStyle = False
        '
        'lblReferencia
        '
        Me.lblReferencia.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Datos.Referencia")})
        Me.lblReferencia.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Underline)
        Me.lblReferencia.ForeColor = System.Drawing.Color.Blue
        Me.lblReferencia.LocationFloat = New DevExpress.Utils.PointFloat(114.3338!, 11.45833!)
        Me.lblReferencia.Name = "lblReferencia"
        Me.lblReferencia.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblReferencia.SizeF = New System.Drawing.SizeF(76.04169!, 23.0!)
        Me.lblReferencia.StylePriority.UseFont = False
        Me.lblReferencia.StylePriority.UseForeColor = False
        Me.lblReferencia.StylePriority.UseTextAlignment = False
        Me.lblReferencia.Text = "[Referencia]"
        Me.lblReferencia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'FormattingRule1
        '
        Me.FormattingRule1.Condition = "[Chollo] = true"
        '
        '
        '
        Me.FormattingRule1.Formatting.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormattingRule1.Name = "FormattingRule1"
        '
        'Foto1
        '
        Me.Foto1.BackColor = System.Drawing.Color.Transparent
        Me.Foto1.BorderColor = System.Drawing.Color.Black
        Me.Foto1.LocationFloat = New DevExpress.Utils.PointFloat(10.00001!, 11.45833!)
        Me.Foto1.Name = "Foto1"
        Me.Foto1.SizeF = New System.Drawing.SizeF(88.0!, 63.0!)
        Me.Foto1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage
        Me.Foto1.StylePriority.UseBackColor = False
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 20.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.TopMargin.Visible = False
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 10.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'lblTitulo
        '
        Me.lblTitulo.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 10.00001!)
        Me.lblTitulo.Multiline = True
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTitulo.SizeF = New System.Drawing.SizeF(710.0!, 26.125!)
        Me.lblTitulo.StylePriority.UseFont = False
        Me.lblTitulo.StylePriority.UseTextAlignment = False
        Me.lblTitulo.Text = "lblTitulo"
        Me.lblTitulo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLine2
        '
        Me.XrLine2.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.DashDotDot
        Me.XrLine2.LocationFloat = New DevExpress.Utils.PointFloat(0.00009536743!, 7.916673!)
        Me.XrLine2.Name = "XrLine2"
        Me.XrLine2.SizeF = New System.Drawing.SizeF(699.9999!, 13.54167!)
        Me.XrLine2.StylePriority.UseBorderDashStyle = False
        '
        'XrLabel3
        '
        Me.XrLabel3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Datos.Poblacion")})
        Me.XrLabel3.Font = New System.Drawing.Font("Times New Roman", 16.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(10.00001!, 21.45834!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(690.0!, 32.70833!)
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.Text = "XrLabel3"
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblTitulo})
        Me.PageHeader.HeightF = 45.83333!
        Me.PageHeader.Name = "PageHeader"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel3, Me.XrLine2})
        Me.GroupHeader1.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("Poblacion", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
        Me.GroupHeader1.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WithFirstDetail
        Me.GroupHeader1.HeightF = 54.16667!
        Me.GroupHeader1.KeepTogether = True
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'XrRichText2
        '
        Me.XrRichText2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Html", Nothing, "Datos.Texto")})
        Me.XrRichText2.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.XrRichText2.LocationFloat = New DevExpress.Utils.PointFloat(114.3338!, 34.45832!)
        Me.XrRichText2.Name = "XrRichText2"
        Me.XrRichText2.SerializableRtfString = "ewBcAHIAdABmADEAXABhAG4AcwBpAFwAYQBuAHMAaQBjAHAAZwAxADIANQAyAFwAZABlAGYAZgAwAHsAX" & _
    "ABmAG8AbgB0AHQAYgBsAHsAXABmADAAXABmAG4AaQBsACAAVABpAG0AZQBzACAATgBlAHcAIABSAG8Ab" & _
    "QBhAG4AOwB9AH0A"
        Me.XrRichText2.SizeF = New System.Drawing.SizeF(585.6663!, 37.83334!)
        '
        'rptListadoCliente
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.GroupHeader1})
        Me.DataMember = "Datos"
        Me.DataSourceSchema = resources.GetString("$this.DataSourceSchema")
        Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.FormattingRule1})
        Me.Margins = New System.Drawing.Printing.Margins(61, 56, 20, 10)
        Me.PageHeight = 1169
        Me.PageWidth = 827
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "12.2"
        CType(Me.XrRichText2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents lblTitulo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblReferencia As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine3 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLine2 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents FormattingRule1 As DevExpress.XtraReports.UI.FormattingRule
    Friend WithEvents GroupHeader1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents Foto1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XrRichText2 As DevExpress.XtraReports.UI.XRRichText
End Class
