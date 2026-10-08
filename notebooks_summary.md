# Resumen de Notebooks y Resultados
A continuación se muestra el código y resultado exacto de cada notebook ejecutado en tiempo real.


## Archivo: 00_Verificacion_Limpieza.ipynb

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



## Archivo: 01Prueba.ipynb

# EDA y KPIs - Servicio Ciudadano 1800 (Caso 15)
Este cuaderno fue adaptado para cargar la vista limpia y responder a las preguntas de negocio (KPIs).


```python
import os
import pyodbc
import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sns

sns.set_theme(style="whitegrid")
plt.rcParams['figure.figsize'] = (10, 6)

# Conexión directa a SQL Server (contenedor db)
server = os.getenv('DB_SERVER', 'db')
database = os.getenv('DB_NAME', 'ServicioCiudadanoDW')
username = os.getenv('DB_USER', 'SA')
password = os.getenv('DB_PASSWORD', 'J0AhMXX4H0QBrRr8R1U098y8aA1@')
driver = os.getenv('DB_DRIVER', '{ODBC Driver 18 for SQL Server}')

connection_string = f'DRIVER={driver};SERVER={server};DATABASE={database};UID={username};PWD={password};TrustServerCertificate=yes;'

print("🔄 Conectando a SQL Server y cargando datos...")
conn = pyodbc.connect(connection_string)
df = pd.read_sql("SELECT * FROM vw_v1_limpio", conn)
conn.close()

print(f"✅ Datos cargados: {df.shape[0]} filas limpias, {df.shape[1]} columnas")
df.head()

```

    🔄 Conectando a SQL Server y cargando datos...


    /tmp/ipykernel_35/328054759.py:21: UserWarning: pandas only supports SQLAlchemy connectable (engine/connection) or database string URI or sqlite3 DBAPI2 connection. Other DBAPI2 objects are not tested. Please consider using SQLAlchemy.
      df = pd.read_sql("SELECT * FROM vw_v1_limpio", conn)


    ✅ Datos cargados: 73923 filas limpias, 14 columnas





<div>
<style scoped>
    .dataframe tbody tr th:only-of-type {
        vertical-align: middle;
    }

    .dataframe tbody tr th {
        vertical-align: top;
    }

    .dataframe thead th {
        text-align: right;
    }
</style>
<table border="1" class="dataframe">
  <thead>
    <tr style="text-align: right;">
      <th></th>
      <th>id_interaccion</th>
      <th>fecha_contacto</th>
      <th>fecha_carga</th>
      <th>canal</th>
      <th>motivo_contacto</th>
      <th>cola_servicio</th>
      <th>duracion_seg</th>
      <th>espera_seg</th>
      <th>grabacion_autorizada</th>
      <th>recontacto_7_dias</th>
      <th>casos_previos_30d</th>
      <th>nivel_transferencias</th>
      <th>tipo_usuario</th>
      <th>turno</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>0</th>
      <td>00068ef7-e2ec-48bb-8cb1-270419504731</td>
      <td>2025-12-07 02:20:17.803</td>
      <td>2026-10-08 00:20:17.803</td>
      <td>Teléfono</td>
      <td>Cobro</td>
      <td>Información</td>
      <td>1717</td>
      <td>796</td>
      <td>No</td>
      <td>0</td>
      <td>4</td>
      <td>1</td>
      <td>Particular</td>
      <td>Nocturno</td>
    </tr>
    <tr>
      <th>1</th>
      <td>000b0a9b-4ed0-43be-9b45-f49c809a5807</td>
      <td>2025-12-12 12:24:23.487</td>
      <td>2026-10-08 00:24:23.483</td>
      <td>Web</td>
      <td>Consulta</td>
      <td>Reclamos</td>
      <td>1542</td>
      <td>523</td>
      <td>Sí</td>
      <td>0</td>
      <td>2</td>
      <td>1</td>
      <td>Gobierno</td>
      <td>AM</td>
    </tr>
    <tr>
      <th>2</th>
      <td>000b22a5-5962-4935-8f48-a91dcc1403c6</td>
      <td>2026-05-25 14:18:51.413</td>
      <td>2026-10-08 00:18:51.410</td>
      <td>Red social</td>
      <td>Consulta</td>
      <td>Información</td>
      <td>728</td>
      <td>392</td>
      <td>Sí</td>
      <td>0</td>
      <td>0</td>
      <td>0</td>
      <td>Empresa</td>
      <td>PM</td>
    </tr>
    <tr>
      <th>3</th>
      <td>000be391-b24f-47ee-a19c-4e6a11790eb0</td>
      <td>2026-01-14 09:14:53.353</td>
      <td>2026-10-08 00:14:53.350</td>
      <td>App</td>
      <td>Consulta</td>
      <td>Facturación</td>
      <td>1177</td>
      <td>896</td>
      <td>No</td>
      <td>1</td>
      <td>4</td>
      <td>0</td>
      <td>Particular</td>
      <td>AM</td>
    </tr>
    <tr>
      <th>4</th>
      <td>000f65d2-da1d-46ad-b6f3-ddb412796923</td>
      <td>2026-02-06 19:19:24.777</td>
      <td>2026-10-08 00:19:24.773</td>
      <td>Red social</td>
      <td>Falla</td>
      <td>Facturación</td>
      <td>191</td>
      <td>53</td>
      <td>Sí</td>
      <td>0</td>
      <td>0</td>
      <td>1</td>
      <td>Empresa</td>
      <td>PM</td>
    </tr>
  </tbody>
