namespace SizananiLogistics.Infrastructure.Models
{
    public class Contractor
    {
        public required int Id { get; init; }
        public required string Name { get; init; }
        public required string EmailAddress { get; init; }
        public required string PhoneNumber { get; init; }
    }
}
