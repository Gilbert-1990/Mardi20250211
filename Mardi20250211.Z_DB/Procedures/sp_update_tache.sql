CREATE PROCEDURE [freeuser].[sp_update_tache]
	@Id int,
	@Titre NVARCHAR(255),
	@Status NVARCHAR(20),
	@UtilisateurId INT
AS
BEGIN
	UPDATE [Tache] SET [Titre] = @Titre, [Status] = @Status WHERE [Id] = @Id AND [UtilisateurId] = @UtilisateurId;
END
