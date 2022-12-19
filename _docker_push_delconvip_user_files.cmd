@ECHO OFF
:: Загружает локальный образ на DockerHub

:: Устанавливает заголовок окна
TITLE Run "docker PUSH UserFiles"

:: Загружает локальный образ на DockerHub
docker push myrsaitov/bulleting_board-services-user_files

PAUSE
