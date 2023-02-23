using Microsoft.AspNetCore.Mvc;

namespace CarsTestTask.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
    }
}
