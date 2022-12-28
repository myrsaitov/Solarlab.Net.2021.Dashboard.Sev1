@ECHO OFF
:: Dev-certs clean and set
:: https://medium.com/@woeterman_94/docker-in-visual-studio-unable-to-configure-https-endpoint-f95727187f5f
:: https://stackoverflow.com/questions/73628719/docker-net-web-api-dev-certs-error-the-ssl-connection-could-not-be-establishe
:: https://www.niceonecode.com/question/20641/unable-to-configure-https-endpoint.-no-server-certificate-was-specified-and-the-default-developer-certif
:: https://learn.microsoft.com/en-us/aspnet/core/security/enforcing-ssl?view=aspnetcore-5.0&tabs=visual-studio#trust-https-certificate-from-windows-subsystem-for-linux-1
:: Еще способ
:: https://stackoverflow.com/questions/69801822/how-to-configure-a-custom-cert-and-key-for-a-net-core-application-for-rider-or

:: Заголовок окна - путь и имя файла
TITLE %~0

ECHO;
ECHO ********************************************************
ECHO * 1. Generating new certificate
ECHO ********************************************************
ECHO;
dotnet dev-certs https -ep %APPDATA%\ASP.NET\Https\bulleting_board.pfx -p changeit --trust
wsl dotnet dev-certs https --clean --import /mnt/c/Users/user/AppData/Roaming/ASP.NET/Https/bulleting_board.pfx --password changeit  --trust
wsl dotnet dev-certs https --trust

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
