@ECHO OFF
:: Выход и вход в докер
:: https://www.dotnetforall.com/failed-to-solve-with-frontend-dockerfile-v0-failed-to-create-llb-definition-possible-solutions/

:: Заголовок окна - путь и имя файла
TITLE %~0

:: Выход из докера
docker logout

:: Вход в докер
docker login -u myrsaitov -p

PAUSE
