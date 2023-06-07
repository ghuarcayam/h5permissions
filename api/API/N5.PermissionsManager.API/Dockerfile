#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["N5.PermissionsManager.API/N5.PermissionsManager.API.csproj", "N5.PermissionsManager.API/"]
RUN dotnet restore "N5.PermissionsManager.API/N5.PermissionsManager.API.csproj"
COPY . .
WORKDIR "/src/N5.PermissionsManager.API"
RUN dotnet build "N5.PermissionsManager.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "N5.PermissionsManager.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "N5.PermissionsManager.API.dll"]