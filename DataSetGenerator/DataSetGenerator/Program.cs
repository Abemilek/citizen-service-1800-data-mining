// ============================================================
// SERVICIO CIUDADANO 1800 - GENERADOR DE DATOS + MINI ETL
// Caso 15 - Resolución y recontacto en un centro de atención
// Basado en el ejemplo del profesor (generador de semilla)
//
// FLUJO QUE EJECUTA ESTE PROGRAMA (se imprime en consola):
//   1. GENERAR   -> interacciones calibradas con los Informes 1-4 del expediente
//   2. CONTAMINAR-> inyecta los defectos de calidad de la semilla (360 registros)
//   3. MINI ETL  -> exporta data/v0_crudo.csv   (dataset SUCIO, evidencia)
//   4. MINI ETL  -> limpia: deduplica, estandariza etiquetas y valida rangos
//   5. MINI ETL  -> exporta data/v1_limpio.csv  (dataset LIMPIO, evidencia)
//   6. CARGA SQL -> zona de preparación (stg_interaccion_cruda) + Data Warehouse
//   7. KPI       -> calcula los 3 indicadores del caso con los datos limpios
//
// Configuración por variables de entorno (o editar los valores por defecto):
//   N_REGISTROS (100000) | SEMILLA (1800) | DATA_DIR (data)
//   DB_HOST, DB_PORT, DB_NAME, DB_USER, DB_PASSWORD
//   SOLO_CSV=1 -> genera los .csv pero no toca SQL Server
// ============================================================

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;

namespace ServicioCiudadano1800.Generador
{
    class Program
    {
        // ============================================================
        // CONFIGURACIÓN PRINCIPAL
        // ============================================================

        // Cantidad total de interacciones a generar (incluye duplicados)
        static int nRegistros = LeerEntero("N_REGISTROS", 100000);

        // Semilla fija: mismos datos en cada corrida (reproducible y auditable)
        static int semilla = LeerEntero("SEMILLA", 1800);

        // Carpeta de evidencia del MINI ETL (se crea en la raíz del proyecto)
        static string carpetaDatos = Environment.GetEnvironmentVariable("DATA_DIR") ?? "data";

        // Solo generar CSV, sin tocar SQL Server
        static bool soloCsv = (Environment.GetEnvironmentVariable("SOLO_CSV") ?? "0") == "1";

        static string connectionString = ConstruirCadenaConexion();

        // ============================================================
        // CONSTANTES BASADAS EN LOS HALLAZGOS DEL CASO 15
        // Formato: nombre, registros, resultado_conocido, resultado_1, suma_duracion_seg
        // (Informes 2, 3 y 4 del expediente; los "(sin dato)" y COBRO/QUEJA se unificaron)
        // ============================================================

        static readonly (string Nombre, int Registros, int Conocidos, int Unos, double SumaDuracion)[] InfoCanal =
        {
            ("Teléfono",   91, 89, 33, 86375),
            ("Chat",       96, 95, 38, 98744),
            ("Correo",     83, 83, 33, 76313),
            ("Red social", 81, 79, 37, 69426),
        };

        static readonly (string Nombre, int Registros, int Conocidos, int Unos, double SumaDuracion)[] InfoMotivo =
        {
            ("Consulta",  60, 59, 18, 57332),
            ("Falla",     80, 80, 39, 80873),
            ("Cobro",     72, 70, 26, 67280),   // incluye COBRO (2 registros)
            ("Solicitud", 67, 66, 27, 65198),
            ("Queja",     81, 79, 35, 70800),   // incluye QUEJA (2 registros)
        };

        static readonly (string Nombre, int Registros, int Conocidos, int Unos, double SumaDuracion)[] InfoCola =
        {
            ("Facturación",  68, 68, 32, 65170),
            ("Soporte",      68, 64, 22, 61825),
            ("Información",  95, 93, 40, 91321),
            ("Reclamos",     54, 54, 20, 51697),
            ("Trámites",     75, 75, 31, 71470),
        };

        // Informe 1: volumen mensual (los 360 registros del dataset v0)
        static readonly (string Mes, int Registros, int Conocidos, int Unos)[] VolumenMensual =
        {
            ("2025-01", 12, 12,  4), ("2025-02", 18, 17,  3), ("2025-03", 17, 16,  5),
            ("2025-04", 11, 11,  5), ("2025-05", 18, 18,  6), ("2025-06", 23, 22, 11),
            ("2025-07", 21, 20,  9), ("2025-08", 20, 20,  7), ("2025-09", 24, 24, 11),
            ("2025-10", 28, 28, 14), ("2025-11", 24, 24, 13), ("2025-12", 24, 23, 12),
            ("2026-01", 15, 15,  9), ("2026-02", 20, 20,  6), ("2026-03", 20, 20,  2),
            ("2026-04", 20, 20,  8), ("2026-05", 24, 23, 14), ("2026-06", 21, 21,  6),
        };

        // Afinidad motivo x cola (el expediente no trae el cruce; el IPF ajusta los totales)
        static readonly Dictionary<string, Dictionary<string, double>> AfinidadMotivoCola = new()
        {
            ["Consulta"] = new() { ["Información"] = 1.0, ["Trámites"] = 0.2, ["Facturación"] = 0.15, ["Soporte"] = 0.1, ["Reclamos"] = 0.02 },
            ["Falla"] = new() { ["Soporte"] = 1.0, ["Información"] = 0.1, ["Reclamos"] = 0.1, ["Trámites"] = 0.05, ["Facturación"] = 0.03 },
            ["Cobro"] = new() { ["Facturación"] = 1.0, ["Información"] = 0.15, ["Reclamos"] = 0.1, ["Trámites"] = 0.1, ["Soporte"] = 0.05 },
            ["Solicitud"] = new() { ["Trámites"] = 1.0, ["Información"] = 0.3, ["Soporte"] = 0.2, ["Facturación"] = 0.1, ["Reclamos"] = 0.02 },
            ["Queja"] = new() { ["Reclamos"] = 1.0, ["Información"] = 0.15, ["Facturación"] = 0.1, ["Soporte"] = 0.1, ["Trámites"] = 0.05 },
        };

        // Segmentos de usuario (supuesto de diseño documentado en el informe)
        static readonly Dictionary<string, double> PesoTipoUsuario = new()
        {
            ["Recurrente"] = 0.40, ["Nuevo"] = 0.30, ["Adulto mayor"] = 0.18, ["Empresa"] = 0.12,
        };

        static readonly Dictionary<string, double> LambdaCasosPrevios = new()
        {
            ["Recurrente"] = 1.4, ["Empresa"] = 1.8, ["Adulto mayor"] = 0.9, ["Nuevo"] = 0.3,
        };

        static readonly Dictionary<string, double> LambdaTransferencias = new()
        {
            ["Consulta"] = 0.25, ["Falla"] = 0.85, ["Cobro"] = 0.5, ["Solicitud"] = 0.55, ["Queja"] = 0.75,
        };

        static readonly Dictionary<string, double> EsperaMediaCanal = new()
        {
            ["Teléfono"] = 240, ["Chat"] = 150, ["Correo"] = 200, ["Red social"] = 180,
        };

        static readonly Dictionary<string, double> EsperaMultTurno = new()
        {
            ["AM"] = 1.0, ["PM"] = 1.1, ["Nocturno"] = 0.7, ["Fin de semana"] = 0.9,
        };

