@ECHO OFF
:: Выводит информацию об имеющихся в системе SDK

:: Устанавливает заголовок окна
TITLE Run "dotnet --list-runtimes"

:: Выводит информацию об имеющихся в системе Runtimes
dotnet --list-runtimes

PAUSE
