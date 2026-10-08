# Verificación de Limpieza y Gobierno de Datos (Caso 15)
Este cuaderno demuestra el "Antes" y "Después" de los datos, comprobando que las reglas de negocio (ETL) diseñadas por el equipo funcionan correctamente al procesar los datos directamente en SQL Server.


```python
import os
import pyodbc
import pandas as pd
import warnings
warnings.filterwarnings('ignore')

# Conexión a la Base de Datos
server = os.getenv('DB_SERVER', 'db')
database = os.getenv('DB_NAME', 'ServicioCiudadanoDW')
username = os.getenv('DB_USER', 'SA')
password = os.getenv('DB_PASSWORD', 'J0AhMXX4H0QBrRr8R1U098y8aA1@')
driver = os.getenv('DB_DRIVER', '{ODBC Driver 18 for SQL Server}')

connection_string = f'DRIVER={driver};SERVER={server};DATABASE={database};UID={username};PWD={password};TrustServerCertificate=yes;'
conn = pyodbc.connect(connection_string)
print("✅ Conectado a la Base de Datos exitosamente")

```

    ✅ Conectado a la Base de Datos exitosamente


### 1. Volumen de Datos y Duplicados (R-CAL-04 y R-CAL-01)


```python
# Vemos la diferencia entre los registros en crudo (con duplicados y target nulos) vs limpios
crudo = pd.read_sql("SELECT COUNT(*) as Total FROM v0_crudo", conn).iloc[0,0]
limpio = pd.read_sql("SELECT COUNT(*) as Total FROM vw_v1_limpio", conn).iloc[0,0]

print(f"🔴 Datos Crudos generados (con basura): {crudo:,} registros")
print(f"🟢 Datos Limpios para modelado: {limpio:,} registros")
print(f"   -> Se limpiaron {crudo - limpio:,} registros defectuosos o duplicados.")

```

    🔴 Datos Crudos generados (con basura): 100,000 registros
    🟢 Datos Limpios para modelado: 73,923 registros
       -> Se limpiaron 26,077 registros defectuosos o duplicados.


### 2. Normalización de Textos (R-CAL-02)


```python
# El generador inyectó valores en mayúsculas como 'COBRO' o 'QUEJA' simulando errores tipográficos
df_antes = pd.read_sql("SELECT motivo_contacto, COUNT(*) as cantidad FROM v0_crudo GROUP BY motivo_contacto", conn)
df_despues = pd.read_sql("SELECT motivo_contacto, COUNT(*) as cantidad FROM vw_v1_limpio GROUP BY motivo_contacto", conn)

print("🔴 ANTES (Tabla v0_crudo):")
print(df_antes.to_string(index=False))
print("-" * 40)
print("🟢 DESPUÉS (Vista vw_v1_limpio):")
print(df_despues.to_string(index=False))

```

    🔴 ANTES (Tabla v0_crudo):
    motivo_contacto  cantidad
           Consulta     24742
              Queja     25067
              Falla     25324
              Cobro     24867
    ----------------------------------------
    🟢 DESPUÉS (Vista vw_v1_limpio):
    motivo_contacto  cantidad
              Cobro     18299
           Consulta     18279
              Falla     18885
              Queja     18460


### 3. Límites Numéricos de Duración (R-CAL-05)


```python
# El negocio exige que las llamadas duren entre 30 y 1800 segundos.
df_antes_dur = pd.read_sql("SELECT MIN(duracion_seg) as Min_Segundos, MAX(duracion_seg) as Max_Segundos FROM v0_crudo", conn)
df_despues_dur = pd.read_sql("SELECT MIN(duracion_seg) as Min_Segundos, MAX(duracion_seg) as Max_Segundos FROM vw_v1_limpio", conn)

print("🔴 ANTES (Tabla v0_crudo):")
print(df_antes_dur.to_string(index=False))
print("   * ¡Hay registros de 20 segs y hasta de 1900 segs! Valores fuera de rango.")
print("-" * 40)
print("🟢 DESPUÉS (Vista vw_v1_limpio):")
print(df_despues_dur.to_string(index=False))
print("   * Valores encuadrados perfectamente entre 30 y 1800 segs.")

```

    🔴 ANTES (Tabla v0_crudo):
     Min_Segundos  Max_Segundos
               20          1999
       * ¡Hay registros de 20 segs y hasta de 1900 segs! Valores fuera de rango.
    ----------------------------------------
    🟢 DESPUÉS (Vista vw_v1_limpio):
     Min_Segundos  Max_Segundos
               30          1800
       * Valores encuadrados perfectamente entre 30 y 1800 segs.


### 4. Manejo de Canales Vacíos (R-CAL-03)


```python
# El generador inyectó valores '(sin dato)'
df_antes_can = pd.read_sql("SELECT canal, COUNT(*) as cantidad FROM v0_crudo GROUP BY canal", conn)
df_despues_can = pd.read_sql("SELECT canal, COUNT(*) as cantidad FROM vw_v1_limpio GROUP BY canal", conn)

print("🔴 ANTES (Tabla v0_crudo):")
print(df_antes_can.to_string(index=False))
print("-" * 40)
print("🟢 DESPUÉS (Vista vw_v1_limpio):")
print(df_despues_can.to_string(index=False))
print("   * Los '(sin dato)' o nulos fueron agrupados inteligentemente bajo 'Sin clasificar'.")

conn.close()

```

    🔴 ANTES (Tabla v0_crudo):
         canal  cantidad
           App     23774
           Web     23485
    (sin dato)      5000
      Teléfono     24012
    Red social     23729
    ----------------------------------------
    🟢 DESPUÉS (Vista vw_v1_limpio):
             canal  cantidad
               App     17619
        Red social     17593
    Sin clasificar      3692
          Teléfono     17686
               Web     17333
       * Los '(sin dato)' o nulos fueron agrupados inteligentemente bajo 'Sin clasificar'.

