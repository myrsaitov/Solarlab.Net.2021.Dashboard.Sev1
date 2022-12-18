@ECHO OFF
:: Выполняет исходный код без дополнительных явных команд компиляции или запуска

:: Устанавливает заголовок окна
TITLE Run "dotnet RUN"

:: Выполняет исходный код без дополнительных явных команд компиляции или запуска
:: https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-run

START "Accounts" dotnet run --launch-profile sev1 --project src/Accounts/Hosts/Accounts.Api/Accounts.Api.csproj
START "Advertisements" dotnet run --launch-profile sev1 --project src/Advertisements/Hosts/Advertisements.Api/Advertisements.Api.csproj
START "UserFiles" dotnet run --launch-profile sev1 --project src/UserFiles/Hosts/UserFiles.Api/UserFiles.Api.csproj

:: Запускает браузеры
START /B chrome https://localhost:49031/swagger/index.html
START /B chrome https://localhost:49032/swagger/index.html
START /B chrome https://localhost:49033/swagger/index.html
