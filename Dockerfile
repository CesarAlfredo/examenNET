# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# 1. Copiamos la carpeta del proyecto completa al contenedor
# Esto copiará la subcarpeta "WebApplication1" dentro de "/src"
COPY . .

# 2. Entramos a la subcarpeta donde está el archivo .csproj
WORKDIR "/src/WebApplication1"

# 3. Restauramos y publicamos apuntando al archivo correcto
RUN dotnet restore "WebApplication1.csproj"
RUN dotnet publish "WebApplication1.csproj" -c Release -o /app/publish

# Etapa de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

# El nombre de la DLL suele ser el mismo que el .csproj
ENTRYPOINT ["dotnet", "WebApplication1.dll"]