using exam.business.ViewModels;
using exam.core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace exam.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser>userManager,
                                 SignInManager<AppUser>signInManager)
        {
            _userManager = userManager;
           _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginvm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser admin = null;
            if(admin is null)
            {
                ModelState.AddModelError("", "Username or password incorrect");
                return View(loginvm);
            }
            var result = await _signInManager.PasswordSignInAsync(admin, loginvm.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "UserName or password is incorrect");
                return View(loginvm);
            }
            return RedirectToAction("Index", "blog");
        }
    }
}
