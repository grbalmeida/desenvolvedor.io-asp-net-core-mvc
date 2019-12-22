using Microsoft.AspNetCore.Mvc;
using Views.Models;

namespace Views.Controllers
{
    public class MoviesController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Movie movie)
        {
            if (ModelState.IsValid)
            {

            }

            return View(movie);
        }
    }
}
