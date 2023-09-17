namespace SizananiLogistics.Application.Models
{
    public record RegisterContractorRequest
    {
        public required Contractor Contractor { get; init; }
    }
}
