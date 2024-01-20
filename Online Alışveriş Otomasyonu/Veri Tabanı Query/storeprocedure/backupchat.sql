CREATE PROCEDURE dbo.usp_BackupDatabase
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @BackupPath NVARCHAR(255)
    SET @BackupPath = 'C:\Users\mehme\Desktop\yedek.bak'

    DECLARE @DatabaseName NVARCHAR(255)
    SET @DatabaseName = 'OnlineAlisveriVT2'

    DECLARE @BackupStatement NVARCHAR(MAX)
    SET @BackupStatement = 'BACKUP DATABASE [' + @DatabaseName + '] TO DISK =''' + @BackupPath + ''''

  
    EXEC sp_executesql @BackupStatement

 

END