**INGENIERÍA EN SISTEMAS DE INFORMACIÓN**

# 16 CASOS DE ESTUDIO

**Expedientes de Fase 0 para el Integrador VIII**

Minería de Datos • Gobierno de Datos • Gestión de la Calidad de los Procesos

|  |
| --- |
| **Alcance:** Cada caso contiene únicamente el contexto y los datos objetivos iniciales que recibe el analista. Las soluciones, hallazgos, KPIs, modelos, políticas, procesos y recomendaciones deberán ser desarrollados por los estudiantes durante los tres cortes: semanas 5, 10 y 14. |

**Centro Universitario Regional de Carazo**\
Integrador VIII • 2026\
Docente: MSc. Yulieth N. Casanova

# Orientaciones para la asignación

Los casos se distribuyen de manera individual o grupal. Todos poseen la misma estructura de entrada, pero representan sectores, procesos, variables, restricciones y decisiones diferentes. El docente asignará un número de caso y la hoja de datos correspondiente.

|  |
| --- |
| **Regla pedagógica:** No entregar a los estudiantes análisis resueltos del caso modelo. Deben descubrir patrones, formular el problema y construir los productos definidos en la matriz integradora. |

## Listado de casos

| **Caso** | **Organización ficticia** | **Tema** | **Hoja de datos** |
| --- | --- | --- | --- |
| 1 | Universidad Regional del Pacífico (URP) | Permanencia estudiantil y continuidad académica | C01_Permanencia |
| 2 | Red Salud Integral Carazo | Gestión de citas y continuidad de atención | C02_Citas |
| 3 | Mercados La Colina S.A. | Disponibilidad de productos y reposición de inventario | C03_Inventario |
| 4 | Movilidad del Sur Cooperativa | Puntualidad y regularidad del transporte interurbano | C04_Transporte |
| 5 | Financiera Emprende Segura | Seguimiento de cartera de microcrédito | C05_Microcredito |
| 6 | Cooperativa AgroVerde | Rendimiento y pérdidas en producción hortícola | C06_Agro |
| 7 | ConectaNica Telecom | Permanencia de clientes en servicios de telecomunicaciones | C07_Telecom |
| 8 | Empresa Municipal Aguas Claras | Detección de consumos anómalos y pérdidas de agua | C08_Agua |
| 9 | NicaCompra Digital | Devoluciones y experiencia de compra en comercio electrónico | C09_Ecommerce |
| 10 | RápidoPacífico Logística | Cumplimiento de entregas de última milla | C10_Logistica |
| 11 | Hoteles Costa y Volcán | Cancelaciones y ocupación en servicios hoteleros | C11_Hotel |
| 12 | Distribuidora Energía CentroSur | Continuidad del servicio de distribución eléctrica | C12_Energia |
| 13 | Industrias TecnoPlast | Calidad de lotes en una planta de manufactura | C13_Manufactura |
| 14 | Farmacias Vida Plena | Riesgo de vencimiento y disponibilidad de medicamentos | C14_Farmacia |
| 15 | Servicio Ciudadano 1800 | Resolución y recontacto en un centro de atención | C15_CallCenter |
| 16 | Servicios Municipales Ciudad Limpia | Cumplimiento de rutas de recolección de residuos | C16_Residuos |

## Contenido común del expediente

| **Bloque** | **Qué recibe el equipo** |
| --- | --- |
| Contexto | Organización, operación, dimensión, periodo y decisión institucional. |
| Proceso | Hechos operativos suficientes para que el equipo construya y valide el AS-IS. |
| Gobierno | Actores, responsables conocidos, restricciones y fuentes para diseñar roles, RACI y políticas. |
| Datos | Dataset v0, diccionario, trazabilidad de origen y reportes neutrales. |
| Calidad | Datos sin limpiar para realizar perfilado, diagnóstico, reglas, indicadores y mejora. |
| Minería | Variable de resultado disponible y variables explicativas; la técnica no se prescribe. |

**CASO 1**

# Permanencia estudiantil y continuidad académica

*Universidad Regional del Pacífico (URP) | Educación superior*

|  |
| --- |
| **Documento que recibe el analista:** Expediente inicial de Fase 0. Contiene hechos, fuentes y datos de partida; no contiene problema formulado, objetivos, KPIs resueltos, técnica de minería seleccionada, marco de gobierno, mapa AS-IS/TO-BE, conclusiones ni recomendaciones. |

## 1. Identificación y asignación

| **Equipo / estudiante** | **Integrantes** | **Fecha de asignación** |
| --- | --- | --- |

| **Organización** | Universidad Regional del Pacífico (URP) |
| --- | --- |
| **Sector y ubicación** | Educación superior \| Carazo y sedes asociadas |
| **Operación** | Programas de ingeniería en modalidades presencial, por encuentros y virtual. |
| **Dimensión** | 4,850 estudiantes activos; 7 programas; 3 modalidades |
| **Periodo disponible** | 2024-I a 2026-I |
| **Unidad de análisis** | estudiante-periodo |
| **Decisión institucional** | Priorizar acciones académicas y de acompañamiento con base en evidencia verificable. |

## 2. Contexto entregado

Universidad Regional del Pacífico (URP) entrega al equipo un conjunto inicial compuesto por Registros de matrícula, aula virtual, calificaciones y bienestar estudiantil. La dirección solicita examinar los datos antes de formular el problema definitivo. El análisis debe distinguir hechos, supuestos y conclusiones, y conservar trazabilidad hacia cada fuente.

**Condición de trabajo.** *Los datos son sintéticos y fueron construidos para fines académicos, pero deben tratarse como si estuvieran sujetos a controles reales de acceso, seguridad, privacidad, calidad y ciclo de vida.*

## 3. Proceso operativo actual: hechos observados

| **Paso** | **Hecho operativo comunicado** | **Evidencia disponible** |
| --- | --- | --- |
| 1 | Registro Académico exporta la matrícula al inicio del periodo. | SIGA |
| 2 | Moodle genera actividad semanal por curso. | Moodle |
| 3 | Docentes cargan asistencia y calificaciones en fechas diferentes. | Moodle |
| 4 | Coordinaciones consolidan hojas para identificar estudiantes que requieren seguimiento. | Archivo CSV |
| 5 | Bienestar registra intervenciones en una aplicación separada. | Bienestar |
| 6 | Al cierre se compara matrícula actual con la del periodo siguiente. | SIGA |

*La secuencia anterior es una descripción factual. Corresponde al equipo verificarla, delimitarla y convertirla en los modelos de proceso exigidos por el Integrador VIII.*

## 4. Actores que participan en el caso

| **Actor / área** | **Participación conocida al inicio** |
| --- | --- |
| Vicerrectoría Académica | Patrocinio y decisiones |
| Registro Académico | Custodia de matrícula |
| Coordinaciones | Uso de alertas |
| TI | Integración y accesos |
| Bienestar | Acompañamiento autorizado |

## 5. Inventario inicial de fuentes

| **Fuente** | **Responsable conocido** | **Formato** | **Actualización** | **Condición inicial** |
| --- | --- | --- | --- | --- |
| SIGA | Registro Académico | Base SQL / vista | Diaria | Acceso por rol; validación pendiente |
| Moodle | TI | API / eventos | Casi en tiempo real | Acceso por rol; validación pendiente |
| Bienestar | Bienestar | Archivo XLSX | Semanal | Acceso por rol; validación pendiente |
| Archivo CSV | Coordinaciones | CSV exportado | Mensual | Acceso por rol; validación pendiente |

## 6. Ficha técnica del dataset v0

| **Archivo de datos** | Datos_Iniciales_16_Casos_Integrador_VIII.xlsx |
| --- | --- |
| **Hoja asignada** | C01_Permanencia |
| **Cantidad de registros** | 360 registros sintéticos |
| **Cantidad de variables** | 15 variables |
| **Variable de resultado disponible** | no_continua_siguiente_periodo: 1 = No continúa en el periodo siguiente; 0 = caso contrario; vacío = no consolidado |
| **Copia de resguardo** | Conservar la hoja original como dataset v0; todas las transformaciones deben quedar en una versión derivada. |
| **Advertencia de calidad:** El dataset conserva de manera intencional valores faltantes, registros repetidos, etiquetas no normalizadas, cargas tardías y valores fuera de rango. No se indican sus cantidades ni ubicaciones: forman parte del diagnóstico que debe realizar el equipo. |  |

## 7. Diccionario preliminar de variables

| **Variable** | **Tipo** | **Descripción inicial** | **Uso conocido** |
| --- | --- | --- | --- |
| id_estudiante_periodo | Texto | Identificador seudonimizado del registro | Clave operativa |
| fecha_inicio_periodo | Fecha | Fecha del evento o corte | Tiempo |
| programa_academico | Texto | Ubicación/unidad: Sistemas, Computación, Telecomunicaciones, Industrial, Civil | Segmentación |
| modalidad | Texto | Canal/modalidad: Presencial, Por encuentros, Virtual | Segmentación |
| condicion_ingreso | Texto | Segmento: Nuevo ingreso, Continuidad, Reingreso, Traslado | Segmentación |
| asignatura_critica | Texto | Categoría: Matemática I, Programación I, Física I, Estadística, Bases de datos | Segmentación |
| promedio_periodo | Numérico | Medida operacional. Rango esperado 48-96 | Medición |
| asistencia_pct | Numérico | Duración/antigüedad. Rango esperado 35-100 | Medición |
| accesos_campus_virtual | Numérico | Indicador operacional 1. Rango esperado 0-180 | Medición |
| asignaturas_reprobadas | Numérico | Indicador operacional 2. Rango esperado 0-5 | Medición |
| beca_o_apoyo | Texto | Variable auxiliar: Beca completa, Beca parcial, Sin beca, Tutoría académica | Contexto |
| sistema_origen | Texto | Sistema de procedencia: SIGA, Moodle, Bienestar, Archivo CSV | Linaje |
| no_continua_siguiente_periodo | Binaria | 1 = No continúa en el periodo siguiente; 0 = caso contrario; nulo = no consolidado | Resultado |
| autorizacion_uso_analitico | Texto | Bandera de autorización o uso permitido según el caso | Gobierno |
| fecha_carga | Fecha | Fecha de incorporación al conjunto analítico | Oportunidad |

## 8. Informes operativos entregados

*Los siguientes cuadros son resúmenes neutrales del dataset v0. Las tasas, comparaciones, prioridades e interpretaciones deben ser calculadas y justificadas por el equipo.*

### Informe 1. Volumen mensual

| **Mes** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: promedio\_periodo** |
| --- | --- | --- | --- | --- |
| 2025-01 | 22 | 22 | 12 | 1,481.2 |
| 2025-02 | 22 | 21 | 11 | 1,560 |
| 2025-03 | 13 | 13 | 4 | 998.7 |
| 2025-04 | 18 | 18 | 11 | 1,263.5 |
| 2025-05 | 22 | 21 | 9 | 1,581.8 |
| 2025-06 | 24 | 23 | 10 | 1,893.6 |
| 2025-07 | 23 | 23 | 7 | 1,665 |
| 2025-08 | 17 | 17 | 8 | 1,216.3 |
| 2025-09 | 18 | 18 | 10 | 1,332.8 |
| 2025-10 | 26 | 25 | 10 | 1,851.5 |
| 2025-11 | 20 | 20 | 9 | 1,470.9 |
| 2025-12 | 23 | 23 | 11 | 1,718.3 |
| 2026-01 | 15 | 15 | 5 | 960.6 |
| 2026-02 | 18 | 17 | 8 | 1,246.2 |
| 2026-03 | 12 | 12 | 2 | 886 |
| 2026-04 | 16 | 16 | 7 | 1,112.2 |
| 2026-05 | 24 | 23 | 7 | 1,693.6 |
| 2026-06 | 27 | 27 | 10 | 1,878.7 |

### Informe 2. Desglose por modalidad

| **modalidad** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: promedio\_periodo** |
| --- | --- | --- | --- | --- |
| (sin dato) | 9 | 8 | 3 | 674.1 |
| Por encuentros | 107 | 106 | 43 | 7,696.4 |
| Presencial | 116 | 114 | 44 | 8,416.3 |
| Virtual | 128 | 126 | 61 | 9,024.1 |

### Informe 3. Desglose por asignatura_critica

| **asignatura\_critica** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: promedio\_periodo** |
| --- | --- | --- | --- | --- |
| Bases de datos | 85 | 83 | 33 | 6,081.9 |
| Estadística | 66 | 66 | 25 | 4,550.4 |
| Física I | 74 | 71 | 26 | 5,466.5 |
| FÍSICA I | 3 | 2 | 1 | 266.4 |
| Matemática I | 64 | 64 | 33 | 4,529.2 |
| MATEMÁTICA I | 1 | 1 | 1 | 91.2 |
| Programación I | 67 | 67 | 32 | 4,825.3 |

### Informe 4. Desglose por programa_academico

| **programa\_academico** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: promedio\_periodo** |
| --- | --- | --- | --- | --- |
| Civil | 68 | 67 | 25 | 4,729.7 |
| Computación | 61 | 60 | 33 | 4,336 |
| Industrial | 74 | 73 | 34 | 5,505.3 |
| Sistemas | 83 | 81 | 29 | 5,998.6 |
| Telecomunicaciones | 74 | 73 | 30 | 5,241.3 |

## 9. Referencias operativas y restricciones

|  |  |
| --- | --- |
| **Referencia comparativa** | Tasa referencial de no continuidad anual en programas comparables: 18%; meta institucional de completitud de datos: 97%. |
| **Privacidad y ética** | Los identificadores deben permanecer seudonimizados; no exponer diagnósticos de bienestar ni condiciones socioeconómicas. |
| **Acceso inicial** | Lectura sobre dataset v0; cualquier dato derivado debe documentar origen, transformación y responsable. |
| **Uso permitido** | Exclusivamente académico dentro del Integrador VIII; no reutilizar nombres ficticios como si fueran organizaciones reales. |

## 10. Paquete recibido por el analista

| **N.º** | **Elemento** | **Contenido inicial** |
| --- | --- | --- |
| 1 | Este expediente de Fase 0 | Contexto, actores, proceso factual, fuentes, diccionario y reportes |
| 2 | Hoja C01_Permanencia del libro de datos | 360 registros sin limpiar |
| 3 | Matriz Integradora y BOA | Criterios de los tres cortes y evidencias obligatorias |
| 4 | Guía de la primera fase | Orientación para organizar el primer incremento |

**CASO 2**

# Gestión de citas y continuidad de atención

*Red Salud Integral Carazo | Servicios de salud ambulatorios*

|  |
| --- |
| **Documento que recibe el analista:** Expediente inicial de Fase 0. Contiene hechos, fuentes y datos de partida; no contiene problema formulado, objetivos, KPIs resueltos, técnica de minería seleccionada, marco de gobierno, mapa AS-IS/TO-BE, conclusiones ni recomendaciones. |

## 1. Identificación y asignación

| **Equipo / estudiante** | **Integrantes** | **Fecha de asignación** |
| --- | --- | --- |

| **Organización** | Red Salud Integral Carazo |
| --- | --- |
| **Sector y ubicación** | Servicios de salud ambulatorios \| Jinotepe, Diriamba y San Marcos |
| **Operación** | Consulta externa, laboratorio y especialidades en cuatro centros. |
| **Dimensión** | 38,000 citas anuales; 72 profesionales |
| **Periodo disponible** | enero 2024-junio 2026 |
| **Unidad de análisis** | cita programada |
| **Decisión institucional** | Organizar agendas, recordatorios y cupos de atención con criterios transparentes. |

## 2. Contexto entregado

Red Salud Integral Carazo entrega al equipo un conjunto inicial compuesto por Citas, admisión, mensajería y facturación. La dirección solicita examinar los datos antes de formular el problema definitivo. El análisis debe distinguir hechos, supuestos y conclusiones, y conservar trazabilidad hacia cada fuente.

**Condición de trabajo.** *Los datos son sintéticos y fueron construidos para fines académicos, pero deben tratarse como si estuvieran sujetos a controles reales de acceso, seguridad, privacidad, calidad y ciclo de vida.*

## 3. Proceso operativo actual: hechos observados

| **Paso** | **Hecho operativo comunicado** | **Evidencia disponible** |
| --- | --- | --- |
| 1 | La cita se solicita por cuatro canales. | AgendaPlus |
| 2 | Admisión valida datos de contacto y disponibilidad. | Admisión |
| 3 | El sistema programa recordatorios automáticos. | SMS Gateway |
| 4 | Cada centro confirma asistencia al cerrar la jornada. | Admisión |
| 5 | Facturación y expediente clínico registran servicios por separado. | Facturación |
| 6 | Las jefaturas reciben un consolidado mensual. | AgendaPlus |

*La secuencia anterior es una descripción factual. Corresponde al equipo verificarla, delimitarla y convertirla en los modelos de proceso exigidos por el Integrador VIII.*

## 4. Actores que participan en el caso

| **Actor / área** | **Participación conocida al inicio** |
| --- | --- |
| Dirección Médica | Patrocinio |
| Admisión | Registro de citas |
| Jefaturas de servicio | Gestión de agendas |
| TI | Integración |
| Protección de datos | Accesos y privacidad |

## 5. Inventario inicial de fuentes

| **Fuente** | **Responsable conocido** | **Formato** | **Actualización** | **Condición inicial** |
| --- | --- | --- | --- | --- |
| AgendaPlus | Admisión | Base SQL / vista | Diaria | Acceso por rol; validación pendiente |
| Admisión | Admisión | API / eventos | Casi en tiempo real | Acceso por rol; validación pendiente |
| SMS Gateway | TI | Archivo XLSX | Semanal | Acceso por rol; validación pendiente |
| Facturación | Administración y facturación | CSV exportado | Mensual | Acceso por rol; validación pendiente |

## 6. Ficha técnica del dataset v0

| **Archivo de datos** | Datos_Iniciales_16_Casos_Integrador_VIII.xlsx |
| --- | --- |
| **Hoja asignada** | C02_Citas |
| **Cantidad de registros** | 360 registros sintéticos |
| **Cantidad de variables** | 15 variables |
| **Variable de resultado disponible** | no_asistio: 1 = Cita sin asistencia; 0 = caso contrario; vacío = no consolidado |
| **Copia de resguardo** | Conservar la hoja original como dataset v0; todas las transformaciones deben quedar en una versión derivada. |
| **Advertencia de calidad:** El dataset conserva de manera intencional valores faltantes, registros repetidos, etiquetas no normalizadas, cargas tardías y valores fuera de rango. No se indican sus cantidades ni ubicaciones: forman parte del diagnóstico que debe realizar el equipo. |  |

## 7. Diccionario preliminar de variables

| **Variable** | **Tipo** | **Descripción inicial** | **Uso conocido** |
| --- | --- | --- | --- |
| id_cita | Texto | Identificador seudonimizado del registro | Clave operativa |
| fecha_cita | Fecha | Fecha del evento o corte | Tiempo |
| centro_salud | Texto | Ubicación/unidad: Jinotepe, Diriamba, San Marcos, Dolores | Segmentación |
| canal_agendamiento | Texto | Canal/modalidad: Call center, Web, Ventanilla, Referencia médica | Segmentación |
| grupo_edad | Texto | Segmento: 0-17, 18-35, 36-59, 60+ | Segmentación |
| especialidad | Texto | Categoría: Medicina general, Pediatría, Ginecología, Cardiología, Laboratorio | Segmentación |
| costo_estimado_usd | Numérico | Medida operacional. Rango esperado 8-110 | Medición |
| espera_dias | Numérico | Duración/antigüedad. Rango esperado 0-45 | Medición |
| recordatorios_enviados | Numérico | Indicador operacional 1. Rango esperado 0-3 | Medición |
| citas_previas_perdidas | Numérico | Indicador operacional 2. Rango esperado 0-4 | Medición |
| tipo_cobertura | Texto | Variable auxiliar: Público, Seguro, Convenio, Particular | Contexto |
| sistema_origen | Texto | Sistema de procedencia: AgendaPlus, Admisión, SMS Gateway, Facturación | Linaje |
| no_asistio | Binaria | 1 = Cita sin asistencia; 0 = caso contrario; nulo = no consolidado | Resultado |
| consentimiento_contacto | Texto | Bandera de autorización o uso permitido según el caso | Gobierno |
| fecha_carga | Fecha | Fecha de incorporación al conjunto analítico | Oportunidad |

## 8. Informes operativos entregados

*Los siguientes cuadros son resúmenes neutrales del dataset v0. Las tasas, comparaciones, prioridades e interpretaciones deben ser calculadas y justificadas por el equipo.*

### Informe 1. Volumen mensual

