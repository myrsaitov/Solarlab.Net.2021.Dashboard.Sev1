@ECHO OFF
:: Запускает docker-compose

:: Устанавливает заголовок окна
TITLE Run "docker-compose REBUILD and UP"

:: Запускает docker-compose
docker-compose up --detach --force-recreate --build
::docker-compose up --detach --no-deps --build advertisements.api

:: Удаляет устаревшие образы
docker image prune

PAUSE
