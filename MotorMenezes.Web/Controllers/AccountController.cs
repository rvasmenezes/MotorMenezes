using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MotorMenezes.Domain.Aggregates.CNHTypeAgg.Interfaces;
using MotorMenezes.Domain.Aggregates.UserAgg.Entities;
using MotorMenezes.Domain.Aggregates.UserAgg.Interfaces;
using MotorMenezes.Domain.Aggregates.UserAgg.Requests;
using MotorMenezes.Domain.Aggregates.UserAgg.Responses;
using MotorMenezes.Infra.Log.Filters;
using MotorMenezes.Web.Models.ViewModels.AccountViewModel;
using System.Linq;
using System.Threading.Tasks;

namespace MotorMenezes.Web.Controllers
{

    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        public readonly IConfiguration _configuration;
        public readonly IUserServices _userServices;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICNHTypeServices _cNHTypeServices;
        private readonly IMapper _mapper;

        public AccountController(
            SignInManager<User> signInManager,
            IConfiguration configuration,
            IUserServices userServices,
            IHttpContextAccessor httpContextAccessor,
            ICNHTypeServices cNHTypeServices,
            IMapper mapper)
        {
            _signInManager = signInManager;
            _configuration = configuration;
            _userServices = userServices;
            _httpContextAccessor = httpContextAccessor;
            _cNHTypeServices = cNHTypeServices;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Register()
            => View();

        [HttpPost]
        [Route("[controller]/Register")]
        public async Task<IActionResult> Register(CreateUserRequest request)
        {
            if (ModelState.IsValid)
            {
                var response = await _userServices.Create(request);

                if (!response.ValidationResult.IsValid)
                    return BadRequest(response.ValidationResult.Errors.FirstOrDefault().ErrorMessage);

                return Ok("/Account/RegisterSuccess");
            }

            return BadRequest("Preencha os campos corretamente!");
        }

        [HttpGet]
        public IActionResult RegisterSuccess()
            => View();

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult Login()
            => View();

        [HttpPost]
        [OvershadowFieldsLog("Password")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (ModelState.IsValid)
            {
                var response = await _userServices.EfetuarLogin(request);

                if (!response.ValidationResult.IsValid)
                    return BadRequest(response.ValidationResult.Errors.FirstOrDefault().ErrorMessage);

                var loginResponse = response.Entity as LoginResponse;

                _httpContextAccessor.HttpContext.Session.SetString("UserName", loginResponse.UserName);

                return Ok(loginResponse.Rota);
            }

            return BadRequest("Login Inválido!");
        }

        [HttpGet]
        [Route("[controller]")]
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var viewModel = _mapper.Map<ProfileViewModel>(await _userServices.GetProfile());

            viewModel.CNHTypeList = await _cNHTypeServices.GetList();

            return View(viewModel);
        }

        [HttpPost]
        [Route("[controller]")]
        [Authorize]
        public async Task<IActionResult> Profile(UserRequest request)
        {
            if (ModelState.IsValid)
            {
                var response = await _userServices.Update(request);

                if (!response.ValidationResult.IsValid)
                    return BadRequest(response.ValidationResult.Errors.FirstOrDefault().ErrorMessage);

                return Ok();
            }

            return BadRequest("Preencha os campos corretamente!");
        }

        [HttpPost]
        [Route("[controller]/DownloadCNH/{id}")]
        [Authorize]
        public async Task<IActionResult> Download(string id)
        {
            var response = await _userServices.DownloadPorId(id);

            if (!response.ValidationResult.IsValid)
                return BadRequest(response.ValidationResult.Errors.FirstOrDefault().ErrorMessage);

            return response.Entity as FileStreamResult;
        }
    }
}
