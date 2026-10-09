-- ============================================================
-- SERVICIO CIUDADANO 1800 - DATA WAREHOUSE (CASO 15)
-- Resolución y recontacto en un centro de atención
-- Zona de preparación + Data Warehouse + catálogos
--
-- Flujo (lo que pide el profe: recolección -> limpieza -> análisis):
--   Generador C# -> stg_interaccion_cruda (datos SUCIOS, tal como llegan)
--   MINI ETL C#  -> data/v0_crudo.csv y data/v1_limpio.csv (evidencia)
--   Generador C# -> hecho_interaccion (datos LIMPIOS, modelo estrella)
--   SQL 02/03    -> dm_dataset_* (datasets de minería) + vw_kpi_*
--
-- Reglas:
--   * Todo hecho tiene DOS roles de tiempo: fecha_contacto y fecha_carga.
--   * Trazabilidad inversa: cada fila del DW guarda id_registro_crudo para
--     volver a su registro original en la zona de preparación.
--   * La limpieza es responsabilidad del MINI ETL; el DW guarda catálogos limpios.
-- ============================================================

-- 1. CREAR BASE DE DATOS
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'ServicioCiudadano1800DW')
BEGIN
    CREATE DATABASE ServicioCiudadano1800DW;
END
GO

USE ServicioCiudadano1800DW;
GO

-- ============================================================
-- 1.b RE-EJECUCIÓN SEGURA: primero se eliminan las tablas
-- dependientes (hechos y staging referencian a las dimensiones;
-- si no se hace en este orden, SQL Server rechaza los DROP).
-- ============================================================
IF OBJECT_ID('dbo.hecho_interaccion', 'U') IS NOT NULL DROP TABLE dbo.hecho_interaccion;
IF OBJECT_ID('dbo.stg_interaccion_cruda', 'U') IS NOT NULL DROP TABLE dbo.stg_interaccion_cruda;
IF OBJECT_ID('dbo.dq_lote', 'U') IS NOT NULL DROP TABLE dbo.dq_lote;
GO

-- ============================================================
-- 2. DIMENSIONES
-- ============================================================

-- DIM_TIEMPO: calendario para análisis temporales (contacto y carga)
IF OBJECT_ID('dbo.dim_tiempo', 'U') IS NOT NULL DROP TABLE dbo.dim_tiempo;
GO

CREATE TABLE dim_tiempo (
    id_tiempo           INT          NOT NULL PRIMARY KEY,   -- formato yyyymmdd
    fecha               DATE         NOT NULL UNIQUE,
    anio                SMALLINT     NOT NULL,
    trimestre           TINYINT      NOT NULL,
    mes                 TINYINT      NOT NULL,
    nombre_mes          NVARCHAR(12) NOT NULL,
    semana_iso          TINYINT      NOT NULL,
    dia_mes             TINYINT      NOT NULL,
    dia_semana          TINYINT      NOT NULL,               -- 1 = lunes ... 7 = domingo
    nombre_dia          NVARCHAR(12) NOT NULL,
    es_fin_de_semana    BIT          NOT NULL
);
GO

WITH fechas AS (
    SELECT CAST('2024-01-01' AS DATE) AS fecha
    UNION ALL
    SELECT DATEADD(DAY, 1, fecha) FROM fechas WHERE fecha < '2026-12-31'
)
INSERT INTO dim_tiempo (id_tiempo, fecha, anio, trimestre, mes, nombre_mes, semana_iso, dia_mes, dia_semana, nombre_dia, es_fin_de_semana)
SELECT
    YEAR(fecha) * 10000 + MONTH(fecha) * 100 + DAY(fecha),
    fecha,
    YEAR(fecha),
    DATEPART(QUARTER, fecha),
    MONTH(fecha),
    CHOOSE(MONTH(fecha), N'enero', N'febrero', N'marzo', N'abril', N'mayo', N'junio',
                         N'julio', N'agosto', N'septiembre', N'octubre', N'noviembre', N'diciembre'),
    DATEPART(ISO_WEEK, fecha),
    DAY(fecha),
    (DATEDIFF(DAY, '19000101', fecha) % 7) + 1,
    CHOOSE((DATEDIFF(DAY, '19000101', fecha) % 7) + 1,
           N'lunes', N'martes', N'miércoles', N'jueves', N'viernes', N'sábado', N'domingo'),
    CASE WHEN (DATEDIFF(DAY, '19000101', fecha) % 7) + 1 >= 6 THEN 1 ELSE 0 END
