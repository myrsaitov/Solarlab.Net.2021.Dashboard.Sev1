@ECHO OFF
:: Запускает docker-compose

:: Устанавливает заголовок окна
TITLE Run "postgres-docker-compose UP"

:: Запускает docker-compose
docker-compose  --file postgres-docker-compose.yml up --detach

PAUSE
