@ECHO OFF
:: Запускает docker-compose

:: Устанавливает заголовок окна
TITLE Run "docker-compose up -d"

:: Запускает docker-compose
docker-compose  -f docker-compose-postgres.yml up -d

PAUSE
