@ECHO OFF
:: Запускает docker-compose

:: Заголовок окна - путь и имя файла
TITLE %~0


:: Создание Volumes
CALL docker-compose-create-volumes.cmd --no_pause

:: Создание Networks
CALL docker-compose-create-networks.cmd --no_pause

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
               up --detach


PAUSE
