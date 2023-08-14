 select * from inmobiliaria.dbo.inmuebles
 select * from igis.dbo.inmuebles
 
 DECLARE @CodigoEmpresa int
 SET @CodigoEmpresa = 2

  DECLARE @Delegacion int
 SET @Delegacion = 1

 DBCC CHECKIDENT(  INMUEBLES , reseed, 0)

delete from IGIS.dbo.INMUEBLES 
 
--update   inmobiliaria.dbo.INMUEBLES  set CodComercial = 1 where codcomercial is null or codcomercial = 0  

-- update Inmobiliaria.dbo.INMUEBLES set codcomercial = 1 where codcomercial in
--(
-- select distinct codcomercial from  Inmobiliaria.dbo.INMUEBLES
-- where codcomercial not in (SELECT Codigo from  Inmobiliaria.dbo.usuarios))

--  select * from  Inmobiliaria.dbo.INMUEBLES
-- where codproveedor not in (SELECT codproveedor from  Inmobiliaria.dbo.Proveedores  )

 --delete from Inmobiliaria.dbo.Inmuebles where Referencia in  ( select Referencia  from  Inmobiliaria.dbo.INMUEBLES
 --where codproveedor not in (SELECT codproveedor from  Inmobiliaria.dbo.Proveedores  ))

INSERT INTO IGIS.dbo.INMUEBLES 
SELECT Referencia, @CodigoEmpresa, Delegacion
, (SELECT ContadoR  FROM Empleados E inner join  Inmobiliaria.dbo.Usuarios u on e.nombre = u.nombre WHERE u.Codigo = I.CodComercial)
, (SELECT Contador FROM Propietarios WHERE CodProveedorViejo = I.CodProveedor)
,CASE WHEN Reservado = 'SI' THEN 1 ELSE 0 END
,Fecha,FechaEnVenta,FechaVencimiento 

,CASE WHEN TipoVenta = 'VENTA' THEN 1 ELSE 0 END
,CASE WHEN TipoVenta = 'ALQUILER' THEN 1 ELSE 0 END
,CASE WHEN AlquilerOpcionCompra = 'SI' THEN 1 ELSE 0 END
,CASE WHEN TipoVenta = 'VERANO' THEN 1 ELSE 0 END
,CASE WHEN TipoVenta = 'TRASPASO' THEN 1 ELSE 0 END

,0
,CASE WHEN Llaves = 'SI' THEN 1 ELSE 0 END

,CASE WHEN TipoVenta = 'VENTA' THEN Precio ELSE 0 END
,CASE WHEN TipoVenta = 'ALQUILER' THEN Precio ELSE 0 END
,CASE WHEN TipoVenta = 'VERANO' THEN Precio ELSE 0 END
,CASE WHEN TipoVenta = 'VERANO' THEN Precio ELSE 0 END
,CASE WHEN TipoVenta = 'VERANO' THEN Precio ELSE 0 END
,CASE WHEN TipoVenta = 'TRASPASO' THEN Precio ELSE 0 END

,CASE WHEN TipoVenta = 'VENTA' THEN PrecioProveedor  ELSE 0 END
,CASE WHEN TipoVenta = 'ALQUILER' THEN PrecioProveedor ELSE 0 END
,CASE WHEN TipoVenta = 'VERANO' THEN PrecioProveedor ELSE 0 END
,CASE WHEN TipoVenta = 'TRASPASO' THEN PrecioProveedor ELSE 0 END

,Gastos

--,CASE WHEN TipoVenta = 'VENTA' AND PN = 'SI' THEN 1 ELSE 0 END
--,CASE WHEN TipoVenta = 'ALQUILER' AND PN = 'SI' THEN 1 ELSE 0 END
--,CASE WHEN TipoVenta = 'VERANO' AND PN = 'SI' THEN 1 ELSE 0 END
--,CASE WHEN TipoVenta = 'TRASPASO' AND PN = 'SI' THEN 1 ELSE 0 END
  
--,CASE WHEN TipoVenta = 'VENTA' THEN Gastos  ELSE '' END
--,CASE WHEN TipoVenta = 'ALQUILER' THEN Gastos ELSE '' END
--,CASE WHEN TipoVenta = 'VERANO' THEN Gastos ELSE '' END
--,CASE WHEN TipoVenta = 'TRASPASO' THEN Gastos ELSE '' END

,Direccion,Num,Altura,CP,Poblacion, 
case when provincia is null then '' else provincia end
 , Puerta
,Metros ,Banos ,Habitaciones,Anos ,MPlaya

,CASE WHEN Ascensor = 'SI' THEN 1 ELSE 0 END
,CASE WHEN CocinaOffice = 'SI' THEN 1 ELSE 0 END
,CASE WHEN Piscina = 'SI' THEN 1 ELSE 0 END
,CASE WHEN Duplex = 'SI' THEN 1 ELSE 0 END
,CASE WHEN Galeria = 'SI' THEN 1 ELSE 0 END
,null, null 
,Tipo, Orientacion, Zona, Estado, Extras, OTrasOBservaciones 

