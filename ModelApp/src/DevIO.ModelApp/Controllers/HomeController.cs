using DevIO.ModelApp.Data;
using DevIO.ModelApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DevIO.ModelApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        public OperationService OperationService { get; set; }
        public OperationService OperationService2 { get; set; }

        public HomeController(OperationService operationService, OperationService operationService2)
        {
            OperationService = operationService;
            OperationService2 = operationService2;
            //IOrderRepository orderRepository
            //_orderRepository = orderRepository;
        }

        public string Index()
        {
            //[FromServices]IOrderRepository _orderRepository2
            //var order = _orderRepository.GetOrder();
            //var order2 = _orderRepository2.GetOrder();

            return
                "First instance: " + Environment.NewLine +
                OperationService.Transient.OperationId + Environment.NewLine +
                OperationService.Scoped.OperationId + Environment.NewLine +
                OperationService.Singleton.OperationId + Environment.NewLine +
                OperationService.SingletonInstance.OperationId + Environment.NewLine +

                Environment.NewLine +
                Environment.NewLine +

                "Second instance: " + Environment.NewLine +
                OperationService2.Transient.OperationId + Environment.NewLine +
                OperationService2.Scoped.OperationId + Environment.NewLine +
                OperationService2.Singleton.OperationId + Environment.NewLine +
                OperationService2.SingletonInstance.OperationId + Environment.NewLine;
        }
    }
}
