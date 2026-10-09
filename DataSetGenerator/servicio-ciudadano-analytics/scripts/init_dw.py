"""
Prepara el Data Warehouse del Servicio Ciudadano 1800 (Caso 15).

  dw-init (docker)  -> crea la base + ejecuta '01_datawarehouse.sql'
  datasets (docker) -> ejecuta los 02 y el 03 (datasets de minería + KPI)

En local también sirve:
    python scripts/init_dw.py          # esquema
    python scripts/crear_datasets.py   # datasets y KPI (después de generar)
"""
from __future__ import annotations

import os
import sys
import time
from pathlib import Path

RAIZ_ANALYTICS = Path(__file__).resolve().parent.parent
sys.path.insert(0, str(RAIZ_ANALYTICS))

from src import database as db  # noqa: E402


def buscar_sql(nombre: str) -> Path:
    """Busca un script en SQL_DIR, /app/sql o en una carpeta sql/ del proyecto."""
    candidatos = []
    if os.getenv("SQL_DIR"):
        candidatos.append(Path(os.getenv("SQL_DIR")) / nombre)
    candidatos.append(Path("/app/sql") / nombre)
    for base in (RAIZ_ANALYTICS, *RAIZ_ANALYTICS.parents):
        candidatos.append(base / "sql" / nombre)
    for ruta in candidatos:
        if ruta.is_file():
            return ruta
    raise FileNotFoundError(
        f"No se encontró '{nombre}'. Buscado en:\n  " + "\n  ".join(str(c) for c in candidatos))


def main() -> int:
    print("== Servicio Ciudadano 1800 | preparando el Data Warehouse ==")
    print("[dw] Esperando a SQL Server ...")
    db.esperar_servidor()
    ruta = buscar_sql("01_datawarehouse.sql")

    # SQL Server puede responder al healthcheck y aún estar inicializando:
    # se reintenta la preparación unas cuantas veces antes de rendirse.
    ultimo_error = None
    for intento in range(1, 6):
        try:
            print(f"[dw] Creando la base si no existe (intento {intento}/5) ...")
            db.crear_base_si_no_existe()
            print(f"[dw] Ejecutando {ruta} ...")
            db.ejecutar_script_sql(ruta)
            print("[dw] Listo: dimensiones, zona de preparación y hechos creados.")
            return 0
        except Exception as exc:  # noqa: BLE001
            ultimo_error = exc
            print(f"[dw] SQL Server aún no está listo: {exc}")
            time.sleep(5)
    raise RuntimeError(f"No se pudo preparar el Data Warehouse: {ultimo_error}")


if __name__ == "__main__":
    try:
        sys.exit(main())
    except Exception as exc:  # noqa: BLE001
        print(f"\nERROR: {exc}", file=sys.stderr)
        sys.exit(1)
