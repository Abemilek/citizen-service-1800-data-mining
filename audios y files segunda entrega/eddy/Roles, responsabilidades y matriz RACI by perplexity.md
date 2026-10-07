**Definición y objetivo**

La **matriz RACI** (también llamada *matriz de asignación de responsabilidades*) es una herramienta de gestión que relaciona las actividades o entregables de un proyecto con los roles o personas involucradas, especificando para cada combinación qué tipo de participación se espera.

**RACI** es un acrónimo del inglés que representa cuatro tipos de responsabilidad:

* **R – Responsible (Responsable):** quien ejecuta el trabajo para completar la tarea. Puede haber más de una persona con este rol en una actividad.
* **A – Accountable (Aprobador / Responsable último):** quien responde finalmente por que la tarea se complete correctamente y tiene la autoridad de aprobación. Solo debe haber **un** Accountable por tarea.
* **C – Consulted (Consultado):** persona cuyo criterio o información se solicita antes o durante la ejecución; la comunicación es bidireccional.
* **I – Informed (Informado):** persona que debe ser mantenida al tanto del progreso o resultado; la comunicación es unidireccional.El objetivo principal es eliminar ambigüedades sobre “quién hace qué”, evitando duplicidades, omisiones y conflictos de autoridad en proyectos y procesos.

## Contexto de uso

La matriz RACI se aplica principalmente en:

* **Gestión de proyectos** (TI, construcción, consultoría, I+D, etc.) para clarificar responsabilidades en tareas, hitos y entregables.
* **Gestión de procesos y mejora continua** (ISO 9001, Six Sigma, BPM) para definir quién interviene en cada paso de un proceso AS-IS o TO-BE.
* **Gobernanza y cumplimiento**, donde es crítico saber quién aprueba, verifica o firma decisiones y documentos.
* **Respuesta a incidentes y operaciones** (por ejemplo, equipos de seguridad, soporte, DevOps) para asignar claramente roles durante incidentes.
* **Proyectos universitarios y trabajos en equipo**, donde ayuda a distribuir tareas y evitar que algunos miembros carguen con todo o queden fuera.

Es especialmente útil cuando hay varios interesados (stakeholders), múltiples equipos o cuando el proyecto es complejo y con muchas dependencias.

## Componentes y estructura de la matriz

Una matriz RACI típica tiene:

* **Filas:** actividades, tareas, entregables o decisiones del proyecto/proceso.wikipedia+2
* **Columnas:** roles o personas involucradas (por ejemplo: “Líder de proyecto”, “Desarrollador”, “Cliente”, “Auditor”). Se recomienda usar **roles** en lugar de nombres para que la matriz sea más estable ante cambios de personal.
* **Celdas:** contienen una de las letras R, A, C, I (o quedan vacías si el rol no participa en esa tarea).

## Símbolos y convenciones

* **R, A, C, I** son las únicas letras estándar en la versión básica.
* Una celda **vacía** significa que ese rol no tiene participación en esa tarea.
* Reglas clave:
  + Cada fila debe tener **al menos un R** (alguien que haga el trabajo).
  + Cada fila debe tener **exactamente un A** (un único responsable último)
  + No se recomienda llenar todas las celdas; muchas vacías es normal y deseable.

## Variantes de la matriz RACI

Existen varias extensiones según la complejidad y necesidades de gobernanza:

## RACI básico

* Roles: R, A, C, I.
* Uso: proyectos estándar donde basta distinguir entre quien ejecuta, quien aprueba, quien opina y quien solo recibe información.

## RASCI

* Añade **S – Support (Apoyo)**: persona o rol que aporta recursos o ayuda al Responsible sin tener responsabilidad principal.
* Útil cuando hay equipos de soporte, asistentes o áreas que colaboran sin ser dueños de la tarea.

## RACI-VS (o RASCI-VS)

* Añade:
  + **V – Verify (Verificador):** revisa que el resultado cumpla criterios de calidad o normativos.
  + **S – Signatory (Firmante / Aprobador formal):** da la aprobación final, a menudo por requisitos regulatorios o contractuales.
* Útil en entornos con controles de calidad estrictos, auditorías, validaciones regulatorias o procesos críticos.

## Otras variantes (menos comunes)

