namespace SizananiLogistics.Web.Models
{
    public class RegisterVehicleViewModel
    {
        public required Vehicle Vehicle { get; set; }

        public RegisterVehicleViewModel WithVehicleContractor(int? contractorId)
        {
            this.Vehicle.ContractorId = contractorId;
            return this;
        }
       
        public static RegisterVehicleViewModel Empty()
        {
            return new RegisterVehicleViewModel()
            {
                Vehicle = new Vehicle()
                {
                    Id = default,
                    ContractorId = default,
                    Model = string.Empty,
                    RegistrationNumber = string.Empty,
                    Type = string.Empty,
                    Weight = 0,
                }
            };
        }
    }
}
