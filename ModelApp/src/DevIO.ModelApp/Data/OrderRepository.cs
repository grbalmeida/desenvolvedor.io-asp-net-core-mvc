using DevIO.ModelApp.Models;

namespace DevIO.ModelApp.Data
{
    public class OrderRepository : IOrderRepository
    {
        public Order GetOrder()
        {
            return new Order();
        }
    }

    public interface IOrderRepository
    {
        Order GetOrder();
    }
}
