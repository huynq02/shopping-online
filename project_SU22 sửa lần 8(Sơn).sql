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
	Role_id int primary key NOT NULL,
	Role_name nvarchar (100) NOT NULL,
	Role_description nvarchar (200) NOT NULL,
)
GO

insert into [Role] (Role_id, Role_name, Role_description) values (1, 'Andee Trencher', 'felis eu sapien');
insert into [Role] (Role_id, Role_name, Role_description) values (2, 'Auguste Ubanks', 'nam ultrices libero non');
insert into [Role] (Role_id, Role_name, Role_description) values (3, 'Forester Siemianowicz', 'blandit mi in');
insert into [Role] (Role_id, Role_name, Role_description) values (4, 'Lainey Batteson', 'luctus rutrum nulla');
insert into [Role] (Role_id, Role_name, Role_description) values (5, 'Lynne Foresight', 'blandit mi in');
insert into [Role] (Role_id, Role_name, Role_description) values (6, 'Linell Drinkale', 'tortor quis turpis sed');
insert into [Role] (Role_id, Role_name, Role_description) values (7, 'Erek Brightey', 'sit amet sapien dignissim');
insert into [Role] (Role_id, Role_name, Role_description) values (8, 'Anderea Shelvey', 'ligula nec sem duis');
insert into [Role] (Role_id, Role_name, Role_description) values (9, 'Gertrude Jaggar', 'vestibulum rutrum rutrum neque');
insert into [Role] (Role_id, Role_name, Role_description) values (10, 'Cammy Melmoth', 'aliquam quis turpis eget');
GO

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
	account_DOB Date 
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
SET IDENTITY_INSERT [dbo].[Color] ON 

INSERT [dbo].[Color] ([color_id], [color_name]) VALUES (1, N'Red')
INSERT [dbo].[Color] ([color_id], [color_name]) VALUES (2, N'Black')
INSERT [dbo].[Color] ([color_id], [color_name]) VALUES (3, N'White')
INSERT [dbo].[Color] ([color_id], [color_name]) VALUES (4, N'Blue')
INSERT [dbo].[Color] ([color_id], [color_name]) VALUES (5, N'Yellow')
INSERT [dbo].[Color] ([color_id], [color_name]) VALUES (6, N'Other')
SET IDENTITY_INSERT [dbo].[Color] OFF

GO




