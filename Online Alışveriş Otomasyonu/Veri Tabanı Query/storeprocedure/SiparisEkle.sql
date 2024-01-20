CREATE PROCEDURE SiparisEkle
	@miktar int ,
	@urunFiyati int,
	@musteriID int,
	@urunID int
AS
BEGIN

INSERT INTO Siparisler(Miktar,ToplamFiyat,MusteriID,UrunID)
VALUES
	(@miktar, @urunFiyati*@miktar ,@musteriID,@urunID)
END