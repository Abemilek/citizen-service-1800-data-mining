-- ============================================================
-- SERVICIO CIUDADANO 1800 - DATA MINING (CASO 15)
-- Dataset v1 CORREGIDO: RECONTACTO A 7 DÍAS sobre datos LIMPIOS
-- (Data Warehouse hecho_interaccion, después del MINI ETL)
--
-- Reglas que garantizan un dataset de minería sano:
--   * Sin duplicados (los quitó el MINI ETL: R-UNI-01).
--   * Etiquetas estandarizadas (COBRO -> Cobro, QUEJA -> Queja: R-EST-01).
--   * Medidas dentro de rango (30-1800, 0-900, 0-4, 0-8: R-VAL-01).
--   * Solo filas con resultado consolidado (recontacto_7_dias NOT NULL).
--   * SIN FUGA DE DATOS: ninguna variable usa información posterior al cierre
--     de la interacción; se excluyen id_interaccion, fechas, sistema_origen y
--     grabacion_autorizada (identificadores, linaje y gobierno).
--   * Categorías de referencia: canal=Teléfono, motivo=Consulta,
--     cola=Información, usuario=Recurrente.
-- ============================================================

IF OBJECT_ID(N'dbo.dm_dataset_recontacto_correcto', N'U') IS NOT NULL
    DROP TABLE dbo.dm_dataset_recontacto_correcto;
GO

SELECT
    v.id_interaccion,                                   -- solo trazabilidad
    v.fecha_contacto,                                   -- solo validación temporal

    -- Variable objetivo (target)
    CAST(v.recontacto_7_dias AS INT)                                   AS recontacto_7_dias,

    -- Canal (referencia: Teléfono)
    CASE WHEN v.canal = N'Chat'       THEN 1 ELSE 0 END               AS es_canal_chat,
    CASE WHEN v.canal = N'Correo'     THEN 1 ELSE 0 END               AS es_canal_correo,
    CASE WHEN v.canal = N'Red social' THEN 1 ELSE 0 END               AS es_canal_red_social,

    -- Motivo de contacto (referencia: Consulta)
    CASE WHEN v.motivo_contacto = N'Falla'     THEN 1 ELSE 0 END      AS es_motivo_falla,
    CASE WHEN v.motivo_contacto = N'Cobro'     THEN 1 ELSE 0 END      AS es_motivo_cobro,
    CASE WHEN v.motivo_contacto = N'Solicitud' THEN 1 ELSE 0 END      AS es_motivo_solicitud,
    CASE WHEN v.motivo_contacto = N'Queja'     THEN 1 ELSE 0 END      AS es_motivo_queja,

    -- Cola de servicio (referencia: Información)
    CASE WHEN v.cola_servicio = N'Facturación' THEN 1 ELSE 0 END      AS es_cola_facturacion,
    CASE WHEN v.cola_servicio = N'Soporte'     THEN 1 ELSE 0 END      AS es_cola_soporte,
    CASE WHEN v.cola_servicio = N'Reclamos'    THEN 1 ELSE 0 END      AS es_cola_reclamos,
    CASE WHEN v.cola_servicio = N'Trámites'    THEN 1 ELSE 0 END      AS es_cola_tramites,

    -- Tipo de usuario (referencia: Recurrente)
    CASE WHEN v.tipo_usuario = N'Nuevo'        THEN 1 ELSE 0 END      AS es_usuario_nuevo,
    CASE WHEN v.tipo_usuario = N'Empresa'      THEN 1 ELSE 0 END      AS es_usuario_empresa,
    CASE WHEN v.tipo_usuario = N'Adulto mayor' THEN 1 ELSE 0 END      AS es_usuario_adulto_mayor,

    -- Medidas operativas (limpias y en rango)
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
    v.mes,
    v.dia_semana,                                                      -- 1 = lunes ... 7 = domingo
    CAST(v.es_fin_de_semana AS INT)                                   AS es_fin_de_semana,
    CASE WHEN v.hora_contacto >= 22 OR v.hora_contacto < 6 THEN 1 ELSE 0 END AS es_horario_nocturno
INTO dbo.dm_dataset_recontacto_correcto
FROM dbo.vw_interaccion AS v
WHERE v.recontacto_7_dias IS NOT NULL
  AND v.id_lote = (SELECT MAX(id_lote) FROM dbo.dq_lote);             -- solo la última corrida
GO

-- Verificación del dataset v1 (limpio)
SELECT
    COUNT(*)                                                           AS filas,
    SUM(recontacto_7_dias)                                             AS positivos,
    CAST(100.0 * SUM(recontacto_7_dias) / COUNT(*) AS DECIMAL(5,2))    AS pct_objetivo
FROM dbo.dm_dataset_recontacto_correcto;
GO
