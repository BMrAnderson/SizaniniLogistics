using SizananiLogistics.Application.Models;

namespace SizananiLogistics.Application
{
    public interface IVehicleContractorSummaryService
    {
        IReadOnlyCollection<VehicleContractorSummaryResult> GetSummary();
    }
}
