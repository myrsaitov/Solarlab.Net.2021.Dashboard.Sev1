@ECHO OFF
:: Dev-certs clean and set

:: Устанавливает заголовок окна
TITLE Run "dev-certs clean and set"

:: To clean a developer certificate:
dotnet dev-certs https --clean

:: To trust the certificate (Windows and macOS only) run
dotnet dev-certs https --trust

ECHO ALSO: RUN "certmgr.msc" => Personal > Certificates
ECHO Restart Visual Studio!!!

PAUSE
