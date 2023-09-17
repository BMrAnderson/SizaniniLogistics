namespace SizananiLogistics.Application.Models
{
    public record RegisterVehicleRequest
    {
        public required Vehicle Vehicle { get; init; }
    }
}
