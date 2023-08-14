USE [Venalia]
GO

ALTER TABLE Inmuebles 
ADD FotosRevisar bit not null default 0
go


ALTER TABLE Inmuebles 
ADD UrbanizacionTexto varchar(100) not null default ''
go

ALTER TABLE Inmuebles 
ADD DireccionMapa varchar(150) not null default ''
go

ALTER TABLE InmueblesBaja 
ADD UrbanizacionTexto varchar(100) not null default ''
go

ALTER TABLE InmueblesBaja 
ADD DireccionMapa varchar(150) not null default ''
go

ALTER TABLE InmueblesBaja 
ADD FotosRevisar bit not null default 0
go

 

/****** Object:  View [dbo].[v_TodosLosInmuebles]    Script Date: 06/09/2014 18:27:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



 
/****** Object:  View [dbo].[v_TodosLosInmuebles]    Script Date: 16/09/2014 20:11:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





ALTER VIEW [dbo].[v_TodosLosInmuebles]
AS
SELECT     [Contador], [Referencia], [CodigoEmpresa], [Delegacion], [ContadorEmpleado], [ContadorPropietario], [FechaAlta], [FechaUltimaLlamadaPropietario], 
                     [Venta], [Alquiler], [AlquilerOpcionCompra], [Verano], [Traspaso], [Llaves], [PrecioVenta], [PrecioAlquiler], [PrecioVerano], [PrecioTraspaso], 
                      [PrecioPropietarioVenta], [PrecioPropietarioAlquiler], [PrecioPropietarioVerano], [PrecioPropietarioTraspaso], [GastosVenta], [GastosAlquiler], [GastosVerano], 
                      [GastosTraspaso], [Direccion], [Numero], [Altura], [CodPostal], [Poblacion], [Provincia], [Puerta], [Metros], [Banos], [Habitaciones], [AnoConstruccion], [MPlaya], 
                      [Ascensor], [CocinaOffice], [Piscina], [Duplex], [Galeria], [AireAcondicionado], [Calefaccion], [Tipo], [Orientacion], [Zona], [Estado], [Extras],  [chollo], 
                      [Escaparate], [NOAlquiler], [Ocultar], [Cartel], [Balcon], [MBalcon], [MBalcon2], [Patio], [MPatio], [MPatio2], [Terraza], [MTerraza], [MTerraza2], [Jardin], [MJardin], 
                      [TrasteroVenta], [MTrastero], [PrecioTrasteroVenta], [PrecioTrasteroAlquiler], [PrecioTrasteroVerano], [GarajeVenta], [MGaraje], [GarajeCerrado], 
                      [GarajeNumero], [PrecioGarajeVenta], [PrecioGarajeAlquiler], [PrecioGarajeVerano], [SemiAmuebladoVenta], [AmuebladoVenta], [Electrodomesticos], 
                      [Cocina], [Calentador], [PrimeraLineaPlaya], [PlatoDucha], [Banera], [FianzaAlquiler], [ComunidadIncluida], [PrecioComunidad], [TextoEscaparate], [FotoEscaparate], 
                      [FotoEscaparate2], [Foto], [TextoLlaves], [Agrupacion], [Personas], [CamasDobles], [CamasIndividuales], [SofaCama], [ImporteHipoteca], [ZonaComercial], [FotosPc], 
                      [FotosWeb], [FotoPrincipal], [CalificacionEnergetica],[TrasteroAlquiler],[TrasteroVerano],[GarajeAlquiler],[GarajeVerano] ,
					  PrecioPropietarioJunio, PrecioPropietarioJulio, PrecioPropietarioAgosto, Via,  [SemiAmuebladoAlquiler], [AmuebladoAlquiler]
					  , ReferenciasUnidas, Montana, AccesoMinusvalidos, Urbanizacion, PlayaIzquierda, AlturaFinca, Direccion2, AlquiladaPorNosotros,Revisado,EnviadaFicha,UrbanizacionTexto,DireccionMapa,FotosRevisar,
                          (SELECT     Nombre
                            FROM          Propietarios P
                            WHERE      Contador = I.ContadorPropietario) AS Propietario,
                          (SELECT     Telefono1
                            FROM          Propietarios P
                            WHERE      Contador = I.ContadorPropietario) AS Telefono1Propietario,
                          (SELECT     Telefono2
                            FROM          Propietarios P
                            WHERE      Contador = I.ContadorPropietario) AS Telefono2Propietario,
                          (SELECT     Telefono3
                            FROM          Propietarios P
                            WHERE      Contador = I.ContadorPropietario) AS Telefono3Propietario,
                          (SELECT     Telefono4
                            FROM          Propietarios P
                            WHERE      Contador = I.ContadorPropietario) AS Telefono4Propietario,
                          (SELECT     TelefonoMovil
                            FROM          Propietarios P
                            WHERE      Contador = I.ContadorPropietario) AS TelefonoMovilPropietario,
                          (SELECT     Email
                            FROM          Propietarios P
                            WHERE      Contador = I.ContadorPropietario) AS EmailPropietario,
                          (SELECT     Email2
                            FROM          Propietarios P
                            WHERE      Contador = I.ContadorPropietario) AS Email2Propietario,
                          (SELECT     COUNT(*)
                            FROM          Inmuebles I2
                            WHERE      I2.Contador = I.ContadorPropietario) AS Inmuebles, CONVERT(BIT, 0) AS Baja
							
FROM         [Inmuebles] I
UNION ALL
SELECT     [Contador], [Referencia], [CodigoEmpresa], [Delegacion], [ContadorEmpleado], [ContadorPropietario], [FechaAlta], [FechaUltimaLlamadaPropietario], 
                      [Venta], [Alquiler], [AlquilerOpcionCompra], [Verano], [Traspaso], [Llaves], [PrecioVenta], [PrecioAlquiler], [PrecioVerano], [PrecioTraspaso], 
                      [PrecioPropietarioVenta], [PrecioPropietarioAlquiler], [PrecioPropietarioVerano], [PrecioPropietarioTraspaso], [GastosVenta], [GastosAlquiler], [GastosVerano], 
                      [GastosTraspaso], [Direccion], [Numero], [Altura], [CodPostal], [Poblacion], [Provincia], [Puerta], [Metros], [Banos], [Habitaciones], [AnoConstruccion], [MPlaya], 
                      [Ascensor], [CocinaOffice], [Piscina], [Duplex], [Galeria], [AireAcondicionado], [Calefaccion], [Tipo], [Orientacion], [Zona], [Estado], [Extras],  [chollo], 
                      [Escaparate], [NOAlquiler], [Ocultar], [Cartel], [Balcon], [MBalcon], [MBalcon2], [Patio], [MPatio], [MPatio2], [Terraza], [MTerraza], [MTerraza2], [Jardin], [MJardin], 
                      [TrasteroVenta], [MTrastero], [PrecioTrasteroVenta], [PrecioTrasteroAlquiler], [PrecioTrasteroVerano], [GarajeVenta], [MGaraje], [GarajeCerrado], 
                      [GarajeNumero], [PrecioGarajeVenta], [PrecioGarajeAlquiler], [PrecioGarajeVerano], [SemiAmuebladoVenta], [AmuebladoVenta], [Electrodomesticos], 
                      [Cocina], [Calentador], [PrimeraLineaPlaya], [PlatoDucha], [Banera], [FianzaAlquiler], [ComunidadIncluida], [PrecioComunidad], [TextoEscaparate], [FotoEscaparate], 
                      [FotoEscaparate2], [Foto], [TextoLlaves], [Agrupacion], [Personas], [CamasDobles], [CamasIndividuales], [SofaCama], [ImporteHipoteca], [ZonaComercial], [FotosPc], 
                      [FotosWeb], [FotoPrincipal], [CalificacionEnergetica],[TrasteroAlquiler],[TrasteroVerano],[GarajeAlquiler],[GarajeVerano],
					  PrecioPropietarioJunio, PrecioPropietarioJulio, PrecioPropietarioAgosto, Via,  [SemiAmuebladoAlquiler], [AmuebladoAlquiler]
					  , ReferenciasUnidas, Montana, AccesoMinusvalidos, Urbanizacion, PlayaIzquierda, AlturaFinca, Direccion2, AlquiladaPorNosotros,Revisado,EnviadaFicha,UrbanizacionTexto,DireccionMapa,FotosRevisar,
                          (SELECT     Nombre
                            FROM          Propietarios P
                            WHERE      Contador = I.ContadorPropietario) AS Propietario,
                          (SELECT     Telefono1
                            FROM          Propietarios P
                            WHERE      Contador = I.ContadorPropietario) AS Telefono1Propietario,
                          (SELECT     Telefono2
                            FROM          Propietarios P
                            WHERE      Contador = I.ContadorPropietario) AS Telefono2Propietario,
                          (SELECT     Telefono3
                            FROM          Propietarios P
                            WHERE      Contador = I.ContadorPropietario) AS Telefono3Propietario,
                          (SELECT     Telefono4
                            FROM          Propietarios P
                            WHERE      Contador = I.ContadorPropietario) AS Telefono4Propietario,
                          (SELECT     TelefonoMovil
                            FROM          Propietarios P
                            WHERE      Contador = I.ContadorPropietario) AS TelefonoMovilPropietario,
                          (SELECT     Email
                            FROM          Propietarios P
                            WHERE      Contador = I.ContadorPropietario) AS EmailPropietario,
                          (SELECT     Email2
                            FROM          Propietarios P
                            WHERE      Contador = I.ContadorPropietario) AS Email2Propietario,
                          (SELECT     COUNT(*)
                            FROM          Inmuebles I2
                            WHERE      I2.Contador = I.ContadorPropietario) AS Inmuebles, CONVERT(BIT, 1) AS Baja
FROM         InmueblesBaja I





GO


