CREATE TABLE Kargo (
		KargoID int PRIMARY KEY IDENTITY (1,1),
		SiparisID int,
		KargoTarihi date,
		KargoDurumu varchar(13) CHECK (KargoDurumu IN('ALINDI','MERKEZDE', 'DAGITIMDA','TESL�M ED�LD�')),
		TeslimatAdresi varchar(90),
		FOREIGN KEY (SiparisID) REFERENCES Siparisler�(SiparisID) ON DELETE CASCADE,
)