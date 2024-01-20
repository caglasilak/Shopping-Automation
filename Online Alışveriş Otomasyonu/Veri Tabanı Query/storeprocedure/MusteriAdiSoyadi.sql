CREATE PROCEDURE MusteriAdiSoyadiAdres

	@kullaniciAdi varchar
AS
BEGIN

SELECT MusteriAdi , MusteriSoyadi ,Adres FROM Musteriler
WHERE KullaniciAdi=@kullaniciAdi

END


select * from Adminler

