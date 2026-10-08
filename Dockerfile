FROM python:3.13-slim

WORKDIR /app

# Instalar dependencias del sistema y MS ODBC Driver 18
RUN apt-get update && apt-get install -y \
    curl \
    gnupg2 \
    unixodbc-dev \
    build-essential \
    && curl -fsSL https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor -o /usr/share/keyrings/microsoft-prod.gpg \
    && curl -fsSL https://packages.microsoft.com/config/debian/12/prod.list | tee /etc/apt/sources.list.d/mssql-release.list \
    && apt-get update \
    && ACCEPT_EULA=Y apt-get install -y msodbcsql18 \
    && apt-get clean \
    && rm -rf /var/lib/apt/lists/*

# Copiar requirements y desanclar versiones para Python 3.13
COPY DataSetGenerator/citizen-analytics/requirements.txt ./requirements.txt
RUN sed -i 's/==.*//g' requirements.txt && pip install --no-cache-dir -r requirements.txt

# El volumen montará el código en /app
EXPOSE 8888

CMD ["jupyter", "lab", "--port=8888", "--no-browser", "--ip=0.0.0.0", "--allow-root", "--notebook-dir=/app/DataSetGenerator/citizen-analytics"]
