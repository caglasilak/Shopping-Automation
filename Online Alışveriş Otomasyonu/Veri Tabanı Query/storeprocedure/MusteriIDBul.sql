CREATE PROCEDURE MusteriIDBul

	@kullaniciAdi varchar
AS
BEGIN

SELECT MusteriID FROM Musteriler
WHERE KullaniciAdi=@kullaniciAdi

END