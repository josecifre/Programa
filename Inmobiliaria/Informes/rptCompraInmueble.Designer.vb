﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptCompraInmueble
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptCompraInmueble))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.Inmueble = New DevExpress.XtraReports.UI.XRRichText()
        Me.NifCliente = New DevExpress.XtraReports.UI.XRLabel()
        Me.NombreCliente = New DevExpress.XtraReports.UI.XRLabel()
        Me.parNombreCliente = New DevExpress.XtraReports.Parameters.Parameter()
        Me.Text2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Text3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Text4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Text5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.TelefonosCliente = New DevExpress.XtraReports.UI.XRLabel()
        Me.DomicilioCliente = New DevExpress.XtraReports.UI.XRLabel()
        Me.Text8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.Empresa = New DevExpress.XtraReports.UI.XRRichText()
        Me.parEmpresa = New DevExpress.XtraReports.Parameters.Parameter()
        Me.Logo = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.EmpresaCif = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.Text1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.Text7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAvisoLegal = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.Text6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMarginBand1 = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMarginBand1 = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.parAvisoLegal = New DevExpress.XtraReports.Parameters.Parameter()
        Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.ParNombreEmpresa = New DevExpress.XtraReports.Parameters.Parameter()
        CType(Me.Inmueble, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Empresa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Inmueble})
        Me.Detail.HeightF = 50.0!
        Me.Detail.Name = "Detail"
        '
        'Inmueble
        '
        Me.Inmueble.BackColor = System.Drawing.Color.Transparent
        Me.Inmueble.BorderColor = System.Drawing.Color.Black
        Me.Inmueble.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Rtf", Nothing, "Visitas.inmueble"), New DevExpress.XtraReports.UI.XRBinding("Html", Nothing, "Visitas.inmueble")})
        Me.Inmueble.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Inmueble.ForeColor = System.Drawing.Color.Black
        Me.Inmueble.LocationFloat = New DevExpress.Utils.PointFloat(15.99998!, 0.0!)
        Me.Inmueble.Name = "Inmueble"
        Me.Inmueble.SerializableRtfString = resources.GetString("Inmueble.SerializableRtfString")
        Me.Inmueble.SizeF = New System.Drawing.SizeF(750.0!, 37.0!)
        Me.Inmueble.StylePriority.UseBackColor = False
        Me.Inmueble.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'NifCliente
        '
        Me.NifCliente.BackColor = System.Drawing.Color.White
        Me.NifCliente.BorderColor = System.Drawing.Color.Black
        Me.NifCliente.CanGrow = False
        Me.NifCliente.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.NifCliente.ForeColor = System.Drawing.Color.Black
        Me.NifCliente.LocationFloat = New DevExpress.Utils.PointFloat(186.9167!, 51.74999!)
        Me.NifCliente.Name = "NifCliente"
        Me.NifCliente.SizeF = New System.Drawing.SizeF(388.0!, 25.0!)
        Me.NifCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'NombreCliente
        '
        Me.NombreCliente.BackColor = System.Drawing.Color.White
        Me.NombreCliente.BorderColor = System.Drawing.Color.Black
        Me.NombreCliente.CanGrow = False
        Me.NombreCliente.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding(Me.parNombreCliente, "Text", "")})
        Me.NombreCliente.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.NombreCliente.ForeColor = System.Drawing.Color.Black
        Me.NombreCliente.LocationFloat = New DevExpress.Utils.PointFloat(186.9167!, 8.749993!)
        Me.NombreCliente.Name = "NombreCliente"
        Me.NombreCliente.SizeF = New System.Drawing.SizeF(388.0!, 26.45834!)
        Me.NombreCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'parNombreCliente
        '
        Me.parNombreCliente.Description = "Nombre dle cliente"
        Me.parNombreCliente.Name = "parNombreCliente"
        '
        'Text2
        '
        Me.Text2.BackColor = System.Drawing.Color.White
        Me.Text2.BorderColor = System.Drawing.Color.Black
        Me.Text2.CanGrow = False
        Me.Text2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Text2.ForeColor = System.Drawing.Color.Black
        Me.Text2.LocationFloat = New DevExpress.Utils.PointFloat(18.91664!, 9.749985!)
        Me.Text2.Name = "Text2"
        Me.Text2.SizeF = New System.Drawing.SizeF(28.0!, 25.45833!)
        Me.Text2.Text = "D."
        Me.Text2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'Text3
        '
        Me.Text3.BackColor = System.Drawing.Color.White
        Me.Text3.BorderColor = System.Drawing.Color.Black
        Me.Text3.CanGrow = False
        Me.Text3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Text3.ForeColor = System.Drawing.Color.Black
        Me.Text3.LocationFloat = New DevExpress.Utils.PointFloat(19.91666!, 51.74999!)
        Me.Text3.Name = "Text3"
        Me.Text3.SizeF = New System.Drawing.SizeF(42.0!, 25.0!)
        Me.Text3.Text = "D.N.I:"
        Me.Text3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'Text4
        '
        Me.Text4.BackColor = System.Drawing.Color.White
        Me.Text4.BorderColor = System.Drawing.Color.Black
        Me.Text4.CanGrow = False
        Me.Text4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Text4.ForeColor = System.Drawing.Color.Black
        Me.Text4.LocationFloat = New DevExpress.Utils.PointFloat(19.91666!, 76.74999!)
        Me.Text4.Name = "Text4"
        Me.Text4.SizeF = New System.Drawing.SizeF(120.0!, 25.0!)
        Me.Text4.Text = "DOMILICIO:"
        Me.Text4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'Text5
        '
        Me.Text5.BackColor = System.Drawing.Color.White
        Me.Text5.BorderColor = System.Drawing.Color.Black
        Me.Text5.CanGrow = False
        Me.Text5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Text5.ForeColor = System.Drawing.Color.Black
        Me.Text5.LocationFloat = New DevExpress.Utils.PointFloat(19.91666!, 101.75!)
        Me.Text5.Name = "Text5"
        Me.Text5.SizeF = New System.Drawing.SizeF(118.0!, 25.00001!)
        Me.Text5.Text = "TELÉFONOS:"
        Me.Text5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'TelefonosCliente
        '
        Me.TelefonosCliente.BackColor = System.Drawing.Color.White
        Me.TelefonosCliente.BorderColor = System.Drawing.Color.Black
        Me.TelefonosCliente.CanGrow = False
        Me.TelefonosCliente.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TelefonosCliente.ForeColor = System.Drawing.Color.Black
        Me.TelefonosCliente.LocationFloat = New DevExpress.Utils.PointFloat(186.9167!, 101.75!)
        Me.TelefonosCliente.Name = "TelefonosCliente"
        Me.TelefonosCliente.SizeF = New System.Drawing.SizeF(390.0!, 25.00001!)
        Me.TelefonosCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'DomicilioCliente
        '
        Me.DomicilioCliente.BackColor = System.Drawing.Color.White
        Me.DomicilioCliente.BorderColor = System.Drawing.Color.Black
        Me.DomicilioCliente.CanGrow = False
        Me.DomicilioCliente.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.DomicilioCliente.ForeColor = System.Drawing.Color.Black
        Me.DomicilioCliente.LocationFloat = New DevExpress.Utils.PointFloat(186.9167!, 76.74999!)
        Me.DomicilioCliente.Name = "DomicilioCliente"
        Me.DomicilioCliente.SizeF = New System.Drawing.SizeF(390.0!, 25.0!)
        Me.DomicilioCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'Text8
        '
        Me.Text8.BackColor = System.Drawing.Color.White
        Me.Text8.BorderColor = System.Drawing.Color.Black
        Me.Text8.CanGrow = False
        Me.Text8.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Text8.ForeColor = System.Drawing.Color.Black
        Me.Text8.LocationFloat = New DevExpress.Utils.PointFloat(19.91666!, 126.75!)
        Me.Text8.Multiline = True
        Me.Text8.Name = "Text8"
        Me.Text8.SizeF = New System.Drawing.SizeF(741.0!, 41.0!)
        Me.Text8.Text = "Encarga a la inmobiliaria al margen reseñada la gestión de la siguiente operación" & _
    ": " & Global.Microsoft.VisualBasic.ChrW(10) & "LA COMPRA DE ALGUNO DE LOS SIGUIENTE/S INMUEBLES :"
        Me.Text8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopJustify
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Empresa, Me.Logo, Me.EmpresaCif})
        Me.ReportHeader.HeightF = 97.24995!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'Empresa
        '
        Me.Empresa.BackColor = System.Drawing.Color.White
        Me.Empresa.BorderColor = System.Drawing.Color.Black
        Me.Empresa.CanGrow = False
        Me.Empresa.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding(Me.parEmpresa, "Html", "")})
        Me.Empresa.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.Empresa.ForeColor = System.Drawing.Color.Black
        Me.Empresa.LocationFloat = New DevExpress.Utils.PointFloat(296.5417!, 0.0!)
        Me.Empresa.Name = "Empresa"
        Me.Empresa.SerializableRtfString = resources.GetString("Empresa.SerializableRtfString")
        Me.Empresa.SizeF = New System.Drawing.SizeF(402.0834!, 61.58334!)
        Me.Empresa.StylePriority.UseFont = False
        Me.Empresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'parEmpresa
        '
        Me.parEmpresa.Description = "Datos Empresa"
        Me.parEmpresa.Name = "parEmpresa"
        '
        'Logo
        '
        Me.Logo.BackColor = System.Drawing.Color.White
        Me.Logo.BorderColor = System.Drawing.Color.Black
        Me.Logo.LocationFloat = New DevExpress.Utils.PointFloat(17.83333!, 0.0!)
        Me.Logo.Name = "Logo"
        Me.Logo.SizeF = New System.Drawing.SizeF(184.0!, 72.0!)
        Me.Logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'EmpresaCif
        '
        Me.EmpresaCif.BackColor = System.Drawing.Color.White
        Me.EmpresaCif.BorderColor = System.Drawing.Color.Black
        Me.EmpresaCif.CanGrow = False
        Me.EmpresaCif.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.EmpresaCif.ForeColor = System.Drawing.Color.Black
        Me.EmpresaCif.LocationFloat = New DevExpress.Utils.PointFloat(296.5417!, 62.58332!)
        Me.EmpresaCif.Name = "EmpresaCif"
        Me.EmpresaCif.SizeF = New System.Drawing.SizeF(207.2917!, 25.0!)
        Me.EmpresaCif.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Text1})
        Me.PageHeader.HeightF = 49.29168!
        Me.PageHeader.Name = "PageHeader"
        '
        'Text1
        '
        Me.Text1.BackColor = System.Drawing.Color.White
        Me.Text1.BorderColor = System.Drawing.Color.Black
        Me.Text1.CanGrow = False
        Me.Text1.Font = New System.Drawing.Font("Arial", 17.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Text1.ForeColor = System.Drawing.Color.Black
        Me.Text1.LocationFloat = New DevExpress.Utils.PointFloat(15.99998!, 10.00001!)
        Me.Text1.Name = "Text1"
        Me.Text1.SizeF = New System.Drawing.SizeF(762.0417!, 29.0!)
        Me.Text1.StylePriority.UseFont = False
        Me.Text1.Text = " HOJA DE ENCARGO PROFESIONAL" & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Text1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Text7, Me.lblAvisoLegal})
        Me.ReportFooter.HeightF = 571.8334!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'Text7
        '
        Me.Text7.BackColor = System.Drawing.Color.White
        Me.Text7.BorderColor = System.Drawing.Color.Black
        Me.Text7.CanGrow = False
        Me.Text7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Text7.ForeColor = System.Drawing.Color.Black
        Me.Text7.KeepTogether = True
        Me.Text7.LocationFloat = New DevExpress.Utils.PointFloat(17.00001!, 12.00002!)
        Me.Text7.Multiline = True
        Me.Text7.Name = "Text7"
        Me.Text7.SizeF = New System.Drawing.SizeF(741.0!, 476.8334!)
        Me.Text7.StylePriority.UseTextAlignment = False
        Me.Text7.Text = resources.GetString("Text7.Text")
        Me.Text7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'lblAvisoLegal
        '
        Me.lblAvisoLegal.BackColor = System.Drawing.Color.White
        Me.lblAvisoLegal.BorderColor = System.Drawing.Color.Black
        Me.lblAvisoLegal.CanGrow = False
        Me.lblAvisoLegal.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.lblAvisoLegal.ForeColor = System.Drawing.Color.Black
        Me.lblAvisoLegal.KeepTogether = True
        Me.lblAvisoLegal.LocationFloat = New DevExpress.Utils.PointFloat(15.99998!, 488.8334!)
        Me.lblAvisoLegal.Name = "lblAvisoLegal"
        Me.lblAvisoLegal.SizeF = New System.Drawing.SizeF(750.0!, 83.0!)
        Me.lblAvisoLegal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Text6})
        Me.PageFooter.HeightF = 47.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'Text6
        '
        Me.Text6.BackColor = System.Drawing.Color.White
        Me.Text6.BorderColor = System.Drawing.Color.Black
        Me.Text6.CanGrow = False
        Me.Text6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Text6.ForeColor = System.Drawing.Color.Black
        Me.Text6.LocationFloat = New DevExpress.Utils.PointFloat(8.0!, 16.0!)
        Me.Text6.Name = "Text6"
        Me.Text6.SizeF = New System.Drawing.SizeF(758.0!, 28.0!)
        Me.Text6.Text = "IMPORTANTE: VER PLIEGO DE CONDICIONES CONSIGNADAS AL DORSO." & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Text6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'TopMarginBand1
        '
        Me.TopMarginBand1.HeightF = 17.04165!
        Me.TopMarginBand1.Name = "TopMarginBand1"
        '
        'BottomMarginBand1
        '
        Me.BottomMarginBand1.HeightF = 16.0!
        Me.BottomMarginBand1.Name = "BottomMarginBand1"
        '
        'parAvisoLegal
        '
        Me.parAvisoLegal.Description = "Aviso Legal"
        Me.parAvisoLegal.Name = "parAvisoLegal"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.NifCliente, Me.NombreCliente, Me.Text2, Me.Text3, Me.Text8, Me.Text5, Me.TelefonosCliente, Me.DomicilioCliente, Me.Text4})
        Me.GroupHeader1.HeightF = 183.3333!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'GroupFooter1
        '
        Me.GroupFooter1.HeightF = 3.125!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'ParNombreEmpresa
        '
        Me.ParNombreEmpresa.Description = "Parameter1"
        Me.ParNombreEmpresa.Name = "ParNombreEmpresa"
        '
        'rptCompraInmueble
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.ReportHeader, Me.PageHeader, Me.ReportFooter, Me.PageFooter, Me.TopMarginBand1, Me.BottomMarginBand1, Me.GroupHeader1, Me.GroupFooter1})
        Me.DataMember = "Visitas"
        Me.DataSourceSchema = resources.GetString("$this.DataSourceSchema")
        Me.Margins = New System.Drawing.Printing.Margins(16, 16, 17, 16)
        Me.PageHeight = 1167
        Me.PageWidth = 825
        Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.parNombreCliente, Me.parEmpresa, Me.ParNombreEmpresa})
        Me.ShowPrintMarginsWarning = False
        Me.Version = "12.2"
        CType(Me.Inmueble, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Empresa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents NifCliente As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents NombreCliente As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents Text2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents Text3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents Text4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents Text5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents TelefonosCliente As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents DomicilioCliente As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents Text8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents Logo As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents Empresa As DevExpress.XtraReports.UI.XRRichText
    Friend WithEvents EmpresaCif As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents Text1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents Text7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents Text6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents TopMarginBand1 As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMarginBand1 As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents lblAvisoLegal As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents parAvisoLegal As DevExpress.XtraReports.Parameters.Parameter
    Friend WithEvents parNombreCliente As DevExpress.XtraReports.Parameters.Parameter
    Friend WithEvents parEmpresa As DevExpress.XtraReports.Parameters.Parameter
    Friend WithEvents Inmueble As DevExpress.XtraReports.UI.XRRichText
    Friend WithEvents GroupHeader1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
    Friend WithEvents ParNombreEmpresa As DevExpress.XtraReports.Parameters.Parameter
End Class
