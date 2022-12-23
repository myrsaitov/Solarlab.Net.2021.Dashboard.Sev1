@ECHO OFF
:: Выполняет сборку проекта в DOCKER

:: Устанавливает заголовок окна
TITLE Run "docker BUILD Advertisements"

:: Выполняет сборку проекта в DOCKER
docker build --no-cache^
             -t myrsaitov/advertisements.api^
             -f ./src/Advertisements/Hosts/Advertisements.Api/Dockerfile^
             ./

PAUSE
