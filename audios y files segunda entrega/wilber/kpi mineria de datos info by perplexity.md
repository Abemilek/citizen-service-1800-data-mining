Con gusto te ayudo a entender qué es este caso.

**¿Qué es esto?**

Esto que tienes es un caso académico ficticio diseñado específicamente para la asignatura Integrador VIII de una universidad (muy probablemente la UNAN-Managua, por tu ubicación y el nombre del curso). No es una organización real ni un dataset público que puedas encontrar en internet.

## Estructura del caso

El documento simula ser un "expediente de Fase 0" que un analista recibiría en un proyecto real de mejora de procesos y análisis de datos en un centro de contacto (call center). Incluye:

* **Contexto organizacional**: Servicio Ciudadano 1800 (ficticio), con 420,000 interacciones anuales y 110 agentes.
* **Proceso AS-IS**: 6 pasos operativos desde la recepción del contacto hasta el reporte de calidad.
* **Dataset sintético**: 360 registros con 15 variables, incluyendo la variable objetivo recontacto\_7\_dias (si el usuario vuelve a contactar en 7 días por el mismo motivo).
* **Informes operativos**: Resúmenes neutrales por mes, canal, motivo y cola de servicio.
* **Restricciones**: Privacidad, trazabilidad, uso académico exclusivo.

## ¿Existe en la vida real?

**No como tal.** "Servicio Ciudadano 1800" es una organización ficticia creada para fines pedagógicos. Sin embargo, el caso está **inspirado en problemas reales** de centros de contacto:

* **Sí existen casos similares en la literatura académica**: Hay tesis y proyectos que analizan recontactos en call centers con datasets de aerolíneas, telecomunicaciones o servicios públicos.
* **Sí existen líneas 1800 reales**: Varios ministerios y gobiernos usan números tipo "1800-XXX" para atención ciudadana (ej. Ministerio de Educación en Ecuador: 1800-338222), pero no se llaman "Servicio Ciudadano 1800" como tal.
* **Sí existen datasets públicos de call centers**: En Kaggle, IBM Data Platform y repositorios universitarios hay datasets similares con variables como duración, canal, motivo, transferencias, etc.

## ¿Cuál sería su equivalente real?

Si quisieras buscar un caso real comparable para practicar o contrastar, podrías usar:

Elemento del caso ficticio: Organización multiservicio
Equivalente real más cercano: Centros de contacto de utilities (agua, luz), bancos, o ministerios con línea 1800.

Elemento del caso ficticio: Variable recontacto\_7\_dias
Equivalente real más cercano: Métrica real llamada "First Contact Resolution (FCR)" inversa o "Repeat Contact Rate".

Elemento del caso ficticio: Dataset con 15 variables
Equivalente real más cercano: Datasets públicos como "Call Center Data" en Kaggle o IBM.

Elemento del caso ficticio: Proceso de 6 pasos
Equivalente real más cercano: Procesos típicos de IVR → cola → agente → CRM → ticketing → calidad

## Referencia académica del curso

El curso **Integrador VIII** aparece en varios planes de estudio de la UNAN-Managua (Derecho, Ingeniería, Ciencias Sociales, etc.) y suele ser un proyecto integrador donde los estudiantes aplican conocimientos de análisis de procesos, calidad, minería de datos y gobierno de datos en un caso simulado.

**En resumen**: Es un caso 100% académico y sintético, pero muy bien estructurado para que practiques perfilado de datos, diagnóstico de calidad, diseño de KPIs, mapeo AS-IS/TO-BE y modelado predictivo sin riesgos de privacidad ni acceso a datos reales.

Luego le pregunte esto: ok ahora con este caso tengo que relacionarlo con una materia llamada mineria de datos?

La respuesta: Este caso está **diseñado específicamente para minería de datos**. Te explico cómo relacionarlo punto por punto:

## Relación directa con Minería de Datos

