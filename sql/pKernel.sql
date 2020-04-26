-- ������ ����������� �������� � �������, ����������� ��� ������ � Context.GetKernelData()
drop proc dm.pKernel
go
create proc dm.pKernel
  @appcode varchar(200)
as
begin
-- !!! ������� ����� ��� ���������� ��������� Context � ������ GetKernelData()
-- Context.menus
select * from dm.tMenu where appcode = @appcode and execType in (0,1)
-- Context.cmds
select * from dm.tCommand where appcode = @appcode and cmdType in (0,1,2)

end
go
grant exec on dm.pKernel to PUBLIC
go

-- exec dm.pKernel 'CommInfoCheck'

