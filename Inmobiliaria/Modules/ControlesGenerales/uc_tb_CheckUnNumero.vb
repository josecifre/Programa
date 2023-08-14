Public Class uc_tb_CheckUnNumero
    Private p_Valor As CheckState

    Private p_ValorCajaTexto1 As Integer

    Private p_tb_ReadOnly As Boolean
    Private p_TextCheckBox As String
    Private ColorInicial As System.Drawing.Color

    Sub New()

        MyBase.New()
        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Public Property TextCheckBox As String
        Get
            Return p_TextCheckBox
        End Get
        Set(value As String)
            p_TextCheckBox = value
            Me.chk.Text = p_TextCheckBox
        End Set
    End Property
    Public Property Valor() As CheckState
        Get
            Return p_Valor
        End Get

        Set(value As CheckState)
            p_Valor = value
            chk.CheckState = p_Valor

        End Set

    End Property

    Private Sub chk_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chk.CheckedChanged
        p_Valor = chk.CheckState
    End Sub
    Private Sub spnValorCajaTexto1_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles spnValorCajaTexto1.EditValueChanged
        p_ValorCajaTexto1 = spnValorCajaTexto1.EditValue
    End Sub
  

    Public Property ValorCajaTexto1() As Integer
        Get
            Return p_ValorCajaTexto1
        End Get

        Set(value As Integer)
            p_ValorCajaTexto1 = value
            spnValorCajaTexto1.EditValue = ValorCajaTexto1

        End Set
    End Property

     
    Public Property tb_ReadOnly() As Boolean
        Get
            Return p_tb_ReadOnly
        End Get

        Set(value As Boolean)
            p_tb_ReadOnly = value
            CambiarReadOnly(p_tb_ReadOnly)

        End Set
    End Property

    Private Sub CambiarReadOnly(Valor)
        For Each c In Me.Controls
            Try
                c.properties.readonly = Valor
            Catch ex As Exception

            End Try
        Next
    End Sub


    Private Sub RC_EnabledChanged(sender As System.Object, e As System.EventArgs) Handles Me.EnabledChanged
        'If Not Me.Enabled Then
        'Me.Enabled = True
        CambiarReadOnly(Not Me.Enabled)
        'End If
    End Sub



End Class
