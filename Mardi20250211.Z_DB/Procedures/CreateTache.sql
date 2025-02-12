CREATE PROCEDURE [FreeUser].[CreateTache]
	@Titre NVARCHAR(255), 
    @UtilisateurId INT
AS
BEGIN
	INSERT INTO Tache (Titre, UtilisateurId) VALUES (@Titre, @UtilisateurId);
END