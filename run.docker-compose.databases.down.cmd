@ECHO OFF
:: Останавливает docker-compose

:: Заголовок окна - путь и имя файла
TITLE %~0

:: Останавливает docker-compose
docker-compose  --env-file=.env.dev^
                --file yml.docker-compose.networks.yml^
                --file yml.docker-compose.postgres.yml^
				--file yml.docker-compose.redis.yml^
                down


PAUSE
