using Microsoft.AspNetCore.Mvc;

namespace DevIO.ModelApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
