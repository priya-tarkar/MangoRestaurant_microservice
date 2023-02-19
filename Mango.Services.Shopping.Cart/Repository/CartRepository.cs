using AutoMapper;
using Mango.Services.Shopping.Cart.DbContexts;
using Mango.Services.Shopping.Cart.Models.Dto;

namespace Mango.Services.Shopping.Cart.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public CartRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public Task<bool> ClearCart(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<CartDto> CreateandUpdate(CartDto cartDto)
        {
            Mango.Services.Shopping.Cart.Models.Cart cart = _mapper.Map<Mango.Services.Shopping.Cart.Models.Cart>(cartDto);
            var productcheck=_db.Products.FirstOrDefault(u=>u.ProductId==cartDto.cartDetail.FirstOrDefault().ProductId);
            if (productcheck == null) {
                _db.Products.Add(cart.cartDetail.FirstOrDefault().Product);
                await _db.SaveChangesAsync();
            }
            //as addnotracking
            var cartheader = _db.CartHeaders.FirstOrDefault(u => u.UserId == cart.cartHeader.UserId);

        }

        public Task<CartDto> GetById(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveCart(int cartDetailsId)
        {
            throw new NotImplementedException();
        }
    }
}