* **RACIO** (con O – Omitted u Observers), **DACI** (Driver, Approver, Contributor, Informed), **RAPID** ( Recommend, Agree, Perform, Input, Decide), entre otras.
* Se eligen según la cultura organizacional y los marcos de gobierno que ya se usen.

En un proyecto universitario, normalmente basta con **RACI básico** o, si quieres mostrar mayor rigor, **RASCI** o **RACI-VS** para actividades clave (por ejemplo, validación de requisitos, revisión de código, entrega final).

## Procedimiento paso a paso para construir una matriz RACI

A continuación, un procedimiento práctico que puedes seguir en un proyecto o tarea universitaria:

## 1. Definir el alcance y los entregables

* Parte del plan del proyecto, EDT (estructura de desglose de trabajo) o lista de actividades del proceso.
* Identifica las **tareas, hitos o decisiones clave** que requieren claridad de roles. No es necesario incluir cada micro-tarea; enfócate en lo relevante.

## 2. Identificar los roles involucrados

* Lista todos los **roles** (no necesariamente nombres) que participan: director de proyecto, líder técnico, desarrolladores, tester, cliente, profesor, etc.
* Si trabajas en equipo universitario, roles típicos: “Coordinador del equipo”, “Desarrollador backend”, “Desarrollador frontend”, “Encargado de documentación”, “Cliente/usuario representativo”, “Profesor/tutor”.

## 3. Construir la cuadrícula

* Crea una tabla con:
  + **Filas:** tareas/entregables.
  + **Columnas:** roles.
* Puedes hacerla en Excel, Google Sheets, Notion, o incluso en un documento Word con tabla.

## 4. Asignar R, A, C, I a cada celda

Trabaja fila por fila (tarea por tarea):

* Para cada rol, decide si es:
  + **R:** ejecuta la tarea.
  + **A:** responde y aprueba.
  + **C:** se le consulta.
  + **I:** se le informa.
  + **Vacío:** no participa.
* Reglas importantes:
  + **Un solo A por fila.** Si hay varios, redistribuye o define sub-tareas.
  + Al menos un **R** por fila.
  + Limita los **C** a quienes realmente aportan valor; evita “consultar a todos”.
  + Usa **I** para mantener alineados a interesados que no necesitan decidir ni ejecutar.

## 5. Validar la matriz con el equipo

* Reúne al equipo y revisa la matriz fila por fila.
* Pregunta:
  + ¿Queda claro quién hace cada cosa?
  + ¿Alguien se siente sobrecargado (muchas R)?
  + ¿Alguna tarea parece “sin dueño” (sin R o sin A)?
  + ¿Hay demasiados C o I que puedan ralentizar el trabajo?
* Ajusta según la discusión y consensúa la versión final.

## 6. Socializar y mantener actualizada

* Comparte la matriz con todos los interesados (equipo, profesor, cliente, etc.).
* Úsala como referencia en reuniones de seguimiento.
* Actualízala si cambian las tareas, el equipo o el alcance.

## Ejemplo práctico completo (proyecto universitario de desarrollo de app)

Supongamos un proyecto universitario para desarrollar una **app móvil de gestión de citas** con backend, base de datos y documentación.

## Roles del equipo

* **COORD:** Coordinador del equipo (líder de proyecto).
* **DEV-B:** Desarrollador backend.
* **DEV-F:** Desarrollador frontend/móvil.
* **QA:** Encargado de pruebas y calidad.
* **DOC:** Responsable de documentación.
* **CLIENTE:** Representante del “cliente” (puede ser el profesor o un compañero haciendo de usuario).
* **PROF:** Profesor/tutor.

## Tareas clave (filas)

1. Definir requisitos del sistema.
2. Diseñar arquitectura y base de datos.
3. Implementar backend (API).
4. Implementar app móvil (frontend).
5. Realizar pruebas integrales.
6. Elaborar documentación final.
7. Presentación y defensa del proyecto.

## Matriz RACI (ejemplo)

