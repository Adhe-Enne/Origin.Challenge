
--CREATE
USE [Master]

DROP DATABASE IF EXISTS [ORIGIN.Challenge] 

CREATE DATABASE [ORIGIN.Challenge]


USE [ORIGIN.Challenge]


CREATE TABLE [dbo].[Account](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DNI] [varchar](9)UNIQUE NOT NULL,
	[FirstName] [varchar](30) NOT NULL,
	[LastName] [varchar](30) NOT NULL,
	[BirthDate] [datetime] NOT NULL,
	[IsEnabled] [bit] NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[DateAdded] [datetime] NOT NULL,
	[DateUpdated] [datetime]  NULL,

CONSTRAINT PK_Account PRIMARY KEY ([Id])
)




CREATE TABLE [dbo].[Card](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OwnerId] [int] NOT NULL,
	[CodeNumber]  [varchar](16) UNIQUE NOT NULL,
	[PIN] [varchar](4) NOT NULL,
	[Balance] [float] NOT NULL,
	[Status] int NOT NULL,
	[CardType] [int] NOT NULL,
	[DueDate] [datetime] NOT NULL,
	[IsEnabled] [bit] NOT NULL,
	[Description] [nchar](50) NULL,
	[DateAdded] [datetime] NOT NULL,
	[DateUpdated] [datetime] NULL,
	
CONSTRAINT PK_Card PRIMARY KEY ([Id]),
CONSTRAINT FK_Card_Account FOREIGN KEY (OwnerId) REFERENCES Account (Id)
)




CREATE TABLE [dbo].[Movement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CardId] [int] NOT NULL,
	[OperationDay] [datetime] NOT NULL,
	[OperationCode] [varchar](16) NOT NULL,
	[WithdrawAmount] [float] NOT NULL,
	RemainingBalance [float] NOT NULL,
	[Description] [varchar](30) NOT NULL,
	[IsEnabled] [bit] NOT NULL,
	
		
CONSTRAINT PK_Movement PRIMARY KEY ([Id]),
CONSTRAINT FK_Movement_Card FOREIGN KEY(CardId) REFERENCES Card (Id)

)	




--POPULATE
INSERT [dbo].[Account] ( [DNI], [FirstName], [LastName], [BirthDate], [IsEnabled], [Email], [DateAdded], [DateUpdated]) 
VALUES ( N'123456789', N'Dante', N'Gebel', CAST(N'2000-10-29T18:53:45.007' AS DateTime), 1, N'Dante@Gmail.com', GETDATE(), GETDATE() )
INSERT [dbo].[Account] ( [DNI], [FirstName], [LastName], [BirthDate], [IsEnabled], [Email], [DateAdded], [DateUpdated]) 
VALUES ( N'369852147', N'Daniel', N'Nina', CAST(N'1989-10-29T18:53:45.007' AS DateTime), 1, N'Daniel@Gmail.com', GETDATE(), GETDATE())
INSERT [dbo].[Account] ( [DNI], [FirstName], [LastName], [BirthDate], [IsEnabled], [Email], [DateAdded], [DateUpdated]) 
VALUES ( N'654987321', N'Hercules', N'Vigila', CAST(N'2001-10-29T20:08:55.933' AS DateTime), 1, N'Hercules@Gmail.com', GETDATE(), GETDATE())
INSERT [dbo].[Account] ( [DNI], [FirstName], [LastName], [BirthDate], [IsEnabled], [Email], [DateAdded], [DateUpdated]) 
VALUES ( N'147852478', N'Zeuz', N'Trueno', CAST(N'2003-10-29T20:08:55.933' AS DateTime), 1, N'Zeuz@Gmail.com', GETDATE(), GETDATE())
INSERT [dbo].[Account] ([DNI], [FirstName], [LastName], [BirthDate], [IsEnabled], [Email], [DateAdded], [DateUpdated]) 
VALUES ( N'350974135', N'Gandaf', N'Elgris', CAST(N'1996-10-29T18:53:45.007' AS DateTime), 1, N'Gandaf@Gmail.com', GETDATE(),GETDATE())


