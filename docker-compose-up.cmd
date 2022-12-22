@ECHO OFF
:: Запускает docker-compose

:: Устанавливает заголовок окна
TITLE Run "docker-compose UP"

:: Запускает docker-compose
docker-compose up --detach

PAUSE
