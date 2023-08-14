Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors

Public Class tbContextMenuStripComponent

    Inherits ContextMenuStrip
    Dim TodoOculto As Boolean = True
    Dim ReservadoOculto As Boolean = True
    Public Parentt As String = ""

    Friend WithEvents popMenuFiltrarPor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PopMenuFiltrarExcluyendo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents popMenuFiltrarMayorQue As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents popMenuFiltrarMayorOIgualQue As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents popMenuFiltrarMenorQue As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents popMenuFiltrarMenorOIgualQue As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PoPMenuFiltrarSinFiltro As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PoPMenuOcultarColumna As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PoPMenuCongelarColumna As System.Windows.Forms.ToolStripMenuItem

    Friend WithEvents PopMenuExportarExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PopMenuExportar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PopMenuExportarHTML As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PopMenuExportarPDF As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PopMenuExportarExcel2007 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PopMenuExportarExcel2003 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PopMenuCopiarCelda As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PopMenuCopiarFila As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PopMenuGestionDocumental As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PopMenuEscaparate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PopMenuMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PopMenuOcultarTodo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PopMenuPublicarFacebook As System.Windows.Forms.ToolStripMenuItem


    Friend WithEvents PopMenuMapa As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PopMenuReserva As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PopMenuOcultarReservados As System.Windows.Forms.ToolStripMenuItem

    Friend WithEvents PopMenuGuardarSituacionActual As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PopMenuRecuperarSituacionGuardada As System.Windows.Forms.ToolStripMenuItem

    Friend WithEvents PopMenuGuardarDiseno As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PopMenuEstablecerComoPredeterminado As System.Windows.Forms.ToolStripMenuItem


    Friend WithEvents PopMenuPerfiles As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPerfilActual As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparatorPerfil As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuEstablecerPerfilComoPredeterminado As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuGuardarPerfil As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEliminarPerfil As System.Windows.Forms.ToolStripMenuItem


    Friend WithEvents mnuCopiarPerfil As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPerfilPredeterminadoPorDefecto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnucmbPerfiles As System.Windows.Forms.ToolStripComboBox

    Friend WithEvents PopMenuFiltros As System.Windows.Forms.ToolStripMenuItem
    '  Friend WithEvents mnuFiltroActual As System.Windows.Forms.ToolStripTextBox
    ' Friend WithEvents ToolStripSeparatorFiltro As System.Windows.Forms.ToolStripSeparator
    ' Friend WithEvents mnuEstablecerFiltroComoPredeterminado As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuGuardarFiltro As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEliminarFiltro As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCopiarFiltro As System.Windows.Forms.ToolStripMenuItem
    '  Friend WithEvents mnuFiltroPredeterminadoPorDefecto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnucmbFiltros As System.Windows.Forms.ToolStripComboBox

    Friend WithEvents PopMenuDarDeBajaCliente As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PopMenuDarDeBajaInmueble As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PopMenuDuplicarInmueble As System.Windows.Forms.ToolStripMenuItem

    Friend WithEvents PopMenuMostrarColoresInmueble As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PopMenuMostrarPPrincipalWeb As System.Windows.Forms.ToolStripMenuItem

    Friend WithEvents AbrirCarpetaFotos As System.Windows.Forms.ToolStripMenuItem


    Dim grc As MyGridControl
    Dim CarpetaPerfiles As String
    Dim CarpetaFiltros As String
    Dim PerfilActual As String
    Dim FicheroInformacionPerfiles As String
    Dim FicheroInformacionFiltros As String
    Dim cmbPerfilesExterno As DevExpress.XtraEditors.ComboBoxEdit = Nothing
    Dim cmbFiltroExterno As DevExpress.XtraEditors.ComboBoxEdit = Nothing

    Protected Overrides Sub OnOpening(ByVal e As System.ComponentModel.CancelEventArgs)
        grc = Me.SourceControl
        grc.tbCarpetaPerfiles = CarpetaPerfiles


        If InStr(CarpetaPerfiles, "ucInmuebles") > 0 OrElse InStr(CarpetaPerfiles, "ucClientes") > 0 Then
            PopMenuRecuperarSituacionGuardada.Visible = True
            PopMenuGuardarSituacionActual.Visible = True
        Else
            PopMenuRecuperarSituacionGuardada.Visible = False
            PopMenuGuardarSituacionActual.Visible = False
        End If

        Me.mnucmbPerfiles.Text = "Seleccione un perfil"
        mnuPerfilActual.Text = "Perfil Actual: " & RecuperarPredeterminadoOActual("ACTUAL", FicheroInformacionPerfiles)
        CargarPerfiles()

        Me.mnucmbFiltros.Text = "Seleccione un filtro"
        '    mnuFiltroActual.Text = "Filtro Actual: " & RecuperarPredeterminadoOActual("ACTUAL", FicheroInformacionFiltros)
        CargarFiltros()

    End Sub