FROM fechas
OPTION (MAXRECURSION 0);
GO

-- DIM_CANAL: canal por donde entró la interacción (Informe 2)
IF OBJECT_ID('dbo.dim_canal', 'U') IS NOT NULL DROP TABLE dbo.dim_canal;
GO

CREATE TABLE dim_canal (
    id_canal        TINYINT      NOT NULL PRIMARY KEY,
    nombre_canal    NVARCHAR(30) NOT NULL UNIQUE
);
GO

INSERT INTO dim_canal (id_canal, nombre_canal) VALUES
    (1, N'Teléfono'), (2, N'Chat'), (3, N'Correo'), (4, N'Red social');
GO

-- DIM_MOTIVO: motivo de contacto (Informe 3; COBRO/QUEJA unificados)
IF OBJECT_ID('dbo.dim_motivo', 'U') IS NOT NULL DROP TABLE dbo.dim_motivo;
GO

CREATE TABLE dim_motivo (
    id_motivo       TINYINT      NOT NULL PRIMARY KEY,
    nombre_motivo   NVARCHAR(30) NOT NULL UNIQUE
);
GO

INSERT INTO dim_motivo (id_motivo, nombre_motivo) VALUES
    (1, N'Consulta'), (2, N'Falla'), (3, N'Cobro'), (4, N'Solicitud'), (5, N'Queja');
GO

-- DIM_COLA: cola de servicio a la que se asignó (Informe 4)
IF OBJECT_ID('dbo.dim_cola', 'U') IS NOT NULL DROP TABLE dbo.dim_cola;
GO

CREATE TABLE dim_cola (
    id_cola         TINYINT      NOT NULL PRIMARY KEY,
    nombre_cola     NVARCHAR(30) NOT NULL UNIQUE
);
GO

INSERT INTO dim_cola (id_cola, nombre_cola) VALUES
    (1, N'Facturación'), (2, N'Soporte'), (3, N'Información'), (4, N'Reclamos'), (5, N'Trámites');
GO

-- DIM_TIPO_USUARIO: segmento del ciudadano
IF OBJECT_ID('dbo.dim_tipo_usuario', 'U') IS NOT NULL DROP TABLE dbo.dim_tipo_usuario;
GO

CREATE TABLE dim_tipo_usuario (
    id_tipo_usuario         TINYINT      NOT NULL PRIMARY KEY,
    nombre_tipo_usuario     NVARCHAR(30) NOT NULL UNIQUE
);
GO

INSERT INTO dim_tipo_usuario (id_tipo_usuario, nombre_tipo_usuario) VALUES
    (1, N'Nuevo'), (2, N'Recurrente'), (3, N'Empresa'), (4, N'Adulto mayor');
GO

-- DIM_TURNO: bloque horario (dimension del KPI Volumen por turno)
IF OBJECT_ID('dbo.dim_turno', 'U') IS NOT NULL DROP TABLE dbo.dim_turno;
GO

CREATE TABLE dim_turno (
    id_turno        TINYINT       NOT NULL PRIMARY KEY,
    nombre_turno    NVARCHAR(30)  NOT NULL UNIQUE,
    descripcion     NVARCHAR(100) NOT NULL
);
GO

INSERT INTO dim_turno (id_turno, nombre_turno, descripcion) VALUES
    (1, N'AM',            N'Lunes a viernes, 06:00 a 11:59'),
    (2, N'PM',            N'Lunes a viernes, 12:00 a 17:59'),
    (3, N'Nocturno',      N'Lunes a viernes, 18:00 a 05:59'),
    (4, N'Fin de semana', N'Sábado y domingo, todo el día');
GO

-- DIM_SISTEMA_ORIGEN: linaje (inventario de fuentes del expediente)
IF OBJECT_ID('dbo.dim_sistema_origen', 'U') IS NOT NULL DROP TABLE dbo.dim_sistema_origen;
GO

CREATE TABLE dim_sistema_origen (
    id_sistema_origen   TINYINT       NOT NULL PRIMARY KEY,
    nombre_sistema      NVARCHAR(30)  NOT NULL UNIQUE,
    responsable         NVARCHAR(60)  NOT NULL,
    formato             NVARCHAR(40)  NOT NULL,
    actualizacion       NVARCHAR(40)  NOT NULL
);
GO

