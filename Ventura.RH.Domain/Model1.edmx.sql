
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/30/2020 14:34:15
-- Generated from EDMX file: C:\Users\leodf\source\repos\VenturaRH\Ventura.RH.Domain\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [VenturaHR];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Administrator_inherits_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User_Administrator] DROP CONSTRAINT [FK_Administrator_inherits_User];
GO
IF OBJECT_ID(N'[dbo].[FK_CommonUser_inherits_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User_CommonUser] DROP CONSTRAINT [FK_CommonUser_inherits_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Enterprise_inherits_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User_Enterprise] DROP CONSTRAINT [FK_Enterprise_inherits_User];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[OpportunitySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OpportunitySet];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[User_Administrator]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User_Administrator];
GO
IF OBJECT_ID(N'[dbo].[User_CommonUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User_CommonUser];
GO
IF OBJECT_ID(N'[dbo].[User_Enterprise]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User_Enterprise];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'OpportunitySet'
CREATE TABLE [dbo].[OpportunitySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [ExpireDate] datetime  NOT NULL,
    [CreateDate] datetime  NOT NULL,
    [CriteriaId] int  NOT NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Criteria'
CREATE TABLE [dbo].[Criteria] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [PWD] smallint  NOT NULL,
    [Weight] smallint  NOT NULL,
    [OpportunityId] int  NOT NULL
);
GO

-- Creating table 'User_Administrator'
CREATE TABLE [dbo].[User_Administrator] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'User_Enterprise'
CREATE TABLE [dbo].[User_Enterprise] (
    [CNPJ] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'User_CommonUser'
CREATE TABLE [dbo].[User_CommonUser] (
    [Age] smallint  NOT NULL,
    [CPF] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
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

-- Creating primary key on [Id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Criteria'
ALTER TABLE [dbo].[Criteria]
ADD CONSTRAINT [PK_Criteria]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'User_Administrator'
ALTER TABLE [dbo].[User_Administrator]
ADD CONSTRAINT [PK_User_Administrator]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'User_Enterprise'
ALTER TABLE [dbo].[User_Enterprise]
ADD CONSTRAINT [PK_User_Enterprise]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'User_CommonUser'
ALTER TABLE [dbo].[User_CommonUser]
ADD CONSTRAINT [PK_User_CommonUser]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [OpportunityId] in table 'Criteria'
ALTER TABLE [dbo].[Criteria]
ADD CONSTRAINT [FK_OpportunityCriteria]
    FOREIGN KEY ([OpportunityId])
    REFERENCES [dbo].[OpportunitySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OpportunityCriteria'
CREATE INDEX [IX_FK_OpportunityCriteria]
ON [dbo].[Criteria]
    ([OpportunityId]);
GO

-- Creating foreign key on [Id] in table 'User_Administrator'
ALTER TABLE [dbo].[User_Administrator]
ADD CONSTRAINT [FK_Administrator_inherits_User]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'User_Enterprise'
ALTER TABLE [dbo].[User_Enterprise]
ADD CONSTRAINT [FK_Enterprise_inherits_User]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'User_CommonUser'
ALTER TABLE [dbo].[User_CommonUser]
ADD CONSTRAINT [FK_CommonUser_inherits_User]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------