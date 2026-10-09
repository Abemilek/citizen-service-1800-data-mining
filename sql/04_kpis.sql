-- ============================================================
-- SERVICIO CIUDADANO 1800 - KPIS DEL CASO 15
-- Este script crea las VISTAS de los 3 indicadores del caso y una
-- vista de calidad ANTES/DESPUÉS del MINI ETL (evidencia).
--
-- Tabla de hechos: hecho_interaccion   (grano = 1 fila por interacción)
-- Medidas: recontacto_7_dias, duracion_seg, espera_seg, transferencias, casos_previos_30d
-- Dimensiones: Tiempo, Canal, Motivo, Cola, Turno, Tipo de usuario, Sistema de origen
-- ============================================================

-- ============================================================
-- KPI 1: DURACIÓN PROMEDIO DE INTERACCIÓN POR CANAL
-- Hecho: hecho_interaccion | Medida: duracion_seg | Dimensión: canal
-- Fórmula: suma(duracion_seg del canal X) / cantidad(interacciones del canal X)
-- Qué mide: cuánto tiempo promedio consume cada canal; sirve para mover
-- personal o simplificar el canal que se está llevando más tiempo de agente.
-- ============================================================
CREATE OR ALTER VIEW dbo.vw_kpi_duracion_canal AS
SELECT
    i.canal,
    COUNT(*)                                                AS interacciones,
    CAST(AVG(CAST(i.duracion_seg AS FLOAT)) AS DECIMAL(10,1)) AS duracion_promedio_seg,
    CAST(AVG(CAST(i.duracion_seg AS FLOAT)) / 60.0 AS DECIMAL(10,2)) AS duracion_promedio_min,
    CAST(100.0 * COUNT(*) / SUM(COUNT(*)) OVER () AS DECIMAL(5,2))   AS pct_del_total
FROM dbo.vw_interaccion AS i
GROUP BY i.canal;
GO

-- ============================================================
-- KPI 2: TASA DE RECONTACTO A 7 DÍAS (TR7)
-- Hecho: hecho_interaccion | Medida: recontacto_7_dias | Dimensión: Tiempo
-- Fórmula: interacciones con recontacto_7_dias = 1 / total con resultado consolidado * 100
-- Qué mide: % de ciudadanos que vuelven a contactar por el mismo motivo dentro de 7 días.
-- Meta del caso: bajar del 41.13% actual a 22% o menos.
-- ============================================================
CREATE OR ALTER VIEW dbo.vw_kpi_tr7_global AS
SELECT
    COUNT(*)                                                             AS interacciones_consolidadas,
    SUM(CAST(i.recontacto_7_dias AS INT))                                AS recontactos,
    CAST(100.0 * SUM(CAST(i.recontacto_7_dias AS INT)) / COUNT(*) AS DECIMAL(5,2)) AS tr7_pct,
    CAST(22.0 AS DECIMAL(5,2))                                           AS meta_pct
FROM dbo.vw_interaccion AS i
WHERE i.recontacto_7_dias IS NOT NULL;
GO

-- Misma medida cortada por la dimensión Tiempo (ventana mensual de 7 días)
CREATE OR ALTER VIEW dbo.vw_kpi_tr7_mensual AS
SELECT
    i.anio,
    i.mes,
    COUNT(*)                                                             AS interacciones_consolidadas,
    SUM(CAST(i.recontacto_7_dias AS INT))                                AS recontactos,
    CAST(100.0 * SUM(CAST(i.recontacto_7_dias AS INT)) / COUNT(*) AS DECIMAL(5,2)) AS tr7_pct
FROM dbo.vw_interaccion AS i
WHERE i.recontacto_7_dias IS NOT NULL
GROUP BY i.anio, i.mes;
GO

