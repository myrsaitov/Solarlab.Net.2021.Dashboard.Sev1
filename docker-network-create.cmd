@ECHO OFF
:: Запускает docker network create

:: Устанавливает заголовок окна
TITLE Run "docker network create"

:: Запускает docker inspect
docker network create -d bridge dev-network

PAUSE
