using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MF.CookieAuthenticationWithoutIdentity01.Mvc.Controllers
{
    [Authorize]
    public class SomenteLogadoController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}
