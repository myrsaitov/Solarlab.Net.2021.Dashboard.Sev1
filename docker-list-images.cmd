@ECHO OFF
:: Выводит список образов

:: Устанавливает заголовок окна
TITLE Run "docker images -a"

:: Выводит список запущенных контейнеров
docker images -a

PAUSE
