namespace SizananiLogistics.Infrastructure.Models
{
    public record VehicleContractorSummary
    {
        public required int ContractorId { get; set; }
        public required string ContractorName { get; set; }
        public required int TotalVehicles { get; set; }
        public required double TotalWeight { get; set; }
    }
}
