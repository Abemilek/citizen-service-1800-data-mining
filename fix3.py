import nbformat
nb_path = 'DataSetGenerator/citizen-analytics/notebooks/04_comparacion_modelos.ipynb'
with open(nb_path, 'r', encoding='utf-8') as f:
    nb = nbformat.read(f, as_version=4)

c1 = nb.cells[1].source
c1 = c1.replace("from sklearn.linear_model import LogisticRegression\nfrom sklearn.tree import DecisionTreeClassifier", "")
c1 = "from sklearn.linear_model import LogisticRegression\nfrom sklearn.tree import DecisionTreeClassifier\n" + c1
nb.cells[1].source = c1

with open(nb_path, 'w', encoding='utf-8') as f:
    nbformat.write(nb, f)
