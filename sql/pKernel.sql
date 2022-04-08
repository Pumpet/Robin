-- выдача необходимых настроек в порядке, необходимом для чтения в Context.GetKernelData()

if OBJECT_ID('robin.pKernel') is not null
  drop proc robin.pKernel
go

create proc robin.pKernel
  @appcode varchar(200)
as
begin

if not exists(select 1 from robin.tApp where code = @appcode) begin
  select @appcode = 'Не настроено приложение ' + @appcode
  raiserror(@appcode, 16, 1)
end

declare @user varchar(100) = suser_name()
if robin.fCheckUserRights(@appcode, @user, default, default) = 0
begin
  select @appcode = 'У пользователя ' + @user + ' нет допуска к приложению ' + @appcode
  raiserror(@appcode, 16, 1)
end

-- !!! порядок важен для заполнения коллекций Context в методе GetKernelData()

-- Context.menus
select 
  m.* 
  from robin.tMenu m
  where m.appcode = @appcode 
    and m.execType in (0,1)
    and robin.fCheckUserRights(@appcode, @user, default, m.marker) = 1

-- Context.cmds
select 
  c.* 
, allowed = robin.fCheckUserRights(@appcode, @user, default, c.marker)
  from robin.tCommand c
  where c.appcode = @appcode 
    and c.cmdType in (0,1,2)

-- Context.appAttrs
select * from robin.tApp where code = @appcode

end
go
grant exec on robin.pKernel to PUBLIC
go

-- exec robin.pKernel 'CommInfoCheck'

