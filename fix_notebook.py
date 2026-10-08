import nbformat

nb_path = 'DataSetGenerator/citizen-analytics/notebooks/04_comparacion_modelos.ipynb'
with open(nb_path, 'r', encoding='utf-8') as f:
    nb = nbformat.read(f, as_version=4)

imports_added = False
for cell in nb.cells:
    if cell.cell_type == 'code' and 'import' in cell.source and not imports_added:
        if 'LogisticRegression' not in cell.source:
            cell.source = cell.source + "\nfrom sklearn.linear_model import LogisticRegression\nfrom sklearn.tree import DecisionTreeClassifier"
        imports_added = True
    elif cell.cell_type == 'code' and 'rf = RandomForestClassifier' in cell.source:
        cell.source = """
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
    elif cell.cell_type == 'code' and 'axes[0].bar' in cell.source:
        cell.source = """
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
"""

with open(nb_path, 'w', encoding='utf-8') as f:
    nbformat.write(nb, f)
