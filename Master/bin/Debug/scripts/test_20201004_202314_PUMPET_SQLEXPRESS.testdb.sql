-- 04.10.2020 20:23:14 PUMPET\SQLEXPRESS.testdb 
-- Script for 'test'

--------------------------------------------------------------------------------
-- form: FDocEdit

delete dm.tCommand where code = 'FDocEdit' and appcode = 'test'
insert dm.tCommand (code, appcode, cmdType, cmd, comment) values ('FDocEdit', 'test', 1, 'TestForms.dll;TestForms.FDocEdit', '')

--------------------------------------------------------------------------------
-- form: Simple

delete dm.tCommand where code = 'Simple' and appcode = 'test'
insert dm.tCommand (code, appcode, cmdType, cmd, comment) values ('Simple', 'test', 1, 'TestForms.dll;TestForms.FSimple', '')

--------------------------------------------------------------------------------
-- sql: DocEdit

delete dm.tCommand where code = 'DocEdit' and appcode = 'test'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('DocEdit', 'test', 0, '', '', '')
update dm.tCommand set cmdTestHead = '
-- Объявления параметров - только для тестирования команды
' where code = 'DocEdit' and appcode = 'test'
update dm.tCommand set cmd = '

declare @t table  (
   id        int null
 , typeCode  varchar(30) null
 , stateCode varchar(30) null
 , number    varchar(50) null
 , docDate   date null
 , stateDate datetime null
 , endDate   date null
 , amount1   decimal(28,10) null
 , amount2   numeric(18,2) null
 , amountInt int null
 , tax       money null
 , prc       float null                                                
 , mark      bit null 
 , content   varchar(1000) null
 , note      varchar(1000) null
 )

 insert @t
     select     
       id        = null
     , typeCode  = null 
     , stateCode = null 
     , number    = convert(varchar(30), null)
     , docDate   = null
     , stateDate = null
     , endDate   = null
     , amount1   = null
     , amount2   = null
     , amountInt = null
     , tax       = null
     , prc       = null
     , mark      = 1
     , content   = null
     , note      = null
                    where @id is null --= -1
                union
     select     
       id        = d.id
     , typeCode  = d.typeCode   
     , stateCode = d.stateCode  
     , number    = d.number   
     , docDate   = d.docDate  
     , stateDate = d.stateDate
     , endDate   = d.endDate  
     , amount1   = d.amount1  
     , amount2   = d.amount2  
     , amountInt = d.amountInt
     , tax       = d.tax      
     , prc       = d.prc      
     , mark      = d.mark     
     , content   = d.content  
     , note      = d.note     
     from tDoc d
     where d.id = @id
                    
select * from @t
  

' where code = 'DocEdit' and appcode = 'test'

--------------------------------------------------------------------------------
-- sql: DocFields

delete dm.tCommand where code = 'DocFields' and appcode = 'test'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('DocFields', 'test', 0, '', '', '')
update dm.tCommand set cmdTestHead = '

declare 
  @id int = 12
, @paramName varchar(100) = null
, @ccb varchar(100) = null    