INSERT INTO dim_sistema_origen (id_sistema_origen, nombre_sistema, responsable, formato, actualizacion) VALUES
    (1, N'ACD',       N'Operaciones',          N'Base SQL / vista', N'Diaria'),
    (2, N'CRM',       N'Gerencia de Servicio', N'API / eventos',    N'Casi en tiempo real'),
    (3, N'Ticketing', N'Operaciones',          N'Archivo XLSX',     N'Semanal'),
    (4, N'Calidad',   N'Calidad',              N'CSV exportado',    N'Mensual');
GO

-- ============================================================
-- 3. ZONA DE PREPARACIÓN (staging con datos sucios)
-- ============================================================

-- DQ_LOTE: un registro por corrida del generador (trazabilidad del origen)
IF OBJECT_ID('dbo.dq_lote', 'U') IS NOT NULL DROP TABLE dbo.dq_lote;
GO

CREATE TABLE dq_lote (
    id_lote             INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    fecha_ejecucion     DATETIME2         NOT NULL DEFAULT SYSDATETIME(),
    origen              NVARCHAR(100)     NOT NULL,
    registros_semilla   INT               NOT NULL,     -- registros del dataset v0 (360)
    registros_generados INT               NOT NULL,     -- registros que generó el algoritmo
    semilla_aleatoria   INT               NOT NULL
);
GO

-- STG_INTERACCION_CRUDA: datos "sucios" tal como llegan de ACD/CRM/Ticketing/Calidad
IF OBJECT_ID('dbo.stg_interaccion_cruda', 'U') IS NOT NULL DROP TABLE dbo.stg_interaccion_cruda;
GO

CREATE TABLE stg_interaccion_cruda (
    id_registro_crudo      BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    id_lote                INT          NOT NULL REFERENCES dbo.dq_lote (id_lote),
    fila_origen            INT          NOT NULL,
    id_interaccion         VARCHAR(20)  NULL,
    fecha_contacto         DATE         NULL,
    hora_contacto          INT          NULL,
    canal                  NVARCHAR(40) NULL,
    motivo_contacto        NVARCHAR(40) NULL,
    cola_servicio          NVARCHAR(40) NULL,
    tipo_usuario           NVARCHAR(40) NULL,
    turno                  NVARCHAR(40) NULL,
    sistema_origen         NVARCHAR(40) NULL,
    duracion_seg           INT          NULL,
    espera_seg             INT          NULL,
    transferencias         INT          NULL,
    casos_previos_30d      INT          NULL,
    grabacion_autorizada   INT          NULL,
    recontacto_7_dias      INT          NULL,
    fecha_carga            DATE         NULL
);
GO

CREATE INDEX ix_stg_lote ON stg_interaccion_cruda (id_lote);
CREATE INDEX ix_stg_interaccion ON stg_interaccion_cruda (id_interaccion);
GO

-- ============================================================
-- 4. TABLA DE HECHOS
-- ============================================================

IF OBJECT_ID('dbo.hecho_interaccion', 'U') IS NOT NULL DROP TABLE dbo.hecho_interaccion;
GO

CREATE TABLE hecho_interaccion (
    id_interaccion       VARCHAR(20) NOT NULL PRIMARY KEY,   -- clave seudonimizada
    id_lote              INT         NOT NULL REFERENCES dbo.dq_lote (id_lote),
    id_registro_crudo    BIGINT      NOT NULL REFERENCES dbo.stg_interaccion_cruda (id_registro_crudo),
    id_tiempo            INT         NOT NULL REFERENCES dbo.dim_tiempo (id_tiempo),      -- fecha_contacto
    id_tiempo_carga      INT         NOT NULL REFERENCES dbo.dim_tiempo (id_tiempo),      -- fecha_carga
    hora_contacto        TINYINT     NOT NULL CHECK (hora_contacto BETWEEN 0 AND 23),
    id_canal             TINYINT     NOT NULL REFERENCES dbo.dim_canal (id_canal),
    id_motivo            TINYINT     NOT NULL REFERENCES dbo.dim_motivo (id_motivo),
    id_cola              TINYINT     NOT NULL REFERENCES dbo.dim_cola (id_cola),
    id_tipo_usuario      TINYINT     NOT NULL REFERENCES dbo.dim_tipo_usuario (id_tipo_usuario),
    id_turno             TINYINT     NOT NULL REFERENCES dbo.dim_turno (id_turno),
    id_sistema_origen    TINYINT     NOT NULL REFERENCES dbo.dim_sistema_origen (id_sistema_origen),
    duracion_seg         INT         NOT NULL CHECK (duracion_seg BETWEEN 30 AND 1800),
    espera_seg           INT         NOT NULL CHECK (espera_seg BETWEEN 0 AND 900),
    transferencias       TINYINT     NOT NULL CHECK (transferencias BETWEEN 0 AND 4),
    casos_previos_30d    TINYINT     NOT NULL CHECK (casos_previos_30d BETWEEN 0 AND 8),
    grabacion_autorizada BIT         NULL,     -- NULL = bandera de gobierno no consolidada
    -- 1 = volvió a contactar por el mismo motivo en 7 días; 0 = no;
    -- NULL = no consolidado (la ventana de 7 días aún no cierra)
    recontacto_7_dias    TINYINT     NULL CHECK (recontacto_7_dias IN (0, 1))
);
GO

