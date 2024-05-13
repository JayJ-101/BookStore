namespace BookStore.Models  
{
    public class CartListViewModel
    {
        public IEnumerable<CartItem> List { get; set; } =new List<CartItem>();  
        public double Subtotal { get;set; }

    }
}
