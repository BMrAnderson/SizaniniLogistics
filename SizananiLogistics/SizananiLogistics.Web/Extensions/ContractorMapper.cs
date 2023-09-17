using SizananiLogistics.Application.Models;
using SizananiLogistics.Web.Models;

namespace SizananiLogistics.Web.Extensions
{
    public static class ContractorMapper
    {
        public static RegisterContractorRequest ToRequest(this RegisterContractorViewModel viewModel)
        {
            var request = new RegisterContractorRequest()
            {
                Contractor = new Application.Models.Contractor()
                {
                    EmailAddress = viewModel.Contractor.EmailAddress,
                    Name = viewModel.Contractor.Name,
                    PhoneNumber = viewModel.Contractor.PhoneNumber,
                }
            };
            return request;
        }

        public static ContractorDetailsViewModel ToViewModel(this IEnumerable<ContractorResult> contractors, ContractorResult? selectedContractor = null, IEnumerable<VehicleResult>? contractorVehicles = null)
        {
            var viewModel = new ContractorDetailsViewModel()
            {
                ContractorsDictionary = contractors.ToContractorDictionary(),
                SelectedContractor = selectedContractor?.ToContractorModel(contractorVehicles ?? Array.Empty<VehicleResult>()),
            };
            return viewModel;
        }

        private static IReadOnlyDictionary<int, string> ToContractorDictionary(this IEnumerable<ContractorResult> contractors)
        {
            return contractors.ToDictionary(k =>  k.Id, v => v.Name);
        }

        private static Models.Contractor ToContractorModel(this ContractorResult contractorResult, IEnumerable<VehicleResult> vehicles)
        {
            var contractor = new Models.Contractor()
            {
                Id = contractorResult.Id,
                Name = contractorResult.Name,
                EmailAddress = contractorResult.EmailAddress,
                PhoneNumber = contractorResult.PhoneNumber,
                Vehicles = vehicles.Select(vehicle => vehicle.ToVehicle()).ToList(),
            };
            return contractor;
        }
    }
}
