-----------------------------------------------------------------------
-- MASTER TABLE
USE GD2C2015;

-----------------------------------------------------------------------
-- SCHEMA

IF NOT EXISTS (
    SELECT schema_name 
    FROM information_schema.schemata 
    WHERE schema_name = 'AERO' 
    )

BEGIN
    EXEC sp_executesql N'CREATE SCHEMA AERO;';
END

-----------------------------------------------------------------------
-- DROP TABLES
IF OBJECT_ID('AERO.butacas_por_vuelo') IS NOT NULL
BEGIN
    DROP TABLE AERO.butacas_por_vuelo;
END;

IF OBJECT_ID('AERO.canjes') IS NOT NULL
BEGIN
    DROP TABLE AERO.canjes;
END;

IF OBJECT_ID('AERO.productos') IS NOT NULL
BEGIN
    DROP TABLE AERO.productos;
END;

IF OBJECT_ID('AERO.aeronaves_por_periodos') IS NOT NULL
BEGIN
    DROP TABLE AERO.aeronaves_por_periodos;
END;

IF OBJECT_ID('AERO.periodos_de_inactividad') IS NOT NULL
BEGIN
    DROP TABLE AERO.periodos_de_inactividad;
END;

IF OBJECT_ID('AERO.funcionalidades_por_rol') IS NOT NULL
BEGIN
    DROP TABLE AERO.funcionalidades_por_rol;
END;

IF OBJECT_ID('AERO.funcionalidades') IS NOT NULL
BEGIN
    DROP TABLE AERO.funcionalidades;
END;

IF OBJECT_ID('AERO.usuarios') IS NOT NULL
BEGIN
    DROP TABLE AERO.usuarios;
END;

IF OBJECT_ID('AERO.tarjetas_de_credito') IS NOT NULL
BEGIN
    DROP TABLE AERO.tarjetas_de_credito;
END;

IF OBJECT_ID('AERO.tipos_tarjeta') IS NOT NULL
BEGIN
    DROP TABLE AERO.tipos_tarjeta;
END;

IF OBJECT_ID('AERO.paquetes') IS NOT NULL
BEGIN
    DROP TABLE AERO.paquetes;
END;

IF OBJECT_ID('AERO.pasajes') IS NOT NULL
BEGIN
    DROP TABLE AERO.pasajes;
END;

IF OBJECT_ID('AERO.cancelaciones') IS NOT NULL
BEGIN
    DROP TABLE AERO.cancelaciones;
END;

IF OBJECT_ID('AERO.boletos_de_compra') IS NOT NULL
BEGIN
    DROP TABLE AERO.boletos_de_compra;
END;

IF OBJECT_ID('AERO.vuelos') IS NOT NULL
BEGIN
    DROP TABLE AERO.vuelos;
END;

IF OBJECT_ID('AERO.rutas') IS NOT NULL
BEGIN
    DROP TABLE AERO.rutas;
END;

IF OBJECT_ID('AERO.aeropuertos') IS NOT NULL
BEGIN
    DROP TABLE AERO.aeropuertos;
END;

IF OBJECT_ID('AERO.ciudades') IS NOT NULL
BEGIN
    DROP TABLE AERO.ciudades;
END;

IF OBJECT_ID('AERO.butacas') IS NOT NULL
BEGIN
    DROP TABLE AERO.butacas;
END;

IF OBJECT_ID('AERO.aeronaves') IS NOT NULL
BEGIN
    DROP TABLE AERO.aeronaves;
END;

IF OBJECT_ID('AERO.tipos_de_servicio') IS NOT NULL
BEGIN
    DROP TABLE AERO.tipos_de_servicio;
END;

IF OBJECT_ID('AERO.fabricantes') IS NOT NULL
BEGIN
    DROP TABLE AERO.fabricantes;
END;

IF OBJECT_ID('AERO.clientes') IS NOT NULL
BEGIN
    DROP TABLE AERO.clientes;
END;

IF OBJECT_ID('AERO.roles') IS NOT NULL
BEGIN
    DROP TABLE AERO.roles;
END;

-----------------------------------------------------------------------
-- TABLES

CREATE TABLE AERO.aeronaves (
    ID  INT   IDENTITY(1,1)    PRIMARY KEY,
    MATRICULA        NVARCHAR(255)    UNIQUE NOT NULL,
    MODELO        NVARCHAR(255) DEFAULT 'modelo',
    KG_DISPONIBLES    NUMERIC(18,0)    NOT NULL,
    FABRICANTE_ID    INT            NOT NULL,
    TIPO_SERVICIO_ID    INT            NOT NULL,
    BAJA            NVARCHAR(255),
    FECHA_ALTA      DATETIME        NOT NULL,
    CANT_BUTACAS    INT            NOT NULL,
    FECHA_BAJA    DATETIME,
    CONSTRAINT aeronaves_CK001 CHECK (BAJA IN ('DEFINITIVA', 'POR_PERIODO'))
)

CREATE TABLE AERO.fabricantes (
    ID  INT  IDENTITY(1,1)    PRIMARY KEY,
    NOMBRE        NVARCHAR(255)    NOT NULL
)

CREATE TABLE AERO.tipos_de_servicio (
    ID INT   IDENTITY(1,1)    PRIMARY KEY,
    NOMBRE        NVARCHAR(255)    NOT NULL
)

CREATE TABLE AERO.butacas (
    ID  INT     IDENTITY(1,1)    PRIMARY KEY,
    NUMERO        NUMERIC(18,0)    NOT NULL,
    TIPO            NVARCHAR(255),
    PISO            NUMERIC(18,0),
    AERONAVE_ID    INT            NOT NULL,
    CONSTRAINT butacas_CK001 CHECK (TIPO IN ('VENTANILLA', 'PASILLO')),
	CONSTRAINT butacas_CK002 CHECK (PISO IN (1,2))
)

CREATE TABLE AERO.butacas_por_vuelo (
VUELO_ID INT NOT NULL,
BUTACA_ID INT NOT NULL,
ESTADO        NVARCHAR(255) DEFAULT 'LIBRE',
CONSTRAINT butacas_por_vuelo_CK001 CHECK (ESTADO IN ('LIBRE', 'COMPRADO')),
PRIMARY KEY(VUELO_ID,BUTACA_ID)
)

CREATE TABLE AERO.pasajes (
    ID    INT    IDENTITY(1,1)    PRIMARY KEY,
    PRECIO        NUMERIC(18,2)		NOT NULL,
    CODIGO        NUMERIC(18,0)     NOT NULL,
    BUTACA_ID        INT            NOT NULL,
    CLIENTE_ID        INT            NOT NULL,
    BOLETO_COMPRA_ID INT             NOT NULL,
    CANCELACION_ID INT DEFAULT NULL
)

CREATE TABLE AERO.clientes (
    ID   INT     IDENTITY(1,1)    PRIMARY KEY,
    ROL_ID        INT            NOT NULL,
    NOMBRE        NVARCHAR(255)    NOT NULL,
    APELLIDO        NVARCHAR(255),
    DNI            NUMERIC(18,0) NOT NULL,
    DIRECCION        NVARCHAR(255),
    TELEFONO        NUMERIC(18,0),
    MAIL            NVARCHAR(255),
    FECHA_NACIMIENTO DATETIME,
	BAJA			INT DEFAULT 0
)

CREATE TABLE AERO.boletos_de_compra (
    ID INT IDENTITY(100000,1)    PRIMARY KEY,
    FECHA_COMPRA    DATETIME          NOT NULL,
    PRECIO_COMPRA    NUMERIC(18,2)	NOT NULL,
    TIPO_COMPRA    NVARCHAR(255),
    CLIENTE_ID        INT            NOT NULL,
	MILLAS 			  INT,
	VUELO_ID         INT		NOT NULL,
    CONSTRAINT boletos_de_compra_CK001 CHECK (TIPO_COMPRA IN ('EFECTIVO', 'TARJETA'))
)

CREATE TABLE AERO.roles (
    ID    INT    IDENTITY(1,1)    PRIMARY KEY,
	NOMBRE 	NVARCHAR(255)		NOT NULL,
	ACTIVO	INT DEFAULT 1,
	CONSTRAINT roles_CK001 CHECK (ACTIVO IN (0,1))
)

CREATE TABLE AERO.funcionalidades (
    ID INT IDENTITY(1,1)    PRIMARY KEY,
    DETALLES        NVARCHAR(255) NOT NULL
)

CREATE TABLE AERO.funcionalidades_por_rol (
	ROL_ID    INT,
	FUNCIONALIDAD_ID INT, 
	PRIMARY KEY(ROL_ID,FUNCIONALIDAD_ID)
)
CREATE TABLE AERO.usuarios (
    ID INT IDENTITY(1,1)    PRIMARY KEY,
    ROL_ID        INT            NOT NULL ,
    USERNAME        NVARCHAR(255)    UNIQUE NOT NULL,
    PASSWORD        NVARCHAR(255)		NOT NULL,
	FECHA_CREACION DATETIME				NOT NULL,
	ULTIMA_MODIFICACION DATETIME		NOT NULL,
	INTENTOS_LOGIN INT NOT NULL DEFAULT 0,
	ACTIVO INT,
	CONSTRAINT usuarios_CK001 CHECK (ACTIVO IN (0,1))
)
CREATE TABLE AERO.productos (
    ID  INT  IDENTITY(1,1)    PRIMARY KEY,
    NOMBRE        NVARCHAR(255)    UNIQUE,
    MILLAS_REQUERIDAS INT  NOT NULL,
    STOCK        INT      NOT NULL    
)

CREATE TABLE AERO.periodos_de_inactividad (
    ID    INT     IDENTITY(1,1)    PRIMARY KEY,
    DESDE        DATETIME			NOT NULL,
    HASTA        DATETIME			NOT NULL
)

