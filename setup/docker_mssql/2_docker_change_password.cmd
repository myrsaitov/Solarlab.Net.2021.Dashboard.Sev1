REM Учетная запись SA обладает правами администратора на экземпляре SQL Server, создаваемом во время установки. После создания контейнера SQL Server указанную вами переменную среды SA_PASSWORD можно обнаружить, запустив echo $SA_PASSWORD в контейнере. В целях безопасности смените пароль SA.

docker exec -it MsSqlExpress /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "u9UWLHeR2feY" -Q "ALTER LOGIN SA WITH PASSWORD='Pf~BBag~iFDt'"

PAUSE