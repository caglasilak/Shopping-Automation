CREATE TRIGGER UrunSilmek
on dbo.Urunler
AFTER DELETE
AS

BEGIN
 set NOCOUNT ON;

  INSERT INTO SilinenUrunler(UrunID,SilinmeTarihi)
  SELECT UrunID,GETDATE()
  FROM deleted
 

 END;
