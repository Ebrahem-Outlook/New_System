#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["New_System.API/New_System.API.csproj", "New_System.API/"]
COPY ["New_System.Infrastructure/New_System.Infrastructure.csproj", "New_System.Infrastructure/"]
COPY ["New_System.Application/New_System.Application.csproj", "New_System.Application/"]
COPY ["New_System.Domain/New_System.Domain.csproj", "New_System.Domain/"]
RUN dotnet restore "./New_System.API/New_System.API.csproj"
COPY . .
WORKDIR "/src/New_System.API"
RUN dotnet build "./New_System.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./New_System.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "New_System.API.dll"]