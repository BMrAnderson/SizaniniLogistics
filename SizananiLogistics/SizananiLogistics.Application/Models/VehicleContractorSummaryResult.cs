namespace SizananiLogistics.Application.Models
{
    public record VehicleContractorSummaryResult
    {
        public required int TotalVehiclesAssigned { get; init; }
        public required double TotalWeightInTonsOfVehiclesAssigned { get; init; }
        public required string ContractorName { get; init; }

    }
}
