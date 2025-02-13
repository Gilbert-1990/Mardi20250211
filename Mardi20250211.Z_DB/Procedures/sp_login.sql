CREATE PROCEDURE [freeuser].[sp_login]
	@Email NVARCHAR(384),
	@Password NVARCHAR(20)
AS
BEGIN
	SELECT Id, Nom, Prenom, Email
	FROM Utilisateur
	WHERE Email = @Email AND Passwd = dbo.CreatePassword(@Password);
END