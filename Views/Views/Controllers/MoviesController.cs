using Microsoft.AspNetCore.Mvc;

namespace Views.Controllers
{
    public class MoviesController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}
