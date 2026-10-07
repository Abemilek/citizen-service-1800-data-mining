-- ============================================================
-- SERVICIO CIUDADANO 1800 - ETL Y GOBIERNO DE DATOS
-- Limpieza de datos (v1_limpio)
-- ============================================================

USE ServicioCiudadanoDW;
GO

IF OBJECT_ID('vw_v1_limpio', 'V') IS NOT NULL DROP VIEW vw_v1_limpio;
GO

-- Creamos una vista que aplica las reglas de limpieza de forma automatica
CREATE VIEW vw_v1_limpio AS
WITH CTE_Duplicados AS (
    -- R-CAL-04: duplicados exactos por id_interaccion -> eliminar, dejar 1ra ocurrencia
    SELECT *,
           ROW_NUMBER() OVER (PARTITION BY id_interaccion ORDER BY fecha_carga) as rn
    FROM dbo.v0_crudo
)
SELECT 
    id_interaccion,
    fecha_contacto,
    fecha_carga,
    
    -- R-CAL-03: canal "(sin dato)" -> se marca y se excluye del analisis por canal
    CASE 
        WHEN canal = '(sin dato)' OR canal IS NULL THEN 'Sin clasificar' 
        ELSE canal 
    END AS canal,
    
    -- R-CAL-02: normalizar motivo_contacto (mayusculas -> formato estandar)
    CASE 
        WHEN motivo_contacto = 'COBRO' THEN 'Cobro'
        WHEN motivo_contacto = 'QUEJA' THEN 'Queja'
        ELSE motivo_contacto 
    END AS motivo_contacto,
    
    cola_servicio,
    duracion_seg,
    espera_seg,
    
    -- R-PRIV-01: grabacion_autorizada vacio/inconsistente -> se asume "No"
    CASE 
        WHEN grabacion_autorizada IS NULL OR grabacion_autorizada = '' THEN 'No'
        ELSE grabacion_autorizada
    END AS grabacion_autorizada,
    
    -- R-CAL-01: convertimos a INT. Los nulos se filtran en el WHERE.
    CAST(recontacto_7_dias AS INT) AS recontacto_7_dias,
    
    casos_previos_30d,
    nivel_transferencias,
    tipo_usuario,
    
    -- Turno (para KPI 9)
    CASE 
        WHEN DATEPART(HOUR, fecha_contacto) BETWEEN 6 AND 12 THEN 'AM'
        WHEN DATEPART(HOUR, fecha_contacto) BETWEEN 13 AND 19 THEN 'PM'
        ELSE 'Nocturno'
    END AS turno
    
FROM CTE_Duplicados
WHERE 
    rn = 1 -- Filtramos duplicados (R-CAL-04)
    -- R-CAL-05: duracion_seg fuera de rango valido (30-1800) -> descartar
    AND duracion_seg >= 30 AND duracion_seg <= 1800
    -- R-CAL-06: espera_seg fuera de rango valido (0-900) -> descartar
    AND espera_seg >= 0 AND espera_seg <= 900
    -- R-CAL-01: recontacto_7_dias vacio -> eliminar del dataset de modelado
    AND recontacto_7_dias IS NOT NULL AND recontacto_7_dias <> '';
GO

PRINT 'Vista vw_v1_limpio creada exitosamente (Reglas de Gobierno aplicadas).';
GO