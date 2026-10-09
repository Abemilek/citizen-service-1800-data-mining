-- ============================================================
-- SERVICIO CIUDADANO 1800 - DATA MINING (CASO 15)
-- Dataset v0: RECONTACTO A 7 DÍAS sobre los datos SUCIOS
-- (zona de preparación stg_interaccion_cruda, tal como llegaron)
--
-- Este dataset conserva los defectos de calidad de la semilla:
--   * duplicados (mismo id_interaccion)
--   * canal vacío / motivo en mayúsculas (COBRO, QUEJA)
--   * valores fuera de rango en las medidas
--   * recontacto_7_dias no consolidado (se excluye: no se puede entrenar sin target)
--
-- Sirve para el notebook 03_modelado.ipynb (modelo inicial) y para comparar
-- contra el dataset CORREGIDO (03_dataset_recontacto_limpio.sql). No hay fuga de datos:
-- todas las variables se conocen al cierre de la interacción.
-- ============================================================

IF OBJECT_ID(N'dbo.dm_dataset_recontacto', N'U') IS NOT NULL
    DROP TABLE dbo.dm_dataset_recontacto;
GO

SELECT
    v.id_interaccion,                                   -- solo trazabilidad
    v.fecha_contacto,                                   -- solo validación temporal

    -- Variable objetivo (target)
    CAST(v.recontacto_7_dias AS INT)                                   AS recontacto_7_dias,

    -- Canal (referencia: Teléfono). Si el canal está vacío no enciende ninguna bandera
    CASE WHEN v.canal = N'Chat'       THEN 1 ELSE 0 END               AS es_canal_chat,
    CASE WHEN v.canal = N'Correo'     THEN 1 ELSE 0 END               AS es_canal_correo,
    CASE WHEN v.canal = N'Red social' THEN 1 ELSE 0 END               AS es_canal_red_social,

    -- Motivo de contacto (referencia: Consulta). COBRO/QUEJA no encienden bandera (dato sucio).
    -- Se usa collation BIN para que 'COBRO' NO coincida con 'Cobro' (SQL Server es case-insensitive por defecto).
    CASE WHEN v.motivo_contacto COLLATE Latin1_General_BIN = N'Falla'     THEN 1 ELSE 0 END AS es_motivo_falla,
    CASE WHEN v.motivo_contacto COLLATE Latin1_General_BIN = N'Cobro'     THEN 1 ELSE 0 END AS es_motivo_cobro,
    CASE WHEN v.motivo_contacto COLLATE Latin1_General_BIN = N'Solicitud' THEN 1 ELSE 0 END AS es_motivo_solicitud,
    CASE WHEN v.motivo_contacto COLLATE Latin1_General_BIN = N'Queja'     THEN 1 ELSE 0 END AS es_motivo_queja,

    -- Cola de servicio (referencia: Información)
    CASE WHEN v.cola_servicio = N'Facturación' THEN 1 ELSE 0 END      AS es_cola_facturacion,
    CASE WHEN v.cola_servicio = N'Soporte'     THEN 1 ELSE 0 END      AS es_cola_soporte,
    CASE WHEN v.cola_servicio = N'Reclamos'    THEN 1 ELSE 0 END      AS es_cola_reclamos,
    CASE WHEN v.cola_servicio = N'Trámites'    THEN 1 ELSE 0 END      AS es_cola_tramites,

    -- Tipo de usuario (referencia: Recurrente)
    CASE WHEN v.tipo_usuario = N'Nuevo'        THEN 1 ELSE 0 END      AS es_usuario_nuevo,
    CASE WHEN v.tipo_usuario = N'Empresa'      THEN 1 ELSE 0 END      AS es_usuario_empresa,
    CASE WHEN v.tipo_usuario = N'Adulto mayor' THEN 1 ELSE 0 END      AS es_usuario_adulto_mayor,

    -- Medidas operativas (en el dataset sucio conservan valores fuera de rango)
    v.duracion_seg,
    v.espera_seg,
    v.transferencias,
    v.casos_previos_30d,

    -- Banderas derivadas
    CASE WHEN v.transferencias > 0     THEN 1 ELSE 0 END              AS tuvo_transferencia,
    CASE WHEN v.espera_seg >= 300      THEN 1 ELSE 0 END              AS espera_larga,
    CASE WHEN v.casos_previos_30d >= 2 THEN 1 ELSE 0 END              AS tiene_casos_previos,

    -- Tiempo
    v.hora_contacto,
    dt.mes,
    dt.dia_semana,                                                     -- 1 = lunes ... 7 = domingo
    CAST(dt.es_fin_de_semana AS INT)                                  AS es_fin_de_semana,
    CASE WHEN v.hora_contacto >= 22 OR v.hora_contacto < 6 THEN 1 ELSE 0 END AS es_horario_nocturno
INTO dbo.dm_dataset_recontacto
FROM dbo.stg_interaccion_cruda AS v
LEFT JOIN dbo.dim_tiempo AS dt ON dt.fecha = v.fecha_contacto
WHERE v.recontacto_7_dias IS NOT NULL
  AND v.id_lote = (SELECT MAX(id_lote) FROM dbo.dq_lote);           -- solo la última corrida
GO

-- Verificación del dataset v0 (sucio)
SELECT
    COUNT(*)                                                           AS filas,
    SUM(recontacto_7_dias)                                             AS positivos,
    CAST(100.0 * SUM(recontacto_7_dias) / COUNT(*) AS DECIMAL(5,2))    AS pct_objetivo
FROM dbo.dm_dataset_recontacto;
GO