## 1. ****Problema de negocio → Problema de minería****

El caso tiene una **variable objetivo clara**: recontacto\_7\_dias (1 = usuario vuelve a contactar en 7 días, 0 = no vuelve) . Esto es exactamente lo que necesita un proyecto de minería de datos:

* **Tipo de problema**: Clasificación binaria (supervisado)
* **Objetivo predictivo**: Identificar qué interacciones tienen alta probabilidad de recontacto para mejorar la resolución en primer contacto (FCR - First Contact Resolution)
* **Equivalente en la literatura**: Similar a predicción de churn, fuga de clientes o morosidad, pero aplicado a recontactos en call center

## 2. ****Variables explicativas disponibles****

El dataset tiene **14 variables predictoras** típicas de minería de datos en CRM/contact centers:

Variable: cola\_servicio
Tipo: Categórica
Uso en minería: Segmentación (Facturación, Soporte, etc.)

Variable: canal
Tipo: Categórica
Uso en minería: Modo de contacto (Teléfono, Chat, etc.)

Variable: tipo\_usuario
Tipo: Categórica
Uso en minería: Perfil de cliente (Nuevo, Recurrente, etc.)

Variable: motivo\_contacto
Tipo: Categórica
Uso en minería: Razón del contacto (Falla, Cobro, Queja)

Variable: duracion\_seg
Tipo: Numérica
Uso en minería: Duración de la interacción

Variable: espera\_seg
Tipo: Numérica
Uso en minería: Tiempo en espera

Variable: transferencias
Tipo: Numérica
Uso en minería: Número de transferencias (0-4)

Variable: casos\_previos\_30d
Tipo: Numérica
Uso en minería: Historial reciente del usuario

Variable: turno
Tipo: Categórica
Uso en minería: Contexto temporal (AM, PM, Nocturno)

Variable: sistema\_origen
Tipo: Categórica
Uso en minería: Linaje del dato (ACD, CRM, etc.)

Variable: grabacion\_autorizada
Tipo: Categórica
Uso en minería: Gobierno/privacidad

Variable: fecha\_contacto
Tipo: Fecha
Uso en minería: Serie temporal

Variable: fecha\_carga
Tipo: Fecha
Uso en minería: Oportunidad de carga

Variable: id\_interaccion
Tipo: Texto
Uso en minería: Clave única

## 3. ****Técnicas de minería aplicables****

Según la literatura, para este tipo de problema puedes usar:

## ****Técnicas supervisadas (clasificación)****:

* **Árboles de decisión**: Interpretables, funcionan bien con variables mixtas (numéricas y categóricas)
* **Regresión logística**: Modelo estadístico clásico para variables binarias
* **Random Forest / Gradient Boosting**: Mejoran precisión combinando múltiples árboles
* **Redes neuronales**: Para patrones complejos no lineales
* **Naive Bayes**: Rápido, útil como baseline
* **K-Nearest Neighbors (KNN)**: Basado en similitud con casos históricos

## ****Técnicas descriptivas (exploración)****:

* **Análisis de asociación**: ¿Qué combinación de motivo + canal + cola predice recontacto?
* **Clustering**: Segmentar interacciones similares para descubrir patrones ocultos
* **Detección de anomalías**: Identificar registros atípicos (valores fuera de rango, duplicados)

## 4. ****Proceso CRISP-DM aplicable****

El caso sigue naturalmente las 6 fases del estándar CRISP-DM para minería de datos:

1. **Entendimiento del negocio**: Mejorar asignación, conocimiento y resolución (decisión institucional del caso)
2. **Entendimiento de datos**: Dataset v0 con 360 registros, 15 variables, diccionario incluido
3. **Preparación de datos**: Limpiar valores faltantes, normalizar etiquetas (ej. "Cobro" vs "COBRO"), eliminar duplicados
4. **Modelado**: Aplicar algoritmos de clasificación para predecir recontacto\_7\_dias
5. **Evaluación**: Métricas como accuracy, precision, recall, F1-score, AUC-ROC
6. **Despliegue**: Recomendaciones para reducir recontactos (mejorar guías, capacitación, routing)

