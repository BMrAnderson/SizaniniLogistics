using SizananiLogistics.Application.Models;

namespace SizananiLogistics.Application
{
    public interface IVehicleService
    {
        VehicleResult Get(VehicleRequest request);
        IReadOnlyCollection<VehicleResult> GetAllVehicles();
        IReadOnlyCollection<VehicleResult> GetVehiclesForContractor(VehiclesForContractorRequest vehiclesRequest);
        void Register(RegisterVehicleRequest registerRequest);
        void Update(UpdateVehicleRequest updateRequest);
        void Remove(RemoveVehicleRequest removeRequest);
    }
}
