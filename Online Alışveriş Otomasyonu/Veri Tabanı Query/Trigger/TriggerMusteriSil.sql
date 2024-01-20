CREATE TRIGGER MusteriSilmek
on dbo.Musteriler
AFTER DELETE
AS
BEGIN

	SET NOCOUNT ON;
	INSERT INTO SilinenMusteri (MusteriID,SilinmeTarihi)
	SELECT MusteriID , GETDATE()
	FROM deleted

END;

SELECT * FROM sys.triggers;

