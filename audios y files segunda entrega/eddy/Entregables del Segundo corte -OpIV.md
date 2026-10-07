**GUÍA DE ENTREGA**

**MARCO DE GOBIERNO DE DATOS V2**

**Componente:** Optativa IV – Gobierno de Datos
**BOA 2:** Diseño del Marco de Gobierno de Datos

1. **Propósito del trabajo**

El equipo deberá **integrar, revisar y mejorar** los productos desarrollados durante las semanas 6, 7, 8 y 9 para construir una segunda versión del **Marco de Gobierno de Datos**, aplicada al caso organizacional asignado.

El Marco V2 debe demostrar cómo el Gobierno de Datos contribuye a que los datos utilizados en el **proceso analítico de Minería de Datos** sean identificables, confiables, protegidos, trazables y utilizados de acuerdo con las necesidades de la organización.

**Importante:** El Marco V2 no consiste en copiar y pegar las actividades anteriores. Los productos deben revisarse, corregirse y relacionarse entre sí.

1. **Secuencia que debe demostrar el Marco V2**

El trabajo debe evidenciar la siguiente relación:

1. **Objetivos de la organización**
2. **Proceso analítico**
3. **Datos necesarios**
4. **Riesgos asociados**
5. **Responsables**
6. **Políticas**
7. **Reglas**
8. **Controles**
9. **Descripción y clasificación de los datos**
10. **Trazabilidad**
11. **Ciclo de vida**
12. **Aplicación al proceso de Minería de Datos**
13. **Estructura obligatoria del documento**

## Portada

Debe incluir:

* Universidad.
* Centro Universitario Regional.
* Carrera.
* Componente curricular.
* Nombre del proyecto/caso.
* Título: **Marco de Gobierno de Datos V2**.
* Integrantes.
* Docente.
* Fecha.

## Contexto y alcance

Actualizar el contexto trabajado en el Marco V1.

Debe explicar:

* organización o caso;
* problema identificado;
* proceso que será analizado;
* objetivo del proceso analítico;
* datos involucrados;
* alcance del Gobierno de Datos;
* áreas o actores involucrados.

## Pregunta orientadora

¿Qué parte de la organización y qué datos estamos gobernando?

1. **Alineación estratégica**

Integrar la **Matriz de Alineación Estratégica de la Semana 7**.

Debe demostrar:

Objetivo organizacional → objetivo analítico → datos necesarios → necesidad de Gobierno de Datos.

## Evidencia

**Matriz de alineación estratégica actualizada.**

1. **Inventario de datos**

Presentar los principales datos utilizados o requeridos por el proceso analítico.

|  |  |  |  |  |
| --- | --- | --- | --- | --- |
| Dato | Fuente | Proceso | Uso analítico | Responsable |
| Fecha | Sistema | Ventas | Análisis temporal | Ventas |
| Producto | Catálogo | Ventas | Segmentación | Inventario |
| Cantidad | Ventas | Ventas | Análisis | Ventas |

A) Dato: Fecha, B) Fuente: Sistema, C) Proceso: Ventas, D) Uso analítico: Análisis temporal, E) Responsable: Ventas
A) Dato: Producto, B) Fuente: Catálogo, C) Proceso: Ventas, D) Uso analítico: Segmentación, E) Responsable: Inventario
A) Dato: Cantidad, B) Fuente: Ventas, C) Proceso: Ventas, D) Uso analítico: Análisis, E) Responsable: Ventas

Debe existir correspondencia con el proceso de Minería de Datos.

1. **Actores involucrados**

Identificar:

* propietarios de datos;
* responsables de datos;
* usuarios;
* responsables del proceso;
* personal técnico;
* otros actores pertinentes.

## Evidencia

**Mapa de actores actualizado.**

1. **Roles y responsabilidades**

Incluir:

* Data Owner;
* Data Steward;
* responsables de procesos;
* usuarios;
* responsables técnicos, cuando corresponda.

## Evidencia

**Matriz de roles y responsabilidades.**

1. **Matriz RACI**

Integrar el RACI desarrollado anteriormente.

Debe mostrar quién:

* **R:** ejecuta;
* **A:** responde/aprueba;
* **C:** es consultado;
* **I:** es informado.

Debe estar relacionado con actividades reales del Gobierno de Datos del caso.

1. **Matriz de riesgos y beneficios**

Recuperar y mejorar el producto de la **Semana 6**.

Debe contener:

|  |  |  |  |  |  |
| --- | --- | --- | --- | --- | --- |
| Riesgo | Probabilidad | Impacto | Nivel | Tratamiento | Política relacionada |
| Datos incompletos | Alta | Alta | Alto | Validación | POL-CAL-01 |
| Duplicidad | Media | Alta | Alto | Control de duplicados | POL-CAL-01 |

