using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcBasicApp.Models
{
    public class Supplier : Entity
    {
        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(100, ErrorMessage = "{0} field must be between {2} and {1} characters", MinimumLength = 2)]
        public string Name { get; set; }
        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(14, ErrorMessage = "{0} field must be between {2} and {1} characters", MinimumLength = 11)]
        public string Document { get; set; }
        public SupplierType SupplierType { get; set; }
        public Address Address { get; set; }
        [DisplayName("Active?")]
        public bool Active { get; set; }

        /* EF Relations */

        public IEnumerable<Product> Products { get; set; }
    }
}
