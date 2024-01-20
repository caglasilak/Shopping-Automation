CREATE TABLE Musteriler (
		MusteriID int PRIMARY KEY IDENTITY (1,1),
		MusteriAdi varchar(25),
		MusteriSoyadi varchar(25),
		KullaniciAdi varchar(10),
		Sifre varchar(7),
		Adres varchar(50),
		Eposta varchar(20),
		Telno varchar(11)
)