|  |  |  |  |  |  |  |  |
| --- | --- | --- | --- | --- | --- | --- | --- |
| Tarea / Rol | COORD | DEV-B | DEV-F | QA | DOC | CLIENTE | PROF |
| 1. Definir requisitos | A | C | C | C | I | R | I |
| 2. Diseñar arquitectura | A | R | C | I | I | C | I |
| 3. Implementar backend | A | R | I | C | I | I | I |
| 4. Implementar frontend | A | C | R | C | I | C | I |
| 5. Pruebas integrales | A | C | C | R | I | C | I |
| 6. Documentación final | A | C | C | C | R | I | C |
| 7. Presentación y defensa | R | C | C | I | C | C | A |

Tarea / Rol: 1. Definir requisitos
COORD: A
DEV-B: C
DEV-F: C
QA: C
DOC: I
CLIENTE: R
PROF: I

Tarea / Rol: 2. Diseñar arquitectura
COORD: A
DEV-B: R
DEV-F: C
QA: I
DOC: I
CLIENTE: C
PROF: I

Tarea / Rol: 3. Implementar backend
COORD: A
DEV-B: R
DEV-F: I
QA: C
DOC: I
CLIENTE: I
PROF: I

Tarea / Rol: 4. Implementar frontend
COORD: A
DEV-B: C
DEV-F: R
QA: C
DOC: I
CLIENTE: C
PROF: I

Tarea / Rol: 5. Pruebas integrales
COORD: A
DEV-B: C
DEV-F: C
QA: R
DOC: I
CLIENTE: C
PROF: I

Tarea / Rol: 6. Documentación final
COORD: A
DEV-B: C
DEV-F: C
QA: C
DOC: R
CLIENTE: I
PROF: C

Tarea / Rol: 7. Presentación y defensa
COORD: R
DEV-B: C
DEV-F: C
QA: I
DOC: C
CLIENTE: C
PROF: A

**Interpretación de algunas filas:**

* **Definir requisitos:**
  + **CLIENTE** es R (propone y detalla lo que necesita).
  + **COORD** es A (responde por que los requisitos estén bien definidos y aprobados).
  + **DEV-B, DEV-F, QA** son C (aportan viabilidad técnica).
  + **DOC y PROF** son I (se enteran, pero no deciden).
* **Implementar backend:**
  + **DEV-B** es R (escribe el código).
  + **COORD** es A (responde por que se entregue a tiempo y según diseño).
  + **QA** es C (define criterios de prueba, revisa aspectos de calidad).
* **Presentación y defensa:**
  + **COORD** es R (coordina la presentación, asigna quién habla de cada parte).
  + **PROF** es A (evalúa y califica; es el “dueño” del criterio de aprobación académica).
  + El resto del equipo es C o I según su participación en la defensa.

Este ejemplo muestra cómo la matriz deja claro quién lidera, quién ejecuta y quién solo opina o recibe información en cada actividad clave.

## Cómo interpretar el resultado final

Al tener la matriz terminada, puedes leerla de dos formas:

## Por filas (tarea por tarea)

* Identificas rápidamente:
  + **Quién ejecuta** (R).
  + **Quién responde y aprueba** (A).
  + **A quién consultar** (C).
  + **A quién mantener informado** (I).
* Sirve para planificar reuniones, revisiones y flujos de aprobación.

## Por columnas (rol por rol)

* Ves la **carga de trabajo** y participación de cada rol:
  + Un rol con muchas **R** puede estar sobrecargado.
  + Un rol con muchas **A** puede ser un cuello de botella de decisiones.
  + Un rol con muchas **C** puede estar ralentizando el proyecto si hay que esperarlo constantemente.

Esto te permite rebalancear tareas, redistribuir responsabilidades o ajustar el alcance antes de que haya problemas reales.

## Ventajas, limitaciones y supuestos clave

## Ventajas

* **Claridad de roles:** reduce confusiones sobre quién hace qué y quién decide.
* **Mejor comunicación:** define explícitamente quién debe ser consultado e informado.
* **Prevención de conflictos:** disminuye disputas por “territorio” o tareas no asumidas.
* **Facilita la gobernanza:** hace visible la cadena de responsabilidad y aprobación.
* **Útil para onboarding:** nuevos miembros entienden rápidamente su rol y con quién interactuar.

## Limitaciones

* **No detalla cómo se hace el trabajo:** solo dice “quién”, no “cómo”. Debe complementarse con procedimientos, manuales o flujos de proceso.
* **Puede volverse compleja:** si se incluyen demasiadas tareas o roles, la matriz se hace ilegible.
* **Riesgo de rigidez:** si no se actualiza, puede quedar desalineada con la realidad del proyecto.
* **Depende de la cultura:** en equipos muy informales o pequeños, puede percibirse como burocrática si no se explica bien su propósito.

