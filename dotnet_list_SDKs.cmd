@ECHO OFF
:: Выводит информацию об имеющихся в системе SDK

:: Устанавливает заголовок окна
TITLE Run "dotnet --list-sdks"

:: Выводит информацию об имеющихся в системе SDK
dotnet --list-sdks

PAUSE