-- ============================================================
-- KPI 3: VOLUMEN DE INTERACCIONES POR TURNO
-- Hecho: hecho_interaccion | Medida: conteo (COUNT) | Dimensión: turno
-- Fórmula: COUNT(hecho_interaccion) agrupado por turno
-- Qué mide: la carga de trabajo real de cada turno (indicador leading de capacidad;
-- no mide calidad de resolución). Sirve para dimensionar personal y horarios.
-- ============================================================
CREATE OR ALTER VIEW dbo.vw_kpi_volumen_turno AS
SELECT
    i.turno,
    COUNT(*)                                                        AS interacciones,
    CAST(100.0 * COUNT(*) / SUM(COUNT(*)) OVER () AS DECIMAL(5,2))  AS pct_del_total
FROM dbo.vw_interaccion AS i
GROUP BY i.turno;
GO

-- ============================================================
-- EVIDENCIA DE CALIDAD: ANTES (staging sucio) vs DESPUÉS (DW limpio)
-- Demuestra que el MINI ETL del generador C# hizo su trabajo.
-- ============================================================
CREATE OR ALTER VIEW dbo.vw_calidad_antes_despues AS
SELECT
    (SELECT COUNT(*) FROM dbo.stg_interaccion_cruda
      WHERE id_lote = (SELECT MAX(id_lote) FROM dbo.dq_lote))                       AS staging_registros,
    (SELECT COUNT(*) FROM dbo.hecho_interaccion
      WHERE id_lote = (SELECT MAX(id_lote) FROM dbo.dq_lote))                       AS dw_registros,
    (SELECT COUNT(*) FROM (
        SELECT id_interaccion FROM dbo.stg_interaccion_cruda
        WHERE id_lote = (SELECT MAX(id_lote) FROM dbo.dq_lote)
        GROUP BY id_interaccion HAVING COUNT(*) > 1) AS d)                          AS duplicados,
    (SELECT COUNT(*) FROM dbo.stg_interaccion_cruda
      WHERE id_lote = (SELECT MAX(id_lote) FROM dbo.dq_lote)
        AND (canal IS NULL OR LTRIM(RTRIM(canal)) = ''))                            AS canal_vacio,
    (SELECT COUNT(*) FROM dbo.stg_interaccion_cruda
      WHERE id_lote = (SELECT MAX(id_lote) FROM dbo.dq_lote)
        AND (duracion_seg NOT BETWEEN 30 AND 1800 OR espera_seg NOT BETWEEN 0 AND 900
             OR transferencias NOT BETWEEN 0 AND 4 OR casos_previos_30d NOT BETWEEN 0 AND 8)) AS fuera_de_rango,
    (SELECT COUNT(*) FROM dbo.stg_interaccion_cruda
      WHERE id_lote = (SELECT MAX(id_lote) FROM dbo.dq_lote)
        AND motivo_contacto COLLATE Latin1_General_BIN IN (N'COBRO', N'QUEJA'))      AS motivo_sin_normalizar,
    (SELECT COUNT(*) FROM dbo.stg_interaccion_cruda
      WHERE id_lote = (SELECT MAX(id_lote) FROM dbo.dq_lote)
        AND recontacto_7_dias IS NULL)                                              AS recontacto_no_consolidado;
GO

-- ============================================================
-- RESUMEN: ejecutar después de cargar los datos para ver los KPI
-- ============================================================
SELECT 'KPI 1 - Duración promedio por canal' AS kpi;
SELECT * FROM dbo.vw_kpi_duracion_canal ORDER BY duracion_promedio_seg DESC;
GO

SELECT 'KPI 2 - Tasa de recontacto a 7 días (global)' AS kpi;
SELECT * FROM dbo.vw_kpi_tr7_global;
GO

SELECT 'KPI 3 - Volumen por turno' AS kpi;
SELECT * FROM dbo.vw_kpi_volumen_turno ORDER BY interacciones DESC;
GO

SELECT 'Evidencia de calidad ANTES vs DESPUÉS del MINI ETL' AS evidencia;
SELECT * FROM dbo.vw_calidad_antes_despues;
GO
