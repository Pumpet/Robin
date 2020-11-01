-- 20.10.2020 22:06:18 LAPTOP-899RUUJG\SQLEXPRESS.testdb 
-- Script for 'Robin'

--------------------------------------------------------------------------------
-- method: TestMethod

delete dm.tCommand where code = 'TestMethod' and appcode = 'Robin'
insert dm.tCommand (code, appcode, cmdType, cmd, comment) values ('TestMethod', 'Robin', 2, 'Robin.exe;Robin.Program;TestMethod', '')

--------------------------------------------------------------------------------
-- form: DocList1

delete dm.tCommand where code = 'DocList1' and appcode = 'Robin'
insert dm.tCommand (code, appcode, cmdType, cmd, comment) values ('DocList1', 'Robin', 1, 'TestForms.dll;TestForms.FDocs', '')

--------------------------------------------------------------------------------
-- form: FDocEdit

delete dm.tCommand where code = 'FDocEdit' and appcode = 'Robin'
insert dm.tCommand (code, appcode, cmdType, cmd, comment) values ('FDocEdit', 'Robin', 1, 'TestForms.dll;TestForms.FDocEdit', '')

--------------------------------------------------------------------------------
-- form: FDocStates

delete dm.tCommand where code = 'FDocStates' and appcode = 'Robin'
insert dm.tCommand (code, appcode, cmdType, cmd, comment) values ('FDocStates', 'Robin', 1, 'TestForms.dll;TestForms.FDocStates', '')

--------------------------------------------------------------------------------
-- form: Simple

delete dm.tCommand where code = 'Simple' and appcode = 'Robin'
insert dm.tCommand (code, appcode, cmdType, cmd, comment) values ('Simple', 'Robin', 1, 'TestForms.dll;TestForms.FSimple', '')

--------------------------------------------------------------------------------
-- sql: DocEdit

delete dm.tCommand where code = 'DocEdit' and appcode = 'Robin'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('DocEdit', 'Robin', 0, '', '', '')
update dm.tCommand set cmdTestHead = '

-- Объявления параметров - только для тестирования команды

' where code = 'DocEdit' and appcode = 'Robin'
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
  


' where code = 'DocEdit' and appcode = 'Robin'

--------------------------------------------------------------------------------
-- sql: DocFields

delete dm.tCommand where code = 'DocFields' and appcode = 'Robin'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('DocFields', 'Robin', 0, '', '', '')
update dm.tCommand set cmdTestHead = '


declare 
  @id int = 12
, @paramName varchar(100) = null
, @ccb varchar(100) = null    


' where code = 'DocFields' and appcode = 'Robin'
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
  


' where code = 'DocFields' and appcode = 'Robin'

--------------------------------------------------------------------------------
-- sql: DocsAll

delete dm.tCommand where code = 'DocsAll' and appcode = 'Robin'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('DocsAll', 'Robin', 0, '', '', '')
update dm.tCommand set cmdTestHead = '

-- Объявления параметров - только для тестирования команды

' where code = 'DocsAll' and appcode = 'Robin'
update dm.tCommand set cmd = '


--waitfor delay ''00:00:01''
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
    , typeName  = t.name
    , stateName = s.name
    from tDoc d
      join tDocType t on d.typeCode = t.code
      join tDocState s on d.stateCode = s.code
   where (d.typeCode = @typeCode or @typeCode is null)
     and (d.Content like @text or @text = '''')
     and (d.amount2 = @num or @num is null)
     -- and (s.name = @state or @state = '''')
     and (s.code = @stateCode or @stateCode = '''')
     and (d.docDate >= @dateFrom or @dateFrom is null)
     and (d.docDate <= @dateTo or @dateTo is null)
     and (d.mark = @mark or @mark is null)
     and (d.number = @number or @number = '''')
     and (@yearall = 1 
        or (@year2019 = 1 and d.stateDate >= ''20190101'' and d.stateDate < ''20200101'')
        or (@year2020 = 1 and d.stateDate >= ''20200101'' and d.stateDate < ''20210101''))
     --and (d.Note = @text or (@text = '''' and d.Note is null)) 
     and (@dtpick is null or (@dtpick is not null and d.stateDate > @dtpick))
  


' where code = 'DocsAll' and appcode = 'Robin'

--------------------------------------------------------------------------------
-- sql: insertDoc

delete dm.tCommand where code = 'insertDoc' and appcode = 'Robin'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('insertDoc', 'Robin', 0, '', '', '')
update dm.tCommand set cmdTestHead = '





' where code = 'insertDoc' and appcode = 'Robin'
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



' where code = 'insertDoc' and appcode = 'Robin'

--------------------------------------------------------------------------------
-- sql: test

delete dm.tCommand where code = 'test' and appcode = 'Robin'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('test', 'Robin', 0, '', '', '')
update dm.tCommand set cmdTestHead = '

-- 

' where code = 'test' and appcode = 'Robin'
update dm.tCommand set cmd = '



      select @id as testId, rtrim(v.name) as testName, v.value as testValue
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
         where rtrim(v.name) = @test
  


' where code = 'test' and appcode = 'Robin'

--------------------------------------------------------------------------------
-- sql: updateDoc

delete dm.tCommand where code = 'updateDoc' and appcode = 'Robin'
insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('updateDoc', 'Robin', 0, '', '', '')
update dm.tCommand set cmdTestHead = '

-- Объявления параметров - только для тестирования команды

' where code = 'updateDoc' and appcode = 'Robin'
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



' where code = 'updateDoc' and appcode = 'Robin'

--------------------------------------------------------------------------------
-- меню

delete dm.tMenu where appcode = 'Robin'
insert dm.tMenu (code, appcode, parent, ord, caption, img, execType, command, marker) 
                select
                  code = 'ddDocs'
                , appcode = 'Robin'
                , parentId = null
                , ord = 1
                , caption = 'Документы'
                , img = 'down'
                , execType = 1
                , command = null
                , marker = null
                
insert dm.tMenu (code, appcode, parent, ord, caption, img, execType, command, marker) 
                select
                  code = 'ddDoc'
                , appcode = 'Robin'
                , parentId = null
                , ord = 1
                , caption = 'Тест'
                , img = ''
                , execType = 1
                , command = null
                , marker = null
                
insert dm.tMenu (code, appcode, parent, ord, caption, img, execType, command, marker) 
                select
                  code = 'miSimple'
                , appcode = 'Robin'
                , parentId = null
                , ord = 1
                , caption = 'Simple Form'
                , img = ''
                , execType = 0
                , command = ''
                , marker = null
                
insert dm.tMenu (code, appcode, parent, ord, caption, img, execType, command, marker) 
                select
                  code = 'ddTest1'
                , appcode = 'Robin'
                , parentId = 3
                , ord = 1
                , caption = 'Тест 1'
                , img = ''
                , execType = 1
                , command = null
                , marker = null
                
insert dm.tMenu (code, appcode, parent, ord, caption, img, execType, command, marker) 
                select
                  code = 'miTest11'
                , appcode = 'Robin'
                , parentId = 7
                , ord = 1
                , caption = 'Тест метод'
                , img = ''
                , execType = 0
                , command = 'TestMethod'
                , marker = null
                
insert dm.tMenu (code, appcode, parent, ord, caption, img, execType, command, marker) 
                select
                  code = 'miDocList1'
                , appcode = 'Robin'
                , parentId = 2
                , ord = 1
                , caption = 'Документы-1'
                , img = ''
                , execType = 0
                , command = 'DocList1'
                , marker = null
                
