@ECHO OFF
:: Восстанавливает зависимости и средства проекта

:: Заголовок окна - путь и имя файла
TITLE %~0

:: Восстанавливает зависимости и средства проекта
:: https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-restore
dotnet restore -f

PAUSE
