@ECHO OFF
:: Запускает docker inspect

:: Заголовок окна - путь и имя файла
TITLE %~0

:: Запускает docker inspect

docker network inspect dev_network
::docker inspect -f '{{range $key, $value := .NetworkSettings.Networks}}{{$key}} {{end}}' advertisements.api-1

PAUSE
