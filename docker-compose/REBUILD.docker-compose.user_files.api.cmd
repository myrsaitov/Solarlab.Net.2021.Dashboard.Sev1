@ECHO OFF
:: Запускает docker-compose

:: Заголовок окна - путь и имя файла
TITLE %~0

:: Запускает docker-compose
docker-compose --env-file=configs/.env^
               --file configs/docker-compose.networks.yml^
               --file configs/docker-compose.postgres.yml^
               --file configs/docker-compose.redis.yml^
               --file configs/docker-compose.back-end.yml^
               --file configs/docker-compose.back-end.build.yml^
               --file configs/docker-compose.back-end.environments.yml^
               build --no-cache user_files.api

:: Удаляет устаревшие образы
docker image prune

PAUSE
