CREATE PROCEDURE UrunSil

	@urunKodu int
AS
BEGIN

DELETE  FROM Urunler
WHERE UrunID=@urunKodu 

END