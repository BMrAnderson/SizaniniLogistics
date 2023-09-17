using SizananiLogistics.Infrastructure.Models;

namespace SizananiLogistics.Infrastructure
{
    public interface IVehicleContractorSummaryRepository
    {
        VehicleContractorSummary[] Get();
    }
}
