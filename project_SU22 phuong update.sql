USE [Project_SU22]
GO
ALTER TABLE [dbo].[Role_function] DROP CONSTRAINT [FK__Role_func__role___2B3F6F97]
GO
ALTER TABLE [dbo].[Role_function] DROP CONSTRAINT [FK__Role_func__funct__2A4B4B5E]
GO
ALTER TABLE [dbo].[productsize] DROP CONSTRAINT [FK__productsi__size___38996AB5]
GO
ALTER TABLE [dbo].[productsize] DROP CONSTRAINT [FK__productsi__produ__37A5467C]
GO
ALTER TABLE [dbo].[product] DROP CONSTRAINT [FK__product__status___412EB0B6]
GO
ALTER TABLE [dbo].[product] DROP CONSTRAINT [FK__product__color_i__32E0915F]
GO
ALTER TABLE [dbo].[product] DROP CONSTRAINT [FK__product__categor__33D4B598]
GO
ALTER TABLE [dbo].[Order_Details] DROP CONSTRAINT [FK__Order_Det__produ__4D94879B]
GO
ALTER TABLE [dbo].[Order_Details] DROP CONSTRAINT [FK__Order_Det__Order__4CA06362]
GO
ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK__Order__shipping___46E78A0C]
GO
ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK__Order__Order_sta__49C3F6B7]
GO
ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK__Order__account_i__440B1D61]
GO
ALTER TABLE [dbo].[feedback] DROP CONSTRAINT [FK__feedback__produc__3B75D760]
GO
ALTER TABLE [dbo].[feedback] DROP CONSTRAINT [FK__feedback__accoun__3C69FB99]
GO
ALTER TABLE [dbo].[Account] DROP CONSTRAINT [FK__Account__account__2E1BDC42]
GO
/****** Object:  Table [dbo].[status_product]    Script Date: 6/13/2022 4:08:35 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[status_product]') AND type in (N'U'))
DROP TABLE [dbo].[status_product]
GO
/****** Object:  Table [dbo].[slide]    Script Date: 6/13/2022 4:08:35 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[slide]') AND type in (N'U'))
DROP TABLE [dbo].[slide]
GO
/****** Object:  Table [dbo].[size]    Script Date: 6/13/2022 4:08:35 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[size]') AND type in (N'U'))
DROP TABLE [dbo].[size]
GO
/****** Object:  Table [dbo].[shipping]    Script Date: 6/13/2022 4:08:35 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[shipping]') AND type in (N'U'))
DROP TABLE [dbo].[shipping]
GO
/****** Object:  Table [dbo].[Role_function]    Script Date: 6/13/2022 4:08:35 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Role_function]') AND type in (N'U'))
DROP TABLE [dbo].[Role_function]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 6/13/2022 4:08:35 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Role]') AND type in (N'U'))
DROP TABLE [dbo].[Role]
GO
/****** Object:  Table [dbo].[productsize]    Script Date: 6/13/2022 4:08:35 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[productsize]') AND type in (N'U'))
DROP TABLE [dbo].[productsize]
GO
/****** Object:  Table [dbo].[product]    Script Date: 6/13/2022 4:08:35 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[product]') AND type in (N'U'))
DROP TABLE [dbo].[product]
GO
/****** Object:  Table [dbo].[Order_status]    Script Date: 6/13/2022 4:08:35 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order_status]') AND type in (N'U'))
DROP TABLE [dbo].[Order_status]
GO
/****** Object:  Table [dbo].[Order_Details]    Script Date: 6/13/2022 4:08:35 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order_Details]') AND type in (N'U'))
DROP TABLE [dbo].[Order_Details]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 6/13/2022 4:08:35 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order]') AND type in (N'U'))
DROP TABLE [dbo].[Order]
GO
/****** Object:  Table [dbo].[Function]    Script Date: 6/13/2022 4:08:35 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Function]') AND type in (N'U'))
DROP TABLE [dbo].[Function]
GO
/****** Object:  Table [dbo].[feedback]    Script Date: 6/13/2022 4:08:35 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[feedback]') AND type in (N'U'))
DROP TABLE [dbo].[feedback]
GO
/****** Object:  Table [dbo].[Color]    Script Date: 6/13/2022 4:08:35 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Color]') AND type in (N'U'))
DROP TABLE [dbo].[Color]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/13/2022 4:08:35 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category]') AND type in (N'U'))
DROP TABLE [dbo].[Category]
GO
/****** Object:  Table [dbo].[blog]    Script Date: 6/13/2022 4:08:35 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[blog]') AND type in (N'U'))
DROP TABLE [dbo].[blog]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 6/13/2022 4:08:35 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Account]') AND type in (N'U'))
DROP TABLE [dbo].[Account]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 6/13/2022 4:08:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[account_id] [int] IDENTITY(1,1) NOT NULL,
	[account_username] [nvarchar](50) NOT NULL,
	[account_password] [nvarchar](30) NOT NULL,
	[account_email] [nvarchar](50) NOT NULL,
	[account_name] [nvarchar](30) NOT NULL,
	[account_phone] [nvarchar](10) NOT NULL,
	[account_address] [nvarchar](100) NOT NULL,
	[account_role_id] [int] NOT NULL,
	[account_gender] [bit] NULL,
	[account_DOB] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[blog]    Script Date: 6/13/2022 4:08:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[blog](
	[blog_id] [int] NOT NULL,
	[blog_title] [nvarchar](200) NOT NULL,
	[blog_author] [nvarchar](100) NOT NULL,
	[blog_descriptions] [nvarchar](500) NOT NULL,
	[blog_createdate] [datetime] NOT NULL,
	[blog_createby] [nvarchar](100) NOT NULL,
	[blog_images] [nvarchar](100) NOT NULL,
	[blog_modifydate] [datetime] NOT NULL,
	[blog_modifyby] [nvarchar](100) NOT NULL,
	[blog_detail] [nvarchar](2000) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[blog_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/13/2022 4:08:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[category_id] [int] IDENTITY(1,1) NOT NULL,
	[category_name] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Color]    Script Date: 6/13/2022 4:08:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Color](
	[color_id] [int] IDENTITY(1,1) NOT NULL,
	[color_name] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[color_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[feedback]    Script Date: 6/13/2022 4:08:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[feedback](
	[feetback_id] [int] IDENTITY(1,1) NOT NULL,
	[feetback_content] [nvarchar](2000) NULL,
	[feetback_ratting] [float] NOT NULL,
	[product_id] [int] NULL,
	[account_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[feetback_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Function]    Script Date: 6/13/2022 4:08:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Function](
	[function_id] [int] NOT NULL,
	[function_name] [varchar](100) NOT NULL,
	[function_description] [nvarchar](200) NOT NULL,
	[function_ordernumber] [int] NOT NULL,
	[function_createday] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[function_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 6/13/2022 4:08:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Order_id] [int] IDENTITY(1,1) NOT NULL,
	[account_id] [int] NULL,
	[Order_note] [nvarchar](50) NULL,
	[Order_status_id] [int] NOT NULL,
	[Order_total_money] [float] NOT NULL,
	[Order_Date] [date] NULL,
	[shipping_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Details]    Script Date: 6/13/2022 4:08:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Details](
	[Order_Details_id] [int] IDENTITY(1,1) NOT NULL,
	[Order_id] [int] NULL,
	[product_id] [int] NULL,
	[Order_Details_price] [float] NULL,
	[Order_Details_num] [int] NULL,
	[Order_Details_total_number] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Order_Details_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_status]    Script Date: 6/13/2022 4:08:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_status](
	[Order_status_id] [int] IDENTITY(1,1) NOT NULL,
	[Order_status_status] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Order_status_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product]    Script Date: 6/13/2022 4:08:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product](
	[product_id] [int] IDENTITY(1,1) NOT NULL,
	[image_product] [nvarchar](500) NOT NULL,
	[product_name] [nvarchar](50) NOT NULL,
	[product_price] [float] NOT NULL,
	[color_id] [int] NULL,
	[product_quantity] [int] NOT NULL,
	[category_id] [int] NULL,
	[status_product_id] [int] NOT NULL,
	[product_description] [nvarchar](2000) NULL,
	[product_code] [nvarchar](10) NOT NULL,
	[product_sale] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[productsize]    Script Date: 6/13/2022 4:08:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productsize](
	[product_id] [int] NULL,
	[size_id] [int] NULL,
	[product_quantity] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 6/13/2022 4:08:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Role_id] [int] IDENTITY(1,1) NOT NULL,
	[Role_name] [nvarchar](100) NOT NULL,
	[Role_description] [nvarchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role_function]    Script Date: 6/13/2022 4:08:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role_function](
	[Role_function_id] [int] NOT NULL,
	[function_id] [int] NULL,
	[role_id] [int] NULL,
	[Role_function_view] [int] NOT NULL,
	[Role_function_insert] [int] NOT NULL,
	[Role_function_update] [int] NOT NULL,
	[Role_function_delete] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Role_function_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shipping]    Script Date: 6/13/2022 4:08:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shipping](
	[shipping_id] [int] IDENTITY(1,1) NOT NULL,
	[shipping_name] [nvarchar](50) NOT NULL,
	[shipping_email] [nvarchar](100) NOT NULL,
	[shipping_phone] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[shipping_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[size]    Script Date: 6/13/2022 4:08:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[size](
	[size_id] [int] IDENTITY(1,1) NOT NULL,
	[size_names] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[size_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[slide]    Script Date: 6/13/2022 4:08:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[slide](
	[slide_id] [int] IDENTITY(1,1) NOT NULL,
	[slide_title] [nvarchar](50) NOT NULL,
	[slide_createdate] [date] NOT NULL,
	[slide_createby] [nvarchar](50) NOT NULL,
	[slide_modifydate] [date] NOT NULL,
	[slide_modifyby] [nvarchar](50) NOT NULL,
	[slide_images] [nvarchar](50) NOT NULL,
	[slide_descriptions] [nvarchar](200) NULL,
	[slide_status_id] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[slide_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[status_product]    Script Date: 6/13/2022 4:08:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[status_product](
	[status_product_id] [int] IDENTITY(1,1) NOT NULL,
	[status_product_status] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[status_product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([account_id], [account_username], [account_password], [account_email], [account_name], [account_phone], [account_address], [account_role_id], [account_gender], [account_DOB]) VALUES (1, N'sswadling0', N'63349', N'dtiddy0@amazon.de', N'Larus fuliginosus', N'9599822277', N'031 Sachs Street', 1, 0, CAST(N'1988-04-27' AS Date))
INSERT [dbo].[Account] ([account_id], [account_username], [account_password], [account_email], [account_name], [account_phone], [account_address], [account_role_id], [account_gender], [account_DOB]) VALUES (2, N'tinett1', N'62028', N'santonacci1@ning.com', N'Eudyptula minor', N'2192325258', N'45 Mesta Hill', 2, 1, CAST(N'2000-11-15' AS Date))
INSERT [dbo].[Account] ([account_id], [account_username], [account_password], [account_email], [account_name], [account_phone], [account_address], [account_role_id], [account_gender], [account_DOB]) VALUES (3, N'imckeighan2', N'15441', N'blay2@blogtalkradio.com', N'Spheniscus mendiculus', N'5042730747', N'3 Pierstorff Park', 3, 0, CAST(N'2006-11-13' AS Date))
INSERT [dbo].[Account] ([account_id], [account_username], [account_password], [account_email], [account_name], [account_phone], [account_address], [account_role_id], [account_gender], [account_DOB]) VALUES (4, N'ctranckle3', N'81795', N'jkasbye3@baidu.com', N'Bassariscus astutus', N'9808350652', N'4 Schiller Court', 4, 0, CAST(N'1996-04-25' AS Date))
INSERT [dbo].[Account] ([account_id], [account_username], [account_password], [account_email], [account_name], [account_phone], [account_address], [account_role_id], [account_gender], [account_DOB]) VALUES (5, N'cmccumesky4', N'39710', N'jkennham4@elegantthemes.com', N'Tragelaphus angasi', N'4744188327', N'1 Park Meadow Alley', 1, 1, CAST(N'1989-08-10' AS Date))
INSERT [dbo].[Account] ([account_id], [account_username], [account_password], [account_email], [account_name], [account_phone], [account_address], [account_role_id], [account_gender], [account_DOB]) VALUES (6, N'rkahler5', N'78679', N'psoanes5@wikipedia.org', N'Eudyptula minor', N'1336992200', N'47302 Crest Line Center', 2, 0, CAST(N'2000-03-26' AS Date))
INSERT [dbo].[Account] ([account_id], [account_username], [account_password], [account_email], [account_name], [account_phone], [account_address], [account_role_id], [account_gender], [account_DOB]) VALUES (7, N'nhollyard6', N'20105', N'dkier6@sun.com', N'Eremophila alpestris', N'8749127450', N'4 Pierstorff Park', 2, 1, CAST(N'1999-03-24' AS Date))
INSERT [dbo].[Account] ([account_id], [account_username], [account_password], [account_email], [account_name], [account_phone], [account_address], [account_role_id], [account_gender], [account_DOB]) VALUES (8, N'sitscovitz7', N'29407', N'nmarcu7@cafepress.com', N'Alouatta seniculus', N'4904341449', N'26799 Westridge Terrace', 3, 0, CAST(N'1996-06-30' AS Date))
INSERT [dbo].[Account] ([account_id], [account_username], [account_password], [account_email], [account_name], [account_phone], [account_address], [account_role_id], [account_gender], [account_DOB]) VALUES (9, N'jroubay8', N'52484', N'gdow8@webeden.co.uk', N'Anthropoides paradisea', N'6116392571', N'533 Mesta Circle', 4, 1, CAST(N'1994-06-03' AS Date))
INSERT [dbo].[Account] ([account_id], [account_username], [account_password], [account_email], [account_name], [account_phone], [account_address], [account_role_id], [account_gender], [account_DOB]) VALUES (10, N'vpatnelli9', N'35122', N'dpridden9@google.fr', N'Tragelaphus angasi', N'6929540111', N'63 Hauk Point', 4, 1, CAST(N'1997-06-14' AS Date))
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (1, N'Nike')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (2, N'Adidas')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (3, N'Reebook')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (4, N'MLB')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (5, N'Gucci')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (6, N'Vans')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (7, N'Converse')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Color] ON 

INSERT [dbo].[Color] ([color_id], [color_name]) VALUES (1, N'Red')
INSERT [dbo].[Color] ([color_id], [color_name]) VALUES (2, N'Black')
INSERT [dbo].[Color] ([color_id], [color_name]) VALUES (3, N'Blue')
INSERT [dbo].[Color] ([color_id], [color_name]) VALUES (4, N'Brown')
INSERT [dbo].[Color] ([color_id], [color_name]) VALUES (5, N'Pink')
INSERT [dbo].[Color] ([color_id], [color_name]) VALUES (6, N'Purple')
INSERT [dbo].[Color] ([color_id], [color_name]) VALUES (7, N'Grey')
SET IDENTITY_INSERT [dbo].[Color] OFF
GO
SET IDENTITY_INSERT [dbo].[feedback] ON 

INSERT [dbo].[feedback] ([feetback_id], [feetback_content], [feetback_ratting], [product_id], [account_id]) VALUES (1, N'suspendisse potenti nullam porttitor lacus at turpis donec', 1.04, 2, 2)
INSERT [dbo].[feedback] ([feetback_id], [feetback_content], [feetback_ratting], [product_id], [account_id]) VALUES (2, N'quam sollicitudin vitae consectetuer eget rutrum at lorem integer', 2.66, 7, 1)
INSERT [dbo].[feedback] ([feetback_id], [feetback_content], [feetback_ratting], [product_id], [account_id]) VALUES (3, N'vestibulum sit amet cursus id turpis integer aliquet', 2.61, 5, 2)
INSERT [dbo].[feedback] ([feetback_id], [feetback_content], [feetback_ratting], [product_id], [account_id]) VALUES (4, N'mauris laoreet ut rhoncus aliquet pulvinar', 4.17, 6, 2)
INSERT [dbo].[feedback] ([feetback_id], [feetback_content], [feetback_ratting], [product_id], [account_id]) VALUES (5, N'penatibus et magnis dis parturient', 2.73, 1, 1)
INSERT [dbo].[feedback] ([feetback_id], [feetback_content], [feetback_ratting], [product_id], [account_id]) VALUES (6, N'erat id mauris vulputate elementum', 4.14, 4, 1)
INSERT [dbo].[feedback] ([feetback_id], [feetback_content], [feetback_ratting], [product_id], [account_id]) VALUES (7, N'turpis eget elit sodales scelerisque mauris sit amet eros suspendisse', 2.79, 3, 1)
INSERT [dbo].[feedback] ([feetback_id], [feetback_content], [feetback_ratting], [product_id], [account_id]) VALUES (8, N'ut ultrices vel augue vestibulum', 1.45, 3, 1)
INSERT [dbo].[feedback] ([feetback_id], [feetback_content], [feetback_ratting], [product_id], [account_id]) VALUES (9, N'sagittis nam congue risus semper porta volutpat', 4.25, 1, 1)
INSERT [dbo].[feedback] ([feetback_id], [feetback_content], [feetback_ratting], [product_id], [account_id]) VALUES (10, N'vel est donec odio justo sollicitudin', 4.39, 6, 2)
SET IDENTITY_INSERT [dbo].[feedback] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Order_id], [account_id], [Order_note], [Order_status_id], [Order_total_money], [Order_Date], [shipping_id]) VALUES (1, 8, N'oke', 4, 5722, NULL, 7)
INSERT [dbo].[Order] ([Order_id], [account_id], [Order_note], [Order_status_id], [Order_total_money], [Order_Date], [shipping_id]) VALUES (2, 2, N'sắp oke', 2, 8327, NULL, 3)
INSERT [dbo].[Order] ([Order_id], [account_id], [Order_note], [Order_status_id], [Order_total_money], [Order_Date], [shipping_id]) VALUES (3, 2, N'sit sdfsss ', 1, 4355, NULL, 9)
INSERT [dbo].[Order] ([Order_id], [account_id], [Order_note], [Order_status_id], [Order_total_money], [Order_Date], [shipping_id]) VALUES (4, 3, N'dolor quis odio ', 3, 8319, NULL, 7)
INSERT [dbo].[Order] ([Order_id], [account_id], [Order_note], [Order_status_id], [Order_total_money], [Order_Date], [shipping_id]) VALUES (5, 2, N'aliquam augue quam', 4, 7194, NULL, 2)
INSERT [dbo].[Order] ([Order_id], [account_id], [Order_note], [Order_status_id], [Order_total_money], [Order_Date], [shipping_id]) VALUES (6, 5, N'curabitur conval', 3, 691, NULL, 5)
INSERT [dbo].[Order] ([Order_id], [account_id], [Order_note], [Order_status_id], [Order_total_money], [Order_Date], [shipping_id]) VALUES (7, 9, N'pede malesuada modo', 4, 4843, NULL, 9)
INSERT [dbo].[Order] ([Order_id], [account_id], [Order_note], [Order_status_id], [Order_total_money], [Order_Date], [shipping_id]) VALUES (8, 10, N'enim in temp scelerisque quam', 2, 3606, NULL, 7)
INSERT [dbo].[Order] ([Order_id], [account_id], [Order_note], [Order_status_id], [Order_total_money], [Order_Date], [shipping_id]) VALUES (9, 8, N'placerat ante nam', 1, 7160, NULL, 3)
INSERT [dbo].[Order] ([Order_id], [account_id], [Order_note], [Order_status_id], [Order_total_money], [Order_Date], [shipping_id]) VALUES (10, 7, N'aliquam quis turpisrisque', 3, 6466, NULL, 10)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[Order_Details] ON 

INSERT [dbo].[Order_Details] ([Order_Details_id], [Order_id], [product_id], [Order_Details_price], [Order_Details_num], [Order_Details_total_number]) VALUES (1, 6, 3, 6, 10, 7)
INSERT [dbo].[Order_Details] ([Order_Details_id], [Order_id], [product_id], [Order_Details_price], [Order_Details_num], [Order_Details_total_number]) VALUES (2, 5, 1, 8, 3, 8)
INSERT [dbo].[Order_Details] ([Order_Details_id], [Order_id], [product_id], [Order_Details_price], [Order_Details_num], [Order_Details_total_number]) VALUES (3, 7, 2, 10, 5, 6)
INSERT [dbo].[Order_Details] ([Order_Details_id], [Order_id], [product_id], [Order_Details_price], [Order_Details_num], [Order_Details_total_number]) VALUES (4, 3, 4, 2, 8, 5)
INSERT [dbo].[Order_Details] ([Order_Details_id], [Order_id], [product_id], [Order_Details_price], [Order_Details_num], [Order_Details_total_number]) VALUES (5, 6, 2, 9, 5, 10)
INSERT [dbo].[Order_Details] ([Order_Details_id], [Order_id], [product_id], [Order_Details_price], [Order_Details_num], [Order_Details_total_number]) VALUES (6, 2, 1, 6, 7, 4)
INSERT [dbo].[Order_Details] ([Order_Details_id], [Order_id], [product_id], [Order_Details_price], [Order_Details_num], [Order_Details_total_number]) VALUES (7, 4, 3, 1, 9, 10)
INSERT [dbo].[Order_Details] ([Order_Details_id], [Order_id], [product_id], [Order_Details_price], [Order_Details_num], [Order_Details_total_number]) VALUES (8, 1, 1, 9, 3, 9)
INSERT [dbo].[Order_Details] ([Order_Details_id], [Order_id], [product_id], [Order_Details_price], [Order_Details_num], [Order_Details_total_number]) VALUES (9, 5, 1, 4, 10, 8)
INSERT [dbo].[Order_Details] ([Order_Details_id], [Order_id], [product_id], [Order_Details_price], [Order_Details_num], [Order_Details_total_number]) VALUES (10, 5, 2, 7, 6, 8)
SET IDENTITY_INSERT [dbo].[Order_Details] OFF
GO
SET IDENTITY_INSERT [dbo].[Order_status] ON 

INSERT [dbo].[Order_status] ([Order_status_id], [Order_status_status]) VALUES (1, N'Chờ lấy hàng')
INSERT [dbo].[Order_status] ([Order_status_id], [Order_status_status]) VALUES (2, N'Đã lấy hàng')
INSERT [dbo].[Order_status] ([Order_status_id], [Order_status_status]) VALUES (3, N'Đang đi đơn')
INSERT [dbo].[Order_status] ([Order_status_id], [Order_status_status]) VALUES (4, N'Đã giao')
SET IDENTITY_INSERT [dbo].[Order_status] OFF
GO
SET IDENTITY_INSERT [dbo].[product] ON 

INSERT [dbo].[product] ([product_id], [image_product], [product_name], [product_price], [color_id], [product_quantity], [category_id], [status_product_id], [product_description], [product_code], [product_sale]) VALUES (1, N'Adidas EQT Bask ADV (Kids)(Blue)(Adidas).jpg', N'San', 5063.94, 3, 27, 1, 3, N'vulputate ut ultrices vel augue vestibulum', N'CNY', 2)
INSERT [dbo].[product] ([product_id], [image_product], [product_name], [product_price], [color_id], [product_quantity], [category_id], [status_product_id], [product_description], [product_code], [product_sale]) VALUES (2, N'Adidas Stan Smith All Black (Men)(Black)(Adidas).jpg', N'Nike', 3922.37, 3, 42, 6, 3, N'nulla nisl nunc nisl duis bibendum felis sed interdum venenatis', N'SEK', 7)
INSERT [dbo].[product] ([product_id], [image_product], [product_name], [product_price], [color_id], [product_quantity], [category_id], [status_product_id], [product_description], [product_code], [product_sale]) VALUES (3, N'Adidas Superstar (Women)(Red)(Adidas).jpg', N'Nike', 1924.4, 1, 267, 7, 4, N'nulla nunc purus phasellus in felis donec semper', N'CAD', 7)
INSERT [dbo].[product] ([product_id], [image_product], [product_name], [product_price], [color_id], [product_quantity], [category_id], [status_product_id], [product_description], [product_code], [product_sale]) VALUES (4, N'Adidas EQT Bask ADV (Kids)(Blue)(Adidas).jpg', N'Fineleaf', 9045.79, 7, 185, 1, 3, N'tincidunt in leo maecenas pulvinar lobortis est phasellus sit', N'SEK', 1)
INSERT [dbo].[product] ([product_id], [image_product], [product_name], [product_price], [color_id], [product_quantity], [category_id], [status_product_id], [product_description], [product_code], [product_sale]) VALUES (5, N'Adidas EQT Bask ADV (Kids)(Blue)(Adidas).jpg', N'Golden', 2967.06, 3, 116, 2, 4, N'id justo sit amet sapien dignissim', N'EUR', 6)
INSERT [dbo].[product] ([product_id], [image_product], [product_name], [product_price], [color_id], [product_quantity], [category_id], [status_product_id], [product_description], [product_code], [product_sale]) VALUES (6, N'Adidas EQT Bask ADV (Kids)(Blue)(Adidas).jpg', N'Alaskan', 9157.5, 6, 297, 2, 2, N'vestibulum ac est lacinia nisi venenatis tristique fusce congue diam', N'RUB', 10)
INSERT [dbo].[product] ([product_id], [image_product], [product_name], [product_price], [color_id], [product_quantity], [category_id], [status_product_id], [product_description], [product_code], [product_sale]) VALUES (7, N'Adidas EQT Bask ADV (Kids)(Blue)(Adidas).jpg', N'Nike', 8503.03, 5, 631, 5, 1, N'parturient montes nascetur ridiculus mus vivamus vestibulum sagittis sapien', N'CNY', 7)
SET IDENTITY_INSERT [dbo].[product] OFF
GO
INSERT [dbo].[productsize] ([product_id], [size_id], [product_quantity]) VALUES (NULL, 2, 143)
INSERT [dbo].[productsize] ([product_id], [size_id], [product_quantity]) VALUES (NULL, 3, 195)
INSERT [dbo].[productsize] ([product_id], [size_id], [product_quantity]) VALUES (NULL, 9, 170)
INSERT [dbo].[productsize] ([product_id], [size_id], [product_quantity]) VALUES (NULL, 7, 181)
INSERT [dbo].[productsize] ([product_id], [size_id], [product_quantity]) VALUES (NULL, 3, 2)
INSERT [dbo].[productsize] ([product_id], [size_id], [product_quantity]) VALUES (NULL, 10, 67)
INSERT [dbo].[productsize] ([product_id], [size_id], [product_quantity]) VALUES (NULL, 2, 188)
INSERT [dbo].[productsize] ([product_id], [size_id], [product_quantity]) VALUES (NULL, 4, 77)
INSERT [dbo].[productsize] ([product_id], [size_id], [product_quantity]) VALUES (NULL, 7, 160)
INSERT [dbo].[productsize] ([product_id], [size_id], [product_quantity]) VALUES (NULL, 10, 117)
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Role_id], [Role_name], [Role_description]) VALUES (1, N'Admin', N'Cân tất')
INSERT [dbo].[Role] ([Role_id], [Role_name], [Role_description]) VALUES (2, N'Marketing', N'Cân vừa')
INSERT [dbo].[Role] ([Role_id], [Role_name], [Role_description]) VALUES (3, N'Customer', N'Đại gia')
INSERT [dbo].[Role] ([Role_id], [Role_name], [Role_description]) VALUES (4, N'Sale', N'Ông hoàng order')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[shipping] ON 

INSERT [dbo].[shipping] ([shipping_id], [shipping_name], [shipping_email], [shipping_phone]) VALUES (1, N'Jaxnation', N'kstraker0@comcast.net', N'9054056655')
INSERT [dbo].[shipping] ([shipping_id], [shipping_name], [shipping_email], [shipping_phone]) VALUES (2, N'Mynte', N'mharpham1@webs.com', N'3752075938')
INSERT [dbo].[shipping] ([shipping_id], [shipping_name], [shipping_email], [shipping_phone]) VALUES (3, N'Twitterworks', N'lcocci2@hhs.gov', N'6248005668')
INSERT [dbo].[shipping] ([shipping_id], [shipping_name], [shipping_email], [shipping_phone]) VALUES (4, N'Latz', N'bscotchford3@spiegel.de', N'3541911923')
INSERT [dbo].[shipping] ([shipping_id], [shipping_name], [shipping_email], [shipping_phone]) VALUES (5, N'Skiba', N'glafaye4@booking.com', N'1656485694')
INSERT [dbo].[shipping] ([shipping_id], [shipping_name], [shipping_email], [shipping_phone]) VALUES (6, N'Innotype', N'gweins5@java.com', N'7358612208')
INSERT [dbo].[shipping] ([shipping_id], [shipping_name], [shipping_email], [shipping_phone]) VALUES (7, N'Zazio', N'sdunlea6@woothemes.com', N'8454936794')
INSERT [dbo].[shipping] ([shipping_id], [shipping_name], [shipping_email], [shipping_phone]) VALUES (8, N'Meemm', N'coldam7@youtube.com', N'4538716086')
INSERT [dbo].[shipping] ([shipping_id], [shipping_name], [shipping_email], [shipping_phone]) VALUES (9, N'Skibox', N'wmagenny8@timesonline.co.uk', N'4001474364')
INSERT [dbo].[shipping] ([shipping_id], [shipping_name], [shipping_email], [shipping_phone]) VALUES (10, N'Nlounge', N'ecage9@odnoklassniki.ru', N'1991594644')
SET IDENTITY_INSERT [dbo].[shipping] OFF
GO
SET IDENTITY_INSERT [dbo].[size] ON 

INSERT [dbo].[size] ([size_id], [size_names]) VALUES (1, 48)
INSERT [dbo].[size] ([size_id], [size_names]) VALUES (2, 51)
INSERT [dbo].[size] ([size_id], [size_names]) VALUES (3, 37)
INSERT [dbo].[size] ([size_id], [size_names]) VALUES (4, 45)
INSERT [dbo].[size] ([size_id], [size_names]) VALUES (5, 54)
INSERT [dbo].[size] ([size_id], [size_names]) VALUES (6, 50)
INSERT [dbo].[size] ([size_id], [size_names]) VALUES (7, 50)
INSERT [dbo].[size] ([size_id], [size_names]) VALUES (8, 48)
INSERT [dbo].[size] ([size_id], [size_names]) VALUES (9, 51)
INSERT [dbo].[size] ([size_id], [size_names]) VALUES (10, 46)
SET IDENTITY_INSERT [dbo].[size] OFF
GO
SET IDENTITY_INSERT [dbo].[status_product] ON 

INSERT [dbo].[status_product] ([status_product_id], [status_product_status]) VALUES (1, N'Còn hàng')
INSERT [dbo].[status_product] ([status_product_id], [status_product_status]) VALUES (2, N'Đang khuyến mãi')
INSERT [dbo].[status_product] ([status_product_id], [status_product_status]) VALUES (3, N'Bán chạy')
INSERT [dbo].[status_product] ([status_product_id], [status_product_status]) VALUES (4, N'Hết hàng')
INSERT [dbo].[status_product] ([status_product_id], [status_product_status]) VALUES (5, N'Ngừng kinh doanh')
SET IDENTITY_INSERT [dbo].[status_product] OFF
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD FOREIGN KEY([account_role_id])
REFERENCES [dbo].[Role] ([Role_id])
GO
ALTER TABLE [dbo].[feedback]  WITH CHECK ADD FOREIGN KEY([account_id])
REFERENCES [dbo].[Account] ([account_id])
GO
ALTER TABLE [dbo].[feedback]  WITH CHECK ADD FOREIGN KEY([product_id])
REFERENCES [dbo].[product] ([product_id])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([account_id])
REFERENCES [dbo].[Account] ([account_id])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([Order_status_id])
REFERENCES [dbo].[Order_status] ([Order_status_id])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([shipping_id])
REFERENCES [dbo].[shipping] ([shipping_id])
GO
ALTER TABLE [dbo].[Order_Details]  WITH CHECK ADD FOREIGN KEY([Order_id])
REFERENCES [dbo].[Order] ([Order_id])
GO
ALTER TABLE [dbo].[Order_Details]  WITH CHECK ADD FOREIGN KEY([product_id])
REFERENCES [dbo].[product] ([product_id])
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD FOREIGN KEY([category_id])
REFERENCES [dbo].[Category] ([category_id])
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD FOREIGN KEY([color_id])
REFERENCES [dbo].[Color] ([color_id])
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD FOREIGN KEY([status_product_id])
REFERENCES [dbo].[status_product] ([status_product_id])
GO
ALTER TABLE [dbo].[productsize]  WITH CHECK ADD FOREIGN KEY([product_id])
REFERENCES [dbo].[product] ([product_id])
GO
ALTER TABLE [dbo].[productsize]  WITH CHECK ADD FOREIGN KEY([size_id])
REFERENCES [dbo].[size] ([size_id])
GO
ALTER TABLE [dbo].[Role_function]  WITH CHECK ADD FOREIGN KEY([function_id])
REFERENCES [dbo].[Function] ([function_id])
GO
ALTER TABLE [dbo].[Role_function]  WITH CHECK ADD FOREIGN KEY([role_id])
REFERENCES [dbo].[Role] ([Role_id])
GO
