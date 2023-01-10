@ECHO OFF
:: Останавливает docker-compose

:: Заголовок окна - путь и имя файла
TITLE %~0

:: Останавливает docker-compose
docker-compose  --env-file=configs/.env^
                --file configs/docker-compose.networks.yml^
                --file configs/docker-compose.postgres.yml^
                down


PAUSE
