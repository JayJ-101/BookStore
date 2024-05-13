using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public partial class Book
    {
        public Book() => Authors = new HashSet<Author>();

        public int BookId { get; set; }

        [Required(ErrorMessage = "Please enter a title.")]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Range(1.0, 1000000.0, ErrorMessage = "Price must be 1 or more.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Please select a genre.")]
        public string GenreId { get; set; } = string.Empty;

        [ValidateNever]
        public Genre Genre { get; set; }
        public ICollection<Author>Authors { get; set; }
    }
}
