CREATE DATABASE Project_SU22
GO
USE Project_SU22
GO

create table Category(
	category_id int identity(1,1) primary key NOT NULL,
	category_name nvarchar(30)
)
GO

create table [Role](
	Role_id int primary key identity(1,1) NOT NULL,
	Role_name nvarchar (100) NOT NULL,
)
GO

INSERT INTO [dbo].[Role] ([role_name]) VALUES ('Customer')
INSERT INTO [dbo].[Role] ([role_name]) VALUES ('Admin')
INSERT INTO [dbo].[Role] ([role_name]) VALUES ('Marketing')
INSERT INTO [dbo].[Role] ([role_name]) VALUES ('Sale')

create table [Function](
	function_id int primary key NOT NULL,
	function_name varchar (100) NOT NULL, 
	function_description nvarchar (200) NOT NULL,
	function_ordernumber int NOT NULL,
	function_createday Date NOT NULL,
)
GO

create table Role_function (
	Role_function_id int primary key NOT NULL,
	function_id int references [Function](function_id),
	role_id int references [Role] (Role_id),
	Role_function_view int NOT NULL,
	Role_function_insert int NOT NULL,
	Role_function_update int NOT NULL,
	Role_function_delete int NOT NULL,
)
GO


Create table Account(
	account_id int identity(1,1) primary key NOT NULL,
	account_username nvarchar (50) NOT NULL,
	account_password nvarchar(30) NOT NULL,
	account_email nvarchar(50) NOT NULL,
	account_name nvarchar(30) NOT NULL,
	account_phone nvarchar(10) not null,
	account_address nvarchar(100) not null,
	account_role_id int NOT NULL,
	account_gender bit , 
	account_status bit NOT NULL,
	account_createdate Date 
)
GO


ALTER TABLE Account  WITH CHECK ADD FOREIGN KEY(account_role_id)
REFERENCES [Role] (Role_id)
GO

create table Color(
	color_id int primary key identity(1,1) not null,
	color_name nvarchar(30)
)
GO

