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
insert into Account ( account_username, account_password, account_email, account_name, account_phone, account_address, account_role_id, account_gender, account_DOB) values 
( N'srego0', N'qlRSKgrn7GX', N'srego0@statcounter.com', N'Sybila Rego', '4705930853', '91502 Westerfield Trail', 1, 1, '4/9/1999'),
( N'csattin1', N'I7FLklx', N'csattin1@example.com', N'Coral Sattin', '365796835', '3 Summer Ridge Pass', 2, 0, '1/27/2005')

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
	image_product nvarchar (500) NOT NULL,
	product_name nvarchar(50) NOT NULL,
	product_price float NOT NULL,
	color_id int foreign key references Color(color_id),
	product_quantity int NOT NULL,
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
	account_id int foreign key references Account(account_id) NOT NULL,
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
	slide_status_id bit NOT NULL,
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


insert into [Order_status] (Order_status_status) values ('penatibus et magnis dis parturient montes');
insert into [Order_status] (Order_status_status) values ('metus aenean fermentum donec ut mauris eget');
insert into [Order_status] (Order_status_status) values ('quis odio consequat varius integer ac');
insert into [Order_status] (Order_status_status) values ('eget vulputate ut ultrices vel augue vestibulum');
insert into [Order_status] (Order_status_status) values ('aliquam sit amet diam in magna bibendum imperdiet');
insert into [Order_status] (Order_status_status) values ('ut tellus nulla ut erat id mauris vulputate elementum nullam');
insert into [Order_status] (Order_status_status) values ('platea dictumst morbi vestibulum velit id pretium iaculis diam');
insert into [Order_status] (Order_status_status) values ('turpis donec posuere metus vitae ipsum aliquam non');
insert into [Order_status] (Order_status_status) values ('sodales sed tincidunt eu felis fusce posuere felis');
insert into [Order_status] (Order_status_status) values ('quis augue luctus tincidunt nulla mollis');

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

insert into Color (color_name) values ('Violet');
insert into Color (color_name) values ('Crimson');
insert into Color (color_name) values ('Maroon');
insert into Color (color_name) values ('Fuscia');
insert into Color (color_name) values ('Goldenrod');
insert into Color (color_name) values ('Green');
insert into Color (color_name) values ('Khaki');
insert into Color (color_name) values ('Mauv');
insert into Color (color_name) values ('Pink');
insert into Color (color_name) values ('Maroon');

insert into Category (category_name) values ('Abbott-Frami');
insert into Category (category_name) values ('Toy Inc');
insert into Category (category_name) values ('Kilback, Goyette and Sipes');
insert into Category (category_name) values ('Sanford and Sons');
insert into Category (category_name) values ('Goyette-Mueller');
insert into Category (category_name) values ('Kulas, Schowalter and Hessel');
insert into Category (category_name) values ('Weber and Sons');
insert into Category (category_name) values ('Flatley and Sons');
insert into Category (category_name) values ('Dickinson and Sons');
insert into Category (category_name) values ('Bechtelar-Koelpin');

insert into size (size_names) values (48);
insert into size (size_names) values (51);
insert into size (size_names) values (37);
insert into size (size_names) values (45);
insert into size (size_names) values (54);
insert into size (size_names) values (50);
insert into size (size_names) values (50);
insert into size (size_names) values (48);
insert into size (size_names) values (51);
insert into size (size_names) values (46);

insert into productsize (size_id, product_quantity) values (2, 143);
insert into productsize (size_id, product_quantity) values (3, 195);
insert into productsize (size_id, product_quantity) values (9, 170);
insert into productsize (size_id, product_quantity) values (7, 181);
insert into productsize (size_id, product_quantity) values (3, 2);
insert into productsize (size_id, product_quantity) values (10, 67);
insert into productsize (size_id, product_quantity) values (2, 188);
insert into productsize (size_id, product_quantity) values (4, 77);
insert into productsize (size_id, product_quantity) values (7, 160);
insert into productsize (size_id, product_quantity) values (10, 117);