| **Mes** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: costo\_estimado\_usd** |
| --- | --- | --- | --- | --- |
| 2025-01 | 31 | 31 | 15 | 1,581.5 |
| 2025-02 | 15 | 15 | 8 | 974 |
| 2025-03 | 20 | 20 | 5 | 1,215 |
| 2025-04 | 16 | 16 | 6 | 1,061.8 |
| 2025-05 | 20 | 20 | 6 | 1,278.6 |
| 2025-06 | 19 | 19 | 9 | 1,066.9 |
| 2025-07 | 17 | 16 | 8 | 963.7 |
| 2025-08 | 17 | 17 | 6 | 1,107.6 |
| 2025-09 | 19 | 18 | 8 | 991.6 |
| 2025-10 | 26 | 25 | 7 | 1,741.1 |
| 2025-11 | 17 | 17 | 5 | 1,042.8 |
| 2025-12 | 20 | 20 | 8 | 1,077.7 |
| 2026-01 | 25 | 25 | 7 | 1,597 |
| 2026-02 | 25 | 25 | 12 | 1,725.3 |
| 2026-03 | 18 | 17 | 8 | 1,243.4 |
| 2026-04 | 16 | 16 | 4 | 911.8 |
| 2026-05 | 17 | 15 | 8 | 1,052.1 |
| 2026-06 | 22 | 22 | 6 | 1,197.4 |

### Informe 2. Desglose por canal_agendamiento

| **canal\_agendamiento** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: costo\_estimado\_usd** |
| --- | --- | --- | --- | --- |
| (sin dato) | 9 | 8 | 3 | 387.5 |
| Call center | 73 | 73 | 25 | 4,192.1 |
| Referencia médica | 83 | 81 | 31 | 5,033 |
| Ventanilla | 100 | 99 | 30 | 6,333.3 |
| Web | 95 | 93 | 47 | 5,883.4 |

### Informe 3. Desglose por especialidad

| **especialidad** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: costo\_estimado\_usd** |
| --- | --- | --- | --- | --- |
| Cardiología | 71 | 70 | 38 | 4,439 |
| Ginecología | 83 | 83 | 33 | 5,325.3 |
| GINECOLOGÍA | 1 | 0 | 0 | 109.2 |
| Laboratorio | 56 | 56 | 15 | 3,452.9 |
| Medicina general | 67 | 66 | 22 | 3,749 |
| MEDICINA GENERAL | 2 | 2 | 1 | 96.1 |
| Pediatría | 79 | 76 | 27 | 4,608.3 |
| PEDIATRÍA | 1 | 1 | 0 | 49.5 |

### Informe 4. Desglose por centro_salud

| **centro\_salud** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: costo\_estimado\_usd** |
| --- | --- | --- | --- | --- |
| Diriamba | 88 | 87 | 36 | 5,330.8 |
| Dolores | 85 | 84 | 36 | 5,217.9 |
| Jinotepe | 73 | 71 | 18 | 4,443.1 |
| San Marcos | 114 | 112 | 46 | 6,837.5 |

## 9. Referencias operativas y restricciones

|  |  |
| --- | --- |
| **Referencia comparativa** | Referencia regional: ausentismo de 15%; confirmación de citas en menos de 24 horas; completitud esperada de teléfono: 95%. |
| **Privacidad y ética** | Aplican confidencialidad clínica, mínimo acceso y prohibición de inferir diagnósticos no contenidos en los datos autorizados. |
| **Acceso inicial** | Lectura sobre dataset v0; cualquier dato derivado debe documentar origen, transformación y responsable. |
| **Uso permitido** | Exclusivamente académico dentro del Integrador VIII; no reutilizar nombres ficticios como si fueran organizaciones reales. |

## 10. Paquete recibido por el analista

| **N.º** | **Elemento** | **Contenido inicial** |
| --- | --- | --- |
| 1 | Este expediente de Fase 0 | Contexto, actores, proceso factual, fuentes, diccionario y reportes |
| 2 | Hoja C02_Citas del libro de datos | 360 registros sin limpiar |
| 3 | Matriz Integradora y BOA | Criterios de los tres cortes y evidencias obligatorias |
| 4 | Guía de la primera fase | Orientación para organizar el primer incremento |

**CASO 3**

# Disponibilidad de productos y reposición de inventario

*Mercados La Colina S.A. | Comercio minorista*

|  |
| --- |
| **Documento que recibe el analista:** Expediente inicial de Fase 0. Contiene hechos, fuentes y datos de partida; no contiene problema formulado, objetivos, KPIs resueltos, técnica de minería seleccionada, marco de gobierno, mapa AS-IS/TO-BE, conclusiones ni recomendaciones. |

## 1. Identificación y asignación

| **Equipo / estudiante** | **Integrantes** | **Fecha de asignación** |
| --- | --- | --- |

| **Organización** | Mercados La Colina S.A. |
| --- | --- |
| **Sector y ubicación** | Comercio minorista \| Managua y Carazo |
| **Operación** | Ocho tiendas, bodega central y canal de pedidos en línea. |
| **Dimensión** | 6,200 SKU; 1.4 millones de movimientos/año |
| **Periodo disponible** | julio 2024-junio 2026 |
| **Unidad de análisis** | producto-tienda-semana |
| **Decisión institucional** | Priorizar reposición y distribución entre tiendas sin aumentar inventario innecesario. |

## 2. Contexto entregado

Mercados La Colina S.A. entrega al equipo un conjunto inicial compuesto por Ventas, inventario, compras, promociones y catálogo de productos. La dirección solicita examinar los datos antes de formular el problema definitivo. El análisis debe distinguir hechos, supuestos y conclusiones, y conservar trazabilidad hacia cada fuente.

**Condición de trabajo.** *Los datos son sintéticos y fueron construidos para fines académicos, pero deben tratarse como si estuvieran sujetos a controles reales de acceso, seguridad, privacidad, calidad y ciclo de vida.*

## 3. Proceso operativo actual: hechos observados

| **Paso** | **Hecho operativo comunicado** | **Evidencia disponible** |
| --- | --- | --- |
| 1 | Las ventas descuentan existencias en el POS. | POS |
| 2 | Las tiendas realizan conteos cíclicos con frecuencias distintas. | POS |
| 3 | El WMS propone reposición nocturna. | WMS |
| 4 | Compras gestiona órdenes y fechas prometidas. | Compras |
| 5 | Promociones se cargan en una herramienta separada. | E-commerce |
| 6 | Gerencia revisa disponibilidad por familia cada semana. | WMS |

*La secuencia anterior es una descripción factual. Corresponde al equipo verificarla, delimitarla y convertirla en los modelos de proceso exigidos por el Integrador VIII.*

## 4. Actores que participan en el caso

| **Actor / área** | **Participación conocida al inicio** |
| --- | --- |
| Gerencia Comercial | Decisiones de surtido |
| Logística | Reposición |
| Compras | Proveedores |
| Jefes de tienda | Conteos |
| TI | Integración POS-WMS |

## 5. Inventario inicial de fuentes

| **Fuente** | **Responsable conocido** | **Formato** | **Actualización** | **Condición inicial** |
| --- | --- | --- | --- | --- |
| POS | Jefes de tienda | Base SQL / vista | Diaria | Acceso por rol; validación pendiente |
| WMS | Logística | API / eventos | Casi en tiempo real | Acceso por rol; validación pendiente |
| Compras | Compras | Archivo XLSX | Semanal | Acceso por rol; validación pendiente |
| E-commerce | Gerencia Comercial | CSV exportado | Mensual | Acceso por rol; validación pendiente |

## 6. Ficha técnica del dataset v0

| **Archivo de datos** | Datos_Iniciales_16_Casos_Integrador_VIII.xlsx |
| --- | --- |
| **Hoja asignada** | C03_Inventario |
| **Cantidad de registros** | 360 registros sintéticos |
| **Cantidad de variables** | 15 variables |
| **Variable de resultado disponible** | quiebre_stock: 1 = Semana con quiebre de inventario; 0 = caso contrario; vacío = no consolidado |
| **Copia de resguardo** | Conservar la hoja original como dataset v0; todas las transformaciones deben quedar en una versión derivada. |
| **Advertencia de calidad:** El dataset conserva de manera intencional valores faltantes, registros repetidos, etiquetas no normalizadas, cargas tardías y valores fuera de rango. No se indican sus cantidades ni ubicaciones: forman parte del diagnóstico que debe realizar el equipo. |  |

## 7. Diccionario preliminar de variables

| **Variable** | **Tipo** | **Descripción inicial** | **Uso conocido** |
| --- | --- | --- | --- |
| id_producto_tienda_semana | Texto | Identificador seudonimizado del registro | Clave operativa |
| inicio_semana | Fecha | Fecha del evento o corte | Tiempo |
| tienda | Texto | Ubicación/unidad: Jinotepe, Diriamba, San Marcos, Masatepe, Managua Sur | Segmentación |
| canal_venta | Texto | Canal/modalidad: Tienda, Web, WhatsApp, Mayorista | Segmentación |
| familia_producto | Texto | Segmento: Abarrotes, Lácteos, Higiene, Bebidas, Congelados | Segmentación |
| tipo_promocion | Texto | Categoría: Sin promoción, 2x1, Descuento, Combo, Temporada | Segmentación |
| ventas_unidades | Numérico | Medida operacional. Rango esperado 5-240 | Medición |
| dias_cobertura | Numérico | Duración/antigüedad. Rango esperado 0-35 | Medición |
| inventario_inicial | Numérico | Indicador operacional 1. Rango esperado 0-420 | Medición |
| dias_retraso_proveedor | Numérico | Indicador operacional 2. Rango esperado 0-18 | Medición |
| clasificacion_abc | Texto | Variable auxiliar: A, B, C | Contexto |
| sistema_origen | Texto | Sistema de procedencia: POS, WMS, Compras, E-commerce | Linaje |
| quiebre_stock | Binaria | 1 = Semana con quiebre de inventario; 0 = caso contrario; nulo = no consolidado | Resultado |
| uso_comercial_autorizado | Texto | Bandera de autorización o uso permitido según el caso | Gobierno |
| fecha_carga | Fecha | Fecha de incorporación al conjunto analítico | Oportunidad |

## 8. Informes operativos entregados

*Los siguientes cuadros son resúmenes neutrales del dataset v0. Las tasas, comparaciones, prioridades e interpretaciones deben ser calculadas y justificadas por el equipo.*

### Informe 1. Volumen mensual

| **Mes** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: ventas\_unidades** |
| --- | --- | --- | --- | --- |
| 2025-01 | 28 | 27 | 5 | 3,600 |
| 2025-02 | 17 | 17 | 8 | 1,831 |
| 2025-03 | 21 | 20 | 8 | 2,708 |
| 2025-04 | 17 | 17 | 4 | 1,303 |
| 2025-05 | 23 | 23 | 10 | 3,097 |
| 2025-06 | 23 | 22 | 7 | 2,709 |
| 2025-07 | 16 | 15 | 7 | 2,094 |
| 2025-08 | 30 | 29 | 10 | 4,047 |
| 2025-09 | 17 | 17 | 5 | 2,049 |
| 2025-10 | 24 | 24 | 14 | 3,058 |
| 2025-11 | 19 | 18 | 6 | 2,392 |
| 2025-12 | 18 | 18 | 10 | 1,896 |
| 2026-01 | 24 | 24 | 9 | 2,837 |
| 2026-02 | 20 | 20 | 10 | 2,506 |
| 2026-03 | 17 | 17 | 6 | 1,787 |
| 2026-04 | 14 | 14 | 6 | 1,371 |
| 2026-05 | 14 | 14 | 6 | 1,728 |
| 2026-06 | 18 | 18 | 8 | 1,925 |

### Informe 2. Desglose por canal_venta

| **canal\_venta** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: ventas\_unidades** |
| --- | --- | --- | --- | --- |
| (sin dato) | 9 | 8 | 2 | 929 |
| Mayorista | 66 | 65 | 34 | 8,058 |
| Tienda | 74 | 74 | 23 | 9,679 |
| Web | 105 | 103 | 35 | 12,330 |
| WhatsApp | 106 | 104 | 45 | 11,942 |

### Informe 3. Desglose por tipo_promocion

| **tipo\_promocion** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: ventas\_unidades** |
| --- | --- | --- | --- | --- |
| 2x1 | 79 | 78 | 33 | 10,070 |
| 2X1 | 1 | 1 | 1 | 120 |
| Combo | 56 | 56 | 19 | 6,178 |
| COMBO | 1 | 1 | 0 | 22 |
| Descuento | 82 | 79 | 24 | 9,850 |
| DESCUENTO | 1 | 0 | 0 | 93 |
| Sin promoción | 64 | 63 | 24 | 7,316 |
| SIN PROMOCIÓN | 1 | 1 | 0 | 156 |
| Temporada | 75 | 75 | 38 | 9,133 |

### Informe 4. Desglose por tienda

| **tienda** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: ventas\_unidades** |
| --- | --- | --- | --- | --- |
| Diriamba | 72 | 68 | 24 | 7,909 |
| Jinotepe | 74 | 74 | 29 | 8,767 |
| Managua Sur | 78 | 77 | 31 | 9,475 |
| Masatepe | 66 | 66 | 27 | 7,472 |
| San Marcos | 70 | 69 | 28 | 9,315 |

## 9. Referencias operativas y restricciones

|  |  |
| --- | --- |
| **Referencia comparativa** | Nivel de servicio referencial: 96%; quiebre máximo semanal: 4%; exactitud de inventario esperada: 98%. |
| **Privacidad y ética** | Los precios de compra y acuerdos con proveedores son reservados; el acceso debe separarse por función. |
| **Acceso inicial** | Lectura sobre dataset v0; cualquier dato derivado debe documentar origen, transformación y responsable. |
| **Uso permitido** | Exclusivamente académico dentro del Integrador VIII; no reutilizar nombres ficticios como si fueran organizaciones reales. |

## 10. Paquete recibido por el analista

| **N.º** | **Elemento** | **Contenido inicial** |
| --- | --- | --- |
| 1 | Este expediente de Fase 0 | Contexto, actores, proceso factual, fuentes, diccionario y reportes |
| 2 | Hoja C03_Inventario del libro de datos | 360 registros sin limpiar |
| 3 | Matriz Integradora y BOA | Criterios de los tres cortes y evidencias obligatorias |
| 4 | Guía de la primera fase | Orientación para organizar el primer incremento |

**CASO 4**

# Puntualidad y regularidad del transporte interurbano

*Movilidad del Sur Cooperativa | Transporte colectivo*

|  |
| --- |
| **Documento que recibe el analista:** Expediente inicial de Fase 0. Contiene hechos, fuentes y datos de partida; no contiene problema formulado, objetivos, KPIs resueltos, técnica de minería seleccionada, marco de gobierno, mapa AS-IS/TO-BE, conclusiones ni recomendaciones. |

## 1. Identificación y asignación

| **Equipo / estudiante** | **Integrantes** | **Fecha de asignación** |
| --- | --- | --- |

| **Organización** | Movilidad del Sur Cooperativa |
| --- | --- |
| **Sector y ubicación** | Transporte colectivo \| Corredor Carazo-Managua |
| **Operación** | 65 buses y 14 rutas con control GPS y despacho manual. |
| **Dimensión** | 9,600 viajes mensuales |
| **Periodo disponible** | enero 2025-junio 2026 |
| **Unidad de análisis** | viaje programado |
| **Decisión institucional** | Ajustar programación, despacho y mantenimiento según patrones operativos. |

## 2. Contexto entregado

Movilidad del Sur Cooperativa entrega al equipo un conjunto inicial compuesto por GPS, despacho, mantenimiento, clima y reclamos. La dirección solicita examinar los datos antes de formular el problema definitivo. El análisis debe distinguir hechos, supuestos y conclusiones, y conservar trazabilidad hacia cada fuente.

**Condición de trabajo.** *Los datos son sintéticos y fueron construidos para fines académicos, pero deben tratarse como si estuvieran sujetos a controles reales de acceso, seguridad, privacidad, calidad y ciclo de vida.*

## 3. Proceso operativo actual: hechos observados

| **Paso** | **Hecho operativo comunicado** | **Evidencia disponible** |
| --- | --- | --- |
| 1 | Despacho asigna unidad y conductor. | Despacho |
| 2 | El GPS transmite posiciones cada dos minutos. | GPS |
| 3 | La hora de llegada se estima con geocercas. | GPS |
| 4 | Mantenimiento registra intervenciones por unidad. | Mantenimiento |
| 5 | Reclamos se reciben por teléfono y redes. | Reclamos |
| 6 | Se consolida puntualidad al final de cada mes. | GPS |

*La secuencia anterior es una descripción factual. Corresponde al equipo verificarla, delimitarla y convertirla en los modelos de proceso exigidos por el Integrador VIII.*

## 4. Actores que participan en el caso

| **Actor / área** | **Participación conocida al inicio** |
| --- | --- |
| Consejo de Administración | Patrocinio |
| Despacho | Programación |
| Mantenimiento | Disponibilidad |
| Conductores | Registro operativo |
| TI/GPS | Calidad de trazas |

## 5. Inventario inicial de fuentes

| **Fuente** | **Responsable conocido** | **Formato** | **Actualización** | **Condición inicial** |
| --- | --- | --- | --- | --- |
| GPS | TI/GPS | Base SQL / vista | Diaria | Acceso por rol; validación pendiente |
| Despacho | Despacho | API / eventos | Casi en tiempo real | Acceso por rol; validación pendiente |
| Mantenimiento | Mantenimiento | Archivo XLSX | Semanal | Acceso por rol; validación pendiente |
| Reclamos | Atención al usuario | CSV exportado | Mensual | Acceso por rol; validación pendiente |

## 6. Ficha técnica del dataset v0

| **Archivo de datos** | Datos_Iniciales_16_Casos_Integrador_VIII.xlsx |
| --- | --- |
| **Hoja asignada** | C04_Transporte |
| **Cantidad de registros** | 360 registros sintéticos |
| **Cantidad de variables** | 15 variables |
| **Variable de resultado disponible** | retraso_mayor_15_min: 1 = Llegada con retraso mayor a 15 minutos; 0 = caso contrario; vacío = no consolidado |
| **Copia de resguardo** | Conservar la hoja original como dataset v0; todas las transformaciones deben quedar en una versión derivada. |
| **Advertencia de calidad:** El dataset conserva de manera intencional valores faltantes, registros repetidos, etiquetas no normalizadas, cargas tardías y valores fuera de rango. No se indican sus cantidades ni ubicaciones: forman parte del diagnóstico que debe realizar el equipo. |  |

## 7. Diccionario preliminar de variables

| **Variable** | **Tipo** | **Descripción inicial** | **Uso conocido** |
| --- | --- | --- | --- |
| id_viaje | Texto | Identificador seudonimizado del registro | Clave operativa |
| fecha_salida | Fecha | Fecha del evento o corte | Tiempo |
| ruta | Texto | Ubicación/unidad: Jinotepe-Managua, Diriamba-Managua, San Marcos-Managua, Jinotepe-Rivas, Diriamba-Masaya | Segmentación |
| franja_horaria | Texto | Canal/modalidad: Pico AM, Valle AM, Pico PM, Nocturno | Segmentación |
| tipo_dia | Texto | Segmento: Laborable, Sábado, Domingo, Feriado | Segmentación |
| estado_clima | Texto | Categoría: Despejado, Lluvia ligera, Lluvia fuerte, Incidencia vial | Segmentación |
| pasajeros_estimados | Numérico | Medida operacional. Rango esperado 12-72 | Medición |
| duracion_real_min | Numérico | Duración/antigüedad. Rango esperado 45-160 | Medición |
| minutos_retraso_salida | Numérico | Indicador operacional 1. Rango esperado 0-35 | Medición |
| dias_desde_mantenimiento | Numérico | Indicador operacional 2. Rango esperado 0-90 | Medición |
| tipo_unidad | Texto | Variable auxiliar: Bus estándar, Bus expreso, Microbús | Contexto |
| sistema_origen | Texto | Sistema de procedencia: GPS, Despacho, Mantenimiento, Reclamos | Linaje |
| retraso_mayor_15_min | Binaria | 1 = Llegada con retraso mayor a 15 minutos; 0 = caso contrario; nulo = no consolidado | Resultado |
| gps_autorizado | Texto | Bandera de autorización o uso permitido según el caso | Gobierno |
| fecha_carga | Fecha | Fecha de incorporación al conjunto analítico | Oportunidad |

## 8. Informes operativos entregados

*Los siguientes cuadros son resúmenes neutrales del dataset v0. Las tasas, comparaciones, prioridades e interpretaciones deben ser calculadas y justificadas por el equipo.*

### Informe 1. Volumen mensual

