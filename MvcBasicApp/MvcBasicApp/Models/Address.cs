using System;
using System.ComponentModel.DataAnnotations;

namespace MvcBasicApp.Models
{
    public class Address : Entity
    {
        public Guid SupplierId { get; set; }
        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(200, ErrorMessage = "{0} field must be between {2} and {1} characters", MinimumLength = 2)]
        public string Street { get; set; }
        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(50, ErrorMessage = "{0} field must be between {2} and {1} characters", MinimumLength = 1)]
        public string Number { get; set; }
        public string Complement { get; set; }
        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(8, ErrorMessage = "{0} field must be 8 characters", MinimumLength = 8)]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(100, ErrorMessage = "{0} field must be between {2} and {1} characters", MinimumLength = 2)]
        public string District { get; set; }
        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(100, ErrorMessage = "{0} field must be between {2} and {1} characters", MinimumLength = 2)]
        public string City { get; set; }
        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(50, ErrorMessage = "{0} field must be between {2} and {1} characters", MinimumLength = 2)]
        public string State { get; set; }

        /* EF - Relations */

        public Supplier Supplier { get; set; }
    }
}
