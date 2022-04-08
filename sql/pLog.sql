if OBJECT_ID('robin.pLog') is not null
  drop proc robin.pLog
go

create proc robin.pLog
  @login varchar(100) 
, @appcode varchar(30) 
, @type varchar(30) 
, @mess varchar(max) 
as
begin

insert robin.tLog (
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

grant exec on robin.pLog to PUBLIC
go

-- select * from robin.tLog

