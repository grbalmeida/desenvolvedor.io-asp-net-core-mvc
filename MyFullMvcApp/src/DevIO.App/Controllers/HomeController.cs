using System.Net;
using DevIO.App.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("error/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var errorModel = new ErrorViewModel();

            if (id == (int)HttpStatusCode.InternalServerError)
            {
                errorModel.Message = "An error has occurred! Please try again later or contact our suport.";
                errorModel.Message = "An error has occurred!";
                errorModel.ErrorCode = id;
            }
            else if (id == (int)HttpStatusCode.NotFound)
            {
                errorModel.Message = "The page you are looking for does not exist! <br />For questions please contact our support";
                errorModel.Title = "Oops! Page not found.";
                errorModel.ErrorCode = id;
            }
            else if (id == (int)HttpStatusCode.Forbidden)
            {
                errorModel.Message = "You are not allowed to do this.";
                errorModel.Title = "Access denied";
                errorModel.ErrorCode = id;
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

            return View("Error", errorModel);
        }
    }
}
