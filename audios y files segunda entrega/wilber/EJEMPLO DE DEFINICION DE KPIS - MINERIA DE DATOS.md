# EJEMPLO PRÁCTICO PASO A PASO: CREACIÓN DE KPIs

Caso: SkyTravel Nicaragua - Agencia de Venta de Boletos Aéreos Aplicación del Framework GQM + SMART

## FASE 0: DATOS OBJETIVOS INICIALES (Lo que recibe el analista al llegar) CONTEXTO DEL CASO

Información General de la Empresa

Elemento: Empresa
Descripción: SkyTravel Nicaragua S.A.

Elemento: Giro
Descripción: Agencia de venta de boletos aéreos (online y presencial)

Elemento: Operación
Descripción: Vuelos nacionales e internacionales en Centroamérica y EE.UU.

Elemento: Tamaño
Descripción: 150 empleados, 85,000 clientes activos, 120,000 reservas anuales

Elemento: Plataforma
Descripción: Sistema SaaS propio + App móvil + 3 sucursales físicas

Elemento: Periodo de análisis
Descripción: 2024-2025

Elemento: Ingresos anuales 2024
Descripción: $4,200,000 USD

Nota metodológica: Estos son los datos e informes que la empresa entrega al equipo de analítica al inicio del proyecto. NO contienen conclusiones ni problemas identificados. Son datos operativos crudos que el analista debe examinar para descubrir patrones, anomalías y oportunidades.

### INFORME 1: Resumen Operativo de Reservas (Año 2024)

Fuente: Sistema SaaS propio de SkyTravel
Granularidad: Mensual
Total de registros: 120,000 reservas iniciadas en 2024

Mes: Ene
Reservas Iniciadas: 9,200
Reservas Pagadas: 3,128
Reservas Abandonadas: 6,072
Ingresos Generados (USD): $412,000

Mes: Feb
Reservas Iniciadas: 8,800
Reservas Pagadas: 2,992
Reservas Abandonadas: 5,808
Ingresos Generados (USD): $395,000

Mes: Abr: Mar
Reservas Iniciadas: 10,500
Reservas Pagadas: 3,570
Reservas Abandonadas: 6,930
Ingresos Generados (USD): $470,000

Mes: Abr
Reservas Iniciadas: 9,800
Reservas Pagadas: 3,332
Reservas Abandonadas: 6,468
Ingresos Generados (USD): $438,000

Mes: May
Reservas Iniciadas: 10,200
Reservas Pagadas: 3,468
Reservas Abandonadas: 6,732
Ingresos Generados (USD): $456,000

Mes: Jun
Reservas Iniciadas: 11,000
Reservas Pagadas: 3,740
Reservas Abandonadas: 7,260
Ingresos Generados (USD): $492,000

Mes: Jul
Reservas Iniciadas: 12,500
Reservas Pagadas: 4,250
Reservas Abandonadas: 8,250
Ingresos Generados (USD): $558,000

Mes: Ago
Reservas Iniciadas: 11,800
Reservas Pagadas: 4,012
Reservas Abandonadas: 7,788
Ingresos Generados (USD): $526,000

Mes: Sep
Reservas Iniciadas: 9,500
Reservas Pagadas: 3,230
Reservas Abandonadas: 6,270
Ingresos Generados (USD): $426,000

Mes: Oct
Reservas Iniciadas: 10,000
Reservas Pagadas: 3,400
Reservas Abandonadas: 6,600
Ingresos Generados (USD): $448,000

Mes: Nov
Reservas Iniciadas: 8,700
Reservas Pagadas: 2,958
Reservas Abandonadas: 5,742
Ingresos Generados (USD): $390,000

Mes: Dic
Reservas Iniciadas: 8,000
Reservas Pagadas: 2,720
Reservas Abandonadas: 5,280
Ingresos Generados (USD): $359,000

