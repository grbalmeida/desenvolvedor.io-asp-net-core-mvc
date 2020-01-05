using DevIO.App.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DevIO.App.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        [DisplayName("Supplier")]
        public Guid SupplierId { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(200, ErrorMessage = "{0} field must be between {2} and {1} characters", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(1000, ErrorMessage = "{0} field must be between {2} and {1} characters", MinimumLength = 2)]
        public string Description { get; set; }

        [DisplayName("Upload Image")]
        public IFormFile UploadImage { get; set; }

        public string Image { get; set; }


        [Required(ErrorMessage = "The {0} field is required")]
        [Currency]
        public decimal Price { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Creation Date")]
        public DateTime CreationDate { get; set; }

        [DisplayName("Active?")]
        public bool Active { get; set; }

        /* EF - Relations */

        public SupplierViewModel Supplier { get; set; }
        public IEnumerable<SupplierViewModel> Suppliers { get; set; }
    }
}
