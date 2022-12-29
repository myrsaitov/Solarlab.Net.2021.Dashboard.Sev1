@ECHO OFF
:: Устанавливает инструменты Entity Framework

:: Заголовок окна - путь и имя файла
TITLE %~0

:: Устанавливает инструменты Entity Framework
:: https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-tool-install
:: https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-tool-uninstall
dotnet tool install --global --framework net5.0 dotnet-ef

PAUSE
