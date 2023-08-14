Public Class frmBuscador

    Public EsInmuebles As Boolean

    Dim Cargando As Boolean

    Sub New()

        InitializeComponent()

    End Sub
    Private Sub frmBuscador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AparienciaGeneral()

        Cargando = True

        FuncionesGenerales.Funciones.LlenarCombo(cmbEmpleados, "Empleados", "Nombre", "Contador", , , "SELECT Contador, Nombre FROM Empleados ORDER BY Nombre")
        FuncionesGenerales.Funciones.LlenarCombo(cmbAgrupaciones, "Agrupaciones", "Agrupacion", "Agrupacion", , , "SELECT Agrupacion FROM Agrupaciones")
        'FuncionesGenerales.Funciones.LlenarCombo(cmbPoblacion, "Poblacion", "Poblacion", "Poblacion", , , "SELECT Poblacion FROM Poblacion")
        'FuncionesGenerales.Funciones.LlenarCombo(cmbOrientacion, "Orientacion", "Orientacion", "Orientacion", , , "SELECT Orientacion FROM Orientacion")
        'FuncionesGenerales.Funciones.LlenarCombo(cmbEstado, "Estado", "Estado", "Estado", , , "SELECT Estado FROM Estado ORDER BY Prioridad DESC")
        'FuncionesGenerales.Funciones.LlenarCombo(cmbTipo, "Tipo", "Tipo", "Tipo", , , "SELECT Tipo FROM Tipo")

        PrepararLlenarCheckCombosClientes(cmbOrientacion2, "Orientacion", , , "SELECT Orientacion FROM Orientacion ORDER by Orientacion", , False)
        PrepararLlenarCheckCombosClientes(cmbTipo2, "Tipo", , , "SELECT Tipo FROM Tipo ORDER by Tipo", , False)
        PrepararLlenarCheckCombosClientes(cmbEstado2, "Estado", , , "SELECT Estado FROM Estado ORDER by Prioridad", , False)

        PrepararLlenarCheckCombosClientes(cmbPoblacion, "Poblacion", , , "SELECT Poblacion, Provincia FROM Poblacion WHERE Visible  = " & GL_SQL_VALOR_1 & " AND Provincia IN (SELECT Provincia FROM Provincias WHERE Visible = " & GL_SQL_VALOR_1 & ") ORDER BY Poblacion, Provincia ", , False)
        PrepararLlenarCheckCombosClientes(cmbTipoVenta2, "TipoVenta", , , "SELECT TipoVenta FROM TipoVenta ORDER by Orden", , False)


        Cargando = False
    End Sub

    Private Sub PrepararLlenarCheckCombosClientes(ByVal cmb As uc_tb_CombosCheck, ByVal Tabla As String, Optional ByVal ConBinding As Boolean = True, Optional ByVal Orden As String = "", Optional ByVal ConsultaCompleta As String = "", Optional Llenar As Boolean = True, Optional HacerClear As Boolean = True)

        Cargando = True

        Dim Baja As String = ""

        cmb.tb_TablaCompleta = Tabla
        cmb.tb_TablaEnlazada = "Clientes" & Tabla
        cmb.tb_Campo = Tabla
        cmb.tb_CampoFiltro = "ContadorCliente"
        If Llenar Then
            cmb.tb_LlenarCompleta(Orden, ConsultaCompleta, HacerClear)
            cmb.tb_ValorBusqueda = 0


        End If

        Cargando = False


        'For i = 0 To cmb.DataBindings.Count - 1
        '    cmb.DataBindings.RemoveAt(0)
        'Next
        'If ConBinding Then




        '    '  cmb.DataBindings.Add(New Binding("tb_ValorBusqueda", BinSrc, "Codigo", True))fech
        'Else
        '    '    cmb.tb_PreparaDatosComboCheck()
        'End If


        'For Each c As CheckedListBoxItem In cmb.Properties.Items
        '    c.Enabled = True
        '    c.Value = False
        'Next
        'cmb.Text = ""

    End Sub

    Private Sub LlenarZona()

        If Cargando Then
            Exit Sub
        End If


        Dim Res As List(Of Tablas.clZonas)

        Try

            Dim Poblaciones As New List(Of String)
            Dim PoblacionesArray As String()
            PoblacionesArray = Split(cmbPoblacion.EditValue, ";")

            For i = 0 To PoblacionesArray.Length - 1
                Poblaciones.Add(PoblacionesArray(i).Trim)
            Next

            Res = ListaZonas(Poblaciones, DatosEmpresa.Codigo)

            cmbzona2.DeselectAll()
            cmbzona2.Properties.Items.Clear()
            cmbzona2.Properties.DataSource = Nothing


            cmbzona2.Properties.DataSource = Res

            cmbzona2.Properties.DisplayMember = "Zona"
            cmbzona2.Properties.ValueMember = "Zona"
            cmbzona2.Properties.SeparatorChar = ";"

            '   cmbzona2.tb_ValorBusqueda = 0

            'For i = 0 To cmbzona2.DataBindings.Count - 1
            '    cmbzona2.DataBindings.RemoveAt(0)
            'Next



            'End If

            '   cmbzona2.tb_ValorBusqueda = 0

            'If PrimeraVez Then
            '    cmbzona2.DataBindings.Add(New Binding("tb_ValorBusqueda", BinSrc, "Contador", True, DataSourceUpdateMode.Never))
            'End If

            'Res = ListaZonas(Poblaciones, DatosEmpresa.Codigo)

            'cmbzona2.DeselectAll()
            'cmbzona2.Properties.Items.Clear()
            'cmbzona2.Properties.DataSource = Nothing


            'cmbzona2.Properties.DataSource = Res

            'cmbzona2.Properties.DisplayMember = "Zona"
            'cmbzona2.Properties.ValueMember = "Zona"
            'cmbzona2.Properties.SeparatorChar = ";"

            'cmbzona2.tb_ValorBusqueda = 0

            'For i = 0 To cmbzona2.DataBindings.Count - 1
            '    cmbzona2.DataBindings.RemoveAt(0)
            'Next


            ''                If PrimeraVezLlenarZona Then
            ''PrimeraVezLlenarZona = False
            'If Not btnAceptar.Enabled Then
            '    cmbzona2.DataBindings.Add(New Binding("tb_ValorBusqueda", BinSrc, "Contador", True, DataSourceUpdateMode.Never))
            'End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try







    End Sub
