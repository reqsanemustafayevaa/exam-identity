using exam.core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace exam.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DashboardController(UserManager<AppUser>userManager
                                   ,RoleManager<IdentityRole>roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        //public async Task<IActionResult> CreateRole()
        //{
        //    var role1 = new IdentityRole("SuperAdmin");
        //    var role2 = new IdentityRole("Admin");
        //    var role3 = new IdentityRole("Member");
        //    await _roleManager.CreateAsync(role1);
        //    await _roleManager.CreateAsync(role2);
        //    await _roleManager.CreateAsync(role3);

        //    return Ok();
        //}
        //public async Task<IActionResult> CreateAdmin()
        //{
        //    var admin = new AppUser
        //    {
        //        FullName = "Reqsane Mustafayeva",
        //        UserName = "SuperAdmin"
        //    };
        //    await _userManager.CreateAsync(admin);
        //    await _userManager.AddToRoleAsync(admin, "SuperAdmin");
        //    return Ok();
        //}
        
    }
}