TOTAL
Reservas Iniciadas: 120,000
Reservas Pagadas: 40,800
Reservas Abandonadas: 79,200
Ingresos Generados (USD): $4,200,000

### INFORME 2: Desglose de Reservas por Canal de Compra (2024)

Fuente: Tabla de hechos hecho\_reserva del Data Warehouse

Canal: Web Desktop
Reservas Iniciadas: 52,000
Reservas Pagadas: 27,560
Reservas Abandonadas: 24,440
% Abandono: 47%

Canal: App Móvil
Reservas Iniciadas: 48,000
Reservas Pagadas: 12,480
Reservas Abandonadas: 35,520
% Abandono: 74%

Canal: Tablet
Reservas Iniciadas: 8,000
Reservas Pagadas: 3,520
Reservas Abandonadas: 4,480
% Abandono: 56%

Canal: Sucursal Física
Reservas Iniciadas: 12,000
Reservas Pagadas: 8,640
Reservas Abandonadas: 3,360
% Abandono: 28%

TOTAL
Reservas Iniciadas: 120,000
Reservas Pagadas: 52,200
Reservas Abandonadas: 67,800
% Abandono: 56.5%

### INFORME 3: Análisis de Cohortes de Clientes (Ventana 12 meses móviles)

Fuente: Tabla de hechos hechopago + dimensión dimcliente
Periodo analizado: Julio 2024 - Junio 2025
Universo: Clientes que realizaron al menos 1 compra en el periodo

Segmento de Cliente: Viajeros de Negocios
Total Clientes: 4,280
Clientes con 1 compra: 1,370
Clientes con ≥2 compras: 2,910
Clientes con ≥3 compras: 1,840
% Recompra: 68%

Segmento de Cliente: Familias Premium
Total Clientes: 2,150
Clientes con 1 compra: 1,032
Clientes con ≥2 compras: 1,118
Clientes con ≥3 compras: 580
% Recompra: 52%

Segmento de Cliente: Millennials Digitales
Total Clientes: 3,890
Clientes con 1 compra: 2,412
Clientes con ≥2 compras: 1,478
Clientes con ≥3 compras: 420
% Recompra: 38%

Segmento de Cliente: Estudiantes
Total Clientes: 1,720
Clientes con 1 compra: 1,307
Clientes con ≥2 compras: 413
Clientes con ≥3 compras: 86
% Recompra: 24%

Segmento de Cliente: Ocasional Promo
Total Clientes: 5,420
Clientes con 1 compra: 4,818
Clientes con ≥2 compras: 596
Clientes con ≥3 compras: 78
% Recompra: 11%

Segmento de Cliente: Otros
Total Clientes: 29,790
Clientes con 1 compra: 24,428
Clientes con ≥2 compras: 4,825
Clientes con ≥3 compras: 1,420
% Recompra: 16%

TOTAL
Total Clientes: 47,250
Clientes con 1 compra: 35,367
Clientes con ≥2 compras: 11,340
Clientes con ≥3 compras: 4,424
% Recompra: 24%

### INFORME 4: Análisis de Recompra por Antigüedad del Cliente

Fuente: Tabla de hechos hechopago + dimensión dimcliente
Periodo: Julio 2024 - Junio 2025

Antigüedad del Cliente: Menos de 1 año
Total Clientes: 18,200
Clientes que Recompraron: 2,548
% Recompra: 14%
LTV Promedio (USD): $180

Antigüedad del Cliente: 1 a 3 años
Total Clientes: 15,400
Clientes que Recompraron: 3,388
% Recompra: 22%
LTV Promedio (USD): $420

Antigüedad del Cliente: 3 a 5 años
Total Clientes: 8,900
Clientes que Recompraron: 3,382
% Recompra: 38%
LTV Promedio (USD): $890

Antigüedad del Cliente: Más de 5 años
Total Clientes: 4,750
Clientes que Recompraron: 2,280
% Recompra: 48%
LTV Promedio (USD): $1,640

