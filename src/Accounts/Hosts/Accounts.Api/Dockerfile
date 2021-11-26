#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Accounts/Hosts/Accounts.Api/Accounts.Api.csproj", "src/Accounts/Hosts/Accounts.Api/"]
COPY ["src/Accounts/Infrastructure/Accounts.DataAccess/Accounts.DataAccess.csproj", "src/Accounts/Infrastructure/Accounts.DataAccess/"]
COPY ["src/Accounts/Domain/Accounts.Domain/Accounts.Domain.csproj", "src/Accounts/Domain/Accounts.Domain/"]
COPY ["src/Accounts/Application/Accounts.Application/Accounts.AppServices.csproj", "src/Accounts/Application/Accounts.Application/"]
COPY ["src/Accounts/Contracts/Accounts.Contracts/Accounts.Contracts.csproj", "src/Accounts/Contracts/Accounts.Contracts/"]
COPY ["src/Advertisements/Contracts/Advertisements.Contracts/Advertisements.Contracts.csproj", "src/Advertisements/Contracts/Advertisements.Contracts/"]
COPY ["src/UserFiles/Contracts/UserFiles.Contracts/UserFiles.Contracts.csproj", "src/UserFiles/Contracts/UserFiles.Contracts/"]
COPY ["src/Accounts/Infrastructure/Accounts.Mapper/Accounts.MapsterMapper.csproj", "src/Accounts/Infrastructure/Accounts.Mapper/"]
RUN dotnet restore "src/Accounts/Hosts/Accounts.Api/Accounts.Api.csproj"
COPY . .
WORKDIR "/src/src/Accounts/Hosts/Accounts.Api"
RUN dotnet build "Accounts.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Accounts.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Accounts.Api.dll"]