namespace SizananiLogistics.Web.Models
{
    public class RegisterContractorViewModel
    {
        public required Contractor Contractor { get; set; }

        public static RegisterContractorViewModel Empty()
        {
            return new RegisterContractorViewModel()
            {
                Contractor = new Contractor()
                {
                    Id = default,
                    EmailAddress = string.Empty,
                    Name = string.Empty,
                    PhoneNumber = string.Empty
                }
            };
        }
    }
}
