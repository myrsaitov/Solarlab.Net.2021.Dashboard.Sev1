@ECHO OFF
:: Выход и вход в докер
:: https://docs.ansible.com/ansible/latest/collections/community/docker/docker_login_module.html
:: https://www.dotnetforall.com/failed-to-solve-with-frontend-dockerfile-v0-failed-to-create-llb-definition-possible-solutions/

:: Заголовок окна - путь и имя файла
TITLE %~0

:: Предупреждение
ECHO;
ECHO;
ECHO Docker Logout?!!!!!!!!!!!!!!!!!!!!!
ECHO;
ECHO;
PAUSE

:: Выход из докера
docker logout

:: Вход в докер
docker login -u USERNAME -p PASSWORD

PAUSE