CREATE TABLE AERO.aeronaves_por_periodos (
    AERONAVE_ID INT,
    PERIODO_ID  INT,
    PRIMARY KEY(AERONAVE_ID,PERIODO_ID)
)

CREATE TABLE AERO.aeropuertos (
    ID  INT    IDENTITY(1,1)    PRIMARY KEY,
    NOMBRE        NVARCHAR(255)     NOT NULL,
    CIUDAD_ID        INT             NOT NULL
)

CREATE TABLE AERO.vuelos (
    ID     INT    IDENTITY(1,1)     PRIMARY KEY,
    FECHA_SALIDA     DATETIME		NOT NULL,
    FECHA_LLEGADA     DATETIME,
    FECHA_LLEGADA_ESTIMADA DATETIME NOT NULL,
    AERONAVE_ID     INT            NOT NULL,
    RUTA_ID         INT            NOT NULL,
	INVALIDO		INT			DEFAULT 0
)

CREATE TABLE AERO.rutas (
    ID     INT     IDENTITY(1,1)     PRIMARY KEY,
    CODIGO         NUMERIC(18,0)    NOT NULL,
    PRECIO_BASE_KG     NUMERIC(18,2)  NOT NULL,
    PRECIO_BASE_PASAJE NUMERIC(18,2) NOT NULL,
    ORIGEN_ID        INT            NOT NULL,
    DESTINO_ID        INT            NOT NULL,
	TIPO_SERVICIO_ID	INT	NOT NULL,
	BAJA			INT DEFAULT 0
)

CREATE TABLE AERO.ciudades (
    ID     INT     IDENTITY(1,1)     PRIMARY KEY,
    NOMBRE         NVARCHAR(255)    NOT NULL
)

CREATE TABLE AERO.paquetes(
    ID   INT  IDENTITY(1,1)     PRIMARY KEY,
    CODIGO         NUMERIC(18,0)    UNIQUE NOT NULL,
    PRECIO         NUMERIC(18,2)	NOT NULL,
    KG             NUMERIC(18,0)	NOT NULL,
    BOLETO_COMPRA_ID     INT		NOT NULL,
    CANCELACION_ID INT DEFAULT NULL
)

CREATE TABLE AERO.canjes (
    ID     INT    IDENTITY(1,1)     PRIMARY KEY,
    CLIENTE_ID         INT             NOT NULL,
    PRODUCTO_ID     INT             NOT NULL,
    CANTIDAD         INT			DEFAULT 1,
    FECHA_CANJE         DATETIME	NOT NULL
)

CREATE TABLE AERO.tarjetas_de_credito (
    ID   INT   IDENTITY(1,1)     PRIMARY KEY,
    TIPO_TARJETA_ID    INT NOT NULL,
    NUMERO         NUMERIC(18,0)    UNIQUE NOT NULL,
    FECHA_VTO         DATETIME        NOT NULL,
    CLIENTE_ID         INT            NOT NULL
)

CREATE TABLE AERO.tipos_tarjeta (
    ID   INT   IDENTITY(1,1)     PRIMARY KEY,
    NOMBRE    NVARCHAR(255) NOT NULL,
	CUOTAS INT DEFAULT 0   
)


CREATE TABLE AERO.cancelaciones (
    ID   INT   IDENTITY(1,1)     PRIMARY KEY,
    FECHA_DEVOLUCION DATETIME		NOT NULL,
    BOLETO_COMPRA_ID INT            NOT NULL,
    MOTIVO         NVARCHAR(255)   NOT NULL
)

-----------------------------------------------------------------------
-- FOREIGN KEYS && INDEXES

ALTER TABLE AERO.tarjetas_de_credito
ADD CONSTRAINT TARJETAS_FK01 FOREIGN KEY
(TIPO_TARJETA_ID) REFERENCES AERO.tipos_tarjeta (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'TARJ_TIPO_TARJ' AND object_id = OBJECT_ID('AERO.tarjetas_de_credito'))
    BEGIN
       CREATE INDEX TARJ_TIPO_TARJ ON AERO.tarjetas_de_credito (TIPO_TARJETA_ID);
    END

