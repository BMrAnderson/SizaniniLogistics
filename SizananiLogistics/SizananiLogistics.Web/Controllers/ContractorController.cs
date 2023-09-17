using Microsoft.AspNetCore.Mvc;
using SizananiLogistics.Application;
using SizananiLogistics.Web.Extensions;
using SizananiLogistics.Web.Models;

namespace SizananiLogistics.Web.Controllers
{
    public class ContractorController : Controller
    {
        private readonly IContractorService _contractorService;
        private readonly IVehicleService _vehicleService;

        public ContractorController(IContractorService contractorService, IVehicleService vehicleService)
        {
            _contractorService = contractorService;
            _vehicleService = vehicleService;
        }

        public IActionResult Index() => View(RegisterContractorViewModel.Empty());

        public IActionResult Details() => View(_contractorService.GetAll().ToViewModel());

        [HttpPost]
        public IActionResult Details(int contractorId)
        {
            var contractor = _contractorService.Get(new Application.Models.ContractorRequest() { Id = contractorId });
        
            var vehicles = _vehicleService.GetVehiclesForContractor(new Application.Models.VehiclesForContractorRequest() { ContractorId = contractorId });
            
            var allContractors = _contractorService.GetAll();

            return View(allContractors.ToViewModel(contractor, vehicles));
        }

        [HttpPost]
        public IActionResult Register(RegisterContractorViewModel viewModel)
        {
            _contractorService.Register(viewModel.ToRequest());

            return Details();
        }
    }
}
