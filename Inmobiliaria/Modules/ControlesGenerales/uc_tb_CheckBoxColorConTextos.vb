Public Class uc_tb_CheckBoxColorConTextos
    Inherits uc_tb_CheckBoxColor

    Dim p_TextoTrue As String
    Dim p_TextoFalse As String
    Dim p_TextoNull As String

    Sub New()


        MyBase.New()
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        Me.Properties.AllowGrayed = True
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
        Me.Properties.PictureChecked = My.Resources.sel
        Me.Properties.PictureGrayed = My.Resources.nisinino
        Me.Properties.PictureUnchecked = My.Resources.nosel

    End Sub

    Public Property TextoTrue As String
        Get
            Return p_TextoTrue
        End Get
        Set(value As String)
            p_TextoTrue = value
        End Set
    End Property

    Public Property TextoFalse As String
        Get
            Return p_TextoFalse
        End Get
        Set(value As String)
            p_TextoFalse = value
        End Set
    End Property

    Public Property TextoNull As String
        Get
            Return p_TextoNull
        End Get
        Set(value As String)
            p_TextoNull = value
        End Set
    End Property
     
    Private Sub uc_tb_CheckBoxColorConTextos_CheckStateChanged(sender As Object, e As System.EventArgs) Handles Me.CheckStateChanged
        Select Case Me.CheckState
            Case Windows.Forms.CheckState.Checked
                '    Me.ForeColor = Color.Red
                Me.Text = p_TextoTrue
            Case Windows.Forms.CheckState.Indeterminate
                Me.Text = p_TextoNull
                '     Me.ForeColor = Color.Blue
            Case Windows.Forms.CheckState.Unchecked
                Me.Text = p_TextoFalse
                '     Me.ForeColor = Color.Red
        End Select
    End Sub
End Class
