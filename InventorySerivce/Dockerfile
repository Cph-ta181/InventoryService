# Base stadiet: bruger .net runtime. Exposer porte.
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build stage bruger .net sdk til at restore og bygge.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["InventorySerivce/InventorySerivce.csproj", "InventorySerivce/"]
RUN dotnet restore "./InventorySerivce/InventorySerivce.csproj"
COPY . .
WORKDIR "/src/InventorySerivce"
RUN dotnet build "./InventorySerivce.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage pakker projektet klar til distribution
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./InventorySerivce.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage angiver runtime og entrypoint
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InventorySerivce.dll"]