        static readonly Dictionary<string, double> PesoSistemaOrigen = new()
        {
            ["ACD"] = 0.60, ["CRM"] = 0.35, ["Ticketing"] = 0.03, ["Calidad"] = 0.02,
        };

        static readonly Dictionary<string, double> PesoSistemaOrigenFalla = new()
        {
            ["ACD"] = 0.30, ["CRM"] = 0.25, ["Ticketing"] = 0.43, ["Calidad"] = 0.02,
        };

        // Desfase de carga (días) según el sistema de origen (oportunidad del dato)
        static readonly Dictionary<string, int[]> DesfaseCarga = new()
        {
            ["ACD"] = new[] { 1, 1 }, ["CRM"] = new[] { 0, 0 }, ["Ticketing"] = new[] { 1, 7 }, ["Calidad"] = new[] { 7, 30 },
        };

        // Pesos de día de la semana (lunes = 0 ... domingo = 6)
        static readonly double[] PesoDiaSemana = { 1.0, 1.0, 1.0, 1.0, 1.0, 0.35, 0.2 };

        // Pesos por hora del día (más carga en horario laboral)
        static readonly double[] PesoHoraLaborable =
        {
            0.4, 0.3, 0.2, 0.2, 0.3, 0.6, 2, 4, 6, 7, 7, 7, 6, 6, 6, 5.5, 5, 4.5, 3, 2.5, 2, 1.5, 1, 0.6,
        };

        static readonly double[] PesoHoraFinde =
        {
            0.3, 0.2, 0.2, 0.2, 0.2, 0.4, 1, 2, 3, 4, 4, 4, 3.5, 3.5, 3.5, 3, 3, 2.5, 2, 1.5, 1.2, 1, 0.7, 0.4,
        };

        // Efectos operativos que empujan el recontacto (se calibran con el modelo logístico)
        const double EfectoTransferencia = 0.30;
        const double EfectoEsperaPorSeg = 0.0012;
        const double EfectoCasosPrevios = 0.12;
        static readonly Dictionary<string, double> EfectoTipoUsuario = new()
        {
            ["Nuevo"] = 0.15, ["Adulto mayor"] = 0.20, ["Empresa"] = -0.10, ["Recurrente"] = 0.0,
        };
        static readonly Dictionary<string, double> EfectoTurno = new()
        {
            ["AM"] = 0.0, ["PM"] = 0.03, ["Nocturno"] = 0.08, ["Fin de semana"] = 0.05,
        };

        // Duración: parámetros del generador log-normal
        const int DuracionMin = 30;
        const int DuracionMax = 1800;
        const double DuracionSigma = 0.55;
        const double DuracionPorTransferencia = 0.10;
        static readonly Dictionary<string, double> DuracionMultTipo = new()
        {
            ["Adulto mayor"] = 1.1, ["Nuevo"] = 1.05, ["Recurrente"] = 1.0, ["Empresa"] = 0.95,
        };
        const int UmbralInteraccionLarga = 1200;

        // Probabilidad de grabación autorizada y defectos de calidad de la semilla (360 registros)
        const double ProbGrabacionAutorizada = 0.88;
        const double PctDuplicados = 1.0;                 // supuesto de diseño (el expediente no lo cuantifica)
        const double PctCanalVacio = 9.0 / 360 * 100;     // real: 9 de 360 "(sin dato)" en canal
        const double PctMotivoMayuscula = 4.0 / 360 * 100; // real: COBRO x2 y QUEJA x2
        const double PctRecontactoVacio = 6.0 / 360 * 100; // real: 6 de 360 sin consolidar
        const double PctFueraDeRango = 0.8;               // supuesto de diseño
        const double PctGrabacionInconsistente = 1.5;     // supuesto de diseño

        // Periodo del expediente (Informe 1: 2025-01 a 2026-06)
        static readonly DateTime PeriodoInicio = new(2025, 1, 1);
        static readonly DateTime PeriodoFin = new(2026, 6, 30);
        const int VentanaRecontactoDias = 7;

        // ============================================================
        // PUNTO DE ENTRADA PRINCIPAL
        // ============================================================
        static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            try { Console.OutputEncoding = Encoding.UTF8; } catch { /* consola sin UTF-8 */ }

            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  SERVICIO CIUDADANO 1800 - GENERADOR + MINI ETL (CASO 15)   ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            Console.WriteLine($"\n📊 Configuración:");
            Console.WriteLine($"   • Interacciones a generar: {nRegistros:N0}  (semilla de datos: 360 registros)");
            Console.WriteLine($"   • Semilla aleatoria fija:  {semilla}");
            Console.WriteLine($"   • Periodo:                 {PeriodoInicio:yyyy-MM-dd} a {PeriodoFin:yyyy-MM-dd}");
            Console.WriteLine($"   • Carpeta de evidencia:    {Path.GetFullPath(carpetaDatos)}");
            Console.WriteLine();

            // ---------- PASO 1 y 2: generar datos limpios + inyectar defectos ----------
            Console.WriteLine("── PASO 1: GENERANDO interacciones calibradas con los Informes 1-4 ──");
            int nDuplicados = (int)Math.Round(PctDuplicados * nRegistros / 100.0);
            var generacion = GenerarInteracciones(nRegistros - nDuplicados, semilla);
            var crudas = InyectarDefectos(generacion.Filas, nRegistros, semilla, nDuplicados);
            crudas = crudas.OrderBy(f => f.FilaOrigen).ToList();

            Console.WriteLine($"   ✓ Interacciones únicas: {generacion.Filas.Count:N0}");
            Console.WriteLine($"   ✓ Con defectos inyectados: {crudas.Count:N0}");
            Console.WriteLine($"   • Error calibración recontacto: {generacion.ErrorRecontacto:F4} | duración: {generacion.ErrorDuracion:F4}");

            // ---------- PASO 3: MINI ETL -> CSV crudo (evidencia del ANTES) ----------
            Directory.CreateDirectory(carpetaDatos);
            string rutaCrudo = Path.Combine(carpetaDatos, "v0_crudo.csv");
            EscribirCsv(rutaCrudo, crudas);
            Console.WriteLine($"\n── PASO 2: MINI ETL (evidencia) -> {rutaCrudo} ──");
            Console.WriteLine($"   ✓ v0_crudo.csv   : {crudas.Count:N0} registros sucios exportados");

            // ---------- PASO 4: MINI ETL de limpieza ----------
            var limpieza = Limpiar(crudas);

            // ---------- PASO 5: MINI ETL -> CSV limpio (evidencia del DESPUÉS) ----------
            string rutaLimpio = Path.Combine(carpetaDatos, "v1_limpio.csv");
            EscribirCsv(rutaLimpio, limpieza.Limpias);
            Console.WriteLine($"   ✓ v1_limpio.csv  : {limpieza.Limpias.Count:N0} registros limpios exportados");
            Console.WriteLine("   NOTA: el MINI ETL es el que produce ambos .csv; compare las filas de");
            Console.WriteLine("         v0_crudo.csv contra v1_limpio.csv para auditar la limpieza.");

            Limpieza.ImprimirResumen(crudas.Count, limpieza);

