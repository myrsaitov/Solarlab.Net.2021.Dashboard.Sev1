@ECHO OFF
:: Выполняет сборку проекта в DOCKER

:: Устанавливает заголовок окна
TITLE Run "docker BUILD Accounts"

:: Выполняет сборку проекта в DOCKER
docker build --no-cache^
             -t myrsaitov/bulleting_board-services-accounts^
             -f ./src/Accounts/Hosts/Accounts.Api/Dockerfile^
             ./

PAUSE
