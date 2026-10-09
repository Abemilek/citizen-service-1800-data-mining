# ============================================
# cargar_datos.py
# Carga de datasets desde SQL Server a pandas
# SERVICIO CIUDADANO 1800 (CASO 15)
# ============================================

import os
import sys

import pandas as pd

# Asegura que se pueda importar src/ sin importar desde dónde se ejecute
RAIZ = os.path.dirname(os.path.abspath(__file__))
if RAIZ not in sys.path:
    sys.path.insert(0, RAIZ)

from src.database import execute_query  # noqa: E402


def _resumen(df: pd.DataFrame, nombre: str, target: str | None = None) -> pd.DataFrame:
    print(f"\n📏 {nombre}: {df.shape[0]:,} filas × {df.shape[1]} columnas")
    if target and target in df.columns:
        print(f"\n🎯 Distribución de la variable objetivo ({target}):")
        print(df[target].value_counts(dropna=False))
        print(f"\n📈 Tasa de {target}=1: {df[target].mean() * 100:.2f}%")
    return df


# ============================================
# DATASETS DE MINERÍA
# ============================================
def cargar_dataset_recontacto():
    """
    Dataset v0 (SUCIO): dm_dataset_recontacto, construido desde la zona de
    preparación tal como llegaron los datos (con duplicados, etiquetas sin
    normalizar y valores fuera de rango).
    """
    print("=" * 60)
    print("📊 CARGANDO DATASET v0 DE RECONTACTO (SUCIO)")
    print("=" * 60)
    query = """
    SELECT *
    FROM dbo.dm_dataset_recontacto
    ORDER BY fecha_contacto;
    """
    df = execute_query(query)
    return _resumen(df, "Dataset v0 (sucio)", "recontacto_7_dias") if df is not None else None


def cargar_dataset_recontacto_correcto():
    """
    Dataset v1 (LIMPIO): dm_dataset_recontacto_correcto, construido desde el
    Data Warehouse después del MINI ETL (sin duplicados, etiquetas normalizadas
    y medidas en rango). Es el dataset oficial para el modelo.
    """
    print("=" * 60)
    print("📊 CARGANDO DATASET v1 CORREGIDO DE RECONTACTO (LIMPIO)")
    print("=" * 60)
    query = """
    SELECT *
    FROM dbo.dm_dataset_recontacto_correcto
    ORDER BY fecha_contacto;
    """
    df = execute_query(query)
    return _resumen(df, "Dataset v1 (limpio)", "recontacto_7_dias") if df is not None else None


# ============================================
# VISTA GENERAL DEL DATA WAREHOUSE
# ============================================
def cargar_interacciones():
    """
    Todas las interacciones limpias del Data Warehouse (vista vw_interaccion),
    con nombres de dimensiones. Se usa para exploración y KPI.
    """
    print("=" * 60)
    print("📊 CARGANDO INTERACCIONES DEL DATA WAREHOUSE")
    print("=" * 60)
    query = """
    SELECT *
    FROM dbo.vw_interaccion
    WHERE id_lote = (SELECT MAX(id_lote) FROM dbo.dq_lote);
    """
    df = execute_query(query)
    return _resumen(df, "Interacciones (DW)") if df is not None else None


# ============================================
# KPI DEL CASO
# ============================================
def cargar_kpis():
    """
    Devuelve un diccionario con los resultados de los 3 KPI del caso:
      kpi1_duracion_canal : duración promedio por canal
      kpi2_tr7_global     : tasa de recontacto a 7 días
      kpi2_tr7_mensual    : TR7 por mes
      kpi3_volumen_turno  : volumen de interacciones por turno
      calidad             : evidencia ANTES vs DESPUÉS del MINI ETL
    """
    print("=" * 60)
    print("📊 CARGANDO KPI DEL CASO 15")
    print("=" * 60)
    return {
        "kpi1_duracion_canal": execute_query("SELECT * FROM dbo.vw_kpi_duracion_canal ORDER BY duracion_promedio_seg DESC;"),
        "kpi2_tr7_global": execute_query("SELECT * FROM dbo.vw_kpi_tr7_global;"),
        "kpi2_tr7_mensual": execute_query("SELECT * FROM dbo.vw_kpi_tr7_mensual ORDER BY anio, mes;"),
        "kpi3_volumen_turno": execute_query("SELECT * FROM dbo.vw_kpi_volumen_turno ORDER BY interacciones DESC;"),
        "calidad": execute_query("SELECT * FROM dbo.vw_calidad_antes_despues;"),
    }


# ============================================
# EJECUCIÓN DIRECTA
# ============================================
if __name__ == "__main__":
    df_limpio = cargar_dataset_recontacto_correcto()
    print("\n")
    df_crudo = cargar_dataset_recontacto()
    print("\n")
    df_interacciones = cargar_interacciones()
    print("\n")
    kpis = cargar_kpis()
    for nombre, tabla in kpis.items():
        print(f"\n[{nombre}]")
        print(tabla.to_string(index=False))

    print("\n" + "=" * 60)
    print("✅ Datos cargados en memoria, listos para modelado")
    print("=" * 60)