,CASE WHEN chollo = 'SI' THEN 1 ELSE 0 END
,CASE WHEN Escaparate = 'SI' THEN 1 ELSE 0 END
,CASE WHEN NOAlquiler = 'SI' THEN 0 ELSE 1 END
,CASE WHEN Ocultar = 'SI' THEN 1 ELSE 0 END
,CASE WHEN Cartel = 'SI' THEN 1 ELSE 0 END

,CASE WHEN Balcon = 'SI' THEN 1 ELSE 0 END, MBalcon , MBalcon2 
,CASE WHEN Patio = 'SI' THEN 1 ELSE 0 END, MPatio , MPatio2 
,CASE WHEN Terraza = 'SI' THEN 1 ELSE 0 END, MTerraza , MTerraza2 
,CASE WHEN Jardin = 'SI' THEN 1 ELSE 0 END, MJardin  

,MTrastero 

,CASE 
	WHEN TipoVenta = 'VENTA' AND Trastero = 'SI' THEN 1
	WHEN TipoVenta = 'VENTA' AND Trastero <> 'SI' THEN 0
END

,CASE 
	WHEN TipoVenta = 'ALQUILER' AND Trastero = 'SI' THEN 1
	WHEN TipoVenta = 'ALQUILER' AND Trastero <> 'SI' THEN 0
END
 
,CASE WHEN TipoVenta = 'VENTA' then PrecioTrastero  ELSE 0 END
,CASE WHEN TipoVenta = 'ALQUILER' then PrecioTrastero  ELSE 0 END

,MGaraje 
,CASE WHEN GarajeCerrado = 'SI' THEN 1 ELSE 0 END

,CASE 
	WHEN TipoVenta = 'VENTA' AND Garaje = 'SI' THEN 1
	WHEN TipoVenta = 'VENTA' AND Garaje <> 'SI' THEN 0
END

,CASE 
	WHEN TipoVenta = 'ALQUILER' AND Garaje = 'SI' THEN 1
	WHEN TipoVenta = 'ALQUILER' AND Garaje <> 'SI' THEN 0
END

 
,CASE WHEN TipoVenta = 'VENTA' then PrecioGaraje  ELSE 0 END
,CASE WHEN TipoVenta = 'ALQUILER' then PrecioGaraje  ELSE 0 END

,CASE WHEN SemiAmueblado = 'SI' then 1  ELSE 0 END
,CASE WHEN Amueblado = 'SI' then 1  ELSE 0 END
 
 
,CASE 	WHEN Electrodomesticos = 'SI' THEN 1 ELSE 0 end
	 

,null,null,null,null,null,null,null,null

,textoescaparate, FotoEscaparate,FotoEscaparate2,Foto
,TextoLlaves, '',null,null,null,null,null,null,null
FROM inmobiliaria.dbo.Inmuebles I


where TIPOVENTA  = 'VENTA' --or   TIPOVENTA ='ALQUILER'
order by REFERENCIA
    
 
--GO

UPDATE igis.dbo.inmuebles set Alquiler = 1   where Referencia in
(
select REFERENCIA from inmobiliaria.dbo.Inmuebles i1 inner join 
(
SELECT COUNT(*) AS CUENTA,MIN(tIPOVENTA) AS TIPO_MIN,MAX(TIPOVENTA) AS TIPO_MAX,MIN(REFERENCIA) AS REF_MIN, MAX(REFERENCIA) AS REF_MAX,  CODPROVEEDOR, DIRECCION,ALTURA,CP,POBLACION,PUERTA
,(SELECT NombreProveedor from inmobiliaria.dbo.Proveedores p where p.codproveedor = i2.CodProveedor) as Propietario
 FROM inmobiliaria.dbo.Inmuebles i2 GROUP BY  CODPROVEEDOR, DIRECCION,ALTURA,CP,POBLACION,PUERTA
HAVING COUNT(*) = 2 AND MIN(tIPOVENTA) = 'ALQUILER' AND    MAX(tIPOVENTA) = 'VENTA') AS I3
on  I1.CodProveedor = I3.CODPROVEEDOR AND I1.DIRECCION = I3.DIRECCION AND I1.ALTURA = I3.ALTURA AND I1.CP = I3.CP AND I1.POBLACION = I3.POBLACION AND I1.PUERTA = I3.PUERTA
WHERE i1.TipoVenta = 'VENTA' )

UPDATE igis.dbo.inmuebles set PrecioAlquiler = Precio, PrecioPropietarioAlquiler  = PrecioProveedor
FROM igis.dbo.inmuebles I1 INNER JOIN Inmobiliaria.DBO.Inmuebles I3 
 on  (SELECT CodProveedorViejo fROM Propietarios where Contador = i1.ContadorPropietario  ) = I3.CODPROVEEDOR AND I1.DIRECCION = I3.DIRECCION AND I1.ALTURA = I3.ALTURA AND I1.CodPostal = I3.CP AND I1.POBLACION = I3.POBLACION AND I1.PUERTA = I3.PUERTA
