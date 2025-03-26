# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /app
COPY ["webapi/src/BovIQ_E2.API/BovIQ_E2.API.csproj", "BovIQ_E2.API/"]
COPY ["webapi/src/Core/BovIQ.Domain/BovIQ.Domain.csproj", "BovIQ.Domain/"]
COPY ["webapi/src/Core/BovIQ.Persistence/BovIQ.Persistence.csproj", "BovIQ.Persistence/"]
RUN dotnet restore "./BovIQ_E2.API/BovIQ_E2.API.csproj"
COPY . .
WORKDIR "/app/webapi/src/BovIQ_E2.API"
RUN dotnet build "./BovIQ_E2.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BovIQ_E2.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BovIQ_E2.API.dll"]