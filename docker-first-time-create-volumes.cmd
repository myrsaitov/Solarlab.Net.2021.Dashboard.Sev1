@ECHO OFF
:: Создает volumes для docker-compose

:: Устанавливает заголовок окна
TITLE Run "docker volume create"

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

PAUSE