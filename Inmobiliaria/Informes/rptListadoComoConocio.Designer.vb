<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptListadoComoConocio
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
        Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim XrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptListadoComoConocio))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.FormattingRule1 = New DevExpress.XtraReports.UI.FormattingRule()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.Titulo = New DevExpress.XtraReports.UI.XRLabel()
        Me.Texto48pt = New DevExpress.XtraReports.UI.FormattingRule()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.lblTotalClientes = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.Númerodepágina1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.TopMarginBand1 = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMarginBand1 = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
        Me.ccTelefonos = New DevExpress.XtraReports.UI.CalculatedField()
        Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.lblSubTotalClientes = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel6, Me.XrLabel5})
        Me.Detail.HeightF = 23.62504!
        Me.Detail.KeepTogether = True
        Me.Detail.Name = "Detail"
        '
        'XrLabel6
        '
        Me.XrLabel6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ccTelefonos")})
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(556.0835!, 0.6250064!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(251.9165!, 23.0!)
        Me.XrLabel6.Text = "XrLabel6"
        '
        'XrLabel5
        '
        Me.XrLabel5.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Datos.Nombre")})
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(38.54187!, 0.0!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(517.5416!, 23.0!)
        Me.XrLabel5.Text = "XrLabel5"
        '
        'FormattingRule1
        '
        Me.FormattingRule1.Condition = "[Baja] = true"
        '
        '
        '
        Me.FormattingRule1.Formatting.ForeColor = System.Drawing.Color.Red
        Me.FormattingRule1.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[True]
        Me.FormattingRule1.Name = "FormattingRule1"
        '
        'XrLine1
        '
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(38.54187!, 33.00002!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(769.4581!, 12.5!)
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Titulo})
        Me.ReportHeader.HeightF = 50.75!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'Titulo
        '
        Me.Titulo.BackColor = System.Drawing.Color.Transparent
        Me.Titulo.BorderColor = System.Drawing.Color.Black
        Me.Titulo.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Titulo.ForeColor = System.Drawing.Color.Black
        Me.Titulo.LocationFloat = New DevExpress.Utils.PointFloat(36.45837!, 25.75!)
        Me.Titulo.Multiline = True
        Me.Titulo.Name = "Titulo"
        Me.Titulo.SizeF = New System.Drawing.SizeF(740.4582!, 25.0!)
        Me.Titulo.StylePriority.UseBackColor = False
        Me.Titulo.Text = "Titulo"
        Me.Titulo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
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
        Me.PageHeader.HeightF = 0.0!
        Me.PageHeader.Name = "PageHeader"
        '
        'XrLabel13
        '
        Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(556.0835!, 10.00001!)
        Me.XrLabel13.Name = "XrLabel13"
        Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel13.SizeF = New System.Drawing.SizeF(251.9165!, 23.0!)
        Me.XrLabel13.Text = "Teléfonos"
        '
        'XrLabel12
        '
        Me.XrLabel12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Datos.ComoConociste")})
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(38.54186!, 10.00004!)
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(266.3331!, 23.0!)
        Me.XrLabel12.Text = "XrLabel12"
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblTotalClientes})
        Me.ReportFooter.HeightF = 29.29168!
        Me.ReportFooter.KeepTogether = True
        Me.ReportFooter.Name = "ReportFooter"
        '
        'lblTotalClientes
        '
        Me.lblTotalClientes.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblTotalClientes.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Datos.Nombre")})
        Me.lblTotalClientes.LocationFloat = New DevExpress.Utils.PointFloat(556.0835!, 6.291676!)
        Me.lblTotalClientes.Name = "lblTotalClientes"
        Me.lblTotalClientes.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTotalClientes.SizeF = New System.Drawing.SizeF(251.9165!, 23.0!)
        Me.lblTotalClientes.StylePriority.UseBorders = False
        Me.lblTotalClientes.StylePriority.UseTextAlignment = False
        XrSummary1.FormatString = "{0:Total Clientes: ####}"
        XrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.Count
        XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.lblTotalClientes.Summary = XrSummary1
        Me.lblTotalClientes.Text = "lblTotalClientes"
        Me.lblTotalClientes.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Númerodepágina1})
        Me.PageFooter.HeightF = 47.0!
        Me.PageFooter.Name = "PageFooter"
        Me.PageFooter.Visible = False
        '
        'Númerodepágina1
        '
        Me.Númerodepágina1.BackColor = System.Drawing.Color.White
        Me.Númerodepágina1.BorderColor = System.Drawing.Color.Black
        Me.Númerodepágina1.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.Númerodepágina1.ForeColor = System.Drawing.Color.Black
        Me.Númerodepágina1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 21.99999!)
        Me.Númerodepágina1.Name = "Númerodepágina1"
        Me.Númerodepágina1.PageInfo = DevExpress.XtraPrinting.PageInfo.Number
        Me.Númerodepágina1.SizeF = New System.Drawing.SizeF(817.9999!, 15.0!)
        Me.Númerodepágina1.StylePriority.UseTextAlignment = False
        Me.Númerodepágina1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'TopMarginBand1
        '
        Me.TopMarginBand1.HeightF = 8.708334!
        Me.TopMarginBand1.Name = "TopMarginBand1"
        '
        'BottomMarginBand1
        '
        Me.BottomMarginBand1.HeightF = 16.0!
        Me.BottomMarginBand1.Name = "BottomMarginBand1"
        '
        'XrLabel14
        '
        Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(10.00001!, 10.00001!)
        Me.XrLabel14.Name = "XrLabel14"
        Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.XrLabel14.SizeF = New System.Drawing.SizeF(48.33352!, 23.0!)
        Me.XrLabel14.StylePriority.UseTextAlignment = False
        Me.XrLabel14.Text = "XrLabel14"
        Me.XrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'ccTelefonos
        '
        Me.ccTelefonos.Expression = "Telefono1 + Iif( [Telefono2] != '', ',' + Telefono2 , '' ) + Iif( [TelefonoMovil]" & _
    " != '', ',' + TelefonoMovil , '' )"
        Me.ccTelefonos.Name = "ccTelefonos"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel12, Me.XrLabel13, Me.XrLine1})
        Me.GroupHeader1.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ComoConociste", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
        Me.GroupHeader1.HeightF = 45.50002!
        Me.GroupHeader1.KeepTogether = True
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblSubTotalClientes})
        Me.GroupFooter1.HeightF = 28.12501!
        Me.GroupFooter1.KeepTogether = True
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'lblSubTotalClientes
        '
        Me.lblSubTotalClientes.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Datos.Nombre")})
        Me.lblSubTotalClientes.LocationFloat = New DevExpress.Utils.PointFloat(556.0835!, 5.125014!)
        Me.lblSubTotalClientes.Name = "lblSubTotalClientes"
        Me.lblSubTotalClientes.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblSubTotalClientes.SizeF = New System.Drawing.SizeF(251.9165!, 23.0!)
        Me.lblSubTotalClientes.StylePriority.UseTextAlignment = False
        XrSummary2.FormatString = "{0:Total Clientes: ####}"
        XrSummary2.Func = DevExpress.XtraReports.UI.SummaryFunc.Count
        XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.lblSubTotalClientes.Summary = XrSummary2
        Me.lblSubTotalClientes.Text = "lblSubTotalClientes"
        Me.lblSubTotalClientes.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'rptListadoComoConocio
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.ReportHeader, Me.PageHeader, Me.ReportFooter, Me.PageFooter, Me.TopMarginBand1, Me.BottomMarginBand1, Me.GroupHeader1, Me.GroupFooter1})
        Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.ccTelefonos})
        Me.DataMember = "Datos"
        Me.DataSourceSchema = resources.GetString("$this.DataSourceSchema")
        Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.Texto48pt, Me.FormattingRule1})
        Me.Margins = New System.Drawing.Printing.Margins(16, 16, 9, 16)
        Me.ShowPrintMarginsWarning = False
        Me.Version = "13.1"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents Númerodepágina1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents TopMarginBand1 As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMarginBand1 As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents Texto48pt As DevExpress.XtraReports.UI.FormattingRule
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents Titulo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents FormattingRule1 As DevExpress.XtraReports.UI.FormattingRule
    Friend WithEvents ccTelefonos As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents lblTotalClientes As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents GroupHeader1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
    Friend WithEvents lblSubTotalClientes As DevExpress.XtraReports.UI.XRLabel
End Class
