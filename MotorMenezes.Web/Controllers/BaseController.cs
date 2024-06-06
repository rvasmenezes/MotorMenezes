using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MotorMenezes.Web.Controllers
{

    public class BaseController : Controller
    {
        public BaseController() { }

        public string UsuarioLogadoId
            => User.FindFirstValue(ClaimTypes.NameIdentifier);

        public string RoleUsuarioLogado
            => User.FindFirstValue(ClaimTypes.Role);
    }
}
