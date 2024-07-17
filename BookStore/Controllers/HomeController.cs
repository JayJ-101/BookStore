using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private Repository<Book> data { get; set; }
      

        public HomeController(BookstoreContext ctx) => data = new Repository<Book>(ctx);

        public IActionResult Index()
        {
            var randomBooks = GetRandomBooks(3);
            return View(randomBooks);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        private IEnumerable<Book> GetRandomBooks(int count)
        {
            var allBooks = data.List(new QueryOptions<Book>
            {
                OrderBy = b=> Guid.NewGuid()
            });
            return allBooks.Take(count);
        }




    }
}
