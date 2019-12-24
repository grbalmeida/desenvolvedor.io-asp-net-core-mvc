using Microsoft.AspNetCore.Mvc;

namespace DevIO.ModelApp.Module.Products.Controllers
{
    [Area("Products")]
    [Route("products")]
    public class RegisterController : Controller
    {
        [Route("list")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("search")]
        public IActionResult Search()
        {
            return View();
        }
    }
}