## Supuestos clave

* Existe una **definición razonablemente clara de tareas y roles** antes de construir la matriz.
* Los participantes están dispuestos a **asumir y respetar** las responsabilidades asignadas.
* La matriz se **usa activamente** (se consulta, se socializa, se actualiza), no es solo un documento decorativo.

## Errores comunes y cómo evitarlos

## 1. Múltiples “A” en una misma tarea

* **Problema:** nadie se siente realmente responsable; se diluye la autoridad y surgen conflictos.
* **Solución:** asigna **un solo A** por tarea. Si hay un comité, nombra al presidente o líder como A.

## 2. Tareas sin R o sin A

* **Problema:** actividades “órfanas” que nadie ejecuta o por las que nadie responde.
* **Solución:** revisa fila por fila y asegura al menos un R y exactamente un A antes de dar por válida la matriz.

## 3. Confundir Responsible con Accountable

* **Problema:** se piensa que quien ejecuta también es el único responsable último, o viceversa.
* **Solución:** recuerda:
  + **R = hace el trabajo.**
  + **A = responde por el resultado y aprueba.**

## 4. Demasiados Consulted (C)

* **Problema:** el proceso se vuelve lento porque hay que esperar opiniones de muchas personas.
* **Solución:** limita C a quienes realmente afectan calidad, riesgo o viabilidad; mueve a los demás a I o quítalos de esa tarea.

## 5. Informar a todo el mundo de todo

* **Problema:** ruido informativo; la gente ignora las comunicaciones porque son excesivas.
* **Solución:** usa I solo para quienes realmente necesitan estar al tanto; define frecuencia y canal de información.

## 6. Matriz demasiado detallada

* **Problema:** cientos de filas con micro-tareas; nadie la lee ni la usa.
* **Solución:** enfócate en entregables y decisiones clave; deja el detalle operativo en procedimientos o listas de tareas separadas.

## 7. Usar nombres en lugar de roles

* **Problema:** si alguien cambia de equipo, la matriz queda obsoleta y confusa.
* **Solución:** usa **roles** (ej. “Líder técnico”) y, si quieres, añade un anexo con “rol → nombre actual”.

## 8. No socializar ni actualizar la matriz

* **Problema:** la matriz existe en papel, pero el equipo no la conoce o no la usa.
* **Solución:** preséntala en una reunión, acuérdala con el equipo y revísala periódicamente o cuando haya cambios importantes.

**Recomendaciones para usarla en un proyecto o tarea universitaria**

1. **Empieza simple:** usa RACI básico (R, A, C, I) a menos que tu proyecto requiera controles de calidad o aprobaciones formales muy marcadas.
2. **Definí bien las tareas clave:** requisitos, diseño, implementación, pruebas, documentación y defensa/presentación suelen ser suficientes.
3. **Usa roles claros y realistas:** adapta los roles a tu equipo (coordinador, desarrolladores, tester, documentador, cliente, profesor).
4. **Hazla en grupo:** construye la matriz en una sesión con todo el equipo; esto ya genera acuerdo y compromiso.
5. **Revísala a mitad del proyecto:** si el alcance o el equipo cambian, actualiza la matriz y vuelve a validarla.
6. **Inclúyela en la documentación del proyecto:** como parte de la gestión del proyecto (junto con cronograma, EDT, etc.), lo cual suele ser bien valorado por los profesores.
7. **Úsala para repartir carga:** si ves que un compañero tiene demasiadas R, redistribuye tareas antes de que haya problemas.
8. **No la sobrecargues:** 5–10 filas con las actividades principales suelen ser suficientes para una tarea universitaria típica.

**Conclusión breve**

La matriz RACI es una herramienta sencilla pero poderosa para definir y comunicar quién es responsable, quién aprueba, quién consulta y quién se informa en cada tarea o entregable de un proyecto o proceso. Bien construida y usada, reduce ambigüedades, mejora la coordinación y ayuda a prevenir conflictos de responsabilidad, tanto en entornos profesionales como en proyectos universitarios.