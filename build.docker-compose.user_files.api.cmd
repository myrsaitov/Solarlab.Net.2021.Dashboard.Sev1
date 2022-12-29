@ECHO OFF
:: Запускает docker-compose

:: Заголовок окна - путь и имя файла
TITLE %~0

:: Запускает docker-compose
docker-compose --env-file=.env.dev^
               --file yml.docker-compose.networks.yml^
               --file yml.docker-compose.postgres.yml^
               --file yml.docker-compose.redis.yml^
               --file yml.docker-compose.app-services.yml^
               --file yml.docker-compose.app-services.override.yml^
               build --no-cache user_files.api

:: Удаляет устаревшие образы
docker image prune

PAUSE
