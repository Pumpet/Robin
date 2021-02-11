-- 04.10.2020 20:23:23 PUMPET\SQLEXPRESS.testdb 
-- Script for 'RegDepo'

--------------------------------------------------------------------------------
-- method: FMess

delete dm.tCommand where code = 'FMess' and appcode = 'RegDepo'
insert dm.tCommand (code, appcode, cmdType, cmd, comment) values ('FMess', 'RegDepo', 2, 'RegDepo.exe;RegDepo.FMain;Mess', '')

--------------------------------------------------------------------------------
-- form: FRegInEdit

delete dm.tCommand where code = 'FRegInEdit' and appcode = 'RegDepo'
insert dm.tCommand (code, appcode, cmdType, cmd, comment) values ('FRegInEdit', 'RegDepo', 1, 'RegDepo.exe;RegDepo.FRegInEdit', '')

--------------------------------------------------------------------------------
-- form: FRegInList

delete dm.tCommand where code = 'FRegInList' and appcode = 'RegDepo'
insert dm.tCommand (code, appcode, cmdType, cmd, comment) values ('FRegInList', 'RegDepo', 1, 'RegDepo.exe;RegDepo.FRegInList', '')

--------------------------------------------------------------------------------
-- form: FRegOperEdit

delete dm.tCommand where code = 'FRegOperEdit' and appcode = 'RegDepo'
insert dm.tCommand (code, appcode, cmdType, cmd, comment) values ('FRegOperEdit', 'RegDepo', 1, 'RegDepo.exe;RegDepo.FRegOperEdit', '')

--------------------------------------------------------------------------------
-- form: FRegOperList

delete dm.tCommand where code = 'FRegOperList' and appcode = 'RegDepo'
insert dm.tCommand (code, appcode, cmdType, cmd, comment) values ('FRegOperList', 'RegDepo', 1, 'RegDepo.exe;RegDepo.FRegOperList', '')

--------------------------------------------------------------------------------
-- form: FRegOutEdit

delete dm.tCommand where code = 'FRegOutEdit' and appcode = 'RegDepo'
insert dm.tCommand (code, appcode, cmdType, cmd, comment) values ('FRegOutEdit', 'RegDepo', 1, 'RegDepo.exe;RegDepo.FRegOutEdit', '')

--------------------------------------------------------------------------------
-- form: FRegOutList

delete dm.tCommand where code = 'FRegOutList' and appcode = 'RegDepo'
insert dm.tCommand (code, appcode, cmdType, cmd, comment) values ('FRegOutList', 'RegDepo', 1, 'RegDepo.exe;RegDepo.FRegOutList', '')

--------------------------------------------------------------------------------
-- sql: RegDelete

delete dm.tCommand where code = 'RegDelete' and appcode = 'RegDepo'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('RegDelete', 'RegDepo', 0, '', '', 'удаление записей и связей')
update dm.tCommand set cmdTestHead = '
--
' where code = 'RegDelete' and appcode = 'RegDepo'
update dm.tCommand set cmd = '
if @mode = ''RegInDelete''
  delete tRegDepoIn where id = @id

if @mode = ''RegOutDelete''
  delete tRegDepoOut where id = @id  
if @mode = ''RegOutDeleteDetIn''
  update tRegDepoOut set inRegId = null where id = @id  
  
if @mode = ''RegOperDelete''
  delete tRegDepoOper where id = @id    
if @mode = ''RegOperDeleteDetIn''
  update tRegDepoOper set inRegId = null where id = @id  
if @mode = ''RegOperDeleteDetOut''
  update tRegDepoOper set outRegId = null where id = @id  

' where code = 'RegDelete' and appcode = 'RegDepo'

--------------------------------------------------------------------------------
-- sql: RegInAdd

delete dm.tCommand where code = 'RegInAdd' and appcode = 'RegDepo'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('RegInAdd', 'RegDepo', 0, '', '', 'входящие - редактор - добавить')
update dm.tCommand set cmdTestHead = '
-- 
' where code = 'RegInAdd' and appcode = 'RegDepo'
update dm.tCommand set cmd = '
if @id is null
  select 
    regNo      = ''''
  , regDate    = getdate()
  , regType    = null
  , regName    = ''''
  , objType    = null
  , objKey     = ''''
  , objName    = ''''
  , clientName = ''''
  , sysType    = null
  , sysKey     = ''''
  , sysDocNo   = ''''
  , sysDocRef  = ''''
  , sysDocDate = convert(date,null)
  , corrName   = ''''
  , note       = ''''

