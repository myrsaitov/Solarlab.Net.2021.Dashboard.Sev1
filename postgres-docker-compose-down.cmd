@ECHO OFF
:: Останавливает docker-compose

:: Устанавливает заголовок окна
TITLE Run "docker-compose down"

:: Останавливает docker-compose
docker-compose  -f postgres-docker-compose.yml down

PAUSE
