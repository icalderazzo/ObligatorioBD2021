-- Paso 1 : Insertar usuarios
insert into Usuario values (11111111, 'Esteban', 'Barrios', 'estebanbarrios@hotmail.com', 'ebarrios', 'contrasenia123', 988888889);
insert into Usuario values (22222222, 'Ignacio', 'Calderazzo', 'ignaciocalderazzo@hotmail.com', 'icalderazzo', 'contrasenia123', 977777779);
insert into Usuario values (33333333, 'Diego', 'Kleinman', 'diegokleinman@hotmail.com', 'dkleinman', 'contrasenia123', 967777779);
insert into Usuario values (44444444, 'Federico', 'Valiño', 'federicovalino@hotmail.com', 'fvalino', 'contrasenia123', 957777779);
insert into Usuario values (44444444, 'Federico', 'Valiño', 'federicovalino@hotmail.com', 'fvalino', 'contrasenia123', 957777779);

-- Paso 2 : Publicar
insert into Publicacion (CiUsuario, NombreProducto, DescripcionProducto, ValorProducto) values (44444444,'Lapiz digital','Lapiz digital de la mejor calidad. Ideal para docentes!', 1000);
insert into Publicacion (CiUsuario, NombreProducto, DescripcionProducto, ValorProducto) values (44444444,'Windows 11','Key global windows 11 oficial, fixes en powerpoint', 1000);
insert into Publicacion (CiUsuario, NombreProducto, DescripcionProducto, ValorProducto) values (11111111,'Termo','Termo stanley', 2000);
insert into Publicacion (CiUsuario, NombreProducto, DescripcionProducto, ValorProducto) values (11111111,'Libro de bases de datos','Data Modeling Essentials – Simsion, Witt, 3ª Edición, Morgan Kaufmann, Elsevier, 2005', 1000);
insert into Publicacion (CiUsuario, NombreProducto, DescripcionProducto, ValorProducto) values (11111111,'Case Iphone 11','Case transparante para iphone 11 de excelente calidad', 1000);
insert into Publicacion (CiUsuario, NombreProducto, DescripcionProducto, ValorProducto) values (44444444,'Promo 2x1 Lapiz digital','Dos lápices digitales por el precio de dos', 2000);

-- Paso 3 : Crear ofertas
insert into Oferta (FechaRealizacion) values ('20211020') --id: 1
insert into Oferta (FechaRealizacion) values ('20211025')

-- Paso 3.1 : Asociar usuarios a las ofertas (Cedula oferta rol)
insert into UsuarioOferta values (11111111, 1, 1);
insert into UsuarioOferta values (44444444, 1, 2);
insert into UsuarioOferta values (44444444, 2, 1);
insert into UsuarioOferta values (11111111, 2, 2);

-- Paso 3.2 : Asociar publicaciones a las ofertas
insert into PublicacionOferta values (1, 1);
insert into PublicacionOferta values (2, 1);
insert into PublicacionOferta values (3, 1);
insert into PublicacionOferta values (1, 2);
insert into PublicacionOferta values (2, 2);
insert into PublicacionOferta values (4, 2);
insert into PublicacionOferta values (5, 2);

begin tran

DECLARE @IdOfertaAnterior BIGINT;
DECLARE @IdOfertaNueva BIGINT;

SET @IdOfertaAnterior = 1;

--Nota: La oferta 1 es, dos articulos del usuario 444444 por 1 articulo del usuario 111111
-- 1: Cambiar estado de oferta actual
UPDATE Oferta SET EstadoOferta = 3 WHERE IdOferta = @IdOfertaAnterior --se pasa a rechazada 'motivo de contraoferta'

-- 2: Crear una nueva oferta
insert into Oferta (FechaRealizacion) values ('20211020') --esta es la contra oferta

SET @IdOfertaNueva = (select top 1 IdOferta from Oferta order by IdOferta desc);

-- 2.1 : Registrar contraoferta
Insert into ContraOferta (IdOfertaAnterior, IdOfertaNueva) values (@IdOfertaAnterior, @IdOfertaNueva)

-- 3:  Destinatario pasa a ser el emisor
insert into UsuarioOferta (IdOferta, IdRolOferta, CiUsuario) 
values
(
	@IdOfertaNueva,
	1,
	(select CiUsuario from UsuarioOferta where IdRolOferta = 2 and IdOferta = @IdOfertaAnterior) -- el que era destinatario en la oferta 1
)

-- 4:  Emisor pasa a ser destinatario
insert into UsuarioOferta (IdOferta, IdRolOferta, CiUsuario) 
values
(
	@IdOfertaNueva,
	2,
	(select CiUsuario from UsuarioOferta where IdRolOferta = 1 and IdOferta = @IdOfertaAnterior) -- el que era emisor en la oferta 1
)

-- 5 Publicacion oferta
insert into PublicacionOferta (IdPublicacion, IdOferta) values (6, @IdOfertaNueva)
insert into PublicacionOferta (IdPublicacion, IdOferta) values (3, @IdOfertaNueva)

commit