@ECHO OFF
:: Останавливает сервер

:: Устанавливает заголовок окна
TITLE Run "dotnet ShutDown"

:: Останавливает сервер
dotnet build-server shutdown

PAUSE
