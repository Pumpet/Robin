drop proc dm.pLog
go
create proc dm.pLog
  @login varchar(100) 
, @appcode varchar(30) 
, @type varchar(30) 
, @mess varchar(max) 
as
begin

insert dm.tLog (
  dt     
, login  
, appcode
, type   
, mess   
)
select
  dt      = getdate()
, login   = isnull(@login, suser_name())
, appcode = isnull(@appcode, '')
, type    = isnull(@type, '') 
, mess    = isnull(@mess, '')  

end
go
grant exec on dm.pLog to PUBLIC
go

-- select * from dm.tLog

