CREATE TABLE SilinenUrunler (
		SilinenUrunID int PRIMARY KEY IDENTITY(1,1),
		UrunID int,
		SilinmeTarihi date, 
		AdminID int,
		FOREIGN KEY (AdminID) REFERENCES Adminler(AdminID)  ON DELETE CASCADE
)