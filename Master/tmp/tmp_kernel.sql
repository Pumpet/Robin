-- select * from dm.tFormOptions where appcode = 'Master'
-- delete dm.tFormOptions where appcode = 'Master' and code = ''

delete dm.tCommand where cmdType in (1,2) and appcode = 'Tmp'
insert dm.tCommand (code, appcode, cmdType, cmd)
values 
  ('FCommandList', 'Tmp', 1, 'Master.exe;Master.FCommandList')

-------------------------------------------------------------------------------
delete dm.tMenu where appcode = 'Tmp'
insert dm.tMenu (code, appcode, parent, ord, caption, img, execType, command)
values
  ('miCommandList', 'Tmp', null, 1, 'Команды', null, 0, 'FCommandList')

-------------------------------------------------------------------------------
delete dm.tCommand where code = 'CommandList' and appcode = 'Tmp'
insert dm.tCommand (code, appcode, cmdType, cmd) values ('CommandList', 'Tmp', 0, '')
update dm.tCommand set cmd = '
select @app = isnull(ltrim(rtrim(@app)),'''')
declare @types table (id int, name varchar(30))
insert @types values (0, ''sql''), (1, ''form''), (2, ''method'')
--declare @itype int = case @type when ''sql'' then 0 when ''form'' then 1 when ''method'' then 2 else -1 end
select 
  c.appcode
, t.name
, c.code 
, c.cmd
, c.cmdType
  from dm.tCommand c
    join @types t on t.id = c.cmdType
  where (@app = '''' or c.appcode = @app)
    and (@type = '''' or t.name = @type)
  order by c.appcode, c.cmdType, c.code
' where code = 'CommandList' and appcode = 'Tmp'

