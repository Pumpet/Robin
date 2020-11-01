drop function dm.fCheckUserRights
go
create function dm.fCheckUserRights (
  @appcode varchar(30)
, @login varchar(100) = null
, @role varchar(30) = null
, @marker varchar(30) = null
)
returns bit
as
begin
  if not exists(select 1 from dm.tApp where code = @appcode) 
    return 0
  if exists(select 1 from dm.tApp where code = @appcode and checkUserRights = 0) 
    return 1
  
  if @login is null select @login = suser_name()

  declare @res int
  
  select @res = count(*)
    from dm.tUser u
      join dm.tUserRole ur on ur.userId = u.id and u.login = @login
      join dm.tRole r on r.id = ur.roleId  and r.appcode = @appcode and (@role is null or (@role is not null and r.code = @role))
    where @marker is null
      or (@marker is not null 
        and exists(select 1 from dm.tRoleMarker rm where rm.roleId = r.id and rm.marker = @marker))
  
  return case @res when 0 then 0 else 1 end
end
go
grant all on dm.fCheckUserRights to PUBLIC
go

-- select dm.fCheckUserRights('Robin', null, null, null)

