-- 04.10.2020 20:23:43 PUMPET\SQLEXPRESS.testdb 
-- Script for 'WorkLog'

--------------------------------------------------------------------------------
-- form: FBackLogEdit

delete dm.tCommand where code = 'FBackLogEdit' and appcode = 'WorkLog'
insert dm.tCommand (code, appcode, cmdType, cmd, comment) values ('FBackLogEdit', 'WorkLog', 1, 'WorkLog.exe;WorkLog.FBackLogEdit', '')

--------------------------------------------------------------------------------
-- form: FBackLogList

delete dm.tCommand where code = 'FBackLogList' and appcode = 'WorkLog'
insert dm.tCommand (code, appcode, cmdType, cmd, comment) values ('FBackLogList', 'WorkLog', 1, 'WorkLog.exe;WorkLog.FBackLogList', '')

--------------------------------------------------------------------------------
-- form: FWorkLogEdit

delete dm.tCommand where code = 'FWorkLogEdit' and appcode = 'WorkLog'
insert dm.tCommand (code, appcode, cmdType, cmd, comment) values ('FWorkLogEdit', 'WorkLog', 1, 'WorkLog.exe;WorkLog.FWorkLogEdit', '')

--------------------------------------------------------------------------------
-- form: FWorkLogList

delete dm.tCommand where code = 'FWorkLogList' and appcode = 'WorkLog'
insert dm.tCommand (code, appcode, cmdType, cmd, comment) values ('FWorkLogList', 'WorkLog', 1, 'WorkLog.exe;WorkLog.FWorkLogList', '')

--------------------------------------------------------------------------------
-- sql: BackLogCheck

delete dm.tCommand where code = 'BackLogCheck' and appcode = 'WorkLog'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('BackLogCheck', 'WorkLog', 0, '', '', '')
update dm.tCommand set cmdTestHead = '

