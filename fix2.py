import nbformat
nb_path = 'DataSetGenerator/citizen-analytics/notebooks/04_comparacion_modelos.ipynb'
with open(nb_path, 'r', encoding='utf-8') as f:
    nb = nbformat.read(f, as_version=4)

c1 = nb.cells[1].source
if 'LogisticRegression(' not in c1:
    c1 = c1.replace('# Entrenar Random Forest', '''# Entrenar Regresion Logistica
lr = LogisticRegression(class_weight='balanced', random_state=42, max_iter=1000)
auc_lr, acc_lr, proba_lr = evaluar_modelo(lr, "Regresión Logística")

# Entrenar Arbol de Decision
dt = DecisionTreeClassifier(class_weight='balanced', random_state=42, max_depth=5)
auc_dt, acc_dt, proba_dt = evaluar_modelo(dt, "Árbol de Decisión")

# Entrenar Random Forest''')
    nb.cells[1].source = c1

with open(nb_path, 'w', encoding='utf-8') as f:
    nbformat.write(nb, f)
