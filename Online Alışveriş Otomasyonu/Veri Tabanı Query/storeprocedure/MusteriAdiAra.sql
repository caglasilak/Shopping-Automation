CREATE PROCEDURE MusteriAdiAra

	@musteriAdi varchar
AS
BEGIN

SELECT * FROM Musteriler
WHERE MusteriAdi=@musteriAdi

END