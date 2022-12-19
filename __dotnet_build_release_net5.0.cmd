@ECHO OFF
:: Выполняет сборку проекта

:: Устанавливает заголовок окна
TITLE Run "dotnet BUILD Release"

:: Выполняет сборку проекта
:: https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-build
::
:: Если после выполнения "dotnet clean" появляются ошибки доступа к DLL-файлам:
:: 1. перезапустить этот скрипт;
:: 2. если ошибки остались, то через диспетчер 
::    задачь снять задачу ".NET" и перезапустить этот скрипт.
:: 3. Удалить с помощью скрипта все папки "bin" и "obj".
:: 4. Остановить сервер MSBuild командой "dotnet build-server shutdown"
::
dotnet build -c Release -f net5.0

PAUSE
