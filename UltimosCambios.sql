--ultimos cambios
--revisar sp's


alter table ClientesComerciales
Add  Predeterminado bit
go

update ClientesComerciales set Predeterminado = 0 

go

alter table ClientesComerciales
alter column  Predeterminado bit not null
go

 



alter table Clientes
Add  VentasBloqueadas bit
go

update clientes set VentasBloqueadas = 0 

go

alter table Clientes
alter column  VentasBloqueadas bit not null
go


 