@ECHO OFF
:: Dev-certs clean and set
:: https://medium.com/@woeterman_94/docker-in-visual-studio-unable-to-configure-https-endpoint-f95727187f5f
:: https://stackoverflow.com/questions/73628719/docker-net-web-api-dev-certs-error-the-ssl-connection-could-not-be-establishe
:: https://www.niceonecode.com/question/20641/unable-to-configure-https-endpoint.-no-server-certificate-was-specified-and-the-default-developer-certif

:: Помогло:
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

:: Устанавливает заголовок окна
TITLE Run "dev-certs clean and set"



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


:: https://learn.microsoft.com/en-us/aspnet/core/security/enforcing-ssl?view=aspnetcore-5.0&tabs=visual-studio#trust-https-certificate-from-windows-subsystem-for-linux-1
ECHO;
ECHO ********************************************************
ECHO * 4. Generating new certificate
ECHO ********************************************************
ECHO;
dotnet dev-certs https -ep %APPDATA%\ASP.NET\Https\bulleting_board.pfx -p pgRu#5~#BcJd --trust
wsl dotnet dev-certs https --clean --import %APPDATA%\ASP.NET\Https\bulleting_board.pfx --password pgRu#5~#BcJd --trust
wsl dotnet dev-certs https --trust

:: Проверка наличия нового сертификата
ECHO;
ECHO ********************************************************
ECHO * 5. Checking new certificate
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
ECHO * 6. Restarting!
ECHO ********************************************************
ECHO;
ECHO Restart MS Visual Studio!!!
ECHO;

PAUSE
