@ECHO OFF
:: Запускает docker-compose

:: Заголовок окна - путь и имя файла
TITLE %~0

:: Запускает docker-compose
docker-compose --env-file=.env^
               --file yml.docker-compose.networks.yml^
               --file yml.docker-compose.postgres.yml^
               --file yml.docker-compose.redis.yml^
               --file yml.docker-compose.back-end.yml^
               --file yml.docker-compose.back-end.override.yml^
               build --no-cache accounts.api

:: Удаляет устаревшие образы
docker image prune

PAUSE
