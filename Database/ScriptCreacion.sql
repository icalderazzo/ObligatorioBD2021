CREATE DATABASE UCUTrade;

CREATE TABLE Usuario(
    Ci INT NOT NULL,
    Nombre NVARCHAR(30) NOT NULL,
    Apellido NVARCHAR(30) NOT NULL,
    Correo NVARCHAR(50) NOT NULL,
    NombreUsuario NVARCHAR(20) NOT NULL UNIQUE,
    Contrasenia NVARCHAR(30) NOT NULL,
    Telefono INT UNIQUE,
    PRIMARY KEY (Ci)
);

CREATE TABLE Publicacion(
    IdPublicacion BIGINT IDENTITY(1,1),
    Estado BIT DEFAULT 1,
    NombreProducto NVARCHAR(50) NOT NULL,
    DescripcionProducto NTEXT NOT NULL,
    ValorProducto INT NOT NULL,
    PRIMARY KEY (IdPublicacion)
);

CREATE TABLE Imagen (
	IdPublicacion BIGINT NOT NULL,
	Imagen VARBINARY(MAX) NOT NULL,
	FOREIGN KEY IdPublicacion REFERENCES Publicacion(IdPublicacion),
	PRIMARY KEY (IdPublicacion)
);

CREATE TABLE UsuarioPublicacion(
    CiUsuario INT NOT NULL,
    IdPublicacion BIGINT NOT NULL,
    FechaPublicacion DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (CiUsuario) REFERENCES Usuario(Ci),
    FOREIGN KEY (IdPublicacion) REFERENCES Publicacion(IdPublicacion),
    PRIMARY KEY (IdPublicacion)
);

CREATE TABLE EstadoOferta(
    IdEstadoOferta SMALLINT IDENTITY(1,1),
    Descripcion VARCHAR (15)
    PRIMARY KEY (IdEstadoOferta)
);

begin tran
insert into EstadoOferta Values ('Pendiente')
insert into EstadoOferta Values ('Completada')
insert into EstadoOferta Values ('Rechazada')
commit


CREATE TABLE Oferta(
    IdOferta BIGINT IDENTITY(1,1),
    FechaRealizacion DATETIME,
    EstadoOferta SMALLINT DEFAULT 1,
    FOREIGN KEY (EstadoOferta) REFERENCES EstadoOferta,
    PRIMARY KEY (IdOferta) 
);

CREATE TABLE RolOferta(
    IdRolOferta SMALLINT IDENTITY(1,1),
    Descripcion NVARCHAR(30),
    PRIMARY KEY (IdRolOferta)
);

begin tran
insert into RolOferta Values ('Emisor')
insert into RolOferta Values ('Destinatario')
commit

CREATE TABLE UsuarioOferta(
    CiUsuario INT NOT NULL,
    IdOferta BIGINT NOT NULL,
    IdRolOferta SMALLINT NOT NULL,
    FOREIGN KEY (CiUsuario) REFERENCES Usuario (Ci),
    FOREIGN KEY (IdOferta) REFERENCES Oferta (IdOferta),
    FOREIGN KEY (IdRolOferta) REFERENCES RolOferta (IdRolOferta),
    PRIMARY KEY (CiUsuario, IdOferta)
);


CREATE TABLE ContraOferta(
    IdOfertaNueva BIGINT NOT NULL,
    IdOfertaAnterior BIGINT NOT NULL,
    FOREIGN KEY (IdOfertaNueva) REFERENCES Oferta (IdOferta),
    FOREIGN KEY (IdOfertaAnterior) REFERENCES Oferta (IdOferta),
    PRIMARY KEY (IdOfertaNueva, IdOfertaAnterior)
);

CREATE TABLE PublicacionOferta(
    IdPublicacion BIGINT NOT NULL,
    IdOferta BIGINT NOT NULL,
    FOREIGN KEY (IdPublicacion) REFERENCES Publicacion (IdPublicacion),
    FOREIGN KEY (IdOferta) REFERENCES Oferta (IdOferta),
    PRIMARY KEY (IdPublicacion, IdOferta)
);