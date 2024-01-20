CREATE PROCEDURE UrunAdiAra

	@urunAdi varchar
AS
BEGIN

SELECT * FROM Urunler
WHERE UrunAdi=@urunAdi

END