| **Mes** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: pasajeros\_estimados** |
| --- | --- | --- | --- | --- |
| 2025-01 | 27 | 27 | 11 | 1,241 |
| 2025-02 | 13 | 13 | 7 | 606 |
| 2025-03 | 19 | 19 | 11 | 825 |
| 2025-04 | 19 | 19 | 9 | 789 |
| 2025-05 | 19 | 19 | 8 | 775 |
| 2025-06 | 18 | 16 | 6 | 828 |
| 2025-07 | 21 | 21 | 13 | 903 |
| 2025-08 | 20 | 19 | 7 | 880 |
| 2025-09 | 25 | 25 | 6 | 956 |
| 2025-10 | 21 | 21 | 10 | 914 |
| 2025-11 | 19 | 19 | 9 | 886 |
| 2025-12 | 15 | 15 | 5 | 657 |
| 2026-01 | 26 | 26 | 6 | 1,239 |
| 2026-02 | 22 | 21 | 12 | 838 |
| 2026-03 | 17 | 17 | 7 | 766 |
| 2026-04 | 23 | 22 | 10 | 849 |
| 2026-05 | 14 | 14 | 8 | 475 |
| 2026-06 | 22 | 21 | 9 | 889 |

### Informe 2. Desglose por franja_horaria

| **franja\_horaria** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: pasajeros\_estimados** |
| --- | --- | --- | --- | --- |
| (sin dato) | 9 | 8 | 7 | 444 |
| Nocturno | 81 | 81 | 31 | 3,436 |
| Pico AM | 81 | 79 | 36 | 3,623 |
| Pico PM | 93 | 90 | 42 | 3,829 |
| Valle AM | 96 | 96 | 38 | 3,984 |

### Informe 3. Desglose por estado_clima

| **estado\_clima** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: pasajeros\_estimados** |
| --- | --- | --- | --- | --- |
| Despejado | 94 | 93 | 24 | 3,711 |
| Incidencia vial | 77 | 76 | 38 | 3,292 |
| Lluvia fuerte | 102 | 100 | 60 | 4,476 |
| Lluvia ligera | 83 | 82 | 31 | 3,688 |
| LLUVIA LIGERA | 4 | 3 | 1 | 149 |

### Informe 4. Desglose por ruta

| **ruta** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: pasajeros\_estimados** |
| --- | --- | --- | --- | --- |
| Diriamba-Managua | 72 | 71 | 27 | 3,146 |
| Diriamba-Masaya | 70 | 69 | 34 | 2,687 |
| Jinotepe-Managua | 69 | 66 | 22 | 2,911 |
| Jinotepe-Rivas | 69 | 68 | 33 | 3,120 |
| San Marcos-Managua | 80 | 80 | 38 | 3,452 |

## 9. Referencias operativas y restricciones

|  |  |
| --- | --- |
| **Referencia comparativa** | Puntualidad operacional esperada: 85%; GPS disponible al menos 97% del tiempo; tolerancia de llegada: 15 minutos. |
| **Privacidad y ética** | Las trazas GPS solo se usarán para fines operativos; no deben publicarse datos identificables del personal. |
| **Acceso inicial** | Lectura sobre dataset v0; cualquier dato derivado debe documentar origen, transformación y responsable. |
| **Uso permitido** | Exclusivamente académico dentro del Integrador VIII; no reutilizar nombres ficticios como si fueran organizaciones reales. |

## 10. Paquete recibido por el analista

| **N.º** | **Elemento** | **Contenido inicial** |
| --- | --- | --- |
| 1 | Este expediente de Fase 0 | Contexto, actores, proceso factual, fuentes, diccionario y reportes |
| 2 | Hoja C04_Transporte del libro de datos | 360 registros sin limpiar |
| 3 | Matriz Integradora y BOA | Criterios de los tres cortes y evidencias obligatorias |
| 4 | Guía de la primera fase | Orientación para organizar el primer incremento |

**CASO 5**

# Seguimiento de cartera de microcrédito

*Financiera Emprende Segura | Microfinanzas*

|  |
| --- |
| **Documento que recibe el analista:** Expediente inicial de Fase 0. Contiene hechos, fuentes y datos de partida; no contiene problema formulado, objetivos, KPIs resueltos, técnica de minería seleccionada, marco de gobierno, mapa AS-IS/TO-BE, conclusiones ni recomendaciones. |

## 1. Identificación y asignación

| **Equipo / estudiante** | **Integrantes** | **Fecha de asignación** |
| --- | --- | --- |

| **Organización** | Financiera Emprende Segura |
| --- | --- |
| **Sector y ubicación** | Microfinanzas \| Región del Pacífico |
| **Operación** | Créditos productivos individuales y solidarios. |
| **Dimensión** | 18,400 créditos activos; 22 oficinas |
| **Periodo disponible** | enero 2023-junio 2026 |
| **Unidad de análisis** | crédito-mes |
| **Decisión institucional** | Organizar seguimiento preventivo y asignación de gestores sin automatizar decisiones de aprobación. |

## 2. Contexto entregado

Financiera Emprende Segura entrega al equipo un conjunto inicial compuesto por Originación, pagos, visitas, actividad económica y buró autorizado. La dirección solicita examinar los datos antes de formular el problema definitivo. El análisis debe distinguir hechos, supuestos y conclusiones, y conservar trazabilidad hacia cada fuente.

**Condición de trabajo.** *Los datos son sintéticos y fueron construidos para fines académicos, pero deben tratarse como si estuvieran sujetos a controles reales de acceso, seguridad, privacidad, calidad y ciclo de vida.*

## 3. Proceso operativo actual: hechos observados

| **Paso** | **Hecho operativo comunicado** | **Evidencia disponible** |
| --- | --- | --- |
| 1 | La oficina registra el crédito en el sistema central. | Core crédito |
| 2 | Caja aplica pagos al cierre diario. | Caja |
| 3 | Gestores sincronizan visitas desde dispositivos móviles. | Gestión móvil |
| 4 | Cobranza recibe listados por antigüedad de mora. | Core crédito |
| 5 | Riesgos consolida indicadores mensuales. | Core crédito |
| 6 | Cumplimiento revisa accesos y consultas seleccionadas. | Buró autorizado |

*La secuencia anterior es una descripción factual. Corresponde al equipo verificarla, delimitarla y convertirla en los modelos de proceso exigidos por el Integrador VIII.*

## 4. Actores que participan en el caso

| **Actor / área** | **Participación conocida al inicio** |
| --- | --- |
| Gerencia de Riesgos | Criterios |
| Crédito | Originación |
| Cobranza | Seguimiento |
| Cumplimiento | Uso legítimo |
| TI | Acceso y auditoría |

## 5. Inventario inicial de fuentes

| **Fuente** | **Responsable conocido** | **Formato** | **Actualización** | **Condición inicial** |
| --- | --- | --- | --- | --- |
| Core crédito | Crédito | Base SQL / vista | Diaria | Acceso por rol; validación pendiente |
| Caja | Tesorería y caja | API / eventos | Casi en tiempo real | Acceso por rol; validación pendiente |
| Gestión móvil | Cobranza | Archivo XLSX | Semanal | Acceso por rol; validación pendiente |
| Buró autorizado | Cumplimiento | CSV exportado | Mensual | Acceso por rol; validación pendiente |

## 6. Ficha técnica del dataset v0

| **Archivo de datos** | Datos_Iniciales_16_Casos_Integrador_VIII.xlsx |
| --- | --- |
| **Hoja asignada** | C05_Microcredito |
| **Cantidad de registros** | 360 registros sintéticos |
| **Cantidad de variables** | 15 variables |
| **Variable de resultado disponible** | mora_mayor_30_dias: 1 = Crédito con mora mayor a 30 días; 0 = caso contrario; vacío = no consolidado |
| **Copia de resguardo** | Conservar la hoja original como dataset v0; todas las transformaciones deben quedar en una versión derivada. |
| **Advertencia de calidad:** El dataset conserva de manera intencional valores faltantes, registros repetidos, etiquetas no normalizadas, cargas tardías y valores fuera de rango. No se indican sus cantidades ni ubicaciones: forman parte del diagnóstico que debe realizar el equipo. |  |

## 7. Diccionario preliminar de variables

| **Variable** | **Tipo** | **Descripción inicial** | **Uso conocido** |
| --- | --- | --- | --- |
| id_credito_mes | Texto | Identificador seudonimizado del registro | Clave operativa |
| fecha_corte | Fecha | Fecha del evento o corte | Tiempo |
| sucursal | Texto | Ubicación/unidad: Jinotepe, Masaya, Rivas, Granada, Managua | Segmentación |
| tipo_credito | Texto | Canal/modalidad: Individual, Solidario, Estacional, Capital de trabajo | Segmentación |
| actividad_economica | Texto | Segmento: Comercio, Agricultura, Servicios, Manufactura, Transporte | Segmentación |
| frecuencia_pago | Texto | Categoría: Semanal, Quincenal, Mensual, Estacional | Segmentación |
| saldo_usd | Numérico | Medida operacional. Rango esperado 120-6500 | Medición |
| antiguedad_credito_dias | Numérico | Duración/antigüedad. Rango esperado 15-720 | Medición |
| cuotas_atrasadas | Numérico | Indicador operacional 1. Rango esperado 0-5 | Medición |
| visitas_gestor_90d | Numérico | Indicador operacional 2. Rango esperado 0-8 | Medición |
| garantia | Texto | Variable auxiliar: Solidaria, Prendaria, Fiduciaria, Sin garantía real | Contexto |
| sistema_origen | Texto | Sistema de procedencia: Core crédito, Caja, Gestión móvil, Buró autorizado | Linaje |
| mora_mayor_30_dias | Binaria | 1 = Crédito con mora mayor a 30 días; 0 = caso contrario; nulo = no consolidado | Resultado |
| consulta_autorizada | Texto | Bandera de autorización o uso permitido según el caso | Gobierno |
| fecha_carga | Fecha | Fecha de incorporación al conjunto analítico | Oportunidad |

## 8. Informes operativos entregados

*Los siguientes cuadros son resúmenes neutrales del dataset v0. Las tasas, comparaciones, prioridades e interpretaciones deben ser calculadas y justificadas por el equipo.*

### Informe 1. Volumen mensual

| **Mes** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: saldo\_usd** |
| --- | --- | --- | --- | --- |
| 2025-01 | 15 | 15 | 7 | 43,565 |
| 2025-02 | 22 | 21 | 7 | 72,156 |
| 2025-03 | 24 | 24 | 11 | 80,769 |
| 2025-04 | 21 | 21 | 9 | 76,292 |
| 2025-05 | 23 | 23 | 12 | 63,619 |
| 2025-06 | 27 | 27 | 14 | 112,436 |
| 2025-07 | 19 | 18 | 5 | 48,793 |
| 2025-08 | 13 | 12 | 4 | 37,989 |
| 2025-09 | 18 | 17 | 6 | 58,431 |
| 2025-10 | 26 | 26 | 9 | 106,881 |
| 2025-11 | 21 | 21 | 5 | 55,385 |
| 2025-12 | 20 | 20 | 6 | 63,954 |
| 2026-01 | 21 | 21 | 4 | 65,692 |
| 2026-02 | 13 | 13 | 6 | 46,181 |
| 2026-03 | 18 | 17 | 8 | 63,811 |
| 2026-04 | 19 | 19 | 12 | 64,803 |
| 2026-05 | 22 | 21 | 7 | 76,017 |
| 2026-06 | 18 | 18 | 6 | 55,800 |

### Informe 2. Desglose por tipo_credito

| **tipo\_credito** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: saldo\_usd** |
| --- | --- | --- | --- | --- |
| (sin dato) | 9 | 8 | 4 | 31,493 |
| Capital de trabajo | 82 | 81 | 35 | 271,299 |
| Estacional | 94 | 94 | 46 | 314,222 |
| Individual | 78 | 77 | 17 | 245,524 |
| Solidario | 97 | 94 | 36 | 330,036 |

### Informe 3. Desglose por frecuencia_pago

| **frecuencia\_pago** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: saldo\_usd** |
| --- | --- | --- | --- | --- |
| Estacional | 80 | 77 | 46 | 252,530 |
| ESTACIONAL | 3 | 3 | 1 | 8,980 |
| Mensual | 96 | 95 | 32 | 326,631 |
| Quincenal | 85 | 84 | 33 | 274,958 |
| Semanal | 95 | 95 | 26 | 327,620 |
| SEMANAL | 1 | 0 | 0 | 1,855 |

### Informe 4. Desglose por sucursal

| **sucursal** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: saldo\_usd** |
| --- | --- | --- | --- | --- |
| Granada | 68 | 65 | 27 | 248,669 |
| Jinotepe | 57 | 57 | 23 | 181,698 |
| Managua | 69 | 68 | 25 | 236,728 |
| Masaya | 87 | 85 | 36 | 283,624 |
| Rivas | 79 | 79 | 27 | 241,855 |

## 9. Referencias operativas y restricciones

|  |  |
| --- | --- |
| **Referencia comparativa** | Cartera en riesgo mayor a 30 días de referencia: 5%; registros de pago conciliados en T+1; trazabilidad de consultas: 100%. |
| **Privacidad y ética** | No usar variables protegidas para negar créditos; las salidas son apoyo al seguimiento y requieren revisión humana. |
| **Acceso inicial** | Lectura sobre dataset v0; cualquier dato derivado debe documentar origen, transformación y responsable. |
| **Uso permitido** | Exclusivamente académico dentro del Integrador VIII; no reutilizar nombres ficticios como si fueran organizaciones reales. |

## 10. Paquete recibido por el analista

| **N.º** | **Elemento** | **Contenido inicial** |
| --- | --- | --- |
| 1 | Este expediente de Fase 0 | Contexto, actores, proceso factual, fuentes, diccionario y reportes |
| 2 | Hoja C05_Microcredito del libro de datos | 360 registros sin limpiar |
| 3 | Matriz Integradora y BOA | Criterios de los tres cortes y evidencias obligatorias |
| 4 | Guía de la primera fase | Orientación para organizar el primer incremento |

**CASO 6**

# Rendimiento y pérdidas en producción hortícola

*Cooperativa AgroVerde | Agroindustria*

|  |
| --- |
| **Documento que recibe el analista:** Expediente inicial de Fase 0. Contiene hechos, fuentes y datos de partida; no contiene problema formulado, objetivos, KPIs resueltos, técnica de minería seleccionada, marco de gobierno, mapa AS-IS/TO-BE, conclusiones ni recomendaciones. |

## 1. Identificación y asignación

| **Equipo / estudiante** | **Integrantes** | **Fecha de asignación** |
| --- | --- | --- |

| **Organización** | Cooperativa AgroVerde |
| --- | --- |
| **Sector y ubicación** | Agroindustria \| Meseta de los Pueblos |
| **Operación** | Tomate, chiltoma y pepino en 42 fincas asociadas. |
| **Dimensión** | 310 parcelas; 2 ciclos productivos anuales |
| **Periodo disponible** | 2023-2026 |
| **Unidad de análisis** | parcela-ciclo |
| **Decisión institucional** | Priorizar asistencia técnica, riego y cosecha según evidencia de campo. |

## 2. Contexto entregado

Cooperativa AgroVerde entrega al equipo un conjunto inicial compuesto por Sensores, bitácoras, laboratorio, clima y recepción de planta. La dirección solicita examinar los datos antes de formular el problema definitivo. El análisis debe distinguir hechos, supuestos y conclusiones, y conservar trazabilidad hacia cada fuente.

**Condición de trabajo.** *Los datos son sintéticos y fueron construidos para fines académicos, pero deben tratarse como si estuvieran sujetos a controles reales de acceso, seguridad, privacidad, calidad y ciclo de vida.*

## 3. Proceso operativo actual: hechos observados

| **Paso** | **Hecho operativo comunicado** | **Evidencia disponible** |
| --- | --- | --- |
| 1 | Se registra la siembra y variedad. | Bitácora móvil |
| 2 | Sensores transmiten humedad y temperatura. | IoT campo |
| 3 | Técnicos capturan labores en la aplicación móvil. | Bitácora móvil |
| 4 | Laboratorio entrega resultados en hojas de cálculo. | Laboratorio |
| 5 | Planta registra peso y rechazo por lote. | Recepción planta |
| 6 | La cooperativa compara rendimientos al final del ciclo. | Recepción planta |

*La secuencia anterior es una descripción factual. Corresponde al equipo verificarla, delimitarla y convertirla en los modelos de proceso exigidos por el Integrador VIII.*

## 4. Actores que participan en el caso

| **Actor / área** | **Participación conocida al inicio** |
| --- | --- |
| Consejo de Cooperativa | Patrocinio |
| Asistencia Técnica | Uso del análisis |
| Productores | Origen de datos |
| Laboratorio | Calidad de mediciones |
| TI/IoT | Sensores y almacenamiento |

## 5. Inventario inicial de fuentes

| **Fuente** | **Responsable conocido** | **Formato** | **Actualización** | **Condición inicial** |
| --- | --- | --- | --- | --- |
| IoT campo | TI/IoT | Base SQL / vista | Diaria | Acceso por rol; validación pendiente |
| Bitácora móvil | Asistencia Técnica | API / eventos | Casi en tiempo real | Acceso por rol; validación pendiente |
| Laboratorio | Laboratorio | Archivo XLSX | Semanal | Acceso por rol; validación pendiente |
| Recepción planta | Recepción de planta | CSV exportado | Mensual | Acceso por rol; validación pendiente |

## 6. Ficha técnica del dataset v0

| **Archivo de datos** | Datos_Iniciales_16_Casos_Integrador_VIII.xlsx |
| --- | --- |
| **Hoja asignada** | C06_Agro |
| **Cantidad de registros** | 360 registros sintéticos |
| **Cantidad de variables** | 15 variables |
| **Variable de resultado disponible** | rendimiento_bajo: 1 = Rendimiento por debajo del umbral técnico; 0 = caso contrario; vacío = no consolidado |
| **Copia de resguardo** | Conservar la hoja original como dataset v0; todas las transformaciones deben quedar en una versión derivada. |
| **Advertencia de calidad:** El dataset conserva de manera intencional valores faltantes, registros repetidos, etiquetas no normalizadas, cargas tardías y valores fuera de rango. No se indican sus cantidades ni ubicaciones: forman parte del diagnóstico que debe realizar el equipo. |  |

## 7. Diccionario preliminar de variables

| **Variable** | **Tipo** | **Descripción inicial** | **Uso conocido** |
| --- | --- | --- | --- |
| id_parcela_ciclo | Texto | Identificador seudonimizado del registro | Clave operativa |
| fecha_siembra | Fecha | Fecha del evento o corte | Tiempo |
| zona | Texto | Ubicación/unidad: Diriá, Diriomo, Catarina, San Marcos, La Conquista | Segmentación |
| sistema_riego | Texto | Canal/modalidad: Goteo, Microaspersión, Gravedad, Manual | Segmentación |
| cultivo | Texto | Segmento: Tomate, Chiltoma, Pepino | Segmentación |
| tipo_suelo | Texto | Categoría: Franco, Franco arcilloso, Arenoso, Arcilloso | Segmentación |
| rendimiento_ton_ha | Numérico | Medida operacional. Rango esperado 8-48 | Medición |
| dias_ciclo | Numérico | Duración/antigüedad. Rango esperado 55-130 | Medición |
| humedad_promedio_pct | Numérico | Indicador operacional 1. Rango esperado 25-95 | Medición |
| aplicaciones_fitosanitarias | Numérico | Indicador operacional 2. Rango esperado 0-12 | Medición |
| variedad | Texto | Variable auxiliar: Tradicional, Híbrida A, Híbrida B, Resistente | Contexto |
| sistema_origen | Texto | Sistema de procedencia: IoT campo, Bitácora móvil, Laboratorio, Recepción planta | Linaje |
| rendimiento_bajo | Binaria | 1 = Rendimiento por debajo del umbral técnico; 0 = caso contrario; nulo = no consolidado | Resultado |
| datos_productivos_autorizados | Texto | Bandera de autorización o uso permitido según el caso | Gobierno |
| fecha_carga | Fecha | Fecha de incorporación al conjunto analítico | Oportunidad |

## 8. Informes operativos entregados

*Los siguientes cuadros son resúmenes neutrales del dataset v0. Las tasas, comparaciones, prioridades e interpretaciones deben ser calculadas y justificadas por el equipo.*

### Informe 1. Volumen mensual

| **Mes** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: rendimiento\_ton\_ha** |
| --- | --- | --- | --- | --- |
| 2025-01 | 21 | 21 | 7 | 591.9 |
| 2025-02 | 22 | 22 | 10 | 611.9 |
| 2025-03 | 20 | 19 | 10 | 503.8 |
| 2025-04 | 11 | 11 | 1 | 236.6 |
| 2025-05 | 24 | 24 | 6 | 718.8 |
| 2025-06 | 16 | 14 | 1 | 448.5 |
| 2025-07 | 26 | 26 | 13 | 802.4 |
| 2025-08 | 22 | 22 | 9 | 660.1 |
| 2025-09 | 21 | 20 | 9 | 652.5 |
| 2025-10 | 19 | 18 | 6 | 662.5 |
| 2025-11 | 13 | 13 | 8 | 351.9 |
| 2025-12 | 20 | 20 | 12 | 579.4 |
| 2026-01 | 28 | 28 | 15 | 806.5 |
| 2026-02 | 15 | 15 | 6 | 480.3 |
| 2026-03 | 14 | 14 | 5 | 385.8 |
| 2026-04 | 18 | 18 | 9 | 460.7 |
| 2026-05 | 26 | 25 | 10 | 667.8 |
| 2026-06 | 24 | 24 | 12 | 747.9 |

