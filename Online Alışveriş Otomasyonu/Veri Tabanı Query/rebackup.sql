USE master
GO
ALTER DATABASE [OnlineAlisveriVT2] set SINGLE_USER WITH ROLLBACK IMMEDIATE
RESTORE DATABASE [OnlineAlisveriVT2] FROM DISK = 'C:\Users\mehme\Desktop\yedek.bak'
ALTER DATABASE [OnlineAlisveriVT2] set MULTI_USER

select * from Urunler