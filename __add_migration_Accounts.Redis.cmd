@ECHO OFF
:: Добавляет миграцию

:: Заголовок окна - путь и имя файла
TITLE %~0

:: Подготовка параметров
SET STARTUP_PROJECT=--startup-project src/Accounts/Hosts/Accounts.Api/Accounts.Api.csproj
SET PROJECT=--project src/Accounts/Infrastructure/Accounts.DataAccess/Accounts.DataAccess.csproj
SET PARAMS=%STARTUP_PROJECT% %PROJECT%

:: Добавляет миграцию
:: dotnet ef migrations add %PARAMS% Initial_Create 
dotnet ef migrations add %PARAMS% AddDataProtectionKeys --context MyKeysContext
:: dotnet ef database update --context MyKeysContext

PAUSE
