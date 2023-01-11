@ECHO OFF
:: Удаляет все образы из системы

:: Заголовок окна - путь и имя файла
TITLE %~0

:: Удаляет все контейнеры, образы и volumes из системы
:: https://docs.docker.com/config/pruning/
docker system prune --all
docker system prune --volumes

PAUSE