### Informe 2. Desglose por sistema_riego

| **sistema\_riego** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: rendimiento\_ton\_ha** |
| --- | --- | --- | --- | --- |
| (sin dato) | 9 | 8 | 4 | 257 |
| Goteo | 93 | 89 | 36 | 2,678.5 |
| Gravedad | 90 | 90 | 38 | 2,642.6 |
| Manual | 89 | 89 | 39 | 2,511.4 |
| Microaspersión | 79 | 78 | 32 | 2,279.8 |

### Informe 3. Desglose por tipo_suelo

| **tipo\_suelo** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: rendimiento\_ton\_ha** |
| --- | --- | --- | --- | --- |
| Arcilloso | 79 | 75 | 38 | 2,290.6 |
| ARCILLOSO | 1 | 1 | 0 | 42.9 |
| Arenoso | 103 | 103 | 42 | 2,979.6 |
| ARENOSO | 1 | 1 | 1 | 9.8 |
| Franco | 73 | 73 | 32 | 1,977.3 |
| FRANCO | 1 | 0 | 0 | 28.6 |
| Franco arcilloso | 101 | 100 | 35 | 3,002.3 |
| FRANCO ARCILLOSO | 1 | 1 | 1 | 38.2 |

### Informe 4. Desglose por zona

| **zona** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: rendimiento\_ton\_ha** |
| --- | --- | --- | --- | --- |
| Catarina | 79 | 79 | 33 | 2,200.5 |
| Diriá | 68 | 66 | 24 | 2,126.2 |
| Diriomo | 65 | 65 | 31 | 1,974.2 |
| La Conquista | 78 | 75 | 34 | 2,232.9 |
| San Marcos | 70 | 69 | 27 | 1,835.5 |

## 9. Referencias operativas y restricciones

|  |  |
| --- | --- |
| **Referencia comparativa** | Umbral técnico referencial por cultivo definido por la cooperativa; sensores con disponibilidad esperada de 95%; datos históricos retenidos por 3 años. |
| **Privacidad y ética** | La productividad por finca es reservada y no debe utilizarse para sancionar asociados sin validación de campo. |
| **Acceso inicial** | Lectura sobre dataset v0; cualquier dato derivado debe documentar origen, transformación y responsable. |
| **Uso permitido** | Exclusivamente académico dentro del Integrador VIII; no reutilizar nombres ficticios como si fueran organizaciones reales. |

## 10. Paquete recibido por el analista

| **N.º** | **Elemento** | **Contenido inicial** |
| --- | --- | --- |
| 1 | Este expediente de Fase 0 | Contexto, actores, proceso factual, fuentes, diccionario y reportes |
| 2 | Hoja C06_Agro del libro de datos | 360 registros sin limpiar |
| 3 | Matriz Integradora y BOA | Criterios de los tres cortes y evidencias obligatorias |
| 4 | Guía de la primera fase | Orientación para organizar el primer incremento |

**CASO 7**

# Permanencia de clientes en servicios de telecomunicaciones

*ConectaNica Telecom | Telecomunicaciones*

|  |
| --- |
| **Documento que recibe el analista:** Expediente inicial de Fase 0. Contiene hechos, fuentes y datos de partida; no contiene problema formulado, objetivos, KPIs resueltos, técnica de minería seleccionada, marco de gobierno, mapa AS-IS/TO-BE, conclusiones ni recomendaciones. |

## 1. Identificación y asignación

| **Equipo / estudiante** | **Integrantes** | **Fecha de asignación** |
| --- | --- | --- |

| **Organización** | ConectaNica Telecom |
| --- | --- |
| **Sector y ubicación** | Telecomunicaciones \| Pacífico y región central |
| **Operación** | Internet fijo, televisión y telefonía para hogares y pymes. |
| **Dimensión** | 64,000 contratos; 12 centros de servicio |
| **Periodo disponible** | enero 2024-junio 2026 |
| **Unidad de análisis** | cliente-mes |
| **Decisión institucional** | Priorizar mejoras de servicio y atención para reducir bajas evitables. |

## 2. Contexto entregado

ConectaNica Telecom entrega al equipo un conjunto inicial compuesto por Facturación, red, CRM, soporte y encuestas. La dirección solicita examinar los datos antes de formular el problema definitivo. El análisis debe distinguir hechos, supuestos y conclusiones, y conservar trazabilidad hacia cada fuente.

**Condición de trabajo.** *Los datos son sintéticos y fueron construidos para fines académicos, pero deben tratarse como si estuvieran sujetos a controles reales de acceso, seguridad, privacidad, calidad y ciclo de vida.*

## 3. Proceso operativo actual: hechos observados

| **Paso** | **Hecho operativo comunicado** | **Evidencia disponible** |
| --- | --- | --- |
| 1 | CRM crea y modifica el contrato. | CRM |
| 2 | Billing emite facturas y aplica pagos. | Billing |
| 3 | NOC registra alarmas por nodo. | NOC |
| 4 | Soporte abre tickets por diversos canales. | Mesa de ayuda |
| 5 | Retención documenta motivos de baja en texto libre. | CRM |
| 6 | Gerencia recibe un tablero mensual. | CRM |

*La secuencia anterior es una descripción factual. Corresponde al equipo verificarla, delimitarla y convertirla en los modelos de proceso exigidos por el Integrador VIII.*

## 4. Actores que participan en el caso

| **Actor / área** | **Participación conocida al inicio** |
| --- | --- |
| Experiencia del Cliente | Patrocinio |
| NOC | Eventos de red |
| Facturación | Pagos |
| Soporte | Contactos |
| Gobierno/Seguridad | Accesos |

## 5. Inventario inicial de fuentes

| **Fuente** | **Responsable conocido** | **Formato** | **Actualización** | **Condición inicial** |
| --- | --- | --- | --- | --- |
| CRM | Experiencia del Cliente | Base SQL / vista | Diaria | Acceso por rol; validación pendiente |
| Billing | Facturación | API / eventos | Casi en tiempo real | Acceso por rol; validación pendiente |
| NOC | NOC | Archivo XLSX | Semanal | Acceso por rol; validación pendiente |
| Mesa de ayuda | Soporte | CSV exportado | Mensual | Acceso por rol; validación pendiente |

## 6. Ficha técnica del dataset v0

| **Archivo de datos** | Datos_Iniciales_16_Casos_Integrador_VIII.xlsx |
| --- | --- |
| **Hoja asignada** | C07_Telecom |
| **Cantidad de registros** | 360 registros sintéticos |
| **Cantidad de variables** | 15 variables |
| **Variable de resultado disponible** | baja_90_dias: 1 = Cliente que cancela dentro de 90 días; 0 = caso contrario; vacío = no consolidado |
| **Copia de resguardo** | Conservar la hoja original como dataset v0; todas las transformaciones deben quedar en una versión derivada. |
| **Advertencia de calidad:** El dataset conserva de manera intencional valores faltantes, registros repetidos, etiquetas no normalizadas, cargas tardías y valores fuera de rango. No se indican sus cantidades ni ubicaciones: forman parte del diagnóstico que debe realizar el equipo. |  |

## 7. Diccionario preliminar de variables

| **Variable** | **Tipo** | **Descripción inicial** | **Uso conocido** |
| --- | --- | --- | --- |
| id_cliente_mes | Texto | Identificador seudonimizado del registro | Clave operativa |
| fecha_corte | Fecha | Fecha del evento o corte | Tiempo |
| zona_servicio | Texto | Ubicación/unidad: Carazo, Masaya, Granada, Managua, Boaco | Segmentación |
| plan_contratado | Texto | Canal/modalidad: Básico, Hogar Plus, Fibra, Pyme | Segmentación |
| tipo_cliente | Texto | Segmento: Hogar, Pyme, Institución, Temporal | Segmentación |
| canal_atencion | Texto | Categoría: App, Call center, Tienda, Técnico de campo | Segmentación |
| factura_usd | Numérico | Medida operacional. Rango esperado 12-145 | Medición |
| antiguedad_meses | Numérico | Duración/antigüedad. Rango esperado 1-96 | Medición |
| incidencias_red_30d | Numérico | Indicador operacional 1. Rango esperado 0-12 | Medición |
| contactos_soporte_30d | Numérico | Indicador operacional 2. Rango esperado 0-10 | Medición |
| medio_pago | Texto | Variable auxiliar: Débito, Caja, Agente, Transferencia | Contexto |
| sistema_origen | Texto | Sistema de procedencia: CRM, Billing, NOC, Mesa de ayuda | Linaje |
| baja_90_dias | Binaria | 1 = Cliente que cancela dentro de 90 días; 0 = caso contrario; nulo = no consolidado | Resultado |
| uso_analitico_autorizado | Texto | Bandera de autorización o uso permitido según el caso | Gobierno |
| fecha_carga | Fecha | Fecha de incorporación al conjunto analítico | Oportunidad |

## 8. Informes operativos entregados

*Los siguientes cuadros son resúmenes neutrales del dataset v0. Las tasas, comparaciones, prioridades e interpretaciones deben ser calculadas y justificadas por el equipo.*

### Informe 1. Volumen mensual

| **Mes** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: factura\_usd** |
| --- | --- | --- | --- | --- |
| 2025-01 | 24 | 24 | 8 | 2,253 |
| 2025-02 | 26 | 26 | 11 | 2,432 |
| 2025-03 | 21 | 20 | 10 | 1,466 |
| 2025-04 | 27 | 27 | 9 | 2,053 |
| 2025-05 | 13 | 13 | 4 | 942 |
| 2025-06 | 21 | 21 | 10 | 1,528 |
| 2025-07 | 18 | 18 | 4 | 1,410 |
| 2025-08 | 24 | 23 | 8 | 1,605 |
| 2025-09 | 23 | 23 | 5 | 1,874 |
| 2025-10 | 18 | 18 | 9 | 1,304 |
| 2025-11 | 20 | 20 | 6 | 1,723 |
| 2025-12 | 22 | 22 | 6 | 1,587 |
| 2026-01 | 13 | 13 | 7 | 989 |
| 2026-02 | 14 | 13 | 3 | 1,175 |
| 2026-03 | 19 | 18 | 5 | 1,581 |
| 2026-04 | 24 | 24 | 11 | 1,929 |
| 2026-05 | 18 | 16 | 5 | 1,414 |
| 2026-06 | 15 | 15 | 7 | 1,084 |

### Informe 2. Desglose por plan_contratado

| **plan\_contratado** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: factura\_usd** |
| --- | --- | --- | --- | --- |
| (sin dato) | 9 | 8 | 3 | 721 |
| Básico | 85 | 83 | 31 | 6,716 |
| Fibra | 109 | 109 | 35 | 8,624 |
| Hogar Plus | 85 | 83 | 28 | 7,111 |
| Pyme | 72 | 71 | 31 | 5,177 |

### Informe 3. Desglose por canal_atencion

| **canal\_atencion** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: factura\_usd** |
| --- | --- | --- | --- | --- |
| App | 87 | 84 | 31 | 6,756 |
| APP | 1 | 0 | 0 | 68 |
| Call center | 96 | 96 | 41 | 7,826 |
| CALL CENTER | 2 | 2 | 0 | 98 |
| Técnico de campo | 80 | 78 | 25 | 6,840 |
| TÉCNICO DE CAMPO | 1 | 1 | 0 | 26 |
| Tienda | 93 | 93 | 31 | 6,735 |

### Informe 4. Desglose por zona_servicio

| **zona\_servicio** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: factura\_usd** |
| --- | --- | --- | --- | --- |
| Boaco | 70 | 70 | 22 | 5,321 |
| Carazo | 70 | 67 | 25 | 5,874 |
| Granada | 76 | 76 | 24 | 5,662 |
| Managua | 73 | 73 | 29 | 5,503 |
| Masaya | 71 | 68 | 28 | 5,989 |

## 9. Referencias operativas y restricciones

|  |  |
| --- | --- |
| **Referencia comparativa** | Baja mensual referencial: 2.2%; disponibilidad comprometida según plan: 97.5%-99%; conciliación de contratos diaria. |
| **Privacidad y ética** | No analizar contenido de comunicaciones; usar solo metadatos autorizados y variables de servicio. |
| **Acceso inicial** | Lectura sobre dataset v0; cualquier dato derivado debe documentar origen, transformación y responsable. |
| **Uso permitido** | Exclusivamente académico dentro del Integrador VIII; no reutilizar nombres ficticios como si fueran organizaciones reales. |

## 10. Paquete recibido por el analista

| **N.º** | **Elemento** | **Contenido inicial** |
| --- | --- | --- |
| 1 | Este expediente de Fase 0 | Contexto, actores, proceso factual, fuentes, diccionario y reportes |
| 2 | Hoja C07_Telecom del libro de datos | 360 registros sin limpiar |
| 3 | Matriz Integradora y BOA | Criterios de los tres cortes y evidencias obligatorias |
| 4 | Guía de la primera fase | Orientación para organizar el primer incremento |

**CASO 8**

# Detección de consumos anómalos y pérdidas de agua

*Empresa Municipal Aguas Claras | Agua potable*

|  |
| --- |
| **Documento que recibe el analista:** Expediente inicial de Fase 0. Contiene hechos, fuentes y datos de partida; no contiene problema formulado, objetivos, KPIs resueltos, técnica de minería seleccionada, marco de gobierno, mapa AS-IS/TO-BE, conclusiones ni recomendaciones. |

## 1. Identificación y asignación

| **Equipo / estudiante** | **Integrantes** | **Fecha de asignación** |
| --- | --- | --- |

| **Organización** | Empresa Municipal Aguas Claras |
| --- | --- |
| **Sector y ubicación** | Agua potable \| Cuatro municipios de Carazo |
| **Operación** | Producción, distribución, micromedición y facturación. |
| **Dimensión** | 28,600 conexiones; 9 sectores hidráulicos |
| **Periodo disponible** | enero 2024-junio 2026 |
| **Unidad de análisis** | conexión-mes |
| **Decisión institucional** | Priorizar inspecciones de fugas y revisión de medidores con base en riesgo operativo. |

## 2. Contexto entregado

Empresa Municipal Aguas Claras entrega al equipo un conjunto inicial compuesto por Lecturas, producción, presiones, órdenes de trabajo y catastro. La dirección solicita examinar los datos antes de formular el problema definitivo. El análisis debe distinguir hechos, supuestos y conclusiones, y conservar trazabilidad hacia cada fuente.

**Condición de trabajo.** *Los datos son sintéticos y fueron construidos para fines académicos, pero deben tratarse como si estuvieran sujetos a controles reales de acceso, seguridad, privacidad, calidad y ciclo de vida.*

## 3. Proceso operativo actual: hechos observados

| **Paso** | **Hecho operativo comunicado** | **Evidencia disponible** |
| --- | --- | --- |
| 1 | Lectores recorren rutas y sincronizan datos. | Comercial |
| 2 | Comercial estima consumos cuando no hay lectura. | Comercial |
| 3 | SCADA registra producción y presión por sector. | SCADA |
| 4 | Usuarios reportan fugas por teléfono. | Órdenes de trabajo |
| 5 | Mantenimiento cierra órdenes con códigos distintos. | Órdenes de trabajo |
| 6 | Se calcula balance hídrico mensualmente. | SCADA |

*La secuencia anterior es una descripción factual. Corresponde al equipo verificarla, delimitarla y convertirla en los modelos de proceso exigidos por el Integrador VIII.*

## 4. Actores que participan en el caso

| **Actor / área** | **Participación conocida al inicio** |
| --- | --- |
| Gerencia Operativa | Priorización |
| Comercial | Lecturas y facturación |
| Acueductos | Producción y presión |
| Mantenimiento | Inspecciones |
| Catastro/TI | Identidad de activos |

## 5. Inventario inicial de fuentes

| **Fuente** | **Responsable conocido** | **Formato** | **Actualización** | **Condición inicial** |
| --- | --- | --- | --- | --- |
| Comercial | Comercial | Base SQL / vista | Diaria | Acceso por rol; validación pendiente |
| SCADA | Acueductos | API / eventos | Casi en tiempo real | Acceso por rol; validación pendiente |
| Órdenes de trabajo | Mantenimiento | Archivo XLSX | Semanal | Acceso por rol; validación pendiente |
| Catastro GIS | Catastro/TI | CSV exportado | Mensual | Acceso por rol; validación pendiente |

## 6. Ficha técnica del dataset v0

| **Archivo de datos** | Datos_Iniciales_16_Casos_Integrador_VIII.xlsx |
| --- | --- |
| **Hoja asignada** | C08_Agua |
| **Cantidad de registros** | 360 registros sintéticos |
| **Cantidad de variables** | 15 variables |
| **Variable de resultado disponible** | fuga_confirmada: 1 = Inspección con fuga confirmada; 0 = caso contrario; vacío = no consolidado |
| **Copia de resguardo** | Conservar la hoja original como dataset v0; todas las transformaciones deben quedar en una versión derivada. |
| **Advertencia de calidad:** El dataset conserva de manera intencional valores faltantes, registros repetidos, etiquetas no normalizadas, cargas tardías y valores fuera de rango. No se indican sus cantidades ni ubicaciones: forman parte del diagnóstico que debe realizar el equipo. |  |

## 7. Diccionario preliminar de variables

| **Variable** | **Tipo** | **Descripción inicial** | **Uso conocido** |
| --- | --- | --- | --- |
| id_conexion_mes | Texto | Identificador seudonimizado del registro | Clave operativa |
| fecha_lectura | Fecha | Fecha del evento o corte | Tiempo |
| sector_hidraulico | Texto | Ubicación/unidad: Jinotepe Norte, Jinotepe Sur, Diriamba, San Marcos, Dolores | Segmentación |
| tipo_medidor | Texto | Canal/modalidad: Mecánico, Digital, Estimado, Sin medidor | Segmentación |
| tipo_usuario | Texto | Segmento: Residencial, Comercial, Institucional, Industrial | Segmentación |
| metodo_lectura | Texto | Categoría: Ruta móvil, Lectura manual, Telemetría, Estimación | Segmentación |
| consumo_m3 | Numérico | Medida operacional. Rango esperado 0-180 | Medición |
| antiguedad_medidor_meses | Numérico | Duración/antigüedad. Rango esperado 1-180 | Medición |
| presion_promedio_psi | Numérico | Indicador operacional 1. Rango esperado 12-72 | Medición |
| ordenes_trabajo_12m | Numérico | Indicador operacional 2. Rango esperado 0-8 | Medición |
| estado_cuenta | Texto | Variable auxiliar: Al día, 1 mes vencido, 2+ meses vencido, Convenio | Contexto |
| sistema_origen | Texto | Sistema de procedencia: Comercial, SCADA, Órdenes de trabajo, Catastro GIS | Linaje |
| fuga_confirmada | Binaria | 1 = Inspección con fuga confirmada; 0 = caso contrario; nulo = no consolidado | Resultado |
| uso_operativo_autorizado | Texto | Bandera de autorización o uso permitido según el caso | Gobierno |
| fecha_carga | Fecha | Fecha de incorporación al conjunto analítico | Oportunidad |

## 8. Informes operativos entregados

*Los siguientes cuadros son resúmenes neutrales del dataset v0. Las tasas, comparaciones, prioridades e interpretaciones deben ser calculadas y justificadas por el equipo.*

### Informe 1. Volumen mensual

| **Mes** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: consumo\_m3** |
| --- | --- | --- | --- | --- |
| 2025-01 | 24 | 23 | 9 | 2,340 |
| 2025-02 | 15 | 14 | 4 | 1,454 |
| 2025-03 | 18 | 18 | 4 | 1,847 |
| 2025-04 | 18 | 18 | 7 | 1,685 |
| 2025-05 | 14 | 14 | 4 | 1,468 |
| 2025-06 | 21 | 21 | 7 | 1,628 |
| 2025-07 | 17 | 17 | 8 | 1,538 |
| 2025-08 | 28 | 27 | 8 | 2,231 |
| 2025-09 | 19 | 19 | 5 | 1,763 |
| 2025-10 | 26 | 24 | 14 | 2,606 |
| 2025-11 | 18 | 18 | 6 | 1,840 |
| 2025-12 | 20 | 20 | 9 | 1,791 |
| 2026-01 | 26 | 26 | 10 | 2,363 |
| 2026-02 | 19 | 18 | 6 | 2,228 |
| 2026-03 | 22 | 22 | 6 | 1,786 |
| 2026-04 | 11 | 11 | 3 | 996 |
| 2026-05 | 22 | 22 | 8 | 1,764 |
| 2026-06 | 22 | 22 | 8 | 1,819 |