TOTAL
Total Clientes: 47,250
Clientes que Recompraron: 11,598
% Recompra: 24.5%
LTV Promedio (USD): $283

### INFORME 5: Desglose por Tipo de Vuelo

Fuente: Tabla de hechos hecho\_reserva
Periodo: Año 2024

Tipo de Vuelo: Nacional
Reservas Iniciadas: 68,000
Reservas Pagadas: 34,680
Reservas Abandonadas: 33,320
% Abandono: 49%
Ticket Promedio (USD): $185

Tipo de Vuelo: Internacional
Reservas Iniciadas: 52,000
Reservas Pagadas: 15,080
Reservas Abandonadas: 36,920
% Abandono: 71%
Ticket Promedio (USD): $520

TOTAL
Reservas Iniciadas: 120,000
Reservas Pagadas: 49,760
Reservas Abandonadas: 70,240
% Abandono: 58.5%
Ticket Promedio (USD): $325

### INFORME 6: Benchmarks del Sector (Aerolíneas/Agencias Centroamérica 2024)

Fuente: Reportes IATA y Cámara de Turismo de Centroamérica

Indicador: Tasa de abandono de reserva
SkyTravel 2024: 58.5%
Benchmark Sector: 45%
Diferencia: +13.5 pp

Indicador: Tasa de recompra a 12 meses
SkyTravel 2024: 24%
Benchmark Sector: 35%
Diferencia: -11 pp

Indicador: Ticket promedio internacional
SkyTravel 2024: $520
Benchmark Sector: $480
Diferencia: +$40

Indicador: NPS (Net Promoter Score)
SkyTravel 2024: 32
Benchmark Sector: 45
Diferencia: -13 pts

Indicador: % Clientes con ≥3 compras/año
SkyTravel 2024: 9.4%
Benchmark Sector: 18%
Diferencia: -8.6 pp

### INFORME 7: Evolución Mensual de Ingresos y Reservas

Fuente: Sistema SaaS propio
Periodo: Enero 2024 - Diciembre 2025

Mes: Ene
Ingresos 2024 (USD): $412,000
Ingresos 2025 (USD): $398,000
Variación ingresos: -3.4%
Reservas 2024: 9,200
Reservas 2025: 8,900
Variación reservas: -3.3%

Mes: Feb
Ingresos 2024 (USD): $395,000
Ingresos 2025 (USD): $372,000
Variación ingresos: -5.8%
Reservas 2024: 8,800
Reservas 2025: 8,400
Variación reservas: -4.5%

Mes: Mar
Ingresos 2024 (USD): $470,000
Ingresos 2025 (USD): $445,000
Variación ingresos: -5.3%
Reservas 2024: 10,500
Reservas 2025: 9,900
Variación reservas: -5.7%

Mes: Abr
Ingresos 2024 (USD): $438,000
Ingresos 2025 (USD): $410,000
Variación ingresos: -6.4%
Reservas 2024: 9,800
Reservas 2025: 9,200
Variación reservas: -6.1%

Mes: May
Ingresos 2024 (USD): $456,000
Ingresos 2025 (USD): $428,000
Variación ingresos: -6.1%
Reservas 2024: 10,200
Reservas 2025: 9,600
Variación reservas: -5.9%

Mes: Jun
Ingresos 2024 (USD): $492,000
Ingresos 2025 (USD): $458,000
Variación ingresos: -6.9%
Reservas 2024: 11,000
Reservas 2025: 10,300
Variación reservas: -6.4%

Mes: Jul
Ingresos 2024 (USD): $558,000
Ingresos 2025 (USD): $512,000
Variación ingresos: -8.2%
Reservas 2024: 12,500
Reservas 2025: 11,600
Variación reservas: -7.2%

Mes: Ago
Ingresos 2024 (USD): $526,000
Ingresos 2025 (USD): $482,000
Variación ingresos: -8.4%
Reservas 2024: 11,800
Reservas 2025: 10,900
Variación reservas: -7.6%

