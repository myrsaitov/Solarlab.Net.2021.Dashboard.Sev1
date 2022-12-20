@ECHO OFF
:: Устанавливает инструменты Entity Framework

:: Устанавливает заголовок окна
TITLE Installing Entity Framework CLI

:: Устанавливает инструменты Entity Framework
:: https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-tool-install
:: https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-tool-uninstall
dotnet tool install --global --framework net5.0 dotnet-ef

PAUSE
