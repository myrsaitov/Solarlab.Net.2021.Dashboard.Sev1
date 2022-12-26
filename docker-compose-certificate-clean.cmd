@ECHO OFF
:: Dev-certs clean and set

:: Очистить все папки:
:: C:\Users\user\AppData\Roaming\Microsoft\UserSecrets
:: C:\Users\user\AppData\Roaming\ASP.NET\Https
::
:: Удалить все сертификаты:
:: dotnet dev-certs https --clean
:: RUN "certmgr.msc": Clean "localhost" in
::   - Personal/Certificates
::   - Current User Trusted Root Certification Authorities/Certificates
:: 
:: Очистить все бинарники у докера и в проекте
:: 
:: Запустить полностью чистый проект в режиме docker-compose, подтвердить создание сертификата

:: Заголовок окна - путь и имя файла
TITLE %~0


:: Удаление вручную
ECHO;
ECHO ********************************************************
ECHO * 1. Manually remove UserSecrets and ASP.NET\Https in APPDATA
ECHO ********************************************************
ECHO;
ECHO %APPDATA%\Microsoft\UserSecrets
START %APPDATA%\Microsoft\UserSecrets
ECHO;
ECHO %APPDATA%\ASP.NET\Https
START %APPDATA%\ASP.NET\Https

ECHO;
ECHO ********************************************************
ECHO * 2. Manually remove Certificates in "certmgr.msc"
ECHO ********************************************************
ECHO;
ECHO Check Sertificates in "certmgr.msc":
ECHO   - Personal/Certificates: REMOVE "localhost"
ECHO   - Current User Trusted Root Certification Authorities/Certificates: REMOVE "localhost"
ECHO;
certmgr.msc

:: To clean a developer certificate:
ECHO;
ECHO ********************************************************
ECHO * 3. Automatic remove certificates
ECHO ********************************************************
ECHO;
dotnet dev-certs https --clean
ECHO;
ECHO;


PAUSE
