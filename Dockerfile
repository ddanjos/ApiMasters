# Estágio de Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o .csproj de dentro da subpasta para o container
COPY ["ApiMasters/ApiMasters.csproj", "./"]
RUN dotnet restore

# Copia todo o resto do código da subpasta para o container
COPY ApiMasters/. .
RUN dotnet publish -c Release -o /app/publish

# Estágio de Execução (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
EXPOSE 8080
COPY --from=build /app/publish .

# CORREÇÃO AQUI: Adicionar a extensão .dll
ENTRYPOINT ["dotnet", "ApiMasters.dll"]
