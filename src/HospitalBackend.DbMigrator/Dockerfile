FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/HospitalBackend.DbMigrator/HospitalBackend.DbMigrator.csproj", "src/HospitalBackend.DbMigrator/"]
COPY ["src/HospitalBackend.DataAccess/HospitalBackend.DataAccess.csproj", "src/HospitalBackend.DataAccess/"]
COPY ["src/HospitalBackend.Domain/HospitalBackend.Domain.csproj", "src/HospitalBackend.Domain/"]
RUN dotnet restore "src/HospitalBackend.DbMigrator/HospitalBackend.DbMigrator.csproj"
COPY . .
WORKDIR "/src/src/HospitalBackend.DbMigrator"
RUN dotnet build "HospitalBackend.DbMigrator.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "HospitalBackend.DbMigrator.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HospitalBackend.DbMigrator.dll"]
