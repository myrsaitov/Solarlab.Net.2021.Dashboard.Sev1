#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/UserFiles/Hosts/UserFiles.Api/UserFiles.Api.csproj", "src/UserFiles/Hosts/UserFiles.Api/"]
COPY ["src/UserFiles/Application/UserFiles.Application/UserFiles.AppServices.csproj", "src/UserFiles/Application/UserFiles.Application/"]
COPY ["src/UserFiles/Domain/UserFiles.Domain/UserFiles.Domain.csproj", "src/UserFiles/Domain/UserFiles.Domain/"]
COPY ["src/UserFiles/Contracts/UserFiles.Contracts/UserFiles.Contracts.csproj", "src/UserFiles/Contracts/UserFiles.Contracts/"]
COPY ["src/Accounts/Contracts/Accounts.Contracts/Accounts.Contracts.csproj", "src/Accounts/Contracts/Accounts.Contracts/"]
COPY ["src/Advertisements/Contracts/Advertisements.Contracts/Advertisements.Contracts.csproj", "src/Advertisements/Contracts/Advertisements.Contracts/"]
COPY ["src/Accounts/Domain/Accounts.Domain/Accounts.Domain.csproj", "src/Accounts/Domain/Accounts.Domain/"]
COPY ["src/UserFiles/Infrastructure/UserFiles.Mapper/UserFiles.MapsterMapper.csproj", "src/UserFiles/Infrastructure/UserFiles.Mapper/"]
COPY ["src/UserFiles/Infrastructure/UserFiles.DataAccess/UserFiles.DataAccess.csproj", "src/UserFiles/Infrastructure/UserFiles.DataAccess/"]
RUN dotnet restore "src/UserFiles/Hosts/UserFiles.Api/UserFiles.Api.csproj"
COPY . .
WORKDIR "/src/src/UserFiles/Hosts/UserFiles.Api"
RUN dotnet build "UserFiles.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserFiles.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserFiles.Api.dll"]