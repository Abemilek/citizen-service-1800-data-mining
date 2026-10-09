# ============================================
# test_conexion.py
# Prueba rápida de conexión a SQL Server
# SERVICIO CIUDADANO 1800 (CASO 15)
# ============================================

import os
import sys

sys.path.insert(0, os.path.dirname(os.path.abspath(__file__)))

from src.database import test_connection, execute_query

if __name__ == "__main__":
    # Prueba 1: Conexión básica
    print("\n🔌 PRUEBA 1: Conexión al servidor")
    test_connection()

    # Prueba 2: Conteo de registros en las tablas del DW
    print("\n\n📊 PRUEBA 2: Conteo de registros en tablas del DW")
    tablas = ['hecho_interaccion', 'stg_interaccion_cruda', 'dq_lote', 'dim_tiempo']

    for tabla in tablas:
        df = execute_query(f"SELECT COUNT(*) AS total FROM dbo.{tabla};")
        if df is not None:
            print(f"   📋 {tabla}: {df['total'][0]:,} registros")

    # Prueba 3: Verificar datasets de minería
    print("\n\n🤖 PRUEBA 3: Datasets de minería de datos")
    datasets = ['dm_dataset_recontacto', 'dm_dataset_recontacto_correcto']

    for ds in datasets:
        df = execute_query(f"SELECT COUNT(*) AS total FROM dbo.{ds};")
        if df is not None:
            print(f"   🤖 {ds}: {df['total'][0]:,} registros")
        else:
            print(f"   ⚠️ {ds}: No existe aún. Ejecuta los scripts SQL primero.")

    # Prueba 4: KPI
    print("\n\n📈 PRUEBA 4: KPI del caso")
    try:
        kpi = execute_query("SELECT * FROM dbo.vw_kpi_tr7_global;")
        print(kpi.to_string(index=False))
    except Exception as exc:  # noqa: BLE001
        print(f"   ⚠️ KPI no disponibles: {exc}")
