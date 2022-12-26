@ECHO OFF
:: Установка сертификатов с помощью MKCERT

:: Заголовок окна - путь и имя файла
TITLE %~0


pause



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
wsl dotnet dev-certs https --clean --import /mnt/c/Users/user/AppData/Roaming/ASP.NET/Https/bulleting_board.pfx --password pgRu#5~#BcJd
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

:: Еще способ
:: https://stackoverflow.com/questions/69801822/how-to-configure-a-custom-cert-and-key-for-a-net-core-application-for-rider-or