### Informe 2. Desglose por tipo_medidor

| **tipo\_medidor** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: consumo\_m3** |
| --- | --- | --- | --- | --- |
| (sin dato) | 9 | 8 | 3 | 905 |
| Digital | 85 | 82 | 22 | 7,330 |
| Estimado | 102 | 101 | 45 | 9,699 |
| Mecánico | 78 | 77 | 25 | 7,520 |
| Sin medidor | 86 | 86 | 31 | 7,693 |

### Informe 3. Desglose por metodo_lectura

| **metodo\_lectura** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: consumo\_m3** |
| --- | --- | --- | --- | --- |
| Estimación | 88 | 87 | 31 | 7,687 |
| ESTIMACIÓN | 1 | 1 | 0 | 54 |
| Lectura manual | 94 | 93 | 33 | 8,948 |
| LECTURA MANUAL | 3 | 2 | 1 | 354 |
| Ruta móvil | 73 | 73 | 33 | 6,339 |
| Telemetría | 101 | 98 | 28 | 9,765 |

### Informe 4. Desglose por sector_hidraulico

| **sector\_hidraulico** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: consumo\_m3** |
| --- | --- | --- | --- | --- |
| Diriamba | 83 | 81 | 23 | 7,568 |
| Dolores | 71 | 70 | 33 | 6,717 |
| Jinotepe Norte | 60 | 58 | 18 | 5,261 |
| Jinotepe Sur | 79 | 79 | 30 | 6,999 |
| San Marcos | 67 | 66 | 22 | 6,602 |

## 9. Referencias operativas y restricciones

|  |  |
| --- | --- |
| **Referencia comparativa** | Agua no contabilizada referencial: 28%; lecturas válidas esperadas: 96%; órdenes críticas atendidas en 48 horas. |
| **Privacidad y ética** | No publicar direcciones exactas ni hábitos de consumo de usuarios; compartir agregados por sector. |
| **Acceso inicial** | Lectura sobre dataset v0; cualquier dato derivado debe documentar origen, transformación y responsable. |
| **Uso permitido** | Exclusivamente académico dentro del Integrador VIII; no reutilizar nombres ficticios como si fueran organizaciones reales. |

## 10. Paquete recibido por el analista

| **N.º** | **Elemento** | **Contenido inicial** |
| --- | --- | --- |
| 1 | Este expediente de Fase 0 | Contexto, actores, proceso factual, fuentes, diccionario y reportes |
| 2 | Hoja C08_Agua del libro de datos | 360 registros sin limpiar |
| 3 | Matriz Integradora y BOA | Criterios de los tres cortes y evidencias obligatorias |
| 4 | Guía de la primera fase | Orientación para organizar el primer incremento |

**CASO 9**

# Devoluciones y experiencia de compra en comercio electrónico

*NicaCompra Digital | Comercio electrónico*

|  |
| --- |
| **Documento que recibe el analista:** Expediente inicial de Fase 0. Contiene hechos, fuentes y datos de partida; no contiene problema formulado, objetivos, KPIs resueltos, técnica de minería seleccionada, marco de gobierno, mapa AS-IS/TO-BE, conclusiones ni recomendaciones. |

## 1. Identificación y asignación

| **Equipo / estudiante** | **Integrantes** | **Fecha de asignación** |
| --- | --- | --- |

| **Organización** | NicaCompra Digital |
| --- | --- |
| **Sector y ubicación** | Comercio electrónico \| Cobertura nacional |
| **Operación** | Marketplace de tecnología, hogar y cuidado personal. |
| **Dimensión** | 96,000 pedidos anuales; 420 vendedores |
| **Periodo disponible** | enero 2024-junio 2026 |
| **Unidad de análisis** | línea de pedido |
| **Decisión institucional** | Priorizar mejoras en catálogo, despacho y políticas de vendedores. |

## 2. Contexto entregado

NicaCompra Digital entrega al equipo un conjunto inicial compuesto por Pedidos, catálogo, pagos, logística, reseñas y devoluciones. La dirección solicita examinar los datos antes de formular el problema definitivo. El análisis debe distinguir hechos, supuestos y conclusiones, y conservar trazabilidad hacia cada fuente.

**Condición de trabajo.** *Los datos son sintéticos y fueron construidos para fines académicos, pero deben tratarse como si estuvieran sujetos a controles reales de acceso, seguridad, privacidad, calidad y ciclo de vida.*

## 3. Proceso operativo actual: hechos observados

| **Paso** | **Hecho operativo comunicado** | **Evidencia disponible** |
| --- | --- | --- |
| 1 | El cliente crea un pedido. | OMS |
| 2 | La pasarela confirma el pago. | Pasarela |
| 3 | El vendedor prepara y entrega al operador logístico. | Logística |
| 4 | El cliente puede solicitar devolución. | OMS |
| 5 | Atención clasifica motivos en texto y códigos. | OMS |
| 6 | Marketplace evalúa vendedores mensualmente. | OMS |

*La secuencia anterior es una descripción factual. Corresponde al equipo verificarla, delimitarla y convertirla en los modelos de proceso exigidos por el Integrador VIII.*

## 4. Actores que participan en el caso

| **Actor / área** | **Participación conocida al inicio** |
| --- | --- |
| Marketplace | Patrocinio |
| Catálogo | Atributos |
| Logística | Entrega |
| Atención | Devoluciones |
| Riesgo/TI | Pagos y accesos |

## 5. Inventario inicial de fuentes

| **Fuente** | **Responsable conocido** | **Formato** | **Actualización** | **Condición inicial** |
| --- | --- | --- | --- | --- |
| OMS | Marketplace | Base SQL / vista | Diaria | Acceso por rol; validación pendiente |
| Catálogo | Catálogo | API / eventos | Casi en tiempo real | Acceso por rol; validación pendiente |
| Pasarela | Finanzas | Archivo XLSX | Semanal | Acceso por rol; validación pendiente |
| Logística | Logística | CSV exportado | Mensual | Acceso por rol; validación pendiente |

## 6. Ficha técnica del dataset v0

| **Archivo de datos** | Datos_Iniciales_16_Casos_Integrador_VIII.xlsx |
| --- | --- |
| **Hoja asignada** | C09_Ecommerce |
| **Cantidad de registros** | 360 registros sintéticos |
| **Cantidad de variables** | 15 variables |
| **Variable de resultado disponible** | producto_devuelto: 1 = Línea de pedido devuelta; 0 = caso contrario; vacío = no consolidado |
| **Copia de resguardo** | Conservar la hoja original como dataset v0; todas las transformaciones deben quedar en una versión derivada. |
| **Advertencia de calidad:** El dataset conserva de manera intencional valores faltantes, registros repetidos, etiquetas no normalizadas, cargas tardías y valores fuera de rango. No se indican sus cantidades ni ubicaciones: forman parte del diagnóstico que debe realizar el equipo. |  |

## 7. Diccionario preliminar de variables

| **Variable** | **Tipo** | **Descripción inicial** | **Uso conocido** |
| --- | --- | --- | --- |
| id_linea_pedido | Texto | Identificador seudonimizado del registro | Clave operativa |
| fecha_pedido | Fecha | Fecha del evento o corte | Tiempo |
| departamento_destino | Texto | Ubicación/unidad: Managua, Carazo, Masaya, Granada, León | Segmentación |
| dispositivo | Texto | Canal/modalidad: Android, iOS, Web móvil, Desktop | Segmentación |
| categoria_producto | Texto | Segmento: Tecnología, Hogar, Moda, Belleza, Repuestos | Segmentación |
| tipo_vendedor | Texto | Categoría: Tienda oficial, Vendedor verificado, Vendedor nuevo, Importador | Segmentación |
| precio_usd | Numérico | Medida operacional. Rango esperado 4-850 | Medición |
| dias_entrega | Numérico | Duración/antigüedad. Rango esperado 0-18 | Medición |
| calificacion_vendedor | Numérico | Indicador operacional 1. Rango esperado 1-5 | Medición |
| devoluciones_previas_cliente | Numérico | Indicador operacional 2. Rango esperado 0-7 | Medición |
| medio_pago | Texto | Variable auxiliar: Tarjeta, Transferencia, Contra entrega, Billetera | Contexto |
| sistema_origen | Texto | Sistema de procedencia: OMS, Catálogo, Pasarela, Logística | Linaje |
| producto_devuelto | Binaria | 1 = Línea de pedido devuelta; 0 = caso contrario; nulo = no consolidado | Resultado |
| uso_analitico_autorizado | Texto | Bandera de autorización o uso permitido según el caso | Gobierno |
| fecha_carga | Fecha | Fecha de incorporación al conjunto analítico | Oportunidad |

## 8. Informes operativos entregados

*Los siguientes cuadros son resúmenes neutrales del dataset v0. Las tasas, comparaciones, prioridades e interpretaciones deben ser calculadas y justificadas por el equipo.*

### Informe 1. Volumen mensual

| **Mes** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: precio\_usd** |
| --- | --- | --- | --- | --- |
| 2025-01 | 30 | 29 | 12 | 12,542 |
| 2025-02 | 19 | 19 | 6 | 8,453 |
| 2025-03 | 19 | 18 | 6 | 8,016 |
| 2025-04 | 18 | 18 | 6 | 8,889 |
| 2025-05 | 24 | 23 | 11 | 8,646 |
| 2025-06 | 20 | 19 | 4 | 8,245 |
| 2025-07 | 22 | 22 | 11 | 8,017 |
| 2025-08 | 22 | 22 | 9 | 10,244 |
| 2025-09 | 16 | 14 | 6 | 7,404 |
| 2025-10 | 20 | 20 | 7 | 8,483 |
| 2025-11 | 27 | 27 | 12 | 10,895 |
| 2025-12 | 15 | 15 | 6 | 7,174 |
| 2026-01 | 17 | 17 | 6 | 7,743 |
| 2026-02 | 16 | 16 | 3 | 6,656 |
| 2026-03 | 19 | 19 | 10 | 8,182 |
| 2026-04 | 23 | 23 | 5 | 9,032 |
| 2026-05 | 22 | 22 | 8 | 7,386 |
| 2026-06 | 11 | 11 | 4 | 5,612 |

### Informe 2. Desglose por dispositivo

| **dispositivo** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: precio\_usd** |
| --- | --- | --- | --- | --- |
| (sin dato) | 9 | 8 | 3 | 3,872 |
| Android | 81 | 79 | 29 | 36,427 |
| Desktop | 88 | 86 | 36 | 36,081 |
| iOS | 93 | 92 | 29 | 41,065 |
| Web móvil | 89 | 89 | 35 | 34,174 |

### Informe 3. Desglose por tipo_vendedor

| **tipo\_vendedor** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: precio\_usd** |
| --- | --- | --- | --- | --- |
| Importador | 84 | 83 | 40 | 36,868 |
| IMPORTADOR | 1 | 0 | 0 | 285 |
| Tienda oficial | 82 | 82 | 20 | 33,688 |
| Vendedor nuevo | 101 | 99 | 35 | 41,471 |
| VENDEDOR NUEVO | 2 | 2 | 0 | 1,171 |
| Vendedor verificado | 89 | 87 | 37 | 37,885 |
| VENDEDOR VERIFICADO | 1 | 1 | 0 | 251 |

### Informe 4. Desglose por departamento_destino

| **departamento\_destino** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: precio\_usd** |
| --- | --- | --- | --- | --- |
| Carazo | 74 | 74 | 19 | 32,542 |
| Granada | 67 | 65 | 26 | 27,206 |
| León | 67 | 66 | 30 | 30,180 |
| Managua | 63 | 62 | 27 | 23,002 |
| Masaya | 89 | 87 | 30 | 38,689 |

## 9. Referencias operativas y restricciones

|  |  |
| --- | --- |
| **Referencia comparativa** | Devolución referencial: 8%; despacho dentro del SLA: 93%; atributos críticos de catálogo completos: 98%. |
| **Privacidad y ética** | No exponer datos de pago, direcciones completas ni perfiles individuales; controlar acceso por vendedor. |
| **Acceso inicial** | Lectura sobre dataset v0; cualquier dato derivado debe documentar origen, transformación y responsable. |
| **Uso permitido** | Exclusivamente académico dentro del Integrador VIII; no reutilizar nombres ficticios como si fueran organizaciones reales. |

## 10. Paquete recibido por el analista

| **N.º** | **Elemento** | **Contenido inicial** |
| --- | --- | --- |
| 1 | Este expediente de Fase 0 | Contexto, actores, proceso factual, fuentes, diccionario y reportes |
| 2 | Hoja C09_Ecommerce del libro de datos | 360 registros sin limpiar |
| 3 | Matriz Integradora y BOA | Criterios de los tres cortes y evidencias obligatorias |
| 4 | Guía de la primera fase | Orientación para organizar el primer incremento |

**CASO 10**

# Cumplimiento de entregas de última milla

*RápidoPacífico Logística | Logística y paquetería*

|  |
| --- |
| **Documento que recibe el analista:** Expediente inicial de Fase 0. Contiene hechos, fuentes y datos de partida; no contiene problema formulado, objetivos, KPIs resueltos, técnica de minería seleccionada, marco de gobierno, mapa AS-IS/TO-BE, conclusiones ni recomendaciones. |

## 1. Identificación y asignación

| **Equipo / estudiante** | **Integrantes** | **Fecha de asignación** |
| --- | --- | --- |

| **Organización** | RápidoPacífico Logística |
| --- | --- |
| **Sector y ubicación** | Logística y paquetería \| Pacífico de Nicaragua |
| **Operación** | Recolección, clasificación y entrega a domicilio. |
| **Dimensión** | 210,000 guías anuales; 95 rutas |
| **Periodo disponible** | enero 2024-junio 2026 |
| **Unidad de análisis** | guía de envío |
| **Decisión institucional** | Ajustar planificación de rutas, capacidad y comunicación con destinatarios. |

## 2. Contexto entregado

RápidoPacífico Logística entrega al equipo un conjunto inicial compuesto por Guías, escaneos, GPS, rutas, clima y reclamos. La dirección solicita examinar los datos antes de formular el problema definitivo. El análisis debe distinguir hechos, supuestos y conclusiones, y conservar trazabilidad hacia cada fuente.

**Condición de trabajo.** *Los datos son sintéticos y fueron construidos para fines académicos, pero deben tratarse como si estuvieran sujetos a controles reales de acceso, seguridad, privacidad, calidad y ciclo de vida.*

## 3. Proceso operativo actual: hechos observados

| **Paso** | **Hecho operativo comunicado** | **Evidencia disponible** |
| --- | --- | --- |
| 1 | Se genera la guía y promesa de entrega. | TMS |
| 2 | La pieza recibe escaneos en cada centro. | TMS |
| 3 | TMS asigna ruta y repartidor. | TMS |
| 4 | La aplicación registra intentos y evidencia. | App repartidor |
| 5 | Atención recibe novedades del destinatario. | Atención |
| 6 | Operaciones consolida SLA semanalmente. | TMS |

*La secuencia anterior es una descripción factual. Corresponde al equipo verificarla, delimitarla y convertirla en los modelos de proceso exigidos por el Integrador VIII.*

## 4. Actores que participan en el caso

| **Actor / área** | **Participación conocida al inicio** |
| --- | --- |
| Operaciones | Patrocinio |
| Planificación | Rutas |
| Centros de clasificación | Escaneos |
| Repartidores | Eventos |
| TI/Seguridad | Trazabilidad |

## 5. Inventario inicial de fuentes

| **Fuente** | **Responsable conocido** | **Formato** | **Actualización** | **Condición inicial** |
| --- | --- | --- | --- | --- |
| TMS | Planificación | Base SQL / vista | Diaria | Acceso por rol; validación pendiente |
| App repartidor | Operaciones | API / eventos | Casi en tiempo real | Acceso por rol; validación pendiente |
| GPS | TI/Seguridad | Archivo XLSX | Semanal | Acceso por rol; validación pendiente |
| Atención | Atención al cliente | CSV exportado | Mensual | Acceso por rol; validación pendiente |

## 6. Ficha técnica del dataset v0

| **Archivo de datos** | Datos_Iniciales_16_Casos_Integrador_VIII.xlsx |
| --- | --- |
| **Hoja asignada** | C10_Logistica |
| **Cantidad de registros** | 360 registros sintéticos |
| **Cantidad de variables** | 15 variables |
| **Variable de resultado disponible** | entrega_fuera_sla: 1 = Entrega fuera del plazo comprometido; 0 = caso contrario; vacío = no consolidado |
| **Copia de resguardo** | Conservar la hoja original como dataset v0; todas las transformaciones deben quedar en una versión derivada. |
| **Advertencia de calidad:** El dataset conserva de manera intencional valores faltantes, registros repetidos, etiquetas no normalizadas, cargas tardías y valores fuera de rango. No se indican sus cantidades ni ubicaciones: forman parte del diagnóstico que debe realizar el equipo. |  |

## 7. Diccionario preliminar de variables

| **Variable** | **Tipo** | **Descripción inicial** | **Uso conocido** |
| --- | --- | --- | --- |
| id_guia | Texto | Identificador seudonimizado del registro | Clave operativa |
| fecha_recoleccion | Fecha | Fecha del evento o corte | Tiempo |
| zona_destino | Texto | Ubicación/unidad: Managua, Carazo, Masaya, Granada, Rivas | Segmentación |
| tipo_servicio | Texto | Canal/modalidad: Mismo día, 24 horas, 48 horas, Económico | Segmentación |
| tipo_cliente | Texto | Segmento: E-commerce, Pyme, Corporativo, Persona | Segmentación |
| franja_entrega | Texto | Categoría: AM, PM, Nocturna, Sin franja | Segmentación |
| peso_kg | Numérico | Medida operacional. Rango esperado 0.1-45 | Medición |
| distancia_km | Numérico | Duración/antigüedad. Rango esperado 1-160 | Medición |
| intentos_entrega | Numérico | Indicador operacional 1. Rango esperado 1-4 | Medición |
| paradas_ruta | Numérico | Indicador operacional 2. Rango esperado 12-90 | Medición |
| condicion_clima | Texto | Variable auxiliar: Despejado, Lluvia, Alerta vial, Normal | Contexto |
| sistema_origen | Texto | Sistema de procedencia: TMS, App repartidor, GPS, Atención | Linaje |
| entrega_fuera_sla | Binaria | 1 = Entrega fuera del plazo comprometido; 0 = caso contrario; nulo = no consolidado | Resultado |
| geolocalizacion_autorizada | Texto | Bandera de autorización o uso permitido según el caso | Gobierno |
| fecha_carga | Fecha | Fecha de incorporación al conjunto analítico | Oportunidad |

## 8. Informes operativos entregados

*Los siguientes cuadros son resúmenes neutrales del dataset v0. Las tasas, comparaciones, prioridades e interpretaciones deben ser calculadas y justificadas por el equipo.*

### Informe 1. Volumen mensual

| **Mes** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: peso\_kg** |
| --- | --- | --- | --- | --- |
| 2025-01 | 26 | 26 | 10 | 626.4 |
| 2025-02 | 13 | 13 | 8 | 237.7 |
| 2025-03 | 22 | 22 | 8 | 535 |
| 2025-04 | 22 | 22 | 8 | 521.7 |
| 2025-05 | 19 | 19 | 9 | 566.8 |
| 2025-06 | 20 | 20 | 8 | 531.1 |
| 2025-07 | 20 | 19 | 9 | 368.9 |
| 2025-08 | 19 | 19 | 13 | 487.2 |
| 2025-09 | 19 | 18 | 7 | 379.5 |
| 2025-10 | 24 | 23 | 7 | 444 |
| 2025-11 | 19 | 19 | 8 | 472.8 |
| 2025-12 | 17 | 17 | 6 | 371.8 |
| 2026-01 | 15 | 14 | 4 | 346.4 |
| 2026-02 | 14 | 14 | 7 | 335.3 |
| 2026-03 | 19 | 18 | 7 | 420.2 |
| 2026-04 | 25 | 24 | 11 | 523.8 |
| 2026-05 | 22 | 22 | 8 | 496.8 |
| 2026-06 | 25 | 25 | 13 | 580.8 |

### Informe 2. Desglose por tipo_servicio

| **tipo\_servicio** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: peso\_kg** |
| --- | --- | --- | --- | --- |
| (sin dato) | 9 | 8 | 5 | 150.8 |
| 24 horas | 93 | 92 | 31 | 2,081.3 |
| 48 horas | 92 | 92 | 35 | 1,926.3 |
| Económico | 82 | 80 | 39 | 1,825.5 |
| Mismo día | 84 | 82 | 41 | 2,262.3 |

