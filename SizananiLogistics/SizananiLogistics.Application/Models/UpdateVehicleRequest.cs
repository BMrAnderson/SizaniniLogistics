namespace SizananiLogistics.Application.Models
{
    public record UpdateVehicleRequest
    {
        public required int Id { get; init; }
        public required Vehicle Vehicle { get; init; }
    }
}