INSERT [dbo].[Card] ( [CodeNumber], [PIN], [OwnerId], [Balance], [DateAdded], [DateUpdated], [Status], [DueDate], [IsEnabled], [CardType], [Description]) VALUES ( N'1111111111111111', N'0000',1, 0, GETDATE(),GETDATE(), 0, CAST(N'2027-10-29T00:00:00.000' AS DateTime), 1, 4, N'TARJETA UALA')
INSERT [dbo].[Card] ( [CodeNumber],  [PIN], [OwnerId], [Balance], [DateAdded], [DateUpdated], [Status], [DueDate], [IsEnabled], [CardType], [Description]) VALUES ( N'8385375823433203', N'6453',2, 0, GETDATE(),GETDATE(), 0, CAST(N'2027-10-29T00:00:00.000' AS DateTime), 1, 3, N'TARJETA MERCADO PAGO')
INSERT [dbo].[Card] ( [CodeNumber], [PIN], [OwnerId], [Balance], [DateAdded], [DateUpdated], [Status], [DueDate], [IsEnabled], [CardType], [Description]) VALUES ( N'8385375823433202', N'0010',3, 0, GETDATE(),GETDATE(), 0, CAST(N'2027-10-29T00:00:00.000' AS DateTime), 1, 2, N'TARJETA BBVA')
INSERT [dbo].[Card] ( [CodeNumber],[PIN], [OwnerId], [Balance], [DateAdded], [DateUpdated],  [Status], [DueDate], [IsEnabled], [CardType], [Description]) VALUES ( N'1234567891234567', N'1234',4, 0,GETDATE(),GETDATE(), 0, CAST(N'2027-10-29T00:00:00.000' AS DateTime), 1, 4, N'TARJETA LEMON CASH')
INSERT [dbo].[Card] ( [CodeNumber], [PIN], [OwnerId], [Balance], [DateAdded], [DateUpdated], [Status], [DueDate], [IsEnabled], [CardType], [Description]) VALUES ( N'1597464896481852', N'2587',5, 0,GETDATE(),GETDATE(), 0, CAST(N'2027-10-29T00:00:00.000' AS DateTime), 1, 2, N'TARJETA MERCADO PAGO')
INSERT [dbo].[Card] ( [CodeNumber], [PIN], [OwnerId], [Balance], [DateAdded], [DateUpdated], [Status], [DueDate], [IsEnabled], [CardType], [Description]) VALUES ( N'6549878523164975', N'0000',1, 0, GETDATE(),GETDATE(), 0, CAST(N'2027-10-29T00:00:00.000' AS DateTime), 1, 4, N'TARJETA UALA')
INSERT [dbo].[Card] ( [CodeNumber],  [PIN], [OwnerId], [Balance], [DateAdded], [DateUpdated], [Status], [DueDate], [IsEnabled], [CardType], [Description]) VALUES ( N'2134565975724316', N'6453',2, 0, GETDATE(),GETDATE(), 0, CAST(N'2027-10-29T00:00:00.000' AS DateTime), 1, 3, N'TARJETA MERCADO PAGO')
INSERT [dbo].[Card] ( [CodeNumber], [PIN], [OwnerId], [Balance], [DateAdded], [DateUpdated], [Status], [DueDate], [IsEnabled], [CardType], [Description]) VALUES ( N'3121464546979752', N'0010',3, 0, GETDATE(),GETDATE(), 0, CAST(N'2027-10-29T00:00:00.000' AS DateTime), 1, 2, N'TARJETA BBVA')
INSERT [dbo].[Card] ( [CodeNumber],[PIN], [OwnerId], [Balance], [DateAdded], [DateUpdated],  [Status], [DueDate], [IsEnabled], [CardType], [Description]) VALUES ( N'6797878454221316', N'1234',4, 0,GETDATE(),GETDATE(), 0, CAST(N'2027-10-29T00:00:00.000' AS DateTime), 1, 4, N'TARJETA LEMON CASH')


--ALGUNOS MOVIMIENTOS
INSERT [dbo].[Movement] ( [CardId], [OperationDay], [WithdrawAmount], [OperationCode], [IsEnabled], [Description], [RemainingBalance]) VALUES ( 1, GETDATE(), 0, N'753769299366', 1, N'Tarjeta Disponible en BALANCE', 100000)
INSERT [dbo].[Movement] ( [CardId], [OperationDay], [WithdrawAmount], [OperationCode], [IsEnabled], [Description], [RemainingBalance]) VALUES ( 1, GETDATE(), 0, N'619783456726', 1, N'Extraccion exitosa', 100000)
INSERT [dbo].[Movement] ( [CardId], [OperationDay], [WithdrawAmount], [OperationCode], [IsEnabled], [Description], [RemainingBalance]) VALUES ( 1, GETDATE(), 15000, N'912424569909', 1, N'Extraccion exitosa', 85000)
INSERT [dbo].[Movement] ( [CardId], [OperationDay], [WithdrawAmount], [OperationCode], [IsEnabled], [Description], [RemainingBalance]) VALUES ( 1, GETDATE(), 0, N'681000410431', 1, N'Extraccion exitosa', 85000)
INSERT [dbo].[Movement] ( [CardId], [OperationDay], [WithdrawAmount], [OperationCode], [IsEnabled], [Description], [RemainingBalance]) VALUES ( 1, GETDATE(), 85000, N'752142368700', 1, N'Extraccion exitosa', 0)
INSERT [dbo].[Movement] ( [CardId], [OperationDay], [WithdrawAmount], [OperationCode], [IsEnabled], [Description], [RemainingBalance]) VALUES ( 1, GETDATE(), 0, N'752142368700', 1, N'FONDOS AGOTADOS', 0)
