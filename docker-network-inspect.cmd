@ECHO OFF
:: Запускает docker inspect

:: Устанавливает заголовок окна
TITLE Run "docker network inspect"

:: Запускает docker inspect

docker network inspect dev_network
::docker inspect -f '{{range $key, $value := .NetworkSettings.Networks}}{{$key}} {{end}}' advertisements.api-1

PAUSE