## 5. ****KPIs de minería de datos para este caso****

Puedes calcular y optimizar:

* **Tasa de recontacto actual**: (Resultado = 1) / (Resultado conocido) por canal, motivo, cola
* **First Contact Resolution (FCR)**: 1 - tasa de recontacto (referencial: 78% según el caso)
* **Importancia de variables**: Qué variables pesan más en predecir recontacto (feature importance)
* **Matriz de confusión**: Verdaderos positivos, falsos positivos, etc.
* **Curva ROC y AUC**: Capacidad discriminativa del modelo

## 6. ****Patrones que puedes descubrir****

Ejemplos de hallazgos típicos en minería de call centers:

* "Las interacciones por **teléfono** con motivo **Falla** y **2+ transferencias** tienen 65% de probabilidad de recontacto"
* "Usuarios **recurrentes** en cola **Soporte** con **espera > 300 seg** recontactan 3x más"
* "El turno **nocturno** tiene menor recontacto pero mayor duración promedio"
* "Motivos no normalizados (ej. 'COBRO' vs 'Cobro') indican problemas de calidad en el registro"

## ¿Qué te pide probablemente la asignatura?

Basado en la estructura del caso y la bibliografía de minería de datos:

1. **Formular el problema**: "Predecir qué interacciones tendrán recontacto en 7 días para priorizar acciones de mejora en FCR"
2. **Perfilado de datos**: Identificar valores faltantes, duplicados, etiquetas inconsistentes (ej. "Cobro"/"COBRO")
3. **Análisis exploratorio**: Distribuciones, correlaciones, segmentaciones por canal/motivo/cola
4. **Selección de técnica**: Justificar por qué usas clasificación (variable binaria) y qué algoritmo eliges
5. **Modelado**: Entrenar/testear con métricas claras
6. **Interpretación**: ¿Qué variables son las más predictivas? ¿Qué acciones recomienda?

Luego le dije que investigue KPI o indicadores de rendimiento para mineria de datos y que lo relacionara con el chat que teníamos abierto, su repuesta:

# KPI e Indicadores de Rendimiento en Minería de Datos

## Definición precisa y objetivo

Un **KPI (Key Performance Indicator)** o indicador clave de rendimiento en minería de datos es una medida cuantitativa que evalúa qué tan bien un modelo predictivo o descriptivo está cumpliendo su objetivo de negocio. Su propósito es transformar el rendimiento técnico del modelo en información accionable para la toma de decisiones.

**Objetivo principal**: Determinar si el modelo es suficientemente preciso, confiable y útil para ser implementado en producción, y compararlo contra alternativas o benchmarks del sector.

## Contexto de uso

## Áreas de aplicación

Industria: Telecomunicaciones / Call centers
Uso típico de KPIs en minería de datos: Predecir churn, recontactos, abandono de llamadas

Industria: Banca y finanzas
Uso típico de KPIs en minería de datos: Detección de fraude, scoring crediticio, morosidad

Industria: Salud
Uso típico de KPIs en minería de datos: Diagnóstico temprano, predicción de readmisiones hospitalarias.

Industria: Retail y e-commerce
Uso típico de KPIs en minería de datos: Recomendación de productos, predicción de compra, segmentación

Industria: Manufactura
Uso típico de KPIs en minería de datos: Detección de defectos, mantenimiento predictivo

## Situaciones donde se aplican

* **Evaluación de modelos de clasificación** (binaria o multiclase)
* **Comparación de algoritmos** (árbol vs. regresión logística vs. red neuronal)
* **Selección de threshold óptimo** para decisiones binarias
* **Monitoreo de degradación** del modelo en producción (data drift)
* **Comunicación a stakeholders** no técnicos del valor del modelo

