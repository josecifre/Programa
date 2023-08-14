<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptEscaparate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptEscaparate))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.imgQR = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.imgSecundaria = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.imgPrincipal = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.Texto = New DevExpress.XtraReports.UI.XRLabel()
        Me.Referencia = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtPrecio = New DevExpress.XtraReports.UI.XRLabel()
        Me.imgTitulo = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.txtTituloEmail = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtTituloNombre = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtTituloTel = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtTituloWeb = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.TopMarginBand1 = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMarginBand1 = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.FormattingRule1 = New DevExpress.XtraReports.UI.FormattingRule()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.HeightF = 0.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Visible = False
        '
        'ReportHeader
        '
        Me.ReportHeader.HeightF = 0.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'PageHeader
        '
        Me.PageHeader.HeightF = 0.0!
        Me.PageHeader.Name = "PageHeader"
        Me.PageHeader.Visible = False
        '
        'ReportFooter
        '
        Me.ReportFooter.BackColor = System.Drawing.Color.Transparent
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.imgQR, Me.imgSecundaria, Me.imgPrincipal, Me.Texto, Me.Referencia, Me.txtPrecio, Me.imgTitulo, Me.txtTituloEmail, Me.txtTituloNombre, Me.txtTituloTel, Me.txtTituloWeb})
        Me.ReportFooter.HeightF = 1500.5!
        Me.ReportFooter.Name = "ReportFooter"
        Me.ReportFooter.StylePriority.UseBackColor = False
        '
        'imgQR
        '
        Me.imgQR.LocationFloat = New DevExpress.Utils.PointFloat(27.79168!, 933.9167!)
        Me.imgQR.Name = "imgQR"
        Me.imgQR.SizeF = New System.Drawing.SizeF(150.0!, 150.0!)
        Me.imgQR.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage
        '
        'imgSecundaria
        '
        Me.imgSecundaria.LocationFloat = New DevExpress.Utils.PointFloat(386.2082!, 396.6667!)
        Me.imgSecundaria.Name = "imgSecundaria"
        Me.imgSecundaria.SizeF = New System.Drawing.SizeF(360.0!, 270.0!)
        Me.imgSecundaria.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage
        '
        'imgPrincipal
        '
        Me.imgPrincipal.LocationFloat = New DevExpress.Utils.PointFloat(27.79168!, 145.8333!)
        Me.imgPrincipal.Name = "imgPrincipal"
        Me.imgPrincipal.SizeF = New System.Drawing.SizeF(718.4165!, 520.8333!)
        Me.imgPrincipal.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage
        '
        'Texto
        '
        Me.Texto.BackColor = System.Drawing.Color.Transparent
        Me.Texto.BorderColor = System.Drawing.Color.Black
        Me.Texto.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Escaparate.Texto")})
        Me.Texto.Font = New System.Drawing.Font("Comic Sans MS", 16.0!)
        Me.Texto.ForeColor = System.Drawing.Color.Black
        Me.Texto.LocationFloat = New DevExpress.Utils.PointFloat(27.79168!, 720.0416!)
        Me.Texto.Name = "Texto"
        Me.Texto.SizeF = New System.Drawing.SizeF(718.4165!, 200.0!)
        Me.Texto.StylePriority.UseBackColor = False
        Me.Texto.StylePriority.UseFont = False
        Me.Texto.Text = "Texto"
        Me.Texto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopJustify
        '
        'Referencia
        '
        Me.Referencia.BackColor = System.Drawing.Color.Transparent
        Me.Referencia.BorderColor = System.Drawing.Color.Black
        Me.Referencia.CanGrow = False
        Me.Referencia.Font = New System.Drawing.Font("Comic Sans MS", 22.0!)
        Me.Referencia.ForeColor = System.Drawing.Color.Black
        Me.Referencia.LocationFloat = New DevExpress.Utils.PointFloat(27.79168!, 666.6667!)
        Me.Referencia.Name = "Referencia"
        Me.Referencia.SizeF = New System.Drawing.SizeF(254.1667!, 41.0!)
        Me.Referencia.StylePriority.UseBackColor = False
        Me.Referencia.StylePriority.UseFont = False
        Me.Referencia.Text = "Ref "
        Me.Referencia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'txtPrecio
        '
        Me.txtPrecio.BackColor = System.Drawing.Color.Transparent
        Me.txtPrecio.BorderColor = System.Drawing.Color.Black
        Me.txtPrecio.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Escaparate.Precio", "{0:n2}")})
        Me.txtPrecio.Font = New System.Drawing.Font("Comic Sans MS", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtPrecio.ForeColor = System.Drawing.Color.Black
        Me.txtPrecio.LocationFloat = New DevExpress.Utils.PointFloat(199.6666!, 933.9167!)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.SizeF = New System.Drawing.SizeF(546.5416!, 44.79169!)
        Me.txtPrecio.StylePriority.UseBackColor = False
        Me.txtPrecio.StylePriority.UseFont = False
        Me.txtPrecio.StylePriority.UseTextAlignment = False
        Me.txtPrecio.Text = "txtPrecio"
        Me.txtPrecio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.txtPrecio.Visible = False
        '
        'imgTitulo
        '
        Me.imgTitulo.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.imgTitulo.Name = "imgTitulo"
        Me.imgTitulo.SizeF = New System.Drawing.SizeF(287.7917!, 174.7083!)
        Me.imgTitulo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage
        '
        'txtTituloEmail
        '
        Me.txtTituloEmail.BackColor = System.Drawing.Color.Transparent
        Me.txtTituloEmail.BorderColor = System.Drawing.Color.Black
        Me.txtTituloEmail.CanGrow = False
        Me.txtTituloEmail.Font = New System.Drawing.Font("Comic Sans MS", 16.0!)
        Me.txtTituloEmail.ForeColor = System.Drawing.Color.Black
        Me.txtTituloEmail.LocationFloat = New DevExpress.Utils.PointFloat(287.7917!, 90.91669!)
        Me.txtTituloEmail.Name = "txtTituloEmail"
        Me.txtTituloEmail.SizeF = New System.Drawing.SizeF(458.4164!, 27.45833!)
        Me.txtTituloEmail.StylePriority.UseBackColor = False
        Me.txtTituloEmail.StylePriority.UseFont = False
        Me.txtTituloEmail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'txtTituloNombre
        '
        Me.txtTituloNombre.BackColor = System.Drawing.Color.Transparent
        Me.txtTituloNombre.BorderColor = System.Drawing.Color.Black
        Me.txtTituloNombre.CanGrow = False
        Me.txtTituloNombre.Font = New System.Drawing.Font("Comic Sans MS", 20.0!)
        Me.txtTituloNombre.ForeColor = System.Drawing.Color.Black
        Me.txtTituloNombre.LocationFloat = New DevExpress.Utils.PointFloat(287.7917!, 21.41666!)
        Me.txtTituloNombre.Name = "txtTituloNombre"
        Me.txtTituloNombre.SizeF = New System.Drawing.SizeF(458.4164!, 40.99998!)
        Me.txtTituloNombre.StylePriority.UseBackColor = False
        Me.txtTituloNombre.StylePriority.UseFont = False
        Me.txtTituloNombre.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'txtTituloTel
        '
        Me.txtTituloTel.BackColor = System.Drawing.Color.Transparent
        Me.txtTituloTel.BorderColor = System.Drawing.Color.Black
        Me.txtTituloTel.CanGrow = False
        Me.txtTituloTel.Font = New System.Drawing.Font("Comic Sans MS", 16.0!)
        Me.txtTituloTel.ForeColor = System.Drawing.Color.Black
        Me.txtTituloTel.LocationFloat = New DevExpress.Utils.PointFloat(287.7918!, 62.41671!)
        Me.txtTituloTel.Name = "txtTituloTel"
        Me.txtTituloTel.SizeF = New System.Drawing.SizeF(458.4164!, 28.49999!)
        Me.txtTituloTel.StylePriority.UseBackColor = False
        Me.txtTituloTel.StylePriority.UseFont = False
        Me.txtTituloTel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'txtTituloWeb
        '
        Me.txtTituloWeb.BackColor = System.Drawing.Color.Transparent
        Me.txtTituloWeb.BorderColor = System.Drawing.Color.Black
        Me.txtTituloWeb.CanGrow = False
        Me.txtTituloWeb.Font = New System.Drawing.Font("Comic Sans MS", 16.0!)
        Me.txtTituloWeb.ForeColor = System.Drawing.Color.Black
        Me.txtTituloWeb.LocationFloat = New DevExpress.Utils.PointFloat(287.7917!, 118.375!)
        Me.txtTituloWeb.Name = "txtTituloWeb"
        Me.txtTituloWeb.SizeF = New System.Drawing.SizeF(458.4164!, 27.45833!)
        Me.txtTituloWeb.StylePriority.UseBackColor = False
        Me.txtTituloWeb.StylePriority.UseFont = False
        Me.txtTituloWeb.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'PageFooter
        '
        Me.PageFooter.HeightF = 0.0!
        Me.PageFooter.Name = "PageFooter"
        Me.PageFooter.Visible = False
        '
        'TopMarginBand1
        '
        Me.TopMarginBand1.HeightF = 24.29163!
        Me.TopMarginBand1.Name = "TopMarginBand1"
        '
        'BottomMarginBand1
        '
        Me.BottomMarginBand1.HeightF = 27.0!
        Me.BottomMarginBand1.Name = "BottomMarginBand1"
        '
        'FormattingRule1
        '
        Me.FormattingRule1.Name = "FormattingRule1"
        '
        'rptEscaparate
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.ReportHeader, Me.PageHeader, Me.ReportFooter, Me.PageFooter, Me.TopMarginBand1, Me.BottomMarginBand1})
        Me.DataMember = "Escaparate"
        Me.DataSourceSchema = resources.GetString("$this.DataSourceSchema")
        Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.FormattingRule1})
        Me.Margins = New System.Drawing.Printing.Margins(25, 24, 24, 27)
        Me.PageHeight = 1167
        Me.PageWidth = 824
        Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.ShowPrintMarginsWarning = False
        Me.Version = "12.2"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents Texto As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents Referencia As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtPrecio As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents imgSecundaria As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents imgPrincipal As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents TopMarginBand1 As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMarginBand1 As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents imgQR As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents FormattingRule1 As DevExpress.XtraReports.UI.FormattingRule
    Friend WithEvents imgTitulo As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents txtTituloEmail As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtTituloTel As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtTituloNombre As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtTituloWeb As DevExpress.XtraReports.UI.XRLabel
End Class
