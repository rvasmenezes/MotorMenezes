using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotorMenezes.Domain.Aggregates.PlanAgg.Interfaces;
using MotorMenezes.Domain.Aggregates.RentalAgg.Interfaces;
using MotorMenezes.Domain.Aggregates.RentalAgg.Requests;
using MotorMenezes.Web.Models.ViewModels.RentalViewModel;
using System.Linq;
using System.Threading.Tasks;

namespace MotorMenezes.Web.Controllers
{
    [Authorize]
    public class RentalsController : BaseController
    {
        public readonly IRentalServices _rentalServices;
        public readonly IPlanServices _planServices;

        public RentalsController(
            IRentalServices rentalServices,
            IPlanServices planServices)
        {
            _rentalServices = rentalServices;
            _planServices = planServices;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> List()
        {
            var viewModel = new RentalListViewModel
            {
                PlanList = await _planServices.GetList(),
                RentalList = await _rentalServices.GetList()
            };

            return View(viewModel);
        }

        [HttpGet]
        [Route("[controller]/Create")]
        public async Task<IActionResult> Create()
        {
            var viewModel = new CreateRentalRequest
            {
                PlanList = await _planServices.GetList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("[controller]/Calculate")]
        public async Task<IActionResult> Calculate(CalculateRequest request)
        {
            var response = await _rentalServices.Calculate(request);

            if (!response.ValidationResult.IsValid)
                return BadRequest(response.ValidationResult.Errors.FirstOrDefault().ErrorMessage);

            return Ok(response.Entity);        
        }

        [HttpPost]
        [Route("[controller]/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateRentalRequest request)
        {
            if (ModelState.IsValid)
            {
                await _rentalServices.Add(request);
                return Ok("/Rentals");
            }

            return BadRequest("Preencha os campos corretamente!");
        }
    }
}
