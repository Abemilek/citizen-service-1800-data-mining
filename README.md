# Servicio Ciudadano 1800 - Data Mining Project (Case 15)

This repository contains a complete Data Mining pipeline designed to analyze and predict customer re-contact rates for "Servicio Ciudadano 1800". The project implements a CRISP-DM methodology, featuring synthetic data generation (in C#), Data Government and ETL processes (in SQL Server), and Exploratory Data Analysis & Predictive Modeling (in Python/Jupyter).

## 🚀 Recommended Setup: Using Docker (All platforms)

The easiest and recommended way to run this project is using Docker. This will automatically spin up the SQL Server database, run the C# generator to insert 100,000 records, apply the ETL rules, and start Jupyter Lab.

### Prerequisites
- Docker and Docker Compose installed.

### Steps
1. Open your terminal in the root directory of this project.
2. Run the following command:
   ```bash
   docker compose up --build -d
   ```
3. **Wait 1-2 minutes** for the C# generator to finish inserting the 100,000 records into the database. You can monitor the progress by running:
   ```bash
   docker compose logs -f db-init
   ```
4. Once it says "¡Proceso completado exitosamente!", open your browser and go to:
   👉 **http://localhost:8888/**
5. Look at your terminal for the Jupyter **token** (it will be printed in the logs of the `jupyter` container). You can find it easily by running:
   ```bash
   docker compose logs jupyter | grep token
   ```
6. Paste the token into the Jupyter login page, and you are ready to open the `.ipynb` notebooks!

---

## 🪟 Alternative Setup: Local Windows (No Docker)

If you prefer to run the project locally without Docker, you will need SQL Server, .NET 10.0 SDK, and Python installed on your Windows machine.

### Prerequisites
- Microsoft SQL Server Management Studio (SSMS) or Azure Data Studio.
- .NET 10.0 SDK.
- Python 3.10+ and Jupyter Lab.

### Steps

#### 1. Database Setup
1. Open SQL Server Management Studio (SSMS).
2. Execute the script `01 - DATAWAREHOUSE.SQL` to create the `ServicioCiudadanoDW` database and the `v0_crudo` table.
3. Open `DataSetGenerator/DataSetGenerator/Program.cs` and update the `connectionString` to point to your local Windows SQL Server instance (e.g., `Server=localhost;Integrated Security=true;...`).

#### 2. Data Generation
1. Open a PowerShell/CMD terminal inside the `DataSetGenerator/DataSetGenerator` folder.
2. Run the C# generator:
   ```cmd
   dotnet run
   ```
   *Wait until it finishes generating the 100,000 records.*

#### 3. ETL and Data Government
1. Go back to SSMS and execute the script `02 - CREACION DE DATASETS.SQL`.
2. This will create the view `vw_v1_limpio` containing the cleaned data.

#### 4. Python Modeling
1. Open a terminal in the root folder of this project.
2. (Optional) Create a virtual environment: `python -m venv venv` and activate it.
3. Install the required Python packages:
   ```cmd
   pip install pandas pyodbc scikit-learn matplotlib seaborn jupyterlab
   ```
4. Start Jupyter Lab:
   ```cmd
   jupyter lab
   ```
5. Inside the notebooks, update the `connection_string` variable to match your local Windows SQL Server credentials, and run all cells.
