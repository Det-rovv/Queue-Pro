FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Queue-Pro.API/Queue-Pro.API.csproj", "Queue-Pro.API/"]
COPY ["Queue-Pro.Infrastructure/Queue-Pro.Infrastructure.csproj", "Queue-Pro.Infrastructure/"]
COPY ["Queue-Pro.Domain/Queue-Pro.Domain.csproj", "Queue-Pro.Domain/"]
COPY ["Queue-Pro.Application/Queue-Pro.Application.csproj", "Queue-Pro.Application/"]
RUN dotnet restore "Queue-Pro.API/Queue-Pro.API.csproj"
COPY . .
WORKDIR "/src/Queue-Pro.API"
RUN dotnet build "./Queue-Pro.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Queue-Pro.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Queue-Pro.API.dll"]
