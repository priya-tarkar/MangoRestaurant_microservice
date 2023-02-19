namespace Mango.Services.Shopping.Cart.Models.Dto
{
    public class CartDto
    {
        public CartHeaderDto cartHeader { get; set; }
        public IEnumerable<CartDetailDto> cartDetail { get; set; }
    }
}
