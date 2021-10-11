#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/NotificationsEmail/Hosts/NotificationsEmail.API/NotificationsEmail.API.csproj", "src/NotificationsEmail/Hosts/NotificationsEmail.API/"]
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