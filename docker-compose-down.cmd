@ECHO OFF
:: Останавливает docker-compose

:: Заголовок окна - путь и имя файла
TITLE %~0

:: Останавливает docker-compose
docker-compose down

PAUSE
