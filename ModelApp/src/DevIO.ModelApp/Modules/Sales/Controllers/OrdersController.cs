using Microsoft.AspNetCore.Mvc;

namespace DevIO.ModelApp.Modules.Sales.Controllers
{
    [Area("Sales")]
    [Route("orders")]
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}