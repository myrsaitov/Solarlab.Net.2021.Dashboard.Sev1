FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Hosts/DemoApi.Migrations/DemoApi.Migrations.csproj", "DemoApi.Migrations/"]
RUN dotnet restore "src/Hosts/DemoApi.Migrations/DemoApi.Migrations.csproj"
COPY . .
WORKDIR "/src/DemoApi.Migrations"
RUN dotnet build "DemoApi.Migrations.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DemoApi.Migrations.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DemoApi.Migrations.dll"]
