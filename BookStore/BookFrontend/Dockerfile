# Base runtime image for production
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
# Add container-specific environment variable
ENV DOTNET_RUNNING_IN_CONTAINER=true

# Build image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy and restore project dependencies
COPY ["BookFrontend.csproj", "."]
RUN dotnet restore "BookFrontend.csproj"

# Copy the remaining source and build the app
COPY . .
WORKDIR "."
RUN dotnet build "BookFrontend.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish image for optimized runtime
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "BookFrontend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookFrontend.dll"]
