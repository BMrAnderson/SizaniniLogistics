using SizananiLogistics.Application.Extensions;
using SizananiLogistics.Application.Extensions.Mappers;
using SizananiLogistics.Application.Models;
using SizananiLogistics.Infrastructure;

namespace SizananiLogistics.Application.Implementation
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicle;

        public VehicleService(IVehicleRepository vehicle)
        {
            _vehicle = vehicle;
        }

        public VehicleResult Get(VehicleRequest request)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            var vehicle = _vehicle.GetById(request.Id);
            if (vehicle == null)
            {
                throw new InvalidOperationException($"Vehicle with Id: [{request.Id}] could not be found. Please try again.");
            }
            return vehicle.ToResult();
        }

        public IReadOnlyCollection<VehicleResult> GetAllVehicles()
        {
            return _vehicle
                .GetAllVehicles()
                .Select(x => x.ToResult())
                .ToArray();
        }

        public IReadOnlyCollection<VehicleResult> GetVehiclesForContractor(VehiclesForContractorRequest vehiclesRequest)
        {
            ArgumentNullException.ThrowIfNull(vehiclesRequest, nameof(vehiclesRequest));
            
            return _vehicle
                .GetVehiclesByContractorId(vehiclesRequest.ContractorId)
                .Select(vehicle => vehicle.ToResult())
                .ToArray(); 
        }

        public void Register(RegisterVehicleRequest registerRequest)
        {
            ArgumentNullException.ThrowIfNull(registerRequest, nameof(registerRequest));

            _vehicle.Insert(registerRequest.ToVehicle());
        }

        public void Remove(RemoveVehicleRequest removeRequest)
        {
            ArgumentNullException.ThrowIfNull(removeRequest, nameof(removeRequest));

            _vehicle.Delete(removeRequest.Id);
        }

        public void Update(UpdateVehicleRequest updateRequest)
        {
            ArgumentNullException.ThrowIfNull(updateRequest, nameof(updateRequest));

            _vehicle.Update(updateRequest.ToVehicle());
        }
    }
}
