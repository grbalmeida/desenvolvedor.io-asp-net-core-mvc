using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "The Title field is required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 60 characters")]
        public string Title { get; set; }
        [Required(ErrorMessage = "The Release Date field is required")]
        [DataType(DataType.DateTime, ErrorMessage = "Date in incorrect format")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\u00C0-\u00FF""'\w-]*$", ErrorMessage = "Invalid format genre")]
        [StringLength(30, ErrorMessage = "30 characters max"), Required(ErrorMessage = "Genre field is required")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "Price field is required")]
        [Range(1, 1000, ErrorMessage = "Price from 1 to 1000")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Rating field is required")]
        [Display(Name = "Rating")]
        [RegularExpression(@"^[0-5]*$", ErrorMessage = "Number only")]
        public int Rating { get; set; }
    }
}
