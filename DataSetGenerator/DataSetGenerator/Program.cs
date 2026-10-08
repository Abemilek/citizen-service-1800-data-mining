using System;
using System.Data.SqlClient;

namespace DataSetGenerator
{
    class Program
    {
        // ============================================================
        // CONFIGURACION - Servicio Ciudadano 1800 (Caso 15)
        // ============================================================
        const int N = 100_000;
        const int SEED = 15;
        static Random rnd = new Random(SEED);

        static string connectionString = "Server=localhost\\SQLEXPRESS;Database=ServicioCiudadanoDW;User Id=sa;Password=12345678;TrustServerCertificate=True;";

        static void Main(string[] args)
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("GENERADOR DE DATOS: SERVICIO CIUDADANO 1800 (CASO 15)");
            Console.WriteLine("==================================================");

            // Validar conexión
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Conexión a BD exitosa.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error de conexión: " + ex.Message);
                    return;
                }
            }

            Console.WriteLine($"\nIniciando generación de {N:N0} registros (Suciedad inyectada)...");
            GenerarDatos();
            Console.WriteLine("\n¡Proceso completado exitosamente!");
        }

        static void GenerarDatos()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Limpiar tabla antes de empezar
                using (var cmd = new SqlCommand("TRUNCATE TABLE v0_crudo", conn))
                {
                    cmd.ExecuteNonQuery();
                }

                int batchSize = 1000;
                int count = 0;

                for (int i = 0; i < N; i++)
                {
                    // Generar campos base
                    string id_interaccion = Guid.NewGuid().ToString();
                    DateTime fecha_contacto = DateTime.Now.AddDays(-rnd.Next(1, 365)).AddHours(rnd.Next(0, 24));
                    
                    // Canal
                    string[] canales = { "Teléfono", "Red social", "Web", "App" };
                    string canal = canales[rnd.Next(canales.Length)];
                    if (rnd.NextDouble() < 0.05) canal = "(sin dato)"; // R-CAL-03 suciedad

                    // Motivo
                    string[] motivos = { "Consulta", "Falla", "Cobro", "Queja" };
                    string motivo = motivos[rnd.Next(motivos.Length)];
                    if (rnd.NextDouble() < 0.10 && motivo == "Cobro") motivo = "COBRO"; // R-CAL-02 suciedad
                    if (rnd.NextDouble() < 0.10 && motivo == "Queja") motivo = "QUEJA"; // R-CAL-02 suciedad

                    // Cola
                    string[] colas = { "Soporte", "Facturación", "Información", "Reclamos" };
                    string cola = colas[rnd.Next(colas.Length)];

                    // Métricas
                    int duracion = rnd.Next(20, 2000); // R-CAL-05 suciedad (<30 o >1800)
                    int espera = rnd.Next(-10, 1000);  // R-CAL-06 suciedad (<0 o >900)
                    
                    string grabacion = rnd.NextDouble() > 0.5 ? "Sí" : "No";
                    if (rnd.NextDouble() < 0.1) grabacion = null; // R-PRIV-01 suciedad

                    // Target (Recontacto a 7 días)
                    // Haremos que la falla tenga más probabilidad de recontacto (basado en KPIs)
                    double probRecontacto = 0.3;
                    if (motivo == "Falla") probRecontacto = 0.5;
                    if (cola == "Facturación") probRecontacto = 0.47;
                    if (canal == "Red social") probRecontacto = 0.46;
                    
                    string recontacto = rnd.NextDouble() < probRecontacto ? "1" : "0";
                    if (rnd.NextDouble() < 0.05) recontacto = null; // R-CAL-01 suciedad nulos

                    int casos_previos = rnd.NextDouble() < 0.3 ? rnd.Next(1, 5) : 0;
                    int transferencias = rnd.NextDouble() < 0.6 ? 0 : rnd.Next(1, 3);
                    string[] tipos = { "Particular", "Empresa", "Gobierno" };
                    string tipo = tipos[rnd.Next(tipos.Length)];

                    // Insertar
                    using (var cmd = new SqlCommand(@"
                        INSERT INTO v0_crudo (
                            id_interaccion, fecha_contacto, canal, motivo_contacto, cola_servicio, 
                            duracion_seg, espera_seg, grabacion_autorizada, recontacto_7_dias,
                            casos_previos_30d, nivel_transferencias, tipo_usuario
                        ) VALUES (
                            @id, @fecha, @canal, @motivo, @cola, @duracion, @espera, @grabacion, @recontacto,
                            @casos_previos, @transferencias, @tipo
                        )", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id_interaccion);
                        cmd.Parameters.AddWithValue("@fecha", fecha_contacto);
                        cmd.Parameters.AddWithValue("@canal", canal ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@motivo", motivo);
                        cmd.Parameters.AddWithValue("@cola", cola);
                        cmd.Parameters.AddWithValue("@duracion", duracion);
                        cmd.Parameters.AddWithValue("@espera", espera);
                        cmd.Parameters.AddWithValue("@grabacion", grabacion ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@recontacto", recontacto ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@casos_previos", casos_previos);
                        cmd.Parameters.AddWithValue("@transferencias", transferencias);
                        cmd.Parameters.AddWithValue("@tipo", tipo);

                        cmd.ExecuteNonQuery();

                        // Simular R-CAL-04 (Duplicados)
                        if (rnd.NextDouble() < 0.02)
                        {
                            cmd.ExecuteNonQuery(); // Ejecutar de nuevo para crear duplicado exacto
                            i++; // Contamos el duplicado en el total N
                        }
                    }

                    count++;
                    if (count % batchSize == 0) Console.WriteLine($"   Generados: {count:N0}...");
                }
            }
        }
    }
}