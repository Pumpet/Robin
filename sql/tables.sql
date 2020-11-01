--//
--//  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
--//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
--//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
--//  PURPOSE.
--//
--//  License: GNU Lesser General Public License (LGPLv3)
--//
--//  Email: pumpet.net@gmail.com
--//  Git: https://github.com/Pumpet/Robin
--//  Copyright (C) Alex Rozanov, 2020 
--//

/*
create schema dm
go

drop table dm.tRoleMarker
drop table dm.tUserRole
drop table dm.tUser
drop table dm.tRole
drop table dm.tMenu
drop table dm.tCommand
drop table dm.tFormOptions
drop table dm.tMarker
drop table dm.tApp
drop table dm.tLog
*/

-------------------------------------------------------------------------------
-- приложение
create table dm.tApp (
  code varchar(30) not null
, caption varchar(100) not null
, note varchar(500) null
, checkUserRights bit not null default 0
, logAll bit not null default 0
, logSQL bit not null default 0
, constraint pkApp primary key (code)
)
go
grant all on dm.tApp to public
go

-------------------------------------------------------------------------------
-- пользователи-роли

create table dm.tUser (
  id int identity not null
, login varchar(100) not null
, name varchar(100) not null
, constraint pkUser primary key (id)
, constraint akUser unique (login)
)
go
grant all on dm.tUser to public
go

create table dm.tRole (
  id int identity not null
, code varchar(30) not null
, appcode varchar(30) not null
, note varchar(500) null
, constraint pkRole primary key (id)
, constraint akRole unique (code, appcode)
, constraint fkRoleApp foreign key (appcode) references dm.tApp(code) on delete no action on update cascade 
)
go
grant all on dm.tRole to public
go

create table dm.tUserRole (
  userId int not null
, roleId int not null
, constraint pkUserRole primary key (userId,roleId)
, constraint fkUserRoleUser foreign key (userId) references dm.tUser(id) on delete cascade
, constraint fkUserRoleRole foreign key (roleId) references dm.tRole(id) on delete cascade
)
go
grant all on dm.tUserRole to public
go

create table dm.tMarker (
  code varchar(30) not null
, note varchar(100) null
, constraint pkMarker primary key (code)
)
go
grant all on dm.tMarker to public
go

create table dm.tRoleMarker (
  roleId int not null
, marker varchar(30) not null
, constraint pkRoleMarker primary key (roleId, marker)
, constraint fkRoleMarkerRole foreign key (roleId) references dm.tRole(id) on delete cascade
, constraint fkRoleMarkerMarker foreign key (marker) references dm.tMarker(code) on delete cascade on update cascade 

)
go
grant all on dm.tRoleMarker to public
go

-------------------------------------------------------------------------------
-- описание команды для вызова
create table dm.tCommand (
  code varchar(30) not null
, appcode varchar(30) not null
, cmdType int not null default 0 -- тип команды: 0 = sql, 1 = форма: cmd='[path]assembly;namespace.class', 2 = метод: cmd='[path]assembly;namespace.class;method'
, cmd varchar(max) not null default ''
, cmdTestHead varchar(max) null
, comment varchar(500) null
, marker varchar(30) null
, constraint pkCommand primary key (code, appcode)
, constraint fkCommandApp foreign key (appcode) references dm.tApp(code) on delete no action on update cascade 
, constraint fkCommandMarker foreign key (marker) references dm.tMarker(code) on delete set null on update cascade 
)
go
grant all on dm.tCommand to public
go

-- alter table dm.tCommand add cmdTestHead varchar(max) null
-- alter table dm.tCommand add comment varchar(500) null
-- alter table dm.tCommand add marker varchar(30) null

-------------------------------------------------------------------------------
-- пункты меню, их зависимость и определение действия при выборе 
create table dm.tMenu (
  id int not null identity
, code varchar(30) not null
, appcode varchar(30) not null
, parentId int null -- id верхнего пункта или null
, ord int not null -- порядок в меню/подменю
, caption varchar(100) not null -- текст меню
, img varchar(100) null -- изображение, если путь не указан - будет смотреть в ImgAsm настроек приложения
, execType int not null default 0  -- 0 = команда, 1 = подменю
, command varchar(30) null -- для execType = 0 - код из tCommand
, marker varchar(30) null
, constraint pkMenu primary key (id)
, constraint akMenu unique (appcode, code)
, constraint fkMenuMenu foreign key (parentId) references dm.tMenu(id) on delete no action
, constraint fkMenuApp foreign key (appcode) references dm.tApp(code) on delete no action on update cascade 
, constraint fkMenuMarker foreign key (marker) references dm.tMarker(code) on delete set null on update cascade 
)
go
grant all on dm.tMenu to public
go

-------------------------------------------------------------------------------
-- xml с настройками отображения форм для пользователя
create table dm.tFormOptions (
  code varchar(100) not null -- например = имени пользователя
, appcode varchar(30) not null
, options xml null 
, constraint pkFormOptions primary key (code, appcode)
, constraint fkFormOptionsApp foreign key (appcode) references dm.tApp(code) on delete no action on update cascade 
)
go
grant all on dm.tFormOptions to public
go

-------------------------------------------------------------------------------
-- лог
create table dm.tLog (
  dt datetime not null
, login varchar(100) not null
, appcode varchar(30) not null
, type varchar(30) not null 
, mess varchar(max) not null
)
go
grant all on dm.tLog to public
go
create nonclustered index idx1Log on dm.tLog(dt)
go

