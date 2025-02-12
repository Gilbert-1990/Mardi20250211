CREATE PROCEDURE [FreeUser].[GetTaches]
	@UtilisateurId INT
AS
BEGIN
	SELECT Id, Titre, DateCreation, [Status], [UtilisateurId]
	FROM Tache
	WHERE [UtilisateurId] = @UtilisateurId;
END