## Componentes fundamentales

## 1. Matriz de confusión (base de todos los KPIs de clasificación)

Para un problema **binario** (como recontacto\_7\_dias: 1 = sí recontacta, 0 = no recontacta), la matriz tiene 4 celdas:

Real: 0 (No recontacto)
Predicho: 0 (No recontacto): TN (Verdadero Negativo)
Predicho: 1 (Recontacto): FP (Falso Positivo)

Real: 1 (Recontacto)
Predicho: 0 (No recontacto): FN (Falso Negativo)
Predicho: 1 (Recontacto): TP (Verdadero Positivo)

**Definiciones**:

* **TP**: Casos que sí recontactan y el modelo predijo correctamente que recontactarían
* **TN**: Casos que no recontactan y el modelo predijo correctamente que no recontactarían
* **FP**: Casos que no recontactan pero el modelo predijo erróneamente que recontactarían (alarma falsa)
* **FN**: Casos que sí recontactan pero el modelo predijo erróneamente que no recontactarían (error crítico)

## 2. Totales derivados

* **P (Positivos reales)** = TP + FN
* **N (Negativos reales)** = TN + FP
* **Total de predicciones** = TP + TN + FP + FN

## KPIs principales: fórmulas, interpretación y cuándo usar cada uno

## Tabla resumen de métricas

1. KPI: Accuracy (Exactitud)
   Fórmula: ACC = (TP + TN) / (TP + TN + FP + FN)
   Rango: 0–1 (o 0–100%)
   Interpretación: Proporción total de predicciones correctas
   Cuándo priorizar: Dataset balanceado, costos de error similares

KPI: Precisión
Fórmula: Precision = TP / (TP + FP)
Rango: 0–1
Interpretación: De los que predije como positivos, ¿cuántos realmente lo son?
Cuándo priorizar: Cuando FP es costoso (ej. bloquear cliente bueno)

KPI: Recall (Sensibilidad)
Fórmula: Recall = TP / (TP + FN)
Rango: 0–1
Interpretación: De los positivos reales, ¿cuántos detecté?
Cuándo priorizar: Cuando FN es costoso (ej. no detectar fraude)

KPI: Especificidad
Fórmula: Especificidad = TN / (TN + FP)
Rango: 0–1
Interpretación: De los negativos reales, ¿cuántos identifiqué bien?
Cuándo priorizar: Cuando importa no alarmar innecesariamente

KPI: F1-Score
Fórmula: F1 = 2 × (Precision × Recall) / (Precision + Recall)
Rango: 0–1
Interpretación: Balance entre precisión y recall (media armónica)
Cuándo priorizar: Cuando hay trade-off y necesitas un solo número

KPI: AUC-ROC
Fórmula: Área bajo la curva ROC (TPR vs. FPR)
Rango: 0–1
Interpretación: Capacidad discriminativa del modelo en todos los thresholds
Cuándo priorizar: Comparar modelos, datasets desbalanceados

## Curva ROC y AUC

La curva ROC (Receiver Operating Characteristic) grafica:

* Eje X: Tasa de Falsos Positivos (FPR) = FPFP+TN=1−Especificidad\displaystyle \frac{FP}{FP + TN} = 1 - EspecificidadFP+TNFP​=1−Especificidad
* Eje Y: Tasa de Verdaderos Positivos (TPR) = Recall = Sensibilidad

Interpretación del AUC:

* AUC = 1.0: Clasificación perfecta
* AUC = 0.5: Modelo aleatorio (sin poder predictivo)
* AUC < 0.5: Modelo peor que aleatorio (invertir predicciones)
* AUC > 0.8: Modelo bueno
* AUC > 0.9: Modelo excelente

## KPIs específicos para call centers (contexto de tu caso)

## KPIs operativos del negocio