A) Riesgo: Datos incompletos, B) Probabilidad: Alta, C) Impacto: Alta, D) Nivel: Alto, E) Tratamiento: Validación, F) Política relacionada: POL-CAL-01
A) Riesgo: Duplicidad, B) Probabilidad: Media, C) Impacto: Alta, D) Nivel: Alto, E) Tratamiento: Control de duplicados, F) Política relacionada: POL-CAL-01

La versión V2 debe demostrar que los riesgos **tienen respuesta dentro del marco**.

1. **Políticas de Gobierno de Datos**

Integrar las políticas desarrolladas en la **Semana 8**.

Cada política debe incluir:

* código;
* nombre;
* objetivo;
* alcance;
* datos afectados;
* responsable;
* declaración;
* justificación.

Ejemplo:

**POL-CAL-01 – Política de calidad de datos:** Los datos utilizados en el proceso analítico deberán cumplir las condiciones de calidad definidas por la organización antes de ser utilizados para generar resultados.

1. **Reglas de Gobierno de Datos**

Las políticas deben traducirse en reglas concretas.

Ejemplo:

**Política:**
Los datos deben ser completos.

**Regla:**
Todo registro de venta debe contener fecha, producto y cantidad.

**Control:**
Los registros incompletos deben ser identificados antes de ingresar al conjunto de datos analítico.

1. **Controles y guardrails**

Incluir los controles diseñados en la Semana 8.

|  |  |  |
| --- | --- | --- |
| Regla | Control/guardrail | Evidencia |
| Fecha obligatoria | Validación de campo | Reporte de errores |
| Producto válido | Validación contra catálogo | Reporte de inconsistencias |
| Acceso por rol | Control de permisos | Registro de accesos |

A) Regla: Fecha obligatoria, B) Control/guardrail: Validación de campo, C) Evidencia: Reporte de errores
A) Regla: Producto válido, B) Control/guardrail: Validación contra catálogo, C) Evidencia: Reporte de inconsistencias
A) Regla: Acceso por rol, B) Control/guardrail: Control de permisos, C) Evidencia: Registro de accesos.

No es obligatorio programar estos controles para este entregable; deben quedar **diseñados y documentados**, salvo que el caso ya permita demostrar una implementación.

1. **Diccionario de datos**

Integrar el producto de la Semana 9.

Debe describir los datos prioritarios:

* nombre;
* descripción;
* tipo;
* formato;
* fuente;
* responsable;
* obligatoriedad;
* valores permitidos;
* clasificación;
* uso analítico;
* política asociada.

1. **Catálogo/glosario**

Definir los principales términos utilizados en el caso.

Ejemplo:

|  |  |
| --- | --- |
| Término | Definición |
| Cliente activo | Cliente que cumple las condiciones definidas por la organización. |
| Venta | Transacción de comercialización registrada por la organización. |

A) Término: Cliente activo, B) Definición: Cliente que cumple las condiciones definidas por la organización.
A) Término: Venta, B) Definición: Transacción de comercialización registrada por la organización.

Las definiciones deben ser **propias del caso**, no solamente copiar conceptos generales.

1. **Clasificación de datos**

Clasificar los datos de acuerdo con las necesidades del caso.

Por ejemplo:

* público;
* interno;
* confidencial;
* personal;
* sensible, cuando corresponda.

Cada clasificación debe tener una justificación.

1. **Trazabilidad**

Mostrar el recorrido de los datos:

1. **Origen**
2. **extracción**
3. **limpieza**
4. **transformación**
5. **dataset analítico**
6. **análisis**
7. **resultado**

Debe señalarse dónde pueden aplicarse las políticas y controles.

## Ejemplo

Trazabilidad de datos en un ejemplo de minería de datos

Aquí estaba un imagen, pero lo trascribí a texto con ayuda de IA y esto medio:

### 1. El Flujo del Proceso (Los números azules y verdes)

El proceso se divide en 7 etapas secuenciales:

