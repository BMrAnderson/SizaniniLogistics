using Microsoft.AspNetCore.Mvc;
using SizananiLogistics.Application;
using SizananiLogistics.Web.Extensions;

namespace SizananiLogistics.Web.Controllers
{
    public class SummaryController : Controller
    {
        private readonly IVehicleContractorSummaryService _vehicleContractorSummaryService;

        public SummaryController(IVehicleContractorSummaryService vehicleContractorSummaryService)
        {
            _vehicleContractorSummaryService = vehicleContractorSummaryService;
        }

        public IActionResult Index() => View(_vehicleContractorSummaryService.GetSummary().ToViewModel());
    }
}
