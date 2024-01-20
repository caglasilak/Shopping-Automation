CREATE TABLE SilinenMusteri (
		SilinenMusteriID int PRIMARY KEY IDENTITY(1,1),
		MusteriID int,
		SilinmeTarihi date,
		SilenAdmin varchar(15),
		FOREIGN KEY (MusteriID) REFERENCES Musteriler (MusteriID) ON DELETE CASCADE
)
DROP TABLE SilinenMusteri