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
	account_role bit,
)
GO
create table Color(
	color_id int primary key identity(1,1) not null,
	color_name nvarchar(30)
)
GO
create table product(
	product_id int identity(1,1) primary key NOT NULL,
	image_id int NOT NULL,
	product_name nvarchar(50) NOT NULL,
	product_price float NOT NULL,
	color_id int foreign key references Color(color_id),
	product_quantity int NOT NULL,
	product_image nvarchar(50) NOT NULL,
	category_id int foreign key references Category(category_id),
	product_status nvarchar (30) NOT NULL,
	product_description nvarchar (2000) NULL,
	product_code nvarchar (10) NOT NULL,
	product_sale int NULL,
)
GO

create table size(
	id int identity(1,1) primary key NOT NULL ,
	names int NOT NULL,
)
GO

create table productsize(	
	product_id int foreign key references product(product_id),
	size_id int foreign key references size(id),
	quantity int NOT NULL,
)
GO

create table feetback(
	id int identity (1,1) NOT NULL primary key,
	content nvarchar (2000) NULL,
	ratting float NOT NULL,
	product_id int NOT NULL,
	account_id int NOT NULL,
)
GO
--Bảng slide chưa hoàn thành cái note và status
create table slide(
	id int identity(1,1) NOT NULL primary key,
	title nvarchar (50) NOT NULL,
	createdate Date NOT NULL,
	createby nvarchar (50) NOT NULL,
	modifydate Date NOT NULL,
	modifyby nvarchar(50) NOT NULL,
	imageslide nvarchar(50) NOT NULL,
	descriptions nvarchar(200) NULL,
)
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[status_product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[status] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

--thêm bảng status product
ALTER TABLE [dbo].[product]  WITH CHECK ADD FOREIGN KEY([status])
REFERENCES [dbo].[status_product] ([id])
GO

CREATE TABLE [dbo].[image_product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[image] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[product]  WITH CHECK ADD FOREIGN KEY([image_id])
REFERENCES [dbo].[image_product] ([id])
GO

create table [Order](
	id int primary key identity(1,1) not null,
	account_id int,
	note nvarchar(50),
	[status_id] int not null,
	total_money float not null,
	[Date] date,
)
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[status_order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[status] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
--
ALTER TABLE [dbo].[order]  WITH CHECK ADD FOREIGN KEY([status_id])
REFERENCES [dbo].[status_order] ([id])
GO

create table Order_Details (
	id int primary key identity(1,1) not null,
	order_id int references [Order](id),
	product_id int references product(product_id),
	price float,
	num int,
	total_number float
)
GO

create table category_blog(
	id int identity(1,1) primary key NOT NULL,
	category_name nvarchar(50) NOT NULL,
)
GO

create table blog(
	id int primary key NOT NULL,
	title nvarchar (200) NOT NULL,
	author nvarchar (100) NOT NULL,
	descriptions nvarchar (500) NOT NULL,
	createdate Datetime NOT NULL,
	createby nvarchar (100) NOT NULL,
	images nvarchar (100) NOT NULL,
	modifydate Datetime NOT NULL,
	modifyby nvarchar (100) NOT NULL,
	detail nvarchar (2000) NOT NULL,
	category_id int foreign key references category_blog(id),
)
GO