using SizananiLogistics.Application.Models;
using SizananiLogistics.Web.Models;

namespace SizananiLogistics.Web.Extensions
{
    public static class SummaryMapper
    {
        public static VehicleContractorSummaryViewModel ToViewModel(this IEnumerable<VehicleContractorSummaryResult> results)
        {
            var viewModel = new VehicleContractorSummaryViewModel()
            {
                VehicleContractorSummaries = results.ToSummary()
            };
            return viewModel;
        }

        private static IReadOnlyCollection<VehicleContractorSummary> ToSummary(this IEnumerable<VehicleContractorSummaryResult> results)
        {
            return results.Select(s => s.ToSummary()).ToList();
        }

        private static VehicleContractorSummary ToSummary(this VehicleContractorSummaryResult result)
        {
            var summary = new VehicleContractorSummary()
            {
                ContractorName = result.ContractorName,
                TotalVehicles = result.TotalVehiclesAssigned,
                TotalWeight = result.TotalWeightInTonsOfVehiclesAssigned
            };
            return summary;
        }
    }
}
