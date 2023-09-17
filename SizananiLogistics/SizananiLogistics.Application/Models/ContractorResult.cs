namespace SizananiLogistics.Application.Models
{
    public record ContractorResult : Contractor
    {
        public required int Id { get; init; }
    }
}
