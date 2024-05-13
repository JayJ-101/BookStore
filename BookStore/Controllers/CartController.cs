using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class CartController : Controller
    {
        private Repository<Book> data { get; set; }
        public CartController(BookstoreContext ctx) => data = new Repository<Book>(ctx);
        
        private Cart GetCart()
        {
            var cart = new Cart(HttpContext);
            cart.Load(data);
            return cart;
        }

        public ViewResult Index()
        {
            Cart cart = GetCart();
            var vm = new CartListViewModel()
            {
                List = cart.List,
                Subtotal = cart.Subtotal
            }; ;
            return View(vm);
        }

        [HttpPost]
        public RedirectToActionResult Add(int id)
        {
            var book = data.Get(new QueryOptions<Book>()
            {
                Where = b => b.BookId == id,
                Includes = "Authors, Genre"
            });
            if(book == null)
            {
                TempData["message"] = "unable to add book to cart.";
            }
            else
            {
                CartItem item = new CartItem
                {
                    Book = new BookDTO(book),
                    Quantity = 1
                };
                Cart cart = GetCart();
                cart.Add(item);
                cart.Save();

                TempData["message"] = $"{book.Title} added to cart";
            }
            return RedirectToAction("List","Book");
        }

        [HttpPost]
        public RedirectToActionResult Remove(int id)
        {
            Cart cart = GetCart();
            CartItem? item = cart.GetById(id);
            if (item != null)
            {
                cart.Remove(item);
                cart.Save();
                TempData["message"] = $"{item.Book.Title} removed from cart";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public RedirectToActionResult Clear()
        {
            Cart cart = GetCart();
            cart.Clear();
            cart.Save();

            TempData["message"] = "Cart cleared.";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id) {
            Cart cart = GetCart();
            CartItem? item = cart.GetById(id);
            if (item == null)
            {
                TempData["message"] = "Unable to locate cart item.";
                return RedirectToAction("Index");
            }
            else
                return View(item);
        }
        [HttpPost]
        public RedirectToActionResult Edit(CartItem item)
        {
            Cart cart = GetCart();
            cart.Edit(item);
            cart.Save();

            TempData["message"] = $"{item.Book.Title} updated";
            return RedirectToAction("Index");   
        }
        public ViewResult Checkout() => View();
    }
}