### Informe 3. Desglose por franja_entrega

| **franja\_entrega** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: peso\_kg** |
| --- | --- | --- | --- | --- |
| AM | 97 | 96 | 45 | 2,435.2 |
| Nocturna | 99 | 99 | 43 | 2,317 |
| NOCTURNA | 2 | 2 | 0 | 74.7 |
| PM | 93 | 89 | 36 | 1,821.8 |
| Sin franja | 69 | 68 | 27 | 1,597.5 |

### Informe 4. Desglose por zona_destino

| **zona\_destino** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: peso\_kg** |
| --- | --- | --- | --- | --- |
| Carazo | 67 | 65 | 39 | 1,580.7 |
| Granada | 63 | 62 | 22 | 1,334 |
| Managua | 76 | 75 | 27 | 1,775.6 |
| Masaya | 73 | 72 | 28 | 1,622.5 |
| Rivas | 81 | 80 | 35 | 1,933.4 |

## 9. Referencias operativas y restricciones

|  |  |
| --- | --- |
| **Referencia comparativa** | Entregas dentro del SLA: 94%; primer intento exitoso: 88%; eventos de trazabilidad completos: 99%. |
| **Privacidad y ética** | Direcciones y geolocalización son datos restringidos; las vistas analíticas deben minimizar detalle personal. |
| **Acceso inicial** | Lectura sobre dataset v0; cualquier dato derivado debe documentar origen, transformación y responsable. |
| **Uso permitido** | Exclusivamente académico dentro del Integrador VIII; no reutilizar nombres ficticios como si fueran organizaciones reales. |

## 10. Paquete recibido por el analista

| **N.º** | **Elemento** | **Contenido inicial** |
| --- | --- | --- |
| 1 | Este expediente de Fase 0 | Contexto, actores, proceso factual, fuentes, diccionario y reportes |
| 2 | Hoja C10_Logistica del libro de datos | 360 registros sin limpiar |
| 3 | Matriz Integradora y BOA | Criterios de los tres cortes y evidencias obligatorias |
| 4 | Guía de la primera fase | Orientación para organizar el primer incremento |

**CASO 11**

# Cancelaciones y ocupación en servicios hoteleros

*Hoteles Costa y Volcán | Turismo y hospitalidad*

|  |
| --- |
| **Documento que recibe el analista:** Expediente inicial de Fase 0. Contiene hechos, fuentes y datos de partida; no contiene problema formulado, objetivos, KPIs resueltos, técnica de minería seleccionada, marco de gobierno, mapa AS-IS/TO-BE, conclusiones ni recomendaciones. |

## 1. Identificación y asignación

| **Equipo / estudiante** | **Integrantes** | **Fecha de asignación** |
| --- | --- | --- |

| **Organización** | Hoteles Costa y Volcán |
| --- | --- |
| **Sector y ubicación** | Turismo y hospitalidad \| Granada, San Juan del Sur y Carazo |
| **Operación** | Tres hoteles, reservas directas y agencias en línea. |
| **Dimensión** | 210 habitaciones; 28,000 reservas anuales |
| **Periodo disponible** | enero 2023-junio 2026 |
| **Unidad de análisis** | reserva hotelera |
| **Decisión institucional** | Ajustar disponibilidad, condiciones de tarifa y comunicación previa a la llegada. |

## 2. Contexto entregado

Hoteles Costa y Volcán entrega al equipo un conjunto inicial compuesto por PMS, motor de reservas, OTA, pagos y reputación. La dirección solicita examinar los datos antes de formular el problema definitivo. El análisis debe distinguir hechos, supuestos y conclusiones, y conservar trazabilidad hacia cada fuente.

**Condición de trabajo.** *Los datos son sintéticos y fueron construidos para fines académicos, pero deben tratarse como si estuvieran sujetos a controles reales de acceso, seguridad, privacidad, calidad y ciclo de vida.*

## 3. Proceso operativo actual: hechos observados

| **Paso** | **Hecho operativo comunicado** | **Evidencia disponible** |
| --- | --- | --- |
| 1 | La reserva ingresa por uno de cuatro canales. | PMS |
| 2 | PMS bloquea disponibilidad. | PMS |
| 3 | Pagos se confirman por pasarela o recepción. | Pasarela |
| 4 | Se envían comunicaciones previas. | Motor web |
| 5 | Recepción marca llegada, cancelación o no-show. | PMS |
| 6 | Comercial compara ocupación y tarifa cada semana. | PMS |

*La secuencia anterior es una descripción factual. Corresponde al equipo verificarla, delimitarla y convertirla en los modelos de proceso exigidos por el Integrador VIII.*

## 4. Actores que participan en el caso

| **Actor / área** | **Participación conocida al inicio** |
| --- | --- |
| Dirección Comercial | Patrocinio |
| Reservas | Canales |
| Recepción | Llegadas |
| Finanzas | Pagos |
| TI | Integraciones OTA |

## 5. Inventario inicial de fuentes

| **Fuente** | **Responsable conocido** | **Formato** | **Actualización** | **Condición inicial** |
| --- | --- | --- | --- | --- |
| PMS | Reservas | Base SQL / vista | Diaria | Acceso por rol; validación pendiente |
| Motor web | Dirección Comercial | API / eventos | Casi en tiempo real | Acceso por rol; validación pendiente |
| OTA | Reservas | Archivo XLSX | Semanal | Acceso por rol; validación pendiente |
| Pasarela | Finanzas | CSV exportado | Mensual | Acceso por rol; validación pendiente |

## 6. Ficha técnica del dataset v0

| **Archivo de datos** | Datos_Iniciales_16_Casos_Integrador_VIII.xlsx |
| --- | --- |
| **Hoja asignada** | C11_Hotel |
| **Cantidad de registros** | 360 registros sintéticos |
| **Cantidad de variables** | 15 variables |
| **Variable de resultado disponible** | cancelada_o_no_show: 1 = Reserva cancelada o no presentada; 0 = caso contrario; vacío = no consolidado |
| **Copia de resguardo** | Conservar la hoja original como dataset v0; todas las transformaciones deben quedar en una versión derivada. |
| **Advertencia de calidad:** El dataset conserva de manera intencional valores faltantes, registros repetidos, etiquetas no normalizadas, cargas tardías y valores fuera de rango. No se indican sus cantidades ni ubicaciones: forman parte del diagnóstico que debe realizar el equipo. |  |

## 7. Diccionario preliminar de variables

| **Variable** | **Tipo** | **Descripción inicial** | **Uso conocido** |
| --- | --- | --- | --- |
| id_reserva | Texto | Identificador seudonimizado del registro | Clave operativa |
| fecha_reserva | Fecha | Fecha del evento o corte | Tiempo |
| hotel | Texto | Ubicación/unidad: Granada Centro, Laguna, San Juan del Sur | Segmentación |
| canal_reserva | Texto | Canal/modalidad: Sitio web, Teléfono, OTA, Corporativo | Segmentación |
| tipo_huesped | Texto | Segmento: Ocio, Negocios, Familia, Grupo | Segmentación |
| tarifa | Texto | Categoría: Flexible, No reembolsable, Promoción, Corporativa | Segmentación |
| monto_usd | Numérico | Medida operacional. Rango esperado 45-1200 | Medición |
| anticipacion_dias | Numérico | Duración/antigüedad. Rango esperado 0-180 | Medición |
| noches | Numérico | Indicador operacional 1. Rango esperado 1-12 | Medición |
| estancias_previas | Numérico | Indicador operacional 2. Rango esperado 0-8 | Medición |
| temporada | Texto | Variable auxiliar: Alta, Media, Baja, Feriado | Contexto |
| sistema_origen | Texto | Sistema de procedencia: PMS, Motor web, OTA, Pasarela | Linaje |
| cancelada_o_no_show | Binaria | 1 = Reserva cancelada o no presentada; 0 = caso contrario; nulo = no consolidado | Resultado |
| contacto_autorizado | Texto | Bandera de autorización o uso permitido según el caso | Gobierno |
| fecha_carga | Fecha | Fecha de incorporación al conjunto analítico | Oportunidad |

## 8. Informes operativos entregados

*Los siguientes cuadros son resúmenes neutrales del dataset v0. Las tasas, comparaciones, prioridades e interpretaciones deben ser calculadas y justificadas por el equipo.*

### Informe 1. Volumen mensual

| **Mes** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: monto\_usd** |
| --- | --- | --- | --- | --- |
| 2025-01 | 21 | 20 | 7 | 13,487 |
| 2025-02 | 23 | 23 | 6 | 16,316 |
| 2025-03 | 20 | 20 | 5 | 10,954 |
| 2025-04 | 19 | 19 | 3 | 10,440 |
| 2025-05 | 16 | 16 | 3 | 10,242 |
| 2025-06 | 21 | 21 | 4 | 11,117 |
| 2025-07 | 20 | 20 | 4 | 10,528 |
| 2025-08 | 23 | 23 | 5 | 16,411 |
| 2025-09 | 19 | 18 | 4 | 14,481 |
| 2025-10 | 19 | 17 | 7 | 10,355 |
| 2025-11 | 22 | 22 | 4 | 15,321 |
| 2025-12 | 16 | 16 | 5 | 10,729 |
| 2026-01 | 25 | 25 | 6 | 12,507 |
| 2026-02 | 18 | 18 | 4 | 9,574 |
| 2026-03 | 17 | 16 | 4 | 9,853 |
| 2026-04 | 20 | 20 | 7 | 10,605 |
| 2026-05 | 22 | 22 | 7 | 11,831 |
| 2026-06 | 19 | 18 | 4 | 14,072 |

### Informe 2. Desglose por canal_reserva

| **canal\_reserva** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: monto\_usd** |
| --- | --- | --- | --- | --- |
| (sin dato) | 9 | 8 | 1 | 3,338 |
| Corporativo | 62 | 62 | 12 | 41,078 |
| OTA | 102 | 100 | 30 | 59,289 |
| Sitio web | 92 | 91 | 30 | 54,045 |
| Teléfono | 95 | 93 | 16 | 61,073 |

### Informe 3. Desglose por tarifa

| **tarifa** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: monto\_usd** |
| --- | --- | --- | --- | --- |
| Corporativa | 85 | 83 | 17 | 49,919 |
| CORPORATIVA | 2 | 1 | 0 | 1,109 |
| Flexible | 74 | 73 | 27 | 46,029 |
| No reembolsable | 80 | 80 | 9 | 51,302 |
| Promoción | 117 | 115 | 36 | 69,270 |
| PROMOCIÓN | 2 | 2 | 0 | 1,194 |

### Informe 4. Desglose por hotel

| **hotel** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: monto\_usd** |
| --- | --- | --- | --- | --- |
| Granada Centro | 99 | 98 | 29 | 57,700 |
| Laguna | 124 | 121 | 29 | 79,548 |
| San Juan del Sur | 137 | 135 | 31 | 81,575 |

## 9. Referencias operativas y restricciones

|  |  |
| --- | --- |
| **Referencia comparativa** | Cancelación/no-show referencial: 18%; paridad de inventario esperada: 99%; confirmación de pago en menos de 15 minutos. |
| **Privacidad y ética** | No compartir documentos de identidad ni preferencias personales; limitar el acceso a historial individual. |
| **Acceso inicial** | Lectura sobre dataset v0; cualquier dato derivado debe documentar origen, transformación y responsable. |
| **Uso permitido** | Exclusivamente académico dentro del Integrador VIII; no reutilizar nombres ficticios como si fueran organizaciones reales. |

## 10. Paquete recibido por el analista

| **N.º** | **Elemento** | **Contenido inicial** |
| --- | --- | --- |
| 1 | Este expediente de Fase 0 | Contexto, actores, proceso factual, fuentes, diccionario y reportes |
| 2 | Hoja C11_Hotel del libro de datos | 360 registros sin limpiar |
| 3 | Matriz Integradora y BOA | Criterios de los tres cortes y evidencias obligatorias |
| 4 | Guía de la primera fase | Orientación para organizar el primer incremento |

**CASO 12**

# Continuidad del servicio de distribución eléctrica

*Distribuidora Energía CentroSur | Energía eléctrica*

|  |
| --- |
| **Documento que recibe el analista:** Expediente inicial de Fase 0. Contiene hechos, fuentes y datos de partida; no contiene problema formulado, objetivos, KPIs resueltos, técnica de minería seleccionada, marco de gobierno, mapa AS-IS/TO-BE, conclusiones ni recomendaciones. |

## 1. Identificación y asignación

| **Equipo / estudiante** | **Integrantes** | **Fecha de asignación** |
| --- | --- | --- |

| **Organización** | Distribuidora Energía CentroSur |
| --- | --- |
| **Sector y ubicación** | Energía eléctrica \| Departamentos del centro-sur |
| **Operación** | Distribución, mantenimiento y atención de incidencias. |
| **Dimensión** | 186,000 suministros; 48 circuitos |
| **Periodo disponible** | enero 2024-junio 2026 |
| **Unidad de análisis** | circuito-semana |
| **Decisión institucional** | Priorizar mantenimiento y cuadrillas según recurrencia e impacto de interrupciones. |

## 2. Contexto entregado

Distribuidora Energía CentroSur entrega al equipo un conjunto inicial compuesto por SCADA, OMS, mantenimiento, clima y llamadas. La dirección solicita examinar los datos antes de formular el problema definitivo. El análisis debe distinguir hechos, supuestos y conclusiones, y conservar trazabilidad hacia cada fuente.

**Condición de trabajo.** *Los datos son sintéticos y fueron construidos para fines académicos, pero deben tratarse como si estuvieran sujetos a controles reales de acceso, seguridad, privacidad, calidad y ciclo de vida.*

## 3. Proceso operativo actual: hechos observados

| **Paso** | **Hecho operativo comunicado** | **Evidencia disponible** |
| --- | --- | --- |
| 1 | SCADA detecta eventos eléctricos. | SCADA |
| 2 | OMS agrupa llamadas e identifica áreas. | OMS |
| 3 | Centro de Control despacha cuadrillas. | OMS |
| 4 | Mantenimiento registra causa y reparación. | Mantenimiento |
| 5 | Planeamiento actualiza programas preventivos. | Mantenimiento |
| 6 | Regulación recibe indicadores consolidados. | OMS |

*La secuencia anterior es una descripción factual. Corresponde al equipo verificarla, delimitarla y convertirla en los modelos de proceso exigidos por el Integrador VIII.*

## 4. Actores que participan en el caso

| **Actor / área** | **Participación conocida al inicio** |
| --- | --- |
| Operaciones | Patrocinio |
| Centro de Control | Eventos SCADA |
| Mantenimiento | Órdenes |
| Atención | Reportes |
| Seguridad/TI | Infraestructura crítica |

## 5. Inventario inicial de fuentes

| **Fuente** | **Responsable conocido** | **Formato** | **Actualización** | **Condición inicial** |
| --- | --- | --- | --- | --- |
| SCADA | Centro de Control | Base SQL / vista | Diaria | Acceso por rol; validación pendiente |
| OMS | Centro de Control | API / eventos | Casi en tiempo real | Acceso por rol; validación pendiente |
| Mantenimiento | Mantenimiento | Archivo XLSX | Semanal | Acceso por rol; validación pendiente |
| Call center | Atención | CSV exportado | Mensual | Acceso por rol; validación pendiente |

## 6. Ficha técnica del dataset v0

| **Archivo de datos** | Datos_Iniciales_16_Casos_Integrador_VIII.xlsx |
| --- | --- |
| **Hoja asignada** | C12_Energia |
| **Cantidad de registros** | 360 registros sintéticos |
| **Cantidad de variables** | 15 variables |
| **Variable de resultado disponible** | interrupcion_recurrente: 1 = Semana con interrupción recurrente; 0 = caso contrario; vacío = no consolidado |
| **Copia de resguardo** | Conservar la hoja original como dataset v0; todas las transformaciones deben quedar en una versión derivada. |
| **Advertencia de calidad:** El dataset conserva de manera intencional valores faltantes, registros repetidos, etiquetas no normalizadas, cargas tardías y valores fuera de rango. No se indican sus cantidades ni ubicaciones: forman parte del diagnóstico que debe realizar el equipo. |  |

## 7. Diccionario preliminar de variables

| **Variable** | **Tipo** | **Descripción inicial** | **Uso conocido** |
| --- | --- | --- | --- |
| id_circuito_semana | Texto | Identificador seudonimizado del registro | Clave operativa |
| inicio_semana | Fecha | Fecha del evento o corte | Tiempo |
| circuito | Texto | Ubicación/unidad: CRZ-01, CRZ-04, MSY-02, GRD-03, RVS-05 | Segmentación |
| tipo_red | Texto | Canal/modalidad: Aérea, Subterránea, Mixta | Segmentación |
| zona | Texto | Segmento: Urbana, Rural, Industrial, Turística | Segmentación |
| causa_reportada | Texto | Categoría: Vegetación, Equipo, Clima, Terceros, No determinada | Segmentación |
| clientes_afectados | Numérico | Medida operacional. Rango esperado 30-6800 | Medición |
| minutos_interrupcion | Numérico | Duración/antigüedad. Rango esperado 0-420 | Medición |
| eventos_30d | Numérico | Indicador operacional 1. Rango esperado 0-12 | Medición |
| dias_desde_poda | Numérico | Indicador operacional 2. Rango esperado 0-240 | Medición |
| condicion_clima | Texto | Variable auxiliar: Normal, Lluvia, Viento fuerte, Tormenta | Contexto |
| sistema_origen | Texto | Sistema de procedencia: SCADA, OMS, Mantenimiento, Call center | Linaje |
| interrupcion_recurrente | Binaria | 1 = Semana con interrupción recurrente; 0 = caso contrario; nulo = no consolidado | Resultado |
| uso_operativo_autorizado | Texto | Bandera de autorización o uso permitido según el caso | Gobierno |
| fecha_carga | Fecha | Fecha de incorporación al conjunto analítico | Oportunidad |

## 8. Informes operativos entregados

*Los siguientes cuadros son resúmenes neutrales del dataset v0. Las tasas, comparaciones, prioridades e interpretaciones deben ser calculadas y justificadas por el equipo.*

### Informe 1. Volumen mensual

| **Mes** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: clientes\_afectados** |
| --- | --- | --- | --- | --- |
| 2025-01 | 22 | 22 | 10 | 85,920 |
| 2025-02 | 20 | 20 | 7 | 77,432 |
| 2025-03 | 18 | 18 | 7 | 53,846 |
| 2025-04 | 20 | 19 | 8 | 55,114 |
| 2025-05 | 18 | 18 | 5 | 63,857 |
| 2025-06 | 17 | 17 | 3 | 47,636 |
| 2025-07 | 18 | 18 | 7 | 57,549 |
| 2025-08 | 26 | 25 | 8 | 88,119 |
| 2025-09 | 26 | 26 | 8 | 99,433 |
| 2025-10 | 23 | 22 | 12 | 92,949 |
| 2025-11 | 14 | 14 | 5 | 40,691 |
| 2025-12 | 24 | 24 | 7 | 80,486 |
| 2026-01 | 30 | 29 | 15 | 92,608 |
| 2026-02 | 17 | 17 | 9 | 48,568 |
| 2026-03 | 13 | 13 | 6 | 28,268 |
| 2026-04 | 12 | 12 | 5 | 42,524 |
| 2026-05 | 24 | 23 | 9 | 67,391 |
| 2026-06 | 18 | 17 | 6 | 63,123 |

### Informe 2. Desglose por tipo_red

| **tipo\_red** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: clientes\_afectados** |
| --- | --- | --- | --- | --- |
| (sin dato) | 9 | 8 | 3 | 30,248 |
| Aérea | 101 | 98 | 39 | 342,197 |
| Mixta | 127 | 126 | 52 | 406,974 |
| Subterránea | 123 | 122 | 43 | 406,095 |

### Informe 3. Desglose por causa_reportada

| **causa\_reportada** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: clientes\_afectados** |
| --- | --- | --- | --- | --- |
| Clima | 77 | 77 | 21 | 272,015 |
| CLIMA | 2 | 2 | 2 | 9,313 |
| Equipo | 69 | 68 | 31 | 238,406 |
| No determinada | 67 | 65 | 22 | 220,185 |
| Terceros | 74 | 72 | 25 | 227,296 |
| TERCEROS | 1 | 1 | 0 | 2,121 |
| Vegetación | 69 | 69 | 36 | 209,648 |
| VEGETACIÓN | 1 | 0 | 0 | 6,530 |

### Informe 4. Desglose por circuito

| **circuito** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: clientes\_afectados** |
| --- | --- | --- | --- | --- |
| CRZ-01 | 61 | 59 | 16 | 218,584 |
| CRZ-04 | 82 | 79 | 35 | 259,444 |
| GRD-03 | 61 | 60 | 23 | 203,106 |
| MSY-02 | 78 | 78 | 29 | 256,198 |
| RVS-05 | 78 | 78 | 34 | 248,182 |

