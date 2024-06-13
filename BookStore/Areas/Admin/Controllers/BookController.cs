using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace BookStore.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
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

        [HttpPost]
        public RedirectToActionResult Select(int id, string operation)
        {
            switch(operation.ToLower()) {
                case"edit" :
                    return RedirectToAction("Edit", new {id});
                case"delete" :
                    return RedirectToAction("Delete", new {id});
                default:
                    return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            var vm = new BookViewModel();
            LoadViewData(vm);
            return View("Book", vm);
        }

        [HttpPost]
        public IActionResult Add(BookViewModel vm)
        {
            if (ModelState.IsValid)
            {
                bookData.AddNewAuthors(vm.Book, vm.SelectedAuthors, authorData);
                bookData.Insert(vm.Book);
                bookData.Save();

                TempData["message"] = $"{vm.Book.Title} added to Books";
                return RedirectToAction("Index");
            }
            else
            {
                LoadViewData(vm);
                return View("Book", vm);
            }
        }
        [HttpGet]


        public void LoadViewData(BookViewModel vm)
        {
            vm.SelectedAuthors = vm.Authors?.Select(
                ba => ba.AuthorId).ToArray() ?? null!;
            vm.Authors = authorData.List(new QueryOptions<Author>
            {
                OrderBy = a => a.FirstName
            });
            vm.Genres = genreData.List(new QueryOptions<Genre>
            {
                OrderBy = g => g.Name
            });
        }
    }
}
