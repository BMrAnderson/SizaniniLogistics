using Microsoft.AspNetCore.Mvc;
using SizananiLogistics.Application;
using SizananiLogistics.Web.Extensions;
using SizananiLogistics.Web.Models;

namespace SizananiLogistics.Web.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;
        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public IActionResult Index(int? contractorId)
        {
            return View(RegisterVehicleViewModel.Empty().WithVehicleContractor(contractorId));
        }

        public IActionResult List(int contractorId)
        {
            var vehicles = _vehicleService.GetVehiclesForContractor(new Application.Models.VehiclesForContractorRequest() { ContractorId = contractorId });

            return View(vehicles.ToViewModel());
        }

        [HttpGet]
        public IActionResult Edit(int vehicleId)
        {
            var vehicle = _vehicleService.Get(new Application.Models.VehicleRequest() { Id = vehicleId });

            return View(vehicle.ToViewModel());
        }

        [HttpPost]
        public IActionResult Edit(EditVehicleViewModel viewModel)
        {
            _vehicleService.Update(viewModel.ToRequest());

            return List(viewModel.Vehicle.ContractorId.GetValueOrDefault());
        }
  
        public IActionResult Delete(int vehicleId)
        {
            var vehicle = _vehicleService.Get(new Application.Models.VehicleRequest() { Id =vehicleId });

            _vehicleService.Remove(new Application.Models.RemoveVehicleRequest() { Id = vehicleId });

            return List(vehicle.ContractorId.GetValueOrDefault());
        }

        [HttpPost]
        public IActionResult Register(RegisterVehicleViewModel viewModel)
        {
            _vehicleService.Register(viewModel.ToRequest());

            return List(viewModel.Vehicle.ContractorId.GetValueOrDefault());
        }

       
    }
}
