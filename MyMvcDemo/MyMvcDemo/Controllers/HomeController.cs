using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcDemo.Models;

namespace MyMvcDemo.Controllers
{
    [Route("")]
    [Route("customer-management")]
    public class HomeController : Controller
    {
        [Route("")]
        [Route("home-page")]
        [Route("home-page/{id:int}/{category:guid}")]
        public IActionResult Index(int id, Guid category)
        {
            return View();
        }

        [Route("about")]
        [Route("about-us")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Route("contact")]
        [Route("contact-us")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [Route("privacy")]
        [Route("privacy-terms")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
