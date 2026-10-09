# Build wheel/dependency layer separately so build tooling never ships in runtime.
FROM python:3.11.16-slim-bookworm AS python-deps
WORKDIR /build
COPY DataSetGenerator/servicio-ciudadano-analytics/requirements.txt ./requirements.txt
RUN python -m pip install --no-cache-dir --prefix=/install -r requirements.txt

# Minimal Python runtime plus only the native libraries needed at runtime.
FROM python:3.11.16-slim-bookworm AS runtime
ENV DEBIAN_FRONTEND=noninteractive \
    PYTHONDONTWRITEBYTECODE=1 \
    PYTHONUNBUFFERED=1 \
    PIP_DISABLE_PIP_VERSION_CHECK=1 \
    PYTHONPATH=/usr/local/lib/python3.11/site-packages \
    HOME=/tmp \
    JUPYTER_RUNTIME_DIR=/tmp/jupyter-runtime \
    JUPYTER_CONFIG_DIR=/tmp/jupyter-config \
    USER=app

RUN apt-get update \
 && apt-get install -y --no-install-recommends ca-certificates curl gnupg unixodbc libgomp1 \
 && install -d -m 0755 /etc/apt/keyrings \
 && curl -fsSL https://packages.microsoft.com/keys/microsoft.asc \
    | gpg --dearmor -o /etc/apt/keyrings/microsoft-prod.gpg \
 && chmod 0644 /etc/apt/keyrings/microsoft-prod.gpg \
 && printf 'deb [arch=%s signed-by=/etc/apt/keyrings/microsoft-prod.gpg] https://packages.microsoft.com/debian/12/prod bookworm main\n' "$(dpkg --print-architecture)" \
    > /etc/apt/sources.list.d/mssql-release.list \
 && apt-get update \
 && ACCEPT_EULA=Y apt-get install -y --no-install-recommends msodbcsql18 \
 && apt-get purge -y --auto-remove curl gnupg \
 && rm -rf /var/lib/apt/lists/* /var/cache/apt/*

COPY --from=python-deps /install/ /usr/local/
WORKDIR /app
COPY DataSetGenerator/servicio-ciudadano-analytics/cargar_datos.py ./
COPY DataSetGenerator/servicio-ciudadano-analytics/src/ ./src/
COPY DataSetGenerator/servicio-ciudadano-analytics/scripts/ ./scripts/
COPY sql/ /app/sql/

# The Compose user can be mapped to the host UID/GID for writable bind mounts.
USER 10001:10001
EXPOSE 8888
CMD ["python", "cargar_datos.py"]
