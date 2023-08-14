Public Class uc_tb_CheckBoxColor
    Inherits DevExpress.XtraEditors.CheckEdit


    Private ColorInicial As System.Drawing.Color

    Private p_ColorSi As System.Drawing.Color
    Private p_ColorNo As System.Drawing.Color
    Private p_ColorIndeterminado As System.Drawing.Color

    Sub New()

        MyBase.New()
        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        Me.Properties.ReadOnly = True
        Me.Properties.AllowGrayed = True
        ColorInicial = Me.ForeColor

        'p_ColorSi = Color.Red
        'p_ColorIndeterminado = Color.Blue
        'p_ColorNo = ColorInicial

        p_ColorSi = System.Drawing.ColorTranslator.FromHtml("#1b812a")
        p_ColorIndeterminado = System.Drawing.ColorTranslator.FromHtml("#7c2420")
        p_ColorNo = ColorInicial


        Me.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
        Me.Properties.PictureChecked = My.Resources.sel
        Me.Properties.PictureGrayed = My.Resources.nisinino
        Me.Properties.PictureUnchecked = My.Resources.nosel

     
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

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

    Public Property tbColorIndeterminado As System.Drawing.Color
        Get
            Return p_ColorIndeterminado
        End Get
        Set(value As System.Drawing.Color)
            p_ColorIndeterminado = value
        End Set
    End Property


    'Public Overrides Property EditValue As Object
    '    Get
    '        Return MyBase.EditValue
    '    End Get
    '    Set(value As Object)
    '        MyBase.EditValue = value
    '        If MyBase.EditValue = True Then
    '            Me.ForeColor = Color.Red
    '        Else
    '            If value = False Then
    '                Me.ForeColor = ColorInicial
    '            Else
    '                Me.ForeColor = Color.Blue
    '            End If


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
                If value = Windows.Forms.CheckState.Unchecked Then
                    Me.ForeColor = p_ColorIndeterminado
                Else
                    Me.ForeColor = p_ColorNo
                End If


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

    End Sub

    Private Sub CambiarOrderTriEstado()
        Select Case Me.CheckState
            Case CheckState.Checked
                Me.CheckState = CheckState.Unchecked
            Case CheckState.Indeterminate
                Me.CheckState = CheckState.Checked
            Case CheckState.Unchecked
                Me.CheckState = CheckState.Indeterminate
        End Select

        'Select Case Me.CheckState
        '    Case CheckState.Checked
        '        Me.CheckState = CheckState.Indeterminate
        '    Case CheckState.Indeterminate
        '        Me.CheckState = CheckState.Unchecked
        '    Case CheckState.Unchecked
        '        Me.CheckState = CheckState.Checked
        'End Select
    End Sub

    'Private Sub CambiarOrderTriEstado()
    '    Select Case Me.CheckState
    '        Case CheckState.Checked
    '            Me.CheckState = CheckState.Unchecked
    '        Case CheckState.Indeterminate
    '            Me.CheckState = CheckState.Checked
    '        Case CheckState.Unchecked
    '            Me.CheckState = CheckState.Indeterminate
    '    End Select
    'End Sub

    

End Class
