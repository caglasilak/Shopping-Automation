CREATE PROCEDURE kargoListele
AS
BEGIN

SELECT SiparisID,KargoTarihi,KargoDurumu,TeslimatAdresi
FROM Kargo 
WHERE KargoID = 6

END


select * from Kargo