CREATE INDEX ix_hecho_tiempo ON hecho_interaccion (id_tiempo);
CREATE INDEX ix_hecho_canal ON hecho_interaccion (id_canal);
CREATE INDEX ix_hecho_motivo ON hecho_interaccion (id_motivo);
CREATE INDEX ix_hecho_cola ON hecho_interaccion (id_cola);
CREATE INDEX ix_hecho_turno ON hecho_interaccion (id_turno);
GO

-- ============================================================
-- 5. VISTAS
-- ============================================================

-- Vista con nombres: es la base de los datasets y de los KPI
CREATE OR ALTER VIEW dbo.vw_interaccion AS
SELECT
    h.id_interaccion,
    t.fecha                 AS fecha_contacto,
    t.anio, t.mes, t.dia_semana, t.es_fin_de_semana,
    h.hora_contacto,
    c.nombre_canal          AS canal,
    m.nombre_motivo         AS motivo_contacto,
    q.nombre_cola           AS cola_servicio,
    u.nombre_tipo_usuario   AS tipo_usuario,
    tu.nombre_turno         AS turno,
    s.nombre_sistema        AS sistema_origen,
    h.duracion_seg,
    h.espera_seg,
    h.transferencias,
    h.casos_previos_30d,
    h.grabacion_autorizada,
    h.recontacto_7_dias,
    tc.fecha                AS fecha_carga,
    h.id_lote,
    h.id_registro_crudo
FROM dbo.hecho_interaccion h
JOIN dbo.dim_tiempo         t  ON t.id_tiempo  = h.id_tiempo
JOIN dbo.dim_tiempo         tc ON tc.id_tiempo = h.id_tiempo_carga
JOIN dbo.dim_canal          c  ON c.id_canal   = h.id_canal
JOIN dbo.dim_motivo         m  ON m.id_motivo  = h.id_motivo
JOIN dbo.dim_cola           q  ON q.id_cola    = h.id_cola
JOIN dbo.dim_tipo_usuario   u  ON u.id_tipo_usuario = h.id_tipo_usuario
JOIN dbo.dim_turno          tu ON tu.id_turno  = h.id_turno
JOIN dbo.dim_sistema_origen s  ON s.id_sistema_origen = h.id_sistema_origen;
GO

-- Trazabilidad inversa: del DW al registro original en la zona de preparación
CREATE OR ALTER VIEW dbo.vw_traza_inversa AS
SELECT
    h.id_interaccion,
    h.id_lote,
    h.id_registro_crudo,
    l.fecha_ejecucion       AS fecha_generacion_lote,
    l.origen                AS origen_lote,
    s.fila_origen,
    s.motivo_contacto       AS motivo_raw,
    m.nombre_motivo         AS motivo_dw,
    CASE WHEN s.motivo_contacto COLLATE Latin1_General_BIN <> m.nombre_motivo COLLATE Latin1_General_BIN
         THEN 1 ELSE 0 END  AS motivo_fue_corregido
FROM dbo.hecho_interaccion h
JOIN dbo.stg_interaccion_cruda s ON s.id_registro_crudo = h.id_registro_crudo
JOIN dbo.dq_lote               l ON l.id_lote = h.id_lote
JOIN dbo.dim_motivo            m ON m.id_motivo = h.id_motivo;
GO

PRINT 'Data Warehouse ServicioCiudadano1800DW creado exitosamente.';
GO
