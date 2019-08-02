
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/03/2019 01:13:04
-- Generated from EDMX file: E:\Projects\IEC\Project\IEC.Server\IEC.Model\IECModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [IEC];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CandidateForm_Candidate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CandidateDocuments] DROP CONSTRAINT [FK_CandidateForm_Candidate];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CandidateDocuments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CandidateDocuments];
GO
IF OBJECT_ID(N'[dbo].[Candidates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Candidates];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CandidateDocuments'
CREATE TABLE [dbo].[CandidateDocuments] (
    [CandidateDocumentId] int IDENTITY(1,1) NOT NULL,
    [DocumentName] nvarchar(250)  NOT NULL,
    [DocumentType] int  NOT NULL,
    [DocumentSize] int  NOT NULL,
    [CandidateId] int  NOT NULL,
    [DocumentPath] nvarchar(500)  NOT NULL
);
GO

-- Creating table 'Candidates'
CREATE TABLE [dbo].[Candidates] (
    [CandidateId] int IDENTITY(1,1) NOT NULL,
    [FullName] nvarchar(250)  NOT NULL,
    [DOB] nvarchar(250)  NOT NULL,
    [Gender] nvarchar(50)  NOT NULL,
    [Address] nvarchar(500)  NOT NULL,
    [City] nvarchar(250)  NOT NULL,
    [Mobile] nvarchar(250)  NOT NULL,
    [Email] nvarchar(250)  NOT NULL,
    [Qualification] nvarchar(250)  NOT NULL,
    [FirstDesiredCourse] nvarchar(250)  NOT NULL,
    [FirstCountry] int  NOT NULL,
    [SecondDesiredCourse] nvarchar(250)  NULL,
    [SecondCountry] nvarchar(250)  NULL,
    [Hear] int  NOT NULL,
    [IsNew] bit  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CandidateDocumentId] in table 'CandidateDocuments'
ALTER TABLE [dbo].[CandidateDocuments]
ADD CONSTRAINT [PK_CandidateDocuments]
    PRIMARY KEY CLUSTERED ([CandidateDocumentId] ASC);
GO

-- Creating primary key on [CandidateId] in table 'Candidates'
ALTER TABLE [dbo].[Candidates]
ADD CONSTRAINT [PK_Candidates]
    PRIMARY KEY CLUSTERED ([CandidateId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CandidateId] in table 'CandidateDocuments'
ALTER TABLE [dbo].[CandidateDocuments]
ADD CONSTRAINT [FK_CandidateForm_Candidate]
    FOREIGN KEY ([CandidateId])
    REFERENCES [dbo].[Candidates]
        ([CandidateId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CandidateForm_Candidate'
CREATE INDEX [IX_FK_CandidateForm_Candidate]
ON [dbo].[CandidateDocuments]
    ([CandidateId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------