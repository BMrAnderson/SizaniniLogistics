IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = 'SizananiLogistics')
BEGIN
    CREATE DATABASE SizananiLogistics;
END
GO

USE SizananiLogistics;
GO

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Contractor')
BEGIN
    CREATE TABLE Contractor
    (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Name NVARCHAR(255) NOT NULL,
        EmailAddress NVARCHAR(255) NOT NULL,
        PhoneNumber NVARCHAR(20) NOT NULL
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Vehicle')
BEGIN
    CREATE TABLE Vehicle
    (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        ContractorId INT,
        Type NVARCHAR(255) NOT NULL,
        RegistrationNumber NVARCHAR(50) NOT NULL,
        Model NVARCHAR(255) NOT NULL,
        Weight FLOAT NOT NULL,
        CONSTRAINT FK_Vehicle_Contractor FOREIGN KEY (ContractorId) REFERENCES Contractor(Id)
    );
END
GO

CREATE VIEW ContractorSummaryView
AS
SELECT
    contractor.Id AS ContractorId,
    contractor.Name AS ContractorName,
    COUNT(vehicle.Id) AS TotalVehicles,
    SUM(vehicle.Weight) AS TotalWeight
FROM Contractor contractor 
INNER JOIN Vehicle vehicle 
	ON contractor.Id = vehicle.ContractorId
GROUP BY contractor.Id, contractor.Name;