* **1. Origen:** Todo comienza en el **Sistema de Ventas**. Aquí es donde se generan los datos crudos (bases de datos, hojas de cálculo, informes).
* **2. Extracción:** Los datos salen de su sistema original. Se representa con una llave inglesa, indicando que es un proceso técnico de "sacar" la información.
* **3. Limpieza:** (El icono de la escoba). Aquí se eliminan los **registros inválidos**, datos corruptos o duplicados. Se "asea" la información.
* **4. Transformación:** (El icono del engranaje). Se monitorea y se transforman las variables. Es decir, se convierte el formato de los datos para que sean útiles para el análisis (por ejemplo, cambiar formatos de fecha o combinar columnas).
* **5. Dataset Analítico:** Es el resultado de los pasos anteriores. Ya tienes una tabla o base de datos limpia y lista para ser analizada.
* **6. Análisis:** (El icono del cerebro). Aquí entra la **Minería de Datos** como tal. Se aplican modelos y algoritmos para encontrar patrones o predicciones.
* **7. Resultado:** (El icono del gráfico con el pulgar arriba). Son los resultados finales del modelo: informes, gráficos o conclusiones que sirven para tomar decisiones.

### 2. La Trazabilidad y Seguridad (Los escudos rojos)

Lo más importante de la imagen son las líneas rojas punteadas y los **escudos**. Esto representa la **Trazabilidad**, que es la capacidad de rastrear el dato en todo su ciclo de vida. Los escudos indican **Puntos de Control / Políticas**:

* **Políticas de Acceso:** Se aplican en el Origen y la Extracción. ¿Quién puede ver o sacar los datos?
* **Controles de Integridad:** Se aplican en la Extracción, Limpieza y Transformación. Aseguran que los datos no se pierdan ni se corrompan al moverlos.
* **Reglas de Calidad de Datos:** Se aplican en la Limpieza. Aseguran que los datos cumplan con estándares (ej: que no haya edades negativas).
* **Validación de Datos:** Se aplica antes del Análisis y al final. Verifica que el modelo esté usando datos correctos y que los resultados sean confiables.

1. **Ciclo de vida de los datos**

Representar las etapas correspondientes al caso:

1. **Captura**
2. **almacenamiento**
3. **preparación**
4. **utilización**
5. **conservación**
6. **archivo/eliminación**

El equipo debe explicar qué ocurre con sus datos en cada etapa.

Aquí estaba un imagen, pero lo trascribí a texto con ayuda de IA y esto medio:

### Concepto General: El Ciclo de Vida de los Datos

La imagen muestra un ciclo continuo (representado por las flechas azules circulares) dividido en 6 etapas. Alrededor de todo el ciclo, hay un anillo exterior llamado **"Políticas y Gobernanza de Datos"**, lo que indica que todas las etapas deben regirse por normas y estándares corporativos.

### Las 6 Etapas del Ciclo

**1. Captura (Iconos de sensores y dispositivos)**

* **¿Qué pasa?** Es la adquisición de los datos crudos desde sus fuentes originales.
* **Ejemplos:** Sensores IoT, correos electrónicos, redes sociales, archivos internos, etc.
* **Nota:** El equipo (representado por las personas) se encarga de obtener estos datos en diversos formatos.

**2. Almacenamiento (Iconos de servidores y nube)**

* **¿Qué pasa?** Los datos capturados se guardan y organizan en sistemas diseñados para soportar grandes volúmenes.
* **Ejemplos:** Nubes (Cloud), Data Warehouses (Almacenes de datos).
* **Nota:** El equipo estructura y guarda la información en sistemas seguros.

**3. Preparación (Icono de engranajes y embudo)**

* **¿Qué pasa?** Aquí es donde ocurre la "limpieza". Se procesan los datos para eliminar errores, inconsistencias y dejarlos listos para el análisis. (Esto equivale a las etapas de Limpieza y Transformación de tu imagen anterior).
* **Ejemplos:** Procesos de limpieza, Data Wrangling (manipulación de datos).
* **Nota:** El equipo prepara los datos para que sean precisos y estén listos para usarse.

**4. Utilización (Icono de gráficos y análisis)**

* **¿Qué pasa?** Es la etapa donde los datos se convierten en valor. Se analizan, se modelan y se usan para tomar decisiones estratégicas.
* **Ejemplos:** Machine Learning (Aprendizaje automático), Inteligencia de Negocios (BI), Reportes.
* **Nota:** El equipo aplica modelos analíticos para extraer conocimientos (insights) y valor de negocio. (Esta etapa es el núcleo de la Minería de Datos).

**5. Conservación (Icono de la caja fuerte/candado)**

* **¿Qué pasa?** Una vez que los datos han sido utilizados, no se borran de inmediato. Deben mantenerse a largo plazo por razones legales, históricas o de auditoría.
* **Ejemplos:** Cumplimiento normativo (Compliance), respaldos (Back-ups).
* **Nota:** El equipo garantiza la disponibilidad y seguridad de los datos históricos bajo normas estrictas.

**6. Archivo/Eliminación (Icono de cajas y trituradora de papel)**

