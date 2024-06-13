namespace BookStore.Models
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BookstoreContext ctx) : base(ctx) { }
        public void AddNewAuthors(Book book, int[] authorids, IRepository<Author> authorData)
        {
            foreach(Author auth in book.Authors)
            {
                book.Authors.Remove(auth);
            }

            foreach(int id in authorids)
            {
                Author? author = authorData.Get(id);    
                if(author != null) 
                    book.Authors.Add(author);
            }
        }
    }
}
