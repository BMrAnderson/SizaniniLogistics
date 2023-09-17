namespace SizananiLogistics.Web.Models
{
    public class VehicleContractorSummary
    {
        public required int TotalVehicles { get; init; }
        public required double TotalWeight { get; init; }
        public required string ContractorName { get; init; }
    }
}
