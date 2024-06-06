using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace MotorMenezes.Core.ApplicationContext
{
    public class MotorMenezesContext : IMotorMenezesContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MotorMenezesContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserLoggedId
        {
            get
            {
                var user = _httpContextAccessor?.HttpContext?.User;
                var nameIdentifier = user?.FindFirstValue(ClaimTypes.NameIdentifier);
                return nameIdentifier!;
            }
        }

        public string UserLoggedEmail
        {
            get
            {
                var user = _httpContextAccessor?.HttpContext?.User;
                var emailUsuarioLogado = user?.FindFirstValue(ClaimTypes.Email);
                return emailUsuarioLogado!;
            }
        }

        public string RoleUserLogged
        {
            get
            {
                var user = _httpContextAccessor?.HttpContext?.User;
                var roleClaim = user?.FindFirstValue(ClaimTypes.Role);
                return roleClaim!;
            }
        }

        public string? UserLoggedName
            => _httpContextAccessor?.HttpContext?.Session.GetString("UserName");
    }
}
