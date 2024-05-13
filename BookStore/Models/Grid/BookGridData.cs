using System.Text.Json.Serialization;

namespace BookStore.Models  
{
    public class BookGridData :GridData
    {
        public BookGridData() => SortField = nameof(Book.Title);

        [JsonIgnore]
        public bool IsSortByGenre =>
            SortField.EqualsNoCase(nameof(Genre));
        [JsonIgnore]
        public bool IsSortByPrice => 
            SortField.EqualsNoCase(nameof(Book.Price));
    }
}