## 9. Referencias operativas y restricciones

|  |  |
| --- | --- |
| **Referencia comparativa** | Indicadores de continuidad definidos por regulación; telecontrol disponible 99%; causas clasificadas en menos de 48 horas. |
| **Privacidad y ética** | La ubicación de infraestructura crítica y vulnerabilidades técnicas se consideran información restringida. |
| **Acceso inicial** | Lectura sobre dataset v0; cualquier dato derivado debe documentar origen, transformación y responsable. |
| **Uso permitido** | Exclusivamente académico dentro del Integrador VIII; no reutilizar nombres ficticios como si fueran organizaciones reales. |

## 10. Paquete recibido por el analista

| **N.º** | **Elemento** | **Contenido inicial** |
| --- | --- | --- |
| 1 | Este expediente de Fase 0 | Contexto, actores, proceso factual, fuentes, diccionario y reportes |
| 2 | Hoja C12_Energia del libro de datos | 360 registros sin limpiar |
| 3 | Matriz Integradora y BOA | Criterios de los tres cortes y evidencias obligatorias |
| 4 | Guía de la primera fase | Orientación para organizar el primer incremento |

**CASO 13**

# Calidad de lotes en una planta de manufactura

*Industrias TecnoPlast | Manufactura*

|  |
| --- |
| **Documento que recibe el analista:** Expediente inicial de Fase 0. Contiene hechos, fuentes y datos de partida; no contiene problema formulado, objetivos, KPIs resueltos, técnica de minería seleccionada, marco de gobierno, mapa AS-IS/TO-BE, conclusiones ni recomendaciones. |

## 1. Identificación y asignación

| **Equipo / estudiante** | **Integrantes** | **Fecha de asignación** |
| --- | --- | --- |

| **Organización** | Industrias TecnoPlast |
| --- | --- |
| **Sector y ubicación** | Manufactura \| Parque Industrial Tipitapa |
| **Operación** | Inyección y ensamble de componentes plásticos. |
| **Dimensión** | 14 líneas; 1,800 lotes mensuales |
| **Periodo disponible** | enero 2024-junio 2026 |
| **Unidad de análisis** | lote de producción |
| **Decisión institucional** | Priorizar controles de proceso, mantenimiento y capacitación por línea. |

## 2. Contexto entregado

Industrias TecnoPlast entrega al equipo un conjunto inicial compuesto por MES, calidad, mantenimiento, laboratorio y recursos humanos. La dirección solicita examinar los datos antes de formular el problema definitivo. El análisis debe distinguir hechos, supuestos y conclusiones, y conservar trazabilidad hacia cada fuente.

**Condición de trabajo.** *Los datos son sintéticos y fueron construidos para fines académicos, pero deben tratarse como si estuvieran sujetos a controles reales de acceso, seguridad, privacidad, calidad y ciclo de vida.*

## 3. Proceso operativo actual: hechos observados

| **Paso** | **Hecho operativo comunicado** | **Evidencia disponible** |
| --- | --- | --- |
| 1 | Producción abre el lote en MES. | MES |
| 2 | Sensores capturan parámetros de máquina. | MES |
| 3 | Calidad toma muestras por frecuencia. | Calidad |
| 4 | Laboratorio registra resultados. | Laboratorio |
| 5 | Mantenimiento documenta paros e intervenciones. | Mantenimiento |
| 6 | Calidad libera o bloquea el lote. | Calidad |

*La secuencia anterior es una descripción factual. Corresponde al equipo verificarla, delimitarla y convertirla en los modelos de proceso exigidos por el Integrador VIII.*

## 4. Actores que participan en el caso

| **Actor / área** | **Participación conocida al inicio** |
| --- | --- |
| Gerencia de Planta | Patrocinio |
| Producción | Parámetros |
| Calidad | Liberación |
| Mantenimiento | Paros |
| TI industrial | MES e integraciones |

## 5. Inventario inicial de fuentes

| **Fuente** | **Responsable conocido** | **Formato** | **Actualización** | **Condición inicial** |
| --- | --- | --- | --- | --- |
| MES | Producción | Base SQL / vista | Diaria | Acceso por rol; validación pendiente |
| Calidad | Calidad | API / eventos | Casi en tiempo real | Acceso por rol; validación pendiente |
| Mantenimiento | Mantenimiento | Archivo XLSX | Semanal | Acceso por rol; validación pendiente |
| Laboratorio | Laboratorio | CSV exportado | Mensual | Acceso por rol; validación pendiente |

## 6. Ficha técnica del dataset v0

| **Archivo de datos** | Datos_Iniciales_16_Casos_Integrador_VIII.xlsx |
| --- | --- |
| **Hoja asignada** | C13_Manufactura |
| **Cantidad de registros** | 360 registros sintéticos |
| **Cantidad de variables** | 15 variables |
| **Variable de resultado disponible** | lote_no_conforme: 1 = Lote clasificado como no conforme; 0 = caso contrario; vacío = no consolidado |
| **Copia de resguardo** | Conservar la hoja original como dataset v0; todas las transformaciones deben quedar en una versión derivada. |
| **Advertencia de calidad:** El dataset conserva de manera intencional valores faltantes, registros repetidos, etiquetas no normalizadas, cargas tardías y valores fuera de rango. No se indican sus cantidades ni ubicaciones: forman parte del diagnóstico que debe realizar el equipo. |  |

## 7. Diccionario preliminar de variables

| **Variable** | **Tipo** | **Descripción inicial** | **Uso conocido** |
| --- | --- | --- | --- |
| id_lote | Texto | Identificador seudonimizado del registro | Clave operativa |
| fecha_produccion | Fecha | Fecha del evento o corte | Tiempo |
| linea | Texto | Ubicación/unidad: Línea 01, Línea 03, Línea 05, Línea 08, Línea 12 | Segmentación |
| turno | Texto | Canal/modalidad: Diurno, Mixto, Nocturno | Segmentación |
| familia_producto | Texto | Segmento: Envases, Tapas, Componentes, Piezas técnicas | Segmentación |
| proveedor_resina | Texto | Categoría: Proveedor A, Proveedor B, Proveedor C, Reciclado interno | Segmentación |
| unidades_lote | Numérico | Medida operacional. Rango esperado 200-6500 | Medición |
| tiempo_ciclo_seg | Numérico | Duración/antigüedad. Rango esperado 8-95 | Medición |
| temperatura_promedio_c | Numérico | Indicador operacional 1. Rango esperado 160-280 | Medición |
| paros_turno | Numérico | Indicador operacional 2. Rango esperado 0-8 | Medición |
| experiencia_operador | Texto | Variable auxiliar: <6 meses, 6-24 meses, 2-5 años, >5 años | Contexto |
| sistema_origen | Texto | Sistema de procedencia: MES, Calidad, Mantenimiento, Laboratorio | Linaje |
| lote_no_conforme | Binaria | 1 = Lote clasificado como no conforme; 0 = caso contrario; nulo = no consolidado | Resultado |
| uso_laboral_agregado | Texto | Bandera de autorización o uso permitido según el caso | Gobierno |
| fecha_carga | Fecha | Fecha de incorporación al conjunto analítico | Oportunidad |

## 8. Informes operativos entregados

*Los siguientes cuadros son resúmenes neutrales del dataset v0. Las tasas, comparaciones, prioridades e interpretaciones deben ser calculadas y justificadas por el equipo.*

### Informe 1. Volumen mensual

| **Mes** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: unidades\_lote** |
| --- | --- | --- | --- | --- |
| 2025-01 | 25 | 25 | 4 | 74,052 |
| 2025-02 | 12 | 11 | 4 | 51,449 |
| 2025-03 | 20 | 20 | 8 | 49,651 |
| 2025-04 | 25 | 25 | 5 | 79,530 |
| 2025-05 | 19 | 19 | 9 | 56,200 |
| 2025-06 | 22 | 22 | 5 | 77,997 |
| 2025-07 | 16 | 15 | 3 | 49,926 |
| 2025-08 | 30 | 28 | 9 | 116,527 |
| 2025-09 | 19 | 19 | 3 | 58,886 |
| 2025-10 | 22 | 22 | 4 | 72,414 |
| 2025-11 | 16 | 16 | 4 | 53,796 |
| 2025-12 | 29 | 29 | 7 | 88,593 |
| 2026-01 | 15 | 14 | 5 | 44,571 |
| 2026-02 | 14 | 14 | 7 | 41,547 |
| 2026-03 | 25 | 25 | 5 | 102,534 |
| 2026-04 | 19 | 19 | 3 | 57,270 |
| 2026-05 | 15 | 15 | 4 | 47,208 |
| 2026-06 | 17 | 16 | 5 | 48,345 |

### Informe 2. Desglose por turno

| **turno** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: unidades\_lote** |
| --- | --- | --- | --- | --- |
| (sin dato) | 9 | 8 | 1 | 32,858 |
| Diurno | 107 | 104 | 23 | 349,479 |
| Mixto | 112 | 111 | 31 | 367,206 |
| Nocturno | 132 | 131 | 39 | 420,953 |

### Informe 3. Desglose por proveedor_resina

| **proveedor\_resina** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: unidades\_lote** |
| --- | --- | --- | --- | --- |
| Proveedor A | 93 | 93 | 22 | 330,595 |
| PROVEEDOR A | 2 | 2 | 0 | 3,352 |
| Proveedor B | 100 | 99 | 22 | 315,355 |
| PROVEEDOR B | 2 | 1 | 0 | 7,274 |
| Proveedor C | 84 | 81 | 27 | 271,062 |
| Reciclado interno | 79 | 78 | 23 | 242,858 |

### Informe 4. Desglose por linea

| **linea** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: unidades\_lote** |
| --- | --- | --- | --- | --- |
| Línea 01 | 58 | 56 | 13 | 190,147 |
| Línea 03 | 66 | 64 | 17 | 226,762 |
| Línea 05 | 84 | 84 | 20 | 271,509 |
| Línea 08 | 76 | 75 | 20 | 226,630 |
| Línea 12 | 76 | 75 | 24 | 255,448 |

## 9. Referencias operativas y restricciones

|  |  |
| --- | --- |
| **Referencia comparativa** | Lotes no conformes máximo: 3%; trazabilidad de materia prima: 100%; liberación de calidad dentro de 4 horas. |
| **Privacidad y ética** | Los datos de desempeño de operadores se analizarán de forma agregada y con acceso restringido. |
| **Acceso inicial** | Lectura sobre dataset v0; cualquier dato derivado debe documentar origen, transformación y responsable. |
| **Uso permitido** | Exclusivamente académico dentro del Integrador VIII; no reutilizar nombres ficticios como si fueran organizaciones reales. |

## 10. Paquete recibido por el analista

| **N.º** | **Elemento** | **Contenido inicial** |
| --- | --- | --- |
| 1 | Este expediente de Fase 0 | Contexto, actores, proceso factual, fuentes, diccionario y reportes |
| 2 | Hoja C13_Manufactura del libro de datos | 360 registros sin limpiar |
| 3 | Matriz Integradora y BOA | Criterios de los tres cortes y evidencias obligatorias |
| 4 | Guía de la primera fase | Orientación para organizar el primer incremento |

**CASO 14**

# Riesgo de vencimiento y disponibilidad de medicamentos

*Farmacias Vida Plena | Distribución farmacéutica*

|  |
| --- |
| **Documento que recibe el analista:** Expediente inicial de Fase 0. Contiene hechos, fuentes y datos de partida; no contiene problema formulado, objetivos, KPIs resueltos, técnica de minería seleccionada, marco de gobierno, mapa AS-IS/TO-BE, conclusiones ni recomendaciones. |

## 1. Identificación y asignación

| **Equipo / estudiante** | **Integrantes** | **Fecha de asignación** |
| --- | --- | --- |

| **Organización** | Farmacias Vida Plena |
| --- | --- |
| **Sector y ubicación** | Distribución farmacéutica \| Managua, Masaya y Carazo |
| **Operación** | 24 sucursales y una bodega central. |
| **Dimensión** | 3,800 SKU; 520,000 dispensaciones/año |
| **Periodo disponible** | enero 2024-junio 2026 |
| **Unidad de análisis** | lote-sucursal-mes |
| **Decisión institucional** | Priorizar redistribución y compras conservando disponibilidad y trazabilidad sanitaria. |

## 2. Contexto entregado

Farmacias Vida Plena entrega al equipo un conjunto inicial compuesto por Inventario por lote, ventas, compras, devoluciones y temperatura. La dirección solicita examinar los datos antes de formular el problema definitivo. El análisis debe distinguir hechos, supuestos y conclusiones, y conservar trazabilidad hacia cada fuente.

**Condición de trabajo.** *Los datos son sintéticos y fueron construidos para fines académicos, pero deben tratarse como si estuvieran sujetos a controles reales de acceso, seguridad, privacidad, calidad y ciclo de vida.*

## 3. Proceso operativo actual: hechos observados

| **Paso** | **Hecho operativo comunicado** | **Evidencia disponible** |
| --- | --- | --- |
| 1 | Compras registra lote y vencimiento. | Compras |
| 2 | Bodega recibe y distribuye bajo FEFO. | ERP |
| 3 | POS descuenta unidades por sucursal. | POS |
| 4 | Sucursales solicitan traslados por mensajería. | ERP |
| 5 | Sensores registran temperatura. | Sensores |
| 6 | Dirección Técnica revisa vencimientos mensualmente. | ERP |

*La secuencia anterior es una descripción factual. Corresponde al equipo verificarla, delimitarla y convertirla en los modelos de proceso exigidos por el Integrador VIII.*

## 4. Actores que participan en el caso

| **Actor / área** | **Participación conocida al inicio** |
| --- | --- |
| Dirección Técnica | Cumplimiento sanitario |
| Abastecimiento | Compras |
| Sucursales | Conteo y venta |
| Bodega | Lotes |
| TI | ERP y sensores |

## 5. Inventario inicial de fuentes

| **Fuente** | **Responsable conocido** | **Formato** | **Actualización** | **Condición inicial** |
| --- | --- | --- | --- | --- |
| ERP | Abastecimiento | Base SQL / vista | Diaria | Acceso por rol; validación pendiente |
| POS | Sucursales | API / eventos | Casi en tiempo real | Acceso por rol; validación pendiente |
| Compras | Abastecimiento | Archivo XLSX | Semanal | Acceso por rol; validación pendiente |
| Sensores | TI | CSV exportado | Mensual | Acceso por rol; validación pendiente |

## 6. Ficha técnica del dataset v0

| **Archivo de datos** | Datos_Iniciales_16_Casos_Integrador_VIII.xlsx |
| --- | --- |
| **Hoja asignada** | C14_Farmacia |
| **Cantidad de registros** | 360 registros sintéticos |
| **Cantidad de variables** | 15 variables |
| **Variable de resultado disponible** | perdida_por_vencimiento: 1 = Lote con pérdida por vencimiento; 0 = caso contrario; vacío = no consolidado |
| **Copia de resguardo** | Conservar la hoja original como dataset v0; todas las transformaciones deben quedar en una versión derivada. |
| **Advertencia de calidad:** El dataset conserva de manera intencional valores faltantes, registros repetidos, etiquetas no normalizadas, cargas tardías y valores fuera de rango. No se indican sus cantidades ni ubicaciones: forman parte del diagnóstico que debe realizar el equipo. |  |

## 7. Diccionario preliminar de variables

| **Variable** | **Tipo** | **Descripción inicial** | **Uso conocido** |
| --- | --- | --- | --- |
| id_lote_sucursal_mes | Texto | Identificador seudonimizado del registro | Clave operativa |
| fecha_corte | Fecha | Fecha del evento o corte | Tiempo |
| sucursal | Texto | Ubicación/unidad: Jinotepe, Diriamba, Masaya, Managua Oriental, Bodega Central | Segmentación |
| condicion_venta | Texto | Canal/modalidad: Receta, Venta libre, Convenio, Programa crónico | Segmentación |
| grupo_terapeutico | Texto | Segmento: Cardiovascular, Antibiótico, Analgésico, Diabetes, Cuidado personal | Segmentación |
| proveedor | Texto | Categoría: Proveedor A, Proveedor B, Proveedor C, Importación directa | Segmentación |
| existencia_unidades | Numérico | Medida operacional. Rango esperado 0-1200 | Medición |
| dias_para_vencer | Numérico | Duración/antigüedad. Rango esperado 10-720 | Medición |
| venta_promedio_mensual | Numérico | Indicador operacional 1. Rango esperado 0-650 | Medición |
| traslados_90d | Numérico | Indicador operacional 2. Rango esperado 0-6 | Medición |
| cadena_frio | Texto | Variable auxiliar: Sí, No, Control ambiental | Contexto |
| sistema_origen | Texto | Sistema de procedencia: ERP, POS, Compras, Sensores | Linaje |
| perdida_por_vencimiento | Binaria | 1 = Lote con pérdida por vencimiento; 0 = caso contrario; nulo = no consolidado | Resultado |
| uso_sanitario_autorizado | Texto | Bandera de autorización o uso permitido según el caso | Gobierno |
| fecha_carga | Fecha | Fecha de incorporación al conjunto analítico | Oportunidad |

## 8. Informes operativos entregados

*Los siguientes cuadros son resúmenes neutrales del dataset v0. Las tasas, comparaciones, prioridades e interpretaciones deben ser calculadas y justificadas por el equipo.*

### Informe 1. Volumen mensual

| **Mes** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: existencia\_unidades** |
| --- | --- | --- | --- | --- |
| 2025-01 | 24 | 24 | 4 | 13,396 |
| 2025-02 | 17 | 17 | 5 | 9,226 |
| 2025-03 | 17 | 17 | 6 | 9,534 |
| 2025-04 | 18 | 18 | 7 | 11,185 |
| 2025-05 | 20 | 20 | 7 | 10,719 |
| 2025-06 | 19 | 19 | 9 | 12,453 |
| 2025-07 | 12 | 11 | 5 | 6,229 |
| 2025-08 | 25 | 25 | 13 | 16,544 |
| 2025-09 | 25 | 25 | 6 | 13,031 |
| 2025-10 | 16 | 16 | 8 | 7,901 |
| 2025-11 | 29 | 29 | 9 | 16,592 |
| 2025-12 | 23 | 21 | 7 | 14,239 |
| 2026-01 | 18 | 18 | 9 | 10,502 |
| 2026-02 | 18 | 18 | 8 | 12,643 |
| 2026-03 | 22 | 22 | 12 | 17,211 |
| 2026-04 | 22 | 19 | 6 | 15,388 |
| 2026-05 | 19 | 19 | 12 | 9,603 |
| 2026-06 | 16 | 16 | 7 | 7,410 |

### Informe 2. Desglose por condicion_venta

| **condicion\_venta** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: existencia\_unidades** |
| --- | --- | --- | --- | --- |
| (sin dato) | 9 | 8 | 5 | 5,587 |
| Convenio | 108 | 106 | 39 | 63,467 |
| Programa crónico | 73 | 72 | 28 | 42,402 |
| Receta | 83 | 83 | 37 | 51,804 |
| Venta libre | 87 | 85 | 31 | 50,546 |

### Informe 3. Desglose por proveedor

| **proveedor** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: existencia\_unidades** |
| --- | --- | --- | --- | --- |
| Importación directa | 86 | 84 | 33 | 49,661 |
| Proveedor A | 89 | 89 | 33 | 54,175 |
| PROVEEDOR A | 3 | 3 | 0 | 1,181 |
| Proveedor B | 88 | 86 | 44 | 50,639 |
| Proveedor C | 93 | 92 | 30 | 57,315 |
| PROVEEDOR C | 1 | 0 | 0 | 835 |

### Informe 4. Desglose por sucursal

| **sucursal** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: existencia\_unidades** |
| --- | --- | --- | --- | --- |
| Bodega Central | 73 | 73 | 32 | 46,456 |
| Diriamba | 77 | 77 | 34 | 42,751 |
| Jinotepe | 67 | 65 | 24 | 43,301 |
| Managua Oriental | 68 | 67 | 21 | 36,618 |
| Masaya | 75 | 72 | 29 | 44,680 |

## 9. Referencias operativas y restricciones

|  |  |
| --- | --- |
| **Referencia comparativa** | Pérdida por vencimiento máxima: 1.5% del inventario; FEFO aplicado al 100%; temperatura crítica reportada en 15 minutos. |
| **Privacidad y ética** | No incluir datos identificables de pacientes ni inferir tratamientos; el análisis se limita a inventario y dispensación agregada. |
| **Acceso inicial** | Lectura sobre dataset v0; cualquier dato derivado debe documentar origen, transformación y responsable. |
| **Uso permitido** | Exclusivamente académico dentro del Integrador VIII; no reutilizar nombres ficticios como si fueran organizaciones reales. |

