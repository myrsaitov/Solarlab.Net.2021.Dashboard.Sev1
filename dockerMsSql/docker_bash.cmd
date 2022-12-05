REM https://docs.microsoft.com/ru-ru/sql/linux/quickstart-install-connect-docker?view=sql-server-ver15&pivots=cs1-powershell
REM Run: /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "Pf~BBag~iFDt"
REM 1> CREATE DATABASE TestDB
REM 2> SELECT Name from sys.Databases
REM 3> GO
...
REM ...> QUIT

docker exec -it MsSqlExpress "bash"

PAUSE