WHERE i1.aLQUILER   = 1 and   i3.TipoVenta = 'ALQUILER' 



  



INSERT INTO IGIS.dbo.INMUEBLES 
SELECT Referencia, @CodigoEmpresa, Delegacion
, (SELECT ContadoR  FROM Empleados E inner join  Inmobiliaria.dbo.Usuarios u on e.nombre = u.nombre WHERE u.Codigo = I.CodComercial)
, (SELECT Contador FROM Propietarios WHERE CodProveedorViejo = I.CodProveedor)
,CASE WHEN Reservado = 'SI' THEN 1 ELSE 0 END
,Fecha,FechaEnVenta,FechaVencimiento 

,CASE WHEN TipoVenta = 'VENTA' THEN 1 ELSE 0 END
,CASE WHEN TipoVenta = 'ALQUILER' THEN 1 ELSE 0 END
,CASE WHEN AlquilerOpcionCompra = 'SI' THEN 1 ELSE 0 END
,CASE WHEN TipoVenta = 'VERANO' THEN 1 ELSE 0 END
,CASE WHEN TipoVenta = 'TRASPASO' THEN 1 ELSE 0 END

,0
,CASE WHEN Llaves = 'SI' THEN 1 ELSE 0 END

,CASE WHEN TipoVenta = 'VENTA' THEN Precio ELSE 0 END
,CASE WHEN TipoVenta = 'ALQUILER' THEN Precio ELSE 0 END
,CASE WHEN TipoVenta = 'VERANO' THEN Precio ELSE 0 END
,CASE WHEN TipoVenta = 'TRASPASO' THEN Precio ELSE 0 END

,CASE WHEN TipoVenta = 'VENTA' THEN PrecioProveedor  ELSE 0 END
,CASE WHEN TipoVenta = 'ALQUILER' THEN PrecioProveedor ELSE 0 END
,CASE WHEN TipoVenta = 'VERANO' THEN PrecioProveedor ELSE 0 END
,CASE WHEN TipoVenta = 'VERANO' THEN Precio ELSE 0 END
,CASE WHEN TipoVenta = 'VERANO' THEN Precio ELSE 0 END
,CASE WHEN TipoVenta = 'TRASPASO' THEN PrecioProveedor ELSE 0 END

,Gastos
 

,Direccion,Num,Altura,CP,Poblacion, 
case when provincia is null then '' else provincia end
 , Puerta
,Metros ,Banos ,Habitaciones,Anos ,MPlaya

,CASE WHEN Ascensor = 'SI' THEN 1 ELSE 0 END
,CASE WHEN CocinaOffice = 'SI' THEN 1 ELSE 0 END
,CASE WHEN Piscina = 'SI' THEN 1 ELSE 0 END
,CASE WHEN Duplex = 'SI' THEN 1 ELSE 0 END
,CASE WHEN Galeria = 'SI' THEN 1 ELSE 0 END
,null, null 
,Tipo, Orientacion, Zona, Estado, Extras, OTrasOBservaciones 

,CASE WHEN chollo = 'SI' THEN 1 ELSE 0 END
,CASE WHEN Escaparate = 'SI' THEN 1 ELSE 0 END
,CASE WHEN NOAlquiler = 'SI' THEN 0 ELSE 1 END
,CASE WHEN Ocultar = 'SI' THEN 1 ELSE 0 END
,CASE WHEN Cartel = 'SI' THEN 1 ELSE 0 END

,CASE WHEN Balcon = 'SI' THEN 1 ELSE 0 END, MBalcon , MBalcon2 
,CASE WHEN Patio = 'SI' THEN 1 ELSE 0 END, MPatio , MPatio2 
,CASE WHEN Terraza = 'SI' THEN 1 ELSE 0 END, MTerraza , MTerraza2 
,CASE WHEN Jardin = 'SI' THEN 1 ELSE 0 END, MJardin  

,MTrastero 

,CASE 
	WHEN TipoVenta = 'VENTA' AND Trastero = 'SI' THEN 1
	WHEN TipoVenta = 'VENTA' AND Trastero <> 'SI' THEN 0
END

,CASE 
	WHEN TipoVenta = 'ALQUILER' AND Trastero = 'SI' THEN 1
	WHEN TipoVenta = 'ALQUILER' AND Trastero <> 'SI' THEN 0
END
 
,CASE WHEN TipoVenta = 'VENTA' then PrecioTrastero  ELSE 0 END
,CASE WHEN TipoVenta = 'ALQUILER' then PrecioTrastero  ELSE 0 END

,MGaraje 
,CASE WHEN GarajeCerrado = 'SI' THEN 1 ELSE 0 END

,CASE 
	WHEN TipoVenta = 'VENTA' AND Garaje = 'SI' THEN 1
	WHEN TipoVenta = 'VENTA' AND Garaje <> 'SI' THEN 0
