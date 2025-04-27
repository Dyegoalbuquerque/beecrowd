# This stage is used when running from Visual Studio in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8090

# Install PostgreSQL client for database readiness check
RUN apt-get update && apt-get install -y postgresql-client && rm -rf /var/lib/apt/lists/*

# Copy the wait-for-db script to the container
COPY src/SalesApi/wait-for-db.sh /app/

# Make the script executable
RUN chmod +x /app/wait-for-db.sh

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy .csproj files to the appropriate directories
COPY ["src/SalesApi/SalesApi.Presentation/SalesApi.Presentation.csproj", "SalesApi.Presentation/"]
COPY ["src/SalesApi/SalesApi.Domain/SalesApi.Domain.csproj", "SalesApi.Domain/"]
COPY ["src/SalesApi/SalesApi.Infrastructure/SalesApi.Infrastructure.csproj", "SalesApi.Infrastructure/"]
COPY ["src/SalesApi/SalesApi.Application/SalesApi.Application.csproj", "SalesApi.Application/"]

# Restore dependencies
RUN dotnet restore "SalesApi.Presentation/SalesApi.Presentation.csproj"

# Copy the remaining files
COPY src/SalesApi/SalesApi.Presentation/ SalesApi.Presentation/
COPY src/SalesApi/SalesApi.Domain/ SalesApi.Domain/
COPY src/SalesApi/SalesApi.Infrastructure/ SalesApi.Infrastructure/
COPY src/SalesApi/SalesApi.Application/ SalesApi.Application/

WORKDIR "/src/SalesApi.Presentation"
RUN dotnet build "SalesApi.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
RUN dotnet publish "SalesApi.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from Visual Studio in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS=http://+:8090

# Add the wait-for-db script to the ENTRYPOINT
ENTRYPOINT ["/app/wait-for-db.sh", "dotnet", "SalesApi.Presentation.dll"]
