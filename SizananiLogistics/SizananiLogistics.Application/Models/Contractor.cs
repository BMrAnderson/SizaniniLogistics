namespace SizananiLogistics.Application.Models
{
    public record Contractor
    {
        public required string Name { get; init; }
        public required string EmailAddress { get; init; }
        public required string PhoneNumber { get; init; }
    }
}
