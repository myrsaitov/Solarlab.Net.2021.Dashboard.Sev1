@ECHO OFF
:: List User Secrets
:: https://blog.christian-schou.dk/what-are-user-secrets-and-how-to-use-them/

:: Устанавливает заголовок окна
TITLE "List User Secrets"

:: Имя проекта (получает из имени файла)
::
:: Отделяет имя файла от PATH:
SET FILE_NAME=%~n0              
:: Отделяет первые 15 символов "__user_secrets_" 
SET PROJECT_NAME=%FILE_NAME:~15%
ECHO PROJECT_NAME = %PROJECT_NAME%

:: List User Secrets
dotnet user-secrets list --project src\%PROJECT_NAME%\Hosts\%PROJECT_NAME%.Api

PAUSE