Mes: Sep
Ingresos 2024 (USD): $426,000
Ingresos 2025 (USD): $388,000
Variación ingresos: -8.9%
Reservas 2024: 9,500
Reservas 2025: 8,700
Variación reservas: -8.4%

Mes: Oct
Ingresos 2024 (USD): $448,000
Ingresos 2025 (USD): $405,000
Variación ingresos: -9.6%
Reservas 2024: 10,000
Reservas 2025: 9,100
Variación reservas: -9.0%

Mes: Nov
Ingresos 2024 (USD): $390,000
Ingresos 2025 (USD): $352,000
Variación ingresos: -9.7%
Reservas 2024: 8,700
Reservas 2025: 7,900
Variación reservas: -9.2%

Mes: Dic
Ingresos 2024 (USD): $359,000
Ingresos 2025 (USD): $320,000
Variación ingresos: -10.9%
Reservas 2024: 8,000
Reservas 2025: 7,100
Variación reservas: -11.3%

TOTAL
Ingresos 2024 (USD): $5,370,000
Ingresos 2025 (USD): $4,970,000
Variación ingresos: -7.4%
Reservas 2024: 120,000
Reservas 2025: 111,600
Variación reservas: -7.0%

### INFORME 8: Top 5 Rutas por Volumen de Reservas (2024)

Fuente: Tabla de hechos hechoreserva + dimensión dimvuelo

Ruta: MGA → MIA
Ciudad Destino: Miami
Reservas Iniciadas: 18,500
Reservas Pagadas: 4,070
% Abandono: 78%
Ingresos Perdidos Est. (USD): $1,482,000

Ruta: MGA → GUA
Ciudad Destino: Guatemala
Reservas Iniciadas: 12,300
Reservas Pagadas: 3,567
% Abandono: 71%
Ingresos Perdidos Est. (USD): $456,000

Ruta: MGA → SJO
Ciudad Destino: San José
Reservas Iniciadas: 9,800
Reservas Pagadas: 3,430
% Abandono: 65%
Ingresos Perdidos Est. (USD): $328,000

Ruta: MGA → MEX
Ciudad Destino: Ciudad de México
Reservas Iniciadas: 8,200
Reservas Pagadas: 3,444
% Abandono: 58%
Ingresos Perdidos Est. (USD): $247,000

Ruta: MGA → PTY
Ciudad Destino: Panamá
Reservas Iniciadas: 6,500
Reservas Pagadas: 3,575
% Abandono: 45%
Ingresos Perdidos Est. (USD): $152,000

## FASE 1: ANÁLISIS PRELIMINAR

**Lo que los estudiantes pueden DESCUBRIR al examinar los datos**

Nota metodológica: como analista, examina los informes anteriores y descubre los problemas. NO se le dicen los problemas, los descubre él mismo a partir de los datos.

Hallazgos que emergen del análisis de los datos:

