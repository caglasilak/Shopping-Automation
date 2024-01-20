CREATE TABLE Odeme (
		OdemeID int PRIMARY KEY IDENTITY (1,1),
		SiparisID int,
		OdemeTarihi date,
		OdemeTutari decimal,
		OdemeTuruID int,
		FOREIGN KEY (SiparisID) REFERENCES Siparisler (SiparisID) ON DELETE CASCADE, 
		FOREIGN KEY (OdemeTuruID) REFERENCES OdemeTurleri (OdemeTuruID) ON DELETE CASCADE
)

