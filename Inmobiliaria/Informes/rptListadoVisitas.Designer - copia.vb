<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptListadoVisitas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptListadoVisitas))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrRichText1 = New DevExpress.XtraReports.UI.XRRichText()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.Texto2 = New DevExpress.XtraReports.UI.XRRichText()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.Titulo1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Texto48pt = New DevExpress.XtraReports.UI.FormattingRule()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.Texto1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.Númerodepágina1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.TopMarginBand1 = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMarginBand1 = New DevExpress.XtraReports.UI.BottomMarginBand()
        CType(Me.XrRichText1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Texto2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrRichText1, Me.XrLine1, Me.Texto2})
        Me.Detail.HeightF = 102.7917!
        Me.Detail.KeepTogether = True
        Me.Detail.Name = "Detail"
        '
        'XrRichText1
        '
        Me.XrRichText1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Html", Nothing, "Visitas.texto3")})
        Me.XrRichText1.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.XrRichText1.LocationFloat = New DevExpress.Utils.PointFloat(38.54167!, 53.12503!)
        Me.XrRichText1.Name = "XrRichText1"
        Me.XrRichText1.SerializableRtfString = resources.GetString("XrRichText1.SerializableRtfString")
        Me.XrRichText1.SizeF = New System.Drawing.SizeF(740.458!, 33.0!)
        Me.XrRichText1.StylePriority.UseFont = False
        '
        'XrLine1
        '
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(38.54167!, 86.12505!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(740.458!, 12.5!)
        '
        'Texto2
        '
        Me.Texto2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Html", Nothing, "Visitas.texto2")})
        Me.Texto2.Font = New System.Drawing.Font("Arial", 20.0!)
        Me.Texto2.LocationFloat = New DevExpress.Utils.PointFloat(38.54167!, 0.0!)
        Me.Texto2.Name = "Texto2"
        Me.Texto2.SerializableRtfString = resources.GetString("Texto2.SerializableRtfString")
        Me.Texto2.SizeF = New System.Drawing.SizeF(740.4581!, 33.0!)
        Me.Texto2.StylePriority.UseFont = False
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Titulo1})
        Me.ReportHeader.HeightF = 76.79167!
        Me.ReportHeader.Name = "ReportHeader"
        Me.ReportHeader.Visible = False
        '
        'Titulo1
        '
        Me.Titulo1.BackColor = System.Drawing.Color.Transparent
        Me.Titulo1.BorderColor = System.Drawing.Color.Black
        Me.Titulo1.CanGrow = False
        Me.Titulo1.Font = New System.Drawing.Font("Arial", 30.0!, System.Drawing.FontStyle.Bold)
        Me.Titulo1.ForeColor = System.Drawing.Color.Red
        Me.Titulo1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.Titulo1.Name = "Titulo1"
        Me.Titulo1.SizeF = New System.Drawing.SizeF(818.0001!, 75.0!)
        Me.Titulo1.StylePriority.UseBackColor = False
        Me.Titulo1.StylePriority.UseFont = False
        Me.Titulo1.StylePriority.UseTextAlignment = False
        Me.Titulo1.Text = "[Visitas.titulo]"
        Me.Titulo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'Texto48pt
        '
        Me.Texto48pt.Condition = "Len([CalculatedField1])  < 18"
        '
        '
        '
        Me.Texto48pt.Formatting.Font = New System.Drawing.Font("Arial", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Texto48pt.Name = "Texto48pt"
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Texto1})
        Me.PageHeader.HeightF = 62.12502!
        Me.PageHeader.Name = "PageHeader"
        '
        'Texto1
        '
        Me.Texto1.BackColor = System.Drawing.Color.Transparent
        Me.Texto1.BorderColor = System.Drawing.Color.Black
        Me.Texto1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Visitas.texto1")})
        Me.Texto1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Texto1.ForeColor = System.Drawing.Color.Black
        Me.Texto1.LocationFloat = New DevExpress.Utils.PointFloat(38.54167!, 0.0!)
        Me.Texto1.Multiline = True
        Me.Texto1.Name = "Texto1"
        Me.Texto1.SizeF = New System.Drawing.SizeF(740.4582!, 25.0!)
        Me.Texto1.StylePriority.UseBackColor = False
        Me.Texto1.Text = "Texto1"
        Me.Texto1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'ReportFooter
        '
        Me.ReportFooter.HeightF = 22.0!
        Me.ReportFooter.Name = "ReportFooter"
        Me.ReportFooter.Visible = False
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Númerodepágina1})
        Me.PageFooter.HeightF = 48.0!
        Me.PageFooter.Name = "PageFooter"
        Me.PageFooter.Visible = False
        '
        'Númerodepágina1
        '
        Me.Númerodepágina1.BackColor = System.Drawing.Color.White
        Me.Númerodepágina1.BorderColor = System.Drawing.Color.Black
        Me.Númerodepágina1.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.Númerodepágina1.ForeColor = System.Drawing.Color.Black
        Me.Númerodepágina1.LocationFloat = New DevExpress.Utils.PointFloat(708.0!, 32.0!)
        Me.Númerodepágina1.Name = "Númerodepágina1"
        Me.Númerodepágina1.PageInfo = DevExpress.XtraPrinting.PageInfo.Number
        Me.Númerodepágina1.SizeF = New System.Drawing.SizeF(57.0!, 15.0!)
        Me.Númerodepágina1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'TopMarginBand1
        '
        Me.TopMarginBand1.HeightF = 58.70834!
        Me.TopMarginBand1.Name = "TopMarginBand1"
        '
        'BottomMarginBand1
        '
        Me.BottomMarginBand1.HeightF = 16.0!
        Me.BottomMarginBand1.Name = "BottomMarginBand1"
        '
        'rptListadoVisitas
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.ReportHeader, Me.PageHeader, Me.ReportFooter, Me.PageFooter, Me.TopMarginBand1, Me.BottomMarginBand1})
        Me.DataSourceSchema = resources.GetString("$this.DataSourceSchema")
        Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.Texto48pt})
        Me.Margins = New System.Drawing.Printing.Margins(16, 16, 59, 16)
        Me.Version = "12.2"
        CType(Me.XrRichText1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Texto2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents Titulo1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents Texto1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents Númerodepágina1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents TopMarginBand1 As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMarginBand1 As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents Texto48pt As DevExpress.XtraReports.UI.FormattingRule
    Friend WithEvents Texto2 As DevExpress.XtraReports.UI.XRRichText
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrRichText1 As DevExpress.XtraReports.UI.XRRichText
End Class
