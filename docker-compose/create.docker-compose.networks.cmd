@ECHO OFF
:: Создаёт Volumes для docker-compose

:: Заголовок окна - путь и имя файла
TITLE %~0


:: Проверка наличия сети "app-network", если нет, то создает её
ECHO;
ECHO *****************************************
ECHO * Creating network "app-network"
ECHO *****************************************
ECHO;
docker network inspect app-network || (
    docker network create -d bridge app-network
)

:: С паузой или без паузы в конце
IF "%~1" EQU "--no_pause" (EXIT /B 0) ELSE PAUSE
