using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {

        private BookRepository bookData { get; set; }
        private Repository<Author> authorData { get; set; }
        private Repository<Genre> genreData { get;set; }
        public BookController(BookstoreContext ctx)
        {
            bookData = new BookRepository(ctx);
            authorData = new Repository<Author>(ctx);   
            genreData = new Repository<Genre>(ctx);
        }


        public ViewResult Index()
        {
            var books = bookData.List(new QueryOptions<Book>{ 
                OrderBy = b => b.Title,
            });

            return View(books);
        }
    }
}
