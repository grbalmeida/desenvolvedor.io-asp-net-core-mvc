using System;

namespace DevIO.ModelApp.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        
        public Order()
        {
            Id = Guid.NewGuid();
        }
    }
}
