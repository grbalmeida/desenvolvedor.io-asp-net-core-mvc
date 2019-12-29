using System;
using System.ComponentModel.DataAnnotations;

namespace MvcBasicApp.Models
{
    public class Product : Entity
    {
        public Guid SupplierId { get; set; }
        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(200, ErrorMessage = "{0} field must be between {2} and {1} characters", MinimumLength = 2)]
        public string Name { get; set; }
        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(1000, ErrorMessage = "{0} field must be between {2} and {1} characters", MinimumLength = 2)]
        public string Description { get; set; }
        [Required(ErrorMessage = "The {0} field is required")]
        public string Image { get; set; }
        [Required(ErrorMessage = "The {0} field is required")]
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Active { get; set; }

        /* EF - Relations */

        public Supplier Supplier { get; set; }
    }
}
