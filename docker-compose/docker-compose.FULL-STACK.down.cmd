@ECHO OFF
:: Останавливает docker-compose

:: Заголовок окна - путь и имя файла
TITLE %~0

:: Останавливает docker-compose
docker-compose --env-file=.env^
               --file docker-compose.networks.yml^
               --file docker-compose.postgres.yml^
               --file docker-compose.redis.yml^
               --file docker-compose.back-end.yml^
               --file docker-compose.back-end.override.yml^
               down


PAUSE
