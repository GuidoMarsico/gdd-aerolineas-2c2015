-----------------------------------------------------------------------
-- MASTER TABLE
USE GD2C2015;

-----------------------------------------------------------------------
-- SCHEMA

IF NOT EXISTS (
    SELECT schema_name 
    FROM information_schema.schemata 
    WHERE schema_name = 'DIVIDIDOS' 
    )

BEGIN
    EXEC sp_executesql N'CREATE SCHEMA DIVIDIDOS;';
END

-----------------------------------------------------------------------
-- DROP TABLES
IF OBJECT_ID('DIVIDIDOS.butacas_por_vuelo') IS NOT NULL
BEGIN
    DROP TABLE DIVIDIDOS.butacas_por_vuelo;
END;

IF OBJECT_ID('DIVIDIDOS.roles_por_usuario') IS NOT NULL
BEGIN
    DROP TABLE DIVIDIDOS.roles_por_usuario;
END;

IF OBJECT_ID('DIVIDIDOS.canjes') IS NOT NULL
BEGIN
    DROP TABLE DIVIDIDOS.canjes;
END;

IF OBJECT_ID('DIVIDIDOS.productos') IS NOT NULL
BEGIN
    DROP TABLE DIVIDIDOS.productos;
END;

IF OBJECT_ID('DIVIDIDOS.aeronaves_por_periodos') IS NOT NULL
BEGIN
    DROP TABLE DIVIDIDOS.aeronaves_por_periodos;
END;

IF OBJECT_ID('DIVIDIDOS.periodos_de_inactividad') IS NOT NULL
BEGIN
    DROP TABLE DIVIDIDOS.periodos_de_inactividad;
END;

IF OBJECT_ID('DIVIDIDOS.funcionalidades_por_rol') IS NOT NULL
BEGIN
    DROP TABLE DIVIDIDOS.funcionalidades_por_rol;
END;

IF OBJECT_ID('DIVIDIDOS.funcionalidades') IS NOT NULL
BEGIN
    DROP TABLE DIVIDIDOS.funcionalidades;
END;

IF OBJECT_ID('DIVIDIDOS.usuarios') IS NOT NULL
BEGIN
    DROP TABLE DIVIDIDOS.usuarios;
END;

IF OBJECT_ID('DIVIDIDOS.tarjetas_de_credito') IS NOT NULL
BEGIN
    DROP TABLE DIVIDIDOS.tarjetas_de_credito;
END;

IF OBJECT_ID('DIVIDIDOS.tipos_tarjeta') IS NOT NULL
BEGIN
    DROP TABLE DIVIDIDOS.tipos_tarjeta;
END;

IF OBJECT_ID('DIVIDIDOS.paquetes') IS NOT NULL
BEGIN
    DROP TABLE DIVIDIDOS.paquetes;
END;

IF OBJECT_ID('DIVIDIDOS.pasajes') IS NOT NULL
BEGIN
    DROP TABLE DIVIDIDOS.pasajes;
END;

IF OBJECT_ID('DIVIDIDOS.cancelaciones') IS NOT NULL
BEGIN
    DROP TABLE DIVIDIDOS.cancelaciones;
END;

IF OBJECT_ID('DIVIDIDOS.boletos_de_compra') IS NOT NULL
BEGIN
    DROP TABLE DIVIDIDOS.boletos_de_compra;
END;

IF OBJECT_ID('DIVIDIDOS.vuelos') IS NOT NULL
BEGIN
    DROP TABLE DIVIDIDOS.vuelos;
END;

IF OBJECT_ID('DIVIDIDOS.rutas') IS NOT NULL
BEGIN
    DROP TABLE DIVIDIDOS.rutas;
END;

IF OBJECT_ID('DIVIDIDOS.aeropuertos') IS NOT NULL
BEGIN
    DROP TABLE DIVIDIDOS.aeropuertos;
END;

IF OBJECT_ID('DIVIDIDOS.ciudades') IS NOT NULL
BEGIN
    DROP TABLE DIVIDIDOS.ciudades;
END;

IF OBJECT_ID('DIVIDIDOS.butacas') IS NOT NULL
BEGIN
    DROP TABLE DIVIDIDOS.butacas;
END;

IF OBJECT_ID('DIVIDIDOS.aeronaves') IS NOT NULL
BEGIN
    DROP TABLE DIVIDIDOS.aeronaves;
END;

IF OBJECT_ID('DIVIDIDOS.tipos_de_servicio') IS NOT NULL
BEGIN
    DROP TABLE DIVIDIDOS.tipos_de_servicio;
END;

IF OBJECT_ID('DIVIDIDOS.fabricantes') IS NOT NULL
BEGIN
    DROP TABLE DIVIDIDOS.fabricantes;
END;

IF OBJECT_ID('DIVIDIDOS.clientes') IS NOT NULL
BEGIN
    DROP TABLE DIVIDIDOS.clientes;
END;

IF OBJECT_ID('DIVIDIDOS.roles') IS NOT NULL
BEGIN
    DROP TABLE DIVIDIDOS.roles;
END;

-----------------------------------------------------------------------
-- TABLES

CREATE TABLE DIVIDIDOS.aeronaves (
    ID  INT   IDENTITY(1,1)    PRIMARY KEY,
    MATRICULA        NVARCHAR(255)    UNIQUE NOT NULL,
    MODELO        NVARCHAR(255) DEFAULT 'MODELO',
    KG_DISPONIBLES    NUMERIC(18,0)    NOT NULL,
    FABRICANTE_ID    INT            NOT NULL,
    TIPO_SERVICIO_ID    INT            NOT NULL,
    BAJA            NVARCHAR(255),
    FECHA_ALTA      DATETIME        NOT NULL,
    CANT_BUTACAS    INT            NOT NULL,
    FECHA_BAJA    DATETIME,
    CONSTRAINT aeronaves_CK001 CHECK (BAJA IN ('DEFINITIVA', 'POR_PERIODO'))
)

CREATE TABLE DIVIDIDOS.fabricantes (
    ID  INT  IDENTITY(1,1)    PRIMARY KEY,
    NOMBRE        NVARCHAR(255)    NOT NULL
)

CREATE TABLE DIVIDIDOS.tipos_de_servicio (
    ID INT   IDENTITY(1,1)    PRIMARY KEY,
    NOMBRE        NVARCHAR(255)    NOT NULL,
	PORCENTAJE NUMERIC(3,2) 
)

CREATE TABLE DIVIDIDOS.butacas (
    ID  INT     IDENTITY(1,1)    PRIMARY KEY,
    NUMERO        NUMERIC(18,0)    NOT NULL,
    TIPO            NVARCHAR(255),
    PISO            NUMERIC(18,0),
    AERONAVE_ID    INT            NOT NULL,
    CONSTRAINT butacas_CK001 CHECK (TIPO IN ('VENTANILLA', 'PASILLO')),
	CONSTRAINT butacas_CK002 CHECK (PISO IN (1,2))
)

CREATE TABLE DIVIDIDOS.butacas_por_vuelo (
VUELO_ID INT NOT NULL,
BUTACA_ID INT NOT NULL,
ESTADO        NVARCHAR(255) DEFAULT 'LIBRE',
CONSTRAINT butacas_por_vuelo_CK001 CHECK (ESTADO IN ('LIBRE', 'COMPRADO')),
PRIMARY KEY(VUELO_ID,BUTACA_ID)
)

CREATE TABLE DIVIDIDOS.pasajes (
    ID    INT    IDENTITY(1,1)    PRIMARY KEY,
    PRECIO        NUMERIC(18,2)		NOT NULL,
    CODIGO        NUMERIC(18,0)     UNIQUE NOT NULL,
    BUTACA_ID        INT            NOT NULL,
    CLIENTE_ID        INT            NOT NULL,
    BOLETO_COMPRA_ID INT             NOT NULL,
	INVALIDO INT DEFAULT 0,
    CANCELACION_ID INT DEFAULT NULL
)