</table>
</div>




```python
# Celda 2: KPI 1 & 2 - Tasa de Recontacto (TR7) y FCR Estimado
# El recontacto es nuestra variable objetivo principal
tr7 = df['recontacto_7_dias'].mean() * 100
fcr = 100 - tr7

print("=" * 60)
print(f"🎯 KPI 1: Tasa de Recontacto a 7 días (TR7)")
print(f"   Valor Actual: {tr7:.2f}% (Meta del negocio: <= 22%)")
print("-" * 60)
print(f"🏆 KPI 2: FCR Estimado (First Contact Resolution)")
print(f"   Valor Actual: {fcr:.2f}% (Benchmark sector: >= 78%)")
print("=" * 60)

# Gráfico de pastel
plt.figure(figsize=(6,6))
plt.pie([fcr, tr7], labels=['Resuelto 1er contacto (FCR)', 'Recontacto (TR7)'], 
        autopct='%1.1f%%', colors=['#2ecc71', '#e74c3c'], explode=(0, 0.1), shadow=True)
plt.title('Proporción de Resolución vs Recontacto')
plt.show()

```

    ============================================================
    🎯 KPI 1: Tasa de Recontacto a 7 días (TR7)
       Valor Actual: 40.21% (Meta del negocio: <= 22%)
    ------------------------------------------------------------
    🏆 KPI 2: FCR Estimado (First Contact Resolution)
       Valor Actual: 59.79% (Benchmark sector: >= 78%)
    ============================================================



    
![png](01Prueba_files/01Prueba_2_1.png)
    