' where code = 'DocFields' and appcode = 'test'
update dm.tCommand set cmd = '

  
    --set nocount on
    --waitfor delay ''00:00:12.300''
    select @id as id, * from (
      select rtrim(v.name) as name, v.value
          from tDoc d
            join tDocType t on d.typeCode = t.code
            join tDocState s on d.stateCode = s.code
            cross apply (values 
            (''id       '', convert(varchar, d.id)         )
          , (''typeCode '', d.typeCode   )
          , (''stateCode'', d.stateCode  )
          , (''number   '', d.number     )
          , (''docDate  '', convert(varchar, d.docDate,104)    )
          , (''stateDate'', convert(varchar, d.stateDate,104)  )
          , (''endDate  '', convert(varchar, d.endDate, 104)    )
          , (''amount1  '', convert(varchar, d.amount1)    )
          , (''amount2  '', convert(varchar, d.amount2)    )
          , (''tax      '', convert(varchar, d.tax    )    )
          , (''prc      '', convert(varchar, d.prc    )    )
          , (''mark     '', convert(varchar, d.mark   )    )
          , (''content  '', d.content    )
          , (''note     '', d.note       )
          , (''typeName '', t.name       )
          , (''stateName'', s.name       ) 
              ) v(name, value)
         where d.id = @id) t
      where (t.name like ltrim(rtrim(@paramName)) or isnull(ltrim(@paramName),'''') = '''')
        and (isnull(ltrim(@ccb),'''') = '''' 
          or exists(select 1 from dm.fStrToTable(@ccb + '', '', '', '', 1) where val = t.name))
  

' where code = 'DocFields' and appcode = 'test'

--------------------------------------------------------------------------------
-- sql: insertDoc

delete dm.tCommand where code = 'insertDoc' and appcode = 'test'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('insertDoc', 'test', 0, '', '', '')
update dm.tCommand set cmdTestHead = '



' where code = 'insertDoc' and appcode = 'test'
update dm.tCommand set cmd = '


  insert tDoc (
    typeCode  
  , stateCode 
  , number    
  , docDate   
  , stateDate 
  , endDate   
  , amount1   
  , amount2   
  , amountInt 
  , tax       
  , prc       
  , mark      
  , content   
  , note
  )
  values (
    ''DOC'' --@typeCode  
  , ''CRT'' --@stateCode 
  , @number    
  , @docDate   
  , @stateDate 
  , @endDate   
  , @amount1   
  , @amount2   
  , @amountInt 
  , @tax       
  , @prc       
  , @mark      
  , '''' --@content   
  , @note
  )

  if @@rowcount > 0 
    select id = convert(int,SCOPE_IDENTITY())


' where code = 'insertDoc' and appcode = 'test'

--------------------------------------------------------------------------------
-- sql: test2

delete dm.tCommand where code = 'test2' and appcode = 'test'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('test2', 'test', 0, '', '', '')
update dm.tCommand set cmdTestHead = '
-- Объявления параметров - только для тестирования команды
' where code = 'test2' and appcode = 'test'
update dm.tCommand set cmd = '
select * from tDoc
' where code = 'test2' and appcode = 'test'

--------------------------------------------------------------------------------
-- sql: test3

delete dm.tCommand where code = 'test3' and appcode = 'test'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('test3', 'test', 0, '', '', '')
update dm.tCommand set cmdTestHead = '

declare @typeCode varchar(100) = ''DOC''
' where code = 'test3' and appcode = 'test'
update dm.tCommand set cmd = '
    select t.name as typeName, d.id, d.typeCode, d.Number, d.docDate
    from tDoc d
      join tDocType t on d.typeCode = t.code
   where d.typeCode = @typeCode --(d.typeCode = @typeCode or isnull(@typeCode,'''') = '''')
' where code = 'test3' and appcode = 'test'

--------------------------------------------------------------------------------
-- sql: testsql

delete dm.tCommand where code = 'testsql' and appcode = 'test'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('testsql', 'test', 0, '', '', '')
update dm.tCommand set cmdTestHead = '
declare @tst int = 1
' where code = 'testsql' and appcode = 'test'
update dm.tCommand set cmd = '
--waitfor delay ''00:00:20.000''
select * from bigdata --order by valuef
' where code = 'testsql' and appcode = 'test'

--------------------------------------------------------------------------------
-- sql: uno_check

delete dm.tCommand where code = 'uno_check' and appcode = 'test'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('uno_check', 'test', 0, '', '', '')
update dm.tCommand set cmdTestHead = '
-- Объявления параметров - только для тестирования команды
' where code = 'uno_check' and appcode = 'test'
update dm.tCommand set cmd = '
if isnull(@someText,'''') = ''''
  select ''someText'',''Не задано!''
' where code = 'uno_check' and appcode = 'test'

--------------------------------------------------------------------------------
-- sql: uno_edit

delete dm.tCommand where code = 'uno_edit' and appcode = 'test'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('uno_edit', 'test', 0, '', '', '')
update dm.tCommand set cmdTestHead = '
-- Объявления параметров - только для тестирования команды
' where code = 'uno_edit' and appcode = 'test'
update dm.tCommand set cmd = '
update tTestStatic set 
  setDate = @setDate
, someText = @someText
, someNumber = @someNumber
, docTypeCode = @docTypeCode
  where id = @id
  
    if @@rowcount > 0   
    select id = cast(@id as int)
' where code = 'uno_edit' and appcode = 'test'

--------------------------------------------------------------------------------
-- sql: unoedit

delete dm.tCommand where code = 'unoedit' and appcode = 'test'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('unoedit', 'test', 0, '', '', '')
update dm.tCommand set cmdTestHead = '
-- Объявления параметров - только для тестирования команды
' where code = 'unoedit' and appcode = 'test'
update dm.tCommand set cmd = '
select top 1 
  s.* 
, dt.name as docTypeName
from tTestStatic s
  left join tDocType dt on dt.code = s.docTypeCode


' where code = 'unoedit' and appcode = 'test'

--------------------------------------------------------------------------------
-- sql: updateDoc

delete dm.tCommand where code = 'updateDoc' and appcode = 'test'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('updateDoc', 'test', 0, '', '', '')
update dm.tCommand set cmdTestHead = '
-- Объявления параметров - только для тестирования команды
' where code = 'updateDoc' and appcode = 'test'
update dm.tCommand set cmd = '


  update tDoc set
    typeCode   = @typeCode  
  , stateCode  = @stateCode 
  , number     = @number    
  , docDate    = @docDate   
  , stateDate  = @stateDate 
  , endDate    = @endDate   
  , amount1    = @amount1   
  , amount2    = @amount2   
  , amountInt  = @amountInt 
  , tax        = @tax       
  , prc        = @prc       
  , mark       = @mark      
  , content    = @content   
  , note       = @note
   where id = @id
  
  if @@rowcount > 0   
    select id = cast(@id as int)


' where code = 'updateDoc' and appcode = 'test'
