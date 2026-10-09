"""
Crea los datasets de minería y las vistas de KPI del Caso 15
(se ejecuta DESPUÉS de que el generador cargó los datos):

    python scripts/crear_datasets.py

  * 02_dataset_recontacto_crudo.sql  -> dm_dataset_recontacto (v0 sucio)
  * 03_dataset_recontacto_limpio.sql -> dm_dataset_recontacto_correcto (limpio)
  * 04_kpis.sql                     -> vw_kpi_* + calidad
"""
from __future__ import annotations

import sys
from pathlib import Path

RAIZ_ANALYTICS = Path(__file__).resolve().parent.parent
sys.path.insert(0, str(RAIZ_ANALYTICS))

from src import database as db  # noqa: E402
from scripts.init_dw import buscar_sql  # noqa: E402

GUIONES = [
    "02_dataset_recontacto_crudo.sql",
    "03_dataset_recontacto_limpio.sql",
    "04_kpis.sql",
]


def main() -> int:
    conn = db.get_connection(autocommit=True)
    try:
        for nombre in GUIONES:
            ruta = buscar_sql(nombre)
            print(f"\n[datasets] Ejecutando {ruta.name} ...")
            db.ejecutar_script_sql(ruta, conn)
    finally:
        conn.close()
    print("\nListo: datasets de minería y KPI creados.")
    return 0


if __name__ == "__main__":
    try:
        sys.exit(main())
    except Exception as exc:  # noqa: BLE001
        print(f"\nERROR: {exc}", file=sys.stderr)
        sys.exit(1)
