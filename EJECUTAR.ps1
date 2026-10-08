# ============================================================
#  SERVICIO CIUDADANO 1800 - MENU DE EJECUCION AUTOMATICA
#  Proyecto: citizen-service-1800-data-mining
#  Archivo: EJECUTAR.ps1
#
#  Como ejecutar:
#    Opcion A (recomendado): doble clic en EJECUTAR.cmd
#    Opcion B: boton derecho sobre este archivo > Ejecutar con PowerShell
#    Opcion C: powershell -ExecutionPolicy Bypass -File EJECUTAR.ps1
# ============================================================

$ErrorActionPreference = "Continue"
[Console]::OutputEncoding = [System.Text.Encoding]::UTF8
$env:PYTHONUTF8 = "1"
$env:PYTHONIOENCODING = "utf-8"

$base = $PSScriptRoot
if (-not $base) { $base = Split-Path -Parent $MyInvocation.MyCommand.Path }

$server = "localhost\SQLEXPRESS"
$dbname = "ServicioCiudadanoDW"

# --- Variables que usan los notebooks y los scripts de Python ---
$env:DB_SERVER   = $server
$env:DB_NAME     = $dbname
$env:DB_USER     = "sa"
$env:DB_PASSWORD = "12345678"
$env:DB_DRIVER   = "ODBC Driver 17 for SQL Server"
$env:DB_TRUSTED  = "no"

# --- Localizar sqlcmd ---
$sqlcmd = (Get-Command sqlcmd -ErrorAction SilentlyContinue).Source
if (-not $sqlcmd) {
    $sqlcmd = "C:\Program Files\Microsoft SQL Server\Client SDK\ODBC\170\Tools\Binn\SQLCMD.EXE"
}

# --- Rutas del proyecto ---
$sql01   = Join-Path $base "01 - DATAWAREHOUSE.SQL"
$sql02   = Join-Path $base "02 - CREACION DE DATASETS.SQL"
$genDir  = Join-Path $base "DataSetGenerator\DataSetGenerator"
$pyDir   = Join-Path $base "DataSetGenerator\citizen-analytics"
$venvPy  = Join-Path $pyDir "venv\Scripts\python.exe"
$dataDir = Join-Path $base "data"

function Titulo($texto) {
    Write-Host ""
    Write-Host "============================================================" -ForegroundColor Cyan
    Write-Host "  $texto" -ForegroundColor Cyan
    Write-Host "============================================================" -ForegroundColor Cyan
}

function Confirmar($mensaje) {
    $r = Read-Host "$mensaje (S/N)"
    return ($r -eq "S" -or $r -eq "s")
}

function Fase1_DW {
    Titulo "FASE 1 - Base de datos (01 - DATAWAREHOUSE.SQL)"
    & $sqlcmd -S $server -E -i $sql01
    Write-Host ""
    Write-Host "Crea la base ServicioCiudadanoDW y la tabla cruda v0_crudo." -ForegroundColor Yellow
}

function Fase2_Generador {
    Titulo "FASE 2 - Generar 100,000 registros (C#)"
    Write-Host "Esto puede tardar de 2 a 5 minutos. No cierres esta ventana..." -ForegroundColor Yellow
    Push-Location $genDir
    dotnet run
    Pop-Location
}

function Fase3_ETL {
    Titulo "FASE 3 - Limpieza de datos (02 - CREACION DE DATASETS.SQL)"
    & $sqlcmd -S $server -E -d $dbname -i $sql02
    Write-Host ""
    Write-Host "Crea la vista limpia vw_v1_limpio con las reglas de gobierno." -ForegroundColor Yellow
}

function Fase4_Python {
    Titulo "FASE 4 - Entorno Python (venv + librerias)"
    if (-not (Test-Path $venvPy)) {
        Write-Host ">> venv no existe, creandolo..." -ForegroundColor Green
        Push-Location $pyDir
        python -m venv venv
        Pop-Location
    } else {
        Write-Host ">> venv ya existe, se reutiliza." -ForegroundColor Green
    }
    Push-Location $pyDir
    & $venvPy -m pip install -r requirements.txt
    Pop-Location
}

