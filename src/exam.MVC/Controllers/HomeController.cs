using Microsoft.AspNetCore.Mvc;

namespace exam.MVC.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            return View();
        }

       
    }
}