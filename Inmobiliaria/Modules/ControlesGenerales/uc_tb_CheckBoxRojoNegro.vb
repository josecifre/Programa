Public Class uc_tb_CheckBoxRojoNegro
    Inherits DevExpress.XtraEditors.CheckEdit


    Private ColorInicial As System.Drawing.Color

    Private p_ColorSi As System.Drawing.Color
    Private p_ColorNo As System.Drawing.Color
    '  Private p_ColorIn As System.Drawing.Color

    Sub New()

        MyBase.New()
        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        Me.Properties.ReadOnly = True
        '    Me.Properties.AllowGrayed = True
        ColorInicial = Me.ForeColor

        'p_ColorSi = Color.Red
        'p_ColorNo = ColorInicial
        '  p_ColorIn = Color.Green


        p_ColorSi = System.Drawing.ColorTranslator.FromHtml("#1b812a")
        p_ColorNo = ColorInicial


        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
        Me.Properties.PictureChecked = My.Resources.sel
        Me.Properties.PictureGrayed = My.Resources.nisinino
        Me.Properties.PictureUnchecked = My.Resources.nosel

        Me.Properties.AutoWidth = True

    End Sub

    Public Property tbColorSi As System.Drawing.Color
        Get
            Return p_ColorSi
        End Get
        Set(value As System.Drawing.Color)
            p_ColorSi = value
        End Set
    End Property

    Public Property tbColorNo As System.Drawing.Color
        Get
            Return p_ColorNo
        End Get
        Set(value As System.Drawing.Color)
            p_ColorNo = value
        End Set
    End Property


    'Public Property tbColorIn As System.Drawing.Color
    '    Get
    '        Return p_ColorIn
    '    End Get
    '    Set(value As System.Drawing.Color)
    '        p_ColorIn = value
    '    End Set
    'End Property

    'Public Overrides Property CheckState As System.Windows.Forms.CheckState
    '    Get
    '        Return MyBase.CheckState
    '    End Get
    '    Set(value As CheckState)
    '        MyBase.CheckState = value
    '        If MyBase.CheckState = Windows.Forms.CheckState.Checked Then
    '            Me.ForeColor = p_ColorSi
    '        Else
    '            Me.ForeColor = p_ColorNo
    '        End If
    '    End Set
    'End Property

    Public Overrides Property CheckState As System.Windows.Forms.CheckState
        Get
            Return MyBase.CheckState
        End Get
        Set(value As CheckState)
            MyBase.CheckState = value
            If MyBase.CheckState = Windows.Forms.CheckState.Checked Then
                Me.ForeColor = p_ColorSi
            Else
                'If MyBase.CheckState = Windows.Forms.CheckState.Indeterminate Then
                '    Me.ForeColor = p_ColorIn
                'Else
                Me.ForeColor = p_ColorNo

                'End If
            End If
        End Set
    End Property
 
  
    Private Sub Me_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseDown
        CambiarOrderTriEstado()
    End Sub

    Private Sub Me_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Space Then
            CambiarOrderTriEstado()
        End If
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub CambiarOrderTriEstado()
        Select Case Me.CheckState
            Case CheckState.Checked
                Me.CheckState = CheckState.Unchecked

            Case CheckState.Unchecked
                Me.CheckState = CheckState.Checked

            Case Windows.Forms.CheckState.Indeterminate
                Me.CheckState = CheckState.Checked

        End Select
    End Sub
     


End Class
