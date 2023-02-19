using Mango.Web.Models;

namespace Mango.Web.Services.IServices
{
    public interface IProductServices:IBaseService
    {
        Task<T> GetAllProductAsync<T>(string Token);
        Task<T> GetProductByIDAsync<T>(int id, string Token);
        Task<T> CreateProductAsync<T>(ProductDto productDto, string Token);
        Task<T> UpdateProductAsync<T>(ProductDto productDto, string Token);
        Task<T> DeleteProductAsync<T>(int id, string Token);
    }
}