* **¿Qué pasa?** Es el final de la vida útil del dato. Se decide qué se archiva permanentemente en un almacenamiento frío (de bajo costo) y qué se destruye de forma segura.
* **Ejemplos:** Archivo a largo plazo, políticas de eliminación de datos (GDPR - Reglamento General de Protección de Datos).
* **Nota:** El equipo decide el destino final de los datos, asegurando una eliminación segura cuando ya no se necesitan o exigen.

### El Anillo Exterior: Políticas y Gobernanza de Datos

A diferencia de la primera imagen (que se enfocaba en controles técnicos por etapa), esta imagen resalta que todo el ciclo está envuelto por la **Gobernanza**. Esto significa que existen reglas claras sobre:

* Quién es el dueño del dato.
* Quién puede acceder a él.
* Cómo debe protegerse la privacidad.
* Qué normativas legales se deben cumplir en cada paso (desde que nace el dato hasta que se elimina).

1. **Seguridad, privacidad y acceso**

Debe establecer:

* quién puede acceder;
* qué datos puede consultar;
* qué datos puede modificar;
* qué datos requieren protección;
* controles de acceso;
* medidas de seguridad;
* aspectos de privacidad pertinentes.

No deben agregarse medidas que no tengan relación con el caso.

1. **Integración con Minería de Datos**

Este apartado es obligatorio.

El equipo debe explicar cómo el Gobierno de Datos contribuye al proceso analítico:

1. **Problema organizacional**
2. **Objetivo del análisis**
3. **Datos requeridos**
4. **Preparación y calidad**
5. **Proceso de Minería de Datos**
6. **Resultados**
7. **Toma de decisiones**

Debe identificarse qué mecanismos de Gobierno de Datos intervienen en cada etapa.

1. **Matriz de integración del Marco V2**

Esta matriz permitirá demostrar que las evidencias no están aisladas.

|  |  |  |  |
| --- | --- | --- | --- |
| Elemento | Producto | Semana | ¿Cómo se relaciona? |
| Riesgos | Matriz de riesgos | 6 | Identifica amenazas |
| Estrategia | Matriz de alineación | 7 | Justifica necesidades |
| Políticas | Políticas | 8 | Establecen condiciones |
| Reglas | Reglas | 8 | Concretan las políticas |
| Controles | Guardrails | 8 | Previenen/detectan problemas |
| Datos | Diccionario | 9 | Describe los datos |
| Clasificación | Matriz | 9 | Determina tratamiento |
| Trazabilidad | Matriz/diagrama | 9 | Sigue el recorrido |
| Ciclo de vida | Modelo | 9 | Define etapas |
| Integración | Marco V2 | 10 | Une todos los elementos |

A) Elemento: Riesgos, B) Producto: Matriz de riesgos, C) Semana: 6, D) ¿Cómo se relaciona?: Identifica amenazas
A) Elemento: Estrategia, B) Producto: Matriz de alineación, C) Semana: 7, D) ¿Cómo se relaciona?: Justifica necesidades
A) Elemento: Políticas, B) Producto: Políticas, C) Semana: 8, D) ¿Cómo se relaciona?: Establecen condiciones
A) Elemento: Reglas, B) Producto: Reglas, C) Semana: 8, D) ¿Cómo se relaciona?: Concretan las políticas
A) Elemento: Controles, B) Producto: Guardrails, C) Semana: 8, D) ¿Cómo se relaciona?: Previenen/detectan problemas
A) Elemento: Datos, B) Producto: Diccionario, C) Semana: 9, D) ¿Cómo se relaciona?: Describe los datos
A) Elemento: Clasificación, B) Producto: Matriz, C) Semana: 9, D) ¿Cómo se relaciona?: Determina tratamiento
A) Elemento: Trazabilidad, B) Producto: Matriz/diagrama, C) Semana: 9, D) ¿Cómo se relaciona?: Sigue el recorrido
A) Elemento: Ciclo de vida, B) Producto: Modelo, C) Semana: 9, D) ¿Cómo se relaciona?: Define etapas
A) Elemento: Integración, B) Producto: Marco V2, C) Semana: 10, D) ¿Cómo se relaciona?: Une todos los elementos

1. **Conclusiones**

El equipo debe responder:

1. ¿Qué problemas de Gobierno de Datos se identificaron?
2. ¿Qué riesgos se reducen con el marco propuesto?
3. ¿Cómo contribuye el marco al proceso de Minería de Datos?
4. ¿Qué elementos deberían implementarse posteriormente?
5. ¿Qué aspectos requieren mejora en una siguiente versión?
6. **Anexos**

Incluir las evidencias complementarias:

* instrumentos utilizados;
* tablas completas;
* diagramas;
* evidencias de trabajo;
* matrices;
* otros elementos pertinentes.