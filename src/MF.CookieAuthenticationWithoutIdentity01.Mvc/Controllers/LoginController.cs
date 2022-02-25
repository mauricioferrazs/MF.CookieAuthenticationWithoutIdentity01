using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using MF.CookieAuthenticationWithoutIdentity01.Mvc.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MF.CookieAuthenticationWithoutIdentity01.Mvc.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Logar()
        {
            return View("Logar");
        }

        [HttpPost]
        public async Task<IActionResult> Logar(LoginViewModel vmLogin)
        {
            if (!ModelState.IsValid)
            {
                return View(vmLogin);
            }

            if (vmLogin.Usuario.ToLower() != "Mauricio".ToLower())
            {
                ModelState.AddModelError(string.Empty, "Usuário ou senha inválidos");
                return View(vmLogin);
            }

            if (vmLogin.Senha.ToLower() != "123456".ToLower())
            {
                ModelState.AddModelError(string.Empty, "Usuário ou senha inválidos");
                return View(vmLogin);
            }

            var lstClaim = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, vmLogin.Usuario)
            };       

            var claimsIdentity =
                new ClaimsIdentity(lstClaim, CookieAuthenticationDefaults.AuthenticationScheme);

            var claimsPrincipal =
                new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Deslogar()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
