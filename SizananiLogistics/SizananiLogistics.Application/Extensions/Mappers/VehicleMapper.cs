using SizananiLogistics.Application.Models;
using Vehicle = SizananiLogistics.Infrastructure.Models.Vehicle;

namespace SizananiLogistics.Application.Extensions.Mappers
{
    public static class VehicleMapper
    {
        public static VehicleResult ToResult(this Vehicle vehicle)
        {
            var result = new VehicleResult()
            {
                Id = vehicle.Id,
                ContractorId = vehicle.ContractorId,
                Model = vehicle.Model,
                RegistrationNumber = vehicle.RegistrationNumber,
                Type = vehicle.Type,
                Weight = vehicle.Weight,
            };
            return result;
        }

        public static Vehicle ToVehicle(this RegisterVehicleRequest request)
        {
            var vehicle = new Vehicle()
            {
                Id = default,
                ContractorId = request.Vehicle.ContractorId,
                Model = request.Vehicle.Model,
                RegistrationNumber = request.Vehicle.RegistrationNumber,
                Type = request.Vehicle.Type,
                Weight = request.Vehicle.Weight,
            };
            return vehicle;
        }

        public static Vehicle ToVehicle(this UpdateVehicleRequest request)
        {
            var vehicle = new Vehicle()
            {
                Id = request.Id,
                ContractorId = request.Vehicle.ContractorId,
                Model = request.Vehicle.Model,
                RegistrationNumber = request.Vehicle.RegistrationNumber,
                Type = request.Vehicle.Type,
                Weight = request.Vehicle.Weight,
            };
            return vehicle;
        }
    }
}
