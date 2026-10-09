# ============================================
# verificar_instalacion.py
# Verifica que TODAS las librerías estén instaladas
# SERVICIO CIUDADANO 1800 (CASO 15)
# ============================================

def verificar():
    print("=" * 60)
    print("🔍 VERIFICACIÓN DE INSTALACIÓN")
    print("=" * 60)

    errores = []

    import sys
    print(f"\n🐍 Python: {sys.version}")

    try:
        import pandas as pd
        print(f"✅ pandas: {pd.__version__}")
    except ImportError:
        errores.append("pandas")

    try:
        import numpy as np
        print(f"✅ numpy: {np.__version__}")
    except ImportError:
        errores.append("numpy")

    try:
        import sklearn
        print(f"✅ scikit-learn: {sklearn.__version__}")
    except ImportError:
        errores.append("scikit-learn")

    try:
        import xgboost as xgb
        print(f"✅ xgboost: {xgb.__version__}")
    except ImportError:
        errores.append("xgboost")

    try:
        import lightgbm as lgb
        print(f"✅ lightgbm: {lgb.__version__}")
    except ImportError:
        errores.append("lightgbm")

    try:
        import matplotlib
        print(f"✅ matplotlib: {matplotlib.__version__}")
    except ImportError:
        errores.append("matplotlib")

    try:
        import seaborn as sns
        print(f"✅ seaborn: {sns.__version__}")
    except ImportError:
        errores.append("seaborn")

    try:
        import pyodbc
        print(f"✅ pyodbc: {pyodbc.version}")
        print("\n📋 Drivers ODBC disponibles:")
        drivers = pyodbc.drivers()
        if drivers:
            for d in drivers:
                print(f"   • {d}")
        else:
            print("   ⚠️ No se encontraron drivers ODBC!")
            errores.append("ODBC Driver")
    except ImportError:
        errores.append("pyodbc")

    try:
        import dotenv
        print("✅ python-dotenv: instalado")
    except ImportError:
        errores.append("python-dotenv")

    try:
        import jupyterlab
        print("✅ jupyterlab: instalado")
    except ImportError:
        errores.append("jupyterlab")

    print("\n" + "=" * 60)
    if errores:
        print(f"❌ Faltan {len(errores)} dependencias: {', '.join(errores)}")
        print(f"💡 Ejecuta: pip install -r requirements.txt")
    else:
        print("🎉 ¡TODAS las dependencias están instaladas!")
    print("=" * 60)


if __name__ == "__main__":
    verificar()
