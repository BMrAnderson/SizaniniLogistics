
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
