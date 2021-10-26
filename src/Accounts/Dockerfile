#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["/Hosts/Accounts.Api/Accounts.Api.csproj", "/Hosts/Accounts.Api/"]
COPY ["/Application/Accounts.Application/Accounts.Application.csproj", "/Application/Accounts.Application/"]
COPY ["/Domain/Accounts.Domain/Accounts.Domain.csproj", "/Domain/Accounts.Domain/"]
COPY ["/Infrastructure/Accounts.DataAccess/Accounts.DataAccess.csproj", "/Infrastructure/Accounts.DataAccess/"]
COPY ["/Infrastructure/Accounts.Mapper/Accounts.MapsterMapper.csproj", "/Infrastructure/Accounts.Mapper/"]
RUN dotnet restore "/Hosts/Accounts.Api/Accounts.Api.csproj"
COPY . .
WORKDIR "/src/Hosts/Accounts.Api"
RUN dotnet build "Accounts.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Accounts.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Accounts.Api.dll"]