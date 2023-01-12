@ECHO OFF
:: Останавливает docker-compose

:: Заголовок окна - путь и имя файла
TITLE %~0

:: Останавливает docker-compose
docker-compose --env-file=configs/.env^
               --file docker-compose.networks^
               --file docker-compose.postgres^
               --file docker-compose.redis^
               --file docker-compose.back-end^
               --file docker-compose.back-end.environments^
               down


PAUSE
