@ECHO OFF
:: Запускает docker-compose

:: Заголовок окна - путь и имя файла
TITLE %~0

:: Запускает docker-compose
docker-compose --env-file=.env.dev^
               --file docker-compose.networks.yml^
               --file docker-compose.postgres.yml^
               --file docker-compose.redis.yml^
               --file docker-compose.app-services.yml^
               --file docker-compose.app-services.override.yml^
               build --no-cache accounts.api

:: Удаляет устаревшие образы
docker image prune

PAUSE
