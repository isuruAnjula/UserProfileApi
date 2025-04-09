# Base Image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 7178

# Build Environment
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY UserProfileApiCleanArc/*.csproj ./UserProfileApiCleanArc/
COPY UserProfileApi.Domain/*.csproj ./UserProfileApi.Domain/
COPY UserProfileApi.Infrastructure/*.csproj ./UserProfileApi.Infrastructure/
COPY UserProfileApi.Application/*.csproj ./UserProfileApi.Application/
COPY *.sln .
RUN dotnet restore UserProfileApiCleanArc.sln
COPY . .
RUN dotnet build UserProfileApiCleanArc.sln -c Release -o /app/build

# Publish App
FROM build AS publish
RUN dotnet publish UserProfileApiCleanArc/UserProfileApiCleanArc.csproj -c Release -o /app/publish

# Final Image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserProfileApiCleanArc.dll"] 