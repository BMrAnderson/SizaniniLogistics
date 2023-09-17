namespace SizananiLogistics.Application.Models
{
    public record VehiclesForContractorRequest
    {
        public required int ContractorId { get; init; }
    }
}
