using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotorMenezes.Core.ApplicationContext;
using MotorMenezes.Core.AWS.Interfaces;
using MotorMenezes.Core.Helpers;
using MotorMenezes.Domain.Aggregates.UserAgg.Dtos;
using MotorMenezes.Domain.Aggregates.UserAgg.Entities;
using MotorMenezes.Domain.Aggregates.UserAgg.Enums;
using MotorMenezes.Domain.Aggregates.UserAgg.Interfaces;
using MotorMenezes.Domain.Aggregates.UserAgg.Requests;
using MotorMenezes.Domain.Aggregates.UserAgg.Responses;
using MotorMenezes.Domain.Common.Dtos;
using MotorMenezes.Domain.Common.Validators;
using MotorMenezes.Domain.Interfaces;

namespace MotorMenezes.Domain.Aggregates.UserAgg.Services
{
    public class UserServices : IUserServices
    {
        protected readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMotorMenezesContext _MotorMenezesContext;
        private readonly IS3Services _s3Services;
        private readonly GlobalVariables _globalVariables;
        private readonly IMapper _mapper;

        public UserServices(
            IUnitOfWork unitOfWork,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IMotorMenezesContext MotorMenezesContext,
            IS3Services s3Services,
            GlobalVariables globalVariables,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _signInManager = signInManager;
            _MotorMenezesContext = MotorMenezesContext;
            _s3Services = s3Services;
            _globalVariables = globalVariables;
            _mapper = mapper;
        }

        public async Task<User?> ObterPorId(string id)
            => await _unitOfWork.UsuarioRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<ResponseCreateDto<LoginResponse>> EfetuarLogin(LoginRequest request)
        {
            var response = new ResponseCreateDto<LoginResponse>();
            var loginResponse = new LoginResponse();

            var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, request.RememberMe, false);

            if (!result.Succeeded)
            {
                response.AddWarningValidation(ConstantMessages.EMAIL_OU_SENHA_INVALIDOS);
                return response;
            }

            var user = await _unitOfWork.UsuarioRepository.GetAll().Where(x => x.Email == request.Email).FirstAsync();

            loginResponse.Rota = ConstantMessages.ROUTE_MOTORCYCLE;
    
            if (await _userManager.IsInRoleAsync(user, ProfileEnum.Motorcyclist.ToString()))
                loginResponse.Rota = ConstantMessages.ROUTE_ACCOUNT;

            loginResponse.UserId = user.Id;
            loginResponse.UserEmail = user.Email;
            loginResponse.UserName = user.Name;

            response.Entity = loginResponse;

            return response;
        }

        public async Task<ResponseCreateDto<LoginResponse>> Create(CreateUserRequest request)
        {
            var response = new ResponseCreateDto<LoginResponse>();

            var usuario = new User(request.Email!, request.Name!);

            var result = await _userManager.CreateAsync(usuario, request.Password!);

            if (result.Succeeded)
                await _userManager.AddToRoleAsync(usuario, ProfileEnum.Motorcyclist.ToString());
            else
                response.AddWarningValidation(string.Join("<br>", result.Errors.Select(x => x.Description)));

            return response;
        }

        public async Task<UserDto> GetProfile()
            => _mapper.Map<UserDto>(await ObterPorId(_MotorMenezesContext.UserLoggedId));

        public async Task<ResponseCreateDto<UserRequest>> Update(UserRequest request)
        {
            var response = new ResponseCreateDto<UserRequest>();

            var usuario = await ObterPorId(_MotorMenezesContext.UserLoggedId);

            var cnpj = request?.CNPJ?.Replace(".", "").Replace("/", "").Replace("-", "").Replace(" ", "");

            if(await _unitOfWork.UsuarioRepository.GetAll()
                .AnyAsync(x => x.CNPJ == cnpj && x.Id != _MotorMenezesContext.UserLoggedId))
            {
                response.AddWarningValidation("CNPJ já está cadastrado!");
                return response;
            }

            if (await _unitOfWork.UsuarioRepository.GetAll()
                .AnyAsync(x => x.CNHNumber == request!.CNHNumber && x.Id != _MotorMenezesContext.UserLoggedId))
            {
                response.AddWarningValidation("Número da CNH já está cadastrado!");
                return response;
            }

            if (request?.Archive != null)
            {
                var extension = Path.GetExtension(request.Archive.FileName).ToLowerInvariant();
                if (extension != ".bmp" && extension != ".png")
                {
                    response.AddWarningValidation("É permitido arquivos somente com extensões .png e .bmp");
                    return response;
                }

                var uniqueFileName = usuario!.Id + ".jpg";
                string pastaCompleta = Path.Combine(_globalVariables.S3UploadPahCNH, uniqueFileName).Replace(@"\", @"/");

                using (var stream = new MemoryStream())
                {
                    await request.Archive.CopyToAsync(stream);
                    stream.Position = 0;
                    await _s3Services.Upload(_globalVariables.S3BucketExterno, pastaCompleta, stream);
                    stream.Flush();
                }

                usuario.PossuiImagem = true;
            }
            else if (request?.Archive == null && !usuario!.PossuiImagem)
            {
                response.AddWarningValidation("Foto da CNH é obrigatória");
                return response;
            }

            usuario!.BirthDate = request?.BirthDate!.Value.ToUniversalTime();
            usuario.Name = request.Name;
            usuario.CNPJ = cnpj;
            usuario.CNHNumber = request.CNHNumber;
            usuario.CNHTypeId = request.CNHTypeId;

            var result = await _userManager.UpdateAsync(usuario);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    response.AddWarningValidation(error.Description);
                    return response;
                }
            }

            await _signInManager.RefreshSignInAsync(usuario);

            return response;
        }

        public async Task<ResponseCreateDto<FileStreamResult>> DownloadPorId(string id)
        {
            var response = new ResponseCreateDto<FileStreamResult>();

            if (string.IsNullOrEmpty(id))
            {
                response.AddWarningValidation(ConstantMessages.PARAMETROS_INVALIDOS);
                return response;
            }

            var user = await ObterPorId(id);

            string file = Path.Combine(_globalVariables.S3UploadPahCNH, user.Id.ToString() + ".jpg").Replace(@"\", @"/");

            if (!await _s3Services.FileExists(_globalVariables.S3BucketExterno, file))
            {
                response.AddWarningValidation(ConstantMessages.ARQUIVO_NAO_ENCONTRADO);
                return response;
            }

            Stream stream = await _s3Services.Download(_globalVariables.S3BucketExterno, file);

            stream.Position = 0;

            response.Entity = new FileStreamResult(stream, "application/octet-stream")
            {
                FileDownloadName = "CNH.jpg"
            };

            return response;
        }
    }
}
