using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotorMenezes.Core.Helpers;
using MotorMenezes.Domain.Aggregates.MotorcycleAgg.Dtos;
using MotorMenezes.Domain.Aggregates.MotorcycleAgg.Entities;
using MotorMenezes.Domain.Aggregates.MotorcycleAgg.Interfaces;
using MotorMenezes.Domain.Aggregates.MotorcycleAgg.Requests;
using MotorMenezes.Domain.Common.Dtos;
using MotorMenezes.Web.Models.ViewModels.MotorcyclesViewModel;
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
        public async Task<IActionResult> CreateOrEdit(string id)
        {
            var viewModel = new MotorcycleCreateViewModel();
            
            if (!string.IsNullOrEmpty(id))
                viewModel = _mapper.Map<MotorcycleCreateViewModel>(await _motorcycleServices.GetById(id));

            viewModel.YearList = Utilidades.GerarListaAnos(50);

            return View(viewModel);
        }
        
        [HttpPost]
        [Route("[controller]/Create")]
        public async Task<IActionResult> Create(MotorcycleCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var response = new ResponseCreateDto<Motorcycle>();
                var request = _mapper.Map<CreateOrEditMotorcycleRequest>(viewModel);

                    response = await _motorcycleServices.SendMessageAdd(request);

                if (!response.ValidationResult.IsValid)
                    return BadRequest(response.ValidationResult.Errors.FirstOrDefault().ErrorMessage);

                return Ok("/Motorcycles");
            }

            var modelErrors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return BadRequest(string.Join("<br>", modelErrors));
        }

        [HttpPost]
        [Route("[controller]/Edit")]
        public async Task<IActionResult> Edit(MotorcycleEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var response = new ResponseCreateDto<Motorcycle>();
                var request = _mapper.Map<CreateOrEditMotorcycleRequest>(viewModel);

                response = await _motorcycleServices.Update(request);

                if (!response.ValidationResult.IsValid)
                    return BadRequest(response.ValidationResult.Errors.FirstOrDefault().ErrorMessage);

                return Ok("/Motorcycles");
            }

            var modelErrors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return BadRequest(string.Join("<br>", modelErrors));
        }

        [HttpDelete]
        [Route("[controller]/Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            await _motorcycleServices.Delete(id);

            return Ok("/Motorcycles");
        }
    }
}