function Fase5_Excel {
    Titulo "FASE 5 - Exportar datos a Excel (carpeta data)"
    if (-not (Test-Path $venvPy)) {
        Write-Host "ERROR: primero ejecuta la FASE 4 (entorno Python)." -ForegroundColor Red
        return
    }
    if (-not (Test-Path $dataDir)) { New-Item -ItemType Directory -Path $dataDir | Out-Null }
    Push-Location $pyDir
    & $venvPy exportar_excel.py
    Pop-Location
    Write-Host ""
    Write-Host "Revisa la carpeta: $dataDir" -ForegroundColor Yellow
}

function Abrir_Jupyter {
    Titulo "JUPYTER LAB"
    if (-not (Test-Path $venvPy)) {
        Write-Host "ERROR: primero ejecuta la FASE 4 (entorno Python)." -ForegroundColor Red
        return
    }
    Write-Host "Se abrira el navegador. Presiona Ctrl+C en esta ventana" -ForegroundColor Yellow
    Write-Host "para detener Jupyter cuando termines." -ForegroundColor Yellow
    Push-Location (Join-Path $pyDir "notebooks")
    & $venvPy -m jupyter lab
    Pop-Location
}

function TodoCompleto {
    if (-not (Confirmar "Se regeneraran los datos (v0_crudo se vacia y se crean 100,000 registros nuevos). Continuar?")) {
        Write-Host "Cancelado." -ForegroundColor Yellow
        return
    }
    Fase1_DW
    Fase2_Generador
    Fase3_ETL
    Fase4_Python
    Fase5_Excel
    Write-Host ""
    Write-Host "LISTO. Usa la opcion 7 para abrir Jupyter Lab (notebooks)." -ForegroundColor Cyan
}

# ============================================================
# MENU PRINCIPAL
# ============================================================
$salir = $false
while (-not $salir) {
    Titulo "SERVICIO CIUDADANO 1800 - MENU DE EJECUCION"
    Write-Host "  1. EJECUTAR TODO (FASE 1 a 5, recomendado la primera vez)"
    Write-Host "  2. FASE 1: Base de datos (01 - DATAWAREHOUSE.SQL)"
    Write-Host "  3. FASE 2: Generar 100,000 registros (C#)"
    Write-Host "  4. FASE 3: Limpieza de datos / vista (02 - DATASETS)"
    Write-Host "  5. FASE 4: Entorno Python (venv + librerias)"
    Write-Host "  6. FASE 5: Exportar a Excel (carpeta data)"
    Write-Host "  7. Abrir Jupyter Lab (notebooks)"
    Write-Host "  0. Salir"
    Write-Host ""
    $op = Read-Host "Elige una opcion"

    switch ($op) {
        "1" {
            TodoCompleto
        }
        "2" {
            if (Confirmar "Se borrara y recreara la tabla v0_crudo (los datos actuales se pierden). Continuar?") {
                Fase1_DW
            } else { Write-Host "Cancelado." -ForegroundColor Yellow }
        }
        "3" {
            if (Confirmar "v0_crudo se vaciara y se generaran 100,000 registros nuevos. Continuar?") {
                Fase2_Generador
            } else { Write-Host "Cancelado." -ForegroundColor Yellow }
        }
        "4" { Fase3_ETL }
        "5" { Fase4_Python }
        "6" { Fase5_Excel }
        "7" { Abrir_Jupyter }
        "0" { $salir = $true }
        default { Write-Host "Opcion no valida." -ForegroundColor Red }
    }

    if (-not $salir -and $op -match "^[1-7]$") {
        Write-Host ""
        Read-Host "Presiona ENTER para volver al menu"
    }
}

Write-Host ""
Write-Host "Hasta luego." -ForegroundColor Cyan
