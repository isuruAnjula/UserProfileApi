## UserProfileAPI ##
- A simple .NET 8.0 Web API that provides authenticated user profiles with Postgres and Auth0 authentication.

## Features
- JWT-based authentication using Auth0
- PostgreSQL database for storing user profiles
- Secure endpoints with authorization
- Docker support for containerized deployment

## Prerequisites
- .NET 8.0 SDK
- PostgreSQL database
- Auth0 account
- Docker

## Configuration
- Clone the repository
- Update appsettings.json with your database connection string and Auth0 credentials

## Run the API
# With Docker
- Build Docker image >> docker build -t userprofile-api .
- Run container >> docker run -p 8080:80 -d userprofile-api

# Without Docker
- dotnet restore
- dotnet build
- dotnet run

## API Endpoints
# GET (Check if API is running)
>> http://localhost:8080/

# GET (Retrieve authenticated user's profile)
>> http://localhost:8080/profile
