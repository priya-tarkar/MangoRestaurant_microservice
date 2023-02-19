using Mango.Services.Shopping.Cart.Models.Dto;

namespace Mango.Services.Shopping.Cart.Repository
{
    public interface ICartRepository
    {
        Task<CartDto> GetById(string userId);
        Task<CartDto> CreateandUpdate(CartDto cartDto);
        Task<bool> RemoveCart(int cartDetailsId);
        Task<bool> ClearCart(string userId);
    }
}
