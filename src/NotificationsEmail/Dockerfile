#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["/Hosts/NotificationsEmail.API/NotificationsEmail.API.csproj", "/Hosts/NotificationsEmail.API/"]
COPY ["/Application/NotificationsEmail.ScheduledSender/NotificationsEmail.ScheduledSender.csproj", "/Application/NotificationsEmail.ScheduledSender/"]
COPY ["/Application/NotificationsEmail.Services/NotificationsEmail.Services.csproj", "/Application/NotificationsEmail.Services/"]
COPY ["/Domain/NotificationsEmail.Domain/NotificationsEmail.Domain.csproj", "/Domain/NotificationsEmail.Domain/"]
COPY ["/Contracts/NotificationsEmail.Contracts/NotificationsEmail.Contracts.csproj", "/Contracts/NotificationsEmail.Contracts/"]
COPY ["/Infrastructure/NotificationsEmail.Repository/NotificationsEmail.Repository.csproj", "/Infrastructure/NotificationsEmail.Repository/"]
COPY ["/Infrastructure/NotificationsEmail.Mapper/NotificationsEmail.Mapper.csproj", "/Infrastructure/NotificationsEmail.Mapper/"]
COPY ["/Infrastructure/NotificationsEmail.SmtpNotifier/NotificationsEmail.Notification.csproj", "/Infrastructure/NotificationsEmail.SmtpNotifier/"]
COPY ["/Infrastructure/NotificationsEmail.Migrations/NotificationsEmail.Migrations.csproj", "/Infrastructure/NotificationsEmail.Migrations/"]
RUN dotnet restore "/Hosts/NotificationsEmail.API/NotificationsEmail.API.csproj"
COPY . .
WORKDIR "/src/Hosts/NotificationsEmail.API"
RUN dotnet build "NotificationsEmail.API.csproj" -o /app/build

FROM build AS publish
RUN dotnet publish "NotificationsEmail.API.csproj" -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NotificationsEmail.API.dll"]