END

,CASE 
	WHEN TipoVenta = 'ALQUILER' AND Garaje = 'SI' THEN 1
	WHEN TipoVenta = 'ALQUILER' AND Garaje <> 'SI' THEN 0
END

 
,CASE WHEN TipoVenta = 'VENTA' then PrecioGaraje  ELSE 0 END
,CASE WHEN TipoVenta = 'ALQUILER' then PrecioGaraje  ELSE 0 END

,CASE WHEN SemiAmueblado = 'SI' then 1  ELSE 0 END
,CASE WHEN Amueblado = 'SI' then 1  ELSE 0 END
 
 
,CASE 	WHEN Electrodomesticos = 'SI' THEN 1 ELSE 0 end
	 

,null,null,null,null,null,null,null,null

,textoescaparate, FotoEscaparate,FotoEscaparate2,Foto
,TextoLlaves, '',null,null,null,null,null,null,null
FROM inmobiliaria.dbo.Inmuebles I


where TIPOVENTA  = 'ALQUILER' AND Referencia NOT IN
(
select REFERENCIA from inmobiliaria.dbo.Inmuebles i1 inner join 
(
SELECT COUNT(*) AS CUENTA,MIN(tIPOVENTA) AS TIPO_MIN,MAX(TIPOVENTA) AS TIPO_MAX,MIN(REFERENCIA) AS REF_MIN, MAX(REFERENCIA) AS REF_MAX,  CODPROVEEDOR, DIRECCION,ALTURA,CP,POBLACION,PUERTA
,(SELECT NombreProveedor from inmobiliaria.dbo.Proveedores p where p.codproveedor = i2.CodProveedor) as Propietario
 FROM inmobiliaria.dbo.Inmuebles i2 GROUP BY  CODPROVEEDOR, DIRECCION,ALTURA,CP,POBLACION,PUERTA
HAVING COUNT(*) = 2 AND MIN(tIPOVENTA) = 'ALQUILER' AND    MAX(tIPOVENTA) = 'VENTA') AS I3

on  I1.CodProveedor = I3.CODPROVEEDOR AND I1.DIRECCION = I3.DIRECCION AND I1.ALTURA = I3.ALTURA AND I1.CP = I3.CP AND I1.POBLACION = I3.POBLACION AND I1.PUERTA = I3.PUERTA

WHERE i1.TipoVenta = 'ALQUILER' )
order by REFERENCIA
    
--go

UPDATE igis.dbo.inmuebles set verano = 1 where Referencia in
(
select REFERENCIA from inmobiliaria.dbo.Inmuebles i1 inner join 
(
SELECT COUNT(*) AS CUENTA,MIN(tIPOVENTA) AS TIPO_MIN,MAX(TIPOVENTA) AS TIPO_MAX,MIN(REFERENCIA) AS REF_MIN, MAX(REFERENCIA) AS REF_MAX,  CODPROVEEDOR, DIRECCION,ALTURA,CP,POBLACION,PUERTA
,(SELECT NombreProveedor from inmobiliaria.dbo.Proveedores p where p.codproveedor = i2.CodProveedor) as Propietario
 FROM inmobiliaria.dbo.Inmuebles i2 GROUP BY  CODPROVEEDOR, DIRECCION,ALTURA,CP,POBLACION,PUERTA
HAVING COUNT(*) = 3 AND MIN(tIPOVENTA) = 'ALQUILER' AND    MAX(tIPOVENTA) = 'VERANO') AS I3

on  I1.CodProveedor = I3.CODPROVEEDOR AND I1.DIRECCION = I3.DIRECCION AND I1.ALTURA = I3.ALTURA AND I1.CP = I3.CP AND I1.POBLACION = I3.POBLACION AND I1.PUERTA = I3.PUERTA

WHERE i1.TipoVenta = 'VENTA' )

 
UPDATE igis.dbo.inmuebles set verano = 1 where Referencia in
(
select REFERENCIA from inmobiliaria.dbo.Inmuebles i1 inner join 
(
SELECT COUNT(*) AS CUENTA,MIN(tIPOVENTA) AS TIPO_MIN,MAX(TIPOVENTA) AS TIPO_MAX,MIN(REFERENCIA) AS REF_MIN, MAX(REFERENCIA) AS REF_MAX,  CODPROVEEDOR, DIRECCION,ALTURA,CP,POBLACION,PUERTA
,(SELECT NombreProveedor from inmobiliaria.dbo.Proveedores p where p.codproveedor = i2.CodProveedor) as Propietario
 FROM inmobiliaria.dbo.Inmuebles i2 GROUP BY  CODPROVEEDOR, DIRECCION,ALTURA,CP,POBLACION,PUERTA
HAVING COUNT(*) = 2 AND MIN(tIPOVENTA) = 'ALQUILER' AND    MAX(tIPOVENTA) = 'VERANO') AS I3

on  I1.CodProveedor = I3.CODPROVEEDOR AND I1.DIRECCION = I3.DIRECCION AND I1.ALTURA = I3.ALTURA AND I1.CP = I3.CP AND I1.POBLACION = I3.POBLACION AND I1.PUERTA = I3.PUERTA

WHERE i1.TipoVenta = 'ALQUILER' )

