

Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid
Imports System
Imports DevExpress.XtraEditors
Imports System.Data
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraBars
Imports DevExpress.LookAndFeel.Design
Imports System.Drawing
Imports DevExpress.Skins
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports System.Data.SqlClient


Partial Public Class ucConfiguracionEmpresas

    Inherits DevExpress.XtraEditors.XtraUserControl

    '  Dim AnadiendoOModificando As Boolean = False
    Dim DocumentosListado As ucDocumentosListadoBase
    '   Dim DocumentosDetalle As ucDocumentosGenerarBase

    Dim Eliminando As Boolean = False
    Dim menu As DXPopupMenu
    Public PopupMenu As DXPopupMenu
    Dim EstoyEnAlta As Boolean

    Dim bd As BaseDatos
    Private WithEvents BinSrc As BindingSource
    Dim TablaMantenimiento As String = "Empresas"
    Dim Cargando As Boolean = True
    Dim PrimeraVez As Boolean

    Dim uRiesgo As Igis.ucRiesgo
    Dim uComercialesClientes As ucComercialesClientes

    'Dim SentenciaSQL As String
    Dim FiltroBusqueda As String = ""
    Dim TextoInicialBotonBuscar As String = ""
    Dim ColorInicialBotonBuscar As System.Drawing.Color
    Dim CampoInicialBusqueda As String = "Nombre"

    '*********COSAS A CAMBIAR EN NUEVOS MANTENIMIENTOS
    '*************************************************
    '1. TablaMantenimiento
    '2. EN NEW
    '   A. Bindings
    '   B. ConfigurarGrid
    '3. Private Sub PrepararAlta()
    '4. Private Function Actualizar() As Boolean
    '5. Private Function ComprobarDatos() As Boolean
    '****FIN*****COSAS A CAMBIAR EN NUEVOS MANTENIMIENTOS
    '****************************************************

    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub LlenarGrid()

        Cargando = True

       
        'SentenciaSQL = "SELECT Codigo, 	FechaAlta,	 ,	Nombre,	NIF ,	NombreComercial ,	Direccion,	Poblacion,	CodPostal ,	Provincia ,	Pais ,	Telefono1 , " & _
        '              " Telefono2 ,	TelefonoMovil ,	Fax ,	Email ,	Web,	Observaciones,	SerieFacturacionPredeterminada,	IVAPredeterminado,	FormaPagoPredeterminada,	AplicarIVANulo,	AplicarRE, " & _
        '              " Retencion,	BancoPredeterminado,	TarifaPredeterminada,	AlmacenPredeterminado,	FamiliaPredeterminada ,	MarcaPredeterminada ,	EmpleadoPredeterminado,	AgrupacionPredeterminada ,	ComercialPredetermido " & _
        '              " FROM Empresas " & _
        '              " ORDER BY Nombre"



        Dim Tab As New Tablas.clTablaGeneral(TablaMantenimiento)
        bd = New BaseDatos
        Tab.Datos(bd, Tab.ConsultaAEjecutar, , , , , True)

        If PrimeraVez Then
            BinSrc = New BindingSource
        End If
        '   
        BinSrc.DataSource = bd.ds
        BinSrc.DataMember = TablaMantenimiento




        Cargando = False

         
    End Sub
    Private Sub ucConfiguracionEmpresas_Load(sender As Object, e As System.EventArgs) Handles Me.Load


        'Dim FicheroXML As String = "c:\nif.xml"
        ''Pruebas xml 
        'Dim ds As New DataSet
        'Dim dt As DataTable

        'ds.ReadXmlSchema(FicheroXML)
        'ds.ReadXml(FicheroXML)
        'dt = ds.Tables("Info")
        'For Each drr As DataRow In dt.Rows
        '    If drr("Tipo") = Tipo Then
        '        drr("Nombre") = NombrePerfil
        '        ds.AcceptChanges()
        '        ds.WriteXml(FicheroInformacionPerfiles, XmlWriteMode.WriteSchema)

        '    End If
        'Next
        ''Pruebas xml 

        AparienciaGeneral()

        Cargando = True
        PrimeraVez = True
        
        LlenarGrid()

        Cargando = True


        'Bindings

      
        txtCodigo.DataBindings.Add(New Binding("EditValue", BinSrc, "Codigo", True))
        txtCodPostal.DataBindings.Add(New Binding("EditValue", BinSrc, "CodPostal", True))
        txtDireccion.DataBindings.Add(New Binding("EditValue", BinSrc, "Direccion", True))
        txtEmail.DataBindings.Add(New Binding("EditValue", BinSrc, "Email", True))

        txtFax.DataBindings.Add(New Binding("EditValue", BinSrc, "Fax", True))
        txtNIF.DataBindings.Add(New Binding("EditValue", BinSrc, "NIF", True))
        txtNombre.DataBindings.Add(New Binding("EditValue", BinSrc, "Nombre", True))
        txtNombreComercial.DataBindings.Add(New Binding("EditValue", BinSrc, "NombreComercial", True))
        txtObservaciones.DataBindings.Add(New Binding("EditValue", BinSrc, "Observaciones", True))
        txtPais.DataBindings.Add(New Binding("EditValue", BinSrc, "Pais", True))
        txtPoblacion.DataBindings.Add(New Binding("EditValue", BinSrc, "Poblacion", True))
        txtProvincia.DataBindings.Add(New Binding("EditValue", BinSrc, "Provincia", True))
        txtTelefono1.DataBindings.Add(New Binding("EditValue", BinSrc, "Telefono1", True))
        txtTelefono2.DataBindings.Add(New Binding("EditValue", BinSrc, "Telefono2", True))
        txtTelefonoMovil.DataBindings.Add(New Binding("EditValue", BinSrc, "TelefonoMovil", True))
        txtWeb.DataBindings.Add(New Binding("EditValue", BinSrc, "Web", True))

        

        Cargando = False

        HabilitarBotones()
        HabilitarDesHabilitarCajas(False)
 




    End Sub
     
     



    Private Sub MyGridView1_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)

        Try


            Dim View As GridView = sender

            If e.Column.FieldName = "Disponible" Then
                If e.CellValue < 0 Then
                    e.Appearance.BackColor = Color.Salmon
                    e.Appearance.BackColor2 = Color.SeaShell
                    e.Appearance.GradientMode = Drawing2D.LinearGradientMode.BackwardDiagonal
                    'Else
                    '    e.Appearance.BackColor = Color.LightGreen
                    '    e.Appearance.BackColor2 = Color.GreenYellow
                    '    'e.Appearance.BackColor = Color.DeepSkyBlue
                    '    'e.Appearance.BackColor2 = Color.LightCyan

                End If
            End If

        Catch ex As Exception

        End Try


        'If e.Column.FieldName = "BloqueoTemporal" Then
        '    If e.CellValue = True Then
        '        e.Appearance.BackColor = Color.PapayaWhip
        '        e.Appearance.BackColor2 = Color.Orange
        '        e.Appearance.GradientMode = Drawing2D.LinearGradientMode.BackwardDiagonal
        '        'Else
        '        '    e.Appearance.BackColor = Color.LightGreen
        '        '    e.Appearance.BackColor2 = Color.GreenYellow
        '        '    'e.Appearance.BackColor = Color.DeepSkyBlue
        '        '    'e.Appearance.BackColor2 = Color.LightCyan

        '    End If
        'End If

    End Sub










