insert robin.tApp select * from dm.tApp

SET IDENTITY_INSERT robin.tUser ON
insert robin.tUser (id, login, name ) select id, login, name from dm.tUser
SET IDENTITY_INSERT robin.tUser OFF

SET IDENTITY_INSERT robin.tRole ON
insert robin.tRole (id, code, appcode, note) select id, code, appcode, note from dm.tRole
SET IDENTITY_INSERT robin.tRole OFF

insert robin.tUserRole select * from dm.tUserRole
insert robin.tMarker select * from dm.tMarker
insert robin.tRoleMarker select * from dm.tRoleMarker
insert robin.tCommand select * from dm.tCommand

SET IDENTITY_INSERT robin.tMenu ON
insert robin.tMenu (id, code, appcode, parentId, ord, caption, img, execType, command, marker) select id, code, appcode, parentId, ord, caption, img, execType, command, marker from dm.tMenu
SET IDENTITY_INSERT robin.tMenu OFF

insert robin.tFormOptions select * from dm.tFormOptions
insert robin.tLog select * from dm.tLog
  