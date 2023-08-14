Imports FuncionesGenerales.Funciones

Public Class ucDuplicarInmueble

    Public pvp As Integer = -1
    Public pp As Integer = -1

    ''' <summary>
    ''' indica el valor actual de los parametros
    ''' </summary>
    ''' <param name="pvp">precio venta público</param>
    ''' <param name="pp">precio propietario</param>
    ''' <remarks></remarks>
    Public Sub New(pvp As Integer, pp As Integer)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        spnPVP.EditValue = pvp
        spnPP.EditValue = pp

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub


    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        If spnPVP.EditValue > -1 And spnPP.EditValue > -1 Then
            pvp = spnPVP.EditValue
            pp = spnPP.EditValue
            Salir()
        Else
            MsgBox("Indique valores válidos.")
        End If
    End Sub
    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        pvp = -1
        Salir()
    End Sub

    Private Sub Salir()
        Me.Dispose()
    End Sub


End Class