#Region "Mantenimiento Clientes"

    Private Sub btnAnadir_Click(sender As System.Object, e As System.EventArgs) Handles btnAnadir.Click
        Anadir()
    End Sub
 

    Private Sub btnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        Modificar()
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click




        Aceptar()


    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub

    Private Sub Anadir()
        EstoyEnAlta = True
        BinSrc.AddNew()
        PrepararAlta()
    End Sub

    Private Sub Modificar(Optional PonermeEnLaPrimeraColumna As Boolean = True)
 

        EstoyEnAlta = False
        PrepararModificacion()
    End Sub
     
    Private Sub Aceptar()
        '  Dim FilaSeleccionada As Integer = GvClientes.FocusedRowHandle

        Actualizar()

        If Not EstoyEnAlta AndAlso txtCodigo.EditValue = DatosEmpresa.Codigo Then
            FuncionesGenerales.Funciones.CargarDatosEmpresa(DatosEmpresa.Codigo)
        End If

        'GvClientes.FocusedRowHandle = FilaSeleccionada
    End Sub
    Private Sub Cancelar()

        BinSrc.CancelEdit()
        HabilitarBotones()
        HabilitarDesHabilitarCajas(False)
    End Sub
    Private Sub PrepararModificacion()

        HabilitarDesHabilitarCajas(True)


        DesHabilitarBotones()
        txtCodigo.Enabled = False

        txtNombre.Focus()
    End Sub

    Private Sub PrepararAlta()

        HabilitarDesHabilitarCajas(True)

        '   FechaAltaDateEdit.EditValue = Microsoft.VisualBasic.Today 'Microsoft.VisualBasic.Format(Microsoft.VisualBasic.Today, "dd/MM/yyyy")

        txtCodigo.Text = ""
        txtCodigo.Enabled = False
        '     chkBaja.Enabled = False
 
        txtNombreComercial.EditValue = ""

 
 

        txtNombre.Focus()



        'LookUpEditIVA.Properties.NullValuePrompt = LookUpEditIVA.Properties.GetDisplayValueByKeyValue(DatosEmpresa.IVAPrederminado).ToString


        DesHabilitarBotones()
        txtNombre.Focus()
    End Sub
    Private Sub HabilitarDesHabilitarCajas(Habilitar As Boolean)
        For Each c As Control In PanelCajas.Controls
            c.Enabled = Habilitar
        Next

        

    End Sub

    Private Function Actualizar() As Boolean
        Try

            Me.Validate()

            If Not ComprobarDatos() Then
                Return False
            End If

            If EstoyEnAlta Then
                BinSrc.Current("FechaAlta") = Microsoft.VisualBasic.Today
                BinSrc.Current("Agrupacion") = ""
                txtCodigo.EditValue = clGenerales.SiguienteRegistro("Codigo", "Empresas")
            Else
                'If Not Eliminando Then
                '    If Gv.GetFocusedRowCellValue("FuturoCliente") = True And BinSrc.Current("FuturoCliente") = 0 Then
                '        MsgBox("")
                '    End If
                'End If

            End If


            'If BinSrc.Item(BinSrc.Count - 1)("Observaciones") Is DBNull.Value Then
            '    BinSrc.Item(BinSrc.Count - 1)("Observaciones") = ""
            'End If

            BinSrc.EndEdit()

             
            If Not ActualizarBaseDatos() Then
                Return False
            End If
 
            HabilitarBotones()
            HabilitarDesHabilitarCajas(False)
            Return True

        Catch ex As SqlClient.SqlException

            XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'DsClientes.RejectChanges()
            'DsClientes.AcceptChanges()

            Return False

        Catch ex2 As Exception

            XtraMessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'DsClientes.RejectChanges()
            'DsClientes.AcceptChanges()
            Return False

        End Try


    End Function
    Private Function ActualizarBaseDatos() As Boolean

        Try
            bd.ActualizarCambios(TablaMantenimiento, bd.ds)
            'LlenarDataGrid()

            'Cargando = True
            'LlenarDataGrid()
            'Cargando = False

            Return True
        Catch ex As SqlClient.SqlException
            If ex.Number = 2627 Then
                MensajeError(GL_ValorDuplicado)
            Else
                MensajeError(ex.Message)
            End If

            '  bd.ds.RejectChanges()
            Return False
        End Try
    End Function

    Private Function ComprobarDatos() As Boolean
        If txtCodigo.Text.ToString.Trim = "" And Not EstoyEnAlta Then
            MensajeError("El campo código no puede estar vacío")

            txtCodigo.Focus()
            Return False
        End If

        If txtNombre.Text.ToString.Trim = "" Then
            MensajeError("El campo nombre no puede estar vacío")

            txtNombre.Focus()
            Return False
        End If

       

        Return True

    End Function


    Private Sub dgvxClientes_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)

        If e.KeyCode = Keys.Escape And btnAceptar.Enabled = True Then

            Try

                Cancelar()
            Catch ex As Exception

            End Try


            'Try
            '    gvClientes.CancelUpdateCurrentRow()
            '    HabilitarBotones()
            'Catch ex As Exception
            'End Try

            'HabilitarBotones()
        End If

        If e.KeyCode = Keys.F1 And btnAceptar.Enabled = False Then
            Anadir()
            Exit Sub
        End If

        'If e.KeyCode = Keys.F2 And btnAceptar.Enabled = False And XtraTabControl1.SelectedTabPageIndex = 0 Then
        '    Eliminar()
        '    Exit Sub
        'End If

        If e.KeyCode = Keys.F3 And btnAceptar.Enabled = False Then
            Modificar(False)
            Exit Sub
        End If

        If e.KeyCode = Keys.F12 Then
            Aceptar()
            Exit Sub
        End If
    End Sub


    Private Sub HabilitarBotones()


        btnAnadir.Enabled = True
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        If bd.ds.Tables(TablaMantenimiento).Rows.Count > 0 Then
            btnModificar.Enabled = True
            btnEliminar.Enabled = True

        End If

        btnAceptar.Enabled = False
        btnCancelar.Enabled = False
        btnSalir.Enabled = True
 
 

        btnEliminar.Enabled = False

    End Sub

    Private Sub DesHabilitarBotones()

        btnAnadir.Enabled = False
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        btnSalir.Enabled = False
        btnAceptar.Enabled = True
        btnCancelar.Enabled = True
     
    End Sub

#End Region




    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Salir()
    End Sub
    Private Sub Salir()
        Me.ParentForm.Dispose()
    End Sub

   

     

 
   
End Class

 


