IF DB_ID('CoffeeShop') IS NULL 
	CREATE DATABASE CoffeeShop
GO

USE CoffeeShop
GO

--======================================================
CREATE TABLE [dbo].[Users](
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL, 
	[Type] [int] NOT NULL,
	PRIMARY KEY (UserName)	
	)
GO

--======================================================
INSERT INTO [dbo].[Users] ([UserName], [Password], [Type]) VALUES 
	('admin', '123', 1),
	('user1', '111', 2),
	('user2', '222', 3),
	('user3', '333', 4),
	('user4', '444', 5)
GO

--======================================================
CREATE TABLE [dbo].[Supplier](
	[id] [varchar](20) NOT NULL,
	[name] [nvarchar](100) NOT NULL, 
	[address] [nvarchar](200)  NOT NULL,
	PRIMARY KEY (id)	
	)
GO

--======================================================
CREATE TABLE [dbo].[ProductCategory](
	[id] [int] IDENTITY(1,1),
	[name] [nvarchar](100) NOT NULL, 	
	PRIMARY KEY (id)	
	)
GO

--======================================================
CREATE TABLE [dbo].[Product](
	[id] [varchar](10) NOT NULL,
	[name] [nvarchar](100) NOT NULL, 
	[purchasePrice] [float]  NOT NULL DEFAULT 0, 
	[sellingPrice] [float]  NOT NULL DEFAULT 0, 
	[categoryId][int]NOT NULL,	
	[supplierId][varchar](20) NOT NULL,
	PRIMARY KEY (id)	
	)
GO

--======================================================
ALTER TABLE Product ADD CONSTRAINT FK_SUPPLIER_PRODUCT FOREIGN KEY (supplierId) REFERENCES Supplier(id)
ALTER TABLE Product ADD CONSTRAINT FK_PRODUCTCATEGORY_PRODUCT FOREIGN KEY (categoryId) REFERENCES ProductCategory(id)

--======================================================

INSERT INTO [dbo].[ProductCategory] ([name]) VALUES 
	(N'Nước ngọt'),
	(N'Trà sữa'),
	(N'Sinh tố'),
	(N'Bia')
GO

--======================================================
INSERT INTO [dbo].[Supplier] ([id], [name], [address]) VALUES 
	('Pepsico', N'Suntory Pepsico', N'Lầu 5, Cao Ốc Sheraton, 88 Đồng Khởi, Q. 1 '),
	('Sapporo', N'Sapporo Vietnam', N'Tầng 17, Tòa nhà Green Power, 35 Tôn Đức Thắng, Quận 1, Thành phố Hồ Chí Minh '),
	('NamViet', N'Công Ty TNHH Một Thành Viên Thực Phẩm Và Nước Giải', N'994/1C Nguyen Thi Minh Khai Street, Tan Thang Town, Tan Binh Ward, Di An District, Binh Duong '),
	('Sting', N'Sting Vietnam', N'Lầu 7, Cao Ốc Serena, 77 Mạc Đỉnh Chi, Q. 1 '),
	('Tiger', N'Tiger World', N'Tầng 10, Tòa nhà Blue Power, 25 Tôn Thất Tùng, Quận 1, Thành phố Hồ Chí Minh ')
GO

INSERT INTO [dbo].[Product] ([id], [name], [sellingPrice], [purchasePrice], [categoryId], [supplierId]) VALUES 
	('Pepsi', N'Pepsi', 10000, 20000, 1, 'Pepsico'),
	('TrasuaTC', N'Trà sữa trân châu', 12000, 17000, 2, 'NamViet'),
	('Sting', N'Nước tăng lực Sting', 8000, 15000, 1, 'Sting'),
	('Sapporo', N'Bia Sapporo', 15000 , 30000, 3, 'Sapporo'),
	('Capucino', N'Cà phê Capucino', 12000, 17000, 2, 'NamViet'),
	('Suprise', N'Suprise', 8000, 15000, 1, 'Pepsico'),
	('Tiger', N'Bia Tiger', 15000 , 30000, 3, 'Tiger')
GO

