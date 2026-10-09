# ============================================
# src/database.py
# SERVICIO CIUDADANO 1800 (CASO 15) - CONEXIÓN SQL SERVER
# Lee la configuración del archivo .env (las variables de entorno
# tienen prioridad; así Docker puede sobrescribir el servidor).
# ============================================

import os
import re
import time
from pathlib import Path

import pandas as pd
import pyodbc
from dotenv import load_dotenv

RAIZ = Path(__file__).resolve().parent.parent
load_dotenv(RAIZ / ".env")          # no pisa variables ya definidas en el entorno


# ---------------------------------------------------------------------------
# Configuración
# ---------------------------------------------------------------------------
def _env(nombre: str, defecto: str) -> str:
    valor = os.getenv(nombre)
    return defecto if valor is None or valor.strip() == "" else valor.strip()


def get_config() -> dict:
    password = os.getenv("DB_PASSWORD")
    password_file = os.getenv("DB_PASSWORD_FILE")
    if not password and password_file:
        password = Path(password_file).read_text(encoding="utf-8").strip()
    if _env("DB_AUTH", "sql").lower() != "windows" and not password:
        raise RuntimeError("Define DB_PASSWORD o DB_PASSWORD_FILE para conectar con SQL Server.")
    return {
        "host": _env("DB_HOST", "localhost"),
        "port": _env("DB_PORT", "1433"),
        "name": _env("DB_NAME", "ServicioCiudadano1800DW"),
        "user": _env("DB_USER", "sa"),
        "password": password or "",
        "driver": _env("DB_DRIVER", "ODBC Driver 18 for SQL Server"),
        "auth": _env("DB_AUTH", "sql").lower(),            # sql | windows
        "trust_cert": _env("DB_TRUST_CERT", "no"),
    }


def _driver_disponible(preferido: str) -> str:
    """Devuelve el driver ODBC a usar; si el preferido no está, busca uno equivalente."""
    instalados = pyodbc.drivers()
    if preferido in instalados:
        return preferido
    candidatos = sorted((d for d in instalados if re.fullmatch(r"ODBC Driver \d+ for SQL Server", d)),
                        key=lambda d: int(re.findall(r"\d+", d)[0]), reverse=True)
    for alternativa in candidatos + [d for d in instalados if d in ("SQL Server Native Client 11.0", "SQL Server")]:
        return alternativa
    raise RuntimeError(
        f"No se encontró el driver ODBC '{preferido}'. Drivers instalados: {instalados or 'ninguno'}.\n"
        "Instala 'ODBC Driver 18 for SQL Server' (Microsoft) o ajusta DB_DRIVER en el archivo .env."
    )


def _servidor(cfg: dict) -> str:
    # Instancia con nombre (localhost\SQLEXPRESS) -> sin puerto
    if "\\" in cfg["host"] or not cfg["port"]:
        return cfg["host"]
    return f"{cfg['host']},{cfg['port']}"


def _cadena_conexion(cfg: dict, base: str | None) -> str:
    driver = _driver_disponible(cfg["driver"])
    partes = [f"DRIVER={{{driver}}}", f"SERVER={_servidor(cfg)}"]
    if base:
        partes.append(f"DATABASE={base}")
    if cfg["auth"] == "windows":
        partes.append("Trusted_Connection=yes")
    else:
        pwd = cfg["password"].replace("}", "}}")
        partes += [f"UID={cfg['user']}", f"PWD={{{pwd}}}"]
    partes.append(f"TrustServerCertificate={cfg['trust_cert']}")
    return ";".join(partes) + ";"


# ---------------------------------------------------------------------------
# Conexión
# ---------------------------------------------------------------------------
def get_connection(base: str | None = "__proyecto__", autocommit: bool = False, timeout: int = 10):
    """
    base="__proyecto__" (por defecto) -> la base del proyecto (DB_NAME)
    base=None / "master"              -> el servidor sin base específica (master)
    """
    cfg = get_config()
    if base == "__proyecto__":
        base = cfg["name"]
    conn = pyodbc.connect(_cadena_conexion(cfg, base), autocommit=autocommit, timeout=timeout)
    return conn


AYUDA_CONEXION = (
    "Revisa en este orden:\n"
    "  1. ¿SQL Server está encendido?  (Docker: docker compose ps | Local: servicio 'SQL Server (MSSQLSERVER)')\n"
    "  2. DB_HOST / DB_PORT / DB_USER / DB_PASSWORD en el archivo .env\n"
    "  3. Si usas Windows Authentication: DB_AUTH=windows\n"
    "  4. Si es una instancia con nombre (SQLEXPRESS): DB_HOST=localhost\\SQLEXPRESS y deja DB_PORT vacío\n"
    "  5. Que el login 'sa' esté habilitado y SQL Server acepte autenticación mixta\n"
    "  6. Que el protocolo TCP/IP esté habilitado (SQL Server Configuration Manager)\n"
)


