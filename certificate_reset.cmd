@ECHO OFF
:: Dev-certs clean and set
:: https://medium.com/@woeterman_94/docker-in-visual-studio-unable-to-configure-https-endpoint-f95727187f5f
:: https://stackoverflow.com/questions/73628719/docker-net-web-api-dev-certs-error-the-ssl-connection-could-not-be-establishe
:: https://www.niceonecode.com/question/20641/unable-to-configure-https-endpoint.-no-server-certificate-was-specified-and-the-default-developer-certif
:: C:\Users\user\AppData\Roaming/Microsoft/UserSecrets
:: C:\Users\user\AppData\Roaming/ASP.NET/Https


:: Устанавливает заголовок окна
TITLE Run "dev-certs clean and set"

:: To clean a developer certificate:
dotnet dev-certs https --clean

PAUSE

:: To generate a developer certificate:
dotnet dev-certs https -t -p "rPWw?sBn6%dh"

PAUSE

:: To trust the certificate (Windows and macOS only):
dotnet dev-certs https --trust

PAUSE

ECHO ALSO: RUN "certmgr.msc": Clean "localhost" in
ECHO   - Personal/Certificates
ECHO   - Current User Trusted Root Certification Authorities/Certificates
ECHO Restart Visual Studio!!!

PAUSE
