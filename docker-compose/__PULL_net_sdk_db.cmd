@ECHO OFF
:: Скачивает необходимые образы заранее
:: Это нужно, если плохая связь и из-за этого возникает ошибка при сборке
::     Error response from daemon: Get "https://registry-1.docker.io/v2/library/postgres/manifests/sha256:cef3a11de97d6aeb94e2d8efdbeecffc3565a6de7ffaf234ee1a2acad559cbcb": net/http: TLS handshake timeout

:: Заголовок окна - путь и имя файла
TITLE %~0

:: Скачивает образы

ECHO;
ECHO;
ECHO ******************************************************
ECHO * Postgres
ECHO ******************************************************
ECHO;
docker pull postgres:15.1

ECHO;
ECHO;
ECHO ******************************************************
ECHO * Redis
ECHO ******************************************************
ECHO;
docker pull bitnami/redis:7.0.7

ECHO;
ECHO;
ECHO ******************************************************
ECHO * .NET
ECHO ******************************************************
ECHO;
docker pull mcr.microsoft.com/dotnet/aspnet:5.0

ECHO;
ECHO;
ECHO ******************************************************
ECHO * .NET SDK
ECHO ******************************************************
ECHO;
docker pull mcr.microsoft.com/dotnet/sdk:5.0

PAUSE
