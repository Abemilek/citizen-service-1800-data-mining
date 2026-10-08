import nbformat
import sys

nb_path = 'DataSetGenerator/citizen-analytics/notebooks/04_comparacion_modelos.ipynb'
try:
    with open(nb_path, 'r', encoding='utf-8') as f:
        nb = nbformat.read(f, as_version=4)

    # Buscar la celda de los imports y agregar LogisticRegression y DecisionTreeClassifier
    for cell in nb.cells:
        if cell.cell_type == 'code' and 'XGBClassifier' in cell.source:
            if 'LogisticRegression' not in cell.source:
                cell.source = cell.source.replace('from xgboost import XGBClassifier\n', 'from xgboost import XGBClassifier\nfrom sklearn.linear_model import LogisticRegression\nfrom sklearn.tree import DecisionTreeClassifier\n')
            break

    # Buscar la celda de entrenamiento
    for cell in nb.cells:
        if cell.cell_type == 'code' and 'Entrenar Random Forest' in cell.source:
            new_source = """
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
"""
            cell.source = new_source.strip()
            
    # Modify the plotting cell to include all 4 models
    for cell in nb.cells:
        if cell.cell_type == 'code' and 'plt.plot' in cell.source and 'fpr_rf' in cell.source:
            new_source = """
# Calcular curvas ROC
fpr_lr, tpr_lr, _ = roc_curve(y_test, proba_lr)
fpr_dt, tpr_dt, _ = roc_curve(y_test, proba_dt)
fpr_rf, tpr_rf, _ = roc_curve(y_test, proba_rf)
fpr_xgb, tpr_xgb, _ = roc_curve(y_test, proba_xgb)

plt.figure(figsize=(10, 8))
plt.plot(fpr_lr, tpr_lr, label=f'Regresión Logística (AUC = {auc_lr:.3f})')
plt.plot(fpr_dt, tpr_dt, label=f'Árbol de Decisión (AUC = {auc_dt:.3f})')
plt.plot(fpr_rf, tpr_rf, label=f'Random Forest (AUC = {auc_rf:.3f})')
plt.plot(fpr_xgb, tpr_xgb, label=f'XGBoost (AUC = {auc_xgb:.3f})', linewidth=2)

plt.plot([0, 1], [0, 1], 'k--', label='Aleatorio (AUC = 0.500)')
plt.xlabel('Tasa de Falsos Positivos')
plt.ylabel('Tasa de Verdaderos Positivos')
plt.title('Comparación de Curvas ROC - Predicción de Recontacto')
plt.legend(loc='lower right')
plt.grid(True, alpha=0.3)
plt.show()

# Imprimir resumen de AUC
print("=" * 40)
print("🏆 RESUMEN DE RENDIMIENTO (ROC-AUC)")
print("=" * 40)
print(f"1. XGBoost:            {auc_xgb:.4f} (Ganador)")
print(f"2. Random Forest:      {auc_rf:.4f}")
print(f"3. Regresión Logística:{auc_lr:.4f}")
print(f"4. Árbol de Decisión:  {auc_dt:.4f}")
"""
            cell.source = new_source.strip()
            
    with open(nb_path, 'w', encoding='utf-8') as f:
        nbformat.write(nb, f)
        
    print("Notebook modificado con exito!")
except Exception as e:
    print(f"Error: {e}")