insert into [status_product] (status_product_status) values ('risus auctor sed tristique in tempus');
insert into [status_product] (status_product_status) values ('vestibulum ac est lacinia nisi venenatis tristique fusce congue');
insert into [status_product] (status_product_status) values ('consequat varius integer ac leo');
insert into [status_product] (status_product_status) values ('consequat nulla nisl nunc nisl');
insert into [status_product] (status_product_status) values ('turpis nec euismod scelerisque quam turpis adipiscing lorem vitae mattis');
insert into [status_product] (status_product_status) values ('tincidunt nulla mollis molestie lorem quisque ut erat curabitur gravida');
insert into [status_product] (status_product_status) values ('enim blandit mi in porttitor');
insert into [status_product] (status_product_status) values ('dictumst maecenas ut massa quis');
insert into [status_product] (status_product_status) values ('eros vestibulum ac est lacinia nisi');
insert into [status_product] (status_product_status) values ('diam vitae quam suspendisse potenti nullam porttitor lacus');


insert into product (image_product, product_name, product_price, color_id, product_quantity, category_id, status_product_id, product_description, product_code, product_sale) values ('diam cras pellentesque volutpat dui maecenas tristique', 'San Clemente Island Bushmallow', '$5063.94', 3, 27, 1, 6, 'vulputate ut ultrices vel augue vestibulum', 'CNY', 2);
insert into product (image_product, product_name, product_price, color_id, product_quantity, category_id, status_product_id, product_description, product_code, product_sale) values ('sed accumsan felis ut at', 'Cuban Prescott Orchid', '$3922.37', 3, 42, 6, 3, 'nulla nisl nunc nisl duis bibendum felis sed interdum venenatis', 'SEK', 7);
insert into product (image_product, product_name, product_price, color_id, product_quantity, category_id, status_product_id, product_description, product_code, product_sale) values ('volutpat sapien arcu sed augue aliquam', 'Maui Dubautia', '$1924.45', 1, 267, 8, 5, 'nulla nunc purus phasellus in felis donec semper', 'CAD', 7);
insert into product (image_product, product_name, product_price, color_id, product_quantity, category_id, status_product_id, product_description, product_code, product_sale) values ('vel dapibus at diam nam tristique tortor', 'Fineleaf Fournerved Daisy', '$9045.79', 10, 185, 1, 8, 'tincidunt in leo maecenas pulvinar lobortis est phasellus sit', 'SEK', 1);
insert into product (image_product, product_name, product_price, color_id, product_quantity, category_id, status_product_id, product_description, product_code, product_sale) values ('mauris eget massa tempor convallis nulla', 'Golden Dwarfgentian', '$2967.06', 3, 116, 2, 4, 'id justo sit amet sapien dignissim', 'EUR', 6);
insert into product (image_product, product_name, product_price, color_id, product_quantity, category_id, status_product_id, product_description, product_code, product_sale) values ('ut massa volutpat convallis morbi odio odio', 'Alaskan Glacier Buttercup', '$9157.55', 6, 297, 2, 6, 'vestibulum ac est lacinia nisi venenatis tristique fusce congue diam', 'RUB', 10);
insert into product (image_product, product_name, product_price, color_id, product_quantity, category_id, status_product_id, product_description, product_code, product_sale) values ('erat eros viverra eget congue eget', 'Pore Lichen', '$8503.03', 8, 631, 9, 1, 'parturient montes nascetur ridiculus mus vivamus vestibulum sagittis sapien', 'CNY', 7);
insert into product (image_product, product_name, product_price, color_id, product_quantity, category_id, status_product_id, product_description, product_code, product_sale) values ('feugiat non pretium quis lectus suspendisse potenti in eleifend quam', 'Brown''s Waterleaf', '$3128.87', 6, 54, 2, 6, 'nisi nam ultrices libero non mattis pulvinar', 'EUR', 5);
insert into product (image_product, product_name, product_price, color_id, product_quantity, category_id, status_product_id, product_description, product_code, product_sale) values ('ac nulla sed vel enim sit amet', 'Stenogyne', '$44.87', 4, 702, 10, 1, 'integer pede justo lacinia eget tincidunt eget tempus vel pede', 'CNY', 6);
insert into product (image_product, product_name, product_price, color_id, product_quantity, category_id, status_product_id, product_description, product_code, product_sale) values ('quam pede lobortis ligula sit', 'Park Willow', '$3908.54', 9, 110, 10, 3, 'et tempus semper est quam pharetra magna ac', 'CZK', 6);




