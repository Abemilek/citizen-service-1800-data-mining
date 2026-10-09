# ============================================================
# Imagen del generador C# (.NET 10) - Servicio Ciudadano 1800
# Compila en una imagen SDK y ejecuta en la imagen runtime.
# ============================================================
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY DataSetGenerator.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o /out --no-restore

FROM mcr.microsoft.com/dotnet/runtime:10.0-noble-chiseled-extra
WORKDIR /app
COPY --from=build /out ./

# Los CSV de evidencia se escriben en /data (volumen montado por docker-compose)
ENV DATA_DIR=/data

# The .NET 10 runtime image provides the unprivileged `app` account.
USER app

ENTRYPOINT ["dotnet", "DataSetGenerator.dll"]
