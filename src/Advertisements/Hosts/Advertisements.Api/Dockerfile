#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Advertisements/Hosts/Advertisements.Api/Advertisements.Api.csproj", "src/Advertisements/Hosts/Advertisements.Api/"]
COPY ["src/Advertisements/Infrastructure/Advertisements.DataAccess/Advertisements.DataAccess.csproj", "src/Advertisements/Infrastructure/Advertisements.DataAccess/"]
COPY ["src/Advertisements/Application/Advertisements.Application/Advertisements.AppServices.csproj", "src/Advertisements/Application/Advertisements.Application/"]
COPY ["src/Accounts/Contracts/Accounts.Contracts/Accounts.Contracts.csproj", "src/Accounts/Contracts/Accounts.Contracts/"]
COPY ["src/UserFiles/Contracts/UserFiles.Contracts/UserFiles.Contracts.csproj", "src/UserFiles/Contracts/UserFiles.Contracts/"]
COPY ["src/Advertisements/Contracts/Advertisements.Contracts/Advertisements.Contracts.csproj", "src/Advertisements/Contracts/Advertisements.Contracts/"]
COPY ["src/Advertisements/Domain/Advertisements.Domain/Advertisements.Domain.csproj", "src/Advertisements/Domain/Advertisements.Domain/"]
COPY ["src/Advertisements/Infrastructure/Advertisements.Mapper/Advertisements.MapsterMapper.csproj", "src/Advertisements/Infrastructure/Advertisements.Mapper/"]
RUN dotnet restore "src/Advertisements/Hosts/Advertisements.Api/Advertisements.Api.csproj"
COPY . .
WORKDIR "/src/src/Advertisements/Hosts/Advertisements.Api"
RUN dotnet build "Advertisements.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Advertisements.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Advertisements.Api.dll"]