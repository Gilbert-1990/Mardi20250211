CREATE PROCEDURE [freeuser].[sp_get_tache_by_id]
	@Id INT,
	@UtilisateurId INT
AS
BEGIN
	SELECT Id, Titre, DateCreation, [Status], [UtilisateurId]
	FROM Tache
	WHERE [UtilisateurId] = @UtilisateurId AND Id = @Id;
END