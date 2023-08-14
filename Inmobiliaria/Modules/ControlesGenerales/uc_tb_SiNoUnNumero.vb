Imports System.ComponentModel

Namespace Venalia.ControlesTB

    Public Class uc_tb_SiNoUnNumero

        Public Event ValorCajaTextoChanged As EventHandler


        Private p_Titulo As String
        Private p_Valor As String

        Private p_ValorCajaTexto1 As Integer
        Private p_tb_ReadOnly As Boolean

        Private ColorInicial As System.Drawing.Color

        Sub New()

            MyBase.New()
            ' Llamada necesaria para el diseñador.
            InitializeComponent()
            ColorInicial = RC.ForeColor
            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        End Sub



        Public Property Valor() As String
            Get
                Return p_Valor
            End Get

            Set(value As String)
                p_Valor = value


                Select Case value
                    Case True
                        RGruop.SelectedIndex = 0
                        RC.AppearanceCaption.ForeColor = Color.Red
                    Case False
                        RGruop.SelectedIndex = 1
                        RC.AppearanceCaption.ForeColor = ColorInicial
                End Select

            End Set

        End Property

        Private Sub RGruop_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles RGruop.SelectedIndexChanged
            Select Case RGruop.SelectedIndex
                Case 0
                    p_Valor = True
                Case 1
                    p_Valor = False

            End Select
        End Sub

        Private Sub spnValorCajaTexto1_EditValueChanged_1(sender As System.Object, e As System.EventArgs) Handles spnValorCajaTexto1.EditValueChanged
            p_ValorCajaTexto1 = spnValorCajaTexto1.EditValue
        End Sub
        Public Property Titulo() As String
            Get
                Return p_Titulo
            End Get

            Set(value As String)
                p_Titulo = value
                RC.Text = p_Titulo

            End Set
        End Property

        <Bindable(True)> _
        Public Property ValorCajaTexto() As Integer
            Get
                Return p_ValorCajaTexto1
            End Get

            Set(value As Integer)
                p_ValorCajaTexto1 = value
                spnValorCajaTexto1.EditValue = ValorCajaTexto
                RaiseEvent ValorCajaTextoChanged(Me, EventArgs.Empty)
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
            For Each c In Me.RC.Controls
                Try
                    c.properties.readonly = Valor
                Catch ex As Exception

                End Try
            Next
        End Sub


        Private Sub RC_EnabledChanged(sender As System.Object, e As System.EventArgs) Handles RC.EnabledChanged
            If Not Me.Enabled Then
                Me.Enabled = True
                CambiarReadOnly(True)
            End If
        End Sub





    End Class
End Namespace