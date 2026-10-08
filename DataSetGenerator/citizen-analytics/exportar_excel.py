# ============================================
# exportar_excel.py
# Exporta los datos crudos (v0_crudo) y los limpios (vw_v1_limpio)
# a archivos Excel dentro de la carpeta "data" del proyecto.
# ============================================

import os
import sys
import pandas as pd

sys.path.insert(0, os.path.dirname(os.path.abspath(__file__)))
from src.database import execute_query

BASE_DIR = os.path.dirname(os.path.abspath(__file__))
DATA_DIR = os.path.normpath(os.path.join(BASE_DIR, '..', '..', 'data'))

TABLAS = [
    ("v0_crudo", "v0_crudo.xlsx"),
    ("vw_v1_limpio", "v1_limpio.xlsx"),
]


def exportar_tabla(tabla, archivo):
    print("=" * 60)
    print("Exportando " + tabla + " a Excel...")
    print("=" * 60)

    df = execute_query("SELECT * FROM " + tabla + ";")

    if df is None or df.empty:
        print("ADVERTENCIA: " + tabla + " no existe o esta vacia. Se omite.")
        return

    os.makedirs(DATA_DIR, exist_ok=True)
    ruta = os.path.join(DATA_DIR, archivo)
    df.to_excel(ruta, index=False)

    print("Excel guardado: " + ruta)
    print("   Filas: {:,} | Columnas: {}".format(len(df), len(df.columns)))


if __name__ == "__main__":
    print("Carpeta destino: " + DATA_DIR)
    for tabla, archivo in TABLAS:
        exportar_tabla(tabla, archivo)
    print("")
    print("Exportacion a Excel completada.")
