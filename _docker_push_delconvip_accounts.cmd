@ECHO OFF
:: Загружает локальный образ на DockerHub

:: Устанавливает заголовок окна
TITLE Run "docker PUSH Accounts"

:: Загружает локальный образ на DockerHub
docker push myrsaitov/bulleting_board-services-accounts

PAUSE