```python
# Celda 3: KPI 3, 4 y 5 - Riesgo de Recontacto por Dimensiones
fig, axes = plt.subplots(3, 1, figsize=(10, 15))

# Por Canal
sns.barplot(data=df, x='canal', y='recontacto_7_dias', ax=axes[0], palette='viridis', errorbar=None)
axes[0].set_title('KPI 3: Tasa de Recontacto por Canal', fontsize=14, fontweight='bold')
axes[0].set_ylabel('% de Recontacto')
axes[0].axhline(0.46, color='red', linestyle='--', label='Límite Riesgo (46%)')
axes[0].legend()

# Por Motivo
sns.barplot(data=df, x='motivo_contacto', y='recontacto_7_dias', ax=axes[1], palette='magma', errorbar=None)
axes[1].set_title('KPI 4: Recontacto por Motivo', fontsize=14, fontweight='bold')
axes[1].set_ylabel('% de Recontacto')

# Por Cola
sns.barplot(data=df, x='cola_servicio', y='recontacto_7_dias', ax=axes[2], palette='coolwarm', errorbar=None)
axes[2].set_title('KPI 5: Recontacto por Cola', fontsize=14, fontweight='bold')
axes[2].set_ylabel('% de Recontacto')

plt.tight_layout()
plt.show()

```

    /tmp/ipykernel_35/3166778481.py:5: FutureWarning: 
    
    Passing `palette` without assigning `hue` is deprecated and will be removed in v0.14.0. Assign the `x` variable to `hue` and set `legend=False` for the same effect.
    
      sns.barplot(data=df, x='canal', y='recontacto_7_dias', ax=axes[0], palette='viridis', errorbar=None)


    /tmp/ipykernel_35/3166778481.py:12: FutureWarning: 
    
    Passing `palette` without assigning `hue` is deprecated and will be removed in v0.14.0. Assign the `x` variable to `hue` and set `legend=False` for the same effect.
    
      sns.barplot(data=df, x='motivo_contacto', y='recontacto_7_dias', ax=axes[1], palette='magma', errorbar=None)


    /tmp/ipykernel_35/3166778481.py:17: FutureWarning: 
    
    Passing `palette` without assigning `hue` is deprecated and will be removed in v0.14.0. Assign the `x` variable to `hue` and set `legend=False` for the same effect.
    
      sns.barplot(data=df, x='cola_servicio', y='recontacto_7_dias', ax=axes[2], palette='coolwarm', errorbar=None)



    
![png](01Prueba_files/01Prueba_3_3.png)
    



```python

```


## Archivo: 03_modelado_correcto.ipynb

# Modelado de Recontacto (Modelo Correcto - Sin Leakage)
Este cuaderno demuestra el modelo correcto para predecir si un ciudadano volverá a contactar (recontacto_7_dias), utilizando únicamente la información disponible en el momento de la llamada.


```python
import pyodbc
import pandas as pd
import os
import matplotlib.pyplot as plt
import seaborn as sns
from sklearn.model_selection import train_test_split
from sklearn.metrics import classification_report, confusion_matrix, roc_auc_score, roc_curve
from xgboost import XGBClassifier

# Cargar datos limpios
server = os.getenv('DB_SERVER', 'db')
database = os.getenv('DB_NAME', 'ServicioCiudadanoDW')
username = os.getenv('DB_USER', 'SA')
password = os.getenv('DB_PASSWORD', 'J0AhMXX4H0QBrRr8R1U098y8aA1@')
driver = os.getenv('DB_DRIVER', '{ODBC Driver 18 for SQL Server}')

connection_string = f'DRIVER={driver};SERVER={server};DATABASE={database};UID={username};PWD={password};TrustServerCertificate=yes;'
conn = pyodbc.connect(connection_string)
df = pd.read_sql("SELECT * FROM vw_v1_limpio", conn)
conn.close()

print(f"✅ Dataset cargado exitosamente")
print(f"📏 Dimensiones: {df.shape[0]:,} filas × {df.shape[1]} columnas")

```

    /tmp/ipykernel_94/276284760.py:19: UserWarning: pandas only supports SQLAlchemy connectable (engine/connection) or database string URI or sqlite3 DBAPI2 connection. Other DBAPI2 objects are not tested. Please consider using SQLAlchemy.
      df = pd.read_sql("SELECT * FROM vw_v1_limpio", conn)


    ✅ Dataset cargado exitosamente
    📏 Dimensiones: 73,923 filas × 14 columnas



