USE [master]
IF EXISTS(select * from sys.databases where name='ItRental')
DROP DATABASE ItRental
GO
/****** Object:  Database [ItRental]    Script Date: 07-05-2019 14:53:22 ******/
CREATE DATABASE [ItRental]
GO
USE [ItRental]
GO
/****** Object:  Table [dbo].[Equipments]    Script Date: 07-05-2019 14:53:22 ******/
CREATE TABLE [dbo].[Equipments](
	[EquipmentId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [nvarchar](max) NOT NULL,
	[Category] [nvarchar](max) NOT NULL,
	[Units] [int] NOT NULL)
GO
SET IDENTITY_INSERT [dbo].[Equipments] ON 
GO
INSERT [dbo].[Equipments] ([EquipmentId], [Name], [Category], [Units]) VALUES (1, N'HDMI', N'Kabler', 4)
GO
INSERT [dbo].[Equipments] ([EquipmentId], [Name], [Category], [Units]) VALUES (2, N'Logitech M705', N'Mus', 3)
GO
INSERT [dbo].[Equipments] ([EquipmentId], [Name], [Category], [Units]) VALUES (3, N'HP Standard Tastatur', N'Tastatur', 2)
GO
INSERT [dbo].[Equipments] ([EquipmentId], [Name], [Category], [Units]) VALUES (4, N'Dell S2240L', N'Skærm', 9)
GO
INSERT [dbo].[Equipments] ([EquipmentId], [Name], [Category], [Units]) VALUES (5, N'Display Port', N'Kabler', 5)
GO
INSERT [dbo].[Equipments] ([EquipmentId], [Name], [Category], [Units]) VALUES (6, N'HDMI til DVI', N'Kabler', 3)
GO
SET IDENTITY_INSERT [dbo].[Equipments] OFF
GO

GO
CREATE TABLE Renters(
RenterId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
Name nvarchar(MAX) NOT NULL,
RenterLevel int NOT NULL
);
GO
CREATE TABLE Rentals(
RentalId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
RentalTime datetime2(0) NOT NULL,
ReturnTime datetime2(0) NOT NULL,
EquipmentId INT FOREIGN KEY REFERENCES Equipments(EquipmentId) NOT NULL ,
Units INT NOT NULL,
RenterId int FOREIGN KEY REFERENCES Renters(RenterId) NOT NULL
);