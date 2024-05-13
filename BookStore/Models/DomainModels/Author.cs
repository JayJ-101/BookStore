using System.ComponentModel.DataAnnotations;

namespace BookStore.Models  
{
    public class Author
    {
        public Author() => Books = new HashSet<Book>();
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Please enter First Name.")]
        [MaxLength(200)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "PLease enter Last Name")]
        [MaxLength(200)]
        public string LastName { get; set; }=string.Empty;

        public string FullName => $"{FirstName} {LastName}";

        //navigation prop
        public ICollection<Book> Books { get; set; }
    }
}
