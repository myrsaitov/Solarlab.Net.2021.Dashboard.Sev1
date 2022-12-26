@ECHO OFF
:: Выполняет сборку проекта в DOCKER

:: Заголовок окна - путь и имя файла
TITLE %~0

:: Выполняет сборку проекта в DOCKER
docker build --no-cache^
             -t myrsaitov/user_files.api^
             -f ./src/UserFiles/Hosts/UserFiles.Api/Dockerfile^
             ./

PAUSE
