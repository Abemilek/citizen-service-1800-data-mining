#!/bin/bash
echo "Waiting for SQL Server to be available..."
until sqlcmd -S db -U SA -P "J0AhMXX4H0QBrRr8R1U098y8aA1@" -C -Q "SELECT 1" &> /dev/null; do
    echo "SQL Server is unavailable - sleeping"
    sleep 3
done

echo "SQL Server is up. Checking if database already exists..."
DB_EXISTS=$(sqlcmd -S db -U SA -P "J0AhMXX4H0QBrRr8R1U098y8aA1@" -C -Q "SET NOCOUNT ON; SELECT COUNT(*) FROM sys.databases WHERE name = 'ServicioCiudadanoDW'" -h -1 | tr -d ' ')

if [ "$DB_EXISTS" -eq "0" ]; then
    echo "Database doesn't exist. Running 01 - DATAWAREHOUSE.SQL"
    sqlcmd -S db -U SA -P "J0AhMXX4H0QBrRr8R1U098y8aA1@" -C -i "01 - DATAWAREHOUSE.SQL"
    
    echo "Modifying C# Connection String for Docker..."
    sed -i 's/Server=localhost/Server=db/g' DataSetGenerator/DataSetGenerator/Program.cs
    sed -i 's/TuPassword123!/J0AhMXX4H0QBrRr8R1U098y8aA1@/g' DataSetGenerator/DataSetGenerator/Program.cs
    
    echo "Running C# Generator"
    cd DataSetGenerator/DataSetGenerator
    dotnet run
    cd ../../
    
    echo "Running 02 - CREACION DE DATASETS.SQL"
    sqlcmd -S db -U SA -P "J0AhMXX4H0QBrRr8R1U098y8aA1@" -d ServicioCiudadanoDW -C -i "02 - CREACION DE DATASETS.SQL"
    
    echo "Database initialization completed successfully!"
else
    echo "Database ServicioCiudadanoDW already exists. Skipping initialization."
fi
