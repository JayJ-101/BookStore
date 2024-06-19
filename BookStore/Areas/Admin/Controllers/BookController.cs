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
        public ViewResult Add()
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

                TempData["message"] = $"{vm.Book.Title} added to Books.";
                return RedirectToAction("Index");  // PRG pattern
            }
            else
            {
                LoadViewData(vm);
                return View("Book", vm);
            }
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            var vm = new BookViewModel
            {
                Book = GetBook(id)
            };
            LoadViewData(vm);
            return View("Book", vm);
        }
        [HttpPost]
        public IActionResult Edit(BookViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var book = GetBook(viewModel.Book.BookId);
                book.Title = viewModel.Book.Title;
                book.GenreId = viewModel.Book.GenreId;
                book.Price = viewModel.Book.Price;

                bookData.AddNewAuthors(book, viewModel.SelectedAuthors, authorData);
                bookData.Save();
                TempData["message"] = $"{viewModel.Book.Title} updated";
                return RedirectToAction("Index");
            }
            else
            {
                LoadViewData(viewModel);
                return View("Book", viewModel);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var vm = new BookViewModel
            {
                Book = bookData.Get(id) ?? new Book()
            };
            return View("Book", vm);
        }
        [HttpPost]
        public IActionResult Delete(Book book)
        {
            bookData.Delete(book);
            bookData.Save();
            TempData["message"] = $"{book.Title} removed from books.";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ViewResult Related(string id)
        {
            var parts = id.Split('-');
            string type = parts[0];
            id = parts[1];

            var options = new QueryOptions<Book>()
            {
                OrderBy = b => b.Title,
                Includes  = "Authors, Genre"
            };
            if (type.EqualsNoCase("authoro"))
                options.Where = b => b.Authors.Any(ba => ba.AuthorId == id.ToInt());
            else if (type.EqualsNoCase("genre"))
                options.Where = b => b.GenreId.ToLower() == id;
            return View(bookData.List(options));
        }
        /// <summary>
        /// private helper method 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private Book GetBook(int id)
        {
            var options = new QueryOptions<Book>
            {
                Where = b => b.BookId == id,
                Includes = "Authors"
            };
            return bookData.Get(options) ?? new Book();
        }
        private void LoadViewData(BookViewModel vm)
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
