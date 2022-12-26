@ECHO OFF
:: Добавляет миграцию

:: Заголовок окна - путь и имя файла
TITLE %~0

:: Имя проекта (получает из имени файла)
::
:: Отделяет имя файла от PATH:
SET FILE_NAME=%~n0
:: Отделяет первые 16 символов "__add_migration_" 
SET PROJECT_NAME=%FILE_NAME:~16%
ECHO PROJECT_NAME = %PROJECT_NAME%

:: Подготовка параметров
SET STARTUP_PROJECT=--startup-project src/%PROJECT_NAME%/Hosts/%PROJECT_NAME%.Api/%PROJECT_NAME%.Api.csproj
SET PROJECT=--project src/%PROJECT_NAME%/Infrastructure/%PROJECT_NAME%.DataAccess/%PROJECT_NAME%.DataAccess.csproj
SET PARAMS=%STARTUP_PROJECT% %PROJECT%

:: Добавляет миграцию
:: dotnet ef migrations add %PARAMS% Initial_Create 

PAUSE
