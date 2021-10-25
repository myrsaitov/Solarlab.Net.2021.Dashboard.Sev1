#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["/Hosts/CommentAPI/Comments.API.csproj", "/Hosts/CommentAPI/"]
COPY ["/Infrastructure/Mapper/Comments.Mapper.csproj", "/Infrastructure/Mapper/"]
COPY ["/Domain/Comments.Domain.csproj", "/Domain/"]
COPY ["/Contracts/Comments.Contracts.csproj", "/Contracts/"]
COPY ["/Infrastructure/CommentMigrations/Comments.Migrations.csproj", "/Infrastructure/CommentMigrations/"]
COPY ["/Infrastructure/Repository/Comments.Repository.csproj", "/Infrastructure/Repository/"]
COPY ["/Application/CommentService/Comments.Services.csproj", "/Application/CommentService/"]
RUN dotnet restore "/Hosts/CommentAPI/Comments.API.csproj"
COPY . .
WORKDIR "/src/Hosts/CommentAPI"
RUN dotnet build "Comments.API.csproj" -o /app/build

FROM build AS publish
RUN dotnet publish "Comments.API.csproj" -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Comments.API.dll"]