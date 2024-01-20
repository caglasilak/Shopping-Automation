CREATE PROCEDURE PersonelEkle
	@kullaniciAdi varchar (20),
	@sifre varchar(20)
AS
BEGIN

INSERT INTO Personel(KullaniciAdi,Sifre)
VALUES
	(@kullaniciAdi,@sifre)

END