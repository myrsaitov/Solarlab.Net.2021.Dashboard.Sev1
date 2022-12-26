@ECHO OFF
:: Запускает docker-compose

:: Заголовок окна - путь и имя файла
TITLE %~0


:: Создание Volumes
ECHO;
ECHO *****************************************
ECHO * Creating Volumes
ECHO *****************************************
ECHO;

:: Accounts
IF NOT EXIST c:\Docker\Root\BulletingBoard\Postgres\Accounts (
    docker volume create^
        --opt type=none^
        --opt device=/c/Docker/Root/BulletingBoard/Postgres/Accounts/largedb^
        --opt o=bind
)

:: Advertisements
IF NOT EXIST c:\Docker\Root\BulletingBoard\Postgres\Advertisements (
    docker volume create^
        --opt type=none^
        --opt device=/c/Docker/Root/BulletingBoard/Postgres/Advertisements/largedb^
        --opt o=bind
)

:: Userfiles
IF NOT EXIST c:\Docker\Root\BulletingBoard\Postgres\UserFiles (
    docker volume create^
        --opt type=none^
        --opt device=/c/Docker/Root/BulletingBoard/Postgres/UserFiles/largedb^
        --opt o=bind
)


:: Запускает docker-compose
ECHO;
ECHO *****************************************
ECHO * Starting containers
ECHO *****************************************
ECHO;
docker-compose  --file postgres-docker-compose.yml up --detach

PAUSE
