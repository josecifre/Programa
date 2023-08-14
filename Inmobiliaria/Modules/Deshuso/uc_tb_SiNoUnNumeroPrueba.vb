
Namespace Igis.ControlesTB

    Public Class uc_tb_SiNoUnNumeroPrueba
        Private p_Titulo As String
        Private p_Valor As String

        Private p_ValorCajaTexto1 As Integer
        Private p_tb_ReadOnly As Boolean

        Private ColorInicial As System.Drawing.Color

        Private BinUserControl As BindingSource

        Sub New()

            MyBase.New()
            ' Llamada necesaria para el diseñador.

            InitializeComponent()
 
            '            BinUserControl = New BindingSource(Me.components)
            BinUserControl = New BindingSource()
            BinUserControl.DataSource = GetType(SiNoUnNumero)
            spnValorCajaTexto.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", BinUserControl, "ValorCajaTexto1", True))



            ColorInicial = RC.ForeColor
            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        End Sub


        Public Property DataSource() As SiNoUnNumero
            Get
                Return TryCast(BinUserControl.DataSource, SiNoUnNumero)
            End Get
            Set(value As SiNoUnNumero)
                BinUserControl.DataSource = value
            End Set
        End Property

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


        Public Property Titulo() As String
            Get
                Return p_Titulo
            End Get

            Set(value As String)
                p_Titulo = value
                RC.Text = p_Titulo

            End Set
        End Property

        Public Property ValorCajaTexto1() As Integer
            Get
                Return p_ValorCajaTexto1
            End Get

            Set(value As Integer)
                p_ValorCajaTexto1 = value
                spnValorCajaTexto.EditValue = ValorCajaTexto1

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