#Region "Mantenimiento Asunto"

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Aceptar()
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub

    Private Sub Aceptar()
        GenerarBusqueda()
        Salir()
    End Sub
    Private Sub Cancelar()
        GL_Busqueda = ""
        Salir()
    End Sub

#End Region

    Private Sub Salir()
        Me.Hide()
        'LiberarMemoria()
    End Sub
    Private Sub GenerarBusqueda()
        GL_Busqueda = ""

        GL_Busqueda &= ObtenerBusquedaDesdeComboGrid(cmbTipoVenta2, "TipoVenta")
        GL_Busqueda &= ObtenerBusquedaDesdeComboGrid(cmbPoblacion, "Poblacion")
        GL_Busqueda &= ObtenerBusquedaDesdeComboGrid(cmbTipo2, "Tipo")
        GL_Busqueda &= ObtenerBusquedaDesdeComboGrid(cmbEstado2, "Estado")
        GL_Busqueda &= ObtenerBusquedaDesdeComboGrid(cmbOrientacion2, "Orientacion")

        GL_Busqueda &= ObtenerBusquedaDesdeComboGrid(cmbZona2, "Zona")

        If txtExtras.Text.Trim <> "" Then
            GL_Busqueda &= " AND Extras LIKE '%" & txtExtras.Text & "%'"
        End If
        If txtDireccion.Text.Trim <> "" Then
            GL_Busqueda &= " AND Direccion LIKE '%" & txtDireccion.Text & "%'"
        End If
        If txtObservaciones.Text.Trim <> "" Then
            GL_Busqueda &= " AND (SELECT COUNT(*) FROM InmueblesObservaciones WHERE ContadorInmueble=I.Contador AND Observaciones LIKE '%" & txtObservaciones.Text & "%') > 0"
        End If
        If txtReferencia.Text.Trim <> "" Then
            GL_Busqueda &= " AND Referencia LIKE '%" & txtReferencia.Text & "%'"
        End If
        If txtGarajeNumero.Text.Trim <> "" Then
            GL_Busqueda &= " AND GarajeNumero LIKE '%" & txtGarajeNumero.Text & "%'"
        End If

        
        
        'If Not cmbEstado.EditValue = Nothing Then
        '    GL_Busqueda &= " AND Estado LIKE '%" & Funciones.pf_ReplaceComillas(cmbEstado.EditValue) & "%'"
        'End If
        'If Not cmbTipo.EditValue = Nothing Then
        '    GL_Busqueda &= " AND Tipo LIKE '%" & Funciones.pf_ReplaceComillas(cmbTipo.EditValue) & "%'"
        'End If
        If Not cmbAgrupaciones.EditValue = Nothing Then
            GL_Busqueda &= " AND Agrupacion LIKE '%" & Funciones.pf_ReplaceComillas(cmbAgrupaciones.EditValue) & "%'"
        End If
        'If Not cmbOrientacion.EditValue = Nothing Then
        '    GL_Busqueda &= " AND Orientacion LIKE '%" & Funciones.pf_ReplaceComillas(cmbOrientacion.EditValue) & "%'"
        'End If


        'If Not cmbPoblacion.EditValue = Nothing Then
        '    GL_Busqueda &= " AND Poblacion LIKE '%" & Funciones.pf_ReplaceComillas(cmbPoblacion.EditValue) & "%'"
        'End If

      







        If Not cmbCalificacionEnergetica.EditValue = Nothing Then
            GL_Busqueda &= " AND CalificacionEnergetica LIKE '%" & cmbCalificacionEnergetica.EditValue & "%'"
        End If

        If Not cmbEmpleados.EditValue = Nothing Then
            GL_Busqueda &= " AND ContadorEmpleado = " & cmbEmpleados.EditValue
        End If

        If Not mskFechaAlta.EditValue = Nothing Then
            GL_Busqueda &= " AND FechaAlta <= '" & Microsoft.VisualBasic.Format(mskFechaAlta.EditValue, "yyyyMMdd") & "'"
        End If

        If ucGarajeVenta.Valor Is Nothing OrElse ucGarajeVenta.Valor Then
            GL_Busqueda &= " AND Garaje " & IIf(ucGarajeVenta.Valor Is Nothing, "IS NULL", "=" & GL_SQL_VALOR_1)
        End If
        If ucTrasteroVenta.Valor Is Nothing OrElse ucTrasteroVenta.Valor Then
            GL_Busqueda &= " AND Trastero " & IIf(ucTrasteroVenta.Valor Is Nothing, "IS NULL", "=" & GL_SQL_VALOR_1)
        End If

        If spnPrecioGaraje.EditValue > 0 Then
            GL_Busqueda &= " AND PrecioGaraje <= " & spnPrecioGaraje.EditValue
        End If
        If spnPrecioTrastero.EditValue > 0 Then
            GL_Busqueda &= " AND PrecioTrastero <= " & spnPrecioTrastero.EditValue
        End If
        If spnMetrosGaraje.EditValue > 0 Then
            GL_Busqueda &= " AND MGaraje >= " & spnMetrosGaraje.EditValue
        End If
        If spnMetrosTrastero.EditValue > 0 Then
            GL_Busqueda &= " AND MTrastero >= " & spnMetrosTrastero.EditValue
        End If
        If spnJardinM1.EditValue > 0 Then
            GL_Busqueda &= " AND MJardin >= " & spnJardinM1.EditValue
        End If
        If spnTerrazaM1.EditValue > 0 Then
            GL_Busqueda &= " AND MTerraza >= " & spnTerrazaM1.EditValue
        End If
        If spnTerrazaM2.EditValue > 0 Then
            GL_Busqueda &= " AND MTerraza2 >= " & spnTerrazaM2.EditValue
        End If
        If spnPatioM1.EditValue > 0 Then
            GL_Busqueda &= " AND MPatio >= " & spnPatioM1.EditValue
        End If
        If spnPatioM2.EditValue > 0 Then
            GL_Busqueda &= " AND MPatio2 >= " & spnPatioM2.EditValue
        End If
        If spnBalconM1.EditValue > 0 Then
            GL_Busqueda &= " AND MBalcon >= " & spnBalconM1.EditValue
        End If
        If spnBalconM2.EditValue > 0 Then
            GL_Busqueda &= " AND MBalcon2 >= " & spnBalconM2.EditValue
        End If

        If spnPrecio.EditValue > 0 Then
            GL_Busqueda &= " AND Precio <= " & spnPrecio.EditValue
        End If
        If spnPersonas.EditValue > 0 Then
            GL_Busqueda &= " AND Personas >= " & spnPersonas.EditValue
        End If
        If spnBanos.EditValue > 0 Then
            GL_Busqueda &= " AND Banos >= " & spnBanos.EditValue
        End If

        If Not spnAltura.EditValue = Nothing Then
            Select Case spnAltura.EditValue
                Case "PB", "-2"
                    GL_Busqueda &= " AND Altura = -2"
                Case "ENT", "-1"
                    GL_Busqueda &= " AND Altura = -1"
                Case Else
                    If IsNumeric(spnAltura.EditValue) Then
                        GL_Busqueda &= " AND Altura <= AND Altura >=0"
                    End If
            End Select
        End If
        If spnHabitaciones.EditValue > 0 Then
            GL_Busqueda &= " AND Habitaciones >= " & spnHabitaciones.EditValue
        End If

        If spnMetros.EditValue > 0 Then
            GL_Busqueda &= " AND Metros >= " & spnMetros.EditValue
        End If
        If spnMetrosPlaya.EditValue > 0 Then
            GL_Busqueda &= " AND MetrosPlaya <= " & spnMetrosPlaya.EditValue
        End If
        If spnAnoConstruccion.EditValue > 0 Then
            GL_Busqueda &= " AND AnoConstruccion >= " & spnAnoConstruccion.EditValue
        End If

        If chkEnviadaFicha.Checked Then
            GL_Busqueda &= " AND EnviadaFicha = " & GL_SQL_VALOR_1
        End If
        If chkPrimeraLineaPlaya.Checked Then
            GL_Busqueda &= " AND PrimeraLineaPlaya = " & GL_SQL_VALOR_1
        End If
        If chkVivenEnEl.Checked Then
            GL_Busqueda &= " AND VivenEnEl = " & GL_SQL_VALOR_1
        End If
        If chkGarajeCerrado.Checked Then
            GL_Busqueda &= " AND GarajeCerrado = " & GL_SQL_VALOR_1
        End If
        If chkLlaves.Checked Then
            GL_Busqueda &= " AND Llaves = " & GL_SQL_VALOR_1
        End If
        If chkAireAcondicionado.Checked Then
            GL_Busqueda &= " AND AireAcondicionado = " & GL_SQL_VALOR_1
        End If
        If chkCalefaccion.Checked Then
            GL_Busqueda &= " AND Calefaccion = " & GL_SQL_VALOR_1
        End If
        If chkCartel.Checked Then
            GL_Busqueda &= " AND Cartel = " & GL_SQL_VALOR_1
        End If
        If chkElectrodomesticos.Checked Then
            GL_Busqueda &= " AND Electrodomesticos = " & GL_SQL_VALOR_1
        End If

        If chkAccesoMinusvalidos.Checked Then
            GL_Busqueda &= " AND AccesoMinusvalidos = " & GL_SQL_VALOR_1
        End If

        If chkCocinaOffice.Checked Then
            GL_Busqueda &= " AND CocinaOffice = " & GL_SQL_VALOR_1
        End If

        If chkVistasAlMar.Checked Then
            GL_Busqueda &= " AND VistasAlMar = " & GL_SQL_VALOR_1
        End If

        If chkUrbanizacion.Checked Then
            GL_Busqueda &= " AND Urbanizacion = " & GL_SQL_VALOR_1
        End If

        If chkZonaComercial.Checked Then
            GL_Busqueda &= " AND ZonaComercial = " & GL_SQL_VALOR_1
        End If


        If chkAmuebladoVenta.Checked Then
            GL_Busqueda &= " AND Amueblado = " & GL_SQL_VALOR_1
        End If
        If chkGaleria.Checked Then
            GL_Busqueda &= " AND Galeria = " & GL_SQL_VALOR_1
        End If
        If chkJardin.Checked Then
            GL_Busqueda &= " AND Jardin = " & GL_SQL_VALOR_1
        End If
        If chkEscaparate.Checked Then
            GL_Busqueda &= " AND Escaparate = " & GL_SQL_VALOR_1
        End If
        If chkAscensor.Checked Then
            GL_Busqueda &= " AND Ascensor = " & GL_SQL_VALOR_1
        End If
        If chkOportunidad.Checked Then
            GL_Busqueda &= " AND Oportunidad = " & GL_SQL_VALOR_1
        End If
        If chkExclusiva.Checked Then
            GL_Busqueda &= " AND Exclusiva = " & GL_SQL_VALOR_1
        End If
        If chkDuplex.Checked Then
            GL_Busqueda &= " AND Duplex = " & GL_SQL_VALOR_1
        End If
        If chkAlquilerVacacional.Checked Then
            GL_Busqueda &= " AND AlquilerVacacional = " & GL_SQL_VALOR_1
        End If
        'If spnOpcionCompra.EditValue > 0 Then
        '    GL_Busqueda &= " AND AlquilerOpcionCompra <= " & spnOpcionCompra.EditValue
        'End If
        If chkOpcionCompra.Checked Then
            GL_Busqueda &= " AND AlquilerOpcionCompra = " & GL_SQL_VALOR_1
        End If
        If chkPiscina.Checked Then
            GL_Busqueda &= " AND Piscina = " & GL_SQL_VALOR_1
        End If
        If chkTerraza.Checked Then
            GL_Busqueda &= " AND Terraza = " & GL_SQL_VALOR_1
        End If
        If chkPatio.Checked Then
            GL_Busqueda &= " AND Patio = " & GL_SQL_VALOR_1
        End If
        If chkBalcon.Checked Then
            GL_Busqueda &= " AND Balcon = " & GL_SQL_VALOR_1
        End If
        If chkSemiAmuebladoVenta.Checked Then
            GL_Busqueda &= " AND SemiAmueblado = " & GL_SQL_VALOR_1
        End If

        GL_Busqueda &= " "
    End Sub

    Private Function ObtenerBusquedaDesdeComboGrid(ByVal cmb As uc_tb_CombosCheck, Campo As String) As String

        Dim Resultado As String = ""

        If Not cmb.EditValue = Nothing AndAlso cmb.EditValue <> "" Then




            Dim PoblacionesArray As String()
            PoblacionesArray = Split(cmb.EditValue, ";")

            Dim ListaIn As String = ""

            For i = 0 To PoblacionesArray.Length - 1
                ListaIn = ListaIn & ", '" & Funciones.pf_ReplaceComillas(PoblacionesArray(i).Trim) & "'"
            Next

            If ListaIn <> "" Then
                Resultado = " AND " & Campo & " IN (" & ListaIn.Substring(1) & ")"
            End If



        End If

        Return Resultado

    End Function


