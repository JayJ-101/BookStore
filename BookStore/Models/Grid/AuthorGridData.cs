using BookStore.Models;
using System.Text.Json.Serialization;

namespace BookStore.Models
{
    public class AuthorGridData : GridData
    {
        public AuthorGridData() => SortField = nameof(Author.FirstName);
        [JsonIgnore]
        //public bool IsSortByFirstName => 
        //    SortField.Equals(nameof(Author.FirstName), StringComparison.OrdinalIgnoreCase);

        public bool IsSortByFirstName =>
            SortField.EqualsNoCase(nameof(Author.FirstName));

    }
}
