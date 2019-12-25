using DevIO.ModelApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.ModelApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public HomeController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IActionResult Index([FromServices] IOrderRepository _orderRepository2)
        {
            var order = _orderRepository.GetOrder();
            var order2 = _orderRepository2.GetOrder();
            return View();
        }
    }
}