```python
# Preparar variables
X = df.drop(columns=['id_interaccion', 'fecha_contacto', 'fecha_carga', 'recontacto_7_dias'])
y = df['recontacto_7_dias']

# One-hot encoding de las categóricas
columnas_texto = X.select_dtypes(include=['object']).columns
X = pd.get_dummies(X, columns=columnas_texto.tolist(), drop_first=True)

# Train/Test Split
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.20, random_state=42, stratify=y)
print(f"✅ Set de entrenamiento: {X_train.shape[0]} | Set de prueba: {X_test.shape[0]}")

```

    /tmp/ipykernel_94/2163815437.py:6: Pandas4Warning: For backward compatibility, 'str' dtypes are included by select_dtypes when 'object' dtype is specified. This behavior is deprecated and will be removed in a future version. Explicitly pass 'str' to `include` to select them, or to `exclude` to remove them and silence this warning.
    See https://pandas.pydata.org/docs/user_guide/migration-3-strings.html#string-migration-select-dtypes for details on how to write code that works with pandas 2 and 3.
      columnas_texto = X.select_dtypes(include=['object']).columns


    ✅ Set de entrenamiento: 59138 | Set de prueba: 14785



```python
# Entrenar el modelo (XGBoost)
# Balanceo de clases
ratio_desbalance = (y_train == 0).sum() / (y_train == 1).sum()

modelo = XGBClassifier(
    n_estimators=300,
    max_depth=5,
    learning_rate=0.05,
    scale_pos_weight=ratio_desbalance, 
    random_state=42,
    eval_metric='auc'
)

print("🔄 Entrenando modelo XGBoost...")
modelo.fit(X_train, y_train)
print("✅ Modelo entrenado exitosamente")

# Evaluacion
y_pred = modelo.predict(X_test)
y_pred_proba = modelo.predict_proba(X_test)[:, 1]

print("=" * 60)
print("📊 REPORTE DE CLASIFICACIÓN (Recontacto)")
print("=" * 60)
print(classification_report(y_test, y_pred, target_names=['Resuelto (0)', 'Recontacta (1)']))
print(f"🎯 ROC-AUC Score: {roc_auc_score(y_test, y_pred_proba):.4f}")

```

    🔄 Entrenando modelo XGBoost...


    ✅ Modelo entrenado exitosamente


    ============================================================
    📊 REPORTE DE CLASIFICACIÓN (Recontacto)
    ============================================================
                    precision    recall  f1-score   support
    
      Resuelto (0)       0.69      0.52      0.59      8839
    Recontacta (1)       0.48      0.65      0.55      5946
    
          accuracy                           0.57     14785
         macro avg       0.58      0.58      0.57     14785
      weighted avg       0.60      0.57      0.57     14785
    
    🎯 ROC-AUC Score: 0.5929



```python
# Gráfico de Matriz de Confusión y Feature Importance
fig, axes = plt.subplots(1, 2, figsize=(16, 6))

# Matriz
cm = confusion_matrix(y_test, y_pred)
sns.heatmap(cm, annot=True, fmt='d', cmap='Blues', 
            xticklabels=['Resuelto (0)', 'Recontacta (1)'], 
            yticklabels=['Resuelto (0)', 'Recontacta (1)'], ax=axes[0])
axes[0].set_title('Matriz de Confusión')
axes[0].set_ylabel('Valor Real')
axes[0].set_xlabel('Predicción')

# Importancia
importancia = pd.DataFrame({'Variable': X.columns, 'Importancia': modelo.feature_importances_})
importancia = importancia.sort_values(by='Importancia', ascending=False).head(10)
sns.barplot(x='Importancia', y='Variable', data=importancia, palette='viridis', ax=axes[1])
axes[1].set_title('Top 10 Variables que Predicen Recontacto')

plt.tight_layout()
plt.show()

```

    /tmp/ipykernel_94/178285746.py:16: FutureWarning: 
    
    Passing `palette` without assigning `hue` is deprecated and will be removed in v0.14.0. Assign the `y` variable to `hue` and set `legend=False` for the same effect.
    
      sns.barplot(x='Importancia', y='Variable', data=importancia, palette='viridis', ax=axes[1])



    
