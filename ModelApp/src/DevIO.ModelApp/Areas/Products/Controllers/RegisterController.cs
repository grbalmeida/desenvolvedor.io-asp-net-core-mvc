using Microsoft.AspNetCore.Mvc;

namespace DevIO.ModelApp.Areas.Products.Controllers
{
    [Area("Products")]
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}