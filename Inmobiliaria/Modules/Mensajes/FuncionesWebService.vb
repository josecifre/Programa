Module FuncionesWebService

    'Public Function sw_EnviarNotificaciones(Contador As Integer, Mensaje As String, titulo As String, accion As String, Optional RutaEncuesta As String = "", Optional MayorOIgualQueVersionAPP As String = "", Optional MenorOIgualQueVersionAPP As String = "") As Boolean


    '    'Dim evn As New EnvioNotificaciones



    '    'evn.Enviar()

    '    Try

    '        Dim Res2 As WebServiceVenalia.clResultado

    '        Dim ServiceWebUIM As New WebServiceVenalia.WebServiceVenaliaClient


    '        Dim Notificacion As New WebServiceVenalia.clNotificacion
    '        Notificacion.NIF = ""
    '        Notificacion.Mensaje = Mensaje.Trim
    '        Notificacion.titulo = titulo
    '        Notificacion.accion = accion
    '        Notificacion.RutaEncuesta = RutaEncuesta
    '        Notificacion.ContadorReceptor = Contador

    '        Res2 = ServiceWebUIM.EnviarNotificaciones("TresBits", "EE358CB6BF1683287B21B102BBC848EB", Notificacion, MayorOIgualQueVersionAPP, MenorOIgualQueVersionAPP)
    '    Catch FaultEX As ServiceModel.FaultException(Of WebServiceVenalia.clResultado)
    '        '    MessageBox.Show(FaultEX.Message)
    '        Return False
    '    Catch ex As Exception
    '        '  MessageBox.Show(ex.Message)
    '        Return False
    '    End Try


    '    Return True



    'End Function
    'Public Function sw_EscribirMensajeParaAPP(ContadorEmisor As Integer, ContadorReceptor As Integer, Mensaje As String) As Boolean

    '    Try
    '        Dim ServicioWeb As New WebServiceVenalia.WebServiceVenaliaClient
    '        Dim Res As WebServiceVenalia.clResultado
    '        Res = ServicioWeb.EscribirMensaje3("TresBits", "EE358CB6BF1683287B21B102BBC848EB", ContadorEmisor, ContadorReceptor, Mensaje, 0)
    '    Catch FaultEX As ServiceModel.FaultException(Of WebServiceVenalia.clResultado)
    '        MessageBox.Show(FaultEX.Message)
    '        Return False
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '        Return False
    '    End Try

    '    Return True

    'End Function



    'Public Function sw_ObtenerMensajes(ContadorReceptor As Integer, Optional ContadorReceptorSolicita As Integer = 0) As List(Of WebServiceVenalia.clMensajes)

    '    Dim Res As List(Of WebServiceVenalia.clMensajes)


    '    Try
    '        Dim ServicioWeb As New WebServiceVenalia.WebServiceVenaliaClient
    '        Res = ServicioWeb.ObtenerMensajes3("TresBits", "EE358CB6BF1683287B21B102BBC848EB", ContadorReceptor, 0, True)
    '        Return Res

    '    Catch FaultEX As ServiceModel.FaultException(Of WebServiceVenalia.clResultado)

    '        MessageBox.Show(FaultEX.Message)
    '        Return Res

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '        Return Res

    '    End Try



    'End Function

   

End Module
