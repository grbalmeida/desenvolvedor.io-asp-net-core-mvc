using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace Models.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var movie = new Movie
            {
                Title = "Hi",
                ReleaseDate = DateTime.Now,
                Genre = null,
                Rating = 10,
                Price = 20000
            };

            return RedirectToAction(nameof(Privacy), movie);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy(Movie movie)
        {
            if (ModelState.IsValid)
            {
            
            }

            foreach (var error in ModelState.Values.SelectMany(m => m.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
