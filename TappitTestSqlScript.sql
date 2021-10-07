drop table IF EXISTS [TappitTechnicalTest].[FavouriteSports];
GO

drop table IF EXISTS [TappitTechnicalTest].[People];
GO

drop table IF EXISTS [TappitTechnicalTest].[Sports];
GO


DROP SCHEMA  IF EXISTS [TappitTechnicalTest] 
GO

CREATE SCHEMA [TappitTechnicalTest] 
GO



CREATE TABLE [TappitTechnicalTest].[FavouriteSports](
	[PersonId] [int] NOT NULL,
	[SportId] [int] NOT NULL,
 CONSTRAINT [PK_FavouriteSports] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC,
	[SportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [TappitTechnicalTest].[People](
	[PersonId] [int] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[IsAuthorised] [bit] NOT NULL,
	[IsValid] [bit] NOT NULL,
	[IsEnabled] [bit] NOT NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [TappitTechnicalTest].[Sports](
	[SportId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[IsEnabled] [bit] NOT NULL,
 CONSTRAINT [PK_Sports] PRIMARY KEY CLUSTERED 
(
	[SportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [TappitTechnicalTest].[FavouriteSports]  WITH CHECK ADD  CONSTRAINT [FK_FavouriteSports_People] FOREIGN KEY([PersonId])
REFERENCES [TappitTechnicalTest].[People] ([PersonId])
GO
ALTER TABLE [TappitTechnicalTest].[FavouriteSports] CHECK CONSTRAINT [FK_FavouriteSports_People]
GO
ALTER TABLE [TappitTechnicalTest].[FavouriteSports]  WITH CHECK ADD  CONSTRAINT [FK_FavouriteSports_Sports] FOREIGN KEY([SportId])
REFERENCES [TappitTechnicalTest].[Sports] ([SportId])
GO
ALTER TABLE [TappitTechnicalTest].[FavouriteSports] CHECK CONSTRAINT [FK_FavouriteSports_Sports]
GO



INSERT INTO TappitTechnicalTest.Sports (SportId, Name, IsEnabled) VALUES (1, N'American Football', 1);
INSERT INTO TappitTechnicalTest.Sports (SportId, Name, IsEnabled) VALUES (2, N'Baseball', 1); 
INSERT INTO TappitTechnicalTest.Sports (SportId, Name, IsEnabled) VALUES (3, N'Basketball', 1);


INSERT INTO TappitTechnicalTest.People (PersonId, FirstName, LastName, IsAuthorised, IsValid, IsEnabled) VALUES (1, N'Frank', N'Smith', 0, 1, 0);
INSERT INTO TappitTechnicalTest.People (PersonId, FirstName, LastName, IsAuthorised, IsValid, IsEnabled) VALUES (2, N'Bob', N'Mason', 0, 0, 0);
INSERT INTO TappitTechnicalTest.People (PersonId, FirstName, LastName, IsAuthorised, IsValid, IsEnabled) VALUES (3, N'David', N'Adams', 0, 1, 1);
INSERT INTO TappitTechnicalTest.People (PersonId, FirstName, LastName, IsAuthorised, IsValid, IsEnabled) VALUES (4, N'Eve', N'Jones', 0, 0, 0);
INSERT INTO TappitTechnicalTest.People (PersonId, FirstName, LastName, IsAuthorised, IsValid, IsEnabled) VALUES (5, N'Steven', N'Taylor', 0, 1, 1);
INSERT INTO TappitTechnicalTest.People (PersonId, FirstName, LastName, IsAuthorised, IsValid, IsEnabled) VALUES (6, N'Hannah', N'Butler', 0, 0, 0);
INSERT INTO TappitTechnicalTest.People (PersonId, FirstName, LastName, IsAuthorised, IsValid, IsEnabled) VALUES (7, N'John', N'Edwards', 0, 1, 0);
INSERT INTO TappitTechnicalTest.People (PersonId, FirstName, LastName, IsAuthorised, IsValid, IsEnabled) VALUES (8, N'Oliver', N'Woods', 0, 0, 0);
INSERT INTO TappitTechnicalTest.People (PersonId, FirstName, LastName, IsAuthorised, IsValid, IsEnabled) VALUES (9, N'Natan', N'Lee', 0, 1, 1);
INSERT INTO TappitTechnicalTest.People (PersonId, FirstName, LastName, IsAuthorised, IsValid, IsEnabled) VALUES (10, N'Thomas', N'Brown', 0, 1, 1);
INSERT INTO TappitTechnicalTest.People (PersonId, FirstName, LastName, IsAuthorised, IsValid, IsEnabled) VALUES (11, N'Otto', N'Campbell', 1, 1, 0);


INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (1, 1);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (1, 2);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (1, 3);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (2, 1);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (2, 2);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (3, 2);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (4, 1);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (4, 2);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (4, 3);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (5, 2);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (6, 1);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (7, 2);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (7, 3);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (8, 2);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (9, 1);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (10, 1);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (10, 2);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (10, 3);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (11, 1);


