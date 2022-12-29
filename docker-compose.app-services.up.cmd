@ECHO OFF
:: Запускает docker-compose

:: Заголовок окна - путь и имя файла
TITLE %~0


:: Создание Volumes
CALL docker-compose.create.volumes.cmd --no_pause


:: Проверка наличия сети "app-network", если нет, то создает её
CALL docker-compose.create.networks.cmd --no_pause


:: Запускает docker-compose
ECHO;
ECHO *****************************************
ECHO * Starting containers
ECHO *****************************************
ECHO;
docker-compose --env-file=.env.dev^
               --file docker-compose.networks.yml^
               --file docker-compose.postgres.yml^
               --file docker-compose.redis.yml^
               --file docker-compose.app-services.yml^
               --file docker-compose.app-services.override.yml^
               up --detach


PAUSE
