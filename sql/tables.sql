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

drop table dm.tMenu
drop table dm.tCommand
drop table dm.tFormOptions
*/


-------------------------------------------------------------------------------
-- описание команды для вызова
create table dm.tCommand (
  code varchar(30) not null
, appcode varchar(30) not null
, cmdType int not null default 0 -- тип команды: 0 = sql, 1 = форма: cmd='[path]assembly;namespace.class', 2 = метод: cmd='[path]assembly;namespace.class;method'
, cmd varchar(max) not null default ''
, cmdTestHead varchar(max) null
, comment varchar(500) null
, constraint pkCommand primary key (code, appcode)
)
go
grant all on dm.tCommand to public
go

-- alter table dm.tCommand add cmdTestHead varchar(max) null
-- alter table dm.tCommand add comment varchar(500) null

-------------------------------------------------------------------------------
-- пункты меню, их зависимость и определение действия при выборе 
create table dm.tMenu (
  code varchar(30) not null
, appcode varchar(30) not null
, parent varchar(30) null -- код верхнего пункта или null
, ord int not null -- порядок в меню/подменю
, caption varchar(100) not null -- текст меню
, img varchar(100) null -- изображение, если путь не указан - будет смотреть в ImgAsm настроек приложения
, execType int not null default 0  -- 0 = команда, 1 = подменю
, command varchar(30) null -- для execType = 0 - код из tCommand
, constraint pkMenu primary key (code, appcode)
, constraint fkMenuMenu foreign key (parent, appcode) references dm.tMenu(code, appcode) on delete no action
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
)
go
grant all on dm.tFormOptions to public
go

/*

update dm.tFormOptions set 
  options = (select o.options from dm.tFormOptions o where o.code = 'REGION\VTB105929')
  where code = 'REGION\MSK49932'

-- select * from dm.tFormOptions where appcode = 'Master'
-- delete dm.tFormOptions where appcode = 'Master' and code = 'REGION\VTB105929'

*/