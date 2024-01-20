CREATE TABLE Urunler (
		UrunID int PRIMARY KEY IDENTITY (1,1),
		UrunAdi varchar(25),
		UrunAciklamasi varchar(50),
		Fiyat money,
		Stok int,
		KategoriID int ,
		RenkID int,
		FOREIGN KEY (KategoriID) REFERENCES Kategori(KategoriID) ON DELETE CASCADE,
		FOREIGN KEY (RenkID) REFERENCES UrunRenkleri (RenkID) ON DELETE CASCADE
		
)