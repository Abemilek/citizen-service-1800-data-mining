-- ============================================================
-- SERVICIO CIUDADANO 1800 - DATA WAREHOUSE
-- Script de creación de base de datos y tablas
-- Autor: Equipo de Analítica (Adaptación Caso 15)
-- ============================================================

-- 1. CREAR BASE DE DATOS
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'ServicioCiudadanoDW')
BEGIN
    CREATE DATABASE ServicioCiudadanoDW;
END
GO

USE ServicioCiudadanoDW;
GO

-- ============================================================
-- 2. TABLA CRUDA (v0_crudo)
-- ============================================================
IF OBJECT_ID('dbo.v0_crudo', 'U') IS NOT NULL DROP TABLE dbo.v0_crudo;
GO

CREATE TABLE v0_crudo (
    id_interaccion          VARCHAR(50) NOT NULL,
    fecha_contacto          DATETIME NOT NULL,
    fecha_carga             DATETIME DEFAULT GETDATE(),
    canal                   VARCHAR(50),
    motivo_contacto         VARCHAR(100),
    cola_servicio           VARCHAR(100),
    duracion_seg            INT,
    espera_seg              INT,
    grabacion_autorizada    VARCHAR(10),
    recontacto_7_dias       VARCHAR(10), -- Puede venir nulo o sucio
    casos_previos_30d       INT,
    nivel_transferencias    INT,
    tipo_usuario            VARCHAR(50)
);
GO

PRINT 'Data Warehouse ServicioCiudadanoDW creado exitosamente con la tabla v0_crudo.';
GO