![png](03_modelado_correcto_files/03_modelado_correcto_4_1.png)
    



## Archivo: 03_modelado.ipynb

# Modelado de Recontacto - XGBoost (Adaptación)
En lugar de predecir el abandono de vuelos, predeciremos si un ciudadano **volverá a contactar (recontacto_7_dias)**.


```python
import pyodbc
import pandas as pd
import os
import matplotlib.pyplot as plt
import seaborn as sns
from sklearn.model_selection import train_test_split
from sklearn.metrics import classification_report, confusion_matrix, roc_auc_score, roc_curve
from xgboost import XGBClassifier

# Cargar datos
conn = pyodbc.connect(f"DRIVER={{ODBC Driver 18 for SQL Server}};SERVER=db;DATABASE=ServicioCiudadanoDW;UID=SA;PWD=J0AhMXX4H0QBrRr8R1U098y8aA1@;TrustServerCertificate=yes;")
df = pd.read_sql("SELECT * FROM vw_v1_limpio", conn)
conn.close()

# Preparar variables
X = df.drop(columns=['id_interaccion', 'fecha_contacto', 'fecha_carga', 'recontacto_7_dias'])
y = df['recontacto_7_dias']

# One-hot encoding de las categóricas
columnas_texto = X.select_dtypes(include=['object']).columns
X = pd.get_dummies(X, columns=columnas_texto.tolist(), drop_first=True)

# Train/Test Split
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.20, random_state=42, stratify=y)
print(f"✅ Train: {X_train.shape[0]} | Test: {X_test.shape[0]}")

```

    /tmp/ipykernel_64/473542998.py:12: UserWarning: pandas only supports SQLAlchemy connectable (engine/connection) or database string URI or sqlite3 DBAPI2 connection. Other DBAPI2 objects are not tested. Please consider using SQLAlchemy.
      df = pd.read_sql("SELECT * FROM vw_v1_limpio", conn)


    /tmp/ipykernel_64/473542998.py:20: Pandas4Warning: For backward compatibility, 'str' dtypes are included by select_dtypes when 'object' dtype is specified. This behavior is deprecated and will be removed in a future version. Explicitly pass 'str' to `include` to select them, or to `exclude` to remove them and silence this warning.
    See https://pandas.pydata.org/docs/user_guide/migration-3-strings.html#string-migration-select-dtypes for details on how to write code that works with pandas 2 and 3.
      columnas_texto = X.select_dtypes(include=['object']).columns


    ✅ Train: 59138 | Test: 14785



```python
# Entrenar el modelo (XGBoost)
# Balanceo de clases (scale_pos_weight) es vital porque hay menos recontactos que resueltos
ratio_desbalance = (y_train == 0).sum() / (y_train == 1).sum()

modelo = XGBClassifier(
    n_estimators=300,
    max_depth=5,
    learning_rate=0.05,
    scale_pos_weight=ratio_desbalance, 
    random_state=42,
    eval_metric='auc'
)

print("🔄 Entrenando modelo XGBoost...")
modelo.fit(X_train, y_train)
print("✅ Modelo entrenado exitosamente")

# Evaluacion
y_pred = modelo.predict(X_test)
y_pred_proba = modelo.predict_proba(X_test)[:, 1]

print("=" * 60)
print("📊 REPORTE DE CLASIFICACIÓN (Recontacto)")
print("=" * 60)
print(classification_report(y_test, y_pred, target_names=['Resuelto (0)', 'Recontacta (1)']))
print(f"🎯 ROC-AUC Score: {roc_auc_score(y_test, y_pred_proba):.4f}")

```

    🔄 Entrenando modelo XGBoost...


    ✅ Modelo entrenado exitosamente


    ============================================================
    📊 REPORTE DE CLASIFICACIÓN (Recontacto)
    ============================================================
                    precision    recall  f1-score   support
    
      Resuelto (0)       0.68      0.52      0.59      8839
    Recontacta (1)       0.47      0.64      0.54      5946
    
          accuracy                           0.57     14785
         macro avg       0.57      0.58      0.56     14785
      weighted avg       0.60      0.57      0.57     14785
    
    🎯 ROC-AUC Score: 0.5842



