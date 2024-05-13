namespace BookStore.Models  
{
    public class BookDTO
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public double Price { get; set; }
        public Dictionary<int,string>Authors { get; set; } = new Dictionary<int, string>();

        public BookDTO() { }

        public BookDTO(Book book)
        {
            BookId = book.BookId;
            Title = book.Title;
            Price = book.Price;
            if(book.Authors?.Count > 0) { 
                foreach(Author a in book.Authors)
                {
                    Authors.Add(a.AuthorId, a.FullName);
                }
            }
        }
    }
}
