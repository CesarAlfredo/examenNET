# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiamos TODO el contenido de la carpeta actual al contenedor
COPY . .

# Buscamos y restauramos el proyecto (el asterisco ayuda a encontrarlo)
RUN dotnet restore "./WebApplication1.csproj"

# Publicamos la aplicación
RUN dotnet publish "./WebApplication1.csproj" -c Release -o /app/publish

# Etapa de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .

# Configuración de puerto para Render
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

ENTRYPOINT ["dotnet", "WebApplication1.dll"]