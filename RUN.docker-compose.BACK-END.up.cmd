@ECHO OFF
:: Запускает docker-compose

:: Заголовок окна - путь и имя файла
TITLE %~0


:: Создание Volumes
CALL create.docker-compose.volumes.cmd --no_pause


:: Проверка наличия сети "app-network", если нет, то создает её
CALL create.docker-compose.networks.cmd --no_pause


:: Запускает docker-compose
ECHO;
ECHO *****************************************
ECHO * Starting containers
ECHO *****************************************
ECHO;
docker-compose --env-file=.env.dev^
               --file yml.docker-compose.networks.yml^
               --file yml.docker-compose.postgres.yml^
               --file yml.docker-compose.redis.yml^
               --file yml.docker-compose.app-services.yml^
               --file yml.docker-compose.app-services.override.yml^
               up --detach


PAUSE
