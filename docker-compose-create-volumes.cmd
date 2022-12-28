@ECHO OFF
:: Создаёт Volumes для docker-compose

:: Заголовок окна - путь и имя файла
TITLE %~0


:: Создание Volumes
ECHO;
ECHO *****************************************
ECHO * Creating Volumes
ECHO *****************************************
ECHO;

:: Accounts
IF NOT EXIST c:\Docker\BulletingBoard\Postgres\Accounts (
    ECHO Creating volume "Accounts"
    docker volume create^
           --opt type=none^
           --opt device=/c/Docker/BulletingBoard/Postgres/Accounts/largedb^
           --opt o=bind^
		   accounts.volume

) ELSE ECHO Volume "Accounts" exists!

:: Advertisements
IF NOT EXIST c:\Docker\BulletingBoard\Postgres\Advertisements (
    ECHO Creating volume "Advertisements"
    docker volume create^
           --opt type=none^
           --opt device=/c/Docker/BulletingBoard/Postgres/Advertisements/largedb^
           --opt o=bind^
		   advertisements.volume
) ELSE ECHO Volume "Advertisements" exists!

:: Userfiles
IF NOT EXIST c:\Docker\BulletingBoard\Postgres\UserFiles (
    ECHO Creating volume "UserFiles"
    docker volume create^
           --opt type=none^
           --opt device=/c/Docker/BulletingBoard/Postgres/UserFiles/largedb^
           --opt o=bind^
		   user_files.volume
) ELSE ECHO Volume "UserFiles" exists!

:: Redis
IF NOT EXIST c:\Docker\BulletingBoard\Redis (
    ECHO Creating volume "Redis"
    docker volume create^
           --opt type=none^
           --opt device=/c/Docker/BulletingBoard/Redis^
           --opt o=bind^
		   redis.volume
) ELSE ECHO Volume "Redis" exists!


:: С паузой или без паузы в конце
IF "%~1" EQU "--no_pause" (EXIT /B 0) ELSE PAUSE
