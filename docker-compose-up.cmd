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

:: Redis
IF NOT EXIST c:\Docker\Root\BulletingBoard\Redis (
    docker volume create^
        --opt type=none^
        --opt device=/c/Docker/Root/BulletingBoard/Redis^
        --opt o=bind
)


:: Проверка наличия сети "app-network", если нет, то создает её
ECHO;
ECHO *****************************************
ECHO * Checking network "app-network"
ECHO *****************************************
ECHO;
docker network inspect app-network || (
    docker network create -d bridge app-network
)


:: Запускает docker-compose
ECHO;
ECHO *****************************************
ECHO * Starting containers
ECHO *****************************************
ECHO;
docker-compose --env-file=.env.dev up --detach

PAUSE
