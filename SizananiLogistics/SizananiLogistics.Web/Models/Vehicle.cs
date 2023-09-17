namespace SizananiLogistics.Web.Models
{
    public class Vehicle
    {
        public int? Id { get; set; }
        public int? ContractorId { get; set; }
        public required string Type { get; init; }
        public required string RegistrationNumber { get; init; }
        public required string Model { get; init; }
        public required double Weight { get; init; }
    }
}