KPI: FCR (First Contact Resolution)
Fórmula: (Casos resueltos en 1ra interacción / Total de casos) × 100
Benchmark típico: 78–85% gurusup+1
Relación con minería de datos: Variable objetivo inversa: recontacto\_7\_dias = 1 - FCR

KPI: Tasa de recontacto
Fórmula: (Recontactos en 7 días / Total interacciones) × 100
Benchmark típico: < 22% (si FCR = 78%) callcoachiq+1
Relación con minería de datos: Output directo del modelo predictivo

KPI: Tasa de abandono
Fórmula: (Llamadas abandonadas / Total llamadas entrantes) × 100
Benchmark típico: < 6–8% justcall+1
Relación con minería de datos: Variable secundaria a predecir

KPI: AHT (Average Handle Time)
Fórmula: Σ duración\_seg / Total interacciones
Benchmark típico: Varía por industria justcall
Relación con minería de datos: Feature del modelo (duración larga → más recontacto)

## Procedimiento paso a paso para calcular KPIs

## Paso 1: Preparar datos de prueba

* Dividir dataset en **train** (70–80%) y **test** (20–30%)
* Entrenar modelo con train
* Generar predicciones sobre test (nunca evaluar sobre train)

## Paso 2: Generar predicciones

* Obtener **predicciones de clase** (0 o 1) para clasificación dura
* O obtener **probabilidades** (0.0–1.0) para curvas ROC y ajuste de threshold

## Paso 3: Construir matriz de confusión

Comparar predicciones vs. valores reales en el dataset de test.

## Paso 4: Calcular métricas

Aplicar fórmulas de la tabla anterior usando los valores TP, TN, FP, FN.

## Paso 5: Interpretar y comparar

* Comparar contra **baseline** (ej. modelo que siempre predice la clase mayoritaria)
* Comparar contra **benchmarks del sector** (ej. FCR > 78% en call centers)
* Comparar **múltiples algoritmos** (árbol vs. regresión logística vs. random forest)

## Paso 6: Seleccionar threshold óptimo (si aplica)

* Si el modelo entrega probabilidades, ajustar el threshold para maximizar F1 o minimizar costo de error
* Usar curva ROC para visualizar trade-off entre TPR y FPR

## Ejemplo práctico completo (Caso 15: Servicio Ciudadano 1800)

## Contexto

Tienes 360 registros del dataset C15\_CallCenter con la variable objetivo recontacto\_7\_dias .

## Paso 1: Dividir datos

* **Train**: 252 registros (70%)
* **Test**: 108 registros (30%)

## Paso 2: Entrenar modelo (ej. árbol de decisión)

El modelo aprende patrones como:

* "Si transferencias ≥ 2 y motivo\_contacto = Falla → alta probabilidad de recontacto"
* "Si canal = Chat y espera\_seg < 100 → baja probabilidad de recontacto"

## Paso 3: Predicciones sobre test

Supongamos que obtienes esta **matriz de confusión** en los 108 registros de test:

Real: 0 (No recontacto)
Predicho: 0: TN = 52
Predicho: 1: FP = 8

Real: 1 (Recontacto)
Predicho: 0: FN = 12
Predicho: 1: TP = 36

**Totales**:

* Positivos reales (P) = TP + FN = 36 + 12 = 48
* Negativos reales (N) = TN + FP = 52 + 8 = 60
* Total = 108

## Paso 4: Calcular KPIs

Accuracy:

ACC = (TP + TN) / Total

ACC = (36 + 52) / 108

ACC = 88 / 108

ACC = 0.815

ACC = 81.5%

Precisión:

Precisión = 0.818 TP / (TP + FP)

Precisión = 36 / (36 + 8)

Precisión = 36 / 44

Precisión = 0.818

Precisión = 81.8%

Recall (Sensibilidad):

Recall = TP / (TP + FN)

Recall = 36 / (36 + 12)

Recall = 36 / 48

Recall = 0.75

Recall = 75%