```python
# Gráfico de Matriz de Confusión y Feature Importance
fig, axes = plt.subplots(1, 2, figsize=(16, 6))

# Matriz
cm = confusion_matrix(y_test, y_pred)
sns.heatmap(cm, annot=True, fmt='d', cmap='Blues', 
            xticklabels=['Resuelto (0)', 'Recontacta (1)'], 
            yticklabels=['Resuelto (0)', 'Recontacta (1)'], ax=axes[0])
axes[0].set_title('Matriz de Confusión')
axes[0].set_ylabel('Valor Real')
axes[0].set_xlabel('Predicción')

# Importancia
importancia = pd.DataFrame({'Variable': X.columns, 'Importancia': modelo.feature_importances_})
importancia = importancia.sort_values(by='Importancia', ascending=False).head(10)
sns.barplot(x='Importancia', y='Variable', data=importancia, palette='viridis', ax=axes[1])
axes[1].set_title('Top 10 Variables que Predicen Recontacto')

plt.tight_layout()
plt.show()

```

    /tmp/ipykernel_64/178285746.py:16: FutureWarning: 
    
    Passing `palette` without assigning `hue` is deprecated and will be removed in v0.14.0. Assign the `y` variable to `hue` and set `legend=False` for the same effect.
    
      sns.barplot(x='Importancia', y='Variable', data=importancia, palette='viridis', ax=axes[1])



    
![png](03_modelado_files/03_modelado_3_1.png)
    



## Archivo: 04_comparacion_modelos.ipynb

# Comparación de Modelos Predictivos
En este cuaderno, compararemos múltiples modelos (Random Forest vs XGBoost) para ver cuál predice mejor el riesgo de recontacto.


```python
from sklearn.linear_model import LogisticRegression
from sklearn.tree import DecisionTreeClassifier
import pyodbc
import pandas as pd
import os
import matplotlib.pyplot as plt
import seaborn as sns
from sklearn.model_selection import train_test_split
from sklearn.metrics import classification_report, roc_auc_score, roc_curve
from xgboost import XGBClassifier
from sklearn.ensemble import RandomForestClassifier

# Cargar y preparar datos
conn = pyodbc.connect(f"DRIVER={{ODBC Driver 18 for SQL Server}};SERVER=db;DATABASE=ServicioCiudadanoDW;UID=SA;PWD=J0AhMXX4H0QBrRr8R1U098y8aA1@;TrustServerCertificate=yes;")
df = pd.read_sql("SELECT * FROM vw_v1_limpio", conn)
conn.close()

X = df.drop(columns=['id_interaccion', 'fecha_contacto', 'fecha_carga', 'recontacto_7_dias'])
y = df['recontacto_7_dias']
X = pd.get_dummies(X, columns=X.select_dtypes(include=['object']).columns.tolist(), drop_first=True)
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.20, random_state=42, stratify=y)

ratio_desbalance = (y_train == 0).sum() / (y_train == 1).sum()

def evaluar_modelo(modelo, nombre):
    modelo.fit(X_train, y_train)
    y_pred_proba = modelo.predict_proba(X_test)[:, 1]
    auc = roc_auc_score(y_test, y_pred_proba)
    acc = modelo.score(X_test, y_test)
    return auc, acc, y_pred_proba

# Entrenar Regresion Logistica
lr = LogisticRegression(class_weight='balanced', random_state=42, max_iter=1000)
auc_lr, acc_lr, proba_lr = evaluar_modelo(lr, "Regresión Logística")

# Entrenar Arbol de Decision
dt = DecisionTreeClassifier(class_weight='balanced', random_state=42, max_depth=5)
auc_dt, acc_dt, proba_dt = evaluar_modelo(dt, "Árbol de Decisión")

# Entrenar Random Forest
rf = RandomForestClassifier(n_estimators=100, class_weight='balanced', random_state=42)
auc_rf, acc_rf, proba_rf = evaluar_modelo(rf, "Random Forest")

# Entrenar XGBoost
xgb = XGBClassifier(n_estimators=300, learning_rate=0.05, scale_pos_weight=ratio_desbalance, random_state=42, eval_metric='auc')
auc_xgb, acc_xgb, proba_xgb = evaluar_modelo(xgb, "XGBoost")
print("✅ Modelos entrenados")


```

    /tmp/ipykernel_351/1469150859.py:15: UserWarning: pandas only supports SQLAlchemy connectable (engine/connection) or database string URI or sqlite3 DBAPI2 connection. Other DBAPI2 objects are not tested. Please consider using SQLAlchemy.
      df = pd.read_sql("SELECT * FROM vw_v1_limpio", conn)


    /tmp/ipykernel_351/1469150859.py:20: Pandas4Warning: For backward compatibility, 'str' dtypes are included by select_dtypes when 'object' dtype is specified. This behavior is deprecated and will be removed in a future version. Explicitly pass 'str' to `include` to select them, or to `exclude` to remove them and silence this warning.
    See https://pandas.pydata.org/docs/user_guide/migration-3-strings.html#string-migration-select-dtypes for details on how to write code that works with pandas 2 and 3.
      X = pd.get_dummies(X, columns=X.select_dtypes(include=['object']).columns.tolist(), drop_first=True)


    ✅ Modelos entrenados



