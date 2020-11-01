-- ������ ����������� �������� � �������, ����������� ��� ������ � Context.GetKernelData()
drop proc dm.pKernel
go
create proc dm.pKernel
  @appcode varchar(200)
as
begin

if not exists(select 1 from dm.tApp where code = @appcode) begin
  select @appcode = '�� ��������� ���������� ' + @appcode
  raiserror(@appcode, 16, 1)
end

declare @user varchar(100) = suser_name()
if dm.fCheckUserRights(@appcode, @user, default, default) = 0
begin
  select @appcode = '� ������������ ' + @user + ' ��� ������� � ���������� ' + @appcode
  raiserror(@appcode, 16, 1)
end

-- !!! ������� ����� ��� ���������� ��������� Context � ������ GetKernelData()

-- Context.menus
select 
  m.* 
  from dm.tMenu m
  where m.appcode = @appcode 
    and m.execType in (0,1)
    and dm.fCheckUserRights(@appcode, @user, default, m.marker) = 1

-- Context.cmds
select 
  c.* 
, allowed = dm.fCheckUserRights(@appcode, @user, default, c.marker)
  from dm.tCommand c
  where c.appcode = @appcode 
    and c.cmdType in (0,1,2)

-- Context.appAttrs
select * from dm.tApp where code = @appcode

end
go
grant exec on dm.pKernel to PUBLIC
go

-- exec dm.pKernel 'CommInfoCheck'

