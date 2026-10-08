# Guía de Ejecución: Proyecto de Minería de Datos (Windows + SQL Server)

¡Hola! Esta guía es para ayudarte a ejecutar el proyecto de minería de datos en tu máquina con Windows usando Microsoft SQL Server.

## 🛠️ Requisitos Previos (Instalaciones necesarias)

Antes de empezar, asegúrate de tener instalados estos programas en tu PC:

1. **Microsoft SQL Server:** Puedes usar la versión gratuita [SQL Server Express](https://www.microsoft.com/es-es/sql-server/sql-server-downloads). También necesitas una herramienta para administrarlo como **SQL Server Management Studio (SSMS)** o Azure Data Studio.
2. **.NET SDK:** Necesario para ejecutar el generador de datos. Descarga el [SDK de .NET](https://dotnet.microsoft.com/download) (versión 8 o superior).
3. **Python:** Descarga [Python 3.10 o superior](https://www.python.org/downloads/). **IMPORTANTE:** Al instalarlo, asegúrate de marcar la casilla **"Add Python to PATH"**.
4. **Git o Visual Studio Code (Opcional pero recomendado):** Para editar los archivos y abrir el proyecto fácilmente.

---

## 🚀 Pasos para Ejecutar el Proyecto

### PASO 1: Crear la Base de Datos

1. Abre **SSMS** y conéctate a tu servidor local de SQL Server.
2. Abre y ejecuta los scripts SQL que están en la raíz del proyecto en este orden estricto:
   - 📂 Ejecuta `01 - DATAWAREHOUSE.SQL` (Esto creará la base de datos `citizenDW` y sus tablas).
   *Nota: No ejecutes todavía los scripts de la parte "02", primero necesitamos llenar la base de datos.*

### PASO 2: Generar los Datos (C#)

1. Abre tu terminal (`cmd` o `PowerShell`) y navega hasta la carpeta del proyecto C#:
   ```cmd
   cd ruta\al\proyecto\DataSetGenerator\DataSetGenerator
   ```
2. Abre el archivo `Program.cs` en cualquier editor de texto y revisa la línea `static string connectionString = ...`. Ajusta las credenciales si tu servidor de SQL Server usa contraseña (por defecto, si usas Windows Authentication, debería decir `Integrated Security=True`).
3. Ejecuta el generador de datos con:
   ```cmd
   dotnet run
   ```
   *Esto generará miles de registros aleatorios y poblará la base de datos. Tomará un minuto aprox.*

### PASO 3: Crear el Dataset para Minería (SQL)

1. Vuelve a **SSMS**.
2. Abre y ejecuta el archivo `02 - DATASE_CORREGIDO.SQL`.
   *Esto creará la vista/tabla con los datos finales limpios que consumirá el modelo de Machine Learning.*

### PASO 4: Configurar el Entorno de Análisis (Python)

1. En tu terminal, navega a la carpeta de análisis:
   ```cmd
   cd ruta\al\proyecto\DataSetGenerator\citizen-analytics
   ```
2. Crea y activa tu entorno virtual:
   ```cmd
   python -m venv venv
   venv\Scripts\activate
   ```
3. Instala las dependencias necesarias:
   ```cmd
   pip install -r requirements.txt
   ```
4. Configura tu conexión a la base de datos. Abre el archivo `.env` en la misma carpeta y ajusta las variables para que apunten a tu SQL Server local (por ejemplo, actualizando `DB_PASSWORD` si tienes una, o usando `DB_TRUSTED=yes` si usas autenticación de Windows).

### PASO 5: ¡A Explorar los Modelos!

1. Con tu entorno virtual aún activo en la terminal, inicia Jupyter Lab:
   ```cmd
   jupyter lab
   ```
2. Se abrirá una pestaña en tu navegador web. Desde ahí, ve a la carpeta `notebooks/` y abre los archivos `.ipynb` (por ejemplo, `03_modelado_correcto.ipynb` o `04_comparacion_modelos.ipynb`) para entrenar y ver los modelos de minería de datos funcionando.

¡Listo! Con eso deberías tener todo el pipeline (BD -> C# -> SQL -> Python) funcionando en tu Windows.
