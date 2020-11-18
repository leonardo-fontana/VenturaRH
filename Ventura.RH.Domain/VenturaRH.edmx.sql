
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/12/2020 20:19:07
-- Generated from EDMX file: C:\Users\leodf\source\repos\VenturaRH\Ventura.RH.Domain\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [VenturaRH];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'OpportunitySet'
CREATE TABLE [dbo].[OpportunitySet] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [CriterionList] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [email] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UserSet_Administrator'
CREATE TABLE [dbo].[UserSet_Administrator] (
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'UserSet_Enterprise'
CREATE TABLE [dbo].[UserSet_Enterprise] (
    [CNPJ] nvarchar(max)  NOT NULL,
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'UserSet_CommonUser'
CREATE TABLE [dbo].[UserSet_CommonUser] (
    [Age] nvarchar(max)  NOT NULL,
    [CPF] nvarchar(max)  NOT NULL,
    [Id] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'OpportunitySet'
ALTER TABLE [dbo].[OpportunitySet]
ADD CONSTRAINT [PK_OpportunitySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserSet_Administrator'
ALTER TABLE [dbo].[UserSet_Administrator]
ADD CONSTRAINT [PK_UserSet_Administrator]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserSet_Enterprise'
ALTER TABLE [dbo].[UserSet_Enterprise]
ADD CONSTRAINT [PK_UserSet_Enterprise]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserSet_CommonUser'
ALTER TABLE [dbo].[UserSet_CommonUser]
ADD CONSTRAINT [PK_UserSet_CommonUser]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Id] in table 'UserSet_Administrator'
ALTER TABLE [dbo].[UserSet_Administrator]
ADD CONSTRAINT [FK_Administrator_inherits_User]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'UserSet_Enterprise'
ALTER TABLE [dbo].[UserSet_Enterprise]
ADD CONSTRAINT [FK_Enterprise_inherits_User]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'UserSet_CommonUser'
ALTER TABLE [dbo].[UserSet_CommonUser]
ADD CONSTRAINT [FK_CommonUser_inherits_User]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------