--go
UPDATE igis.dbo.inmuebles set verano = 1 where Referencia in
(
select REFERENCIA from inmobiliaria.dbo.Inmuebles i1 inner join 
(
SELECT COUNT(*) AS CUENTA,MIN(tIPOVENTA) AS TIPO_MIN,MAX(TIPOVENTA) AS TIPO_MAX,MIN(REFERENCIA) AS REF_MIN, MAX(REFERENCIA) AS REF_MAX,  CODPROVEEDOR, DIRECCION,ALTURA,CP,POBLACION,PUERTA
,(SELECT NombreProveedor from inmobiliaria.dbo.Proveedores p where p.codproveedor = i2.CodProveedor) as Propietario
 FROM inmobiliaria.dbo.Inmuebles i2 GROUP BY  CODPROVEEDOR, DIRECCION,ALTURA,CP,POBLACION,PUERTA
HAVING COUNT(*) = 2 AND MIN(tIPOVENTA) = 'VENTA' AND    MAX(tIPOVENTA) = 'VERANO') AS I3

on  I1.CodProveedor = I3.CODPROVEEDOR AND I1.DIRECCION = I3.DIRECCION AND I1.ALTURA = I3.ALTURA AND I1.CP = I3.CP AND I1.POBLACION = I3.POBLACION AND I1.PUERTA = I3.PUERTA

WHERE i1.TipoVenta = 'VENTA' )



UPDATE igis.dbo.inmuebles set PrecioVeranoJunio = Precio, PrecioVeranoJulio = Precio, PrecioVeranoAgosto  = Precio, PrecioPropietarioverano  = PrecioProveedor
FROM igis.dbo.inmuebles I1 INNER JOIN Inmobiliaria.DBO.Inmuebles I3 
 on  (SELECT CodProveedorViejo fROM Propietarios where Contador = i1.ContadorPropietario  ) = I3.CODPROVEEDOR AND I1.DIRECCION = I3.DIRECCION AND I1.ALTURA = I3.ALTURA AND I1.CodPostal = I3.CP AND I1.POBLACION = I3.POBLACION AND I1.PUERTA = I3.PUERTA
WHERE i1.VERANO   = 1 and   i3.TipoVenta = 'VERANO' 

 

INSERT INTO IGIS.dbo.INMUEBLES 
SELECT Referencia, @CodigoEmpresa, Delegacion
, (SELECT ContadoR  FROM Empleados E inner join  Inmobiliaria.dbo.Usuarios u on e.nombre = u.nombre WHERE u.Codigo = I.CodComercial)
, (SELECT Contador FROM Propietarios WHERE CodProveedorViejo = I.CodProveedor)
,CASE WHEN Reservado = 'SI' THEN 1 ELSE 0 END
,Fecha,FechaEnVenta,FechaVencimiento 

,CASE WHEN TipoVenta = 'VENTA' THEN 1 ELSE 0 END
,CASE WHEN TipoVenta = 'ALQUILER' THEN 1 ELSE 0 END
,CASE WHEN AlquilerOpcionCompra = 'SI' THEN 1 ELSE 0 END
,CASE WHEN TipoVenta = 'VERANO' THEN 1 ELSE 0 END
,CASE WHEN TipoVenta = 'TRASPASO' THEN 1 ELSE 0 END

,0
,CASE WHEN Llaves = 'SI' THEN 1 ELSE 0 END

,CASE WHEN TipoVenta = 'VENTA' THEN Precio ELSE 0 END
,CASE WHEN TipoVenta = 'ALQUILER' THEN Precio ELSE 0 END
,CASE WHEN TipoVenta = 'VERANO' THEN Precio ELSE 0 END
,CASE WHEN TipoVenta = 'VERANO' THEN Precio ELSE 0 END
,CASE WHEN TipoVenta = 'VERANO' THEN Precio ELSE 0 END
,CASE WHEN TipoVenta = 'TRASPASO' THEN Precio ELSE 0 END

,CASE WHEN TipoVenta = 'VENTA' THEN PrecioProveedor  ELSE 0 END
,CASE WHEN TipoVenta = 'ALQUILER' THEN PrecioProveedor ELSE 0 END
,CASE WHEN TipoVenta = 'VERANO' THEN PrecioProveedor ELSE 0 END
,CASE WHEN TipoVenta = 'TRASPASO' THEN PrecioProveedor ELSE 0 END

,Gastos

--,CASE WHEN TipoVenta = 'VENTA' AND PN = 'SI' THEN 1 ELSE 0 END
--,CASE WHEN TipoVenta = 'ALQUILER' AND PN = 'SI' THEN 1 ELSE 0 END
--,CASE WHEN TipoVenta = 'VERANO' AND PN = 'SI' THEN 1 ELSE 0 END
--,CASE WHEN TipoVenta = 'TRASPASO' AND PN = 'SI' THEN 1 ELSE 0 END
  