            // ---------- PASO 6: cargar SQL Server ----------
            if (soloCsv)
            {
                Console.WriteLine("\n(SOLO_CSV=1: no se toca SQL Server)");
            }
            else
            {
                try
                {
                    Console.WriteLine("\n── PASO 3: CARGANDO SQL Server (staging + Data Warehouse) ──");
                    CargarSqlServer(crudas, limpieza.Limpias);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n⚠ No se pudo cargar SQL Server: {ex.Message}");
                    Console.WriteLine("  Los CSV de evidencia quedaron generados. Ejecuta 'docker compose up --build'");
                    Console.WriteLine("  o crea el esquema con 'sql/01_datawarehouse.sql' antes de reintentar.");
                }
            }

            // ---------- PASO 7: KPI ----------
            Console.WriteLine("\n── PASO 4: KPI DEL CASO (calculados sobre los datos LIMPIOS) ──");
            ImprimirKpis(limpieza.Limpias);

            Console.WriteLine("\n✅ Proceso terminado.");
        }

        // ============================================================
        // GENERADOR (datos limpios calibrados con los informes)
        // ============================================================
        static ResultadoGeneracion GenerarInteracciones(int n, int semillaGen)
        {
            var rng = new Muestreo(semillaGen);
            var meses = VolumenMensual.Select(m => m.Mes).ToArray();

            // 1) Cuántas interacciones caen en cada mes (proporción del Informe 1)
            long totalInforme = VolumenMensual.Sum(m => (long)m.Registros);
            var cuotas = VolumenMensual.Select(m => m.Registros * (double)n / totalInforme).ToArray();
            var cuentas = cuotas.Select(c => (int)Math.Floor(c)).ToArray();
            int resto = n - cuentas.Sum();
            var ordenResto = Enumerable.Range(0, meses.Length).OrderByDescending(i => cuotas[i] - cuentas[i]).ToArray();
            for (int k = 0; k < resto && k < ordenResto.Length; k++) cuentas[ordenResto[k]]++;

            // 2) Fechas y horas
            var fechas = new List<DateTime>(n);
            var codigoMes = new List<int>(n);
            var horas = new List<int>(n);
            for (int mi = 0; mi < meses.Length; mi++)
            {
                var partes = meses[mi].Split('-');
                int anio = int.Parse(partes[0]), mes = int.Parse(partes[1]);
                var dias = new List<DateTime>();
                for (var d = new DateTime(anio, mes, 1); d.Month == mes; d = d.AddDays(1))
                    if (d >= PeriodoInicio && d <= PeriodoFin) dias.Add(d);
                var pesosDia = dias.Select(d => PesoDiaSemana[DiaSemanaLunes0(d)]).ToArray();
                for (int k = 0; k < cuentas[mi]; k++)
                {
                    var dia = dias[rng.Elegir(pesosDia)];
                    fechas.Add(dia);
                    codigoMes.Add(mi);
                    horas.Add(rng.Elegir(DiaSemanaLunes0(dia) >= 5 ? PesoHoraFinde : PesoHoraLaborable));
                }
            }
            var orden = Enumerable.Range(0, fechas.Count).OrderBy(i => fechas[i]).ThenBy(i => horas[i]).ToArray();
            fechas = orden.Select(i => fechas[i]).ToList();
            horas = orden.Select(i => horas[i]).ToList();
            var mesCod = orden.Select(i => codigoMes[i]).ToArray();
            n = fechas.Count;

            // 3) Dimensiones y medidas operativas
            var canales = InfoCanal.Select(x => x.Nombre).ToArray();
            var motivos = InfoMotivo.Select(x => x.Nombre).ToArray();
            var colas = InfoCola.Select(x => x.Nombre).ToArray();
            var tipos = PesoTipoUsuario.Keys.ToArray();

            var pesosCanal = InfoCanal.Select(x => (double)x.Registros).ToArray();
            var conjunta = Calibracion.IpfMotivoCola(
                AfinidadMotivoCola, motivos, colas,
                InfoMotivo.Select(x => (double)x.Registros).ToArray(),
                InfoCola.Select(x => (double)x.Registros).ToArray());
            var acumulada = new double[motivos.Length * colas.Length];
            for (int i = 0; i < motivos.Length; i++)
                for (int j = 0; j < colas.Length; j++) acumulada[i * colas.Length + j] = conjunta[i, j];
            var pesosTipo = tipos.Select(t => PesoTipoUsuario[t]).ToArray();
            var sistemas = PesoSistemaOrigen.Keys.ToArray();
            var pesosSistema = sistemas.Select(s => PesoSistemaOrigen[s]).ToArray();
            var pesosSistemaFalla = sistemas.Select(s => PesoSistemaOrigenFalla.GetValueOrDefault(s, 0.0)).ToArray();

            var codCanal = new int[n]; var codMotivo = new int[n]; var codCola = new int[n]; var codTipo = new int[n];
            var turno = new string[n]; var sistema = new string[n];
            var transferencias = new int[n]; var casosPrevios = new int[n]; var espera = new int[n];

            for (int i = 0; i < n; i++)
            {
                codCanal[i] = rng.Elegir(pesosCanal);
                int celda = rng.Elegir(acumulada);
                codMotivo[i] = celda / colas.Length;
                codCola[i] = celda % colas.Length;
                codTipo[i] = rng.Elegir(pesosTipo);

                int h = horas[i];
                bool finde = DiaSemanaLunes0(fechas[i]) >= 5;
                turno[i] = finde ? "Fin de semana" : (h >= 6 && h < 12 ? "AM" : (h >= 12 && h < 18 ? "PM" : "Nocturno"));

                string motivo = motivos[codMotivo[i]], tipo = tipos[codTipo[i]], canal = canales[codCanal[i]];
                transferencias[i] = Math.Min(rng.Poisson(LambdaTransferencias.GetValueOrDefault(motivo, 0.5)), 4);
                casosPrevios[i] = Math.Min(rng.Poisson(LambdaCasosPrevios.GetValueOrDefault(tipo, 0.5)), 8);
                double media = EsperaMediaCanal.GetValueOrDefault(canal, 200) * EsperaMultTurno.GetValueOrDefault(turno[i], 1.0);
                espera[i] = (int)Math.Min(Math.Max(Math.Round(rng.Gamma2(media / 2.0)), 0), 900);

                var pesosSis = motivo == "Falla" ? pesosSistemaFalla : pesosSistema;
                sistema[i] = sistemas[rng.Elegir(pesosSis)];
            }

            // 4) Duración calibrada contra las medias por canal/motivo/cola del informe
            var baseDuracion = new double[n];
            for (int i = 0; i < n; i++)
            {
                baseDuracion[i] = Math.Exp(rng.Normal() * DuracionSigma)
                                  * (1.0 + DuracionPorTransferencia * transferencias[i])
                                  * DuracionMultTipo.GetValueOrDefault(tipos[codTipo[i]], 1.0);
            }
            var dimsDuracion = new List<Calibracion.Dimension>
            {
                new("canal", codCanal, InfoCanal.Select(x => x.SumaDuracion / x.Registros).ToArray()),
                new("motivo", codMotivo, InfoMotivo.Select(x => x.SumaDuracion / x.Registros).ToArray()),
                new("cola", codCola, InfoCola.Select(x => x.SumaDuracion / x.Registros).ToArray()),
            };
            var duracion = Calibracion.CalibrarDuracion(baseDuracion, dimsDuracion, DuracionMin, DuracionMax, out double errorDuracion);

            // 5) Recontacto calibrado contra las tasas por canal/motivo/cola/mes del informe
            var offset = new double[n];
            for (int i = 0; i < n; i++)
            {
                offset[i] = EfectoTransferencia * transferencias[i]
                          + EfectoEsperaPorSeg * (espera[i] - 200)
                          + EfectoCasosPrevios * casosPrevios[i]
                          + EfectoTipoUsuario.GetValueOrDefault(tipos[codTipo[i]], 0.0)
                          + EfectoTurno.GetValueOrDefault(turno[i], 0.0);
            }
            double global = InfoCanal.Sum(x => (double)x.Unos) / InfoCanal.Sum(x => (double)x.Conocidos);
            double suavizadoK = 60;
            var tasaMes = new Dictionary<string, double>();
            foreach (var m in VolumenMensual)
            {
                double observada = m.Unos / (double)m.Conocidos;
                tasaMes[m.Mes] = global + (observada - global) * m.Conocidos / (m.Conocidos + suavizadoK);
            }
            var dimsRecontacto = new List<Calibracion.Dimension>
            {
                new("canal", codCanal, InfoCanal.Select(x => x.Unos / (double)x.Conocidos).ToArray()),
                new("motivo", codMotivo, InfoMotivo.Select(x => x.Unos / (double)x.Conocidos).ToArray()),
                new("cola", codCola, InfoCola.Select(x => x.Unos / (double)x.Conocidos).ToArray()),
                new("mes", mesCod, meses.Select(m => tasaMes.GetValueOrDefault(m, global)).ToArray()),
            };
            var probabilidad = Calibracion.CalibrarLogit(offset, dimsRecontacto, global, out double errorRecontacto);

            // 6) Armado de filas
            var limiteVentana = PeriodoFin.AddDays(-VentanaRecontactoDias);
            var filas = new List<Interaccion>(n);
            for (int i = 0; i < n; i++)
            {
                var sis = sistema[i];
                var rango = DesfaseCarga.GetValueOrDefault(sis, new[] { 0, 0 });
                int desfase = rng.Entero(rango[0], rango[1] + 1);
                bool ventanaAbierta = fechas[i] > limiteVentana;
                filas.Add(new Interaccion
                {
                    FilaOrigen = i + 1,
                    IdInteraccion = $"INT-{i + 1:D7}",
                    FechaContacto = fechas[i],
                    HoraContacto = horas[i],
                    Canal = canales[codCanal[i]],
                    MotivoContacto = motivos[codMotivo[i]],
                    ColaServicio = colas[codCola[i]],
                    TipoUsuario = tipos[codTipo[i]],
                    Turno = turno[i],
                    SistemaOrigen = sis,
                    DuracionSeg = duracion[i],
                    EsperaSeg = espera[i],
                    Transferencias = transferencias[i],
                    CasosPrevios30d = casosPrevios[i],
                    GrabacionAutorizada = rng.U() < ProbGrabacionAutorizada ? 1 : 0,
                    Recontacto7Dias = ventanaAbierta ? (int?)null : (rng.U() < probabilidad[i] ? 1 : 0),
                    FechaCarga = fechas[i].AddDays(desfase),
                });
            }
            return new ResultadoGeneracion
            {
                Filas = filas,
                ErrorRecontacto = errorRecontacto,
                ErrorDuracion = errorDuracion,
            };
        }

