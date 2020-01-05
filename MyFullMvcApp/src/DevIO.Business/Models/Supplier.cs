using System.Collections.Generic;

namespace DevIO.Business.Models
{
    public class Supplier : Entity
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public SupplierType SupplierType { get; set; }
        public Address Address { get; set; }
        public bool Active { get; set; }

        /* EF - Relations */

        public IEnumerable<Product> Products { get; set; }
    }
}