--,CASE WHEN TipoVenta = 'VENTA' THEN Gastos  ELSE '' END
--,CASE WHEN TipoVenta = 'ALQUILER' THEN Gastos ELSE '' END
--,CASE WHEN TipoVenta = 'VERANO' THEN Gastos ELSE '' END
--,CASE WHEN TipoVenta = 'TRASPASO' THEN Gastos ELSE '' END


,Direccion,Num,Altura,CP,Poblacion, 
case when provincia is null then '' else provincia end
 , Puerta
,Metros ,Banos ,Habitaciones,Anos ,MPlaya

,CASE WHEN Ascensor = 'SI' THEN 1 ELSE 0 END
,CASE WHEN CocinaOffice = 'SI' THEN 1 ELSE 0 END
,CASE WHEN Piscina = 'SI' THEN 1 ELSE 0 END
,CASE WHEN Duplex = 'SI' THEN 1 ELSE 0 END
,CASE WHEN Galeria = 'SI' THEN 1 ELSE 0 END
,null, null 
,Tipo, Orientacion, Zona, Estado, Extras, OTrasOBservaciones 

,CASE WHEN chollo = 'SI' THEN 1 ELSE 0 END
,CASE WHEN Escaparate = 'SI' THEN 1 ELSE 0 END
,CASE WHEN NOAlquiler = 'SI' THEN 0 ELSE 1 END
,CASE WHEN Ocultar = 'SI' THEN 1 ELSE 0 END
,CASE WHEN Cartel = 'SI' THEN 1 ELSE 0 END

,CASE WHEN Balcon = 'SI' THEN 1 ELSE 0 END, MBalcon , MBalcon2 
,CASE WHEN Patio = 'SI' THEN 1 ELSE 0 END, MPatio , MPatio2 
,CASE WHEN Terraza = 'SI' THEN 1 ELSE 0 END, MTerraza , MTerraza2 
,CASE WHEN Jardin = 'SI' THEN 1 ELSE 0 END, MJardin  

,MTrastero 

,CASE 
	WHEN TipoVenta = 'VENTA' AND Trastero = 'SI' THEN 1
	WHEN TipoVenta = 'VENTA' AND Trastero <> 'SI' THEN 0
END

,CASE 
	WHEN TipoVenta = 'ALQUILER' AND Trastero = 'SI' THEN 1
	WHEN TipoVenta = 'ALQUILER' AND Trastero <> 'SI' THEN 0
END
 
,CASE WHEN TipoVenta = 'VENTA' then PrecioTrastero  ELSE 0 END
,CASE WHEN TipoVenta = 'ALQUILER' then PrecioTrastero  ELSE 0 END

,MGaraje 
,CASE WHEN GarajeCerrado = 'SI' THEN 1 ELSE 0 END

,CASE 
	WHEN TipoVenta = 'VENTA' AND Garaje = 'SI' THEN 1
	WHEN TipoVenta = 'VENTA' AND Garaje <> 'SI' THEN 0
END

,CASE 
	WHEN TipoVenta = 'ALQUILER' AND Garaje = 'SI' THEN 1
	WHEN TipoVenta = 'ALQUILER' AND Garaje <> 'SI' THEN 0
END

 
,CASE WHEN TipoVenta = 'VENTA' then PrecioGaraje  ELSE 0 END
,CASE WHEN TipoVenta = 'ALQUILER' then PrecioGaraje  ELSE 0 END

,CASE WHEN SemiAmueblado = 'SI' then 1  ELSE 0 END
,CASE WHEN Amueblado = 'SI' then 1  ELSE 0 END
 
 
,CASE 	WHEN Electrodomesticos = 'SI' THEN 1 ELSE 0 end
	 


,null,null,null,null,null,null,null,null

,textoescaparate, FotoEscaparate,FotoEscaparate2,Foto
,TextoLlaves, '',null,null,null,null,null,null,null
FROM inmobiliaria.dbo.Inmuebles I


 where TIPOVENTA  = 'VERANO' 
AND REFERENCIA NOT IN
(
select REFERENCIA from inmobiliaria.dbo.Inmuebles i1 inner join 
(
SELECT COUNT(*) AS CUENTA,MIN(tIPOVENTA) AS TIPO_MIN,MAX(TIPOVENTA) AS TIPO_MAX,MIN(REFERENCIA) AS REF_MIN, MAX(REFERENCIA) AS REF_MAX,  CODPROVEEDOR, DIRECCION,ALTURA,CP,POBLACION,PUERTA
,(SELECT NombreProveedor from inmobiliaria.dbo.Proveedores p where p.codproveedor = i2.CodProveedor) as Propietario
 FROM inmobiliaria.dbo.Inmuebles i2 GROUP BY  CODPROVEEDOR, DIRECCION,ALTURA,CP,POBLACION,PUERTA
HAVING COUNT(*) = 2 AND MIN(tIPOVENTA) = 'VENTA' AND    MAX(tIPOVENTA) = 'VERANO') AS I3

on  I1.CodProveedor = I3.CODPROVEEDOR AND I1.DIRECCION = I3.DIRECCION AND I1.ALTURA = I3.ALTURA AND I1.CP = I3.CP AND I1.POBLACION = I3.POBLACION AND I1.PUERTA = I3.PUERTA

WHERE i1.TipoVenta = 'VERANO' )

