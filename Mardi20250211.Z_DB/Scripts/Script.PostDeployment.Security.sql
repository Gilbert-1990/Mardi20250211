/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
IF NOT EXISTS (SELECT * FROM sys.syslogins WHERE [name] = N'FreeManagerLogin')
BEGIN
	CREATE LOGIN FreeManagerLogin WITH PASSWORD=N'4dmin1234='
END


IF NOT EXISTS (SELECT * FROM sys.sysusers WHERE [name] = N'FreeManagerUser')
BEGIN
	CREATE USER FreeManagerUser FOR LOGIN FreeManagerLogin;
	ALTER ROLE FreeUser ADD MEMBER FreeManagerUser;
END