* Hallazgo 1: Tasa de abandono de reservas preocupante Del Informe 1, los estudiantes pueden calcular: Total de reservas iniciadas en 2024: 120,000 Total de reservas pagadas: 40,800 Total de reservas abandonadas: 79,200 Tasa de abandono = 79,200 / 120,000 = 66%
* Del Informe 6 (benchmark), el sector está en 45%. SkyTravel está 21 puntos porcentuales por encima del benchmark.
* Conclusión del analista: "Hay un problema serio de conversión en el proceso de reserva. De cada 3 clientes que inician una reserva, 2 no la completan."
* Hallazgo 2: El canal móvil es el principal responsable del abandono Del Informe 2, los estudiantes pueden observar: App Móvil: 74% de abandono (el peor canal) Web Desktop: 47% de abandono Sucursal Física: 28% de abandono (el mejor canal)
* Conclusión del analista: "El canal móvil concentra el mayor problema de abandono. Representa el 40% de las reservas iniciadas pero tiene la tasa de abandono más alta."
* Hallazgo 3: Vuelos internacionales abandonados 2.1x más que nacionales Del Informe 5: Vuelos internacionales: 71% de abandono Vuelos nacionales: 49% de abandono
* Conclusión del analista: "Los vuelos internacionales tienen un proceso de decisión más complejo y esto se refleja en mayor abandono."
* Hallazgo 4: Baja tasa de recompra Del Informe 3, los estudiantes pueden calcular: Total de clientes activos en 12 meses: 47,250 Clientes con ≥2 compras: 11,340 Tasa de recompra = 11,340 / 47,250 = 24%
* Del Informe 6 (benchmark), el sector está en 35%. SkyTravel está 11 puntos por debajo.
* Conclusión del analista: "Solo 1 de cada 4 clientes regresa a comprar. Estamos perdiendo la oportunidad de generar ingresos recurrentes."
* Hallazgo 5: Los clientes que compran con promoción NO son leales Del Informe 3, segmento "Ocasional Promo": 5,420 clientes, pero solo 11% de recompra (el más bajo) Representan 11.5% de la base pero aportan poco a ingresos recurrentes
* Conclusión del analista: "Las promociones atraen clientes pero no los fidelizan. Hay un problema de calidad en la adquisición."
* Hallazgo 6: Caída sostenida de ingresos en 2025 Del Informe 7: Ingresos 2024: $5,370,000 Ingresos 2025: $4,970,000 Caída de $400,000 (-7.4%) La caída se acelera mes a mes (de -3.4% en enero a -10.9% en diciembre)
* Conclusión del analista: "La tendencia es negativa y se está acelerando. Si no se interviene, la proyección para 2026 es preocupante."
* Hallazgo 7: La ruta MGA→MIA es la más crítica Del Informe 8: Ruta MGA→MIA: 78% de abandono Ingresos perdidos estimados: $1,482,000 Representa el 33% del impacto total del abandono

Conclusión del analista: "Hay una ruta específica que concentra un tercio del problema. Una intervención focalizada aquí tendría alto impacto."

## FASE 2: ANÁLISIS PRELIMINAR

### PASO 1: OBJETIVO ESTRATÉGICO (GOAL)

**Sesión de trabajo con el director Comercial de SkyTravel**

*"Analizando los informes que nos entregaron, encontramos varios problemas graves. El más urgente es que estamos perdiendo 2 de cada 3 reservas que se inician, y eso nos cuesta casi medio millón de dólares al año. Además, los clientes que compran una vez no regresan. Si seguimos así, en 2026 podríamos perder una sucursal. Necesitamos que nos ayuden a entender qué está pasando y cómo solucionarlo."*
— Director Comercial, SkyTravel Nicaragua

Plantilla completada:

**OBJETIVO ESTRATÉGICO (GOAL)**

Negocio/Organización: SkyTravel Nicaragua S.A.

Objetivo estratégico:
"Incrementar los ingresos anuales en un 15% durante el año 2026, mediante la reducción del abandono de reservas online y el aumento de la recompra de clientes existentes."

Justificación: La empresa enfrenta dos problemas críticos:
(1) El 68% de las reservas iniciadas no se completan, generando pérdidas estimadas en $420,000 anuales.
(2) Solo el 22% de los clientes realizan una segunda compra en los 12 meses siguientes, cuando el benchmark del sector es del 35%.

Responsable: Director Comercial

Consecuencia de NO resolverlo:

* Pérdida proyectada de $630,000 en 2026
* Reducción de cuota de mercado del 18% al 12%
* Riesgo de cierre de 1 sucursal física

Nota pedagógica clave: Observa cómo el objetivo estratégico ahora se justifica con datos concretos de los informes (66% vs 45% benchmark, caída del 7.4% en 2025). No es un número inventado, es un dato que emerge del análisis de los informes operativos.

### PASO 2: PREGUNTAS ANALÍTICAS (QUESTION)

