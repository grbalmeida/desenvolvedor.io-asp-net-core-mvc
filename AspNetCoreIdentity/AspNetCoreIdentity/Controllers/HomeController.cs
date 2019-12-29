using System;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using AspNetCoreIdentity.Extensions;
using KissLog;

namespace AspNetCoreIdentity.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger _logger;

        public HomeController(ILogger logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            _logger.Trace("User accessed homepage");
            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            _logger.Trace("The user accessed the page about");
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Route("contact")]
        public IActionResult Contact()
        {
            _logger.Trace("User accessed contact page");
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [Route("privacy")]
        public IActionResult Privacy()
        {
            _logger.Trace("User accessed privacy page");
            throw new Exception("Error");
            // return View();
        }

        [Authorize(Roles = "Admin, Manager")]
        [Route("secret")]
        public IActionResult Secret()
        {
            _logger.Warn("User accessed secret page");
            return View();
        }

        [Authorize(Policy = "CanDelete")]
        public IActionResult SecretClaim()
        {
            return View("Secret");
        }

        [Authorize(Policy = "CanWrite")]
        public IActionResult SecretClaimWrite()
        {
            return View("Secret");
        }

        [ClaimAuthorize("Products", "Read")]
        public IActionResult ProductsRead()
        {
            return View("Secret");
        }

        [ClaimAuthorize("Products", "Add")]
        public IActionResult ProductsAdd()
        {
            return View("Secret");
        }

        [ClaimAuthorize("Products", "Edit")]
        public IActionResult ProductsEdit()
        {
            return View("Secret");
        }

        [ClaimAuthorize("Products", "Delete")]
        public IActionResult ProductsDelete()
        {
            return View("Secret");
        }

        [Route("error/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            _logger.Error("An error has occurred");
            var errorModel = new ErrorViewModel();

            if (id == 500)
            {
                errorModel.Message = "An error has occurred! Please try again later or contact our suport.";
                errorModel.Message = "An error has occurred!";
                errorModel.ErrorCode = id;
            }
            else if (id == 404)
            {
                errorModel.Message = "The page you are looking for does not exist! <br />For questions please contact our support";
                errorModel.Title = "Oops! Page not found.";
                errorModel.ErrorCode = id;
            }
            else if (id == 403)
            {
                errorModel.Message = "You are not allowed to do this.";
                errorModel.Title = "Access denied";
                errorModel.ErrorCode = id;
            }
            else
            {
                return StatusCode(id);
            }

            return View("Error", errorModel);
        }
    }
}
