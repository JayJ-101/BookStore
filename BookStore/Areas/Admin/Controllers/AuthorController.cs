using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Areas.Admin.Controllers
{
    [Authorize(Roles="Admin")]
    [Area("Admin")]
    public class AuthorController : Controller
    {
        private Repository<Author> data { get; set; }
        public AuthorController(BookstoreContext ctx) => data = new Repository<Author>(ctx);

        public ViewResult Index()
        {
            var authors = data.List(new QueryOptions<Author>
            {
                OrderBy = a => a.FirstName
            });
            return View(authors);
        }

        [HttpPost]
        public RedirectToActionResult Select(int id, string operation)
        {
            switch(operation.ToLower())
            {
                case "edit": 
                    return RedirectToAction("Edit", new { id });    
                case "delete":
                    return RedirectToAction("Delete", new { id });
                default:
                    return RedirectToAction("Index");
            }
        }

        #region Add Author

        [HttpGet]
        public ViewResult Add() => View("Author", new Author());

        [HttpPost]
        public IActionResult Add(Author author, string operation)
        {
            var validate = new Validate(TempData);
            if (!validate.IsAuthorChecked)
            {
                validate.CheckAuthor(author.FirstName, author.LastName, operation, data);
                if(!validate.IsValid)
                    ModelState.AddModelError(nameof(author.LastName), validate.ErrorMessage);
            }
            if (ModelState.IsValid)
            {
                data.Insert(author);
                data.Save();
                validate.ClearAuthor();
                TempData["message"] = $"{author.FullName} added to Authors.";
                return RedirectToAction("Index"); 
            }
            else
                return View(author);
        }


        #endregion

        #region Delete Author
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var author = data.Get(new QueryOptions<Author>
            {
                Where = a => a.AuthorId == id,
                Includes = "Books"
            }) ;
            if (author != null && author.Books.Count > 0)
            {
                TempData["mesdage"] = $"Cant't delete author {author.FullName} " +
                    "because they have related books.";
                return RedirectToAction("Related", "Book",
                    new { id = "author-" + id });
            }
            else
                return View("Author", author);
        }
        [HttpPost]
        public RedirectToActionResult Delete(Author author)
        {
            data.Delete(author);
            data.Save();
            TempData["message"] = $"{author.FullName} removed form Authors.";
            return RedirectToAction("Index");
        }
        #endregion

    }
}
