CREATE PROCEDURE MusteriEkle
	@adi varchar (20),
	@soyadi varchar(20),
	@kullaniciadi varchar(20),
	@sifre varchar(20),
	@adres varchar(20),
	@eposta varchar(20),
	@telefon varchar(20)
AS
BEGIN

INSERT INTO Musteriler(MusteriAdi,MusteriSoyadi,KullaniciAdi,Sifre,Adres,Eposta,Telno)
VALUES
	(@adi,@soyadi,@kullaniciadi,@sifre,@adres,@eposta,@telefon)

END