@ECHO OFF
:: Удаляет все образы из системы

:: Устанавливает заголовок окна
TITLE Run "docker system prune -a"

:: Удаляет все образы из системы
docker system prune -a

PAUSE
