
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/16/2016 15:14:59
-- Generated from EDMX file: E:\cs\EFfirst\EFfirst\Models\EFfirstModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Test];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserInfoOrderInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderInfo] DROP CONSTRAINT [FK_UserInfoOrderInfo];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfo];
GO
IF OBJECT_ID(N'[dbo].[OrderInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderInfo];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserInfo'
CREATE TABLE [dbo].[UserInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL
);
GO

-- Creating table 'OrderInfo'
CREATE TABLE [dbo].[OrderInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Content] nvarchar(255)  NULL,
    [UserInfoId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserInfo'
ALTER TABLE [dbo].[UserInfo]
ADD CONSTRAINT [PK_UserInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderInfo'
ALTER TABLE [dbo].[OrderInfo]
ADD CONSTRAINT [PK_OrderInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserInfoId] in table 'OrderInfo'
ALTER TABLE [dbo].[OrderInfo]
ADD CONSTRAINT [FK_UserInfoOrderInfo]
    FOREIGN KEY ([UserInfoId])
    REFERENCES [dbo].[UserInfo]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoOrderInfo'
CREATE INDEX [IX_FK_UserInfoOrderInfo]
ON [dbo].[OrderInfo]
    ([UserInfoId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------