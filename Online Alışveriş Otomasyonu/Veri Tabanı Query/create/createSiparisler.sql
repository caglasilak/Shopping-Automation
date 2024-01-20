CREATE TABLE Siparisler (
		SiparisID int PRIMARY KEY IDENTITY (1,1),
		Miktar int,
		ToplamFiyat decimal,
		MusteriID int,
		UrunID int,
		FOREIGN KEY (MusteriID) REFERENCES Musteriler(MusteriID) ON DELETE CASCADE,
		FOREIGN KEY (UrunID) REFERENCES Urunler (UrunID) ON DELETE CASCADE
		
)