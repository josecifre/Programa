Imports DevExpress.XtraEditors
Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraEditors.ViewInfo

Public Class ucBocadillo3


    Public Ancho As Integer
    Public Alto As Integer

    Sub New(Texto1 As String, Texto2 As String, ContadorEmisor As Integer)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

       
        'Dim ColorFondo As New System.Drawing.Color
        'If ContadorEmisor <> 0 Then
        '    ColorFondo = Color.FromArgb(0, 230, 245, 252)
        'Else
        '    ColorFondo = Color.FromArgb(0, 224, 253, 220)
        'End If
        'ColorFondo = Color.FromArgb(0, 255, 0, 0)
        'Panel1.BackColor = ColorFondo
        'lblTexto.BackColor = ColorFondo

        If Texto2 = "GRANDE" Then
            lblTexto.Font = New Font(lblTexto.Font.FontFamily, 12, FontStyle.Bold)
        Else
            lblTexto.Font = New Font(lblTexto.Font.FontFamily, 9, FontStyle.Bold)
        End If

        lblTexto.Parent = Panel1
        lblTexto.BringToFront()
        lblTexto.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        lblTexto.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        lblTexto.MaximumSize = New Size(600, 100)
        lblTexto.AutoSizeMode = LabelAutoSizeMode.Vertical


        Dim TextoReemplazado As String = ""
        TextoReemplazado = ReemplazarHTML(Texto1)
        lblTexto.Text = TextoReemplazado

        lblTexto.Width = Graphics.FromHwnd(lblTexto.Handle).MeasureString(lblTexto.Text,
                                     lblTexto.Font,
                                     lblTexto.MaximumSize.Width,
                                     StringFormat.GenericDefault).ToSize().Width

        Ancho = lblTexto.Width + 10
        Alto = lblTexto.Height + 20
         

    End Sub

    Private Function ReemplazarHTML(TextoHTML) As String
         

        Dim PosicionInicial As Integer = 0
        Dim PosicionFinal As Integer = 0
        Dim LogitudLink As Integer

        Dim TextoOriginalLink As String = ""
        Dim TextoLinkConEtiquetas As String = ""


        PosicionInicial = InStr(TextoHTML, "<a href=", CompareMethod.Text)



        If PosicionInicial > 0 Then

            Dim PosicionFinalTextoLink As Integer
            PosicionFinalTextoLink = InStr(PosicionInicial, TextoHTML, ">", CompareMethod.Text)

            Dim TextoLink As String = Mid(TextoHTML, PosicionInicial, PosicionFinalTextoLink - PosicionInicial)
            TextoLink = Replace(TextoLink, "<a href=", "")


            PosicionFinal = InStr(PosicionInicial, TextoHTML, "</a>", CompareMethod.Binary)
            If PosicionFinal > 0 Then

                LogitudLink = PosicionFinal - PosicionInicial + 4
                TextoOriginalLink = Mid(TextoHTML, PosicionInicial, LogitudLink)
                TextoHTML = Replace(TextoHTML, TextoOriginalLink, TextoLink)
            End If


        End If
        '  TextoHTML = Replace(TextoHTML, "<br>", "")
        ' TextoHTML = New Text.RegularExpressions.Regex("\n").Replace(TextoHTML, "<br>")

        Return TextoHTML

    End Function

    Private Sub SizeMemoEdit(ByVal [me] As MemoEdit)
        Dim vi As MemoEditViewInfo = TryCast([me].GetViewInfo(), MemoEditViewInfo)
        Dim cache As GraphicsCache = New GraphicsCache([me].CreateGraphics())
        Dim h As Integer = (TryCast(vi, DevExpress.XtraEditors.ViewInfo.IHeightAdaptable)).CalcHeight(cache, vi.MaskBoxRect.Width)
        Dim args As ObjectInfoArgs = New ObjectInfoArgs()
        args.Bounds = New Rectangle(0, 0, vi.ClientRect.Width, h)
        Dim rect As Rectangle = vi.BorderPainter.CalcBoundsByClientRectangle(args)
        cache.Dispose()
        If rect.Height <> [me].Height Then
            [me].Height = rect.Height
        End If
    End Sub

    Private Sub ucBocadillo2_MouseEnter(sender As System.Object, e As System.EventArgs) Handles MyBase.MouseEnter
        ActiveControl = Me.Parent
    End Sub
End Class