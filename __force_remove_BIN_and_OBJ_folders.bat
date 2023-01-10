@ECHO OFF
:: Рекурсивно удаляет папки BIN и OBJ

:: Устанавливает заголовок окна
TITLE "Deleting all BIN and OBJ folders"

@ECHO Deleting all BIN and OBJ folders...

:: В цикле удаляет папки
FOR /D /R . %%D IN (bin,obj) DO @IF EXIST "%%D" RD /S/Q "%%D"

@ECHO BIN and OBJ folders successfully deleted :) Close the window.

PAUSE > NUL
