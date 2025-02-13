CREATE PROCEDURE [freeuser].[sp_get_taches]
	@UtilisateurId INT
AS
BEGIN
	SELECT Id, Titre, DateCreation, [Status], [UtilisateurId]
	FROM Tache
	WHERE [UtilisateurId] = @UtilisateurId;
END
