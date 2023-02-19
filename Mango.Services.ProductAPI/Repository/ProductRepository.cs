using AutoMapper;
using Mango.Services.ProductAPI.DbContexts;
using Mango.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        //doubt 
        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product=_mapper.Map<Product>(productDto);
            if(product.ProductId>0)
            { //doubt
                _db.Products.Update(product);
            }
            else
            {
                _db.Products.Add(product);
            }
           await _db.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);

            
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product = await _db.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
                _db.Products.Remove(product);
                _db.SaveChanges();
                if (product == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product product = await _db.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List <Product> products= await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}
