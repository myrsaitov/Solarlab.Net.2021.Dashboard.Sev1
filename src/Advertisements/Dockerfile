#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["/Hosts/Advertisements.Api/Advertisements.Api.csproj", "/Hosts/Advertisements.Api/"]
COPY ["/Application/Advertisements.Application/Advertisements.Application.csproj", "/Application/Advertisements.Application/"]
COPY ["/Domain/Advertisements.Domain/Advertisements.Domain.csproj", "/Domain/Advertisements.Domain/"]
COPY ["/Infrastructure/Advertisements.DataAccess/Advertisements.DataAccess.csproj", "/Infrastructure/Advertisements.DataAccess/"]
COPY ["/Infrastructure/Advertisements.Mapper/Advertisements.MapsterMapper.csproj", "/Infrastructure/Advertisements.Mapper/"]
RUN dotnet restore "/Hosts/Advertisements.Api/Advertisements.Api.csproj"
COPY . .
WORKDIR "/src/Hosts/Advertisements.Api"
RUN dotnet build "Advertisements.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Advertisements.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Advertisements.Api.dll"]