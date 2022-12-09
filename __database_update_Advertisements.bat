@ECHO OFF
:: Обновляет базу данных

:: Устанавливает заголовок окна
TITLE "Updating Data Base"

:: Имя проекта (получает из имени файла)
::
:: Отделяет имя файла от PATH:
SET FILE_NAME=%~n0
:: Отделяет первые 18 символов "__database_update_" 
SET PROJECT_NAME=%FILE_NAME:~18%
ECHO PROJECT_NAME = %PROJECT_NAME%

:: Обновляет базу данных
:: Можно указать имя нужной миграции: dotnet ef database update %MigrationName%
dotnet ef database update^
    --startup-project  src\%PROJECT_NAME%\Hosts\%PROJECT_NAME%.Api/%PROJECT_NAME%.Api.csproj^
    --project src\%PROJECT_NAME%\Infrastructure\%PROJECT_NAME%.DataAccess\%PROJECT_NAME%.DataAccess.csproj
 
PAUSE
