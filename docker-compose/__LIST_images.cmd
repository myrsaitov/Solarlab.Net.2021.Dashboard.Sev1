@ECHO OFF
:: Выводит список образов

:: Заголовок окна - путь и имя файла
TITLE %~0

:: Выводит список запущенных контейнеров
:: https://docs.docker.com/engine/reference/commandline/image_prune/
docker images --format "table {{.Repository}}\t{{.Tag}}\t{{.ID}}\t{{.CreatedAt}}\t{{.Size}}"


PAUSE
