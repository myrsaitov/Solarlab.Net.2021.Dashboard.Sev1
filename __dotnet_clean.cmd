@ECHO OFF
:: Удаляет выходные файлы прошлой сборки

:: Устанавливает заголовок окна
TITLE Run "dotnet CLEAN"

:: Удаляет выходные файлы прошлой сборки
:: https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-clean
dotnet clean

PAUSE
