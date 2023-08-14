delete from Netis.dbo.DocumentoPresupuesto 
delete from Netis.dbo.Empleados 

set identity_insert Netis.dbo.Empleados on

insert into Netis.dbo.Empleados 
 (codigo,fechaalta,baja,nombre,nif,NombreComercial,Direccion ,Poblacion, CodPostal ,Provincia ,Pais ,Telefono1 ,Telefono2 ,TelefonoMovil , Fax ,Email ,Observaciones ,BancoNombre ,BancoCuenta ,Comercial ,agrupacion)

select convert(int,codigo)   ,getdate(),0,NOMBRE ,DNI ,'',DIRECCION,POBLACION,CODPOST, provincia, pais, TELEFON,'',MOBIL ,'','','','','',0,'' 
from [2012LV].dbo.vendedor where codigo ='05'

set identity_insert Netis.dbo.Empleados off

TRUNCATE Table NetisEmpresas.dbo.Usuarios

insert into NetisEmpresas.dbo.Usuarios values( 'a','DE931DBFB2FA8525','ADMINISTRADOR',1,'Metropolis')
insert into NetisEmpresas.dbo.Usuarios values(  'b','DE931DBFB2FA8525','STANDARD',1,'Metropolis')
insert into NetisEmpresas.dbo.Usuarios values(  'c','DE931DBFB2FA8525','STANDARD',1,'Metropolis')
insert into NetisEmpresas.dbo.Usuarios values( 'd','DE931DBFB2FA8525','STANDARD',1,'Metropolis')
insert into NetisEmpresas.dbo.Usuarios values( 'e','DE931DBFB2FA8525','STANDARD',1,'Metropolis')

insert into NetisEmpresas.dbo.UsuarioTipos VALUES ('STANDARD')
DELETE FROM NetisEmpresas.dbo.UsuarioTipos WHERE TIPO = 'NORMAL'

alter proc sp_CrearUsuario
@Usuario varchar(50),
@Pass varchar(50),
@Tipo varchar(50),
@EmpresaPredeterminada int
as
 
INSERT INTO Usuarios VALUES ( @Usuario,@Pass,@Tipo,@EmpresaPredeterminada,'Metropolis')
SELECT @@IDENTITY 


create proc sp_ModificaUsuario
@Codigo int,
@Usuario varchar(50),
@Pass varchar(50),
@Tipo varchar(50)
 
as
 
update Usuarios set     DisenoPerfil  ='Metropolis'  
  create proc sp_EliminaUsuario
@Codigo int 
as
 
delete from Usuarios   where Codigo =@Codigo
 
  SELECT * FROM Empresas 

  insert into empresas values (1,'Netis','DEMO 04')