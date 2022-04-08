Для установки примера:

1. Разархивировать Bonds_project\install.rar
2. Запустить: install.bat сервер база логин пароль
или для доменной учетки: > install.bat сервер база
пользователь должен быть db_owner'ом
3. В Bonds\Bonds.xml прописать имя сервера и базы в строке подключения (атрибут Value тега с Name="ConnectionString")
4. Запустить Bonds\Bonds.exe

Для запуска приложения Master (Master\Master.exe) необходимо сервер и базу прописать аналогично в Master\Master.xml

Исходники примера - см. в Bonds_project\Bonds\Bonds.sln