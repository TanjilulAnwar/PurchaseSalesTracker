USE [StockManagement]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 27-Oct-19 11:00:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](4) NULL,
	[Name] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 27-Oct-19 11:00:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](4) NULL,
	[Name] [varchar](30) NULL,
	[Address] [varchar](30) NULL,
	[Email] [varchar](30) NULL,
	[Contact] [varchar](12) NULL,
	[LoyaltyPoint] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 27-Oct-19 11:00:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[Code] [varchar](4) NULL,
	[Name] [varchar](30) NULL,
	[ReOrderLevel] [int] NULL,
	[Description] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purchase]    Script Date: 27-Oct-19 11:00:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[Code] [varchar](10) NULL,
	[InvoiceNo] [varchar](20) NULL,
	[SupplierID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchasedProducts]    Script Date: 27-Oct-19 11:00:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchasedProducts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseCode] [varchar](10) NULL,
	[ProductCode] [varchar](10) NULL,
	[MfgDate] [date] NULL,
	[ExpDate] [date] NULL,
	[Quantity] [int] NULL,
	[UnitPrice] [float] NULL,
	[TotalPrice] [float] NULL,
	[MRP] [float] NULL,
	[Remarks] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sales]    Script Date: 27-Oct-19 11:00:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerCode] [varchar](4) NULL,
	[Code] [varchar](10) NULL,
	[Date] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesProducts]    Script Date: 27-Oct-19 11:00:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesProducts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SalesCode] [varchar](10) NULL,
	[ProductName] [varchar](30) NULL,
	[ProductCode] [varchar](5) NULL,
	[CustomerName] [varchar](30) NULL,
	[SalesDate] [date] NULL,
	[Quantity] [int] NULL,
	[MRP] [float] NULL,
	[TotalMRP] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 27-Oct-19 11:00:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](4) NULL,
	[Name] [varchar](30) NULL,
	[Address] [varchar](30) NULL,
	[Email] [varchar](30) NULL,
	[Contact] [varchar](12) NULL,
	[ContactPerson] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([ID], [Code], [Name]) VALUES (11, N'1001', N'ELECTRONICS')