create table product(
	product_id int identity(1,1) primary key NOT NULL,
	product_name nvarchar(50) NOT NULL,
	product_price money NOT NULL,
	color_id int foreign key references Color(color_id),
	product_quantity int NOT NULL,
	product_image nvarchar(50) NOT NULL,
	category_id int foreign key references Category(category_id),
	status_product_id int NOT NULL,
	product_description nvarchar (2000) NULL,
	product_code nvarchar (10) NOT NULL,
	product_create_date datetime not null
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


ALTER TABLE [dbo].[product]  WITH CHECK ADD FOREIGN KEY([status_product_id])
REFERENCES [dbo].[status_product] ([status_product_id])
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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
	Order_Details_price money,
	Order_Details_num int,
	Order_Details_total_number float,
)
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create table Blog(
	blog_id int identity(1,1) NOT NULL,
	blog_title nvarchar (200) NOT NULL,
	blog_author nvarchar (100) NOT NULL,
	blog_descriptions nvarchar (500) NULL,
	blog_createdate Datetime NOT NULL,
	blog_createby nvarchar (100) NOT NULL,
	blog_images nvarchar (100) NOT NULL,
	blog_modifydate Datetime NULL,
	blog_modifyby nvarchar (100) NULL,
	blog_detail nvarchar (max) NOT NULL,
	blog_back_link nvarchar(1000) null
CONSTRAINT [PK_Blog] PRIMARY KEY CLUSTERED 
(
	[blog_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
create table Slide(
	slide_id int identity(1,1) NOT NULL,
	slide_title nvarchar (500) NOT NULL,
	slide_createdate Date NOT NULL,
	slide_createby nvarchar (50) NOT NULL,
	slide_modifydate Date NULL,
	slide_modifyby nvarchar(50) NULL,
	slide_imageslide nvarchar(50) NOT NULL,
	slide_descriptions nvarchar(500) NULL,
	slide_status_id bit NOT NULL,
CONSTRAINT [PK_Slide] PRIMARY KEY CLUSTERED 
(
	[slide_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[Blog] ([blog_title],[blog_author],[blog_descriptions],[blog_createdate],[blog_createby],[blog_images],[blog_modifydate],[blog_modifyby],[blog_detail],[blog_back_link]) 
VALUES (N'10 điều thú vị có thể bạn chưa biết về thương hiệu Goyard (Phần 1)', N'Tuan Anh', N'Tất cả các thương hiệu xa xỉ đều rao giảng về sự quý hiếm và độc quyền của họ, nhưng rất ít trong số họ có đủ can đảm để trở nên khó nắm bắt và kín đáo theo bất kỳ cách nào tron...', '2022-05-02', N'Tuan Anh', 'Blog2.png', '2022-05-05', N'Tuan Anh', N'<p>Tất cả các thương hiệu xa xỉ đều rao giảng về sự quý hiếm và độc quyền của họ, nhưng rất ít trong số họ có đủ can đảm để trở nên khó nắm bắt và kín đáo theo bất kỳ cách nào trong vô số cách mà Goyard đã có trong nhiều thế kỷ. Thương hiệu không quảng cáo, niêm yết sản phẩm trên trang web của mình hoặc nói chuyện với giới truyền thông, và bạn sẽ không bao giờ thấy một buổi tiệc ra mắt sản phẩm hay tuần lễ thời trang của Goyard lộng lẫy. Goyard không muốn thực hiện hành động cân bằng cực kỳ phổ biến trong ngành thời trang khi tuyên bố các sản phẩm của mình là quý hiếm và vẫn cố gắng bán các chủ thẻ trị giá 300 đô la cho mỗi người trên Trái đất; thương hiệu chỉ đơn giản là không bán các khách hàng bình thường.</p>', 
					     N'https://www.facebook.com/plugins/post.php?href=https%3A%2F%2Fwww.facebook.com%2Ftuananh462001%2Fposts%2F822954654996908&amp;show_text=true&amp;width=500&quot; width=&quot;500&quot; height=&quot;202&quot; style=&quot;border:none;overflow:hidden&quot; scrolling=&quot;no&quot; frameborder=&quot;0&quot;
                         allowfullscreen=&quot;true&quot; allow=&quot;autoplay; clipboard-write; encrypted-media; picture-in-picture; web-share')

INSERT INTO [dbo].[Slide] ([slide_title], [slide_createdate], [slide_createby], [slide_modifydate], [slide_modifyby], [slide_imageslide], [slide_descriptions], [slide_status_id]) 
VALUES (N'Bách hoá giữa năm sale đậm nửa giá', '2022-06-06', 'Tuan Anh', '2022-06-06', 'Tuan Anh', 'girl1.jpg', 'Săn deal quốc tế ngập tràn deal ngon', 1)
INSERT INTO [dbo].[Slide] ([slide_title], [slide_createdate], [slide_createby], [slide_modifydate], [slide_modifyby], [slide_imageslide], [slide_descriptions], [slide_status_id]) 
VALUES (N'ABCD', '2022-05-06', 'Tuan Anh', '2022-05-06', 'Tuan Anh', 'girl1.jpg', 'Săn deal quốc tế ngập tràn deal ngon', 0)

SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (1, N'Nike')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (2, N'Adidas')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (3, N'Reebook')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (4, N'MLB')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (5, N'Gucci')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (6, N'Vans')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (7, N'Converse')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (8, N'Other')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO


GO
SET IDENTITY_INSERT [dbo].[Color] ON 

INSERT [dbo].[Color] ([color_id], [color_name]) VALUES (1, N'Red')
INSERT [dbo].[Color] ([color_id], [color_name]) VALUES (2, N'Black')
INSERT [dbo].[Color] ([color_id], [color_name]) VALUES (3, N'White')
INSERT [dbo].[Color] ([color_id], [color_name]) VALUES (4, N'Blue')
INSERT [dbo].[Color] ([color_id], [color_name]) VALUES (5, N'Yellow')
INSERT [dbo].[Color] ([color_id], [color_name]) VALUES (6, N'Other')
SET IDENTITY_INSERT [dbo].[Color] OFF

GO
SET IDENTITY_INSERT [dbo].[Size] ON 

INSERT [dbo].[Size] (size_id, size_names) VALUES (1, 37)
INSERT [dbo].[Size] (size_id, size_names) VALUES (2, 38)
INSERT [dbo].[Size] (size_id, size_names) VALUES (3, 39)
INSERT [dbo].[Size] (size_id, size_names) VALUES (4, 40)
INSERT [dbo].[Size] (size_id, size_names) VALUES (5, 41)
INSERT [dbo].[Size] (size_id, size_names) VALUES (6, 42)
INSERT [dbo].[Size] (size_id, size_names) VALUES (7, 43)
SET IDENTITY_INSERT [dbo].[Size] OFF
GO

GO
SET IDENTITY_INSERT [dbo].[Status_product] ON 

INSERT [dbo].[Status_product] ([status_product_id], [status_product_status]) VALUES (1, N'Còn hàng')
INSERT [dbo].[Status_product] ([status_product_id], [status_product_status]) VALUES (2, N'Đang khuyến mãi')
INSERT [dbo].[Status_product]([status_product_id], [status_product_status]) VALUES (3, N'Bán chạy')
INSERT [dbo].[Status_product] ([status_product_id], [status_product_status]) VALUES (4, N'Hết hàng')
INSERT [dbo].[Status_product] ([status_product_id], [status_product_status]) VALUES (5, N'Ngừng kinh doanh')
INSERT [dbo].[Status_product]([status_product_id], [status_product_status]) VALUES (6, N'Nam')
INSERT [dbo].[Status_product] ([status_product_id], [status_product_status]) VALUES (7, N'Nữ')
INSERT [dbo].[Status_product] ([status_product_id], [status_product_status]) VALUES (8, N'Trẻ Em')
SET IDENTITY_INSERT [dbo].[Status_product] OFF
GO

SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([product_id], [product_image], [product_name], [product_price], [color_id], [product_quantity], [category_id], [status_product_id], [product_description], [product_code], [product_create_date]) VALUES (1, N'Adidas EQT Bask ADV.jpg', N'Adidas EQT Bask ADV', 150, 4, 25, 2, 1, N'
This product is made with vegan alternatives to animal-derived ingredients or materials. It is also made with Primegreen, a series of high-performance recycled materials. 50% of upper is recycled content. No virgin polyester.', N'N1', CAST(N'2022-06-11T00:00:00.000' AS DateTime))
INSERT [dbo].[Product] ([product_id], [product_image], [product_name], [product_price], [color_id], [product_quantity], [category_id], [status_product_id], [product_description], [product_code], [product_create_date]) VALUES (2, N'Adidas Stan Smith All Black.jpg', N'Adidas Stan Smith All Black', 250, 2, 25, 2, 2, N'
This product is made with vegan alternatives to animal-derived ingredients or materials. It is also made with Primegreen, a series of high-performance recycled materials. 50% of upper is recycled content. No virgin polyester.', N'N2', CAST(N'2022-06-12T00:00:00.000' AS DateTime))
INSERT [dbo].[Product] ([product_id], [product_image], [product_name], [product_price], [color_id], [product_quantity], [category_id],[status_product_id], [product_description], [product_code], [product_create_date]) VALUES (3, N'Adidas Superstar.jpg', N'Adidas Superstar', 214, 1, 25, 2, 2, N'
This product is made with vegan alternatives to animal-derived ingredients or materials. It is also made with Primegreen, a series of high-performance recycled materials. 50% of upper is recycled content. No virgin polyester.', N'N2', CAST(N'2022-06-11T00:00:00.000' AS DateTime))
INSERT [dbo].[Product] ([product_id], [product_image], [product_name], [product_price], [color_id], [product_quantity], [category_id], [status_product_id], [product_description], [product_code], [product_create_date]) VALUES (4, N'Converse 1970s Sunflower.jpg', N'Converse 1970s Sunflower', 155, 5, 6, 7, 3, N'
This product is made with vegan alternatives to animal-derived ingredients or materials. It is also made with Primegreen, a series of high-performance recycled materials. 50% of upper is recycled content. No virgin polyester.', N'Male', CAST(N'2022-06-11T00:00:00.000' AS DateTime))
INSERT [dbo].[Product] ([product_id], [product_image], [product_name], [product_price], [color_id], [product_quantity], [category_id], [status_product_id], [product_description], [product_code], [product_create_date]) VALUES (5, N'Converse Chuck Taylor All Star.jpg', N'Converse Chuck Taylor All Star', 124, 2, 6, 7, 3, N'
This product is made with vegan alternatives to animal-derived ingredients or materials. It is also made with Primegreen, a series of high-performance recycled materials. 50% of upper is recycled content. No virgin polyester.', N'Green', CAST(N'2022-06-14T00:00:00.000' AS DateTime))
INSERT [dbo].[Product] ([product_id], [product_image], [product_name], [product_price], [color_id], [product_quantity], [category_id], [status_product_id], [product_description], [product_code], [product_create_date]) VALUES (6, N'Converse Chuck Taylor II.jpg', N'Converse Chuck Taylor II', 111, 4, 12, 7, 7, N'
This product is made with vegan alternatives to animal-derived ingredients or materials. It is also made with Primegreen, a series of high-performance recycled materials. 50% of upper is recycled content. No virgin polyester.', N'N2', CAST(N'2022-06-16T00:00:00.000' AS DateTime))
INSERT [dbo].[Product] ([product_id], [product_image], [product_name], [product_price], [color_id], [product_quantity], [category_id], [status_product_id], [product_description], [product_code], [product_create_date]) VALUES (7, N'Converse Run Star Hike.jpg', N'Converse Run Star Hike', 99, 6, 5, 7, 8, N'
This product is made with vegan alternatives to animal-derived ingredients or materials. It is also made with Primegreen, a series of high-performance recycled materials. 50% of upper is recycled content. No virgin polyester.', N'Crimson', CAST(N'2022-06-16T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Product] OFF
GO


insert into shipping ([shipping_name], shipping_email, shipping_phone) values ('Jaxnation', 'kstraker0@comcast.net', '9054056655');
insert into shipping ([shipping_name], shipping_email, shipping_phone) values ('Mynte', 'mharpham1@webs.com', '3752075938');
insert into shipping ([shipping_name], shipping_email, shipping_phone) values ('Twitterworks', 'lcocci2@hhs.gov', '6248005668');
insert into shipping ([shipping_name], shipping_email, shipping_phone) values ('Latz', 'bscotchford3@spiegel.de', '3541911923');
insert into shipping ([shipping_name], shipping_email, shipping_phone) values ('Skiba', 'glafaye4@booking.com', '1656485694');
insert into shipping ([shipping_name], shipping_email, shipping_phone) values ('Innotype', 'gweins5@java.com', '7358612208');
insert into shipping ([shipping_name], shipping_email, shipping_phone) values ('Zazio', 'sdunlea6@woothemes.com', '8454936794');
insert into shipping ([shipping_name], shipping_email, shipping_phone) values ('Meemm', 'coldam7@youtube.com', '4538716086');
insert into shipping ([shipping_name], shipping_email, shipping_phone) values ('Skibox', 'wmagenny8@timesonline.co.uk', '4001474364');
insert into shipping ([shipping_name], shipping_email, shipping_phone) values ('Nlounge', 'ecage9@odnoklassniki.ru', '1991594644');

insert into [Order_status] (Order_status_status) values ('Lấy hàng');
insert into [Order_status] (Order_status_status) values ('Kiểm hàng');
insert into [Order_status] (Order_status_status) values ('Đang giao');
insert into [Order_status] (Order_status_status) values ('Đã giao hàng');
insert into [Order_status] (Order_status_status) values ('Hủy đơn hàng');
insert into [Order_status] (Order_status_status) values ('Đơn hàng lỗi');
Go

INSERT INTO [dbo].[Account] ([account_username], [account_password], [account_email], [account_name], [account_phone], [account_address], [account_role_id], [account_gender], [account_status], [account_createdate]) 
VALUES (N'Kieu', '123456789', N'anhnkthe151369@fpt.edu.vn', N'Nguyễn Kiều Tuấn Anh','0987582761', N'Sơn Tây', 1, 1, 1, '2022-06-15')
INSERT INTO [dbo].[Account] ([account_username], [account_password], [account_email], [account_name], [account_phone], [account_address], [account_role_id], [account_gender], [account_status], [account_createdate]) 
VALUES(N'KhanhVy', '123789456', N'TranKhanhVy@gmai.com',  N'Trần Khánh Vy', '013316464', N'Nghệ An', 2, 0, 1, '2022-05-05')

GO

--SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([account_id], [Order_note], [Order_status_id], [Order_total_money], [Order_Date], [shipping_id]) VALUES (1, N'oke', 4, 5722, CAST(N'2020-06-15' AS Date), 7)
INSERT [dbo].[Order] ([account_id], [Order_note], [Order_status_id], [Order_total_money], [Order_Date], [shipping_id]) VALUES (1, N'sắp oke', 2, 8327, CAST(N'2021-07-09' AS Date), 3)
/*INSERT [dbo].[Order] ([Order_id], [account_id], [Order_note], [Order_status_id], [Order_total_money], [Order_Date], [shipping_id]) VALUES (3, 2, N'sit sdfsss ', 1, 4355, CAST(N'2021-11-11' AS Date), 9)
INSERT [dbo].[Order] ([Order_id], [account_id], [Order_note], [Order_status_id], [Order_total_money], [Order_Date], [shipping_id]) VALUES (4, 3, N'dolor quis odio ', 3, 8319, CAST(N'2022-05-12' AS Date), 7)
INSERT [dbo].[Order] ([Order_id], [account_id], [Order_note], [Order_status_id], [Order_total_money], [Order_Date], [shipping_id]) VALUES (5, 2, N'aliquam augue quam', 4, 7194, CAST(N'2022-05-13' AS Date), 2)
INSERT [dbo].[Order] ([Order_id], [account_id], [Order_note], [Order_status_id], [Order_total_money], [Order_Date], [shipping_id]) VALUES (6, 5, N'curabitur conval', 3, 691, CAST(N'2022-05-14' AS Date), 5)
INSERT [dbo].[Order] ([Order_id], [account_id], [Order_note], [Order_status_id], [Order_total_money], [Order_Date], [shipping_id]) VALUES (7, 9, N'pede malesuada modo', 4, 4843, CAST(N'2022-05-16' AS Date), 9)
INSERT [dbo].[Order] ([Order_id], [account_id], [Order_note], [Order_status_id], [Order_total_money], [Order_Date], [shipping_id]) VALUES (8, 10, N'enim in temp scelerisque quam', 2, 3606, CAST(N'2022-05-17' AS Date), 7)
INSERT [dbo].[Order] ([Order_id], [account_id], [Order_note], [Order_status_id], [Order_total_money], [Order_Date], [shipping_id]) VALUES (9, 8, N'placerat ante nam', 1, 7160, CAST(N'2022-06-12' AS Date), 3)
INSERT [dbo].[Order] ([Order_id], [account_id], [Order_note], [Order_status_id], [Order_total_money], [Order_Date], [shipping_id]) VALUES (10, 7, N'aliquam quis turpisrisque', 3, 6466, CAST(N'2022-05-12' AS Date), 10)*/
--SET IDENTITY_INSERT [dbo].[Order] OFF
GO

INSERT [dbo].[Order_Details] ([Order_id], [product_id], [Order_Details_price], [Order_Details_num], [Order_Details_total_number]) VALUES (2, 3, 6, 10, 7)
INSERT [dbo].[Order_Details] ([Order_id], [product_id], [Order_Details_price], [Order_Details_num], [Order_Details_total_number]) VALUES (1, 1, 8, 3, 8)
/*INSERT [dbo].[Order_Details] ([Order_Details_id], [Order_id], [product_id], [Order_Details_price], [Order_Details_num], [Order_Details_total_number]) VALUES (3, 7, 2, 10, 5, 6)
INSERT [dbo].[Order_Details] ([Order_Details_id], [Order_id], [product_id], [Order_Details_price], [Order_Details_num], [Order_Details_total_number]) VALUES (4, 3, 4, 2, 8, 5)
INSERT [dbo].[Order_Details] ([Order_Details_id], [Order_id], [product_id], [Order_Details_price], [Order_Details_num], [Order_Details_total_number]) VALUES (5, 6, 2, 9, 5, 10)
INSERT [dbo].[Order_Details] ([Order_Details_id], [Order_id], [product_id], [Order_Details_price], [Order_Details_num], [Order_Details_total_number]) VALUES (6, 2, 1, 6, 7, 4)
INSERT [dbo].[Order_Details] ([Order_Details_id], [Order_id], [product_id], [Order_Details_price], [Order_Details_num], [Order_Details_total_number]) VALUES (7, 4, 3, 1, 9, 10)
INSERT [dbo].[Order_Details] ([Order_Details_id], [Order_id], [product_id], [Order_Details_price], [Order_Details_num], [Order_Details_total_number]) VALUES (8, 1, 1, 9, 3, 9)
INSERT [dbo].[Order_Details] ([Order_Details_id], [Order_id], [product_id], [Order_Details_price], [Order_Details_num], [Order_Details_total_number]) VALUES (9, 5, 1, 4, 10, 8)
INSERT [dbo].[Order_Details] ([Order_Details_id], [Order_id], [product_id], [Order_Details_price], [Order_Details_num], [Order_Details_total_number]) VALUES (10, 5, 2, 7, 6, 8)*/
GO