CREATE TABLE [dbo].[Tache]
(
	[Id] INT NOT NULL IDENTITY, 
    [Titre] NVARCHAR(255) NOT NULL, 
    [DateCreation] DATETIME2 NOT NULL  CONSTRAINT DF_Tache_DateCreation DEFAULT (SYSDATETIME()),
    [Status] NVARCHAR(20) NOT NULL CONSTRAINT DF_Tache_Status DEFAULT (N'En Cours'),
    [UtilisateurId] INT NOT NULL,
    CONSTRAINT [PK_Tache] PRIMARY KEY ([Id]),
    CONSTRAINT [CK_Tache_Status] CHECK ([Status] IN (N'En Cours', 'Cloturée')),
    CONSTRAINT [FK_Tache_Utilisateur] FOREIGN KEY ([UtilisateurId]) REFERENCES [Utilisateur]([Id])
)
