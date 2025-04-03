# Base Image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Build Environment
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY UserProfileApi.csproj .
RUN dotnet restore UserProfileApi.csproj
COPY . .
RUN dotnet build UserProfileApi.csproj -c Release -o /app/build

# Publish App
FROM build AS publish
RUN dotnet publish UserProfileApi.csproj -c Release -o /app/publish

# Final Image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserProfileApi.dll"]