CREATE TABLE DIVIDIDOS.clientes (
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

CREATE TABLE DIVIDIDOS.boletos_de_compra (
    ID INT IDENTITY(100000,1)    PRIMARY KEY,
    FECHA_COMPRA    DATETIME          NOT NULL,
    PRECIO_COMPRA    NUMERIC(18,2)	NOT NULL,
    TIPO_COMPRA    NVARCHAR(255),
    CLIENTE_ID        INT            NOT NULL,
	MILLAS 			  INT,
	VUELO_ID         INT		NOT NULL,
	INVALIDO INT DEFAULT 0,
    CONSTRAINT boletos_de_compra_CK001 CHECK (TIPO_COMPRA IN ('EFECTIVO', 'TARJETA'))
)

CREATE TABLE DIVIDIDOS.roles (
    ID    INT    IDENTITY(1,1)    PRIMARY KEY,
	NOMBRE 	NVARCHAR(255)		NOT NULL,
	ACTIVO	INT DEFAULT 1,
	CONSTRAINT roles_CK001 CHECK (ACTIVO IN (0,1))
)

CREATE TABLE DIVIDIDOS.funcionalidades (
    ID INT IDENTITY(1,1)    PRIMARY KEY,
    DETALLES        NVARCHAR(255) NOT NULL
)

CREATE TABLE DIVIDIDOS.funcionalidades_por_rol (
	ROL_ID    INT,
	FUNCIONALIDAD_ID INT, 
	PRIMARY KEY(ROL_ID,FUNCIONALIDAD_ID)
)

CREATE TABLE DIVIDIDOS.usuarios (
    ID INT IDENTITY(1,1)    PRIMARY KEY,
    USERNAME        NVARCHAR(255)    UNIQUE NOT NULL,
    PASSWORD        NVARCHAR(255)		NOT NULL,
	FECHA_CREACION DATETIME				NOT NULL,
	ULTIMA_MODIFICACION DATETIME		NOT NULL,
	INTENTOS_LOGIN INT NOT NULL DEFAULT 0,
	ACTIVO INT,
	CONSTRAINT usuarios_CK001 CHECK (ACTIVO IN (0,1))
)

CREATE TABLE DIVIDIDOS.roles_por_usuario (
	ROL_ID    INT,
	USUARIO_ID INT, 
	PRIMARY KEY(ROL_ID,USUARIO_ID)
)

CREATE TABLE DIVIDIDOS.productos (
    ID  INT  IDENTITY(1,1)    PRIMARY KEY,
    NOMBRE        NVARCHAR(255)    UNIQUE,
    MILLAS_REQUERIDAS INT  NOT NULL,
    STOCK        INT      NOT NULL    
)

CREATE TABLE DIVIDIDOS.periodos_de_inactividad (
    ID    INT     IDENTITY(1,1)    PRIMARY KEY,
    DESDE        DATETIME			NOT NULL,
    HASTA        DATETIME			NOT NULL
)

CREATE TABLE DIVIDIDOS.aeronaves_por_periodos (
    AERONAVE_ID INT,
    PERIODO_ID  INT,
    PRIMARY KEY(AERONAVE_ID,PERIODO_ID)
)

CREATE TABLE DIVIDIDOS.aeropuertos (
    ID  INT    IDENTITY(1,1)    PRIMARY KEY,
    NOMBRE        NVARCHAR(255)     NOT NULL,
    CIUDAD_ID        INT             NOT NULL,
	BAJA			 INT			DEFAULT 0
)

CREATE TABLE DIVIDIDOS.vuelos (
    ID     INT    IDENTITY(1,1)     PRIMARY KEY,
    FECHA_SALIDA     DATETIME		NOT NULL,
    FECHA_LLEGADA     DATETIME,
    FECHA_LLEGADA_ESTIMADA DATETIME NOT NULL,
    AERONAVE_ID     INT            NOT NULL,
    RUTA_ID         INT            NOT NULL,
	INVALIDO		INT			DEFAULT 0
)

CREATE TABLE DIVIDIDOS.rutas (
    ID     INT     IDENTITY(1,1)     PRIMARY KEY,
    CODIGO         NUMERIC(18,0)    NOT NULL,
    PRECIO_BASE_KG     NUMERIC(18,2)  NOT NULL,
    PRECIO_BASE_PASAJE NUMERIC(18,2) NOT NULL,
    ORIGEN_ID        INT            NOT NULL,
    DESTINO_ID        INT            NOT NULL,
	TIPO_SERVICIO_ID	INT	NOT NULL,
	BAJA			INT DEFAULT 0
)

CREATE TABLE DIVIDIDOS.ciudades (
    ID     INT     IDENTITY(1,1)     PRIMARY KEY,
    NOMBRE         NVARCHAR(255)    NOT NULL,
	BAJA		   INT				DEFAULT 0
)

CREATE TABLE DIVIDIDOS.paquetes(
    ID   INT  IDENTITY(1,1)     PRIMARY KEY,
    CODIGO         NUMERIC(18,0)    UNIQUE NOT NULL,
    PRECIO         NUMERIC(18,2)	NOT NULL,
    KG             NUMERIC(18,2)	NOT NULL,
    BOLETO_COMPRA_ID     INT		NOT NULL,
	INVALIDO INT DEFAULT 0,
    CANCELACION_ID INT DEFAULT NULL
)

CREATE TABLE DIVIDIDOS.canjes (
    ID     INT    IDENTITY(1,1)     PRIMARY KEY,
    CLIENTE_ID         INT             NOT NULL,
    PRODUCTO_ID     INT             NOT NULL,
    CANTIDAD         INT			DEFAULT 1,
    FECHA_CANJE         DATETIME	NOT NULL
)

CREATE TABLE DIVIDIDOS.tarjetas_de_credito (
    ID   INT   IDENTITY(1,1)     PRIMARY KEY,
    TIPO_TARJETA_ID    INT NOT NULL,
    NUMERO         NUMERIC(18,0)    UNIQUE NOT NULL,
    FECHA_VTO         DATETIME        NOT NULL,
    CLIENTE_ID         INT            NOT NULL
)

CREATE TABLE DIVIDIDOS.tipos_tarjeta (
    ID   INT   IDENTITY(1,1)     PRIMARY KEY,
    NOMBRE    NVARCHAR(255) NOT NULL,
	CUOTAS INT DEFAULT 0   
)


CREATE TABLE DIVIDIDOS.cancelaciones (
    ID   INT   IDENTITY(1,1)     PRIMARY KEY,
    FECHA_DEVOLUCION DATETIME		NOT NULL,
    BOLETO_COMPRA_ID INT            NOT NULL,
    MOTIVO         NVARCHAR(255)   NOT NULL
)

-----------------------------------------------------------------------
-- FOREIGN KEYS && INDEXES

ALTER TABLE DIVIDIDOS.tarjetas_de_credito
ADD CONSTRAINT TARJETAS_FK01 FOREIGN KEY
(TIPO_TARJETA_ID) REFERENCES DIVIDIDOS.tipos_tarjeta (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'TARJ_TIPO_TARJ' AND object_id = OBJECT_ID('DIVIDIDOS.tarjetas_de_credito'))
    BEGIN
       CREATE INDEX TARJ_TIPO_TARJ ON DIVIDIDOS.tarjetas_de_credito (TIPO_TARJETA_ID);
    END

ALTER TABLE DIVIDIDOS.tarjetas_de_credito
ADD CONSTRAINT TARJETAS_FK02 FOREIGN KEY
(CLIENTE_ID) REFERENCES DIVIDIDOS.clientes (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_TARJ_CLIE' AND object_id = OBJECT_ID('DIVIDIDOS.tarjetas_de_credito'))
    BEGIN
       CREATE INDEX FKI_TARJ_CLIE ON DIVIDIDOS.tarjetas_de_credito (CLIENTE_ID);
    END

ALTER TABLE DIVIDIDOS.aeronaves
ADD CONSTRAINT AERONAVES_FK01 FOREIGN KEY
(FABRICANTE_ID) REFERENCES DIVIDIDOS.fabricantes (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'AERO_FABRIC' AND object_id = OBJECT_ID('DIVIDIDOS.aeronaves'))
    BEGIN
       CREATE INDEX AERO_FABRIC ON DIVIDIDOS.aeronaves (FABRICANTE_ID);
    END

ALTER TABLE DIVIDIDOS.aeronaves
ADD CONSTRAINT AERONAVES_FK02 FOREIGN KEY
(TIPO_SERVICIO_ID) REFERENCES DIVIDIDOS.tipos_de_servicio (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'AERO_TIPO_SERV' AND object_id = OBJECT_ID('DIVIDIDOS.aeronaves'))
    BEGIN
       CREATE INDEX AERO_TIPO_SERV ON DIVIDIDOS.aeronaves (TIPO_SERVICIO_ID);
    END

ALTER TABLE DIVIDIDOS.butacas
ADD CONSTRAINT BUTACAS_FK01 FOREIGN KEY
(AERONAVE_ID) REFERENCES DIVIDIDOS.aeronaves (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'BUTAC_AERO' AND object_id = OBJECT_ID('DIVIDIDOS.butacas'))
    BEGIN
       CREATE INDEX BUTAC_AERO ON DIVIDIDOS.butacas (AERONAVE_ID);
    END

ALTER TABLE DIVIDIDOS.butacas_por_vuelo
ADD CONSTRAINT butacas_por_vu_FK01 FOREIGN KEY
(VUELO_ID) REFERENCES DIVIDIDOS.vuelos (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'BUTAC_VUELO_VUELO' AND object_id = OBJECT_ID('DIVIDIDOS.butacas_por_vuelo'))
    BEGIN
       CREATE INDEX BUTAC_VUELO_VUELO ON DIVIDIDOS.butacas_por_vuelo (VUELO_ID);
    END

ALTER TABLE DIVIDIDOS.butacas_por_vuelo
ADD CONSTRAINT butacas_por_aeronave_FK02 FOREIGN KEY
(BUTACA_ID) REFERENCES DIVIDIDOS.butacas (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'BUTAC_VUELO_BUTACA' AND object_id = OBJECT_ID('DIVIDIDOS.butacas_por_vuelo'))
    BEGIN
       CREATE INDEX BUTAC_VUELO_BUTACA ON DIVIDIDOS.butacas_por_vuelo (BUTACA_ID);
    END

ALTER TABLE DIVIDIDOS.pasajes
ADD CONSTRAINT PASAJES_FK01 FOREIGN KEY
(BUTACA_ID) REFERENCES DIVIDIDOS.butacas (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'PASAJ_BUTAC' AND object_id = OBJECT_ID('DIVIDIDOS.pasajes'))
    BEGIN
       CREATE INDEX PASAJ_BUTAC ON DIVIDIDOS.pasajes (BUTACA_ID);
    END

ALTER TABLE DIVIDIDOS.pasajes
ADD CONSTRAINT PASAJES_FK02 FOREIGN KEY
(CLIENTE_ID) REFERENCES DIVIDIDOS.clientes (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'PASAJ_CLIENT' AND object_id = OBJECT_ID('DIVIDIDOS.pasajes'))
    BEGIN
       CREATE INDEX PASAJ_CLIENT ON DIVIDIDOS.pasajes (CLIENTE_ID);
    END

ALTER TABLE DIVIDIDOS.pasajes
ADD CONSTRAINT PASAJES_FK03 FOREIGN KEY
(BOLETO_COMPRA_ID) REFERENCES DIVIDIDOS.boletos_de_compra (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'PASAJ_BOL_COMP' AND object_id = OBJECT_ID('DIVIDIDOS.pasajes'))
    BEGIN
       CREATE INDEX PASAJ_BOL_COMP ON DIVIDIDOS.pasajes (BOLETO_COMPRA_ID);
    END

ALTER TABLE DIVIDIDOS.pasajes
ADD CONSTRAINT PASAJES_FK04 FOREIGN KEY
(CANCELACION_ID) REFERENCES DIVIDIDOS.cancelaciones (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'PASAJ_CANC' AND object_id = OBJECT_ID('DIVIDIDOS.pasajes'))
    BEGIN
       CREATE INDEX PASAJ_CANC ON DIVIDIDOS.pasajes (CANCELACION_ID);
    END

ALTER TABLE DIVIDIDOS.clientes
ADD CONSTRAINT CLIENTES_FK01 FOREIGN KEY
(ROL_ID) REFERENCES DIVIDIDOS.roles (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'CLIENT_ROLES' AND object_id = OBJECT_ID('DIVIDIDOS.clientes'))
    BEGIN
       CREATE INDEX CLIENT_ROLES ON DIVIDIDOS.clientes (ROL_ID);
    END

ALTER TABLE DIVIDIDOS.boletos_de_compra
ADD CONSTRAINT BOLETOS_DE_COMPRA_FK01 FOREIGN KEY
(CLIENTE_ID) REFERENCES DIVIDIDOS.clientes (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_BOL_COMP_CLIENT' AND object_id = OBJECT_ID('DIVIDIDOS.boletos_de_compra'))
    BEGIN
       CREATE INDEX FKI_BOL_COMP_CLIENT ON DIVIDIDOS.boletos_de_compra (CLIENTE_ID);
    END

ALTER TABLE DIVIDIDOS.boletos_de_compra
ADD CONSTRAINT boletos_FK02 FOREIGN KEY
(VUELO_ID) REFERENCES DIVIDIDOS.vuelos (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_BOLETO_VUEL' AND object_id = OBJECT_ID('DIVIDIDOS.boletos_de_compra'))
    BEGIN
       CREATE INDEX FKI_BOLETO_VUEL ON DIVIDIDOS.boletos_de_compra (VUELO_ID);
    END

ALTER TABLE DIVIDIDOS.funcionalidades_por_rol
ADD CONSTRAINT FUNCIONALIDADES_POR_ROL_FK01 FOREIGN KEY
(ROL_ID) REFERENCES DIVIDIDOS.roles (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_FUNCXROL_ROL' AND object_id = OBJECT_ID('DIVIDIDOS.funcionalidades_por_rol'))
    BEGIN
       CREATE INDEX FKI_FUNCXROL_ROL ON DIVIDIDOS.funcionalidades_por_rol (ROL_ID);
    END

ALTER TABLE DIVIDIDOS.funcionalidades_por_rol
ADD CONSTRAINT FUNCIONALIDADES_POR_ROL_FK02 FOREIGN KEY
(FUNCIONALIDAD_ID) REFERENCES DIVIDIDOS.funcionalidades (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_FUNCXROL_FUNC' AND object_id = OBJECT_ID('DIVIDIDOS.funcionalidades_por_rol'))
    BEGIN
       CREATE INDEX FKI_FUNCXROL_FUNC ON DIVIDIDOS.funcionalidades_por_rol (FUNCIONALIDAD_ID);
    END

ALTER TABLE DIVIDIDOS.aeronaves_por_periodos
ADD CONSTRAINT AERONAVES_POR_PERIODOS_FK01 FOREIGN KEY
(AERONAVE_ID) REFERENCES DIVIDIDOS.aeronaves (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_AEROXPER_AERO' AND object_id = OBJECT_ID('DIVIDIDOS.aeronaves_por_periodos'))
    BEGIN
       CREATE INDEX FKI_AEROXPER_AERO ON DIVIDIDOS.aeronaves_por_periodos (AERONAVE_ID);
    END

ALTER TABLE DIVIDIDOS.aeronaves_por_periodos
ADD CONSTRAINT AERONAVES_POR_PERIODOS_FK02 FOREIGN KEY
(PERIODO_ID) REFERENCES DIVIDIDOS.periodos_de_inactividad (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_AEROXPER_PERXINAC' AND object_id = OBJECT_ID('DIVIDIDOS.aeronaves_por_periodos'))
    BEGIN
       CREATE INDEX FKI_AEROXPER_PERXINAC ON DIVIDIDOS.aeronaves_por_periodos (PERIODO_ID);
    END

ALTER TABLE DIVIDIDOS.aeropuertos
ADD CONSTRAINT AEROPUERTOS_FK01 FOREIGN KEY
(CIUDAD_ID) REFERENCES DIVIDIDOS.ciudades (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_AERO_CIUD' AND object_id = OBJECT_ID('DIVIDIDOS.aeropuertos'))
    BEGIN
       CREATE INDEX FKI_AERO_CIUD ON DIVIDIDOS.aeropuertos (CIUDAD_ID);
    END

ALTER TABLE DIVIDIDOS.vuelos
ADD CONSTRAINT VUELOS_FK01 FOREIGN KEY
(AERONAVE_ID) REFERENCES DIVIDIDOS.aeronaves (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_VUEL_AERO' AND object_id = OBJECT_ID('DIVIDIDOS.vuelos'))
    BEGIN
       CREATE INDEX FKI_VUEL_AERO ON DIVIDIDOS.vuelos (AERONAVE_ID);
    END

ALTER TABLE DIVIDIDOS.vuelos
ADD CONSTRAINT VUELOS_FK02 FOREIGN KEY
(RUTA_ID) REFERENCES DIVIDIDOS.rutas (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_VUEL_RUT' AND object_id = OBJECT_ID('DIVIDIDOS.vuelos'))
    BEGIN
       CREATE INDEX FKI_VUEL_RUT ON DIVIDIDOS.vuelos (RUTA_ID);
    END

ALTER TABLE DIVIDIDOS.rutas
ADD CONSTRAINT rutas_FK01 FOREIGN KEY
(TIPO_SERVICIO_ID) REFERENCES DIVIDIDOS.tipos_de_servicio (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_rutas_tipo_servicio' AND object_id = OBJECT_ID('DIVIDIDOS.rutas'))
    BEGIN
       CREATE INDEX FKI_rutas_tipo_servicio ON DIVIDIDOS.rutas (TIPO_SERVICIO_ID);
    END

ALTER TABLE DIVIDIDOS.rutas
ADD CONSTRAINT RUTAS_FK02 FOREIGN KEY
(ORIGEN_ID) REFERENCES DIVIDIDOS.aeropuertos (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_RUT_AERO' AND object_id = OBJECT_ID('DIVIDIDOS.rutas'))
    BEGIN
       CREATE INDEX FKI_RUT_AERO ON DIVIDIDOS.rutas (ORIGEN_ID);
    END

ALTER TABLE DIVIDIDOS.rutas
ADD CONSTRAINT RUTAS_FK03 FOREIGN KEY
(DESTINO_ID) REFERENCES DIVIDIDOS.aeropuertos (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_RUT_AERO2' AND object_id = OBJECT_ID('DIVIDIDOS.rutas'))
    BEGIN
       CREATE INDEX FKI_RUT_AERO2 ON DIVIDIDOS.rutas (DESTINO_ID);
    END

ALTER TABLE DIVIDIDOS.paquetes
ADD CONSTRAINT paquetes_FK01 FOREIGN KEY
(BOLETO_COMPRA_ID) REFERENCES DIVIDIDOS.boletos_de_compra (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_PAQ_BOLDECOMP' AND object_id = OBJECT_ID('DIVIDIDOS.paquetes'))
    BEGIN
       CREATE INDEX FKI_PAQ_BOLDECOMP ON DIVIDIDOS.paquetes (BOLETO_COMPRA_ID);
    END

ALTER TABLE DIVIDIDOS.paquetes
ADD CONSTRAINT paquetes_FK02 FOREIGN KEY
(CANCELACION_ID) REFERENCES DIVIDIDOS.cancelaciones (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_PAQ_CANC' AND object_id = OBJECT_ID('DIVIDIDOS.paquetes'))
    BEGIN
       CREATE INDEX FKI_PAQ_CANC ON DIVIDIDOS.paquetes (CANCELACION_ID);
    END

ALTER TABLE DIVIDIDOS.canjes
ADD CONSTRAINT CANJES_FK01 FOREIGN KEY
(PRODUCTO_ID) REFERENCES DIVIDIDOS.productos (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_CANJ_PROD' AND object_id = OBJECT_ID('DIVIDIDOS.canjes'))
    BEGIN
       CREATE INDEX FKI_CANJ_PROD ON DIVIDIDOS.canjes (PRODUCTO_ID);
    END

ALTER TABLE DIVIDIDOS.canjes
ADD CONSTRAINT CANJES_FK02 FOREIGN KEY
(CLIENTE_ID) REFERENCES DIVIDIDOS.clientes (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_CANJ_CLIE' AND object_id = OBJECT_ID('DIVIDIDOS.canjes'))
    BEGIN
       CREATE INDEX FKI_CANJ_CLIE ON DIVIDIDOS.canjes (CLIENTE_ID);
    END

ALTER TABLE DIVIDIDOS.cancelaciones
ADD CONSTRAINT CANCELACIONES_FK01 FOREIGN KEY
(BOLETO_COMPRA_ID) REFERENCES DIVIDIDOS.boletos_de_compra (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_CANC_BOLCOMP' AND object_id = OBJECT_ID('DIVIDIDOS.cancelaciones'))
    BEGIN
       CREATE INDEX FKI_CANC_BOLCOMP ON DIVIDIDOS.cancelaciones (BOLETO_COMPRA_ID);
    END

ALTER TABLE DIVIDIDOS.roles_por_usuario
ADD CONSTRAINT ROLES_POR_USUARIO_FK01 FOREIGN KEY
(ROL_ID) REFERENCES DIVIDIDOS.roles (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_ROL_POR_USUA_ROL' AND object_id = OBJECT_ID('DIVIDIDOS.roles_por_usuario'))
    BEGIN
       CREATE INDEX FKI_ROL_POR_USUA_ROL ON DIVIDIDOS.roles_por_usuario (ROL_ID);
    END

ALTER TABLE DIVIDIDOS.roles_por_usuario
ADD CONSTRAINT ROLES_POR_USUARIO_FK02 FOREIGN KEY
(USUARIO_ID) REFERENCES DIVIDIDOS.usuarios (ID)

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'FKI_ROL_POR_USUA_USUARIO' AND object_id = OBJECT_ID('DIVIDIDOS.roles_por_usuario'))
    BEGIN
       CREATE INDEX FKI_ROL_POR_USUA_USUARIO ON DIVIDIDOS.roles_por_usuario (USUARIO_ID);
    END
-----------------------------------------------------------------------
-- INSERTS

INSERT INTO DIVIDIDOS.funcionalidades VALUES
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
('Cancelar Compra'),
('Consultar Listado');

INSERT INTO DIVIDIDOS.roles (nombre, activo) VALUES
('Administrador', 1),
('Cliente', 1);

INSERT INTO DIVIDIDOS.usuarios  (USERNAME, PASSWORD, FECHA_CREACION, ULTIMA_MODIFICACION, INTENTOS_LOGIN, ACTIVO) VALUES 
('admin', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', GETDATE(), GETDATE(), 0, 1),
('admin2', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', GETDATE(), GETDATE(), 0, 1),
('admin3', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', GETDATE(), GETDATE(), 0, 1);

INSERT INTO DIVIDIDOS.roles_por_usuario (ROL_ID, USUARIO_ID) VALUES 
(1, 1),
(1, 2),
(1, 3);

INSERT INTO DIVIDIDOS.productos (NOMBRE, MILLAS_REQUERIDAS, STOCK)
VALUES ('VALIJA', 150, 50),
('CANDADO', 10, 200),
('ALMOHADA', 45, 100),
('AUTO', 10000, 15),
('CALEFACTOR', 500, 150);

INSERT INTO DIVIDIDOS.tipos_tarjeta (NOMBRE, CUOTAS)
VALUES ('VISA', 6),
('MASTERCARD', 12),
('AMEX', 3),
('DINERS', 0);

-----------------------------------------------------------------------
-- PROCEDURES && FUNCTIONS

--DROP
IF OBJECT_ID('DIVIDIDOS.corrigeMail') IS NOT NULL
    DROP FUNCTION DIVIDIDOS.corrigeMail
GO

IF OBJECT_ID('DIVIDIDOS.cantButacasLibres') IS NOT NULL
BEGIN
    DROP FUNCTION DIVIDIDOS.cantButacasLibres
END;
GO

IF OBJECT_ID('DIVIDIDOS.kgLibres') IS NOT NULL
BEGIN
    DROP FUNCTION DIVIDIDOS.kgLibres
END;
GO

IF OBJECT_ID('DIVIDIDOS.precioTotal') IS NOT NULL
    DROP FUNCTION DIVIDIDOS.precioTotal
GO

IF OBJECT_ID('DIVIDIDOS.addFuncionalidad') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.addFuncionalidad;
END;
GO

IF OBJECT_ID('DIVIDIDOS.agregarFuncionalidad') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.agregarFuncionalidad;
END;
GO

IF OBJECT_ID('DIVIDIDOS.cambiarNombreRol') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.cambiarNombreRol;
END;
GO

IF OBJECT_ID('DIVIDIDOS.quitarFuncionalidad') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.quitarFuncionalidad;
END;
GO

IF OBJECT_ID('DIVIDIDOS.agregarRol') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.agregarRol;
END;
GO

IF OBJECT_ID('DIVIDIDOS.vuelosDisponibles') IS NOT NULL
BEGIN
    DROP PROCEDURE DIVIDIDOS.vuelosDisponibles
END;
GO

IF OBJECT_ID('DIVIDIDOS.inhabilitarRol') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.inhabilitarRol;
END;
GO

IF OBJECT_ID('DIVIDIDOS.habilitarRol') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.habilitarRol;
END;
GO

IF OBJECT_ID('DIVIDIDOS.UpdateIntento') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.UpdateIntento;
END;
GO

IF OBJECT_ID('DIVIDIDOS.agregarCliente') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.agregarCliente;
END;
GO

IF OBJECT_ID('DIVIDIDOS.updateCliente') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.updateCliente;
END;
GO

IF OBJECT_ID('DIVIDIDOS.bajaCliente') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.bajaCliente;
END;
GO

IF OBJECT_ID('DIVIDIDOS.agregarAeronave') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.agregarAeronave;
END;
GO

IF OBJECT_ID('DIVIDIDOS.updateAeronave') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.updateAeronave;
END;
GO

IF OBJECT_ID('DIVIDIDOS.bajaAeronave') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.bajaAeronave;
END;
GO

IF OBJECT_ID('DIVIDIDOS.agregarRuta') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.agregarRuta;
END;
GO

IF OBJECT_ID('DIVIDIDOS.updateRuta') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.updateRuta;
END;
GO

IF OBJECT_ID('DIVIDIDOS.bajaRuta') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.bajaRuta;
END;
GO

IF OBJECT_ID('DIVIDIDOS.top5DestinosConPasajes') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.top5DestinosConPasajes;
END;
GO

IF OBJECT_ID('DIVIDIDOS.top5DestinosCancelados') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.top5DestinosCancelados;
END;
GO

IF OBJECT_ID('DIVIDIDOS.top5DestinosAeronavesVacias') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.top5DestinosAeronavesVacias;
END;
GO

IF OBJECT_ID('DIVIDIDOS.top5ClientesMillas') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.top5ClientesMillas;
END;
GO

IF OBJECT_ID('DIVIDIDOS.top5AeronavesFueraDeServicio') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.top5AeronavesFueraDeServicio;
END;
GO

IF OBJECT_ID('DIVIDIDOS.generarViaje') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.generarViaje;
END;
GO

IF OBJECT_ID('DIVIDIDOS.registrarLlegada') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.registrarLlegada;
END;
GO

IF OBJECT_ID('DIVIDIDOS.validarVuelo') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.validarVuelo;
END;
GO

IF OBJECT_ID('DIVIDIDOS.consultarMillas') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.consultarMillas;
END;
GO

IF OBJECT_ID('DIVIDIDOS.obtenerClienteConMillas') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.obtenerClienteConMillas;
END;
GO

IF OBJECT_ID('DIVIDIDOS.altaCanje') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.altaCanje;
END;
GO

IF OBJECT_ID('DIVIDIDOS.migracionButacasPorVuelo') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.migracionButacasPorVuelo;
END;
GO

IF OBJECT_ID('DIVIDIDOS.altaTarjeta') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.altaTarjeta;
END;
GO

IF OBJECT_ID('DIVIDIDOS.bajaCiudad') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.bajaCiudad;
END;
GO

IF OBJECT_ID('DIVIDIDOS.crearButacas') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.crearButacas;
END;
GO

IF OBJECT_ID('DIVIDIDOS.cambiarAeronaveDeVuelo') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.cambiarAeronaveDeVuelo;
END;
GO

IF OBJECT_ID('DIVIDIDOS.bajaVuelo') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.bajaVuelo;
END;
GO

IF OBJECT_ID('DIVIDIDOS.altaPasaje') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.altaPasaje;
END;
GO
​
IF OBJECT_ID('DIVIDIDOS.altaPaquete') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.altaPaquete;
END;
GO

IF OBJECT_ID('DIVIDIDOS.cancelarPasajesDeBc') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.cancelarPasajesDeBc;
END;
GO
​
IF OBJECT_ID('DIVIDIDOS.altaBoletoDeCompra') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.altaBoletoDeCompra;
END;
GO

IF OBJECT_ID('DIVIDIDOS.cancelarPasaje') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.cancelarPasaje;
END;
GO

IF OBJECT_ID('DIVIDIDOS.cancelarPaquete') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.cancelarPaquete;
END;
GO

IF OBJECT_ID('DIVIDIDOS.asignarRol') IS NOT NULL
BEGIN
	DROP PROCEDURE DIVIDIDOS.asignarRol;
END;
GO

--CREATE
CREATE FUNCTION DIVIDIDOS.corrigeMail (@s NVARCHAR (255)) 
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

CREATE FUNCTION DIVIDIDOS.kgLibres(@vuelo int)
RETURNS INT
AS BEGIN
	DECLARE @kgOcupados INT;
	DECLARE @KgTot INT
	SET @kgOcupados=(SELECT SUM(p.KG) from DIVIDIDOS.boletos_de_compra b 
	join DIVIDIDOS.paquetes p on p.BOLETO_COMPRA_ID = b.ID
	where b.VUELO_ID = @vuelo and b.ID not in (SELECT BOLETO_COMPRA_ID FROM DIVIDIDOS.cancelaciones))
	SET @KgTot=(SELECT a.KG_DISPONIBLES from DIVIDIDOS.vuelos v join
	DIVIDIDOS.aeronaves a on a.ID = v.AERONAVE_ID
	where v.ID = @vuelo )
	IF(@kgOcupados IS NULL)
		RETURN @kgTot;
	RETURN @KgTot - @kgOcupados
END
GO

CREATE FUNCTION DIVIDIDOS.precioTotal(@id int)
RETURNS numeric(18,2)
AS BEGIN
	DECLARE @totPas numeric(18,2);
	DECLARE @totPaq numeric(18,2);
	SET @totPas=(SELECT SUM(pas.PRECIO) from DIVIDIDOS.pasajes pas 
	where @id=pas.BOLETO_COMPRA_ID)
	SET @totPaq=(SELECT SUM(paq.PRECIO) from DIVIDIDOS.paquetes paq 
	where @id=paq.BOLETO_COMPRA_ID)
	IF(@totPas IS NULL)
	set @totPas= 0
	IF(@totPaq IS NULL)
	set @totPaq= 0
	RETURN @totPas + @totPaq
END
GO 

CREATE FUNCTION DIVIDIDOS.cantButacasLibres(@vuelo int)
RETURNS INT
AS BEGIN
	DECLARE @butacasLibres INT;
	set @butacasLibres = (SELECT count(b.ID) FROM DIVIDIDOS.butacas_por_vuelo bxv 
	join DIVIDIDOS.butacas b on b.ID = bxv.BUTACA_ID 
	where bxv.VUELO_ID = @vuelo AND bxv.ESTADO = 'LIBRE')
	RETURN  @butacasLibres
END
GO

-- ROLES Y FUNCIONALIDADES
CREATE PROCEDURE DIVIDIDOS.agregarRol(@nombreRol nvarchar(255),@retorno int output)
AS BEGIN
	INSERT INTO DIVIDIDOS.Roles (NOMBRE,ACTIVO) VALUES (@nombreRol, 1)
	SET @retorno = SCOPE_IDENTITY()
END
GO

CREATE PROCEDURE DIVIDIDOS.asignarRol(@idRol int, @idUser int)
AS BEGIN
	INSERT INTO DIVIDIDOS.roles_por_usuario(USUARIO_ID, ROL_ID)
	VALUES (@idUser, @idRol)
END
GO

CREATE PROCEDURE DIVIDIDOS.inhabilitarRol(@idRol int)
AS BEGIN
UPDATE DIVIDIDOS.roles
SET ACTIVO = 0
WHERE ID = @idRol
DELETE DIVIDIDOS.roles_por_usuario WHERE ROL_ID = @idRol
END
GO

CREATE PROCEDURE DIVIDIDOS.habilitarRol(@idRol int)
AS BEGIN
UPDATE DIVIDIDOS.roles
SET ACTIVO = 1
WHERE ID = @idRol
END
GO

CREATE PROCEDURE DIVIDIDOS.addFuncionalidad(@rol nvarchar(255), @func nvarchar(255)) AS
BEGIN
	INSERT INTO DIVIDIDOS.funcionalidades_por_rol (ROL_ID, FUNCIONALIDAD_ID)
		VALUES ((SELECT id FROM DIVIDIDOS.roles WHERE NOMBRE = @rol),
		        (SELECT id FROM DIVIDIDOS.funcionalidades WHERE DETALLES = @func))
END
GO

CREATE PROCEDURE DIVIDIDOS.agregarFuncionalidad(@idRol int, @idFunc int)
AS BEGIN
INSERT INTO DIVIDIDOS.funcionalidades_por_rol (ROL_ID, FUNCIONALIDAD_ID)
VALUES (@idRol, @idFunc)
END
GO

CREATE PROCEDURE DIVIDIDOS.quitarFuncionalidad(@idRol int, @idFunc int)
AS BEGIN
DELETE FROM DIVIDIDOS.funcionalidades_por_rol
WHERE ROL_ID = @idRol and FUNCIONALIDAD_ID = @idFunc
END
GO


CREATE PROCEDURE DIVIDIDOS.cambiarNombreRol(@idRol int, @nombre nvarchar(255))
AS BEGIN
UPDATE DIVIDIDOS.roles
SET NOMBRE=@nombre
WHERE ID=@idRol
END
GO

-- INTENTOS
CREATE PROCEDURE DIVIDIDOS.UpdateIntento(@nombre varchar(25), @exitoso int)
AS BEGIN
	IF(@exitoso = 1)
		BEGIN
			UPDATE DIVIDIDOS.usuarios  SET INTENTOS_LOGIN=0 WHERE USERNAME=@nombre
		END
	ELSE
		BEGIN
			DECLARE @cant_Intentos int
			SELECT @cant_Intentos = intentos_login FROM DIVIDIDOS.usuarios WHERE USERNAME=@nombre
			IF( @cant_Intentos = 2)
				BEGIN
					UPDATE DIVIDIDOS.usuarios  SET ACTIVO=0, INTENTOS_LOGIN=0 WHERE USERNAME=@nombre
				END
			ELSE
				BEGIN
					UPDATE DIVIDIDOS.usuarios set INTENTOS_LOGIN=@cant_Intentos+1 WHERE USERNAME=@nombre
				END
		END
END
GO

-- CLIENTES
CREATE PROCEDURE DIVIDIDOS.agregarCliente(@rol_id INT, @nombreCliente nvarchar(255), @apellidoCliente nvarchar(255), 
	@documentoCliente numeric(18,0), @direccion nvarchar(255), 
	@telefono numeric(18,0), @mail nvarchar(255), @fechaNac varchar(50))
AS BEGIN
	INSERT INTO DIVIDIDOS.Clientes (rol_id, nombre, apellido, dni, direccion,telefono,
	mail,FECHA_NACIMIENTO)  
	VALUES (@rol_id, SUBSTRING(UPPER (@nombreCliente), 1, 1) + SUBSTRING (LOWER (@nombreCliente), 2,LEN(@nombreCliente)), 
	SUBSTRING(UPPER (@apellidoCliente), 1, 1) + SUBSTRING (LOWER (@apellidoCliente), 2,LEN(@apellidoCliente)), 
	@documentoCliente, @direccion, 
	@telefono, DIVIDIDOS.corrigeMail(@mail), convert(datetime, @fechaNac,109))
END
GO

CREATE PROCEDURE DIVIDIDOS.updateCliente(@id INT, @direccion nvarchar(255), @telefono numeric(18,0), @mail nvarchar(255))
AS BEGIN
UPDATE DIVIDIDOS.clientes
SET DIRECCION = @direccion, TELEFONO = @telefono, MAIL =  DIVIDIDOS.corrigeMail(@mail)
WHERE ID = @id
END
GO

CREATE PROCEDURE DIVIDIDOS.bajaCliente(@id  INT)
AS BEGIN
UPDATE DIVIDIDOS.clientes
SET BAJA = 1
WHERE ID=@id;
END
GO

--BUTACAS
CREATE PROCEDURE DIVIDIDOS.crearButacas (@idAeronave int, @butacas int)
AS BEGIN
declare @i int
declare @tipo varchar(50)
set @i = 0
	WHILE(@i != @butacas)
	begin
		if((@i%2) = 0)
		begin
		set @tipo = 'VENTANILLA'
		end
		else
		begin
		set @tipo = 'PASILLO'
		end
		INSERT INTO DIVIDIDOS.butacas (AERONAVE_ID, NUMERO, PISO, TIPO)
		VALUES (@idAeronave, @i, 1, @tipo)
		set @i = @i+1
	end
END
GO

-- AERONAVES
CREATE PROCEDURE DIVIDIDOS.agregarAeronave(@matricula nvarchar(255), @modelo nvarchar(255), @kg_disponibles numeric(18,0), 
@fabricante int, @tipo_servicio int, @alta varchar(50), @cantButacas int)
AS BEGIN
	INSERT INTO DIVIDIDOS.aeronaves(MATRICULA, MODELO, KG_DISPONIBLES, FABRICANTE_ID, TIPO_SERVICIO_ID, FECHA_ALTA, CANT_BUTACAS)
	VALUES (UPPER(@matricula), UPPER(@modelo), @kg_disponibles, @fabricante, @tipo_servicio, convert(datetime, @alta,109), @cantButacas)
	declare @id int
	set @id = SCOPE_IDENTITY()
	EXEC DIVIDIDOS.crearButacas @idAeronave = @id, @butacas = @cantButacas
END
GO

CREATE PROCEDURE DIVIDIDOS.updateAeronave(@id  INT, @fechaInicio varchar(50), @fechaFin varchar(50))
AS BEGIN
DECLARE @IDPERIODO INT
SELECT @IDPERIODO= ID FROM DIVIDIDOS.periodos_de_inactividad WHERE DESDE=convert(datetime, @fechaInicio,109) AND 
HASTA=convert(datetime, @fechaFin,109)
	IF(@IDPERIODO IS NULL)
		BEGIN
			INSERT INTO DIVIDIDOS.periodos_de_inactividad VALUES(convert(datetime, @fechaInicio,109),convert(datetime, @fechaFin,109)) 
			SET @IDPERIODO=SCOPE_IDENTITY()
		END
INSERT INTO  DIVIDIDOS.aeronaves_por_periodos VALUES(@ID,@IDPERIODO)
UPDATE DIVIDIDOS.aeronaves SET BAJA='POR_PERIODO' WHERE ID=@id; 
END
GO

CREATE PROCEDURE DIVIDIDOS.bajaAeronave(@id  INT)
AS BEGIN
UPDATE DIVIDIDOS.aeronaves SET BAJA='DEFINITIVA',
FECHA_BAJA= CURRENT_TIMESTAMP
WHERE ID=@id;
END
GO

-- RUTAS
CREATE PROCEDURE DIVIDIDOS.agregarRuta(@codigo int, @precioKg numeric(18,2), @precioPasaje numeric(18,2), @origen int, @destino int, 
	@servicio int)
AS BEGIN
	INSERT INTO DIVIDIDOS.rutas(CODIGO, PRECIO_BASE_KG, PRECIO_BASE_PASAJE, ORIGEN_ID, DESTINO_ID, TIPO_SERVICIO_ID)
	VALUES (@codigo, @precioKg, @precioPasaje, @origen, @destino, @servicio)
END
GO

CREATE PROCEDURE DIVIDIDOS.updateRuta(@id INT, @precioKg numeric(18,2), @precioPasaje numeric(18,2), @servicio INT)
AS BEGIN
UPDATE DIVIDIDOS.rutas
SET PRECIO_BASE_KG = @precioKg, PRECIO_BASE_PASAJE = @precioPasaje, TIPO_SERVICIO_ID = @servicio
WHERE ID = @id
END
GO

CREATE PROCEDURE DIVIDIDOS.cancelarPasajesDeBc(@idBc int)
AS BEGIN
INSERT INTO DIVIDIDOS.cancelaciones (BOLETO_COMPRA_ID, FECHA_DEVOLUCION, MOTIVO)
VALUES(@idBc,CURRENT_TIMESTAMP,'CANCELACION PASAJE')
UPDATE DIVIDIDOS.pasajes
SET CANCELACION_ID = SCOPE_IDENTITY()
WHERE BOLETO_COMPRA_ID = @idBc
UPDATE DIVIDIDOS.butacas_por_vuelo
SET ESTADO = 'LIBRE'
WHERE BUTACA_ID IN (SELECT p.BUTACA_ID FROM DIVIDIDOS.pasajes p , DIVIDIDOS.boletos_de_compra b WHERE b.ID = @idBc AND p.BOLETO_COMPRA_ID = b.ID)
END
GO

/*SE PUEDE CANCELAR UNO O VARIOS PASAJES DEL MISMO BOLETO DE COMPRA*/
CREATE PROCEDURE DIVIDIDOS.cancelarPasaje(@idPasaje int)
AS BEGIN
INSERT INTO DIVIDIDOS.cancelaciones (BOLETO_COMPRA_ID, FECHA_DEVOLUCION, MOTIVO)
SELECT BOLETO_COMPRA_ID, CURRENT_TIMESTAMP, 'CANCELACION PASAJE' FROM DIVIDIDOS.pasajes WHERE ID = @idPasaje
UPDATE DIVIDIDOS.pasajes
SET CANCELACION_ID = SCOPE_IDENTITY()
WHERE ID = @idPasaje
UPDATE DIVIDIDOS.butacas_por_vuelo
SET ESTADO = 'LIBRE'
WHERE BUTACA_ID = (SELECT BUTACA_ID FROM DIVIDIDOS.pasajes WHERE ID = @idPasaje)
END
GO

/*NO SE PUEDE CANCELAR UN SOLO PAQUETE, SE CANCELAN TODOS LOS DEL BOLETO DE COMPRA*/
CREATE PROCEDURE DIVIDIDOS.cancelarPaquete(@idBoletoCompra int)
AS BEGIN
INSERT INTO DIVIDIDOS.cancelaciones (BOLETO_COMPRA_ID, FECHA_DEVOLUCION, MOTIVO)
VALUES(@idBoletoCompra, CURRENT_TIMESTAMP, 'CANCELACION PAQUETE')
UPDATE DIVIDIDOS.paquetes
SET CANCELACION_ID = SCOPE_IDENTITY()
WHERE BOLETO_COMPRA_ID = @idBoletoCompra
END
GO

CREATE PROCEDURE DIVIDIDOS.bajaVuelo(@id int)
AS BEGIN
DELETE DIVIDIDOS.butacas_por_vuelo WHERE VUELO_ID = @id 
UPDATE DIVIDIDOS.vuelos 
SET INVALIDO = 1
WHERE ID = @id AND FECHA_LLEGADA IS NULL AND FECHA_SALIDA > CURRENT_TIMESTAMP
INSERT INTO DIVIDIDOS.cancelaciones (BOLETO_COMPRA_ID, FECHA_DEVOLUCION, MOTIVO)
SELECT BC.ID, CURRENT_TIMESTAMP, 'BAJA VUELO' FROM DIVIDIDOS.boletos_de_compra BC, DIVIDIDOS.vuelos v WHERE BC.VUELO_ID = @id and
v.ID = bc.VUELO_ID and v.INVALIDO = 1 and bc.INVALIDO = 0
SELECT BC.ID Into  #Temp FROM DIVIDIDOS.boletos_de_compra BC, DIVIDIDOS.vuelos v WHERE BC.VUELO_ID = @id and
v.ID = bc.VUELO_ID and v.INVALIDO = 1 and bc.INVALIDO = 0
Declare @idBoleto int
	While (Select Count(*) From #Temp) > 0
	Begin
		Select Top 1 @idBoleto = Id From #Temp
		EXEC DIVIDIDOS.cancelarPasajesDeBc @idBc = @idBoleto
		EXEC DIVIDIDOS.cancelarPaquete @idBoletoCompra = @idBoleto
		Delete #Temp Where Id = @idBoleto
	End
END
GO

CREATE PROCEDURE DIVIDIDOS.bajaRuta(@id INT)
AS BEGIN
UPDATE DIVIDIDOS.rutas
SET BAJA = 1
WHERE ID=@id;
SELECT v.ID Into #Temp FROM DIVIDIDOS.vuelos v WHERE v.RUTA_ID = @id
Declare @idVuelo int
	While (Select Count(*) From #Temp) > 0
	Begin
		Select Top 1 @idVuelo = Id From #Temp
		EXEC DIVIDIDOS.bajaVuelo @id = @idVuelo
		Delete #Temp Where Id = @idVuelo
	End
END
GO

--LISTADOS ESTADISTICOS
--TOP 5 de los destino con mas pasajes comprados
CREATE PROCEDURE DIVIDIDOS.top5DestinosConPasajes(@fechaFrom varchar(50), @fechaTo varchar(50))
AS BEGIN
select top 5 a.NOMBRE as Destino, count(p.ID) as 'Cantidad de Pasajes' 
from DIVIDIDOS.pasajes p 
join DIVIDIDOS.boletos_de_compra bc on p.BOLETO_COMPRA_ID=bc.ID
join DIVIDIDOS.vuelos v on bc.VUELO_ID=v.ID 
join DIVIDIDOS.rutas r on v.RUTA_ID=r.ID
join DIVIDIDOS.aeropuertos a on r.DESTINO_ID=a.ID
where bc.id NOT IN (select BOLETO_COMPRA_ID from DIVIDIDOS.cancelaciones) and
p.INVALIDO=0 AND
bc.INVALIDO=0 AND
bc.FECHA_COMPRA between convert(datetime, @fechaFrom,109) and convert(datetime, @fechaTo,109)
group by a.nombre 
order by 2 desc
END
GO

--TOP 5 de los destinos con más pasajes cancelados 
CREATE PROCEDURE DIVIDIDOS.top5DestinosCancelados(@fechaFrom varchar(50), @fechaTo varchar(50))
AS BEGIN
select top 5 a.NOMBRE as Destino, count(p.ID) as Cancelaciones from DIVIDIDOS.pasajes p
join DIVIDIDOS.boletos_de_compra bc on p.BOLETO_COMPRA_ID = bc.ID
join DIVIDIDOS.vuelos v on bc.VUELO_ID = v.ID
join DIVIDIDOS.rutas r on v.RUTA_ID=r.ID
join DIVIDIDOS.aeropuertos a on r.DESTINO_ID=a.ID
where p.CANCELACION_ID IS NOT NULL AND
bc.FECHA_COMPRA between convert(datetime, @fechaFrom,109) and convert(datetime, @fechaTo,109)
group by a.NOMBRE 
order by 2 desc
END
GO

--TOP 5 de los destino con aeronaves mas vacias
CREATE PROCEDURE DIVIDIDOS.top5DestinosAeronavesVacias(@fechaFrom varchar(50), @fechaTo varchar(50))
AS BEGIN
select top 5 a.NOMBRE as Destino, count(buV.VUELO_ID) as 'Butacas Vacias' 
from DIVIDIDOS.butacas_por_vuelo buV 
--join DIVIDIDOS.butacas b on naves.ID = b.Aeronave_id 
join DIVIDIDOS.vuelos v on buV.VUELO_ID=v.ID 
join DIVIDIDOS.rutas r on v.RUTA_ID=r.ID 
join DIVIDIDOS.aeropuertos a on r.DESTINO_ID=a.ID 
where buV.ESTADO = 'LIBRE' and
v.FECHA_SALIDA between convert(datetime, @fechaFrom,109) and convert(datetime, @fechaTo,109) and
v.FECHA_LLEGADA between convert(datetime, @fechaFrom,109) and convert(datetime, @fechaTo,109)
group by a.NOMBRE
order by 2 desc
END
GO

--TOP de los clientes con mas puntos acumulados a la fecha (la fecha es hasta el dia de hoy)
CREATE PROCEDURE DIVIDIDOS.top5ClientesMillas(@fechaFrom varchar(50), @fechaTo varchar(50))
AS BEGIN
/*creo tabla temporal, para poder insertar de ambas queries*/
create table #tablaMillas(
Cliente varchar(255),
Millas int
)

/*inserto en la tabla temporal los pasajes*/
insert into #tablaMillas 
select c.NOMBRE+' '+c.APELLIDO, sum(bc.millas)
from DIVIDIDOS.clientes c
join DIVIDIDOS.pasajes p on c.ID=p.CLIENTE_ID
join DIVIDIDOS.boletos_de_compra bc on p.BOLETO_COMPRA_ID=bc.ID 
where P.CANCELACION_ID IS NULL AND
p.INVALIDO=0 AND
bc.INVALIDO=0 AND
bc.FECHA_COMPRA between DATEADD(YYYY, -1, CURRENT_TIMESTAMP) and CURRENT_TIMESTAMP
group by c.nombre, c.APELLIDO

/*inserto en la tabla temporal los paquetes*/
insert into #tablaMillas 
select c.NOMBRE+' '+c.APELLIDO, sum(bc.millas)
from DIVIDIDOS.Clientes c  
join DIVIDIDOS.boletos_de_compra bc on bc.Cliente_ID=c.ID
join DIVIDIDOS.paquetes p on bc.ID = p.BOLETO_COMPRA_ID
where P.CANCELACION_ID IS NULL AND
p.INVALIDO=0 AND
bc.INVALIDO=0 AND
bc.FECHA_COMPRA between DATEADD(YYYY, -1, CURRENT_TIMESTAMP) and CURRENT_TIMESTAMP
group by c.nombre, c.APELLIDO

select top 5 * from #tablaMillas
order by 2 desc

drop table #tablaMillas
END
GO

CREATE PROCEDURE DIVIDIDOS.top5AeronavesFueraDeServicio(@fechaFrom varchar(50), @fechaTo varchar(50))
AS BEGIN
select top 5 a.matricula as 'Nombre Aeronave', sum(DATEDIFF(day,pi.desde,pi.hasta)) as 'Cantidad de días fuera de servicio'
from DIVIDIDOS.aeronaves_por_periodos ap
join DIVIDIDOS.periodos_de_inactividad pi on ap.periodo_id=pi.id
join DIVIDIDOS.aeronaves a on ap.aeronave_id= a.id
where pi.desde between convert(datetime, @fechaFrom,109) and convert(datetime, @fechaTo,109) AND
pi.hasta between convert(datetime, @fechaFrom,109) and convert(datetime, @fechaTo,109) 
group by a.matricula
order by 2 desc 
END
GO

-- VUELOS
CREATE PROCEDURE DIVIDIDOS.generarViaje(@fechaSalida varchar(255), @fechaLlegadaEstimada varchar(255), @idAeronave int, @idRuta int)
AS BEGIN
INSERT INTO DIVIDIDOS.vuelos (FECHA_SALIDA, FECHA_LLEGADA_ESTIMADA, AERONAVE_ID, RUTA_ID)
VALUES (convert(datetime, @fechaSalida,109), convert(datetime, @fechaLlegadaEstimada, 109), @idAeronave, @idRuta)
INSERT INTO DIVIDIDOS.butacas_por_vuelo (VUELO_ID, BUTACA_ID, ESTADO)
SELECT SCOPE_IDENTITY(), b.ID, 'LIBRE' FROM DIVIDIDOS.butacas b
WHERE b.AERONAVE_ID = @idAeronave
END
GO

CREATE PROCEDURE DIVIDIDOS.registrarLlegada(@idVuelo int, @fechaLlegada varchar(50))
AS BEGIN
UPDATE DIVIDIDOS.vuelos
SET FECHA_LLEGADA = convert(datetime, @fechaLlegada,109)
WHERE ID = @idVuelo
UPDATE DIVIDIDOS.boletos_de_compra
SET MILLAS = FLOOR(PRECIO_COMPRA/10)
WHERE VUELO_ID = @idVuelo and ID not in (SELECT BOLETO_COMPRA_ID FROM DIVIDIDOS.cancelaciones)
END
GO

CREATE PROCEDURE DIVIDIDOS.vuelosDisponibles(@fecha varchar(50))
AS BEGIN
	Select v.ID as ID ,v.FECHA_SALIDA as 'Salida', v.FECHA_LLEGADA_ESTIMADA as 'Llegada Estimada', o.NOMBRE as Origen, d.NOMBRE as Destino,
	 DIVIDIDOS.cantButacasLibres(v.ID) as 'Butacas Libres', DIVIDIDOS.kgLibres(v.ID) as 'Kg Disponibles', t.NOMBRE as 'Tipo de Servicio'
	from DIVIDIDOS.vuelos v
	join DIVIDIDOS.rutas r on r.ID = v.RUTA_ID
	join DIVIDIDOS.aeropuertos o on r.ORIGEN_ID = o.ID
	join DIVIDIDOS.aeropuertos d on r.DESTINO_ID = d.ID
	join DIVIDIDOS.aeronaves a on v.AERONAVE_ID = a.ID
	join DIVIDIDOS.tipos_de_servicio t on t.ID = a.TIPO_SERVICIO_ID and t.ID = r.TIPO_SERVICIO_ID
	where (v.INVALIDO = 0) AND (v.FECHA_SALIDA > convert(datetime, @fecha,109)) 
	AND( (DIVIDIDOS.cantButacasLibres(v.ID)  != 0 ) OR (DIVIDIDOS.kgLibres(v.ID) !=0 ))
	order by 2
END
GO

CREATE PROCEDURE DIVIDIDOS.validarVuelo (@id int, @fechaSalida varchar(50), @fechaLlegadaEstimada varchar(50))
AS BEGIN
select COUNT(v.ID) from DIVIDIDOS.vuelos v
where v.AERONAVE_ID = @id and (v.FECHA_SALIDA > convert(datetime, @fechaSalida,109) and v.FECHA_SALIDA < convert(datetime, @fechaLlegadaEstimada,109)
or v.FECHA_LLEGADA > convert(datetime, @fechaSalida,109) and v.FECHA_LLEGADA < convert(datetime, @fechaLlegadaEstimada,109)
or v.FECHA_LLEGADA_ESTIMADA > convert(datetime, @fechaSalida,109) and v.FECHA_LLEGADA_ESTIMADA  < convert(datetime, @fechaLlegadaEstimada,109))
END
GO

CREATE PROCEDURE DIVIDIDOS.cambiarAeronaveDeVuelo (@idVuelo int, @idAeronaveNueva int)
AS BEGIN
UPDATE DIVIDIDOS.vuelos
SET AERONAVE_ID = @idAeronaveNueva
WHERE ID = @idVuelo
END
GO

-- BUTACAS POR VUELO
CREATE PROCEDURE DIVIDIDOS.migracionButacasPorVuelo
AS BEGIN
declare @cantAeronaves int
select @cantAeronaves = count(ID) from DIVIDIDOS.aeronaves
declare @j int
set @j = 1
	while(@j != @cantAeronaves+1)
	begin
	declare @cantButacas int
	SELECT @cantButacas = a.CANT_BUTACAS from DIVIDIDOS.aeronaves a where a.ID = @j
	declare @i int
	set @i = 0
		WHILE(@i != @cantButacas)
		begin
			IF((SELECT count(b.ID) FROM DIVIDIDOS.butacas b, DIVIDIDOS.vuelos v
			where v.INVALIDO = 0 and b.AERONAVE_ID = @j and v.AERONAVE_ID = @j and b.NUMERO = @i) = 0)
				begin
				INSERT INTO DIVIDIDOS.butacas_por_vuelo(BUTACA_ID, VUELO_ID, ESTADO)
				SELECT b.ID, v.ID,'LIBRE' FROM DIVIDIDOS.butacas b, DIVIDIDOS.vuelos v
				where v.INVALIDO = 0 and b.AERONAVE_ID = @j and v.AERONAVE_ID = @j and b.NUMERO = @i
				end
			else
				begin
				INSERT INTO DIVIDIDOS.butacas_por_vuelo(BUTACA_ID, VUELO_ID, ESTADO)
				SELECT b.ID, v.ID,'COMPRADO' FROM DIVIDIDOS.butacas b, DIVIDIDOS.vuelos v
				where v.INVALIDO = 0 and b.AERONAVE_ID = @j and v.AERONAVE_ID = @j and b.NUMERO = @i
				end
		set @i = @i+1
		end
	set @j = @j+1
	end
END
GO

-- MILLAS
CREATE PROCEDURE DIVIDIDOS.consultarMillas (@dni numeric(18,0))
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
from DIVIDIDOS.clientes c
join DIVIDIDOS.pasajes p on c.ID=p.CLIENTE_ID 
join DIVIDIDOS.boletos_de_compra bc on p.BOLETO_COMPRA_ID=bc.ID 
where bc.ID NOT IN (select BOLETO_COMPRA_ID from DIVIDIDOS.cancelaciones) and
p.INVALIDO=0 AND
bc.INVALIDO=0 AND
bc.FECHA_COMPRA between DATEADD(YYYY, -1, CURRENT_TIMESTAMP) and CURRENT_TIMESTAMP
and c.DNI = @dni

/*inserto en la tabla temporal los paquetes*/
insert into #tablaMillas 
select bc.FECHA_COMPRA as Fecha, 'Paquete' as Motivo, bc.millas as Millas
from DIVIDIDOS.clientes c  
join DIVIDIDOS.boletos_de_compra bc on bc.CLIENTE_ID=c.ID
join DIVIDIDOS.paquetes p on bc.ID = p.BOLETO_COMPRA_ID
where bc.ID NOT IN (select BOLETO_COMPRA_ID from DIVIDIDOS.cancelaciones) and
p.INVALIDO=0 AND
bc.INVALIDO=0 AND
bc.FECHA_COMPRA between DATEADD(YYYY, -1, CURRENT_TIMESTAMP) and CURRENT_TIMESTAMP
and c.DNI = @dni

/*inserto en la tabla temporal los canjes*/
insert into #tablaMillas 
select cj.FECHA_CANJE as Fecha, 'Canje por '+CONVERT(varchar(10), cj.CANTIDAD)+' unidades de '+LOWER(p.NOMBRE) as Motivo, 
-p.MILLAS_REQUERIDAS*cj.CANTIDAD as Millas
from DIVIDIDOS.clientes c
join DIVIDIDOS.canjes cj on cj.CLIENTE_ID=c.ID
join DIVIDIDOS.productos p on p.ID = cj.PRODUCTO_ID
where cj.FECHA_CANJE between DATEADD(YYYY, -1, CURRENT_TIMESTAMP) and CURRENT_TIMESTAMP
and c.DNI = @dni

/*hago el select que me va a devolver toda la tabla para el dataGridView*/
select * from #tablaMillas

/*hago drop de la tabla temporal*/
drop table #tablaMillas
END
GO

CREATE PROCEDURE DIVIDIDOS.obtenerClienteConMillas (@dni numeric(18,0))
AS BEGIN
CREATE TABLE #Result (
  FECHA_COMPRA datetime,
  Motivo varchar(255),
  Millas int
)
INSERT INTO #Result EXEC DIVIDIDOS.consultarMillas @dni

SELECT c.ID, c.NOMBRE as Nombre, c.APELLIDO as Apellido, c.DNI as Dni, c.FECHA_NACIMIENTO as 'Fecha de Nacimiento', SUM(r.Millas) as Millas
FROM #Result r
join DIVIDIDOS.clientes c on c.DNI = @dni
group by c.ID, c.NOMBRE, c.APELLIDO, c.DNI, c.FECHA_NACIMIENTO
DROP TABLE #Result
END
GO

-- CANJES
CREATE PROCEDURE DIVIDIDOS.altaCanje (@idCliente int, @idProducto int, @cantidad int)
AS BEGIN
INSERT INTO DIVIDIDOS.canjes (CLIENTE_ID, PRODUCTO_ID, CANTIDAD, FECHA_CANJE)
VALUES (@idCliente, @idProducto, @cantidad, CURRENT_TIMESTAMP)
UPDATE DIVIDIDOS.productos
SET STOCK = STOCK - @cantidad
where ID = @idProducto
END
GO

-- TARJETAS
CREATE PROCEDURE DIVIDIDOS.altaTarjeta (@idCliente int, @nroTarjeta numeric(18,0), @idTipo int, @fechaVto varchar(255))
AS BEGIN
INSERT INTO DIVIDIDOS.tarjetas_de_credito (Cliente_ID, NUMERO, TIPO_TARJETA_ID, FECHA_VTO)
VALUES (@idCliente, @nroTarjeta, @idTipo, convert(datetime, @fechaVto,109))
END
GO

-- CIUDADES
/*Hago baja logica de todo porque sino rompe*/
CREATE PROCEDURE DIVIDIDOS.bajaCiudad (@idCiudad int)
AS BEGIN
UPDATE DIVIDIDOS.aeropuertos
SET BAJA = 1
WHERE CIUDAD_ID = @idCiudad

UPDATE DIVIDIDOS.ciudades
SET BAJA = 1
WHERE ID = @idCiudad

SELECT r.ID Into #Temp FROM DIVIDIDOS.rutas r, DIVIDIDOS.aeropuertos a WHERE (r.ORIGEN_ID = a.ID and a.CIUDAD_ID = @idCiudad) or 
(r.DESTINO_ID = a.ID and a.CIUDAD_ID = @idCiudad)
Declare @idRuta int
	While (Select Count(*) From #Temp) > 0
	Begin
		Select Top 1 @idRuta = Id From #Temp
		EXEC DIVIDIDOS.bajaRuta @id = @idRuta
		Delete #Temp Where Id = @idRuta
	End
END
GO

-- COMPRAS
CREATE PROCEDURE DIVIDIDOS.altaBoletoDeCompra (@precio numeric(18,2), @tipo nvarchar(255), @idCliente int, @idVuelo int)
AS BEGIN
INSERT INTO DIVIDIDOS.boletos_de_compra (PRECIO_COMPRA, TIPO_COMPRA, CLIENTE_ID, VUELO_ID, FECHA_COMPRA, MILLAS)
VALUES (@precio, UPPER(@tipo), @idCliente, @idVuelo, CURRENT_TIMESTAMP, 0)
END
GO

CREATE PROCEDURE DIVIDIDOS.altaPasaje (@idCliente int, @idButaca int, @idBoletoCompra int, @precio numeric(18,2))
AS BEGIN
DECLARE @codigo numeric(18,0)
select top 1 @codigo = CODIGO from DIVIDIDOS.pasajes
order by CODIGO desc
INSERT INTO DIVIDIDOS.pasajes (CLIENTE_ID, BUTACA_ID, BOLETO_COMPRA_ID, PRECIO, CODIGO, CANCELACION_ID)
VALUES (@idCliente, @idButaca, @idBoletoCompra, @precio, @codigo+1, NULL)
UPDATE DIVIDIDOS.butacas_por_vuelo
SET ESTADO = 'COMPRADO'
WHERE BUTACA_ID = @idButaca AND VUELO_ID = (SELECT bc.VUELO_ID FROM DIVIDIDOS.boletos_de_compra bc WHERE bc.ID = @idBoletoCompra)
END
GO

CREATE PROCEDURE DIVIDIDOS.altaPaquete (@idBoletoCompra int, @kg numeric(18,2), @precio numeric(18,2))
AS BEGIN
DECLARE @codigo numeric(18,0)
select top 1 @codigo = CODIGO from DIVIDIDOS.paquetes
order by CODIGO desc
INSERT INTO DIVIDIDOS.paquetes (BOLETO_COMPRA_ID, KG, PRECIO, CODIGO, CANCELACION_ID)
VALUES (@idBoletoCompra, @kg, @precio, @codigo+1, NULL)
END
GO

-----------------------------------------------------------------------
-- TRIGGERS

IF OBJECT_ID('DIVIDIDOS.insertVuelos') IS NOT NULL
BEGIN
   DROP TRIGGER DIVIDIDOS.insertVuelos;
END;
GO

IF OBJECT_ID('DIVIDIDOS.insertBoletosCompra') IS NOT NULL
BEGIN
   DROP TRIGGER DIVIDIDOS.insertBoletosCompra;
END;
GO

IF OBJECT_ID('DIVIDIDOS.insertPasajes') IS NOT NULL
BEGIN
   DROP TRIGGER DIVIDIDOS.insertPasajes;
END;
GO

IF OBJECT_ID('DIVIDIDOS.insertPaquetes') IS NOT NULL
BEGIN
   DROP TRIGGER DIVIDIDOS.insertPaquetes;
END;
GO

CREATE TRIGGER DIVIDIDOS.insertVuelos on DIVIDIDOS.vuelos
AFTER INSERT
AS BEGIN TRANSACTION
update DIVIDIDOS.vuelos
set INVALIDO= 1
where ID in (select i.ID from DIVIDIDOS.vuelos v, inserted i
where v.id != i.id and v.AERONAVE_ID = i.AERONAVE_ID and (i.FECHA_SALIDA between v.FECHA_SALIDA and v.FECHA_LLEGADA_ESTIMADA
or i.FECHA_LLEGADA between v.FECHA_SALIDA and v.FECHA_LLEGADA_ESTIMADA 
or i.FECHA_LLEGADA_ESTIMADA between v.FECHA_SALIDA and v.FECHA_LLEGADA_ESTIMADA))
COMMIT
GO

CREATE TRIGGER DIVIDIDOS.insertBoletosCompra on DIVIDIDOS.boletos_de_compra
AFTER INSERT
AS BEGIN TRANSACTION
UPDATE DIVIDIDOS.boletos_de_compra
SET INVALIDO = 1
WHERE VUELO_ID in (select v.ID from DIVIDIDOS.vuelos v where v.INVALIDO = 1)
COMMIT
GO

CREATE TRIGGER DIVIDIDOS.insertPasajes on DIVIDIDOS.pasajes
AFTER INSERT
AS BEGIN TRANSACTION
UPDATE DIVIDIDOS.pasajes
SET INVALIDO = 1
WHERE BOLETO_COMPRA_ID in (select bc.ID from DIVIDIDOS.boletos_de_compra bc where bc.INVALIDO = 1)
COMMIT
GO

CREATE TRIGGER DIVIDIDOS.insertPaquetes on DIVIDIDOS.paquetes
AFTER INSERT
AS BEGIN TRANSACTION
UPDATE DIVIDIDOS.paquetes
SET INVALIDO = 1
WHERE BOLETO_COMPRA_ID in (select bc.ID from DIVIDIDOS.boletos_de_compra bc where bc.INVALIDO = 1)
COMMIT
GO

-----------------------------------------------------------------------
-- MIGRACION

INSERT INTO DIVIDIDOS.fabricantes (NOMBRE)
SELECT DISTINCT Aeronave_Fabricante
FROM gd_esquema.Maestra
WHERE Aeronave_Fabricante IS NOT NULL

INSERT INTO DIVIDIDOS.tipos_de_servicio (NOMBRE)
SELECT DISTINCT Tipo_Servicio
FROM gd_esquema.Maestra
WHERE Tipo_Servicio IS NOT NULL
update DIVIDIDOS.tipos_de_servicio
set porcentaje= 0.05
where id=3
update DIVIDIDOS.tipos_de_servicio
set porcentaje= 0.1
where id=2
update DIVIDIDOS.tipos_de_servicio
set porcentaje= 0.15
where id=1

INSERT INTO DIVIDIDOS.ciudades (NOMBRE)
(SELECT DISTINCT Ruta_Ciudad_Origen
FROM gd_esquema.Maestra
WHERE Ruta_Ciudad_Origen IS NOT NULL
UNION
SELECT DISTINCT Ruta_Ciudad_Destino
FROM gd_esquema.Maestra
WHERE Ruta_Ciudad_Destino IS NOT NULL)

INSERT INTO DIVIDIDOS.aeropuertos (CIUDAD_ID, NOMBRE)
(SELECT ID, NOMBRE
FROM DIVIDIDOS.ciudades)

INSERT INTO DIVIDIDOS.clientes (DNI, NOMBRE, APELLIDO, FECHA_NACIMIENTO, MAIL, TELEFONO, DIRECCION, ROL_ID)
select m.Cli_Dni, SUBSTRING(UPPER (m.Cli_Nombre), 1, 1) + SUBSTRING (LOWER (m.Cli_Nombre), 2,LEN(m.Cli_Nombre)), 
SUBSTRING(UPPER (m.Cli_Apellido), 1, 1) + SUBSTRING (LOWER (m.Cli_Apellido), 2,LEN(m.Cli_Apellido)), m.Cli_Fecha_Nac, 
DIVIDIDOS.corrigeMail(m.Cli_Mail), m.Cli_Telefono, m.Cli_Dir, r.ID
from GD2C2015.gd_esquema.Maestra m, DIVIDIDOS.roles r
where r.NOMBRE = 'Cliente'
group by m.Cli_Dni, m.Cli_Nombre, m.Cli_Apellido, m.Cli_Fecha_Nac, m.Cli_Mail, m.Cli_Telefono, m.Cli_Dir, r.ID;

/*la fecha de creacion es CURRENT TIMESTAMP ya que las fechas de salida de las aeronaves son en 2016*/
INSERT INTO DIVIDIDOS.aeronaves (MATRICULA, MODELO, KG_DISPONIBLES, FABRICANTE_ID, TIPO_SERVICIO_ID, FECHA_ALTA, CANT_BUTACAS)
SELECT UPPER(m.Aeronave_Matricula), UPPER(m.Aeronave_Modelo), m.Aeronave_KG_Disponibles, f.ID, ts.ID, CURRENT_TIMESTAMP, m.Butaca_Nro+1
FROM GD2C2015.gd_esquema.Maestra m, DIVIDIDOS.fabricantes f, DIVIDIDOS.tipos_de_servicio ts
where f.NOMBRE = m.Aeronave_Fabricante and ts.NOMBRE = m.Tipo_Servicio 
/*QUERY PARA SABER CUAL ES EL MAYOR NUMERO DE BUTACA DE LAS AERONAVES, POR SI ES QUE SE USA ESE NUMERO PARA LA CANT_BUTACAS*/
and m.Butaca_Nro = (select max(Butaca_Nro) from [GD2C2015].[gd_esquema].[Maestra] j where m.Aeronave_Matricula = j.Aeronave_Matricula)
group by m.Aeronave_Matricula, m.Aeronave_Modelo, m.Aeronave_KG_Disponibles, f.ID, ts.ID, m.Butaca_Nro

INSERT INTO DIVIDIDOS.butacas (NUMERO, TIPO, PISO, AERONAVE_ID)
SELECT M.Butaca_Nro, UPPER(M.Butaca_Tipo), M.Butaca_Piso, A.ID
FROM DIVIDIDOS.aeronaves A, GD2C2015.gd_esquema.Maestra M
WHERE A.MATRICULA = M.Aeronave_Matricula and Butaca_Piso != 0
GROUP BY M.Butaca_Nro, M.Butaca_Tipo, M.Butaca_Piso, A.ID

/*Creo tabla temporal para las rutas, con esa tabla despues es mas facil unificar las filas que pertenezcan a la MISMA ruta (todo igual
excepto que en una fila el kg base esta en 0 y en la otra el pasaje base esta en 0) porque en vez de recorrer 400000 filas recorre
solamente 136, por lo que nos deja un total de 68 rutas diferentes (si tienen el mismo codigo de ruta pero distinto origen o destino o 
tipo de servicio son distintas rutas)*/
SELECT DISTINCT [Ruta_Codigo], [Ruta_Precio_BaseKG], [Ruta_Precio_BasePasaje], [Ruta_Ciudad_Origen], [Ruta_Ciudad_Destino], [Tipo_Servicio]
INTO #rutas_temporales
FROM [GD2C2015].[gd_esquema].[Maestra]

INSERT INTO DIVIDIDOS.rutas (CODIGO, PRECIO_BASE_KG, PRECIO_BASE_PASAJE, ORIGEN_ID, DESTINO_ID, TIPO_SERVICIO_ID)
SELECT r.Ruta_Codigo, r.Ruta_Precio_BaseKG, r2.Ruta_Precio_BasePasaje, o.ID, d.ID, ts.ID
FROM #rutas_temporales r, #rutas_temporales r2, DIVIDIDOS.aeropuertos o, DIVIDIDOS.aeropuertos d, DIVIDIDOS.tipos_de_servicio ts
WHERE d.NOMBRE = r.Ruta_Ciudad_Destino AND o.NOMBRE = r.Ruta_Ciudad_Origen AND ts.NOMBRE = r.Tipo_Servicio
AND r.Ruta_Precio_BasePasaje = 0 AND r2.Ruta_Precio_BaseKG = 0 AND r.Ruta_Codigo = r2.Ruta_Codigo
AND r.Ruta_Ciudad_Destino = r2.Ruta_Ciudad_Destino AND r.Ruta_Ciudad_Origen = r2.Ruta_Ciudad_Origen
AND r.Tipo_Servicio = r2.Tipo_Servicio

/*elimino la tabla temporal*/
DROP TABLE #rutas_temporales

INSERT INTO DIVIDIDOS.vuelos (FECHA_SALIDA, FECHA_LLEGADA_ESTIMADA, FECHA_LLEGADA, AERONAVE_ID, RUTA_ID)
SELECT m.[FechaSalida], m.[Fecha_LLegada_Estimada], m.[FechaLLegada], a.ID, r.ID
FROM [GD2C2015].[gd_esquema].[Maestra] m, DIVIDIDOS.aeronaves a, DIVIDIDOS.rutas r, DIVIDIDOS.aeropuertos p1, DIVIDIDOS.aeropuertos p2
WHERE m.[Ruta_Codigo] = r.CODIGO AND m.[Ruta_Ciudad_Origen] = p1.NOMBRE AND p1.ID = r.ORIGEN_ID AND m.[Ruta_Ciudad_Destino] = p2.NOMBRE 
AND p2.ID = r.DESTINO_ID AND a.MATRICULA = m.[Aeronave_Matricula]
GROUP BY m.[FechaSalida], m.[Fecha_LLegada_Estimada], m.[FechaLLegada], a.ID, r.ID

/*ejecucion de procedure que migra la tabla de butacas por vuelo*/
EXEC DIVIDIDOS.migracionButacasPorVuelo

/*migracion de boletos de compra, con precio y millas en 0 (despues se actualizan)*/
insert into DIVIDIDOS.boletos_de_compra (CLIENTE_ID, FECHA_COMPRA, MILLAS, PRECIO_COMPRA, TIPO_COMPRA, VUELO_ID)
SELECT distinct C.ID as cliente, CASE WHEN Paquete_Codigo != 0 THEN Paquete_FechaCompra ELSE Pasaje_FechaCompra END AS FechaCompra, 0 as Millas, 0 as Precio, 'EFECTIVO' as tipoCompra, v.ID as vuelo
FROM GD2C2015.gd_esquema.Maestra M
join DIVIDIDOS.clientes C on C.APELLIDO = SUBSTRING(UPPER (m.Cli_Apellido), 1, 1) + SUBSTRING (LOWER (m.Cli_Apellido), 2,LEN(m.Cli_Apellido))
and C.NOMBRE = SUBSTRING(UPPER (m.Cli_Nombre), 1, 1) + SUBSTRING (LOWER (m.Cli_Nombre), 2,LEN(m.Cli_Nombre))
and C.DNI = M.Cli_Dni
join DIVIDIDOS.aeronaves a on m.Aeronave_Matricula = a.MATRICULA
join DIVIDIDOS.vuelos v on v.AERONAVE_ID = a.ID and v.RUTA_ID = 
	(SELECT r.id from DIVIDIDOS.rutas r 
	join DIVIDIDOS.aeropuertos p1 on m.[Ruta_Ciudad_Origen] = p1.NOMBRE AND p1.ID = r.ORIGEN_ID
	join DIVIDIDOS.aeropuertos p2 on m.[Ruta_Ciudad_Destino] = p2.NOMBRE AND p2.ID = r.DESTINO_ID
	where m.[Ruta_Codigo] = r.CODIGO and m.FechaSalida = v.FECHA_SALIDA and m.Fecha_LLegada_Estimada = v.FECHA_LLEGADA_ESTIMADA and
	m.FechaLLegada = v.FECHA_LLEGADA)

/*migracion de pasajes*/
INSERT INTO DIVIDIDOS.pasajes (CODIGO, CLIENTE_ID, BUTACA_ID, CANCELACION_ID, BOLETO_COMPRA_ID, PRECIO)
SELECT M.Pasaje_Codigo, C.ID, B.ID, NULL, bc.ID, M.Pasaje_Precio FROM GD2C2015.gd_esquema.Maestra M
join DIVIDIDOS.clientes C on C.APELLIDO = SUBSTRING(UPPER (m.Cli_Apellido), 1, 1) + SUBSTRING (LOWER (m.Cli_Apellido), 2,LEN(m.Cli_Apellido))
and C.NOMBRE = SUBSTRING(UPPER (m.Cli_Nombre), 1, 1) + SUBSTRING (LOWER (m.Cli_Nombre), 2,LEN(m.Cli_Nombre))
and C.DNI = M.Cli_Dni
join DIVIDIDOS.aeronaves A on M.Aeronave_Matricula = A.MATRICULA
join DIVIDIDOS.butacas B on B.NUMERO = M.Butaca_Nro and A.ID = B.AERONAVE_ID
join DIVIDIDOS.boletos_de_compra bc on m.Pasaje_FechaCompra = bc.FECHA_COMPRA and bc.CLIENTE_ID = c.ID
join DIVIDIDOS.vuelos v on v.AERONAVE_ID = a.ID and v.RUTA_ID = 
	(SELECT r.id from DIVIDIDOS.rutas r 
	join DIVIDIDOS.aeropuertos p1 on m.[Ruta_Ciudad_Origen] = p1.NOMBRE AND p1.ID = r.ORIGEN_ID
	join DIVIDIDOS.aeropuertos p2 on m.[Ruta_Ciudad_Destino] = p2.NOMBRE AND p2.ID = r.DESTINO_ID
	where m.[Ruta_Codigo] = r.CODIGO and m.FechaSalida = v.FECHA_SALIDA and m.Fecha_LLegada_Estimada = v.FECHA_LLEGADA_ESTIMADA and
	m.FechaLLegada = v.FECHA_LLEGADA) and v.ID=bc.VUELO_ID 
where M.Pasaje_Codigo != 0

/*migracion de paquetes*/
INSERT INTO DIVIDIDOS.paquetes (CODIGO, KG, BOLETO_COMPRA_ID, CANCELACION_ID, PRECIO)
SELECT M.Paquete_Codigo, M.Paquete_KG, bc.ID, NULL, M.Paquete_Precio FROM GD2C2015.gd_esquema.Maestra M
join DIVIDIDOS.clientes C on C.APELLIDO = SUBSTRING(UPPER (m.Cli_Apellido), 1, 1) + SUBSTRING (LOWER (m.Cli_Apellido), 2,LEN(m.Cli_Apellido))
and C.NOMBRE = SUBSTRING(UPPER (m.Cli_Nombre), 1, 1) + SUBSTRING (LOWER (m.Cli_Nombre), 2,LEN(m.Cli_Nombre))
and C.DNI = M.Cli_Dni
join DIVIDIDOS.boletos_de_compra bc on m.Paquete_FechaCompra = bc.FECHA_COMPRA and bc.CLIENTE_ID = c.ID
join DIVIDIDOS.aeronaves A on M.Aeronave_Matricula = A.MATRICULA
join DIVIDIDOS.vuelos v on v.AERONAVE_ID = a.ID and v.RUTA_ID = 
	(SELECT r.id from DIVIDIDOS.rutas r 
	join DIVIDIDOS.aeropuertos p1 on m.[Ruta_Ciudad_Origen] = p1.NOMBRE AND p1.ID = r.ORIGEN_ID
	join DIVIDIDOS.aeropuertos p2 on m.[Ruta_Ciudad_Destino] = p2.NOMBRE AND p2.ID = r.DESTINO_ID
	where m.[Ruta_Codigo] = r.CODIGO and m.FechaSalida = v.FECHA_SALIDA and m.Fecha_LLegada_Estimada = v.FECHA_LLEGADA_ESTIMADA and
	m.FechaLLegada = v.FECHA_LLEGADA) and v.ID=bc.VUELO_ID 
where M.Paquete_Codigo != 0

/*actualizamos los datos del boleto de compra (precio y millas) segun la cantidad de pasajes y paquetes que los referencien*/
update DIVIDIDOS.boletos_de_compra 
set PRECIO_COMPRA= DIVIDIDOS.precioTotal(id)

update DIVIDIDOS.boletos_de_compra 
set millas= FLOOR(PRECIO_COMPRA/10)

-----------------------------------------------------------------------
-- EJECUCION DE PROCEDURES

EXEC DIVIDIDOS.addFuncionalidad @rol='Administrador', @func ='Consultar Millas';
EXEC DIVIDIDOS.addFuncionalidad @rol='Administrador', @func ='Alta de Cliente';
EXEC DIVIDIDOS.addFuncionalidad @rol='Administrador', @func ='Alta de Aeronave';
EXEC DIVIDIDOS.addFuncionalidad @rol='Administrador', @func ='Alta de Tarjeta de Crédito';
EXEC DIVIDIDOS.addFuncionalidad @rol='Administrador', @func ='Baja de Aeronave';
EXEC DIVIDIDOS.addFuncionalidad @rol='Administrador', @func ='Baja de Ciudad';
EXEC DIVIDIDOS.addFuncionalidad @rol='Administrador', @func ='Baja de Cliente';
EXEC DIVIDIDOS.addFuncionalidad @rol='Administrador', @func ='Modificacion de Aeronave';
EXEC DIVIDIDOS.addFuncionalidad @rol='Administrador', @func ='Modificacion de Cliente';
EXEC DIVIDIDOS.addFuncionalidad @rol='Administrador', @func ='Realizar Canje';
EXEC DIVIDIDOS.addFuncionalidad @rol='Administrador', @func ='Alta de Rol';
EXEC DIVIDIDOS.addFuncionalidad @rol='Administrador', @func ='Baja de Rol';
EXEC DIVIDIDOS.addFuncionalidad @rol='Administrador', @func ='Modificacion de Rol';
EXEC DIVIDIDOS.addFuncionalidad @rol='Administrador', @func ='Alta de Ruta';
EXEC DIVIDIDOS.addFuncionalidad @rol='Administrador', @func ='Baja de Ruta';
EXEC DIVIDIDOS.addFuncionalidad @rol='Administrador', @func ='Modificacion de Ruta';
EXEC DIVIDIDOS.addFuncionalidad @rol='Administrador', @func ='Comprar Pasaje/Encomienda';
EXEC DIVIDIDOS.addFuncionalidad @rol='Administrador', @func ='Generar Viaje';
EXEC DIVIDIDOS.addFuncionalidad @rol='Administrador', @func ='Registrar Llegadas';
EXEC DIVIDIDOS.addFuncionalidad @rol='Administrador', @func ='Consultar Listado';
EXEC DIVIDIDOS.addFuncionalidad @rol='Administrador', @func ='Cancelar Compra';
EXEC DIVIDIDOS.addFuncionalidad @rol='Cliente', @func ='Comprar Pasaje/Encomienda';
EXEC DIVIDIDOS.addFuncionalidad @rol='Cliente', @func ='Consultar Millas';
EXEC DIVIDIDOS.addFuncionalidad @rol='Cliente', @func ='Realizar Canje';
EXEC DIVIDIDOS.addFuncionalidad @rol='Cliente', @func ='Alta de Tarjeta de Crédito';
EXEC DIVIDIDOS.addFuncionalidad @rol='Cliente', @func ='Cancelar Compra';
