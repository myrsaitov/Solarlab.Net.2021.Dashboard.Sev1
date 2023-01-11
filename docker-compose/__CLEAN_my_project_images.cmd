@ECHO OFF
:: Удаляет разработанные мной образы из системы

:: Заголовок окна - путь и имя файла
TITLE %~0

:: Удаляет разработанные мной образы из системы
:: https://docs.docker.com/engine/reference/commandline/image_prune/
docker image prune -a -f --filter=label=developer=myrsaitov


PAUSE
