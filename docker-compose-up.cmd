@ECHO OFF
:: Запускает docker-compose

:: Устанавливает заголовок окна
TITLE Run "docker-compose up -d"

:: Запускает docker-compose
docker-compose up -d

PAUSE
