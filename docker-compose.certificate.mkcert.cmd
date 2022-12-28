@ECHO OFF
:: Установка сертификатов с помощью MKCERT
:: https://medium.com/@aweber01/locally-trusted-development-certificates-with-mkcert-and-iis-e09410d92031
:: https://knplabs.com/en/blog/how-to-handle-https-with-docker-compose-and-mkcert-for-local-development

:: Заголовок окна - путь и имя файла
TITLE %~0


ECHO;
ECHO ********************************************************
ECHO * 1. Generating new certificate
ECHO ********************************************************
ECHO;

::mkcert-v1.4.4-windows-amd64.exe -help

mkcert-v1.4.4-windows-amd64.exe -pkcs12 bulleting_board

:: Install the local CA in the system trust store.
mkcert-v1.4.4-windows-amd64.exe -install

MOVE bulleting_board.p12 %APPDATA%\ASP.NET\Https\bulleting_board.pfx

pause
:: Проверка наличия нового сертификата
ECHO;
ECHO ********************************************************
ECHO * 2. Checking new certificate
ECHO ********************************************************
ECHO;
ECHO %APPDATA%\ASP.NET\Https
START %APPDATA%\ASP.NET\Https
ECHO;
ECHO Check Sertificates in "certmgr.msc":
ECHO   - Personal/Certificates: "localhost"
ECHO   - Current User Trusted Root Certification Authorities/Certificates: "localhost"
ECHO;
certmgr.msc

:: Перезапустите MS Visual Studio!!!
ECHO;
ECHO ********************************************************
ECHO * 3. Restarting!
ECHO ********************************************************
ECHO;
ECHO Restart MS Visual Studio!!!
ECHO;

PAUSE

:: Еще способ
:: https://stackoverflow.com/questions/69801822/how-to-configure-a-custom-cert-and-key-for-a-net-core-application-for-rider-or