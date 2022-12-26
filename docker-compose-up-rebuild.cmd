@ECHO OFF
:: Запускает docker-compose

:: Заголовок окна - путь и имя файла
TITLE %~0

:: Запускает docker-compose
docker-compose up --detach --force-recreate --build
::docker-compose up --detach --no-deps --build advertisements.api

:: Удаляет устаревшие образы
docker image prune

PAUSE