        // ============================================================
        // CONTAMINADOR: inyecta los defectos de calidad de la semilla
        // ============================================================
        static List<Interaccion> InyectarDefectos(List<Interaccion> limpias, int nTotal, int semillaGen, int nDuplicados)
        {
            var rng = new Muestreo(semillaGen + 7919);
            var usadas = new HashSet<int>();

            List<int> Candidatas(Func<Interaccion, bool> filtro)
            {
                var lista = new List<int>();
                for (int i = 0; i < limpias.Count; i++)
                    if (!usadas.Contains(i) && filtro(limpias[i])) lista.Add(i);
                rng.Barajar(lista);
                return lista;
            }

            // 1) Canal vacío: "(sin dato)" del Informe 2 (9/360)
            int kCanal = (int)Math.Round(PctCanalVacio * nTotal / 100.0);
            foreach (var i in Candidatas(_ => true).Take(kCanal)) { limpias[i].Canal = null; usadas.Add(i); }

            // 2) Etiquetas no normalizadas: COBRO y QUEJA en mayúsculas
            int kMayus = (int)Math.Round(PctMotivoMayuscula * nTotal / 100.0);
            foreach (var i in Candidatas(f => f.MotivoContacto is "Cobro" or "Queja").Take(kMayus))
            {
                limpias[i].MotivoContacto = limpias[i].MotivoContacto!.ToUpperInvariant();
                usadas.Add(i);
            }

            // 3) recontacto_7_dias vacío: se completa hasta la proporción de la semilla (6/360),
            //    contando los contactos recientes cuya ventana de 7 días aún está abierta
            int kRecontacto = (int)Math.Round(PctRecontactoVacio * nTotal / 100.0);
            int yaVacios = limpias.Count(f => !f.Recontacto7Dias.HasValue);
            int faltan = Math.Max(0, kRecontacto - yaVacios);
            foreach (var i in Candidatas(f => f.Recontacto7Dias.HasValue).Take(faltan))
            {
                limpias[i].Recontacto7Dias = null;
                usadas.Add(i);
            }

            // 4) Valores fuera de rango del diccionario
            int kFuera = (int)Math.Round(PctFueraDeRango * nTotal / 100.0);
            var campos = new[] { "duracion_seg", "espera_seg", "transferencias", "casos_previos_30d" };
            foreach (var i in Candidatas(_ => true).Take(kFuera))
            {
                var f = limpias[i];
                switch (campos[rng.Entero(0, campos.Length)])
                {
                    case "duracion_seg": f.DuracionSeg = new[] { 0, 12, 2700, 3600 }[rng.Entero(0, 4)]; break;
                    case "espera_seg": f.EsperaSeg = new[] { -1, 1200, 2000 }[rng.Entero(0, 3)]; break;
                    case "transferencias": f.Transferencias = new[] { 5, 7, 9 }[rng.Entero(0, 3)]; break;
                    default: f.CasosPrevios30d = new[] { 12, 15, 20 }[rng.Entero(0, 3)]; break;
                }
                usadas.Add(i);
            }

            // 5) grabacion_autorizada vacía (inconsistencia de gobierno del dato)
            int kGrabacion = (int)Math.Round(PctGrabacionInconsistente * nTotal / 100.0);
            foreach (var i in Candidatas(_ => true).Take(kGrabacion))
            {
                limpias[i].GrabacionAutorizada = null;
                usadas.Add(i);
            }

            // 6) Duplicados: copia exacta de filas buenas (mismo id_interaccion)
            var salida = new List<Interaccion>(limpias);
            int filaSiguiente = limpias.Count;
            foreach (var i in Candidatas(_ => true).Take(nDuplicados))
            {
                var copia = limpias[i].Copiar();
                copia.FilaOrigen = ++filaSiguiente;
                salida.Add(copia);
            }
            return salida;
        }

