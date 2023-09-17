using SizananiLogistics.Application.Extensions.Mappers;
using SizananiLogistics.Application.Models;
using SizananiLogistics.Infrastructure;

namespace SizananiLogistics.Application.Implementation
{
    public class VehicleContractorSummaryService : IVehicleContractorSummaryService
    {
        private readonly IVehicleContractorSummaryRepository _contractorSummary;
        public VehicleContractorSummaryService(IVehicleContractorSummaryRepository contractorSummary)
        {
            _contractorSummary = contractorSummary;
        }

        public IReadOnlyCollection<VehicleContractorSummaryResult> GetSummary()
        {
            return _contractorSummary
                .Get()
                .Select(item => item.ToResult())
                .ToArray();
        }
    }
}
