import nbformat as nbf
import os

# Create 01_EDA_KPIs.ipynb
nb1 = nbf.v4.new_notebook()
text1 = """# Análisis Exploratorio (EDA) y Medición de KPIs - Servicio Ciudadano 1800
Este notebook se conecta al Data Warehouse (`ServicioCiudadanoDW`) para extraer los datos limpios y responder a los KPIs de negocio establecidos."""
code1 = """import os
import pyodbc
import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sns

sns.set_theme(style="whitegrid")

# Configurar conexión usando variables de entorno (Docker)
server = os.getenv('DB_SERVER', 'localhost')
database = os.getenv('DB_NAME', 'ServicioCiudadanoDW')
username = os.getenv('DB_USER', 'SA')
password = os.getenv('DB_PASSWORD', 'J0AhMXX4H0QBrRr8R1U098y8aA1@')
driver = os.getenv('DB_DRIVER', '{ODBC Driver 18 for SQL Server}')

connection_string = f'DRIVER={driver};SERVER={server};DATABASE={database};UID={username};PWD={password};TrustServerCertificate=yes;'

print("Conectando a BD...")
conn = pyodbc.connect(connection_string)

# Extraer datos limpios de la vista
query = "SELECT * FROM vw_v1_limpio"
df = pd.read_sql(query, conn)
conn.close()

print(f"Total de registros limpios: {len(df)}")
df.head()
"""
code1_kpis = """# KPI 1 & 2: Tasa de Recontacto (TR7) y FCR Estimado
tr7 = df['recontacto_7_dias'].mean() * 100
fcr = 100 - tr7

print(f"--- KPI 1: Tasa de Recontacto a 7 días (TR7) ---")
print(f"Valor Actual: {tr7:.2f}% (Meta: <= 22%)")
print(f"--- KPI 2: FCR Estimado ---")
print(f"Valor Actual: {fcr:.2f}% (Meta: >= 78%)")
"""
code1_kpi3 = """# KPI 3: Tasa de Recontacto por Canal
plt.figure(figsize=(10,5))
canal_recontacto = df.groupby('canal')['recontacto_7_dias'].mean() * 100
canal_recontacto.sort_values(ascending=False).plot(kind='bar', color='salmon')
plt.title('KPI 3: Tasa de Recontacto por Canal')
plt.ylabel('% Recontacto')
plt.axhline(46, color='red', linestyle='--', label='Límite de riesgo (46%)')
plt.legend()
plt.show()
"""

nb1['cells'] = [
    nbf.v4.new_markdown_cell(text1),
    nbf.v4.new_code_cell(code1),
    nbf.v4.new_code_cell(code1_kpis),
    nbf.v4.new_code_cell(code1_kpi3)
]
with open('01_EDA_KPIs.ipynb', 'w') as f:
    nbf.write(nb1, f)

# Create 02_Modelado_Recontacto.ipynb
nb2 = nbf.v4.new_notebook()
text2 = """# Modelado Predictivo - Recontacto en 7 días
Objetivo: Predecir la variable objetivo `recontacto_7_dias` utilizando diferentes algoritmos y encontrar los factores más determinantes."""
code2 = """import os
import pyodbc
import pandas as pd
from sklearn.model_selection import train_test_split
from sklearn.preprocessing import StandardScaler, OneHotEncoder
from sklearn.compose import ColumnTransformer
from sklearn.pipeline import Pipeline
from sklearn.ensemble import RandomForestClassifier
from sklearn.linear_model import LogisticRegression
from sklearn.metrics import classification_report, roc_auc_score

# Conexión
connection_string = f"DRIVER={os.getenv('DB_DRIVER', '{ODBC Driver 18 for SQL Server}')};SERVER={os.getenv('DB_SERVER', 'localhost')};DATABASE={os.getenv('DB_NAME', 'ServicioCiudadanoDW')};UID={os.getenv('DB_USER', 'SA')};PWD={os.getenv('DB_PASSWORD', 'J0AhMXX4H0QBrRr8R1U098y8aA1@')};TrustServerCertificate=yes;"
conn = pyodbc.connect(connection_string)
df = pd.read_sql("SELECT * FROM vw_v1_limpio", conn)
conn.close()

# Preparación de datos
X = df.drop(columns=['id_interaccion', 'fecha_contacto', 'fecha_carga', 'recontacto_7_dias'])
y = df['recontacto_7_dias']

# Separar numéricas y categóricas
num_cols = ['duracion_seg', 'espera_seg', 'casos_previos_30d', 'nivel_transferencias']
cat_cols = ['canal', 'motivo_contacto', 'cola_servicio', 'grabacion_autorizada', 'tipo_usuario', 'turno']

preprocessor = ColumnTransformer(
    transformers=[
        ('num', StandardScaler(), num_cols),
        ('cat', OneHotEncoder(drop='first', handle_unknown='ignore'), cat_cols)
    ])

X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42, stratify=y)
print("Datos preparados.")
"""
code2_train = """# Modelo 1: Random Forest
rf = Pipeline([
    ('preprocessor', preprocessor),
    ('classifier', RandomForestClassifier(n_estimators=100, random_state=42))
])

rf.fit(X_train, y_train)
y_pred_rf = rf.predict(X_test)
print("--- Random Forest Report ---")
print(classification_report(y_test, y_pred_rf))
print(f"ROC AUC: {roc_auc_score(y_test, rf.predict_proba(X_test)[:,1]):.4f}")
"""

nb2['cells'] = [
    nbf.v4.new_markdown_cell(text2),
    nbf.v4.new_code_cell(code2),
    nbf.v4.new_code_cell(code2_train)
]
with open('02_Modelado_Recontacto.ipynb', 'w') as f:
    nbf.write(nb2, f)
print("Notebooks creados.")
