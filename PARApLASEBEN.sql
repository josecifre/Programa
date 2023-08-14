 USE netis
 go
Create view v_ListadoPrespuestos
 
  AS

    

 
	 SELECT D.Contador, D.Empresa, D.Serie ,D.Numero, D.Fecha,D.Estado , D.CodCliente, 
	 (SELECT Nombre FROM Clientes C WHERE C.Codigo = D.CodCliente) AS Cliente, D.Cobrada ,
	  (SELECT Nombre FROM Empleados C WHERE C.Codigo = D.CodEmpleado) AS Empleado , CodEmpleado,FormaPago,FechaEntrega,Observaciones,
	ROUND (ISNULL ( SUM (DD.Cantidad * DD.Precio * (1-(DtoPor/100))),0),2) as IMPORTE,
	ROUND (ISNULL ( SUM (0.01 * D.DescuentoPP * DD.Cantidad * DD.Precio * (1-(DtoPor/100))),0),2) as DTOPP,
	ROUND (ISNULL ( SUM (0.01 * (100 - D.DescuentoPP) * DD.Cantidad * DD.Precio * (1-(DtoPor/100))),0),2) as BI,
	ROUND (ISNULL ( SUM (0.01 * (100 - D.DescuentoPP) * DD.Cantidad * DD.Precio * (1-(DtoPor/100)) * (IVAPor/100)),0),2) as IVA,
	ROUND (ISNULL ( SUM (0.01 * (100 - D.DescuentoPP) * DD.Cantidad * DD.Precio * (1-(DtoPor/100)) * (1 + (IVAPor/100))),0),2) as Total
	FROM DocumentoPresupuesto  D INNER JOIN DocumentoPresupuestoDetalle  DD ON D.Contador = DD.ContadorDocumento 
	GROUP BY D.Contador, D.Empresa, D.Serie ,D.Numero, D.Fecha,D.Estado ,D.CodCliente, D.Cobrada , CodEmpleado,FormaPago,FechaEntrega,Observaciones 

  go



  USE netis
GO

/****** Object:  Table [dbo].[EmailsRecibidos]    Script Date: 31/05/2013 13:29:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[EmailsRecibidos](
	[Contador] [int] IDENTITY(1,1) NOT NULL,
	[TipoEmail] [varchar](50) NOT NULL,
	Documento Varchar(50) not null,
	ContadorDocumento int,
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


USE netis
GO

/****** Object:  Table [dbo].[EmailsRecibidosAdjuntos]    Script Date: 31/05/2013 13:38:26 ******/
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

ALTER TABLE [dbo].[EmailsRecibidosAdjuntos]  WITH CHECK ADD  CONSTRAINT [FK_EmailsRecibidosAdjuntos_EmailsRecibidos] FOREIGN KEY([ContadorEmailRecibido])
REFERENCES [dbo].[EmailsRecibidos] ([Contador])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[EmailsRecibidosAdjuntos] CHECK CONSTRAINT [FK_EmailsRecibidosAdjuntos_EmailsRecibidos]
GO


/****** Object:  Table [dbo].[EmailConfiguracion]    Script Date: 31/05/2013 13:40:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
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
insert into EmailConfiguracion values ('plasben@tresbits.es','plasben@tresbits.es','Incidencias KuviK','B4D08367A6EC75932D92BF0958C71B8E','mail.tresbits.es','mail.tresbits.es',25,'','','',0,0)

go
select * from EmailConfiguracion