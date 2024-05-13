using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Genre
    {
        public Genre() => Books = new List<Book>();

        [MaxLength(10)]
        [Required(ErrorMessage = "Please enter a genre ID.")]
        [Remote("CheckGenre", "Validation", "Admin")]
        public string GenreId { get; set; } =  string.Empty;

        [StringLength(25)]
        [Required(ErrorMessage = "Please enter genre name.")]
        public string Name { get; set; } = string.Empty;

        public ICollection<Book> Books { get; set; }
    }
}
