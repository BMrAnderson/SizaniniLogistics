using SizananiLogistics.Application.Models;
using SizananiLogistics.Web.Models;

namespace SizananiLogistics.Web.Extensions
{
    public static class VehicleMapper
    {
        public static EditVehicleViewModel ToViewModel(this VehicleResult result)
        {
            var viewModel = new EditVehicleViewModel()
            {
                Vehicle = result.ToVehicle(),
            };
            return viewModel;
        }

        public static VehicleListViewModel ToViewModel(this IEnumerable<VehicleResult> results)
        {
            var viewModel = new VehicleListViewModel()
            {
                Vehicles = results.Select(vehicle => vehicle.ToVehicle()).ToList(),
            };
            return viewModel;
        }

        public static UpdateVehicleRequest ToRequest(this EditVehicleViewModel viewModel)
        {
            var request = new UpdateVehicleRequest()
            {
                Id = viewModel.Vehicle.Id.GetValueOrDefault(),
                Vehicle = new Application.Models.Vehicle()
                {
                    ContractorId = viewModel.Vehicle.ContractorId,
                    Model = viewModel.Vehicle.Model,
                    RegistrationNumber = viewModel.Vehicle.RegistrationNumber,
                    Type = viewModel.Vehicle.Type,
                    Weight = viewModel.Vehicle.Weight,
                }
            };
            return request;
        }

        public static RegisterVehicleRequest ToRequest(this RegisterVehicleViewModel viewModel)
        {
            var request = new RegisterVehicleRequest()
            {
                Vehicle = new Application.Models.Vehicle()
                {
                    ContractorId = viewModel.Vehicle.ContractorId,
                    Model = viewModel.Vehicle.Model,
                    RegistrationNumber = viewModel.Vehicle.RegistrationNumber,
                    Type = viewModel.Vehicle.Type,
                    Weight = viewModel.Vehicle.Weight
                }
            };
            return request;
        }

        public static Models.Vehicle ToVehicle(this VehicleResult vehicleResult)
        {
            var vehicle = new Models.Vehicle()
            {
                Id = vehicleResult.Id,
                ContractorId = vehicleResult.ContractorId,
                Model = vehicleResult.Model,
                RegistrationNumber = vehicleResult.RegistrationNumber,
                Type = vehicleResult.Type,
                Weight = vehicleResult.Weight,
            };
            return vehicle; 
        }
    }
}
