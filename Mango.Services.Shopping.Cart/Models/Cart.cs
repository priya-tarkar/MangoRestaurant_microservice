namespace Mango.Services.Shopping.Cart.Models
{
    public class Cart
    {
        public CartHeader cartHeader { get; set; }
        public IEnumerable<CartDetail> cartDetail { get; set; }
    }
}
