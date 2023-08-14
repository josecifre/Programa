Public Class uc_tb_SiNoIndiferente




    Private p_Valor As Nullable(Of Boolean)



    Private p_tb_ReadOnly As Boolean

    Private ColorInicial As System.Drawing.Color

    Sub New()

        MyBase.New()
        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ColorInicial = Me.ForeColor
        RGruop.Properties.Items(0).Value = False
        RGruop.Properties.Items(1).Value = False

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Property Valor() As Nullable(Of Boolean)
        Get
            Return p_Valor
        End Get

        Set(value As Nullable(Of Boolean))
            p_Valor = value

            RGruop.Properties.Items(0).Value = False
            RGruop.Properties.Items(1).Value = False
            RGruop.Properties.Items(2).Value = False

            Select Case value
                Case True
                    RGruop.SelectedIndex = 0

                Case False
                    RGruop.SelectedIndex = 1

                Case Else

                    RGruop.SelectedIndex = 2
            End Select

        End Set

    End Property

    Private Sub RGruop_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles RGruop.SelectedIndexChanged
        Select Case RGruop.SelectedIndex
            Case 0
                p_Valor = True
            Case 1
                p_Valor = False
            Case 2
                p_Valor = Nothing
        End Select
    End Sub
  

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
        Me.RGruop.Properties.ReadOnly = Valor
    End Sub


    Private Sub RC_EnabledChanged(sender As System.Object, e As System.EventArgs) Handles Me.EnabledChanged
        If Not Me.Enabled Then
            ' Me.Enabled = True
            CambiarReadOnly(True)
        End If
    End Sub

 
End Class