INSERT [dbo].[Categories] ([ID], [Code], [Name]) VALUES (12, N'1002', N'DECORATIONS')
INSERT [dbo].[Categories] ([ID], [Code], [Name]) VALUES (13, N'1003', N'COSMETICS')
INSERT [dbo].[Categories] ([ID], [Code], [Name]) VALUES (14, N'1004', N'MOBILE')
INSERT [dbo].[Categories] ([ID], [Code], [Name]) VALUES (15, N'1005', N'ORGANIC')
INSERT [dbo].[Categories] ([ID], [Code], [Name]) VALUES (16, N'1006', N'FURNITURE')
INSERT [dbo].[Categories] ([ID], [Code], [Name]) VALUES (17, N'1007', N'STATIONARY')
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([ID], [Code], [Name], [Address], [Email], [Contact], [LoyaltyPoint]) VALUES (5, N'3001', N'SHAFIQ', N'DHAKA', N's@mail.com', N'01547875896', 6000)
INSERT [dbo].[Customers] ([ID], [Code], [Name], [Address], [Email], [Contact], [LoyaltyPoint]) VALUES (6, N'3002', N'RAFIQ', N'KHULNA', N'r@mail.com', N'76436587345', 6000)
INSERT [dbo].[Customers] ([ID], [Code], [Name], [Address], [Email], [Contact], [LoyaltyPoint]) VALUES (7, N'3003', N'TAWFIQ', N'KHULNA', N't@mail.com', N'56858687587', 6000)
INSERT [dbo].[Customers] ([ID], [Code], [Name], [Address], [Email], [Contact], [LoyaltyPoint]) VALUES (8, N'3004', N'JAKER', N'VOLA', N'J@mail.com', N'54245464646', 6000)
INSERT [dbo].[Customers] ([ID], [Code], [Name], [Address], [Email], [Contact], [LoyaltyPoint]) VALUES (9, N'3005', N'SAKIB', N'FENI', N'sa@mail.com', N'76746464646', 6000)
SET IDENTITY_INSERT [dbo].[Customers] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ID], [CategoryID], [Code], [Name], [ReOrderLevel], [Description]) VALUES (9, 11, N'0101', N'ELECTRIC IRON', 25, N'good')
INSERT [dbo].[Products] ([ID], [CategoryID], [Code], [Name], [ReOrderLevel], [Description]) VALUES (10, 11, N'0102', N'REFRIGERATOR', 25, N'good')
INSERT [dbo].[Products] ([ID], [CategoryID], [Code], [Name], [ReOrderLevel], [Description]) VALUES (11, 11, N'0103', N'MICROWAVE OVEN', 25, N'good')
INSERT [dbo].[Products] ([ID], [CategoryID], [Code], [Name], [ReOrderLevel], [Description]) VALUES (12, 12, N'0201', N'FLOWER VASE', 25, N'god')
INSERT [dbo].[Products] ([ID], [CategoryID], [Code], [Name], [ReOrderLevel], [Description]) VALUES (13, 12, N'0202', N'PICTURE FRAME', 25, N'good')
INSERT [dbo].[Products] ([ID], [CategoryID], [Code], [Name], [ReOrderLevel], [Description]) VALUES (14, 13, N'0301', N'OLIVE OIL', 25, N'good')
INSERT [dbo].[Products] ([ID], [CategoryID], [Code], [Name], [ReOrderLevel], [Description]) VALUES (15, 13, N'0302', N'BODY SPRAY', 25, N'good')
INSERT [dbo].[Products] ([ID], [CategoryID], [Code], [Name], [ReOrderLevel], [Description]) VALUES (16, 13, N'0303', N'HAIR CREAM', 25, N'good')
INSERT [dbo].[Products] ([ID], [CategoryID], [Code], [Name], [ReOrderLevel], [Description]) VALUES (17, 14, N'0401', N'SAMSUNG S7', 25, N'good')
INSERT [dbo].[Products] ([ID], [CategoryID], [Code], [Name], [ReOrderLevel], [Description]) VALUES (18, 14, N'0402', N'HUWAEI P20', 25, N'good')
INSERT [dbo].[Products] ([ID], [CategoryID], [Code], [Name], [ReOrderLevel], [Description]) VALUES (19, 15, N'0501', N'CONDENSED MILK', 25, N'good')
INSERT [dbo].[Products] ([ID], [CategoryID], [Code], [Name], [ReOrderLevel], [Description]) VALUES (20, 15, N'0502', N'DRIED FRUITS', 25, N'good')
INSERT [dbo].[Products] ([ID], [CategoryID], [Code], [Name], [ReOrderLevel], [Description]) VALUES (21, 17, N'0601', N'TABLE', 25, N'good')
INSERT [dbo].[Products] ([ID], [CategoryID], [Code], [Name], [ReOrderLevel], [Description]) VALUES (22, 16, N'0602', N'CHAIR', 25, N'good')
INSERT [dbo].[Products] ([ID], [CategoryID], [Code], [Name], [ReOrderLevel], [Description]) VALUES (23, 17, N'0701', N'PEN', 25, N'good')
INSERT [dbo].[Products] ([ID], [CategoryID], [Code], [Name], [ReOrderLevel], [Description]) VALUES (24, 17, N'0702', N'ERASER', 25, N'good')
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[Suppliers] ON 

INSERT [dbo].[Suppliers] ([ID], [Code], [Name], [Address], [Email], [Contact], [ContactPerson]) VALUES (3, N'4001', N'SAHIL CO.', N'DHAKA', N'sahil@mail.com', N'123432423434', N'sahil')
INSERT [dbo].[Suppliers] ([ID], [Code], [Name], [Address], [Email], [Contact], [ContactPerson]) VALUES (4, N'4002', N'STAR CO.', N'DHAKA', N'star@mail.com', N'67657567677', N'helal')
INSERT [dbo].[Suppliers] ([ID], [Code], [Name], [Address], [Email], [Contact], [ContactPerson]) VALUES (5, N'4003', N'TREE CO.', N'DHAKA', N'tree@mail.com', N'87978897989', N'didar')
INSERT [dbo].[Suppliers] ([ID], [Code], [Name], [Address], [Email], [Contact], [ContactPerson]) VALUES (6, N'4004', N'MASTER CO.', N'DHAKA', N'master@mail.com', N'456575746646', N'sohel')
SET IDENTITY_INSERT [dbo].[Suppliers] OFF
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [fk_products_category_id] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [fk_products_category_id]
GO
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD  CONSTRAINT [fk_purchase_supplier_id] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Suppliers] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Purchase] CHECK CONSTRAINT [fk_purchase_supplier_id]
GO
