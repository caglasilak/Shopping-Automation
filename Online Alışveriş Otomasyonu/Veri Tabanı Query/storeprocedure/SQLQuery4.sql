CREATE PROCEDURE MusteriSilme

	@musteriKullaniciID int
AS
BEGIN

DELETE  FROM Musteriler
WHERE MusteriID=@musteriKullaniciID

END