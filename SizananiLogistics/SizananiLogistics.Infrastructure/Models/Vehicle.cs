namespace SizananiLogistics.Infrastructure.Models
{
    public record Vehicle
    {
        public required int Id { get; init; }
        public int? ContractorId { get; set; }
        public required string Type { get; init; }
        public required string RegistrationNumber { get; init; }
        public required string Model { get; init; }
        public required double Weight { get; init; }
    }
}