## 10. Paquete recibido por el analista

| **N.º** | **Elemento** | **Contenido inicial** |
| --- | --- | --- |
| 1 | Este expediente de Fase 0 | Contexto, actores, proceso factual, fuentes, diccionario y reportes |
| 2 | Hoja C14_Farmacia del libro de datos | 360 registros sin limpiar |
| 3 | Matriz Integradora y BOA | Criterios de los tres cortes y evidencias obligatorias |
| 4 | Guía de la primera fase | Orientación para organizar el primer incremento |

**CASO 15**

# Resolución y recontacto en un centro de atención

*Servicio Ciudadano 1800 | Centro de contacto multiservicio*

|  |
| --- |
| **Documento que recibe el analista:** Expediente inicial de Fase 0. Contiene hechos, fuentes y datos de partida; no contiene problema formulado, objetivos, KPIs resueltos, técnica de minería seleccionada, marco de gobierno, mapa AS-IS/TO-BE, conclusiones ni recomendaciones. |

## 1. Identificación y asignación

| **Equipo / estudiante** | **Integrantes** | **Fecha de asignación** |
| --- | --- | --- |

| **Organización** | Servicio Ciudadano 1800 |
| --- | --- |
| **Sector y ubicación** | Centro de contacto multiservicio \| Cobertura nacional |
| **Operación** | Atención telefónica, chat, correo y redes sociales. |
| **Dimensión** | 420,000 interacciones anuales; 110 agentes |
| **Periodo disponible** | enero 2024-junio 2026 |
| **Unidad de análisis** | interacción |
| **Decisión institucional** | Mejorar asignación, conocimiento y resolución de solicitudes. |

## 2. Contexto entregado

Servicio Ciudadano 1800 entrega al equipo un conjunto inicial compuesto por ACD, CRM, tickets, calidad y encuestas. La dirección solicita examinar los datos antes de formular el problema definitivo. El análisis debe distinguir hechos, supuestos y conclusiones, y conservar trazabilidad hacia cada fuente.

**Condición de trabajo.** *Los datos son sintéticos y fueron construidos para fines académicos, pero deben tratarse como si estuvieran sujetos a controles reales de acceso, seguridad, privacidad, calidad y ciclo de vida.*

## 3. Proceso operativo actual: hechos observados

| **Paso** | **Hecho operativo comunicado** | **Evidencia disponible** |
| --- | --- | --- |
| 1 | La plataforma recibe el contacto. | ACD |
| 2 | IVR o bot clasifica el motivo. | ACD |
| 3 | La interacción se asigna a una cola. | ACD |
| 4 | El agente registra cierre y disposición. | CRM |
| 5 | Tickets técnicos continúan en otra herramienta. | Ticketing |
| 6 | Calidad revisa muestras y reportes semanales. | Calidad |

*La secuencia anterior es una descripción factual. Corresponde al equipo verificarla, delimitarla y convertirla en los modelos de proceso exigidos por el Integrador VIII.*

## 4. Actores que participan en el caso

| **Actor / área** | **Participación conocida al inicio** |
| --- | --- |
| Gerencia de Servicio | Patrocinio |
| Operaciones | Colas |
| Calidad | Evaluación |
| Conocimiento | Guías |
| TI/Seguridad | Canales y accesos |

## 5. Inventario inicial de fuentes

| **Fuente** | **Responsable conocido** | **Formato** | **Actualización** | **Condición inicial** |
| --- | --- | --- | --- | --- |
| ACD | Operaciones | Base SQL / vista | Diaria | Acceso por rol; validación pendiente |
| CRM | Gerencia de Servicio | API / eventos | Casi en tiempo real | Acceso por rol; validación pendiente |
| Ticketing | Operaciones | Archivo XLSX | Semanal | Acceso por rol; validación pendiente |
| Calidad | Calidad | CSV exportado | Mensual | Acceso por rol; validación pendiente |

## 6. Ficha técnica del dataset v0

| **Archivo de datos** | Datos_Iniciales_16_Casos_Integrador_VIII.xlsx |
| --- | --- |
| **Hoja asignada** | C15_CallCenter |
| **Cantidad de registros** | 360 registros sintéticos |
| **Cantidad de variables** | 15 variables |
| **Variable de resultado disponible** | recontacto_7_dias: 1 = Usuario que vuelve a contactar por el mismo motivo en 7 días; 0 = caso contrario; vacío = no consolidado |
| **Copia de resguardo** | Conservar la hoja original como dataset v0; todas las transformaciones deben quedar en una versión derivada. |
| **Advertencia de calidad:** El dataset conserva de manera intencional valores faltantes, registros repetidos, etiquetas no normalizadas, cargas tardías y valores fuera de rango. No se indican sus cantidades ni ubicaciones: forman parte del diagnóstico que debe realizar el equipo. |  |

## 7. Diccionario preliminar de variables

| **Variable** | **Tipo** | **Descripción inicial** | **Uso conocido** |
| --- | --- | --- | --- |
| id_interaccion | Texto | Identificador seudonimizado del registro | Clave operativa |
| fecha_contacto | Fecha | Fecha del evento o corte | Tiempo |
| cola_servicio | Texto | Ubicación/unidad: Facturación, Soporte, Información, Reclamos, Trámites | Segmentación |
| canal | Texto | Canal/modalidad: Teléfono, Chat, Correo, Red social | Segmentación |
| tipo_usuario | Texto | Segmento: Nuevo, Recurrente, Empresa, Adulto mayor | Segmentación |
| motivo_contacto | Texto | Categoría: Consulta, Falla, Cobro, Solicitud, Queja | Segmentación |
| duracion_seg | Numérico | Medida operacional. Rango esperado 30-1800 | Medición |
| espera_seg | Numérico | Duración/antigüedad. Rango esperado 0-900 | Medición |
| transferencias | Numérico | Indicador operacional 1. Rango esperado 0-4 | Medición |
| casos_previos_30d | Numérico | Indicador operacional 2. Rango esperado 0-8 | Medición |
| turno | Texto | Variable auxiliar: AM, PM, Nocturno, Fin de semana | Contexto |
| sistema_origen | Texto | Sistema de procedencia: ACD, CRM, Ticketing, Calidad | Linaje |
| recontacto_7_dias | Binaria | 1 = Usuario que vuelve a contactar por el mismo motivo en 7 días; 0 = caso contrario; nulo = no consolidado | Resultado |
| grabacion_autorizada | Texto | Bandera de autorización o uso permitido según el caso | Gobierno |
| fecha_carga | Fecha | Fecha de incorporación al conjunto analítico | Oportunidad |

## 8. Informes operativos entregados

*Los siguientes cuadros son resúmenes neutrales del dataset v0. Las tasas, comparaciones, prioridades e interpretaciones deben ser calculadas y justificadas por el equipo.*

### Informe 1. Volumen mensual

| **Mes** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: duracion\_seg** |
| --- | --- | --- | --- | --- |
| 2025-01 | 12 | 12 | 4 | 10,061 |
| 2025-02 | 18 | 17 | 3 | 17,251 |
| 2025-03 | 17 | 16 | 5 | 16,456 |
| 2025-04 | 11 | 11 | 5 | 8,081 |
| 2025-05 | 18 | 18 | 6 | 20,590 |
| 2025-06 | 23 | 22 | 11 | 22,652 |
| 2025-07 | 21 | 20 | 9 | 25,330 |
| 2025-08 | 20 | 20 | 7 | 18,035 |
| 2025-09 | 24 | 24 | 11 | 23,088 |
| 2025-10 | 28 | 28 | 14 | 24,704 |
| 2025-11 | 24 | 24 | 13 | 22,539 |
| 2025-12 | 24 | 23 | 12 | 23,066 |
| 2026-01 | 15 | 15 | 9 | 15,475 |
| 2026-02 | 20 | 20 | 6 | 20,443 |
| 2026-03 | 20 | 20 | 2 | 19,377 |
| 2026-04 | 20 | 20 | 8 | 18,459 |
| 2026-05 | 24 | 23 | 14 | 19,952 |
| 2026-06 | 21 | 21 | 6 | 15,924 |

### Informe 2. Desglose por canal

| **canal** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: duracion\_seg** |
| --- | --- | --- | --- | --- |
| (sin dato) | 9 | 8 | 4 | 10,625 |
| Chat | 96 | 95 | 38 | 98,744 |
| Correo | 83 | 83 | 33 | 76,313 |
| Red social | 81 | 79 | 37 | 69,426 |
| Teléfono | 91 | 89 | 33 | 86,375 |

### Informe 3. Desglose por motivo_contacto

| **motivo\_contacto** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: duracion\_seg** |
| --- | --- | --- | --- | --- |
| Cobro | 70 | 68 | 25 | 64,970 |
| COBRO | 2 | 2 | 1 | 2,310 |
| Consulta | 60 | 59 | 18 | 57,332 |
| Falla | 80 | 80 | 39 | 80,873 |
| Queja | 79 | 78 | 35 | 69,028 |
| QUEJA | 2 | 1 | 0 | 1,772 |
| Solicitud | 67 | 66 | 27 | 65,198 |

### Informe 4. Desglose por cola_servicio

| **cola\_servicio** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: duracion\_seg** |
| --- | --- | --- | --- | --- |
| Facturación | 68 | 68 | 32 | 65,170 |
| Información | 95 | 93 | 40 | 91,321 |
| Reclamos | 54 | 54 | 20 | 51,697 |
| Soporte | 68 | 64 | 22 | 61,825 |
| Trámites | 75 | 75 | 31 | 71,470 |

## 9. Referencias operativas y restricciones

|  |  |
| --- | --- |
| **Referencia comparativa** | Resolución en primer contacto referencial: 78%; abandono máximo: 8%; codificación de motivo completa: 97%. |
| **Privacidad y ética** | Las grabaciones y textos libres requieren controles reforzados; el dataset no contiene contenido de conversaciones. |
| **Acceso inicial** | Lectura sobre dataset v0; cualquier dato derivado debe documentar origen, transformación y responsable. |
| **Uso permitido** | Exclusivamente académico dentro del Integrador VIII; no reutilizar nombres ficticios como si fueran organizaciones reales. |

## 10. Paquete recibido por el analista

| **N.º** | **Elemento** | **Contenido inicial** |
| --- | --- | --- |
| 1 | Este expediente de Fase 0 | Contexto, actores, proceso factual, fuentes, diccionario y reportes |
| 2 | Hoja C15_CallCenter del libro de datos | 360 registros sin limpiar |
| 3 | Matriz Integradora y BOA | Criterios de los tres cortes y evidencias obligatorias |
| 4 | Guía de la primera fase | Orientación para organizar el primer incremento |

**CASO 16**

# Cumplimiento de rutas de recolección de residuos

*Servicios Municipales Ciudad Limpia | Gestión de residuos sólidos*

|  |
| --- |
| **Documento que recibe el analista:** Expediente inicial de Fase 0. Contiene hechos, fuentes y datos de partida; no contiene problema formulado, objetivos, KPIs resueltos, técnica de minería seleccionada, marco de gobierno, mapa AS-IS/TO-BE, conclusiones ni recomendaciones. |

## 1. Identificación y asignación

| **Equipo / estudiante** | **Integrantes** | **Fecha de asignación** |
| --- | --- | --- |

| **Organización** | Servicios Municipales Ciudad Limpia |
| --- | --- |
| **Sector y ubicación** | Gestión de residuos sólidos \| Municipios de Carazo |
| **Operación** | Recolección domiciliar, comercial y puntos especiales. |
| **Dimensión** | 32 rutas; 48 unidades; 41,000 usuarios |
| **Periodo disponible** | enero 2024-junio 2026 |
| **Unidad de análisis** | ruta-jornada |
| **Decisión institucional** | Priorizar rutas, mantenimiento y supervisión para cumplir frecuencias programadas. |

## 2. Contexto entregado

Servicios Municipales Ciudad Limpia entrega al equipo un conjunto inicial compuesto por Programación, GPS, báscula, mantenimiento y reportes ciudadanos. La dirección solicita examinar los datos antes de formular el problema definitivo. El análisis debe distinguir hechos, supuestos y conclusiones, y conservar trazabilidad hacia cada fuente.

**Condición de trabajo.** *Los datos son sintéticos y fueron construidos para fines académicos, pero deben tratarse como si estuvieran sujetos a controles reales de acceso, seguridad, privacidad, calidad y ciclo de vida.*

## 3. Proceso operativo actual: hechos observados

| **Paso** | **Hecho operativo comunicado** | **Evidencia disponible** |
| --- | --- | --- |
| 1 | Operaciones programa rutas y unidades. | Programación |
| 2 | Supervisión entrega hoja de jornada. | Programación |
| 3 | GPS registra el recorrido. | GPS |
| 4 | Báscula registra toneladas al ingreso. | Báscula |
| 5 | Atención recibe reportes ciudadanos. | Atención ciudadana |
| 6 | La jefatura consolida cumplimiento cada semana. | Programación |

*La secuencia anterior es una descripción factual. Corresponde al equipo verificarla, delimitarla y convertirla en los modelos de proceso exigidos por el Integrador VIII.*

## 4. Actores que participan en el caso

| **Actor / área** | **Participación conocida al inicio** |
| --- | --- |
| Dirección Municipal | Patrocinio |
| Operaciones | Programación |
| Supervisión | Cierre de rutas |
| Mantenimiento | Flota |
| TI/GPS | Trazas |

## 5. Inventario inicial de fuentes

| **Fuente** | **Responsable conocido** | **Formato** | **Actualización** | **Condición inicial** |
| --- | --- | --- | --- | --- |
| Programación | Operaciones | Base SQL / vista | Diaria | Acceso por rol; validación pendiente |
| GPS | TI/GPS | API / eventos | Casi en tiempo real | Acceso por rol; validación pendiente |
| Báscula | Supervisión | Archivo XLSX | Semanal | Acceso por rol; validación pendiente |
| Atención ciudadana | Atención ciudadana | CSV exportado | Mensual | Acceso por rol; validación pendiente |

## 6. Ficha técnica del dataset v0

| **Archivo de datos** | Datos_Iniciales_16_Casos_Integrador_VIII.xlsx |
| --- | --- |
| **Hoja asignada** | C16_Residuos |
| **Cantidad de registros** | 360 registros sintéticos |
| **Cantidad de variables** | 15 variables |
| **Variable de resultado disponible** | recoleccion_incompleta: 1 = Ruta con recolección incompleta; 0 = caso contrario; vacío = no consolidado |
| **Copia de resguardo** | Conservar la hoja original como dataset v0; todas las transformaciones deben quedar en una versión derivada. |
| **Advertencia de calidad:** El dataset conserva de manera intencional valores faltantes, registros repetidos, etiquetas no normalizadas, cargas tardías y valores fuera de rango. No se indican sus cantidades ni ubicaciones: forman parte del diagnóstico que debe realizar el equipo. |  |

## 7. Diccionario preliminar de variables

| **Variable** | **Tipo** | **Descripción inicial** | **Uso conocido** |
| --- | --- | --- | --- |
| id_ruta_jornada | Texto | Identificador seudonimizado del registro | Clave operativa |
| fecha_jornada | Fecha | Fecha del evento o corte | Tiempo |
| zona | Texto | Ubicación/unidad: Jinotepe, Diriamba, San Marcos, Dolores, La Paz de Carazo | Segmentación |
| tipo_ruta | Texto | Canal/modalidad: Domiciliar, Comercial, Mercado, Especial | Segmentación |
| tipo_dia | Texto | Segmento: Laborable, Sábado, Domingo, Feriado | Segmentación |
| condicion_unidad | Texto | Categoría: Disponible, Con falla menor, Sustituta, Salida tardía | Segmentación |
| toneladas_recolectadas | Numérico | Medida operacional. Rango esperado 1-18 | Medición |
| duracion_ruta_min | Numérico | Duración/antigüedad. Rango esperado 90-620 | Medición |
| paradas_registradas | Numérico | Indicador operacional 1. Rango esperado 12-180 | Medición |
| reportes_ciudadanos | Numérico | Indicador operacional 2. Rango esperado 0-25 | Medición |
| estado_clima | Texto | Variable auxiliar: Despejado, Lluvia, Viento, Evento local | Contexto |
| sistema_origen | Texto | Sistema de procedencia: Programación, GPS, Báscula, Atención ciudadana | Linaje |
| recoleccion_incompleta | Binaria | 1 = Ruta con recolección incompleta; 0 = caso contrario; nulo = no consolidado | Resultado |
| gps_uso_operativo | Texto | Bandera de autorización o uso permitido según el caso | Gobierno |
| fecha_carga | Fecha | Fecha de incorporación al conjunto analítico | Oportunidad |

## 8. Informes operativos entregados

*Los siguientes cuadros son resúmenes neutrales del dataset v0. Las tasas, comparaciones, prioridades e interpretaciones deben ser calculadas y justificadas por el equipo.*

### Informe 1. Volumen mensual

| **Mes** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: toneladas\_recolectadas** |
| --- | --- | --- | --- | --- |
| 2025-01 | 21 | 21 | 11 | 180.9 |
| 2025-02 | 16 | 16 | 10 | 147.4 |
| 2025-03 | 15 | 15 | 10 | 149.7 |
| 2025-04 | 19 | 19 | 12 | 158.7 |
| 2025-05 | 29 | 29 | 12 | 257.2 |
| 2025-06 | 22 | 22 | 7 | 207.2 |
| 2025-07 | 23 | 23 | 8 | 221.6 |
| 2025-08 | 24 | 24 | 10 | 184.7 |
| 2025-09 | 15 | 14 | 6 | 169.3 |
| 2025-10 | 22 | 21 | 9 | 204.3 |
| 2025-11 | 18 | 18 | 4 | 193.5 |
| 2025-12 | 18 | 18 | 9 | 178.1 |
| 2026-01 | 19 | 19 | 12 | 174.8 |
| 2026-02 | 29 | 29 | 10 | 240.7 |
| 2026-03 | 21 | 19 | 10 | 201.2 |
| 2026-04 | 16 | 16 | 4 | 147.7 |
| 2026-05 | 16 | 15 | 7 | 167.6 |
| 2026-06 | 17 | 16 | 9 | 199.8 |

### Informe 2. Desglose por tipo_ruta

| **tipo\_ruta** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: toneladas\_recolectadas** |
| --- | --- | --- | --- | --- |
| (sin dato) | 9 | 8 | 5 | 114.3 |
| Comercial | 105 | 103 | 47 | 969.2 |
| Domiciliar | 73 | 73 | 32 | 715.4 |
| Especial | 84 | 84 | 42 | 824.3 |
| Mercado | 89 | 86 | 34 | 761.2 |

### Informe 3. Desglose por condicion_unidad

| **condicion\_unidad** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: toneladas\_recolectadas** |
| --- | --- | --- | --- | --- |
| Con falla menor | 77 | 75 | 35 | 755.9 |
| CON FALLA MENOR | 3 | 2 | 0 | 35.4 |
| Disponible | 79 | 78 | 30 | 703.4 |
| Salida tardía | 85 | 84 | 42 | 791.5 |
| Sustituta | 115 | 114 | 52 | 1,089.8 |
| SUSTITUTA | 1 | 1 | 1 | 8.4 |

### Informe 4. Desglose por zona

| **zona** | **Registros** | **Resultado conocido** | **Resultado = 1** | **Suma: toneladas\_recolectadas** |
| --- | --- | --- | --- | --- |
| Diriamba | 72 | 71 | 29 | 675.1 |
| Dolores | 54 | 54 | 21 | 517.5 |
| Jinotepe | 73 | 72 | 37 | 679.5 |
| La Paz de Carazo | 76 | 74 | 34 | 633.8 |
| San Marcos | 85 | 83 | 39 | 878.5 |

## 9. Referencias operativas y restricciones

|  |  |
| --- | --- |
| **Referencia comparativa** | Rutas cumplidas esperadas: 96%; disponibilidad de flota: 92%; trazas GPS completas: 95%. |
| **Privacidad y ética** | La geolocalización del personal se usa solo durante la jornada; los reportes ciudadanos deben anonimizarse. |
| **Acceso inicial** | Lectura sobre dataset v0; cualquier dato derivado debe documentar origen, transformación y responsable. |
| **Uso permitido** | Exclusivamente académico dentro del Integrador VIII; no reutilizar nombres ficticios como si fueran organizaciones reales. |

## 10. Paquete recibido por el analista

| **N.º** | **Elemento** | **Contenido inicial** |
| --- | --- | --- |
| 1 | Este expediente de Fase 0 | Contexto, actores, proceso factual, fuentes, diccionario y reportes |
| 2 | Hoja C16_Residuos del libro de datos | 360 registros sin limpiar |
| 3 | Matriz Integradora y BOA | Criterios de los tres cortes y evidencias obligatorias |
| 4 | Guía de la primera fase | Orientación para organizar el primer incremento |
