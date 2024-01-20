CREATE TRIGGER UpdateStok
ON Urunler
AFTER INSERT
AS
BEGIN
    DECLARE @UrunID INT, @Stok INT;
    SELECT @UrunID = i.UrunID, @Stok = i.Stok
    FROM inserted i;
    UPDATE Urunler
    SET Stok = Stok - @Stok
    WHERE UrunID = @UrunID;
END;