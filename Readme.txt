Web приложение «Автомат по продаже напитков»
Проект реализован в Visual studio 2019 на .NET Framework 4.6.1
За пользовательский интерфейс отвечает контроллер Drinks, за административный - Admin.
Для доступ к административному интерфейсу необходимо в адресной строке указать:
https://localhost:nnnnn/Admin/Index/d3r4i8n6k8
Где d3r4i8n6k8 - секретный ключ.
Ограничение доступа реализовано с помощью фильтра, в котором происходит аутентификация:
~/Infrastructure/AdminAttribute.cs
Секретный ключ хранится в Web.config (configuration/appSettings/add key="Admin") 
в захешированном виде с использованием SHA512 в виде Base64.

Проект DataAccess отвечет за взаимодействие с БД.
Проект BusinessLogic отвечает за бизнес-логику и содержит основной функционал.
Проект WemAutomat отвечает за взаимодействие с пользователем.
Для внедрения зависимостей использовался Ninject.
