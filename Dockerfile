# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

RUN dotnet dev-certs https

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj .
RUN dotnet restore

# Copy everything else and build
COPY . .
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .

ENV ASPNETCORE_URLS=https://+:8081;http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Development
ENV MONGO_DB=mongodb://mongodb:27017
ENV SAVE_PATH=/app

EXPOSE 8080 8081
ENTRYPOINT ["dotnet", "ml.dll"]
