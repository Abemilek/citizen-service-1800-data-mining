-- ============================================================
-- citizen NICARAGUA - DATA MINING
-- Dataset CORREGIDO: SIN Data Leakage (Variables congeladas en el tiempo)
-- PROYECTO A: Reducir TAR de 66% a 50%
-- COMPATIBLE CON: SQL Server 2016+
-- ============================================================

-- PASO 1: Eliminar tabla si ya existe para permitir re-ejecución
DROP TABLE IF EXISTS dbo.dm_dataset_abandono_correcto;
GO

-- PASO 2: Crear el dataset con variables calculadas SOLO con información 
-- disponible ANTES del momento de la reserva (sin mirar al futuro)
SELECT
    -- === IDENTIFICADORES ===
    r.id_reserva,
    r.id_cliente,

    -- === VARIABLE TARGET (Y) ===
    CASE
        WHEN r.estado_reserva = 'abandonada' THEN 1
        WHEN r.estado_reserva = 'pagada'     THEN 0
        ELSE NULL
    END AS es_abandono,

    -- === GRUPO A1: VARIABLES TEMPORALES ===
    DATEPART(HOUR, r.fecha_inicio_reserva) AS hora_inicio,
    
    CASE
        WHEN DATEPART(HOUR, r.fecha_inicio_reserva) BETWEEN 22 AND 23
          OR DATEPART(HOUR, r.fecha_inicio_reserva) BETWEEN 0 AND 5
        THEN 1 ELSE 0
    END AS es_horario_nocturno,
    
    DATEPART(WEEKDAY, r.fecha_inicio_reserva) AS dia_semana,
    
    CASE
        WHEN DATENAME(WEEKDAY, r.fecha_inicio_reserva) IN ('Saturday', 'Sunday', 'Sábado', 'Domingo')
        THEN 1 ELSE 0
    END AS es_fin_semana,
    
    dt.es_temporada_alta,

    -- === GRUPO A2: COMPORTAMIENTO DE SESIÓN ===
    ISNULL(ipf.intentos_pago_fallidos, 0) AS intentos_pago_fallidos,

    COUNT(*) OVER (
        PARTITION BY r.id_cliente, 
                     CAST(r.fecha_inicio_reserva AS DATE)
    ) AS reservas_mismo_dia,

    -- === GRUPO A3: CONTEXTO DE COMPRA ===
    CASE WHEN r.id_canal = 1      THEN 1 ELSE 0 END AS es_app_movil,
    CASE WHEN r.id_canal = 2      THEN 1 ELSE 0 END AS es_web_desktop,
    CASE WHEN r.id_canal = 3 THEN 1 ELSE 0 END AS es_sucursal,
    
    CASE WHEN r.tipo_vuelo = 'internacional' THEN 1 ELSE 0 END AS es_internacional,
    
    CASE WHEN r.ruta = 'MGA-MIA' THEN 1 ELSE 0 END AS es_ruta_MGA_MIA,
    
    CASE WHEN r.ruta IN ('MGA-MIA','MGA-GUA','MGA-SJO','MGA-MEX','MGA-PTY')
         THEN 1 ELSE 0
    END AS es_ruta_top5,
    
    r.precio_cotizado,
    
    CASE 
        WHEN pr.precio_promedio_ruta > 0 
        THEN r.precio_cotizado / pr.precio_promedio_ruta
        ELSE NULL 
    END AS precio_vs_promedio_ruta,
    
    CASE
        WHEN r.tipo_vuelo = 'internacional'
         AND r.precio_cotizado > 500
        THEN 1 ELSE 0
    END AS es_precio_alto_intl,

    -- === GRUPO A4: PERFIL DEL CLIENTE (CORREGIDO: SIN DATA LEAKAGE) ===
    
    -- 1. Antigüedad calculada al momento EXACTO de la reserva
    DATEDIFF(DAY, c.fecha_registro, r.fecha_inicio_reserva) AS antiguedad_cliente_dias,
    
    CASE 
        WHEN DATEDIFF(DAY, c.fecha_registro, r.fecha_inicio_reserva) < 90 
        THEN 1 ELSE 0 
    END AS es_cliente_nuevo,
    
    -- 2. COMPRAS PREVIAS: Solo cuenta reservas pagadas ANTERIORES a esta reserva
    (SELECT COUNT(*)
     FROM hecho_reserva hr
     WHERE hr.id_cliente = r.id_cliente
       AND hr.estado_reserva = 'pagada'
       AND hr.fecha_inicio_reserva < r.fecha_inicio_reserva  -- CLAVE: Solo pasado
       AND hr.fecha_inicio_reserva >= DATEADD(month, -12, r.fecha_inicio_reserva)
    ) AS compras_previas_12m_real,
    
    -- 3. MONTO TOTAL: Solo suma pagos realizados ANTERIORES a esta reserva
    (SELECT ISNULL(SUM(hp.monto_pagado), 0)
     FROM hecho_pago hp
     INNER JOIN hecho_reserva hr ON hp.id_reserva = hr.id_reserva
     WHERE hr.id_cliente = r.id_cliente
       AND hr.estado_reserva = 'pagada'
       AND hp.fecha_pago < r.fecha_inicio_reserva  -- CLAVE: Solo pasado
       AND hp.fecha_pago >= DATEADD(month, -12, r.fecha_inicio_reserva)
    ) AS monto_total_12m_real,
    
    c.segmento_cliente,
    
    CASE WHEN c.segmento_cliente = 'Ocasional Promo' THEN 1 ELSE 0 END AS es_ocasional_promo,
    CASE WHEN c.segmento_cliente = 'Estudiantes'     THEN 1 ELSE 0 END AS es_estudiante,

    -- === VARIABLE DE CONTROL ===
    r.fecha_inicio_reserva

INTO dbo.dm_dataset_abandono_correcto

FROM hecho_reserva r
    INNER JOIN dim_cliente c 
        ON r.id_cliente = c.id_cliente
    LEFT JOIN dim_tiempo dt 
        ON CAST(r.fecha_inicio_reserva AS DATE) = dt.fecha
    
    -- Subconsulta optimizada: Precio promedio por ruta
    LEFT JOIN (
        SELECT 
            ruta,
            AVG(CAST(precio_cotizado AS FLOAT)) AS precio_promedio_ruta
        FROM hecho_reserva
        WHERE estado_reserva = 'pagada'
        GROUP BY ruta
    ) pr ON r.ruta = pr.ruta
    
    -- Subconsulta optimizada: Intentos de pago fallidos
    LEFT JOIN (
        SELECT 
            id_reserva,
            COUNT(*) AS intentos_pago_fallidos
        FROM hecho_pago
        WHERE estado_pago = 'rechazado'
        GROUP BY id_reserva
    ) ipf ON r.id_reserva = ipf.id_reserva

WHERE r.estado_reserva IN ('pagada', 'abandonada')
  AND r.fecha_inicio_reserva >= '2024-01-01'
  AND r.fecha_inicio_reserva <  '2025-07-01';
GO

-- PASO 3: Verificación final del dataset creado
SELECT 
    COUNT(*) AS total_registros,
    SUM(es_abandono) AS total_abandonos,
    COUNT(*) - SUM(es_abandono) AS total_pagadas,
    ROUND(SUM(es_abandono) * 100.0 / COUNT(*), 2) AS pct_abandono,
    AVG(compras_previas_12m_real) AS promedio_compras_previas,
    AVG(monto_total_12m_real) AS promedio_monto_previo
FROM dbo.dm_dataset_abandono_correcto;
GO