        // ============================================================
        // MINI ETL: reglas de limpieza de calidad
        // ============================================================
        static readonly Dictionary<string, string[]> Catalogos = new()
        {
            ["canal"] = new[] { "Teléfono", "Chat", "Correo", "Red social" },
            ["motivo_contacto"] = new[] { "Consulta", "Falla", "Cobro", "Solicitud", "Queja" },
            ["cola_servicio"] = new[] { "Facturación", "Soporte", "Información", "Reclamos", "Trámites" },
            ["tipo_usuario"] = new[] { "Nuevo", "Recurrente", "Empresa", "Adulto mayor" },
            ["turno"] = new[] { "AM", "PM", "Nocturno", "Fin de semana" },
            ["sistema_origen"] = new[] { "ACD", "CRM", "Ticketing", "Calidad" },
        };

        static Limpieza Limpiar(List<Interaccion> crudas)
        {
            var reglas = new List<ReglaLimpieza>
            {
                new("R-UNI-01", "Unicidad",        "id_interaccion duplicado (se conserva la primera aparición)"),
                new("R-EST-01", "Estandarización", "motivo_contacto se normaliza al catálogo (COBRO->Cobro, QUEJA->Queja)"),
                new("R-COM-01", "Completitud",     "canal, motivo_contacto, cola_servicio y fecha_contacto son obligatorios"),
                new("R-VAL-01", "Validez",         "rangos: duración 30-1800, espera 0-900, transferencias 0-4, casos 0-8"),
                new("R-CAT-01", "Validez",         "valores categóricos deben existir en el catálogo oficial"),
                new("R-CRO-01", "Consistencia",    "fecha_carga no puede ser anterior a fecha_contacto"),
                new("R-CON-01", "Consolidación",   "recontacto_7_dias vacío = no consolidado (se conserva como nulo)"),
            };

            var vistos = new HashSet<string>();
            var rechazadas = new List<Interaccion>();
            var limpias = new List<Interaccion>();
            int corregidosEtiqueta = 0;

            int evaluados = 0;
            foreach (var original in crudas.OrderBy(x => x.FilaOrigen))
            {
                evaluados++;
                // Se trabaja sobre una COPIA para no alterar el registro original:
                // el CSV crudo y la zona de preparación deben conservar los datos sucios.
                var f = original.Copiar();
                string? regla = null;
                if (f.IdInteraccion == null || !vistos.Add(f.IdInteraccion))
                {
                    regla = "R-UNI-01";
                }
                else
                {
                    // Estandarización de etiquetas (CORREGIR)
                    if (f.MotivoContacto != null)
                    {
                        var canonico = Catalogos["motivo_contacto"].FirstOrDefault(c =>
                            string.Equals(c, f.MotivoContacto.Trim(), StringComparison.OrdinalIgnoreCase)) ?? f.MotivoContacto;
                        if (canonico != f.MotivoContacto) corregidosEtiqueta++;
                        f.MotivoContacto = canonico;
                    }

                    if (string.IsNullOrWhiteSpace(f.Canal) || string.IsNullOrWhiteSpace(f.MotivoContacto)
                        || string.IsNullOrWhiteSpace(f.ColaServicio) || !f.FechaContacto.HasValue)
                        regla = "R-COM-01";
                    else if (f.DuracionSeg is < DuracionMin or > DuracionMax
                          || f.EsperaSeg is < 0 or > 900
                          || f.Transferencias is < 0 or > 4
                          || f.CasosPrevios30d is < 0 or > 8)
                        regla = "R-VAL-01";
                    else if (!Catalogos["canal"].Contains(f.Canal!)
                          || !Catalogos["motivo_contacto"].Contains(f.MotivoContacto)
                          || !Catalogos["cola_servicio"].Contains(f.ColaServicio)
                          || !Catalogos["tipo_usuario"].Contains(f.TipoUsuario)
                          || !Catalogos["turno"].Contains(f.Turno)
                          || !Catalogos["sistema_origen"].Contains(f.SistemaOrigen))
                        regla = "R-CAT-01";
                    else if (f.FechaCarga.HasValue && f.FechaContacto.HasValue && f.FechaCarga < f.FechaContacto)
                        regla = "R-CRO-01";
                }

                if (regla == null) limpias.Add(f);
                else { rechazadas.Add(f); reglas.First(r => r.Id == regla).Afectados++; }
            }

            reglas.First(r => r.Id == "R-EST-01").Afectados = corregidosEtiqueta;
            reglas.First(r => r.Id == "R-UNI-01").Evaluados = evaluados;
            reglas.First(r => r.Id == "R-EST-01").Evaluados = crudas.Count(f => f.MotivoContacto != null);
            foreach (var r in reglas.Where(r => r.Id is not ("R-UNI-01" or "R-EST-01")))
                r.Evaluados = crudas.Count - reglas.First(x => x.Id == "R-UNI-01").Afectados;
            reglas.First(r => r.Id == "R-CON-01").Afectados = limpias.Count(f => !f.Recontacto7Dias.HasValue);
            reglas.First(r => r.Id == "R-CON-01").Evaluados = limpias.Count;

            return new Limpieza { Limpias = limpias, Rechazadas = rechazadas, Reglas = reglas };
        }

        // ============================================================
        // MINI ETL: exportación CSV de evidencia
        // ============================================================
        static readonly string[] ColumnasCsv =
        {
            "fila_origen", "id_interaccion", "fecha_contacto", "hora_contacto", "canal", "motivo_contacto",
            "cola_servicio", "tipo_usuario", "turno", "sistema_origen", "duracion_seg", "espera_seg",
            "transferencias", "casos_previos_30d", "grabacion_autorizada", "recontacto_7_dias", "fecha_carga",
        };

