# Servicio Ciudadano 1800 · Caso 15

Proyecto de minería de datos sobre interacciones de un centro de atención ciudadana. El flujo genera registros reproducibles, simula problemas de calidad, aplica un MINI ETL, carga un Data Warehouse en SQL Server, calcula KPI y compara modelos para predecir el recontacto dentro de siete días.

> Los datos se generan artificialmente a partir de cifras de referencia y supuestos de diseño. Los resultados de los modelos son demostrativos; no describen el rendimiento real de un centro de atención.

## Requisitos

- Docker Engine y Docker Compose v2 (recomendado), **o**
- SQL Server, .NET 10, Python 3.10–3.12 y Microsoft ODBC Driver 18 para SQL Server.

## Ejecución recomendada: Docker Compose

Desde la raíz del proyecto, prepara el archivo de configuración y define una contraseña única para SQL Server:

```bash
cp .env.example .env
```

Edita `.env` y reemplaza `DB_PASSWORD`. Ajusta `APP_UID` y `APP_GID` a los identificadores de tu usuario (`id -u` y `id -g` en Linux/macOS) para que los contenedores puedan escribir los CSV y notebooks montados.

Construye y arranca todo el flujo:

```bash
docker compose up --build
```

Compose inicia SQL Server, prepara el Data Warehouse, genera y limpia los datos, crea los datasets de minería y finalmente inicia JupyterLab. Abre <http://localhost:8888>; el token de acceso aparece en:

```bash
docker compose logs jupyter
```

Los puertos de Jupyter y SQL Server solo se publican en `127.0.0.1`. Los CSV generados aparecen en `data/`, una carpeta ignorada por Git. La base de datos persiste en el volumen `sqlserver_data`.

Puedes ajustar el número de registros y la semilla desde `.env`, por ejemplo `N_REGISTROS=30000` y `SEMILLA=1800`. Para detener el proyecto y conservar la base de datos:

```bash
docker compose down
```

Para borrar también la base persistida y comenzar desde cero:

```bash
docker compose down -v
docker compose up --build
```

`down -v` elimina permanentemente los datos del volumen de SQL Server.

## Ejecución sin Docker

Necesitas SQL Server en `localhost:1433`, .NET 10, Python 3.10–3.12 y ODBC Driver 18. Configura las credenciales para la conexión local en `DataSetGenerator/servicio-ciudadano-analytics/.env` (ese archivo está excluido de Git). Con un certificado local autofirmado puedes usar `DB_TRUST_CERT=yes` durante el desarrollo; para un entorno real, configura un certificado confiable y `DB_TRUST_CERT=no`.

### 1. Instalar dependencias Python

```bash
cd DataSetGenerator/servicio-ciudadano-analytics
python -m venv venv
# Linux/macOS:
source venv/bin/activate
# Windows PowerShell:
# .\venv\Scripts\Activate.ps1
pip install -r requirements.txt
```

### 2. Configurar la conexión

En Linux/macOS, exporta las variables para que Python y el generador .NET usen la misma conexión:

```bash
export DB_HOST=localhost
export DB_PORT=1433
export DB_NAME=ServicioCiudadano1800DW
export DB_USER=sa
export DB_PASSWORD='tu-contraseña-local'
export DB_TRUST_CERT=yes
```

En Windows PowerShell, define los mismos valores con `$env:DB_HOST = "localhost"`, `$env:DB_PORT = "1433"`, `$env:DB_NAME = "ServicioCiudadano1800DW"`, `$env:DB_USER = "sa"`, `$env:DB_PASSWORD = "tu-contraseña-local"` y `$env:DB_TRUST_CERT = "yes"`.

### 3. Crear el esquema y generar/cargar interacciones

Desde la carpeta de analítica, inicializa las tablas y después vuelve a la raíz del proyecto para correr el generador:

```bash
python scripts/init_dw.py
cd ../..
dotnet run --project DataSetGenerator/DataSetGenerator -c Release
```

El generador crea `data/v0_crudo.csv` y `data/v1_limpio.csv`, carga los datos en SQL Server y calcula los KPI. Para generar únicamente los CSV, sin conectar a SQL Server:

```bash
SOLO_CSV=1 dotnet run --project DataSetGenerator/DataSetGenerator -c Release
```

En PowerShell usa `$env:SOLO_CSV = "1"` antes del comando. Puedes cambiar el tamaño con `N_REGISTROS` y la semilla con `SEMILLA`.

### 4. Crear datasets de minería y abrir notebooks

```bash
cd DataSetGenerator/servicio-ciudadano-analytics
python scripts/crear_datasets.py
jupyter lab
```

Abre la carpeta `notebooks/` en JupyterLab. El notebook `06_modelos.ipynb` compara ocho algoritmos; los demás cubren conexión, entrenamiento inicial, modelado con datos limpios y comparación antes/después del MINI ETL.

## Estructura principal

- `compose.yaml`: servicios, volúmenes, puertos y configuración local.
- `Dockerfile` y `DataSetGenerator/DataSetGenerator/Dockerfile`: imágenes de analítica y generador .NET.
- `sql/`: scripts de inicialización, datasets de minería y KPI en orden de ejecución.
- `DataSetGenerator/DataSetGenerator/`: generador C# y MINI ETL.
- `DataSetGenerator/servicio-ciudadano-analytics/`: utilidades Python y notebooks.
- `data/`: CSV generados; no se incluyen en Git.
- `DataSetGenerator/INSTALCION.MD`: notas específicas del generador y material de referencia del curso.

## Integración continua

GitHub Actions ejecuta el flujo de CI definido en `.github/workflows/ci.yml` en cada `push`, pull request y ejecución manual. Comprueba la sintaxis de Python y el formato JSON de los notebooks, valida la configuración de Compose y construye las imágenes Python y .NET. Las compilaciones no arrancan SQL Server ni necesitan credenciales reales.

## Seguridad y alcance

No subas `.env` ni credenciales. La configuración Compose ejecuta los procesos de analítica y generación sin root, limita sus permisos y protege la contraseña mediante un secret. Este Compose está pensado para desarrollo local; producción requiere, entre otras cosas, credenciales SQL de mínimo privilegio, certificado TLS confiable, backups y un gestor de secretos apropiado.
