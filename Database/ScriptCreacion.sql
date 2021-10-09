--CREATE DATABASE UCUTrade;

CREATE TABLE Usuario(
    Ci INT NOT NULL,
    Nombre NVARCHAR(30) NOT NULL,
    Apellido NVARCHAR(30) NOT NULL,
    Correo NVARCHAR(50) NOT NULL,
    NombreUsuario NVARCHAR(20) NOT NULL,
    Contrasenia NVARCHAR(30) NOT NULL,
    PRIMARY KEY (Ci)
);

CREATE TABLE Telefono(
    Numero INT NOT NULL,
    CiUsuario INT NOT NULL,
    FOREIGN KEY (CiUsuario) REFERENCES Usuario(Ci),
    PRIMARY KEY (Numero)  
);

CREATE TABLE Producto(
    IdProducto BIGINT IDENTITY(1,1),
    Nombre NVARCHAR(50),
    Descripcion NTEXT,
    Valor INT,
    PRIMARY KEY (IdProducto)
);

CREATE TABLE Publicacion(
    IdProducto BIGINT NOT NULL,
    CiUsuario INT NOT NULL,
    Estado BIT DEFAULT 1,
    FechaPublicacion DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (IdProducto) REFERENCES Producto (IdProducto),
    FOREIGN KEY (CiUsuario) REFERENCES Usuario (Ci),
    PRIMARY KEY (IdProducto)
);

CREATE TABLE EstadoTransaccion(
    IdEstadoTransaccion SMALLINT IDENTITY(1,1),
    Descripcion VARCHAR (15)
    PRIMARY KEY (IdEstadoTransaccion)
);

begin tran
insert into EstadoTransaccion Values ('Pendiente')
insert into EstadoTransaccion Values ('Completada')
insert into EstadoTransaccion Values ('Rechazada')
commit

CREATE TABLE Transaccion(
    IdTransaccion BIGINT IDENTITY(1,1),
    Fecha DATETIME DEFAULT CURRENT_TIMESTAMP,
    EstadoTransaccion SMALLINT DEFAULT 1,
    FOREIGN KEY (EstadoTransaccion) REFERENCES EstadoTransaccion,
    PRIMARY KEY (IdTransaccion) 
);


CREATE TABLE ContraOferta(
    IdNuevaTransaccion BIGINT NOT NULL,
    IdTransaccionContraofertada BIGINT NOT NULL,
    PRIMARY KEY (IdNuevaTransaccion, IdTransaccionContraofertada)
);

CREATE TABLE EsOfrecida(
    IdTransaccion BIGINT NOT NULL,
    IdProductoOfrecido BIGINT NOT NULL,
    FOREIGN KEY (IdProductoOfrecido) REFERENCES Publicacion (IdProducto),
    FOREIGN KEY (IdTransaccion) REFERENCES Transaccion(IdTransaccion),
    PRIMARY KEY (IdTransaccion, IdProductoOfrecido)
);

CREATE TABLE RecibeOferta(
    IdTransaccion BIGINT NOT NULL,
    IdProductoDeseado BIGINT NOT NULL,
    FOREIGN KEY (IdProductoDeseado) REFERENCES Publicacion (IdProducto),
    FOREIGN KEY (IdTransaccion) REFERENCES Transaccion(IdTransaccion),
    PRIMARY KEY (IdTransaccion, IdProductoDeseado)
);