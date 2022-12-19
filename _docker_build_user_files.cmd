@ECHO OFF
:: Выполняет сборку проекта в DOCKER

:: Устанавливает заголовок окна
TITLE Run "docker BUILD UserFiles"

:: Выполняет сборку проекта в DOCKER
docker build --no-cache^
             -t myrsaitov/bulleting_board-services-user_files^
             -f ./src/UserFiles/Hosts/UserFiles.Api/Dockerfile^
             ./

PAUSE
