Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

'Imports CrystalDecisions.CrystalReports.Engine
'Imports CrystalDecisions.Shared


Public Class frmReport

    Private Sub frmReport_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Cuando cerramos la ventana del Report, si hay alguna ventana abierta la minimizamos
        For Each f As Form In frmPrincipal.MdiChildren
            If f.Created Then
                f.WindowState = FormWindowState.Normal
            End If
        Next
    End Sub
    'Private Sub prueba()



    ' Dim a As New ReportDocument
    '    a.FileName = "C:\LambdaPi\Curso\Curso Programador\Ejercicios\Forms\Crystal Reports\rptListadoClientes.rpt"

    '    a.PrintToPrinter(1, False, 0, 0)
    'End Sub

    Private Sub frmReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Icon = My.Resources.Icono
        'Me.crw.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree

        ChangeExportButton()
        Me.Show()

    End Sub


    Private Sub ChangeExportButton()

        For Each ctrl As Control In crw.Controls
            'Buscar toolstrip del visor de informes
            If TypeOf ctrl Is ToolStrip Then
                Dim ts As ToolStrip = DirectCast(ctrl, ToolStrip)

                For Each tsi As ToolStripItem In ts.Items

                    'Buscar el botón exportar por un ImageIndex
                    If TypeOf tsi Is ToolStripButton AndAlso tsi.ImageIndex = 8 Then


                        Dim crXb As ToolStripButton = DirectCast(tsi, ToolStripButton)

                        'Clonar el aspecto 
                        Dim tsb As New ToolStripButton()
                        tsb.Size = crXb.Size
                        tsb.Padding = crXb.Padding
                        tsb.Margin = crXb.Margin
                        tsb.TextImageRelation = crXb.TextImageRelation

                        tsb.Text = crXb.Text
                        tsb.ToolTipText = crXb.ToolTipText
                        tsb.ImageScaling = crXb.ImageScaling
                        tsb.ImageAlign = crXb.ImageAlign
                        tsb.ImageIndex = crXb.ImageIndex
                        tsb.Visible = crXb.Visible
                        tsb.Enabled = crXb.Enabled

                        'Añadir el nuevo botón
                        ts.Items.Insert(0, tsb)

                        AddHandler tsb.Click, AddressOf Export_Click

                        Exit For
                    End If
                Next
            End If
        Next

        'Ocultar el botón por defecto
        Me.crw.ShowExportButton = False
    End Sub
    Private Sub Export_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim saveDiag As New SaveFileDialog()
        saveDiag.Title = "Exportar Informe"
        saveDiag.Filter = "Adobe Acrobat (*.pdf)|*.pdf|Microsoft Excel (*.xls)|*.xls|Sólo datos de Microsoft Excel (*.xls)|*.xls|Microsoft Word (*.doc)|*.doc|Formato de texto enriquecido (*.rtf)|*.rtf"
        saveDiag.FilterIndex = 1

        If saveDiag.ShowDialog = Windows.Forms.DialogResult.OK Then

            Dim crDiskFileDestinationOptions As New DiskFileDestinationOptions()
            Dim rptDoc As ReportDocument = DirectCast(crw.ReportSource, ReportDocument)
            Dim crExportOptions As ExportOptions = rptDoc.ExportOptions
            crDiskFileDestinationOptions.DiskFileName = saveDiag.FileName
            crExportOptions.ExportDestinationOptions = crDiskFileDestinationOptions
            crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile

            Select Case saveDiag.FilterIndex
                Case 1
                    ' pdf
                    crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat
                    Exit Select
                Case 2
                    ' xls
                    crExportOptions.ExportFormatType = ExportFormatType.Excel
                    Exit Select
                Case 3
                    ' xls
                    crExportOptions.ExportFormatType = ExportFormatType.ExcelRecord
                    Exit Select
                Case 4
                    ' doc
                    crExportOptions.ExportFormatType = ExportFormatType.WordForWindows
                    Exit Select
                Case 5
                    ' rtf
                    crExportOptions.ExportFormatType = ExportFormatType.RichText
                    Exit Select

            End Select

            rptDoc.Export(crExportOptions)

        End If
    End Sub



End Class