ALTER TABLE AERO.tarjetas_de_credito
ADD CONSTRAINT TARJETAS_FK02 FOREIGN KEY
(CLIENTE_ID) REFERENCES AERO.clientes (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_TARJ_CLIE' AND object_id = OBJECT_ID('AERO.tarjetas_de_credito'))
    BEGIN
       CREATE INDEX FKI_TARJ_CLIE ON AERO.tarjetas_de_credito (CLIENTE_ID);
    END

ALTER TABLE AERO.aeronaves
ADD CONSTRAINT AERONAVES_FK01 FOREIGN KEY
(FABRICANTE_ID) REFERENCES AERO.fabricantes (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'AERO_FABRIC' AND object_id = OBJECT_ID('AERO.aeronaves'))
    BEGIN
       CREATE INDEX AERO_FABRIC ON AERO.aeronaves (FABRICANTE_ID);
    END

ALTER TABLE AERO.aeronaves
ADD CONSTRAINT AERONAVES_FK02 FOREIGN KEY
(TIPO_SERVICIO_ID) REFERENCES AERO.tipos_de_servicio (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'AERO_TIPO_SERV' AND object_id = OBJECT_ID('AERO.aeronaves'))
    BEGIN
       CREATE INDEX AERO_TIPO_SERV ON AERO.aeronaves (TIPO_SERVICIO_ID);
    END

ALTER TABLE AERO.butacas
ADD CONSTRAINT BUTACAS_FK01 FOREIGN KEY
(AERONAVE_ID) REFERENCES AERO.aeronaves (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'BUTAC_AERO' AND object_id = OBJECT_ID('AERO.butacas'))
    BEGIN
       CREATE INDEX BUTAC_AERO ON AERO.butacas (AERONAVE_ID);
    END

ALTER TABLE AERO.butacas_por_vuelo
ADD CONSTRAINT butacas_por_vu_FK01 FOREIGN KEY
(VUELO_ID) REFERENCES AERO.vuelos (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'BUTAC_VUELO_VUELO' AND object_id = OBJECT_ID('AERO.butacas_por_vuelo'))
    BEGIN
       CREATE INDEX BUTAC_VUELO_VUELO ON AERO.butacas_por_vuelo (VUELO_ID);
    END

ALTER TABLE AERO.butacas_por_vuelo
ADD CONSTRAINT butacas_por_aeronave_FK02 FOREIGN KEY
(BUTACA_ID) REFERENCES AERO.butacas (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'BUTAC_VUELO_BUTACA' AND object_id = OBJECT_ID('AERO.butacas_por_vuelo'))
    BEGIN
       CREATE INDEX BUTAC_VUELO_BUTACA ON AERO.butacas_por_vuelo (BUTACA_ID);
    END

ALTER TABLE AERO.pasajes
ADD CONSTRAINT PASAJES_FK01 FOREIGN KEY
(BUTACA_ID) REFERENCES AERO.butacas (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'PASAJ_BUTAC' AND object_id = OBJECT_ID('AERO.pasajes'))
    BEGIN
       CREATE INDEX PASAJ_BUTAC ON AERO.pasajes (BUTACA_ID);
    END

ALTER TABLE AERO.pasajes
ADD CONSTRAINT PASAJES_FK02 FOREIGN KEY
(CLIENTE_ID) REFERENCES AERO.clientes (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'PASAJ_CLIENT' AND object_id = OBJECT_ID('AERO.pasajes'))
    BEGIN
       CREATE INDEX PASAJ_CLIENT ON AERO.pasajes (CLIENTE_ID);
    END

ALTER TABLE AERO.pasajes
ADD CONSTRAINT PASAJES_FK03 FOREIGN KEY
(BOLETO_COMPRA_ID) REFERENCES AERO.boletos_de_compra (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'PASAJ_BOL_COMP' AND object_id = OBJECT_ID('AERO.pasajes'))
    BEGIN
       CREATE INDEX PASAJ_BOL_COMP ON AERO.pasajes (BOLETO_COMPRA_ID);
    END

ALTER TABLE AERO.pasajes
ADD CONSTRAINT PASAJES_FK04 FOREIGN KEY
(CANCELACION_ID) REFERENCES AERO.cancelaciones (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'PASAJ_CANC' AND object_id = OBJECT_ID('AERO.pasajes'))
    BEGIN
       CREATE INDEX PASAJ_CANC ON AERO.pasajes (CANCELACION_ID);
    END

ALTER TABLE AERO.clientes
ADD CONSTRAINT CLIENTES_FK01 FOREIGN KEY
(ROL_ID) REFERENCES AERO.roles (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'CLIENT_ROLES' AND object_id = OBJECT_ID('AERO.clientes'))
    BEGIN
       CREATE INDEX CLIENT_ROLES ON AERO.clientes (ROL_ID);
    END

ALTER TABLE AERO.boletos_de_compra
ADD CONSTRAINT BOLETOS_DE_COMPRA_FK01 FOREIGN KEY
(CLIENTE_ID) REFERENCES AERO.clientes (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_BOL_COMP_CLIENT' AND object_id = OBJECT_ID('AERO.boletos_de_compra'))
    BEGIN
       CREATE INDEX FKI_BOL_COMP_CLIENT ON AERO.boletos_de_compra (CLIENTE_ID);
    END

ALTER TABLE AERO.boletos_de_compra
ADD CONSTRAINT boletos_FK02 FOREIGN KEY
(VUELO_ID) REFERENCES AERO.vuelos (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_BOLETO_VUEL' AND object_id = OBJECT_ID('AERO.boletos_de_compra'))
    BEGIN
       CREATE INDEX FKI_BOLETO_VUEL ON AERO.boletos_de_compra (VUELO_ID);
    END

ALTER TABLE AERO.funcionalidades_por_rol
ADD CONSTRAINT FUNCIONALIDADES_POR_ROL_FK01 FOREIGN KEY
(ROL_ID) REFERENCES AERO.roles (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_FUNCXROL_ROL' AND object_id = OBJECT_ID('AERO.funcionalidades_por_rol'))
    BEGIN
       CREATE INDEX FKI_FUNCXROL_ROL ON AERO.funcionalidades_por_rol (ROL_ID);
    END

ALTER TABLE AERO.funcionalidades_por_rol
ADD CONSTRAINT FUNCIONALIDADES_POR_ROL_FK02 FOREIGN KEY
(FUNCIONALIDAD_ID) REFERENCES AERO.funcionalidades (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_FUNCXROL_FUNC' AND object_id = OBJECT_ID('AERO.funcionalidades_por_rol'))
    BEGIN
       CREATE INDEX FKI_FUNCXROL_FUNC ON AERO.funcionalidades_por_rol (FUNCIONALIDAD_ID);
    END

ALTER TABLE AERO.usuarios
ADD CONSTRAINT USUARIOS_FK01 FOREIGN KEY
(ROL_ID) REFERENCES AERO.roles (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_USR_ROL' AND object_id = OBJECT_ID('AERO.usuarios'))
    BEGIN
       CREATE INDEX FKI_USR_ROL ON AERO.usuarios (ROL_ID);
    END

ALTER TABLE AERO.aeronaves_por_periodos
ADD CONSTRAINT AERONAVES_POR_PERIODOS_FK01 FOREIGN KEY
(AERONAVE_ID) REFERENCES AERO.aeronaves (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_AEROXPER_AERO' AND object_id = OBJECT_ID('AERO.aeronaves_por_periodos'))
    BEGIN
       CREATE INDEX FKI_AEROXPER_AERO ON AERO.aeronaves_por_periodos (AERONAVE_ID);
    END

ALTER TABLE AERO.aeronaves_por_periodos
ADD CONSTRAINT AERONAVES_POR_PERIODOS_FK02 FOREIGN KEY
(PERIODO_ID) REFERENCES AERO.periodos_de_inactividad (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_AEROXPER_PERXINAC' AND object_id = OBJECT_ID('AERO.aeronaves_por_periodos'))
    BEGIN
       CREATE INDEX FKI_AEROXPER_PERXINAC ON AERO.aeronaves_por_periodos (PERIODO_ID);
    END

ALTER TABLE AERO.aeropuertos
ADD CONSTRAINT AEROPUERTOS_FK01 FOREIGN KEY
(CIUDAD_ID) REFERENCES AERO.ciudades (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_AERO_CIUD' AND object_id = OBJECT_ID('AERO.aeropuertos'))
    BEGIN
       CREATE INDEX FKI_AERO_CIUD ON AERO.aeropuertos (CIUDAD_ID);
    END

ALTER TABLE AERO.vuelos
ADD CONSTRAINT VUELOS_FK01 FOREIGN KEY
(AERONAVE_ID) REFERENCES AERO.aeronaves (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_VUEL_AERO' AND object_id = OBJECT_ID('AERO.vuelos'))
    BEGIN
       CREATE INDEX FKI_VUEL_AERO ON AERO.vuelos (AERONAVE_ID);
    END

ALTER TABLE AERO.vuelos
ADD CONSTRAINT VUELOS_FK02 FOREIGN KEY
(RUTA_ID) REFERENCES AERO.rutas (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_VUEL_RUT' AND object_id = OBJECT_ID('AERO.vuelos'))
    BEGIN
       CREATE INDEX FKI_VUEL_RUT ON AERO.vuelos (RUTA_ID);
    END

ALTER TABLE AERO.rutas
ADD CONSTRAINT rutas_FK01 FOREIGN KEY
(TIPO_SERVICIO_ID) REFERENCES AERO.tipos_de_servicio (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_rutas_tipo_servicio' AND object_id = OBJECT_ID('AERO.rutas'))
    BEGIN
       CREATE INDEX FKI_rutas_tipo_servicio ON AERO.rutas (TIPO_SERVICIO_ID);
    END

ALTER TABLE AERO.rutas
ADD CONSTRAINT RUTAS_FK02 FOREIGN KEY
(ORIGEN_ID) REFERENCES AERO.aeropuertos (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_RUT_AERO' AND object_id = OBJECT_ID('AERO.rutas'))
    BEGIN
       CREATE INDEX FKI_RUT_AERO ON AERO.rutas (ORIGEN_ID);
    END

ALTER TABLE AERO.rutas
ADD CONSTRAINT RUTAS_FK03 FOREIGN KEY
(DESTINO_ID) REFERENCES AERO.aeropuertos (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_RUT_AERO2' AND object_id = OBJECT_ID('AERO.rutas'))
    BEGIN
       CREATE INDEX FKI_RUT_AERO2 ON AERO.rutas (DESTINO_ID);
    END

ALTER TABLE AERO.paquetes
ADD CONSTRAINT paquetes_FK01 FOREIGN KEY
(BOLETO_COMPRA_ID) REFERENCES AERO.boletos_de_compra (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_PAQ_BOLDECOMP' AND object_id = OBJECT_ID('AERO.paquetes'))
    BEGIN
       CREATE INDEX FKI_PAQ_BOLDECOMP ON AERO.paquetes (BOLETO_COMPRA_ID);
    END

ALTER TABLE AERO.paquetes
ADD CONSTRAINT paquetes_FK02 FOREIGN KEY
(CANCELACION_ID) REFERENCES AERO.cancelaciones (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_PAQ_CANC' AND object_id = OBJECT_ID('AERO.paquetes'))
    BEGIN
       CREATE INDEX FKI_PAQ_CANC ON AERO.paquetes (CANCELACION_ID);
    END

ALTER TABLE AERO.canjes
ADD CONSTRAINT CANJES_FK01 FOREIGN KEY
(PRODUCTO_ID) REFERENCES AERO.productos (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_CANJ_PROD' AND object_id = OBJECT_ID('AERO.canjes'))
    BEGIN
       CREATE INDEX FKI_CANJ_PROD ON AERO.canjes (PRODUCTO_ID);
    END

ALTER TABLE AERO.canjes
ADD CONSTRAINT CANJES_FK02 FOREIGN KEY
(CLIENTE_ID) REFERENCES AERO.clientes (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_CANJ_CLIE' AND object_id = OBJECT_ID('AERO.canjes'))
    BEGIN
       CREATE INDEX FKI_CANJ_CLIE ON AERO.canjes (CLIENTE_ID);
    END

ALTER TABLE AERO.cancelaciones
ADD CONSTRAINT CANCELACIONES_FK01 FOREIGN KEY
(BOLETO_COMPRA_ID) REFERENCES AERO.boletos_de_compra (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_CANC_BOLCOMP' AND object_id = OBJECT_ID('AERO.cancelaciones'))
    BEGIN
       CREATE INDEX FKI_CANC_BOLCOMP ON AERO.cancelaciones (BOLETO_COMPRA_ID);
    END
-----------------------------------------------------------------------
-- INSERTS

INSERT INTO AERO.funcionalidades VALUES
('Consultar Millas'),
('Alta de Cliente'),
('Alta de Aeronave'),
('Alta de Tarjeta de Crédito'),
('Baja de Aeronave'),
('Baja de Ciudad'),
('Baja de Cliente'),
('Modificacion de Aeronave'),
('Modificacion de Cliente'),
('Realizar Canje'),
('Alta de Rol'),
('Baja de Rol'),
('Modificacion de Rol'),
('Alta de Ruta'),
('Baja de Ruta'),
('Modificacion de Ruta'),
('Comprar Pasaje/Encomienda'),
('Generar Viaje'),
('Registrar Llegadas'),
('Consultar Listado');

INSERT INTO AERO.roles (nombre, activo) VALUES
('administrador', 1),
('cliente', 1);

INSERT INTO AERO.usuarios  (ROL_ID, USERNAME, PASSWORD, FECHA_CREACION, ULTIMA_MODIFICACION, INTENTOS_LOGIN, ACTIVO) VALUES 
(1, 'admin', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', GETDATE(), GETDATE(), 0, 1);

INSERT INTO AERO.productos (NOMBRE, MILLAS_REQUERIDAS, STOCK)
VALUES ('Valija', 150, 50),
('Candado', 10, 200),
('Almohada', 45, 100),
('Auto', 10000, 15),
('Calefactor', 500, 150);

INSERT INTO AERO.tipos_tarjeta (NOMBRE, CUOTAS)
VALUES ('VISA', 6),
('MASTERCARD', 12),
('AMEX', 3),
('DINERS', 0);

-----------------------------------------------------------------------
-- PROCEDURES && FUNCTIONS

--DROP
IF OBJECT_ID('AERO.corrigeMail') IS NOT NULL
    DROP FUNCTION AERO.corrigeMail
GO

IF OBJECT_ID('AERO.cantButacasLibres') IS NOT NULL
BEGIN
    DROP FUNCTION AERO.cantButacasLibres
END;
GO

IF OBJECT_ID('AERO.kgLibres') IS NOT NULL
BEGIN
    DROP FUNCTION AERO.kgLibres
END;
GO

IF OBJECT_ID('AERO.addFuncionalidad') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.addFuncionalidad;
END;
GO

IF OBJECT_ID('AERO.agregarFuncionalidad') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.agregarFuncionalidad;
END;
GO

IF OBJECT_ID('AERO.quitarFuncionalidad') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.quitarFuncionalidad;
END;
GO

IF OBJECT_ID('AERO.agregarRol') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.agregarRol;
END;
GO

IF OBJECT_ID('AERO.vuelosDisponibles') IS NOT NULL
BEGIN
    DROP PROCEDURE AERO.vuelosDisponibles
END;
GO

IF OBJECT_ID('AERO.inhabilitarRol') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.inhabilitarRol;
END;
GO

IF OBJECT_ID('AERO.habilitarRol') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.habilitarRol;
END;
GO

IF OBJECT_ID('AERO.UpdateIntento') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.UpdateIntento;
END;
GO

IF OBJECT_ID('AERO.agregarCliente') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.agregarCliente;
END;
GO

IF OBJECT_ID('AERO.updateCliente') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.updateCliente;
END;
GO

IF OBJECT_ID('AERO.bajaCliente') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.bajaCliente;
END;
GO

IF OBJECT_ID('AERO.agregarAeronave') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.agregarAeronave;
END;
GO

IF OBJECT_ID('AERO.updateAeronave') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.updateAeronave;
END;
GO

IF OBJECT_ID('AERO.bajaAeronave') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.bajaAeronave;
END;
GO

IF OBJECT_ID('AERO.agregarRuta') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.agregarRuta;
END;
GO

IF OBJECT_ID('AERO.updateRuta') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.updateRuta;
END;
GO

IF OBJECT_ID('AERO.bajaRuta') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.bajaRuta;
END;
GO

IF OBJECT_ID('AERO.top5DestinosConPasajes') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.top5DestinosConPasajes;
END;
GO

IF OBJECT_ID('AERO.top5DestinosCancelados') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.top5DestinosCancelados;
END;
GO

IF OBJECT_ID('AERO.top5DestinosAeronavesVacias') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.top5DestinosAeronavesVacias;
END;
GO

IF OBJECT_ID('AERO.top5ClientesMillas') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.top5ClientesMillas;
END;
GO

IF OBJECT_ID('AERO.top5AeronavesFueraDeServicio') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.top5AeronavesFueraDeServicio;
END;
GO

IF OBJECT_ID('AERO.generarViaje') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.generarViaje;
END;
GO

IF OBJECT_ID('AERO.registrarLlegada') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.registrarLlegada;
END;
GO

IF OBJECT_ID('AERO.validarVuelo') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.validarVuelo;
END;
GO

IF OBJECT_ID('AERO.consultarMillas') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.consultarMillas;
END;
GO

IF OBJECT_ID('AERO.obtenerClienteConMillas') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.obtenerClienteConMillas;
END;
GO

IF OBJECT_ID('AERO.altaCanje') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.altaCanje;
END;
GO

IF OBJECT_ID('AERO.migracionButacasPorVuelo') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.migracionButacasPorVuelo;
END;
GO

IF OBJECT_ID('AERO.altaTarjeta') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.altaTarjeta;
END;
GO

IF OBJECT_ID('AERO.bajaCiudad') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.bajaCiudad;
END;
GO

IF OBJECT_ID('AERO.crearButacas') IS NOT NULL
BEGIN
	DROP PROCEDURE AERO.crearButacas;
END;
GO

--CREATE
CREATE FUNCTION AERO.corrigeMail (@s NVARCHAR (255)) 
RETURNS NVARCHAR(255)
AS
BEGIN
   IF @s is null
      RETURN null
   
   DECLARE @s2 NVARCHAR(255)
   SET @s2 = ''
   DECLARE @l int
   SET @l = len(@s)
   DECLARE @p int
   SET @p = 1
   WHILE @p <= @l
   BEGIN
      DECLARE @c int;
      SET @c = ascii(substring(@s, @p, 1))
      set @c = LOWER(@c)

      if (@c = 32) set @c = ascii('_')      
	  if @c = ascii('ä') set @c = ascii('a')
	  if @c = ascii('ë') set @c = ascii('e')
	  if @c = ascii('ï') set @c = ascii('i')
	  if @c = ascii('ö') set @c = ascii('o')
      if @c = ascii('ü') set @c = ascii('u')
	  if @c = ascii('á') set @c = ascii('a')
      if @c = ascii('é') set @c = ascii('e')
	  if @c = ascii('í') set @c = ascii('i')
	  if @c = ascii('ó') set @c = ascii('o')
	  if @c = ascii('ú') set @c = ascii('u')
	  if @c = ascii('à') set @c = ascii('a')
      if @c = ascii('è') set @c = ascii('e')
	  if @c = ascii('ì') set @c = ascii('i')
	  if @c = ascii('ò') set @c = ascii('o')
	  if @c = ascii('ù') set @c = ascii('u')
	  if @c = ascii('ñ') set @c = ascii('n')

      if (@c between 48 and 57 or @c = 64 or @c = 45 or @c = 46 
      or @c = 95 or @c between 65 and 90 or @c between 97 and 122)
		
		SET @s2 = @s2 + char(@c)
      
      SET @p = @p + 1
   END
   IF len(@s2) = 0
      return null
   return @s2
END
GO
CREATE FUNCTION AERO.kgLibres(@vuelo int)
RETURNS INT
AS BEGIN
	DECLARE @kgOcupados INT;
	DECLARE @KgTot INT
	SET @kgOcupados=(SELECT SUM(p.KG) from AERO.boletos_de_compra b 
	join AERO.paquetes p on p.BOLETO_COMPRA_ID = b.ID
	where b.VUELO_ID = @vuelo)
	SET @KgTot=(SELECT a.KG_DISPONIBLES from AERO.vuelos v join
	AERO.aeronaves a on a.ID = v.AERONAVE_ID
	where v.ID = @vuelo )
	IF(@kgOcupados IS NULL)
		RETURN @kgTot;
	RETURN @KgTot - @kgOcupados
END
GO

CREATE FUNCTION AERO.cantButacasLibres(@vuelo int)
RETURNS INT
AS BEGIN
	DECLARE @butacasOcupadas INT;
	DECLARE @butacasTot INT;
	SET @butacasOcupadas = (SELECT COUNT(bu.ID)
     FROM  [GD2C2015].[AERO].[boletos_de_compra] b 
	 JOIN [GD2C2015].[AERO].[pasajes] p on b.ID = p.BOLETO_COMPRA_ID 
	 join AERO.butacas bu on p.BUTACA_ID = bu.ID
	 join AERO.aeronaves a on a.ID = bu.AERONAVE_ID
	 join AERO.butacas_por_vuelo buV on bu.ID=buV.BUTACA_ID and buV.VUELO_ID=@vuelo
	 where  b.VUELO_ID =@vuelo AND buV.ESTADO ='COMPRADO')
	 SET @butacasTot=(SELECT a.CANT_BUTACAS from AERO.vuelos v join
	AERO.aeronaves a on a.ID = v.AERONAVE_ID
	where v.ID = @vuelo )
	RETURN  @butacasTot - @butacasOcupadas
END
GO

-- ROLES Y FUNCIONALIDADES
CREATE PROCEDURE AERO.agregarRol(@nombreRol nvarchar(255),@retorno int output)
AS BEGIN
	INSERT INTO AERO.Roles (NOMBRE,ACTIVO) VALUES (@nombreRol, 1)
	SET @retorno = SCOPE_IDENTITY()
END
GO

CREATE PROCEDURE AERO.inhabilitarRol(@idRol int)
AS BEGIN
UPDATE AERO.roles
SET ACTIVO = 0
WHERE ID = @idRol
END
GO

CREATE PROCEDURE AERO.habilitarRol(@idRol int)
AS BEGIN
UPDATE AERO.roles
SET ACTIVO = 1
WHERE ID = @idRol
END
GO

CREATE PROCEDURE AERO.addFuncionalidad(@rol nvarchar(255), @func nvarchar(255)) AS
BEGIN
	INSERT INTO AERO.funcionalidades_por_rol (ROL_ID, FUNCIONALIDAD_ID)
		VALUES ((SELECT id FROM AERO.roles WHERE NOMBRE = @rol),
		        (SELECT id FROM AERO.funcionalidades WHERE DETALLES = @func))
END
GO

CREATE PROCEDURE AERO.agregarFuncionalidad(@idRol int, @idFunc int)
AS BEGIN
INSERT INTO AERO.funcionalidades_por_rol (ROL_ID, FUNCIONALIDAD_ID)
VALUES (@idRol, @idFunc)
END
GO

CREATE PROCEDURE AERO.quitarFuncionalidad(@idRol int, @idFunc int)
AS BEGIN
DELETE FROM AERO.funcionalidades_por_rol
WHERE ROL_ID = @idRol and FUNCIONALIDAD_ID = @idFunc
END
GO

-- INTENTOS
CREATE PROCEDURE AERO.UpdateIntento(@nombre varchar(25), @exitoso int)
AS BEGIN
	IF(@exitoso = 1)
		BEGIN
			UPDATE AERO.usuarios  SET INTENTOS_LOGIN=0 WHERE USERNAME=@nombre
		END
	ELSE
		BEGIN
			DECLARE @cant_Intentos int
			SELECT @cant_Intentos = intentos_login FROM AERO.usuarios WHERE USERNAME=@nombre
			IF( @cant_Intentos = 2)
				BEGIN
					UPDATE AERO.usuarios  SET ACTIVO=0, INTENTOS_LOGIN=0 WHERE USERNAME=@nombre
				END
			ELSE
				BEGIN
					UPDATE AERO.usuarios set INTENTOS_LOGIN=@cant_Intentos+1 WHERE USERNAME=@nombre
				END
		END
END
GO

-- CLIENTES
CREATE PROCEDURE AERO.agregarCliente(@rol_id INT, @nombreCliente nvarchar(255), @apellidoCliente nvarchar(255), 
	@documentoCliente numeric(18,0), @direccion nvarchar(255), 
	@telefono numeric(18,0), @mail nvarchar(255), @fechaNac varchar(50))
AS BEGIN
	INSERT INTO AERO.Clientes (rol_id, nombre, apellido, dni, direccion,telefono,
	mail,FECHA_NACIMIENTO)  
	VALUES (@rol_id, SUBSTRING(UPPER (@nombreCliente), 1, 1) + SUBSTRING (LOWER (@nombreCliente), 2,LEN(@nombreCliente)), 
	SUBSTRING(UPPER (@apellidoCliente), 1, 1) + SUBSTRING (LOWER (@apellidoCliente), 2,LEN(@apellidoCliente)), 
	@documentoCliente, @direccion, 
	@telefono, AERO.corrigeMail(@mail), convert(datetime, @fechaNac,109))
END
GO

CREATE PROCEDURE AERO.updateCliente(@id INT, @direccion nvarchar(255), @telefono numeric(18,0), @mail nvarchar(255))
AS BEGIN
UPDATE AERO.clientes
SET DIRECCION = @direccion, TELEFONO = @telefono, MAIL =  AERO.corrigeMail(@mail)
WHERE ID = @id
END
GO

CREATE PROCEDURE AERO.bajaCliente(@id  INT)
AS BEGIN
UPDATE AERO.clientes
SET BAJA = 1
WHERE ID=@id;
END
GO

--BUTACAS
CREATE PROCEDURE AERO.crearButacas (@idAeronave int, @butacas int)
AS BEGIN
declare @i int
declare @tipo varchar(50)
set @i = 1
	WHILE(@i != @butacas+1)
	begin
		if((@i%2) = 0)
		begin
		set @tipo = 'Ventanilla'
		end
		else
		begin
		set @tipo = 'Pasillo'
		end
		INSERT INTO AERO.butacas (AERONAVE_ID, NUMERO, PISO, TIPO)
		VALUES (@idAeronave, @i, 1, @tipo)
		set @i = @i+1
	end
END
GO

-- AERONAVES
CREATE PROCEDURE AERO.agregarAeronave(@matricula nvarchar(255), @modelo nvarchar(255), @kg_disponibles numeric(18,0), 
@fabricante nvarchar(255), @tipo_servicio nvarchar(255), @alta varchar(50), @cantButacas int)
AS BEGIN
	INSERT INTO AERO.aeronaves(MATRICULA, MODELO, KG_DISPONIBLES, FABRICANTE_ID, TIPO_SERVICIO_ID, FECHA_ALTA, CANT_BUTACAS)
	VALUES (@matricula, @modelo, @kg_disponibles, @fabricante, @tipo_servicio, convert(datetime, @alta,109), @cantButacas)
	declare @id int
	set @id = SCOPE_IDENTITY()
	EXEC AERO.crearButacas @idAeronave = @id, @butacas = @cantButacas
END
GO

CREATE PROCEDURE AERO.updateAeronave(@id  INT, @fechaInicio varchar(50), @fechaFin varchar(50))
AS BEGIN
DECLARE @IDPERIODO INT
SELECT @IDPERIODO= ID FROM AERO.periodos_de_inactividad WHERE DESDE=convert(datetime, @fechaInicio,109) AND 
HASTA=convert(datetime, @fechaFin,109)
	IF(@IDPERIODO IS NULL)
		BEGIN
			INSERT INTO AERO.periodos_de_inactividad VALUES(convert(datetime, @fechaInicio,109),convert(datetime, @fechaFin,109)) 
			SET @IDPERIODO=SCOPE_IDENTITY()
		END
INSERT INTO  AERO.aeronaves_por_periodos VALUES(@ID,@IDPERIODO)
UPDATE AERO.aeronaves SET BAJA='POR_PERIODO' WHERE ID=@id; 
END
GO

CREATE PROCEDURE AERO.bajaAeronave(@id  INT)
AS BEGIN
UPDATE AERO.aeronaves SET BAJA='DEFINITIVA',
FECHA_BAJA= CURRENT_TIMESTAMP
WHERE ID=@id;
END
GO

-- RUTAS
CREATE PROCEDURE AERO.agregarRuta(@codigo int, @precioKg numeric(18,2), @precioPasaje numeric(18,2), @origen int, @destino int, 
	@servicio int)
AS BEGIN
	INSERT INTO AERO.rutas(CODIGO, PRECIO_BASE_KG, PRECIO_BASE_PASAJE, ORIGEN_ID, DESTINO_ID, TIPO_SERVICIO_ID)
	VALUES (@codigo, @precioKg, @precioPasaje, @origen, @destino, @servicio)
END
GO

CREATE PROCEDURE AERO.updateRuta(@id INT, @precioKg numeric(18,2), @precioPasaje numeric(18,2), @servicio INT)
AS BEGIN
UPDATE AERO.rutas
SET PRECIO_BASE_KG = @precioKg, PRECIO_BASE_PASAJE = @precioPasaje, TIPO_SERVICIO_ID = @servicio
WHERE ID = @id
END
GO

CREATE PROCEDURE AERO.bajaRuta(@id INT)
AS BEGIN
UPDATE AERO.rutas
SET BAJA = 1
WHERE ID=@id;
END
GO

--Vuelos
CREATE PROCEDURE AERO.vuelosDisponibles(@fecha varchar(50))
AS BEGIN
	Select v.ID as ID ,v.FECHA_SALIDA as 'Salida', v.FECHA_LLEGADA_ESTIMADA as 'Llegada Estimada', o.NOMBRE as Origen, d.NOMBRE as Destino,
	 AERO.cantButacasLibres(v.ID) as 'Butacas Libres', AERO.kgLibres(v.ID) as 'Kg Disponibles'
	from AERO.vuelos v
	join AERO.rutas r on r.ID = v.RUTA_ID
	join AERO.aeropuertos o on r.ORIGEN_ID = o.ID
	join AERO.aeropuertos d on r.DESTINO_ID = d.ID
	join AERO.aeronaves a on v.AERONAVE_ID = a.ID
	where (v.INVALIDO = 0) AND (v.FECHA_SALIDA > convert(datetime, @fecha,109)) 
	AND( (AERO.cantButacasLibres(v.ID)  != 0 ) OR (AERO.kgLibres(v.ID) !=0 ))
END
GO


--LISTADOS ESTADISTICOS
--TOP 5 de los destino con mas pasajes comprados
CREATE PROCEDURE AERO.top5DestinosConPasajes(@fechaFrom varchar(50), @fechaTo varchar(50))
AS BEGIN
select top 5 a.NOMBRE as Destino, count(p.ID) as 'Cantidad de Pasajes' 
from AERO.pasajes p 
join AERO.boletos_de_compra bc on p.BOLETO_COMPRA_ID=bc.ID
join AERO.vuelos v on bc.VUELO_ID=v.ID 
join AERO.rutas r on v.RUTA_ID=r.ID
join AERO.aeropuertos a on r.DESTINO_ID=a.ID
where bc.id NOT IN (select BOLETO_COMPRA_ID from AERO.cancelaciones)
and bc.FECHA_COMPRA between convert(datetime, @fechaFrom,109) and convert(datetime, @fechaTo,109)
group by a.nombre 
order by 2 desc
END
GO

--TOP 5 de los destinos con más pasajes cancelados 
CREATE PROCEDURE AERO.top5DestinosCancelados(@fechaFrom varchar(50), @fechaTo varchar(50))
AS BEGIN
select top 5 a.NOMBRE as Destino, count(p.ID) as Cancelaciones from AERO.pasajes p
join AERO.boletos_de_compra bc on p.BOLETO_COMPRA_ID = bc.ID
join AERO.vuelos v on bc.VUELO_ID = v.ID
join AERO.rutas r on v.RUTA_ID=r.ID
join AERO.aeropuertos a on r.DESTINO_ID=a.ID
where p.CANCELACION_ID IS NOT NULL AND
bc.FECHA_COMPRA between convert(datetime, @fechaFrom,109) and convert(datetime, @fechaTo,109)
group by a.NOMBRE 
order by 2 desc
END
GO

--TOP 5 de los destino con aeronaves mas vacias
CREATE PROCEDURE AERO.top5DestinosAeronavesVacias(@fechaFrom varchar(50), @fechaTo varchar(50))
AS BEGIN
select a.NOMBRE as Destino, count(buV.VUELO_ID) as 'Butacas Vacias' 
from AERO.butacas_por_vuelo buV 
--join AERO.butacas b on naves.ID = b.Aeronave_id 
join AERO.vuelos v on buV.VUELO_ID=v.ID 
join AERO.rutas r on v.RUTA_ID=r.ID 
join AERO.aeropuertos a on r.DESTINO_ID=a.ID 
where buV.ESTADO = 'LIBRE' and
v.FECHA_SALIDA between convert(datetime, @fechaFrom,109) and convert(datetime, @fechaTo,109) and
v.FECHA_LLEGADA between convert(datetime, @fechaFrom,109) and convert(datetime, @fechaTo,109)
group by a.NOMBRE
order by 2 desc
END
GO

--TOP de los clientes con mas puntos acumulados a la fecha (la fecha es hasta el dia de hoy)
CREATE PROCEDURE AERO.top5ClientesMillas(@fechaFrom varchar(50), @fechaTo varchar(50))
AS BEGIN
/*creo tabla temporal, para poder insertar de ambas queries*/
create table #tablaMillas(
Cliente varchar(255),
Millas int
)

/*inserto en la tabla temporal los pasajes*/
insert into #tablaMillas 
select c.NOMBRE+' '+c.APELLIDO, sum(bc.millas)
from AERO.clientes c
join AERO.pasajes p on c.ID=p.CLIENTE_ID 
join AERO.boletos_de_compra bc on p.BOLETO_COMPRA_ID=bc.ID 
where P.CANCELACION_ID IS NULL AND
bc.FECHA_COMPRA between DATEADD(YYYY, -1, CURRENT_TIMESTAMP) and CURRENT_TIMESTAMP
group by c.nombre, c.APELLIDO

/*inserto en la tabla temporal los paquetes*/
insert into #tablaMillas 
select c.NOMBRE+' '+c.APELLIDO, sum(bc.millas)
from AERO.clientes c  
join AERO.boletos_de_compra bc on bc.CLIENTE_ID=c.ID
join AERO.paquetes p on bc.ID = p.BOLETO_COMPRA_ID
where P.CANCELACION_ID IS NULL AND
bc.FECHA_COMPRA between DATEADD(YYYY, -1, CURRENT_TIMESTAMP) and CURRENT_TIMESTAMP
group by c.nombre, c.APELLIDO

select * from #tablaMillas
order by 2 desc

drop table #tablaMillas
END
GO

CREATE PROCEDURE AERO.top5AeronavesFueraDeServicio(@fechaFrom varchar(50), @fechaTo varchar(50))
AS BEGIN
select top 5 a.matricula as 'Nombre Aeronave', sum(DATEDIFF(day,pi.desde,pi.hasta)) as 'Cantidad de días fuera de servicio'
from AERO.aeronaves_por_periodos ap
join Aero.periodos_de_inactividad pi on ap.periodo_id=pi.id
join AERO.aeronaves a on ap.aeronave_id= a.id
where pi.desde between convert(datetime, @fechaFrom,109) and convert(datetime, @fechaTo,109) AND
pi.hasta between convert(datetime, @fechaFrom,109) and convert(datetime, @fechaTo,109) 
group by a.matricula
order by 2 desc 
END
GO

-- VUELOS
CREATE PROCEDURE AERO.generarViaje(@fechaSalida varchar(255), @fechaLlegadaEstimada varchar(255), @idAeronave int, @idRuta int)
AS BEGIN
INSERT INTO AERO.vuelos (FECHA_SALIDA, FECHA_LLEGADA_ESTIMADA, AERONAVE_ID, RUTA_ID)
VALUES (convert(datetime, @fechaSalida,109), convert(datetime, @fechaLlegadaEstimada, 109), @idAeronave, @idRuta)
END
GO

CREATE PROCEDURE AERO.registrarLlegada(@idVuelo int, @fechaLlegada varchar(50))
AS BEGIN
UPDATE AERO.vuelos
SET FECHA_LLEGADA = convert(datetime, @fechaLlegada,109)
WHERE ID = @idVuelo
END
GO

CREATE PROCEDURE AERO.validarVuelo (@id int, @fechaSalida varchar(50), @fechaLlegadaEstimada varchar(50))
AS BEGIN
select COUNT(v.ID) from AERO.vuelos v
where v.AERONAVE_ID = @id and (v.FECHA_SALIDA between convert(datetime, @fechaSalida,109) and convert(datetime, @fechaLlegadaEstimada,109)
or v.FECHA_LLEGADA between convert(datetime, @fechaSalida,109) and convert(datetime, @fechaLlegadaEstimada,109)
or v.FECHA_LLEGADA_ESTIMADA between convert(datetime, @fechaSalida,109) and convert(datetime, @fechaLlegadaEstimada,109))
END
GO

-- BUTACAS POR VUELO
CREATE PROCEDURE AERO.migracionButacasPorVuelo
AS BEGIN
declare @cantAeronaves int
select @cantAeronaves = count(ID) from aero.aeronaves
declare @j int
set @j = 1
	while(@j != @cantAeronaves+1)
	begin
	declare @cantButacas int
	SELECT @cantButacas = a.CANT_BUTACAS from AERO.aeronaves a where a.ID = @j
	declare @i int
	set @i = 1
		WHILE(@i != @cantButacas+1)
		begin
			IF((SELECT count(b.ID) FROM AERO.butacas b, AERO.vuelos v
			where v.INVALIDO = 0 and b.AERONAVE_ID = @j and v.AERONAVE_ID = @j and b.NUMERO = @i) = 0)
				begin
				INSERT INTO AERO.butacas_por_vuelo(BUTACA_ID, VUELO_ID, ESTADO)
				SELECT b.ID, v.ID,'LIBRE' FROM AERO.butacas b, AERO.vuelos v
				where v.INVALIDO = 0 and b.AERONAVE_ID = @j and v.AERONAVE_ID = @j and b.NUMERO = @i
				end
			else
				begin
				INSERT INTO AERO.butacas_por_vuelo(BUTACA_ID, VUELO_ID, ESTADO)
				SELECT b.ID, v.ID,'COMPRADO' FROM AERO.butacas b, AERO.vuelos v
				where v.INVALIDO = 0 and b.AERONAVE_ID = @j and v.AERONAVE_ID = @j and b.NUMERO = @i
				end
		set @i = @i+1
		end
	set @j = @j+1
	end
END
GO

-- MILLAS
CREATE PROCEDURE AERO.consultarMillas (@dni numeric(18,0))
AS BEGIN

/*creo tabla temporal, para poder insertar de ambas queries*/
create table #tablaMillas(
Fecha datetime,
Motivo varchar(255),
Millas int
)

/*inserto en la tabla temporal los pasajes*/
insert into #tablaMillas 
select bc.FECHA_COMPRA as Fecha, 'Pasaje' as Motivo, bc.millas as Millas
from AERO.clientes c
join AERO.pasajes p on c.ID=p.CLIENTE_ID 
join AERO.boletos_de_compra bc on p.BOLETO_COMPRA_ID=bc.ID 
where bc.ID NOT IN (select BOLETO_COMPRA_ID from AERO.cancelaciones) and
bc.FECHA_COMPRA between DATEADD(YYYY, -1, CURRENT_TIMESTAMP) and CURRENT_TIMESTAMP
and c.DNI = @dni

/*inserto en la tabla temporal los paquetes*/
insert into #tablaMillas 
select bc.FECHA_COMPRA as Fecha, 'Paquete' as Motivo, bc.millas as Millas
from AERO.clientes c  
join AERO.boletos_de_compra bc on bc.CLIENTE_ID=c.ID
join AERO.paquetes p on bc.ID = p.BOLETO_COMPRA_ID
where bc.ID NOT IN (select BOLETO_COMPRA_ID from AERO.cancelaciones) and
bc.FECHA_COMPRA between DATEADD(YYYY, -1, CURRENT_TIMESTAMP) and CURRENT_TIMESTAMP
and c.DNI = @dni

/*inserto en la tabla temporal los canjes*/
insert into #tablaMillas 
select cj.FECHA_CANJE as Fecha, 'Canje por '+CONVERT(varchar(10), cj.CANTIDAD)+' unidades de '+p.NOMBRE as Motivo, 
-p.MILLAS_REQUERIDAS*cj.CANTIDAD as Millas
from AERO.clientes c
join AERO.canjes cj on cj.CLIENTE_ID=c.ID
join AERO.productos p on p.ID = cj.PRODUCTO_ID
where cj.FECHA_CANJE between DATEADD(YYYY, -1, CURRENT_TIMESTAMP) and CURRENT_TIMESTAMP
and c.DNI = @dni

/*hago el select que me va a devolver toda la tabla para el dataGridView*/
select * from #tablaMillas

/*hago drop de la tabla temporal*/
drop table #tablaMillas
END
GO

CREATE PROCEDURE AERO.obtenerClienteConMillas (@dni numeric(18,0))
AS BEGIN
CREATE TABLE #Result (
  FECHA_COMPRA datetime,
  Motivo varchar(255),
  Millas int
)
INSERT INTO #Result EXEC AERO.consultarMillas @dni

SELECT c.ID, c.NOMBRE, c.APELLIDO, c.DNI, c.FECHA_NACIMIENTO, SUM(r.Millas) as Millas
FROM #Result r
join AERO.clientes c on c.DNI = @dni
group by c.ID, c.NOMBRE, c.APELLIDO, c.DNI, c.FECHA_NACIMIENTO
DROP TABLE #Result
END
GO

-- CANJES
CREATE PROCEDURE AERO.altaCanje (@idCliente int, @idProducto int, @cantidad int)
AS BEGIN
INSERT INTO AERO.canjes (CLIENTE_ID, PRODUCTO_ID, CANTIDAD, FECHA_CANJE)
VALUES (@idCliente, @idProducto, @cantidad, CURRENT_TIMESTAMP)
UPDATE AERO.productos
SET STOCK = STOCK - @cantidad
where ID = @idProducto
END
GO

-- TARJETAS
CREATE PROCEDURE AERO.altaTarjeta (@idCliente int, @nroTarjeta numeric(18,0), @idTipo int, @fechaVto varchar(255))
AS BEGIN
INSERT INTO AERO.tarjetas_de_credito (CLIENTE_ID, NUMERO, TIPO_TARJETA_ID, FECHA_VTO)
VALUES (@idCliente, @nroTarjeta, @idTipo, convert(datetime, @fechaVto,109))
END
GO

-- CIUDADES
/* NO TENEMOS QUE HACER DELETE, TENDRIAMOS QUE HACER UNA BAJA LOGICA (PONERLE UN CAMPO BAJA A RUTAS, AEROPUERTOS Y CIUDADES)
PORQUE SINO VAMOS A TENER QUE ELIMINAR VUELOS, BOLETOS DE COMPRA (LOS QUE ESTEN ASOCIADOS A ESOS Y VAMOS A ROMPER TODO)

CREATE PROCEDURE AERO.bajaCiudad (@idCiudad int)
AS BEGIN
UPDATE AERO.vuelos
SET INVALIDO = 1
WHERE RUTA_ID IN (SELECT ID FROM AERO.rutas WHERE ORIGEN_ID IN(SELECT ID FROM AERO.aeropuertos WHERE CIUDAD_ID = @idCiudad) 
OR DESTINO_ID IN(SELECT ID FROM AERO.aeropuertos WHERE CIUDAD_ID = @idCiudad))
DELETE AERO.rutas
WHERE ORIGEN_ID IN(SELECT ID FROM AERO.aeropuertos WHERE CIUDAD_ID = @idCiudad) 
OR DESTINO_ID IN(SELECT ID FROM AERO.aeropuertos WHERE CIUDAD_ID = @idCiudad)
DELETE AERO.aeropuertos
WHERE CIUDAD_ID = @idCiudad
DELETE AERO.ciudades
WHERE ID = @idCiudad
END
GO*/

-----------------------------------------------------------------------
-- TRIGGERS

IF OBJECT_ID('AERO.insertVuelos') IS NOT NULL
BEGIN
   DROP TRIGGER AERO.insertVuelos;
END;
GO    

CREATE TRIGGER AERO.insertVuelos on AERO.vuelos
AFTER INSERT
as begin transaction
update AERO.vuelos
set INVALIDO= 1
where ID in (select i.ID from AERO.vuelos v, inserted i
where v.id != i.id and v.AERONAVE_ID = i.AERONAVE_ID and (i.FECHA_SALIDA between v.FECHA_SALIDA and v.FECHA_LLEGADA_ESTIMADA
or i.FECHA_LLEGADA between v.FECHA_SALIDA and v.FECHA_LLEGADA_ESTIMADA 
or i.FECHA_LLEGADA_ESTIMADA between v.FECHA_SALIDA and v.FECHA_LLEGADA_ESTIMADA))
commit
GO

-----------------------------------------------------------------------
-- MIGRACION

INSERT INTO AERO.fabricantes (NOMBRE)
SELECT DISTINCT Aeronave_Fabricante
FROM gd_esquema.Maestra
WHERE Aeronave_Fabricante IS NOT NULL

INSERT INTO AERO.tipos_de_servicio (NOMBRE)
SELECT DISTINCT Tipo_Servicio
FROM gd_esquema.Maestra
WHERE Tipo_Servicio IS NOT NULL

INSERT INTO AERO.ciudades (NOMBRE)
(SELECT DISTINCT Ruta_Ciudad_Origen
FROM gd_esquema.Maestra
WHERE Ruta_Ciudad_Origen IS NOT NULL
UNION
SELECT DISTINCT Ruta_Ciudad_Destino
FROM gd_esquema.Maestra
WHERE Ruta_Ciudad_Destino IS NOT NULL)

INSERT INTO AERO.aeropuertos (CIUDAD_ID, NOMBRE)
(SELECT ID, NOMBRE
FROM AERO.ciudades)

INSERT INTO AERO.clientes (DNI, NOMBRE, APELLIDO, FECHA_NACIMIENTO, MAIL, TELEFONO, DIRECCION, ROL_ID)
select m.Cli_Dni, SUBSTRING(UPPER (m.Cli_Nombre), 1, 1) + SUBSTRING (LOWER (m.Cli_Nombre), 2,LEN(m.Cli_Nombre)), 
SUBSTRING(UPPER (m.Cli_Apellido), 1, 1) + SUBSTRING (LOWER (m.Cli_Apellido), 2,LEN(m.Cli_Apellido)), m.Cli_Fecha_Nac, 
AERO.corrigeMail(m.Cli_Mail), m.Cli_Telefono, m.Cli_Dir, r.ID
from GD2C2015.gd_esquema.Maestra m, AERO.roles r
where r.NOMBRE = 'cliente'
group by m.Cli_Dni, m.Cli_Nombre, m.Cli_Apellido, m.Cli_Fecha_Nac, m.Cli_Mail, m.Cli_Telefono, m.Cli_Dir, r.ID;

/*la fecha de creacion es CURRENT TIMESTAMP ya que las fechas de salida de las aeronaves son en 2016*/
INSERT INTO AERO.aeronaves (MATRICULA, MODELO, KG_DISPONIBLES, FABRICANTE_ID, TIPO_SERVICIO_ID, FECHA_ALTA, CANT_BUTACAS)
SELECT m.Aeronave_Matricula, m.Aeronave_Modelo, m.Aeronave_KG_Disponibles, f.ID, ts.ID, CURRENT_TIMESTAMP, m.Butaca_Nro
FROM GD2C2015.gd_esquema.Maestra m, AERO.fabricantes f, AERO.tipos_de_servicio ts
where f.NOMBRE = m.Aeronave_Fabricante and ts.NOMBRE = m.Tipo_Servicio 
/*QUERY PARA SABER CUAL ES EL MAYOR NUMERO DE BUTACA DE LAS AERONAVES, POR SI ES QUE SE USA ESE NUMERO PARA LA CANT_BUTACAS*/
and m.Butaca_Nro = (select max(Butaca_Nro) from [GD2C2015].[gd_esquema].[Maestra] j where m.Aeronave_Matricula = j.Aeronave_Matricula)
group by m.Aeronave_Matricula, m.Aeronave_Modelo, m.Aeronave_KG_Disponibles, f.ID, ts.ID, m.Butaca_Nro

INSERT INTO AERO.butacas (NUMERO, TIPO, PISO, AERONAVE_ID)
SELECT M.Butaca_Nro, M.Butaca_Tipo, M.Butaca_Piso, A.ID
FROM AERO.aeronaves A, GD2C2015.gd_esquema.Maestra M
WHERE A.MATRICULA = M.Aeronave_Matricula AND M.Butaca_Nro != 0
GROUP BY M.Butaca_Nro, M.Butaca_Tipo, M.Butaca_Piso, A.ID

/*Creo tabla temporal para las rutas, con esa tabla despues es mas facil unificar las filas que pertenezcan a la MISMA ruta (todo igual
excepto que en una fila el kg base esta en 0 y en la otra el pasaje base esta en 0) porque en vez de recorrer 400000 filas recorre
solamente 136, por lo que nos deja un total de 68 rutas diferentes (si tienen el mismo codigo de ruta pero distinto origen o destino o 
tipo de servicio son distintas rutas)*/
SELECT DISTINCT [Ruta_Codigo], [Ruta_Precio_BaseKG], [Ruta_Precio_BasePasaje], [Ruta_Ciudad_Origen], [Ruta_Ciudad_Destino], [Tipo_Servicio]
INTO #rutas_temporales
FROM [GD2C2015].[gd_esquema].[Maestra]

INSERT INTO AERO.rutas (CODIGO, PRECIO_BASE_KG, PRECIO_BASE_PASAJE, ORIGEN_ID, DESTINO_ID, TIPO_SERVICIO_ID)
SELECT r.Ruta_Codigo, r.Ruta_Precio_BaseKG, r2.Ruta_Precio_BasePasaje, o.ID, d.ID, ts.ID
FROM #rutas_temporales r, #rutas_temporales r2, AERO.aeropuertos o, AERO.aeropuertos d, AERO.tipos_de_servicio ts
WHERE d.NOMBRE = r.Ruta_Ciudad_Destino AND o.NOMBRE = r.Ruta_Ciudad_Origen AND ts.NOMBRE = r.Tipo_Servicio
AND r.Ruta_Precio_BasePasaje = 0 AND r2.Ruta_Precio_BaseKG = 0 AND r.Ruta_Codigo = r2.Ruta_Codigo
AND r.Ruta_Ciudad_Destino = r2.Ruta_Ciudad_Destino AND r.Ruta_Ciudad_Origen = r2.Ruta_Ciudad_Origen
AND r.Tipo_Servicio = r2.Tipo_Servicio

/*elimino la tabla temporal*/
DROP TABLE #rutas_temporales

INSERT INTO AERO.vuelos (FECHA_SALIDA, FECHA_LLEGADA_ESTIMADA, FECHA_LLEGADA, AERONAVE_ID, RUTA_ID)
SELECT m.[FechaSalida], m.[Fecha_LLegada_Estimada], m.[FechaLLegada], a.ID, r.ID
FROM [GD2C2015].[gd_esquema].[Maestra] m, AERO.aeronaves a, AERO.rutas r, AERO.aeropuertos p1, AERO.aeropuertos p2
WHERE m.[Ruta_Codigo] = r.CODIGO AND m.[Ruta_Ciudad_Origen] = p1.NOMBRE AND p1.ID = r.ORIGEN_ID AND m.[Ruta_Ciudad_Destino] = p2.NOMBRE 
AND p2.ID = r.DESTINO_ID AND a.MATRICULA = m.[Aeronave_Matricula]
GROUP BY m.[FechaSalida], m.[Fecha_LLegada_Estimada], m.[FechaLLegada], a.ID, r.ID

/*ejecucion de procedure que migra la tabla de butacas por vuelo*/
EXEC AERO.migracionButacasPorVuelo


/*CUANDO MIGREMOS LOS PASAJES, PAQUETES Y BOLETOS DE COMPRA HABRIA QUE HACER TODO JUNTO, LAS MILLAS DEL BOLETO DE COMPRA
SE CALCULA COMO PRECIO TOTAL / 10 (PONEMOS SOLO LA PARTE ENTERA) Y EL PRECIO TOTAL COMO LA SUMATORIA DE LOS PRECIOS PARCIALES
DE LOS PASAJES Y PAQUETES ADQUIRIDOS, LOS PRECIOS PARCIALES TENEMOS QUE CALCULARLOS ASI: TENEMOS EL VUELO_ID EN EL BOLETO DE COMPRA, 
CON ESE ID LE PEGAMOS AL VUELO QUE TIENE UNA RUTA_ID, ESA RUTA TIENE UN PRECIO BASE PASAJE (QUE ES EL PRECIO QUE LE PONEMOS A CADA PASAJE)
Y UN PRECIO BASE KG QUE LO MULTIPLICAMOS POR LOS KG DEL PAQUETE*/

/* MIGRACION DE BOLETO DE COMPRA, PASAJES y PAQUETES

FALTARIA UPDATE DE MILLAS Y PRECIO DE COMPRA PARA EL BOLETO DE COMPRA Y UNIFICAR FILAS QUE TENGAN MISMO CLIENTE, MISMO VUELO Y MISMA FECHA

INSERT INTO AERO.boletos_de_compra (CLIENTE_ID, FECHA_COMPRA, MILLAS, PRECIO_COMPRA, TIPO_COMPRA, VUELO_ID)

SELECT C.ID, CASE WHEN Paquete_FechaCompra != 0 THEN Paquete_FechaCompra ELSE Pasaje_FechaCompra END AS FechaCompra, NULL as Millas, 0 as Precio, 'EFECTIVO', v.ID
FROM GD2C2015.gd_esquema.Maestra M
join AERO.clientes C on C.APELLIDO = SUBSTRING(UPPER (m.Cli_Apellido), 1, 1) + SUBSTRING (LOWER (m.Cli_Apellido), 2,LEN(m.Cli_Apellido))
and C.NOMBRE = SUBSTRING(UPPER (m.Cli_Nombre), 1, 1) + SUBSTRING (LOWER (m.Cli_Nombre), 2,LEN(m.Cli_Nombre))
and C.DNI = M.Cli_Dni
join AERO.aeronaves a on m.Aeronave_Matricula = a.MATRICULA
join AERO.vuelos v on v.AERONAVE_ID = a.ID and v.RUTA_ID = (SELECT r.id from AERO.rutas r 
join AERO.aeropuertos p1 on m.[Ruta_Ciudad_Origen] = p1.NOMBRE AND p1.ID = r.ORIGEN_ID
join AERO.aeropuertos p2 on m.[Ruta_Ciudad_Destino] = p2.NOMBRE AND p2.ID = r.DESTINO_ID
where m.[Ruta_Codigo] = r.CODIGO and m.FechaSalida = v.FECHA_SALIDA and m.Fecha_LLegada_Estimada = v.FECHA_LLEGADA_ESTIMADA and
m.FechaLLegada = v.FECHA_LLEGADA)


INSERT INTO AERO.pasajes (CODIGO, CLIENTE_ID, BUTACA_ID, CANCELACION_ID, BOLETO_COMPRA_ID, PRECIO)
SELECT M.Pasaje_Codigo, C.ID, B.ID, NULL, bc.ID, M.Pasaje_Precio FROM GD2C2015.gd_esquema.Maestra M
join AERO.clientes C on C.APELLIDO = SUBSTRING(UPPER (m.Cli_Apellido), 1, 1) + SUBSTRING (LOWER (m.Cli_Apellido), 2,LEN(m.Cli_Apellido))
and C.NOMBRE = SUBSTRING(UPPER (m.Cli_Nombre), 1, 1) + SUBSTRING (LOWER (m.Cli_Nombre), 2,LEN(m.Cli_Nombre))
and C.DNI = M.Cli_Dni
join AERO.aeronaves A on M.Aeronave_Matricula = A.MATRICULA
join AERO.butacas B on B.NUMERO = M.Butaca_Nro and A.ID = B.AERONAVE_ID
join AERO.boletos_de_compra bc on m.Pasaje_FechaCompra = bc.FECHA_COMPRA and bc.CLIENTE_ID = c.ID
where M.Pasaje_Codigo != 0

INSERT INTO AERO.paquetes (CODIGO, KG, BOLETO_COMPRA_ID, CANCELACION_ID, PRECIO)
SELECT M.Paquete_Codigo, M.Paquete_KG, bc.ID, NULL, M.Paquete_Precio FROM GD2C2015.gd_esquema.Maestra M
join AERO.boletos_de_compra bc on m.Paquete_FechaCompra = bc.FECHA_COMPRA and bc.CLIENTE_ID = c.ID
where M.Paquete_Codigo != 0*/

-----------------------------------------------------------------------
-- EJECUCION DE PROCEDURES

EXEC AERO.addFuncionalidad @rol='administrador', @func ='Consultar Millas';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Alta de Cliente';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Alta de Aeronave';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Alta de Tarjeta de Crédito';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Baja de Aeronave';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Baja de Ciudad';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Baja de Cliente';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Modificacion de Aeronave';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Modificacion de Cliente';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Realizar Canje';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Alta de Rol';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Baja de Rol';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Modificacion de Rol';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Alta de Ruta';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Baja de Ruta';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Modificacion de Ruta';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Comprar Pasaje/Encomienda';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Generar Viaje';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Registrar Llegadas';
EXEC AERO.addFuncionalidad @rol='administrador', @func ='Consultar Listado';
EXEC AERO.addFuncionalidad @rol='cliente', @func ='Comprar Pasaje/Encomienda';
EXEC AERO.addFuncionalidad @rol='cliente', @func ='Consultar Millas';
EXEC AERO.addFuncionalidad @rol='cliente', @func ='Realizar Canje';
EXEC AERO.addFuncionalidad @rol='cliente', @func ='Alta de Tarjeta de Crédito';

-----------------------------------------------------------------------
--PRUEBAS DE LISTADOS ESTADISTICOS 
/*
--set de datos para prueba 1
insert into AERO.clientes values(2,'pepe','asd','37013085','asd','123','asd@gmail.com',CONVERT(datetime,'20151215',109),0)
--select * from AERO.clientes

insert into AERO.tipos_de_servicio values('asd')
--select * from AERO.tipos_de_servicio

insert into AERO.fabricantes values('luisito')
--select * from AERO.fabricantes

insert into AERO.aeronaves values('123','asd',123,1,1,NULL,CURRENT_TIMESTAMP,99,NULL)
insert into AERO.aeronaves values('999','asd',999,1,1,NULL,CURRENT_TIMESTAMP,99,NULL)
--select * from AERO.aeronaves

insert into AERO.ciudades values('ciudad1')
insert into AERO.ciudades values('ciudad2')
--select * from AERO.ciudades

insert into AERO.aeropuertos values('aerp1',1)
insert into AERO.aeropuertos values('aerp2',2)
--select * from AERO.aeropuertos

insert into AERO.rutas values(1,100,100,1,2,1,0)
insert into AERO.rutas values(2,100,100,2,1,1,0)
--select * from AERO.rutas

insert into AERO.vuelos values(CURRENT_TIMESTAMP,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP,1,1,0)
insert into AERO.vuelos values(dateadd(MM,1,CURRENT_TIMESTAMP),dateadd(MM,1,CURRENT_TIMESTAMP),CURRENT_TIMESTAMP,2,2,0)
--select * from AERO.vuelos

insert into AERO.boletos_de_compra values(1,CURRENT_TIMESTAMP,300,'efectivo',1,22,1)
insert into AERO.boletos_de_compra values(2,CURRENT_TIMESTAMP,30,'efectivo',1,22,1)
insert into AERO.boletos_de_compra values(3,DATEADD(YYYY,-4,CURRENT_TIMESTAMP),40,'efectivo',1,22,2)
--select * from AERO.boletos_de_compra

insert into AERO.butacas values(1,'PASILLO',1,1)
insert into AERO.butacas values(2,'PASILLO',1,1)
insert into AERO.butacas values(3,'PASILLO',1,1)
insert into AERO.butacas values(1,'PASILLO',1,2)
--select * from AERO.butacas

insert into AERO.butacas_por_vuelo values(1,1,'COMPRADO')
insert into AERO.butacas_por_vuelo values(1,2,'COMPRADO')
insert into AERO.butacas_por_vuelo values(1,3,'COMPRADO')
insert into AERO.butacas_por_vuelo values(2,1,'COMPRADO')
--select * from AERO.butacas_por_vuelo

insert into AERO.pasajes values(100,1,1,1,100000,NULL)
insert into AERO.pasajes values(200,2,2,1,100000,NULL)
insert into AERO.pasajes values(30,3,3,1,100001,NULL)
insert into AERO.pasajes values(40,4,4,1,100002,NULL)
--select * from AERO.pasajes
GO

exec AERO.top5DestinosConPasajes @fechaFrom='20000201', @fechaTo='29990201'
GO

--SET PARA PROBAR 2((AGREGADO A LOS ANTERIORES)
insert into AERO.butacas values(4,'PASILLO',1,1)
insert into AERO.butacas values(5,'PASILLO',1,1)
insert into AERO.butacas values(6,'PASILLO',1,1)
insert into AERO.butacas values(2,'PASILLO',1,2)
--select * from AERO.butacas

insert into AERO.butacas_por_vuelo values(1,4,'LIBRE')
insert into AERO.butacas_por_vuelo values(1,5,'LIBRE')
insert into AERO.butacas_por_vuelo values(2,2,'LIBRE')
insert into AERO.butacas_por_vuelo values(2,3,'LIBRE')
--SELECT * FROM AERO.butacas_por_vuelo
GO

exec AERO.top5DestinosAeronavesVacias @fechaFrom='20000201', @fechaTo='29990201'
GO

--MILLAS CLIENTES
exec AERO.top5ClientesMillas @fechaFrom='20000201', @fechaTo='29990201'
GO

--SET PARA PROBAR 4(AGREGADO A LOS ANTERIORES)
insert into AERO.cancelaciones values(CURRENT_TIMESTAMP,100000,'asd')
insert into AERO.cancelaciones values(CURRENT_TIMESTAMP,100002,'asd')
--select * from AERO.cancelaciones

update AERO.pasajes set CANCELACION_ID=1 where ID=1
update AERO.pasajes set CANCELACION_ID=1 where ID=2
update AERO.pasajes set CANCELACION_ID=2 where ID=4
--select * from AERO.pasajes
GO

exec AERO.top5DestinosCancelados @fechaFrom='20000201', @fechaTo='29990201'
GO

insert into AERO.periodos_de_inactividad values('20150101','20150530')
insert into AERO.periodos_de_inactividad values('20150120','20151230')
insert into AERO.periodos_de_inactividad values('20150101','20150110')
insert into AERO.periodos_de_inactividad values('20150201','20150210')
--SELECT * FROM AERO.periodos_de_inactividad

insert into AERO.aeronaves_por_periodos values(1,1)
insert into AERO.aeronaves_por_periodos values(1,2)
insert into AERO.aeronaves_por_periodos values(2,3)
insert into AERO.aeronaves_por_periodos values(2,4)
--SELECT * FROM AERO.aeronaves_por_periodos
GO

EXEC AERO.top5AeronavesFueraDeServicio @fechaFrom='20150101', @fechaTo ='20150601';
GO
*/
