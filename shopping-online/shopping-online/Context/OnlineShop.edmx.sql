
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/08/2022 12:09:18
-- Generated from EDMX file: C:\Users\Admin\source\repos\shopping-online\shopping-online\shopping-online\Context\OnlineShop.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Project_SU22];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Image_product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Image_product];
GO
IF OBJECT_ID(N'[dbo].[Order_Details]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Order_Details];
GO
IF OBJECT_ID(N'[dbo].[Slide]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Slide];
GO
IF OBJECT_ID(N'[dbo].[Status_order]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Status_order];
GO
IF OBJECT_ID(N'[dbo].[Status_product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Status_product];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[Project_SU22ModelStoreContainer].[Product_size]', 'U') IS NOT NULL
    DROP TABLE [Project_SU22ModelStoreContainer].[Product_size];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Accounts'
CREATE TABLE [dbo].[Accounts] (
    [account_id] int IDENTITY(1,1) NOT NULL,
    [account_email] nvarchar(50)  NOT NULL,
    [account_password] nvarchar(30)  NOT NULL,
    [account_name] nvarchar(30)  NOT NULL,
    [account_phone] nvarchar(10)  NOT NULL,
    [account_address] nvarchar(100)  NOT NULL,
    [account_gender] bit  NOT NULL,
    [account_role] int  NULL
);
GO

-- Creating table 'Blogs'
CREATE TABLE [dbo].[Blogs] (
    [id] int IDENTITY(1,1) NOT NULL,
    [title] nvarchar(200)  NOT NULL,
    [author] nvarchar(100)  NOT NULL,
    [descriptions] nvarchar(500)  NOT NULL,
    [createdate] datetime  NOT NULL,
    [createby] nvarchar(100)  NOT NULL,
    [images] nvarchar(100)  NOT NULL,
    [modifydate] datetime  NOT NULL,
    [modifyby] nvarchar(100)  NOT NULL,
    [detail] nvarchar(2000)  NOT NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [category_id] int IDENTITY(1,1) NOT NULL,
    [category_name] nvarchar(30)  NULL
);
GO

-- Creating table 'Colors'
CREATE TABLE [dbo].[Colors] (
    [color_id] int IDENTITY(1,1) NOT NULL,
    [color_name] nvarchar(30)  NULL
);
GO

-- Creating table 'Feedbacks'
CREATE TABLE [dbo].[Feedbacks] (
    [id] int IDENTITY(1,1) NOT NULL,
    [content] nvarchar(2000)  NULL,
    [ratting] float  NOT NULL,
    [product_id] int  NULL,
    [account_id] int  NOT NULL
);
GO

-- Creating table 'Image_product'
CREATE TABLE [dbo].[Image_product] (
    [id] int IDENTITY(1,1) NOT NULL,
    [image] nvarchar(100)  NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [id] int IDENTITY(1,1) NOT NULL,
    [account_id] int  NULL,
    [note] nvarchar(50)  NULL,
    [status_id] int  NOT NULL,
    [total_money] float  NOT NULL,
    [Date] datetime  NULL,
    [shipping_id] int  NOT NULL
);
GO

-- Creating table 'Order_Details'
CREATE TABLE [dbo].[Order_Details] (
    [id] int IDENTITY(1,1) NOT NULL,
    [order_id] int  NULL,
    [product_id] int  NULL,
    [price] float  NULL,
    [num] int  NULL,
    [total_number] float  NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [product_id] int IDENTITY(1,1) NOT NULL,
    [image_id] int  NOT NULL,
    [product_name] nvarchar(50)  NOT NULL,
    [product_price] float  NOT NULL,
    [color_id] int  NOT NULL,
    [product_quantity] int  NOT NULL,
    [category_id] int  NOT NULL,
    [status_id] int  NOT NULL,
    [product_description] nvarchar(2000)  NULL,
    [product_code] nvarchar(10)  NOT NULL,
    [product_sale] int  NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [id] int IDENTITY(1,1) NOT NULL,
    [role_name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Shippings'
CREATE TABLE [dbo].[Shippings] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NOT NULL,
    [email] nvarchar(100)  NOT NULL,
    [phone] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Sizes'
CREATE TABLE [dbo].[Sizes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [names] int  NOT NULL
);
GO

-- Creating table 'Status_order'
CREATE TABLE [dbo].[Status_order] (
    [id] int IDENTITY(1,1) NOT NULL,
    [status] nvarchar(100)  NULL
);
GO

-- Creating table 'Status_product'
CREATE TABLE [dbo].[Status_product] (
    [id] int IDENTITY(1,1) NOT NULL,
    [status] nvarchar(100)  NULL
);
GO

-- Creating table 'Product_size'
CREATE TABLE [dbo].[Product_size] (
    [product_id] int  NULL,
    [size_id] int  NULL,
    [quantity] int  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Slides'
CREATE TABLE [dbo].[Slides] (
    [id] int IDENTITY(1,1) NOT NULL,
    [title] nvarchar(500)  NOT NULL,
    [createdate] datetime  NOT NULL,
    [createby] nvarchar(50)  NOT NULL,
    [modifydate] datetime  NULL,
    [modifyby] nvarchar(50)  NULL,
    [imageslide] nvarchar(50)  NOT NULL,
    [descriptions] nvarchar(500)  NULL,
    [status_id] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [account_id] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [PK_Accounts]
    PRIMARY KEY CLUSTERED ([account_id] ASC);
GO

-- Creating primary key on [id] in table 'Blogs'
ALTER TABLE [dbo].[Blogs]
ADD CONSTRAINT [PK_Blogs]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [category_id] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([category_id] ASC);
GO

-- Creating primary key on [color_id] in table 'Colors'
ALTER TABLE [dbo].[Colors]
ADD CONSTRAINT [PK_Colors]
    PRIMARY KEY CLUSTERED ([color_id] ASC);
GO

-- Creating primary key on [id] in table 'Feedbacks'
ALTER TABLE [dbo].[Feedbacks]
ADD CONSTRAINT [PK_Feedbacks]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Image_product'
ALTER TABLE [dbo].[Image_product]
ADD CONSTRAINT [PK_Image_product]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Order_Details'
ALTER TABLE [dbo].[Order_Details]
ADD CONSTRAINT [PK_Order_Details]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [product_id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([product_id] ASC);
GO

-- Creating primary key on [id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Shippings'
ALTER TABLE [dbo].[Shippings]
ADD CONSTRAINT [PK_Shippings]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Sizes'
ALTER TABLE [dbo].[Sizes]
ADD CONSTRAINT [PK_Sizes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Status_order'
ALTER TABLE [dbo].[Status_order]
ADD CONSTRAINT [PK_Status_order]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Status_product'
ALTER TABLE [dbo].[Status_product]
ADD CONSTRAINT [PK_Status_product]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [quantity] in table 'Product_size'
ALTER TABLE [dbo].[Product_size]
ADD CONSTRAINT [PK_Product_size]
    PRIMARY KEY CLUSTERED ([quantity] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [id] in table 'Slides'
ALTER TABLE [dbo].[Slides]
ADD CONSTRAINT [PK_Slides]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [account_role] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [FK_Account_Role]
    FOREIGN KEY ([account_role])
    REFERENCES [dbo].[Roles]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Account_Role'
CREATE INDEX [IX_FK_Account_Role]
ON [dbo].[Accounts]
    ([account_role]);
GO

-- Creating foreign key on [account_id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_Order_Status_Account]
    FOREIGN KEY ([account_id])
    REFERENCES [dbo].[Accounts]
        ([account_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_Status_Account'
CREATE INDEX [IX_FK_Order_Status_Account]
ON [dbo].[Orders]
    ([account_id]);
GO

-- Creating foreign key on [category_id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Product_Category]
    FOREIGN KEY ([category_id])
    REFERENCES [dbo].[Categories]
        ([category_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Product_Category'
CREATE INDEX [IX_FK_Product_Category]
ON [dbo].[Products]
    ([category_id]);
GO

-- Creating foreign key on [color_id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Product_Color]
    FOREIGN KEY ([color_id])
    REFERENCES [dbo].[Colors]
        ([color_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Product_Color'
CREATE INDEX [IX_FK_Product_Color]
ON [dbo].[Products]
    ([color_id]);
GO

-- Creating foreign key on [product_id] in table 'Feedbacks'
ALTER TABLE [dbo].[Feedbacks]
ADD CONSTRAINT [FK_Feedback_Product]
    FOREIGN KEY ([product_id])
    REFERENCES [dbo].[Products]
        ([product_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Feedback_Product'
CREATE INDEX [IX_FK_Feedback_Product]
ON [dbo].[Feedbacks]
    ([product_id]);
GO

-- Creating foreign key on [image_id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Product_Image_product]
    FOREIGN KEY ([image_id])
    REFERENCES [dbo].[Image_product]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Product_Image_product'
CREATE INDEX [IX_FK_Product_Image_product]
ON [dbo].[Products]
    ([image_id]);
GO

-- Creating foreign key on [order_id] in table 'Order_Details'
ALTER TABLE [dbo].[Order_Details]
ADD CONSTRAINT [FK_Order_Details_Order]
    FOREIGN KEY ([order_id])
    REFERENCES [dbo].[Orders]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_Details_Order'
CREATE INDEX [IX_FK_Order_Details_Order]
ON [dbo].[Order_Details]
    ([order_id]);
GO

-- Creating foreign key on [shipping_id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_Order_Shipping]
    FOREIGN KEY ([shipping_id])
    REFERENCES [dbo].[Shippings]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_Shipping'
CREATE INDEX [IX_FK_Order_Shipping]
ON [dbo].[Orders]
    ([shipping_id]);
GO

-- Creating foreign key on [status_id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_Order_Status_order]
    FOREIGN KEY ([status_id])
    REFERENCES [dbo].[Status_order]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_Status_order'
CREATE INDEX [IX_FK_Order_Status_order]
ON [dbo].[Orders]
    ([status_id]);
GO

-- Creating foreign key on [product_id] in table 'Order_Details'
ALTER TABLE [dbo].[Order_Details]
ADD CONSTRAINT [FK_Order_Details_Product]
    FOREIGN KEY ([product_id])
    REFERENCES [dbo].[Products]
        ([product_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_Details_Product'
CREATE INDEX [IX_FK_Order_Details_Product]
ON [dbo].[Order_Details]
    ([product_id]);
GO

-- Creating foreign key on [product_id] in table 'Product_size'
ALTER TABLE [dbo].[Product_size]
ADD CONSTRAINT [FK_Product_size_Product]
    FOREIGN KEY ([product_id])
    REFERENCES [dbo].[Products]
        ([product_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Product_size_Product'
CREATE INDEX [IX_FK_Product_size_Product]
ON [dbo].[Product_size]
    ([product_id]);
GO

-- Creating foreign key on [status_id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Product_Status_product]
    FOREIGN KEY ([status_id])
    REFERENCES [dbo].[Status_product]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Product_Status_product'
CREATE INDEX [IX_FK_Product_Status_product]
ON [dbo].[Products]
    ([status_id]);
GO

-- Creating foreign key on [size_id] in table 'Product_size'
ALTER TABLE [dbo].[Product_size]
ADD CONSTRAINT [FK_Product_size_Size]
    FOREIGN KEY ([size_id])
    REFERENCES [dbo].[Sizes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Product_size_Size'
CREATE INDEX [IX_FK_Product_size_Size]
ON [dbo].[Product_size]
    ([size_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------