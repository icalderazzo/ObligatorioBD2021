Usuario (<u>CI</u>, Nombre, Apellido, Correo, NombreUsuario, Contraseña)

Telefono (<u>Numero</u>, Fk_UsuarioCI)

Producto (<u>IdProducto</u>, Nombre, Descripción, Valor)

Imagen()

Publicacion (<u>Fk_IdProducto</u>, Fk_UsuarioCI, Estado, FechaPublicacion)

EsOferecida (<u>Fk_IdTransaccion</u>, <u>Fk_IdProductoOfrecido</u>)

RecibeOferta (<u>Fk_IdTransaccion</u>, <u>Fk_IdProductoDeseado</u>)

Transaccion (<u>IdTransaccion</u>, Fecha, IdTransaccionAnterior, Fk_EstadoTransaccion)

ContraOferta (<u>IdNuevaTransaccion</u>, <u>IdTransaccionContraofertada</u>)

EstadoTransaccion (<u>IdEstadoTransaccion</u>, Descripcion)









