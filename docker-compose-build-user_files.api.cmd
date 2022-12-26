@ECHO OFF
:: Запускает docker-compose

:: Заголовок окна - путь и имя файла
TITLE %~0

:: Запускает docker-compose
docker-compose build --no-cache user_files.api

:: Удаляет устаревшие образы
docker image prune

PAUSE
