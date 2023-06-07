#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["API/N5.PermissionsManager.API/N5.PermissionsManager.API.csproj", "API/N5.PermissionsManager.API/"]
COPY ["BuildingBlocks/Application/N5.BuildingBlocks.Application/N5.BuildingBlocks.Application.csproj", "BuildingBlocks/Application/N5.BuildingBlocks.Application/"]
COPY ["BuildingBlocks/Domain/N5.BuildingBlocks.Domain/N5.BuildingBlocks.Domain.csproj", "BuildingBlocks/Domain/N5.BuildingBlocks.Domain/"]
COPY ["BuildingBlocks/Infrastructure/N5.BuildingBlocks.Infrastructure/N5.BuildingBlocks.Infrastructure.csproj", "BuildingBlocks/Infrastructure/N5.BuildingBlocks.Infrastructure/"]
COPY ["Module/Permissions/Application/N5.PermissionsManager.Application/N5.PermissionsManager.Application.csproj", "Module/Permissions/Application/N5.PermissionsManager.Application/"]
COPY ["Module/Permissions/Domain/N5.PermissionsManager.Domain/N5.PermissionsManager.Domain.csproj", "Module/Permissions/Domain/N5.PermissionsManager.Domain/"]
COPY ["Module/Permissions/Infrastructure/N5.PermissionsManager.Infrastructure/N5.PermissionsManager.Infrastructure.csproj", "Module/Permissions/Infrastructure/N5.PermissionsManager.Infrastructure/"]
RUN dotnet restore "API/N5.PermissionsManager.API/N5.PermissionsManager.API.csproj"
COPY . .
WORKDIR "/src/API/N5.PermissionsManager.API"
RUN dotnet build "N5.PermissionsManager.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "N5.PermissionsManager.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "N5.PermissionsManager.API.dll"]