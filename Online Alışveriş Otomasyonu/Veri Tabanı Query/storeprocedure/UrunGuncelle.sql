CREATE PROCEDURE UrunGuncelleme
	@urunID int,
	@urunAdi varchar(20),
	@urunAciklamasi varchar(20),
	@fiyat int,
	@kategori int,
	@renk int
AS
BEGIN

UPDATE Urunler
SET 
	UrunAdi=@urunAdi,
	UrunAciklamasi=@urunAciklamasi,
	Fiyat=@fiyat,
	KategoriID=@kategori,
	RenkID=@renk
	
	WHERE
	UrunID=@urunID;


END