using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using AspNetCoreIdentity.Extensions;

namespace AspNetCoreIdentity.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Route("contact")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [Route("privacy")]
        public IActionResult Privacy()
        {
            throw new Exception("Error");
            // return View();
        }

        [Authorize(Roles = "Admin, Manager")]
        [Route("secret")]
        public IActionResult Secret()
        {
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