else
  select 
    regNo      = ''''
  , regDate    = getdate()
  , regType    = regType   
  , regName    = regName   
  , objType    = objType   
  , objKey     = objKey    
  , objName    = objName   
  , clientName = clientName
  , sysType    = sysType   
  , sysKey     = sysKey    
  , sysDocNo   = sysDocNo  
  , sysDocRef  = sysDocRef 
  , sysDocDate = sysDocDate
  , corrName   = corrName  
  , note       = note      
  , regTypeName = t.name  
  , objTypeName = ot.name  
  , sysTypeName = st.name  
    from tRegDepoIn i 
      join tRegDepoTypes t on t.code = i.regType
      left join tRegDepoObjTypes ot on ot.code = i.objType
      left join tRegDepoSysTypes st on st.code = i.sysType    
      where i.id = @id
' where code = 'RegInAdd' and appcode = 'RegDepo'

--------------------------------------------------------------------------------
-- sql: RegInEdit

delete dm.tCommand where code = 'RegInEdit' and appcode = 'RegDepo'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('RegInEdit', 'RegDepo', 0, '', '', 'входящие - редактор - изменить')
update dm.tCommand set cmdTestHead = '
declare @id int  = 1
' where code = 'RegInEdit' and appcode = 'RegDepo'
update dm.tCommand set cmd = '
select 
  i.*
, regTypeName = t.name  
, objTypeName = ot.name  
, sysTypeName = st.name  
  from tRegDepoIn i 
    join tRegDepoTypes t on t.code = i.regType
    left join tRegDepoObjTypes ot on ot.code = i.objType
    left join tRegDepoSysTypes st on st.code = i.sysType    
    where i.id = @id

' where code = 'RegInEdit' and appcode = 'RegDepo'

--------------------------------------------------------------------------------
-- sql: RegInInsert

delete dm.tCommand where code = 'RegInInsert' and appcode = 'RegDepo'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('RegInInsert', 'RegDepo', 0, '', '', 'входящие - вставка')
update dm.tCommand set cmdTestHead = '
--
' where code = 'RegInInsert' and appcode = 'RegDepo'
update dm.tCommand set cmd = '
insert tRegDepoIn (
  regNo      
, regDate    
, regType    
, regName    
, objType    
, objKey     
, objName    
, clientName 
, sysType    
, sysKey     
, sysDocNo   
, sysDocRef  
, sysDocDate 
, corrName   
, userName   
, userId     
, note       
)
select 
  regNo      = @regNo     
, regDate    = @regDate   
, regType    = @regType   
, regName    = @regName   
, objType    = @objType   
, objKey     = @objKey    
, objName    = @objName   
, clientName = @clientName
, sysType    = @sysType   
, sysKey     = @sysKey    
, sysDocNo   = @sysDocNo  
, sysDocRef  = @sysDocRef 
, sysDocDate = @sysDocDate
, corrName   = @corrName  
, userName   = suser_name()
, userId     = suser_name()
, note       = @note
  
if @@rowcount > 0 
  select id = convert(int,SCOPE_IDENTITY())
  
' where code = 'RegInInsert' and appcode = 'RegDepo'

--------------------------------------------------------------------------------
-- sql: RegInList

delete dm.tCommand where code = 'RegInList' and appcode = 'RegDepo'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('RegInList', 'RegDepo', 0, '', '', 'входящие - список')
update dm.tCommand set cmdTestHead = '
-- 
' where code = 'RegInList' and appcode = 'RegDepo'
update dm.tCommand set cmd = '
select @typeCode = isnull(ltrim(rtrim(@typeCode)),'''')
select @objName = isnull(ltrim(rtrim(@objName)),'''')

select 
  i.*
, regTypeName = t.name  
  from tRegDepoIn i 
    join tRegDepoTypes t on t.code = i.regType
  where i.regDate >= @dateFrom and i.regDate < dateadd(dd,1,@dateTo)
    and (@typeCode = '''' or (@typeCode <> '''' and t.code = @typeCode))
    and (@objName = '''' or (@objName <> '''' and i.objName like ''%'' + @objName + ''%''))
' where code = 'RegInList' and appcode = 'RegDepo'

--------------------------------------------------------------------------------
-- sql: RegInUpdate

delete dm.tCommand where code = 'RegInUpdate' and appcode = 'RegDepo'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('RegInUpdate', 'RegDepo', 0, '', '', 'входящие - обновление')
update dm.tCommand set cmdTestHead = '
-- 
' where code = 'RegInUpdate' and appcode = 'RegDepo'
update dm.tCommand set cmd = '
update tRegDepoIn set
  regNo      = @regNo     
, regDate    = @regDate   
, regType    = @regType   
, regName    = @regName   
, objType    = @objType   
, objKey     = @objKey    
, objName    = @objName   
, clientName = @clientName
, sysType    = @sysType   
, sysKey     = @sysKey    
, sysDocNo   = @sysDocNo  
, sysDocRef  = @sysDocRef 
, sysDocDate = @sysDocDate
, corrName   = @corrName  
, userName   = suser_name()
, userId     = suser_name()
, note       = @note
  where id = @id
  
  if @@rowcount > 0   
    select id = cast(@id as int)
' where code = 'RegInUpdate' and appcode = 'RegDepo'

--------------------------------------------------------------------------------
-- sql: RegObjTypes

delete dm.tCommand where code = 'RegObjTypes' and appcode = 'RegDepo'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('RegObjTypes', 'RegDepo', 0, '', '', 'комбо типы объектов')
update dm.tCommand set cmdTestHead = '
-- 
' where code = 'RegObjTypes' and appcode = 'RegDepo'
update dm.tCommand set cmd = '
select code, name 
  from tRegDepoObjTypes 
  where upper(modes) like ''%'' + @mode + ''%''
union 
  select code = '''', name = '''' 
order by name
' where code = 'RegObjTypes' and appcode = 'RegDepo'

--------------------------------------------------------------------------------
-- sql: RegOperAdd

delete dm.tCommand where code = 'RegOperAdd' and appcode = 'RegDepo'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('RegOperAdd', 'RegDepo', 0, '', '', 'операции - редактор - добавить')
update dm.tCommand set cmdTestHead = '
-- 
' where code = 'RegOperAdd' and appcode = 'RegDepo'
update dm.tCommand set cmd = '
if @id is null
  select 
    regNo      = ''''
  , regDate    = getdate()
  , regType    = null
  , objType    = null
  , objKey     = ''''
  , objName    = ''''
  , clientName = ''''
  , sysType    = null
  , sysKey     = ''''
  , sysDocNo   = ''''
  , sysDocRef  = ''''
  , note       = ''''
  , accActive  = ''''
  , operDate   = getdate()
  , inRegId    = null
  , outRegId   = null  
  , inRegNo    = ''''
  , inRegName  = '''' 
  , outRegNo   = ''''
  , outRegName = ''''   

else
  select 
    regNo      = ''''
  , regDate    = getdate()
  , regType    = op.regType   
  , objType    = op.objType   
  , objKey     = op.objKey    
  , objName    = op.objName   
  , clientName = op.clientName
  , sysType    = op.sysType   
  , sysKey     = op.sysKey    
  , sysDocNo   = op.sysDocNo  
  , sysDocRef  = op.sysDocRef 
  , note       = op.note    
  , accActive  = op.accActive
  , operDate   = op.operDate
  , inRegId    = op.inRegId
  , outRegId   = op.outRegId
  , regTypeName = t.name  
  , objTypeName = ot.name  
  , sysTypeName = st.name  
  , inRegNo     = i.regNo
  , inRegName   = i.regName
  , outRegNo    = o.regNo
  , outRegName  = o.regName  
  
  from tRegDepoOper op 
         join tRegDepoTypes t on t.code = op.regType
         left join tRegDepoObjTypes ot on ot.code = op.objType
         left join tRegDepoSysTypes st on st.code = op.sysType    
         left join tRegDepoIn i on i.id = op.inRegId    
         left join tRegDepoOut o on o.id = op.outRegId          
  where op.id = @id
      
' where code = 'RegOperAdd' and appcode = 'RegDepo'

--------------------------------------------------------------------------------
-- sql: RegOperEdit

delete dm.tCommand where code = 'RegOperEdit' and appcode = 'RegDepo'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('RegOperEdit', 'RegDepo', 0, '', '', 'операции - редактор - изменить')
update dm.tCommand set cmdTestHead = '
-- 
' where code = 'RegOperEdit' and appcode = 'RegDepo'
update dm.tCommand set cmd = '
select 
  op.*
, regTypeName = t.name  
, objTypeName = ot.name  
, sysTypeName = st.name  
, inRegNo     = i.regNo
, inRegName   = i.regName
, outRegNo    = o.regNo
, outRegName  = o.regName
  from tRegDepoOper op
    join tRegDepoTypes t on t.code = op.regType
    left join tRegDepoObjTypes ot on ot.code = op.objType
    left join tRegDepoSysTypes st on st.code = op.sysType    
    left join tRegDepoIn i on i.id = op.inRegId
    left join tRegDepoOut o on o.id = op.outRegId    
    where op.id = @id

' where code = 'RegOperEdit' and appcode = 'RegDepo'

--------------------------------------------------------------------------------
-- sql: RegOperInsert

delete dm.tCommand where code = 'RegOperInsert' and appcode = 'RegDepo'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('RegOperInsert', 'RegDepo', 0, '', '', 'операции - вставка')
update dm.tCommand set cmdTestHead = '
--
' where code = 'RegOperInsert' and appcode = 'RegDepo'
update dm.tCommand set cmd = '
insert tRegDepoOper (
  regNo      
, regDate    
, regType    
, objType    
, objKey     
, objName    
, clientName 
, sysType    
, sysKey     
, sysDocNo   
, sysDocRef  
, userName   
, userId     
, note       
, accActive  
, operDate   
, inRegId    
, outRegId   
)
select 
  regNo      = @regNo     
, regDate    = @regDate   
, regType    = @regType   
, objType    = @objType   
, objKey     = @objKey    
, objName    = @objName   
, clientName = @clientName
, sysType    = @sysType   
, sysKey     = @sysKey    
, sysDocNo   = @sysDocNo  
, sysDocRef  = @sysDocRef 
, userName   = suser_name()
, userId     = suser_name()
, note       = @note
, accActive  = @accActive
, operDate   = @operDate
, inRegId    = @inRegId
, outRegId   = @outRegId
  
if @@rowcount > 0 
  select id = convert(int,SCOPE_IDENTITY())
  
' where code = 'RegOperInsert' and appcode = 'RegDepo'

--------------------------------------------------------------------------------
-- sql: RegOperList

delete dm.tCommand where code = 'RegOperList' and appcode = 'RegDepo'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('RegOperList', 'RegDepo', 0, '', '', 'операции - список')
update dm.tCommand set cmdTestHead = '
--
' where code = 'RegOperList' and appcode = 'RegDepo'
update dm.tCommand set cmd = '
select @typeCode = isnull(ltrim(rtrim(@typeCode)),'''')
select @objName = isnull(ltrim(rtrim(@objName)),'''')
select @inRegNo = isnull(ltrim(rtrim(@inRegNo)),'''')
select @outRegNo = isnull(ltrim(rtrim(@outRegNo)),'''')

select 
  op.*
, regTypeName = t.name  
, inRegNo = i.regNo
, outRegNo = o.regNo
  from tRegDepoOper op 
    join tRegDepoTypes t on t.code = op.regType
    left join tRegDepoIn i on i.id = op.inRegId
    left join tRegDepoOut o on o.id = op.outRegId
  where op.regDate >= @dateFrom and op.regDate < dateadd(dd,1,@dateTo)
    and (@typeCode = '''' or (@typeCode <> '''' and t.code = @typeCode))
    and (@objName = '''' or (@objName <> '''' and op.objName like ''%'' + @objName + ''%''))
    and (@inRegNo = '''' or (@inRegNo <> '''' and i.regNo is not null and i.regNo like @inRegNo))
    and (@outRegNo = '''' or (@outRegNo <> '''' and o.regNo is not null and o.regNo like @outRegNo))    
    
    

' where code = 'RegOperList' and appcode = 'RegDepo'

--------------------------------------------------------------------------------
-- sql: RegOperListDetIn

delete dm.tCommand where code = 'RegOperListDetIn' and appcode = 'RegDepo'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('RegOperListDetIn', 'RegDepo', 0, '', '', 'операции - под входящим')
update dm.tCommand set cmdTestHead = '
-- 
' where code = 'RegOperListDetIn' and appcode = 'RegDepo'
update dm.tCommand set cmd = '
select 
  op.* 
, regTypeName = t.name   
  from tRegDepoOper op
    join tRegDepoTypes t on t.code = op.regType
  where inRegId = @parentId
  
' where code = 'RegOperListDetIn' and appcode = 'RegDepo'

--------------------------------------------------------------------------------
-- sql: RegOperListDetOut

delete dm.tCommand where code = 'RegOperListDetOut' and appcode = 'RegDepo'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('RegOperListDetOut', 'RegDepo', 0, '', '', 'операции - под исходящим')
update dm.tCommand set cmdTestHead = '
-- 
' where code = 'RegOperListDetOut' and appcode = 'RegDepo'
update dm.tCommand set cmd = '
select 
  op.* 
, regTypeName = t.name   
  from tRegDepoOper op
    join tRegDepoTypes t on t.code = op.regType
    where outRegId = @parentId
' where code = 'RegOperListDetOut' and appcode = 'RegDepo'

--------------------------------------------------------------------------------
-- sql: RegOperUpdate

delete dm.tCommand where code = 'RegOperUpdate' and appcode = 'RegDepo'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('RegOperUpdate', 'RegDepo', 0, '', '', 'операции - обновление')
update dm.tCommand set cmdTestHead = '
-- 
' where code = 'RegOperUpdate' and appcode = 'RegDepo'
update dm.tCommand set cmd = '
update tRegDepoOper set
  regNo      = @regNo     
, regDate    = @regDate   
, regType    = @regType   
, objType    = @objType   
, objKey     = @objKey    
, objName    = @objName   
, clientName = @clientName
, sysType    = @sysType   
, sysKey     = @sysKey    
, sysDocNo   = @sysDocNo  
, sysDocRef  = @sysDocRef 
, userName   = suser_name()
, userId     = suser_name()
, note       = @note
, accActive  = @accActive
, operDate   = @operDate
, inRegId    = @inRegId
, outRegId   = @outRegId
  where id = @id
  
  if @@rowcount > 0   
    select id = cast(@id as int)
' where code = 'RegOperUpdate' and appcode = 'RegDepo'

--------------------------------------------------------------------------------
-- sql: RegOutAdd

delete dm.tCommand where code = 'RegOutAdd' and appcode = 'RegDepo'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('RegOutAdd', 'RegDepo', 0, '', '', 'исходящие - редактор - добавить')
update dm.tCommand set cmdTestHead = '
--
' where code = 'RegOutAdd' and appcode = 'RegDepo'
update dm.tCommand set cmd = '
if @id is null
  select 
    regNo      = ''''
  , regDate    = getdate()
  , regType    = null
  , regName    = ''''
  , objType    = null
  , objKey     = ''''
  , objName    = ''''
  , clientName = ''''
  , sysType    = null
  , sysKey     = ''''
  , sysDocNo   = ''''
  , sysDocRef  = ''''
  , sysDocDate = convert(date,null)
  , corrName   = ''''
  , note       = ''''
  , outDate    = getdate()
  , inRegId    = null
  , inRegNo    = ''''
  , inRegName  = '''' 

else
  select 
    regNo      = ''''
  , regDate    = getdate()
  , regType    = o.regType   
  , regName    = o.regName   
  , objType    = o.objType   
  , objKey     = o.objKey    
  , objName    = o.objName   
  , clientName = o.clientName
  , sysType    = o.sysType   
  , sysKey     = o.sysKey    
  , sysDocNo   = o.sysDocNo  
  , sysDocRef  = o.sysDocRef 
  , sysDocDate = o.sysDocDate
  , corrName   = o.corrName  
  , note       = o.note    
  , outDate    = o.outDate
  , inRegId    = o.inRegId
  , regTypeName = t.name  
  , objTypeName = ot.name  
  , sysTypeName = st.name  
  , inRegNo    = i.regNo
  , inRegName  = i.regName
    from tRegDepoOut o 
      join tRegDepoTypes t on t.code = o.regType
      left join tRegDepoObjTypes ot on ot.code = o.objType
      left join tRegDepoSysTypes st on st.code = o.sysType    
      left join tRegDepoIn i on i.id = o.inRegId    
    where o.id = @id
      
' where code = 'RegOutAdd' and appcode = 'RegDepo'

--------------------------------------------------------------------------------
-- sql: RegOutEdit

delete dm.tCommand where code = 'RegOutEdit' and appcode = 'RegDepo'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('RegOutEdit', 'RegDepo', 0, '', '', 'исходящие - редактор - изменить')
update dm.tCommand set cmdTestHead = '
-- 
' where code = 'RegOutEdit' and appcode = 'RegDepo'
update dm.tCommand set cmd = '
select 
  o.*
, regTypeName = t.name  
, objTypeName = ot.name  
, sysTypeName = st.name  
, inRegNo     = i.regNo
, inRegName   = i.regName
  from tRegDepoOut o
  join tRegDepoTypes t on t.code = o.regType
    left join tRegDepoObjTypes ot on ot.code = o.objType
    left join tRegDepoSysTypes st on st.code = o.sysType    
    left join tRegDepoIn i on i.id = o.inRegId
    where o.id = @id

' where code = 'RegOutEdit' and appcode = 'RegDepo'

--------------------------------------------------------------------------------
-- sql: RegOutInsert

delete dm.tCommand where code = 'RegOutInsert' and appcode = 'RegDepo'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('RegOutInsert', 'RegDepo', 0, '', '', 'исходящие - вставка')
update dm.tCommand set cmdTestHead = '
-- 
' where code = 'RegOutInsert' and appcode = 'RegDepo'
update dm.tCommand set cmd = '
insert tRegDepoOut (
  regNo      
, regDate    
, regType    
, regName    
, objType    
, objKey     
, objName    
, clientName 
, sysType    
, sysKey     
, sysDocNo   
, sysDocRef  
, sysDocDate 
, corrName   
, userName   
, userId     
, note       
, outDate    
, inRegId    
)
select 
  regNo      = @regNo     
, regDate    = @regDate   
, regType    = @regType   
, regName    = @regName   
, objType    = @objType   
, objKey     = @objKey    
, objName    = @objName   
, clientName = @clientName
, sysType    = @sysType   
, sysKey     = @sysKey    
, sysDocNo   = @sysDocNo  
, sysDocRef  = @sysDocRef 
, sysDocDate = @sysDocDate
, corrName   = @corrName  
, userName   = suser_name()
, userId     = suser_name()
, note       = @note
, outDate    = @outDate
, inRegId    = @inRegId
  
if @@rowcount > 0 
  select id = convert(int,SCOPE_IDENTITY())
  
' where code = 'RegOutInsert' and appcode = 'RegDepo'

--------------------------------------------------------------------------------
-- sql: RegOutList

delete dm.tCommand where code = 'RegOutList' and appcode = 'RegDepo'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('RegOutList', 'RegDepo', 0, '', '', 'исходящие - список')
update dm.tCommand set cmdTestHead = '
-- 
' where code = 'RegOutList' and appcode = 'RegDepo'
update dm.tCommand set cmd = '
select @typeCode = isnull(ltrim(rtrim(@typeCode)),'''')
select @objName = isnull(ltrim(rtrim(@objName)),'''')
select @inRegNo = isnull(ltrim(rtrim(@inRegNo)),'''')

select 
  o.*
, regTypeName = t.name  
, inRegNo = i.regNo
  from tRegDepoOut o 
    join tRegDepoTypes t on t.code = o.regType
    left join tRegDepoIn i on i.id = o.inRegId
  where o.regDate >= @dateFrom and o.regDate < dateadd(dd,1,@dateTo)
    and (@typeCode = '''' or (@typeCode <> '''' and t.code = @typeCode))
    and (@objName = '''' or (@objName <> '''' and o.objName like ''%'' + @objName + ''%''))
    and (@inRegNo = '''' or (@inRegNo <> '''' and i.regNo is not null and i.regNo like @inRegNo))

' where code = 'RegOutList' and appcode = 'RegDepo'

--------------------------------------------------------------------------------
-- sql: RegOutListDet

delete dm.tCommand where code = 'RegOutListDet' and appcode = 'RegDepo'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('RegOutListDet', 'RegDepo', 0, '', '', 'исходящие - под входящим')
update dm.tCommand set cmdTestHead = '
-- 
' where code = 'RegOutListDet' and appcode = 'RegDepo'
update dm.tCommand set cmd = '
select 
  o.* 
, regTypeName = t.name   
  from tRegDepoOut o
    join tRegDepoTypes t on t.code = o.regType
  where inRegId = @parentId
' where code = 'RegOutListDet' and appcode = 'RegDepo'

--------------------------------------------------------------------------------
-- sql: RegOutUpdate

delete dm.tCommand where code = 'RegOutUpdate' and appcode = 'RegDepo'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('RegOutUpdate', 'RegDepo', 0, '', '', 'исходящие - обновление')
update dm.tCommand set cmdTestHead = '
-- 
' where code = 'RegOutUpdate' and appcode = 'RegDepo'
update dm.tCommand set cmd = '
update tRegDepoOut set
  regNo      = @regNo     
, regDate    = @regDate   
, regType    = @regType   
, regName    = @regName   
, objType    = @objType   
, objKey     = @objKey    
, objName    = @objName   
, clientName = @clientName
, sysType    = @sysType   
, sysKey     = @sysKey    
, sysDocNo   = @sysDocNo  
, sysDocRef  = @sysDocRef 
, sysDocDate = @sysDocDate
, corrName   = @corrName  
, userName   = suser_name()
, userId     = suser_name()
, note       = @note
, outDate    = @outDate    
, inRegId    = @inRegId
  where id = @id
  
  if @@rowcount > 0   
    select id = cast(@id as int)
' where code = 'RegOutUpdate' and appcode = 'RegDepo'

--------------------------------------------------------------------------------
-- sql: RegSaveCheck

delete dm.tCommand where code = 'RegSaveCheck' and appcode = 'RegDepo'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('RegSaveCheck', 'RegDepo', 0, '', '', 'проверки перед сохранением')
update dm.tCommand set cmdTestHead = '
-- 
' where code = 'RegSaveCheck' and appcode = 'RegDepo'
update dm.tCommand set cmd = '
  declare @t table (c varchar(30), t varchar(200))
  declare @ms varchar(100) = ''не задано обязательное поле!''

  if isnull(ltrim(rtrim(@regNo)),'''') = '''' insert @t select ''regNo'', @ms
  if isnull(@regDate,''19000101'') = ''19000101'' insert @t select ''regDate'', @ms    
  if isnull(ltrim(rtrim(@regType)),'''') = '''' insert @t select ''regTypeName'', @ms  
  if @mode <> ''OP'' and isnull(ltrim(rtrim(@regName)),'''') = '''' insert @t select ''regName'', @ms    
  if isnull(ltrim(rtrim(@objName)),'''') = '''' insert @t select ''objName'', @ms   
  if isnull(ltrim(rtrim(@clientName)),'''') = '''' insert @t select ''clientName'', @ms     
  if @mode <> ''OP'' and isnull(ltrim(rtrim(@corrName)),'''') = '''' insert @t select ''corrName'', @ms      
  if @mode = ''OP'' and isnull(ltrim(rtrim(@accActive)),'''') = '''' insert @t select ''accActive'', @ms      
  if @mode = ''OP'' and isnull(@operDate,''19000101'') = ''19000101'' insert @t select ''operDate'', @ms      
  if @mode = ''OUT'' and isnull(@outDate,''19000101'') = ''19000101'' insert @t select ''outDate'', @ms        
  
  select * from @t

' where code = 'RegSaveCheck' and appcode = 'RegDepo'

--------------------------------------------------------------------------------
-- sql: RegSysTypes

delete dm.tCommand where code = 'RegSysTypes' and appcode = 'RegDepo'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('RegSysTypes', 'RegDepo', 0, '', '', 'комбо системные типы')
update dm.tCommand set cmdTestHead = '
-- 
' where code = 'RegSysTypes' and appcode = 'RegDepo'
update dm.tCommand set cmd = '
select code, name 
  from tRegDepoSysTypes 
  where upper(modes) like ''%'' + @mode + ''%''
union 
  select code = '''', name = '''' 
order by name
' where code = 'RegSysTypes' and appcode = 'RegDepo'

--------------------------------------------------------------------------------
-- sql: RegTypes

delete dm.tCommand where code = 'RegTypes' and appcode = 'RegDepo'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('RegTypes', 'RegDepo', 0, '', '', 'комбо типы документов')
update dm.tCommand set cmdTestHead = '
declare @mode varchar(10) = ''IN''
' where code = 'RegTypes' and appcode = 'RegDepo'
update dm.tCommand set cmd = '
select code, name 
  from tRegDepoTypes 
  where upper(modes) like ''%'' + @mode + ''%''
  union 
  select code = '''', name = '''' 
order by name
' where code = 'RegTypes' and appcode = 'RegDepo'
