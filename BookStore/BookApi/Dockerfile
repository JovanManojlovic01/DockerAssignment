# Base runtime image for production
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
ENV DOTNET_RUNNING_IN_CONTAINER=true

# Build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project file and restore dependencies
COPY ["BookApi.csproj", "./"]
RUN dotnet restore "BookApi.csproj"

# Copy the remaining files and build
COPY . .
WORKDIR "."
RUN dotnet build "BookApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish image for optimized runtime
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "BookApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookApi.dll"]