#Region "ParaKeyPreview"

    Private Structure MSG
        Public hwnd As IntPtr
        Public message As Integer
        Public wParam As IntPtr
        Public lParam As IntPtr
        Public time As Integer
        Public pt_x As Integer
        Public pt_y As Integer
    End Structure

    <Runtime.InteropServices.DllImport("user32.dll", CharSet:=Runtime.InteropServices.CharSet.Auto)> _
    Private Shared Function PeekMessage(<Runtime.InteropServices.In(), Runtime.InteropServices.Out()> ByRef msg As MSG, ByVal hwnd As Runtime.InteropServices.HandleRef, ByVal msgMin As Integer, ByVal msgMax As Integer, ByVal remove As Integer) As Boolean
    End Function
    ''' <span class="code-SummaryComment"><summary> </span>
    ''' Trap any keypress before child controls get hold of them
    ''' <span class="code-SummaryComment"></summary></span>
    ''' <span class="code-SummaryComment"><param name="m">Windows message</param></span>
    ''' <span class="code-SummaryComment"><returns>True if the keypress is handled</returns></span>
    Protected Overrides Function ProcessKeyPreview(ByRef m As Message) As Boolean
        Const WM_KEYDOWN As Integer = &H100
        Const WM_KEYUP As Integer = &H101
        Const WM_CHAR As Integer = &H102
        Const WM_SYSCHAR As Integer = &H106
        Const WM_SYSKEYDOWN As Integer = &H104
        Const WM_SYSKEYUP As Integer = &H105
        Const WM_IME_CHAR As Integer = &H286

        Dim e As KeyEventArgs = Nothing

        If (m.Msg <> WM_CHAR) AndAlso (m.Msg <> WM_SYSCHAR) AndAlso (m.Msg <> WM_IME_CHAR) Then
            e = New KeyEventArgs(DirectCast(CInt(CLng(m.WParam)), Keys) Or ModifierKeys)
            If (m.Msg = WM_KEYDOWN) OrElse (m.Msg = WM_SYSKEYDOWN) Then
                TrappedKeyDown(e)
            End If
            'else
            '{
            '    TrappedKeyUp(e);
            '}

            ' Remove any WM_CHAR type messages if supresskeypress is true.
            If e.SuppressKeyPress Then
                Me.RemovePendingMessages(WM_CHAR, WM_CHAR)
                Me.RemovePendingMessages(WM_SYSCHAR, WM_SYSCHAR)
                Me.RemovePendingMessages(WM_IME_CHAR, WM_IME_CHAR)
            End If

            If e.Handled Then
                Return e.Handled
            End If
        End If
        Return MyBase.ProcessKeyPreview(m)
    End Function

    Private Sub RemovePendingMessages(ByVal msgMin As Integer, ByVal msgMax As Integer)
        If Not Me.IsDisposed Then
            Dim msg As New MSG()
            Dim handle As IntPtr = Me.Handle
            While PeekMessage(msg, New Runtime.InteropServices.HandleRef(Me, handle), msgMin, msgMax, 1)
            End While
        End If
    End Sub

    ''' <span class="code-SummaryComment"><summary></span>
    ''' This routine gets called if a keydown has been trapped 
    ''' before a child control can get it.
    ''' <span class="code-SummaryComment"></summary></span>
    ''' <span class="code-SummaryComment"><param name="e"></param></span>
    Private Sub TrappedKeyDown(ByVal e As KeyEventArgs)

        If e.KeyCode = Keys.Escape Then

            Try
                Cancelar()
                e.Handled = True
                e.SuppressKeyPress = True
            Catch ex As Exception

            End Try

        End If

        If e.KeyCode = Keys.F12 Then
            Aceptar()
            e.Handled = True
            e.SuppressKeyPress = True
            Exit Sub
        End If


    End Sub

