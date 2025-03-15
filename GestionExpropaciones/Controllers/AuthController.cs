using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionExpropaciones.Controllers;

public class AuthController : Controller
{
    [AllowAnonymous]
    public IActionResult Login()
    {
        return Challenge(new AuthenticationProperties { RedirectUri = "/" }, GoogleDefaults.AuthenticationScheme);
    }

    [Authorize]
    public async Task<IActionResult> Logout()
    {
        return SignOut(new AuthenticationProperties { RedirectUri = "/Auth/Login" }, CookieAuthenticationDefaults.AuthenticationScheme);
    }

    [AllowAnonymous]
    public IActionResult AccessDenied()
    {
        return View();
    }

    [Authorize]
    public IActionResult UserInfo()
    {
        return Json(new { Name = User.Identity.Name, IsAuthenticated = User.Identity.IsAuthenticated });
    }
}