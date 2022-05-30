CREATE DATABASE Project_SU22
GO
USE Project_SU22
GO

create table Category(
	category_id int identity(1,1) primary key NOT NULL,
	category_name nvarchar(30)
)
GO
Create table Account(
	account_id int identity(1,1) primary key NOT NULL,
	account_email nvarchar(50) NOT NULL,
	account_password nvarchar(30) NOT NULL,
	account_name nvarchar(30) NOT NULL,
	account_phone nvarchar(10) not null,
	account_address nvarchar(100) not null,
	account_role int,
)
GO
create table Color(
	color_id int primary key identity(1,1) not null,
	color_name nvarchar(30)
)
GO

create table product(
	product_id int identity(1,1) primary key NOT NULL,
	image_product_id int NOT NULL,
	product_name nvarchar(50) NOT NULL,
	product_price float NOT NULL,
	color_id int foreign key references Color(color_id),
	product_quantity int NOT NULL,
	product_image nvarchar(50) NOT NULL,
	category_id int foreign key references Category(category_id),
	status_product_id int NOT NULL,
	product_description nvarchar (2000) NULL,
	product_code nvarchar (10) NOT NULL,
	product_sale int NULL,
)
GO

create table size(
	size_id int identity(1,1) primary key NOT NULL ,
	size_names int NOT NULL,
)
GO

create table productsize(	
	product_id int foreign key references product(product_id),
	size_id int foreign key references size(size_id),
	product_quantity int NOT NULL,
)
GO

create table feedback(
	feetback_id int identity (1,1) NOT NULL primary key,
	feetback_content nvarchar (2000) NULL,
	feetback_ratting float NOT NULL,
	product_id int foreign key references product(product_id),
	account_id int NOT NULL,
)
GO
--Bảng slide chưa hoàn thành cái note và status
create table slide(
	slide_id int identity(1,1) NOT NULL primary key,
	slide_title nvarchar (50) NOT NULL,
	slide_createdate Date NOT NULL,
	slide_createby nvarchar (50) NOT NULL,
	slide_modifydate Date NOT NULL,
	slide_modifyby nvarchar(50) NOT NULL,
	slide_images nvarchar(50) NOT NULL,
	slide_descriptions nvarchar(200) NULL,
	slide_status_id int NOT NULL,
)
GO

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


ALTER TABLE [dbo].[product]  WITH CHECK ADD FOREIGN KEY([status_product_id])
REFERENCES [dbo].[status_product] ([status_product_id])
GO

CREATE TABLE [dbo].[image_product](
	[image_product_id] [int] IDENTITY(1,1) NOT NULL,
	[image_product_image] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[image_product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[product]  WITH CHECK ADD FOREIGN KEY([image_product_id])
REFERENCES [dbo].[image_product] ([image_product_id])
GO

create table [Order](
	Order_id int primary key identity(1,1) not null,
	account_id int references Account(account_id),
	Order_note nvarchar(50),
	[Order_status_id] int not null,
	Order_total_money float not null,
	[Order_Date] date,
	shipping_id int NOT NULL,
)
GO


create table shipping(
	shipping_id int identity(1,1) primary key NOT NULL,
	[shipping_name] nvarchar (50) NOT NULL,
	shipping_email nvarchar (100) NOT NULL,
	shipping_phone nvarchar (50) NOT NULL,
)

ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([shipping_id])
REFERENCES [dbo].[shipping] ([shipping_id])
GO


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
--
ALTER TABLE [dbo].[order]  WITH CHECK ADD FOREIGN KEY([Order_status_id])
REFERENCES [dbo].[Order_status] ([Order_status_id])
GO

create table Order_Details (
	Order_Details_id int primary key identity(1,1) not null,
	Order_id int references [Order](Order_id),
	product_id int references product(product_id),
	Order_Details_price float,
	Order_Details_num int,
	Order_Details_total_number float,
)
GO

create table blog(
	blog_id int primary key NOT NULL,
	blog_title nvarchar (200) NOT NULL,
	blog_author nvarchar (100) NOT NULL,
	blog_descriptions nvarchar (500) NOT NULL,
	blog_createdate Datetime NOT NULL,
	blog_createby nvarchar (100) NOT NULL,
	blog_images nvarchar (100) NOT NULL,
	blog_modifydate Datetime NOT NULL,
	blog_modifyby nvarchar (100) NOT NULL,
	blog_detail nvarchar (2000) NOT NULL,
)
GO