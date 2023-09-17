using SizananiLogistics.Infrastructure.Models;

namespace SizananiLogistics.Infrastructure
{
    public interface IVehicleRepository
    {
        Vehicle? GetById(int id);
        Vehicle[] GetAllVehicles();
        Vehicle[] GetVehiclesByContractorId(int contractorId);
        void Insert(Vehicle vehicle);
        void Update(Vehicle vehicle);
        void Delete(int id);
    }
}
