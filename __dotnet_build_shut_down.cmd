@ECHO OFF
:: Останавливает сервер

:: Заголовок окна - путь и имя файла
TITLE %~0

:: Останавливает сервер
dotnet build-server shutdown

PAUSE