#Region "Perfiles"

    Sub New(ByVal CarpPerfiles As String, Optional cmbPasadoPerfilesExterno As DevExpress.XtraEditors.ComboBoxEdit = Nothing, Optional cmbPasadoFiltrosExterno As DevExpress.XtraEditors.ComboBoxEdit = Nothing)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()


        cmbPerfilesExterno = cmbPasadoPerfilesExterno
        cmbFiltroExterno = cmbPasadoFiltrosExterno
        '   Dim Predeterminado as   String
        CarpetaPerfiles = CarpPerfiles
        CarpetaFiltros = CarpetaPerfiles & "\" & "Filtros"
        FicheroInformacionPerfiles = CarpetaPerfiles & "\InformacionPerfiles.xml"
        FicheroInformacionFiltros = CarpetaFiltros & "\InformacionFiltros.xml"


        If cmbPerfilesExterno IsNot Nothing Then
            CargarPerfilesEnComboExteriorNuevo()
        End If

        If cmbFiltroExterno IsNot Nothing Then
            CargarFiltrosEnComboExteriorNuevo()
        End If

        'Predeterminado = RecuperarPredeterminadoOActual("PREDETERMINADO")
        'EscribirPredeterminadoOActual(Predeterminado, "ACTUAL")

        'grc = Me.SourceControl

        'If Predeterminado <> "" Then
        '    AplicarPerfil(Predeterminado)
        'End If

        '      RecuperarPerfil(Predeterminado)


        Me.popMenuFiltrarPor = New System.Windows.Forms.ToolStripMenuItem
        Me.PopMenuFiltrarExcluyendo = New System.Windows.Forms.ToolStripMenuItem
        Me.popMenuFiltrarMayorQue = New System.Windows.Forms.ToolStripMenuItem
        Me.popMenuFiltrarMayorOIgualQue = New System.Windows.Forms.ToolStripMenuItem
        Me.popMenuFiltrarMenorQue = New System.Windows.Forms.ToolStripMenuItem
        Me.popMenuFiltrarMenorOIgualQue = New System.Windows.Forms.ToolStripMenuItem
        Me.PoPMenuFiltrarSinFiltro = New System.Windows.Forms.ToolStripMenuItem
        Me.PoPMenuOcultarColumna = New System.Windows.Forms.ToolStripMenuItem
        Me.PoPMenuCongelarColumna = New System.Windows.Forms.ToolStripMenuItem
        Me.PopMenuExportarExcel = New System.Windows.Forms.ToolStripMenuItem
        Me.PopMenuExportar = New System.Windows.Forms.ToolStripMenuItem
        Me.PopMenuExportarHTML = New System.Windows.Forms.ToolStripMenuItem
        Me.PopMenuExportarPDF = New System.Windows.Forms.ToolStripMenuItem
        Me.PopMenuExportarExcel2007 = New System.Windows.Forms.ToolStripMenuItem
        Me.PopMenuExportarExcel2003 = New System.Windows.Forms.ToolStripMenuItem
        Me.PopMenuCopiarCelda = New System.Windows.Forms.ToolStripMenuItem
        Me.PopMenuGuardarSituacionActual = New System.Windows.Forms.ToolStripMenuItem
        Me.PopMenuRecuperarSituacionGuardada = New System.Windows.Forms.ToolStripMenuItem

        Me.PopMenuCopiarFila = New System.Windows.Forms.ToolStripMenuItem
        Me.PopMenuGestionDocumental = New System.Windows.Forms.ToolStripMenuItem
        Me.PopMenuEscaparate = New System.Windows.Forms.ToolStripMenuItem
        Me.PopMenuMostrar = New System.Windows.Forms.ToolStripMenuItem
        Me.PopMenuOcultarTodo = New System.Windows.Forms.ToolStripMenuItem
        Me.PopMenuPublicarFacebook = New System.Windows.Forms.ToolStripMenuItem
        Me.PopMenuOcultarReservados = New System.Windows.Forms.ToolStripMenuItem
        Me.PopMenuMapa = New System.Windows.Forms.ToolStripMenuItem
        Me.PopMenuReserva = New System.Windows.Forms.ToolStripMenuItem


        Me.PopMenuPerfiles = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPerfilActual = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripSeparatorPerfil = New System.Windows.Forms.ToolStripSeparator
        Me.mnuEstablecerPerfilComoPredeterminado = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuGuardarPerfil = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuEliminarPerfil = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuCopiarPerfil = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPerfilPredeterminadoPorDefecto = New System.Windows.Forms.ToolStripMenuItem

        Me.mnucmbPerfiles = New System.Windows.Forms.ToolStripComboBox



        Me.PopMenuFiltros = New System.Windows.Forms.ToolStripMenuItem
        'Me.mnuFiltroActual = New System.Windows.Forms.ToolStripTextBox
        'Me.ToolStripSeparatorFiltro = New System.Windows.Forms.ToolStripSeparator
        'Me.mnuEstablecerFiltroComoPredeterminado = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuGuardarFiltro = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuEliminarFiltro = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuCopiarFiltro = New System.Windows.Forms.ToolStripMenuItem
        '    Me.mnuFiltroPredeterminadoPorDefecto = New System.Windows.Forms.ToolStripMenuItem

        Me.mnucmbFiltros = New System.Windows.Forms.ToolStripComboBox

        Me.PopMenuDarDeBajaCliente = New System.Windows.Forms.ToolStripMenuItem
        Me.PopMenuDarDeBajaInmueble = New System.Windows.Forms.ToolStripMenuItem
        Me.PopMenuDuplicarInmueble = New System.Windows.Forms.ToolStripMenuItem

        Me.PopMenuMostrarColoresInmueble = New System.Windows.Forms.ToolStripMenuItem
        Me.PopMenuMostrarPPrincipalWeb = New System.Windows.Forms.ToolStripMenuItem

        Me.AbrirCarpetaFotos = New System.Windows.Forms.ToolStripMenuItem
        'fitros

        'ContextMenuStrip1
        '
        Me.Items.AddRange(New System.Windows.Forms.ToolStripItem() {
                          Me.PopMenuOcultarReservados,
                          Me.popMenuFiltrarPor,
                          Me.PopMenuFiltrarExcluyendo,
                          Me.popMenuFiltrarMayorQue,
                          Me.popMenuFiltrarMayorOIgualQue,
                          Me.popMenuFiltrarMenorQue,
                          Me.popMenuFiltrarMenorOIgualQue,
                          Me.PoPMenuFiltrarSinFiltro,
                          Me.PoPMenuOcultarColumna,
                          Me.PoPMenuCongelarColumna,
                          Me.PopMenuExportarExcel,
                          Me.PopMenuExportar,
                          Me.PopMenuPerfiles,
                          Me.PopMenuFiltros,
                          Me.PopMenuCopiarCelda,
                          Me.PopMenuCopiarFila,
                          Me.PopMenuGestionDocumental,
                          Me.PopMenuEscaparate,
                          Me.PopMenuMostrar,
                          Me.PopMenuOcultarTodo,
                          Me.PopMenuPublicarFacebook,
                          Me.PopMenuMapa,
                          Me.PopMenuReserva,
                          Me.PopMenuGuardarSituacionActual,
                          Me.PopMenuRecuperarSituacionGuardada,
                          Me.PopMenuDarDeBajaCliente,
                          Me.PopMenuDarDeBajaInmueble,
                          Me.PopMenuDuplicarInmueble,
                          Me.PopMenuMostrarColoresInmueble,
                          Me.PopMenuMostrarPPrincipalWeb,
                          Me.AbrirCarpetaFotos})
        '  Me.Name = "ContextMenuStrip1"
        Me.Size = New System.Drawing.Size(289, 334)
        '
        'popMenuFiltrarPor
        '
        Me.popMenuFiltrarPor.Name = "popMenuFiltrarPor"
        Me.popMenuFiltrarPor.Size = New System.Drawing.Size(288, 22)
        Me.popMenuFiltrarPor.Text = "Filtrar Por"
        Me.popMenuFiltrarPor.Visible = False
        '
        'PopMenuFiltrarExcluyendo
        '
        Me.PopMenuFiltrarExcluyendo.Name = "PopMenuFiltrarExcluyendo"
        Me.PopMenuFiltrarExcluyendo.Size = New System.Drawing.Size(288, 22)
        Me.PopMenuFiltrarExcluyendo.Text = "Filtrar Excluyendo"
        Me.PopMenuFiltrarExcluyendo.Visible = False
        '
        'popMenuFiltrarMayorQue
        '
        Me.popMenuFiltrarMayorQue.Name = "popMenuFiltrarMayorQue"
        Me.popMenuFiltrarMayorQue.Size = New System.Drawing.Size(288, 22)
        Me.popMenuFiltrarMayorQue.Text = "Mayor Que"
        Me.popMenuFiltrarMayorQue.Visible = False
        '
        'popMenuFiltrarMayorOIgualQue
        '
        Me.popMenuFiltrarMayorOIgualQue.Name = "popMenuFiltrarMayorOIgualQue"
        Me.popMenuFiltrarMayorOIgualQue.Size = New System.Drawing.Size(288, 22)
        Me.popMenuFiltrarMayorOIgualQue.Text = "Mayor o Igual Que"
        Me.popMenuFiltrarMayorOIgualQue.Visible = False
        '
        'popMenuFiltrarMenorQue
        '
        Me.popMenuFiltrarMenorQue.Name = "popMenuFiltrarMenorQue"
        Me.popMenuFiltrarMenorQue.Size = New System.Drawing.Size(288, 22)
        Me.popMenuFiltrarMenorQue.Text = "Menor Que"
        Me.popMenuFiltrarMenorQue.Visible = False
        '
        'popMenuFiltrarMenorOIgualQue
        '
        Me.popMenuFiltrarMenorOIgualQue.Name = "popMenuFiltrarMenorOIgualQue"
        Me.popMenuFiltrarMenorOIgualQue.Size = New System.Drawing.Size(288, 22)
        Me.popMenuFiltrarMenorOIgualQue.Text = "Menor o Igual Que"
        Me.popMenuFiltrarMenorOIgualQue.Visible = False
        '
        'PoPMenuFiltrarSinFiltro
        '
        Me.PoPMenuFiltrarSinFiltro.Name = "PoPMenuFiltrarSinFiltro"
        Me.PoPMenuFiltrarSinFiltro.Size = New System.Drawing.Size(288, 22)
        Me.PoPMenuFiltrarSinFiltro.Text = "Quitar Filtro"
        Me.PoPMenuFiltrarSinFiltro.Visible = False
        '
        'PoPMenuOcultarColumna
        '
        Me.PoPMenuOcultarColumna.Name = "PoPMenuOcultarColumna"
        Me.PoPMenuOcultarColumna.Size = New System.Drawing.Size(288, 22)
        Me.PoPMenuOcultarColumna.Text = "Ocultar Columna"
        Me.PoPMenuOcultarColumna.Visible = False
        '
        'PoPMenuCongelarColumna
        '
        Me.PoPMenuCongelarColumna.Name = "PoPMenuCongelarColumna"
        Me.PoPMenuCongelarColumna.Size = New System.Drawing.Size(288, 22)
        Me.PoPMenuCongelarColumna.Text = "Fijar / Liberar Columna"
        Me.PoPMenuCongelarColumna.Visible = False
        '
        'PopMenuExportarExcel
        '
        Me.PopMenuExportarExcel.Name = "PopMenuExportarExcel"
        Me.PopMenuExportarExcel.Size = New System.Drawing.Size(288, 22)
        Me.PopMenuExportarExcel.Text = "Exportar Excel"
        Me.PopMenuExportarExcel.Visible = False
        '
        'PopMenuExportar
        '
        Me.PopMenuExportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PopMenuExportarHTML, Me.PopMenuExportarPDF, Me.PopMenuExportarExcel2007, Me.PopMenuExportarExcel2003})
        Me.PopMenuExportar.Name = "PopMenuExportar"
        Me.PopMenuExportar.Size = New System.Drawing.Size(288, 22)
        Me.PopMenuExportar.Text = "Exportar"
        '
        'PopMenuExportarHTML
        '
        Me.PopMenuExportarHTML.Name = "PopMenuExportarHTML"
        Me.PopMenuExportarHTML.Size = New System.Drawing.Size(127, 22)
        Me.PopMenuExportarHTML.Text = "HTML"
        '
        'PopMenuExportarPDF
        '
        Me.PopMenuExportarPDF.Name = "PopMenuExportarPDF"
        Me.PopMenuExportarPDF.Size = New System.Drawing.Size(127, 22)
        Me.PopMenuExportarPDF.Text = "PDF"
        '
        'PopMenuExportarExcel2007
        '
        Me.PopMenuExportarExcel2007.Name = "PopMenuExportarExcel2007"
        Me.PopMenuExportarExcel2007.Size = New System.Drawing.Size(127, 22)
        Me.PopMenuExportarExcel2007.Text = "Excel"
        '
        'PopMenuExportarExcel2003
        '
        Me.PopMenuExportarExcel2003.Name = "PopMenuExportarExcel2003"
        Me.PopMenuExportarExcel2003.Size = New System.Drawing.Size(127, 22)
        Me.PopMenuExportarExcel2003.Text = "Excel 2003"
        '

        '
        'PopMenuCopiarCelda
        '
        Me.PopMenuCopiarCelda.Name = "PopMenuCopiarCelda"
        Me.PopMenuCopiarCelda.Size = New System.Drawing.Size(288, 22)
        Me.PopMenuCopiarCelda.Text = "Copiar Celda"


        '

        'PopMenuGuardarSituacionActual
        '
        Me.PopMenuGuardarSituacionActual.Name = "PopMenuGuardarSituacionActual"
        Me.PopMenuGuardarSituacionActual.Size = New System.Drawing.Size(288, 22)
        Me.PopMenuGuardarSituacionActual.Text = "Guardar Situacion Actual"

        'PopMenuRecuperarSituacionGuardada
        '
        Me.PopMenuRecuperarSituacionGuardada.Name = "PopMenuRecuperarSituacionGuardada"
        Me.PopMenuRecuperarSituacionGuardada.Size = New System.Drawing.Size(288, 22)
        Me.PopMenuRecuperarSituacionGuardada.Text = "Recuperar Situacion Guardada"

        'PopMenuCopiarFila
        '
        Me.PopMenuCopiarFila.Name = "PopMenuCopiarFila"
        Me.PopMenuCopiarFila.Size = New System.Drawing.Size(288, 22)
        Me.PopMenuCopiarFila.Text = "Copiar Fila"

        'PopMenuGestionDocumental
        '
        Me.PopMenuGestionDocumental.Name = "PopMenuGestionDocumental"
        Me.PopMenuGestionDocumental.Size = New System.Drawing.Size(288, 22)
        Me.PopMenuGestionDocumental.Text = "Gestión Documental"
        Me.PopMenuGestionDocumental.Visible = False

        'PopMenuEscaparate
        '
        Me.PopMenuEscaparate.Name = "PopMenuEscaparate"
        Me.PopMenuEscaparate.Size = New System.Drawing.Size(288, 22)
        Me.PopMenuEscaparate.Text = "Escaparate"
        Me.PopMenuEscaparate.Visible = False

        'PopMenuMostrar
        '
        Me.PopMenuMostrar.Name = "PopMenuMostrar"
        Me.PopMenuMostrar.Size = New System.Drawing.Size(288, 22)
        Me.PopMenuMostrar.Text = "Mostrar Este"
        Me.PopMenuMostrar.Visible = False

        'PopMenuMapa
        '
        Me.PopMenuMapa.Name = "PopMenuMapa"
        Me.PopMenuMapa.Size = New System.Drawing.Size(288, 22)
        Me.PopMenuMapa.Text = "Mapa"
        Me.PopMenuMapa.Visible = False

        'PopMenuReserva
        '
        Me.PopMenuReserva.Name = "PopMenuReserva"
        Me.PopMenuReserva.Size = New System.Drawing.Size(288, 22)
        Me.PopMenuReserva.Text = "Reserva"
        Me.PopMenuReserva.Visible = False

        'PopMenuOcultarTodo
        '
        Me.PopMenuOcultarTodo.Name = "PopMenuOcultarTodo"
        Me.PopMenuOcultarTodo.Size = New System.Drawing.Size(288, 22)
        Me.PopMenuOcultarTodo.Text = "Ocultar Todo"
        Me.PopMenuOcultarTodo.Visible = False

        'PopMenuPublicarFacebook
        '
        Me.PopMenuPublicarFacebook.Name = "PopMenuPublicarFacebook"
        Me.PopMenuPublicarFacebook.Size = New System.Drawing.Size(288, 22)
        Me.PopMenuPublicarFacebook.Text = "Publicar en Facebook"
        Me.PopMenuPublicarFacebook.Visible = False

        'PopMenuOcultarReservados
        '
        Me.PopMenuOcultarReservados.Name = "PopMenuOcultarReservados"
        Me.PopMenuOcultarReservados.Size = New System.Drawing.Size(288, 22)
        Me.PopMenuOcultarReservados.Text = "Ocultar Reservados"
        Me.PopMenuOcultarReservados.Visible = False

        'PopMenuPerfiles
        '
        Me.PopMenuPerfiles.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPerfilActual, Me.ToolStripSeparatorPerfil, Me.mnuEstablecerPerfilComoPredeterminado, Me.mnuGuardarPerfil, Me.mnuPerfilPredeterminadoPorDefecto, Me.mnucmbPerfiles, Me.mnuCopiarPerfil, Me.mnuEliminarPerfil})
        Me.PopMenuPerfiles.Name = "PopMenuPerfiles"
        Me.PopMenuPerfiles.Size = New System.Drawing.Size(181, 22)
        Me.PopMenuPerfiles.Text = "Perfiles"
        '
        'mnuPerfilActual
        '
        Me.mnuPerfilActual.Name = "mnuPerfilActual"
        'Me.mnuPerfilActual.  Size = new  System.Drawing.Size(180, 23)
        Me.mnuPerfilActual.Size = New System.Drawing.Size(Me.Width, 23)
        Me.mnuPerfilActual.Text = "Perfil Actual: "
        'Me.mnuPerfilActual.ReadOnly = True
        Me.mnuPerfilActual.Enabled = False
        '
        'ToolStripSeparatorPerfil
        '
        Me.ToolStripSeparatorPerfil.Name = "ToolStripSeparatorPerfil"
        Me.ToolStripSeparatorPerfil.Size = New System.Drawing.Size(285, 6)
        '
        'mnuEstablecerPerfilComoPredeterminado
        '
        Me.mnuEstablecerPerfilComoPredeterminado.Name = "mnuEstablecerPerfilComoPredeterminado"
        Me.mnuEstablecerPerfilComoPredeterminado.Size = New System.Drawing.Size(288, 22)
        Me.mnuEstablecerPerfilComoPredeterminado.Text = "Establecer Actual Como Predeterminado"
        '
        'mnuGuardarPerfil
        '
        Me.mnuGuardarPerfil.Name = "mnuGuardarPerfil"
        Me.mnuGuardarPerfil.Size = New System.Drawing.Size(288, 22)
        Me.mnuGuardarPerfil.Text = "Guardar Perfil"


        'mnuGuardarFiltro
        '
        Me.mnuEliminarPerfil.Name = "mnuEliminarPerfil"
        Me.mnuEliminarPerfil.Size = New System.Drawing.Size(288, 22)
        Me.mnuEliminarPerfil.Text = "Eliminar Perfil"

        'mnuPerfilPredeterminadoPorDefecto
        '
        Me.mnuPerfilPredeterminadoPorDefecto.Name = "mnuPerfilPredeterminadoPorDefecto"
        Me.mnuPerfilPredeterminadoPorDefecto.Size = New System.Drawing.Size(288, 22)
        Me.mnuPerfilPredeterminadoPorDefecto.Text = "Establecer como Predeterminado valores por defecto"

        'mnuCopiarPerfil
        Me.mnuCopiarPerfil.Name = "mnuCopiarPerfil"
        Me.mnuCopiarPerfil.Size = New System.Drawing.Size(288, 22)
        Me.mnuCopiarPerfil.Text = "Copiar Perfiles"

        '
        'mnucmbPerfiles
        '
        Me.mnucmbPerfiles.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.mnucmbPerfiles.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.mnucmbPerfiles.Name = "mnucmbPerfiles"
        'Me.mnucmbPerfiles.  Size = new  System.Drawing.Size(150, 23)
        Me.mnucmbPerfiles.Size = New System.Drawing.Size(Me.Width, 23)
        ' Me.mnucmbPerfiles.AutoSize = True
        Me.mnucmbPerfiles.Sorted = True
        Me.mnucmbPerfiles.Text = "Seleccione un perfil"




        '****************
        'PopMenuFiltros
        '
        'Me.PopMenuFiltros.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFiltroActual, Me.ToolStripSeparatorFiltro, Me.mnuEstablecerFiltroComoPredeterminado, Me.mnuGuardarFiltro, Me.mnuFiltroPredeterminadoPorDefecto, Me.mnucmbFiltros, Me.mnuCopiarFiltro})
        Me.PopMenuFiltros.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuGuardarFiltro, Me.mnucmbFiltros, Me.mnuCopiarFiltro, Me.mnuEliminarFiltro})
        Me.PopMenuFiltros.Name = "PopMenuFiltros"
        Me.PopMenuFiltros.Size = New System.Drawing.Size(181, 22)
        Me.PopMenuFiltros.Text = "Filtros"
        '
        ''mnuFiltroActual
        ''
        'Me.mnuFiltroActual.Name = "mnuFiltroActual"
        ''Me.mnuFiltroActual.  Size = new  System.Drawing.Size(180, 23)
        'Me.mnuFiltroActual.Size = New System.Drawing.Size(Me.Width, 23)
        'Me.mnuFiltroActual.Text = "Filtro Actual: "
        ''Me.mnuFiltroActual.ReadOnly = True
        'Me.mnuFiltroActual.Enabled = False
        ''
        ''ToolStripSeparatorFiltro
        ''
        'Me.ToolStripSeparatorFiltro.Name = "ToolStripSeparatorFiltro"
        'Me.ToolStripSeparatorFiltro.Size = New System.Drawing.Size(285, 6)
        ''
        ''mnuEstablecerFiltroComoPredeterminado
        ''
        'Me.mnuEstablecerFiltroComoPredeterminado.Name = "mnuEstablecerFiltroComoPredeterminado"
        'Me.mnuEstablecerFiltroComoPredeterminado.Size = New System.Drawing.Size(288, 22)
        'Me.mnuEstablecerFiltroComoPredeterminado.Text = "Establecer Actual Como Predeterminado"
        '
        'mnuGuardarFiltro
        '
        Me.mnuGuardarFiltro.Name = "mnuGuardarFiltro"
        Me.mnuGuardarFiltro.Size = New System.Drawing.Size(288, 22)
        Me.mnuGuardarFiltro.Text = "Guardar Filtro"


        'mnuGuardarFiltro
        '
        Me.mnuEliminarFiltro.Name = "mnuEliminarFiltro"
        Me.mnuEliminarFiltro.Size = New System.Drawing.Size(288, 22)
        Me.mnuEliminarFiltro.Text = "Eliminar Filtro"
        ''mnuFiltroPredeterminadoPorDefecto
        ''
        'Me.mnuFiltroPredeterminadoPorDefecto.Name = "mnuFiltroPredeterminadoPorDefecto"
        'Me.mnuFiltroPredeterminadoPorDefecto.Size = New System.Drawing.Size(288, 22)
        'Me.mnuFiltroPredeterminadoPorDefecto.Text = "Establecer como Predeterminado valores por defecto"

        'mnuCopiarFiltro
        Me.mnuCopiarFiltro.Name = "mnuCopiarFiltro"
        Me.mnuCopiarFiltro.Size = New System.Drawing.Size(288, 22)
        Me.mnuCopiarFiltro.Text = "Copiar Filtros"
        '
        'PopMenuDarDeBajaCliente
        '
        Me.PopMenuDarDeBajaCliente.Name = "PopMenuDarDeBajaCliente"
        Me.PopMenuDarDeBajaCliente.Size = New System.Drawing.Size(288, 22)
        Me.PopMenuDarDeBajaCliente.Text = "Dar de Baja Cliente"
        Me.PopMenuDarDeBajaCliente.Visible = False
        '
        'PopMenuDarDeBajaInmueble
        '
        Me.PopMenuDarDeBajaInmueble.Name = "PopMenuDarDeBajaInmueble"
        Me.PopMenuDarDeBajaInmueble.Size = New System.Drawing.Size(288, 22)
        Me.PopMenuDarDeBajaInmueble.Text = "Dar de Baja Inmueble"
        Me.PopMenuDarDeBajaInmueble.Visible = False
        '
        'PopMenuDuplicarInmueble
        '
        Me.PopMenuDuplicarInmueble.Name = "PopMenuDuplicarInmueble"
        Me.PopMenuDuplicarInmueble.Size = New System.Drawing.Size(288, 22)
        Me.PopMenuDuplicarInmueble.Text = "Duplicar Inmueble"
        Me.PopMenuDuplicarInmueble.Visible = False
        '
        'PopMenuMostrarColoresInmueble
        '
        Me.PopMenuMostrarColoresInmueble.Name = "PopMenuMostrarColoresInmueble"
        Me.PopMenuMostrarColoresInmueble.Size = New System.Drawing.Size(288, 22)
        Me.PopMenuMostrarColoresInmueble.Text = "Mostrar Colores en este Inmueble"
        Me.PopMenuMostrarColoresInmueble.Visible = False
        '
        'PopMenuMostrarPPrincipalWeb
        '
        Me.PopMenuMostrarPPrincipalWeb.Name = "PopMenuMostrarPPrincipalWeb"
        Me.PopMenuMostrarPPrincipalWeb.Size = New System.Drawing.Size(288, 22)
        Me.PopMenuMostrarPPrincipalWeb.Text = "Mostrar en la Pantalla Principal de la Web"
        Me.PopMenuMostrarPPrincipalWeb.Visible = False
        '
        'AbrirCarpetaFotos
        '
        Me.AbrirCarpetaFotos.Name = "AbrirCarpetaFotos"
        Me.AbrirCarpetaFotos.Size = New System.Drawing.Size(288, 22)
        Me.AbrirCarpetaFotos.Text = "Abrir la Carpeta de las Fotos del inmueble"
        Me.AbrirCarpetaFotos.Visible = False

        '
        'mnucmbFiltros
        '
        Me.mnucmbFiltros.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.mnucmbFiltros.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.mnucmbFiltros.Name = "mnucmbFiltros"
        'Me.mnucmbFiltros.  Size = new  System.Drawing.Size(150, 23)
        Me.mnucmbFiltros.Size = New System.Drawing.Size(Me.Width, 23)
        ' Me.mnucmbFiltros.AutoSize = True
        Me.mnucmbFiltros.Sorted = True
        Me.mnucmbFiltros.Text = "Seleccione un Filtro"
        '
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Function RecuperarPredeterminadoOActual(ByVal Tipo As String, Fichero As String) As String


        If Not System.IO.File.Exists(Fichero) Then
            Return ""
        End If

        Dim Predeterminado As String = ""
        Dim dt As DataTable
        Dim ds As New DataSet
        ds.ReadXmlSchema(Fichero)
        ds.ReadXml(Fichero)
        dt = ds.Tables("Info")
        For Each drr As DataRow In dt.Rows
            If drr("Tipo") = Tipo Then
                Predeterminado = drr("Nombre")
            End If
        Next

        Return Predeterminado

    End Function

    Private Sub EscribirPredeterminadoOActual(ByVal NombrePerfil As String, ByVal Tipo As String, Optional ByVal ValoresPorDefecto As Boolean = False)

        If Tipo = "PREDETERMINADO" AndAlso NombrePerfil = "" AndAlso Not ValoresPorDefecto Then
            MessageBox.Show("Debe guardar el perfil con un nombre para establecerlo como predeterminado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If Not ValoresPorDefecto Then
            If Not System.IO.File.Exists(FicheroInformacionPerfiles) Then
                If Tipo = "PREDETERMINADO" Then
                    ComprobarYCrearCarpetas(CarpetaPerfiles)
                    System.IO.File.Copy(My.Application.Info.DirectoryPath & "\InformacionPerfiles.xml", FicheroInformacionPerfiles)
                Else
                    Exit Sub
                End If

            End If
        End If

        If Not IO.File.Exists(FicheroInformacionPerfiles) Then
            Exit Sub
        End If

        Dim dt As DataTable
        '  Dim dr as   DataRow

        Dim ds As New DataSet
        ds.ReadXmlSchema(FicheroInformacionPerfiles)
        ds.ReadXml(FicheroInformacionPerfiles)
        dt = ds.Tables("Info")
        For Each drr As DataRow In dt.Rows
            If drr("Tipo") = Tipo Then
                drr("Nombre") = NombrePerfil
                ds.AcceptChanges()
                ds.WriteXml(FicheroInformacionPerfiles, XmlWriteMode.WriteSchema)

            End If
        Next

        If Tipo = "PREDETERMINADO" Then
            If ValoresPorDefecto Then
                MessageBox.Show("Debe salir y volver a entrar en la pantalla para completar los cambios.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Diseño establecido como predeterminado correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        End If


        If Tipo = "ACTUAL" Then
            Try
                mnuPerfilActual.Text = "Perfil Actual: " & NombrePerfil

            Catch ex As Exception

            End Try
        End If


    End Sub
    Private Sub mnucmbPerfiles_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnucmbPerfiles.SelectedIndexChanged

        Dim NombrePerfil As String = mnucmbPerfiles.Text
        '    grc.tbRecuperarPerfil(NombrePerfil)
        AplicarPerfil(NombrePerfil)

    End Sub

    Public Function AplicarPerfil(NombrePerfil As String, Optional GridControlPasado As MyGridControl = Nothing) As Boolean






        If Len(NombrePerfil) > 16 Then
            If Microsoft.VisualBasic.Right(NombrePerfil, 16).ToUpper = "(PREDETERMINADO)" Then
                NombrePerfil = Microsoft.VisualBasic.Left(NombrePerfil, Len(NombrePerfil) - 16)
            End If
        End If


        If Not System.IO.File.Exists(CarpetaPerfiles & "\" & NombrePerfil & ".xml") Then
            MessageBox.Show("El perfil seleccionado ya no existe", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Try
            Dim Resultado As Boolean
            Resultado = RecuperarPerfil(NombrePerfil, GridControlPasado)



            Me.Close()
            Return Resultado

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function
    Private Function RecuperarPerfil(ByVal NombrePerfil As String, Optional GridControlPasado As MyGridControl = Nothing) As Boolean

        Try
            Dim g As MyGridView
            If GridControlPasado Is Nothing Then
                g = grc.MainView
            Else
                g = GridControlPasado.MainView
            End If

            Dim FiltroAnteriorCriteria As DevExpress.Data.Filtering.CriteriaOperator
            FiltroAnteriorCriteria = g.ActiveFilterCriteria


            Try

                If Not IsNothing(grc) Then
                    If Not IsNothing(grc.ColumnaCheck) Then
                        If Not IsNothing(grc.ColumnaCheck.View) Then
                            grc.ColumnaCheck.View = Nothing
                        End If
                    End If
                End If

            Catch ex As Exception

            End Try


            If Not System.IO.File.Exists(CarpetaPerfiles & "\" & NombrePerfil & ".xml") Then

                If NombrePerfil = PerfilSituacionActual Then
                    MensajeError("No hay situaciones almacenadas.")
                Else
                    MensajeError("No se puede recuperar el perfil solicitado")
                End If

                Return False
            End If

            g.RestoreLayoutFromXml(CarpetaPerfiles & "\" & NombrePerfil & ".xml", DevExpress.Utils.OptionsLayoutBase.FullLayout)


            Try
                If Not IsNothing(grc) Then
                    If grc.tb_AnadirColumnaCheck = True Then
                        grc.AnadirColumnaCheck()
                    End If
                End If


            Catch ex As Exception

            End Try



            If IsNothing(g.ActiveFilterCriteria) AndAlso Not IsNothing(FiltroAnteriorCriteria) Then
                g.ActiveFilterCriteria = FiltroAnteriorCriteria
            End If

            If NombrePerfil <> PerfilSituacionActual Then
                EscribirPredeterminadoOActual(NombrePerfil, "ACTUAL")
            Else

                'Dim Sel As String = "SELECT "& Funciones.SQL_CASE_ISNULL("Contador,0") & " AS Conta FROM SituacionActualContadores WHERE REPLACE(RutaCompleta,'/','\') = '" & Replace(Funciones.pf_ReplaceComillas(CarpetaPerfiles & "\" & NombrePerfil & ".xml", "/", "\"))) & "'"
                'Dim Sel As String = "SELECT " & Funciones.SQL_CASE_ISNULL("Contador,0") & " AS Conta FROM SituacionActualContadores WHERE REPLACE(RutaCompleta,'/','\') = '" & Replace(Funciones.pf_ReplaceComillas(CarpetaPerfiles & "\" & NombrePerfil & ".xml"), "/", "\") & "'"
                Dim Sel As String = "SELECT " & Funciones.SQL_CASE_ISNULL("Contador,0") & " AS Conta FROM SituacionActualContadores WHERE RutaCompleta = '" & Funciones.pf_ReplaceComillas(CarpetaPerfiles & "/" & NombrePerfil & ".xml") & "'"
                Dim Conta As Integer = BD_CERO.Execute(Sel, False)

                SituarseEnGrid(g, Conta, "Contador")

            End If

            For Each dc In g.Columns
                Select Case dc.ColumnType.Name
                    Case "Boolean"
                        dc.ColumnEdit = g.GridControl.RepositoryItems("tbRichk")
                    Case "Byte"
                        dc.ColumnEdit = g.GridControl.RepositoryItems("tbRichk2")
                End Select
            Next
        Catch ex As Exception

        End Try
       
        'Try
        '    grc.tbRecuperarPerfil(NombrePerfil)
        '    Return True
        ' Catch ex as Exception
        '    MensajeError(ex.Message)
        '    Return False
        'End Try


    End Function

    Private Sub CargarPerfiles()

        If Not System.IO.Directory.Exists(CarpetaPerfiles) Then
            Exit Sub
        End If

        Dim Predeterminado As String = RecuperarPredeterminadoOActual("PREDETERMINADO", FicheroInformacionPerfiles)

        Dim Ficheros As String()

        mnucmbPerfiles.Items.Clear()
        ' mnucmbPerfiles.Items.Add("")

        Ficheros = System.IO.Directory.GetFiles(CarpetaPerfiles, "*.xml")
        For Each Fich In Ficheros
            If Fich <> "InformacionPerfiles" Then
                Select Case System.IO.Path.GetFileNameWithoutExtension(Fich)
                    Case Predeterminado
                        mnucmbPerfiles.Items.Add(System.IO.Path.GetFileNameWithoutExtension(Fich).ToString & "(Predeterminado)")
                    Case "InformacionPerfiles"
                    Case PerfilSituacionActual
                    Case Else
                        mnucmbPerfiles.Items.Add(System.IO.Path.GetFileNameWithoutExtension(Fich))
                End Select
            End If
        Next


        If cmbPerfilesExterno IsNot Nothing Then
            CargarPerfilesEnComboExteriorNuevo()
        End If



    End Sub

    Private Sub CargarPerfilesEnComboExteriorNuevo()

        If Not System.IO.Directory.Exists(CarpetaPerfiles) Then
            Exit Sub
        End If

        Dim Predeterminado As String = RecuperarPredeterminadoOActual("PREDETERMINADO", FicheroInformacionPerfiles)

        Dim Ficheros As String()

        cmbPerfilesExterno.Properties.Items.Clear()
        ' cmbPerfilesExterno.Items.Add("")

        Ficheros = System.IO.Directory.GetFiles(CarpetaPerfiles, "*.xml")
        For Each Fich In Ficheros
            If Fich <> "InformacionPerfiles" Then
                Select Case System.IO.Path.GetFileNameWithoutExtension(Fich)
                    Case Predeterminado
                        cmbPerfilesExterno.Properties.Items.Add(System.IO.Path.GetFileNameWithoutExtension(Fich).ToString & "(Predeterminado)")
                    Case "InformacionPerfiles"
                    Case PerfilSituacionActual

                    Case Else
                        cmbPerfilesExterno.Properties.Items.Add(System.IO.Path.GetFileNameWithoutExtension(Fich))
                End Select
            End If
        Next


    End Sub

    Private Sub mnuEstablecerPerfilComoPredeterminado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEstablecerPerfilComoPredeterminado.Click
        EscribirPredeterminadoOActual(RecuperarPredeterminadoOActual("ACTUAL", FicheroInformacionPerfiles), "PREDETERMINADO")
    End Sub

    Private Sub mnuPerfilPredeterminadoPorDefecto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPerfilPredeterminadoPorDefecto.Click
        EscribirPredeterminadoOActual("", "PREDETERMINADO", True)
    End Sub
    Public Sub GuardarPerfilActual(g As GridView, Perfil As String)
        Try
            Dim RutaCompleta As String
            If Perfil = "" Or Perfil = Gl_ResultadoBusqueda_SALIR Then
                Exit Sub
            End If
            ComprobarYCrearCarpetas(CarpetaPerfiles)
            RutaCompleta = CarpetaPerfiles & "/" & Perfil & ".xml"
            g.SaveLayoutToXml(RutaCompleta, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            EscribirPredeterminadoOActual(Perfil, "ACTUAL")
            'MessageBox.Show("Diseño guardado correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            'MessageBox.Show("Error al guardar el diseño.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GuardarSituacionActual()
        Try

            If MessageBox.Show("¿Confirma que quiere guardar la situación actual?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
                Exit Sub
            End If

            Dim g As MyGridView
            g = grc.MainView

            Dim Perfil As String
            Perfil = PerfilSituacionActual

            Dim RutaCompleta As String
            If Perfil = "" Or Perfil = Gl_ResultadoBusqueda_SALIR Then
                Exit Sub
            End If

            Dim columnacheck As Boolean = False
            If Not g.Columns("CheckMarkSelection") Is Nothing Then
                columnacheck = True
            End If
            ComprobarYCrearCarpetas(CarpetaPerfiles)
            RutaCompleta = CarpetaPerfiles & "/" & Perfil & ".xml"
            Try

                If Not IsNothing(grc.ColumnaCheck) Then
                    If Not IsNothing(grc.ColumnaCheck.View) Then
                        grc.ColumnaCheck.View = Nothing
                    End If
                End If
            Catch ex As Exception

            End Try

            Dim Conta As Integer = g.GetDataRow(g.FocusedRowHandle).Item("Contador")

            Dim Sel As String = ""

            Sel = "" & GL_SQL_DELETE & "FROM SituacionActualContadores WHERE RutaCompleta = '" & Funciones.pf_ReplaceComillas(RutaCompleta) & "'"
            BD_CERO.Execute(Sel)

            Sel = "INSERT INTO SituacionActualContadores (Contador, RutaCompleta) VALUES (" & Conta & ", '" & RutaCompleta & "')"
            BD_CERO.Execute(Sel)

            g.SaveLayoutToXml(RutaCompleta, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            '  EscribirPredeterminadoOActual(Perfil, "ACTUAL")
            'MessageBox.Show("Diseño guardado correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If columnacheck Then
                Try
                    grc.tb_AnadirColumnaCheck = True
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            'MessageBox.Show("Error al guardar el diseño.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub mnuGuardarPerfil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGuardarPerfil.Click

        'Try
        '    grc.tbGuardarPerfil()
        ' Catch ex as Exception

        'End Try

        Try

            Dim NombreDiseño As String
            Dim RutaCompleta As String

            Dim f As New tbImputBox("Introduzca el nombre con el que quiere guardar el perfil")
            f.ShowDialog()
            NombreDiseño = Gl_ResultadoBusqueda

            If NombreDiseño = "" Or NombreDiseño = Gl_ResultadoBusqueda_SALIR Then
                Exit Sub
            End If

            '   MsgBox(CarpetaPerfiles)
            ComprobarYCrearCarpetas(CarpetaPerfiles)
            RutaCompleta = CarpetaPerfiles & "/" & NombreDiseño & ".xml"

            If System.IO.File.Exists(RutaCompleta) Then
                If MessageBox.Show("Ya existe un diseño con ese nombre." & vbCrLf & "¿Desea reemplazar el diseño?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then
                    Exit Sub
                End If
            End If


            Dim g As MyGridView
            g = grc.MainView

            Try

                If Not IsNothing(grc.ColumnaCheck) Then
                    If Not IsNothing(grc.ColumnaCheck.View) Then
                        grc.ColumnaCheck.View = Nothing
                    End If
                End If
            Catch ex As Exception

            End Try

            '      ColumnaCheck.View = Nothing
            g.SaveLayoutToXml(RutaCompleta, DevExpress.Utils.OptionsLayoutBase.FullLayout)

            Try
                If grc.tb_AnadirColumnaCheck = True Then
                    grc.AnadirColumnaCheck()
                End If

            Catch ex As Exception

            End Try

            '    ColumnaCheck as  GridCheckMarksSelection(g)

            CargarPerfiles()
            '   cmbVistas.Text = NombreDiseño

            If Not System.IO.File.Exists(FicheroInformacionPerfiles) Then
                ComprobarYCrearCarpetas(CarpetaPerfiles)
                System.IO.File.Copy(My.Application.Info.DirectoryPath & "\InformacionPerfiles.xml", FicheroInformacionPerfiles)
            End If

            EscribirPredeterminadoOActual(NombreDiseño, "ACTUAL")

            MessageBox.Show("Diseño guardado correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)



        Catch ex As Exception
            MessageBox.Show("Error al guardar el diseño.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Private Sub mnuEliminarPerfil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEliminarPerfil.Click

        Try

            Dim Fichero As String = FicheroInformacionPerfiles

            Dim NombreDiseño As String


            Dim f As New tbImputBox("Introduzca el nombre del Perfil que quiere eliminar")
            f.ShowDialog()
            NombreDiseño = Gl_ResultadoBusqueda

            If NombreDiseño = "" Or NombreDiseño = Gl_ResultadoBusqueda_SALIR Then
                Exit Sub
            End If


            If Not System.IO.File.Exists(Fichero) Then
                MsgBox("No existe el Perfil que quiere eliminar")
                Exit Sub
            End If


            Dim dt As DataTable
            '  Dim dr as   DataRow

            Dim ds As New DataSet

            ds.ReadXmlSchema(Fichero)
            ds.ReadXml(Fichero)
            dt = ds.Tables("Info")

            Dim PerfilEncontrado As Boolean = False

            For Each drr As DataRow In dt.Rows
                If drr("Nombre") = NombreDiseño Then
                    PerfilEncontrado = True
                    dt.Rows.Remove(drr)
                    Exit For
                End If
            Next

            If Not PerfilEncontrado Then
                MsgBox("No existe el Perfil que quiere eliminar")
                Exit Sub
            End If

            ds.AcceptChanges()
            ds.WriteXml(Fichero, XmlWriteMode.WriteSchema)
            ds = Nothing

            CargarPerfiles()


            MessageBox.Show("Perfil eliminado correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)


        Catch ex As Exception
            MessageBox.Show("Error al eliminado el Perfil.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Private Sub mnuCopiarPerfil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCopiarPerfil.Click

        ''Dim sen as   New ToolStripMenuItem
        ''sen = TryCast(sender, ToolStripMenuItem)
        'Dim frm as   New frmCopiarPerfiles
        '' frm.lbldgvxABuscar.Text = Me.Name & "/dgvx"
        'frm.lbldgvxABuscar.Text = "/dgvx"
        'frm.ShowDialog()



        Dim f As New DevExpress.XtraEditors.XtraForm

        f.SuspendLayout()
        '
        'form2
        '
        f.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        f.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        f.ClientSize = New System.Drawing.Size(658, 262)
        f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        'f.Name = "form2"
        'f.Text = "form2"
        f.ResumeLayout(False)


        f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Dim uc As New ucCopiarPerfiles(CarpetaPerfiles, "PERFILES")
        uc.Dock = System.Windows.Forms.DockStyle.Fill
        f.Controls.Add(uc)
        f.StartPosition = FormStartPosition.CenterScreen
        f.ControlBox = False

        Dim Texto As String = ""

        f.Text = Texto

        f.ShowDialog()
        f.Dispose()
    End Sub

#End Region

#Region "Filtros"

    Private Sub mnuEliminarFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEliminarFiltro.Click


        Try

            Dim Fichero As String = FicheroInformacionFiltros

            Dim NombreDiseño As String


            Dim f As New tbImputBox("Introduzca el nombre del Filtro que quiere eliminar")
            f.ShowDialog()
            NombreDiseño = Gl_ResultadoBusqueda

            If NombreDiseño = "" Or NombreDiseño = Gl_ResultadoBusqueda_SALIR Then
                Exit Sub
            End If


            If Not System.IO.File.Exists(Fichero) Then
                MsgBox("No existe el filtro que quiere eliminar")
                Exit Sub
            End If


            Dim dt As DataTable
            '  Dim dr as   DataRow

            Dim ds As New DataSet

            ds.ReadXmlSchema(Fichero)
            ds.ReadXml(Fichero)
            dt = ds.Tables("Info")

            Dim FiltroEncontrado As Boolean = False

            For Each drr As DataRow In dt.Rows
                If drr("Nombre") = NombreDiseño Then
                    FiltroEncontrado = True
                    dt.Rows.Remove(drr)
                    Exit For
                End If
            Next

            If Not FiltroEncontrado Then
                MsgBox("No existe el filtro que quiere eliminar")
                Exit Sub
            End If

            ds.AcceptChanges()
            ds.WriteXml(Fichero, XmlWriteMode.WriteSchema)
            ds = Nothing

            CargarFiltros()


            If cmbFiltroExterno IsNot Nothing Then
                cmbFiltroExterno.Text = ""
            End If

            MessageBox.Show("Filtro eliminado correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)


        Catch ex As Exception
            MessageBox.Show("Error al eliminado el Filtro.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub mnuGuardarFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGuardarFiltro.Click

        
        Try

            Dim Fichero As String = FicheroInformacionFiltros


            Dim g As MyGridView
            g = grc.MainView

            If IsNothing(g.ActiveFilterCriteria) Then
                MensajeError("No hay ningún filtro para guardar")
                Exit Sub
            End If

            Dim NombreDiseño As String


            Dim f As New tbImputBox("Introduzca el nombre con el que quiere guardar el Filtro")
            f.ShowDialog()
            NombreDiseño = Gl_ResultadoBusqueda

            If NombreDiseño = "" Or NombreDiseño = Gl_ResultadoBusqueda_SALIR Then
                Exit Sub
            End If


            If Not System.IO.File.Exists(Fichero) Then
                ComprobarYCrearCarpetas(CarpetaFiltros)
                System.IO.File.Copy(My.Application.Info.DirectoryPath & "\InformacionFiltros.xml", Fichero)
            End If


            Dim dt As DataTable
            '  Dim dr as   DataRow

            Dim ds As New DataSet

            ds.ReadXmlSchema(Fichero)
            ds.ReadXml(Fichero)
            dt = ds.Tables("Info")


            Dim ExisteSinFiltros As Boolean = False

            For Each drr As DataRow In dt.Rows
                If drr("Nombre") = "[Sin Filtros]" Then
                    ExisteSinFiltros = True
                    Exit For
                End If
            Next


            For Each drr As DataRow In dt.Rows
               
                If drr("Nombre") = NombreDiseño Then
                    If MessageBox.Show("Ya existe un filtro con ese nombre." & vbCrLf & "¿Desea reemplazar el filtro?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then
                        Exit Sub
                    Else
                        dt.Rows.Remove(drr)
                        Exit For

                    End If
                End If
            Next



            ds.AcceptChanges()
            ds.WriteXml(Fichero, XmlWriteMode.WriteSchema)
            ds = Nothing


            'Añadimos
            ds = New DataSet
            dt = New DataTable
            ds.ReadXmlSchema(Fichero)
            ds.ReadXml(Fichero)
            dt = ds.Tables("Info")
            Dim dr As DataRow


            If Not ExisteSinFiltros Then
                dr = dt.NewRow
                dr("Nombre") = "[Sin Filtros]"
                dr("Tipo") = ""
                dr("Filtro") = ""

                dt.Rows.Add(dr)

                ds.AcceptChanges()
                ds.WriteXml(Fichero, XmlWriteMode.WriteSchema)
            End If

            dr = dt.NewRow
            dr("Nombre") = NombreDiseño
            dr("Tipo") = ""
            dr("Filtro") = g.ActiveFilterCriteria.ToString

            dt.Rows.Add(dr)

            ds.AcceptChanges()
            ds.WriteXml(Fichero, XmlWriteMode.WriteSchema)
            ds = Nothing


            CargarFiltros()
            '   cmbVistas.Text = NombreDiseño

            If cmbFiltroExterno IsNot Nothing Then
                cmbFiltroExterno.Text = NombreDiseño
            End If

            MessageBox.Show("Filtro guardado correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)


        Catch ex As Exception
            MessageBox.Show("Error al guardar el Filtro.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub mnucmbFiltros_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnucmbFiltros.SelectedIndexChanged

        Dim NombreFiltro As String = mnucmbFiltros.Text
        '    grc.tbRecuperarPerfil(NombrePerfil)
        AplicarFiltro(NombreFiltro)

    End Sub

    Private Sub CargarFiltros()

        If Not System.IO.Directory.Exists(CarpetaFiltros) Then
            Exit Sub
        End If

        Dim ds As New DataSet
        Dim dt As New DataTable
        ds.ReadXmlSchema(FicheroInformacionFiltros)
        ds.ReadXml(FicheroInformacionFiltros)
        dt = ds.Tables("Info")
        mnucmbFiltros.Items.Clear()
        For Each drr As DataRow In dt.Rows
            mnucmbFiltros.Items.Add(drr("Nombre"))
        Next

        mnucmbFiltros.Sorted = True

        If cmbFiltroExterno IsNot Nothing Then
            CargarFiltrosEnComboExteriorNuevo()
        End If



    End Sub
    Private Sub CargarFiltrosEnComboExteriorNuevo()

        If Not System.IO.Directory.Exists(CarpetaFiltros) Then
            Exit Sub
        End If


        Dim ds As New DataSet
        Dim dt As New DataTable
        ds.ReadXmlSchema(FicheroInformacionFiltros)
        ds.ReadXml(FicheroInformacionFiltros)
        dt = ds.Tables("Info")
        cmbFiltroExterno.Properties.Items.Clear()
        For Each drr As DataRow In dt.Rows
            cmbFiltroExterno.Properties.Items.Add(drr("Nombre"))
        Next
        cmbFiltroExterno.Properties.Sorted = True

    End Sub
    Public Function AplicarFiltro(NombreFiltro As String, Optional GridControlPasado As MyGridControl = Nothing) As Boolean

        'If Len(NombreFiltro) > 16 Then
        '    If Microsoft.VisualBasic.Right(NombreFiltro, 16).ToUpper = "(PREDETERMINADO)" Then
        '        NombreFiltro = Microsoft.VisualBasic.Left(NombreFiltro, Len(NombreFiltro) - 16)
        '    End If
        'End If



        Try
            Dim Resultado As Boolean
            Resultado = RecuperarFiltro(NombreFiltro, GridControlPasado)
            Me.Close()
            Return Resultado

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function

    Private Function RecuperarFiltro(ByVal NombreFiltro As String, Optional GridControlPasado As MyGridControl = Nothing) As Boolean

        Try
            Dim g As MyGridView
            If GridControlPasado Is Nothing Then
                g = grc.MainView
            Else
                g = GridControlPasado.MainView
            End If

            Dim FiltroAAplicar As String = ""
            Dim dt As DataTable
            '  Dim dr as   DataRow

            Dim ds As New DataSet
            ds.ReadXmlSchema(FicheroInformacionFiltros)
            ds.ReadXml(FicheroInformacionFiltros)
            dt = ds.Tables("Info")
            For Each drr As DataRow In dt.Rows
                If drr("Nombre") = NombreFiltro Then
                    FiltroAAplicar = drr("Filtro")
                    Exit For
                End If
             Next

            If FiltroAAplicar = "" And NombreFiltro <> "[Sin Filtros]" Then
                MensajeError("El filtro solicitado ya no existe")
                Return False
            End If


            If cmbFiltroExterno IsNot Nothing Then
                cmbFiltroExterno.Text = NombreFiltro
            End If

            g.ActiveFilterString = FiltroAAplicar

            Return True


            '      EscribirPredeterminadoOActual(NombreFiltro, "ACTUAL")
        Catch ex As Exception

        End Try

        'Try
        '    grc.tbRecuperarPerfil(NombreFiltro)
        '    Return True
        ' Catch ex as Exception
        '    MensajeError(ex.Message)
        '    Return False
        'End Try


    End Function

    Private Sub mnuCopiarFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCopiarFiltro.Click

        ''Dim sen as   New ToolStripMenuItem
        ''sen = TryCast(sender, ToolStripMenuItem)
        'Dim frm as   New frmCopiarPerfiles
        '' frm.lbldgvxABuscar.Text = Me.Name & "/dgvx"
        'frm.lbldgvxABuscar.Text = "/dgvx"
        'frm.ShowDialog()



        Dim f As New DevExpress.XtraEditors.XtraForm

        f.SuspendLayout()
        '
        'form2
        '
        f.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        f.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        f.ClientSize = New System.Drawing.Size(658, 262)
        f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        'f.Name = "form2"
        'f.Text = "form2"
        f.ResumeLayout(False)


        f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Dim uc As New ucCopiarPerfiles(CarpetaFiltros, "FILTROS")
        uc.Dock = System.Windows.Forms.DockStyle.Fill
        f.Controls.Add(uc)
        f.StartPosition = FormStartPosition.CenterScreen
        f.ControlBox = False

        Dim Texto As String = ""

        f.Text = Texto

        f.ShowDialog()
        f.Dispose()
    End Sub
#End Region

#Region "Otros"
    Private Sub PopMenuCopiarFila_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PopMenuCopiarFila.Click
        CopiarFila()
    End Sub

    Private Sub PopMenuGestionDocumental_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PopMenuGestionDocumental.Click
        CopiarFila()
    End Sub

    

    Private Sub PopMenuCopiarCelda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PopMenuCopiarCelda.Click
        CopiarCelda()
    End Sub

    Private Sub PopMenuGuardarSituacionActual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PopMenuGuardarSituacionActual.Click
        GuardarSituacionActual()
    End Sub

    Private Sub PopMenuRecuperarSituacionGuardada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PopMenuRecuperarSituacionGuardada.Click
        RecuperarPerfil(PerfilSituacionActual)
    End Sub

    Private Sub CopiarCelda()

        Dim g As GridView
        g = grc.MainView

        If g.RowCount = 0 Then
            MessageBox.Show("Debe seleccionar una celda", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)


            Exit Sub
        End If

        If g.FocusedRowHandle < 0 Then
            MessageBox.Show("Debe seleccionar una celda", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Exit Sub
        End If


        Try
            Clipboard.SetText(g.GetRowCellValue(g.FocusedRowHandle, g.FocusedColumn))
        Catch ex As Exception

        End Try




    End Sub

    Private Sub CopiarFila()

        Dim g As GridView
        g = grc.MainView

        If g.RowCount = 0 Then
            MessageBox.Show("Debe seleccionar una fila", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If g.FocusedRowHandle < 0 Then
            MessageBox.Show("Debe seleccionar una fila", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        g.CopyToClipboard()
    End Sub
    Private Sub PopMenuEscaparate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PopMenuEscaparate.Click
        Escaparate()
    End Sub
    Private Sub Escaparate()

        Dim g As GridView
        g = grc.MainView

        If g.RowCount = 0 Then
            MessageBox.Show("Debe seleccionar un inmueble", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If g.FocusedRowHandle < 0 Then
            MessageBox.Show("Debe seleccionar un inmueble", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim a As DataRowView = g.GetFocusedRow
        With frmEscaparate
            .ContadorInmueble = a.Item("Contador")
            .ContadorPropietario = a.Item("ContadorPropietario")
            .ReferenciaInmueble = a.Item("Referencia")
            .ShowDialog()
        End With
    End Sub
    'Private Sub PopMenuPublicarFacebook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PopMenuPublicarFacebook.Click
    '    uInmueblesActivo.publicarFacebook()
    'End Sub
    Private Sub PopMenuOcultarTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PopMenuOcultarTodo.Click
        OcultarTodo()
    End Sub
    Private Sub OcultarTodo()
        Dim OcultarMostrar As String = "mostrar"
        If TodoOculto Then OcultarMostrar = "ocultar"
        If XtraMessageBox.Show("¿Confirma que quiere " & OcultarMostrar & " todos los registros?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
            Exit Sub
        End If
        With uInmueblesActivo.bd
            .Execute("UPDATE Inmuebles SET Ocultar=" & FuncionesGenerales.Funciones.pf_ReplaceTrueFalse(TodoOculto) & " WHERE CodigoEmpresa=" & DatosEmpresa.Codigo)

            For Each row As DataRow In .ds.Tables("Inmuebles").Rows
                row.BeginEdit()
                row("Ocultar") = FuncionesGenerales.Funciones.pf_ReplaceTrueFalse(TodoOculto)
                row.EndEdit()
            Next
            .ds.AcceptChanges()
        End With
        If TodoOculto Then
            TodoOculto = False
            Me.PopMenuOcultarTodo.Text = "Mostrar Todo"
        Else
            TodoOculto = True
            Me.PopMenuOcultarTodo.Text = "Ocultar Todo"
        End If
        
    End Sub

    Private Sub PopMenuOcultarReservados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PopMenuOcultarReservados.Click
        OcultarReservados()
    End Sub
    Private Sub OcultarReservados()

        Dim ContadorAnterior As Integer = 0
        Try
            ContadorAnterior = uInmueblesActivo.BinSrc.Current("Contador")

        Catch ex As Exception

        End Try
        Dim filtro As String = ""
        With uInmueblesActivo
            If ReservadoOculto Then
                filtro = " Reservado = 0 "
                'If .DeDondeVengo = "CLIENTES" Then

                '    'ocultamos las reservas que le interesan al cliente activo
                '    'If UClienteActivo.BinSrc.Current("Alquiler") = True Then filtro = "(ReservadoAlquiler=0"
                '    'If UClienteActivo.BinSrc.Current("Verano") = True Then
                '    '    If filtro = "" Then
                '    '        filtro = "("
                '    '    Else
                '    '        filtro = filtro & " AND "
                '    '    End If
                '    '    filtro &= "ReservadoVerano=0"
                '    'End If
                '    'If UClienteActivo.BinSrc.Current("Venta") = True Then
                '    '    If filtro = "" Then
                '    '        filtro = "("
                '    '    Else
                '    '        filtro = filtro & " AND "
                '    '    End If
                '    '    filtro &= "ReservadoVenta=0"
                '    'End If
                '    'If filtro <> "" Then filtro &= ")"
                'Else
                '    'ocultamos todas las reservas
                '    filtro = "(ReservadoAlquiler=0 AND ReservadoVerano=0 AND ReservadoVenta=0)"
                'End If

                ReservadoOculto = False
                Me.PopMenuOcultarReservados.Text = "Mostrar Reservados"
            Else
                ReservadoOculto = True
                Me.PopMenuOcultarReservados.Text = "Ocultar Reservados"
            End If
            If .BinSrc.Filter = "" Or filtro = "" Then
                .BinSrc.Filter = filtro
            Else
                .BinSrc.Filter &= " AND " & filtro
            End If
        End With

        Try
            SituarseEnGrid(uInmueblesActivo.Gv, ContadorAnterior, "Contador", 0)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub PopMenuMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PopMenuMostrar.Click
        Mostrar()
    End Sub
    Private Sub Mostrar()
        With uInmueblesActivo
            .bd.Execute("UPDATE Inmuebles SET Ocultar=0 WHERE Contador=" & .BinSrc.Current("Contador"))
            .BinSrc.Current("Ocultar") = 0
            .bd.ds.AcceptChanges()
        End With
        TodoOculto = True
        Me.PopMenuOcultarTodo.Text = "Ocultar Todo"
    End Sub
    Private Sub PopMenuMapa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PopMenuMapa.Click
        Mapa()
    End Sub
    Private Sub Mapa()
        Try
            If Parentt = "Propietarios" Then
                MostrarMapa(uInmueblesActivo.UcInmueblesPropietario1.BinSrc.Current("Contador"))
            Else
                If Parentt = "Propiet" Then
                    MostrarMapa(uPropietariosActivo.GvInmuebles.GetFocusedRow("Contador"))
                Else
                    MostrarMapa(uInmueblesActivo.BinSrc.Current("Contador"))
                End If

            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub PopMenuReserva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PopMenuReserva.Click
        Reserva()
    End Sub
    Private Sub Reserva()
        If Parentt = "Propietarios" Then
            uInmueblesActivo.Reserva(uInmueblesActivo.UcInmueblesPropietario1.BinSrc.Current("Contador"))
        Else
            If Parentt = "Propiet" Then
                Try
                    Dim Contador As Integer
                    Contador = uPropietariosActivo.GvInmuebles.GetFocusedRow("Contador")

                    

                    If Not uPropietariosActivo.GvInmuebles.GetFocusedRow("Reservado") Then
                        frmFichaReserva.chkReservado.Checked = True
                    End If

                    frmFichaReserva.ContadorInmueble = Contador
                    frmFichaReserva.ShowDialog()
                Catch ex As Exception

                End Try

            Else
                uInmueblesActivo.Reserva()
            End If

        End If

    End Sub
    Private Sub popMenuExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PopMenuExportarExcel2007.Click, PopMenuExportarPDF.Click, PopMenuExportarExcel2003.Click, PopMenuExportarHTML.Click
        Dim Extension As String = ""
        If sender.Equals(PopMenuExportarExcel2007) Then
            Extension = "xlsx"
        End If
        If sender.Equals(PopMenuExportarExcel2003) Then
            Extension = "xls"
        End If
        If sender.Equals(PopMenuExportarPDF) Then
            Extension = "pdf"
        End If
        If sender.Equals(PopMenuExportarHTML) Then
            Extension = "html"
        End If

        Dim f As New tbImputBox("Introduzca la contraseña para exportar datos")
        f.ShowDialog()
        Dim Pass As String
        Pass = Gl_ResultadoBusqueda

        If Pass <> "LMML77" Then
            MensajeInformacion("La contraseña no es correcta")
            Exit Sub
        End If

        Exportar(Extension)
    End Sub

    Private Sub Exportar(ByVal Extension As String)

        Try

            Dim Ruta As String = ""
            Dim FBD As New FolderBrowserDialog

            Dim ofd As New SaveFileDialog
            Dim Fichero As String

            'ofd.Filter = "Archivos de Word(*.doc;*.docx)|*.doc;*.docx"

            'ofd.Filter = "Archivos doc |*.doc|docx|*.docx"

            ofd.Filter = "Archivos |*." & Extension & "|Todos|*.*"
            ofd.Title = "Seleccione un fichero"

            If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then

                Dim g As New GridView
                g = grc.MainView

                Fichero = ofd.FileName

                Select Case Extension
                    Case "xlsx"
                        g.ExportToXlsx(Fichero)
                    Case "xls"
                        g.ExportToXls(Fichero)

                    Case "pdf"
                        g.ExportToPdf(Fichero)

                    Case "html"
                        g.ExportToHtml(Fichero)

                End Select


                Dim p As New Process
                p.Start(Fichero)
            Else
                MessageBox.Show("No se guardó el documento", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Function ComprobarYCrearCarpetas(ByVal Directorio As String) As String

        If Not IO.Directory.Exists(Directorio) Then
            IO.Directory.CreateDirectory(Directorio)
        End If
        Return Directorio
    End Function

    Private Sub PopMenuDarDeBajaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PopMenuDarDeBajaCliente.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        UClienteActivo.ActualizarBajaAlta()
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub
    Private Sub PopMenuDarDeBajaInmueble_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PopMenuDarDeBajaInmueble.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        uInmueblesActivo.ActualizarBajaAlta()
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub
    Private Sub PopMenuDuplicarInmueble_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PopMenuDuplicarInmueble.Click
        uInmueblesActivo.DuplicarInmueble()
    End Sub
    Private Sub PopMenuMostrarColoresInmueble_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PopMenuMostrarColoresInmueble.Click
        uInmueblesActivo.MostrarColoresInmueble()
    End Sub
    Private Sub PopMenuMostrarPPrincipalWeb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PopMenuMostrarPPrincipalWeb.Click
        uInmueblesActivo.MostrarPPrincipalWeb()
    End Sub

    Private Sub AbrirCarpetaFotos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbrirCarpetaFotos.Click
        uInmueblesActivo.AbrirCarpetaFotos()
    End Sub
#End Region
End Class


