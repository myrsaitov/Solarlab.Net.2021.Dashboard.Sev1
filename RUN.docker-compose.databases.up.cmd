@ECHO OFF
:: Запускает docker-compose

:: Заголовок окна - путь и имя файла
TITLE %~0


:: Создание Volumes
CALL create.docker-compose.volumes.cmd --no_pause

:: Создание Networks
CALL create.docker-compose.networks.cmd --no_pause

:: Запускает docker-compose
ECHO;
ECHO *****************************************
ECHO * Starting containers
ECHO *****************************************
ECHO;
docker-compose --env-file=.env^
               --file yml.docker-compose.networks.yml^
               --file yml.docker-compose.postgres.yml^
			   --file yml.docker-compose.redis.yml^
               up --detach


PAUSE