REGLA CRÍTICA: Preguntas ABIERTAS de negocio (sin anticipar métodos estadísticos)

El equipo de analítica, junto con el director Comercial y el Gerente de TI, formula preguntas basadas en los hallazgos descubiertos en la Fase 0.5.

* Pregunta 1 (estado actual - abandono):

"¿En qué momento exacto del proceso de reserva online los usuarios abandonan antes de completar el pago?"

* Pregunta 2 (segmentación – abandono: "¿Existen diferencias en la tasa de abandono según el tipo de vuelo (nacional vs internacional), la ruta específica el dispositivo usado (web vs app móvil)?"
* Pregunta 3 (relación entre factores - recompra): "¿El comportamiento de compra inicial del cliente (precio pagado, ruta, antigüedad) está relacionado con la probabilidad de que realice una segunda compra?"
* Pregunta 4 (momento/tiempo - recompra):"¿Cuánto tiempo transcurre, en promedio, entre la primera y la segunda compra de los clientes que sí regresan?"
* Pregunta 5 (causa raíz - ambos problemas): "¿Los clientes que abandonan la reserva y los que no regresan comparten características comunes (perfil, canal de compra, tipo de vuelo)?"

Verificación de rigor metodológico

Verificación: ¿Las preguntas son abiertas y de negocio?
Resultado: SÍ

Verificación: ¿Permiten derivar múltiplesCubren dimensiones clave (tiempo, segmento, causa)?
Resultado: SÍ

Verificación: ¿Permiten derivar múltiples KPIs?
Resultado: SÍ

Verificación: ¿Se basan en hallazgos de los datos iniciales?
Resultado: SÍ

Verificación: ¿Anticipan métodos estadísticos?
Resultado: NO (correcto)

### PASO 3: DEFINICIÓN DE KPIs (METRIC)

A partir de las preguntas, se definen 2 KPIs principales (uno por cada problema descubierto en los datos).

**KPI #1: Tasa de Abandono de Reserva (TAR)**

**Responde a:** Preguntas 1 y 2

Nombre: Tasa de Abandono de Reserva (TAR)

Fórmula:

TAR = $\frac{No de reservas que no completaron pago en 24h}{Total de reservas iniciadas en el periodo}\*100$

TAR = (N.º de reservas que no completaron pago en 24 h / Total de reservas iniciadas en el periodo) × 100

Unidad de medida: Porcentaje %

Frecuencia de cálculo: Semanal (cada lunes)

Fuente de datos:

* Tabla de hechos: hecho\_reserva
* Tabla de dimensiones: dim\_cliente, dim\_vuelo, dim\_canal , dim\_tiempo

Variables que lo componen:

* id\_reserva (PK, entero)
* estado\_reserva (categórica: iniciada/pagada/abandonada)
* fecha\_inicio\_reserva (fecha/hora)
* fecha\_completado\_pago (fecha/hora, nullable)
* tipo\_vuelo (categórica: nacional/internacional)
* canal\_compra (categórica: web/app/sucursal)
* dispositivo (categórica: desktop/móvil/tablet)
* ruta (categórica: código IATA origen-destino)
* precio\_cotizado (decimal, USD)

Reglas de negocio:

* Una reserva se considera "abandonada" si pasan 24 horas

desde su creación sin que se registre el pago.

* Se excluyen reservas canceladas explícitamente por el

usuario (esas van a otro indicador).

**KPI #2: Tasa de Recompra a 12 Meses (TRM)**

**Responde a:** Preguntas 3, 4 y 5

Fórmula:

**TRM** = $\frac{No de clientes compras>2 en 12m}{No de clientes compras>1 en 12m}\*100$

TRM = (N.º de clientes con más de 2 compras en 12 meses / N.º de clientes con más de 1 compra en 12 meses) × 100

Unidad de medida: Porcentaje

Frecuencia de cálculo: Mensual (primer día hábil del mes)

Fuente de datos:

* Tabla de hechos: hecho\_reserva, hecho\_pago
* Tabla de dimensiones: dim\_cliente, dim\_tiempo

Variables que lo componen:

* id\_cliente (PK, entero)
* fecha\_primera\_compra (fecha)
* fecha\_ultima\_compra (fecha)
* total\_compras\_12m (entero)
* monto\_total\_12m (decimal, USD)
* ruta\_mas\_frecuente (categórica)
* antiguedad\_cliente\_dias (entero)
* segmento\_cliente (categórica: nuevo/recurrente/vip)

Reglas de negocio:

* "Cliente activo" = aquel que ha completado al menos 1

pago en la ventana de 12 meses móviles.

* Se cuentan solo compras pagadas, no reservas canceladas.

### PASO 4: VALIDACIÓN CIENTÍFICA CON CRITERIO SMART

**Validación del KPI #1: Tasa de Abandono de Reserva (TAR)**

[S] Specific: [✓] Sí -

La fórmula tiene numerador (reservas no pagadas en 24h) y denominador (total de reservas iniciadas) claramente definidos. Dos analistas independientes obtendrían el mismo resultado con los mismos datos

[M] Measurable: [✓] Sí

Los datos existen en el sistema SaaS propio de SkyTravel. Cada reserva tiene estado, fecha de inicio y fecha de pago. Se puede calcular automáticamente.

[A] Achievable: [✓] Sí

No requiere nueva infraestructura. Solo se necesita acceso de lectura a la tabla hecho\_reserva del DW. Costo de implementación: 0 (datos ya disponibles).

[R] Relevant: [✓] Sí

Este KPI ataca directamente el problema de negocio: el director Comercial identificó el abandono como la principal fuga de ingresos ($420,000/año). Reducirlo tiene impacto financiero directo y medible.

[T] Time-bound: [✓] Sí

Se calcula semanalmente (cada lunes). Permite detectar tendencias semana a semana y evaluar intervenciones en ciclos cortos (ej. cambios en el checkout).

**Resultado final: [✓] KPI APROBADO**

**Validación del KPI #2: Tasa de Recompra a 12 Meses (TRM)**

[S] Specific: [✓] Sí

La fórmula distingue claramente entre clientes con ≥2 compras y clientes con al menos 1 compra en 12 meses. La ventana temporal (12 meses móviles) está definida.

[M] Measurable: [✓] Sí

Los datos de compras por cliente están en el DW. Se puede calcular con una consulta SQL agregada.

[A] Achievable: [✓] Sí

Requiere datos históricos de 12 meses, los cuales ya están disponibles en el Data Warehouse.

[R] Relevant: [✓] Sí

Ataca el segundo problema de negocio: la baja retención (22% vs benchmark de 35%). Mejorar este KPI tiene impacto directo en ingresos recurrentes y LTV.

[T] Time-bound: [✓] Sí

Se calcula mensualmente. Permite monitorear el efecto de campañas de fidelización mes a mes

**Resultado final: [✓] KPI APROBADO**

### PASO 5: LÍNEA BASE, META Y UMBRAL DE ALERTA

**Contexto del KPI #1: Tasa de Abandono de Reserva (TAR)**

**CONTEXTO DEL KPI: Tasa de Abandono de Reserva (TAR)**

Línea Base: 68%
Periodo de referencia: Enero-Junio 2025
Fuente del histórico: Reportes del sistema SaaS propio
Dato verificado: De 60,000 reservas iniciadas en 6 meses, 40,800 no completaron el pago.

Meta: Reducir a 50% en 6 meses (al cierre de Q1-2026)
Impacto esperado: Recuperar ~$180,000 en ingresos

Umbral de alerta: 60%
(Si la TAR sube de 60%, se activa protocolo de revisión del proceso de checkout)

Acción si se supera el umbral:

* Revisión urgente del flujo de pago (UX/UI)
* Análisis de errores técnicos en pasarela de pago
* Activar equipo de marketing con email de recuperación
* Intervención del modelo de minería de datos para identificar perfiles de alto riesgo de abandono

**Contexto del KPI #2: Tasa de Recompra a 12 Meses (TRM)**

**CONTEXTO DEL KPI: Tasa de Recompra a 12 Meses (TRM)**

Línea Base: 22%
Periodo de referencia: Julio 2024 - Junio 2025
Fuente del histórico: DW de SkyTravel
Dato verificado: De 45,000 clientes activos, solo 9,900 realizaron una segunda compra en 12 meses.

Meta: Aumentar a 30% en 12 meses (al cierre de 2026)
Impacto esperado: Incremento de $240,000 en ingresos recurrentes

Umbral de alerta: 18%
(Si la TRM baja de 18%, se activa revisión de estrategia de fidelización)

Acción si se supera el umbral:

* Revisión del programa de millas/puntos
* Análisis de satisfacción post-viaje (encuestas NPS)
* Campañas segmentadas de email marketing
* Intervención del modelo de clustering para identificar perfiles de clientes con baja probabilidad de recompra

**APLICACIÓN DE LAS PRUEBAS DE VALIDACION**

**Prueba 1: El "¿Y qué?" (The "So What?" Test)**

**Para el KPI #1 (TAR):**

* *Analista:* "Director, nuestra Tasa de Abandono de Reserva está en 68%."
* *Director Comercial:* "¿Y qué? ¿Eso es bueno o malo?"
* *Analista:* "Es malo. Nuestra meta es 50%, y cada punto porcentual que bajemos representa $12,000 en ingresos recuperados. Además, estamos 18 puntos por encima del benchmark de la industria (50%)."
* *Director:* "Entendido. ¿Qué vamos a hacer?"
* *Resultado:* **PASA la prueba.** El KPI tiene contexto comparativo y detona acción.

**Para el KPI #2 (TRM):**

* *Analista:* "Gerente, nuestra Tasa de Recompra a 12 meses está en 22%."
* *Gerente de Marketing:* "¿Y qué?"
* *Analista:* "Es preocupante. El benchmark del sector es 35%, y estamos perdiendo aproximadamente $240,000 anuales en ingresos recurrentes que podríamos capturar si llegáramos al 30%."
* *Resultado:* **PASA la prueba.**

**Prueba 2: La Prueba de la Inacción**

**Para el KPI #1 (TAR):**

* Si la TAR sube a 65% (supera el umbral de 60%)...
* ¿Qué pasa? → Se activa automáticamente: revisión de UX del checkout + análisis técnico de pasarela de pago + campaña de email de recuperación.
* *Resultado:* **PASA la prueba.** Hay protocolo de acción definido.

**Para el KPI #2 (TRM):**

* Si la TRM baja a 17% (supera el umbral de 18%)...
* ¿Qué pasa? → Se activa: revisión del programa de fidelización + análisis NPS + campañas segmentadas.
* *Resultado:* **PASA la prueba.**

Verificación de los 5 requisitos mínimos:

Requisito: 1. Valor Actual
KPI #1 (TAR): 62%
KPI #2 (TRM): 26%

Requisito: 2. Contexto Comparativo
KPI #1 (TAR): Meta: 50%, Línea Base: 66%, Benchmark: 45%
KPI #2 (TRM): Meta: 30%, Línea Base: 24%, Benchmark: 35%

Requisito: 5. Accquisito: 3. Direccionalidad
KPI #1 (TAR): -4% vs semana anterior (mejorando)
KPI #2 (TRM): +2% vs mes anterior

Requisito: 4. Estado / Semáforo
KPI #1 (TAR): Rojo (supera umbral 60%)
KPI #2 (TRM): Amarillo (en progreso)

Requisito: 5. Accionabilidad
KPI #1 (TAR): Revisar checkout mobile
KPI #2 (TRM): Mantener campañas