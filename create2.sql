USE xsxx
IF(OBJECT_ID('regist_recorder1') is not null)        -- 判断名为 regist_recorder 的触发器是否存在
DROP TRIGGER regist_recorder1        -- 删除触发器
GO
CREATE TRIGGER regist_recorder1
ON StudentUser  	         
AFTER
INSERT
AS 
	declare @UserName    nchar(20)
	declare @DateTime    datetime
	declare @UserOperation nchar(200)
	declare @dentity CHAR(20)

	select @UserName = ID FROM StudentUser
	select @DateTime = CONVERT(datetime,GETDATE(),120) 
	select @dentity ='StudentUser'

	declare @op varchar(10)
	select @op=case when exists(select 1 from inserted) and exists(select 1 from deleted)
                   then 'Update'
                   when exists(select 1 from inserted) and not exists(select 1 from deleted)
                   then 'Insert'
                   when not exists(select 1 from inserted) and exists(select 1 from deleted)
                   then 'Delete' end
                   
	
	select @UserOperation = @op
	

	INSERT INTO SysLog(UserID,dentity,DateAndTime,UserOperation)
	VALUES (@UserName,@dentity,@DateTime,@UserOperation)

--当管理员信息更新，触发器启动，将更新的内容存至注册日志
IF(OBJECT_ID('regist_recorder2') is not null)        -- 判断名为 regist_recorder 的触发器是否存在
DROP TRIGGER regist_recorder2        -- 删除触发器
GO
CREATE TRIGGER regist_recorder2
ON Administrator  	         
AFTER
INSERT
AS 
	declare @UserName    nchar(20)
	declare @DateTime    datetime
	declare @UserOperation nchar(200)
	declare @dentity CHAR(20)

	select @UserName = ID FROM Administrator
	select @DateTime = CONVERT(datetime,GETDATE(),120) 
	select @dentity ='Administrator'

	declare @op varchar(10)
	select @op=case when exists(select 1 from inserted) and exists(select 1 from deleted)
                   then 'Update'
                   when exists(select 1 from inserted) and not exists(select 1 from deleted)
                   then 'Insert'
                   when not exists(select 1 from inserted) and exists(select 1 from deleted)
                   then 'Delete' end
                   
	
	select @UserOperation = @op
	

	INSERT INTO SysLog(UserID,dentity,DateAndTime,UserOperation)
	VALUES (@UserName,@dentity,@DateTime,@UserOperation)



