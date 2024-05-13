using BookStore.Models.ExtensionMethods;
using Microsoft.AspNetCore.Http;

namespace BookStore.Models  
{
    public class Cart
    {
        private const string CartKey = "myCart";
        private const string CountKey = "myCount";

        private ISession session { get; set; }
        private IRequestCookieCollection requestCookies { get; set; }   
        private IResponseCookies responseCookies { get; set; }

        private List<CartItem> items { get; set; } = null!;
        private List<CartItemDTO> cookieItems { get; set; } = null!;

        public Cart(HttpContext ctx)
        {
            session = ctx.Session;
            requestCookies = ctx.Request.Cookies;
            responseCookies = ctx.Response.Cookies; 
        }

        public void Load(Repository<Book> data)
        {
            //cart items from session and cookies
            items = session.GetObject<List<CartItem>>(CartKey) 
                ?? new List<CartItem>();
            cookieItems = requestCookies.GetObject<List<CartItemDTO>>(CartKey) 
                ?? new List<CartItemDTO>() ;

            if (cookieItems.Count > items.Count)
            {
                items.Clear();

                foreach(CartItemDTO storeItem in cookieItems)
                {
                    var book = data.Get(new QueryOptions<Book>
                    {
                        Where = b => b.BookId == storeItem.BookId,
                        Includes = "Authors, Genre"
                    });
                    if (book != null)
                    {
                        CartItem item = new CartItem
                        {
                            Book = new BookDTO(book),
                            Quantity = storeItem.Quantity
                        };
                        items.Add(item);
                    }
                }
                Save();
            }

        }
        
        public double Subtotal => items.Sum(i => i.Subtotal);
        public int? Count => session.GetInt32(CountKey) ?? requestCookies.GetInt32(CountKey);
        public IEnumerable<CartItem> List => items;
        
        public CartItem? GetById(int? id)
        {
            if (items == null || id == null)
            {
                return null;
            }
            else
            {
                return items.FirstOrDefault(ci => ci.Book?.BookId == id);
            }
            
        }

        // if the user clicks "Add to Cart" and the item
        // is already in the cart, it's updated rather than duplicated.
        public void Add(CartItem item)
        {
            var itemInCart = GetById(item.Book.BookId);
            // if new, add
            if (itemInCart == null)
            {
                items.Add(item);
            }
            else
            {  // otherwise, increase quantity amount by 1
                itemInCart.Quantity += 1;
            }
        }
        // when editing, replace quantity value with new one. Used when user edits a cart item
        // and changes its quantity
        public void Edit(CartItem item)
        {
            var itemInCart = GetById(item.Book.BookId);
            if (itemInCart != null)
            {
                itemInCart.Quantity = item.Quantity;
            }
        }

        public void Remove(CartItem item) => items.Remove(item);
        public void Clear() => items.Clear();

        public void Save()
        {
            if (items.Count == 0)
            {
                session.Remove(CartKey);
                session.Remove(CountKey);
                responseCookies.Delete(CartKey);
                responseCookies.Delete(CountKey);
            }
            else
            {
                session.SetObject<List<CartItem>>(CartKey, items);
                session.SetInt32(CountKey, items.Count);
                responseCookies.SetObject<List<CartItemDTO>>(CartKey, items.ToDTO());
                responseCookies.SetInt32(CountKey, items.Count);
            }
        }
    }
}
