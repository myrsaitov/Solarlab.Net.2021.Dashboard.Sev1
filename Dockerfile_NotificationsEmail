#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/NotificationsEmail/Hosts/NotificationsEmail.API/NotificationsEmail.API.csproj", "src/NotificationsEmail/Hosts/NotificationsEmail.API/"]
COPY ["src/NotificationsEmail/Application/NotificationsEmail.ScheduledSender/NotificationsEmail.ScheduledSender.csproj", "src/NotificationsEmail/Application/NotificationsEmail.ScheduledSender/"]
COPY ["src/NotificationsEmail/Application/NotificationsEmail.Services/NotificationsEmail.Services.csproj", "src/NotificationsEmail/Application/NotificationsEmail.Services/"]
COPY ["src/NotificationsEmail/Domain/NotificationsEmail.Domain/NotificationsEmail.Domain.csproj", "src/NotificationsEmail/Domain/NotificationsEmail.Domain/"]
COPY ["src/NotificationsEmail/Contracts/NotificationsEmail.Contracts/NotificationsEmail.Contracts.csproj", "src/NotificationsEmail/Contracts/NotificationsEmail.Contracts/"]
COPY ["src/NotificationsEmail/Infrastructure/NotificationsEmail.Repository/NotificationsEmail.Repository.csproj", "src/NotificationsEmail/Infrastructure/NotificationsEmail.Repository/"]
COPY ["src/NotificationsEmail/Infrastructure/NotificationsEmail.Mapper/NotificationsEmail.Mapper.csproj", "src/NotificationsEmail/Infrastructure/NotificationsEmail.Mapper/"]
COPY ["src/NotificationsEmail/Infrastructure/NotificationsEmail.SmtpNotifier/NotificationsEmail.Notification.csproj", "src/NotificationsEmail/Infrastructure/NotificationsEmail.SmtpNotifier/"]
COPY ["src/NotificationsEmail/Infrastructure/NotificationsEmail.Migrations/NotificationsEmail.Migrations.csproj", "src/NotificationsEmail/Infrastructure/NotificationsEmail.Migrations/"]
RUN dotnet restore "src/NotificationsEmail/Hosts/NotificationsEmail.API/NotificationsEmail.API.csproj"
COPY . .
WORKDIR "/src/src/NotificationsEmail/Hosts/NotificationsEmail.API"
RUN dotnet build "NotificationsEmail.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NotificationsEmail.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NotificationsEmail.API.dll"]