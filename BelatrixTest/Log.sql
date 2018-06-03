CREATE TABLE [dbo].[Logs]
(
    [LogId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Level] TINYINT NOT NULL DEFAULT (0), 
    [Message] NVARCHAR(4000) NULL, 
    [StackTrace] NVARCHAR(4000) NULL, 
    [MachineName] NVARCHAR(100) NOT NULL, 
    [UserName] NVARCHAR(100) NOT NULL, 
    [CreatedDate] DATETIME NOT NULL,
)


Create Procedure LogSave
    @level tinyint = 0
    ,@message nvarchar(4000) = ''
    ,@stackTrace nvarchar(4000) = ''
    ,@machineName NVARCHAR(100) = ''
    ,@userName NVARCHAR(100) = ''
    ,@createdDate datetime
as
begin
    insert into LogSave ([LogId],[Level], [Message] , [StackTrace] , [MachineName] , [UserName] , [CreatedDate])
    values(@level,@message ,@stackTrace,@machineName,@userName,@createdDate)
end