Especificidad:

Especificidad = TN / (TN + FP)

Especificidad = 52 / (52 + 8)

Especificidad = 52 / 60

Especificidad = 0.867

Especificidad = 86.7%

F1-Score:

F1 = 2 × (Precisión × Recall) / (Precisión + Recall)

F1 =78. 2 × (0.818 × 0.75) / (0.818 + 0.75)

F1 = 2 × 0.6135 / 1.568

F1 = 1.227 / 1.568

F1 = 0.782

F1 = 78.2%

Tasa de recontacto predicha:

TP + FP = 36 + 8

TP + FP = 44

Porcentaje = 44 / 108

Porcentaje = 0.407

Porcentaje = 40.7%

FCR estimado (inverso):

FCR = 1 - 0.407

FCR = 0.593

FCR = 59.3%

Resultado: FCR = 59.3%, por debajo del benchmark de 78% [7][12]

## Paso 5: Interpretación

* **Accuracy 81.5%**: El modelo acierta 8 de cada 10 predicciones
* **Precisión 81.8%**: Cuando predice recontacto, 82% de las veces es correcto
* **Recall 75%**: Detecta 3 de cada 4 recontactos reales (25% se le escapan)
* **F1 78.2%**: Balance aceptable entre precisión y recall
* **FCR 59.3%**: Muy por debajo del estándar de 78% → el centro de contacto tiene problema grave de resolución en primer contacto

## Paso 6: Recomendaciones de negocio

1. **Priorizar capacitación** en motivos con alto recontacto (ej. "Falla" con 39/80 = 48.7% de recontacto según Informe 3 del caso )
2. **Reducir transferencias**: Las interacciones con 2+ transferencias tienen mayor probabilidad de recontacto
3. **Mejorar guías de conocimiento** para colas con bajo FCR (ej. Información: 40/95 = 42.1% de recontacto)
4. **Implementar routing inteligente**: Derivar casos complejos a agentes senior desde el inicio

## Cómo interpretar el resultado final

## Escalas de interpretación general

Rango de AUC / F1: 0.90–1.00
Calidad del modelo: Excelente
Acción recomendada: Implementar en producción

Rango de AUC / F1: 0.80–0.89
Calidad del modelo: Bueno
Acción recomendada: Implementar con monitoreo

Rango de AUC / F1: 0.70–0.79
Calidad del modelo: Aceptable
Acción recomendada: Mejorar features o probar otro algoritmo

Rango de AUC / F1: 0.60–0.69
Calidad del modelo: Regular
Acción recomendada: Revisar calidad de datos o ingeniería de features

Rango de AUC / F1: < 0.60
Calidad del modelo: Pobre
Acción recomendada: Descartar o reformular problema

## Interpretación contextual (call center)

* **Si Recall es bajo** (< 70%): El modelo está dejando escapar muchos recontactos → capacitar agentes en detección temprana
* **Si Precisión es baja** (< 70%): El modelo está alarmando en falso → revisar threshold o features
* **Si FCR < 78%**: Hay problema operativo grave, independiente del modelo

## Ventajas, limitaciones y supuestos clave

## Ventajas

* **Objetividad**: Métricas cuantitativas comparables entre modelos
* **Acción**: Vincula rendimiento técnico con impacto de negocio
* **Comunicación**: Facilita explicar valor del modelo a no técnicos
* **Optimización**: Permite ajustar threshold según costos de error

## Limitaciones

* **Dependencia del dataset**: Métricas pueden cambiar con diferentes datos de test
* **Sensibilidad al desbalance**: Accuracy puede ser engañoso si una clase domina (ej. 90% no recontactan)
* **No capturan costo real**: Un FP puede costar $10 y un FN $1000, pero las métricas estándar no lo reflejan
* **Requieren datos etiquetados**: No aplican directamente a minería no supervisada (clustering)

## Supuestos clave

