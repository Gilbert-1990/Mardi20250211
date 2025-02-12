CREATE PROCEDURE [FreeUser].[Register]
	@Nom NVARCHAR(50),
	@Prenom NVARCHAR(50),
	@Email NVARCHAR(384),
	@Passwd NVARCHAR(20)
AS
BEGIN
	BEGIN TRY
		INSERT INTO Utilisateur (Nom, Prenom, Email, Passwd)
		VALUES (@Nom, @Prenom, @Email, dbo.CreatePassword(@Passwd));
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
		DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
		DECLARE @ErrorState INT = ERROR_STATE();
		
		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
		RETURN
	END CATCH
END
