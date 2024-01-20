CREATE PROCEDURE RenkliUrun
	@renk varchar(15)
AS
BEGIN

SELECT * FROM Urunler
WHERE RenkId IN(SELECT RenkID 
FROM UrunRenkleri 
WHERE RenkAdi=@renk)

END