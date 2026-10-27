# Estágio de Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copia o .csproj de dentro da subpasta para o container
COPY ["ApiMasters/ApiMasters.csproj", "./"]
RUN dotnet restore

# Copia todo o resto do código da subpasta para o container
COPY ApiMasters/. .
RUN dotnet publish -c Release -o /app/publish

# Estágio de Execução (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
EXPOSE 8080
COPY --from=build /app/publish .

# Lembre-se de trocar "SuaApi.dll" pelo nome real da sua DLL
ENTRYPOINT ["dotnet", "ApiMasters"]
