Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class ucArticulosVendidos
    Public Sub New()
        InitializeComponent()

    End Sub


    Public Sub LlenarGridInmuebles(CodProp As Integer)

        Dim Tabla As String = "Propietarios"
        Dim Sel As String = "EXEC sp_InmueblesPropietarios  " & CodProp
        Dim bd As New BaseDatos
        bd.LlenarDataSet(Sel, Tabla)

        dgvx.DataSource = bd.ds.Tables(Tabla)
        dgvx.ForceInitialize()

        ParametrizarGrid(Gv, False)
        Gv.BestFitColumns()
        Gv.OptionsView.ColumnAutoWidth = True
        Gv.OptionsView.ShowGroupPanel = False
        Gv.OptionsView.ShowAutoFilterRow = False
        ConfigurarGridInmuebles()
        'Gv.Columns("PrecioUnitario").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        'Gv.Columns("PrecioUnitario").DisplayFormat.FormatString = "{0:n2}"
        ''  c.Numero AS Albaran, C.Fecha, Articulo, Definicion, Unidades,Precio as PrecioUnitario, dto1, dto2 
        '  If dgvx.Width > Me.Width Then
        dgvx.Width = Me.Width
        '  End If

    End Sub

    Private Sub ConfigurarGridInmuebles()

        'If Not PrimeraVezInmuebles Then
        '    Exit Sub
        'End If

        'PrimeraVezInmuebles = False
        'If dgvx.tbEstablecerPerfilPredeterminado() Then
        '    Exit Sub
        'End If



        'GridPasado.OptionsNavigation.EnterMoveNextColumn = True
        'GridPasado.OptionsNavigation.UseTabKey = True
        'GridPasado.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        Gv.OptionsView.ShowGroupPanel = False
        'GridPasado.OptionsBehavior.Editable = False
        'GridPasado.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        'GridPasado.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
        'GridPasado.OptionsView.ColumnAutoWidth = True
        Gv.OptionsView.ShowAutoFilterRow = False

        'Gv.Columns("Referencia").Visible = False
        Gv.Columns("Delegacion").Visible = False
        Gv.Columns("CodPropietario").Visible = False
        Gv.Columns("Reservado").Visible = False
        Gv.Columns("FechaAlta").Visible = False
        Gv.Columns("FechaUltimaLlamadaPropietario").Visible = False
        Gv.Columns("FechaVencimiento").Visible = False
        '   Gv.Columns("Venta").Visible = False
        '   Gv.Columns("Alquiler").Visible = False
        Gv.Columns("AlquilerOpcionCompra").Visible = False
        Gv.Columns("Baja").Visible = False
        Gv.Columns("Llaves").Visible = False
        '     Gv.Columns("PrecioVenta").Visible = False
        '    Gv.Columns("PrecioAlquiler").Visible = False
        Gv.Columns("PrecioPropietarioVenta").Visible = False
        Gv.Columns("PrecioPropietarioAlquiler").Visible = False
        Gv.Columns("PrecioNegociableVenta").Visible = False
        Gv.Columns("PrecioNegociableAlquiler").Visible = False
        Gv.Columns("GastosVenta").Visible = False
        Gv.Columns("GastosAlquiler").Visible = False
        Gv.Columns("Direccion").Visible = False
        Gv.Columns("Numero").Visible = False
        Gv.Columns("Altura").Visible = False
        Gv.Columns("CodPostal").Visible = False
        Gv.Columns("Poblacion").Visible = False
        Gv.Columns("Provincia").Visible = False
        Gv.Columns("Puerta").Visible = False
        Gv.Columns("Metros").Visible = False
        Gv.Columns("Banos").Visible = False
        Gv.Columns("Habitaciones").Visible = False
        Gv.Columns("AnoConstruccion").Visible = False
        Gv.Columns("MPlaya").Visible = False
        Gv.Columns("Ascensor").Visible = False
        Gv.Columns("CocinaOffice").Visible = False
        Gv.Columns("Piscina").Visible = False
        Gv.Columns("Duplex").Visible = False
        Gv.Columns("Galeria").Visible = False
        Gv.Columns("AireAcondicionado").Visible = False
        Gv.Columns("Calefaccion").Visible = False
        Gv.Columns("Tipo").Visible = False
        Gv.Columns("Orientacion").Visible = False
        Gv.Columns("Zona").Visible = False
        Gv.Columns("Estado").Visible = False
        Gv.Columns("Extras").Visible = False
        Gv.Columns("OtrasObservaciones").Visible = False
        Gv.Columns("chollo").Visible = False
        Gv.Columns("Escaparate").Visible = False
        Gv.Columns("NOAlquiler").Visible = False
        Gv.Columns("Ocultar").Visible = False
        Gv.Columns("Cartel").Visible = False
        Gv.Columns("Balcon").Visible = False
        Gv.Columns("MBalcon").Visible = False
        Gv.Columns("MBalcon2").Visible = False
        Gv.Columns("Patio").Visible = False
        Gv.Columns("MPatio").Visible = False
        Gv.Columns("MPatio2").Visible = False
        Gv.Columns("Terraza").Visible = False
        Gv.Columns("MTerraza").Visible = False
        Gv.Columns("MTerraza2").Visible = False
        Gv.Columns("Jardin").Visible = False
        Gv.Columns("MJardin").Visible = False
        Gv.Columns("MTrastero").Visible = False
        Gv.Columns("TrasteroVenta").Visible = False
        Gv.Columns("TrasteroAlquiler").Visible = False
        Gv.Columns("PrecioTrasteroVenta").Visible = False
        Gv.Columns("PrecioTrasteroAlquiler").Visible = False
        Gv.Columns("MGaraje").Visible = False
        Gv.Columns("GarajeCerrado").Visible = False
        Gv.Columns("GarajeVenta").Visible = False
        Gv.Columns("GarajeAlquiler").Visible = False
        Gv.Columns("PrecioGarajeVenta").Visible = False
        Gv.Columns("PrecioGarajeAlquiler").Visible = False
        Gv.Columns("SemiAmuebladoVenta").Visible = False
        Gv.Columns("SemiAmuebladoAlquiler").Visible = False
        Gv.Columns("AmuebladoVenta").Visible = False
        Gv.Columns("AmuebladoAlquiler").Visible = False
        Gv.Columns("PrecioAmuebladoVenta").Visible = False
        Gv.Columns("PrecioAmuebladoAlquiler").Visible = False
        Gv.Columns("ElectrodomesticosAlquiler").Visible = False
        Gv.Columns("CocinaAlquiler").Visible = False
        Gv.Columns("CalentadorAlquiler").Visible = False
        Gv.Columns("PlatoDuchaAlquiler").Visible = False
        Gv.Columns("BaneraAlquiler").Visible = False
        Gv.Columns("FianzaAlquler").Visible = False
        Gv.Columns("ComunidadIncluida").Visible = False
        Gv.Columns("PrecioComunidad").Visible = False
        Gv.Columns("CodVendedor").Visible = False
        Gv.Columns("CodCaptador").Visible = False
        Gv.Columns("CodComercial").Visible = False
        Gv.Columns("TextoEscaparate").Visible = False
        Gv.Columns("FotoEscaparate").Visible = False
        Gv.Columns("FotoEscaparate2").Visible = False
        Gv.Columns("Foto").Visible = False
        Gv.Columns("TextoLlaves").Visible = False
        Gv.Columns("OrdenImpresion").Visible = False
        Gv.Columns("Agrupacion").Visible = False






        'gvClientes.Columns("Articulo").Width = 280
        'gvClientes.Columns("Codigo").Width = 100

        'gvClientes.Columns("Descuento").Caption = "% Desc."
        'gvClientes.Columns("DescuentoRecalculo").Caption = "% Recalc."

        'gvClientes.Columns("Precio").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric


        'gvClientes.BestFitMaxRowCount = 20
        Gv.BestFitColumns()
        'gvClientes.OptionsView.ShowAutoFilterRow = False

        'If Estado = GL_ACEPTADO Then
        '    gvClientes.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        '    gvClientes.OptionsBehavior.Editable = False
        'End If


        'gvClientes.ShowButtonMode = Views.Base.ShowButtonModeEnum.ShowAlways
        '     gvClientes.ShowFindPanel()
        'Sumatorio en el pie del grid
        '   gvClientes.FooterPanelHeight = 20

        '    gvClientes.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always

        'Sumatorios en agrupaciones
        Gv.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways

        Dim ItemArticulo As GridGroupSummaryItem = New GridGroupSummaryItem()
        ItemArticulo.FieldName = "Codigo"
        ItemArticulo.DisplayFormat = "{0:n0}"
        ItemArticulo.SummaryType = DevExpress.Data.SummaryItemType.Count
        Gv.GroupSummary.Add(ItemArticulo)

        'Dim filterString As String = "Nombre LIKE '%a%'"
        'gvClientes.Columns("Nombre").FilterInfo = New Columns.ColumnFilterInfo(ColumnFilterType.Custom, Nothing, filterString)



        '   gvClientes.Columns("Nombre").FilterInfo.Type.Custom()






        'gvClientes.OptionsView.ShowFooter = True
        'gvClientes.Columns("CodigoSIG").SummaryItem.FieldName = "CodigoSIG"
        'gvClientes.Columns("CodigoSIG").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        'gvClientes.Columns("CodigoSIG").SummaryItem.DisplayFormat = "Estudios: {0:n0}"

    End Sub

End Class
