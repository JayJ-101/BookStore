using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class AuthorController : Controller
    {
        private Repository<Author> _repository{ get; set; }
        public AuthorController(BookstoreContext ctx) => _repository = new Repository<Author>(ctx);

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ViewResult List(AuthorGridData values)
        {
            //create optionsfor Query Author
            var options = new QueryOptions<Author>
            {
                Includes = "Books",
                PageNumber = values.PageNumber,
                PageSize = values.PageSize,
                OrderByDirection = values.SortDirection,
            };
            if(values.IsSortByFirstName)
                options.OrderBy = a=> a.FirstName;
            else
                options.OrderBy = a=> a.LastName;

            /*create view model and add page of author data, current grid route
                segment and the total number of pages*/
            var vm = new AuthorListViewModel
            {
                Authors = _repository.List(options),
                CurrentRoute = values,
                TotalPages = values.GetTotalPages(_repository.Count)

            };
            return View (vm);   
        }

        public IActionResult Details(int id) {
            var author = _repository.Get(new QueryOptions<Author>{
                Where = a => a.AuthorId == id,
                Includes = "Books"
            }) ?? new Author();
            return View (author);
        }
    }
}
