CREATE PROCEDURE [freeuser].[sp_create_tache]
	@Titre NVARCHAR(255), 
    @UtilisateurId INT
AS
BEGIN
	INSERT INTO Tache (Titre, UtilisateurId) VALUES (@Titre, @UtilisateurId);
END