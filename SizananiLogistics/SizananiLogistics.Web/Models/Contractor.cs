namespace SizananiLogistics.Web.Models
{
    public class Contractor
    {
        public int? Id { get; set; }
        public required string Name { get; set; }
        public required string EmailAddress { get; set; }
        public required string PhoneNumber { get; set; }
        public IReadOnlyCollection<Vehicle> Vehicles { get; set; }

        public Contractor() => Vehicles = Array.Empty<Vehicle>();
    }
}
