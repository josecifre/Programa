 
GO
/****** Object:  UserDefinedFunction [dbo].[F_Autenticacion]    Script Date: 02/06/2013 23:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 
CREATE FUNCTION [dbo].[F_Autenticacion] (@Usu varchar(50), @Pass varchar(50)) 
RETURNS VARCHAR(50)
AS
BEGIN
	DECLARE @PASS_ENCRIPTADA VARCHAR(500)
	DECLARE @BD_A_Devolver VARCHAR(50)

	SET @PASS_ENCRIPTADA = (select msdb.dbo.F_Encriptar (@Pass,'LAMBDAPI'))
	IF (SELECT COUNT(*) FROM netisempresas.dbo.Usuarios WHERE Usuario = @Usu AND Pass = @PASS_ENCRIPTADA ) > 0 
		SET @BD_A_Devolver = (SELECT TOP 1 E.BaseDatos  FROM netisempresas.dbo.Usuarios U INNER JOIN netisempresas.dbo.Empresas E ON U.EmpresaPredeterminada = E.Codigo  WHERE Usuario = @Usu AND Pass = @PASS_ENCRIPTADA )
	ELSE
		SET @BD_A_Devolver = ''

	RETURN @BD_A_Devolver
END

  --SELECT dbo.F_Autenticacion ('usu','pass')
GO
/****** Object:  UserDefinedFunction [dbo].[FechaActual]    Script Date: 02/06/2013 23:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create FUNCTION [dbo].[FechaActual] ()
RETURNS  VARCHAR(50) 
AS

BEGIN
DECLARE @FECHA VARCHAR(50)
	SET @FECHA =   (SELECT CONVERT(VARCHAR(50), GETDATE(),112))
	RETURN @FECHA
END


GO
/****** Object:  UserDefinedFunction [dbo].[HoraActual]    Script Date: 02/06/2013 23:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create FUNCTION [dbo].[HoraActual] ()
RETURNS  VARCHAR(50) 
AS

BEGIN
DECLARE @HORA VARCHAR(50)
	SET @HORA = '19000101 ' + (SELECT CONVERT(VARCHAR(50), GETDATE(),108))
	RETURN @HORA
END


GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 02/06/2013 23:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clientes](
	[Codigo] [varchar](50) NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[Baja] [bit] NOT NULL,
	[Nombre] [varchar](150) NOT NULL,
	[NIF] [varchar](50) NOT NULL,
	[NombreComercial] [varchar](50) NOT NULL,
	[Direccion] [varchar](250) NOT NULL,
	[Poblacion] [varchar](150) NOT NULL,
	[CodPostal] [varchar](50) NOT NULL,
	[Provincia] [varchar](50) NOT NULL,
	[Pais] [varchar](50) NOT NULL,
	[Telefono1] [varchar](50) NOT NULL,
	[Telefono2] [varchar](50) NOT NULL,
	[TelefonoMovil] [varchar](50) NOT NULL,
	[Fax] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Web] [varchar](155) NOT NULL,
	[Observaciones] [varchar](1050) NOT NULL,


	 
 CONSTRAINT [PK__Clientes__06370DADDC86A53F] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO


 select * from usuarios
  select * from Empleados 

/****** Object:  Table [dbo].[EmailConfiguracion]    Script Date: 02/06/2013 23:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[EmailConfiguracion](
	[EMail] [varchar](150) NOT NULL,
	[Usuario] [varchar](150) NOT NULL,
	[NombreMostrar] [varchar](150) NOT NULL,
	[Contrasena] [varchar](150) NOT NULL,
	[SMTP] [varchar](150) NOT NULL,
	[POP3Host] [varchar](150) NOT NULL,
	[Puerto] [int] NOT NULL,
	[Asunto] [varchar](150) NOT NULL,
	[Url] [varchar](150) NOT NULL,
	[Mensaje] [varchar](350) NOT NULL,
	[html] [varchar](50) NOT NULL,
	[SSL] [bit] NOT NULL,
 CONSTRAINT [PK_DatosConfiguracionEMail] PRIMARY KEY CLUSTERED 
(
	[EMail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmailsRecibidos]    Script Date: 02/06/2013 23:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmailsRecibidos](
	[Contador] [int] IDENTITY(1,1) NOT NULL,
	[TipoEmail] [varchar](50) NOT NULL,
	[Documento] [varchar](50) NOT NULL,
	[ContadorDocumento] [int] NULL,
	[Fecha] [datetime] NOT NULL,
	[Asunto] [varchar](450) NOT NULL,
	[De] [varchar](150) NOT NULL,
	[Descripcion] [ntext] NOT NULL,
 CONSTRAINT [PK_EmailsAutorizacion] PRIMARY KEY CLUSTERED 
(
	[Contador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmailsRecibidosAdjuntos]    Script Date: 02/06/2013 23:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmailsRecibidosAdjuntos](
	[ContadorEmailRecibido] [int] NOT NULL,
	[Adjuntos] [varchar](250) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 02/06/2013 23:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empleados](
	[Codigo] [int] NOT NULL,
	[FechaAlta] [datetime] NULL,
	[Baja] [bit] NOT NULL,
	[Nombre] [varchar](150) NOT NULL,
	[NIF] [varchar](50) NOT NULL,
	[Alias] [varchar](50) NOT NULL,
	[Direccion] [varchar](250) NOT NULL,
	[Poblacion] [varchar](150) NOT NULL,
	[CodPostal] [varchar](50) NOT NULL,
	[Provincia] [varchar](50) NOT NULL,
	[Pais] [varchar](50) NOT NULL,
	[Telefono1] [varchar](50) NOT NULL,
	[Telefono2] [varchar](50) NOT NULL,
	[TelefonoMovil] [varchar](50) NOT NULL,
	[Fax] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Observaciones] [varchar](1050) NOT NULL,
	[BancoNombre] [varchar](50) NOT NULL,
	[BancoCuenta] [varchar](50) NOT NULL,
	[Comercial] [bit] NULL,
	[Agrupacion] [varchar](100) NOT NULL,
 CONSTRAINT [PK__Empleado__06370DAD25869641] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Empresas]    Script Date: 02/06/2013 23:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empresas](
	[Codigo] [int] NOT NULL,
	[FechaAlta] [datetime] NULL,
	[Nombre] [varchar](150) NULL,
	[NIF] [varchar](50) NULL,
	[NombreComercial] [varchar](50) NULL,
	[Direccion] [varchar](250) NULL,
	[Poblacion] [varchar](150) NULL,
	[CodPostal] [varchar](50) NULL,
	[Provincia] [varchar](50) NULL,
	[Pais] [varchar](50) NULL,
	[Telefono1] [varchar](50) NULL,
	[Telefono2] [varchar](50) NULL,
	[TelefonoMovil] [varchar](50) NULL,
	[Fax] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Web] [varchar](155) NULL,
	[Observaciones] [varchar](1050) NULL,
	[SerieFacturacionPredeterminada] [varchar](50) NULL,
	[IVAPredeterminado] [varchar](50) NULL,
	[FormaPagoPredeterminada] [varchar](100) NULL,
	[BancoPredeterminado] [varchar](100) NULL,
	[TarifaPredeterminada] [varchar](100) NULL,
	[AlmacenPredeterminado] [varchar](100) NULL,
	[FamiliaPredeterminada] [varchar](100) NULL,
	[MarcaPredeterminada] [varchar](100) NULL,
	[EmpleadoPredeterminado] [int] NULL,
	[AgrupacionPredeterminada] [varchar](100) NULL,
	[AplicarIVANulo] [bit] NULL,
	[AplicarRE] [bit] NULL,
	[Retencion] [float] NULL,
	[IVAIncluido] [bit] NULL,
	[AccesoVendedoresSoloASusPresupuestos] [bit] NULL,
 CONSTRAINT [PK__Empresas__06370DADEEB25907] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

   insert into igis.dbo.Empleados values(
  1,getdate(), 0, 'JOSE','','','','','','','','','','','','','','','',0,'')



/****** Object:  Index [IX_Clientes]    Script Date: 02/06/2013 23:14:31 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Clientes] ON [dbo].[Clientes]
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_FechaAlta]  DEFAULT (getdate()) FOR [FechaAlta]
GO
ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_NIF]  DEFAULT ('') FOR [NIF]
GO
ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_NombreComercial]  DEFAULT ('') FOR [NombreComercial]
GO
ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_Direccion]  DEFAULT ('') FOR [Direccion]
GO
ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_Observaciones]  DEFAULT ('') FOR [Observaciones]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Clientes] FOREIGN KEY([FormaPago])
REFERENCES [dbo].[FormasPago] ([Nombre])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Clientes]
GO
ALTER TABLE [dbo].[EmailsRecibidosAdjuntos]  WITH CHECK ADD  CONSTRAINT [FK_EmailsRecibidosAdjuntos_EmailsRecibidos] FOREIGN KEY([ContadorEmailRecibido])
REFERENCES [dbo].[EmailsRecibidos] ([Contador])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmailsRecibidosAdjuntos] CHECK CONSTRAINT [FK_EmailsRecibidosAdjuntos_EmailsRecibidos]
GO
/****** Object:  Trigger [dbo].[I_Clientes]    Script Date: 02/06/2013 23:14:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
GO
/****** Object:  Trigger [dbo].[I_Empleados]    Script Date: 02/06/2013 23:14:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
create TRIGGER [dbo].[I_Empresas]
ON [dbo].[Empresas]
after insert
AS 


 
	DECLARE @CodigoAntes  int
	DECLARE @Codigo  int
	DECLARE @BaseDatos varchar (50)
	DECLARE @Nombre  varchar(150)

	--SET @CodigoEnLaBaseDeDatos   = 1
	--SET @CodigoGlobal = CONVERT(VARCHAR(50),@CodigoEnLaBaseDeDatos) + (SELECT DB_NAME())
	--PRINT @CodigoGlobal

	SET @Codigo = (SELECT ISNULL( MAX(Codigo),0) from  IgisEmpresas.dbo.Empresas ) +1
	SET @BaseDatos = (SELECT DB_NAME())
	SET @Nombre = (SELECT Nombre from inserted)
	SET @CodigoAntes = (SELECT Codigo from inserted) 
 
	INSERT INTO IgisEmpresas.dbo.Empresas VALUES (@Codigo ,@BaseDatos,@Nombre)
	UPDATE Empresas set Codigo =  @Codigo  WHERE Codigo = @CodigoAntes


GO
/****** Object:  Trigger [dbo].[U_Empresas]    Script Date: 02/06/2013 23:14:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[U_Empresas]
ON [dbo].[Empresas]
AFTER update
AS 
 
 IF UPDATE (Nombre)
	
	BEGIN
		DECLARE @NombreAntes Varchar (150)
		DECLARE @NombreDespues Varchar (150)
		DECLARE @Codigo int
 

		SET @NombreAntes = (SELECT Nombre from deleted )
		SET @NombreDespues  = (SELECT Nombre from inserted  )
		SET @Codigo  = (SELECT Codigo from inserted  )

		update IgisEmpresas.dbo.Empresas set nombre = @nombredespues where Codigo = @Codigo 

	end

GO


SELECT * FROM IGIS.DBO.EMPRESAS
SELECT * FROM NETIS.DBO.EMPRESAS

INSERT INTO IGIS.DBO.EMPRESAS VALUES (
16,GETDATE(),'UIM' ,'','','','','','','','','','','','','','','','GENERAL','','','','','','',1,'',0,0,0,0,0)

select * from igis.dbo.Clientes


delete from igis.dbo.Clientes

	INSERT INTO igis.dbo.Clientes SELECT
CodCliente, Fecha, CodComercial, 0, Delegacion, 
case when TipoVenta1 = 'VENTA' THEN 1 ELSE 0 END, case when TipoVenta1 = 'ALQUILER' THEN 1 ELSE 0 END, 
case when AlquilerOpcionCompra = 'SI' THEN 1 ELSE 0 END, 
 NombreCliente, nifCliente, viaCliente + domicilioCliente, 
poblacionCliente, codpostalCliente, 
provinciaCliente, paisCliente, telefono1Cliente, telefono2Cliente, telefonomovilCliente, faxCliente, 
emailCliente, webCliente, otrasobservaciones,b,a,md,mh,pd,ph,hd,hh,pid,pih,balcon, patio, ascensor,
trastero, garaje,terraza,galeria,amueblado,semiamueblado, pisoascensor,piscina,duplex,garajecerrado,
Jardin, CocinaOffice, 0,
case when emailsino = 'NO' THEN 1 ELSE 0 END, 
case when emailsino = 'NO' THEN 1 ELSE 0 END, 
 CodigoComoConociste 
FROM inmobiliaria.dbo.Clientes

update   inmobiliaria.dbo.ClientesBaja set CodComercial = 1 where codcomercial is null
update   inmobiliaria.dbo.ClientesBaja set SemiAmueblado = '' where SemiAmueblado is null
delete from inmobiliaria.dbo.ClientesBaja where codcliente =11964
delete from inmobiliaria.dbo.ClientesBaja where codcliente =18918
delete from inmobiliaria.dbo.ClientesBaja where codcliente =18576
delete from inmobiliaria.dbo.ClientesBaja where codcliente = 
delete from inmobiliaria.dbo.ClientesBaja where codcliente = 


begin transaction
	INSERT INTO igis.dbo.Clientes SELECT
CodCliente, Fecha, CodComercial, 1, Delegacion, 
case when TipoVenta1 = 'VENTA' THEN 1 ELSE 0 END, case when TipoVenta1 = 'ALQUILER' THEN 1 ELSE 0 END, 
case when AlquilerOpcionCompra = 'SI' THEN 1 ELSE 0 END, 
 NombreCliente, nifCliente, viaCliente + domicilioCliente, 
poblacionCliente, codpostalCliente, 
provinciaCliente, paisCliente, telefono1Cliente, telefono2Cliente, telefonomovilCliente, faxCliente, 
emailCliente, webCliente, otrasobservaciones,b,a,md,mh,pd,ph,hd,hh,pid,pih,balcon, patio, ascensor,
trastero, garaje,terraza,galeria,amueblado,semiamueblado, pisoascensor,piscina,duplex,garajecerrado,
Jardin, CocinaOffice, 0,
case when emailsino = 'NO' THEN 1 ELSE 0 END, 
case when emailsino = 'NO' THEN 1 ELSE 0 END, 
 CodigoComoConociste 
FROM inmobiliaria.dbo.ClientesBaja where codcliente not in (SELECT CodCliente FROM inmobiliaria.dbo.Clientes)
commit


alter table clientes 
add   Agrupacion varchar (50) 
go

update clientes SET Agrupacion = ''
					 
go
alter table clientes 
alter column   Agrupacion varchar (50) not null
go
  

select * from inmobiliaria.dbo.Clientes order by AliasCliente desc

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Agrupaciones](
	[Agrupacion] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Agrupaciones] PRIMARY KEY CLUSTERED 
(
	[Agrupacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
insert into Agrupaciones values ('')

create Table ClientesEstado (
CodigoCliente varchar (50) not null,
Estado Varchar(50) not null,
)
go
alter table ClientesEstado
add constraint pk_ClientesEstado primary key (CodigoCliente,Estado)
go

SET ANSI_PADDING OFF
GO


delete from ClientesEstado
go

DECLARE @CodCliente VARCHAR(50)
DECLARE @Estado1 VARCHAR(50)
DECLARE @Estado2 VARCHAR(50)
DECLARE @Estado3 VARCHAR(50)
DECLARE @Estado4 VARCHAR(50)
DECLARE @Estado5 VARCHAR(50)
DECLARE @Estado6 VARCHAR(50)
DECLARE @Estado7 VARCHAR(50)
DECLARE @Estado8 VARCHAR(50)
DECLARE @Estado9 VARCHAR(50)
DECLARE @Estado10 VARCHAR(50)

  

DECLARE csr CURSOR FOR  
SELECT CodCliente, Estado1, Estado2, Estado3, Estado4, Estado5, Estado6, Estado7, Estado8, Estado9, Estado10
  from inmobiliaria.dbo.Clientes 
  

OPEN csr   
FETCH NEXT FROM csr INTO  @CodCliente, @Estado1, @Estado2, @Estado3, @Estado4, @Estado5, @Estado6, @Estado7, @Estado8, @Estado9, @Estado10   

WHILE @@FETCH_STATUS = 0   
BEGIN   

	
      if @Estado1 <> ''
		insert into ClientesEstado values (@CodCliente,@Estado1)

      if @Estado2 <> ''
		insert into ClientesEstado values (@CodCliente,@Estado2)

      if @Estado3<> ''
		insert into ClientesEstado values (@CodCliente,@Estado3)

      if @Estado4 <> ''
		insert into ClientesEstado values (@CodCliente,@Estado4)

      if @Estado5 <> ''
		insert into ClientesEstado values (@CodCliente,@Estado5)

      if @Estado6 <> ''
		insert into ClientesEstado values (@CodCliente,@Estado6)

		if @Estado7 <> ''
			insert into ClientesEstado values (@CodCliente,@Estado7)

		if @Estado8 <> ''
				insert into ClientesEstado values (@CodCliente,@Estado8)

		if @Estado9 <> ''
				insert into ClientesEstado values (@CodCliente,@Estado9)

		if @Estado10 <> ''
				insert into ClientesEstado values (@CodCliente,@Estado10)

		 

      FETCH NEXT FROM csr INTO @CodCliente, @Estado1, @Estado2, @Estado3, @Estado4, @Estado5, @Estado6, @Estado7, @Estado8, @Estado9, @Estado10  
END   

CLOSE csr   
DEALLOCATE csr 



DECLARE @CodCliente VARCHAR(50)
DECLARE @Estado1 VARCHAR(50)
DECLARE @Estado2 VARCHAR(50)
DECLARE @Estado3 VARCHAR(50)
DECLARE @Estado4 VARCHAR(50)
DECLARE @Estado5 VARCHAR(50)
DECLARE @Estado6 VARCHAR(50)
DECLARE @Estado7 VARCHAR(50)
DECLARE @Estado8 VARCHAR(50)
DECLARE @Estado9 VARCHAR(50)
DECLARE @Estado10 VARCHAR(50)

  

DECLARE csr CURSOR FOR  
SELECT CodCliente, Estado1, Estado2, Estado3, Estado4, Estado5, Estado6, Estado7, Estado8, Estado9, Estado10
  FROM inmobiliaria.dbo.ClientesBaja where codcliente not in (SELECT CodCliente FROM inmobiliaria.dbo.Clientes)
  

OPEN csr   
FETCH NEXT FROM csr INTO  @CodCliente, @Estado1, @Estado2, @Estado3, @Estado4, @Estado5, @Estado6, @Estado7, @Estado8, @Estado9, @Estado10   

WHILE @@FETCH_STATUS = 0   
BEGIN   

	
      if @Estado1 <> ''
		insert into ClientesEstado values (@CodCliente,@Estado1)

      if @Estado2 <> ''
		insert into ClientesEstado values (@CodCliente,@Estado2)

      if @Estado3<> ''
		insert into ClientesEstado values (@CodCliente,@Estado3)

      if @Estado4 <> ''
		insert into ClientesEstado values (@CodCliente,@Estado4)

      if @Estado5 <> ''
		insert into ClientesEstado values (@CodCliente,@Estado5)

      if @Estado6 <> ''
		insert into ClientesEstado values (@CodCliente,@Estado6)

		if @Estado7 <> ''
			insert into ClientesEstado values (@CodCliente,@Estado7)

		if @Estado8 <> ''
				insert into ClientesEstado values (@CodCliente,@Estado8)

		if @Estado9 <> ''
				insert into ClientesEstado values (@CodCliente,@Estado9)

		if @Estado10 <> ''
				insert into ClientesEstado values (@CodCliente,@Estado10)

		 

      FETCH NEXT FROM csr INTO @CodCliente, @Estado1, @Estado2, @Estado3, @Estado4, @Estado5, @Estado6, @Estado7, @Estado8, @Estado9, @Estado10  
END   

CLOSE csr   
DEALLOCATE csr 


--TIPO

create Table ClientesTipo (
CodigoCliente varchar (50) not null,
Tipo Varchar(50) not null,
)
go
alter table ClientesTipo
add constraint pk_ClientesTipo primary key (CodigoCliente,Tipo)
go

delete from ClientesTipo
go

DECLARE @CodCliente VARCHAR(50)
DECLARE @Tipo1 VARCHAR(50)
DECLARE @Tipo2 VARCHAR(50)
DECLARE @Tipo3 VARCHAR(50)
DECLARE @Tipo4 VARCHAR(50)
DECLARE @Tipo5 VARCHAR(50)
DECLARE @Tipo6 VARCHAR(50)
DECLARE @Tipo7 VARCHAR(50)
DECLARE @Tipo8 VARCHAR(50)
DECLARE @Tipo9 VARCHAR(50)
DECLARE @Tipo10 VARCHAR(50)

  

DECLARE csr CURSOR FOR  
SELECT CodCliente, Tipo1, Tipo2, Tipo3, Tipo4, Tipo5, Tipo6, Tipo7, Tipo8, Tipo9, Tipo10
  from inmobiliaria.dbo.Clientes 
  

OPEN csr   
FETCH NEXT FROM csr INTO  @CodCliente, @Tipo1, @Tipo2, @Tipo3, @Tipo4, @Tipo5, @Tipo6, @Tipo7, @Tipo8, @Tipo9, @Tipo10   

WHILE @@FETCH_STATUS = 0   
BEGIN   

	
      if @Tipo1 <> ''
		insert into ClientesTipo values (@CodCliente,@Tipo1)

      if @Tipo2 <> ''
		insert into ClientesTipo values (@CodCliente,@Tipo2)

      if @Tipo3<> ''
		insert into ClientesTipo values (@CodCliente,@Tipo3)

      if @Tipo4 <> ''
		insert into ClientesTipo values (@CodCliente,@Tipo4)

      if @Tipo5 <> ''
		insert into ClientesTipo values (@CodCliente,@Tipo5)

      if @Tipo6 <> ''
		insert into ClientesTipo values (@CodCliente,@Tipo6)

		if @Tipo7 <> ''
			insert into ClientesTipo values (@CodCliente,@Tipo7)

		if @Tipo8 <> ''
				insert into ClientesTipo values (@CodCliente,@Tipo8)

		if @Tipo9 <> ''
				insert into ClientesTipo values (@CodCliente,@Tipo9)

		if @Tipo10 <> ''
				insert into ClientesTipo values (@CodCliente,@Tipo10)

		 

      FETCH NEXT FROM csr INTO @CodCliente, @Tipo1, @Tipo2, @Tipo3, @Tipo4, @Tipo5, @Tipo6, @Tipo7, @Tipo8, @Tipo9, @Tipo10  
END   

CLOSE csr   
DEALLOCATE csr 



--DECLARE @CodCliente VARCHAR(50)
--DECLARE @Tipo1 VARCHAR(50)
--DECLARE @Tipo2 VARCHAR(50)
--DECLARE @Tipo3 VARCHAR(50)
--DECLARE @Tipo4 VARCHAR(50)
--DECLARE @Tipo5 VARCHAR(50)
--DECLARE @Tipo6 VARCHAR(50)
--DECLARE @Tipo7 VARCHAR(50)
--DECLARE @Tipo8 VARCHAR(50)
--DECLARE @Tipo9 VARCHAR(50)
--DECLARE @Tipo10 VARCHAR(50)

  

DECLARE csr CURSOR FOR  
SELECT CodCliente, Tipo1, Tipo2, Tipo3, Tipo4, Tipo5, Tipo6, Tipo7, Tipo8, Tipo9, Tipo10
  FROM inmobiliaria.dbo.ClientesBaja where codcliente not in (SELECT CodCliente FROM inmobiliaria.dbo.Clientes)
  

OPEN csr   
FETCH NEXT FROM csr INTO  @CodCliente, @Tipo1, @Tipo2, @Tipo3, @Tipo4, @Tipo5, @Tipo6, @Tipo7, @Tipo8, @Tipo9, @Tipo10   

WHILE @@FETCH_STATUS = 0   
BEGIN   

	
      if @Tipo1 <> ''
		insert into ClientesTipo values (@CodCliente,@Tipo1)

      if @Tipo2 <> ''
		insert into ClientesTipo values (@CodCliente,@Tipo2)

      if @Tipo3<> ''
		insert into ClientesTipo values (@CodCliente,@Tipo3)

      if @Tipo4 <> ''
		insert into ClientesTipo values (@CodCliente,@Tipo4)

      if @Tipo5 <> ''
		insert into ClientesTipo values (@CodCliente,@Tipo5)

      if @Tipo6 <> ''
		insert into ClientesTipo values (@CodCliente,@Tipo6)

		if @Tipo7 <> ''
			insert into ClientesTipo values (@CodCliente,@Tipo7)

		if @Tipo8 <> ''
				insert into ClientesTipo values (@CodCliente,@Tipo8)

		if @Tipo9 <> ''
				insert into ClientesTipo values (@CodCliente,@Tipo9)

		if @Tipo10 <> ''
				insert into ClientesTipo values (@CodCliente,@Tipo10)

		 

      FETCH NEXT FROM csr INTO @CodCliente, @Tipo1, @Tipo2, @Tipo3, @Tipo4, @Tipo5, @Tipo6, @Tipo7, @Tipo8, @Tipo9, @Tipo10  
END   

CLOSE csr   
DEALLOCATE csr 




--Poblacion

create Table ClientesPoblacion (
CodigoCliente varchar (50) not null,
Poblacion Varchar(50) not null,
)
go
alter table ClientesPoblacion
add constraint pk_ClientesPoblacion primary key (CodigoCliente,Poblacion)
go

delete from ClientesPoblacion
go



DECLARE @CodCliente VARCHAR(50)
DECLARE @Poblacion1 VARCHAR(50)
DECLARE @Poblacion2 VARCHAR(50)
DECLARE @Poblacion3 VARCHAR(50)
DECLARE @Poblacion4 VARCHAR(50)
DECLARE @Poblacion5 VARCHAR(50)
DECLARE @Poblacion6 VARCHAR(50)
DECLARE @Poblacion7 VARCHAR(50)
DECLARE @Poblacion8 VARCHAR(50)
DECLARE @Poblacion9 VARCHAR(50)
DECLARE @Poblacion10 VARCHAR(50)

  

DECLARE csr CURSOR FOR  
SELECT CodCliente, Poblacion1, Poblacion2, Poblacion3, Poblacion4, Poblacion5, Poblacion6, Poblacion7, Poblacion8, Poblacion9, Poblacion10
  from inmobiliaria.dbo.Clientes 
  

OPEN csr   
FETCH NEXT FROM csr INTO  @CodCliente, @Poblacion1, @Poblacion2, @Poblacion3, @Poblacion4, @Poblacion5, @Poblacion6, @Poblacion7, @Poblacion8, @Poblacion9, @Poblacion10   

WHILE @@FETCH_STATUS = 0   
BEGIN   

	
      if @Poblacion1 <> ''
		insert into ClientesPoblacion values (@CodCliente,@Poblacion1)

      if @Poblacion2 <> ''
		insert into ClientesPoblacion values (@CodCliente,@Poblacion2)

      if @Poblacion3<> ''
		insert into ClientesPoblacion values (@CodCliente,@Poblacion3)

      if @Poblacion4 <> ''
		insert into ClientesPoblacion values (@CodCliente,@Poblacion4)

      if @Poblacion5 <> ''
		insert into ClientesPoblacion values (@CodCliente,@Poblacion5)

      if @Poblacion6 <> ''
		insert into ClientesPoblacion values (@CodCliente,@Poblacion6)

		if @Poblacion7 <> ''
			insert into ClientesPoblacion values (@CodCliente,@Poblacion7)

		if @Poblacion8 <> ''
				insert into ClientesPoblacion values (@CodCliente,@Poblacion8)

		if @Poblacion9 <> ''
				insert into ClientesPoblacion values (@CodCliente,@Poblacion9)

		if @Poblacion10 <> ''
				insert into ClientesPoblacion values (@CodCliente,@Poblacion10)

		 

      FETCH NEXT FROM csr INTO @CodCliente, @Poblacion1, @Poblacion2, @Poblacion3, @Poblacion4, @Poblacion5, @Poblacion6, @Poblacion7, @Poblacion8, @Poblacion9, @Poblacion10  
END   

CLOSE csr   
DEALLOCATE csr 



--DECLARE @CodCliente VARCHAR(50)
--DECLARE @Poblacion1 VARCHAR(50)
--DECLARE @Poblacion2 VARCHAR(50)
--DECLARE @Poblacion3 VARCHAR(50)
--DECLARE @Poblacion4 VARCHAR(50)
--DECLARE @Poblacion5 VARCHAR(50)
--DECLARE @Poblacion6 VARCHAR(50)
--DECLARE @Poblacion7 VARCHAR(50)
--DECLARE @Poblacion8 VARCHAR(50)
--DECLARE @Poblacion9 VARCHAR(50)
--DECLARE @Poblacion10 VARCHAR(50)

  

DECLARE csr CURSOR FOR  
SELECT CodCliente, Poblacion1, Poblacion2, Poblacion3, Poblacion4, Poblacion5, Poblacion6, Poblacion7, Poblacion8, Poblacion9, Poblacion10
  FROM inmobiliaria.dbo.ClientesBaja where codcliente not in (SELECT CodCliente FROM inmobiliaria.dbo.Clientes)
  

OPEN csr   
FETCH NEXT FROM csr INTO  @CodCliente, @Poblacion1, @Poblacion2, @Poblacion3, @Poblacion4, @Poblacion5, @Poblacion6, @Poblacion7, @Poblacion8, @Poblacion9, @Poblacion10   

WHILE @@FETCH_STATUS = 0   
BEGIN   

	
      if @Poblacion1 <> ''
		insert into ClientesPoblacion values (@CodCliente,@Poblacion1)

      if @Poblacion2 <> ''
		insert into ClientesPoblacion values (@CodCliente,@Poblacion2)

      if @Poblacion3<> ''
		insert into ClientesPoblacion values (@CodCliente,@Poblacion3)

      if @Poblacion4 <> ''
		insert into ClientesPoblacion values (@CodCliente,@Poblacion4)

      if @Poblacion5 <> ''
		insert into ClientesPoblacion values (@CodCliente,@Poblacion5)

      if @Poblacion6 <> ''
		insert into ClientesPoblacion values (@CodCliente,@Poblacion6)

		if @Poblacion7 <> ''
			insert into ClientesPoblacion values (@CodCliente,@Poblacion7)

		if @Poblacion8 <> ''
				insert into ClientesPoblacion values (@CodCliente,@Poblacion8)

		if @Poblacion9 <> ''
				insert into ClientesPoblacion values (@CodCliente,@Poblacion9)

		if @Poblacion10 <> ''
				insert into ClientesPoblacion values (@CodCliente,@Poblacion10)

		 

      FETCH NEXT FROM csr INTO @CodCliente, @Poblacion1, @Poblacion2, @Poblacion3, @Poblacion4, @Poblacion5, @Poblacion6, @Poblacion7, @Poblacion8, @Poblacion9, @Poblacion10  
END   

CLOSE csr   
DEALLOCATE csr 
 


--Zona

create Table ClientesZona (
CodigoCliente varchar (50) not null,
Zona Varchar(50) not null,
)
go
alter table ClientesZona
add constraint pk_ClientesZona primary key (CodigoCliente,Zona)
go

delete from ClientesZona
go

DECLARE @CodCliente VARCHAR(50)
DECLARE @Zona1 VARCHAR(50)
DECLARE @Zona2 VARCHAR(50)
DECLARE @Zona3 VARCHAR(50)
DECLARE @Zona4 VARCHAR(50)
DECLARE @Zona5 VARCHAR(50)
DECLARE @Zona6 VARCHAR(50)
DECLARE @Zona7 VARCHAR(50)
DECLARE @Zona8 VARCHAR(50)
DECLARE @Zona9 VARCHAR(50)
DECLARE @Zona10 VARCHAR(50)

  

DECLARE csr CURSOR FOR  
SELECT CodCliente, Zona1, Zona2, Zona3, Zona4, Zona5, Zona6, Zona7, Zona8, Zona9, Zona10
  from inmobiliaria.dbo.Clientes 
  

OPEN csr   
FETCH NEXT FROM csr INTO  @CodCliente, @Zona1, @Zona2, @Zona3, @Zona4, @Zona5, @Zona6, @Zona7, @Zona8, @Zona9, @Zona10   

WHILE @@FETCH_STATUS = 0   
BEGIN   

	
      if @Zona1 <> ''
		insert into ClientesZona values (@CodCliente,@Zona1)

      if @Zona2 <> ''
		insert into ClientesZona values (@CodCliente,@Zona2)

      if @Zona3<> ''
		insert into ClientesZona values (@CodCliente,@Zona3)

      if @Zona4 <> ''
		insert into ClientesZona values (@CodCliente,@Zona4)

      if @Zona5 <> ''
		insert into ClientesZona values (@CodCliente,@Zona5)

      if @Zona6 <> ''
		insert into ClientesZona values (@CodCliente,@Zona6)

		if @Zona7 <> ''
			insert into ClientesZona values (@CodCliente,@Zona7)

		if @Zona8 <> ''
				insert into ClientesZona values (@CodCliente,@Zona8)

		if @Zona9 <> ''
				insert into ClientesZona values (@CodCliente,@Zona9)

		if @Zona10 <> ''
				insert into ClientesZona values (@CodCliente,@Zona10)

		 

      FETCH NEXT FROM csr INTO @CodCliente, @Zona1, @Zona2, @Zona3, @Zona4, @Zona5, @Zona6, @Zona7, @Zona8, @Zona9, @Zona10  
END   

CLOSE csr   
DEALLOCATE csr 



--DECLARE @CodCliente VARCHAR(50)
--DECLARE @Zona1 VARCHAR(50)
--DECLARE @Zona2 VARCHAR(50)
--DECLARE @Zona3 VARCHAR(50)
--DECLARE @Zona4 VARCHAR(50)
--DECLARE @Zona5 VARCHAR(50)
--DECLARE @Zona6 VARCHAR(50)
--DECLARE @Zona7 VARCHAR(50)
--DECLARE @Zona8 VARCHAR(50)
--DECLARE @Zona9 VARCHAR(50)
--DECLARE @Zona10 VARCHAR(50)

  

DECLARE csr CURSOR FOR  
SELECT CodCliente, Zona1, Zona2, Zona3, Zona4, Zona5, Zona6, Zona7, Zona8, Zona9, Zona10
  FROM inmobiliaria.dbo.ClientesBaja where codcliente not in (SELECT CodCliente FROM inmobiliaria.dbo.Clientes)
  

OPEN csr   
FETCH NEXT FROM csr INTO  @CodCliente, @Zona1, @Zona2, @Zona3, @Zona4, @Zona5, @Zona6, @Zona7, @Zona8, @Zona9, @Zona10   

WHILE @@FETCH_STATUS = 0   
BEGIN   

	
      if @Zona1 <> ''
		insert into ClientesZona values (@CodCliente,@Zona1)

      if @Zona2 <> ''
		insert into ClientesZona values (@CodCliente,@Zona2)

      if @Zona3<> ''
		insert into ClientesZona values (@CodCliente,@Zona3)

      if @Zona4 <> ''
		insert into ClientesZona values (@CodCliente,@Zona4)

      if @Zona5 <> ''
		insert into ClientesZona values (@CodCliente,@Zona5)

      if @Zona6 <> ''
		insert into ClientesZona values (@CodCliente,@Zona6)

		if @Zona7 <> ''
			insert into ClientesZona values (@CodCliente,@Zona7)

		if @Zona8 <> ''
				insert into ClientesZona values (@CodCliente,@Zona8)

		if @Zona9 <> ''
				insert into ClientesZona values (@CodCliente,@Zona9)

		if @Zona10 <> ''
				insert into ClientesZona values (@CodCliente,@Zona10)

		 

      FETCH NEXT FROM csr INTO @CodCliente, @Zona1, @Zona2, @Zona3, @Zona4, @Zona5, @Zona6, @Zona7, @Zona8, @Zona9, @Zona10  
END   

CLOSE csr   
DEALLOCATE csr 




--Orientacion

create Table ClientesOrientacion (
CodigoCliente varchar (50) not null,
Orientacion Varchar(50) not null,
)
go
alter table ClientesOrientacion
add constraint pk_ClientesOrientacion primary key (CodigoCliente,Orientacion)
go

delete from ClientesOrientacion
go

DECLARE @CodCliente VARCHAR(50)
DECLARE @Orientacion1 VARCHAR(50)
DECLARE @Orientacion2 VARCHAR(50)
DECLARE @Orientacion3 VARCHAR(50)
DECLARE @Orientacion4 VARCHAR(50)
DECLARE @Orientacion5 VARCHAR(50)
DECLARE @Orientacion6 VARCHAR(50)
DECLARE @Orientacion7 VARCHAR(50)
DECLARE @Orientacion8 VARCHAR(50)
DECLARE @Orientacion9 VARCHAR(50)
DECLARE @Orientacion10 VARCHAR(50)

  

DECLARE csr CURSOR FOR  
SELECT CodCliente, Orientacion1, Orientacion2, Orientacion3, Orientacion4, Orientacion5, Orientacion6, Orientacion7, Orientacion8, Orientacion9, Orientacion10
  from inmobiliaria.dbo.Clientes 
  

OPEN csr   
FETCH NEXT FROM csr INTO  @CodCliente, @Orientacion1, @Orientacion2, @Orientacion3, @Orientacion4, @Orientacion5, @Orientacion6, @Orientacion7, @Orientacion8, @Orientacion9, @Orientacion10   

WHILE @@FETCH_STATUS = 0   
BEGIN   

	
      if @Orientacion1 <> ''
		insert into ClientesOrientacion values (@CodCliente,@Orientacion1)

      if @Orientacion2 <> ''
		insert into ClientesOrientacion values (@CodCliente,@Orientacion2)

      if @Orientacion3<> ''
		insert into ClientesOrientacion values (@CodCliente,@Orientacion3)

      if @Orientacion4 <> ''
		insert into ClientesOrientacion values (@CodCliente,@Orientacion4)

      if @Orientacion5 <> ''
		insert into ClientesOrientacion values (@CodCliente,@Orientacion5)

      if @Orientacion6 <> ''
		insert into ClientesOrientacion values (@CodCliente,@Orientacion6)

		if @Orientacion7 <> ''
			insert into ClientesOrientacion values (@CodCliente,@Orientacion7)

		if @Orientacion8 <> ''
				insert into ClientesOrientacion values (@CodCliente,@Orientacion8)

		if @Orientacion9 <> ''
				insert into ClientesOrientacion values (@CodCliente,@Orientacion9)

		if @Orientacion10 <> ''
				insert into ClientesOrientacion values (@CodCliente,@Orientacion10)

		 

      FETCH NEXT FROM csr INTO @CodCliente, @Orientacion1, @Orientacion2, @Orientacion3, @Orientacion4, @Orientacion5, @Orientacion6, @Orientacion7, @Orientacion8, @Orientacion9, @Orientacion10  
END   

CLOSE csr   
DEALLOCATE csr 



--DECLARE @CodCliente VARCHAR(50)
--DECLARE @Orientacion1 VARCHAR(50)
--DECLARE @Orientacion2 VARCHAR(50)
--DECLARE @Orientacion3 VARCHAR(50)
--DECLARE @Orientacion4 VARCHAR(50)
--DECLARE @Orientacion5 VARCHAR(50)
--DECLARE @Orientacion6 VARCHAR(50)
--DECLARE @Orientacion7 VARCHAR(50)
--DECLARE @Orientacion8 VARCHAR(50)
--DECLARE @Orientacion9 VARCHAR(50)
--DECLARE @Orientacion10 VARCHAR(50)

  

DECLARE csr CURSOR FOR  
SELECT CodCliente, Orientacion1, Orientacion2, Orientacion3, Orientacion4, Orientacion5, Orientacion6, Orientacion7, Orientacion8, Orientacion9, Orientacion10
  FROM inmobiliaria.dbo.ClientesBaja where codcliente not in (SELECT CodCliente FROM inmobiliaria.dbo.Clientes)
  

OPEN csr   
FETCH NEXT FROM csr INTO  @CodCliente, @Orientacion1, @Orientacion2, @Orientacion3, @Orientacion4, @Orientacion5, @Orientacion6, @Orientacion7, @Orientacion8, @Orientacion9, @Orientacion10   

WHILE @@FETCH_STATUS = 0   
BEGIN   

	
      if @Orientacion1 <> ''
		insert into ClientesOrientacion values (@CodCliente,@Orientacion1)

      if @Orientacion2 <> ''
		insert into ClientesOrientacion values (@CodCliente,@Orientacion2)

      if @Orientacion3<> ''
		insert into ClientesOrientacion values (@CodCliente,@Orientacion3)

      if @Orientacion4 <> ''
		insert into ClientesOrientacion values (@CodCliente,@Orientacion4)

      if @Orientacion5 <> ''
		insert into ClientesOrientacion values (@CodCliente,@Orientacion5)

      if @Orientacion6 <> ''
		insert into ClientesOrientacion values (@CodCliente,@Orientacion6)

		if @Orientacion7 <> ''
			insert into ClientesOrientacion values (@CodCliente,@Orientacion7)

		if @Orientacion8 <> ''
				insert into ClientesOrientacion values (@CodCliente,@Orientacion8)

		if @Orientacion9 <> ''
				insert into ClientesOrientacion values (@CodCliente,@Orientacion9)

		if @Orientacion10 <> ''
				insert into ClientesOrientacion values (@CodCliente,@Orientacion10)

		 

      FETCH NEXT FROM csr INTO @CodCliente, @Orientacion1, @Orientacion2, @Orientacion3, @Orientacion4, @Orientacion5, @Orientacion6, @Orientacion7, @Orientacion8, @Orientacion9, @Orientacion10  
END   

CLOSE csr   
DEALLOCATE csr 


create view v_ClientesPoblaciones
as
SELECT CONVERT (bIT,1) AS Selec, CodigoCliente, Poblacion FROM ClientesPoblacion 
UNION ALL 
SELECT CONVERT (bIT,0) AS Selec,0,Poblacion FROM Poblacion ORDER BY Poblacion

alter FUNCTION F_ClientesPoblaciones (@CodigoCliente varchar(50))
 RETURNS TABLE
 AS
 RETURN (
 SELECT CONVERT (bIT,1) AS Selec, CodigoCliente, Poblacion FROM ClientesPoblacion 
 WHERE CodigoCliente = @CodigoCliente
 UNION ALL 
SELECT CONVERT (bIT,0) AS Selec, 0 as CodigoCliente, Poblacion FROM Poblacion 
 WHERE Poblacion NOT IN (SELECT  Poblacion FROM ClientesPoblacion 
 WHERE CodigoCliente = @CodigoCliente)
 
)
SELECT * FROM CLIENTES
SELECT * FROM POBLACION

SELECT  dbo.F_ClientesPoblaciones ORDER BY Poblacion

SELECT * from dbo.F_ClientesPoblaciones ('11546') ORDER BY Poblacion



UPDATE INMUEBLES SET Llaves = 0 WHERE LLAVES <> 'SI'
UPDATE INMUEBLES SET Llaves = 1 WHERE LLAVES ='SI'
GO 
ALTER TABLE INMUEBLES
ALTER COLUMN LLAVES BIT
GO
UPDATE INMUEBLES SET PISCINA = 0 WHERE PISCINA <> 'SI'
UPDATE INMUEBLES SET PISCINA = 1 WHERE PISCINA ='SI'

GO 
ALTER TABLE INMUEBLES
ALTER COLUMN PISCINA BIT
GO

UPDATE INMUEBLES SET cOCINAOFFICE = 0 WHERE cOCINAOFFICE <> 'SI'
UPDATE INMUEBLES SET cOCINAOFFICE = 1 WHERE cOCINAOFFICE ='SI'

GO 
ALTER TABLE INMUEBLES
ALTER COLUMN cOCINAOFFICE BIT
GO

UPDATE INMUEBLES SET ASCENSOR = 0 WHERE ASCENSOR <> 'SI'
UPDATE INMUEBLES SET ASCENSOR = 1 WHERE ASCENSOR ='SI'

GO 
ALTER TABLE INMUEBLES
ALTER COLUMN ASCENSOR BIT
GO

UPDATE INMUEBLES SET GALERIA = 0 WHERE GALERIA <> 'SI'
UPDATE INMUEBLES SET GALERIA = 1 WHERE GALERIA ='SI'

GO 
ALTER TABLE INMUEBLES
ALTER COLUMN GALERIA BIT
GO

UPDATE INMUEBLES SET GALERIA = 0 WHERE GALERIA <> 'SI'
UPDATE INMUEBLES SET GALERIA = 1 WHERE GALERIA ='SI'

GO 
ALTER TABLE INMUEBLES
ALTER COLUMN GALERIA BIT
GO

UPDATE INMUEBLES SET CHOLLO = 0 WHERE CHOLLO <> 'SI'
UPDATE INMUEBLES SET CHOLLO = 1 WHERE CHOLLO ='SI'

GO 
ALTER TABLE INMUEBLES
ALTER COLUMN CHOLLO BIT
GO

UPDATE INMUEBLES SET ESCAPARATE = 0 WHERE ESCAPARATE <> 'SI'
UPDATE INMUEBLES SET ESCAPARATE = 1 WHERE ESCAPARATE ='SI'

GO 
ALTER TABLE INMUEBLES
ALTER COLUMN ESCAPARATE BIT
GO


UPDATE INMUEBLES SET NOALQUILER = 1 WHERE NOALQUILER <> 'SI'
UPDATE INMUEBLES SET NOALQUILER = 0 WHERE NOALQUILER = 'SI'

GO 
ALTER TABLE INMUEBLES
ALTER COLUMN NOALQUILER BIT
GO

UPDATE INMUEBLES SET OCULTAR = 0 WHERE OCULTAR <> 'SI'
UPDATE INMUEBLES SET OCULTAR = 1 WHERE OCULTAR ='SI'

GO 
ALTER TABLE INMUEBLES
ALTER COLUMN OCULTAR BIT
GO

UPDATE INMUEBLES SET Jardin = 0 WHERE Jardin <> 'SI'
UPDATE INMUEBLES SET Jardin = 1 WHERE Jardin ='SI'

GO 
ALTER TABLE INMUEBLES
ALTER COLUMN Jardin BIT
GO

UPDATE INMUEBLES SET PN = 0 WHERE PN <> 'SI'
UPDATE INMUEBLES SET PN = 1 WHERE PN ='SI'

GO 
ALTER TABLE INMUEBLES
ALTER COLUMN PN BIT
GO

 

ALTER TABLE INMUEBLES
add PrecioVenta int
GO

ALTER TABLE INMUEBLES
add PrecioAlquiler int
GO

ALTER TABLE INMUEBLES
add  Venta bit
GO

ALTER TABLE INMUEBLES
add  Alquiler bit
GO

UPDATE INMUEBLES SET Venta = 0  
UPDATE INMUEBLES SET ALQUILER =0

UPDATE INMUEBLES SET Venta = 1 WHERE tipovENTA = 'VENTA'
UPDATE INMUEBLES SET ALQUILER = 1 WHERE tipovENTA = 'ALQUILER'


UPDATE INMUEBLES SET PrecioVenta = 0  
UPDATE INMUEBLES SET PrecioALQUILER =0

UPDATE INMUEBLES SET PrecioVenta = Precio WHERE tipovENTA = 'VENTA'
UPDATE INMUEBLES SET PrecioALQUILER = Precio WHERE tipovENTA = 'ALQUILER'

 ALTER TABLE INMUEBLES
drop column Precio
go




ALTER TABLE INMUEBLES
add  Agrupacion varchar(50)
GO
UPDATE INMUEBLES SET Agrupacion = ''  

ALTER TABLE INMUEBLES
add  Baja bit
GO
UPDATE INMUEBLES SET Baja = 0




aLTER TABLE INMUEBLES
add  TrasteroVenta Varchar(50)
GO

ALTER TABLE INMUEBLES
add  TrasteroAlquiler Varchar(50)
GO

UPDATE INMUEBLES SET TrasteroVenta = ''
UPDATE INMUEBLES SET TrasteroAlquiler = ''

UPDATE INMUEBLES SET TrasteroVenta = trastero WHERE tipovENTA = 'VENTA'
UPDATE INMUEBLES SET TrasteroAlquiler = trastero WHERE tipovENTA = 'ALQUILER'


aLTER TABLE INMUEBLES
add  PrecioTrasteroVenta int
GO

ALTER TABLE INMUEBLES
add  PrecioTrasteroAlquiler int
GO

UPDATE INMUEBLES SET PrecioTrasteroVenta = 0
UPDATE INMUEBLES SET PrecioTrasteroAlquiler = 0

UPDATE INMUEBLES SET PrecioTrasteroVenta = PrecioTrastero WHERE tipovENTA = 'VENTA'
UPDATE INMUEBLES SET PrecioTrasteroAlquiler = PrecioTrastero WHERE tipovENTA = 'ALQUILER'

 ALTER TABLE INMUEBLES
drop column PrecioTrastero
go



aLTER TABLE INMUEBLES
add  PrecioGarajeVenta int
GO

ALTER TABLE INMUEBLES
add  PrecioGarajeAlquiler int
GO

UPDATE INMUEBLES SET PrecioGarajeVenta = 0
UPDATE INMUEBLES SET PrecioGarajeAlquiler = 0

UPDATE INMUEBLES SET PrecioGarajeVenta = PrecioGaraje WHERE tipovENTA = 'VENTA'
UPDATE INMUEBLES SET PrecioGarajeAlquiler = PrecioGaraje WHERE tipovENTA = 'ALQUILER'


UPDATE INMUEBLES SET GarajeCerrado = 0 WHERE GarajeCerrado <> 'SI'
UPDATE INMUEBLES SET GarajeCerrado = 1 WHERE GarajeCerrado ='SI'

 ALTER TABLE INMUEBLES
drop column PrecioGaraje
go

GO 
ALTER TABLE INMUEBLES
ALTER COLUMN GarajeCerrado BIT
GO



ALTER TABLE INMUEBLES
add PrecioProveedorVenta int
GO

ALTER TABLE INMUEBLES
add PrecioProveedorAlquiler int
GO

 
UPDATE INMUEBLES SET PrecioProveedorVenta = 0  
UPDATE INMUEBLES SET PrecioProveedorAlquiler =0

UPDATE INMUEBLES SET PrecioProveedorVenta = PrecioProveedor  WHERE tipovENTA = 'VENTA'
UPDATE INMUEBLES SET PrecioProveedorAlquiler = PrecioProveedor WHERE tipovENTA = 'ALQUILER'


ALTER TABLE INMUEBLES
add PrecioNegociableVenta bit
GO
UPDATE INMUEBLES SET PrecioNegociableVenta = 0 WHERE PN <> 'SI'
UPDATE INMUEBLES SET PrecioNegociableVenta = 1 WHERE PN ='SI'

 ALTER TABLE INMUEBLES
drop column PrecioProveedor
go
 
ALTER TABLE INMUEBLES
add PrecioNegociableAlquler bit
GO
UPDATE INMUEBLES SET PrecioNegociableAlquler = 0 WHERE PN <> 'SI'
UPDATE INMUEBLES SET PrecioNegociableAlquler = 1 WHERE PN ='SI'

ALTER TABLE INMUEBLES
drop column PN
go
  

ALTER TABLE INMUEBLES
drop column PrecioProveedor
go
  

ALTER TABLE INMUEBLES
drop column Tipo2
go


ALTER TABLE INMUEBLES
drop column telefono1
go
  
ALTER TABLE INMUEBLES
drop column Movil
go
  
ALTER TABLE INMUEBLES
drop column PrecioProveedor
go
  

  ALTER TABLE INMUEBLES
drop column Orientacion2
go
  ALTER TABLE INMUEBLES
drop column Orientacion2
go
  
  
  







--UPDATE INMUEBLES SET BALCON = 1 WHERE BALCON ='SI'
--UPDATE INMUEBLES SET BALCON = 0 WHERE BALCON <> 'SI'
--GO 
--ALTER TABLE INMUEBLES
--ALTER COLUMN BALCON BIT
--GO


--UPDATE INMUEBLES SET PATIO = 1 WHERE PATIO ='SI'
--UPDATE INMUEBLES SET PATIO = 0 WHERE PATIO <> 'SI'
--GO 
--ALTER TABLE INMUEBLES
--ALTER COLUMN PATIO BIT
--GO


--UPDATE INMUEBLES SET TERRAZA = 1 WHERE TERRAZA ='SI'
--UPDATE INMUEBLES SET TERRAZA = 0 WHERE TERRAZA <> 'SI'
--GO 
--ALTER TABLE INMUEBLES
--ALTER COLUMN TERRAZA BIT
--GO

--GO 
--ALTER TABLE INMUEBLES
--ALTER COLUMN PATIO VARCHAR(50) NOT NULL
--GO
--UPDATE INMUEBLES SET PATIO = 'SI' WHERE PATIO ='1'
--UPDATE INMUEBLES SET PATIO = 'NO' WHERE PATIO <> '1'

