# Notas del generador · Servicio Ciudadano 1800

Este documento conserva las instrucciones específicas del generador de datos compartidas para el curso. El punto de entrada actualizado para instalar y ejecutar el proyecto completo es el [README de la raíz](../README.md).

## Generador C# y MINI ETL

El generador reproduce las interacciones con la semilla `1800`, introduce defectos de calidad y escribe:

- `data/v0_crudo.csv`: datos antes del MINI ETL.
- `data/v1_limpio.csv`: datos después de deduplicar, estandarizar y validar rangos.

Desde la raíz del proyecto, con .NET 10:

```bash
dotnet run --project DataSetGenerator/DataSetGenerator -c Release
```

Para crear solo los CSV, sin SQL Server:

```bash
SOLO_CSV=1 dotnet run --project DataSetGenerator/DataSetGenerator -c Release
```

Para ajustar la cantidad y mantener una semilla reproducible:

```bash
N_REGISTROS=30000 SEMILLA=1800 dotnet run --project DataSetGenerator/DataSetGenerator -c Release
```

En PowerShell, define las variables con `$env:SOLO_CSV = "1"`, `$env:N_REGISTROS = "30000"` o `$env:SEMILLA = "1800"` antes de ejecutar `dotnet run`.

## Analítica y notebooks

El proyecto Python y sus instrucciones están en `servicio-ciudadano-analytics/`. Sus notebooks cubren:

| Notebook | Propósito |
| --- | --- |
| `01Prueba.ipynb` | Prueba de conexión al Data Warehouse |
| `03_modelado.ipynb` | Línea base con el dataset sucio (v0) |
| `03_modelado_correcto.ipynb` | Modelo con el dataset limpio (v1) y acciones |
| `04_comparacion_modelos.ipynb` | Efecto de la limpieza (v0 frente a v1) |
| `06_modelos.ipynb` | Comparación de ocho algoritmos |

Para generar datasets SQL/KPI y abrirlos, consulta la sección de ejecución local del [README](../README.md).