' where code = 'BackLogCheck' and appcode = 'WorkLog'
update dm.tCommand set cmd = '

  declare @t table (c varchar(30), t varchar(200))
  select @task = isnull(ltrim(rtrim(upper(@task))),'''')
  if @taskName = '''' 
    insert @t select ''taskName'', ''Наименование обязательно!''
  if @taskName <> '''' and exists(select 1 from itTask where taskName = ltrim(rtrim(@taskName)) and (id <> @id or @id is null))
    insert @t select ''taskName'', ''Существует задача с таким наименованием!''
  if not exists(select 1 from itTaskType where taskType = @taskType)
    insert @t select ''taskType'', ''Неправильный вид задачи!''
  if @onBR = 1 and not exists(select 1 from itTaskStates where stage = ltrim(rtrim(@stage)))
    insert @t select ''stage'', ''Неправильный статус задачи!''
  select * from @t

' where code = 'BackLogCheck' and appcode = 'WorkLog'

--------------------------------------------------------------------------------
-- sql: BackLogDel

delete dm.tCommand where code = 'BackLogDel' and appcode = 'WorkLog'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('BackLogDel', 'WorkLog', 0, '', '', '')
update dm.tCommand set cmdTestHead = '

' where code = 'BackLogDel' and appcode = 'WorkLog'
update dm.tCommand set cmd = '

  if exists(select 1 from itWorkLog where taskId = @id) 
  begin
      declare @s varchar(500) 
      select @s = ''Есть работы по задаче '' + task from itTask where id = @id
      raiserror(@s,16,1)
  end 
  else
      delete itTask where id = @id

' where code = 'BackLogDel' and appcode = 'WorkLog'

--------------------------------------------------------------------------------
-- sql: BackLogEdit

delete dm.tCommand where code = 'BackLogEdit' and appcode = 'WorkLog'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('BackLogEdit', 'WorkLog', 0, '', '', '')
update dm.tCommand set cmdTestHead = '

' where code = 'BackLogEdit' and appcode = 'WorkLog'
update dm.tCommand set cmd = '

  if @id is null
    select
      id       = null
    , taskName = ''''
    , task     = ''''
    , taskType = ''''
    , crDate   = cast(getdate() as date)
    , finDate  = convert(date,null)
    , systems  = ''''
    , numbers  = ''''
    , manager  = ''''
    , customer = ''''
    , prio     = 0
    , stage    = ''''
    , comment  = ''''
    , onBR     = 0
    , fin      = 0
    , brDate   = convert(date,null)
    , anDate   = convert(date,null)
    , devDate  = convert(date,null)
    , itDate   = convert(date,null)
    , tstDate  = convert(date,null)
    , goDate   = convert(date,null)
    , critical = 0
  else
    select * 
      from itTask 
      where id = @id

' where code = 'BackLogEdit' and appcode = 'WorkLog'

--------------------------------------------------------------------------------
-- sql: BackLogHistory

delete dm.tCommand where code = 'BackLogHistory' and appcode = 'WorkLog'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('BackLogHistory', 'WorkLog', 0, '', '', '')
update dm.tCommand set cmdTestHead = '

' where code = 'BackLogHistory' and appcode = 'WorkLog'
update dm.tCommand set cmd = '

    select h.*, isnull(u.userName, h._user) as userName
      from itTaskHistory h
        left join itUsers u on u.userId = h._user
       where id = @id
       order by h._dt desc

' where code = 'BackLogHistory' and appcode = 'WorkLog'

--------------------------------------------------------------------------------
-- sql: BackLogInsert

delete dm.tCommand where code = 'BackLogInsert' and appcode = 'WorkLog'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('BackLogInsert', 'WorkLog', 0, '', '', '')
update dm.tCommand set cmdTestHead = '

' where code = 'BackLogInsert' and appcode = 'WorkLog'
update dm.tCommand set cmd = '

  insert itTask (
    taskName
  , task     
  , taskType 
  , crDate   
  , finDate  
  , systems  
  , numbers  
  , manager  
  , customer 
  , prio     
  , stage    
  , comment  
  , onBR     
  , fin      
  , brDate   
  , anDate   
  , devDate  
  , itDate   
  , tstDate  
  , goDate   
  , critical
  )
  select
    taskName = ltrim(rtrim(@taskName))
  , task     = @task    
  , taskType = @taskType
  , crDate   = @crDate  
  , finDate  = @finDate 
  , systems  = ltrim(rtrim(@systems))
  , numbers  = ltrim(rtrim(@numbers)) 
  , manager  = ltrim(rtrim(@manager)) 
  , customer = ltrim(rtrim(@customer))
  , prio     = @prio    
  , stage    = ltrim(rtrim(@stage))
  , comment  = @comment 
  , onBR     = @onBR    
  , fin      = @fin     
  , brDate   = @brDate  
  , anDate   = @anDate  
  , devDate  = @devDate 
  , itDate   = @itDate  
  , tstDate  = @tstDate 
  , goDate   = @goDate  
  , critical = @critical
  
  if @@rowcount > 0 
    select id = convert(int,SCOPE_IDENTITY())

' where code = 'BackLogInsert' and appcode = 'WorkLog'

--------------------------------------------------------------------------------
-- sql: BackLogList

delete dm.tCommand where code = 'BackLogList' and appcode = 'WorkLog'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('BackLogList', 'WorkLog', 0, '', '', '')
update dm.tCommand set cmdTestHead = '

' where code = 'BackLogList' and appcode = 'WorkLog'
update dm.tCommand set cmd = '

  select @stage = isnull(ltrim(rtrim(@stage)),'''')
  select @systems = isnull(ltrim(rtrim(@systems)),'''')
  select @taskType = isnull(ltrim(rtrim(@taskType)),'''')
  declare @userName varchar(30) = (select userName from itUsers where userId = @user)

  select 
    id       
  , taskName
  , task     
  , taskType 
  , crDate   
  , finDate  
  , systems  
  , numbers  
  , manager  
  , customer 
  , prio     
  , stage    
  , comment  
  , onBR     
  , fin      
  , brDate   
  , anDate   
  , devDate  
  , itDate   
  , tstDate  
  , goDate   
  , critical
  , lastFinDate = (select top 1 h.finDate from itTaskHistory h where h.id = t.id and h.finDate is not null and h.finDate <> isnull(t.finDate,''19000101'') order by _dt desc)
    from itTask t
    where (@all = 1 or (@br = 1 and t.onBR = 1) or (@nobr = 1 and t.onBR = 0))
      and (@taskType = '''' or t.taskType like ''%''+@taskType+''%'')
      and (@withClosed = 1 or (@withClosed = 0 and t.fin = 0))
      and (@my = 0 
        or (@my = 1 and exists(select 1 from itWorkLog w where w.userId = @user and w.taskId = t.id))
        or (@my = 1 and @userName is not null and t.manager like ''%'' + @userName + ''%'')
      )
      and (@stage = '''' or t.stage like ''%''+@stage+''%'')
      and (@systems = '''' or t.systems like ''%''+@systems+''%'')
    order by t.taskType, t.id

' where code = 'BackLogList' and appcode = 'WorkLog'

--------------------------------------------------------------------------------
-- sql: BackLogUpdate

delete dm.tCommand where code = 'BackLogUpdate' and appcode = 'WorkLog'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('BackLogUpdate', 'WorkLog', 0, '', '', '')
update dm.tCommand set cmdTestHead = '

' where code = 'BackLogUpdate' and appcode = 'WorkLog'
update dm.tCommand set cmd = '

  update itTask set
    taskName = ltrim(rtrim(@taskName))
  , task     = @task    
  , taskType = @taskType
  , crDate   = @crDate  
  , finDate  = @finDate 
  , systems  = ltrim(rtrim(@systems)) 
  , numbers  = ltrim(rtrim(@numbers)) 
  , manager  = ltrim(rtrim(@manager)) 
  , customer = ltrim(rtrim(@customer))
  , prio     = @prio    
  , stage    = ltrim(rtrim(@stage))
  , comment  = @comment 
  , onBR     = @onBR    
  , fin      = @fin     
  , brDate   = @brDate  
  , anDate   = @anDate  
  , devDate  = @devDate 
  , itDate   = @itDate  
  , tstDate  = @tstDate 
  , goDate   = @goDate  
  , critical = @critical
    where id = @id
  
  if @@rowcount > 0   
    select id = cast(@id as int)

' where code = 'BackLogUpdate' and appcode = 'WorkLog'

--------------------------------------------------------------------------------
-- sql: WorkLogAdd

delete dm.tCommand where code = 'WorkLogAdd' and appcode = 'WorkLog'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('WorkLogAdd', 'WorkLog', 0, '', '', '')
update dm.tCommand set cmdTestHead = '
-- Объявления параметров - только для тестирования команды
' where code = 'WorkLogAdd' and appcode = 'WorkLog'
update dm.tCommand set cmd = '

  if @id is null
    select
      id = null
    , userId = @userId
    , taskId = cast(@taskId as int)
    , logDate = cast(getdate() as date)
    , logTime = 1.00
    , logType = ''''
    , comment = ''''
    , numbers = (select t.numbers from itTask t where t.id = @taskId)
    , taskName = (select t.taskName from itTask t where t.id = @taskId)
    , userName = (select u.userName from itUsers u where u.userId = @userId)
  else
    select 
    id = null
  , userId = @userId 
  , w.taskId 
  , logDate = cast(getdate() as date)
  , w.logTime
  , w.logType
  , w.comment
  , t.numbers
  , t.taskName 
  , userName = (select u.userName from itUsers u where u.userId = @userId)
    from itWorkLog w
      join itTask t on t.id = w.taskId
    where w.id = @id

' where code = 'WorkLogAdd' and appcode = 'WorkLog'

--------------------------------------------------------------------------------
-- sql: WorkLogEdit

delete dm.tCommand where code = 'WorkLogEdit' and appcode = 'WorkLog'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('WorkLogEdit', 'WorkLog', 0, '', '', '')
update dm.tCommand set cmdTestHead = '

' where code = 'WorkLogEdit' and appcode = 'WorkLog'
update dm.tCommand set cmd = '

  select 
    w.*
  , t.numbers
  , t.taskName 
  , u.userName
    from itWorkLog w
      join itUsers u on u.userId = w.userId
      join itTask t on t.id = w.taskId
    where w.id = @id

' where code = 'WorkLogEdit' and appcode = 'WorkLog'

--------------------------------------------------------------------------------
-- sql: WorkLogInsert

delete dm.tCommand where code = 'WorkLogInsert' and appcode = 'WorkLog'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('WorkLogInsert', 'WorkLog', 0, '', '', '')
update dm.tCommand set cmdTestHead = '

' where code = 'WorkLogInsert' and appcode = 'WorkLog'
update dm.tCommand set cmd = '

  insert itWorkLog (
    userId 
  , taskId 
  , logDate 
  , logTime 
  , logType
  , comment 
  )
  select
    userId  = @userId 
  , taskId  = @taskId 
  , logDate = @logDate
  , logTime = @logTime
  , logType = @logType
  , comment = @comment
  
  if @@rowcount > 0 
    select id = convert(int,SCOPE_IDENTITY())

' where code = 'WorkLogInsert' and appcode = 'WorkLog'

--------------------------------------------------------------------------------
-- sql: WorkLogList

delete dm.tCommand where code = 'WorkLogList' and appcode = 'WorkLog'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('WorkLogList', 'WorkLog', 0, '', '', '')
update dm.tCommand set cmdTestHead = '

' where code = 'WorkLogList' and appcode = 'WorkLog'
update dm.tCommand set cmd = '

declare @df int = @@datefirst
set datefirst 1

; with wl as (
    select * from itWorkLog 
      where @taskId is not null and @taskId <> -1 and taskId = @taskId
    union 
    select * from itWorkLog 
      where @taskId = -1
       and (logDate >= @dateFrom or @dateFrom is null)
       and (logDate <= @dateTo or @dateTo is null)
  )
  select 
    wl.*
  , u.userName
  , t.numbers
  , t.taskName 
  , allTime = isnull((select sum(w.logTime) from itWorkLog w where w.logDate = wl.logDate and w.userId = wl.userId),0)
  , wday = case datepart(dw, wl.logDate) when 1 then ''ПН'' when 2 then ''ВТ'' when 3 then ''СР'' when 4 then ''ЧТ'' when 5 then ''ПТ'' when 6 then ''СБ'' when 7 then ''ВС'' end
  , taskTime = sum(wl.logTime) over()
    from wl 
      join itUsers u on u.userId = wl.userId
      join itTask t on t.id = wl.taskId
    where ((@myWork = 1 and u.userId = @user) or @myWork = 0)
    order by wl.logDate, u.userName, wl.id

set datefirst @df

' where code = 'WorkLogList' and appcode = 'WorkLog'

--------------------------------------------------------------------------------
-- sql: WorkLogReport

delete dm.tCommand where code = 'WorkLogReport' and appcode = 'WorkLog'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('WorkLogReport', 'WorkLog', 0, '', '', '')
update dm.tCommand set cmdTestHead = '

' where code = 'WorkLogReport' and appcode = 'WorkLog'
update dm.tCommand set cmd = '

  select 
    w.logDate
  , w.logTime
  , w.logType
  , w.comment
  , t.numbers
  , t.taskName 
  , u.userName
    from itWorkLog w 
      join itUsers u on u.userId = w.userId
      join itTask t on t.id = w.taskId
    where (w.logDate >= @dateFrom or @dateFrom is null)
      and (w.logDate <= @dateTo or @dateTo is null)
      and u.otdel = 1
    order by w.logDate, u.userName, w.id

' where code = 'WorkLogReport' and appcode = 'WorkLog'

--------------------------------------------------------------------------------
-- sql: WorkLogUpdate

delete dm.tCommand where code = 'WorkLogUpdate' and appcode = 'WorkLog'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('WorkLogUpdate', 'WorkLog', 0, '', '', '')
update dm.tCommand set cmdTestHead = '

' where code = 'WorkLogUpdate' and appcode = 'WorkLog'
update dm.tCommand set cmd = '

  update itWorkLog set
    userId  = @userId 
  , taskId  = @taskId 
  , logDate = @logDate
  , logTime = @logTime
  , logType = @logType
  , comment = @comment
    where id = @id
  
  if @@rowcount > 0   
    select id = cast(@id as int)

' where code = 'WorkLogUpdate' and appcode = 'WorkLog'