insert into feedback (feetback_content, feetback_ratting, product_id, account_id) values ('suspendisse potenti nullam porttitor lacus at turpis donec', 1.04, 2, 2);
insert into feedback (feetback_content, feetback_ratting, product_id, account_id) values ('quam sollicitudin vitae consectetuer eget rutrum at lorem integer', 2.66, 10, 1);
insert into feedback (feetback_content, feetback_ratting, product_id, account_id) values ('vestibulum sit amet cursus id turpis integer aliquet', 2.61, 5, 2);
insert into feedback (feetback_content, feetback_ratting, product_id, account_id) values ('mauris laoreet ut rhoncus aliquet pulvinar', 4.17, 10, 2);
insert into feedback (feetback_content, feetback_ratting, product_id, account_id) values ('penatibus et magnis dis parturient', 2.73, 1, 1);
insert into feedback (feetback_content, feetback_ratting, product_id, account_id) values ('erat id mauris vulputate elementum', 4.14, 8, 1);
insert into feedback (feetback_content, feetback_ratting, product_id, account_id) values ('turpis eget elit sodales scelerisque mauris sit amet eros suspendisse', 2.79, 8, 1);
insert into feedback (feetback_content, feetback_ratting, product_id, account_id) values ('ut ultrices vel augue vestibulum', 1.45, 3, 1);
insert into feedback (feetback_content, feetback_ratting, product_id, account_id) values ('sagittis nam congue risus semper porta volutpat', 4.25, 10, 1);
insert into feedback (feetback_content, feetback_ratting, product_id, account_id) values ('vel est donec odio justo sollicitudin', 4.39, 6, 2);

insert into Order_Details (Order_id, product_id, Order_Details_price, Order_Details_num, Order_Details_total_number) values (10, 3.29, 6, 10, 7);
insert into Order_Details (Order_id, product_id, Order_Details_price, Order_Details_num, Order_Details_total_number) values (5, 1.83, 8, 3, 8);
insert into Order_Details (Order_id, product_id, Order_Details_price, Order_Details_num, Order_Details_total_number) values (7, 2.05, 10, 5, 6);
insert into Order_Details (Order_id, product_id, Order_Details_price, Order_Details_num, Order_Details_total_number) values (3, 4.06, 2, 8, 5);
insert into Order_Details (Order_id, product_id, Order_Details_price, Order_Details_num, Order_Details_total_number) values (8, 2.73, 9, 5, 10);
insert into Order_Details (Order_id, product_id, Order_Details_price, Order_Details_num, Order_Details_total_number) values (2, 1.09, 6, 7, 4);
insert into Order_Details (Order_id, product_id, Order_Details_price, Order_Details_num, Order_Details_total_number) values (4, 3.62, 1, 9, 10);
insert into Order_Details (Order_id, product_id, Order_Details_price, Order_Details_num, Order_Details_total_number) values (9, 1.81, 9, 3, 9);
insert into Order_Details (Order_id, product_id, Order_Details_price, Order_Details_num, Order_Details_total_number) values (5, 1.02, 4, 10, 8);
insert into Order_Details (Order_id, product_id, Order_Details_price, Order_Details_num, Order_Details_total_number) values (5, 2.48, 7, 6, 8);