AND Referencia NOT IN
 
(
select REFERENCIA from inmobiliaria.dbo.Inmuebles i1 inner join 
(
SELECT COUNT(*) AS CUENTA,MIN(tIPOVENTA) AS TIPO_MIN,MAX(TIPOVENTA) AS TIPO_MAX,MIN(REFERENCIA) AS REF_MIN, MAX(REFERENCIA) AS REF_MAX,  CODPROVEEDOR, DIRECCION,ALTURA,CP,POBLACION,PUERTA
,(SELECT NombreProveedor from inmobiliaria.dbo.Proveedores p where p.codproveedor = i2.CodProveedor) as Propietario
 FROM inmobiliaria.dbo.Inmuebles i2 GROUP BY  CODPROVEEDOR, DIRECCION,ALTURA,CP,POBLACION,PUERTA
HAVING COUNT(*) = 3 AND MIN(tIPOVENTA) = 'ALQUILER' AND    MAX(tIPOVENTA) = 'VERANO') AS I3

on  I1.CodProveedor = I3.CODPROVEEDOR AND I1.DIRECCION = I3.DIRECCION AND I1.ALTURA = I3.ALTURA AND I1.CP = I3.CP AND I1.POBLACION = I3.POBLACION AND I1.PUERTA = I3.PUERTA

WHERE i1.TipoVenta = 'VERANO' )

AND Referencia NOT IN
(
select REFERENCIA from inmobiliaria.dbo.Inmuebles i1 inner join 
(
SELECT COUNT(*) AS CUENTA,MIN(tIPOVENTA) AS TIPO_MIN,MAX(TIPOVENTA) AS TIPO_MAX,MIN(REFERENCIA) AS REF_MIN, MAX(REFERENCIA) AS REF_MAX,  CODPROVEEDOR, DIRECCION,ALTURA,CP,POBLACION,PUERTA
,(SELECT NombreProveedor from inmobiliaria.dbo.Proveedores p where p.codproveedor = i2.CodProveedor) as Propietario
 FROM inmobiliaria.dbo.Inmuebles i2 GROUP BY  CODPROVEEDOR, DIRECCION,ALTURA,CP,POBLACION,PUERTA
HAVING COUNT(*) = 2 AND MIN(tIPOVENTA) = 'ALQUILER' AND    MAX(tIPOVENTA) = 'VERANO') AS I3

on  I1.CodProveedor = I3.CODPROVEEDOR AND I1.DIRECCION = I3.DIRECCION AND I1.ALTURA = I3.ALTURA AND I1.CP = I3.CP AND I1.POBLACION = I3.POBLACION AND I1.PUERTA = I3.PUERTA

WHERE i1.TipoVenta = 'VERANO' )


--*************
INSERT INTO IGIS.dbo.INMUEBLES 
SELECT Referencia, @CodigoEmpresa, Delegacion
, (SELECT ContadoR  FROM Empleados E inner join  Inmobiliaria.dbo.Usuarios u on e.nombre = u.nombre WHERE u.Codigo = I.CodComercial)
, (SELECT Contador FROM Propietarios WHERE CodProveedorViejo = I.CodProveedor)
,CASE WHEN Reservado = 'SI' THEN 1 ELSE 0 END
,Fecha,FechaEnVenta,FechaVencimiento 

,CASE WHEN TipoVenta = 'VENTA' THEN 1 ELSE 0 END
,CASE WHEN TipoVenta = 'ALQUILER' THEN 1 ELSE 0 END
,CASE WHEN AlquilerOpcionCompra = 'SI' THEN 1 ELSE 0 END
,CASE WHEN TipoVenta = 'VERANO' THEN 1 ELSE 0 END
,CASE WHEN TipoVenta = 'TRASPASO' THEN 1 ELSE 0 END

,0
,CASE WHEN Llaves = 'SI' THEN 1 ELSE 0 END

,CASE WHEN TipoVenta = 'VENTA' THEN Precio ELSE 0 END
,CASE WHEN TipoVenta = 'ALQUILER' THEN Precio ELSE 0 END
,CASE WHEN TipoVenta = 'VERANO' THEN Precio ELSE 0 END
,CASE WHEN TipoVenta = 'VERANO' THEN Precio ELSE 0 END
,CASE WHEN TipoVenta = 'VERANO' THEN Precio ELSE 0 END
,CASE WHEN TipoVenta = 'TRASPASO' THEN Precio ELSE 0 END

