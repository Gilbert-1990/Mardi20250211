CREATE PROCEDURE [freeuser].[sp_change_tache_status]
	@Id int,
	@Status NVARCHAR(20),
	@UtilisateurId INT
AS
BEGIN
	UPDATE [Tache] SET [Status] = @Status WHERE [Id] = @Id AND [UtilisateurId] = @UtilisateurId;
END