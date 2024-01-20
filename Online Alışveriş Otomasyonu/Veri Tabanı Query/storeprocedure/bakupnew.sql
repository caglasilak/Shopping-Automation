USE [OnlineAlisveriVT3]
GO
/****** Object:  StoredProcedure [dbo].[usp_BackupDatabase]    Script Date: 25.12.2023 12:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_BackupDatabase]
@BackupPath NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
 
    SET @BackupPath ='C:\Users\mehme\Desktop\yedek.bak'

    DECLARE @DatabaseName NVARCHAR(255)
    SET @DatabaseName = 'OnlineAlisveriVT3'

    DECLARE @BackupStatement NVARCHAR(MAX)
    SET @BackupStatement = 'BACKUP DATABASE [' + @DatabaseName + '] TO DISK =''' + @BackupPath + ''''

    -- Backup işlemini gerçekleştir
    EXEC sp_executesql @BackupStatement
END