,CASE WHEN TipoVenta = 'VENTA' THEN PrecioProveedor  ELSE 0 END
,CASE WHEN TipoVenta = 'ALQUILER' THEN PrecioProveedor ELSE 0 END
,CASE WHEN TipoVenta = 'VERANO' THEN PrecioProveedor ELSE 0 END
,CASE WHEN TipoVenta = 'TRASPASO' THEN PrecioProveedor ELSE 0 END

,Gastos

--,CASE WHEN TipoVenta = 'VENTA' AND PN = 'SI' THEN 1 ELSE 0 END
--,CASE WHEN TipoVenta = 'ALQUILER' AND PN = 'SI' THEN 1 ELSE 0 END
--,CASE WHEN TipoVenta = 'VERANO' AND PN = 'SI' THEN 1 ELSE 0 END
--,CASE WHEN TipoVenta = 'TRASPASO' AND PN = 'SI' THEN 1 ELSE 0 END
  
--,CASE WHEN TipoVenta = 'VENTA' THEN Gastos  ELSE '' END
--,CASE WHEN TipoVenta = 'ALQUILER' THEN Gastos ELSE '' END
--,CASE WHEN TipoVenta = 'VERANO' THEN Gastos ELSE '' END
--,CASE WHEN TipoVenta = 'TRASPASO' THEN Gastos ELSE '' END


,Direccion,Num,Altura,CP,Poblacion, 
case when provincia is null then '' else provincia end
 , Puerta
,Metros ,Banos ,Habitaciones,Anos ,MPlaya

,CASE WHEN Ascensor = 'SI' THEN 1 ELSE 0 END
,CASE WHEN CocinaOffice = 'SI' THEN 1 ELSE 0 END
,CASE WHEN Piscina = 'SI' THEN 1 ELSE 0 END
,CASE WHEN Duplex = 'SI' THEN 1 ELSE 0 END
,CASE WHEN Galeria = 'SI' THEN 1 ELSE 0 END
,null, null 
,Tipo, Orientacion, Zona, Estado, Extras, OTrasOBservaciones 

,CASE WHEN chollo = 'SI' THEN 1 ELSE 0 END
,CASE WHEN Escaparate = 'SI' THEN 1 ELSE 0 END
,CASE WHEN NOAlquiler = 'SI' THEN 0 ELSE 1 END
,CASE WHEN Ocultar = 'SI' THEN 1 ELSE 0 END
,CASE WHEN Cartel = 'SI' THEN 1 ELSE 0 END

,CASE WHEN Balcon = 'SI' THEN 1 ELSE 0 END, MBalcon , MBalcon2 
,CASE WHEN Patio = 'SI' THEN 1 ELSE 0 END, MPatio , MPatio2 
,CASE WHEN Terraza = 'SI' THEN 1 ELSE 0 END, MTerraza , MTerraza2 
,CASE WHEN Jardin = 'SI' THEN 1 ELSE 0 END, MJardin  

,MTrastero 

,CASE 
	WHEN TipoVenta = 'VENTA' AND Trastero = 'SI' THEN 1
	WHEN TipoVenta = 'VENTA' AND Trastero <> 'SI' THEN 0
END

,CASE 
	WHEN TipoVenta = 'ALQUILER' AND Trastero = 'SI' THEN 1
	WHEN TipoVenta = 'ALQUILER' AND Trastero <> 'SI' THEN 0
END
 
,CASE WHEN TipoVenta = 'VENTA' then PrecioTrastero  ELSE 0 END
,CASE WHEN TipoVenta = 'ALQUILER' then PrecioTrastero  ELSE 0 END

,MGaraje 
,CASE WHEN GarajeCerrado = 'SI' THEN 1 ELSE 0 END

,CASE 
	WHEN TipoVenta = 'VENTA' AND Garaje = 'SI' THEN 1
	WHEN TipoVenta = 'VENTA' AND Garaje <> 'SI' THEN 0
END

,CASE 
	WHEN TipoVenta = 'ALQUILER' AND Garaje = 'SI' THEN 1
	WHEN TipoVenta = 'ALQUILER' AND Garaje <> 'SI' THEN 0
END

 
,CASE WHEN TipoVenta = 'VENTA' then PrecioGaraje  ELSE 0 END
,CASE WHEN TipoVenta = 'ALQUILER' then PrecioGaraje  ELSE 0 END

,CASE WHEN SemiAmueblado = 'SI' then 1  ELSE 0 END
,CASE WHEN Amueblado = 'SI' then 1  ELSE 0 END
 
 
,CASE 	WHEN Electrodomesticos = 'SI' THEN 1 ELSE 0 end
	 

,null,null,null,null,null,null,null,null

,textoescaparate, FotoEscaparate,FotoEscaparate2,Foto
,TextoLlaves, '',null,null,null,null,null,null,null
FROM inmobiliaria.dbo.Inmuebles I


 where TIPOVENTA  = 'TRASPASO' 


  