CREATE PROCEDURE [FreeUser].[ChangeTacheStatus]
	@Id int,
	@Status NVARCHAR(20),
	@UtilisateurId INT
AS
BEGIN
	UPDATE [Tache] SET [Status] = @Status WHERE [Id] = @Id AND [UtilisateurId] = @UtilisateurId;
END