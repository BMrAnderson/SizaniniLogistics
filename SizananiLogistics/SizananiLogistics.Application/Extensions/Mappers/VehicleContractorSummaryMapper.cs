using SizananiLogistics.Application.Models;
using SizananiLogistics.Infrastructure.Models;

namespace SizananiLogistics.Application.Extensions.Mappers
{
    public static class VehicleContractorSummaryMapper
    {
        public static VehicleContractorSummaryResult ToResult(this VehicleContractorSummary summary)
        {
            var result = new VehicleContractorSummaryResult()
            {
                ContractorName = summary.ContractorName,
                TotalVehiclesAssigned = summary.TotalVehicles,
                TotalWeightInTonsOfVehiclesAssigned = summary.TotalWeight
            };
            return result;
        }

    }
}
