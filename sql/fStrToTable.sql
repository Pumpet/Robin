drop function dm.fStrToTable
go
create function dm.fStrToTable (
  @str varchar(max)
, @dlm varchar(100) = ','
, @trim int = 1
)
returns @res table (val varchar(max))
as
begin
  if datalength(@dlm) = 0 select @dlm = null
  if @dlm is not null and charindex(@dlm,@str) = 0
    select @str = @str + @dlm

  declare @k int = datalength(@dlm) - 1
  ; with tmp(val,s) as
  (
  select
    convert(varchar(max), left(s, charindex(@dlm, s + @dlm) - 1)) as val
  , stuff(s, 1, charindex(@dlm, s + @dlm) + @k, '') as s
  from (values (@str)) t(s)
  union all
  select
    convert(varchar(max), left(s, charindex(@dlm, s + @dlm) - 1)) as val
  , stuff(s, 1, charindex(@dlm, s + @dlm) + @k, '') as s
   from tmp
  where datalength(s) > 0
  ), 
  res as (select case @trim when 1 then ltrim(rtrim(val)) else val end as val
            from tmp)
  insert @res (val)
  select val
    from res
   where val is not null and datalength(val) > 0 and (val <> @str or datalength(val) <> datalength(@str))
  option (maxrecursion 0)
  return
end
go
grant all on dm.fStrToTable to PUBLIC
go

-- select * from dm.fStrToTable('one,two, ,three', '', 0)
-- select * from dm.fStrToTable('one', ',', 0)
