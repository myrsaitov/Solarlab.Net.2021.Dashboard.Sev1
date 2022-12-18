@ECHO OFF
:: Восстанавливает зависимости и средства проекта

:: Устанавливает заголовок окна
TITLE Run "dotnet RESTORE"

:: Восстанавливает зависимости и средства проекта
:: https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-restore
dotnet restore -f

PAUSE
