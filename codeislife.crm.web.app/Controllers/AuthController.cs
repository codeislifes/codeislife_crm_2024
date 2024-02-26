using codeislife.crm.web.app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace codeislife.crm.web.app.Controllers;

public class AuthController : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    public AuthController
    (
        SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager
    )
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        return RedirectToAction("Login");
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View(new LoginModel());
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(string returnUrl, LoginModel model)
    {
        var identity = await _userManager.FindByNameAsync(model.Username);
        var signInResult = await _signInManager.PasswordSignInAsync(identity, model.Password, true, true);

        if (signInResult.Succeeded)
        {
            if(!string.IsNullOrEmpty(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction("Index", "Home");
        }
        else
        {
            ModelState.AddModelError("SigninNot", "Kullanıcı adı veya şifreniz yanlış");
        }
        return View();
    }

    [AllowAnonymous]
    public IActionResult Register()
    {
        return View();
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        var identity = new IdentityUser
        {
            Email = model.Email,
            UserName = model.Email,
            PhoneNumber = model.PhoneNumber,
            PhoneNumberConfirmed = true,
            EmailConfirmed = true,
            NormalizedEmail = model.Email.ToUpper(new System.Globalization.CultureInfo("tr-TR")),
            NormalizedUserName = model.Email.ToUpper(new System.Globalization.CultureInfo("tr-TR"))
        };

        var user = await _userManager.CreateAsync(identity, model.Password);

        if (user.Succeeded)
        {
            var result = await _signInManager.PasswordSignInAsync(identity, model.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
        }
        return View();
    }

    [HttpGet]
    [Authorize]
    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }
}
