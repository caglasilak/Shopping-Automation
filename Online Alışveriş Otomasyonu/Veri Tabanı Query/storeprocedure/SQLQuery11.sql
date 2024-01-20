ALTER TRIGGER [dbo].[UpdateStok]
ON [dbo].[Urunler]
AFTER INSERT
AS
BEGIN
    UPDATE Urunler
    SET Stok = Urunler.Stok - i.Stok
    FROM Urunler
    INNER JOIN inserted i ON Urunler.UrunID = i.UrunID;
END;
