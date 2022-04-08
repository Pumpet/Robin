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

create schema robin
go

-------------------------------------------------------------------------------
-- ����������
create table robin.tApp (
  code varchar(30) not null
, caption varchar(100) not null
, note varchar(500) null
, checkUserRights bit not null default 0
, logAll bit not null default 0
, logSQL bit not null default 0
, constraint pkApp primary key (code)
)
go
grant DELETE, INSERT, REFERENCES, SELECT, UPDATE on robin.tApp to public
go
insert robin.tApp (code, caption, note, checkUserRights) values ('Master', 'Master', 'Master', 0)
go
-------------------------------------------------------------------------------
-- ������������-����

create table robin.tUser (
  id int identity not null
, login varchar(100) not null
, name varchar(100) not null
, constraint pkUser primary key (id)
, constraint akUser unique (login)
)
go
grant DELETE, INSERT, REFERENCES, SELECT, UPDATE on robin.tUser to public
go

create table robin.tRole (
  id int identity not null
, code varchar(30) not null
, appcode varchar(30) not null
, note varchar(500) null
, constraint pkRole primary key (id)
, constraint akRole unique (code, appcode)
, constraint fkRoleApp foreign key (appcode) references robin.tApp(code) on delete no action on update cascade 
)
go
grant DELETE, INSERT, REFERENCES, SELECT, UPDATE on robin.tRole to public
go

create table robin.tUserRole (
  userId int not null
, roleId int not null
, constraint pkUserRole primary key (userId,roleId)
, constraint fkUserRoleUser foreign key (userId) references robin.tUser(id) on delete cascade
, constraint fkUserRoleRole foreign key (roleId) references robin.tRole(id) on delete cascade
)
go
grant DELETE, INSERT, REFERENCES, SELECT, UPDATE on robin.tUserRole to public
go

create table robin.tMarker (
  code varchar(30) not null
, note varchar(100) null
, constraint pkMarker primary key (code)
)
go
grant DELETE, INSERT, REFERENCES, SELECT, UPDATE on robin.tMarker to public
go

create table robin.tRoleMarker (
  roleId int not null
, marker varchar(30) not null
, constraint pkRoleMarker primary key (roleId, marker)
, constraint fkRoleMarkerRole foreign key (roleId) references robin.tRole(id) on delete cascade
, constraint fkRoleMarkerMarker foreign key (marker) references robin.tMarker(code) on delete cascade on update cascade 

)
go
grant DELETE, INSERT, REFERENCES, SELECT, UPDATE on robin.tRoleMarker to public
go

-------------------------------------------------------------------------------
-- �������� ������� ��� ������
create table robin.tCommand (
  code varchar(30) not null
, appcode varchar(30) not null
, cmdType int not null default 0 -- ��� �������: 0 = sql, 1 = �����: cmd='[path]assembly;namespace.class', 2 = �����: cmd='[path]assembly;namespace.class;method'
, cmd varchar(max) not null default ''
, cmdTestHead varchar(max) null
, comment varchar(500) null
, marker varchar(30) null
, constraint pkCommand primary key (code, appcode)
, constraint fkCommandApp foreign key (appcode) references robin.tApp(code) on delete no action on update cascade 
, constraint fkCommandMarker foreign key (marker) references robin.tMarker(code) on delete set null on update cascade 
)
go
grant DELETE, INSERT, REFERENCES, SELECT, UPDATE on robin.tCommand to public
go

-------------------------------------------------------------------------------
-- ������ ����, �� ����������� � ����������� �������� ��� ������ 
create table robin.tMenu (
  id int not null identity
, code varchar(30) not null
, appcode varchar(30) not null
, parentId int null -- id �������� ������ ��� null
, ord int not null -- ������� � ����/�������
, caption varchar(100) not null -- ����� ����
, img varchar(100) null -- �����������, ���� ���� �� ������ - ����� �������� � ImgAsm �������� ����������
, execType int not null default 0  -- 0 = �������, 1 = �������
, command varchar(30) null -- ��� execType = 0 - ��� �� tCommand
, marker varchar(30) null
, constraint pkMenu primary key (id)
, constraint akMenu unique (appcode, code)
, constraint fkMenuMenu foreign key (parentId) references robin.tMenu(id) on delete no action
, constraint fkMenuApp foreign key (appcode) references robin.tApp(code) on delete no action on update cascade 
, constraint fkMenuMarker foreign key (marker) references robin.tMarker(code) on delete set null on update cascade 
)
go
grant DELETE, INSERT, REFERENCES, SELECT, UPDATE on robin.tMenu to public
go

-------------------------------------------------------------------------------
-- xml � ����������� ����������� ���� ��� ������������
create table robin.tFormOptions (
  code varchar(100) not null -- �������� = ����� ������������
, appcode varchar(30) not null
, options xml null 
, constraint pkFormOptions primary key (code, appcode)
, constraint fkFormOptionsApp foreign key (appcode) references robin.tApp(code) on delete no action on update cascade 
)
go
grant DELETE, INSERT, REFERENCES, SELECT, UPDATE on robin.tFormOptions to public
go

-------------------------------------------------------------------------------
-- ���
create table robin.tLog (
  dt datetime not null
, login varchar(100) not null
, appcode varchar(30) not null
, type varchar(30) not null 
, mess varchar(max) not null
)
go
grant DELETE, INSERT, REFERENCES, SELECT, UPDATE on robin.tLog to public
go
create nonclustered index idx1Log on robin.tLog(dt)
go

