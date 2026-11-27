-- Practical 11: Smart Campus Service Portal - Non-destructive SQL Server Setup Script
-- Target Instance: Default SQL Server instance (.) / MSSQLSERVER
-- Safe to run multiple times; preserves all existing tables and records.

IF DB_ID(N'Practical11') IS NULL
BEGIN
    CREATE DATABASE [Practical11];
END
GO

USE [Practical11];
GO

IF OBJECT_ID(N'dbo.ServiceRequests', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.ServiceRequests
    (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        StudentName NVARCHAR(70) NOT NULL,
        Department NVARCHAR(60) NOT NULL,
        Issue NVARCHAR(80) NOT NULL,
        Description NVARCHAR(500) NOT NULL,
        Status NVARCHAR(50) NOT NULL CONSTRAINT DF_ServiceRequests_Status DEFAULT N'Pending',
        CreatedAt DATETIME2 NOT NULL CONSTRAINT DF_ServiceRequests_CreatedAt DEFAULT SYSDATETIME()
    );
END
GO

IF OBJECT_ID(N'dbo.CampusEvents', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.CampusEvents
    (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Title NVARCHAR(100) NOT NULL,
        Location NVARCHAR(150) NOT NULL,
        EventDate DATETIME2 NOT NULL,
        Description NVARCHAR(500) NOT NULL
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.CampusEvents)
BEGIN
    INSERT INTO dbo.CampusEvents (Title, Location, EventDate, Description)
    VALUES
        (N'Tech Innovation Day', N'Main Auditorium', DATEADD(DAY, 3, CAST(GETDATE() AS DATETIME2)), N'Student project showcase, prototype demos, and industry tech talks.'),
        (N'Campus Sports Meet', N'University Sports Ground', DATEADD(DAY, 10, CAST(GETDATE() AS DATETIME2)), N'Annual inter-department athletics, cricket, and indoor sports competitions.'),
        (N'Cloud & .NET Workshop', N'Computer Engineering Seminar Hall', DATEADD(DAY, 15, CAST(GETDATE() AS DATETIME2)), N'Hands-on session on ASP.NET Core MVC, Entity Framework Core, and REST APIs.');
END
GO
