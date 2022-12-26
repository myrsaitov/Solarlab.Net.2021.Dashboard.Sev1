@ECHO OFF
:: Удаляет выходные файлы прошлой сборки

:: Заголовок окна - путь и имя файла
TITLE %~0

:: Удаляет выходные файлы прошлой сборки
:: https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-clean
dotnet clean

PAUSE
