REM https://docs.microsoft.com/ru-ru/sql/linux/quickstart-install-connect-docker?view=sql-server-ver15&pivots=cs1-powershell

docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=u9UWLHeR2feY" -e "MSSQL_PID=Express" -p 1401:1433 --name mssql -h mssql -v C:/Mssql2019DockerVolume/data:/var/opt/mssql/data -v C:/Mssql2019DockerVolume/log:/var/opt/mssql/log -v C:/Mssql2019DockerVolume/secrets:/var/opt/mssql/secrets -d mcr.microsoft.com/mssql/server:2019-latest

pause