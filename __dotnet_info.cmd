@ECHO OFF
:: Выводит информацию о DotNet

:: Заголовок окна - путь и имя файла
TITLE %~0

:: Выводит информацию о DotNet
dotnet --info

PAUSE
