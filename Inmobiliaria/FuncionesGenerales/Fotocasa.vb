Imports RestSharp

Module Fotocasa
    Public Function PrepararJsonInmuebleFotocasa(Referencia As String, Locati As location) As Objetos.Inmuebles

        Dim Sel As String
        Dim bd As New BaseDatos
        Dim dt As DataTable

        Sel = "SELECT * FROM Inmuebles WHERE Referencia = " & Referencia
        bd.LlenarDataSet(Sel, "T")
        dt = bd.ds.Tables("T")
        Dim row As DataRow
        row = dt.Rows(0)

        Sel = "SELECT Tipo FROM TipoPortales WHERE Contador=(SELECT Contador" & "FotoCasa" & " FROM Tipo WHERE CodigoEmpresa=" & DatosEmpresa.Codigo & " AND Tipo='" & row("Tipo") & "')"
        Dim Tipo As String
        Tipo = BD_CERO.Execute(Sel, False, "")

        If Tipo = "" Then
            MensajeError("No se puede continuar con la publicación porque la referencia " & Referencia & " no tiene tipo asignado")
            Return Nothing
        End If


        Dim IdTipoVenta As Integer = 0
        Sel = "SELECT TipoVenta FROM TipoVentaPortales WHERE Contador=(SELECT Contador" & "FotoCasa" & " FROM TipoVenta WHERE CodigoEmpresa=" & DatosEmpresa.Codigo & " AND TipoVenta='" & row("TipoVenta") & "')"
        Dim tipoventa As String = BD_CERO.Execute(Sel, False)
        If IsNothing(tipoventa) OrElse Not tipoventa.Contains("|") Then
            MensajeError("No se puede continuar con la publicación porque la referencia " & Referencia & " no tiene tipo asignado")
            Return Nothing
        End If
        IdTipoVenta = tipoventa.Split("|")(0)
        'Dim tipo As String = BD_CERO.Execute(Sel, False)
        'If IsNothing(tipo) OrElse Not tipo.Contains("|") Then
        '    XtraMessageBox.Show("Error al publicar el inmueble " & dtr("Referencia") & ", el tipo " & dtr("Tipo") & " NO esta asignado" & vbCrLf & "Se cancela la publicación completa de " & "FotoCasa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    .Flush()
        '    .Close()
        '    bdPublicar.CerrarBD()
        '    dtr.close()
        '    pf.Close()
        '    Return Inmueble
        'End If
        '.WriteAttributeString("id", tipo.Split("|")(0))
        '.WriteString(tipo.Split("|")(1))


        Dim Inmueble As New Objetos.Inmuebles

        Inmueble.ExternalId = Referencia
        Inmueble.AgencyReference = Referencia
        Inmueble.TypeId = Tipo.Split("|")(0)
        Try
            Inmueble.SubtypeId = Tipo.Split("|")(2)
        Catch ex As Exception

        End Try

        If row("Duplex") Then
            Inmueble.SubtypeId = 3
        End If

        Inmueble.IsNewConstruction = False

        Inmueble.PropertyStatusId = 1 'Disponbile DIC_PropertyStatus


        '  Inmueble.ExpirationCauseId = null
        Inmueble.ShowSurface = True
        Inmueble.ContactTypeId = 1 'Agencia DIC_PropertyContactType
        Inmueble.IsPromotion = False
        '  Inmueble.BankAwardedId = 0
        Inmueble.ContactName = "" 'Si queremos poner el nombre del contacto de la inmobiliaria


        '******* PropertyAddress
        Inmueble.PropertyAddress = New List(Of PropertyAddress)

        Dim MiPropertyAddress = New PropertyAddress

        Dim StreetTypeId As Integer = 0
        Sel = "SELECT Id FROM ViasFotocasa WHERE AComparar LIKE '%" & row("Via") & "%'"
        StreetTypeId = BD_CERO.Execute(Sel, False, 0)

        Dim FloorId As Integer = 0
        If row("Altura") = -2 Then
            FloorId = 5
        Else
            If row("Altura") = -1 Then
                FloorId = 4
            Else
                If row("Altura") = 0 Then
                    FloorId = 3
                Else

                    FloorId = row("Altura") + 5
                End If
            End If
        End If


        MiPropertyAddress.ZipCode = row("CodPostal")
        MiPropertyAddress.CountryId = 724
        MiPropertyAddress.Zone = ""
        MiPropertyAddress.StreetTypeId = StreetTypeId
        'MiPropertyAddress.Street = row("Direccion")
        'MiPropertyAddress.Number = row("Numero")

        MiPropertyAddress.Street = row("DireccionMapa")
        MiPropertyAddress.Number = 1


        MiPropertyAddress.FloorId = FloorId



        MiPropertyAddress.x = CDbl(Replace(Locati.lng, ".", ","))
        MiPropertyAddress.y = CDbl(Replace(Locati.lat, ".", ","))
        MiPropertyAddress.VisibilityModeId = 2

        Inmueble.PropertyAddress.Add(MiPropertyAddress)





        '******* PropertyFeature
        Inmueble.PropertyFeature = New List(Of PropertyFeature)

        Dim MiPropertyFeature As PropertyFeature

        MiPropertyFeature = New PropertyFeature
        MiPropertyFeature.FeatureId = 1
        MiPropertyFeature.LanguageId = 4
        MiPropertyFeature.DecimalValue = row("Metros")
        Inmueble.PropertyFeature.Add(MiPropertyFeature)

        Dim Descripcion As String = ConsultasBaseDatos.ObtenerDescripcionInmueble2(row("Contador"), 0)
        MiPropertyFeature = New PropertyFeature  'Descripcion Abreviada
        MiPropertyFeature.FeatureId = 2
        MiPropertyFeature.LanguageId = 4
        MiPropertyFeature.TextValue = Descripcion
        Inmueble.PropertyFeature.Add(MiPropertyFeature)

        MiPropertyFeature = New PropertyFeature  'Descripcion Extendida
        MiPropertyFeature.FeatureId = 3
        MiPropertyFeature.LanguageId = 4
        MiPropertyFeature.TextValue = Descripcion
        Inmueble.PropertyFeature.Add(MiPropertyFeature)


        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 10 Then
            MiPropertyFeature = New PropertyFeature  'Descripcion Extendida
            MiPropertyFeature.FeatureId = 11
            MiPropertyFeature.LanguageId = 4
            MiPropertyFeature.DecimalValue = row("Habitaciones")
            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If


        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Then
            MiPropertyFeature = New PropertyFeature  'Descripcion Extendida
            MiPropertyFeature.FeatureId = 12
            MiPropertyFeature.LanguageId = 4
            MiPropertyFeature.DecimalValue = row("Banos")
            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 3 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 5 Or Inmueble.TypeId = 10 Then
            MiPropertyFeature = New PropertyFeature  'Descripcion Extendida
            MiPropertyFeature.FeatureId = 22
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(row("Ascensor")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = row("Ascensor")
            End If
            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 5 Or Inmueble.TypeId = 10 Then
            MiPropertyFeature = New PropertyFeature  'Descripcion Extendida
            MiPropertyFeature.FeatureId = 23
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(row("Garaje")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = row("Garaje")
            End If
            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 3 Or Inmueble.TypeId = 4 Then
            MiPropertyFeature = New PropertyFeature  'Descripcion Extendida
            MiPropertyFeature.FeatureId = 24
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(row("Trastero")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = row("Trastero")
            End If
            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 5 Or Inmueble.TypeId = 10 Then
            MiPropertyFeature = New PropertyFeature  'Descripcion Extendida
            MiPropertyFeature.FeatureId = 25
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(row("Piscina")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = row("Piscina")
            End If
            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 10 Then
            MiPropertyFeature = New PropertyFeature  'Descripcion Extendida
            MiPropertyFeature.FeatureId = 26
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(row("Jardin")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = row("Jardin")
            End If
            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 4 Then
            MiPropertyFeature = New PropertyFeature  'Descripcion Extendida
            MiPropertyFeature.FeatureId = 27
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(row("Terraza")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = row("Terraza")
            End If
            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 3 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 5 Or Inmueble.TypeId = 6 Or Inmueble.TypeId = 7 Or Inmueble.TypeId = 10 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 28
            MiPropertyFeature.LanguageId = 4
            Select Case row("Orientacion")
                Case "NORTE"
                    MiPropertyFeature.DecimalValue = 3
                Case "ESTE-NORTE"
                    MiPropertyFeature.DecimalValue = 1
                Case "ESTE"
                    MiPropertyFeature.DecimalValue = 5
                Case "ESTE-SUR"
                    MiPropertyFeature.DecimalValue = 6
                Case "SUR"
                    MiPropertyFeature.DecimalValue = 8
                Case "SUR-OESTE"
                    MiPropertyFeature.DecimalValue = 4
                Case "OESTE"
                    MiPropertyFeature.DecimalValue = 2
                Case "NORTE-OESTE"
                    MiPropertyFeature.DecimalValue = 7
                Case Else
                    MiPropertyFeature.DecimalValue = 3
            End Select

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If


        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 10 Then
            MiPropertyFeature = New PropertyFeature  'Descripcion Extendida
            MiPropertyFeature.FeatureId = 29
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(row("Calefaccion")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = row("Calefaccion")
            End If
            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 3 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 10 Then

            Dim Amueblado As Boolean = False
            Dim SemiAmueblado As Boolean = False

            If IsDBNull(row("Amueblado")) Then
                Amueblado = False
            Else
                Amueblado = row("Amueblado")
            End If

            If IsDBNull(row("SemiAmueblado")) Then
                SemiAmueblado = False
            Else
                SemiAmueblado = row("SemiAmueblado")
            End If

            If Amueblado OrElse SemiAmueblado Then
                Amueblado = True
            End If

            MiPropertyFeature = New PropertyFeature  'Descripcion Extendida
            MiPropertyFeature.FeatureId = 30
            MiPropertyFeature.LanguageId = 4
            MiPropertyFeature.BoolValue = Amueblado
            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 3 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 5 Or Inmueble.TypeId = 6 Or Inmueble.TypeId = 7 Or Inmueble.TypeId = 8 Or Inmueble.TypeId = 10 Or Inmueble.TypeId = 12 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 57
            MiPropertyFeature.LanguageId = 4
            MiPropertyFeature.DecimalValue = row("Metros")

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If


        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 3 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 5 Or Inmueble.TypeId = 10 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 62
            MiPropertyFeature.LanguageId = 4
            MiPropertyFeature.DecimalValue = row("MTerraza") + row("MTerraza2")

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 2 Or Inmueble.TypeId = 10 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 72
            MiPropertyFeature.LanguageId = 4
            MiPropertyFeature.DecimalValue = row("MJardin")

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If


        If Inmueble.TypeId = 2 Or Inmueble.TypeId = 10 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 83
            MiPropertyFeature.LanguageId = 4
            MiPropertyFeature.DecimalValue = row("MGaraje")

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If


        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 3 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 5 Or Inmueble.TypeId = 7 Or Inmueble.TypeId = 10 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 132
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(row("Electrodomesticos")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = row("Electrodomesticos")
            End If

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 3 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 5 Or Inmueble.TypeId = 7 Or Inmueble.TypeId = 12 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 155
            MiPropertyFeature.LanguageId = 4
            MiPropertyFeature.DecimalValue = row("PrecioComunidad")

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If


        If IdTipoVenta = 3 Or IdTipoVenta = 8 Then
            If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 3 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 8 Or Inmueble.TypeId = 12 Then
                MiPropertyFeature = New PropertyFeature
                MiPropertyFeature.FeatureId = 156
                MiPropertyFeature.LanguageId = 4

                If IsDBNull(row("ComunidadIncluida")) Then
                    MiPropertyFeature.BoolValue = False
                Else
                    MiPropertyFeature.BoolValue = row("ComunidadIncluida")
                End If

                Inmueble.PropertyFeature.Add(MiPropertyFeature)
            End If
        End If




        If Not IsDBNull(row("ZonaComercial")) AndAlso row("ZonaComercial") Then
            If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 3 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 5 Or Inmueble.TypeId = 6 Or Inmueble.TypeId = 7 Or Inmueble.TypeId = 10 Then
                MiPropertyFeature = New PropertyFeature
                MiPropertyFeature.FeatureId = 174
                MiPropertyFeature.LanguageId = 4
                MiPropertyFeature.DecimalValue = 1
                Inmueble.PropertyFeature.Add(MiPropertyFeature)
            End If
        End If

        If Not IsDBNull(row("ZonaComercial")) AndAlso row("ZonaComercial") Then
            If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 3 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 5 Or Inmueble.TypeId = 6 Or Inmueble.TypeId = 7 Or Inmueble.TypeId = 8 Or Inmueble.TypeId = 10 Then
                MiPropertyFeature = New PropertyFeature
                MiPropertyFeature.FeatureId = 175
                MiPropertyFeature.LanguageId = 4
                MiPropertyFeature.DecimalValue = 9
                Inmueble.PropertyFeature.Add(MiPropertyFeature)
            End If
        End If

        If Not IsDBNull(row("ZonaComercial")) AndAlso row("ZonaComercial") Then
            If Inmueble.TypeId = 10 Then
                MiPropertyFeature = New PropertyFeature
                MiPropertyFeature.FeatureId = 180
                MiPropertyFeature.LanguageId = 4
                MiPropertyFeature.DecimalValue = 15
                Inmueble.PropertyFeature.Add(MiPropertyFeature)
            End If
        End If

        If Not IsDBNull(row("Urbanizacion")) AndAlso row("Urbanizacion") Then
            If Inmueble.TypeId = 6 Then
                MiPropertyFeature = New PropertyFeature
                MiPropertyFeature.FeatureId = 183
                MiPropertyFeature.LanguageId = 4
                MiPropertyFeature.DecimalValue = 7
                Inmueble.PropertyFeature.Add(MiPropertyFeature)
            End If
        End If

        If Not IsDBNull(row("Urbanizacion")) AndAlso row("Urbanizacion") Then
            If Inmueble.TypeId = 10 Then
                MiPropertyFeature = New PropertyFeature
                MiPropertyFeature.FeatureId = 187
                MiPropertyFeature.LanguageId = 4
                MiPropertyFeature.DecimalValue = 7
                Inmueble.PropertyFeature.Add(MiPropertyFeature)
            End If
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 3 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 5 Or Inmueble.TypeId = 7 Or Inmueble.TypeId = 8 Or Inmueble.TypeId = 10 Or Inmueble.TypeId = 12 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 231
            MiPropertyFeature.LanguageId = 4
            MiPropertyFeature.DecimalValue = row("AnoConstruccion")

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 3 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 5 Or Inmueble.TypeId = 7 Or Inmueble.TypeId = 10 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 249
            MiPropertyFeature.LanguageId = 4
            Select Case row("Estado")
                Case "NUEVO"
                    MiPropertyFeature.DecimalValue = 3
                Case "SEMINUEVO"
                    MiPropertyFeature.DecimalValue = 2
                Case "REFORMADO"
                    MiPropertyFeature.DecimalValue = 1
                Case "SEMIREFORMADO"
                    MiPropertyFeature.DecimalValue = 4
                Case "ORIGEN", "PARA REFORMAR", "PARA DERRIVAR", "PARA DERRIBAR", "DIAFANO"
                    MiPropertyFeature.DecimalValue = 5

                Case Else
                    MiPropertyFeature.DecimalValue = 1
            End Select

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 3 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 5 Or Inmueble.TypeId = 7 Or Inmueble.TypeId = 8 Or Inmueble.TypeId = 10 Or Inmueble.TypeId = 12 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 254
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(row("AireAcondicionado")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = row("AireAcondicionado")
            End If

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If


        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 259
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(row("Electrodomesticos")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = row("Electrodomesticos")
            End If

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 263
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(row("Patio")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = row("Patio")
            End If

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 3 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 263
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(row("Calefaccion")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = row("Calefaccion")
            End If

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 284
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(row("PrimeraLineaPlaya")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = row("PrimeraLineaPlaya")
            End If

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 285
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(row("Montana")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = row("Montana")
            End If

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 289
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(row("CocinaOffice")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = row("CocinaOffice")
            End If

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 10 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 296
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(row("Calefaccion")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = row("Calefaccion")
            End If

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 297
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(row("Balcon")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = row("Balcon")
            End If

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 315
            MiPropertyFeature.LanguageId = 4
            If IsDBNull(row("VistasAlMar")) Then
                MiPropertyFeature.BoolValue = False
            Else
                MiPropertyFeature.BoolValue = row("VistasAlMar")
            End If

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If

        If Inmueble.TypeId = 1 Or Inmueble.TypeId = 2 Or Inmueble.TypeId = 3 Or Inmueble.TypeId = 4 Or Inmueble.TypeId = 5 Or Inmueble.TypeId = 7 Or Inmueble.TypeId = 10 Then
            MiPropertyFeature = New PropertyFeature
            MiPropertyFeature.FeatureId = 317
            MiPropertyFeature.LanguageId = 4

            Select Case row("CalificacionEnergetica")
                Case "A"
                    MiPropertyFeature.DecimalValue = 1
                Case "B"
                    MiPropertyFeature.DecimalValue = 2
                Case "C"
                    MiPropertyFeature.DecimalValue = 3
                Case "D"
                    MiPropertyFeature.DecimalValue = 4
                Case "E"
                    MiPropertyFeature.DecimalValue = 5
                Case "F"
                    MiPropertyFeature.DecimalValue = 6
                Case "G"
                    MiPropertyFeature.DecimalValue = 7

                Case Else
                    MiPropertyFeature.DecimalValue = 8
            End Select

            Inmueble.PropertyFeature.Add(MiPropertyFeature)
        End If


        '******* PropertyContactInfo

        Sel = "SELECT emailFotocasa FROM Empresas WHERE Codigo = " & DatosEmpresa.Codigo
        Dim emailFotocasa As String = BD_CERO.Execute(Sel, False, "")

        If emailFotocasa <> "" AndAlso IsNothing(Inmueble.PropertyContactInfo) Then
            Inmueble.PropertyContactInfo = New List(Of PropertyContactInfo)
        End If

        If emailFotocasa <> "" Then
            Dim MiPropertyContactInfo = New PropertyContactInfo

            MiPropertyContactInfo.TypeId = 1 'emailFotocasa
            MiPropertyContactInfo.Value = emailFotocasa
            MiPropertyContactInfo.ValueTypeId = 1

            Inmueble.PropertyContactInfo.Add(MiPropertyContactInfo)
        End If

        Sel = "SELECT TelefonoFotocasa FROM Empresas WHERE Codigo = " & DatosEmpresa.Codigo
        Dim TelefonoFotocasa As String = BD_CERO.Execute(Sel, False, "")

        If TelefonoFotocasa <> "" AndAlso IsNothing(Inmueble.PropertyContactInfo) Then
            Inmueble.PropertyContactInfo = New List(Of PropertyContactInfo)
        End If

        If TelefonoFotocasa <> "" Then
            Dim MiPropertyContactInfo = New PropertyContactInfo

            MiPropertyContactInfo.TypeId = 2 'Telefono
            MiPropertyContactInfo.Value = TelefonoFotocasa
            MiPropertyContactInfo.ValueTypeId = 1

            Inmueble.PropertyContactInfo.Add(MiPropertyContactInfo)
        End If


        '******* PropertyContactInfo
        Inmueble.PropertyPublications = New List(Of PropertyPublication)

        Dim MiPropertyPublications = New PropertyPublication

        MiPropertyPublications.PublicationId = 1 'FotoCasa
        MiPropertyPublications.PublicationTypeId = 1 'Web Propia

        Inmueble.PropertyPublications.Add(MiPropertyPublications)


        '******* PropertyContactInfo
        Inmueble.PropertyTransaction = New List(Of PropertyTransaction)

        Dim MiPropertyTransaction = New PropertyTransaction

        MiPropertyTransaction.TransactionTypeId = IdTipoVenta

        Select Case MiPropertyTransaction.TransactionTypeId
            Case 3
                MiPropertyTransaction.PaymentPeriodicityId = 3

            Case 8
                MiPropertyTransaction.PaymentPeriodicityId = 4

        End Select



        MiPropertyTransaction.Price = row("Precio")
        If row("Metros") <> 0 Then
            MiPropertyTransaction.PriceM2 = row("Precio") / row("Metros")
        Else
            MiPropertyTransaction.PriceM2 = row("Precio")
        End If

        MiPropertyTransaction.CurrencyId = 1

        MiPropertyTransaction.ShowPrice = True



        Inmueble.PropertyTransaction.Add(MiPropertyTransaction)



        '******* PropertyDocument
        Inmueble.PropertyDocument = New List(Of PropertyDocument)


        If DatosEmpresa.WordPress Then

            Sel = "SELECT SourceUrl FROM WP_FOTOS WHERE ContadorInmueble = " & row("Contador")
            Dim bdFotos As New BaseDatos
            bdFotos.LlenarDataSet(Sel, "T")

            For i = 0 To bdFotos.ds.Tables("T").Rows.Count - 1

                Dim PropertyDocument = New PropertyDocument
                PropertyDocument.TypeId = 1
                PropertyDocument.description = ""

                PropertyDocument.Url = bdFotos.ds.Tables("T").Rows(i)("SourceUrl")

                PropertyDocument.RoomTypeId = 0
                PropertyDocument.FileTypeId = 2
                PropertyDocument.Visible = True
                PropertyDocument.SortingId = i

                Inmueble.PropertyDocument.Add(PropertyDocument)




            Next


        Else
            Dim ftp As New tb_FTP
            Dim DirFiles As List(Of String) = ftp.FTPArchivosCarpeta(GL_ConfiguracionWeb.DirectorioFotos & "/" & Referencia)
            If Not IsNothing(DirFiles) AndAlso DirFiles.Count > 0 Then
                For i = 0 To DirFiles.Count - 1
                    Try
                        Dim PropertyDocument = New PropertyDocument
                        PropertyDocument.TypeId = 1
                        PropertyDocument.description = ""
                        If GL_ConfiguracionWeb.web3B Then
                            PropertyDocument.Url = "http://venalia.net" & GL_ConfiguracionWeb.DirectorioFotos & "/" & Referencia & "/" & DirFiles(i)
                        Else
                            PropertyDocument.Url = GL_ConfiguracionWeb.WebConHHTP & Replace(GL_ConfiguracionWeb.DirectorioFotos, "/httpdocs", "") & "/" & Referencia & "/" & DirFiles(i)
                        End If

                        PropertyDocument.RoomTypeId = 0
                        PropertyDocument.FileTypeId = 2
                        PropertyDocument.Visible = True
                        PropertyDocument.SortingId = i

                        Inmueble.PropertyDocument.Add(PropertyDocument)
                    Catch
                    End Try
                Next
            End If
        End If



        Return Inmueble
    End Function
    Public Function PublicarFotoCasaRest(Referencia As String, CodigoAPI As String, Optional ActualizarInmuebleExistente As Boolean = False) As clResultado
        Dim Res As New clResultado
        Dim Sel As String

        If CodigoAPI = "" Then
            Sel = "SELECT Codigo FROM ClientePortales WHERE Portal = 'FotoCasa' and CodigoEmpresa = " & DatosEmpresa.Codigo
            CodigoAPI = BD_CERO.Execute(Sel, False, "")

            If CodigoAPI = "" Then
                Res.Code = -1
                Res.Message = "No puede DesPublicar en FotoCasa porque no tiene código API de acceso"
                MensajeError(Res.Message)
                Return Res
            End If
        End If




        Dim Locati As location

        If Debugger.IsAttached Then
            Return Res
        End If


        Dim bd As New BaseDatos
        Dim dt As DataTable

        Sel = "SELECT * FROM Inmuebles WHERE Referencia = " & Referencia
        bd.LlenarDataSet(Sel, "T")
        dt = bd.ds.Tables("T")
        Dim row As DataRow
        row = dt.Rows(0)

        If row("Metros") = 0 Then
            Res.StatusCode = -1
            Res.Message = "No se puede publicar el inmueble en Fotocasa porque no tiene metros"
            Return Res
        End If

        If row("Precio") = 0 Then
            Res.StatusCode = -1
            Res.Message = "No se puede publicar el inmueble en Fotocasa porque no tiene Precio"
            Return Res
        End If

        If row("CodPostal").ToString.Trim = "" Then
            Res.StatusCode = -1
            Res.Message = "No se puede publicar el inmueble en Fotocasa porque no tiene Código Postal"
            Return Res
        End If

        Try

            Dim Direccion As String = ""
            Direccion = row("Provincia") & "+" & row("Poblacion") & "+" & row("CodPostal") & "+" & row("DireccionMapa") ' & "+" & row("Numero")

            Locati = ObtenerLocation(Direccion)



        Catch ex As Exception


            Res.StatusCode = -1
            Res.Message = "Error al obtener la latitud y la longitud " & ex.Message
            Return Res
        End Try

        If Locati.lat = 0 AndAlso Locati.lng = 0 Then
            Res.StatusCode = -1
            Res.Message = "Error al obtener la latitud y la longitud. No se pudo obtener localizar el inmueble con la dirección actual"
            Return Res
        End If


        Dim Inmueble As Objetos.Inmuebles = PrepararJsonInmuebleFotocasa(Referencia, Locati)

        If IsNothing(Inmueble) Then
            Res.StatusCode = -1
            Res.Message = "Error al construir el objeto"
            Return Res
        End If

        Try

            ''Para superseguridad. SOLO con Framework 4.5
            ''System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls

            Dim Metodo As RestSharp.Method
            Dim CodigoEsperado As Integer

            If ActualizarInmuebleExistente Then
                Metodo = Method.PUT
                CodigoEsperado = 200
            Else
                Metodo = Method.POST
                CodigoEsperado = 201
            End If

            Dim client = New RestClient(GL_wsRutaWs & "property")
            Dim request = New RestRequest(Metodo)

            request.AddHeader("Inmofactory-Api-Key", CodigoAPI)
            request.AddHeader("Cache-Control", "no-cache")
            request.AddHeader("content-type", "application/json")

            Dim postData As String = SerializarPost(Inmueble)

            request.AddParameter("application/json", postData, ParameterType.RequestBody)

            Dim response As IRestResponse = client.Execute(request)

            Dim MensajeAdicional As String = response.Content

            If response.StatusCode = CodigoEsperado Then
                Res.Message = response.Content
                Res.StatusCode = 0
                Res.Code = ""

                Sel = "UPDATE Inmuebles SET Portal" & "FotoCasa" & " = " & GL_SQL_VALOR_1 & " WHERE Referencia = '" & Funciones.pf_ReplaceComillas(Referencia) & "' AND CodigoEmpresa=" & DatosEmpresa.Codigo
                BD_CERO.Execute(Sel)

                If ActualizarInmuebleExistente Then
                    InsertaEnTramites(Referencia, "UPDATE FOTOCASA", MensajeAdicional)
                Else
                    InsertaEnTramites(Referencia, "ALTA FOTOCASA", MensajeAdicional)
                End If

            Else
                Res = Newtonsoft.Json.JsonConvert.DeserializeObject(Of clResultado)(response.Content)


                If Res.StatusCode = 400 AndAlso Res.Code = "Error_110" Then  'El inmueble ya existe, hacemos un put
                    request.Method = Method.PUT
                    response = client.Execute(request)
                    MensajeAdicional = response.Content
                    If response.StatusCode = 200 Then
                        Res.Message = response.Content
                        Res.StatusCode = 0
                        Res.Code = ""

                        Sel = "UPDATE Inmuebles SET Portal" & "FotoCasa" & " = " & GL_SQL_VALOR_1 & " WHERE Referencia = '" & Funciones.pf_ReplaceComillas(Referencia) & "' AND CodigoEmpresa=" & DatosEmpresa.Codigo
                        BD_CERO.Execute(Sel)

                        InsertaEnTramites(Referencia, "UPDATE FOTOCASA", MensajeAdicional)

                    Else
                        Res.StatusCode = -1
                        Res = Newtonsoft.Json.JsonConvert.DeserializeObject(Of clResultado)(response.Content)
                        Res.Code = response.StatusDescription
                        InsertaEnTramites(Referencia, "INTENTO ALTA FOTOCASA", MensajeAdicional)
                    End If



                Else
                    Res.StatusCode = -2
                    Res = Newtonsoft.Json.JsonConvert.DeserializeObject(Of clResultado)(response.Content)
                    Res.Code = response.StatusDescription
                    InsertaEnTramites(Referencia, "INTENTO ALTA FOTOCASA", MensajeAdicional)

                End If

            End If

            InsertarMovimientosFotocasa(Referencia, 1, Res.StatusCode, "ALTA", MensajeAdicional)



        Catch ex5 As Net.WebException
            Res.StatusCode = GL_CodigoErrorWebService
            Res.Message = ex5.Message

        Catch ex As Exception
            Res.StatusCode = GL_CodigoErrorWebService
            Res.Message = ex.Message
        End Try

        Return Res


    End Function
    Public Function DespublicarFotocasa(Referencia As String, CodigoAPI As String, Motivo As String) As clResultado


        'If Debugger.IsAttached Then
        '    Return Nothing
        'End If


        Dim Res As New clResultado

        'Referencia = "14519"

        Try
            Dim client = New RestClient(GL_wsRutaWs & "property/" & Referencia)
            Dim request = New RestRequest(Method.[DELETE])

            request.AddHeader("Inmofactory-Api-Key", CodigoAPI)
            request.AddHeader("Cache-Control", "no-cache")
            request.AddHeader("content-type", "application/json")

            Dim response As IRestResponse = client.Execute(request)

            Dim MensajeAdicional As String = response.Content

            If response.StatusDescription = "OK" Then
                Res.Message = response.Content
                Res.StatusCode = 0
                Res.Code = ""

                Dim Sel As String
                Sel = "UPDATE Inmuebles SET PortalFotoCasa = 0 WHERE Referencia = '" & Funciones.pf_ReplaceComillas(Referencia) & "'  and CodigoEmpresa = " & DatosEmpresa.Codigo
                BD_CERO.Execute(Sel)

                InsertaEnTramites(Referencia, "BAJA FOTOCASA", MensajeAdicional)


            Else
                Res.StatusCode = -1
                Res = Newtonsoft.Json.JsonConvert.DeserializeObject(Of clResultado)(response.Content)

                If Res.Code = "Error_1402" Then
                    Res.StatusCode = 0
                    Dim Sel As String
                    Sel = "UPDATE Inmuebles SET PortalFotoCasa = 0 WHERE Referencia = '" & Funciones.pf_ReplaceComillas(Referencia) & "'  and CodigoEmpresa = " & DatosEmpresa.Codigo
                    BD_CERO.Execute(Sel)

                    InsertaEnTramites(Referencia, "BAJA FOTOCASA", MensajeAdicional)
                Else
                    InsertaEnTramites(Referencia, "INTENTO BAJA FOTOCASA", MensajeAdicional)
                End If
            End If


            InsertarMovimientosFotocasa(Referencia, 0, Res.StatusCode, Motivo, MensajeAdicional)

        Catch ex4 As ServiceModel.FaultException(Of clResultado)
            Res.StatusCode = ex4.Code.ToString
            Res.Message = ex4.Reason.ToString

        Catch ex5 As Net.WebException
            Res.StatusCode = GL_CodigoErrorWebService
            Res.Message = ex5.Message

        Catch ex As Exception
            Res.StatusCode = GL_CodigoErrorWebService
            Res.Message = ex.Message
        End Try

        Return Res


    End Function

End Module
