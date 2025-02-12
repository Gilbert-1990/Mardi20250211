CREATE PROCEDURE [FreeUser].[GetTacheById]
	@Id INT,
	@UtilisateurId INT
AS
BEGIN
	SELECT Id, Titre, DateCreation, [Status], [UtilisateurId]
	FROM Tache
	WHERE [UtilisateurId] = @UtilisateurId AND Id = @Id;
END