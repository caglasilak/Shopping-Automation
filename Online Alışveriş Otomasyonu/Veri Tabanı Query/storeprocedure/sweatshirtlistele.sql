CREATE PROCEDURE sweatshirtListele
AS
BEGIN

SELECT UrunAdi,UrunAciklamasi,Fiyat,Stok,KategoriID,RenkID
FROM Urunler 
WHERE KategoriID = 1

END