        static void EscribirCsv(string ruta, List<Interaccion> filas)
        {
            using var w = new StreamWriter(ruta, false, new UTF8Encoding(false));
            w.WriteLine(string.Join(",", ColumnasCsv));
            foreach (var f in filas)
            {
                w.WriteLine(string.Join(",", new[]
                {
                    f.FilaOrigen.ToString(CultureInfo.InvariantCulture),
                    TextoCsv(f.IdInteraccion),
                    f.FechaContacto?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) ?? "",
                    f.HoraContacto?.ToString(CultureInfo.InvariantCulture) ?? "",
                    TextoCsv(f.Canal), TextoCsv(f.MotivoContacto), TextoCsv(f.ColaServicio), TextoCsv(f.TipoUsuario),
                    TextoCsv(f.Turno), TextoCsv(f.SistemaOrigen),
                    f.DuracionSeg?.ToString(CultureInfo.InvariantCulture) ?? "",
                    f.EsperaSeg?.ToString(CultureInfo.InvariantCulture) ?? "",
                    f.Transferencias?.ToString(CultureInfo.InvariantCulture) ?? "",
                    f.CasosPrevios30d?.ToString(CultureInfo.InvariantCulture) ?? "",
                    f.GrabacionAutorizada?.ToString(CultureInfo.InvariantCulture) ?? "",
                    f.Recontacto7Dias?.ToString(CultureInfo.InvariantCulture) ?? "",
                    f.FechaCarga?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) ?? "",
                }));
            }
        }

        static string TextoCsv(string? s) =>
            s == null ? "" : (s.Contains(',') || s.Contains('"') ? "\"" + s.Replace("\"", "\"\"") + "\"" : s);

        // ============================================================
        // CARGA A SQL SERVER (staging con datos sucios + DW con datos limpios)
        // ============================================================
        static void CargarSqlServer(List<Interaccion> crudas, List<Interaccion> limpias)
        {
            using var conn = AbrirConexion();
            int idLote;
            using (var cmd = new SqlCommand(
                "INSERT INTO dbo.dq_lote (origen, registros_semilla, registros_generados, semilla_aleatoria) " +
                "OUTPUT INSERTED.id_lote VALUES (@origen, 360, @generados, @semilla)", conn))
            {
                cmd.Parameters.AddWithValue("@origen", "Generador C# (DataSetGenerator/Program.cs) + MINI ETL");
                cmd.Parameters.AddWithValue("@generados", crudas.Count);
                cmd.Parameters.AddWithValue("@semilla", semilla);
                idLote = (int)cmd.ExecuteScalar();
            }

            // 3a) Zona de preparación: los datos SUCIOS tal como llegan de los sistemas
            var tablaCruda = TablaStaging();
            foreach (var f in crudas) tablaCruda.Rows.Add(idLote, f.FilaOrigen, V(f.IdInteraccion), V(f.FechaContacto),
                V(f.HoraContacto), V(f.Canal), V(f.MotivoContacto), V(f.ColaServicio), V(f.TipoUsuario), V(f.Turno),
                V(f.SistemaOrigen), V(f.DuracionSeg), V(f.EsperaSeg), V(f.Transferencias), V(f.CasosPrevios30d),
                V(f.GrabacionAutorizada), V(f.Recontacto7Dias), V(f.FechaCarga));
            using (var bulk = new SqlBulkCopy(conn) { DestinationTableName = "dbo.stg_interaccion_cruda", BatchSize = 5000, BulkCopyTimeout = 300 })
            {
                foreach (DataColumn col in tablaCruda.Columns) bulk.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                bulk.WriteToServer(tablaCruda);
            }

            // 3b) Trazabilidad: fila_origen -> id_registro_crudo generado por SQL
            var mapaCrudos = new Dictionary<int, long>();
            using (var cmd = new SqlCommand("SELECT id_registro_crudo, fila_origen FROM dbo.stg_interaccion_cruda WHERE id_lote = @lote", conn))
            {
                cmd.Parameters.AddWithValue("@lote", idLote);
                using var reader = cmd.ExecuteReader();
                while (reader.Read()) mapaCrudos[reader.GetInt32(1)] = reader.GetInt64(0);
            }

            // 3c) Catálogos de dimensiones
            var idCanal = LeerCatalogo(conn, "dim_canal", "id_canal", "nombre_canal");
            var idMotivo = LeerCatalogo(conn, "dim_motivo", "id_motivo", "nombre_motivo");
            var idCola = LeerCatalogo(conn, "dim_cola", "id_cola", "nombre_cola");
            var idTipo = LeerCatalogo(conn, "dim_tipo_usuario", "id_tipo_usuario", "nombre_tipo_usuario");
            var idTurno = LeerCatalogo(conn, "dim_turno", "id_turno", "nombre_turno");
            var idSistema = LeerCatalogo(conn, "dim_sistema_origen", "id_sistema_origen", "nombre_sistema");

            // 3d) Hecho: solo los datos LIMPIOS (los rechazados quedan en staging y en el CSV crudo)
            var tablaHecho = TablaHecho();
            foreach (var f in limpias)
            {
                int idTiempo = f.FechaContacto!.Value.Year * 10000 + f.FechaContacto.Value.Month * 100 + f.FechaContacto.Value.Day;
                int idTiempoCarga = (f.FechaCarga ?? f.FechaContacto.Value).Year * 10000
                                  + (f.FechaCarga ?? f.FechaContacto.Value).Month * 100
                                  + (f.FechaCarga ?? f.FechaContacto.Value).Day;
                tablaHecho.Rows.Add(
                    f.IdInteraccion!, idLote, mapaCrudos[f.FilaOrigen], idTiempo, idTiempoCarga, f.HoraContacto,
                    idCanal[f.Canal!], idMotivo[f.MotivoContacto!], idCola[f.ColaServicio!], idTipo[f.TipoUsuario!],
                    idTurno[f.Turno!], idSistema[f.SistemaOrigen!], f.DuracionSeg, f.EsperaSeg, f.Transferencias,
                    f.CasosPrevios30d, f.GrabacionAutorizada, DBNull.Value.Equals(f.Recontacto7Dias) ? DBNull.Value : f.Recontacto7Dias);
            }
            using (var bulk = new SqlBulkCopy(conn) { DestinationTableName = "dbo.hecho_interaccion", BatchSize = 5000, BulkCopyTimeout = 300 })
            {
                foreach (DataColumn col in tablaHecho.Columns) bulk.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                bulk.WriteToServer(tablaHecho);
            }

            Console.WriteLine($"   ✓ Lote {idLote}: {crudas.Count:N0} sucios -> stg_interaccion_cruda");
            Console.WriteLine($"   ✓ {limpias.Count:N0} limpios -> hecho_interaccion (trazables por id_registro_crudo)");
        }

        static DataTable TablaStaging()
        {
            var t = new DataTable();
            t.Columns.Add("id_lote", typeof(int));
            t.Columns.Add("fila_origen", typeof(int));
            t.Columns.Add("id_interaccion", typeof(string));
            t.Columns.Add("fecha_contacto", typeof(DateTime));
            t.Columns.Add("hora_contacto", typeof(int));
            t.Columns.Add("canal", typeof(string));
            t.Columns.Add("motivo_contacto", typeof(string));
            t.Columns.Add("cola_servicio", typeof(string));
            t.Columns.Add("tipo_usuario", typeof(string));
            t.Columns.Add("turno", typeof(string));
            t.Columns.Add("sistema_origen", typeof(string));
            t.Columns.Add("duracion_seg", typeof(int));
            t.Columns.Add("espera_seg", typeof(int));
            t.Columns.Add("transferencias", typeof(int));
            t.Columns.Add("casos_previos_30d", typeof(int));
            t.Columns.Add("grabacion_autorizada", typeof(int));
            t.Columns.Add("recontacto_7_dias", typeof(int));
            t.Columns.Add("fecha_carga", typeof(DateTime));
            return t;
        }

        static DataTable TablaHecho()
        {
            var t = new DataTable();
            t.Columns.Add("id_interaccion", typeof(string));
            t.Columns.Add("id_lote", typeof(int));
            t.Columns.Add("id_registro_crudo", typeof(long));
            t.Columns.Add("id_tiempo", typeof(int));
            t.Columns.Add("id_tiempo_carga", typeof(int));
            t.Columns.Add("hora_contacto", typeof(int));
            t.Columns.Add("id_canal", typeof(byte));
            t.Columns.Add("id_motivo", typeof(byte));
            t.Columns.Add("id_cola", typeof(byte));
            t.Columns.Add("id_tipo_usuario", typeof(byte));
            t.Columns.Add("id_turno", typeof(byte));
            t.Columns.Add("id_sistema_origen", typeof(byte));
            t.Columns.Add("duracion_seg", typeof(int));
            t.Columns.Add("espera_seg", typeof(int));
            t.Columns.Add("transferencias", typeof(byte));
            t.Columns.Add("casos_previos_30d", typeof(byte));
            t.Columns.Add("grabacion_autorizada", typeof(byte));
            t.Columns.Add("recontacto_7_dias", typeof(int));
            return t;
        }

        static Dictionary<string, byte> LeerCatalogo(SqlConnection conn, string tabla, string colId, string colNombre)
        {
            var mapa = new Dictionary<string, byte>();
            using var cmd = new SqlCommand($"SELECT {colId}, {colNombre} FROM dbo.{tabla}", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) mapa[reader.GetString(1)] = reader.GetByte(0);
            return mapa;
        }

        static SqlConnection AbrirConexion()
        {
            Exception? ultimo = null;
            for (int intento = 1; intento <= 10; intento++)
            {
                try
                {
                    var conn = new SqlConnection(connectionString);
                    conn.Open();
                    return conn;
                }
                catch (Exception ex) { ultimo = ex; System.Threading.Thread.Sleep(3000); }
            }
            throw new InvalidOperationException("No se pudo conectar a SQL Server. Detalle: " + ultimo?.Message);
        }

        static string ConstruirCadenaConexion()
        {
            string E(string nombre, string defecto)
            {
                var v = Environment.GetEnvironmentVariable(nombre);
                return string.IsNullOrWhiteSpace(v) ? defecto : v.Trim();
            }
            var host = E("DB_HOST", "localhost");
            var puerto = E("DB_PORT", "1433");
            var bd = E("DB_NAME", "ServicioCiudadano1800DW");
            var usuario = E("DB_USER", "sa");
            var clave = Environment.GetEnvironmentVariable("DB_PASSWORD");
            var archivoClave = Environment.GetEnvironmentVariable("DB_PASSWORD_FILE");
            if (string.IsNullOrWhiteSpace(clave) && !string.IsNullOrWhiteSpace(archivoClave))
                clave = File.ReadAllText(archivoClave).Trim();
            if (string.IsNullOrWhiteSpace(clave))
                throw new InvalidOperationException("Define DB_PASSWORD o DB_PASSWORD_FILE para conectar con SQL Server.");
            var confiarCertificado = E("DB_TRUST_CERT", "false");
            var servidor = host.Contains('\\') || string.IsNullOrEmpty(puerto) ? host : $"{host},{puerto}";
            return $"Server={servidor};Database={bd};User Id={usuario};Password=\"{clave.Replace("\"", "\"\"")}\";" +
                   $"TrustServerCertificate={confiarCertificado};Encrypt=True;Connect Timeout=30;";
        }

        static object V(object? valor) => valor ?? DBNull.Value;

        // ============================================================
        // KPI DEL CASO
        // ============================================================
        static void ImprimirKpis(List<Interaccion> limpias)
        {
            Console.WriteLine("\nKPI 1 - Duración promedio de interacción por canal (fórmula: suma duración / cantidad)");
            Console.WriteLine("  Canal        Interacciones   Duración prom. (s)   Duración prom. (min)");
            foreach (var g in limpias.GroupBy(f => f.Canal).OrderByDescending(g => g.Average(f => f.DuracionSeg ?? 0)))
                Console.WriteLine($"  {g.Key,-12} {g.Count(),12:N0} {g.Average(f => f.DuracionSeg ?? 0),20:N1} {g.Average(f => f.DuracionSeg ?? 0) / 60.0,22:N1}");

            var consolidados = limpias.Where(f => f.Recontacto7Dias.HasValue).ToList();
            double tr7 = consolidados.Count == 0 ? 0 : 100.0 * consolidados.Count(f => f.Recontacto7Dias == 1) / consolidados.Count;
            Console.WriteLine("\nKPI 2 - Tasa de recontacto a 7 días (TR7) = recontactos / interacciones con resultado consolidado");
            Console.WriteLine($"  Interacciones consolidadas: {consolidados.Count:N0} | recontactos: {consolidados.Count(f => f.Recontacto7Dias == 1):N0}");
            Console.WriteLine($"  TR7 global: {tr7:F2}%   (meta del caso: 22% | valor del informe: 41.13%)");

            Console.WriteLine("\nKPI 3 - Volumen de interacciones por turno (COUNT agrupado por turno)");
            foreach (var g in limpias.GroupBy(f => f.Turno).OrderByDescending(g => g.Count()))
                Console.WriteLine($"  {g.Key,-14} {g.Count(),10:N0} interacciones ({100.0 * g.Count() / limpias.Count,5:F1}%)");
        }

        // ============================================================
        // UTILIDADES
        // ============================================================
        static int LeerEntero(string variable, int defecto)
        {
            var texto = Environment.GetEnvironmentVariable(variable);
            return int.TryParse(texto, NumberStyles.Integer, CultureInfo.InvariantCulture, out var v) ? v : defecto;
        }

        static int DiaSemanaLunes0(DateTime d) => ((int)d.DayOfWeek + 6) % 7;
    }

    // ============================================================
    // DTO: una interacción del centro de contacto (15 variables + hora + fila)
    // ============================================================
    public sealed class Interaccion
    {
        public int FilaOrigen { get; set; }
        public string? IdInteraccion { get; set; }
        public DateTime? FechaContacto { get; set; }
        public int? HoraContacto { get; set; }
        public string? Canal { get; set; }
        public string? MotivoContacto { get; set; }
        public string? ColaServicio { get; set; }
        public string? TipoUsuario { get; set; }
        public string? Turno { get; set; }
        public string? SistemaOrigen { get; set; }
        public int? DuracionSeg { get; set; }
        public int? EsperaSeg { get; set; }
        public int? Transferencias { get; set; }
        public int? CasosPrevios30d { get; set; }
        public int? GrabacionAutorizada { get; set; }
        public int? Recontacto7Dias { get; set; }
        public DateTime? FechaCarga { get; set; }

        public Interaccion Copiar() => (Interaccion)MemberwiseClone();
    }

    public sealed class ResultadoGeneracion
    {
        public List<Interaccion> Filas { get; init; } = new();
        public double ErrorRecontacto { get; init; }
        public double ErrorDuracion { get; init; }
    }

    public sealed class ReglaLimpieza
    {
        public string Id { get; }
        public string Dimension { get; }
        public string Descripcion { get; }
        public int Evaluados { get; set; }
        public int Afectados { get; set; }

        public ReglaLimpieza(string id, string dimension, string descripcion)
        {
            Id = id; Dimension = dimension; Descripcion = descripcion;
        }
    }

    public sealed class Limpieza
    {
        public List<Interaccion> Limpias { get; init; } = new();
        public List<Interaccion> Rechazadas { get; init; } = new();
        public List<ReglaLimpieza> Reglas { get; init; } = new();

        public static void ImprimirResumen(int totalCrudos, Limpieza l)
        {
            Console.WriteLine("\n   Regla     Dimensión         Evaluados  Afectados       %  Descripción");
            foreach (var r in l.Reglas)
            {
                double pct = r.Evaluados == 0 ? 0 : 100.0 * r.Afectados / r.Evaluados;
                Console.WriteLine($"   {r.Id,-9} {r.Dimension,-16} {r.Evaluados,10:N0} {r.Afectados,10:N0} {pct,6:F2}%  {r.Descripcion}");
            }
            Console.WriteLine($"   Rechazadas: {l.Rechazadas.Count:N0} | Duplicadas: {l.Reglas.First(r => r.Id == "R-UNI-01").Afectados:N0} | " +
                              $"Limpias: {l.Limpias.Count:N0} de {totalCrudos:N0} ({100.0 * l.Limpias.Count / totalCrudos:F1}%)");
        }
    }

    // ============================================================
    // MUESTREO: números aleatorios con semilla fija (reproducible)
    // ============================================================
    public sealed class Muestreo
    {
        private readonly Random _r;
        private double? _sobrante;

        public Muestreo(int semilla) => _r = new Random(semilla);

        public double U() => _r.NextDouble();

        public int Entero(int minIncl, int maxExcl) => _r.Next(minIncl, maxExcl);

        public double Normal()
        {
            if (_sobrante.HasValue) { var v = _sobrante.Value; _sobrante = null; return v; }
            double u1 = 1.0 - U(), u2 = U();
            double radio = Math.Sqrt(-2.0 * Math.Log(u1));
            double angulo = 2.0 * Math.PI * u2;
            _sobrante = radio * Math.Sin(angulo);
            return radio * Math.Cos(angulo);
        }

        public int Poisson(double lambda)
        {
            if (lambda <= 0) return 0;
            double limite = Math.Exp(-lambda), p = 1.0;
            int k = 0;
            do { k++; p *= U(); } while (p > limite);
            return k - 1;
        }

        public double Gamma2(double escala)
        {
            double a = -Math.Log(1.0 - U());
            double b = -Math.Log(1.0 - U());
            return escala * (a + b);
        }

        public int Elegir(double[] pesos)
        {
            double total = pesos.Sum();
            double x = U() * total, acumulado = 0;
            for (int i = 0; i < pesos.Length; i++)
            {
                acumulado += pesos[i];
                if (x < acumulado) return i;
            }
            return pesos.Length - 1;
        }

        public void Barajar<T>(IList<T> lista)
        {
            for (int i = lista.Count - 1; i > 0; i--)
            {
                int j = _r.Next(i + 1);
                (lista[i], lista[j]) = (lista[j], lista[i]);
            }
        }
    }

    // ============================================================
    // CALIBRACIÓN: hace que los datos reproduzcan los informes
    // ============================================================
    public static class Calibracion
    {
        public static double Logit(double p) { p = Math.Min(Math.Max(p, 1e-6), 1 - 1e-6); return Math.Log(p / (1 - p)); }

        public static double Sigmoide(double z) => 1.0 / (1.0 + Math.Exp(-z));

        // Matriz conjunta motivo x cola que respeta los totales de los Informes 3 y 4 (IPF)
        public static double[,] IpfMotivoCola(
            Dictionary<string, Dictionary<string, double>> afinidad,
            string[] motivos, string[] colas, double[] registrosMotivo, double[] registrosCola)
        {
            int f = motivos.Length, c = colas.Length;
            var m = new double[f, c];
            for (int i = 0; i < f; i++)
            {
                afinidad.TryGetValue(motivos[i], out var fila);
                for (int j = 0; j < c; j++)
                    m[i, j] = fila != null && fila.TryGetValue(colas[j], out var a) ? a : 0.01;
            }
            var filaObj = new double[f];
            var colObj = new double[c];
            double sumaF = registrosMotivo.Sum(), sumaC = registrosCola.Sum();
            for (int i = 0; i < f; i++) filaObj[i] = registrosMotivo[i] / sumaF;
            for (int j = 0; j < c; j++) colObj[j] = registrosCola[j] / sumaC;

            for (int it = 0; it < 2000; it++)
            {
                for (int i = 0; i < f; i++)
                {
                    double suma = 0;
                    for (int j = 0; j < c; j++) suma += m[i, j];
                    for (int j = 0; j < c; j++) m[i, j] *= filaObj[i] / suma;
                }
                for (int j = 0; j < c; j++)
                {
                    double suma = 0;
                    for (int i = 0; i < f; i++) suma += m[i, j];
                    for (int i = 0; i < f; i++) m[i, j] *= colObj[j] / suma;
                }
            }
            double total = 0;
            foreach (var v in m) total += v;
            for (int i = 0; i < f; i++)
                for (int j = 0; j < c; j++) m[i, j] /= total;
            return m;
        }

        public sealed record Dimension(string Nombre, int[] Codigos, double[] Objetivo);

        // Ajusta un efecto aditivo (escala logit) por categoría hasta igualar la tasa de recontacto
        public static double[] CalibrarLogit(double[] offset, IList<Dimension> dims, double tasaGlobal, out double errorMax)
        {
            int n = offset.Length;
            double media = offset.Average();
            var z = new double[n];
            double base0 = Logit(tasaGlobal);
            for (int i = 0; i < n; i++) z[i] = base0 + offset[i] - media;

            errorMax = 1.0;
            for (int iter = 0; iter < 400; iter++)
            {
                errorMax = 0.0;
                foreach (var d in dims)
                {
                    int niveles = d.Objetivo.Length;
                    var suma = new double[niveles];
                    var cuenta = new int[niveles];
                    for (int i = 0; i < n; i++) { suma[d.Codigos[i]] += Sigmoide(z[i]); cuenta[d.Codigos[i]]++; }
                    var delta = new double[niveles];
                    for (int l = 0; l < niveles; l++)
                    {
                        if (cuenta[l] == 0) continue;
                        double m = suma[l] / cuenta[l];
                        delta[l] = 0.7 * (Logit(d.Objetivo[l]) - Logit(m));
                        errorMax = Math.Max(errorMax, Math.Abs(m - d.Objetivo[l]));
                    }
                    for (int i = 0; i < n; i++) z[i] += delta[d.Codigos[i]];
                }
                if (errorMax < 1e-4) break;
            }
            var p = new double[n];
            for (int i = 0; i < n; i++) p[i] = Sigmoide(z[i]);
            return p;
        }

        // Escala la duración base por categoría para que la media coincida con la del informe
        public static int[] CalibrarDuracion(double[] baseValores, IList<Dimension> dims, int minimo, int maximo, out double errorMax)
        {
            int n = baseValores.Length;
            var factores = dims.Select(d => Enumerable.Repeat(1.0, d.Objetivo.Length).ToArray()).ToArray();
            const double escala = 800.0;

            double[] Valores()
            {
                var v = new double[n];
                for (int i = 0; i < n; i++)
                {
                    double f = escala;
                    for (int k = 0; k < dims.Count; k++) f *= factores[k][dims[k].Codigos[i]];
                    v[i] = Math.Min(Math.Max(baseValores[i] * f, minimo), maximo);
                }
                return v;
            }

            errorMax = 1.0;
            for (int iter = 0; iter < 300; iter++)
            {
                errorMax = 0.0;
                for (int k = 0; k < dims.Count; k++)
                {
                    var vals = Valores();
                    int niveles = dims[k].Objetivo.Length;
                    var suma = new double[niveles];
                    var cuenta = new int[niveles];
                    for (int i = 0; i < n; i++) { suma[dims[k].Codigos[i]] += vals[i]; cuenta[dims[k].Codigos[i]]++; }
                    for (int l = 0; l < niveles; l++)
                    {
                        if (cuenta[l] == 0) continue;
                        double ratio = dims[k].Objetivo[l] / (suma[l] / cuenta[l]);
                        factores[k][l] *= Math.Pow(ratio, 0.7);
                        errorMax = Math.Max(errorMax, Math.Abs(ratio - 1.0));
                    }
                }
                if (errorMax < 1e-3) break;
            }
            var final = Valores();
            var salida = new int[n];
            for (int i = 0; i < n; i++) salida[i] = (int)Math.Min(Math.Max(Math.Round(final[i]), minimo), maximo);
            return salida;
        }
    }
}
