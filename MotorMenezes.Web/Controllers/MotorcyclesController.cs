using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotorMenezes.Domain.Aggregates.MotorcycleAgg.Dtos;
using MotorMenezes.Domain.Aggregates.MotorcycleAgg.Entities;
using MotorMenezes.Domain.Aggregates.MotorcycleAgg.Interfaces;
using MotorMenezes.Domain.Aggregates.MotorcycleAgg.Requests;
using MotorMenezes.Domain.Aggregates.RentalAgg.Entities;
using MotorMenezes.Domain.Common.Dtos;
using MotorMenezes.Web.Models.ViewModels.MotorcyclesViewModel;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Linq;
using System.Threading.Tasks;

namespace MotorMenezes.Web.Controllers
{
    [Authorize]
    public class MotorcyclesController : BaseController
    {
        public readonly IMotorcycleServices _motorcycleServices;
        private readonly IMapper _mapper;

        public MotorcyclesController(
            IMotorcycleServices motorcycleServices,
            IMapper mapper)
        {
            _motorcycleServices = motorcycleServices;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> List(FilterMotorcycleDto filterMotorcycleDto)
        {
            var viewModel = new MotorcyclesListViewModel
            {
                FilterMotorcycleDto = filterMotorcycleDto,
                MotorcycleList = await _motorcycleServices.GetList(filterMotorcycleDto)
            };

            return View(viewModel);
        }

        [HttpGet]
        [Route("[controller]/CreateOrEdit")]
        [Route("[controller]/CreateOrEdit/{id}")]
        public async Task<IActionResult> CreateOrEdit(int id)
        {
            var viewModel = new MotorcycleCreateOrEditViewModel();

            if (id > 0)
                viewModel = _mapper.Map<MotorcycleCreateOrEditViewModel>(await _motorcycleServices.GetById(id));

            return View(viewModel);
        }
        
        [HttpPost]
        [Route("[controller]/CreateOrEdit")]
        public async Task<IActionResult> CreateOrEdit(CreateOrEditMotorcycleRequest request)
        {
            var response = new ResponseCreateDto<Motorcycle>();

            if(request.Id > 0)
                response = await _motorcycleServices.Update(request);
            else
                response = await _motorcycleServices.SendMessageAdd(request);

            if (!response.ValidationResult.IsValid)
                return BadRequest(response.ValidationResult.Errors.FirstOrDefault().ErrorMessage);

            return Ok("/Motorcycles");        
        }

        [HttpDelete]
        [Route("[controller]/Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _motorcycleServices.Delete(id);

            return Ok("/Motorcycles");
        }
    }
}
