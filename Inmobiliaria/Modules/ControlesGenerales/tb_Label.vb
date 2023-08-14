Public Class tb_Label
    Inherits DevExpress.XtraEditors.LabelControl

    Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        Me.AllowHtmlString = True
        '   Me.Text = "<b><color=Black>" & Me.Text & " </b></color>"
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub


    Public Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(value As String)
            '  MyBase.Text = value
            MyBase.Text = "<b><color=Black>" & value & " </b></color>"
        End Set
    End Property

End Class

