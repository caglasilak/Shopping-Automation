CREATE TABLE Personel(
		PersonelID int PRIMARY KEY IDENTITY (1,1),
		KullaniciAdi varchar(15),
		Sifre varchar(15)
)


INSERT INTO Personel
VALUES ('memo','1234')