1. **Datos de test son representativos** de la población real
2. **Las etiquetas (y) son correctas** (no hay ruido en la variable objetivo)
3. **Distribución estacionaria**: Los patrones no cambian drásticamente con el tiempo (no hay data drift)
4. **Independencia de observaciones**: Cada registro es independiente de los demás

Errores comunes y cómo evitarlos

Error: Evaluar sobre datos de train
Consecuencia: Overfitting, métricas infladas
Cómo evitarlo: Usar siempre test set o cross-validation

Error: Usar accuracy con datasets desbalanceados
Consecuencia: Modelo parece bueno pero no detecta clase minoritaria
Cómo evitarlo: Usar F1, AUC, o métricas por clase

Error: Ignorar costos de negocio
Consecuencia: Optimizar métrica técnica pero no impacto real
Cómo evitarlo: Definir matriz de costos (FP vs. FN) antes de elegir threshold

Error: No establecer baseline
Consecuencia: No saber si el modelo es mejor que algo simple
Cómo evitarlo: Comparar contra modelo que siempre predice clase mayoritaria

Error: Reportar solo una métrica
Consecuencia: Visión incompleta del rendimiento
Cómo evitarlo: Reportar al menos: Accuracy, Precisión, Recall, F1, AUC

Error: No validar con datos temporales
Consecuencia: Modelo funciona en pasado pero no en futuro
Cómo evitarlo: Usar train-test por tiempo (ej. train: ene-may, test: jun)

## Recomendaciones para proyectos universitarios

## 1. Estructura del informe técnico

* **Sección de métricas**: Incluir tabla con todas las métricas principales para cada modelo probado
* **Matriz de confusión**: Mostrar al menos para el modelo final seleccionado
* **Curva ROC**: Incluir gráfica con AUC reportado
* **Comparativa**: Tabla comparando 2–3 algoritmos (ej. árbol, regresión logística, random forest)

## 2. Buenas prácticas

* **Justificar elección de métrica**: Explicar por qué priorizas F1 sobre accuracy (ej. "dataset desbalanceado con 30% recontactos")
* **Incluir baseline**: Mostrar métricas de un modelo trivial para contextualizar
* **Validación cruzada**: Si el dataset es pequeño (< 500 registros), usar k-fold cross-validation (k=5 o 10)
* **Reproducibilidad**: Reportar seed aleatorio, versión de librerías, y división train-test exacta

## 3. Errores a evitar en entregas académicas

* ❌ No reportar tamaño de train/test
* ❌ No mencionar si hubo desbalance de clases
* ❌ No comparar contra baseline
* ❌ No interpretar métricas en contexto de negocio
* ❌ No mencionar limitaciones del enfoque

## 4. Checklist mínimo para tu caso (Caso 15)

* Calcular distribución de recontacto\_7\_dias (¿hay desbalance?)
* Reportar matriz de confusión del modelo final
* Calcular Accuracy, Precisión, Recall, F1, AUC
* Comparar FCR estimado vs. benchmark de 78%
* Interpretar qué significa para el centro de contacto
* Recomendar 2–3 acciones concretas basadas en los KPIs

## Conclusión

Los KPIs en minería de datos son el puente entre el rendimiento técnico del modelo y el valor de negocio. Para problemas de clasificación binaria como tu caso de recontactos en call center, las métricas esenciales son **Accuracy, Precisión, Recall, F1-Score y AUC-ROC**, todas derivadas de la **matriz de confusión**.

La clave no es maximizar una métrica en abstracto, sino **seleccionar y optimizar la métrica que mejor refleje los costos reales de error** en tu contexto (ej. en call centers, un FN puede significar un cliente insatisfecho que abandona, mientras que un FP puede ser solo una llamada preventiva innecesaria). Para tu caso específico, además de las métricas técnicas, debes reportar **FCR estimado** y compararlo contra el benchmark de 78% para demostrar impacto operativo.