#End Region

    Private Sub cmbCalificacionEnergetica_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCalificacionEnergetica.SelectedIndexChanged
        Select Case cmbCalificacionEnergetica.SelectedItem.ToString
            Case "A" : cmbCalificacionEnergetica.BackColor = Color.DarkGreen : cmbCalificacionEnergetica.ForeColor = Color.White
            Case "B" : cmbCalificacionEnergetica.BackColor = Color.Green : cmbCalificacionEnergetica.ForeColor = Color.White
            Case "C" : cmbCalificacionEnergetica.BackColor = Color.GreenYellow : cmbCalificacionEnergetica.ForeColor = Color.Gray
            Case "D" : cmbCalificacionEnergetica.BackColor = Color.Yellow : cmbCalificacionEnergetica.ForeColor = Color.LightGray
            Case "E" : cmbCalificacionEnergetica.BackColor = Color.Orange : cmbCalificacionEnergetica.ForeColor = Color.White
            Case "F" : cmbCalificacionEnergetica.BackColor = Color.Red : cmbCalificacionEnergetica.ForeColor = Color.White
            Case "G" : cmbCalificacionEnergetica.BackColor = Color.DarkRed : cmbCalificacionEnergetica.ForeColor = Color.White
            Case Else : cmbCalificacionEnergetica.BackColor = Color.White : cmbCalificacionEnergetica.ForeColor = Color.Black
        End Select

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        txtExtras.Text = ""
        txtDireccion.Text = ""
        txtObservaciones.Text = ""
        txtReferencia.Text = ""
        txtGarajeNumero.Text = ""

 
        cmbAgrupaciones.EditValue = Nothing


        PrepararLlenarCheckCombosClientes(cmbOrientacion2, "Orientacion", , , "SELECT Orientacion FROM Orientacion ORDER by Orientacion", , True)
        PrepararLlenarCheckCombosClientes(cmbTipo2, "Tipo", , , "SELECT Tipo FROM Tipo ORDER by Tipo", , True)
        PrepararLlenarCheckCombosClientes(cmbEstado2, "Estado", , , "SELECT Estado FROM Estado ORDER by Prioridad", , True)


        PrepararLlenarCheckCombosClientes(cmbTipoVenta2, "TipoVenta", , , "SELECT TipoVenta FROM TipoVenta ORDER by Orden", , True)
        PrepararLlenarCheckCombosClientes(cmbPoblacion, "Poblacion", , , "SELECT Poblacion, Provincia FROM Poblacion WHERE Visible  = " & GL_SQL_VALOR_1 & " AND Provincia IN (SELECT Provincia FROM Provincias WHERE Visible = " & GL_SQL_VALOR_1 & ") ORDER BY Poblacion, Provincia ", , True)

        cmbZona2.Properties.Items.Clear()
        cmbZona2.Properties.DataSource = Nothing

        cmbCalificacionEnergetica.EditValue = Nothing
        cmbEmpleados.EditValue = Nothing
        mskFechaAlta.EditValue = Nothing

        ucGarajeVenta.Valor = False
        ucTrasteroVenta.Valor = False

        spnPrecioGaraje.EditValue = 0
        spnPrecioTrastero.EditValue = 0
        spnMetrosGaraje.EditValue = 0
        spnMetrosTrastero.EditValue = 0
        spnJardinM1.EditValue = 0
        spnTerrazaM1.EditValue = 0
        spnTerrazaM2.EditValue = 0
        spnPatioM1.EditValue = 0
        spnPatioM2.EditValue = 0
        spnBalconM1.EditValue = 0
        spnBalconM2.EditValue = 0

        spnPrecio.EditValue = Nothing
        spnPersonas.EditValue = Nothing
        spnBanos.EditValue = Nothing

        spnAltura.EditValue = Nothing
        spnHabitaciones.EditValue = Nothing

        spnMetros.EditValue = Nothing
        spnMetrosPlaya.EditValue = Nothing
        spnAnoConstruccion.EditValue = Nothing

        chkEnviadaFicha.Checked = False
        chkPrimeraLineaPlaya.Checked = False
        chkVivenEnEl.Checked = False
        chkGarajeCerrado.Checked = False
        chkLlaves.Checked = False
        chkAireAcondicionado.Checked = False
        chkCalefaccion.Checked = False
        chkCartel.Checked = False
        chkElectrodomesticos.Checked = False
        chkAmuebladoVenta.Checked = False
        chkGaleria.Checked = False
        chkJardin.Checked = False
        chkEscaparate.Checked = False
        chkAscensor.Checked = False
        chkOportunidad.Checked = False
        chkExclusiva.Checked = False
        chkDuplex.Checked = False
        chkOpcionCompra.Checked = False
        chkAlquilerVacacional.Checked = False
        chkPiscina.Checked = False
        chkTerraza.Checked = False
        chkPatio.Checked = False
        chkBalcon.Checked = False
        chkSemiAmuebladoVenta.Checked = False

        chkAccesoMinusvalidos.Checked = False
        chkCocinaOffice.Checked = False
        chkVistasAlMar.Checked = False
        chkUrbanizacion.Checked = False
        chkZonaComercial.Checked = False
    End Sub
    Private Sub cmbPoblacion_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cmbPoblacion.EditValueChanged
        LlenarZona()
    End Sub

    Private Sub cmbEmpleados_QueryPopUp(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbEmpleados.QueryPopUp
        cmbEmpleados.Properties.View.Columns("Contador").Visible = False
    End Sub
End Class