def test_connection(verbose: bool = True) -> bool:
    try:
        conn = get_connection()
        cur = conn.cursor()
        cur.execute("SELECT @@VERSION")
        version = cur.fetchone()[0].splitlines()[0]
        conn.close()
        if verbose:
            cfg = get_config()
            print(f"Conexión OK -> {_servidor(cfg)} / {cfg['name']}\n{version}")
        return True
    except Exception as exc:  # noqa: BLE001
        if verbose:
            print(f"No se pudo conectar: {exc}\n\n{AYUDA_CONEXION}")
        return False


def esperar_servidor(timeout_s: int = 180, intervalo_s: int = 3) -> None:
    """Reintenta conectarse al servidor (base master) hasta que responda."""
    inicio, ultimo_error = time.time(), None
    while time.time() - inicio < timeout_s:
        try:
            get_connection(base=None, autocommit=True, timeout=5).close()
            return
        except Exception as exc:  # noqa: BLE001
            ultimo_error = exc
            time.sleep(intervalo_s)
    raise RuntimeError(f"SQL Server no respondió en {timeout_s} s. Último error: {ultimo_error}\n\n{AYUDA_CONEXION}")


def crear_base_si_no_existe() -> None:
    nombre = get_config()["name"]
    if not re.fullmatch(r"[A-Za-z0-9_]+", nombre):
        raise ValueError(f"DB_NAME inválido: {nombre!r} (usa solo letras, números y guion bajo)")
    conn = get_connection(base=None, autocommit=True)
    try:
        conn.cursor().execute(f"IF DB_ID(N'{nombre}') IS NULL CREATE DATABASE [{nombre}]")
    finally:
        conn.close()


# ---------------------------------------------------------------------------
# Consultas
# ---------------------------------------------------------------------------
def execute_query(sql: str, params: tuple | list | None = None) -> pd.DataFrame:
    """Ejecuta un SELECT y devuelve un DataFrame."""
    conn = get_connection()
    try:
        cur = conn.cursor()
        cur.execute(sql, *params) if params else cur.execute(sql)
        columnas = [c[0] for c in cur.description]
        filas = cur.fetchall()
        return pd.DataFrame.from_records([tuple(f) for f in filas], columns=columnas)
    finally:
        conn.close()


def execute_non_query(sql: str, params: tuple | list | None = None) -> int:
    conn = get_connection()
    try:
        cur = conn.cursor()
        cur.execute(sql, *params) if params else cur.execute(sql)
        conn.commit()
        return cur.rowcount
    finally:
        conn.close()


def _lotes_go(texto: str) -> list[str]:
    return [b.strip() for b in re.split(r"^\s*GO\s*$", texto, flags=re.MULTILINE | re.IGNORECASE) if b.strip()]


def ejecutar_script_sql(ruta: str | Path, conn=None, verbose: bool = True) -> None:
    """Ejecuta un archivo .sql separando los lotes por GO (igual que SSMS / sqlcmd)."""
    ruta = Path(ruta)
    texto = ruta.read_text(encoding="utf-8-sig")
    propia = conn is None
    conn = conn or get_connection(autocommit=True)
    try:
        cur = conn.cursor()
        cur.execute("SET NOCOUNT ON")
        lotes = _lotes_go(texto)
        for i, lote in enumerate(lotes, 1):
            try:
                cur.execute(lote)
                while True:
                    if cur.description:
                        filas = cur.fetchall()
                        if verbose and filas:
                            df = pd.DataFrame.from_records([tuple(f) for f in filas],
                                                           columns=[c[0] for c in cur.description])
                            print(df.to_string(index=False))
                    if not cur.nextset():
                        break
            except pyodbc.Error as exc:
                raise RuntimeError(f"Error en {ruta.name}, lote {i}/{len(lotes)}:\n{exc}\n--- lote ---\n{lote[:600]}") from exc
        if not propia:
            conn.commit()
    finally:
        if propia:
            conn.close()
    if verbose:
        print(f"[sql] {ruta.name}: {len(lotes)} lotes ejecutados")


def fetch_df(conn, sql: str, params: tuple | list | None = None) -> pd.DataFrame:
    """Como execute_query, pero sobre una conexión ya abierta."""
    cur = conn.cursor()
    cur.execute(sql, *params) if params else cur.execute(sql)
    columnas = [c[0] for c in cur.description]
    filas = cur.fetchall()
    return pd.DataFrame.from_records([tuple(f) for f in filas], columns=columnas)


# ============================================
# EJECUCIÓN DIRECTA (para probar desde terminal)
# ============================================
if __name__ == "__main__":
    test_connection()
