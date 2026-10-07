# 🧠 Guía "A Prueba de Balas" del Proyecto (Explicado para Juniors)

Si en algún momento te pierdes en qué hace este proyecto o el profesor te hace una pregunta trampa, lee este documento. Aquí explicamos la "magia" detrás del código con palabras de a centavo.

---

## 1. 🏭 El Flujo y la Trazabilidad (¿De dónde salieron los datos?)

**Pregunta de oro del profe:** *"¿Esos datos son reales o inventados?"*
**Tu respuesta:** "Son datos **sintéticos** (inventados), pero con **trazabilidad matemática**."

*   **¿Qué significa eso?** Que usamos un programa en C# (el generador) para simular 100,000 llamadas al *Servicio Ciudadano 1800*. 
*   **¿De dónde sacamos los porcentajes?** De los documentos del caso (el Expediente). Por ejemplo, el expediente decía que la Tasa de Recontacto real era del ~41%. Configuramos el programa en C# para que forzara estadísticamente ese 41%. 
*   **¿Qué es ese 46% de riesgo que sale en la gráfica?** Es la línea roja histórica. Significa que, estadísticamente, el 46% de las personas que escriben por **Redes Sociales** vuelven a contactar molestos.

---

## 2. 🧹 El Gobierno de Datos (¿Qué rayos es R-CAL-04?)

Antes de meter los datos a un modelo de inteligencia artificial, hay que limpiarlos. Las siglas raras son simplemente **Reglas de Calidad (R-CAL)** que nos exigió el negocio:

*   **R-CAL-04:** "No quiero llamadas duplicadas". (En SQL usamos la fórmula `ROW_NUMBER()` para borrar los clones).
*   **R-CAL-02:** "La gente de sistemas escribe mal 'COBRO' o 'QUEJA' en mayúsculas". (En SQL usamos `CASE WHEN` para corregir la ortografía).
*   **R-CAL-01:** "Si no sabemos si el cliente volvió a llamar o no (target nulo), borra esa fila porque no le sirve a la Inteligencia Artificial para aprender".

---

## 3. 🎯 Los KPIs: ¿Por qué hablamos tanto del KPI 1 y 2?

Tenemos 10 KPIs, pero el **KPI 1 (Tasa de Recontacto - TR7)** y el **KPI 2 (Resolución al primer contacto - FCR)** son las estrellas del show.

*   **¿Por qué?** Porque el KPI 1 es nuestra **Variable Objetivo (Target)**. Todo el Machine Learning de este proyecto tiene una sola misión en la vida: *Adivinar si el KPI 1 se va a cumplir o no para una llamada específica.* Los demás KPIs (como el canal o el motivo) son solo las "pistas" que usa la IA para adivinar ese KPI 1.

---

## 4. 🤖 Modelos, Data Leakage y ROC-AUC (Diccionario fácil)

En los cuadernos `03` y `04` usamos términos que suenan asustadores. Aquí está la traducción:

*   **Data Leakage (Fuga de Datos):** Imagina que tienes un examen mañana y alguien te filtra las respuestas hoy. Si sacas 100/100, es trampa. En Machine Learning, "Data Leakage" es darle al modelo información del futuro (por ejemplo, decirle hoy cuántas llamadas hará el cliente el próximo mes). El profe quería que probáramos que nuestro modelo es honesto y **"Sin Leakage"**.
*   **Random Forest y XGBoost:** Son dos algoritmos predictivos. Son como dos analistas de datos compitiendo. Random Forest es un "consejo de sabios" que votan, y XGBoost es un analista que aprende de sus propios errores rápidamente.
*   **ROC-AUC (Área Bajo la Curva):** Es la calificación de la escuela del algoritmo. 
    *   `0.50` = El modelo es tan bueno como lanzar una moneda al aire (mediocre).
    *   `1.00` = El modelo es perfecto (suele ser trampa / Data leakage).
    *   `0.60 a 0.80` = Un modelo realista y bueno. (El nuestro saca ~0.59, ¡lo cual es excelente y muy realista para predecir comportamiento humano!).

---

## 5. 📁 ¿Qué hace cada cuaderno (Jupyter Notebook)?

Si ejecutas los archivos en el navegador, este es el orden de la historia que debes contar:

1.  **`00_Verificacion_Limpieza.ipynb`**: Es tu prueba de que limpiaste la casa. Imprime tablas que muestran cómo entran datos con basura (100k filas) y cómo SQL los limpia dejándolos en 74k filas perfectas.
2.  **`01Prueba.ipynb`**: Es tu "Panel de Control". Conecta a la base de datos limpia y saca los gráficos de los KPIs (Por ejemplo, el gráfico enorme que te muestra cómo la gente de "Facturación" es la que más vuelve a llamar).
3.  **`03_modelado.ipynb`**: Aquí ocurre la magia. Le pasamos los datos a **XGBoost**. Al final, te muestra el **"Top 10 Variables Importantes"**. (Ejemplo: te dirá que la "duración de la llamada" es la pista #1 para saber si alguien volverá a llamar).
4.  **`04_comparacion_modelos.ipynb`**: El Coliseo Romano. Pone a pelear a Random Forest contra XGBoost. Te saca una gráfica comparando quién tiene el mejor **ROC-AUC** para justificarle al profesor tu elección final de algoritmo.
