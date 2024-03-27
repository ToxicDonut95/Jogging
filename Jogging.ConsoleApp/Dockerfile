FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Jogging.ConsoleApp/Jogging.ConsoleApp.csproj", "Jogging.ConsoleApp/"]
RUN dotnet restore "Jogging.ConsoleApp/Jogging.ConsoleApp.csproj"
COPY . .
WORKDIR "/src/Jogging.ConsoleApp"
RUN dotnet build "Jogging.ConsoleApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Jogging.ConsoleApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Jogging.ConsoleApp.dll"]