```python

print("=" * 70)
print("📊 COMPARACIÓN DE MÉTRICAS")
print("=" * 70)

fig, axes = plt.subplots(1, 2, figsize=(14, 5))

# ROC-AUC
axes[0].bar(['LogReg', 'Tree', 'RF', 'XGB'], [auc_lr, auc_dt, auc_rf, auc_xgb], color=['#2ecc71', '#f1c40f', '#3498db', '#e74c3c'])
axes[0].set_title('ROC-AUC', fontsize=14, fontweight='bold')
axes[0].set_ylim(0, 1.05)
for i, v in enumerate([auc_lr, auc_dt, auc_rf, auc_xgb]):
    axes[0].text(i, v + 0.02, f"{v:.3f}", ha='center', fontweight='bold')

# Curvas ROC
fpr_lr, tpr_lr, _ = roc_curve(y_test, proba_lr)
fpr_dt, tpr_dt, _ = roc_curve(y_test, proba_dt)
fpr_rf, tpr_rf, _ = roc_curve(y_test, proba_rf)
fpr_xgb, tpr_xgb, _ = roc_curve(y_test, proba_xgb)

axes[1].plot(fpr_lr, tpr_lr, color='#2ecc71', lw=2, label=f'LR (AUC = {auc_lr:.3f})')
axes[1].plot(fpr_dt, tpr_dt, color='#f1c40f', lw=2, label=f'DT (AUC = {auc_dt:.3f})')
axes[1].plot(fpr_rf, tpr_rf, color='#3498db', lw=2, label=f'RF (AUC = {auc_rf:.3f})')
axes[1].plot(fpr_xgb, tpr_xgb, color='#e74c3c', lw=2, label=f'XGB (AUC = {auc_xgb:.3f})')
axes[1].plot([0, 1], [0, 1], color='gray', lw=2, linestyle='--')
axes[1].set_title('Curvas ROC', fontweight='bold')
axes[1].legend(loc="lower right")

plt.tight_layout()
plt.show()

print(f"💡 CONCLUSIÓN: XGBoost sigue siendo el mejor modelo.")

```

    ======================================================================
    📊 COMPARACIÓN DE MÉTRICAS
    ======================================================================



    
![png](04_comparacion_modelos_files/04_comparacion_modelos_2_1.png)
    


    💡 CONCLUSIÓN: XGBoost sigue siendo el mejor modelo.

